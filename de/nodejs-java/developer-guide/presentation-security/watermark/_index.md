---
title: Wasserzeichen
type: docs
weight: 40
url: /de/nodejs-java/watermark/
keywords: "Wasserzeichen in Präsentation"
description: "Verwenden Sie Wasserzeichen in PowerPoint mit Aspose.Slides. Fügen Sie ein Wasserzeichen in eine PPT‑Präsentation ein oder entfernen Sie ein Wasserzeichen. Bildwasserzeichen oder Textwasserzeichen einfügen."
---

## **Über Wasserzeichen**

**Ein Wasserzeichen** in einer Präsentation ist ein Text‑ oder Bildstempel, der auf einer Folie oder über alle Folien der Präsentation verwendet wird. Üblicherweise wird ein Wasserzeichen verwendet, um anzuzeigen, dass die Präsentation ein Entwurf ist (z. B. ein „Draft“-Wasserzeichen), dass sie vertrauliche Informationen enthält (z. B. ein „Confidential“-Wasserzeichen), um anzugeben, zu welchem Unternehmen sie gehört (z. B. ein „Company Name“-Wasserzeichen), um den Autor der Präsentation zu identifizieren usw. Ein Wasserzeichen hilft, Urheberrechtsverletzungen zu verhindern, indem es anzeigt, dass die Präsentation nicht kopiert werden soll. Wasserzeichen werden sowohl in PowerPoint‑ als auch in OpenOffice‑Präsentationsformaten verwendet. In Aspose.Slides können Sie ein Wasserzeichen zu den Dateiformaten PowerPoint PPT, PPTX und OpenOffice ODP hinzufügen.

In [**Aspose.Slides**](https://products.aspose.com/slides/nodejs-java/) gibt es verschiedene Möglichkeiten, Wasserzeichen in PowerPoint‑ oder OpenOffice‑Dokumenten zu erstellen und deren Design und Verhalten zu ändern. Gemeinsam ist, dass zum Hinzufügen von Text‑Wasserzeichen der Typ [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) verwendet werden sollte und zum Hinzufügen von Bild‑Wasserzeichen die Klasse [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) oder das Füllen einer Wasserzeichen‑Form mit einem Bild verwendet wird. `PictureFrame` implementiert den Typ [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) und ermöglicht die Nutzung aller flexiblen Einstellungen des Form‑Objekts. Da `TextFrame` keine Form ist und seine Einstellungen begrenzt sind, wird es in ein [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/)‑Objekt eingewickelt.

Es gibt zwei Möglichkeiten, ein Wasserzeichen anzuwenden: auf eine einzelne Folie oder auf alle Folien der Präsentation. Der Folienmaster wird verwendet, um ein Wasserzeichen auf alle Folien der Präsentation anzuwenden – das Wasserzeichen wird dem Folienmaster hinzugefügt, dort vollständig gestaltet und auf alle Folien angewendet, ohne die Möglichkeit zu beeinträchtigen, das Wasserzeichen auf einzelnen Folien zu bearbeiten.

Ein Wasserzeichen gilt in der Regel als für andere Benutzer nicht bearbeitbar. Um zu verhindern, dass das Wasserzeichen (bzw. die übergeordnete Form des Wasserzeichens) bearbeitet wird, stellt Aspose.Slides eine Form‑Sperrfunktion bereit. Eine bestimmte Form kann auf einer normalen Folie oder auf einem Folienmaster gesperrt werden. Wird die Wasserzeichen‑Form auf dem Folienmaster gesperrt, ist sie auf allen Folien der Präsentation gesperrt.

Sie können dem Wasserzeichen einen Namen zuweisen, sodass Sie es später, wenn Sie es löschen möchten, anhand des Namens in den Formen der Folie finden können.

Sie können das Wasserzeichen nach beliebigen Vorstellungen gestalten; jedoch gibt es üblicherweise gemeinsame Merkmale von Wasserzeichen, wie zentrierte Ausrichtung, Drehung, Vordergrundposition usw. Wir werden im Folgenden in den Beispielen erläutern, wie diese verwendet werden.

## **Text‑Wasserzeichen**

### **Text‑Wasserzeichen zu Folie hinzufügen**
Um ein Text‑Wasserzeichen in PPT, PPTX oder ODP hinzuzufügen, können Sie zunächst eine Form zur Folie hinzufügen und dann dieser Form einen TextFrame hinzufügen. Der TextFrame wird durch den Typ [**TextFrame**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) repräsentiert. Dieser Typ erbt nicht von [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape), das über einen umfangreichen Satz von Eigenschaften zur flexiblen Positionierung des Wasserzeichens verfügt. Daher wird das Objekt [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) in ein [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape)‑Objekt eingewickelt. Um dem Shape Text‑Wasserzeichen hinzuzufügen, verwenden Sie die Methode [**addTextFrame**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-) und übergeben den Wasserzeichen‑Text.
```javascript
const watermarkText = "CONFIDENTIAL";

let presentation = new aspose.slides.Presentation();
let slide = presentation.getSlides().get_Item(0);

let watermarkShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 40);
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```


{{% alert color="primary" title="Siehe auch" %}} 
- [Wie man ](/slides/de/nodejs-java/slide-master/)[TextFrame](/slides/de/nodejs-java/adding-and-formatting-text/)
{{% /alert %}}

### **Text‑Wasserzeichen zur Präsentation hinzufügen**
Wenn Sie ein Text‑Wasserzeichen zur gesamten Präsentation hinzufügen möchten (d. h. zu allen Folien auf einmal), fügen Sie es dem [**MasterSlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide) hinzu. Der Rest der Logik ist derselbe wie beim Hinzufügen eines Wasserzeichens zu einer einzelnen Folie – erstellen Sie ein [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape)‑Objekt und fügen Sie das Wasserzeichen mithilfe der Methode [**addTextFrame**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-) hinzu:
```javascript
const watermarkText = "CONFIDENTIAL";

let presentation = new aspose.slides.Presentation();
let masterSlide = presentation.getMasters().get_Item(0);

let watermarkShape = masterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 40);
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```


{{% alert color="primary" title="Siehe auch" %}} 
- [Wie man ](/slides/de/nodejs-java/slide-master/)[Slide Master](/slides/de/nodejs-java/slide-master/)
{{% /alert %}}

### **Transparenz der Wasserzeichen‑Form festlegen**
Standardmäßig ist die Rechteckform mit Füll‑ und Linienfarben formatiert. Die folgenden Codezeilen machen die Form transparent.
```javascript
watermarkShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
watermarkShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
```


### **Schriftart für ein Text‑Wasserzeichen festlegen**
Sie können die Schriftart des Text‑Wasserzeichens wie unten gezeigt ändern.
```javascript
let textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new aspose.slides.FontData("Arial"));
textFormat.setFontHeight(50);
```


### **Farbe des Wasserzeichen‑Textes festlegen**
Um die Farbe des Wasserzeichen‑Textes festzulegen, verwenden Sie diesen Code:
```java
let alpha = 150;
let red = 200;
let green = 200;
let blue = 200;

let fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
fillFormat.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", red, green, blue, alpha));
```


### **Text‑Wasserzeichen zentrieren**
Es ist möglich, das Wasserzeichen auf einer Folie zu zentrieren, und dafür können Sie Folgendes tun:
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

![Das Text‑Wasserzeichen](text_watermark.png)

## **Bild‑Wasserzeichen**

### **Bild‑Wasserzeichen zur Präsentation hinzufügen**
Um ein Bild‑Wasserzeichen zu allen Folien der Präsentation hinzuzufügen, können Sie Folgendes tun:
```javascript
let watermarkImage = aspose.slides.Images.fromFile("watermark.png");
let image = presentation.getImages().addImage(watermarkImage);

// ...

watermarkShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
```


### **Wasserzeichen vor Bearbeitung sperren**
Wenn es notwendig ist, ein Wasserzeichen vor Bearbeitung zu schützen, verwenden Sie die Methode [**AutoShape.getShapeLock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#getShapeLock--) auf der Form. Mit dieser Eigenschaft können Sie die Form davor schützen, ausgewählt, in der Größe verändert, neu positioniert, mit anderen Elementen gruppiert, ihr Text vor Bearbeitung gesperrt und vieles mehr zu werden:
```javascript
// Sperre die Wasserzeichenform vor Änderungen
watermarkShape.getShapeLock().setSelectLocked(true);
watermarkShape.getShapeLock().setSizeLocked(true);
watermarkShape.getShapeLock().setTextLocked(true);
watermarkShape.getShapeLock().setPositionLocked(true);
watermarkShape.getShapeLock().setGroupingLocked(true);
```


{{% alert color="primary" title="Siehe auch" %}} 
- [Wie man Formen vor Bearbeitung sperrt](/slides/de/nodejs-java/presentation-locking/)
{{% /alert %}}

### **Wasserzeichen in den Vordergrund bringen**
In Aspose.Slides kann die Z‑Reihenfolge von Formen über die Methode [**SlideCollection.reorder**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#reorder-int-aspose.slides.ISlide...-) festgelegt werden. Dazu rufen Sie diese Methode aus der Liste der Präsentationsfolien auf und übergeben die Formreferenz sowie deren Ordnungsnummer. Auf diese Weise kann eine Form in den Vordergrund oder in den Hintergrund der Folie verschoben werden. Diese Funktion ist besonders nützlich, wenn Sie ein Wasserzeichen vor die Präsentation stellen müssen:
```javascript
let shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```


### **Rotation des Wasserzeichens festlegen**
Hier ist ein Codebeispiel, wie Sie die Drehung des Wasserzeichens anpassen können, sodass es diagonal über die Folie positioniert wird:
```javascript
const diagonalAngle = Math.atan(slideSize.getHeight() / slideSize.getWidth()) * 180 / Math.PI;

watermarkShape.setRotation(diagonalAngle);
```


### **Einen Namen für ein Wasserzeichen festlegen**
Aspose.Slides erlaubt es, den Namen einer Form festzulegen. Durch die Verwendung des Formnamens können Sie künftig auf die Form zugreifen, um sie zu ändern oder zu löschen. Um den Namen der Wasserzeichen‑Form festzulegen, weisen Sie ihn der Methode [**AutoShape.getName**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getName--) zu:
```javascript
watermarkShape.setName("watermark");
```


### **Wasserzeichen entfernen**
Um die Wasserzeichen‑Form zu entfernen, verwenden Sie die Methode [AutoShape.getName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getName--) um sie in den Folienformen zu finden. Anschließend übergeben Sie die Wasserzeichen‑Form an die Methode [**ShapeCollection.remove**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#remove-aspose.slides.IShape-):
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

Ein Wasserzeichen ist ein Text‑ oder Bildoverlay, das auf Folien angewendet wird und hilft, geistiges Eigentum zu schützen, die Markenbekanntheit zu steigern oder die unbefugte Nutzung von Präsentationen zu verhindern.

**Kann ich ein Wasserzeichen zu allen Folien einer Präsentation hinzufügen?**

Ja, Aspose.Slides ermöglicht es, ein Wasserzeichen zu jeder Folie einer Präsentation hinzuzufügen. Sie können durch alle Folien iterieren und die Wasserzeichen‑Einstellungen einzeln anwenden.

**Wie kann ich die Transparenz des Wasserzeichens anpassen?**

Sie können die Transparenz des Wasserzeichens anpassen, indem Sie die [Füll‑Einstellungen](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getfillformat/) der Form ändern. Dadurch wird das Wasserzeichen dezent und lenkt nicht vom Folieninhalt ab.

**Welche Bildformate werden für Wasserzeichen unterstützt?**

Aspose.Slides unterstützt verschiedene Bildformate wie PNG, JPEG, GIF, BMP, SVG und weitere.

**Kann ich die Schriftart und den Stil eines Text‑Wasserzeichens anpassen?**

Ja, Sie können jede Schriftart, Größe und Stil wählen, um das Design Ihrer Präsentation anzupassen und die Markenkonsistenz zu wahren.

**Wie ändere ich die Position oder Ausrichtung eines Wasserzeichens?**

Sie können die Position und Ausrichtung des Wasserzeichens ändern, indem Sie die Koordinaten, Größe und Drehung der Form anpassen.