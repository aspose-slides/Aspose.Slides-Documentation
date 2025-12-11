---
title: Управление масштабированием презентации в Android
linktitle: Управление Zoom
type: docs
weight: 60
url: /ru/androidjava/manage-zoom/
keywords:
- масштабирование
- кадр масштабирования
- масштабирование слайда
- масштабирование раздела
- масштабирование содержания
- добавление масштабирования
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Создайте и настройте Zoom с помощью Aspose.Slides для Android через Java — переходите между разделами, добавляйте миниатюры и переходы в презентациях PPT, PPTX и ODP."
---

## **Обзор**
Zoom в PowerPoint позволяет переходить к конкретным слайдам, разделам и частям презентации и обратно. При демонстрации эта возможность быстро перемещаться по содержимому может оказаться очень полезной. 

![overview_image](overview.png)

* Чтобы суммировать всю презентацию на одном слайде, используйте [Summary Zoom](#Summary-Zoom).
* Чтобы показать только выбранные слайды, используйте [Slide Zoom](#Slide-Zoom).
* Чтобы показать только один раздел, используйте [Section Zoom](#Section-Zoom).

## **Zoom слайда**
Zoom слайда может сделать вашу презентацию более динамичной, позволяя свободно перемещаться между слайдами в любом выбранном порядке без прерывания хода презентации. Zoom слайдов отлично подходит для коротких презентаций без множества разделов, но их также можно использовать в разных сценариях презентаций.

Zoom слайды помогают детально рассматривать несколько фрагментов информации, ощущая, что вы работаете на едином холсте. 

![overview_image](slidezoomsel.png)

Для объектов Zoom слайда Aspose.Slides предоставляет перечисление [ZoomImageType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ZoomImageType), интерфейс [IZoomFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IZoomFrame) и некоторые методы в интерфейсе [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).

### **Создание Zoom‑кадров**

Вы можете добавить Zoom‑кадр на слайд следующим образом:

1.	Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2.	Создайте новые слайды, к которым вы планируете привязать Zoom‑кадры. 
3.	Добавьте идентификационный текст и фон к созданным слайдам.
4.	Добавьте Zoom‑кадры (содержащие ссылки на созданные слайды) на первый слайд.
5.	Запишите изменённую презентацию в файл PPTX.

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
    autoshape.getTextFrame().setText("Second Slide");

    // Создает фон для третьего слайда
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // Создает текстовое поле для третьего слайда
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    //Добавляет объекты ZoomFrame
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // Сохраняет презентацию
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Создание Zoom‑кадров с пользовательскими изображениями**
С помощью Aspose.Slides для Android через Java вы можете создать Zoom‑кадр с другим изображением предварительного просмотра слайда следующим образом:
1.	Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2.	Создайте новый слайд, к которому вы планируете привязать Zoom‑кадр. 
3.	Добавьте идентификационный текст и фон к слайду.
4.	Создайте объект [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage), добавив изображение в коллекцию Images, связанную с объектом [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation), которое будет использоваться для заполнения кадра.
5.	Добавьте Zoom‑кадры (содержащие ссылку на созданный слайд) на первый слайд.
6.	Запишите изменённую презентацию в файл PPTX.

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
    autoshape.getTextFrame().setText("Second Slide");

    // Создает новое изображение для объекта Zoom
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    //Adds объект ZoomFrame
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);

    // Сохраняет презентацию
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

### **Форматирование Zoom‑кадров**
В предыдущих разделах мы показывали, как создавать простые Zoom‑кадры. Чтобы создать более сложные Zoom‑кадры, необходимо изменить форматирование простого кадра. Существует несколько вариантов форматирования, которые вы можете применить к Zoom‑кадру.

Вы можете управлять форматированием Zoom‑кадра на слайде следующим образом:

1.	Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2.	Создайте новые слайды, к которым вы планируете привязать Zoom‑кадр. 
3.	Добавьте некоторый идентификационный текст и фон к созданным слайдам.
4.	Добавьте Zoom‑кадры (содержащие ссылки на созданные слайды) на первый слайд.
5.	Создайте объект [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage), добавив изображение в коллекцию Images, связанную с объектом [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation), которое будет использоваться для заполнения кадра.
6.	Установите пользовательское изображение для первого объекта Zoom‑кадра.
7.	Измените формат линии для второго объекта Zoom‑кадра.
8.	Удалите фон с изображения второго объекта Zoom‑кадра.
5.	Запишите изменённую презентацию в файл PPTX.

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
    autoshape.getTextFrame().setText("Second Slide");

    // Создает фон для третьего слайда
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // Создает текстовое поле для третьего слайда
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    //Adds ZoomFrame objects
    IZoomFrame zoomFrame1 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // Создает новое изображение для объекта zoom
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    // Sets custom image for zoomFrame1 object
    zoomFrame1.setImage(picture);

    // Sets a zoom frame format for zoomFrame2 object
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink);
    zoomFrame2.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    // Setting for Do not show background for zoomFrame2 object
    zoomFrame2.setShowBackground(false);

    // Saves the presentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Zoom раздела**

Zoom раздела — это ссылка на раздел вашей презентации. Вы можете использовать Zoom‑разделы, чтобы возвращаться к разделам, которые хотите особо подчеркнуть. Или использовать их, чтобы показать, как отдельные части вашей презентации связаны между собой. 

![overview_image](seczoomsel.png)

Для объектов Zoom раздела Aspose.Slides предоставляет интерфейс [ISectionZoomFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISectionZoomFrame) и некоторые методы в интерфейсе [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).

### **Создание Zoom‑кадров раздела**

Вы можете добавить Zoom‑кадр раздела на слайд следующим образом:

1.	Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2.	Создайте новый слайд. 
3.	Добавьте идентификационный фон к созданному слайду.
4.	Создайте новый раздел, к которому вы планируете привязать Zoom‑кадр. 
5.	Добавьте Zoom‑кадр раздела (содержащий ссылки на созданный раздел) на первый слайд.
6.	Запишите изменённую презентацию в файл PPTX.

``` java
Presentation pres = new Presentation();
try {
    //Добавляет новый слайд в презентацию
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Добавляет новый раздел в презентацию
    pres.getSections().addSection("Section 1", slide);

    // Добавляет объект SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // Сохраняет презентацию
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Создание Zoom‑кадров раздела с пользовательскими изображениями**

С помощью Aspose.Slides для Android через Java вы можете создать Zoom‑кадр раздела с другим изображением предварительного просмотра слайда следующим образом:

1.	Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2.	Создайте новый слайд.
3.	Добавьте идентификационный фон к созданному слайду.
4.	Создайте новый раздел, к которому вы планируете привязать Zoom‑кадр. 
5.	Создайте объект [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage), добавив изображение в коллекцию Images, связанную с объектом [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation), которое будет использоваться для заполнения кадра.
5.	Добавьте Zoom‑кадр раздела (содержащий ссылку на созданный раздел) на первый слайд.
6.	Запишите изменённую презентацию в файл PPTX.

``` java 
Presentation pres = new Presentation();
try {
    //Добавляет новый слайд в презентацию
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Добавляет новый раздел в презентацию
    pres.getSections().addSection("Section 1", slide);

    // Создает новое изображение для объекта zoom
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

### **Форматирование Zoom‑кадров раздела**

Для создания более сложных Zoom‑кадров раздела необходимо изменить форматирование простого кадра. Существует несколько вариантов форматирования, которые вы можете применить к Zoom‑кадру раздела.

Вы можете управлять форматированием Zoom‑кадра раздела на слайде следующим образом:

1.	Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2.	Создайте новый слайд.
3.	Добавьте идентификационный фон к созданному слайду.
4.	Создайте новый раздел, к которому вы планируете привязать Zoom‑кадр. 
5.	Добавьте Zoom‑кадр раздела (содержащий ссылки на созданный раздел) на первый слайд.
6.	Измените размер и позицию созданного объекта Zoom раздела.
7.	Создайте объект [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage), добавив изображение в коллекцию images, связанную с объектом [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation), которое будет использоваться для заполнения кадра.
8.	Установите пользовательское изображение для созданного Zoom‑кадра раздела.
9.	Установите возможность *возврата к исходному слайду из связанного раздела*. 
10.	Удалите фон с изображения Zoom‑кадра раздела.
11.	Измените формат линии для второго Zoom‑кадра.
12.	Измените длительность перехода.
13.	Запишите изменённую презентацию в файл PPTX.

``` java
Presentation pres = new Presentation();
try {
    //Добавляет новый слайд в презентацию
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Добавляет новый раздел в презентацию
    pres.getSections().addSection("Section 1", slide);

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


## **Обзорный Zoom**

Обзорный Zoom похож на целевую страницу, где одновременно отображаются все части вашей презентации. При демонстрации вы можете использовать Zoom, чтобы переходить от одного места презентации к другому в любом порядке. Вы можете проявлять креативность, перематывать вперёд или возвращаться к отдельным частям слайд‑шоу, не прерывая ход презентации.

![overview_image](sumzoomsel.png)

Для объектов Обзорного Zoom Aspose.Slides предоставляет интерфейсы [ISummaryZoomFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomFrame), [ISummaryZoomSection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSection) и [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSectionCollection), а также некоторые методы в интерфейсе [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).

### **Создание Сводного Zoom**

Вы можете добавить Сводный Zoom‑кадр на слайд следующим образом:

1.	Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2.	Создайте новые слайды с идентификационным фоном и новыми разделами для созданных слайдов.
3.	Добавьте Сводный Zoom‑кадр на первый слайд.
4.	Запишите изменённую презентацию в файл PPTX.

``` java 
Presentation pres = new Presentation();
try {
    //Добавляет новый слайд в презентацию
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Добавляет новый раздел в презентацию
    pres.getSections().addSection("Section 1", slide);

    //Добавляет новый слайд в презентацию
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Добавляет новый раздел в презентацию
    pres.getSections().addSection("Section 2", slide);

    //Добавляет новый слайд в презентацию
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Добавляет новый раздел в презентацию
    pres.getSections().addSection("Section 3", slide);

    //Добавяет новый слайд в презентацию
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.green);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Добавляет новый раздел в презентацию
    pres.getSections().addSection("Section 4", slide);

    // Добавляет объект SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // Сохраняет презентацию
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Добавление и удаление раздела Сводного Zoom**

Все разделы в Сводном Zoom‑кадре представлены объектами [ISummaryZoomSection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSection), которые хранятся в объекте [ISummaryZoomSectionCollection]. Вы можете добавить или удалить объект раздела Сводного Zoom через интерфейс [ISummaryZoomSectionCollection] следующим образом:

1.	Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2.	Создайте новые слайды с идентификационным фоном и новыми разделами для созданных слайдов.
3.	Добавьте Сводный Zoom‑кадр в первый слайд.
4.	Добавьте новый слайд и раздел в презентацию.
5.	Добавьте созданный раздел в Сводный Zoom‑кадр.
6.	Удалите первый раздел из Сводного Zoom‑кадра.
7.	Запишите изменённую презентацию в файл PPTX.

``` java
Presentation pres = new Presentation();
try {
    //Добавляет новый слайд в презентацию
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Добавляет новый раздел в презентацию
    pres.getSections().addSection("Section 1", slide);

    //Добавляет новый слайд в презентацию
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Добавляет новый раздел в презентацию
    pres.getSections().addSection("Section 2", slide);

    // Добавляет объект SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    //Добавляет новый слайд в презентацию
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Добавляет новый раздел в презентацию
    ISection section3 = pres.getSections().addSection("Section 3", slide);

    // Добавляет раздел в Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);

    // Удаляет раздел из Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));

    // Сохраняет презентацию
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Форматирование разделов Сводного Zoom**

Для создания более сложных объектов разделов Сводного Zoom необходимо изменить форматирование простого кадра. Существует несколько вариантов форматирования, которые вы можете применить к объекту раздела Сводного Zoom.

Вы можете контролировать форматирование объекта раздела Сводного Zoom в Сводном Zoom‑кадре следующим образом:

1.	Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2.	Создайте новые слайды с идентификационным фоном и новыми разделами для созданных слайдов.
3.	Добавьте Сводный Zoom‑кадр на первый слайд.
4.	Получите объект раздела Сводного Zoom для первого элемента из `ISummaryZoomSectionCollection`.
7.	Создайте объект [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage), добавив изображение в коллекцию images, связанную с объектом [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation), которое будет использоваться для заполнения кадра.
8.	Установите пользовательское изображение для созданного Zoom‑кадра раздела.
9.	Установите возможность *возврата к исходному слайду из связанного раздела*.
11.	Измените формат линии для второго Zoom‑кадра.
12.	Измените длительность перехода.
13.	Запишите изменённую презентацию в файл PPTX.

``` java
Presentation pres = new Presentation();
try {
    //Добавляет новый слайд в презентацию
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adds a new section to the presentation
    pres.getSections().addSection("Section 1", slide);

    //Adds a new slide to the presentation
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adds a new section to the presentation
    pres.getSections().addSection("Section 2", slide);

    // Adds a SummaryZoomFrame object
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // Gets the first SummaryZoomSection object
    ISummaryZoomSection summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);

    // Formatting for SummaryZoomSection object
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

    // Saves the presentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Могу ли я управлять возвратом к «родительскому» слайду после показа цели?**

Да. У [Zoom frame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zoomframe/) или [section](https://reference.aspose.com/slides/androidjava/com.aspose.slides/sectionzoomframe/) есть поведение возврата к родителю, которое при включении отправляет зрителей обратно к исходному слайду после посещения целевого содержимого.

**Могу ли я настроить «скорость» или длительность перехода Zoom?**

Да. Zoom поддерживает установку длительности перехода, что позволяет контролировать, сколько времени длится анимация перехода.

**Есть ли ограничения на количество объектов Zoom в презентации?**

Жёсткого ограничения API не задокументировано. Практические ограничения зависят от общей сложности презентации и производительности устройства зрителя. Можно добавить много Zoom‑кадров, но следует учитывать размер файла и время рендеринга.