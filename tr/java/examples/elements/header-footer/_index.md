---
title: Üstbilgi Altbilgi
type: docs
weight: 220
url: /tr/java/examples/elements/header-footer/
keywords:
- kod örneği
- üstbilgi
- altbilgi
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile slayt üstbilgilerini ve altbilgilerini kontrol edin: PPT, PPTX ve ODP dosyalarında tarih, slayt numarası ve özel metin ekleyin, Java örnekleriyle."
---
Bu makale, **Aspose.Slides for Java** kullanarak altbilgi eklemeyi ve tarih ve saat yer tutucularını güncellemeyi gösterir.

## **Altbilgi Ekle**

Bir slaytın altbilgi alanına metin ekleyin ve görünür hale getirin.

```java
static void addHeaderFooter() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setFooterText("My footer");
        slide.getHeaderFooterManager().setFooterVisibility(true);
    } finally {
        presentation.dispose();
    }
}
```

## **Tarih ve Saati Güncelle**

Bir slayttaki tarih ve saat yer tutucusunu değiştirin.

```java
static void updateDateTime() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setDateTimeText("01/01/2024");
        slide.getHeaderFooterManager().setDateTimeVisibility(true);
    } finally {
        presentation.dispose();
    }
}
```