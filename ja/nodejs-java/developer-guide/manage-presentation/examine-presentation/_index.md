---
title: JavaScript でプレゼンテーション情報を取得および更新する
linktitle: プレゼンテーション情報
type: docs
weight: 30
url: /ja/nodejs-java/examine-presentation/
keywords:
- プレゼンテーション形式
- プレゼンテーション プロパティ
- ドキュメント プロパティ
- プロパティの取得
- プロパティの読み取り
- プロパティの変更
- プロパティの修正
- プロパティの更新
- PPTX の検査
- PPT の検査
- ODP の検査
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript を使用して PowerPoint および OpenDocument のプレゼンテーション内のスライド、構造、メタデータを調査し、迅速なインサイトとスマートなコンテンツ監査を実現します。"
---
## **概要**

この記事では、Aspose.Slides でプレゼンテーション情報を検査する方法を示します。ファイル全体を読み込まずにプレゼンテーションの現在の形式を判断し、ドキュメント プロパティを読み取り、必要に応じてそれらのプロパティを更新する方法を説明します。

例は [PresentationInfo](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentationinfo/) と [DocumentProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/documentproperties/) API を基にしており、プレゼンテーション メタデータを操作する典型的な手順を示しています。

## **プレゼンテーション形式の確認**

プレゼンテーションに取り掛かる前に、現在の形式（PPT、PPTX、ODP など）が何であるかを確認したい場合があります。

プレゼンテーションをロードせずに形式を確認できます。次の JavaScript コードをご覧ください。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
console.log(info.getLoadFormat());// PPTX
var info2 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
console.log(info2.getLoadFormat());// PPT
var info3 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.odp");
console.log(info3.getLoadFormat());// ODP
```

## **プレゼンテーション プロパティの取得**

この JavaScript コードは、プレゼンテーションのプロパティ（プレゼンテーションに関する情報）を取得する方法を示しています：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
var props = info.readDocumentProperties();
console.log(props.getCreatedTime());
console.log(props.getSubject());
console.log(props.getTitle());
// ..
```

[DocumentProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/documentproperties/#DocumentProperties--) クラス内のプロパティを確認したい場合があります。

## **プレゼンテーション プロパティの更新**

Aspose.Slides は、プレゼンテーション プロパティを変更できる [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) メソッドを提供しています。

以下のようなドキュメント プロパティが設定された PowerPoint プレゼンテーションがあるとします。

![PowerPoint プレゼンテーションの元のドキュメント プロパティ](input_properties.png)

このコード例は、いくつかのプレゼンテーション プロパティを編集する方法を示しています：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let fileName = "sample.pptx";

let info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(fileName);

let properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

プロパティを変更した結果は以下のとおりです。

![PowerPoint プレゼンテーションの変更後ドキュメント プロパティ](output_properties.png)

## **便利なリンク**

プレゼンテーションとそのセキュリティ属性についてさらに情報を得るには、次のリンクが役立つ場合があります。

- [プレゼンテーションのパスワード保護](/slides/ja/nodejs-java/password-protected-presentation/)
- [プレゼンテーションの書き込み保護](/slides/ja/nodejs-java/write-protected-presentation/)

## **よくある質問**

**フォントが埋め込まれているか、どのフォントが埋め込まれているかを確認するにはどうすればよいですか？**

プレゼンテーション レベルで [embedded-font 情報](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) を探し、[実際にコンテンツで使用されているフォント](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fontsmanager/getfonts/) の集合と比較して、レンダリングに必須のフォントを特定します。

**ファイルに非表示スライドが含まれているか、その数を素早く知るには？**

[スライド コレクション](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slidecollection/) を走査し、各スライドの [可視性フラグ](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slide/gethidden/) を確認します。

**カスタム スライドサイズや向きが使用されているか、デフォルトと異なるかを検出できますか？**

はい。現在の [スライドサイズ](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/getslidesize/) と向きを標準プリセットと比較します。これにより、印刷やエクスポート時の挙動を予測できます。

**チャートが外部データ ソースを参照しているかすぐに確認する方法はありますか？**

はい。すべての [チャート](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chart/) を走査し、[データ ソース](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) をチェックして、内部かリンクベースか、壊れたリンクがないかを確認します。

**レンダリングや PDF エクスポートを遅くする可能性のある「重い」スライドを評価するには？**

各スライドについてオブジェクト数を集計し、大きな画像、透過、影、アニメーション、マルチメディアなどを探して、概算の複雑度スコアを付け、パフォーマンス上のボトルネックとなり得るスライドをフラグします。