---
title: 图像
type: docs
weight: 10
url: /java/image/
description: 使用 Java 在 PowerPoint 演示文稿的幻灯片中处理图像。从磁盘或网络添加图像到 PowerPoint 幻灯片。使用 Java 将图像添加到幻灯片母版或作为幻灯片背景。使用 Java 将 SVG 添加到 PowerPoint 演示文稿。使用 Java 将 SVG 转换为 PowerPoint 中的形状。使用 Java 将图像作为 EMF 添加到幻灯片中。
---

## **演示文稿中的幻灯片图像**

图像使演示文稿更具吸引力和趣味性。在 Microsoft PowerPoint 中，您可以从文件、互联网上或其他位置插入图片到幻灯片。类似地，Aspose.Slides 允许您通过不同的程序将图像添加到演示文稿的幻灯片中。

{{% alert  title="提示" color="primary" %}} 

Aspose 提供免费的转换器—[JPEG 到 PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) 和 [PNG 到 PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—使用户可以快速从图像创建演示文稿。 

{{% /alert %}} 

{{% alert title="信息" color="info" %}}

如果您想将图像作为框架对象添加，特别是如果您打算使用标准格式选项来更改其大小、添加效果等—请参见 [图片框](https://docs.aspose.com/slides/java/picture-frame/)。 

{{% /alert %}} 

{{% alert title="注意" color="warning" %}}

您可以操作与图像和 PowerPoint 演示文稿相关的输入/输出操作，以将图像从一种格式转换为另一种格式。请查看这些页面：转换 [图像到 JPG](https://products.aspose.com/slides/java/conversion/image-to-jpg/); 转换 [JPG 到图像](https://products.aspose.com/slides/java/conversion/jpg-to-image/); 转换 [JPG 到 PNG](https://products.aspose.com/slides/java/conversion/jpg-to-png/)，转换 [PNG 到 JPG](https://products.aspose.com/slides/java/conversion/png-to-jpg/); 转换 [PNG 到 SVG](https://products.aspose.com/slides/java/conversion/png-to-svg/)，转换 [SVG 到 PNG](https://products.aspose.com/slides/java/conversion/svg-to-png/)。

{{% /alert %}}

Aspose.Slides 支持处理这些流行格式的图像：JPEG、PNG、GIF 等。

## **将本地存储的图像添加到幻灯片**

您可以将一张或多张计算机上的图像添加到演示文稿中的幻灯片上。以下 Java 示例代码展示了如何将图像添加到幻灯片：

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

## **从网络向幻灯片添加图像**

如果您想要添加到幻灯片的图像在您的计算机上不可用，您可以直接从网络添加图像。

以下示例代码展示了如何在 Java 中从网络向幻灯片添加图像：

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

幻灯片母版是存储和控制信息（主题、布局等）的顶层幻灯片，关于其下的所有幻灯片。因此，当您向幻灯片母版添加图像时，该图像将出现在该幻灯片母版下的每个幻灯片上。

以下 Java 示例代码展示了如何向幻灯片母版添加图像：

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

## **将图像添加为幻灯片背景**

您可以决定将图片用作特定幻灯片或多个幻灯片的背景。在这种情况下，您需要查看 *[将图像设置为幻灯片背景](https://docs.aspose.com/slides/java/presentation-background/#setting-images-as-background-for-slides)*。

## **将 SVG 添加到演示文稿**
您可以通过使用属于 [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) 接口的 [addPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) 方法将任何图像添加或插入到演示文稿中。

要基于 SVG 图像创建图像对象，您可以按照以下方式操作：

1. 创建 SvgImage 对象以将其插入 ImageShapeCollection
2. 从 ISvgImage 创建 PPImage 对象
3. 使用 IPPImage 接口创建 PictureFrame 对象

以下示例代码展示了如何实现上述步骤将 SVG 图像添加到演示文稿中：

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
Aspose.Slides 将 SVG 转换为一组形状的功能类似于用于处理 SVG 图像的 PowerPoint 功能：

![PowerPoint 弹出菜单](img_01_01.png)

该功能由 [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) 接口的 [addGroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) 方法的一个重载提供，该方法以 [ISvgImage](https://reference.aspose.com/slides/java/com.aspose.slides/ISvgImage) 对象作为第一个参数。

以下示例代码展示了如何使用上述方法将 SVG 文件转换为一组形状：

```java 
// 创建新演示文稿
IPresentation presentation = new Presentation();
try {
    // 读取 SVG 文件内容
    byte[] svgContent = Files.readAllBytes(Paths.get("image.svg"));

    // 创建 SvgImage 对象
    ISvgImage svgImage = new SvgImage(svgContent);

    // 获取幻灯片大小
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // 将 SVG 图像转换为形状组，并将其缩放到幻灯片大小
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
Aspose.Slides for Java 允许您从 Excel 工作表生成 EMF 图像，并使用 Aspose.Cells 将图像作为 EMF 添加到幻灯片。

以下示例代码展示了如何执行上述任务：

```java 
Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);
ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

//将工作簿保存到流中
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

{{% alert title="信息" color="info" %}}

使用 Aspose 免费 [文本到 GIF](https://products.aspose.app/slides/text-to-gif) 转换器，您可以轻松地为文本添加动画、从文本创建 GIF 等。

{{% /alert %}}