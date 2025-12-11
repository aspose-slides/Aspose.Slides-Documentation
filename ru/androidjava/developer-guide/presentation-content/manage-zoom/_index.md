---
title: Управление масштабированием презентации на Android
linktitle: Управление Zoom
type: docs
weight: 60
url: /ru/androidjava/manage-zoom/
keywords:
- масштабирование
- рамка масштабирования
- масштабирование слайда
- масштабирование раздела
- масштабирование сводки
- добавить масштабирование
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Создавайте и настраивайте Zoom с помощью Aspose.Slides для Android через Java — переключайтесь между разделами, добавляйте миниатюры и переходы в презентациях форматов PPT, PPTX и ODP."
---

## **Обзор**
Zoom в PowerPoint позволяет переходить к определённым слайдам, разделам и частям презентации и обратно. При показе эта возможность быстрого перемещения по контенту может быть очень полезна. 

![изображение_обзора](overview.png)

* Чтобы суммировать всю презентацию на одном слайде, используйте [Сводный Zoom](#Summary-Zoom).
* Чтобы показывать только выбранные слайды, используйте [Zoom Слайда](#Slide-Zoom).
* Чтобы показывать только один раздел, используйте [Zoom Раздела](#Section-Zoom).

## **Zoom Слайда**
Zoom слайда может сделать вашу презентацию более динамичной, позволяя свободно перемещаться между слайдами в любом порядке без прерывания потока презентации. Zoom‑слайды отлично подходят для коротких презентаций без множества разделов, но их можно использовать и в других сценариях.

Zoom‑слайды помогают глубже изучать несколько фрагментов информации, оставаясь на едином полотне. 

![изображение_обзора](slidezoomsel.png)

Для объектов Zoom слайда Aspose.Slides предоставляет перечисление [ZoomImageType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ZoomImageType), интерфейс [IZoomFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IZoomFrame) и некоторые методы интерфейса [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).

### **Создание Zoom‑рамок**

Вы можете добавить Zoom‑рамку на слайд следующим образом:

1.	Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2.	Создайте новые слайды, к которым планируете привязать Zoom‑рамки. 
3.	Добавьте идентификационный текст и фон к созданным слайдам.
4.	Добавьте Zoom‑рамки (содержит ссылки на созданные слайды) на первый слайд.
5.	Запишите изменённую презентацию в файл PPTX.

Этот Java‑код демонстрирует создание Zoom‑рамки на слайде:
``` java
Presentation pres = new Presentation();
try {
    //Добавляет новые слайды в презентацию
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Создаёт фон для второго слайда
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Создаёт текстовое поле для второго слайда
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // Создаёт фон для третьего слайда
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // Создаёт текстовое поле для третьего слайда
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

### **Создание Zoom‑рамок с пользовательскими изображениями**
С помощью Aspose.Slides for Android via Java вы можете создать Zoom‑рамку с другим изображением предпросмотра слайда следующим образом:
1.	Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2.	Создайте новый слайд, к которому планируете привязать Zoom‑рамку. 
3.	Добавьте идентификационный текст и фон к слайду.
4.	Создайте объект [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage), добавив изображение в коллекцию Images, связанную с объектом [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation), которое будет использовано для заполнения рамки.
5.	Добавьте Zoom‑рамки (содержит ссылку на созданный слайд) на первый слайд.
6.	Запишите изменённую презентацию в файл PPTX.

Этот Java‑код демонстрирует создание Zoom‑рамки с другим изображением:
``` java
Presentation pres = new Presentation();
try {
    //Добавляет новый слайд в презентацию
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Создаёт фон для второго слайда
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Создаёт текстовое поле для третьего слайда
    IAutoShape autoshape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // Создаёт новое изображение для объекта Zoom
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

### **Форматирование Zoom‑рамок**
В предыдущих разделах мы показывали, как создать простые Zoom‑рамки. Чтобы создать более сложные Zoom‑рамки, необходимо изменить форматирование простой рамки. Существует несколько параметров форматирования, которые можно применить к Zoom‑рамке. 

Вы можете управлять форматированием Zoom‑рамки на слайде следующим образом:

1.	Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2.	Создайте новые слайды, к которым планируете привязать Zoom‑рамку. 
3.	Добавьте некоторый идентификационный текст и фон к созданным слайдам.
4.	Добавьте Zoom‑рамки (содержит ссылки на созданные слайды) на первый слайд.
5.	Создайте объект [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage), добавив изображение в коллекцию Images, связанную с объектом [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation), которое будет использовано для заполнения рамки.
6.	Установите пользовательское изображение для первой Zoom‑рамки.
7.	Измените формат линии для второй Zoom‑рамки.
8.	Удалите фон изображения второй Zoom‑рамки.
5.	Запишите изменённую презентацию в файл PPTX.

Этот Java‑код демонстрирует изменение форматирования Zoom‑рамки на слайде: 
``` java 
Presentation pres = new Presentation();
try {
    //Добавляет новые слайды в презентацию
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Creates a background for the second slide
    // Создаёт фон для второго слайда
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Creates a text box for the second slide
    // Создаёт текстовое поле для второго слайда
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // Creates a background for the third slide
    // Создаёт фон для третьего слайда
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // Creates a text box for the third slide
    // Создаёт текстовое поле для третьего слайда
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    //Adds ZoomFrame objects
    //Добавляет объекты ZoomFrame
    IZoomFrame zoomFrame1 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // Creates a new image for the zoom object
    // Создаёт новое изображение для объекта Zoom
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    // Sets custom image for zoomFrame1 object
    // Устанавливает пользовательское изображение для объекта zoomFrame1
    zoomFrame1.setImage(picture);

    // Sets a zoom frame format for the zoomFrame2 object
    // Устанавливает формат рамки зума для объекта zoomFrame2
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink);
    zoomFrame2.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    // Setting for Do not show background for zoomFrame2 object
    // Настройка: не показывать фон для объекта zoomFrame2
    zoomFrame2.setShowBackground(false);

    // Saves the presentation
    // Сохраняет презентацию
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Zoom Раздела**

Zoom раздела – это ссылка на раздел в вашей презентации. Вы можете использовать Zoom‑разделы, чтобы возвращаться к разделам, которые хотите особо подчеркнуть, либо чтобы показать, как отдельные части вашей презентации соединяются между собой. 

![изображение_обзора](seczoomsel.png)

Для объектов Zoom раздела Aspose.Slides предоставляет интерфейс [ISectionZoomFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISectionZoomFrame) и некоторые методы интерфейса [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).

### **Создание Zoom‑рамок раздела**

Вы можете добавить Zoom‑рамку раздела на слайд следующим образом:

1.	Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2.	Создайте новый слайд. 
3.	Добавьте идентификационный фон к созданному слайду.
4.	Создайте новый раздел, к которому планируете привязать Zoom‑рамку. 
5.	Добавьте Zoom‑рамку раздела (содержит ссылки на созданный раздел) на первый слайд.
6.	Запишите изменённую презентацию в файл PPTX.

Этот Java‑код демонстрирует создание Zoom‑рамки на слайде:
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

### **Создание Zoom‑рамок раздела с пользовательскими изображениями**

С помощью Aspose.Slides for Android via Java вы можете создать Zoom‑рамку раздела с другим изображением предпросмотра слайда следующим образом:

1.	Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2.	Создайте новый слайд.
3.	Добавьте идентификационный фон к созданному слайду.
4.	Создайте новый раздел, к которому планируете привязать Zoom‑рамку. 
5.	Создайте объект [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage), добавив изображение в коллекцию Images, связанную с объектом [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation), которое будет использовано для заполнения рамки.
5.	Добавьте Zoom‑рамку раздела (содержит ссылку на созданный раздел) на первый слайд.
6.	Запишите изменённую презентацию в файл PPTX.

Этот Java‑код демонстрирует создание Zoom‑рамки с другим изображением:
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

    //Создаёт новое изображение для объекта Zoom
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

### **Форматирование Zoom‑рамок раздела**

Чтобы создать более сложные Zoom‑рамки раздела, необходимо изменить форматирование простой рамки. Существует несколько параметров форматирования, которые можно применить к Zoom‑рамке раздела. 

Вы можете управлять форматированием Zoom‑рамки раздела на слайде следующим образом:

1.	Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2.	Создайте новый слайд.
3.	Добавьте идентификационный фон к созданному слайду.
4.	Создайте новый раздел, к которому планируете привязать Zoom‑рамку. 
5.	Добавьте Zoom‑рамку раздела (содержит ссылки на созданный раздел) на первый слайд.
6.	Измените размер и положение созданного объекта Zoom‑раздела.
7.	Создайте объект [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage), добавив изображение в коллекцию Images, связанную с объектом [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation), которое будет использовано для заполнения рамки.
8.	Установите пользовательское изображение для созданного объекта Zoom‑раздела.
9.	Установите возможность *возврата к оригинальному слайду из связанного раздела*. 
10.	Удалите фон изображения объекта Zoom‑раздела.
11.	Измените формат линии для второго Zoom‑рамки.
12.	Измените длительность перехода.
13.	Запишите изменённую презентацию в файл PPTX.

Этот Java‑код демонстрирует изменение форматирования Zoom‑рамки раздела:
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

    // Форматирование SectionZoomFrame
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



## **Сводный Zoom**

Сводный Zoom подобен посадочной странице, где одновременно отображаются все части вашей презентации. При показе вы можете использовать Zoom, чтобы переходить от одного места к другому в любом порядке, пропускать части или возвращаться к уже просмотренным слайдам, не прерывая поток презентации.

![изображение_обзора](sumzoomsel.png)

Для объектов Сводного Zoom Aspose.Slides предоставляет интерфейсы [ISummaryZoomFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomFrame), [ISummaryZoomSection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSection) и [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSectionCollection), а также некоторые методы интерфейса [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).

### **Создание Сводного Zoom**

Вы можете добавить Сводный Zoom‑фрейм на слайд следующим образом:

1.	Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2.	Создайте новые слайды с идентификационным фоном и новыми разделами для созданных слайдов.
3.	Добавьте Сводный Zoom‑фрейм на первый слайд.
4.	Запишите изменённую презентацию в файл PPTX.

Этот Java‑код демонстрирует создание Сводного Zoom‑фрейма на слайде:
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

    // Adds a SummaryZoomFrame object
    // Добавляет объект SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // Saves the presentation
    // Сохраняет презентацию
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Добавление и удаление секции Сводного Zoom**

Все секции в Сводном Zoom‑фрейме представлены объектами [ISummaryZoomSection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSection), которые хранятся в объекте [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSectionCollection). Вы можете добавить или удалить объект секции Сводного Zoom через интерфейс [ISummaryZoomSectionCollection] следующим образом:

1.	Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2.	Создайте новые слайды с идентификационным фоном и новыми разделами для созданных слайдов.
3.	Добавьте Сводный Zoom‑фрейм в первый слайд.
4.	Добавьте новый слайд и раздел в презентацию.
5.	Добавьте созданный раздел в Сводный Zoom‑фрейм.
6.	Удалите первую секцию из Сводного Zoom‑фрейма.
7.	Запишите изменённую презентацию в файл PPTX.

Этот Java‑код демонстрирует добавление и удаление секций в Сводном Zoom‑фрейме:
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

    //Добавает новый слайд в презентацию
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Добавляет новый раздел в презентацию
    pres.getSections().addSection("Section 2", slide);

    // Добавляет объект SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    //Добавает новый слайд в презентацию
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


### **Форматирование секций Сводного Zoom**

Чтобы создать более сложные объекты секций Сводного Zoom, необходимо изменить форматирование простой рамки. Существует несколько параметров форматирования, которые можно применить к объекту секции Сводного Zoom. 

Вы можете управлять форматированием объекта секции Сводного Zoom в Сводном Zoom‑фрейме следующим образом:

1.	Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2.	Создайте новые слайды с идентификационным фоном и новыми разделами для созданных слайдов.
3.	Добавьте Сводный Zoom‑фрейм в первый слайд.
4.	Получите объект секции Сводного Zoom для первого объекта из `ISummaryZoomSectionCollection`.
7.	Создайте объект [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage), добавив изображение в коллекцию images, связанную с объектом [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation), которое будет использовано для заполнения рамки.
8.	Установите пользовательское изображение для созданного объекта секции Zoom.
9.	Установите возможность *возврата к оригинальному слайду из связанного раздела*. 
11.	Измените формат линии для второго Zoom‑рамки.
12.	Измените длительность перехода.
13.	Запишите изменённую презентацию в файл PPTX.

Этот Java‑код демонстрирует изменение форматирования объекта секции Сводного Zoom:
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

**Можно ли управлять возвращением к «родительскому» слайду после показа цели?**

Да. У [Zoom‑рамки](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zoomframe/) или [раздела](https://reference.aspose.com/slides/androidjava/com.aspose.slides/sectionzoomframe/) есть поведение возврата к родителю, которое при включении отправляет зрителей обратно к исходному слайду после посещения целевого контента.

**Можно ли регулировать «скорость» или длительность перехода Zoom?**

Да. Zoom поддерживает установку длительности перехода, позволяя контролировать, сколько времени занимает анимация перехода.

**Есть ли ограничения на количество Zoom‑объектов в презентации?**

 Жёстких ограничений API нет. Практические ограничения зависят от общей сложности презентации и производительности устройства. Можно добавить много Zoom‑рамок, но следует учитывать размер файла и время рендеринга.