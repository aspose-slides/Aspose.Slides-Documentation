---
title: Wasserzeichen
type: docs
weight: 40
url: /androidjava/wasserzeichen/
keywords:
- wasserzeichen
- wasserzeichen hinzufügen
- textwasserzeichen
- bildwasserzeichen
- PowerPoint
- präsentation
- Android
- Java
- Aspose.Slides für Android über Java
description: "Text- und Bildwasserzeichen zu PowerPoint-Präsentationen in Java hinzufügen"
---

## **Über Wasserzeichen**

**Ein Wasserzeichen** in einer Präsentation ist ein Text- oder Bildstempel, der auf einer Folie oder auf allen Folien der Präsentation verwendet wird. Normalerweise wird ein Wasserzeichen verwendet, um anzuzeigen, dass die Präsentation ein Entwurf ist (z.B. ein "Entwurf" Wasserzeichen), dass sie vertrauliche Informationen enthält (z.B. ein "Vertraulich" Wasserzeichen), um anzugeben, zu welchem Unternehmen sie gehört (z.B. ein "Unternehmensname" Wasserzeichen), um den Autor der Präsentation zu identifizieren usw. Ein Wasserzeichen hilft, Urheberrechtsverletzungen zu verhindern, indem es anzeigt, dass die Präsentation nicht kopiert werden sollte. Wasserzeichen werden sowohl im PowerPoint- als auch im OpenOffice-Präsentationsformat verwendet. In Aspose.Slides können Sie Wasserzeichen zu PowerPoint PPT, PPTX und OpenOffice ODP-Dateiformaten hinzufügen.

In [**Aspose.Slides**](https://products.aspose.com/slides/android-java/) gibt es verschiedene Möglichkeiten, Wasserzeichen in PowerPoint- oder OpenOffice-Dokumenten zu erstellen und deren Design und Verhalten zu ändern. Der gemeinsame Aspekt ist, dass Sie zum Hinzufügen von Textwasserzeichen das [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) Interface verwenden sollten, und um Bildwasserzeichen hinzuzufügen, verwenden Sie die [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/) Klasse oder füllen eine Wasserzeichenform mit einem Bild. `PictureFrame` implementiert das [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) Interface, wodurch Sie alle flexiblen Einstellungen des Formobjekts nutzen können. Da `ITextFrame` keine Form ist und ihre Einstellungen begrenzt sind, wird sie in ein [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) Objekt eingewickelt.

Es gibt zwei Möglichkeiten, wie ein Wasserzeichen angewendet werden kann: auf eine einzelne Folie oder auf alle Präsentationsfolien. Der Folienmaster wird verwendet, um ein Wasserzeichen auf allen Präsentationsfolien anzuwenden - das Wasserzeichen wird zum Folienmaster hinzugefügt, dort vollständig gestaltet und auf alle Folien angewendet, ohne das Recht zur Bearbeitung des Wasserzeichens auf einzelnen Folien zu beeinträchtigen.

Ein Wasserzeichen wird normalerweise als nicht bearbeitbar für andere Benutzer betrachtet. Um zu verhindern, dass das Wasserzeichen (oder besser gesagt die übergeordnete Form des Wasserzeichens) bearbeitet wird, bietet Aspose.Slides eine Funktion zur Formensperrung an. Eine bestimmte Form kann auf einer normalen Folie oder auf einem Folienmaster gesperrt werden. Wenn die Wasserzeichenform auf dem Folienmaster gesperrt ist, wird sie auf allen Präsentationsfolien gesperrt.

Sie können einen Namen für das Wasserzeichen festlegen, sodass Sie es in Zukunft, wenn Sie es löschen möchten, nach dem Namen in den Formen der Folie finden können.

Sie können das Wasserzeichen auf beliebige Weise gestalten; es gibt jedoch normalerweise gemeinsame Merkmale in Wasserzeichen, wie z.B. zentrierte Ausrichtung, Drehung, Vordergrundposition usw. Wir werden im Folgenden betrachten, wie man diese in den Beispielen verwendet.

## **Textwasserzeichen**

### **Textwasserzeichen zu einer Folie hinzufügen**

Um ein Textwasserzeichen in PPT, PPTX oder ODP hinzuzufügen, können Sie zunächst eine Form zur Folie hinzufügen und dann einen Textrahmen zu dieser Form hinzufügen. Der Textrahmen wird durch das [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) Interface repräsentiert. Dieser Typ erbt nicht von [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/), das über eine breite Palette von Eigenschaften zur flexiblen Positionierung des Wasserzeichens verfügt. Daher wird das [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) Objekt in ein [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) Objekt eingewickelt. Um Wasserzeichentext zur Form hinzuzufügen, verwenden Sie die [addTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) Methode wie unten gezeigt.

```java
String watermarkText = "VERTRAULICH";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Siehe auch" %}} 
- [Wie man die TextFrame-Klasse verwendet](/slides/androidjava/text-formatting/)
{{% /alert %}}

### **Textwasserzeichen zu einer Präsentation hinzufügen**

Wenn Sie ein Textwasserzeichen zu der gesamten Präsentation (d.h. zu allen Folien auf einmal) hinzufügen möchten, fügen Sie es zum [MasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/masterslide/) hinzu. Die restliche Logik ist die gleiche, wie beim Hinzufügen eines Wasserzeichens zu einer einzelnen Folie - erstellen Sie ein [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) Objekt und fügen Sie dann das Wasserzeichen damit hinzu, indem Sie die [addTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) Methode verwenden.

```java
String watermarkText = "VERTRAULICH";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Siehe auch" %}} 
- [Wie man den Folienmaster verwendet](/slides/androidjava/slide-master/)
{{% /alert %}}

### **Wasserzeichenformtransparenz einstellen**

Standardmäßig ist die Rechteckform mit Füll- und Linienfarben gestaltet. Die folgenden Codezeilen machen die Form transparent.

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

### **Wasserzeichentextfarbe festlegen**

Um die Farbe des Wasserzeichentexts festzulegen, verwenden Sie diesen Code:

```java
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(Color.argb(alpha, red, green, blue));
```

### **Ein Textwasserzeichen zentrieren**

Es ist möglich, das Wasserzeichen auf einer Folie zu zentrieren, und dafür können Sie Folgendes tun:

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

Das Bild unten zeigt das Endergebnis.

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

## **Ein Wasserzeichen vom Bearbeiten sperren**

Wenn es notwendig ist, zu verhindern, dass ein Wasserzeichen bearbeitet wird, verwenden Sie die [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#getAutoShapeLock--) Methode auf der Form. Mit dieser Eigenschaft können Sie die Form davor schützen, ausgewählt, skaliert, repositioniert, mit anderen Elementen gruppiert, ihren Text vor dem Bearbeiten gesperrt und vieles mehr zu werden:

```java
// Sperren Sie die Wasserzeichenform vor Modifikationen
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);
```

## **Ein Wasserzeichen nach vorne bringen**

In Aspose.Slides kann die Z-Reihenfolge von Formen über die [IShapeCollection.reorder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) Methode festgelegt werden. Um dies zu tun, müssen Sie diese Methode von der Liste der Präsentationsfolien aufrufen und die Formreferenz sowie ihre Reihenfolgenummer an die Methode übergeben. Auf diese Weise ist es möglich, eine Form nach vorne zu bringen oder sie auf die Rückseite der Folie zu senden. Diese Funktion ist besonders nützlich, wenn Sie ein Wasserzeichen vor die Präsentation platzieren müssen:

```java
int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```

## **Wasserzeichenrotation festlegen**

Hier ist ein Codebeispiel, wie Sie die Rotation des Wasserzeichens anpassen, damit es diagonal über die Folie positioniert ist:

```java
double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);
```

## **Einen Namen für ein Wasserzeichen festlegen**

Aspose.Slides ermöglicht es Ihnen, den Namen einer Form festzulegen. Indem Sie den Formnamen verwenden, können Sie in Zukunft darauf zugreifen, um ihn zu bearbeiten oder zu löschen. Um den Namen der Wasserzeichenform festzulegen, weisen Sie ihn der [IAutoShape.setName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setName-java.lang.String-) Methode zu:

```java
watermarkShape.setName("watermark");
```

## **Ein Wasserzeichen entfernen**

Um die Wasserzeichenform zu entfernen, verwenden Sie die [IAutoShape.getName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getName--) Methode, um sie in den Folienformen zu finden. Übergeben Sie dann die Wasserzeichenform an die [IShapeCollection.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) Methode:

```java
IShape[] slideShapes = slide.getShapes().toArray();
for (IShape shape : slideShapes) {
    if ("watermark".equals(shape.getName()))
    {
        slide.getShapes().remove(watermarkShape);
    }
}
```

## **Ein Live-Beispiel**

Sie möchten vielleicht die **Aspose.Slides kostenlose** [Wasserzeichen hinzufügen](https://products.aspose.app/slides/watermark) und [Wasserzeichen entfernen](https://products.aspose.app/slides/watermark/remove-watermark) Online-Tools ausprobieren.

![Online-Tools zum Hinzufügen und Entfernen von Wasserzeichen](online_tools.png)