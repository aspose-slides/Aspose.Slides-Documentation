---
title: Wasserzeichen
type: docs
weight: 40
url: /net/watermark/
keywords:
- wasserzeichen
- wasserzeichen hinzufügen
- textwasserzeichen
- bildwasserzeichen
- PowerPoint
- präsentation
- C#
- Csharp
- Aspose.Slides für .NET
description: "Fügen Sie text- und bildwasserzeichen zu PowerPoint-Präsentationen in C# oder .NET hinzu"
---

## **Über Wasserzeichen**

**Ein Wasserzeichen** in einer Präsentation ist ein Text- oder Bildstempel, der auf einer Folie oder in allen Folien der Präsentation verwendet wird. Normalerweise wird ein Wasserzeichen verwendet, um anzuzeigen, dass die Präsentation ein Entwurf ist (z.B. ein "Entwurf"-Wasserzeichen), dass sie vertrauliche Informationen enthält (z.B. ein "Vertraulich"-Wasserzeichen), um anzugeben, welcher Firma sie gehört (z.B. ein "Firmenname"-Wasserzeichen), um den Autor der Präsentation zu identifizieren usw. Ein Wasserzeichen hilft, Urheberrechtsverletzungen zu verhindern, indem es anzeigt, dass die Präsentation nicht kopiert werden sollte. Wasserzeichen werden sowohl in PowerPoint- als auch in OpenOffice-Präsentationsformaten verwendet. In Aspose.Slides können Sie ein Wasserzeichen zu PowerPoint PPT, PPTX und OpenOffice ODP-Dateiformaten hinzufügen.

In [**Aspose.Slides**](https://products.aspose.com/slides/net/) gibt es verschiedene Möglichkeiten, Wasserzeichen in PowerPoint- oder OpenOffice-Dokumenten zu erstellen und deren Design und Verhalten zu ändern. Der gemeinsame Aspekt ist, dass zum Hinzufügen von Textwasserzeichen das [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) Interface verwendet werden sollte, und zum Hinzufügen von Bildwasserzeichen die [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) Klasse oder eine Wasserzeichenform mit einem Bild gefüllt werden sollte. `PictureFrame` implementiert das [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) Interface, wodurch Sie alle flexiblen Einstellungen des Formobjekts nutzen können. Da `ITextFrame` keine Form ist und seine Einstellungen begrenzt sind, wird es in ein [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) Objekt eingewickelt.

Es gibt zwei Möglichkeiten, ein Wasserzeichen anzuwenden: auf eine einzelne Folie oder auf alle Präsentationsfolien. Der Folienmaster wird verwendet, um ein Wasserzeichen auf alle Präsentationsfolien anzuwenden — das Wasserzeichen wird dem Folienmaster hinzugefügt, dort vollständig gestaltet und auf alle Folien angewendet, ohne das Recht zur Bearbeitung des Wasserzeichens auf einzelnen Folien zu beeinträchtigen.

Ein Wasserzeichen wird normalerweise als nicht verfügbar für die Bearbeitung durch andere Benutzer angesehen. Um zu verhindern, dass das Wasserzeichen (oder eher die übergeordnete Form des Wasserzeichens) bearbeitet wird, bietet Aspose.Slides eine Funktion zum Sperren von Formen an. Eine bestimmte Form kann auf einer normalen Folie oder auf einem Folienmaster gesperrt werden. Wenn die Wasserzeichenform auf dem Folienmaster gesperrt ist, wird sie auf allen Präsentationsfolien gesperrt.

Sie können dem Wasserzeichen einen Namen geben, damit Sie es in Zukunft, wenn Sie es löschen möchten, in den Formen der Folie nach Namen finden können.

Sie können das Wasserzeichen auf beliebige Weise gestalten; jedoch gibt es normalerweise gemeinsame Merkmale in Wasserzeichen, wie z.B. zentrierte Ausrichtung, Drehung, Vordergrundposition usw. Wir werden im Folgenden betrachten, wie man diese in den Beispielen verwendet.

## **Textwasserzeichen**

### **Fügen Sie ein Textwasserzeichen zu einer Folie hinzu**

Um ein Textwasserzeichen in PPT, PPTX oder ODP hinzuzufügen, können Sie zuerst eine Form zur Folie hinzufügen, dann einen Textbereich zu dieser Form hinzufügen. Der Textbereich wird durch das [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe) Interface dargestellt. Dieser Typ wird nicht von [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) abgeleitet, das eine breite Palette von Eigenschaften für die flexible Positionierung des Wasserzeichens hat. Daher wird das [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe) Objekt in ein [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) Objekt eingewickelt. Um dem Formen-Wasserzeichentext hinzuzufügen, verwenden Sie die [AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/methods/addtextframe) Methode wie unten gezeigt.

```cs
string watermarkText = "VERTRAULICH";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="primary" title="Siehe auch" %}} 
- [Wie man die TextFrame-Klasse verwendet](/slides/net/text-formatting/)
{{% /alert %}}

### **Fügen Sie ein Textwasserzeichen zu einer Präsentation hinzu**

Wenn Sie ein Textwasserzeichen zur gesamten Präsentation (d.h. zu allen Folien auf einmal) hinzufügen möchten, fügen Sie es zum [MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/) hinzu. Der Rest der Logik ist die gleiche wie beim Hinzufügen eines Wasserzeichens zu einer einzelnen Folie — erstellen Sie ein [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) Objekt und fügen Sie dann das Wasserzeichen mit der [AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/methods/addtextframe) Methode hinzu.

```cs
string watermarkText = "VERTRAULICH";

using Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.Masters[0];

IAutoShape watermarkShape = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="primary" title="Siehe auch" %}} 
- [Wie man den Folienmaster verwendet](/slides/net/slide-master/)
{{% /alert %}}

### **Setzen Sie die Transparenz der Wasserzeichenform**

Standardmäßig wird die rechteckige Form mit Füll- und Linienfarben gestaltet. Die folgenden Codezeilen machen die Form transparent.

```cs
watermarkShape.FillFormat.FillType = FillType.NoFill;
watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;
```

### **Setzen Sie die Schriftart für ein Textwasserzeichen**

Sie können die Schriftart des Textwasserzeichens wie unten gezeigt ändern.

```cs
IPortionFormat textFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
textFormat.LatinFont = new FontData("Arial");
textFormat.FontHeight = 50;
```

### **Setzen Sie die Textfarbe des Wasserzeichens**

Um die Farbe des Wasserzeichentextes einzustellen, verwenden Sie diesen Code:

```cs
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat;
fillFormat.FillType = FillType.Solid;
fillFormat.SolidFillColor.Color = Color.FromArgb(alpha, red, green, blue);
```

### **Zentrieren Sie ein Textwasserzeichen**

Es ist möglich, das Wasserzeichen auf einer Folie zu zentrieren, und dazu können Sie Folgendes tun:

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

### **Fügen Sie ein Bildwasserzeichen zu einer Präsentation hinzu**

Um ein Bildwasserzeichen zu einer Präsentationsfolie hinzuzufügen, können Sie Folgendes tun:

```cs
using FileStream imageStream = File.OpenRead("watermark.png");
IPPImage image = presentation.Images.AddImage(imageStream);

watermarkShape.FillFormat.FillType = FillType.Picture;
watermarkShape.FillFormat.PictureFillFormat.Picture.Image = image;
watermarkShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
```

## **Sperren Sie ein Wasserzeichen vor Bearbeitung**

Wenn es notwendig ist, zu verhindern, dass ein Wasserzeichen bearbeitet wird, verwenden Sie die [IAutoShape.ShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/properties/shapelock) Eigenschaft der Form. Mit dieser Eigenschaft können Sie die Form davor schützen, ausgewählt, in der Größe geändert, neu positioniert, mit anderen Elementen gruppiert, ihr Text aus der Bearbeitung gesperrt und vieles mehr zu werden:

```cs
// Sperren Sie die Wasserzeichenform vor Änderungen
watermarkShape.ShapeLock.SelectLocked = true;
watermarkShape.ShapeLock.SizeLocked = true;
watermarkShape.ShapeLock.TextLocked = true;
watermarkShape.ShapeLock.PositionLocked = true;
watermarkShape.ShapeLock.GroupingLocked = true;
```

## **Bringen Sie ein Wasserzeichen nach vorne**

In Aspose.Slides kann die Z-Reihenfolge von Formen über die [IShapeCollection.Reorder](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/reorder/#reorder) Methode festgelegt werden. Dazu müssen Sie diese Methode aus der Präsentationsfolienliste aufrufen und den Formreferenz und ihre Reihenfolgenummer in die Methode übergeben. Auf diese Weise ist es möglich, eine Form nach vorne zu bringen oder sie an die Rückseite der Folie zu senden. Diese Funktion ist besonders nützlich, wenn Sie ein Wasserzeichen vor die Präsentation setzen müssen:

```cs
int shapeCount = slide.Shapes.Count;
slide.Shapes.Reorder(shapeCount - 1, watermarkShape);
```

## **Setzen Sie die Wasserzeichenrotation**

Hier ist ein Codebeispiel, wie man die Drehung des Wasserzeichens anpasst, damit es diagonal über die Folie positioniert ist:

```cs
double diagonalAngle = Math.Atan((slideSize.Height / slideSize.Width)) * 180 / Math.PI;

watermarkShape.Rotation = (float)diagonalAngle;
```

## **Setzen Sie einen Namen für ein Wasserzeichen**

Aspose.Slides erlaubt es Ihnen, den Namen einer Form festzulegen. Anhand des Formnamens können Sie in Zukunft auf sie zugreifen, um sie zu modifizieren oder zu löschen. Um den Namen der Wasserzeichenform festzulegen, weisen Sie ihn der [IAutoShape.Name](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/name) Eigenschaft zu:

```cs
watermarkShape.Name = "wasserzeichen";
```

## **Entfernen Sie ein Wasserzeichen**

Um die Wasserzeichenform zu entfernen, verwenden Sie die [IAutoShape.Name](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/name) Eigenschaft, um sie in den Folienformen zu finden. Übergeben Sie dann die Wasserzeichenform in die [IShapeCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/remove/) Methode:

```cs
List<IShape> slideShapes = slide.Shapes.ToList();
foreach (IShape shape in slideShapes)
{
    if (string.Compare(shape.Name, "wasserzeichen", StringComparison.Ordinal) == 0)
    {
        slide.Shapes.Remove(watermarkShape);
    }
}
```

## **Ein Live-Beispiel**

Sie möchten möglicherweise die **Aspose.Slides kostenlos** [Wasserzeichen hinzufügen](https://products.aspose.app/slides/watermark) und [Wasserzeichen entfernen](https://products.aspose.app/slides/watermark/remove-watermark) Online-Tools überprüfen.

![Online-Tools zum Hinzufügen und Entfernen von Wasserzeichen](online_tools.png)