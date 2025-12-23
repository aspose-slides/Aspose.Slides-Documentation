---
title: Форматировать текст PowerPoint в PHP
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
- вращение текста
- угол вращения
- текстовый фрейм
- межстрочный интервал
- свойство автоподгонки
- привязка текстового фрейма
- табуляция текста
- язык по умолчанию
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Форматировать и стилизовать текст в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для PHP через Java. Настраивайте шрифты, цвета, выравнивание и многое другое."
---

## **Выделить текст**
Метод [highlightText](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame#highlightText-java.lang.String-java.awt.Color-) был добавлен в интерфейс [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) и класс [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame).

Он позволяет выделять часть текста фоном, используя образец текста, аналогично инструменту Text Highlight Color в PowerPoint 2019.

Ниже приведён фрагмент кода, показывающий, как использовать эту функцию:
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
Aspose предоставляет простой, [бесплатный онлайн‑сервис редактирования PowerPoint](https://products.aspose.app/slides/editor)
{{% /alert %}} 

## **Выделение текста с помощью регулярного выражения**
Метод [highlightRegex](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame#highlightRegex-java.lang.String-java.awt.Color-com.aspose.slides.ITextHighlightingOptions-) был добавлен в интерфейс [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) и класс [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame).

Он позволяет выделять часть текста фоном, используя регулярное выражение, аналогично инструменту Text Highlight Color в PowerPoint 2019.

Ниже приведён фрагмент кода, показывающий, как использовать эту функцию:
```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $options = new TextHighlightingOptions();
    $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getTextFrame()->highlightRegex("\\b[^\\s]{4}\\b", java("java.awt.Color")->YELLOW, $options);// выделение всех слов из 10 и более символов

    $pres->save("OutputPresentation-highlight.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Установить цвет фона текста**
Aspose.Slides позволяет задать предпочитаемый цвет фона для текста.

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


## **Выровнять абзацы текста**
Форматирование текста – один из ключевых элементов при создании любых документов или презентаций. Мы знаем, что Aspose.Slides for PHP via Java поддерживает добавление текста на слайды, но в этой теме мы посмотрим, как управлять выравниванием абзацев текста на слайде. Пожалуйста, выполните следующие шаги для выравнивания абзацев текста с помощью Aspose.Slides for PHP via Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите ссылку на слайд, используя его индекс.
3. Получите доступ к Placeholder‑формам, присутствующим на слайде, и приведите их к типу [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape).
4. Получите абзац (который нужно выровнять) из [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape#getTextFrame--) , предоставляемого [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape).
5. Выровняйте абзац. Абзац может быть выровнен по правому, левому, центру или с выравниванием по ширине.
6. Запишите изменённую презентацию в файл PPTX.

Реализация указанных выше шагов приведена ниже.
```php
  # Создайте объект Presentation, представляющий файл PPTX
  $pres = new Presentation("ParagraphsAlignment.pptx");
  try {
    # Получаем первый слайд
    $slide = $pres->getSlides()->get_Item(0);
    # Доступ к первому и второму заполнительному элементу на слайде и приведение их к типу AutoShape
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # Изменяем текст в обоих заполнителях
    $tf1->setText("Center Align by Aspose");
    $tf2->setText("Center Align by Aspose");
    # Получаем первый абзац из заполнителей
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # Выравниваем абзац текста по центру
    $para1->getParagraphFormat()->setAlignment(TextAlignment->Center);
    $para2->getParagraphFormat()->setAlignment(TextAlignment->Center);
    # Сохраняем презентацию в файл PPTX
    $pres->save("Centeralign_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Установить прозрачность текста**
В этой статье демонстрируется, как установить свойство прозрачности для любой текстовой формы с помощью Aspose.Slides for PHP via Java. Чтобы задать прозрачность текста, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите ссылку на слайд.
3. Установите цвет тени.
4. Запишите презентацию в файл PPTX.

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


## **Установить межсимвольный интервал для текста**
Aspose.Slides позволяет задать расстояние между буквами в текстовом поле. Таким образом, вы можете регулировать визуальную плотность строки или блока текста, расширяя или сжимая интервалы между символами.

Этот PHP‑код показывает, как расширить интервалы для одной строки текста и сжать их для другой строки:
```php
  $presentation = new Presentation("in.pptx");
  $textBox1 = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $textBox2 = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(1);
  $textBox1->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(20);// расширить

  $textBox2->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(-2);// сжать

  $presentation->save("out.pptx", SaveFormat::Pptx);
```


## **Управление свойствами шрифта абзаца**
Презентации обычно содержат как текст, так и изображения. Текст может быть отформатирован различными способами, либо для выделения определённых разделов и слов, либо в соответствии с корпоративными стилями. Форматирование текста помогает пользователям менять внешний вид содержания презентации. Эта статья показывает, как с помощью Aspose.Slides for PHP via Java настроить свойства шрифта абзацев текста на слайдах. Чтобы управлять свойствами шрифта абзаца с помощью Aspose.Slides for PHP via Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите ссылку на слайд, используя его индекс.
3. Получите доступ к Placeholder‑формам на слайде и приведите их к типу [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
4. Получите [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) из [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame), предоставляемого [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
5. Выровняйте абзац по ширине.
6. Получите объект Portion текста абзаца.
7. Определите шрифт с помощью FontData и соответственно установите Font у Portion текста.
   1. Установите полужирный стиль шрифта.
   2. Установите курсив.
8. Установите цвет шрифта, используя [getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IBasePortionFormat#getFillFormat--), предоставляемый объектом [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion).
9. Сохраните изменённую презентацию в файл [PPTX](https://docs.fileformat.com/presentation/pptx/).

```php
  # Создайте объект Presentation, представляющий файл PPTX
  $pres = new Presentation("FontProperties.pptx");
  try {
    # Доступ к слайду по его позиции
    $slide = $pres->getSlides()->get_Item(0);
    # Доступ к первому и второму заполнителям на слайде и приведение их к типу AutoShape
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # Доступ к первому абзацу
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # Доступ к первой части
    $port1 = $para1->getPortions()->get_Item(0);
    $port2 = $para2->getPortions()->get_Item(0);
    # Определите новые шрифты
    $fd1 = new FontData("Elephant");
    $fd2 = new FontData("Castellar");
    # Присвоить новые шрифты части
    $port1->getPortionFormat()->setLatinFont($fd1);
    $port2->getPortionFormat()->setLatinFont($fd2);
    # Установить шрифт полужирным
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
Portion используется для хранения текста с одинаковым стилем в абзаце. Эта статья показывает, как с помощью Aspose.Slides for PHP via Java создать текстовое поле с некоторым текстом и затем задать определённый шрифт и различные свойства семейства шрифтов. Чтобы создать текстовое поле и задать свойства шрифта текста в нём:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) типа [Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType#Rectangle) на слайд.
4. Удалите стиль заливки, связанный с [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
5. Получите TextFrame AutoShape.
6. Добавьте текст в TextFrame.
7. Получите объект Portion, связанный с [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
8. Определите шрифт, который будет использоваться для [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion).
9. Установите другие свойства шрифта, такие как полужирный, курсив, подчёркивание, цвет и высота, используя соответствующие свойства, предоставляемые объектом Portion.
10. Сохраните изменённую презентацию в файл PPTX.

```php
  # Создать объект Presentation
  $pres = new Presentation();
  try {
    # Получить первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Добавить AutoShape типа Rectangle
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    # Удалить любую заливку, связанную с AutoShape
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Обратиться к TextFrame, связанному с AutoShape
    $tf = $ashp->getTextFrame();
    $tf->setText("Aspose TextBox");
    # Обратиться к Portion, связанному с TextFrame
    $port = $tf->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    # Задать шрифт для Portion
    $port->getPortionFormat()->setLatinFont(new FontData("Times New Roman"));
    # Установить полужирный стиль шрифта
    $port->getPortionFormat()->setFontBold(NullableBool::True);
    # Установить курсив шрифта
    $port->getPortionFormat()->setFontItalic(NullableBool::True);
    # Установить подчеркивание шрифта
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


## **Установить размер шрифта для текста**
Aspose.Slides позволяет выбрать предпочтительный размер шрифта для существующего текста в абзаце и для текста, который может быть добавлен в абзац позже.

Этот PHP‑код показывает, как установить размер шрифта для текста, содержащегося в абзаце:
```php
  $presentation = new Presentation("example.pptx");
  try {
    # Получает первую форму, например.
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
      $autoShape = $shape;
      # Получает первый абзац, например.
      $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
      # Устанавливает размер шрифта по умолчанию 20 pt для всех текстовых частей в абзаце.
      $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(20);
      # Устанавливает размер шрифта 20 pt для текущих текстовых частей в абзаце.
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


## **Установить вращение текста**
Aspose.Slides for PHP via Java позволяет разработчикам вращать текст. Текст может быть установлен как [Horizontal](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#Horizontal), [Vertical](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#Vertical), [Vertical270](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#Vertical270), [WordArtVertical](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#WordArtVertical), [EastAsianVertical](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#EastAsianVertical), [MongolianVertical](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#MongolianVertical) или [WordArtVerticalRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#WordArtVerticalRightToLeft). Чтобы вращать текст любого TextFrame, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите доступ к первому слайду.
3. Добавьте любую форму на слайд.
4. Получите доступ к [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
5. [Rotate the text](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setTextVerticalType-byte-).
6. Сохраните файл на диск.

```php
  # Создать экземпляр класса Presentation
  $pres = new Presentation();
  try {
    # Получить первый слайд
    $slide = $pres->getSlides()->get_Item(0);
    # Добавить AutoShape типа Rectangle
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 350);
    # Добавить TextFrame к Rectangle
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Доступ к TextFrame
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setTextVerticalType(TextVerticalType::Vertical270);
    # Создать объект Paragraph для TextFrame
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


## **Установить пользовательский угол вращения для TextFrame**
Aspose.Slides for PHP via Java теперь поддерживает задавание пользовательского угла вращения для TextFrame. В этой теме мы рассмотрим пример, как установить свойство RotationAngle в Aspose.Slides. Новые методы [setRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setRotationAngle-float-) и [getRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#getRotationAngle--) добавлены в интерфейсы [IChartTextBlockFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IChartTextBlockFormat) и [ITextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat) и позволяют задавать пользовательский угол вращения для TextFrame. Чтобы установить RotationAngle, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Добавьте диаграмму на слайд.
3. [Set RotationAngle property](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setRotationAngle-float-).
4. Запишите презентацию в файл PPTX.

В примере ниже мы задаём свойство RotationAngle.
```php
  # Создать экземпляр класса Presentation
  $pres = new Presentation();
  try {
    # Получить первый слайд
    $slide = $pres->getSlides()->get_Item(0);
    # Добавить AutoShape типа Rectangle
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 350);
    # Добавить TextFrame к Rectangle
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Получить TextFrame
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setRotationAngle(25);
    # Создать объект Paragraph для TextFrame
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Создать объект Portion для Paragraph
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
Aspose.Slides предоставляет свойства в [`ParagraphFormat`](https://reference.aspose.com/slides/php-java/aspose.slides/IParagraphFormat)—`SpaceAfter`, `SpaceBefore` и `SpaceWithin`—которые позволяют управлять межстрочным интервалом абзаца. Свойства используются следующим образом:

* Чтобы задать межстрочный интервал в процентах, используйте положительное значение. 
* Чтобы задать межстрочный интервал в пунктах, используйте отрицательное значение.

Например, вы можете установить интервал 16 pt, задав свойство `SpaceBefore` со значением -16.

Так задаётся межстрочный интервал для конкретного абзаца:

1. Загрузите презентацию, содержащую AutoShape с текстом.
2. Получите ссылку на слайд через его индекс.
3. Получите доступ к TextFrame.
4. Получите доступ к Paragraph.
5. Установите свойства Paragraph.
6. Сохраните презентацию.

Этот PHP‑код показывает, как задать межстрочный интервал для абзаца:
```php
  # Создать экземпляр класса Presentation
  $pres = new Presentation("Fonts.pptx");
  try {
    # Получить ссылку на слайд по его индексу
    $sld = $pres->getSlides()->get_Item(0);
    # Получить доступ к TextFrame
    $tf1 = $sld->getShapes()->get_Item(0)->getTextFrame();
    # Получить доступ к Paragraph
    $para = $tf1->getParagraphs()->get_Item(0);
    # Установить свойства Paragraph
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


## **Установить свойство AutofitType для TextFrame**
В этой теме мы изучим различные свойства форматирования текстовых фреймов. Статья охватывает, как задать свойство AutofitType, привязку текста и вращение текста в презентации. Aspose.Slides for PHP via Java позволяет разработчикам задавать свойство AutofitType любого текстового фрейма. AutofitType может быть установлен в [Normal](https://reference.aspose.com/slides/php-java/aspose.slides/TextAutofitType#Normal) или [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/TextAutofitType#Shape). Если установить [Normal], форма останется прежней, а текст будет подстроен без изменения формы; если установить [Shape], форма будет изменена так, чтобы в ней помещался только необходимый текст. Чтобы задать свойство AutofitType текстового фрейма, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) .
2. Получите доступ к первому слайду.
3. Добавьте любую форму на слайд.
4. Получите доступ к [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
5. [Set the AutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setAutofitType-byte-) текстового фрейма.
6. Сохраните файл на диск.

```php
  # Создать экземпляр класса Presentation
  $pres = new Presentation();
  try {
    # Получить первый слайд
    $slide = $pres->getSlides()->get_Item(0);
    # Добавить AutoShape типа Rectangle
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 150);
    # Добавить TextFrame к Rectangle
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Доступ к TextFrame
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    # Создать объект Paragraph для TextFrame
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Создать объект Portion для Paragraph
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


## **Установить привязку TextFrame**
Aspose.Slides for PHP via Java позволяет разработчикам задавать привязку любого TextFrame. TextAnchorType определяет, где текст размещается в форме. Привязка может быть установлена в [Top](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Top), [Center](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Center), [Bottom](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Bottom), [Justified](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Justified) или [Distributed](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Distributed). Чтобы задать привязку TextFrame, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите доступ к первому слайду.
3. Добавьте любую форму на слайд.
4. Получите доступ к [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
5. [Set TextAnchorType](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setAnchoringType-byte-) TextFrame.
6. Сохраните файл на диск.

```php
  # Создать экземпляр класса Presentation
  $pres = new Presentation();
  try {
    # Получить первый слайд
    $slide = $pres->getSlides()->get_Item(0);
    # Добавить AutoShape типа Rectangle
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 350);
    # Добавить TextFrame к Rectangle
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Доступ к TextFrame
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setAnchoringType(TextAnchorType::Bottom);
    # Создать объект Paragraph для TextFrame
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Создать объект Portion для Paragraph
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


## **Табуляции и EffectiveTabs в презентации**
Все табуляции текста задаются в пикселях.

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**Рисунок: 2 явные табуляции и 2 табуляции по умолчанию**|

- Свойство EffectiveTabs.ExplicitTabCount (2 в нашем случае) равно Tabs.Count.  
- Коллекция EffectiveTabs включает все табуляции (из коллекции Tabs и табуляции по умолчанию).  
- EffectiveTabs.ExplicitTabCount (2 в нашем случае) равно Tabs.Count.  
- Свойство EffectiveTabs.DefaultTabSize (294) показывает расстояние между табуляциями по умолчанию (3 и 4 в нашем примере).  
- EffectiveTabs.GetTabByIndex(index) с index = 0 вернёт первую явную табуляцию (Position = 731), index = 1 – вторую табуляцию (Position = 1241). При запросе index = 2 будет возвращена первая табуляция по умолчанию (Position = 1470) и т.д.  
- EffectiveTabs.GetTabAfterPosition(pos) используется для получения следующей табуляции после некоторого текста. Например, у вас есть текст «Hello World!». Чтобы отобразить такой текст, нужно знать, где начинается «world!». Сначала рассчитывается длина слова «Hello» в пикселях и вызывается GetTabAfterPosition с этим значением. Вы получаете позицию следующей табуляции для отрисовки «world!».

## **Извлечь текст с эффектом All-Caps**
В PowerPoint применение эффекта **All Caps** делает текст заглавными буквами на слайде, даже если он был введён строчными. При получении такого текста через Aspose.Slides библиотека возвращает его в том виде, в каком он был введён. Чтобы обработать это, проверьте [TextCapType](https://reference.aspose.com/slides/php-java/aspose.slides/textcaptype/) — если он указывает `All`, просто преобразуйте возвращённую строку в верхний регистр, чтобы вывод совпадал с тем, что видят пользователи на слайде.

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


```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```


## **FAQ**

**Как изменить текст в таблице на слайде?**

Чтобы изменить текст в таблице на слайде, необходимо использовать класс [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/). Можно перебрать все ячейки таблицы и изменить текст в каждой ячейке, получив доступ к её `TextFrame` и `ParagraphFormat` внутри каждой ячейки.

**Как применить градиентный цвет к тексту в слайде PowerPoint?**

Чтобы применить градиентный цвет к тексту, используйте метод `getFillFormat` в [BasePortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/). Установите `FillFormat` в `Gradient`, где можно задать начальный и конечный цвета градиента, а также другие свойства, такие как направление и прозрачность, для создания градиентного эффекта на тексте.