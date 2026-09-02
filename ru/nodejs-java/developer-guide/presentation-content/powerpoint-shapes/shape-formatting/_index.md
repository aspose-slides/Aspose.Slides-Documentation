---
title: Форматирование фигур PowerPoint в JavaScript
linktitle: Форматирование фигур
type: docs
weight: 20
url: /ru/nodejs-java/shape-formatting/
keywords:
- форматирование фигуры
- форматирование линии
- эффект скетча
- скетч линии фигуры
- форматирование стиля соединения
- градиентное заполнение
- заполнение шаблоном
- заполнение изображением
- заполнение текстурой
- заполнение сплошным цветом
- прозрачность фигуры
- чёрно‑белое отображение фигуры
- отображение фигуры в градациях серого
- поворот фигуры
- 3D‑скошенный эффект
- 3D‑вращение
- сброс форматирования
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Форматируйте фигуры PowerPoint на JavaScript с помощью Aspose.Slides — задавайте стили заполнения, линий и эффектов для файлов PPT, PPTX и ODP с точностью и полным контролем."
---
## **Введение**

В PowerPoint вы можете добавлять фигуры на слайды. Поскольку фигуры состоят из линий, их можно форматировать, изменяя или применяя эффекты к их контуру. Кроме того, вы можете форматировать фигуры, задавая параметры, контролирующие заполнение их внутренностей.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Node.js via Java предоставляет классы и методы, позволяющие форматировать фигуры, используя те же параметры, что и в PowerPoint.

## **Форматирование линий**

Используя Aspose.Slides, вы можете задать пользовательский стиль линии для фигуры. Ниже перечислены шаги процедуры:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/autoshape/) на слайд.
1. Установите [line style](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/linestyle/) фигуры.
1. Задайте толщину линии.
1. Установите [dash style](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/linedashstyle/) линии.
1. Установите цвет линии для фигуры.
1. Сохраните изменённую презентацию в файл PPTX.

Следующий код демонстрирует, как отформатировать прямоугольный `AutoShape`:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Создайте экземпляр класса Presentation, который представляет файл презентации.
let presentation = new aspose.slides.Presentation();
try {
    // Получить первый слайд.
    let slide = presentation.getSlides().get_Item(0);

    // Добавить автоматическую фигуру типа Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);

    // Удалить заливку из прямоугольной фигуры.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // Применить форматирование к линиям прямоугольника.
    shape.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.ThickThin));
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));

    // Установить цвет линии прямоугольника.
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // Сохранить файл PPTX на диск.
    presentation.save("formatted_lines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![The formatted lines in the presentation](formatted-lines.png)

## **Применение эффектов скетча к линиям фигуры**

Эффект скетча делает линию фигуры выглядящей как нарисованная от руки. Используйте [Shape.getLineFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/) для доступа к настройкам линии, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/lineformat/) для доступа к настройкам скетча и [SketchFormat.setSketchType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sketchformat/) для выбора значения из перечисления [LineSketchType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/linesketchtype/).

Следующий JavaScript‑код показывает, как применить эффект [LineSketchType.Curved](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/linesketchtype/) , прочитать явно назначенное значение и удалить эффект с помощью [LineSketchType.None](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/linesketchtype/):

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);

    // Получите формат линии фигуры и её формат скетча.
    let sketchFormat = shape.getLineFormat().getSketchFormat();

    // Примените эффект скетча.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.Curved);

    // Прочитайте эффект скетча, назначенный напрямую фигуре.
    let explicitSketchType = sketchFormat.getSketchType();
    console.log("Explicit sketch type: " + explicitSketchType);

    // Уберите эффект скетча.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.None);
} finally {
    presentation.dispose();
}
```

Значение, возвращаемое [SketchFormat.getSketchType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sketchformat/), представляет параметр, назначенный непосредственно фигуре. Если форматирование линии может наследоваться от темы, шаблона или макета слайда, используйте [LineFormat.getEffective](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/lineformat/), вызовите `getSketchFormat` у полученного объекта, а затем его метод `getSketchType`. Эффективное значение отражает форматирование, фактически применённое после разрешения наследования:

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

## **Форматирование стилей соединения**

Вот три варианта типа соединения:

* Round
* Miter
* Bevel

По умолчанию, когда PowerPoint соединяет две линии под углом (например, в углу фигуры), он использует настройку **Round**. Однако, если вы рисуете фигуру с острыми углами, вы можете предпочесть вариант **Miter**.

![The join style in the presentation](join-style-powerpoint.png)

Следующий JavaScript‑код демонстрирует, как были созданы три прямоугольника (как показано на изображении выше) с использованием настроек типа соединения Miter, Bevel и Round:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Создайте экземпляр класса Presentation, который представляет файл презентации.
let presentation = new aspose.slides.Presentation();
try {
    // Получить первый слайд.
    let slide = presentation.getSlides().get_Item(0);

    // Добавьте три автофигуры типа Rectangle.
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

    // Установите толщину линии.
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

В PowerPoint градиентное заполнение — это параметр форматирования, позволяющий применять к фигуре непрерывный переход цветов. Например, можно задать два и более цветов, где один постепенно переходит в другой.

Вот как применить градиентное заполнение к фигуре с помощью Aspose.Slides:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/autoshape/) на слайд.
1. Установите [FillType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/filltype/) фигуры в `Gradient`.
1. Добавьте два желаемых цвета с заданными позициями, используя методы `add` коллекции остановок градиента, предоставляемой классом [GradientFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/gradientformat/).
1. Сохраните изменённую презентацию в файл PPTX.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Создайте экземпляр класса Presentation, который представляет файл презентации.
let presentation = new aspose.slides.Presentation();
try {
    // Получить первый слайд.
    let slide = presentation.getSlides().get_Item(0);

    // Добавьте автоматическую фигуру типа Ellipse.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);

    // Примените градиентное форматирование к эллипсу.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));

    // Установите направление градиента.
    shape.getFillFormat().getGradientFormat().setGradientDirection(aspose.slides.GradientDirection.FromCorner2);

    // Добавьте две остановки градиента.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, aspose.slides.PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0, aspose.slides.PresetColor.Red);

    // Сохраните файл PPTX на диск.
    presentation.save("gradient_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![The ellipse with gradient fill](gradient-fill.png)

## **Заполнение шаблоном**

В PowerPoint заполнение шаблоном — это параметр форматирования, позволяющий применить двухцветный узор (точки, полосы, крест‑штриховку, клетки) к фигуре. Вы можете выбрать собственные цвета для переднего и заднего плана узора.

Aspose.Slides предоставляет более 45 предопределённых стилей шаблонов, которые можно применять к фигурам для улучшения визуального оформления презентаций. Даже после выбора предопределённого шаблона можно указать точные цвета, которые он будет использовать.

Вот как применить заполнение шаблоном к фигуре с помощью Aspose.Slides:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/autoshape/) на слайд.
1. Установите [FillType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/filltype/) фигуры в `Pattern`.
1. Выберите стиль шаблона из предопределённых вариантов.
1. Установите [Background Color](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/patternformat/#getBackColor--) шаблона.
1. Установите [Foreground Color](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/patternformat/#getForeColor--) шаблона.
1. Сохраните изменённую презентацию в файл PPTX.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Создайте экземпляр класса Presentation, который представляет файл презентации.
let presentation = new aspose.slides.Presentation();
try {
    // Получить первый слайд.
    let slide = presentation.getSlides().get_Item(0);

    // Добавьте автоматическую фигуру типа Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Установите тип заливки в Pattern.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));

    // Установите стиль шаблона.
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));

    // Установите фон и передний цвет шаблона.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // Сохраните файл PPTX на диск.
    presentation.save("pattern_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![The rectangle with pattern fill](pattern-fill.png)

## **Заполнение изображением**

В PowerPoint заполнение изображением — это параметр форматирования, позволяющий вставить изображение внутрь фигуры, фактически используя его в качестве фона фигуры.

Вот как использовать Aspose.Slides для применения заполнения изображением к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/autoshape/) на слайд.
1. Установите [FillType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/filltype/) фигуры в `Picture`.
1. Установите режим заполнения изображения в `Tile` (или другой предпочтительный режим).
1. Создайте объект [PPImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ppimage/) из изображения, которое хотите использовать.
1. Передайте изображение методу `ISlidesPicture.setImage`.
1. Сохраните изменённую презентацию в файл PPTX.

![The lotus picture](lotus.png)

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Создайте экземпляр класса Presentation, который представляет файл презентации.
let presentation = new aspose.slides.Presentation();
try {
    // Получить первый слайд.
    let slide = presentation.getSlides().get_Item(0);

    // Добавьте автоматическую фигуру типа Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Установите тип заливки в Picture.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Установите режим заливки изображением.
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

![The shape with picture fill](picture-fill.png)

### **Замощить изображение как текстуру**

Если вы хотите задать замощённое изображение в качестве текстуры и настроить поведение замощения, вы можете использовать следующие методы класса [PictureFillFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): задает режим заполнения изображением — `Tile` или `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): указывает выравнивание тайлов внутри фигуры.
- [setTileFlip](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): контролирует, будет ли тайл отражён по горизонтали, вертикали или обоим направлениям.
- [setTileOffsetX](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): задает горизонтальное смещение тайла (в пунктах) от начала фигуры.
- [setTileOffsetY](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): задает вертикальное смещение тайла (в пунктах) от начала фигуры.
- [setTileScaleX](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): определяет горизонтальный масштаб тайла в процентах.
- [setTileScaleY](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): определяет вертикальный масштаб тайла в процентах.

Следующий пример кода показывает, как добавить прямоугольную фигуру с замощённым заполнением изображением и настроить параметры тайлов:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Создайте экземпляр класса Presentation, который представляет файл презентации.
let presentation = new aspose.slides.Presentation();
try {
    // Получить первый слайд.
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

    // Настройте режим заливки изображением и параметры замощения.
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

![The tile options](tile-options.png)

## **Заполнение сплошным цветом**

В PowerPoint заполнение сплошным цветом — это параметр форматирования, который заполняет фигуру единым ровным цветом. Этот простой фоновый цвет применяется без градиентов, текстур или шаблонов.

Чтобы применить сплошное заполнение к фигуре с помощью Aspose.Slides, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/autoshape/) на слайд.
1. Установите [FillType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/filltype/) фигуры в `Solid`.
1. Назначьте предпочтительный цвет заливки фигуре.
1. Сохраните изменённую презентацию в файл PPTX.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Создайте экземпляр класса Presentation, который представляет файл презентации.
let presentation = new aspose.slides.Presentation();
try {
    // Получить первый слайд.
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

![The shape with solid color fill](solid-color-fill.png)

## **Установка прозрачности**

В PowerPoint при применении к фигурам сплошного, градиентного, изображенческого или текстурного заполнения можно также задать уровень прозрачности, контролирующий непрозрачность заливки. Более высокое значение прозрачности делает фигуру более просвечивающей, позволяя видеть фон или лежащие ниже объекты.

Aspose.Slides позволяет задать уровень прозрачности, изменяя альфа‑компонент цвета, используемого для заливки. Как это сделать:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/autoshape/) на слайд.
1. Установите [FillType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/filltype/) фигуры в `Solid`.
1. Используйте `Color` для определения цвета с прозрачностью (компонент `alpha` управляет прозрачностью).
1. Сохраните презентацию.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Создайте экземпляр класса Presentation, который представляет файл презентации.
let presentation = new aspose.slides.Presentation();
try {
    // Получить первый слайд.
    let slide = presentation.getSlides().get_Item(0);

    // Добавьте автоматическую фигуру прямоугольника со сплошным заполнением.
    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Добавьте автоматическую фигуру прямоугольника с прозрачностью поверх сплошной фигуры.
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

![The transparent shape](shape-transparency.png)

## **Поворот фигур**

Aspose.Slides позволяет вращать фигуры в презентациях PowerPoint. Это может быть полезно при размещении визуальных элементов с определённым выравниванием или дизайнерскими требованиями.

Чтобы повернуть фигуру на слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/autoshape/) на слайд.
1. Установите свойство вращения фигуры на требуемый угол.
1. Сохраните презентацию.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Создайте экземпляр класса Presentation, который представляет файл презентации.
let presentation = new aspose.slides.Presentation();
try {
    // Получить первый слайд.
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

![The shape rotation](shape-rotation.png)

## **Добавление 3D‑скошенных эффектов**

Aspose.Slides позволяет применять 3D‑скошенные эффекты к фигурам, настраивая их свойства [ThreeDFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/threedformat/).

Чтобы добавить 3D‑скошенные эффекты к фигуре, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/autoshape/) на слайд.
1. Настройте [ThreeDFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/threedformat/) фигуры, задав параметры фаски.
1. Сохраните презентацию.

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

![The 3D bevel effect](3D-bevel-effect.png)

## **Добавление 3D‑вращения**

Aspose.Slides позволяет применять 3D‑вращение к фигурам, настраивая их свойства [ThreeDFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/threedformat/).

Чтобы применить 3D‑вращение к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/autoshape/) на слайд.
1. Используйте [setCameraType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/camera/#setCameraType) и [setLightType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/lightrig/#setLightType) для определения 3D‑вращения.
1. Сохраните презентацию.

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

![The 3D rotation effect](3D-rotation-effect.png)

## **Управление черно‑белой визуализацией фигур**

Метод [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) указывает, как отдельная фигура будет отображаться, когда презентация просматривается или обрабатывается в черно‑белом режиме. Он сам по себе не включает черно‑белый режим и не меняет заполнение, линию или другое форматирование фигуры в обычном цветном режиме.

Используйте значение из перечисления [BlackWhiteMode](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/blackwhitemode/) для выбора нужного поведения. Например, `Automatic` позволяет приложению‑отображателю выбрать преобразование, `Gray` и `LightGray` используют серый цвет, `BlackWhite` использует только черный и белый, `Black` и `White` принудительно задают один цвет, `Color` сохраняет обычную окраску, а `Hidden` исключает фигуру в черно‑белом режиме. `NotDefined` означает, что режим не задан на уровне фигуры.

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

    // Сохраните оранжевую заливку в цветном режиме, но отображайте фигуру в сером цвете в черно‑белом режиме.
    shape.setBlackWhiteMode(java.newByte(aspose.slides.BlackWhiteMode.Gray));

    presentation.save("shape_black_white_mode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

В обычном цветном режиме прямоугольник сохраняет оранжевую заливку. В черно‑белом рабочем процессе он использует серый цвет, поскольку его режим установлен в `Gray`. Это позволяет сохранить полноцветный слайд, одновременно определяя отдельный вид для печати, предварительного просмотра или других процессов, которые учитывают настройки черно‑белого отображения презентации.

## **Сброс форматирования**

Следующий JavaScript‑код показывает, как сбросить форматирование слайда и вернуть положение, размер и форматирование всех фигур‑заполнителей на [LayoutSlide](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/layoutslide/) к их значениям по умолчанию:

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

Только незначительно. Встроенные изображения и мультимедиа занимают большую часть места файла, тогда как параметры фигур, такие как цвета, эффекты и градиенты, хранятся как метаданные и практически не увеличивают размер.

**Как определить фигуры на слайде, имеющие идентичное форматирование, чтобы сгруппировать их?**

Сравните ключевые свойства форматирования каждой фигуры — параметры заливки, линии и эффекты. Если все соответствующие значения совпадают, рассматривайте их стили как одинаковые и логически группируйте такие фигуры, что упрощает последующее управление стилями.

**Могу ли я сохранить набор пользовательских стилей фигур в отдельный файл для повторного использования в других презентациях?**

Да. Сохраните образцы фигур с нужными стилями в шаблонный набор слайдов или файл шаблона .POTX. При создании новой презентации откройте шаблон, клонируйте необходимые стилизованные фигуры и повторно примените их форматирование там, где это требуется.