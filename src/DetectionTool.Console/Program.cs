using DetectionTool.Core;

RunScan();

static void RunScan() {
  var scanner = new Scanner();

  try {
    var results = scanner.Scan();

    if (results.Detected) {
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine("結果:検出されました");
      Console.WriteLine("マルウェアの痕跡が検出された可能性があります");
      Console.WriteLine();
      Console.WriteLine("不審なファイル:");
      foreach(var detectedFile in results.DetectedFiles) {
        Console.WriteLine($"  => {detectedFile}");
      }
      Console.WriteLine();
      Console.ForegroundColor = ConsoleColor.Blue;
      Console.WriteLine($"次に行うべき事については、こちらをご覧下さい: {DetectionTool.Core.Constants.kSupportArticle}");

    } else {
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine("結果:未検出");
      Console.WriteLine("マルウェアは検出されませんでした");
    }
  } catch (Exception ex) {
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("結果:不確定");
    Console.WriteLine($"スキャンに失敗しました {ex.Message}");
  }

  Console.ResetColor();
}