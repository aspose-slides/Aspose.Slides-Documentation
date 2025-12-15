---
title: Форматирование фигур PowerPoint на Android
linktitle: Форматирование фигур
type: docs
weight: 20
url: /ru/androidjava/shape-formatting/
keywords:
- форматировать форму
- форматировать линию
- форматировать стиль соединения
- градиентная заливка
- узорчатая заливка
- заполнение изображением
- текстурная заливка
- сплошная заливка
- прозрачность фигуры
- повернуть фигуру
- 3d эффект фаски
- 3d эффект вращения
- сбросить форматирование
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Узнайте, как форматировать фигуры PowerPoint на Android с помощью Aspose.Slides — задавайте стили заливки, линий и эффектов для файлов PPT, PPTX и ODP с точностью и полным контролем."
---

## **Обзор**

В PowerPoint вы можете добавлять фигуры на слайды. Поскольку фигуры состоят из линий, вы можете форматировать их, изменяя или применяя эффекты к их контуру. Кроме того, вы можете форматировать фигуры, задавая параметры, которые контролируют заполнение их внутренностей.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Android via Java предоставляет интерфейсы и методы, позволяющие форматировать фигуры, используя те же параметры, что доступны в PowerPoint.

## **Форматирование линий**

С помощью Aspose.Slides вы можете задать пользовательский стиль линии для фигуры. Ниже приведены шаги, описывающие процедуру:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) на слайд.
4. Установите стиль линии [line style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linestyle/) фигуры.
5. Установите ширину линии.
6. Установите [dash style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linedashstyle/) линии.
7. Установите цвет линии для фигуры.
8. Сохраните изменённую презентацию в файл PPTX.

Следующий код демонстрирует, как отформатировать прямоугольный `AutoShape`:
```java
// Создать экземпляр класса Presentation, представляющего файл презентации.
Presentation presentation = new Presentation();
try {
    // Получить первый слайд.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Добавить автофигуру типа Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Установить цвет заливки для прямоугольной фигуры.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // Применить форматирование к линиям прямоугольника.
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // Установить цвет линии прямоугольника.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Сохранить файл PPTX на диск.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


Результат:

![The formatted lines in the presentation](formatted-lines.png)

## **Форматирование стилей соединений**

Вот три варианта типа соединения:

* Круглый
* Срез
* Фаска

По умолчанию, когда PowerPoint соединяет две линии под углом (например, в углу фигуры), он использует параметр **Round**. Однако, если вы рисуете фигуру с острыми углами, вам может подойти параметр **Miter**.

![The join style in the presentation](join-style-powerpoint.png)

Следующий код на Java демонстрирует, как три прямоугольника (как показано на изображении выше) были созданы с использованием настроек типа соединения Miter, Bevel и Round:
```java
// Создать экземпляр класса Presentation, представляющего файл презентации.
Presentation presentation = new Presentation();
try {
    // Получить первый слайд.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Добавить три автофигуры типа Rectangle.
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Установить цвет заливки для каждой прямоугольной фигуры.
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // Установить толщину линии.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // Установить цвет линии для каждого прямоугольника.
    shape1.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape3.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Установить стиль соединения.
    shape1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shape2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shape3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // Добавить текст к каждому прямоугольнику.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // Сохранить файл PPTX на диск.
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Заливка градиентом**

В PowerPoint заливка градиентом — это параметр форматирования, позволяющий применить к фигуре плавный переход цветов. Например, можно применить два и более цветов так, чтобы один постепенно переходил в другой.

Вот как применить заливку градиентом к фигуре с помощью Aspose.Slides:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) на слайд.
4. Установите [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) фигуры в `Gradient`.
5. Добавьте два желаемых цвета с определенными позициями, используя методы `add` коллекции градиентных остановок, предоставляемой интерфейсом [IGradientFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/).
6. Сохраните изменённую презентацию в файл PPTX.

```java
// Создать экземпляр класса Presentation, который представляет файл презентации.
Presentation presentation = new Presentation();
try {
    // Получить первый слайд.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Добавить автофигуру типа Ellipse.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Применить градиентное форматирование к эллипсу.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Установить направление градиента.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // Добавить две градиентные остановки.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // Сохранить файл PPTX на диск.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


Результат:

![The ellipse with gradient fill](gradient-fill.png)

## **Заливка узором**

В PowerPoint заливка узором — это параметр форматирования, позволяющий применить к фигуре двухцветный дизайн, например, точки, полосы, штриховку или шахматную сетку. Вы можете выбрать пользовательские цвета для переднего и заднего плана узора.

Aspose.Slides предоставляет более 45 предопределенных стилей узоров, которые можно применять к фигурам для повышения визуальной привлекательности презентаций. Даже после выбора предопределенного узора вы всё равно можете указать точные цвета, которые он будет использовать.

Вот как применить заливку узором к фигуре с помощью Aspose.Slides:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) на слайд.
4. Установите [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) фигуры в `Pattern`.
5. Выберите стиль узора из предопределенных вариантов.
6. Установите [Background Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/patternformat/#getBackColor--) узора.
7. Установите [Foreground Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/patternformat/#getForeColor--) узора.
8. Сохраните изменённую презентацию в файл PPTX.

```java
// Создать экземпляр класса Presentation, представляющего файл презентации.
Presentation presentation = new Presentation();
try {
    // Получить первый слайд.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Добавить автофигуру типа Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Установить тип заливки в Pattern.
    shape.getFillFormat().setFillType(FillType.Pattern);

    // Установить стиль узора.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // Установить цвета фона и переднего плана узора.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // Сохранить файл PPTX на диск.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


Результат:

![The rectangle with pattern fill](pattern-fill.png)

## **Заливка изображением**

В PowerPoint заливка изображением — это параметр форматирования, позволяющий вставить изображение внутрь фигуры, эффективно используя изображение как фон фигуры.

Вот как использовать Aspose.Slides для применения заливки изображением к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) на слайд.
4. Установите [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) фигуры в `Picture`.
5. Установите режим заливки изображения в `Tile` (или другой предпочтительный режим).
6. Создайте объект [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) из изображения, которое хотите использовать.
7. Передайте изображение методу `ISlidesPicture.setImage`.
8. Сохраните изменённую презентацию в файл PPTX.

Допустим, у нас есть файл "lotus.png" со следующим изображением:

![The lotus picture](lotus.png)

```java
// Создать экземпляр класса Presentation, представляющего файл презентации.
Presentation presentation = new Presentation();
try {
    // Получить первый слайд.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Добавить автофигуру типа Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Установить тип заливки в Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Установить режим заливки изображением.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // Загрузить изображение и добавить его в ресурсы презентации.
    IImage image = Images.fromFile("lotus.png");
    IPPImage picture = presentation.getImages().addImage(image);
    image.dispose();

    // Установить изображение.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Сохранить файл PPTX на диск.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


Результат:

![The shape with picture fill](picture-fill.png)

### **Мозаика изображения как текстура**

Если вы хотите установить мозаичное изображение как текстуру и настроить поведение мозаики, вы можете использовать следующие методы интерфейса [IPictureFillFormat] и класса [PictureFillFormat]:

- [setPictureFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Устанавливает режим заливки изображения — `Tile` или `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Задает выравнивание плиток внутри фигуры.
- [setTileFlip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Определяет, будет ли плитка отражена по горизонтали, вертикали или обеим осям.
- [setTileOffsetX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Устанавливает горизонтальное смещение плитки (в пунктах) от начала фигуры.
- [setTileOffsetY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Устанавливает вертикальное смещение плитки (в пунктах) от начала фигуры.
- [setTileScaleX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Определяет горизонтальный масштаб плитки в процентах.
- [setTileScaleY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Определяет вертикальный масштаб плитки в процентах.

Следующий пример кода показывает, как добавить прямоугольную фигуру с мозаичной заливкой изображением и настроить параметры плитки:
```java
// Создать экземпляр класса Presentation, представляющего файл презентации.
Presentation presentation = new Presentation();
try {
    // Получить первый слайд.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Добавить автофигуру прямоугольника.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Установить тип заливки фигуры в Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Загрузить изображение и добавить его в ресурсы презентации.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Присвоить изображение фигуре.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Настроить режим заливки изображением и параметры мозаики.
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    // Сохранить файл PPTX на диск.
    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


Результат:

![The tile options](tile-options.png)

## **Заливка сплошным цветом**

В PowerPoint заливка сплошным цветом — это параметр форматирования, который заполняет фигуру одним равномерным цветом. Этот простой фон применяется без градиентов, текстур или узоров.

Чтобы применить заливку сплошным цветом к фигуре с помощью Aspose.Slides, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) на слайд.
4. Установите [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) фигуры в `Solid`.
5. Назначьте желаемый цвет заливки фигуре.
6. Сохраните изменённую презентацию в файл PPTX.

```java
// Создать экземпляр класса Presentation, представляющего файл презентации.
Presentation presentation = new Presentation();
try {
    // Получить первый слайд.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Добавить автофигуру типа Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Установить тип заливки в Solid.
    shape.getFillFormat().setFillType(FillType.Solid);

    // Установить цвет заливки.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // Сохранить файл PPTX на диск.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


Результат:

![The shape with solid color fill](solid-color-fill.png)

## **Установка прозрачности**

В PowerPoint, когда вы применяете заливку сплошным цветом, градиентом, изображением или текстурой к фигурам, вы также можете установить уровень прозрачности, чтобы контролировать непрозрачность заливки. Более высокое значение прозрачности делает фигуру более просвечивающей, позволяя видеть фон или находящиеся под ней объекты.

Aspose.Slides позволяет задавать уровень прозрачности, изменяя альфа‑значение в цвете, используемом для заливки. Вот как это сделать:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) на слайд.
4. Установите [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) в `Solid`.
5. Используйте `Color` для определения цвета с прозрачностью (компонент `alpha` управляет прозрачностью).
6. Сохраните презентацию.

```java
// Создать экземпляр класса Presentation, представляющего файл презентации.
Presentation presentation = new Presentation();
try {
    // Получить первый слайд.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Добавить сплошную прямоугольную автофигуру.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Добавить прозрачную прямоугольную автофигуру поверх сплошной фигуры.
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // Сохранить файл PPTX на диск.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


Результат:

![The transparent shape](shape-transparency.png)

## **Поворот фигур**

Aspose.Slides позволяет поворачивать фигуры в презентациях PowerPoint. Это может быть полезно при размещении визуальных элементов с определённым выравниванием или требованиями к дизайну.

Чтобы повернуть фигуру на слайде, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) на слайд.
4. Установите свойство вращения фигуры на требуемый угол.
5. Сохраните презентацию.

```java
// Создать экземпляр класса Presentation, представляющего файл презентации.
Presentation presentation = new Presentation();
try {
    // Получить первый слайд.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Добавить автофигуру типа Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Повернуть фигуру на 5 градусов.
    shape.setRotation(5);

    // Сохранить файл PPTX на диск.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


Результат:

![The shape rotation](shape-rotation.png)

## **Добавление 3D‑эффектов фаски**

Aspose.Slides позволяет применять 3D‑эффекты фаски к фигурам, настраивая их свойства [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/threedformat/).

Чтобы добавить 3D‑эффекты фаски к фигуре, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) на слайд.
4. Настройте [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/threedformat/) фигуры для определения параметров фаски.
5. Сохраните презентацию.

```java
// Создать экземпляр класса Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Добавить фигуру на слайд.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE);
    shape.getLineFormat().setWidth(2.0);

    // Установить свойства ThreeDFormat фигуры.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    // Сохранить презентацию как файл PPTX.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


Результат:

![The 3D bevel effect](3D-bevel-effect.png)

## **Добавление 3D‑эффектов вращения**

Aspose.Slides позволяет применять 3D‑эффекты вращения к фигурам, настраивая их свойства [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/threedformat/).

Чтобы применить 3D‑вращение к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) на слайд.
4. Используйте методы [setCameraType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setCameraType-int-) и [setLightType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) для определения 3D‑вращения.
5. Сохраните презентацию.

```java
// Создать экземпляр класса Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    // Сохранить презентацию как файл PPTX.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


Результат:

![The 3D rotation effect](3D-rotation-effect.png)

## **Сброс форматирования**

Следующий код на Java демонстрирует, как сбросить форматирование слайда и вернуть позицию, размер и оформление всех фигур с заполняющими элементами на [LayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/layoutslide/) к их настройкам по умолчанию:
```java
Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Сбросить каждую фигуру на слайде, у которой есть заполнитель на макете.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **FAQ**

**Влияет ли форматирование фигур на конечный размер файла презентации?**

Только незначительно. Встроенные изображения и медиа‑файлы занимают большую часть объёма файла, тогда как параметры фигур, такие как цвета, эффекты и градиенты, хранятся как метаданные и практически не увеличивают размер.

**Как определить фигуры на слайде, имеющие одинаковое форматирование, чтобы их сгруппировать?**

Сравните ключевые свойства форматирования каждой фигуры — параметры заливки, линии и эффекты. Если все соответствующие значения совпадают, рассматривайте их стили как одинаковые и логически группируйте такие фигуры, что упрощает последующее управление стилями.

**Могу ли я сохранить набор пользовательских стилей фигур в отдельный файл для повторного использования в других презентациях?**

Да. Сохраните примеры фигур с нужными стилями в шаблонный набор слайдов или файл шаблона .POTX. При создании новой презентации откройте шаблон, клонируйте необходимые стилизованные фигуры и повторно примените их форматирование там, где требуется.