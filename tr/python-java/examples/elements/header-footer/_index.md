---
title: Üst Bilgi Alt Bilgi
type: docs
weight: 220
url: /tr/python-java/examples/elements/header-footer/
keywords:
- kod örneği
- üst bilgi
- alt bilgi
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java kullanarak slayt üst ve alt bilgilerini kontrol edin: PPT, PPTX ve ODP sunumlarına tarih, slayt numarası ve özel metin ekleyin."
---
Bu makale, **Aspose.Slides for Python via Java** kullanarak alt bilgileri eklemeyi ve tarih ve saat tutucularını güncellemeyi gösterir.

Paketi, [Installation](/slides/tr/python-java/installation/) bölümünde açıklandığı gibi yükleyin. Her örnek, JVM'i başlatmadan önce `asposeslides` paketini içe aktarır, ardından JVM çalıştıktan sonra API'yi içe aktarır.

## **Alt Bilgi Ekle**

Bir slaydın alt bilgi alanına metin ekleyin ve görünür hâle getirin.

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

## **Tarih ve Zamanı Güncelle**

Bir slayttaki tarih ve saat tutucusunu değiştirin.

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