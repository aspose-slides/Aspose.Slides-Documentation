---
title: PowerPoint-Formate in C++ formatieren
linktitle: Formformatierung
type: docs
weight: 20
url: /de/cpp/shape-formatting/
keywords:
- Form formatieren
- Linie formatieren
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
description: "Erfahren Sie, wie Sie PowerPoint-Formen in C++ mit Aspose.Slides—Füll-, Linien- und Effektstile für PPT-, PPTX- und ODP-Dateien präzise und vollständig steuern."
---

## **Übersicht**

In PowerPoint können Sie Formen zu Folien hinzufügen. Da Formen aus Linien bestehen, können Sie diese formatieren, indem Sie deren Konturen modifizieren oder Effekte darauf anwenden. Zusätzlich können Sie Formen formatieren, indem Sie Einstellungen festlegen, die steuern, wie deren Innenseiten gefüllt werden.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides für C++ bietet Schnittstellen und Methoden, mit denen Sie Formen mit denselben Optionen formatieren können, die in PowerPoint verfügbar sind.

## **Linien formatieren**

Mit Aspose.Slides können Sie einen benutzerdefinierten Linienstil für eine Form festlegen. Die folgenden Schritte beschreiben den Vorgang:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Holen Sie eine Referenz auf eine Folie anhand ihres Indexes.
3. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) hinzu.
4. Setzen Sie den [line style](https://reference.aspose.com/slides/cpp/aspose.slides/linestyle/) der Form.
5. Setzen Sie die Linienbreite.
6. Setzen Sie den [dash style](https://reference.aspose.com/slides/cpp/aspose.slides/linedashstyle/) der Linie.
7. Setzen Sie die Linienfarbe für die Form.
8. Speichern Sie die geänderte Präsentation als PPTX-Datei.

Der folgende Code zeigt, wie ein Rechteck‑`AutoShape` formatiert wird:
```cpp
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei repräsentiert.
auto presentation = MakeObject<Presentation>();

// Holen Sie die erste Folie.
auto slide = presentation->get_Slide(0);

// Fügen Sie eine AutoShape vom Typ Rechteck hinzu.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// Setzen Sie die Füllfarbe für die Rechteckform.
shape->get_FillFormat()->set_FillType(FillType::NoFill);

// Wenden Sie Formatierungen auf die Linien des Rechtecks an.
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);

// Setzen Sie die Farbe für die Linie des Rechtecks.
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Speichern Sie die PPTX-Datei auf dem Datenträger.
presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


Das Ergebnis:

![The formatted lines in the presentation](formatted-lines.png)

## **Verbindungsstile formatieren**

Hier sind die drei Optionen für Verbindungstypen:

* Rund
* Gehrung
* Abschrägung

Standardmäßig verwendet PowerPoint, wenn es zwei Linien in einem Winkel verbindet (wie an einer eckigen Form), die Einstellung **Rund**. Wenn Sie jedoch eine Form mit scharfen Winkeln zeichnen, bevorzugen Sie möglicherweise die **Gehrung**‑Option.

![The join style in the presentation](join-style-powerpoint.png)

Der folgende C++‑Code zeigt, wie drei Rechtecke (wie im obigen Bild dargestellt) mit den Einstellungen für die Verbindungstypen Miter, Bevel und Round erstellt wurden:
```cpp
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei repräsentiert.
auto presentation = MakeObject<Presentation>();

// Holen Sie die erste Folie.
auto slide = presentation->get_Slide(0);

// Fügen Sie drei AutoShapes des Typs Rechteck hinzu.
auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

// Setzen Sie die Füllfarbe für jede Rechtecksform.
shape1->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape2->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape3->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// Setzen Sie die Linienbreite.
shape1->get_LineFormat()->set_Width(15);
shape2->get_LineFormat()->set_Width(15);
shape3->get_LineFormat()->set_Width(15);

// Setzen Sie die Farbe für die Linie jedes Rechtecks.
shape1->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape3->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Setzen Sie den Verbindungsstil.
shape1->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
shape2->get_LineFormat()->set_JoinStyle(LineJoinStyle::Bevel);
shape3->get_LineFormat()->set_JoinStyle(LineJoinStyle::Round);

// Fügen Sie jedem Rechteck Text hinzu.
shape1->get_TextFrame()->set_Text(u"Miter Join Style");
shape2->get_TextFrame()->set_Text(u"Bevel Join Style");
shape3->get_TextFrame()->set_Text(u"Round Join Style");

// Speichern Sie die PPTX-Datei auf dem Datenträger.
presentation->Save(u"join_styles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Verlaufsfüllung**

In PowerPoint ist die Verlaufsfüllung eine Formatierungsoption, mit der Sie einer Form einen kontinuierlichen Farbübergang zuweisen können. Beispielsweise können Sie zwei oder mehr Farben anwenden, sodass eine allmählich in die andere übergeht.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Holen Sie eine Referenz auf eine Folie anhand ihres Indexes.
3. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) hinzu.
4. Setzen Sie den [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) der Form auf `Gradient`.
5. Fügen Sie Ihre beiden bevorzugten Farben mit definierten Positionen hinzu, indem Sie die `Add`‑Methoden der Farbverlaufs‑Stop‑Sammlung verwenden, die über die Schnittstelle [IGradientFormat](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/) bereitgestellt wird.
6. Speichern Sie die geänderte Präsentation als PPTX-Datei.

```cpp
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei repräsentiert.
auto presentation = MakeObject<Presentation>();

// Holen Sie die erste Folie.
auto slide = presentation->get_Slide(0);

// Fügen Sie eine AutoShape des Typs Ellipse hinzu.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

// Wenden Sie eine Verlaufsformatierung auf die Ellipse an.
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);

// Setzen Sie die Richtung des Verlaufs.
shape->get_FillFormat()->get_GradientFormat()->set_GradientDirection(GradientDirection::FromCorner2);

// Fügen Sie zwei Gradient-Stops hinzu.
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

// Speichern Sie die PPTX-Datei auf dem Datenträger.
presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


Das Ergebnis:

![The ellipse with gradient fill](gradient-fill.png)

## **Musterfüllung**

In PowerPoint ist die Musterfüllung eine Formatierungsoption, die es Ihnen ermöglicht, einem Objekt ein zweifarbiges Design – wie Punkte, Streifen, Kreuzschraffuren oder Karos – zuzuweisen. Sie können benutzerdefinierte Farben für Vorder- und Hintergrund des Musters wählen.

Aspose.Slides stellt über 45 vordefinierte Musterstile bereit, die Sie Formen zuweisen können, um die optische Attraktivität Ihrer Präsentationen zu verbessern. Auch nach Auswahl eines vordefinierten Musters können Sie die genauen Farben festlegen, die verwendet werden sollen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Holen Sie eine Referenz auf eine Folie anhand ihres Indexes.
3. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) hinzu.
4. Setzen Sie den [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) der Form auf `Pattern`.
5. Wählen Sie einen Musterstil aus den vordefinierten Optionen.
6. Setzen Sie die [Background Color](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_backcolor/) des Musters.
7. Setzen Sie die [Foreground Color](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_forecolor/) des Musters.
8. Speichern Sie die geänderte Präsentation als PPTX-Datei.

```cpp
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei repräsentiert.
auto presentation = MakeObject<Presentation>();

// Holen Sie die erste Folie.
auto slide = presentation->get_Slide(0);

// Fügen Sie eine AutoShape des Typs Rectangle hinzu.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Setzen Sie den Fülltyp auf Pattern.
shape->get_FillFormat()->set_FillType(FillType::Pattern);

// Setzen Sie den Musterstil.
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// Setzen Sie die Hintergrund- und Vordergrundfarben des Musters.
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// Speichern Sie die PPTX-Datei auf dem Datenträger.
presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


Das Ergebnis:

![The rectangle with pattern fill](pattern-fill.png)

## **Bildfüllung**

In PowerPoint ist die Bildfüllung eine Formatierungsoption, die es Ihnen ermöglicht, ein Bild in eine Form einzufügen – das Bild dient dabei effektiv als Hintergrund der Form.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Holen Sie eine Referenz auf eine Folie anhand ihres Indexes.
3. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) hinzu.
4. Setzen Sie den [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) der Form auf `Picture`.
5. Setzen Sie den Bildfüllungsmodus auf `Tile` (oder einen anderen gewünschten Modus).
6. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/)‑Objekt aus dem Bild, das Sie verwenden möchten.
7. Übergeben Sie das Bild an die Methode `ISlidesPicture.set_Image`.
8. Speichern Sie die geänderte Präsentation als PPTX-Datei.

Angenommen, wir haben eine Datei "lotus.png" mit folgendem Bild:

![The lotus picture](lotus.png)

```cpp
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
auto presentation = MakeObject<Presentation>();

// Holen Sie die erste Folie.
auto slide = presentation->get_Slide(0);

// Fügen Sie eine AutoShape des Typs Rectangle hinzu.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

// Setzen Sie den Fülltyp auf Picture.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Setzen Sie den Bildfüllungsmodus.
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

// Laden Sie ein Bild und fügen Sie es zu den Präsentationsressourcen hinzu.
auto image = Images::FromFile(u"lotus.png");
auto picture = presentation->get_Images()->AddImage(image);
image->Dispose();

// Setzen Sie das Bild.
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(picture);

// Speichern Sie die PPTX-Datei auf dem Datenträger.
presentation->Save(u"picture_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```



Das Ergebnis:

![The shape with picture fill](picture-fill.png)

### **Bild kacheln als Textur**

Wenn Sie ein gekacheltes Bild als Textur festlegen und das Kachelaterverhalten anpassen möchten, können Sie die folgenden Methoden der Schnittstelle [IPictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/) und der Klasse [PictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/) verwenden:

- [set_PictureFillMode](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): Setzt den Bildfüllungsmodus – entweder `Tile` oder `Stretch`.
- [set_TileAlignment](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): Gibt die Ausrichtung der Kacheln innerhalb der Form an.
- [set_TileFlip](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileflip/): Steuert, ob die Kachel horizontal, vertikal oder beides gespiegelt wird.
- [set_TileOffsetX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): Setzt den horizontalen Versatz der Kachel (in Punkt) vom Ursprung der Form.
- [set_TileOffsetY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): Setzt den vertikalen Versatz der Kachel (in Punkt) vom Ursprung der Form.
- [set_TileScaleX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): Definiert die horizontale Skalierung der Kachel als Prozentsatz.
- [set_TileScaleY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): Definiert die vertikale Skalierung der Kachel als Prozentsatz.

Der folgende Beispielcode zeigt, wie ein Rechteck mit gekachelter Bildfüllung hinzugefügt und Kacheloptionen konfiguriert werden:
```cpp
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
auto presentation = MakeObject<Presentation>();

// Holen Sie die erste Folie.
auto firstSlide = presentation->get_Slide(0);

// Fügen Sie eine AutoShape des Typs Rectangle hinzu.
auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

// Setzen Sie den Fülltyp der Form auf Picture.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Laden Sie das Bild und fügen Sie es zu den Präsentationsressourcen hinzu.
auto sourceImage = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

// Weisen Sie das Bild der Form zu.
auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);

// Konfigurieren Sie den Bildfüllungsmodus und die Kacheleigenschaften.
pictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
pictureFillFormat->set_TileOffsetX(-32);
pictureFillFormat->set_TileOffsetY(-32);
pictureFillFormat->set_TileScaleX(50);
pictureFillFormat->set_TileScaleY(50);
pictureFillFormat->set_TileAlignment(RectangleAlignment::BottomRight);
pictureFillFormat->set_TileFlip(TileFlip::FlipBoth);

// Speichern Sie die PPTX-Datei auf dem Datenträger.
presentation->Save(u"tile.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


Das Ergebnis:

![The tile options](tile-options.png)

## **Einfarbige Füllung**

In PowerPoint ist die einfarbige Füllung eine Formatierungsoption, die eine Form mit einer einzigen, einheitlichen Farbe füllt. Diese einfache Hintergrundfarbe wird ohne Verläufe, Texturen oder Muster angewendet.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Holen Sie eine Referenz auf eine Folie anhand ihres Indexes.
3. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) hinzu.
4. Setzen Sie den [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) der Form auf `Solid`.
5. Weisen Sie der Form Ihre gewünschte Füllfarbe zu.
6. Speichern Sie die geänderte Präsentation als PPTX-Datei.

```cpp
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
auto presentation = MakeObject<Presentation>();

// Holen Sie die erste Folie.
auto slide = presentation->get_Slide(0);

// Fügen Sie eine AutoShape des Typs Rectangle hinzu.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Setzen Sie den Fülltyp auf Solid.
shape->get_FillFormat()->set_FillType(FillType::Solid);

// Setzen Sie die Füllfarbe.
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// Speichern Sie die PPTX-Datei auf dem Datenträger.
presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


Das Ergebnis:

![The shape with solid color fill](solid-color-fill.png)

## **Transparenz festlegen**

In PowerPoint können Sie beim Anwenden einer einfarbigen, Verlauf-, Bild- oder Texturfüllung auf Formen auch einen Transparenzwert festlegen, um die Deckkraft der Füllung zu steuern. Ein höherer Transparenzwert macht die Form durchsichtiger, sodass der Hintergrund oder darunter liegende Objekte teilweise sichtbar werden.

Aspose.Slides ermöglicht das Festlegen des Transparenzwerts, indem Sie den Alpha‑Wert der für die Füllung verwendeten Farbe anpassen. So geht’s:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Holen Sie eine Referenz auf eine Folie anhand ihres Indexes.
3. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) hinzu.
4. Setzen Sie den [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) der Form auf `Solid`.
5. Verwenden Sie `Color`, um eine Farbe mit Transparenz zu definieren (die Komponente `alpha` steuert die Transparenz).
6. Speichern Sie die Präsentation.

```cpp
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
auto presentation = MakeObject<Presentation>();

// Holen Sie die erste Folie.
auto slide = presentation->get_Slide(0);

// Fügen Sie eine solide Rechteck-AutoShape hinzu.
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Fügen Sie eine transparente Rechteck-AutoShape über der soliden Form hinzu.
auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(204, 255, 255, 0));

// Speichern Sie die PPTX-Datei auf dem Datenträger.
presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


Das Ergebnis:

![The transparent shape](shape-transparency.png)

## **Formen drehen**

Aspose.Slides ermöglicht das Drehen von Formen in PowerPoint‑Präsentationen. Dies kann nützlich sein, um visuelle Elemente mit bestimmten Ausrichtungs‑ oder Designanforderungen zu positionieren.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Holen Sie eine Referenz auf eine Folie anhand ihres Indexes.
3. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) hinzu.
4. Setzen Sie die Rotations‑Eigenschaft der Form auf den gewünschten Winkel.
5. Speichern Sie die Präsentation.

```cpp
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
auto presentation = MakeObject<Presentation>();

// Holen Sie die erste Folie.
auto slide = presentation->get_Slide(0);

// Fügen Sie eine AutoShape des Typs Rectangle hinzu.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Drehen Sie die Form um 5 Grad.
shape->set_Rotation(5);

// Speichern Sie die PPTX-Datei auf dem Datenträger.
presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


Das Ergebnis:

![The shape rotation](shape-rotation.png)

## **3D‑Kanteneffekte hinzufügen**

Aspose.Slides ermöglicht das Anwenden von 3D‑Kanteneffekten auf Formen, indem deren [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/)‑Eigenschaften konfiguriert werden.

1. Instanziieren Sie die Klasse [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Holen Sie eine Referenz auf eine Folie anhand ihres Indexes.
3. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) hinzu.
4. Konfigurieren Sie das [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/) der Form, um die Kanten‑Einstellungen zu definieren.
5. Speichern Sie die Präsentation.

```cpp
// Erstellen Sie eine Instanz der Presentation-Klasse.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Fügen Sie der Folie eine Form hinzu.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Green());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->set_Width(2.0);

// Setzen Sie die ThreeDFormat-Eigenschaften der Form.
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


Das Ergebnis:

![The 3D bevel effect](3D-bevel-effect.png)

## **3D‑Drehungseffekte hinzufügen**

Aspose.Slides ermöglicht das Anwenden von 3D‑Drehungseffekten auf Formen, indem deren [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/)‑Eigenschaften konfiguriert werden.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Holen Sie eine Referenz auf eine Folie anhand ihres Indexes.
3. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) hinzu.
4. Verwenden Sie die Methoden [set_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/set_cameratype/) und [set_LightType](https://reference.aspose.com/slides/cpp/aspose.slides/ilightrig/set_lighttype/), um die 3D‑Drehung zu definieren.
5. Speichern Sie die Präsentation.

```cpp
// Erstellen Sie eine Instanz der Presentation-Klasse.
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


Das Ergebnis:

![The 3D rotation effect](3D-rotation-effect.png)

## **Formatierung zurücksetzen**

Der folgende C++‑Code zeigt, wie die Formatierung einer Folie zurückgesetzt und die Position, Größe und Formatierung aller Formen mit Platzhaltern auf dem [LayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/layoutslide/) auf die Standardeinstellungen zurückgesetzt werden:
```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // Zurücksetzen jeder Form auf der Folie, die einen Platzhalter im Layout hat.
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **FAQ**

**Beeinflusst die Formatierung von Formen die endgültige Dateigröße der Präsentation?**

Nur in geringem Maße. Eingebettete Bilder und Medien beanspruchen den Großteil des Speicherplatzes, während Formparameter wie Farben, Effekte und Verläufe als Metadaten gespeichert werden und praktisch keinen zusätzlichen Platz benötigen.

**Wie kann ich Formen auf einer Folie erkennen, die identische Formatierung aufweisen, damit ich sie gruppieren kann?**

Vergleichen Sie die wesentlichen Formatierungseigenschaften jeder Form – Füllung, Kontur und Effekt‑Einstellungen. Stimmen alle entsprechenden Werte überein, können Sie deren Stile als identisch betrachten und die Formen logisch gruppieren, was die spätere Stilverwaltung vereinfacht.

**Kann ich ein Set benutzerdefinierter Formstile in einer separaten Datei speichern, um sie in anderen Präsentationen wiederzuverwenden?**

Ja. Speichern Sie Beispielformen mit den gewünschten Stilen in einem Vorlagen‑Slide‑Deck oder einer .POTX‑Vorlagendatei. Beim Erstellen einer neuen Präsentation öffnen Sie die Vorlage, klonen die benötigten stilisierten Formen und wenden deren Formatierung dort an, wo sie benötigt wird.