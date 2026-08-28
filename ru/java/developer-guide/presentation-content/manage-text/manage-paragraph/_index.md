---
title: Управление абзацами текста PowerPoint в Java
linktitle: Управление абзацем
type: docs
weight: 40
url: /ru/java/manage-paragraph/
aliases:
  - /java/paragraph/
  - /java/portion/
keywords:
  - добавить текст
  - добавить абзац
  - управлять текстом
  - управлять абзацем
  - управлять маркером
  - отступ абзаца
  - висячий отступ
  - маркер абзаца
  - нумерованный список
  - маркированный список
  - свойства абзаца
  - импорт HTML
  - текст в HTML
  - абзац в HTML
  - абзац в изображение
  - текст в изображение
  - экспорт абзаца
  - PowerPoint
  - презентация
  - Java
  - Aspose.Slides
description: "Узнайте, как создавать и форматировать абзацы, фрагменты, маркеры, нумерованные списки, отступы, HTML‑контент и изображения абзацев с помощью Aspose.Slides для Java."
---
## **Обзор**

Aspose.Slides for Java представляет текст как иерархию текстовых рамок, абзацев и фрагментов:

* [ITextFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/) представляет контейнер текста в фигуре и предоставляет доступ к её коллекции абзацев.
* [IParagraph](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraph/) представляет один абзац в текстовой рамке и предоставляет доступ к её фрагментам и форматированию уровня абзаца.
* [IPortion](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iportion/) представляет участок текста внутри абзаца. Каждый фрагмент может иметь собственный текст и форматирование символов.

Таким образом, абзац может содержать текст с разными шрифтами, цветами, размерами и другим форматированием, используя несколько фрагментов.

## **Создание и форматирование абзацев**

### **Создание абзацев с несколькими фрагментами**

Следующие шаги создают текстовую рамку с тремя абзацами, каждый из которых содержит три фрагмента:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/).
2. Получите нужный слайд по его индексу.
3. Добавьте прямоугольную [IAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape/) на слайд.
4. Получите [ITextFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/) фигуры.
5. Используйте абзац по умолчанию и добавьте ещё два объекта [IParagraph](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraph/) в текстовую рамку.
6. Добавьте достаточное количество объектов [IPortion](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iportion/) для каждого абзаца, чтобы получить по три фрагмента. Абзац по умолчанию уже содержит один пустой фрагмент.
7. Установите текст каждого фрагмента.
8. Примените форматирование уровня символов через [IPortion.getPortionFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iportion/#getPortionFormat--).
9. Сохраните изменённую презентацию.

Этот пример на Java реализует указанные шаги:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);
    ITextFrame textFrame = shape.getTextFrame();

    IParagraph firstParagraph = textFrame.getParagraphs().get_Item(0);
    firstParagraph.getPortions().add(new Portion());
    firstParagraph.getPortions().add(new Portion());

    IParagraph secondParagraph = new Paragraph();
    secondParagraph.getPortions().add(new Portion());
    secondParagraph.getPortions().add(new Portion());
    secondParagraph.getPortions().add(new Portion());
    textFrame.getParagraphs().add(secondParagraph);

    IParagraph thirdParagraph = new Paragraph();
    thirdParagraph.getPortions().add(new Portion());
    thirdParagraph.getPortions().add(new Portion());
    thirdParagraph.getPortions().add(new Portion());
    textFrame.getParagraphs().add(thirdParagraph);

    int paragraphCount = textFrame.getParagraphs().getCount();
    for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        IParagraph paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
        int portionCount = paragraph.getPortions().getCount();
        for (int portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            IPortion portion = paragraph.getPortions().get_Item(portionIndex);
            portion.setText("Portion " + (paragraphIndex + 1) + "." + (portionIndex + 1));

            if (portionIndex == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
                portion.getPortionFormat().setFontBold(NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (portionIndex == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
                portion.getPortionFormat().setFontItalic(NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    presentation.save("paragraphs_with_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Создание маркированных и нумерованных списков**

### **Создание маркированного или нумерованного списка**

Марки и нумерация упрощают восприятие связанных элементов. В Aspose.Slides настройки списка определяются через [IBulletFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibulletformat/).

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/).
2. Получите нужный слайд по его индексу.
3. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape/) на выбранный слайд.
4. Получите [ITextFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/) фигуры.
5. Удалите абзац по умолчанию из текстовой рамки.
6. Создайте объект [Paragraph](https://reference.aspose.com/slides/ru/java/com.aspose.slides/paragraph/) для символической марки.
7. Установите [IBulletFormat.setType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibulletformat/#setType-int-) в значение [BulletType.Symbol](https://reference.aspose.com/slides/ru/java/com.aspose.slides/bullettype/) и задайте символ марки.
8. Установите текст абзаца, отступ, цвет марки и высоту марки.
9. Добавьте абзац в текстовую рамку.
10. Создайте второй абзац и установите [IBulletFormat.setType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibulletformat/#setType-int-) в значение [BulletType.Numbered](https://reference.aspose.com/slides/ru/java/com.aspose.slides/bullettype/).
11. Настройте стиль нумерованной марки и добавьте абзац в текстовую рамку.
12. Сохраните презентацию.

Этот пример на Java создает символическую и нумерованную марки:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph symbolParagraph = new Paragraph();
    symbolParagraph.setText("Welcome to Aspose.Slides");
    symbolParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    symbolParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    symbolParagraph.getParagraphFormat().setIndent(25);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    symbolParagraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    symbolParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(symbolParagraph);

    Paragraph numberedParagraph = new Paragraph();
    numberedParagraph.setText("This is a numbered item");
    numberedParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    numberedParagraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);
    numberedParagraph.getParagraphFormat().setIndent(25);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    numberedParagraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    numberedParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(numberedParagraph);

    presentation.save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Использование изображений в качестве марок**

Изображения‑марки позволяют использовать собственный рисунок вместо символа или числа.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/).
2. Получите нужный слайд по его индексу.
3. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape/) и получайте её [ITextFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/).
4. Удалите абзац по умолчанию из текстовой рамки.
5. Загрузите изображение марки и добавьте его в коллекцию изображений презентации как [IPPImage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ippimage/).
6. Создайте объект [Paragraph](https://reference.aspose.com/slides/ru/java/com.aspose.slides/paragraph/) и задайте его текст.
7. Установите [IBulletFormat.setType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibulletformat/#setType-int-) в значение [BulletType.Picture](https://reference.aspose.com/slides/ru/java/com.aspose.slides/bullettype/).
8. Присвойте изображение через [IBulletFormat.getPicture](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibulletformat/#getPicture--) и задайте высоту марки.
9. Добавьте абзац в текстовую рамку.
10. Сохраните изменённую презентацию.

Этот пример на Java создаёт марку‑изображение:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage bulletImage = Images.fromFile("bullets.png");
    IPPImage presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(bulletImage);
    } finally {
        bulletImage.dispose();
    }

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentationImage);
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(paragraph);

    presentation.save("picture_bullet.pptx", SaveFormat.Pptx);
    presentation.save("picture_bullet.ppt", SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

### **Создание многоуровневого списка**

Установите [IParagraphFormat.setDepth](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraphformat/#setDepth-short-) для размещения абзацев на разных уровнях списка. Верхний уровень имеет глубину `0`.

1. Создайте объект [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/) и получите слайд.
2. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape/) и очистите абзац по умолчанию из её текстовой рамки.
3. Создайте четыре абзаца и настройте их символы марок.
4. Установите их значения [IParagraphFormat.setDepth](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraphformat/#setDepth-short-) в `0`, `1`, `2` и `3`.
5. Добавьте абзацы в текстовую рамку и сохраните презентацию.

Этот пример на Java создаёт четырёхуровневый маркированный список:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    IParagraph firstParagraph = new Paragraph();
    firstParagraph.setText("Content");
    firstParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    firstParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setDepth((short) 0);

    IParagraph secondParagraph = new Paragraph();
    secondParagraph.setText("Second level");
    secondParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    secondParagraph.getParagraphFormat().getBullet().setChar('-');
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setDepth((short) 1);

    IParagraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("Third level");
    thirdParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    thirdParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.getParagraphFormat().setDepth((short) 2);

    IParagraph fourthParagraph = new Paragraph();
    fourthParagraph.setText("Fourth level");
    fourthParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    fourthParagraph.getParagraphFormat().getBullet().setChar('-');
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    fourthParagraph.getParagraphFormat().setDepth((short) 3);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);
    textFrame.getParagraphs().add(fourthParagraph);

    presentation.save("multilevel_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Задание пользовательского начального значения для нумерованного списка**

Используйте [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) для указания начального номера нумерованного абзаца.

1. Создайте объект [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/) и добавьте [IAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape/) на слайд.
2. Очистите абзац по умолчанию из текстовой рамки фигуры.
3. Создайте три нумерованных абзаца.
4. Установите [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) в `2`, `3` и `7` для соответствующих абзацев.
5. Добавьте абзацы в текстовую рамку и сохраните презентацию.

Этот пример на Java задаёт пользовательский стартовый номер каждому абзацу:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("Start at 2");
    firstParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    firstParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 2);
    textFrame.getParagraphs().add(firstParagraph);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("Start at 3");
    secondParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    secondParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 3);
    textFrame.getParagraphs().add(secondParagraph);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("Start at 7");
    thirdParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    thirdParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 7);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("custom_numbered_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Управление разметкой абзаца и свойствами завершения**

### **Установка отступа первой строки**

Используйте [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraphformat/#setIndent-float-) для управления отступом первой строки абзаца. Этот метод смещает только первую строку относительно левого поля абзаца. Положительное значение сдвигает первую строку вправо, остальные строки остаются выровненными по телу абзаца.

Используйте [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-), когда нужно переместить весь абзац. Применяйте [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraphformat/#setIndent-float-), когда необходимо сместить только первую строку.

Пример ниже создаёт несколько абзацев и применяет разные значения [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraphformat/#setIndent-float-) для демонстрации влияния отступа первой строки на разметку абзаца.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/).
2. Получите целевой слайд.
3. Добавьте прямоугольную [IAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape/) на слайд.
4. Получите [ITextFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/) фигуры и удалите абзац по умолчанию.
5. Создайте несколько абзацев и задайте для них разные значения [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraphformat/#setIndent-float-).
6. Добавьте абзацы в текстовую рамку.
7. Сохраните изменённую презентацию.

Этот код показывает, как задать отступ абзаца:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setMarginLeft(20f);
    firstParagraph.getParagraphFormat().setIndent(0f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setMarginLeft(20f);
    secondParagraph.getParagraphFormat().setIndent(20f);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.getParagraphFormat().setMarginLeft(20f);
    thirdParagraph.getParagraphFormat().setIndent(40f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Отступ первой строки абзацев](first_line_indent.png)

### **Установка висячего отступа**

Висячий отступ — это разметка абзаца, при которой первая строка начинается левее остальных строк. В Aspose.Slides такой эффект создаётся с помощью [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraphformat/#setIndent-float-). Передайте отрицательное значение, чтобы переместить первую строку влево относительно тела абзаца.

На практике [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) задаёт левую позицию тела абзаца, а [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraphformat/#setIndent-float-) определяет позицию первой строки относительно этого поля. Чтобы создать висячий отступ, задайте положительное значение для `setMarginLeft` и отрицательное значение для `setIndent`.

Такое форматирование удобно для библиографий, ссылок, глоссариев и других абзацев, где строки‑переносы должны выравниваться под телом абзаца, а не под первым символом первой строки.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/).
2. Получите целевой слайд.
3. Добавьте прямоугольную [IAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape/) на слайд.
4. Получите [ITextFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/) фигуры и удалите абзац по умолчанию.
5. Создайте абзацы и задайте положительное значение [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) для каждого.
6. Передайте отрицательное значение [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraphformat/#setIndent-float-) для создания эффекта висячего отступа.
7. Добавьте абзацы в текстовую рамку.
8. Сохраните изменённую презентацию.

Этот код показывает, как задать висячий отступ для абзаца:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setMarginLeft(40f);
    firstParagraph.getParagraphFormat().setIndent(-20f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setMarginLeft(60f);
    secondParagraph.getParagraphFormat().setIndent(-30f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Висячий отступ абзацев](hanging_indent.png)

### **Установка свойств конца абзаца**

[IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) управляет форматированием символа конца абзаца. В следующем примере задаётся размер шрифта и латинский шрифт для конца второго абзаца:

1. Загрузите объект [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/) и получите слайд.
2. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape/) и очистите его абзац по умолчанию.
3. Создайте два абзаца и добавьте к ним текстовые фрагменты.
4. Создайте объект [PortionFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/portionformat/) для символа конца второго абзаца.
5. Установите [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) и [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-).
6. Примените формат с помощью [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) и сохраните презентацию.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getPortions().add(new Portion("Sample text"));

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getPortions().add(new Portion("Sample text 2"));

    PortionFormat endParagraphFormat = new PortionFormat();
    endParagraphFormat.setFontHeight(48);
    endParagraphFormat.setLatinFont(new FontData("Times New Roman"));
    secondParagraph.setEndParagraphPortionFormat(endParagraphFormat);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("end_paragraph_format.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Импорт и экспорт содержимого абзацев**

### **Импорт HTML‑текста в абзацы**

Используйте [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/ru/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) для преобразования HTML‑разметки в абзацы и фрагменты внутри текстовой рамки.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/).
2. Получите слайд и добавьте [IAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape/).
3. Получите [ITextFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/) фигуры и очистите абзац по умолчанию.
4. Считайте исходный HTML‑файл.
5. Передайте строку HTML в [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/ru/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-).
6. Сохраните изменённую презентацию.

Этот пример на Java импортирует HTML в текстовую рамку:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    float shapeWidth = (float) presentation.getSlideSize().getSize().getWidth() - 20;
    float shapeHeight = (float) presentation.getSlideSize().getSize().getHeight() - 20;
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().getParagraphs().clear();

    try {
        byte[] htmlBytes = Files.readAllBytes(Paths.get("file.html"));
        String html = new String(htmlBytes, StandardCharsets.UTF_8);
        shape.getTextFrame().getParagraphs().addFromHtml(html);
        presentation.save("html_text.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("The HTML file could not be read: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **Экспорт текста абзаца в HTML**

Используйте [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/ru/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) для экспорта выбранного диапазона абзацев в HTML.

1. Создайте объект [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/) и загрузите нужную презентацию.
2. Получите слайд и найдите [IAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape/), содержащий текст.
3. Получите [ITextFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/).
4. Вызовите [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/ru/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) с индексом начального абзаца и количеством абзацев для экспорта.
5. Запишите полученную строку HTML в файл.

Этот пример на Java экспортирует все абзацы из первой текстовой фигуры:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("ExportingHTMLText.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null) {
            IParagraphCollection paragraphs = textFrame.getParagraphs();
            String html = paragraphs.exportToHtml(0, paragraphs.getCount(), null);
            try {
                Files.write(Paths.get("paragraphs.html"), html.getBytes(StandardCharsets.UTF_8));
            } catch (IOException exception) {
                System.out.println("The HTML file could not be written: " + exception.getMessage());
            }
        } else {
            System.out.println("The first shape does not contain a text frame.");
        }
    } else {
        System.out.println("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

### **Отображение абзаца в виде изображения**

[IParagraph.getImage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraph/#getImage--) непосредственно рендерит отдельный абзац и возвращает объект [IImage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iimage/). Сохраните результат в файл или поток с помощью [IImage.save](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iimage/#save-java.lang.String-int-). Нет необходимости рендерить всю содержащую фигуру или вручную обрезать bitmap.

[IParagraph.getImage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraph/#getImage--) может вернуть `null`, если абзац не найден в родительской коллекции, не имеет корректных границ рендеринга или не может быть отрисован. Проверьте результат перед сохранением и освободите полученное изображение после использования.

#### **Рендеринг абзаца в масштабе по умолчанию**

Предположим, у нас есть файл презентации sample.pptx с одним слайдом, где первая фигура — текстовое поле, содержащее три абзаца.

![Текстовое поле с тремя абзацами](paragraph_to_image_input.png)

Следующий пример рендерит второй абзац в обычной текстовой фигуре в масштабе по умолчанию и сохраняет полученное изображение в формате PNG. Блок `finally` гарантирует корректное освобождение изображения.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null && textFrame.getParagraphs().getCount() > 1) {
            IParagraph paragraph = textFrame.getParagraphs().get_Item(1);
            IImage paragraphImage = paragraph.getImage();

            if (paragraphImage != null) {
                try {
                    paragraphImage.save("paragraph.png", ImageFormat.Png);
                } finally {
                    paragraphImage.dispose();
                }
            } else {
                System.out.println("The paragraph could not be rendered.");
            }
        } else {
            System.out.println("The expected paragraph was not found.");
        }
    } else {
        System.out.println("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

Результат:

![Изображение абзаца](paragraph_to_image_output.png)

#### **Рендеринг абзаца в ячейке таблицы с масштабированием**

Используйте перегруженный метод [IParagraph.getImage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraph/#getImage-float-float-), принимающий параметры `float scaleX` и `float scaleY` для задания горизонтального и вертикального коэффициентов масштабирования. Пример ниже создает таблицу, рендерит абзац в её первой ячейке с двойным масштабом по ширине и высоте и сохраняет результат как PNG‑изображение.

```java
import com.aspose.slides.*;

float scaleX = 2f;
float scaleY = 2f;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = slide.getShapes().addTable(50, 50, new double[] { 300 }, new double[] { 80 });
    IParagraph paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0);
    paragraph.setText("Text in a table cell");

    IImage paragraphImage = paragraph.getImage(scaleX, scaleY);
    if (paragraphImage != null) {
        try {
            paragraphImage.save("table_paragraph.png", ImageFormat.Png);
        } finally {
            paragraphImage.dispose();
        }
    } else {
        System.out.println("The paragraph could not be rendered.");
    }
} finally {
    presentation.dispose();
}
```

Коэффициент масштаба `1` сохраняет размер оси в пикселях по умолчанию. Например, `2` для обеих осей даёт изображение, ширина и высота которого примерно в два раза больше исходных, а количество пикселей увеличивается в четыре раза. Более крупные коэффициенты обычно обеспечивают более чёткий текст при увеличении или выводе в высоком разрешении, но также увеличивают потребление памяти и размер файла. Коэффициенты меньше `1` дают меньшие изображения с меньшей детализацией. Используйте одинаковые коэффициенты, чтобы сохранить пропорции абзаца; разные горизонтальный и вертикальный коэффициенты растягивают вывод независимо.

Рендеринг всей фигуры с помощью [IShape.getImage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishape/#getImage--) остаётся полезным, когда требуется включить заливку, границу или иной визуальный контекст фигуры. Для изображения только абзаца используйте [IParagraph.getImage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraph/#getImage--).

## **FAQ**

**Можно ли полностью отключить перенос строк внутри текстовой рамки?**

Да. Установите [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) для отключения переноса, чтобы строки не разрывались у краёв рамки.

**Как получить точные границы конкретного абзаца на слайде?**

Вызовите [IParagraph.getRect](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraph/#getRect--) для получения ограничивающего прямоугольника абзаца. [IPortion.getRect](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iportion/#getRect--) возвращает границы отдельного фрагмента.

**Где управляется выравнивание абзаца (по левому, правому краю, по центру или по ширине)?**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) — настройка уровня абзаца, применяющаяся ко всему абзацу независимо от форматирования отдельных фрагментов.

**Можно ли задать язык проверки орфографии для части абзаца?**

Да. Установите [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) для отдельных фрагментов, чтобы один абзац мог содержать текст на нескольких языках.