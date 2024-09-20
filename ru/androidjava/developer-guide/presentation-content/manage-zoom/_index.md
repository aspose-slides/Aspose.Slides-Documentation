---
title: Управление Зумом
type: docs
weight: 60
url: /androidjava/manage-zoom/
keywords: "Zoom, Zoom frame, Добавить зум, Форматировать зум-каркас, Сводный зум, Презентация PowerPoint, Java, Aspose.Slides для Android через Java"
description: "Добавьте зум или зум-каркас в презентации PowerPoint на Java"
---

## **Обзор**
Зумы в PowerPoint позволяют вам переходить к конкретным слайдам, разделам и частям презентации. Эта возможность быстро перемещаться по содержимому может оказаться очень полезной во время презентации.

![overview_image](overview.png)

* Чтобы обобщить всю презентацию на одном слайде, используйте [Сводный зум](#Summary-Zoom).
* Чтобы показать только выбранные слайды, используйте [Зум слайдов](#Slide-Zoom).
* Чтобы показать только один раздел, используйте [Зум раздела](#Section-Zoom).

## **Зум слайдов**
Зум слайдов может сделать вашу презентацию более динамичной, позволяя вам свободно перемещаться между слайдами в любом порядке, не прерывая поток вашей презентации. Зумы слайдов отлично подходят для кратких презентаций без множества разделов, но вы все равно можете использовать их в различных сценариях презентации.

Зумы слайдов помогают вам глубже понять несколько аспектов информации, создавая впечатление, что вы находитесь на едином полотне.

![overview_image](slidezoomsel.png)

Для объектов зума слайдов Aspose.Slides предоставляет перечисление [ZoomImageType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ZoomImageType), интерфейс [IZoomFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IZoomFrame) и некоторые методы в интерфейсе [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).

### **Создание зум-каркасов**

Вы можете добавить зум-каркас на слайд следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Создайте новые слайды, к которым вы собираетесь привязать зум-каркасы. 
3. Добавьте идентификационный текст и фон к созданным слайдам.
4. Добавьте зум-каркасы (ссылающиеся на созданные слайды) к первому слайду.
5. Запишите измененную презентацию в файл PPTX.

Этот код на Java показывает, как создать зум-каркас на слайде:

``` java
Presentation pres = new Presentation();
try {
    //Добавляет новые слайды в презентацию
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Создает фон для второго слайда
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Создает текстовое поле для второго слайда
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Второй слайд");

    // Создает фон для третьего слайда
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // Создает текстовое поле для третьего слайда
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Третий слайд");

    //Добавляет объекты ZoomFrame
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // Сохраняет презентацию
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **Создание зум-каркасов с пользовательскими изображениями**
С помощью Aspose.Slides для Android через Java вы можете создать зум-каркас с другим изображением предварительного просмотра слайда следующим образом:
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Создайте новый слайд, к которому вы собираетесь привязать зум-каркас. 
3. Добавьте идентификационный текст и фон к слайду.
4. Создайте объект [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage), добавив изображение в коллекцию Images, связанную с объектом [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation), который будет использоваться для заполнения каркаса.
5. Добавьте зум-каркасы (ссылающиеся на созданный слайд) к первому слайду.
6. Запишите измененную презентацию в файл PPTX.

Этот код на Java показывает, как создать зум-каркас с другим изображением:

``` java
Presentation pres = new Presentation();
try {
    //Добавляет новый слайд в презентацию
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Создает фон для второго слайда
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Создает текстовое поле для третьего слайда
    IAutoShape autoshape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Второй слайд");

    // Создает новое изображение для объекта зума
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    //Добавляет объект ZoomFrame
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);

    // Сохраняет презентацию
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
### **Форматирование зум-каркасов**
В предыдущих разделах мы показали, как создать простые зум-каркасы. Чтобы создать более сложные зум-каркасы, вам нужно изменить оформление простого каркаса. Существует несколько параметров форматирования, которые вы можете применить к зум-каркасу. 

Вы можете контролировать форматирование зум-каркаса на слайде следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Создайте новые слайды, к которым вы собираетесь привязать зум-каркас. 
3. Добавьте некоторый идентификационный текст и фон к созданным слайдам.
4. Добавьте зум-каркас (ссылающийся на созданные слайды) к первому слайду.
5. Создайте объект [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage), добавив изображение в коллекцию Images, связанную с объектом [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation), который будет использоваться для заполнения каркаса.
6. Установите пользовательское изображение для первого объекта зум-каркаса.
7. Измените формат линии для второго объекта зум-каркаса.
8. Удалите фон у изображения второго объекта зум-каркаса.
5. Запишите измененную презентацию в файл PPTX.

Этот код на Java показывает, как изменить форматирование зум-каркаса на слайде: 

``` java 
Presentation pres = new Presentation();
try {
    //Добавляет новые слайды в презентацию
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Создает фон для второго слайда
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Создает текстовое поле для второго слайда
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Второй слайд");

    // Создает фон для третьего слайда
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // Создает текстовое поле для третьего слайда
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Третий слайд");

    //Добавляет объекты ZoomFrame
    IZoomFrame zoomFrame1 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // Создает новое изображение для объекта зума
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    // Устанавливает пользовательское изображение для объекта zoomFrame1
    zoomFrame1.setImage(picture);

    // Устанавливает формат зум-каркаса для второго объекта zoomFrame2
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink);
    zoomFrame2.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    // Устанавливает параметр_Не показывать фон_ для объекта zoomFrame2
    zoomFrame2.setShowBackground(false);

    // Сохраняет презентацию
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Зум раздела**

Зум раздела - это ссылка на раздел в вашей презентации. Вы можете использовать зумы разделов, чтобы вернуться к разделам, на которых хотите действительно акцентировать внимание. Или вы можете использовать их, чтобы подчеркнуть, как определенные части вашей презентации взаимосвязаны.

![overview_image](seczoomsel.png)

Для объектов зума разделов Aspose.Slides предоставляет интерфейс [ISectionZoomFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISectionZoomFrame) и некоторые методы в интерфейсе [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).

### **Создание зум-каркасов раздела**

Вы можете добавить зум-каркас раздела на слайд следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Создайте новый слайд. 
3. Добавьте идентификационный фон к созданному слайду.
4. Создайте новый раздел, к которому вы собираетесь привязать зум-каркас. 
5. Добавьте зум-каркас раздела (ссылающийся на созданный раздел) к первому слайду.
6. Запишите измененную презентацию в файл PPTX.

Этот код на Java показывает, как создать зум-каркас на слайде:

``` java
Presentation pres = new Presentation();
try {
    //Добавляет новый слайд в презентацию
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Добавляет новый раздел в презентацию
    pres.getSections().addSection("Раздел 1", slide);

    // Добавляет объект SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // Сохраняет презентацию
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **Создание зум-каркасов раздела с пользовательскими изображениями**

Используя Aspose.Slides для Android через Java, вы можете создать зум-каркас раздела с другим изображением предварительного просмотра слайда следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Создайте новый слайд.
3. Добавьте идентификационный фон к созданному слайду.
4. Создайте новый раздел, к которому вы собираетесь привязать зум-каркас. 
5. Создайте объект [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage), добавив изображение в коллекцию Images, связанную с объектом [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation), который будет использоваться для заполнения рамки.
5. Добавьте зум-каркас раздела (ссылающийся на созданный раздел) к первому слайду.
6. Запишите измененную презентацию в файл PPTX.

Этот код на Java показывает, как создать зум-каркас с другим изображением:

``` java 
Presentation pres = new Presentation();
try {
    //Добавляет новый слайд в презентацию
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Добавляет новый раздел в презентацию
    pres.getSections().addSection("Раздел 1", slide);

    // Создает новое изображение для объекта зума
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Добавляет объект SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1), picture);

    // Сохраняет презентацию
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
### **Форматирование зум-каркасов раздела**

Чтобы создать более сложные зум-каркасы раздела, вам нужно изменить форматирование простого каркаса. Существует несколько параметров форматирования, которые вы можете применить к зум-каркасу раздела. 

Вы можете контролировать форматирование зум-каркаса раздела на слайде следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Создайте новый слайд.
3. Добавьте идентификационный фон к созданному слайду.
4. Создайте новый раздел, к которому вы собираетесь привязать зум-каркас. 
5. Добавьте зум-каркас раздела (ссылающийся на созданные разделы) к первому слайду.
6. Измените размер и положение созданного объекта зума раздела.
7. Создайте объект [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage), добавив изображение в коллекцию Images, связанную с объектом [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation), который будет использоваться для заполнения каркаса.
8. Установите пользовательское изображение для созданного объекта зум-каркаса раздела.
9. Установите возможность *возврата на оригинальный слайд из связанного раздела*. 
10. Удалите фон у изображения объекта зум-каркаса раздела.
11. Измените формат линии для второго объекта зум-каркаса.
12. Измените длительность перехода.
13. Запишите измененную презентацию в файл PPTX.

Этот код на Java показывает, как изменить форматирование для зум-каркаса раздела:

``` java
Presentation pres = new Presentation();
try {
    //Добавляет новый слайд в презентацию
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Добавляет новый раздел в презентацию
    pres.getSections().addSection("Раздел 1", slide);

    // Добавляет объект SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // Форматирование для SectionZoomFrame
    sectionZoomFrame.setX(100);
    sectionZoomFrame.setY(300);
    sectionZoomFrame.setWidth(100);
    sectionZoomFrame.setHeight(75);

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
         picture = pres.getImages().addImage(image);
     } finally {
        if (image != null) image.dispose();
     }
    sectionZoomFrame.setImage(picture);

    sectionZoomFrame.setReturnToParent(true);
    sectionZoomFrame.setShowBackground(false);

    sectionZoomFrame.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    sectionZoomFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.gray);
    sectionZoomFrame.getLineFormat().setDashStyle(LineDashStyle.DashDot);
    sectionZoomFrame.getLineFormat().setWidth(2.5f);

    sectionZoomFrame.setTransitionDuration(1.5f);

    // Сохраняет презентацию
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Сводный зум**

Сводный зум - это как целевая страница, где все части вашей презентации отображаются одновременно. Во время вашей презентации вы можете использовать зум, чтобы перейти из одного места вашей презентации в другое в любом порядке, который вам нравится. Вы можете быть креативными, перепрыгивать вперед или пересматривать отдельные части вашего слайд-шоу, не нарушая поток вашей презентации.

![overview_image](sumzoomsel.png)

Для объектов сводного зума Aspose.Slides предоставляет интерфейсы [ISummaryZoomFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomFrame), [ISummaryZoomSection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSection) и [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSectionCollection), а также некоторые методы в интерфейсе [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).

### **Создание сводного зума**

Вы можете добавить зум-каркас в сводный зум на слайд следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Создайте новые слайды с идентификационным фоном и новыми разделами для созданных слайдов.
3. Добавьте зум-каркас в первый слайд.
4. Запишите измененную презентацию в файл PPTX.

Этот код на Java показывает, как создать зум-каркас сводного зума на слайде:

``` java 
Presentation pres = new Presentation();
try {
    //Добавляет новый слайд в презентацию
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Добавляет новый раздел в презентацию
    pres.getSections().addSection("Раздел 1", slide);

    //Добавляет новый слайд в презентацию
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Добавляет новый раздел в презентацию
    pres.getSections().addSection("Раздел 2", slide);

    //Добавляет новый слайд в презентацию
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Добавляет новый раздел в презентацию
    pres.getSections().addSection("Раздел 3", slide);

    //Добавляет новый слайд в презентацию
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.green);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Добавляет новый раздел в презентацию
    pres.getSections().addSection("Раздел 4", slide);

    // Добавляет объект SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // Сохраняет презентацию
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Добавление и удаление секции сводного зума**

Все секции в зум-каркасе сводного зума представлены объектами [ISummaryZoomSection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSection), которые хранятся в объекте [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSectionCollection). Вы можете добавлять или удалять объект секции зум-каркаса сводного зума через интерфейс [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSectionCollection) следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Создайте новые слайды с идентификационным фоном и новыми разделами для созданных слайдов.
3. Добавьте зум-каркас сводного зума в первый слайд.
4. Добавьте новый слайд и раздел в презентацию.
5. Добавьте созданный раздел в зум-каркас сводного зума.
6. Удалите первый раздел из зум-каркаса сводного зума.
7. Запишите измененную презентацию в файл PPTX.

Этот код на Java показывает, как добавить и удалить секции в зум-каркас сводного зума:

``` java
Presentation pres = new Presentation();
try {
    //Добавляет новый слайд в презентацию
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Добавляет новый раздел в презентацию
    pres.getSections().addSection("Раздел 1", slide);

    //Добавляет новый слайд в презентацию
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Добавляет новый раздел в презентацию
    pres.getSections().addSection("Раздел 2", slide);

    // Добавляет объект SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    //Добавляет новый слайд в презентацию
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Добавляет новый раздел в презентацию
    ISection section3 = pres.getSections().addSection("Раздел 3", slide);

    // Добавляет секцию в сводный зум
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);

    // Удаляет секцию из сводного зума
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));

    // Сохраняет презентацию
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Форматирование секций сводного зума**

Чтобы создать более сложные объекты секции сводного зума, вам нужно изменить форматирование простого каркаса. Существует несколько параметров форматирования, которые вы можете применить к объекту секции сводного зума. 

Вы можете контролировать форматирование для объекта секции сводного зума в зум-каркасе сводного зума следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Создайте новые слайды с идентификационным фоном и новыми разделами для созданных слайдов.
3. Добавьте зум-каркас сводного зума в первый слайд.
4. Получите объект секции сводного зума для первого объекта из `ISummaryZoomSectionCollection`.
7. Создайте объект [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage), добавив изображение в коллекцию images, связанную с объектом [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation), который будет использоваться для заполнения каркаса.
8. Установите пользовательское изображение для созданного объекта зум-каркаса секции сводного зума.
9. Установите возможность *возврата на оригинальный слайд из связанного раздела*. 
11. Измените формат линии для второго объекта зум-каркаса.
12. Измените длительность перехода.
13. Запишите измененную презентацию в файл PPTX.

Этот код на Java показывает, как изменить форматирование для объекта секции сводного зума:

``` java
Presentation pres = new Presentation();
try {
    //Добавляет новый слайд в презентацию
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Добавляет новый раздел в презентацию
    pres.getSections().addSection("Раздел 1", slide);

    //Добавляет новый слайд в презентацию
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Добавляет новый раздел в презентацию
    pres.getSections().addSection("Раздел 2", slide);

    // Добавляет объект SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // Получает первый объект SummaryZoomSection
    ISummaryZoomSection summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);

    // Форматирование для объекта SummaryZoomSection
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
    picture = pres.getImages().addImage(picture);
    } finally {
          if (image != null) image.dispose();
    }
    summarySection.setImage(picture);

    summarySection.setReturnToParent(false);

    summarySection.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    summarySection.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.black);
    summarySection.getLineFormat().setDashStyle(LineDashStyle.DashDot);
    summarySection.getLineFormat().setWidth(1.5f);

    summarySection.setTransitionDuration(1.5f);

    // Сохраняет презентацию
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```