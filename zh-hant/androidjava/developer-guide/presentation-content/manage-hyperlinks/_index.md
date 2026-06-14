---
title: 在 Android 上管理簡報超連結
linktitle: 管理超連結
type: docs
weight: 20
url: /zh-hant/androidjava/manage-hyperlinks/
keywords:
- 新增 URL
- 新增 超連結
- 建立 超連結
- 格式化 超連結
- 移除 超連結
- 更新 超連結
- 文字 超連結
- 投影片 超連結
- 圖形 超連結
- 圖片 超連結
- 影片 超連結
- 可變 超連結
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java，輕鬆管理 PowerPoint 與 OpenDocument 簡報中的超連結——在數分鐘內提升互動性與工作流程。"
---
## **簡介**

超連結是對物件、資料或某處位置的參照。以下是 PowerPoint 簡報中常見的超連結：

* 文字、形狀或媒體內的網站連結
* 投影片連結

Aspose.Slides for Android via Java 讓您在簡報中執行許多與超連結相關的操作。

{{% alert color="primary" %}} 
您可能想查看 Aspose 的簡易、[免費線上 PowerPoint 編輯器。](https://products.aspose.app/slides/zh-hant/editor)
{{% /alert %}} 

## **新增 URL 超連結**

### **新增 URL 超連結到文字**

此 Java 程式碼示範如何將網站超連結新增至文字：

```java
Presentation presentation = new Presentation();
try {
	IAutoShape shape1 = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.addTextFrame("Aspose: File Format APIs");
	
	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat(); 
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
	portionFormat.setFontHeight(32);

	presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
	if (presentation != null) presentation.dispose();
}
```

### **新增 URL 超連結到形狀或框架**

此範例程式碼示範如何將網站超連結新增至形狀：

```java
Presentation pres = new Presentation();
try {
	IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

	shape.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	shape.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

### **新增 URL 超連結到媒體**

Aspose.Slides 允許您為影像、音訊與視訊檔案新增超連結。

此範例程式碼示範如何為 **影像** 新增超連結：

```java
Presentation pres = new Presentation();
try {
	// 新增影像至簡報
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
    picture = pres.getImages().addImage(picture);
    } finally {
          if (image != null) image.dispose();
    }
	// 在第 1 張投影片上建立圖片框，使用先前新增的影像
	IPictureFrame pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pictureFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	pictureFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

此範例程式碼示範如何為 **音訊檔案** 新增超連結：

```java
Presentation pres = new Presentation();
try {
	IAudio audio = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("audio.mp3")));
	IAudioFrame audioFrame = pres.getSlides().get_Item(0).getShapes().addAudioFrameEmbedded(10, 10, 100, 100, audio);

	audioFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	audioFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

此範例程式碼示範如何為 **視訊** 新增超連結：

```java
Presentation pres = new Presentation();
try {
	IVideo video = pres.getVideos().addVideo(Files.readAllBytes(Paths.get("video.avi")));
	IVideoFrame videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video);

	videoFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	videoFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

{{%  alert  title="Tip"  color="primary"  %}} 
您可能想查看 *[管理 OLE](/slides/zh-hant/androidjava/manage-ole/)*。
{{% /alert %}}

## **使用超連結建立目錄**

由於超連結可用於添加對物件或位置的參照，您可以利用它們建立目錄。

此範例程式碼示範如何使用超連結建立目錄：

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
	paragraph.setText("Title of slide 2 .......... ");

	Portion linkPortion = new Portion();
	linkPortion.setText("Page 2");
	linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);

	paragraph.getPortions().add(linkPortion);
	contentTable.getTextFrame().getParagraphs().add(paragraph);

	pres.save("link_to_slide.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **格式化超連結**

### **顏色**

使用介面 [IHyperlink](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IHyperlink) 中的 [ColorSource](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Hyperlink#setColorSource-int-) 屬性，您可以設定超連結的顏色，也可以取得超連結的顏色資訊。此功能首次在 PowerPoint 2019 中引入，因此屬性變更不適用於較舊的 PowerPoint 版本。

此範例程式碼示範在同一投影片上新增不同顏色的超連結：

```java
Presentation pres = new Presentation();
try {
	IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
	shape1.addTextFrame("This is a sample of colored hyperlink.");
	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat);
	portionFormat.getFillFormat().setFillType(FillType.Solid);
	portionFormat.getFillFormat().getSolidFillColor().setColor(Color.RED);

	IAutoShape shape2 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
	shape2.addTextFrame("This is a sample of usual hyperlink.");
	shape2.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

	pres.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **從簡報中移除超連結**

### **從文字中移除超連結**

此 Java 程式碼示範如何移除投影片中文字的超連結：

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

### **從形狀或框架中移除超連結**

此 Java 程式碼示範如何移除投影片中形狀的超連結：

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

## **可變超連結**

[Hyperlink](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Hyperlink) 類別是可變的。使用此類別，您可以變更以下屬性的值：

- [IHyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IHyperlink#setTargetFrame-java.lang.String-)
- [IHyperlink.setTooltip(String value)](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IHyperlink#setTooltip-java.lang.String-)
- [IHyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IHyperlink#setHistory-boolean-)
- [IHyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IHyperlink#setHighlightClick-boolean-)
- [IHyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IHyperlink#setStopSoundOnClick-boolean-)

此程式碼片段示範如何在投影片中新增超連結，並稍後編輯其工具提示：

```java
Presentation pres = new Presentation();
try {
	IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.addTextFrame("Aspose: File Format APIs");

	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat(); 
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
	portionFormat.setFontHeight(32);

	pres.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **IHyperlinkQueries 支援的屬性**

您可以從簡報、投影片或定義了超連結的文字中存取 [IHyperlinkQueries](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IHyperlinkQueries)。

- [IPresentation.getHyperlinkQueries()](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IPresentation#getHyperlinkQueries--)
- [IBaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IBaseSlide#getHyperlinkQueries--)
- [ITextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ITextFrame#getHyperlinkQueries--)

[IHyperlinkQueries](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IHyperlinkQueries) 類別支援以下方法與屬性：

- [IHyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IHyperlinkQueries#getHyperlinkClicks--)
- [IHyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IHyperlinkQueries#getHyperlinkMouseOvers--)
- [IHyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IHyperlinkQueries#getAnyHyperlinks--)
- [IHyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IHyperlinkQueries#removeAllHyperlinks--)

## **常見問題**

**如何建立不僅指向投影片，而是指向「章節」或章節第一張投影片的內部導覽？**

PowerPoint 中的章節是投影片的分組；導覽在技術上仍針對特定投影片。若要「導覽至章節」，通常會連結至該章節的第一張投影片。

**我可以將超連結附加到母片元素，使其在所有投影片上都有效嗎？**

可以。母片與版面配置元素支援超連結。此類連結會出現在子投影片上，並在簡報播放時可點擊。

**匯出為 PDF、HTML、圖像或視訊時，超連結會被保留嗎？**

在 [PDF](/slides/zh-hant/androidjava/convert-powerpoint-to-pdf/) 和 [HTML](/slides/zh-hant/androidjava/convert-powerpoint-to-html/) 中，會保留連結；匯出為 [圖像](/slides/zh-hant/androidjava/convert-powerpoint-to-png/) 和 [視訊](/slides/zh-hant/androidjava/convert-powerpoint-to-video/) 時，因為這些格式本身不支援超連結，點擊功能將不會被保留。