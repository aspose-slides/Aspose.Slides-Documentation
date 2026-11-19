---
title: 3D-Effekte in Präsentationen mit .NET erstellen
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
- 3D-Farbverlauf
- 3D-Text
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "3D‑Effekte für PowerPoint‑Formen und -Text in .NET mit Aspose.Slides anwenden und rendern. Kamera, Beleuchtung, Material, Extrusion, Füllungen und 3D‑Text konfigurieren."
---
## **Übersicht**

Aspose.Slides für .NET kann 3D‑Formatierungen im PowerPoint‑Stil für Formen und Text erstellen, bearbeiten, erhalten und rendern. Dieser Artikel behandelt 3D‑Effekte wie Drehung, Extrusion, Abschrägungen, Beleuchtung, Material, Farbverlauf oder Bildfüllungen und 3D‑Text.

{{% alert color="info" title="Note" %}}
Dieser Artikel behandelt 3D‑Formatierungseffekte für PowerPoint‑Formen und -Text. Er behandelt nicht das Einfügen oder Bearbeiten eigenständiger 3D‑Modelldateien. Wenn Sie eine Folie als Bild, PDF oder HTML exportieren, rendert Aspose.Slides diese 3D‑Effekte in die exportierte 2D‑Ausgabe.
{{% /alert %}}

## **Konzepte der 3D-Formatierung**

Verwenden Sie die [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/threedformat)-Eigenschaft, um einer Form 3D‑Formatierung zuzuweisen. Die Eigenschaft stellt [IThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat) bereit, die die 3D‑Szene für diese Form steuert.

Für Text verwenden Sie die [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/threedformat)-Eigenschaft. Damit wird die 3D‑Formatierung auf den Textrahmen anstatt auf den Formkörper angewendet.

Die wichtigsten Eigenschaften sind:

| Eigenschaft | Was es steuert | Wann es zu verwenden ist |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera) | Ansichtspunkt, vordefinierter Kameratyp, Rotation, Zoom und Perspektive. | Drehen Sie das Objekt im 3D‑Raum oder passen Sie eine vordefinierte PowerPoint‑3D‑Drehung an. |
| [LightRig](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/lightrig) | Lichtvorgabe, Richtung und Lichtrotation. | Ändern Sie, wie Highlights und Schatten auf der 3D‑Oberfläche erscheinen. |
| [Material](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/material) | Oberflächenmaterial, z. B. flach, matt, Kunststoff oder Metall. | Lassen Sie dieselbe Geometrie flacher, weicher, glänzender oder metallisch wirken. |
| [ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) | Wie weit die Form von ihrer Vorderseite nach hinten ausgedehnt wird. | Verwandeln Sie eine flache Form in ein sichtbar dickes 3D‑Objekt. |
| [ExtrusionColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) | Farbe der extrudierten Seiten. | Machen Sie die Tiefe sichtbar oder koordinieren Sie die Seitenfarbe mit der Vorderseiten‑Füllung. |
| [Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/depth) | Zusätzliche 3D‑Tiefe, die von PowerPoint‑3D‑Formatierung verwendet wird. | Feinabstimmung der Tiefe für Formen oder Text, insbesondere zusammen mit Abschrägungs‑ und Materialeinstellungen. |
| [BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/beveltop) und [BevelBottom](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/bevelbottom) | Erhöhte oder abgerundete Kanten an Vorder- und Rückseiten. | Fügen Sie eine abgeflachte oder geformte Kante hinzu, anstatt einer scharfen flachen Fläche. |
| [ContourColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourcolor) und [ContourWidth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourwidth) | Umriss um das 3D‑Objekt. | Betonen Sie die Objektgrenze in der gerenderten Ausgabe. |

## **Eine 3D‑Form erstellen**

Eine Form benötigt normalerweise vier Arten von Einstellungen, bevor sie überzeugend 3D wirkt:

- Kameraeinstellungen, weil die voreingestellte Vorderansicht die Extrusion verbergen könnte.
- Lichteinstellungen, weil Beleuchtung die Flächen und Seiten lesbar macht.
- Materialeinstellungen, weil die Oberfläche beeinflusst, wie das Licht gerendert wird.
- Extrusions‑ oder Tiefe‑Einstellungen, weil eine flache Form Dicke benötigt.

Das folgende Beispiel erstellt ein Rechteck, fügt seiner Vorderseite Text hinzu und wendet 3D‑Formatierung an. Die Kamerarotationswerte sind in Grad angegeben, und die Extrusionshöhe beträgt 100 Punkte. Das Beispiel rendert die Folie zu einem PNG‑Bild mit dem Doppelten ihrer Standardgröße und speichert die Präsentation als PPTX.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

In PowerPoint wird die 3D‑Drehung über das Fenster 3‑D‑Drehung konfiguriert. Die X‑, Y‑ und Z‑Rotationswerte entsprechen der Drehung, die Sie über die Kamera‑API festlegen.

![PowerPoint‑Fenster 3‑D‑Drehung mit hervorgehobenen X‑, Y‑ und Z‑Rotationswerten](img_02_01.png)

In Aspose.Slides greifen Sie über [IThreeDFormat.Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera) auf die Kamera zu. Dieses Beispiel erstellt ein Rechteck, wählt eine orthografische Vorderansicht und setzt die X‑, Y‑ und Z‑Rotationen auf 20, 30 bzw. 40 Grad. Es konfiguriert die Form im Speicher, ohne eine Datei zu speichern:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

Verwenden Sie die Kamera, wenn Sie ändern müssen, wie der Betrachter das Objekt sieht. Sie ändert nicht die 2D‑Formgeometrie auf der Folie. Sie ändert den 3D‑Standort, den PowerPoint und Aspose.Slides beim Rendern verwenden.

### **Kameraausrichtung von einer Vorlagenform kopieren**

Um eine Form in einer Vorlage anzupassen, kopieren Sie deren [CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/)‑Voreinstellung und lesen Sie die Winkel mit [GetRotation](https://reference.aspose.com/slides/net/aspose.slides/icamera/getrotation/). Das Beispiel öffnet `template.pptx`, liest die Kamera der ersten Form auf der ersten Folie und überträgt deren Ausrichtung auf die zweite Form. Beide Formen besitzen bereits 3D‑Beleuchtung, und die zweite Form hat keine explizite Kameradrehung.

Die Winkel sind in Grad angegeben. Index `0` ist die Breite, Index `1` die Länge und Index `2` die Umdrehung. Übergeben Sie sie in dieser Reihenfolge an [SetRotation](https://reference.aspose.com/slides/net/aspose.slides/icamera/setrotation/). Gibt die Quelle `null` zurück, hat sie keine explizite Drehung, sodass die Winkel der zweiten Form unbeändert bleiben. Eine explizite Drehung von `(0, 0, 0)` liefert drei Nullen und sollte kopiert werden.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var shapes = presentation.Slides[0].Shapes;

var sourceCamera = shapes[0].ThreeDFormat.Camera;
var destinationCamera = shapes[1].ThreeDFormat.Camera;

destinationCamera.CameraType = sourceCamera.CameraType;
var angles = sourceCamera.GetRotation();
if (angles != null)
{
    destinationCamera.SetRotation(angles[0], angles[1], angles[2]);
}

presentation.Save("camera-copy.pptx", SaveFormat.Pptx);
```

Wenn Sie `camera-copy.pptx` erneut öffnen, haben die beiden Formen dieselbe Kameravoreinstellung und -rotation. In PowerPoint verwendet der rechte Pfeil die von dem linken Rechteck kopierte Kameraausrichtung. Beide Formen nutzen dieselbe Beleuchtung und Extrusionstiefe.

![Ein blaues 3D‑Rechteck und ein rechter Pfeil mit übereinstimmender Kameraausrichtung, von oben rechts betrachtet](camera-orientation.png)

## **Extrusion und Tiefe hinzufügen**

Extrusion lässt eine Form dick erscheinen, indem sie hinter der Vorderfläche erweitert wird. In PowerPoint legt die Tiefensteuerung diese sichtbare Dicke fest, und die Farbsteuerung bestimmt die Farbe der Seitenflächen.

![PowerPoint‑Tiefensteuerungen, zugeordnet zu Extrusionsfarbe und Extrusionshöhe‑Eigenschaften](img_02_02.png)

Setzen Sie [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) für die Dicke und [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) für die Seitenfarbe. Dieses Beispiel gibt einem Rechteck eine 100‑Punkte‑Extrusion mit violetten Seiten und dreht die Kamera, um die Dicke zu zeigen. Es konfiguriert die Form im Speicher, ohne eine Datei zu speichern:

```csharp
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
```

Die [IThreeDFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/depth)‑Eigenschaft legt die Tiefe einer 3D‑Form fest. Die [ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight)‑Eigenschaft steuert die Höhe des Extrusionseffekts, wie in diesem Beispiel gezeigt.

## **Verwenden von Farbverlauf‑ oder Bildfüllungen mit 3D‑Effekten**

3D‑Formatierung ist unabhängig von der Formfüllung. Sie können der Vorderseite eine Vollfarbe, einen Farbverlauf, ein Muster oder eine Bildfüllung zuweisen und dennoch dieselben Kamera‑, Licht‑, Material‑ und Extrusionseinstellungen verwenden.

Dieses Beispiel wendet einen Blau‑zu‑Orange‑Farbverlauf auf die Vorderseite an und eine dunkelorange Farbe auf die 150‑Punkte‑Extrusion. Die Farbverlaufs‑Stopps bei 0 und 100 markieren den Anfang und das Ende des Verlaufs. Die Kamerarotationswerte sind in Grad. Die Folie wird zu einem PNG‑Bild mit dem Doppelten ihrer Standardgröße gerendert:

```csharp
using System.Drawing;
using Aspose.Slides;

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

![Gerendertes 3D‑Rechteck mit blau‑zu‑orangefarbenem Farbverlauf und orangefarbener Extrusion](img_02_03.png)

Um stattdessen eine Bildfüllung zu verwenden, fügen Sie das Bild zur Präsentation hinzu und weisen es der Formfüllung zu. Dieses Beispiel erfordert eine vorhandene Datei namens "image.jpg" im Arbeitsverzeichnis. Es streckt das Bild, um das Rechteck zu füllen, wendet eine 150‑Punkte‑Extrusion an und setzt die Kamerarotation in Grad. Es konfiguriert die Form im Speicher, ohne eine Datei zu speichern oder zu rendern:

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

var imageData = File.ReadAllBytes("image.jpg");
var image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;
```

Das Bild wird auf der Vorderseite gerendert, während die Extrusion als 3D‑Seitenfläche gerendert wird:

![Gerendertes 3D‑Rechteck mit Fotofüllung auf der Vorderseite und orangefarbener Extrusion](img_02_04.png)

## **3D‑Formatierung auf Text anwenden**

Die 3D‑Formatierung von Formen wirkt auf den Formkörper. Die 3D‑Formatierung von Text wirkt auf den Textrahmen. Das ist nützlich für WordArt‑ähnliche Effekte, bei denen die Buchstaben selbst Extrusion, Material, Beleuchtung und Kameraeinstellungen benötigen.

Das folgende Beispiel erstellt Text mit einem orange‑weiß‑gitter Muster, wendet einen nach oben gerichteten Bogen an und konfiguriert 3D‑Einstellungen über [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/threedformat). Die Extrusionshöhe und Tiefe sind in Punkten angegeben, und die Lichtrotation ist in Grad. Die Formfüllung und Kontur werden ausgeblendet, sodass nur der Text sichtbar ist. Das Beispiel rendert ein PNG‑Bild mit dem Doppelten der Standardfolienabmessungen und speichert die Präsentation als PPTX:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

Der Text wird als gebogene, extrudierte 3D‑Beschriftung gerendert:

![Gerendeter 3D‑Text mit einem gebogenen WordArt‑Transform, orangefarbener Mustervollfüllung und dunkler Extrusion](img_02_05.png)

## **Text auf einer 3D‑Form flach halten**

Um Text lesbar zu halten und gleichzeitig das 3D‑Aussehen einer Form zu bewahren, setzen Sie [ITextFrameFormat.KeepTextFlat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/keeptextflat/) über [ITextFrame.TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframe/textframeformat/). Ist der Wert `true`, bleibt der Text außerhalb der 3D‑Szene. Ist er `false`, nimmt der Text an der Szene teil und folgt ihrer 3D‑Ausrichtung.

Diese Einstellung entfernt nicht die 3D‑Formatierung der Form: Kamera, Beleuchtung, Material und Extrusion bleiben über [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/threedformat/) konfiguriert. Sie unterscheidet sich zudem von einer normalen Drehung. [IShape.Rotation](https://reference.aspose.com/slides/net/aspose.slides/ishape/rotation/) dreht die Form in der Folienebene, während [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/) die benutzerdefinierte Drehung des Textes innerhalb seiner Begrenzungsbox steuert. Den Text aus der 3D‑Szene herauszuhalten, setzt keine dieser Winkel zurück.

Das folgende eigenständige Beispiel erstellt ein blaues Rechteck mit Text und dupliziert es neben dem Original. Beide Formen besitzen dieselbe 3D‑Formatierung; nur die Texteinstellung unterscheidet sich: `false` links und `true` rechts. Die Kamerawinkel sind in Grad, und die Extrusionshöhe beträgt 40 Punkte. Das Beispiel speichert die Präsentation als PPTX und rendert die Vergleichsfolie zu PNG mit dem Doppelten ihrer Standardgröße.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 70, 160, 240, 140);

shape.TextFrame.Text = "Readable text";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 28;
shape.TextFrame.Paragraphs[0].ParagraphFormat.Alignment = TextAlignment.Center;
shape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Center;
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.CornflowerBlue;

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(30, 30, 0);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 40;
shape.ThreeDFormat.ExtrusionColor.Color = Color.RoyalBlue;
shape.TextFrame.TextFrameFormat.KeepTextFlat = false;

var flatTextShape = (IAutoShape)slide.Shapes.AddClone(shape, 400, 160);
flatTextShape.TextFrame.TextFrameFormat.KeepTextFlat = true;

presentation.Save("keep_text_flat.pptx", SaveFormat.Pptx);
using var image = slide.GetImage(2, 2);
image.Save("keep_text_flat.png");
```

Links folgt der Text der 3D‑Ausrichtung. Rechts bleibt er flach und leichter lesbar. Beide Rechtecke behalten dieselbe sichtbare Extrusion und 3D‑Ausrichtung bei.

![Nebeneinander stehende 3D‑Rechtecke: KeepTextFlat ist links false und rechts true](keep_text_flat.png)

## **Export‑ und Rendering‑Verhalten**

Aspose.Slides bewahrt die 3D‑Formatierung beim Speichern in PowerPoint‑Formate wie PPTX. Beim Rendern oder Exportieren in fixierte Layout‑Formate wird die 3D‑Szene gerastert oder als 2D‑Ergebnis in die Ausgabe gezeichnet. Dies gilt, wenn Sie Folien zu [PNG](/slides/de/net/convert-powerpoint-to-png/) rendern, zu [PDF](/slides/de/net/convert-powerpoint-to-pdf/) exportieren, zu [HTML](/slides/de/net/convert-powerpoint-to-html/) exportieren oder Frames für die [Video‑Konvertierung](/slides/de/net/convert-powerpoint-to-video/) erzeugen.

- Exportierte Bilder und PDFs sind nicht interaktiv. Das Objekt kann vom Betrachter nach dem Export nicht gedreht werden.
- Das endgültige Erscheinungsbild hängt von der Kombination aus Kamera, Licht‑Rig, Material, Extrusion, Füllung und Folien‑Skalierung ab.
- Wenn Sie geerbte oder themenbasierte Formatierungswerte prüfen müssen, lesen Sie die [effektiven Formeigenschaften](/slides/de/net/shape-effective-properties/).
- Einige Ausgabeformate können die editierbare PowerPoint‑3D‑Formatierung nicht speichern. In diesen Formaten wird das visuelle Ergebnis gerendert, anstatt als editierbare 3D‑Einstellungen erhalten zu bleiben.

## **FAQ**

**Kann Aspose.Slides interaktive 3D‑Präsentationen erstellen?**

Aspose.Slides erstellt und rendert PowerPoint‑3D‑Effekte für Formen und Text. Es macht exportierte Bilder, PDFs oder HTML‑Seiten nicht zu interaktiven 3D‑Szenen, die ein Betrachter drehen könnte. In PPTX bleibt die 3D‑Formatierung in PowerPoint editierbar, sofern das Format dies unterstützt.

**Was ist der Unterschied zwischen einem 3D‑Modell und einem 3D‑Effekt?**

Ein 3D‑Modell ist ein separates 3D‑Objekt, das in eine Präsentation eingefügt wird. Ein 3D‑Effekt ist eine Formatierung, die auf eine normale PowerPoint‑Form oder -Text angewendet wird, wie Drehung, Extrusion, Abschrägung, Beleuchtung und Material. Dieser Artikel behandelt 3D‑Effekte.

**Welche Einstellungen sind für eine sichtbare 3D‑Form erforderlich?**

Mindestens muss eine Kameradrehung und entweder Extrusion oder Tiefe festgelegt werden. In der Praxis sollten zudem ein Licht‑Rig und ein Material gesetzt werden, damit die gerenderten Flächen klare Highlights und Schatten besitzen.

**Kann ich 3D‑Effekte sowohl auf Formen als auch auf Text anwenden?**

Ja. Verwenden Sie [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/threedformat) für den Formkörper und [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/threedformat) für Text.

**Werden 3D‑Effekte beim Exportieren zu Bildern, PDF, HTML oder Video‑Frames angezeigt?**

Ja. Aspose.Slides rendert 3D‑Effekte beim Erzeugen von Folienbildern, PDF‑Ausgabe, HTML‑Ausgabe und Frames für die Videokonvertierung. Die exportierte Ausgabe enthält das gerenderte Erscheinungsbild, nicht ein editierbares 3D‑Objekt.

**Kann ich die endgültigen 3D‑Werte nach Vererbung und Anwendung von Theme‑Einstellungen auslesen?**

Ja. Verwenden Sie die APIs für effektive Formatierung, die in [Effektive Formeigenschaften](/slides/de/net/shape-effective-properties/) beschrieben werden, um die endgültigen Kamera‑, Licht‑Rig‑, Abschrägungs‑ und verwandten 3D‑Werte auszulesen.