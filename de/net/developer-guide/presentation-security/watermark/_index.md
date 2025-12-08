---
title: Ein Wasserzeichen zu einer Präsentation in C# hinzufügen
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
- Wasserzeichen zur Präsentation hinzufügen
- Wasserzeichen zu PPT hinzufügen
- Wasserzeichen zu PPTX hinzufügen
- Wasserzeichen zu ODP hinzufügen
- Wasserzeichen aus Präsentation entfernen
- Wasserzeichen aus PPT entfernen
- Wasserzeichen aus PPTX entfernen
- Wasserzeichen aus ODP entfernen
- Wasserzeichen aus Präsentation löschen
- Wasserzeichen aus PPT löschen
- Wasserzeichen aus PPTX löschen
- Wasserzeichen aus ODP löschen
- PowerPoint
- OpenDocument
- Präsentation
- C#
- Csharp
- Aspose.Slides für .NET
description: "Erfahren Sie, wie Sie Text- und Bildwasserzeichen in PowerPoint- und OpenDocument-Präsentationen in C# verwalten, um einen Entwurf, vertrauliche Informationen, Urheberrecht und mehr anzuzeigen."
---

## **Übersicht**

**Ein Wasserzeichen** in einer Präsentation ist ein Text‑ oder Bildstempel, der auf einer Folie oder auf allen Folien einer Präsentation verwendet wird. In der Regel wird ein Wasserzeichen verwendet, um anzuzeigen, dass die Präsentation ein Entwurf ist (z. B. ein „Entwurf“-Wasserzeichen), dass sie vertrauliche Informationen enthält (z. B. ein „Vertraulich“-Wasserzeichen), um anzugeben, zu welchem Unternehmen sie gehört (z. B. ein „Firmenname“-Wasserzeichen), um den Autor der Präsentation zu identifizieren usw. Ein Wasserzeichen hilft, Urheberrechtsverletzungen zu verhindern, indem es anzeigt, dass die Präsentation nicht kopiert werden sollte. Wasserzeichen werden sowohl im PowerPoint‑ als auch im OpenDocument‑Präsentationsformat verwendet. In Aspose.Slides können Sie ein Wasserzeichen zu PowerPoint‑PPT, PPTX und OpenDocument‑ODP‑Dateiformaten hinzufügen.

In [**Aspose.Slides**](https://products.aspose.com/slides/net/) gibt es verschiedene Möglichkeiten, Wasserzeichen in PowerPoint‑ oder OpenDocument‑Dokumenten zu erstellen und ihr Design sowie ihr Verhalten zu ändern. Der gemeinsame Aspekt ist, dass zum Hinzufügen von Textwasserzeichen die [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/)‑Schnittstelle verwendet werden sollte, und zum Hinzufügen von Bildwasserzeichen die [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/)-Klasse oder das Füllen einer Wasserzeichen‑Form mit einem Bild. `PictureFrame` implementiert die [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape)-Schnittstelle, sodass Sie alle flexiblen Einstellungen des Form‑Objekts verwenden können. Da `ITextFrame` keine Form ist und seine Einstellungen eingeschränkt sind, wird es in ein [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape)-Objekt verpackt.

Es gibt zwei Möglichkeiten, ein Wasserzeichen anzuwenden: auf einer einzelnen Folie oder auf allen Folien einer Präsentation. Der Folienmaster wird verwendet, um ein Wasserzeichen auf alle Folien anzuwenden – das Wasserzeichen wird dem Folienmaster hinzugefügt, dort vollständig gestaltet und dann auf alle Folien angewendet, ohne die Möglichkeit zu beeinträchtigen, das Wasserzeichen auf einzelnen Folien zu ändern.

Ein Wasserzeichen wird in der Regel als für andere Benutzer nicht editierbar angesehen. Um zu verhindern, dass das Wasserzeichen (bzw. die übergeordnete Form des Wasserzeichens) bearbeitet wird, bietet Aspose.Slides eine Form‑Sperrfunktion. Eine bestimmte Form kann auf einer normalen Folie oder auf einem Folienmaster gesperrt werden. Wenn die Wasserzeichen‑Form auf dem Folienmaster gesperrt ist, wird sie auf allen Folien gesperrt.

Sie können dem Wasserzeichen einen Namen zuweisen, sodass Sie es in Zukunft, wenn Sie es löschen möchten, anhand des Namens in den Folienformen finden können.

Sie können das Wasserzeichen nach Belieben gestalten; es gibt jedoch normalerweise gemeinsame Merkmale von Wasserzeichen, wie zentrierte Ausrichtung, Drehung, Vorderposition usw. Wir werden im Folgenden betrachten, wie man diese in den Beispielen verwendet.

## **Textwasserzeichen**

### **Ein Textwasserzeichen zu einer Folie hinzufügen**

Um ein Textwasserzeichen in PPT, PPTX oder ODP hinzuzufügen, können Sie zunächst eine Form zur Folie hinzufügen und dann dieser Form einen Textrahmen hinzufügen. Der Textrahmen wird durch die [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe)-Schnittstelle repräsentiert. Dieser Typ erbt nicht von [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/), das einen breiten Satz von Eigenschaften zur flexiblen Positionierung des Wasserzeichens bietet. Daher wird das [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe)-Objekt in ein [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)-Objekt verpackt. Um Wasserzeichentext zur Form hinzuzufügen, verwenden Sie die [AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/methods/addtextframe)-Methode wie unten gezeigt.
```cs
string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// Fügen Sie das Wasserzeichen zur Folie hinzu.
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```


{{% alert color="primary" title="Siehe auch" %}} 
- [Wie verwendet man die TextFrame‑Klasse?](/slides/de/net/text-formatting/)
{{% /alert %}}

### **Ein Textwasserzeichen zu einer Präsentation hinzufügen**

Wenn Sie ein Textwasserzeichen zur gesamten Präsentation (d. h. zu allen Folien auf einmal) hinzufügen möchten, fügen Sie es dem [MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/) hinzu. Der Rest der Logik ist derselbe wie beim Hinzufügen eines Wasserzeichens zu einer einzelnen Folie – erstellen Sie ein [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)-Objekt und fügen Sie dann das Wasserzeichen mit der [AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/methods/addtextframe)-Methode hinzu.
```cs
string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.Masters[0];

// Fügen Sie das Wasserzeichen zur Masterfolie hinzu.
IAutoShape watermarkShape = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```


{{% alert color="primary" title="Siehe auch" %}} 
- [Wie verwendet man den Folienmaster?](/slides/de/net/slide-master/)
{{% /alert %}}

### **Transparenz der Wasserzeichen‑Form einstellen**

Standardmäßig ist die Rechteckform mit Füll‑ und Linienfarben formatiert. Das bedeutet, dass das Wasserzeichen beim Hinzufügen möglicherweise mit einem festen Hintergrund oder einer Rahmenfarbe erscheint, die vom Folieninhalt ablenken kann. Um sicherzustellen, dass das Wasserzeichen dezent bleibt und das visuelle Design der Präsentation nicht stört, können Sie die Form vollständig transparent machen.

Die folgenden Codezeilen machen die Form transparent, indem sowohl die Füll‑ als auch die Rahmenfarbe entfernt werden:
```cs
watermarkShape.FillFormat.FillType = FillType.NoFill;
watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;
```


### **Schriftart für ein Textwasserzeichen festlegen**

Bevor Sie das Textwasserzeichen auf Ihre Folie anwenden, sollten Sie dessen Aussehen anpassen, damit es mit dem Gesamtdesign harmoniert. Sie können die Schriftart und -größe ändern, um sicherzustellen, dass das Wasserzeichen gut lesbar und ästhetisch ansprechend ist. Das Anpassen der Schriftart kann auch helfen, die Markenidentität zu stärken oder einfach den Präsentationsstil zu treffen.

Der nachstehende Codeausschnitt zeigt, wie Sie die Schrifteinstellungen des Wasserzeichens ändern, indem Sie eine bestimmte lateinische Schrift auswählen und eine passende Schriftgröße festlegen:
```cs
IPortionFormat textFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
textFormat.LatinFont = new FontData("Arial");
textFormat.FontHeight = 50;
```


### **Farbe des Wasserzeichentextes festlegen**

Bevor Sie Ihr Wasserzeichen anwenden, müssen Sie sicherstellen, dass die Textfarbe passend gewählt ist, damit sie sich gut in den Folieninhalt einfügt, ohne ihn zu überlagern. Durch Anpassen der Transparenz (Alpha) sowie der Rot‑, Grün‑ und Blauanteile können Sie ein dezentes, halbtransparentes Wasserzeichen erzeugen, das sichtbar, aber unaufdringlich bleibt. Dieser Ansatz hilft, den Fokus auf die eigentliche Präsentation zu behalten und gleichzeitig den Inhalt zu schützen.

Um die Farbe des Wasserzeichentextes festzulegen, verwenden Sie den folgenden Code:
```cs
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat;
fillFormat.FillType = FillType.Solid;
fillFormat.SolidFillColor.Color = Color.FromArgb(alpha, red, green, blue);
```


### **Ein Textwasserzeichen zentrieren**

Das korrekte Zentrieren Ihres Textwasserzeichens kann die Gesamtästhetik Ihrer Präsentation erheblich verbessern, indem das Wasserzeichen symmetrisch positioniert wird, unabhängig von den Folienabmessungen. Dieser Ansatz verleiht Ihren Folien ein professionelles Aussehen und stellt sicher, dass das Wasserzeichen nicht mit dem Hauptinhalt der Folie kollidiert.

Der nachstehende Codeausschnitt zeigt, wie Sie die Mitte einer Folie berechnen und das Textwasserzeichen entsprechend platzieren:
```cs
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

![Das Textwasserzeichen](text_watermark.png)

## **Bildwasserzeichen**

### **Ein Bildwasserzeichen zu einer Präsentation hinzufügen**

In vielen Fällen kann ein Bildwasserzeichen ein einzigartiges Branding-Element oder eine visuell ansprechendere Alternative zu einem Textwasserzeichen bieten. Stellen Sie vor dem Hinzufügen des Wasserzeichens sicher, dass die Bilddatei verfügbar ist (z. B. PNG für Transparenz). Das folgende Beispiel zeigt, wie Sie ein Bild aus dem Dateisystem laden, zur Präsentation hinzufügen und es dann als Wasserzeichen über die Fülleigenschaften der Form anwenden.
```cs
using FileStream imageStream = File.OpenRead("watermark.png");
IPPImage image = presentation.Images.AddImage(imageStream);

watermarkShape.FillFormat.FillType = FillType.Picture;
watermarkShape.FillFormat.PictureFillFormat.Picture.Image = image;
watermarkShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
```


## **Ein Wasserzeichen vor dem Bearbeiten schützen**

Falls es nötig ist, ein Wasserzeichen vor dem Bearbeiten zu schützen, verwenden Sie die [IAutoShape.ShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/properties/shapelock)-Eigenschaft der Form. Mit dieser Eigenschaft können Sie die Form davor schützen, ausgewählt, in der Größe geändert, neu positioniert, mit anderen Elementen gruppiert, ihr Text vor Bearbeitung gesperrt und vieles mehr zu werden:
```cs
// Sperrt die Wasserzeichenform vor Änderungen.
watermarkShape.ShapeLock.SelectLocked = true;
watermarkShape.ShapeLock.SizeLocked = true;
watermarkShape.ShapeLock.TextLocked = true;
watermarkShape.ShapeLock.PositionLocked = true;
watermarkShape.ShapeLock.GroupingLocked = true;
```


## **Ein Wasserzeichen in den Vordergrund bringen**

In Aspose.Slides kann die Z‑Reihenfolge von Formen über die [IShapeCollection.Reorder](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/reorder/#reorder)-Methode festgelegt werden. Dazu rufen Sie diese Methode aus der Liste der Präsentationsfolien auf und übergeben die Formreferenz sowie ihre Reihenfolgenummer. Auf diese Weise kann eine Form in den Vordergrund oder in den Hintergrund einer Folie verschoben werden. Diese Funktion ist besonders nützlich, wenn Sie ein Wasserzeichen vor dem restlichen Präsentationsinhalt platzieren möchten:
```cs
int shapeCount = slide.Shapes.Count;
slide.Shapes.Reorder(shapeCount - 1, watermarkShape);
```


## **Wasserzeichen‑Drehung festlegen**

Das Anpassen der Drehung Ihres Wasserzeichens kann die visuelle Wirkung und Diskretion Ihrer Präsentation erheblich steigern. Ein diagonales Wasserzeichen kann beispielsweise weniger aufdringlich sein und dennoch einen starken Schutz gegen unbefugte Nutzung bieten. Das folgende Beispiel berechnet den passenden Winkel basierend auf den Folienabmessungen, sodass das Wasserzeichen diagonal über die Folie angeordnet wird. Diese dynamische Berechnung stellt sicher, dass das Wasserzeichen bei unterschiedlichen Foliengrößen wirksam bleibt.
```cs
double diagonalAngle = Math.Atan((slideSize.Height / slideSize.Width)) * 180 / Math.PI;

watermarkShape.Rotation = (float)diagonalAngle;
```


## **Einem Wasserzeichen einen Namen zuweisen**

Aspose.Slides ermöglicht das Festlegen eines Formnamens. Durch die Verwendung des Formnamens können Sie die Form in Zukunft wiederfinden, um sie zu ändern oder zu löschen. Um den Namen der Wasserzeichen‑Form festzulegen, weisen Sie sie der [IAutoShape.Name](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/name)-Eigenschaft zu:
```cs
watermarkShape.Name = "watermark";
```


## **Ein Wasserzeichen entfernen**

Um die Wasserzeichen‑Form zu entfernen, verwenden Sie die [IAutoShape.Name](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/name)-Eigenschaft, um sie in den Folienformen zu finden. Anschließend übergeben Sie die Wasserzeichen‑Form an die [IShapeCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/remove/)-Methode:
```cs
List<IShape> slideShapes = slide.Shapes.ToList();
foreach (IShape shape in slideShapes)
{
    if (string.Compare(shape.Name, "watermark", StringComparison.Ordinal) == 0)
    {
        slide.Shapes.Remove(watermarkShape);
    }
}
```


## **Ein Live‑Beispiel**

Sie können die **Aspose.Slides free**‑Tools **[Wasserzeichen hinzufügen](https://products.aspose.app/slides/watermark)** und **[Wasserzeichen entfernen](https://products.aspose.app/slides/watermark/remove-watermark)** online ausprobieren.

![Online‑Tools zum Hinzufügen und Entfernen von Wasserzeichen](online_tools.png)

## **FAQ**

**Was ist ein Wasserzeichen und warum sollte ich es verwenden?**

Ein Wasserzeichen ist ein Text‑ oder Bild‑Overlay, das auf Folien angewendet wird, um geistiges Eigentum zu schützen, die Markenbekanntheit zu steigern oder die unbefugte Nutzung von Präsentationen zu verhindern.

**Kann ich ein Wasserzeichen zu allen Folien einer Präsentation hinzufügen?**

Ja, Aspose.Slides ermöglicht das programmatische Hinzufügen eines Wasserzeichens zu jeder Folie einer Präsentation. Sie können über alle Folien iterieren und die Wasserzeichen‑Einstellungen einzeln anwenden.

**Wie kann ich die Transparenz des Wasserzeichens anpassen?**

Sie können die Transparenz des Wasserzeichens ändern, indem Sie die Fülleinstellungen ([FillFormat](https://reference.aspose.com/slides/net/aspose.slides/shape/fillformat/)) der Form anpassen. Dadurch bleibt das Wasserzeichen dezent und lenkt nicht vom Folieninhalt ab.

**Welche Bildformate werden für Wasserzeichen unterstützt?**

Aspose.Slides unterstützt verschiedene Bildformate wie PNG, JPEG, GIF, BMP, SVG und mehr.

**Kann ich Schriftart und Stil eines Textwasserzeichens anpassen?**

Ja, Sie können jede Schriftart, Größe und jeden Stil wählen, um das Design Ihrer Präsentation zu unterstützen und Marken‑Konsistenz zu wahren.

**Wie ändere ich die Position oder Ausrichtung eines Wasserzeichens?**

Sie können Position und Ausrichtung des Wasserzeichens programmatisch anpassen, indem Sie die Koordinaten, Größe und Drehungseigenschaften der Form ändern.