---
title: Форматирование фигур PowerPoint на JavaScript
linktitle: Форматирование фигур
type: docs
weight: 20
url: /ru/nodejs-java/shape-formatting/
keywords:
- форматирование фигуры
- форматирование линии
- эффект наброска
- набросок линии фигуры
- форматирование стиля соединения
- градиентная заливка
- заполнение узором
- заполнение изображением
- заполнение текстурой
- заливка сплошным цветом
- прозрачность фигуры
- чёрно‑белая отрисовка фигуры
- отображение фигуры в градациях серого
- повернуть фигуру
- 3D‑эффект фаски
- 3D‑эффект вращения
- сброс форматирования
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Узнайте, как форматировать фигуры PowerPoint на JavaScript с помощью Aspose.Slides — задавайте стили заливки, линий и эффектов для файлов PPT и PPTX с точностью и полным контролем."
---
## **Введение**

Форматируйте фигуры в PowerPoint, регулируя их контура, заливки и эффекты. Aspose.Slides for Node.js via Java позволяет программно управлять этими настройками, включая прозрачность, вращение и 3D‑форматирование.

![Варианты форматирования фигур в PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Node.js via Java предоставляет классы и методы, позволяющие форматировать фигуры с использованием тех же параметров, что доступны в PowerPoint.

## **Форматирование линий**

Используйте [Shape.getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat) для управления контуром фигуры. Этот пример создает незаполненный прямоугольник с синей пунктирной линией. [LineFormat.setStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setStyle) выбирает составную линию «толстый‑тонкий», а [LineFormat.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setWidth) устанавливает её ширину в 7 пунктов, и [LineFormat.setDashStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setDashStyle) выбирает шаблон пунктиров.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.ThickThin));
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    presentation.save("formatted_lines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Отформатированные линии в презентации](formatted-lines.png)

### **Установка пользовательских шаблонов пунктиров линии**

Используйте [LineFormat.setCustomDashPattern](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setCustomDashPattern), когда предопределённые стили линий не предоставляют нужных длин пунктиров и промежутков, например для фирменных контуров или технических схем. Назначение шаблона автоматически меняет стиль пунктировки линии на [LineDashStyle.Custom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linedashstyle/).

Элементы массива чередуются между длинами пунктиров и промежутков, начиная с пунктирного сегмента. Каждое значение является кратным ширине линии: `[4, 2]` при ширине 3 пункта дает пунктир длиной 12 пунктов, за которым следует промежуток 6 пунктов. Используйте пары конечных неотрицательных значений для определения полных сегментов пунктир‑промежуток. В примере используются положительные значения, чтобы каждый пунктир и промежуток были видимы.

Этот пример создаёт пять синих линий одинаковой длины и с плоскими концами. Первые три сравнивают шаблоны при ширине 3 пункта. Четвёртая повторяет первый шаблон при двойной ширине, удваивая как длину пунктиров, так и промежутков. Пятая переключается от пользовательского шаблона к сплошной линии.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(600, 300, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    let patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ];

    for (let i = 0; i < patterns.length; i++) {
        let line = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 50 + i * 50, 500, 0);
        line.getLineFormat().setWidth(i == 3 ? 6 : 3);
        line.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 139));
        line.getLineFormat().setCapStyle(java.newByte(aspose.slides.LineCapStyle.Flat));
        line.getLineFormat().setBeginArrowheadStyle(java.newByte(aspose.slides.LineArrowheadStyle.None));
        line.getLineFormat().setEndArrowheadStyle(java.newByte(aspose.slides.LineArrowheadStyle.None));
        let pattern = java.newArray("float", patterns[i]);
        line.getLineFormat().setCustomDashPattern(pattern);
    }

    // Вернуть последнюю линию к сплошному стилю.
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Solid));

    presentation.save("custom_dash_patterns.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Чтобы вернуться к предопределённому пунктирному стилю, передайте [LineDashStyle.Dash](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linedashstyle/) в [LineFormat.setDashStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setDashStyle). Выбранный стиль управляет внешним видом линии.

Результат в PowerPoint сверху вниз: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; и **Solid, 3 pt**.

![Три пользовательских шаблона пунктиров, более широкая линия с первым шаблоном и сплошная линия в PowerPoint](custom-dash-patterns.png)

### **Установка концов линии**

Используйте [LineFormat.setCapStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setCapStyle) для установки концов открытой линии. Класс [LineCapStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linecapstyle/) предоставляет три явных стиля концов:

- `Flat`: Линия заканчивается в конечной точке.
- `Round`: Полукруглый конец выступает за пределы конечной точки на половину ширины линии.
- `Square`: Квадратный конец выступает за пределы конечной точки на половину ширины линии.

Класс также включает `NotDefined`, что означает, что стиль конца явно не задан.

Концы отличаются от стрелок, которые добавляют символы к концам линии, и соединений, которые управляют углами между сегментами линии. Этот пример отключает стрелки через [LineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setBeginArrowheadStyle) и [LineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setEndArrowheadStyle), чтобы сравнивались только формы концов.

Следующий пример создает три практически одинаковые горизонтальные линии шириной 20 пунктов. Сверху вниз они используют плоские, круглые и квадратные концы. Их конечные точки имеют одинаковые горизонтальные координаты; круглые и квадратные концы выступают на 10 пунктов за каждую конечную точку.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(500, 240, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    let capStyles = [aspose.slides.LineCapStyle.Flat, aspose.slides.LineCapStyle.Round, aspose.slides.LineCapStyle.Square];

    for (let i = 0; i < capStyles.length; i++) {
        let line = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 100, 50 + i * 70, 300, 0);
        line.getLineFormat().setWidth(20);
        line.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 139));
        line.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Solid));
        line.getLineFormat().setCapStyle(java.newByte(capStyles[i]));
        line.getLineFormat().setBeginArrowheadStyle(java.newByte(aspose.slides.LineArrowheadStyle.None));
        line.getLineFormat().setEndArrowheadStyle(java.newByte(aspose.slides.LineArrowheadStyle.None));
    }

    presentation.save("line_caps.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат в PowerPoint сверху вниз: **Flat**, **Round**, и **Square**.

![Плоские, круглые и квадратные концы на одинаковых толстых линиях в PowerPoint](line-caps.png)

## **Применение эффектов наброска к линиям фигур**

Эффект наброска делает линию фигуры выглядящей нарисованной от руки. Используйте [Shape.getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat) для доступа к настройкам линии, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#getSketchFormat) для доступа к настройкам наброска и [SketchFormat.setSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sketchformat/#setSketchType) для выбора значения из класса [LineSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/).

Следующий код JavaScript показывает, как применить эффект [LineSketchType.Curved](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/), прочитать явно назначенное значение и удалить эффект с помощью [LineSketchType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);

    let sketchFormat = shape.getLineFormat().getSketchFormat();
    sketchFormat.setSketchType(aspose.slides.LineSketchType.Curved);
    let explicitSketchType = sketchFormat.getSketchType();
    console.log("Explicit sketch type: " + explicitSketchType);
    sketchFormat.setSketchType(aspose.slides.LineSketchType.None);
} finally {
    presentation.dispose();
}
```

Значение, возвращаемое [SketchFormat.getSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sketchformat/#getSketchType), представляет настройку, назначенную непосредственно фигуре. Если форматирование линии может наследоваться из темы, главного слайда или макета, используйте [LineFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#getEffective), вызовите `getSketchFormat` у полученного объекта, а затем вызовите его метод `getSketchType`. Эффективное значение отражает фактическое применяемое форматирование после разрешения наследования. Этот пример требует существующей презентации с хотя бы одной фигурой на первом слайде и выводит оба значения:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    let lineFormat = shape.getLineFormat();
    let explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    let effectiveLineFormat = lineFormat.getEffective();
    let effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    console.log("Explicit sketch type: " + explicitSketchType);
    console.log("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **Форматирование стилей соединений**

Здесь три варианта типа соединения:

* Round
* Miter
* Bevel

Стиль соединения управляет тем, как два контура встречаются в углу. Используйте **Round** для скруглённых углов, **Miter** для острых углов или **Bevel** для локализованных углов.

![Стиль соединения в презентации](join-style-powerpoint.png)

Этот пример создаёт три чёрных прямоугольника с синими контурами шириной 15 пунктов. Он использует [LineFormat.setJoinStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setJoinStyle) для применения значений miter, bevel и round из [LineJoinStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linejoinstyle/), соответственно, чтобы сравнить, как рисуются углы.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let miterShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let bevelShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let roundShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    miterShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    miterShape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    bevelShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    bevelShape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    roundShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    roundShape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

    miterShape.getLineFormat().setWidth(15);
    bevelShape.getLineFormat().setWidth(15);
    roundShape.getLineFormat().setWidth(15);

    miterShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    miterShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    bevelShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    bevelShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    roundShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    roundShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    miterShape.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Miter));
    bevelShape.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Bevel));
    roundShape.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Round));

    miterShape.getTextFrame().setText("Miter Join Style");
    bevelShape.getTextFrame().setText("Bevel Join Style");
    roundShape.getTextFrame().setText("Round Join Style");

    presentation.save("join_styles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Ограничение соединений Miter на острых углах**

Используйте [LineFormat.setMiterLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setMiterLimit) вместе с [LineFormat.setJoinStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setJoinStyle), установленным в [LineJoinStyle.Miter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linejoinstyle/), чтобы ограничить, насколько далеко может выступать острый угол.

Ограничение — это отношение расстояния между внутренним и внешним углами соединения к ширине линии. Например, значение `8` допускает длину среза до восьми ширин линии; это не измерение в пунктах. Если угол превышает ограничение, PowerPoint использует фаску в этом месте. Большее ограничение позволяет более острые точки. Настройка влияет только на соединения Miter и не оказывает видимого эффекта, когда угол остаётся в пределах обоих ограничений.

Этот пример создаёт два одинаковых незаполненных треугольника с контурами шириной 20 пунктов. Левый треугольник использует ограничение `2`, правый — `8`. Каждый треугольник шириной 80 пунктов и высотой 160 пунктов, что даёт верхнему углу отношение длины среза к ширине линии примерно `4.12`. В результате PowerPoint делает фаску у левого вершины и сохраняет острую вершину у правого.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(500, 320, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    let miterLimits = [2, 8];

    for (let i = 0; i < miterLimits.length; i++) {
        let triangle = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Triangle, 90 + i * 240, 110, 80, 160);
        triangle.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        triangle.getLineFormat().setWidth(20);
        triangle.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        triangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 139));
        triangle.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Miter));
        triangle.getLineFormat().setMiterLimit(java.newFloat(miterLimits[i]));
    }

    presentation.save("miter_limits.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат в PowerPoint: **Miter limit 2** слева и **miter limit 8** справа.

![Срезанный верхний угол с ограничением Miter 2 и заострённый верхний угол с ограничением Miter 8 в PowerPoint](miter-limits.png)

## **Градиентная заливка**

Градиентная заливка смешивает цвета по фигуре. Этот пример заполняет эллипс линейным градиентом под углом 45° от красного к пурпурному с помощью [FillFormat.getGradientFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getGradientFormat). Метод [GradientStopCollection.addPresetColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientstopcollection/#addPresetColor) размещает цветовые стопы в 0 и 1, в начале и конце градиента. Очистка существующих стопов гарантирует, что будут использованы только эти два цвета.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
    shape.getFillFormat().getGradientFormat().setLinearGradientAngle(45);
    shape.getFillFormat().getGradientFormat().getGradientStops().clear();
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, aspose.slides.PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0, aspose.slides.PresetColor.Red);

    presentation.save("gradient_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Эллипс с градиентной заливкой](gradient-fill.png)

Если градиент выглядит иначе в экспортированном изображении, чем в PowerPoint, см. [Выберите стиль визуализации градиента](/slides/ru/nodejs-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Вы можете выбрать стиль визуализации без изменения градиентной заливки, сохранённой в презентации.

### **Установка угла линейного градиента**

Используйте [GradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/#setLinearGradientAngle) для управления ориентацией заливки [GradientShape.Linear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientshape/). Угол измеряется в градусах и увеличивается по часовой стрелке: `0` — слева направо, `90` — сверху вниз, `180` — справа налево, `270` — снизу вверх. Поддерживаются дробные углы. Углы вне диапазона `[0, 360)` нормализуются к одному обороту; например, `-45` становится `315`, а `360` — `0`.

Этот пример создаёт шесть прямоугольников с одинаковыми стопами красного, зелёного и синего цветов в позициях `0`, `0.5` и `1`. Масштабирование отключено, чтобы угол можно было сравнивать независимо от пропорций прямоугольников. Углы слева направо: `0`, `45` и `90` в первой строке, а `135`, `180` и `270` во второй строке.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    let angles = [0, 45, 90, 135, 180, 270];

    for (let i = 0; i < angles.length; i++) {
        let x = 30 + (i % 3) * 230;
        let y = 30 + Math.floor(i / 3) * 190;

        let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, x, y, 200, 150);
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));

        let gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "RED"));
        gradient.getGradientStops().add(java.newFloat(0.5), java.getStaticFieldValue("java.awt.Color", "GREEN"));
        gradient.getGradientStops().add(1, java.getStaticFieldValue("java.awt.Color", "BLUE"));
        gradient.setLinearGradientScaled(java.newByte(aspose.slides.NullableBool.False));
        gradient.setLinearGradientAngle(angles[i]);
    }

    presentation.save("linear_gradient_angles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат в PowerPoint:

![Линейные градиенты при 0, 45 и 90 градусах в верхнем ряду и 135, 180 и 270 градусах в нижнем ряду](linear-gradient-angles.png)

### **Масштабирование линейного градиента фигурой**

[GradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/#setLinearGradientScaled) принимает значение [NullableBool](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/). Установите его явно в `False`, чтобы геометрический угол градиента сохранялся при изменении пропорций фигуры, или в `True`, чтобы градиент масштабировался вместе с шириной и высотой фигуры. При включённом масштабировании видимый угол может отличаться от заданного угла у несоразмерной фигуры.

Следующий пример использует угол `45`° и те же цветовые стопы, что и при сравнении углов. В левом столбце используется `False`; в правом — `True`. Каждый столбец содержит широкий прямоугольник над высоким. Оба начинаются с одинаковых широких размеров; изменение ширины и высоты второго прямоугольника демонстрирует, как заливка реагирует на изменение размеров без изменения настроек градиента.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 460, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    let scalingOptions = [aspose.slides.NullableBool.False, aspose.slides.NullableBool.True];

    for (let column = 0; column < scalingOptions.length; column++) {
        for (let row = 0; row < 2; row++) {
            let x = 30 + column * 360;
            let y = row == 0 ? 30 : 150;

            let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, x, y, 300, 90);
            shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));

            let gradient = shape.getFillFormat().getGradientFormat();
            gradient.setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
            gradient.getGradientStops().clear();
            gradient.getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "RED"));
            gradient.getGradientStops().add(java.newFloat(0.5), java.getStaticFieldValue("java.awt.Color", "GREEN"));
            gradient.getGradientStops().add(1, java.getStaticFieldValue("java.awt.Color", "BLUE"));
            gradient.setLinearGradientAngle(45);
            gradient.setLinearGradientScaled(java.newByte(scalingOptions[column]));

            if (row == 1) {
                shape.setWidth(90);
                shape.setHeight(280);
            }
        }
    }

    presentation.save("linear_gradient_scaling.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат в PowerPoint, с отключённым масштабированием слева и включённым справа:

![Широкие и высокие прямоугольники с градиентом 45°, сравнение LinearGradientScaled False слева и True справа](linear-gradient-scaling.png)

При отключённом масштабировании диагональные цветовые полосы сохраняют одинаковую ориентацию в обоих прямоугольниках. При включённом масштабировании полосы растягиваются вместе с пропорциями фигуры. Это помогает воспроизводить градиент шаблона при адаптации фигуры к другому размеру. На квадрате включение масштабирования не меняет внешний вид этого градиента `45`°.

Оба параметра — угол и масштабирование — применяются к линейным градиентам. Они не управляют заливками [GradientShape.Radial or GradientShape.Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientshape/).

### **Комбинация угла с направлением градиента**

[GradientFormat.setGradientDirection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/#setGradientDirection) выбирает стиль градиента из класса [GradientDirection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientdirection/); это не заменяет числовой угол. Для линейного градиента стили углов могут менять область распределения цветов без изменения угла, заданного через [setLinearGradientAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/#setLinearGradientAngle). Сохраняйте направление неизменным при сравнении углов или масштабирования.

Следующий пример применяет одинаковые настройки в обратном порядке. Два прямоугольника выглядят одинаково: назначение направления до или после угла не меняет результат.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < 2; i++) {
        let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30 + i * 140, 320, 100);
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));

        let gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "RED"));
        gradient.getGradientStops().add(java.newFloat(0.5), java.getStaticFieldValue("java.awt.Color", "GREEN"));
        gradient.getGradientStops().add(1, java.getStaticFieldValue("java.awt.Color", "BLUE"));
        gradient.setLinearGradientScaled(java.newByte(aspose.slides.NullableBool.True));

        if (i == 0) {
            gradient.setGradientDirection(aspose.slides.GradientDirection.FromCorner1);
            gradient.setLinearGradientAngle(30);
        } else {
            gradient.setLinearGradientAngle(30);
            gradient.setGradientDirection(aspose.slides.GradientDirection.FromCorner1);
        }
    }

    presentation.save("linear_gradient_direction.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Заливка узором**

Заливка узором применяет двухцветный рисунок, например точки, полосы или шахматы. Этот пример использует [PatternFormat.setPatternStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#setPatternStyle) для выбора узора «решётка». [PatternFormat.getBackColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getBackColor) задаёт светло-серый фон, а [PatternFormat.getForeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getForeColor) задаёт жёлтый цвет узора.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    presentation.save("pattern_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Прямоугольник с заливкой узором](pattern-fill.png)

## **Заливка изображением**

Заливка изображением использует картинку внутри фигуры. Этот пример требует локального изображения и использует [Images.fromFile](https://reference.aspose.com/slides/nodejs-java/aspose.slides/images/#fromFile) для загрузки его в коллекцию изображений презентации. Установка [PictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode) в режим «Tile» повторяет изображение внутри прямоугольника. Исходное изображение, используемое здесь, показано ниже:

![Изображение лотоса](lotus.png)

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Tile);

    let image = aspose.slides.Images.fromFile("lotus.png");
    let picture;
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    presentation.save("picture_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Фигура с заливкой изображением](picture-fill.png)

### **Повторить изображение как текстуру**

Если вы хотите задать повторяющуюся картинку как текстуру и настроить поведение повторения, можете использовать следующие методы класса [PictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): Устанавливает режим заливки изображения — `Tile` (повтор) или `Stretch` (растягивание).
- [setTileAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): Задает выравнивание плиток внутри фигуры.
- [setTileFlip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): Определяет, будет ли плитка отражена по горизонтали, вертикали или обоим направлениям.
- [setTileOffsetX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): Устанавливает горизонтальное смещение плитки (в пунктах) от начала фигуры.
- [setTileOffsetY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): Устанавливает вертикальное смещение плитки (в пунктах) от начала фигуры.
- [setTileScaleX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): Определяет горизонтальный масштаб плитки в процентах.
- [setTileScaleY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): Определяет вертикальный масштаб плитки в процентах.

Этот пример требует локального изображения и настраивает [PictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/) на повтор с 50 % от оригинального размера. Смещения −32 пункта сдвигают плитки горизонтально и вертикально; выравнивание «bottom‑right» и отражение в обоих направлениях определяют порядок расположения повторяющейся текстуры.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let firstSlide = presentation.getSlides().get_Item(0);

    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    let sourceImage = aspose.slides.Images.fromFile("lotus.png");
    let presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    let pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);
    pictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.BottomRight));
    pictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipBoth);

    presentation.save("tile.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Параметры плитки](tile-options.png)

## **Заливка сплошным цветом**

Сплошная заливка задаёт фигуре один единственный однородный цвет. Этот пример использует [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType) для выбора режима сплошной заливки и назначает жёлтый цвет через [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getSolidFillColor), после чего сохраняет прямоугольник в презентации.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    presentation.save("solid_color_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Фигура со сплошной заливкой](solid-color-fill.png)

### **Копировать цвета, сохраняя ссылки на тему**

Используйте [ColorFormat.copyFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/#copyFrom) для копирования определения цвета, включая его тип, ссылку на тему и преобразования. Это полезно при передаче цвета заливки между фигурами, которые должны продолжать следовать теме презентации. Метод копирует только цвет: он не копирует тип заливки, контур или другое форматирование фигуры. Явно задайте тип заливки назначения с помощью [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType).

Этот пример создаёт три прямоугольника слева направо: исходный, копию, учитывающую тему, и фиксированную RGB‑копию. Исходный использует [ColorFormat.setSchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/#setSchemeColor) для ссылки на первый акцентный цвет и добавляет оттенок через [ColorOperationCollection.add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/coloroperationcollection/#add). RGB‑копия использует эффективный цвет заливки исходного, так что все три первоначально выглядят одинаково. Вызов [ColorFormat.setColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/#setColor) задаёт фиксированное RGB‑значение и очищает любые существующие преобразования цвета.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(660, 220, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(java.newInstanceSync("java.awt.Color", 65, 105, 225));

    let source = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 40, 180, 140);
    let themeCopy = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 240, 40, 180, 140);
    let rgbCopy = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 450, 40, 180, 140);

    for (let shape of [source, themeCopy, rgbCopy]) {
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    }

    let sourceColor = source.getFillFormat().getSolidFillColor();
    sourceColor.setSchemeColor(aspose.slides.SchemeColor.Accent1);
    sourceColor.getColorTransform().add(aspose.slides.ColorTransformOperation.Tint, java.newFloat(0.75));

    themeCopy.getFillFormat().getSolidFillColor().copyFrom(sourceColor);
    rgbCopy.getFillFormat().getSolidFillColor().setColor(source.getFillFormat().getEffective().getSolidFillColor());

    let before = slide.getImage(1, 1);
    try {
        before.save("color-copy-before.png", aspose.slides.ImageFormat.Png);
    } finally {
        before.dispose();
    }

    // Ссылки на тему следуют новому цвету акцента; фиксированное RGB‑значение не меняется.
    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(java.newInstanceSync("java.awt.Color", 255, 69, 0));

    let after = slide.getImage(1, 1);
    try {
        after.save("color-copy-after.png", aspose.slides.ImageFormat.Png);
    } finally {
        after.dispose();
    }
    presentation.save("copied_colors.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Перед изменением темы все три заливки совпадают:

![Исходный, копия copyFrom и фиксированная RGB цель с одинаковой синий заливкой](color-copy-before.png)

После изменения темы исходный и копия, учитывающая тему, переходят к новому акцентному цвету и сохраняют свой оттенок. Фиксированная RGB‑копия остаётся синей:

![Исходный и копия copyFrom с оранжевыми заливками, в то время как фиксированная RGB цель остаётся синей](color-copy-after.png)

Скопированное определение независимо от исходного. Последующее изменение ссылки темы у исходного, назначение другого цвета или добавление/удаление его преобразований не меняет назначение. Изменение темы всё равно влияет на обе фигуры, потому что каждая независимо ссылается на один и тот же цвет темы.

Сохранение и повторное открытие PPTX сохраняет тип скопированного цвета, возвращаемый [ColorFormat.getColorType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/#getColorType), ссылку на тему и коллекцию преобразований, возвращаемую [ColorFormat.getColorTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/#getColorTransform); они не преобразуются в RGB.

При копировании между различными темами, например между презентациями с разными палитрами акцентов, скопированная ссылка разрешается относительно темы назначения. Та же ссылка и преобразования могут поэтому давать иной видимый цвет. См. [Тема презентации](/slides/ru/nodejs-java/presentation-theme/) для получения дополнительной информации о настройке цветов темы.

## **Использовать фон слайда как заливку фигуры**

Используйте [AutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/#setUseBackgroundFill), когда фигура должна соответствовать фону слайда, например в шаблоне презентации. Сначала задайте тип заливки через [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType) в [FillType.NotDefined](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/), чтобы удалить любую явную заливку. При этом комбинация заставит фигуру использовать фон слайда вместо собственного стиля заливки. Включение флага само по себе не удаляет существующую явную заливку.

Это отличается от [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/): заливка фоном покрывает объекты за фигурой соответствующей областью фонового изображения слайда, тогда как отсутствие заливки оставляет эти объекты видимыми. Градиент остаётся привязанным к слайду, а не перезапускается внутри каждой фигуры.

Следующий пример создаёт мастер‑фон, наследуемый слайдом, и размещает пурпурную полосу позади трёх прямоугольников. Левый прямоугольник использует фон, средний — без заливки, правый — переключается с фоновой заливки на явную оранжевую.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    // Наследовать градиент от мастера.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.NotDefined));
    slide.getLayoutSlide().getBackground().setType(java.newByte(aspose.slides.BackgroundType.NotDefined));
    let background = slide.getLayoutSlide().getMasterSlide().getBackground();
    background.setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    background.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    let gradient = background.getFillFormat().getGradientFormat();
    gradient.setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
    gradient.setLinearGradientAngle(0);
    gradient.getGradientStops().clear();
    gradient.getGradientStops().add(0, java.newInstanceSync("java.awt.Color", 0, 0, 139));
    gradient.getGradientStops().add(1, java.newInstanceSync("java.awt.Color", 135, 206, 250));

    // Добавьте этот объект первым, чтобы он оказался позади прямоугольников.
    let band = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 25, 150, 670, 100);
    band.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    band.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
    band.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    let backgroundShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 100, 160, 200);
    backgroundShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NotDefined));
    backgroundShape.setUseBackgroundFill(true);

    let noFillShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 280, 100, 160, 200);
    noFillShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    let explicitShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 510, 100, 160, 200);
    explicitShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NotDefined));
    explicitShape.setUseBackgroundFill(true);

    // Отключите заливку фоном перед применением явной заливки.
    explicitShape.setUseBackgroundFill(false);
    explicitShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    explicitShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 165, 0));

    presentation.save("background_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат слева направо: **background fill**, **no fill**, и **explicit fill**. Пурпурная полоса скрыта левым и правым прямоугольниками, но остаётся видимой через средний.

![Фоновая заливка, отсутствие заливки и явная оранжевая заливка поверх пурпурной полосы](background-fill.png)

То же поведение применяется к фону, определённому непосредственно на слайде или унаследованному из макета. Фигура использует разрешённый фон слайда; пример оставляет фоны слайда и макета неопределёнными, чтобы их обеспечивал мастер.

## **Установка прозрачности**

Для сплошной заливки альфа‑компонента цвета управляет непрозрачностью: `0` — полностью прозрачно, `255` — полностью непрозрачно. Этот пример использует альфа‑значение `128` для жёлтого прямоугольника, делая его примерно на 50 % прозрачным, чтобы нижний прямоугольник оставался видимым. Цвет задаётся через [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getSolidFillColor).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    let transparentShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    transparentShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 255, 0, 128));

    presentation.save("shape_transparency.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Прозрачная фигура](shape-transparency.png)

## **Вращение фигур**

Используйте [Shape.setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation) для вращения фигуры в плоскости слайда. Угол измеряется в градусах; этот пример вращает прямоугольник на 5 градусов по часовой стрелке и сохраняет презентацию.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    shape.setRotation(5);

    presentation.save("shape_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Вращение фигуры](shape-rotation.png)

## **Добавление 3D‑эффектов фаски**

Используйте [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat), чтобы придать фигуре глубину и фаску. Этот пример создаёт зелёный эллипс с оранжевым контуром, задаёт глубину 4 пункта через [ThreeDFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setDepth) и применяет круглую верхнюю фаску шириной и высотой 6 пунктов через [ThreeDFormat.getBevelTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getBevelTop). Фронтальная ортографическая камера и трёхточечное освещение делают фаску видимой.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 128, 0));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 165, 0));
    shape.getLineFormat().setWidth(2.0);
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);

    presentation.save("3D_bevel_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Эффект 3D‑фаски](3D-bevel-effect.png)

## **Добавление 3D‑вращения**

3D‑вид фигуры управляется настройками её камеры. Этот пример использует [Camera.setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setRotation) с углами широты 40°, долготы 35° и оборота 20°. Он выбирает изометрическую камеру через [Camera.setCameraType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setCameraType) и сбалансированное освещение через [LightRig.setLightType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lightrig/#setLightType), затем сохраняет отформатированный прямоугольник.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");
    autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);

    presentation.save("3D_rotation_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Эффект 3D‑вращения](3D-rotation-effect.png)

## **Управление черно‑белой визуализацией фигур**

Метод [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) задаёт, как отдельная фигура будет отрисовываться, когда презентация просматривается или обрабатывается в чёрно‑белом режиме. Он не включает чёрно‑белый режим сам по себе и не меняет заливку, контур или другое форматирование фигуры в обычном цветном режиме.

Используйте значение из класса [BlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blackwhitemode/) для выбора желаемого поведения. Например, `Automatic` позволяет приложению‑визуализатору выбирать преобразование, `Gray` и `LightGray` используют серый цвет, `BlackWhite` — только чёрный и белый, `Black` и `White` — принудительно один цвет, `Color` сохраняет обычные цвета, а `Hidden` — исключает фигуру в чёрно‑белом режиме. `NotDefined` означает, что режим для фигуры не задан.

Этот пример создаёт оранжевый прямоугольник и использует [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) для выбора серой окраски. Сохранённая фигура сохраняет оранжную заливку для обычного цветного отображения и запрашивает серую окраску у приложений, учитывающих чёрно‑белые настройки отображения:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 165, 0));
    shape.setBlackWhiteMode(java.newByte(aspose.slides.BlackWhiteMode.Gray));

    presentation.save("shape_black_white_mode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

В обычном цветном режиме прямоугольник сохраняет оранжную заливку. При рабочем процессе чёрно‑белого отображения он использует серую окраску, потому что его режим установлен в `Gray`. Это позволяет сохранять полноцветный слайд, определяя отдельный вид для печати, предварительного просмотра или других процессов, которые учитывают чёрно‑белые настройки презентации.

## **Сброс форматирования**

Используйте [Slide.reset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#reset) для восстановления позиции, размеров и форматирования заполнителей слайда из соответствующих заполнителей макета. Этот пример требует существующей презентации с заполнителями, связанными с макетом, и сбрасывает каждый слайд перед сохранением. Фигуры без соответствующих заполнителей макета не сбрасываются.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        slide.reset();
    }

    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Влияет ли форматирование фигур на конечный размер файла презентации?**  
Цвета, стили линий и настройки эффектов обычно добавляют мало данных по сравнению с встроенными изображениями и медиа. Заливка изображениями может увеличить размер файла, так как их изображения хранятся в презентации.

**Как определить фигуры на слайде, имеющие идентичное форматирование, чтобы сгруппировать их?**  
Сравните ключевые свойства форматирования каждой фигуры — заливку, контур и настройки эффектов. Если все соответствующие значения совпадают, считается, что их стили одинаковы, и такие фигуры можно логически сгруппировать, что упрощает последующее управление стилями.

**Можно ли сохранить набор пользовательских стилей фигур в отдельный файл для повторного использования в других презентациях?**  
Да. Сохраните образцы фигур с нужными стилями в шаблонном наборе слайдов или файле шаблона *.POTX*. При создании новой презентации откройте шаблон, клонируйте необходимые стилизованные фигуры и повторно примените их форматирование там, где это требуется.