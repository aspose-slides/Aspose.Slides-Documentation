---
title: PowerPoint-Formen in PHP formatieren
linktitle: Formformatierung
type: docs
weight: 20
url: /de/php-java/shape-formatting/
keywords:
- Form formatieren
- Linie formatieren
- Verbindungsstil formatieren
- Gradientenfüllung
- Musterfüllung
- Bildfüllung
- Texturfüllung
- Einfarbige Füllung
- Form-Transparenz
- Form rotieren
- 3D-Kanteneffekt
- 3D-Rotationseffekt
- Formatierung zurücksetzen
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint-Formen in PHP mit Aspose.Slides formatieren können – füllen, Linien- und Effektstile für PPT-, PPTX- und ODP-Dateien präzise und mit voller Kontrolle festlegen."
---

## **Übersicht**

In PowerPoint können Sie Formen zu Folien hinzufügen. Da Formen aus Linien bestehen, können Sie sie formatieren, indem Sie die Umrisse ändern oder Effekte darauf anwenden. Zusätzlich können Sie Formen formatieren, indem Sie Einstellungen festlegen, die steuern, wie ihre Innenflächen gefüllt werden.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides für PHP via Java bietet Klassen und Methoden, mit denen Sie Formen mit denselben Optionen formatieren können, die in PowerPoint verfügbar sind.

## **Linien formatieren**

Mit Aspose.Slides können Sie für eine Form einen benutzerdefinierten Linienstil festlegen. Der folgende Ablauf beschreibt die Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) hinzu.
1. Setzen Sie den [Linienstil](https://reference.aspose.com/slides/php-java/aspose.slides/linestyle/) der Form.
1. Setzen Sie die Linienbreite.
1. Setzen Sie den [Strichstil](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/) der Linie.
1. Setzen Sie die Linienfarbe für die Form.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Der folgende PHP‑Code demonstriert, wie ein Rechteck‑`AutoShape` formatiert wird:
```php
// Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei repräsentiert.
$presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    $slide = $presentation->getSlides()->get_Item(0);

    // Fügen Sie eine AutoShape vom Typ Rectangle hinzu.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

    // Setzen Sie die Füllfarbe für die Rechteckform.
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    // Wenden Sie Formatierung auf die Linien des Rechtecks an.
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);

    // Setzen Sie die Farbe für die Linie des Rechtecks.
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // Speichern Sie die PPTX‑Datei auf dem Datenträger.
    $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


Das Ergebnis:

![The formatted lines in the presentation](formatted-lines.png)

## **Linienverbindungs‑Stile formatieren**

Hier sind die drei Optionen für Verbindungs­typen:

* Round
* Miter
* Bevel

Standardmäßig verwendet PowerPoint beim Verbinden zweier Linien in einem Winkel (z. B. an einer Formenecke) den **Round**‑Modus. Wenn Sie jedoch eine Form mit scharfen Winkeln zeichnen, ist die **Miter**‑Option möglicherweise besser geeignet.

![The join style in the presentation](join-style-powerpoint.png)

Der folgende PHP‑Code zeigt, wie drei Rechtecke (wie im Bild oben) mit den Verbindungs‑Typen Miter, Bevel und Round erstellt wurden:
```php
// Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei darstellt.
$presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    $slide = $presentation->getSlides()->get_Item(0);

    // Fügen Sie drei AutoShapes vom Typ Rectangle hinzu.
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    // Setzen Sie die Füllfarbe für jede Rechtecksform.
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

    // Speichern Sie die PPTX‑Datei auf dem Datenträger.
    $presentation->save("join_styles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **Verlaufsfüllung**

In PowerPoint ist die Verlaufsfüllung eine Formatierungsoption, mit der Sie einer Form einen kontinuierlichen Farbübergang zuweisen können. Sie können zum Beispiel zwei oder mehr Farben so anwenden, dass die eine allmählich in die andere übergeht.

So wenden Sie eine Verlaufsfüllung auf eine Form mit Aspose.Slides an:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) der Form auf `Gradient`.
1. Fügen Sie mit den `add`‑Methoden der von [GradientFormat](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/) bereitgestellten Gradienten‑Stop‑Sammlung Ihre beiden Wunschfarben mit definierten Positionen hinzu.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Der folgende PHP‑Code demonstriert die Anwendung einer Verlaufsfüllung auf eine Ellipse:
```php
// Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei darstellt.
$presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    $slide = $presentation->getSlides()->get_Item(0);

    // Fügen Sie eine AutoShape vom Typ Ellipse hinzu.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

    // Wenden Sie eine Verlaufformatierung auf die Ellipse an.
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);

    // Setzen Sie die Richtung des Farbverlaufs.
    $shape->getFillFormat()->getGradientFormat()->setGradientDirection(GradientDirection::FromCorner2);

    // Fügen Sie zwei Farbverlaufsstopps hinzu.
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0, PresetColor::Red);

    // Speichern Sie die PPTX‑Datei auf dem Datenträger.
    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


Das Ergebnis:

![The ellipse with gradient fill](gradient-fill.png)

## **Musterfüllung**

In PowerPoint ist die Musterfüllung eine Formatierungsoption, mit der Sie ein zweifarbiges Design (z. B. Punkte, Streifen, Kreuzschraffuren oder Karos) auf eine Form anwenden können. Sie können für Vorder‑ und Hintergrund des Musters eigene Farben festlegen.

Aspose.Slides bietet über 45 vordefinierte Mustervorlagen, die Sie auf Formen anwenden können, um die optische Gestaltung Ihrer Präsentationen zu verbessern. Auch nach Auswahl eines vordefinierten Musters können Sie die genauen Farben festlegen, die verwendet werden sollen.

So wenden Sie eine Musterfüllung auf eine Form mit Aspose.Slides an:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) der Form auf `Pattern`.
1. Wählen Sie einen Mustertyp aus den vordefinierten Optionen.
1. Setzen Sie die [Background Color](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getBackColor) des Musters.
1. Setzen Sie die [Foreground Color](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getForeColor) des Musters.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Der folgende PHP‑Code demonstriert die Anwendung einer Musterfüllung auf ein Rechteck:
```php
// Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei darstellt.
$presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    $slide = $presentation->getSlides()->get_Item(0);

    // Fügen Sie eine AutoShape vom Typ Rectangle hinzu.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Setzen Sie den Fülltyp auf Pattern.
    $shape->getFillFormat()->setFillType(FillType::Pattern);

    // Setzen Sie den Musterstil.
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);

    // Setzen Sie die Hintergrund‑ und Vordergrundfarben des Musters.
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    // Speichern Sie die PPTX‑Datei auf dem Datenträger.
    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


Das Ergebnis:

![The rectangle with pattern fill](pattern-fill.png)

## **Bildfüllung**

In PowerPoint ist die Bildfüllung eine Formatierungsoption, mit der Sie ein Bild in eine Form einfügen können – das Bild dient dabei als Hintergrund der Form.

So verwenden Sie Aspose.Slides, um eine Bildfüllung auf eine Form anzuwenden:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) der Form auf `Picture`.
1. Setzen Sie den Bildfüllungsmodus auf `Tile` (oder einen anderen gewünschten Modus).
1. Erstellen Sie ein [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/)‑Objekt aus dem Bild, das Sie verwenden möchten.
1. Übergaben Sie das Bild an die Methode `SlidesPicture.setImage`.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Angenommen, wir haben die Datei **lotus.png** mit folgendem Bild:

![The lotus picture](lotus.png)

Der folgende PHP‑Code demonstriert, wie Sie eine Form mit dem Bild füllen:
```php
// Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei darstellt.
$presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    $slide = $presentation->getSlides()->get_Item(0);

    // Fügen Sie eine AutoShape vom Typ Rectangle hinzu.
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

    // Speichern Sie die PPTX‑Datei auf dem Datenträger.
    $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


Das Ergebnis:

![The shape with picture fill](picture-fill.png)

### **Bild kacheln als Textur**

Wenn Sie ein gekacheltes Bild als Textur festlegen und das Kachel‑Verhalten anpassen möchten, können Sie die folgenden Methoden der Klasse [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) verwenden:

- [setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode): Legt den Bildfüllungsmodus fest – `Tile` oder `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileAlignment): Bestimmt die Ausrichtung der Kacheln innerhalb der Form.
- [setTileFlip](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileFlip): Steuert, ob die Kachel horizontal, vertikal oder beides gespiegelt wird.
- [setTileOffsetX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetX): Setzt den horizontalen Versatz der Kachel (in Punkten) vom Ursprung der Form.
- [setTileOffsetY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetY): Setzt den vertikalen Versatz der Kachel (in Punkten) vom Ursprung der Form.
- [setTileScaleX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleX): Definiert den horizontalen Maßstab der Kachel in Prozent.
- [setTileScaleY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleY): Definiert den vertikalen Maßstab der Kachel in Prozent.

Der folgende Beispielcode zeigt, wie Sie ein Rechteck mit gekachelter Bildfüllung hinzufügen und die Kacheloptionen konfigurieren:
```php
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
$presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    $firstSlide = $presentation->getSlides()->get_Item(0);

    // Fügen Sie eine Rechteck-AutoShape hinzu.
    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

    // Setzen Sie den Fülltyp der Form auf Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Laden Sie das Bild und fügen Sie es zu den Präsentationsressourcen hinzu.
    $sourceImage = Images::fromFile("lotus.png");
    $presentationImage = $presentation->getImages()->addImage($sourceImage);
    $sourceImage->dispose();

    // Weisen Sie das Bild der Form zu.
    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);

    // Konfigurieren Sie den Bildfüllungsmodus und die Kacheleigenschaften.
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

![The tile options](tile-options.png)

## **Einfarbige Füllung**

In PowerPoint ist die einfarbige Füllung eine Formatierungsoption, die eine Form mit einer einzigen, gleichmäßigen Farbe füllt. Dieser einheitliche Hintergrund wird ohne Verläufe, Texturen oder Muster angewendet.

So wenden Sie eine einfarbige Füllung auf eine Form mit Aspose.Slides an:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) der Form auf `Solid`.
1. Weisen Sie der Form Ihre gewünschte Füllfarbe zu.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Der folgende PHP‑Code demonstriert die Anwendung einer einfarbigen Füllung auf ein Rechteck in einer PowerPoint‑Folie:
```php
// Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei darstellt.
$presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    $slide = $presentation->getSlides()->get_Item(0);

    // Fügen Sie eine AutoShape vom Typ Rectangle hinzu.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Setzen Sie den Fülltyp auf Solid.
    $shape->getFillFormat()->setFillType(FillType::Solid);

    // Setzen Sie die Füllfarbe.
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    // Speichern Sie die PPTX‑Datei auf dem Datenträger.
    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


Das Ergebnis:

![The shape with solid color fill](solid-color-fill.png)

## **Transparenz einstellen**

In PowerPoint können Sie bei einer einfarbigen, verlaufenden, bild- oder texturfüllten Form auch einen Transparenzwert festlegen, um die Undurchsichtigkeit der Füllung zu steuern. Ein höherer Transparenzwert macht die Form durchsichtiger, sodass der Hintergrund oder darunterliegende Objekte teilweise sichtbar werden.

Aspose.Slides ermöglicht das Einstellen der Transparenz, indem Sie den Alpha‑Wert der für die Füllung verwendeten Farbe anpassen. So geht’s:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) auf `Solid`.
1. Verwenden Sie `Color`, um eine Farbe mit Transparenz zu definieren (der `alpha`‑Komponente steuert die Transparenz).
1. Speichern Sie die Präsentation.

Der folgende PHP‑Code demonstriert, wie Sie einer Rechteckform eine transparente Füllfarbe zuweisen:
```php
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
$presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    $slide = $presentation->getSlides()->get_Item(0);

    // Fügen Sie eine solide Rechteck-AutoShape hinzu.
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Fügen Sie eine transparente Rechteck-AutoShape über der soliden Form hinzu.
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

![The transparent shape](shape-transparency.png)

## **Formen rotieren**

Aspose.Slides ermöglicht das Rotieren von Formen in PowerPoint‑Präsentationen. Dies kann nützlich sein, wenn Sie visuelle Elemente mit bestimmten Ausrichtungen oder Design‑Ansprüchen positionieren möchten.

So rotieren Sie eine Form auf einer Folie:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) hinzu.
1. Setzen Sie die Rotationseigenschaft der Form auf den gewünschten Winkel.
1. Speichern Sie die Präsentation.

Der folgende PHP‑Code demonstriert das Rotieren einer Form um 5 Grad:
```php
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
$presentation = new Presentation();
try {
    // Holen Sie die erste Folie.
    $slide = $presentation->getSlides()->get_Item(0);

    // Fügen Sie eine AutoShape vom Typ Rectangle hinzu.
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

![The shape rotation](shape-rotation.png)

## **3D‑Kehlkanten‑Effekte hinzufügen**

Aspose.Slides ermöglicht das Hinzufügen von 3D‑Kehlkanten‑Effekten zu Formen, indem Sie deren [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/)‑Eigenschaften konfigurieren.

So fügen Sie einer Form 3D‑Kehlkanten‑Effekte hinzu:

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) hinzu.
1. Konfigurieren Sie das [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/) der Form, um die Kehlkanten‑Einstellungen festzulegen.
1. Speichern Sie die Präsentation.

Der folgende PHP‑Code zeigt, wie Sie 3D‑Kehlkanten‑Effekte auf eine Form anwenden:
```php
// Erstellen Sie eine Instanz der Presentation‑Klasse.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Fügen Sie eine Form zur Folie hinzu.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $shape->getLineFormat()->setWidth(2.0);

    // Setzen Sie die ThreeDFormat-Eigenschaften der Form.
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

![The 3D bevel effect](3D-bevel-effect.png)

## **3D‑Rotations‑Effekte hinzufügen**

Aspose.Slides ermöglicht das Hinzufügen von 3D‑Rotations‑Effekten zu Formen, indem Sie deren [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/)‑Eigenschaften konfigurieren.

So wenden Sie eine 3D‑Rotation auf eine Form an:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) hinzu.
1. Verwenden Sie [setCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setCameraType) und [setLightType](https://reference.aspose.com/slides/php-java/aspose.slides/lightrig/#setLightType), um die 3D‑Rotation zu definieren.
1. Speichern Sie die Präsentation.

Der folgende PHP‑Code demonstriert die Anwendung von 3D‑Rotations‑Effekten auf eine Form:
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

![The 3D rotation effect](3D-rotation-effect.png)

## **Formatierung zurücksetzen**

Der folgende Java‑Code zeigt, wie Sie die Formatierung einer Folie zurücksetzen und die Position, Größe sowie die Formatierung aller Formen mit Platzhaltern auf dem [LayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/) auf ihre Standardwerte zurücksetzen:
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

**Beeinflusst die Formatierung von Formen die endgültige Dateigröße der Präsentation?**

Nur minimal. Eingebettete Bilder und Medien belegen den größten Teil des Speicherplatzes, während Form‑Parameter wie Farben, Effekte und Verläufe als Metadaten gespeichert werden und praktisch keinen zusätzlichen Platz benötigen.

**Wie kann ich Formen auf einer Folie erkennen, die identische Formatierungen besitzen, um sie zu gruppieren?**

Vergleichen Sie die wichtigsten Formatierungs‑Eigenschaften jeder Form – Füll‑, Linien‑ und Effekt‑Einstellungen. Stimmen alle entsprechenden Werte überein, behandeln Sie die Stile als identisch und gruppieren die Formen logisch, was die spätere Stilverwaltung vereinfacht.

**Kann ich ein Set benutzerdefinierter Form‑Stile in einer separaten Datei speichern, um sie in anderen Präsentationen wiederzuverwenden?**

Ja. Speichern Sie Beispiel‑Formen mit den gewünschten Stilen in einer Vorlagen‑Präsentation oder einer .POTX‑Vorlagendatei. Beim Erstellen einer neuen Präsentation öffnen Sie die Vorlage, duplizieren die benötigten stilisierten Formen und wenden deren Formatierung dort an, wo sie benötigt wird.