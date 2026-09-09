---
title: Üstbilgi ve Altbilgi
type: docs
weight: 220
url: /tr/python-java/examples/elements/header-footer/
keywords:
- kod örneği
- üstbilgi
- altbilgi
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile slayt üstbilgilerini ve altbilgilerini yönetin: PPT, PPTX ve ODP sunumlarına tarih, slayt numarası ve özel metin ekleyin."
---
Bu makale, **Aspose.Slides for Python via Java** kullanarak altbilgileri eklemeyi ve tarih ve saat yer tutucularını güncellemeyi gösterir.

Paketi, [Installation](/slides/tr/python-java/installation/) bölümünde açıklandığı gibi kurun. Her örnek, JVM'yi başlatmadan önce `asposeslides` kütüphanesini içe aktarır, ardından JVM çalıştıktan sonra API'yi içe aktarır.

## **Altbilgi Ekle**

Bir slaydın altbilgi alanına metin ekleyin ve görünür hâle getirin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getHeaderFooterManager().setFooterText("My footer")
    slide.getHeaderFooterManager().setFooterVisibility(True)
finally:
    presentation.dispose()
```

## **Tarih ve Saati Güncelle**

Bir slayttaki tarih ve saat yer tutucusunu değiştirin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getHeaderFooterManager().setDateTimeText("01/01/2024")
    slide.getHeaderFooterManager().setDateTimeVisibility(True)
finally:
    presentation.dispose()
```