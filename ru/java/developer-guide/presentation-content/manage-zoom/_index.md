---
title: Управление Зумом
type: docs
weight: 60
url: /java/manage-zoom/
keywords: "Zoom, Zoom фрейм, Добавить зум, Форматировать зум фрейм, Сводка зум, Презентация PowerPoint, Java, Aspose.Slides для Java"
description: "Добавьте зум или зум фреймы в презентации PowerPoint на Java"
---

## **Обзор**
Зумы в PowerPoint позволяют вам переходить к конкретным слайдам, секциям и частям презентации и обратно. Во время презентации эта возможность быстро перемещаться по содержимому может оказаться очень полезной.

![overview_image](overview.png)

* Чтобы подвести итоги всей презентации на одном слайде, используйте [Сводный Зум](#Summary-Zoom).
* Чтобы показать только выбранные слайды, используйте [Зум слайдов](#Slide-Zoom).
* Чтобы показать только одну секцию, используйте [Зум секции](#Section-Zoom).

## **Зум слайдов**
Зум слайдов может сделать вашу презентацию более динамичной, позволяя вам свободно перемещаться между слайдами в любом порядке, не прерывая поток вашей презентации. Зумы слайдов отлично подходят для коротких презентаций без большого количества секций, но их все еще можно применять в различных сценариях презентации.

Зумы слайдов помогают вам углубляться в несколько частей информации, при этом создавая ощущение, что вы находитесь на одном холсте.

![overview_image](slidezoomsel.png)

Для объектов зума слайдов Aspose.Slides предоставляет перечисление [ZoomImageType](https://reference.aspose.com/slides/java/com.aspose.slides/ZoomImageType), интерфейс [IZoomFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IZoomFrame) и некоторые методы в интерфейсе [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection).

### **Создание зум фреймов**

Вы можете добавить зум фрейм на слайд следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Создайте новые слайды, к которым вы планируете привязать зум фреймы.
3. Добавьте текст идентификации и фон к созданным слайдам.
4. Добавьте зум фреймы (содержашие ссылки на созданные слайды) на первый слайд.
5. Запишите модифицированную презентацию в файл PPTX.

Этот код на Java демонстрирует, как создать зум фрейм на слайде:

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
### **Создание зум фреймов с настраиваемыми изображениями**
С помощью Aspose.Slides для Java вы можете создать зум фрейм с другим изображением предварительного просмотра слайда следующим образом:
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Создайте новый слайд, к которому вы планируете привязать зум фрейм.
3. Добавьте текст идентификации и фон к слайду.
4. Создайте объект [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage), добавив изображение в коллекцию Images, связанную с объектом [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation), который будет использоваться для заполнения фрейма.
5. Добавьте зум фреймы (содержашие ссылку на созданный слайд) на первый слайд.
6. Запишите модифицированную презентацию в файл PPTX.

Этот код на Java демонстрирует, как создать зум фрейм с другим изображением:

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
### **Форматирование зум фреймов**
В предыдущих разделах мы показали вам, как создавать простые зум фреймы. Чтобы создать более сложные зум фреймы, вам нужно изменить форматирование простого фрейма. Есть несколько вариантов форматирования, которые вы можете применить к зум фрейму.

Вы можете контролировать форматирование зум фрейма на слайде следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Создайте новые слайды, к которым вы намерены привязать зум фрейм.
3. Добавьте некоторый текст идентификации и фон к созданным слайдам.
4. Добавьте зум фреймы (содержашие ссылки на созданные слайды) на первый слайд.
5. Создайте объект [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage), добавив изображение в коллекцию Images, связанную с объектом [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation), который будет использоваться для заполнения фрейма.
6. Установите настраиваемое изображение для первого объекта зума.
7. Измените формат линии для второго объекта зума.
8. Удалите фон с изображения второго объекта зума.
5. Запишите модифицированную презентацию в файл PPTX.

Этот код на Java демонстрирует, как изменить форматирование зум фрейма на слайде:

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
    // Устанавливает настраиваемое изображение для объекта zoomFrame1
    zoomFrame1.setImage(picture);

    // Устанавливает формат зум фрейма для объекта zoomFrame2
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink);
    zoomFrame2.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    // Установка "Не показывать фон" для объекта zoomFrame2
    zoomFrame2.setShowBackground(false);

    // Сохраняет презентацию
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Зум секций**

Зум секций - это ссылка на секцию в вашей презентации. Вы можете использовать зумы секций, чтобы вернуться к секциям, которые вы хотите действительно подчеркнуть. Или вы можете использовать их, чтобы выделить, как определенные части вашей презентации связаны.

![overview_image](seczoomsel.png)

Для объектов зума секций Aspose.Slides предоставляет интерфейс [ISectionZoomFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ISectionZoomFrame) и некоторые методы в интерфейсе [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection).

### **Создание зум фреймов секций**

Вы можете добавить зум фрейм секции на слайд следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Создайте новый слайд.
3. Добавьте идентификационный фон к созданному слайду.
4. Создайте новую секцию, к которой вы планируете привязать зум фрейм.
5. Добавьте зум фрейм секции (содержаший ссылки на созданную секцию) на первый слайд.
6. Запишите модифицированную презентацию в файл PPTX.

Этот код на Java демонстрирует, как создать зум фрейм на слайде:

``` java
Presentation pres = new Presentation();
try {
    //Добавляет новый слайд в презентацию
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Добавляет новую секцию в презентацию
    pres.getSections().addSection("Секция 1", slide);

    // Добавляет объект SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // Сохраняет презентацию
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **Создание зум фреймов секций с настраиваемыми изображениями**

Используя Aspose.Slides для Java, вы можете создать зум фрейм секции с другим изображением предварительного просмотра слайда следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Создайте новый слайд.
3. Добавьте идентификационный фон к созданному слайду.
4. Создайте новую секцию, к которой вы планируете привязать зум фрейм.
5. Создайте объект [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage), добавив изображение в коллекцию Images, связанную с объектом [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation), который будет использоваться для заполнения фрейма.
5. Добавьте зум фрейм секции (содержаший ссылку на созданную секцию) на первый слайд.
6. Запишите модифицированную презентацию в файл PPTX.

Этот код на Java демонстрирует, как создать зум фрейм с другим изображением:

``` java 
Presentation pres = new Presentation();
try {
    //Добавляет новый слайд в презентацию
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Добавляет новую секцию в презентацию
    pres.getSections().addSection("Секция 1", slide);

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
### **Форматирование зум фреймов секций**

Чтобы создать более сложные зум фреймы секций, вам нужно изменить форматирование простого фрейма. Есть несколько вариантов форматирования, которые вы можете применить к зум фрейму секции.

Вы можете контролировать форматирование зум фрейма секции на слайде следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Создайте новый слайд.
3. Добавьте идентификационный фон к созданному слайду.
4. Создайте новую секцию, к которой вы планируете привязать зум фрейм.
5. Добавьте зум фрейм секции (содержаший ссылки на созданную секцию) на первый слайд.
6. Измените размер и позицию созданного объекта зума секции.
7. Создайте объект [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage), добавив изображение в коллекцию Images, связанную с объектом [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation), который будет использоваться для заполнения фрейма.
8. Установите настраиваемое изображение для созданного объекта зума секции.
9. Установите возможность *возврата к оригинальному слайду из связанной секции*.
10. Удалите фон с изображения объекта зума секции.
11. Измените формат линии для второго объекта зума.
12. Измените продолжительность перехода.
13. Запишите модифицированную презентацию в файл PPTX.

Этот код на Java демонстрирует, как изменить форматирование для объекта зума секции:

``` java
Presentation pres = new Presentation();
try {
    //Добавляет новый слайд в презентацию
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Добавляет новую секцию в презентацию
    pres.getSections().addSection("Секция 1", slide);

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


## **Сводный Зум**

Сводный зум - это как целевая страница, где все элементы вашей презентации отображаются сразу. Когда вы презентацию, вы можете использовать зум, чтобы перемещаться от одного места в вашей презентации к другому в любом порядке, который вам нравится. Вы можете проявить креативность, пропустить вперед или снова посетить части вашего слайд-шоу, не прерывая поток вашей презентации.

![overview_image](sumzoomsel.png)

Для объектов сводного зума Aspose.Slides предоставляет интерфейсы [ISummaryZoomFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomFrame), [ISummaryZoomSection](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomSection) и [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomSectionCollection) и некоторые методы в интерфейсе [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection).

### **Создание сводного зума**

Вы можете добавить сводный зум фрейм на слайд следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Создайте новые слайды с идентификационным фоном и новые секции для созданных слайдов.
3. Добавьте сводный зум фрейм на первый слайд.
4. Запишите модифицированную презентацию в файл PPTX.

Этот код на Java демонстрирует, как создать сводный зум фрейм на слайде:

``` java 
Presentation pres = new Presentation();
try {
    //Добавляет новый слайд в презентацию
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Добавляет новую секцию в презентацию
    pres.getSections().addSection("Секция 1", slide);

    //Добавляет новый слайд в презентацию
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Добавляет новую секцию в презентацию
    pres.getSections().addSection("Секция 2", slide);

    //Добавляет новый слайд в презентацию
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Добавляет новую секцию в презентацию
    pres.getSections().addSection("Секция 3", slide);

    //Добавляет новый слайд в презентацию
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.green);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Добавляет новую секцию в презентацию
    pres.getSections().addSection("Секция 4", slide);

    // Добавляет объект SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // Сохраняет презентацию
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Добавление и удаление секций сводного зума**

Все секции в сводном зум фрейме представлены объектами [ISummaryZoomSection](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomSection), которые хранятся в объекте [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomSectionCollection). Вы можете добавить или удалить объект секции сводного зума через интерфейс [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomSectionCollection) следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Создайте новые слайды с идентификационным фоном и новые секции для созданных слайдов.
3. Добавьте сводный зум фрейм на первый слайд.
4. Добавьте новый слайд и секцию в презентацию.
5. Добавьте созданную секцию в сводный зум фрейм.
6. Удалите первую секцию из сводного зум фрейма.
7. Запишите модифицированную презентацию в файл PPTX.

Этот код на Java демонстрирует, как добавлять и удалять секции в сводном зум фрейме:

``` java
Presentation pres = new Presentation();
try {
    //Добавляет новый слайд в презентацию
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adds a new section to the presentation
    pres.getSections().addSection("Секция 1", slide);

    //Добавляет новый слайд в презентацию
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adds a new section to the presentation
    pres.getSections().addSection("Секция 2", slide);

    // Adds SummaryZoomFrame object
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    //Добавляет новый слайд в презентацию
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Добавляет новую секцию в презентацию
    ISection section3 = pres.getSections().addSection("Секция 3", slide);

    // Добавляет секцию к сводному зуму
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

Чтобы создать более сложные объекты секции сводного зума, вам нужно изменить форматирование простого фрейма. Существует несколько вариантов форматирования, которые вы можете применить к объекту секции сводного зума.

Вы можете контролировать форматирование для объекта секции сводного зума в сводном зум фрейме следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Создайте новые слайды с идентификационным фоном и новые секции для созданных слайдов.
3. Добавьте сводный зум фрейм на первый слайд.
4. Получите объект секции сводного зума для первого объекта из `ISummaryZoomSectionCollection`.
7. Создайте объект [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage), добавив изображение в коллекцию изображений, связанную с объектом [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation), который будет использоваться для заполнения фрейма.
8. Установите настраиваемое изображение для созданного объекта зума секции.
9. Установите возможность *возврата к оригинальному слайду из связанной секции*.
11. Измените формат линии для второго объекта зума.
12. Измените продолжительность перехода.
13. Запишите модифицированную презентацию в файл PPTX.

Этот код на Java демонстрирует, как изменить форматирование для объекта секции сводного зума:

``` java
Presentation pres = new Presentation();
try {
    //Добавляет новый слайд в презентацию
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Добавляет новую секцию в презентацию
    pres.getSections().addSection("Секция 1", slide);

    //Добавляет новый слайд в презентацию
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Добавляет новую секцию в презентацию
    pres.getSections().addSection("Секция 2", slide);

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