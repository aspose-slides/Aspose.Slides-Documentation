---
title: ÜstbilgiAltbilgi
type: docs
weight: 220
url: /tr/python-net/examples/elements/header-footer/
keywords:
- üstbilgi altbilgi
- üstbilgi altbilgi ekle
- üstbilgi altbilgi güncelle
- tarih ve saat ayarla
- kod örnekleri
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides ile Python'da üstbilgi ve altbilgileri kontrol edin: tarih/saat, slayt numaraları ve altbilgi metnini ekleyin veya düzenleyin, PPT, PPTX ve ODP formatlarında yer tutucuları gösterin ya da gizleyin."
---
Aspose.Slides for Python via .NET kullanarak altbilgileri eklemeyi ve tarih ve saat yer tutucularını güncellemeyi gösterir.

## **Altbilgi Ekle**

Altbilgi alanına metin ekleyin ve görünür hale getirin.

```py
def add_footer():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        slide.header_footer_manager.set_footer_text("My footer")
        slide.header_footer_manager.set_footer_visibility(True)

        presentation.save("footer.pptx", slides.export.SaveFormat.PPTX)
```

## **Tarih ve Saati Güncelle**

Bir slayttaki tarih ve saat yer tutucusunu değiştirin.

```py
def add_date_time():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        slide.header_footer_manager.set_date_time_text("01/01/2024")
        slide.header_footer_manager.set_date_time_visibility(True)

        presentation.save("date_time.pptx", slides.export.SaveFormat.PPTX)
```