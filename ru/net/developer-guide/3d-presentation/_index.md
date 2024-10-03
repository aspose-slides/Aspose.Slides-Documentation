---
title: 3D Презентация
type: docs
weight: 232
url: /ru/net/3d-presentation/
keywords: "3D, 3D PowerPoint, 3D презентация, 3D вращение, 3D глубина, 3D экструзия, 3D градиент, 3D текст, презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "3D презентация PowerPoint на C# или .NET"
---


## Обзор
Как вы обычно создаете 3D презентацию PowerPoint?
Microsoft PowerPoint позволяет создавать 3D презентации, добавляя туда 3D модели, применяя 3D эффекты к фигурам,
создавая 3D текст, загружая 3D графику в презентацию, создавая 3D анимации PowerPoint.

Создание 3D эффектов значительно улучшает вашу презентацию, превращая ее в 3D презентацию, и это может быть самым простым способом реализации 3D презентации.
С версии Aspose.Slides 20.9 добавлен новый **кросс-платформенный 3D движок**. Новый 3D движок позволяет
экспортировать и растрировать фигуры и текст с 3D эффектами. В предыдущих версиях фигуры с примененными 3D эффектами отображались плоско. Но теперь стало возможным
отображать фигуры с **полноценным 3D**.
Кроме того, теперь можно создавать фигуры с 3D эффектами через публичный API Slides.

В API Aspose.Slides, чтобы сделать
фигуру 3D фигурой PowerPoint, используйте свойство [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/threedformat),
которое наследует функции интерфейса [IThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat):
- [BevelBottom](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/bevelbottom) 
и [BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/beveltop): задайте фаску для фигуры, определите тип фаски (например, Угол, Круг, Мягкий Круг), определите высоту и ширину фаски.
- [Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera): используется для имитации движения камеры вокруг объекта. Другими словами, задавая вращение камеры, зум и другие параметры - вы можете взаимодействовать со своими
фигурами как с 3D моделью в PowerPoint.
- [ContourColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourcolor)
и [ContourWidth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourwidth): задайте параметры контура, чтобы фигура выглядела как 3D фигура PowerPoint.
- [Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/depth), 
[ExtrusionColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) 
и [ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight): используются для придания фигуре трехмерности, что означает преобразование 2D фигуры в 3D фигуру,
путем задания ее глубины или экструзии.
- [LightRig](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/lightrig): может создать световой эффект для 3D фигуры. Логика этого свойства схожа с Camera, вы можете задать вращение света
относительно 3D фигуры и выбрать тип света.
- [Material](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/material): настройка типа материала 3D фигуры может добавить более живой эффект. Свойство предоставляет набор предустановленных материалов, таких как:
Металл, Пластик, Порошок, Матовая поверхность и т.д.

Все 3D функции могут быть применены как к фигурам, так и к тексту. Давайте посмотрим, как получить доступ к свойствам, упомянутым выше, а затем рассмотрим их подробно шаг за шагом:
``` csharp 
using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
    shape.TextFrame.Text = "3D";
    shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;
    
    shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
    shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
    shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
    shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
    shape.ThreeDFormat.Material = MaterialPresetType.Flat; 
    shape.ThreeDFormat.ExtrusionHeight = 100;
    shape.ThreeDFormat.ExtrusionColor.Color = Color.Blue;
    
    pres.Slides[0].GetThumbnail(2, 2).Save("sample_3d.png");
    pres.Save("sandbox_3d.pptx", SaveFormat.Pptx);
}
```

Созданный мини-просмотр выглядит так:

![todo:image_alt_text](img_01_01.png)

## 3D Вращение
Возможно вращать 3D фигуры PowerPoint в 3D плоскости, что делает их более интерактивными. Чтобы вращать 3D фигуру в PowerPoint, вы обычно используете следующее меню:

![todo:image_alt_text](img_02_01.png)

В API Aspose.Slides вращение 3D фигуры может управляться с помощью свойства [IThreeDFormat.Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera):

``` csharp
IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
// ... установить другие параметры 3D сцены
pres.Slides[0].GetThumbnail(2, 2).Save("sample_3d.png");
```

## 3D Глубина и Экструзия
Чтобы придать третье измерение вашей фигуре и сделать ее 3D фигурой, используйте свойства [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) 
и [IThreeDFormat.ExtrusionColor.Color](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor):

``` csharp
IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
// ... установить другие параметры 3D сцены
pres.Slides[0].GetThumbnail(2, 2).Save("sample_3d.png");
```

Обычно вы используете меню Глубина в PowerPoint, чтобы задать Глубину для 3D фигуры PowerPoint:

![todo:image_alt_text](img_02_02.png)


## 3D Градиент
Градиент может использоваться для заливки цвета 3D фигуры PowerPoint. Давайте создадим фигуру с градиентной заливкой и применим к ней 3D эффект:

``` csharp
using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.TextFrame.Text = "3D Градиент";
    shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientStops.Add(0, Color.Blue);
    shape.FillFormat.GradientFormat.GradientStops.Add(100, Color.Orange);
   
    shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
    shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
    shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
    shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
    shape.ThreeDFormat.ExtrusionHeight = 150;
    shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;
   
    pres.Slides[0].GetThumbnail(2, 2).Save("sample_3d.png");
}
```

А вот и результат:

![todo:image_alt_text](img_02_03.png)

Кроме градиентной заливки, возможно заполнить фигуры изображением:
``` csharp
shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = pres.Images.AddImage(File.ReadAllBytes("image.jpg"));
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
// .. настройка 3D: shape.ThreeDFormat.Camera, shape.ThreeDFormat.LightRig, shape.ThreeDFormat.Extrusion* свойства
pres.Slides[0].GetThumbnail(2, 2).Save("sample_3d.png");
```


Вот как это выглядит:

![todo:image_alt_text](img_02_04.png)

## 3D Текст (WordArt)
Aspose.Slides также позволяет применять 3D эффекты к тексту. Для создания 3D текста можно использовать эффект трансформации WordArt:

``` csharp
using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
    shape.TextFrame.Text = "3D Текст";
   
    Portion portion = (Portion)shape.TextFrame.Paragraphs[0].Portions[0];
    portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
    portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
    portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
    portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.LargeGrid;
   
    shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 128;
   
    ITextFrame textFrame = shape.TextFrame;
    // настройка эффекта трансформации WordArt "Арка вверх"
    textFrame.TextFrameFormat.Transform = TextShapeType.ArchUp;

    textFrame.TextFrameFormat.ThreeDFormat.ExtrusionHeight = 3.5f;
    textFrame.TextFrameFormat.ThreeDFormat.Depth = 3;
    textFrame.TextFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;
    textFrame.TextFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
    textFrame.TextFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
    textFrame.TextFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

    textFrame.TextFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;
   
    pres.Slides[0].GetThumbnail(2, 2).Save("text3d.png");
    pres.Save("text3d.pptx", SaveFormat.Pptx);
}
```

Вот такой результат:

![todo:image_alt_text](img_02_05.png)


## Не Поддерживается - В ближайшее время
Следующие функции 3D PowerPoint пока не поддерживаются:
- Фаска
- Материал
- Контур
- Освещение

Мы продолжаем улучшать наш 3D движок, и эти функции находятся в процессе дальнейшей реализации.