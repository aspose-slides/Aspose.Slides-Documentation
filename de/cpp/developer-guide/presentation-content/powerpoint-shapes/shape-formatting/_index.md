---
title: Formatausdruck
type: docs
weight: 20
url: /de/cpp/shape-formatting/
keywords: "Formatiere Form, formatiere Linien, formatiere Verbindungstile, Farbverlauf-Füllung, Muster-Füllung, Bildfüllung, einfarbige Füllung, Formen drehen, 3D-Facetteneffekte, 3D-Drehungseffekt, PowerPoint-Präsentation, C++, Aspose.Slides für C++"
description: "Formatiere eine Form in PowerPoint-Präsentation in C++"
---

In PowerPoint kannst du Formen zu Folien hinzufügen. Da Formen aus Linien bestehen, kannst du Formen formatieren, indem du bestimmte Effekte auf ihre einzelnen Linien anwendest oder modifizierst. Zusätzlich kannst du Formen formatieren, indem du Einstellungen angibst, die bestimmen, wie sie (der Bereich in ihnen) gefüllt sind.

![format-shape-powerpoint](format-shape-powerpoint.png)

**Aspose.Slides für C++** bietet Schnittstellen und Eigenschaften, die es dir ermöglichen, Formen basierend auf bekannten Optionen in PowerPoint zu formatieren.

## **Linien formatieren**

Mit Aspose.Slides kannst du deinen bevorzugten Linienstil für eine Form angeben. Die folgenden Schritte skizzieren ein solches Verfahren:

1. Erstelle eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
2. Hole einen Verweis auf eine Folie über ihren Index.
3. Füge der Folie eine [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) hinzu.
4. Setze eine Farbe für die Formlinien.
5. Setze die Breite für die Formlinien.
6. Setze den [Linienstil](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a837c78839bf6ebb16979455cd1de59e4) für die Linien der Form.
7. Setze den [Strichstil](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a7eaad354a35a3b567a7327d625be3c6e) für die Linien der Form.
8. Schreibe die modifizierte Präsentation als PPTX-Datei.

Dieser C++-Code demonstriert eine Operation, bei der wir ein Rechteck `AutoShape` formatiert haben:

```cpp
// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt
auto pres = MakeObject<Presentation>();

// Holt die erste Folie
auto slide = pres->get_Slides()->idx_get(0);

// Fügt eine Autoform des Rechtecktyps hinzu
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// Setzt die Füllfarbe für die Rechtecksform
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_White());

// Wendet einige Formatierungen auf die Linien des Rechtecks an
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);

// Setzt die Farbe für die Linie des Rechtecks
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Schreibt die PPTX-Datei auf die Festplatte
pres->Save(u"RectShpLn_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Verbindungstile formatieren**
Dies sind die 3 Optionen für Verbindungstypen:

* Rund
* Gehrung
* Fase

Standardmäßig verwendet PowerPoint die Einstellung **Rund**, wenn es zwei Linien in einem Winkel (oder an einer Ecke einer Form) verbindet. Wenn du jedoch eine Form mit sehr scharfen Winkeln zeichnen möchtest, möchtest du möglicherweise **Gehrung** auswählen.

![join-style-powerpoint](join-style-powerpoint.png)

Dieser C++-Code demonstriert eine Operation, bei der 3 Rechtecke (das Bild oben) mit den Verbindungstyp-Einstellungen Gehrung, Fase und Rund erstellt wurden:

```cpp
// Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt
auto pres = MakeObject<Presentation>();

// Holt die erste Folie
auto slide = pres->get_Slides()->idx_get(0);

// Fügt 3 rechteckige Autoformen hinzu
SharedPtr<IAutoShape> shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);
SharedPtr<IAutoShape> shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 300, 100, 150, 75);
SharedPtr<IAutoShape> shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 250, 150, 75);

// Setzt die Füllfarbe für die rechteckige Form
shape1->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape2->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape3->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// Setzt die Breite der Linie
shape1->get_LineFormat()->set_Width(15);
shape2->get_LineFormat()->set_Width(15);
shape3->get_LineFormat()->set_Width(15);

// Setzt die Farbe für die Linie des Rechtecks
shape1->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape3->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Setzt den Verbindungstyp
shape1->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
shape2->get_LineFormat()->set_JoinStyle(LineJoinStyle::Bevel);
shape3->get_LineFormat()->set_JoinStyle(LineJoinStyle::Round);

// Fügt jedem Rechteck Text hinzu
shape1->get_TextFrame()->set_Text(u"Miter Verbindungstyp");
shape2->get_TextFrame()->set_Text(u"Fase Verbindungstyp");
shape3->get_TextFrame()->set_Text(u"Rund Verbindungstyp");

// Schreibt die PPTX-Datei auf die Festplatte
pres->Save(u"RectShpLnJoin_out.pptx", Export::SaveFormat::Pptx);
```

## **Farbverlauf-Füllung**
In PowerPoint ist die Farbverlauf-Füllung eine Formatierungsoption, die es dir ermöglicht, eine kontinuierliche Mischung von Farben auf eine Form anzuwenden. Zum Beispiel kannst du zwei oder mehr Farben in einem Setup anwenden, bei dem eine Farbe allmählich in eine andere Farbe übergeht.

So verwendest du Aspose.Slides, um eine Farbverlauf-Füllung auf eine Form anzuwenden:

1. Erstelle eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
2. Hole einen Verweis auf eine Folie über ihren Index.
3. Füge der Folie eine [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) hinzu.
4. Setze den [Fülltyp](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a) der Form auf `Gradient`.
5. Füge deine 2 bevorzugten Farben mit definierten Positionen hinzu, indem du die `Add`-Methoden verwendest, die von der `GradientStops`-Kollektion der `GradientFormat`-Klasse bereitgestellt werden.
6. Schreibe die modifizierte Präsentation als PPTX-Datei.

Dieser C++-Code demonstriert eine Operation, bei der der Farbverlauf-Fülleffekt auf eine Ellipse angewendet wurde:

```cpp
// Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt
auto pres = MakeObject<Presentation>();

// Holt die erste Folie
auto slide = pres->get_Slides()->idx_get(0);
    
// Fügt eine elliptische Autoform hinzu
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 150, 75, 150);

// Wendet die Farbverlaufformatierung auf die Ellipse an
autoShape->get_FillFormat()->set_FillType(FillType::Gradient);
autoShape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);

// Setzt die Richtung des Farbverlaufs
autoShape->get_FillFormat()->get_GradientFormat()->set_GradientDirection(GradientDirection::FromCorner2);

// Füge 2 Farbverlaufsstopps hinzu
autoShape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
autoShape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

// Schreibt die PPTX-Datei auf die Festplatte
pres->Save(u"FillShapesGradient_out.pptx", Export::SaveFormat::Pptx);
```

## **Muster-Füllung**
In PowerPoint ist die Muster-Füllung eine Formatierungsoption, die es dir ermöglicht, ein zweifarbendesign aus Punkten, Streifen, Kreuzschraffuren oder Kästchen auf eine Form anzuwenden. Zusätzlich kannst du deine bevorzugten Farben für den Vordergrund und Hintergrund deines Musters auswählen.

Aspose.Slides bietet über 45 vordefinierte Stile, die verwendet werden können, um Formen zu formatieren und Präsentationen zu bereichern. Selbst nachdem du ein vordefiniertes Muster ausgewählt hast, kannst du weiterhin die Farben angeben, die das Muster enthalten muss.

So verwendest du Aspose.Slides, um eine Muster-Füllung auf eine Form anzuwenden:

1. Erstelle eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
2. Hole einen Verweis auf eine Folie über ihren Index.
3. Füge der Folie eine [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) hinzu.
4. Setze den [Fülltyp](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a) der Form auf `Pattern`.
5. Setze deinen bevorzugten Musterstil für die Form.
6. Setze die [Hintergrundfarbe](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_pattern_format#af55b6343b7bd80d0ad95070e96b8766e) für das [PatternFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.pattern_format).
7. Setze die [Vordergrundfarbe](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_pattern_format#a4121d8c2233df4b90cbfd6ea4c312cbe) für das [PatternFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.pattern_format).
8. Schreibe die modifizierte Präsentation als PPTX-Datei.

Dieser C++-Code demonstriert eine Operation, bei der eine Muster-Füllung verwendet wurde, um ein Rechteck zu verschönern:

```cpp
// Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt
auto pres = MakeObject<Presentation>();

// Holt die erste Folie
auto slide = pres->get_Slides()->idx_get(0);

// Fügt eine rechteckige Autoform hinzu
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);

// Setzt den Fülltyp auf Muster
autoShape->get_FillFormat()->set_FillType(FillType::Pattern);

// Setzt den Musterstil
autoShape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// Setzt die Muster-Hintergrund- und Vordergrundfarben
autoShape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color ( Color::get_LightGray());
autoShape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// Schreibt die PPTX-Datei auf die Festplatte
pres->Save(u"RectShpPatt_out.pptx", Export::SaveFormat::Pptx);
```

## **Bildfüllung**
In PowerPoint ist die Bildfüllung eine Formatierungsoption, die es dir ermöglicht, ein Bild in eine Form einzufügen. Im Wesentlichen kannst du ein Bild als Hintergrund einer Form verwenden.

So verwendest du Aspose.Slides, um eine Form mit einem Bild zu füllen:

1. Erstelle eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
2. Hole einen Verweis auf eine Folie über ihren Index.
3. Füge der Folie eine [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) hinzu.
4. Setze den [Fülltyp](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a) der Form auf `Picture`.
5. Setze den Bildfüllmodus auf Kachel.
6. Erstelle ein `IPPImage`-Objekt mit dem Bild, das zur Füllung der Form verwendet wird.
7. Setze die `Picture.Image`-Eigenschaft des `PictureFillFormat`-Objekts auf das neu erstellte `IPPImage`.
8. Schreibe die modifizierte Präsentation als PPTX-Datei.

Dieser C++-Code zeigt dir, wie man eine Form mit einem Bild füllt:

```cpp
// Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt
auto pres = MakeObject<Presentation>();

// Holt die erste Folie
auto slide = pres->get_Slides()->idx_get(0);

// Fügt eine rechteckige Autoform hinzu
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);

// Setzt den Fülltyp auf Bild
autoShape->get_FillFormat()->set_FillType(FillType::Picture);

// Setzt den Bildfüllmodus
autoShape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

// Setzt das Bild
auto img = Images::FromFile(u"Tulips.jpg");
auto imgx = pres->get_Images()->AddImage(img);
autoShape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(imgx);

// Schreibt die PPTX-Datei auf die Festplatte
pres->Save(u"RectShpPic_out.pptx", Export::SaveFormat::Pptx);
```

## **Einfarbige Füllung**
In PowerPoint ist die einfarbige Füllung eine Formatierungsoption, die es dir erlaubt, eine Form mit einer einzigen Farbe zu füllen. Die gewählte Farbe ist typischerweise eine einfarbige Farbe. Die Farbe wird dem Hintergrund der Form mit allen speziellen Effekten oder Modifikationen angewendet.

So verwendest du Aspose.Slides, um eine einfarbige Füllung auf eine Form anzuwenden:

1. Erstelle eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
2. Hole einen Verweis auf eine Folie über ihren Index.
3. Füge der Folie eine [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) hinzu.
4. Setze den [Fülltyp](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a) der Form auf `Solid`.
5. Setze deine bevorzugte Farbe für die Form.
6. Schreibe die modifizierte Präsentation als PPTX-Datei.

Die obigen Schritte werden im folgenden Beispiel umgesetzt.

```cpp
// Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt
auto pres = MakeObject<Presentation>();

// Holt die erste Folie
auto slide = pres->get_Slides()->idx_get(0);

// Fügt eine rechteckige Autoform hinzu
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);

// Setzt den Fülltyp auf Bild
autoShape->get_FillFormat()->set_FillType(FillType::Solid);

// Setzt die Farbe für das Rechteck
autoShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// Schreibt die PPTX-Datei auf die Festplatte
pres->Save(u"RectShpSolid_out.pptx", Export::SaveFormat::Pptx);
```

## **Transparenz einstellen**

In PowerPoint kannst du die Transparenzstufe festlegen, die die Deckkraft einer Füllung bestimmt, wenn du Formen mit einfarbigen Farben, Farbverläufen, Bildern oder Texturen füllst. Auf diese Weise zeigt beispielsweise beim Setzen einer niedrigen Transparenzstufe das Folienobjekt oder der Hintergrund hinter der (Form) hindurch.

Aspose.Slides ermöglicht es dir, die Transparenzstufe einer Form folgendermaßen einzustellen:

1. Erstelle eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
2. Hole einen Verweis auf eine Folie über ihren Index.
3. Füge der Folie eine [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) hinzu.
4. Verwende `Color.FromArgb` mit dem festgelegten Alpha-Komponentenwert.
5. Speichere das Objekt als PowerPoint-Datei.

Dieser C++-Code demonstriert den Vorgang:

```cpp
// Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt
auto pres = MakeObject<Presentation>();

// Holt die erste Folie
auto slide = pres->get_Slides()->idx_get(0);

// Fügt eine feste Form hinzu
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 75, 175, 75, 150);

// Fügt eine transparente Form über der festen Form hinzu
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(128, 204, 102, 0));
   
// Schreibt die PPTX-Datei auf die Festplatte
pres->Save(u"ShapeTransparentOverSolid_out.pptx", Export::SaveFormat::Pptx);
```

## **Formen drehen**
Aspose.Slides ermöglicht es dir, eine auf einer Folie hinzugefügte Form folgendermaßen zu drehen:

1. Erstelle eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
2. Hole einen Verweis auf eine Folie über ihren Index.
3. Füge der Folie eine [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) hinzu.
4. Drehe die Form um die benötigte Gradzahl.
5. Schreibe die modifizierte Präsentation als PPTX-Datei.

Dieser C++-Code zeigt dir, wie du eine Form um 90 Grad drehst:

```cpp
// Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt
auto pres = MakeObject<Presentation>();

// Holt die erste Folie
auto slide = pres->get_Slides()->idx_get(0);

// Fügt eine rechteckige Autoform hinzu
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);

// Dreht die Form um 90 Grad
autoShape->set_Rotation(90.f);

// Schreibt die PPTX-Datei auf die Festplatte
pres->Save(u"RectShpRot_out.pptx", Export::SaveFormat::Pptx);
```

## **3D-Facetteneffekte hinzufügen**
Aspose.Slides ermöglicht es dir, 3D-Facetteneffekte zu einer Form hinzuzufügen, indem du ihre [ThreeDFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.three_d_format) Eigenschaften folgendermaßen modifizierst:

1. Erstelle eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
2. Hole einen Verweis auf eine Folie über ihren Index.
3. Füge der Folie eine [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) hinzu.
3. Setze deine bevorzugten Parameter für die Eigenschaften des [ThreeDFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.three_d_format) der Form.
4. Schreibe die Präsentation auf die Festplatte.

Dieser C++-Code zeigt dir, wie du 3D-Facetteneffekte zu einer Form hinzufügst:

```cpp
// Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt
auto pres = MakeObject<Presentation>();

// Holt die erste Folie
auto slide = pres->get_Slides()->idx_get(0);

// Fügt eine Form zur Folie hinzu
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30, 30, 200, 200);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Green());
auto format = shape->get_LineFormat()->get_FillFormat();
format->set_FillType(FillType::Solid);
format->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->set_Width(2.0);

// Setzt die ThreeDFormat Eigenschaften der Form
shape->get_ThreeDFormat()->set_Depth(4.0);
shape->get_ThreeDFormat()->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
shape->get_ThreeDFormat()->get_BevelTop()->set_Height(6);
shape->get_ThreeDFormat()->get_BevelTop()->set_Width(6);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);

// Schreibt die Präsentation als PPTX-Datei
pres->Save(u"Bavel_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **3D-Drehungseffekt hinzufügen**
Aspose.Slides ermöglicht es dir, 3D-Drehungseffekte auf eine Form anzuwenden, indem du ihre [ThreeDFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.three_d_format) Eigenschaften folgendermaßen modifizierst:

1. Erstelle eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
2. Hole einen Verweis auf eine Folie über ihren Index.
3. Füge der Folie eine [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) hinzu.
3. Gib deine bevorzugten Figuren für [CameraType](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_camera#aea0717e8ef5f3199df99ed2cb2ea2dcb) und [LightType](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_light_rig#a2cd12029664967d0e2f93eee25a4963f) an.
4. Schreibe die Präsentation auf die Festplatte.

Dieser C++-Code zeigt dir, wie du 3D-Drehungseffekte auf eine Form anwendest:

```cpp
// Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt
auto pres = MakeObject<Presentation>();

// Holt die erste Folie
auto slide = pres->get_Slides()->idx_get(0);
    
// Fügt eine Form zur Folie hinzu
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30, 30, 200, 200);

// Setzt die ThreeDFormat Eigenschaften der Form
shape->get_ThreeDFormat()->set_Depth(6);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(40, 35, 20);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

// Fügt eine Form zur Folie hinzu
shape = slide->get_Shapes()->AddAutoShape(ShapeType::Line, 30, 300, 200, 200);

// Setzt die ThreeDFormat Eigenschaften der Form
shape->get_ThreeDFormat()->set_Depth(6);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(0, 35, 20);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

// Schreibt die Präsentation als PPTX-Datei
pres->Save(u"Rotation_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Formatierung zurücksetzen**

Dieser C++-Code zeigt dir, wie du die Formatierung auf einer Folie zurücksetzt und die Position, Größe und Formatierung jeder Form mit einem Platzhalter auf der [LayoutSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.layout_slide) auf ihre Standardwerte zurücksetzt:

```c++
auto pres = System::MakeObject<Presentation>();

for (auto slide : pres->get_Slides())
{
    // Jede Form auf der Folie, die einen Platzhalter im Layout hat, wird zurückgesetzt
    slide->Reset();
}
```