---
title: Управление текстовыми полями в презентациях с помощью JavaScript
linktitle: Управление текстовым полем
type: docs
weight: 20
url: /ru/nodejs-java/manage-textbox/
keywords:
- текстовое поле
- текстовый фрейм
- добавить текст
- обновить текст
- создать текстовое поле
- проверить текстовое поле
- добавить колонку текста
- добавить гиперссылку
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides для Node.js упрощает создание, редактирование и клонирование текстовых полей в файлах PowerPoint и OpenDocument, улучшая автоматизацию ваших презентаций."
---
## **Введение**

Текст на слайдах обычно находится в текстовых полях или фигурах. Поэтому, чтобы добавить текст на слайд, необходимо добавить текстовое поле, а затем поместить в него текст. Aspose.Slides for Node.js via Java предоставляет класс [AutoShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/AutoShape), который позволяет добавить фигуру, содержащую текст.

{{% alert title="Info" color="info" %}}

Aspose.Slides также предоставляет класс [Shape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Shape), который позволяет добавлять фигуры на слайды. Однако не все фигуры, добавленные через класс `Shape`, могут содержать текст. Фигуры, добавленные через класс [AutoShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/AutoShape), могут содержать текст.

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

Поэтому, работая с фигурой, к которой вы хотите добавить текст, рекомендуется проверить, что она была создана через класс `AutoShape`. Только в этом случае вы сможете работать с [TextFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/TextFrame), который является свойством `AutoShape`. См. раздел [Update Text](https://docs.aspose.com/slides/ru/nodejs-java/manage-textbox/#update-text) на этой странице.

{{% /alert %}}

## **Создание текстового поля на слайде**

Чтобы создать текстовое поле на слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Presentation).  
2. Получите ссылку на первый слайд в только что созданной презентации.  
3. Добавьте объект [AutoShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/AutoShape) с типом `ShapeType` — `Rectangle` в указанное положение на слайде и получите ссылку на добавленный объект `AutoShape`.  
4. Добавьте свойство `TextFrame` к объекту `AutoShape`, которое будет содержать текст. В примере ниже мы добавили такой текст: *Aspose TextBox*  
5. Наконец, запишите файл PPTX через объект `Presentation`.  

Этот JavaScript‑код — реализация описанных шагов — показывает, как добавить текст на слайд:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Создает экземпляр Presentation
var pres = new aspose.slides.Presentation();
try {
    // Получает первый слайд в презентации
    var sld = pres.getSlides().get_Item(0);
    // Добавляет AutoShape с типом Rectangle
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // Добавляет TextFrame к Rectangle
    ashp.addTextFrame(" ");
    // Получает доступ к TextFrame
    var txtFrame = ashp.getTextFrame();
    // Создает объект Paragraph для TextFrame
    var para = txtFrame.getParagraphs().get_Item(0);
    // Создает объект Portion для параграфа
    var portion = para.getPortions().get_Item(0);
    // Устанавливает текст
    portion.setText("Aspose TextBox");
    // Сохраняет презентацию на диск
    pres.save("TextBox_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Проверка, является ли фигура текстовым полем**

Aspose.Slides предоставляет метод [isTextBox](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/autoshape/#isTextBox) класса [AutoShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/autoshape/), позволяющий определить, является ли фигура текстовым полем.

![Text box and shape](istextbox.png)

Этот JavaScript‑код показывает, как проверить, было ли создано фигуру как текстовое поле:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (var slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        var slide = presentation.getSlides().get_Item(slideIndex);
        for (var shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            var shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                var autoShape = shape;
                console.log(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Обратите внимание, что если вы просто добавите автофигуру с помощью метода `addAutoShape` класса [ShapeCollection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shapecollection/), метод `isTextBox` у автофигуры вернёт `false`. Однако после того, как вы добавите текст в автофигуру с помощью метода `addTextFrame` или `setText`, свойство `isTextBox` вернёт `true`.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
var slide = presentation.getSlides().get_Item(0);

var shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox() возвращает false
shape1.addTextFrame("shape 1");
// shape1.isTextBox() возвращает true

var shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox() возвращает false
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox() возвращает true

var shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox() возвращает false
shape3.addTextFrame("");
// shape3.isTextBox() возвращает false

var shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox() возвращает false
shape4.getTextFrame().setText("");
// shape4.isTextBox() возвращает false
```

## **Нахождение фигуры, владеющей TextFrame**

В общем коде обработки текста вы можете получить объект [TextFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/) без предварительного знания, к какой презентации он принадлежит. Используйте метод [TextFrame.getParentShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/#getParentShape--) для перехода к владеющей [Shape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/).

Для текстового фрейма, принадлежащего [AutoShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/autoshape/) или другой фигуре, содержащей текст, метод [TextFrame.getParentShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/#getParentShape--) возвращает владельца, а метод [TextFrame.getParentCell](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/#getParentCell--) возвращает `null`. Оба метода предоставляют только чтение, поэтому их вызов не меняет владения. Всегда проверяйте возвращаемое значение на `null` перед доступом к фигуре.

Для полного примера, показывающего определение владельцев фигур и ячеек таблиц, включая фигуры, связанные с узлами SmartArt, см. [Search and Replace Text](/slides/ru/nodejs-java/search-and-replace-text/).

## **Добавление колонок в текстовое поле**

Aspose.Slides предоставляет методы [setColumnCount](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) и [setColumnSpacing](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/TextFrameFormat#setColumnSpacing-double-) класса [TextFrameFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/TextFrameFormat), которые позволяют добавлять колонки в текстовые поля. Вы можете задать количество колонок и установить расстояние между ними в пунктах.

Этот JavaScript‑код демонстрирует описанную операцию:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    // Получает первый слайд в презентации
    var slide = pres.getSlides().get_Item(0);
    // Добавляет AutoShape с типом Rectangle
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // Добавляет TextFrame к Rectangle
    aShape.addTextFrame((("All these columns are limited to be within a single text container -- " + "you can add or delete text and the new or remaining text automatically adjusts ") + "itself to flow within the container. You cannot have text flow from one container ") + "to other though -- we told you PowerPoint's column options for text are limited!"));
    // Получает формат текста TextFrame
    var format = aShape.getTextFrame().getTextFrameFormat();
    // Указывает количество колонок в TextFrame
    format.setColumnCount(3);
    // Указывает расстояние между колонками
    format.setColumnSpacing(10);
    // Сохраняет презентацию
    pres.save("ColumnCount.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Добавление колонок в TextFrame**

Aspose.Slides for Node.js via Java предоставляет метод [setColumnCount](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) класса [TextFrameFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/TextFrameFormat), который позволяет добавлять колонки в текстовые фреймы. С помощью этого свойства вы можете указать желаемое количество колонок в TextFrame.

Этот JavaScript‑код показывает, как добавить колонку внутри TextFrame:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const assert = require("assert");

var outPptxFileName = "ColumnsTest.pptx";
var pres = new aspose.slides.Presentation();
try {
    var shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    var format = shape1.getTextFrame().getTextFrameFormat();
    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " + "you can add or delete text - and the new or remaining text automatically adjusts " + "itself to stay within the container. You cannot have text spill over from one container " + "to other, though -- because PowerPoint's column options for text are limited!");
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test.getSlides().get_Item(0).getShapes().get_Item(0);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnCount(), 2);
        // Расстояние между колонками никогда не устанавливалось, поэтому возвращается NaN.
        assert.ok(Number.isNaN(autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing()));
    } finally {
        if (test != null) {
            test.dispose();
        }
    }
    format.setColumnSpacing(20);
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test1 = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test1.getSlides().get_Item(0).getShapes().get_Item(0);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnCount(), 2);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing(), 20);
    } finally {
        if (test1 != null) {
            test1.dispose();
        }
    }
    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test2 = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test2.getSlides().get_Item(0).getShapes().get_Item(0);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnCount(), 3);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing(), 15);
    } finally {
        if (test2 != null) {
            test2.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Обновление текста**

Aspose.Slides позволяет изменить или обновить текст, содержащийся в текстовом поле, либо все тексты в презентации.

Этот JavaScript‑код демонстрирует операцию, при которой обновляются (или изменяются) все тексты в презентации:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation("text.pptx");
try {
    for (let s = 0; s < pres.getSlides().size(); s++) {
        let slide = pres.getSlides().get_Item(s);
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // Проверяет, поддерживает ли фигура текстовый фрейм (IAutoShape).
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                var autoShape = shape;
                // Перебирает абзацы в текстовом фрейме
                for (let j = 0; j < autoShape.getTextFrame().getParagraphs().getCount(); j++) {
                    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(j);
                    // Перебирает каждую часть в абзаце
                    for (let k = 0; k < paragraph.getPortions().getCount(); k++) {
                        let portion = paragraph.getPortions().get_Item(k);
                        portion.setText(portion.getText().replace("years", "months"));// Изменяет текст
                        portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));// Изменяет форматирование
                    }
                }
            }
        }
    }
    // Сохраняет изменённую презентацию
    pres.save("text-changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Добавление текстового поля с гиперссылкой** 

Вы можете вставить ссылку внутрь текстового поля. При щелчке по полю пользователи будут перенаправлены по этой ссылке.

Чтобы добавить текстовое поле, содержащее ссылку, выполните следующие шаги:

1. Создайте экземпляр класса `Presentation`.  
2. Получите ссылку на первый слайд в только что созданной презентации.  
3. Добавьте объект `AutoShape` с типом `ShapeType` — `Rectangle` в указанное положение на слайде и получите ссылку на добавленный объект AutoShape.  
4. Добавьте `TextFrame` к объекту `AutoShape` и задайте текст первой части. В примере ниже использован такой текст: *Aspose.Slides*  
5. Получите `HyperlinkManager` этой части через её `PortionFormat`.  
6. Вызовите `setExternalHyperlinkClick` у `HyperlinkManager`, чтобы прикрепить ссылку к части.  
7. Наконец, запишите файл PPTX через объект `Presentation`.  

Этот JavaScript‑код — реализация описанных шагов — показывает, как добавить текстовое поле с гиперссылкой на слайд:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Создает экземпляр класса Presentation, представляющего PPTX
var pres = new aspose.slides.Presentation();
try {
    // Получает первый слайд в презентации
    var slide = pres.getSlides().get_Item(0);
    // Добавляет объект AutoShape с типом Rectangle
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 150, 50);
    // Приводит форму к типу AutoShape
    var pptxAutoShape = shape;
    // Получает доступ к свойству ITextFrame, связанному с AutoShape
    pptxAutoShape.addTextFrame("");
    var textFrame = pptxAutoShape.getTextFrame();
    // Добавляет некоторый текст в фрейм
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");
    // Устанавливает гиперссылку для текста части
    var hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");
    // Сохраняет презентацию PPTX
    pres.save("hLink_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**В чём разница между текстовым полем и заполнителем текста при работе с мастер‑слайдами?**

[Заполнитель](/slides/ru/nodejs-java/manage-placeholder/) наследует стиль/положение от [мастера](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/masterslide/) и может быть переопределён на [раскладах](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/layoutslide/), тогда как обычное текстовое поле является независимым объектом на конкретном слайде и не меняется при переключении раскладок.

**Как выполнить массовую замену текста во всей презентации, не затрагивая текст в диаграммах, таблицах и SmartArt?**

Ограничьте итерацию автофигурами, имеющими TextFrame, и исключите встроенные объекты ([диаграммы](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chart/), [таблицы](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/smartart/)), обходя их коллекции отдельно или пропуская такие типы объектов.