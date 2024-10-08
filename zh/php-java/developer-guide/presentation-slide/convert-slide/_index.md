---
title: 转换幻灯片
type: docs
weight: 35
url: /zh/php-java/convert-slide/
keywords: 
- 将幻灯片转换为图像
- 以图像格式导出幻灯片
- 将幻灯片保存为图像
- 幻灯片转图像
- 幻灯片转PNG
- 幻灯片转JPEG
- 幻灯片转位图
- PHP
- Aspose.Slides for PHP通过Java
description: "将PowerPoint幻灯片转换为图像（位图、PNG或JPG）在PHP中"
---

Aspose.Slides for PHP通过Java允许您将幻灯片（在演示文稿中）转换为图像。支持的图像格式包括：BMP、PNG、JPG（JPEG）、GIF等。

要将幻灯片转换为图像，请执行以下操作：

1. 首先，使用以下方式设置转换参数和要转换的幻灯片对象：
   * [ITiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/ITiffOptions) 接口或
   * [IRenderingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/IRenderingOptions) 接口。

2. 其次，使用 [getImage](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-java.awt.Dimension-) 方法将幻灯片转换为图像。

## **关于位图和其他图像格式**

在Java中，[Images](https://reference.aspose.com/slides/php-java/aspose.slides/Images) 是一个允许您使用像素数据定义的图像的对象。您可以使用此类的实例以广泛的格式保存图像（JPG、PNG等）。

{{% alert title="信息" color="info" %}}

Aspose最近开发了一个在线 [文本转GIF](https://products.aspose.app/slides/text-to-gif) 转换器。

{{% /alert %}}

## **将幻灯片转换为位图并以PNG格式保存图像**

以下PHP代码演示了如何将演示文稿的第一张幻灯片转换为位图对象，然后将图像以PNG格式保存：

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # 将演示文稿中的第一张幻灯片转换为Images对象
    $slideImage = $pres->getSlides()->get_Item(0)->getImage();
    # 以PNG格式保存图像
    try {
      # 将图像保存到磁盘。
      $slideImage->save("Slide_0.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

以下示例代码演示了如何使用 [getImage](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-java.awt.Dimension-) 方法将演示文稿的第一张幻灯片转换为位图对象：

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # 获取演示文稿幻灯片的大小
    $slideSize = new Java("java.awt.Dimension", $slideSize->getWidth(), $slideSize->getHeight());
    # 创建与幻灯片大小相同的Images
    $slideImage = $sld->getImage(new RenderingOptions(), $slideSize);
    try {
      # 将图像保存到磁盘。
      $slideImage->save("Slide_0.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="提示" color="primary" %}} 

您可以将幻灯片转换为Images对象，然后在其他地方直接使用该对象。或者，您可以将幻灯片转换为Images，然后以JPEG或您喜欢的其他格式保存图像。

{{% /alert %}}  

## **将幻灯片转换为具有自定义大小的图像**

您可能需要获取某个特定大小的图像。使用 [getImage](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-) 方法的重载，您可以将幻灯片转换为具有特定尺寸（长度和宽度）的图像。

以下示例代码演示了使用 [getImage](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-java.awt.Dimension-) 方法进行转换的过程：

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # 将演示文稿中的第一张幻灯片转换为指定大小的位图
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 1820, 1040));
    # 以JPEG格式保存图像
    try {
      # 将图像保存到磁盘。
      $slideImage->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **将具有备注和评论的幻灯片转换为图像**

某些幻灯片包含备注和评论。

Aspose.Slides提供了两个接口——[ITiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/ITiffOptions) 和 [IRenderingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/IRenderingOptions)——允许您控制将演示文稿幻灯片渲染为图像。两个接口都包含 [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/INotesCommentsLayoutingOptions) 接口，允许您在将幻灯片转换为图像时在幻灯片上添加备注和评论。

{{% alert title="信息" color="info" %}} 

使用 [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/INotesCommentsLayoutingOptions) 接口，您可以指定在生成的图像中备注和评论的首选位置。

{{% /alert %}} 

以下PHP代码演示了具有备注和评论的幻灯片的转换过程：

```php
  $pres = new Presentation("PresentationNotesComments.pptx");
  try {
    # 创建渲染选项
    $options = new RenderingOptions();
    # 设置备注在页面上的位置
    $options->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomTruncated);
    # 设置评论在页面上的位置
    $options->getNotesCommentsLayouting()->setCommentsPosition(CommentsPositions::Right);
    # 设置评论输出区域的宽度
    $options->getNotesCommentsLayouting()->setCommentsAreaWidth(500);
    # 设置评论区域的颜色
    $options->getNotesCommentsLayouting()->setCommentsAreaColor(java("java.awt.Color")->LIGHT_GRAY);
    # 将演示文稿的第一张幻灯片转换为位图对象
    $slideImage = $pres->getSlides()->get_Item(0)->getImage($options, 2.0, 2.0);
    # 以GIF格式保存图像
    try {
      $slideImage->save("Slide_Notes_Comments_0.gif", ImageFormat::Gif);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

以下PHP代码演示了使用 [getImage](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-java.awt.Dimension-) 方法转换具有备注的幻灯片的过程：

```php
  $pres = new Presentation("PresentationNotes.pptx");
  try {
    # 获取演示文稿备注的大小
    $notesSize = $pres->getNotesSize()->getSize();
    # 创建渲染选项
    $options = new RenderingOptions();
    # 设置备注的位置
    $options->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomTruncated);
    # 创建与备注大小相同的Images
    $slideImage = $pres->getSlides()->get_Item(0)->getImage($options, $notesSize);
    # 以PNG格式保存图像
    try {
      # 将图像保存到磁盘。
      $slideImage->save("Slide_0.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="注意" color="warning" %}} 

在任何幻灯片转换为图像的过程中， [NotesPositions](https://reference.aspose.com/slides/php-java/aspose.slides/INotesCommentsLayoutingOptions#setNotesPosition-int-) 属性不能设置为 BottomFull（以指定备注的位置），因为备注的文本可能很长，可能无法适应指定的图像大小。

{{% /alert %}} 

## **使用ITiffOptions将幻灯片转换为图像**

[ITiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/ITiffOptions) 接口让您对生成的图像拥有更多的控制（在参数方面）。使用该接口，您可以指定生成图像的大小、分辨率、调色板等参数。

以下PHP代码演示了一个转换过程，其中使用ITiffOptions输出300dpi分辨率和2160 × 2800大小的黑白图像：

```php
  $pres = new Presentation("PresentationNotesComments.pptx");
  try {
    # 按索引获取幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 创建TiffOptions对象
    $options = new TiffOptions();
    $options->setImageSize(new Java("java.awt.Dimension", 2160, 2880));
    # 设置在找不到源字体时使用的字体
    $options->setDefaultRegularFont("Arial Black");
    # 设置备注在页面上的位置
    $options->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomTruncated);
    # 设置像素格式（黑白）
    $options->setPixelFormat(ImagePixelFormat::Format1bppIndexed);
    # 设置分辨率
    $options->setDpiX(300);
    $options->setDpiY(300);
    # 将幻灯片转换为位图对象
    $slideImage = $slide->getImage($options);
    # 以TIFF格式保存图像
    try {
      $slideImage->save("PresentationNotesComments.tiff", ImageFormat::Tiff);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="注意" color="warning" %}} 

在JDK 9之前的版本中不保证支持Tiff。

{{% /alert %}} 

## **将所有幻灯片转换为图像**

Aspose.Slides允许您将单个演示文稿中的所有幻灯片转换为图像。基本上，您可以将整个演示文稿转换为图像。

以下示例代码演示了如何将演示文稿中的所有幻灯片转换为图像：

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # 将演示文稿逐张幻灯片渲染到图像数组
    for($i = 0; $i < java_values($pres->getSlides()->size()) ; $i++) {
      # 控制隐藏的幻灯片（不渲染隐藏的幻灯片）
      if ($pres->getSlides()->get_Item($i)->getHidden()) {
        continue;
      }
      # 将幻灯片转换为位图对象
      $slideImage = $pres->getSlides()->get_Item($i)->getImage(2.0, 2.0);
      # 以PNG格式保存图像
      try {
        $slideImage->save("Slide_" . $i . ".png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```