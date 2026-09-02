---
title: Форматирование фигур PowerPoint в JavaScript
linktitle: Форматирование фигур
type: docs
weight: 20
url: /ru/nodejs-java/shape-formatting/
keywords:
- форматировать форму
- форматировать линию
- эскизный эффект
- эскизная линия фигуры
- форматировать стиль соединения
- градиентная заливка
- заполнение узором
- заполнение картинкой
- заполнение текстурой
- одноцветная заливка
- прозрачность фигуры
- вращение фигуры
- 3D эффект фаски
- 3D эффект вращения
- сброс форматирования
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Форматировать фигуры PowerPoint в JavaScript с помощью Aspose.Slides — установить стили заливки, линии и эффектов для файлов PPT, PPTX и ODP с точностью и полной управляемостью."
---
## **Введение**

В PowerPoint вы можете добавлять фигуры на слайды. Поскольку фигуры состоят из линий, их можно форматировать, изменяя или применяя эффекты к их контурам. Кроме того, вы можете форматировать фигуры, задавая параметры, контролирующие заполнение их внутренних областей.

![Форматирование формы в PowerPoint](format-shape-powerpoint.png)

Aspose.Slides для Node.js через Java предоставляет классы и методы, которые позволяют форматировать фигуры, используя те же параметры, что доступны в PowerPoint.

## **Форматирование линий**

С помощью Aspose.Slides вы можете задать пользовательский стиль линии для фигуры. Ниже перечислены шаги процедуры:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/autoshape/) на слайд.
4. Установите [line style](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/linestyle/) фигуры.
5. Установите ширину линии.
6. Задайте [dash style](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/linedashstyle/) линии.
7. Установите цвет линии для фигуры.
8. Сохраните изменённую презентацию в файл PPTX.

Следующий код демонстрирует, как отформатировать прямоугольный `AutoShape`:

```js
// Создайте экземпляр класса Presentation, представляющего файл презентации.
let presentation = new aspose.slides.Presentation();
try {
    // Получите первый слайд.
    let slide = presentation.getSlides().get_Item(0);

    // Добавьте автоматическую фигуру типа Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);

    // Установите цвет заливки для фигуры прямоугольника.
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

Эффект эскиза делает линию фигуры выглядящей нарисованной от руки. Используйте [Shape.getLineFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/) для доступа к настройкам линии, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/lineformat/) для доступа к настройкам эскиза и [SketchFormat.setSketchType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sketchformat/) для выбора значения из перечисления [LineSketchType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/linesketchtype/).

Следующий код JavaScript показывает, как применить эффект [LineSketchType.Curved](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/linesketchtype/), прочитать явно назначенное значение и удалить эффект с помощью [LineSketchType.None](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/linesketchtype/):

```js
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);

    // Получите формат линии фигуры и её формат эскиза.
    let sketchFormat = shape.getLineFormat().getSketchFormat();

    // Примените эффект эскиза.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.Curved);

    // Прочитайте эффект эскиза, назначенный напрямую фигуре.
    let explicitSketchType = sketchFormat.getSketchType();
    console.log("Explicit sketch type: " + explicitSketchType);

    // Удалите эффект эскиза.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.None);
} finally {
    presentation.dispose();
}
```

Значение, возвращаемое [SketchFormat.getSketchType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sketchformat/), представляет настройку, присвоенную непосредственно фигуре. Если форматирование линии может наследоваться от темы, мастер‑слайда или макета слайда, используйте [LineFormat.getEffective](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/lineformat/), вызовите `getSketchFormat` у полученного объекта, а затем вызовите его метод `getSketchType`. Эффективное значение отражает фактическое форматирование после разрешения наследования:

```js
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

* Круглый
* Фаска
* С фаской

По умолчанию PowerPoint соединяет две линии под углом (например, в углу фигуры) с использованием настройки **Round**. Однако, если вы рисуете фигуру с острыми углами, вам может подойти вариант **Miter**.

![Стиль соединения в презентации](join-style-powerpoint.png)

Следующий код JavaScript демонстрирует, как три прямоугольника (как показано на изображении выше) были созданы с использованием настроек соединения Miter, Bevel и Round:

```js
// Создайте экземпляр класса Presentation, представляющего файл презентации.
let presentation = new aspose.slides.Presentation();
try {
    // Получите первый слайд.
    let slide = presentation.getSlides().get_Item(0);

    // Добавьте три автоматические фигуры типа Rectangle.
    let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    // Установите цвет заливки для каждой фигуры прямоугольника.
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

## **Градиентная заливка**

В PowerPoint градиентная заливка – это параметр форматирования, позволяющий применить к фигуре плавный переход цветов. Например, можно задать два и более цвета так, чтобы один постепенно переходил в другой.

Ниже показано, как применить градиентную заливку к фигуре с помощью Aspose.Slides:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/autoshape/) на слайд.
4. Установите [FillType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/filltype/) фигуры в `Gradient`.
5. Добавьте два желаемых цвета с заданными позициями, используя методы `add` коллекции градиентных остановок, доступные через класс [GradientFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/gradientformat/).
6. Сохраните изменённую презентацию в файл PPTX.

```js
// Создайте экземпляр класса Presentation, представляющего файл презентации.
let presentation = new aspose.slides.Presentation();
try {
    // Получите первый слайд.
    let slide = presentation.getSlides().get_Item(0);

    // Добавьте автоматическую фигуру типа Ellipse.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);

    // Примените градиентное форматирование к эллипсу.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));

    // Задайте направление градиента.
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

![Эллипс с градиентной заливкой](gradient-fill.png)

## **Заполнение узором**

В PowerPoint заполнение узором – это параметр форматирования, позволяющий применить к фигуре двухцветный узор (точки, полосы, штриховка, шахматный и т.д.). Вы можете выбрать собственные цвета для переднего и заднего плана узора.

Aspose.Slides предоставляет более 45 предопределённых стилей узоров, которые можно применить к фигурам для повышения визуальной привлекательности презентаций. Даже после выбора предопределённого узора вы всё равно можете указать точные цвета, которые он должен использовать.

Ниже показано, как применить заполнение узором к фигуре с помощью Aspose.Slides:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/autoshape/) на слайд.
4. Установите [FillType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/filltype/) фигуры в `Pattern`.
5. Выберите стиль узора из предопределённых вариантов.
6. Установите [Background Color](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/patternformat/#getBackColor--) узора.
7. Установите [Foreground Color](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/patternformat/#getForeColor--) узора.
8. Сохраните изменённую презентацию в файл PPTX.

```js
// Создайте экземпляр класса Presentation, представляющего файл презентации.
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

    // Установите фоновые и передние цвета узора.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // Сохраните файл PPTX на диск.
    presentation.save("pattern_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Прямоугольник с узорчатой заливкой](pattern-fill.png)

## **Заполнение картинкой**

В PowerPoint заполнение картинкой – это параметр форматирования, позволяющий вставить изображение внутрь фигуры, эффективно используя изображение в качестве её фона.

Ниже показано, как с помощью Aspose.Slides применить заполнение картинкой к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/autoshape/) на слайд.
4. Установите [FillType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/filltype/) фигуры в `Picture`.
5. Установите режим заполнения картинкой в `Tile` (или любой другой предпочтительный режим).
6. Создайте объект [PPImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ppimage/) из изображения, которое хотите использовать.
7. Передайте изображение методу `ISlidesPicture.setImage`.
8. Сохраните изменённую презентацию в файл PPTX.

Допустим, у нас есть файл «lotus.png» со следующей картинкой:

![The lotus picture](lotus.png)

Следующий код JavaScript демонстрирует, как заполнить фигуру изображением:

```js
// Создайте экземпляр класса Presentation, представляющего файл презентации.
let presentation = new aspose.slides.Presentation();
try {
    // Получите первый слайд.
    let slide = presentation.getSlides().get_Item(0);

    // Добавьте автоматическую фигуру типа Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Установите тип заливки в Picture.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Установите режим заливки картинкой.
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

![Фигура с картинной заливкой](picture-fill.png)

### **Замостить изображение как текстуру**

Если вы хотите задать замощённое изображение в качестве текстуры и настроить поведение замощения, используйте следующие методы класса [PictureFillFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): Задаёт режим заливки изображением – `Tile` или `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): Определяет выравнивание плиток внутри фигуры.
- [setTileFlip](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): Управляет тем, будет ли плитка отражена по горизонтали, вертикали или обеим осям.
- [setTileOffsetX](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): Задаёт горизонтальное смещение плитки (в пунктах) от начала фигуры.
- [setTileOffsetY](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): Задаёт вертикальное смещение плитки (в пунктах) от начала фигуры.
- [setTileScaleX](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): Определяет горизонтальный масштаб плитки в процентах.
- [setTileScaleY](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): Определяет вертикальный масштаб плитки в процентах.

```js
// Создайте экземпляр класса Presentation, представляющего файл презентации.
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

    // Присвойте изображение фигуре.
    let pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Настройте режим заливки картинкой и свойства замощения.
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

![Параметры замостки](tile-options.png)

## **Одноцветная заливка**

В PowerPoint одноцветная заливка – это параметр форматирования, который заполняет фигуру единственным ровным цветом. Этот простой фон применяется без градиентов, текстур или узоров.

Чтобы применить одноцветную заливку к фигуре с помощью Aspose.Slides, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/autoshape/) на слайд.
4. Установите [FillType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/filltype/) фигуры в `Solid`.
5. Назначьте желаемый цвет заливки фигуре.
6. Сохраните изменённую презентацию в файл PPTX.

```js
// Создайте экземпляр класса Presentation, представляющего файл презентации.
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

![Фигура с одноцветной заливкой](solid-color-fill.png)

## **Установка прозрачности**

В PowerPoint при применении одноцветной, градиентной, картинной или текстурной заливки к фигурам можно также задать уровень прозрачности, контролирующий непрозрачность заливки. Чем выше значение прозрачности, тем более просвечивающей становится фигура, позволяя частично видеть фон или объекты под ней.

Aspose.Slides позволяет задать уровень прозрачности, изменяя альфа‑компонент цвета, используемого для заливки. Как это сделать:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/autoshape/) на слайд.
4. Установите [FillType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/filltype/) фигуры в `Solid`.
5. Используйте `Color` для определения цвета с прозрачностью (компонент `alpha` управляет прозрачностью).
6. Сохраните презентацию.

```js
// Создайте экземпляр класса Presentation, представляющего файл презентации.
let presentation = new aspose.slides.Presentation();
try {
    // Получите первый слайд.
    let slide = presentation.getSlides().get_Item(0);

    // Добавьте автоматическую фигуру прямоугольника со сплошной заливкой.
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

![Прозрачная фигура](shape-transparency.png)

## **Вращение фигур**

Aspose.Slides позволяет вращать фигуры в презентациях PowerPoint. Это может быть полезно при размещении визуальных элементов с определёнными требованиями к выравниванию или дизайну.

Чтобы повернуть фигуру на слайде, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/autoshape/) на слайд.
4. Установите свойство вращения фигуры в нужный угол.
5. Сохраните презентацию.

```js
// Создайте экземпляр класса Presentation, представляющего файл презентации.
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

![Вращение фигуры](shape-rotation.png)

## **Добавление 3D эффектов фаски**

Aspose.Slides позволяет применять 3D‑эффекты фаски к фигурам, настраивая их свойства [ThreeDFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/threedformat/).

Чтобы добавить 3D‑эффекты фаски к фигуре, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/autoshape/) на слайд.
4. Настройте [ThreeDFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/threedformat/) фигуры, задав параметры фаски.
5. Сохраните презентацию.

```js
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

![Эффект 3D фаски](3D-bevel-effect.png)

## **Добавление 3D вращения**

Aspose.Slides позволяет применять 3D‑вращение к фигурам, настраивая их свойства [ThreeDFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/threedformat/).

Чтобы применить 3D‑вращение к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/autoshape/) на слайд.
4. Используйте [setCameraType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/camera/#setCameraType) и [setLightType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/lightrig/#setLightType) для определения 3D‑вращения.
5. Сохраните презентацию.

```js
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

![Эффект 3D вращения](3D-rotation-effect.png)

## **Сброс форматирования**

Следующий код Java показывает, как сбросить форматирование слайда и вернуть положение, размер и форматирование всех фигур с заполнителями на [LayoutSlide](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/layoutslide/) к их настройкам по умолчанию:

```js
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        // Сбросить каждую фигуру на слайде, имеющую заполнитель в макете.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Влияет ли форматирование фигур на конечный размер файла презентации?**

Только незначительно. Встроенные изображения и медиа занимают большую часть объёма файла, а параметры фигур, такие как цвета, эффекты и градиенты, хранятся как метаданные и практически не увеличивают размер.

**Как обнаружить фигуры на слайде с идентичным форматированием, чтобы собрать их в группу?**

Сравните ключевые свойства форматирования каждой фигуры — параметры заполнения, линии и эффектов. Если все соответствующие значения совпадают, считаем их стили одинаковыми и логически группируем такие фигуры, что упрощает дальнейшее управление стилями.

**Могу ли я сохранить набор пользовательских стилей фигур в отдельный файл для повторного использования в других презентациях?**

Да. Сохраните образцы фигур с нужными стилями в шаблонный набор слайдов или файл шаблона .POTX. При создании новой презентации откройте шаблон, клонируйте необходимые стилизованные фигуры и повторно примените их форматирование там, где это требуется.