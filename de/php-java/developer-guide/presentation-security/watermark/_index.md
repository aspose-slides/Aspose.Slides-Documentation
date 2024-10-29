---
title: Wasserzeichen
type: docs
weight: 40
url: /de/php-java/watermark/
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

**Ein Wasserzeichen** in einer Präsentation ist ein Text- oder Bildstempel, der auf einer Folie oder auf allen Folien der Präsentation verwendet wird. Normalerweise wird ein Wasserzeichen verwendet, um anzuzeigen, dass die Präsentation ein Entwurf ist (z.B. ein "Entwurf"-Wasserzeichen), dass sie vertrauliche Informationen enthält (z.B. ein "Vertraulich"-Wasserzeichen), um anzugeben, zu welchem Unternehmen sie gehört (z.B. ein "Unternehmensname"-Wasserzeichen), um den Autor der Präsentation zu identifizieren usw. Ein Wasserzeichen hilft, Urheberrechtsverletzungen zu verhindern, indem angezeigt wird, dass die Präsentation nicht kopiert werden sollte. Wasserzeichen werden sowohl im PowerPoint- als auch im OpenOffice-Präsentationsformat verwendet. In Aspose.Slides können Sie ein Wasserzeichen zu PowerPoint-PPT-, PPTX- und OpenOffice-ODP-Dateiformaten hinzufügen.

In [**Aspose.Slides**](https://products.aspose.com/slides/php-java/) gibt es verschiedene Möglichkeiten, Wasserzeichen in PowerPoint- oder OpenOffice-Dokumenten zu erstellen und deren Design und Verhalten zu ändern. Der gemeinsame Aspekt besteht darin, dass Sie zur Hinzufügung von Textwasserzeichen die [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) Klasse verwenden sollten, und um Bildwasserzeichen hinzuzufügen, verwenden Sie die [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) Klasse oder fügen Sie ein Bild zu einer Wasserzeichenform hinzu. `PictureFrame` implementiert die [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) Klasse, die Ihnen alle flexiblen Einstellungen des Formobjekts zur Verfügung stellt. Da `ITextFrame` keine Form ist und ihre Einstellungen begrenzt sind, wird sie in ein [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) Objekt eingewickelt.

Es gibt zwei Möglichkeiten, ein Wasserzeichen anzuwenden: auf eine einzelne Folie oder auf alle Präsentationsfolien. Der Folienmaster wird verwendet, um ein Wasserzeichen auf allen Folien der Präsentation anzuwenden – das Wasserzeichen wird zum Folienmaster hinzugefügt, dort vollständig gestaltet und auf alle Folien angewendet, ohne das Recht zur Bearbeitung des Wasserzeichens auf einzelnen Folien zu beeinträchtigen.

Ein Wasserzeichen wird normalerweise als nicht bearbeitbar für andere Benutzer betrachtet. Um zu verhindern, dass das Wasserzeichen (oder besser gesagt die Elternelementform des Wasserzeichens) bearbeitet wird, bietet Aspose.Slides eine Funktion zur Formverriegelung. Eine bestimmte Form kann auf einer normalen Folie oder auf einem Folienmaster gesperrt werden. Wenn die Wasserzeichenform auf dem Folienmaster gesperrt ist, wird sie auf allen Präsentationsfolien gesperrt.

Sie können dem Wasserzeichen einen Namen geben, damit Sie es in Zukunft finden und löschen können, wenn Sie es in den Formen der Folie nach Namen suchen möchten.

Sie können das Wasserzeichen nach Belieben gestalten; in der Regel gibt es jedoch häufige Merkmale in Wasserzeichen, wie z.B. zentrierte Ausrichtung, Drehung, Vordergrundposition usw. Im Folgenden werden wir betrachten, wie man diese in den Beispielen verwendet.

## **Textwasserzeichen**

### **Fügen Sie ein Textwasserzeichen zu einer Folie hinzu**

Um ein Textwasserzeichen in PPT, PPTX oder ODP hinzuzufügen, können Sie zuerst eine Form zur Folie hinzufügen und dann einen Textrahmen zu dieser Form hinzufügen. Der Textrahmen wird durch die [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) Klasse dargestellt. Dieser Typ erbt nicht von [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/), die eine breite Palette von Eigenschaften für die flexible Positionierung des Wasserzeichens hat. Daher wird das [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) Objekt in ein [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) Objekt eingewickelt. Um den Wasserzeichentext zur Form hinzuzufügen, verwenden Sie die [addTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#addTextFrame) Methode, wie unten gezeigt.

```php
$watermarkText = "VERTRAULICH";

$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$watermarkShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```

{{% alert color="primary" title="Siehe auch" %}} 
- [Wie man die TextFrame-Klasse verwendet](/slides/de/php-java/text-formatting/)
{{% /alert %}}

### **Fügen Sie ein Textwasserzeichen zu einer Präsentation hinzu**

Wenn Sie ein Textwasserzeichen zur gesamten Präsentation (d.h. allen Folien gleichzeitig) hinzufügen möchten, fügen Sie es zum [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) hinzu. Die restliche Logik ist die gleiche wie beim Hinzufügen eines Wasserzeichens zu einer einzelnen Folie – erstellen Sie ein [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) Objekt und fügen Sie dann das Wasserzeichen mit der [addTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#addTextFrame) Methode hinzu.

```php
$watermarkText = "VERTRAULICH";

$presentation = new Presentation();
$masterSlide = $presentation->getMasters()->get_Item(0);

$watermarkShape = $masterSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```

{{% alert color="primary" title="Siehe auch" %}} 
- [Wie man den Folienmaster verwendet](/slides/de/php-java/slide-master/)
{{% /alert %}}

### **Setzen Sie die Transparenz der Wasserzeichenform**

Standardmäßig ist die Rechteckform mit Füll- und Linienfarben gestaltet. Die folgenden Codezeilen machen die Form transparent.

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

Um die Farbe des Wasserzeichentextes festzulegen, verwenden Sie diesen Code:

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

## **Sperren Sie ein Wasserzeichen vor der Bearbeitung**

Wenn es notwendig ist, ein Wasserzeichen vor der Bearbeitung zu schützen, verwenden Sie die [AutoShape.getAutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#getAutoShapeLock) Methode auf der Form. Mit dieser Eigenschaft können Sie die Form vor Auswahl, Größenänderung, Neupositionierung, Gruppierung mit anderen Elementen, das Sperren ihres Textes vor der Bearbeitung und vieles mehr schützen:

```php
// Sperren Sie die Wasserzeichenform vor Änderungen
$watermarkShape->getAutoShapeLock()->setSelectLocked(true);
$watermarkShape->getAutoShapeLock()->setSizeLocked(true);
$watermarkShape->getAutoShapeLock()->setTextLocked(true);
$watermarkShape->getAutoShapeLock()->setPositionLocked(true);
$watermarkShape->getAutoShapeLock()->setGroupingLocked(true);
```

## **Bringen Sie ein Wasserzeichen in den Vordergrund**

In Aspose.Slides kann die Z-Reihenfolge von Formen über die [ShapeCollection.reorder](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#reorder) Methode festgelegt werden. Dazu müssen Sie diese Methode aus der Folienliste der Präsentation aufrufen und die Formreferenz und ihre Reihenfolgenummer an die Methode übergeben. Auf diese Weise ist es möglich, eine Form in den Vordergrund zu bringen oder sie an den Hintergrund der Folie zu senden. Diese Funktion ist besonders nützlich, wenn Sie ein Wasserzeichen vor der Präsentation platzieren müssen:

```php
$shapeCount = java_values($slide->getShapes()->size());
$slide->getShapes()->reorder($shapeCount - 1, $watermarkShape);
```

## **Setzen Sie die Wasserzeichenrotation**

Hier ist ein Codebeispiel, wie man die Rotation des Wasserzeichens so anpasst, dass es diagonal über die Folie positioniert wird:

```php
$diagonalAngle = atan($slideWidth / $slideHeight) * 180 / M_PI;

$watermarkShape->setRotation($diagonalAngle);
```

## **Setzen Sie einen Namen für ein Wasserzeichen**

Aspose.Slides ermöglicht es Ihnen, den Namen einer Form festzulegen. Mit dem Formnamen können Sie in Zukunft darauf zugreifen, um es zu ändern oder zu löschen. Um den Namen der Wasserzeichenform festzulegen, weisen Sie ihn der [AutoShape.setName](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setName) Methode zu:

```php
$watermarkShape->setName("wasserzeichen");
```

## **Entfernen Sie ein Wasserzeichen**

Um die Wasserzeichenform zu entfernen, verwenden Sie die [AutoShape.getName](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getName) Methode, um es in den Folienformen zu finden. Dann übergeben Sie die Wasserzeichenform an die [ShapeCollection.remove](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#remove) Methode:

```php
$slideShapes = $slide->getShapes()->toArray();
foreach ($slideShapes as $shape) {
    if ($shape->getName() === "wasserzeichen") {
        $slide->getShapes()->remove($shape);
    }
}
```

## **Ein Live-Beispiel**

Sie möchten möglicherweise die **Aspose.Slides kostenlosen** [Wasserzeichen hinzufügen](https://products.aspose.app/slides/watermark) und [Wasserzeichen entfernen](https://products.aspose.app/slides/watermark/remove-watermark) Online-Tools ausprobieren.

![Online-Tools zum Hinzufügen und Entfernen von Wasserzeichen](online_tools.png)