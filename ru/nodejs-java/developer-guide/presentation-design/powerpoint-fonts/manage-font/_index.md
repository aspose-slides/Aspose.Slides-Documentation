---
title: Управление шрифтами в презентациях с использованием JavaScript
linktitle: Управление шрифтами
type: docs
weight: 10
url: /ru/nodejs-java/manage-fonts/
keywords:
- управление шрифтами
- свойства шрифтов
- абзац
- форматирование текста
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Управляйте шрифтами с помощью Aspose.Slides для Node.js через Java: внедряйте, заменяйте и загружайте пользовательские шрифты, чтобы презентации PPT, PPTX и ODP оставались чистыми и согласованными."
---

## **Управление свойствами шрифта**
{{% alert color="primary" %}} 

Презентации обычно содержат как текст, так и изображения. Текст может быть отформатирован различными способами, чтобы выделить определённые секции и слова или соответствовать корпоративным стилям. Форматирование текста помогает пользователям изменять внешний вид содержимого презентации. В этой статье показано, как использовать Aspose.Slides for Node.js через Java для настройки свойств шрифта абзацев текста на слайдах.

{{% /alert %}} 

Для управления свойствами шрифта абзаца с помощью Aspose.Slides for Node.js через Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Получите доступ к элементам [Placeholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/) на слайде и приведите их к типу [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/).
1. Получите [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) из [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/), предоставляемого [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/).
1. Выровняйте абзац по ширине.
1. Получите [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) текста из [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/).
1. Определите шрифт с помощью [FontData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontdata/) и установите **Font** для текста в [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) соответственно.
   1. Установите полужирный начертание шрифта.
   1. Установите курсив.
1. Установите цвет шрифта с помощью [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/), доступного у объекта [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/).
1. Сохраните изменённую презентацию в файл PPTX.

Ниже представлена реализация указанных шагов. Она принимает простую презентацию и форматирует шрифты на одном из слайдов. Последующие скриншоты показывают исходный файл и то, как фрагменты кода меняют его. Код изменяет шрифт, цвет и стиль шрифта.

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
        // Получение первого и второго заполнителя на слайде и приведение их к типу AutoShape
        var tf1 = slide.getShapes().get_Item(0).getTextFrame();
        var tf2 = slide.getShapes().get_Item(1).getTextFrame();
        // Получение первого абзаца
        var para1 = tf1.getParagraphs().get_Item(0);
        var para2 = tf2.getParagraphs().get_Item(0);
        // Выравнивание абзаца по ширине
        para2.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.JustifyLow);
        // Получение первой части текста
        var port1 = para1.getPortions().get_Item(0);
        var port2 = para2.getPortions().get_Item(0);
        // Определение новых шрифтов
        var fd1 = new aspose.slides.FontData("Elephant");
        var fd2 = new aspose.slides.FontData("Castellar");
        // Назначение новых шрифтов части текста
        port1.getPortionFormat().setLatinFont(fd1);
        port2.getPortionFormat().setLatinFont(fd2);
        // Установка полужирного начертания шрифта
        port1.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
        port2.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
        // Установка курсивного начертания шрифта
        port1.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
        port2.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
        // Установка цвета шрифта
        port1.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
        port2.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
        // Сохранение PPTX на диск
        pres.save("WelcomeFont.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```


## **Установить свойства шрифта текста**
{{% alert color="primary" %}} 

Как упоминалось в **Управление свойствами шрифта**, объект [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) используется для хранения текста с одинаковым стилем форматирования в абзаце. В этой статье показано, как использовать Aspose.Slides for Node.js через Java для создания текстового поля с некоторым текстом, а затем определить конкретный шрифт и различные другие свойства семейства шрифтов.

{{% /alert %}} 

Для создания текстового поля и установки свойств шрифта текста в нём:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте к слайду [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) типа **Rectangle**.
1. Удалите стиль заливки, связанный с [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/).
1. Получите доступ к [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) объекта [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/).
1. Добавьте некоторый текст в [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/).
1. Получите объект [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/), связанный с [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/).
1. Определите шрифт, который будет использоваться для [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/).
1. Установите другие свойства шрифта, такие как полужирный, курсив, подчёркивание, цвет и высота, используя соответствующие свойства объекта [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/).
1. Запишите изменённую презентацию в файл PPTX.

Ниже представлена реализация указанных шагов.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Рисунок: Текст с некоторыми свойствами шрифта, установленными Aspose.Slides for Node.js через Java**|
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
    // Установить свойство Bold для шрифта
    port.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // Установить свойство Italic для шрифта
    port.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Установить свойство Underline для шрифта
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
