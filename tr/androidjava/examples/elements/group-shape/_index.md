---
title: Grup Şekli
type: docs
weight: 170
url: /tr/androidjava/examples/elements/group-shape/
keywords:
- kod örneği
- grup şekli
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android'da gruplandırılmış şekilleri yönetin: Java örnekleriyle PPT, PPTX ve ODP sunumlarında grup şekillerini oluşturun, iç içe yerleştirin, hizalayın, yeniden sıralayın ve stil verin."
---
**Aspose.Slides for Android via Java** kullanarak şekil grupları oluşturma, onlara erişme, gruplamayı kaldırma ve silme örnekleri.

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

Slayttan bir grup şekli silin.

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

Şekilleri grup kapsayıcısından dışarı taşıyın.

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