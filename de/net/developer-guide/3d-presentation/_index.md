---
title: Erstellen von 3D‑Effekten in Präsentationen mit .NET
linktitle: 3D Präsentation
type: docs
weight: 232
url: /de/net/3d-presentation/
keywords:
- 3D PowerPoint
- 3D Präsentation
- 3D Drehung
- 3D Tiefe
- 3D Extrusion
- 3D Farbverlauf
- 3D Text
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Wenden Sie 3D‑Effekte für PowerPoint‑Formen und -Text in .NET mit Aspose.Slides an und rendern Sie sie. Konfigurieren Sie Kamera, Beleuchtung, Material, Extrusion, Füllungen und 3D‑Text."
---
## **Übersicht**

Aspose.Slides für .NET kann PowerPoint‑ähnliche 3D‑Formatierungen für Formen und Text erstellen, bearbeiten, beibehalten und rendern. Dieser Artikel behandelt 3D‑Effekte wie Drehung, Extrusion, Abschrägungen, Beleuchtung, Material, Farbverlauf‑ oder Bildfüllungen und 3D‑Text.

{{% alert color="primary" %}}
Dieser Artikel behandelt 3D‑Formatierungseffekte auf PowerPoint‑Formen und -Text. Es geht nicht um das Einfügen oder Bearbeiten von eigenständigen 3D‑Modelldateien. Wenn Sie eine Folie in ein Bild, PDF oder HTML exportieren, rendert Aspose.Slides diese 3D‑Effekte in die exportierte 2D‑Ausgabe.
{{% /alert %}}

## **3D‑Formatierungskonzepte**

Verwenden Sie die Eigenschaft [IShape.ThreeDFormat](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/properties/threedformat), um einer Form eine 3D‑Formatierung zuzuweisen. Die Eigenschaft stellt [IThreeDFormat](https://reference.aspose.com/slides/de/net/aspose.slides/ithreedformat) bereit, das die 3D‑Szene für diese Form steuert.

Für Text verwenden Sie die Eigenschaft [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/de/net/aspose.slides/itextframeformat/properties/threedformat). Diese wendet die 3D‑Formatierung auf den Textrahmen anstelle des Formkörpers an.

Die wichtigsten Eigenschaften sind:

| Eigenschaft | Was sie steuert | Wann zu verwenden |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/de/net/aspose.slides/ithreedformat/properties/camera) | Ansichtspunkt, vordefinierter Kameratyp, Drehung, Zoom und Perspektive. | Drehen Sie das Objekt im 3D‑Raum oder passen Sie es an eine PowerPoint‑3D‑Drehungsvoreinstellung an. |
| [LightRig](https://reference.aspose.com/slides/de/net/aspose.slides/ithreedformat/properties/lightrig) | Lichtvorgabe, Richtung und Lichtrotation. | Ändern Sie, wie Hervorhebungen und Schatten auf der 3D‑Oberfläche erscheinen. |
| [Material](https://reference.aspose.com/slides/de/net/aspose.slides/ithreedformat/properties/material) | Oberflächenmaterial, z. B. flach, matt, Kunststoff oder Metall. | Lassen Sie die gleiche Geometrie flacher, weicher, glänzender oder metallisch wirken. |
| [ExtrusionHeight](https://reference.aspose.com/slides/de/net/aspose.slides/ithreedformat/properties/extrusionheight) | Wie weit die Form von ihrer Vorderfläche rückwärts verläuft. | Verwandeln Sie eine flache Form in ein sichtbar dickes 3D‑Objekt. |
| [ExtrusionColor](https://reference.aspose.com/slides/de/net/aspose.slides/ithreedformat/properties/extrusioncolor) | Farbe der extrudierten Seiten. | Machen Sie die Tiefe sichtbar oder koordinieren Sie die Seitenfarbe mit der Vorderseitenfüllung. |
| [Depth](https://reference.aspose.com/slides/de/net/aspose.slides/ithreedformat/properties/depth) | Zusätzliche 3D‑Tiefe, die von der PowerPoint‑3D‑Formatierung verwendet wird. | Feinabstimmung der Tiefe für Formen oder Text, insbesondere in Kombination mit Abschrägungs‑ und Materialeinstellungen. |
| [BevelTop](https://reference.aspose.com/slides/de/net/aspose.slides/ithreedformat/properties/beveltop) und [BevelBottom](https://reference.aspose.com/slides/de/net/aspose.slides/ithreedformat/properties/bevelbottom) | Erhabene oder abgerundete Kanten an den Vorder‑ und Rückseiten. | Fügen Sie eine weiche oder geformte Kante hinzu, anstatt einer scharfen flachen Fläche. |
| [ContourColor](https://reference.aspose.com/slides/de/net/aspose.slides/ithreedformat/properties/contourcolor) und [ContourWidth](https://reference.aspose.com/slides/de/net/aspose.slides/ithreedformat/properties/contourwidth) | Umriss um das 3D‑Objekt. | Betonen Sie die Objektgrenze in der gerenderten Ausgabe. |

## **Eine 3D‑Form erstellen**

Eine Form benötigt normalerweise vier Arten von Einstellungen, bevor sie überzeugend 3D wirkt:

- Kameraeinstellungen, weil die Standard‑Frontansicht die Extrusion verbergen kann.
- Lichteinstellungen, weil Beleuchtung die Flächen und Seiten lesbar macht.
- Materialeinstellungen, weil die Oberfläche beeinflusst, wie Licht dargestellt wird.
- Extrusions‑ oder Tiefeneinstellungen, weil eine flache Form Dicke benötigt.

Das folgende Beispiel erstellt ein Rechteck, fügt Text zu seiner Vorderseite hinzu, wendet 3D‑Formatierung an, speichert die Präsentation als PPTX und rendert die Folie zu einem PNG‑Bild.

```csharp
const float imageScale = 2;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.TextFrame.Text = "3D";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.CornflowerBlue;

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Blue;

using var thumbnail = slide.GetImage(imageScale, imageScale);
thumbnail.Save("shape_3d.png");

presentation.Save("shape_3d.pptx", SaveFormat.Pptx);
```

Das gerenderte Folienbild zeigt das Rechteck als dicken 3D‑Block:

![Gerendertes blaues 3D‑Rechteck mit weißem 3D‑Text auf der Vorderseite](img_01_01.png)

## **Eine Form mit der Kamera drehen**

In PowerPoint wird die 3D‑Drehung über das 3‑D‑Drehungs‑Panel konfiguriert. Die X‑, Y‑ und Z‑Drehwerte entsprechen der Drehung, die Sie über die Kamera‑API festlegen.

![PowerPoint‑3‑D‑Drehungs‑Panel mit hervorgehobenen X‑, Y‑ und Z‑Drehwerten](img_02_01.png)

In Aspose.Slides setzen Sie den Kameratyp und die Drehung über [IThreeDFormat.Camera](https://reference.aspose.com/slides/de/net/aspose.slides/ithreedformat/properties/camera):

```csharp
shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

Verwenden Sie die Kamera, wenn Sie ändern müssen, wie der Betrachter das Objekt sieht. Sie ändert nicht die 2D‑Formgeometrie auf der Folie. Sie ändert den 3D‑Blickpunkt, den PowerPoint und Aspose.Slides beim Rendern verwenden.

## **Extrusion und Tiefe hinzufügen**

Extrusion lässt eine Form dick erscheinen, indem sie hinter der Vorderseite erweitert wird. In PowerPoint legt die Tiefensteuerung diese sichtbare Dicke fest, und die Farbsteuerung bestimmt die Farbe der Seitenflächen.

![PowerPoint‑Tiefensteuerungen abgebildet auf Extrusions‑Farbe‑ und Extrusions‑Höhen‑Eigenschaften](img_02_02.png)

Setzen Sie [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/de/net/aspose.slides/ithreedformat/properties/extrusionheight) für die Dicke und [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/de/net/aspose.slides/ithreedformat/properties/extrusioncolor) für die Seitenfarbe:

```csharp
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
```

Verwenden Sie [IThreeDFormat.Depth](https://reference.aspose.com/slides/de/net/aspose.slides/ithreedformat/properties/depth), wenn Sie direkt mit dem PowerPoint‑Tiefenwert arbeiten oder Tiefe mit Abschrägung, Material und Texteffekten kombinieren müssen. In vielen Form‑Szenarien ist `ExtrusionHeight` die eindeutigere Einstellung, da sie die sichtbare Extrusion direkt ausdrückt.

## **Farbverlauf‑ oder Bildfüllungen mit 3D‑Effekten verwenden**

Die 3D‑Formatierung ist unabhängig von der Formfüllung. Sie können eine Volltonfarbe, einen Farbverlauf, ein Muster oder eine Bildfüllung auf die Vorderseite anwenden und dennoch dieselben Kamera-, Licht‑, Material‑ und Extrusions‑Einstellungen verwenden.

Dieses Beispiel wendet eine Farbverlauf‑Füllung auf die Form und eine dunklere Extrusions‑Farbe auf die Seiten an:

```csharp
const float imageScale = 2;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
shape.TextFrame.Text = "3D Gradient";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

shape.FillFormat.FillType = FillType.Gradient;
shape.FillFormat.GradientFormat.GradientStops.Add(0, Color.Blue);
shape.FillFormat.GradientFormat.GradientStops.Add(100, Color.Orange);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;

using var thumbnail = slide.GetImage(imageScale, imageScale);
thumbnail.Save("gradient_3d.png");
```

Die gerenderte Ausgabe behält den Farbverlauf auf der Vorderseite bei und rendert die Extrusion separat:

![Gerendertes 3D‑Rechteck mit einem Blau‑zu‑Orange‑Farbverlauf und oranger Extrusion](img_02_03.png)

Um stattdessen eine Bildfüllung zu verwenden, fügen Sie das Bild zur Präsentation hinzu und weisen es der Formfüllung zu:

```csharp
var imageData = File.ReadAllBytes("image.jpg");
var image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;
```

Das Bild wird auf der Vorderseite gerendert, während die Extrusion als 3D‑Seitenfläche gerendert wird:

![Gerendertes 3D‑Rechteck mit Fotofüllung auf der Vorderseite und oranger Extrusion](img_02_04.png)

## **3D‑Formatierung auf Text anwenden**

Die 3D‑Formatierung von Formen wirkt sich auf den Formkörper aus. Die 3D‑Formatierung von Text wirkt sich auf den Textrahmen aus. Dies ist nützlich für WordArt‑ähnliche Effekte, bei denen die Buchstaben selbst Extrusion, Material, Beleuchtung und Kameraeinstellungen benötigen.

Das folgende Beispiel erstellt Text mit einer Mustere‑Füllung, wendet eine WordArt‑Transformation an und konfiguriert 3D‑Einstellungen auf [ITextFrameFormat](https://reference.aspose.com/slides/de/net/aspose.slides/itextframeformat):

```csharp
const float imageScale = 2;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Text = "3D Text";

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.LargeGrid;

shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 128;

var textFrameFormat = shape.TextFrame.TextFrameFormat;
textFrameFormat.Transform = TextShapeType.ArchUp;
textFrameFormat.ThreeDFormat.ExtrusionHeight = 3.5f;
textFrameFormat.ThreeDFormat.Depth = 3;
textFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;
textFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
textFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
textFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);
textFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;

using var thumbnail = slide.GetImage(imageScale, imageScale);
thumbnail.Save("text_3d.png");

presentation.Save("text_3d.pptx", SaveFormat.Pptx);
```

Der Text wird als gekrümmte, extrudierte 3D‑Beschriftung gerendert:

![Gerenderter 3D‑Text mit einer gebogenen WordArt‑Transformation, oranger Mustere‑Füllung und dunkler Extrusion](img_02_05.png)

## **Export‑ und Rendering‑Verhalten**

Aspose.Slides bewahrt die 3D‑Formatierung beim Speichern in PowerPoint‑Formate wie PPTX. Beim Rendern oder Exportieren in feste Layout‑Formate wird die 3D‑Szene rasterisiert oder als 2D‑Ergebnis in die Ausgabe gezeichnet. Dies gilt, wenn Sie Folien nach [PNG](/slides/de/net/convert-powerpoint-to-png/), [PDF](/slides/de/net/convert-powerpoint-to-pdf/), [HTML](/slides/de/net/convert-powerpoint-to-html/) rendern oder Frames für die [Video‑Konvertierung](/slides/de/net/convert-powerpoint-to-video/) erzeugen.

Beachten Sie folgende Punkte:

- Exportierte Bilder und PDFs sind nicht interaktiv. Das Objekt kann nach dem Export nicht vom Betrachter gedreht werden.
- Das endgültige Erscheinungsbild hängt von der Kombination aus Kamera, Licht‑Rig, Material, Extrusion, Füllung und Folien‑Skalierung ab.
- Wenn Sie vererbte oder themenbasierte Formatierungswerte prüfen müssen, lesen Sie die [effektiven Formeigenschaften](/slides/de/net/shape-effective-properties/).
- Einige Ausgabeformate können die editierbare PowerPoint‑3D‑Formatierung nicht speichern. In diesen Formaten wird das visuelle Ergebnis gerendert, anstatt als editierbare 3D‑Einstellungen erhalten zu bleiben.

## **FAQ**

**Kann Aspose.Slides interaktive 3D‑Präsentationen erstellen?**

Aspose.Slides erstellt und rendert PowerPoint‑3D‑Effekte für Formen und Text. Es macht exportierte Bilder, PDFs oder HTML‑Seiten nicht zu interaktiven 3D‑Szene, die ein Betrachter drehen kann. In PPTX bleibt die 3D‑Formatierung in PowerPoint editierbar, sofern das Format dies unterstützt.

**Was ist der Unterschied zwischen einem 3D‑Modell und einem 3D‑Effekt?**

Ein 3D‑Modell ist ein separates 3D‑Objekt, das in eine Präsentation eingefügt wird. Ein 3D‑Effekt ist eine Formatierung, die auf eine reguläre PowerPoint‑Form oder Text angewendet wird, z. B. Drehung, Extrusion, Abschrägung, Beleuchtung und Material. Dieser Artikel behandelt 3D‑Effekte.

**Welche Einstellungen sind für eine sichtbare 3D‑Form erforderlich?**

Mindestens müssen Sie eine Kameradrehung und entweder Extrusion oder Tiefe festlegen. In der Praxis sollten Sie auch ein Licht‑Rig und Material einstellen, damit die gerenderten Flächen klare Highlights und Schatten aufweisen.

**Kann ich 3D‑Effekte sowohl auf Formen als auch auf Text anwenden?**

Ja. Verwenden Sie [IShape.ThreeDFormat](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/properties/threedformat) für den Formkörper und [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/de/net/aspose.slides/itextframeformat/properties/threedformat) für Text.

**Werden 3D‑Effekte beim Exportieren zu Bildern, PDF, HTML oder Videoframes angezeigt?**

Ja. Aspose.Slides rendert 3D‑Effekte, wenn Folienbilder, PDF‑Ausgabe, HTML‑Ausgabe und Frames für die Videokonvertierung erzeugt werden. Die exportierte Ausgabe enthält das gerenderte Erscheinungsbild, nicht ein editierbares 3D‑Objekt.

**Kann ich die endgültigen 3D‑Werte nach Anwendung von Vererbung und Themen‑Einstellungen auslesen?**

Ja. Verwenden Sie die APIs für effektive Formatierung, beschrieben in [Shape Effective Properties](/slides/de/net/shape-effective-properties/), um die endgültigen Kamera‑, Licht‑Rig‑, Abschrägungs‑ und zugehörigen 3D‑Werte auszulesen.