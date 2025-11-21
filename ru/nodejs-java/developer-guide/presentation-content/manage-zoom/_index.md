---
title: Управление Zoom
type: docs
weight: 60
url: /ru/nodejs-java/manage-zoom/
keywords: "Zoom, кадр Zoom, Добавить масштаб, Форматировать кадр масштабирования, Summary zoom, презентация PowerPoint, Java, Aspose.Slides для Node.js через Java"
description: "Добавьте масштаб или кадры масштаба в презентации PowerPoint на JavaScript"
---

## **Overview**

Zooms in PowerPoint позволяют переходить к определённым слайдам, разделам и частям презентации и обратно. При представлении эта возможность быстро перемещаться по содержимому может оказаться очень полезной. 

![overview_image](overview.png)

* Чтобы суммировать всю презентацию на одном слайде, используйте [Summary Zoom](#Summary-Zoom).
* Чтобы показать только выбранные слайды, используйте [Slide Zoom](#Slide-Zoom).
* Чтобы показать только один раздел, используйте [Section Zoom](#Section-Zoom).

## **Slide Zoom**

Zoom слайда может сделать вашу презентацию более динамичной, позволяя свободно перемещаться между слайдами в любой выбранной вами последовательности без прерывания потока презентации. Zoom слайда отлично подходит для коротких презентаций без множества разделов, но его также можно использовать в различных сценариях.

Zoom слайда помогает углубиться в несколько кусков информации, создавая ощущение работы на едином холсте. 

![overview_image](slidezoomsel.png)

Для объектов Zoom слайда Aspose.Slides предоставляет перечисление [ZoomImageType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ZoomImageType), класс [ZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ZoomFrame) и некоторые методы класса [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection).

### **Creating Zoom Frames**

Вы можете добавить Zoom‑кадр на слайд следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Создайте новые слайды, к которым вы планируете привязать Zoom‑кадры. 
3. Добавьте идентификационный текст и фон к созданным слайдам.
4. Добавьте Zoom‑кадры (ссылающиеся на созданные слайды) на первый слайд.
5. Сохраните изменённую презентацию в файл PPTX.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Добавляет новые слайды в презентацию
    var slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    var slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // Создаёт фон для второго слайда
    slide2.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // Создаёт текстовое поле для второго слайда
    var autoshape = slide2.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // Создаёт фон для третьего слайда
    slide3.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "darkGray"));
    // Создаёт текстовое поле для третьего слайда
    autoshape = slide3.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");
    // Добавляет объекты ZoomFrame
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);
    // Сохраняет презентацию
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Creating Zoom Frames with Custom Images**

С помощью Aspose.Slides for Node.js via Java вы можете создать Zoom‑кадр с другим изображением предпросмотра слайда следующим образом:
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Создайте новый слайд, к которому вы планируете привязать Zoom‑кадр. 
3. Добавьте идентификационный текст и фон к слайду.
4. Создайте объект [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PPImage), добавив изображение в коллекцию Images, связанную с объектом [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation), которое будет использовано для заполнения кадра.
5. Добавьте Zoom‑кадры (ссылающиеся на созданный слайд) на первый слайд.
6. Сохраните изменённую презентацию в файл PPTX.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Добавляет новый слайд в презентацию
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // Создаёт фон для второго слайда
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // Создаёт текстовое поле для третьего слайда
    var autoshape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // Создаёт новое изображение для объекта зума
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Добавляет объект ZoomFrame
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);
    // Сохраняет презентацию
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Formatting Zoom Frames**

В предыдущих разделах мы показывали, как создать простые Zoom‑кадры. Чтобы создать более сложные Zoom‑кадры, необходимо изменить форматирование простого кадра. Существует несколько вариантов форматирования, которые можно применить к Zoom‑кадру. 

Вы можете управлять форматированием Zoom‑кадра на слайде следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Создайте новые слайды, к которым вы планируете привязать Zoom‑кадр. 
3. Добавьте некоторый идентификационный текст и фон к созданным слайдам.
4. Добавьте Zoom‑кадры (ссылающиеся на созданные слайды) на первый слайд.
5. Создайте объект [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PPImage), добавив изображение в коллекцию Images, связанную с объектом [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation), которое будет использовано для заполнения кадра.
6. Установите пользовательское изображение для первого объекта Zoom‑кадра.
7. Измените формат линии для второго объекта Zoom‑кадра.
8. Удалите фон из изображения второго объекта Zoom‑кадра.
5. Сохраните изменённую презентацию в файл PPTX.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Добавляет новые слайды в презентацию
    var slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    var slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // Создаёт фон для второго слайда
    slide2.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // Создаёт текстовое поле для второго слайда
    var autoshape = slide2.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // Создаёт фон для третьего слайда
    slide3.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "darkGray"));
    // Создаёт текстовое поле для третьего слайда
    autoshape = slide3.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");
    // Добавляет объекты ZoomFrame
    var zoomFrame1 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    var zoomFrame2 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);
    // Создаёт новое изображение для объекта зума
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Устанавливает пользовательское изображение для объекта zoomFrame1
    zoomFrame1.setImage(picture);
    // Устанавливает формат рамки зума для объекта zoomFrame2
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "pink"));
    zoomFrame2.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    // Настройка: не показывать фон для объекта zoomFrame2
    zoomFrame2.setShowBackground(false);
    // Сохраняет презентацию
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Section Zoom**

Section Zoom представляет собой ссылку на раздел вашей презентации. Вы можете использовать Section Zoom, чтобы возвращаться к разделам, которые хотите особенно подчеркнуть. Или использовать их для демонстрации того, как определённые части вашей презентации связаны между собой. 

![overview_image](seczoomsel.png)

Для объектов Section Zoom Aspose.Slides предоставляет класс [SectionZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SectionZoomFrame) и некоторые методы класса [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection).

### **Creating Section Zoom Frames**

Вы можете добавить Section Zoom‑кадр на слайд следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Создайте новый слайд. 
3. Добавьте идентификационный фон к созданному слайду.
4. Создайте новый раздел, к которому вы планируете привязать Zoom‑кадр. 
5. Добавьте Section Zoom‑кадр (ссылающийся на созданный раздел) на первый слайд.
6. Сохраните изменённую презентацию в файл PPTX.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Добавляет новый слайд в презентацию
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Добавляет новый раздел в презентацию
    pres.getSections().addSection("Section 1", slide);
    // Добавляет объект SectionZoomFrame
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));
    // Сохраняет презентацию
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Creating Section Zoom Frames with Custom Images**

С помощью Aspose.Slides for Node.js via Java вы можете создать Section Zoom‑кадр с другим изображением предпросмотра слайда следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Создайте новый слайд.
3. Добавьте идентификационный фон к созданному слайду.
4. Создайте новый раздел, к которому вы планируете привязать Zoom‑кадр. 
5. Создайте объект [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PPImage), добавив изображение в коллекцию Images, связанную с объектом [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation), которое будет использовано для заполнения кадра.
5. Добавьте Section Zoom‑кадр (ссылающийся на созданный раздел) на первый слайд.
6. Сохраните изменённую презентацию в файл PPTX.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Добавляет новый слайд в презентацию
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Добавляет новый раздел в презентацию
    pres.getSections().addSection("Section 1", slide);
    // Создаёт новое изображение для объекта зума
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Добавляет объект SectionZoomFrame
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1), picture);
    // Сохраняет презентацию
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Formatting Section Zoom Frames**

Чтобы создать более сложные Section Zoom‑кадры, необходимо изменить форматирование простого кадра. Существует несколько вариантов форматирования, которые можно применить к Section Zoom‑кадру. 

Вы можете управлять форматированием Section Zoom‑кадра на слайде следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Создайте новый слайд.
3. Добавьте идентификационный фон к созданному слайду.
4. Создайте новый раздел, к которому вы планируете привязать Zoom‑кадр. 
5. Добавьте Section Zoom‑кадр (ссылающийся на созданный раздел) на первый слайд.
6. Измените размер и позицию созданного Section Zoom‑объекта.
7. Создайте объект [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PPImage), добавив изображение в коллекцию Images, связанную с объектом [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation), которое будет использовано для заполнения кадра.
8. Установите пользовательское изображение для созданного Section Zoom‑кадра.
9. Установите возможность *возврата к оригинальному слайду из связанного раздела*. 
10. Удалите фон из изображения объекта Section Zoom‑кадра.
11. Измените формат линии для второго Zoom‑кадра.
12. Измените длительность перехода.
13. Сохраните изменённую презентацию в файл PPTX.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Добавляет новый слайд в презентацию
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Добавляет новый раздел в презентацию
    pres.getSections().addSection("Section 1", slide);
    // Добавляет объект SectionZoomFrame
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));
    // Форматирование для SectionZoomFrame
    sectionZoomFrame.setX(100);
    sectionZoomFrame.setY(300);
    sectionZoomFrame.setWidth(100);
    sectionZoomFrame.setHeight(75);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    sectionZoomFrame.setImage(picture);
    sectionZoomFrame.setReturnToParent(true);
    sectionZoomFrame.setShowBackground(false);
    sectionZoomFrame.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    sectionZoomFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    sectionZoomFrame.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    sectionZoomFrame.getLineFormat().setWidth(2.5);
    sectionZoomFrame.setTransitionDuration(1.5);
    // Сохраняет презентацию
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Summary Zoom**

Summary Zoom — это своего рода целевая страница, на которой отображаются все части вашей презентации одновременно. При представлении вы можете использовать Zoom, чтобы переходить от одного места к другому в любой последовательности. Вы можете проявлять креативность, перематывать вперёд или возвращаться к отдельным частям слайдшоу без нарушения течения презентации.

![overview_image](sumzoomsel.png)

Для объектов Summary Zoom Aspose.Slides предоставляет классы [SummaryZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SummaryZoomFrame), [SummaryZoomSection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SummaryZoomSection) и [SummaryZoomSectionCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SummaryZoomSectionCollection), а также некоторые методы класса [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection).

### **Creating Summary Zoom**

Вы можете добавить Summary Zoom‑кадр на слайд следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Создайте новые слайды с идентификационным фоном и новые разделы для созданных слайдов.
3. Добавьте Summary Zoom‑кадр на первый слайд.
4. Сохраните изменённую презентацию в файл PPTX.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Добавляет новый слайд в презентацию
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Добавляет новый раздел в презентацию
    pres.getSections().addSection("Section 1", slide);
    // Добавляет новый слайд в презентацию
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Добавляет новый раздел в презентацию
    pres.getSections().addSection("Section 2", slide);
    // Добавляет новый слайд в презентацию
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "magenta"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Добавляет новый раздел в презентацию
    pres.getSections().addSection("Section 3", slide);
    // Добавляет новый слайд в презентацию
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "green"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Добавляет новый раздел в презентацию
    pres.getSections().addSection("Section 4", slide);
    // Добавляет объект SummaryZoomFrame
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // Сохраняет презентацию
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Adding and Removing Summary Zoom Section**

Все разделы в Summary Zoom‑кадре представлены объектами [SummaryZoomSection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SummaryZoomSection), которые хранятся в объекте [SummaryZoomSectionCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SummaryZoomSectionCollection). Вы можете добавить или удалить объект Summary Zoom‑раздела через класс [SummaryZoomSectionCollection] следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Создайте новые слайды с идентификационным фоном и новые разделы для созданных слайдов.
3. Добавьте Summary Zoom‑кадр в первый слайд.
4. Добавьте новый слайд и раздел в презентацию.
5. Добавьте созданный раздел в Summary Zoom‑кадр.
6. Удалите первый раздел из Summary Zoom‑кадра.
7. Сохраните изменённую презентацию в файл PPTX.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Добавляет новый слайд в презентацию
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Добавляет новый раздел в презентацию
    pres.getSections().addSection("Section 1", slide);
    // Добавляет новый слайд в презентацию
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Добавляет новый раздел в презентацию
    pres.getSections().addSection("Section 2", slide);
    // Добавляет объект SummaryZoomFrame
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // Добавляет новый слайд в презентацию
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "magenta"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Добавляет новый раздел в презентацию
    var section3 = pres.getSections().addSection("Section 3", slide);
    // Добавляет раздел в Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);
    // Удаляет раздел из Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));
    // Сохраняет презентацию
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Formatting Summary Zoom Sections**

Чтобы создать более сложные объекты Summary Zoom‑разделов, необходимо изменить форматирование простого кадра. Существует несколько вариантов форматирования, которые можно применить к объекту Summary Zoom‑раздела. 

Вы можете управлять форматированием объекта Summary Zoom‑раздела в Summary Zoom‑кадре следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Создайте новые слайды с идентификационным фоном и новые разделы для созданных слайдов.
3. Добавьте Summary Zoom‑кадр на первый слайд.
4. Получите объект Summary Zoom‑раздела для первого элемента из `ISummaryZoomSectionCollection`.
7. Создайте объект [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PPImage), добавив изображение в коллекцию images, связанную с объектом [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation), которое будет использовано для заполнения кадра.
8. Установите пользовательское изображение для созданного Section Zoom‑кадра.
9. Установите возможность *возврата к оригинальному слайду из связанного раздела*. 
11. Измените формат линии для второго Zoom‑кадра.
12. Измените длительность перехода.
13. Сохраните изменённую презентацию в файл PPTX.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Добавляет новый слайд в презентацию
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Добавляет новый раздел в презентацию
    pres.getSections().addSection("Section 1", slide);
    // Добавляет новый слайд в презентацию
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Добавляет новый раздел в презентацию
    pres.getSections().addSection("Section 2", slide);
    // Добавляет объект SummaryZoomFrame
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // Получает первый объект SummaryZoomSection
    var summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);
    // Форматирование объекта SummaryZoomSection
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(picture);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    summarySection.setImage(picture);
    summarySection.setReturnToParent(false);
    summarySection.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    summarySection.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "black"));
    summarySection.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    summarySection.getLineFormat().setWidth(1.5);
    summarySection.setTransitionDuration(1.5);
    // Сохраняет презентацию
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Can I control returning to the 'parent' slide after showing the target?**

Yes. The [Zoom frame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomframe/) or [section](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sectionzoomframe/) has a `setReturnToParent` method that, when enabled, sends viewers back to the originating slide after they visit the target content.

**Can I adjust the 'speed' or duration of the Zoom transition?**

Yes. Zoom exposes a `setTransitionDuration` method so you can control how long the jump animation takes.

**Are there limits on how many Zoom objects a presentation can contain?**

There is no hard API limit documented. Practical limits depend on overall presentation complexity and the viewer's performance. You can add many Zoom frames, but consider file size and rendering time.