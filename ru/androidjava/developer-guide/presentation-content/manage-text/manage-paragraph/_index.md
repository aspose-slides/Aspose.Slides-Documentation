---
title: Управление абзацами текста PowerPoint на Android
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
- импортировать HTML
- текст в HTML
- абзац в HTML
- абзац в изображение
- текст в изображение
- экспортировать абзац
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Узнайте, как создавать и форматировать абзацы, фрагменты, маркеры, нумерованные списки, отступы, HTML‑контент и изображения абзацев с помощью Aspose.Slides для Android через Java."
---
## **Обзор**

Aspose.Slides для Android через Java представляет текст как иерархию текстовых рамок, абзацев и фрагментов:

* [ITextFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/) представляет контейнер текста в фигуре и предоставляет доступ к её коллекции абзацев.
* [IParagraph](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraph/) представляет один абзац в текстовой рамке и предоставляет доступ к его фрагментам и форматированию уровня абзаца.
* [IPortion](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iportion/) представляет текстовый фрагмент внутри абзаца. Каждый фрагмент может иметь собственный текст и форматирование на уровне символов.

Таким образом, в абзаце может быть текст с разными шрифтами, цветами, размерами и другим форматированием, используя несколько фрагментов.

## **Создание и форматирование абзацев**

### **Создание абзацев с несколькими фрагментами**

Следующие шаги создают текстовую рамку с тремя абзацами, каждый из которых содержит три фрагмента:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/).
2. Получите доступ к нужному слайду по его индексу.
3. Добавьте прямоугольный [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/) к слайду.
4. Получите доступ к [ITextFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/) формы.
5. Используйте абзац по умолчанию и добавьте еще два объекта [IParagraph](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraph/) в текстовую рамку.
6. Добавьте достаточное количество объектов [IPortion](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iportion/) , чтобы каждый абзац содержал три фрагмента. Абзац по умолчанию уже содержит один пустой фрагмент.
7. Установите текст для каждого фрагмента.
8. Примените форматирование на уровне символов через [IPortion.getPortionFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iportion/#getPortionFormat--).
9. Сохраните изменённую презентацию.

Этот пример для Android через Java реализует перечисленные шаги:

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

Маркировка и нумерация упрощают просмотр связанных элементов. В Aspose.Slides параметры списка определяются через [IBulletFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibulletformat/).

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/).
2. Получите доступ к нужному слайду по его индексу.
3. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/) к выбранному слайду.
4. Получите доступ к [ITextFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/) формы.
5. Удалите абзац по умолчанию из текстовой рамки.
6. Создайте объект [Paragraph](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/paragraph/) для символного маркера.
7. Установите [IBulletFormat.setType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibulletformat/#setType-int-) в значение [BulletType.Symbol](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/bullettype/) и задайте символ маркера.
8. Задайте текст абзаца, отступ, цвет маркера и высоту маркера.
9. Добавьте абзац в текстовую рамку.
10. Создайте второй абзац и установите [IBulletFormat.setType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibulletformat/#setType-int-) в значение [BulletType.Numbered](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/bullettype/).
11. Настройте стиль нумерованного маркера и добавьте абзац в текстовую рамку.
12. Сохраните презентацию.

Этот пример для Android через Java создаёт символный маркер и нумерованный маркер:

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

### **Использование графических маркеров**

Графические маркеры позволяют использовать собственное изображение вместо символа или числа.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/).
2. Получите доступ к нужному слайду по его индексу.
3. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/) и получите доступ к его [ITextFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/).
4. Удалите абзац по умолчанию из текстовой рамки.
5. Загрузите изображение маркера и добавьте его в коллекцию изображений презентации как объект [IPPImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ippimage/).
6. Создайте объект [Paragraph](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/paragraph/) и задайте его текст.
7. Установите [IBulletFormat.setType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibulletformat/#setType-int-) в значение [BulletType.Picture](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/bullettype/).
8. Назначьте изображение через [IBulletFormat.getPicture](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibulletformat/#getPicture--) и задайте высоту маркера.
9. Добавьте абзац в текстовую рамку.
10. Сохраните изменённую презентацию.

Этот пример для Android через Java создаёт графический маркер:

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

Установите [IParagraphFormat.setDepth](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) , чтобы разместить абзацы на разных уровнях списка. Верхний уровень имеет глубину `0`.

1. Создайте объект [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/) и получите доступ к слайду.
2. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/) и очистите абзац по умолчанию из его текстовой рамки.
3. Создайте четыре абзаца и настройте их символы маркеров.
4. Установите их значения [IParagraphFormat.setDepth](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) в `0`, `1`, `2` и `3`.
5. Добавьте абзацы в текстовую рамку и сохраните презентацию.

Этот пример для Android через Java создаёт четырехуровневый маркированный список:

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

### **Указание пользовательского начального номера для элементов нумерованного списка**

Используйте [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) , чтобы задать начальный номер, отображаемый для нумерованного абзаца.

1. Создайте объект [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/) и добавьте [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/) к слайду.
2. Очистите абзац по умолчанию из текстовой рамки формы.
3. Создайте три нумерованных абзаца.
4. Установите [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) в `2`, `3` и `7` для соответствующих абзацев.
5. Добавьте абзацы в текстовую рамку и сохраните презентацию.

Этот пример для Android через Java присваивает каждому абзацу пользовательский начальный номер:

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

## **Управление расположением абзацев и их конечными свойствами**

### **Установка отступа первой строки**

Используйте [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) для управления отступом первой строки абзаца. Этот метод перемещает только первую строку относительно левого поля абзаца. Положительное значение сдвигает первую строку вправо, остальные строки остаются выровненными по телу абзаца.

Используйте [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-), когда необходимо переместить весь абзац. Используйте [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-), когда нужно переместить только первую строку.

В примере ниже создаются несколько абзацев и задаются разные значения [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) , чтобы продемонстрировать, как отступ первой строки влияет на расположение абзаца.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/).
2. Получите доступ к целевому слайду.
3. Добавьте прямоугольный [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/) к слайду.
4. Получите доступ к [ITextFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/) формы и удалите абзац по умолчанию.
5. Создайте несколько абзацев и задайте им разные значения [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-).
6. Добавьте абзацы в текстовую рамку.
7. Сохраните изменённую презентацию.

Этот код показывает, как задать отступ абзаца:

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
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().setFillType(FillType.Solid);
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

Висячий отступ — это расположение абзаца, при котором первая строка начинается левее остальных строк. В Aspose.Slides вы создаете этот эффект с помощью [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-). Передайте отрицательное значение, чтобы переместить первую строку влево относительно тела абзаца.

На практике [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) задаёт левую позицию тела абзаца, а [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) задаёт позицию первой строки относительно этого поля. Чтобы создать висячий отступ, задайте положительное значение для `setMarginLeft` и отрицательное значение для `setIndent`.

Это форматирование полезно для библиографий, ссылок, глоссариев и других абзацев, где строки должны выравниваться под телом абзаца, а не под первым символом первой строки.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/).
2. Получите доступ к целевому слайду.
3. Добавьте прямоугольный [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/) к слайду.
4. Получите доступ к [ITextFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/) формы и удалите абзац по умолчанию.
5. Создайте абзацы и задайте положительное значение [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) для каждого абзаца.
6. Задайте отрицательное значение [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) для создания эффекта висячего отступа.
7. Добавьте абзацы в текстовую рамку.
8. Сохраните изменённую презентацию.

Этот код показывает, как задать висячий отступ для абзаца:

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

[IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) управляет форматированием маркера конца абзаца. В следующем примере задаются размер шрифта и латинский шрифт для маркера конца второго абзаца:

1. Загрузите объект [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/) и получите доступ к слайду.
2. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/) и очистите его абзац по умолчанию.
3. Создайте два абзаца и добавьте к ним текстовые фрагменты.
4. Создайте объект [PortionFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/portionformat/) для маркера конца второго абзаца.
5. Установите [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) и [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-).
6. Примените формат с помощью [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) и сохраните презентацию.

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

Используйте [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) для преобразования разметки HTML в абзацы и фрагменты в текстовой рамке.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/).
2. Получите доступ к слайду и добавьте [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/).
3. Получите доступ к [ITextFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/) формы и очистите абзац по умолчанию.
4. Прочитайте исходный HTML‑файл.
5. Передайте строку HTML в [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-).
6. Сохраните изменённую презентацию.

Этот пример для Android через Java импортирует HTML в текстовую рамку:

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

Используйте [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) для экспорта выбранного диапазона абзацев в формате HTML.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/) и загрузите нужную презентацию.
2. Получите доступ к слайду и найдите [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/), содержащий текст.
3. Получите доступ к [ITextFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/).
4. Вызовите [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) с индексом начального абзаца и количеством экспортируемых абзацев.
5. Запишите полученную строку HTML в файл.

Этот пример для Android через Java экспортирует все абзацы из первой текстовой фигуры:

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

[IParagraph.getImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraph/#getImage--) рендерит отдельный абзац напрямую и возвращает объект [IImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimage/). Сохраните результат в файл или поток с помощью [IImage.save](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-). Не требуется рендерить содержащую форму или вручную обрезать bitmap.

[IParagraph.getImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraph/#getImage--) может вернуть `null`, если абзац не найден в родительской коллекции, не имеет допустимых границ рендеринга или не может быть отрендерен. Проверьте результат перед сохранением и затем освободите полученное изображение.

#### **Отображение абзаца в масштабе по умолчанию**

Предположим, что у нас есть файл презентации `sample.pptx` с одним слайдом, где первая фигура — это текстовое поле, содержащее три абзаца.

![Текстовое поле с тремя абзацами](paragraph_to_image_input.png)

В следующем примере рендерится второй абзац в обычной текстовой фигуре в масштабе по умолчанию и сохраняется полученное изображение в формате PNG. Блок `finally` гарантирует корректное освобождение изображения.

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

Используйте перегрузку [IParagraph.getImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraph/#getImage-float-float-) , принимающую параметры `float scaleX` и `float scaleY` для задания горизонтального и вертикального коэффициентов масштабирования. В примере создаётся таблица, рендерится абзац в её первой ячейке с двойной шириной и высотой по умолчанию, затем результат сохраняется как PNG‑изображение.

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

Коэффициент масштабирования `1` сохраняет размер оси по умолчанию. Например, `2` для обеих осей приводит к изображению, ширина и высота которого примерно вдвое больше стандартных, что дает в четыре раза больше пикселей. Большие коэффициенты обычно дают более чёткий текст для увеличения или вывода в высоком разрешении, но увеличивают расход памяти и размер файла. Коэффициенты ниже `1` дают меньшие изображения с меньшей детализацией. Используйте одинаковые коэффициенты, чтобы сохранить пропорции абзаца; разные горизонтальный и вертикальный коэффициенты растягивают вывод независимо.

Рендеринг всей формы с помощью [IShape.getImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/#getImage--) остаётся полезным, когда необходимо включить заполнение, границу или другой визуальный контекст формы. Для получения изображения только абзаца используйте [IParagraph.getImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraph/#getImage--).

## **FAQ**

**Могу ли я полностью отключить перенос строк внутри текстовой рамки?**

Да. Установите [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) , чтобы отключить перенос, и строки не будут разрываться у краёв текстовой рамки.

**Как получить точные границы конкретного абзаца на слайде?**

Используйте [IParagraph.getRect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraph/#getRect--) для получения ограничивающего прямоугольника абзаца. [IPortion.getRect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iportion/#getRect--) предоставляет границы отдельного фрагмента.

**Где управляется выравнивание абзаца (по левому, правому краю, по центру или по ширине)?**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) — это параметр уровня абзаца и применяется ко всему абзацу независимо от форматирования отдельных фрагментов.

**Могу ли я задать язык проверки правописания для части абзаца?**

Да. Установите [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) для отдельных фрагментов, чтобы один абзац мог содержать текст на нескольких языках.