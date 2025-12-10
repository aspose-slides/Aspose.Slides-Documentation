---
title: Форматирование фигур PowerPoint в Java
linktitle: Форматирование фигур
type: docs
weight: 20
url: /ru/java/shape-formatting/
keywords:
- формат фигуры
- формат линии
- формат стиля соединения
- градиентная заливка
- заливка шаблоном
- заливка изображением
- текстурная заливка
- заливка сплошным цветом
- прозрачность фигуры
- вращение фигуры
- 3D-эффект фаски
- 3D-эффект вращения
- сброс форматирования
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Узнайте, как форматировать фигуры PowerPoint на Java с помощью Aspose.Slides — задавайте стили заливки, линий и эффектов для файлов PPT, PPTX и ODP с точностью и полным контролем."
---

## **Обзор**

В PowerPoint вы можете добавлять формы на слайды. Поскольку формы состоят из линий, вы можете форматировать их, изменяя или применяя эффекты к их контурам. Кроме того, вы можете форматировать формы, указывая параметры, которые контролируют заполнение их внутренней части.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Java предоставляет интерфейсы и методы, позволяющие форматировать формы с использованием тех же параметров, что доступны в PowerPoint.

## **Форматирование линий**

С помощью Aspose.Slides вы можете задавать пользовательский стиль линии для формы. Ниже перечислены шаги процедуры:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) на слайд.
1. Задайте [line style](https://reference.aspose.com/slides/java/com.aspose.slides/linestyle/) формы.
1. Установите ширину линии.
1. Задайте [dash style](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/) линии.
1. Установите цвет линии для формы.
1. Сохраните изменённую презентацию как файл PPTX.

Ниже приведён код, демонстрирующий, как отформатировать прямоугольник `AutoShape`:
```java
// Создайте экземпляр класса Presentation, который представляет файл презентации.
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

![The formatted lines in the presentation](formatted-lines.png)

## **Форматирование стилей соединений**

Вот три варианта типа соединения:

* Круглое
* Срезанное
* Фаска

По умолчанию, когда PowerPoint соединяет две линии под углом (например, в угле формы), используется настройка **Круглое**. Однако, если вы рисуете форму с острыми углами, вам может подойти вариант **Срезанное**.

![The join style in the presentation](join-style-powerpoint.png)

Ниже показан Java‑код, демонстрирующий, как три прямоугольника (как на изображении выше) были созданы с использованием настроек соединения Срезанное, Фаска и Круглое:
```java
// Создайте экземпляр класса Presentation, который представляет файл презентации.
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

В PowerPoint градиентная заливка — это параметр форматирования, позволяющий применять к форме плавный переход нескольких цветов. Например, можно задать два и более цвета так, чтобы один постепенно переходил в другой.

Как применить градиентную заливку к форме с помощью Aspose.Slides:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) на слайд.
1. Установите свойство формы [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) в `Gradient`.
1. Добавьте два желаемых цвета с заданными позициями, используя методы `add` коллекции остановок градиента, предоставляемой интерфейсом [IGradientFormat](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/).
1. Сохраните изменённую презентацию как файл PPTX.

Ниже показан Java‑код, демонстрирующий, как применить градиентный эффект к эллипсу:
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

![The ellipse with gradient fill](gradient-fill.png)

## **Заливка шаблоном**

В PowerPoint заливка шаблоном — это параметр форматирования, позволяющий применять к форме двухцветный узор (точки, полосы, перекрестные штрихи или шахматы). Вы можете выбрать пользовательские цвета для переднего и заднего плана шаблона.

Aspose.Slides предоставляет более 45 предопределённых стилей шаблонов, которые можно применять к формам для улучшения визуального вида презентаций. Даже после выбора готового шаблона вы можете указать точные цвета, которые он будет использовать.

Как применить заливку шаблоном к форме с помощью Aspose.Slides:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) на слайд.
1. Установите свойство формы [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) в `Pattern`.
1. Выберите стиль шаблона из предопределённых вариантов.
1. Задайте [Background Color](https://reference.aspose.com/slides/java/com.aspose.slides/patternformat/#getBackColor--) шаблона.
1. Задайте [Foreground Color](https://reference.aspose.com/slides/java/com.aspose.slides/patternformat/#getForeColor--) шаблона.
1. Сохраните изменённую презентацию как файл PPTX.

Ниже показан Java‑код, демонстрирующий, как применить шаблонную заливку к прямоугольнику:
```java
// Создайте экземпляр класса Presentation, который представляет файл презентации.
Presentation presentation = new Presentation();
try {
    // Получите первый слайд.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Добавьте автофигуру типа Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Установите тип заливки в Pattern.
    shape.getFillFormat().setFillType(FillType.Pattern);

    // Установите стиль шаблона.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // Установите фон и передний цвет шаблона.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // Сохраните файл PPTX на диск.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


Результат:

![The rectangle with pattern fill](pattern-fill.png)

## **Заливка изображением**

В PowerPoint заливка изображением — это параметр форматирования, позволяющий вставить изображение внутрь формы, effectively using the image as the shape's background.

Вот как использовать Aspose.Slides для применения заливки изображением к форме:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) на слайд.
1. Установите свойство формы [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) в `Picture`.
1. Установите режим заливки изображения в `Tile` (или другой предпочтительный режим).
1. Создайте объект [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) из изображения, которое хотите использовать.
1. Передайте изображение методу `ISlidesPicture.setImage`.
1. Сохраните изменённую презентацию как файл PPTX.

Допустим, у нас есть файл «lotus.png» со следующим изображением:

![The lotus picture](lotus.png)

Ниже приведён Java‑код, демонстрирующий, как заполнить форму изображением:
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

![The shape with picture fill](picture-fill.png)

### **Тайловое изображение как текстура**

Если нужно задать тайловое изображение в качестве текстуры и настроить поведение тайлинга, используйте следующие методы интерфейса [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) и класса [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): задаёт режим заливки изображения — `Tile` или `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): определяет выравнивание тайлов внутри формы.
- [setTileFlip](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): управляет отражением тайла по горизонтали, вертикали или обоим направлениям.
- [setTileOffsetX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): задаёт горизонтальное смещение тайла (в пунктах) от начала формы.
- [setTileOffsetY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): задаёт вертикальное смещение тайла (в пунктах) от начала формы.
- [setTileScaleX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): определяет горизонтальный масштаб тайла в процентах.
- [setTileScaleY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): определяет вертикальный масштаб тайла в процентах.

Ниже пример кода, показывающий, как добавить прямоугольную форму с тайловой заливкой изображением и настроить параметры тайлов:
```java
// Создайте экземпляр класса Presentation, представляющего файл презентации.
Presentation presentation = new Presentation();
try {
    // Получите первый слайд.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Добавьте автофигуру прямоугольника.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Установите тип заливки формы в Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Загрузите изображение и добавьте его в ресурсы презентации.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Назначьте изображение фигуре.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Настройте режим заливки изображением и свойства тайлинга.
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

![The tile options](tile-options.png)

## **Заливка сплошным цветом**

В PowerPoint заливка сплошным цветом — это параметр форматирования, который заполняет форму единым, однородным цветом. Этот простой фон применяется без градиентов, текстур или узоров.

Чтобы применить сплошную заливку к форме с помощью Aspose.Slides, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) на слайд.
1. Установите свойство формы [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) в `Solid`.
1. Задайте желаемый цвет заливки для формы.
1. Сохраните изменённую презентацию как файл PPTX.

Ниже показан Java‑код, демонстрирующий, как применить сплошную заливку к прямоугольнику в слайде PowerPoint:
```java
// Создайте экземпляр класса Presentation, который представляет файл презентации.
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

![The shape with solid color fill](solid-color-fill.png)

## **Установка прозрачности**

В PowerPoint при применении сплошного цвета, градиента, изображения или текстурной заливки к формулам вы также можете задать уровень прозрачности, контролирующий непрозрачность заливки. Чем выше значение прозрачности, тем более «прозрачной» становится форма, позволяя видеть фон или находящиеся ниже объекты.

Aspose.Slides позволяет задавать уровень прозрачности, изменяя альфа‑компонент в цвете, используемом для заливки. Как это сделать:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) на слайд.
1. Установите [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) в `Solid`.
1. Используйте `Color` для определения цвета с прозрачностью (компонент `alpha` управляет прозрачностью).
1. Сохраните презентацию.

Ниже показан Java‑код, демонстрирующий, как применить цвет заливки с прозрачностью к прямоугольнику:
```java
// Создайте экземпляр класса Presentation, представляющий файл презентации.
Presentation presentation = new Presentation();
try {
    // Получите первый слайд.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Добавьте сплошную прямоугольную автофигуру.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Добавьте прозрачную прямоугольную автофигуру поверх сплошной фигуры.
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

![The transparent shape](shape-transparency.png)

## **Вращение форм**

Aspose.Slides позволяет вращать формы в презентациях PowerPoint. Это может быть полезно при позиционировании визуальных элементов с определёнными требованиями к выравниванию или дизайну.

Чтобы вращать форму на слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) на слайд.
1. Установите свойство rotation формы в нужный угол.
1. Сохраните презентацию.

Ниже показан Java‑код, демонстрирующий вращение формы на 5 градусов:
```java
// Создайте экземпляр класса Presentation, представляющего файл презентации.
Presentation presentation = new Presentation();
try {
    // Получите первый слайд.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Добавьте автофигуру типа Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Поверните форму на 5 градусов.
    shape.setRotation(5);

    // Сохраните файл PPTX на диск.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


Результат:

![The shape rotation](shape-rotation.png)

## **Добавление 3D‑эффекта фаски**

Aspose.Slides позволяет применять к формам 3D‑эффекты фаски, настраивая их свойства [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/).

Чтобы добавить 3D‑эффект фаски к форме, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) на слайд.
1. Настройте свойство формы [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/) для определения параметров фаски.
1. Сохраните презентацию.

Ниже показан Java‑код, демонстрирующий применение 3D‑эффекта фаски к форме:
```java
// Создайте экземпляр класса Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Добавьте форму на слайд.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE);
    shape.getLineFormat().setWidth(2.0);

    // Задайте свойства ThreeDFormat формы.
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

![The 3D bevel effect](3D-bevel-effect.png)

## **Добавление 3D‑вращения**

Aspose.Slides позволяет применять к формам 3D‑вращение, настраивая их свойства [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/).

Чтобы применить 3D‑вращение к форме:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) на слайд.
1. Используйте методы [setCameraType](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setCameraType-int-) и [setLightType](https://reference.aspose.com/slides/java/com.aspose.slides/ilightrig/#setLightType-int-) для определения 3D‑вращения.
1. Сохраните презентацию.

Ниже показан Java‑код, демонстрирующий применение 3D‑вращения к форме:
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

    // Сохраните презентацию в файл PPTX.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


Результат:

![The 3D rotation effect](3D-rotation-effect.png)

## **Сброс форматирования**

Ниже приведён Java‑код, показывающий, как сбросить форматирование слайда и вернуть положение, размер и форматирование всех форм с заполнителями на [LayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/layoutslide/) к их значениям по умолчанию:
```java
Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Сбросить каждую форму на слайде, у которой есть заполнитель в макете.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **FAQ**

**Влияет ли форматирование формы на размер итогового файла презентации?**

Только незначительно. Вложенные изображения и медиа‑файлы занимают большую часть пространства, тогда как параметры формы, такие как цвета, эффекты и градиенты, сохраняются как метаданные и практически не увеличивают размер файла.

**Как определить формы на слайде с одинаковым форматированием, чтобы их сгруппировать?**

Сравните ключевые свойства форматирования каждой формы — параметры заливки, линии и эффекты. Если все соответствующие значения совпадают, рассматривайте их стили как одинаковые и логически группируйте такие формы, что упрощает дальнейшее управление стилями.

**Можно ли сохранить набор пользовательских стилей форм в отдельный файл для повторного использования в других презентациях?**

Да. Сохраните образцы форм с желаемыми стилями в шаблонной презентации или файле шаблона .POTX. При создании новой презентации откройте шаблон, клонируйте нужные стилизованные формы и повторно применяйте их форматирование там, где требуется.