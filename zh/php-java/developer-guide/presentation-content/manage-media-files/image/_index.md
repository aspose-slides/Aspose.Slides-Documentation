---
title: 图像
type: docs
weight: 10
url: /php-java/image/
description: 使用 PHP 在 PowerPoint 演示文稿的幻灯片中处理图像。从磁盘或网络添加图像到 PowerPoint 幻灯片中。使用 PHP 将图像添加到幻灯片母版或作为幻灯片背景。使用 PHP 将 SVG 添加到 PowerPoint 演示文稿中。使用 PHP 将 SVG 转换为 PowerPoint 中的形状。使用 PHP 将图像作为 EMF 添加到幻灯片中。
---

## **在演示文稿的幻灯片中插入图像**

图像使演示文稿更具吸引力和趣味性。在 Microsoft PowerPoint 中，您可以从文件、互联网或其他位置将图片插入到幻灯片中。同样，Aspose.Slides 允许您通过不同的过程向演示文稿中的幻灯片添加图像。

{{% alert  title="提示" color="primary" %}} 

Aspose 提供免费的转换器——[JPEG 到 PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) 和 [PNG 到 PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)——可以让人们快速从图像创建演示文稿。 

{{% /alert %}} 

{{% alert title="信息" color="info" %}}

如果您想将图像作为框架对象添加——特别是如果您计划在其上使用标准格式选项来改变其大小、添加效果等——请参见 [图片框架](https://docs.aspose.com/slides/php-java/picture-frame/)。

{{% /alert %}} 

{{% alert title="注意" color="warning" %}}

您可以处理涉及图像和 PowerPoint 演示文稿的输入/输出操作，以将图像从一种格式转换为另一种格式。请参见以下页面：转换 [图像到 JPG](https://products.aspose.com/slides/php-java/conversion/image-to-jpg/)；转换 [JPG 到图像](https://products.aspose.com/slides/php-java/conversion/jpg-to-image/)；转换 [JPG 到 PNG](https://products.aspose.com/slides/php-java/conversion/jpg-to-png/)，转换 [PNG 到 JPG](https://products.aspose.com/slides/php-java/conversion/png-to-jpg/)；转换 [PNG 到 SVG](https://products.aspose.com/slides/php-java/conversion/png-to-svg/)，转换 [SVG 到 PNG](https://products.aspose.com/slides/php-java/conversion/svg-to-png/)。

{{% /alert %}}

Aspose.Slides 支持处理以下流行格式的图像：JPEG、PNG、GIF 等。

## **将本地存储的图像添加到幻灯片中**

您可以将计算机上的一张或多张图像添加到演示文稿的幻灯片中。以下示例代码演示了如何将图像添加到幻灯片中：

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **从网络向幻灯片中添加图像**

如果您希望添加到幻灯片中的图像在计算机上不可用，您可以直接从网络添加该图像。

以下示例代码演示了如何将网络图像添加到幻灯片中：

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $imageUrl = new URL("[REPLACE WITH URL]");
    $connection = $imageUrl->openConnection();
    $inputStream = $connection->getInputStream();
    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new java_class("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    try {
      $buffer = $Array->newInstance($Byte, 1024);
      $read;
      while ($read = $inputStream->read($buffer, 0, $Array->getLength($buffer)) != -1) {
        $outputStream->write($buffer, 0, $read);
      } 
      $outputStream->flush();
      $image = $pres->getImages()->addImage($outputStream->toByteArray());
      $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $image);
    } finally {
      if (!java_is_null($inputStream)) {
        $inputStream->close();
      }
      $outputStream->close();
    }
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **将图像添加到幻灯片母版**

幻灯片母版是顶部的幻灯片，存储和控制关于其下所有幻灯片的信息（主题、布局等）。因此，当您将图像添加到幻灯片母版时，该图像会出现在该幻灯片母版下的每一张幻灯片上。

以下 Java 示例代码演示了如何将图像添加到幻灯片母版中：

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $masterSlide = $slide->getLayoutSlide()->getMasterSlide();
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $masterSlide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **将图像作为幻灯片背景添加**

您可能决定使用图片作为特定幻灯片或多个幻灯片的背景。在这种情况下，您需要查看 *[为幻灯片设置图像作为背景](https://docs.aspose.com/slides/php-java/presentation-background/#setting-images-as-background-for-slides)*。

## **将 SVG 添加到演示文稿中**
您可以使用属于 [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection) 接口的 [addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) 方法向演示文稿中添加或插入任何图像。

要基于 SVG 图像创建图像对象，您可以这样做：

1. 创建 SvgImage 对象以插入到 ImageShapeCollection
2. 从 ISvgImage 创建 PPImage 对象
3. 使用 IPPImage 接口创建 PictureFrame 对象

以下示例代码演示了如何实现上述步骤将 SVG 图像添加到演示文稿中：
```php
  # 实例化表示 PPTX 文件的 Presentation 类
  $pres = new Presentation();
  try {
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "image.svg"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $svgContent = new String($bytes);

    $svgImage = new SvgImage($svgContent);
    $ppImage = $pres->getImages()->addImage($svgImage);
    $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, $ppImage->getWidth(), $ppImage->getHeight(), $ppImage);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **将 SVG 转换为一组形状**
Aspose.Slides 将 SVG 转换为一组形状的功能类似于 PowerPoint 中用于处理 SVG 图像的功能：

![PowerPoint 弹出菜单](img_01_01.png)

该功能由 [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection) 接口的 [addGroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) 方法的重载之一提供，该方法以 [ISvgImage](https://reference.aspose.com/slides/php-java/aspose.slides/ISvgImage) 对象作为第一个参数。

以下示例代码演示了如何使用所述方法将 SVG 文件转换为一组形状：

```php
  # 创建新的演示文稿
  $presentation = new Presentation();
  try {
    # 读取 SVG 文件内容
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "image.svg"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $svgContent = $bytes;

    # 创建 SvgImage 对象
    $svgImage = new SvgImage($svgContent);
    # 获取幻灯片大小
    $slideSize = $presentation->getSlideSize()->getSize();
    # 将 SVG 图像转换为一组形状并缩放到幻灯片大小
    $presentation->getSlides()->get_Item(0)->getShapes()->addGroupShape($svgImage, 0.0, 0.0, $slideSize->getWidth(), $slideSize->getHeight());
    # 以 PPTX 格式保存演示文稿
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **将图像作为 EMF 添加到幻灯片中**
Aspose.Slides for PHP via Java 允许您从 Excel 表格生成 EMF 图像，并使用 Aspose.Cells 将图像作为 EMF 添加到幻灯片中。

以下示例代码演示了如何执行上述任务：

```php
  $book = new Workbook("chart.xlsx");
  $sheet = $book->getWorksheets()->get(0);
  $options = new ImageOrPrintOptions();
  $options->setHorizontalResolution(200);
  $options->setVerticalResolution(200);
  $options->setImageType(ImageType::EMF);
  # 将工作簿保存到流中
  $sr = new SheetRender($sheet, $options);
  $pres = new Presentation();
  try {
    $pres->getSlides()->removeAt(0);
    $EmfSheetName = "";
    for($j = 0; $j < java_values($sr->getPageCount()) ; $j++) {
      $EmfSheetName = "test" . $sheet->getName() . " Page" . $j + 1 . ".out.emf";
      $sr->toImage($j, $EmfSheetName);
      $picture;
      $image = Images->fromFile($EmfSheetName);
      try {
        $picture = $pres->getImages()->addImage($image);
      } finally {
        if (!java_is_null($image)) {
          $image->dispose();
        }
      }
      $slide = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->getByType(SlideLayoutType::Blank));
      $m = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, $pres->getSlideSize()->getSize()->getWidth(), $pres->getSlideSize()->getSize()->getHeight(), $picture);
    }
    $pres->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="信息" color="info" %}}

使用 Aspose 免费的 [文本到 GIF](https://products.aspose.app/slides/text-to-gif) 转换器，您可以轻松地为文本添加动画，创建 GIF 等。

{{% /alert %}}