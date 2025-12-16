---
title: Получить эффективные свойства фигур из презентаций на Android
linktitle: Эффективные свойства
type: docs
weight: 50
url: /ru/androidjava/shape-effective-properties/
keywords:
- свойства фигур
- свойства камеры
- освещение
- фаска формы
- текстовая рамка
- стиль текста
- высота шрифта
- формат заливки
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Узнайте, как Aspose.Slides for Android via Java рассчитывает и применяет эффективные свойства фигур для точного рендеринга PowerPoint."
---

В этой теме мы обсудим **effective** и **local** свойства. Когда мы задаём значения непосредственно на этих уровнях

1. В свойствах части на слайде части;
1. В стиле текста прототипной формы на макете или мастер‑слайде (если у формы текстового фрейма части есть такой стиль);
1. В глобальных настройках текста презентации;

эти значения называют **local** значениями. На любом уровне **local** значения могут быть определены или опущены. Но когда приложению нужно знать, как должна выглядеть часть, оно использует **effective** значения. Вы можете получить эффективные значения, используя метод **getEffective()** из локального формата.

Этот пример кода показывает, как получить эффективные значения:
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


## **Получить эффективные свойства камеры**
Aspose.Slides for Android via Java позволяет разработчикам получать эффективные свойства камеры. В этой цели в Aspose.Slides был добавлен интерфейс [**ICameraEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICameraEffectiveData). Интерфейс [ICameraEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICameraEffectiveData) представляет собой неизменяемый объект, содержащий эффективные свойства камеры. Экземпляр [**ICameraEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICameraEffectiveData) используется как часть интерфейса [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IThreeDFormatEffectiveData), который является парой [effective values](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getEffective--) для класса [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat).

Этот пример кода демонстрирует, как получить эффективные свойства камеры:
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


## **Получить эффективные свойства Light Rig**
Aspose.Slides for Android via Java позволяет разработчикам получать эффективные свойства Light Rig. Для этой цели в Aspose.Slides был добавлен интерфейс [**ILightRigEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ILightRigEffectiveData). Интерфейс [ILightRigEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ILightRigEffectiveData) представляет собой неизменяемый объект, содержащий эффективные свойства световой установки. Экземпляр [**ILightRigEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ILightRigEffectiveData) используется как часть интерфейса [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IThreeDFormatEffectiveData), который является парой [effective values](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getEffective--) для класса [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat).

Этот пример кода демонстрирует, как получить эффективные свойства Light Rig:
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


## **Получить эффективные свойства Bevel Shape**
Aspose.Slides for Android via Java позволяет разработчикам получать эффективные свойства Bevel Shape. Для этой цели был добавлен интерфейс [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeBevelEffectiveData). Интерфейс [IShapeBevelEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeBevelEffectiveData) представляет собой неизменяемый объект, содержащий эффективные свойства рельефа грани формы. Экземпляр [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeBevelEffectiveData) используется как часть интерфейса [**IThreeDFormatEffectiveData**]([**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeBevelEffectiveData)), который является парой [effective values](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getEffective--) для класса [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat).

Этот пример кода демонстрирует, как получить эффективные свойства Bevel Shape:
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


## **Получить эффективные свойства Text Frame**
С помощью Aspose.Slides for Android via Java можно получить эффективные свойства Text Frame. Для этой цели в Aspose.Slides был добавлен интерфейс [**ITextFrameFormatEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormatEffectiveData). Он содержит свойства форматирования текстового фрейма.

Этот пример кода показывает, как получить эффективные свойства форматирования Text Frame:
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


## **Получить эффективные свойства Text Style**
С помощью Aspose.Slides for Android via Java можно получить эффективные свойства Text Style. Для этой цели в Aspose.Slides был добавлен интерфейс [**ITextStyleEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextStyleEffectiveData). Он содержит эффективные свойства стиля текста.

Этот пример кода демонстрирует, как получить эффективные свойства Text Style:
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


## **Получить эффективное значение высоты шрифта**
С помощью Aspose.Slides for Android via Java можно получить эффективные свойства высоты шрифта. Здесь предоставлен код, демонстрирующий изменение эффективного значения высоты шрифта части после установки локальных значений высоты шрифта на разных уровнях структуры презентации:
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


## **Получить эффективный формат заливки для таблицы**
С помощью Aspose.Slides for Android via Java можно получить эффективное форматирование заливки для различных логических частей таблицы. Для этой цели в Aspose.Slides был добавлен интерфейс [**ICellFormatEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICellFormatEffectiveData). Он содержит свойства эффективного форматирования заливки. Обратите внимание: форматирование ячейки всегда имеет приоритет над форматированием строки; строка имеет приоритет над столбцом; столбец имеет приоритет над всей таблицей.
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

**Как определить, что я получил "моментальный снимок", а не "живой объект", и когда следует перечитывать эффективные свойства?**

EffectiveData объекты являются неизменяемыми снимками вычисленных значений на момент вызова. Если вы измените локальные или унаследованные настройки формы, запросите эффективные данные снова, чтобы получить обновлённые значения.

**Влияет ли изменение макета/мастер‑слайда на эффективные свойства, уже полученные ранее?**

Да, но только после повторного чтения. Уже полученный объект EffectiveData не обновляется сам по себе — запросите его снова после изменения макета или мастера.

**Можно ли изменять значения через EffectiveData?**

Нет. EffectiveData только для чтения. Вносите изменения в локальные объекты форматирования (форма/текст/3D и т.д.), а затем снова получайте эффективные значения.

**Что происходит, если свойство не задано на уровне формы, макета/мастера и глобальных настроек?**

Эффективное значение определяется механизмом значений по умолчанию (по умолчанию PowerPoint/Aspose.Slides). Это полученное значение становится частью снимка EffectiveData.

**Можно ли по эффективному значению шрифта определить, какой уровень предоставил размер или гарнитуру?**

Не напрямую. EffectiveData возвращает окончательное значение. Чтобы узнать источник, проверьте локальные значения в части/абзаце/текстовом фрейме и стили текста в макете/мастере/презентации, чтобы увидеть, где появилось первое явное определение.

**Почему значения EffectiveData иногда совпадают с локальными?**

Потому что локальное значение стало окончательным (не потребовалось наследование с более высокого уровня). В таких случаях эффективное значение совпадает с локальным.

**Когда следует использовать эффективные свойства, а когда работать только с локальными?**

Используйте EffectiveData, когда нужен результат «как отрисовано» после применения всех наследований (например, для согласования цветов, отступов или размеров). Если нужно изменить форматирование на определённом уровне, изменяйте локальные свойства и, при необходимости, перечитывайте EffectiveData для проверки результата.