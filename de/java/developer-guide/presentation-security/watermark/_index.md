---
title: Wasserzeichen zu Präsentationen in Java hinzufügen
linktitle: Wasserzeichen
type: docs
weight: 40
url: /de/java/watermark/
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
- Java
- Aspose.Slides
description: "Verwalten Sie Text- und Bildwasserzeichen in PowerPoint- und OpenDocument-Präsentationen in Java, um einen Entwurf, vertrauliche Informationen, Urheberrechte und mehr anzuzeigen."
---
## **Einleitung**

**Ein Wasserzeichen** in einer Präsentation ist ein Text‑ oder Bildstempel, der auf einer Folie oder über alle Folien hinweg verwendet wird. Üblicherweise dient ein Wasserzeichen dazu, anzuzeigen, dass die Präsentation ein Entwurf ist (z. B. ein „Entwurf“-Wasserzeichen), vertrauliche Informationen enthält (z. B. ein „Vertraulich“-Wasserzeichen), zu welcher Firma sie gehört (z. B. ein „Firmenname“-Wasserzeichen), den Autor der Präsentation zu identifizieren usw. Ein Wasserzeichen hilft, Urheberrechtsverletzungen zu verhindern, indem es anzeigt, dass die Präsentation nicht kopiert werden darf. Wasserzeichen werden sowohl in PowerPoint‑ als auch in OpenOffice‑Präsentationsformaten verwendet. In Aspose.Slides können Sie ein Wasserzeichen zu PowerPoint‑PPT, PPTX und OpenOffice‑ODP‑Dateiformaten hinzufügen.

In [**Aspose.Slides**](https://products.aspose.com/slides/de/java/) gibt es verschiedene Möglichkeiten, Wasserzeichen in PowerPoint‑ oder OpenOffice‑Dokumenten zu erstellen und deren Design sowie Verhalten zu ändern. Der gemeinsame Aspekt ist, dass Sie zum Hinzufügen von Textwasserzeichen die [ITextFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/)-Schnittstelle verwenden sollten und zum Hinzufügen von Bildwasserzeichen die [PictureFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/pictureframe/)-Klasse oder das Füllen einer Wasserzeichnungsform mit einem Bild. `PictureFrame` implementiert die [IShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/)-Schnittstelle, wodurch Sie alle flexiblen Einstellungen des Formobjekts nutzen können. Da `ITextFrame` keine Form ist und seine Einstellungen begrenzt sind, wird sie in ein [IShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/)-Objekt eingepackt.

Ein Wasserzeichen kann auf zwei Arten angewendet werden: auf einer einzelnen Folie oder auf allen Folien der Präsentation. Der Folien‑Master wird verwendet, um ein Wasserzeichen auf allen Folien anzuwenden — das Wasserzeichen wird zum Folien‑Master hinzugefügt, dort vollständig gestaltet und anschließend auf alle Folien angewendet, ohne die Möglichkeit zu beeinträchtigen, das Wasserzeichen auf einzelnen Folien zu ändern.

Ein Wasserzeichen wird in der Regel als für andere Benutzer nicht bearbeitbar angesehen. Um zu verhindern, dass das Wasserzeichen (oder genauer gesagt die übergeordnete Form des Wasserzeichens) bearbeitet wird, bietet Aspose.Slides eine Form‑Sperrfunktion. Eine bestimmte Form kann auf einer normalen Folie oder auf einem Folien‑Master gesperrt werden. Wird die Wasserzeichnungsform auf dem Folien‑Master gesperrt, ist sie auf allen Folien gesperrt.

Sie können dem Wasserzeichen einen Namen zuweisen, sodass Sie es später anhand dieses Namens in den Formen der Folie finden und ggf. löschen können.

Sie können das Wasserzeichen nach Belieben gestalten; typischerweise weisen Wasserzeichen jedoch gemeinsame Merkmale wie zentrierte Ausrichtung, Drehung, Vordergrundposition usw. auf. Im Folgenden sehen Sie, wie diese Aspekte in den Beispielen verwendet werden.

## **Textwasserzeichen**

### **Ein Textwasserzeichen zu einer Folie hinzufügen**

Um ein Textwasserzeichen in PPT, PPTX oder ODP hinzuzufügen, können Sie zunächst eine Form zur Folie hinzufügen und anschließend dieser Form einen Textrahmen zuweisen. Der Textrahmen wird durch die [ITextFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/)-Schnittstelle repräsentiert. Dieser Typ erbt nicht von [IShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/), das eine Vielzahl von Eigenschaften zur flexiblen Positionierung des Wasserzeichens bietet. Daher wird das [ITextFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/)-Objekt in ein [IAutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/iautoshape/)-Objekt eingepackt. Um dem Shape Textwasserzeichen hinzuzufügen, verwenden Sie die [addTextFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-)‑Methode wie unten gezeigt.

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="Siehe auch" %}} 
- [Wie die TextFrame‑Klasse verwendet wird](/slides/de/java/text-formatting/)
{{% /alert %}}

### **Ein Textwasserzeichen zur gesamten Präsentation hinzufügen**

Wenn Sie ein Textwasserzeichen zur gesamten Präsentation (d. h. zu allen Folien auf einmal) hinzufügen möchten, fügen Sie es dem [MasterSlide](https://reference.aspose.com/slides/de/java/com.aspose.slides/masterslide/) hinzu. Der Rest der Logik ist identisch zum Hinzufügen eines Wasserzeichens zu einer einzelnen Folie — erzeugen Sie ein [IAutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/iautoshape/)-Objekt und fügen Sie anschließend das Wasserzeichen mit der [addTextFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-)‑Methode hinzu.

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="Siehe auch" %}} 
- [Wie der Folien‑Master verwendet wird](/slides/de/java/slide-master/)
{{% /alert %}}

### **Transparenz der Wasserzeichnungsform festlegen**

Standardmäßig ist die Rechteckform mit Füll‑ und Linienfarben versehen. Die folgenden Codezeilen machen die Form transparent.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

presentation.dispose();
```

### **Schriftart für ein Textwasserzeichen festlegen**

Sie können die Schriftart des Textwasserzeichens wie folgt ändern.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);

presentation.dispose();
```

### **Farbe des Wasserzeichentextes festlegen**

Um die Farbe des Wasserzeichentextes zu setzen, verwenden Sie diesen Code:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));

presentation.dispose();
```

### **Ein Textwasserzeichen zentrieren**

Es ist möglich, das Wasserzeichen auf einer Folie zu zentrieren; dafür können Sie Folgendes tun:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

Dimension2D slideSize = presentation.getSlideSize().getSize();

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.getShapes().addAutoShape(
        ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

Das Bild unten zeigt das Endergebnis.

![Das Textwasserzeichen](text_watermark.png)

## **Bildwasserzeichen**

### **Ein Bildwasserzeichen zur Präsentation hinzufügen**

Um ein Bildwasserzeichen zu einer Präsentationsfolie hinzuzufügen, können Sie Folgendes tun:

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.InputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

presentation.dispose();
```

### **Ein Wasserzeichen vor Bearbeitung schützen**

Wenn es erforderlich ist, ein Wasserzeichen vor Bearbeitung zu schützen, verwenden Sie die [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/de/java/com.aspose.slides/iautoshape/#getAutoShapeLock--)‑Methode auf der Form. Mit dieser Eigenschaft können Sie die Form davor schützen, ausgewählt, in der Größe verändert, verschoben, mit anderen Elementen gruppiert, der Text gesperrt usw. zu werden:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

// Sperre die Wasserzeichenform vor Änderungen
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);

presentation.dispose();
```

### **Ein Wasserzeichen in den Vordergrund bringen**

In Aspose.Slides kann die Z‑Reihenfolge von Formen über die [IShapeCollection.reorder](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-)‑Methode festgelegt werden. Dazu rufen Sie diese Methode aus der Präsentations‑Folienliste auf und übergeben die Formreferenz sowie ihre Reihenfolgenummer. Auf diese Weise lässt sich eine Form nach vorne oder nach hinten verschieben. Diese Funktion ist besonders nützlich, wenn Sie ein Wasserzeichen vor dem Rest der Präsentation platzieren möchten:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);

presentation.dispose();
```

### **Wasserzeichen drehen**

Hier ein Codebeispiel, wie Sie die Drehung des Wasserzeichens anpassen, sodass es diagonal über die Folie verläuft:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

Dimension2D slideSize = presentation.getSlideSize().getSize();

double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);

presentation.dispose();
```

### **Einen Namen für ein Wasserzeichen festlegen**

Aspose.Slides ermöglicht das Festlegen eines Formnamens. Mit dem Formnamen können Sie die Form später wiederfinden, um sie zu ändern oder zu löschen. Um den Namen der Wasserzeichnungsform festzulegen, rufen Sie die [IAutoShape.setName](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/#setName-java.lang.String-)‑Methode auf:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.setName("watermark");

presentation.dispose();
```

### **Ein Wasserzeichen entfernen**

Um die Wasserzeichnungsform zu entfernen, verwenden Sie die [IAutoShape.getName](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/#getName--)‑Methode, um sie in den Folienformen zu finden. Anschließend übergeben Sie die Form an die [IShapeCollection.remove](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-)‑Methode:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

IShape[] slideShapes = slide.getShapes().toArray();
for (IShape shape : slideShapes) {
    if ("watermark".equals(shape.getName()))
    {
        slide.getShapes().remove(shape);
    }
}

presentation.dispose();
```

## **FAQ**

### Was ist ein Wasserzeichen und warum sollte ich es verwenden?

Ein Wasserzeichen ist ein Text‑ oder Bildüberlagerung, die auf Folien angewendet wird, um geistiges Eigentum zu schützen, die Markenbekanntheit zu steigern oder die unbefugte Nutzung von Präsentationen zu verhindern.

### Kann ich ein Wasserzeichen zu allen Folien einer Präsentation hinzufügen?

Ja, Aspose.Slides ermöglicht es, programmatisch ein Wasserzeichen zu jeder Folie einer Präsentation hinzuzufügen. Sie können über alle Folien iterieren und die Wasserzeicheneinstellungen einzeln anwenden.

### Wie kann ich die Transparenz des Wasserzeichens anpassen?

Sie können die Transparenz des Wasserzeichens ändern, indem Sie die Fülleinstellungen ([getFillFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/shape/#getFillFormat--)) der Form anpassen. So bleibt das Wasserzeichen dezent und lenkt nicht vom Folieninhalt ab.

### Welche Bildformate werden für Wasserzeichen unterstützt?

Aspose.Slides unterstützt verschiedene Bildformate wie PNG, JPEG, GIF, BMP, SVG und weitere.

### Kann ich die Schriftart und den Stil eines Textwasserzeichens anpassen?

Ja, Sie können jede Schriftart, Größe und jeden Stil wählen, um das Design Ihrer Präsentation und die Marken‑Konsistenz zu wahren.

### Wie ändere ich die Position oder Ausrichtung eines Wasserzeichens?

Sie können die Position und Ausrichtung des Wasserzeichens programmgesteuert ändern, indem Sie die Koordinaten, Größe und Drehungseigenschaften der Form anpassen.