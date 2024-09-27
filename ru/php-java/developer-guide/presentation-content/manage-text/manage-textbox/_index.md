---
title: Управление текстовым полем
type: docs
weight: 20
url: /ru/php-java/manage-textbox/
description: Создание текстовых полей на слайдах PowerPoint с использованием PHP. Добавление столбца в текстовое поле или текстовую рамку на слайдах PowerPoint с использованием PHP. Добавление текстового поля с гиперссылкой на слайды PowerPoint с использованием PHP.
---


Тексты на слайдах обычно существуют в текстовых полях или фигурах. Поэтому, чтобы добавить текст на слайд, вам нужно добавить текстовое поле, а затем вставить текст внутрь текстового поля. Aspose.Slides для PHP через Java предоставляет интерфейс [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape), который позволяет добавлять фигуры, содержащие текст.

{{% alert title="Информация" color="info" %}}

Aspose.Slides также предоставляет интерфейс [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape), который позволяет добавлять фигуры на слайды. Однако не все фигуры, добавленные через интерфейс `IShape`, могут содержать текст. Но фигуры, добавленные через интерфейс [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape), могут содержать текст.

{{% /alert %}}

{{% alert title="Примечание" color="warning" %}} 

Поэтому, когда вы работаете с фигурой, к которой хотите добавить текст, вам следует проверить и подтвердить, что она была приведена через интерфейс `IAutoShape`. Только тогда вы сможете работать с [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame), который является свойством под `IAutoShape`. См. раздел [Обновление текста](https://docs.aspose.com/slides/php-java/manage-textbox/#update-text) на этой странице.

{{% /alert %}}

## **Создание текстового поля на слайде**

Чтобы создать текстовое поле на слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите ссылку на первый слайд в вновь созданной презентации. 
3. Добавьте объект [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) с установленным типом [ShapeType](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryShape#setShapeType-int-) в `Rectangle` в указанной позиции на слайде и получите ссылку на вновь добавленный объект `IAutoShape`.
4. Добавьте свойство `TextFrame` к объекту `IAutoShape`, которое будет содержать текст. В приведенном ниже примере мы добавили этот текст: *Aspose TextBox*
5. Наконец, запишите файл PPTX через объект `Presentation`. 

Этот PHP-код — реализация вышеуказанных шагов — показывает, как добавить текст на слайд:

```php
  # Создание экземпляра Presentation
  $pres = new Presentation();
  try {
    # Получение первого слайда в презентации
    $sld = $pres->getSlides()->get_Item(0);
    # Добавление AutoShape с типом, установленным как Rectangle
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # Добавление TextFrame к Rectangle
    $ashp->addTextFrame(" ");
    # Доступ к текстовой рамке
    $txtFrame = $ashp->getTextFrame();
    # Создание объекта Paragraph для текстовой рамки
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Создание объекта Portion для абзаца
    $portion = $para->getPortions()->get_Item(0);
    # Установка текста
    $portion->setText("Aspose TextBox");
    # Сохранение презентации на диск
    $pres->save("TextBox_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Проверка на фигуру текстового поля**

Aspose.Slides предоставляет свойство [isTextBox()](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#isTextBox--) (из класса [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/)), которое позволяет вам проверять фигуры и искать текстовые поля.

![Текстовое поле и фигура](istextbox.png)

Этот PHP-код показывает, как проверить, было ли создано поле как текстовое:

```php
class ShapeCallback {
    function invoke($shape, $slide, $index){
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape")))
        $autoShape = $shape;
        echo(java_is_true($autoShape->isTextBox()) ? "фигура является текстовым полем" : "фигура не является текстовым полем");
    }
}

  $pres = new Presentation("pres.pptx");
  try {
    $forEachShapeCallback = java_closure(new ShapeCallback(), null, java("com.aspose.slides.ForEachSlideCallback"));
    ForEach::shape($pres, $forEachShapeCallback);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Добавление столбца в текстовое поле**

Aspose.Slides предоставляет свойства [ColumnCount](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setColumnCount-int-) и [ColumnSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setColumnSpacing-double-) (из интерфейса [ITextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat) и класса [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat)), которые позволяют добавлять столбцы в текстовые поля. Вы можете указать количество столбцов в текстовом поле и установить промежуток между столбцами в пунктах.

Этот код демонстрирует описанную операцию:

```php
  $pres = new Presentation();
  try {
    # Получение первого слайда в презентации
    $slide = $pres->getSlides()->get_Item(0);
    # Добавление AutoShape с типом, установленным как Rectangle
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Добавление TextFrame к Rectangle
    $aShape->addTextFrame("Все эти столбцы ограничены одной текстовой областью - " . "вы можете добавлять или удалять текст, и новый или оставшийся текст автоматически изменяется " . "для того, чтобы вписываться в контейнер. Текст не может перетекать из одного контейнера " . "в другой - мы уже говорили вам, что варианты столбцов для текста PowerPoint ограничены!");
    # Получение текстового формата TextFrame
    $format = $aShape->getTextFrame()->getTextFrameFormat();
    # Указание количества столбцов в TextFrame
    $format->setColumnCount(3);
    # Указание промежутка между столбцами
    $format->setColumnSpacing(10);
    # Сохранение презентации
    $pres->save("ColumnCount.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Добавление столбца в текстовую рамку**
Aspose.Slides для PHP через Java предоставляет свойство [ColumnCount](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setColumnCount-int-) (из интерфейса [ITextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat)), которое позволяет добавлять столбцы в текстовые рамки. С помощью этого свойства вы можете указать желаемое количество столбцов в текстовой рамке.

Этот PHP-код показывает, как добавить столбец внутри текстовой рамки:

```php
  $outPptxFileName = "ColumnsTest.pptx";
  $pres = new Presentation();
  try {
    $shape1 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    $format = $shape1->getTextFrame()->getTextFrameFormat();
    $format->setColumnCount(2);
    $shape1->getTextFrame()->setText("Все эти столбцы вынуждены оставаться в одном текстовом контейнере - " . "вы можете добавлять или удалять текст - и новый или оставшийся текст автоматически изменяется " . "для того, чтобы оставаться в контейнере. Текст не может выливаться из одного контейнера " . "в другой, потому что варианты столбцов PowerPoint для текста ограничены!");
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

Aspose.Slides позволяет вам изменять или обновлять текст, содержащийся в текстовом поле, или все тексты, содержащиеся в презентации. 

Этот PHP-код демонстрирует операцию, при которой все тексты в презентации обновляются или изменяются:

```php
  $pres = new Presentation("text.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        # Проверяет, поддерживает ли фигура текстовую рамку (IAutoShape).
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
          $autoShape = $shape;
          # Перебирает абзацы в текстовой рамке
          foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
            # Перебирает каждую часть в абзаце
            foreach($paragraph->getPortions() as $portion) {
              $portion->setText($portion->getText()->replace("years", "months"));// Изменяет текст

              $portion->getPortionFormat()->setFontBold(NullableBool::True);// Изменяет форматирование

            }
          }
        }
      }
    }
    # Сохраняет измененную презентацию
    $pres->save("text-changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Добавление текстового поля с гиперссылкой** 

Вы можете вставить ссылку внутрь текстового поля. Когда текстовое поле будет нажато, пользователи будут направлены на открытие ссылки. 

Чтобы добавить текстовое поле, содержащее ссылку, выполните следующие шаги:

1. Создайте экземпляр класса `Presentation`. 
2. Получите ссылку на первый слайд в вновь созданной презентации. 
3. Добавьте объект `AutoShape` с установленным `ShapeType` в `Rectangle` в указанной позиции на слайде и получите ссылку на вновь добавленный объект AutoShape.
4. Добавьте `TextFrame` к объекту `AutoShape`, который содержит *Aspose TextBox* в качестве его текста по умолчанию. 
5. Создайте экземпляр класса `IHyperlinkManager`. 
6. Назначьте объект `IHyperlinkManager` свойству [HyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/Shape#getHyperlinkClick--) для вашей предпочитаемой части `TextFrame`.
7. Наконец, запишите файл PPTX через объект `Presentation`. 

Этот PHP-код — реализация вышеуказанных шагов — показывает, как добавить текстовое поле с гиперссылкой на слайд:

```php
  # Создание экземпляра класса Presentation, представляющего PPTX
  $pres = new Presentation();
  try {
    # Получение первого слайда в презентации
    $slide = $pres->getSlides()->get_Item(0);
    # Добавление объекта AutoShape с типом, установленным как Rectangle
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 150, 50);
    # Приведение фигуры к AutoShape
    $pptxAutoShape = $shape;
    # Доступ к свойству ITextFrame, связанному с AutoShape
    $pptxAutoShape->addTextFrame("");
    $textFrame = $pptxAutoShape->getTextFrame();
    # Добавление текста в рамку
    $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->setText("Aspose.Slides");
    # Установка гиперссылки для текста порции
    $hyperlinkManager = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getHyperlinkManager();
    $hyperlinkManager->setExternalHyperlinkClick("http://www.aspose.com");
    # Сохранение презентации PPTX
    $pres->save("hLink_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```