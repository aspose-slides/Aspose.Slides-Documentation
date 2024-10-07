---
title: Wasserzeichen
type: docs
weight: 40
url: /php-java/watermark/
keywords:
- wasserzeichen
- wasserzeichen hinzufügen
- textwasserzeichen
- bildwasserzeichen
- PowerPoint
- präsentation
- PHP
- Java
- Aspose.Slides für PHP über Java
description: "Fügen Sie Text- und Bildwasserzeichen zu PowerPoint-Präsentationen in PHP hinzu"
---

## **Über Wasserzeichen**

**Ein Wasserzeichen** in einer Präsentation ist ein Text- oder Bildstempel, der auf einer Folie oder auf allen Folien der Präsentation verwendet wird. In der Regel wird ein Wasserzeichen verwendet, um anzuzeigen, dass die Präsentation ein Entwurf ist (z. B. ein "Entwurf"-Wasserzeichen), dass sie vertrauliche Informationen enthält (z. B. ein "Vertraulich"-Wasserzeichen), um anzugeben, welcher Firma sie gehört (z. B. ein "Firmenname"-Wasserzeichen), um den Autor der Präsentation zu identifizieren usw. Ein Wasserzeichen hilft, Urheberrechtsverletzungen zu verhindern, indem es anzeigt, dass die Präsentation nicht kopiert werden sollte. Wasserzeichen werden sowohl in PowerPoint- als auch in OpenOffice-Präsentationsformaten verwendet. In Aspose.Slides können Sie ein Wasserzeichen zu PowerPoint PPT, PPTX und OpenOffice ODP-Dateiformaten hinzufügen.

In [**Aspose.Slides**](https://products.aspose.com/slides/php-java/) gibt es verschiedene Möglichkeiten, Wasserzeichen in PowerPoint- oder OpenOffice-Dokumenten zu erstellen und deren Design und Verhalten zu modifizieren. Der gemeinsame Aspekt ist, dass Sie zum Hinzufügen von Textwasserzeichen die Klasse [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) verwenden sollten, und um Bildwasserzeichen hinzuzufügen, verwenden Sie die Klasse [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) oder füllen Sie eine Wasserzeichengeometrie mit einem Bild. `PictureFrame` implementiert die [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) Klasse, die es Ihnen ermöglicht, alle flexiblen Einstellungen des Formenobjekts zu verwenden. Da `ITextFrame` keine Geometrie ist und dessen Einstellungen begrenzt sind, wird es in ein [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) Objekt eingewickelt.

Ein Wasserzeichen kann auf zwei Arten angewendet werden: auf einer einzelnen Folie oder auf allen Präsentationsfolien. Der Slide Master wird verwendet, um ein Wasserzeichen auf allen Präsentationsfolien anzuwenden – das Wasserzeichen wird zum Slide Master hinzugefügt, dort vollständig gestaltet und auf allen Folien angewendet, ohne die Berechtigung zur Änderung des Wasserzeichens auf einzelnen Folien zu beeinträchtigen.

Ein Wasserzeichen wird normalerweise als nicht bearbeitbar für andere Benutzer betrachtet. Um zu verhindern, dass das Wasserzeichen (oder eher die übergeordnete Form des Wasserzeichens) bearbeitet wird, bietet Aspose.Slides eine Funktion zum Sperren von Formen. Eine bestimmte Form kann auf einer normalen Folie oder auf einem Slide Master gesperrt werden. Wenn die Wasserzeichengeometrie auf dem Slide Master gesperrt ist, wird sie auf allen Präsentationsfolien gesperrt sein.

Sie können dem Wasserzeichen einen Namen geben, damit Sie es in Zukunft beim Löschen anhand des Namens in den Formen der Folie finden können.

Sie können das Wasserzeichen nach Belieben gestalten; es gibt jedoch normalerweise gemeinsame Merkmale in Wasserzeichen, wie z. B. zentrierte Ausrichtung, Rotation, Position im Vordergrund usw. Wir werden betrachten, wie man diese in den folgenden Beispielen verwendet.

## **Text Wasserzeichen**

### **Fügen Sie ein Textwasserzeichen zu einer Folie hinzu**

Um ein Textwasserzeichen in PPT, PPTX oder ODP hinzuzufügen, können Sie zuerst eine Form zur Folie hinzufügen und dann einen Textrahmen zu dieser Form hinzufügen. Der Textrahmen wird durch die Klasse [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) dargestellt. Dieser Typ erbt nicht von [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/), die eine breite Palette von Eigenschaften zur flexiblen Positionierung des Wasserzeichens hat. Daher wird das [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) Objekt in ein [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) Objekt eingewickelt. Um dem Formen Wasserzeichen-Text hinzuzufügen, verwenden Sie die Methode [addTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#addTextFrame), wie unten gezeigt.

```php
$watermarkText = "VERTRAULICH";

$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$watermarkShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```

{{% alert color="primary" title="Siehe auch" %}} 
- [Wie man die TextFrame-Klasse verwendet](/slides/php-java/text-formatting/)
{{% /alert %}}

### **Fügen Sie ein Textwasserzeichen zu einer Präsentation hinzu**

Wenn Sie ein Textwasserzeichen zur gesamten Präsentation (d.h. auf allen Folien gleichzeitig) hinzufügen möchten, fügen Sie es zum [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) hinzu. Der Rest der Logik ist die gleiche wie bei der Hinzufügung eines Wasserzeichens zu einer einzelnen Folie - erstellen Sie ein [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) Objekt und fügen Sie dann das Wasserzeichen mit der Methode [addTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#addTextFrame) hinzu.

```php
$watermarkText = "VERTRAULICH";

$presentation = new Presentation();
$masterSlide = $presentation->getMasters()->get_Item(0);

$watermarkShape = $masterSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```

{{% alert color="primary" title="Siehe auch" %}} 
- [Wie man den Slide Master verwendet](/slides/php-java/slide-master/)
{{% /alert %}}

### **Setzen Sie die Transparenz der Wasserzeichengeometrie**

Standardmäßig wird die Rechtecksform mit Füll- und Linienfarben gestaltet. Die folgenden Codezeilen machen die Form transparent.

```php
$watermarkShape->getFillFormat()->setFillType(FillType::NoFill);
$watermarkShape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
```

### **Setzen Sie die Schriftart für ein Textwasserzeichen**

Sie können die Schriftart des Textwasserzeichens wie unten gezeigt ändern.

```php
$textFormat = $watermarkFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat();
$textFormat->setLatinFont(new FontData("Arial"));
$textFormat->setFontHeight(50);
```

### **Setzen Sie die Textfarbe des Wasserzeichens**

Um die Farbe des Wasserzeichen-Textes zu setzen, verwenden Sie diesen Code:

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

### **Zentrieren Sie ein Textwasserzeichen**

Es ist möglich, das Wasserzeichen auf einer Folie zu zentrieren, und dafür können Sie Folgendes tun:

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

Das Bild unten zeigt das Endergebnis.

![Das Textwasserzeichen](text_watermark.png)

## **Bildwasserzeichen**

### **Fügen Sie ein Bildwasserzeichen zu einer Präsentation hinzu**

Um ein Bildwasserzeichen zu einer Präsentationsfolie hinzuzufügen, können Sie Folgendes tun:

```php
$image = Images::fromFile("watermark.png");
$picture = $presentation->getImages()->addImage($image);
$image->dispose();

$watermarkShape->getFillFormat()->setFillType(FillType::Picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
```

## **Sperren Sie ein Wasserzeichen gegen Bearbeitung**

Falls notwendig, um ein Wasserzeichen vor Bearbeitung zu schützen, verwenden Sie die Methode [AutoShape.getAutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#getAutoShapeLock) auf der Form. Mit dieser Eigenschaft können Sie die Form davor schützen, ausgewählt, verändert, repositioniert, mit anderen Elementen gruppiert zu werden, den Text vor der Bearbeitung zu sperren und vieles mehr:

```php
// Sperren Sie die Wasserzeichengeometrie vor Änderungen
$watermarkShape->getAutoShapeLock()->setSelectLocked(true);
$watermarkShape->getAutoShapeLock()->setSizeLocked(true);
$watermarkShape->getAutoShapeLock()->setTextLocked(true);
$watermarkShape->getAutoShapeLock()->setPositionLocked(true);
$watermarkShape->getAutoShapeLock()->setGroupingLocked(true);
```

## **Bringen Sie ein Wasserzeichen in den Vordergrund**

In Aspose.Slides kann die Z-Reihenfolge von Formen über die Methode [ShapeCollection.reorder](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#reorder) festgelegt werden. Um dies zu tun, müssen Sie diese Methode aus der Präsentationsfolienliste aufrufen und die Referenz der Form und ihre Reihenfolgenummer an die Methode übergeben. Auf diese Weise ist es möglich, eine Form in den Vordergrund zu bringen oder sie in den Hintergrund der Folie zu senden. Diese Funktion ist besonders nützlich, wenn Sie ein Wasserzeichen vor der Präsentation platzieren müssen:

```php
$shapeCount = java_values($slide->getShapes()->size());
$slide->getShapes()->reorder($shapeCount - 1, $watermarkShape);
```

## **Setzen Sie die Rotation des Wasserzeichens**

Hier ist ein Codebeispiel, wie die Rotation des Wasserzeichens angepasst werden kann, damit es diagonal über die Folie positioniert wird:

```php
$diagonalAngle = atan($slideWidth / $slideHeight) * 180 / M_PI;

$watermarkShape->setRotation($diagonalAngle);
```

## **Setzen Sie einen Namen für ein Wasserzeichen**

Aspose.Slides ermöglicht es Ihnen, einen Namen für eine Form festzulegen. Mit dem Formenname können Sie in Zukunft darauf zugreifen, um sie zu ändern oder zu löschen. Um den Namen der Wasserzeichengeometrie festzulegen, weisen Sie ihn der Methode [AutoShape.setName](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setName) zu:

```php
$watermarkShape->setName("wasserzeichen");
```

## **Entfernen Sie ein Wasserzeichen**

Um die Wasserzeichengeometrie zu entfernen, verwenden Sie die Methode [AutoShape.getName](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getName), um sie in den Folienformen zu finden. Übergeben Sie dann die Wasserzeichengeometrie in die Methode [ShapeCollection.remove](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#remove):

```php
$slideShapes = $slide->getShapes()->toArray();
foreach ($slideShapes as $shape) {
    if ($shape->getName() === "wasserzeichen") {
        $slide->getShapes()->remove($shape);
    }
}
```

## **Ein Live-Beispiel**

Sie möchten vielleicht die **Aspose.Slides kostenlose** [Wasserzeichen hinzufügen](https://products.aspose.app/slides/watermark) und [Wasserzeichen entfernen](https://products.aspose.app/slides/watermark/remove-watermark) Online-Tools ausprobieren.

![Online-Tools zum Hinzufügen und Entfernen von Wasserzeichen](online_tools.png)