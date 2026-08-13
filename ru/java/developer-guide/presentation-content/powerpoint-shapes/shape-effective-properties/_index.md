---
title: Получить эффективные свойства фигуры из презентаций на Java
linktitle: Эффективные свойства
type: docs
weight: 50
url: /ru/java/shape-effective-properties/
keywords:
- свойства фигур
- свойства камеры
- осветительное оборудование
- фаска фигуры
- текстовая область
- текстовый стиль
- высота шрифта
- формат заливки
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Узнайте, как Aspose.Slides for Java вычисляет и применяет эффективные свойства фигур для точного отображения PowerPoint."
---
## **Обзор**

Эта тема объясняет разницу между **локальными** и **эффективными** свойствами. Локальные значения — это значения, задаваемые непосредственно на конкретном уровне форматирования, например:

1. Свойства фрагмента на слайде.
1. Текстовые стили прототипа формы в макете или основном слайде, если у формы текстовой области фрагмента есть такой стиль.
1. Глобальные настройки текста в презентации.

Локальные значения могут быть определены или опущены на любом уровне. Когда Aspose.Slides требуется окончательное форматирование «как отрисовано», он разрешает цепочку наследования и возвращает **эффективные** значения. Получить их можно, вызвав метод `getEffective` у объекта локального формата.

Следующий пример показывает, как получить эффективные значения. Предполагается, что первая фигура на первом слайде — это [IAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IAutoShape) с текстовой областью и как минимум одним фрагментом.

```java
import com.aspose.slides.*;

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

{{% alert color="info" %}}
Эффективные данные форматирования представляют текущие вычисленные параметры после применения наследования. В текущей реализации некоторые объекты эффективных данных, такие как [IPortionFormatEffectiveData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IPortionFormatEffectiveData), могут кэшироваться внутри. Повторный вызов `getEffective` после изменения родительского или унаследованного форматирования может обновить кэш, и ранее полученный объект может больше не отражать прежнее состояние. Если необходимо сохранить эффективные значения для последующего использования, скопируйте требуемые свойства (например, высоту шрифта, цвет заливки, стиль шрифта или выравнивание) в собственный объект данных.
{{% /alert %}}

## **Получить эффективные свойства камеры**

Aspose.Slides позволяет получить эффективные свойства камеры. Интерфейс [ICameraEffectiveData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ICameraEffectiveData) представляет собой неизменяемый объект, содержащий эффективные свойства камеры. Экземпляр [ICameraEffectiveData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ICameraEffectiveData) раскрывается через [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IThreeDFormatEffectiveData), который предоставляет эффективные значения для [IThreeDFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IThreeDFormat).

Следующий образец кода показывает, как получить эффективные свойства камеры. Предполагается, что первая фигура на первом слайде имеет 3D‑форматирование.

```java
import com.aspose.slides.*;

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

## **Получить эффективные свойства осветительного оборудования**

Aspose.Slides позволяет получить эффективные свойства осветительного оборудования. Интерфейс [ILightRigEffectiveData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ILightRigEffectiveData) представляет собой неизменяемый объект, содержащий эффективные свойства осветительного оборудования. Экземпляр [ILightRigEffectiveData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ILightRigEffectiveData) раскрывается через [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IThreeDFormatEffectiveData), который предоставляет эффективные значения для [IThreeDFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IThreeDFormat).

Следующий образец кода показывает, как получить эффективные свойства осветительного оборудования. Предполагается, что первая фигура на первом слайде имеет 3D‑форматирование.

```java
import com.aspose.slides.*;

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

Aspose.Slides позволяет получить эффективные свойства фаски фигуры. Интерфейс [IShapeBevelEffectiveData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IShapeBevelEffectiveData) представляет собой неизменяемый объект, содержащий эффективные свойства рельефа фаски фигуры. Экземпляр [IShapeBevelEffectiveData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IShapeBevelEffectiveData) раскрывается через [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IThreeDFormatEffectiveData), который предоставляет эффективные значения для [IThreeDFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IThreeDFormat).

Следующий образец кода показывает, как получить эффективные свойства верхней фаски фигуры. Предполагается, что первая фигура на первом слайде имеет 3D‑форматирование.

```java
import com.aspose.slides.*;

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

## **Получить эффективные свойства текстовой области**

С помощью Aspose.Slides можно получить эффективные свойства текстовой области. Интерфейс [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ITextFrameFormatEffectiveData) содержит эффективные параметры форматирования текстовой области.

Следующий образец кода показывает, как получить эффективные параметры форматирования текстовой области. Предполагается, что первая фигура на первом слайде — это [IAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IAutoShape) с текстовой областью.

```java
import com.aspose.slides.*;

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

С помощью Aspose.Slides можно получить эффективные свойства текстового стиля. Интерфейс [ITextStyleEffectiveData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ITextStyleEffectiveData) содержит эффективные параметры текстового стиля.

Следующий образец кода показывает, как получить эффективные параметры текстового стиля. Предполагается, что первая фигура на первом слайде — это [IAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IAutoShape) с текстовой областью.

```java
import com.aspose.slides.*;

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
import com.aspose.slides.*;

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

## **Получить эффективный формат заливки для таблицы**

С помощью Aspose.Slides можно получить эффективное форматирование заливки для различных частей таблицы. Интерфейс [IFillFormatEffectiveData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IFillFormatEffectiveData) содержит эффективные параметры форматирования заливки. Форматирование ячейки имеет более высокий приоритет, чем форматирование строки; форматирование строки — выше, чем форматирование столбца; форматирование столбца — выше, чем форматирование всей таблицы.

В результате свойства [ICellFormatEffectiveData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ICellFormatEffectiveData) используются при отрисовке ячейки таблицы. Следующий образец кода показывает, как получить эффективное форматирование заливки для различных частей таблицы. Предполагается, что первая фигура на первом слайде — это [ITable](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ITable).

```java
import com.aspose.slides.*;

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

## **Часто задаваемые вопросы**

### Возвращает ли `getEffective` моментальный снимок?

Не всегда. Эффективные данные представляют вычисленное форматирование после применения наследования, но некоторые объекты эффективных данных могут кэшироваться внутри. Последующий вызов `getEffective` может пересчитать форматирование и обновить кэш, поэтому ранее полученный объект не следует считать постоянным снимком.

### Когда следует снова считывать эффективные свойства?

Вызовите `getEffective` повторно после изменения локального форматирования, стилей‑родителей, форматирования макета, форматирования мастера или параметров по умолчанию презентации. Следующий вызов переоценит иерархию форматирования и вернёт актуальный эффективный результат.

### Влияет ли изменение или удаление макета/мастер‑слайда на уже полученные эффективные свойства?

Да, изменение отразится при следующем вызове `getEffective`. Если источник родительского форматирования изменён или удалён, ранее полученные эффективные данные могут стать устаревшими. После повторного вызова `getEffective` Aspose.Slides переоценит дерево форматирования, и шрифты, цвета, размеры или другие значения могут измениться.

### Можно ли изменять значения через объекты эффективных данных?

Нет. Объекты эффективных данных лишь предоставляют вычисленные значения. Вносите изменения в локальные объекты форматирования, а затем снова получайте эффективные значения.

### Что происходит, если свойство не задано на уровне фигуры, макета/мастера и глобальных настроек?

Эффективное значение определяется механизмом значений по умолчанию, включающим настройки PowerPoint и Aspose.Slides. Это разрешённое значение становится частью текущих эффективных данных.

### По эффективному значению шрифта можно определить, какой уровень предоставил размер или гарнитуру?

Не напрямую. Эффективные данные возвращают окончательное значение. Чтобы выяснить источник, проверьте локальные значения на уровне фрагмента, абзаца, текстовой области и текстовых стилей в макете, мастере и презентации, чтобы увидеть, где появилось первое явное определение.

### Почему иногда эффективные значения выглядят идентично локальным?

Потому что локальное значение оказалось окончательным (не потребовалось наследование с более высокого уровня). В таких случаях эффективное значение совпадает с локальным.

### Когда следует использовать эффективные свойства, а когда работать только с локальными?

Используйте эффективные данные, когда нужен результат «как отрисовано» после применения всего наследования, например для согласования цветов, отступов или размеров. Если необходимо сохранить эти значения независимо от последующих изменений форматирования, скопируйте нужные свойства в свой собственный объект. Если требуется изменить форматирование на определённом уровне, изменяйте локальные свойства и, при необходимости, снова считывайте эффективные данные для проверки результата.