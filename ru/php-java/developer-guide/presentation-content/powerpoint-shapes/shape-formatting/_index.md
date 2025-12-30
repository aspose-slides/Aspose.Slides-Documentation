---
title: Форматировать фигуры PowerPoint в PHP
linktitle: Форматирование фигур
type: docs
weight: 20
url: /ru/php-java/shape-formatting/
keywords:
- форматировать фигуру
- форматировать линию
- форматировать стиль соединения
- градиентное заполнение
- заполнение узором
- заполнение изображением
- заполнение текстурой
- заполнение сплошным цветом
- прозрачность фигуры
- поворот фигуры
- 3d скос
- 3d поворот
- сброс форматирования
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как форматировать фигуры PowerPoint в PHP с помощью Aspose.Slides — задавайте стили заливки, контура и эффектов для файлов PPT, PPTX и ODP с точностью и полным контролем."
---

## **Обзор**

В PowerPoint вы можете добавлять фигуры на слайды. Поскольку фигуры состоят из линий, их можно форматировать, изменяя или применяя эффекты к контуру. Кроме того, вы можете форматировать фигуры, указывая настройки, которые контролируют заполнение их внутренней части.

![формат-формы-powerpoint](format-shape-powerpoint.png)

Aspose.Slides для PHP через Java предоставляет классы и методы, позволяющие форматировать фигуры с использованием тех же параметров, что и в PowerPoint.

## **Форматирование линий**

С помощью Aspose.Slides вы можете задать пользовательский стиль линии для фигуры. Ниже перечислены шаги процедуры:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) на слайд.
1. Установите [line style](https://reference.aspose.com/slides/php-java/aspose.slides/linestyle/) фигуры.
1. Установите ширину линии.
1. Установите [dash style](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/) линии.
1. Установите цвет линии для фигуры.
1. Сохраните изменённую презентацию в файл PPTX.

Ниже показан PHP‑код, демонстрирующий, как отформатировать прямоугольный `AutoShape`:
```php
// Создайте экземпляр класса Presentation, представляющего файл презентации.
$presentation = new Presentation();
try {
    // Получите первый слайд.
    $slide = $presentation->getSlides()->get_Item(0);

    // Добавьте автофигуру типа Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

    // Установите цвет заливки для фигуры прямоугольника.
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

## **Форматирование стилей соединений**

Существует три варианта типа соединения:

* Round
* Miter
* Bevel

По умолчанию PowerPoint использует настройку **Round**, когда соединяет две линии под углом (например, в угле фигуры). Однако если вы рисуете фигуру с острыми углами, может быть предпочтительнее вариант **Miter**.

![Стиль соединения в презентации](join-style-powerpoint.png)

Ниже показан PHP‑код, демонстрирующий, как были созданы три прямоугольника (как показано на изображении выше) с использованием настроек соединения Miter, Bevel и Round:
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

    // Установите цвет заливки для каждой фигуры прямоугольника.
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

    // Установите цвет линии для каждого прямоугольника.
    $shape1->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape2->getLineFormat()->setFillType(FillType::Solid);
    $shape2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape3->getLineFormat()->setFillType(FillType::Solid);
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


## **Градиентное заполнение**

В PowerPoint градиентное заполнение — это параметр форматирования, позволяющий применить плавный переход цветов к фигуре. Например, можно задать два и более цветов так, чтобы один постепенно переходил в другой.

Как применить градиентное заполнение к фигуре с помощью Aspose.Slides:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) на слайд.
1. Установите свойство [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) фигуры в `Gradient`.
1. Добавьте два предпочитаемых цвета с заданными позициями, используя методы `add` коллекции градиентных остановок, доступные через класс [GradientFormat](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/).
1. Сохраните изменённую презентацию в файл PPTX.

Ниже показан PHP‑код, демонстрирующий, как применить градиент к эллипсу:
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

    // Добавьте два градиентных остановки.
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0, PresetColor::Red);

    // Сохраните файл PPTX на диск.
    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


Результат:

![Эллипс с градиентным заполнением](gradient-fill.png)

## **Заполнение узором**

В PowerPoint заполнение узором — это параметр форматирования, позволяющий применить двухцветный рисунок (точки, полосы, перекрёстные штрихи, шахматка) к фигуре. Вы можете выбрать пользовательские цвета для переднего и заднего плана узора.

Aspose.Slides предоставляет более 45 предопределённых стилей узоров, которые можно применять к фигурам для улучшения внешнего вида презентаций. После выбора предопределённого узора вы всё равно можете указать точные цвета, которые он будет использовать.

Как применить заполнение узором к фигуре с помощью Aspose.Slides:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) на слайд.
1. Установите свойство [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) фигуры в `Pattern`.
1. Выберите стиль узора из предопределённых вариантов.
1. Установите [Background Color](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getBackColor) узора.
1. Установите [Foreground Color](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getForeColor) узора.
1. Сохраните изменённую презентацию в файл PPTX.

Ниже показан PHP‑код, демонстрирующий, как применить узор к прямоугольнику:
```php
// Создайте экземпляр класса Presentation, представляющего файл презентации.
$presentation = new Presentation();
try {
    // Получите первый слайд.
    $slide = $presentation->getSlides()->get_Item(0);

    // Добавьте автофигуру типа Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Установите тип заполнения в Pattern.
    $shape->getFillFormat()->setFillType(FillType::Pattern);

    // Установите стиль узора.
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);

    // Установите фон и передний цвета узора.
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    // Сохраните файл PPTX на диск.
    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


Результат:

![Прямоугольник с узором](pattern-fill.png)

## **Заполнение изображением**

В PowerPoint заполнение изображением — это параметр форматирования, позволяющий вставить изображение внутрь фигуры, эффективно используя его как фон фигуры.

Как использовать Aspose.Slides для заполнения фигуры изображением:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) на слайд.
1. Установите свойство [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) фигуры в `Picture`.
1. Установите режим заполнения изображения в `Tile` (или иной предпочтительный режим).
1. Создайте объект [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) из изображения, которое хотите использовать.
1. Передайте изображение в метод `SlidesPicture.setImage`.
1. Сохраните изменённую презентацию в файл PPTX.

Предположим, у нас есть файл «lotus.png» со следующим изображением:

![Изображение лотоса](lotus.png)

Ниже показан PHP‑код, демонстрирующий, как заполнить фигуру изображением:
```php
// Создайте экземпляр класса Presentation, представляющего файл презентации.
$presentation = new Presentation();
try {
    // Получите первый слайд.
    $slide = $presentation->getSlides()->get_Item(0);

    // Добавьте автофигуру типа Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

    // Установите тип заполнения в Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Установите режим заполнения изображением.
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


Результат:

![Фигура с заполнением изображением](picture-fill.png)

### **Тайловое изображение в качестве текстуры**

Если вы хотите задать тайловое изображение в качестве текстуры и настроить поведение тайлинга, используйте следующие методы класса [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode): Задает режим заполнения изображения — `Tile` или `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileAlignment): Определяет выравнивание тайлов внутри фигуры.
- [setTileFlip](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileFlip): Управляет отражением тайла по горизонтали, вертикали или обоим направлениям.
- [setTileOffsetX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetX): Задает горизонтальное смещение тайла (в пунктах) от начала фигуры.
- [setTileOffsetY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetY): Задает вертикальное смещение тайла (в пунктах) от начала фигуры.
- [setTileScaleX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleX): Определяет горизонтальный масштаб тайла в процентах.
- [setTileScaleY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleY): Определяет вертикальный масштаб тайла в процентах.

Ниже показан пример кода, добавляющего прямоугольник с тайловым заполнением изображением и настраивающего параметры тайла:
```php
// Создайте экземпляр класса Presentation, представляющего файл презентации.
$presentation = new Presentation();
try {
    // Получите первый слайд.
    $firstSlide = $presentation->getSlides()->get_Item(0);

    // Добавьте автофигуру прямоугольника.
    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

    // Установите тип заполнения фигуры в Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Загрузите изображение и добавьте его в ресурсы презентации.
    $sourceImage = Images::fromFile("lotus.png");
    $presentationImage = $presentation->getImages()->addImage($sourceImage);
    $sourceImage->dispose();

    // Назначьте изображение фигуре.
    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);

    // Настройте режим заполнения изображением и свойства тайлинга.
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

![Параметры тайла](tile-options.png)

## **Заполнение сплошным цветом**

В PowerPoint заполнение сплошным цветом — это параметр форматирования, который заполняет фигуру одним, одинаковым цветом. Этот однотонный фон применяется без градиентов, текстур или узоров.

Чтобы применить сплошное заполнение к фигуре с помощью Aspose.Slides, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) на слайд.
1. Установите свойство [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) фигуры в `Solid`.
1. Задайте желаемый цвет заливки.
1. Сохраните изменённую презентацию в файл PPTX.

Ниже показан PHP‑код, демонстрирующий, как применить сплошное заполнение к прямоугольнику в слайде PowerPoint:
```php
// Создайте экземпляр класса Presentation, представляющего файл презентации.
$presentation = new Presentation();
try {
    // Получите первый слайд.
    $slide = $presentation->getSlides()->get_Item(0);

    // Добавьте автофигуру типа Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Установите тип заполнения в Solid.
    $shape->getFillFormat()->setFillType(FillType::Solid);

    // Установите цвет заливки.
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    // Сохраните файл PPTX на диск.
    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


Результат:

![Фигура со сплошным заполнением](solid-color-fill.png)

## **Установка прозрачности**

В PowerPoint, когда вы применяете сплошной цвет, градиент, изображение или текстуру к фигурам, вы также можете задать уровень прозрачности, контролируя непрозрачность заливки. Чем выше значение прозрачности, тем более «прозрачной» будет фигура, позволяя видеть фон или объекты позади неё.

Aspose.Slides позволяет задать уровень прозрачности, изменяя альфа‑компонент цвета, используемого для заливки. Как это сделать:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) на слайд.
1. Установите [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) в `Solid`.
1. Используйте `Color`, задав цвет с прозрачностью (компонент `alpha` управляет прозрачностью).
1. Сохраните презентацию.

Ниже показан PHP‑код, демонстрирующий, как задать прозрачный цвет заливки для прямоугольника:
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


Результат:

![Прозрачная фигура](shape-transparency.png)

## **Поворот фигур**

Aspose.Slides позволяет вращать фигуры в презентациях PowerPoint. Это может быть полезно при размещении визуальных элементов с определённым выравниванием или дизайнерскими требованиями.

Чтобы повернуть фигуру на слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) на слайд.
1. Установите свойство вращения фигуры в нужный угол.
1. Сохраните презентацию.

Ниже показан PHP‑код, демонстрирующий вращение фигуры на 5 градусов:
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


Результат:

![Вращение фигуры](shape-rotation.png)

## **Добавление 3D‑скосов**

Aspose.Slides позволяет применять 3D‑скосы к фигурам, настраивая их свойства [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/).

Чтобы добавить 3D‑скос к фигуре, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) на слайд.
1. Настройте свойства [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/) фигуры, задав параметры скоса.
1. Сохраните презентацию.

Ниже показан PHP‑код, применяющий 3D‑скос к фигуре:
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


Результат:

![Эффект 3D‑скоса](3D-bevel-effect.png)

## **Добавление 3D‑поворотов**

Aspose.Slides позволяет применять 3D‑повороты к фигурам, настраивая их свойства [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/).

Чтобы применить 3D‑поворот к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) на слайд.
1. Используйте [setCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setCameraType) и [setLightType](https://reference.aspose.com/slides/php-java/aspose.slides/lightrig/#setLightType) для определения 3D‑поворота.
1. Сохраните презентацию.

Ниже показан PHP‑код, демонстрирующий применение 3D‑поворота к фигуре:
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


Результат:

![Эффект 3D‑поворота](3D-rotation-effect.png)

## **Сброс форматирования**

Ниже показан Java‑код, демонстрирующий, как сбросить форматирование слайда и вернуть положение, размер и форматирование всех фигур с заполнителями на [LayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/) к их значениям по умолчанию:
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

Только незначительно. Встроенные изображения и мультимедиа занимают большую часть пространства файла, тогда как параметры фигур, такие как цвета, эффекты и градиенты, хранятся как метаданные и почти не увеличивают размер.

**Как определить фигуры на слайде, имеющие одинаковое форматирование, чтобы их сгруппировать?**

Сравните ключевые свойства форматирования каждой фигуры — параметры заполнения, контура и эффекты. Если все соответствующие значения совпадают, считайте их стили идентичными и логически группируйте такие фигуры, что упрощает дальнейшее управление стилем.

**Можно ли сохранить набор пользовательских стилей фигур в отдельный файл для повторного использования в других презентациях?**

Да. Сохраните образцы фигур с нужными стилями в шаблонный набор слайдов или файл шаблона .POTX. При создании новой презентации откройте шаблон, клонируйте нужные стилизованные фигуры и повторно примените их форматирование там, где это требуется.