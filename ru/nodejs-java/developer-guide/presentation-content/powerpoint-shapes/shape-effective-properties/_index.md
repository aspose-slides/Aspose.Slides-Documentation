---
title: Эффективные свойства фигуры
type: docs
weight: 50
url: /ru/nodejs-java/shape-effective-properties/
---

В этом разделе мы обсудим **эффективные** и **локальные** свойства. Когда мы задаём значения напрямую на этих уровнях

1. В свойствах части на слайде части;
1. В стиле текста прототипа фигуры на макете или мастер‑слайде (если у формы текста части есть такой стиль);
1. В глобальных настройках текста презентации;

эти значения называют **локальными**. На любом уровне **локальные** значения могут быть определены или опущены. Но когда приложению нужно узнать, как должна выглядеть часть, оно использует **эффективные** значения. Получить эффективные значения можно, вызвав метод **getEffective()** у локального формата.

Этот пример кода показывает, как получить эффективные значения:
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
Aspose.Slides for Node.js via Java позволяет разработчикам получать эффективные свойства камеры. Для этой цели в Aspose.Slides был добавлен класс [**CameraEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CameraEffectiveData). Класс [CameraEffectiveData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CameraEffectiveData) представляет неизменяемый объект, содержащий эффективные свойства камеры. Экземпляр [**CameraEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CameraEffectiveData) используется как часть класса [**ThreeDFormatEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormatEffectiveData), который является парой [effective values](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getEffective--) для класса [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat).

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
Aspose.Slides for Node.js via Java позволяет разработчикам получать эффективные свойства Light Rig. Для этой цели в Aspose.Slides был добавлен класс [**LightRigEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LightRigEffectiveData). Класс [LightRigEffectiveData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LightRigEffectiveData) представляет неизменяемый объект, содержащий эффективные свойства осветительной установки. Экземпляр [**LightRigEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LightRigEffectiveData) используется как часть класса [**ThreeDFormatEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormatEffectiveData), который является парой [effective values](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getEffective--) для класса [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat).

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
Aspose.Slides for Node.js via Java позволяет разработчикам получать эффективные свойства Bevel Shape. Для этой цели в Aspose.Slides был добавлен класс [**ShapeBevelEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeBevelEffectiveData). Класс [ShapeBevelEffectiveData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeBevelEffectiveData) представляет неизменяемый объект, содержащий эффективные свойства рельефа грани фигуры. Экземпляр [**ShapeBevelEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeBevelEffectiveData) используется как часть класса [**ThreeDFormatEffectiveData**]([**ShapeBevelEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeBevelEffectiveData)) , который является парой [effective values](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getEffective--) для класса [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat).

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
С помощью Aspose.Slides for Node.js via Java вы можете получать эффективные свойства Text Frame. Для этой цели в Aspose.Slides был добавлен класс [**TextFrameFormatEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormatEffectiveData). Он содержит эффективные свойства форматирования текстовой рамки.

Этот пример кода показывает, как получить эффективные свойства форматирования текстовой рамки:
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
С помощью Aspose.Slides for Node.js via Java вы можете получать эффективные свойства Text Style. Для этой цели в Aspose.Slides был добавлен класс [**TextStyleEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextStyleEffectiveData). Он содержит эффективные свойства стиля текста.

Этот пример кода показывает, как получить эффективные свойства стиля текста:
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
С помощью Aspose.Slides for Node.js via Java вы можете получать эффективные свойства высоты шрифта. Здесь мы предоставляем код, который демонстрирует изменение эффективного значения высоты шрифта части после установки локальных значений высоты шрифта на разных уровнях структуры презентации:
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


## **Получение эффективного формата заполнения для таблицы**
С помощью Aspose.Slides for Node.js via Java вы можете получать эффективное форматирование заполнения для разных логических частей таблицы. Для этой цели в Aspose.Slides был добавлен класс [**CellFormatEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CellFormatEffectiveData). Он содержит эффективные свойства форматирования заполнения. Обратите внимание: форматирование ячейки всегда имеет приоритет над форматированием строки; строка — над столбцом; столбец — над всей таблицей.
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

**Как понять, что я получил «снимок», а не «живой объект», и когда следует снова читать эффективные свойства?**

Объекты EffectiveData — это неизменяемые снимки вычисленных значений на момент вызова. Если вы меняете локальные или унаследованные настройки фигуры, получите эффективные данные снова, чтобы увидеть обновлённые значения.

**Влияет ли изменение макета/мастер‑слайда на уже полученные эффективные свойства?**

Да, но только после повторного чтения. Уже полученный объект EffectiveData не обновляется сам — запросите его снова после изменения макета или мастера.

**Можно ли изменять значения через EffectiveData?**

Нет. EffectiveData только для чтения. Вносьте изменения в локальные объекты форматирования (фигура/текст/3D и т.д.), затем снова получайте эффективные значения.

**Что происходит, если свойство не задано на уровне фигуры, макета/мастера и глобальных настроек?**

Эффективное значение определяется механизмом по умолчанию (стандартные значения PowerPoint/Aspose.Slides). Это разрешённое значение становится частью снимка EffectiveData.

**По эффективному значению шрифта можно ли определить, какой уровень задавал размер или гарнитуру?**

Не напрямую. EffectiveData возвращает окончательное значение. Чтобы найти источник, проверьте локальные значения в части/параграфе/текстовой рамке и стили текста в макете/мастере/презентации, где появляется первое явное определение.

**Почему значения EffectiveData иногда совпадают с локальными?**

Потому что локальное значение оказалось конечным (не потребовалось наследование с более высокого уровня). В таких случаях эффективное значение совпадает с локальным.

**Когда использовать эффективные свойства, а когда работать только с локальными?**

Используйте EffectiveData, когда требуется результат «как будет отображено» после применения всего наследования (например, для согласования цветов, отступов или размеров). Если нужно изменить форматирование на конкретном уровне, изменяйте локальные свойства и, при необходимости, заново считывайте EffectiveData для проверки результата.