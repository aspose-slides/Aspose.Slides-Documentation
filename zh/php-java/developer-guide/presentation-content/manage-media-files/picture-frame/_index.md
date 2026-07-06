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
description: "使用 Aspose.Slides for PHP via Java 向 PowerPoint 和 OpenDocument 演示文稿添加图片框。简化工作流程并提升幻灯片设计。"
---
## **介绍**

图片框是一种包含图像的形状——它就像框中的照片。

您可以通过图片框将图像添加到幻灯片中。这样，您可以通过格式化图片框来格式化图像。

{{% alert  title="Tip" color="primary" %}} 
Aspose 提供免费转换器——[JPEG 转 PowerPoint](https://products.aspose.app/slides/zh/import/jpg-to-ppt) 和 [PNG 转 PowerPoint](https://products.aspose.app/slides/zh/import/png-to-ppt)——可帮助用户快速从图像创建演示文稿。 
{{% /alert %}} 

## **创建图片框**

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 通过向与演示对象关联的 [ImageCollection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/imagecollection/) 添加图像，创建一个 [PPImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/ppimage/) 对象，用于填充形状。  
4. 指定图像的宽度和高度。  
5. 通过引用幻灯片关联的形状对象公开的 `addPictureFrame` 方法，基于图像的宽度和高度创建一个 [PictureFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/pictureframe/)。  
6. 将图片框（包含图片）添加到幻灯片。  
7. 将修改后的演示文稿写入为 PPTX 文件。  

以下 PHP 代码演示如何创建图片框：

```php
  # 实例化表示 PPTX 文件的 Presentation 类
  $pres = new Presentation();
  try {
    # 获取第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 实例化 Image 类
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # 添加图片框，宽高与图片相同
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
图片框使您能够快速基于图像创建演示幻灯片。当您将图片框与 Aspose.Slides 的保存选项结合使用时，可以操作输入/输出以将图像从一种格式转换为另一种格式。您可能想查看以下页面：转换 [图像为 JPG](https://products.aspose.com/slides/zh/php-java/conversion/image-to-jpg/)；转换 [JPG 为图像](https://products.aspose.com/slides/zh/php-java/conversion/jpg-to-image/)；转换 [JPG 为 PNG](https://products.aspose.com/slides/zh/php-java/conversion/jpg-to-png/)；转换 [PNG 为 JPG](https://products.aspose.com/slides/zh/php-java/conversion/png-to-jpg/)；转换 [PNG 为 SVG](https://products.aspose.com/slides/zh/php-java/conversion/png-to-svg/)；转换 [SVG 为 PNG](https://products.aspose.com/slides/zh/php-java/conversion/svg-to-png/)。 
{{% /alert %}}

## **使用相对比例创建图片框**

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 将图像添加到演示文稿的图像集合中。  
4. 通过向与演示对象关联的 [ImageCollection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/imagecollection/) 添加图像，创建一个 [PPImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/ppimage/) 对象，用于填充形状。  
5. 在图片框中指定图像的相对宽度和高度。  
6. 将修改后的演示文稿写入为 PPTX 文件。  

以下 PHP 代码演示如何使用相对比例创建图片框：

```php
  # 实例化表示 PPTX 的 Presentation 类
  $pres = new Presentation();
  try {
    # 获取第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 实例化 Image 类
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # 添加图片框，宽高与图片相同
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # 设置相对比例的宽度和高度
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

您可以从 [PictureFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/pictureframe/) 对象中提取光栅图像，并将其保存为 PNG、JPG 等格式。下面的代码示例演示如何从文档 “sample.pptx” 中提取图像并保存为 PNG 格式。

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

当演示文稿在 [PictureFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/pictureframe/) 形状中包含 SVG 图形时，Aspose.Slides for PHP via Java 可让您完整保真地检索原始矢量图像。通过遍历幻灯片的形状集合，您可以识别每个 [PictureFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/pictureframe/)，检查其底层的 [PPImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/ppimage/) 是否包含 SVG 内容，然后将该图像以原始 SVG 格式保存到磁盘或流中。

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

## **获取图像的亮度和对比度**

Aspose.Slides 允许您获取应用于图像的亮度和对比度效果。[Luminance](https://reference.aspose.com/slides/zh/php-java/aspose.slides/luminance/) 类表示此图像转换效果。

以下 PHP 代码演示如何从图片框获取亮度和对比度设置：

```php
  $presentation = new Presentation("sample.pptx");

  try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $pictureFrame = $shape;

    $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
    $imageTransformCount = java_values($imageTransform->size());
    for ($index = 0; $index < $imageTransformCount; $index++) {
      $effect = $imageTransform->get_Item($index);
      if (java_instanceof($effect, new JavaClass("com.aspose.slides.Luminance"))) {
        $luminance = $effect->getEffective();
        $brightness = java_values($luminance->getBrightness());
        $contrast = java_values($luminance->getContrast());

        echo("Brightness: " . $brightness . PHP_EOL);
        echo("Contrast: " . $contrast . PHP_EOL);
      }
    }
  } finally {
    $presentation->dispose();
  }
```

## **图片框格式化**

Aspose.Slides 提供了许多可应用于图片框的格式化选项。使用这些选项，您可以更改图片框以满足特定需求。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 通过向与演示对象关联的 [ImageCollection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/imagecollection/) 添加图像，创建一个 [PPImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/ppimage/) 对象，用于填充形状。  
4. 指定图像的宽度和高度。  
5. 通过引用幻灯片关联的 [ShapeCollection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shapecollection/) 对象公开的 [addPictureFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shapecollection/addpictureframe/) 方法，基于图像的宽度和高度创建一个 `PictureFrame`。  
6. 将图片框（包含图片）添加到幻灯片。  
7. 设置图片框的线条颜色。  
8. 设置图片框的线条宽度。  
9. 通过给定正值或负值旋转图片框。  
   * 正值会顺时针旋转图像。  
   * 负值会逆时针旋转图像。  
10. 将图片框（包含图片）添加到幻灯片。  
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
    # 添加图片框，宽高与图片相同
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # 对 PictureFrameEx 应用一些格式化
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

Aspose 最近推出了一个 [免费拼贴制作工具](https://products.aspose.app/slides/zh/collage)。如果您需要 [合并 JPG/JPEG](https://products.aspose.app/slides/zh/collage/jpg) 或 PNG 图像，或 [从照片创建网格](https://products.aspose.app/slides/zh/collage/photo-grid)，可使用此服务。 

{{% /alert %}}

## **将图像添加为链接**

为了避免演示文稿体积过大，您可以通过链接添加图像（或视频），而不是将文件直接嵌入到演示文稿中。以下 PHP 代码演示如何将图像和视频添加到占位符中：

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

以下 PHP 代码演示如何裁剪幻灯片上的现有图像：

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
    # 向幻灯片添加 PictureFrame
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

如果您想删除框中图像的裁剪区域，可以使用 [deletePictureCroppedAreas()](https://reference.aspose.com/slides/zh/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) 方法。若无需裁剪，该方法返回原始图像。

以下 PHP 代码演示此操作：

```php
  $presentation = new Presentation("PictureFrameCrop.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # 获取第一张幻灯片中的 PictureFrame
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
[deletePictureCroppedAreas()] 方法会将裁剪后的图像添加到演示文稿的图像集合中。如果该图像仅在处理过的 [PictureFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/pictureframe/) 中使用，则此设置可以减小演示文稿的大小。否则，生成的演示文稿中的图像数量会增加。

该方法在裁剪操作中会将 WMF/EMF 元文件转换为光栅 PNG 图像。 
{{% /alert %}}

## **压缩图像**

您可以使用 [PictureFillFormat::compressImage()](https://reference.aspose.com/slides/zh/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) 方法压缩演示文稿中的图片。该方法通过根据形状大小和指定的分辨率来减小图像尺寸，并可选择删除裁剪区域。

它会像 PowerPoint 的 **图片格式 -> 压缩图片 -> 分辨率** 功能一样调整图片的大小和分辨率。

以下 PHP 示例演示如何通过指定目标分辨率并可选地删除裁剪区域来压缩演示文稿中的图像：

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # 使用目标分辨率 150 DPI（网页分辨率）压缩图像并删除裁剪区域。
    $result = $pictureFrame->getPictureFormat()->compressImage(true, PicturesCompression::Dpi150);

    # 检查压缩结果。
    if ($result) {
        echo "Image successfully compressed.";
    } else {
        echo "Image compression failed or no changes were necessary.";
    }

    $presentation->save("CompressedImage.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

或者直接使用自定义 DPI 值：

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # 将图像压缩至 150 DPI（网页分辨率），并删除裁剪区域。
    $pictureFrame->getPictureFormat()->compressImage(true, 150.0);

    $presentation->save("CompressedImage.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
该方法会根据形状的大小和提供的 DPI 将图像转换为较低分辨率。裁剪区域也可以被删除以优化文件大小。  
如果图像是元文件（WMF/EMF）或 SVG，则不会进行压缩。JPEG 的质量将根据分辨率保持或略有降低，类似于 PowerPoint 处理高分辨率 JPEG 的方式。 
{{% /alert %}}

## **锁定宽高比**

如果您希望包含图像的形状在更改图像尺寸后仍保持宽高比，可使用 [setAspectRatioLocked](https://reference.aspose.com/slides/zh/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) 方法设置 *锁定宽高比*。 

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
此 *锁定宽高比* 设置仅保持形状的宽高比，而不影响其包含的图像。 
{{% /alert %}}

## **使用 StretchOff 属性**

通过 [PictureFillFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/picturefillformat/) 类的 [setStretchOffsetLeft](https://reference.aspose.com/slides/zh/php-java/aspose.slides/picturefillformat/setstretchoffsetleft/)、[setStretchOffsetTop](https://reference.aspose.com/slides/zh/php-java/aspose.slides/picturefillformat/setstretchoffsettop/)、[setStretchOffsetRight](https://reference.aspose.com/slides/zh/php-java/aspose.slides/picturefillformat/setstretchoffsetright/) 和 [setStretchOffsetBottom](https://reference.aspose.com/slides/zh/php-java/aspose.slides/picturefillformat/setstretchoffsetbottom/) 方法，您可以指定填充矩形。

当对图像指定拉伸时，源矩形会按比例缩放以适应指定的填充矩形。填充矩形的每条边由相对于形状边界框对应边的百分比偏移定义。正百分比表示向内收缩，负百分比表示向外扩展。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 添加一个矩形 `AutoShape`。  
4. 创建图像。  
5. 设置形状的填充类型。  
6. 设置形状的图片填充模式。  
7. 添加已设置的图像以填充形状。  
8. 指定图像相对于形状边界框对应边的偏移量。  
9. 将修改后的演示文稿写入为 PPTX 文件。  

以下 PHP 代码演示使用 StretchOff 属性的过程：

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
    # 添加设为矩形的 AutoShape
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # 设置形状的填充类型
    $aShape->getFillFormat()->setFillType(FillType::Picture);
    # 设置形状的图片填充模式
    $aShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    # 设置用于填充形状的图像
    $aShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # 指定图像相对于形状边界框对应边的偏移量
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

## **常见问题**

**如何查找支持的 PictureFrame 图像格式？**  
Aspose.Slides 通过分配给 PictureFrame 的图像对象支持光栅图像（PNG、JPEG、BMP、GIF 等）和矢量图像（例如 SVG）。支持的格式列表通常与幻灯片和图像转换引擎的功能相吻合。

**大量添加大图像会如何影响 PPTX 大小和性能？**  
嵌入大图像会增加文件大小和内存占用；使用链接图像可以保持演示文稿体积较小，但需要确保外部文件可访问。Aspose.Slides 提供通过链接添加图像以减小文件大小的功能。

**如何锁定图像对象防止意外移动/缩放？**  
使用针对 PictureFrame 的 [shape locks](https://reference.aspose.com/slides/zh/php-java/aspose.slides/pictureframe/getpictureframelock/)（例如，禁用移动或缩放）即可锁定图像对象。该锁定机制支持包括 PictureFrame 在内的多种形状类型。

**导出演示文稿为 PDF/图像时，SVG 矢量保真度是否得到保留？**  
Aspose.Slides 允许从 PictureFrame 中提取原始矢量 SVG。导出为 PDF 或光栅格式时，结果可能会根据导出设置被栅格化；但原始 SVG 以矢量形式存储的事实可通过提取行为得到验证。