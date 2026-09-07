---
title: Bölüm
type: docs
weight: 90
url: /tr/python-java/examples/elements/section/
keywords:
- kod örneği
- bölüm
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java kullanarak sunum bölümlerini yönetin: Python kod örnekleriyle bölümleri ekleyin, erişin, kaldırın ve yeniden adlandırın."
---
Sunum bölümlerini yönetmek için örnekler—programatik olarak **Aspose.Slides for Python via Java** kullanarak ekleme, erişme, silme ve yeniden adlandırma.

Paketi [Installation](/slides/tr/python-java/installation/) bölümünde açıklandığı gibi kurun. Her örnek, JVM'i başlatmadan önce `asposeslides` paketini içe aktarır, ardından JVM çalışırken API'yi içe aktarır.

## **Bölüm Ekle**

Belirli bir slayttan başlayan bir bölüm oluşturun.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Bölümün başlangıcını işaret eden slaytı belirtin.
    presentation.getSections().addSection("New Section", slide)
finally:
    presentation.dispose()
```

## **Bölüme Erişme**

Bir sunumdan bölüm bilgilerini okuyun.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    presentation.getSections().addSection("My Section", slide)

    # İndeksle bir bölüme erişin.
    section = presentation.getSections().get_Item(0)
    section_name = section.getName()
    print(section_name)
finally:
    presentation.dispose()
```

## **Bölümü Kaldır**

Daha önce eklenmiş bir bölümü silin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    section = presentation.getSections().addSection("Temporary Section", slide)

    # İlk bölümü kaldırın.
    presentation.getSections().removeSection(section)
finally:
    presentation.dispose()
```

## **Bölümü Yeniden Adlandır**

Mevcut bir bölümün adını değiştirin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    presentation.getSections().addSection("Old Name", slide)

    section = presentation.getSections().get_Item(0)
    section.setName("New Name")
finally:
    presentation.dispose()
```