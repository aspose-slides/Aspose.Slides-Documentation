---
title: 在 Java 中管理簡報超連結
linktitle: 管理超連結
type: docs
weight: 20
url: /zh-hant/java/manage-hyperlinks/
keywords:
- 新增 URL
- 新增超連結
- 建立超連結
- 格式化超連結
- 移除超連結
- 更新超連結
- 文字超連結
- 投影片超連結
- 圖形超連結
- 圖片超連結
- 影片超連結
- 可變超連結
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 輕鬆管理 PowerPoint 和 OpenDocument 簡報中的超連結，僅需幾分鐘即可提升互動性與工作流程。"
---
## **簡介**

超連結是對某個物件、資料或位置的參照。以下是在 PowerPoint 簡報中常見的超連結：

* 文字、圖形或多媒體內的網站連結
* 投影片連結

Aspose.Slides for Java 允許您在簡報中執行許多與超連結相關的工作。 

{{% alert color="info" %}} 
您可能想看看 Aspose 簡易的[免費線上 PowerPoint 編輯器](https://products.aspose.app/slides/zh-hant/editor)。
{{% /alert %}} 

## **新增 URL 超連結**

### **將 URL 超連結新增至文字**

以下 Java 程式碼示範如何將網站超連結新增至文字：

```java
import com.aspose.slides.*;

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

### **將 URL 超連結新增至圖形或框架**

以下 Java 範例程式碼示範如何將網站超連結新增至圖形：

```java
import com.aspose.slides.*;

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

### **將 URL 超連結新增至媒體**

Aspose.Slides 允許您將超連結新增至圖片、音訊和影片檔案。 

以下程式碼示範如何將超連結新增至**圖片**：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
	// 新增圖片至簡報
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
	// 建立圖片框架於投影片 1，根據先前加入的圖片
	IPictureFrame pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pictureFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	pictureFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

以下程式碼示範如何將超連結新增至**音訊檔案**：

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

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

以下程式碼示範如何將超連結新增至**影片**：

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

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

{{%  alert  title="Tip"  color="info"  %}} 
您可能想看看 *[管理 OLE](/slides/zh-hant/java/manage-ole/)*。
{{% /alert %}}

## **使用超連結建立目錄**

由於超連結可用於加入對物件或位置的參照，您可以利用它們建立目錄。 

以下範例程式碼示範如何使用超連結建立目錄：

```java
import com.aspose.slides.*;
import java.awt.Color;

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

透過 [ColorSource](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Hyperlink#setColorSource-int-) 屬性於 [IHyperlink](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IHyperlink) 介面，您可以設定超連結的顏色，亦可從超連結取得顏色資訊。此功能首次在 PowerPoint 2019 中推出，因此屬性相關的變更不適用於較舊的 PowerPoint 版本。

以下範例程式碼示範在同一投影片中加入不同顏色的超連結的操作：

```java
import com.aspose.slides.*;
import java.awt.Color;

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

以下 Java 程式碼示範如何從簡報投影片的文字中移除超連結：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
try {
	ISlide slide = pres.getSlides().get_Item(0);
	for (IShape shape : slide.getShapes())
	{
		if (shape instanceof IAutoShape)
		{
			IAutoShape autoShape = (IAutoShape)shape;
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

### **從圖形或框架中移除超連結**

以下 Java 程式碼示範如何從簡報投影片的圖形中移除超連結：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
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

[Hyperlink](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Hyperlink) 類別是可變的。使用此類別，您可以變更以下屬性的值：

- [IHyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IHyperlink#setTargetFrame-java.lang.String-)
- [IHyperlink.setTooltip(String value)](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IHyperlink#setTooltip-java.lang.String-)
- [IHyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IHyperlink#setHistory-boolean-)
- [IHyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IHyperlink#setHighlightClick-boolean-)
- [IHyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IHyperlink#setStopSoundOnClick-boolean-)

以下程式碼片段示範如何將超連結新增至投影片，並之後編輯其提示文字：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
	IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.addTextFrame("Aspose: File Format APIs");

	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat(); 
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
	portionFormat.setFontHeight(32);

	// 更改已新增超連結的提示文字
	portionFormat.getHyperlinkClick().setTooltip("Aspose: the File Format APIs");

	pres.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **IHyperlinkQueries 支援的屬性**

您可以從定義了超連結的簡報、投影片或文字取得 [IHyperlinkQueries](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IHyperlinkQueries)。 

- [IPresentation.getHyperlinkQueries()](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IPresentation#getHyperlinkQueries--)
- [IBaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IBaseSlide#getHyperlinkQueries--)
- [ITextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ITextFrame#getHyperlinkQueries--)

[IHyperlinkQueries](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IHyperlinkQueries) 類別支援以下方法與屬性： 

- [IHyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IHyperlinkQueries#getHyperlinkClicks--)
- [IHyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IHyperlinkQueries#getHyperlinkMouseOvers--)
- [IHyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IHyperlinkQueries#getAnyHyperlinks--)
- [IHyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IHyperlinkQueries#removeAllHyperlinks--)

## **常見問題**

### 如何僅以內部導覽至投影片之外，也能導覽至「區段」或區段的第一張投影片？

PowerPoint 中的區段是投影片的分組；導覽技術上是針對特定投影片。若要「導覽至區段」，通常會連結至該區段的第一張投影片。

### 我可以將超連結附加於母片元素，使其於所有投影片上皆可使用嗎？

可以。母片與版面配置元素支援超連結。此類連結會出現在子投影片上，且在投影片放映時可點擊。

### 匯出為 PDF、HTML、圖片或影片時，超連結會被保留嗎？

在 [PDF](/slides/zh-hant/java/convert-powerpoint-to-pdf/) 與 [HTML](/slides/zh-hant/java/convert-powerpoint-to-html/) 中，會保留連結。匯出為 [圖片](/slides/zh-hant/java/convert-powerpoint-to-png/) 與 [影片](/slides/zh-hant/java/convert-powerpoint-to-video/) 時，因這些格式（點陣框架/影片）不支援超連結，點擊功能將不會保留。