---
title: Erstellen von 3D-Präsentationen in .NET
linktitle: 3D-Präsentation
type: docs
weight: 232
url: /de/net/3d-presentation/
keywords:
- 3D PowerPoint
- 3D-Präsentation
- 3D-Drehung
- 3D-Tiefe
- 3D-Extrusion
- 3D-Verlauf
- 3D-Text
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erstellen Sie mühelos interaktive 3D-Präsentationen in .NET mit Aspose.Slides. Exportieren Sie schnell in PowerPoint- und OpenDocument-Formate für vielseitige Verwendung."
---

## **Übersicht**
Wie erstellen Sie normalerweise eine 3D PowerPoint‑Präsentation?
Microsoft PowerPoint ermöglicht das Erstellen von 3D‑Präsentationen, bei denen wir 3D‑Modelle hinzufügen, 3D‑Effekte auf Formen anwenden, 3D‑Text erstellen, 3D‑Grafiken in die Präsentation hochladen und PowerPoint‑3D‑Animationen erzeugen. 

Das Erstellen von 3D‑Effekten hat einen großen Einfluss darauf, Ihre Präsentation zu einer 3D‑Präsentation zu verbessern, und kann die einfachste Umsetzung einer 3D‑Präsentation sein. 
Seit der Version 20.9 von Aspose.Slides wurde eine neue **plattformübergreifende 3D‑Engine** hinzugefügt. Die neue 3D‑Engine ermöglicht das Exportieren und Rasterisieren von Formen und Text mit 3D‑Effekten. In früheren Versionen wurden Slides‑Formen mit angewendeten 3D‑Effekten flach gerendert. Jetzt ist es jedoch möglich, Formen mit einem **vollwertigen 3D** zu rendern. 
Zudem ist es jetzt möglich, Formen mit 3D‑Effekten über die öffentliche Slides‑API zu erstellen.

In der Aspose.Slides‑API verwenden Sie, um eine Form zu einer PowerPoint‑3D‑Form zu machen, die Eigenschaft [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/threedformat) , die die Funktionen des Interfaces [IThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat) erbt:
- [BevelBottom] und [BevelTop]: Legen Sie eine Schräge für die Form fest, definieren Sie den Schrägtyp (z. B. Angle, Circle, SoftRound) sowie Höhe und Breite der Schräge.
- [Camera]: Wird verwendet, um Kamerabewegungen um das Objekt zu imitieren. Mit anderen Worten: Durch Einstellen von Drehung, Zoom und anderen Eigenschaften der Kamera können Sie Ihre Formen wie ein 3D‑Modell in PowerPoint manipulieren.
- [ContourColor] und [ContourWidth]: Setzen Sie Kontur‑Eigenschaften, um die Form wie eine 3D‑PowerPoint‑Form aussehen zu lassen.
- [Depth], [ExtrusionColor] und [ExtrusionHeight]: Werden verwendet, um die Form dreidimensional zu machen, d. h. eine 2D‑Form in eine 3D‑Form zu konvertieren, indem Sie die Tiefe festlegen oder extrudieren.
- [LightRig]: Kann einen Lichteffekt auf einer 3D‑Form erzeugen. Die Logik dieser Eigenschaft ähnelt der Kamera; Sie können die Drehung des Lichts in Relation zur 3D‑Form einstellen und den Lichttyp wählen.
- [Material]: Durch Festlegen des Typs des 3D‑Formmaterials können Sie einen realistischeren Effekt erzielen. Die Eigenschaft bietet eine Reihe vordefinierter Materialien, wie z. B. Metal, Plastic, Powder, Matte usw.  

Alle 3D‑Funktionen können sowohl auf Formen als auch auf Text angewendet werden. Lassen Sie uns sehen, wie Sie auf die oben genannten Eigenschaften zugreifen und sie Schritt für Schritt im Detail betrachten:
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


Das gerenderte Miniaturbild sieht so aus:

![todo:image_alt_text](img_01_01.png)

## **3D‑Drehung**
Es ist möglich, PowerPoint‑3D‑Formen im 3D‑Raum zu drehen, was mehr Interaktivität bietet. Um eine 3D‑Form in PowerPoint zu drehen, verwenden Sie normalerweise das folgende Menü:

![todo:image_alt_text](img_02_01.png)

In der Aspose.Slides‑API kann die 3D‑Formrotation über die Eigenschaft [IThreeDFormat.Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera) verwaltet werden:
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
Um Ihrer Form die dritte Dimension zu verleihen und sie zu einer 3D‑Form zu machen, verwenden Sie die Eigenschaften [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) und [IThreeDFormat.ExtrusionColor.Color](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor):
``` csharp
IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
// ... weitere 3D Szenenparameter festlegen

using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
{
    thumbnail.Save("sample_3d.png");
}
```


Normalerweise verwenden Sie das Menü Tiefe in PowerPoint, um die Tiefe für eine PowerPoint‑3D‑Form festzulegen:

![todo:image_alt_text](img_02_02.png)


## **3D‑Verlauf**
Ein Verlauf kann verwendet werden, um die Farbe einer PowerPoint‑3D‑Form zu füllen. Lassen Sie uns eine Form mit Verlauf‑Füllfarbe erstellen und einen 3D‑Effekt darauf anwenden:
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


So sieht es aus:

![todo:image_alt_text](img_02_04.png)

## **3D‑Text (WordArt)**
Aspose.Slides ermöglicht ebenfalls das Anwenden von 3D auf Text. Für die Erstellung von 3D‑Text kann der WordArt‑Transformations‑Effekt verwendet werden:
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
    // setze den "Arch Up" WordArt-Transformationseffekt
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

**Werden 3D‑Effekte beim Export einer Präsentation in Bilder/PDF/HTML erhalten?**

Ja. Die Slides‑3D‑Engine rendert 3D‑Effekte beim Export in unterstützte Formate ([images](/slides/de/net/convert-powerpoint-to-png/), [PDF](/slides/de/net/convert-powerpoint-to-pdf/), [HTML](/slides/de/net/convert-powerpoint-to-html/), etc.).

**Kann ich die „effektiven“ (finalen) 3D‑Parameterwerte abrufen, die Themen, Vererbung usw. berücksichtigen?**

Ja. Slides bietet APIs zum [effektive Werte lesen](/slides/de/net/shape-effective-properties/) (einschließlich für 3D – Beleuchtung, Abschrägungen usw.), sodass Sie die endgültigen angewendeten Einstellungen sehen können.

**Funktionieren 3D‑Effekte beim Konvertieren einer Präsentation in ein Video?**

Ja. Beim [Erzeugen von Frames für das Video](/slides/de/net/convert-powerpoint-to-video/) werden 3D‑Effekte genauso gerendert wie bei [exportierten Bildern](/slides/de/net/convert-powerpoint-to-png/).