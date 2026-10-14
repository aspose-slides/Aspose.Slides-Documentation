---
title: "Форматирование фигур PowerPoint на Android"
linktitle: "Форматирование фигур"
type: docs
weight: 20
url: /ru/androidjava/shape-formatting/
keywords:
- форматировать фигуру
- форматировать линию
- эффект наброска
- линия фигуры наброска
- форматировать стиль соединения
- градиентная заливка
- заливка узором
- заливка изображением
- заливка текстурой
- сплошная заливка цветом
- прозрачность фигурки
- черно-белая отрисовка фигурки
- отображение фигурки в градациях серого
- повернуть фигурку
- 3D‑эффект фаски
- 3D‑поворот
- сброс форматирования
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Узнайте, как форматировать фигуры PowerPoint на Android с помощью Aspose.Slides — задавайте стили заливки, линий и эффектов для файлов PPT, PPTX и ODP с точностью и полной управляемостью."
---
## **Введение**

В PowerPoint вы можете добавлять фигурки на слайды. Поскольку фигурки состоят из линий, их можно форматировать, изменяя или применяя эффекты к контуру. Кроме того, фигурки можно форматировать, задавая параметры, которые контролируют заполнение их внутренней области.

![Форматированные линии в PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Android via Java предоставляет интерфейсы и методы, позволяющие форматировать фигурки с теми же параметрами, что доступны в PowerPoint.

## **Форматирование линий**

С помощью Aspose.Slides вы можете указать пользовательский стиль линии для фигурки. Ниже приведены шаги процедуры:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) на слайд.
1. Установите [стиль линии](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linestyle/) фигурки.
1. Задайте толщину линии.
1. Установите [стиль штриха](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linedashstyle/) линии.
1. Задайте цвет линии для фигурки.
1. Сохраните изменённую презентацию как файл PPTX.

Следующий код демонстрирует, как отформатировать прямоугольник `AutoShape`:

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

## **Применение эффектов «рисунок от руки» к линиям фигурок**

Эффект «рисунок от руки» делает линию фигурки выглядящей нарисованной вручную. Используйте [IShape.getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) для доступа к настройкам линии, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/) для доступа к настройкам скетча и [ISketchFormat.setSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/) для выбора значения из перечисления [LineSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/).

Следующий код на Java показывает, как применить эффект [LineSketchType.Curved](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/), прочитать явно заданное значение и удалить эффект с помощью [LineSketchType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // Доступ к формату линии фигуры и её формату скетча.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // Применить эффект скетча.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // Прочитать эффект скетча, назначенный непосредственно фигуре.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // Удалить эффект скетча.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

Значение, возвращаемое [ISketchFormat.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/), представляет настройку, назначенную непосредственно фигурке. Если форматирование линии может наследоваться от темы, шаблона или макета слайда, используйте [ILineFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/), получайте [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformateffectivedata/), и читайте [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformateffectivedata/). Эффективное значение отражает фактическое форматирование после разрешения наследования:

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

## **Форматирование стилей соединения**

Вот три варианта типа соединения:

* Round
* Miter
* Bevel

По умолчанию, когда PowerPoint соединяет две линии под углом (например, в углу фигурки), используется настройка **Round**. Однако если вы рисуете фигурку с острыми углами, вам может подойти вариант **Miter**.

![Стиль соединения в презентации](join-style-powerpoint.png)

Следующий код на Java демонстрирует, как три прямоугольника (как показано на изображении выше) были созданы с использованием настроек соединения Miter, Bevel и Round:

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

    // Установите толщину линии.
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

В PowerPoint градиентная заливка — это параметр форматирования, позволяющий применить непрерывный переход цветов к фигурке. Например, можно задать два и более цветов так, чтобы один постепенно переходил в другой.

Ниже показано, как применить градиентную заливку к фигурке с помощью Aspose.Slides:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) на слайд.
1. Установите для фигурки свойство [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) значением `Gradient`.
1. Добавьте два желаемых цвета с определёнными позициями, используя методы `add` из коллекции градиентных остановок, предоставляемой интерфейсом [IGradientFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/).
1. Сохраните изменённую презентацию как файл PPTX.

Следующий код на Java демонстрирует, как применить градиентную заливку к эллипсу:

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

    // Задайте направление градиента.
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

Если градиент выглядит иначе в экспортированном изображении, чем в PowerPoint, см. раздел [Choose a Gradient Rendering Style](/slides/ru/androidjava/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Вы можете выбрать стиль рендеринга, не меняя градиентную заливку, хранящуюся в презентации.

## **Заливка узором**

В PowerPoint заливка узором — это параметр форматирования, позволяющий применить двухцветный дизайн (точки, полосы, штриховку или шахматный узор) к фигурке. Вы можете задать собственные цвета для переднего и заднего плана узора.

Aspose.Slides предоставляет более 45 предустановленных стилей узоров, которые можно применить к фигуркам для улучшения визуального восприятия презентаций. Даже после выбора предустановленного узора вы можете указать точные цвета, которые он будет использовать.

Ниже показано, как применить заливку узором к фигурке с помощью Aspose.Slides:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) на слайд.
1. Установите для фигурки свойство [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) значением `Pattern`.
1. Выберите стиль узора из предустановленных вариантов.
1. Установите [Background Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/patternformat/#getBackColor--) узора.
1. Установите [Foreground Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/patternformat/#getForeColor--) узора.
1. Сохраните изменённую презентацию как файл PPTX.

Следующий код на Java демонстрирует, как применить заливку узором к прямоугольнику:

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

    // Установите фоновые и передние цвета узора.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // Сохраните файл PPTX на диск.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Прямоугольник с заливкой узором](pattern-fill.png)

## **Заливка изображением**

В PowerPoint заливка изображением — это параметр форматирования, позволяющий вставить изображение внутрь фигурки, effectively using the image as the shape's background.

Ниже показано, как использовать Aspose.Slides для применения заливки изображением к фигурке:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) на слайд.
1. Установите для фигурки свойство [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) значением `Picture`.
1. Установите режим заливки изображением в `Tile` (или другой предпочтительный режим).
1. Создайте объект [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) из изображения, которое хотите использовать.
1. Передайте изображение в метод `ISlidesPicture.setImage`.
1. Сохраните изменённую презентацию как файл PPTX.

Допустим, у нас есть файл «lotus.png» со следующим изображением:

![Изображение лотоса](lotus.png)

Следующий код на Java демонстрирует, как заполнить фигурку изображением:

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

![Фигурка с заливкой изображением](picture-fill.png)

### **Текстура «Плитка» изображения**

Если нужно задать изображение‑плитку в качестве текстуры и настроить поведение размещения плиток, можно использовать следующие методы интерфейса [IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) и класса [PictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): задаёт режим заливки изображения — `Tile` или `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): определяет выравнивание плиток внутри фигурки.
- [setTileFlip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): контролирует, будет ли плитка отражена по горизонтали, вертикали или обеим осям.
- [setTileOffsetX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): задаёт горизонтальное смещение плитки (в пунктах) от начала фигурки.
- [setTileOffsetY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): задаёт вертикальное смещение плитки (в пунктах) от начала фигурки.
- [setTileScaleX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): определяет горизонтальный масштаб плитки в процентах.
- [setTileScaleY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): определяет вертикальный масштаб плитки в процентах.

Следующий пример кода показывает, как добавить прямоугольную фигурку с заливкой‑плиткой и настроить параметры плитки:

```java
import com.aspose.slides.*;

// Создайте экземпляр класса Presentation, представляющего файл презентации.
Presentation presentation = new Presentation();
try {
    // Получите первый слайд.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Добавьте прямоугольную автофигуру.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Установите тип заливки фигурки в Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Загрузите изображение и добавьте его в ресурсы презентации.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Присвойте изображение фигурке.
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

![Параметры плитки](tile-options.png)

## **Сплошная заливка цветом**

В PowerPoint сплошная заливка цветом — это параметр форматирования, который заполняет фигурку одним равномерным цветом. Этот простой фон применяется без градиентов, текстур или узоров.

Чтобы применить сплошную заливку цветом к фигурке с помощью Aspose.Slides, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) на слайд.
1. Установите свойство фигурки [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) значением `Solid`.
1. Задайте желаемый цвет заливки фигурки.
1. Сохраните изменённую презентацию как файл PPTX.

Следующий код на Java демонстрирует, как применить сплошную заливку цветом к прямоугольнику в слайде PowerPoint:

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

![Фигурка со сплошной заливкой цветом](solid-color-fill.png)

## **Установка прозрачности**

В PowerPoint, когда вы применяете сплошную заливку, градиент, изображение или текстуру к фигуркам, вы также можете задать уровень прозрачности, контролирующий непрозрачность заливки. Более высокий уровень прозрачности делает фигурку более просвечивающей, позволяя фону или нижележащим объектам частично просвечивать.

Aspose.Slides позволяет установить уровень прозрачности, регулируя альфа‑компонент цвета, используемого для заливки. Как это сделать:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) на слайд.
1. Установите [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) значением `Solid`.
1. Используйте `Color` для определения цвета с прозрачностью (компонент `alpha` управляет прозрачностью).
1. Сохраните презентацию.

Следующий код на Java демонстрирует, как применить прозрачный цвет заливки к прямоугольнику:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Создайте экземпляр класса Presentation, представляющего файл презентации.
Presentation presentation = new Presentation();
try {
    // Получите первый слайд.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Добавьте сплошную прямоугольную автофигуру.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Добавьте прозрачную прямоугольную автофигуру над сплошной фигурой.
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

![Прозрачная фигурка](shape-transparency.png)

## **Поворот фигурок**

Aspose.Slides позволяет поворачивать фигурки в презентациях PowerPoint. Это может быть полезно при позиционировании визуальных элементов с определённым выравниванием или дизайнерскими требованиями.

Чтобы повернуть фигурку на слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) на слайд.
1. Установите свойство вращения фигурки на нужный угол.
1. Сохраните презентацию.

Следующий код на Java демонстрирует, как повернуть фигурку на 5 градусов:

```java
import com.aspose.slides.*;

// Создайте экземпляр класса Presentation, представляющего файл презентации.
Presentation presentation = new Presentation();
try {
    // Получите первый слайд.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Добавьте автофигуру типа Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Поверните фигурку на 5 градусов.
    shape.setRotation(5);

    // Сохраните файл PPTX на диск.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Поворот фигурки](shape-rotation.png)

## **Добавление 3D‑эффекта фаски**

Aspose.Slides позволяет применять 3D‑эффекты фаски к фигуркам, настраивая их свойства [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/threedformat/).

Чтобы добавить 3D‑эффект фаски к фигурке, выполните следующие шаги:

1. Создайте объект класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) на слайд.
1. Настройте свойства [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/threedformat/) фигурки для определения параметров фаски.
1. Сохраните презентацию.

Следующий код на Java показывает, как применить 3D‑эффект фаски к фигурке:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Создайте экземпляр класса Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Добавьте фигурку на слайд.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE);
    shape.getLineFormat().setWidth(2.0);

    // Установите свойства ThreeDFormat фигурки.
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

![Эффект 3D‑фаски](3D-bevel-effect.png)

## **Добавление 3D‑поворота**

Aspose.Slides позволяет применять 3D‑поворот к фигуркам, настраивая их свойства [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/threedformat/).

Чтобы применить 3D‑поворот к фигурке:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) на слайд.
1. Используйте методы [setCameraType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setCameraType-int-) и [setLightType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) для определения 3D‑поворота.
1. Сохраните презентацию.

Следующий код на Java демонстрирует, как применить 3D‑поворот к фигурке:

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

    // Сохраните презентацию как файл PPTX.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Эффект 3D‑поворота](3D-rotation-effect.png)

## **Управление черно‑белым рендерингом фигурок**

Метод [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) задаёт, как отдельная фигурка будет отрисовываться, когда презентация просматривается или обрабатывается в черно‑белом режиме. Метод сам по себе не включает черно‑белый режим и не изменяет заливку, линии или другое форматирование фигурки в обычном цветовом режиме.

Используйте значение из класса [BlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blackwhitemode/) для выбора нужного поведения. Например, `Automatic` позволяет приложению‑отрисовщику выбрать способ преобразования, `Gray` и `LightGray` используют серый цвет, `BlackWhite` использует только чёрный и белый, `Black` и `White` принудительно задают один цвет, `Color` сохраняет обычные цвета, `Hidden` исключает фигурку в черно‑белом режиме. `NotDefined` означает, что режим на уровне фигурки не задан.

Следующий код на Java создаёт цветную фигурку и делает её серой в режиме черно‑белого отображения:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    // Сохраните оранжевую заливку в цветном режиме, но отобразите фигурку в сером цвете в черно-белом режиме.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

В обычном цветовом режиме прямоугольник сохраняет оранжевую заливку. В рабочем процессе черно‑белого отображения он будет отображён серым, поскольку его режим установлен в `Gray`. Это позволяет сохранять полноцветный слайд, одновременно определяя отдельный внешний вид для печати, предварительного просмотра или других рабочих процессов, учитывающих настройки черно‑белого отображения презентации.

## **Сброс форматирования**

Следующий код на Java показывает, как сбросить форматирование слайда и вернуть положение, размер и форматирование всех фигурок с заполнителями на [LayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/layoutslide/) к их значениям по умолчанию:

```java
import com.aspose.slides.*;

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

## **FAQ**

**Влияет ли форматирование фигурок на конечный размер файла презентации?**

Практически не влияет. Встроенные изображения и медиа‑файлы занимают большую часть объёма, тогда как параметры фигурок, такие как цвета, эффекты и градиенты, хранятся как метаданные и добавляют почти нулевой размер.

**Как определить фигурки на слайде, имеющие идентичное форматирование, чтобы сгруппировать их?**

Сравните ключевые свойства форматирования каждой фигурки — заливку, линии и настройки эффектов. Если все соответствующие значения совпадают, рассматривайте их стили как одинаковые и логически группируйте такие фигурки, что упрощает дальнейшее управление стилями.

**Можно ли сохранить набор пользовательских стилей фигурок в отдельный файл для повторного использования в других презентациях?**

Да. Сохраните образцы фигурок с нужными стилями в шаблонном наборе слайдов или файле шаблона *.POTX*. При создании новой презентации откройте шаблон, клонируйте необходимые стилизованные фигурки и повторно примените их форматирование там, где это требуется.