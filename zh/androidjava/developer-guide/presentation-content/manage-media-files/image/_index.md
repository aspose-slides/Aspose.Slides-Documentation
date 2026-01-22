---
title: 在 Android 上优化演示文稿的图像管理
linktitle: 管理图像
type: docs
weight: 10
url: /zh/androidjava/image/
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
- Android
- Java
- Aspose.Slides
description: "通过 Aspose.Slides for Android via Java，简化 PowerPoint 和 OpenDocument 中的图像管理，优化性能并实现工作流自动化。"
---

## **幻灯片中的图像**

图像使演示文稿更具吸引力和趣味性。在 Microsoft PowerPoint 中，您可以将来自文件、互联网或其他位置的图片插入到幻灯片中。同样，Aspose.Slides 也允许您通过不同的方式向演示文稿的幻灯片中添加图像。

{{% alert  title="Tip" color="primary" %}} 

Aspose 提供免费转换器——[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) 和 [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)——让用户能够快速从图像创建演示文稿。 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

如果您想将图像作为框架对象添加——尤其是计划使用标准格式选项来更改其大小、添加效果等——请参阅 [Picture Frame](https://docs.aspose.com/slides/androidjava/picture-frame/)。 

{{% /alert %}} 

Aspose.Slides 支持对 JPEG、PNG、GIF 等常见格式的图像进行操作。

## **向幻灯片添加本地存储的图像**

您可以将计算机上的一张或多张图像添加到演示文稿的幻灯片中。下面的 Java 示例代码展示了如何向幻灯片添加图像：
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

如果要添加到幻灯片的图像在计算机上不可用，您可以直接从网络添加该图像。

下面的示例代码展示了如何在 Java 中将网络图像添加到幻灯片：
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

幻灯片母版是顶部幻灯片，用于存储和控制其下所有幻灯片的信息（主题、布局等）。因此，当您向幻灯片母版添加图像时，该图像会出现在该母版下的每一张幻灯片上。

下面的 Java 示例代码展示了如何向幻灯片母版添加图像：
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


## **将图像设为幻灯片背景**

您可能决定将图片用作特定幻灯片或多个幻灯片的背景。在这种情况下，请参阅 *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/androidjava/presentation-background/#setting-images-as-background-for-slides)*。

## **向演示文稿添加 SVG**

您可以使用属于 [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) 接口的 [addPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) 方法，将任意图像插入演示文稿。

创建基于 SVG 图像的图像对象可以按以下方式进行：

1. 创建 SvgImage 对象并将其插入 ImageShapeCollection
2. 从 ISvgImage 创建 PPImage 对象
3. 使用 IPPImage 接口创建 PictureFrame 对象

下面的示例代码展示了如何实现上述步骤，将 SVG 图像添加到演示文稿中：
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


## **将 SVG 转换为形状集合**

Aspose.Slides 将 SVG 转换为形状集合的功能类似于 PowerPoint 用于处理 SVG 图像的功能：

![PowerPoint Popup Menu](img_01_01.png)

该功能由 [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) 接口的一个 [addGroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) 方法的重载提供，该方法的第一个参数接受 [ISvgImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISvgImage) 对象。

下面的示例代码展示了如何使用上述方法将 SVG 文件转换为形状集合：
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

    // 将 SVG 图像转换为形状组并按幻灯片尺寸缩放
    presentation.getSlides().get_Item(0).getShapes().
            addGroupShape(svgImage, 0f, 0f, (float)slideSize.getWidth(), (float)slideSize.getHeight());

    // 以 PPTX 格式保存演示文稿
    presentation.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **将图像以 EMF 形式添加到幻灯片**

Aspose.Slides for Android via Java 允许您从 Excel 工作表生成 EMF 图像，并通过 Aspose.Cells 将这些图像作为 EMF 添加到幻灯片中。  

下面的示例代码展示了如何完成上述任务：
```java 
Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);
ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

//将工作簿保存到流
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

Aspose.Slides 让您能够替换存储在演示文稿图像集合中的图像（包括幻灯片形状使用的图像）。本节展示了更新集合中图像的几种方法。API 提供直接的方法来使用原始字节数据、[IImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/) 实例，或集合中已存在的其他图像来替换图像。

按照以下步骤操作：

1. 使用 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 类加载包含图像的演示文稿文件。  
2. 将新图像从文件加载到字节数组中。  
3. 使用字节数组将目标图像替换为新图像。  
4. 在第二种方法中，将图像加载到 [IImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/) 对象中，并使用该对象替换目标图像。  
5. 在第三种方法中，用演示文稿图像集合中已存在的图像替换目标图像。  
6. 将修改后的演示文稿写入为 PPTX 文件。  
```java
// 实例化表示演示文稿文件的 Presentation 类。
Presentation presentation = new Presentation("sample.pptx");
try {
    // 第一种方式。
    IImage imageData = Images.fromStream(new FileInputStream("image0.jpeg"));
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

使用 Aspose 免费的 [Text to GIF](https://products.aspose.app/slides/text-to-gif) 转换器，您可以轻松为文字添加动画、从文字创建 GIF 等。 

{{% /alert %}}

## **FAQ**

**插入后原始图像分辨率是否保持不变？**

是的。源像素得以保留，但最终显示效果取决于幻灯片上 [picture](/slides/zh/androidjava/picture-frame/) 的缩放方式以及保存时是否进行压缩。

**一次性在数十张幻灯片中替换相同徽标的最佳方法是什么？**

将徽标放在母版幻灯片或布局上，并在演示文稿的图像集合中替换它——更改会传播到所有使用该资源的元素。

**插入的 SVG 能否转换为可编辑的形状？**

可以。您可以将 SVG 转换为一组形状，随后各个部件即可使用标准形状属性进行编辑。

**如何一次性为多张幻灯片设置图片作为背景？**

在母版幻灯片或相应布局上 [将图像分配为背景](/slides/zh/androidjava/presentation-background/)，使用该母版/布局的所有幻灯片都会继承该背景。

**如何防止因大量图片导致演示文稿文件大小“膨胀”？**

复用单一图像资源而不是重复拷贝，选择合适的分辨率，保存时进行压缩，并在适当情况下将重复的图形放在母版上。