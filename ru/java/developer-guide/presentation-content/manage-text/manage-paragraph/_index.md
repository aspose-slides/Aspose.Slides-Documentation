---
title: Управление текстовыми абзацами PowerPoint в Java
linktitle: Управление абзацем
type: docs
weight: 40
url: /ru/java/manage-paragraph/
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
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Мастер форматирования абзацев с Aspose.Slides для Java — оптимизируйте выравнивание, интервал и стиль в презентациях PPT, PPTX и ODP на Java."
---
Aspose.Slides предоставляет все интерфейсы и классы, необходимые для работы с текстами, абзацами и фрагментами PowerPoint на Java.

* Aspose.Slides предоставляет интерфейс [ITextFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/) , позволяющий добавлять объекты, представляющие абзац. Объект `ITextFame` может содержать один или несколько абзацев (каждый абзац создаётся с помощью переноса строки).
* Aspose.Slides предоставляет интерфейс [IParagraph](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraph/) , позволяющий добавлять объекты, представляющие фрагменты. Объект `IParagraph` может содержать один или несколько фрагментов (коллекция объектов iPortions).
* Aspose.Slides предоставляет интерфейс [IPortion](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iportion/) , позволяющий добавлять объекты, представляющие тексты и их свойства форматирования. 

Объект `IParagraph` способен обрабатывать тексты с разными свойствами форматирования через связанные с ним объекты `IPortion`.

## **Добавление нескольких абзацев, содержащих несколько фрагментов**

Эти шаги показывают, как добавить текстовый фрейм, содержащий 3 абзаца, каждый из которых содержит 3 фрагмента:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/).
2. Получите ссылку на нужный слайд по его индексу.
3. Добавьте прямоугольный [IAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape/) на слайд.
4. Получите ITextFrame, связанный с [IAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape/).
5. Создайте два объекта [IParagraph](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraph/) и добавьте их в коллекцию `IParagraphs` объекта [ITextFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/).
6. Создайте три объекта [IPortion](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iportion/) для каждого нового `IParagraph` (по два объекта Portion для абзаца по умолчанию) и добавьте каждый объект `IPortion` в коллекцию IPortion соответствующего `IParagraph`.
7. Установите текст для каждого фрагмента.
8. Примените желаемые свойства форматирования к каждому фрагменту с помощью свойств форматирования объекта `IPortion`.
9. Сохраните изменённую презентацию.

```java
// Создать объект класса Presentation, представляющий файл PPTX
Presentation pres = new Presentation();
try {
    // Получение первого слайда
    ISlide slide = pres.getSlides().get_Item(0);

    // Добавить AutoShape типа Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // Получить TextFrame AutoShape
    ITextFrame tf = ashp.getTextFrame();

    // Создать абзацы и фрагменты с различными форматами текста
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

    //Сохранить PPTX на диск
    pres.save("multiParaPort_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Управление маркерами абзацев**

Списки с маркерами позволяют быстро и эффективно структурировать и представлять информацию. Маркированные абзацы всегда легче читать и воспринимать.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/).
2. Получите ссылку на нужный слайд по его индексу.
3. Добавьте [autoshape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape/) на выбранный слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/) автокисти.
5. Удалите абзац по умолчанию в `TextFrame`.
6. Создайте первый экземпляр абзаца с помощью класса [Paragraph](https://reference.aspose.com/slides/ru/java/com.aspose.slides/paragraph/).
7. Установите `Type` маркера для абзаца в `Symbol` и задайте символ маркера.
8. Установите `Text` абзаца.
9. Установите `Indent` абзаца для маркера.
10. Задайте цвет маркера.
11. Задайте высоту маркера.
12. Добавьте новый абзац в коллекцию абзацев `TextFrame`.
13. Добавьте второй абзац и повторите процесс, указанный в шагах 7–13.
14. Сохраните презентацию.

```java
// Создает объект класса Presentation, представляющий файл PPTX
Presentation pres = new Presentation();
try {
    // Получает первый слайд
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Добавляет и получает Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Получает текстовый фрейм автокисти
    ITextFrame txtFrm = aShp.getTextFrame();

    // Удаляет абзац по умолчанию
    txtFrm.getParagraphs().removeAt(0);

    // Создает абзац
    Paragraph para = new Paragraph();

    // Устанавливает стиль маркера абзаца и символ
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char)8226);

    // Устанавливает текст абзаца
    para.setText("Welcome to Aspose.Slides");

    // Устанавливает отступ маркера
    para.getParagraphFormat().setIndent(25);

    // Устанавливает цвет маркера
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // установить IsBulletHardColor в true, чтобы использовать собственный цвет маркера

    // Устанавливает высоту маркера
    para.getParagraphFormat().getBullet().setHeight(100);

    // Добавляет абзац в текстовый фрейм
    txtFrm.getParagraphs().add(para);

    // Создает второй абзац
    Paragraph para2 = new Paragraph();

    // Устанавливает тип и стиль маркера абзаца
    para2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);

    // Добавляет текст абзаца
    para2.setText("This is numbered bullet");

    // Устанавливает отступ маркера
    para2.getParagraphFormat().setIndent(25);

    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // установить IsBulletHardColor в true, чтобы использовать собственный цвет маркера

    // Устанавливает высоту маркера
    para2.getParagraphFormat().getBullet().setHeight(100);

    // Добавляет абзац в текстовый фрейм
    txtFrm.getParagraphs().add(para2);
    
    // Сохраняет измененную презентацию
    pres.save("Bullet_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Управление маркерами с изображениями**

Списки с маркерами помогают быстро и эффективно упорядочить информацию. Абзацы с изображениями легко читать и понимать.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/).
2. Получите ссылку на нужный слайд по его индексу.
3. Добавьте [autoshape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape/) на слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/) автокисти.
5. Удалите абзац по умолчанию в `TextFrame`.
6. Создайте первый экземпляр абзаца с помощью класса [Paragraph](https://reference.aspose.com/slides/ru/java/com.aspose.slides/paragraph/).
7. Загрузите изображение в [IPPImage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ippimage/).
8. Установите тип маркера в [Picture](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ippimage/) и задайте изображение.
9. Установите `Text` абзаца.
10. Установите `Indent` абзаца для маркера.
11. Задайте цвет маркера.
12. Задайте высоту маркера.
13. Добавьте новый абзац в коллекцию абзацев `TextFrame`.
14. Добавьте второй абзац и повторите процесс, основанный на предыдущих шагах.
15. Сохраните изменённую презентацию.

```java
// Создаёт объект класса Presentation, представляющий файл PPTX
Presentation presentation = new Presentation();
try {
    // Получает первый слайд
    ISlide slide = presentation.getSlides().get_Item(0);

    // Создаёт изображение для маркеров
    IPPImage picture;
    IImage image = Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // Добавляет и получает AutoShape
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Получает текстовый фрейм автокисти
    ITextFrame textFrame = autoShape.getTextFrame();

    // Удаляет абзац по умолчанию
    textFrame.getParagraphs().removeAt(0);

    // Создаёт новый абзац
    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");

    // Устанавливает стиль маркера абзаца и изображение
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // Устанавливает высоту маркера
    paragraph.getParagraphFormat().getBullet().setHeight(100);

    // Добавляет абзац в текстовый фрейм
    textFrame.getParagraphs().add(paragraph);

    // Сохраняет презентацию как файл PPTX
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

    // Сохраняет презентацию как файл PPT
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Управление многоуровневыми маркерами**

Списки с маркерами помогают быстро и эффективно упорядочить информацию. Многоуровневые маркеры легко читаются и понятны.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/).
2. Получите ссылку на нужный слайд по его индексу.
3. Добавьте [autoshape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape/) в новый слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/) автокисти.
5. Удалите абзац по умолчанию в `TextFrame`.
6. Создайте первый экземпляр абзаца через класс [Paragraph](https://reference.aspose.com/slides/ru/java/com.aspose.slides/paragraph/) и задайте глубину 0.
7. Создайте второй экземпляр абзаца через класс `Paragraph` и задайте глубину 1.
8. Создайте третий экземпляр абзаца через класс `Paragraph` и задайте глубину 2.
9. Создайте четвёртый экземпляр абзаца через класс `Paragraph` и задайте глубину 3.
10. Добавьте новые абзацы в коллекцию абзацев `TextFrame`.
11. Сохраните изменённую презентацию.

```java
// Создаёт объект класса Presentation, представляющий файл PPTX
Presentation pres = new Presentation();
try {
    // Получает первый слайд
    ISlide slide = pres.getSlides().get_Item(0);

    // Добавляет и получает Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Получает текстовый фрейм созданного автокисти
    ITextFrame text = aShp.addTextFrame("");

    // Очищает абзац по умолчанию
    text.getParagraphs().clear();

    // Добавляет первый абзац
    IParagraph para1 = new Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Устанавливает уровень маркера
    para1.getParagraphFormat().setDepth((short)0);

    // Добавляет второй абзац
    IParagraph para2 = new Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Устанавливает уровень маркера
    para2.getParagraphFormat().setDepth((short)1);

    // Добавляет третий абзац
    IParagraph para3 = new Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Устанавливает уровень маркера
    para3.getParagraphFormat().setDepth((short)2);

    // Добавляет четвёртый абзац
    IParagraph para4 = new Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Устанавливает уровень маркера
    para4.getParagraphFormat().setDepth((short)3);

    // Добавляет абзацы в коллекцию
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);

    // Сохраняет презентацию как файл PPTX
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Управление абзацем с пользовательским нумерованным списком**

Интерфейс [IBulletFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibulletformat/) предоставляет свойство [NumberedBulletStartWith](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) и другие, позволяющие управлять абзацами с пользовательской нумерацией или форматированием.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/).
2. Получите слайд, содержащий абзац.
3. Добавьте [autoshape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape/) на слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/) автокисти.
5. Удалите абзац по умолчанию в `TextFrame`.
6. Создайте первый экземпляр абзаца через класс [Paragraph](https://reference.aspose.com/slides/ru/java/com.aspose.slides/paragraph/) и установите [NumberedBulletStartWith](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) в 2.
7. Создайте второй экземпляр абзаца через класс `Paragraph` и установите `NumberedBulletStartWith` в 3.
8. Создайте третий экземпляр абзаца через класс `Paragraph` и установите `NumberedBulletStartWith` в 7.
9. Добавьте новые абзацы в коллекцию абзацев `TextFrame`.
10. Сохраните изменённую презентацию.

```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Получает текстовый фрейм созданного автокисти
    ITextFrame textFrame = shape.getTextFrame();

    // Удаляет существующий абзац по умолчанию
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

## **Установка отступа первой строки для абзаца**

Используйте метод [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraphformat/#setIndent-float-) для управления отступом первой строки абзаца. Этот метод смещает только первую строку относительно левого поля абзаца. Положительное значение сдвигает первую строку вправо, остальные строки остаются выровненными по телу абзаца.

Используйте [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) когда нужно переместить весь абзац. Используйте [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraphformat/#setIndent-float-) когда нужно сместить только первую строку.

В примере ниже создаются несколько абзацев и задаются различные значения отступа, чтобы показать, как отступ первой строки влияет на расположение абзаца.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/).
2. Получите целевой слайд.
3. Добавьте прямоугольный [AutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/autoshape/) на слайд.
4. Добавьте пустой [TextFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/textframe/) к фигуре и удалите абзац по умолчанию.
5. Создайте несколько абзацев и задайте им разные значения [Indent](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraphformat/#setIndent-float-).
6. Добавьте абзацы в текстовый фрейм.
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

![Отступ первой строки абзацев](first_line_indent.png)

## **Установка висячего отступа для абзаца**

Висячий отступ — это макет абзаца, при котором первая строка начинается левее остальных строк. В Aspose.Slides этот эффект создаётся методом [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraphformat/#setIndent-float-). Установите отрицательное значение отступа, чтобы сдвинуть первую строку влево относительно тела абзаца.

На практике [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) определяет левую позицию тела абзаца, а [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraphformat/#setIndent-float-) определяет позицию первой строки относительно этого поля. Чтобы создать висячий отступ, задайте положительное значение `MarginLeft` и отрицательное значение `Indent`.

Такое форматирование полезно для библиографий, ссылок, словарных статей и других абзацев, где перенесённые строки должны выравниваться под телом абзаца, а не под первым символом первой строки.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/).
2. Получите целевой слайд.
3. Добавьте прямоугольный [AutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/autoshape/) на слайд.
4. Добавьте пустой [TextFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/textframe/) к фигуре и удалите абзац по умолчанию.
5. Создайте абзацы и задайте каждому положительное значение [MarginLeft](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-).
6. Установите отрицательное значение [Indent](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraphformat/#setIndent-float-), чтобы создать эффект висячего отступа.
7. Добавьте абзацы в текстовый фрейм.
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

![Висячий отступ абзацев](hanging_indent.png)

## **Управление свойствами End абзаца**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/).
1. Получите ссылку на слайд, содержащий абзац, по его позиции.
1. Добавьте прямоугольный [autoshape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape/) на слайд.
1. Добавьте [TextFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/) с двумя абзацами в прямоугольник.
1. Установите `FontHeight` и тип шрифта для абзацев.
1. Установите свойства End для абзацев.
1. Запишите изменённую презентацию в файл PPTX.

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

## **Импорт HTML‑текста в абзацы**

Aspose.Slides предоставляет расширенную поддержку импорта HTML‑текста в абзацы.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/).
2. Получите ссылку на нужный слайд по его индексу.
3. Добавьте [autoshape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape/) на слайд.
4. Добавьте и получите `autoshape` [ITextFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/).
5. Удалите абзац по умолчанию в `ITextFrame`.
6. Прочитайте исходный HTML‑файл с помощью TextReader.
7. Создайте первый экземпляр абзаца через класс [Paragraph](https://reference.aspose.com/slides/ru/java/com.aspose.slides/paragraph/).
8. Добавьте содержимое HTML‑файла, считанное TextReader, в [ParagraphCollection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/paragraphcollection/) TextFrame.
9. Сохраните изменённую презентацию.

```java
// Создать пустой экземпляр презентации
Presentation pres = new Presentation();
try {
    // Получить первый слайд презентации по умолчанию
    ISlide slide = pres.getSlides().get_Item(0);

    // Добавить AutoShape для размещения HTML‑контента
    IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
            (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

    ashape.getFillFormat().setFillType(FillType.NoFill);

    // Добавить текстовый фрейм к фигуре
    ashape.addTextFrame("");

    // Очистить все абзацы в добавленном текстовом фрейме
    ashape.getTextFrame().getParagraphs().clear();

    // Загружать HTML‑файл с помощью StreamReader
    TextReader tr = new StreamReader("file.html");

    // Добавить текст из HTML‑потока в текстовый фрейм
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // Сохранить презентацию
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Экспорт текста абзаца в HTML**

Aspose.Slides предоставляет расширенную поддержку экспорта текстов (содержащихся в абзацах) в HTML.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/) и загрузите нужную презентацию.
2. Получите ссылку на нужный слайд по его индексу.
3. Получите форму, содержащую текст, который будет экспортирован в HTML.
4. Получите [TextFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/textframe/) формы.
5. Создайте экземпляр `StreamWriter` и добавьте новый HTML‑файл.
6. Укажите начальный индекс для StreamWriter и экспортируйте выбранные абзацы.

```java
// Загрузить файл презентации
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // Получить первый слайд презентации по умолчанию
    ISlide slide = pres.getSlides().get_Item(0);

    // Желаемый индекс
    int index = 0;

    // Доступ к добавленной фигуре
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // Создание выходного HTML‑файла
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    //Extracting first paragraph as HTML
    // Записать данные абзацев в HTML, указав начальный индекс абзаца и общее количество копируемых абзацев
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Сохранить абзац как изображение**

В этом разделе рассматриваются два примера, демонстрирующие, как сохранить текстовый абзац, представленный интерфейсом [IParagraph](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraph/), в виде изображения. Оба примера включают получение изображения фигуры, содержащей абзац, с помощью методов `getImage` интерфейса [IShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishape/), вычисление границ абзаца внутри фигуры и экспорт его как растрового изображения. Такие подходы позволяют извлекать отдельные части текста из презентаций PowerPoint и сохранять их как отдельные изображения, что может быть полезно в различных сценариях.

Предположим, у нас есть файл презентации `sample.pptx` с одним слайдом, где первая фигура — это текстовое поле, содержащее три абзаца.

![Текстовое поле с тремя абзацами](paragraph_to_image_input.png)

**Пример 1**

В этом примере мы получаем второй абзац в виде изображения. Для этого извлекаем изображение фигуры с первого слайда презентации, затем вычисляем границы второго абзаца в текстовом фрейме фигуры. Затем абзац перерисовывается на новом растровом изображении, которое сохраняется в формате PNG. Этот метод особенно полезен, когда нужно сохранить конкретный абзац как отдельное изображение, сохраняя точные размеры и форматирование текста.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Сохранить форму в памяти в виде растрового изображения.
    IImage shapeImage = firstShape.getImage();
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // Создать растровое изображение формы из памяти.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // Вычислить границы второго абзаца.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    Rectangle2D paragraphRectangle = secondParagraph.getRect();

    // Вычислить координаты и размер выходного изображения (минимальный размер - 1x1 пиксель).
    int imageX = (int) Math.floor(paragraphRectangle.getX());
    int imageY = (int) Math.floor(paragraphRectangle.getY());
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.getWidth()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.getHeight()));

    // Обрезать растровое изображение формы, чтобы получить только растровое изображение абзаца.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

Результат:

![Изображение абзаца](paragraph_to_image_output.png)

**Пример 2**

В этом примере мы расширяем предыдущий подход, добавляя коэффициенты масштабирования к изображению абзаца. Фигура извлекается из презентации и сохраняется как изображение с коэффициентом масштабирования `2`. Это позволяет получить более высокое разрешение при экспорте абзаца. Затем границы абзаца рассчитываются с учётом масштаба. Масштабирование может быть особенно полезно, когда требуется более детализированное изображение, например, для печатных материалов высокого качества.

```java
float imageScaleX = 2f;
float imageScaleY = imageScaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Сохранить форму в памяти в виде растрового изображения с масштабированием.
    IImage shapeImage = firstShape.getImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // Создать растровое изображение формы из памяти.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // Вычислить границы второго абзаца.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    Rectangle2D paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.setRect(
            paragraphRectangle.getX() * imageScaleX,
            paragraphRectangle.getY() * imageScaleY,
            paragraphRectangle.getWidth() * imageScaleX,
            paragraphRectangle.getHeight() * imageScaleY
    );

    // Вычислить координаты и размер выходного изображения (минимальный размер — 1x1 пиксель).
    int imageX = (int) Math.floor(paragraphRectangle.getX());
    int imageY = (int) Math.floor(paragraphRectangle.getY());
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.getWidth()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.getHeight()));

    // Обрезать растровое изображение формы, чтобы получить только растровое изображение абзаца.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Вопросы и ответы**

**Можно ли полностью отключить перенос строк внутри текстового фрейма?**

Да. Используйте настройку переноса текста фрейма ([setWrapText](https://reference.aspose.com/slides/ru/java/com.aspose.slides/textframeformat/#setWrapText-byte-)), чтобы отключить перенос — строки не будут разрываться у границ фрейма.

**Как получить точные границы конкретного абзаца на слайде?**

Можно получить прямоугольник, ограничивающий абзац (и даже отдельный фрагмент), чтобы знать его точное положение и размер на слайде.

**Где управляется выравнивание абзаца (лево/право/центр/по ширине)?**

[Alignment](https://reference.aspose.com/slides/ru/java/com.aspose.slides/paragraphformat/#setAlignment-int-) — это настройка уровня абзаца в [ParagraphFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/paragraphformat/); она применяется ко всему абзацу независимо от отдельного форматирования фрагментов.

**Можно ли задать язык проверки правописания только для части абзаца (например, одного слова)?**

Да. Язык задаётся на уровне фрагмента ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/ru/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)), поэтому в одном абзаце могут сосуществовать несколько языков.