---
title: 图片
type: docs
weight: 50
url: /zh/php-java/examples/elements/picture/
keywords:
- 图片
- 图片框
- 添加图片
- 访问图片
- 代码示例
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "在 PHP 中使用 Aspose.Slides 处理图片：插入、替换、裁剪、压缩、调整透明度和效果、填充形状，并导出为 PPT、PPTX 和 ODP。"
---
展示如何使用 **Aspose.Slides for PHP via Java** 插入和访问图片。下面的示例将在幻灯片上放置图像，然后检索它。

## **添加图片**

此代码将在第一张幻灯片上插入图像作为图片框。

```php
function addPicture() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $image = $presentation->getImages()->addImage(
            new Java("java.io.FileInputStream", new Java("java.io.File", "image.jpg")));

        // 将图像添加到演示文稿资源中。
        $ppImage = $presentation->getImages()->addImage($image);

        // 在第一张幻灯片上插入显示该图像的图片框。
        $slide->getShapes()->addPictureFrame(
            ShapeType::Rectangle, 50, 50, $ppImage->getWidth(), $ppImage->getHeight(), $ppImage);

        $presentation->save("picture.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **访问图片**

此示例确保幻灯片包含图片框，然后访问它找到的第一个图片框。

```php
function accessPicture() {
    $presentation = new Presentation("picture.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 访问幻灯片上的第一个 PictureFrame。
        $firstPictureFrame = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
                $firstPictureFrame = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```