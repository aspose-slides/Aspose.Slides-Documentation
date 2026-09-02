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
- эскиз линии фигуры
- форматирование стиля соединения
- градиентная заливка
- заполнение узором
- заполнение картинкой
- заполнение текстурой
- сплошная заливка цветом
- прозрачность фигуры
- черно-белая отрисовка фигуры
- отображение фигуры в градациях серого
- поворот фигуры
- 3D-скос
- 3D-поворот
- сброс форматирования
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Узнайте, как форматировать фигуры PowerPoint в Java с помощью Aspose.Slides — задавайте стили заливки, линии и эффектов для файлов PPT, PPTX и ODP с точностью и полным контролем."
---
## **Введение**

В PowerPoint вы можете добавлять фигуры на слайды. Поскольку фигуры состоят из линий, их можно форматировать, изменяя или применяя эффекты к контуру. Кроме того, вы можете форматировать фигуры, задавая параметры, которые определяют, как заполняется их внутренняя часть.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Java предоставляет интерфейсы и методы, позволяющие форматировать фигуры с использованием тех же параметров, что доступны в PowerPoint.

## **Форматирование линий**

Используя Aspose.Slides, вы можете задать пользовательский стиль линии для фигуры. Ниже приведена последовательность действий:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape/) на слайд.
1. Установите [стиль линии](https://reference.aspose.com/slides/ru/java/com.aspose.slides/linestyle/) фигуры.
1. Установите ширину линии.
1. Установите [стиль пунктиров](https://reference.aspose.com/slides/ru/java/com.aspose.slides/linedashstyle/) линии.
1. Установите цвет линии для фигуры.
1. Сохраните изменённую презентацию в файл PPTX.

Следующий код демонстрирует, как отформатировать прямоугольный `AutoShape`:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Создайте экземпляр класса Presentation, представляющего файл презентации.
Presentation presentation = new Presentation();
try {
    // Получите первый слайд.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Добавьте автофигуру типа Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Установите цвет заливки для прямоугольной фигуры.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // Примените форматирование к линиям прямоугольника.
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // Установите цвет линии прямоугольника.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Сохраните файл PPTX на диск.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Отформатированные линии в презентации](formatted-lines.png)

## **Применение эффектов эскиза к линиям фигур**

Эффект эскиза делает линию фигуры выглядящей как нарисованную от руки. Используйте [IShape.getLineFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishape/) для доступа к настройкам линии, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ilineformat/) для доступа к настройкам эскиза и [ISketchFormat.setSketchType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isketchformat/) для выбора значения из перечисления [LineSketchType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/linesketchtype/).

Следующий Java‑код показывает, как применить эффект [LineSketchType.Curved](https://reference.aspose.com/slides/ru/java/com.aspose.slides/linesketchtype/), прочитать явно заданное значение и удалить эффект с помощью [LineSketchType.None](https://reference.aspose.com/slides/ru/java/com.aspose.slides/linesketchtype/):

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // Доступ к формату линии фигуры и её формату эскиза.
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

Значение, возвращаемое [ISketchFormat.getSketchType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isketchformat/), представляет настройку, назначенную непосредственно фигуре. Если форматирование линии может наследоваться от темы, шаблона слайда или макета слайда, используйте [ILineFormat.getEffective](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ilineformat/), получите доступ к [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ilineformateffectivedata/), и прочитайте [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isketchformateffectivedata/). Эффективное значение отражает форматирование, которое действительно применяется после разрешения наследования:

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

## **Форматирование стилей соединений**

Вот три варианта типа соединения:

* Круглый
* Срез
* Фаска

По умолчанию, когда PowerPoint соединяет две линии под углом (например, в углу фигуры), используется настройка **Круглый**. Однако если вы рисуете фигуру с острыми углами, вам может подойти вариант **Срез**.

![Стиль соединения в презентации](join-style-powerpoint.png)

Следующий Java‑код демонстрирует, как были созданы три прямоугольника (как показано на изображении выше) с использованием настроек типов соединения Срез, Фаска и Круглый:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

В PowerPoint градиентная заливка — это параметр форматирования, позволяющий применить к фигуре плавный переход цветов. Например, можно задать два и более цветов, где один постепенно переходит в другой.

Как применить градиентную заливку к фигуре с помощью Aspose.Slides:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape/) на слайд.
1. Установите [FillType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/filltype/) фигуры в `Gradient`.
1. Добавьте два выбранных цвета с определёнными положениями, используя методы `add` коллекции градиентных остановок, представленной интерфейсом [IGradientFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/igradientformat/).
1. Сохраните изменённую презентацию в файл PPTX.

Следующий Java‑код демонстрирует, как применить градиентный эффект к эллипсу:

```java
import com.aspose.slides.*;

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

    // Добавьте две остановки градиента.
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

В PowerPoint заливка узором — это параметр форматирования, позволяющий применить к фигуре двухцветный дизайн, такой как точки, полосы, перекрёстные штрихи или шахматы. Вы можете выбрать собственные цвета для переднего и заднего плана узора.

Aspose.Slides предоставляет более 45 предопределённых стилей узоров, которые можно применять к фигурам для улучшения визуального восприятия презентаций. Даже после выбора предопределённого узора вы можете указать точные цвета, которые он будет использовать.

Как применить заливку узором к фигуре с помощью Aspose.Slides:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape/) на слайд.
1. Установите [FillType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/filltype/) фигуры в `Pattern`.
1. Выберите стиль узора из предопределённых вариантов.
1. Установите [Background Color](https://reference.aspose.com/slides/ru/java/com.aspose.slides/patternformat/#getBackColor--) узора.
1. Установите [Foreground Color](https://reference.aspose.com/slides/ru/java/com.aspose.slides/patternformat/#getForeColor--) узора.
1. Сохраните изменённую презентацию в файл PPTX.

Следующий Java‑код демонстрирует, как применить заливку узором к прямоугольнику:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

    // Установите цвета фона и переднего плана узора.
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

## **Заливка картинкой**

В PowerPoint заливка картинкой — это параметр форматирования, позволяющий вставить изображение внутрь фигуры, эффективно используя его как фон фигуры.

Как использовать Aspose.Slides для применения заливки картинкой к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape/) на слайд.
1. Установите [FillType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/filltype/) фигуры в `Picture`.
1. Установите режим заливки картинкой в `Tile` (или другой предпочтительный режим).
1. Создайте объект [IPPImage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ippimage/) из изображения, которое хотите использовать.
1. Передайте изображение методу `ISlidesPicture.setImage`.
1. Сохраните изменённую презентацию в файл PPTX.

Предположим, у нас есть файл «lotus.png» со следующим изображением:

![The lotus picture](lotus.png)

Следующий Java‑код демонстрирует, как заполнить фигуру картинкой:

```java
import com.aspose.slides.*;

// Создайте экземпляр класса Presentation, представляющего файл презентации.
Presentation presentation = new Presentation();
try {
    // Получите первый слайд.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Добавьте автофигуру типа Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Установите тип заливки в Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Установите режим заливки картинкой.
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

![Фигура с заливкой картинкой](picture-fill.png)

### **Плитка изображения как текстура**

Если вы хотите задать плиточное изображение в качестве текстуры и настроить поведение плитки, используйте следующие методы интерфейса [IPictureFillFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipicturefillformat/) и класса [PictureFillFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): задаёт режим заливки картинкой — `Tile` или `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): определяет выравнивание плиток внутри фигуры.
- [setTileFlip](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): управляет тем, будет ли плитка отражена по горизонтали, вертикали или обеим сторонам.
- [setTileOffsetX](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): задаёт горизонтальное смещение плитки (в пунктах) от начала фигуры.
- [setTileOffsetY](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): задаёт вертикальное смещение плитки (в пунктах) от начала фигуры.
- [setTileScaleX](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): определяет горизонтальный масштаб плитки в процентах.
- [setTileScaleY](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): определяет вертикальный масштаб плитки в процентах.

Следующий пример кода показывает, как добавить прямоугольную фигуру с плиточной заливкой изображением и настроить параметры плитки:

```java
import com.aspose.slides.*;

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

    // Присвойте изображение фигуре.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Настройте режим заливки картинкой и свойства плитки.
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

## **Сплошная заливка цветом**

В PowerPoint сплошная заливка цветом — это параметр форматирования, заполняющий фигуру единым одинаковым цветом. Этот однотонный фон применяется без градиентов, текстур или узоров.

Чтобы применить сплошную заливку цветом к фигуре с помощью Aspose.Slides, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape/) на слайд.
1. Установите [FillType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/filltype/) фигуры в `Solid`.
1. Назначьте желаемый цвет заливки фигуре.
1. Сохраните изменённую презентацию в файл PPTX.

Следующий Java‑код демонстрирует, как применить сплошную заливку цветом к прямоугольнику в PowerPoint‑слайде:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

![Фигура со сплошной заливкой цветом](solid-color-fill.png)

## **Установка прозрачности**

В PowerPoint при применении сплошной, градиентной, картинной или текстурной заливки к фигурам вы также можете задать уровень прозрачности, контролирующий непрозрачность заливки. Чем выше значение прозрачности, тем более просвечивающей будет фигура, позволяя частично видеть фон или нижележащие объекты.

Aspose.Slides позволяет установить уровень прозрачности, изменяя альфа‑компонент в цвете, используемом для заливки. Как это сделать:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape/) на слайд.
1. Установите [FillType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/filltype/) в `Solid`.
1. Используйте `Color` для определения цвета с прозрачностью (компонент `alpha` контролирует прозрачность).
1. Сохраните презентацию.

Следующий Java‑код демонстрирует, как применить прозрачный цвет заливки к прямоугольнику:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Создайте экземпляр класса Presentation, представляющего файл презентации.
Presentation presentation = new Presentation();
try {
    // Получите первый слайд.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Добавьте автофигуру прямоугольника с сплошной заливкой.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Добавьте автофигуру прозрачного прямоугольника поверх сплошной фигуры.
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

## **Вращение фигур**

Aspose.Slides позволяет вращать фигуры в презентациях PowerPoint. Это может быть полезно при размещении визуальных элементов с определёнными требованиями к выравниванию или дизайну.

Чтобы вращать фигуру на слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape/) на слайд.
1. Установите свойство вращения фигуры на нужный угол.
1. Сохраните презентацию.

Следующий Java‑код демонстрирует, как повернуть фигуру на 5 градусов:

```java
import com.aspose.slides.*;

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

## **Добавление 3D‑скосов**

Aspose.Slides позволяет применять 3D‑скосы к фигурам, настраивая их свойства [ThreeDFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/threedformat/).

Чтобы добавить 3D‑скосы к фигуре, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape/) на слайд.
1. Настройте [ThreeDFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/threedformat/) фигуры, задав параметры скосов.
1. Сохраните презентацию.

Следующий Java‑код показывает, как применить 3D‑скосы к фигуре:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

    // Установите свойства ThreeDFormat фигуры.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    // Сохраните презентацию в файл PPTX.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Эффект 3D‑скоса](3D-bevel-effect.png)

## **Добавление 3D‑поворотов**

Aspose.Slides позволяет применять 3D‑повороты к фигурам, настраивая их свойства [ThreeDFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/threedformat/).

Чтобы применить 3D‑поворот к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape/) на слайд.
1. Используйте [setCameraType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/icamera/#setCameraType-int-) и [setLightType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ilightrig/#setLightType-int-) для определения 3D‑поворота.
1. Сохраните презентацию.

Следующий Java‑код демонстрирует, как применить 3D‑поворот к фигуре:

```java
import com.aspose.slides.*;

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

    // Сохраните презентацию в файл PPTX.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Эффект 3D‑поворота](3D-rotation-effect.png)

## **Управление черно‑белой отрисовкой фигур**

Метод [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) задаёт, как отдельная фигура будет отрисовываться при просмотре или обработке презентации в черно‑белом режиме. Он не включает черно‑белый режим сам по себе и не меняет заливку, линии или другие параметры форматирования фигуры в обычном цветном режиме.

Для выбора поведения используйте значение из класса [BlackWhiteMode](https://reference.aspose.com/slides/ru/java/com.aspose.slides/blackwhitemode/). Например, `Automatic` позволяет приложению выбора конвертации, `Gray` и `LightGray` используют оттенки серого, `BlackWhite` — только чёрный и белый, `Black` и `White` принудительно задают один цвет, `Color` сохраняет обычные цвета, а `Hidden` скрывает фигуру в черно‑белом режиме. `NotDefined` означает, что режим на уровне фигуры не задан.

Следующий Java‑код создает цветную фигуру и заставляет её отображаться серой при черно‑белом отображении:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    // Сохраните оранжевую заливку в цветном режиме, но отобразите фигуру в оттенках серого в черно-белом режиме.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

В обычном цветном режиме прямоугольник сохраняет оранжевую заливку. При работе в черно‑белом режиме он отображается серым, потому что его режим установлен в `Gray`. Это позволяет сохранять полноцветный слайд, определяя отдельный вид для печати, предварительного просмотра или других процессов, учитывающих настройки черно‑белого отображения презентации.

## **Сброс форматирования**

Следующий Java‑код показывает, как сбросить форматирование слайда и вернуть позицию, размер и форматирование всех фигур с заполнителями на [LayoutSlide](https://reference.aspose.com/slides/ru/java/com.aspose.slides/layoutslide/) к их значениям по умолчанию:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Сбросить каждую фигуру на слайде, имеющую заполнитель в макете.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Влияет ли форматирование фигур на конечный размер файла презентации?**

Только незначительно. Встроенные изображения и мультимедиа занимают большую часть места, тогда как параметры фигур, такие как цвета, эффекты и градиенты, хранятся как метаданные и практически не увеличивают размер файла.

**Как обнаружить фигуры на слайде, имеющие идентичное форматирование, чтобы сгруппировать их?**

Сравните ключевые свойства форматирования каждой фигуры — параметры заливки, линии и эффектов. Если все соответствующие значения совпадают, рассматривайте их стили как одинаковые и логически группируйте такие фигуры, что упрощает последующее управление стилями.

**Можно ли сохранить набор пользовательских стилей фигур в отдельный файл для повторного использования в других презентациях?**

Да. Сохраните образцы фигур с нужными стилями в шаблонный набор слайдов или в файл шаблона *.POTX*. При создании новой презентации откройте шаблон, клонируйте необходимые стилизованные фигуры и повторно примените их форматирование там, где это требуется.