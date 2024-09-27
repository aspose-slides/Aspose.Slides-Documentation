---
title: Управление шрифтами - PowerPoint Java API
linktitle: Управление шрифтами
type: docs
weight: 10
url: /ru/php-java/manage-fonts/
description: Презентации обычно содержат как текст, так и изображения. Эта статья показывает, как использовать PowerPoint Java API для настройки свойств шрифта абзацев текста на слайдах.
---

## **Управление свойствами шрифта**
{{% alert color="primary" %}} 

Презентации обычно содержат как текст, так и изображения. Текст может быть отформатирован различными способами, чтобы выделить определённые разделы и слова или соответствовать корпоративным стилям. Форматирование текста помогает пользователям изменять внешний вид содержания презентации. Эта статья показывает, как использовать Aspose.Slides для PHP через Java для настройки свойств шрифта абзацев текста на слайдах.

{{% /alert %}} 

Чтобы управлять свойствами шрифта абзаца с помощью Aspose.Slides для PHP через Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Доступ к фигурам [Placeholder](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Placeholder) на слайде и приведите их к типу [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/classes/AutoShape).
1. Получите [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Paragraph) из [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/classes/TextFrame), возвращаемого [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/classes/AutoShape).
1. Выровняйте абзац.
1. Получите текст [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion) абзаца.
1. Определите шрифт с использованием [FontData](https://reference.aspose.com/slides/php-java/aspose.slides/classes/FontData) и установите **Font** текста [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion) соответственно.
   1. Установите шрифт в жирный.
   1. Установите шрифт в курсив.
1. Установите цвет шрифта с помощью [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/classes/FillFormat), возвращаемого объектом [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion).
1. Сохраните изменённую презентацию в файл PPTX.

Реализация вышеперечисленных шагов приведена ниже. Он принимает простую презентацию и форматирует шрифты на одном из слайдов. Скриншоты, которые следуют, показывают входной файл и то, как фрагменты кода изменяют его. Код изменяет шрифт, цвет и стиль шрифта.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Рисунок: Текст в входном файле**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Рисунок: Тот же текст с обновлённым форматированием**|

```php
  # Создайте объект Presentation, представляющий файл PPTX
  $pres = new Presentation("FontProperties.pptx");
  try {
    # Доступ к слайду по его позиции
    $slide = $pres->getSlides()->get_Item(0);
    # Доступ к первому и второму заполнителю на слайде и приведение их к AutoShape
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # Доступ к первому абзацу
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # Выровняйте абзац
    $para2->getParagraphFormat()->setAlignment(TextAlignment->JustifyLow);
    # Доступ к первой доле
    $port1 = $para1->getPortions()->get_Item(0);
    $port2 = $para2->getPortions()->get_Item(0);
    # Определите новые шрифты
    $fd1 = new FontData("Elephant");
    $fd2 = new FontData("Castellar");
    # Присвойте новые шрифты порции
    $port1->getPortionFormat()->setLatinFont($fd1);
    $port2->getPortionFormat()->setLatinFont($fd2);
    # Установите шрифт в жирный
    $port1->getPortionFormat()->setFontBold(NullableBool::True);
    $port2->getPortionFormat()->setFontBold(NullableBool::True);
    # Установите шрифт в курсив
    $port1->getPortionFormat()->setFontItalic(NullableBool::True);
    $port2->getPortionFormat()->setFontItalic(NullableBool::True);
    # Установите цвет шрифта
    $port1->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port1->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $port2->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port2->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # Сохраните PPTX на диск
    $pres->save("WelcomeFont.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Установите свойства шрифта текста**
{{% alert color="primary" %}} 

Как упоминалось в **Управлении свойствами шрифта**, [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion) используется для хранения текста с аналогичным стилем форматирования в абзаце. Эта статья показывает, как использовать Aspose.Slides для PHP через Java для создания текстового поля с некоторым текстом, а затем определить определённый шрифт и различные другие свойства категории шрифта.

{{% /alert %}} 

Чтобы создать текстовое поле и установить свойства шрифта текста в нём:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/classes/AutoShape) типа **Rectangle** на слайд.
1. Удалите стиль заливки, связанный с [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/classes/AutoShape).
1. Получите текстовую рамку [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/classes/TextFrame), связанную с [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/classes/AutoShape).
1. Добавьте некоторый текст в [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/classes/TextFrame).
1. Получите объект [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion), связанный с [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/classes/TextFrame).
1. Определите шрифт, который будет использоваться для [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion).
1. Установите другие свойства шрифта, такие как жирный, курсив, подчёркивание, цвет и высота, используя соответствующие свойства, предоставляемые объектом [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion).
1. Запишите изменённую презентацию как файл PPTX.

Реализация вышеперечисленных шагов приведена ниже.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Рисунок: Текст с некоторыми свойствами шрифта, установленными Aspose.Slides для PHP через Java**|

```php
  # Создайте объект Presentation, представляющий файл PPTX
  $pres = new Presentation();
  try {
    # Получите первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Добавьте AutoShape типа Rectangle
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    # Удалите любой стиль заливки, связанный с AutoShape
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Получите TextFrame, связанный с AutoShape
    $tf = $ashp->getTextFrame();
    $tf->setText("Aspose TextBox");
    # Получите Portion, связанную с TextFrame
    $port = $tf->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    # Установите шрифт для Portion
    $port->getPortionFormat()->setLatinFont(new FontData("Times New Roman"));
    # Установите свойство Bold для шрифта
    $port->getPortionFormat()->setFontBold(NullableBool::True);
    # Установите свойство Italic для шрифта
    $port->getPortionFormat()->setFontItalic(NullableBool::True);
    # Установите свойство Underline для шрифта
    $port->getPortionFormat()->setFontUnderline(TextUnderlineType::Single);
    # Установите высоту шрифта
    $port->getPortionFormat()->setFontHeight(25);
    # Установите цвет шрифта
    $port->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # Сохраните презентацию на диск
    $pres->save("pptxFont.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```