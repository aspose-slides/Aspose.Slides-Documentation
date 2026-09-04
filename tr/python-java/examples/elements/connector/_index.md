---
title: Bağlayıcı
type: docs
weight: 190
url: /tr/python-java/examples/elements/connector/
keywords:
- kod örneği
- bağlayıcı
- bağlayıcı ekle
- bağlayıcıya eriş
- bağlayıcıyı kaldır
- şekilleri yeniden bağla
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java kullanarak PPT, PPTX ve ODP sunumlarında bağlayıcılarla şekilleri ekleme, erişme, kaldırma ve yeniden bağlama konusunda bilgi edinin."
---
Bu makale, şekilleri bağlayıcılarla nasıl bağlayacağınızı ve hedeflerini **Aspose.Slides for Python via Java** kullanarak nasıl değiştireceğinizi gösterir.

Paketi, [Installation](/slides/tr/python-java/installation/) bölümünde açıklandığı gibi kurun. Her örnek, JVM'yi başlatmadan önce `asposeslides` paketini içe aktarır, ardından JVM çalıştıktan sonra API'yi içe aktarır.

## **Bağlayıcı Ekle**

Slayttaki iki nokta arasına bir bağlayıcı şekli ekleyin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100)
finally:
    presentation.dispose()
```

## **Bağlayıcıya Eriş**

Bir slayta eklenen ilk bağlayıcı şekli alın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Connector, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100)

    # Slayttaki ilk bağlayıcıya eriş.
    connector = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Connector):
            connector = shape
            break
finally:
    presentation.dispose()
```

## **Bağlayıcıyı Kaldır**

Slayttan bir bağlayıcıyı silin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100)

    slide.getShapes().remove(connector)
finally:
    presentation.dispose()
```

## **Şekilleri Yeniden Bağla**

Başlangıç ve bitiş hedeflerini atayarak bir bağlayıcıyı iki şekle bağlayın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50)
    shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 50, 50)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100)

    connector.setStartShapeConnectedTo(shape1)
    connector.setEndShapeConnectedTo(shape2)
finally:
    presentation.dispose()
```