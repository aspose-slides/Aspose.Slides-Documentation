---
title: Android でのプレゼンテーションのフォント管理
linktitle: フォント管理
type: docs
weight: 10
url: /ja/androidjava/manage-fonts/
keywords:
- フォントの管理
- フォント プロパティ
- 段落
- テキスト フォーマット
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用した Java でフォントを制御します：フォントを埋め込み、置換し、カスタムフォントをロードして、PPT、PPTX、ODP プレゼンテーションを明瞭でブランド安全かつ一貫性のある状態に保ちます。"
---
## **概要**

Aspose.Slides を使用すると、コードから直接プレゼンテーションのテキストのフォントプロパティを管理できます。スライド内のテキストは、シェイプ、テキストフレーム、段落、ポーションを介してアクセスでき、選択したテキストに書式設定を適用できます。

この記事では、フォントファミリ、太字および斜体スタイル、段落配置、フォント色など、プレゼンテーション内の既存テキストのフォント関連プロパティを設定する方法を説明します。また、テキストボックスを作成し、テキストを追加し、フォントファミリ、太字、斜体、下線、フォントサイズ、色などのフォントプロパティを設定してから、結果を PPTX ファイルとして保存する方法も示します。

## **フォント関連プロパティの管理**
{{% alert color="info" %}} 

プレゼンテーションには通常、テキストと画像の両方が含まれます。テキストはさまざまな方法で書式設定でき、特定のセクションや単語を強調したり、企業のスタイルに合わせたりします。テキストの書式設定により、プレゼンテーション コンテンツの外観と感触を変えることができます。この記事では、Aspose.Slides for Android via Java を使用してスライド上の段落テキストのフォントプロパティを構成する方法を示します。

{{% /alert %}} 

Aspose.Slides for Android via Java を使用して段落のフォントプロパティを管理する手順:

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライド内の [Placeholder](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/placeholder/) シェイプにアクセスし、[AutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/autoshape/) に型キャストします。
4. [AutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/autoshape/) が公開する [TextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/textframe/) から [Paragraph](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/paragraph/) を取得します。
5. 段落を左右揃えにします。
6. [Paragraph](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/paragraph/) のテキスト [Portion](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/portion/) にアクセスします。
7. [FontData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fontdata/) を使用してフォントを定義し、テキスト [Portion](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/portion/) の **Font** を適切に設定します。
   1. フォントを太字に設定します。
   1. フォントを斜体に設定します。
8. [Portion](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/portion/) オブジェクトが公開する [FillFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fillformat/) を使用してフォント色を設定します。
9. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

上記手順の実装例を以下に示します。装飾のないプレゼンテーションを取得し、スライドの 1 つのフォントをフォーマットします。以下のスクリーンショットは入力ファイルとコード スニペットがそれをどのように変更するかを示しています。コードはフォント、色、フォントスタイルを変更します。

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**図: 入力ファイルのテキスト**|

|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**図: 更新された書式設定の同じテキスト**|

```java
import com.aspose.slides.*;
import java.awt.Color;

// PPTX ファイルを表す Presentation オブジェクトをインスタンス化
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// スライド位置を使用してスライドにアクセス
	ISlide slide = pres.getSlides().get_Item(0);

	// スライド内の最初と2番目のプレースホルダーにアクセスし、AutoShape に型キャスト
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	// 最初の段落にアクセス
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

	// 段落を左右揃えに設定
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

	// PPTX をディスクに保存
	pres.save("WelcomeFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **テキストフォントプロパティの設定**
{{% alert color="info" %}} 

**フォント関連プロパティの管理** で述べたように、[Portion](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/portion/) は段落内で同一の書式スタイルを持つテキストを保持するために使用されます。この記事では、Aspose.Slides for Android via Java を使用してテキストボックスを作成し、テキストを追加した後、特定のフォントやフォントファミリ カテゴリのさまざまなプロパティを定義する方法を示します。

{{% /alert %}} 

テキストボックスを作成し、その中のテキストのフォントプロパティを設定する手順:

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライドに **Rectangle** タイプの [AutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/autoshape/) を追加します。
4. [AutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/autoshape/) に関連付けられた塗りつぶしスタイルを削除します。
5. [AutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/autoshape/) の [TextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/textframe/) にアクセスします。
6. [TextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/textframe/) にテキストを追加します。
7. [TextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/textframe/) に関連付けられた [Portion](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/portion/) オブジェクトにアクセスします。
8. [Portion](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/portion/) に使用するフォントを定義します。
9. [Portion](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/portion/) オブジェクトが公開する関連プロパティを使用して、太字、斜体、下線、色、サイズなどの他のフォントプロパティを設定します。
10. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。

上記手順の実装例を以下に示します。

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**図: Aspose.Slides for Android via Java で設定されたフォントプロパティを持つテキスト**|

```java
import com.aspose.slides.*;
import java.awt.Color;

// PPTX ファイルを表す Presentation オブジェクトをインスタンス化
Presentation pres = new Presentation();
try {
	// 最初のスライドを取得
	ISlide sld = pres.getSlides().get_Item(0);
	
	// Rectangle タイプの AutoShape を追加
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// AutoShape に関連付けられた塗りつぶしスタイルをすべて削除
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// AutoShape に関連付けられた TextFrame にアクセス
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// TextFrame に関連付けられた Portion にアクセス
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// Portion 用のフォントを設定
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	// フォントの太字プロパティを設定
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// フォントの斜体プロパティを設定
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// フォントの下線プロパティを設定
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	// フォントのサイズを設定
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