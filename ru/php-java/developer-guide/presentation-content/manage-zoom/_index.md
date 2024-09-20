---
title: Управление зумом
type: docs
weight: 60
url: /php-java/manage-zoom/
keywords: "Zoom, рамка зума, добавить зум, формат рамки зума, сводный зум, презентация PowerPoint, Java, Aspose.Slides для PHP через Java"
description: "Добавить зум или рамки зума в презентации PowerPoint"
---

## **Обзор**
Зумы в PowerPoint позволяют переходить к конкретным слайдам, разделам и частям презентации. Эта возможность быстро перемещаться по контенту может быть очень полезной во время презентации.

![overview_image](overview.png)

* Чтобы подвести итог всей презентации на одном слайде, используйте [Сводный зум](#Summary-Zoom).
* Чтобы показать только выбранные слайды, используйте [Зум слайда](#Slide-Zoom).
* Чтобы показать только один раздел, используйте [Зум секции](#Section-Zoom).

## **Зум слайда**
Зум слайда может сделать вашу презентацию более динамичной, позволяя вам свободно перемещаться между слайдами в любом порядке, который вы выберете, не останавливая поток вашей презентации. Зумы слайдов отлично подходят для коротких презентаций без множества разделов, но вы также можете использовать их в различных сценариях презентации.

Зумы слайдов помогают вам углубиться в несколько частей информации, при этом создавая ощущение, что вы находитесь на одном холсте.

![overview_image](slidezoomsel.png)

Для объектов зума слайдов Aspose.Slides предоставляет перечисление [ZoomImageType](https://reference.aspose.com/slides/php-java/aspose.slides/ZoomImageType), интерфейс [IZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IZoomFrame) и несколько методов в интерфейсе [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).

### **Создание рамок зума**

Вы можете добавить рамку зума на слайд следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Создайте новые слайды, к которым вы планируете привязать рамки зума.
3. Добавьте текст идентификации и фон к созданным слайдам.
4. Добавьте рамки зума (ссылающиеся на созданные слайды) на первый слайд.
5. Запишите измененную презентацию в файл PPTX.

Этот код PHP показывает, как создать рамку зума на слайде:

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
    $autoshape->getTextFrame()->setText("Второй слайд");
    # Создает фон для третьего слайда
    $slide3->getBackground()->setType(BackgroundType::OwnBackground);
    $slide3->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide3->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->darkGray);
    # Создает текстовое поле для третьего слайда
    $autoshape = $slide3->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Третий слайд");
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
### **Создание рамок зума с пользовательскими изображениями**
С помощью Aspose.Slides для PHP через Java вы можете создать рамку зума с другим изображением предварительного просмотра слайда следующим образом:
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Создайте новый слайд, к которому вы планируете привязать рамку зума.
3. Добавьте текст идентификации и фон на слайд.
4. Создайте объект [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage), добавив изображение в коллекцию Изображений, связанную с объектом [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation), который будет использоваться для заполнения рамки.
5. Добавьте рамки зума (ссылающиеся на созданный слайд) на первый слайд.
6. Запишите измененную презентацию в файл PPTX.

Этот код PHP показывает, как создать рамку зума с другим изображением:

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
    $autoshape->getTextFrame()->setText("Второй слайд");
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
### **Форматирование рамок зума**
В предыдущих разделах мы показали, как создать простые рамки зума. Чтобы создать более сложные рамки зума, необходимо изменить форматирование простой рамки. Существует несколько параметров форматирования, которые вы можете применить к рамке зума. 

Вы можете управлять форматированием рамки зума на слайде следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Создайте новые слайды, которые вы планируете связать с рамкой зума. 
3. Добавьте некоторый текст идентификации и фон к созданным слайдам.
4. Добавьте рамки зума (ссылающиеся на созданные слайды) на первый слайд.
5. Создайте объект [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage), добавив изображение в коллекцию Изображений, связанную с объектом [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation), который будет использоваться для заполнения рамки.
6. Установите пользовательское изображение для первого объекта рамки зума.
7. Измените формат линии для второго объекта рамки зума.
8. Удалите фон у изображения второго объекта рамки зума.
5. Запишите измененную презентацию в файл PPTX.

Этот код PHP показывает, как изменить форматирование рамки зума на слайде:

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
    $autoshape->getTextFrame()->setText("Второй слайд");
    # Создает фон для третьего слайда
    $slide3->getBackground()->setType(BackgroundType::OwnBackground);
    $slide3->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide3->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->darkGray);
    # Создает текстовое поле для третьего слайда
    $autoshape = $slide3->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Третий слайд");
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
    # Настройки для показа фона для объекта zoomFrame2
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

## **Зум секции**

Зум секции — это ссылка на раздел вашей презентации. Вы можете использовать зумы секций, чтобы вернуться к разделам, которые вы хотите действительно подчеркнуть. Или вы можете использовать их, чтобы показать, как определенные части вашей презентации взаимосвязаны.

![overview_image](seczoomsel.png)

Для объектов зума секций Aspose.Slides предоставляет интерфейс [ISectionZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ISectionZoomFrame) и несколько методов в интерфейсе [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).

### **Создание рамок зума секции**

Вы можете добавить рамку зума секции на слайд следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Создайте новый слайд. 
3. Добавьте идентификационный фон на созданный слайд.
4. Создайте новый раздел, к которому вы планируете привязать рамку зума. 
5. Добавьте рамку зума секции (ссылающуюся на созданный раздел) на первый слайд.
6. Запишите измененную презентацию в файл PPTX.

Этот код PHP показывает, как создать рамку зума на слайде:

```php
  $pres = new Presentation();
  try {
    # Добавляет новый слайд в презентацию
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Добавляет новый раздел в презентацию
    $pres->getSections()->addSection("Раздел 1", $slide);
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
### **Создание рамок зума секции с пользовательскими изображениями**

Используя Aspose.Slides для PHP через Java, вы можете создать рамку зума секции с другим изображением предварительного просмотра слайда следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Создайте новый слайд.
3. Добавьте идентификационный фон на созданный слайд.
4. Создайте новый раздел, к которому вы планируете привязать рамку зума. 
5. Создайте объект [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage), добавив изображение в коллекцию Изображений, связанную с объектом [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation), который будет использоваться для заполнения рамки.
5. Добавьте рамку зума секции (ссылающуюся на созданный раздел) на первый слайд.
6. Запишите измененную презентацию в файл PPTX.

Этот код PHP показывает, как создать рамку зума с другим изображением:

```php
  $pres = new Presentation();
  try {
    # Добавляет новый слайд в презентацию
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Добавляет новый раздел в презентацию
    $pres->getSections()->addSection("Раздел 1", $slide);
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
### **Форматирование рамок зума секции**

Чтобы создать более сложные рамки зума секции, необходимо изменить форматирование простой рамки. Существует несколько параметров форматирования, которые вы можете применить к рамке зума секции. 

Вы можете управлять форматированием рамки зума секции на слайде следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Создайте новый слайд.
3. Добавьте идентификационный фон на созданный слайд.
4. Создайте новый раздел, к которому вы планируете привязать рамку зума. 
5. Добавьте рамку зума секции (ссылающуюся на созданный раздел) на первый слайд.
6. Измените размер и положение для созданного объекта зума секции.
7. Создайте объект [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage), добавив изображение в коллекцию Изображений, связанную с объектом [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation), который будет использоваться для заполнения рамки.
8. Установите пользовательское изображение для созданного объекта рамки зума секции.
9. Установите возможность *возврата на оригинальный слайд из связанного раздела*.
10. Удалите фон у изображения объекта рамки зума секции.
11. Измените формат линии для второго объекта зума.
12. Измените продолжительность перехода.
13. Запишите измененную презентацию в файл PPTX.

Этот код PHP показывает, как изменить форматирование рамки зума секции:

```php
  $pres = new Presentation();
  try {
    # Добавляет новый слайд в презентацию
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Добавляет новый раздел в презентацию
    $pres->getSections()->addSection("Раздел 1", $slide);
    # Добавляет новый объект SectionZoomFrame
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


## **Сводный зум**

Сводный зум подобен целевой странице, на которой отображаются все части вашей презентации одновременно. Когда вы презентуете, вы можете использовать зум, чтобы перемещаться из одного места в вашей презентации в другое в любом порядке, который вам нравится. Вы можете проявлять креативность, пропускать вперед или повторно посещать части вашей слайд-шоу, не прерывая поток вашей презентации.

![overview_image](sumzoomsel.png)

Для объектов сводного зума Aspose.Slides предоставляет интерфейсы [ISummaryZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomFrame), [ISummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSection) и [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSectionCollection), а также некоторые методы в интерфейсе [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).

### **Создание сводного зума**

Вы можете добавить рамку сводного зума на слайд следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Создайте новые слайды с фоном идентификации и новыми разделами для созданных слайдов.
3. Добавьте рамку сводного зума на первый слайд.
4. Запишите измененную презентацию в файл PPTX.

Этот код PHP показывает, как создать рамку сводного зума на слайде:

```php
  $pres = new Presentation();
  try {
    # Добавляет новый слайд в презентацию
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Добавляет новый раздел в презентацию
    $pres->getSections()->addSection("Раздел 1", $slide);
    # Добавляет новый слайд в презентацию
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Добавляет новый раздел в презентацию
    $pres->getSections()->addSection("Раздел 2", $slide);
    # Добавляет новый слайд в презентацию
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->magenta);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Добавляет новый раздел в презентацию
    $pres->getSections()->addSection("Раздел 3", $slide);
    # Добавляет новый слайд в презентацию
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->green);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Добавляет новый раздел в презентацию
    $pres->getSections()->addSection("Раздел 4", $slide);
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

### **Добавление и удаление секции сводного зума**

Все секции в рамке сводного зума представлены объектами [ISummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSection), которые хранятся в объекте [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSectionCollection). Вы можете добавить или удалить объект секции сводного зума через интерфейс [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSectionCollection) следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Создайте новые слайды с фоном идентификации и новыми разделами для созданных слайдов.
3. Добавьте рамку сводного зума на первый слайд.
4. Добавьте новый слайд и раздел в презентацию.
5. Добавьте созданный раздел в рамку сводного зума.
6. Удалите первый раздел из рамки сводного зума.
7. Запишите измененную презентацию в файл PPTX.

Этот код PHP показывает, как добавить и удалить секции в рамке сводного зума:

```php
  $pres = new Presentation();
  try {
    # Добавляет новый слайд в презентацию
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Добавляет новый раздел в презентацию
    $pres->getSections()->addSection("Раздел 1", $slide);
    # Добавляет новый слайд в презентацию
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Добавляет новый раздел в презентацию
    $pres->getSections()->addSection("Раздел 2", $slide);
    # Добавляет объект SummaryZoomFrame
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # Добавляет новый слайд в презентацию
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->magenta);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Добавляет новый раздел в презентацию
    $section3 = $pres->getSections()->addSection("Раздел 3", $slide);
    # Добавляет секцию в сводный зум
    $summaryZoomFrame->getSummaryZoomCollection()->addSummaryZoomSection($section3);
    # Удаляет секцию из сводного зума
    $summaryZoomFrame->getSummaryZoomCollection()->removeSummaryZoomSection($pres->getSections()->get_Item(1));
    # Сохраняет презентацию
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Форматирование секций сводного зума**

Чтобы создать более сложные объекты секции сводного зума, необходимо изменить форматирование простой рамки. Существует несколько параметров форматирования, которые вы можете применить к объекту секции сводного зума. 

Вы можете управлять форматированием объекта секции сводного зума в рамке сводного зума следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Создайте новые слайды с фоном идентификации и новыми разделами для созданных слайдов.
3. Добавьте рамку сводного зума на первый слайд.
4. Получите объект секции сводного зума для первого объекта из `ISummaryZoomSectionCollection`.
7. Создайте объект [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage), добавив изображение в коллекцию изображений, связанную с объектом [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation), который будет использоваться для заполнения рамки.
8. Установите пользовательское изображение для созданного объекта рамки секции сводного зума.
9. Установите возможность *возврата на оригинальный слайд из связанного раздела*.
11. Измените формат линии для второго объекта зума.
12. Измените продолжительность перехода.
13. Запишите измененную презентацию в файл PPTX.

Этот код PHP показывает, как изменить форматирование объекта секции сводного зума:

```php
  $pres = new Presentation();
  try {
    # Добавляет новый слайд в презентацию
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Добавляет новый раздел в презентацию
    $pres->getSections()->addSection("Раздел 1", $slide);
    # Добавляет новый слайд в презентацию
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Добавляет новый раздел в презентацию
    $pres->getSections()->addSection("Раздел 2", $slide);
    # Добавляет объект SummaryZoomFrame
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # Получает первый объект SummaryZoomSection
    $summarySection = $summaryZoomFrame->getSummaryZoomCollection()->get_Item(0);
    # Форматирование для объекта SummaryZoomSection
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
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