---
title: JavaScript を使用したプレゼンテーションでのフォント管理
linktitle: フォント管理
type: docs
weight: 10
url: /ja/nodejs-java/manage-fonts/
keywords:
- フォント管理
- フォントプロパティ
- 段落
- テキスト書式設定
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java を使用してフォントを制御します：埋め込み、置換、カスタムフォントの読み込みで PPT、PPTX、ODP プレゼンテーションをクリアで一貫性のある状態に保ちます。"
---

## **フォント関連プロパティの管理**
{{% alert color="primary" %}} 

プレゼンテーションは通常、テキストと画像の両方を含みます。テキストはさまざまな方法で書式設定でき、特定のセクションや単語を強調したり、企業のスタイルに合わせたりできます。テキストの書式設定により、プレゼンテーション コンテンツの外観と感触を変えることができます。本稿では、Aspose.Slides for Node.js via Java を使用してスライド上の段落テキストのフォント プロパティを構成する方法を示します。

{{% /alert %}} 

Aspose.Slides for Node.js via Java を使用して段落のフォント プロパティを管理する手順:

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. スライド内の [Placeholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/) 形状にアクセスし、[AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) にキャストします。
1. [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) が提供する [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) から [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) を取得します。
1. 段落を両端揃えにします。
1. [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) のテキスト [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) にアクセスします。
1. [FontData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontdata/) を使用してフォントを定義し、テキスト [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) の **Font** を設定します。
   1. フォントを太字に設定します。
   1. フォントを斜体に設定します。
1. [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) オブジェクトが提供する [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/) を使用してフォントカラーを設定します。
1. 変更済みプレゼンテーションを PPTX ファイルとして保存します。

上記手順の実装例を以下に示します。装飾のないプレゼンテーションを取得し、1 つのスライドのフォントをフォーマットします。以下のスクリーンショットは入力ファイルとコード スニペットがそれをどのように変更するかを示しています。コードはフォント、カラー、フォント スタイルを変更します。

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**図: 入力ファイルのテキスト**|

|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**図: 更新された書式設定の同じテキスト**|
```javascript
// PPTX ファイルを表す Presentation オブジェクトをインスタンス化する
var pres = new aspose.slides.Presentation("FontProperties.pptx");
try {
    // スライドの位置を使用してスライドにアクセスする
    var slide = pres.getSlides().get_Item(0);
    // スライド内の最初と2番目のプレースホルダーにアクセスし、AutoShape にキャストする
    var tf1 = slide.getShapes().get_Item(0).getTextFrame();
    var tf2 = slide.getShapes().get_Item(1).getTextFrame();
    // 最初の段落にアクセスする
    var para1 = tf1.getParagraphs().get_Item(0);
    var para2 = tf2.getParagraphs().get_Item(0);
    // 段落を両端揃えにする
    para2.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.JustifyLow);
    // 最初のポーションにアクセスする
    var port1 = para1.getPortions().get_Item(0);
    var port2 = para2.getPortions().get_Item(0);
    // 新しいフォントを定義する
    var fd1 = new aspose.slides.FontData("Elephant");
    var fd2 = new aspose.slides.FontData("Castellar");
    // ポーションに新しいフォントを割り当てる
    port1.getPortionFormat().setLatinFont(fd1);
    port2.getPortionFormat().setLatinFont(fd2);
    // フォントを太字に設定する
    port1.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // フォントを斜体に設定する
    port1.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // フォントの色を設定する
    port1.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    port2.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    // PPTX をディスクに保存する
    pres.save("WelcomeFont.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **テキストフォントプロパティの設定**
{{% alert color="primary" %}} 

**フォント関連プロパティの管理** で述べたように、[Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) は段落内で同じ書式スタイルのテキストを保持するために使用されます。本稿では、Aspose.Slides for Node.js via Java を使用してテキスト ボックスを作成し、特定のフォントとフォント ファミリ カテゴリのさまざまなプロパティを定義する方法を示します。

{{% /alert %}} 

テキスト ボックスを作成し、そのテキストのフォント プロパティを設定する手順:

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. スライドにタイプ **Rectangle** の [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) を追加します。
1. [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) に関連付けられた塗りつぶしスタイルを削除します。
1. [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) の [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) にアクセスします。
1. [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) にテキストを追加します。
1. [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) に関連付けられた [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) オブジェクトにアクセスします。
1. [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) に使用するフォントを定義します。
1. [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) オブジェクトが提供する関連プロパティを使用して、太字、斜体、下線、色、高さなどの他のフォント プロパティを設定します。
1. 変更済みプレゼンテーションを PPTX ファイルとして書き出します。

上記手順の実装例を以下に示します。

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**図: Aspose.Slides for Node.js via Java によって設定されたテキストのフォントプロパティ**|
```javascript
// PPTX ファイルを表す Presentation オブジェクトをインスタンス化する
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得する
    var sld = pres.getSlides().get_Item(0);
    // 矩形タイプの AutoShape を追加する
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    // AutoShape に関連付けられた塗りつぶしスタイルを削除する
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // AutoShape に関連付けられた TextFrame にアクセスする
    var tf = ashp.getTextFrame();
    tf.setText("Aspose TextBox");
    // TextFrame に関連付けられた Portion にアクセスする
    var port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
    // Portion のフォントを設定する
    port.getPortionFormat().setLatinFont(new aspose.slides.FontData("Times New Roman"));
    // フォントの太字プロパティを設定する
    port.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // フォントの斜体プロパティを設定する
    port.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // フォントの下線プロパティを設定する
    port.getPortionFormat().setFontUnderline(aspose.slides.TextUnderlineType.Single);
    // フォントのサイズを設定する
    port.getPortionFormat().setFontHeight(25);
    // フォントの色を設定する
    port.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    // プレゼンテーションをディスクに保存する
    pres.save("pptxFont.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
