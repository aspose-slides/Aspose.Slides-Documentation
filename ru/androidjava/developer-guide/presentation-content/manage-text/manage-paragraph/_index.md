---
title: Управление текстовыми абзацами PowerPoint на Android
linktitle: Управление абзацем
type: docs
weight: 40
url: /ru/androidjava/manage-paragraph/
aliases:
  - /androidjava/paragraph/
  - /androidjava/portion/
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
- экспортировать абзац
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Узнайте, как создавать и форматировать абзацы, части, маркеры, нумерованные списки, отступы, HTML‑содержимое и изображения абзацев с помощью Aspose.Slides для Android через Java."
---
## **Обзор**

Aspose.Slides for Android via Java представляет текст как иерархию текстовых фреймов, абзацев и частей:

* [ITextFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/) представляет контейнер текста в фигуре и предоставляет доступ к её коллекции абзацев.
* [IParagraph](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraph/) представляет один абзац в текстовом фрейме и предоставляет доступ к его частям и форматированию уровня абзаца.
* [IPortion](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iportion/) представляет текстовый фрагмент внутри абзаца. Каждая часть может иметь собственный текст и форматирование уровня символов.

Таким образом, абзац может содержать текст с разными шрифтами, цветами, размерами и другим форматированием, используя несколько частей.

## **Создание и форматирование абзацев**

### **Создание абзацев с несколькими частями**

Следующие шаги создают текстовый фрейм с тремя абзацами, каждый из которых содержит три части:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/).
2. Получите нужный слайд по его индексу.
3. Добавьте прямоугольную [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/) на слайд.
4. Получите [ITextFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/) фигуры.
5. Используйте абзац по умолчанию и добавьте два дополнительных [IParagraph](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraph/) в текстовый фрейм.
6. Добавьте достаточное количество объектов [IPortion](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iportion/) для каждого абзаца, чтобы они содержали по три части. Абзац по умолчанию уже содержит одну пустую часть.
7. Установите текст каждой части.
8. Примените форматирование уровня символов через [IPortion.getPortionFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iportion/#getPortionFormat--).
9. Сохраните изменённую презентацию.

Этот пример Android via Java реализует указанные шаги:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Маркеры и нумерация упрощают восприятие связанных элементов. В Aspose.Slides настройки списка определяются через [IBulletFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibulletformat/).

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/).
2. Получите нужный слайд по его индексу.
3. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/) на выбранный слайд.
4. Получите [ITextFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/) фигуры.
5. Удалите абзац по умолчанию из текстового фрейма.
6. Создайте [Paragraph](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/paragraph/) для символического маркера.
7. Установите [IBulletFormat.setType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibulletformat/#setType-int-) в значение [BulletType.Symbol](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/bullettype/) и задайте символ маркера.
8. Задайте текст абзаца, отступ, цвет маркера и высоту маркера.
9. Добавьте абзац в текстовый фрейм.
10. Создайте второй абзац и установите [IBulletFormat.setType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibulletformat/#setType-int-) в значение [BulletType.Numbered](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/bullettype/).
11. Настройте стиль нумерованного маркера и добавьте абзац в текстовый фрейм.
12. Сохраните презентацию.

Этот пример Android via Java создаёт символический и нумерованный маркеры:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

### **Использование изображений в качестве маркеров**

Изображения‑маркеры позволяют использовать собственную картинку вместо символа или числа.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/).
2. Получите нужный слайд по его индексу.
3. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/) и получите его [ITextFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/).
4. Удалите абзац по умолчанию из текстового фрейма.
5. Загрузите изображение маркера и добавьте его в коллекцию изображений презентации как [IPPImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ippimage/).
6. Создайте [Paragraph](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/paragraph/) и задайте его текст.
7. Установите [IBulletFormat.setType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibulletformat/#setType-int-) в значение [BulletType.Picture](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/bullettype/).
8. Присвойте изображение через [IBulletFormat.getPicture](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibulletformat/#getPicture--) и задайте высоту маркера.
9. Добавьте абзац в текстовый фрейм.
10. Сохраните изменённую презентацию.

Этот пример Android via Java создаёт изображение‑маркер:

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

Установите [IParagraphFormat.setDepth](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) для размещения абзацев на разных уровнях списка. Верхний уровень имеет глубину `0`.

1. Создайте [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/) и получите слайд.
2. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/) и очистите абзац по умолчанию в его текстовом фрейме.
3. Создайте четыре абзаца и настройте их символы маркеров.
4. Установите их значения [IParagraphFormat.setDepth](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) в `0`, `1`, `2` и `3`.
5. Добавьте абзацы в текстовый фрейм и сохраните презентацию.

Этот пример Android via Java создаёт четырёхуровневый маркированный список:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

### **Начало нумерованных элементов списка с пользовательских значений**

Используйте [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) для задания начального номера, отображаемого для нумерованного абзаца.

1. Создайте [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/) и добавьте [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/) на слайд.
2. Очистите абзац по умолчанию в текстовом фрейме фигуры.
3. Создайте три нумерованных абзаца.
4. Установите [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) в `2`, `3` и `7` для соответствующих абзацев.
5. Добавьте абзацы в текстовый фрейм и сохраните презентацию.

Этот пример Android via Java задаёт пользовательские начальные номера для каждого абзаца:

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

## **Управление макетом абзаца и свойствами окончания**

### **Установка отступа первой строки**

Используйте [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) для управления отступом первой строки абзаца. Этот метод смещает только первую строку относительно левого поля абзаца. Положительное значение сдвигает первую строку вправо, в то время как остальные строки остаются выровненными по телу абзаца.

Используйте [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) когда нужно переместить весь абзац. Используйте [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) когда нужно сместить только первую строку.

Ниже пример, создающий несколько абзацев и применяющий разные значения [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) для демонстрации влияния отступа первой строки на макет абзаца.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/).
2. Получите целевой слайд.
3. Добавьте прямоугольную [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/) на слайд.
4. Получите [ITextFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/) фигуры и удалите абзац по умолчанию.
5. Создайте несколько абзацев и задайте им разные значения [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-).
6. Добавьте абзацы в текстовый фрейм.
7. Сохраните изменённую презентацию.

Этот код показывает, как установить отступ абзаца:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Висячий отступ — это макет абзаца, при котором первая строка начинается левее остальных строк. В Aspose.Slides такой эффект создаётся с помощью [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-). Передайте отрицательное значение, чтобы сместить первую строку влево относительно тела абзаца.

На практике [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) определяет левую позицию тела абзаца, а [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) — позицию первой строки относительно этого поля. Чтобы создать висячий отступ, передайте положительное значение в `setMarginLeft` и отрицательное — в `setIndent`.

Это форматирование полезно для библиографий, ссылок, глоссариев и других абзацев, где перенесённые строки должны выравниваться под телом абзаца, а не под первым символом первой строки.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/).
2. Получите целевой слайд.
3. Добавьте прямоугольную [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/) на слайд.
4. Получите [ITextFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/) фигуры и удалите абзац по умолчанию.
5. Создайте абзацы и для каждого задайте положительное значение [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-).
6. Задайте отрицательное значение [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) для создания эффекта висячего отступа.
7. Добавьте абзацы в текстовый фрейм.
8. Сохраните изменённую презентацию.

Этот код показывает, как установить висячий отступ для абзаца:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

### **Установка свойств конечного фрагмента абзаца**

[IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) управляет форматированием конечного знака абзаца. В следующем примере задаётся размер шрифта и латинский шрифт для конечного знака второго абзаца:

1. Загрузите [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/) и получите слайд.
2. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/) и очистите его абзац по умолчанию.
3. Создайте два абзаца и добавьте к ним текстовые части.
4. Создайте [PortionFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/portionformat/) для конечного знака второго абзаца.
5. Установите [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) и [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-).
6. Примените формат через [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) и сохраните презентацию.

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

## **Подсчёт отображённых строк**

Для правил абзаца, влияющих на автоматический перенос и пунктуацию в конце строк, см. [Control Line Breaking](/slides/ru/androidjava/text-formatting/#control-line-breaking) и [Control Hanging Punctuation](/slides/ru/androidjava/text-formatting/#control-hanging-punctuation).

Используйте [IParagraph.getLinesCount](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraph/#getLinesCount--) для подсчёта строк, занимаемых абзацем после расположения текста, включая автоматический перенос. Это полезно при проверке длины текста и макета в шаблонах презентаций.

Абзац является элементом в [ITextFrame.getParagraphs](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/#getParagraphs--), и может занимать несколько отображённых строк. Явный разрыв строки внутри абзаца принудительно создаёт новую строку без создания нового абзаца. Автоматический перенос формирует строки на основе доступной ширины без вставки явных разрывов в текст. Поэтому подсчёт абзацев или символов разрыва строки не даёт количества отображённых строк.

Следующий пример создаёт текстовую фигуру, подсчитывает её строки, сужает фигуру, а затем заменяет текст более короткой строкой. Перенос включён, автоподгонка отключена, так что ширина фигуры управляет переносом без автоматического уменьшения текста или изменения размера фигуры. Размеры фигур указаны в пунктах. Затем пример добавляет ещё один абзац и суммирует количество строк во всём текстовом фрейме.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    paragraph.setText("This text demonstrates how automatic wrapping changes the number of rendered lines.");
    System.out.println("Original width: " + paragraph.getLinesCount());

    shape.setWidth(150);
    System.out.println("Narrower shape: " + paragraph.getLinesCount());

    paragraph.setText("Short text.");
    System.out.println("Shorter text: " + paragraph.getLinesCount());

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("Another paragraph.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    textFrame.getParagraphs().add(secondParagraph);

    int totalLineCount = 0;
    for (IParagraph currentParagraph : textFrame.getParagraphs()) {
        totalLineCount += currentParagraph.getLinesCount();
    }
    System.out.println("Total lines in the text frame: " + totalLineCount);
} finally {
    presentation.dispose();
}
```

При данном тексте и этих размерах сужение фигуры увеличивает количество строк, а замена текста короткой строкой уменьшает его. Точные цифры могут варьироваться в зависимости от доступных шрифтов и их подстановки, размера шрифта, полей, отступов, переноса и настроек автоподгонки. Используйте шрифты и параметры макета, предназначенные для целевой среды, при проверке шаблона.

Только количество строк не определяет, выходит ли текст за пределы контейнера. Важны доступная высота, высота строк, интервалы между абзацами и строками, а также поведение автоподгонки; даже одна строка может превышать доступную ширину, если перенос отключён.

## **Импорт и экспорт содержимого абзаца**

### **Импорт HTML‑текста в абзацы**

Используйте [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) для преобразования HTML‑разметки в абзацы и части внутри текстового фрейма.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/).
2. Получите слайд и добавьте [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/).
3. Получите [ITextFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/) фигуры и очистите её абзац по умолчанию.
4. Прочитайте исходный HTML‑файл.
5. Передайте строку HTML в [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-).
6. Сохраните изменённую презентацию.

Этот пример Android via Java импортирует HTML в текстовый фрейм:

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

Используйте [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) для экспорта выбранного диапазона абзацев в HTML.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/) и загрузите нужную презентацию.
2. Получите слайд и найдите [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/) с нужным текстом.
3. Получите [ITextFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/) фигуры.
4. Вызовите [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) с индексом начального абзаца и количеством экспортируемых абзацев.
5. Запишите полученную строку HTML в файл.

Этот пример Android via Java экспортирует все абзацы из первой текстовой фигуры:

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

### **Отображение абзаца как изображения**

[IParagraph.getImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraph/#getImage--) напрямую рендерит отдельный абзац и возвращает [IImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimage/). Сохраните результат в файл или поток с помощью [IImage.save](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-). Не требуется рендерить содержащую фигуру или вручную обрезать bitmap.

[IParagraph.getImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraph/#getImage--) может вернуть `null`, если абзац не найден в родительской коллекции, не имеет корректных границ рендеринга или не может быть отрисован. Проверьте результат перед сохранением и освободите полученное изображение после использования.

#### **Отображение абзаца в масштабе по умолчанию**

Предположим, у нас есть файл презентации `sample.pptx` с одним слайдом, где первая фигура — текстовый блок, содержащий три абзаца.

![Текстовый блок с тремя абзацами](paragraph_to_image_input.png)

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

#### **Отображение абзаца в ячейке таблицы с масштабированием**

Используйте перегрузку [IParagraph.getImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraph/#getImage-float-float-) с параметрами `float scaleX` и `float scaleY` для задания горизонтального и вертикального коэффициентов масштабирования. В следующем примере создаётся таблица, абзац в её первой ячейке рендерится с двойной шириной и высотой по сравнению со значением по умолчанию, и результат сохраняется как PNG‑изображение.

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

Коэффициент масштабирования `1` сохраняет размер по умолчанию для соответствующей оси. Например, `2` для обеих осей даёт изображение, ширина и высота которого примерно вдвое больше исходных размеров, что приводит к четырём раз большим количествам пикселей. Большие коэффициенты обычно дают более чёткий текст для масштабирования или вывода в высоком разрешении, но также увеличивают расход памяти и размер файла. Коэффициенты ниже `1` дают более мелкие изображения с меньшей детализацией. Используйте одинаковые коэффициенты, чтобы сохранить пропорции абзаца; разные горизонтальный и вертикальный коэффициенты растягивают изображение независимо.

Рендеринг полной фигуры с помощью [IShape.getImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/#getImage--) остаётся полезным, когда вывод должен включать заливку, контур или другой визуальный контекст фигуры. Для изображения только абзаца используйте [IParagraph.getImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraph/#getImage--).

## **Часто задаваемые вопросы**

**Можно ли полностью отключить перенос строк внутри текстовой рамки?**

Да. Установите [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) для отключения переноса, чтобы строки не разбивались у краёв текстового фрейма.

**Как получить точные границы конкретного абзаца на слайде?**

Используйте [IParagraph.getRect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraph/#getRect--) для получения ограничивающего прямоугольника абзаца. [IPortion.getRect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iportion/#getRect--) предоставляет границы отдельной части.

**Где управляется выравнивание абзаца (по левому, правому краю, по центру или по ширине)?**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) — это настройка уровня абзаца и применяется ко всему абзацу независимо от форматирования отдельных частей.

**Можно ли задать язык проверки орфографии для части абзаца?**

Да. Установите [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) для отдельных частей, чтобы один абзац мог содержать текст на нескольких языках.