---
title: Получить эффективные свойства фигур из презентаций на Android
linktitle: Эффективные свойства
type: docs
weight: 50
url: /ru/androidjava/shape-effective-properties/
keywords:
- свойства фигур
- свойства камеры
- световая установка
- фаска формы
- текстовый фрейм
- стиль текста
- высота шрифта
- формат заливки
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Узнайте, как Aspose.Slides для Android через Java вычисляет и применяет эффективные свойства фигур для точного отображения PowerPoint."
---
## **Обзор**

Эта статья объясняет разницу между **локальными** и **эффективными** свойствами. Локальные значения — это значения, установленные непосредственно на определённом уровне форматирования, например:

1. Свойства фрагмента на слайде.
1. Текстовые стили прототипа формы на макете или основном слайде, если у формы текстового фрейма фрагмента есть такой стиль.
1. Глобальные настройки текста в презентации.

Локальные значения могут быть определены или опущены на любом уровне. Когда Aspose.Slides требуется окончательное форматирование «как оно отображается», она разрешает цепочку наследования и возвращает **эффективные** значения. Получить их можно, вызвав метод `getEffective()` у локального объекта формата.

В следующем примере показано, как получить эффективные значения. Предполагается, что первая форма на первом слайде является [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/) с текстовым фреймом и как минимум одним фрагментом.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrame textFrame = shape.getTextFrame();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = textFrame.getTextFrameFormat().getEffective();

    IPortion portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormatEffectiveData effectivePortionFormat = portion.getPortionFormat().getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
Эффективные данные форматирования представляют текущие вычисленные параметры после применения наследования. В текущей реализации некоторые объекты эффективных данных, такие как [IPortionFormatEffectiveData](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iportionformateffectivedata/), могут кэшироваться внутри. Повторный вызов `getEffective()` после изменения родительского или унаследованного форматирования может обновить кэшированные данные, и ранее полученный объект может больше не отражать прежнее состояние. Если необходимо сохранить эффективные значения для последующего использования, скопируйте требуемые свойства, например высоту шрифта, цвет заливки, стиль шрифта или выравнивание, в свой собственный объект данных.
{{% /alert %}}

## **Получить эффективные свойства камеры**

Aspose.Slides позволяет получать эффективные свойства камеры. Интерфейс [ICameraEffectiveData](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/icameraeffectivedata/) представляет собой неизменяемый объект, содержащий эффективные свойства камеры. Экземпляр [ICameraEffectiveData](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/icameraeffectivedata/) доступен через [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformateffectivedata/), который предоставляет эффективные значения для [IThreeDFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/).

В следующем примере кода показано, как получить эффективные свойства камеры. Предполагается, что первая форма на первом слайде имеет 3D-форматирование.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ICameraEffectiveData cameraEffectiveData = threeDEffectiveData.getCamera();

    System.out.println("= Effective camera properties =");
    System.out.println("Type: " + cameraEffectiveData.getCameraType());
    System.out.println("Field of view: " + cameraEffectiveData.getFieldOfViewAngle());
    System.out.println("Zoom: " + cameraEffectiveData.getZoom());
} finally {
    presentation.dispose();
}
```

## **Получить эффективные свойства световой установки**

Aspose.Slides позволяет получать эффективные свойства световой установки. Интерфейс [ILightRigEffectiveData](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilightrigeffectivedata/) представляет собой неизменяемый объект, содержащий эффективные свойства световой установки. Экземпляр [ILightRigEffectiveData](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilightrigeffectivedata/) доступен через [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformateffectivedata/), который предоставляет эффективные значения для [IThreeDFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/).

В следующем примере кода показано, как получить эффективные свойства световой установки. Предполагается, что первая форма на первом слайде имеет 3D-форматирование.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ILightRigEffectiveData lightRigEffectiveData = threeDEffectiveData.getLightRig();

    System.out.println("= Effective light rig properties =");
    System.out.println("Type: " + lightRigEffectiveData.getLightType());
    System.out.println("Direction: " + lightRigEffectiveData.getDirection());
} finally {
    presentation.dispose();
}
```

## **Получить эффективные свойства фаски формы**

Aspose.Slides позволяет получать эффективные свойства фаски формы. Интерфейс [IShapeBevelEffectiveData](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishapebeveleffectivedata/) представляет собой неизменяемый объект, содержащий эффективные свойства рельефа грани формы. Экземпляр [IShapeBevelEffectiveData](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishapebeveleffectivedata/) доступен через [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformateffectivedata/), который предоставляет эффективные значения для [IThreeDFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ithreedformat/).

В следующем примере кода показано, как получить эффективные свойства верхней фаски формы. Предполагается, что первая форма на первом слайде имеет 3D-форматирование.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    IShapeBevelEffectiveData bevelTopEffectiveData = threeDEffectiveData.getBevelTop();

    System.out.println("= Effective shape's top face relief properties =");
    System.out.println("Type: " + bevelTopEffectiveData.getBevelType());
    System.out.println("Width: " + bevelTopEffectiveData.getWidth());
    System.out.println("Height: " + bevelTopEffectiveData.getHeight());
} finally {
    presentation.dispose();
}
```

## **Получить эффективные свойства текстового фрейма**

С помощью Aspose.Slides вы можете получить эффективные свойства текстового фрейма. Интерфейс [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframeformateffectivedata/) содержит эффективные свойства форматирования текстового фрейма.

В следующем примере кода показано, как получить эффективные свойства форматирования текстового фрейма. Предполагается, что первая форма на первом слайде является [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/) с текстовым фреймом.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

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
    presentation.dispose();
}
```

## **Получить эффективные свойства текстового стиля**

С помощью Aspose.Slides вы можете получить эффективные свойства текстового стиля. Интерфейс [ITextStyleEffectiveData](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextstyleeffectivedata/) содержит эффективные свойства текстового стиля.

В следующем примере кода показано, как получить эффективные свойства текстового стиля. Предполагается, что первая форма на первом слайде является [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/) с текстовым фреймом.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    int levelCount = 9;

    for (int levelIndex = 0; levelIndex < levelCount; levelIndex++) {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);

        System.out.println("= Effective paragraph formatting for style level #" + levelIndex + " =");

        System.out.println("Depth: " + effectiveStyleLevel.getDepth());
        System.out.println("Indent: " + effectiveStyleLevel.getIndent());
        System.out.println("Alignment: " + effectiveStyleLevel.getAlignment());
        System.out.println("Font alignment: " + effectiveStyleLevel.getFontAlignment());
    }
} finally {
    presentation.dispose();
}
```

## **Получить значение эффективной высоты шрифта**

С помощью Aspose.Slides вы можете получить эффективную высоту шрифта. В следующем коде демонстрируется, как меняется эффективная высота шрифта фрагмента после установки локальных значений высоты шрифта на разных уровнях структуры презентации.

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

## **Получить эффективный формат заливки для таблицы**

С помощью Aspose.Slides вы можете получать эффективное форматирование заливки для различных частей таблицы. Интерфейс [IFillFormatEffectiveData](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ifillformateffectivedata/) содержит свойства эффективного форматирования заливки. Форматирование ячейки имеет более высокий приоритет, чем форматирование строки, строковое — более высокий, чем форматирование столбца, а форматирование столбца — более высокий, чем форматирование всей таблицы.

В результате свойства [ICellFormatEffectiveData](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/icellformateffectivedata/) используются при отрисовке ячейки таблицы. В следующем примере кода показано, как получить эффективное форматирование заливки для разных частей таблицы. Предполагается, что первая форма на первом слайде является [ITable](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itable/).

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable)slide.getShapes().get_Item(0);

    IRow row = table.getRows().get_Item(0);
    IColumn column = table.getColumns().get_Item(0);
    ICell cell = table.get_Item(0, 0);

    IFillFormatEffectiveData tableFillFormatEffective = table.getTableFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData rowFillFormatEffective = row.getRowFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData columnFillFormatEffective = column.getColumnFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData cellFillFormatEffective = cell.getCellFormat().getEffective().getFillFormat();
} finally {
    presentation.dispose();
}
```

## **Вопросы и ответы**

**Возвращает ли `getEffective()` мгновенный снимок?**

Не всегда. Эффективные данные представляют вычисленное форматирование после применения наследования, но некоторые объекты эффективных данных могут кэшироваться внутри. Последующий вызов `getEffective()` может пересчитать форматирование и обновить кэшированные данные, поэтому ранее полученный объект не следует рассматривать как постоянный снимок.

**Когда следует снова читать эффективные свойства?**

Вызовите `getEffective()` повторно после изменения локального форматирования, стилей‑родителей, форматирования макета, форматирования мастера или параметров по умолчанию на уровне презентации. Следующий вызов переоценит иерархию форматирования и вернёт текущий эффективный результат.

**Влияют ли изменения или удаление макета/основного слайда на уже полученные эффективные свойства?**

Да, но изменение отразится только при следующем вызове `getEffective()`. Если источник родительского форматирования изменён или удалён, ранее полученные эффективные данные могут стать устаревшими. После повторного вызова `getEffective()` Aspose.Slides переоценивает дерево форматирования, и полученные шрифты, цвета, размеры или другие значения могут измениться.

**Можно ли изменять значения через объекты эффективных данных?**

Нет. Объекты эффективных данных только предоставляют вычисленные значения. Вносите изменения в локальные объекты форматирования, а затем снова получайте эффективные значения.

**Что происходит, если свойство не задано на уровне формы, макета/мастера и глобальных настроек?**

Эффективное значение определяется механизмом значений по умолчанию, включающим настройки PowerPoint и Aspose.Slides. Полученное значение становится частью текущих эффективных данных.

**Можно ли по эффективному значению шрифта определить, на каком уровне было задано его размер или гарнитура?**

Не напрямую. Эффективные данные возвращают окончательное значение. Чтобы понять источник, проверяйте локальные значения на уровне фрагмента, абзаца, текстового фрейма и текстовых стилей на макете, мастере и уровне презентации, ищя первое явное определение.

**Почему иногда эффективные значения выглядят идентичными локальным?**

Потому что локальное значение оказалось окончательным (не потребовалось наследовать значение с более высокого уровня). В таких случаях эффективное значение совпадает с локальным.

**Когда следует использовать эффективные свойства, а когда работать только с локальными?**

Используйте эффективные данные, когда нужен результат «как он будет отрисован» после применения всего наследования, например для согласования цветов, отступов или размеров. Если необходимо сохранить эти значения независимо от будущих изменений форматирования, скопируйте нужные свойства в собственный объект. Если планируется изменять форматирование на конкретном уровне, модифицируйте локальные свойства и, при необходимости, снова читайте эффективные данные, чтобы проверить результат.