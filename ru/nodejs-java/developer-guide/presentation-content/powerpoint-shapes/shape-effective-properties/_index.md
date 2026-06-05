---
title: Получить эффективные свойства фигур из презентаций на JavaScript
linktitle: Эффективные свойства
type: docs
weight: 50
url: /ru/nodejs-java/shape-effective-properties/
keywords:
- свойства фигур
- свойства камеры
- осветительное оборудование
- фаска формы
- текстовый фрейм
- стиль текста
- высота шрифта
- формат заливки
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Узнайте, как Aspose.Slides для Node.js через Java вычисляет и применяет эффективные свойства фигур для точного рендеринга PowerPoint."
---
## **Обзор**

Эта тема объясняет разницу между **локальными** и **эффективными** свойствами. Локальные значения — это значения, задаваемые напрямую на определённом уровне форматирования, например:

1. Свойства фрагмента на слайде.
1. Стилевые шаблоны текста формы‑прототипа на макете или мастере, если у формы текстового фрейма фрагмента есть такой стиль.
1. Глобальные настройки текста в презентации.

Локальные значения могут быть заданы или опущены на любом уровне. Когда Aspose.Slides требуется окончательное форматирование «как отрендерено», она разрешает цепочку наследования и возвращает **эффективные** значения. Получить их можно, вызвав метод `getEffective` у локального объекта формата.

Следующий пример показывает, как получить эффективные значения. Предполагается, что первая форма на первом слайде является [AutoShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/autoshape/) с текстовым фреймом и как минимум одним фрагментом.

```javascript

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let localTextFrameFormat = shape.getTextFrame().getTextFrameFormat();
    let effectiveTextFrameFormat = localTextFrameFormat.getEffective();

    let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    let localPortionFormat = paragraph.getPortions().get_Item(0).getPortionFormat();
    let effectivePortionFormat = localPortionFormat.getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
Эффективные данные форматирования представляют текущие вычисленные параметры после применения наследования. В текущей реализации некоторые объекты эффективных данных могут кэшироваться внутренне. Повторный вызов `getEffective` после изменения родительского или наследуемого форматирования может обновить кэшированные данные, и ранее полученный объект может больше не отражать прежнее состояние. Если необходимо сохранить эффективные значения для последующего использования, скопируйте требуемые свойства, такие как высота шрифта, цвет заливки, стиль шрифта или выравнивание, в свой собственный объект данных.
{{% /alert %}}

## **Получить эффективные свойства камеры**

Aspose.Slides позволяет получить эффективные свойства камеры. Объект данных эффективной камеры содержит неизменяемые свойства камеры и предоставляется через эффективные значения, возвращаемые для [ThreeDFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/threedformat/).

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let camera = threeDEffectiveData.getCamera();
    let cameraType = camera.getCameraType();
    let fieldOfViewAngle = camera.getFieldOfViewAngle();
    let zoom = camera.getZoom();

    console.log("= Effective camera properties =");
    console.log("Type: " + cameraType);
    console.log("Field of view: " + fieldOfViewAngle);
    console.log("Zoom: " + zoom);
} finally {
    presentation.dispose();
}
```

## **Получить эффективные свойства светового оборудования**

Aspose.Slides позволяет получить эффективные свойства светового оборудования. Объект данных эффективного светового оборудования содержит неизменяемые свойства освещения и предоставляется через эффективные значения, возвращаемые для [ThreeDFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/threedformat/).

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let lightRig = threeDEffectiveData.getLightRig();
    let lightType = lightRig.getLightType();
    let direction = lightRig.getDirection();

    console.log("= Effective light rig properties =");
    console.log("Type: " + lightType);
    console.log("Direction: " + direction);
} finally {
    presentation.dispose();
}
```

## **Получить эффективные свойства фаски формы**

Aspose.Slides позволяет получить эффективные свойства фаски формы. Объект данных эффективной фаски содержит неизменяемые свойства рельефа грани формы и предоставляется через эффективные значения, возвращаемые для [ThreeDFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/threedformat/).

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let bevelTop = threeDEffectiveData.getBevelTop();
    let bevelType = bevelTop.getBevelType();
    let bevelWidth = bevelTop.getWidth();
    let bevelHeight = bevelTop.getHeight();

    console.log("= Effective shape's top face relief properties =");
    console.log("Type: " + bevelType);
    console.log("Width: " + bevelWidth);
    console.log("Height: " + bevelHeight);
} finally {
    presentation.dispose();
}
```

## **Получить эффективные свойства текстового фрейма**

Используя Aspose.Slides, вы можете получить эффективные свойства текстового фрейма. Возвращаемый объект эффективных данных содержит свойства форматирования текстового фрейма.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    let effectiveTextFrameFormat = textFrameFormat.getEffective();
    let anchoringType = effectiveTextFrameFormat.getAnchoringType();
    let autofitType = effectiveTextFrameFormat.getAutofitType();
    let textVerticalType = effectiveTextFrameFormat.getTextVerticalType();
    let marginLeft = effectiveTextFrameFormat.getMarginLeft();
    let marginTop = effectiveTextFrameFormat.getMarginTop();
    let marginRight = effectiveTextFrameFormat.getMarginRight();
    let marginBottom = effectiveTextFrameFormat.getMarginBottom();

    console.log("Anchoring type: " + anchoringType);
    console.log("Autofit type: " + autofitType);
    console.log("Text vertical type: " + textVerticalType);
    console.log("Margins");
    console.log("   Left: " + marginLeft);
    console.log("   Top: " + marginTop);
    console.log("   Right: " + marginRight);
    console.log("   Bottom: " + marginBottom);
} finally {
    presentation.dispose();
}
```

## **Получить эффективные свойства текстового стиля**

Используя Aspose.Slides, вы можете получить эффективные свойства текстового стиля. Возвращаемый объект эффективных данных содержит свойства текстового стиля.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);
    let effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    let levelCount = 9;

    for (let levelIndex = 0; levelIndex < levelCount; levelIndex++) {
        let effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);
        let depth = effectiveStyleLevel.getDepth();
        let indent = effectiveStyleLevel.getIndent();
        let alignment = effectiveStyleLevel.getAlignment();
        let fontAlignment = effectiveStyleLevel.getFontAlignment();

        console.log("= Effective paragraph formatting for style level #" + levelIndex + " =");

        console.log("Depth: " + depth);
        console.log("Indent: " + indent);
        console.log("Alignment: " + alignment);
        console.log("Font alignment: " + fontAlignment);
    }
} finally {
    presentation.dispose();
}
```

## **Получить значение эффективной высоты шрифта**

С помощью Aspose.Slides можно получить эффективную высоту шрифта. Ниже приведён код, демонстрирующий, как меняется эффективная высота шрифта у фрагмента после установки локальных значений высоты шрифта на различных уровнях структуры презентации.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shapeType = aspose.slides.ShapeType.Rectangle;
    let autoShape = slide.getShapes().addAutoShape(shapeType, 100, 100, 400, 75, false);
    autoShape.addTextFrame("");

    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    let firstPortion = new aspose.slides.Portion("Sample text with first portion");
    let secondPortion = new aspose.slides.Portion(" and second portion.");

    paragraph.getPortions().add(firstPortion);
    paragraph.getPortions().add(secondPortion);

    let firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    let secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    let firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    let secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height just after creation:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting the presentation default font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting paragraph default font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    firstPortion.getPortionFormat().setFontHeight(55);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting portion #0 font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    secondPortion.getPortionFormat().setFontHeight(18);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting portion #1 font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    let saveFormat = aspose.slides.SaveFormat.Pptx;
    presentation.save("SetLocalFontHeightValues.pptx", saveFormat);
} finally {
    presentation.dispose();
}
```

## **Получить эффективный формат заливки таблицы**

С помощью Aspose.Slides можно получить эффективное форматирование заливки для разных частей таблицы. Возвращаемый объект эффективных данных содержит свойства форматирования заливки. Форматирование ячейки имеет более высокий приоритет, чем форматирование строки, строковое — выше, чем форматирование столбца, а форматирование столбца — выше, чем форматирование всей таблицы.

В результате свойства эффективного форматирования ячейки используются при отрисовке ячейки таблицы. Ниже показан пример кода, демонстрирующий, как получить эффективное форматирование заливки для разных частей таблицы. Предполагается, что первая форма на первом слайде является [Table](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/table/).

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let table = slide.getShapes().get_Item(0);

    let tableFormatEffective = table.getTableFormat().getEffective();
    let rowFormatEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    let columnFormatEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    let cellFormatEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    let tableFillFormatEffective = tableFormatEffective.getFillFormat();
    let rowFillFormatEffective = rowFormatEffective.getFillFormat();
    let columnFillFormatEffective = columnFormatEffective.getFillFormat();
    let cellFillFormatEffective = cellFormatEffective.getFillFormat();
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Возвращает ли `getEffective` снимок?**

Не всегда. Эффективные данные представляют вычисленное форматирование после применения наследования, однако некоторые объекты эффективных данных могут кэшироваться внутренне. Последующий вызов `getEffective` может пересчитать форматирование и обновить кэшированные данные, поэтому ранее полученный объект не следует рассматривать как постоянный снимок.

**Когда следует снова считывать эффективные свойства?**

Вызовите `getEffective` повторно после изменения локального форматирования, стилей‑родителей, форматирования макета, форматирования мастера или параметров по умолчанию на уровне презентации. Следующий вызов переоценит иерархию форматирования и вернёт текущий эффективный результат.

**Влияет ли изменение или удаление макета/мастер‑слайда на уже полученные эффективные свойства?**

Да, но изменение учитывается только при следующем вызове `getEffective`. Если источник форматирования‑родителя изменён или удалён, ранее полученные эффективные данные могут стать устаревшими. После повторного вызова `getEffective` Aspose.Slides переоценит дерево форматирования, и результаты — шрифты, цвета, размеры и другие значения — могут измениться.

**Могу ли я изменять значения через объекты эффективных данных?**

Нет. Объекты эффективных данных предоставляют только вычисленные значения. Вносите изменения в локальные объекты форматирования, а затем снова получайте эффективные значения.

**Что происходит, если свойство не задано на уровне формы, макета/мастера и глобальных настроек?**

Эффективное значение определяется механизмом значений по умолчанию, включающим настройки PowerPoint и Aspose.Slides. Это полученное значение становится частью текущих эффективных данных.

**Можно ли по эффективному значению шрифта определить, какой уровень предоставил размер или тип шрифта?**

Не напрямую. Эффективные данные возвращают окончательное значение. Чтобы определить источник, проверьте локальные значения на уровне фрагмента, абзаца, текстового фрейма и текстовых стилей на уровнях макета, мастера и презентации, чтобы увидеть, где появилось первое явное определение.

**Почему иногда эффективные значения совпадают с локальными?**

Потому что локальное значение оказалось окончательным (не потребовалось наследование с более высокого уровня). В таких случаях эффективное значение совпадает с локальным.

**Когда следует использовать эффективные свойства, а когда работать только с локальными?**

Используйте эффективные данные, когда требуется результат «как отрендерено» после применения всего наследования, например для согласования цветов, отступов или размеров. Если необходимо сохранить эти значения независимо от последующих изменений форматирования, скопируйте нужные свойства в свой объект. Если нужно изменить форматирование на определённом уровне, измените локальные свойства и, при необходимости, снова прочитайте эффективные данные, чтобы проверить результат.