---
title: 使用 PHP 管理演示文稿中的图片框
linktitle: 图片框
type: docs
weight: 10
url: /zh/php-java/picture-frame/
keywords:
- 图片框
- 添加图片框
- 创建图片框
- 添加图像
- 创建图像
- 提取图像
- 光栅图像
- 矢量图像
- 裁剪图像
- 裁剪区域
- StretchOff 属性
- 图片框格式化
- 图片框属性
- 相对比例
- 图像效果
- 宽高比
- 图像透明度
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 将图片框添加到 PowerPoint 和 OpenDocument 演示文稿中。简化工作流程并提升幻灯片设计。"
---

图片框是一种包含图像的形状——它就像框中的图片。

您可以通过图片框将图像添加到幻灯片中。这样，您可以通过格式化图片框来格式化图像。

{{% alert  title="Tip" color="primary" %}} 
Aspose 提供免费转换器——[JPEG 转 PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) 和 [PNG 转 PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)——可让用户快速从图像创建演示文稿。 
{{% /alert %}} 

## **创建图片框**

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 通过向与演示文稿对象关联的 [IImagescollection](https://reference.aspose.com/slides/php-java/aspose.slides/IImageCollection) 添加图像来创建一个 [IPPImage]() 对象，该对象将用于填充形状。  
4. 指定图像的宽度和高度。  
5. 通过引用幻灯片关联的形状对象公开的 `AddPictureFrame` 方法，根据图像的宽度和高度创建一个 [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/PictureFrame)。  
6. 将包含图片的图片框添加到幻灯片中。  
7. 将修改后的演示文稿写入为 PPTX 文件。  

以下 PHP 代码示例演示如何创建图片框：
```php
  # 实例化表示 PPTX 文件的 Presentation 类
  $pres = new Presentation();
  try {
    # 获取第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 实例化 Image 类
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # 添加一个图片框，大小与图片的高度和宽度相同
    $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # 将 PPTX 文件写入磁盘
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="warning" %}} 
图片框可让您快速基于图像创建演示文稿幻灯片。当将图片框与 Aspose.Slides 的保存选项结合使用时，您可以操作输入/输出以将图像从一种格式转换为另一种格式。您可能想查看以下页面：转换 [image to JPG](https://products.aspose.com/slides/php-java/conversion/image-to-jpg/)；转换 [JPG to image](https://products.aspose.com/slides/php-java/conversion/jpg-to-image/)；转换 [JPG to PNG](https://products.aspose.com/slides/php-java/conversion/jpg-to-png/)，转换 [PNG to JPG](https://products.aspose.com/slides/php-java/conversion/png-to-jpg/)；转换 [PNG to SVG](https://products.aspose.com/slides/php-java/conversion/png-to-svg/)，转换 [SVG to PNG](https://products.aspose.com/slides/php-java/conversion/svg-to-png/)。 
{{% /alert %}} 

## **创建具有相对比例的图片框**

通过改变图像的相对缩放，您可以创建更复杂的图片框。

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 将图像添加到演示文稿的图像集合中。  
4. 通过向与演示文稿对象关联的 [IImagescollection](https://reference.aspose.com/slides/php-java/aspose.slides/IImageCollection) 添加图像来创建一个 [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage) 对象，该对象将用于填充形状。  
5. 在图片框中指定图像的相对宽度和高度。  
6. 将修改后的演示文稿写入为 PPTX 文件。  

以下 PHP 代码示例演示如何创建具有相对比例的图片框：
```php
  # 实例化表示 PPTX 的 Presentation 类
  $pres = new Presentation();
  try {
    # 获取第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 实例化 Image 类
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # 添加图片框，尺寸等同于图片的高度和宽度
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # 设置相对缩放宽度和高度
    $pf->setRelativeScaleHeight(0.8);
    $pf->setRelativeScaleWidth(1.35);
    # 将 PPTX 文件写入磁盘
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **从图片框中提取光栅图像**

您可以从 [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/PictureFrame) 对象中提取光栅图像并将其保存为 PNG、JPG 等格式。下面的代码示例展示如何从文档 "sample.pptx" 中提取图像并以 PNG 格式保存。
```php
  $presentation = new Presentation("sample.pptx");
  try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $firstShape = $firstSlide->getShapes()->get_Item(0);
    if (java_instanceof($firstShape, new JavaClass("com.aspose.slides.PictureFrame"))) {
      $pictureFrame = $firstShape;
      try {
        $slideImage = $pictureFrame->getPictureFormat()->getPicture()->getImage()->getImage();
        $slideImage->save("slide_1_shape_1.png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } catch (JavaException $e) {
  } finally {
    $presentation->dispose();
  }
```


## **从图片框中提取 SVG 图像**

当演示文稿包含放置在 [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) 形状中的 SVG 图形时，Aspose.Slides for PHP via Java 可以让您完整保真地检索原始矢量图像。通过遍历幻灯片的形状集合，您可以识别每个 [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/)，检查底层的 [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) 是否包含 SVG 内容，然后将该图像以其原生 SVG 格式保存到磁盘或流中。

以下代码示例演示如何从图片框中提取 SVG 图像：
```php
$presentation = new Presentation("sample.pptx");

try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
        $svgImage = $shape->getPictureFormat()->getPicture()->getImage()->getSvgImage();

        if ($svgImage !== null) {
            file_put_contents("output.svg", $svgImage->getSvgData());
        }
    }
} finally {
    $presentation->dispose();
}
```


## **获取图像的透明度**

Aspose.Slides 允许您获取应用于图像的透明度效果。以下 PHP 代码演示该操作：
```php
  $presentation = new Presentation("Test.pptx");
  $pictureFrame = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
  foreach($imageTransform as $effect) {
    if (java_instanceof($effect, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
      $alphaModulateFixed = $effect;
      $transparencyValue = 100 - $alphaModulateFixed->getAmount();
      echo("Picture transparency: " . $transparencyValue);
    }
  }
```


## **图片框格式化**

Aspose.Slides 提供了许多可应用于图片框的格式化选项。使用这些选项，您可以修改图片框以满足特定需求。

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 通过向与演示文稿对象关联的 [IImagescollection](https://reference.aspose.com/slides/php-java/aspose.slides/IImageCollection) 添加图像来创建一个 [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage) 对象，该对象将用于填充形状。  
4. 指定图像的宽度和高度。  
5. 通过与引用幻灯片关联的 [IShapes](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection) 对象公开的 [AddPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) 方法，根据图像的宽度和高度创建一个 `PictureFrame`。  
6. 将包含图片的图片框添加到幻灯片中。  
7. 设置图片框的线条颜色。  
8. 设置图片框的线条宽度。  
9. 通过给出正值或负值来旋转图片框。  
   * 正值会顺时针旋转图像。  
   * 负值会逆时针旋转图像。  
10. 将包含图片的图片框添加到幻灯片中。  
11. 将修改后的演示文稿写入为 PPTX 文件。  

以下 PHP 代码演示图片框格式化过程：
```php
  # 实例化表示 PPTX 的 Presentation 类
  $pres = new Presentation();
  try {
    # 获取第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 实例化 Image 类
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # 添加与图片高度和宽度相同的图片框
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # 对 PictureFrameEx 应用一些格式设置
    $pf->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $pf->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pf->getLineFormat()->setWidth(20);
    $pf->setRotation(45);
    # 将 PPTX 文件写入磁盘
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert title="Tip" color="primary" %}}
Aspose 最近推出了一个 [免费拼贴制作工具](https://products.aspose.app/slides/collage)。如果您需要 [合并 JPG/JPEG](https://products.aspose.app/slides/collage/jpg) 或 PNG 图像，或 [从照片创建网格](https://products.aspose.app/slides/collage/photo-grid)，都可以使用此服务。 
{{% /alert %}}

## **将图像添加为链接**

为了避免演示文稿体积过大，您可以通过链接方式添加图像（或视频），而不是将文件直接嵌入演示文稿。以下 PHP 代码示例展示如何将图像和视频添加到占位符中：
```php
  $presentation = new Presentation("input.pptx");
  try {
    $shapesToRemove = new Java("java.util.ArrayList");
    $shapesCount = $presentation->getSlides()->get_Item(0)->getShapes()->size();
    for($i = 0; $i < java_values($shapesCount) ; $i++) {
      $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item($i);
      if (java_is_null($autoShape->getPlaceholder())) {
        continue;
      }
      switch ($autoShape->getPlaceholder()->getType()) {
        case PlaceholderType::Picture :
          $pictureFrame = $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, $autoShape->getX(), $autoShape->getY(), $autoShape->getWidth(), $autoShape->getHeight(), null);
          $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
          $shapesToRemove->add($autoShape);
          break;
        case PlaceholderType::Media :
          $videoFrame = $presentation->getSlides()->get_Item(0)->getShapes()->addVideoFrame($autoShape->getX(), $autoShape->getY(), $autoShape->getWidth(), $autoShape->getHeight(), "");
          $videoFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
          $videoFrame->setLinkPathLong("https://youtu.be/t_1LYZ102RA");
          $shapesToRemove->add($autoShape);
          break;
      }
    }
    foreach($shapesToRemove as $shape) {
      $presentation->getSlides()->get_Item(0)->getShapes()->remove($shape);
    }
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **裁剪图像**

以下 PHP 代码示例展示如何在幻灯片上裁剪已有图像：
```php
  $pres = new Presentation();
  # 创建新的图像对象
  try {
    $picture;
    $image = Images->fromFile($imagePath);
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # 向幻灯片添加图片框
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 100, 100, 420, 250, $picture);
    # 裁剪图像（百分比值）
    $picFrame->getPictureFormat()->setCropLeft(23.6);
    $picFrame->getPictureFormat()->setCropRight(21.5);
    $picFrame->getPictureFormat()->setCropTop(3);
    $picFrame->getPictureFormat()->setCropBottom(31);
    # 保存结果
    $pres->save($outPptxFile, SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **删除图片的裁剪区域**

如果您想删除框中图像的裁剪区域，可以使用 [deletePictureCroppedAreas()](https://reference.aspose.com/slides/php-java/aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) 方法。若无需裁剪，该方法返回原始图像或裁剪后的图像。

以下 PHP 代码演示该操作：
```php
  $presentation = new Presentation("PictureFrameCrop.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # 从第一张幻灯片获取 PictureFrame
    $picFrame = $slide->getShapes()->get_Item(0);
    # 删除 PictureFrame 图像的裁剪区域并返回裁剪后的图像
    $croppedImage = $picFrame->getPictureFormat()->deletePictureCroppedAreas();
    # 保存结果
    $presentation->save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


{{% alert title="NOTE" color="warning" %}} 
[deletePictureCroppedAreas()] 方法会将裁剪后的图像添加到演示文稿的图像集合中。如果该图像仅在处理后的 [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) 中使用，此设置可以减小演示文稿的大小。否则，生成的演示文稿中的图像数量会增加。

该方法在裁剪操作中会将 WMF/EMF 元文件转换为光栅 PNG 图像。 
{{% /alert %}}

## **锁定宽高比**

如果您希望包含图像的形状在更改图像尺寸后仍保持宽高比，可使用 [setAspectRatioLocked](https://reference.aspose.com/slides/php-java/aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) 方法来设置 *锁定宽高比* 参数。

以下 PHP 代码演示如何锁定形状的宽高比：
```php
  $pres = new Presentation("pres.pptx");
  try {
    $layout = $pres->getLayoutSlides()->getByType(SlideLayoutType::Custom);
    $emptySlide = $pres->getSlides()->addEmptySlide($layout);
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $pictureFrame = $emptySlide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $presImage->getWidth(), $presImage->getHeight(), $picture);
    # 设置形状在调整大小时保持宽高比
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert title="NOTE" color="warning" %}} 
此 *锁定宽高比* 设置仅保留形状的宽高比，而不影响其内部的图像。 
{{% /alert %}}

## **使用 StretchOff 属性**

通过使用来自 [IPictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat) 接口和 [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat) 类的 [StretchOffsetLeft](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-) 、 [StretchOffsetTop](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat#setStretchOffsetTop--) 、 [StretchOffsetRight](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat#setStretchOffsetRight--) 和 [StretchOffsetBottom](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) 属性，您可以指定填充矩形。

当对图像指定拉伸时，源矩形会缩放以适应指定的填充矩形。填充矩形的每一边由相对于形状边界框相应边缘的百分比偏移定义。正百分比表示内缩，负百分比表示外扩。

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentatio) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 添加一个矩形 `AutoShape`。  
4. 创建图像。  
5. 设置形状的填充类型。  
6. 设置形状的图片填充模式。  
7. 添加已设置的图像以填充形状。  
8. 指定图像相对于形状边界框对应边缘的偏移。  
9. 将修改后的演示文稿写入为 PPTX 文件。  

以下 PHP 代码演示使用 StretchOff 属性的过程：
```php
  # 实例化 Prseetation 类，该类表示 PPTX 文件
  $pres = new Presentation();
  try {
    # 获取第一张幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 实例化 ImageEx 类
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # 添加一个矩形 AutoShape
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # 设置形状的填充类型
    $aShape->getFillFormat()->setFillType(FillType::Picture);
    # 设置形状的图片填充模式
    $aShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    # 设置用于填充形状的图像
    $aShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # 指定图像相对于形状边界框相应边缘的偏移量
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetLeft(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetRight(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetTop(-20);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetBottom(-10);
    # 将 PPTX 文件写入磁盘
    $pres->save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**如何了解 PictureFrame 支持的图像格式？**  
Aspose.Slides 通过分配给 [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) 的图像对象支持光栅图像（PNG、JPEG、BMP、GIF 等）和矢量图像（例如 SVG）。支持的格式列表通常与幻灯片和图像转换引擎的功能相重叠。

**大量添加大图像会如何影响 PPTX 文件大小和性能？**  
嵌入大图像会增加文件大小和内存使用；使用链接方式添加图像可以降低演示文稿大小，但需确保外部文件保持可访问。Aspose.Slides 提供通过链接添加图像的功能，以减小文件体积。

**如何锁定图像对象以防止意外移动/调整大小？**  
可对 [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) 使用 [shape locks](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/getpictureframelock/)，例如禁用移动或调整大小。锁定机制在单独的 [保护文章](/slides/zh/php-java/applying-protection-to-presentation/) 中有说明，适用于包括 [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) 在内的多种形状类型。

**导出演示文稿为 PDF/图像时，SVG 矢量保真度是否得以保留？**  
Aspose.Slides 允许从 [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) 中提取原始 SVG 矢量。导出为 PDF 或光栅格式时，结果可能会根据导出设置而光栅化；提取行为表明原始 SVG 仍以矢量形式存储。