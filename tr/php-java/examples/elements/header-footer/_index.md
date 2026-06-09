---
title: ÜstbilgiAltbilgi
type: docs
weight: 220
url: /tr/php-java/examples/elements/header-footer/
keywords:
- üstbilgi altbilgi
- üstbilgi ve altbilgi ekle
- üstbilgi ve altbilgi güncelle
- kod örnekleri
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides ile PHP'de üstbilgi ve altbilgi kontrolü: tarih/saat, slayt numaraları ve altbilgi metnini ekleyin veya düzenleyin, PPT, PPTX ve ODP'de yer tutucuları gösterin veya gizleyin."
---
**Aspose.Slides for PHP via Java** kullanarak altbilgiler eklemeyi ve tarih ve saat yer tutucularını güncellemeyi gösterir.

## **Altbilgi Ekle**

Bir slaydın altbilgi alanına metin ekleyin ve görünür hâle getirin.

```php
function addHeaderFooter() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getHeaderFooterManager()->setFooterText("My footer");
        $slide->getHeaderFooterManager()->setFooterVisibility(true);

        $presentation->save("footer.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Tarih ve Zamanı Güncelle**

Bir slayttaki tarih ve saat yer tutucusunu değiştirin.

```php
function updateDateTime() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getHeaderFooterManager()->setDateTimeText("01/01/2024");
        $slide->getHeaderFooterManager()->setDateTimeVisibility(true);

        $presentation->save("datetime.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```