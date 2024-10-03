---
title: Управление абзацем PowerPoint в Java
type: docs
weight: 40
url: /ru/androidjava/manage-paragraph/
keywords: "Добавить абзац PowerPoint, Управление абзацами, Отступ абзаца, Свойства абзаца, HTML текст, Экспорт текста абзаца, Презентация PowerPoint, Java, Aspose.Slides для Android через Java"
description: "Создание и управление абзацем, текстом, отступом и свойствами в презентациях PowerPoint на Java"
---

Aspose.Slides предоставляет все интерфейсы и классы, необходимые для работы с текстами, абзацами и частями PowerPoint в Java.

* Aspose.Slides предоставляет интерфейс [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/), который позволяет добавлять объекты, представляющие абзац. Объект `ITextFame` может содержать один или несколько абзацев (каждый абзац создается с помощью переноса строки).
* Aspose.Slides предоставляет интерфейс [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/), который позволяет добавлять объекты, представляющие части текста. Объект `IParagraph` может содержать одну или несколько частей (коллекция объектов iPortions).
* Aspose.Slides предоставляет интерфейс [IPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/), который позволяет добавлять объекты, представляющие текст и его форматирующие свойства.

Объект `IParagraph` может работать с текстами с различными форматирующими свойствами через свои базовые объекты `IPortion`.

## **Добавить несколько абзацев, содержащих несколько частей**

Эти шаги покажут вам, как добавить текстовое поле, содержащее 3 абзаца, каждый из которых содержит 3 части:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Получите ссылку на соответствующий слайд через его индекс.
3. Добавьте прямоугольник [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) на слайд.
4. Получите ITextFrame, связанное с [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/).
5. Создайте два объекта [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/) и добавьте их в коллекцию `IParagraphs` объекта [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/).
6. Создайте три объекта [IPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/) для каждого нового `IParagraph` (два объекта Portion для абзаца по умолчанию) и добавьте каждый объект `IPortion` в коллекцию IPortion каждого `IParagraph`.
7. Установите текст для каждой части.
8. Примените свои предпочтительные функции форматирования к каждой части, используя свойства форматирования, предоставленные объектом `IPortion`.
9. Сохраните измененную презентацию.

Этот код Java является реализацией шагов по добавлению абзацев, содержащих части:

```java
// Создание экземпляра класса Presentation, представляющего файл PPTX
Presentation pres = new Presentation();
try {
    // Доступ к первому слайду
    ISlide slide = pres.getSlides().get_Item(0);

    // Добавление автофигуры типа Прямоугольник
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // Доступ к TextFrame автофигуры
    ITextFrame tf = ashp.getTextFrame();

    // Создание абзацев и частей с разными текстовыми форматами
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

    //Запись PPTX на диск
    pres.save("multiParaPort_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Управление маркерами абзаца**

Списки с маркерами помогают упорядочить и быстро представить информацию. Абзацы с маркерами всегда легче читать и понимать.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Получите ссылку на соответствующий слайд через его индекс.
3. Добавьте [автофигуру](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) на выбранный слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) автофигуры.
5. Удалите абзац по умолчанию в `TextFrame`.
6. Создайте экземпляр первого абзаца с использованием класса [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/).
7. Установите тип маркера для абзаца на `Symbol` и задайте символ маркера.
8. Установите текст абзаца.
9. Установите отступ абзаца для маркера.
10. Установите цвет для маркера.
11. Установите высоту маркера.
12. Добавьте новый абзац в коллекцию абзацев `TextFrame`.
13. Добавьте второй абзац и повторите процесс, указанный в пунктах 7-13.
14. Сохраните презентацию.

Этот код Java показывает, как добавить маркер абзаца:

```java
// Создание экземпляра класса Presentation, представляющего файл PPTX
Presentation pres = new Presentation();
try {
    // Доступ к первому слайду
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Добавление и доступ к автофигуре
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Доступ к текстовому кадру автофигуры
    ITextFrame txtFrm = aShp.getTextFrame();

    // Удаление абзаца по умолчанию
    txtFrm.getParagraphs().removeAt(0);

    // Создание абзаца
    Paragraph para = new Paragraph();

    // Установка стиля маркера абзаца и символа
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char)8226);

    // Установка текста абзаца
    para.setText("Добро пожаловать в Aspose.Slides");

    // Установка отступа маркера
    para.getParagraphFormat().setIndent(25);

    // Установка цвета маркера
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // установка IsBulletHardColor в true для использования собственного цвета маркера

    // Установка высоты маркера
    para.getParagraphFormat().getBullet().setHeight(100);

    // Добавление абзаца в текстовый кадр
    txtFrm.getParagraphs().add(para);

    // Создание второго абзаца
    Paragraph para2 = new Paragraph();

    // Установка типа и стиля маркера абзаца
    para2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);

    // Добавление текста абзаца
    para2.setText("Это нумерованный маркер");

    // Установка отступа маркера
    para2.getParagraphFormat().setIndent(25);

    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // установка IsBulletHardColor в true для использования собственного цвета маркера

    // Установка высоты маркера
    para2.getParagraphFormat().getBullet().setHeight(100);

    // Добавление абзаца в текстовый кадр
    txtFrm.getParagraphs().add(para2);
    
    // Сохранение измененной презентации
    pres.save("Bullet_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Управление изображениями маркеров**

Списки с маркерами помогают упорядочить и быстро представить информацию. Абзацы с изображениями легко читать и понимать.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Получите ссылку на соответствующий слайд через его индекс.
3. Добавьте [автофигуру](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) на слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) автофигуры.
5. Удалите абзац по умолчанию в `TextFrame`.
6. Создайте экземпляр первого абзаца с использованием класса [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/).
7. Загрузите изображение в [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/).
8. Установите тип маркера на [Picture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) и задайте изображение.
9. Установите текст абзаца.
10. Установите отступ абзаца для маркера.
11. Установите цвет для маркера.
12. Установите высоту для маркера.
13. Добавьте новый абзац в коллекцию абзацев `TextFrame`.
14. Добавьте второй абзац и повторите процесс в соответствии с предыдущими шагами.
15. Сохраните измененную презентацию.

Этот код Java показывает, как добавлять и управлять маркерами изображений:

```java
// Создание экземпляра класса Presentation, представляющего файл PPTX
Presentation presentation = new Presentation();
try {
    // Доступ к первому слайду
    ISlide slide = presentation.getSlides().get_Item(0);

    // Создание изображения для маркеров
    IPPImage picture;
    IImage image = Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // Добавление и доступ к автофигуре
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Доступ к текстовому кадру автофигуры
    ITextFrame textFrame = autoShape.getTextFrame();

    // Удалить абзац по умолчанию
    textFrame.getParagraphs().removeAt(0);

    // Создание нового абзаца
    Paragraph paragraph = new Paragraph();
    paragraph.setText("Добро пожаловать в Aspose.Slides");

    // Установка стиля маркера абзаца и изображения
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // Установка высоты маркера
    paragraph.getParagraphFormat().getBullet().setHeight(100);

    // Добавление абзаца в текстовый кадр
    textFrame.getParagraphs().add(paragraph);

    // Запись презентации в формате PPTX
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

    // Запись презентации в формате PPT
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **Управление многоуровневыми маркерами**

Списки с маркерами помогают упорядочить и быстро представить информацию. Многоуровневые маркеры легко читать и понимать.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Получите ссылку на соответствующий слайд через его индекс.
3. Добавьте [автофигуру](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) на новый слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) автофигуры.
5. Удалите абзац по умолчанию в `TextFrame`.
6. Создайте экземпляр первого абзаца через класс [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/) и установите уровень на 0.
7. Создайте экземпляр второго абзаца через класс `Paragraph` и установите уровень на 1.
8. Создайте экземпляр третьего абзаца через класс `Paragraph` и установите уровень на 2.
9. Создайте экземпляр четвертого абзаца через класс `Paragraph` и установите уровень на 3.
10. Добавьте новые абзацы в коллекцию абзацев `TextFrame`.
11. Сохраните измененную презентацию.

Этот код Java показывает, как добавлять и управлять многоуровневыми маркерами:

```java
// Создание экземпляра класса Presentation, представляющего файл PPTX
Presentation pres = new Presentation();
try {
    // Доступ к первому слайду
    ISlide slide = pres.getSlides().get_Item(0);

    // Добавление и доступ к автофигуре
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Доступ к текстовому кадру созданной автофигуры
    ITextFrame text = aShp.addTextFrame("");

    // Очистка абзаца по умолчанию
    text.getParagraphs().clear();

    // Добавление первого абзаца
    IParagraph para1 = new Paragraph();
    para1.setText("Содержимое");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Установка уровня маркера
    para1.getParagraphFormat().setDepth((short)0);

    // Добавление второго абзаца
    IParagraph para2 = new Paragraph();
    para2.setText("Второй уровень");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Установка уровня маркера
    para2.getParagraphFormat().setDepth((short)1);

    // Добавление третьего абзаца
    IParagraph para3 = new Paragraph();
    para3.setText("Третий уровень");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Установка уровня маркера
    para3.getParagraphFormat().setDepth((short)2);

    // Добавление четвертого абзаца
    IParagraph para4 = new Paragraph();
    para4.setText("Четвертый уровень");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Установка уровня маркера
    para4.getParagraphFormat().setDepth((short)3);

    // Добавление абзацев в коллекцию
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);

    // Запись презентации в файл PPTX
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Управление абзацем с пользовательским нумерованным списком**

Интерфейс [IBulletFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/) предоставляет свойство [NumberedBulletStartWith](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) и другие, которые позволяют управлять абзацами с пользовательской нумерацией или форматированием.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Получите ссылку на слайд, содержащий абзац.
3. Добавьте [автофигуру](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) на слайд.
4. Доступ к [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) автофигуры.
5. Удалите абзац по умолчанию в `TextFrame`.
6. Создайте экземпляр первого абзаца через класс [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/) и установите [NumberedBulletStartWith](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) на 2.
7. Создайте экземпляр второго абзаца через класс `Paragraph` и установите `NumberedBulletStartWith` на 3.
8. Создайте экземпляр третьего абзаца через класс `Paragraph` и установите `NumberedBulletStartWith` на 7.
9. Добавьте новые абзацы в коллекцию абзацев `TextFrame`.
10. Сохраните измененную презентацию.

Этот код Java показывает, как добавлять и управлять абзацами с пользовательской нумерацией или форматированием:

```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Доступ к текстовому кадру созданной автофигуры
    ITextFrame textFrame = shape.getTextFrame();

    // Удаление абзаца по умолчанию
    textFrame.getParagraphs().removeAt(0);

    // Первый список
    Paragraph paragraph1 = new Paragraph();
    paragraph1.setText("маркер 2");
    paragraph1.getParagraphFormat().setDepth((short)4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)2);
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.setText("маркер 3");
    paragraph2.getParagraphFormat().setDepth((short)4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)3);
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph2);


    Paragraph paragraph5 = new Paragraph();
    paragraph5.setText("маркер 7");
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

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Получите ссылку на соответствующий слайд через его индекс.
1. Добавьте прямоугольник [автофигуру](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) на слайд.
1. Добавьте [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) с тремя абзацами в прямоугольник автофигуры.
1. Скрыть линии прямоугольника.
1. Установите отступ для каждого [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/) через свойство BulletOffset.
1. Запишите измененную презентацию в формате PPT.

Этот код Java показывает, как установить отступ абзаца:

```java
// Создание экземпляра класса Presentation
Presentation pres = new Presentation();
try {
    // Получение первого слайда
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Добавление формы прямоугольника
    IAutoShape rect = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 150);
    
    // Добавление TextFrame к прямоугольнику
    ITextFrame tf = rect.addTextFrame("Это первая строка \rЭто вторая строка \rЭто третья строка");
    
    // Установите текст так, чтобы он подходил к форме
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
    
    //Запись презентации на диск
    pres.save("InOutDent_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Установить висячий отступ для абзаца**

Этот код Java показывает, как установить висячий отступ для абзаца:

```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 250, 550, 150);

    Paragraph para1 = new Paragraph();
    para1.setText("Пример");

    Paragraph para2 = new Paragraph();
    para2.setText("Установить висячий отступ для абзаца");

    Paragraph para3 = new Paragraph();
    para3.setText("Этот код C# показывает, как установить висячий отступ для абзаца: ");

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

## **Управление свойствами конечного абзаца для абзаца**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
2. Получите ссылку на слайд, содержащий абзац, через его положение.
3. Добавьте прямоугольник [автофигуру](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) на слайд.
4. Добавьте [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) с двумя абзацами в прямоугольник.
5. Установите `FontHeight` и шрифт для абзацев.
6. Установите конечные свойства для абзацев.
7. Запишите измененную презентацию в файл PPTX.

Этот код Java показывает, как установить конечные свойства для абзацев в PowerPoint: 

```java
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);

    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("Пример текста"));

    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("Пример текста 2"));

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


## **Импортировать HTML текст в абзацы**

Aspose.Slides предоставляет улучшенную поддержку импорта HTML текста в абзацы.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
2. Получите ссылку на соответствующий слайд через его индекс.
3. Добавьте [автофигуру](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) на слайд.
4. Добавьте и получите доступ к `автофигуре` [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/).
5. Удалите абзац по умолчанию в `ITextFrame`.
6. Прочитайте исходный HTML файл в TextReader.
7. Создайте экземпляр первого абзаца через класс [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/).
8. Добавьте содержимое HTML файла в считываемый TextReader в коллекцию [ParagraphCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphcollection/).
9. Сохраните измененную презентацию.

Этот код Java является реализацией шагов по импорту HTML текстов в абзацы:

```java
// Создание пустого экземпляра презентации
Presentation pres = new Presentation();
try {
    // Доступ к первому слайду презентации
    ISlide slide = pres.getSlides().get_Item(0);

    // Добавление автофигуры для размещения HTML содержимого
    IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
            (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

    ashape.getFillFormat().setFillType(FillType.NoFill);

    // Добавление текстового кадра к форме
    ashape.addTextFrame("");

    // Очистка всех абзацев в добавленном текстовом кадре
    ashape.getTextFrame().getParagraphs().clear();

    // Загрузка HTML файла с помощью счетчика потоков
    TextReader tr = new StreamReader("file.html");

    // Добавление текста из HTML счетчика в текстовый кадр
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // Сохранение презентации
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Экспорт текста абзацев в HTML**

Aspose.Slides предоставляет улучшенную поддержку экспорта текстов (содержащихся в абзацах) в HTML.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) и загрузите нужную презентацию.
2. Получите ссылку на соответствующий слайд через его индекс.
3. Получите доступ к фигуре, содержащей текст, который будет экспортирован в HTML.
4. Получите текстовый [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/).
5. Создайте экземпляр `StreamWriter` и добавьте новый HTML файл.
6. Установите начальный индекс для StreamWriter и экспортируйте свои предпочтительные абзацы.

Этот код Java показывает, как экспортировать текст абзацев PowerPoint в HTML:

```java
// Загрузка файла презентации
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // Доступ к первому слайду презентации
    ISlide slide = pres.getSlides().get_Item(0);

    // Желаемый индекс
    int index = 0;

    // Доступ к добавленной фигуре
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // Создание выходного HTML файла
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    // Извлечение первого абзаца в качестве HTML
    // Запись данных абзацев в HTML, указав начальный индекс абзаца, общее количество абзацев для копирования
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```