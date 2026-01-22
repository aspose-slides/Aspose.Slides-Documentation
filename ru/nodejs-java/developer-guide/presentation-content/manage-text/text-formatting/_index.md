---
title: Форматировать текст PowerPoint в JavaScript
linktitle: Форматирование текста
type: docs
weight: 50
url: /ru/nodejs-java/text-formatting/
keywords:
- выделить текст
- регулярное выражение
- выравнивание абзаца
- стиль текста
- фон текста
- прозрачность текста
- межсимвольный интервал
- свойства шрифта
- семейство шрифтов
- поворот текста
- угол поворота
- текстовый кадр
- межстрочный интервал
- свойство автоподгонки
- привязка текстового кадра
- табуляция текста
- язык по умолчанию
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Форматировать и оформлять текст в презентациях PowerPoint и OpenDocument с помощью JavaScript и Aspose.Slides для Node.js. Настраивайте шрифты, цвета, выравнивание и многое другое."
---

## **Выделить текст**

Метод [highlightText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#highlightText-java.lang.String-java.awt.Color-) был добавлен в класс [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) и класс [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame).

Он позволяет выделять часть текста фоновым цветом, используя образец текста, аналогично инструменту Text Highlight Color в PowerPoint 2019.

Ниже приведён фрагмент кода, показывающий, как использовать эту функцию:
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var textHighlightingOptions = new aspose.slides.TextHighlightingOptions();
    textHighlightingOptions.setWholeWordsOnly(true);
    pres.getSlides().get_Item(0).getShapes().get_Item(0).getTextFrame().highlightText("title", java.getStaticFieldValue("java.awt.Color", "BLUE"));// подсветка всех слов 'important'
    pres.getSlides().get_Item(0).getShapes().get_Item(0).getTextFrame().highlightText("to", java.getStaticFieldValue("java.awt.Color", "MAGENTA"), textHighlightingOptions);// подсветка всех отдельных вхождений 'the' 
    pres.save("OutputPresentation-highlight.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" %}} 
Aspose предоставляет простой, [бесплатный онлайн‑сервис редактирования PowerPoint](https://products.aspose.app/slides/editor)
{{% /alert %}} 

## **Выделить текст с помощью регулярного выражения**

Метод [highlightRegex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#highlightRegex-java.lang.String-java.awt.Color-aspose.slides.ITextHighlightingOptions-) был добавлен в класс [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) и класс [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame).

Он позволяет выделять часть текста фоновым цветом, используя регулярное выражение, аналогично инструменту Text Highlight Color в PowerPoint 2019.

Ниже приведён фрагмент кода, показывающий, как использовать эту функцию:
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var options = new aspose.slides.TextHighlightingOptions();
    pres.getSlides().get_Item(0).getShapes().get_Item(0).getTextFrame().highlightRegex("\\b[^\\s]{4}\\b", java.getStaticFieldValue("java.awt.Color", "YELLOW"), options);// подсветка всех слов, состоящих из 10 и более символов
    pres.save("OutputPresentation-highlight.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Установить цвет фона текста**

Aspose.Slides позволяет указать предпочтительный цвет фона текста.

Этот JavaScript‑код показывает, как установить цвет фона для всего текста:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.getTextFrame().getParagraphs().clear();
    var para = new aspose.slides.Paragraph();
    var portion1 = new aspose.slides.Portion("Black");
    portion1.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    var portion2 = new aspose.slides.Portion(" Red ");
    var portion3 = new aspose.slides.Portion("Black");
    portion3.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    para.getPortions().add(portion1);
    para.getPortions().add(portion2);
    para.getPortions().add(portion3);
    autoShape.getTextFrame().getParagraphs().add(para);
    pres.save("text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
const pres = new aspose.slides.Presentation("text.pptx");
try {
    const slide = pres.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    if (autoShape.getTextFrame() != null) {
        const paragraphs = autoShape.getTextFrame().getParagraphs();
        const paragraphCount = paragraphs.size();
        for (let i = 0; i < paragraphCount; i++) {
            const portions = paragraphs.get_Item(i).getPortions();
            const portionCount = portions.size();
            for (let j = 0; j < portionCount; j++) {
                const portion = portions.get_Item(j);
                portion.getPortionFormat().getHighlightColor().setColor(Color.BLUE);
            }
        }
    }
    pres.save("text-red.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


Этот JavaScript‑код показывает, как установить цвет фона только для части текста:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.getTextFrame().getParagraphs().clear();
    var para = new aspose.slides.Paragraph();
    var portion1 = new aspose.slides.Portion("Black");
    portion1.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    var portion2 = new aspose.slides.Portion(" Red ");
    var portion3 = new aspose.slides.Portion("Black");
    portion3.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    para.getPortions().add(portion1);
    para.getPortions().add(portion2);
    para.getPortions().add(portion3);
    autoShape.getTextFrame().getParagraphs().add(para);
    pres.save("text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
var presentation = new aspose.slides.Presentation("text.pptx");
try {
    var autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    var redPortion = java.callStaticMethodSync("StreamSupport", "stream", autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().spliterator(), false).filter(p -> p.getText().contains("Red")).findFirst();
    if (redPortion.isPresent()) {
        redPortion.get().getPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    }
    presentation.save("text-red.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **Выравнивание абзацев текста**

Форматирование текста является одним из ключевых элементов при создании любых документов или презентаций. Мы знаем, что Aspose.Slides for Node.js via Java поддерживает добавление текста на слайды, но в этой теме мы посмотрим, как управлять выравниванием абзацев текста на слайде. Пожалуйста, выполните следующие шаги для выравнивания абзацев текста с помощью Aspose.Slides for Node.js via Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Получите ссылку на слайд, используя его индекс.
3. Доступ к фигурам‑заместителям, находящимся на слайде, и приведите их к типу [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
4. Получите абзац (который нужно выровнять) из [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#getTextFrame--) объекта [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
5. Выравнивайте абзац. Абзац может быть выровнен по правому, левому краю, по центру или по ширине.
6. Запишите изменённую презентацию в файл PPTX.

Реализация указанных шагов приведена ниже.
```javascript
// Создать объект Presentation, представляющий файл PPTX
var pres = new aspose.slides.Presentation("ParagraphsAlignment.pptx");
try {
    // Получение первого слайда
    var slide = pres.getSlides().get_Item(0);
    // Получение первого и второго заполнителей на слайде и приведение их к типу AutoShape
    var tf1 = slide.getShapes().get_Item(0).getTextFrame();
    var tf2 = slide.getShapes().get_Item(1).getTextFrame();
    // Изменение текста в обоих заполнителях
    tf1.setText("Center Align by Aspose");
    tf2.setText("Center Align by Aspose");
    // Получение первого абзаца из заполнителей
    var para1 = tf1.getParagraphs().get_Item(0);
    var para2 = tf2.getParagraphs().get_Item(0);
    // Выровнять абзац текста по центру
    para1.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);
    para2.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);
    // Сохранение презентации в файл PPTX
    pres.save("Centeralign_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Установить прозрачность текста**

В этой статье показано, как задать свойство прозрачности любой текстовой фигуре с помощью Aspose.Slides for Node.js via Java. Чтобы установить прозрачность текста, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Получите ссылку на слайд.
3. Задайте цвет тени.
4. Запишите презентацию в файл PPTX.

Реализация указанных шагов приведена ниже.
```javascript
var pres = new aspose.slides.Presentation("transparency.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var effects = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getEffectFormat();
    var outerShadowEffect = effects.getOuterShadowEffect();
    var shadowColor = outerShadowEffect.getShadowColor().getColor();
    console.log((shadowColor.toString() + " - transparency is: ") + ((shadowColor.getAlpha() / 255.0) * 100));
    // установить прозрачность в ноль процентов
    outerShadowEffect.getShadowColor().setColor(java.newInstanceSync("java.awt.Color", shadowColor.getRed(), shadowColor.getGreen(), shadowColor.getBlue(), 255));
    pres.save("transparency-2.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Установить межсимвольный интервал текста**

Aspose.Slides позволяет задавать расстояние между буквами в текстовом поле. Таким образом, вы можете регулировать визуальную плотность строки или блока текста, расширяя или сжимая интервал между символами.

Этот JavaScript‑код показывает, как увеличить интервал для одной строки текста и уменьшить его для другой строки:
```javascript
var presentation = new aspose.slides.Presentation("in.pptx");
var textBox1 = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var textBox2 = presentation.getSlides().get_Item(0).getShapes().get_Item(1);
textBox1.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(20);// расширить
textBox2.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(-2);// сжать
presentation.save("out.pptx", aspose.slides.SaveFormat.Pptx);
```


## **Управление свойствами шрифта абзаца**

Презентации обычно содержат как текст, так и изображения. Текст может быть отформатирован по‑разному: для выделения определённых разделов и слов или в соответствии с корпоративными стилями. Форматирование текста помогает пользователям менять внешний вид содержимого презентации. В этой статье показано, как с помощью Aspose.Slides for Node.js via Java настроить свойства шрифта абзацев текста на слайдах. Для управления свойствами шрифта абзаца выполните:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Доступ к фигурам‑заместителям на слайде и приведите их к типу [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
1. Получите [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) из [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame), связанного с [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
1. Выравняйте абзац по ширине.
1. Получите объект Portion текста абзаца.
1. Определите шрифт с помощью FontData и задайте шрифт Portion соответственно.
   1. Сделайте шрифт полужирным.
   1. Сделайте шрифт курсивом.
1. Задайте цвет шрифта, используя [getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BasePortionFormat#getFillFormat--) объекта [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion).
1. Запишите изменённую презентацию в файл [PPTX](https://docs.fileformat.com/presentation/pptx/).

Реализация указанных шагов приведена ниже. Она берёт простую презентацию и форматирует шрифты на одном из слайдов.
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
    // Получение первой части
    var port1 = para1.getPortions().get_Item(0);
    var port2 = para2.getPortions().get_Item(0);
    // Определить новые шрифты
    var fd1 = new aspose.slides.FontData("Elephant");
    var fd2 = new aspose.slides.FontData("Castellar");
    // Назначить новые шрифты части
    port1.getPortionFormat().setLatinFont(fd1);
    port2.getPortionFormat().setLatinFont(fd2);
    // Установить шрифт полужирным
    port1.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // Установить шрифт курсивом
    port1.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Установить цвет шрифта
    port1.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
    port2.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    // Записать PPTX на диск
    pres.save("WelcomeFont_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Управление семейством шрифтов текста**

Portion используется для хранения текста с одинаковым стилем в абзаце. Эта статья показывает, как с помощью Aspose.Slides for Node.js via Java создать текстовое поле с текстом, затем задать конкретный шрифт и другие свойства семейства шрифтов. Для создания текстового поля и установки свойств шрифта текста выполните:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) типа [Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeType#Rectangle) на слайд.
4. Удалите заливку, связанную с [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
5. Доступ к TextFrame AutoShape.
6. Добавьте некоторый текст в TextFrame.
7. Доступ к объекту Portion, связанному с [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
8. Определите шрифт, который будет использоваться для [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion).
9. Задайте другие свойства шрифта, такие как полужирный, курсив, подчёркивание, цвет и размер, используя соответствующие свойства Portion.
10. Запишите изменённую презентацию в файл PPTX.

Реализация указанных шагов приведена ниже.
```javascript
// Создать объект Presentation
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
    // Записать PPTX на диск
    pres.save("SetTextFontProperties_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Установить размер шрифта текста**

Aspose.Slides позволяет задать предпочтительный размер шрифта для существующего текста в абзаце и для другого текста, который может быть добавлен позже.

Этот JavaScript‑код показывает, как задать размер шрифта для текста, содержащегося в абзаце:
```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
try {
    // Получаем первую форму, например.
    var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        var autoShape = shape;
        // Получаем первый абзац, например.
        var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
        // Устанавливает размер шрифта по умолчанию 20 пунктов для всех текстовых частей в абзаце.
        paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
        // Устанавливает размер шрифта 20 пунктов для текущих текстовых частей в абзаце.
        for (let i = 0; i < paragraph.getPortions().getCount(); i++) {
            let portion = paragraph.getPortions().get_Item(i);
            portion.getPortionFormat().setFontHeight(20);
        }
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **Установить поворот текста**

Aspose.Slides for Node.js via Java позволяет разработчикам поворачивать текст. Текст может отображаться как [Horizontal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#Horizontal), [Vertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#Vertical), [Vertical270](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#Vertical270), [WordArtVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#WordArtVertical), [EastAsianVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#EastAsianVertical), [MongolianVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#MongolianVertical) или [WordArtVerticalRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#WordArtVerticalRightToLeft). Чтобы повернуть текст любого TextFrame, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Доступ к первому слайду.
3. Добавьте любую фигуру на слайд.
4. Доступ к [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
5. [Rotate the text](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setTextVerticalType-byte-).
6. Сохраните файл на диск.
```javascript
// Создать экземпляр класса Presentation
var pres = new aspose.slides.Presentation();
try {
    // Получить первый слайд
    var slide = pres.getSlides().get_Item(0);
    // Добавить AutoShape типа Rectangle
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 350, 350);
    // Добавить TextFrame к прямоугольнику
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Получение текстового кадра
    var txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setTextVerticalType(aspose.slides.TextVerticalType.Vertical270);
    // Создать объект Paragraph для текстового кадра
    var para = txtFrame.getParagraphs().get_Item(0);
    // Создать объект Portion для абзаца
    var portion = para.getPortions().get_Item(0);
    portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Сохранить презентацию
    pres.save("RotateText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Установить пользовательский угол поворота для TextFrame**

Aspose.Slides for Node.js via Java теперь поддерживает задание пользовательского угла поворота для TextFrame. В этой теме показан пример, как задать свойство RotationAngle в Aspose.Slides. Были добавлены новые методы [setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setRotationAngle-float-) и [getRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#getRotationAngle--) в класс [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat), позволяющие задать собственный угол поворота для TextFrame. Чтобы задать RotationAngle, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Добавьте диаграмму на слайд.
3. [Set RotationAngle property](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setRotationAngle-float-).
4. Запишите презентацию в файл PPTX.

В примере ниже задаётся свойство RotationAngle.
```javascript
// Создать экземпляр класса Presentation
var pres = new aspose.slides.Presentation();
try {
    // Получить первый слайд
    var slide = pres.getSlides().get_Item(0);
    // Добавить AutoShape типа Rectangle
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 350, 350);
    // Добавить TextFrame к прямоугольнику
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Получение текстового кадра
    var txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setRotationAngle(25);
    // Создать объект Paragraph для текстового кадра
    var para = txtFrame.getParagraphs().get_Item(0);
    // Создать объект Portion для абзаца
    var portion = para.getPortions().get_Item(0);
    portion.setText("Text rotation example.");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Сохранить презентацию
    pres.save(resourcesOutputPath + "RotateText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Межстрочный интервал абзаца**

Aspose.Slides предоставляет свойства в [`ParagraphFormat`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ParagraphFormat)—`SpaceAfter`, `SpaceBefore` и `SpaceWithin`—которые позволяют управлять межстрочным интервалом абзаца. Свойства используются следующим образом:

* Чтобы задать межстрочный интервал в процентах, используйте положительное значение. 
* Чтобы задать межстрочный интервал в пунктах, используйте отрицательное значение.

Например, можно задать интервал 16 pt, установив свойство `SpaceBefore` в -16.

Как задать межстрочный интервал для конкретного абзаца:

1. Загрузите презентацию, содержащую AutoShape с текстом.
2. Получите ссылку на слайд по его индексу.
3. Доступ к TextFrame.
4. Доступ к Paragraph.
5. Задайте свойства Paragraph.
6. Сохраните презентацию.

Этот JavaScript‑код показывает, как задать межстрочный интервал для абзаца:
```javascript
// Создать экземпляр класса Presentation
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    // Получить ссылку на слайд по его индексу
    var sld = pres.getSlides().get_Item(0);
    // Доступ к TextFrame
    var tf1 = sld.getShapes().get_Item(0).getTextFrame();
    // Доступ к Paragraph
    var para = tf1.getParagraphs().get_Item(0);
    // Установить свойства Paragraph
    para.getParagraphFormat().setSpaceWithin(80);
    para.getParagraphFormat().setSpaceBefore(40);
    para.getParagraphFormat().setSpaceAfter(40);
    // Сохранить презентацию
    pres.save("LineSpacing_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Установить свойство AutofitType для TextFrame**

В этой теме рассматриваются различные свойства форматирования текстового кадра. Статья описывает, как установить свойство AutofitType текстового кадра, привязку текста и поворот текста в презентации. Aspose.Slides for Node.js via Java позволяет разработчикам задавать свойство AutofitType любого текстового кадра. AutofitType может принимать значение [Normal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAutofitType#Normal) или [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAutofitType#Shape). При значении [Normal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAutofitType#Normal) форма остаётся неизменной, а текст подгоняется, не изменяя форму. При значении [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAutofitType#Shape) форма изменяется так, чтобы в ней помещался только необходимый текст. Чтобы задать свойство AutofitType текстового кадра, выполните:

1. Создайте экземпляр класса [Presentation ](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Доступ к первому слайду.
3. Добавьте любую фигуру на слайд.
4. Доступ к [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
5. [Set the AutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType-byte-) для TextFrame.
6. Сохраните файл на диск.
```javascript
// Создать экземпляр класса Presentation
var pres = new aspose.slides.Presentation();
try {
    // Получить первый слайд
    var slide = pres.getSlides().get_Item(0);
    // Добавить AutoShape типа Rectangle
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 350, 150);
    // Добавить TextFrame к прямоугольнику
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Получение текстового кадра
    var txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAutofitType(aspose.slides.TextAutofitType.Shape);
    // Создать объект Paragraph для текстового кадра
    var para = txtFrame.getParagraphs().get_Item(0);
    // Создать объект Portion для абзаца
    var portion = para.getPortions().get_Item(0);
    portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Сохранить презентацию
    pres.save(resourcesOutputPath + "formatText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Установить привязку TextFrame**

Aspose.Slides for Node.js via Java позволяет установить привязку любого TextFrame. TextAnchorType определяет, где расположен текст внутри фигуры. TextAnchorType может принимать значения [Top](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Top), [Center](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Center), [Bottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Bottom), [Justified](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Justified) или [Distributed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Distributed). Чтобы задать привязку TextFrame, выполните:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Доступ к первому слайду.
3. Добавьте любую фигуру на слайд.
4. Доступ к [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
5. [Set TextAnchorType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setAnchoringType-byte-) для TextFrame.
6. Сохраните файл на диск.
```javascript
// Создать экземпляр класса Presentation
var pres = new aspose.slides.Presentation();
try {
    // Получить первый слайд
    var slide = pres.getSlides().get_Item(0);
    // Добавить AutoShape типа Rectangle
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 350, 350);
    // Добавить TextFrame к прямоугольнику
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Получение текстового кадра
    var txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAnchoringType(aspose.slides.TextAnchorType.Bottom);
    // Создать объект Paragraph для текстового кадра
    var para = txtFrame.getParagraphs().get_Item(0);
    // Создать объект Portion для абзаца
    var portion = para.getPortions().get_Item(0);
    portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Сохранить презентацию
    pres.save("AnchorText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Табы и EffectiveTabs в презентации**

Все табуляции текста указаны в пикселях.

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**Рисунок: 2 явных таба и 2 таба по умолчанию**|
- Свойство EffectiveTabs.ExplicitTabCount (2 в нашем случае) равно Tabs.Count.  
- Коллекция EffectiveTabs включает все табы (из коллекции Tabs и табы по умолчанию).  
- Свойство EffectiveTabs.ExplicitTabCount (2 в нашем случае) равно Tabs.Count.  
- Свойство EffectiveTabs.DefaultTabSize (294) показывает расстояние между табами по умолчанию (3 и 4 в нашем примере).  
- EffectiveTabs.GetTabByIndex(index) с index = 0 вернёт первый явный таб (Position = 731), index = 1 – второй таб (Position = 1241). При запросе index = 2 будет возвращён первый таб по умолчанию (Position = 1470) и т.д.  
- EffectiveTabs.GetTabAfterPosition(pos) используется для получения следующей табуляции после некоторого текста. Например, имеется текст: "Hello World!". Чтобы отобразить такой текст, необходимо знать, откуда начинать рисовать "world!". Сначала вычислите длину слова "Hello" в пикселях и вызовите GetTabAfterPosition с этим значением. Вы получите позицию следующего таба для рисования "world!".

## **Установить стиль текста по умолчанию**

Если необходимо применить одинаковое форматирование текста ко всем элементам текста презентации одновременно, можно использовать метод `getDefaultTextStyle` класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) и задать предпочтительное форматирование. Пример кода ниже показывает, как установить полужирный шрифт (14 pt) по умолчанию для текста на всех слайдах новой презентации.
```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Получить формат абзаца верхнего уровня.
    var paragraphFormat = presentation.getDefaultTextStyle().getLevel(0);
    if (paragraphFormat != null) {
        paragraphFormat.getDefaultPortionFormat().setFontHeight(14);
        paragraphFormat.getDefaultPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    }
    presentation.save("DefaultTextStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Извлечь текст с эффектом All‑Caps**

В PowerPoint применение эффекта шрифта **All Caps** делает текст заглавными буквами на слайде, даже если он был введён строчными. При получении такого фрагмента текста с помощью Aspose.Slides библиотека возвращает текст в том виде, в каком он был введён. Чтобы обработать это, проверьте [TextCapType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textcaptype/) — если он указывает `All`, просто преобразуйте возвращённую строку в верхний регистр, чтобы вывод соответствовал тому, что видит пользователь на слайде.

Предположим, у нас есть следующий текстовый блок на первом слайде файла sample2.pptx.

![The All Caps effect](all_caps_effect.png)

Пример кода ниже показывает, как извлечь текст с применённым эффектом **All Caps**:
```js
var presentation = new aspose.slides.Presentation("sample2.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    var autoShape = slide.getShapes().get_Item(0);
    var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    var textPortion = paragraph.getPortions().get_Item(0);

    console.log("Original text:", textPortion.getText());

    var textFormat = textPortion.getPortionFormat().getEffective();
    if (textFormat.getTextCapType() == aspose.slides.TextCapType.All) {
        var text = textPortion.getText().toUpperCase();
        console.log("All-Caps effect:", text);
    }
} finally {
    presentation.dispose();
}
```


Вывод:
```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```


## **FAQ**

**Как изменить текст в таблице на слайде?**

Для изменения текста в таблице на слайде необходимо использовать объект [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/). Можно пройтись по всем ячейкам таблицы и изменить текст в каждой ячейке, получив её `TextFrame` и свойства `ParagraphFormat`.

**Как применить градиентный цвет к тексту в слайде PowerPoint?**

Для применения градиентного цвета к тексту используйте свойство Fill Format в [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/). Установите Fill Format в `Gradient`, где можно задать начальный и конечный цвета градиента, а также другие параметры, такие как направление и прозрачность, чтобы создать градиентный эффект текста.