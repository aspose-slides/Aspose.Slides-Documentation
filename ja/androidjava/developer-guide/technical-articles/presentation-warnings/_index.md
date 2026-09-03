---
title: "Android でのプレゼンテーション警告の処理"
type: docs
weight: 90
url: /ja/androidjava/presentation-warnings/
aliases:
- /androidjava/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して、プレゼンテーションの読み込み、レンダリング、変換、保存時に警告を収集、分類、対応する方法を学びます。"
---
## **概要**

Aspose.Slides は、プレゼンテーションの読み込み、レンダリング、変換、または保存中に回復可能な問題を報告できます。例として、破損したソースレコード、保存できないコンテンツ、フォント置換、ターゲット形式の制限などがあります。警告コールバックにより、アプリケーションはこれらの状態を記録し、現在の操作を継続できるかどうかを判断できます。

[IWarningCallback](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iwarningcallback/) インターフェイスを実装し、[IWarningInfo](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iwarninginfo/) を通じて提供される [getWarningType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iwarninginfo/#getWarningType--) と [getDescription](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iwarninginfo/#getDescription--) の値を調べます。警告を受け入れる場合は [ReturnAction.Continue](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/returnaction/#Continue) を返し、操作を停止する場合は [ReturnAction.Abort](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/returnaction/#Abort) を返します。

プレゼンテーションのオープン時に発生する警告には [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/loadoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) を使用します。レンダリングおよびエクスポートオプション クラスは [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) を継承し、スライドのレンダリング、変換、保存時の警告を受け取ります。警告自体はアプリケーション操作を特定しないため、結合レポートを作成する際にはコールバック インスタンスを操作ステージに関連付けてください。

## **警告と例外**

警告は、コールバックが `ReturnAction.Continue` を返す限り Aspose.Slides が回復できる状態を示します。例外は要求された操作が正常に完了できないことを意味し、例外は警告に変換されず、警告ポリシーで処理できません。

`ReturnAction.Abort` を返すと、警告ディスパッチャは例外をスローして現在の操作を終了させます。公開される例外は操作とプレゼンテーション形式に依存します。たとえば、読み込み時には [PptxReadException](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pptxreadexception/) または [PptReadException](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pptreadexception/) が発生し、保存またはエクスポート時には [PptxException](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pptxexception/) が発生する可能性があります。操作の境界で例外を処理し、警告レポートを使用してアプリケーション ポリシーが終了の原因かどうかを判断してください。コールバックは `ReturnAction.Abort` を返す前に警告を記録するため、理由はアプリケーション側で利用可能です。

## **警告カテゴリ**

[WarningType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/warningtype/) クラスは以下のカテゴリに対応する整数定数を提供します。

| 警告タイプ | 意味 | 典型的なポリシー |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/warningtype/#SourceFileCorruption) | ソース プレゼンテーションに破損が含まれており、元の形式で保存されたドキュメントが使用できなくなる可能性があります。 | 中止。 |
| [DataLoss](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/warningtype/#DataLoss) | テキスト、チャート、画像、またはその他のデータが、ロードまたは保存後に欠落している可能性があります。 | 中止。 |
| [MajorFormattingLoss](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/warningtype/#MajorFormattingLoss) | プレゼンテーションの重要な書式が失われる可能性があります。 | 厳格な検証モードでは中止、そうでなければ記録して継続。 |
| [MinorFormattingLoss](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/warningtype/#MinorFormattingLoss) | 限定的な書式の違いが発生する可能性があります。 | 診断のために記録し、継続。 |
| [CompatibilityIssue](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/warningtype/#CompatibilityIssue) | 結果が一部のアプリケーションや古いバージョンで正しく開かない、または正しく動作しない可能性があります。 | 互換性が必須でない限り、ログに記録して継続。 |
| [UnexpectedContent](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/warningtype/#UnexpectedContent) | ソースにサポートされていない、または認識できないコンテンツが含まれており、その影響はまだ不明である可能性があります。 | 記録して継続、または厳格なポリシーではエラーとして扱う。 |

カテゴリはポリシー決定の指針となります。[getDescription](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iwarninginfo/#getDescription--) が返す値は診断用に保存してください。ただし、メッセージ テキストは警告シナリオや製品バージョンによって変わるため、アプリケーション ロジックでその文言に依存しないでください。

## **警告の収集と分類**

以下の例は、全処理パイプラインに対して 1 つのアプリケーション レベルのレポートを使用しています。別々のコールバック インスタンスが読み込み、レンダリング、PDF 変換、PPTX 保存からの警告にラベル付けします。ポリシーはソース破損またはデータ損失で中止し、必要に応じて主要な書式損失でも中止し、その他の警告は継続します。

`input.pptx` を書き込み可能なアプリケーション ディレクトリに配置し、そのディレクトリを `PresentationWarningExample.run` に渡してください。例は同じディレクトリに出力を保存します。Android のユーザー インターフェイスを応答性のある状態に保つため、バックグラウンド スレッドでプレゼンテーション処理を実行してください。

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
import java.io.File;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class PresentationWarningExample {
    public static void run(File dataDirectory) {
        WarningReport report = new WarningReport();
        WarningPolicy policy = new WarningPolicy(true);
        File inputFile = new File(dataDirectory, "input.pptx");
        boolean completed = processPresentation(inputFile.getAbsolutePath(), dataDirectory, report, policy);

        System.out.println(completed ? "Processing completed." : "Processing stopped.");

        for (WarningEntry entry : report.getEntries()) {
            String typeName = warningTypeName(entry.type);
            System.out.println("[" + entry.stage + "] " + typeName + ": " + entry.description);
        }
    }

    private static boolean processPresentation(String inputPath, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            LoadOptions loadOptions = new LoadOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Loading, report, policy);
            loadOptions.setWarningCallback(callback);

            Presentation presentation = new Presentation(inputPath, loadOptions);
            try {
                if (!renderFirstSlide(presentation, dataDirectory, report, policy)) {
                    return false;
                }

                if (!convertToPdf(presentation, dataDirectory, report, policy)) {
                    return false;
                }

                return saveValidatedCopy(presentation, dataDirectory, report, policy);
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

    private static boolean renderFirstSlide(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
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
                File outputFile = new File(dataDirectory, "slide-1.png");
                image.save(outputFile.getAbsolutePath(), ImageFormat.Png);
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

    private static boolean convertToPdf(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            PdfOptions options = new PdfOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Conversion, report, policy);
            options.setWarningCallback(callback);

            File outputFile = new File(dataDirectory, "converted.pdf");
            presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pdf, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Conversion stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean saveValidatedCopy(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            PptxOptions options = new PptxOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Saving, report, policy);
            options.setWarningCallback(callback);

            File outputFile = new File(dataDirectory, "validated-output.pptx");
            presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx, options);
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

`WarningPolicy` を構築する際に主要な書式差異が許容できる場合は `abortOnMajorFormattingLoss` に `false` を渡します。互換性問題、軽微な書式損失、予期しないコンテンツは、操作が継続した場合でもレポートに残ります。アプリケーションがこれらのカテゴリのいずれかを拒否する必要がある場合は `WarningPolicy.getAction` を拡張してください。

## **一般的な警告シナリオ**

警告はワークフローのさまざまな段階で発生する可能性があります。

- **Digital signatures:** 署名されたプレゼンテーションは、読み込み時に処理中に署名が失われるという警告を出すことがあります。Aspose.Slides はこの `DataLoss` 状態を [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentationsignedwarninginfo/) を通じて報告します。ロード段階のコールバックにより、アプリケーションはファイルを拒否するか、報告された損失を明示的に受け入れることができます。
- **Font substitution:** 利用できないフォントがスライドのレンダリングまたはエクスポート時に置換されることがあります。フォント置換警告は `DataLoss` として報告されるため、上記の厳格なポリシーはアプリケーションが視覚的に許容できる置換であっても中止します。この動作を確認するには、実行時に利用できないフォントでテキストが含まれるプレゼンテーションを入力として使用してください。警告の説明に置換が示されますので、必要なフォントを用意するか [フォント置換ルール](/slides/ja/androidjava/font-substitution/) を設定してから再試行してください。
- **Unsupported or unexpected content:** ローダーが認識できないプレゼンテーション レコードや機能に遭遇することがあります。これらの警告は `UnexpectedContent`、またはデータや書式への影響が明らかな場合はより重大なカテゴリになることがあります。
- **Format compatibility:** 別のプレゼンテーション形式へ保存すると、機能が省略されたり、一部のアプリケーションで動作が異なる結果になることがあります。たとえば、8 本以上の水平ガイドまたは垂直ガイドが含まれるプレゼンテーションをレガシー PPT に保存すると `CompatibilityIssue` が報告されます。保存段階のコールバックは損失を記録して継続するか、すべてのガイドを保持する必要がある場合は拒否できます。
- **Loading behavior:** 読み込みオプションやレガシー動作も警告を生成します。たとえば、[IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) は、過去のプレゼンテーション ロック動作の使用を `CompatibilityIssue` として識別します。

警告はソース ドキュメント、ターゲット形式、操作、Aspose.Slides のバージョンに依存します。すべてのファイルが警告を生成する、またはシナリオが必ずしも 1 つのカテゴリにマッピングされると想定しないでください。

## **中止された操作の安全な処理**

コールバックが `ReturnAction.Abort` を返した場合、読み込みに失敗したオブジェクトを使用しないでください。また、レンダリングや保存の出力が完了したと仮定しないでください。操作は出力ファイルを作成した後、完了する前に終了することがあります。

`validated-output.pptx` のような別のパスに検証済みの結果を保存してください。操作が正常に完了し、警告レポートがアプリケーション ポリシーを満たし、出力が開いて確認できたときにのみ既存のプレゼンテーションを置き換えます。これにより、部分的または拒否された結果で有効なソース ファイルを上書きすることを防げます。

空の警告レポートは、すべてのソース 機能が保持されたことの保証ではありません。アプリケーションが要求する追加のコンテンツおよび視覚的チェックを実施してください。さらに詳しくは [Open Presentations](/slides/ja/androidjava/open-presentation/) と [Save Presentations](/slides/ja/androidjava/save-presentation/) を参照してください。

## **よくある質問**

**Can a warning callback handle every Aspose.Slides error?**  
いいえ。コールバックは警告として報告される回復可能な状態のみを処理します。コールバックとは無関係に発生する例外は、ロード、レンダリング、変換、保存呼び出しを囲むアプリケーション側で処理する必要があります。

**Does returning `ReturnAction.Continue` guarantee identical output?**  
いいえ。処理が継続できることを許可するだけです。報告された状態によりデータ、書式、互換性に差異が生じる可能性があるため、収集した警告タイプと説明を確認してください。

**How can an application identify the operation that produced a warning?**  
各操作ごとにコールバック インスタンスを作成し、[getWarningType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iwarninginfo/#getWarningType--) と [getDescription](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iwarninginfo/#getDescription--) が返す値とともにアプリケーション定義のステージ情報を保持します（例を参照）。