---
title: Получить эффективные свойства фигур из презентаций на JavaScript
linktitle: Эффективные свойства
type: docs
weight: 50
url: /ru/nodejs-java/shape-effective-properties/
keywords:
- свойства фигуры
- свойства камеры
- освещение
- скошенная форма
- текстовый фрейм
- стиль текста
- высота шрифта
- формат заливки
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Узнайте, как Aspose.Slides for Node.js via Java вычисляет и применяет эффективные свойства фигур для точного отображения PowerPoint."
---

В этой теме мы рассмотрим **эффективные** и **локальные** свойства. Когда мы задаём значения напрямую на этих уровнях

1. В свойствах части на слайде части;
1. В стиле текста прототипной формы на шаблоне или главном слайде (если у формы текстового фрейма части есть стиль);
1. В глобальных настройках текста презентации;

эти значения называют **локальными** значениями. На любом уровне **локальные** значения могут быть определены или опущены. Но когда приложению нужно знать, как должна выглядеть часть, оно использует **эффективные** значения. Получить эффективные значения можно, вызвав метод **getEffective()** у локального формата.

В этом примере кода показано, как получить эффективные значения:
```javascript
var pres = new aspose.slides.Presentation("Presentation1.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var localTextFrameFormat = shape.getTextFrame().getTextFrameFormat();
    var effectiveTextFrameFormat = localTextFrameFormat.getEffective();
    var localPortionFormat = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    var effectivePortionFormat = localPortionFormat.getEffective();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Получение эффективных свойств камеры**
Aspose.Slides for Node.js via Java позволяет разработчикам получать эффективные свойства камеры. Для этой цели в Aspose.Slides был добавлен класс **CameraEffectiveData**. Класс **CameraEffectiveData** представляет собой неизменяемый объект, содержащий эффективные свойства камеры. Экземпляр класса **CameraEffectiveData** используется в составе класса **ThreeDFormatEffectiveData**, который является парой [эффективных значений](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getEffective--) для класса [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat).

Этот пример кода показывает, как получить эффективные свойства камеры:
```javascript
var pres = new aspose.slides.Presentation("Presentation1.pptx");
try {
    var threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();
    console.log("= Effective camera properties =");
    console.log("Type: " + threeDEffectiveData.getCamera().getCameraType());
    console.log("Field of view: " + threeDEffectiveData.getCamera().getFieldOfViewAngle());
    console.log("Zoom: " + threeDEffectiveData.getCamera().getZoom());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Получение эффективных свойств Light Rig**
Aspose.Slides for Node.js via Java позволяет разработчикам получать эффективные свойства Light Rig. Для этой цели в Aspose.Slides был добавлен класс **LightRigEffectiveData**. Класс **LightRigEffectiveData** представляет собой неизменяемый объект, содержащий эффективные свойства Light Rig. Экземпляр класса **LightRigEffectiveData** используется в составе класса **ThreeDFormatEffectiveData**, который является парой [эффективных значений](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getEffective--) для класса [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat).

Этот пример кода показывает, как получить эффективные свойства Light Rig:
```javascript
var pres = new aspose.slides.Presentation("Presentation1.pptx");
try {
    var threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();
    console.log("= Effective light rig properties =");
    console.log("Type: " + threeDEffectiveData.getLightRig().getLightType());
    console.log("Direction: " + threeDEffectiveData.getLightRig().getDirection());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Получение эффективных свойств Bevel Shape**
Aspose.Slides for Node.js via Java позволяет разработчикам получать эффективные свойства Bevel Shape. Для этой цели в Aspose.Slides был добавлен класс **ShapeBevelEffectiveData**. Класс **ShapeBevelEffectiveData** представляет собой неизменяемый объект, содержащий эффективные свойства рельефа грани формы. Экземпляр класса **ShapeBevelEffectiveData** используется в составе класса **ThreeDFormatEffectiveData**, который является парой [эффективных значений](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getEffective--) для класса [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat).

Этот пример кода показывает, как получить эффективные свойства Bevel Shape:
```javascript
var pres = new aspose.slides.Presentation("Presentation1.pptx");
try {
    var threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();
    console.log("= Effective shape's top face relief properties =");
    console.log("Type: " + threeDEffectiveData.getBevelTop().getBevelType());
    console.log("Width: " + threeDEffectiveData.getBevelTop().getWidth());
    console.log("Height: " + threeDEffectiveData.getBevelTop().getHeight());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Получение эффективных свойств Text Frame**
Используя Aspose.Slides for Node.js via Java, вы можете получить эффективные свойства Text Frame. Для этой цели в Aspose.Slides был добавлен класс **TextFrameFormatEffectiveData**. Он содержит эффективные свойства форматирования текстового фрейма.

Этот пример кода показывает, как получить эффективные свойства форматирования текстового фрейма:
```javascript
var pres = new aspose.slides.Presentation("Presentation1.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var effectiveTextFrameFormat = shape.getTextFrame().getTextFrameFormat().getEffective();
    console.log("Anchoring type: " + effectiveTextFrameFormat.getAnchoringType());
    console.log("Autofit type: " + effectiveTextFrameFormat.getAutofitType());
    console.log("Text vertical type: " + effectiveTextFrameFormat.getTextVerticalType());
    console.log("Margins");
    console.log("   Left: " + effectiveTextFrameFormat.getMarginLeft());
    console.log("   Top: " + effectiveTextFrameFormat.getMarginTop());
    console.log("   Right: " + effectiveTextFrameFormat.getMarginRight());
    console.log("   Bottom: " + effectiveTextFrameFormat.getMarginBottom());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Получение эффективных свойств Text Style**
Используя Aspose.Slides for Node.js via Java, вы можете получить эффективные свойства Text Style. Для этой цели в Aspose.Slides был добавлен класс **TextStyleEffectiveData**. Он содержит эффективные свойства текстового стиля.

Этот пример кода показывает, как получить эффективные свойства текстового стиля:
```javascript
var pres = new aspose.slides.Presentation("Presentation1.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    for (var i = 0; i <= 8; i++) {
        var effectiveStyleLevel = effectiveTextStyle.getLevel(i);
        console.log(("= Effective paragraph formatting for style level #" + i) + " =");
        console.log("Depth: " + effectiveStyleLevel.getDepth());
        console.log("Indent: " + effectiveStyleLevel.getIndent());
        console.log("Alignment: " + effectiveStyleLevel.getAlignment());
        console.log("Font alignment: " + effectiveStyleLevel.getFontAlignment());
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Получение эффективного значения высоты шрифта**
Используя Aspose.Slides for Node.js via Java, вы можете получить эффективные свойства высоты шрифта. Здесь приведён код, показывающий изменение эффективного значения высоты шрифта части после установки локальных значений высоты шрифта на разных уровнях структуры презентации:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var newShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 75, false);
    newShape.addTextFrame("");
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().clear();
    var portion0 = new aspose.slides.Portion("Sample text with first portion");
    var portion1 = new aspose.slides.Portion(" and second portion.");
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion0);
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion1);
    console.log("Effective font height just after creation:");
    console.log("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    console.log("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());
    pres.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    console.log("Effective font height after setting entire presentation default font height:");
    console.log("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    console.log("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());
    newShape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    console.log("Effective font height after setting paragraph default font height:");
    console.log("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    console.log("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setFontHeight(55);
    console.log("Effective font height after setting portion #0 font height:");
    console.log("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    console.log("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1).getPortionFormat().setFontHeight(18);
    console.log("Effective font height after setting portion #1 font height:");
    console.log("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    console.log("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());
    pres.save("SetLocalFontHeightValues.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Получение эффективного формата заливки для таблицы**
Используя Aspose.Slides for Node.js via Java, вы можете получить эффективное форматирование заливки для различных логических частей таблицы. Для этой цели в Aspose.Slides был добавлен класс **CellFormatEffectiveData**. Он содержит эффективные свойства форматирования заливки. Обратите внимание: форматирование ячейки всегда имеет приоритет над форматированием строки; строка — над столбцом; столбец — над всей таблицей.
```javascript
var pres = new aspose.slides.Presentation("Presentation1.pptx");
try {
    var tbl = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var tableFormatEffective = tbl.getTableFormat().getEffective();
    var rowFormatEffective = tbl.getRows().get_Item(0).getRowFormat().getEffective();
    var columnFormatEffective = tbl.getColumns().get_Item(0).getColumnFormat().getEffective();
    var cellFormatEffective = tbl.get_Item(0, 0).getCellFormat().getEffective();
    var tableFillFormatEffective = tableFormatEffective.getFillFormat();
    var rowFillFormatEffective = rowFormatEffective.getFillFormat();
    var columnFillFormatEffective = columnFormatEffective.getFillFormat();
    var cellFillFormatEffective = cellFormatEffective.getFillFormat();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Как я могу понять, что получил «snapshot», а не «live object», и когда следует снова читать эффективные свойства?**  
Объекты EffectiveData являются неизменяемыми снимками вычисленных значений на момент вызова. Если вы измените локальные или унаследованные параметры формы, снова получите эффективные данные, чтобы получить обновлённые значения.

**Влияет ли изменение шаблона/главного слайда на эффективные свойства, которые уже были получены?**  
Да, но только после повторного чтения. Уже полученный объект EffectiveData не обновляется сам — запросите его снова после изменения шаблона или главного слайда.

**Можно ли изменять значения через EffectiveData?**  
Нет. EffectiveData доступен только для чтения. Вносите изменения в локальные объекты форматирования (форма/текст/3D и т.д.), а затем снова получайте эффективные значения.

**Что происходит, если свойство не задано на уровне формы, шаблона/главного слайда и не задано в глобальных настройках?**  
Эффективное значение определяется механизмом значений по умолчанию (по умолчанию PowerPoint/Aspose.Slides). Полученное значение становится частью снимка EffectiveData.

**По эффективному значению шрифта можно ли определить, какой уровень предоставил размер или гарнитуру?**  
Не напрямую. EffectiveData возвращает окончательное значение. Чтобы найти источник, проверьте локальные значения на уровне части/абзаца/текстового фрейма и текстовые стили на уровне шаблона/главного слайда/презентации, где появляется первое явное определение.

**Почему значения EffectiveData иногда выглядят одинаково с локальными?**  
Потому что локальное значение оказалось окончательным (не потребовалось наследование с более высокого уровня). В таких случаях эффективное значение совпадает с локальным.

**Когда следует использовать эффективные свойства, а когда работать только с локальными?**  
Используйте EffectiveData, когда нужен результат «как отображается» после применения всего наследования (например, для согласования цветов, отступов или размеров). Если нужно изменить форматирование на конкретном уровне, изменяйте локальные свойства и, при необходимости, снова считывайте EffectiveData для проверки результата.