---
title: ActiveX
type: docs
weight: 200
url: /tr/python-net/examples/elements/activex/
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
- Python
- Aspose.Slides
description: "Python'da Aspose.Slides ile ActiveX denetimlerini bulmayı, düzenlemeyi ve kaldırmayı, ayrıca PowerPoint sunumları için özellik güncellemelerini öğrenin."
---
Bir sunumda ActiveX denetimlerini ekleme, erişme, kaldırma ve yapılandırma işlemlerini **Aspose.Slides for Python via .NET** kullanarak gösterir.

## **ActiveX Denetimi Ekleme**

Yeni bir ActiveX denetimi ekleyin.

```py
def add_activex():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Yeni bir ActiveX denetimi (Metin Kutusu) ekleyin.
        control = slide.controls.add_control(slides.ControlType.WINDOWS_MEDIA_PLAYER, 50, 50, 100, 50)

        presentation.save("activex.pptm", slides.export.SaveFormat.PPTM)
```

## **ActiveX Denetimine Erişme**

Slayttaki ilk ActiveX denetiminden bilgi okuyun.

```py
def access_activex():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        # İlk ActiveX denetimine eriş.
        control = slide.controls[0] if slide.controls else None
        if control is not None:
            # Denetim adını yazdır.
            print(f"Control Name: {control.name}")
```

## **ActiveX Denetimini Kaldırma**

Slayttan mevcut bir ActiveX denetimini silin.

```py
def remove_activex():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        if len(slide.controls) > 0:
            # İlk ActiveX denetimini kaldır.
            slide.controls.remove_at(0)

        presentation.save("activex_removed.pptm", slides.export.SaveFormat.PPTM)
```

## **ActiveX Özelliklerini Ayarlama**

Birçok ActiveX özelliğini yapılandırın.

```py
def set_activex_properties():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        # Kontrol koleksiyonunun en az bir Kontrol içerdiğini varsayarak.
        control = slide.controls[0]

        control.properties.add("Caption", "Click Me")
        control.properties.add("Enabled", "true")

        presentation.save("activex_properties.pptm", slides.export.SaveFormat.PPTM)
```