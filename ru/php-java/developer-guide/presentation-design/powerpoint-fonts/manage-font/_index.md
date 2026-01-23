---
title: Управление шрифтами в презентациях с помощью PHP
linktitle: Управление шрифтами
type: docs
weight: 10
url: /ru/php-java/manage-fonts/
keywords:
- управление шрифтами
- свойства шрифта
- абзац
- форматирование текста
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Контролируйте шрифты в PHP с помощью Aspose.Slides: встраивайте, заменяйте и загружайте пользовательские шрифты, чтобы презентации PPT, PPTX и ODP оставались четкими, бренд‑безопасными и согласованными."
---

## **Управление свойствами шрифтов**
{{% alert color="primary" %}} 

Презентации обычно содержат как текст, так и изображения. Текст можно форматировать различными способами, либо чтобы выделить определённые разделы и слова, либо чтобы соответствовать корпоративным стилям. Форматирование текста помогает пользователям варьировать внешний вид содержимого презентации. В этой статье показано, как использовать Aspose.Slides for PHP via Java для настройки свойств шрифта абзацев текста на слайдах.

{{% /alert %}} 

Для управления свойствами шрифта абзаца с помощью Aspose.Slides for PHP via Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Получите формы [Placeholder](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/) на слайде и приведите их к типу [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
1. Получите [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) из [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/), предоставляемого [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
1. Выровняйте абзац по ширине.
1. Получите [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) текста [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/).
1. Определите шрифт с помощью [FontData](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/) и соответственно установите **Font** текста [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/).
   1. Установите шрифт полужирным.
   1. Установите шрифт курсивом.
1. Установите цвет шрифта с помощью [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/), предоставляемого объектом [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/).
1. Сохраните изменённую презентацию в файл PPTX.

Реализация указанных выше шагов приведена ниже. Она берёт простую презентацию и форматирует шрифты на одном из слайдов. Снятые скриншоты показывают исходный файл и то, как фрагменты кода изменяют его. Код изменяет шрифт, цвет и стиль шрифта.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Рисунок: Текст во входном файле**|

|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Рисунок: Тот же текст с обновлённым форматированием**|
```php
  # Создать объект Presentation, представляющий файл PPTX
  $pres = new Presentation("FontProperties.pptx");
  try {
    # Получить слайд по его позиции
    $slide = $pres->getSlides()->get_Item(0);
    # Получить первый и второй плейсхолдер на слайде и привести их к типу AutoShape
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # Получить первый абзац
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # Выравнивание абзаца по ширине
    $para2->getParagraphFormat()->setAlignment(TextAlignment->JustifyLow);
    # Получить первую часть
    $port1 = $para1->getPortions()->get_Item(0);
    $port2 = $para2->getPortions()->get_Item(0);
    # Определить новые шрифты
    $fd1 = new FontData("Elephant");
    $fd2 = new FontData("Castellar");
    # Назначить новые шрифты части
    $port1->getPortionFormat()->setLatinFont($fd1);
    $port2->getPortionFormat()->setLatinFont($fd2);
    # Установить шрифт жирным
    $port1->getPortionFormat()->setFontBold(NullableBool::True);
    $port2->getPortionFormat()->setFontBold(NullableBool::True);
    # Установить шрифт курсивом
    $port1->getPortionFormat()->setFontItalic(NullableBool::True);
    $port2->getPortionFormat()->setFontItalic(NullableBool::True);
    # Установить цвет шрифта
    $port1->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port1->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $port2->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port2->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # Сохранить PPTX на диск
    $pres->save("WelcomeFont.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Установка свойств шрифта текста**
{{% alert color="primary" %}} 

Как упоминалось в **Управление свойствами шрифтов**, объект [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) используется для хранения текста с одинаковым стилем форматирования в абзаце. В этой статье показано, как использовать Aspose.Slides for PHP via Java для создания текстового поля с некоторым текстом, а затем определить конкретный шрифт и различные другие свойства семейства шрифтов.

{{% /alert %}} 

Для создания текстового поля и установки свойств шрифта текста в нём:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте к слайду [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) типа **Rectangle**.
1. Удалите стиль заливки, связанный с [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
1. Получите [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) у [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
1. Добавьте некоторый текст в [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/).
1. Получите объект [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/), связанный с [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/).
1. Определите шрифт, который будет использоваться для [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/).
1. Установите другие свойства шрифта, такие как полужирный, курсив, подчёркивание, цвет и высота, используя соответствующие свойства, предоставляемые объектом [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/).
1. Запишите изменённую презентацию в файл PPTX.

Реализация указанных выше шагов приведена ниже.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Рисунок: Текст с установленными некоторыми свойствами шрифта, заданными Aspose.Slides for PHP via Java**|
```php
  # Создать объект Presentation, представляющий файл PPTX
  $pres = new Presentation();
  try {
    # Получить первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Добавить AutoShape типа Rectangle
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    # Удалить любой стиль заливки, связанный с AutoShape
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Получить TextFrame, связанный с AutoShape
    $tf = $ashp->getTextFrame();
    $tf->setText("Aspose TextBox");
    # Получить Portion, связанный с TextFrame
    $port = $tf->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    # Задать шрифт для Portion
    $port->getPortionFormat()->setLatinFont(new FontData("Times New Roman"));
    # Установить свойство Bold для шрифта
    $port->getPortionFormat()->setFontBold(NullableBool::True);
    # Установить свойство Italic для шрифта
    $port->getPortionFormat()->setFontItalic(NullableBool::True);
    # Установить свойство Underline для шрифта
    $port->getPortionFormat()->setFontUnderline(TextUnderlineType::Single);
    # Задать высоту шрифта
    $port->getPortionFormat()->setFontHeight(25);
    # Установить цвет шрифта
    $port->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # Сохранить презентацию на диск
    $pres->save("pptxFont.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
