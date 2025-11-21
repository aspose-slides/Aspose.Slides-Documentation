---
title: Создание 3D презентаций в .NET
linktitle: 3D Презентация
type: docs
weight: 232
url: /ru/net/3d-presentation/
keywords:
- 3D PowerPoint
- 3D презентация
- 3D вращение
- 3D глубина
- 3D экструзия
- 3D градиент
- 3D текст
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Легко создавайте интерактивные 3D презентации в .NET с помощью Aspose.Slides. Быстро экспортируйте в форматы PowerPoint и OpenDocument для универсального использования."
---

## **Обзор**
Как обычно создаёте 3D‑презентацию в PowerPoint?  
Microsoft PowerPoint позволяет создавать 3D‑презентации: добавлять 3D‑модели, применять 3D‑эффекты к фигурам, создавать 3D‑текст, загружать 3D‑графику в презентацию, создавать 3D‑анимацию PowerPoint.

Создание 3D‑эффектов сильно улучшает вашу презентацию, превращая её в 3D‑презентацию, и часто является самым простым способом реализации 3D‑презентации.  
Начиная с версии Aspose.Slides 20.9 добавлен новый **кроссплатформенный 3D‑движок**. Новый 3D‑движок позволяет экспортировать и растеризовать фигуры и текст с 3D‑эффектами. В предыдущих версиях фигуры Slides с применёнными 3D‑эффектами рендерились плоско. Теперь же можно рендерить фигуры с **полноценным 3D**.  
Более того, теперь можно создавать фигуры с 3D‑эффектами через публичный API Slides.

В API Aspose.Slides, чтобы превратить фигуру в 3D‑фигуру PowerPoint, используйте свойство [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/threedformat), которое наследует возможности интерфейса [IThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat):
- [BevelBottom](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/bevelbottom) и [BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/beveltop): задают фаску фигуре, определяют тип фаски (например, Angle, Circle, SoftRound), высоту и ширину фаски.
- [Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera): используется для имитации движений камеры вокруг объекта. Иными словами, задавая вращение, масштаб и другие свойства, вы можете «развлекать» свои фигуры так же, как 3D‑модель в PowerPoint.
- [ContourColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourcolor) и [ContourWidth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourwidth): задают свойства контура, чтобы фигура выглядела как 3D‑фигура PowerPoint.
- [Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/depth), [ExtrusionColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) и [ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight): используются для придания фигуре трёхмерности, то есть преобразования 2D‑фигуры в 3D‑фигуру путём задания её глубины или экструзии.
- [LightRig](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/lightrig): создаёт световой эффект на 3D‑фигуре. Логика этого свойства близка к Camera: можно задать вращение света относительно 3D‑фигуры и выбрать тип освещения.
- [Material](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/material): установка типа материала 3D‑фигуры добавляет более живой эффект. Свойство предоставляет набор предопределённых материалов, например: Metal, Plastic, Powder, Matte и др.

Все 3D‑возможности могут применяться как к фигурам, так и к тексту. Давайте посмотрим, как получить доступ к перечисленным выше свойствам, а затем подробно разберём их шаг за шагом:
``` csharp 
const float imageScale = 2;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
    shape.TextFrame.Text = "3D";
    shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

    shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
    shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
    shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
    shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
    shape.ThreeDFormat.Material = MaterialPresetType.Flat;
    shape.ThreeDFormat.ExtrusionHeight = 100;
    shape.ThreeDFormat.ExtrusionColor.Color = Color.Blue;

    using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
    {
        thumbnail.Save("sample_3d.png");
    }

    presentation.Save("sandbox_3d.pptx", SaveFormat.Pptx);
}
```


Сгенерированная миниатюра выглядит так:

![todo:image_alt_text](img_01_01.png)

## **3D‑вращение**
Можно вращать 3D‑фигуры PowerPoint в 3D‑пространстве, что повышает интерактивность. Чтобы вращать 3D‑фигуру в PowerPoint, обычно используют следующее меню:

![todo:image_alt_text](img_02_01.png)

В API Aspose.Slides вращение 3D‑фигур может управляться с помощью свойства [IThreeDFormat.Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera):
``` csharp
IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
// ... установить другие параметры 3D-сцены

using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
{
    thumbnail.Save("sample_3d.png");
}
```


## **3D глубина и экструдирование**
Чтобы добавить третье измерение к вашей фигуре и превратить её в 3D‑фигуру, используйте свойства [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) и [IThreeDFormat.ExtrusionColor.Color](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor):
``` csharp
IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
// ... установить другие параметры 3D-сцены

using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
{
    thumbnail.Save("sample_3d.png");
}
```


Обычно в PowerPoint используют меню Depth для задания глубины 3D‑фигуры PowerPoint:

![todo:image_alt_text](img_02_02.png)

## **3D‑градиент**
Градиент может использоваться для заполнения цвета 3D‑фигуры PowerPoint. Создадим фигуру с градиентной заливкой и применим к ней 3D‑эффект:
``` csharp
const float imageScale = 2;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.TextFrame.Text = "3D Gradient";
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

    using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
    {
        thumbnail.Save("sample_3d.png");
    }
}
```


И результат выглядит так:

![todo:image_alt_text](img_02_03.png)

Помимо градиентной заливки, фигуры можно заполнять изображением:
``` csharp
byte[] imageData = File.ReadAllBytes("image.jpg");
IPPImage image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
// ... настройка 3D: shape.ThreeDFormat.Camera, shape.ThreeDFormat.LightRig, shape.ThreeDFormat.Extrusion* свойства

using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
{
    thumbnail.Save("sample_3d.png");
}
```


Вот как это выглядит:

![todo:image_alt_text](img_02_04.png)

## **3D‑текст (WordArt)**
Aspose.Slides позволяет применять 3D к тексту. Для создания 3D‑текста можно использовать эффект трансформации WordArt:
``` csharp
const float imageScale = 2;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
    shape.TextFrame.Text = "3D Text";

    Portion portion = (Portion)shape.TextFrame.Paragraphs[0].Portions[0];
    portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
    portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
    portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
    portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.LargeGrid;

    shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 128;

    ITextFrameFormat textFrameFormat = shape.TextFrame.TextFrameFormat;
    // установить трансформацию WordArt "Arch Up"
    textFrameFormat.Transform = TextShapeType.ArchUp;

    textFrameFormat.ThreeDFormat.ExtrusionHeight = 3.5f;
    textFrameFormat.ThreeDFormat.Depth = 3;
    textFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;
    textFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
    textFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
    textFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

    textFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;

    using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
    {
        thumbnail.Save("text3d.png");
    }

    presentation.Save("text3d.pptx", SaveFormat.Pptx);
}
```


Результат:

![todo:image_alt_text](img_02_05.png)

## **FAQ**

**Будут ли 3D‑эффекты сохранены при экспорте презентации в изображения/PDF/HTML?**

Да. 3D‑движок Slides рендерит 3D‑эффекты при экспорте в поддерживаемые форматы ([images](/slides/ru/net/convert-powerpoint-to-png/), [PDF](/slides/ru/net/convert-powerpoint-to-pdf/), [HTML](/slides/ru/net/convert-powerpoint-to-html/), и т.д.).

**Можно ли получить «эффективные» (финальные) значения параметров 3D, учитывающие темы, наследование и пр.?**

Да. Slides предоставляет API для [чтения эффективных значений](/slides/ru/net/shape-effective-properties/) (включая 3D‑освещение, фаски и др.), чтобы увидеть окончательные применённые настройки.

**Работают ли 3D‑эффекты при конвертации презентации в видео?**

Да. При [генерации кадров для видео](/slides/ru/net/convert-powerpoint-to-video/) 3D‑эффекты рендерятся так же, как при [экспорте изображений](/slides/ru/net/convert-powerpoint-to-png/).