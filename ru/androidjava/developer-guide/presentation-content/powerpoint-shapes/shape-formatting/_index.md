---
title: "Форматирование фигур PowerPoint на Android"
linktitle: "Форматирование фигур"
type: docs
weight: 20
url: /ru/androidjava/shape-formatting/
keywords:
- "форматирование формы"
- "форматирование линии"
- "эффект эскиза"
- "линия фигуры в виде эскиза"
- "форматировать стиль соединения"
- "градиентная заливка"
- "узорная заливка"
- "заполнение изображением"
- "текстурная заливка"
- "сплошная заливка цветом"
- "прозрачность фигуры"
- "повернуть фигуру"
- "3D‑фаска"
- "3D‑поворот"
- "сбросить форматирование"
- "PowerPoint"
- "презентация"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Узнайте, как форматировать фигурки PowerPoint на Android с помощью Aspose.Slides — задавайте стили заливки, линии и эффектов для файлов PPT, PPTX и ODP с точностью и полным контролем."
---
## **Введение**

В PowerPoint вы можете добавлять фигурки на слайды. Поскольку фигурки состоят из линий, их можно форматировать, изменяя или применяя эффекты к контуру. Кроме того, фигурки можно форматировать, задавая параметры, определяющие, как заполняется их внутренняя часть.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Android via Java предоставляет интерфейсы и методы, позволяющие форматировать фигурки, используя те же возможности, что и в PowerPoint.

## **Форматирование линий**

С помощью Aspose.Slides вы можете указать пользовательский стиль линии для фигурки. Ниже перечислены шаги процедуры:

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/).
1. Получить ссылку на слайд по его индексу.
1. Добавить [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/) на слайд.
1. Установить [line style](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/linestyle/) фигурки.
1. Задать ширину линии.
1. Установить [dash style](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/linedashstyle/) линии.
1. Задать цвет линии для фигурки.
1. Сохранить изменённую презентацию как файл PPTX.

Ниже приведён код, демонстрирующий форматирование прямоугольника `AutoShape`:

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

![Отформатированные линии в презентации](formatted-lines.png)

## **Применение эффектов «рисунок от руки» к линиям фигурки**

Эффект «рисунок от руки» делает линию фигурки выглядящей нарисованной вручную. Используйте [IShape.getLineFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/) для доступа к параметрам линии, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilineformat/) для доступа к настройкам эффекта, и [ISketchFormat.setSketchType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isketchformat/) для выбора значения из перечисления [LineSketchType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/linesketchtype/).

Ниже Java‑код, показывающий применение эффекта [LineSketchType.Curved](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/linesketchtype/), чтение явно установленного значения и удаление эффекта с помощью [LineSketchType.None](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/linesketchtype/):

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // Получить доступ к формату линии фигурки и её формату эскиза.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // Применить эффект эскиза.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // Прочитать эффект эскиза, назначенный напрямую фигурке.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // Удалить эффект эскиза.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

Значение, возвращаемое [ISketchFormat.getSketchType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isketchformat/), представляет настройку, назначенную непосредственно фигурке. Если форматирование линии может наследоваться из темы, шаблона мастера или макета слайда, используйте [ILineFormat.getEffective](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilineformat/), доступ к [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilineformateffectivedata/), и чтение [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isketchformateffectivedata/). Эффективное значение отражает фактическое применённое форматирование после разрешения наследования:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    ILineFormat lineFormat = shape.getLineFormat();

    int explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    ILineFormatEffectiveData effectiveLineFormat = lineFormat.getEffective();
    int effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    System.out.println("Explicit sketch type: " + explicitSketchType);
    System.out.println("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **Форматирование стилей соединения**

Доступны три варианта типа соединения:

* Round
* Miter
* Bevel

По умолчанию PowerPoint использует настройку **Round**, когда соединяет две линии под углом (например, в углу фигурки). Однако при рисовании фигурки с острыми углами может быть предпочтительно использовать **Miter**.

![Стиль соединения в презентации](join-style-powerpoint.png)

Ниже Java‑код, демонстрирующий, как три прямоугольника (см. изображение выше) были созданы с использованием настроек соединения Miter, Bevel и Round:

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

    // Задать ширину линии.
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

    // Задать стиль соединения.
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

## **Градиентная заливка**

В PowerPoint градиентная заливка — это параметр форматирования, позволяющий применить к фигурке плавный переход цветов. Например, можно задать два и более цвета так, чтобы один постепенно переходил в другой.

Как применить градиентную заливку к фигурке с помощью Aspose.Slides:

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/).
1. Получить ссылку на слайд по его индексу.
1. Добавить [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/) на слайд.
1. Установить свойство [FillType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/filltype/) фигурки в `Gradient`.
1. Добавить два желаемых цвета с заданными позициями, используя методы `add` коллекции градиентных остановок, доступной через интерфейс [IGradientFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/igradientformat/).
1. Сохранить изменённую презентацию как файл PPTX.

Ниже Java‑код, демонстрирующий применение градиентной заливки к эллипсу:

```java
// Создать экземпляр класса Presentation, представляющего файл презентации.
Presentation presentation = new Presentation();
try {
    // Получить первый слайд.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Добавить автофигуру типа Ellipse.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Применить градиентное форматирование к эллипсу.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Задать направление градиента.
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

![Эллипс с градиентной заливкой](gradient-fill.png)

## **Заливка узором**

В PowerPoint заливка узором — это параметр форматирования, позволяющий применить к фигурке двуцветный рисунок (точки, полосы, шахматы и т.п.). Вы можете выбрать пользовательские цвета для переднего и фонового плана узора.

Aspose.Slides предоставляет более 45 предопределённых стилей узоров, которые можно применять к фигуркам для улучшения визуального восприятия презентаций. Даже после выбора предопределённого узора вы всё равно можете задать точные цвета, которые он будет использовать.

Как применить заливку узором к фигурке с помощью Aspose.Slides:

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/).
1. Получить ссылку на слайд по его индексу.
1. Добавить [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/) на слайд.
1. Установить свойство [FillType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/filltype/) фигурки в `Pattern`.
1. Выбрать стиль узора из предопределённых вариантов.
1. Задать [Background Color](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/patternformat/#getBackColor--) узора.
1. Задать [Foreground Color](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/patternformat/#getForeColor--) узора.
1. Сохранить изменённую презентацию как файл PPTX.

Ниже Java‑код, демонстрирующий применение заливки узором к прямоугольнику:

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

    // Установить фоновые и передние цвета узора.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // Сохранить файл PPTX на диск.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Прямоугольник с узорной заливкой](pattern-fill.png)

## **Заливка изображением**

В PowerPoint заливка изображением — это параметр форматирования, позволяющий вставить изображение внутрь фигурки, фактически используя его в качестве фоновой части фигурки.

Как воспользоваться Aspose.Slides для применения заливки изображением к фигурке:

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/).
1. Получить ссылку на слайд по его индексу.
1. Добавить [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/) на слайд.
1. Установить свойство [FillType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/filltype/) фигурки в `Picture`.
1. Задать режим заливки изображения в `Tile` (или любой другой предпочтительный режим).
1. Создать объект [IPPImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ippimage/) из изображения, которое планируется использовать.
1. Передать изображение методу `ISlidesPicture.setImage`.
1. Сохранить изменённую презентацию как файл PPTX.

Предположим, у нас есть файл «lotus.png» со следующим изображением:

![Изображение лотоса](lotus.png)

Ниже Java‑код, показывающий, как заполнить фигурку изображением:

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

![Фигурка с заливкой изображением](picture-fill.png)

### **Тайловое изображение как текстура**

Если нужно задать тайловое изображение в качестве текстуры и настроить поведение тайлинга, используйте следующие методы интерфейса [IPictureFillFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipicturefillformat/) и класса [PictureFillFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): задаёт режим заливки изображением — `Tile` или `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): задаёт выравнивание тайлов внутри фигурки.
- [setTileFlip](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): управляет тем, будет ли тайл отражён по горизонтали, вертикали или обоим направлениям.
- [setTileOffsetX](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): задаёт горизонтальное смещение тайла (в пунктах) от начала координат фигурки.
- [setTileOffsetY](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): задаёт вертикальное смещение тайла (в пунктах) от начала координат фигурки.
- [setTileScaleX](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): определяет горизонтальный масштаб тайла в процентах.
- [setTileScaleY](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): определяет вертикальный масштаб тайла в процентах.

Ниже пример кода, показывающий, как добавить прямоугольник с тайловой заливкой изображением и настроить параметры тайла:

```java
// Создать экземпляр класса Presentation, представляющего файл презентации.
Presentation presentation = new Presentation();
try {
    // Получить первый слайд.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Добавить автофигуру типа Rectangle.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Установить тип заливки фигурки в Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Загрузить изображение и добавить его в ресурсы презентации.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Назначить изображение фигурке.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Настроить режим заливки изображением и свойства тайлинга.
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

![Параметры тайлинга](tile-options.png)

## **Сплошная заливка цветом**

В PowerPoint сплошная заливка цветом — это параметр форматирования, который заполняет фигурку одним ровным цветом без градиентов, текстур или узоров.

Чтобы применить сплошную заливку цветом к фигурке с помощью Aspose.Slides, выполните следующие шаги:

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/).
1. Получить ссылку на слайд по его индексу.
1. Добавить [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/) на слайд.
1. Установить свойство [FillType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/filltype/) фигурки в `Solid`.
1. Назначить желаемый цвет заливки фигурке.
1. Сохранить изменённую презентацию как файл PPTX.

Ниже Java‑код, демонстрирующий применение сплошной заливки к прямоугольнику в слайде PowerPoint:

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

![Фигурка со сплошной заливкой цветом](solid-color-fill.png)

## **Установка прозрачности**

В PowerPoint при применении сплошного цвета, градиента, изображения или текстуры к фигуркам можно также задать уровень прозрачности, контролирующий непрозрачность заливки. Чем выше значение прозрачности, тем более «прозрачной» становится фигурка, позволяя видеть фон или находящиеся под ней объекты.

Aspose.Slides позволяет задать уровень прозрачности, изменяя альфа‑компонент цвета, используемого для заливки. Как это сделать:

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/).
1. Получить ссылку на слайд по его индексу.
1. Добавить [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/) на слайд.
1. Установить [FillType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/filltype/) в `Solid`.
1. Использовать `Color` для определения цвета с заданной прозрачностью (компонент `alpha` управляет прозрачностью).
1. Сохранить презентацию.

Ниже Java‑код, показывающий, как применить прозрачный цвет заливки к прямоугольнику:

```java
// Создать экземпляр класса Presentation, представляющего файл презентации.
Presentation presentation = new Presentation();
try {
    // Получить первый слайд.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Добавить сплошную автофигуру прямоугольника.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Добавить прозрачную автофигуру прямоугольника поверх сплошной фигурки.
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

![Прозрачная фигурка](shape-transparency.png)

## **Поворот фигурок**

Aspose.Slides позволяет поворачивать фигурки в презентациях PowerPoint. Это может быть полезно при размещении визуальных элементов с определёнными требованиями к выравниванию или дизайну.

Чтобы повернуть фигурку на слайде, выполните следующие действия:

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/).
1. Получить ссылку на слайд по его индексу.
1. Добавить [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/) на слайд.
1. Установить свойство поворота фигурки на нужный угол.
1. Сохранить презентацию.

Ниже Java‑код, демонстрирующий поворот фигурки на 5 градусов:

```java
// Создать экземпляр класса Presentation, представляющего файл презентации.
Presentation presentation = new Presentation();
try {
    // Получить первый слайд.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Добавить автофигуру типа Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Повернуть фигурку на 5 градусов.
    shape.setRotation(5);

    // Сохранить файл PPTX на диск.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Поворот фигурки](shape-rotation.png)

## **Добавление 3D‑эффекта фаски**

Aspose.Slides позволяет применять 3D‑фаску к фигуркам, настраивая их свойства [ThreeDFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/threedformat/).

Чтобы добавить 3D‑фаску к фигурке, выполните следующие шаги:

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/).
1. Получить ссылку на слайд по его индексу.
1. Добавить [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/) на слайд.
1. Настроить свойства [ThreeDFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/threedformat/) фигурки для задания параметров фаски.
1. Сохранить презентацию.

Ниже Java‑код, показывающий, как применить 3D‑фаску к фигурке:

```java
// Создать экземпляр класса Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Добавить фигурку на слайд.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE);
    shape.getLineFormat().setWidth(2.0);

    // Установить свойства ThreeDFormat фигурки.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    // Сохранить презентацию в файл PPTX.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Эффект 3D‑фаски](3D-bevel-effect.png)

## **Добавление 3D‑поворота**

Aspose.Slides позволяет применять 3D‑поворот к фигуркам, настраивая их свойства [ThreeDFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/threedformat/).

Чтобы применить 3D‑поворот к фигурке:

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/).
1. Получить ссылку на слайд по его индексу.
1. Добавить [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/) на слайд.
1. Использовать методы [setCameraType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/icamera/#setCameraType-int-) и [setLightType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) для определения 3D‑поворота.
1. Сохранить презентацию.

Ниже Java‑код, демонстрирующий применение 3D‑поворота к фигурке:

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

    // Сохранить презентацию в файл PPTX.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Эффект 3D‑поворота](3D-rotation-effect.png)

## **Сброс форматирования**

Ниже Java‑код, показывающий, как сбросить форматирование слайда и восстановить позицию, размер и форматирование всех фигурок с заполнителями на [LayoutSlide](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/layoutslide/) до их значений по умолчанию:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Сбросить каждую фигурку на слайде, у которой есть заполнитель в макете.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Вопросы и ответы**

**Влияет ли форматирование фигурок на конечный размер файла презентации?**

Практически не влияет. Основную часть места занимают встроенные изображения и мультимедиа, тогда как параметры фигурок (цвета, эффекты, градиенты) хранятся как метаданные и почти не увеличивают размер файла.

**Как определить фигурки на слайде, которые имеют одинаковое форматирование, чтобы сгруппировать их?**

Сравните ключевые свойства форматирования каждой фигурки — параметры заливки, линии и эффекты. Если все соответствующие значения совпадают, их стили можно считать одинаковыми и логически сгруппировать, что упростит последующее управление стилями.

**Можно ли сохранить набор пользовательских стилей фигурок в отдельный файл для повторного использования в других презентациях?**

Да. Сохраните образцы фигурок с нужными стилями в шаблонном наборе слайдов или файле шаблона .POTX. При создании новой презентации откройте шаблон, клонируйте требуемые стилизованные фигурки и примените их форматирование там, где это необходимо.