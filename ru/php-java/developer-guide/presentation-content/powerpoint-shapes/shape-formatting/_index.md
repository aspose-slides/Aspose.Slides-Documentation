---
title: Форматирование фигур PowerPoint в PHP
linktitle: Форматирование фигур
type: docs
weight: 20
url: /ru/php-java/shape-formatting/
keywords:
- формат фигуры
- формат линии
- эффект наброска
- набросок линии фигуры
- стиль соединения
- градиентная заливка
- заливка шаблоном
- заливка изображением
- заливка текстурой
- заливка сплошным цветом
- прозрачность фигуры
- черно-белая отрисовка фигуры
- отображение фигуры в градациях серого
- вращение фигуры
- 3D-эффект фаски
- 3D-эффект вращения
- сброс форматирования
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как форматировать фигуры PowerPoint в PHP с помощью Aspose.Slides — задавайте стили заливки, линии и эффектов для файлов PPT, PPTX и ODP с точностью и полным контролем."
---
## **Введение**

В PowerPoint вы можете добавлять фигуры на слайды. Поскольку фигуры состоят из линий, их можно форматировать, изменяя или применяя эффекты к контуру. Кроме того, фигуры можно форматировать, задавая параметры заполнения их внутренних областей.

![формат-формы-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for PHP via Java предоставляет классы и методы, позволяющие форматировать фигуры с использованием тех же возможностей, что и в PowerPoint.

## **Форматирование линий**

С помощью Aspose.Slides вы можете задать пользовательский стиль линии для фигуры. Ниже приведена последовательность действий:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) на слайд.
1. Установите [line style](https://reference.aspose.com/slides/php-java/aspose.slides/linestyle/) фигуры.
1. Задайте толщину линии.
1. Установите [dash style](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/) линии.
1. Задайте цвет линии для фигуры.
1. Сохраните изменённую презентацию как файл PPTX.

Следующий PHP‑код демонстрирует, как отформатировать прямоугольный `AutoShape`:

```php
// Создайте экземпляр класса Presentation, который представляет файл презентации.
$presentation = new Presentation();
try {
    // Получите первый слайд.
    $slide = $presentation->getSlides()->get_Item(0);

    // Добавьте автофигуру типа Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

    // Задайте цвет заливки для прямоугольной фигуры.
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    // Примените форматирование к линиям прямоугольника.
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);

    // Задайте цвет линии прямоугольника.
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // Сохраните файл PPTX на диск.
    $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат:

![Отформатированные линии в презентации](formatted-lines.png)

## **Применить эффекты наброска к линиям фигур**

Эффект наброска делает линию фигуры выглядящей как нарисованную от руки. Используйте [Shape.getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) для доступа к настройкам линии, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/) — для доступа к настройкам наброска, и [SketchFormat.setSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/) — для выбора значения из перечисления [LineSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/).

Следующий PHP‑код показывает, как применить эффект [LineSketchType.Curved](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/), прочитать явно назначенное значение и удалить эффект с помощью [LineSketchType.None](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/):

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

    // Доступ к формату линии фигуры и её формату наброска.
    $sketchFormat = $shape->getLineFormat()->getSketchFormat();

    // Применить эффект наброска.
    $sketchFormat->setSketchType(LineSketchType::Curved);

    // Прочитать эффект наброска, назначенный непосредственно фигуре.
    $explicitSketchType = $sketchFormat->getSketchType();
    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;

    // Удалить эффект наброска.
    $sketchFormat->setSketchType(LineSketchType::None);
} finally {
    $presentation->dispose();
}
```

Значение, возвращаемое [SketchFormat.getSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/), представляет настройку, непосредственно присвоенную фигуре. Если форматирование линии может наследоваться из темы, мастер‑слайда или шаблона, используйте [LineFormat.getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/), обратитесь к методу `getSketchFormat` полученного объекта и прочитайте его значение `getSketchType`. Эффективное значение отражает фактическое форматирование после разрешения наследования:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $lineFormat = $shape->getLineFormat();

    $explicitSketchType = $lineFormat->getSketchFormat()->getSketchType();
    $effectiveLineFormat = $lineFormat->getEffective();
    $effectiveSketchType = $effectiveLineFormat->getSketchFormat()->getSketchType();

    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;
    echo "Effective sketch type: " . $effectiveSketchType . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Форматирование стилей соединений**

Варианты трёх типов соединений:

* Round
* Miter
* Bevel

По умолчанию, когда PowerPoint соединяет две линии под углом (например, в углу фигуры), используется параметр **Round**. Однако при рисовании фигур с острыми углами может быть предпочтительнее вариант **Miter**.

![Стиль соединения в презентации](join-style-powerpoint.png)

Следующий PHP‑код демонстрирует, как три прямоугольника (как показано на изображении выше) были созданы с использованием настроек соединения Miter, Bevel и Round:

```php
// Создайте экземпляр класса Presentation, который представляет файл презентации.
$presentation = new Presentation();
try {
    // Получите первый слайд.
    $slide = $presentation->getSlides()->get_Item(0);

    // Добавьте три автофигуры типа Rectangle.
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    // Установите цвет заливки для каждой прямоугольной фигуры.
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

    // Установите толщину линии.
    $shape1->getLineFormat()->setWidth(15);
    $shape2->getLineFormat()->setWidth(15);
    $shape3->getLineFormat()->setWidth(15);

    // Задайте цвет линии для каждого прямоугольника.
    $shape1->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape3->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // Задайте стиль соединения.
    $shape1->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
    $shape2->getLineFormat()->setJoinStyle(LineJoinStyle::Bevel);
    $shape3->getLineFormat()->setJoinStyle(LineJoinStyle::Round);

    // Добавьте текст к каждому прямоугольнику.
    $shape1->getTextFrame()->setText("Miter Join Style");
    $shape2->getTextFrame()->setText("Bevel Join Style");
    $shape3->getTextFrame()->setText("Round Join Style");

    // Сохраните файл PPTX на диск.
    $presentation->save("join_styles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Градиентная заливка**

В PowerPoint градиентная заливка — это параметр форматирования, позволяющий применить непрерывный переход цветов к фигуре. Например, можно задать два или более цвета, где один постепенно переходит в другой.

Вот как применить градиентную заливку к фигуре с помощью Aspose.Slides:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) на слайд.
1. Установите [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) фигуры в `Gradient`.
1. Добавьте два желаемых цвета с определёнными позициями, используя методы `add` коллекции остановок градиента, доступные через класс [GradientFormat](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/) .
1. Сохраните изменённую презентацию как файл PPTX.

Следующий PHP‑код демонстрирует, как применить градиентный эффект к эллипсу:

```php
// Создайте экземпляр класса Presentation, представляющего файл презентации.
$presentation = new Presentation();
try {
    // Получите первый слайд.
    $slide = $presentation->getSlides()->get_Item(0);

    // Добавьте автофигуру типа Ellipse.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

    // Примените градиентное форматирование к эллипсу.
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);

    // Задайте направление градиента.
    $shape->getFillFormat()->getGradientFormat()->setGradientDirection(GradientDirection::FromCorner2);

    // Добавьте две остановки градиента.
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0, PresetColor::Red);

    // Сохраните файл PPTX на диск.
    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат:

![Эллипс с градиентной заливкой](gradient-fill.png)

Если градиент выглядит иначе в экспортированном изображении, чем в PowerPoint, см. [Choose a Gradient Rendering Style](/slides/ru/php-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Вы можете выбрать стиль рендеринга, не меняя градиентную заливку, сохранённую в презентации.

## **Заливка шаблоном**

В PowerPoint заливка шаблоном — это параметр форматирования, позволяющий применить двухцветный рисунок — например, точки, полосы, штриховку или шахматную сетку — к фигуре. Вы можете задать собственные цвета переднего и заднего плана шаблона.

Aspose.Slides предоставляет более 45 предопределённых стилей шаблонов, которые можно применять к фигурам для улучшения визуального восприятия презентаций. После выбора предопределённого шаблона вы всё равно можете указать точные цвета, которые он будет использовать.

Вот как применить заливку шаблоном к фигуре с помощью Aspose.Slides:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) на слайд.
1. Установите [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) фигуры в `Pattern`.
1. Выберите стиль шаблона из предопределённых вариантов.
1. Установите [Background Color](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getBackColor) шаблона.
1. Установите [Foreground Color](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getForeColor) шаблона.
1. Сохраните изменённую презентацию как файл PPTX.

Следующий PHP‑код демонстрирует, как применить заливку шаблоном к прямоугольнику:

```php
// Создайте экземпляр класса Presentation, представляющего файл презентации.
$presentation = new Presentation();
try {
    // Получите первый слайд.
    $slide = $presentation->getSlides()->get_Item(0);

    // Добавьте автофигуру типа Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Задайте тип заливки Pattern.
    $shape->getFillFormat()->setFillType(FillType::Pattern);

    // Установите стиль шаблона.
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);

    // Задайте фон и передний цвет шаблона.
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    // Сохраните файл PPTX на диск.
    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат:

![Прямоугольник с заливкой шаблоном](pattern-fill.png)

## **Заливка изображением**

В PowerPoint заливка изображением — это параметр форматирования, позволяющий вставить изображение внутрь фигуры, effectively using the image as the shape's background.

Вот как использовать Aspose.Slides для применения заливки изображением к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) на слайд.
1. Установите [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) фигуры в `Picture`.
1. Установите режим заливки изображения в `Tile` (или другой предпочтительный режим).
1. Создайте объект [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) из изображения, которое хотите использовать.
1. Передайте изображение методу `SlidesPicture.setImage`.
1. Сохраните изменённую презентацию как файл PPTX.

Допустим, у нас есть файл «lotus.png» со следующим изображением:

![Изображение лотоса](lotus.png)

Следующий PHP‑код демонстрирует, как заполнить фигуру изображением:

```php
// Создайте экземпляр класса Presentation, представляющего файл презентации.
$presentation = new Presentation();
try {
    // Получите первый слайд.
    $slide = $presentation->getSlides()->get_Item(0);

    // Добавьте автофигуру типа Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

    // Задайте тип заливки Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Установите режим заливки изображением.
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    // Загрузите изображение и добавьте его в ресурсы презентации.
    $image = Images::fromFile("lotus.png");
    $picture = $presentation->getImages()->addImage($image);
    $image->dispose();

    // Задайте изображение.
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);

    // Сохраните файл PPTX на диск.
    $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат:

![Фигура с заливкой изображением](picture-fill.png)

### **Замостить изображение как текстуру**

Если необходимо задать замощённое изображение в качестве текстуры и настроить поведение замощения, можно использовать следующие методы класса [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) :

- [setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode): задаёт режим заливки изображения — `Tile` или `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileAlignment): определяет выравнивание плиток внутри фигуры.
- [setTileFlip](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileFlip): управляет горизонтальным, вертикальным или двойным отражением плитки.
- [setTileOffsetX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetX): задаёт горизонтальное смещение плитки (в пунктах) от начала фигуры.
- [setTileOffsetY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetY): задаёт вертикальное смещение плитки (в пунктах) от начала фигуры.
- [setTileScaleX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleX): определяет горизонтальный масштаб плитки в процентах.
- [setTileScaleY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleY): определяет вертикальный масштаб плитки в процентах.

Следующий пример кода показывает, как добавить прямоугольную фигуру с замощённой заливкой и настроить параметры плитки:

```php
// Создайте экземпляр класса Presentation, представляющего файл презентации.
$presentation = new Presentation();
try {
    // Получите первый слайд.
    $firstSlide = $presentation->getSlides()->get_Item(0);

    // Добавьте автофигуру прямоугольника.
    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

    // Задайте тип заливки фигуры как Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Загрузите изображение и добавьте его в ресурсы презентации.
    $sourceImage = Images::fromFile("lotus.png");
    $presentationImage = $presentation->getImages()->addImage($sourceImage);
    $sourceImage->dispose();

    // Назначьте изображение фигуре.
    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);

    // Настройте режим заливки изображением и свойства замощения.
    $pictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $pictureFillFormat->setTileOffsetX(-32);
    $pictureFillFormat->setTileOffsetY(-32);
    $pictureFillFormat->setTileScaleX(50);
    $pictureFillFormat->setTileScaleY(50);
    $pictureFillFormat->setTileAlignment(RectangleAlignment::BottomRight);
    $pictureFillFormat->setTileFlip(TileFlip::FlipBoth);

    // Сохраните файл PPTX на диск.
    $presentation->save("tile.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат:

![Параметры замощения](tile-options.png)

## **Заливка сплошным цветом**

В PowerPoint заливка сплошным цветом — это параметр форматирования, заполняющий фигуру одним однородным цветом. Этот простой фон применяется без градиентов, текстур или шаблонов.

Чтобы применить сплошную заливку к фигуре с помощью Aspose.Slides, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) на слайд.
1. Установите [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) фигуры в `Solid`.
1. Присвойте фигуре желаемый цвет заливки.
1. Сохраните изменённую презентацию как файл PPTX.

Следующий PHP‑код демонстрирует, как применить сплошную заливку к прямоугольнику в PowerPoint‑слайде:

```php
// Создайте экземпляр класса Presentation, представляющего файл презентации.
$presentation = new Presentation();
try {
    // Получите первый слайд.
    $slide = $presentation->getSlides()->get_Item(0);

    // Добавьте автофигуру типа Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Установите тип заливки Solid.
    $shape->getFillFormat()->setFillType(FillType::Solid);

    // Задайте цвет заливки.
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    // Сохраните файл PPTX на диск.
    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат:

![Фигура со сплошной заливкой цветом](solid-color-fill.png)

## **Установить прозрачность**

В PowerPoint, когда вы применяете сплошную заливку, градиент, изображение или текстуру к фигурам, можно также задать уровень прозрачности, контролирующий непрозрачность заливки. Более высокий уровень прозрачности делает фигуру более просвечивающей, позволяя фону или подлежащим объектам частично просвечивать.

Aspose.Slides позволяет задать уровень прозрачности, изменяя альфа‑компонент в цвете, используемом для заливки. Как это сделать:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) на слайд.
1. Установите [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) в `Solid`.
1. Используйте `Color` для определения цвета с прозрачностью (компонент `alpha` управляет прозрачностью).
1. Сохраните презентацию.

Следующий PHP‑код демонстрирует, как задать прозрачный цвет заливки для прямоугольника:

```php
// Создайте экземпляр класса Presentation, представляющего файл презентации.
$presentation = new Presentation();
try {
    // Получите первый слайд.
    $slide = $presentation->getSlides()->get_Item(0);

    // Добавьте автофигуру сплошного прямоугольника.
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Добавьте автофигуру прозрачного прямоугольника поверх сплошного.
    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", 255, 255, 0, 204));

    // Сохраните файл PPTX на диск.
    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат:

![Прозрачная фигура](shape-transparency.png)

## **Поворот фигур**

Aspose.Slides позволяет вращать фигуры в презентациях PowerPoint. Это может быть полезно при размещении визуальных элементов с определённым выравниванием или дизайнерскими требованиями.

Чтобы повернуть фигуру на слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) на слайд.
1. Установите свойство вращения фигуры в нужный угол.
1. Сохраните презентацию.

Следующий PHP‑код демонстрирует, как повернуть фигуру на 5 градусов:

```php
// Создайте экземпляр класса Presentation, который представляет файл презентации.
$presentation = new Presentation();
try {
    // Получите первый слайд.
    $slide = $presentation->getSlides()->get_Item(0);

    // Добавьте автофигуру типа Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Поверните фигуру на 5 градусов.
    $shape->setRotation(5);

    // Сохраните файл PPTX на диск.
    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат:

![Поворот фигуры](shape-rotation.png)

## **Добавить 3D-эффекты фаски**

Aspose.Slides позволяет применять 3D-эффекты фаски к фигурам, настраивая их свойства [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/) .

Чтобы добавить 3D-эффекты фаски к фигуре, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) на слайд.
1. Настройте [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/) фигуры, задав параметры фаски.
1. Сохраните презентацию.

Следующий PHP‑код показывает, как применить 3D-эффекты фаски к фигуре:

```php
// Создайте экземпляр класса Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Добавьте фигуру на слайд.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $shape->getLineFormat()->setWidth(2.0);

    // Установите свойства ThreeDFormat фигуры.
    $shape->getThreeDFormat()->setDepth(4);
    $shape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $shape->getThreeDFormat()->getBevelTop()->setHeight(6);
    $shape->getThreeDFormat()->getBevelTop()->setWidth(6);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::ThreePt);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);

    // Сохраните презентацию как файл PPTX.
    $presentation->save("3D_bevel_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат:

![3D-эффект фаски](3D-bevel-effect.png)

## **Добавить 3D-эффекты вращения**

Aspose.Slides позволяет применять 3D-эффекты вращения к фигурам, настраивая их свойства [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/) .

Чтобы применить 3D-вращение к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) на слайд.
1. Используйте [setCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setCameraType) и [setLightType](https://reference.aspose.com/slides/php-java/aspose.slides/lightrig/#setLightType) для задания 3D‑вращения.
1. Сохраните презентацию.

Следующий PHP‑код демонстрирует, как применить 3D-эффекты вращения к фигуре:

```php
// Создайте экземпляр класса Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $autoShape->getTextFrame()->setText("Hello, Aspose!");

    $autoShape->getThreeDFormat()->setDepth(6);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(40, 35, 20);
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);

    // Сохраните презентацию как файл PPTX.
    $presentation->save("3D_rotation_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат:

![3D-эффект вращения](3D-rotation-effect.png)

## **Контроль черно-белой отрисовки фигур**

Метод [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setBlackWhiteMode) указывает, как отдельная фигура будет отрисовываться, когда презентация отображается или обрабатывается в черно-белом режиме. Он сам по себе не включает черно-белый режим и не меняет заливку, контур или другие параметры форматирования в обычном цветном режиме.

Используйте значение из класса [BlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/blackwhitemode/) для выбора нужного поведения. Например, `Automatic` позволяет приложению выбора выполнить конверсию, `Gray` и `LightGray` используют оттенки серого, `BlackWhite` использует только чёрный и белый, `Black` и `White` принудительно задают один цвет, `Color` сохраняет обычные цвета, а `Hidden` исключает фигуру в черно-белом режиме. `NotDefined` означает, что режим на уровне фигуры не назначен.

Следующий PHP‑код создаёт цветную фигуру и делает её серой в режиме черно‑белого отображения:

```php
use aspose\slides\BlackWhiteMode;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $orange = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($orange);

    // Сохраните оранжевую заливку в цветном режиме, но отображайте фигуру в сером цвете в режиме черно-белого.
    $shape->setBlackWhiteMode(BlackWhiteMode::Gray);

    $presentation->save("shape_black_white_mode.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

В обычном цветном режиме прямоугольник сохраняет оранжевую заливку. В рабочем процессе черно‑белого отображения он использует серый цвет, потому что его режим установлен в `Gray`. Это позволяет сохранять полноцветный слайд, одновременно определяя отдельный вид для печати, предпросмотра или других процессов, учитывающих настройки черно‑белого отображения презентации.

## **Сброс форматирования**

Следующий Java‑код показывает, как сбросить форматирование слайда и вернуть положение, размер и параметры всех фигур‑заполнителей на [LayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/) к их значениям по умолчанию:

```php
$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        // Сбросить каждую фигуру на слайде, у которой есть заполнитель в шаблоне.
        $slide->reset();
    }
    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Вопросы и ответы**

**Влияет ли форматирование фигур на окончательный размер файла презентации?**

Только незначительно. Встроенные изображения и медиа‑файлы занимают большую часть места, а параметры фигур, такие как цвета, эффекты и градиенты, хранятся как метаданные и практически не увеличивают размер.

**Как обнаружить фигуры на слайде, имеющие идентичное форматирование, чтобы их сгруппировать?**

Сравните ключевые свойства форматирования каждой фигуры — заполнение, контур и параметры эффектов. Если все соответствующие значения совпадают, рассматривайте их стили как одинаковые и логически группируйте такие фигуры, что упрощает дальнейшее управление стилями.

**Можно ли сохранить набор пользовательских стилей фигур в отдельный файл для повторного использования в других презентациях?**

Да. Сохраните образцы фигур с нужными стилями в шаблонный набор слайдов или файл шаблона .POTX. При создании новой презентации откройте шаблон, клонируйте необходимые стилизованные фигуры и снова примените их форматирование там, где требуется.