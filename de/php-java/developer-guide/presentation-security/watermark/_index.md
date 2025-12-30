---
title: Wasserzeichen zu Präsentationen in PHP hinzufügen
linktitle: Wasserzeichen
type: docs
weight: 40
url: /de/php-java/watermark/
keywords:
- wasserzeichen
- textwasserzeichen
- bildwasserzeichen
- wasserzeichen hinzufügen
- wasserzeichen ändern
- wasserzeichen entfernen
- wasserzeichen löschen
- wasserzeichen zu PPT hinzufügen
- wasserzeichen zu PPTX hinzufügen
- wasserzeichen zu ODP hinzufügen
- wasserzeichen aus PPT entfernen
- wasserzeichen aus PPTX entfernen
- wasserzeichen aus ODP entfernen
- wasserzeichen aus PPT löschen
- wasserzeichen aus PPTX löschen
- wasserzeichen aus ODP löschen
- PowerPoint
- OpenDocument
- präsentation
- PHP
- Aspose.Slides
description: "Verwalten Sie Text‑ und Bildwasserzeichen in PowerPoint‑ und OpenDocument‑Präsentationen in PHP, um einen Entwurf, vertrauliche Informationen, Urheberrechte und mehr anzugeben."
---

## **Über Wasserzeichen**

**Ein Wasserzeichen** in einer Präsentation ist ein Text‑ oder Bildstempel, der auf einer Folie oder in allen Folien einer Präsentation verwendet wird. Üblicherweise wird ein Wasserzeichen genutzt, um anzuzeigen, dass die Präsentation ein Entwurf ist (z. B. ein „Entwurf“-Wasserzeichen), dass vertrauliche Informationen enthalten sind (z. B. ein „Vertraulich“-Wasserzeichen), um anzugeben, zu welchem Unternehmen sie gehört (z. B. ein „Firmenname“-Wasserzeichen), den Autor der Präsentation zu identifizieren usw. Ein Wasserzeichen hilft, Urheberrechtsverletzungen zu verhindern, indem es anzeigt, dass die Präsentation nicht kopiert werden soll. Wasserzeichen werden sowohl im PowerPoint‑ als auch im OpenOffice‑Präsentationsformat verwendet. In Aspose.Slides können Sie einem PowerPoint‑PPT, PPTX und OpenOffice‑ODP‑Dateiformat ein Wasserzeichen hinzufügen.

In [**Aspose.Slides**](https://products.aspose.com/slides/php-java/) gibt es verschiedene Möglichkeiten, Wasserzeichen in PowerPoint‑ oder OpenOffice‑Dokumenten zu erstellen und deren Design sowie Verhalten zu ändern. Der gemeinsame Aspekt ist, dass zum Hinzufügen von Text‑Wasserzeichen die Klasse [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) verwendet werden sollte und zum Hinzufügen von Bild‑Wasserzeichen die Klasse [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) oder das Füllen einer Wasserzeichen‑Form mit einem Bild. `PictureFrame` implementiert die Klasse [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/), sodass Sie alle flexiblen Einstellungen des Shape‑Objekts nutzen können. Da `ITextFrame` kein Shape ist und seine Einstellungen begrenzt sind, wird es in ein [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/)‑Objekt eingewickelt.

Ein Wasserzeichen kann auf zwei Arten angewendet werden: auf einer einzelnen Folie oder auf allen Folien der Präsentation. Der Folien‑Master wird verwendet, um ein Wasserzeichen auf alle Folien anzuwenden — das Wasserzeichen wird dem Folien‑Master hinzugefügt, dort vollständig gestaltet und auf alle Folien angewendet, ohne die Möglichkeit zu beeinträchtigen, das Wasserzeichen auf einzelnen Folien zu bearbeiten.

Ein Wasserzeichen wird in der Regel als nicht editierbar für andere Benutzer betrachtet. Um zu verhindern, dass das Wasserzeichen (bzw. das übergeordnete Shape des Wasserzeichens) bearbeitet wird, bietet Aspose.Slides eine Shape‑Sperrfunktion. Ein bestimmtes Shape kann auf einer normalen Folie oder auf einem Folien‑Master gesperrt werden. Wird das Wasserzeichen‑Shape auf dem Folien‑Master gesperrt, ist es auf allen Folien gesperrt.

Sie können dem Wasserzeichen einen Namen zuweisen, sodass Sie es in Zukunft anhand des Namens in den Folien‑Shapes finden und ggf. löschen können.

Sie können das Wasserzeichen nach Belieben gestalten; typischerweise besitzen Wasserzeichen jedoch gemeinsame Merkmale wie zentrierte Ausrichtung, Drehung, Vordergrundposition usw. Im Folgenden betrachten wir, wie man diese Merkmale in den Beispielen verwendet.

## **Text‑Wasserzeichen**

### **Ein Text‑Wasserzeichen zu einer Folie hinzufügen**

Um ein Text‑Wasserzeichen in PPT, PPTX oder ODP hinzuzufügen, können Sie zunächst ein Shape zur Folie hinzufügen und diesem dann ein TextFrame zuweisen. Das TextFrame wird durch die Klasse [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) repräsentiert. Dieser Typ erbt nicht von [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/), das über zahlreiche Eigenschaften für die flexible Positionierung des Wasserzeichens verfügt. Deshalb wird das [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/)-Objekt in ein [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/)‑Objekt eingewickelt. Um dem Shape Text‑Wasserzeichen hinzuzufügen, verwenden Sie die Methode [addTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#addTextFrame) wie unten gezeigt.
```php
$watermarkText = "CONFIDENTIAL";

$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$watermarkShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```


{{% alert color="primary" title="Siehe auch" %}} 
- [Verwendung der TextFrame‑Klasse](/slides/de/php-java/text-formatting/)
{{% /alert %}}

### **Ein Text‑Wasserzeichen zur gesamten Präsentation hinzufügen**

Wenn Sie ein Text‑Wasserzeichen zur gesamten Präsentation (also zu allen Folien gleichzeitig) hinzufügen möchten, fügen Sie es dem [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) hinzu. Der Rest der Logik ist identisch zur Vorgehensweise beim Hinzufügen eines Wasserzeichens zu einer einzelnen Folie — erstellen Sie ein [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/)‑Objekt und fügen Sie das Wasserzeichen mittels der Methode [addTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#addTextFrame) hinzu.
```php
$watermarkText = "CONFIDENTIAL";

$presentation = new Presentation();
$masterSlide = $presentation->getMasters()->get_Item(0);

$watermarkShape = $masterSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```


{{% alert color="primary" title="Siehe auch" %}} 
- [Verwendung des Folien‑Masters](/slides/de/php-java/slide-master/)
{{% /alert %}}

### **Transparenz des Wasserzeichen‑Shapes festlegen**

Standardmäßig ist das Rechteck‑Shape mit Füll‑ und Linienfarben formatiert. Die folgenden Codezeilen machen das Shape transparent.
```php
$watermarkShape->getFillFormat()->setFillType(FillType::NoFill);
$watermarkShape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
```


### **Schriftart für ein Text‑Wasserzeichen festlegen**

Sie können die Schriftart des Text‑Wasserzeichens wie unten gezeigt ändern.
```php
$textFormat = $watermarkFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat();
$textFormat->setLatinFont(new FontData("Arial"));
$textFormat->setFontHeight(50);
```


### **Farbe des Wasserzeichen‑Texts festlegen**

Um die Farbe des Wasserzeichen‑Texts zu setzen, verwenden Sie diesen Code:
```php
$alpha = 150;
$red = 200;
$green = 200;
$blue = 200;
$textColor = new Java("java.awt.Color", $red, $green, $blue, $alpha);

$fillFormat = $watermarkFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();
$fillFormat->setFillType(FillType::Solid);
$fillFormat->getSolidFillColor()->setColor($textColor);
```


### **Ein Text‑Wasserzeichen zentrieren**

Es ist möglich, das Wasserzeichen auf einer Folie zu zentrieren; dazu können Sie Folgendes tun:
```php
$slideSize = $presentation->getSlideSize()->getSize();
$slideWidth = java_values($slideSize->getWidth());
$slideHeight = java_values($slideSize->getHeight());

$watermarkWidth = 400;
$watermarkHeight = 40;
$watermarkX = ($slideWidth - $watermarkWidth) / 2;
$watermarkY = ($slideHeight - $watermarkHeight) / 2;

$watermarkShape = $slide->getShapes()->addAutoShape(
        ShapeType::Rectangle, $watermarkX, $watermarkY, $watermarkWidth, $watermarkHeight);

$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);
```


Das untenstehende Bild zeigt das Endergebnis.

![Das Text‑Wasserzeichen](text_watermark.png)

## **Bild‑Wasserzeichen**

### **Ein Bild‑Wasserzeichen zur Präsentation hinzufügen**

Um ein Bild‑Wasserzeichen zu einer Präsentationsfolie hinzuzufügen, können Sie Folgendes tun:
```php
$image = Images::fromFile("watermark.png");
$picture = $presentation->getImages()->addImage($image);
$image->dispose();

$watermarkShape->getFillFormat()->setFillType(FillType::Picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
```


### **Ein Wasserzeichen vor Bearbeitung schützen**

Falls es erforderlich ist, ein Wasserzeichen vor Bearbeitung zu schützen, verwenden Sie die Methode [AutoShape.getAutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#getAutoShapeLock) am Shape. Mit dieser Eigenschaft können Sie das Shape davor schützen, ausgewählt, in der Größe geändert, repositioniert, mit anderen Elementen gruppiert, sein Text vor Bearbeitung gesperrt usw.:
```php
// Sperrt das Wasserzeichen-Shape vor Änderungen
$watermarkShape->getAutoShapeLock()->setSelectLocked(true);
$watermarkShape->getAutoShapeLock()->setSizeLocked(true);
$watermarkShape->getAutoShapeLock()->setTextLocked(true);
$watermarkShape->getAutoShapeLock()->setPositionLocked(true);
$watermarkShape->getAutoShapeLock()->setGroupingLocked(true);
```


### **Ein Wasserzeichen in den Vordergrund holen**

In Aspose.Slides kann die Z‑Reihenfolge von Shapes über die Methode [ShapeCollection.reorder](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#reorder) festgelegt werden. Dazu rufen Sie diese Methode aus der Liste der Präsentationsfolien auf und übergeben die Shape‑Referenz sowie deren Reihenfolge‑Nummer. Auf diese Weise lässt sich ein Shape in den Vordergrund oder in den Hintergrund der Folie verschieben. Diese Funktion ist besonders nützlich, wenn Sie ein Wasserzeichen vor die übrigen Inhalte der Präsentation stellen möchten:
```php
$shapeCount = java_values($slide->getShapes()->size());
$slide->getShapes()->reorder($shapeCount - 1, $watermarkShape);
```


### **Wasserzeichen‑Drehung festlegen**

Im Folgenden ein Code‑Beispiel, wie Sie die Drehung des Wasserzeichens anpassen können, sodass es diagonal über die Folie positioniert wird:
```php
$diagonalAngle = atan($slideWidth / $slideHeight) * 180 / M_PI;

$watermarkShape->setRotation($diagonalAngle);
```


### **Einen Namen für ein Wasserzeichen festlegen**

Aspose.Slides ermöglicht das Setzen eines Shape‑Namens. Durch die Verwendung des Shape‑Namens können Sie das Shape später wiederfinden, um es zu ändern oder zu löschen. Um den Namen des Wasserzeichen‑Shapes festzulegen, weisen Sie ihn der Methode [AutoShape.setName](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setName) zu:
```php
$watermarkShape->setName("watermark");
```


### **Ein Wasserzeichen entfernen**

Um das Wasserzeichen‑Shape zu entfernen, verwenden Sie die Methode [AutoShape.getName](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getName), um es in den Folien‑Shapes zu finden. Anschließend übergeben Sie das Wasserzeichen‑Shape an die Methode [ShapeCollection.remove](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#remove):
```php
$slideShapes = $slide->getShapes()->toArray();
foreach ($slideShapes as $shape) {
    if ($shape->getName() === "watermark") {
        $slide->getShapes()->remove($shape);
    }
}
```


## **FAQ**

**Was ist ein Wasserzeichen und warum sollte ich es verwenden?**

Ein Wasserzeichen ist ein Text‑ oder Bild‑Overlay, das auf Folien angewendet wird, um geistiges Eigentum zu schützen, die Markenbekanntheit zu steigern oder die unbefugte Nutzung von Präsentationen zu verhindern.

**Kann ich ein Wasserzeichen zu allen Folien einer Präsentation hinzufügen?**

Ja, Aspose.Slides ermöglicht das programmgesteuerte Hinzufügen eines Wasserzeichens zu jeder Folie einer Präsentation. Sie können über alle Folien iterieren und die Wasserzeichen‑Einstellungen individuell anwenden.

**Wie kann ich die Transparenz des Wasserzeichens anpassen?**

Sie können die Transparenz des Wasserzeichens ändern, indem Sie die Füll‑Einstellungen ([getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getfillformat/)) des Shapes anpassen. So bleibt das Wasserzeichen dezent und lenkt nicht vom Folieninhalt ab.

**Welche Bildformate werden für Wasserzeichen unterstützt?**

Aspose.Slides unterstützt verschiedene Bildformate wie PNG, JPEG, GIF, BMP, SVG und weitere.

**Kann ich die Schriftart und den Stil eines Text‑Wasserzeichens anpassen?**

Ja, Sie können jede Schriftart, Größe und jeden Stil wählen, um das Design Ihrer Präsentation zu ergänzen und Marken‑Konsistenz zu wahren.

**Wie ändere ich die Position oder Ausrichtung eines Wasserzeichens?**

Sie können die Position und Ausrichtung des Wasserzeichens programmgesteuert ändern, indem Sie die Koordinaten, Größe und Drehungs‑Eigenschaften des Shapes anpassen.