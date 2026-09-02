---
title: PowerPoint-Formen in C++ formatieren
linktitle: Formformatierung
type: docs
weight: 20
url: /de/cpp/shape-formatting/
keywords:
- Form formatieren
- Linie formatieren
- Skizzeneffekt
- Skizzenformenlinie
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
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint-Formen in C++ mit Aspose.Slides formatieren – Füll-, Linien- und Effektstile für PPT-, PPTX- und ODP-Dateien präzise und vollständig steuern."
---
## **Einführung**

In PowerPoint können Sie Formen zu Folien hinzufügen. Da Formen aus Linien bestehen, können Sie sie formatieren, indem Sie die Konturen ändern oder Effekte darauf anwenden. Zusätzlich können Sie Formen formatieren, indem Sie Einstellungen festlegen, die steuern, wie deren Innenflächen gefüllt werden.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides für C++ bietet Schnittstellen und Methoden, mit denen Sie Formen mithilfe derselben Optionen formatieren können, die in PowerPoint verfügbar sind.

## **Linien formatieren**

Mit Aspose.Slides können Sie für eine Form einen benutzerdefinierten Linienstil festlegen. Die folgenden Schritte beschreiben das Vorgehen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/).
1. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/) hinzu.
1. Setzen Sie den [Linienstil](https://reference.aspose.com/slides/de/cpp/aspose.slides/linestyle/) der Form.
1. Setzen Sie die Linienbreite.
1. Setzen Sie den [Strichstil](https://reference.aspose.com/slides/de/cpp/aspose.slides/linedashstyle/) der Linie.
1. Setzen Sie die Linienfarbe für die Form.
1. Speichern Sie die geänderte Präsentation als PPTX-Datei.

Der folgende C++‑Code demonstriert, wie ein Rechteck‑AutoShape formatiert wird:

```cpp
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
auto presentation = MakeObject<Presentation>();

// Die erste Folie abrufen.
auto slide = presentation->get_Slide(0);

// Ein AutoShape vom Typ Rectangle hinzufügen.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// Die Füllfarbe für das Rechteck-Shape festlegen.
shape->get_FillFormat()->set_FillType(FillType::NoFill);

// Formatierung auf die Linien des Rechtecks anwenden.
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);

// Die Farbe für die Linie des Rechtecks festlegen.
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Die PPTX-Datei auf die Festplatte speichern.
presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Die formatierten Linien in der Präsentation](formatted-lines.png)

## **Skizzeneffekte auf Formlinien anwenden**

Ein Skizzen‑Effekt lässt eine Formlinie handgezeichnet aussehen. Verwenden Sie [IShape::get_LineFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/get_lineformat/), um auf die Linieneinstellungen zuzugreifen, [ILineFormat::get_SketchFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/ilineformat/get_sketchformat/), um auf die Skizzeneinstellungen zuzugreifen, und [ISketchFormat::set_SketchType](https://reference.aspose.com/slides/de/cpp/aspose.slides/isketchformat/set_sketchtype/), um einen Wert aus der Aufzählung [LineSketchType](https://reference.aspose.com/slides/de/cpp/aspose.slides/linesketchtype/) auszuwählen.

Der folgende C++‑Code zeigt, wie man den Effekt [LineSketchType::Curved](https://reference.aspose.com/slides/de/cpp/aspose.slides/linesketchtype/) anwendet, den explizit zugewiesenen Wert ausliest und den Effekt mit [LineSketchType::None](https://reference.aspose.com/slides/de/cpp/aspose.slides/linesketchtype/) entfernt:

```cpp
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

// Access the shape's line format and its sketch format.
auto sketchFormat = shape->get_LineFormat()->get_SketchFormat();

// Apply a sketch effect.
sketchFormat->set_SketchType(LineSketchType::Curved);

// Read the sketch effect assigned directly to the shape.
auto explicitSketchType = sketchFormat->get_SketchType();
Console::WriteLine(u"Explicit sketch type: {0}", explicitSketchType);

// Remove the sketch effect.
sketchFormat->set_SketchType(LineSketchType::None);

presentation->Dispose();
```

Der von [ISketchFormat::get_SketchType](https://reference.aspose.com/slides/de/cpp/aspose.slides/isketchformat/get_sketchtype/) zurückgegebene Wert repräsentiert die direkt an die Form zugewiesene Einstellung. Wenn die Linienformatierung von einem Design, einer Master‑Folien‑ oder Layout‑Folien‑Vorlage geerbt werden kann, verwenden Sie [ILineFormat::GetEffective](https://reference.aspose.com/slides/de/cpp/aspose.slides/ilineformat/geteffective/), greifen Sie auf [ILineFormatEffectiveData::get_SketchFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/ilineformateffectivedata/get_sketchformat/) zu und lesen Sie [ISketchFormatEffectiveData::get_SketchType](https://reference.aspose.com/slides/de/cpp/aspose.slides/isketchformateffectivedata/get_sketchtype/) aus. Der effektive Wert spiegelt die Formatierung wider, die tatsächlich nach Auflösung der Vererbung angewendet wird:

```cpp
auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto lineFormat = shape->get_LineFormat();

auto explicitSketchType = lineFormat->get_SketchFormat()->get_SketchType();
auto effectiveLineFormat = lineFormat->GetEffective();
auto effectiveSketchType = effectiveLineFormat->get_SketchFormat()->get_SketchType();

Console::WriteLine(u"Explicit sketch type: {0}", explicitSketchType);
Console::WriteLine(u"Effective sketch type: {0}", effectiveSketchType);

presentation->Dispose();
```

## **Verbindungs‑Stile formatieren**

Hier sind die drei Optionen für den Verbindungstyp:

* Rund
* Gehrung
* Fase

Standardmäßig verwendet PowerPoint beim Verbinden zweier Linien in einem Winkel (z. B. an einer Formkante) die Einstellung **Rund**. Wenn Sie jedoch eine Form mit spitzen Winkeln zeichnen, bevorzugen Sie möglicherweise die **Gehrung**‑Option.

![Der Verbindungsstil in der Präsentation](join-style-powerpoint.png)

Der folgende C++‑Code demonstriert, wie drei Rechtecke (wie im Bild oben) mit den Verbindungs‑Typ‑Einstellungen Gehrung, Fase und Rund erstellt wurden:

```cpp
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
auto presentation = MakeObject<Presentation>();

// Die erste Folie abrufen.
auto slide = presentation->get_Slide(0);

// Fügen Sie drei AutoShapes vom Typ Rectangle hinzu.
auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

// Legen Sie die Füllfarbe für jedes Rechteck-Shape fest.
shape1->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape2->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape3->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// Legen Sie die Linienbreite fest.
shape1->get_LineFormat()->set_Width(15);
shape2->get_LineFormat()->set_Width(15);
shape3->get_LineFormat()->set_Width(15);

// Legen Sie die Farbe für die Linie jedes Rechtecks fest.
shape1->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape3->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Legen Sie den Verbindungsstil fest.
shape1->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
shape2->get_LineFormat()->set_JoinStyle(LineJoinStyle::Bevel);
shape3->get_LineFormat()->set_JoinStyle(LineJoinStyle::Round);

// Fügen Sie jedem Rechteck Text hinzu.
shape1->get_TextFrame()->set_Text(u"Miter Join Style");
shape2->get_TextFrame()->set_Text(u"Bevel Join Style");
shape3->get_TextFrame()->set_Text(u"Round Join Style");

// Speichern Sie die PPTX-Datei auf der Festplatte.
presentation->Save(u"join_styles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Verlaufsfüllung**

In PowerPoint ist die Verlaufsfüllung eine Formatierungsoption, mit der Sie einer Form einen kontinuierlichen Farbübergang zuweisen können. Zum Beispiel können Sie zwei oder mehrere Farben so anwenden, dass die eine allmählich in die andere übergeht.

So wenden Sie eine Verlaufsfüllung auf eine Form mit Aspose.Slides an:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/).
1. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/de/cpp/aspose.slides/filltype/) der Form auf `Gradient`.
1. Fügen Sie mit den `Add`‑Methoden der Verlaufs‑Stop‑Sammlung, die über die Schnittstelle [IGradientFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/igradientformat/) bereitgestellt wird, Ihre beiden gewünschten Farben mit definierten Positionen hinzu.
1. Speichern Sie die geänderte Präsentation als PPTX-Datei.

```cpp
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
auto presentation = MakeObject<Presentation>();

// Die erste Folie abrufen.
auto slide = presentation->get_Slide(0);

// Ein AutoShape vom Typ Ellipse hinzufügen.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

// Wenden Sie eine Verlaufsformatierung auf die Ellipse an.
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);

// Legen Sie die Richtung des Verlaufs fest.
shape->get_FillFormat()->get_GradientFormat()->set_GradientDirection(GradientDirection::FromCorner2);

// Zwei Verlaufspunkte hinzufügen.
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

// Speichern Sie die PPTX-Datei auf der Festplatte.
presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Die Ellipse mit Verlaufsfüllung](gradient-fill.png)

## **Musterfüllung**

In PowerPoint ist die Musterfüllung eine Formatierungsoption, mit der Sie ein zweifarbiges Design – etwa Punkte, Streifen, Kreuzschraffuren oder Karos – auf eine Form anwenden können. Sie können für den Vorder‑ und Hintergrund des Musters benutzerdefinierte Farben wählen.

Aspose.Slides stellt über 45 vordefinierte Musterstile bereit, die Sie auf Formen anwenden können, um die visuelle Wirkung Ihrer Präsentationen zu erhöhen. Auch nachdem Sie ein vordefiniertes Muster ausgewählt haben, können Sie die genauen Farben festlegen, die verwendet werden sollen.

So wenden Sie eine Musterfüllung auf eine Form mit Aspose.Slides an:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/).
1. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/de/cpp/aspose.slides/filltype/) der Form auf `Pattern`.
1. Wählen Sie einen Musterstil aus den vordefinierten Optionen.
1. Setzen Sie die [Background Color](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipatternformat/get_backcolor/) des Musters.
1. Setzen Sie die [Foreground Color](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipatternformat/get_forecolor/) des Musters.
1. Speichern Sie die geänderte Präsentation als PPTX-Datei.

```cpp
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
auto presentation = MakeObject<Presentation>();

// Die erste Folie abrufen.
auto slide = presentation->get_Slide(0);

// Ein AutoShape vom Typ Rectangle hinzufügen.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Den Fülltyp auf Pattern setzen.
shape->get_FillFormat()->set_FillType(FillType::Pattern);

// Den Musterstil setzen.
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// Setzen Sie die Hintergrund- und Vordergrundfarben des Musters.
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// Speichern Sie die PPTX-Datei auf der Festplatte.
presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Das Rechteck mit Musterfüllung](pattern-fill.png)

## **Bildfüllung**

In PowerPoint ist die Bildfüllung eine Formatierungsoption, die es Ihnen ermöglicht, ein Bild in eine Form einzufügen – das Bild dient dabei effektiv als Hintergrund der Form.

So verwenden Sie Aspose.Slides, um eine Bildfüllung auf eine Form anzuwenden:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/).
1. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/de/cpp/aspose.slides/filltype/) der Form auf `Picture`.
1. Setzen Sie den Bildfüllungsmodus auf `Tile` (oder einen anderen bevorzugten Modus).
1. Erzeugen Sie ein [IPPImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ippimage/)‑Objekt aus dem Bild, das Sie verwenden möchten.
1. Übergeben Sie das Bild an die Methode `ISlidesPicture.set_Image`.
1. Speichern Sie die geänderte Präsentation als PPTX-Datei.

Nehmen wir an, wir haben die Datei „lotus.png“ mit folgendem Bild:

![Das Lotus‑Bild](lotus.png)

Der folgende C++‑Code demonstriert, wie eine Form mit dem Bild gefüllt wird:

```cpp
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
auto presentation = MakeObject<Presentation>();

// Die erste Folie abrufen.
auto slide = presentation->get_Slide(0);

// Ein AutoShape vom Typ Rectangle hinzufügen.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

// Den Fülltyp auf Picture setzen.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Den Bildfüllungsmodus setzen.
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

// Bild laden und zu den Präsentationsressourcen hinzufügen.
auto image = Images::FromFile(u"lotus.png");
auto picture = presentation->get_Images()->AddImage(image);
image->Dispose();

// Das Bild setzen.
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(picture);

// Die PPTX-Datei auf der Festplatte speichern.
presentation->Save(u"picture_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Die Form mit Bildfüllung](picture-fill.png)

### **Bild kacheln als Textur**

Wenn Sie ein gekacheltes Bild als Textur festlegen und das Kacheln‑Verhalten anpassen möchten, können Sie die folgenden Methoden der Schnittstelle [IPictureFillFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipicturefillformat/) und der Klasse [PictureFillFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/picturefillformat/) verwenden:

- [set_PictureFillMode](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): Legt den Bildfüllungsmodus fest – entweder `Tile` oder `Stretch`.
- [set_TileAlignment](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): Gibt die Ausrichtung der Kacheln innerhalb der Form an.
- [set_TileFlip](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipicturefillformat/set_tileflip/): Steuert, ob die Kachel horizontal, vertikal oder beides gespiegelt wird.
- [set_TileOffsetX](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): Legt den horizontalen Versatz der Kachel (in Punkten) vom Ursprung der Form fest.
- [set_TileOffsetY](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): Legt den vertikalen Versatz der Kachel (in Punkten) vom Ursprung der Form fest.
- [set_TileScaleX](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): Definiert den horizontalen Skalierungsprozentsatz der Kachel.
- [set_TileScaleY](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): Definiert den vertikalen Skalierungsprozentsatz der Kachel.

Der folgende Beispielcode zeigt, wie ein Rechteck mit gekachelter Bildfüllung hinzugefügt und die Kacheloptionen konfiguriert werden:

```cpp
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
auto presentation = MakeObject<Presentation>();

// Die erste Folie abrufen.
auto firstSlide = presentation->get_Slide(0);

// Ein Rechteck‑AutoShape hinzufügen.
auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

// Den Fülltyp der Form auf Picture setzen.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Das Bild laden und zu den Präsentationsressourcen hinzufügen.
auto sourceImage = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

// Das Bild der Form zuweisen.
auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);

// Den Bildfüllungsmodus und die Kachel‑Eigenschaften konfigurieren.
pictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
pictureFillFormat->set_TileOffsetX(-32);
pictureFillFormat->set_TileOffsetY(-32);
pictureFillFormat->set_TileScaleX(50);
pictureFillFormat->set_TileScaleY(50);
pictureFillFormat->set_TileAlignment(RectangleAlignment::BottomRight);
pictureFillFormat->set_TileFlip(TileFlip::FlipBoth);

// Die PPTX-Datei auf der Festplatte speichern.
presentation->Save(u"tile.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Die Kacheloptionen](tile-options.png)

## **Einfarbige Füllung**

In PowerPoint ist die einfarbige Füllung eine Formatierungsoption, die eine Form mit einer einzigen, gleichmäßigen Farbe füllt. Dieser einfache Hintergrund wird ohne Verläufe, Texturen oder Muster angewendet.

Um eine einfarbige Füllung auf eine Form mit Aspose.Slides anzuwenden, gehen Sie folgendermaßen vor:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/).
1. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/de/cpp/aspose.slides/filltype/) der Form auf `Solid`.
1. Weisen Sie der Form Ihre bevorzugte Füllfarbe zu.
1. Speichern Sie die geänderte Präsentation als PPTX-Datei.

```cpp
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
auto presentation = MakeObject<Presentation>();

// Die erste Folie abrufen.
auto slide = presentation->get_Slide(0);

// Ein AutoShape vom Typ Rectangle hinzufügen.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Den Fülltyp auf Solid setzen.
shape->get_FillFormat()->set_FillType(FillType::Solid);

// Die Füllfarbe setzen.
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// Die PPTX-Datei auf der Festplatte speichern.
presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Die Form mit einfarbiger Füllung](solid-color-fill.png)

## **Transparenz festlegen**

In PowerPoint können Sie bei einer einfarbigen, Verlauf-, Bild‑ oder Texturfüllung die Transparenzstufe einstellen, um die Undurchsichtigkeit der Füllung zu steuern. Ein höherer Transparenzwert lässt die Form durchsichtiger erscheinen, sodass der Hintergrund oder darunterliegende Objekte teilweise sichtbar werden.

Aspose.Slides ermöglicht das Festlegen der Transparenz, indem Sie den Alphawert in der für die Füllung verwendeten Farbe anpassen. So geht’s:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/).
1. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/) hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/de/cpp/aspose.slides/filltype/) der Form auf `Solid`.
1. Verwenden Sie `Color`, um eine Farbe mit Transparenz zu definieren (die `alpha`‑Komponente steuert die Transparenz).
1. Speichern Sie die Präsentation.

```cpp
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
auto presentation = MakeObject<Presentation>();

// Die erste Folie abrufen.
auto slide = presentation->get_Slide(0);

// Ein solides Rechteck-AutoShape hinzufügen.
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Ein transparentes Rechteck-AutoShape über dem soliden Shape hinzufügen.
auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(204, 255, 255, 0));

// Die PPTX-Datei auf der Festplatte speichern.
presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Die transparente Form](shape-transparency.png)

## **Formen drehen**

Aspose.Slides ermöglicht das Drehen von Formen in PowerPoint‑Präsentationen. Dies kann nützlich sein, wenn visuelle Elemente mit bestimmten Ausrichtungs‑ oder Designanforderungen positioniert werden sollen.

So drehen Sie eine Form auf einer Folie:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/).
1. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/) hinzu.
1. Setzen Sie die Drehungseigenschaft der Form auf den gewünschten Winkel.
1. Speichern Sie die Präsentation.

```cpp
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
auto presentation = MakeObject<Presentation>();

// Die erste Folie abrufen.
auto slide = presentation->get_Slide(0);

// Ein AutoShape vom Typ Rectangle hinzufügen.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Die Form um 5 Grad drehen.
shape->set_Rotation(5);

// Die PPTX-Datei auf der Festplatte speichern.
presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Die Formdrehung](shape-rotation.png)

## **3D‑Kanteneffekte hinzufügen**

Aspose.Slides ermöglicht das Hinzufügen von 3D‑Kanteneffekten zu Formen, indem deren [ThreeDFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/threedformat/)-Eigenschaften konfiguriert werden.

So fügen Sie einer Form 3D‑Kanteneffekte hinzu:

1. Instanziieren Sie die Klasse [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/).
1. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/) hinzu.
1. Konfigurieren Sie das [ThreeDFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/threedformat/) der Form, um die Kanten­einstellungen festzulegen.
1. Speichern Sie die Präsentation.

```cpp
// Instanziieren Sie die Presentation-Klasse.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Ein Shape zur Folie hinzufügen.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Green());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->set_Width(2.0);

// Setzen Sie die ThreeDFormat-Eigenschaften des Shapes.
shape->get_ThreeDFormat()->set_Depth(4.0);
shape->get_ThreeDFormat()->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
shape->get_ThreeDFormat()->get_BevelTop()->set_Height(6);
shape->get_ThreeDFormat()->get_BevelTop()->set_Width(6);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);

// Speichern Sie die Präsentation als PPTX-Datei.
presentation->Save(u"3D_bevel_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Der 3D‑Kanten‑Effekt](3D-bevel-effect.png)

## **3D‑Drehungseffekte hinzufügen**

Aspose.Slides ermöglicht das Anwenden von 3D‑Drehungseffekten auf Formen, indem deren [ThreeDFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/threedformat/)-Eigenschaften konfiguriert werden.

So wenden Sie eine 3D‑Drehung auf eine Form an:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/).
1. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/) hinzu.
1. Verwenden Sie [set_CameraType](https://reference.aspose.com/slides/de/cpp/aspose.slides/icamera/set_cameratype/) und [set_LightType](https://reference.aspose.com/slides/de/cpp/aspose.slides/ilightrig/set_lighttype/), um die 3D‑Drehung zu definieren.
1. Speichern Sie die Präsentation.

```cpp
// Instanziieren Sie die Presentation-Klasse.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_TextFrame()->set_Text(u"Hello, Aspose!");

shape->get_ThreeDFormat()->set_Depth(6);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(40, 35, 20);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

// Speichern Sie die Präsentation als PPTX-Datei.
presentation->Save(u"3D_rotation_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Der 3D‑Drehungseffekt](3D-rotation-effect.png)

## **Formatierung zurücksetzen**

Der folgende C++‑Code zeigt, wie die Formatierung einer Folie zurückgesetzt und die Position, Größe und Formatierung aller Formen mit Platzhaltern auf dem [LayoutSlide](https://reference.aspose.com/slides/de/cpp/aspose.slides/layoutslide/) auf deren Standardwerte zurückgesetzt werden:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // Setzen Sie jede Form auf der Folie zurück, die einen Platzhalter im Layout hat.
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Beeinflusst die Formformatierung die endgültige Dateigröße der Präsentation?**

Nur minimal. Eingebettete Bilder und Medien belegen den größten Teil des Speicherplatzes, während Formparameter wie Farben, Effekte und Verläufe als Metadaten gespeichert werden und praktisch keinen zusätzlichen Platz beanspruchen.

**Wie kann ich Formen auf einer Folie erkennen, die identische Formatierungen besitzen, um sie zu gruppieren?**

Vergleichen Sie die wichtigsten Formatierungseigenschaften jeder Form – Füllung, Linie und Effekt‑Einstellungen. Stimmen alle entsprechenden Werte überein, können Sie die Stile als identisch ansehen und die Formen logisch gruppieren, was die spätere Stilverwaltung vereinfacht.

**Kann ich einen Satz benutzerdefinierter Formstile in einer separaten Datei speichern, um sie in anderen Präsentationen wiederzuverwenden?**

Ja. Speichern Sie Beispiel­formen mit den gewünschten Stilen in einer Vorlagen‑Präsentation oder einer .POTX‑Vorlagendatei. Beim Erstellen einer neuen Präsentation öffnen Sie die Vorlage, duplizieren die benötigten gestylten Formen und wenden deren Formatierung dort an, wo sie benötigt wird.