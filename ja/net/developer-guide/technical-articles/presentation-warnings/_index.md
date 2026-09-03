---
title: .NET でのプレゼンテーション警告の処理
type: docs
weight: 120
url: /ja/net/presentation-warnings/
aliases:
- /net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- 警告コールバック
- 警告ポリシー
- データ損失
- ソース破損
- 互換性の問題
- フォント置換
- デジタル署名
- プレゼンテーションの読み込み
- プレゼンテーションのレンダリング
- プレゼンテーションの変換
- プレゼンテーションの保存
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用してプレゼンテーションを読み込み、レンダリング、変換、保存する際に、警告を収集・分類・対処する方法を学びます。"
---
## **概要**

Aspose.Slides は、プレゼンテーションの読み込み、レンダリング、変換、保存中に回復可能な問題を報告できます。例として、破損したソースレコード、保存できないコンテンツ、フォントの置換、ターゲット形式の制限などがあります。警告コールバックを使用すると、アプリケーションはこれらの状態を記録し、現在の操作を続行できるかどうかを決定できます。

[IWarningCallback] インターフェイスを実装し、[IWarningInfo] から提供される [WarningType] と [Description] プロパティを調べます。警告を受け入れるには [ReturnAction.Continue] を返し、操作を停止するには `ReturnAction.Abort` を返します。

プレゼンテーションを開く際に発生する警告には [LoadOptions.WarningCallback] を使用します。レンダリングおよびエクスポート オプション クラスは [SaveOptions.WarningCallback] を継承し、スライドのレンダリング、変換、保存時の警告を受け取ります。警告自体はアプリケーションの操作を特定しないため、結合レポートを作成する際に各コールバック インスタンスに操作ステージを関連付けます。

## **警告と例外**

警告は、コールバックが `ReturnAction.Continue` を返した場合に Aspose.Slides が回復できる状態を表します。例外は、要求された操作を正常に完了できないことを意味し、例外は警告に変換されず、警告ポリシーで処理できません。

`ReturnAction.Abort` を返すと、警告ディスパッチャに例外を発生させて現在の操作を終了させるよう要求します。公開される例外は操作やプレゼンテーション形式によって異なります。たとえば、ロード時には [PptxReadException] や [PptReadException] が発生し、保存またはエクスポート時には [PptxException] が発生することがあります。例外は操作の境界で処理し、警告レポートを使用して終了がアプリケーション ポリシーによるものか、特定の例外サブタイプやメッセージに依存しているかを判断します。コールバックは `ReturnAction.Abort` を返す前に警告を記録し、理由がアプリケーションで利用可能であることを保証します。

## **警告カテゴリ**

[WarningType] 列挙体は次のカテゴリを提供します：

| 警告タイプ | 意味 | 典型的なポリシー |
| --- | --- | --- |
| `SourceFileCorruption` | 元のプレゼンテーションに破損が含まれており、元の形式で保存された文書が使用できなくなる可能性があります。 | 中止。 |
| `DataLoss` | ロードまたは保存後にテキスト、チャート、画像、その他のデータが欠落している可能性があります。 | 中止。 |
| `MajorFormattingLoss` | プレゼンテーションの重要な書式設定が失われる可能性があります。 | 厳密な検証モードでは中止、そうでなければ記録して続行。 |
| `MinorFormattingLoss` | 限定的な書式差異が発生する可能性があります。 | 診断のために記録し、続行。 |
| `CompatibilityIssue` | 結果が一部のアプリケーションや古いバージョンで正しく開かれない、または正しく動作しない可能性があります。 | 互換性が必須でない限り、ログに記録して続行。 |
| `UnexpectedContent` | ソースにサポートされていない、または認識できないコンテンツが含まれており、その影響はまだ不明です。 | 記録して続行、または厳密なポリシーではエラーとして扱う。 |

カテゴリはポリシー決定の指針とすべきです。`Description` を診断情報として保存しますが、警告シナリオや製品バージョンによりメッセージ本文が変わるため、アプリケーションロジックでその文言に依存しないでください。

## **警告の収集と分類**

以下の例は、完全な処理パイプラインに対してアプリケーションレベルのレポートを 1 つ使用します。別々のコールバック インスタンスがロード、レンダリング、PDF 変換、PPTX 保存からの警告にラベルを付けます。ポリシーはソースの破損やデータ損失で中止し、必要に応じて主要な書式損失でも中止し、その他の警告は続行します。

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;

internal static class PresentationWarningExample
{
    public static void Main()
    {
        var report = new WarningReport();
        var policy = new WarningPolicy(abortOnMajorFormattingLoss: true);
        var completed = ProcessPresentation("input.pptx", report, policy);

        Console.WriteLine(completed ? "Processing completed." : "Processing stopped.");

        foreach (var entry in report.Entries)
        {
            Console.WriteLine($"[{entry.Stage}] {entry.Type}: {entry.Description}");
        }
    }

    private static bool ProcessPresentation(string inputPath, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var loadOptions = new LoadOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Loading, report, policy)
            };

            using var presentation = new Presentation(inputPath, loadOptions);

            if (!RenderFirstSlide(presentation, report, policy))
            {
                return false;
            }

            if (!ConvertToPdf(presentation, report, policy))
            {
                return false;
            }

            return SaveValidatedCopy(presentation, report, policy);
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Loading stopped: {exception.Message}");
            return false;
        }
    }

    private static bool RenderFirstSlide(Presentation presentation, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var options = new RenderingOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Rendering, report, policy)
            };

            using var image = presentation.Slides[0].GetImage(options);
            image.Save("slide-1.png", ImageFormat.Png);
            return true;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Rendering stopped: {exception.Message}");
            return false;
        }
    }

    private static bool ConvertToPdf(Presentation presentation, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var options = new PdfOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Conversion, report, policy)
            };

            presentation.Save("converted.pdf", SaveFormat.Pdf, options);
            return true;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Conversion stopped: {exception.Message}");
            return false;
        }
    }

    private static bool SaveValidatedCopy(Presentation presentation, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var options = new PptxOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Saving, report, policy)
            };

            presentation.Save("validated-output.pptx", SaveFormat.Pptx, options);
            return true;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Saving stopped: {exception.Message}");
            return false;
        }
    }

    private enum OperationStage
    {
        Loading,
        Rendering,
        Conversion,
        Saving
    }

    private sealed class WarningEntry
    {
        public WarningEntry(OperationStage stage, WarningType type, string description)
        {
            Stage = stage;
            Type = type;
            Description = description;
        }

        public OperationStage Stage { get; }

        public WarningType Type { get; }

        public string Description { get; }
    }

    private sealed class WarningReport
    {
        private readonly List<WarningEntry> _entries = new List<WarningEntry>();

        public IReadOnlyList<WarningEntry> Entries => _entries;

        public void Add(OperationStage stage, IWarningInfo warning)
        {
            _entries.Add(new WarningEntry(stage, warning.WarningType, warning.Description));
        }
    }

    private sealed class WarningPolicy
    {
        private readonly bool _abortOnMajorFormattingLoss;

        public WarningPolicy(bool abortOnMajorFormattingLoss)
        {
            _abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
        }

        public ReturnAction GetAction(WarningType warningType)
        {
            if (warningType == WarningType.SourceFileCorruption || warningType == WarningType.DataLoss)
            {
                return ReturnAction.Abort;
            }

            if (warningType == WarningType.MajorFormattingLoss && _abortOnMajorFormattingLoss)
            {
                return ReturnAction.Abort;
            }

            return ReturnAction.Continue;
        }
    }

    private sealed class ReportingWarningCallback : IWarningCallback
    {
        private readonly OperationStage _stage;
        private readonly WarningReport _report;
        private readonly WarningPolicy _policy;

        public ReportingWarningCallback(OperationStage stage, WarningReport report, WarningPolicy policy)
        {
            _stage = stage;
            _report = report;
            _policy = policy;
        }

        public ReturnAction Warning(IWarningInfo warning)
        {
            _report.Add(_stage, warning);
            return _policy.GetAction(warning.WarningType);
        }
    }
}
```

主要な書式差異が許容できる場合は、`abortOnMajorFormattingLoss` を `false` に設定します。互換性の問題、軽微な書式損失、予期しないコンテンツは、操作が続行された場合でもレポートに保持されます。アプリケーションがこれらのカテゴリのいずれかを拒否する必要がある場合は、`WarningPolicy.GetAction` を拡張してください。

## **一般的な警告シナリオ**

警告はワークフローのさまざまな段階で発生する可能性があります:

- **デジタル署名:** 署名されたプレゼンテーションは、ロード時に処理中に署名が失われるという警告を生成することがあります。Aspose.Slides はこの `DataLoss` 状態を [IPresentationSignedWarningInfo] を通じて報告します。ロード段階のコールバックにより、アプリケーションはファイルを拒否するか、報告された損失を明示的に受け入れることができます。
- **フォント置換:** 利用できないフォントは、スライドがレンダリングまたはエクスポートされる際に置き換えられることがあります。フォント置換の警告は `DataLoss` として報告されるため、上記の厳格なポリシーでは、アプリケーションが視覚的に許容できる置換であっても中止します。この動作を確認するには、実行時に使用できないフォントでテキストが含まれるプレゼンテーションを使用してください。警告の説明は置換を特定します。必要なフォントまたは [font substitution rules](/slides/ja/net/font-substitution/) を設定してから再試行します。
- **サポートされていないまたは予期しないコンテンツ:** ローダーは認識できないプレゼンテーションレコードや機能に遭遇することがあります。このような警告は `UnexpectedContent` を使用する場合や、データや書式が影響を受けることが判明している場合はより重大なカテゴリになることがあります。
- **形式の互換性:** 別のプレゼンテーション形式に保存すると、機能が省略されたり、一部のアプリケーションで動作が異なる結果になることがあります。たとえば、水平または垂直の描画ガイドが 8 本以上あるプレゼンテーションを従来の PPT に保存すると `CompatibilityIssue` が報告されます。保存段階のコールバックは損失を記録して続行するか、すべてのガイドを保持する必要がある場合は拒否できます。
- **ロードの動作:** ロード オプションやレガシー動作も警告を生成することがあります。たとえば、[IObsoletePresLockingBehaviorWarningInfo] は、廃止されたプレゼンテーションロック動作の使用を `CompatibilityIssue` として識別します。

警告はソース ドキュメント、ターゲット形式、操作、および Aspose.Slides のバージョンに依存します。すべてのファイルが警告を生成する、またはシナリオが常に 1 つのカテゴリにのみマップされると想定しないでください。

## **中止された操作の安全な処理**

コールバックが `ReturnAction.Abort` を返した場合、ロードに失敗したオブジェクトを使用せず、レンダリングまたは保存の出力が完了したと想定しないでください。操作は出力ファイルを作成した後、完了する前に終了することがあります。

検証済みの結果は `validated-output.pptx` のような別のパスに保存してください。操作が正常に完了し、警告レポートがアプリケーション ポリシーを満たし、出力が開いて確認できる場合にのみ既存のプレゼンテーションを置き換えます。これにより、部分的または拒否された結果で有効なソース ファイルを上書きすることを防げます。

空の警告レポートは、すべてのソース機能が保持されたことの保証ではありません。アプリケーションで必要な追加のコンテンツおよびビジュアルチェックを実施してください。さらに、[Open Presentations](/slides/ja/net/open-presentation/) と [Save Presentations](/slides/ja/net/save-presentation/) も参照してください。

## **FAQ**

**警告コールバックはすべての Aspose.Slides エラーを処理できますか？**

いいえ。コールバックは警告として報告される回復可能な状態を処理します。コールバックとは独立して発生する例外は、ロード、レンダリング、変換、保存呼び出しの周囲でアプリケーション側で処理する必要があります。

**`ReturnAction.Continue` を返すことで出力が同一になることが保証されますか？**

いいえ。処理を続行できるだけです。報告された状態はデータ、書式、互換性の差異を引き起こす可能性があるため、収集された警告タイプと説明を確認してください。

**アプリケーションは警告を生成した操作をどのように特定できますか？**

各操作ごとにコールバック インスタンスを作成し、例示のように `WarningType` と `Description` に加えてアプリケーション独自のステージを保存します。