---
title: Üst Bilgi Alt Bilgi
type: docs
weight: 220
url: /tr/nodejs-java/examples/elements/header-footer/
keywords:
- kod örneği
- üst bilgi
- alt bilgi
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js ile slayt üst ve alt bilgilerini kontrol edin: PPT, PPTX ve ODP dosyalarında tarih, slayt numarası ve özel metin ekleyin; JavaScript örnekleriyle."
---
Bu makale, **Aspose.Slides for Node.js via Java** kullanarak alt bilgi eklemeyi ve tarih ve saat yer tutucularını güncellemeyi gösterir.

## **Alt Bilgi Ekle**

Bir slaydın alt bilgi alanına metin ekleyin ve görünür hale getirin.

```js
function addHeaderFooter() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setFooterText("My footer");
        slide.getHeaderFooterManager().setFooterVisibility(true);

        presentation.save("header_footer.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Tarih ve Saati Güncelle**

Bir slayttaki tarih ve saat yer tutucusunu değiştirin.

```js
function updateDateTime() {
    let presentation = new aspose.slides.Presentation("header_footer.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setDateTimeText("01/01/2024");
        slide.getHeaderFooterManager().setDateTimeVisibility(true);

        presentation.save("header_footer_updated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```