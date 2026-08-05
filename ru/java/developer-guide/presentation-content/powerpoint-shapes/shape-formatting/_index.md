---
title: Форматирование фигур PowerPoint в Java
linktitle: Форматирование фигур
type: docs
weight: 20
url: /ru/java/shape-formatting/
keywords:
- форматирование фигуры
- форматирование линии
- эффект эскиза
- линия фигуры в виде эскиза
- форматировать стиль соединения
- градиентная заливка
- заливка узором
- заливка изображением
- заливка текстурой
- сплошная заливка
- прозрачность фигуры
- вращение фигуры
- 3d-скошенный эффект
- 3d-вращение
- сброс форматирования
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Узнайте, как форматировать фигуры PowerPoint на Java с помощью Aspose.Slides — задавайте стили заливки, линии и эффектов для файлов PPT, PPTX и ODP с точностью и полным контролем."
---
## **Введение**

В PowerPoint вы можете добавлять фигуры на слайды. Поскольку фигуры состоят из линий, вы можете форматировать их, изменяя или применяя эффекты к их контурам. Кроме того, вы можете форматировать фигуры, задавая параметры, контролирующие заливку их внутренней области.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Java предоставляет интерфейсы и методы, позволяющие форматировать фигуры с использованием тех же параметров, что доступны в PowerPoint.

## **Форматирование линий**

С помощью Aspose.Slides вы можете задать пользовательский стиль линии для фигуры. Ниже перечислены шаги процесса:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/) .
1. Получите ссылку на слайд по его индексу.
1. Добавьте на слайд [IAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape/) .
1. Задайте [line style](https://reference.aspose.com/slides/ru/java/com.aspose.slides/linestyle/) фигуры.
1. Установите ширину линии.
1. Установите [dash style](https://reference.aspose.com/slides/ru/java/com.aspose.slides/linedashstyle/) линии.
1. Задайте цвет линии для фигуры.
1. Сохраните изменённую презентацию как файл PPTX.

Ниже показан код, демонстрирующий, как отформатировать прямоугольник `AutoShape`:

```java
// Создайте экземпляр класса Presentation, представляющего файл презентации.
    // Получите первый слайд.
    // Добавьте автофигуру типа Rectangle.
    // Установите цвет заливки для прямоугольной фигуры.
    // Примените форматирование к линиям прямоугольника.
    // Установите цвет линии прямоугольника.
    // Сохраните файл PPTX на диск.
Presentation presentation = new Presentation();
try {
    // Get the first slide.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Add an auto shape of the Rectangle type.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Set the fill color for the rectangle shape.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // Apply formatting to the rectangle's lines.
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // Set the color for the rectangle's line.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Save the PPTX file to disk.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Отформатированные линии в презентации](formatted-lines.png)

## **Применение эффектов эскиза к линиям фигур**

Эффект эскиза делает линию фигуры выглядящей нарисованной от руки. Используйте [IShape.getLineFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishape/) для доступа к параметрам линии, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ilineformat/) для доступа к настройкам эскиза и [ISketchFormat.setSketchType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isketchformat/) для выбора значения из перечисления [LineSketchType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/linesketchtype/) .

Ниже Java‑код, показывающий, как применить эффект [LineSketchType.Curved](https://reference.aspose.com/slides/ru/java/com.aspose.slides/linesketchtype/), прочитать явно заданное значение и удалить эффект с помощью [LineSketchType.None](https://reference.aspose.com/slides/ru/java/com.aspose.slides/linesketchtype/) :

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // Получить доступ к формату линии фигуры и её формату эскиза.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // Применить эффект эскиза.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // Прочитать эффект эскиза, назначенный напрямую фигуре.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // Удалить эффект эскиза.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

Значение, возвращаемое [ISketchFormat.getSketchType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isketchformat/), представляет параметр, назначенный непосредственно фигуре. Если форматирование линии может быть унаследовано из темы, главного слайда или макета, используйте [ILineFormat.getEffective](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ilineformat/), обратитесь к [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ilineformateffectivedata/), а затем к [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isketchformateffectivedata/). Эффективное значение отражает фактическое форматирование после разрешения наследования:

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

Существует три варианта типа соединения:

* Round
* Miter
* Bevel

По умолчанию, когда PowerPoint соединяет две линии под углом (например, в углу фигуры), используется настройка **Round**. Однако при рисовании фигур с острыми углами может быть предпочтительнее вариант **Miter**.

![Стиль соединения в презентации](join-style-powerpoint.png)

Ниже Java‑код, демонстрирующий, как три прямоугольника (как показано на изображении выше) были созданы с использованием настроек соединения Miter, Bevel и Round :

```java
// Создайте экземпляр класса Presentation, представляющего файл презентации.
Presentation presentation = new Presentation();
try {
    // Получите первый слайд.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Добавьте три автофигуры типа Rectangle.
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Установите цвет заливки для каждой прямоугольной фигуры.
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // Установите ширину линии.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // Установите цвет линии для каждого прямоугольника.
    shape1.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape3.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Установите стиль соединения.
    shape1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shape2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shape3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // Добавьте текст к каждому прямоугольнику.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // Сохраните файл PPTX на диск.
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Градиентная заливка**

В PowerPoint градиентная заливка — это параметр форматирования, позволяющий применить плавный переход цветов к фигуре. Например, вы можете задать две и более цветов, где один постепенно переходит в другой.

Как применить градиентную заливку к фигуре с помощью Aspose.Slides:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/) .
1. Получите ссылку на слайд по его индексу.
1. Добавьте на слайд [IAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape/) .
1. Установите для фигуры [FillType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/filltype/) значение `Gradient`.
1. Добавьте два желаемых цвета с заданными позициями, используя методы `add` коллекции градиентных остановок, предоставляемой интерфейсом [IGradientFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/igradientformat/) .
1. Сохраните изменённую презентацию как файл PPTX.

Ниже Java‑код, демонстрирующий, как применить эффект градиентной заливки к эллипсу:

```java
// Создайте экземпляр класса Presentation, представляющего файл презентации.
Presentation presentation = new Presentation();
try {
    // Получите первый слайд.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Добавьте автофигуру типа Ellipse.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Примените градиентное форматирование к эллипсу.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Установите направление градиента.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // Добавьте две градиентные остановки.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // Сохраните файл PPTX на диск.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Эллипс с градиентной заливкой](gradient-fill.png)

## **Заливка узором**

В PowerPoint заливка узором — это параметр форматирования, позволяющий применить двухцветный рисунок (точки, полосы, штриховку или клетки) к фигуре. Вы можете задать собственные цвета для переднего и заднего плана узора.

Aspose.Slides предлагает более 45 предопределённых стилей узоров, которые можно применять к фигурам для повышения визуальной привлекательности презентаций. Даже после выбора предопределённого узора вы всё равно можете указать точные цвета, которые он будет использовать.

Как применить заливку узором к фигуре с помощью Aspose.Slides:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/) .
1. Получите ссылку на слайд по его индексу.
1. Добавьте на слайд [IAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape/) .
1. Установите для фигуры [FillType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/filltype/) значение `Pattern`.
1. Выберите стиль узора из предопределённых вариантов.
1. Задайте [Background Color](https://reference.aspose.com/slides/ru/java/com.aspose.slides/patternformat/#getBackColor--) узора.
1. Задайте [Foreground Color](https://reference.aspose.com/slides/ru/java/com.aspose.slides/patternformat/#getForeColor--) узора.
1. Сохраните изменённую презентацию как файл PPTX.

Ниже Java‑код, демонстрирующий, как применить заливку узором к прямоугольнику:

```java
// Создайте экземпляр класса Presentation, представляющего файл презентации.
Presentation presentation = new Presentation();
try {
    // Получите первый слайд.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Добавьте автофигуру типа Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Установите тип заливки в Pattern.
    shape.getFillFormat().setFillType(FillType.Pattern);

    // Установите стиль узора.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // Установите фон и передний цвет узора.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // Сохраните файл PPTX на диск.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Прямоугольник с узорной заливкой](pattern-fill.png)

## **Заливка изображением**

В PowerPoint заливка изображением — это параметр форматирования, позволяющий вставить изображение внутрь фигуры, использовав его в качестве фона.

Как использовать Aspose.Slides для применения заливки изображением к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/) .
1. Получите ссылку на слайд по его индексу.
1. Добавьте на слайд [IAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape/) .
1. Установите для фигуры [FillType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/filltype/) значение `Picture`.
1. Установите режим заливки изображением в `Tile` (или любой другой предпочтительный режим).
1. Создайте объект [IPPImage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ippimage/) из изображения, которое хотите использовать.
1. Передайте изображение в метод `ISlidesPicture.setImage`.
1. Сохраните изменённую презентацию как файл PPTX.

Допустим, у нас есть файл «lotus.png» со следующим изображением:

![Изображение лотоса](lotus.png)

Ниже Java‑код, демонстрирующий, как заполнить фигуру изображением:

```java
// Создайте экземпляр класса Presentation, представляющего файл презентации.
Presentation presentation = new Presentation();
try {
    // Получите первый слайд.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Добавьте автофигуру типа Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Установите тип заливки в Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Установите режим заливки изображением.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // Загрузите изображение и добавьте его в ресурсы презентации.
    IImage image = Images.fromFile("lotus.png");
    IPPImage picture = presentation.getImages().addImage(image);
    image.dispose();

    // Установите изображение.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Сохраните файл PPTX на диск.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Фигура с заливкой изображением](picture-fill.png)

### **Плитка изображения как текстура**

Если требуется задать изображение в виде плитки и настроить её параметры, можно использовать следующие методы интерфейса [IPictureFillFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipicturefillformat/) и класса [PictureFillFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/picturefillformat/) :

- [setPictureFillMode](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) : задаёт режим заливки изображением — `Tile` или `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-) : определяет выравнивание плиток внутри фигуры.
- [setTileFlip](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-) : управляет отражением плитки по горизонтали, вертикали или обеим осям.
- [setTileOffsetX](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-) : задаёт горизонтальное смещение плитки (в пунктах) от начала фигуры.
- [setTileOffsetY](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-) : задаёт вертикальное смещение плитки (в пунктах) от начала фигуры.
- [setTileScaleX](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-) : определяет горизонтальный масштаб плитки в процентах.
- [setTileScaleY](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-) : определяет вертикальный масштаб плитки в процентах.

Ниже пример кода, показывающий, как добавить прямоугольную фигуру с заливкой изображением‑плиткой и настроить параметры плитки:

```java
// Создайте экземпляр класса Presentation, представляющего файл презентации.
Presentation presentation = new Presentation();
try {
    // Получите первый слайд.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Добавьте автофигуру прямоугольника.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Установите тип заливки фигуры в Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Загрузите изображение и добавьте его в ресурсы презентации.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Назначьте изображение фигуре.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Настройте режим заливки изображением и свойства замощения.
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    // Сохраните файл PPTX на диск.
    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Параметры плитки](tile-options.png)

## **Заливка сплошным цветом**

В PowerPoint сплошная заливка — это параметр форматирования, заполняющий фигуру одним ровным цветом. Этот фон задаётся без градиентов, текстур или узоров.

Для применения сплошной заливки к фигуре с помощью Aspose.Slides выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/) .
1. Получите ссылку на слайд по его индексу.
1. Добавьте на слайд [IAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape/) .
1. Установите для фигуры [FillType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/filltype/) значение `Solid`.
1. Назначьте желаемый цвет заливки.
1. Сохраните изменённую презентацию как файл PPTX.

Ниже Java‑код, демонстрирующий, как применить сплошную заливку к прямоугольнику в слайде PowerPoint:

```java
// Создайте экземпляр класса Presentation, представляющего файл презентации.
Presentation presentation = new Presentation();
try {
    // Получите первый слайд.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Добавьте автофигуру типа Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Установите тип заливки в Solid.
    shape.getFillFormat().setFillType(FillType.Solid);

    // Установите цвет заливки.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // Сохраните файл PPTX на диск.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Фигура со сплошной заливкой](solid-color-fill.png)

## **Установка прозрачности**

В PowerPoint, применяя сплошную заливку, градиент, изображение или текстуру к фигурам, можно также задать уровень прозрачности, контролирующий непрозрачность заливки. Более высокий коэффициент прозрачности делает фигуру более просвечивающей, позволяя частично видеть фон или находящиеся под ней объекты.

Aspose.Slides позволяет установить уровень прозрачности, изменяя альфа‑компоненту цвета, используемого для заливки. Как это сделать:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/) .
1. Получите ссылку на слайд по его индексу.
1. Добавьте на слайд [IAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape/) .
1. Установите [FillType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/filltype/) в значение `Solid`.
1. Используйте `Color`, задав цвет с прозрачностью (компонент `alpha` определяет степень прозрачности).
1. Сохраните презентацию.

Ниже Java‑код, демонстрирующий, как задать прозрачный цвет заливки для прямоугольника:

```java
// Создайте экземпляр класса Presentation, представляющего файл презентации.
Presentation presentation = new Presentation();
try {
    // Получите первый слайд.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Добавьте автофигуру прямоугольника со сплошной заливкой.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Добавьте автофигуру прямоугольника с прозрачностью над сплошной фигурой.
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // Сохраните файл PPTX на диск.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Прозрачная фигура](shape-transparency.png)

## **Поворот фигур**

Aspose.Slides позволяет вращать фигуры в презентациях PowerPoint. Это может быть полезно при позиционировании визуальных элементов с требуемым выравниванием или дизайном.

Для вращения фигуры на слайде выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/) .
1. Получите ссылку на слайд по его индексу.
1. Добавьте на слайд [IAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape/) .
1. Установите свойство вращения фигуры на требуемый угол.
1. Сохраните презентацию.

Ниже Java‑код, демонстрирующий, как повернуть фигуру на 5 градусов:

```java
// Создайте экземпляр класса Presentation, представляющего файл презентации.
Presentation presentation = new Presentation();
try {
    // Получите первый слайд.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Добавьте автофигуру типа Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Поверните фигуру на 5 градусов.
    shape.setRotation(5);

    // Сохраните файл PPTX на диск.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Вращение фигуры](shape-rotation.png)

## **Добавление 3D-скошенных эффектов**

Aspose.Slides позволяет применять к фигурам 3D‑скошенные эффекты, задавая свойства их [ThreeDFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/threedformat/) .

Для добавления 3D‑скошенных эффектов к фигуре выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/) .
1. Получите ссылку на слайд по его индексу.
1. Добавьте на слайд [IAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape/) .
1. Настройте [ThreeDFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/threedformat/) фигуры, указав параметры скоса.
1. Сохраните презентацию.

Ниже Java‑код, показывающий, как применить 3D‑скошенные эффекты к фигуре:

```java
// Создайте экземпляр класса Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Добавьте фигуру на слайд.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE);
    shape.getLineFormat().setWidth(2.0);

    // Задайте свойства ThreeDFormat фигуры.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    // Сохраните презентацию как файл PPTX.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Эффект 3D‑скошения](3D-bevel-effect.png)

## **Добавление 3D-эффектов вращения**

Aspose.Slides позволяет применять к фигурам 3D‑вращения, задавая свойства их [ThreeDFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/threedformat/) .

Для применения 3D‑вращения к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/) .
1. Получите ссылку на слайд по его индексу.
1. Добавьте на слайд [IAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape/) .
1. Используйте методы [setCameraType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/icamera/#setCameraType-int-) и [setLightType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ilightrig/#setLightType-int-) для задания 3D‑вращения.
1. Сохраните презентацию.

Ниже Java‑код, демонстрирующий, как применить 3D‑вращение к фигуре:

```java
// Создайте экземпляр класса Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    // Сохраните презентацию как файл PPTX.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Эффект 3D‑вращения](3D-rotation-effect.png)

## **Сброс форматирования**

Ниже Java‑код, показывающий, как сбросить форматирование слайда и вернуть положение, размеры и форматирование всех фигур с заполнителями на [LayoutSlide](https://reference.aspose.com/slides/ru/java/com.aspose.slides/layoutslide/) к их значениям по умолчанию:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Сбросить каждую фигуру на слайде, у которой есть заполнитель в макете.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Влияет ли форматирование фигур на конечный размер файла презентации?**

Только минимально. Встроенные изображения и мультимедиа занимают большую часть пространства файла, тогда как параметры фигур (цвета, эффекты, градиенты) сохраняются как метаданные и практически не увеличивают размер.

**Как обнаружить фигуры на слайде с одинаковым форматированием, чтобы сгруппировать их?**

Сравните ключевые свойства форматирования каждой фигуры — параметры заливки, линии и эффектов. Если все соответствующие значения совпадают, можно считать их стили идентичными и логически сгруппировать такие фигуры, что упрощает последующее управление стилями.

**Можно ли сохранить набор пользовательских стилей фигур в отдельный файл для повторного использования в других презентациях?**

Да. Сохраните образцы фигур с нужными стилями в шаблоне презентации или в файле шаблона .POTX. При создании новой презентации откройте шаблон, клонируйте необходимые стилизованные фигуры и применяйте их форматирование там, где требуется.