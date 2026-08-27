---
title: Управление текстовыми полями в презентациях с помощью PHP
linktitle: Управление текстовым полем
type: docs
weight: 20
url: /ru/php-java/manage-textbox/
keywords:
- текстовое поле
- текстовый фрейм
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
description: "Aspose.Slides for PHP упрощает создание, редактирование и клонирование текстовых полей в файлах PowerPoint и OpenDocument, улучшая автоматизацию ваших презентаций."
---
## **Введение**

Текст на слайдах обычно находится в текстовых полях или фигурах. Поэтому, чтобы добавить текст на слайд, вам нужно добавить текстовое поле и затем поместить туда текст. Aspose.Slides for PHP via Java предоставляет класс [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) , который позволяет добавить фигуру, содержащую текст.

{{% alert title="Info" color="info" %}}
Aspose.Slides также предоставляет класс [Shape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/) , который позволяет добавлять фигуры на слайды. Однако не все фигуры, добавленные через класс `Shape`, могут содержать текст. Но фигуры, добавленные через класс [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) , могут содержать текст.
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
Поэтому, работая с фигурой, к которой вы хотите добавить текст, вам следует проверить и убедиться, что она приведена к классу `AutoShape`. Только тогда вы сможете работать с [TextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/) , который является свойством `AutoShape`. См. раздел [Update Text](/slides/ru/php-java/manage-textbox/#update-text) на этой странице.
{{% /alert %}}

## **Создание текстового поля на слайде**

Чтобы создать текстовое поле на слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/) .
2. Получите ссылку на первый слайд в только что созданной презентации. 
3. Добавьте объект [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) с типом фигуры, установленным как [Rectangle](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shapetype/#Rectangle) , в указанной позиции на слайде и получите ссылку на только что добавленный объект `AutoShape` .
4. Добавьте `TextFrame` к объекту `AutoShape`, которое будет содержать текст. В приведённом ниже примере мы добавили такой текст: *Aspose TextBox*
5. Наконец, запишите PPTX‑файл через объект `Presentation` . 

Этот PHP‑код — реализация вышеописанных шагов — показывает, как добавить текст на слайд:

```php
  # Создаёт экземпляр Presentation
  $pres = new Presentation();
  try {
    # Получает первый слайд в презентации
    $sld = $pres->getSlides()->get_Item(0);
    # Добавляет AutoShape с типом Rectangle
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # Добавляет TextFrame к Rectangle
    $ashp->addTextFrame(" ");
    # Получает доступ к текстовому фрейму
    $txtFrame = $ashp->getTextFrame();
    # Создаёт объект Paragraph для текстового фрейма
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Создаёт объект Portion для абзаца
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

## **Проверка формы на предмет текстового поля**

Aspose.Slides предоставляет метод [isTextBox](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/istextbox/) из класса [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) , позволяющий проверять фигуры и определять текстовые поля.

![Text box and shape](istextbox.png)

Этот PHP‑код показывает, как проверить, была ли фигура создана как текстовое поле:

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
    $forEachShapeCallback = java_closure(new ShapeCallback(), null, java("com.aspose.slides.ForEachShapeCallback"));
    ForEach_::shape($presentation, $forEachShapeCallback);
} finally {
    $presentation->dispose();
}
```

Обратите внимание, что если вы просто добавите автофигуру, используя метод `addAutoShape` из класса [ShapeCollection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shapecollection/) , метод `isTextBox` у этой автофигуры вернёт `false`. Однако после того, как вы добавите текст в автофигуру с помощью метода `addTextFrame` или `setText`, свойство `isTextBox` вернёт `true`.

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

## **Найти форму, владеющую TextFrame**

В общем коде обработки текста вы можете получить [TextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/) без знания, какой объект презентации его содержит. Используйте метод [TextFrame::getParentShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/#getParentShape) , чтобы перейти к владельцу [Shape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/) .

Для текстового фрейма, принадлежащего [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) или другой фигуре, содержащей текст, [TextFrame::getParentShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/#getParentShape) возвращает владельца, а [TextFrame::getParentCell](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/#getParentCell) возвращает `null`. Оба метода обеспечивают только чтение, поэтому их вызов не меняет владения. Всегда проверяйте возвращаемое значение с помощью `java_is_null` перед доступом к фигуре.

Для полного примера, определяющего владельцев фигур и ячеек таблиц, включая фигуры, связанные с узлами SmartArt, см. раздел [Search and Replace Text](/slides/ru/php-java/search-and-replace-text/) .

## **Добавление колонок в текстовое поле**

Aspose.Slides предоставляет методы [setColumnCount](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframeformat/setcolumncount/) и [setColumnSpacing](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframeformat/setcolumnspacing/) из класса [TextFrameFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframeformat/) , которые позволяют добавить колонки в текстовые поля. Вы можете задать количество колонок в текстовом поле и установить расстояние между колонками в пунктах.

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
    # Указывает интервал между колонками
    $format->setColumnSpacing(10);
    # Сохраняет презентацию
    $pres->save("ColumnCount.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Добавление колонок в TextFrame**

Aspose.Slides for PHP via Java предоставляет метод [setColumnCount](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframeformat/setcolumncount/) из класса [TextFrameFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframeformat/) , который позволяет добавить колонки в текстовые фреймы. С помощью этого свойства вы можете указать желаемое количество колонок в текстовом фрейме.

Этот PHP‑код показывает, как добавить колонку внутри текстового фрейма:

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

Aspose.Slides позволяет изменить или обновить текст, содержащийся в текстовом поле, либо весь текст, содержащийся в презентации. 

Этот PHP‑код демонстрирует операцию, при которой весь текст в презентации обновляется или изменяется:

```php
  $pres = new Presentation("text.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        # Проверяет, поддерживает ли фигура текстовый фрейм (IAutoShape).
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
          $autoShape = $shape;
          # Итерирует абзацы в текстовом фрейме
          foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
            # Итерирует каждую часть в абзаце
            foreach($paragraph->getPortions() as $portion) {
              $portion->setText($portion->getText()->replace("years", "months"));// Изменяет текст

              $portion->getPortionFormat()->setFontBold(NullableBool::True);// Изменяет форматирование

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

Вы можете вставить ссылку внутрь текстового поля. При щелчке по текстовому полю пользователи будут перенаправлены открыть ссылку. 

Чтобы добавить текстовое поле, содержащие ссылку, выполните следующие шаги:

1. Создайте экземпляр класса `Presentation` .
2. Получите ссылку на первый слайд в только что созданной презентации. 
3. Добавьте объект `AutoShape` с `ShapeType`, установленным как `Rectangle` , в указанной позиции на слайде и получите ссылку на только что добавленный объект AutoShape .
4. Добавьте `TextFrame` к объекту `AutoShape`, содержащий *Aspose TextBox* в качестве текста по умолчанию. 
5. Создайте экземпляр класса `HyperlinkManager` .
6. Назначьте гиперссылку с помощью метода [setExternalHyperlinkClick](https://reference.aspose.com/slides/ru/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/) , привязанного к выбранной части `TextFrame` .
7. Наконец, запишите PPTX‑файл через объект `Presentation` .

Этот PHP‑код — реализация вышеописанных шагов — показывает, как добавить текстовое поле со ссылкой на слайд:

```php
  # Создаёт экземпляр класса Presentation, представляющего PPTX
  $pres = new Presentation();
  try {
    # Получает первый слайд в презентации
    $slide = $pres->getSlides()->get_Item(0);
    # Добавляет объект AutoShape с типом Rectangle
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 150, 50);
    # Приводит форму к AutoShape
    $pptxAutoShape = $shape;
    # Получает доступ к свойству ITextFrame, связанному с AutoShape
    $pptxAutoShape->addTextFrame("");
    $textFrame = $pptxAutoShape->getTextFrame();
    # Добавляет текст в фрейм
    $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->setText("Aspose.Slides");
    # Устанавливает гиперссылку для текста части
    $hyperlinkManager = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getHyperlinkManager();
    $hyperlinkManager->setExternalHyperlinkClick("http://www.aspose.com");
    # Сохраняет презентацию PPTX
    $pres->save("hLink_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Часто задаваемые вопросы**

**В чём разница между текстовым полем и заполнителем текста при работе с мастер‑слайдами?**

[placeholder](/slides/ru/php-java/manage-placeholder/) наследует стиль/позицию от [master](https://reference.aspose.com/slides/ru/php-java/aspose.slides/masterslide/) и может быть переопределён на [layouts](https://reference.aspose.com/slides/ru/php-java/aspose.slides/layoutslide/) , тогда как обычное текстовое поле является независимым объектом на конкретном слайде и не меняется при переключении макетов.

**Как выполнить массовую замену текста во всей презентации, не затрагивая текст внутри диаграмм, таблиц и SmartArt?**

Ограничьте итерацию авто‑формами, имеющими TextFrame, и исключите встроенные объекты ([charts](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chart/) , [tables](https://reference.aspose.com/slides/ru/php-java/aspose.slides/table/) , [SmartArt](https://reference.aspose.com/slides/ru/php-java/aspose.slides/smartart/) ), обходя их коллекции отдельно или пропуская такие типы объектов.