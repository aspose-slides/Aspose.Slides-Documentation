---
title: フォントの管理 - PowerPoint Java API
linktitle: フォントの管理
type: docs
weight: 10
url: /androidjava/manage-fonts/
description: プレゼンテーションには通常、テキストと画像の両方が含まれています。この記事では、PowerPoint Java APIを使用してスライド上のテキスト段落のフォントプロパティを構成する方法を示します。
---

## **フォント関連プロパティの管理**
{{% alert color="primary" %}} 

プレゼンテーションには通常、テキストと画像の両方が含まれています。テキストは特定のセクションや単語を強調したり、企業スタイルに準拠したりするために、さまざまな方法でフォーマットできます。テキストフォーマットは、ユーザーがプレゼンテーションコンテンツの外観を変える手助けをします。この記事では、Aspose.Slides for AndroidをJava経由で使用して、スライド上のテキスト段落のフォントプロパティを構成する方法を示します。

{{% /alert %}} 

Aspose.Slides for AndroidをJava経由で使用して段落のフォントプロパティを管理するには：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. スライド内の[Placeholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Placeholder)形状にアクセスし、それらを[AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/AutoShape)に型キャストします。
1. [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/AutoShape)によって公開された[TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/TextFrame)から[Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Paragraph)を取得します。
1. 段落を整列させます。
1. [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Paragraph)のテキスト[Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Portion)にアクセスします。
1. [FontData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/FontData)を使用してフォントを定義し、テキスト[Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Portion)の**Font**をそれに応じて設定します。
   1. フォントを太字に設定します。
   1. フォントをイタリックに設定します。
1. [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Portion)オブジェクトによって公開された[FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/FillFormat)を使用してフォントの色を設定します。
1. 修正されたプレゼンテーションをPPTXファイルに保存します。

上記の手順の実装は以下に示されています。これは装飾のないプレゼンテーションを取り込み、スライドの1つのフォントをフォーマットします。以下に示すスクリーンショットは、入力ファイルとコードスニペットがそれをどのように変更するかを示しています。コードはフォント、色、およびフォントスタイルを変更します。

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**図: 入力ファイルのテキスト**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**図: 更新されたフォーマットの同じテキスト**|

```java
// PPTXファイルを表すPresentationオブジェクトをインスタンス化
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// スライド位置を使用してスライドにアクセス
	ISlide slide = pres.getSlides().get_Item(0);

	// スライド内の最初と第二のプレースホルダーにアクセスし、AutoShapeとして型キャスト
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

	// フォントをイタリックに設定
	port1.getPortionFormat().setFontItalic(NullableBool.True);
	port2.getPortionFormat().setFontItalic(NullableBool.True);

	// フォントカラーの設定
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

**フォント関連プロパティの管理**で述べたように、[Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Portion)は段落内で同じフォーマットスタイルのテキストを保持するために使用されます。この記事では、Aspose.Slides for AndroidをJava経由で使用して、テキストボックスを作成し、特定のフォント及びフォントファミリカテゴリのさまざまな他のプロパティを定義する方法を示します。

{{% /alert %}} 

テキストボックスを作成し、その中のテキストのフォントプロパティを設定するには：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. スライドに**Rectangle**タイプの[AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/AutoShape)を追加します。
1. [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/AutoShape)に関連付けられたフィルスタイルを削除します。
1. [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/AutoShape)の[TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/TextFrame)にアクセスします。
1. [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/TextFrame)にテキストを追加します。
1. [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/TextFrame)に関連する[Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Portion)オブジェクトにアクセスします。
1. [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Portion)で使用するフォントを定義します。
1. 太字、イタリック、下線、色、高さなどの他のフォントプロパティを[Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Portion)オブジェクトによって公開された関連プロパティを使用して設定します。
1. 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

上記の手順の実装は以下に示されています。

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**図: Aspose.Slides for AndroidをJava経由で設定されたフォントプロパティを持つテキスト**|

```java
// PPTXファイルを表すPresentationオブジェクトをインスタンス化
Presentation pres = new Presentation();
try {
	// 最初のスライドを取得
	ISlide sld = pres.getSlides().get_Item(0);
	
	// RectangleタイプのAutoShapeを追加
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// AutoShapeに関連するフィルスタイルを削除
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// AutoShapeに関連するTextFrameにアクセス
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// TextFrameに関連するPortionにアクセス
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// Portionのフォントを設定
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	// フォントの太字プロパティを設定
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// フォントのイタリックプロパティを設定
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