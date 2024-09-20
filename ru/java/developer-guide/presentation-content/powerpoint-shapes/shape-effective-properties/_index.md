---
title: Эффективные свойства формы
type: docs
weight: 50
url: /java/shape-effective-properties/
---

В этой теме мы обсудим **эффективные** и **локальные** свойства. Когда мы устанавливаем значения напрямую на этих уровнях

1. В свойствах порции на слайде порции;
1. В текстовом стиле прототипа формы на разметке или мастер-слайде (если у формы текстового фрейма есть таковой);
1. В глобальных текстовых настройках презентации;

эти значения называют **локальными** значениями. На любом уровне **локальные** значения могут быть определены или опущены. Но когда приложению нужно знать, как должна выглядеть порция, оно использует **эффективные** значения. Вы можете получить эффективные значения, используя метод **getEffective()** от локального формата.

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

## **Получение эффективных свойств камеры**
Aspose.Slides для Java позволяет разработчикам получать эффективные свойства камеры. Для этой цели интерфейс [**ICameraEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ICameraEffectiveData) был добавлен в Aspose.Slides. Интерфейс [ICameraEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ICameraEffectiveData) представляет собой неизменяемый объект, содержащий эффективные свойства камеры. Экземпляр интерфейса [**ICameraEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ICameraEffectiveData) используется как часть интерфейса [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IThreeDFormatEffectiveData), который является парой [эффективных значений](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getEffective--) для класса [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat).

Этот пример кода показывает, как получить эффективные свойства для камеры:

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IThreeDFormatEffectiveData threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();

    System.out.println("= Эффективные свойства камеры =");
    System.out.println("Тип: " + threeDEffectiveData.getCamera().getCameraType());
    System.out.println("Угол обзора: " + threeDEffectiveData.getCamera().getFieldOfViewAngle());
    System.out.println("Масштаб: " + threeDEffectiveData.getCamera().getZoom());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Получение эффективных свойств Light Rig**
Aspose.Slides для Java позволяет разработчикам получать эффективные свойства Light Rig. Для этой цели интерфейс [**ILightRigEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ILightRigEffectiveData) был добавлен в Aspose.Slides. Интерфейс [ILightRigEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ILightRigEffectiveData) представляет собой неизменяемый объект, содержащий эффективные свойства осветительного оборудования. Экземпляр интерфейса [**ILightRigEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ILightRigEffectiveData) используется как часть интерфейса [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IThreeDFormatEffectiveData), который является парой [эффективных значений](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getEffective--) для класса [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat).

Этот пример кода показывает, как получить эффективные свойства Light Rig:

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IThreeDFormatEffectiveData threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();

    System.out.println("= Эффективные свойства Light Rig =");
    System.out.println("Тип: " + threeDEffectiveData.getLightRig().getLightType());
    System.out.println("Направление: " + threeDEffectiveData.getLightRig().getDirection());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Получение эффективных свойств формы с закругленными углами**
Aspose.Slides для Java позволяет разработчикам получать эффективные свойства формы с закругленными углами. Для этой цели интерфейс [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeBevelEffectiveData) был добавлен в Aspose.Slides. Интерфейс [IShapeBevelEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeBevelEffectiveData) представляет собой неизменяемый объект, содержащий эффективные свойства рельефа лица формы. Экземпляр интерфейса [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeBevelEffectiveData) используется как часть интерфейса [**IThreeDFormatEffectiveData**]([**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeBevelEffectiveData)), который является парой [эффективных значений](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getEffective--) для класса [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat).

Этот пример кода показывает, как получить эффективные свойства для формы с закругленными углами:

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IThreeDFormatEffectiveData threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();

    System.out.println("= Эффективные свойства рельефа верхней поверхности формы =");
    System.out.println("Тип: " + threeDEffectiveData.getBevelTop().getBevelType());
    System.out.println("Ширина: " + threeDEffectiveData.getBevelTop().getWidth());
    System.out.println("Высота: " + threeDEffectiveData.getBevelTop().getHeight());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Получение эффективных свойств текстового фрейма**
С помощью Aspose.Slides для Java вы можете получить эффективные свойства текстового фрейма. Для этой цели интерфейс [**ITextFrameFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormatEffectiveData) был добавлен в Aspose.Slides. Он содержит эффективные свойства форматирования текстового фрейма.

Этот пример кода показывает, как получить эффективные свойства форматирования текстового фрейма:

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = shape.getTextFrame().getTextFrameFormat().getEffective();

    System.out.println("Тип анкерования: " + effectiveTextFrameFormat.getAnchoringType());
    System.out.println("Тип автоформатирования: " + effectiveTextFrameFormat.getAutofitType());
    System.out.println("Вертикальный тип текста: " + effectiveTextFrameFormat.getTextVerticalType());
    System.out.println("Отступы");
    System.out.println("   Левый: " + effectiveTextFrameFormat.getMarginLeft());
    System.out.println("   Верхний: " + effectiveTextFrameFormat.getMarginTop());
    System.out.println("   Правый: " + effectiveTextFrameFormat.getMarginRight());
    System.out.println("   Нижний: " + effectiveTextFrameFormat.getMarginBottom());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Получение эффективных свойств текстового стиля**
С помощью Aspose.Slides для Java вы можете получить эффективные свойства текстового стиля. Для этой цели интерфейс [**ITextStyleEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ITextStyleEffectiveData) был добавлен в Aspose.Slides. Он содержит эффективные свойства текстового стиля.

Этот пример кода показывает, как получить эффективные свойства текстового стиля:

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();

    for (int i = 0; i <= 8; i++)
    {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(i);
        System.out.println("= Эффективное форматирование абзаца для уровня стиля #" + i + " =");

        System.out.println("Глубина: " + effectiveStyleLevel.getDepth());
        System.out.println("Отступ: " + effectiveStyleLevel.getIndent());
        System.out.println("Выравнивание: " + effectiveStyleLevel.getAlignment());
        System.out.println("Выравнивание шрифта: " + effectiveStyleLevel.getFontAlignment());
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Получение эффективного значения высоты шрифта**
С помощью Aspose.Slides для Java вы можете получить эффективные свойства высоты шрифта. Здесь мы предоставляем код, который показывает, как значение эффективной высоты шрифта порции изменяется после установки локальных значений высоты шрифта на разных уровнях структуры презентации:

```java
Presentation pres = new Presentation();
try {
    IAutoShape newShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
    newShape.addTextFrame("");
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().clear();

    IPortion portion0 = new Portion("Пример текста с первой порцией");
    IPortion portion1 = new Portion(" и второй порцией.");

    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion0);
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion1);

    System.out.println("Эффективная высота шрифта сразу после создания:");
    System.out.println("Порция #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Порция #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    pres.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    System.out.println("Эффективная высота шрифта после установки высоты шрифта по умолчанию для всей презентации:");
    System.out.println("Порция #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Порция #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    newShape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    System.out.println("Эффективная высота шрифта после установки высоты шрифта по умолчанию для абзаца:");
    System.out.println("Порция #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Порция #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setFontHeight(55);
    System.out.println("Эффективная высота шрифта после установки высоты шрифта порции #0:");
    System.out.println("Порция #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Порция #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1).getPortionFormat().setFontHeight(18);
    System.out.println("Эффективная высота шрифта после установки высоты шрифта порции #1:");
    System.out.println("Порция #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Порция #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    pres.save("SetLocalFontHeightValues.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Получение эффективного заполнения для таблицы**
С помощью Aspose.Slides для Java вы можете получить эффективное заполнение для различных логических частей таблицы. Для этой цели интерфейс [**ICellFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ICellFormatEffectiveData) был добавлен в Aspose.Slides. Он содержит эффективные свойства заполнения. Пожалуйста, обратите внимание на следующее: форматирование ячеек всегда имеет приоритет над форматированием строк; строки имеют приоритет над столбцами; и столбцы имеют приоритет над всей таблицей.

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