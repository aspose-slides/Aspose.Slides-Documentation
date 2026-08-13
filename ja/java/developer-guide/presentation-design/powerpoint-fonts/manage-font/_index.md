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
- テキスト 書式設定
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides を使用した Java でフォントを制御します：埋め込み、置換、カスタムフォントのロードにより、PPT、PPTX、ODP プレゼンテーションをクリアでブランド安全かつ一貫した状態に保ちます。"
---
## **概要**

Aspose.Slides を使用すると、コードから直接プレゼンテーションのテキストのフォント プロパティを管理できます。スライド内のテキストはシェイプ、テキスト フレーム、段落、ポーションを介して取得し、選択したテキストに書式設定を適用できます。

この記事では、プレゼンテーション内の既存テキストに対してフォント ファミリ、太字・斜体スタイル、段落の配置、フォントの色などのフォント関連プロパティを設定する方法を説明します。また、テキスト ボックスを作成し、テキストを追加し、フォント ファミリ、太字、斜体、下線、フォント サイズ、色などのフォント プロパティを設定して PPTX ファイルとして保存する方法も示します。

## **フォント関連プロパティの管理**
{{% alert color="info" %}} 

プレゼンテーションには通常、テキストと画像の両方が含まれます。テキストは特定のセクションや単語を強調したり、企業のスタイルに合わせたりするためにさまざまに書式設定できます。テキストの書式設定は、プレゼンテーション コンテンツの外観を変えるのに役立ちます。本記事では、Aspose.Slides for Java を使用してスライド上の段落テキストのフォント プロパティを構成する方法を紹介します。

{{% /alert %}} 

Aspose.Slides for Java で段落のフォント プロパティを管理する手順:

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation) クラスのインスタンスを作成します。  
1. インデックスを使用してスライドの参照を取得します。  
1. スライド内の [Placeholder](https://reference.aspose.com/slides/ja/java/com.aspose.slides/placeholder/) シェイプにアクセスし、[AutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/autoshape/) に型変換します。  
1. [AutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/autoshape/) から取得できる [TextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/textframe/) から [Paragraph](https://reference.aspose.com/slides/ja/java/com.aspose.slides/paragraph/) を取得します。  
1. 段落を均等割り付けに設定します。  
1. [Paragraph](https://reference.aspose.com/slides/ja/java/com.aspose.slides/paragraph/) のテキスト [Portion](https://reference.aspose.com/slides/ja/java/com.aspose.slides/portion/) にアクセスします。  
1. [FontData](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fontdata/) を使用してフォントを定義し、テキスト [Portion](https://reference.aspose.com/slides/ja/java/com.aspose.slides/portion/) の **Font** を適切に設定します。  
   1. フォントを太字に設定します。  
   1. フォントを斜体に設定します。  
1. [Portion](https://reference.aspose.com/slides/ja/java/com.aspose.slides/portion/) オブジェクトが公開する [FillFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fillformat/) を使用してフォント色を設定します。  
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

上記手順の実装例は以下の通りです。装飾されていないプレゼンテーションを取得し、スライドのフォントをフォーマットします。以下のスクリーンショットは入力ファイルとコード スニペットによる変更結果を示しています。コードはフォント、色、フォント スタイルを変更します。

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**図: 入力ファイルのテキスト**|

|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**図: 更新された書式設定の同じテキスト**|

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instantiate a Presentation object that represents a PPTX file
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// スライドの位置を使用してスライドにアクセスします
	ISlide slide = pres.getSlides().get_Item(0);

	// スライド内の最初と2番目のプレースホルダーにアクセスし、AutoShape に型変換します
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	// 最初の段落にアクセスします
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

	// 段落を両端揃えにします
	para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

	// 最初のポーションにアクセスします
	IPortion port1 = para1.getPortions().get_Item(0);
	IPortion port2 = para2.getPortions().get_Item(0);

	// 新しいフォントを定義します
	FontData fd1 = new FontData("Elephant");
	FontData fd2 = new FontData("Castellar");

	// ポーションに新しいフォントを割り当てます
	port1.getPortionFormat().setLatinFont(fd1);
	port2.getPortionFormat().setLatinFont(fd2);

	// フォントを太字に設定します
	port1.getPortionFormat().setFontBold(NullableBool.True);
	port2.getPortionFormat().setFontBold(NullableBool.True);

	// フォントを斜体に設定します
	port1.getPortionFormat().setFontItalic(NullableBool.True);
	port2.getPortionFormat().setFontItalic(NullableBool.True);

	// フォントの色を設定します
	port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

	// PPTX をディスクに保存します
	pres.save("WelcomeFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **テキスト フォント プロパティの設定**
{{% alert color="info" %}} 

**フォント関連プロパティの管理** で述べたように、[Portion](https://reference.aspose.com/slides/ja/java/com.aspose.slides/portion/) は段落内で同じ書式スタイルのテキストを保持するために使用されます。本記事では、Aspose.Slides for Java を使用してテキスト ボックスを作成し、テキストに特定のフォントとフォント ファミリ カテゴリのさまざまなプロパティを定義する方法を示します。

{{% /alert %}} 

テキスト ボックスを作成し、そのテキストのフォント プロパティを設定する手順:

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation) クラスのインスタンスを作成します。  
1. インデックスを使用してスライドの参照を取得します。  
1. スライドに **Rectangle** タイプの [AutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/autoshape/) を追加します。  
1. [AutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/autoshape/) に関連付けられた塗りつぶしスタイルを削除します。  
1. [AutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/autoshape/) の [TextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/textframe/) にアクセスします。  
1. [TextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/textframe/) にテキストを追加します。  
1. [TextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/textframe/) に関連付けられた [Portion](https://reference.aspose.com/slides/ja/java/com.aspose.slides/portion/) オブジェクトにアクセスします。  
1. [Portion](https://reference.aspose.com/slides/ja/java/com.aspose.slides/portion/) で使用するフォントを定義します。  
1. [Portion](https://reference.aspose.com/slides/ja/java/com.aspose.slides/portion/) オブジェクトが提供する関連プロパティを使用して、太字、斜体、下線、色、高さなどの他のフォント プロパティを設定します。  
1. 変更したプレゼンテーションを PPTX ファイルとして書き出します。

上記手順の実装例は以下の通りです。

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**図: Aspose.Slides for Java で設定されたフォント プロパティを持つテキスト**|

```java
import com.aspose.slides.*;
import java.awt.Color;

// PPTX ファイルを表す Presentation オブジェクトをインスタンス化します
Presentation pres = new Presentation();
try {
	// 最初のスライドを取得します
	ISlide sld = pres.getSlides().get_Item(0);
	
	// Rectangle タイプの AutoShape を追加します
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// AutoShape に関連付けられた塗りつぶしスタイルを削除します
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// AutoShape に関連付けられた TextFrame にアクセスします
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// TextFrame に関連付けられた Portion にアクセスします
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// Portion のフォントを設定します
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	// フォントの太字プロパティを設定します
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// フォントの斜体プロパティを設定します
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// フォントの下線プロパティを設定します
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	// フォントの高さを設定します
	port.getPortionFormat().setFontHeight(25);
	
	// フォントの色を設定します
	port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	
	// プレゼンテーションをディスクに保存します
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```