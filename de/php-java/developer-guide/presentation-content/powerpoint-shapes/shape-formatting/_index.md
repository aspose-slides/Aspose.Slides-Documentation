---
title: PowerPoint-Formen in PHP formatieren
linktitle: Form-Formatierung
type: docs
weight: 20
url: /de/php-java/shape-formatting/
keywords:
- Form formatieren
- Linie formatieren
- Skizzen-Effekt
- Skizzenlinien einer Form
- Verbindungsstil formatieren
- Verlaufsfüllung
- Musterfüllung
- Bildfüllung
- Texturfüllung
- Einfarbige Füllung
- Form-Transparenz
- Schwarz-weiß-Darstellung von Formen
- Graustufen-Darstellung von Formen
- Form drehen
- 3D-Keil-Effekt
- 3D-Dreh-Effekt
- Formatierung zurücksetzen
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint-Formen in PHP mit Aspose.Slides formatieren – Füll-, Linien- und Effekt-Stile für PPT-, PPTX- und ODP-Dateien präzise und vollständig steuern."
---
## **Einführung**

In PowerPoint können Sie Formen zu Folien hinzufügen. Da Formen aus Linien bestehen, können Sie sie formatieren, indem Sie deren Konturen ändern oder Effekte darauf anwenden. Zusätzlich können Sie Formen formatieren, indem Sie Einstellungen festlegen, die steuern, wie ihre Innenflächen gefüllt werden.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides für PHP via Java bietet Klassen und Methoden, mit denen Sie Formen mithilfe derselben Optionen formatieren können, die in PowerPoint verfügbar sind.

## **Linien formatieren**

Mit Aspose.Slides können Sie einen benutzerdefinierten Linienstil für eine Form angeben. Die folgenden Schritte beschreiben das Vorgehen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/).
1. Rufen Sie eine Referenz auf eine Folie anhand ihres Indexes ab.
1. Fügen Sie dem Folie eine [AutoShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/) hinzu.
1. Legen Sie den [Linienstil](https://reference.aspose.com/slides/de/php-java/aspose.slides/linestyle/) der Form fest.
1. Setzen Sie die Linienbreite.
1. Legen Sie den [Strichstil](https://reference.aspose.com/slides/de/php-java/aspose.slides/linedashstyle/) der Linie fest.
1. Legen Sie die Linienfarbe für die Form fest.
1. Speichern Sie die geänderte Präsentation als PPTX-Datei.

Der folgende PHP‑Code zeigt, wie ein Rechteck‑`AutoShape` formatiert wird:

```php
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
$presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    $slide = $presentation->getSlides()->get_Item(0);

    // Fügen Sie eine AutoShape vom Typ Rechteck hinzu.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

    // Setzen Sie die Füllfarbe für die Rechteckform.
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    // Wenden Sie Formatierungen auf die Linien des Rechtecks an.
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

Ein Skizze‑Effekt lässt eine Formlinie handgezeichnet erscheinen. Verwenden Sie [Shape.getLineFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/) , um auf die Linieneinstellungen zuzugreifen, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/lineformat/) , um auf die Skizzen‑Einstellungen zuzugreifen, und [SketchFormat.setSketchType](https://reference.aspose.com/slides/de/php-java/aspose.slides/sketchformat/) , um einen Wert aus der Aufzählung [LineSketchType](https://reference.aspose.com/slides/de/php-java/aspose.slides/linesketchtype/) auszuwählen.

Der folgende PHP‑Code zeigt, wie ein [LineSketchType.Curved](https://reference.aspose.com/slides/de/php-java/aspose.slides/linesketchtype/)‑Effekt angewendet, der explizit zugewiesene Wert ausgelesen und der Effekt mit [LineSketchType.None](https://reference.aspose.com/slides/de/php-java/aspose.slides/linesketchtype/) entfernt wird:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

    // Greifen Sie auf das Linienformat der Form und deren Skizzenformat zu.
    $sketchFormat = $shape->getLineFormat()->getSketchFormat();

    // Wenden Sie einen Skizzen-Effekt an.
    $sketchFormat->setSketchType(LineSketchType::Curved);

    // Lesen Sie den direkt der Form zugewiesenen Skizzen-Effekt.
    $explicitSketchType = $sketchFormat->getSketchType();
    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;

    // Entfernen Sie den Skizzen-Effekt.
    $sketchFormat->setSketchType(LineSketchType::None);
} finally {
    $presentation->dispose();
}
```

Der von [SketchFormat.getSketchType](https://reference.aspose.com/slides/de/php-java/aspose.slides/sketchformat/) zurückgegebene Wert repräsentiert die direkt an die Form zugewiesene Einstellung. Wenn die Linienformatierung von einem Design, einer Master‑Folien oder einer Layout‑Folien geerbt werden kann, verwenden Sie [LineFormat.getEffective](https://reference.aspose.com/slides/de/php-java/aspose.slides/lineformat/), greifen Sie auf die Methode `getSketchFormat` des zurückgegebenen Objekts zu und lesen Sie dessen `getSketchType`‑Wert. Der effektive Wert spiegelt die Formatierung wider, die nach Auflösung der Vererbung tatsächlich angewendet wird:

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

## **Verbindungs‑Stile formatieren**

Hier sind die drei Optionen für den Verbindungstyp:

* Rund
* Gehrung
* Fase

Standardmäßig verwendet PowerPoint beim Verbinden zweier Linien in einem Winkel (wie an einer Formkante) die Einstellung **Rund**. Wenn Sie jedoch eine Form mit spitzen Winkeln zeichnen, bevorzugen Sie möglicherweise die Option **Gehrung**.

![Der Verbindungsstil in der Präsentation](join-style-powerpoint.png)

Der folgende PHP‑Code zeigt, wie drei Rechtecke (wie im Bild oben) mit den Verbindungs‑Typ‑Einstellungen Gehrung, Fase und Rund erstellt wurden:

```php
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
$presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    $slide = $presentation->getSlides()->get_Item(0);

    // Fügen Sie drei AutoShapes des Typs Rechteck hinzu.
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

## **Verlaufsfüllung**

In PowerPoint ist die Verlaufsfüllung eine Formatierungsoption, mit der Sie einer Form einen kontinuierlichen Farbübergang zuweisen können. Beispielsweise können Sie zwei oder mehr Farben so anwenden, dass eine allmählich in die andere übergeht.

So wenden Sie eine Verlaufsfüllung auf eine Form mit Aspose.Slides an:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/).
1. Rufen Sie eine Referenz auf eine Folie anhand ihres Indexes ab.
1. Fügen Sie dem Folie eine [AutoShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/de/php-java/aspose.slides/filltype/) der Form auf `Gradient`.
1. Fügen Sie Ihre beiden bevorzugten Farben mit definierten Positionen mithilfe der `add`‑Methoden der Gradient‑Stop‑Sammlung, die durch die Klasse [GradientFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/gradientformat/) bereitgestellt wird, hinzu.
1. Speichern Sie die geänderte Präsentation als PPTX-Datei.

```php
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
$presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    $slide = $presentation->getSlides()->get_Item(0);

    // Fügen Sie eine AutoShape des Typs Ellipse hinzu.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

    // Wenden Sie eine Verlaufsformatierung auf die Ellipse an.
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);

    // Setzen Sie die Richtung des Verlaufs.
    $shape->getFillFormat()->getGradientFormat()->setGradientDirection(GradientDirection::FromCorner2);

    // Fügen Sie zwei Gradient-Stops hinzu.
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0, PresetColor::Red);

    // Speichern Sie die PPTX-Datei auf dem Datenträger.
    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das Ergebnis:

![Die Ellipse mit Verlaufsfüllung](gradient-fill.png)

## **Musterfüllung**

In PowerPoint ist die Musterfüllung eine Formatierungsoption, mit der Sie ein zweifarbiges Design – wie Punkte, Streifen, Kreuzschraffuren oder Karos – auf eine Form anwenden können. Sie können individuelle Farben für den Vorder- und Hintergrund des Musters festlegen.

Aspose.Slides bietet über 45 vordefinierte Mustervorlagen, die Sie auf Formen anwenden können, um die optische Attraktivität Ihrer Präsentationen zu steigern. Selbst nach Auswahl eines vordefinierten Musters können Sie noch die genauen zu verwendenden Farben angeben.

So wenden Sie eine Musterfüllung auf eine Form mit Aspose.Slides an:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/).
1. Rufen Sie eine Referenz auf eine Folie anhand ihres Indexes ab.
1. Fügen Sie dem Folie eine [AutoShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/de/php-java/aspose.slides/filltype/) der Form auf `Pattern`.
1. Wählen Sie einen Mustertyp aus den vordefinierten Optionen.
1. Setzen Sie die [Background Color](https://reference.aspose.com/slides/de/php-java/aspose.slides/patternformat/#getBackColor) des Musters.
1. Setzen Sie die [Foreground Color](https://reference.aspose.com/slides/de/php-java/aspose.slides/patternformat/#getForeColor) des Musters.
1. Speichern Sie die geänderte Präsentation als PPTX-Datei.

```php
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
$presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    $slide = $presentation->getSlides()->get_Item(0);

    // Fügen Sie eine AutoShape des Typs Rectangle hinzu.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Setzen Sie den FillType auf Pattern.
    $shape->getFillFormat()->setFillType(FillType::Pattern);

    // Setzen Sie den PatternStyle.
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

In PowerPoint ist die Bildfüllung eine Formatierungsoption, die es Ihnen ermöglicht, ein Bild in einer Form zu platzieren – das Bild wird dabei effektiv zum Hintergrund der Form.

So verwenden Sie Aspose.Slides, um eine Bildfüllung auf eine Form anzuwenden:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/).
1. Rufen Sie eine Referenz auf eine Folie anhand ihres Indexes ab.
1. Fügen Sie dem Folie eine [AutoShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/de/php-java/aspose.slides/filltype/) der Form auf `Picture`.
1. Setzen Sie den Bildfüllmodus auf `Tile` (oder einen anderen gewünschten Modus).
1. Erstellen Sie ein [PPImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/ppimage/)‑Objekt aus dem Bild, das Sie verwenden möchten.
1. Übergeben Sie das Bild an die Methode `SlidesPicture.setImage`.
1. Speichern Sie die geänderte Präsentation als PPTX-Datei.

![Das Lotus‑Bild](lotus.png)

Der folgende PHP‑Code zeigt, wie eine Form mit dem Bild gefüllt wird:

```php
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
$presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    $slide = $presentation->getSlides()->get_Item(0);

    // Fügen Sie eine AutoShape des Typs Rectangle hinzu.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

    // Setzen Sie den FillType auf Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Setzen Sie den Bildfüllmodus.
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    // Laden Sie ein Bild und fügen Sie es den Präsentationsressourcen hinzu.
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

Wenn Sie ein gekacheltes Bild als Textur festlegen und das Kachel‑Verhalten anpassen möchten, können Sie die folgenden Methoden der Klasse [PictureFillFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/picturefillformat/) verwenden:

- [setPictureFillMode](https://reference.aspose.com/slides/de/php-java/aspose.slides/picturefillformat/#setPictureFillMode): Legt den Bildfüllmodus fest – entweder `Tile` oder `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/de/php-java/aspose.slides/picturefillformat/#setTileAlignment): Gibt die Ausrichtung der Kacheln innerhalb der Form an.
- [setTileFlip](https://reference.aspose.com/slides/de/php-java/aspose.slides/picturefillformat/#setTileFlip): Steuert, ob die Kachel horizontal, vertikal oder beides gespiegelt wird.
- [setTileOffsetX](https://reference.aspose.com/slides/de/php-java/aspose.slides/picturefillformat/#setTileOffsetX): Legt den horizontalen Versatz der Kachel (in Punkten) vom Ursprung der Form fest.
- [setTileOffsetY](https://reference.aspose.com/slides/de/php-java/aspose.slides/picturefillformat/#setTileOffsetY): Legt den vertikalen Versatz der Kachel (in Punkten) vom Ursprung der Form fest.
- [setTileScaleX](https://reference.aspose.com/slides/de/php-java/aspose.slides/picturefillformat/#setTileScaleX): Definiert die horizontale Skalierung der Kachel als Prozentsatz.
- [setTileScaleY](https://reference.aspose.com/slides/de/php-java/aspose.slides/picturefillformat/#setTileScaleY): Definiert die vertikale Skalierung der Kachel als Prozentsatz.

Der folgende Code‑Beispiel zeigt, wie ein Rechteck mit gekachelter Bildfüllung erstellt und die Kachel‑Optionen konfiguriert werden:

```php
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
$presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    $firstSlide = $presentation->getSlides()->get_Item(0);

    // Fügen Sie eine Rechteck‑AutoShape hinzu.
    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

    // Setzen Sie den FillType der Form auf Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Laden Sie das Bild und fügen Sie es den Präsentationsressourcen hinzu.
    $sourceImage = Images::fromFile("lotus.png");
    $presentationImage = $presentation->getImages()->addImage($sourceImage);
    $sourceImage->dispose();

    // Weisen Sie das Bild der Form zu.
    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);

    // Konfigurieren Sie den Bildfüllmodus und die Kachel‑Eigenschaften.
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

In PowerPoint ist die einfarbige Füllung eine Formatierungsoption, die eine Form mit einer einzigen, einheitlichen Farbe füllt. Dieser schlichte Hintergrund wird ohne Verläufe, Texturen oder Muster angewendet.

So wenden Sie eine einfarbige Füllung auf eine Form mit Aspose.Slides an:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/).
1. Rufen Sie eine Referenz auf eine Folie anhand ihres Indexes ab.
1. Fügen Sie dem Folie eine [AutoShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/de/php-java/aspose.slides/filltype/) der Form auf `Solid`.
1. Weisen Sie der Form Ihre bevorzugte Füllfarbe zu.
1. Speichern Sie die geänderte Präsentation als PPTX-Datei.

```php
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
$presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    $slide = $presentation->getSlides()->get_Item(0);

    // Fügen Sie eine AutoShape des Typs Rectangle hinzu.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Setzen Sie den FillType auf Solid.
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

In PowerPoint können Sie beim Anwenden einer einfarbigen, Verlaufs‑, Bild‑ oder Textur‑Füllung auf Formen ebenfalls einen Transparenzwert festlegen, um die Undurchsichtigkeit der Füllung zu steuern. Ein höherer Transparenzwert macht die Form durchsichtiger, sodass der Hintergrund oder darunter liegende Objekte teilweise sichtbar werden.

Aspose.Slides ermöglicht das Festlegen des Transparenzwertes, indem Sie den Alpha‑Wert in der für die Füllung verwendeten Farbe anpassen. So geht’s:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/).
1. Rufen Sie eine Referenz auf eine Folie anhand ihres Indexes ab.
1. Fügen Sie dem Folie eine [AutoShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/de/php-java/aspose.slides/filltype/) auf `Solid`.
1. Verwenden Sie `Color`, um eine Farbe mit Transparenz zu definieren (die Komponente `alpha` steuert die Transparenz).
1. Speichern Sie die Präsentation.

```php
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
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

Aspose.Slides ermöglicht das Drehen von Formen in PowerPoint‑Präsentationen. Dies kann nützlich sein, um visuelle Elemente mit bestimmten Ausrichtungs‑ oder Design‑Anforderungen zu positionieren.

So drehen Sie eine Form auf einer Folie:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/).
1. Rufen Sie eine Referenz auf eine Folie anhand ihres Indexes ab.
1. Fügen Sie dem Folie eine [AutoShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/) hinzu.
1. Setzen Sie die Rotation‑Eigenschaft der Form auf den gewünschten Winkel.
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

    // Speichern Sie die PPTX-Datei auf dem Datenträger.
    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das Ergebnis:

![Die Formdrehung](shape-rotation.png)

## **3D‑Keil‑Effekte hinzufügen**

Aspose.Slides ermöglicht das Anwenden von 3D‑Keil‑Effekten auf Formen, indem deren [ThreeDFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/threedformat/)‑Eigenschaften konfiguriert werden.

So fügen Sie einer Form 3D‑Keil‑Effekte hinzu:

1. Instanziieren Sie die Klasse [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/).
1. Rufen Sie eine Referenz auf eine Folie anhand ihres Indexes ab.
1. Fügen Sie dem Folie eine [AutoShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/) hinzu.
1. Konfigurieren Sie das [ThreeDFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/threedformat/) der Form, um die Keil‑Einstellungen zu definieren.
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

    // Speichern Sie die Präsentation als PPTX-Datei.
    $presentation->save("3D_bevel_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das Ergebnis:

![Der 3D‑Keil‑Effekt](3D-bevel-effect.png)

## **3D‑Dreh‑Effekte hinzufügen**

Aspose.Slides ermöglicht das Anwenden von 3D‑Dreh‑Effekten auf Formen, indem deren [ThreeDFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/threedformat/)‑Eigenschaften konfiguriert werden.

So wenden Sie eine 3D‑Drehung auf eine Form an:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/).
1. Rufen Sie eine Referenz auf eine Folie anhand ihres Indexes ab.
1. Fügen Sie dem Folie eine [AutoShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/) hinzu.
1. Verwenden Sie [setCameraType](https://reference.aspose.com/slides/de/php-java/aspose.slides/camera/#setCameraType) und [setLightType](https://reference.aspose.com/slides/de/php-java/aspose.slides/lightrig/#setLightType), um die 3D‑Drehung zu definieren.
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

![Der 3D‑Dreh‑Effekt](3D-rotation-effect.png)

## **Schwarz‑weiß‑Darstellung von Formen steuern**

Die Methode [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/#setBlackWhiteMode) legt fest, wie eine einzelne Form gerendert wird, wenn eine Präsentation im Schwarz‑weiß‑Modus angezeigt oder verarbeitet wird. Sie aktiviert den Schwarz‑weiß‑Modus nicht selbst und ändert die Füll‑, Linien‑ oder andere Formatierung der Form im normalen Farbmodus nicht.

Verwenden Sie einen Wert aus der Klasse [BlackWhiteMode](https://reference.aspose.com/slides/de/php-java/aspose.slides/blackwhitemode/), um das gewünschte Verhalten auszuwählen. Beispielsweise lässt `Automatic` die Rendering‑Anwendung die Konvertierung wählen, `Gray` und `LightGray` verwenden Grautöne, `BlackWhite` verwendet ausschließlich Schwarz und Weiß, `Black` und `White` erzwingen eine einzelne Farbe, `Color` erhält die normale Farbgebung bei, und `Hidden` lässt die Form im Schwarz‑weiß‑Modus wegfallen. `NotDefined` bedeutet, dass kein Form‑Level‑Modus zugewiesen ist.

Der folgende PHP‑Code erstellt eine farbige Form und lässt sie im Schwarz‑weiß‑Anzeige‑Modus grau erscheinen:

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

    // Behalte die orange Füllung im Farbmodus, aber rendere die Form mit grauer Färbung im Schwarz-weiß-Modus.
    $shape->setBlackWhiteMode(BlackWhiteMode::Gray);

    $presentation->save("shape_black_white_mode.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Im normalen Farbmodus behält das Rechteck seine orange Füllung. Im Schwarz‑weiß‑Arbeitsablauf verwendet es Graufärbung, weil sein Modus auf `Gray` gesetzt ist. So können Sie eine Vollfarb‑Folien beibehalten und gleichzeitig ein unterschiedliches Aussehen für Druck, Vorschau oder andere Arbeitsabläufe, die die Schwarz‑weiß‑Anzeige‑Einstellungen der Präsentation berücksichtigen, definieren.

## **Formatierung zurücksetzen**

Der folgende Java‑Code zeigt, wie die Formatierung einer Folie zurückgesetzt und die Position, Größe und Formatierung aller Formen mit Platzhaltern auf dem [LayoutSlide](https://reference.aspose.com/slides/de/php-java/aspose.slides/layoutslide/) auf ihre Standard‑Einstellungen zurückgesetzt werden:

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

**Beeinflusst die Formformatierung die endgültige Dateigröße der Präsentation?**

Nur minimal. Eingebettete Bilder und Medien belegen den größten Teil des Speicherplatzes, während Form‑Parameter wie Farben, Effekte und Verläufe als Metadaten gespeichert werden und praktisch keine zusätzliche Größe hinzufügen.

**Wie kann ich Formen auf einer Folie erkennen, die identische Formatierung besitzen, sodass ich sie gruppieren kann?**

Vergleichen Sie die wichtigsten Formatierungs‑Eigenschaften jeder Form – Füllung, Linie und Effekt‑Einstellungen. Stimmen alle entsprechenden Werte überein, behandeln Sie deren Stile als identisch und gruppieren Sie die Formen logisch, was die spätere Stilverwaltung vereinfacht.

**Kann ich ein Set benutzerdefinierter Form‑Stile in einer separaten Datei speichern, um es in anderen Präsentationen wiederzuverwenden?**

Ja. Speichern Sie Beispiel‑Formen mit den gewünschten Stilen in einem Vorlagen‑Slide‑Deck oder einer .POTX‑Vorlagendatei. Beim Erstellen einer neuen Präsentation öffnen Sie die Vorlage, klonen die benötigten stilisierten Formen und wenden deren Formatierung dort an, wo sie gebraucht wird.