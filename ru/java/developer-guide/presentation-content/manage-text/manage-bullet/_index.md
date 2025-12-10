---
title: Управление маркированными и нумерованными списками в презентациях с помощью Java
linktitle: Управление списками
type: docs
weight: 60
url: /ru/java/manage-bullet/
keywords:
- маркер
- маркированный список
- нумерованный список
- символьный маркер
- изображение-маркер
- пользовательский маркер
- многоуровневый список
- создать маркер
- добавить маркер
- добавить список
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Узнайте, как управлять маркированными и нумерованными списками в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для Java. Пошаговое руководство."
---

В **Microsoft PowerPoint** вы можете создавать маркированные и нумерованные списки так же, как делаете это в Word и других текстовых редакторах. **Aspose.Slides for Java** также позволяет использовать маркеры и цифры в слайдах ваших презентаций. 

## **Зачем использовать маркированные списки?**

Маркированные списки помогают быстро и эффективно организовать и представить информацию. 

**Пример маркированного списка**

В большинстве случаев маркированный список выполняет три основные функции:

- привлекает внимание читателей или зрителей к важной информации
- позволяет читателям или зрителям легко просматривать ключевые пункты
- сообщает и передаёт важные детали эффективно.

## **Зачем использовать нумерованные списки?**

Нумерованные списки также помогают в организации и представлении информации. В идеале следует использовать числа (вместо маркеров), когда порядок элементов (например, *шаг 1, шаг 2* и т.д.) важен или когда на элемент нужно ссылаться (например, *см. шаг 3*).

**Пример нумерованного списка**

Это сводка шагов (от шага 1 до шага 15) в процедуре **Создание маркеров** ниже:

1. Создайте экземпляр класса презентации.
2. Выполните несколько задач (от шага 3 до шага 14).
3. Сохраните презентацию. 

## **Создание маркеров**

Эта тема также является частью серии тем по управлению абзацами текста. На этой странице будет показано, как управлять маркерами абзацев. Маркеры более полезны, когда что‑то описывается пошагово. Кроме того, текст выглядит более упорядоченным при использовании маркеров. Маркированные абзацы всегда легче читать и понимать. Мы увидим, как разработчики могут использовать эту небольшую, но мощную возможность Aspose.Slides for Java. Пожалуйста, выполните шаги ниже для управления маркерами абзацев с помощью Aspose.Slides for Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
2. Получите нужный слайд из коллекции слайдов с помощью объекта [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide).
3. Добавьте [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationText) на выбранный слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame) добавленной фигуры.
5. Удалите абзац по умолчанию в TextFrame.
6. Создайте первый экземпляр абзаца с использованием класса [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/Paragraph).
7. Установите тип маркера для абзаца.
8. Установите тип маркера в [Symbol](https://reference.aspose.com/slides/java/com.aspose.slides/BulletType#Symbol) и задайте символ маркера.
9. Установите текст абзаца.
10. Установите отступ абзаца для размещения маркера.
11. Установите цвет маркера.
12. Установите высоту маркеров.
13. Добавьте созданный абзац в коллекцию абзацев TextFrame.
14. Добавьте второй абзац и повторите процесс, указанный в шагах **7 до 13**.
15. Сохраните презентацию.

```java
// Создать экземпляр класса Presentation, представляющего файл PPTX
Presentation pres = new Presentation();
try {
    // Получение первого слайда
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Добавление и доступ к Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // Доступ к текстовому фрейму созданного autoshape
    ITextFrame txtFrm = aShp.getTextFrame();
    
    // Удаление исходного абзаца по умолчанию
    txtFrm.getParagraphs().removeAt(0);
    
    // Создание абзаца
    Paragraph para = new Paragraph();
    
    // Установка стиля маркера абзаца и символа
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char) 8226);
    
    // Установка текста абзаца
    para.setText("Welcome to Aspose.Slides");
    
    // Установка отступа маркера
    para.getParagraphFormat().setIndent(25);
    
    // Установка цвета маркера
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    
    // Установите IsBulletHardColor в true, чтобы использовать собственный цвет маркера
    para.getParagraphFormat().getBullet().isBulletHardColor();
    
    // Установка высоты маркера
    para.getParagraphFormat().getBullet().setHeight(100);
    
    // Добавление абзаца в текстовый фрейм
    txtFrm.getParagraphs().add(para);
    
    // Сохранение презентации в файл PPTX
    pres.save("Bullet.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Создание изображений‑маркеров**

Aspose.Slides for Java позволяет изменять маркеры в маркированных списках. Вы можете заменять маркеры на пользовательские символы или изображения. Если вы хотите добавить визуальный интерес к списку или привлечь ещё больше внимания к элементам списка, вы можете использовать собственное изображение в качестве маркера. 

{{% alert color="primary" %}} 

В идеальном случае, если вы планируете заменить обычный символ маркера изображением, рекомендуется выбрать простую графику с прозрачным фоном. Такие изображения лучше всего подходят в качестве пользовательских символов маркеров. 

В любом случае выбранное изображение будет уменьшено до очень небольшого размера, поэтому настоятельно рекомендуем выбирать изображение, которое будет выглядеть хорошо (в качестве замены символа маркера) в списке. 

{{% /alert %}} 

Чтобы создать изображение‑маркер, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
2. Получите нужный слайд из коллекции слайдов с помощью объекта [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide).
3. Добавьте автоконтур (autoshape) на выбранный слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) добавленной фигуры.
5. Удалите абзац по умолчанию в [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe).
6. Создайте первый экземпляр абзаца с использованием класса Paragraph.
7. Загрузите изображение с диска в [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IPPImage).
8. Установите тип маркера в Picture и задайте изображение.
9. Установите текст абзаца.
10. Установите отступ абзаца для размещения маркера.
11. Установите цвет маркера.
12. Установите высоту маркеров.
13. Добавьте созданный абзац в коллекцию абзацев [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe).
14. Добавьте второй абзац и повторите процесс, описанный в предыдущих шагах.
15. Сохраните презентацию.

```java
Presentation pres = new Presentation();
try {
    // Получение первого слайда
    ISlide slide = pres.getSlides().get_Item(0);

    // Создание изображения для маркеров
    IPPImage picture;
    IImage image = Images.fromFile("asp1.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Добавление и доступ к Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Доступ к текстовому фрейму созданного autoshape
    ITextFrame txtFrm = aShp.getTextFrame();
    // Удаление существующего абзаца по умолчанию
    txtFrm.getParagraphs().removeAt(0);

    // Создание нового абзаца
    Paragraph para = new Paragraph();
    para.setText("Welcome to Aspose.Slides");

    // Установка стиля маркера абзаца и изображения
    para.getParagraphFormat().getBullet().setType(BulletType.Picture);
    para.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // Установка высоты маркера
    para.getParagraphFormat().getBullet().setHeight(100);

    // Добавление абзаца в текстовый фрейм
    txtFrm.getParagraphs().add(para);

    // Запись презентации в файл PPTX
    pres.save("Bullet.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Создание многоуровневых маркеров**

Чтобы создать маркированный список, содержащий элементы разных уровней — вложенные списки под основным маркером — выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
2. Получите нужный слайд из коллекции слайдов с помощью объекта [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide).
3. Добавьте автоконтур в выбранный слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) добавленной фигуры.
5. Удалите абзац по умолчанию в [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe).
6. Создайте первый экземпляр абзаца с использованием класса Paragraph и задайте глубину 0.
7. Создайте второй экземпляр абзаца с использованием класса Paragraph и задайте глубину 1.
8. Создайте третий экземпляр абзаца с использованием класса Paragraph и задайте глубину 2.
9. Создайте четвертый экземпляр абзаца с использованием класса Paragraph и задайте глубину 3.
10. Добавьте созданные абзацы в коллекцию абзацев [TextFrame] paragraph collection.
11. Сохраните презентацию.

```java
// Создать объект класса Presentation, представляющего файл PPTX
Presentation pres = new Presentation();
try {
    // Получение первого слайда
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Добавление и доступ к Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // Получение текстового фрейма созданного autoshape
    ITextFrame txtFrm = aShp.addTextFrame("");
    
    // Удаление существующего абзаца по умолчанию
    txtFrm.getParagraphs().clear();
    
    // Создание первого абзаца
    Paragraph para1 = new Paragraph();
    // Установка стиля маркера абзаца и символа
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char) 8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    //Установка уровня маркера
    para1.getParagraphFormat().setDepth ((short)0);
    
    // Создание второго абзаца
    Paragraph para2 = new Paragraph();
    // Установка стиля маркера абзаца и символа
    para2.setText("Second level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    //Установка уровня маркера
    para2.getParagraphFormat().setDepth ((short)1);
    
    // Создание третьего абзаца
    Paragraph para3 = new Paragraph();
    // Установка стиля маркера абзаца и символа
    para3.setText("Third level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char) 8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    //Установка уровня маркера
    para3.getParagraphFormat().setDepth ((short)2);
    
    // Создание четвертого абзаца
    Paragraph para4 = new Paragraph();
    // Установка стиля маркера абзаца и символа
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    //Установка уровня маркера
    para4.getParagraphFormat().setDepth ((short)3);
    
    // Добавление абзаца в текстовый фрейм
    txtFrm.getParagraphs().add(para1);
    txtFrm.getParagraphs().add(para2);
    txtFrm.getParagraphs().add(para3);
    txtFrm.getParagraphs().add(para4);
    
    // Сохранение презентации в файл PPTX
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Создание пользовательских нумерованных списков**

Aspose.Slides for Java предоставляет простой API для управления абзацами с пользовательским форматированием номеров. Чтобы добавить пользовательский нумерованный список в абзац, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
2. Получите нужный слайд из коллекции слайдов с помощью объекта [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide).
3. Добавьте автоконтур в выбранный слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) добавленной фигуры.
5. Удалите абзац по умолчанию в [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe).
6. Создайте первый экземпляр абзаца с использованием класса Paragraph и установите **NumberedBulletStartWith** в 2.
7. Создайте второй экземпляр абзаца с использованием класса Paragraph и установите **NumberedBulletStartWith** в 3.
8. Создайте третий экземпляр абзаца с использованием класса Paragraph и установите **NumberedBulletStartWith** в 7.
9. Добавьте созданные абзацы в коллекцию абзацев [TextFrame] paragraph collection.
10. Сохраните презентацию.

```java
// Создать объект класса Presentation, представляющий файл PPTX
Presentation pres = new Presentation();
try {
    // Доступ к первому слайду
    ISlide slide = pres.getSlides().get_Item(0);

    // Добавление и доступ к Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Доступ к текстовому фрейму созданного autoshape
    ITextFrame txtFrm = aShp.addTextFrame("");

    // Удаление существующего абзаца по умолчанию
    txtFrm.getParagraphs().clear();

    // Первый список
    Paragraph paragraph1 = new Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth((short)4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)2);
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth((short)4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)3);
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph2);

    // Второй список
    Paragraph paragraph5 = new Paragraph();
    paragraph5.setText("bullet 5");
    paragraph5.getParagraphFormat().setDepth((short)4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)5);
    paragraph5.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph5);

    pres.save(resourcesOutputPath + "SetCustomBulletsNumber-slides.pptx.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Можно ли экспортировать маркированные и нумерованные списки, созданные с помощью Aspose.Slides, в другие форматы, такие как PDF или изображения?**

Да, Aspose.Slides полностью сохраняет форматирование и структуру маркированных и нумерованных списков при экспорте презентаций в такие форматы, как PDF, изображения и другие, обеспечивая согласованные результаты.

**Можно ли импортировать маркированные или нумерованные списки из существующих презентаций?**

Да, Aspose.Slides позволяет импортировать и редактировать маркированные или нумерованные списки из существующих презентаций, сохраняя их исходное форматирование и внешний вид.

**Поддерживает ли Aspose.Slides маркированные и нумерованные списки в презентациях, созданных на разных языках?**

Да, Aspose.Slides полностью поддерживает многоязычные презентации, позволяя создавать маркированные и нумерованные списки на любом языке, включая использование специальных или нелатинских символов.