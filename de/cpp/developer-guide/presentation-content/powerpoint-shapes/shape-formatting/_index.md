---
title: PowerPoint-Formate in C++ formatieren
linktitle: Formformatierung
type: docs
weight: 20
url: /de/cpp/shape-formatting/
keywords:
- Form formatieren
- Linie formatieren
- Skizzen‑effekt
- Skizzierte Formlinie
- Verbindungsstil formatieren
- Verlauffüllung
- Musterfüllung
- Bildfüllung
- Texturfüllung
- Einfarbige Füllung
- Formtransparenz
- Schwarz‑weiß‑Darstellung von Formen
- Graustufen‑Darstellung von Formen
- Form drehen
- 3D‑Keil‑Effekt
- 3D‑Rotations‑Effekt
- Formatierung zurücksetzen
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint-Formen in C++ mit Aspose.Slides formatieren – füllen, Linien- und Effekt‑Stile für PPT-, PPTX- und ODP‑Dateien präzise und vollumfänglich einstellen."
---
## **Einführung**

In PowerPoint können Sie Formen zu Folien hinzufügen. Da Formen aus Linien bestehen, können Sie sie formatieren, indem Sie deren Konturen ändern oder Effekte darauf anwenden. Zusätzlich können Sie Formen formatieren, indem Sie Einstellungen festlegen, die steuern, wie deren Innenflächen gefüllt werden.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides für C++ stellt Schnittstellen und Methoden bereit, mit denen Sie Formen mithilfe derselben Optionen formatieren können, die in PowerPoint verfügbar sind.

## **Linien formatieren**

Mit Aspose.Slides können Sie einen benutzerdefinierten Linienstil für eine Form festlegen. Die folgenden Schritte beschreiben das Vorgehen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)-Klasse.
1. Holen Sie eine Referenz auf eine Folie über ihren Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)-Element hinzu.
1. Legen Sie den [Linienstil](https://reference.aspose.com/slides/cpp/aspose.slides/linestyle/) der Form fest.
1. Legen Sie die Linienbreite fest.
1. Legen Sie den [Strichstil](https://reference.aspose.com/slides/cpp/aspose.slides/linedashstyle/) der Linie fest.
1. Legen Sie die Linienfarbe für die Form fest.
1. Speichern Sie die geänderte Präsentation als PPTX-Datei.

Der folgende Code zeigt, wie man ein Rechteck‑`AutoShape` formatiert:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/LineDashStyle.h>
#include <DOM/LineStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei darstellt.
auto presentation = MakeObject<Presentation>();

// Holen Sie die erste Folie.
auto slide = presentation->get_Slide(0);

// Fügen Sie eine AutoShape vom Typ Rechteck hinzu.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// Setzen Sie die Füllfarbe für die Rechteckform.
shape->get_FillFormat()->set_FillType(FillType::NoFill);

// Formatieren Sie die Linien des Rechtecks.
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);

// Setzen Sie die Farbe für die Linie des Rechtecks.
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Speichern Sie die PPTX‑Datei auf dem Datenträger.
presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Das Ergebnis:

![Die formatierten Linien in der Präsentation](formatted-lines.png)

## **Skizzen‑Effekte auf Formlinien anwenden**

Ein Skizzen‑Effekt lässt eine Formlinie handgezeichnet aussehen. Verwenden Sie [IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/), um auf die Linieneinstellungen zuzugreifen, [ILineFormat::get_SketchFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/get_sketchformat/), um auf die Skizzeneinstellungen zuzugreifen, und [ISketchFormat::set_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformat/set_sketchtype/), um einen Wert aus der [LineSketchType](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/)-Aufzählung auszuwählen.

Der folgende C++‑Code zeigt, wie man einen [LineSketchType::Curved](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/)-Effekt anwendet, den explizit zugewiesenen Wert liest und den Effekt mit [LineSketchType::None](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/) entfernt:

```cpp
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

// Zugriff auf das Linienformat der Form und deren Skizzenformat.
auto sketchFormat = shape->get_LineFormat()->get_SketchFormat();

// Skizzen-Effekt anwenden.
sketchFormat->set_SketchType(LineSketchType::Curved);

// Den direkt der Form zugewiesenen Skizzen-Effekt auslesen.
auto explicitSketchType = sketchFormat->get_SketchType();
Console::WriteLine(u"Explicit sketch type: {0}", explicitSketchType);

// Den Skizzen-Effekt entfernen.
sketchFormat->set_SketchType(LineSketchType::None);

presentation->Dispose();
```

Der von [ISketchFormat::get_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformat/get_sketchtype/) zurückgegebene Wert stellt die direkt der Form zugewiesene Einstellung dar. Wenn die Linienformatierung von einem Design, einer Master‑Folie oder einer Layout‑Folie geerbt werden kann, verwenden Sie [ILineFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/geteffective/), greifen Sie auf [ILineFormatEffectiveData::get_SketchFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformateffectivedata/get_sketchformat/) zu und lesen Sie [ISketchFormatEffectiveData::get_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformateffectivedata/get_sketchtype/). Der effektive Wert spiegelt die Formatierung wider, die tatsächlich angewendet wird, nachdem die Vererbung aufgelöst wurde:

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

## **Verbindungsstile formatieren**

Hier sind die drei Optionen für den Verbindungs­typ:

* Rund
* Gehrung
* Fase

Standardmäßig verwendet PowerPoint beim Verbinden zweier Linien unter einem Winkel (wie an einer Formkante) die Einstellung **Rund**. Wenn Sie jedoch eine Form mit scharfen Winkeln zeichnen, bevorzugen Sie möglicherweise die **Gehrung**‑Option.

![Der Verbindungsstil in der Präsentation](join-style-powerpoint.png)

Der folgende C++‑Code demonstriert, wie drei Rechtecke (wie im obigen Bild) mit den Verbindungs­typ‑Einstellungen Gehrung, Fase und Rund erstellt wurden:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LineJoinStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei darstellt.
auto presentation = MakeObject<Presentation>();

// Holen Sie die erste Folie.
auto slide = presentation->get_Slide(0);

// Fügen Sie drei AutoShapes vom Typ Rechteck hinzu.
auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

// Setzen Sie die Füllfarbe für jede Rechteckform.
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

// Speichern Sie die PPTX‑Datei auf dem Datenträger.
presentation->Save(u"join_styles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Verlauffüllung**

In PowerPoint ist die Verlauffüllung eine Formatierungsoption, mit der Sie einer Form einen kontinuierlichen Farbübergang zuweisen können. Beispielsweise können Sie zwei oder mehr Farben so anwenden, dass die eine allmählich in die andere übergeht.

So wenden Sie eine Verlauffüllung auf eine Form mit Aspose.Slides an:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)-Klasse.
1. Holen Sie eine Referenz auf eine Folie über ihren Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)-Element hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/)-Wert der Form auf `Gradient`.
1. Fügen Sie Ihre beiden bevorzugten Farben mit definierten Positionen über die `Add`‑Methoden der Farbverlauf‑Stopp‑Sammlung hinzu, die von der [IGradientFormat](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/)-Schnittstelle bereitgestellt wird.
1. Speichern Sie die geänderte Präsentation als PPTX-Datei.

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientDirection.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/PresetColor.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei darstellt.
auto presentation = MakeObject<Presentation>();

// Holen Sie die erste Folie.
auto slide = presentation->get_Slide(0);

// Fügen Sie eine AutoShape vom Typ Ellipse hinzu.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

// Wenden Sie eine Verlaufformattierung auf die Ellipse an.
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);

// Setzen Sie die Richtung des Verlaufs.
shape->get_FillFormat()->get_GradientFormat()->set_GradientDirection(GradientDirection::FromCorner2);

// Fügen Sie zwei Farbverlaufs‑Stopps hinzu.
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

// Speichern Sie die PPTX‑Datei auf dem Datenträger.
presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Die Ellipse mit Verlauffüllung](gradient-fill.png)

Falls ein Verlauf in einem exportierten Bild anders aussieht als in PowerPoint, siehe [Wählen Sie einen Verlauf‑Renderstil](/slides/de/cpp/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Sie können einen Renderstil auswählen, ohne die im Dokument gespeicherte Verlauffüllung zu ändern.

## **Musterfüllung**

In PowerPoint ist die Musterfüllung eine Formatierungsoption, mit der Sie einer Form ein zweifarbiges Design – wie Punkte, Streifen, Schraffuren oder Karos – zuweisen können. Sie können individuelle Farben für den Vorder‑ und Hintergrund des Musters wählen.

Aspose.Slides stellt über 45 vordefinierte Musterstile bereit, die Sie auf Formen anwenden können, um die visuelle Attraktivität Ihrer Präsentationen zu erhöhen. Auch nach der Auswahl eines vordefinierten Musters können Sie die genauen zu verwendenden Farben festlegen.

So wenden Sie eine Musterfüllung auf eine Form mit Aspose.Slides an:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)-Klasse.
1. Holen Sie eine Referenz auf eine Folie über ihren Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)-Element hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/)-Wert der Form auf `Pattern`.
1. Wählen Sie einen Musterstil aus den vordefinierten Optionen.
1. Setzen Sie die [Hintergrundfarbe](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_backcolor/) des Musters.
1. Setzen Sie die [Vordergrundfarbe](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_forecolor/) des Musters.
1. Speichern Sie die geänderte Präsentation als PPTX-Datei.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IPatternFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PatternStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
auto presentation = MakeObject<Presentation>();

// Holen Sie die erste Folie.
auto slide = presentation->get_Slide(0);

// Fügen Sie eine AutoShape vom Typ Rectangle hinzu.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Setzen Sie den FillType auf Pattern.
shape->get_FillFormat()->set_FillType(FillType::Pattern);

// Setzen Sie den PatternStyle.
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// Setzen Sie die Hintergrund- und Vordergrundfarben des Musters.
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// Speichern Sie die PPTX-Datei auf dem Datenträger.
presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Das Rechteck mit Musterfüllung](pattern-fill.png)

## **Bildfüllung**

In PowerPoint ist die Bildfüllung eine Formatierungsoption, mit der Sie ein Bild in eine Form einfügen können – das Bild wird dabei effektiv als Hintergrund der Form verwendet.

So verwenden Sie Aspose.Slides, um eine Bildfüllung auf eine Form anzuwenden:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)-Klasse.
1. Holen Sie eine Referenz auf eine Folie über ihren Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)-Element hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/)-Wert der Form auf `Picture`.
1. Setzen Sie den Bildfüllungsmodus auf `Tile` (oder einen anderen bevorzugten Modus).
1. Erzeugen Sie ein [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/)-Objekt aus dem Bild, das Sie verwenden möchten.
1. Übergeben Sie das Bild an die Methode `ISlidesPicture.set_Image`.
1. Speichern Sie die geänderte Präsentation als PPTX-Datei.

Angenommen, wir haben eine Datei "lotus.png" mit folgendem Bild:

![Das Lotus‑Bild](lotus.png)

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei darstellt.
auto presentation = MakeObject<Presentation>();

// Holen Sie die erste Folie.
auto slide = presentation->get_Slide(0);

// Fügen Sie eine AutoShape vom Typ Rectangle hinzu.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

// Setzen Sie den FillType auf Picture.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Setzen Sie den PictureFillMode.
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

// Laden Sie ein Bild und fügen Sie es zu den Präsentationsressourcen hinzu.
auto image = Images::FromFile(u"lotus.png");
auto picture = presentation->get_Images()->AddImage(image);
image->Dispose();

// Setzen Sie das Bild.
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(picture);

// Speichern Sie die PPTX‑Datei auf dem Datenträger.
presentation->Save(u"picture_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Die Form mit Bildfüllung](picture-fill.png)

### **Bild kacheln als Textur**

Wenn Sie ein gekacheltes Bild als Textur festlegen und das Kachelattribut anpassen möchten, können Sie die folgenden Methoden des [IPictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/)-Interface und der [PictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/)-Klasse verwenden:

- [set_PictureFillMode](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): Setzt den Bildfüllungsmodus – entweder `Tile` oder `Stretch`.
- [set_TileAlignment](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): Gibt die Ausrichtung der Kacheln innerhalb der Form an.
- [set_TileFlip](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileflip/): Steuert, ob die Kachel horizontal, vertikal oder beides gespiegelt wird.
- [set_TileOffsetX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): Setzt den horizontalen Versatz der Kachel (in Punkten) vom Ursprung der Form.
- [set_TileOffsetY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): Setzt den vertikalen Versatz der Kachel (in Punkten) vom Ursprung der Form.
- [set_TileScaleX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): Definiert die horizontale Skalierung der Kachel als Prozentsatz.
- [set_TileScaleY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): Definiert die vertikale Skalierung der Kachel als Prozentsatz.

Der folgende Code‑Auszug zeigt, wie man einer Rechteckform eine gekachelte Bildfüllung hinzufügt und die Kacheloptionen konfiguriert:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/ShapeType.h>
#include <DOM/TileFlip.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei darstellt.
auto presentation = MakeObject<Presentation>();

// Holen Sie die erste Folie.
auto firstSlide = presentation->get_Slide(0);

// Fügen Sie eine Rechteck‑AutoShape hinzu.
auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

// Setzen Sie den FillType der Form auf Picture.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Laden Sie das Bild und fügen Sie es zu den Präsentationsressourcen hinzu.
auto sourceImage = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

// Weisen Sie das Bild der Form zu.
auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);

// Konfigurieren Sie den PictureFillMode und die Kachel‑Eigenschaften.
pictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
pictureFillFormat->set_TileOffsetX(-32);
pictureFillFormat->set_TileOffsetY(-32);
pictureFillFormat->set_TileScaleX(50);
pictureFillFormat->set_TileScaleY(50);
pictureFillFormat->set_TileAlignment(RectangleAlignment::BottomRight);
pictureFillFormat->set_TileFlip(TileFlip::FlipBoth);

// Speichern Sie die PPTX‑Datei auf dem Datenträger.
presentation->Save(u"tile.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Die Kacheloptionen](tile-options.png)

## **Einfarbige Füllung**

In PowerPoint ist die einfarbige Füllung eine Formatierungsoption, die eine Form mit einer einzigen, einheitlichen Farbe füllt. Diese schlichte Hintergrundfarbe wird ohne Verläufe, Texturen oder Muster angewendet.

Um eine einfarbige Füllung auf eine Form mit Aspose.Slides anzuwenden, führen Sie folgende Schritte aus:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)-Klasse.
1. Holen Sie eine Referenz auf eine Folie über ihren Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)-Element hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/)-Wert der Form auf `Solid`.
1. Weisen Sie der Form Ihre bevorzugte Füllfarbe zu.
1. Speichern Sie die geänderte Präsentation als PPTX-Datei.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
auto presentation = MakeObject<Presentation>();

// Holen Sie die erste Folie.
auto slide = presentation->get_Slide(0);

// Fügen Sie eine AutoShape vom Typ Rectangle hinzu.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Setzen Sie den FillType auf Solid.
shape->get_FillFormat()->set_FillType(FillType::Solid);

// Setzen Sie die Füllfarbe.
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// Speichern Sie die PPTX-Datei auf dem Datenträger.
presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Die Form mit einfarbiger Füllung](solid-color-fill.png)

## **Transparenz festlegen**

In PowerPoint können Sie, wenn Sie einer Form eine einfarbige, Verlauf-, Bild‑ oder Textur‑Füllung zuweisen, ebenfalls einen Transparenzwert festlegen, um die Deckkraft der Füllung zu steuern. Ein höherer Transparenzwert macht die Form durchsichtiger, sodass der Hintergrund oder darunterliegende Objekte teilweise sichtbar werden.

Aspose.Slides ermöglicht es Ihnen, den Transparenzwert festzulegen, indem Sie den Alpha‑Wert der für die Füllung verwendeten Farbe anpassen. So geht’s:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)-Klasse.
1. Holen Sie eine Referenz auf eine Folie über ihren Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)-Element hinzu.
1. Setzen Sie den [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/)-Wert der Form auf `Solid`.
1. Verwenden Sie `Color`, um eine Farbe mit Transparenz zu definieren (die `alpha`‑Komponente steuert die Transparenz).
1. Speichern Sie die Präsentation.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei darstellt.
auto presentation = MakeObject<Presentation>();

// Holen Sie die erste Folie.
auto slide = presentation->get_Slide(0);

// Fügen Sie eine einfarbige Rechteck‑AutoShape hinzu.
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Fügen Sie eine transparente Rechteck‑AutoShape über der einfarbigen Form hinzu.
auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(204, 255, 255, 0));

// Speichern Sie die PPTX‑Datei auf dem Datenträger.
presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Die transparente Form](shape-transparency.png)

## **Formen drehen**

Aspose.Slides ermöglicht das Drehen von Formen in PowerPoint‑Präsentationen. Dies kann nützlich sein, wenn visuelle Elemente mit bestimmten Ausrichtungen oder Design‑Anforderungen positioniert werden sollen.

So drehen Sie eine Form auf einer Folie:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)-Klasse.
1. Holen Sie eine Referenz auf eine Folie über ihren Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)-Element hinzu.
1. Setzen Sie die Rotations‑Eigenschaft der Form auf den gewünschten Winkel.
1. Speichern Sie die Präsentation.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei darstellt.
auto presentation = MakeObject<Presentation>();

// Holen Sie die erste Folie.
auto slide = presentation->get_Slide(0);

// Fügen Sie eine AutoShape vom Typ Rectangle hinzu.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Drehen Sie die Form um 5 Grad.
shape->set_Rotation(5);

// Speichern Sie die PPTX‑Datei auf dem Datenträger.
presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Die Formdrehung](shape-rotation.png)

## **3D‑Keil‑Effekte hinzufügen**

Aspose.Slides ermöglicht das Anwenden von 3D‑Keil‑Effekten auf Formen, indem deren [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/)-Eigenschaften konfiguriert werden.

So fügen Sie einer Form 3D‑Keil‑Effekte hinzu:

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)-Klasse.
1. Holen Sie eine Referenz auf eine Folie über ihren Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)-Element hinzu.
1. Konfigurieren Sie das [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/) der Form, um Keil‑Einstellungen festzulegen.
1. Speichern Sie die Präsentation.

```cpp
#include <DOM/BevelPresetType.h>
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeBevel.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Erzeugen Sie eine Instanz der Presentation‑Klasse.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Fügen Sie der Folie eine Form hinzu.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Green());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->set_Width(2.0);

// Setzen Sie die ThreeDFormat‑Eigenschaften der Form.
shape->get_ThreeDFormat()->set_Depth(4.0);
shape->get_ThreeDFormat()->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
shape->get_ThreeDFormat()->get_BevelTop()->set_Height(6);
shape->get_ThreeDFormat()->get_BevelTop()->set_Width(6);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);

// Speichern Sie die Präsentation als PPTX‑Datei.
presentation->Save(u"3D_bevel_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Der 3D‑Keil‑Effekt](3D-bevel-effect.png)

## **3D‑Rotation‑Effekte hinzufügen**

Aspose.Slides ermöglicht das Anwenden von 3D‑Rotation‑Effekten auf Formen, indem deren [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/)-Eigenschaften konfiguriert werden.

So wenden Sie eine 3D‑Rotation auf eine Form an:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)-Klasse.
1. Holen Sie eine Referenz auf eine Folie über ihren Index.
1. Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)-Element hinzu.
1. Verwenden Sie [set_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/set_cameratype/) und [set_LightType](https://reference.aspose.com/slides/cpp/aspose.slides/ilightrig/set_lighttype/), um die 3D‑Rotation festzulegen.
1. Speichern Sie die Präsentation.

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/ILightRig.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Erzeugen Sie eine Instanz der Presentation‑Klasse.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_TextFrame()->set_Text(u"Hello, Aspose!");

shape->get_ThreeDFormat()->set_Depth(6);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(40, 35, 20);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

// Speichern Sie die Präsentation als PPTX‑Datei.
presentation->Save(u"3D_rotation_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Der 3D‑Rotation‑Effekt](3D-rotation-effect.png)

## **Schwarz‑weiß‑Rendering für Formen steuern**

Die Methode [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_blackwhitemode/) legt fest, wie eine einzelne Form gerendert wird, wenn eine Präsentation im Schwarz‑weiß‑Modus angezeigt oder verarbeitet wird. Sie aktiviert die Schwarz‑weiß‑Anzeige nicht selbst und ändert die Füllung, Linie oder andere Formatierungen der Form nicht im normalen Farbmodus.

Verwenden Sie einen Wert aus der [BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/blackwhitemode/)-Aufzählung, um das gewünschte Verhalten auszuwählen. Beispielsweise lässt `Automatic` die Rendering‑Anwendung die Konvertierung wählen, `Gray` und `LightGray` verwenden graue Färbung, `BlackWhite` nutzt ausschließlich Schwarz und Weiß, `Black` und `White` erzwingen eine einfarbige Darstellung, `Color` bewahrt die normale Farbgebung, und `Hidden` blendet die Form im Schwarz‑weiß‑Modus aus. `NotDefined` bedeutet, dass kein Form‑Level‑Modus zugewiesen ist.

Der folgende C++‑Code erstellt eine farbige Form und lässt sie im Schwarz‑weiß‑Anzeigemodus grau erscheinen:

```cpp
#include <DOM/BlackWhiteMode.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());

// Behalten Sie die orange Füllung im Farbmodus bei, aber rendern Sie die Form mit grauer Färbung im Schwarz‑weiß‑Modus.
shape->set_BlackWhiteMode(BlackWhiteMode::Gray);

presentation->Save(u"shape_black_white_mode.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Im normalen Farbmodus behält das Rechteck seine orange Füllung bei. In einem Schwarz‑weiß‑Anzeige‑Workflow wird es grau gefärbt, weil sein Modus auf `Gray` gesetzt ist. So können Sie eine Vollfarb‑Folien beibehalten und gleichzeitig ein separates Erscheinungsbild für den Druck, die Vorschau oder andere Workflows definieren, die die Schwarz‑weiß‑Anzeigeeinstellungen der Präsentation berücksichtigen.

## **Formatierung zurücksetzen**

Der folgende C++‑Code zeigt, wie die Formatierung einer Folie zurückgesetzt wird und die Position, Größe und Formatierung aller Formen mit Platzhaltern auf dem [LayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/layoutslide/) auf ihre Standardwerte zurückgesetzt werden:

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

for (auto&& slide : System::IterateOver(presentation->get_Slides()))
{
    // Setze jede Form auf der Folie zurück, die einen Platzhalter im Layout hat.
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Beeinflusst die Formformatierung die endgültige Dateigröße der Präsentation?**

Nur minimal. Eingebettete Bilder und Medien beanspruchen den größten Teil des Dateiraums, während Formparameter wie Farben, Effekte und Verläufe als Metadaten gespeichert werden und praktisch keinen zusätzlichen Platz benötigen.

**Wie kann ich Formen auf einer Folie erkennen, die identische Formatierungen aufweisen, um sie zu gruppieren?**

Vergleichen Sie die wichtigsten Formatierungseigenschaften jeder Form – Füllung, Linie und Effekt‑Einstellungen. Stimmen alle entsprechenden Werte überein, behandeln Sie deren Stile als identisch und gruppieren die Formen logisch, was die spätere Stilverwaltung vereinfacht.

**Kann ich ein Set benutzerdefinierter Formstile in einer separaten Datei speichern, um sie in anderen Präsentationen wiederzuverwenden?**

Ja. Speichern Sie Beispielsformen mit den gewünschten Stilen in einem Vorlagen‑Slide‑Deck oder einer .POTX‑Vorlagendatei. Beim Erstellen einer neuen Präsentation öffnen Sie die Vorlage, klonen die benötigten gestylten Formen und wenden deren Formatierung an den gewünschten Stellen erneut an.