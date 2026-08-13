---
title: Wasserzeichen zu Präsentationen unter Android hinzufügen
linktitle: Wasserzeichen
type: docs
weight: 40
url: /de/androidjava/watermark/
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
- Android
- Java
- Aspose.Slides
description: "Verwalten Sie Text- und Bildwasserzeichen in PowerPoint- und OpenDocument-Präsentationen unter Android in Java, um einen Entwurf, vertrauliche Informationen und mehr anzuzeigen."
---
## **Einleitung**

**Ein Wasserzeichen** in einer Präsentation ist ein Text‑ oder Bildstempel, der auf einer Folie oder auf allen Folien einer Präsentation verwendet wird. In der Regel wird ein Wasserzeichen genutzt, um anzuzeigen, dass die Präsentation ein Entwurf ist (z. B. ein „Entwurf“-Wasserzeichen), dass sie vertrauliche Informationen enthält (z. B. ein „Vertraulich“-Wasserzeichen), um anzugeben, zu welchem Unternehmen sie gehört (z. B. ein „Firmenname“-Wasserzeichen), um den Autor der Präsentation zu identifizieren usw. Ein Wasserzeichen hilft, Urheberrechtsverletzungen zu verhindern, indem es anzeigt, dass die Präsentation nicht kopiert werden darf. Wasserzeichen werden sowohl im PowerPoint‑ als auch im OpenOffice‑Präsentationsformat verwendet. In Aspose.Slides können Sie ein Wasserzeichen zu PowerPoint‑PPT, PPTX und OpenOffice‑ODP‑Dateiformaten hinzufügen.

In [**Aspose.Slides**](https://products.aspose.com/slides/de/android-java/), gibt es verschiedene Möglichkeiten, Wasserzeichen in PowerPoint‑ oder OpenOffice‑Dokumenten zu erstellen und ihr Design sowie Verhalten zu ändern. Der gemeinsame Aspekt ist, dass Sie zum Hinzufügen von Textwasserzeichen das [ITextFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframe/)-Interface verwenden sollten und zum Hinzufügen von Bildwasserzeichen die [PictureFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/pictureframe/)-Klasse oder das Befüllen einer Wasserzeichenform mit einem Bild. `PictureFrame` implementiert das [IShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/)-Interface, sodass Sie alle flexiblen Einstellungen des Formobjekts nutzen können. Da `ITextFrame` keine Form ist und seine Einstellungen begrenzt sind, wird es in ein [IShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/)-Objekt eingebettet.

Es gibt zwei Möglichkeiten, ein Wasserzeichen anzuwenden: auf einer einzelnen Folie oder auf allen Folien der Präsentation. Der Folienmaster wird verwendet, um ein Wasserzeichen auf alle Folien anzuwenden – das Wasserzeichen wird dem Folienmaster hinzugefügt, dort vollständig gestaltet und auf alle Folien angewendet, ohne die Möglichkeit zu beeinträchtigen, das Wasserzeichen auf einzelnen Folien zu ändern.

Ein Wasserzeichen wird in der Regel als für andere Benutzer nicht editierbar betrachtet. Um zu verhindern, dass das Wasserzeichen (bzw. die übergeordnete Form des Wasserzeichens) bearbeitet wird, bietet Aspose.Slides eine Form‑Sperrfunktion. Eine bestimmte Form kann auf einer normalen Folie oder auf einem Folienmaster gesperrt werden. Wird die Wasserzeichen‑Form auf dem Folienmaster gesperrt, ist sie auf allen Folien gesperrt.

Sie können dem Wasserzeichen einen Namen zuweisen, sodass Sie es später anhand des Namens in den Folienformen finden und löschen können.

Das Wasserzeichen kann nach Belieben gestaltet werden; üblicherweise weisen Wasserzeichen jedoch Merkmale wie zentrierte Ausrichtung, Drehung, Vordergrundposition usw. auf. In den folgenden Beispielen zeigen wir, wie diese Eigenschaften verwendet werden können.

## **Textwasserzeichen**

### **Ein Textwasserzeichen zu einer Folie hinzufügen**

Um ein Textwasserzeichen in PPT, PPTX oder ODP hinzuzufügen, können Sie zunächst eine Form zur Folie hinzufügen und anschließend einen Textbereich zu dieser Form. Der Textbereich wird durch das [ITextFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframe/)-Interface repräsentiert. Dieser Typ erbt nicht von [IShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/), das ein breites Set an Eigenschaften für die flexible Positionierung des Wasserzeichens bietet. Daher wird das [ITextFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframe/)-Objekt in ein [IAutoShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iautoshape/)-Objekt eingebettet. Um Text zum Wasserzeichen hinzuzufügen, verwenden Sie die [addTextFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-)‑Methode wie unten gezeigt.

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
- [Wie man die TextFrame‑Klasse verwendet](/slides/de/androidjava/text-formatting/)
{{% /alert %}}

### **Ein Textwasserzeichen zur gesamten Präsentation hinzufügen**

Wenn Sie ein Textwasserzeichen zur gesamten Präsentation (also zu allen Folien gleichzeitig) hinzufügen möchten, fügen Sie es dem [MasterSlide](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/masterslide/) hinzu. Der Rest der Logik entspricht dem Hinzufügen eines Wasserzeichens zu einer einzelnen Folie – Sie erstellen ein [IAutoShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iautoshape/)-Objekt und fügen das Wasserzeichen über die [addTextFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-)‑Methode hinzu.

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
- [Wie man den Folienmaster verwendet](/slides/de/androidjava/slide-master/)
{{% /alert %}}

### **Transparenz der Wasserzeichenform festlegen**

Standardmäßig ist die Rechteckform mit Füll‑ und Linienfarbe gestaltet. Die folgenden Codezeilen machen die Form transparent.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    watermarkShape.getFillFormat().setFillType(FillType.NoFill);
    watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
} finally {
    presentation.dispose();
}
```

### **Schriftart für ein Textwasserzeichen festlegen**

Sie können die Schriftart des Textwasserzeichens wie unten gezeigt ändern.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

    IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
    textFormat.setLatinFont(new FontData("Arial"));
    textFormat.setFontHeight(50);
} finally {
    presentation.dispose();
}
```

### **Farbe des Wasserzeichentextes festlegen**

Um die Farbe des Wasserzeichentextes festzulegen, verwenden Sie diesen Code:

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 150, red = 200, green = 200, blue = 200;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

    IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
    fillFormat.setFillType(FillType.Solid);
    fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));
} finally {
    presentation.dispose();
}
```

### **Ein Textwasserzeichen zentrieren**

Es ist möglich, das Wasserzeichen auf einer Folie zu zentrieren. Dazu können Sie Folgendes tun:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    float watermarkWidth = 400;
    float watermarkHeight = 40;
    float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
    float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

    IAutoShape watermarkShape = slide.getShapes().addAutoShape(
            ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

    ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);
} finally {
    presentation.dispose();
}
```

Das Bild unten zeigt das Endergebnis.

![The text watermark](text_watermark.png)

## **Bildwasserzeichen**

### **Ein Bildwasserzeichen zur Präsentation hinzufügen**

Um ein Bildwasserzeichen zu einer Präsentationsfolie hinzuzufügen, können Sie Folgendes ausführen:

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.InputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    InputStream imageStream = new FileInputStream("watermark.png");
    IPPImage image = presentation.getImages().addImage(imageStream);

    watermarkShape.getFillFormat().setFillType(FillType.Picture);
    watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
} finally {
    presentation.dispose();
}
```

### **Ein Wasserzeichen vor Bearbeitung schützen**

Falls es notwendig ist, ein Wasserzeichen vor dem Bearbeiten zu schützen, verwenden Sie die [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iautoshape/#getAutoShapeLock--)‑Methode auf der Form. Mit dieser Eigenschaft können Sie die Form davor schützen, ausgewählt, in der Größe geändert, neu positioniert, mit anderen Elementen gruppiert, ihr Text vor Bearbeitung gesperrt usw. zu werden:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    // Sperre die Wasserzeichenform vor Änderungen
    watermarkShape.getAutoShapeLock().setSelectLocked(true);
    watermarkShape.getAutoShapeLock().setSizeLocked(true);
    watermarkShape.getAutoShapeLock().setTextLocked(true);
    watermarkShape.getAutoShapeLock().setPositionLocked(true);
    watermarkShape.getAutoShapeLock().setGroupingLocked(true);
} finally {
    presentation.dispose();
}
```

### **Ein Wasserzeichen in den Vordergrund bringen**

In Aspose.Slides kann die Z‑Reihenfolge von Formen über die [IShapeCollection.reorder](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-)‑Methode festgelegt werden. Dazu rufen Sie diese Methode aus der Liste der Präsentationsfolien auf und übergeben die Formreferenz sowie deren Reihenfolgenummer. Auf diese Weise können Sie eine Form in den Vordergrund oder in den Hintergrund der Folie verschieben. Diese Funktion ist besonders nützlich, wenn Sie ein Wasserzeichen vor dem Rest der Präsentation platzieren möchten:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    int shapeCount = slide.getShapes().size();
    slide.getShapes().reorder(shapeCount - 1, watermarkShape);
} finally {
    presentation.dispose();
}
```

### **Wasserzeichen drehen**

Hier ein Codebeispiel, wie die Drehung des Wasserzeichens angepasst wird, sodass es diagonal über die Folie verläuft:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

    watermarkShape.setRotation((float)diagonalAngle);
} finally {
    presentation.dispose();
}
```

### **Einen Namen für ein Wasserzeichen festlegen**

Aspose.Slides ermöglicht das Festlegen eines Formnamens. Durch Verwendung des Formnamens können Sie später auf die Form zugreifen, um sie zu ändern oder zu löschen. Um den Namen der Wasserzeichen‑Form festzulegen, übergeben Sie ihn an die [IAutoShape.setName](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/#setName-java.lang.String-)‑Methode:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    watermarkShape.setName("watermark");
} finally {
    presentation.dispose();
}
```

### **Ein Wasserzeichen entfernen**

Um die Wasserzeichen‑Form zu entfernen, verwenden Sie die [IAutoShape.getName](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/#getName--)‑Methode, um sie in den Folienformen zu finden. Anschließend übergeben Sie die Wasserzeichen‑Form an die [IShapeCollection.remove](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-)‑Methode:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("watermarked.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape[] slideShapes = slide.getShapes().toArray();
    for (IShape shape : slideShapes) {
        if ("watermark".equals(shape.getName()))
        {
            slide.getShapes().remove(shape);
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

### Was ist ein Wasserzeichen und warum sollte ich es verwenden?

Ein Wasserzeichen ist eine Text‑ oder Bildüberlagerung, die auf Folien angewendet wird, um geistiges Eigentum zu schützen, die Markenbekanntheit zu erhöhen oder die unbefugte Nutzung von Präsentationen zu verhindern.

### Kann ich ein Wasserzeichen zu allen Folien einer Präsentation hinzufügen?

Ja, Aspose.Slides ermöglicht es Ihnen, programmgesteuert ein Wasserzeichen zu jeder Folie einer Präsentation hinzuzufügen. Sie können über alle Folien iterieren und die Wasserzeicheneinstellungen einzeln anwenden.

### Wie kann ich die Transparenz des Wasserzeichens anpassen?

Sie können die Transparenz des Wasserzeichens anpassen, indem Sie die Füll‑Einstellungen ([getFillFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/shape/#getFillFormat--)) der Form ändern. Auf diese Weise bleibt das Wasserzeichen dezent und lenkt nicht vom Folieninhalt ab.

### Welche Bildformate werden für Wasserzeichen unterstützt?

Aspose.Slides unterstützt verschiedene Bildformate wie PNG, JPEG, GIF, BMP, SVG und weitere.

### Kann ich die Schriftart und den Stil eines Textwasserzeichens anpassen?

Ja, Sie können jede Schriftart, Größe und jeden Stil wählen, um das Design Ihrer Präsentation zu entsprechen und die Marken­konsistenz zu wahren.

### Wie ändere ich die Position oder Ausrichtung eines Wasserzeichens?

Sie können die Position und Ausrichtung des Wasserzeichens programmgesteuert anpassen, indem Sie die Koordinaten, die Größe und die Drehungseigenschaften der Form modifizieren.