---
title: Получить эффективные свойства фигур из презентаций в Java
linktitle: Эффективные свойства
type: docs
weight: 50
url: /ru/java/shape-effective-properties/
keywords:
- свойства фигур
- свойства камеры
- осветительный комплект
- фаска формы
- текстовый кадр
- стиль текста
- высота шрифта
- формат заливки
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Узнайте, как Aspose.Slides for Java вычисляет и применяет эффективные свойства фигур для точного рендеринга PowerPoint."
---

В этой теме мы обсудим **effective** и **local** свойства. Когда мы задаём значения напрямую на этих уровнях

1. В свойствах части на слайде части;
1. В стиле текста прототипной фигуры на макете или главном слайде (если у формы текстового кадра части есть такой);
1. В глобальных настройках текста презентации;

эти значения называются **local** значениями. На любом уровне **local** значения могут быть определены или опущены. Но когда приложению нужно знать, как должна выглядеть часть, оно использует **effective** значения. Вы можете получить effective значения, используя метод **getEffective()** из локального формата.

Этот пример кода показывает, как получить effective значения:
```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    ITextFrameFormat localTextFrameFormat = shape.getTextFrame().getTextFrameFormat();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = localTextFrameFormat.getEffective();

    IPortionFormat localPortionFormat = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    IPortionFormatEffectiveData effectivePortionFormat = localPortionFormat.getEffective();
} finally {
    if (pres != null) pres.dispose();
}
```


## **Получить effective свойства камеры**
Aspose.Slides для Java позволяет разработчикам получать effective свойства камеры. Для этой цели в Aspose.Slides был добавлен интерфейс [**ICameraEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ICameraEffectiveData). Интерфейс [ICameraEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ICameraEffectiveData) представляет неизменяемый объект, содержащий effective свойства камеры. Экземпляр интерфейса [**ICameraEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ICameraEffectiveData) используется как часть интерфейса [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IThreeDFormatEffectiveData), который является парой [effective values](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getEffective--) для класса [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat).

Этот пример кода показывает, как получить effective свойства камеры:
```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IThreeDFormatEffectiveData threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();

    System.out.println("= Effective camera properties =");
    System.out.println("Type: " + threeDEffectiveData.getCamera().getCameraType());
    System.out.println("Field of view: " + threeDEffectiveData.getCamera().getFieldOfViewAngle());
    System.out.println("Zoom: " + threeDEffectiveData.getCamera().getZoom());
} finally {
    if (pres != null) pres.dispose();
}
```


## **Получить effective свойства Light Rig**
Aspose.Slides для Java позволяет разработчикам получать effective свойства Light Rig. Для этой цели в Aspose.Slides был добавлен интерфейс [**ILightRigEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ILightRigEffectiveData). Интерфейс [ILightRigEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ILightRigEffectiveData) представляет неизменяемый объект, содержащий effective свойства светового оборудования. Экземпляр интерфейса [**ILightRigEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ILightRigEffectiveData) используется как часть интерфейса [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IThreeDFormatEffectiveData), который является парой [effective values](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getEffective--) для класса [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat).

Этот пример кода показывает, как получить effective свойства Light Rig:
```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IThreeDFormatEffectiveData threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();

    System.out.println("= Effective light rig properties =");
    System.out.println("Type: " + threeDEffectiveData.getLightRig().getLightType());
    System.out.println("Direction: " + threeDEffectiveData.getLightRig().getDirection());
} finally {
    if (pres != null) pres.dispose();
}
```


## **Получить effective свойства Bevel Shape**
Aspose.Slides для Java позволяет разработчикам получать effective свойства Bevel Shape. Для этой цели в Aspose.Slides был добавлен интерфейс [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeBevelEffectiveData). Интерфейс [IShapeBevelEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeBevelEffectiveData) представляет неизменяемый объект, содержащий effective свойства рельефа формы. Экземпляр интерфейса [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeBevelEffectiveData) используется как часть интерфейса [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IThreeDFormatEffectiveData), который является парой [effective values](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getEffective--) для класса [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat).

Этот пример кода показывает, как получить effective свойства Bevel Shape:
```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IThreeDFormatEffectiveData threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();

    System.out.println("= Effective shape's top face relief properties =");
    System.out.println("Type: " + threeDEffectiveData.getBevelTop().getBevelType());
    System.out.println("Width: " + threeDEffectiveData.getBevelTop().getWidth());
    System.out.println("Height: " + threeDEffectiveData.getBevelTop().getHeight());
} finally {
    if (pres != null) pres.dispose();
}
```


## **Получить effective свойства Text Frame**
С помощью Aspose.Slides для Java вы можете получить effective свойства Text Frame. Для этой цели в Aspose.Slides был добавлен интерфейс [**ITextFrameFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormatEffectiveData). Он содержит effective свойства форматирования текстового кадра.

Этот пример кода показывает, как получить effective свойства форматирования текстового кадра:
```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = shape.getTextFrame().getTextFrameFormat().getEffective();

    System.out.println("Anchoring type: " + effectiveTextFrameFormat.getAnchoringType());
    System.out.println("Autofit type: " + effectiveTextFrameFormat.getAutofitType());
    System.out.println("Text vertical type: " + effectiveTextFrameFormat.getTextVerticalType());
    System.out.println("Margins");
    System.out.println("   Left: " + effectiveTextFrameFormat.getMarginLeft());
    System.out.println("   Top: " + effectiveTextFrameFormat.getMarginTop());
    System.out.println("   Right: " + effectiveTextFrameFormat.getMarginRight());
    System.out.println("   Bottom: " + effectiveTextFrameFormat.getMarginBottom());
} finally {
    if (pres != null) pres.dispose();
}
```


## **Получить effective свойства Text Style**
С помощью Aspose.Slides для Java вы можете получить effective свойства Text Style. Для этой цели в Aspose.Slides был добавлен интерфейс [**ITextStyleEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ITextStyleEffectiveData). Он содержит effective свойства текстового стиля.

Этот пример кода показывает, как получить effective свойства текстового стиля:
```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();

    for (int i = 0; i <= 8; i++)
    {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(i);
        System.out.println("= Effective paragraph formatting for style level #" + i + " =");

        System.out.println("Depth: " + effectiveStyleLevel.getDepth());
        System.out.println("Indent: " + effectiveStyleLevel.getIndent());
        System.out.println("Alignment: " + effectiveStyleLevel.getAlignment());
        System.out.println("Font alignment: " + effectiveStyleLevel.getFontAlignment());
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Получить значение effective высоты шрифта**
С помощью Aspose.Slides для Java вы можете получить effective свойства высоты шрифта. Здесь мы предоставляем код, который показывает, как меняется effective высота шрифта части после установки локальных значений высоты шрифта на разных уровнях структуры презентации:
```java
Presentation pres = new Presentation();
try {
    IAutoShape newShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
    newShape.addTextFrame("");
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().clear();

    IPortion portion0 = new Portion("Sample text with first portion");
    IPortion portion1 = new Portion(" and second portion.");

    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion0);
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion1);

    System.out.println("Effective font height just after creation:");
    System.out.println("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    pres.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    System.out.println("Effective font height after setting entire presentation default font height:");
    System.out.println("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    newShape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    System.out.println("Effective font height after setting paragraph default font height:");
    System.out.println("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setFontHeight(55);
    System.out.println("Effective font height after setting portion #0 font height:");
    System.out.println("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1).getPortionFormat().setFontHeight(18);
    System.out.println("Effective font height after setting portion #1 font height:");
    System.out.println("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    pres.save("SetLocalFontHeightValues.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Получить effective параметры заполнения таблицы**
С помощью Aspose.Slides для Java вы можете получить effective свойства заполнения для различных логических частей таблицы. Для этой цели в Aspose.Slides был добавлен интерфейс [**ICellFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ICellFormatEffectiveData). Он содержит effective свойства форматирования заполнения. Обратите внимание: форматирование ячеек всегда имеет приоритет над форматированием строки; строка — над столбцом; столбец — над всей таблицей.
```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    ITable tbl = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITableFormatEffectiveData tableFormatEffective = tbl.getTableFormat().getEffective();
    IRowFormatEffectiveData rowFormatEffective = tbl.getRows().get_Item(0).getRowFormat().getEffective();
    IColumnFormatEffectiveData columnFormatEffective = tbl.getColumns().get_Item(0).getColumnFormat().getEffective();
    ICellFormatEffectiveData cellFormatEffective = tbl.get_Item(0, 0).getCellFormat().getEffective();

    IFillFormatEffectiveData tableFillFormatEffective = tableFormatEffective.getFillFormat();
    IFillFormatEffectiveData rowFillFormatEffective = rowFormatEffective.getFillFormat();
    IFillFormatEffectiveData columnFillFormatEffective = columnFormatEffective.getFillFormat();
    IFillFormatEffectiveData cellFillFormatEffective = cellFormatEffective.getFillFormat();
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Как понять, что я получил «снимок», а не «живой объект», и когда следует снова считывать effective свойства?**

Объекты EffectiveData являются неизменяемыми снимками вычисленных значений на момент вызова. Если вы измените локальные или унаследованные настройки фигуры, получите effective данные снова, чтобы получить обновлённые значения.

**Влияет ли изменение макета/главного слайда на уже полученные effective свойства?**

Да, но только после повторного чтения. Уже полученный объект EffectiveData не обновляется автоматически — запросите его снова после изменения макета или главного слайда.

**Можно ли изменять значения через EffectiveData?**

Нет. EffectiveData доступен только для чтения. Вносите изменения в локальные объекты форматирования (figure/text/3D и т.д.), а затем при необходимости получайте effective значения вновь.

**Что происходит, если свойство не задано на уровне фигуры, макета/главного слайда и глобальных настроек?**

Effective значение определяется механизмом по умолчанию (значения по умолчанию PowerPoint/Aspose.Slides). Это разрешённое значение становится частью снимка EffectiveData.

**Можно ли по effective значению шрифта определить, какой уровень предоставил размер или гарнитуру?**

Не напрямую. EffectiveData возвращает окончательное значение. Чтобы найти источник, проверьте локальные значения на уровне части/абзаца/текстового кадра и стили текста на макете/главном слайде/презентации, где первое явное определение появляется.

**Почему значения EffectiveData иногда совпадают с локальными?**

Потому что локальное значение оказалось окончательным (высший уровень наследования не потребовался). В таких случаях effective значение равно локальному.

**Когда следует использовать effective свойства, а когда работать только с локальными?**

Используйте EffectiveData, когда нужен результат «как отрисовано» после применения всего наследования (например, для согласования цветов, отступов или размеров). Если необходимо изменить форматирование на конкретном уровне, изменяйте локальные свойства и, при необходимости, заново считывайте EffectiveData для проверки результата.