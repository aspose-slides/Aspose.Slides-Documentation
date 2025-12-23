---
title: Управление масштабированием презентации в PHP
linktitle: Управление зумом
type: docs
weight: 60
url: /ru/php-java/manage-zoom/
keywords:
- зум
- кадр зума
- масштабирование слайда
- масштабирование раздела
- обобщённый зум
- добавить зум
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Создавайте и настраивайте зум с помощью Aspose.Slides for PHP via Java — переходите между разделами, добавляйте миниатюры и переходы в презентациях PPT, PPTX и ODP."
---

## **Обзор**
Zoom в PowerPoint позволяет переходить к определённым слайдам, разделам и частям презентации и обратно. При выступлении эта возможность быстрой навигации по содержимому может быть очень полезной. 

![overview_image](overview.png)

* Чтобы суммировать всю презентацию на одном слайде, используйте [Summary Zoom](#Summary-Zoom).
* Чтобы показывать только выбранные слайды, используйте [Slide Zoom](#Slide-Zoom).
* Чтобы показывать только один раздел, используйте [Section Zoom](#Section-Zoom).

## **Slide Zoom**
Zoom слайда делает вашу презентацию более динамичной, позволяя свободно переходить между слайдами в любом порядке без прерывания подачи материала. Zoom слайды отлично подходят для коротких презентаций без множества разделов, но их можно использовать и в других сценариях.

Zoom слайды помогают углубиться в несколько блоков информации, оставаясь на едином холсте. 

![overview_image](slidezoomsel.png)

Для объектов Zoom слайда Aspose.Slides предоставляет перечисление [ZoomImageType](https://reference.aspose.com/slides/php-java/aspose.slides/ZoomImageType), интерфейс [IZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IZoomFrame) и некоторые методы интерфейса [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).

### **Create Zoom Frames**

Добавить Zoom‑кадр на слайд можно так:

1.	Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
2.	Create new slides to which you intend to link the zoom frames. 
3.	Add an identification text and background to the created slides.
4.	Add zoom frames (containing the references to created slides) to the first slide.
5.	Write the modified presentation as a PPTX file.

This PHP code shows you how to create a zoom frame on a slide:
```php
  $pres = new Presentation();
  try {
    # Добавляет новые слайды в презентацию
    $slide2 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide3 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # Создает фон для второго слайда
    $slide2->getBackground()->setType(BackgroundType::OwnBackground);
    $slide2->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide2->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # Создает текстовое поле для второго слайда
    $autoshape = $slide2->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # Создает фон для третьего слайда
    $slide3->getBackground()->setType(BackgroundType::OwnBackground);
    $slide3->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide3->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->darkGray);
    # Создает текстовое поле для третьего слайда
    $autoshape = $slide3->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Trird Slide");
    # Добавляет объекты ZoomFrame
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 250, 200, $slide2);
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(200, 250, 250, 200, $slide3);
    # Сохраняет презентацию
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Create Zoom Frames with Custom Images**
With Aspose.Slides for PHP via Java, you can create a zoom frame with a different slide preview image this way:
1.	Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
2.	Create a new slide to which you intend to link the zoom frame. 
3.	Add an identification text and background to the slide.
4.	Create an [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage) object by adding an image to the Images collection associated with the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) object that will be used to fill the frame.
5.	Add zoom frames (containing the reference to created slide) to the first slide.
6.	Write the modified presentation as a PPTX file.

This PHP code shows you how to create a zoom frame with a different image:
```php
  $pres = new Presentation();
  try {
    # Добавляет новый слайд в презентацию
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # Создает фон для второго слайда
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # Создает текстовое поле для третьего слайда
    $autoshape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # Создает новое изображение для объекта зума
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Добавляет объект ZoomFrame
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 300, 200, $slide, $picture);
    # Сохраняет презентацию
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Format Zoom Frames**
In the previous sections, we showed you how to create simple zoom frames. To create more complicated zoom frames, you have to alter a simple frame's formatting. There are several formatting options you can apply to a zoom frame. 

You can control a zoom frame's formatting on a slide this way:

1.	Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
2.	Create new slides to link to which you intend to link the zoom frame. 
3.	Add some identification text and background to the created slides.
4.	Add zoom frames (containing the references to the created slides) to the first slide.
5.	Create an [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage) object by adding an image to the Images collection associated with the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) object that will be used to fill the frame.
6	Set a custom image for the first zoom frame object.
7	Change the line format for the second zoom frame object.
8	Remove the background from an image of the second zoom frame object.
5.	Write the modified presentation as a PPTX file.

This PHP code shows you how to change a zoom frame's formatting on a slide:
```php
  $pres = new Presentation();
  try {
    # Добавляет новые слайды в презентацию
    $slide2 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide3 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # Создает фон для второго слайда
    $slide2->getBackground()->setType(BackgroundType::OwnBackground);
    $slide2->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide2->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # Создает текстовое поле для второго слайда
    $autoshape = $slide2->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # Создает фон для третьего слайда
    $slide3->getBackground()->setType(BackgroundType::OwnBackground);
    $slide3->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide3->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->darkGray);
    # Создает текстовое поле для третьего слайда
    $autoshape = $slide3->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Trird Slide");
    # Добавляет объекты ZoomFrame
    $zoomFrame1 = $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 250, 200, $slide2);
    $zoomFrame2 = $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(200, 250, 250, 200, $slide3);
    # Создает новое изображение для объекта зума
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Устанавливает пользовательское изображение для объекта zoomFrame1
    $zoomFrame1->setImage($picture);
    # Устанавливает формат рамки зума для объекта zoomFrame2
    $zoomFrame2->getLineFormat()->setWidth(5);
    $zoomFrame2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $zoomFrame2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->pink);
    $zoomFrame2->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    # Настройка: не отображать фон для объекта zoomFrame2
    $zoomFrame2->setShowBackground(false);
    # Сохраняет презентацию
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Section Zoom**

Section Zoom — это ссылка на раздел вашей презентации. Вы можете использовать Section Zoom, чтобы возвращаться к разделам, которые хотите особо подчеркнуть, или показать, как отдельные части презентации взаимосвязаны. 

![overview_image](seczoomsel.png)

Для объектов Section Zoom Aspose.Slides предоставляет интерфейс [ISectionZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ISectionZoomFrame) и некоторые методы интерфейса [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).

### **Create Section Zoom Frames**

Add a section zoom frame to a slide this way:

1.	Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
2.	Create a new slide. 
3.	Add an identification background to the created slide.
4.	Create a new section to which you intend to link the zoom frame. 
5.Add a section zoom frame (containing references to the created section) to the first slide.
6.Write the modified presentation as a PPTX file.

This PHP code shows you how to create a zoom frame on a slide:
```php
  $pres = new Presentation();
  try {
    # Добавляет новый слайд в презентацию
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Добавляет новый раздел в презентацию
    $pres->getSections()->addSection("Section 1", $slide);
    # Добавляет объект SectionZoomFrame
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1));
    # Сохраняет презентацию
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Create Section Zoom Frames with Custom Images**

Using Aspose.Slides for PHP via Java, you can create a section zoom frame with a different slide preview image this way:

1.	Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
2.	Create a new slide.
3.	Add an identification background to created slide.
4.	Create a new section to which you intend to link the zoom frame. 
5.	Create an [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage) object by adding an image to the Images collection associated with the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) object that will be used to fill the frame.
5.	Add a section zoom frame (containing a reference to the created section) to the first slide.
6.	Write the modified presentation as a PPTX file.

This PHP code shows you how to create a zoom frame with a different image:
```php
  $pres = new Presentation();
  try {
    # Добавляет новый слайд в презентацию
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Добавляет новый раздел в презентацию
    $pres->getSections()->addSection("Section 1", $slide);
    # Создает новое изображение для объекта зума
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Добавляет объект SectionZoomFrame
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1), $picture);
    # Сохраняет презентацию
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Format Section Zoom Frames**

To create more complicated section zoom frames, you have to alter a simple frame's formatting. There are several formatting options you can apply to a section zoom frame. 

You can control a section zoom frame's formatting on a slide this way:

1.	Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
2.	Create a new slide.
3.	Add identification background to created slide.
4.	Create a new section to which you intend to link the zoom frame. 
5.Add a section zoom frame (containing references to created section) to the first slide.
6.Change the size and position for the created section zoom object.
7.Create an [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage) object by adding an image to the Images collection associated with the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) object that will be used to fill the frame.
8.Set a custom image for the created section zoom frame object.
9.Set the *return to the original slide from the linked section* ability. 
10.Remove the background from an image of the section zoom frame object.
11.Change the line format for the second zoom frame object.
12.Change the transition duration.
13.Write the modified presentation as a PPTX file.

This PHP code shows you how to change a section zoom frame's formatting:
```php
  $pres = new Presentation();
  try {
    # Добавляет новый слайд в презентацию
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Добавляет новый раздел в презентацию
    $pres->getSections()->addSection("Section 1", $slide);
    # Добавляет объект SectionZoomFrame
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1));
    # Форматирование для SectionZoomFrame
    $sectionZoomFrame->setX(100);
    $sectionZoomFrame->setY(300);
    $sectionZoomFrame->setWidth(100);
    $sectionZoomFrame->setHeight(75);
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $sectionZoomFrame->setImage($picture);
    $sectionZoomFrame->setReturnToParent(true);
    $sectionZoomFrame->setShowBackground(false);
    $sectionZoomFrame->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $sectionZoomFrame->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $sectionZoomFrame->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $sectionZoomFrame->getLineFormat()->setWidth(2.5);
    $sectionZoomFrame->setTransitionDuration(1.5);
    # Сохраняет презентацию
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Summary Zoom**

Summary Zoom — это как стартовая страница, где одновременно отображаются все части вашей презентации. При выступлении вы можете использовать Zoom, чтобы переходить от одного места к другому в любом порядке, креативно переключаться, пропускать или возвращаться к отдельным элементам слайд-шоу без нарушения потока подачи.

![overview_image](sumzoomsel.png)

Для объектов Summary Zoom Aspose.Slides предоставляет интерфейсы [ISummaryZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomFrame), [ISummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSection) и [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSectionCollection), а также некоторые методы интерфейса [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).

### **Create a Summary Zoom**

Add a summary zoom frame to a slide this way:

1.	Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
2.	Create new slides with identification background and new sections for created slides.
3.	Add the summary zoom frame to the first slide.
4.Write the modified presentation as a PPTX file.

This PHP code shows you how to create a summary zoom frame on a slide:
```php
  $pres = new Presentation();
  try {
    # Добавляет новый слайд в презентацию
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Добавляет новый раздел в презентацию
    $pres->getSections()->addSection("Section 1", $slide);
    # Добавляет новый слайд в презентацию
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Добавляет новый раздел в презентацию
    $pres->getSections()->addSection("Section 2", $slide);
    # Добавляет новый слайд в презентацию
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->magenta);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Добавляет новый раздел в презентацию
    $pres->getSections()->addSection("Section 3", $slide);
    # Добавляет новый слайд в презентацию
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->green);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Добавляет новый раздел в презентацию
    $pres->getSections()->addSection("Section 4", $slide);
    # Добавляет объект SummaryZoomFrame
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # Сохраняет презентацию
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **Add and Remove a Summary Zoom Section**

All sections in a summary zoom frame are represented by [ISummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSection) objects, which are stored in the [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSectionCollection) object. You can add or remove a summary zoom section object through the [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSectionCollection) interface this way:

1.	Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
2.	Create new slides with identification background and new sections for created slides.
3.	Add a summary zoom frame into the first slide.
4.Add a new slide and section to the presentation.
5.Add the created section to the summary zoom frame.
6.Remove the first section from the summary zoom frame.
7.Write the modified presentation as a PPTX file.

This PHP code shows you how to add and remove sections in a summary zoom frame:
```php
  $pres = new Presentation();
  try {
    # Добавляет новый слайд в презентацию
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Добавляет новый раздел в презентацию
    $pres->getSections()->addSection("Section 1", $slide);
    # Добавляет новый слайд в презентацию
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Добавляет новый раздел в презентацию
    $pres->getSections()->addSection("Section 2", $slide);
    # Добавляет объект SummaryZoomFrame
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # Добавляет новый слайд в презентацию
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->magenta);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Добавляет новый раздел в презентацию
    $section3 = $pres->getSections()->addSection("Section 3", $slide);
    # Добавляет раздел в Summary Zoom
    $summaryZoomFrame->getSummaryZoomCollection()->addSummaryZoomSection($section3);
    # Удаляет раздел из Summary Zoom
    $summaryZoomFrame->getSummaryZoomCollection()->removeSummaryZoomSection($pres->getSections()->get_Item(1));
    # Сохраняет презентацию
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **Format Summary Zoom Sections**

To create more complicated summary zoom section objects, you have to alter a simple frame's formatting. There are several formatting options you can apply to a summary zoom section object. 

You can control the formatting for a summary zoom section object in a summary zoom frame this way:

1.	Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
2.	Create new slides with identification background and new sections for created slides.
3.	Add a summary zoom frame to the first slide.
4.Get a summary zoom section object for the first object from the `ISummaryZoomSectionCollection`.
7.Create an [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage) object by adding an image to the images collection associated with the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) object that will be used to fill the frame.
8.Set a custom image for the created section zoom frame object.
9.Set the *return to the original slide from the linked section* ability. 
11.Change the line format for the second zoom frame object.
12.Change the transition duration.
13.Write the modified presentation as a PPTX file.

This PHP code shows you how to change the formatting for a summary zoom section object:
```php
  $pres = new Presentation();
  try {
    # Добавляет новый слайд в презентацию
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Добавляет новый раздел в презентацию
    $pres->getSections()->addSection("Section 1", $slide);
    # Добавляет новый слайд в презентацию
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Добавляет новый раздел в презентацию
    $pres->getSections()->addSection("Section 2", $slide);
    # Добавляет объект SummaryZoomFrame
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # Получает первый объект SummaryZoomSection
    $summarySection = $summaryZoomFrame->getSummaryZoomCollection()->get_Item(0);
    # Форматирование объекта SummaryZoomSection
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($picture);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $summarySection->setImage($picture);
    $summarySection->setReturnToParent(false);
    $summarySection->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $summarySection->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->black);
    $summarySection->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $summarySection->getLineFormat()->setWidth(1.5);
    $summarySection->setTransitionDuration(1.5);
    # Сохраняет презентацию
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Can I control returning to the 'parent' slide after showing the target?**

Yes. The [Zoom frame](https://reference.aspose.com/slides/php-java/aspose.slides/zoomframe/) or [section](https://reference.aspose.com/slides/php-java/aspose.slides/sectionzoomframe/) has a `ReturnToParent` behavior that, when enabled, sends viewers back to the originating slide after they visit the target content.

**Can I adjust the 'speed' or duration of the Zoom transition?**

Yes. Zoom supports setting a `TransitionDuration` so you can control how long the jump animation takes.

**Are there limits on how many Zoom objects a presentation can contain?**

There is no hard API limit documented. Practical limits depend on overall presentation complexity and the viewer's performance. You can add many Zoom frames, but consider file size and rendering time.