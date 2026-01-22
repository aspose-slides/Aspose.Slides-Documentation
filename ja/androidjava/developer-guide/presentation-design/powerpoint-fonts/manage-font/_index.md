---
title: Androidでプレゼンテーションのフォントを管理
linktitle: フォントを管理
type: docs
weight: 10
url: /ja/androidjava/manage-fonts/
keywords:
- フォントを管理
- フォントプロパティ
- 段落
- テキスト書式設定
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "JavaでAspose.Slides for Androidを使用してフォントを制御：フォントを埋め込み、代替し、カスタムフォントを読み込んで、PPT、PPTX、ODPプレゼンテーションをクリアでブランド安全、かつ一貫性のある状態に保ちます。"
---

## **フォント関連プロパティの管理**
{{% alert color="primary" %}} 

プレゼンテーションは通常、テキストと画像の両方を含みます。テキストはさまざまな方法で書式設定でき、特定のセクションや単語を強調したり、企業のスタイルに合わせたりできます。テキストの書式設定は、プレゼンテーション内容の外観や感触を変えるのに役立ちます。本記事では、Aspose.Slides for Android via Java を使用して、スライド上のテキスト段落のフォントプロパティを構成する方法を示します。

{{% /alert %}} 

Aspose.Slides for Android via Java を使用して段落のフォントプロパティを管理するには:

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. スライド内の [Placeholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) シェイプにアクセスし、[AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/autoshape/) に型キャストします。
1. [AutoShape] が公開する [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/) から [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/) を取得します。
1. 段落を両端揃えにします。
1. [Paragraph] のテキスト [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) にアクセスします。
1. [FontData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontdata/) を使用してフォントを定義し、テキスト [Portion] の **Font** をそれに応じて設定します。
   1. フォントを太字に設定します。
   1. フォントをイタリック体に設定します。
1. [Portion] オブジェクトが公開する [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/) を使用してフォントの色を設定します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

上記の手順の実装例を以下に示します。装飾のないプレゼンテーションを取得し、スライドの1つのフォントをフォーマットします。以下のスクリーンショットは入力ファイルとコードスニペットがどのように変更されるかを示します。コードはフォント、色、およびフォントスタイルを変更します。

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**図: 入力ファイルのテキスト**|

|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**図: 更新された書式設定の同じテキスト**|
```java
// PPTX ファイルを表す Presentation オブジェクトをインスタンス化する
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// スライドの位置を使ってスライドにアクセスする
	ISlide slide = pres.getSlides().get_Item(0);

	// スライド内の最初と2番目のプレースホルダーにアクセスし、AutoShape に型キャストする
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	// 最初の Paragraph にアクセスする
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

	// 段落を両端揃えにする
	para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

	// 最初の Portion にアクセスする
	IPortion port1 = para1.getPortions().get_Item(0);
	IPortion port2 = para2.getPortions().get_Item(0);

	// 新しいフォントを定義する
	FontData fd1 = new FontData("Elephant");
	FontData fd2 = new FontData("Castellar");

	// 新しいフォントを Portion に割り当てる
	port1.getPortionFormat().setLatinFont(fd1);
	port2.getPortionFormat().setLatinFont(fd2);

	// フォントを太字に設定する
	port1.getPortionFormat().setFontBold(NullableBool.True);
	port2.getPortionFormat().setFontBold(NullableBool.True);

	// フォントを斜体に設定する
	port1.getPortionFormat().setFontItalic(NullableBool.True);
	port2.getPortionFormat().setFontItalic(NullableBool.True);

	// フォントの色を設定する
	port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

	// PPTX をディスクに保存する
	pres.save("WelcomeFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```


## **テキストフォントプロパティの設定**
{{% alert color="primary" %}} 

As mentioned in **Managing Font Related Properties**, a [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) は段落内で同じ書式スタイルのテキストを保持するために使用されます。本記事では、Aspose.Slides for Android via Java を使用してテキストボックスを作成し、いくつかのテキストを設定し、特定のフォントやフォントファミリーカテゴリのさまざまなプロパティを定義する方法を示します。

{{% /alert %}} 

テキストボックスを作成し、その中のテキストのフォントプロパティを設定するには:

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. スライドにタイプ **Rectangle** の [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/autoshape/) を追加します。
1. [AutoShape] に関連付けられた塗りつぶしスタイルを削除します。
1. [AutoShape] の [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/) にアクセスします。
1. [TextFrame] にテキストを追加します。
1. [TextFrame] に関連付けられた [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) オブジェクトにアクセスします。
1. [Portion] に使用するフォントを定義します。
1. [Portion] オブジェクトが提供する関連プロパティを使用して、太字、イタリック、下線、色、サイズなどの他のフォントプロパティを設定します。
1. 変更したプレゼンテーションを書き出して PPTX ファイルとして保存します。

上記の手順の実装例は以下です。

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**図: Aspose.Slides for Android via Java によって設定されたフォントプロパティを持つテキスト**|
```java
// PPTX ファイルを表す Presentation オブジェクトをインスタンス化する
Presentation pres = new Presentation();
try {
	// 最初のスライドを取得する
	ISlide sld = pres.getSlides().get_Item(0);
	
	// Rectangle 種類の AutoShape を追加する
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// AutoShape に関連付けられた塗りつぶしスタイルを削除する
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// AutoShape に関連付けられた TextFrame にアクセスする
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// TextFrame に関連付けられた Portion にアクセスする
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// Portion のフォントを設定する
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	// フォントの太字プロパティを設定する
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// フォントの斜体プロパティを設定する
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// フォントの下線プロパティを設定する
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	// フォントの高さを設定する
	port.getPortionFormat().setFontHeight(25);
	
	// フォントの色を設定する
	port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	
	// プレゼンテーションをディスクに保存する
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```
