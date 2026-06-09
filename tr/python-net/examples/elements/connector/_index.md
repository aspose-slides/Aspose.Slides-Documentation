---
title: Bağlayıcı
type: docs
weight: 190
url: /tr/python-net/examples/elements/connector/
keywords:
- bağlayıcı
- bağlayıcı ekle
- bağlayıcıya eriş
- bağlayıcı kaldır
- şekilleri yeniden bağla
- kod örnekleri
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Python ile Aspose.Slides kullanarak bağlayıcıları çizin ve kontrol edin: bağlayıcı ekleyin, yönlendirin, yeniden yönlendirin, bağlantı noktalarını, okları ve stilleri ayarlayarak şekilleri PPT, PPTX ve ODP formatlarında bağlayın."
---
Şekilleri bağlayıcılarla bağlamayı ve hedeflerini **Aspose.Slides for Python via .NET** kullanarak değiştirmeyi gösterir.

## **Bağlayıcı Ekle**

Slayttaki iki nokta arasına bir bağlayıcı şekli ekleyin.

```py
def add_connector():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Eğik bağlayıcı şekli ekle.
        connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 100, 100)

        presentation.save("connector.pptx", slides.export.SaveFormat.PPTX)
```

## **Bağlayıcıya Erişme**

Bir slayta eklenen ilk bağlayıcı şekli alın.

```py
def access_connector():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # Slayttaki ilk bağlayıcıya eriş.
        first_connector = None
        for shape in slide.shapes:
            if isinstance(shape, slides.Connector):
                first_connector = shape
                break
```

## **Bağlayıcıyı Kaldır**

Bağlayıcıyı slayttan silin.

```py
def remove_connector():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # İlk şeklin bir bağlayıcı olduğunu varsayarak.
        connector = slide.shapes[0]

        # Bağlayıcıyı kaldır.
        slide.shapes.remove(connector)

        presentation.save("connector_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Şekilleri Yeniden Bağla**

Başlangıç ve bitiş hedeflerini atayarak bir bağlayıcıyı iki şekle bağlayın.

```py
def reconnect_shapes():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # İlk dikdörtgen şekli ekle.
        shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 50, 50)
        # İkinci dikdörtgen şekli ekle.
        shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 50, 50)

        # Eğik bağlayıcı şekli ekle.
        connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 100, 100)

        # Bağlayıcının başlangıcını ilk şekle bağla.
        connector.start_shape_connected_to = shape1
        # Bağlayıcının sonunu ikinci şekle bağla.
        connector.end_shape_connected_to = shape2

        presentation.save("shapes_reconnected.pptx", slides.export.SaveFormat.PPTX)
```