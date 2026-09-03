---
title: Javaでプレゼンテーションの警告を処理する
type: docs
weight: 90
url: /ja/java/presentation-warnings/
aliases:
- /java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- 警告コールバック
- 警告ポリシー
- データ損失
- ソース破損
- 互換性問題
- フォント置換
- デジタル署名
- プレゼンテーションの読み込み
- プレゼンテーションのレンダリング
- プレゼンテーションの変換
- プレゼンテーションの保存
- PowerPoint
- OpenDocument
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用してプレゼンテーションを読み込み、レンダリング、変換、保存する際の警告を収集、分類、対処する方法を学びます。"
---
## **概要**

Aspose.Slides は、プレゼンテーションの読み込み、レンダリング、変換、または保存中に回復可能な問題を報告できます。例としては、破損したソースレコード、保存できないコンテンツ、フォント置換、ターゲット形式の制限などがあります。警告コールバックを使用すると、アプリケーションはこれらの状態を記録し、現在の操作を継続できるかどうかを判断できます。

[IWarningCallback](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iwarningcallback/) インターフェイスを実装し、[IWarningInfo](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iwarninginfo/) から提供される [getWarningType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iwarninginfo/#getWarningType--) と [getDescription](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iwarninginfo/#getDescription--) の値を調べます。警告を受け入れる場合は [ReturnAction.Continue](https://reference.aspose.com/slides/ja/java/com.aspose.slides/returnaction/#Continue) を返し、操作を中止する場合は [ReturnAction.Abort](https://reference.aspose.com/slides/ja/java/com.aspose.slides/returnaction/#Abort) を返します。

プレゼンテーションのオープン時に発生する警告には [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/ja/java/com.aspose.slides/loadoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) を使用します。レンダリングおよびエクスポートオプションクラスは [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/ja/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) を継承しており、スライドのレンダリング、変換、保存時の警告を受け取ります。警告自体はアプリケーションの操作を特定しないため、結合レポートを作成する際は各コールバックインスタンスに操作段階を関連付けてください。

## **警告と例外**

警告は、コールバックが `ReturnAction.Continue` を返すことで Aspose.Slides が回復できる状態を表します。例外は要求された操作が通常通り完了できないことを意味し、例外は警告に変換されず、警告ポリシーで処理できません。

`ReturnAction.Abort` を返すと、警告ディスパッチャは例外をスローして現在の操作を終了します。公開される例外は操作とプレゼンテーション形式に依存します。たとえば、読み込み時には [PptxReadException](https://reference.aspose.com/slides/ja/java/com.aspose.slides/pptxreadexception/) や [PptReadException](https://reference.aspose.com/slides/ja/java/com.aspose.slides/pptreadexception/) が発生し、保存またはエクスポート時には [PptxException](https://reference.aspose.com/slides/ja/java/com.aspose.slides/pptxexception/) が発生する可能性があります。操作の境界で例外を処理し、警告レポートを用いてアプリケーションポリシーが終了の原因であるかを判断してください。コールバックは `ReturnAction.Abort` を返す前に警告を記録するため、理由はアプリケーションで利用可能です。

## **警告のカテゴリ**

[WarningType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/warningtype/) クラスは以下のカテゴリに対応する整数定数を提供します。

| 警告タイプ | 意味 | 典型的なポリシー |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/ja/java/com.aspose.slides/warningtype/#SourceFileCorruption) | 元のプレゼンテーションに破損があり、元の形式で保存されたドキュメントが使用できなくなる可能性があります。 | Abort. |
| [DataLoss](https://reference.aspose.com/slides/ja/java/com.aspose.slides/warningtype/#DataLoss) | テキスト、チャート、画像、またはその他のデータが読み込みまたは保存後に欠落する可能性があります。 | Abort. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/ja/java/com.aspose.slides/warningtype/#MajorFormattingLoss) | プレゼンテーションが重要な書式設定を失う可能性があります。 | Abort in strict validation mode; otherwise record and continue. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/ja/java/com.aspose.slides/warningtype/#MinorFormattingLoss) | 限定的な書式差異が発生する可能性があります。 | Record for diagnostics and continue. |
| [CompatibilityIssue](https://reference.aspose.com/slides/ja/java/com.aspose.slides/warningtype/#CompatibilityIssue) | 結果が一部のアプリケーションや古いバージョンで正しく開かない、または正しく動作しない可能性があります。 | Log and continue unless compatibility is mandatory. |
| [UnexpectedContent](https://reference.aspose.com/slides/ja/java/com.aspose.slides/warningtype/#UnexpectedContent) | ソースにサポートされていないまたは認識されないコンテンツが含まれており、その影響はまだ不明である可能性があります。 | Record and continue, or treat as an error in a strict policy. |

カテゴリはポリシー決定の指針となります。診断目的で [getDescription](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iwarninginfo/#getDescription--) が返す値を保存してください。ただし、メッセージテキストはシナリオや製品バージョンにより変わるため、アプリケーションロジックでその文言に依存しないでください。

## **警告の収集と分類**

以下の例は、完全な処理パイプライン用にアプリケーションレベルのレポートを 1 つ使用します。別々のコールバックインスタンスが読み込み、レンダリング、PDF 変換、PPTX 保存の警告にラベルを付けます。ポリシーはソース破損またはデータロスで中止し、重要な書式損失はオプションで中止、他の警告は継続します。

```java
import com.aspose.slides.IImage;
import com.aspose.slides.IWarningCallback;
import com.aspose.slides.IWarningInfo;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.PdfOptions;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.RenderingOptions;
import com.aspose.slides.ReturnAction;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.WarningType;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

class PresentationWarningExample {
    public static void main(String[] args) {
        WarningReport report = new WarningReport();
        WarningPolicy policy = new WarningPolicy(true);
        boolean completed = processPresentation("input.pptx", report, policy);

        System.out.println(completed ? "Processing completed." : "Processing stopped.");

        for (WarningEntry entry : report.getEntries()) {
            String typeName = warningTypeName(entry.type);
            System.out.println("[" + entry.stage + "] " + typeName + ": " + entry.description);
        }
    }

    private static boolean processPresentation(String inputPath, WarningReport report, WarningPolicy policy) {
        try {
            LoadOptions loadOptions = new LoadOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Loading, report, policy);
            loadOptions.setWarningCallback(callback);

            Presentation presentation = new Presentation(inputPath, loadOptions);
            try {
                if (!renderFirstSlide(presentation, report, policy)) {
                    return false;
                }

                if (!convertToPdf(presentation, report, policy)) {
                    return false;
                }

                return saveValidatedCopy(presentation, report, policy);
            }
            finally {
                presentation.dispose();
            }
        }
        catch (Exception exception) {
            System.err.println("Loading stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean renderFirstSlide(Presentation presentation, WarningReport report, WarningPolicy policy) {
        if (presentation.getSlides().size() == 0) {
            System.err.println("Rendering stopped: the presentation has no slides.");
            return false;
        }

        try {
            RenderingOptions options = new RenderingOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Rendering, report, policy);
            options.setWarningCallback(callback);

            IImage image = presentation.getSlides().get_Item(0).getImage(options);
            try {
                image.save("slide-1.png", ImageFormat.Png);
                return true;
            }
            finally {
                image.dispose();
            }
        }
        catch (Exception exception) {
            System.err.println("Rendering stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean convertToPdf(Presentation presentation, WarningReport report, WarningPolicy policy) {
        try {
            PdfOptions options = new PdfOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Conversion, report, policy);
            options.setWarningCallback(callback);

            presentation.save("converted.pdf", SaveFormat.Pdf, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Conversion stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean saveValidatedCopy(Presentation presentation, WarningReport report, WarningPolicy policy) {
        try {
            PptxOptions options = new PptxOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Saving, report, policy);
            options.setWarningCallback(callback);

            presentation.save("validated-output.pptx", SaveFormat.Pptx, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Saving stopped: " + exception.getMessage());
            return false;
        }
    }

    private static String warningTypeName(int warningType) {
        switch (warningType) {
            case WarningType.SourceFileCorruption:
                return "SourceFileCorruption";
            case WarningType.DataLoss:
                return "DataLoss";
            case WarningType.MajorFormattingLoss:
                return "MajorFormattingLoss";
            case WarningType.MinorFormattingLoss:
                return "MinorFormattingLoss";
            case WarningType.CompatibilityIssue:
                return "CompatibilityIssue";
            case WarningType.UnexpectedContent:
                return "UnexpectedContent";
            default:
                return "Unknown (" + warningType + ")";
        }
    }

    private enum OperationStage {
        Loading,
        Rendering,
        Conversion,
        Saving
    }

    private static final class WarningEntry {
        final OperationStage stage;
        final int type;
        final String description;

        WarningEntry(OperationStage stage, int type, String description) {
            this.stage = stage;
            this.type = type;
            this.description = description;
        }
    }

    private static final class WarningReport {
        private final List<WarningEntry> entries = new ArrayList<WarningEntry>();

        List<WarningEntry> getEntries() {
            return Collections.unmodifiableList(entries);
        }

        void add(OperationStage stage, IWarningInfo warning) {
            WarningEntry entry = new WarningEntry(stage, warning.getWarningType(), warning.getDescription());
            entries.add(entry);
        }
    }

    private static final class WarningPolicy {
        private final boolean abortOnMajorFormattingLoss;

        WarningPolicy(boolean abortOnMajorFormattingLoss) {
            this.abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
        }

        int getAction(int warningType) {
            if (warningType == WarningType.SourceFileCorruption || warningType == WarningType.DataLoss) {
                return ReturnAction.Abort;
            }

            if (warningType == WarningType.MajorFormattingLoss && abortOnMajorFormattingLoss) {
                return ReturnAction.Abort;
            }

            return ReturnAction.Continue;
        }
    }

    private static final class ReportingWarningCallback implements IWarningCallback {
        private final OperationStage stage;
        private final WarningReport report;
        private final WarningPolicy policy;

        ReportingWarningCallback(OperationStage stage, WarningReport report, WarningPolicy policy) {
            this.stage = stage;
            this.report = report;
            this.policy = policy;
        }

        @Override
        public int warning(IWarningInfo warning) {
            report.add(stage, warning);
            return policy.getAction(warning.getWarningType());
        }
    }
}
```

`WarningPolicy` を構築する際に `abortOnMajorFormattingLoss` に `false` を渡すと、重要な書式差異が許容可能な場合に継続できます。互換性問題、軽微な書式損失、予期しないコンテンツは、操作が継続してもレポートに保持されます。これらのカテゴリのいずれかを拒否する必要がある場合は `WarningPolicy.getAction` を拡張してください。

## **一般的な警告シナリオ**

警告はワークフローのさまざまな段階で発生します。

- **デジタル署名:** 署名されたプレゼンテーションは、読み込み時に処理中に署名が失われる旨の警告を出すことがあります。Aspose.Slides はこの `DataLoss` 状態を [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentationsignedwarninginfo/) を通じて報告します。ロード段階のコールバックでファイルを拒否するか、報告された損失を明示的に受け入れるかを決定できます。
- **フォント置換:** 利用できないフォントはスライドのレンダリングまたはエクスポート時に置換されます。フォント置換の警告は `DataLoss` として報告されるため、上記の厳格ポリシーではアプリケーションが視覚的に許容できても中止します。動作を確認するには、実行環境に存在しないフォントでテキストが書かれたプレゼンテーションを使用してください。警告の説明に置換情報が含まれますので、必要なフォントを導入するか、[フォント置換ルール](/slides/ja/java/font-substitution/) を設定してから再試行してください。
- **サポートされていないまたは予期しないコンテンツ:** ローダーが認識できないレコードや機能に遭遇することがあります。この種の警告は `UnexpectedContent`、あるいはデータや書式に影響がある場合はより重大なカテゴリになることがあります。
- **形式の互換性:** 別のプレゼンテーション形式へ保存すると、機能が省略されたり、一部のアプリケーションで動作が異なる結果になることがあります。たとえば、8 本以上の水平または垂直ガイドを含むプレゼンテーションをレガシー PPT に保存すると `CompatibilityIssue` が報告されます。保存段階のコールバックで損失を記録して続行するか、すべてのガイドを保持する必要がある場合は拒否できます。
- **読み込み動作:** 読み込みオプションやレガシー動作でも警告が発生することがあります。たとえば、[IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) は、非推奨のプレゼンテーションロック動作の使用を `CompatibilityIssue` として特定します。

警告はソース文書、ターゲット形式、操作、Aspose.Slides のバージョンに依存します。すべてのファイルが警告を出すとは限らず、シナリオが必ずしも 1 つのカテゴリにだけマップされるわけでもありません。

## **中止された操作の安全な取り扱い**

コールバックが `ReturnAction.Abort` を返した場合、読み込みに失敗したオブジェクトを使用せず、レンダリングや保存出力が完了したと仮定しないでください。操作は出力ファイルを作成した後、完了前に終了することがあります。

検証済みの結果は `validated-output.pptx` のような別パスに保存してください。操作が正常に完了し、警告レポートがポリシーに合致し、出力が開いて確認できたことを確認してから、既存のプレゼンテーションと置き換えます。これにより、部分的または拒否された結果で有効なソースファイルを上書きするリスクを回避できます。

空の警告レポートは、すべてのソース機能が保持されたことを保証するものではありません。アプリケーション固有の追加コンテンツやビジュアルチェックを実施してください。合わせて [Open Presentations](/slides/ja/java/open-presentation/) と [Save Presentations](/slides/ja/java/save-presentation/) も参照してください。

## **FAQ**

**警告コールバックで Aspose.Slides のすべてのエラーを処理できますか？**

いいえ。回復可能な条件で警告として報告されるものだけが対象です。コールバックとは無関係に発生する例外は、読み込み、レンダリング、変換、保存呼び出しの周囲でアプリケーション側で処理する必要があります。

**`ReturnAction.Continue` を返すと出力が同一になることが保証されますか？**

いいえ。処理を続行できるだけで、報告された条件によりデータ、書式、互換性の違いが生じる可能性があります。収集した警告タイプと説明を確認してください。

**アプリケーションは警告を生成した操作をどのように識別できますか？**

各操作ごとにコールバックインスタンスを作成し、[getWarningType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iwarninginfo/#getWarningType--) と [getDescription](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iwarninginfo/#getDescription--) が返す値と共に、アプリケーション定義の段階情報を保持してください。例に示すように実装できます。