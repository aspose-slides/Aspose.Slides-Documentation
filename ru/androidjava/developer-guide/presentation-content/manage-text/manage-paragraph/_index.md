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
description: "Узнайте, как создавать и форматировать абзацы, фрагменты, маркеры, нумерованные списки, отступы, HTML-контент и изображения абзацев с помощью Aspose.Slides для Android via Java."
---
## **Обзор**

Aspose.Slides for Android via Java представляет текст в виде иерархии текстовых фреймов, абзацев и фрагментов:

* [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) представляет контейнер текста в фигуре и предоставляет доступ к её коллекции абзацев.
* [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/) представляет один абзац в текстовом фрейме и предоставляет доступ к его фрагментам и форматированию уровня абзаца.
* [IPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/) представляет фрагмент текста внутри абзаца. Каждый фрагмент может иметь собственный текст и форматирование уровня символов.

Таким образом, абзац может содержать текст с разными шрифтами, цветами, размерами и другим форматированием, используя несколько фрагментов.

## **Создание и форматирование абзацев**

Создавайте абзацы в текстовом фрейме фигуры и используйте фрагменты для форматирования отдельных участков текста. В этом разделе показано, как объединять несколько фрагментов в каждом абзаце и применять разные цвета, размеры шрифта и стили.

### **Создание абзацев с несколькими фрагментами**

Следующий пример Android via Java создает три абзаца, каждый из которых содержит три текстовых фрагмента в коллекции, возвращаемой [IParagraph.getPortions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getPortions--). Он переиспользует абзац по умолчанию и его пустой фрагмент, затем добавляет остальные абзацы и фрагменты. Форматирование применяется через [IPortion.getPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/#getPortionFormat--): первый фрагмент в каждом абзаце красный, полужирный и 15 пунктов; второй — синий, курсив и 18 пунктов. Третий фрагмент сохраняет форматирование по умолчанию:

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

Организуйте текст абзаца в списки с символами, цифрами или пользовательскими изображениями. Примеры в этом разделе охватывают форматирование маркеров, многоуровневые списки и пользовательские начальные номера.

### **Создание маркированного или нумерованного списка**

Маркировка и нумерация упрощают восприятие связанных элементов. В Aspose.Slides параметры списка задаются через [IBulletFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/).

Этот пример Android via Java добавляет символный маркер и нумерованный элемент в один текстовый фрейм. [IBulletFormat.setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) выбирает тип маркера, а [IBulletFormat.setChar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setChar-char-) задает символ и [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) выбирает стиль нумерации. Оба элемента используют черные маркеры высотой 100 % и отступ абзаца 25 пунктов:

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

Изображения‑маркеры позволяют использовать пользовательское изображение вместо символа или числа.

Этот пример Android via Java добавляет изображение в коллекцию изображений презентации как [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) и использует его в качестве маркера абзаца. Он вызывает [IBulletFormat.setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) для использования изображения‑маркера и назначает изображение через [IBulletFormat.getPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#getPicture--). [IBulletFormat.setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setHeight-float-) устанавливается в 100 % для масштабирования маркера относительно текста абзаца:

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

Установите [IParagraphFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) для размещения абзацев на разных уровнях списка. Верхний уровень имеет глубину `0`.

Этот пример Android via Java задаёт значения [IParagraphFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) от 0 до 3 для четырёх абзацев, создавая иерархию внутри одного текстового фрейма. Каждый абзац использует символный маркер, при этом [IBulletFormat.setChar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setChar-char-) чередуется между круглым маркером и дефисом для различения соседних уровней:

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

### **Установка пользовательских начальных значений нумерованных пунктов**

Используйте [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) для задания начального номера, отображаемого для нумерованного абзаца.

Этот пример Android via Java устанавливает [IBulletFormat.setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) для использования нумерации в трёх абзацах и задаёт значения [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) 2, 3 и 7. Начальное значение задаётся отдельно для каждого абзаца, позволяя пропускать номера:

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

## **Управление расположением абзаца и свойствами окончания**

Регулируйте отступы абзаца и поля, чтобы контролировать позицию первой строки и строк переноса. Вы также можете форматировать знак завершения абзаца отдельно от видимых текстовых фрагментов.

### **Установка отступа первой строки**

Используйте метод [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) для управления отступом первой строки абзаца. Эта настройка смещает только первую строку относительно левого поля абзаца. Положительное значение сдвигает первую строку вправо, в то время как остальные строки остаются выровненными по телу абзаца.

Используйте [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) когда нужно переместить весь абзац. Используйте [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) когда нужно переместить только первую строку.

Следующий пример задаёт трём абзацам одинаковый [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) = 20 пунктов и значения [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) = 0, 20 и 40 пунктов. Первые строки начинают с постепенно увеличивающихся смещений, в то время как строки переноса сохраняют одинаковое левое поле:

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

Висячий отступ — это расположение абзаца, при котором первая строка начинается левее остальных строк. В Aspose.Slides это достигается с помощью свойства [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-). Установите `Indent` в отрицательное значение, чтобы переместить первую строку влево относительно тела абзаца.

На практике [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) определяет левую позицию тела абзаца, а [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) — позицию первой строки относительно этого поля. Чтобы создать висячий отступ, задайте положительное значение `MarginLeft` и отрицательное значение `Indent`.

Такое форматирование полезно для библиографий, ссылок, глоссариев и других абзацев, где строки переноса должны выравниваться под телом абзаца, а не под первой буквой первой строки.

Следующий пример Android via Java сочетает значения [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) = 40 и 60 пунктов с [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) = -20 и -30 пунктов. В каждом абзаце первая строка начинается левее строк переноса; во втором абзаце висячий отступ глубже:

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

Метод [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) управляет форматированием знака окончания абзаца. В следующем примере создаётся объект [PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portionformat/) с [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) = 48 пунктов и [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-) = Times New Roman. Этот формат присваивается знаку окончания второго абзаца, не изменяя видимые текстовые фрагменты:

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

## **Подсчёт отрисованных строк**

Для правил абзаца, влияющих на автоматический перенос и пунктуацию в конце строк, см. [Control Line Breaking](/slides/ru/androidjava/text-formatting/#control-line-breaking) и [Control Hanging Punctuation](/slides/ru/androidjava/text-formatting/#control-hanging-punctuation).

Используйте [IParagraph.getLinesCount](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getLinesCount--) для подсчёта строк, занятых абзацем после размещения текста, включая автоматический перенос. Это полезно при проверке длины текста и макета в шаблонах презентаций.

Абзац — это один элемент в [ITextFrame.getParagraphs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParagraphs--), и он может занимать несколько отрисованных строк. Явный разрыв строки внутри абзаца принудительно создаёт новую строку без создания нового абзаца. Автоматический перенос образует строки на основе доступной ширины без вставки явных разрывов в текст. Поэтому подсчёт абзацев или символов разрыва не даёт количества отрисованных строк.

Следующий пример создаёт текстовую фигуру, подсчитывает её строки, сужает фигуру, а затем заменяет текст более короткой строкой. Пример включает перенос, включив [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-), и отключив автоподгонку, используя [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-), чтобы ширина фигуры контролировала перенос без автоматического сжатия текста или изменения размеров фигуры. Каждый измерение использует [IParagraph.getLinesCount](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getLinesCount--). Размеры фигуры указаны в пунктах. В конце пример добавляет ещё один абзац и суммирует количество строк по всему текстовому фрейму.

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

При данном тексте и этих размерах сужение фигуры увеличивает количество строк, а замена текста короткой строкой уменьшает его. Точные значения могут различаться в зависимости от доступных шрифтов и их подстановки, размера шрифта, полей, отступов, переноса и настроек автоподгонки. Используйте шрифты и параметры макета, предназначенные для целевой среды, при проверке шаблона.

Одно лишь количество строк не определяет, переполняет ли текст контейнер. Важны доступная высота, высота строк, межстрочный и абзацный интервалы, а также поведение автоподгонки; даже одна строка может выйти за пределы ширины, если перенос отключён.

## **Импорт и экспорт содержимого абзацев**

Используйте HTML для импорта текста в презентацию или экспорта существующих абзацев для внешнего использования. Этот раздел также показывает, как рендерить отдельные абзацы как изображения, включая абзацы в ячейках таблиц.

### **Импорт HTML‑текста в абзацы**

Используйте [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) для преобразования HTML‑разметки в абзацы и фрагменты в текстовом фрейме.

Этот пример Android via Java читает HTML из файла и передаёт разметку в [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-). Он очищает абзац по умолчанию в текстовом фрейме, чтобы фрейм содержал только импортированный контент. Прямоугольная фигура оставляет отступ 10 пунктов со всех сторон слайда:

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

### **Экспорт текста абзацев в HTML**

Используйте [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) для экспорта выбранного диапазона абзацев в HTML. При повторном использовании текста презентации на веб‑сайте вы можете захотеть сохранить локальное выделение без переноса шрифта, размера или стилей текстового поля презентации. Установите [TextToHtmlConversionOptions.setTextInheritanceLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/texttohtmlconversionoptions/#setTextInheritanceLimit-int-) для управления глубиной наследования форматирования при экспорте.

Скачайте [пример презентации](text-inheritance.pptx) и разместите её в рабочем каталоге приложения. На первом слайде она содержит одну текстовую фигуру с текстом «Inherited text; explicit red 18pt». Входной файл намеренно использует несколько уровней форматирования:

- Стиль текста по умолчанию презентации задаёт Calibri размером 28 pt.
- Стиль первого уровня текстового фрейма задаёт синий цвет и курсив.
- Абзац явно задаёт полужирный шрифт.
- Второй фрагмент «explicit red 18pt» явно задаёт красный цвет и размер 18 pt.

Следующий полный пример экспортирует те же абзацы трижды. Он передаёт [TextToHtmlConversionOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/texttohtmlconversionoptions/) в метод экспорта и записывает каждый результат в отдельный UTF‑8 HTML‑файл:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("text-inheritance.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null) {
            IParagraphCollection paragraphs = textFrame.getParagraphs();
            
            int[] modes = { TextInheritanceLimit.All, TextInheritanceLimit.TextBox, TextInheritanceLimit.ParagraphOnly };
            String[] fileNames = { "All.html", "TextBox.html", "ParagraphOnly.html" };

            for (int i = 0; i < modes.length; i++) {
                TextToHtmlConversionOptions options = new TextToHtmlConversionOptions();
                options.setTextInheritanceLimit(modes[i]);

                String html = paragraphs.exportToHtml(0, paragraphs.getCount(), options);
                byte[] htmlBytes = html.getBytes(StandardCharsets.UTF_8);
                try {
                    Files.write(Paths.get(fileNames[i]), htmlBytes);
                } catch (IOException exception) {
                    System.out.println("The HTML file could not be written: " + exception.getMessage());
                }
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

Сгенерированный HTML содержит следующий CSS для первого фрагмента «Inherited text; ». Таблица перечисляет соответствующие объявления; остальные свойства опущены для ясности.

| Вывод | Соответствующий CSS для первого фрагмента | Внешний вид |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Синий, полужирный, курсивный текст 28 pt в Calibri, если этот шрифт доступен. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Синий, полужирный, курсивный текст; шрифт и размер определяются окружающей страницей или браузером. |
| `ParagraphOnly.html` | `font-weight:bold` | Полужирный текст; шрифт, размер, цвет и курсив определяются окружающей страницой или браузером. |

Второй фрагмент сохраняет `color:#ff0000`, `font-size:18pt` и `font-weight:bold` во всех трёх выводах. Он также сохраняет курсив в `All` и `TextBox`, но не в `ParagraphOnly`. Ограничение наследования поэтому не удаляет форматирование, явно назначенное абзацу или фрагменту.

Откройте файлы в одном браузере для сравнения. В двух ограниченных режимах опущенные свойства CSS берутся из стилей целевой страницы или значений по умолчанию браузера, поэтому итоговый вид зависит от места использования HTML.

### **Рендеринг абзаца как изображения**

[IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage--) рендерит отдельный абзац непосредственно и возвращает объект [IImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/). Сохраните результат в файл или поток с помощью [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-). Нет необходимости рендерить содержащую фигуру или вручную обрезать bitmap.

[IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage--) может вернуть `null`, если абзац не найден в родительской коллекции, не имеет валидных границ рендеринга или не может быть отрисован. Проверьте результат перед сохранением и освободите полученное изображение после использования.

#### **Рендеринг абзаца в масштабе по умолчанию**

Пример использует презентацию с одним слайдом, на котором первая фигура — текстовое поле, содержащее три абзаца.

![Текстовое поле с тремя абзацами](paragraph_to_image_input.png)

Следующий пример выбирает второй абзац с индексом 1 и вызывает [IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage--) без параметров масштаба. Он проверяет, что фигура содержит требуемый абзац и что рендеринг вернул изображение, перед тем как вызвать [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) для сохранения PNG‑файла. Блок `finally` освобождает изображение после использования.

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

Используйте перегрузку [IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage-float-float-) с параметрами `float scaleX` и `float scaleY` для задания горизонтального и вертикального коэффициентов масштабирования. Следующий пример создаёт таблицу, рендерит абзац в её первой ячейке с удвоенной шириной и высотой и сохраняет результат в PNG‑изображение.

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

Коэффициент масштаба `1` оставляет соответствующую ось в её исходном размере пикселей. Например, `2` для обеих осей даёт изображение, ширина и высота которого примерно в два раза больше исходных размеров, что даёт в четыре раза больше пикселей. Более крупные коэффициенты обычно дают более чёткий текст для увеличения или вывода в высоком разрешении, но также увеличивают расход памяти и размер файла. Коэффициенты меньше `1` дают более маленькие изображения с меньшей детализацией. Используйте одинаковые коэффициенты, чтобы сохранить пропорции абзаца; разные горизонтальные и вертикальные коэффициенты растягивают вывод независимо.

Рендеринг всей фигуры с помощью [IShape.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getImage--) остаётся полезным, когда в выводе должны присутствовать заливка, контур или другой визуальный контекст фигуры. Для изображения только абзаца используйте [IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage--).

## **FAQ**

**Можно ли полностью отключить перенос строк внутри текстового фрейма?**

Да. Установите [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) для отключения переноса, чтобы строки не разбивались у краёв текстового фрейма.

**Как получить точные границы конкретного абзаца на слайде?**

Используйте [IParagraph.getRect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getRect--) для получения прямоугольника, ограничивающего абзац. [IPortion.getRect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/#getRect--) предоставляет границы отдельного фрагмента.

**Где управляются выравнивание абзаца (по левому, правому краю, по центру или по ширине)?**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) — это настройка уровня абзаца и применяется ко всему абзацу независимо от форматирования отдельных фрагментов.

Чтобы вертикально выровнять фрагменты разного размера шрифта внутри каждой строки, см. [Align Fonts Within a Line](/slides/ru/androidjava/text-formatting/#align-fonts-within-a-line).

**Можно ли задать язык проверки правописания только для части абзаца?**

Да. Установите [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) для отдельных фрагментов, чтобы один абзац мог содержать текст на нескольких языках.