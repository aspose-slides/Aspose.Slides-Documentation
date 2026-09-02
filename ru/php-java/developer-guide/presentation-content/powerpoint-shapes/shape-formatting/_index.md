---
title: "Форматирование фигур PowerPoint в PHP"
linktitle: "Форматирование фигур"
type: docs
weight: 20
url: /ru/php-java/shape-formatting/
keywords:
- форматировать фигуру
- форматировать линию
- эффект скетча
- линия фигуры в стиле скетч
- форматировать стиль соединения
- градиентная заливка
- заливка узором
- заливка изображением
- заливка текстурой
- заливка сплошным цветом
- прозрачность фигуры
- повернуть фигуру
- 3D-эффект фаски
- 3D-эффект вращения
- сбросить форматирование
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как форматировать фигуры PowerPoint в PHP с помощью Aspose.Slides — задавайте стили заливки, линий и эффектов для файлов PPT, PPTX и ODP с точностью и полным контролем."
---
## **Введение**

В PowerPoint вы можете добавлять фигуры на слайды. Поскольку фигуры состоят из линий, их можно форматировать, изменяя или применяя эффекты к их контурам. Кроме того, вы можете форматировать фигуры, задавая параметры, контролирующие заполнение их внутренних областей.

![формат-фигуры-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for PHP via Java предоставляет классы и методы, позволяющие форматировать фигуры с использованием тех же параметров, которые доступны в PowerPoint.

## **Форматирование линий**

С помощью Aspose.Slides вы можете задать пользовательский стиль линии для фигуры. Ниже перечислены шаги процедуры:

1. Создайте экземпляр класса [Презентация](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) на слайд.
1. Установите [стиль линии](https://reference.aspose.com/slides/ru/php-java/aspose.slides/linestyle/) фигуры.
1. Установите ширину линии.
1. Установите [стиль штрихов](https://reference.aspose.com/slides/ru/php-java/aspose.slides/linedashstyle/) линии.
1. Установите цвет линии для фигуры.
1. Сохраните изменённую презентацию в файл PPTX.
1. Сохраните изменённую презентацию в файл PPTX.

Следующий код PHP демонстрирует, как отформатировать прямоугольный `AutoShape`:

```php
// Создайте экземпляр класса Presentation, представляющего файл презентации.
$presentation = new Presentation();
try {
    // Получить первый слайд.
    $slide = $presentation->getSlides()->get_Item(0);

    // Добавить автофигуру типа Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

    // Установить цвет заливки для прямоугольной фигуры.
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    // Применить форматирование к линиям прямоугольника.
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);

    // Установить цвет линии прямоугольника.
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // Сохранить файл PPTX на диск.
    $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат:

![Отформатированные линии в презентации](formatted-lines.png)

## **Применение эффектов скетча к линиям фигур**

Эффект скетча делает линию фигуры выглядящей нарисованной от руки. Используйте [Shape.getLineFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/) для доступа к параметрам линии, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/lineformat/) для доступа к настройкам скетча и [SketchFormat.setSketchType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sketchformat/) для выбора значения из перечисления [LineSketchType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/linesketchtype/).

Следующий код PHP показывает, как применить эффект [LineSketchType.Curved](https://reference.aspose.com/slides/ru/php-java/aspose.slides/linesketchtype/), прочитать явно присвоенное значение и удалить эффект с помощью [LineSketchType.None](https://reference.aspose.com/slides/ru/php-java/aspose.slides/linesketchtype/):

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

    // Доступ к формату линии фигуры и её формату скетча.
    $sketchFormat = $shape->getLineFormat()->getSketchFormat();

    // Применить эффект скетча.
    $sketchFormat->setSketchType(LineSketchType::Curved);

    // Прочитать эффект скетча, назначенный непосредственно фигуре.
    $explicitSketchType = $sketchFormat->getSketchType();
    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;

    // Удалить эффект скетча.
    $sketchFormat->setSketchType(LineSketchType::None);
} finally {
    $presentation->dispose();
}
```

Значение, возвращаемое [SketchFormat.getSketchType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sketchformat/), представляет параметр, назначенный непосредственно фигуре. Если форматирование линии может наследоваться от темы, шаблона слайда или макета, используйте [LineFormat.getEffective](https://reference.aspose.com/slides/ru/php-java/aspose.slides/lineformat/), получите метод `getSketchFormat` возвращённого объекта и прочитайте его значение `getSketchType`. Эффективное значение отражает форматирование, которое действительно применяется после разрешения наследования:

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

Вот три варианта типа соединения:

* Округлый
* Срез
* Фаска

По умолчанию, когда PowerPoint соединяет две линии под углом (например, в углу фигуры), он использует параметр **Округление**. Однако, если вы рисуете фигуру с острыми углами, вам может подойти параметр **Срез**.

![Стиль соединения в презентации](join-style-powerpoint.png)

Следующий код PHP демонстрирует, как три прямоугольника (как показано на изображении выше) были созданы с использованием настроек типов соединения Miter, Bevel и Round:

```php
// Создайте экземпляр класса Presentation, представляющего файл презентации.
$presentation = new Presentation();
try {
    // Получить первый слайд.
    $slide = $presentation->getSlides()->get_Item(0);

    // Добавить три автофигуры типа Rectangle.
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    // Установить цвет заливки для каждой прямоугольной фигуры.
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

    // Установить толщину линии.
    $shape1->getLineFormat()->setWidth(15);
    $shape2->getLineFormat()->setWidth(15);
    $shape3->getLineFormat()->setWidth(15);

    // Установить цвет линии для каждого прямоугольника.
    $shape1->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape3->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // Установить стиль соединения.
    $shape1->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
    $shape2->getLineFormat()->setJoinStyle(LineJoinStyle::Bevel);
    $shape3->getLineFormat()->setJoinStyle(LineJoinStyle::Round);

    // Добавить текст к каждому прямоугольнику.
    $shape1->getTextFrame()->setText("Miter Join Style");
    $shape2->getTextFrame()->setText("Bevel Join Style");
    $shape3->getTextFrame()->setText("Round Join Style");

    // Сохранить файл PPTX на диск.
    $presentation->save("join_styles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Градиентная заливка**

В PowerPoint градиентная заливка — это параметр форматирования, позволяющий применять к фигуре плавный переход цветов. Например, можно применить два и более цветов так, чтобы один постепенно переходил в другой.

Ниже показано, как применить градиентную заливку к фигуре с помощью Aspose.Slides:

1. Создайте экземпляр класса [Презентация](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) на слайд.
1. Установите свойство [FillType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/filltype/) фигуры в `Gradient`.
1. Добавьте два выбранных вами цвета с заданными позициями, используя методы `add` коллекции остановок градиента, предоставляемой классом [GradientFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/gradientformat/).
1. Сохраните изменённую презентацию в файл PPTX.

```php
// Создайте экземпляр класса Presentation, представляющего файл презентации.
$presentation = new Presentation();
try {
    // Получить первый слайд.
    $slide = $presentation->getSlides()->get_Item(0);

    // Добавить автофигуру типа Ellipse.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

    // Применить градиентное форматирование к эллипсу.
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);

    // Установить направление градиента.
    $shape->getFillFormat()->getGradientFormat()->setGradientDirection(GradientDirection::FromCorner2);

    // Добавить две градиентные остановки.
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0, PresetColor::Red);

    // Сохранить файл PPTX на диск.
    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Эллипс с градиентной заливкой](gradient-fill.png)

## **Заливка узором**

В PowerPoint заливка узором — это параметр форматирования, позволяющий применять к фигуре двухцветный дизайн — например, точки, полосы, перекрёстные штрихи или клетки. Вы можете выбрать пользовательские цвета для переднего плана и фона узора.

Aspose.Slides предоставляет более 45 предопределённых стилей узоров, которые вы можете применять к фигурам для улучшения визуальной привлекательности ваших презентаций. Даже после выбора предопределённого узора вы всё равно можете задать точные цвета, которые он будет использовать.

Ниже показано, как применить заливку узором к фигуре с помощью Aspose.Slides:

1. Создайте экземпляр класса [Презентация](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) на слайд.
1. Установите свойство [FillType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/filltype/) фигуры в `Pattern`.
1. Выберите стиль узора из предопределённых вариантов.
1. Установите [Цвет фона](https://reference.aspose.com/slides/ru/php-java/aspose.slides/patternformat/#getBackColor) узора.
1. Установите [Цвет переднего плана](https://reference.aspose.com/slides/ru/php-java/aspose.slides/patternformat/#getForeColor) узора.
1. Сохраните изменённую презентацию в файл PPTX.

```php
    // Создайте экземпляр класса Presentation, представляющего файл презентации.
    $presentation = new Presentation();
    try {
        // Получить первый слайд.
        $slide = $presentation->getSlides()->get_Item(0);

        // Добавить автофигуру типа Rectangle.
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

        // Установить тип заливки как Pattern.
        $shape->getFillFormat()->setFillType(FillType::Pattern);

        // Установить стиль узора.
        $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);

        // Установить цвета фона и переднего плана узора.
        $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
        $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

        // Сохранить файл PPTX на диск.
        $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
```

![Прямоугольник с узорной заливкой](pattern-fill.png)

## **Заливка изображением**

В PowerPoint заливка изображением — это параметр форматирования, позволяющий вставить изображение внутрь фигуры, effectively используя изображение в качестве фона фигуры.

Ниже показано, как использовать Aspose.Slides для применения заливки изображением к фигуре:

1. Создайте экземпляр класса [Презентация](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) на слайд.
1. Установите свойство [FillType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/filltype/) фигуры в `Picture`.
1. Установите режим заливки изображения в `Tile` (или другой предпочтительный режим).
1. Создайте объект [PPImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/ppimage/) из изображения, которое хотите использовать.
1. Передайте изображение в метод `SlidesPicture.setImage`.
1. Сохраните изменённую презентацию в файл PPTX.

Предположим, у нас есть файл "lotus.png" со следующим изображением:

![Изображение лотоса](lotus.png)

```php
// Создайте экземпляр класса Presentation, представляющего файл презентации.
$presentation = new Presentation();
try {
    // Получить первый слайд.
    $slide = $presentation->getSlides()->get_Item(0);

    // Добавить автофигуру типа Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

    // Установить тип заливки как Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Установить режим заливки изображением.
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    // Загрузить изображение и добавить его в ресурсы презентации.
    $image = Images::fromFile("lotus.png");
    $picture = $presentation->getImages()->addImage($image);
    $image->dispose();

    // Установить изображение.
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);

    // Сохранить файл PPTX на диск.
    $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Фигура с заливкой изображением](picture-fill.png)

### **Повторяющееся изображение в качестве текстуры**

Если вы хотите задать повторяющееся изображение в качестве текстуры и настроить поведение повторения, вы можете использовать следующие методы класса [PictureFillFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/ru/php-java/aspose.slides/picturefillformat/#setPictureFillMode): Устанавливает режим заливки изображения — `Tile` или `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/ru/php-java/aspose.slides/picturefillformat/#setTileAlignment): Задает выравнивание плиток внутри фигуры.
- [setTileFlip](https://reference.aspose.com/slides/ru/php-java/aspose.slides/picturefillformat/#setTileFlip): Определяет, будет ли плитка отражена по горизонтали, вертикали или оба направления.
- [setTileOffsetX](https://reference.aspose.com/slides/ru/php-java/aspose.slides/picturefillformat/#setTileOffsetX): Устанавливает горизонтальное смещение плитки (в пунктах) от начала фигуры.
- [setTileOffsetY](https://reference.aspose.com/slides/ru/php-java/aspose.slides/picturefillformat/#setTileOffsetY): Устанавливает вертикальное смещение плитки (в пунктах) от начала фигуры.
- [setTileScaleX](https://reference.aspose.com/slides/ru/php-java/aspose.slides/picturefillformat/#setTileScaleX): Определяет горизонтальный масштаб плитки в процентах.
- [setTileScaleY](https://reference.aspose.com/slides/ru/php-java/aspose.slides/picturefillformat/#setTileScaleY): Определяет вертикальный масштаб плитки в процентах.

```php
// Создайте экземпляр класса Presentation, представляющего файл презентации.
$presentation = new Presentation();
try {
    // Получить первый слайд.
    $firstSlide = $presentation->getSlides()->get_Item(0);

    // Добавить автофигуру типа Rectangle.
    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

    // Установить тип заливки фигуры как Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Загрузить изображение и добавить его в ресурсы презентации.
    $sourceImage = Images::fromFile("lotus.png");
    $presentationImage = $presentation->getImages()->addImage($sourceImage);
    $sourceImage->dispose();

    // Присвоить изображение фигуре.
    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);

    // Настроить режим заливки изображением и параметры мозаики.
    $pictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $pictureFillFormat->setTileOffsetX(-32);
    $pictureFillFormat->setTileOffsetY(-32);
    $pictureFillFormat->setTileScaleX(50);
    $pictureFillFormat->setTileScaleY(50);
    $pictureFillFormat->setTileAlignment(RectangleAlignment::BottomRight);
    $pictureFillFormat->setTileFlip(TileFlip::FlipBoth);

    // Сохранить файл PPTX на диск.
    $presentation->save("tile.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Опции плитки](tile-options.png)

## **Заливка сплошным цветом**

В PowerPoint заливка сплошным цветом — это параметр форматирования, который заполняет фигуру одним однородным цветом. Этот простой фон применяется без каких‑либо градиентов, текстур или узоров.

Чтобы применить сплошную заливку к фигуре с помощью Aspose.Slides, выполните следующие шаги:

1. Создайте экземпляр класса [Презентация](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) на слайд.
1. Установите свойство [FillType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/filltype/) фигуры в `Solid`.
1. Укажите предпочтительный цвет заливки для фигуры.
1. Сохраните изменённую презентацию в файл PPTX.

```php
// Создайте экземпляр класса Presentation, представляющего файл презентации.
$presentation = new Presentation();
try {
    // Получить первый слайд.
    $slide = $presentation->getSlides()->get_Item(0);

    // Добавить автофигуру типа Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Установить тип заливки как Solid.
    $shape->getFillFormat()->setFillType(FillType::Solid);

    // Установить цвет заливки.
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    // Сохранить файл PPTX на диск.
    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Фигура со сплошной заливкой](solid-color-fill.png)

## **Установка прозрачности**

В PowerPoint, когда вы применяете сплошную заливку, градиент, изображение или текстуру к фигурам, вы также можете задать уровень прозрачности, контролирующий непрозрачность заливки. Более высокий уровень прозрачности делает фигуру более полупрозрачной, позволяя видеть фон или нижележащие объекты.

Aspose.Slides позволяет задать уровень прозрачности, изменяя значение альфа‑канала в цвете, используемом для заливки. Вот как это сделать:

1. Создайте экземпляр класса [Презентация](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) на слайд.
1. Установите [FillType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/filltype/) фигуры в `Solid`.
1. Используйте `Color` для определения цвета с прозрачностью (компонент `alpha` управляет прозрачностью).
1. Сохраните презентацию.

```php
// Создайте экземпляр класса Presentation, представляющего файл презентации.
$presentation = new Presentation();
try {
    // Получить первый слайд.
    $slide = $presentation->getSlides()->get_Item(0);

    // Добавить сплошную автофигуру прямоугольника.
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Добавить прозрачную автофигуру прямоугольника поверх сплошной фигуры.
    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", 255, 255, 0, 204));

    // Сохранить файл PPTX на диск.
    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Прозрачная фигура](shape-transparency.png)

## **Поворот фигур**

Aspose.Slides позволяет вращать фигуры в презентациях PowerPoint. Это может быть полезно при расположении визуальных элементов с определёнными требованиями к выравниванию или дизайну.

Чтобы повернуть фигуру на слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Презентация](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) на слайд.
1. Установите свойство вращения фигуры на нужный угол.
1. Сохраните презентацию.

```php
// Создайте экземпляр класса Presentation, представляющего файл презентации.
$presentation = new Presentation();
try {
    // Получить первый слайд.
    $slide = $presentation->getSlides()->get_Item(0);

    // Добавить автофигуру типа Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Повернуть фигуру на 5 градусов.
    $shape->setRotation(5);

    // Сохранить файл PPTX на диск.
    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Поворот фигуры](shape-rotation.png)

## **Добавление 3D-эффекта фаски**

Aspose.Slides позволяет применять 3D‑эффекты фаски к фигурам, настраивая их свойства [ThreeDFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/threedformat/).

Чтобы добавить 3D‑эффект фаски к фигуре, выполните следующие шаги:

1. Создайте экземпляр класса [Презентация](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) на слайд.
1. Настройте свойства [ThreeDFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/threedformat/) фигуры, чтобы задать параметры фаски.
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

![3D-эффект фаски](3D-bevel-effect.png)

## **Добавление 3D-эффектов вращения**

Aspose.Slides позволяет применять 3D‑вращения к фигурам, настраивая их свойства [ThreeDFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/threedformat/).

Чтобы применить 3D‑вращение к фигуре:

1. Создайте экземпляр класса [Презентация](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) на слайд.
1. Используйте [setCameraType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/camera/#setCameraType) и [setLightType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/lightrig/#setLightType) для определения 3D‑вращения.
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

![3D-эффект вращения](3D-rotation-effect.png)

## **Сброс форматирования**

Следующий код Java демонстрирует, как сбросить форматирование слайда и вернуть позицию, размер и форматирование всех фигур с заполнителями на [LayoutSlide](https://reference.aspose.com/slides/ru/php-java/aspose.slides/layoutslide/) к их значениям по умолчанию:

```php
$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        // Сбросить каждую фигуру на слайде, имеющую заполнитель в макете.
        $slide->reset();
    }
    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Влияет ли форматирование фигур на конечный размер файла презентации?**

Только минимально. Встроенные изображения и медиа‑файлы занимают большую часть места, тогда как параметры фигур, такие как цвета, эффекты и градиенты, хранятся как метаданные и практически не увеличивают размер файла.

**Как определить фигуры на слайде, имеющие одинаковое форматирование, чтобы их сгруппировать?**

Сравните ключевые свойства форматирования каждой фигуры — параметры заливки, линии и эффекты. Если все соответствующие значения совпадают, их стили можно считать идентичными и логически группировать такие фигуры, что упрощает дальнейшее управление стилем.

**Могу ли я сохранить набор пользовательских стилей фигур в отдельный файл для повторного использования в других презентациях?**

Да. Сохраните образцы фигур с требуемыми стилями в шаблонный набор слайдов или в файл шаблона .POTX. При создании новой презентации откройте шаблон, клонируйте нужные стилизованные фигуры и повторно примените их форматирование там, где это необходимо.