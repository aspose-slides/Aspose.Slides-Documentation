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
description: "Fügen Sie Text- und Bildwasserzeichen zu PowerPoint-Präsentationen in C# oder .NET hinzu"
---

## **Über Wasserzeichen**

**Ein Wasserzeichen** in einer Präsentation ist ein Text- oder Bildstempel, der auf einer Folie oder auf allen Folien der Präsentation verwendet wird. Üblicherweise wird ein Wasserzeichen verwendet, um anzuzeigen, dass die Präsentation ein Entwurf ist (z.B. ein "Entwurf"-Wasserzeichen), dass sie vertrauliche Informationen enthält (z.B. ein "Vertraulich"-Wasserzeichen), um anzugeben, zu welchem Unternehmen es gehört (z.B. ein "Unternehmensname"-Wasserzeichen), um den Autor der Präsentation zu identifizieren usw. Ein Wasserzeichen hilft, Urheberrechtsverletzungen zu verhindern, indem es angibt, dass die Präsentation nicht kopiert werden sollte. Wasserzeichen werden sowohl in PowerPoint- als auch in OpenOffice-Präsentationsformaten verwendet. In Aspose.Slides können Sie ein Wasserzeichen zu PowerPoint PPT-, PPTX- und OpenOffice ODP-Dateiformaten hinzufügen.

In [**Aspose.Slides**](https://products.aspose.com/slides/net/) gibt es verschiedene Möglichkeiten, Wasserzeichen in PowerPoint- oder OpenOffice-Dokumenten zu erstellen und ihr Design und Verhalten zu ändern. Der gemeinsame Aspekt ist, dass Sie zum Hinzufügen von Textwasserzeichen das [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) Interface verwenden sollten, und zum Hinzufügen von Bildwasserzeichen die [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) Klasse oder eine Wasserzeichenform mit einem Bild füllen. `PictureFrame` implementiert das [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) Interface, das es Ihnen ermöglicht, alle flexiblen Einstellungen des Formobjekts zu nutzen. Da `ITextFrame` keine Form ist und ihre Einstellungen begrenzt sind, wird es in einem [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) Objekt eingewickelt.

Es gibt zwei Möglichkeiten, wie ein Wasserzeichen angewendet werden kann: auf eine einzelne Folie oder auf alle Präsentationsfolien. Der Folienmaster wird verwendet, um ein Wasserzeichen auf alle Präsentationsfolien anzuwenden – das Wasserzeichen wird dem Folienmaster hinzugefügt, dort vollständig gestaltet und auf alle Folien angewendet, ohne das Recht zum Modifizieren des Wasserzeichens auf individuellen Folien zu beeinträchtigen.

Ein Wasserzeichen wird in der Regel als nicht verfügbar für die Bearbeitung durch andere Benutzer angesehen. Um zu verhindern, dass das Wasserzeichen (oder vielmehr die übergeordnete Form des Wasserzeichens) bearbeitet wird, bietet Aspose.Slides eine Funktion zum Sperren von Formen. Eine spezifische Form kann auf einer normalen Folie oder auf einem Folienmaster gesperrt werden. Wenn die Wasserzeichenform auf dem Folienmaster gesperrt ist, wird sie auf allen Präsentationsfolien gesperrt.

Sie können einen Namen für das Wasserzeichen festlegen, sodass Sie es in Zukunft, wenn Sie es löschen möchten, anhand des Namens in den Formen der Folie finden können.

Sie können das Wasserzeichen auf beliebige Weise gestalten; es gibt jedoch normalerweise gemeinsame Merkmale in Wasserzeichen, wie z.B. Zentrierung, Drehung, Vordergrundposition usw. Wir werden im Folgenden betrachten, wie man diese in den Beispielen verwendet.

## **Textwasserzeichen**

### **Textwasserzeichen zu einer Folie hinzufügen**

Um ein Textwasserzeichen in PPT, PPTX oder ODP hinzuzufügen, können Sie zuerst eine Form zur Folie hinzufügen, dann einen Textrahmen zu dieser Form hinzufügen. Der Textrahmen wird durch das [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe) Interface dargestellt. Dieser Typ erbt nicht von [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/), das eine breite Palette von Eigenschaften für die flexible Positionierung des Wasserzeichens hat. Daher wird das [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe) Objekt in einem [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) Objekt eingewickelt. Um den Wasserzeichentext zur Form hinzuzufügen, verwenden Sie die [AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/methods/addtextframe) Methode wie unten gezeigt.

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

### **Textwasserzeichen zu einer Präsentation hinzufügen**

Wenn Sie ein Textwasserzeichen zur gesamten Präsentation (d.h. zu allen Folien auf einmal) hinzufügen möchten, fügen Sie es dem [MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/) hinzu. Der Rest der Logik ist dieselbe wie beim Hinzufügen eines Wasserzeichens zu einer einzelnen Folie – erstellen Sie ein [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) Objekt und fügen Sie ihm das Wasserzeichen mit der [AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/methods/addtextframe) Methode hinzu.

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

### **Transparenz der Wasserzeichenform einstellen**

Standardmäßig ist die Rechteckform mit Füll- und Liniefarben gestaltet. Die folgenden Codezeilen machen die Form transparent.

```cs
watermarkShape.FillFormat.FillType = FillType.NoFill;
watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;
```

### **Die Schriftart für ein Textwasserzeichen einstellen**

Sie können die Schriftart des Textwasserzeichens wie unten gezeigt ändern.

```cs
IPortionFormat textFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
textFormat.LatinFont = new FontData("Arial");
textFormat.FontHeight = 50;
```

### **Die Textfarbe des Wasserzeichens einstellen**

Um die Farbe des Wasserzeichentextes einzustellen, verwenden Sie diesen Code:

```cs
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat;
fillFormat.FillType = FillType.Solid;
fillFormat.SolidFillColor.Color = Color.FromArgb(alpha, red, green, blue);
```

### **Ein Textwasserzeichen zentrieren**

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

### **Ein Bildwasserzeichen zu einer Präsentation hinzufügen**

Um ein Bildwasserzeichen zu einer Präsentationsfolie hinzuzufügen, können Sie Folgendes tun:

```cs
using FileStream imageStream = File.OpenRead("watermark.png");
IPPImage image = presentation.Images.AddImage(imageStream);

watermarkShape.FillFormat.FillType = FillType.Picture;
watermarkShape.FillFormat.PictureFillFormat.Picture.Image = image;
watermarkShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
```

## **Ein Wasserzeichen vor der Bearbeitung sperren**

Falls es notwendig ist, ein Wasserzeichen vor der Bearbeitung zu schützen, verwenden Sie die [IAutoShape.ShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/properties/shapelock) Eigenschaft auf der Form. Mit dieser Eigenschaft können Sie die Form vor Auswahl, Größenänderung, Neupositionierung, Gruppierung mit anderen Elementen, die Sperrung des Textes vor der Bearbeitung und vieles mehr schützen:

```cs
// Sperren Sie die Wasserzeichenform gegen Modifikationen
watermarkShape.ShapeLock.SelectLocked = true;
watermarkShape.ShapeLock.SizeLocked = true;
watermarkShape.ShapeLock.TextLocked = true;
watermarkShape.ShapeLock.PositionLocked = true;
watermarkShape.ShapeLock.GroupingLocked = true;
```

## **Ein Wasserzeichen nach vorne bringen**

In Aspose.Slides kann die Z-Ordnung von Formen über die [IShapeCollection.Reorder](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/reorder/#reorder) Methode festgelegt werden. Dazu müssen Sie diese Methode aus der Liste der Präsentationsfolien aufrufen und die Formreferenz sowie ihre Ordnungsnummer an die Methode übergeben. Auf diese Weise ist es möglich, eine Form nach vorne zu bringen oder sie nach hinten in die Folie zu senden. Diese Funktion ist besonders nützlich, wenn Sie ein Wasserzeichen vor der Präsentation platzieren müssen:

```cs
int shapeCount = slide.Shapes.Count;
slide.Shapes.Reorder(shapeCount - 1, watermarkShape);
```

## **Drehung des Wasserzeichens einstellen**

Hier ist ein Codebeispiel, wie die Drehung des Wasserzeichens angepasst werden kann, damit es diagonal über die Folie positioniert wird:

```cs
double diagonalAngle = Math.Atan((slideSize.Height / slideSize.Width)) * 180 / Math.PI;

watermarkShape.Rotation = (float)diagonalAngle;
```

## **Einen Namen für ein Wasserzeichen festlegen**

Aspose.Slides ermöglicht es Ihnen, den Namen einer Form festzulegen. Durch die Verwendung des Formnamens können Sie in Zukunft darauf zugreifen, um sie zu ändern oder zu löschen. Um den Namen der Wasserzeichenform festzulegen, weisen Sie ihn der [IAutoShape.Name](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/name) Eigenschaft zu:

```cs
watermarkShape.Name = "watermark";
```

## **Ein Wasserzeichen entfernen**

Um die Wasserzeichenform zu entfernen, verwenden Sie die [IAutoShape.Name](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/name) Eigenschaft, um sie in den Folienformen zu finden. Übergeben Sie dann die Wasserzeichenform in die [IShapeCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/remove/) Methode:

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

## **Ein Live-Beispiel**

Sie möchten möglicherweise die **Aspose.Slides kostenlose** [Wasserzeichen hinzufügen](https://products.aspose.app/slides/watermark) und [Wasserzeichen entfernen](https://products.aspose.app/slides/watermark/remove-watermark) Online-Tools ausprobieren.

![Online-Tools zum Hinzufügen und Entfernen von Wasserzeichen](online_tools.png)