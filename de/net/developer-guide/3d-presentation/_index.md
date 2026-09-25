---
title: 3D‑Effekte in Präsentationen mit .NET erstellen
linktitle: 3D‑Präsentation
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

Aspose.Slides für .NET kann 3D‑Formatierungen im PowerPoint‑Stil für Formen und Text erstellen, bearbeiten, beibehalten und rendern. Dieser Artikel behandelt 3D‑Effekte wie Drehungen, Extrusion, Abschrägungen, Beleuchtung, Material, Farbverläufe oder Bildfüllungen sowie 3D‑Text.

{{% alert color="info" title="Note" %}}
Dieser Artikel behandelt 3D‑Formatierungseffekte für PowerPoint‑Formen und -Text. Es geht nicht um das Einfügen oder Bearbeiten von eigenständigen 3D‑Modelldateien. Wenn Sie eine Folie in ein Bild, PDF oder HTML exportieren, rendert Aspose.Slides diese 3D‑Effekte in die exportierte 2D‑Ausgabe.
{{% /alert %}}

## **3D-Formatierungskonzepte**

Verwenden Sie die [IShape.ThreeDFormat](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/properties/threedformat)-Eigenschaft, um einer Form 3D‑Formatierung zuzuweisen. Die Eigenschaft stellt [IThreeDFormat](https://reference.aspose.com/slides/de/net/aspose.slides/ithreedformat) bereit, das die 3D‑Szene für diese Form steuert.

Für Text verwenden Sie die [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/de/net/aspose.slides/itextframeformat/properties/threedformat)-Eigenschaft. Diese wendet 3D‑Formatierung auf den Textrahmen statt auf den Formkörper an.

Die wichtigsten Eigenschaften sind:

| Eigenschaft | Was es steuert | Wann zu verwenden |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/de/net/aspose.slides/ithreedformat/properties/camera) | Ansichtspunkt, voreingestellter Kameratyp, Drehung, Zoom und Perspektive. | Drehen Sie das Objekt im 3D‑Raum oder verwenden Sie eine PowerPoint‑Drehvorgabe. |
| [LightRig](https://reference.aspose.com/slides/de/net/aspose.slides/ithreedformat/properties/lightrig) | Lichtvoreinstellung, Richtung und Lichtdrehung. | Ändern Sie, wie Hervorhebungen und Schatten auf der 3D‑Oberfläche erscheinen. |
| [Material](https://reference.aspose.com/slides/de/net/aspose.slides/ithreedformat/properties/material) | Oberflächenmaterial, z. B. flach, matt, Kunststoff oder Metall. | Lassen Sie die gleiche Geometrie flacher, weicher, glänzender oder metallisch wirken. |
| [ExtrusionHeight](https://reference.aspose.com/slides/de/net/aspose.slides/ithreedformat/properties/extrusionheight) | Wie weit die Form von ihrer Vorderseite nach hinten ausgedehnt wird. | Verwandeln Sie eine flache Form in ein sichtbar dickes 3D‑Objekt. |
| [ExtrusionColor](https://reference.aspose.com/slides/de/net/aspose.slides/ithreedformat/properties/extrusioncolor) | Farbe der extrudierten Seiten. | Machen Sie die Tiefe sichtbar oder stimmen Sie die Seitenfarbe mit der Vorderfüllung ab. |
| [Depth](https://reference.aspose.com/slides/de/net/aspose.slides/ithreedformat/properties/depth) | Zusätzliche 3D‑Tiefe, die von PowerPoint‑3D‑Formatierung verwendet wird. | Feinabstimmung der Tiefe für Formen oder Text, insbesondere zusammen mit Abschrägungs‑ und Materialeinstellungen. |
| [BevelTop](https://reference.aspose.com/slides/de/net/aspose.slides/ithreedformat/properties/beveltop) and [BevelBottom](https://reference.aspose.com/slides/de/net/aspose.slides/ithreedformat/properties/bevelbottom) | Erhobene oder abgerundete Kanten an Vorder- und Rückseite. | Fügen Sie eine weiche oder geformte Kante hinzu anstelle einer scharfen flachen Fläche. |
| [ContourColor](https://reference.aspose.com/slides/de/net/aspose.slides/ithreedformat/properties/contourcolor) and [ContourWidth](https://reference.aspose.com/slides/de/net/aspose.slides/ithreedformat/properties/contourwidth) | Umriss um das 3D‑Objekt. | Betonen Sie die Objektgrenze in der gerenderten Ausgabe. |

## **Erstellen einer 3D‑Form**

Eine Form benötigt in der Regel vier Arten von Einstellungen, bevor sie überzeugend 3D aussieht:

- Kameraeinstellungen, da die Standard‑Vorderansicht die Extrusion verbergen kann.
- Lichteinstellungen, weil Beleuchtung die Flächen und Seiten lesbar macht.
- Materialeinstellungen, weil die Oberfläche beeinflusst, wie Licht gerendert wird.
- Extrusions‑ oder Tiefeinstellungen, da eine flache Form Dicke benötigt.

Das folgende Beispiel erstellt ein Rechteck, fügt Text zu seiner Vorderseite hinzu und wendet 3D‑Formatierung an. Die Kameradrehwerte sind in Grad angegeben, und die Extrusionshöhe beträgt 100 Punkte. Das Beispiel rendert die Folie zu einem PNG‑Bild in der doppelten Standardgröße und speichert die Präsentation als PPTX.

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

![Gerendertes blaues 3D‑Rechteck mit weißem 3D‑Text auf der Vorderseite](img_01_01.png)

## **Eine Form mit der Kamera drehen**

In PowerPoint wird die 3D‑Drehung im Fenster „3‑D‑Drehung“ konfiguriert. Die X‑, Y‑ und Z‑Drehwerte entsprechen der Drehung, die Sie über die Kamera‑API festlegen.

![PowerPoint‑3‑D‑Drehungs‑Fenster mit hervorgehobenen X‑, Y‑ und Z‑Drehwerten](img_02_01.png)

In Aspose.Slides greifen Sie über [IThreeDFormat.Camera](https://reference.aspose.com/slides/de/net/aspose.slides/ithreedformat/properties/camera) auf die Kamera zu. Dieses Beispiel erstellt ein Rechteck, wählt eine orthografische Vorderansicht und setzt seine X‑, Y‑ und Z‑Drehungen auf 20, 30 bzw. 40 Grad. Es konfiguriert die Form im Speicher, ohne eine Datei zu speichern:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

Verwenden Sie die Kamera, wenn Sie ändern müssen, wie der Betrachter das Objekt sieht. Sie ändert nicht die 2D‑Geometrie der Form auf der Folie, sondern den 3D‑Blickpunkt, den PowerPoint und Aspose.Slides beim Rendern nutzen.

## **Extrusion und Tiefe hinzufügen**

Extrusion lässt eine Form dick wirken, indem sie hinter die Vorderfläche erweitert wird. In PowerPoint legt die Tiefensteuerung diese sichtbare Dicke fest, und die Farbsteuerung bestimmt die Farbe der Seitenflächen.

![PowerPoint‑Tiefensteuerungen, zugeordnet zu den Eigenschaften ExtrusionColor und ExtrusionHeight](img_02_02.png)

Setzen Sie [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/de/net/aspose.slides/ithreedformat/properties/extrusionheight) für die Dicke und [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/de/net/aspose.slides/ithreedformat/properties/extrusioncolor) für die Seitenfarbe. Dieses Beispiel gibt einem Rechteck eine 100‑Punkte‑Extrusion mit violetten Seiten und dreht die Kamera, um die Dicke sichtbar zu machen. Es konfiguriert die Form im Speicher, ohne eine Datei zu speichern:

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

Die [IThreeDFormat.Depth](https://reference.aspose.com/slides/de/net/aspose.slides/ithreedformat/properties/depth)-Eigenschaft legt die Tiefe einer 3D‑Form fest. Die [ExtrusionHeight](https://reference.aspose.com/slides/de/net/aspose.slides/ithreedformat/properties/extrusionheight)-Eigenschaft steuert die Höhe des Extrusions‑Effekts, wie in diesem Beispiel gezeigt.

## **Verlauf‑ oder Bildfüllungen mit 3D‑Effekten verwenden**

3D‑Formatierung ist unabhängig von der Formfüllung. Sie können eine einfarbige, verlaufende, gemusterte oder Bildfüllung auf die Vorderseite anwenden und dennoch dieselbe Kamera, Beleuchtung, Material und Extrusion verwenden.

Dieses Beispiel wendet einen blau‑zu‑orangefarbenen Verlauf auf die Vorderseite und eine dunkelorange Farbe auf die 150‑Punkte‑Extrusion an. Die Verlaufs‑Stops bei 0 % und 100 % markieren Anfang und Ende des Verlaufs. Die Kameradrehwerte sind in Grad. Die Folie wird zu einem PNG‑Bild in der doppelten Standardgröße gerendert:

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

![Gerendertes 3D‑Rechteck mit blau‑zu‑orangefarbenem Verlaufs‑Fill und orangefarbener Extrusion](img_02_03.png)

Um stattdessen eine Bildfüllung zu verwenden, fügen Sie das Bild zur Präsentation hinzu und weisen es der Formfüllung zu. Dieses Beispiel setzt voraus, dass im Arbeitsverzeichnis eine Datei namens "image.jpg" existiert. Das Bild wird über das Rechteck gestreckt, die Extrusion auf 150 Punkte gesetzt und die Kameradrehung in Grad angegeben. Es konfiguriert die Form im Speicher, ohne eine Datei zu speichern oder zu rendern:

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

![Gerendertes 3D‑Rechteck mit Foto‑Fill auf der Vorderseite und orangefarbener Extrusion](img_02_04.png)

## **3D‑Formatierung auf Text anwenden**

Die 3D‑Formatierung einer Form betrifft den Formkörper. Die 3D‑Formatierung von Text betrifft den Textrahmen. Das ist nützlich für WordArt‑ähnliche Effekte, bei denen die Buchstaben selbst Extrusion, Material, Beleuchtung und Kamera benötigen.

Das folgende Beispiel erstellt Text mit einem orange‑weiß‑Gittermuster, wendet einen nach oben gerichteten Bogen an und konfiguriert 3D‑Einstellungen über [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/de/net/aspose.slides/itextframeformat/properties/threedformat). Die Extrusions‑Höhe und Tiefe sind in Punkten angegeben, die Lichtdrehung in Grad. Die Formfüllung und Kontur sind ausgeblendet, sodass nur der Text sichtbar ist. Das Beispiel rendert ein PNG‑Bild in der doppelten Standard‑Foliengröße und speichert die Präsentation als PPTX:

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

![Gerenderter 3D‑Text mit bogenförmiger WordArt‑Transformation, orangefarbenem Muster‑Fill und dunkler Extrusion](img_02_05.png)

## **Text flach auf einer 3D‑Form halten**

Um Text lesbar zu halten und gleichzeitig das 3D‑Aussehen einer Form zu bewahren, setzen Sie [ITextFrameFormat.KeepTextFlat](https://reference.aspose.com/slides/de/net/aspose.slides/itextframeformat/keeptextflat/) über [ITextFrame.TextFrameFormat](https://reference.aspose.com/slides/de/net/aspose.slides/itextframe/textframeformat/). Wenn der Wert `true` ist, bleibt der Text außerhalb der 3D‑Szene. Ist er `false`, nimmt der Text an der Szene teil und folgt ihrer 3D‑Ausrichtung.

Diese Einstellung entfernt nicht die 3D‑Formatierung der Form: Kamera, Beleuchtung, Material und Extrusion bleiben über [IShape.ThreeDFormat](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/threedformat/) konfiguriert. Sie unterscheidet sich außerdem von einer normalen Drehung. [IShape.Rotation](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/rotation/) dreht die Form in der Folienebene, während [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/de/net/aspose.slides/itextframeformat/rotationangle/) die benutzerdefinierte Drehung des Textes innerhalb seines Begrenzungsrahmens steuert. Das Halten des Textes außerhalb der 3D‑Szene setzt keinen dieser Winkel zurück.

Das folgende eigenständige Beispiel erstellt ein blaues Rechteck mit Text und dupliziert es neben dem Original. Beide Formen haben dieselbe 3D‑Formatierung; nur die Texteinstellung unterscheidet sich: `false` links und `true` rechts. Die Kamerawinkel sind in Grad angegeben, die Extrusions‑Höhe beträgt 40 Punkte. Das Beispiel speichert die Präsentation als PPTX und rendert die Vergleichs‑Folie zu PNG in der doppelten Standardgröße.

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

![Nebeneinander‑stehende 3D‑Rechtecke: KeepTextFlat ist links false und rechts true](keep_text_flat.png)

## **Export‑ und Rendering‑Verhalten**

Aspose.Slides bewahrt 3D‑Formatierung beim Speichern in PowerPoint‑Formaten wie PPTX. Beim Rendern oder Exportieren in Layout‑feste Formate wird die 3D‑Szene rasterisiert bzw. in das Ergebnis als 2D‑Darstellung gezeichnet. Das gilt beim Rendern von Folien zu [PNG](/slides/de/net/convert-powerpoint-to-png/), beim Export zu [PDF](/slides/de/net/convert-powerpoint-to-pdf/), zu [HTML](/slides/de/net/convert-powerpoint-to-html/) oder beim Erzeugen von Frames für die [Video‑Konvertierung](/slides/de/net/convert-powerpoint-to-video/).

Beachten Sie folgende Punkte:

- Exportierte Bilder und PDFs sind nicht interaktiv. Das Objekt kann nach dem Export vom Betrachter nicht mehr gedreht werden.
- Das endgültige Erscheinungsbild hängt von der Kombination aus Kamera, Beleuchtung, Material, Extrusion, Füllung und Folien‑Skalierung ab.
- Wenn Sie vererbte oder themenbasierte Formatierungswerte prüfen müssen, lesen Sie die [effektiven Form‑Eigenschaften](/slides/de/net/shape-effective-properties/).
- Einige Ausgabeformate können keine editierbare PowerPoint‑3D‑Formatierung speichern. In diesen Formaten wird das visuelle Ergebnis gerendert, nicht als editierbare 3D‑Einstellungen erhalten.

## **FAQ**

**Kann Aspose.Slides interaktive 3D‑Präsentationen erstellen?**

Aspose.Slides erstellt und rendert PowerPoint‑3D‑Effekte für Formen und Text. Es macht exportierte Bilder, PDFs oder HTML‑Seiten nicht zu interaktiven 3D‑Szenen, die ein Betrachter rotieren kann. In PPTX bleibt die 3D‑Formatierung in PowerPoint editierbar, sofern das Format sie unterstützt.

**Was ist der Unterschied zwischen einem 3D‑Modell und einem 3D‑Effekt?**

Ein 3D‑Modell ist ein separates 3D‑Objekt, das in eine Präsentation eingefügt wird. Ein 3D‑Effekt ist eine Formatierung, die auf eine reguläre PowerPoint‑Form oder auf Text angewendet wird, z. B. Drehung, Extrusion, Abschrägung, Beleuchtung und Material. Dieser Artikel behandelt 3D‑Effekte.

**Welche Einstellungen sind erforderlich, damit eine 3D‑Form sichtbar wird?**

Mindestens eine Kameradrehung und entweder Extrusion oder Tiefe müssen gesetzt werden. In der Praxis sollten zudem ein LightRig und Material gesetzt werden, damit die gerenderten Flächen klare Highlights und Schatten zeigen.

**Kann ich 3D‑Effekte sowohl auf Formen als auch auf Text anwenden?**

Ja. Verwenden Sie [IShape.ThreeDFormat](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/properties/threedformat) für den Formkörper und [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/de/net/aspose.slides/itextframeformat/properties/threedformat) für Text.

**Werden 3D‑Effekte beim Export zu Bildern, PDF, HTML oder Video‑Frames angezeigt?**

Ja. Aspose.Slides rendert 3D‑Effekte, wenn Folienbilder, PDF‑Ausgaben, HTML‑Ausgaben oder Frames für die Video‑Konvertierung erzeugt werden. Die exportierten Ausgaben enthalten das gerenderte Erscheinungsbild, nicht ein editierbares 3D‑Objekt.

**Kann ich die endgültigen 3D‑Werte nach Vererbung und Themen‑Einstellungen auslesen?**

Ja. Verwenden Sie die APIs für effektive Formatierung, die in [Shape Effective Properties](/slides/de/net/shape-effective-properties/) beschrieben sind, um die endgültigen Kamera‑, LightRig‑, Bevel‑ und zugehörigen 3D‑Werte zu lesen.