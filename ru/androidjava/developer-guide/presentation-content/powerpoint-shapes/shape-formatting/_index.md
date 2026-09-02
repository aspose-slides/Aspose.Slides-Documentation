---
title: Форматирование фигур PowerPoint на Android
linktitle: Форматирование фигур
type: docs
weight: 20
url: /ru/androidjava/shape-formatting/
keywords:
- форматировать фигуру
- форматировать линию
- эффект эскиза
- линия фигуры в стиле эскиза
- форматировать стиль соединения
- градиентная заливка
- заполнение узором
- заполнение изображением
- заполнение текстурой
- сплошная заливка цветом
- прозрачность фигуры
- чёрно‑белая отрисовка фигуры
- оттенки серого фигуры
- повернуть фигуру
- 3D-скос
- 3D‑вращение
- сбросить форматирование
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Узнайте, как форматировать фигуры PowerPoint на Android с помощью Aspose.Slides — задавайте стили заливки, линий и эффектов для файлов PPT, PPTX и ODP с точностью и полным контролем."
---
## **Введение**

В PowerPoint вы можете добавлять фигуры на слайды. Поскольку фигуры состоят из линий, вы можете форматировать их, изменяя или применяя эффекты к их контурам. Кроме того, вы можете форматировать фигуры, задавая параметры, которые управляют заполнением их внутренних областей.

![формат-фигуры-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Android via Java предоставляет интерфейсы и методы, позволяющие форматировать фигуры с использованием тех же параметров, что доступны в PowerPoint.

## **Форматирование линий**

С помощью Aspose.Slides вы можете задать пользовательский стиль линии для фигуры. Ниже приведены шаги процедуры:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/) на слайд.
1. Установите [line style](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/linestyle/) фигуры.
1. Задайте толщину линии.
1. Установите [dash style](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/linedashstyle/) линии.
1. Установите цвет линии для фигуры.
1. Сохраните изменённую презентацию в файл PPTX.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Создайте объект класса Presentation, представляющий файл презентации.
Presentation presentation = new Presentation();
try {
    // Получите первый слайд.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Добавьте автофигуру типа Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Удалите заливку из прямоугольной фигуры, чтобы были видны только её линии.
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

Эффект эскиза делает линию фигуры похожей на нарисованную от руки. Используйте [IShape.getLineFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/) для доступа к настройкам линии, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilineformat/) для доступа к настройкам эскиза и [ISketchFormat.setSketchType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isketchformat/) для выбора значения из перечисления [LineSketchType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/linesketchtype/).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // Получите формат линии фигуры и её формат эскиза.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // Примените эффект эскиза.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // Прочитайте эффект эскиза, назначенный напрямую фигуре.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // Удалите эффект эскиза.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

Значение, возвращаемое [ISketchFormat.getSketchType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isketchformat/), представляет настройку, назначенную непосредственно фигуре. Если форматирование линии может быть унаследовано из темы, мастер‑слайда или шаблона слайда, используйте [ILineFormat.getEffective](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilineformat/), доступ к [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilineformateffectivedata/), и чтение [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isketchformateffectivedata/). Эффективное значение отражает фактическое форматирование после разрешения наследования:

```java
import com.aspose.slides.*;

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

* Округлый
* Срез
* Фаска

По умолчанию, когда PowerPoint соединяет две линии под углом (например, в углу фигуры), он использует настройку **Округлый**. Однако если вы рисуете фигуру с острыми углами, вам может подойти вариант **Срез**.

![Стиль соединения в презентации](join-style-powerpoint.png)

```java
import com.aspose.slides.*;
import java.awt.Color;

// Создайте объект класса Presentation, представляющий файл презентации.
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

В PowerPoint градиентная заливка — это параметр форматирования, позволяющий применить к фигуре плавный переход нескольких цветов. Например, можно задать два или более цветов так, чтобы один постепенно переходил в другой.

Как применить градиентную заливку к фигуре с помощью Aspose.Slides:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/) на слайд.
1. Установите свойство [FillType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/filltype/) фигуры в значение `Gradient`.
1. Добавьте два выбранных цвета с заданными позициями, используя методы `add` коллекции градиентных остановок, доступные через интерфейс [IGradientFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/igradientformat/).
1. Сохраните изменённую презентацию в файл PPTX.

```java
import com.aspose.slides.*;

// Создайте объект класса Presentation, представляющий файл презентации.
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

В PowerPoint заливка узором — это параметр, позволяющий применить к фигуре двухцветный узор (точки, полосы, перекрестные штрихи, клетки и т.д.). Вы можете выбрать собственные цвета для переднего и заднего плана узора.

Aspose.Slides предоставляет более 45 предопределённых стилей узоров, которые можно применять к фигурам для повышения визуальной привлекательности презентаций. Даже после выбора предопределённого узора вы всё равно можете указать точные цвета, которые он будет использовать.

Как применить заливку узором к фигуре с помощью Aspose.Slides:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/) на слайд.
1. Установите свойство [FillType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/filltype/) фигуры в значение `Pattern`.
1. Выберите стиль узора из предопределённых вариантов.
1. Установите [Background Color](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/patternformat/#getBackColor--) узора.
1. Установите [Foreground Color](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/patternformat/#getForeColor--) узора.
1. Сохраните изменённую презентацию в файл PPTX.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Создайте объект класса Presentation, представляющий файл презентации.
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

## **Заливка изображением**

В PowerPoint заливка изображением — это параметр, позволяющий вставить изображение внутрь фигуры, фактически используя его как фон фигуры.

Как использовать Aspose.Slides для применения заливки изображением к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/) на слайд.
1. Установите свойство [FillType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/filltype/) фигуры в значение `Picture`.
1. Установите режим заливки изображением в `Tile` (или иной предпочтительный режим).
1. Создайте объект [IPPImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ippimage/) из изображения, которое хотите использовать.
1. Передайте изображение в метод `ISlidesPicture.setImage`.
1. Сохраните изменённую презентацию в файл PPTX.

![Картинка лотоса](lotus.png)

```java
import com.aspose.slides.*;

// Создайте объект класса Presentation, представляющий файл презентации.
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

### **Повторяющееся изображение как текстура**

Если вы хотите задать повторяющееся изображение в качестве текстуры и настроить поведение повторения, используйте следующие методы интерфейса [IPictureFillFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipicturefillformat/) и класса [PictureFillFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): задаёт режим заливки изображением — `Tile` или `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): определяет выравнивание плиток внутри фигуры.
- [setTileFlip](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): управляет горизонтальным, вертикальным или двойным отражением плитки.
- [setTileOffsetX](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): задаёт горизонтальное смещение плитки (в пунктах) от начала фигуры.
- [setTileOffsetY](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): задаёт вертикальное смещение плитки (в пунктах) от начала фигуры.
- [setTileScaleX](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): определяет горизонтальный масштаб плитки в процентах.
- [setTileScaleY](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): определяет вертикальный масштаб плитки в процентах.

```java
import com.aspose.slides.*;

// Создайте объект класса Presentation, представляющий файл презентации.
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

    // Настройте режим заливки изображением и свойства мозаики.
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

![Параметры повторения](tile-options.png)

## **Сплошная заливка цветом**

В PowerPoint сплошная заливка цветом — это параметр, который заполняет фигуру одним ровным цветом без градиентов, текстур или узоров.

Чтобы применить сплошную заливку цветом к фигуре с помощью Aspose.Slides, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/) на слайд.
1. Установите свойство [FillType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/filltype/) фигуры в значение `Solid`.
1. Назначьте предпочтительный цвет заливки фигуре.
1. Сохраните изменённую презентацию в файл PPTX.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Создайте объект класса Presentation, представляющий файл презентации.
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

В PowerPoint при применении сплошного цвета, градиента, изображения или текстуры к фигурам можно также задать уровень прозрачности, контролирующий непрозрачность заливки. Чем выше значение прозрачности, тем более просвечивающей будет фигура, позволяя видеть фон или нижележащие объекты.

Aspose.Slides позволяет установить уровень прозрачности, изменяя альфа‑компонент цвета, используемого для заливки. Вот как это сделать:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/) на слайд.
1. Установите свойство [FillType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/filltype/) в значение `Solid`.
1. Используйте `Color` для определения цвета с прозрачностью (компонент `alpha` управляет прозрачностью).
1. Сохраните презентацию.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Создайте объект класса Presentation, представляющий файл презентации.
Presentation presentation = new Presentation();
try {
    // Получите первый слайд.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Добавьте автофигуру сплошного прямоугольника.
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

## **Поворот фигур**

Aspose.Slides позволяет вращать фигуры в презентациях PowerPoint. Это может быть полезно при размещении визуальных элементов с определённым выравниванием или дизайнерскими требованиями.

Чтобы повернуть фигуру на слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/) на слайд.
1. Установите свойство вращения фигуры на требуемый угол.
1. Сохраните презентацию.

```java
import com.aspose.slides.*;

// Создайте объект класса Presentation, представляющий файл презентации.
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

![Поворот фигуры](shape-rotation.png)

## **Добавление 3D-скосов**

Aspose.Slides позволяет применять 3D-скосы к фигурам, настраивая их свойства [ThreeDFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/threedformat/).

Чтобы добавить 3D-скосы к фигуре, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/) на слайд.
1. Настройте [ThreeDFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/threedformat/) фигуры, задав параметры скосов.
1. Сохраните презентацию.

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

![Эффект 3D-скоса](3D-bevel-effect.png)

## **Добавление 3D-вращения**

Aspose.Slides позволяет применять 3D-вращение к фигурам, настраивая их свойства [ThreeDFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/threedformat/).

Чтобы применить 3D-вращение к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/) на слайд.
1. Используйте методы [setCameraType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/icamera/#setCameraType-int-) и [setLightType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) для определения 3D-вращения.
1. Сохраните презентацию.

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

![Эффект 3D-вращения](3D-rotation-effect.png)

## **Управление черно-белой отрисовкой фигур**

Метод [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) определяет, как отдельная фигура будет отрисовываться при просмотре или обработке презентации в черно‑белом режиме. Он сам по себе не включает черно‑белый режим и не меняет заливку, линии или другие параметры форматирования в обычном цветовом режиме.

Для выбора поведения используйте значение из класса [BlackWhiteMode](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/blackwhitemode/). Например, `Automatic` позволяет приложению выбрать способ преобразования, `Gray` и `LightGray` используют оттенки серого, `BlackWhite` — только чёрный и белый, `Black` и `White` принудительно задают один цвет, `Color` сохраняет обычные цвета, а `Hidden` исключает фигуру в черно‑белом режиме. `NotDefined` означает, что режим на уровне фигуры не установлен.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    // Сохраните оранжевую заливку в цветном режиме, но отрисуйте фигуру с серой заливкой в черно-белом режиме.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

В обычном цветовом режиме прямоугольник сохраняет оранжевую заливку. В режиме черно‑белого отображения он будет отображаться серым, поскольку его режим установлен в `Gray`. Это позволяет сохранять слайд в полноцветном виде, задавая отдельный вид для печати, предварительного просмотра или других процессов, учитывающих настройки черно‑белого отображения презентации.

## **Сброс форматирования**

Следующий код на Java демонстрирует, как сбросить форматирование слайда и вернуть позиции, размеры и форматирование всех фигур‑заполнителей на [LayoutSlide](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/layoutslide/) к их значениям по умолчанию:

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

Только минимально. Вложенные изображения и медиа‑файлы занимают большую часть объёма, тогда как параметры фигур — цвета, эффекты, градиенты — хранятся как метаданные и практически не увеличивают размер файла.

**Как обнаружить фигуры на слайде, имеющие идентичное форматирование, чтобы сгруппировать их?**

Сравните ключевые свойства форматирования каждой фигуры — параметры заливки, линии и эффектов. Если все соответствующие значения совпадают, рассматривайте их стили как одинаковые и логически группируйте такие фигуры, что упрощает последующее управление стилями.

**Можно ли сохранить набор пользовательских стилей фигур в отдельный файл для повторного использования в других презентациях?**

Да. Сохраните образцы фигур с нужными стилями в шаблонный набор слайдов или файл шаблона .POTX. При создании новой презентации откройте шаблон, клонируйте необходимые стилизованные фигуры и повторно примените их форматирование там, где это требуется.