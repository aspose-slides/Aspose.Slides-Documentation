---
title: Форматирование фигур PowerPoint в PHP
linktitle: Форматирование фигур
type: docs
weight: 20
url: /ru/php-java/shape-formatting/
keywords:
- формат фигуры
- формат линии
- эффект эскиза
- эскиз линии фигуры
- форматировать стиль соединения
- градиентная заливка
- заливка узором
- заливка изображением
- текстурная заливка
- заливка сплошным цветом
- прозрачность фигуры
- чёрно-белая визуализация фигуры
- визуализация фигуры в градациях серого
- повернуть фигуру
- 3D‑эффект фаски
- 3D‑поворотный эффект
- сброс форматирования
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как форматировать фигуры PowerPoint в PHP с помощью Aspose.Slides — задавайте стили заливки, линий и эффектов для файлов PPT, PPTX и ODP с точностью и полной свободой управления."
---
## **Введение**

В PowerPoint вы можете добавлять фигуры на слайды. Поскольку фигуры состоят из линий, их можно форматировать, изменяя или применяя эффекты к контурам. Кроме того, фигуры можно форматировать, указывая параметры, контролирующие заполнение их внутренней части.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for PHP via Java предоставляет классы и методы, позволяющие форматировать фигуры с использованием тех же параметров, что доступны в PowerPoint.

## **Форматирование линий**

С помощью Aspose.Slides вы можете задать пользовательский стиль линии для фигуры. Ниже представлены шаги выполнения процедуры:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) на слайд.
1. Установите [line style](https://reference.aspose.com/slides/ru/php-java/aspose.slides/linestyle/) для фигуры.
1. Установите толщину линии.
1. Установите [dash style](https://reference.aspose.com/slides/ru/php-java/aspose.slides/linedashstyle/) линии.
1. Установите цвет линии для фигуры.
1. Сохраните изменённую презентацию в файл PPTX.

Следующий PHP‑код демонстрирует, как отформатировать прямоугольный `AutoShape`:

```php
// Создайте экземпляр класса Presentation, представляющего файл презентации.
$presentation = new Presentation();
try {
    // Получите первый слайд.
    $slide = $presentation->getSlides()->get_Item(0);

    // Добавьте автофигуру типа Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

    // Установите цвет заливки для прямоугольной фигуры.
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    // Примените форматирование к линиям прямоугольника.
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);

    // Установите цвет линии прямоугольника.
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

## **Применение эффектов эскиза к линиям фигуры**

Эффект эскиза делает линию фигуры выглядящей нарисованной от руки. Используйте [Shape.getLineFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/) для доступа к настройкам линии, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/lineformat/) для доступа к настройкам эскиза и [SketchFormat.setSketchType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sketchformat/) для выбора значения из перечисления [LineSketchType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/linesketchtype/).

Следующий PHP‑код показывает, как применить эффект [LineSketchType.Curved](https://reference.aspose.com/slides/ru/php-java/aspose.slides/linesketchtype/) , прочитать явно присвоенное значение и удалить эффект с помощью [LineSketchType.None](https://reference.aspose.com/slides/ru/php-java/aspose.slides/linesketchtype/) :

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

    // Получите формат линии фигуры и её формат эскиза.
    $sketchFormat = $shape->getLineFormat()->getSketchFormat();

    // Примените эффект эскиза.
    $sketchFormat->setSketchType(LineSketchType::Curved);

    // Прочитайте эффект эскиза, назначенный непосредственно фигуре.
    $explicitSketchType = $sketchFormat->getSketchType();
    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;

    // Уберите эффект эскиза.
    $sketchFormat->setSketchType(LineSketchType::None);
} finally {
    $presentation->dispose();
}
```

Значение, возвращаемое [SketchFormat.getSketchType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sketchformat/), представляет настройку, назначенную непосредственно фигуре. Если форматирование линии может наследоваться от темы, мастер‑слайда или слайда‑разметки, используйте [LineFormat.getEffective](https://reference.aspose.com/slides/ru/php-java/aspose.slides/lineformat/), получите метод `getSketchFormat` возвращённого объекта и прочитайте его значение `getSketchType`. Эффективное значение отражает форматирование, которое действительно применяется после разрешения наследования:

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

Доступны три варианта типа соединения:

* Скруглённый
* Угловой
* Скошенный

По умолчанию PowerPoint соединяет две линии под углом (например, в углу фигуры) используя настройку **Round**. Однако при рисовании фигуры с острыми углами вы можете предпочесть параметр **Miter**.

![Стиль соединения в презентации](join-style-powerpoint.png)

Следующий PHP‑код демонстрирует, как три прямоугольника (как показано на изображении выше) были созданы с использованием настроек типа соединения Miter, Bevel и Round:

```php
// Создайте экземпляр класса Presentation, представляющего файл презентации.
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

    // Установите ширину линии.
    $shape1->getLineFormat()->setWidth(15);
    $shape2->getLineFormat()->setWidth(15);
    $shape3->getLineFormat()->setWidth(15);

    // Установите цвет линии каждого прямоугольника.
    $shape1->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape3->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // Установите стиль соединения.
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

В PowerPoint градиентная заливка — это параметр форматирования, позволяющий применять к фигуре непрерывный переход цветов. Например, можно задать два и более цветов так, чтобы один постепенно переходил в другой.

Вот как применить градиентную заливку к фигуре с помощью Aspose.Slides:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) на слайд.
1. Установите для фигуры [FillType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/filltype/) значение `Gradient`.
1. Добавьте два желаемых цвета с определёнными позициями, используя методы `add` коллекции остановок градиента, доступные в классе [GradientFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/gradientformat/).
1. Сохраните изменённую презентацию в файл PPTX.

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

    // Установите направление градиента.
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

Эллипс с градиентной заливкой:

![Эллипс с градиентной заливкой](gradient-fill.png)

## **Заливка узором**

В PowerPoint заливка узором — это параметр форматирования, позволяющий применять к фигуре двухцветный рисунок, например точки, полосы, перекрёстные штрихи или шахматную решётку. Вы можете выбрать пользовательские цвета для переднего и заднего плана узора.

Aspose.Slides предоставляет более 45 предопределённых стилей узоров, которые можно применять к фигурам для улучшения визуального восприятия презентаций. Даже после выбора предопределённого узора вы можете задать точные цвета, которые он будет использовать.

Вот как применить заливку узором к фигуре с помощью Aspose.Slides:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) на слайд.
1. Установите [FillType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/filltype/) фигуры в `Pattern`.
1. Выберите стиль узора из предопределённых вариантов.
1. Установите [Background Color](https://reference.aspose.com/slides/ru/php-java/aspose.slides/patternformat/#getBackColor) узора.
1. Установите [Foreground Color](https://reference.aspose.com/slides/ru/php-java/aspose.slides/patternformat/#getForeColor) узора.
1. Сохраните изменённую презентацию в файл PPTX.

```php
// Создайте экземпляр класса Presentation, представляющего файл презентации.
$presentation = new Presentation();
try {
    // Получите первый слайд.
    $slide = $presentation->getSlides()->get_Item(0);

    // Добавьте автофигуру типа Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Установите тип заливки в Pattern.
    $shape->getFillFormat()->setFillType(FillType::Pattern);

    // Установите стиль узора.
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);

    // Установите фоновые и передние цвета узора.
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    // Сохраните файл PPTX на диск.
    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Прямоугольник с заливкой узором:

![Прямоугольник с заливкой узором](pattern-fill.png)

## **Заливка изображением**

В PowerPoint заливка изображением — это параметр форматирования, позволяющий вставить изображение внутрь фигуры, фактически используя его в качестве фона фигуры.

Вот как применить заливку изображением к фигуре с помощью Aspose.Slides:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) на слайд.
1. Установите [FillType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/filltype/) фигуры в `Picture`.
1. Установите режим заливки изображения в `Tile` (или другой предпочтительный режим).
1. Создайте объект [PPImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/ppimage/) из изображения, которое хотите использовать.
1. Передайте изображение в метод `SlidesPicture.setImage`.
1. Сохраните изменённую презентацию в файл PPTX.

![Изображение лотоса](lotus.png)

```php
// Создайте экземпляр класса Presentation, представляющего файл презентации.
$presentation = new Presentation();
try {
    // Получите первый слайд.
    $slide = $presentation->getSlides()->get_Item(0);

    // Добавьте автофигуру типа Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

    // Установите тип заливки в Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Установите режим заливки изображением.
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    // Загрузите изображение и добавьте его в ресурсы презентации.
    $image = Images::fromFile("lotus.png");
    $picture = $presentation->getImages()->addImage($image);
    $image->dispose();

    // Установите изображение.
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);

    // Сохраните файл PPTX на диск.
    $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Фигура с заливкой изображением:

![Фигура с заливкой изображением](picture-fill.png)

### **Текстурирование плиткой изображения**

Если вы хотите установить изображение плиткой в качестве текстуры и настроить поведение плитки, можете использовать следующие методы класса [PictureFillFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/picturefillformat/) :

- [setPictureFillMode](https://reference.aspose.com/slides/ru/php-java/aspose.slides/picturefillformat/#setPictureFillMode): Задаёт режим заливки изображения — `Tile` или `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/ru/php-java/aspose.slides/picturefillformat/#setTileAlignment): Указывает выравнивание плиток внутри фигуры.
- [setTileFlip](https://reference.aspose.com/slides/ru/php-java/aspose.slides/picturefillformat/#setTileFlip): Управляет тем, будет ли плитка отражена по горизонтали, вертикали или обеим осям.
- [setTileOffsetX](https://reference.aspose.com/slides/ru/php-java/aspose.slides/picturefillformat/#setTileOffsetX): Задаёт горизонтальное смещение плитки (в пунктах) от начала фигуры.
- [setTileOffsetY](https://reference.aspose.com/slides/ru/php-java/aspose.slides/picturefillformat/#setTileOffsetY): Задаёт вертикальное смещение плитки (в пунктах) от начала фигуры.
- [setTileScaleX](https://reference.aspose.com/slides/ru/php-java/aspose.slides/picturefillformat/#setTileScaleX): Определяет горизонтальный масштаб плитки в процентах.
- [setTileScaleY](https://reference.aspose.com/slides/ru/php-java/aspose.slides/picturefillformat/#setTileScaleY): Определяет вертикальный масштаб плитки в процентах.

Следующий пример кода показывает, как добавить прямоугольную фигуру с заливкой изображением‑плиткой и настроить параметры плитки:

```php
// Создайте экземпляр класса Presentation, представляющего файл презентации.
$presentation = new Presentation();
try {
    // Получите первый слайд.
    $firstSlide = $presentation->getSlides()->get_Item(0);

    // Добавьте автофигуру прямоугольника.
    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

    // Установите тип заливки фигуры в Picture.
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

Параметры плитки:

![Параметры плитки](tile-options.png)

## **Однородная заливка цветом**

В PowerPoint однородная заливка цветом — это параметр форматирования, который заполняет фигуру одним равномерным цветом. Этот простой цвет фона применяется без градиентов, текстур или узоров.

Чтобы применить однородную заливку цветом к фигуре с помощью Aspose.Slides, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) на слайд.
1. Установите [FillType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/filltype/) фигуры в `Solid`.
1. Назначьте желаемый цвет заливки фигуре.
1. Сохраните изменённую презентацию в файл PPTX.

```php
// Создайте экземпляр класса Presentation, представляющего файл презентации.
$presentation = new Presentation();
try {
    // Получите первый слайд.
    $slide = $presentation->getSlides()->get_Item(0);

    // Добавьте автофигуру типа Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Установите тип заливки в Solid.
    $shape->getFillFormat()->setFillType(FillType::Solid);

    // Установите цвет заливки.
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    // Сохраните файл PPTX на диск.
    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Фигура с однородной заливкой цветом:

![Фигура с однородной заливкой цветом](solid-color-fill.png)

## **Установка прозрачности**

В PowerPoint при применении к фигурам однородной заливки, градиента, изображения или текстуры можно также задать уровень прозрачности, контролирующий непрозрачность заливки. Чем выше значение прозрачности, тем более прозрачной будет фигура, позволяя фону или находящимся ниже объектам частично просвечивать.

Aspose.Slides позволяет задать уровень прозрачности, корректируя альфа‑компонент цвета, используемого для заливки. Вот как это сделать:

```php
// Создайте экземпляр класса Presentation, представляющего файл презентации.
$presentation = new Presentation();
try {
    // Получите первый слайд.
    $slide = $presentation->getSlides()->get_Item(0);

    // Добавьте сплошную автофигуру прямоугольника.
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Добавьте прозрачную автофигуру прямоугольника поверх сплошной фигуры.
    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", 255, 255, 0, 204));

    // Сохраните файл PPTX на диск.
    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Прозрачная фигура:

![Прозрачная фигура](shape-transparency.png)

## **Поворот фигур**

Aspose.Slides позволяет вращать фигуры в презентациях PowerPoint. Это может быть полезно при размещении визуальных элементов с определёнными требованиями к выравниванию или дизайну.

Чтобы повернуть фигуру на слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) на слайд.
1. Установите свойство вращения фигуры на требуемый угол.
1. Сохраните презентацию.

```php
// Создайте экземпляр класса Presentation, представляющего файл презентации.
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

Поворот фигуры:

![Поворот фигуры](shape-rotation.png)

## **Добавление 3D‑эффекта фаски**

С помощью Aspose.Slides можно применять к фигурам 3D‑эффекты фаски, настраивая их свойства [ThreeDFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/threedformat/).

Чтобы добавить 3D‑эффекты фаски к фигуре, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) на слайд.
1. Настройте [ThreeDFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/threedformat/) фигуры, задав параметры фаски.
1. Сохраните презентацию.

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

    // Сохраните презентацию в файл PPTX.
    $presentation->save("3D_bevel_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Эффект 3D‑фаски:

![Эффект 3D‑фаски](3D-bevel-effect.png)

## **Добавление 3D‑поворотных эффектов**

С помощью Aspose.Slides можно применять к фигурам 3D‑поворотные эффекты, настраивая их свойства [ThreeDFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/threedformat/).

Чтобы применить 3D‑поворот к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) на слайд.
1. Используйте [setCameraType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/camera/#setCameraType) и [setLightType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/lightrig/#setLightType) для определения 3D‑поворота.
1. Сохраните презентацию.

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

    // Сохраните презентацию в файл PPTX.
    $presentation->save("3D_rotation_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Эффект 3D‑поворота:

![Эффект 3D‑поворота](3D-rotation-effect.png)

## **Управление чёрно‑белой визуализацией фигур**

[Shape::setBlackWhiteMode](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/#setBlackWhiteMode) определяет, как отдельная фигура отображается, когда презентация просматривается или обрабатывается в чёрно‑белом режиме. Этот метод сам по себе не включает чёрно‑белый режим и не меняет заливку, линию или другие параметры форматирования фигуры в обычном цветовом режиме.

Используйте значение из класса [BlackWhiteMode] для выбора нужного поведения. Например, `Automatic` позволяет приложению выбора преобразования, `Gray` и `LightGray` используют серый цвет, `BlackWhite` выводит только чёрный и белый, `Black` и `White` принудительно задают один цвет, `Color` сохраняет обычные цвета, а `Hidden` исключает фигуру в чёрно‑белом режиме. `NotDefined` означает, что режим для фигуры не установлен.

Следующий PHP‑код создаёт цветную фигуру и делает её серой в чёрно‑белом режиме отображения:

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

    // Сохраните оранжевую заливку в цветном режиме, но отображайте фигуру в сером цвете в черно-белом режиме.
    $shape->setBlackWhiteMode(BlackWhiteMode::Gray);

    $presentation->save("shape_black_white_mode.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

В обычном цветовом режиме прямоугольник сохраняет оранжевую заливку. В чёрно‑белом режиме он отображается серым, поскольку его режим установлен в `Gray`. Это позволяет сохранять полноцветный слайд, определяя при этом отдельный вид для печати, предварительного просмотра или иных процессов, учитывающих настройки чёрно‑белого отображения презентации.

## **Сброс форматирования**

Следующий Java‑код показывает, как сбросить форматирование слайда и вернуть положение, размер и форматирование всех фигур‑заполнителей на [LayoutSlide](https://reference.aspose.com/slides/ru/php-java/aspose.slides/layoutslide/) к их настройкам по умолчанию:

```php
$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        // Сбросить каждую фигуру на слайде, у которой есть заполнитель в макете.
        $slide->reset();
    }
    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Влияет ли форматирование фигур на конечный размер файла презентации?**

Только незначительно. Встраиваемые изображения и медиа занимают большинство места в файле, тогда как параметры фигур, такие как цвета, эффекты и градиенты, хранятся как метаданные и практически не увеличивают размер.

**Как определить фигуры на слайде, имеющие одинаковое форматирование, чтобы их сгруппировать?**

Сравните ключевые свойства форматирования каждой фигуры — параметры заливки, линии и эффекты. Если все соответствующие значения совпадают, рассматривайте их стили как идентичные и логически группируйте такие фигуры, что упрощает последующее управление стилями.

**Можно ли сохранить набор пользовательских стилей фигур в отдельный файл для повторного использования в других презентациях?**

Да. Сохраните образцы фигур с нужными стилями в шаблон презентации или в файл шаблона .POTX. При создании новой презентации откройте шаблон, клонируйте нужные стилизованные фигуры и применяйте их форматирование там, где требуется.