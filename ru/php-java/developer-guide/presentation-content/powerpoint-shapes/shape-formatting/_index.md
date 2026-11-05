---
title: Форматирование фигур PowerPoint в PHP
linktitle: Форматирование фигур
type: docs
weight: 20
url: /ru/php-java/shape-formatting/
keywords:
- форматировать фигуру
- форматировать линию
- эффект эскиза
- линия фигуры в стиле эскиза
- форматировать стиль соединения
- градиентная заливка
- шаблонная заливка
- заполнение изображением
- заполнение текстурой
- сплошная цветная заливка
- прозрачность фигуры
- черно-белый рендеринг фигуры
- рендеринг фигуры в градациях серого
- повернуть фигуру
- 3D-скосовый эффект
- эффект 3D-вращения
- сброс форматирования
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как форматировать фигуры PowerPoint в PHP с помощью Aspose.Slides - задавайте стили заливки, линии и эффектов для файлов PPT и PPTX с точностью и полным контролем."
---
## **Введение**

Форматируйте фигуры в PowerPoint, изменяя их контуры, заливки и эффекты. Aspose.Slides для PHP через Java позволяет управлять этими настройками программно, включая прозрачность, вращение и 3D‑форматирование.

![Варианты форматирования фигур в PowerPoint](format-shape-powerpoint.png)

Aspose.Slides для PHP через Java предоставляет классы и методы, позволяющие форматировать фигуры с теми же параметрами, что доступны в PowerPoint.

## **Форматирование линий**

Используйте [Shape::getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat), чтобы управлять контуром фигуры. Этот пример создаёт незаполненный прямоугольник с синей пунктирной обводкой. [LineFormat::setStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setStyle) выбирает составную линию «толстая‑тонкая», а [LineFormat::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setWidth) задаёт ширину 7 пунктов, а [LineFormat::setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setDashStyle) выбирает тип штриховки.

```php
use aspose\slides\FillType;
use aspose\slides\LineDashStyle;
use aspose\slides\LineStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат:

![Отформатированные линии в презентации](formatted-lines.png)

### **Установка пользовательских шаблонов штрихов линии**

Используйте [LineFormat::setCustomDashPattern](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setCustomDashPattern), когда предопределённые стили линий не предоставляют нужных длин штрихов и промежутков, например для фирменных контуров или технических схем. Присваивание шаблона автоматически меняет стиль штриховки линии на [LineDashStyle::Custom](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/).

Элементы массива чередуются между длинами штриха и промежутка, начиная со штриха. Каждый параметр – кратный ширине линии: `[4, 2]` при ширине 3 пункта дают штрих 12 пунктов и промежуток 6 пунктов. Используйте пары конечных неотрицательных значений для определения полных сегментов штрих‑пробел. В примере используются положительные значения, чтобы каждый штрих и промежуток были видимы.

Этот пример создаёт пять синих линий одинаковой длины и с плоскими концами. Первые три сравнивают шаблоны при ширине 3 пункта. Четвёртая повторяет первый шаблон при удвоенной ширине, удваивая и длину штриха, и промежутка. Пятая переключается с пользовательского шаблона на сплошную линию.

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\LineCapStyle;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(600, 300, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ];
    $lineColor = new Java("java.awt.Color", 0, 0, 139);

    for ($i = 0; $i < count($patterns); $i++) {
        $line = $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 50 + $i * 50, 500, 0);
        $line->getLineFormat()->setWidth($i == 3 ? 6 : 3);
        $line->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $line->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
        $line->getLineFormat()->setCapStyle(LineCapStyle::Flat);
        $line->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle::None);
        $line->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::None);
        $line->getLineFormat()->setCustomDashPattern($patterns[$i]);
    }

    // Вернуть последнюю линию к сплошному стилю.
    $slide->getShapes()->get_Item(4)->getLineFormat()->setDashStyle(LineDashStyle::Solid);

    $presentation->save("custom_dash_patterns.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Чтобы вернуться к предопределённому пунктирному стилю, передайте [LineDashStyle::Dash](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/) в [LineFormat::setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setDashStyle). Выбранный стиль управляет внешним видом линии.

Результат в PowerPoint сверху вниз: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; и **Solid, 3 pt**.

![Три пользовательских шаблона штрихов, более широкая линия с первым шаблоном и сплошная линия в PowerPoint](custom-dash-patterns.png)

### **Установка стилей концов линий**

Используйте [LineFormat::setCapStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setCapStyle), чтобы задать окончания открытой линии. Класс [LineCapStyle](https://reference.aspose.com/slides/php-java/aspose.slides/linecapstyle/) предоставляет три явно заданных стиля:

- `Flat`: штрих обрывается в конечной точке.
- `Round`: полукруглый конец выходит за пределы конечной точки на половину ширины линии.
- `Square`: квадратный конец выходит за пределы конечной точки на половину ширины линии.

Класс также включает `NotDefined`, что означает отсутствие явно заданного стиля конца.

Концы отличаются от стрелок, которые добавляют символы к концам линии, и от соединений, которые управляют углами между сегментами линии. В этом примере стрелки отключаются через [LineFormat::setBeginArrowheadStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setBeginArrowheadStyle) и [LineFormat::setEndArrowheadStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setEndArrowheadStyle), чтобы сравнивались только формы концов.

Следующий пример создаёт три почти одинаковых горизонтальных линии шириной 20 пунктов. Сверху вниз они используют плоские, круглые и квадратные концы. Их конечные координаты одинаковы по горизонтали; круглые и квадратные концы выступают на 10 пунктов за каждую конечную точку.

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\LineCapStyle;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(500, 240, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $capStyles = [LineCapStyle::Flat, LineCapStyle::Round, LineCapStyle::Square];

    for ($i = 0; $i < count($capStyles); $i++) {
        $line = $slide->getShapes()->addAutoShape(ShapeType::Line, 100, 50 + $i * 70, 300, 0);
        $line->getLineFormat()->setWidth(20);
        $line->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $lineColor = new Java("java.awt.Color", 0, 0, 139);
        $line->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
        $line->getLineFormat()->setDashStyle(LineDashStyle::Solid);
        $line->getLineFormat()->setCapStyle($capStyles[$i]);
        $line->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle::None);
        $line->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::None);
    }

    $presentation->save("line_caps.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат в PowerPoint сверху вниз: **Flat**, **Round**, **Square**.

![Плоские, круглые и квадратные концы на одинаковых толстых линиях в PowerPoint](line-caps.png)

## **Применение эффектов «эскиз» к линиям фигур**

Эффект «эскиз» делает линию фигуры выглядящей нарисованной вручную. Используйте [Shape::getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat) для доступа к настройкам линии, [LineFormat::getSketchFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#getSketchFormat) — к настройкам эскиза, и [SketchFormat::setSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/#setSketchType) для выбора значения из класса [LineSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/).

Следующий PHP‑код демонстрирует, как применить эффект [LineSketchType::Curved](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/), прочитать явно заданное значение и удалить эффект, задав [LineSketchType::None](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/):

```php
use aspose\slides\LineSketchType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

    $sketchFormat = $shape->getLineFormat()->getSketchFormat();
    $sketchFormat->setSketchType(LineSketchType::Curved);
    $explicitSketchType = $sketchFormat->getSketchType();
    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;
    $sketchFormat->setSketchType(LineSketchType::None);
} finally {
    $presentation->dispose();
}
```

Значение, возвращаемое [SketchFormat::getSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/#getSketchType), представляет настройку, назначенную непосредственно фигуре. Если форматирование линии может наследоваться от темы, главного слайда или макета, используйте [LineFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#getEffective), полученный объект‑метод `getSketchFormat` и прочитайте его значение `getSketchType`. Эффективное значение отражает реальное применённое форматирование после разрешения наследования. Этот пример требует существующей презентации с хотя бы одной фигурой на первом слайде и выводит оба значения:

```php
use aspose\slides\Presentation;

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

* Round
* Miter
* Bevel

Стиль соединения определяет, как два отрезка контура встречаются в углу. Используйте **Round** для закруглённых углов, **Miter** для острых углов или **Bevel** для снятых углов.

![Стиль соединения в презентации](join-style-powerpoint.png)

Этот пример создаёт три чёрных прямоугольника с синими контурами шириной 15 пунктов. Он устанавливает [LineFormat::setJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setJoinStyle) в значения miter, bevel и round из [LineJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/linejoinstyle/) соответственно, чтобы сравнить, как рисуются углы.

```php
use aspose\slides\FillType;
use aspose\slides\LineJoinStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $miterShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $bevelShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $roundShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    $miterShape->getFillFormat()->setFillType(FillType::Solid);
    $miterShape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $bevelShape->getFillFormat()->setFillType(FillType::Solid);
    $bevelShape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $roundShape->getFillFormat()->setFillType(FillType::Solid);
    $roundShape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

    $miterShape->getLineFormat()->setWidth(15);
    $bevelShape->getLineFormat()->setWidth(15);
    $roundShape->getLineFormat()->setWidth(15);

    $miterShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $miterShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $bevelShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $bevelShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $roundShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $roundShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    $miterShape->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
    $bevelShape->getLineFormat()->setJoinStyle(LineJoinStyle::Bevel);
    $roundShape->getLineFormat()->setJoinStyle(LineJoinStyle::Round);

    $miterShape->getTextFrame()->setText("Miter Join Style");
    $bevelShape->getTextFrame()->setText("Bevel Join Style");
    $roundShape->getTextFrame()->setText("Round Join Style");

    $presentation->save("join_styles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Ограничение соединений‑митеров в острых углах**

Используйте [LineFormat::setMiterLimit](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setMiterLimit) совместно с [LineFormat::setJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setJoinStyle), установленным в [LineJoinStyle::Miter](https://reference.aspose.com/slides/php-java/aspose.slides/linejoinstyle/), чтобы ограничить, насколько далеко может выступать острый угол.

Лимит — это отношение расстояния между внутренним и внешним углами соединения к ширине линии. Например, значение `8` допускает длину митера до восьми ширин линии; это не измеряется в пунктах. Если угол превышает лимит, PowerPoint заменяет его на снятое соединение. Больший лимит позволяет более острые точки. Настройка влияет только на митер‑соединения и не имеет видимого эффекта, когда угол остаётся в пределах лимита.

Этот пример создаёт два одинаковых незаполненных треугольника с контурами шириной 20 пунктов. Левый треугольник использует лимит `2`, правый — `8`. Каждый треугольник шириной 80 пунктов и высотой 160 пунктов, что даёт отношение длины митера к ширине линии около `4.12`. Поэтому PowerPoint обрезает левый верхний угол и сохраняет правый.

```php
use aspose\slides\FillType;
use aspose\slides\LineJoinStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(500, 320, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $miterLimits = [2, 8];

    for ($i = 0; $i < count($miterLimits); $i++) {
        $triangle = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 90 + $i * 240, 110, 80, 160);
        $triangle->getFillFormat()->setFillType(FillType::NoFill);
        $triangle->getLineFormat()->setWidth(20);
        $triangle->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $lineColor = new Java("java.awt.Color", 0, 0, 139);
        $triangle->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
        $triangle->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
        $triangle->getLineFormat()->setMiterLimit($miterLimits[$i]);
    }

    $presentation->save("miter_limits.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат в PowerPoint: **Miter limit 2** слева и **miter limit 8** справа.

![Снятый верхний угол при лимите митера 2 и острий угол при лимите 8 в PowerPoint](miter-limits.png)

## **Градиентная заливка**

Градиентная заливка плавно переходит от одного цвета к другому внутри фигуры. Этот пример заполняет эллипс линейным градиентом под углом 45° от красного к пурпурному, используя [FillFormat::getGradientFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getGradientFormat). Метод [GradientStopCollection::addPresetColor](https://reference.aspose.com/slides/php-java/aspose.slides/gradientstopcollection/#addPresetColor) размещает цветовые остановки в позициях 0 и 1, т.е. в начале и в конце градиента. Очистка существующих остановок обеспечивает использование только этих двух цветов.

```php
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\Presentation;
use aspose\slides\PresetColor;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);
    $shape->getFillFormat()->getGradientFormat()->setLinearGradientAngle(45);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->clear();
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0.0, PresetColor::Red);

    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат:

![Эллипс с градиентной заливкой](gradient-fill.png)

Если градиент выглядит иначе в экспортированном изображении, чем в PowerPoint, см. [Choose a Gradient Rendering Style](/slides/ru/php-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Вы можете выбрать стиль рендеринга, не меняя сам градиент, хранящийся в презентации.

### **Установка угла линейного градиента**

Используйте [GradientFormat::setLinearGradientAngle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientAngle) для управления ориентацией заливки типа [GradientShape::Linear](https://reference.aspose.com/slides/php-java/aspose.slides/gradientshape/). Угол измеряется в градусах и увеличивается по часовой стрелке: `0` — слева направо, `90` — сверху вниз, `180` — справа налево, `270` — снизу вверх. Поддерживаются дробные углы. Углы за пределами `[0, 360)` нормализуются к одному обороту; например, `-45` превращается в `315`, а `360` — в `0`.

Этот пример создаёт шесть прямоугольников с одинаковыми красными, зелёными и синими остановками в позициях `0`, `0.5` и `1`. Масштабирование отключено, чтобы угол сравнивался независимо от пропорций фигур. Углы слева направо: `0`, `45` и `90` в первой строке, и `135`, `180` и `270` во второй строке.

```php
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 400, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $angles = [0, 45, 90, 135, 180, 270];

    for ($i = 0; $i < count($angles); $i++) {
        $x = 30 + ($i % 3) * 230;
        $y = 30 + intdiv($i, 3) * 190;

        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 200, 150);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getFillFormat()->setFillType(FillType::Gradient);

        $gradient = $shape->getFillFormat()->getGradientFormat();
        $gradient->setGradientShape(GradientShape::Linear);
        $gradient->getGradientStops()->clear();
        $gradient->getGradientStops()->add(0, java("java.awt.Color")->RED);
        $gradient->getGradientStops()->add(0.5, java("java.awt.Color")->GREEN);
        $gradient->getGradientStops()->add(1, java("java.awt.Color")->BLUE);
        $gradient->setLinearGradientScaled(NullableBool::False);
        $gradient->setLinearGradientAngle($angles[$i]);
    }

    $presentation->save("linear_gradient_angles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат в PowerPoint:

![Линейные градиенты при углах 0, 45 и 90 градусов в верхнем ряду и 135, 180 и 270 градусов в нижнем ряду](linear-gradient-angles.png)

### **Масштабирование линейного градиента вместе с фигурой**

[GradientFormat::setLinearGradientScaled](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientScaled) принимает значение типа [NullableBool](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/). Установите его явно в `False`, чтобы сохранять геометрический угол градиента при изменении пропорций фигуры, или в `True`, чтобы масштабировать градиент вместе с шириной и высотой фигуры. При включённом масштабировании видимый угол может отличаться от заданного на несо-квадратной фигуре.

Следующий пример использует угол `45` градусов и те же цветовые остановки, что и в примере сравнения углов. В левом столбце установлено `False`; в правом — `True`. Каждый столбец содержит широкий прямоугольник над высоким прямоугольником. Оба начинают с одинаковых широких размеров; изменение ширины и высоты второго прямоугольника демонстрирует, как заливка реагирует на пере‑размеривание без изменения параметров градиента.

```php
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 460, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $scalingOptions = [NullableBool::False, NullableBool::True];

    for ($column = 0; $column < count($scalingOptions); $column++) {
        for ($row = 0; $row < 2; $row++) {
            $x = 30 + $column * 360;
            $y = $row == 0 ? 30 : 150;

            $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 300, 90);
            $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
            $shape->getFillFormat()->setFillType(FillType::Gradient);

            $gradient = $shape->getFillFormat()->getGradientFormat();
            $gradient->setGradientShape(GradientShape::Linear);
            $gradient->getGradientStops()->clear();
            $gradient->getGradientStops()->add(0, java("java.awt.Color")->RED);
            $gradient->getGradientStops()->add(0.5, java("java.awt.Color")->GREEN);
            $gradient->getGradientStops()->add(1, java("java.awt.Color")->BLUE);
            $gradient->setLinearGradientAngle(45);
            $gradient->setLinearGradientScaled($scalingOptions[$column]);

            if ($row == 1) {
                $shape->setWidth(90);
                $shape->setHeight(280);
            }
        }
    }

    $presentation->save("linear_gradient_scaling.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат в PowerPoint, с отключённым масштабированием слева и включённым справа:

![Широкие и высокие прямоугольники с градиентом 45°, сравнение LinearGradientScaled False слева и True справа](linear-gradient-scaling.png)

При отключённом масштабировании диагональные цветовые полосы сохраняют одинаковую ориентацию в обеих фигурах. При включённом масштабировании полосы растягиваются вместе с пропорциями фигуры. Это помогает воспроизвести градиент шаблона при адаптации фигуры к другому размеру. На квадрате включение масштабирования не меняет внешний вид градиента под 45°.

Оба параметра — угол и масштабирование — применимы только к линейным градиентам. Они не управляют заливками [GradientShape::Radial] или [GradientShape::Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientshape/).

### **Комбинация угла с направлением градиента**

[GradientFormat::setGradientDirection](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setGradientDirection) выбирает стиль градиента из класса [GradientDirection](https://reference.aspose.com/slides/php-java/aspose.slides/gradientdirection/); это не заменяет числовой угол. Для линейного градиента стиль угла может изменить область распределения цветов без изменения угла, задаваемого через [setLinearGradientAngle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientAngle). Оставляйте направление неизменным при сравнении углов или масштабирования.

Следующий пример применяет одинаковые параметры в обратном порядке. Два прямоугольника выглядят одинаково: установка направления до или после угла не меняет результат.

```php
use aspose\slides\FillType;
use aspose\slides\GradientDirection;
use aspose\slides\GradientShape;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    for ($i = 0; $i < 2; $i++) {
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30 + $i * 140, 320, 100);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getFillFormat()->setFillType(FillType::Gradient);

        $gradient = $shape->getFillFormat()->getGradientFormat();
        $gradient->setGradientShape(GradientShape::Linear);
        $gradient->getGradientStops()->clear();
        $gradient->getGradientStops()->add(0, java("java.awt.Color")->RED);
        $gradient->getGradientStops()->add(0.5, java("java.awt.Color")->GREEN);
        $gradient->getGradientStops()->add(1, java("java.awt.Color")->BLUE);
        $gradient->setLinearGradientScaled(NullableBool::True);

        if ($i == 0) {
            $gradient->setGradientDirection(GradientDirection::FromCorner1);
            $gradient->setLinearGradientAngle(30);
        } else {
            $gradient->setLinearGradientAngle(30);
            $gradient->setGradientDirection(GradientDirection::FromCorner1);
        }
    }

    $presentation->save("linear_gradient_direction.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Шаблонная заливка**

Шаблонная заливка применяет двухцветный узор, такой как точки, полосы или шахматы. Этот пример использует [PatternFormat::setPatternStyle](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#setPatternStyle) для выбора узора «решётка». [PatternFormat::getBackColor](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getBackColor) задаёт светло‑серый фон, а [PatternFormat::getForeColor](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getForeColor) — жёлтый цвет узора.

```php
use aspose\slides\FillType;
use aspose\slides\PatternStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::Pattern);
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат:

![Прямоугольник с шаблонной заливкой](pattern-fill.png)

## **Заливка картинкой**

Заливка картинкой использует изображение внутри фигуры. Этот пример требует локального изображения и использует [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) для загрузки его в коллекцию изображений презентации. Установка [PictureFillFormat::setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode) в режим «мозаика» повторяет изображение внутри прямоугольника. Исходное изображение показано ниже:

![Изображение лотоса](lotus.png)

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);
    $shape->getFillFormat()->setFillType(FillType::Picture);
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    $image = Images::fromFile("lotus.png");
    try {
        $picture = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);

    $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат:

![Фигура с заливкой картинкой](picture-fill.png)

### **Повторять изображение как текстуру**

Если нужно установить повторяющуюся картинку как текстуру и настроить её повторение, используйте следующие методы класса [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode): задаёт режим заливки — `Tile` или `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileAlignment): определяет выравнивание плиток внутри фигуры.
- [setTileFlip](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileFlip): управляет зеркальным отражением плитки по горизонтали, вертикали или обоим направлениям.
- [setTileOffsetX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetX): задаёт горизонтальное смещение плитки (в пунктах) от начала фигуры.
- [setTileOffsetY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetY): задаёт вертикальное смещение плитки (в пунктах) от начала фигуры.
- [setTileScaleX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleX): определяет горизонтальный масштаб плитки в процентах.
- [setTileScaleY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleY): определяет вертикальный масштаб плитки в процентах.

Этот пример требует локального изображения и настраивает [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) на повторение его в размере 50 % от оригинала. Смещения `−32` пункта сдвигают плитки горизонтально и вертикально; выравнивание в правом нижнем углу и отражение в обеих направлениях определяют расположение повторяющейся текстуры.

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\RectangleAlignment;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TileFlip;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);
    $shape->getFillFormat()->setFillType(FillType::Picture);

    $sourceImage = Images::fromFile("lotus.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($sourceImage);
    } finally {
        $sourceImage->dispose();
    }

    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);
    $pictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $pictureFillFormat->setTileOffsetX(-32);
    $pictureFillFormat->setTileOffsetY(-32);
    $pictureFillFormat->setTileScaleX(50);
    $pictureFillFormat->setTileScaleY(50);
    $pictureFillFormat->setTileAlignment(RectangleAlignment::BottomRight);
    $pictureFillFormat->setTileFlip(TileFlip::FlipBoth);

    $presentation->save("tile.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат:

![Параметры плитки](tile-options.png)

## **Сплошная цветная заливка**

Сплошная заливка задаёт фигуре один единый цвет. Этот пример устанавливает [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) в режим сплошной заливки и задаёт жёлтый цвет через [FillFormat::getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor), затем сохраняет прямоугольник в презентацию.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат:

![Фигура со сплошной цветной заливкой](solid-color-fill.png)

### **Копировать цвета, сохраняя ссылки на тему**

Используйте [ColorFormat::copyFrom](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#copyFrom) для копирования определения цвета, включая тип цвета, ссылку на тему и преобразования. Это полезно при передаче цвета заливки между фигурами, которые должны продолжать следовать теме презентации. Метод копирует только цвет: он не копирует тип заливки, контур или другое форматирование фигуры. Установите тип заливки назначения явно через [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType).

Этот пример создаёт три прямоугольника слева направо: источник, копию с учётом темы и фиксированную RGB‑копию. Источник использует [ColorFormat::setSchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#setSchemeColor) для ссылки на первый акцентный цвет и добавляет оттенок через [ColorOperationCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/coloroperationcollection/#add). RGB‑копия использует эффективный цвет заливки источника, поэтому все три изначально выглядят одинаково. Вызов [ColorFormat::setColor](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#setColor) задаёт фиксированное RGB‑значение и очищает любые существующие преобразования цвета.

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SchemeColor;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(660, 220, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $initialAccent = new Java("java.awt.Color", 65, 105, 225);
    $presentation->getMasterTheme()->getColorScheme()->getAccent1()->setColor($initialAccent);

    $source = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 40, 180, 140);
    $themeCopy = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 240, 40, 180, 140);
    $rgbCopy = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 450, 40, 180, 140);

    foreach ([$source, $themeCopy, $rgbCopy] as $shape) {
        $shape->getFillFormat()->setFillType(FillType::Solid);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    }

    $sourceColor = $source->getFillFormat()->getSolidFillColor();
    $sourceColor->setSchemeColor(SchemeColor::Accent1);
    $sourceColor->getColorTransform()->add(ColorTransformOperation::Tint, 0.75);

    $themeCopy->getFillFormat()->getSolidFillColor()->copyFrom($sourceColor);
    $rgbCopy->getFillFormat()->getSolidFillColor()->setColor($source->getFillFormat()->getEffective()->getSolidFillColor());

    $before = $slide->getImage(1.0, 1.0);
    try {
        $before->save("color-copy-before.png", ImageFormat::Png);
    } finally {
        $before->dispose();
    }

    // Ссылки на тему следуют новому акцентному цвету; фиксированное значение RGB не меняется.
    $updatedAccent = new Java("java.awt.Color", 255, 69, 0);
    $presentation->getMasterTheme()->getColorScheme()->getAccent1()->setColor($updatedAccent);

    $after = $slide->getImage(1.0, 1.0);
    try {
        $after->save("color-copy-after.png", ImageFormat::Png);
    } finally {
        $after->dispose();
    }
    $presentation->save("copied_colors.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

До изменения темы все три заливки совпадают:

![Источник, копия‑destination и фиксированная RGB‑destination с одинаковыми синими заливками](color-copy-before.png)

После изменения темы источник и копия, учитывающая тему, следуют новому акцентному цвету и сохраняют оттенок. Фиксированная RGB‑копия остаётся синей:

![Источник и копия‑destination с оранжевыми заливками, фиксированная RGB‑destination остаётся синей](color-copy-after.png)

Скопированное определение независимо от источника. Последующее изменение ссылки темы у источника, назначение другого цвета или добавление/удаление преобразований не меняет получателя. При изменении темы оба объекта меняются, потому что каждый независимо ссылается на один и тот же цвет темы.

Сохранение и повторное открытие PPTX сохраняет тип скопированного цвета, возвращаемый [ColorFormat::getColorType](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#getColorType), ссылку на тему и коллекцию преобразований, возвращаемую [ColorFormat::getColorTransform](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#getColorTransform); они не преобразуют определение в RGB.

При копировании между разными контекстами тем, например между презентациями с разными палитрами акцентов, скопированная ссылка разрешается относительно темы получателя. Та же ссылка и преобразования могут дать другой видимый цвет. См. [Presentation Theme](/slides/ru/php-java/presentation-theme/) для получения более подробной информации о настройке цветов темы.

## **Использовать фон слайда как заливку фигуры**

Используйте [AutoShape::setUseBackgroundFill](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#setUseBackgroundFill), когда фигура должна соответствовать фону слайда, например в шаблоне презентации. Сначала задайте тип заливки через [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) в значение [FillType::NotDefined](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/), чтобы убрать любую явную заливку. При такой комбинации фигура использует фон слайда вместо своей заливки. Включение только флага не удаляет уже существующую явную заливку.

Это отличается от [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/): заливка фоном покрывает объекты за фигурой соответствующей областью фона слайда, тогда как отсутствие заливки оставляет эти объекты видимыми. Градиент остаётся привязанным к слайду, а не перезапускается внутри каждой фигуры.

Следующий пример создаёт мастер‑фон, наследуемый слайдом, и размещает магентовую полосу за тремя прямоугольниками. Левый прямоугольник использует фон, средний — без заливки, правый переключается с фоновой заливки на явную оранжевую.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 400, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    // Наследовать градиент от мастера.
    $slide->getBackground()->setType(BackgroundType::NotDefined);
    $slide->getLayoutSlide()->getBackground()->setType(BackgroundType::NotDefined);
    $background = $slide->getLayoutSlide()->getMasterSlide()->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $background->getFillFormat()->setFillType(FillType::Gradient);
    $gradient = $background->getFillFormat()->getGradientFormat();
    $gradient->setGradientShape(GradientShape::Linear);
    $gradient->setLinearGradientAngle(0);
    $gradient->getGradientStops()->clear();
    $startColor = new Java("java.awt.Color", 0, 0, 139);
    $gradient->getGradientStops()->add(0, $startColor);
    $endColor = new Java("java.awt.Color", 135, 206, 250);
    $gradient->getGradientStops()->add(1, $endColor);

    // Добавить этот объект первым, чтобы он отображался позади прямоугольников.
    $band = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 25, 150, 670, 100);
    $band->getFillFormat()->setFillType(FillType::Solid);
    $band->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
    $band->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $backgroundShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 100, 160, 200);
    $backgroundShape->getFillFormat()->setFillType(FillType::NotDefined);
    $backgroundShape->setUseBackgroundFill(true);

    $noFillShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 280, 100, 160, 200);
    $noFillShape->getFillFormat()->setFillType(FillType::NoFill);

    $explicitShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 510, 100, 160, 200);
    $explicitShape->getFillFormat()->setFillType(FillType::NotDefined);
    $explicitShape->setUseBackgroundFill(true);

    // Отключить заливку фоном перед применением явной заливки.
    $explicitShape->setUseBackgroundFill(false);
    $explicitShape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $explicitShape->getFillFormat()->getSolidFillColor()->setColor($fillColor);

    $presentation->save("background_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат слева направо: **фоновая заливка**, **без заливки**, **явная заливка**. Магентовая полоса скрыта левым и правым прямоугольниками, но остаётся видимой через средний.

![Фоновая заливка, отсутствие заливки и явная оранжевая заливка поверх магентовой полосы](background-fill.png)

То же поведение применимо к фону, определённому непосредственно на слайде, или унаследованному от макета. Фигура использует разрешённый фон слайда; пример оставляет как слайд, так и фон макета неопределёнными, поэтому мастер их обеспечивает.

## **Установка прозрачности**

Для сплошной заливки альфа‑компонент цвета управляет непрозрачностью: 0 — полностью прозрачно, 255 — полностью непрозрачно. Этот пример использует значение альфа = 128 для жёлтого прямоугольника, делая его примерно на 50 % прозрачным, чтобы нижний прямоугольник оставался видимым. Цвет задаётся через [FillFormat::getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor).

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 255, 0, 128);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor($fillColor);

    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат:

![Прозрачная фигура](shape-transparency.png)

## **Вращение фигур**

Используйте [Shape::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) для поворота фигуры в плоскости слайда. Угол измеряется в градусах; в этом примере прямоугольник повёрнут на 5 градусов по часовой стрелке и сохраняется в презентацию.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->setRotation(5);

    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат:

![Вращение фигуры](shape-rotation.png)

## **Добавление 3D‑эффектов скосов**

Используйте [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat), чтобы придать фигуре глубину и скосы. Этот пример создаёт зелёный эллипс с оранжевой обводкой, задаёт [ThreeDFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setDepth) в 4 пункта и применяет круглый верхний скос шириной и высотой 6 пунктов через [ThreeDFormat::getBevelTop](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getBevelTop). Передняя орфографическая камера и трёхточечное освещение делают скос видимым.

```php
use aspose\slides\BevelPresetType;
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\LightRigPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 0, 128, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
    $shape->getLineFormat()->setWidth(2.0);
    $shape->getThreeDFormat()->setDepth(4);
    $shape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $shape->getThreeDFormat()->getBevelTop()->setHeight(6);
    $shape->getThreeDFormat()->getBevelTop()->setWidth(6);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::ThreePt);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);

    $presentation->save("3D_bevel_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат:

![Эффект 3D‑скоса](3D-bevel-effect.png)

## **Добавление 3D‑вращения**

Вид 3D‑фигуры контролируется настройками её камеры. Этот пример использует [Camera::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setRotation) с углами широты, долготы и вращения — 40°, 35° и 20°. Выбирает изометрическую камеру через [Camera::setCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setCameraType) и сбалансированное освещение через [LightRig::setLightType](https://reference.aspose.com/slides/php-java/aspose.slides/lightrig/#setLightType), затем сохраняет отформатированный прямоугольник.

```php
use aspose\slides\CameraPresetType;
use aspose\slides\LightRigPresetType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $autoShape->getTextFrame()->setText("Hello, Aspose!");
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(40, 35, 20);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);

    $presentation->save("3D_rotation_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат:

![Эффект 3D‑вращения](3D-rotation-effect.png)

## **Управление черно‑белым отображением фигур**

Метод [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setBlackWhiteMode) задаёт, как отдельная фигура будет отображаться при просмотре или обработке презентации в черно‑белом режиме. Он не включает черно‑белый режим сам по себе и не меняет заливку, контур или другое форматирование фигуры в обычном цветовом режиме.

Используйте значение из класса [BlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/blackwhitemode/), чтобы выбрать желаемое поведение. Например, `Automatic` позволяет приложению‑отображателю выбрать способ конвертации, `Gray` и `LightGray` используют оттенки серого, `BlackWhite` — только чёрный и белый, `Black` и `White` принудительно задают один цвет, `Color` сохраняет обычные цвета, а `Hidden` исключает фигуру в черно‑белом режиме. `NotDefined` означает, что режим на уровне фигуры не задан.

Этот пример создаёт оранжевый прямоугольник и задаёт [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setBlackWhiteMode) в `Gray`. Сохранённая фигура сохраняет оранжевую заливку для обычного цветного отображения и запрашивает серое отображение у приложений, поддерживающих настройки чёрно‑белого режима:

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
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->setBlackWhiteMode(BlackWhiteMode::Gray);

    $presentation->save("shape_black_white_mode.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

В обычном цветовом режиме прямоугольник сохраняет оранжевую заливку. В рабочем процессе чёрно‑белого отображения он будет отображаться серым, потому что его режим установлен в `Gray`. Это позволяет сохранять полноцветный слайд, определяя при этом отдельный вид для печати, предварительного просмотра или иных процессов, учитывающих чёрно‑белый режим.

## **Сброс форматирования**

Используйте [Slide::reset](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#reset), чтобы восстановить позицию, размеры и форматирование заполнителей слайда из соответствующих заполнителей макета. Этот пример требует существующей презентации с заполнителями, связанными с макетом, и сбрасывает каждый слайд перед сохранением. Фигуры без соответствующего заполнителя макета не сбрасываются.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        $slide->reset();
    }

    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Влияет ли форматирование фигур на конечный размер файла презентации?**

Цвета, стили линий и параметры эффектов обычно добавляют небольшое количество данных по сравнению с внедрёнными изображениями и мультимедиа. Заливка картинкой может увеличить размер файла, поскольку её изображения хранятся в презентации.

**Как обнаружить фигуры на слайде с идентичным форматированием, чтобы объединить их?**

Сравнивайте ключевые свойства форматирования каждой фигуры — заливку, линию и параметры эффектов. Если все соответствующие значения совпадают, считавайте их стили одинаковыми и логически группируйте такие фигуры, что упрощает дальнейшее управление стилями.

**Можно ли сохранить набор пользовательских стилей фигур в отдельный файл для повторного использования в других презентациях?**

Да. Сохраните образцы фигур с нужными стилями в шаблонный набор слайдов или файл шаблона *.POTX*. При создании новой презентации откройте шаблон, клонируйте необходимые стилизованные фигуры и примените их форматирование где требуется.