---
title: Управление масштабированием презентации в Java
linktitle: Управление Zoom
type: docs
weight: 60
url: /ru/java/manage-zoom/
keywords:
- масштабирование
- zoom-кадр
- Zoom слайда
- Zoom раздела
- Zoom обзора
- добавить Zoom
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Создавайте и настраивайте Zoom с помощью Aspose.Slides для Java — переходите между разделами, добавляйте миниатюры и переходы в презентациях PPT, PPTX и ODP."
---

## **Обзор**
Zoom в PowerPoint позволяет переходить к определённым слайдам, разделам и частям презентации и возвращаться от них. При показе такая возможность быстрой навигации по содержимому может быть очень полезной. 

![overview_image](overview.png)

* Чтобы обобщить всю презентацию на одном слайде, используйте [Summary Zoom](#Summary-Zoom).
* Чтобы показывать только выбранные слайды, используйте [Slide Zoom](#Slide-Zoom).
* Чтобы показывать только один раздел, используйте [Section Zoom](#Section-Zoom).

## **Zoom слайда**
Zoom слайда может сделать вашу презентацию более динамичной, позволяя свободно переходить между слайдами в любом порядке без прерывания потока презентации. Zoom слайда отлично подходит для коротких презентаций без множества разделов, но его можно использовать и в различных сценариях.

Zoom слайда помогает углубиться в несколько блоков информации, ощущая их как часть единого холста. 

![overview_image](slidezoomsel.png)

Для объектов Zoom слайда Aspose.Slides предоставляет перечисление [ZoomImageType](https://reference.aspose.com/slides/java/com.aspose.slides/ZoomImageType), интерфейс [IZoomFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IZoomFrame) и некоторые методы в интерфейсе [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection).

### **Создание Zoom‑кадров**

Вы можете добавить Zoom‑кадр на слайд следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Создайте новые слайды, к которым планируете привязать Zoom‑кадры. 
3. Добавьте идентификационный текст и фон к созданным слайдам.
4. Добавьте Zoom‑кадры (содержащие ссылки на созданные слайды) на первый слайд.
5. Запишите изменённую презентацию в файл PPTX.

Этот Java‑код показывает, как создать Zoom‑кадр на слайде:
``` java
Presentation pres = new Presentation();
try {
    //Добавляет новые слайды в презентацию
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    //Создаёт фон для второго слайда
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    //Создаёт текстовое поле для второго слайда
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    //Создаёт фон для третьего слайда
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    //Создаёт текстовое поле для третьего слайда
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    //Добавляет объекты ZoomFrame
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    //Сохраняет презентацию
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Создание Zoom‑кадров с пользовательскими изображениями**
С помощью Aspose.Slides for Java вы можете создать Zoom‑кадр с отдельным изображением предпросмотра слайда следующим образом: 
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Создайте новый слайд, к которому планируете привязать Zoom‑кадр. 
3. Добавьте идентификационный текст и фон к слайду.
4. Создайте объект [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage), добавив изображение в коллекцию Images, связанную с объектом [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation), которое будет использовано для заполнения кадра.
5. Добавьте Zoom‑кадры (содержащие ссылку на созданный слайд) на первый слайд.
6. Запишите изменённую презентацию в файл PPTX.

Этот Java‑код показывает, как создать Zoom‑кадр с другим изображением:
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

    // Создаёт новое изображение для объекта zoom
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

### **Форматирование Zoom‑кадров**
В предыдущих разделах мы показали, как создать простые Zoom‑кадры. Чтобы создать более сложные Zoom‑кадры, необходимо изменить форматирование простого кадра. Существует несколько параметров форматирования, которые можно применить к Zoom‑кадру. 

Вы можете управлять форматированием Zoom‑кадра на слайде следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Создайте новые слайды, к которым планируете привязать Zoom‑кадр. 
3. Добавьте идентификационный текст и фон к созданным слайдам.
4. Добавьте Zoom‑кадры (содержащие ссылки на созданные слайды) на первый слайд.
5. Создайте объект [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage), добавив изображение в коллекцию Images, связанную с объектом [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation), которое будет использовано для заполнения кадра.
6. Установите пользовательское изображение для первого объекта Zoom‑кадра.
7. Измените формат линии для второго объекта Zoom‑кадра.
8. Удалите фон из изображения второго объекта Zoom‑кадра.
5. Запишите изменённую презентацию в файл PPTX.

Этот Java‑код показывает, как изменить форматирование Zoom‑кадра на слайде: 
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
    IZoomFrame zoomFrame1 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // Создаёт новое изображение для объекта zoom
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    // Устанавливает пользовательское изображение для объекта zoomFrame1
    zoomFrame1.setImage(picture);

    // Устанавливает формат рамки zoom для объекта zoomFrame2
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink);
    zoomFrame2.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    // Настройка: не показывать фон для объекта zoomFrame2
    zoomFrame2.setShowBackground(false);

    // Сохраняет презентацию
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Zoom раздела**

Zoom раздела — это ссылка на раздел вашей презентации. Вы можете использовать Zoom разделов, чтобы возвращаться к разделам, которые хотите особо подчеркнуть. Или использовать их, чтобы показать, как отдельные части вашей презентации связаны между собой. 

![overview_image](seczoomsel.png)

Для объектов Zoom раздела Aspose.Slides предоставляет интерфейс [ISectionZoomFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ISectionZoomFrame) и некоторые методы в интерфейсе [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection).

### **Создание Zoom‑кадров раздела**

Вы можете добавить Zoom‑кадр раздела на слайд следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Создайте новый слайд. 
3. Добавьте идентификационный фон к созданному слайду.
4. Создайте новый раздел, к которому планируете привязать Zoom‑кадр. 
5. Добавьте Zoom‑кадр раздела (содержащий ссылки на созданный раздел) на первый слайд.
6. Запишите изменённую презентацию в файл PPTX.

Этот Java‑код показывает, как создать Zoom‑кадр на слайде:
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

С помощью Aspose.Slides for Java вы можете создать Zoom‑кадр раздела с отдельным изображением предпросмотра слайда следующим образом: 

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Создайте новый слайд.
3. Добавьте идентификационный фон к созданному слайду.
4. Создайте новый раздел, к которому планируете привязать Zoom‑кадр. 
5. Создайте объект [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage), добавив изображение в коллекцию Images, связанную с объектом [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation), которое будет использовано для заполнения кадра.
5. Добавьте Zoom‑кадр раздела (содержащий ссылку на созданный раздел) на первый слайд.
6. Запишите изменённую презентацию в файл PPTX.

Этот Java‑код показывает, как создать Zoom‑кадр с другим изображением:
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

    // Создаёт новое изображение для объекта zoom
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

Чтобы создать более сложные Zoom‑кадры раздела, необходимо изменить форматирование простого кадра. Существует несколько параметров форматирования, которые можно применить к Zoom‑кадру раздела. 

Вы можете управлять форматированием Zoom‑кадра раздела на слайде следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Создайте новый слайд.
3. Добавьте идентификационный фон к созданному слайду.
4. Создайте новый раздел, к которому планируете привязать Zoom‑кадр. 
5. Добавьте Zoom‑кадр раздела (содержащий ссылки на созданный раздел) на первый слайд.
6. Измените размер и позицию созданного объекта Zoom‑раздела.
7. Создайте объект [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage), добавив изображение в коллекцию Images, связанную с объектом [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation), которое будет использовано для заполнения кадра.
8. Установите пользовательское изображение для созданного объекта Zoom‑раздела.
9. Установите возможность *return to the original slide from the linked section*.
10. Удалите фон из изображения объекта Zoom‑раздела.
11. Измените формат линии для второго объекта Zoom‑кадра.
12. Измените длительность перехода.
13. Запишите изменённую презентацию в файл PPTX.

Этот Java‑код показывает, как изменить форматирование Zoom‑кадра раздела:
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


## **Zoom‑обзора**

Zoom‑обзора похож на целевую страницу, где одновременно отображаются все части вашей презентации. При показе вы можете использовать Zoom, чтобы переходить от одной части презентации к другой в любом порядке. Вы можете творчески пропускать части или возвращаться к уже просмотренным без прерывания потока презентации.

![overview_image](sumzoomsel.png)

Для объектов Zoom‑обзора Aspose.Slides предоставляет интерфейсы [ISummaryZoomFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomFrame), [ISummaryZoomSection](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomSection) и [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomSectionCollection), а также некоторые методы в интерфейсе [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection).

### **Создание Zoom‑обзора**

Вы можете добавить Zoom‑обзорный кадр на слайд следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Создайте новые слайды с идентификационным фоном и новыми разделами для созданных слайдов.
3. Добавьте Zoom‑обзорный кадр на первый слайд.
4. Запишите изменённую презентацию в файл PPTX.

Этот Java‑код показывает, как создать Zoom‑обзорный кадр на слайде:
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

    // Adds a new section to the presentation
    // Добавляет новый раздел в презентацию
    pres.getSections().addSection("Section 2", slide);

    //Добавляет новый слайд в презентацию
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adds a new section to the presentation
    // Добавляет новый раздел в презентацию
    pres.getSections().addSection("Section 3", slide);

    //Добавирует новый слайд в презентацию
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.green);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adds a new section to the presentation
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


### **Добавление и удаление раздела Zoom‑обзора**

Все разделы в Zoom‑обзорном кадре представлены объектами [ISummaryZoomSection](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomSection), которые хранятся в объекте [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomSectionCollection). Вы можете добавлять или удалять объект раздела Zoom‑обзора через интерфейс [ISummaryZoomSectionCollection] следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Создайте новые слайды с идентификационным фоном и новыми разделами для созданных слайдов.
3. Добавьте Zoom‑обзорный кадр в первый слайд.
4. Добавьте новый слайд и раздел в презентацию.
5. Добавьте созданный раздел в Zoom‑обзорный кадр.
6. Удалите первый раздел из Zoom‑обзорного кадра.
7. Запишите изменённую презентацию в файл PPTX.

Этот Java‑код показывает, как добавить и удалить разделы в Zoom‑обзорном кадре:
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

    // Adds a new section to the presentation
    // Добавляет новый раздел в презентацию
    pres.getSections().addSection("Section 2", slide);

    // Добавляет объект SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    //Добавляет новый слайд в презентацию
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adds a new section to the presentation
    // Добавляет новый раздел в презентацию
    ISection section3 = pres.getSections().addSection("Section 3", slide);

    // Adds a section to the Summary Zoom
    // Добавляет раздел к Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);

    // Removes section from the Summary Zoom
    // Удаляет раздел из Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));

    // Saves the presentation
    // Сохраняет презентацию
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Форматирование разделов Zoom‑обзора**

Чтобы создать более сложные объекты разделов Zoom‑обзора, необходимо изменить форматирование простого кадра. Существует несколько параметров форматирования, которые можно применить к объекту раздела Zoom‑обзора. 

Вы можете контролировать форматирование объекта раздела Zoom‑обзора в Zoom‑обзорном кадре следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Создайте новые слайды с идентификационным фоном и новыми разделами для созданных слайдов.
3. Добавьте Zoom‑обзорный кадр на первый слайд.
4. Получите объект раздела Zoom‑обзора первого объекта из `ISummaryZoomSectionCollection`.
7. Создайте объект [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage), добавив изображение в коллекцию images, связанную с объектом [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation), которое будет использовано для заполнения кадра.
8. Установите пользовательское изображение для созданного объекта Zoom‑раздела.
9. Установите возможность *return to the original slide from the linked section*.
11. Измените формат линии для второго объекта Zoom‑кадра.
12. Измените длительность перехода.
13. Запишите изменённую презентацию в файл PPTX.

Этот Java‑код показывает, как изменить форматирование объекта раздела Zoom‑обзора:
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

    // Получает первый объект SummaryZoomSection
    ISummaryZoomSection summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);

    // Форматирование объекта SummaryZoomSection
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


## **FAQ**

**Можно ли контролировать возврат к «родительскому» слайду после показа цели?**

Да. У [Zoom frame](https://reference.aspose.com/slides/java/com.aspose.slides/zoomframe/) или [section](https://reference.aspose.com/slides/java/com.aspose.slides/sectionzoomframe/) есть поведение `ReturnToParent`, которое при включении отправляет зрителей обратно к исходному слайду после посещения целевого содержимого.

**Можно ли настраивать «скорость» или длительность перехода Zoom?**

Да. Zoom поддерживает установку `TransitionDuration`, позволяя контролировать продолжительность анимации перехода.

**Есть ли ограничения на количество объектов Zoom в одной презентации?**

Жёстких ограничений API не задокументировано. Практические ограничения зависят от общей сложности презентации и производительности устройства просмотра. Можно добавить множество Zoom‑кадров, но следует учитывать размер файла и время рендеринга.