---
title: Wasserzeichen
type: docs
weight: 40
url: /androidjava/watermark/
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

**Ein Wasserzeichen** in einer Präsentation ist ein Text- oder Bildstempel, der auf einer Folie oder über alle Präsentationsfolien hinweg verwendet wird. In der Regel wird ein Wasserzeichen verwendet, um anzuzeigen, dass die Präsentation ein Entwurf ist (z.B. ein "Entwurf"-Wasserzeichen), dass sie vertrauliche Informationen enthält (z.B. ein "Vertraulich"-Wasserzeichen), um anzugeben, zu welchem Unternehmen sie gehört (z.B. ein "Unternehmensname"-Wasserzeichen), um den Autor der Präsentation zu identifizieren usw. Ein Wasserzeichen hilft, Urheberrechtsverletzungen zu verhindern, indem es anzeigt, dass die Präsentation nicht kopiert werden sollte. Wasserzeichen werden sowohl in PowerPoint- als auch in OpenOffice-Präsentationsformaten verwendet. In Aspose.Slides können Sie ein Wasserzeichen zu PowerPoint PPT-, PPTX- und OpenOffice ODP-Dateiformaten hinzufügen.

In [**Aspose.Slides**](https://products.aspose.com/slides/android-java/) gibt es verschiedene Möglichkeiten, Wasserzeichen in PowerPoint- oder OpenOffice-Dokumenten zu erstellen und deren Design und Verhalten zu ändern. Der gemeinsame Aspekt besteht darin, dass Sie zum Hinzufügen von Textwasserzeichen das [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) Interface verwenden sollten und zum Hinzufügen von Bildwasserzeichen die [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/) Klasse verwenden oder eine Wasserzeichenform mit einem Bild füllen. `PictureFrame` implementiert das [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) Interface, sodass Sie alle flexiblen Einstellungen des Formenobjekts verwenden können. Da `ITextFrame` keine Form ist und seine Einstellungen begrenzt sind, wird es in ein [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) Objekt gewickelt.

Es gibt zwei Möglichkeiten, wie ein Wasserzeichen angewendet werden kann: auf einer einzelnen Folie oder auf allen Präsentationsfolien. Die Foliensmaster werden verwendet, um ein Wasserzeichen auf allen Präsentationsfolien anzuwenden — das Wasserzeichen wird zum Foliensmaster hinzugefügt, dort vollständig gestaltet und auf alle Folien angewendet, ohne die Berechtigung zur Bearbeitung des Wasserzeichens auf einzelnen Folien zu beeinträchtigen.

Ein Wasserzeichen wird üblicherweise als nicht bearbeitbar für andere Benutzer betrachtet. Um zu verhindern, dass das Wasserzeichen (oder besser gesagt die übergeordnete Form des Wasserzeichens) bearbeitet wird, bietet Aspose.Slides die Funktionalität zur Formensperrung. Eine bestimmte Form kann auf einer normalen Folie oder auf einem Foliensmaster gesperrt werden. Wenn die Wasserzeichenform auf dem Foliensmaster gesperrt ist, wird sie auf allen Präsentationsfolien gesperrt sein.

Sie können einen Namen für das Wasserzeichen festlegen, damit Sie es in Zukunft, wenn Sie es löschen möchten, nach Namen in den Formen der Folie finden können.

Sie können das Wasserzeichen auf beliebige Weise gestalten; es gibt jedoch normalerweise gemeinsame Merkmale in Wasserzeichen, wie z.B. zentrale Ausrichtung, Drehung, Vordergrundposition usw. Wir werden im Folgenden betrachten, wie man diese in den Beispielen verwendet.

## **Textwasserzeichen**

### **Ein Textwasserzeichen zu einer Folie hinzufügen**

Um ein Textwasserzeichen in PPT, PPTX oder ODP hinzuzufügen, können Sie zunächst eine Form zur Folie hinzufügen und dann einen Textrahmen zu dieser Form hinzufügen. Der Textrahmen wird durch das [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) Interface dargestellt. Dieser Typ erbt nicht von [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/), das eine breite Palette von Eigenschaften für die flexible Positionierung des Wasserzeichens hat. Daher wird das [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) Objekt in ein [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) Objekt gewickelt. Um den Wasserzeichen-Text zur Form hinzuzufügen, verwenden Sie die [addTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) Methode, wie unten gezeigt.

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

### **Ein Textwasserzeichen zu einer Präsentation hinzufügen**

Wenn Sie ein Textwasserzeichen zur gesamten Präsentation (d.h. zu allen Folien auf einmal) hinzufügen möchten, fügen Sie es zum [MasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/masterslide/) hinzu. Der Rest der Logik ist dieselbe wie beim Hinzufügen eines Wasserzeichens zu einer einzelnen Folie — erstellen Sie ein [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) Objekt und fügen Sie dann das Wasserzeichen mit der [addTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) Methode hinzu.

```java
String watermarkText = "VERTRAULICH";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Siehe auch" %}} 
- [Wie man den Slide Master verwendet](/slides/androidjava/slide-master/)
{{% /alert %}}

### **Transparenz der Wasserzeichenform einstellen**

Standardmäßig wird die Rechteckform mit Füll- und Linienfarben gestylt. Die folgenden Codezeilen machen die Form transparent.

```java
watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
```

### **Die Schriftart für ein Textwasserzeichen festlegen**

Sie können die Schriftart des Textwasserzeichens wie unten gezeigt ändern.

```java
IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);
```

### **Die Textfarbe des Wasserzeichens festlegen**

Um die Farbe des Wasserzeichen-Texts festzulegen, verwenden Sie diesen Code:

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

![Das Text-Wasserzeichen](text_watermark.png)

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

## **Ein Wasserzeichen vor der Bearbeitung sperren**

Wenn es notwendig ist, ein Wasserzeichen vor der Bearbeitung zu schützen, verwenden Sie die [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#getAutoShapeLock--) Methode auf der Form. Mit dieser Eigenschaft können Sie die Form vor Auswahl, Größenänderung, Neupositionierung, Gruppierung mit anderen Elementen schützen, ihren Text vor Bearbeitung sperren und vieles mehr:

```java
// Sperren Sie die Wasserzeichenform vor Änderungen
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);
```

## **Ein Wasserzeichen in den Vordergrund bringen**

In Aspose.Slides kann die Z-Reihenfolge von Formen über die [IShapeCollection.reorder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) Methode festgelegt werden. Dazu müssen Sie diese Methode aus der Liste der Präsentationsfolien aufrufen und den Formreferenz und ihre Reihenfolgenummer übergeben. So ist es möglich, eine Form in den Vordergrund zu bringen oder sie in den Hintergrund der Folie zu senden. Diese Funktion ist besonders nützlich, wenn Sie ein Wasserzeichen vor der Präsentation platzieren müssen:

```java
int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```

## **Wasserzeichenrotation einstellen**

Hier ist ein Codebeispiel, wie man die Drehung des Wasserzeichens anpassen kann, damit es diagonal über die Folie positioniert wird:

```java
double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);
```

## **Einen Namen für ein Wasserzeichen festlegen**

Aspose.Slides ermöglicht es Ihnen, den Namen einer Form festzulegen. Mit Hilfe des Formnamens können Sie in Zukunft darauf zugreifen, um ihn zu ändern oder zu löschen. Um den Namen der Wasserzeichenform festzulegen, weisen Sie ihn der [IAutoShape.setName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setName-java.lang.String-) Methode zu:

```java
watermarkShape.setName("wasserzeichen");
```

## **Ein Wasserzeichen entfernen**

Um die Wasserzeichenform zu entfernen, verwenden Sie die [IAutoShape.getName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getName--) Methode, um sie in den Formen der Folie zu finden. Übergeben Sie dann die Wasserzeichenform in die [IShapeCollection.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) Methode:

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

Sie möchten möglicherweise die **Aspose.Slides kostenlose** [Wasserzeichen hinzufügen](https://products.aspose.app/slides/watermark) und [Wasserzeichen entfernen](https://products.aspose.app/slides/watermark/remove-watermark) Online-Tools überprüfen.

![Online-Tools zum Hinzufügen und Entfernen von Wasserzeichen](online_tools.png)