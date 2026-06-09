---
title: Mürekkep
type: docs
weight: 180
url: /tr/php-java/examples/elements/ink/
keywords:
- mürekkep
- mürekkebe erişim
- mürekkebi kaldır
- kod örnekleri
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides ile PHP'de slaytlarda dijital mürekkebi yönetin: kalem darbeleri ekleyin, yolları düzenleyin, renk ve kalınlığı ayarlayın ve sonuçları PowerPoint ve OpenDocument için dışa aktarın."
---
Mevcut mürekkep şekillerine erişim ve bunları **Aspose.Slides for PHP via Java** kullanarak kaldırma örneklerini sağlar.

> ❗ **Not:** Mürekkep şekilleri, özel cihazlardan gelen kullanıcı girdilerini temsil eder. Aspose.Slides programlı olarak yeni mürekkep darbeleri oluşturamaz, ancak mevcut mürekkebi okuyabilir ve değiştirebilirsiniz.

## **Mürekkebe Erişim**

Bir slayttaki ilk mürekkep şeklini alın.

```php
function accessInk() {
    $presentation = new Presentation("ink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Slayttaki ilk mürekkep şekline eriş.
        $firstInk = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Ink"))) {
                $firstInk = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Mürekkebi Kaldır**

Slayttan bir mürekkep şekli silin.

```php
function removeInk() {
    $presentation = new Presentation("ink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Slayttaki ilk şeklin bir mürekkep şekli olduğunu varsayarak.
        $ink = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($ink);

        $presentation->save("ink_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```