---
title: Tablo
type: docs
weight: 120
url: /tr/androidjava/examples/elements/table/
keywords:
- kod örneği
- tablo
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android'de tablolarla çalışın: oluşturun, biçimlendirin, hücreleri birleştirin, stiller uygulayın, verileri içe aktarın ve PPT, PPTX ve ODP için Java örnekleriyle dışa aktarın."
---
**Aspose.Slides for Android via Java** kullanarak tablo ekleme, tabloya erişme, tablo silme ve hücre birleştirme örnekleri.

## **Tablo Ekle**

İki satır ve iki sütundan oluşan basit bir tablo oluşturun.

```java
static void addTable() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);
    } finally {
        presentation.dispose();
    }
}
```

## **Tabloya Eriş**

Slayttaki ilk tablo şekli alın.

```java
static void accessTable() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);

        // Slayttaki ilk tabloya eriş.
        ITable firstTable = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ITable) {
                firstTable = (ITable) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Tabloyu Sil**

Bir slayttan tabloyu silin.

```java
static void removeTable() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);

        slide.getShapes().remove(table);
    } finally {
        presentation.dispose();
    }
}
```

## **Tablo Hücrelerini Birleştir**

Bir tablonun bitişik hücrelerini tek bir hücreye birleştirin.

```java
static void mergeTableCells() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);

        // Hücreleri birleştir.
        table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 1), false);
    } finally {
        presentation.dispose();
    }
}
```