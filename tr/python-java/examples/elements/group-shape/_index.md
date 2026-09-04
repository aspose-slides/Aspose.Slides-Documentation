---
title: Grup Şekli
type: docs
weight: 170
url: /tr/python-java/examples/elements/group-shape/
keywords:
- kod örneği
- grup şekli
- grup şekli ekle
- grup şekline eriş
- grup şekli kaldır
- şekilleri gruptan çıkar
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile sunumlarda grup şekillerini yönetin: PowerPoint ve OpenDocument dosyalarında şekilleri ekleyin, erişin, kaldırın ve gruptan çıkarın."
---
Bu makale, **Aspose.Slides for Python via Java** kullanarak şekil grupları oluşturmayı, onlara erişmeyi, silmeyi ve içeriklerini gruptan çıkarmayı göstermektedir.

Paketi, [Installation](/slides/tr/python-java/installation/) bölümünde açıklandığı gibi kurun. Her örnek, JVM'i başlatmadan önce `asposeslides` paketini içe aktarır, ardından JVM çalıştıktan sonra API'yi içe aktarır.

## **Grup Şekli Ekle**

İki temel şekil içeren bir grup oluşturun.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    group = slide.getShapes().addGroupShape()
    group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50)
    group.getShapes().addAutoShape(ShapeType.Ellipse, 60, 0, 50, 50)
finally:
    presentation.dispose()
```

## **Grup Şekline Erişme**

Bir slayttan ilk grup şekli alın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GroupShape, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    group = slide.getShapes().addGroupShape()
    group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50)

    first_group = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, GroupShape):
            first_group = shape
            break
finally:
    presentation.dispose()
```

## **Grup Şeklini Kaldır**

Grupla şekli slayttan sil.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    group = slide.getShapes().addGroupShape()

    slide.getShapes().remove(group)
finally:
    presentation.dispose()
```

## **Şekilleri Gruptan Çıkarma**

Bir şekli grup konteynerinden dışarı taşıyın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    group = slide.getShapes().addGroupShape()
    rectangle = group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50)

    # Şekli gruptan dışarı taşı.
    slide.getShapes().addClone(rectangle)
    group.getShapes().remove(rectangle)
finally:
    presentation.dispose()
```