---
title: 3D-Präsentation
type: docs
weight: 232
url: /de/net/3d-presentation/
keywords:
- 3D
- 3D PowerPoint
- 3D-Präsentation
- 3D-Drehung
- 3D-Tiefe
- 3D-Extrusion
- 3D-Verlauf
- 3D-Text
- PowerPoint-Präsentation
- C#
- Csharp
- Aspose.Slides für .NET
description: "3D PowerPoint-Präsentation in C# oder .NET"
---

## **Übersicht**
Wie erstellen Sie normalerweise eine 3D‑PowerPoint‑Präsentation?
Microsoft PowerPoint ermöglicht das Erstellen von 3D‑Präsentationen, indem wir dort 3D‑Modelle hinzufügen, 3D‑Effekte auf Formen anwenden, 3D‑Text erstellen, 3D‑Grafiken in die Präsentation hochladen und PowerPoint‑3D‑Animationen erzeugen.

Das Erzeugen von 3D‑Effekten hat einen großen Einfluss darauf, Ihre Präsentation zu einer 3D‑Präsentation zu verbessern, und kann die einfachste Implementierung einer 3D‑Präsentation sein.
Seit der Version 20.9 von Aspose.Slides wurde eine neue **plattformübergreifende 3D‑Engine** hinzugefügt. Die neue 3D‑Engine ermöglicht das Exportieren und Rasterisieren von Formen und Text mit 3D‑Effekten. In früheren Versionen wurden Formen mit angewendeten 3D‑Effekten flach gerendert. Jetzt ist es jedoch möglich, Formen mit einem **vollen 3D‑Render** darzustellen.
Außerdem können Formen mit 3D‑Effekten nun über die öffentliche Slides‑API erstellt werden.

In der Aspose.Slides‑API verwenden Sie die Eigenschaft [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/threedformat), die die Merkmale des Interfaces [IThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat) erbt, um 
eine Form zu einer PowerPoint‑3D‑Form zu machen:
- [BevelBottom](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/bevelbottom) 
und [BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/beveltop): Begrenzung (Bevel) für die Form festlegen, Typ (z. B. Angle, Circle, SoftRound) definieren, Höhe und Breite der Begrenzung bestimmen.
- [Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera): Wird verwendet, um Kamerabewegungen um das Objekt zu simulieren. Durch das Einstellen von Drehung, Zoom und anderen Eigenschaften können Sie Ihre Formen wie ein 3D‑Modell in PowerPoint manipulieren.
- [ContourColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourcolor) 
und [ContourWidth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourwidth): Kontur‑Eigenschaften festlegen, damit die Form wie eine 3D‑PowerPoint‑Form aussieht.
- [Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/depth), 
[ExtrusionColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) 
und [ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight): Werden verwendet, um die Form dreidimensional zu machen, d. h. eine 2D‑Form in eine 3D‑Form zu konvertieren, indem Sie die Tiefe setzen oder sie extrudieren.
- [LightRig](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/lightrig): Kann einen Lichteffekt auf einer 3D‑Form erzeugen. Die Logik dieser Eigenschaft ähnelt der von Camera; Sie können die Drehung des Lichts relativ zur 3D‑Form festlegen und den Lichttyp wählen.
- [Material](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/material): Das Festlegen des Materials einer 3D‑Form verleiht ihr ein lebendigeres Aussehen. Die Eigenschaft bietet vordefinierte Materialien wie Metal, Plastic, Powder, Matte usw.

Alle 3D‑Funktionen können sowohl auf Formen als auch auf Text angewendet werden. Lassen Sie uns sehen, wie Sie die oben genannten Eigenschaften verwenden und sie anschließend Schritt für Schritt im Detail betrachten:
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


Das gerenderte Vorschaubild sieht so aus:

![todo:image_alt_text](img_01_01.png)

## **3D‑Drehung**
Es ist möglich, PowerPoint‑3D‑Formen in einer 3D‑Ebene zu drehen, was mehr Interaktivität bringt. Um eine 3D‑Form in PowerPoint zu drehen, verwenden Sie normalerweise das folgende Menü:

![todo:image_alt_text](img_02_01.png)

In der Aspose.Slides‑API kann die 3D‑Form‑Drehung über die Eigenschaft [IThreeDFormat.Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera) verwaltet werden:
``` csharp
IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
// ... weitere 3D-Szenenparameter festlegen

using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
{
    thumbnail.Save("sample_3d.png");
}
```


## **3D‑Tiefe und Extrusion**
Um Ihrer Form die dritte Dimension hinzuzufügen und sie zu einer 3D‑Form zu machen, verwenden Sie die Eigenschaften [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) 
und [IThreeDFormat.ExtrusionColor.Color](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor):
``` csharp
IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
// ... weitere 3D‑Szenenparameter festlegen

using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
{
    thumbnail.Save("sample_3d.png");
}
```


Normalerweise verwenden Sie das Menü „Depth“ in PowerPoint, um die Tiefe einer PowerPoint‑3D‑Form festzulegen:

![todo:image_alt_text](img_02_02.png)


## **3D‑Verlauf**
Ein Verlauf kann verwendet werden, um die Farbe einer PowerPoint‑3D‑Form zu füllen. Erstellen wir eine Form mit Verlauf‑Füllfarbe und wenden einen 3D‑Effekt darauf an:
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

Neben einer Verlauf‑Füllfarbe ist es möglich, Formen mit einem Bild zu füllen:
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


So sieht das aus:

![todo:image_alt_text](img_02_04.png)

## **3D‑Text (WordArt)**
Aspose.Slides ermöglicht das Anwenden von 3D auf Text. Für die Erstellung von 3D‑Text können Sie den WordArt‑Transformations‑Effekt verwenden:
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
    // den "Arch Up" WordArt-Transformations-Effekt setzen
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

## **FAQ**

**Werden 3D‑Effekte beim Exportieren einer Präsentation in Bilder/PDF/HTML beibehalten?**

Ja. Die Slides‑3D‑Engine rendert 3D‑Effekte beim Export in unterstützte Formate ([Bilder](/slides/de/net/convert-powerpoint-to-png/), [PDF](/slides/de/net/convert-powerpoint-to-pdf/), [HTML](/slides/de/net/convert-powerpoint-to-html/), usw.).

**Kann ich die „effektiven“ (finalen) 3D‑Parameterwerte abrufen, die Themen, Vererbung usw. berücksichtigen?**

Ja. Slides bietet APIs zum [Lesen effektiver Werte](/slides/de/net/shape-effective-properties/) (einschließlich für 3D – Beleuchtung, Abschrägungen usw.), sodass Sie die endgültigen angewendeten Einstellungen sehen können.

**Funktionieren 3D‑Effekte, wenn eine Präsentation in ein Video konvertiert wird?**

Ja. Beim [Erzeugen von Frames für das Video](/slides/de/net/convert-powerpoint-to-video/) werden 3D‑Effekte genau so gerendert wie bei [exportierten Bildern](/slides/de/net/convert-powerpoint-to-png/).