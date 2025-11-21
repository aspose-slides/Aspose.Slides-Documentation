---
title: プレゼンテーションの検査
type: docs
weight: 30
url: /ja/nodejs-java/examine-presentation/
keywords:
- PowerPoint
- プレゼンテーション
- プレゼンテーション形式
- プレゼンテーションプロパティ
- ドキュメントプロパティ
- プロパティ取得
- プロパティ読み取り
- プロパティ変更
- プロパティ修正
- PPTX
- PPT
- JavaScript
- Node
description: "Node で PowerPoint プレゼンテーションのプロパティを読み取り・変更"
---

Aspose.Slides for Node.js via Java を使用すると、プレゼンテーションを調べてそのプロパティを確認し、動作を理解できます。

{{% alert title="Info" color="info" %}} 

ここで使用する操作に必要なプロパティとメソッドは、[PresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo) と [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/documentproperties/) クラスに含まれています。

{{% /alert %}} 

## **プレゼンテーションの形式を確認する**

プレゼンテーションを操作する前に、現在の形式（PPT、PPTX、ODP など）が何であるかを確認したくなることがあります。

プレゼンテーションをロードせずに形式を確認できます。以下の JavaScript コードをご覧ください：
```javascript
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
console.log(info.getLoadFormat());// PPTX形式
var info2 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
console.log(info2.getLoadFormat());// PPT形式
var info3 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.odp");
console.log(info3.getLoadFormat());// ODP形式
```


## **プレゼンテーションのプロパティを取得する**

この JavaScript コードは、プレゼンテーションのプロパティ（プレゼンテーションに関する情報）を取得する方法を示しています：
```javascript
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
var props = info.readDocumentProperties();
console.log(props.getCreatedTime());
console.log(props.getSubject());
console.log(props.getTitle());
// ..
```


DocumentProperties クラスの [プロパティ](https://reference.aspose.com/slides/nodejs-java/aspose.slides/documentproperties/#DocumentProperties--) を確認したくなるかもしれません。

## **プレゼンテーションのプロパティを更新する**

Aspose.Slides は、プレゼンテーションのプロパティを変更できる [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) メソッドを提供しています。

以下に示すようなドキュメントプロパティを持つ PowerPoint プレゼンテーションがあるとします。

![PowerPoint プレゼンテーションの元のドキュメントプロパティ](input_properties.png)

このコード例は、いくつかのプレゼンテーションプロパティを編集する方法を示しています：
```javascript
let fileName = "sample.pptx";

let info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(fileName);

let properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```


ドキュメントプロパティを変更した結果は以下のとおりです。

![PowerPoint プレゼンテーションの変更後のドキュメントプロパティ](output_properties.png)

## **便利なリンク**

プレゼンテーションとそのセキュリティ属性に関する詳細情報を得るには、以下のリンクが役立つかもしれません：

- [プレゼンテーションが暗号化されているかどうかの確認](https://docs.aspose.com/slides/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [プレゼンテーションが書き込み保護（読み取り専用）されているかどうかの確認](https://docs.aspose.com/slides/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [プレゼンテーションをロードする前にパスワードで保護されているかどうかの確認](https://docs.aspose.com/slides/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [プレゼンテーションを保護するために使用されたパスワードの確認](https://docs.aspose.com/slides/nodejs-java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**フォントが埋め込まれているか、どのフォントが埋め込まれているかをどう確認できますか？**

プレゼンテーションレベルで [embedded-font information](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) を探し、次にそれらのエントリを [実際にコンテンツで使用されているフォント](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getfonts/) の集合と比較して、レンダリングに重要なフォントを特定します。

**ファイルに非表示スライドがあるか、またその数をすばやく確認する方法は？**

[slide collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/) を反復処理し、各スライドの [visibility flag](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/gethidden/) を確認します。

**カスタムスライドサイズと向きが使用されているか、デフォルトと異なるかを検出できますか？**

はい。現在の [slide size](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getslidesize/) と向きを標準のプリセットと比較します。これにより、印刷やエクスポート時の動作を予測できます。

**チャートが外部データソースを参照しているかどうかをすばやく確認する方法はありますか？**

はい。すべての [charts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/) を走査し、各々の [data source](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) を確認して、データが内部かリンクベースか、破損したリンクがあるかどうかを記録します。

**レンダリングや PDF エクスポートを遅くする可能性のある「重い」スライドをどのように評価できますか？**

各スライドについてオブジェクト数を集計し、大きな画像、透過、影、アニメーション、マルチメディアなどを調べます。おおまかな複雑度スコアを付与し、パフォーマンス上のボトルネックになり得る箇所を示します。