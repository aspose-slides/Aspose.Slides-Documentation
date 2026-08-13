---
title: 在 Java 中管理演示文稿超链接
linktitle: 管理超链接
type: docs
weight: 20
url: /zh/java/manage-hyperlinks/
keywords:
- 添加 URL
- 添加超链接
- 创建超链接
- 格式化超链接
- 删除超链接
- 更新超链接
- 文本超链接
- 幻灯片超链接
- 形状超链接
- 图像超链接
- 视频超链接
- 可变超链接
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "轻松使用 Aspose.Slides for Java 在 PowerPoint 和 OpenDocument 演示文稿中管理超链接——在几分钟内提升互动性和工作流程。"
---
## **介绍**

超链接是对对象、数据或某个位置的引用。这些是 PowerPoint 演示文稿中常见的超链接：

* 文本、形状或媒体中的网站链接
* 幻灯片链接

Aspose.Slides for Java 允许您在演示文稿中执行许多与超链接相关的任务。

{{% alert color="info" %}} 
您可能想查看 Aspose 简单的，[免费在线 PowerPoint 编辑器](https://products.aspose.app/slides/zh/editor)。
{{% /alert %}} 

## **添加 URL 超链接**

### **向文本添加 URL 超链接**

此 Java 代码演示了如何向文本添加网站超链接：

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

### **向形状或框架添加 URL 超链接**

此 Java 示例代码演示了如何向形状添加网站超链接：

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

### **向媒体添加 URL 超链接**

Aspose.Slides 允许您向图像、音频和视频文件添加超链接。

此示例代码演示了如何向**图像**添加超链接：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // 将图像添加到演示文稿
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
	// 基于先前添加的图像在第 1 张幻灯片上创建图片框
	IPictureFrame pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pictureFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	pictureFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

此示例代码演示了如何向**音频文件**添加超链接：

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

此示例代码演示了如何向**视频**添加超链接：

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

{{% alert title="提示" color="info" %}} 
您可能想查看 *[管理 OLE](/slides/zh/java/manage-ole/)*。
{{% /alert %}}

## **使用超链接创建目录**

由于超链接可以引用对象或位置，您可以使用它们创建目录。

此示例代码演示了如何使用超链接创建目录：

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

## **格式化超链接**

### **颜色**

通过 [IHyperlink](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IHyperlink) 接口中的 [ColorSource](https://reference.aspose.com/slides/zh/java/com.aspose.slides/Hyperlink#setColorSource-int-) 属性，您可以为超链接设置颜色，也可以从超链接获取颜色信息。此功能首次在 PowerPoint 2019 中引入，因此对旧版本 PowerPoint 无效。

此示例代码演示了在同一幻灯片上添加不同颜色超链接的操作：

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

## **从演示文稿中删除超链接**

### **从文本中删除超链接**

此 Java 代码演示了如何从演示文稿幻灯片中的文本删除超链接：

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

### **从形状或框架中删除超链接**

此 Java 代码演示了如何从演示文稿幻灯片中的形状删除超链接：

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

## **可变超链接**

[Hyperlink](https://reference.aspose.com/slides/zh/java/com.aspose.slides/Hyperlink) 类是可变的。使用此类，您可以修改以下属性的值：

- [IHyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IHyperlink#setTargetFrame-java.lang.String-)
- [IHyperlink.setTooltip(String value)](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IHyperlink#setTooltip-java.lang.String-)
- [IHyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IHyperlink#setHistory-boolean-)
- [IHyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IHyperlink#setHighlightClick-boolean-)
- [IHyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IHyperlink#setStopSoundOnClick-boolean-)

以下代码片段演示了如何向幻灯片添加超链接并随后编辑其提示文本：

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

	// 更改已添加的超链接的提示文字
	portionFormat.getHyperlinkClick().setTooltip("Aspose: the File Format APIs");

	pres.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **IHyperlinkQueries 支持的属性**

您可以从演示文稿、幻灯片或定义了超链接的文本中访问 [IHyperlinkQueries](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IHyperlinkQueries)。

- [IPresentation.getHyperlinkQueries()](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IPresentation#getHyperlinkQueries--)
- [IBaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IBaseSlide#getHyperlinkQueries--)
- [ITextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ITextFrame#getHyperlinkQueries--)

[IHyperlinkQueries](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IHyperlinkQueries) 类支持以下方法和属性：

- [IHyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IHyperlinkQueries#getHyperlinkClicks--)
- [IHyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IHyperlinkQueries#getHyperlinkMouseOvers--)
- [IHyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IHyperlinkQueries#getAnyHyperlinks--)
- [IHyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IHyperlinkQueries#removeAllHyperlinks--)

## **常见问题解答**

### 如何在内部导航时不仅定位到幻灯片，还定位到“章节”或章节的第一张幻灯片？

PowerPoint 中的章节是幻灯片的分组；导航技术上针对特定幻灯片。若要“导航到章节”，通常链接到该章节的第一张幻灯片。

### 能否将超链接附加到母版幻灯片元素，使其在所有幻灯片上都有效？

可以。母版幻灯片和布局元素支持超链接。这些链接会出现在子幻灯片上，并在放映期间可点击。

### 导出为 PDF、HTML、图像或视频时超链接会保留吗？

在 [PDF](/slides/zh/java/convert-powerpoint-to-pdf/) 和 [HTML](/slides/zh/java/convert-powerpoint-to-html/) 中会保留——链接通常会被保持。导出为 [图像](/slides/zh/java/convert-powerpoint-to-png/) 和 [视频](/slides/zh/java/convert-powerpoint-to-video/) 时，由于这些格式的本质（栅格帧/视频不支持超链接），点击功能将不会保留。