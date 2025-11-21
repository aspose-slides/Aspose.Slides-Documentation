---
title: Управление текстовым полем
type: docs
weight: 20
url: /ru/nodejs-java/manage-textbox/
keywords:
- текстовое поле
- текстовый кадр
- добавить текст
- обновить текст
- текстовое поле с гиперссылкой
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides для Node.js через Java
description: "Управляйте текстовым полем или текстовым кадром в презентациях PowerPoint с помощью JavaScript"
---

Текст на слайдах обычно находится в текстовых полях или фигурах. Поэтому, чтобы добавить текст на слайд, необходимо добавить текстовое поле и затем поместить там текст. Aspose.Slides for Node.js via Java предоставляет класс [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape), который позволяет добавить фигуру, содержащую текст.

{{% alert title="Info" color="info" %}}
Aspose.Slides также предоставляет класс [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape), который позволяет добавлять фигуры на слайды. Однако не все фигуры, добавленные через класс `Shape`, могут содержать текст. Фигуры, добавленные через класс [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape), могут содержать текст.
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
Поэтому, работая с фигурой, в которую нужно добавить текст, рекомендуется проверить и убедиться, что она была приведена к классу `AutoShape`. Только тогда вы сможете работать с [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame), который является свойством `AutoShape`. См. раздел [Update Text](https://docs.aspose.com/slides/nodejs-java/manage-textbox/#update-text) на этой странице.
{{% /alert %}}

## **Создание текстового поля на слайде**

Чтобы создать текстовое поле на слайде, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Получите ссылку на первый слайд в только что созданной презентации. 
3. Добавьте объект [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) с типом `ShapeType`, установленным в `Rectangle`, в указанном положении на слайде и получите ссылку на только что добавленный объект `AutoShape`.
4. Добавьте свойство `TextFrame` к объекту `AutoShape`, которое будет содержать текст. В примере ниже мы добавили такой текст: *Aspose TextBox*.
5. Наконец, запишите файл PPTX через объект `Presentation`. 

Этот JavaScript‑код, реализующий описанные шаги, показывает, как добавить текст на слайд:
```javascript
// Создаёт объект Presentation
var pres = new aspose.slides.Presentation();
try {
    // Получает первый слайд в презентации
    var sld = pres.getSlides().get_Item(0);
    // Добавляет AutoShape с типом Rectangle
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // Добавляет TextFrame в прямоугольник
    ashp.addTextFrame(" ");
    // Получает доступ к текстовому кадру
    var txtFrame = ashp.getTextFrame();
    // Создаёт объект Paragraph для текстового кадра
    var para = txtFrame.getParagraphs().get_Item(0);
    // Создаёт объект Portion для абзаца
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


## **Проверка формы текстового поля**

Aspose.Slides предоставляет метод [isTextBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/#isTextBox) класса [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/), позволяющий проверять фигуры и определять, являются ли они текстовыми полями.

![Текстовое поле и фигура](istextbox.png)

Этот JavaScript‑код показывает, как проверить, создана ли фигура как текстовое поле:
```javascript
var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    java.callStaticMethodSync("ForEach", "shape", presentation, (shape, slide, index) -> {
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            var autoShape = shape;
            console.log(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
        }
    });
} finally {
    presentation.dispose();
}
```


Обратите внимание, что если вы просто добавите автогенерируемую фигуру с помощью метода `addAutoShape` класса [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/), метод `isTextBox` у такой фигуры вернёт `false`. Однако после того, как вы добавите текст в автогенерируемую фигуру с помощью метода `addTextFrame` или `setText`, свойство `isTextBox` вернёт `true`.
```javascript
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


## **Добавление колонок в текстовое поле**

Aspose.Slides предоставляет методы [setColumnCount](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) и [setColumnSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setColumnSpacing-double-) класса [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat), которые позволяют добавлять колонки в текстовые поля. Вы можете задать количество колонок в текстовом поле и установить промежуток в пунктах между колонками.

Этот код на JavaScript демонстрирует описанную операцию: 
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Получает первый слайд в презентации
    var slide = pres.getSlides().get_Item(0);
    // Добавляет AutoShape с типом Rectangle
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // Добавляет TextFrame к прямоугольнику
    aShape.addTextFrame((("All these columns are limited to be within a single text container -- " + "you can add or delete text and the new or remaining text automatically adjusts ") + "itself to flow within the container. You cannot have text flow from one container ") + "to other though -- we told you PowerPoint's column options for text are limited!");
    // Получает формат текста TextFrame
    var format = aShape.getTextFrame().getTextFrameFormat();
    // Задаёт количество колонок в TextFrame
    format.setColumnCount(3);
    // Задаёт расстояние между колонками
    format.setColumnSpacing(10);
    // Сохраняет презентацию
    pres.save("ColumnCount.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Добавление колонки в текстовый кадр**

Aspose.Slides for Node.js via Java предоставляет метод [setColumnCount](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) класса [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat), который позволяет добавлять колонки в текстовые кадры. С помощью этого свойства вы можете указать желаемое количество колонок в текстовом кадре.

Этот JavaScript‑код показывает, как добавить колонку внутри текстового кадра:
```javascript
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
        java.callStaticMethodSync("Assert", "assertTrue", 2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", java.getStaticFieldValue("java.lang.Double", "NaN") == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
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
        java.callStaticMethodSync("Assert", "assertTrue", 2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", 20 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
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
        java.callStaticMethodSync("Assert", "assertTrue", 3 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", 15 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
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

Aspose.Slides позволяет изменять или обновлять текст, содержащийся в текстовом поле, либо все тексты, содержащиеся в презентации. 

Этот JavaScript‑код демонстрирует операцию, при которой все тексты в презентации обновляются или изменяются:
```javascript
var pres = new aspose.slides.Presentation("text.pptx");
try {
    for (let s = 0; s < pres.getSlides().size(); s++) {
        let slide = pres.getSlides().get_Item(s);
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // Проверяет, поддерживает ли фигура текстовый кадр (IAutoShape).
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                var autoShape = shape;
                // Проходит по абзацам в текстовом кадре
                for (let j = 0; j < autoShape.getTextFrame().getParagraphs().getCount(); j++) {
                    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(j);
                    // Проходит по каждому сегменту в абзаце
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

Вы можете вставить ссылку внутрь текстового поля. При щелчке по полю пользователи будут перенаправлены к открытию ссылки. 

Чтобы добавить текстовое поле, содержащее ссылку, выполните следующие шаги:

1. Создайте экземпляр класса `Presentation`. 
2. Получите ссылку на первый слайд в только что созданной презентации. 
3. Добавьте объект `AutoShape` с типом `ShapeType`, установленным в `Rectangle`, в заданном положении на слайде и получите ссылку на только что добавленный объект `AutoShape`.
4. Добавьте `TextFrame` к объекту `AutoShape`, который содержит *Aspose TextBox* в качестве текста по умолчанию. 
5. Создайте экземпляр класса `HyperlinkManager`. 
6. Свяжите объект `HyperlinkManager` со свойством [HyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getHyperlinkClick--) вашего выбранного фрагмента `TextFrame`. 
7. Наконец, запишите файл PPTX через объект `Presentation`. 

Этот JavaScript‑код, реализующий описанные шаги, показывает, как добавить текстовое поле с гиперссылкой на слайд:
```javascript
// Создает объект класса Presentation, представляющий PPTX
var pres = new aspose.slides.Presentation();
try {
    // Получает первый слайд в презентации
    var slide = pres.getSlides().get_Item(0);
    // Добавляет объект AutoShape с типом Rectangle
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 150, 50);
    // Преобразует форму к AutoShape
    var pptxAutoShape = shape;
    // Получает свойство ITextFrame, связанное с AutoShape
    pptxAutoShape.addTextFrame("");
    var textFrame = pptxAutoShape.getTextFrame();
    // Добавляет некоторый текст в кадр
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");
    // Устанавливает гиперссылку для текста сегмента
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

**В чём разница между текстовым полем и заполнителем текста при работе с слайдами‑шаблонами?**

[Заполнитель](/slides/ru/nodejs-java/manage-placeholder/) наследует стиль/позицию от [главного шаблона](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/) и может быть переопределён на [макетах](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslide/), тогда как обычное текстовое поле является независимым объектом на конкретном слайде и не меняется при переключении макетов.

**Как выполнить массовую замену текста во всей презентации, не затрагивая текст внутри диаграмм, таблиц и SmartArt?**

Ограничьте итерацию только автогенерируемыми фигурами, имеющими текстовые кадры, и исключите встроенные объекты ([диаграммы](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/), [таблицы](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/)), обходя их коллекции отдельно или пропуская такие типы объектов.