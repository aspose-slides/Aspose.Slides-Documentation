---
title: Форматирование текста PowerPoint в JavaScript
linktitle: Форматирование текста
type: docs
weight: 50
url: /ru/nodejs-java/text-formatting/
keywords:
- выделение текста
- регулярное выражение
- выравнивание абзаца
- стиль текста
- фон текста
- прозрачность текста
- межсимвольный интервал
- свойства шрифта
- семейство шрифтов
- вращение текста
- угол вращения
- текстовый фрейм
- межстрочный интервал
- свойство автоподгонки
- привязка текстового фрейма
- табуляция текста
- язык по умолчанию
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Узнайте, как форматировать и оформлять текст в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для Node.js через Java. Настраивайте шрифты, цвета, выравнивание и многое другое с помощью мощных примеров кода на JavaScript."
---

## **Выделение текста**

Метод [highlightText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#highlightText-java.lang.String-java.awt.Color-) был добавлен в класс [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) и класс [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame).

Он позволяет выделять часть текста фоновым цветом, используя образец текста, аналогично инструменту Text Highlight Color в PowerPoint 2019.

Ниже показан фрагмент кода, демонстрирующий, как использовать эту функцию:
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var textHighlightingOptions = new aspose.slides.TextHighlightingOptions();
    textHighlightingOptions.setWholeWordsOnly(true);
    pres.getSlides().get_Item(0).getShapes().get_Item(0).getTextFrame().highlightText("title", java.getStaticFieldValue("java.awt.Color", "BLUE"));// выделение всех слов 'important'
    pres.getSlides().get_Item(0).getShapes().get_Item(0).getTextFrame().highlightText("to", java.getStaticFieldValue("java.awt.Color", "MAGENTA"), textHighlightingOptions);// выделение всех отдельных вхождений 'the'
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

## **Выделение текста с помощью регулярного выражения**

Метод [highlightRegex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#highlightRegex-java.lang.String-java.awt.Color-aspose.slides.ITextHighlightingOptions-) был добавлен в класс [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) и класс [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame).

Он позволяет выделять часть текста фоновым цветом, используя регулярное выражение, аналогично инструменту Text Highlight Color в PowerPoint 2019.

Ниже показан фрагмент кода, демонстрирующий, как использовать эту функцию:
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var options = new aspose.slides.TextHighlightingOptions();
    pres.getSlides().get_Item(0).getShapes().get_Item(0).getTextFrame().highlightRegex("\\b[^\\s]{4}\\b", java.getStaticFieldValue("java.awt.Color", "YELLOW"), options);// выделение всех слов длиной 10 символов и более
    pres.save("OutputPresentation-highlight.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Установка фонового цвета текста**

Aspose.Slides позволяет указать предпочитаемый цвет фона текста.

Этот JavaScript‑код показывает, как установить фоновой цвет для всего текста:
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


Этот JavaScript‑код показывает, как установить фоновой цвет только для части текста:
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

Форматирование текста — один из ключевых элементов при создании любых документов или презентаций. Мы знаем, что Aspose.Slides for Node.js via Java поддерживает добавление текста на слайды, но в этой теме мы посмотрим, как можно управлять выравниванием абзацев текста на слайде. Пожалуйста, выполните следующие шаги, чтобы выровнять абзацы текста, используя Aspose.Slides for Node.js via Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Получите ссылку на слайд, используя его индекс.
3. Получите доступ к Placeholder‑формам на слайде и приведите их к типу [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
4. Получите абзац (который нужно выровнять) из [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#getTextFrame--) объекта [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
5. Выровняйте абзац. Абзац может быть выровнен по правому, левому, центру или с выравниванием по ширине.
6. Сохраните изменённую презентацию в файл PPTX.

Реализация вышеуказанных шагов приведена ниже.
```javascript
// Создать объект Presentation, представляющий файл PPTX
var pres = new aspose.slides.Presentation("ParagraphsAlignment.pptx");
try {
    // Доступ к первому слайду
    var slide = pres.getSlides().get_Item(0);
    // Доступ к первому и второму placeholder на слайде и приведение их к AutoShape
    var tf1 = slide.getShapes().get_Item(0).getTextFrame();
    var tf2 = slide.getShapes().get_Item(1).getTextFrame();
    // Изменить текст в обоих placeholder
    tf1.setText("Center Align by Aspose");
    tf2.setText("Center Align by Aspose");
    // Получение первого абзаца в placeholder
    var para1 = tf1.getParagraphs().get_Item(0);
    var para2 = tf2.getParagraphs().get_Item(0);
    // Выравнивание абзаца текста по центру
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


## **Установка прозрачности текста**

В этой статье показано, как задать свойство прозрачности для любой текстовой формы с помощью Aspose.Slides for Node.js via Java. Чтобы установить прозрачность текста, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Получите ссылку на слайд.
3. Установите цвет тени.
4. Сохраните презентацию в файл PPTX.

Реализация вышеуказанных шагов приведена ниже.
```javascript
var pres = new aspose.slides.Presentation("transparency.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var effects = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getEffectFormat();
    var outerShadowEffect = effects.getOuterShadowEffect();
    var shadowColor = outerShadowEffect.getShadowColor().getColor();
    console.log((shadowColor.toString() + " - transparency is: ") + ((shadowColor.getAlpha() / 255.0) * 100));
    // установить прозрачность в 0 процентов
    outerShadowEffect.getShadowColor().setColor(java.newInstanceSync("java.awt.Color", shadowColor.getRed(), shadowColor.getGreen(), shadowColor.getBlue(), 255));
    pres.save("transparency-2.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Установка межсимвольного интервала для текста**

Aspose.Slides позволяет задать интервал между буквами в текстовом поле. Таким образом, вы можете регулировать визуальную плотность строки или блока текста, расширяя или сужая интервал между символами.

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

Презентации обычно содержат как текст, так и изображения. Текст может быть отформатирован различными способами — либо для выделения определённых разделов и слов, либо в соответствии с корпоративными стилями. Форматирование текста помогает пользователям варьировать внешний вид содержимого презентации. Эта статья показывает, как с помощью Aspose.Slides for Node.js via Java настроить свойства шрифта абзацев текста на слайдах. Чтобы управлять свойствами шрифта абзаца, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Получите доступ к Placeholder‑формам на слайде и приведите их к типу [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
1. Получите [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) из [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame), предоставленного объектом [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
1. Выравняйте абзац.
1. Получите текстовую Portion абзаца.
1. Определите шрифт с помощью FontData и задайте шрифт Portion соответственно.  
   1. Установите шрифт полужирным.  
   1. Установите шрифт курсивом.
1. Задайте цвет шрифта, используя [getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BasePortionFormat#getFillFormat--) объекта [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion).
1. Сохраните изменённую презентацию в файл [PPTX](https://docs.fileformat.com/presentation/pptx/).

Реализация вышеуказанных шагов приведена ниже. Она берёт простую презентацию и форматирует шрифты на одном из слайдов.
```javascript
// Создать объект Presentation, представляющий файл PPTX
var pres = new aspose.slides.Presentation("FontProperties.pptx");
try {
    // Доступ к слайду по его индексу
    var slide = pres.getSlides().get_Item(0);
    // Доступ к первому и второму placeholder на слайде и приведение их к AutoShape
    var tf1 = slide.getShapes().get_Item(0).getTextFrame();
    var tf2 = slide.getShapes().get_Item(1).getTextFrame();
    // Доступ к первому абзацу
    var para1 = tf1.getParagraphs().get_Item(0);
    var para2 = tf2.getParagraphs().get_Item(0);
    // Доступ к первой части текста
    var port1 = para1.getPortions().get_Item(0);
    var port2 = para2.getPortions().get_Item(0);
    // Определить новые шрифты
    var fd1 = new aspose.slides.FontData("Elephant");
    var fd2 = new aspose.slides.FontData("Castellar");
    // Присвоить новые шрифты части текста
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
    // Сохранить PPTX на диск
    pres.save("WelcomeFont_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Управление семейством шрифтов текста**

Portion используется для хранения текста с одинаковым стилем форматирования в абзаце. Эта статья показывает, как с помощью Aspose.Slides for Node.js via Java создать текстовое поле с некоторым текстом, а затем задать конкретный шрифт и другие свойства семейства шрифтов. Чтобы создать текстовое поле и задать свойства шрифта текста в нём:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) типа [Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeType#Rectangle) на слайд.
4. Удалите стиль заполнения, связанный с [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
5. Получите TextFrame AutoShape.
6. Добавьте некоторый текст в TextFrame.
7. Получите объект Portion, связанный с [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
8. Определите шрифт, который будет использоваться для [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion).
9. Задайте другие свойства шрифта, такие как полужирный, курсив, подчеркивание, цвет и высота, используя соответствующие свойства объекта Portion.
10. Сохраните изменённую презентацию в файл PPTX.

Реализация вышеуказанных шагов приведена ниже.
```javascript
// Создать объект Presentation
var pres = new aspose.slides.Presentation();
try {
    // Получить первый слайд
    var sld = pres.getSlides().get_Item(0);
    // Добавить AutoShape типа Rectangle
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    // Удалить любой стиль заполнения, связанный с AutoShape
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


## **Установка размера шрифта текста**

Aspose.Slides позволяет выбрать предпочтительный размер шрифта для существующего текста в абзаце и для текста, который может быть добавлен позже в тот же абзац.

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
        // Устанавливает размер шрифта по умолчанию 20 pt для всех текстовых частей в абзаце.
        paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
        // Устанавливает размер шрифта 20 pt для текущих текстовых частей в абзаце.
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


## **Установка вращения текста**

Aspose.Slides for Node.js via Java позволяет разработчикам вращать текст. Текст может быть отображён как [Horizontal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#Horizontal), [Vertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#Vertical), [Vertical270](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#Vertical270), [WordArtVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#WordArtVertical), [EastAsianVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#EastAsianVertical), [MongolianVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#MongolianVertical) или [WordArtVerticalRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#WordArtVerticalRightToLeft). Чтобы вращать текст в любом TextFrame, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Получите доступ к первому слайду.
3. Добавьте любую форму на слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
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
    // Доступ к текстовому фрейму
    var txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setTextVerticalType(aspose.slides.TextVerticalType.Vertical270);
    // Создать объект Paragraph для текстового фрейма
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


## **Установка пользовательского угла вращения для TextFrame**

Aspose.Slides for Node.js via Java теперь поддерживает установку пользовательского угла вращения для TextFrame. В этой теме мы покажем пример, как задать свойство RotationAngle в Aspose.Slides. В новые методы [setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setRotationAngle-float-) и [getRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#getRotationAngle--) были добавлены в классы [ChartTextBlockFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartTextBlockFormat) и [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat), позволяя задавать пользовательский угол вращения для TextFrame. Чтобы задать RotationAngle, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Добавьте диаграмму на слайд.
3. [Set RotationAngle property](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setRotationAngle-float-).
4. Сохраните презентацию в файл PPTX.

В примере ниже задается свойство RotationAngle.
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
    // Доступ к текстовому фрейму
    var txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setRotationAngle(25);
    // Создать объект Paragraph для текстового фрейма
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

Aspose.Slides предоставляет свойства в [`ParagraphFormat`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ParagraphFormat) — `SpaceAfter`, `SpaceBefore` и `SpaceWithin` — позволяющие управлять межстрочным интервалом абзаца. Эти три свойства используются следующим образом:

* Чтобы задать межстрочный интервал в процентах, используйте положительное значение.  
* Чтобы задать межстрочный интервал в пунктах, используйте отрицательное значение.

Например, можно задать межстрочный интервал 16 pt, установив свойство `SpaceBefore` в ‑16.

Так задаётся межстрочный интервал для конкретного абзаца:

1. Загрузите презентацию, содержащую AutoShape с текстом.
2. Получите ссылку на слайд через его индекс.
3. Получите TextFrame.
4. Получите Paragraph.
5. Задайте свойства Paragraph.
6. Сохраните презентацию.

Этот JavaScript‑код показывает, как задать межстрочный интервал для абзаца:
```javascript
// Создать экземпляр класса Presentation
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    // Получить ссылку на слайд по его индексу
    var sld = pres.getSlides().get_Item(0);
    // Получить доступ к TextFrame
    var tf1 = sld.getShapes().get_Item(0).getTextFrame();
    // Получить доступ к абзацу
    var para = tf1.getParagraphs().get_Item(0);
    // Установить свойства абзаца
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


## **Установка свойства AutofitType для TextFrame**

В этой теме мы рассматриваем различные свойства форматирования текстового фрейма. Статья описывает, как задать свойство AutofitType текстового фрейма, привязку текста и вращение текста в презентации. Aspose.Slides for Node.js via Java позволяет разработчикам задать свойство AutofitType любого текстового фрейма. AutofitType может быть установлен в [Normal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAutofitType#Normal) или [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAutofitType#Shape). Если установлено значение [Normal], форма остаётся прежней, а текст подгоняется без изменения формы. Если AutofitType установлен в [Shape], форма изменяется так, чтобы в ней помещался только необходимый текст. Чтобы задать свойство AutofitType текстового фрейма, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation ](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)class.
2. Получите доступ к первому слайду.
3. Добавьте любую форму на слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
5. [Set the AutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType-byte-) TextFrame.
6. Сохраните файл на диск.
```javascript
// Создать экземпляр класса Presentation
var pres = new aspose.slides.Presentation();
try {
    // Получить доступ к первому слайду
    var slide = pres.getSlides().get_Item(0);
    // Добавить AutoShape типа Rectangle
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 350, 150);
    // Добавить TextFrame к прямоугольнику
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Доступ к текстовому фрейму
    var txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAutofitType(aspose.slides.TextAutofitType.Shape);
    // Создать объект Paragraph для текстового фрейма
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


## **Установка привязки (Anchor) TextFrame**

Aspose.Slides for Node.js via Java позволяет разработчикам задавать привязку любого TextFrame. TextAnchorType указывает, где текст размещён внутри формы. AnchorType может быть установлен в [Top](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Top), [Center](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Center), [Bottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Bottom), [Justified](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Justified) или [Distributed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Distributed). Чтобы задать привязку любого TextFrame, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
2. Получите доступ к первому слайду.
3. Добавьте любую форму на слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
5. [Set TextAnchorType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setAnchoringType-byte-) TextFrame.
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
        // Доступ к текстовому фрейму
        var txtFrame = ashp.getTextFrame();
        txtFrame.getTextFrameFormat().setAnchoringType(aspose.slides.TextAnchorType.Bottom);
        // Создать объект Paragraph для текстового фрейма
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

Все табуляции текста задаются в пикселах.

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**Figure: 2 Explicit Tabs and 2 Default Tabs**|

- Свойство EffectiveTabs.ExplicitTabCount (2 в нашем случае) равно Tabs.Count.  
- Коллекция EffectiveTabs включает все табы (из коллекции Tabs и табы по умолчанию).  
- Свойство EffectiveTabs.ExplicitTabCount (2 в нашем случае) равно Tabs.Count.  
- Свойство EffectiveTabs.DefaultTabSize (294) показывает расстояние между табами по умолчанию (3 и 4 в нашем примере).  
- EffectiveTabs.GetTabByIndex(index) с index = 0 возвращает первый явный таб (Position = 731), index = 1 — второй таб (Position = 1241). При попытке получить таб с index = 2 вернётся первый таб по умолчанию (Position = 1470) и т.д.  
- EffectiveTabs.GetTabAfterPosition(pos) используется для получения следующей табуляции после некоторого текста. Например, есть текст «Hello World!». Чтобы отрисовать такой текст, нужно знать, где начать рисовать «world!». Сначала вычислите длину «Hello» в пикселях и вызовите GetTabAfterPosition с этим значением. Вы получите позицию следующей табуляции для рисования «world!».

## **Установка стиля текста по умолчанию**

Если нужно применить одинаковое форматирование текста ко всем элементам текста презентации сразу, используйте метод `getDefaultTextStyle` класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) и задайте предпочтительное форматирование. Пример кода ниже показывает, как задать шрифт полужирный (14 pt) по умолчанию для текста на всех слайдах новой презентации.
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


## **Извлечение текста с эффектом All‑Caps**

В PowerPoint применение эффекта **All Caps** делает текст заглавным на слайде, даже если он изначально набран строчными. При извлечении такой части текста с помощью Aspose.Slides библиотека возвращает текст именно так, как он был введён. Чтобы обработать это, проверьте [TextCapType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textcaptype/) — если он указывает `All`, просто преобразуйте возвращённую строку в верхний регистр, чтобы ваш вывод соответствовал тому, что видят пользователи на слайде.

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


Output:
```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```


## **FAQ**

**Как изменить текст в таблице на слайде?**

Чтобы изменить текст в таблице на слайде, используйте объект [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/). Можно перебрать все ячейки таблицы и изменить текст в каждой ячейке, получив её `TextFrame` и свойства `ParagraphFormat`.

**Как применить градиентный цвет к тексту в слайде PowerPoint?**

Чтобы применить градиентный цвет к тексту, используйте свойство Fill Format в [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/). Установите Fill Format в `Gradient`, где можно задать начальный и конечный цвета градиента, а также другие свойства, такие как направление и прозрачность, чтобы создать градиентный эффект на тексте.