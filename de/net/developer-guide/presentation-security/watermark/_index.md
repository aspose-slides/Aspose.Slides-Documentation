---
title: Wasserzeichen zu Präsentationen in .NET hinzufügen
linktitle: Wasserzeichen
type: docs
weight: 40
url: /de/net/watermark/
keywords:
- Wasserzeichen
- Textwasserzeichen
- Bildwasserzeichen
- Wasserzeichen hinzufügen
- Wasserzeichen ändern
- Wasserzeichen entfernen
- Wasserzeichen löschen
- Wasserzeichen zu PPT hinzufügen
- Wasserzeichen zu PPTX hinzufügen
- Wasserzeichen zu ODP hinzufügen
- Wasserzeichen aus PPT entfernen
- Wasserzeichen aus PPTX entfernen
- Wasserzeichen aus ODP entfernen
- Wasserzeichen aus PPT löschen
- Wasserzeichen aus PPTX löschen
- Wasserzeichen aus ODP löschen
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Verwalten Sie Text- und Bildwasserzeichen in PowerPoint- und OpenDocument-Präsentationen in .NET, um Entwürfe, vertrauliche Informationen, Urheberrechte und mehr anzuzeigen."
---
## **Einleitung**

**Ein Wasserzeichen** in einer Präsentation ist ein Text‑ oder Bildstempel, der auf einer Folie oder in allen Folien einer Präsentation verwendet wird. Üblicherweise wird ein Wasserzeichen eingesetzt, um anzuzeigen, dass die Präsentation ein Entwurf ist (z. B. ein „Entwurf“-Wasserzeichen), dass sie vertrauliche Informationen enthält (z. B. ein „Vertraulich“-Wasserzeichen), welchem Unternehmen sie zuzuordnen ist (z. B. ein „Firmenname“-Wasserzeichen), den Autor der Präsentation zu identifizieren usw. Ein Wasserzeichen hilft, Urheberrechtsverletzungen zu verhindern, indem es anzeigt, dass die Präsentation nicht kopiert werden darf. Wasserzeichen werden sowohl im PowerPoint‑ als auch im OpenDocument‑Präsentationsformat verwendet. In Aspose.Slides können Sie ein Wasserzeichen zu PowerPoint‑PPT-, PPTX‑ und OpenDocument‑ODP‑Dateiformaten hinzufügen.

In [**Aspose.Slides**](https://products.aspose.com/slides/de/net/) gibt es verschiedene Möglichkeiten, Wasserzeichen in PowerPoint‑ oder OpenDocument‑Dokumenten zu erzeugen und deren Design und Verhalten zu ändern. Der gemeinsame Aspekt ist, dass Sie zum Hinzufügen von Text‑Wasserzeichen die [ITextFrame](https://reference.aspose.com/slides/de/net/aspose.slides/itextframe/)‑Schnittstelle verwenden sollten und zum Hinzufügen von Bild‑Wasserzeichen die [PictureFrame](https://reference.aspose.com/slides/de/net/aspose.slides/pictureframe/)‑Klasse oder das Füllen einer Wasserzeichen‑Form mit einem Bild. `PictureFrame` implementiert die [IShape](https://reference.aspose.com/slides/de/net/aspose.slides/ishape)‑Schnittstelle, sodass Sie alle flexiblen Einstellungen des Formobjekts nutzen können. Da `ITextFrame` keine Form ist und seine Einstellungen begrenzt sind, wird es in ein [IShape](https://reference.aspose.com/slides/de/net/aspose.slides/ishape)‑Objekt eingewickelt.

Ein Wasserzeichen kann auf zwei Arten angewendet werden: auf einer einzelnen Folie oder auf allen Folien der Präsentation. Der Folien‑Master wird verwendet, um ein Wasserzeichen auf alle Folien anzuwenden — das Wasserzeichen wird dem Folien‑Master hinzugefügt, dort vollständig gestaltet und auf alle Folien angewendet, ohne die Möglichkeit zu beeinträchtigen, das Wasserzeichen auf einzelnen Folien zu ändern.

Ein Wasserzeichen gilt normalerweise als für andere Benutzer nicht editierbar. Um zu verhindern, dass das Wasserzeichen (bzw. die übergeordnete Form des Wasserzeichens) bearbeitet wird, bietet Aspose.Slides eine Funktions‑zur‑Form‑Sperrung. Eine bestimmte Form kann auf einer normalen Folie oder auf einem Folien‑Master gesperrt werden. Wenn die Wasserzeichen‑Form auf dem Folien‑Master gesperrt ist, ist sie auf allen Folien gesperrt.

Sie können dem Wasserzeichen einen Namen zuweisen, sodass Sie es später anhand des Namens in den Folien‑Formen finden und löschen können.

Sie können das Wasserzeichen nach Belieben gestalten; typischerweise weisen Wasserzeichen jedoch gemeinsame Merkmale wie zentrierte Ausrichtung, Drehung, Vordergrundposition usw. auf. Wir werden im Folgenden zeigen, wie diese Eigenschaften in den Beispielen verwendet werden.

## **Text‑Wasserzeichen**

### **Ein Text‑Wasserzeichen zu einer Folie hinzufügen**

Um ein Text‑Wasserzeichen in PPT, PPTX oder ODP hinzuzufügen, können Sie zuerst eine Form zur Folie hinzufügen und dann dieser Form einen Text‑Frame zuweisen. Der Text‑Frame wird durch die [ITextFrame](https://reference.aspose.com/slides/de/net/aspose.slides/itextframe)‑Schnittstelle repräsentiert. Dieser Typ erbt nicht von [IShape](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/), das einen umfangreichen Satz von Eigenschaften für die flexible Positionierung des Wasserzeichens bietet. Deshalb wird das [ITextFrame](https://reference.aspose.com/slides/de/net/aspose.slides/itextframe)‑Objekt in ein [IAutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/)‑Objekt eingebettet. Um dem Shape Text‑Wasserzeichen hinzuzufügen, verwenden Sie die [AddTextFrame](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/methods/addtextframe)‑Methode wie unten gezeigt.

```cs
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// Das Wasserzeichen zur Folie hinzufügen.
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="info" title="Siehe auch" %}} 
- [Wie verwendet man die TextFrame‑Klasse?](/slides/de/net/text-formatting/)
{{% /alert %}}

### **Ein Text‑Wasserzeichen zur gesamten Präsentation hinzufügen**

Wenn Sie ein Text‑Wasserzeichen zur gesamten Präsentation (also zu allen Folien gleichzeitig) hinzufügen möchten, fügen Sie es dem [MasterSlide](https://reference.aspose.com/slides/de/net/aspose.slides/masterslide/) hinzu. Der Rest der Logik ist identisch mit dem Hinzufügen eines Wasserzeichens zu einer einzelnen Folie — erzeugen Sie ein [IAutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/)‑Objekt und fügen Sie das Wasserzeichen mit der [AddTextFrame](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/methods/addtextframe)‑Methode hinzu.

```cs
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.Masters[0];

// Das Wasserzeichen zum Master-Layout hinzufügen.
IAutoShape watermarkShape = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="info" title="Siehe auch" %}} 
- [Wie verwendet man den Folien‑Master?](/slides/de/net/slide-master/)
{{% /alert %}}

### **Transparenz der Wasserzeichen‑Form festlegen**

Standardmäßig ist die Rechteck‑Form mit Füll‑ und Linienfarbe formatiert. Das bedeutet, dass das Wasserzeichen beim Hinzufügen einen soliden Hintergrund oder Rahmen besitzen kann, der vom Folieninhalt ablenkt. Um sicherzustellen, dass das Wasserzeichen dezent bleibt und das visuelle Design der Präsentation nicht stört, können Sie die Form vollständig transparent machen.

Die folgenden Codezeilen entfernen sowohl die Füll‑ als auch die Rahmenfarbe und machen die Form transparent:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.FillFormat.FillType = FillType.NoFill;
watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;
```

### **Schriftart für ein Text‑Wasserzeichen festlegen**

Bevor Sie das Text‑Wasserzeichen auf Ihre Folie anwenden, sollten Sie sein Erscheinungsbild an das Gesamtdesign anpassen. Sie können die Schriftart und -größe ändern, damit das Wasserzeichen gut lesbar und ästhetisch ansprechend ist. Die Anpassung der Schriftart unterstützt zudem die Markenidentität oder das passende Präsentationsstil.

Im folgenden Code‑Snippet wird gezeigt, wie Sie die Schriftart auf eine bestimmte lateinische Schrift setzen und eine geeignete Schriftgröße festlegen:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame("CONFIDENTIAL");

IPortionFormat textFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
textFormat.LatinFont = new FontData("Arial");
textFormat.FontHeight = 50;
```

### **Farbe des Wasserzeichen‑Texts festlegen**

Bevor Sie Ihr Wasserzeichen anwenden, sollten Sie die Textfarbe so einstellen, dass sie gut mit dem Folieninhalt harmoniert, ohne zu dominieren. Durch Anpassen der Transparenz (Alpha) sowie der Rot‑, Grün‑ und Blau‑Komponenten können Sie ein dezentes, halbtransparentes Wasserzeichen erzeugen, das sichtbar, aber unaufdringlich ist. Dieser Ansatz bewahrt den Fokus auf Ihrer Hauptpräsentation und schützt gleichzeitig den Inhalt.

Verwenden Sie folgenden Code, um die Farbe des Wasserzeichen‑Texts festzulegen:

```cs
using System.Drawing;
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame("CONFIDENTIAL");

int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat;
fillFormat.FillType = FillType.Solid;
fillFormat.SolidFillColor.Color = Color.FromArgb(alpha, red, green, blue);
```

### **Text‑Wasserzeichen zentrieren**

Ein korrekt zentriertes Text‑Wasserzeichen verbessert das Gesamtbild Ihrer Präsentation erheblich, indem es symmetrisch platziert wird, unabhängig von den Folienabmessungen. Dies verleiht Ihren Folien ein professionelles Aussehen und sorgt dafür, dass das Wasserzeichen den Hauptinhalt nicht beeinträchtigt.

Der nachfolgende Code berechnet die zentrale Position einer Folie und platziert das Text‑Wasserzeichen entsprechend:

```cs
using System.Drawing;
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

SizeF slideSize = presentation.SlideSize.Size;

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = (slideSize.Width - watermarkWidth) / 2;
float watermarkY = (slideSize.Height - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.Shapes.AddAutoShape(
    ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

Das Bild unten zeigt das Endergebnis.

![The text watermark](text_watermark.png)

## **Bild‑Wasserzeichen**

### **Ein Bild‑Wasserzeichen zur Präsentation hinzufügen**

In vielen Fällen kann ein Bild‑Wasserzeichen ein einzigartiges Branding‑Element oder eine optisch ansprechendere Alternative zu einem Text‑Wasserzeichen bieten. Stellen Sie vor dem Hinzufügen sicher, dass die Bilddatei verfügbar ist (z. B. PNG für Transparenz). Das folgende Beispiel zeigt, wie Sie ein Bild aus dem Dateisystem laden, es der Präsentation hinzufügen und anschließend als Wasserzeichen über die Füll‑Eigenschaften der Form anwenden.

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

using FileStream imageStream = File.OpenRead("watermark.png");
IPPImage image = presentation.Images.AddImage(imageStream);

watermarkShape.FillFormat.FillType = FillType.Picture;
watermarkShape.FillFormat.PictureFillFormat.Picture.Image = image;
watermarkShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
```

## **Wasserzeichen vor Bearbeitung schützen**

Falls ein Wasserzeichen nicht bearbeitet werden darf, verwenden Sie die [IAutoShape.ShapeLock](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/properties/shapelock)‑Eigenschaft der Form. Mit dieser Eigenschaft können Sie die Form vor Auswahl, Größenänderung, Verschiebung, Gruppierung mit anderen Elementen, Bearbeitung ihres Textes und vielem mehr schützen:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

// Das Wasserzeichen-Shape vor Änderungen sperren.
watermarkShape.ShapeLock.SelectLocked = true;
watermarkShape.ShapeLock.SizeLocked = true;
watermarkShape.ShapeLock.TextLocked = true;
watermarkShape.ShapeLock.PositionLocked = true;
watermarkShape.ShapeLock.GroupingLocked = true;
```

## **Wasserzeichen in den Vordergrund bringen**

In Aspose.Slides kann die Z‑Reihenfolge von Formen über die [IShapeCollection.Reorder](https://reference.aspose.com/slides/de/net/aspose.slides/ishapecollection/reorder/#reorder)‑Methode festgelegt werden. Rufen Sie diese Methode aus der Liste der Präsentations‑Folien auf und übergeben Sie die Form‑Referenz sowie deren neue Reihenfolgen‑Nummer. So lässt sich eine Form in den Vordergrund oder in den Hintergrund der Folie verschieben. Diese Funktion ist besonders nützlich, wenn das Wasserzeichen vor dem restlichen Inhalt angezeigt werden soll:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

int shapeCount = slide.Shapes.Count;
slide.Shapes.Reorder(shapeCount - 1, watermarkShape);
```

## **Drehung des Wasserzeichens festlegen**

Die Drehung Ihres Wasserzeichens kann die visuelle Wirkung und Subtilität Ihrer Präsentation stark beeinflussen. Ein diagonales Wasserzeichen ist beispielsweise weniger aufdringlich, bietet aber dennoch effektiven Schutz vor unbefugter Nutzung. Das folgende Beispiel berechnet den passenden Winkel basierend auf den Folienabmessungen, sodass das Wasserzeichen diagonal über die Folie verläuft. Diese dynamische Berechnung stellt sicher, dass das Wasserzeichen unabhängig von variierenden Foliengrößen wirksam bleibt.

```cs
using System.Drawing;
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

SizeF slideSize = presentation.SlideSize.Size;

double diagonalAngle = Math.Atan((slideSize.Height / slideSize.Width)) * 180 / Math.PI;

watermarkShape.Rotation = (float)diagonalAngle;
```

## **Einen Namen für ein Wasserzeichen festlegen**

Aspose.Slides ermöglicht das Festlegen eines Namens für eine Form. Durch die Verwendung des Formnamens können Sie die Form später wiederfinden, um sie zu ändern oder zu löschen. Um den Namen der Wasserzeichen‑Form zu setzen, weisen Sie ihn der [IAutoShape.Name](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/properties/name)‑Eigenschaft zu:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.Name = "watermark";
```

## **Wasserzeichen entfernen**

Um die Wasserzeichen‑Form zu entfernen, nutzen Sie die [IAutoShape.Name](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/properties/name)‑Eigenschaft, um sie in den Folien‑Formen zu finden. Anschließend übergeben Sie die Form an die [IShapeCollection.Remove](https://reference.aspose.com/slides/de/net/aspose.slides/ishapecollection/remove/)‑Methode:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

List<IShape> slideShapes = slide.Shapes.ToList();
foreach (IShape shape in slideShapes)
{
    if (string.Compare(shape.Name, "watermark", StringComparison.Ordinal) == 0)
    {
        slide.Shapes.Remove(shape);
    }
}
```

## **Ein Live‑Beispiel**

Probieren Sie die kostenlosen Aspose.Slides‑Tools **Add Watermark** und **Remove Watermark** online aus.

![Online tools to add and remove watermarks](online_tools.png)

## **FAQ**

### Was ist ein Wasserzeichen und warum sollte ich es verwenden?

Ein Wasserzeichen ist ein Text‑ oder Bild‑Overlay, das auf Folien angewendet wird, um geistiges Eigentum zu schützen, die Markenbekanntheit zu steigern oder die unbefugte Nutzung von Präsentationen zu verhindern.

### Kann ich ein Wasserzeichen zu allen Folien einer Präsentation hinzufügen?

Ja, Aspose.Slides ermöglicht das programmgesteuerte Hinzufügen eines Wasserzeichens zu jeder Folie einer Präsentation. Sie können über alle Folien iterieren und die Wasserzeichen‑Einstellungen einzeln anwenden.

### Wie kann ich die Transparenz des Wasserzeichens anpassen?

Die Transparenz des Wasserzeichens kann durch Ändern der Füll‑Einstellungen ([FillFormat](https://reference.aspose.com/slides/de/net/aspose.slides/shape/fillformat/)) der Form angepasst werden. So bleibt das Wasserzeichen dezent und lenkt nicht vom Folieninhalt ab.

### Welche Bildformate werden für Wasserzeichen unterstützt?

Aspose.Slides unterstützt verschiedene Bildformate wie PNG, JPEG, GIF, BMP, SVG und weitere.

### Kann ich die Schriftart und den Stil eines Text‑Wasserzeichens anpassen?

Ja, Sie können jede Schriftart, Größe und jeden Stil wählen, um das Design Ihrer Präsentation zu ergänzen und die Marken‑Konsistenz zu wahren.

### Wie ändere ich die Position oder Ausrichtung eines Wasserzeichens?

Sie können die Position und Ausrichtung des Wasserzeichens programmgesteuert anpassen, indem Sie die Koordinaten, Größe und Dreh‑Eigenschaften der Form ändern.