---
title: Управление маркерами
type: docs
weight: 60
url: /ru/java/manage-bullet/
keywords: "Маркеры, Списки с маркерами, Номера, Нумерованные списки, Изображения маркеров, многоуровневые маркеры, Презентация PowerPoint, Java, Aspose.Slides для Java"
description: "Создайте списки с маркерами и нумерованные списки в презентации PowerPoint на Java"
---

В **Microsoft PowerPoint** вы можете создавать списки с маркерами и нумерованные списки так же, как и в Word и других текстовых редакторах. **Aspose.Slides для Java** также позволяет использовать маркеры и номера на слайдах ваших презентаций.

## Зачем использовать списки с маркерами?

Списки с маркерами помогают организовать и быстро представить информацию.

**Пример списка с маркерами**

В большинстве случаев список с маркерами выполняет три основные функции:

- привлекает внимание ваших читателей или зрителей к важной информации
- позволяет вашим читателям или зрителям легко находить ключевые моменты
- эффективно передает и доставляет важные детали.

## Зачем использовать нумерованные списки?

Нумерованные списки также помогают в организации и представлении информации. В идеале вы должны использовать номера (вместо маркеров), когда порядок записей (например, *шаг 1, шаг 2* и т.д.) имеет значение или когда запись должна быть упомянута (например, *см. шаг 3*).

**Пример нумерованного списка**

Это сводка шагов (шаг 1 до шага 15) в процедуре **Создание маркеров** ниже:

1. Создайте экземпляр класса презентации.
2. Выполните несколько задач (шаги 3 до 14).
3. Сохраните презентацию.

## Создание маркеров
Эта тема также является частью серии тем управления текстовыми абзацами. Эта страница покажет, как мы можем управлять маркерами абзаций. Маркеры более полезны, когда что-то нужно описать по шагам. Более того, текст выглядит хорошо организованным с использованием маркеров. Абзацы с маркерами всегда легче читать и понимать. Мы увидим, как разработчики могут использовать эту небольшую, но мощную функцию Aspose.Slides для Java. Пожалуйста, следуйте приведенным ниже шагам, чтобы управлять маркерами абзацев с использованием Aspose.Slides для Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Получите доступ к желаемому слайду в коллекции слайдов с помощью объекта [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide).
1. Добавьте [Автоформу](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationText) на выбранный слайд.
1. Получите доступ к [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame) добавленной фигуры.
1. Удалите стандартный абзац в TextFrame.
1. Создайте экземпляр первого абзаца с помощью класса [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/Paragraph).
1. Установите тип маркера абзаца.
1. Установите тип маркера на [Symbol](https://reference.aspose.com/slides/java/com.aspose.slides/BulletType#Symbol) и установите символ маркера.
1. Установите текст абзаца.
1. Установите отступ абзаца для установки маркера.
1. Установите цвет маркера.
1. Установите высоту маркеров.
1. Добавьте созданный абзац в коллекцию абзацев TextFrame.
1. Добавьте второй абзац и повторите процесс, изложенный в шагах **7-13**.
1. Сохраните презентацию.

Этот пример кода на Java — реализация вышеуказанных шагов — показывает, как создать список с маркерами на слайде:

```java
// Создаем экземпляр класса Presentation, представляющего файл PPTX
Presentation pres = new Presentation();
try {
    // Получаем доступ к первому слайду
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Добавляем и получаем доступ к Автоформе
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // Получаем доступ к текстовому полю созданной автоформы
    ITextFrame txtFrm = aShp.getTextFrame();
    
    // Удаляем существующий абзац
    txtFrm.getParagraphs().removeAt(0);
    
    // Создаем абзац
    Paragraph para = new Paragraph();
    
    // Устанавливаем стиль маркера абзаца и символ
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char) 8226);
    
    // Устанавливаем текст абзаца
    para.setText("Добро пожаловать в Aspose.Slides");
    
    // Устанавливаем отступ маркера
    para.getParagraphFormat().setIndent(25);
    
    // Устанавливаем цвет маркера
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    
    // Установите IsBulletHardColor в true, чтобы использовать свой цвет маркера
    para.getParagraphFormat().getBullet().isBulletHardColor();
    
    // Устанавливаем высоту маркера
    para.getParagraphFormat().getBullet().setHeight(100);
    
    // Добавляем абзац в текстовое поле
    txtFrm.getParagraphs().add(para);
    
    // Сохраняем презентацию в файл PPTX
    pres.save("Bullet.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## Создание изображений маркеров

Aspose.Slides для Java позволяет вам изменять маркеры в списках с маркерами. Вы можете заменить маркеры на пользовательские символы или изображения. Если вы хотите добавить визуальный интерес к списку или привлечь еще большее внимание к записям в списке, вы можете использовать свое собственное изображение в качестве маркера.

{{% alert color="primary" %}} 

В идеале, если вы собираетесь заменить обычный символ маркера изображением, вам следует выбрать простое графическое изображение с прозрачным фоном. Такие изображения лучше всего подходят в качестве пользовательских символов маркеров.

В любом случае, выбранное вами изображение будет уменьшено до очень маленького размера, поэтому мы настоятельно рекомендуем выбрать изображение, которое хорошо выглядит (в качестве замены для символа маркера) в списке. 

{{% /alert %}} 

Чтобы создать изображение маркера, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Получите доступ к желаемому слайду в коллекции слайдов с помощью объекта [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide).
1. Добавьте автоформу на выбранный слайд.
1. Получите доступ к [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) добавленной фигуры.
1. Удалите стандартный абзац в [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe).
1. Создайте экземпляр первого абзаца с помощью класса Paragraph.
1. Загрузите изображение с диска в [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IPPImage).
1. Установите тип маркера на изображение и добавьте изображение.
1. Установите текст абзаца.
1. Установите отступ абзаца для установки маркера.
1. Установите цвет маркера.
1. Установите высоту маркеров.
1. Добавьте созданный абзац в [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) коллекцию абзацев.
1. Добавьте второй абзац и повторите процесс, изложенный в предыдущих шагах.
1. Сохраните презентацию.

Этот код на Java показывает, как создать изображение маркера на слайде:

```java
Presentation pres = new Presentation();
try {
    // Получаем доступ к первому слайду
    ISlide slide = pres.getSlides().get_Item(0);

    // Создаем изображение для маркеров
    IPPImage picture;
    IImage image = Images.fromFile("asp1.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Добавляем и получаем доступ к Автоформе
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Получаем доступ к текстовому полю созданной автоформы
    ITextFrame txtFrm = aShp.getTextFrame();
    // Удаляем существующий абзац
    txtFrm.getParagraphs().removeAt(0);

    // Создаем новый абзац
    Paragraph para = new Paragraph();
    para.setText("Добро пожаловать в Aspose.Slides");

    // Устанавливаем стиль маркера абзаца и изображение
    para.getParagraphFormat().getBullet().setType(BulletType.Picture);
    para.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // Устанавливаем высоту маркера
    para.getParagraphFormat().getBullet().setHeight(100);

    // Добавляем абзац в текстовое поле
    txtFrm.getParagraphs().add(para);

    // Сохраняем презентацию в файл PPTX
    pres.save("Bullet.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## Создание многоуровневых маркеров

Чтобы создать список с маркерами, который содержит элементы на разных уровнях — дополнительные списки под основным списком маркеров — выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Получите доступ к желаемому слайду в коллекции слайдов с помощью объекта [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide).
1. Добавьте автоформу на выбранный слайд.
1. Получите доступ к [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) добавленной фигуры.
1. Удалите стандартный абзац в [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe).
1. Создайте экземпляр первого абзаца, используя класс Paragraph и установите глубину равной 0.
1. Создайте экземпляр второго абзаца, используя класс Paragraph и установите глубину равной 1.
1. Создайте экземпляр третьего абзаца, используя класс Paragraph и установите глубину равной 2.
1. Создайте экземпляр четвертого абзаца, используя класс Paragraph и установите глубину равной 3.
1. Добавьте созданные абзацы в коллекцию абзацев [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe).
1. Сохраните презентацию.

Этот код, который является реализацией вышеуказанных шагов, показывает, как создать многоуровневый список с маркерами на Java:

```java
// Создаем экземпляр класса Presentation, представляющего файл PPTX
Presentation pres = new Presentation();
try {
    // Получаем доступ к первому слайду
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Добавляем и получаем доступ к Автоформе
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // Получаем доступ к текстовому полю созданной автоформы
    ITextFrame txtFrm = aShp.addTextFrame("");
    
    // Удаляем существующий абзац
    txtFrm.getParagraphs().clear();
    
    // Создаем первый абзац
    Paragraph para1 = new Paragraph();
    // Устанавливаем стиль маркера абзаца и символ
    para1.setText("Содержание");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char) 8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Устанавливаем уровень маркера
    para1.getParagraphFormat().setDepth ((short)0);
    
    // Создаем второй абзац
    Paragraph para2 = new Paragraph();
    // Устанавливаем стиль маркера абзаца и символ
    para2.setText("Второй уровень");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Устанавливаем уровень маркера
    para2.getParagraphFormat().setDepth ((short)1);
    
    // Создаем третий абзац
    Paragraph para3 = new Paragraph();
    // Устанавливаем стиль маркера абзаца и символ
    para3.setText("Третий уровень");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char) 8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Устанавливаем уровень маркера
    para3.getParagraphFormat().setDepth ((short)2);
    
    // Создаем четвертый абзац
    Paragraph para4 = new Paragraph();
    // Устанавливаем стиль маркера абзаца и символ
    para4.setText("Четвертый уровень");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Устанавливаем уровень маркера
    para4.getParagraphFormat().setDepth ((short)3);
    
    // Добавляем абзацы в текстовое поле
    txtFrm.getParagraphs().add(para1);
    txtFrm.getParagraphs().add(para2);
    txtFrm.getParagraphs().add(para3);
    txtFrm.getParagraphs().add(para4);
    
    // Сохраняем презентацию в файл PPTX
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## Создание пользовательского нумерованного списка
Aspose.Slides для Java предоставляет простой API для управления абзацами с пользовательским форматированием номеров. Чтобы добавить пользовательский нумерованный список в абзац, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Получите доступ к желаемому слайду в коллекции слайдов с помощью объекта [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide).
1. Добавьте автоформу на выбранный слайд.
1. Получите доступ к [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) добавленной фигуры.
1. Удалите стандартный абзац в [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe).
1. Создайте экземпляр первого абзаца с помощью класса Paragraph и установите **NumberedBulletStartWith** на 2.
1. Создайте экземпляр второго абзаца с помощью класса Paragraph и установите **NumberedBulletStartWith** на 3.
1. Создайте экземпляр третьего абзаца с помощью класса Paragraph и установите **NumberedBulletStartWith** на 7.
1. Добавьте созданные абзацы в [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) коллекцию абзацев.
1. Сохраните презентацию.

Этот код на Java показывает, как создать нумерованный список на слайде:

```java
// Создаем экземпляр класса Presentation, представляющего файл PPTX
Presentation pres = new Presentation();
try {
    // Получаем доступ к первому слайду
    ISlide slide = pres.getSlides().get_Item(0);

    // Добавляем и получаем доступ к Автоформе
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Получаем доступ к текстовому полю созданной автоформы
    ITextFrame txtFrm = aShp.addTextFrame("");

    // Удаляем существующий абзац
    txtFrm.getParagraphs().clear();

    // Первый список
    Paragraph paragraph1 = new Paragraph();
    paragraph1.setText("маркер 2");
    paragraph1.getParagraphFormat().setDepth((short)4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)2);
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.setText("маркер 3");
    paragraph2.getParagraphFormat().setDepth((short)4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)3);
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph2);

    // Второй список
    Paragraph paragraph5 = new Paragraph();
    paragraph5.setText("маркер 5");
    paragraph5.getParagraphFormat().setDepth((short)4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)5);
    paragraph5.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph5);

    pres.save(resourcesOutputPath + "SetCustomBulletsNumber-slides.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```