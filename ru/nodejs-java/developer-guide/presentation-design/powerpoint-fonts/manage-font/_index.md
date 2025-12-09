---
title: Управление шрифтами в презентациях с помощью JavaScript
linktitle: Управление шрифтами
type: docs
weight: 10
url: /ru/nodejs-java/manage-fonts/
keywords:
- управление шрифтами
- свойства шрифта
- абзац
- форматирование текста
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Управляйте шрифтами с помощью Aspose.Slides for Node.js via Java: встраивайте, заменяйте и загружайте пользовательские шрифты, чтобы презентации PPT, PPTX и ODP оставались четкими и согласованными."
---

## **Управление свойствами шрифтов**
{{% alert color="primary" %}} 

Презентации обычно содержат как текст, так и изображения. Текст можно оформлять разными способами: выделять отдельные разделы и слова или приводить его к корпоративным стилям. Форматирование текста помогает пользователям разнообразить внешний вид содержимого презентации. В этой статье показано, как с помощью Aspose.Slides for Node.js via Java настроить свойства шрифта абзацев текста на слайдах.

{{% /alert %}} 

Чтобы управлять свойствами шрифта абзаца с помощью Aspose.Slides for Node.js via Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. Получите ссылку на слайд, указав его индекс.
1. Доступ к объектам [Placeholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Placeholder) на слайде и приведение их к типу [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/AutoShape).
1. Получите [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Paragraph) из [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/TextFrame), предоставляемого [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/AutoShape).
1. Выравнивайте абзац по ширине.
1. Доступ к [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Portion) текста абзаца.
1. Определите шрифт с помощью [FontData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/FontData) и установите **Font** для объекта [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Portion).
   1. Установите полужирное начертание.
   1. Установите курсив.
1. Установите цвет шрифта через [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/FillFormat), предоставляемый объектом [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Portion).
1. Сохраните изменённую презентацию в файл PPTX.

Реализация перечисленных шагов приведена ниже. Пример берёт простую презентацию и применяет форматирование шрифтов к одному из слайдов. Скриншоты ниже показывают исходный файл и результат изменения кода. Код меняет шрифт, цвет и стиль шрифта.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Рисунок: Текст во входном файле**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Рисунок: Тот же текст с обновлённым форматированием**|
```javascript
    // Создать объект Presentation, представляющий файл PPTX
    var pres = new aspose.slides.Presentation("FontProperties.pptx");
    try {
        // Получение слайда по его позиции
        var slide = pres.getSlides().get_Item(0);
        // Получение первого и второго заполнителя (placeholder) на слайде и приведение их к типу AutoShape
        var tf1 = slide.getShapes().get_Item(0).getTextFrame();
        var tf2 = slide.getShapes().get_Item(1).getTextFrame();
        // Получение первого абзаца
        var para1 = tf1.getParagraphs().get_Item(0);
        var para2 = tf2.getParagraphs().get_Item(0);
        // Выравнивание абзаца по ширине
        para2.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.JustifyLow);
        // Получение первой части (portion)
        var port1 = para1.getPortions().get_Item(0);
        var port2 = para2.getPortions().get_Item(0);
        // Определение новых шрифтов
        var fd1 = new aspose.slides.FontData("Elephant");
        var fd2 = new aspose.slides.FontData("Castellar");
        // Назначение новых шрифтов части
        port1.getPortionFormat().setLatinFont(fd1);
        port2.getPortionFormat().setLatinFont(fd2);
        // Установить полужирное начертание
        port1.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
        port2.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
        // Установить курсив
        port1.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
        port2.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
        // Установить цвет шрифта
        port1.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
        port2.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
        // Сохранить PPTX на диск
        pres.save("WelcomeFont.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```


## **Установка свойств шрифта текста**
{{% alert color="primary" %}} 

Как упоминалось в разделе **Управление свойствами шрифтов**, объект [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Portion) используется для хранения текста с одинаковым стилем форматирования в абзаце. В этой статье показано, как с помощью Aspose.Slides for Node.js via Java создать текстовое поле с некоторым текстом, а затем задать определённый шрифт и различные другие свойства семейства шрифтов.

{{% /alert %}} 

Чтобы создать текстовое поле и задать свойства шрифта текста в нём:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. Получите ссылку на слайд, указав его индекс.
1. Добавьте на слайд [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/AutoShape) типа **Rectangle**.
1. Удалите стиль заливки, связанный с [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/AutoShape).
1. Доступ к [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/TextFrame) объекта [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/AutoShape).
1. Добавьте некоторый текст в [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/TextFrame).
1. Доступ к объекту [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Portion), связанному с [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/TextFrame).
1. Определите шрифт, который будет использоваться для [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Portion).
1. Установите остальные свойства шрифта, такие как полужирный, курсив, подчёркивание, цвет и высоту, используя соответствующие свойства, предоставляемые объектом [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Portion).
1. Запишите изменённую презентацию в файл PPTX.

Реализация перечисленных шагов указана ниже.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Рисунок: Текст с некоторыми установленными свойствами шрифта, созданный Aspose.Slides for Node.js via Java**|
```javascript
// Создать объект Presentation, представляющий файл PPTX
var pres = new aspose.slides.Presentation();
try {
    // Получить первый слайд
    var sld = pres.getSlides().get_Item(0);
    // Добавить AutoShape типа Rectangle
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    // Удалить любой стиль заливки, связанный с AutoShape
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Получить TextFrame, связанный с AutoShape
    var tf = ashp.getTextFrame();
    tf.setText("Aspose TextBox");
    // Получить Portion, связанный с TextFrame
    var port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
    // Установить шрифт для Portion
    port.getPortionFormat().setLatinFont(new aspose.slides.FontData("Times New Roman"));
    // Установить свойство Bold шрифта
    port.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // Установить свойство Italic шрифта
    port.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Установить свойство Underline шрифта
    port.getPortionFormat().setFontUnderline(aspose.slides.TextUnderlineType.Single);
    // Установить высоту шрифта
    port.getPortionFormat().setFontHeight(25);
    // Установить цвет шрифта
    port.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    // Сохранить презентацию на диск
    pres.save("pptxFont.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
