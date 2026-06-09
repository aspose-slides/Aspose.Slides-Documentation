---
title: Metin Kutusu
type: docs
weight: 40
url: /tr/php-java/examples/elements/text-box/
keywords:
- metin kutusu
- metin kutusu ekle
- metin kutusuna eriş
- metin kutusunu kaldır
- kod örnekleri
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides ile PHP'de metin kutuları oluşturun ve biçimlendirin: yazı tiplerini, hizalamayı, kaydırmayı, otomatik sığdırmayı ayarlayın ve PowerPoint ve OpenDocument için slaytları düzenlemeye yönelik bağlantılar ekleyin."
---
Aspose.Slides'ta, bir **metin kutusu** `AutoShape` tarafından temsil edilir. Neredeyse her şekil metin içerebilir, ancak tipik bir metin kutusunun dolgu veya kenarlığı yoktur ve sadece metin gösterir.

Bu kılavuz, metin kutularını programlı olarak nasıl ekleyeceğinizi, erişeceğinizi ve kaldıracağınızı açıklar.

## **Metin Kutusu Ekle**

Bir metin kutusu, dolgu ve kenarlığı olmayan ve içinde biçimlendirilmiş metin bulunan basit bir `AutoShape`'dır. İşte bir tane nasıl oluşturulur:

```php
function addTextBox() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Bir dikdörtgen şekil oluştur (varsayılan olarak kenarlıklı dolu ve metinsiz).
        $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 75, 150, 100);

        // Dolgu ve kenarlığı kaldırarak tipik bir metin kutusu gibi görünmesini sağla.
        $textBox->getFillFormat()->setFillType(FillType::NoFill);
        $textBox->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        // Metin biçimlendirmesini ayarla.
        $paragraph = $textBox->getTextFrame()->getParagraphs()->get_Item(0);
        $portionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
        $portionFormat->getFillFormat()->setFillType(FillType::Solid);
        $portionFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

        // Gerçek metin içeriğini ata.
        $textBox->getTextFrame()->setText("Some text...");

        $presentation->save("text_box.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Not:** Boş olmayan bir `TextFrame` içeren herhangi bir `AutoShape`, bir metin kutusu olarak işlev görebilir.

## **İçeriğe Göre Metin Kutularına Erişim**

Belirli bir anahtar kelimeyi (ör. "Slide") içeren tüm metin kutularını bulmak için şekiller üzerinde döngü yapın ve metinlerini kontrol edin:

```php
function accessTextBox() {
    $presentation = new Presentation("text_box.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Slayttaki ilk metin kutusuna eriş.
        $firstTextBox = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $firstTextBox = $shape;
                if (strpos($firstTextBox->getTextFrame()->getText(), "Slide") !== false) {
                    // Eşleşen metin kutusuyla bir şey yap.
                }
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **İçeriğe Göre Metin Kutularını Kaldırma**

Bu örnek, belirli bir anahtar kelimeyi içeren ilk slayttaki tüm metin kutularını bulur ve siler:

```php
function removeTextBoxes() {
    $presentation = new Presentation("text_box.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $shapesToRemove = [];

        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $autoShape = $shape;
                if (strpos($autoShape->getTextFrame()->getText(), "Slide") !== false) {
                    $shapesToRemove[] = $shape;
                }
            }
        }

        foreach ($shapesToRemove as $shape) {
            $slide->getShapes()->remove($shape);
        }

        $presentation->save("text_boxes_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **İpucu:** Döngü sırasında koleksiyonu değiştirmeden önce şekil koleksiyonunun bir kopyasını her zaman oluşturun; böylece koleksiyon değişikliği hatalarını önlersiniz.