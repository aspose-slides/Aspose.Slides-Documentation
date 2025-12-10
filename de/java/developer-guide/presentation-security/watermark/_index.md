---
title: Wasserzeichen zu Präsentationen in Java hinzufügen
linktitle: Wasserzeichen
type: docs
weight: 40
url: /de/java/watermark/
keywords:
- Wasserzeichen
- Text-Wasserzeichen
- Bild-Wasserzeichen
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

## **Über Wasserzeichen**

**Ein Wasserzeichen** in einer Präsentation ist ein Text‑ oder Bildstempel, der auf einer Folie oder über alle Folien einer Präsentation hinweg verwendet wird. Üblicherweise wird ein Wasserzeichen eingesetzt, um anzuzeigen, dass die Präsentation ein Entwurf ist (z. B. ein „Draft“-Wasserzeichen), dass sie vertrauliche Informationen enthält (z. B. ein „Confidential“-Wasserzeichen), um anzugeben, zu welchem Unternehmen sie gehört (z. B. ein „Company Name“-Wasserzeichen), den Autor der Präsentation zu identifizieren usw. Ein Wasserzeichen hilft, Urheberrechtsverletzungen zu verhindern, indem es anzeigt, dass die Präsentation nicht kopiert werden darf. Wasserzeichen werden sowohl in PowerPoint‑ als auch in OpenOffice‑Präsentationsformaten verwendet. In Aspose.Slides können Sie ein Wasserzeichen zu PowerPoint‑PPT, PPTX und OpenOffice‑ODP‑Dateiformaten hinzufügen.

In [**Aspose.Slides**](https://products.aspose.com/slides/java/) gibt es verschiedene Möglichkeiten, Wasserzeichen in PowerPoint‑ oder OpenOffice‑Dokumenten zu erstellen und deren Design sowie Verhalten zu ändern. Der gemeinsame Aspekt ist, dass Sie zum Hinzufügen von Text‑Wasserzeichen die Schnittstelle [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) verwenden sollten und zum Hinzufügen von Bild‑Wasserzeichen die Klasse [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) oder das Füllen einer Wasserzeichen‑Form mit einem Bild nutzen. `PictureFrame` implementiert die Schnittstelle [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) und ermöglicht die Verwendung aller flexiblen Einstellungen des Form‑Objekts. Da `ITextFrame` keine Form ist und seine Einstellungen eingeschränkt sind, wird es in ein [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/)‑Objekt eingebettet.

Es gibt zwei Möglichkeiten, ein Wasserzeichen anzuwenden: auf einer einzelnen Folie oder auf allen Folien einer Präsentation. Der Folienmaster wird verwendet, um ein Wasserzeichen auf alle Folien einer Präsentation anzuwenden – das Wasserzeichen wird dem Folienmaster hinzugefügt, dort vollständig gestaltet und auf alle Folien angewendet, ohne die Möglichkeit zu beeinträchtigen, das Wasserzeichen auf einzelnen Folien zu ändern.

Ein Wasserzeichen wird in der Regel als nicht editierbar für andere Benutzer angesehen. Um zu verhindern, dass das Wasserzeichen (bzw. die übergeordnete Form des Wasserzeichens) bearbeitet wird, bietet Aspose.Slides eine Form‑Sperrfunktionalität. Eine bestimmte Form kann auf einer normalen Folie oder auf einem Folienmaster gesperrt werden. Wird die Wasserzeichen‑Form auf dem Folienmaster gesperrt, ist sie auf allen Folien der Präsentation gesperrt.

Sie können dem Wasserzeichen einen Namen zuweisen, sodass Sie es später, wenn Sie es löschen möchten, anhand des Namens in den Folienformen finden können.

Sie können das Wasserzeichen nach Belieben gestalten; es gibt jedoch üblicherweise gemeinsame Merkmale von Wasserzeichen, wie z. B. zentrierte Ausrichtung, Drehung, Vordergrundposition usw. Wir werden nachfolgend in den Beispielen zeigen, wie diese verwendet werden.

## **Text‑Wasserzeichen**

### **Text‑Wasserzeichen zu einer Folie hinzufügen**

Um ein Text‑Wasserzeichen in PPT, PPTX oder ODP hinzuzufügen, können Sie zunächst eine Form zur Folie hinzufügen und anschließend einen Text‑Frame zu dieser Form. Der Text‑Frame wird durch die Schnittstelle [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) repräsentiert. Dieser Typ erbt nicht von [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/), das über einen umfangreichen Satz von Eigenschaften zur flexiblen Positionierung des Wasserzeichens verfügt. Daher wird das [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/)‑Objekt in ein [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/)‑Objekt eingebettet. Um dem Shape Text‑Wasserzeichen hinzuzufügen, verwenden Sie die Methode [addTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) wie unten gezeigt.
```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```


{{% alert color="primary" title="Siehe auch" %}} 
- [Verwendung der TextFrame-Klasse](/slides/de/java/text-formatting/)
{{% /alert %}}

### **Text‑Wasserzeichen einer Präsentation hinzufügen**

Wenn Sie ein Text‑Wasserzeichen zur gesamten Präsentation hinzufügen möchten (d. h. alle Folien auf einmal), fügen Sie es dem [MasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/masterslide/) hinzu. Der restliche Ablauf ist derselbe wie beim Hinzufügen eines Wasserzeichens zu einer einzelnen Folie – erstellen Sie ein [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/)‑Objekt und fügen Sie das Wasserzeichen mithilfe der Methode [addTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) hinzu.
```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```


{{% alert color="primary" title="Siehe auch" %}} 
- [Verwendung des Folienmasters](/slides/de/java/slide-master/)
{{% /alert %}}

### **Transparenz der Wasserzeichen‑Form festlegen**

Standardmäßig ist die Rechteck‑Form mit Füll‑ und Linienfarben formatiert. Die folgenden Codezeilen machen die Form transparent.
```java
watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
```


### **Schriftart für ein Text‑Wasserzeichen festlegen**

Sie können die Schriftart des Text‑Wasserzeichens wie unten gezeigt ändern.
```java
IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);
```


### **Farbe des Wasserzeichen‑Textes festlegen**

Um die Farbe des Wasserzeichen‑Textes festzulegen, verwenden Sie folgenden Code:
```java
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));
```


### **Text‑Wasserzeichen zentrieren**

Es ist möglich, das Wasserzeichen auf einer Folie zu zentrieren; dazu können Sie Folgendes tun:
```java
Dimension2D slideSize = presentation.getSlideSize().getSize();

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.getShapes().addAutoShape(
        ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```


![Das Text‑Wasserzeichen](text_watermark.png)

## **Bild‑Wasserzeichen**

### **Bild‑Wasserzeichen einer Präsentation hinzufügen**

Um ein Bild‑Wasserzeichen zu einer Präsentationsfolie hinzuzufügen, können Sie Folgendes tun:
```java
InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
```


### **Ein Wasserzeichen vor Bearbeitung sperren**

Falls es erforderlich ist, ein Wasserzeichen vor Bearbeitung zu schützen, verwenden Sie die Methode [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#getAutoShapeLock--) an der Form. Mit dieser Eigenschaft können Sie die Form davor schützen, ausgewählt, in der Größe geändert, neu positioniert, mit anderen Elementen gruppiert, ihr Text vor Bearbeitung gesperrt und vieles mehr zu werden:
```java
// Sperre die Wasserzeichen-Form vor Änderungen
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);
```


### **Wasserzeichen in den Vordergrund bringen**

In Aspose.Slides kann die Z‑Reihenfolge von Formen über die Methode [IShapeCollection.reorder](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) festgelegt werden. Dazu rufen Sie diese Methode aus der Folienliste der Präsentation auf und übergeben die Formreferenz sowie deren Reihenfolgenummer. So lässt sich eine Form in den Vordergrund oder in den Hintergrund der Folie verschieben. Diese Funktion ist besonders nützlich, wenn Sie ein Wasserzeichen vor der Präsentation platzieren möchten:
```java
int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```


### **Wasserzeichen‑Drehung festlegen**

Hier ist ein Codebeispiel, wie Sie die Drehung des Wasserzeichens anpassen können, sodass es diagonal über die Folie positioniert wird:
```java
double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);
```


### **Einen Namen für ein Wasserzeichen festlegen**

Aspose.Slides ermöglicht das Festlegen eines Namens für eine Form. Durch die Verwendung des Formnamens können Sie später auf die Form zugreifen, um sie zu ändern oder zu löschen. Um den Namen der Wasserzeichen‑Form festzulegen, übergeben Sie ihn an die Methode [IAutoShape.setName](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setName-java.lang.String-):
```java
watermarkShape.setName("watermark");
```


### **Ein Wasserzeichen entfernen**

Um die Wasserzeichen‑Form zu entfernen, verwenden Sie die Methode [IAutoShape.getName](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getName--) um sie in den Folienformen zu finden. Anschließend übergeben Sie die Wasserzeichen‑Form an die Methode [IShapeCollection.remove](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-):
```java
IShape[] slideShapes = slide.getShapes().toArray();
for (IShape shape : slideShapes) {
    if ("watermark".equals(shape.getName()))
    {
        slide.getShapes().remove(watermarkShape);
    }
}
```


## **FAQ**

**Was ist ein Wasserzeichen und warum sollte ich es benutzen?**

Ein Wasserzeichen ist eine Text‑ oder Bildüberlagerung, die auf Folien angewendet wird und dazu beiträgt, geistiges Eigentum zu schützen, die Markenbekanntheit zu steigern oder die unbefugte Nutzung von Präsentationen zu verhindern.

**Kann ich ein Wasserzeichen zu allen Folien einer Präsentation hinzufügen?**

Ja, Aspose.Slides ermöglicht es, programmgesteuert ein Wasserzeichen zu jeder Folie einer Präsentation hinzuzufügen. Sie können durch alle Folien iterieren und die Wasserzeichen‑Einstellungen einzeln anwenden.

**Wie kann ich die Transparenz des Wasserzeichens anpassen?**

Sie können die Transparenz des Wasserzeichens anpassen, indem Sie die Füll‑Einstellungen ([getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getFillFormat--)) der Form ändern. Dadurch wird das Wasserzeichen dezent und lenkt nicht vom Folieninhalt ab.

**Welche Bildformate werden für Wasserzeichen unterstützt?**

Aspose.Slides unterstützt verschiedene Bildformate wie PNG, JPEG, GIF, BMP, SVG und weitere.

**Kann ich die Schriftart und den Stil eines Text‑Wasserzeichens anpassen?**

Ja, Sie können jede Schriftart, Größe und Stil wählen, um das Design Ihrer Präsentation anzupassen und die Markenkonsistenz zu wahren.

**Wie ändere ich die Position oder Ausrichtung eines Wasserzeichens?**

Sie können die Position und Ausrichtung des Wasserzeichens programmgesteuert anpassen, indem Sie die Koordinaten, Größe und Drehung der Form ändern.