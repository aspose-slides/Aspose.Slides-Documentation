---
title: 使用 Java 优化演示文稿中的图像管理
linktitle: 管理图像
type: docs
weight: 10
url: /zh/java/image/
keywords:
- 添加图像
- 添加图片
- 添加位图
- 替换图像
- 替换图片
- 来自网络
- 背景
- 添加 PNG
- 添加 JPG
- 添加 SVG
- 添加 EMF
- 添加 WMF
- 添加 TIFF
- PowerPoint
- OpenDocument
- 演示文稿
- EMF
- SVG
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 简化 PowerPoint 和 OpenDocument 中的图像管理，优化性能并自动化工作流。"
---

## **演示文稿幻灯片中的图像**

图像使演示更加吸引人和有趣。在 Microsoft PowerPoint 中，您可以从文件、互联网或其他位置将图片插入幻灯片。同样，Aspose.Slides 允许您通过多种方式向演示文稿的幻灯片添加图像。

{{% alert  title="Tip" color="primary" %}} 
Aspose 提供免费的转换器—[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) 和 [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—让用户能够快速从图像创建演示文稿。 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
如果您想将图像添加为框架对象——尤其是计划使用标准格式选项来更改其大小、添加效果等——请参阅 [Picture Frame](https://docs.aspose.com/slides/java/picture-frame/)。 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
您可以操作涉及图像和 PowerPoint 演示文稿的输入/输出，以将图像从一种格式转换为另一种格式。请参阅以下页面：转换 [image to JPG](https://products.aspose.com/slides/java/conversion/image-to-jpg/); 转换 [JPG to image](https://products.aspose.com/slides/java/conversion/jpg-to-image/); 转换 [JPG to PNG](https://products.aspose.com/slides/java/conversion/jpg-to-png/)，转换 [PNG to JPG](https://products.aspose.com/slides/java/conversion/png-to-jpg/); 转换 [PNG to SVG](https://products.aspose.com/slides/java/conversion/png-to-svg/)，转换 [SVG to PNG](https://products.aspose.com/slides/java/conversion/svg-to-png/)。
{{% /alert %}}

Aspose.Slides 支持对这些常用格式的图像进行操作：JPEG、PNG、GIF 等。

## **将本地存储的图像添加到幻灯片**

您可以将计算机上的一个或多个图像添加到演示文稿的幻灯片中。以下 Java 示例代码演示了如何向幻灯片添加图像：
```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);
	    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
	slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```


## **从网络添加图像到幻灯片**

如果您想添加到幻灯片的图像在电脑上不可用，可以直接从网络添加该图像。

以下示例代码演示了如何在 Java 中将网络图像添加到幻灯片：
```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);

	URL imageUrl = new URL("[REPLACE WITH URL]");
	URLConnection connection = imageUrl.openConnection();
	InputStream inputStream = connection.getInputStream();

	ByteArrayOutputStream outputStream = new ByteArrayOutputStream();
	try {
		byte[] buffer = new byte[1024];
		int read;

		while ((read = inputStream.read(buffer, 0, buffer.length)) != -1)
			outputStream.write(buffer, 0, read);

		outputStream.flush();

		IPPImage image = pres.getImages().addImage(outputStream.toByteArray());
		slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
	} finally {
		if (inputStream != null) inputStream.close();
		outputStream.close();
	}

	pres.save("pres.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```


## **向幻灯片母版添加图像**

幻灯片母版是存储并控制其下所有幻灯片信息（主题、布局等）的顶层幻灯片。因此，将图像添加到幻灯片母版后，该图像会出现在该母版下的每一张幻灯片上。

以下 Java 示例代码演示了如何向幻灯片母版添加图像：
```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);
	IMasterSlide masterSlide = slide.getLayoutSlide().getMasterSlide();

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
	masterSlide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```


## **将图像设置为幻灯片背景**

您可能决定将图片用作特定幻灯片或多个幻灯片的背景。在这种情况下，您需要查看 *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/java/presentation-background/#setting-images-as-background-for-slides)*。

## **将 SVG 添加到演示文稿**

您可以使用属于 [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) 接口的 [addPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) 方法，将任意图像添加或插入到演示文稿中。

要基于 SVG 图像创建图像对象，可按如下方式操作：

1. 创建 SvgImage 对象以将其插入 ImageShapeCollection  
2. 从 ISvgImage 创建 PPImage 对象  
3. 使用 IPPImage 接口创建 PictureFrame 对象  

以下示例代码演示了如何实现上述步骤，将 SVG 图像添加到演示文稿中：
```java
// 实例化表示 PPTX 文件的 Presentation 类
Presentation pres = new Presentation();
try {
    String svgContent = new String(Files.readAllBytes(Paths.get("image.svg")));
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage ppImage = pres.getImages().addImage(svgImage);
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 
            ppImage.getWidth(), ppImage.getHeight(), ppImage);
    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **将 SVG 转换为一组形状**

Aspose.Slides 将 SVG 转换为一组形状的功能类似于 PowerPoint 处理 SVG 图像的功能：

![PowerPoint Popup Menu](img_01_01.png)

该功能由 [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) 接口的一个 overload 的 [addGroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) 方法提供，该方法将 [ISvgImage](https://reference.aspose.com/slides/java/com.aspose.slides/ISvgImage) 对象作为第一个参数。

以下示例代码演示了如何使用上述方法将 SVG 文件转换为一组形状：
```java
// 创建新的演示文稿
IPresentation presentation = new Presentation();
try {
    // 读取 SVG 文件内容
    byte[] svgContent = Files.readAllBytes(Paths.get("image.svg"));

    // 创建 SvgImage 对象
    ISvgImage svgImage = new SvgImage(svgContent);

    // 获取幻灯片尺寸
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // 将 SVG 图像转换为形状组并按幻灯片尺寸进行缩放
    presentation.getSlides().get_Item(0).getShapes().
            addGroupShape(svgImage, 0f, 0f, (float)slideSize.getWidth(), (float)slideSize.getHeight());

    // 以 PPTX 格式保存演示文稿
    presentation.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **将图像作为 EMF 添加到幻灯片**

Aspose.Slides for Java 允许您从 Excel 工作表生成 EMF 图像，并通过 Aspose.Cells 将这些图像以 EMF 形式添加到幻灯片中。

以下示例代码演示了如何完成上述任务：
```java
Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);
ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

//保存工作簿到流
SheetRender sr = new SheetRender(sheet, options);
Presentation pres = new Presentation();
try {
    pres.getSlides().removeAt(0);
    
    String EmfSheetName = "";
    for (int j = 0; j < sr.getPageCount(); j++)
    {
    
        EmfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, EmfSheetName);

        IPPImage picture;
        IImage image = Images.fromFile(EmfSheetName);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
        ISlide slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().getByType(SlideLayoutType.Blank));
        IShape m = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0,
					(float)pres.getSlideSize().getSize().getWidth(), 
					(float)pres.getSlideSize().getSize().getHeight(), 
					picture);
    }
    
    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **替换图像集合中的图像**

Aspose.Slides 让您可以替换存储在演示文稿图像集合中的图像（包括幻灯片形状使用的图像）。本节展示了几种更新集合中图像的方法。API 提供了直接使用原始字节数据、[IImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/) 实例或集合中已存在的另一图像来替换图像的简便方法。

按照以下步骤操作：

1. 使用 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 类加载包含图像的演示文稿文件。  
1. 将新图像从文件加载到字节数组中。  
1. 使用字节数组将目标图像替换为新图像。  
1. 在第二种方法中，将图像加载到 [IImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/) 对象中，并使用该对象替换目标图像。  
1. 在第三种方法中，将目标图像替换为演示文稿图像集合中已存在的图像。  
1. 将修改后的演示文稿写出为 PPTX 文件。  
```java
// 实例化表示演示文稿文件的 Presentation 类。
Presentation presentation = new Presentation("sample.pptx");
try {
    // 第一种方式。
    byte[] imageData = Files.readAllBytes(Paths.get("image0.jpeg"));
    IPPImage oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);
    
    // 第二种方式。
    IImage newImage = Images.fromFile("image1.png");
    oldImage = presentation.getImages().get_Item(1);
    oldImage.replaceImage(newImage);
    newImage.dispose();
    
    // 第三种方式。
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));
    
    // 将演示文稿保存到文件。
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


{{% alert title="Info" color="info" %}}
使用 Aspose 免费的 [Text to GIF](https://products.aspose.app/slides/text-to-gif) 转换器，您可以轻松为文本添加动画、从文本创建 GIF 等。 
{{% /alert %}}

## **常见问题**

**插入后原始图像分辨率是否保持不变？**

是的。源像素会被保留，但最终显示效果取决于幻灯片上 [picture](/slides/zh/java/picture-frame/) 的缩放方式以及保存时应用的压缩。

**一次性在数十张幻灯片上替换相同标志的最佳方法是什么？**

将标志放在母版幻灯片或布局上，并在演示文稿的图像集合中替换它——更新会传播到所有使用该资源的元素。

**插入的 SVG 能否转换为可编辑的形状？**

可以。您可以将 SVG 转换为一组形状，随后各个部件即可通过标准形状属性进行编辑。

**如何一次性将图片设置为多个幻灯片的背景？**

在母版幻灯片或相应布局上 [Assign the image as the background](/slides/zh/java/presentation-background/)，使用该母版/布局的所有幻灯片都会继承该背景。

**如何防止由于大量图片导致演示文稿体积“膨胀”？**

重复使用单一图像资源而非复制，选择合适的分辨率，保存时进行压缩，并在适当的情况下将重复图形放置在母版上。