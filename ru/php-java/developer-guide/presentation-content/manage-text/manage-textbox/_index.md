---
title: Управление текстовыми полями в презентациях с использованием PHP
linktitle: Управление текстовым полем
type: docs
weight: 20
url: /ru/php-java/manage-textbox/
keywords:
- текстовое поле
- текстовый кадр
- добавить текст
- обновить текст
- создать текстовое поле
- проверить текстовое поле
- добавить колонку текста
- добавить гиперссылку
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP упрощает создание, редактирование и клонирование текстовых полей в файлах PowerPoint и OpenDocument, повышая эффективность автоматизации ваших презентаций."
---

Текст на слайдах обычно находится в текстовых полях или фигурах. Поэтому, чтобы добавить текст на слайд, необходимо добавить текстовое поле, а затем поместить в него текст. Aspose.Slides for PHP via Java предоставляет интерфейс [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape), который позволяет добавить фигуру с текстом.

{{% alert title="Info" color="info" %}}
Aspose.Slides также предоставляет интерфейс [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape), который позволяет добавлять фигуры на слайды. Однако не все фигуры, добавленные через интерфейс `IShape`, могут содержать текст. Фигуры, добавленные через интерфейс [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape), могут содержать текст.
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
Поэтому, работая с фигурой, к которой вы хотите добавить текст, рекомендуется проверить и подтвердить, что она была приведена к интерфейсу `IAutoShape`. Только тогда вы сможете работать с [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame), который является свойством `IAutoShape`. См. раздел [Update Text](https://docs.aspose.com/slides/php-java/manage-textbox/#update-text) на этой странице.
{{% /alert %}}

## **Создание текстового поля на слайде**

Для создания текстового поля на слайде выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите ссылку на первый слайд в только что созданной презентации. 
3. Добавьте объект [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) с типом `ShapeType`, установленным как `Rectangle`, в указанном положении на слайде и получите ссылку на только что добавленный объект `IAutoShape`.
4. Добавьте свойство `TextFrame` к объекту `IAutoShape`, которое будет содержать текст. В примере ниже мы добавили этот текст: *Aspose TextBox*
5. Наконец, запишите файл PPTX с помощью объекта `Presentation`. 

Этот PHP‑код — реализация описанных шагов — показывает, как добавить текст на слайд:
```php
  # Создает экземпляр Presentation
  $pres = new Presentation();
  try {
    # Получает первый слайд в презентации
    $sld = $pres->getSlides()->get_Item(0);
    # Добавляет AutoShape с типом Rectangle
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # Добавляет TextFrame к Rectangle
    $ashp->addTextFrame(" ");
    # Получает доступ к TextFrame
    $txtFrame = $ashp->getTextFrame();
    # Создает объект Paragraph для TextFrame
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Создает объект Portion для абзаца
    $portion = $para->getPortions()->get_Item(0);
    # Устанавливает текст
    $portion->setText("Aspose TextBox");
    # Сохраняет презентацию на диск
    $pres->save("TextBox_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Проверка наличия фигуры текстового поля**

Aspose.Slides предоставляет метод [isTextBox](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#isTextBox--) из класса [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/), позволяющий проверять фигуры и определять текстовые поля.

![Text box and shape](istextbox.png)

Этот PHP‑код показывает, как проверить, было ли создано поле как текстовое поле:
```php
class ShapeCallback {
    function invoke($shape, $slide, $index) {
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
            $autoShape = $shape;
            echo(java_is_true($autoShape->isTextBox()) ? "shape is a text box" : "shape is not a text box");
        }
    }
}

$presentation = new Presentation("sample.pptx");
try {
    $forEachShapeCallback = java_closure(new ShapeCallback(), null, java("com.aspose.slides.ForEachSlideCallback"));
    ForEach::shape($presentation, $forEachShapeCallback);
} finally {
    $presentation->dispose();
}
```


Обратите внимание, что если вы просто добавляете автографику с помощью метода `addAutoShape` из класса [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/), метод `isTextBox` у этой автографики вернёт `false`. Однако после добавления текста в автографику с помощью метода `addTextFrame` или `setText` свойство `isTextBox` вернёт `true`.
```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
// shape1->isTextBox() возвращает false
$shape1->addTextFrame("shape 1");
// shape1->isTextBox() возвращает true

$shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->isTextBox() возвращает false
$shape2->getTextFrame()->setText("shape 2");
// shape2->isTextBox() возвращает true

$shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->isTextBox() возвращает false
$shape3->addTextFrame("");
// shape3->isTextBox() возвращает false

$shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->isTextBox() возвращает false
$shape4->getTextFrame()->setText("");
// shape4->isTextBox() возвращает false
```


## **Добавление колонок в текстовое поле**

Aspose.Slides предоставляет свойства [ColumnCount](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setColumnCount-int-) и [ColumnSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setColumnSpacing-double-) (из интерфейса [ITextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat) и класса [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat)), позволяющие добавить колонки в текстовые поля. Вы можете указать количество колонок и задать расстояние между колонками в пунктах.

Этот код демонстрирует описанную операцию:
```php
  $pres = new Presentation();
  try {
    # Получает первый слайд в презентации
    $slide = $pres->getSlides()->get_Item(0);
    # Добавляет AutoShape с типом Rectangle
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Добавляет TextFrame к Rectangle
    $aShape->addTextFrame("All these columns are limited to be within a single text container -- " . "you can add or delete text and the new or remaining text automatically adjusts " . "itself to flow within the container. You cannot have text flow from one container " . "to other though -- we told you PowerPoint's column options for text are limited!");
    # Получает формат текста TextFrame
    $format = $aShape->getTextFrame()->getTextFrameFormat();
    # Указывает количество колонок в TextFrame
    $format->setColumnCount(3);
    # Указывает расстояние между колонками
    $format->setColumnSpacing(10);
    # Сохраняет презентацию
    $pres->save("ColumnCount.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Добавление колонок в текстовый кадр**

Aspose.Slides for PHP via Java предоставляет свойство [ColumnCount](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setColumnCount-int-) (из интерфейса [ITextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat)), которое позволяет добавить колонки в текстовые кадры. С помощью этого свойства можно задать желаемое количество колонок в текстовом кадре.

Этот PHP‑код показывает, как добавить колонку в текстовый кадр:
```php
  $outPptxFileName = "ColumnsTest.pptx";
  $pres = new Presentation();
  try {
    $shape1 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    $format = $shape1->getTextFrame()->getTextFrameFormat();
    $format->setColumnCount(2);
    $shape1->getTextFrame()->setText("All these columns are forced to stay within a single text container -- " . "you can add or delete text - and the new or remaining text automatically adjusts " . "itself to stay within the container. You cannot have text spill over from one container " . "to other, though -- because PowerPoint's column options for text are limited!");
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test = new Presentation($outPptxFileName);
    try {
      $autoShape = $test->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(2 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(Double->NaN == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test)) {
        $test->dispose();
      }
    }
    $format->setColumnSpacing(20);
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test1 = new Presentation($outPptxFileName);
    try {
      $autoShape = $test1->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(2 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(20 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test1)) {
        $test1->dispose();
      }
    }
    $format->setColumnCount(3);
    $format->setColumnSpacing(15);
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test2 = new Presentation($outPptxFileName);
    try {
      $autoShape = $test2->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(3 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(15 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test2)) {
        $test2->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Обновление текста**

Aspose.Slides позволяет изменить или обновить текст, находящийся в текстовом поле, либо все тексты в презентации.

Этот PHP‑код демонстрирует операцию, при которой все тексты в презентации обновляются или изменяются:
```php
  $pres = new Presentation("text.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        # Проверяет, поддерживает ли фигура текстовый кадр (IAutoShape).
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
          $autoShape = $shape;
          # Перебирает абзацы в текстовом кадре
          foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
            # Перебирает каждый участок в абзаце
            foreach($paragraph->getPortions() as $portion) {
              $portion->setText($portion->getText()->replace("years", "months"));// Меняет текст

              $portion->getPortionFormat()->setFontBold(NullableBool::True);// Меняет форматирование

            }
          }
        }
      }
    }
    # Сохраняет изменённую презентацию
    $pres->save("text-changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Добавление текстового поля со ссылкой** 

Вы можете вставить ссылку внутрь текстового поля. При щелчке по полю пользователь будет перенаправлен к открытию ссылки. 

Чтобы добавить текстовое поле, содержащее ссылку, выполните следующие шаги:

1. Создайте экземпляр класса `Presentation`. 
2. Получите ссылку на первый слайд в только что созданной презентации. 
3. Добавьте объект `AutoShape` с типом `ShapeType`, установленным как `Rectangle`, в указанном положении на слайде и получите ссылку на только что добавленный объект AutoShape.
4. Добавьте `TextFrame` к объекту `AutoShape`, содержащий *Aspose TextBox* в качестве текста по умолчанию. 
5. Создайте объект класса `IHyperlinkManager`. 
6. Присвойте объект `IHyperlinkManager` свойству [HyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/Shape#getHyperlinkClick--) у выбранного фрагмента `TextFrame`. 
7. Наконец, запишите файл PPTX с помощью объекта `Presentation`. 

Этот PHP‑код — реализация описанных шагов — показывает, как добавить текстовое поле со ссылкой на слайд:
```php
  # Создает экземпляр класса Presentation, представляющего PPTX
  $pres = new Presentation();
  try {
    # Получает первый слайд в презентации
    $slide = $pres->getSlides()->get_Item(0);
    # Добавляет объект AutoShape с типом Rectangle
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 150, 50);
    # Приводит форму к типу AutoShape
    $pptxAutoShape = $shape;
    # Получает доступ к свойству ITextFrame, связанному с AutoShape
    $pptxAutoShape->addTextFrame("");
    $textFrame = $pptxAutoShape->getTextFrame();
    # Добавляет некоторый текст в кадр
    $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->setText("Aspose.Slides");
    # Устанавливает гиперссылку для текста части
    $hyperlinkManager = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getHyperlinkManager();
    $hyperlinkManager->setExternalHyperlinkClick("http://www.aspose.com");
    # Сохраняет PPTX презентацию
    $pres->save("hLink_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**В чём разница между текстовым полем и заполнителем текста при работе с мастер‑слайдами?**

[placeholder](/slides/ru/php-java/manage-placeholder/) наследует стиль/позицию от [master](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) и может быть переопределён на [layouts](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/), тогда как обычное текстовое поле — это независимый объект на конкретном слайде и не меняется при переключении макетов.

**Как выполнить массовую замену текста во всей презентации, не затрагивая текст внутри диаграмм, таблиц и SmartArt?**

Ограничьте итерацию авто‑фигурами, имеющими текстовые кадры, и исключите встроенные объекты ([charts](https://reference.aspose.com/slides/php-java/aspose.slides/chart/), [tables](https://reference.aspose.com/slides/php-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/)), обходя их коллекции отдельно или пропуская эти типы объектов.