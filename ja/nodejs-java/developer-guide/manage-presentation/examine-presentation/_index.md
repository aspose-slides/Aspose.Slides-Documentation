---
title: JavaScript でプレゼンテーション情報の取得と更新
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
description: "JavaScript を使用して PowerPoint および OpenDocument プレゼンテーションのスライド、構造、メタデータを調査し、より迅速な洞察と賢いコンテンツ監査を実現します。"
---
## **概要**

Aspose.Slides はプレゼンテーションの形式を識別し、完全なプレゼンテーションオブジェクトモデルを作成せずにドキュメント メタデータを読み取ることができます。これは、ファイルを分類したり、インベントリを作成したり、プレゼンテーションの内容を読み込んで処理するかどうかを判断する前にプロパティを検査したりする場合に便利です。

この記事では、[PresentationFactory](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentationfactory/) と [PresentationInfo](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentationinfo/) を使用した軽量な検査と、[DocumentProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/documentproperties/) を使用した対象を絞った更新について示します。

## **プレゼンテーション形式の確認**

[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) を使用して、[Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) インスタンスを作成せずにファイルを検査できます。[PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentationinfo/getloadformat/) メソッドは、PPTX、PPT、ODP など検出された形式を報告します。

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

## **軽量プレゼンテーション・インベントリの構築**

多数のプレゼンテーション ファイルを処理する場合、検証、インデックス作成、または文書管理システム向けのコンパクトなインベントリが必要になることがあります。このシナリオでは、[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) を使用して [PresentationInfo](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentationinfo/) オブジェクトを取得し、続いて [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) を呼び出してドキュメント メタデータを読み取ります。このアプローチでは、[Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) インスタンスを作成したり、完全なプレゼンテーション オブジェクトモデルを走査したりする必要はありません。

[DocumentProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/documentproperties/) が提供する拡張プロパティは、次のインベントリ値を返します。

| メソッド | インベントリ 値 |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/documentproperties/#getSlides) | スライドの総数。 |
| [getHiddenSlides](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) | 非表示スライドの数。 |
| [getNotes](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/documentproperties/#getNotes) | ノートが含まれるスライドの数。 |
| [getParagraphs](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/documentproperties/#getParagraphs) | 利用可能な場合の段落の総数。 |
| [getWords](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/documentproperties/#getWords) | 単語の総数。 |
| [getMultimediaClips](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/documentproperties/#getMultimediaClips) | オーディオおよびビデオ クリップの総数。 |

以下の例は、[Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) オブジェクトを作成せずにこれらの値を読み取り、コンパクトなインベントリを出力します。また、[DocumentProperties.getHeadingPairs](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/documentproperties/#getHeadingPairs) と [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) を組み合わせて、フォント、テーマ、スライド タイトルなどのコンテンツ グループを表示します。

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

各 [HeadingPair](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/headingpair/) は、[HeadingPair.getName](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/headingpair/#getName) によってグループ名を提供し、[HeadingPair.getCount](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/headingpair/#getCount) によってそのグループ内の項目数を提供します。[DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) はフラットで順序付けされた配列を返すため、各 HeadingPair で指定された連続タイトル数だけを消費します。

### **保存されたメタデータと形式の制限**

[PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) が返すインベントリ プロパティは、ソース ドキュメントで利用可能なメタデータを反映します。Aspose.Slides はこの呼び出しのためにプレゼンテーション オブジェクトモデルをロードして走査し、これらの値を再計算しません。欠落しているプロパティはデフォルト値で表され、最後にファイルを保存したアプリケーションがドキュメント プロパティを更新しなかった場合、保存された値は古くなる可能性があります。

- **PPTX:** この形式は、スライド、ノート、非表示スライド、段落、単語、マルチメディアのカウント、およびヘッディング ペアとパート タイトルの拡張ドキュメント プロパティを提供します。利用可能性は、ドキュメント作成者がどのプロパティを書き込んだかに依存します。
- **PPT:** バイナリ形式は対応するドキュメント要約プロパティを格納できます。プロパティが存在しない、または作成者によって更新されていない場合、Aspose.Slides はスライドから計算せずに保存された値またはデフォルト値を返します。
- **ODP:** OpenDocument メタデータはページ、段落、単語数などの一般的なドキュメント統計を提供しますが、これらの値はすべての PowerPoint 固有の拡張プロパティにマッピングされません。非表示スライド、ノートスライド、マルチメディア、ヘッディング ペア、パート タイトルのメタデータは利用できない場合があり、インベントリ プロパティはデフォルト値を返すことがあります。ゼロ値や空配列を、対応するコンテンツが存在しないという決定的な証拠として扱わないでください。

インベントリや事前チェックには軽量メタデータ アプローチを使用してください。結果がインメモリの変更を反映する必要がある場合や、実際のプレゼンテーション コンテンツを検証する必要がある場合は、プレゼンテーションをロードしてライブ オブジェクトモデルを検査してください。

## **プレゼンテーション プロパティの更新**

[PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) が返すプロパティは、[Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) インスタンスを作成せずに変更できます。変更は [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentationinfo/updatedocumentproperties/) で適用し、[PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentationinfo/writebindedpresentation/) でバインドされたプレゼンテーションを書き出します。

以下の画像は元のドキュメント プロパティを示しています。

![PowerPoint プレゼンテーションの元のドキュメント プロパティ](input_properties.png)

以下の例はタイトルと最終保存時刻を変更し、結果を新しいファイルに書き出します。

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

![PowerPoint プレゼンテーションの変更後ドキュメント プロパティ](output_properties.png)

## **便利なリンク**

関連するセキュリティチェックや保護設定については、次の記事をご覧ください。

- [プレゼンテーションのパスワード保護](/slides/ja/nodejs-java/password-protected-presentation/)
- [プレゼンテーションの書き込み保護](/slides/ja/nodejs-java/write-protected-presentation/)

## **FAQ**

**フォントが埋め込まれているか、どのフォントが埋め込まれているかを確認するにはどうすればよいですか？**

プレゼンテーションをロードし、[Presentation.getFontsManager](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/getfontsmanager/) を使用します。[FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) で埋め込まれたフォントを取得し、[FontsManager.getFonts](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fontsmanager/getfonts/) でプレゼンテーションで使用されているフォントを取得します。両方の結果を比較して、レンダリングに必要だが埋め込まれていないフォントを特定します。

**ファイルに非表示スライドがあるかどうか、またその数をすぐに知るにはどうすればよいですか？**

保存されたドキュメント メタデータが十分であれば、[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) と [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) を介して [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) を読み取ります。これは軽量インベントリに適しています。プレゼンテーションがメモリ上で変更されている場合、保存されたメタデータが欠落または古くなる可能性があるため、[Presentation.getSlides](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/getslides/) を走査し、各スライドの [Slide.getHidden](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slide/gethidden/) メソッドで確認してください。

**カスタムスライド サイズと向きが使用されているか、デフォルトと異なるかを検出できますか？**

はい。プレゼンテーションをロードし、[Presentation.getSlideSize](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/getslidesize/) を呼び出します。[SlideSize.getType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slidesize/gettype/)、[SlideSize.getSize](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slidesize/getsize/)、[SlideSize.getOrientation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slidesize/getorientation/) を使用して現在の設定を期待されるプリセットや寸法と比較します。

**チャートが外部データ ソースを参照しているかどうかをすぐに確認する方法はありますか？**

はい。各 [Chart](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chart/) を見つけ、[ChartData.getDataSourceType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) を呼び出します。外部ブックの場合は、[ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) を呼び出します。データ ソースの種類とパスで外部参照が識別できますが、対象が利用可能かどうかは別途リソース チェックが必要です。

**レンダリングや PDF 書き出しを遅くする可能性のある「重い」スライドを評価する方法はありますか？**

単一の複雑度プロパティは存在しません。[Presentation.getSlides](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/getslides/) と各スライドの [BaseSlide.getShapes](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseslide/#getShapes) コレクションを走査します。シェイプ数や大きな画像、エフェクト、アニメーション、マルチメディアの有無をスクリーニング信号として使用し、代表的なレンダリングまたはエクスポートを測定して、スライドを確実なパフォーマンス ボトルネックとして扱うかどうかを判断します。