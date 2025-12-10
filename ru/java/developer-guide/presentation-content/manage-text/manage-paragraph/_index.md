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
description: "Освойте форматирование абзацев с Aspose.Slides для Java — оптимизируйте выравнивание, интервалы и стиль в презентациях PPT, PPTX и ODP на Java."
---

Aspose.Slides предоставляет все интерфейсы и классы, необходимые для работы с текстом, абзацами и фрагментами PowerPoint в Java.

* Aspose.Slides предоставляет интерфейс [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/), позволяющий добавлять объекты, представляющие абзац. Объект `ITextFame` может содержать один или несколько абзацев (каждый абзац создаётся переводом строки).
* Aspose.Slides предоставляет интерфейс [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/), позволяющий добавлять объекты, представляющие фрагменты. Объект `IParagraph` может содержать один или несколько фрагментов (коллекцию объектов iPortions).
* Aspose.Slides предоставляет интерфейс [IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/), позволяющий добавлять объекты, представляющие текст и его свойства форматирования.

Объект `IParagraph` способен обрабатывать тексты с различными свойствами форматирования через свои вложенные объекты `IPortion`.

## **Добавление нескольких абзацев, содержащих несколько фрагментов**

Эти шаги покажут, как добавить текстовый фрейм, содержащий 3 абзаца, и каждый абзац содержащий по 3 фрагмента:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Получите ссылку на нужный слайд по его индексу.
3. Добавьте прямоугольную [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) на слайд.
4. Получите ITextFrame, связанный с [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/).
5. Создайте два объекта [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) и добавьте их в коллекцию `IParagraphs` объекта [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/).
6. Создайте три объекта [IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/) для каждого нового `IParagraph` (два объекта Portion для абзаца по умолчанию) и добавьте каждый объект `IPortion` в коллекцию IPortion соответствующего `IParagraph`.
7. Задайте текст для каждого фрагмента.
8. Примените желаемые свойства форматирования к каждому фрагменту, используя свойства форматирования, доступные в объекте `IPortion`.
9. Сохраните изменённую презентацию.

Этот Java‑код реализует шаги по добавлению абзацев, содержащих фрагменты:
```java
// Создать экземпляр класса Presentation, представляющего файл PPTX
Presentation pres = new Presentation();
try {
    // Доступ к первому слайду
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

    // Сохранить PPTX на диск
    pres.save("multiParaPort_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Управление маркерами абзацев**

Маркированные списки помогают быстро и эффективно организовать и представить информацию. Абзацы с маркерами всегда проще читать и понимать.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Получите ссылку на нужный слайд по его индексу.
3. Добавьте [autoshape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) на выбранный слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) автoshape.
5. Удалите абзац по умолчанию в `TextFrame`.
6. Создайте первый экземпляр абзаца, используя класс [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/).
7. Установите для абзаца тип маркера `Type` равным `Symbol` и задайте символ маркера.
8. Задайте `Text` абзаца.
9. Установите `Indent` абзаца для маркера.
10. Задайте цвет маркера.
11. Задайте высоту маркера.
12. Добавьте новый абзац в коллекцию абзацев `TextFrame`.
13. Добавьте второй абзац и повторите процесс, указанный в шагах 7‑13.
14. Сохраните презентацию.

Этот Java‑код демонстрирует, как добавить маркер к абзацу:
```java
// Создает экземпляр класса Presentation, представляющего файл PPTX
Presentation pres = new Presentation();
try {
    // Получает первый слайд
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Добавляет и получает AutoShape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Получает текстовый фрейм авток формы
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

    // Устанавливает тип маркера абзаца и стиль
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


## **Управление графическими маркерами**

Маркированные списки помогают быстро и эффективно организовать и представить информацию. Абзацы с изображениями легко читать и понимать.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Получите ссылку на нужный слайд по его индексу.
3. Добавьте [autoshape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) на слайд.
4. Добавьте и получите доступ к [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) автoshape.
5. Удалите абзац по умолчанию в `ITextFrame`.
6. Создайте первый экземпляр абзаца, используя класс [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/).
7. Загрузите изображение в [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/).
8. Установите тип маркера как [Picture](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) и задайте изображение.
9. Задайте `Text` абзаца.
10. Установите `Indent` абзаца для маркера.
11. Задайте цвет маркера.
12. Задайте высоту маркера.
13. Добавьте новый абзац в коллекцию абзацев `TextFrame`.
14. Добавьте второй абзац и повторите процесс, основываясь на предыдущих шагах.
15. Сохраните изменённую презентацию.

Этот Java‑код демонстрирует, как добавить и управлять графическими маркерами:
```java
// Создает экземпляр класса Presentation, представляющего файл PPTX
Presentation presentation = new Presentation();
try {
    // Получает первый слайд
    ISlide slide = presentation.getSlides().get_Item(0);

    // Создает изображение для маркеров
    IPPImage picture;
    IImage image = Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // Добавляет и получает AutoShape
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Получает текстовый фрейм авток формы
    ITextFrame textFrame = autoShape.getTextFrame();

    // Удаляет абзац по умолчанию
    textFrame.getParagraphs().removeAt(0);

    // Создает новый абзац
    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");

    // Устанавливает стиль маркера абзаца и изображение
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // Устанавливает высоту маркера
    paragraph.getParagraphFormat().getBullet().setHeight(100);

    // Добавляет абзац в текстовый фрейм
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

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Получите ссылку на нужный слайд по его индексу.
3. Добавьте [autoshape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) в новый слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) автoshape.
5. Удалите абзац по умолчанию в `TextFrame`.
6. Создайте первый экземпляр абзаца через класс [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/) и задайте глубину 0.
7. Создайте второй экземпляр абзаца через класс `Paragraph` и задайте глубину 1.
8. Создайте третий экземпляр абзаца через класс `Paragraph` и задайте глубину 2.
9. Создайте четвёртый экземпляр абзаца через класс `Paragraph` и задайте глубину 3.
10. Добавьте новые абзацы в коллекцию абзацев `TextFrame`.
11. Сохраните изменённую презентацию.

Этот Java‑код демонстрирует, как добавить и управлять многоуровневыми маркерами:
```java
// Создает экземпляр класса Presentation, представляющего файл PPTX
Presentation pres = new Presentation();
try {
    // Получает первый слайд
    ISlide slide = pres.getSlides().get_Item(0);

    // Добавляет и получает AutoShape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Получает текстовый фрейм созданного AutoShape
    ITextFrame text = aShp.addTextFrame("");

    // Очищает абзац по умолчанию
    text.getParagraphs().clear();

    // Adds the first paragraph
    IParagraph para1 = new Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Устанавливает уровень маркера
    para1.getParagraphFormat().setDepth((short)0);

    // Adds the second paragraph
    IParagraph para2 = new Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Устанавливает уровень маркера
    para2.getParagraphFormat().setDepth((short)1);

    // Adds the third paragraph
    IParagraph para3 = new Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Устанавливает уровень маркера
    para3.getParagraphFormat().setDepth((short)2);

    // Adds the fourth paragraph
    IParagraph para4 = new Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Устанавливает уровень маркера
    para4.getParagraphFormat().setDepth((short)3);

    // Adds paragraphs to collection
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);

    // Writes the presentation as a PPTX file
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Управление абзацем с пользовательским нумерованным списком**

Интерфейс [IBulletFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/) предоставляет свойство [NumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) и другие, позволяющие управлять абзацами с пользовательской нумерацией или форматированием.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Получите слайд, содержащий абзац.
3. Добавьте [autoshape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) на слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) автoshape.
5. Удалите абзац по умолчанию в `TextFrame`.
6. Создайте первый экземпляр абзаца через класс [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/) и задайте [NumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) равным 2.
7. Создайте второй экземпляр абзаца через класс `Paragraph` и задайте `NumberedBulletStartWith` равным 3.
8. Создайте третий экземпляр абзаца через класс `Paragraph` и задайте `NumberedBulletStartWith` равным 7.
9. Добавьте новые абзацы в коллекцию абзацев `TextFrame`.
10. Сохраните изменённую презентацию.

Этот Java‑код демонстрирует, как добавить и управлять абзацами с пользовательской нумерацией или форматированием:
```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Получает текстовый фрейм созданного AutoShape
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


## **Установить отступ абзаца**

1. Создайте экземпляр [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) класса.
2. Получите ссылку на нужный слайд по его индексу.
3. Добавьте прямоугольный [autoshape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) к слайду.
4. Добавьте [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) с тремя абзацами к прямоугольному автoshape.
5. Скройте линии прямоугольника.
6. Установите отступ для каждого [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/) через их свойство BulletOffset.
7. Сохраните изменённую презентацию в файл PPT.

Этот Java‑код демонстрирует, как установить отступ абзаца:
```java
// Создайте экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    // Получите первый слайд
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Добавьте форму прямоугольника
    IAutoShape rect = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 150);
    
    // Добавьте TextFrame к прямоугольнику
    ITextFrame tf = rect.addTextFrame("This is first line \rThis is second line \rThis is third line");
    
    // Установите автоматический размер текста под форму
    tf.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    
    // Скрыть линии прямоугольника
    rect.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    
    // Получите первый абзац в TextFrame и установите его отступ
    IParagraph para1 = tf.getParagraphs().get_Item(0);
    // Установка стиля маркера абзаца и символа
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().setAlignment(TextAlignment.Left);
    
    para1.getParagraphFormat().setDepth((short)2);
    para1.getParagraphFormat().setIndent(30);
    
    // Получите второй абзац в TextFrame и установите его отступ
    IParagraph para2 = tf.getParagraphs().get_Item(1);
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar((char)8226);
    para2.getParagraphFormat().setAlignment(TextAlignment.Left);
    para2.getParagraphFormat().setDepth((short)2);
    para2.getParagraphFormat().setIndent(40);
    
    // Получите третий абзац в TextFrame и установите его отступ
    IParagraph para3 = tf.getParagraphs().get_Item(2);
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().setAlignment(TextAlignment.Left);
    para3.getParagraphFormat().setDepth((short)2);
    para3.getParagraphFormat().setIndent(50);
    
    // Сохраните презентацию на диск
    pres.save("InOutDent_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Установить висячий отступ для абзаца**

Этот Java‑код демонстрирует, как установить висячий отступ для абзаца:
```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 250, 550, 150);

    Paragraph para1 = new Paragraph();
    para1.setText("Example");

    Paragraph para2 = new Paragraph();
    para2.setText("Set Hanging Indent for Paragraph");

    Paragraph para3 = new Paragraph();
    para3.setText("This code shows you how to set the hanging indent for a paragraph: ");

    para2.getParagraphFormat().setMarginLeft(10f);
    para3.getParagraphFormat().setMarginLeft(20f);

    autoShape.getTextFrame().getParagraphs().add(para1);
    autoShape.getTextFrame().getParagraphs().add(para2);
    autoShape.getTextFrame().getParagraphs().add(para3);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Управление свойствами End в абзаце**

1. Создайте экземпляр [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) класса.
2. Получите ссылку на слайд, содержащий абзац, по его позиции.
3. Добавьте прямоугольный [autoshape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) к слайду.
4. Добавьте [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) с двумя абзацами к прямоугольнику.
5. Установите `FontHeight` и тип шрифта для абзацев.
6. Установите свойства End для абзацев.
7. Сохраните изменённую презентацию в файл PPTX.

Этот Java‑код демонстрирует, как установить свойства End для абзацев в PowerPoint:
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

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Получите ссылку на нужный слайд по его индексу.
3. Добавьте [autoshape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) на слайд.
4. Добавьте и получите доступ к [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) автoshape.
5. Удалите абзац по умолчанию в `ITextFrame`.
6. Прочитайте исходный HTML‑файл с помощью TextReader.
7. Создайте первый экземпляр абзаца через класс [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/).
8. Добавьте содержимое HTML‑файла, прочитанного TextReader, в [ParagraphCollection](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/) TextFrame.
9. Сохраните изменённую презентацию.

Этот Java‑код реализует шаги по импорту HTML‑текстов в абзацы:
```java
// Создать пустой экземпляр презентации
Presentation pres = new Presentation();
try {
    // Получить первый слайд презентации по умолчанию
    ISlide slide = pres.getSlides().get_Item(0);

    // Добавление AutoShape для размещения HTML‑контента
    IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
            (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

    ashape.getFillFormat().setFillType(FillType.NoFill);

    // Добавление текстового фрейма к фигуре
    ashape.addTextFrame("");

    // Очистка всех абзацев в добавленном текстовом фрейме
    ashape.getTextFrame().getParagraphs().clear();

    // Загрузка HTML‑файла с помощью StreamReader
    TextReader tr = new StreamReader("file.html");

    // Добавление текста из HTML‑потока в текстовый фрейм
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // Сохранение презентации
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Экспорт текста абзаца в HTML**

Aspose.Slides предоставляет расширенную поддержку экспорта текстов (содержащихся в абзацах) в HTML.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) и загрузите нужную презентацию.
2. Получите ссылку на нужный слайд по его индексу.
3. Получите форму, содержащую текст, который будет экспортирован в HTML.
4. Получите [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/) формы.
5. Создайте экземпляр `StreamWriter` и добавьте новый HTML‑файл.
6. Укажите начальный индекс для StreamWriter и экспортируйте выбранные абзацы.

Этот Java‑код демонстрирует, как экспортировать тексты абзацев PowerPoint в HTML:
```java
// Загрузить файл презентации
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // Получить первый слайд презентации по умолчанию
    ISlide slide = pres.getSlides().get_Item(0);

    // Требуемый индекс
    int index = 0;

    // Доступ к добавленной фигуре
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // Создание выходного HTML‑файла
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    //Извлечение первого абзаца в формате HTML
    // Запись данных абзацев в HTML, указывая начальный индекс абзаца и количество копируемых абзацев
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Сохранить абзац как изображение**

В этом разделе мы рассмотрим два примера, демонстрирующие, как сохранить текстовый абзац, представленный интерфейсом [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/), в виде изображения. Оба примера включают получение изображения формы, содержащей абзац, с помощью методов `getImage` из интерфейса [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/), вычисление границ абзаца внутри формы и экспорт его как растрового изображения. Эти подходы позволяют извлекать отдельные части текста из презентаций PowerPoint и сохранять их как отдельные изображения, что может быть полезно в различных сценариях.

Предположим, что у нас есть файл презентации sample.pptx с одним слайдом, где первая форма — текстовое поле, содержащее три абзаца.

![The text box with three paragraphs](paragraph_to_image_input.png)

**Example 1**

В этом примере мы получаем второй абзац в виде изображения. Для этого извлекаем изображение формы с первого слайда презентации, затем вычисляем границы второго абзаца в текстовом фрейме формы. Абзац затем перерисовывается на новое растровое изображение, которое сохраняется в формате PNG. Этот метод особенно полезен, когда нужно сохранить конкретный абзац как отдельное изображение, сохранив точные размеры и форматирование текста.
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


Результат:

![The paragraph image](paragraph_to_image_output.png)

**Example 2**

В этом примере мы расширяем предыдущий подход, добавляя коэффициенты масштабирования к изображению абзаца. Форма извлекается из презентации и сохраняется как изображение с коэффициентом масштабирования `2`. Это позволяет получить изображение более высокого разрешения при экспорте абзаца. Затем границы абзаца вычисляются с учётом масштаба. Масштабирование может быть особенно полезно, когда требуется более детализированное изображение, например, для использования в печатных материалах высокого качества.
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


## **FAQ**

**Могу ли я полностью отключить перенос строк внутри текстового фрейма?**

Да. Используйте настройку переноса текста у текстового фрейма ([setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setWrapText-byte-)), чтобы отключить перенос, и строки не будут разрываться у краёв фрейма.

**Как получить точные границы конкретного абзаца на слайде?**

Можно получить ограничивающий прямоугольник абзаца (и даже отдельного фрагмента), чтобы знать его точное положение и размер на слайде.

**Где управляется выравнивание абзаца (влево/вправо/по центру/по ширине)?**

[Alignment](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphformat/#setAlignment-int-) — это настройка уровня абзаца в [ParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphformat/); она применяется ко всему абзацу независимо от форматирования отдельных фрагментов.

**Могу ли я установить язык проверки орфографии только для части абзаца (например, одного слова)?**

Да. Язык задаётся на уровне фрагмента ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)), поэтому в одном абзаце могут сосуществовать несколько языков.