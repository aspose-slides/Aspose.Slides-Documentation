---
title: Управление маркерами
type: docs
weight: 60
url: /androidjava/manage-bullet/
keywords: "Маркеры, Микшерованные списки, Числа, Нумерованные списки, Изображения маркеров, многоуровневые маркеры, Презентация PowerPoint, Java, Aspose.Slides для Android через Java"
description: "Создание маркерованных и нумерованных списков в презентации PowerPoint на Java"
---

В **Microsoft PowerPoint** вы можете создать маркерованные и нумерованные списки так же, как и в Word и других текстовых редакторах. **Aspose.Slides для Android через Java** также позволяет использовать маркеры и числа в слайдах ваших презентаций.

## Почему использовать маркерованные списки?

Маркерованные списки помогают вам быстро и эффективно организовать и представить информацию.

**Пример маркерованного списка**

В большинстве случаев маркерованный список выполняет эти три основные функции:

- привлекает внимание ваших читателей или зрителей к важной информации
- позволяет вашим читателям или зрителям легко находить ключевые моменты
- эффективно передает важные детали.

## Почему использовать нумерованные списки?

Нумерованные списки также помогают в организации и представлении информации. В идеале, вы должны использовать числа (вместо маркеров), когда важен порядок записей (например, *шаг 1, шаг 2* и т.д.) или когда запись должна быть упомянута (например, *см. шаг 3*).

**Пример нумерованного списка**

Это сводка шагов (шаг 1 до шага 15) в процедуре **Создание маркеров** ниже:

1. Создайте экземпляр класса презентации. 
2. Выполните несколько задач (шаги 3 до 14).
3. Сохраните презентацию. 

## Создание маркеров
Эта тема также является частью серии тем по управлению текстовыми абзацами. Эта страница покажет, как мы можем управлять маркерами абзацев. Маркеры более полезны, когда что-то описывается в пошаговом порядке. Более того, текст выглядит хорошо организованным при использовании маркеров. Маркерованные абзацы всегда легче читать и понимать. Мы увидим, как разработчики могут использовать эту небольшую, но мощную функцию Aspose.Slides для Android через Java. Пожалуйста, следуйте шагам ниже, чтобы управлять маркерами абзацев, используя Aspose.Slides для Android через Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Получите доступ к нужному слайду в коллекции слайдов, используя объект [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide).
1. Добавьте [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationText) на выбранный слайд.
1. Получите доступ к [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) добавленной формы.
1. Удалите стандартный абзац в TextFrame.
1. Создайте первый экземпляр абзаца, используя класс [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Paragraph).
1. Установите тип маркера для абзаца.
1. Установите тип маркера на [Symbol](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BulletType#Symbol) и установите символ маркера.
1. Установите текст абзаца.
1. Установите отступ абзаца, чтобы установить маркер.
1. Установите цвет маркера.
1. Установите высоту маркеров.
1. Добавьте созданный абзац в коллекцию абзацев TextFrame.
1. Добавьте второй абзац и повторите процесс, описанный в шагах **7 до 13**.
1. Сохраните презентацию.

Этот пример кода на Java — реализация вышеуказанных шагов — показывает вам, как создать маркерованный список на слайде:

```java
// Создайте экземпляр класса Presentation, представляющего файл PPTX
Presentation pres = new Presentation();
try {
    // Доступ к первому слайду
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Добавление и доступ к Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // Доступ к текстовому фрейму созданной автозаменной
    ITextFrame txtFrm = aShp.getTextFrame();
    
    // Удаление стандартного существующего абзаца
    txtFrm.getParagraphs().removeAt(0);
    
    // Создание абзаца
    Paragraph para = new Paragraph();
    
    // Установка стиля и символа маркера абзаца
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char) 8226);
    
    // Установка текста абзаца
    para.setText("Добро пожаловать в Aspose.Slides");
    
    // Установка отступа маркера
    para.getParagraphFormat().setIndent(25);
    
    // Установка цвета маркера
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    
    // Установите IsBulletHardColor в true, чтобы использовать свой собственный цвет маркера
    para.getParagraphFormat().getBullet().isBulletHardColor();
    
    // Установка высоты маркера
    para.getParagraphFormat().getBullet().setHeight(100);
    
    // Добавление абзаца в текстовый фрейм
    txtFrm.getParagraphs().add(para);
    
    // Сохранение презентации в качестве файла PPTX
    pres.save("Bullet.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## Создание изображений-маркеров

Aspose.Slides для Android через Java позволяет вам изменить маркеры в маркированных списках. Вы можете заменить маркеры на пользовательские символы или изображения. Если вы хотите добавить визуальный интерес к списку или привлечь еще больше внимания к элементам в списке, вы можете использовать свое собственное изображение в качестве маркера.

{{% alert color="primary" %}} 

В идеале, если вы собираетесь заменить обычный маркерный символ на изображение, вам может потребоваться выбрать простое графическое изображение с прозрачным фоном. Такие изображения лучше всего работать в качестве пользовательских символов маркеров. 

В любом случае, изображение, которое вы выберете, будет уменьшено до очень маленького размера, поэтому мы настоятельно рекомендуем выбрать изображение, которое хорошо выглядит (в качестве замены символа маркера) в списке. 

{{% /alert %}} 

Чтобы создать изображение-маркер, пройдите через эти шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)
1. Получите доступ к нужному слайду в коллекции слайдов, используя объект [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide)
1. Добавьте автозамену на выбранный слайд
1. Получите доступ к [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) добавленной формы
1. Удалите стандартный абзац в [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe)
1. Создайте первый экземпляр абзаца, используя класс Paragraph
1. Загрузите изображение с диска в [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IPPImage)
1. Установите тип маркера как изображение и установите изображение
1. Установите текст абзаца
1. Установите отступ абзаца для установки маркера
1. Установите цвет маркера
1. Установите высоту маркеров
1. Добавьте созданный абзац в коллекцию [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) абзацев
1. Добавьте второй абзац и повторите процесс, описанный в предыдущих шагах
1. Сохраните презентацию

Этот код на Java демонстрирует, как создать изображение-маркер на слайде:

```java
Presentation pres = new Presentation();
try {
    // Доступ к первому слайду
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

    // Доступ к текстовому фрейму созданной автозаменной
    ITextFrame txtFrm = aShp.getTextFrame();
    // Удаление стандартного существующего абзаца
    txtFrm.getParagraphs().removeAt(0);

    // Создание нового абзаца
    Paragraph para = new Paragraph();
    para.setText("Добро пожаловать в Aspose.Slides");

    // Установка стиля и изображения маркера абзаца
    para.getParagraphFormat().getBullet().setType(BulletType.Picture);
    para.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // Установка высоты маркера
    para.getParagraphFormat().getBullet().setHeight(100);

    // Добавление абзаца в текстовый фрейм
    txtFrm.getParagraphs().add(para);

    // Запись презентации как файла PPTX
    pres.save("Bullet.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## Создание многоуровневых маркеров

Чтобы создать маркированный список, который содержит элементы на разных уровнях — дополнительные списки под основным маркерованным списком — пройдите через эти шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Получите доступ к нужному слайду в коллекции слайдов, используя объект [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide).
1. Добавьте автозамену на выбранный слайд.
1. Получите доступ к [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) добавленной формы.
1. Удалите стандартный абзац в [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe).
1. Создайте первый экземпляр абзаца, используя класс Paragraph, и установите глубину на 0.
1. Создайте второй экземпляр абзаца, используя класс Paragraph, и установите глубину на 1.
1. Создайте третий экземпляр абзаца, используя класс Paragraph, и установите глубину на 2.
1. Создайте четвертый экземпляр абзаца, используя класс Paragraph, и установите глубину на 3.
1. Добавьте созданные абзацы в коллекцию [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) абзацев.
1. Сохраните презентацию.

Этот код, который является реализацией вышеуказанных шагов, показывает вам, как создать многоуровневый маркерованный список на Java:

```java
// Создайте экземпляр класса Presentation, представляющего файл PPTX
Presentation pres = new Presentation();
try {
    // Доступ к первому слайду
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Добавление и доступ к Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // Доступ к текстовому фрейму созданной автозаменной
    ITextFrame txtFrm = aShp.addTextFrame("");
    
    // Удаление стандартного существующего абзаца
    txtFrm.getParagraphs().clear();
    
    // Создание первого абзаца
    Paragraph para1 = new Paragraph();
    // Установка стиля и символа маркера абзаца
    para1.setText("Содержимое");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char) 8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Установка уровня маркера
    para1.getParagraphFormat().setDepth ((short)0);
    
    // Создание второго абзаца
    Paragraph para2 = new Paragraph();
    // Установка стиля и символа маркера абзаца
    para2.setText("Второй уровень");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Установка уровня маркера
    para2.getParagraphFormat().setDepth ((short)1);
    
    // Создание третьего абзаца
    Paragraph para3 = new Paragraph();
    // Установка стиля и символа маркера абзаца
    para3.setText("Третий уровень");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char) 8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Установка уровня маркера
    para3.getParagraphFormat().setDepth ((short)2);
    
    // Создание четвертого абзаца
    Paragraph para4 = new Paragraph();
    // Установка стиля и символа маркера абзаца
    para4.setText("Четвертый уровень");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Установка уровня маркера
    para4.getParagraphFormat().setDepth ((short)3);
    
    // Добавление абзацев в текстовый фрейм
    txtFrm.getParagraphs().add(para1);
    txtFrm.getParagraphs().add(para2);
    txtFrm.getParagraphs().add(para3);
    txtFrm.getParagraphs().add(para4);
    
    // Сохранение презентации как файла PPTX
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## Создание пользовательского нумерованного списка
Aspose.Slides для Android через Java предоставляет простой API для управления абзацами с пользовательским форматированием чисел. Чтобы добавить пользовательский номер в абзац, пожалуйста, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Получите доступ к нужному слайду в коллекции слайдов, используя объект [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide).
1. Добавьте автозамену на выбранный слайд.
1. Получите доступ к [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) добавленной формы.
1. Удалите стандартный абзац в [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe).
1. Создайте первый экземпляр абзаца, используя класс Paragraph, и установите **NumberedBulletStartWith** на 2.
1. Создайте второй экземпляр абзаца, используя класс Paragraph, и установите **NumberedBulletStartWith** на 3.
1. Создайте третий экземпляр абзаца, используя класс Paragraph, и установите **NumberedBulletStartWith** на 7.
1. Добавьте созданные абзацы в коллекцию [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) абзацев.
1. Сохраните презентацию.

Этот код на Java показывает вам, как создать нумерованный список на слайде:

```java
// Создайте экземпляр класса Presentation, представляющего файл PPTX
Presentation pres = new Presentation();
try {
    // Доступ к первому слайду
    ISlide slide = pres.getSlides().get_Item(0);

    // Добавление и доступ к Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Доступ к текстовому фрейму созданной автозаменной
    ITextFrame txtFrm = aShp.addTextFrame("");

    // Удаление стандартного существующего абзаца
    txtFrm.getParagraphs().clear();

    // Первый список
    Paragraph paragraph1 = new Paragraph();
    paragraph1.setText("номер 2");
    paragraph1.getParagraphFormat().setDepth((short)4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)2);
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.setText("номер 3");
    paragraph2.getParagraphFormat().setDepth((short)4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)3);
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph2);

    // Второй список
    Paragraph paragraph5 = new Paragraph();
    paragraph5.setText("номер 5");
    paragraph5.getParagraphFormat().setDepth((short)4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)5);
    paragraph5.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph5);

    pres.save(resourcesOutputPath + "SetCustomBulletsNumber-slides.pptx.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```