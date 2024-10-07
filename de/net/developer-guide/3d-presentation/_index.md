---
title: 3D-Präsentation
type: docs
weight: 232
url: /net/3d-presentation/
keywords:
- 3D
- 3D PowerPoint
- 3D-Präsentation
- 3D-Rotation
- 3D-Tiefe
- 3D-Extrusion
- 3D-Gradient
- 3D-Text
- PowerPoint-Präsentation
- C#
- Csharp
- Aspose.Slides für .NET
description: "3D PowerPoint-Präsentation in C# oder .NET"
---


## Übersicht
Wie erstellen Sie normalerweise eine 3D PowerPoint-Präsentation?
Microsoft PowerPoint ermöglicht es, 3D-Präsentationen zu erstellen, indem wir dort 3D-Modelle hinzufügen, 3D-Effekte auf Formen anwenden, 
3D-Text erstellen, 3D-Grafiken in die Präsentation hochladen und PowerPoint 3D-Animationen erstellen. 

Die Erstellung von 3D-Effekten hat einen großen Einfluss auf die Verbesserung Ihrer Präsentation zu einer 3D-Präsentation und kann die einfachste Umsetzung einer 3D-Präsentation sein. 
Seit der Version 20.9 von Aspose.Slides wurde ein neuer **plattformerweiterter 3D-Engine** hinzugefügt. Der neue 3D-Engine ermöglicht es, 
Formen und Text mit 3D-Effekten zu exportieren und zu rasterisieren. In früheren Versionen 
wurden Formen mit 3D-Effekten flach dargestellt. Aber jetzt ist es möglich, 
Formen mit einer **vollwertigen 3D** darzustellen.
Darüber hinaus ist es jetzt möglich, Formen mit 3D-Effekten über die öffentliche API von Slides zu erstellen.

Im Aspose.Slides API, um 
eine Form zu einer PowerPoint 3D-Form zu machen, verwenden Sie die [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/threedformat) Eigenschaft, 
die die Eigenschaften des [IThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat) Interfaces erbt:
- [BevelBottom](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/bevelbottom) 
und [BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/beveltop): Bevel für die Form einstellen, Bevel-Typ definieren (z.B. Winkel, Kreis, weich rund), Höhe und Breite des Bevels definieren.
- [Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera): wird verwendet, um Kamerabewegungen um das Objekt zu imitieren. Mit anderen Worten, durch die Einstellung der Kamerarotation, Zoom und anderen Eigenschaften - können Sie mit Ihren 
Formen wie mit dem 3D-Modell in PowerPoint interagieren.
- [ContourColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourcolor) 
und [ContourWidth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourwidth): Kontureigenschaften festlegen, um die Form wie eine 3D-PowerPoint-Form aussehen zu lassen.
- [Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/depth), 
[ExtrusionColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) 
und [ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight): werden verwendet, um die Form dreidimensional zu machen, was bedeutet, eine 2D-Form in eine 3D-Form zu konvertieren, 
indem man ihre Tiefe einstellt oder sie extrudiert.
- [LightRig](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/lightrig): kann einen Lichteffekt auf einer 3D-Form erzeugen. Die Logik dieser Eigenschaft ist ähnlich wie bei der Kamera, Sie können die Rotation des Lichts 
im Verhältnis zur 3D-Form einstellen und den Lichttyp wählen.
- [Material](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/material): Durch das Festlegen des Typs des 3D-Formmaterials kann ein lebendigerer Effekt erzielt werden. Die Eigenschaft bietet eine Reihe vordefinierter Materialien, wie: 
Metall, Kunststoff, Pulver, Matt, usw.

Alle 3D-Funktionen können sowohl auf Formen als auch auf Text angewendet werden. Lassen Sie uns sehen, wie man auf die oben genannten Eigenschaften zugreift und sie dann Schritt für Schritt im Detail betrachtet:
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

Das gerenderte Thumbnail sieht so aus:

![todo:image_alt_text](img_01_01.png)

## 3D-Rotation
Es ist möglich, PowerPoint 3D-Formen im 3D-Raum zu drehen, was mehr Interaktivität bringt. Um eine 3D-Form in PowerPoint zu drehen, verwenden Sie normalerweise das folgende Menü:

![todo:image_alt_text](img_02_01.png)

In der Aspose.Slides API kann die 3D-Formrotation über die [IThreeDFormat.Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera) Eigenschaft verwaltet werden:

``` csharp
IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
// ... andere 3D-Szenenparameter festlegen

using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
{
    thumbnail.Save("sample_3d.png");
}
```

## 3D-Tiefe und Extrusion
Um der Form die dritte Dimension zu verleihen und sie zu einer 3D-Form zu machen, verwenden Sie die [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) 
und [IThreeDFormat.ExtrusionColor.Color](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) Eigenschaften:

``` csharp
IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
// ... andere 3D-Szenenparameter festlegen

using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
{
    thumbnail.Save("sample_3d.png");
}
```

In der Regel verwenden Sie das Tiefenmenü in PowerPoint, um die Tiefe für die PowerPoint 3D-Form festzulegen:

![todo:image_alt_text](img_02_02.png)


## 3D-Gradient
Ein Gradient kann verwendet werden, um die Farbe der PowerPoint 3D-Form zu füllen. Lassen Sie uns eine Form mit Farbverlauf und 3D-Effekt erstellen:

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

Und hier ist das Ergebnis:

![todo:image_alt_text](img_02_03.png)

Neben einer Farbverlauffüllfarbe ist es auch möglich, Formen mit einem Bild zu füllen:
``` csharp
byte[] imageData = File.ReadAllBytes("image.jpg");
IPPImage image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
// ... 3D einrichten: shape.ThreeDFormat.Camera, shape.ThreeDFormat.LightRig, shape.ThreeDFormat.Extrusion* Eigenschaften

using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
{
    thumbnail.Save("sample_3d.png");
}
```

So sieht es aus:

![todo:image_alt_text](img_02_04.png)

## 3D-Text (WordArt)
Aspose.Slides ermöglicht es auch, 3D auf Text anzuwenden. Um einen 3D-Text zu erstellen, können Sie den WordArt-Transformeffekt verwenden:

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
    // Setzen Sie den WordArt-Transformeffekt "Bogen nach oben"
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

Hier ist das Ergebnis:

![todo:image_alt_text](img_02_05.png)


## Nicht Unterstützt - Kommt Bald
Die folgenden PowerPoint 3D-Funktionen werden noch nicht unterstützt: 
- Bevel
- Material
- Kontur
- Beleuchtung

Wir setzen die Verbesserung unserer 3D-Engine fort, und diese Funktionen sind Gegenstand weiterer Implementierungen.