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
- 图片框格式设置
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

图片框是一种包含图像的形状——它就像装在相框中的图片。

您可以通过图片框向幻灯片添加图像。这样，您可以通过格式化图片框来格式化图像。

{{% alert  title="Tip" color="primary" %}} 

Aspose 提供免费转换器——[JPEG 转 PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) 和 [PNG 转 PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)——允许用户快速从图像创建演示文稿。 

{{% /alert %}} 

## **创建图片框**

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 通过向与演示对象关联的 [Imagescollection](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/) 添加图像来创建 [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) 对象，该对象将用于填充形状。  
4. 指定图像的宽度和高度。  
5. 通过与引用的幻灯片关联的形状对象公开的 `addPictureFrame` 方法，根据图像的宽度和高度创建 [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/)。  
6. 将图片框（包含图片）添加到幻灯片。  
7. 将修改后的演示文稿写入为 PPTX 文件。  

下面的 PHP 代码演示如何创建图片框：
```php
  # 实例化表示 PPTX 文件的 Presentation 类
  $pres = new Presentation();
  try {
    # 获取第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 实例化 Image 类
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # 添加一个图片框，宽高与图片等同
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

图片框使您能够快速基于图像创建演示文稿幻灯片。当您将图片框与 Aspose.Slides 的保存选项结合使用时，您可以操控输入/输出操作，以实现图像格式之间的转换。您可能想查看以下页面：转换 [image to JPG](https://products.aspose.com/slides/php-java/conversion/image-to-jpg/)；转换 [JPG to image](https://products.aspose.com/slides/php-java/conversion/jpg-to-image/)；转换 [JPG to PNG](https://products.aspose.com/slides/php-java/conversion/jpg-to-png/)，转换 [PNG to JPG](https://products.aspose.com/slides/php-java/conversion/png-to-jpg/)；转换 [PNG to SVG](https://products.aspose.com/slides/php-java/conversion/png-to-svg/)，转换 [SVG to PNG](https://products.aspose.com/slides/php-java/conversion/svg-to-png/)。 

{{% /alert %}}

## **创建具有相对比例的图片框**

通过改变图像的相对缩放，您可以创建更复杂的图片框。

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 向演示文稿的图像集合中添加图像。  
4. 通过向与演示对象关联的 [Imagescollection](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/) 添加图像来创建 [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) 对象，该对象将用于填充形状。  
5. 在图片框中指定图像的相对宽度和高度。  
6. 将修改后的演示文稿写入为 PPTX 文件。  

下面的 PHP 代码演示如何创建具有相对比例的图片框：
```php
  # 实例化表示 PPTX 的 Presentation 类
  $pres = new Presentation();
  try {
    # 获取第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 实例化 Image 类
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # 添加一个宽高等同于图片的图片框
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # 设置相对缩放的宽度和高度
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

您可以从 [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) 对象中提取光栅图像，并将其保存为 PNG、JPG 等格式。下面的代码示例演示如何从文档 “sample.pptx” 中提取图像并保存为 PNG 格式。
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

当演示文稿在 [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) 形状中包含 SVG 图形时，Aspose.Slides for PHP via Java 允许您以完整保真度检索原始矢量图像。通过遍历幻灯片的形状集合，您可以识别每个 [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/)，检查其底层的 [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) 是否包含 SVG 内容，然后将该图像以原生 SVG 格式保存到磁盘或流中。

下面的代码示例演示如何从图片框中提取 SVG 图像：
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

Aspose.Slides 允许您获取应用于图像的透明度效果。以下 PHP 代码演示此操作：
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


## **图片框格式设置**

Aspose.Slides 提供许多可应用于图片框的格式设置选项。使用这些选项，您可以更改图片框以满足特定需求。

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 通过向与演示对象关联的 [Imagescollection](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/) 添加图像来创建 [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) 对象，该对象将用于填充形状。  
4. 指定图像的宽度和高度。  
5. 通过与引用的幻灯片关联的 [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/) 对象公开的 [addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addpictureframe/) 方法，根据图像的宽度和高度创建 `PictureFrame`。  
6. 将图片框（包含图片）添加到幻灯片。  
7. 设置图片框的线条颜色。  
8. 设置图片框的线条宽度。  
9. 通过给定正值或负值旋转图片框。  
   * 正值使图像顺时针旋转。  
   * 负值使图像逆时针旋转。  
10. 将图片框（包含图片）添加到幻灯片。  
11. 将修改后的演示文稿写入为 PPTX 文件。  

下面的 PHP 代码演示图片框的格式设置过程：
```php
  # 实例化表示 PPTX 的 Presentation 类
  $pres = new Presentation();
  try {
    # 获取第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 实例化 Image 类
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # 添加图片框，宽高与图片等同
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

Aspose 最近开发了一个 [免费拼图制作器](https://products.aspose.app/slides/collage)。如果您需要 [合并 JPG/JPEG](https://products.aspose.app/slides/collage/jpg) 或 PNG 图像，或 [从照片创建网格](https://products.aspose.app/slides/collage/photo-grid)，可以使用此服务。 

{{% /alert %}}

## **将图像添加为链接**

为了避免演示文稿体积过大，您可以通过链接添加图像（或视频），而不是直接嵌入文件。以下 PHP 代码演示如何将图像和视频添加到占位符中：
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

以下 PHP 代码演示如何裁剪幻灯片上已有的图像：
```php
  $pres = new Presentation();
  # 创建新图像对象
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


## **删除图片框的裁剪区域**

如果您想删除框内图像的裁剪区域，可以使用 [deletePictureCroppedAreas()](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) 方法。该方法返回裁剪后的图像，若无需裁剪则返回原始图像。

以下 PHP 代码演示此操作：
```php
  $presentation = new Presentation("PictureFrameCrop.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # 获取第一张幻灯片上的 PictureFrame
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

[deletePictureCroppedAreas()](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) 方法会将裁剪后的图像添加到演示文稿的图像集合中。如果该图像仅在处理的 [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) 中使用，此设置可以减小演示文稿大小。否则，生成的演示文稿中的图像数量会增加。

此方法在裁剪操作中将 WMF/EMF 元文件转换为光栅 PNG 图像。 

{{% /alert %}}

## **锁定宽高比**

如果您希望包含图像的形状在更改图像尺寸后仍保持宽高比，可以使用 [setAspectRatioLocked](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) 方法设置 *锁定宽高比*。

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

*锁定宽高比* 设置仅保留形状本身的宽高比，而不影响其包含的图像。 

{{% /alert %}}

## **使用 StretchOff 属性**

通过 [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) 类的 [setStretchOffsetLeft](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/setstretchoffsetleft/)、[setStretchOffsetTop](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/setstretchoffsettop/)、[setStretchOffsetRight](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/setstretchoffsetright/) 和 [setStretchOffsetBottom](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/setstretchoffsetbottom/) 方法，您可以指定填充矩形。

当为图像指定拉伸时，会将源矩形按比例缩放以适应指定的填充矩形。填充矩形的每条边由相对于形状边界框对应边缘的百分比偏移定义。正百分比表示内收，负百分比表示外伸。

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 添加一个矩形 `AutoShape`。  
4. 创建图像。  
5. 设置形状的填充类型。  
6. 设置形状的图片填充模式。  
7. 添加用于填充形状的设定图像。  
8. 指定图像相对于形状边界框对应边缘的偏移。  
9. 将修改后的演示文稿写入为 PPTX 文件。  

下面的 PHP 代码演示使用 StretchOff 属性的过程：
```php
  # 实例化表示 PPTX 文件的 Presentation 类
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
    # 添加一个设置为矩形的 AutoShape
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # 设置形状的填充类型
    $aShape->getFillFormat()->setFillType(FillType::Picture);
    # 设置形状的图片填充模式
    $aShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    # 设置图像以填充形状
    $aShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # 指定图像相对于形状边界框对应边缘的偏移量
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

**如何查找 PictureFrame 支持的图像格式？**

Aspose.Slides 通过分配给 [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) 的图像对象支持光栅图像（PNG、JPEG、BMP、GIF 等）和矢量图像（例如 SVG）。受支持的格式列表通常与幻灯片和图像转换引擎的功能重叠。

**添加大量大图像会如何影响 PPTX 大小和性能？**

嵌入大图像会增加文件大小和内存使用；链接图像有助于保持演示文稿体积较小，但需要外部文件保持可访问。Aspose.Slides 提供通过链接添加图像的功能，以减少文件大小。

**如何锁定图像对象防止意外移动/调整大小？**

对 [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) 使用 [shape locks](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/getpictureframelock/)（例如禁用移动或调整大小）。锁定机制在单独的 [保护文章](/slides/zh/php-java/applying-protection-to-presentation/) 中描述，支持包括 [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) 在内的多种形状类型。

**导出演示文稿为 PDF/图像时，SVG 矢量保真度是否得到保留？**

Aspose.Slides 允许从 [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) 中提取原始矢量 SVG。导出为 PDF（/slides/php-java/convert-powerpoint-to-pdf/）或光栅格式（/slides/php-java/convert-powerpoint-to-png/）时，结果可能会根据导出设置被光栅化；提取行为确认原始 SVG 仍以矢量形式存储。