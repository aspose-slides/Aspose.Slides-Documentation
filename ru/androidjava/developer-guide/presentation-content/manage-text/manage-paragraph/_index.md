---
title: Управление текстовыми параграфами PowerPoint на Android
linktitle: Управление параграфом
type: docs
weight: 40
url: /ru/androidjava/manage-paragraph/
keywords:
- добавить текст
- добавить параграф
- управлять текстом
- управлять параграфом
- управлять маркером
- отступ параграфа
- висячий отступ
- маркер параграфа
- нумерованный список
- маркированный список
- свойства параграфа
- импорт HTML
- текст в HTML
- параграф в HTML
- параграф в изображение
- текст в изображение
- экспортировать параграф
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Освойте форматирование параграфов с Aspose.Slides для Android — оптимизируйте выравнивание, интервалы и стиль в презентациях PPT, PPTX и ODP на Java."
---
Aspose.Slides предоставляет все необходимые интерфейсы и классы для работы с текстом, параграфами и фрагментами PowerPoint на Java.

* Aspose.Slides предоставляет интерфейс [ITextFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/) , позволяющий добавлять объекты, представляющие параграф. Объект `ITextFame` может содержать один или несколько параграфов (каждый параграф создаётся с помощью перевода строки).
* Aspose.Slides предоставляет интерфейс [IParagraph](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraph/) , позволяющий добавлять объекты, представляющие фрагменты. Объект `IParagraph` может содержать один или несколько фрагментов (коллекцию объектов iPortions).
* Aspose.Slides предоставляет интерфейс [IPortion](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iportion/) , позволяющий добавлять объекты, представляющие текст и его свойства форматирования.

Объект `IParagraph` способен обрабатывать тексты с различными свойствами форматирования через свои внутренние объекты `IPortion`.

## **Добавление нескольких параграфов, содержащих несколько текстовых фрагментов**

Эти шаги показывают, как добавить текстовый фрейм, содержащий 3 параграфа, каждый из которых содержит 3 фрагмента:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/).
2. Получите ссылку на соответствующий слайд по его индексу.
3. Добавьте прямоугольную [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/) на слайд.
4. Получите ITextFrame, связанный с [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/).
5. Создайте два объекта [IParagraph](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraph/) и добавьте их в коллекцию `IParagraphs` объекта [ITextFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/).
6. Создайте по три объекта [IPortion](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iportion/) для каждого нового `IParagraph` (по два объекта Portion для стандартного Paragraph) и добавьте каждый объект `IPortion` в коллекцию IPortion соответствующего `IParagraph`.
7. Установите текст для каждого фрагмента.
8. Примените желаемые свойства форматирования к каждому фрагменту, используя свойства форматирования, предоставляемые объектом `IPortion`.
9. Сохраните изменённую презентацию.

```java
// Создайте экземпляр класса Presentation, представляющий файл PPTX
Presentation pres = new Presentation();
try {
    // Доступ к первому слайду
    ISlide slide = pres.getSlides().get_Item(0);

    // Добавьте AutoShape типа Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // Доступ к TextFrame AutoShape
    ITextFrame tf = ashp.getTextFrame();

    // Создайте Paragraph и Portion с разными форматами текста
    IParagraph para0 = tf.getParagraphs().get_Item(0);
    IPortion port01 = new Portion();
    IPortion port02 = new Portion();
    para0.getPortions().add(port01);
    para0.getPortions().add(port02);

    IParagraph para1 = new Paragraph();
    tf.getParagraphs().add(para1);
    IPortion port10 = new Portion();
    IPortion port11 = new Portion();
    IPortion port12 = new Portion();
    para1.getPortions().add(port10);
    para1.getPortions().add(port11);
    para1.getPortions().add(port12);

    IParagraph para2 = new Paragraph();
    tf.getParagraphs().add(para2);
    IPortion port20 = new Portion();
    IPortion port21 = new Portion();
    IPortion port22 = new Portion();
    para2.getPortions().add(port20);
    para2.getPortions().add(port21);
    para2.getPortions().add(port22);

    for (int i = 0; i < 3; i++) 
    {
        for (int j = 0; j < 3; j++) 
        {
            IPortion portion = tf.getParagraphs().get_Item(i).getPortions().get_Item(j); 
            portion.setText("Portion0" + j);
            if (j == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
                portion.getPortionFormat().setFontBold(NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (j == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
                portion.getPortionFormat().setFontItalic(NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    //Записать PPTX на диск
    pres.save("multiParaPort_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Управление маркерами в параграфах**

Маркированные списки помогают быстро и эффективно организовать и представить информацию. Параграфы с маркерами всегда проще читать и понимать.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/).
2. Получите ссылку на соответствующий слайд по его индексу.
3. Добавьте [autoshape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/) на выбранный слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/) автоконтурной формы.
5. Удалите стандартный параграф в `TextFrame`.
6. Создайте первый экземпляр параграфа, используя класс [Paragraph](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/paragraph/).
7. Установите тип маркера `Type` для параграфа как `Symbol` и задайте символ маркера.
8. Задайте `Text` параграфа.
9. Установите `Indent` параграфа для маркера.
10. Установите цвет маркера.
11. Задайте высоту маркера.
12. Добавьте новый параграф в коллекцию параграфов `TextFrame`.
13. Добавьте второй параграф и повторите процесс, описанный в шагах 7‑13.
14. Сохраните презентацию.

```java
// Создает экземпляр класса Presentation, представляющего файл PPTX
Presentation pres = new Presentation();
try {
    // Доступ к первому слайду
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Добавляет и получает автофигуру
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Доступ к текстовому фрейму автофигуры
    ITextFrame txtFrm = aShp.getTextFrame();

    // Удаляет стандартный параграф
    txtFrm.getParagraphs().removeAt(0);

    // Создает параграф
    Paragraph para = new Paragraph();

    // Устанавливает стиль маркера параграфа и символ
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char)8226);

    // Устанавливает текст параграфа
    para.setText("Welcome to Aspose.Slides");

    // Устанавливает отступ маркера
    para.getParagraphFormat().setIndent(25);

    // Устанавливает цвет маркера
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // установить IsBulletHardColor в true, чтобы использовать собственный цвет маркера

    // Устанавливает высоту маркера
    para.getParagraphFormat().getBullet().setHeight(100);

    // Добавляет параграф в текстовый фрейм
    txtFrm.getParagraphs().add(para);

    // Создает второй параграф
    Paragraph para2 = new Paragraph();

    // Устанавливает тип и стиль маркера параграфа
    para2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);

    // Добавляет текст параграфа
    para2.setText("This is numbered bullet");

    // Устанавливает отступ маркера
    para2.getParagraphFormat().setIndent(25);

    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // установить IsBulletHardColor в true, чтобы использовать собственный цвет маркера

    // Устанавливает высоту маркера
    para2.getParagraphFormat().getBullet().setHeight(100);

    // Добавляет параграф в текстовый фрейм
    txtFrm.getParagraphs().add(para2);
    
    // Сохраняет изменённую презентацию
    pres.save("Bullet_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Управление маркерами‑картинками**

Маркированные списки помогают быстро и эффективно организовать и представить информацию. Параграфы с картинками легко читать и понимать.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/).
2. Получите ссылку на соответствующий слайд по его индексу.
3. Добавьте [autoshape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/) на слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/) автоконтурной формы.
5. Удалите стандартный параграф в `TextFrame`.
6. Создайте первый параграф через класс [Paragraph](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/paragraph/).
7. Загрузите изображение в [IPPImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ippimage/).
8. Установите тип маркера как [Picture](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ippimage/) и задайте изображение.
9. Задайте `Text` Paragraph.
10. Установите `Indent` Paragraph для маркера.
11. Установите цвет маркера.
12. Задайте высоту маркера.
13. Добавьте новый параграф в коллекцию параграфов `TextFrame`.
14. Добавьте второй параграф и повторите процесс, основанный на предыдущих шагах.
15. Сохраните изменённую презентацию.

```java
// Создает экземпляр класса Presentation, представляющего файл PPTX
Presentation presentation = new Presentation();
try {
    // Доступ к первому слайду
    ISlide slide = presentation.getSlides().get_Item(0);

    // Создает изображение для маркеров
    IPPImage picture;
    IImage image = Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // Добавляет и получает автофигуру
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Доступ к текстовому фрейму автофигуры
    ITextFrame textFrame = autoShape.getTextFrame();

    // Удаляет стандартный параграф
    textFrame.getParagraphs().removeAt(0);

    // Создает новый параграф
    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");

    // Устанавливает стиль маркера параграфа и изображение
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // Устанавливает высоту маркера
    paragraph.getParagraphFormat().getBullet().setHeight(100);

    // Добавляет параграф в текстовый фрейм
    textFrame.getParagraphs().add(paragraph);

    // Сохраняет презентацию в файл PPTX
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

    // Сохраняет презентацию в файл PPT
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Управление многоуровневыми маркерами**

Маркированные списки помогают быстро и эффективно организовать и представить информацию. Многоуровневые маркеры легко читаются и понимаются.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/).
2. Получите ссылку на соответствующий слайд по его индексу.
3. Добавьте [autoshape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/) на новый слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/) автоконтурной формы.
5. Удалите стандартный параграф в `TextFrame`.
6. Создайте первый параграф через класс [Paragraph](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/paragraph/) и установите глубину 0.
7. Создайте второй параграф через класс `Paragraph` и задайте глубину 1.
8. Создайте третий параграф через класс `Paragraph` и задайте глубину 2.
9. Создайте четвёртый параграф через класс `Paragraph` и задайте глубину 3.
10. Добавьте новые параграфы в коллекцию параграфов `TextFrame`.
11. Сохраните изменённую презентацию.

```java
// Создаёт экземпляр класса Presentation, представляющего файл PPTX
Presentation pres = new Presentation();
try {
    // Получает доступ к первому слайду
    ISlide slide = pres.getSlides().get_Item(0);

    // Добавляет и получает AutoShape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Получает доступ к текстовому фрейму созданной AutoShape
    ITextFrame text = aShp.addTextFrame("");

    // Очищает стандартный параграф
    text.getParagraphs().clear();

    // Добавляет первый параграф
    IParagraph para1 = new Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Устанавливает уровень маркера
    para1.getParagraphFormat().setDepth((short)0);

    // Добавляет второй параграф
    IParagraph para2 = new Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Устанавливает уровень маркера
    para2.getParagraphFormat().setDepth((short)1);

    // Добавляет третий параграф
    IParagraph para3 = new Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Устанавливает уровень маркера
    para3.getParagraphFormat().setDepth((short)2);

    // Добавляет четвертый параграф
    IParagraph para4 = new Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Устанавливает уровень маркера
    para4.getParagraphFormat().setDepth((short)3);

    // Добавляет параграфы в коллекцию
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);

    // Сохраняет презентацию в файл PPTX
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Управление параграфом с пользовательским нумерованным списком**

Интерфейс [IBulletFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibulletformat/) предоставляет свойство [NumberedBulletStartWith](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) и другие, позволяющие управлять параграфами с пользовательской нумерацией или форматированием.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/).
2. Получите доступ к слайду, содержащему параграф.
3. Добавьте [autoshape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/) на слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/) автоконтурной формы.
5. Удалите стандартный параграф в `TextFrame`.
6. Создайте первый параграф через класс [Paragraph](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/paragraph/) и установите [NumberedBulletStartWith](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) значение 2.
7. Создайте второй параграф через класс `Paragraph` и установите `NumberedBulletStartWith` значение 3.
8. Создайте третий параграф через класс `Paragraph` и установите `NumberedBulletStartWith` значение 7.
9. Добавьте новые параграфы в коллекцию параграфов `TextFrame`.
10. Сохраните изменённую презентацию.

```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Получает доступ к текстовому фрейму созданной автофигуры
    ITextFrame textFrame = shape.getTextFrame();

    // Удаляет стандартный существующий параграф
    textFrame.getParagraphs().removeAt(0);

    // Первый список
    Paragraph paragraph1 = new Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth((short)4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)2);
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth((short)4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)3);
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph2);


    Paragraph paragraph5 = new Paragraph();
    paragraph5.setText("bullet 7");
    paragraph5.getParagraphFormat().setDepth((short)4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)7);
    paragraph5.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph5);

    presentation.save("SetCustomBulletsNumber-slides.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Установка отступа первой строки для параграфа**

Используйте метод [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) для управления отступом первой строки параграфа. Этот метод перемещает только первую строку относительно левого поля параграфа. Положительное значение сдвигает первую строку вправо, в то время как остальные строки остаются выровненными по телу параграфа.

Используйте [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-), когда нужно сдвинуть весь параграф. Используйте [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-), когда необходимо сдвинуть только первую строку.

Пример ниже создает несколько параграфов и применяет разные значения отступа, чтобы продемонстрировать, как отступ первой строки влияет на макет параграфа.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/).
2. Получите доступ к целевому слайду.
3. Добавьте прямоугольную [AutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/autoshape/) на слайд.
4. Добавьте пустой [TextFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/textframe/) к фигуре и удалите стандартный параграф.
5. Создайте несколько параграфов и задайте им различные значения [Indent](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-).
6. Добавьте параграфы в текстовый фрейм.
7. Сохраните изменённую презентацию.

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape rectangleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(FillType.NoFill);
    rectangleShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().removeAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().setMarginLeft(20f);
    firstParagraph.getParagraphFormat().setIndent(0f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().setMarginLeft(20f);
    secondParagraph.getParagraphFormat().setIndent(20f);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().setMarginLeft(20f);
    thirdParagraph.getParagraphFormat().setIndent(40f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

Результат:

![Отступ первой строки параграфов](first_line_indent.png)

## **Установка висячего отступа для параграфа**

Висячий отступ — это макет параграфа, при котором первая строка начинается левее остальных строк. В Aspose.Slides это эффект создаётся с помощью метода [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-). Установите отступ отрицательным, чтобы переместить первую строку влево относительно тела параграфа.

На практике [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) задаёт левое положение тела параграфа, а [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) определяет позицию первой строки относительно этого поля. Чтобы создать висячий отступ, задайте положительное значение `MarginLeft` и отрицательное значение `Indent`.

Такое форматирование полезно для библиографий, ссылок, глоссариев и других параграфов, где строки переноса должны выравниваться по телу параграфа, а не под первым символом первой строки.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/).
2. Получите доступ к целевому слайду.
3. Добавьте прямоугольную [AutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/autoshape/) на слайд.
4. Добавьте пустой [TextFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/textframe/) к фигуре и удалите стандартный параграф.
5. Создайте параграфы и задайте каждому положительное значение [MarginLeft](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-).
6. Задайте отрицательное значение [Indent](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-), чтобы создать эффект висячего отступа.
7. Добавьте параграфы в текстовый фрейм.
8. Сохраните изменённую презентацию.

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape rectangleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(FillType.NoFill);
    rectangleShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().removeAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().setMarginLeft(40f);
    firstParagraph.getParagraphFormat().setIndent(-20f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().setMarginLeft(60f);
    secondParagraph.getParagraphFormat().setIndent(-30f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

Результат:

![Висячий отступ параграфов](hanging_indent.png)

## **Управление свойствами End в параграфе**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/).
2. Получите ссылку на слайд, содержащий параграф, по его позиции.
3. Добавьте прямоугольный [autoshape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/) на слайд.
4. Добавьте [TextFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/) с двумя параграфами в прямоугольник.
5. Задайте `FontHeight` и тип шрифта для параграфов.
6. Установите свойства End для параграфов.
7. Сохраните изменённую презентацию в файл PPTX.

```java
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);

    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("Sample text"));

    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("Sample text 2"));

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(48);
    portionFormat.setLatinFont(new FontData("Times New Roman"));
    para2.setEndParagraphPortionFormat(portionFormat);

    shape.getTextFrame().getParagraphs().add(para1);
    shape.getTextFrame().getParagraphs().add(para2);

    pres.save(resourcesOutputPath+"pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Импорт HTML‑текста в параграфы**

Aspose.Slides предоставляет расширенную поддержку импорта HTML‑текста в параграфы.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/).
2. Получите ссылку на соответствующий слайд по его индексу.
3. Добавьте [autoshape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/) на слайд.
4. Добавьте и получите доступ к `autoshape` [ITextFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/).
5. Удалите стандартный параграф в `ITextFrame`.
6. Прочитайте исходный HTML‑файл с помощью TextReader.
7. Создайте первый параграф через класс [Paragraph](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/paragraph/).
8. Добавьте содержимое HTML‑файла, считанное из TextReader, в [ParagraphCollection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/paragraphcollection/) TextFrame.
9. Сохраните изменённую презентацию.

```java
// Создать пустой экземпляр презентации
Presentation pres = new Presentation();
try {
    // Получить доступ к стандартному первому слайду презентации
    ISlide slide = pres.getSlides().get_Item(0);

    // Добавляем AutoShape для размещения HTML‑содержимого
    IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
            (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

    ashape.getFillFormat().setFillType(FillType.NoFill);

    // Добавляем текстовый фрейм к фигуре
    ashape.addTextFrame("");

    // Очищаем все параграфы в добавленном текстовом фрейме
    ashape.getTextFrame().getParagraphs().clear();

    // Загружаем HTML‑файл с помощью StreamReader
    TextReader tr = new StreamReader("file.html");

    // Добавляем текст из HTML‑потока в текстовый фрейм
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // Сохраняем презентацию
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Экспорт текста параграфа в HTML**

Aspose.Slides предоставляет расширенную поддержку экспорта текстов (содержащихся в параграфах) в HTML.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/) и загрузите нужную презентацию.
2. Получите ссылку на соответствующий слайд по его индексу.
3. Получите доступ к фигуре, содержащей текст, который будет экспортирован в HTML.
4. Получите [TextFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/textframe/) фигуры.
5. Создайте экземпляр `StreamWriter` и добавьте новый HTML‑файл.
6. Укажите начальный индекс для StreamWriter и экспортируйте выбранные параграфы.

```java
// Загрузить файл презентации
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // Получить доступ к стандартному первому слайду презентации
    ISlide slide = pres.getSlides().get_Item(0);

    // Желаемый индекс
    int index = 0;

    // Доступ к добавленной фигуре
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // Создание выходного HTML-файла
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    //Извлечение первого параграфа в виде HTML
    // Запись данных параграфов в HTML, указав начальный индекс параграфа и количество копируемых параграфов
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Сохранение параграфа как изображения**

В этом разделе мы рассмотрим два примера, демонстрирующие, как сохранить текстовый параграф, представленный интерфейсом [IParagraph](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraph/), как изображение. Оба примера включают получение изображения фигуры, содержащей параграф, с помощью методов `getImage` из интерфейса [IShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/), вычисление границ параграфа внутри фигуры и экспорт его как bitmap‑изображения. Такие подходы позволяют извлекать определённые части текста из презентаций PowerPoint и сохранять их отдельными изображениями, что может быть полезно в различных сценариях.

Предположим, у нас есть файл презентации sample.pptx с одним слайдом, где первая фигура — текстовое поле, содержащее три параграфа.

![Текстовое поле с тремя параграфами](paragraph_to_image_input.png)

**Пример 1**

В этом примере мы получаем второй параграф в виде изображения. Для этого извлекаем изображение фигуры с первого слайда презентации, затем вычисляем границы второго параграфа в текстовом фрейме фигуры. Параграф затем перерисовывается на новое bitmap‑изображение, которое сохраняется в формате PNG. Этот метод особенно полезен, когда необходимо сохранить конкретный параграф как отдельное изображение, сохранив точные размеры и форматирование текста.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Сохранить форму в памяти в виде bitmap.
    IImage shapeImage = firstShape.getImage();
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // Создать bitmap формы из памяти.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // Вычислить границы второго параграфа.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    RectF paragraphRectangle = secondParagraph.getRect();

    // Вычислить координаты и размер выходного изображения (минимальный размер - 1x1 пиксель).
    int imageX = (int) Math.floor(paragraphRectangle.left);
    int imageY = (int) Math.floor(paragraphRectangle.top);
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.width()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.height()));

    // Обрезать bitmap формы, чтобы получить только bitmap параграфа.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

Результат:

![Изображение параграфа](paragraph_to_image_output.png)

**Пример 2**

В этом примере мы расширяем предыдущий подход, добавляя коэффициенты масштабирования к изображению параграфа. Фигура извлекается из презентации и сохраняется как изображение с коэффициентом масштабирования `2`. Это позволяет получить изображение более высокого разрешения при экспорте параграфа. Затем границы параграфа вычисляются с учётом масштабирования. Масштабирование особенно полезно, когда требуется более детализированное изображение, например, для использования в высококачественных печатных материалах.

```java
float imageScaleX = 2f;
float imageScaleY = imageScaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Сохранить форму в памяти в виде bitmap с масштабированием.
    IImage shapeImage = firstShape.getImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // Создать bitmap формы из памяти.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // Вычислить границы второго параграфа.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    RectF paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.set(
            paragraphRectangle.left * imageScaleX,
            paragraphRectangle.top * imageScaleY,
            paragraphRectangle.right * imageScaleX,
            paragraphRectangle.bottom * imageScaleY
    );

    // Вычислить координаты и размер выходного изображения (минимальный размер - 1x1 pixel).
    int imageX = (int) Math.floor(paragraphRectangle.left);
    int imageY = (int) Math.floor(paragraphRectangle.top);
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.width()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.height()));

    // Обрезать bitmap формы, чтобы получить только bitmap параграфа.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **FAQ**

**Можно ли полностью отключить перенос строк внутри текстового фрейма?**

Да. Используйте настройку переноса текста в текстовом фрейме ([setWrapText](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-)), чтобы отключить перенос, и строки не будут разрезаться по краям фрейма.

**Как получить точные границы конкретного параграфа на слайде?**

Вы можете получить прямоугольник ограничивающий параграф (и даже отдельный фрагмент), чтобы узнать его точное положение и размер на слайде.

**Где управляется выравнивание параграфа (по левому/правому краю, по центру, по ширине)?**

[Alignment](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/paragraphformat/#setAlignment-int-) — настройка уровня параграфа в [ParagraphFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/paragraphformat/); она применяется ко всему параграфу независимо от форматирования отдельных фрагментов.

**Можно ли задать язык проверки орфографии только для части параграфа (например, для одного слова)?**

Да. Язык задаётся на уровне фрагмента ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)), поэтому в одном параграфе могут сосуществовать несколько языков.