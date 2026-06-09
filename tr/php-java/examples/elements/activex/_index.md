---
title: ActiveX
type: docs
weight: 200
url: /tr/php-java/examples/elements/activex/
keywords:
- ActiveX
- ActiveX denetimi
- ActiveX ekle
- ActiveX eriş
- ActiveX kaldır
- ActiveX özellikleri
- kod örnekleri
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "PHP'de Aspose.Slides kullanarak ActiveX denetimlerini bulma, düzenleme ve kaldırma, ayrıca PowerPoint sunumları için özellik güncellemelerini öğrenin."
---
Bir sunumda **Aspose.Slides for PHP via Java** kullanarak ActiveX denetimlerini ekleme, erişme, kaldırma ve yapılandırma işlemlerini gösterir.

## **ActiveX Denetimi Ekle**

Yeni bir ActiveX denetimi ekleyin.

```php
function addActiveX() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Yeni bir ActiveX denetimi ekleyin.
        $control = $slide->getControls()->addControl(ControlType::WindowsMediaPlayer, 50, 50, 100, 50);

        $presentation->save("activex.pptm", SaveFormat::Pptm);
    } finally {
        // Sunumu serbest bırakın.
        $presentation->dispose();
    }
}
```

## **ActiveX Denetimine Eriş**

Slayttaki ilk ActiveX denetiminden bilgileri okuyun.

```php
function accessActiveX() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // İlk ActiveX denetimine eriş.
        $control = $slide->getControls()->get_Item(0);

        echo "Control Name: " . $control->getName() . PHP_EOL;
    } finally {
        // Sunumu serbest bırak.
        $presentation->dispose();
    }
}
```

## **ActiveX Denetimini Kaldır**

Mevcut bir ActiveX denetimini slayttan silin.

```php
function removeActiveX() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        if (java_values($slide->getControls()->size()) > 0) {
            // İlk ActiveX denetimini kaldır.
            $slide->getControls()->removeAt(0);
        }

        $presentation->save("activex_removed.pptm", SaveFormat::Pptm);
    } finally {
        // Sunumu serbest bırak.
        $presentation->dispose();
    }
}
```

## **ActiveX Özelliklerini Ayarla**

Birçok ActiveX özelliğini yapılandırın.

```php
function setActiveXProperties() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // İlk denetimin eklediğimiz denetim olduğunu varsayıyoruz.
        $control = $slide->getControls()->get_Item(0);

        // Özellikleri yapılandır.
        $control->getProperties()->set_Item("Caption", "Click Me");
        $control->getProperties()->set_Item("Enabled", "true");

        $presentation->save("activex_properties.pptm", SaveFormat::Pptm);
    } finally {
        // Sunumu serbest bırak.
        $presentation->dispose();
    }
}
```