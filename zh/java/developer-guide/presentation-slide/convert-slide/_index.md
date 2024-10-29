---
title: 转换幻灯片
type: docs
weight: 35
url: /zh/java/convert-slide/
keywords: 
- 将幻灯片转换为图像
- 将幻灯片导出为图像
- 将幻灯片保存为图像
- 幻灯片转图像
- 幻灯片转PNG
- 幻灯片转JPEG
- 幻灯片转位图
- Java
- Aspose.Slides for Java
description: "在Java中将PowerPoint幻灯片转换为图像（位图、PNG或JPG）"
---

Aspose.Slides for Java允许您将幻灯片（在演示文稿中）转换为图像。支持的图像格式包括：BMP、PNG、JPG（JPEG）、GIF等。

要将幻灯片转换为图像，请执行以下操作：

1. 首先，通过以下方式设置转换参数和要转换的幻灯片对象：
   * 使用[ITiffOptions](https://reference.aspose.com/slides/java/com.aspose.slides/ITiffOptions)接口或
   * 使用[IRenderingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/IRenderingOptions)接口。

2. 其次，通过使用[getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-java.awt.Dimension-)方法将幻灯片转换为图像。

## **关于位图和其他图像格式**

在Java中，[Images](https://reference.aspose.com/slides/java/com.aspose.slides/Images)是一个对象，允许您处理通过像素数据定义的图像。您可以使用该类的实例将图像保存为多种格式（JPG、PNG等）。

{{% alert title="信息" color="info" %}}

Aspose最近开发了一个在线[文本到GIF](https://products.aspose.app/slides/text-to-gif)转换器。

{{% /alert %}}

## **将幻灯片转换为位图并以PNG格式保存图像**

以下Java代码展示了如何将演示文稿的第一张幻灯片转换为位图对象，然后以PNG格式保存该图像：

``` java 
Presentation pres = new Presentation("Presentation.pptx");
try {
    // 将演示文稿中的第一张幻灯片转换为Images对象
    IImage slideImage = pres.getSlides().get_Item(0).getImage();

	// 以PNG格式保存图像
	try {
        // 在磁盘上保存图像。
         slideImage.save("Slide_0.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

该示例代码展示了如何使用[getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-java.awt.Dimension-)方法将演示文稿的第一张幻灯片转换为位图对象：

``` java 
Presentation pres = new Presentation("Presentation.pptx");
try {
	// 获取演示文稿幻灯片大小
	Dimension2D slideSize = new Dimension((int) slideSize.getWidth(), (int) slideSize.getHeight());

	// 创建一个具有幻灯片大小的Images
    IImage slideImage = sld.getImage(new RenderingOptions(), slideSize);
    try {
         // 在磁盘上保存图像。
          slideImage.save("Slide_0.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="提示" color="primary" %}} 

您可以将幻灯片转换为Images对象，然后在某处直接使用该对象。或者，您可以将幻灯片转换为Images并以JPEG或其他您喜欢的格式保存图像。

{{% /alert %}}  

## **使用自定义大小转换幻灯片为图像**

您可能需要获取特定大小的图像。使用[getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-)方法的重载，您可以将幻灯片转换为具有特定尺寸（长度和宽度）的图像。

该示例代码展示了如何使用Java中的[getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-java.awt.Dimension-)方法进行提议的转换：

``` java 
Presentation pres = new Presentation("Presentation.pptx");
try {
    // 将演示文稿中的第一张幻灯片转换为具有指定大小的位图
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1820, 1040));
	
	// 保存图像为JPEG格式
	try {
         // 在磁盘上保存图像。
          slideImage.save("Slide_0.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **将带注释和评论的幻灯片转换为图像**

某些幻灯片包含注释和评论。

Aspose.Slides提供了两个接口——[ITiffOptions](https://reference.aspose.com/slides/java/com.aspose.slides/ITiffOptions)和[IRenderingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/IRenderingOptions)——允许您控制将演示文稿幻灯片渲染为图像。这两个接口都包含[INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/INotesCommentsLayoutingOptions)接口，允许您在将幻灯片转换为图像时在幻灯片上添加注释和评论。

{{% alert title="信息" color="info" %}} 

通过[INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/INotesCommentsLayoutingOptions)接口，您可以在生成的图像中指定注释和评论的首选位置。

{{% /alert %}} 

以下Java代码演示了带注释和评论的幻灯片的转换过程：

``` java 
Presentation pres = new Presentation("PresentationNotesComments.pptx");
try {
    // 创建渲染选项
    IRenderingOptions options = new RenderingOptions();

    // 设置页面上注释的位置
    options.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomTruncated);

    // 设置页面上评论的位置 
    options.getNotesCommentsLayouting().setCommentsPosition(CommentsPositions.Right);

    // 设置评论输出区域的宽度
    options.getNotesCommentsLayouting().setCommentsAreaWidth(500);

    // 设置评论区域的颜色
    options.getNotesCommentsLayouting().setCommentsAreaColor(Color.LIGHT_GRAY);

    // 将演示文稿的第一张幻灯片转换为位图对象
    IImage slideImage = pres.getSlides().get_Item(0).getImage(options, 2f, 2f);

    // 以GIF格式保存图像
    try {
          slideImage.save("Slide_Notes_Comments_0.gif", ImageFormat.Gif);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

该Java代码演示了使用[getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-java.awt.Dimension-)方法将带注释的幻灯片转换的过程：

``` java
Presentation pres = new Presentation("PresentationNotes.pptx");
try {
	// 获取演示文稿注释的大小
	Dimension2D notesSize = pres.getNotesSize().getSize();

	// 创建渲染选项
	IRenderingOptions options = new RenderingOptions();

	// 设置注释的位置
	options.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomTruncated);

	// 创建一个具有注释大小的Images
    IImage slideImage = pres.getSlides().get_Item(0).getImage(options, notesSize);

	// 以PNG格式保存图像
    try {
         // 在磁盘上保存图像。
          slideImage.save("Slide_0.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="注意" color="warning" %}} 

在任何幻灯片到图像的转换过程中，[NotesPositions](https://reference.aspose.com/slides/java/com.aspose.slides/INotesCommentsLayoutingOptions#setNotesPosition-int-)属性不能设置为BottomFull（以指定注释的位置），因为注释的文本可能很长，这意味着可能不适合指定的图像大小。

{{% /alert %}} 

## **使用ITiffOptions转换幻灯片为图像**

[ITiffOptions](https://reference.aspose.com/slides/java/com.aspose.slides/ITiffOptions)接口让您对生成的图像有更多的控制（在参数方面）。使用此接口，您可以指定生成图像的大小、分辨率、调色板和其他参数。

该Java代码演示了使用ITiffOptions进行转换的过程，其中输出为300dpi分辨率和2160 × 2800大小的黑白图像：

``` java 
Presentation pres = new Presentation("PresentationNotesComments.pptx");
try {
	// 按索引获取幻灯片
	ISlide slide = pres.getSlides().get_Item(0);

	// 创建TiffOptions对象
	TiffOptions options = new TiffOptions();
	options.setImageSize(new Dimension(2160, 2880));

	// 设置字体，以防未找到源字体
	options.setDefaultRegularFont("Arial Black");

	// 设置页面上注释的位置
	options.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomTruncated);

	// 设置像素格式（黑白）
	options.setPixelFormat(ImagePixelFormat.Format1bppIndexed);

	// 设置分辨率
	options.setDpiX(300);
	options.setDpiY(300);

	// 将幻灯片转换为位图对象
	IImage slideImage = slide.getImage(options);

	// 以TIFF格式保存图像
	try {
          slideImage.save("PresentationNotesComments.tiff", ImageFormat.Tiff);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="注意" color="warning" %}} 

在JDK 9之前的版本中，未保证支持Tiff。

{{% /alert %}} 

## **将所有幻灯片转换为图像**

Aspose.Slides允许您将单个演示文稿中的所有幻灯片转换为图像。基本上，您可以将演示文稿（完整）转换为图像。

以下示例代码展示了如何将演示文稿中的所有幻灯片转换为Java中的图像：

``` java 
Presentation pres = new Presentation("Presentation.pptx");
try {
    // 渲染演示文稿到图像数组，逐张幻灯片
    for (int i = 0 ; i < pres.getSlides().size(); i++)
    {
        // 控制隐藏幻灯片（不渲染隐藏的幻灯片）
        if (pres.getSlides().get_Item(i).getHidden())
            continue;

        // 将幻灯片转换为位图对象
        IImage slideImage = pres.getSlides().get_Item(i).getImage(2f, 2f);

        // 以PNG格式保存图像
        try {
              slideImage.save("Slide_" + i + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
} 
```