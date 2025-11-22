---
title: Форматирование фигур PowerPoint в JavaScript
linktitle: Форматирование фигур
type: docs
weight: 20
url: /ru/nodejs-java/shape-formatting/
keywords:
  - форматировать фигуру
  - форматировать линию
  - форматировать стиль соединения
  - градиентная заливка
  - заливка шаблоном
  - заливка картинкой
  - заливка текстурой
  - сплошная заливка цветом
  - прозрачность фигуры
  - повернуть фигуру
  - 3D-скос
  - эффект 3D‑вращения
  - сброс форматирования
  - PowerPoint
  - презентация
  - Java
  - Aspose.Slides
description: "Узнайте, как форматировать фигуры PowerPoint в JavaScript с помощью Aspose.Slides — задавайте стили заливки, линии и эффектов для файлов PPT, PPTX и ODP с точностью и полным контролем."
---

## **Обзор**

В PowerPoint вы можете добавлять фигуры на слайды. Поскольку фигуры состоят из линий, их можно форматировать, изменяя или применяя эффекты к контурам. Кроме того, фигуры можно форматировать, задавая параметры, контролирующие заливку их внутренней области.

![форматирование фигуры PowerPoint](format-shape-powerpoint.png)

Aspose.Slides для Node.js через Java предоставляет классы и методы, позволяющие форматировать фигуры, используя те же параметры, что доступны в PowerPoint.

## **Форматирование линий**

Используя Aspose.Slides, вы можете задать пользовательский стиль линии для фигуры. Ниже перечислены шаги процедуры:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) на слайд.
1. Установите [стиль линии](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linestyle/) фигуры.
1. Установите ширину линии.
1. Установите [dash style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linedashstyle/) линии.
1. Установите цвет линии для фигуры.
1. Сохраните изменённую презентацию в файл PPTX.

Следующий код демонстрирует, как отформатировать прямоугольный `AutoShape`:
```js
// Создайте экземпляр класса Presentation, представляющий файл презентации.
let presentation = new aspose.slides.Presentation();
try {
    // Получите первый слайд.
    let slide = presentation.getSlides().get_Item(0);

    // Добавьте автоконтур типа Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);

    // Установите цвет заливки для прямоугольной фигуры.
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

## **Форматирование стилей соединения**

Вот три варианта типа соединения:

* Круглый
* Срезанный
* Скошенный

По умолчанию, когда PowerPoint соединяет две линии под углом (например, в углу фигуры), используется настройка **Round**. Однако если вы рисуете фигуру с острыми углами, вам может подойти вариант **Miter**.

![Стиль соединения в презентации](join-style-powerpoint.png)

Следующий код JavaScript демонстрирует, как три прямоугольника (как показано на изображении выше) были созданы с использованием настроек типа соединения Miter, Bevel и Round:
```js
// Создайте экземпляр класса Presentation, представляющий файл презентации.
let presentation = new aspose.slides.Presentation();
try {
    // Получите первый слайд.
    let slide = presentation.getSlides().get_Item(0);

    // Добавьте три автоконтурных фигуры типа Rectangle.
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

В PowerPoint градиентная заливка — это параметр форматирования, позволяющий применять непрерывный переход цветов к фигуре. Например, можно задать два и более цветов так, чтобы один постепенно переходил в другой.

Вот как применить градиентную заливку к фигуре с помощью Aspose.Slides:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) на слайд.
1. Установите свойство [FillType] фигуры в `Gradient`.
1. Добавьте две предпочтительные цвета с определёнными позициями, используя методы `add` коллекции остановок градиента, предоставляемой классом [GradientFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/).
1. Сохраните изменённую презентацию в файл PPTX.

```js
// Создайте экземпляр класса Presentation, представляющий файл презентации.
let presentation = new aspose.slides.Presentation();
try {
    // Получите первый слайд.
    let slide = presentation.getSlides().get_Item(0);

    // Добавьте автофигуру типа Ellipse.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);

    // Примените градиентное форматирование к эллипсу.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));

    // Задайте направление градиента.
    shape.getFillFormat().getGradientFormat().setGradientDirection(aspose.slides.GradientDirection.FromCorner2);

    // Добавьте два градиентных стопа.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, aspose.slides.PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0, aspose.slides.PresetColor.Red);

    // Сохраните файл PPTX на диск.
    presentation.save("gradient_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


Результат:

![Эллипс с градиентной заливкой](gradient-fill.png)

## **Заливка шаблоном**

В PowerPoint заливка шаблоном — это параметр форматирования, позволяющий применить двухцветный узор (например, точки, полосы, крест‑штриховку или клетки) к фигуре. Можно задать пользовательские цвета переднего плана и фона шаблона.

Aspose.Slides предоставляет более 45 предопределённых стилей шаблонов, которые можно применить к фигурам для улучшения визуального восприятия презентаций. Даже после выбора предопределённого шаблона вы всё равно можете указать точные цвета, которые он будет использовать.

Вот как применить заливку шаблоном к фигуре с помощью Aspose.Slides:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) на слайд.
1. Установите свойство [FillType] фигуры в `Pattern`.
1. Выберите стиль шаблона из предопределённых вариантов.
1. Установите [Background Color](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getBackColor--) шаблона.
1. Установите [Foreground Color](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getForeColor--) шаблона.
1. Сохраните изменённую презентацию в файл PPTX.

```js
// Создайте экземпляр класса Presentation, представляющий файл презентации.
let presentation = new aspose.slides.Presentation();
try {
    // Получите первый слайд.
    let slide = presentation.getSlides().get_Item(0);

    // Добавьте автофигуру типа Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Установите тип заливки в Pattern.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));

    // Установите стиль узора.
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));

    // Установите фон и передний цвет узора.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // Сохраните файл PPTX на диск.
    presentation.save("pattern_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


Результат:

![Прямоугольник с заливкой шаблоном](pattern-fill.png)

## **Заливка картинкой**

В PowerPoint заливка картинкой — это параметр форматирования, позволяющий вставить изображение внутрь фигуры, эффективно используя изображение как фон фигуры.

Вот как использовать Aspose.Slides для применения заливки картинкой к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) на слайд.
1. Установите свойство [FillType] фигуры в `Picture`.
1. Установите режим заливки картинкой в `Tile` (или другой предпочтительный режим).
1. Создайте объект [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) из изображения, которое хотите использовать.
1. Передайте изображение методу `ISlidesPicture.setImage`.
1. Сохраните изменённую презентацию в файл PPTX.

![Изображение лотоса](lotus.png)

```js
// Создайте экземпляр класса Presentation, представляющий файл презентации.
let presentation = new aspose.slides.Presentation();
try {
    // Получите первый слайд.
    let slide = presentation.getSlides().get_Item(0);

    // Добавьте автофигуру типа Rectangle.
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



Результат:

![Фигура с заливкой картинкой](picture-fill.png)

### **Задать картинку‑мозаику как текстуру**

Если вы хотите задать картинку‑мозаика в качестве текстуры и настроить поведение мозаики, вы можете использовать следующие методы класса [PictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): Устанавливает режим заливки картинкой — `Tile` или `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): Указывает выравнивание мозаичных элементов внутри фигуры.
- [setTileFlip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): Определяет, будет ли элемент мозаики отражён по горизонтали, вертикали или оба направления.
- [setTileOffsetX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): Устанавливает горизонтальное смещение мозаичного элемента (в пунктах) от начала фигуры.
- [setTileOffsetY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): Устанавливает вертикальное смещение мозаичного элемента (в пунктах) от начала фигуры.
- [setTileScaleX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): Определяет горизонтальный масштаб мозаичного элемента в процентах.
- [setTileScaleY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): Определяет вертикальный масштаб мозаичного элемента в процентах.

Следующий пример кода показывает, как добавить прямоугольную фигуру с мозаичной заливкой картинкой и настроить параметры мозаики:
```js
// Создайте экземпляр класса Presentation, представляющий файл презентации.
let presentation = new aspose.slides.Presentation();
try {
    // Получите первый слайд.
    let firstSlide = presentation.getSlides().get_Item(0);

    // Добавьте автофигуру прямоугольника.
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

    // Настройте режим заливки картинкой и свойства мозаики.
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

![Параметры мозаики](tile-options.png)

## **Сплошная заливка цветом**

В PowerPoint сплошная заливка цветом — это параметр форматирования, который заполняет фигуру одним однородным цветом. Этот простой фоновый цвет применяется без градиентов, текстур или узоров.

Чтобы применить сплошную заливку цветом к фигуре с помощью Aspose.Slides, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) на слайд.
1. Установите свойство [FillType] фигуры в `Solid`.
1. Назначьте предпочтительный цвет заливки фигуре.
1. Сохраните изменённую презентацию в файл PPTX.

```js
// Создайте экземпляр класса Presentation, представляющий файл презентации.
let presentation = new aspose.slides.Presentation();
try {
    // Получите первый слайд.
    let slide = presentation.getSlides().get_Item(0);

    // Добавьте автофигуру типа Rectangle.
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

![Фигура со сплошной заливкой цветом](solid-color-fill.png)

## **Установить прозрачность**

В PowerPoint при применении сплошной, градиентной, картинкой или текстурной заливки к фигурам можно также задать уровень прозрачности, контролирующий непрозрачность заливки. Более высокое значение прозрачности делает фигуру более полупрозрачной, позволяя видеть фон или находящиеся позади объекты.

Aspose.Slides позволяет задать уровень прозрачности, изменяя альфа‑компонент цвета, используемого для заливки. Вот как это сделать:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) на слайд.
1. Установите свойство [FillType] фигуры в `Solid`.
1. Используйте `Color`, чтобы определить цвет с прозрачностью (компонент `alpha` управляет прозрачностью).
1. Сохраните презентацию.

```js
// Создайте экземпляр класса Presentation, представляющий файл презентации.
let presentation = new aspose.slides.Presentation();
try {
    // Получите первый слайд.
    let slide = presentation.getSlides().get_Item(0);

    // Добавьте сплошную прямоугольную автофигуру.
    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Добавьте прозрачную прямоугольную автофигуру поверх сплошной фигуры.
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

![Прозрачная фигура](shape-transparency.png)

## **Вращение фигур**

Aspose.Slides позволяет вращать фигуры в презентациях PowerPoint. Это может быть полезно при размещении визуальных элементов с определённым выравниванием или дизайнерскими требованиями.

Чтобы вращать фигуру на слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) на слайд.
1. Установите свойство вращения фигуры на требуемый угол.
1. Сохраните презентацию.

```js
// Создайте экземпляр класса Presentation, представляющий файл презентации.
let presentation = new aspose.slides.Presentation();
try {
    // Получите первый слайд.
    let slide = presentation.getSlides().get_Item(0);

    // Добавьте автофигуру типа Rectangle.
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

![Вращение фигуры](shape-rotation.png)

## **Добавление 3D‑скосов**

Aspose.Slides позволяет применять 3D‑скосы к фигурам, настраивая их свойства [ThreeDFormat].

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) на слайд.
1. Настройте свойства [ThreeDFormat] фигуры, определив параметры скосов.
1. Сохраните презентацию.

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

    // Сохраните презентацию как файл PPTX.
    presentation.save("3D_bevel_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


Результат:

![Эффект 3D‑скосов](3D-bevel-effect.png)

## **Добавление 3D‑вращения**

Aspose.Slides позволяет применять 3D‑вращение к фигурам, настраивая их свойства [ThreeDFormat].

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) на слайд.
1. Используйте методы [setCameraType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setCameraType) и [setLightType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lightrig/#setLightType) для определения 3D‑вращения.
1. Сохраните презентацию.

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

    // Сохраните презентацию как файл PPTX.
    presentation.save("3D_rotation_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


Результат:

![Эффект 3D‑вращения](3D-rotation-effect.png)

## **Сброс форматирования**

Следующий код Java показывает, как сбросить форматирование слайда и вернуть положение, размер и форматирование всех фигур с заполнителями на [LayoutSlide] к их настройкам по умолчанию:
```js
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        // Сбросьте каждую фигуру на слайде, у которой есть заполнитель в макете.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **FAQ**

**Влияет ли форматирование фигур на конечный размер файла презентации?**

Только незначительно. Встроенные изображения и медиа‑файлы занимают большую часть объёма файла, тогда как параметры фигур, такие как цвета, эффекты и градиенты, хранятся как метаданные и практически не увеличивают размер.

**Как определить фигуры на слайде, имеющие одинаковое форматирование, чтобы сгруппировать их?**

Сравните ключевые свойства форматирования каждой фигуры — параметры заливки, линии и эффекты. Если все соответствующие значения совпадают, считается, что стили идентичны, и их можно логически сгруппировать, что упрощает последующее управление стилями.

**Можно ли сохранить набор пользовательских стилей фигур в отдельный файл для повторного использования в других презентациях?**

Да. Сохраните образцы фигур с нужными стилями в шаблон набора слайдов или в файл шаблона .POTX. При создании новой презентации откройте шаблон, клонируйте необходимые стилизованные фигуры и повторно примените их форматирование там, где это требуется.