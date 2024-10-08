---
title: 画框
type: docs
weight: 10
url: /php-java/picture-frame/
keywords: "添加画框, 创建画框, 添加图片, 创建图片, 提取图片, StretchOff 属性, 画框格式, 画框属性, PowerPoint 演示文稿, Java, Aspose.Slides for PHP via Java"
description: "将画框添加到 PowerPoint 演示文稿中"

---

画框是包含图片的形状——就像框中的图片。

您可以通过画框将图片添加到幻灯片中。通过这种方式，您可以通过格式化画框来格式化图片。

{{% alert  title="提示" color="primary" %}} 

Aspose 提供免费的转换器——[JPEG 转 PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) 和 [PNG 转 PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)——允许用户快速从图片创建演示文稿。

{{% /alert %}} 

## **创建画框**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 通过将图片添加到与演示文稿对象关联的 [IImagescollection](https://reference.aspose.com/slides/php-java/aspose.slides/IImageCollection) 中，创建一个 [IPPImage]() 对象，该对象将用于填充形状。
4. 指定图片的宽度和高度。
5. 通过与引用幻灯片关联的形状对象暴露的 `AddPictureFrame` 方法，根据图片的宽度和高度创建一个 [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/PictureFrame)。
6. 将画框（包含图片）添加到幻灯片。
7. 将修改后的演示文稿写入 PPTX 文件。

以下 PHP 代码展示了如何创建一个画框：

```php
  # 实例化表示 PPTX 文件的 Presentation 类
  $pres = new Presentation();
  try {
    # 获取第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 实例化 Image 类
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # 添加与图片高度和宽度等效的画框
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

画框允许您快速根据图片创建演示幻灯片。当您将画框与 Aspose.Slides 的保存选项结合使用时，您可以操纵输入/输出操作以将图片从一种格式转换为另一种格式。您可能想查看这些页面：转换 [image to JPG](https://products.aspose.com/slides/php-java/conversion/image-to-jpg/); 转换 [JPG to image](https://products.aspose.com/slides/php-java/conversion/jpg-to-image/); 转换 [JPG to PNG](https://products.aspose.com/slides/php-java/conversion/jpg-to-png/)，转换 [PNG to JPG](https://products.aspose.com/slides/php-java/conversion/png-to-jpg/); 转换 [PNG to SVG](https://products.aspose.com/slides/php-java/conversion/png-to-svg/)，转换 [SVG to PNG](https://products.aspose.com/slides/php-java/conversion/svg-to-png/)。

{{% /alert %}}

## **使用相对比例创建画框**

通过改变图片的相对缩放，您可以创建更复杂的画框。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。 
3. 将图片添加到演示文稿图片集合中。
4. 通过将图片添加到与演示文稿对象关联的 [IImagescollection](https://reference.aspose.com/slides/php-java/aspose.slides/IImageCollection) 中，创建一个 [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage) 对象，该对象将用于填充形状。
5. 在画框中指定图片的相对宽度和高度。
6. 将修改后的演示文稿写入 PPTX 文件。

以下 PHP 代码展示了如何使用相对比例创建画框：

```php
  # 实例化表示 PPTX 的 Presentation 类
  $pres = new Presentation();
  try {
    # 获取第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 实例化 Image 类
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # 添加与图片高度和宽度等效的画框
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

## **从画框提取图像**

您可以从 [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/PictureFrame) 对象提取图像并将其保存为 PNG、JPG 和其他格式。以下代码示例演示如何从文档 "sample.pptx" 中提取图像并以 PNG 格式保存。

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

## **获取图像的透明度**

Aspose.Slides 允许您获取图像的透明度。以下 PHP 代码演示了该操作：

```php
  $presentation = new Presentation($folderPath . "Test.pptx");
  $pictureFrame = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
  foreach($imageTransform as $effect) {
    if (java_instanceof($effect, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
      $alphaModulateFixed = $effect;
      $transparencyValue = 100 - $alphaModulateFixed->getAmount();
      echo("图片透明度: " . $transparencyValue);
    }
  }
```

## **画框格式化**

Aspose.Slides 提供了许多可应用于画框的格式选项。使用这些选项，您可以更改画框以使其符合特定要求。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。 
3. 通过将图片添加到与演示文稿对象关联的 [IImagescollection](https://reference.aspose.com/slides/php-java/aspose.slides/IImageCollection) 中，创建一个 [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage) 对象，该对象将用于填充形状。
4. 指定图片的宽度和高度。
5. 通过与引用幻灯片关联的 [IShapes](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection) 对象暴露的 [AddPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) 方法，根据图片的宽度和高度创建一个 `PictureFrame`。
6. 将画框（包含图片）添加到幻灯片。
7. 设置画框的线条颜色。
8. 设置画框的线条宽度。
9. 通过给出正值或负值旋转画框。
   * 正值顺时针旋转图像。 
   * 负值逆时针旋转图像。
10. 将画框（包含图片）添加到幻灯片。
11. 将修改后的演示文稿写入 PPTX 文件。

以下 PHP 代码演示了画框格式化过程：

```php
  # 实例化表示 PPTX 的 Presentation 类
  $pres = new Presentation();
  try {
    # 获取第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 实例化 Image 类
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # 添加与图片高度和宽度等效的画框
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # 对 PictureFrameEx 应用一些格式
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

{{% alert title="提示" color="primary" %}}

Aspose 最近开发了一个 [免费的拼贴制作器](https://products.aspose.app/slides/collage)。如果您需要 [合并 JPG/JPEG](https://products.aspose.app/slides/collage/jpg) 或 PNG 图片，或者 [从照片创建网格](https://products.aspose.app/slides/collage/photo-grid)，您可以使用该服务。 

{{% /alert %}}

## **将图片添加为链接**

为了避免演示文稿文件过大，您可以通过链接添加图片（或视频），而不是将文件直接嵌入演示文稿中。以下 PHP 代码展示了如何将图片和视频添加到占位符中：

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

以下 PHP 代码展示了如何裁剪幻灯片上的现有图像：

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
    # 将 PictureFrame 添加到幻灯片
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

## 删除图像裁剪区域

如果您想删除框中的图像的裁剪区域，可以使用 [deletePictureCroppedAreas()](https://reference.aspose.com/slides/php-java/aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) 方法。此方法返回裁剪后的图像或在不需要裁剪的情况下返回原始图像。

以下 PHP 代码演示该操作：

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

{{% alert title="注意" color="warning" %}} 

[deletePictureCroppedAreas()](https://reference.aspose.com/slides/php-java/aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) 方法将裁剪后的图像添加到演示文稿图像集合中。如果图像只在处理过的 [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) 中使用，该设置可以减少演示文稿大小。否则，生成的演示文稿中的图像数量将增加。

此方法在裁剪操作中将 WMF/EMF 元文件转换为光栅 PNG 图像。

{{% /alert %}}

## **锁定宽高比**

如果您希望包含图像的形状在更改图像大小后保持其宽高比，您可以使用 [setAspectRatioLocked](https://reference.aspose.com/slides/php-java/aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) 方法设置 *锁定宽高比* 设置。

以下 PHP 代码展示了如何锁定形状的宽高比：

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
    # 设置形状以保持在调整大小时保持宽高比
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="注意" color="warning" %}} 

此 *锁定宽高比* 设置仅保留形状的宽高比，而不保留其包含的图像的宽高比。

{{% /alert %}}

## **使用 StretchOff 属性**

使用 [StretchOffsetLeft](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-)、[StretchOffsetTop](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat#setStretchOffsetTop--)、[StretchOffsetRight](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat#setStretchOffsetRight--) 和 [StretchOffsetBottom](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) 属性来自 [IPictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat) 接口和 [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat) 类，您可以指定填充矩形。

当为图像指定拉伸时，源矩形将按比例缩放以适应指定的填充矩形。填充矩形的每条边通过相对于形状边界框相应边缘的百分比偏移量定义。正百分比表示内缩，负百分比表示外缩。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentatio) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 添加一个矩形 `AutoShape`。 
4. 创建一个图像。
5. 设置形状的填充类型。
6. 设置形状的图片填充模式。
7. 将设置的图像添加到填充形状。
8. 指定图像相对于形状的边界框的相应边缘的偏移量。
9. 将修改后的演示文稿写入 PPTX 文件。

以下 PHP 代码演示了使用 StretchOff 属性的过程：

```php
  # 实例化表示 PPTX 文件的 Prseetation 类
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
    # 添加设置为矩形的 AutoShape
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # 设置形状的填充类型
    $aShape->getFillFormat()->setFillType(FillType::Picture);
    # 设置形状的图片填充模式
    $aShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    # 设置图像以填充形状
    $aShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # 指定图像相对于形状的边界框的相应边缘的偏移量
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