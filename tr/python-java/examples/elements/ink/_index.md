---
title: Mürekkep
type: docs
weight: 180
url: /tr/python-java/examples/elements/ink/
keywords:
- kod örneği
- mürekkep
- mürekkebe erişim
- mürekkebi kaldır
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java sunumlarında, PPT, PPTX ve ODP dosyaları dahil olmak üzere mürekkep şekillerine erişin ve kaldırın."
---
Bu makale, mevcut mürekkep şekillerine erişme ve **Aspose.Slides for Python via Java** kullanarak bunları kaldırma örnekleri sunar.

Paketi, [Installation](/slides/tr/python-java/installation/) bölümünde açıklandığı gibi kurun. Her örnek, JVM'yi başlatmadan önce `asposeslides` paketini içe aktarır, ardından JVM çalıştıktan sonra API'yi içe aktarır.

{{% alert color="info" title="Note" %}}
Mürekkep şekilleri, özel cihazlardan gelen kullanıcı girişini temsil eder. Aspose.Slides programatik olarak yeni mürekkep darbeleri oluşturamaz, ancak mevcut mürekkebi okuyabilir ve değiştirebilirsiniz.
{{% /alert %}}

## **Mürekkebe Erişim**
Bir slayttaki ilk mürekkep şeklinden etiketleri okuyun.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Ink, Presentation

presentation = Presentation("ink.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().get_Item(0)
    if isinstance(shape, Ink):
        tags = shape.getCustomData().getTags()
        if tags.size() > 0:
            tag_name = tags.getNameByIndex(0)
            # tag_name'i gerektiği gibi kullanın.
finally:
    presentation.dispose()
```

## **Mürekkebi Kaldır**
Eğer mevcutsa slayttan bir mürekkep şeklini silin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Ink, Presentation

presentation = Presentation("ink.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    ink = None
    for shape in slide.getShapes():
        if isinstance(shape, Ink):
            ink = shape
            break

    if ink is not None:
        slide.getShapes().remove(ink)
finally:
    presentation.dispose()
```