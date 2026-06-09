---
title: Grup Şekli
type: docs
weight: 170
url: /tr/java/examples/elements/group-shape/
keywords:
- kod örneği
- grup şekli
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java’da gruplanmış şekilleri yönetin: Java örnekleriyle PPT, PPTX ve ODP sunumlarında grup şekilleri oluşturun, iç içe yerleştirin, hizalayın, yeniden sırala ve stil verin."
---
**Aspose.Slides for Java** kullanarak şekil grupları oluşturma, erişme, gruplamayı çözme ve kaldırma örnekleri.

## **Grup Şekli Ekle**

İki temel şekil içeren bir grup oluşturun.

```java
static void addGroupShape() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IGroupShape group = slide.getShapes().addGroupShape();
        group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
        group.getShapes().addAutoShape(ShapeType.Ellipse, 60, 0, 50, 50);
    } finally {
        presentation.dispose();
    }
}
```

## **Grup Şekline Erişme**

Bir slayttan ilk grup şekli alın.

```java
static void accessGroupShape() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IGroupShape group = slide.getShapes().addGroupShape();
        group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

        IGroupShape firstGroup = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IGroupShape) {
                firstGroup = (IGroupShape) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Grup Şekli Kaldırma**

Grup şeklini slayttan silin.

```java
static void removeGroupShape() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IGroupShape group = slide.getShapes().addGroupShape();

        slide.getShapes().remove(group);
    } finally {
        presentation.dispose();
    }
}
```

## **Şekilleri Gruplamadan Çıkarma**

Şekilleri grup kapsayıcısından dışarı taşı.

```java
static void ungroupShapes() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IGroupShape group = slide.getShapes().addGroupShape();
        IAutoShape rect = group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

        // Şekli grup dışına taşı.
        slide.getShapes().addClone(rect);
        group.getShapes().remove(rect);
    } finally {
        presentation.dispose();
    }
}
```