---
title: 画像
type: docs
weight: 50
url: /ja/php-java/examples/elements/picture/
keywords:
- 画像
- 画像フレーム
- 画像の追加
- 画像の取得
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides を使用して PHP で画像を操作します：挿入、置換、トリミング、圧縮、透明度とエフェクトの調整、シェイプへの塗り付け、そして PPT、PPTX、ODP へのエクスポート。"
---
**Aspose.Slides for PHP via Java** を使用して画像の挿入とアクセス方法を示します。以下の例では、スライドに画像を配置し、取得します。

## **画像の追加**

このコードは、最初のスライドに画像フレームとして画像を挿入します。

```php
function addPicture() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $image = $presentation->getImages()->addImage(
            new Java("java.io.FileInputStream", new Java("java.io.File", "image.jpg")));

        // 画像をプレゼンテーションのリソースに追加します。
        $ppImage = $presentation->getImages()->addImage($image);

        // 最初のスライドに画像を表示する画像フレームを挿入します。
        $slide->getShapes()->addPictureFrame(
            ShapeType::Rectangle, 50, 50, $ppImage->getWidth(), $ppImage->getHeight(), $ppImage);

        $presentation->save("picture.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **画像の取得**

この例では、スライドに画像フレームが含まれていることを確認し、見つかった最初のフレームにアクセスします。

```php
function accessPicture() {
    $presentation = new Presentation("picture.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // スライド上の最初のPictureFrameにアクセスします。
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