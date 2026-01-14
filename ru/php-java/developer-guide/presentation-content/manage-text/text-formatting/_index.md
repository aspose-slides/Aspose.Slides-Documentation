---
title: Форматирование текста PowerPoint в PHP
linktitle: Форматирование текста
type: docs
weight: 50
url: /ru/php-java/text-formatting/
keywords:
- выделение текста
- регулярное выражение
- выравнивание абзаца
- стиль текста
- фон текста
- прозрачность текста
- межсимвольный интервал
- свойства шрифта
- семейство шрифтов
- поворот текста
- угол поворота
- текстовый кадр
- межстрочный интервал
- свойство автоподгонки
- привязка текстового кадра
- табуляция текста
- язык по умолчанию
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Форматирование и стилизация текста в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для PHP через Java. Настраивайте шрифты, цвета, выравнивание и многое другое."
---

## **Подсветка текста**
Метод [highlightText](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/highlighttext/) был добавлен в класс [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/).

Он позволяет подсвечивать часть текста фоновым цветом, используя образец текста, аналогично инструменту Text Highlight Color в PowerPoint 2019.

Ниже приведён пример кода, показывающий, как использовать эту возможность:
```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $textHighlightingOptions = new TextHighlightingOptions();
    $textHighlightingOptions->setWholeWordsOnly(true);
    $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getTextFrame()->highlightText("title", java("java.awt.Color")->BLUE);// выделение всех слов 'important'

    $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getTextFrame()->highlightText("to", java("java.awt.Color")->MAGENTA, $textHighlightingOptions);// выделение всех отдельных вхождений 'the'

    $pres->save("OutputPresentation-highlight.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="primary" %}} 
Aspose предоставляет простой, [бесплатный онлайн сервис редактирования PowerPoint](https://products.aspose.app/slides/editor)
{{% /alert %}} 

## **Подсветка текста с использованием регулярного выражения**
Метод [highlightRegex](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/highlightregex/) был добавлен в класс [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/).

Он позволяет подсвечивать часть текста фоновым цветом, используя регулярное выражение, аналогично инструменту Text Highlight Color в PowerPoint 2019.

Ниже приведён пример кода, показывающий, как использовать эту возможность:
```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $options = new TextHighlightingOptions();
    $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getTextFrame()->highlightRegex("\\b[^\\s]{4}\\b", java("java.awt.Color")->YELLOW, $options);// выделение всех слов длиной 10 символов и более

    $pres->save("OutputPresentation-highlight.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Установка цвета фона текста**
Aspose.Slides позволяет задать предпочитаемый цвет фона текста.

Этот PHP‑код показывает, как установить цвет фона для всего текста:
```php
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
    $autoShape->getTextFrame()->getParagraphs()->clear();
    $para = new Paragraph();
    $portion1 = new Portion("Black");
    $portion1->getPortionFormat()->setFontBold(NullableBool::True);
    $portion2 = new Portion(" Red ");
    $portion3 = new Portion("Black");
    $portion3->getPortionFormat()->setFontBold(NullableBool::True);
    $para->getPortions()->add($portion1);
    $para->getPortions()->add($portion2);
    $para->getPortions()->add($portion3);
    $autoShape->getTextFrame()->getParagraphs()->add($para);
    $pres->save("text.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
  $presentation = new Presentation("text.pptx");
  try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    StreamSupport->stream($autoShape->getTextFrame()->getParagraphs()->spliterator(), false)->map(( p) -> $p->getPortions())->forEach(( c) -> $c->forEach(( ic) -> $ic->getPortionFormat()->getHighlightColor()->setColor($Color.BLUE)));
    $presentation->save("text-red.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


Этот PHP‑код показывает, как установить цвет фона только для части текста:
```php
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
    $autoShape->getTextFrame()->getParagraphs()->clear();
    $para = new Paragraph();
    $portion1 = new Portion("Black");
    $portion1->getPortionFormat()->setFontBold(NullableBool::True);
    $portion2 = new Portion(" Red ");
    $portion3 = new Portion("Black");
    $portion3->getPortionFormat()->setFontBold(NullableBool::True);
    $para->getPortions()->add($portion1);
    $para->getPortions()->add($portion2);
    $para->getPortions()->add($portion3);
    $autoShape->getTextFrame()->getParagraphs()->add($para);
    $pres->save("text.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
  $presentation = new Presentation("text.pptx");
  try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $redPortion = StreamSupport->stream($autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->spliterator(), false)->filter(( p) -> $p->getText()->contains("Red"))->findFirst();
    if ($redPortion->isPresent()) {
      $redPortion->get()->getPortionFormat()->getHighlightColor()->setColor(java("java.awt.Color")->RED);
    }
    $presentation->save("text-red.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **Выравнивание абзацев текста**
Форматирование текста – один из ключевых элементов при создании документов или презентаций. Мы знаем, что Aspose.Slides for PHP via Java поддерживает добавление текста в слайды, но в этой статье мы посмотрим, как управлять выравниванием абзацев текста в слайде. Пожалуйста, выполните следующие шаги для выравнивания абзацев текста с помощью Aspose.Slides for PHP via Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Получите ссылку на слайд, используя его индекс.
3. Доступ к Placeholder‑формам слайда и приведение их к типу [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
4. Получите абзац (который нужно выровнять) из [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/), предоставляемого [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
5. Выровняйте абзац. Абзац может быть выровнен по правому, левому краю, по центру или по ширине.
6. Сохраните изменённую презентацию в виде файла PPTX.

Реализация перечисленных шагов показана ниже.
```php
  # Создать объект Presentation, представляющий PPTX файл
  $pres = new Presentation("ParagraphsAlignment.pptx");
  try {
    # Доступ к первому слайду
    $slide = $pres->getSlides()->get_Item(0);
    # Получение первого и второго заполнителей на слайде и приведение к типу AutoShape
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # Изменение текста в обоих заполнителях
    $tf1->setText("Center Align by Aspose");
    $tf2->setText("Center Align by Aspose");
    # Получение первого абзаца из заполнителей
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # Выравнивание абзаца текста по центру
    $para1->getParagraphFormat()->setAlignment(TextAlignment->Center);
    $para2->getParagraphFormat()->setAlignment(TextAlignment->Center);
    # Сохранение презентации в файл PPTX
    $pres->save("Centeralign_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Установка прозрачности текста**
В этой статье демонстрируется, как задать свойство прозрачности любой текстовой фигуры с помощью Aspose.Slides for PHP via Java. Чтобы установить прозрачность текста, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Получите ссылку на слайд.
3. Задайте цвет тени.
4. Сохраните презентацию в виде файла PPTX.

Реализация перечисленных шагов показана ниже.
```php
  $pres = new Presentation("transparency.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $effects = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getEffectFormat();
    $outerShadowEffect = $effects->getOuterShadowEffect();
    $shadowColor = $outerShadowEffect->getShadowColor()->getColor();
    echo($shadowColor->toString() . " - transparency is: " . $shadowColor->getAlpha() / 255.0 * 100);
    # установить прозрачность в ноль процентов
    $outerShadowEffect->getShadowColor()->setColor(new java("java.awt.Color", $shadowColor->getRed(), $shadowColor->getGreen(), $shadowColor->getBlue(), 255));
    $pres->save("transparency-2.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Установка межсимвольного интервала текста**
Aspose.Slides позволяет задать расстояние между символами в текстовом блоке. Таким образом, вы можете регулировать визуальную плотность строки или блока текста, расширяя или сужая интервал между символами.

Этот PHP‑код показывает, как увеличить интервал для одной строки текста и уменьшить его для другой строки:
```php
  $presentation = new Presentation("in.pptx");
  $textBox1 = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $textBox2 = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(1);
  $textBox1->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(20);// расширить

  $textBox2->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(-2);// сжать

  $presentation->save("out.pptx", SaveFormat::Pptx);
```


## **Управление свойствами шрифта абзаца**
Презентации обычно содержат как текст, так и изображения. Текст может быть отформатирован различными способами — для подсветки определённых разделов и слов или в соответствии с корпоративными стилями. Форматирование текста помогает пользователям варьировать внешний вид содержимого презентации. В этой статье показано, как с помощью Aspose.Slides for PHP via Java настроить свойства шрифта абзацев текста на слайдах. Чтобы управлять свойствами шрифта абзаца:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Получите ссылку на слайд, используя его индекс.
1. Доступ к Placeholder‑формам слайда и приведение их к типу [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
1. Получите объект [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) из [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/), предоставляемого [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
1. Выравнивание абзаца по ширине.
1. Доступ к Portion текста абзаца.
1. Определите шрифт с помощью FontData и установите шрифт Portion соответственно.
   1. Сделать шрифт жирным.
   1. Сделать шрифт курсивом.
1. Установите цвет шрифта через [getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFillFormat), предоставляемый объектом [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/).
1. Сохраните изменённую презентацию в файл [PPTX](https://docs.fileformat.com/presentation/pptx/).

Реализация перечисленных шагов представлена ниже. Она берёт простую презентацию и форматирует шрифты на одном из слайдов.
```php
  # Создать объект Presentation, представляющий PPTX файл
  $pres = new Presentation("FontProperties.pptx");
  try {
    # Получить слайд по его позиции
    $slide = $pres->getSlides()->get_Item(0);
    # Получить первый и второй заполнители на слайде и привести их к типу AutoShape
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # Получить первый абзац
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # Получить первую часть текста
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
    $port1->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
    $port2->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port2->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    # Записать PPTX на диск
    $pres->save("WelcomeFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Управление семейством шрифтов текста**
Portion используется для группировки текста с одинаковым стилем в абзаце. В этой статье показано, как с помощью Aspose.Slides for PHP via Java создать текстовое поле, задать определённый шрифт и другие свойства семейства шрифтов. Чтобы создать текстовое поле и задать свойства шрифта текста в нём:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) типа [Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/shapetype/#Rectangle) на слайд.
4. Удалите стиль заливки, связанный с [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
5. Доступ к TextFrame AutoShape.
6. Добавьте текст в TextFrame.
7. Доступ к объекту Portion, связанному с [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/).
8. Определите шрифт, который будет использоваться для [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/).
9. Задайте другие свойства шрифта, такие как жирный, курсив, подчёркивание, цвет и высота, используя соответствующие свойства объекта Portion.
10. Сохраните изменённую презентацию в файл PPTX.

Реализация перечисленных шагов представлена ниже.
```php
  # Создать объект Presentation
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
    # Установить шрифт для Portion
    $port->getPortionFormat()->setLatinFont(new FontData("Times New Roman"));
    # Установить свойство Bold для шрифта
    $port->getPortionFormat()->setFontBold(NullableBool::True);
    # Установить свойство Italic для шрифта
    $port->getPortionFormat()->setFontItalic(NullableBool::True);
    # Установить свойство Underline для шрифта
    $port->getPortionFormat()->setFontUnderline(TextUnderlineType::Single);
    # Установить высоту шрифта
    $port->getPortionFormat()->setFontHeight(25);
    # Установить цвет шрифта
    $port->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # Записать PPTX на диск
    $pres->save("SetTextFontProperties_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Установка размера шрифта текста**
Aspose.Slides позволяет выбрать предпочитаемый размер шрифта для существующего текста в абзаце и для текста, который может быть добавлен позже.

Этот PHP‑код показывает, как установить размер шрифта для текста, находящегося в абзаце:
```php
  $presentation = new Presentation("example.pptx");
  try {
    # Получает первую форму, например.
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
      $autoShape = $shape;
      # Получает первый абзац, например.
      $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
      # Устанавливает размер шрифта по умолчанию 20 pt для всех частей текста в абзаце.
      $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(20);
      # Устанавливает размер шрифта 20 pt для текущих частей текста в абзаце.
      foreach($paragraph->getPortions() as $portion) {
        $portion->getPortionFormat()->setFontHeight(20);
      }
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **Установка поворота текста**
Aspose.Slides for PHP via Java позволяет разработчикам вращать текст. Текст может быть отображён как [Horizontal](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/#Horizontal), [Vertical](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/#Vertical), [Vertical270](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/#Vertical270), [WordArtVertical](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/#WordArtVertical), [EastAsianVertical](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/#EastAsianVertical), [MongolianVertical](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/#MongolianVertical) или [WordArtVerticalRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/#WordArtVerticalRightToLeft). Чтобы повернуть текст любого TextFrame, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Доступ к первому слайду.
3. Добавьте любую фигуру на слайд.
4. Доступ к [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/).
5. [Поверните текст](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/).
6. Сохраните файл на диск.
```php
  # Создать экземпляр класса Presentation
  $pres = new Presentation();
  try {
    # Получить первый слайд
    $slide = $pres->getSlides()->get_Item(0);
    # Добавить AutoShape типа Rectangle
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 350);
    # Добавить TextFrame к прямоугольнику
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Доступ к текстовому фрейму
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setTextVerticalType(TextVerticalType::Vertical270);
    # Создать объект Paragraph для текстового фрейма
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Создать объект Portion для абзаца
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Сохранить презентацию
    $pres->save("RotateText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Установка произвольного угла поворота для TextFrame**
Aspose.Slides for PHP via Java теперь поддерживает задание произвольного угла поворота для TextFrame. В этой теме показан пример, как задать свойство RotationAngle в Aspose.Slides. Добавлены новые методы [setRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setrotationangle/) и [getRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/getrotationangle/) в класс [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/), позволяющие задавать произвольный угол поворота для TextFrame. Чтобы задать RotationAngle, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Добавьте диаграмму на слайд.
3. [Задайте угол поворота](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setrotationangle/).
4. Сохраните презентацию в файл PPTX.

В примере ниже показано, как установить свойство RotationAngle.
```php
  # Создать экземпляр класса Presentation
  $pres = new Presentation();
  try {
    # Получить первый слайд
    $slide = $pres->getSlides()->get_Item(0);
    # Добавить AutoShape типа Rectangle
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 350);
    # Добавить TextFrame к прямоугольнику
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Доступ к текстовому фрейму
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setRotationAngle(25);
    # Создать объект Paragraph для текстового фрейма
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Создать объект Portion для абзаца
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("Text rotation example.");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Сохранить презентацию
    $pres->save($resourcesOutputPath . "RotateText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Межстрочный интервал абзаца**
Aspose.Slides предоставляет свойства в [ParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/) — `SpaceAfter`, `SpaceBefore` и `SpaceWithin` — которые позволяют управлять межстрочным интервалом абзаца. Свойства используют следующим образом:

* Чтобы задать межстрочный интервал в процентах, укажите положительное значение. 
* Чтобы задать межстрочный интервал в пунктах, укажите отрицательное значение.

Например, можно установить интервал 16 pt, задав `SpaceBefore` = -16.

Как задать межстрочный интервал для конкретного абзаца:

1. Загрузите презентацию, содержащую AutoShape с текстом.
2. Получите ссылку на слайд через его индекс.
3. Доступ к TextFrame.
4. Доступ к Paragraph.
5. Установите свойства Paragraph.
6. Сохраните презентацию.

Этот PHP‑код показывает, как задать межстрочный интервал для абзаца:
```php
  # Создать экземпляр класса Presentation
  $pres = new Presentation("Fonts.pptx");
  try {
    # Получить ссылку на слайд по его индексу
    $sld = $pres->getSlides()->get_Item(0);
    # Доступ к TextFrame
    $tf1 = $sld->getShapes()->get_Item(0)->getTextFrame();
    # Доступ к абзацу
    $para = $tf1->getParagraphs()->get_Item(0);
    # Установить свойства абзаца
    $para->getParagraphFormat()->setSpaceWithin(80);
    $para->getParagraphFormat()->setSpaceBefore(40);
    $para->getParagraphFormat()->setSpaceAfter(40);
    # Сохранить презентацию
    $pres->save("LineSpacing_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Установка свойства AutofitType для TextFrame**
В этой теме рассматриваются различные свойства форматирования TextFrame. Статья описывает, как задать свойство AutofitType, привязку текста и вращение текста в презентации. Aspose.Slides for PHP via Java позволяет задавать свойство AutofitType любого TextFrame. AutofitType может быть установлен в [Normal](https://reference.aspose.com/slides/php-java/aspose.slides/textautofittype/#Normal) или [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/textautofittype/#Shape). При значении [Normal](https://reference.aspose.com/slides/php-java/aspose.slides/textautofittype/#Normal) форма остаётся прежней, а текст подгоняется без изменения формы. При значении [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/textautofittype/#Shape) форма меняется так, чтобы в неё помещался только необходимый текст. Чтобы задать свойство AutofitType для TextFrame, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Доступ к первому слайду.
3. Добавьте любую форму на слайд.
4. Доступ к [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/).
5. [Задайте тип автоподгонки](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setautofittype/) для TextFrame.
6. Сохраните файл на диск.
```php
  # Создать экземпляр класса Presentation
  $pres = new Presentation();
  try {
    # Получить первый слайд
    $slide = $pres->getSlides()->get_Item(0);
    # Добавить AutoShape типа Rectangle
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 150);
    # Добавить TextFrame к прямоугольнику
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Доступ к текстовому фрейму
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    # Создать объект Paragraph для текстового фрейма
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Создать объект Portion для абзаца
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Сохранить презентацию
    $pres->save($resourcesOutputPath . "formatText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Установка привязки текста в TextFrame**
Aspose.Slides for PHP via Java позволяет задавать привязку текста в любом TextFrame. TextAnchorType определяет положение текста в форме. AnchorType может быть установлен в [Top](https://reference.aspose.com/slides/php-java/aspose.slides/textanchortype/#Top), [Center](https://reference.aspose.com/slides/php-java/aspose.slides/textanchortype/#Center), [Bottom](https://reference.aspose.com/slides/php-java/aspose.slides/textanchortype/#Bottom), [Justified](https://reference.aspose.com/slides/php-java/aspose.slides/textanchortype/#Justified) или [Distributed](https://reference.aspose.com/slides/php-java/aspose.slides/textanchortype/#Distributed). Чтобы задать привязку текста в любой TextFrame, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Доступ к первому слайду.
3. Добавьте любую форму на слайд.
4. Доступ к [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/).
5. [Задайте тип привязки текста](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setanchoringtype/) для TextFrame.
6. Сохраните файл на диск.
```php
  # Создать экземпляр класса Presentation
  $pres = new Presentation();
  try {
    # Получить первый слайд
    $slide = $pres->getSlides()->get_Item(0);
    # Добавить AutoShape типа Rectangle
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 350);
    # Добавить TextFrame к прямоугольнику
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Доступ к текстовому фрейму
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setAnchoringType(TextAnchorType::Bottom);
    # Создать объект Paragraph для текстового фрейма
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Создать объект Portion для абзаца
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Сохранить презентацию
    $pres->save("AnchorText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Tabs и EffectiveTabs в презентации**
Все табуляции текста указаны в пикселях.

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**Рисунок: 2 явные табуляции и 2 табуляции по умолчанию**|
- Свойство EffectiveTabs.ExplicitTabCount (2 в нашем случае) равно Tabs.Count.  
- Коллекция EffectiveTabs включает все табуляции (из коллекции Tabs и табуляции по умолчанию).  
- Свойство EffectiveTabs.ExplicitTabCount (2 в нашем случае) равно Tabs.Count.  
- Свойство EffectiveTabs.DefaultTabSize (294) показывает расстояние между табуляциями по умолчанию (3 и 4 в нашем примере).  
- EffectiveTabs.GetTabByIndex(index) с index = 0 вернёт первую явную табуляцию (Position = 731), index = 1 — вторую табуляцию (Position = 1241). При запросе index = 2 будет возвращена первая табуляция по умолчанию (Position = 1470) и т.д.  
- EffectiveTabs.GetTabAfterPosition(pos) используется для получения следующей табуляции после некоторого текста. Например, есть текст: "Hello World!". Чтобы отобразить такой текст, необходимо знать, где начинать рисовать "world!". Сначала вычислите длину "Hello" в пикселях и вызовите GetTabAfterPosition с этим значением. Вы получите позицию следующей табуляции для рисования "world!".  

## **Извлечение текста с эффектом All‑Caps**
В PowerPoint применение эффекта шрифта **All Caps** делает текст заглавным на слайде, даже если он был введён строчными буквами. При получении такой части текста с помощью Aspose.Slides библиотека возвращает текст в исходном виде. Чтобы обработать это, проверьте [TextCapType](https://reference.aspose.com/slides/php-java/aspose.slides/textcaptype/) — если указано `All`, просто преобразуйте полученную строку в верхний регистр, чтобы вывод совпадал с тем, что видят пользователи на слайде.

Допустим, у нас есть следующий текстовый блок на первом слайде файла sample2.pptx.

![The All Caps effect](all_caps_effect.png)

Пример кода ниже показывает, как извлечь текст с применённым эффектом **All Caps**:
```php
$presentation = new Presentation("sample2.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $textPortion = $paragraph->getPortions()->get_Item(0);

    echo "Original text: ", $textPortion->getText(), "\n";

    $textFormat = $textPortion->getPortionFormat()->getEffective();
    if (java_values($textFormat->getTextCapType()) === TextCapType::All) {
        $text = $textPortion->getText()->toUpperCase();
        echo "All-Caps effect: ", $text, "\n";
    }
} finally {
    $presentation->dispose();
}
```


Вывод:
```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```


## **FAQ**

**Как изменить текст в таблице на слайде?**

Для изменения текста в таблице на слайде необходимо использовать класс [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/). Можно пройтись по всем ячейкам таблицы и изменить текст в каждой ячейке, получив её `TextFrame` и свойства `ParagraphFormat`.

**Как применить градиентный цвет к тексту в слайде PowerPoint?**

Чтобы применить градиент к тексту, используйте метод `getFillFormat` в [BasePortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/). Установите `FilFormat` в `Gradient`, задав начальный и конечный цвета градиента, а также дополнительные свойства, такие как направление и прозрачность, для создания градиентного эффекта текста.