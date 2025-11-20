---
title: 3D‑презентация
type: docs
weight: 232
url: /ru/net/3d-presentation/
keywords:
- 3D
- 3D PowerPoint
- 3D‑презентация
- 3D‑поворот
- 3D‑глубина
- 3D‑выдавливание
- 3D‑градиент
- 3D‑текст
- Презентация PowerPoint
- C#
- CSharp
- Aspose.Slides для .NET
description: "3D‑презентация PowerPoint на C# или .NET"
---

## **Обзор**
Как обычно вы создаёте 3D‑презентацию в PowerPoint?
Microsoft PowerPoint позволяет создавать 3D‑презентации, добавлять 3D‑модели, применять 3D‑эффекты к объектам, 
создавать 3D‑текст, загружать 3D‑графику в презентацию, создавать 3D‑анимацию в PowerPoint.

Создание 3D‑эффектов оказывает сильное влияние на улучшение вашей презентации, превращая её в 3D‑презентацию, и может быть самым простым способом реализации 3D‑презентации. 
Начиная с версии Aspose.Slides 20.9 добавлен новый **кроссплатформенный 3D‑движок**. Новый 3D‑движок позволяет 
экспортировать и растрировать объекты и текст с 3D‑эффектами. В предыдущих версиях 
объекты Slides с применёнными 3D‑эффектами отображались плоско. Теперь же возможно 
отображать объекты с **полноценным 3D**. 
Более того, теперь можно создавать объекты с 3D‑эффектами через публичный API Slides.

В API Aspose.Slides, чтобы превратить объект в 3D‑объект PowerPoint, используйте свойство [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/threedformat), 
которое наследует возможности интерфейса [IThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat):
- [BevelBottom](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/bevelbottom) 
and [BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/beveltop): задать фаску объекту, определить тип фаски (например, Angle, Circle, SoftRound), высоту и ширину фаски.
- [Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera): используется для имитации движений камеры вокруг объекта. Иными словами, задавая вращение, масштаб и другие свойства, вы можете управлять объектами как 3D‑моделью в PowerPoint.
- [ContourColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourcolor) 
and [ContourWidth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourwidth): задают свойства контура, чтобы объект выглядел как 3D‑объект PowerPoint.
- [Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/depth), 
[ExtrusionColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) 
and [ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight): используются для придания объекту трёхмерности, то есть преобразования 2D‑объекта в 3D‑объект, задавая его глубину или экструдируя его.
- [LightRig](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/lightrig): может создавать световой эффект на 3D‑объекте. Логика этого свойства схожа с Camera, можно задать вращение света относительно 3D‑объекта и выбрать тип света.
- [Material](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/material): установка типа материала 3D‑объекта может придать ему более живой вид. Свойство предоставляет набор предопределённых материалов, таких как: Metal, Plastic, Powder, Matte и др.

Все 3D‑возможности могут быть применены как к объектам, так и к тексту. Давайте посмотрим, как получить доступ к упомянутым выше свойствам, а затем подробно рассмотрим их шаг за шагом:
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


Сгенерированная миниатюра выглядит следующим образом:

![todo:image_alt_text](img_01_01.png)

## **3D‑поворот**
Можно вращать 3D‑объекты PowerPoint в 3D‑пространстве, что повышает интерактивность. Чтобы повернуть 3D‑объект в PowerPoint, обычно используется следующее меню:

![todo:image_alt_text](img_02_01.png)

В API Aspose.Slides вращение 3D‑объекта можно управлять с помощью свойства [IThreeDFormat.Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera):
``` csharp
IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
// ... задать другие параметры 3D сцены

using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
{
    thumbnail.Save("sample_3d.png");
}
```


## **3D‑глубина и экструзия**
Чтобы добавить третье измерение вашему объекту и превратить его в 3D‑объект, используйте свойства [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) 
and [IThreeDFormat.ExtrusionColor.Color](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor):
``` csharp
IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
// ... задать другие параметры 3D сцены

using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
{
    thumbnail.Save("sample_3d.png");
}
```


Обычно в PowerPoint используется меню Depth для установки глубины 3D‑объекта PowerPoint:

![todo:image_alt_text](img_02_02.png)


## **3D‑градиент**
Градиент можно использовать для заполнения цвета 3D‑объекта PowerPoint. Давайте создадим объект с заливкой градиентом и применим к нему 3D‑эффект:
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


И вот результат:

![todo:image_alt_text](img_02_03.png)

Помимо градиентной заливки, можно заполнить объект изображением:
``` csharp
byte[] imageData = File.ReadAllBytes("image.jpg");
IPPImage image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
// ... настройка 3D: shape.ThreeDFormat.Camera, shape.ThreeDFormat.LightRig, shape.ThreeDFormat.Extrusion* properties

using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
{
    thumbnail.Save("sample_3d.png");
}
```


Так это выглядит:

![todo:image_alt_text](img_02_04.png)

## **3D‑текст (WordArt)**
Aspose.Slides также позволяет применять 3D к тексту. Для создания 3D‑текста можно использовать трансформирующий эффект WordArt:
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
    // установить трансформ-эффект WordArt "Arch Up"
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


Вот результат:

![todo:image_alt_text](img_02_05.png)

## **FAQ**

**Сохранятся ли 3D‑эффекты при экспорте презентации в изображения/PDF/HTML?**

Да. 3D‑движок Slides рендерит 3D‑эффекты при экспорте в поддерживаемые форматы ([изображения](/slides/ru/net/convert-powerpoint-to-png/), [PDF](/slides/ru/net/convert-powerpoint-to-pdf/), [HTML](/slides/ru/net/convert-powerpoint-to-html/), и др.).

**Могу ли я получить «эффективные» (окончательные) значения параметров 3D, учитывающие темы, наследование и т.д.?**

Да. Slides предоставляет API для [чтения эффективных значений](/slides/ru/net/shape-effective-properties/) (включая 3D‑параметры — освещение, фаски и т.п.), что позволяет увидеть окончательные применённые настройки.

**Работают ли 3D‑эффекты при преобразовании презентации в видео?**

Да. При [создании кадров для видео](/slides/ru/net/convert-powerpoint-to-video/) 3D‑эффекты рендерятся так же, как и при [экспорте изображений](/slides/ru/net/convert-powerpoint-to-png/).