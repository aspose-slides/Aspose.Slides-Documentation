---
title: Wasserzeichen zu Präsentationen in JavaScript hinzufügen
linktitle: Wasserzeichen
type: docs
weight: 40
url: /de/nodejs-java/watermark/
keywords:
- wasserzeichen
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Verwalten Sie Text- und Bildwasserzeichen in PowerPoint- und OpenDocument‑Präsentationen in Node.js, um einen Entwurf, vertrauliche Informationen, Urheberrechte und mehr anzugeben."
---

## **Über Wasserzeichen**

**Ein Wasserzeichen** in einer Präsentation ist ein Text‑ oder Bildstempel, der auf einer Folie oder in allen Folien einer Präsentation verwendet wird. Normalerweise wird ein Wasserzeichen benutzt, um anzuzeigen, dass die Präsentation ein Entwurf ist (z. B. ein „Entwurf“-Wasserzeichen), dass sie vertrauliche Informationen enthält (z. B. ein „Vertraulich“-Wasserzeichen), zu welcher Firma sie gehört (z. B. ein „Firmenname“-Wasserzeichen), den Autor der Präsentation zu identifizieren usw. Ein Wasserzeichen hilft, Urheberrechtsverletzungen zu verhindern, indem es anzeigt, dass die Präsentation nicht kopiert werden darf. Wasserzeichen werden sowohl in PowerPoint‑ als auch in OpenOffice‑Präsentationsformaten verwendet. In Aspose.Slides können Sie Wasserzeichen zu PowerPoint‑PPT, PPTX und OpenOffice‑ODP‑Dateiformaten hinzufügen.

In [**Aspose.Slides**](https://products.aspose.com/slides/nodejs-java/) gibt es verschiedene Möglichkeiten, Wasserzeichen in PowerPoint‑ oder OpenOffice‑Dokumenten zu erstellen und ihr Design sowie Verhalten zu ändern. Der gemeinsame Aspekt ist, dass zum Hinzufügen von Textwasserzeichen der [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/)-Typ verwendet werden sollte und zum Hinzufügen von Bildwasserzeichen die [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/)-Klasse oder das Befüllen einer Wasserzeichen‑Form mit einem Bild. `PictureFrame` implementiert den [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/)-Typ, sodass Sie alle flexiblen Einstellungen des Shape‑Objekts nutzen können. Da `TextFrame` kein Shape ist und seine Einstellungen begrenzt sind, wird es in ein [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/)-Objekt eingepackt.

Es gibt zwei Möglichkeiten, ein Wasserzeichen anzuwenden: auf einer einzelnen Folie oder auf allen Folien der Präsentation. Der Folienmaster wird verwendet, um ein Wasserzeichen auf alle Folien anzuwenden — das Wasserzeichen wird dem Folienmaster hinzugefügt, dort vollständig gestaltet und anschließend auf alle Folien übertragen, ohne die Möglichkeit zu beeinträchtigen, das Wasserzeichen auf einzelnen Folien zu bearbeiten.

Ein Wasserzeichen wird normalerweise als für andere Benutzer nicht editierbar betrachtet. Um zu verhindern, dass das Wasserzeichen (oder genauer gesagt das übergeordnete Shape des Wasserzeichens) bearbeitet wird, bietet Aspose.Slides eine Shape‑Lock‑Funktionalität. Ein bestimmtes Shape kann auf einer normalen Folie oder auf einem Folienmaster gesperrt werden. Wenn das Wasserzeichen‑Shape auf dem Folienmaster gesperrt ist, ist es auf allen Folien gesperrt.

Sie können dem Wasserzeichen einen Namen geben, sodass Sie es später anhand des Namens in den Shapes der Folie finden und löschen können.

Sie können das Wasserzeichen nach Belieben gestalten; üblich sind jedoch Merkmale wie zentrierte Ausrichtung, Drehung, Vordergrundposition usw. Wir zeigen, wie man diese in den Beispielen unten verwendet.

## **Textwasserzeichen**

### **Textwasserzeichen zu Folie hinzufügen**
Um ein Textwasserzeichen in PPT, PPTX oder ODP hinzuzufügen, können Sie zuerst ein Shape zur Folie hinzufügen und dann diesem Shape ein TextFrame hinzufügen. Das TextFrame wird durch den [**TextFrame**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame)-Typ repräsentiert. Dieser Typ erbt nicht von [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape), das über ein breites Set an Eigenschaften zur flexiblen Positionierung des Wasserzeichens verfügt. Deshalb wird das [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame)-Objekt in ein [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape)-Objekt eingepackt. Um Text zum Shape hinzuzufügen, verwenden Sie die [**addTextFrame**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-)‑Methode und übergeben den Wasserzeichentext:
```javascript
const watermarkText = "CONFIDENTIAL";

let presentation = new aspose.slides.Presentation();
let slide = presentation.getSlides().get_Item(0);

let watermarkShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 40);
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```


{{% alert color="primary" title="Siehe auch" %}} 
- Wie man verwendet [TextFrame](/slides/de/nodejs-java/text-formatting/).
{{% /alert %}}

### **Textwasserzeichen zur Präsentation hinzufügen**

Wenn Sie ein Textwasserzeichen für die gesamte Präsentation (also alle Folien gleichzeitig) hinzufügen möchten, fügen Sie es dem [**MasterSlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide) hinzu. Der Rest der Logik ist identisch zum Hinzufügen eines Wasserzeichens zu einer einzelnen Folie — ein [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape)-Objekt erstellen und anschließend das Wasserzeichen mit der [**addTextFrame**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-)‑Methode hinzufügen:
```javascript
const watermarkText = "CONFIDENTIAL";

let presentation = new aspose.slides.Presentation();
let masterSlide = presentation.getMasters().get_Item(0);

let watermarkShape = masterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 40);
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```


{{% alert color="primary" title="Siehe auch" %}} 
- [Wie man verwendet ](/slides/de/nodejs-java/slide-master/)[Folienmaster](/slides/de/nodejs-java/slide-master/)
{{% /alert %}}

### **Transparenz des Wasserzeichen‑Shapes festlegen**

Standardmäßig ist das Rechteck‑Shape mit Füll‑ und Linienfarben gestaltet. Die folgenden Codezeilen machen das Shape transparent.
```javascript
watermarkShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
watermarkShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
```


### **Schriftart für ein Textwasserzeichen festlegen**

Sie können die Schriftart des Textwasserzeichens wie unten gezeigt ändern.
```javascript
let textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new aspose.slides.FontData("Arial"));
textFormat.setFontHeight(50);
```


### **Farbe des Wasserzeichen‑Texts festlegen**

Um die Farbe des Wasserzeichen‑Texts festzulegen, verwenden Sie diesen Code:
```java
let alpha = 150;
let red = 200;
let green = 200;
let blue = 200;

let fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
fillFormat.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", red, green, blue, alpha));
```


### **Textwasserzeichen zentrieren**
Es ist möglich, das Wasserzeichen auf einer Folie zu zentrieren; dafür können Sie Folgendes tun:
```javascript
const watermarkWidth = 400;
const watermarkHeight = 40;
const watermarkX = (slideSize.getWidth() - watermarkWidth) / 2;
const watermarkY = (slideSize.getHeight() - watermarkHeight) / 2;

let watermarkShape = masterSlide.getShapes().addAutoShape(
        aspose.slides.ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);
        
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```


Das Bild unten zeigt das Endergebnis.

![Das Textwasserzeichen](text_watermark.png)

## **Bildwasserzeichen**

### **Bildwasserzeichen zur Präsentation hinzufügen**

Um ein Bildwasserzeichen zu allen Folien der Präsentation hinzuzufügen, können Sie Folgendes tun:
```javascript
let watermarkImage = aspose.slides.Images.fromFile("watermark.png");
let image = presentation.getImages().addImage(watermarkImage);

// ...

watermarkShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
```


### **Wasserzeichen vor Bearbeitung schützen**

Falls es nötig ist, ein Wasserzeichen vor dem Bearbeiten zu schützen, verwenden Sie die [**AutoShape.getShapeLock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#getShapeLock--)‑Methode am Shape. Mit dieser Eigenschaft können Sie das Shape vor Auswahl, Größenänderung, Verschiebung, Gruppierung mit anderen Elementen, Bearbeitung des Textes und vielem mehr schützen:
```javascript
// Sperre das Wasserzeichen-Shape vor Änderungen
watermarkShape.getShapeLock().setSelectLocked(true);
watermarkShape.getShapeLock().setSizeLocked(true);
watermarkShape.getShapeLock().setTextLocked(true);
watermarkShape.getShapeLock().setPositionLocked(true);
watermarkShape.getShapeLock().setGroupingLocked(true);
```


### **Wasserzeichen in den Vordergrund bringen**

In Aspose.Slides kann die Z‑Reihenfolge von Shapes über die [**SlideCollection.reorder**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#reorder-int-aspose.slides.ISlide...-)‑Methode festgelegt werden. Rufen Sie diese Methode aus der Folienliste der Präsentation auf und übergeben Sie die Shape‑Referenz sowie die gewünschte Reihenfolgenummer. So lässt sich ein Shape nach vorne oder nach hinten verschieben. Diese Funktion ist besonders nützlich, wenn Sie ein Wasserzeichen vor dem Rest der Präsentation platzieren möchten:
```javascript
let shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```


### **Drehung des Wasserzeichens festlegen**

Im folgenden Beispiel wird gezeigt, wie die Drehung des Wasserzeichens so angepasst wird, dass es diagonal über die Folie verläuft:
```javascript
const diagonalAngle = Math.atan(slideSize.getHeight() / slideSize.getWidth()) * 180 / Math.PI;

watermarkShape.setRotation(diagonalAngle);
```


### **Einen Namen für ein Wasserzeichen festlegen**

Aspose.Slides ermöglicht das Festlegen eines Shape‑Namens. Durch den Shape‑Namen können Sie das Wasserzeichen später gezielt ändern oder entfernen. Um den Namen des Wasserzeichen‑Shapes festzulegen, verwenden Sie die [**AutoShape.getName**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getName--)‑Methode:
```javascript
watermarkShape.setName("watermark");
```


### **Wasserzeichen entfernen**

Um das Wasserzeichen‑Shape zu entfernen, nutzen Sie die [AutoShape.getName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getName--)‑Methode, um es in den Shapes der Folie zu finden. Anschließend übergeben Sie das Wasserzeichen‑Shape an die [**ShapeCollection.remove**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#remove-aspose.slides.IShape-)‑Methode:
```javascript
for (var i = 0; i < slide.getShapes().size(); i++) {
    var shape = slide.getShapes().get_Item(i);
    if ("watermark" == shape.getName()) {
        slide.getShapes().remove(watermarkShape);
    }
}
```


## **FAQ**

**Was ist ein Wasserzeichen und warum sollte ich es verwenden?**

Ein Wasserzeichen ist ein Text‑ oder Bildüberlagerung, die Folien schützt, die Markenbekanntheit stärkt oder die unautorisierte Nutzung von Präsentationen verhindert.

**Kann ich ein Wasserzeichen zu allen Folien einer Präsentation hinzufügen?**

Ja, Aspose.Slides ermöglicht das Hinzufügen eines Wasserzeichens zu jeder Folie einer Präsentation. Sie können über alle Folien iterieren und die Wasserzeichen‑Einstellungen einzeln anwenden.

**Wie kann ich die Transparenz des Wasserzeichens anpassen?**

Sie können die Transparenz des Wasserzeichens ändern, indem Sie die [Füll‑Einstellungen](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getfillformat/) des Shapes anpassen. So bleibt das Wasserzeichen dezent und lenkt nicht vom Folieninhalt ab.

**Welche Bildformate werden für Wasserzeichen unterstützt?**

Aspose.Slides unterstützt verschiedene Bildformate wie PNG, JPEG, GIF, BMP, SVG und mehr.

**Kann ich die Schriftart und den Stil eines Textwasserzeichens anpassen?**

Ja, Sie können jede Schriftart, Größe und Stil wählen, um das Design Ihrer Präsentation anzupassen und Marken­konsistenz zu wahren.

**Wie ändere ich die Position oder Ausrichtung eines Wasserzeichens?**

Sie können die Position und Ausrichtung des Wasserzeichens ändern, indem Sie die Koordinaten, Größe und Drehungs‑Eigenschaften des Shapes anpassen.