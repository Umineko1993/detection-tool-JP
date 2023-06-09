using DetectionTool.Core;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DetectionTool {
  public partial class MainWindow : Form {
    public MainWindow() {
      InitializeComponent();
    }

    private void buttonScan_Click(object sender, EventArgs e) {
      var scanner = new Scanner();

      try {
        var results = scanner.Scan();

        groupBoxScanResults.Visible = true;
        if (results.Detected) {
          labelDetectedResult.Text = "YES";
          labelDetectedResult.ForeColor = Color.Red;
          labelSummaryValue.Text = "マルウェアの痕跡が検出された可能性があります";
          labelFoundInStartupValue.Text = results.FoundInStartUp ? "YES" : "NO";
          labelFoundInStartupValue.ForeColor = results.FoundInStartUp ? Color.Red : Color.Green;
          textBoxSuspiciousFiles.Text = string.Join(Environment.NewLine, results.DetectedFiles);
          labelSuspiciousFiles.Visible = true;
          textBoxSuspiciousFiles.Visible = true;
          linkLabelSupport.Visible = true;

        } else {
          labelDetectedResult.Text = "NO";
          labelDetectedResult.ForeColor = Color.Green;
          labelSummaryValue.Text = "マルウェアは検出されませんでした";
          labelFoundInStartupValue.Text = "NO";
          labelFoundInStartupValue.ForeColor = Color.Green;
        }
      } catch (Exception ex) {
        labelDetectedResult.Text = "Inconclusive";
        labelDetectedResult.ForeColor = Color.Orange;
        labelSummaryValue.Text = $"スキャンに失敗しました {ex.Message}";
        labelFoundInStartupValue.Text = "不確定要素";
        labelFoundInStartupValue.ForeColor = Color.Orange;
      }
    }

    private void linkLabelSupport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
      System.Diagnostics.Process.Start(Constants.kSupportArticle);
    }
  }
}
