---
title: Wasserzeichen zu Präsentationen auf Android hinzufügen
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
description: "Verwalten Sie Text- und Bildwasserzeichen in PowerPoint- und OpenDocument-Präsentationen auf Android in Java, um einen Entwurf, vertrauliche Informationen und mehr anzuzeigen."
---

## **Über Wasserzeichen**

**Ein Wasserzeichen** in einer Präsentation ist ein Text‑ oder Bildstempel, der auf einer Folie oder über alle Folien einer Präsentation hinweg verwendet wird. In der Regel wird ein Wasserzeichen verwendet, um anzuzeigen, dass die Präsentation ein Entwurf ist (z. B. ein „Draft“-Wasserzeichen), dass sie vertrauliche Informationen enthält (z. B. ein „Confidential“-Wasserzeichen), um anzugeben, zu welchem Unternehmen sie gehört (z. B. ein „Company Name“-Wasserzeichen), um den Autor der Präsentation zu identifizieren usw. Ein Wasserzeichen hilft, Urheberrechtsverletzungen zu verhindern, indem es anzeigt, dass die Präsentation nicht kopiert werden darf. Wasserzeichen werden sowohl in PowerPoint‑ als auch in OpenOffice‑Präsentationsformaten verwendet. In Aspose.Slides können Sie ein Wasserzeichen zu PowerPoint‑PPT-, PPTX‑ und OpenOffice‑ODP‑Dateiformaten hinzufügen.

In [**Aspose.Slides**](https://products.aspose.com/slides/android-java/) gibt es verschiedene Möglichkeiten, Wasserzeichen in PowerPoint‑ oder OpenOffice‑Dokumenten zu erstellen und deren Design und Verhalten zu ändern. Der gemeinsame Aspekt ist, dass Sie zum Hinzufügen von Textwasserzeichen das [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/)‑Interface verwenden sollten und zum Hinzufügen von Bildwasserzeichen die [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/)‑Klasse oder das Füllen einer Wasserzeichenform mit einem Bild nutzen. `PictureFrame` implementiert das [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/)‑Interface, sodass Sie alle flexiblen Einstellungen des Formobjekts verwenden können. Da `ITextFrame` keine Form ist und seine Einstellungen begrenzt sind, wird es in ein [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/)‑Objekt eingewickelt.

Es gibt zwei Methoden, ein Wasserzeichen anzuwenden: auf einer einzelnen Folie oder auf allen Folien der Präsentation. Der Folienmaster wird verwendet, um ein Wasserzeichen auf alle Folien anzuwenden – das Wasserzeichen wird dem Folienmaster hinzugefügt, dort vollständig gestaltet und auf alle Folien angewendet, ohne die Möglichkeit zu beeinträchtigen, das Wasserzeichen auf einzelnen Folien zu bearbeiten.

Ein Wasserzeichen gilt in der Regel als für andere Benutzer nicht bearbeitbar. Um zu verhindern, dass das Wasserzeichen (bzw. die übergeordnete Form des Wasserzeichens) bearbeitet wird, bietet Aspose.Slides eine Form‑Sperrfunktion. Eine bestimmte Form kann auf einer normalen Folie oder auf einem Folienmaster gesperrt werden. Wenn die Wasserzeichenform auf dem Folienmaster gesperrt ist, ist sie auf allen Folien der Präsentation gesperrt.

Sie können dem Wasserzeichen einen Namen zuweisen, sodass Sie es später, wenn Sie es löschen möchten, über den Namen in den Formen der Folie finden können.

Sie können das Wasserzeichen nach Belieben gestalten; jedoch gibt es in der Regel gemeinsame Merkmale von Wasserzeichen, wie zentrierte Ausrichtung, Drehung, Vordergrundposition usw. Wir werden im Folgenden zeigen, wie diese in den Beispielen verwendet werden können.

## **Textwasserzeichen**

### **Ein Textwasserzeichen zu einer Folie hinzufügen**

Um ein Textwasserzeichen in PPT, PPTX oder ODP hinzuzufügen, können Sie zunächst eine Form zur Folie hinzufügen und dann dieser Form einen Textframe hinzufügen. Der Textframe wird durch das [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/)‑Interface dargestellt. Dieser Typ erbt nicht von [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/), das über einen großen Satz von Eigenschaften zur flexiblen Positionierung des Wasserzeichens verfügt. Daher wird das [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/)‑Objekt in ein [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/)‑Objekt eingewickelt. Um dem Shape Text für das Wasserzeichen hinzuzufügen, verwenden Sie die Methode [addTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) wie unten gezeigt.
```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```


{{% alert color="primary" title="Siehe auch" %}} 
- [Wie man die TextFrame‑Klasse verwendet](/slides/de/androidjava/text-formatting/)
{{% /alert %}}

### **Ein Textwasserzeichen zu einer Präsentation hinzufügen**

Wenn Sie ein Textwasserzeichen zur gesamten Präsentation hinzufügen möchten (d. h. alle Folien auf einmal), fügen Sie es dem [MasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/masterslide/) hinzu. Der Rest der Logik ist derselbe wie beim Hinzufügen eines Wasserzeichens zu einer einzelnen Folie – erstellen Sie ein [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/)‑Objekt und fügen Sie das Wasserzeichen anschließend mit der Methode [addTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) hinzu.
```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```


{{% alert color="primary" title="Siehe auch" %}} 
- [Wie man den Folienmaster verwendet](/slides/de/androidjava/slide-master/)
{{% /alert %}}

### **Transparenz der Wasserzeichenform festlegen**

Standardmäßig ist die Rechteckform mit Füll‑ und Linienfarben formatiert. Die folgenden Codezeilen machen die Form transparent.
```java
watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
```


### **Schriftart für ein Textwasserzeichen festlegen**

Sie können die Schriftart des Textwasserzeichens wie unten gezeigt ändern.
```java
IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);
```


### **Farbe des Wasserzeichnungstextes festlegen**

Um die Farbe des Wasserzeichnungstextes festzulegen, verwenden Sie diesen Code:
```java
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(Color.argb(alpha, red, green, blue));
```


### **Ein Textwasserzeichen zentrieren**

Es ist möglich, das Wasserzeichen auf einer Folie zu zentrieren; dazu können Sie Folgendes tun:
```java
SizeF slideSize = presentation.getSlideSize().getSize();

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.getShapes().addAutoShape(
        ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```


![Das Textwasserzeichen](text_watermark.png)

## **Bildwasserzeichen**

### **Ein Bildwasserzeichen zu einer Präsentation hinzufügen**

Um ein Bildwasserzeichen zu einer Präsentationsfolie hinzuzufügen, können Sie Folgendes tun:
```java
InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
```


### **Ein Wasserzeichen vor Bearbeitung sperren**

Falls es notwendig ist, ein Wasserzeichen vor einer Bearbeitung zu schützen, verwenden Sie die Methode [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#getAutoShapeLock--) auf der Form. Mit dieser Eigenschaft können Sie die Form davor schützen, ausgewählt, in der Größe geändert, neu positioniert, mit anderen Elementen gruppiert, ihr Text vor Bearbeitung gesperrt zu werden und vieles mehr:
```java
// Sperre die Wasserzeichenform vor Änderungen
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);
```


### **Ein Wasserzeichen nach vorne bringen**

In Aspose.Slides kann die Z‑Reihenfolge von Formen über die Methode [IShapeCollection.reorder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) festgelegt werden. Dazu müssen Sie diese Methode aus der Liste der Präsentationsfolien aufrufen und die Formreferenz sowie deren Ordnungsnummer übergeben. Auf diese Weise kann eine Form nach vorne bzw. nach hinten verschoben werden. Diese Funktion ist besonders nützlich, wenn Sie ein Wasserzeichen vor die Präsentation stellen müssen:
```java
int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```


### **Drehung des Wasserzeichens festlegen**

Hier ein Codebeispiel, wie Sie die Drehung des Wasserzeichens anpassen können, sodass es diagonal über die Folie positioniert wird:
```java
double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);
```


### **Einen Namen für ein Wasserzeichen festlegen**

Aspose.Slides ermöglicht es, den Namen einer Form festzulegen. Durch die Verwendung des Formnamens können Sie später darauf zugreifen, um sie zu ändern oder zu löschen. Um den Namen der Wasserzeichenform festzulegen, weisen Sie ihn der Methode [IAutoShape.setName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setName-java.lang.String-) zu:
```java
watermarkShape.setName("watermark");
```


### **Ein Wasserzeichen entfernen**

Um die Wasserzeichenform zu entfernen, verwenden Sie die Methode [IAutoShape.getName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getName--) , um sie in den Folienformen zu finden. Anschließend übergeben Sie die Wasserzeichenform an die Methode [IShapeCollection.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-):
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

**Was ist ein Wasserzeichen und warum sollte ich es verwenden?**

Ein Wasserzeichen ist ein Text‑ oder Bildüberlagerung, die auf Folien angewendet wird und dazu dient, geistiges Eigentum zu schützen, die Markenbekanntheit zu erhöhen oder die unbefugte Nutzung von Präsentationen zu verhindern.

**Kann ich ein Wasserzeichen zu allen Folien einer Präsentation hinzufügen?**

Ja, Aspose.Slides ermöglicht es, programmgesteuert ein Wasserzeichen zu jeder Folie einer Präsentation hinzuzufügen. Sie können durch alle Folien iterieren und die Wasserzeicheneinstellungen einzeln anwenden.

**Wie kann ich die Transparenz des Wasserzeichens anpassen?**

Sie können die Transparenz des Wasserzeichens anpassen, indem Sie die Füllformat‑Einstellungen ([getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getFillFormat--)) der Form ändern. Dadurch wird das Wasserzeichen dezent und lenkt nicht von den Folieninhalten ab.

**Welche Bildformate werden für Wasserzeichen unterstützt?**

Aspose.Slides unterstützt verschiedene Bildformate wie PNG, JPEG, GIF, BMP, SVG und weitere.

**Kann ich die Schriftart und den Stil eines Textwasserzeichens anpassen?**

Ja, Sie können jede Schriftart, Größe und Stil wählen, um das Design Ihrer Präsentation anzupassen und die Marken‑konsistenz zu wahren.

**Wie ändere ich die Position oder Ausrichtung eines Wasserzeichens?**

Sie können die Position und Ausrichtung des Wasserzeichens programmgesteuert ändern, indem Sie die Koordinaten, Größe und Drehungseigenschaften der Form anpassen.