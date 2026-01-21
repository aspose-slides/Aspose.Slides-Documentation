---
title: Java を使用したプレゼンテーションでのフォント管理
linktitle: フォント管理
type: docs
weight: 10
url: /ja/java/manage-fonts/
keywords:
- フォントの管理
- フォント プロパティ
- 段落
- テキスト書式設定
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して Java でフォントを制御します：埋め込み、置換、カスタムフォントの読み込みを行い、PPT、PPTX、ODP プレゼンテーションをクリアでブランド安全かつ一貫性のある状態に保ちます。"
---

## **フォント関連プロパティの管理**
{{% alert color="primary" %}} 

プレゼンテーションには通常、テキストと画像の両方が含まれます。テキストはさまざまな方法で書式設定でき、特定のセクションや単語を強調したり、企業のスタイルに合わせたりできます。テキストの書式設定は、プレゼンテーションの内容の外観や感覚を変えるのに役立ちます。本稿では、Aspose.Slides for Java を使用してスライド上のテキスト段落のフォントプロパティを設定する方法を示します。

{{% /alert %}} 

段落のフォントプロパティを管理するには、Aspose.Slides for Java を使用します。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. スライド内の [Placeholder](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/) シェイプにアクセスし、[AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/) に型変換します。
1. [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/) が公開する [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/) から [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/) を取得します。
1. 段落を両端揃えにします。
1. [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/) のテキスト [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) にアクセスします。
1. [FontData](https://reference.aspose.com/slides/java/com.aspose.slides/fontdata/) を使用してフォントを定義し、テキスト [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) の **Font** を適切に設定します。
   1. フォントを太字に設定します。
   1. フォントを斜体に設定します。
1. [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) オブジェクトが公開する [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/) を使用してフォントの色を設定します。
1. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

上記の手順の実装例を以下に示します。装飾のないプレゼンテーションを取得し、スライドの一つのフォントを書式設定します。以下のスクリーンショットは入力ファイルとコードスニペットがどのように変更するかを示しています。コードはフォント、色、およびフォントスタイルを変更します。

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**図: 入力ファイルのテキスト**|

|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**図: 更新された書式設定の同じテキスト**|
```java
	// PPTX ファイルを表す Presentation オブジェクトをインスタンス化
Presentation pres = new Presentation("FontProperties.pptx");
try {
		// スライド位置でスライドにアクセス
		ISlide slide = pres.getSlides().get_Item(0);

		// スライド内の最初と 2 番目のプレースホルダーにアクセスし、AutoShape に型変換
		ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
		ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

		// 最初の Paragraph にアクセス
		IParagraph para1 = tf1.getParagraphs().get_Item(0);
		IParagraph para2 = tf2.getParagraphs().get_Item(0);

		// 段落を両端揃えに設定
		para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

		// 最初の Portion にアクセス
		IPortion port1 = para1.getPortions().get_Item(0);
		IPortion port2 = para2.getPortions().get_Item(0);

		// 新しいフォントを定義
		FontData fd1 = new FontData("Elephant");
		FontData fd2 = new FontData("Castellar");

		// Portion に新しいフォントを割り当て
		port1.getPortionFormat().setLatinFont(fd1);
		port2.getPortionFormat().setLatinFont(fd2);

		// フォントを太字に設定
		port1.getPortionFormat().setFontBold(NullableBool.True);
		port2.getPortionFormat().setFontBold(NullableBool.True);

		// フォントを斜体に設定
		port1.getPortionFormat().setFontItalic(NullableBool.True);
		port2.getPortionFormat().setFontItalic(NullableBool.True);

		// フォントの色を設定
		port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
		port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
		port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
		port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

		// PPTX をディスクに保存
		pres.save("WelcomeFont.pptx", SaveFormat.Pptx);
	} finally {
		if (pres != null) pres.dispose();
	}
```


## **テキストフォントプロパティの設定**
{{% alert color="primary" %}} 

**Managing Font Related Properties** で説明したように、[Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) は段落内で同じ書式スタイルのテキストを保持するために使用されます。本稿では、Aspose.Slides for Java を使用してテキストボックスを作成し、特定のフォントおよびフォントファミリカテゴリのさまざまなプロパティを定義する方法を示します。

{{% /alert %}} 

テキストボックスを作成し、その中のテキストのフォントプロパティを設定するには、次の手順を行います。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. スライドにタイプ **Rectangle** の [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/) を追加します。
1. [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/) に関連付けられた塗りスタイルを削除します。
1. [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/) の [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/) にアクセスします。
1. [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/) にテキストを追加します。
1. [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/) に関連付けられた [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) オブジェクトにアクセスします。
1. [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) に使用するフォントを定義します。
1. [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) オブジェクトが提供する関連プロパティを使用して、太字、斜体、下線、色、高さなどの他のフォントプロパティを設定します。
1. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。

上記の手順の実装例を以下に示します。

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**図: Aspose.Slides for Java によって設定された一部フォントプロパティを持つテキスト**|
```java
// PPTX ファイルを表す Presentation オブジェクトをインスタンス化
Presentation pres = new Presentation();
try {
	// 最初のスライドを取得
	ISlide sld = pres.getSlides().get_Item(0);
	
	// Rectangle タイプの AutoShape を追加
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// AutoShape に関連付けられた塗りスタイルを削除
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// AutoShape に関連付けられた TextFrame にアクセス
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// TextFrame に関連付けられた Portion にアクセス
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// Portion のフォントを設定
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	// フォントの太字プロパティを設定
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// フォントの斜体プロパティを設定
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// フォントの下線プロパティを設定
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	// フォントの高さを設定
	port.getPortionFormat().setFontHeight(25);
	
	// フォントの色を設定
	port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	
	// プレゼンテーションをディスクに保存
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```
