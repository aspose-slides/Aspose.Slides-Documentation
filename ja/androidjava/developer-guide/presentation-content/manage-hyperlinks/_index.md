---
title: ハイパーリンクの管理
type: docs
weight: 20
url: /ja/androidjava/manage-hyperlinks/
keywords: "PowerPoint ハイパーリンク, テキストハイパーリンク, スライドハイパーリンク, 形状ハイパーリンク, 画像ハイパーリンク, ビデオハイパーリンク, Java"
description: "JavaでPowerPointプレゼンテーションにハイパーリンクを追加する方法"
---

ハイパーリンクは、オブジェクトやデータ、または何かの場所への参照です。PowerPointプレゼンテーションにおける一般的なハイパーリンクは以下の通りです：

* テキスト、形状、またはメディア内のウェブサイトへのリンク
* スライドへのリンク

Aspose.Slides for Android via Javaを使用すると、プレゼンテーション内のハイパーリンクに関連する多くのタスクを実行できます。

{{% alert color="primary" %}} 

Asposeのシンプルな、[無料のオンラインPowerPointエディタ。](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **URLハイパーリンクの追加**

### **テキストへのURLハイパーリンクの追加**

このJavaコードは、テキストにウェブサイトのハイパーリンクを追加する方法を示しています：

```java
Presentation presentation = new Presentation();
try {
	IAutoShape shape1 = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.addTextFrame("Aspose: File Format APIs");
	
	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat(); 
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setTooltip("70%以上のフォーチュン100企業がAspose APIを信頼しています");
	portionFormat.setFontHeight(32);

	presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
	if (presentation != null) presentation.dispose();
}
```

### **形状またはフレームへのURLハイパーリンクの追加**

このJavaのサンプルコードは、形状にウェブサイトのハイパーリンクを追加する方法を示しています：

```java
Presentation pres = new Presentation();
try {
	IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

	shape.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	shape.getHyperlinkClick().setTooltip("70%以上のフォーチュン100企業がAspose APIを信頼しています");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

### **メディアへのURLハイパーリンクの追加**

Aspose.Slidesを使用すると、画像、音声、ビデオファイルにハイパーリンクを追加できます。

このサンプルコードは、**画像**にハイパーリンクを追加する方法を示しています：

```java
Presentation pres = new Presentation();
try {
	// プレゼンテーションに画像を追加
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
    picture = pres.getImages().addImage(picture);
    } finally {
          if (image != null) image.dispose();
    }
	// 追加された画像に基づいてスライド1に画像フレームを作成
	IPictureFrame pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pictureFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	pictureFrame.getHyperlinkClick().setTooltip("70%以上のフォーチュン100企業がAspose APIを信頼しています");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

このサンプルコードは、**音声ファイル**にハイパーリンクを追加する方法を示しています：

```java
Presentation pres = new Presentation();
try {
	IAudio audio = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("audio.mp3")));
	IAudioFrame audioFrame = pres.getSlides().get_Item(0).getShapes().addAudioFrameEmbedded(10, 10, 100, 100, audio);

	audioFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	audioFrame.getHyperlinkClick().setTooltip("70%以上のフォーチュン100企業がAspose APIを信頼しています");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

このサンプルコードは、**ビデオ**にハイパーリンクを追加する方法を示しています：

```java
Presentation pres = new Presentation();
try {
	IVideo video = pres.getVideos().addVideo(Files.readAllBytes(Paths.get("video.avi")));
	IVideoFrame videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video);

	videoFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	videoFrame.getHyperlinkClick().setTooltip("70%以上のフォーチュン100企業がAspose APIを信頼しています");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

{{%  alert  title="ヒント"  color="primary"  %}} 

* [OLEの管理](/slides/ja/androidjava/manage-ole/) を見ると良いでしょう。

{{% /alert %}}

## **ハイパーリンクを使用して目次を作成する**

ハイパーリンクを使用すると、オブジェクトや場所への参照を追加できるため、目次を作成するために使用できます。

このサンプルコードは、ハイパーリンクを使用して目次を作成する方法を示しています：

```java
Presentation pres = new Presentation();
try {
	ISlide firstSlide = pres.getSlides().get_Item(0);
	ISlide secondSlide = pres.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

	IAutoShape contentTable = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
	contentTable.getFillFormat().setFillType(FillType.NoFill);
	contentTable.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
	contentTable.getTextFrame().getParagraphs().clear();

	Paragraph paragraph = new Paragraph();
	paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
	paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
	paragraph.setText("スライド2のタイトル .......... ");

	Portion linkPortion = new Portion();
	linkPortion.setText("ページ2");
	linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);

	paragraph.getPortions().add(linkPortion);
	contentTable.getTextFrame().getParagraphs().add(paragraph);

	pres.save("link_to_slide.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **ハイパーリンクの形式設定**

### **色**

[ColorSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Hyperlink#setColorSource-int-)プロパティを使用して、[IHyperlink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlink)インタフェースでハイパーリンクの色を設定し、ハイパーリンクから色の情報を取得できます。この機能はPowerPoint 2019で初めて導入されたため、プロパティに関する変更は古いPowerPointバージョンには適用されません。

このサンプルコードは、異なる色を持つハイパーリンクを同じスライドに追加する操作を示します：

```java
Presentation pres = new Presentation();
try {
	IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
	shape1.addTextFrame("これはカラーハイパーリンクのサンプルです。");
	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat);
	portionFormat.getFillFormat().setFillType(FillType.Solid);
	portionFormat.getFillFormat().getSolidFillColor().setColor(Color.RED);

	IAutoShape shape2 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
	shape2.addTextFrame("これは通常のハイパーリンクのサンプルです。");
	shape2.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

	pres.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **プレゼンテーションからハイパーリンクを削除する**

### **テキストからハイパーリンクを削除する**

このJavaコードは、プレゼンテーションスライド内のテキストからハイパーリンクを削除する方法を示しています：

```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);
	for (IShape shape : slide.getShapes())
	{
		IAutoShape autoShape = (IAutoShape)shape;
		if (autoShape != null)
		{
			for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs())
			{
				for (IPortion portion : paragraph.getPortions())
				{
					portion.getPortionFormat().getHyperlinkManager().removeHyperlinkClick();
				}
			}
		}
	}

	pres.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

### **形状やフレームからハイパーリンクを削除する**

このJavaコードは、プレゼンテーションスライド内の形状からハイパーリンクを削除する方法を示しています： 

```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);
	for (IShape shape : slide.getShapes())
	{
		shape.getHyperlinkManager().removeHyperlinkClick();
	}
	pres.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **可変ハイパーリンク**

[Hyperlink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Hyperlink)クラスは可変です。このクラスを使用すると、これらのプロパティの値を変更できます：

- [IHyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlink#setTargetFrame-java.lang.String-)
- [IHyperlink.setTooltip(String value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlink#setTooltip-java.lang.String-)
- [IHyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlink#setHistory-boolean-)
- [IHyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlink#setHighlightClick-boolean-)
- [IHyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlink#setStopSoundOnClick-boolean-)

コードスニペットは、スライドにハイパーリンクを追加し、そのツールチップを後で編集する方法を示しています：

```java
Presentation pres = new Presentation();
try {
	IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.addTextFrame("Aspose: File Format APIs");

	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat(); 
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setTooltip("70%以上のフォーチュン100企業がAspose APIを信頼しています");
	portionFormat.setFontHeight(32);

	pres.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **IHyperlinkQueriesでサポートされているプロパティ**

リンクが定義されているプレゼンテーション、スライド、またはテキストから[IHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlinkQueries)にアクセスできます。

- [IPresentation.getHyperlinkQueries()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentation#getHyperlinkQueries--)
- [IBaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getHyperlinkQueries--)
- [ITextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame#getHyperlinkQueries--)

[IHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlinkQueries)クラスはこれらのメソッドおよびプロパティをサポートします：

- [IHyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlinkQueries#getHyperlinkClicks--)
- [IHyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlinkQueries#getHyperlinkMouseOvers--)
- [IHyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlinkQueries#getAnyHyperlinks--)
- [IHyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlinkQueries#removeAllHyperlinks--)