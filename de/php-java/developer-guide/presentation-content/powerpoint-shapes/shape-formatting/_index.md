---
title: PowerPoint-Formen in PHP formatieren
linktitle: Formformatierung
type: docs
weight: 20
url: /de/php-java/shape-formatting/
keywords:
- Form formatieren
- Linie formatieren
- Skizzen-Effekt
- Skizzenformlinie
- Verbindungsstil formatieren
- Verlaufsfüllung
- Musterfüllung
- Bildfüllung
- Texturfüllung
- Einfarbige Füllung
- Formtransparenz
- Form drehen
- 3D-Kanteneffekt
- 3D-Drehungseffekt
- Formatierung zurücksetzen
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint-Formen in PHP mit Aspose.Slides formatieren – Füll‑, Linien‑ und Effekt‑Stile für PPT-, PPTX‑ und ODP‑Dateien präzise und mit voller Kontrolle festlegen."
---
## **Einleitung**

In PowerPoint können Sie Formen zu Folien hinzufügen. Da Formen aus Linien bestehen, können Sie sie formatieren, indem Sie die Konturen ändern oder Effekte darauf anwenden. Außerdem können Sie Formen formatieren, indem Sie Einstellungen festlegen, die steuern, wie deren Innenflächen gefüllt werden.

![Formformatierung in PowerPoint](format-shape-powerpoint.png)

Aspose.Slides für PHP via Java bietet Klassen und Methoden, mit denen Sie Formen mit denselben Optionen formatieren können, die in PowerPoint verfügbar sind.

## **Linien formatieren**

Mit Aspose.Slides können Sie für eine Form einen benutzerdefinierten Linienstil festlegen. Die folgenden Schritte beschreiben das Verfahren:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/).
1. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie eine [AutoShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/) hinzu.
1. Setzen Sie den [Linienstil](https://reference.aspose.com/slides/de/php-java/aspose.slides/linestyle/) der Form.
1. Setzen Sie die Linienbreite.
1. Setzen Sie den [Strichstil](https://reference.aspose.com/slides/de/php-java/aspose.slides/linedashstyle/) der Linie.
1. Setzen Sie die Linienfarbe für die Form.
1. Speichern Sie die geänderte Präsentation als PPTX-Datei.

Der folgende PHP‑Code zeigt, wie Sie ein Rechteck‑`AutoShape` formatieren:

```php
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
$presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    $slide = $presentation->getSlides()->get_Item(0);

    // Fügen Sie eine AutoShape des Typs Rectangle hinzu.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

    // Setzen Sie die Füllfarbe für die Rechteckform.
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    // Formatieren Sie die Linien des Rechtecks.
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);

    // Setzen Sie die Farbe für die Linie des Rechtecks.
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // Speichern Sie die PPTX-Datei auf der Festplatte.
    $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das Ergebnis:

![Die formatierten Linien in der Präsentation](formatted-lines.png)

## **Skizze‑Effekte auf Formlinien anwenden**

Ein Skizze‑Effekt lässt eine Formlinie handgezeichnet erscheinen. Verwenden Sie [Shape.getLineFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/), um auf die Linieneinstellungen zuzugreifen, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/lineformat/), um auf die Skizzeeinstellungen zuzugreifen, und [SketchFormat.setSketchType](https://reference.aspose.com/slides/de/php-java/aspose.slides/sketchformat/), um einen Wert aus der Aufzählung [LineSketchType](https://reference.aspose.com/slides/de/php-java/aspose.slides/linesketchtype/) auszuwählen.

Der folgende PHP‑Code zeigt, wie man den Effekt [LineSketchType.Curved](https://reference.aspose.com/slides/de/php-java/aspose.slides/linesketchtype/) anwendet, den explizit zugewiesenen Wert ausliest und den Effekt mit [LineSketchType.None](https://reference.aspose.com/slides/de/php-java/aspose.slides/linesketchtype/) entfernt:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

    // Greifen Sie auf das Linienformat der Form und dessen Skizzenformat zu.
    $sketchFormat = $shape->getLineFormat()->getSketchFormat();

    // Wenden Sie einen Skizzen-Effekt an.
    $sketchFormat->setSketchType(LineSketchType::Curved);

    // Lesen Sie den Skizzen-Effekt, der direkt der Form zugewiesen wurde.
    $explicitSketchType = $sketchFormat->getSketchType();
    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;

    // Entfernen Sie den Skizzen-Effekt.
    $sketchFormat->setSketchType(LineSketchType::None);
} finally {
    $presentation->dispose();
}
```

Der von [SketchFormat.getSketchType](https://reference.aspose.com/slides/de/php-java/aspose.slides/sketchformat/) zurückgegebene Wert repräsentiert die direkt der Form zugewiesene Einstellung. Wenn die Linienformatierung von einem Design, einer Master‑Folie oder einer Layout‑Folie geerbt werden kann, verwenden Sie [LineFormat.getEffective](https://reference.aspose.com/slides/de/php-java/aspose.slides/lineformat/), greifen Sie auf die `getSketchFormat`‑Methode des zurückgegebenen Objekts zu und lesen Sie dessen `getSketchType`‑Wert aus. Der effektive Wert spiegelt die tatsächlich angewendete Formatierung wider, nachdem die Vererbung aufgelöst wurde:

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

* Rund
* Gehrung
* Fase

Standardmäßig verwendet PowerPoint beim Verbinden zweier Linien in einem Winkel (z. B. an einer Formkante) die Einstellung **Rund**. Wenn Sie jedoch eine Form mit scharfen Winkeln zeichnen, bevorzugen Sie möglicherweise die Einstellung **Gehrung**.

![Der Verbindungsstil in der Präsentation](join-style-powerpoint.png)

Der folgende PHP‑Code zeigt, wie drei Rechtecke (wie im obigen Bild) mit den Verbindungsstil‑Einstellungen Gehrung, Fase und Rund erstellt wurden:

```php
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
$presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    $slide = $presentation->getSlides()->get_Item(0);

    // Fügen Sie drei AutoShapes des Typs Rectangle hinzu.
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

    // Speichern Sie die PPTX-Datei auf der Festplatte.
    $presentation->save("join_styles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Verlaufsfüllung**

In PowerPoint ist die Verlaufsfüllung eine Formatierungsoption, die es ermöglicht, einer Form einen kontinuierlichen Farbverlauf zuzuweisen. Sie können beispielsweise zwei oder mehr Farben so anwenden, dass die eine allmählich in die andere übergeht.

So wenden Sie mit Aspose.Slides eine Verlaufsfüllung auf eine Form an:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/).
1. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie eine [AutoShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/) hinzu.
1. Setzen Sie das [FillType](https://reference.aspose.com/slides/de/php-java/aspose.slides/filltype/) der Form auf `Gradient`.
1. Fügen Sie mit den `add`‑Methoden der vom [GradientFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/gradientformat/) bereitgestellten Gradient‑Stop‑Sammlung Ihre beiden gewünschten Farben mit definierten Positionen hinzu.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

```php
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
$presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    $slide = $presentation->getSlides()->get_Item(0);

    // Fügen Sie eine AutoShape des Typs Ellipse hinzu.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

    // Wenden Sie eine Gradientformatierung auf die Ellipse an.
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);

    // Setzen Sie die Richtung des Gradienten.
    $shape->getFillFormat()->getGradientFormat()->setGradientDirection(GradientDirection::FromCorner2);

    // Fügen Sie zwei Gradient-Stops hinzu.
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0, PresetColor::Red);

    // Speichern Sie die PPTX-Datei auf der Festplatte.
    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das Ergebnis:

![Die Ellipse mit Verlaufsfüllung](gradient-fill.png)

## **Musterfüllung**

In PowerPoint ist die Musterfüllung eine Formatierungsoption, mit der Sie einer Form ein zweifarbiges Design – beispielsweise Punkte, Streifen, Kreuzschraffierungen oder Rautenmuster – zuweisen können. Sie können benutzerdefinierte Farben für den Vorder- und Hintergrund des Musters auswählen.

Aspose.Slides stellt über 45 vordefinierte Musterstile bereit, die Sie Formen zuweisen können, um die visuelle Attraktivität Ihrer Präsentationen zu erhöhen. Auch nach Auswahl eines vordefinierten Musters können Sie die genauen zu verwendenden Farben festlegen.

So wenden Sie mit Aspose.Slides eine Musterfüllung auf eine Form an:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/).
1. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie eine [AutoShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/) hinzu.
1. Setzen Sie das [FillType](https://reference.aspose.com/slides/de/php-java/aspose.slides/filltype/) der Form auf `Pattern`.
1. Wählen Sie einen Musterstil aus den vordefinierten Optionen.
1. Setzen Sie die [Hintergrundfarbe](https://reference.aspose.com/slides/de/php-java/aspose.slides/patternformat/#getBackColor) des Musters.
1. Setzen Sie die [Vordergrundfarbe](https://reference.aspose.com/slides/de/php-java/aspose.slides/patternformat/#getForeColor) des Musters.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

```php
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
$presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    $slide = $presentation->getSlides()->get_Item(0);

    // Fügen Sie eine AutoShape des Typs Rectangle hinzu.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Setzen Sie den Fülltyp auf Pattern.
    $shape->getFillFormat()->setFillType(FillType::Pattern);

    // Setzen Sie den Musterstil.
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);

    // Setzen Sie die Hintergrund- und Vordergrundfarben des Musters.
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    // Speichern Sie die PPTX-Datei auf der Festplatte.
    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das Ergebnis:

![Das Rechteck mit Musterfüllung](pattern-fill.png)

## **Bildfüllung**

In PowerPoint ist die Bildfüllung eine Formatierungsoption, die es ermöglicht, ein Bild in eine Form einzufügen – das Bild wird dabei effektiv als Hintergrund der Form verwendet.

So verwenden Sie Aspose.Slides, um einer Form eine Bildfüllung zuzuweisen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/).
1. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie eine [AutoShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/) hinzu.
1. Setzen Sie das [FillType](https://reference.aspose.com/slides/de/php-java/aspose.slides/filltype/) der Form auf `Picture`.
1. Setzen Sie den Bildfüllungsmodus auf `Tile` (oder einen anderen bevorzugten Modus).
1. Erstellen Sie ein [PPImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/ppimage/)‑Objekt aus dem Bild, das Sie verwenden möchten.
1. Übergeben Sie das Bild an die Methode `SlidesPicture.setImage`.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Nehmen wir an, wir haben eine Datei "lotus.png" mit folgendem Bild:

![Das Lotus‑Bild](lotus.png)

```php
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
$presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    $slide = $presentation->getSlides()->get_Item(0);

    // Fügen Sie eine AutoShape des Typs Rectangle hinzu.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

    // Setzen Sie den Fülltyp auf Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Setzen Sie den Bildfüllungsmodus.
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    // Laden Sie ein Bild und fügen Sie es den Präsentationsressourcen hinzu.
    $image = Images::fromFile("lotus.png");
    $picture = $presentation->getImages()->addImage($image);
    $image->dispose();

    // Setzen Sie das Bild.
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);

    // Speichern Sie die PPTX-Datei auf der Festplatte.
    $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das Ergebnis:

![Die Form mit Bildfüllung](picture-fill.png)

### **Bild kacheln als Textur**

Wenn Sie ein gekacheltes Bild als Textur festlegen und das Kachelverhalten anpassen möchten, können Sie die folgenden Methoden der Klasse [PictureFillFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/picturefillformat/) verwenden:

- [setPictureFillMode](https://reference.aspose.com/slides/de/php-java/aspose.slides/picturefillformat/#setPictureFillMode): Legt den Bildfüllungsmodus fest – entweder `Tile` oder `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/de/php-java/aspose.slides/picturefillformat/#setTileAlignment): Gibt die Ausrichtung der Kacheln innerhalb der Form an.
- [setTileFlip](https://reference.aspose.com/slides/de/php-java/aspose.slides/picturefillformat/#setTileFlip): Steuert, ob die Kachel horizontal, vertikal oder beides gespiegelt wird.
- [setTileOffsetX](https://reference.aspose.com/slides/de/php-java/aspose.slides/picturefillformat/#setTileOffsetX): Legt den horizontalen Versatz der Kachel (in Punkten) vom Ursprung der Form fest.
- [setTileOffsetY](https://reference.aspose.com/slides/de/php-java/aspose.slides/picturefillformat/#setTileOffsetY): Legt den vertikalen Versatz der Kachel (in Punkten) vom Ursprung der Form fest.
- [setTileScaleX](https://reference.aspose.com/slides/de/php-java/aspose.slides/picturefillformat/#setTileScaleX): Definiert die horizontale Skalierung der Kachel als Prozentsatz.
- [setTileScaleY](https://reference.aspose.com/slides/de/php-java/aspose.slides/picturefillformat/#setTileScaleY): Definiert die vertikale Skalierung der Kachel als Prozentsatz.

Das folgende Codebeispiel zeigt, wie Sie einer Rechteckform eine gekachelte Bildfüllung hinzufügen und die Kacheloptionen konfigurieren:

```php
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
$presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    $firstSlide = $presentation->getSlides()->get_Item(0);

    // Fügen Sie eine AutoShape des Typs Rectangle hinzu.
    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

    // Setzen Sie den Fülltyp der Form auf Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Laden Sie das Bild und fügen Sie es den Präsentationsressourcen hinzu.
    $sourceImage = Images::fromFile("lotus.png");
    $presentationImage = $presentation->getImages()->addImage($sourceImage);
    $sourceImage->dispose();

    // Weisen Sie das Bild der Form zu.
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

    // Speichern Sie die PPTX-Datei auf der Festplatte.
    $presentation->save("tile.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das Ergebnis:

![Die Kacheloptionen](tile-options.png)

## **Einfarbige Füllung**

In PowerPoint ist die einfarbige Füllung eine Formatierungsoption, die eine Form mit einer einzigen, einheitlichen Farbe füllt. Diese schlichte Hintergrundfarbe wird ohne Verläufe, Texturen oder Muster angewendet.

So wenden Sie mit Aspose.Slides eine einfarbige Füllung auf eine Form an:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/).
1. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie eine [AutoShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/) hinzu.
1. Setzen Sie das [FillType](https://reference.aspose.com/slides/de/php-java/aspose.slides/filltype/) der Form auf `Solid`.
1. Weisen Sie der Form Ihre bevorzugte Füllfarbe zu.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

```php
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
$presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    $slide = $presentation->getSlides()->get_Item(0);

    // Fügen Sie eine AutoShape des Typs Rectangle hinzu.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Setzen Sie den Fülltyp auf Solid.
    $shape->getFillFormat()->setFillType(FillType::Solid);

    // Setzen Sie die Füllfarbe.
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    // Speichern Sie die PPTX-Datei auf der Festplatte.
    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das Ergebnis:

![Die Form mit einfarbiger Füllung](solid-color-fill.png)

## **Transparenz festlegen**

In PowerPoint können Sie, wenn Sie einer Form eine einfarbige, Verlaufs-, Bild‑ oder Texturfüllung zuweisen, zusätzlich einen Transparenzgrad festlegen, um die Undurchsichtigkeit der Füllung zu steuern. Ein höherer Transparenzwert macht die Form durchsichtiger, sodass der Hintergrund oder darunter liegende Objekte teilweise sichtbar werden.

Aspose.Slides ermöglicht das Festlegen des Transparenzgrades, indem Sie den Alphawert der für die Füllung verwendeten Farbe anpassen. So geht's:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/).
1. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie eine [AutoShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/) hinzu.
1. Setzen Sie das [FillType](https://reference.aspose.com/slides/de/php-java/aspose.slides/filltype/) der Form auf `Solid`.
1. Verwenden Sie `Color`, um eine Farbe mit Transparenz zu definieren (der `alpha`‑Komponent steuert die Transparenz).
1. Speichern Sie die Präsentation.

```php
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
$presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    $slide = $presentation->getSlides()->get_Item(0);

    // Fügen Sie eine feste Rechteck‑AutoShape hinzu.
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Fügen Sie eine transparente Rechteck‑AutoShape über der festen Form hinzu.
    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", 255, 255, 0, 204));

    // Speichern Sie die PPTX-Datei auf der Festplatte.
    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das Ergebnis:

![Die transparente Form](shape-transparency.png)

## **Formen drehen**

Aspose.Slides ermöglicht das Drehen von Formen in PowerPoint‑Präsentationen. Das kann nützlich sein, um visuelle Elemente mit bestimmten Ausrichtungs‑ oder Designanforderungen zu positionieren.

So drehen Sie eine Form auf einer Folie:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/).
1. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie eine [AutoShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/) hinzu.
1. Setzen Sie die Rotations‑Eigenschaft der Form auf den gewünschten Winkel.
1. Speichern Sie die Präsentation.

```php
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
$presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    $slide = $presentation->getSlides()->get_Item(0);

    // Fügen Sie eine AutoShape des Typs Rectangle hinzu.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Drehen Sie die Form um 5 Grad.
    $shape->setRotation(5);

    // Speichern Sie die PPTX-Datei auf der Festplatte.
    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das Ergebnis:

![Die Formdrehung](shape-rotation.png)

## **3D‑Kanteneffekte hinzufügen**

Aspose.Slides ermöglicht das Anwenden von 3D‑Kanteneffekten auf Formen, indem Sie deren [ThreeDFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/threedformat/)‑Eigenschaften konfigurieren.

So fügen Sie einer Form 3D‑Kanteneffekte hinzu:

1. Instanziieren Sie die Klasse [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/).
1. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie eine [AutoShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/) hinzu.
1. Konfigurieren Sie das [ThreeDFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/threedformat/) der Form, um Kanten‑Einstellungen zu definieren.
1. Speichern Sie die Präsentation.

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

![Der 3D‑Kanten-Effekt](3D-bevel-effect.png)

## **3D‑Drehungseffekte hinzufügen**

Aspose.Slides ermöglicht das Anwenden von 3D‑Drehungseffekten auf Formen, indem Sie deren [ThreeDFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/threedformat/)‑Eigenschaften konfigurieren.

So wenden Sie eine 3D‑Drehung auf eine Form an:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/).
1. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie eine [AutoShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/) hinzu.
1. Verwenden Sie die Methoden [setCameraType](https://reference.aspose.com/slides/de/php-java/aspose.slides/camera/#setCameraType) und [setLightType](https://reference.aspose.com/slides/de/php-java/aspose.slides/lightrig/#setLightType), um die 3D‑Drehung zu definieren.
1. Speichern Sie die Präsentation.

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

![Der 3D‑Drehungseffekt](3D-rotation-effect.png)

## **Formatierung zurücksetzen**

Der folgende Java‑Code zeigt, wie Sie die Formatierung einer Folie zurücksetzen und die Position, Größe und Formatierung aller Formen mit Platzhaltern auf dem [LayoutSlide](https://reference.aspose.com/slides/de/php-java/aspose.slides/layoutslide/) auf ihre Standardwerte zurücksetzen:

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

**Hat die Formatierung von Formen Auswirkungen auf die Dateigröße der endgültigen Präsentation?**

Nur minimal. Eingebettete Bilder und Medien beanspruchen den größten Teil des Speicherplatzes, während Formparameter wie Farben, Effekte und Verläufe als Metadaten gespeichert werden und praktisch keinen zusätzlichen Platz benötigen.

**Wie kann ich Formen auf einer Folie erkennen, die identische Formatierungen aufweisen, damit ich sie gruppieren kann?**

Vergleichen Sie die wichtigsten Formatierungseigenschaften jeder Form – Füllung, Linie und Effekt‑Einstellungen. Stimmen alle entsprechenden Werte überein, behandeln Sie deren Stile als identisch und gruppieren Sie die Formen logisch, was die spätere Stilverwaltung vereinfacht.

**Kann ich einen Satz benutzerdefinierter Formstile in einer separaten Datei speichern, um sie in anderen Präsentationen wiederzuverwenden?**

Ja. Speichern Sie Beispiel­formen mit den gewünschten Stilen in einem Vorlagen‑Foliensatz oder einer .POTX‑Vorlagendatei. Beim Erstellen einer neuen Präsentation öffnen Sie die Vorlage, klonen die benötigten gestylten Formen und wenden deren Formatierung dort an, wo sie benötigt wird.