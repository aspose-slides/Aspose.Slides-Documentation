---
title: Форматирование фигур
type: docs
weight: 20
url: /ru/net/shape-formatting/
keywords: "Формат фигуры, формат линий, стили соединений, градиентная заливка, заливка узором, заливка изображением, заливка сплошным цветом, поворот фигур, 3D эффекты фаски, 3D эффект вращения, презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Форматирование фигуры в презентации PowerPoint на C# или .NET"
---

В PowerPoint вы можете добавлять фигуры на слайды. Поскольку фигуры состоят из линий, вы можете форматировать фигуры, изменяя или применяя определенные эффекты к их составным линиям. Кроме того, вы можете форматировать фигуры, указывая настройки, которые определяют, как они (их области) заливаются.

![format-shape-powerpoint](format-shape-powerpoint.png)

**Aspose.Slides для .NET** предоставляет интерфейсы и свойства, которые позволяют вам форматировать фигуры на основе известных параметров в PowerPoint.

## **Формат линий**

С помощью Aspose.Slides вы можете определить свой предпочитаемый стиль линии для фигуры. Эти шаги описывают такую процедуру:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите ссылку на слайд через его индекс. 
3. Добавьте [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) на слайд.
4. Установите цвет для линий фигуры.
5. Установите ширину для линий фигуры.
6. Установите [стиль линии](https://reference.aspose.com/slides/net/aspose.slides/linestyle) для линии фигуры.
7. Установите [стиль штриха](http://aspose.com/api/net/slides/aspose.slides/linedashstyle) для линии фигуры. 
8. Запишите измененную презентацию в файл PPTX.

Этот код на C# демонстрирует операцию, в которой мы форматируем прямоугольник `AutoShape`:

```c#
// Создает экземпляр класса презентации, который представляет файл презентации
using (Presentation pres = new Presentation())
{
    // Получает первый слайд
    ISlide sld = pres.Slides[0];

    // Добавляет автопформу прямоугольной формы
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Устанавливает цвет заливки для фигуры прямоугольника
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.White;

    // Применяет некоторые настройки к линиям прямоугольника
    shp.LineFormat.Style = LineStyle.ThickThin;
    shp.LineFormat.Width = 7;
    shp.LineFormat.DashStyle = LineDashStyle.Dash;

    // Устанавливает цвет для линии прямоугольника
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Записывает файл PPTX на диск
    pres.Save("RectShpLn_out.pptx", SaveFormat.Pptx);
}
```

## **Формат стилей соединений**
Это три варианта типа соединения:

* Закругленный
* Скошенный
* Фаска

По умолчанию, когда PowerPoint соединяет две линии под углом (или угол фигуры), используется настройка **Закругленный**. Однако, если вы хотите нарисовать фигуру с очень острыми углами, вам может понадобиться выбрать **Скошенный**.

![join-style-powerpoint](join-style-powerpoint.png)

Этот код на C# демонстрирует операцию, в которой были созданы 3 прямоугольника (на изображении выше) с настройками типа соединения Скошенный, Фаска и Закругленный:

```c#
// Создает экземпляр класса презентации, который представляет файл презентации
using (Presentation pres = new Presentation())
{
    // Получает первый слайд
    ISlide sld = pres.Slides[0];

    // Добавляет 3 прямоугольные автопформы
    IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 100, 150, 75);
    IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 100, 150, 75);
    IShape shp3 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 250, 150, 75);

    // Устанавливает цвет заливки для фигуры прямоугольника
    shp1.FillFormat.FillType = FillType.Solid;
    shp1.FillFormat.SolidFillColor.Color = Color.Black;
    shp2.FillFormat.FillType = FillType.Solid;
    shp2.FillFormat.SolidFillColor.Color = Color.Black;
    shp3.FillFormat.FillType = FillType.Solid;
    shp3.FillFormat.SolidFillColor.Color = Color.Black;

    // Устанавливает ширину линии
    shp1.LineFormat.Width = 15;
    shp2.LineFormat.Width = 15;
    shp3.LineFormat.Width = 15;

    // Устанавливает цвет линии для фигуры прямоугольника
    shp1.LineFormat.FillFormat.FillType = FillType.Solid;
    shp1.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shp2.LineFormat.FillFormat.FillType = FillType.Solid;
    shp2.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shp3.LineFormat.FillFormat.FillType = FillType.Solid;
    shp3.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Устанавливает стиль соединения
    shp1.LineFormat.JoinStyle = LineJoinStyle.Miter;
    shp2.LineFormat.JoinStyle = LineJoinStyle.Bevel;
    shp3.LineFormat.JoinStyle = LineJoinStyle.Round;

    // Добавляет текст к каждому прямоугольнику
    ((IAutoShape)shp1).TextFrame.Text = "Скошенный стиль соединения";
    ((IAutoShape)shp2).TextFrame.Text = "Фаска стиль соединения";
    ((IAutoShape)shp3).TextFrame.Text = "Закругленный стиль соединения";

    // Записывает файл PPTX на диск
    pres.Save("RectShpLnJoin_out.pptx", SaveFormat.Pptx);
}
```

## **Градиентная заливка**
В PowerPoint Градиентная заливка – это опция форматирования, которая позволяет применять непрерывный переход цветов к фигуре. Например, вы можете применить два или более цвета в настройке, где один цвет постепенно затухает и изменяется на другой цвет.

Вот как вы используете Aspose.Slides для применения градиентной заливки к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите ссылку на слайд через его индекс. 
3. Добавьте [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) на слайд.
4. Установите [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype) фигуры на `Gradient`.
5. Добавьте ваши 2 предпочитаемых цвета с определенными позициями, используя методы `Add`, предоставленные коллекцией `GradientStops`, связанной с классом `GradientFormat`.
6. Запишите измененную презентацию в файл PPTX.

Этот код на C# демонстрирует операцию, когда эффект градиентной заливки был применен к эллипсу:

```c#
// Создает экземпляр класса презентации, который представляет файл презентации
using (Presentation pres = new Presentation())
{
    // Получает первый слайд
    ISlide sld = pres.Slides[0];

    // Добавляет эллипсоидную автоп форму
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 75, 150);

    // Применяет градиентное форматирование к эллипсу
    shp.FillFormat.FillType = FillType.Gradient;
    shp.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // Устанавливает направление градиента
    shp.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // Добавляет 2 градиентные точки
    shp.FillFormat.GradientFormat.GradientStops.Add((float)1.0, PresetColor.Purple);
    shp.FillFormat.GradientFormat.GradientStops.Add((float)0, PresetColor.Red);

    // Записывает файл PPTX на диск
    pres.Save("EllipseShpGrad_out.pptx", SaveFormat.Pptx);
}
```

## **Заливка узором**
В PowerPoint Заливка узором – это опция форматирования, которая позволяет применить двухцветный дизайн, состоящий из точек, полос, крестиков или клеток, к фигуре. Кроме того, вы можете выбрать предпочитаемые цвета для переднего и заднего плана вашего узора.

Aspose.Slides предоставляет более 45 предустановленных стилей, которые можно использовать для форматирования фигур и обогащения презентаций. Даже после того, как вы выбрали предустановленный узор, вы все равно можете указать цвета, которые должен содержать узор.

Вот как вы используете Aspose.Slides для применения заливки узором к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите ссылку на слайд через его индекс. 
3. Добавьте [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) на слайд.
4. Установите [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype) фигуры на `Pattern`.
5. Установите стиль узора, который вам нужен для фигуры. 
6. Установите [Цвет фона](http://www.aspose.com/api/net/slides/aspose.slides/patternformat/properties/backcolor) для [PatternFormat](http://www.aspose.com/api/net/slides/aspose.slides/patternformat).
7. Установите [Цвет переднего плана](http://www.aspose.com/api/net/slides/aspose.slides/patternformat/properties/forecolor) для [PatternFormat](http://www.aspose.com/api/net/slides/aspose.slides/patternformat).
8. Запишите измененную презентацию в файл PPTX.

Этот код на C# демонстрирует операцию, в которой заливка узором была использована для улучшения внешнего вида прямоугольника:

```c#
// Создает экземпляр класса презентации, который представляет файл презентации
using (Presentation pres = new Presentation())
{
    // Получает первый слайд
    ISlide sld = pres.Slides[0];

    // Добавляет прямоугольную автоп форму
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // Устанавливает тип заливки на узор
    shp.FillFormat.FillType = FillType.Pattern;

    // Устанавливает стиль узора
    shp.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // Устанавливает цвета узора
    shp.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shp.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // Записывает файл PPTX на диск
    pres.Save("RectShpPatt_out.pptx", SaveFormat.Pptx);
}
```

## **Заливка изображением**
В PowerPoint Заливка изображением – это опция форматирования, которая позволяет вставить изображение внутрь фигуры. Фактически, вы можете использовать изображение в качестве фона фигуры.

Вот как вы используете Aspose.Slides для заливки фигуры изображением:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. Получите ссылку на слайд через его индекс. 
3. Добавьте [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) на слайд.
4. Установите [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype) фигуры на `Picture`.
5. Установите режим заливки картинки на Мозаика.
6. Создайте объект `IPPImage` с использованием изображения, которое будет использоваться для заливки фигуры.
7. Установите свойство `Picture.Image` объекта `PictureFillFormat` на недавно созданный `IPPImage`.
8. Запишите измененную презентацию в файл PPTX.

Этот код на C# показывает, как заполнить фигуру изображением:

```c#
// Создает экземпляр класса презентации, который представляет файл презентации
using (Presentation pres = new Presentation())
{
    // Получает первый слайд
    ISlide sld = pres.Slides[0];

    // Добавляет прямоугольную автоп форму
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // Устанавливает тип заливки на изображение
    shp.FillFormat.FillType = FillType.Picture;

    // Устанавливает режим заливки картинки
    shp.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

    // Устанавливает изображение
    System.Drawing.Image img = (System.Drawing.Image)new Bitmap("Tulips.jpg");
    IPPImage imgx = pres.Images.AddImage(img);
    shp.FillFormat.PictureFillFormat.Picture.Image = imgx;

    // Записывает файл PPTX на диск
    pres.Save("RectShpPic_out.pptx", SaveFormat.Pptx);
}
```

## **Сплошная заливка цвета**
В PowerPoint Сплошная заливка цвета – это опция форматирования, которая позволяет заполнить фигуру одним цветом. Выбранный цвет, как правило, является простым цветом. Цвет применяется к фону фигуры с любыми специальными эффектами или изменениями.

Вот как вы используете Aspose.Slides для применения сплошной заливки цвета к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите ссылку на слайд через его индекс. 
3. Добавьте [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) на слайд.
4. Установите [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype) фигуры на `Solid`.
5. Установите свой предпочитаемый цвет для фигуры.
6. Запишите измененную презентацию в файл PPTX.

Этот код на C# показывает, как применить сплошную заливку цвета к фигуре в PowerPoint:

```c#
// Создает экземпляр класса презентации, который представляет файл презентации
using (Presentation presentation = new Presentation())
{
    // Получает первый слайд
    ISlide slide = presentation.Slides[0];

    // Добавляет прямоугольную автоп форму
    IShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // Устанавливает тип заливки на Сплошной
    shape.FillFormat.FillType = FillType.Solid;

    // Устанавливает цвет для прямоугольника
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // Записывает файл PPTX на диск
    presentation.Save("RectShpSolid_out.pptx", SaveFormat.Pptx);
}
```

## **Установить прозрачность**

В PowerPoint, когда вы заполняете фигуры сплошными цветами, градиентами, изображениями или текстурами, вы можете задать уровень прозрачности, который определяет непрозрачность заливки. Таким образом, например, если вы установите низкий уровень прозрачности, объект слайда или фон позади (фигуры) будет просвечиваться.

Aspose.Slides позволяет установить уровень прозрачности для фигуры следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите ссылку на слайд через его индекс. 
3. Добавьте [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) на слайд.
4. Используйте `Color.FromArgb` с установленным компонентом альфа.
5. Сохраните объект как файл PowerPoint.

Этот код на C# демонстрирует процесс:

```c#
// Создает экземпляр класса презентации, который представляет файл презентации
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    
    // Добавляет сплошную фигуру
    IShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 75, 175, 75, 150);

    // Добавляет прозрачную фигуру поверх сплошной фигуры
    IShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);
    shape.FillFormat.FillType = FillType.Solid;
    shape.FillFormat.SolidFillColor.Color = Color.FromArgb(128, 204, 102, 0);
    
    // Записывает файл PPTX на диск
    presentation.Save("ShapeTransparentOverSolid_out.pptx", SaveFormat.Pptx);
}
```

## **Повернуть фигуры**
Aspose.Slides позволяет вам поворачивать фигуру, добавленную на слайд, следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите ссылку на слайд через его индекс. 
3. Добавьте [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) на слайд.
4. Поверните фигуру на необходимое количество градусов. 
5. Запишите измененную презентацию в файл PPTX.

Этот код на C# показывает, как повернуть фигуру на 90 градусов:

```c#
// Создает экземпляр класса презентации, который представляет файл презентации
using (Presentation pres = new Presentation())
{
    // Получает первый слайд
    ISlide sld = pres.Slides[0];

    // Добавляет прямоугольную автоп форму
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // Поворачивает фигуру на 90 градусов
    shp.Rotation = 90;

    // Записывает файл PPTX на диск
    pres.Save("RectShpRot_out.pptx", SaveFormat.Pptx);
}
```

## **Добавить 3D эффекты фаски**
Aspose.Slides позволяет добавлять 3D эффекты фаски к фигуре, изменяя свойства [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ThreeDFormat) следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите ссылку на слайд через его индекс. 
3. Добавьте [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) на слайд.
3. Установите предпочтительные параметры для свойств [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ThreeDFormat) фигуры. 
4. Запишите презентацию на диск.

Этот код на C# показывает, как добавить эффекты 3D фаски к фигуре:

```c#
// Создает экземпляр класса презентации
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    
    // Добавляет фигуру на слайд
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 30, 30, 100, 100);
    shape.FillFormat.FillType = FillType.Solid;
    shape.FillFormat.SolidFillColor.Color = Color.Green;
    ILineFillFormat format = shape.LineFormat.FillFormat;
    format.FillType = FillType.Solid;
    format.SolidFillColor.Color = Color.Orange;
    shape.LineFormat.Width = 2.0;
    
    // Устанавливает свойства Shape's ThreeDFormat
    shape.ThreeDFormat.Depth = 4;
    shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    shape.ThreeDFormat.BevelTop.Height = 6;
    shape.ThreeDFormat.BevelTop.Width = 6;
    shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
    shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
    shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
    
    // Записывает презентацию в файл PPTX
    pres.Save("Bavel_out.pptx", SaveFormat.Pptx);
}
```

## **Добавить 3D эффект вращения**
Aspose.Slides позволяет применять 3D эффекты вращения к фигуре, изменяя свойства [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ThreeDFormat) следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите ссылку на слайд через его индекс. 
3. Добавьте [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) на слайд.
3. Укажите предпочитаемые параметры для [CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/properties/cameratype) и [LightType](https://reference.aspose.com/slides/net/aspose.slides/ilightrig/properties/lighttype).
4. Запишите презентацию на диск. 

Этот код на C# показывает, как применять 3D эффекты вращения к фигуре:

```c#
// Создает экземпляр класса презентации
using (Presentation pres = new Presentation())
{
    IShape autoShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 200, 200);
    
    autoShape.ThreeDFormat.Depth = 6;
    autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
    
    autoShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Line, 30, 300, 200, 200);
    autoShape.ThreeDFormat.Depth = 6;
    autoShape.ThreeDFormat.Camera.SetRotation(0, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
    
    // Записывает презентацию в файл PPTX
    pres.Save("Rotation_out.pptx", SaveFormat.Pptx);
}
```

## **Сброс форматирования**

Этот код на C# показывает, как сбросить форматирование на слайде и вернуть позицию, размер и форматирование каждой фигуры, имеющей заполнение на [LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/), к их значениям по умолчанию:

```c#
using (Presentation pres = new Presentation())
{
    foreach (ISlide slide in pres.Slides)
    {
        // каждая фигура на слайде, которая имеет заполнение на макете, будет возвращена
        slide.Reset();
    }
}
```