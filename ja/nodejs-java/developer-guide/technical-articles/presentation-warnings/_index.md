---
title: Node.js でプレゼンテーションの警告を処理する
type: docs
weight: 90
url: /ja/nodejs-java/presentation-warnings/
aliases:
- /nodejs-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
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
- JavaScript
- Node.js
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java を使用して、プレゼンテーションの読み込み、レンダリング、変換、保存時に警告を収集・分類・対処する方法を学びます。"
---
## **概要**

Aspose.Slides は、プレゼンテーションの読み込み、レンダリング、変換、または保存中に回復可能な問題を報告できます。例としては、破損したソースレコード、保持できないコンテンツ、フォント置換、ターゲット形式の制限などがあります。警告コールバックを使用すると、アプリケーションはこれらの状態を記録し、現在の操作を継続できるかどうかを判断できます。

`java.newProxy` を使用して JavaScript で [IWarningCallback](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iwarningcallback/) Java インターフェイスを実装し、[IWarningInfo](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iwarninginfo/) を通じて提供される [getWarningType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iwarninginfo/#getWarningType--) と [getDescription](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iwarninginfo/#getDescription--) の値を確認します。警告を受け入れる場合は [ReturnAction.Continue](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/returnaction/#Continue) を返し、操作を停止する場合は [ReturnAction.Abort](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/returnaction/#Abort) を返します。

プレゼンテーションを開く際に発生する警告は [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/loadoptions/#setWarningCallback) を使用します。レンダリングとエクスポートのオプション クラスは [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/saveoptions/#setWarningCallback) を継承しており、スライドのレンダリング、変換、保存時の警告を受け取ります。警告自体はアプリケーションの操作を特定しないため、結合レポートを作成する際は各コールバック インスタンスを操作ステージに関連付けてください。

## **警告と例外**

警告は、コールバックが `ReturnAction.Continue` を返す限り Aspose.Slides が回復できる状態を示します。例外は要求された操作を通常通り完了できないことを意味し、例外は警告に変換されず、警告ポリシーで処理できません。

`ReturnAction.Abort` を返すと、警告ディスパッチャは例外を発生させて現在の操作を終了します。公開される例外は操作およびプレゼンテーション形式によって異なります。たとえば、読み込み時には [PptxReadException](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pptxreadexception/) または [PptReadException](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pptreadexception/) がスローされ、保存やエクスポート時には [PptxException](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pptxexception/) がスローされることがあります。操作の境界で Java ブリッジからのエラーをキャッチし、警告レポートを使用してアプリケーション ポリシーが終了の原因かどうかを判断してください。コールバックは `ReturnAction.Abort` を返す前に警告を記録し、理由がアプリケーションに残るようにします。

## **警告カテゴリ**

[WarningType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/warningtype/) クラスは、次のカテゴリに対応する整数定数を提供します。

| 警告タイプ | 意味 | 典型的なポリシー |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/warningtype/#SourceFileCorruption) | ソース プレゼンテーションに破損が含まれており、元の形式で保存すると使用できなくなる可能性があります。 | 中止 |
| [DataLoss](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/warningtype/#DataLoss) | 読み込みまたは保存後にテキスト、チャート、画像、その他のデータが欠落している可能性があります。 | 中止 |
| [MajorFormattingLoss](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/warningtype/#MajorFormattingLoss) | プレゼンテーションが重要な書式設定を失う可能性があります。 | 厳密な検証モードでは中止、その他は記録して継続 |
| [MinorFormattingLoss](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/warningtype/#MinorFormattingLoss) | 限定的な書式差異が発生する可能性があります。 | 診断用に記録して継続 |
| [CompatibilityIssue](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/warningtype/#CompatibilityIssue) | 結果が一部のアプリケーションや古いバージョンで正しく開かない、または動作しない可能性があります。 | 互換性が必須でない限りログに記録して継続 |
| [UnexpectedContent](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/warningtype/#UnexpectedContent) | ソースに未対応または認識できないコンテンツが含まれ、その影響が不明な場合があります。 | 記録して継続、または厳密ポリシーではエラーとして扱う |

カテゴリはポリシー決定の指針となります。診断目的で [getDescription](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iwarninginfo/#getDescription--) が返す値を保存しても構いませんが、メッセージ文言は警告シナリオや製品バージョンによって変わるため、アプリケーション ロジックの根拠にしないでください。

## **警告の収集と分類**

以下の JavaScript サンプルは、全処理パイプライン用のアプリケーション レベルのレポートを使用します。別々のコールバック インスタンスが、読み込み、レンダリング、PDF 変換、PPTX 保存からの警告にラベルを付けます。ポリシーはソース破損またはデータ損失で中止し、必要に応じて大幅な書式損失でも中止し、他の警告は継続します。

```javascript
const java = require("java");
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

class WarningPolicy {
    constructor(abortOnMajorFormattingLoss) {
        this.abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
    }

    getAction(warningType) {
        if (warningType === aspose.slides.WarningType.SourceFileCorruption || warningType === aspose.slides.WarningType.DataLoss) {
            return aspose.slides.ReturnAction.Abort;
        }

        if (warningType === aspose.slides.WarningType.MajorFormattingLoss && this.abortOnMajorFormattingLoss) {
            return aspose.slides.ReturnAction.Abort;
        }

        return aspose.slides.ReturnAction.Continue;
    }
}

function createReportingWarningCallback(stage, report, policy) {
    return java.newProxy("com.aspose.slides.IWarningCallback", {
        warning: function (warning) {
            const type = warning.getWarningType();
            const description = warning.getDescription();
            report.push({ stage, type, description });
            return policy.getAction(type);
        }
    });
}

function processPresentation(inputPath, report, policy) {
    try {
        const loadOptions = new aspose.slides.LoadOptions();
        const callback = createReportingWarningCallback("Loading", report, policy);
        loadOptions.setWarningCallback(callback);

        const presentation = new aspose.slides.Presentation(inputPath, loadOptions);
        try {
            if (!renderFirstSlide(presentation, report, policy)) {
                return false;
            }

            if (!convertToPdf(presentation, report, policy)) {
                return false;
            }

            return saveValidatedCopy(presentation, report, policy);
        } finally {
            presentation.dispose();
        }
    } catch (error) {
        console.error("Loading stopped: " + error.message);
        return false;
    }
}

function renderFirstSlide(presentation, report, policy) {
    if (presentation.getSlides().size() === 0) {
        console.error("Rendering stopped: the presentation has no slides.");
        return false;
    }

    try {
        const options = new aspose.slides.RenderingOptions();
        const callback = createReportingWarningCallback("Rendering", report, policy);
        options.setWarningCallback(callback);

        const image = presentation.getSlides().get_Item(0).getImage(options);
        try {
            image.save("slide-1.png", aspose.slides.ImageFormat.Png);
            return true;
        } finally {
            image.dispose();
        }
    } catch (error) {
        console.error("Rendering stopped: " + error.message);
        return false;
    }
}

function convertToPdf(presentation, report, policy) {
    try {
        const options = new aspose.slides.PdfOptions();
        const callback = createReportingWarningCallback("Conversion", report, policy);
        options.setWarningCallback(callback);

        presentation.save("converted.pdf", aspose.slides.SaveFormat.Pdf, options);
        return true;
    } catch (error) {
        console.error("Conversion stopped: " + error.message);
        return false;
    }
}

function saveValidatedCopy(presentation, report, policy) {
    try {
        const options = new aspose.slides.PptxOptions();
        const callback = createReportingWarningCallback("Saving", report, policy);
        options.setWarningCallback(callback);

        presentation.save("validated-output.pptx", aspose.slides.SaveFormat.Pptx, options);
        return true;
    } catch (error) {
        console.error("Saving stopped: " + error.message);
        return false;
    }
}

function warningTypeName(warningType) {
    switch (warningType) {
        case aspose.slides.WarningType.SourceFileCorruption:
            return "SourceFileCorruption";
        case aspose.slides.WarningType.DataLoss:
            return "DataLoss";
        case aspose.slides.WarningType.MajorFormattingLoss:
            return "MajorFormattingLoss";
        case aspose.slides.WarningType.MinorFormattingLoss:
            return "MinorFormattingLoss";
        case aspose.slides.WarningType.CompatibilityIssue:
            return "CompatibilityIssue";
        case aspose.slides.WarningType.UnexpectedContent:
            return "UnexpectedContent";
        default:
            return "Unknown (" + warningType + ")";
    }
}

const report = [];
const policy = new WarningPolicy(true);
const completed = processPresentation("input.pptx", report, policy);

console.log(completed ? "Processing completed." : "Processing stopped.");

for (const entry of report) {
    const typeName = warningTypeName(entry.type);
    console.log("[" + entry.stage + "] " + typeName + ": " + entry.description);
}
```

`WarningPolicy` を構築する際に `abortOnMajorFormattingLoss` に `false` を指定すると、大幅な書式差異を許容できます。互換性問題、軽微な書式損失、予期しないコンテンツは、操作が継続されてもレポートに保持されます。これらのカテゴリのいずれかをアプリケーション側で拒否する必要がある場合は、`WarningPolicy.getAction` を拡張してください。

## **一般的な警告シナリオ**

警告はワークフローのさまざまな段階で発生する可能性があります。

- **デジタル署名:** 署名されたプレゼンテーションは、読み込み時に処理中に署名が失われる旨の警告を出すことがあります。Aspose.Slides はこの `DataLoss` 状態を [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentationsignedwarninginfo/) を通じて報告します。ロード段階のコールバックでファイルを拒否するか、報告された損失を明示的に受け入れるか選択できます。
- **フォント置換:** 利用できないフォントは、スライドのレンダリングまたはエクスポート時に置換されます。フォント置換の警告は `DataLoss` として報告されるため、上記の厳密ポリシーではアプリケーションが視覚的に許容できても中止されます。この動作を確認するには、実行環境に存在しないフォントでテキストが書かれた入力プレゼンテーションを使用してください。警告の説明で置換フォントが特定できるので、必要なフォントを配置するか [フォント置換ルール](/slides/ja/nodejs-java/font-substitution/) を設定してから再試行してください。
- **未サポートまたは予期しないコンテンツ:** ローダーが認識できないプレゼンテーション レコードや機能に遭遇することがあります。このような警告は `UnexpectedContent`、あるいはデータや書式に影響がある場合はより重大なカテゴリになることがあります。
- **形式互換性:** 別のプレゼンテーション形式へ保存すると、機能が省かれたり、いくつかのアプリケーションで動作が異なったりすることがあります。たとえば、8 本を超える水平または垂直の描画ガイドを含むプレゼンテーションをレガシー PPT に保存すると `CompatibilityIssue` が報告されます。保存段階のコールバックで損失を記録して継続するか、すべてのガイドを保持する必要がある場合は拒否できます。
- **読み込み動作:** 読み込みオプションやレガシー 動作でも警告が生成されます。例として、[IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) は、廃止されたプレゼンテーション ロック 動作の使用を `CompatibilityIssue` として識別します。

警告はソース文書、ターゲット形式、操作、Aspose.Slides のバージョンに依存します。すべてのファイルが警告を出すとは限らず、シナリオが常に単一のカテゴリにマッピングされるわけでもありません。

## **中止された操作の安全な処理**

コールバックが `ReturnAction.Abort` を返した場合、読み込みに失敗したオブジェクトを使用しないでください。また、レンダリングまたは保存結果が完了したと仮定しないでください。操作は出力ファイルを作成した後でも、完了する前に終了することがあります。

検証済みの結果は `validated-output.pptx` など別のパスに保存してください。操作が正常に完了し、警告レポートがポリシーに合致し、出力が開いてチェックできることを確認してから、既存のプレゼンテーションを置き換えます。これにより、部分的または拒否された結果で有効なソース ファイルが上書きされることを防げます。

空の警告レポートは、すべてのソース機能が保持されたことの保証ではありません。アプリケーションが要求する追加のコンテンツやビジュアルチェックを実施してください。合わせて [Open Presentations](/slides/ja/nodejs-java/open-presentation/) と [Save Presentations](/slides/ja/nodejs-java/save-presentation/) も参照してください。

## **FAQ**

**警告コールバックはすべての Aspose.Slides エラーを処理できますか？**

いいえ。コールバックは警告として報告される回復可能な状態のみを処理します。コールバックとは無関係に発生する例外は、読み込み、レンダリング、変換、保存呼び出しを囲むアプリケーション側でハンドリングする必要があります。

**`ReturnAction.Continue` を返すと出力が完全に同一になることが保証されますか？**

いいえ。処理を続行できるだけで、報告された状態によりデータ、書式、互換性の違いが生じる可能性があります。収集した警告タイプと説明を確認してください。

**アプリケーションは警告を生成した操作をどのように特定しますか？**

各操作ごとにコールバック インスタンスを作成し、[getWarningType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iwarninginfo/#getWarningType--) と [getDescription](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iwarninginfo/#getDescription--) が返す値とともに、アプリケーション定義のステージ情報を保持します。サンプルに示す方法をご参照ください。