---
title: Resim
type: docs
weight: 50
url: /tr/php-java/examples/elements/picture/
keywords:
- resim
- resim çerçevesi
- resim ekle
- resme eriş
- kod örnekleri
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "PHP'de Aspose.Slides kullanarak resimlerle çalışın: ekleme, değiştirme, kırpma, sıkıştırma, şeffaflık ve efektleri ayarlama, şekilleri doldurma ve PPT, PPTX ve ODP için dışa aktarma."
---
Aspose.Slides for PHP via Java kullanarak resim ekleme ve erişme işlemlerini gösterir. Aşağıdaki örnekler bir resmi slayta ekler ve ardından onu alır.

## **Resim Ekle**

Bu kod bir resmi ilk slayta resim çerçevesi olarak ekler.

```php
function addPicture() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $image = $presentation->getImages()->addImage(
            new Java("java.io.FileInputStream", new Java("java.io.File", "image.jpg")));

        // Sunum kaynaklarına resmi ekle.
        $ppImage = $presentation->getImages()->addImage($image);

        // İlk slaytta resmi gösteren bir resim çerçevesi ekle.
        $slide->getShapes()->addPictureFrame(
            ShapeType::Rectangle, 50, 50, $ppImage->getWidth(), $ppImage->getHeight(), $ppImage);

        $presentation->save("picture.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Resme Erişim**

Bu örnek, bir slaydın bir resim çerçevesi içerdiğini doğrular ve ardından bulduğu ilk çerçeveye erişir.

```php
function accessPicture() {
    $presentation = new Presentation("picture.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Slayttaki ilk PictureFrame'e eriş.
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