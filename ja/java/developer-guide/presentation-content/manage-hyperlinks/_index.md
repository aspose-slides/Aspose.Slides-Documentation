---
title: ハイパーリンクの管理
type: docs
weight: 20
url: /java/manage-hyperlinks/
keywords: "PowerPoint ハイパーリンク, テキスト ハイパーリンク, スライド ハイパーリンク, 図形 ハイパーリンク, 画像 ハイパーリンク, 動画 ハイパーリンク, Java"
description: "JavaでPowerPointプレゼンテーションにハイパーリンクを追加する方法"
---

ハイパーリンクは、オブジェクトやデータ、あるいは何かの中の場所への参照です。これらはPowerPointプレゼンテーションで一般的なハイパーリンクです：

* テキスト、図形、またはメディア内のウェブサイトへのリンク
* スライドへのリンク

Aspose.Slides for Javaを使用すると、プレゼンテーション内のハイパーリンクに関する多くのタスクを実行できます。

{{% alert color="primary" %}} 

Asposeのシンプルな[無料オンラインPowerPointエディタ](https://products.aspose.app/slides/editor)をチェックしてみてください。

{{% /alert %}} 

## **URLハイパーリンクの追加**

### **テキストへのURLハイパーリンクの追加**

このJavaコードは、テキストにウェブサイトのハイパーリンクを追加する方法を示しています：

```java
Presentation presentation = new Presentation();
try {
	IAutoShape shape1 = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.addTextFrame("Aspose: ファイル形式API");
	
	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat(); 
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setTooltip("70% 以上のフォーチュン100企業がAspose APIを信頼しています");
	portionFormat.setFontHeight(32);

	presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
	if (presentation != null) presentation.dispose();
}
```

### **図形やフレームへのURLハイパーリンクの追加**

このサンプルコードは、図形にウェブサイトのハイパーリンクを追加する方法を示しています：

```java
Presentation pres = new Presentation();
try {
	IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

	shape.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	shape.getHyperlinkClick().setTooltip("70% 以上のフォーチュン100企業がAspose APIを信頼しています");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

### **メディアへのURLハイパーリンクの追加**

Aspose.Slidesを使用すると、画像、音声、および動画ファイルにハイパーリンクを追加できます。

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
	// 以前に追加した画像に基づいてスライド1に画像フレームを作成
	IPictureFrame pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pictureFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	pictureFrame.getHyperlinkClick().setTooltip("70% 以上のフォーチュン100企業がAspose APIを信頼しています");

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
	audioFrame.getHyperlinkClick().setTooltip("70% 以上のフォーチュン100企業がAspose APIを信頼しています");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

このサンプルコードは、**動画**にハイパーリンクを追加する方法を示しています：

```java
Presentation pres = new Presentation();
try {
	IVideo video = pres.getVideos().addVideo(Files.readAllBytes(Paths.get("video.avi")));
	IVideoFrame videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video);

	videoFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	videoFrame.getHyperlinkClick().setTooltip("70% 以上のフォーチュン100企業がAspose APIを信頼しています");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

{{%  alert  title="ヒント"  color="primary"  %}} 

* [OLEの管理](/slides/java/manage-ole/)を確認してください。

{{% /alert %}}

## **ハイパーリンクを使用した目次の作成**

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

## **ハイパーリンクのフォーマット**

### **色**

[ColorSource](https://reference.aspose.com/slides/java/com.aspose.slides/Hyperlink#setColorSource-int-)プロパティを使用して、[IHyperlink](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlink)インターフェースのハイパーリンクの色を設定したり、ハイパーリンクから色の情報を取得したりできます。この機能は、PowerPoint 2019で最初に導入されたため、プロパティに関する変更は古いPowerPointバージョンには適用されません。

このサンプルコードは、異なる色のハイパーリンクを同じスライドに追加する操作を示しています：

```java
Presentation pres = new Presentation();
try {
	IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
	shape1.addTextFrame("これは色付きハイパーリンクのサンプルです。");
	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat);
	portionFormat.getFillFormat().setFillType(FillType.Solid);
	portionFormat.getFillFormat().getSolidFillColor().setColor(Color.RED);

	IAutoShape shape2 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
	shape2.addTextFrame("これは一般的なハイパーリンクのサンプルです。");
	shape2.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

	pres.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **プレゼンテーションからハイパーリンクを削除する**

### **テキストからハイパーリンクを削除する**

このJavaコードは、プレゼンテーションスライドのテキストからハイパーリンクを削除する方法を示しています：

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

### **図形やフレームからハイパーリンクを削除する**

このJavaコードは、プレゼンテーションスライドの図形からハイパーリンクを削除する方法を示しています： 

```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);
	for (IShape shape : slide.getShapes())
	{
		shape.getHyperlinkManager().removeHyperlinkClick();
	}
	pres.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
}finally {
	if (pres != null) pres.dispose();
}
```

## **ミュータブルハイパーリンク**

[Hyperlink](https://reference.aspose.com/slides/java/com.aspose.slides/Hyperlink)クラスはミュータブルです。このクラスを使用すると、これらのプロパティの値を変更できます：

- [IHyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlink#setTargetFrame-java.lang.String-)
- [IHyperlink.setTooltip(String value)](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlink#setTooltip-java.lang.String-)
- [IHyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlink#setHistory-boolean-)
- [IHyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlink#setHighlightClick-boolean-)
- [IHyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlink#setStopSoundOnClick-boolean-)

このコードスニペットは、スライドにハイパーリンクを追加し、後でそのツールトップを編集する方法を示しています：

```java
Presentation pres = new Presentation();
try {
	IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.addTextFrame("Aspose: ファイル形式API");

	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat(); 
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setTooltip("70% 以上のフォーチュン100企業がAspose APIを信頼しています");
	portionFormat.setFontHeight(32);

	pres.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **IHyperlinkQueriesでサポートされているプロパティ**

ハイパーリンクが定義されているプレゼンテーション、スライド、またはテキストから[IHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlinkQueries)にアクセスできます。

- [IPresentation.getHyperlinkQueries()](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentation#getHyperlinkQueries--)
- [IBaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getHyperlinkQueries--)
- [ITextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame#getHyperlinkQueries--)

[IHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlinkQueries)クラスは、これらのメソッドとプロパティをサポートしています：

- [IHyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlinkQueries#getHyperlinkClicks--)
- [IHyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlinkQueries#getHyperlinkMouseOvers--)
- [IHyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlinkQueries#getAnyHyperlinks--)
- [IHyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlinkQueries#removeAllHyperlinks--)