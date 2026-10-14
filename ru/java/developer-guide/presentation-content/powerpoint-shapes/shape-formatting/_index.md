---
title: Форматирование фигур PowerPoint в Java
linktitle: Форматирование фигур
type: docs
weight: 20
url: /ru/java/shape-formatting/
keywords:
- формат фигуры
- формат линии
- эффект наброска
- набросок линии фигуры
- форматировать стиль соединения
- градиентная заливка
- заполнение узором
- заполнение изображением
- заполнение текстурой
- заполнение сплошным цветом
- прозрачность фигуры
- чёрно‑белая отрисовка фигур
- отображение фигур в градациях серого
- повернуть фигуру
- эффект 3D‑скос
- эффект 3D‑вращения
- сброс форматирования
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Узнайте, как форматировать фигуры PowerPoint в Java с помощью Aspose.Slides — задавайте стили заливки, линий и эффектов для файлов PPT, PPTX и ODP с точностью и полным контролем."
---
## **Введение**

В PowerPoint вы можете добавлять фигуры на слайды. Поскольку фигуры состоят из линий, их можно форматировать, изменяя или применяя эффекты к контуру. Кроме того, фигуры можно форматировать, задавая параметры, контролирующие заполнение их внутренностей.

![Форматирование фигуры в PowerPoint](format-shape-powerpoint.png)

Aspose.Slides для Java предоставляет интерфейсы и методы, позволяющие форматировать фигуры, используя те же параметры, что доступны в PowerPoint.

## **Форматирование линий**

С помощью Aspose.Slides вы можете задать пользовательский стиль линии для фигуры. Ниже перечислены шаги процедуры:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) на слайд.
1. Установите [стиль линии](https://reference.aspose.com/slides/java/com.aspose.slides/linestyle/) для фигуры.
1. Установите ширину линии.
1. Установите [стиль штриховки](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/) линии.
1. Установите цвет линии для фигуры.
1. Сохраните изменённую презентацию в файл PPTX.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Создать экземпляр класса Presentation, представляющего файл презентации.
Presentation presentation = new Presentation();
try {
    // Получить первый слайд.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Добавить автофигуру типа Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Установить цвет заливки прямоугольной фигуры.
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

![Отформатированные линии в презентации](formatted-lines.png)

## **Применение эффектов наброска к линиям фигур**

Эффект наброска делает линию фигуры выглядящей как нарисованную вручную. Используйте [IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) для доступа к настройкам линии, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/) для доступа к настройкам наброска и [ISketchFormat.setSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/) для выбора значения из перечисления [LineSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/).

Ниже приведён Java‑код, показывающий, как применить эффект [LineSketchType.Curved](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) , прочитать явно назначенное значение и удалить эффект с помощью [LineSketchType.None](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/):

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // Доступ к формату линии фигуры и её формату наброска.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // Применить эффект наброска.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // Прочитать эффект наброска, назначенный напрямую фигуре.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // Удалить эффект наброска.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

Значение, возвращаемое [ISketchFormat.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/) , представляет настройку, назначенную напрямую фигуре. Если форматирование линии может наследоваться из темы, главного слайда или макета слайда, используйте [ILineFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/), получайте [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformateffectivedata/) и считывайте [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformateffectivedata/). Эффективное значение отражает фактическое применённое форматирование после разрешения наследования:

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
* Скос

По умолчанию, когда PowerPoint соединяет две линии под углом (например, в углу фигуры), он использует настройку **Круглое**. Однако, если вы рисуете фигуру с острыми углами, вам может подойти вариант **Срез**.

![Стиль соединения в презентации](join-style-powerpoint.png)

```java
import com.aspose.slides.*;
import java.awt.Color;

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

    // Установить ширину линии.
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

## **Градиентная заливка**

В PowerPoint градиентная заливка — это параметр форматирования, который позволяет наложить плавный переход цветов на фигуру. Например, можно применить два и более цветов так, чтобы один постепенно переходил в другой.

Следуйте этим шагам, чтобы применить градиентную заливку к фигуре с помощью Aspose.Slides:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) на слайд.
1. Установите [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) фигуры в `Gradient`.
1. Добавьте два предпочтительных цвета с заданными позициями, используя методы `add` коллекции градиентных стопов, доступные через интерфейс [IGradientFormat](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/).
1. Сохраните изменённую презентацию в файл PPTX.

```java
import com.aspose.slides.*;

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

    // Установить направление градиента.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // Добавить два градиентных стопа.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // Сохранить файл PPTX на диск.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Эллипс с градиентной заливкой](gradient-fill.png)

Если градиент выглядит иначе в экспортированном изображении, чем в PowerPoint, см. [Выбрать стиль визуализации градиента](/slides/ru/java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Вы можете выбрать стиль визуализации без изменения градиентной заливки, хранящейся в презентации.

## **Заполнение узором**

В PowerPoint заполнение узором — это параметр форматирования, позволяющий применить двухцветный рисунок (точки, полосы, штриховка или клетки) к фигуре. Вы можете выбрать собственные цвета для переднего и фона узора.

Aspose.Slides предоставляет более 45 предопределённых стилей узоров, которые можно применять к фигурам для улучшения визуального восприятия презентаций. После выбора предопределённого узора вы всё равно можете указать точные цвета, которые он использует.

Следуйте этим шагам, чтобы применить заполнение узором к фигуре с помощью Aspose.Slides:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) на слайд.
1. Установите [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) фигуры в `Pattern`.
1. Выберите стиль узора из предопределённых вариантов.
1. Установите [Background Color](https://reference.aspose.com/slides/java/com.aspose.slides/patternformat/#getBackColor--) узора.
1. Установите [Foreground Color](https://reference.aspose.com/slides/java/com.aspose.slides/patternformat/#getForeColor--) узора.
1. Сохраните изменённую презентацию в файл PPTX.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

![Прямоугольник с узорной заливкой](pattern-fill.png)

## **Заполнение изображением**

В PowerPoint заполнение изображением — это параметр форматирования, позволяющий вставить изображение внутрь фигуры, эффективно используя его в качестве фона фигуры.

Следуйте этим шагам, чтобы с помощью Aspose.Slides применить заполнение изображением к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) на слайд.
1. Установите [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) фигуры в `Picture`.
1. Установите режим заполнения изображения в `Tile` (или другой предпочтительный режим).
1. Создайте объект [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) из изображения, которое хотите использовать.
1. Передайте изображение в метод `ISlidesPicture.setImage`.
1. Сохраните изменённую презентацию в файл PPTX.

![Изображение лотоса](lotus.png)

```java
import com.aspose.slides.*;

// Создать экземпляр класса Presentation, представляющего файл презентации.
Presentation presentation = new Presentation();
try {
    // Получить первый слайд.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Добавить автофигуру типа Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Установить тип заливки в Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Установить режим заполнения изображения.
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

![Фигура с заполнением изображением](picture-fill.png)

### **Повторяющееся изображение как текстура**

Если вы хотите задать повторяющееся изображение как текстуру и настроить поведение повторения, можете использовать следующие методы интерфейса [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) и класса [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Устанавливает режим заполнения изображения — `Tile` или `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Задаёт выравнивание плиток внутри фигуры.
- [setTileFlip](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Управляет отражением плитки по горизонтали, вертикали или обеим осям.
- [setTileOffsetX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Устанавливает горизонтальное смещение плитки (в пунктах) от начала фигуры.
- [setTileOffsetY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Устанавливает вертикальное смещение плитки (в пунктах) от начала фигуры.
- [setTileScaleX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Задает горизонтальный масштаб плитки в процентах.
- [setTileScaleY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Задает вертикальный масштаб плитки в процентах.

```java
import com.aspose.slides.*;

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

    // Назначить изображение фигуре.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Настроить режим заполнения изображением и свойства мозаики.
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

![Опции плитки](tile-options.png)

## **Заполнение сплошным цветом**

В PowerPoint заполнение сплошным цветом — это параметр форматирования, который заполняет фигуру одним равномерным цветом. Этот простой фон применяется без градиентов, текстур или узоров.

Чтобы применить сплошную цветовую заливку к фигуре с помощью Aspose.Slides, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) на слайд.
1. Установите [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) фигуры в `Solid`.
1. Задайте желаемый цвет заливки для фигуры.
1. Сохраните изменённую презентацию в файл PPTX.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

![Фигура со сплошной заливкой](solid-color-fill.png)

## **Установка прозрачности**

В PowerPoint при применении сплошного, градиентного, изображённого или текстурного заполнения к фигурам можно также задать уровень прозрачности, регулируя непрозрачность заливки. Более высокое значение прозрачности делает фигуру более просвечивающей, позволяя частично видеть фон или объекты под ней.

Aspose.Slides позволяет задать уровень прозрачности, меняя альфа‑компонент цвета, используемого для заливки. Делайте так:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) на слайд.
1. Установите [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) фигуры в `Solid`.
1. Используйте `Color` для определения цвета с прозрачностью (альфа‑компонент управляет прозрачностью).
1. Сохраните презентацию.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Создать экземпляр класса Presentation, представляющего файл презентации.
Presentation presentation = new Presentation();
try {
    // Получить первый слайд.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Добавить автофигуру сплошного прямоугольника.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Добавить прозрачную автофигуру прямоугольника поверх сплошной фигуры.
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // Сохранить файл PPTX на диск.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Прозрачная фигура](shape-transparency.png)

## **Поворот фигур**

Aspose.Slides позволяет поворачивать фигуры в презентациях PowerPoint. Это может быть полезно при размещении визуальных элементов с определённым выравниванием или дизайнерскими требованиями.

Чтобы повернуть фигуру на слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) на слайд.
1. Установите свойство вращения фигуры на требуемый угол.
1. Сохраните презентацию.

```java
import com.aspose.slides.*;

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

![Поворот фигуры](shape-rotation.png)

## **Добавление 3D-скосов**

Aspose.Slides позволяет применять 3D‑скосы к фигурам, настраивая их свойства [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/).

Чтобы добавить 3D‑скосы к фигуре, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) на слайд.
1. Настройте [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/) фигуры, указав параметры скоса.
1. Сохраните презентацию.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

![Эффект 3D-скоса](3D-bevel-effect.png)

## **Добавление 3D-вращения**

Aspose.Slides позволяет применять 3D‑вращение к фигурам, настраивая их свойства [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/).

Чтобы применить 3D‑вращение к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) на слайд.
1. Используйте [setCameraType](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setCameraType-int-) и [setLightType](https://reference.aspose.com/slides/java/com.aspose.slides/ilightrig/#setLightType-int-) для определения 3D‑вращения.
1. Сохраните презентацию.

```java
import com.aspose.slides.*;

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

![Эффект 3D-вращения](3D-rotation-effect.png)

## **Управление черно-белой отрисовкой фигур**

Метод [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) задаёт, как отдельная фигура будет отрисовываться при просмотре или обработке презентации в черно‑белом режиме. Он не включают черно‑белый режим сам по себе и не меняет заливку, линии или другие параметры форматирования в обычном цветном режиме.

Используйте значение из класса [BlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/blackwhitemode/) для выбора требуемого поведения. Например, `Automatic` позволяет приложению‑отображателю выбрать способ конвертации, `Gray` и `LightGray` используют оттенки серого, `BlackWhite` — только чёрный и белый, `Black` и `White` принудительно задают один цвет, `Color` сохраняет обычные цвета, а `Hidden` исключает фигуру в черно‑белом режиме. `NotDefined` означает, что режим на уровне фигуры не задан.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    // Оставить оранжевую заливку в цветном режиме, но отрисовывать фигуру в серой палитре в черно-белом режиме.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Сброс форматирования**

Следующий Java‑код демонстрирует, как сбросить форматирование слайда и вернуть позицию, размер и форматирование всех фигур‑заполнителей на [LayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/layoutslide/) к их значениям по умолчанию:

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

**Влияет ли форматирование фигур на размер итогового файла презентации?**

Только незначительно. Встроенные изображения и медиа‑файлы занимают большую часть места, тогда как параметры фигур — такие как цвета, эффекты и градиенты — хранятся как метаданные и практически не увеличивают размер файла.

**Как обнаружить фигуры на слайде, которые имеют одинаковое форматирование, чтобы сгруппировать их?**

Сравните ключевые свойства форматирования каждой фигуры — параметры заливки, линии и эффектов. Если все соответствующие значения совпадают, их стили считаются идентичными, и такие фигуры можно логически группировать, что упрощает дальнейшее управление стилями.

**Можно ли сохранить набор пользовательских стилей фигур в отдельный файл для повторного использования в других презентациях?**

Да. Сохраните образцы фигур с желаемыми стилями в шаблонный набор слайдов или файл шаблона *.POTX*. При создании новой презентации откройте шаблон, клонируйте нужные стилизованные фигуры и примените их форматирование там, где это необходимо.