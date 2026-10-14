---
title: Форматирование фигур PowerPoint в JavaScript
linktitle: Форматирование фигур
type: docs
weight: 20
url: /ru/nodejs-java/shape-formatting/
keywords:
- форматирование фигуры
- форматирование линии
- эффект эскиза
- эскиз линии фигуры
- форматировать стиль соединения
- градиентное заполнение
- заполнение узором
- заполнение изображением
- заполнение текстурой
- заполнение сплошным цветом
- прозрачность фигуры
- черно‑белая отрисовка фигуры
- отображение фигуры в градациях серого
- поворот фигуры
- 3D‑эффект фаски
- 3D‑эффект вращения
- сброс форматирования
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Форматирование фигур PowerPoint в JavaScript с помощью Aspose.Slides — задавайте стили заполнения, линий и эффектов для файлов PPT, PPTX и ODP с точностью и полным контролем."
---
## **Введение**

В PowerPoint вы можете добавлять фигуры на слайды. Поскольку фигуры состоят из линий, их можно форматировать, изменяя или применяя эффекты к контуру. Кроме того, вы можете форматировать фигуры, задавая параметры, которые контролируют заполнение их внутренней части.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Node.js via Java предоставляет классы и методы, позволяющие форматировать фигуры с использованием тех же параметров, что доступны в PowerPoint.

## **Форматирование линий**

С помощью Aspose.Slides вы можете указать пользовательский стиль линии для фигуры. Ниже приведена последовательность действий:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) на слайд.
1. Установите [стиль линии](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linestyle/) фигуры.
1. Установите ширину линии.
1. Установите [тип штриха](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linedashstyle/) линии.
1. Установите цвет линии для фигуры.
1. Сохраните изменённую презентацию в файл PPTX.

Следующий код демонстрирует, как отформатировать прямоугольник `AutoShape`:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Создайте объект класса Presentation, представляющий файл презентации.
let presentation = new aspose.slides.Presentation();
try {
    // Получите первый слайд.
    let slide = presentation.getSlides().get_Item(0);

    // Добавьте автоматическую фигуру типа Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);

    // Удалите заливку из прямоугольной фигуры.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // Примените форматирование к линиям прямоугольника.
    shape.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.ThickThin));
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));

    // Установите цвет линии прямоугольника.
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // Сохраните файл PPTX на диск.
    presentation.save("formatted_lines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Отформатированные линии в презентации](formatted-lines.png)

## **Применение эффектов эскиза к линиям фигур**

Эффект эскиза делает линию фигуры выглядящей как нарисованную от руки. Используйте [Shape.getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) для доступа к параметрам линии, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/) для доступа к параметрам эскиза и [SketchFormat.setSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sketchformat/) для выбора значения из перечисления [LineSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/).

Следующий JavaScript‑код показывает, как применить эффект [LineSketchType.Curved](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/), прочитать явно назначенное значение и удалить эффект с помощью [LineSketchType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/):

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);

    // Получить формат линии фигуры и её формат эскиза.
    let sketchFormat = shape.getLineFormat().getSketchFormat();

    // Применить эффект эскиза.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.Curved);

    // Прочитать эффект эскиза, назначенный непосредственно фигуре.
    let explicitSketchType = sketchFormat.getSketchType();
    console.log("Explicit sketch type: " + explicitSketchType);

    // Удалить эффект эскиза.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.None);
} finally {
    presentation.dispose();
}
```

Значение, возвращаемое [SketchFormat.getSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sketchformat/), представляет настройку, назначенную непосредственно фигуре. Если форматирование линии может быть унаследовано из темы, мастер‑слайда или шаблона, используйте [LineFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/), вызовите `getSketchFormat` у полученного объекта, а затем его метод `getSketchType`. Эффективное значение отражает фактическое форматирование после разрешения наследования:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

Вот три доступных варианта типа соединения:

* Round
* Miter
* Bevel

По умолчанию, когда PowerPoint соединяет две линии под углом (например, в углу фигуры), используется настройка **Round**. Однако если вы рисуете фигуру с острыми углами, вам может подойти вариант **Miter**.

![Стиль соединения в презентации](join-style-powerpoint.png)

Следующий JavaScript‑код демонстрирует, как три прямоугольника (как показано на изображении выше) были созданы с использованием настроек соединения Miter, Bevel и Round:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Создайте объект класса Presentation, представляющий файл презентации.
let presentation = new aspose.slides.Presentation();
try {
    // Получите первый слайд.
    let slide = presentation.getSlides().get_Item(0);

    // Добавьте три автоматические фигуры типа Rectangle.
    let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    // Установите цвет заливки для каждой прямоугольной фигуры.
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

    // Установите ширину линии.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // Установите цвет линии для каждого прямоугольника.
    shape1.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape2.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape3.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // Установите стиль соединения.
    shape1.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Miter));
    shape2.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Bevel));
    shape3.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Round));

    // Добавьте текст к каждому прямоугольнику.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // Сохраните файл PPTX на диск.
    presentation.save("join_styles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Градиентное заполнение**

В PowerPoint градиентное заполнение — это параметр форматирования, позволяющий применять к фигуре плавный переход цветов. Например, вы можете задать два и более цветов, где один постепенно переходит в другой.

Как применить градиентное заполнение к фигуре с помощью Aspose.Slides:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) на слайд.
1. Установите у фигуры [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) в значение `Gradient`.
1. Добавьте ваши два предпочтительных цвета с определёнными позициями, используя методы `add` коллекции градиентных остановок, предоставляемой классом [GradientFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/).
1. Сохраните изменённую презентацию в файл PPTX.

Следующий JavaScript‑код демонстрирует, как применить градиент к эллипсу:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Создайте объект класса Presentation, представляющий файл презентации.
let presentation = new aspose.slides.Presentation();
try {
    // Получите первый слайд.
    let slide = presentation.getSlides().get_Item(0);

    // Добавьте автоматическую фигуру типа Ellipse.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);

    // Примените градиентное форматирование к эллипсу.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));

    // Установите направление градиента.
    shape.getFillFormat().getGradientFormat().setGradientDirection(aspose.slides.GradientDirection.FromCorner2);

    // Добавьте две градиентные остановки.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, aspose.slides.PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0, aspose.slides.PresetColor.Red);

    // Сохраните файл PPTX на диск.
    presentation.save("gradient_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Эллипс с градиентным заполнением](gradient-fill.png)

Если градиент выглядит иначе в экспортированном изображении, чем в PowerPoint, см. [Choose a Gradient Rendering Style](/slides/ru/nodejs-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Можно выбрать стиль визуализации, не изменяя градиент, хранящийся в презентации.

## **Заполнение узором**

В PowerPoint заполнение узором — это параметр, позволяющий применить двухцветный узор — например, точки, полосы, перекрёстные линии или шахматную сетку — к фигуре. Вы можете выбрать собственные цвета для переднего и заднего плана узора.

Aspose.Slides предоставляет более 45 предопределённых стилей узоров, которые можно применить к фигурам для улучшения визуального восприятия презентаций. После выбора предопределённого узора вы всё равно можете указать точные цвета, которые он будет использовать.

Как применить узор к фигуре с помощью Aspose.Slides:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) на слайд.
1. Установите у фигуры [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) в значение `Pattern`.
1. Выберите стиль узора из предопределённых вариантов.
1. Установите [Background Color](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getBackColor--) узора.
1. Установите [Foreground Color](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getForeColor--) узора.
1. Сохраните изменённую презентацию в файл PPTX.

Следующий JavaScript‑код демонстрирует, как применить узор к прямоугольнику:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Создайте объект класса Presentation, представляющий файл презентации.
let presentation = new aspose.slides.Presentation();
try {
    // Получите первый слайд.
    let slide = presentation.getSlides().get_Item(0);

    // Добавьте автоматическую фигуру типа Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Установите тип заливки в Pattern.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));

    // Установите стиль узора.
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));

    // Установите фон и цвет переднего плана узора.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // Сохраните файл PPTX на диск.
    presentation.save("pattern_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Прямоугольник с узорным заполнением](pattern-fill.png)

## **Заполнение изображением**

В PowerPoint заполнение изображением — это параметр, позволяющий вставить изображение внутрь фигуры, effectively using the image as the shape's background.

Как использовать Aspose.Slides для заполнения фигуры изображением:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) на слайд.
1. Установите у фигуры [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) в значение `Picture`.
1. Установите режим заполнения изображения в `Tile` (или любой другой предпочтительный режим).
1. Создайте объект [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) из изображения, которое хотите использовать.
1. Передайте изображение методу `ISlidesPicture.setImage`.
1. Сохраните изменённую презентацию в файл PPTX.

Предположим, у нас есть файл «lotus.png» со следующим изображением:

![Изображение лотоса](lotus.png)

Следующий JavaScript‑код демонстрирует, как заполнить фигуру изображением:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Создайте объект класса Presentation, представляющий файл презентации.
let presentation = new aspose.slides.Presentation();
try {
    // Получите первый слайд.
    let slide = presentation.getSlides().get_Item(0);

    // Добавьте автоматическую фигуру типа Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Установите тип заливки в Picture.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Установите режим заполнения изображением.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Tile);

    // Загрузите изображение и добавьте его в ресурсы презентации.
    let image = aspose.slides.Images.fromFile("lotus.png");
    let picture = presentation.getImages().addImage(image);
    image.dispose();

    // Установите изображение.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Сохраните файл PPTX на диск.
    presentation.save("picture_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Фигура с заполнением изображением](picture-fill.png)

### **Изображение‑тайл как текстура**

Если необходимо задать изображение‑тайл в качестве текстуры и настроить поведение тайлинга, вы можете использовать следующие методы класса [PictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): задаёт режим заполнения изображения — `Tile` или `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): определяет выравнивание тайлов внутри фигуры.
- [setTileFlip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): управляет тем, будет ли тайл отражён горизонтально, вертикально или оба способа.
- [setTileOffsetX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): задаёт горизонтальное смещение тайла (в пунктах) от начала фигуры.
- [setTileOffsetY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): задаёт вертикальное смещение тайла (в пунктах) от начала фигуры.
- [setTileScaleX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): определяет горизонтальный масштаб тайла в процентах.
- [setTileScaleY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): определяет вертикальный масштаб тайла в процентах.

Следующий пример кода показывает, как добавить прямоугольник с тайловым заполнением изображения и настроить параметры тайла:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Создайте объект класса Presentation, представляющий файл презентации.
let presentation = new aspose.slides.Presentation();
try {
    // Получите первый слайд.
    let firstSlide = presentation.getSlides().get_Item(0);

    // Добавьте автоматическую фигуру прямоугольника.
    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);

    // Установите тип заливки фигуры в Picture.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Загрузите изображение и добавьте его в ресурсы презентации.
    let sourceImage = aspose.slides.Images.fromFile("lotus.png");
    let presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Назначьте изображение фигуре.
    let pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Настройте режим заполнения изображением и свойства тайлинга.
    pictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.BottomRight));
    pictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipBoth);

    // Сохраните файл PPTX на диск.
    presentation.save("tile.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Параметры тайла](tile-options.png)

## **Заполнение сплошным цветом**

В PowerPoint заполнение сплошным цветом — это параметр, который заполняет фигуру единым, одинаковым цветом. Этот простой фон применяется без градиентов, текстур или узоров.

Чтобы применить сплошное заполнение к фигуре с помощью Aspose.Slides, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) на слайд.
1. Установите у фигуры [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) в значение `Solid`.
1. Присвойте фигуре желаемый цвет заполнения.
1. Сохраните изменённую презентацию в файл PPTX.

Следующий JavaScript‑код демонстрирует, как применить сплошное заполнение к прямоугольнику в слайде PowerPoint:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Создайте объект класса Presentation, представляющий файл презентации.
let presentation = new aspose.slides.Presentation();
try {
    // Получите первый слайд.
    let slide = presentation.getSlides().get_Item(0);

    // Добавьте автоматическую фигуру типа Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Установите тип заливки в Solid.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));

    // Установите цвет заливки.
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // Сохраните файл PPTX на диск.
    presentation.save("solid_color_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Фигура со сплошным цветом](solid-color-fill.png)

## **Установка прозрачности**

В PowerPoint, когда вы применяете сплошное, градиентное, изображение или текстурное заполнение к фигурам, можно также задать уровень прозрачности, контролирующий непрозрачность заполнения. Чем выше значение прозрачности, тем более «прозрачной» становится фигура, позволяя видеть фон или объекты, расположенные ниже.

Aspose.Slides позволяет установить уровень прозрачности, изменяя альфа‑компонент цвета, используемого для заполнения. Как это сделать:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) на слайд.
1. Установите [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) в значение `Solid`.
1. Используйте `Color` для определения цвета с прозрачностью (компонент `alpha` управляет прозрачностью).
1. Сохраните презентацию.

Следующий JavaScript‑код демонстрирует, как применить прозрачный цвет заполнения к прямоугольнику:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Создайте объект класса Presentation, представляющий файл презентации.
let presentation = new aspose.slides.Presentation();
try {
    // Получите первый слайд.
    let slide = presentation.getSlides().get_Item(0);

    // Добавьте сплошную прямоугольную автоматическую фигуру.
    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Добавьте прозрачную прямоугольную автоматическую фигуру поверх сплошной фигуры.
    let transparentShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    transparentShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 255, 0, 204));

    // Сохраните файл PPTX на диск.
    presentation.save("shape_transparency.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Прозрачная фигура](shape-transparency.png)

## **Поворот фигур**

Aspose.Slides позволяет поворачивать фигуры в презентациях PowerPoint. Это может быть полезно при позиционировании визуальных элементов с определёнными требованиями к выравниванию или дизайну.

Чтобы повернуть фигуру на слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) на слайд.
1. Установите свойство вращения фигуры на требуемый угол.
1. Сохраните презентацию.

Следующий JavaScript‑код демонстрирует, как повернуть фигуру на 5 градусов:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Создайте объект класса Presentation, представляющий файл презентации.
let presentation = new aspose.slides.Presentation();
try {
    // Получите первый слайд.
    let slide = presentation.getSlides().get_Item(0);

    // Добавьте автоматическую фигуру типа Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Поверните фигуру на 5 градусов.
    shape.setRotation(5);

    // Сохраните файл PPTX на диск.
    presentation.save("shape_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Вращение фигуры](shape-rotation.png)

## **Добавление 3D‑эффектов фаски**

Aspose.Slides позволяет применять 3D‑эффекты фаски к фигурам, настраивая их свойства [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/).

Чтобы добавить 3D‑эффекты фаски к фигуре, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) на слайд.
1. Настройте у фигуры [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/) для определения параметров фаски.
1. Сохраните презентацию.

Следующий JavaScript‑код показывает, как применить 3D‑эффекты фаски к фигуре:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Создайте экземпляр класса Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Добавьте фигуру на слайд.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    shape.getLineFormat().setWidth(2.0);

    // Установите свойства ThreeDFormat фигуры.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);

    // Сохраните презентацию в файл PPTX.
    presentation.save("3D_bevel_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![3D‑эффект фаски](3D-bevel-effect.png)

## **Добавление 3D‑вращения**

Aspose.Slides позволяет применять 3D‑вращение к фигурам, настраивая их свойства [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/).

Чтобы применить 3D‑вращение к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) на слайд.
1. Используйте [setCameraType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setCameraType) и [setLightType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lightrig/#setLightType) для определения 3D‑вращения.
1. Сохраните презентацию.

Следующий JavaScript‑код демонстрирует, как применить 3D‑вращение к фигуре:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Создайте экземпляр класса Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);

    // Сохраните презентацию в файл PPTX.
    presentation.save("3D_rotation_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![3D‑вращение](3D-rotation-effect.png)

## **Управление черно‑белой визуализацией фигур**

Метод [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) задаёт, как отдельная фигура будет отрисована при просмотре или обработке презентации в черно‑белом режиме. Он сам по себе не включает черно‑белый режим и не меняет заполнение, линии или другое форматирование фигуры в обычном цветовом режиме.

Для выбора желаемого поведения используйте значение из перечисления [BlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blackwhitemode/). Например, `Automatic` позволяет приложению рендеринга выбрать способ конвертации, `Gray` и `LightGray` используют оттенки серого, `BlackWhite` — только чёрный и белый, `Black` и `White` — принудительно один цвет, `Color` сохраняет обычные цвета, а `Hidden` — исключает фигуру в черно‑белом режиме. `NotDefined` означает, что режим на уровне фигуры не задан.

Следующий JavaScript‑код создаёт цветную фигуру и заставляет её отображаться серой в черно‑белом режиме отображения:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));

    // Сохраните оранжевую заливку в цветном режиме, но отобразите фигуру в сером цвете в черно‑белом режиме.
    shape.setBlackWhiteMode(java.newByte(aspose.slides.BlackWhiteMode.Gray));

    presentation.save("shape_black_white_mode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

В обычном цветовом режиме прямоугольник сохраняет оранжевое заполнение. При работе в черно‑белом режиме он отображается серым, потому что его режим установлен в `Gray`. Это позволяет сохранять полноцветный слайд, задавая отдельный вид для печати, просмотра или других процессов, учитывающих настройки черно‑белого отображения презентации.

## **Сброс форматирования**

Следующий JavaScript‑код показывает, как сбросить форматирование слайда и вернуть позицию, размер и форматирование всех фигур с заполнителями на [LayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslide/) к их исходным настройкам:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        // Сбросить каждую фигуру на слайде, у которой есть заполнитель в макете.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Влияет ли форматирование фигур на конечный размер файла презентации?**

Только незначительно. Встроенные изображения и медиа занимают большую часть места, тогда как параметры фигур, такие как цвета, эффекты и градиенты, хранятся как метаданные и практически не увеличивают размер файла.

**Как определить фигуры на слайде, имеющие идентичное форматирование, чтобы сгруппировать их?**

Сравните у каждой фигуры ключевые свойства форматирования — заполнение, линии и эффекты. Если все соответствующие значения совпадают, рассматривайте их стили как одинаковые и логически группируйте такие фигуры, что упрощает управление стилями в дальнейшем.

**Можно ли сохранить набор пользовательских стилей фигур в отдельный файл для повторного использования в других презентациях?**

Да. Сохраните образцы фигур с нужными стилями в шаблонный набор слайдов или файл шаблона *.POTX*. При создании новой презентации откройте шаблон, клонируйте необходимые стилизованные фигуры и повторно примените их форматирование там, где это требуется.