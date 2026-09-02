---
title: Управление текстовыми абзацами PowerPoint в JavaScript
linktitle: Управление абзацем
type: docs
weight: 40
url: /ru/nodejs-java/manage-paragraph/
aliases:
  - /nodejs-java/параграф/
  - /nodejs-java/часть/
keywords:
- добавить текст
- добавить абзац
- управлять текстом
- управлять абзацем
- управлять маркировкой
- отступ абзаца
- висячий отступ
- маркировка абзаца
- нумерованный список
- маркированный список
- свойства абзаца
- импортировать HTML
- текст в HTML
- абзац в HTML
- абзац в изображение
- текст в изображение
- экспортировать абзац
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Узнайте, как создавать и форматировать абзацы, фрагменты, маркировки, нумерованные списки, отступы, HTML‑содержимое и изображения абзацев с помощью Aspose.Slides для Node.js через Java."
---
## **Обзор**

Aspose.Slides for Node.js via Java представляет текст как иерарекцию текстовых фреймов, абзацев и фрагментов:

* [TextFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/) представляет контейнер текста в фигуре и предоставляет доступ к её коллекции абзацев.
* [Paragraph](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/paragraph/) представляет один абзац в текстовом фрейме и предоставляет доступ к его фрагментам и форматированию уровня абзаца.
* [Portion](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/portion/) представляет фрагмент текста внутри абзаца. Каждый фрагмент может иметь собственный текст и форматирование уровня символов.

Таким образом, абзац может содержать текст с разными шрифтами, цветами, размерами и другим форматированием, используя несколько фрагментов.

## **Создание и форматирование абзацев**

### **Создание абзацев с несколькими фрагментами**

Следующие шаги создают текстовый фрейм с тремя абзацами, каждый из которых содержит три фрагмента:

1. Создайте экземпляр класса [Presentation].
2. Получите доступ к нужному слайду по его индексу.
3. Добавьте прямоугольную [AutoShape] на слайд.
4. Получите доступ к [TextFrame] фигуры.
5. Используйте абзац по умолчанию и добавьте два дополнительных объекта [Paragraph] в текстовый фрейм.
6. Добавьте достаточное количество объектов [Portion] для каждого абзаца, чтобы он содержал три фрагмента. Абзац по умолчанию уже содержит один пустой фрагмент.
7. Установите текст для каждого фрагмента.
8. Примените форматирование уровня символов через [Portion.getPortionFormat].
9. Сохраните изменённую презентацию.

Этот пример JavaScript реализует указанные шаги:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 300, 150);
    const textFrame = shape.getTextFrame();

    const firstParagraph = textFrame.getParagraphs().get_Item(0);
    firstParagraph.getPortions().add(new aspose.slides.Portion());
    firstParagraph.getPortions().add(new aspose.slides.Portion());

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    textFrame.getParagraphs().add(secondParagraph);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    textFrame.getParagraphs().add(thirdParagraph);

    const paragraphCount = textFrame.getParagraphs().getCount();
    for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
        const portionCount = paragraph.getPortions().getCount();
        for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            const portion = paragraph.getPortions().get_Item(portionIndex);
            portion.setText("Portion " + (paragraphIndex + 1) + "." + (portionIndex + 1));

            if (portionIndex === 0) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
                portion.getPortionFormat().setFontHeight(15);
            } else if (portionIndex === 1) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
                portion.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    presentation.save("paragraphs_with_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Создание маркированных и нумерованных списков**

### **Создание маркированного или нумерованного списка**

Маркировка и нумерация упрощают просмотр связанных элементов. В Aspose.Slides настройки списка определяются через [BulletFormat].

1. Создайте экземпляр класса [Presentation].
2. Получите доступ к нужному слайду по его индексу.
3. Добавьте [AutoShape] на выбранный слайд.
4. Получите доступ к [TextFrame] фигуры.
5. Удалите абзац по умолчанию из текстового фрейма.
6. Создайте [Paragraph] для символической маркировки.
7. Установите [BulletFormat.setType] в значение [BulletType.Symbol] и задайте символ маркировки.
8. Установите текст абзаца, отступ, цвет маркировки и высоту марки.
9. Добавьте абзац в текстовый фрейм.
10. Создайте второй абзац и установите [BulletFormat.setType] в значение [BulletType.Numbered].
11. Настройте стиль нумерованной маркировки и добавьте абзац в текстовый фрейм.
12. Сохраните презентацию.

Этот пример JavaScript создаёт символическую маркировку и нумерованную маркировку:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const symbolParagraph = new aspose.slides.Paragraph();
    symbolParagraph.setText("Welcome to Aspose.Slides");
    symbolParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    symbolParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    symbolParagraph.getParagraphFormat().setIndent(25);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    symbolParagraph.getParagraphFormat().getBullet().setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    symbolParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(symbolParagraph);

    const numberedParagraph = new aspose.slides.Paragraph();
    numberedParagraph.setText("This is a numbered item");
    numberedParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    numberedParagraph.getParagraphFormat().getBullet().setNumberedBulletStyle(java.newByte(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain));
    numberedParagraph.getParagraphFormat().setIndent(25);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    numberedParagraph.getParagraphFormat().getBullet().setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    numberedParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(numberedParagraph);

    presentation.save("bulleted_and_numbered_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Использование изображений в маркировке**

Изображения в маркировке позволяют использовать собственное изображение вместо символа или цифры.

1. Создайте экземпляр класса [Presentation].
2. Получите доступ к нужному слайду по его индексу.
3. Добавьте [AutoShape] и получите доступ к его [TextFrame].
4. Удалите абзац по умолчанию из текстового фрейма.
5. Загрузите изображение маркировки и добавьте его в коллекцию изображений презентации как [PPImage].
6. Создайте [Paragraph] и задайте его текст.
7. Установите [BulletFormat.setType] в значение [BulletType.Picture].
8. Назначьте изображение через [BulletFormat.getPicture] и задайте высоту марки.
9. Добавьте абзац в текстовый фрейм.
10. Сохраните изменённую презентацию.

Этот пример JavaScript создаёт изображение в качестве маркировки:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const bulletImage = aspose.slides.Images.fromFile("image.png");
    let presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(bulletImage);
    } finally {
        bulletImage.dispose();
    }

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph = new aspose.slides.Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    paragraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Picture));
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentationImage);
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(paragraph);

    presentation.save("picture_bullet.pptx", aspose.slides.SaveFormat.Pptx);
    presentation.save("picture_bullet.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

### **Создание многоуровневого списка**

Установите [ParagraphFormat.setDepth], чтобы разместить абзацы на разных уровнях списка. Верхний уровень имеет глубину `0`.

1. Создайте [Presentation] и получите доступ к слайду.
2. Добавьте [AutoShape] и очистите абзац по умолчанию из его текстового фрейма.
3. Создайте четыре абзаца и настройте их символы маркировки.
4. Установите их значения [ParagraphFormat.setDepth] в `0`, `1`, `2` и `3`.
5. Добавьте абзацы в текстовый фрейм и сохраните презентацию.

Этот пример JavaScript создаёт четырёхуровневый маркированный список:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("Content");
    firstParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    firstParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setDepth(java.newShort(0));

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("Second level");
    secondParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    secondParagraph.getParagraphFormat().getBullet().setChar(java.newChar(45));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setDepth(java.newShort(1));

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("Third level");
    thirdParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    thirdParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.getParagraphFormat().setDepth(java.newShort(2));

    const fourthParagraph = new aspose.slides.Paragraph();
    fourthParagraph.setText("Fourth level");
    fourthParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    fourthParagraph.getParagraphFormat().getBullet().setChar(java.newChar(45));
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    fourthParagraph.getParagraphFormat().setDepth(java.newShort(3));

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);
    textFrame.getParagraphs().add(fourthParagraph);

    presentation.save("multilevel_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Начало нумерованных пунктов списка с пользовательских значений**

Используйте [BulletFormat.setNumberedBulletStartWith], чтобы задать начальный номер, отображаемый для нумерованного абзаца.

1. Создайте [Presentation] и добавьте [AutoShape] на слайд.
2. Очистите абзац по умолчанию из текстового фрейма фигуры.
3. Создайте три нумерованных абзаца.
4. Установите [BulletFormat.setNumberedBulletStartWith] в `2`, `3` и `7` для соответствующих абзацев.
5. Добавьте абзацы в текстовый фрейм и сохраните презентацию.

Этот пример JavaScript назначает пользовательский начальный номер каждому абзацу:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("Start at 2");
    firstParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    firstParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(2));
    textFrame.getParagraphs().add(firstParagraph);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("Start at 3");
    secondParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    secondParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(3));
    textFrame.getParagraphs().add(secondParagraph);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("Start at 7");
    thirdParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    thirdParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(7));
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("custom_numbered_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Управление расположением абзаца и конечными свойствами**

### **Установка отступа первой строки**

Используйте [ParagraphFormat.setIndent], чтобы контролировать отступ первой строки абзаца. Этот метод перемещает только первую строку относительно левого поля абзаца. Положительное значение смещает первую строку вправо, остальные строки остаются выровненными по телу абзаца.

Используйте [ParagraphFormat.setMarginLeft], когда нужно переместить весь абзац. Используйте [ParagraphFormat.setIndent], когда нужно переместить только первую строку.

Пример ниже создаёт несколько абзацев и применяет разные значения [ParagraphFormat.setIndent], чтобы продемонстрировать, как отступ первой строки влияет на расположение абзаца.

1. Создайте экземпляр класса [Presentation].
2. Получите доступ к целевому слайду.
3. Добавьте прямоугольную [AutoShape] на слайд.
4. Получите доступ к [TextFrame] фигуры и удалите абзац по умолчанию.
5. Создайте несколько абзацев и задайте им разные значения [ParagraphFormat.setIndent].
6. Добавьте абзацы в текстовый фрейм.
7. Сохраните изменённую презентацию.

Этот код показывает, как установить отступ абзаца:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setMarginLeft(20);
    firstParagraph.getParagraphFormat().setIndent(0);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setMarginLeft(20);
    secondParagraph.getParagraphFormat().setIndent(20);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.getParagraphFormat().setMarginLeft(20);
    thirdParagraph.getParagraphFormat().setIndent(40);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![The first-line indent of the paragraphs](first_line_indent.png)

### **Установка висячего отступа**

Висячий отступ — это расположение абзаца, при котором первая строка начинается левее остальных строк. В Aspose.Slides вы создаёте этот эффект с помощью [ParagraphFormat.setIndent]. Передайте отрицательное значение, чтобы переместить первую строку влево относительно тела абзаца.

На практике [ParagraphFormat.setMarginLeft] определяет левую позицию тела абзаца, а [ParagraphFormat.setIndent] определяет позицию первой строки относительно этого поля. Чтобы создать висячий отступ, передайте положительное значение в `setMarginLeft` и отрицательное значение в `setIndent`.

Такое форматирование полезно для библиографий, ссылок, глоссариев и других абзацев, где переносимые строки должны выравниваться под телом абзаца, а не под первым символом первой строки.

1. Создайте экземпляр класса [Presentation].
2. Получите доступ к целевому слайду.
3. Добавьте прямоугольную [AutoShape] на слайд.
4. Получите доступ к [TextFrame] фигуры и удалите абзац по умолчанию.
5. Создайте абзацы и задайте положительное значение [ParagraphFormat.setMarginLeft] для каждого абзаца.
6. Передайте отрицательное значение в [ParagraphFormat.setIndent], чтобы создать эффект висячего отступа.
7. Добавьте абзацы в текстовый фрейм.
8. Сохраните изменённую презентацию.

Этот код показывает, как установить висячий отступ для абзаца:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setMarginLeft(40);
    firstParagraph.getParagraphFormat().setIndent(-20);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setMarginLeft(60);
    secondParagraph.getParagraphFormat().setIndent(-30);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![The hanging indent of the paragraphs](hanging_indent.png)

### **Установка свойств конечного фрагмента абзаца**

[Paragraph.setEndParagraphPortionFormat] управляет форматированием конечного знака абзаца. В следующем примере задаётся размер шрифта и латинский шрифт для конечного знака второго абзаца:

1. Создайте или загрузите [Presentation] и получите доступ к слайду.
2. Добавьте [AutoShape] и очистите его абзац по умолчанию.
3. Создайте два абзаца и добавьте в них текстовые фрагменты.
4. Создайте [PortionFormat] для конечного знака второго абзаца.
5. Установите [BasePortionFormat.setFontHeight] и [BasePortionFormat.setLatinFont].
6. Назначьте формат с помощью [Paragraph.setEndParagraphPortionFormat] и сохраните презентацию.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 200, 250);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getPortions().add(new aspose.slides.Portion("Sample text"));

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getPortions().add(new aspose.slides.Portion("Sample text 2"));

    const endParagraphFormat = new aspose.slides.PortionFormat();
    endParagraphFormat.setFontHeight(48);
    endParagraphFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    secondParagraph.setEndParagraphPortionFormat(endParagraphFormat);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("end_paragraph_format.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Импорт и экспорт содержимого абзацев**

### **Импорт HTML-текста в абзацы**

Используйте [ParagraphCollection.addFromHtml] для преобразования HTML‑разметки в абзацы и фрагменты в текстовом фрейме.

1. Создайте экземпляр класса [Presentation].
2. Получите доступ к слайду и добавьте [AutoShape].
3. Получите доступ к [TextFrame] фигуры и очистите её абзац по умолчанию.
4. Определите или считайте исходную строку HTML.
5. Передайте строку HTML в [ParagraphCollection.addFromHtml].
6. Сохраните изменённую презентацию.

Этот пример JavaScript импортирует HTML в текстовый фрейм:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shapeWidth = presentation.getSlideSize().getSize().getWidth() - 20;
    const shapeHeight = presentation.getSlideSize().getSize().getHeight() - 20;
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().getParagraphs().clear();

    const html = "<p><b>Aspose.Slides</b> imports HTML text into presentation paragraphs.</p>";
    shape.getTextFrame().getParagraphs().addFromHtml(html);
    presentation.save("html_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Экспорт текста абзаца в HTML**

Используйте [ParagraphCollection.exportToHtml] для экспорта выбранного диапазона абзацев в HTML.

1. Создайте или загрузите экземпляр класса [Presentation].
2. Получите доступ к слайду и найдите [AutoShape], содержащий текст.
3. Получите доступ к [TextFrame] фигуры.
4. Вызовите [ParagraphCollection.exportToHtml] с индексом начального абзаца и количеством абзацев для экспорта.
5. Запишите возвращённую строку HTML в файл.

Этот автономный пример JavaScript создаёт текстовую форму и экспортирует все её абзацы:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 100);
    const sourceTextFrame = sourceShape.getTextFrame();
    sourceTextFrame.getParagraphs().clear();
    for (const text of ["First paragraph", "Second paragraph", "Third paragraph"]) {
        const sourceParagraph = new aspose.slides.Paragraph();
        sourceParagraph.setText(text);
        sourceTextFrame.getParagraphs().add(sourceParagraph);
    }
    const shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        const textFrame = shape.getTextFrame();
        if (textFrame !== null) {
            const paragraphs = textFrame.getParagraphs();
            const html = paragraphs.exportToHtml(0, paragraphs.getCount(), null);
            fs.writeFileSync("paragraphs.html", html, "utf8");
        } else {
            console.log("The first shape does not contain a text frame.");
        }
    } else {
        console.log("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

### **Отображение абзаца как изображения**

[Paragraph.getImage] отображает отдельный абзац напрямую и возвращает [IImage]. Сохраните результат в файл с помощью [IImage.save]. Нет необходимости отображать содержащую форму или вручную обрезать bitmap.

[Paragraph.getImage] может возвращать `null`, если абзац не найден в родительской коллекции, не имеет корректных границ рендеринга или не может быть отрисован. Проверьте результат перед сохранением и освободите полученное изображение после использования.

#### **Отображение абзаца в масштабе по умолчанию**

Следующий текстовый блок содержит три абзаца:

![The text box with three paragraphs](paragraph_to_image_input.png)

Следующий пример отображает второй абзац в обычной текстовой форме в масштабе по умолчанию и сохраняет полученное изображение в формате PNG. Блок `finally` гарантирует корректное освобождение изображения.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 100);
    const sourceTextFrame = sourceShape.getTextFrame();
    sourceTextFrame.getParagraphs().clear();
    for (const text of ["First paragraph", "Second paragraph", "Third paragraph"]) {
        const sourceParagraph = new aspose.slides.Paragraph();
        sourceParagraph.setText(text);
        sourceTextFrame.getParagraphs().add(sourceParagraph);
    }
    const shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        const textFrame = shape.getTextFrame();
        if (textFrame !== null && textFrame.getParagraphs().getCount() > 1) {
            const paragraph = textFrame.getParagraphs().get_Item(1);
            const paragraphImage = paragraph.getImage();

            if (paragraphImage !== null) {
                try {
                    paragraphImage.save("paragraph.png", aspose.slides.ImageFormat.Png);
                } finally {
                    paragraphImage.dispose();
                }
            } else {
                console.log("The paragraph could not be rendered.");
            }
        } else {
            console.log("The expected paragraph was not found.");
        }
    } else {
        console.log("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

Результат:

![The paragraph image](paragraph_to_image_output.png)

#### **Отображение абзаца в ячейке таблицы с масштабированием**

Используйте перегрузку [Paragraph.getImage], принимающую параметры `scaleX` и `scaleY`, чтобы задать горизонтальный и вертикальный коэффициенты масштабирования.

Следующий пример создаёт таблицу, отображает абзац в первой ячейке с удвоенной шириной и высотой по сравнению с размером по умолчанию и сохраняет результат как PNG‑изображение.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const scaleX = 2;
const scaleY = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const columnWidths = java.newArray("double", [300]);
    const rowHeights = java.newArray("double", [80]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);
    const paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0);
    paragraph.setText("Text in a table cell");

    const paragraphImage = paragraph.getImage(scaleX, scaleY);
    if (paragraphImage !== null) {
        try {
            paragraphImage.save("table_paragraph.png", aspose.slides.ImageFormat.Png);
        } finally {
            paragraphImage.dispose();
        }
    } else {
        console.log("The paragraph could not be rendered.");
    }
} finally {
    presentation.dispose();
}
```

Коэффициент масштабирования `1` сохраняет размер оси в пикселях по умолчанию. Например, `2` для обоих коэффициентов создаёт изображение, ширина и высота которого примерно вдвое превышают размеры по умолчанию, что даёт в четыре раза больше пикселей. Большие коэффициенты, как правило, дают более чёткий текст при увеличении или выводе в высоком разрешении, но также увеличивают потребление памяти и размер файла. Коэффициенты ниже `1` создают более мелкие изображения с меньшей детализацией. Используйте одинаковые коэффициенты, чтобы сохранить соотношение сторон абзаца; разные горизонтальные и вертикальные коэффициенты растягивают вывод независимо.

Отрисовка всей формы с помощью [Shape.getImage] остаётся полезной, когда вывод должен включать заливку, границу формы или другой визуальный контекст. Для изображения только абзаца используйте [Paragraph.getImage].

## **FAQ**

**Можно ли полностью отключить перенос строк внутри текстового фрейма?**

Да. Установите [TextFrameFormat.setWrapText], чтобы отключить перенос, и строки не будут разбиваться у краёв текстового фрейма.

**Как получить точные границы конкретного абзаца на слайде?**

Используйте [Paragraph.getRect], чтобы получить ограничивающий прямоугольник абзаца. [Portion.getRect] предоставляет границы отдельного фрагмента.

**Где управляется выравнивание абзаца (по левому краю, правому, по центру или по ширине)?**

[ParagraphFormat.setAlignment] — это настройка уровня абзаца и применяется ко всему абзацу независимо от форматирования отдельных фрагментов.

**Можно ли задать язык проверки правописания для части абзаца?**

Да. Установите [BasePortionFormat.setLanguageId] для отдельных фрагментов, чтобы один абзац мог содержать текст на нескольких языках.