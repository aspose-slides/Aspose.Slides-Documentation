---
title: 转换幻灯片
type: docs
weight: 35
url: /androidjava/convert-slide/
keywords: 
- 将幻灯片转换为图像
- 将幻灯片导出为图像
- 将幻灯片保存为图像
- 幻灯片到图像
- 幻灯片到PNG
- 幻灯片到JPEG
- 幻灯片到位图
- Java
- Aspose.Slides for Android via Java
description: "在Java中将PowerPoint幻灯片转换为图像（位图、PNG或JPG）"
---

Aspose.Slides for Android via Java允许您将幻灯片（在演示文稿中）转换为图像。这些是支持的图像格式：BMP、PNG、JPG（JPEG）、GIF等。

要将幻灯片转换为图像，请执行以下操作：

1. 首先，使用以下方法设置转换参数和要转换的幻灯片对象：
   * [ITiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiffOptions)接口或
   * [IRenderingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IRenderingOptions)接口。

2. 其次，通过使用[getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage--)方法将幻灯片转换为图像。

## **关于位图和其他图像格式**

在Java中，[Images](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Images)是一个对象，允许您使用由像素数据定义的图像。您可以使用此类的实例以广泛的格式（JPG、PNG等）保存图像。

{{% alert title="信息" color="info" %}}

Aspose最近开发了一种在线[文本到GIF](https://products.aspose.app/slides/text-to-gif)转换器。

{{% /alert %}}

## **将幻灯片转换为位图并将图像保存为PNG**

以下Java代码向您展示如何将演示文稿的第一张幻灯片转换为位图对象，然后将图像保存为PNG格式：

``` java 
Presentation pres = new Presentation("Presentation.pptx");
try {
    // 将演示文稿中的第一张幻灯片转换为Images对象
    IImage slideImage = pres.getSlides().get_Item(0).getImage();

	// 将图像保存为PNG格式
	try {
        // 将图像保存到磁盘。
         slideImage.save("Slide_0.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

此示例代码向您展示如何使用[getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide#getImage-java.awt.Dimension-)方法将演示文稿的第一张幻灯片转换为位图对象：

``` java 
Presentation pres = new Presentation("Presentation.pptx");
try {
	// 获取演示文稿的幻灯片大小
	Dimension2D slideSize = new Dimension((int) slideSize.getWidth(), (int) slideSize.getHeight());

	// 创建一个带有幻灯片大小的Images
    IImage slideImage = sld.getImage(new RenderingOptions(), slideSize);
    try {
         // 将图像保存到磁盘。
          slideImage.save("Slide_0.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="提示" color="primary" %}} 

您可以将幻灯片转换为Images对象，然后在某处直接使用该对象。或者，您可以将幻灯片转换为Images，然后将图像保存为JPEG或您偏好的任何其他格式。

{{% /alert %}}  

## **使用自定义大小转换幻灯片为图像**

您可能需要获取特定大小的图像。通过使用[getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-)方法的重载，您可以将幻灯片转换为具有特定维度（长度和宽度）的图像。

此示例代码展示了如何在Java中使用[getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide#getImage-java.awt.Dimension-)方法执行提议的转换：

``` java 
Presentation pres = new Presentation("Presentation.pptx");
try {
    // 将演示文稿中的第一张幻灯片转换为指定大小的位图
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1820, 1040));
	
	// 将图像保存为JPEG格式
	try {
         // 将图像保存到磁盘。
          slideImage.save("Slide_0.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **将带有注释和备注的幻灯片转换为图像**

某些幻灯片包含注释和备注。

Aspose.Slides提供了两个接口——[ITiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiffOptions)和[IRenderingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IRenderingOptions)——允许您控制演示文稿幻灯片渲染为图像。这两个接口都包含[INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INotesCommentsLayoutingOptions)接口，允许您在将幻灯片转换为图像时添加备注和评论。

{{% alert title="信息" color="info" %}} 

使用[INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INotesCommentsLayoutingOptions)接口，您可以指定结果图像中备注和评论的首选位置。

{{% /alert %}} 

此Java代码演示了带有注释和备注的幻灯片的转换过程：

``` java 
Presentation pres = new Presentation("PresentationNotesComments.pptx");
try {
    // 创建渲染选项
    IRenderingOptions options = new RenderingOptions();

    // 设置页面上备注的位置
    options.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomTruncated);

    // 设置页面上评论的位置 
    options.getNotesCommentsLayouting().setCommentsPosition(CommentsPositions.Right);

    // 设置评论输出区域的宽度
    options.getNotesCommentsLayouting().setCommentsAreaWidth(500);

    // 设置评论区域的颜色
    options.getNotesCommentsLayouting().setCommentsAreaColor(Color.LIGHT_GRAY);

    // 将演示文稿中的第一张幻灯片转换为位图对象
    IImage slideImage = pres.getSlides().get_Item(0).getImage(options, 2f, 2f);

    // 将图像保存为GIF格式
    try {
          slideImage.save("Slide_Notes_Comments_0.gif", ImageFormat.Gif);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

此Java代码演示了使用[getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide#getImage-java.awt.Dimension-)方法的带有备注的幻灯片的转换过程：

``` java
Presentation pres = new Presentation("PresentationNotes.pptx");
try {
	// 获取演示文稿备注的大小
	Dimension2D notesSize = pres.getNotesSize().getSize();

	// 创建渲染选项
	IRenderingOptions options = new RenderingOptions();

	// 设置备注的位置
	options.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomTruncated);

	// 创建一个带有备注大小的Images
    IImage slideImage = pres.getSlides().get_Item(0).getImage(options, notesSize);

	// 将图像保存为PNG格式
    try {
         // 将图像保存到磁盘。
          slideImage.save("Slide_0.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="注意" color="warning" %}} 

在任何幻灯片到图像的转换过程中，不能将[NotesPositions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INotesCommentsLayoutingOptions#setNotesPosition-int-)属性设置为BottomFull（以指定备注的位置），因为备注的文本可能较大，可能无法适应指定的图像大小。

{{% /alert %}} 

## **使用ITiffOptions转换幻灯片为图像**

[ITiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiffOptions)接口提供了对生成图像在参数上的更多控制。使用此接口，您可以指定生成图像的大小、分辨率、调色板和其他参数。

以下Java代码演示了一个转换过程，其中使用ITiffOptions输出一幅300dpi分辨率和2160 × 2800大小的黑白图像：

``` java 
Presentation pres = new Presentation("PresentationNotesComments.pptx");
try {
	// 按索引获取幻灯片
	ISlide slide = pres.getSlides().get_Item(0);

	// 创建一个TiffOptions对象
	TiffOptions options = new TiffOptions();
	options.setImageSize(new Dimension(2160, 2880));

	// 在找不到源字体时设置使用的字体
	options.setDefaultRegularFont("Arial Black");

	// 设置页面上备注的位置
	options.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomTruncated);

	// 设置像素格式（黑白）
	options.setPixelFormat(ImagePixelFormat.Format1bppIndexed);

	// 设置分辨率
	options.setDpiX(300);
	options.setDpiY(300);

	// 将幻灯片转换为位图对象
	IImage slideImage = slide.getImage(options);

	// 将图像保存为TIFF格式
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

在JDK 9之前的版本中，TIFF支持不能保证。

{{% /alert %}} 

## **将所有幻灯片转换为图像**

Aspose.Slides允许您将单个演示文稿中的所有幻灯片转换为图像。实质上，您可以将整个演示文稿转换为图像。

此示例代码向您展示如何在Java中将演示文稿中的所有幻灯片转换为图像：

``` java 
Presentation pres = new Presentation("Presentation.pptx");
try {
    // 按幻灯片逐一渲染演示文稿到图像数组
    for (int i = 0 ; i < pres.getSlides().size(); i++)
    {
        // 控制隐藏幻灯片（不渲染隐藏幻灯片）
        if (pres.getSlides().get_Item(i).getHidden())
            continue;

        // 将幻灯片转换为位图对象
        IImage slideImage = pres.getSlides().get_Item(i).getImage(2f, 2f);

        // 将图像保存为PNG格式
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