---
title: Получить эффективные свойства фигур из презентаций на Java
linktitle: Эффективные свойства
type: docs
weight: 50
url: /ru/java/shape-effective-properties/
keywords:
- свойства фигур
- свойства камеры
- осветительный набор
- фаска фигуры
- текстовый кадр
- текстовый стиль
- высота шрифта
- формат заливки
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Узнайте, как Aspose.Slides for Java вычисляет и применяет эффективные свойства фигур для точного рендеринга PowerPoint."
---
## **Обзор**

Эта статья объясняет различие между **локальными** и **эффективными** свойствами. Локальные значения – это значения, которые задаются непосредственно на определённом уровне форматирования, например:

1. Свойства фрагмента на слайде.
1. Текстовые стили шаблонных фигур на макете или основном слайде, если у формы текстового кадра фрагмента есть такие стили.
1. Глобальные текстовые настройки в презентации.

Локальные значения могут быть определены или опущены на любом уровне. Когда Aspose.Slides требуется окончательное форматирование «как отображено», она разрешает цепочку наследования и возвращает **эффективные** значения. Получить их можно, вызвав метод `getEffective` у локального объекта формата.

Следующий пример показывает, как получить эффективные значения. Предполагается, что первая фигура на первом слайде является [IAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IAutoShape) с текстовым кадром и как минимум одним фрагментом.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormat localTextFrameFormat = shape.getTextFrame().getTextFrameFormat();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = localTextFrameFormat.getEffective();

    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    IPortion portion = paragraph.getPortions().get_Item(0);
    IPortionFormat localPortionFormat = portion.getPortionFormat();
    IPortionFormatEffectiveData effectivePortionFormat = localPortionFormat.getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
Эффективные данные форматирования представляют текущие вычисленные параметры после применения наследования. В текущей реализации некоторые объекты эффективных данных, такие как [IPortionFormatEffectiveData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IPortionFormatEffectiveData), могут кэшироваться внутри. Повторный вызов `getEffective` после изменения родительского или унаследованного форматирования может обновить кэшированные данные, и ранее полученный объект может больше не отражать прежнее состояние. Если необходимо сохранить эффективные значения для дальнейшего использования, скопируйте требуемые свойства, такие как высота шрифта, цвет заливки, стиль шрифта или выравнивание, в свой собственный объект данных.
{{% /alert %}}

## **Получить эффективные свойства камеры**

Aspose.Slides позволяет получить эффективные свойства камеры. Интерфейс [ICameraEffectiveData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ICameraEffectiveData) представляет неизменяемый объект, содержащий эффективные свойства камеры. Экземпляр [ICameraEffectiveData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ICameraEffectiveData) раскрывается через [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IThreeDFormatEffectiveData), который предоставляет эффективные значения для [IThreeDFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IThreeDFormat).

Следующий фрагмент кода показывает, как получить эффективные свойства камеры. Предполагается, что первая фигура на первом слайде имеет 3D‑форматирование.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ICameraEffectiveData cameraEffectiveData = threeDEffectiveData.getCamera();
    int cameraType = cameraEffectiveData.getCameraType();
    double fieldOfViewAngle = cameraEffectiveData.getFieldOfViewAngle();
    double zoom = cameraEffectiveData.getZoom();

    System.out.println("= Effective camera properties =");
    System.out.println("Type: " + cameraType);
    System.out.println("Field of view: " + fieldOfViewAngle);
    System.out.println("Zoom: " + zoom);
} finally {
    presentation.dispose();
}
```

## **Получить эффективные свойства осветительного устройства**

Aspose.Slides позволяет получить эффективные свойства осветительного устройства. Интерфейс [ILightRigEffectiveData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ILightRigEffectiveData) представляет неизменяемый объект, содержащий эффективные свойства осветительного устройства. Экземпляр [ILightRigEffectiveData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ILightRigEffectiveData) раскрывается через [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IThreeDFormatEffectiveData), который предоставляет эффективные значения для [IThreeDFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IThreeDFormat).

Следующий фрагмент кода показывает, как получить эффективные свойства осветительного устройства. Предполагается, что первая фигура на первом слайде имеет 3D‑форматирование.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ILightRigEffectiveData lightRigEffectiveData = threeDEffectiveData.getLightRig();
    int lightType = lightRigEffectiveData.getLightType();
    int direction = lightRigEffectiveData.getDirection();

    System.out.println("= Effective light rig properties =");
    System.out.println("Type: " + lightType);
    System.out.println("Direction: " + direction);
} finally {
    presentation.dispose();
}
```

## **Получить эффективные свойства фаски фигуры**

Aspose.Slides позволяет получить эффективные свойства фаски фигуры. Интерфейс [IShapeBevelEffectiveData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IShapeBevelEffectiveData) представляет неизменяемый объект, содержащий эффективные свойства рельефа грани фигуры. Экземпляр [IShapeBevelEffectiveData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IShapeBevelEffectiveData) раскрывается через [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IThreeDFormatEffectiveData), который предоставляет эффективные значения для [IThreeDFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IThreeDFormat).

Следующий фрагмент кода показывает, как получить эффективные свойства верхней фаски фигуры. Предполагается, что первая фигура на первом слайде имеет 3D‑форматирование.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    IShapeBevelEffectiveData bevelTop = threeDEffectiveData.getBevelTop();
    int bevelType = bevelTop.getBevelType();
    double bevelWidth = bevelTop.getWidth();
    double bevelHeight = bevelTop.getHeight();

    System.out.println("= Effective shape's top face relief properties =");
    System.out.println("Type: " + bevelType);
    System.out.println("Width: " + bevelWidth);
    System.out.println("Height: " + bevelHeight);
} finally {
    presentation.dispose();
}
```

## **Получить эффективные свойства текстового кадра**

С помощью Aspose.Slides можно получить эффективные свойства текстового кадра. Интерфейс [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ITextFrameFormatEffectiveData) содержит эффективные свойства форматирования текстового кадра.

Следующий фрагмент кода показывает, как получить эффективные свойства форматирования текстового кадра. Предполагается, что первая фигура на первом слайде является [IAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IAutoShape) с текстовым кадром.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = textFrameFormat.getEffective();
    int anchoringType = effectiveTextFrameFormat.getAnchoringType();
    int autofitType = effectiveTextFrameFormat.getAutofitType();
    int textVerticalType = effectiveTextFrameFormat.getTextVerticalType();
    double marginLeft = effectiveTextFrameFormat.getMarginLeft();
    double marginTop = effectiveTextFrameFormat.getMarginTop();
    double marginRight = effectiveTextFrameFormat.getMarginRight();
    double marginBottom = effectiveTextFrameFormat.getMarginBottom();

    System.out.println("Anchoring type: " + anchoringType);
    System.out.println("Autofit type: " + autofitType);
    System.out.println("Text vertical type: " + textVerticalType);
    System.out.println("Margins");
    System.out.println("   Left: " + marginLeft);
    System.out.println("   Top: " + marginTop);
    System.out.println("   Right: " + marginRight);
    System.out.println("   Bottom: " + marginBottom);
} finally {
    presentation.dispose();
}
```

## **Получить эффективные свойства текстового стиля**

С помощью Aspose.Slides можно получить эффективные свойства текстового стиля. Интерфейс [ITextStyleEffectiveData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ITextStyleEffectiveData) содержит эффективные свойства текстового стиля.

Следующий фрагмент кода показывает, как получить эффективные свойства текстового стиля. Предполагается, что первая фигура на первом слайде является [IAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IAutoShape) с текстовым кадром.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);
    
    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    int levelCount = 9;

    for (int levelIndex = 0; levelIndex < levelCount; levelIndex++)
    {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);
        int depth = effectiveStyleLevel.getDepth();
        double indent = effectiveStyleLevel.getIndent();
        int alignment = effectiveStyleLevel.getAlignment();
        int fontAlignment = effectiveStyleLevel.getFontAlignment();
        System.out.println("= Effective paragraph formatting for style level #" + levelIndex + " =");

        System.out.println("Depth: " + depth);
        System.out.println("Indent: " + indent);
        System.out.println("Alignment: " + alignment);
        System.out.println("Font alignment: " + fontAlignment);
    }
} finally {
    presentation.dispose();
}
```

## **Получить эффективное значение высоты шрифта**

С помощью Aspose.Slides можно получить эффективную высоту шрифта. Следующий код демонстрирует, как меняется эффективная высота шрифта фрагмента после установки локальных значений высоты шрифта на разных уровнях структуры презентации.

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
    autoShape.addTextFrame("");

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    IPortion firstPortion = new Portion("Sample text with first portion");
    IPortion secondPortion = new Portion(" and second portion.");

    paragraph.getPortions().add(firstPortion);
    paragraph.getPortions().add(secondPortion);

    IPortionFormatEffectiveData firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    IPortionFormatEffectiveData secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();
    
    System.out.println("Effective font height just after creation:");
    double firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    double secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting the presentation default font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting paragraph default font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    firstPortion.getPortionFormat().setFontHeight(55);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting portion #0 font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    secondPortion.getPortionFormat().setFontHeight(18);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();
    
    System.out.println("Effective font height after setting portion #1 font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    presentation.save("SetLocalFontHeightValues.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Получить эффективный формат заливки таблицы**

С помощью Aspose.Slides можно получить эффективное форматирование заливки для разных частей таблицы. Интерфейс [IFillFormatEffectiveData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IFillFormatEffectiveData) содержит эффективные свойства форматирования заливки. Формат ячейки имеет более высокий приоритет, чем формат строки; формат строки — выше, чем формат столбца; формат столбца — выше, чем формат всей таблицы.

В результате свойства [ICellFormatEffectiveData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ICellFormatEffectiveData) используются для отрисовки ячейки таблицы. Следующий фрагмент кода показывает, как получить эффективное форматирование заливки для разных частей таблицы. Предполагается, что первая фигура на первом слайде является [ITable](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ITable).

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable)slide.getShapes().get_Item(0);
    
    ITableFormatEffectiveData tableFormatEffective = table.getTableFormat().getEffective();
    IRowFormatEffectiveData rowFormatEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    IColumnFormatEffectiveData columnFormatEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    ICellFormatEffectiveData cellFormatEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    IFillFormatEffectiveData tableFillFormatEffective = tableFormatEffective.getFillFormat();
    IFillFormatEffectiveData rowFillFormatEffective = rowFormatEffective.getFillFormat();
    IFillFormatEffectiveData columnFillFormatEffective = columnFormatEffective.getFillFormat();
    IFillFormatEffectiveData cellFillFormatEffective = cellFormatEffective.getFillFormat();
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Возвращает ли `getEffective` снимок состояния?**

Не всегда. Эффективные данные представляют вычисленное форматирование после применения наследования, но некоторые объекты эффективных данных могут кэшироваться внутри. Последующий вызов `getEffective` может перерасчитать форматирование и обновить кэш, поэтому ранее полученный объект не следует рассматривать как постоянный снимок.

**Когда следует повторно считывать эффективные свойства?**

Вызовите `getEffective` снова после изменения локального форматирования, стилей‑родителей, форматирования макета, форматирования мастера или параметров по умолчанию презентации. Следующий вызов переоценивает иерархию форматирования и возвращает актуальный эффективный результат.

**Влияет ли изменение или удаление макета/главного слайда на уже полученные эффективные свойства?**

Да, но изменение будет отражено только при следующем вызове `getEffective`. Если источник родительского форматирования изменён или удалён, ранее полученные эффективные данные могут стать устаревшими. После повторного вызова `getEffective` Aspose.Slides переоценивает дерево форматирования, и полученные шрифты, цвета, размеры или другие параметры могут измениться.

**Можно ли изменять значения через объекты эффективных данных?**

Нет. Объекты эффективных данных лишь предоставляют рассчитанные значения. Вносите изменения в локальные объекты форматирования, а затем снова получайте эффективные значения.

**Что происходит, если свойство не задано на уровне фигуры, макета/массива, ни в глобальных настройках?**

Эффективное значение определяется механизмом значений по умолчанию, включающим настройки PowerPoint и Aspose.Slides. Полученное таким образом значение становится частью текущих эффективных данных.

**Можно ли по эффективному значению шрифта определить, какой уровень предоставил размер или гарнитуру?**

Не напрямую. Эффективные данные возвращают окончательное значение. Чтобы найти источник, проверьте локальные значения в фрагменте, абзаце, текстовом кадре и текстовых стилях на уровнях макета, мастера и презентации, чтобы увидеть, где первое явное определение появилось.

**Почему эффективные значения иногда выглядят одинаково с локальными?**

Потому что локальное значение оказалось окончательным (не потребовалось наследование с более высокого уровня). В таких случаях эффективное значение совпадает с локальным.

**Когда следует использовать эффективные свойства, а когда работать только с локальными?**

Используйте эффективные данные, когда нужен результат «как отображено» после применения всех уровней наследования, например, для согласования цветов, отступов или размеров. Если необходимо сохранить эти значения независимо от будущих изменений форматирования, скопируйте требуемые свойства в свой собственный объект. Если требуется изменить форматирование на конкретном уровне, изменяйте локальные свойства и при необходимости снова считывайте эффективные данные, чтобы убедиться в результате.