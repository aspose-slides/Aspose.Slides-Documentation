---
title: VbaMakro
type: docs
weight: 150
url: /tr/php-java/examples/elements/vba-macro/
keywords:
- vba makro
- vba makro ekle
- vba makroya eriş
- vba makroyı kaldır
- kod örnekleri
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides kullanarak PHP'de VBA makrolarıyla çalışın: projeleri ve modülleri ekleyin veya düzenleyin, makroları imzalayın veya kaldırın ve sunumları PPT, PPTX ve ODP formatlarında kaydedin."
---
VBA makrolarını **Aspose.Slides for PHP via Java** kullanarak ekleme, erişme ve kaldırma işlemlerini gösterir.

## **VBA Makro Ekle**

VBA projesi ve basit bir makro modülü içeren bir sunum oluşturun.

```php
function addVbaMacro() {
    $presentation = new Presentation();
    try {
        $presentation->setVbaProject(new VbaProject());

        $module = $presentation->getVbaProject()->getModules()->addEmptyModule("Module");
        $module->setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

        $presentation->save("vba_macro.pptm", SaveFormat::Pptm);
    } finally {
        $presentation->dispose();
    }
}
```

## **VBA Makrosuna Eriş**

VBA projesinden ilk modülü alın.

```php
function accessVbaMacro() {
    $presentation = new Presentation("vba_macro.pptm");
    try {
        $firstModule = $presentation->getVbaProject()->getModules()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **VBA Makrosunu Kaldır**

VBA projesinden bir modülü silin.

```php
function removeVbaMacro() {
    $presentation = new Presentation("vba_macro.pptm");
    try {
        // VBA projesinde en az bir modül olduğunu varsayarak.
        $module = $presentation->getVbaProject()->getModules()->get_Item(0);

        $presentation->getVbaProject()->getModules()->remove($module);

        $presentation->save("vba_macro_removed.pptm", SaveFormat::Pptm);
    } finally {
        $presentation->dispose();
    }
}
```