---
title: PowerPoint-Formen in C++ formatieren
linktitle: Formformatierung
type: docs
weight: 20
url: /de/cpp/shape-formatting/
keywords:
- Form formatieren
- Linie formatieren
- Skizzeffekt
- Skizzierte Formlinie
- Verbindungsstil formatieren
- Verlaufsfüllung
- Musterfüllung
- Bildfüllung
- Texturfüllung
- Einfarbige Füllung
- Formtransparenz
- Schwarz‑weiß‑Darstellung von Formen
- Graustufen‑Darstellung von Formen
- Form drehen
- 3D‑Kanten‑Effekt
- 3D‑Dreh‑Effekt
- Formatierung zurücksetzen
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint-Formen in C++ mit Aspose.Slides formatieren – Füllungen, Linien- und Effektstile für PPT- und PPTX-Dateien präzise und mit voller Kontrolle festlegen."
---
## **Einführung**

Formatiere Formen in PowerPoint, indem du ihre Konturen, Füllungen und Effekte anpasst. Aspose.Slides für C++ ermöglicht es, diese Einstellungen programmgesteuert zu steuern, einschließlich Transparenz, Drehung und 3D‑Formatierung.

![Optionen zur Formformatierung in PowerPoint](format-shape-powerpoint.png)

Aspose.Slides für C++ stellt Schnittstellen und Methoden bereit, mit denen du Formen unter Verwendung derselben Optionen wie in PowerPoint formatieren kannst.

## **Linien formatieren**

Verwende [IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/), um die Kontur einer Form zu steuern. Dieses Beispiel erstellt ein nicht gefülltes Rechteck mit einer blauen, gestrichelten Kontur. [ILineFormat::set_Style](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_style/) wählt eine dick‑dünn‑Kombinationslinie, während [ILineFormat::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_width/) die Breite auf 7 Punkte und [ILineFormat::set_DashStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_dashstyle/) das Strichmuster festlegt.

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
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Das Ergebnis:

![Die formatierten Linien in der Präsentation](formatted-lines.png)

### **Benutzerdefinierte Strichmuster festlegen**

Verwende [ILineFormat::set_CustomDashPattern](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_customdashpattern/), wenn vordefinierte Linienstile die benötigten Strich‑ und Lückenlängen nicht bieten, zum Beispiel für markenbezogene Konturen oder technische Diagramme. Das Zuweisen eines Musters ändert automatisch den Strichstil zu [LineDashStyle::Custom](https://reference.aspose.com/slides/cpp/aspose.slides/linedashstyle/).

Array‑Einträge wechseln zwischen Strich‑ und Lückenlängen, beginnend mit einem Strich. Jeder Wert ist ein Vielfaches der Linienbreite: `{ 4, 2 }` bei einer Breite von 3 Punkten erzeugt einen 12‑Punkt‑Strich gefolgt von einer 6‑Punkt‑Lücke. Verwende Paare aus endlichen, nichtnegativen Werten, um komplette Strich‑und‑Lücken‑Segmente zu definieren. Das Beispiel verwendet positive Werte, damit jeder Strich und jede Lücke sichtbar bleibt.

Dieses Beispiel erstellt fünf blaue Linien mit gleicher Länge und flachen Enden. Die ersten drei vergleichen Muster bei einer Breite von 3 Punkten. Die vierte wiederholt das erste Muster bei doppelter Breite und verdoppelt damit Strich‑ und Lückenlängen. Die fünfte wechselt von einem benutzerdefinierten Muster zu einer durchgezogenen Linie.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/LineArrowheadStyle.h>
#include <DOM/LineCapStyle.h>
#include <DOM/LineDashStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <system/array.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(600, 300, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

const auto patterns = std::array<ArrayPtr<float>, 5>{
    MakeArray<float>({ 4, 2 }),
    MakeArray<float>({ 1, 2 }),
    MakeArray<float>({ 6, 2, 1, 2 }),
    MakeArray<float>({ 4, 2 }),
    MakeArray<float>({ 4, 2 })
};

for (auto i = 0; i < patterns.size(); i++)
{
    auto line = slide->get_Shapes()->AddAutoShape(ShapeType::Line, 50, 50 + i * 50, 500, 0);
    line->get_LineFormat()->set_Width(i == 3 ? 6 : 3);
    line->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
    line->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
    line->get_LineFormat()->set_CapStyle(LineCapStyle::Flat);
    line->get_LineFormat()->set_BeginArrowheadStyle(LineArrowheadStyle::None);
    line->get_LineFormat()->set_EndArrowheadStyle(LineArrowheadStyle::None);
    line->get_LineFormat()->set_CustomDashPattern(patterns[i]);
}

// Return the last line to a solid style.
slide->get_Shape(4)->get_LineFormat()->set_DashStyle(LineDashStyle::Solid);

presentation->Save(u"custom_dash_patterns.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Um stattdessen zu einem vordefinierten gestrichelten Stil zurückzukehren, übergebe [LineDashStyle::Dash](https://reference.aspose.com/slides/cpp/aspose.slides/linedashstyle/) an [ILineFormat::set_DashStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_dashstyle/). Der ausgewählte Stil steuert das Aussehen der Linie.

Das Ergebnis in PowerPoint von oben nach unten: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; und **Solid, 3 pt**.

![Drei benutzerdefinierte Strichmuster, eine breitere Linie mit dem ersten Muster und eine durchgezogene Linie in PowerPoint](custom-dash-patterns.png)


### **Linienenden festlegen**

Verwende [ILineFormat::set_CapStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_capstyle/), um die Enden einer offenen Linie zu setzen. Die Aufzählung [LineCapStyle](https://reference.aspose.com/slides/cpp/aspose.slides/linecapstyle/) bietet drei explizite Endstile:

- `Flat`: Der Strich endet am Endpunkt.
- `Round`: Eine halbkreisförmige Kappe erstreckt sich über den Endpunkt hinaus um die halbe Linienbreite.
- `Square`: Eine quadratische Kappe erstreckt sich über den Endpunkt hinaus um die halbe Linienbreite.

Die Aufzählung enthält außerdem `NotDefined`, was bedeutet, dass kein Endstil explizit zugewiesen ist.

Enden unterscheiden sich von Pfeilspitzen, die Symbole an Linienenden hinzufügen, und von Verbindungen, die Ecken zwischen Linienabschnitten steuern. Dieses Beispiel deaktiviert Pfeilspitzen über [ILineFormat::set_BeginArrowheadStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_beginarrowheadstyle/) und [ILineFormat::set_EndArrowheadStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_endarrowheadstyle/), sodass nur die Endformen verglichen werden.

Das folgende Beispiel erstellt drei ansonsten identische horizontale Linien, 20 Punkte breit. Von oben nach unten verwenden sie flache, runde bzw. quadratische Enden. Ihre Endpunkte besitzen dieselben horizontalen Koordinaten; die runden und quadratischen Enden erstrecken sich 10 Punkte über jeden Endpunkt hinaus.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/LineArrowheadStyle.h>
#include <DOM/LineCapStyle.h>
#include <DOM/LineDashStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(500, 240, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

const auto capStyles = std::array<LineCapStyle, 3>{ LineCapStyle::Flat, LineCapStyle::Round, LineCapStyle::Square };

for (auto i = 0; i < capStyles.size(); i++)
{
    auto line = slide->get_Shapes()->AddAutoShape(ShapeType::Line, 100, 50 + i * 70, 300, 0);
    line->get_LineFormat()->set_Width(20);
    line->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
    line->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
    line->get_LineFormat()->set_DashStyle(LineDashStyle::Solid);
    line->get_LineFormat()->set_CapStyle(capStyles[i]);
    line->get_LineFormat()->set_BeginArrowheadStyle(LineArrowheadStyle::None);
    line->get_LineFormat()->set_EndArrowheadStyle(LineArrowheadStyle::None);
}

presentation->Save(u"line_caps.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Das Ergebnis in PowerPoint von oben nach unten: **Flat**, **Round** und **Square**.

![Flache, runde und quadratische Enden an identischen dicken Linien in PowerPoint](line-caps.png)

## **Skizzeneffekte auf Formlinien anwenden**

Ein Skizzeneffekt lässt eine Formlinie handgezeichnet wirken. Verwende [IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/), um die Linieneinstellungen zu erhalten, [ILineFormat::get_SketchFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/get_sketchformat/), um die Skizzen‑Einstellungen zu erhalten, und [ISketchFormat::set_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformat/set_sketchtype/), um einen Wert aus der Aufzählung [LineSketchType](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/) auszuwählen.

Der folgende C++‑Code zeigt, wie man den Effekt [LineSketchType::Curved](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/) anwendet, den explizit zugewiesenen Wert ausliest und den Effekt mit [LineSketchType::None](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/) entfernt:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISketchFormat.h>
#include <DOM/ISlide.h>
#include <DOM/LineSketchType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

auto sketchFormat = shape->get_LineFormat()->get_SketchFormat();
sketchFormat->set_SketchType(LineSketchType::Curved);
auto explicitSketchType = sketchFormat->get_SketchType();
Console::WriteLine(u"Explicit sketch type: {0}", explicitSketchType);
sketchFormat->set_SketchType(LineSketchType::None);

presentation->Dispose();
```

Der von [ISketchFormat::get_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformat/get_sketchtype/) zurückgegebene Wert repräsentiert die Einstellung, die direkt der Form zugewiesen wurde. Wenn die Linienformatierung von einem Design, einer Master‑Folie oder einer Layout‑Folie geerbt werden kann, verwende [ILineFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/geteffective/), greife auf [ILineFormatEffectiveData::get_SketchFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformateffectivedata/get_sketchformat/) zu und lese [ISketchFormatEffectiveData::get_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformateffectivedata/get_sketchtype/) aus. Der effektive Wert spiegelt die Formatierung wider, die tatsächlich nach Auflösung der Vererbung angewendet wird. Dieses Beispiel setzt eine vorhandene Präsentation mit mindestens einer Form auf der ersten Folie voraus und gibt beide Werte aus:

```cpp
#include <DOM/ILineFormat.h>
#include <DOM/ILineFormatEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/ISketchFormat.h>
#include <DOM/ISketchFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/LineSketchType.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

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

Hier sind die drei Optionen für Verbindungsarten:

* Round
* Miter
* Bevel

Der Verbindungsstil bestimmt, wie zwei Kontursegmente an einer Ecke zusammentreffen. Verwende **Round** für abgerundete Ecken, **Miter** für spitze Ecken oder **Bevel** für abgeflachte Ecken.

![Der Verbindungsstil in der Präsentation](join-style-powerpoint.png)

Dieses Beispiel erstellt drei schwarze Rechtecke mit blauen Konturen, 15 Punkte breit. Es setzt [ILineFormat::set_JoinStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_joinstyle/) auf die Miter‑, Bevel‑ und Round‑Werte der Aufzählung [LineJoinStyle](https://reference.aspose.com/slides/cpp/aspose.slides/linejoinstyle/), um zu vergleichen, wie die Ecken gezeichnet werden.

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
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto miterShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
auto bevelShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
auto roundShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

miterShape->get_FillFormat()->set_FillType(FillType::Solid);
miterShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
bevelShape->get_FillFormat()->set_FillType(FillType::Solid);
bevelShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
roundShape->get_FillFormat()->set_FillType(FillType::Solid);
roundShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

miterShape->get_LineFormat()->set_Width(15);
bevelShape->get_LineFormat()->set_Width(15);
roundShape->get_LineFormat()->set_Width(15);

miterShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
miterShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
bevelShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
bevelShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
roundShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
roundShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

miterShape->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
bevelShape->get_LineFormat()->set_JoinStyle(LineJoinStyle::Bevel);
roundShape->get_LineFormat()->set_JoinStyle(LineJoinStyle::Round);

miterShape->get_TextFrame()->set_Text(u"Miter Join Style");
bevelShape->get_TextFrame()->set_Text(u"Bevel Join Style");
roundShape->get_TextFrame()->set_Text(u"Round Join Style");

presentation->Save(u"join_styles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Miter‑Verbindungen an scharfen Ecken begrenzen**

Verwende [ILineFormat::set_MiterLimit](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_miterlimit/) zusammen mit [ILineFormat::set_JoinStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_joinstyle/) auf [LineJoinStyle::Miter](https://reference.aspose.com/slides/cpp/aspose.slides/linejoinstyle/), um zu begrenzen, wie weit eine scharfe Ecke ausstrecken darf.

Der Grenzwert ist das Verhältnis des Abstands zwischen innerer und äußerer Ecke der Verbindung zur Linienbreite. Zum Beispiel erlaubt ein Wert von `8` eine Miter‑Länge von bis zu acht facher Linienbreite; es handelt sich nicht um eine Messung in Punkten. Überschreitet die Ecke den Grenzwert, verwendet PowerPoint an dieser Stelle eine abgeschrägte Verbindung. Ein größerer Grenzwert ermöglicht spitzere Punkte. Die Einstellung wirkt sich nur auf Miter‑Verbindungen aus und hat keinen sichtbaren Effekt, solange die Ecke innerhalb beider Grenzwerte bleibt.

Dieses Beispiel erstellt zwei identische, nicht gefüllte Dreiecke mit Konturen, 20 Punkte breit. Das linke Dreieck verwendet einen Grenzwert von `2`, das rechte `8`. Jedes Dreieck ist 80 Punkte breit und 160 Punkte hoch, was seinem oberen Scheitel ein Miter‑Längen‑zu‑Linienbreite‑Verhältnis von ungefähr `4.12` gibt. Folglich wird der linke Scheitel abgeschrägt und der rechte beibehalten.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/LineJoinStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(500, 320, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

const auto miterLimits = std::array<float, 2>{ 2.0f, 8.0f };

for (auto i = 0; i < miterLimits.size(); i++)
{
    auto triangle = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 90 + i * 240, 110, 80, 160);
    triangle->get_FillFormat()->set_FillType(FillType::NoFill);
    triangle->get_LineFormat()->set_Width(20);
    triangle->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
    triangle->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
    triangle->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
    triangle->get_LineFormat()->set_MiterLimit(miterLimits[i]);
}

presentation->Save(u"miter_limits.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Das Ergebnis in PowerPoint: **Miter‑Grenzwert 2** links und **Miter‑Grenzwert 8** rechts.

![Ein abgeschrägter Scheitel mit Miter‑Grenzwert 2 und ein spitzer Scheitel mit Miter‑Grenzwert 8 in PowerPoint](miter-limits.png)

## **Verlaufsfüllung**

Eine Verlaufsfüllung blendet Farben über einer Form hinweg. Dieses Beispiel füllt eine Ellipse mit einem linearen Verlauf unter einem 45‑Grad‑Winkel von Rot nach Lila, indem es [IFillFormat::get_GradientFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_gradientformat/) verwendet. Die Methode [IGradientStopCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides/igradientstopcollection/add/) legt die Farbstopps bei 0 und 1, dem Anfang bzw. Ende des Verlaufs, fest. Das Löschen vorhandener Stopps stellt sicher, dass nur diese beiden Farben verwendet werden.

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/PresetColor.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);
shape->get_FillFormat()->get_GradientFormat()->set_LinearGradientAngle(45);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Clear();
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Das Ergebnis:

![Die Ellipse mit Verlaufsfüllung](gradient-fill.png)

Falls ein Verlauf in einem exportierten Bild anders aussieht als in PowerPoint, siehe [Choose a Gradient Rendering Style](/slides/de/cpp/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Du kannst einen Renderstil auswählen, ohne die im Präsentations‑Datei gespeicherte Verlaufsgrafik zu ändern.

### **Den Winkel des linearen Verlaufs festlegen**

Verwende [IGradientFormat::set_LinearGradientAngle](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/set_lineargradientangle/), um die Ausrichtung einer [GradientShape::Linear](https://reference.aspose.com/slides/cpp/aspose.slides/gradientshape/)-Füllung zu steuern. Der Winkel wird in Grad gemessen und erhöht im Uhrzeigersinn: `0` verläuft von links nach rechts, `90` von oben nach unten, `180` von rechts nach links und `270` von unten nach oben. Bruchteilswinkel werden unterstützt. Endliche Winkel außerhalb des Bereichs `[0, 360)` werden zu einer Umdrehung normalisiert; zum Beispiel wird `-45` zu `315` und `360` zu `0`.

Dieses Beispiel erstellt sechs Rechtecke mit identischen roten, grünen und blauen Stopps an den Positionen `0`, `0.5` und `1`. Die Skalierung ist deaktiviert, sodass der Winkel unabhängig von den Proportionen der Rechtecke verglichen werden kann. Die Winkel von links nach rechts lauten in der ersten Reihe `0`, `45` und `90`, in der zweiten Reihe `135`, `180` und `270`.

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(720, 400, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

const auto angles = std::array<float, 6>{ 0, 45, 90, 135, 180, 270 };

for (auto i = 0; i < angles.size(); i++)
{
    auto x = 30 + (i % 3) * 230;
    auto y = 30 + (i / 3) * 190;

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, x, y, 200, 150);
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_FillFormat()->set_FillType(FillType::Gradient);

    auto gradient = shape->get_FillFormat()->get_GradientFormat();
    gradient->set_GradientShape(GradientShape::Linear);
    gradient->get_GradientStops()->Clear();
    gradient->get_GradientStops()->Add(0.0f, Color::get_Red());
    gradient->get_GradientStops()->Add(0.5f, Color::get_Lime());
    gradient->get_GradientStops()->Add(1.0f, Color::get_Blue());
    gradient->set_LinearGradientScaled(NullableBool::False);
    gradient->set_LinearGradientAngle(angles[i]);
}

presentation->Save(u"linear_gradient_angles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Das Ergebnis in PowerPoint:

![Lineare Verläufe bei 0°, 45° und 90° in der oberen Zeile sowie 135°, 180° und 270° in der unteren Zeile](linear-gradient-angles.png)

### **Einen linearen Verlauf mit der Form skalieren**

[IGradientFormat::set_LinearGradientScaled](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/set_lineargradientscaled/) akzeptiert einen [NullableBool](https://reference.aspose.com/slides/cpp/aspose.slides/nullablebool/). Setze ihn explizit auf `False`, um den geometrischen Verlaufswinkel beizubehalten, wenn sich die Proportionen der Form ändern, oder auf `True`, um den Verlauf mit Breite und Höhe der Form zu skalieren. Bei aktivierter Skalierung kann sich der sichtbare Winkel von dem zugewiesenen Winkel auf einer nicht quadratischen Form unterscheiden.

Das folgende Beispiel verwendet einen Winkel von `45` Grad und dieselben Farbstopps wie im Winkelvergleich. Die linke Spalte verwendet `False`; die rechte Spalte verwendet `True`. Jede Spalte enthält ein breites Rechteck über einem hohen Rechteck. Beide beginnen mit denselben breiten Abmessungen; das Ändern von Breite und Höhe des zweiten Rechtecks zeigt, wie die Füllung auf Größenänderungen reagiert, ohne die Verlaufs‑Einstellungen zu ändern.

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(720, 460, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

const auto scalingOptions = std::array<NullableBool, 2>{ NullableBool::False, NullableBool::True };

for (auto column = 0; column < scalingOptions.size(); column++)
{
    for (auto row = 0; row < 2; row++)
    {
        auto x = 30 + column * 360;
        auto y = row == 0 ? 30 : 150;

        auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, x, y, 300, 90);
        shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
        shape->get_FillFormat()->set_FillType(FillType::Gradient);

        auto gradient = shape->get_FillFormat()->get_GradientFormat();
        gradient->set_GradientShape(GradientShape::Linear);
        gradient->get_GradientStops()->Clear();
        gradient->get_GradientStops()->Add(0.0f, Color::get_Red());
        gradient->get_GradientStops()->Add(0.5f, Color::get_Lime());
        gradient->get_GradientStops()->Add(1.0f, Color::get_Blue());
        gradient->set_LinearGradientAngle(45);
        gradient->set_LinearGradientScaled(scalingOptions[column]);

        if (row == 1)
        {
            shape->set_Width(90);
            shape->set_Height(280);
        }
    }
}

presentation->Save(u"linear_gradient_scaling.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Das Ergebnis in PowerPoint, mit deaktivierter Skalierung links und aktivierter Skalierung rechts:

![Breite und hohe Rechtecke mit einem 45‑Grad‑Verlauf, Vergleich LinearGradientScaled False links und True rechts](linear-gradient-scaling.png)

Bei deaktivierter Skalierung behalten die diagonalen Farbstreifen in beiden Rechtecken dieselbe Ausrichtung. Bei aktivierter Skalierung strecken sich die Streifen mit den Proportionen der Form. Dies hilft, den Verlauf einer Vorlage wiederzugeben, wenn eine Form an eine andere Größe angepasst wird. Auf einem Quadrat ändert das Aktivieren der Skalierung das Aussehen dieses `45`‑Grad‑Verlaufs nicht.

Sowohl der Winkel als auch die Skalierungseinstellungen gelten für lineare Verläufe. Sie steuern nicht die Füllungen [GradientShape::Radial oder GradientShape::Rectangle](https://reference.aspose.com/slides/cpp/aspose.slides/gradientshape/).

### **Winkel mit Verlaufsrichtung kombinieren**

[IGradientFormat::set_GradientDirection](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/set_gradientdirection/) wählt einen Verlaufsstil aus der Aufzählung [GradientDirection](https://reference.aspose.com/slides/cpp/aspose.slides/gradientdirection/); sie ersetzt keinen numerischen Winkel. Bei einem linearen Verlauf können die Eckstile den Bereich, über den die Farben verteilt werden, ändern, ohne den über [IGradientFormat::set_LinearGradientAngle](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/set_lineargradientangle/) zugewiesenen Winkel zu ändern. Lass die Richtung unverändert, wenn du Winkel oder Skalierung vergleichst.

Das folgende Beispiel wendet dieselben Einstellungen in umgekehrter Reihenfolge an. Die beiden Rechtecke sehen gleich aus: Das Setzen der Richtung vor oder nach dem Winkel ändert das Ergebnis nicht.

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientDirection.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
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

for (auto i = 0; i < 2; i++)
{
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30, 30 + i * 140, 320, 100);
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_FillFormat()->set_FillType(FillType::Gradient);

    auto gradient = shape->get_FillFormat()->get_GradientFormat();
    gradient->set_GradientShape(GradientShape::Linear);
    gradient->get_GradientStops()->Clear();
    gradient->get_GradientStops()->Add(0.0f, Color::get_Red());
    gradient->get_GradientStops()->Add(0.5f, Color::get_Lime());
    gradient->get_GradientStops()->Add(1.0f, Color::get_Blue());
    gradient->set_LinearGradientScaled(NullableBool::True);

    if (i == 0)
    {
        gradient->set_GradientDirection(GradientDirection::FromCorner1);
        gradient->set_LinearGradientAngle(30);
    }
    else
    {
        gradient->set_LinearGradientAngle(30);
        gradient->set_GradientDirection(GradientDirection::FromCorner1);
    }
}

presentation->Save(u"linear_gradient_direction.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Musterfüllung**

Eine Musterfüllung wendet ein zweifarbiges Design wie Punkte, Streifen oder Rauten an. Dieses Beispiel verwendet [IPatternFormat::set_PatternStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/set_patternstyle/), um ein Gitter‑Muster auszuwählen. [IPatternFormat::get_BackColor](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_backcolor/) liefert den hellgrauen Hintergrund, und [IPatternFormat::get_ForeColor](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_forecolor/) liefert die gelbe Musterfarbe.

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
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_FillFormat()->set_FillType(FillType::Pattern);
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Das Ergebnis:

![Das Rechteck mit Musterfüllung](pattern-fill.png)

## **Bildfüllung**

Eine Bildfüllung verwendet ein Bild innerhalb einer Form. Dieses Beispiel benötigt ein lokales Bild und lädt es über [Images::FromFile](https://reference.aspose.com/slides/cpp/aspose.slides/images/fromfile/) in die Bildsammlung der Präsentation. Das Setzen von [IPictureFillFormat::set_PictureFillMode](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/) auf den Kachel‑Modus wiederholt das Bild innerhalb des Rechtecks. Das hier verwendete Quellbild ist unten abgebildet:

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
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);
shape->get_FillFormat()->set_FillType(FillType::Picture);
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

auto image = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(image);
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(presentationImage);

presentation->Save(u"picture_fill.pptx", SaveFormat::Pptx);
image->Dispose();
presentation->Dispose();
```

Das Ergebnis:

![Die Form mit Bildfüllung](picture-fill.png)

### **Bild kacheln als Textur**

Wenn du ein gekacheltes Bild als Textur festlegen und das Kachel‑Verhalten anpassen möchtest, kannst du die folgenden Methoden des Interfaces [IPictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/) und der Klasse [PictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/) verwenden:

- [set_PictureFillMode](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): Legt den Bildfüll‑Modus fest – entweder `Tile` oder `Stretch`.
- [set_TileAlignment](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): Gibt die Ausrichtung der Kacheln innerhalb der Form an.
- [set_TileFlip](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileflip/): Steuert, ob die Kachel horizontal, vertikal oder beide Richtungen gespiegelt wird.
- [set_TileOffsetX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): Setzt den horizontalen Versatz der Kachel (in Punkten) vom Ursprung der Form.
- [set_TileOffsetY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): Setzt den vertikalen Versatz der Kachel (in Punkten) vom Ursprung der Form.
- [set_TileScaleX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): Definiert die horizontale Skalierung der Kachel als Prozentsatz.
- [set_TileScaleY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): Definiert die vertikale Skalierung der Kachel als Prozentsatz.

Dieses Beispiel benötigt ein lokales Bild und konfiguriert [IPictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/), sodass es mit 50 % seiner Originalgröße wiederholt wird. Offsets von −32 Punkten verschieben die Kacheln horizontal und vertikal; die Ausrichtung unten‑rechts und das Spiegeln in beide Richtungen bestimmen, wie die wiederholte Textur angeordnet wird.

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
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto firstSlide = presentation->get_Slide(0);

auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);
shape->get_FillFormat()->set_FillType(FillType::Picture);

auto sourceImage = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(sourceImage);

auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);
pictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
pictureFillFormat->set_TileOffsetX(-32);
pictureFillFormat->set_TileOffsetY(-32);
pictureFillFormat->set_TileScaleX(50);
pictureFillFormat->set_TileScaleY(50);
pictureFillFormat->set_TileAlignment(RectangleAlignment::BottomRight);
pictureFillFormat->set_TileFlip(TileFlip::FlipBoth);

presentation->Save(u"tile.pptx", SaveFormat::Pptx);
sourceImage->Dispose();
presentation->Dispose();
```

Das Ergebnis:

![Die Kachel‑Optionen](tile-options.png)

## **Einfarbige Füllung**

Eine einfarbige Füllung verleiht einer Form eine einheitliche Farbe. Dieses Beispiel setzt [IFillFormat::set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) auf den einfarbigen Füllmodus und weist Gelb über [IFillFormat::get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/) zu, dann speichert es das Rechteck in einer Präsentation.

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
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Das Ergebnis:

![Die Form mit einfarbiger Füllung](solid-color-fill.png)

### **Farben kopieren und Theme‑Verweise erhalten**

Verwende [IColorFormat::CopyFrom](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/copyfrom/), um eine Farbangabe zu kopieren, einschließlich Farbart, Theme‑Verweis und Transformationen. Das ist nützlich, wenn du eine Füllfarbe zwischen Formen überträgst, die weiterhin dem Präsentations‑Theme folgen sollen. Die Methode kopiert nur die Farbe: Sie kopiert weder den Fülltyp, die Kontur noch andere Formformatierungen. Setze den Ziel‑Fülltyp explizit mit [IFillFormat::set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/).

Dieses Beispiel erstellt drei Rechtecke von links nach rechts: die Quelle, eine Theme‑bewusste Kopie und eine feste RGB‑Kopie. Die Quelle verwendet [IColorFormat::set_SchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/set_schemecolor/), um die erste Akzentfarbe zu referenzieren, und fügt über [IColorOperationCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides/icoloroperationcollection/add/) einen Ton hinzu. Die RGB‑Kopie verwendet die effektive Füllfarbe der Quelle, sodass alle drei zunächst identisch aussehen. Das Aufrufen von [IColorFormat::set_Color](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/set_color/) setzt einen festen RGB‑Wert und löscht vorhandene Farbtransformationen.

```cpp
#include <DOM/ColorTransformOperation.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IColorOperationCollection.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/Theme/IColorScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <initializer_list>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(660, 220, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

presentation->get_MasterTheme()->get_ColorScheme()->get_Accent1()->set_Color(Color::get_RoyalBlue());

auto source = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30, 40, 180, 140);
auto themeCopy = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 240, 40, 180, 140);
auto rgbCopy = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 450, 40, 180, 140);

for (auto shape : { source, themeCopy, rgbCopy })
{
    shape->get_FillFormat()->set_FillType(FillType::Solid);
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
}

auto sourceColor = source->get_FillFormat()->get_SolidFillColor();
sourceColor->set_SchemeColor(SchemeColor::Accent1);
sourceColor->get_ColorTransform()->Add(ColorTransformOperation::Tint, 0.75f);

themeCopy->get_FillFormat()->get_SolidFillColor()->CopyFrom(sourceColor);
auto effectiveFill = source->get_FillFormat()->GetEffective();
rgbCopy->get_FillFormat()->get_SolidFillColor()->set_Color(effectiveFill->get_SolidFillColor());

auto before = slide->GetImage(1.0f, 1.0f);
before->Save(u"color-copy-before.png", ImageFormat::Png);
before->Dispose();

// Theme-Referenzen folgen der neuen Akzentfarbe; der feste RGB-Wert folgt ihr nicht.
presentation->get_MasterTheme()->get_ColorScheme()->get_Accent1()->set_Color(Color::get_OrangeRed());

auto after = slide->GetImage(1.0f, 1.0f);
after->Save(u"color-copy-after.png", ImageFormat::Png);
after->Dispose();
presentation->Save(u"copied_colors.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Vor dem Theme‑Wechsel stimmen alle drei Füllungen überein:

![Quelle, CopyFrom‑Ziel und feste RGB‑Ziel mit identischen blauen Füllungen](color-copy-before.png)

Nach dem Theme‑Wechsel folgen die Quelle und die Theme‑bewusste Kopie der neuen Akzentfarbe und behalten ihren Ton bei. Die feste RGB‑Kopie bleibt blau:

![Quelle und CopyFrom‑Ziel mit orangefarbenen Füllungen, während das feste RGB‑Ziel blau bleibt](color-copy-after.png)

Die kopierte Definition ist unabhängig von der Quelle. Änderungen an der Theme‑Referenz der Quelle, das Zuweisen einer anderen Farbe oder das Hinzufügen bzw. Entfernen von Transformationen ändern das Ziel nicht. Ein Theme‑Wechsel wirkt sich dennoch auf beide Formen aus, da jede eigenständig auf dieselbe Theme‑Farbe referenziert.

Das Speichern und erneute Öffnen der PPTX bewahrt den Farbtyp der Kopie, verfügbar über [IColorFormat::get_ColorType](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/get_colortype/), ihren Theme‑Verweis und die Transformationssammlung, die über [IColorFormat::get_ColorTransform](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/get_colortransform/) zurückgegeben wird; sie wird nicht in RGB flachgelegt.

Beim Kopieren zwischen unterschiedlichen Theme‑Kontexten, beispielsweise Präsentationen mit verschiedenen Akzent-Paletten, wird der kopierte Verweis gegen das Theme des Ziels aufgelöst. Der gleiche Verweis und dieselben Transformationen können daher eine andere sichtbare Farbe erzeugen. Siehe [Presentation Theme](/slides/de/cpp/presentation-theme/) für mehr Informationen zur Konfiguration von Theme‑Farben.

## **Folienhintergrund als Formfüllung verwenden**

Verwende [IAutoShape::set_UseBackgroundFill](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/set_usebackgroundfill/), wenn eine Form dem Folienhintergrund entsprechen soll, beispielsweise in einer Präsentationsvorlage. Setze zunächst [IFillFormat::set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) auf [FillType::NotDefined](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/), um eine explizite Füllung zu entfernen. Mit dieser Kombination verwendet die Form den Folienhintergrund anstelle ihrer eigenen Stil‑Füllung. Das reine Aktivieren des Flags entfernt keine bereits vorhandene explizite Füllung.

Dies unterscheidet sich von [FillType::NoFill](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/): Eine Hintergrundfüllung deckt Objekte hinter der Form mit dem entsprechenden Bereich des Folienhintergrunds ab, während keine Füllung diese Objekte sichtbar lässt. Ein Verlauf bleibt dabei an der Folie ausgerichtet, statt in jeder Form neu zu beginnen.

Das folgende Beispiel erstellt einen Master‑Hintergrund, der von der Folie geerbt wird, und platziert ein magentafarbenes Band hinter drei Rechtecken. Das linke Rechteck verwendet den Hintergrund, das mittlere hat keine Füllung, das rechte wechselt von Hintergrund‑Füllung zu einer expliziten orangefarbenen Füllung.

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(720, 400, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

// Vererbe den Verlauf vom Master.
slide->get_Background()->set_Type(BackgroundType::NotDefined);
slide->get_LayoutSlide()->get_Background()->set_Type(BackgroundType::NotDefined);
auto background = slide->get_LayoutSlide()->get_MasterSlide()->get_Background();
background->set_Type(BackgroundType::OwnBackground);
background->get_FillFormat()->set_FillType(FillType::Gradient);
auto gradient = background->get_FillFormat()->get_GradientFormat();
gradient->set_GradientShape(GradientShape::Linear);
gradient->set_LinearGradientAngle(0);
gradient->get_GradientStops()->Clear();
gradient->get_GradientStops()->Add(0, Color::get_DarkBlue());
gradient->get_GradientStops()->Add(1, Color::get_LightSkyBlue());

// Füge dieses Objekt zuerst hinzu, damit es hinter den Rechtecken erscheint.
auto band = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 25, 150, 670, 100);
band->get_FillFormat()->set_FillType(FillType::Solid);
band->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Magenta());
band->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

auto backgroundShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 100, 160, 200);
backgroundShape->get_FillFormat()->set_FillType(FillType::NotDefined);
backgroundShape->set_UseBackgroundFill(true);

auto noFillShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 280, 100, 160, 200);
noFillShape->get_FillFormat()->set_FillType(FillType::NoFill);

auto explicitShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 510, 100, 160, 200);
explicitShape->get_FillFormat()->set_FillType(FillType::NotDefined);
explicitShape->set_UseBackgroundFill(true);

// Deaktiviere die Hintergrundfüllung, bevor eine explizite Füllung angewendet wird.
explicitShape->set_UseBackgroundFill(false);
explicitShape->get_FillFormat()->set_FillType(FillType::Solid);
explicitShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());

presentation->Save(u"background_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Das Ergebnis von links nach rechts: **Hintergrund‑Füllung**, **Keine Füllung** und **Explizite Füllung**. Das magentafarbene Band wird von den linken und rechten Rechtecken verdeckt, bleibt jedoch durch das mittlere Rechteck sichtbar.

![Hintergrund‑Füllung, keine Füllung und explizite orange Füllung über einem magentafarbenen Band](background-fill.png)

Dasselbe Verhalten gilt für einen direkt auf der Folie definierten Hintergrund oder einen von einem Layout geerbten Hintergrund. Die Form verwendet den aufgelösten Folienhintergrund; das Beispiel lässt sowohl den Folien‑ als auch den Layout‑Hintergrund undefiniert, sodass der Master ihn liefert.

## **Transparenz festlegen**

Bei einer einfarbigen Füllung steuert die Alpha‑Komponente der Farbe die Undurchsichtigkeit: 0 ist vollständig transparent und 255 vollständig undurchsichtig. Dieses Beispiel verwendet einen Alpha‑Wert von 128 für ein gelbes Rechteck, wodurch es etwa zu 50 % transparent ist und das darunterliegende Rechteck sichtbar bleibt. Die Farbe wird über [IFillFormat::get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/) zugewiesen.

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
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

const int alpha = 128;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, Color::get_Yellow()));

presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Das Ergebnis:

![Die transparente Form](shape-transparency.png)

## **Formen drehen**

Verwende [IShape::set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_rotation/), um eine Form in der Folien­ebene zu drehen. Der Winkel wird in Grad gemessen; dieses Beispiel dreht ein Rechteck um 5 Grad im Uhrzeigersinn und speichert die Präsentation.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto

```

Das Ergebnis:

![Die Drehung der Form](shape-rotation.png)

## **3D‑Kanten‑Effekte hinzufügen**

Verwende [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_threedformat/), um einer Form Tiefe und abgeschrägte Kanten zu verleihen. Dieses Beispiel erstellt eine grüne Ellipse mit einer orangefarbenen Kontur, setzt [IThreeDFormat::set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_depth/) auf 4 Punkte und wendet über [IThreeDFormat::get_BevelTop](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_beveltop/) einen kreisförmigen oberen Keil mit Breite und Höhe von 6 Punkten an. Eine front‑facing orthografische Kamera und eine Dreipunkt‑Beleuchtung lassen den Keil sichtbar werden.

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
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Green());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->set_Width(2.0);
shape->get_ThreeDFormat()->set_Depth(4);
shape->get_ThreeDFormat()->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
shape->get_ThreeDFormat()->get_BevelTop()->set_Height(6);
shape->get_ThreeDFormat()->get_BevelTop()->set_Width(6);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);

presentation->Save(u"3D_bevel_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Das Ergebnis:

![Der 3D‑Kanten‑Effekt](3D-bevel-effect.png)

## **3D‑Dreh‑Effekte hinzufügen**

Die 3D‑Ansicht einer Form wird durch ihre Kamera‑Einstellungen gesteuert. Dieses Beispiel verwendet [ICamera::SetRotation](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/setrotation/) mit Latitude‑, Longitude‑ und Revolutions‑Winkeln von 40, 35 bzw. 20 Grad. Es wählt über [ICamera::set_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/set_cameratype/) eine isometrische Kamera und über [ILightRig::set_LightType](https://reference.aspose.com/slides/cpp/aspose.slides/ilightrig/set_lighttype/) eine ausgeglichene Beleuchtung, dann speichert es das formatierte Rechteck.

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
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
autoShape->get_TextFrame()->set_Text(u"Hello, Aspose!");
autoShape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
autoShape->get_ThreeDFormat()->get_Camera()->SetRotation(40, 35, 20);
autoShape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

presentation->Save(u"3D_rotation_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Das Ergebnis:

![Der 3D‑Dreh‑Effekt](3D-rotation-effect.png)

## **Schwarz‑weiß‑Darstellung für Formen steuern**

Die Methode [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_blackwhitemode/) legt fest, wie eine einzelne Form gerendert wird, wenn eine Präsentation im Schwarz‑weiß‑Modus angezeigt oder verarbeitet wird. Sie aktiviert die Schwarz‑weiß‑Anzeige nicht selbst und ändert weder die Füllung, die Kontur noch andere Formatierungen im normalen Farbmodus.

Verwende einen Wert aus der Aufzählung [BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/blackwhitemode/), um das gewünschte Verhalten auszuwählen. Beispielsweise lässt `Automatic` die Rendering‑Anwendung die Konvertierung wählen, `Gray` und `LightGray` verwenden Grautöne, `BlackWhite` nutzt nur Schwarz und Weiß, `Black` und `White` erzwingen eine einzelne Farbe, `Color` erhält die normale Farbgebung, und `Hidden` lässt die Form im Schwarz‑weiß‑Modus wegfallen. `NotDefined` bedeutet, dass kein Modus auf Form‑Ebene zugewiesen ist.

Dieses Beispiel erstellt ein orangefarbenes Rechteck und setzt [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_blackwhitemode/) auf `Gray`. Die gespeicherte Form behält ihre orange Farbe für die normale Farbdarstellung bei und fordert bei Anwendungen, die den Schwarz‑weiß‑Modus honorieren, eine graue Darstellung an:

```cpp
#include <DOM/BlackWhiteMode.h>
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
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->set_BlackWhiteMode(BlackWhiteMode::Gray);

presentation->Save(u"shape_black_white_mode.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Im normalen Farbmodus behält das Rechteck seine orange Füllung. In einem Schwarz‑weiß‑Workflow nutzt es die graue Färbung, weil sein Modus auf `Gray` gesetzt ist. So kannst du eine Voll‑Farb‑Folien‑Präsentation erhalten und gleichzeitig ein abweichendes Aussehen für Druck, Vorschau oder andere Workflows definieren, die die Schwarz‑weiß‑Einstellungen der Präsentation berücksichtigen.

## **Formatierung zurücksetzen**

Verwende [ISlide::Reset](https://reference.aspose.com/slides/cpp/aspose.slides/islide/reset/), um Position, Größe und Formatierung von Platzhaltern einer Folie aus den entsprechenden Platzhaltern des zugehörigen Layouts wiederherzustellen. Dieses Beispiel benötigt eine vorhandene Präsentation mit layout‑verknüpften Platzhaltern und setzt jede Folie zurück, bevor sie gespeichert wird. Formen ohne entsprechendes Layout‑Platzhalter werden nicht zurückgesetzt.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
for (auto&& slide : IterateOver(presentation->get_Slides()))
{
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Beeinflusst die Formformatierung die endgültige Dateigröße der Präsentation?**

Farben, Linienstile und Effekt‑Einstellungen fügen im Vergleich zu eingebetteten Bildern und Medien nur wenig Daten hinzu. Bild‑Füllungen können die Dateigröße erhöhen, weil ihre Bilder in der Präsentation gespeichert werden.

**Wie kann ich Formen auf einer Folie erkennen, die identische Formatierung besitzen, um sie zu gruppieren?**

Vergleiche die wichtigsten Formatierungs‑Eigenschaften jeder Form – Füllung, Linie und Effekte. Stimmen alle entsprechenden Werte überein, betrachte ihre Stile als identisch und gruppiere die Formen logisch; das vereinfacht spätere Stil‑Verwaltung.

**Kann ich einen Satz benutzerdefinierter Formstile in einer separaten Datei speichern, um ihn in anderen Präsentationen wiederzuverwenden?**

Ja. Speichere Beispiel‑Formen mit den gewünschten Stilen in einem Vorlagen‑Slide‑Deck oder einer .POTX‑Vorlagendatei. Beim Erstellen einer neuen Präsentation öffne die Vorlage, klone die benötigten stilisierten Formen und wende deren Formatierung dort an, wo sie benötigt wird.