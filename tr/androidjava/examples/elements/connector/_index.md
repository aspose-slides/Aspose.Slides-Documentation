---
title: Bağlayıcı
type: docs
weight: 190
url: /tr/androidjava/examples/elements/connector/
keywords:
- kod örneği
- Connector
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android kullanarak şekiller arasına bağlayıcı ekleme, yönlendirme ve stillendirme hakkında öğrenin, PPT, PPTX ve ODP sunumları için Java örnekleri."
---
Bu makale, şekilleri bağlayıcılarla bağlamayı ve hedeflerini **Aspose.Slides for Android via Java** kullanarak değiştirmeyi gösterir.

## **Bağlayıcı Ekle**

Slayttaki iki nokta arasında bir bağlayıcı şekli ekleyin.

```java
static void addConnector() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100);
    } finally {
        presentation.dispose();
    }
}
```

## **Bağlayıcıya Eriş**

Bir slayta eklenen ilk bağlayıcı şekli alın.

```java
static void accessConnector() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

        // Slayttaki ilk bağlayıcıya erişin.
        IConnector connector = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IConnector) {
                connector = (IConnector) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Bağlayıcıyı Kaldır**

Slayttan bir bağlayıcıyı silin.

```java
static void removeConnector() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

        slide.getShapes().remove(connector);
    } finally {
        presentation.dispose();
    }
}
```

## **Şekilleri Yeniden Bağla**

Başlangıç ve bitiş hedeflerini atayarak bir bağlayıcıyı iki şekle bağlayın.

```java
static void reconnectShapes() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
        IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 50, 50);
        IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

        connector.setStartShapeConnectedTo(shape1);
        connector.setEndShapeConnectedTo(shape2);
    } finally {
        presentation.dispose();
    }
}
```