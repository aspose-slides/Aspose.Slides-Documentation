---
title: 使用 PHP 优化演示文稿中的图像管理
linktitle: 管理图像
type: docs
weight: 10
url: /zh/php-java/image/
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
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 在 PowerPoint 和 OpenDocument 中简化图像管理，优化性能并自动化工作流。"
---

## **演示文稿幻灯片中的图像**

图像使演示文稿更具吸引力和趣味性。 在 Microsoft PowerPoint 中，您可以从文件、互联网或其他位置将图片插入到幻灯片中。 类似地，Aspose.Slides 允许您通过多种方式向演示文稿的幻灯片添加图像。

{{% alert  title="Tip" color="primary" %}} 

Aspose 提供免费转换器——[JPEG 转 PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) and [PNG 转 PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)——允许用户快速从图像创建演示文稿。

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

如果您想将图像添加为框架对象——特别是当您计划使用标准格式选项来更改其大小、添加效果等时——请参阅[图片框](/slides/zh/php-java/picture-frame/)。

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

您可以操作涉及图像和 PowerPoint 演示文稿的输入/输出，以将图像从一种格式转换为另一种格式。请参阅以下页面：convert [图像转 JPG](https://products.aspose.com/slides/php-java/conversion/image-to-jpg/); convert [JPG 转 图像](https://products.aspose.com/slides/php-java/conversion/jpg-to-image/); convert [JPG 转 PNG](https://products.aspose.com/slides/php-java/conversion/jpg-to-png/), convert [PNG 转 JPG](https://products.aspose.com/slides/php-java/conversion/png-to-jpg/); convert [PNG 转 SVG](https://products.aspose.com/slides/php-java/conversion/png-to-svg/), convert [SVG 转 PNG](https://products.aspose.com/slides/php-java/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides 支持对这些常用格式的图像进行操作：JPEG、PNG、GIF 等。

## **向幻灯片添加本地存储的图像**

您可以将计算机上的一个或多个图像添加到演示文稿的幻灯片中。以下示例代码展示了如何向幻灯片添加图像：

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


## **从网页向幻灯片添加图像**

如果您想添加到幻灯片的图像在电脑上不可用，您可以直接从网络添加该图像。

以下示例代码展示了如何从网络向幻灯片添加图像：

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


## **向幻灯片母版添加图像**

幻灯片母版是顶部幻灯片，存储并控制其下所有幻灯片的信息（主题、布局等）。因此，当您向幻灯片母版添加图像时，该图像会出现在该母版下的每一张幻灯片上。

以下 Java 示例代码展示了如何向幻灯片母版添加图像：

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


## **将图像设为幻灯片背景**

您可能决定将图片用作特定幻灯片或多张幻灯片的背景。在这种情况下，您需要了解如何[将图像设为幻灯片背景](/slides/zh/php-java/presentation-background/#set-an-image-as-a-slide-background)。

## **向演示文稿添加 SVG**

您可以使用属于[ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/)类的[addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addpictureframe/)方法向演示文稿添加或插入任何图像。

要基于 SVG 图像创建图像对象，可以按以下方式进行：

1. 创建 SvgImage 对象以将其插入到 ImageShapeCollection
1. 从 ISvgImage 创建 PPImage 对象
1. 使用 PPImage 类创建 PictureFrame 对象

以下示例代码展示了如何实现上述步骤，将 SVG 图像添加到演示文稿中：

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


## **将 SVG 转换为形状集合**

Aspose.Slides 将 SVG 转换为形状集合的功能类似于 PowerPoint 用于处理 SVG 图像的功能：

![PowerPoint Popup Menu](img_01_01.png)

该功能由 [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/) 类的 [addGroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addgroupshape/) 方法的其中一个重载提供，该重载接受 [SvgImage](https://reference.aspose.com/slides/php-java/aspose.slides/svgimage/) 对象作为第一个参数。

以下示例代码展示了如何使用上述方法将 SVG 文件转换为形状集合：

```php
  # 创建新演示文稿
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
    # 获取幻灯片尺寸
    $slideSize = $presentation->getSlideSize()->getSize();
    # 将 SVG 图像转换为形状组并缩放到幻灯片尺寸
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


## **将图像以 EMF 形式添加到幻灯片**

Aspose.Slides for PHP via Java 允许您从 Excel 工作表生成 EMF 图像，并使用 Aspose.Cells 将这些图像以 EMF 形式添加到幻灯片中。

以下示例代码展示了如何执行上述任务：

```php
  $book = new Workbook("chart.xlsx");
  $sheet = $book->getWorksheets()->get(0);
  $options = new ImageOrPrintOptions();
  $options->setHorizontalResolution(200);
  $options->setVerticalResolution(200);
  $options->setImageType(ImageType::EMF);
  # 将工作簿保存到流
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


## **替换图像集合中的图像**

Aspose.Slides 允许您替换存储在演示文稿图像集合中的图像（包括幻灯片形状使用的图像）。本节展示了更新集合中图像的几种方法。API 提供了使用原始字节数据、[IImage](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/) 实例或集合中已存在的另一个图像来替换图像的简便方法。

Follow the steps below:

1. 使用 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类加载包含图像的演示文稿文件。
1. 将新图像从文件加载到字节数组中。
1. 使用字节数组将目标图像替换为新图像。
1. 在第二种方法中，将图像加载到 [IImage](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/) 对象中，并使用该对象替换目标图像。
1. 在第三种方法中，将目标图像替换为演示文稿图像集合中已存在的图像。
1. 将修改后的演示文稿写入为 PPTX 文件。

```php
// 实例化表示演示文稿文件的 Presentation 类。
$presentation = new Presentation("sample.pptx");
try {
    // 第一种方式。
    $imagePath = (new Java("java.io.File", "image0.jpeg"))->toPath();
    $imageData = (new Java("java.nio.file.Files"))->readAllBytes($imagePath);
    $oldImage = $presentation->getImages()->get_Item(0);
    $oldImage->replaceImage($imageData);

    // 第二种方式。
    $newImage = Images::fromFile("image1.png");
    $oldImage = $presentation->getImages()->get_Item(1);
    $oldImage->replaceImage($newImage);
    $newImage->dispose();
    
    // 第三种方式。
    $oldImage = $presentation->getImages()->get_Item(2);
    $oldImage->replaceImage($presentation->getImages()->get_Item(3));
    
    // 将演示文稿保存到文件。
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


{{% alert title="Info" color="info" %}}

使用 Aspose 免费的 [Text to GIF](https://products.aspose.app/slides/text-to-gif) 转换器，您可以轻松为文本添加动画、从文本创建 GIF 等。

{{% /alert %}}

## **常见问题**

**插入后原始图像分辨率是否保持不变？**

是的。源像素得以保留，但最终显示效果取决于[图片](/slides/zh/php-java/picture-frame/)在幻灯片上的缩放方式以及保存时所使用的压缩。

**一次性替换数十张幻灯片中相同徽标的最佳方法是什么？**

将徽标放置在母版幻灯片或布局上，并在演示文稿的图像集合中进行替换——更新会传播到所有使用该资源的元素。

**插入的 SVG 能否转换为可编辑的形状？**

可以。您可以将 SVG 转换为一组形状，之后各个部分即可使用标准形状属性进行编辑。

**如何一次性将图片设为多张幻灯片的背景？**

在母版幻灯片或相应布局上[将图像设为背景](/slides/zh/php-java/presentation-background/)，使用该母版/布局的所有幻灯片都会继承该背景。

**如何防止因大量图片导致演示文稿体积“膨胀”？**

重复使用单一图像资源而非重复拷贝，选择合适的分辨率，保存时进行压缩，并在适当情况下将重复图形放在母版上。