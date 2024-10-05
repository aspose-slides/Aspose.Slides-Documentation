---
title: フォントの管理 - PowerPoint Java API
linktitle: フォントの管理
type: docs
weight: 10
url: /java/manage-fonts/
description: プレゼンテーションには通常、テキストと画像の両方が含まれています。この記事では、PowerPoint Java APIを使用してスライド上のテキスト段落のフォントプロパティを設定する方法を示します。
---

## **フォント関連プロパティの管理**
{{% alert color="primary" %}} 

プレゼンテーションには通常、テキストと画像の両方が含まれています。テキストは特定のセクションや単語を強調するため、あるいは企業スタイルに合わせるために、さまざまにフォーマットできます。テキストのフォーマットは、ユーザーがプレゼンテーションコンテンツの外観や印象を変えるのに役立ちます。この記事では、Aspose.Slides for Javaを使用してスライド上のテキスト段落のフォントプロパティを設定する方法を示します。

{{% /alert %}} 

Aspose.Slides for Javaを使用して段落のフォントプロパティを管理するには：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. スライド内の[Placeholder](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Placeholder)シェイプにアクセスし、それらを[AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/classes/AutoShape)に型変換します。
1. [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/classes/AutoShape)が公開する[TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/classes/TextFrame)から[Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Paragraph)を取得します。
1. 段落を整列させます。
1. [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Paragraph)のテキスト[Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion)にアクセスします。
1. [FontData](https://reference.aspose.com/slides/java/com.aspose.slides/classes/FontData)を使用してフォントを定義し、テキスト[Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion)の**Font**をそれに応じて設定します。
   1. フォントを太字に設定します。
   1. フォントを斜体に設定します。
1. [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion)オブジェクトが露出している[FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/classes/FillFormat)を使用してフォントの色を設定します。
1. 修正されたプレゼンテーションをPPTXファイルとして保存します。

上記の手順の実装は以下に示されています。これは装飾のないプレゼンテーションを取り、スライドの1つでフォントをフォーマットします。以下のスクリーンショットは、入力ファイルとコードスニペットがどのようにそれを変更するかを示しています。コードはフォント、色、フォントスタイルを変更します。

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**図：入力ファイルのテキスト**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**図：フォーマットが更新された同じテキスト**|

```java
// PPTXファイルを表すPresentationオブジェクトをインスタンス化
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// スライド位置を使用してスライドにアクセス
	ISlide slide = pres.getSlides().get_Item(0);

	// スライド内の最初と二つ目のプレースホルダーにアクセスし、AutoShapeとして型変換
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	// 最初の段落にアクセス
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

	// 段落を整列
	para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

	// 最初のポーションにアクセス
	IPortion port1 = para1.getPortions().get_Item(0);
	IPortion port2 = para2.getPortions().get_Item(0);

	// 新しいフォントを定義
	FontData fd1 = new FontData("Elephant");
	FontData fd2 = new FontData("Castellar");

	// ポーションに新しいフォントを割り当て
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

	// PPTXをディスクに保存
	pres.save("WelcomeFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **テキストフォントプロパティの設定**
{{% alert color="primary" %}} 

**フォント関連プロパティの管理**で述べたように、[Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion)は段落内で同様のフォーマットスタイルを持つテキストを保持するために使用されます。この記事では、Aspose.Slides for Javaを使用してテキストボックスを作成し、特定のフォントやフォントファミリーカテゴリのさまざまなプロパティを定義する方法を示します。

{{% /alert %}} 

テキストボックスを作成し、その中のテキストのフォントプロパティを設定するには：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. スライドに**矩形**タイプの[AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/classes/AutoShape)を追加します。
1. [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/classes/AutoShape)に関連付けられた塗りつぶしスタイルを削除します。
1. [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/classes/AutoShape)の[TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/classes/TextFrame)にアクセスします。
1. [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/classes/TextFrame)にテキストを追加します。
1. [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/classes/TextFrame)に関連付けられた[Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion)オブジェクトにアクセスします。
1. [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion)に使用されるフォントを定義します。
1. [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion)オブジェクトによって公開される関連プロパティを使用して、太字、斜体、下線、色、高さなどの他のフォントプロパティを設定します。
1. 修正されたプレゼンテーションをPPTXファイルとして保存します。

上記の手順の実装は以下に示されています。

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**図：Aspose.Slides for Javaによって設定されたフォントプロパティのあるテキスト**|

```java
// PPTXファイルを表すPresentationオブジェクトをインスタンス化
Presentation pres = new Presentation();
try {
	// 最初のスライドを取得
	ISlide sld = pres.getSlides().get_Item(0);
	
	// 矩形タイプのAutoShapeを追加
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// AutoShapeに関連付けられた塗りつぶしスタイルを削除
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// AutoShapeに関連付けられたTextFrameにアクセス
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// TextFrameに関連付けられたPortionにアクセス
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// Portionのフォントを設定
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