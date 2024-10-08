---
title: Wasserzeichen
type: docs
weight: 40
url: /java/watermark/
keywords:
- wasserzeichen
- wasserzeichen hinzufügen
- textwasserzeichen
- bildwasserzeichen
- PowerPoint
- präsentation
- Java
- Aspose.Slides für Java
description: "Fügen Sie Text- und Bildwasserzeichen zu PowerPoint-Präsentationen in Java hinzu"
---

## **Über Wasserzeichen**

**Ein Wasserzeichen** in einer Präsentation ist ein Text- oder Bildstempel, der auf einer Folie oder in allen Folien der Präsentation verwendet wird. In der Regel wird ein Wasserzeichen verwendet, um anzuzeigen, dass die Präsentation ein Entwurf ist (z.B. ein "Entwurf"-Wasserzeichen), dass sie vertrauliche Informationen enthält (z.B. ein "Vertraulich"-Wasserzeichen), um anzugeben, welchem Unternehmen sie gehört (z.B. ein "Firmenname"-Wasserzeichen), um den Autor der Präsentation zu identifizieren usw. Ein Wasserzeichen hilft, Urheberrechtsverletzungen zu verhindern, indem es deutlich macht, dass die Präsentation nicht kopiert werden sollte. Wasserzeichen werden sowohl in PowerPoint- als auch in OpenOffice-Präsentationsformaten verwendet. In Aspose.Slides können Sie ein Wasserzeichen zu PowerPoint PPT, PPTX und OpenOffice ODP-Dateiformaten hinzufügen.

In [**Aspose.Slides**](https://products.aspose.com/slides/java/) gibt es verschiedene Möglichkeiten, Wasserzeichen in PowerPoint- oder OpenOffice-Dokumenten zu erstellen und deren Design und Verhalten zu ändern. Der gemeinsame Aspekt ist, dass Sie zum Hinzufügen von Textwasserzeichen das [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) Interface verwenden sollten und zum Hinzufügen von Bildwasserzeichen die [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) Klasse nutzen oder eine Wasserzeichenform mit einem Bild füllen. `PictureFrame` implementiert das [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) Interface, wodurch Sie alle flexiblen Einstellungen des Formobjekts nutzen können. Da `ITextFrame` keine Form ist und ihre Einstellungen eingeschränkt sind, wird es in ein [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) Objekt eingewickelt.

Es gibt zwei Möglichkeiten, wie ein Wasserzeichen angewendet werden kann: auf einer einzelnen Folie oder auf allen Präsentationsfolien. Der Folienmaster wird verwendet, um ein Wasserzeichen auf allen Präsentationsfolien anzuwenden — das Wasserzeichen wird zum Folienmaster hinzugefügt, dort vollständig gestaltet und auf alle Folien angewendet, ohne die Berechtigung zur Modifikation des Wasserzeichens auf einzelnen Folien zu beeinträchtigen.

Ein Wasserzeichen wird normalerweise als nicht bearbeitbar durch andere Benutzer betrachtet. Um zu verhindern, dass das Wasserzeichen (oder besser gesagt, die übergeordnete Form des Wasserzeichens) bearbeitet wird, bietet Aspose.Slides eine Funktion zum Sperren von Formen an. Eine bestimmte Form kann auf einer normalen Folie oder auf einem Folienmaster gesperrt werden. Wenn die Wasserzeichenform auf dem Folienmaster gesperrt ist, wird sie in allen Präsentationsfolien gesperrt.

Sie können dem Wasserzeichen einen Namen zuweisen, sodass Sie es in Zukunft, wenn Sie es löschen möchten, in den Formen der Folie nach Namen finden können.

Sie können das Wasserzeichen auf beliebige Weise gestalten; jedoch gibt es normalerweise gemeinsame Merkmale in Wasserzeichen, wie z.B. mittig ausgerichtet, Rotation, Vordergrundposition usw. Wir werden im Folgenden betrachten, wie man diese in den Beispielen verwendet.

## **Textwasserzeichen**

### **Fügen Sie ein Textwasserzeichen zu einer Folie hinzu**

Um ein Textwasserzeichen in PPT, PPTX oder ODP hinzuzufügen, können Sie zunächst eine Form zur Folie hinzufügen und dann einen Textrahmen zu dieser Form hinzufügen. Der Textrahmen wird durch das [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) Interface dargestellt. Dieser Typ erbt nicht von [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/), das eine breite Palette von Eigenschaften zur flexiblen Positionierung des Wasserzeichens hat. Daher wird das [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) Objekt in ein [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) Objekt verpackt. Um dem Formobjekt Wasserzeichentext hinzuzufügen, verwenden Sie die [addTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) Methode, wie unten gezeigt.

```java
String watermarkText = "VERTRAULICH";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Siehe auch" %}} 
- [So verwenden Sie die TextFrame-Klasse](/slides/java/text-formatting/)
{{% /alert %}}

### **Fügen Sie ein Textwasserzeichen zu einer Präsentation hinzu**

Wenn Sie ein Textwasserzeichen zur gesamten Präsentation (d.h. zu allen Folien auf einmal) hinzufügen möchten, fügen Sie es zum [MasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/masterslide/) hinzu. Der Rest der Logik ist dieselbe wie beim Hinzufügen eines Wasserzeichens zu einer einzelnen Folie — erstellen Sie ein [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) Objekt und fügen Sie dann das Wasserzeichen hinzu, indem Sie die [addTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) Methode verwenden.

```java
String watermarkText = "VERTRAULICH";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Siehe auch" %}} 
- [So verwenden Sie die Folienmaster](/slides/java/slide-master/)
{{% /alert %}}

### **Setzen Sie die Transparenz der Wasserzeichenform**

Standardmäßig wird die Rechteckform mit Füll- und Linienfarben gestylt. Die folgenden Codezeilen machen die Form transparent.

```java
watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
```

### **Setzen Sie die Schriftart für ein Textwasserzeichen**

Sie können die Schriftart des Textwasserzeichens wie unten gezeigt ändern.

```java
IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);
```

### **Setzen Sie die Textfarbe des Wasserzeichens**

Um die Farbe des Wasserzeichentextes festzulegen, verwenden Sie diesen Code:

```java
int alpha = 150, rot = 200, grün = 200, blau = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(new Color(rot, grün, blau, alpha));
```

### **Zentrieren Sie ein Textwasserzeichen**

Es ist möglich, das Wasserzeichen auf einer Folie zu zentrieren. Dafür können Sie Folgendes tun:

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

Das folgende Bild zeigt das Endergebnis.

![Das Textwasserzeichen](text_watermark.png)

## **Bildwasserzeichen**

### **Fügen Sie ein Bildwasserzeichen zu einer Präsentation hinzu**

Um ein Bildwasserzeichen zu einer Präsentationsfolie hinzuzufügen, können Sie Folgendes tun:

```java
InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
```

## **Sperren Sie ein Wasserzeichen gegen Bearbeitung**

Wenn es notwendig ist, das Bearbeiten eines Wasserzeichens zu verhindern, verwenden Sie die [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#getAutoShapeLock--) Methode auf der Form. Mit dieser Eigenschaft können Sie die Form davor schützen, ausgewählt, verändert, repositioniert, mit anderen Elementen gruppiert, sowie ihren Text gegen Bearbeitung gesperrt zu werden, und vieles mehr:

```java
// Sperren Sie die Wasserzeichenform gegen Änderungen
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);
```

## **Bringen Sie ein Wasserzeichen nach vorne**

In Aspose.Slides kann die Z-Reihenfolge von Formen über die [IShapeCollection.reorder](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) Methode festgelegt werden. Dazu müssen Sie diese Methode von der Liste der Präsentationsfolien aufrufen und den Verweis auf die Form sowie deren Reihenfolge in die Methode übergeben. Auf diese Weise ist es möglich, eine Form nach vorne zu bringen oder sie nach hinten zu verschieben. Diese Funktion ist besonders nützlich, wenn Sie ein Wasserzeichen vor der Präsentation platzieren müssen:

```java
int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```

## **Setzen Sie die Wasserzeichenrotation**

Hier ist ein Codebeispiel, wie Sie die Rotation des Wasserzeichens anpassen können, damit es diagonal über die Folie positioniert wird:

```java
double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);
```

## **Setzen Sie einen Namen für ein Wasserzeichen**

Aspose.Slides ermöglicht es Ihnen, den Namen einer Form festzulegen. Durch die Verwendung des Formnamens können Sie in Zukunft darauf zugreifen, um sie zu modifizieren oder zu löschen. Um den Namen der Wasserzeichenform festzulegen, weisen Sie ihn der [IAutoShape.setName](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setName-java.lang.String-) Methode zu:

```java
watermarkShape.setName("wasserzeichen");
```

## **Entfernen Sie ein Wasserzeichen**

Um die Wasserzeichenform zu entfernen, verwenden Sie die [IAutoShape.getName](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getName--) Methode, um sie in den Folienformen zu finden. Übergeben Sie dann die Wasserzeichenform in die [IShapeCollection.remove](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) Methode:

```java
IShape[] slideShapes = slide.getShapes().toArray();
for (IShape shape : slideShapes) {
    if ("wasserzeichen".equals(shape.getName()))
    {
        slide.getShapes().remove(watermarkShape);
    }
}
```

## **Ein Live-Beispiel**

Sie möchten vielleicht die **Aspose.Slides kostenlose** [Wasserzeichen hinzufügen](https://products.aspose.app/slides/watermark) und [Wasserzeichen entfernen](https://products.aspose.app/slides/watermark/remove-watermark) Online-Tools ausprobieren.

![Online-Tools zum Hinzufügen und Entfernen von Wasserzeichen](online_tools.png)