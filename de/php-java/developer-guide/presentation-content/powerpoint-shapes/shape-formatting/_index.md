---
title: PowerPoint-Formen in PHP formatieren
linktitle: Formformatierung
type: docs
weight: 20
url: /de/php-java/shape-formatting/
keywords:
- Form formatieren
- Linie formatieren
- Skizze-Effekt
- Skizzenformenlinie
- Verbindungsstil formatieren
- Verlaufsfüllung
- Musterfüllung
- Bildfüllung
- Texturfüllung
- Einfarbige Füllung
- Formen-Transparenz
- Schwarz-Weiß-Darstellung von Formen
- Graustufen-Darstellung von Formen
- Form drehen
- 3D-Kanteneffekt
- 3D-Drehungseffekt
- Formatierung zurücksetzen
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint-Formen in PHP mit Aspose.Slides formatieren – füllen, Linien und Effekt‑Stile für PPT-, PPTX- und ODP-Dateien präzise und vollständig steuern."
---
## **Einführung**

In PowerPoint können Sie Formen zu Folien hinzufügen. Da Formen aus Linien bestehen, können Sie sie formatieren, indem Sie deren Konturen modifizieren oder Effekte darauf anwenden. Zusätzlich können Sie Formen formatieren, indem Sie Einstellungen festlegen, die steuern, wie deren Innenbereiche gefüllt werden.

![Form-Formatierung in PowerPoint](format-shape-powerpoint.png)

Aspose.Slides für PHP via Java bietet Klassen und Methoden, mit denen Sie Formen mithilfe derselben Optionen formatieren können, die in PowerPoint verfügbar sind.

## **Linien formatieren**

Mit Aspose.Slides können Sie für eine Form einen benutzerdefinierten Linienstil festlegen. Die folgenden Schritte beschreiben das Vorgehen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Klasse.  
1. Holen Sie sich eine Referenz zu einer Folie anhand ihres Index.  
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) hinzu.  
1. Setzen Sie den [Linienstil](https://reference.aspose.com/slides/php-java/aspose.slides/linestyle/) der Form.  
1. Legen Sie die Linienbreite fest.  
1. Setzen Sie den [Strichart](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/) der Linie.  
1. Legen Sie die Linienfarbe für die Form fest.  
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Der folgende PHP‑Code zeigt, wie ein Rechteck‑`AutoShape` formatiert wird:

```php
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei repräsentiert.
$presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    $slide = $presentation->getSlides()->get_Item(0);

    // Fügen Sie eine AutoShape vom Typ Rechteck hinzu.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

    // Setzen Sie die Füllfarbe für die Rechteckform.
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    // Anwenden der Formatierung auf die Linien des Rechtecks.
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);

    // Setzen Sie die Farbe für die Linie des Rechtecks.
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // Speichern Sie die PPTX-Datei auf dem Datenträger.
    $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das Ergebnis:

![Die formatierten Linien in der Präsentation](formatted-lines.png)

## **Skizze‑Effekte auf Formlinien anwenden**

Ein Skizze‑Effekt lässt eine Formlinie handgezeichnet erscheinen. Verwenden Sie [Shape.getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/), um auf die Linieneinstellungen zuzugreifen, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/), um auf die Skizze‑Einstellungen zuzugreifen, und [SketchFormat.setSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/), um einen Wert aus der Aufzählung [LineSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/) auszuwählen.

Der folgende PHP‑Code zeigt, wie der Effekt [LineSketchType.Curved](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/) angewendet, der explizit zugewiesene Wert gelesen und der Effekt mit [LineSketchType.None](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/) entfernt wird:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

    // Greifen Sie auf das Linienformat der Form und dessen Skizzenformat zu.
    $sketchFormat = $shape->getLineFormat()->getSketchFormat();

    // Wenden Sie einen Skizze-Effekt an.
    $sketchFormat->setSketchType(LineSketchType::Curved);

    // Lesen Sie den direkt der Form zugewiesenen Skizze-Effekt.
    $explicitSketchType = $sketchFormat->getSketchType();
    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;

    // Entfernen Sie den Skizze-Effekt.
    $sketchFormat->setSketchType(LineSketchType::None);
} finally {
    $presentation->dispose();
}
```

Der von [SketchFormat.getSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/) zurückgegebene Wert repräsentiert die direkt an die Form zugewiesene Einstellung. Wenn die Linienformatierung von einem Design, einer Master‑Folien‑ oder Layout‑Folie geerbt werden kann, verwenden Sie [LineFormat.getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/), greifen Sie auf die `getSketchFormat`‑Methode des zurückgegebenen Objekts zu und lesen dessen `getSketchType`‑Wert. Der effektive Wert spiegelt die Formatierung wider, die nach Auflösung der Vererbung tatsächlich angewendet wird:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $lineFormat = $shape->getLineFormat();

    $explicitSketchType = $lineFormat->getSketchFormat()->getSketchType();
    $effectiveLineFormat = $lineFormat->getEffective();
    $effectiveSketchType = $effectiveLineFormat->getSketchFormat()->getSketchType();

    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;
    echo "Effective sketch type: " . $effectiveSketchType . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Verbindungsstile formatieren**

Hier sind die drei Optionen für den Verbindungstyp:

* Round
* Miter
* Bevel

Standardmäßig verwendet PowerPoint beim Verbinden zweier Linien in einem Winkel (z. B. an einer Form‑Ecke) die Einstellung **Round**. Wenn Sie jedoch eine Form mit scharfen Winkeln zeichnen, bevorzugen Sie möglicherweise die Option **Miter**.

![Der Verbindungsstil in der Präsentation](join-style-powerpoint.png)

Der folgende PHP‑Code zeigt, wie drei Rechtecke (wie im Bild oben) mit den Verbindungstyp‑Einstellungen Miter, Bevel und Round erstellt wurden:

```php
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei repräsentiert.
$presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    $slide = $presentation->getSlides()->get_Item(0);

    // Fügen Sie drei AutoShapes vom Typ Rechteck hinzu.
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    // Setzen Sie die Füllfarbe für jede Rechteckform.
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

    // Setzen Sie die Linienbreite.
    $shape1->getLineFormat()->setWidth(15);
    $shape2->getLineFormat()->setWidth(15);
    $shape3->getLineFormat()->setWidth(15);

    // Setzen Sie die Farbe für die Linie jedes Rechtecks.
    $shape1->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape3->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // Setzen Sie den Verbindungsstil.
    $shape1->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
    $shape2->getLineFormat()->setJoinStyle(LineJoinStyle::Bevel);
    $shape3->getLineFormat()->setJoinStyle(LineJoinStyle::Round);

    // Fügen Sie jedem Rechteck Text hinzu.
    $shape1->getTextFrame()->setText("Miter Join Style");
    $shape2->getTextFrame()->setText("Bevel Join Style");
    $shape3->getTextFrame()->setText("Round Join Style");

    // Speichern Sie die PPTX-Datei auf dem Datenträger.
    $presentation->save("join_styles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Verlauffüllung**

In PowerPoint ist die Verlauffüllung eine Formatierungsoption, mit der Sie einem Objekt einen kontinuierlichen Farbübergang zuweisen können. Zum Beispiel können Sie zwei oder mehr Farben so anwenden, dass die eine allmählich in die andere übergeht.

So wenden Sie eine Verlauffüllung auf eine Form mit Aspose.Slides an:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Klasse.  
1. Holen Sie sich eine Referenz zu einer Folie anhand ihres Index.  
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) hinzu.  
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) der Form auf `Gradient`.  
1. Fügen Sie Ihre beiden bevorzugten Farben mit definierten Positionen mittels der `add`‑Methoden der Farb‑Stopp‑Sammlung hinzu, die von der Klasse [GradientFormat](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/) bereitgestellt wird.  
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Der folgende PHP‑Code demonstriert, wie ein Verlaufseffekt auf eine Ellipse angewendet wird:

```php
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei repräsentiert.
$presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    $slide = $presentation->getSlides()->get_Item(0);

    // Fügen Sie eine AutoShape vom Typ Ellipse hinzu.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

    // Wenden Sie eine Verlaufsformatierung auf die Ellipse an.
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);

    // Setzen Sie die Richtung des Farbverlaufs.
    $shape->getFillFormat()->getGradientFormat()->setGradientDirection(GradientDirection::FromCorner2);

    // Fügen Sie zwei Verlaufspunkte hinzu.
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0, PresetColor::Red);

    // Speichern Sie die PPTX-Datei auf dem Datenträger.
    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das Ergebnis:

![Die Ellipse mit Verlauffüllung](gradient-fill.png)

Wenn ein Verlauf in einem exportierten Bild anders aussieht als in PowerPoint, siehe [Wählen Sie einen Verlauf‑Rendering‑Stil](/slides/de/php-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Sie können einen Rendering‑Stil auswählen, ohne die im Dokument gespeicherte Verlauffüllung zu ändern.

## **Musterfüllung**

In PowerPoint ist die Musterfüllung eine Formatierungsoption, mit der Sie ein zweifarbiges Design – z. B. Punkte, Streifen, Kreuzschraffuren oder Karos – auf eine Form anwenden können. Sie können für den Vorder‑ und Hintergrund des Musters eigene Farben festlegen.

Aspose.Slides bietet über 45 vordefinierte Musterstile, die Sie auf Formen anwenden können, um die visuelle Attraktivität Ihrer Präsentationen zu erhöhen. Auch nach Auswahl eines vordefinierten Musters können Sie die genauen Farben festlegen, die verwendet werden sollen.

So wenden Sie eine Musterfüllung auf eine Form mit Aspose.Slides an:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Klasse.  
1. Holen Sie sich eine Referenz zu einer Folie anhand ihres Index.  
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) hinzu.  
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) der Form auf `Pattern`.  
1. Wählen Sie einen Musterstil aus den vordefinierten Optionen.  
1. Setzen Sie die [Hintergrundfarbe](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getBackColor) des Musters.  
1. Setzen Sie die [Vordergrundfarbe](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getForeColor) des Musters.  
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Der folgende PHP‑Code demonstriert, wie eine Musterfüllung auf ein Rechteck angewendet wird:

```php
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei repräsentiert.
$presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    $slide = $presentation->getSlides()->get_Item(0);

    // Fügen Sie eine AutoShape vom Typ Rechteck hinzu.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Setzen Sie den Fülltyp auf Pattern.
    $shape->getFillFormat()->setFillType(FillType::Pattern);

    // Setzen Sie den Musterstil.
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);

    // Setzen Sie die Hintergrund- und Vordergrundfarben des Musters.
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    // Speichern Sie die PPTX-Datei auf dem Datenträger.
    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das Ergebnis:

![Das Rechteck mit Musterfüllung](pattern-fill.png)

## **Bildfüllung**

In PowerPoint ist die Bildfüllung eine Formatierungsoption, die es ermöglicht, ein Bild in eine Form zu integrieren – das Bild dient effektiv als Hintergrund der Form.

So verwenden Sie Aspose.Slides, um einer Form eine Bildfüllung zuzuweisen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Klasse.  
1. Holen Sie sich eine Referenz zu einer Folie anhand ihres Index.  
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) hinzu.  
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) der Form auf `Picture`.  
1. Setzen Sie den Bildfüllungsmodus auf `Tile` (oder einen anderen gewünschten Modus).  
1. Erzeugen Sie ein [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/)‑Objekt aus dem Bild, das Sie verwenden möchten.  
1. Übergießen Sie das Bild an die Methode `SlidesPicture.setImage`.  
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Nehmen wir an, wir haben die Datei „lotus.png“ mit folgendem Bild:

![Das Lotus‑Bild](lotus.png)

Der folgende PHP‑Code demonstriert, wie eine Form mit dem Bild gefüllt wird:

```php
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei repräsentiert.
$presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    $slide = $presentation->getSlides()->get_Item(0);

    // Fügen Sie eine AutoShape vom Typ Rechteck hinzu.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

    // Setzen Sie den Fülltyp auf Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Setzen Sie den Bildfüllungsmodus.
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    // Laden Sie ein Bild und fügen Sie es zu den Präsentationsressourcen hinzu.
    $image = Images::fromFile("lotus.png");
    $picture = $presentation->getImages()->addImage($image);
    $image->dispose();

    // Setzen Sie das Bild.
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);

    // Speichern Sie die PPTX-Datei auf dem Datenträger.
    $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das Ergebnis:

![Die Form mit Bildfüllung](picture-fill.png)

### **Bild kacheln als Textur**

Wenn Sie ein gekacheltes Bild als Textur festlegen und das Kachel‑Verhalten anpassen möchten, können Sie die folgenden Methoden der Klasse [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) verwenden:

- [setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode): Setzt den Bildfüllungsmodus – entweder `Tile` oder `Stretch`.  
- [setTileAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileAlignment): Gibt die Ausrichtung der Kacheln innerhalb der Form an.  
- [setTileFlip](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileFlip): Steuert, ob die Kachel horizontal, vertikal oder beide Richtungen gespiegelt wird.  
- [setTileOffsetX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetX): Legt den horizontalen Versatz der Kachel (in Punkten) vom Ursprung der Form fest.  
- [setTileOffsetY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetY): Legt den vertikalen Versatz der Kachel (in Punkten) vom Ursprung der Form fest.  
- [setTileScaleX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleX): Definiert den horizontalen Maßstab der Kachel als Prozentsatz.  
- [setTileScaleY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleY): Definiert den vertikalen Maßstab der Kachel als Prozentsatz.

Der folgende Code‑Auszug zeigt, wie ein Rechteck mit gekachelter Bildfüllung erstellt und Kachel‑Optionen konfiguriert werden:

```php
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei repräsentiert.
$presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    $firstSlide = $presentation->getSlides()->get_Item(0);

    // Fügen Sie eine AutoShape vom Typ Rechteck hinzu.
    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

    // Setzen Sie den Fülltyp der Form auf Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Laden Sie das Bild und fügen Sie es zu den Präsentationsressourcen hinzu.
    $sourceImage = Images::fromFile("lotus.png");
    $presentationImage = $presentation->getImages()->addImage($sourceImage);
    $sourceImage->dispose();

    // Ordnen Sie das Bild der Form zu.
    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);

    // Konfigurieren Sie den Bildfüllungsmodus und die Kachel‑Eigenschaften.
    $pictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $pictureFillFormat->setTileOffsetX(-32);
    $pictureFillFormat->setTileOffsetY(-32);
    $pictureFillFormat->setTileScaleX(50);
    $pictureFillFormat->setTileScaleY(50);
    $pictureFillFormat->setTileAlignment(RectangleAlignment::BottomRight);
    $pictureFillFormat->setTileFlip(TileFlip::FlipBoth);

    // Speichern Sie die PPTX-Datei auf dem Datenträger.
    $presentation->save("tile.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das Ergebnis:

![Die Kachel‑Optionen](tile-options.png)

## **Einfarbige Füllung**

In PowerPoint ist die einfarbige Füllung eine Formatierungsoption, die eine Form mit einer einzigen, gleichmäßigen Farbe füllt. Dieser einfarbige Hintergrund wird ohne Verläufe, Texturen oder Muster angewendet.

So wenden Sie eine einfarbige Füllung auf eine Form mit Aspose.Slides an:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Klasse.  
1. Holen Sie sich eine Referenz zu einer Folie anhand ihres Index.  
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) hinzu.  
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) der Form auf `Solid`.  
1. Weisen Sie der Form Ihre bevorzugte Füllfarbe zu.  
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Der folgende PHP‑Code demonstriert, wie eine einfarbige Füllung auf ein Rechteck in einer PowerPoint‑Folien‑Präsentation angewendet wird:

```php
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei repräsentiert.
$presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    $slide = $presentation->getSlides()->get_Item(0);

    // Fügen Sie eine AutoShape vom Typ Rechteck hinzu.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Setzen Sie den Fülltyp auf Solid.
    $shape->getFillFormat()->setFillType(FillType::Solid);

    // Setzen Sie die Füllfarbe.
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    // Speichern Sie die PPTX-Datei auf dem Datenträger.
    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das Ergebnis:

![Die Form mit einfarbiger Füllung](solid-color-fill.png)

## **Transparenz festlegen**

In PowerPoint können Sie bei einer einfarbigen, Verlauf‑, Bild‑ oder Textur‑Füllung für Formen auch einen Transparenz‑Wert festlegen, um die Undurchsichtigkeit der Füllung zu steuern. Ein höherer Transparenz‑Wert macht die Form durchsichtiger, sodass der Hintergrund oder darunter liegende Objekte teilweise sichtbar werden.

Aspose.Slides ermöglicht das Festlegen des Transparenz‑Werts, indem Sie den Alpha‑Wert in der für die Füllung verwendeten Farbe anpassen. So gehen Sie vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Klasse.  
1. Holen Sie sich eine Referenz zu einer Folie anhand ihres Index.  
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) hinzu.  
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) auf `Solid`.  
1. Verwenden Sie `Color`, um eine Farbe mit Transparenz zu definieren (die `alpha`‑Komponente steuert die Transparenz).  
1. Speichern Sie die Präsentation.

Der folgende PHP‑Code demonstriert, wie eine transparente Füllfarbe auf ein Rechteck angewendet wird:

```php
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei repräsentiert.
$presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    $slide = $presentation->getSlides()->get_Item(0);

    // Fügen Sie eine solide Rechteck‑AutoShape hinzu.
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Fügen Sie eine transparente Rechteck‑AutoShape über der soliden Form hinzu.
    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", 255, 255, 0, 204));

    // Speichern Sie die PPTX-Datei auf dem Datenträger.
    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das Ergebnis:

![Die transparente Form](shape-transparency.png)

## **Formen drehen**

Aspose.Slides ermöglicht das Drehen von Formen in PowerPoint‑Präsentationen. Dies kann nützlich sein, wenn visuelle Elemente mit bestimmten Ausrichtungs‑ oder Design‑Anforderungen positioniert werden sollen.

So drehen Sie eine Form auf einer Folie:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Klasse.  
1. Holen Sie sich eine Referenz zu einer Folie anhand ihres Index.  
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) hinzu.  
1. Setzen Sie die Drehungs‑Eigenschaft der Form auf den gewünschten Winkel.  
1. Speichern Sie die Präsentation.

Der folgende PHP‑Code demonstriert, wie eine Form um 5 Grad gedreht wird:

```php
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei repräsentiert.
$presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    $slide = $presentation->getSlides()->get_Item(0);

    // Fügen Sie eine AutoShape vom Typ Rechteck hinzu.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Drehen Sie die Form um 5 Grad.
    $shape->setRotation(5);

    // Speichern Sie die PPTX-Datei auf dem Datenträger.
    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das Ergebnis:

![Die Formdrehung](shape-rotation.png)

## **3D‑Kanteneffekte hinzufügen**

Aspose.Slides ermöglicht das Anwenden von 3D‑Kanten‑Effekten auf Formen, indem die Eigenschaften ihres [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/) konfiguriert werden.

So fügen Sie einer Form 3D‑Kanten‑Effekte hinzu:

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Klasse.  
1. Holen Sie sich eine Referenz zu einer Folie anhand ihres Index.  
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) hinzu.  
1. Konfigurieren Sie das [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/) der Form, um die Kanten‑Einstellungen zu definieren.  
1. Speichern Sie die Präsentation.

Der folgende PHP‑Code zeigt, wie 3D‑Kanten‑Effekte einer Form hinzugefügt werden:

```php
// Erstellen Sie eine Instanz der Presentation-Klasse.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Fügen Sie der Folie eine Form hinzu.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $shape->getLineFormat()->setWidth(2.0);

    // Setzen Sie die ThreeDFormat‑Eigenschaften der Form.
    $shape->getThreeDFormat()->setDepth(4);
    $shape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $shape->getThreeDFormat()->getBevelTop()->setHeight(6);
    $shape->getThreeDFormat()->getBevelTop()->setWidth(6);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::ThreePt);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);

    // Speichern Sie die Präsentation als PPTX‑Datei.
    $presentation->save("3D_bevel_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das Ergebnis:

![Der 3D‑Kanten‑Effekt](3D-bevel-effect.png)

## **3D‑Drehungseffekte hinzufügen**

Aspose.Slides ermöglicht das Anwenden von 3D‑Drehungs‑Effekten auf Formen, indem die Eigenschaften ihres [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/) konfiguriert werden.

So wenden Sie eine 3D‑Drehung auf eine Form an:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Klasse.  
1. Holen Sie sich eine Referenz zu einer Folie anhand ihres Index.  
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) hinzu.  
1. Verwenden Sie [setCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setCameraType) und [setLightType](https://reference.aspose.com/slides/php-java/aspose.slides/lightrig/#setLightType), um die 3D‑Drehung zu definieren.  
1. Speichern Sie die Präsentation.

Der folgende PHP‑Code demonstriert, wie 3D‑Drehungs‑Effekte einer Form zugewiesen werden:

```php
// Erstellen Sie eine Instanz der Presentation-Klasse.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $autoShape->getTextFrame()->setText("Hello, Aspose!");

    $autoShape->getThreeDFormat()->setDepth(6);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(40, 35, 20);
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);

    // Speichern Sie die Präsentation als PPTX-Datei.
    $presentation->save("3D_rotation_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das Ergebnis:

![Der 3D‑Drehungs‑Effekt](3D-rotation-effect.png)

## **Steuerung der Schwarz‑Weiß‑Darstellung für Formen**

Die Methode [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setBlackWhiteMode) legt fest, wie eine einzelne Form gerendert wird, wenn eine Präsentation im Schwarz‑Weiß‑Modus angezeigt oder verarbeitet wird. Sie aktiviert den Schwarz‑Weiß‑Modus nicht selbst und ändert die Füll‑, Linien‑ oder sonstige Formatierung der Form im normalen Farbmodus nicht.

Verwenden Sie einen Wert aus der Klasse [BlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/blackwhitemode/), um das gewünschte Verhalten auszuwählen. Zum Beispiel lässt `Automatic` die Rendering‑Anwendung die Konvertierung wählen, `Gray` und `LightGray` verwenden Graufärbung, `BlackWhite` nutzt ausschließlich Schwarz und Weiß, `Black` und `White` erzwingen eine einzelne Farbe, `Color` bewahrt die normale Farbgebung, und `Hidden` lässt die Form im Schwarz‑Weiß‑Modus wegfallen. `NotDefined` bedeutet, dass kein Form‑Ebene‑Modus zugewiesen ist.

Der folgende PHP‑Code erstellt eine farbige Form und lässt sie im Schwarz‑Weiß‑Anzeige‑Modus grau erscheinen:

```php
use aspose\slides\BlackWhiteMode;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $orange = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($orange);

    // Behalten Sie die orange Füllung im Farbmodus, aber rendern Sie die Form mit grauer Färbung im Schwarz-Weiß-Modus.
    $shape->setBlackWhiteMode(BlackWhiteMode::Gray);

    $presentation->save("shape_black_white_mode.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Im normalen Farbmodus behält das Rechteck seine orange‑Füllung. Im Schwarz‑Weiß‑Anzeige‑Workflow wird es grau dargestellt, weil sein Modus auf `Gray` gesetzt ist. So können Sie eine Voll‑Farben‑Folien‑Präsentation beibehalten und gleichzeitig ein separates Erscheinungsbild für den Druck, die Vorschau oder andere Workflows definieren, die die Schwarz‑Weiß‑Anzeige‑Einstellungen der Präsentation berücksichtigen.

## **Formatierung zurücksetzen**

Der folgende Java‑Code zeigt, wie die Formatierung einer Folie zurückgesetzt und die Position, Größe und Formatierung aller Formen mit Platzhaltern auf dem [LayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/) auf deren Standard‑Einstellungen zurückgesetzt werden:

```php
$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        // Setzen Sie jede Form auf der Folie zurück, die einen Platzhalter im Layout hat.
        $slide->reset();
    }
    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Wirkt sich die Formatierung von Formen auf die endgültige Dateigröße der Präsentation aus?**

Nur minimal. Eingebettete Bilder und Medien belegen den größten Teil des Speicherplatzes, während Form‑Parameter wie Farben, Effekte und Verläufe als Metadaten gespeichert werden und praktisch keinen zusätzlichen Speicherbedarf verursachen.

**Wie kann ich Formen auf einer Folie erkennen, die identische Formatierungen besitzen, um sie zu gruppieren?**

Vergleichen Sie die wichtigsten Formatierungseigenschaften jeder Form – Füll‑, Linien‑ und Effekt‑Einstellungen. Stimmen alle entsprechenden Werte überein, behandeln Sie deren Stile als identisch und gruppieren Sie diese Formen logisch, was die spätere Stilverwaltung vereinfacht.

**Kann ich einen Satz benutzerdefinierter Form‑Stile in einer separaten Datei speichern, um ihn in anderen Präsentationen wiederzuverwenden?**

Ja. Speichern Sie Beispiel‑Formen mit den gewünschten Stilen in einem Vorlagen‑Slide‑Deck oder einer .POTX‑Vorlagendatei. Beim Erstellen einer neuen Präsentation öffnen Sie die Vorlage, klonen die gewünschten gestylten Formen und wenden deren Formatierung dort an, wo sie benötigt wird.