---
title: Получить эффективные свойства фигур из презентаций на Java
linktitle: Эффективные свойства
type: docs
weight: 50
url: /ru/java/shape-effective-properties/
keywords:
  - свойства фигур
  - свойства камеры
  - световой комплект
  - фаска формы
  - текстовый кадр
  - текстовый стиль
  - высота шрифта
  - формат заполнения
  - PowerPoint
  - презентация
  - Java
  - Aspose.Slides
description: "Узнайте, как Aspose.Slides для Java вычисляет и применяет эффективные свойства фигур для точного рендеринга PowerPoint."
---
## **Обзор**

Эта тема объясняет различие между **локальными** и **эффективными** свойствами. Локальные значения — это значения, которые задаются непосредственно на определённом уровне форматирования, например:

1. Свойства фрагмента на слайде.  
1. Стили текста прототипной формы на макете или главном слайде, когда у формы текстового кадра фрагмента есть такой стиль.  
1. Глобальные настройки текста в презентации.

Локальные значения могут быть заданы или опущены на любом уровне. Когда Aspose.Slides требует окончательное «как отрендерено» форматирование, он разрешает цепочку наследования и возвращает **эффективные** значения. Их можно получить, вызвав метод `getEffective` у локального объекта формата.

Следующий пример показывает, как получить эффективные значения. Предполагается, что первая форма на первом слайде является [IAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IAutoShape) с текстовым кадром и как минимум одним фрагментом.

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
Эффективные данные форматирования представляют текущие вычисленные параметры после применения наследования. В текущей реализации некоторые объекты эффективных данных, такие как [IPortionFormatEffectiveData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IPortionFormatEffectiveData), могут кэшироваться внутри. Вызов `getEffective` повторно после изменения родительского или унаследованного форматирования может обновить кэшированные данные, и ранее полученный объект может больше не отражать прежнее состояние. Если необходимо сохранить эффективные значения для последующего использования, скопируйте требуемые свойства, например высоту шрифта, цвет заливки, стиль шрифта или выравнивание, в собственный объект данных.
{{% /alert %}}

## **Получить эффективные свойства камеры**

Aspose.Slides позволяет получить эффективные свойства камеры. Интерфейс [ICameraEffectiveData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ICameraEffectiveData) представляет неизменяемый объект, содержащий эффективные свойства камеры. Экземпляр [ICameraEffectiveData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ICameraEffectiveData) доступен через [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IThreeDFormatEffectiveData), который предоставляет эффективные значения для [IThreeDFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IThreeDFormat).

Следующий пример кода показывает, как получить эффективные свойства камеры. Предполагается, что первая форма на первом слайде имеет 3D‑форматирование.

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

## **Получить эффективные свойства светового установки**

Aspose.Slides позволяет получить эффективные свойства светового оборудования. Интерфейс [ILightRigEffectiveData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ILightRigEffectiveData) представляет неизменяемый объект, содержащий эффективные свойства световой установки. Экземпляр [ILightRigEffectiveData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ILightRigEffectiveData) доступен через [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IThreeDFormatEffectiveData), который предоставляет эффективные значения для [IThreeDFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IThreeDFormat).

Следующий пример кода показывает, как получить эффективные свойства световой установки. Предполагается, что первая форма на первом слайде имеет 3D‑форматирование.

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

## **Получить эффективные свойства фаски формы**

Aspose.Slides позволяет получить эффективные свойства фаски формы. Интерфейс [IShapeBevelEffectiveData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IShapeBevelEffectiveData) представляет неизменяемый объект, содержащий эффективные свойства рельефа фаски формы. Экземпляр [IShapeBevelEffectiveData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IShapeBevelEffectiveData) доступен через [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IThreeDFormatEffectiveData), который предоставляет эффективные значения для [IThreeDFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IThreeDFormat).

Следующий пример кода показывает, как получить эффективные свойства верхней фаски формы. Предполагается, что первая форма на первом слайде имеет 3D‑форматирование.

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

С помощью Aspose.Slides вы можете получить эффективные свойства текстового кадра. Интерфейс [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ITextFrameFormatEffectiveData) содержит эффективные свойства форматирования текстового кадра.

Следующий пример кода показывает, как получить эффективные свойства форматирования текстового кадра. Предполагается, что первая форма на первом слайде является [IAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IAutoShape) с текстовым кадром.

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

С помощью Aspose.Slides вы можете получить эффективные свойства текстового стиля. Интерфейс [ITextStyleEffectiveData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ITextStyleEffectiveData) содержит эффективные свойства текстового стиля.

Следующий пример кода показывает, как получить эффективные свойства текстового стиля. Предполагается, что первая форма на первом слайде является [IAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IAutoShape) с текстовым кадром.

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

С помощью Aspose.Slides вы можете получить эффективную высоту шрифта. Ниже показан пример, демонстрирующий, как эффективная высота шрифта фрагмента изменяется после установки локальных значений высоты шрифта на разных уровнях структуры презентации.

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

## **Получить эффективный формат заполнения для таблицы**

С помощью Aspose.Slides вы можете получить эффективное форматирование заполнения для различных частей таблицы. Интерфейс [IFillFormatEffectiveData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IFillFormatEffectiveData) содержит эффективные свойства форматирования заполнения. Форматирование ячейки имеет более высокий приоритет, чем форматирование строки, форматирование строки имеет более высокий приоритет, чем форматирование столбца, а форматирование столбца — более высокий приоритет, чем форматирование всей таблицы.

В результате свойства [ICellFormatEffectiveData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ICellFormatEffectiveData) используются для отрисовки ячейки таблицы. Следующий пример кода показывает, как получить эффективное форматирование заполнения для различных частей таблицы. Предполагается, что первая форма на первом слайде является [ITable](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ITable).

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

Не всегда. Эффективные данные представляют вычисленное форматирование после применения наследования, но некоторые объекты эффективных данных могут кэшироваться внутри. Последующий вызов `getEffective` может пересчитать форматирование и обновить кэш, поэтому ранее полученный объект не следует рассматривать как постоянный снимок.

**Когда следует снова читать эффективные свойства?**

Вызовите `getEffective` повторно после изменения локального форматирования, стилей‑родителей, форматирования макета, форматирования шаблона или параметров по умолчанию презентации. Следующий вызов переоценит иерархию форматирования и вернёт текущий эффективный результат.

**Влияют ли изменения или удаление макета/шаблона слайда на уже полученные эффективные свойства?**

Да, но изменение отразится только при следующем вызове `getEffective`. Если источник форматирования‑родителя изменён или удалён, ранее полученные эффективные данные могут стать устаревшими. После повторного вызова `getEffective` Aspose.Slides переоценит дерево форматирования, и полученные шрифты, цвета, размеры или другие значения могут измениться.

**Можно ли изменять значения через объекты эффективных данных?**

Нет. Объекты эффективных данных предоставляют только вычисленные значения. Вносите изменения в локальные объекты форматирования, а затем снова получайте эффективные значения.

**Что происходит, если свойство не задано на уровне формы, макета/шаблона и глобальных настроек?**

Эффективное значение определяется механизмом значений по умолчанию, который включает настройки PowerPoint и Aspose.Slides. Полученное значение становится частью текущих эффективных данных.

**Можно ли по эффективному значению шрифта определить, на каком уровне было задано размер или гарнитура?**

Не напрямую. Эффективные данные возвращают окончательное значение. Чтобы узнать источник, проверьте локальные значения на уровне фрагмента, параграфа, текстового кадра и текстовых стилей на уровнях макета, шаблона и презентации, чтобы увидеть, где впервые появилось явное определение.

**Почему иногда эффективные значения выглядят идентичными локальным?**

Потому что локальное значение оказалось окончательным (не потребовалось наследование из более высокого уровня). В таких случаях эффективное значение совпадает с локальным.

**Когда следует использовать эффективные свойства, а когда работать только с локальными?**

Используйте эффективные данные, когда нужен результат «как отрендерено» после применения всего наследования, например для согласования цветов, отступов или размеров. Если требуется сохранять эти значения независимо от последующих изменений форматирования, скопируйте необходимые свойства в собственный объект. Если нужно изменить форматирование на конкретном уровне, изменяйте локальные свойства и, при необходимости, снова читайте эффективные данные для проверки результата.