---
title: Форматирование текста
type: docs
weight: 50
url: /php-java/text-formatting/
---


## **Выделение текста**
Метод [highlightText](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame#highlightText-java.lang.String-java.awt.Color-) был добавлен в интерфейс [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) и класс [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame).

Он позволяет выделить часть текста цветом фона, используя текстовый образец, аналогично инструменту цвета выделения текста в PowerPoint 2019.

Ниже приведен фрагмент кода, показывающий, как использовать эту функцию:

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $textHighlightingOptions = new TextHighlightingOptions();
    $textHighlightingOptions->setWholeWordsOnly(true);
    $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getTextFrame()->highlightText("title", java("java.awt.Color")->BLUE);// выделение всех слов 'важный'

    $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getTextFrame()->highlightText("to", java("java.awt.Color")->MAGENTA, $textHighlightingOptions);// выделение всех отдельных вхождений 'the'

    $pres->save("OutputPresentation-highlight.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 

Aspose предоставляет простой, [бесплатный онлайн-сервис редактирования PowerPoint](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **Выделение текста с помощью регулярного выражения**

Метод [highlightRegex](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame#highlightRegex-java.lang.String-java.awt.Color-com.aspose.slides.ITextHighlightingOptions-) был добавлен в интерфейс [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) и класс [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame).

Он позволяет выделить часть текста цветом фона с использованием регулярного выражения, аналогично инструменту цвета выделения текста в PowerPoint 2019.

Ниже приведен фрагмент кода, показывающий, как использовать эту функцию:

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $options = new TextHighlightingOptions();
    $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getTextFrame()->highlightRegex("\\b[^\\s]{4}\\b", java("java.awt.Color")->YELLOW, $options);// выделение всех слов длиной 10 символов или больше

    $pres->save("OutputPresentation-highlight.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Установка цвета фона текста**

Aspose.Slides позволяет вам указать предпочитаемый цвет для фона текста.

Этот PHP-код показывает, как установить цвет фона для всего текста:

```php
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
    $autoShape->getTextFrame()->getParagraphs()->clear();
    $para = new Paragraph();
    $portion1 = new Portion("Черный");
    $portion1->getPortionFormat()->setFontBold(NullableBool::True);
    $portion2 = new Portion(" Красный ");
    $portion3 = new Portion("Черный");
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

Этот PHP-код показывает, как установить цвет фона только для части текста:

```php
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
    $autoShape->getTextFrame()->getParagraphs()->clear();
    $para = new Paragraph();
    $portion1 = new Portion("Черный");
    $portion1->getPortionFormat()->setFontBold(NullableBool::True);
    $portion2 = new Portion(" Красный ");
    $portion3 = new Portion("Черный");
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
    $redPortion = StreamSupport->stream($autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->spliterator(), false)->filter(( p) -> $p->getText()->contains("Красный"))->findFirst();
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

## **Выравнивание параграфов текста**

Форматирование текста — один из ключевых элементов при создании любых документов или презентаций. Мы знаем, что Aspose.Slides для PHP через Java поддерживает добавление текста на слайды, но в этой теме мы увидим, как мы можем контролировать выравнивание текстовых параграфов на слайде. Пожалуйста, выполните следующие шаги, чтобы выровнять текстовые параграфы с помощью Aspose.Slides для PHP через Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите ссылку на слайд, используя его индекс.
3. Получите доступ к формам-заполнителям, присутствующим на слайде, и приведите их к типу [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape).
4. Получите параграф (который нужно выровнять) из [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape#getTextFrame--) предоставленного [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape).
5. Выровняйте параграф. Параграф может быть выровнен вправо, влево, по центру и по ширине.
6. Запишите измененную презентацию в файл PPTX.

Реализация вышеуказанных шагов приведена ниже.

```php
  # Создайте объект Presentation, представляющий файл PPTX
  $pres = new Presentation("ParagraphsAlignment.pptx");
  try {
    # Получение первого слайда
    $slide = $pres->getSlides()->get_Item(0);
    # Получение первого и второго заполнительных мест на слайде и приведение их к типу AutoShape
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # Измените текст в обоих заполнителях
    $tf1->setText("Центрировать по Aspose");
    $tf2->setText("Центрировать по Aspose");
    # Получение первого параграфа в заполнителях
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # Выравнивание текстового параграфа по центру
    $para1->getParagraphFormat()->setAlignment(TextAlignment->Center);
    $para2->getParagraphFormat()->setAlignment(TextAlignment->Center);
    # Запись презентации в файл PPTX
    $pres->save("Centeralign_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Установка прозрачности для текста**
В этой статье показано, как установить свойство прозрачности для любой текстовой формы с помощью Aspose.Slides для PHP через Java. Чтобы установить прозрачность текста, пожалуйста, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите ссылку на слайд.
3. Установите цвет тени.
4. Запишите презентацию в файл PPTX.

Реализация вышеуказанных шагов приведена ниже.

```php
  $pres = new Presentation("transparency.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $effects = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getEffectFormat();
    $outerShadowEffect = $effects->getOuterShadowEffect();
    $shadowColor = $outerShadowEffect->getShadowColor()->getColor();
    echo($shadowColor->toString() . " - прозрачность: " . $shadowColor->getAlpha() / 255.0 * 100);
    # Установка прозрачности на ноль процентов
    $outerShadowEffect->getShadowColor()->setColor(new java("java.awt.Color", $shadowColor->getRed(), $shadowColor->getGreen(), $shadowColor->getBlue(), 255));
    $pres->save("transparency-2.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Установка межбуквенного интервала для текста**

Aspose.Slides позволяет устанавливать расстояние между буквами в текстовом поле. Таким образом, вы можете отрегулировать визуальную плотность строки или блока текста, увеличивая или уменьшая расстояние между символами.

Этот PHP-код показывает, как увеличить расстояние для одной строки текста и уменьшить расстояние для другой строки:

```php
  $presentation = new Presentation("in.pptx");
  $textBox1 = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $textBox2 = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(1);
  $textBox1->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(20);// увеличить

  $textBox2->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(-2);// уменьшить

  $presentation->save("out.pptx", SaveFormat::Pptx);

```

## **Управление свойствами шрифта параграфа**

Презентации обычно содержат как текст, так и изображения. Текст может форматироваться различными способами, чтобы выделить определенные разделы и слова или соответствовать корпоративным стилям. Форматирование текста помогает пользователям разнообразить внешний вид содержимого презентации. Эта статья показывает, как использовать Aspose.Slides для PHP через Java для настройки свойств шрифта параграфов текста на слайдах. Чтобы управлять свойствами шрифта параграфа с помощью Aspose.Slides для PHP через Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Получите доступ к формам-заполнителям на слайде и приведите их к [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
1. Получите [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) из [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame), предоставленного [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
1. Обосновайте параграф.
1. Получите текстовую часть параграфа.
1. Определите шрифт с помощью FontData и установите шрифт текста соответственно.
   1. Установите шрифт в жирный.
   1. Установите шрифт в курсив.
1. Установите цвет шрифта с помощью [getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IBasePortionFormat#getFillFormat--) предоставленного объекта [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion).
1. Запишите измененную презентацию в файл [PPTX](https://docs.fileformat.com/presentation/pptx/).

Реализация вышеуказанных шагов приведена ниже. Она принимает презентуемую презентацию и форматирует шрифты на одном из слайдов.

```php
  # Создайте объект Presentation, представляющий файл PPTX
  $pres = new Presentation("FontProperties.pptx");
  try {
    # Получение ссылки на слайд по его позиции
    $slide = $pres->getSlides()->get_Item(0);
    # Получение первого и второго заполнителя на слайде и приведение их к типу AutoShape
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # Получение первого параграфа
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # Получение первой части
    $port1 = $para1->getPortions()->get_Item(0);
    $port2 = $para2->getPortions()->get_Item(0);
    # Определение новых шрифтов
    $fd1 = new FontData("Elephant");
    $fd2 = new FontData("Castellar");
    # Присвоить новые шрифты части
    $port1->getPortionFormat()->setLatinFont($fd1);
    $port2->getPortionFormat()->setLatinFont($fd2);
    # Установить шрифт в жирный
    $port1->getPortionFormat()->setFontBold(NullableBool::True);
    $port2->getPortionFormat()->setFontBold(NullableBool::True);
    # Установить шрифт в курсив
    $port1->getPortionFormat()->setFontItalic(NullableBool::True);
    $port2->getPortionFormat()->setFontItalic(NullableBool::True);
    # Установить цвет шрифта
    $port1->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port1->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
    $port2->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port2->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    # Запись PPTX на диск
    $pres->save("WelcomeFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Управление семейством шрифтов текста**
Часть используется для хранения текста с аналогичным стилем форматирования в параграфе. Эта статья показывает, как использовать Aspose.Slides для PHP через Java для создания текстового поля с некоторым текстом, а затем определения конкретного шрифта и различных других свойств категории семейства шрифтов. Чтобы создать текстовое поле и установить свойства шрифта текста в нем:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) типа [Прямоугольник](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType#Rectangle) на слайд.
4. Уберите стиль заливки, связанный с [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
5. Получите доступ к TextFrame AutoShape.
6. Добавьте текст в TextFrame.
7. Получите доступ к объекту Portion, связанному с [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
8. Определите шрифт, который будет использоваться для [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion).
9. Установите другие свойства шрифта, такие как жирный, курсив, подчеркивание, цвет и высота с использованием соответствующих свойств, предоставленных объектом Portion.
10. Запишите измененную презентацию в файл PPTX.

Реализация вышеуказанных шагов приведена ниже.

```php
  # Создайте презентацию
  $pres = new Presentation();
  try {
    # Получите первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Добавить AutoShape типа Прямоугольник
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    # Удалите любые стили заливки, связанные с AutoShape
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Получите доступ к TextFrame, связанному с AutoShape
    $tf = $ashp->getTextFrame();
    $tf->setText("Aspose TextBox");
    # Получите доступ к Portion, связанному с TextFrame
    $port = $tf->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    # Установите шрифт для Portion
    $port->getPortionFormat()->setLatinFont(new FontData("Times New Roman"));
    # Установите свойство Bold шрифта
    $port->getPortionFormat()->setFontBold(NullableBool::True);
    # Установите свойство Italic шрифта
    $port->getPortionFormat()->setFontItalic(NullableBool::True);
    # Установите свойство Underline шрифта
    $port->getPortionFormat()->setFontUnderline(TextUnderlineType::Single);
    # Установите высоту шрифта
    $port->getPortionFormat()->setFontHeight(25);
    # Установите цвет шрифта
    $port->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # Запишите PPTX на диск
    $pres->save("SetTextFontProperties_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Установка размера шрифта для текста**

Aspose.Slides позволяет вам выбрать предпочитаемый размер шрифта для существующего текста в параграфе и другого текста, который может быть добавлен в параграф позже.

Этот PHP-код показывает, как установить размер шрифта для текста, содержащегося в параграфе:

```php
  $presentation = new Presentation("example.pptx");
  try {
    # Получение первой формы, например.
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
      $autoShape = $shape;
      # Получение первого параграфа, например.
      $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
      # Установка размера шрифта по умолчанию на 20 пунктов для всех текстовых частей в параграфе.
      $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(20);
      # Установка размера шрифта на 20 пунктов для текущих текстовых частей в параграфе.
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

## **Установка вращения текста**

Aspose.Slides для PHP через Java позволяет разработчикам вращать текст. Текст можно установить, чтобы он отображался как [Горизонтальный](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#Horizontal), [Вертикальный](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#Vertical), [Вертикальный270](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#Vertical270), [WordArtВертикальный](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#WordArtVertical), [ВосточноазиатскийВертикальный](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#EastAsianVertical), [МонгольскийВертикальный](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#MongolianVertical) или [WordArtВертикальныйСправаналево](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#WordArtVerticalRightToLeft). Чтобы повернуть текст любого TextFrame, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите первый слайд.
3. Добавьте любую форму на слайд.
4. Получите доступ к [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
5. [Поверните текст](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setTextVerticalType-byte-).
6. Сохраните файл на диск.

```php
  # Создайте экземпляр класса Presentation
  $pres = new Presentation();
  try {
    # Получите первый слайд
    $slide = $pres->getSlides()->get_Item(0);
    # Добавьте AutoShape типа Прямоугольник
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 350);
    # Добавьте TextFrame в Прямоугольник
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Получение текстового кадра
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setTextVerticalType(TextVerticalType::Vertical270);
    # Создайте объект Paragraph для текстового кадра
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Создайте объект Portion для параграфа
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("Умная курица перепрыгивает через ленивую собаку. Умная курица перепрыгивает через ленивую собаку.");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Сохраните Презентацию
    $pres->save("RotateText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Установка угла вращения для TextFrame**
Aspose.Slides для PHP через Java теперь поддерживает установку пользовательского угла вращения для текстового кадра. В этой теме мы увидим с примером, как установить свойство RotationAngle в Aspose.Slides. Новые методы [setRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setRotationAngle-float-) и [getRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#getRotationAngle--) были добавлены в интерфейсы [IChartTextBlockFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IChartTextBlockFormat) и [ITextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat), что позволяет установить пользовательский угол поворота для текстового кадра. Чтобы установить RotationAngle, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Добавьте диаграмму на слайд.
3. [Установите свойство RotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setRotationAngle-float-).
4. Запишите презентацию в файл PPTX.

В приведенном ниже примере мы устанавливаем свойство RotationAngle.

```php
  # Создайте экземпляр класса Presentation
  $pres = new Presentation();
  try {
    # Получите первый слайд
    $slide = $pres->getSlides()->get_Item(0);
    # Добавьте AutoShape типа Прямоугольник
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 350);
    # Добавьте TextFrame в Прямоугольник
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Получение текстового кадра
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setRotationAngle(25);
    # Создайте объект Paragraph для текстового кадра
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Создайте объект Portion для параграфа
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("Пример вращения текста.");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Сохраните Презентацию
    $pres->save($resourcesOutputPath . "RotateText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Междустрочный интервал параграфа**
Aspose.Slides предоставляет свойства в [ParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IParagraphFormat)—`SpaceAfter`, `SpaceBefore` и `SpaceWithin`—которые позволяют управлять межстрочным интервалом для параграфа. Эти три свойства используются следующим образом:

* Чтобы указать межстрочный интервал для параграфа в процентах, используйте положительное значение. 
* Чтобы указать межстрочный интервал для параграфа в пунктах, используйте отрицательное значение.

Например, вы можете установить межстрочный интервал в 16 пунктов для параграфа, установив свойство `SpaceBefore` на -16.

Вот как вы можете указать межстрочный интервал для конкретного параграфа:

1. Загрузите презентацию, содержащую AutoShape с текстом.
2. Получите ссылку на слайд по его индексу.
3. Получите доступ к TextFrame.
4. Получите доступ к параграфу.
5. Установите свойства параграфа.
6. Сохраните презентацию.

Этот PHP-код показывает, как указать межстрочный интервал для параграфа:

```php
  # Создайте экземпляр класса Presentation
  $pres = new Presentation("Fonts.pptx");
  try {
    # Получите ссылку на слайд по индексу
    $sld = $pres->getSlides()->get_Item(0);
    # Получите доступ к TextFrame
    $tf1 = $sld->getShapes()->get_Item(0)->getTextFrame();
    # Получите доступ к параграфу
    $para = $tf1->getParagraphs()->get_Item(0);
    # Установите свойства параграфа
    $para->getParagraphFormat()->setSpaceWithin(80);
    $para->getParagraphFormat()->setSpaceBefore(40);
    $para->getParagraphFormat()->setSpaceAfter(40);
    # Сохраните презентацию
    $pres->save("LineSpacing_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Установка свойства AutofitType для текстового кадра**
В этой теме мы исследуем различные свойства форматирования текстового кадра. Эта статья охватывает, как установить свойство AutofitType текстового кадра, якорь текста и вращение текста в презентации. Aspose.Slides для PHP через Java позволяет разработчикам устанавливать свойство AutofitType любого текстового кадра. AutofitType может быть установлен на [Normal](https://reference.aspose.com/slides/php-java/aspose.slides/TextAutofitType#Normal) или [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/TextAutofitType#Shape). Если установлено на [Normal](https://reference.aspose.com/slides/php-java/aspose.slides/TextAutofitType#Normal), то форма останется прежней, в то время как текст будет подгонять без изменения самой формы, тогда как если AutofitType установлен на [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/TextAutofitType#Shape), то форма будет изменена таким образом, что в ней будет содержаться только необходимый текст. Чтобы установить свойство AutofitType текстового кадра, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation ](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите доступ к первому слайду.
3. Добавьте любую форму на слайд.
4. Получите доступ к [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
5. [Установите AutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setAutofitType-byte-) для TextFrame.
6. Сохраните файл на диск.

```php
  # Создайте экземпляр класса Presentation
  $pres = new Presentation();
  try {
    # Получите первый слайд
    $slide = $pres->getSlides()->get_Item(0);
    # Добавьте AutoShape типа Прямоугольник
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 150);
    # Добавьте TextFrame в Прямоугольник
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Получение текстового кадра
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    # Создайте объект Paragraph для текстового кадра
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Создайте объект Portion для параграфа
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("Умная курица перепрыгивает через ленивую собаку. Умная курица перепрыгивает через ленивую собаку.");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Сохраните Презентацию
    $pres->save($resourcesOutputPath . "formatText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Установка якоря TextFrame**
Aspose.Slides для PHP через Java позволяет разработчикам устанавливать якорь любого TextFrame. TextAnchorType определяет, где текст размещен в форме. AnchorType может быть установлен на [Верхний](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Top), [Центр](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Center), [Нижний](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Bottom), [Выравненный](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Justified) или [Распределенный](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Distributed). Чтобы установить якорь любого текстового кадра, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите доступ к первому слайду.
3. Добавьте любую форму на слайд.
4. Получите доступ к [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
5. [Установите TextAnchorType](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setAnchoringType-byte-) текстового кадра.
6. Сохраните файл на диск.

```php
  # Создайте экземпляр класса Presentation
  $pres = new Presentation();
  try {
    # Получите первый слайд
    $slide = $pres->getSlides()->get_Item(0);
    # Добавьте AutoShape типа Прямоугольник
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 350);
    # Добавьте TextFrame в Прямоугольник
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Получение текстового кадра
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setAnchoringType(TextAnchorType::Bottom);
    # Создайте объект Paragraph для текстового кадра
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Создайте объект Portion для параграфа
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("Умная курица перепрыгивает через ленивую собаку. Умная курица перепрыгивает через ленивую собаку.");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Сохраните Презентацию
    $pres->save("AnchorText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Вкладки и EffectiveTabs в презентации**
Все текстовые табуляции указываются в пикселях.

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**Рисунок: 2 явные вкладки и 2 вкладки по умолчанию**|
- Свойство EffectiveTabs.ExplicitTabCount (2 в нашем случае) равно свойства Tabs.Count.
- Коллекция EffectiveTabs включает все вкладки (из коллекции вкладок и вкладок по умолчанию).
- Свойство EffectiveTabs.ExplicitTabCount (2 в нашем случае) равно свойства Tabs.Count.
- Свойство EffectiveTabs.DefaultTabSize (294) показывает расстояние между вкладками по умолчанию (3 и 4 в нашем примере).
- Метод EffectiveTabs.GetTabByIndex(index) с индексом = 0 вернет первую явную вкладку (Position = 731), индекс = 1 — вторую вкладку (Position = 1241). Если вы попробуете получить следующую вкладку с индексом = 2, она вернет первую вкладку по умолчанию (Position = 1470) и т. д.
- Метод EffectiveTabs.GetTabAfterPosition(pos) используется для получения следующей табуляции после некоторого текста. Например, вы имеете текст: "Привет, мир!". Чтобы отобразить такой текст, вам нужно знать, где начать рисовать "мир!". Сначала вы должны рассчитать длину "Привет" в пикселях и вызвать GetTabAfterPosition с этим значением. Вы получите следующую позицию табуляции, чтобы нарисовать "мир!".
