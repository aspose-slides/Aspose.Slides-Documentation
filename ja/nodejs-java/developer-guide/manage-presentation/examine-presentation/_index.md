---
title: JavaScript でプレゼンテーション情報を取得および更新する
linktitle: プレゼンテーション情報
type: docs
weight: 30
url: /ja/nodejs-java/examine-presentation/
keywords:
- プレゼンテーション形式
- プレゼンテーションプロパティ
- ドキュメントプロパティ
- プロパティ取得
- プロパティ読み取り
- プロパティ変更
- プロパティ修正
- プロパティ更新
- PPTX の検査
- PPT の検査
- ODP の検査
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript を使用して PowerPoint および OpenDocument のプレゼンテーション内のスライド、構造、メタデータを調査し、迅速な洞察とスマートなコンテンツ監査を実現します。"
---
## **概要**

Aspose.Slides は、プレゼンテーションの形式を識別し、完全なプレゼンテーション オブジェクト モデルを作成せずにドキュメント メタデータを読み取ることができます。これは、ファイルを分類したり、インベントリを作成したり、プレゼンテーションの内容を読み込んで処理するかどうかを決定する前にプロパティを検査したりする場合に便利です。

この記事では、[PresentationFactory](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentationfactory/) と [PresentationInfo](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentationinfo/) を使用した軽量検査、および [DocumentProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/documentproperties/) を使用したターゲット更新を示します。

## **プレゼンテーションの形式を確認する**

既にプレゼンテーションをロードしている場合は、ロード後の検出とレガシー PPT、PPS、POT ストリームの制限については、[Determine the Original Presentation Format](/slides/ja/nodejs-java/detect-presentation-source-format/) を参照してください。

[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) を使用して、[Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) インスタンスを作成せずにファイルを検査できます。[PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentationinfo/getloadformat/) メソッドは、PPTX、PPT、ODP など、検出された形式を報告します。

```javascript
const aspose = require("aspose.slides.via.java");

const fileNames = ["pres.pptx", "pres.ppt", "pres.odp"];

for (const fileName of fileNames) {
    const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(fileName);
    const loadFormat = presentationInfo.getLoadFormat();
    let formatName = `Other (${loadFormat})`;

    if (loadFormat === aspose.LoadFormat.Pptx) {
        formatName = "PPTX";
    } else if (loadFormat === aspose.LoadFormat.Ppt) {
        formatName = "PPT";
    } else if (loadFormat === aspose.LoadFormat.Odp) {
        formatName = "ODP";
    }

    console.log(`${fileName}: ${formatName}`);
}
```

## **軽量なプレゼンテーションインベントリの構築**

多数のプレゼンテーション ファイルを処理する場合、検証、インデックス作成、または文書管理システムのためのコンパクトなインベントリが必要になることがあります。このシナリオでは、[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) を使用して [PresentationInfo](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentationinfo/) オブジェクトを取得し、次に [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) を呼び出してドキュメント メタデータを読み取ります。このアプローチでは、[Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) インスタンスを作成せず、完全なプレゼンテーション オブジェクト モデルを走査する必要もありません。

[DocumentProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/documentproperties/) が公開する拡張プロパティは、次のインベントリ値を提供します。

| メソッド | インベントリ値 |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/documentproperties/#getSlides) | 総スライド数。 |
| [getHiddenSlides](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) | 非表示スライド数。 |
| [getNotes](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/documentproperties/#getNotes) | ノートが含まれるスライド数。 |
| [getParagraphs](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/documentproperties/#getParagraphs) | 利用可能な場合の段落総数。 |
| [getWords](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/documentproperties/#getWords) | 総単語数。 |
| [getMultimediaClips](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/documentproperties/#getMultimediaClips) | オーディオおよびビデオ クリップの総数。 |

次の例は、[Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) オブジェクトを作成せずにこれらの値を読み取り、コンパクトなインベントリを出力します。また、[DocumentProperties.getHeadingPairs](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/documentproperties/#getHeadingPairs) と [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) を組み合わせて、フォント、テーマ、スライドタイトルなどのコンテンツ グループを表示します。

```javascript
const path = require("path");
const aspose = require("aspose.slides.via.java");

const filePath = "sample.pptx";
const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(filePath);
const documentProperties = presentationInfo.readDocumentProperties();

const loadFormat = presentationInfo.getLoadFormat();
let formatName = `Other (${loadFormat})`;

if (loadFormat === aspose.LoadFormat.Pptx) {
    formatName = "PPTX";
} else if (loadFormat === aspose.LoadFormat.Ppt) {
    formatName = "PPT";
} else if (loadFormat === aspose.LoadFormat.Odp) {
    formatName = "ODP";
}

console.log(`File: ${path.basename(filePath)}`);
console.log(`Format: ${formatName}`);
console.log(`Title: ${documentProperties.getTitle()}`);
console.log(`Author: ${documentProperties.getAuthor()}`);
console.log("Statistics:");
console.log(`  Slides: ${documentProperties.getSlides()}`);
console.log(`  Hidden slides: ${documentProperties.getHiddenSlides()}`);
console.log(`  Slides with notes: ${documentProperties.getNotes()}`);
console.log(`  Paragraphs: ${documentProperties.getParagraphs()}`);
console.log(`  Words: ${documentProperties.getWords()}`);
console.log(`  Multimedia clips: ${documentProperties.getMultimediaClips()}`);

const headingPairs = documentProperties.getHeadingPairs() || [];
const titlesOfParts = documentProperties.getTitlesOfParts() || [];
let partIndex = 0;

if (headingPairs.length === 0 || titlesOfParts.length === 0) {
    console.log("Content groups: not available");
} else {
    console.log("Content groups:");

    for (const headingPair of headingPairs) {
        const partCount = headingPair.getCount();
        console.log(`  ${headingPair.getName()} (${partCount})`);

        for (let partOffset = 0; partOffset < partCount && partIndex < titlesOfParts.length; partOffset++) {
            console.log(`    - ${titlesOfParts[partIndex]}`);
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.length) {
        console.log("  Other parts:");

        while (partIndex < titlesOfParts.length) {
            console.log(`    - ${titlesOfParts[partIndex]}`);
            partIndex++;
        }
    }
}
```

各 [HeadingPair](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/headingpair/) は、[HeadingPair.getName](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/headingpair/#getName) によってグループ名を、[HeadingPair.getCount](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/headingpair/#getCount) によってそのグループ内の項目数を提供します。[DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) はフラットで順序付けられた配列を返すため、各ヘディングペアで指定された連続したタイトル数だけを消費します。

### **保存されたメタデータと形式の制限**

[PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) が返すインベントリ プロパティは、ソース ドキュメントに存在するメタデータを反映します。Aspose.Slides はこの呼び出しのためにプレゼンテーション オブジェクト モデルをロードまたは走査せず、これらの値を再計算しません。欠落しているプロパティはデフォルト値で表され、最後にファイルを保存したアプリケーションがドキュメント プロパティを更新していない場合、保存された値は古くなっている可能性があります。

- **PPTX:** スライド、ノート、非表示スライド、段落、単語、マルチメディアのカウントやヘディングペア、パートタイトルなど、拡張ドキュメント プロパティが提供されます。利用可能性は、ドキュメント作成者が書き込んだプロパティに依存します。
- **PPT:** バイナリ形式は対応するドキュメント要約プロパティを格納できます。プロパティが存在しない、または作成者によって更新されていない場合、Aspose.Slides はスライドから計算するのではなく、保存された値またはデフォルト値を返します。
- **ODP:** OpenDocument メタデータはページ、段落、単語の総数などの一般的な統計情報を提供しますが、これらの値は PowerPoint 固有の拡張プロパティと必ずしも一致しません。非表示スライド、ノートスライド、マルチメディア、ヘディングペア、パートタイトルのメタデータは利用できない場合があり、インベントリ プロパティはデフォルト値を返すことがあります。ゼロ値や空配列を、対応するコンテンツが存在しない決定的な証拠として扱わないでください。

軽量メタデータ手法はインベントリや事前チェックに適しています。結果がメモリ内の変更を反映する必要がある場合や、実際のプレゼンテーション コンテンツを検証する必要がある場合は、プレゼンテーションをロードしてライブ オブジェクト モデルを検査してください。

## **プレゼンテーションプロパティの更新**

[PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) が返すプロパティは、[Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) インスタンスを作成せずに変更できます。[PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentationinfo/updatedocumentproperties/) で変更を適用し、[PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentationinfo/writebindedpresentation/) でバインドされたプレゼンテーションを書き込みます。

以下の画像は元のドキュメント プロパティを示しています。

![Original document properties of the PowerPoint presentation](input_properties.png)

次の例はタイトルと最終保存時刻を変更し、結果を新しいファイルに書き出します。

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");

const sourceFile = "sample.pptx";
const outputFile = "sample_with_updated_properties.pptx";
const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(sourceFile);
const documentProperties = presentationInfo.readDocumentProperties();

documentProperties.setTitle("Quarterly sales report");
documentProperties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

presentationInfo.updateDocumentProperties(documentProperties);
const outputStream = java.newInstanceSync("java.io.FileOutputStream", outputFile);
try {
    presentationInfo.writeBindedPresentation(outputStream);
} finally {
    outputStream.close();
}
```

以下の画像は更新されたドキュメント プロパティを示しています。

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **便利なリンク**

関連するセキュリティ チェックや保護設定については、次の記事をご参照ください。

- [Password-Protect Presentations](/slides/ja/nodejs-java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/ja/nodejs-java/write-protected-presentation/)

## **よくある質問**

**フォントが埋め込まれているか、どのフォントが埋め込まれているかを確認する方法は？**

プレゼンテーションをロードし、[Presentation.getFontsManager](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/getfontsmanager/) を使用します。[FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) で埋め込みフォントを取得し、[FontsManager.getFonts](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fontsmanager/getfonts/) でプレゼンテーションで使用されているフォントを取得します。両者を比較して、レンダリングに必要だが埋め込まれていないフォントを特定します。

**ファイルに非表示スライドがあるかどうか、またその数をすばやく確認する方法は？**

保存されたドキュメント メタデータが十分であれば、[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) と [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) を通じて [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) を読み取ります。これは軽量インベントリに適しています。メモリ上でプレゼンテーションが変更されている場合、保存メタデータが欠落または古い可能性があるため、[Presentation.getSlides](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/getslides/) を走査し、各スライドの [Slide.getHidden](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slide/gethidden/) メソッドで確認してください。

**カスタム スライド サイズや向きが使用されているか、デフォルトと異なるかを検出できますか？**

はい。プレゼンテーションをロードし、[Presentation.getSlideSize](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/getslidesize/) を呼び出します。[SlideSize.getType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slidesize/gettype/)、[SlideSize.getSize](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slidesize/getsize/)、[SlideSize.getOrientation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slidesize/getorientation/) を使用して現在の設定を期待されるプリセットや寸法と比較してください。

**チャートが外部データ ソースを参照しているかどうかをすばやく確認する方法は？**

各 [Chart](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chart/) を見つけ、[ChartData.getDataSourceType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) を呼び出します。外部ブックである場合は、[ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) を呼び出します。データ ソースのタイプとパスが外部参照を示しますが、対象が利用可能かどうかは別途リソース チェックが必要です。

**レンダリングや PDF エクスポートを遅くする可能性のある「重い」スライドを評価する方法は？**

単一の複雑度プロパティは存在しません。[Presentation.getSlides](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/getslides/) と各スライドの [BaseSlide.getShapes](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseslide/#getShapes) コレクションを走査します。シェイプ数や大きな画像、エフェクト、アニメーション、マルチメディアの有無をスクリーニング指標として使用し、代表的なレンダリングやエクスポートを測定して、スライドが実際にパフォーマンス ボトルネックであるかを判断してください。