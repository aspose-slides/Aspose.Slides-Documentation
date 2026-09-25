---
title: Verwalten von Präsentationsformen in C++
linktitle: Formmanipulation
type: docs
weight: 40
url: /de/cpp/shape-manipulations/
keywords:
- PowerPoint-Form
- Präsentationsform
- Form auf Folie
- Form finden
- Form klonen
- Form entfernen
- Form ausblenden
- Formreihenfolge ändern
- Interop-Form-ID erhalten
- alternativer Text der Form
- Formanpassungspunkt
- vordefinierte Formanpassung
- Formgeometrie
- Form-Layout-Formate
- Form als SVG
- Form zu SVG
- Form ausrichten
- Form spiegeln
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie Präsentationsformen mit Aspose.Slides für C++ identifizieren, anpassen, klonen, entfernen, ausblenden, neu anordnen, exportieren, ausrichten und spiegeln."
---
## **Übersicht**

Aspose.Slides for C++ stellt die Formen auf einer Folie als geordnete [IShapeCollection](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishapecollection/). Die Sammlung ist sowohl der Ort, an dem Sie Formen finden und ändern, als auch die Quelle ihrer Stapelreihenfolge: Index `0` ist die hinterste Form, während der letzte Index die vorderste Form ist.

Dieser Artikel folgt diesem Modell. Er erklärt zunächst, wie man eine Form zuverlässig identifiziert und vordefinierte Formanpassungspunkte ändert, und zeigt dann, wie man Formen klont, entfernt, ausblendet und neu anordnet. Die abschließenden Abschnitte behandeln Layout‑bezogene Formatierung, SVG‑Export, Ausrichtung und Spiegelungseinstellungen. Jeder Abschnitt ist unabhängig, sodass Sie nur die für Ihren Workflow benötigten Vorgänge verwenden können.

## **Identifizieren und Finden von Formen**

Sammlungsindizes sind beim Verarbeiten einer bekannten Datei praktisch, aber sie sind keine stabilen Kennungen. Das Hinzufügen, Entfernen oder Neuanordnen einer Form kann ihren Index ändern. Wählen Sie einen Bezeichner entsprechend der Art und Weise, wie die Präsentation erstellt und gepflegt wird:

- [Name](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/get_name/) ist nützlich für von Entwicklern gesteuerte Vorlagen und lässt sich leicht im Auswahlbereich von PowerPoint prüfen. Namen können bearbeitet werden und sind nicht garantiert eindeutig, daher sollten Sie eine Namenskonvention festlegen, wenn Code davon abhängt.
- [AlternativeText](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/get_alternativetext/) ist nützlich, wenn eine Barrierefreiheitsbeschreibung oder ein vom Autor bereitgestelltes Tag die Form bereits identifiziert. Es ist für Benutzer sichtbar, kann lokalisiert oder für Barrierefreiheit umgeschrieben werden und ist nicht garantiert eindeutig. Verwenden Sie nicht stillschweigend bedeutungsvollen Barrierefreiheitstext als Datenbankschlüssel.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/get_officeinteropshapeid/) ist ein schreibgeschützter Bezeichner, der innerhalb einer Folie eindeutig ist und der von PowerPoint‑Interop verwendeten Form‑ID entspricht. Verwenden Sie ihn, wenn Sie mit PowerPoint integrieren oder während der Lebensdauer einer Form einen eindeutigen Verweis benötigen. Eine geklonte oder neu erstellte Form ist eine andere Form und erhält ihre eigene ID.

Die zugehörige [UniqueId](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/get_uniqueid/)‑Eigenschaft hat Geltungsbereich einer Präsentation, ist jedoch für Add‑Ins gedacht und kann neu zugewiesen werden. Sie sollte nicht als permanenter externer Schlüssel behandelt werden. Wenn eine langfristige Identität wesentlich ist, behalten Sie die Zuordnung in Anwendungsdaten und prüfen Sie, ob die erwartete Form noch existiert.

Für ein praktisches Beispiel zum Lesen und Aktualisieren sowohl des alternativen Text‑Titels als auch der Beschreibung siehe [Manage Alternative Text Titles and Descriptions](/slides/de/cpp/presentation-accessibility/). Verwenden Sie alternativen Text, um die Bedeutung der Grafik für Leser zu erklären, und halten Sie ihn getrennt von Formnamen, die vom Code zum Finden von Formen verwendet werden.

Das folgende Beispiel sucht nach `Name` und gibt die folienbezogene Interop‑ID aus. Wenn die Vorlage die erwartete Form nicht enthält, meldet der Code dieses Ergebnis, anstatt mit dem falschen Objekt fortzufahren.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IShape> targetShape;
for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"RevenueChart")
    {
        targetShape = shape;
        break;
    }
}

if (targetShape == nullptr)
{
    Console::WriteLine(u"The shape 'RevenueChart' was not found on slide 1.");
}
else
{
    Console::WriteLine(String::Format(u"Found {0}; interop ID: {1}", targetShape->get_Name(), targetShape->get_OfficeInteropShapeId()));
}

presentation->Dispose();
```

Wenn ein Vorgang spezifisch für einen Formtyp ist, prüfen Sie das Interface, bevor Sie typspezifische Mitglieder verwenden. Dieses Beispiel aktualisiert Text und alternativen Text nur, wenn das benannte Objekt ein [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/) ist.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IShape> candidate;
for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"StatusLabel")
    {
        candidate = shape;
        break;
    }
}

if (candidate != nullptr && ObjectExt::Is<IAutoShape>(candidate))
{
    auto autoShape = ExplicitCast<IAutoShape>(candidate);
    autoShape->get_TextFrame()->set_Text(u"Approved");
    autoShape->set_AlternativeText(u"Approval status: approved");
    presentation->Save(u"identified-shape.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"'StatusLabel' is missing or is not an AutoShape.");
}

presentation->Dispose();
```

## **Identifizieren und Ändern von vordefinierten Formanpassungen**

Vordefinierte Geometrieformen können Anpassungspunkte offenbaren, die Eigenschaften wie Eckgröße, Pfeilverhältnisse oder Bogenwinkel steuern. Greifen Sie über die schreibgeschützte [IGeometryShape::get_Adjustments](https://reference.aspose.com/slides/de/cpp/aspose.slides/igeometryshape/get_adjustments/)‑Sammlung darauf zu. Die Sammlung selbst wird von der Form bereitgestellt, aber jedes [IAdjustValue](https://reference.aspose.com/slides/de/cpp/aspose.slides/iadjustvalue/) enthält einen Wert, der geändert werden kann.

Verlassen Sie sich nicht ausschließlich auf einen festen Sammlungsindex. Durchlaufen Sie die Anpassungen und prüfen Sie die schreibgeschützte [IAdjustValue::get_Type](https://reference.aspose.com/slides/de/cpp/aspose.slides/iadjustvalue/get_type/)‑Eigenschaft, deren [ShapeAdjustmentType](https://reference.aspose.com/slides/de/cpp/aspose.slides/shapeadjustmenttype/)‑Wert beschreibt, was die Anpassung kontrolliert. Die schreibgeschützte [IAdjustValue::get_Name](https://reference.aspose.com/slides/de/cpp/aspose.slides/iadjustvalue/get_name/)‑Eigenschaft liefert zusätzliche Identifikationsinformationen und ist besonders nützlich, wenn ein Preset mehr als eine Anpassung mit demselben semantischen Typ enthält.

Verwenden Sie die Werteigenschaft, die der Bedeutung der Anpassung entspricht:

| Anpassungstyp | Zweck | Zu ändernder Wert |
|---|---|---|
| `CornerSize` | Größe abgerundeter Ecken | [RawValue](https://reference.aspose.com/slides/de/cpp/aspose.slides/iadjustvalue/set_rawvalue/) |
| `ArrowTailThickness` | Dicke eines Pfeilendes | `RawValue` |
| `ArrowheadLength` | Länge einer Pfeilspitze | `RawValue` |
| `ArrowheadWidth` | Breite einer Pfeilspitze | `RawValue` |
| `StartAngle` | Startwinkel eines Torten- oder Bogensegments | [AngleValue](https://reference.aspose.com/slides/de/cpp/aspose.slides/iadjustvalue/set_anglevalue/) |
| `EndAngle` | Endwinkel eines Torten- oder Bogensegments | `AngleValue` |

`Type` und `Name` können nicht zugewiesen werden. `RawValue` ist ein les‑/schreibbarer Integer in den nativen Geometriemaßen des Presets, während `AngleValue` ein les‑/schreibbarer Winkel in Grad ist. Anzahl, Reihenfolge, Bedeutung und gültiger Bereich der Anpassungen hängen vom Preset‑[ShapeType](https://reference.aspose.com/slides/de/cpp/aspose.slides/igeometryshape/get_shapetype/) ab. Ein Wert, der für ein Preset gültig ist, kann für ein anderes ungültig oder mit anderer Wirkung sein.

Wenn `Type` `ShapeAdjustmentType::Custom` ist, erkennt die API keine standardmäßige semantische Bedeutung. Prüfen Sie `Name`, den Preset‑Typ und den vorhandenen Wert und lassen Sie die Anpassung unverändert, sofern die erwartete Bedeutung und der Bereich nicht bekannt sind. Selbst bei erkannten Typen sollten Sie prüfen, ob derselbe Typ mehr als einmal vorkommt, bevor Sie einen Wert auswählen. Der Artikel [Connector](/slides/de/cpp/connector/) zeigt diese Situation bei Bieganpassungen von Verbindern.

Das folgende vollständige Beispiel erzeugt Standard‑ und geänderte Varianten von drei Preset‑Formen. Es durchläuft jede Anpassung, gibt deren `Name` und `Type` aus, ändert größenbezogene Werte über `RawValue`, ändert Winkel über `AngleValue` und speichert das Ergebnis. Die linke Spalte behält die Standardgeometrie; die rechte Spalte zeigt das angepasste abgerundete Rechteck, den Vier‑Wege‑Pfeil und das Kuchen‑Segment.

```cpp
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Fügt Überschriften für die Standard- und angepassten Formspalten hinzu.
auto defaultColumnLabel = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 20, 250, 30);
defaultColumnLabel->get_TextFrame()->set_Text(u"Default preset geometry");
auto adjustedColumnLabel = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 390, 20, 250, 30);
adjustedColumnLabel->get_TextFrame()->set_Text(u"Modified adjustment values");

slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 80, 70, 160, 70);
auto modifiedRoundedRectangle = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 430, 70, 160, 70);
modifiedRoundedRectangle->set_Name(u"ModifiedRoundedRectangle");

slide->get_Shapes()->AddAutoShape(ShapeType::QuadArrow, 80, 180, 160, 110);
auto modifiedArrow = slide->get_Shapes()->AddAutoShape(ShapeType::QuadArrow, 430, 180, 160, 110);
modifiedArrow->set_Name(u"ModifiedQuadArrow");

slide->get_Shapes()->AddAutoShape(ShapeType::Pie, 95, 330, 130, 130);
auto modifiedPie = slide->get_Shapes()->AddAutoShape(ShapeType::Pie, 445, 330, 130, 130);
modifiedPie->set_Name(u"ModifiedPie");

auto shapesToAdjust = MakeArray<SharedPtr<IGeometryShape>>({modifiedRoundedRectangle, modifiedArrow, modifiedPie});

for (auto shape : shapesToAdjust)
{
    auto adjustments = shape->get_Adjustments();
    for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
    {
        auto adjustment = adjustments->idx_get(adjustmentIndex);
        Console::WriteLine(shape->get_Name() + u" / " + adjustment->get_Name() + u": " + ObjectExt::ToString(adjustment->get_Type()));

        switch (adjustment->get_Type())
        {
            case ShapeAdjustmentType::CornerSize:
                adjustment->set_RawValue(5000);
                break;
            case ShapeAdjustmentType::ArrowTailThickness:
                adjustment->set_RawValue(25000);
                break;
            case ShapeAdjustmentType::ArrowheadLength:
                adjustment->set_RawValue(30000);
                break;
            case ShapeAdjustmentType::ArrowheadWidth:
                adjustment->set_RawValue(40000);
                break;
            case ShapeAdjustmentType::StartAngle:
                adjustment->set_AngleValue(30);
                break;
            case ShapeAdjustmentType::EndAngle:
                adjustment->set_AngleValue(300);
                break;
            case ShapeAdjustmentType::Custom:
                Console::WriteLine(u"Custom adjustment '" + adjustment->get_Name() + u"' was not changed.");
                break;
        }
    }
}

presentation->Save(u"preset-shape-adjustments.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Das Überprüfen des semantischen Typs vor dem Ändern eines Werts macht den Code explizit hinsichtlich seiner Absicht und verhindert die Annahme, dass ein bestimmter Sammlungsindex dieselbe Bedeutung bei verschiedenen Preset‑Formen hat.

## **Ändern der Formensammlung**

Die Methoden zum Hinzufügen, Klonen, Entfernen und Neuordnen wirken sofort auf die Sammlung. Wenn ein Vorgang die Anzahl oder Reihenfolge von Formen ändert, verlassen Sie sich nicht weiter auf vor dem Vorgang erfasste Indizes.

### **Klone einer Form**

[AddClone](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishapecollection/addclone/) erstellt eine unabhängige Kopie und hängt sie an die Zielsammlung an. [InsertClone](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishapecollection/insertclone/) erstellt ebenfalls eine Kopie, platziert sie jedoch an einem angegebenen Z‑Order‑Index. Die Überladungen, die Koordinaten akzeptieren, verschieben den Klon ohne Größenänderung; Überladungen mit Breite und Höhe können ihn ebenfalls skalieren.

Das Beispiel erstellt eine Ziel­folie, klont ein beschriftetes Rechteck nach vorne und fügt einen zweiten Klon hinten ein. Änderungen an einem der Klone verändern nicht die Ausgangsform.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto sourceSlide = presentation->get_Slide(0);
auto sourceShape = sourceSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 180, 60);
sourceShape->set_Name(u"SourceLabel");
sourceShape->get_TextFrame()->set_Text(u"Source");

auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto destinationSlide = presentation->get_Slides()->AddEmptySlide(blankLayout);

auto frontCloneShape = destinationSlide->get_Shapes()->AddClone(sourceShape, 80, 80);
frontCloneShape->set_Name(u"FrontClone");
if (ObjectExt::Is<IAutoShape>(frontCloneShape))
{
    auto frontClone = ExplicitCast<IAutoShape>(frontCloneShape);
    frontClone->get_TextFrame()->set_Text(u"Front clone");
}
else
{
    Console::WriteLine(u"The front clone is not an AutoShape; its text was not changed.");
}

auto backCloneShape = destinationSlide->get_Shapes()->InsertClone(0, sourceShape, 80, 180);
backCloneShape->set_Name(u"BackClone");
if (ObjectExt::Is<IAutoShape>(backCloneShape))
{
    auto backClone = ExplicitCast<IAutoShape>(backCloneShape);
    backClone->get_TextFrame()->set_Text(u"Back clone");
}
else
{
    Console::WriteLine(u"The back clone is not an AutoShape; its text was not changed.");
}

presentation->Save(u"cloned-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Klonen kopiert den Inhalt und die Formatierung der Form, einschließlich Name und alternativem Text. Weisen Sie dem Klon neue logische Bezeichner zu, wenn diese Werte eindeutig sein müssen. Ressourcen, die von komplexen Formen verwendet werden, werden von der Präsentation verwaltet, aber ein Klon bleibt ein neuer Sammlungs­eintrag mit einer neuen Formidentität.

### **Entfernen von Formen**

[Remove](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishapecollection/remove/) löscht ein bestimmtes Formobjekt aus seiner Sammlung. Beim Entfernen mehrerer Treffer während einer indizierten Iteration sollten Sie von hinten nach vorne traversieren, damit jeder verbleibende Index gültig bleibt.

Dieses Beispiel entfernt jede Form mit einem festgelegten Namen. Es liest die aktuell indizierte Form, nicht ein festes Sammlungs­element, und wirft die Form nicht unnötig um.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto keepShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 140, 60);
keepShape->set_Name(u"Keep");

auto firstTemporaryShape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 220, 40, 80, 80);
firstTemporaryShape->set_Name(u"Temporary");

auto secondTemporaryShape = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 340, 40, 100, 80);
secondTemporaryShape->set_Name(u"Temporary");

for (int32_t i = slide->get_Shapes()->get_Count() - 1; i >= 0; --i)
{
    auto shape = slide->get_Shape(i);
    if (shape->get_Name() == u"Temporary")
    {
        slide->get_Shapes()->Remove(shape);
    }
}

presentation->Save(u"removed-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Nach dem Entfernen ändern sich die Formanzahl und die Indizes späterer Formen. Verweise auf nicht betroffene Formen bleiben zuverlässiger als gespeicherte Indizes. Berücksichtigen Sie zudem Verbinder, Animationen und andere Präsentations‑Features, die auf das entfernte Objekt verweisen könnten; das Entfernen einer sichtbaren Form kann mehr als nur das Aussehen der Folie verändern.

### **Ausblenden einer Form**

Das Setzen von [Hidden](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/set_hidden/) auf `true` behält die Form in der Sammlung, verhindert jedoch ihr Erscheinen in der normalen Bildschirmpräsentation. Index, Formatierung und Inhalt bleiben für Code verfügbar, sodass das Ausblenden für optionale Elemente geeignet ist, die später wiederhergestellt werden können.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto visibleShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 160, 60);
visibleShape->set_Name(u"VisibleLabel");

auto optionalShape = slide->get_Shapes()->AddAutoShape(ShapeType::Moon, 240, 40, 100, 100);
optionalShape->set_Name(u"OptionalDecoration");

for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"OptionalDecoration")
    {
        shape->set_Hidden(true);
    }
}

presentation->Save(u"hidden-shape.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Ausblenden ist weder Löschen noch Sicherheit. Das Objekt kann weiterhin von einem Benutzer oder von Code entdeckt und wieder eingeblendet werden und bleibt Teil der Präsentationsdatei.

### **Ändern der Z‑Reihenfolge**

Überlappende Formen werden in Sammlungsreihenfolge gemalt. [Reorder](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishapecollection/reorder/) verschiebt eine vorhandene Form zu einem Zielindex, ohne sie zu klonen. Index `0` ist der hinterste; `Count - 1` ist der vorderste.

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto blueRectangle = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 220, 120);
blueRectangle->set_Name(u"BlueRectangle");
blueRectangle->get_FillFormat()->set_FillType(FillType::Solid);
blueRectangle->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_SteelBlue());

auto orangeEllipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 180, 140, 220, 120);
orangeEllipse->set_Name(u"OrangeEllipse");
orangeEllipse->get_FillFormat()->set_FillType(FillType::Solid);
orangeEllipse->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());

slide->get_Shapes()->Reorder(slide->get_Shapes()->get_Count() - 1, blueRectangle);
presentation->Save(u"reordered-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Das Rechteck wird zuerst erstellt und liegt zunächst hinter der Ellipse. Das Verschieben auf den letzten Index bringt es nach vorne. Finalisieren Sie die Z‑Reihenfolge, nachdem Sie alle zugehörigen Formen hinzugefügt oder geklont haben, da diese Vorgänge neue Sammlungs­einträge anfügen oder einfügen und den beabsichtigten Stapel ändern können.

## **Untersuchen von Formen auf Layout‑Folien**

Normale Folien, Layout‑Folien und Master‑Folien besitzen getrennte Formensammlungen. Eine Form in einer Layout‑Sammlung ist nicht dasselbe Objekt wie eine ähnlich positionierte Form auf einer normalen Folie. Untersuchen Sie Layout‑Formen, wenn Sie das von einem Layout bereitgestellte Format verstehen oder ändern müssen.

Das folgende Beispiel liest für jede Layout‑Form die [FillFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/get_fillformat/) und [LineFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/get_lineformat/), ohne anzunehmen, dass jede Form ein `AutoShape` ist.

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto layoutSlide : presentation->get_LayoutSlides())
{
    for (auto shape : layoutSlide->get_Shapes())
    {
        auto fillType = shape->get_FillFormat()->get_FillType();
        auto lineWidth = shape->get_LineFormat()->get_Width();
        Console::WriteLine(String::Format(u"{0} / {1}: fill={2}, line width={3}", layoutSlide->get_Name(), shape->get_Name(), fillType, lineWidth));
    }
}

presentation->Dispose();
```

Das Bearbeiten eines Layouts kann mehrere Folien beeinflussen, die es verwenden. Bevor Sie eine Layout‑Form ändern, bestimmen Sie, ob eine normale Folie das Objekt erbt oder eine lokale Überschreibung enthält, und testen Sie jede Folie, die dieses Layout verwendet.

## **Exportieren einer Form nach SVG**

[WriteAsSvg](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/writeassvg/) schreibt den gerenderten Inhalt einer einzelnen Form in einen Stream. Das Ergebnis enthält die Form, nicht den gesamten Folienhintergrund oder benachbarte Formen.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

if (slide->get_Shapes()->get_Count() == 0)
{
    Console::WriteLine(u"Slide 1 does not contain a shape to export.");
}
else
{
    auto shape = slide->get_Shape(0);
    auto svgStream = File::Create(u"shape.svg");
    shape->WriteAsSvg(svgStream);
    svgStream->Close();
}

presentation->Dispose();
```

Halten Sie die Präsentation beim Rendern geöffnet. Die Ausgabe hängt von der Formatierung der Form und von Ressourcen wie Schriften und Bildern ab. Wenn Sie die gesamte Komposition benötigen, exportieren Sie die Folie statt einer einzelnen Form. Der Aufrufer besitzt den Stream und muss ihn schließen oder entsorgen.

## **Ausrichten von Formen**

Die [SlideUtil::AlignShapes](https://reference.aspose.com/slides/de/cpp/aspose.slides.util/slideutil/alignshapes/)‑Überladungen richten entweder alle Formen oder ausgewählte Sammlungsindizes aus. [ShapesAlignmentType](https://reference.aspose.com/slides/de/cpp/aspose.slides/shapesalignmenttype/) gibt die Kante, Mittellinie oder den Verteilungsmodus an. Setzen Sie `alignToSlide` auf `true`, um die Folienkanten zu verwenden; setzen Sie es auf `false`, um die ausgewählten Formen relativ zueinander auszurichten.

Dieses Beispiel richtet drei Formen an der oberen Kante der Folie aus. Die zurückgegebenen Form‑Referenzen werden unmittelbar vor der Ausrichtung in ihre aktuellen Indizes umgewandelt.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/ShapesAlignmentType.h>
#include <Export/SaveFormat.h>
#include <Util/SlideUtil.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Util;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto firstShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 60, 80, 120, 50);
auto secondShape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 240, 160, 120, 50);
auto thirdShape = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 420, 240, 120, 50);
firstShape->set_Name(u"FirstAlignedShape");
secondShape->set_Name(u"SecondAlignedShape");
thirdShape->set_Name(u"ThirdAlignedShape");

auto shapeIndexes = MakeArray<int32_t>({slide->get_Shapes()->IndexOf(firstShape), slide->get_Shapes()->IndexOf(secondShape), slide->get_Shapes()->IndexOf(thirdShape)});

SlideUtil::AlignShapes(ShapesAlignmentType::AlignTop, true, slide, shapeIndexes);
presentation->Save(u"aligned-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Ausrichten ändert Positionen, nicht die Z‑Reihenfolge. Relative Ausrichtung erfordert normalerweise mindestens zwei Formen, während horizontale oder vertikale Verteilung genug Formen benötigt, um Abstände zu definieren. Berechnen Sie Indizes neu, wenn Sie die Sammlung vor dem Aufruf der Methode ändern.

## **Spiegeln einer Form**

Die [ShapeFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/shapeframe/)‑Klasse speichert Position, Größe, horizontale und vertikale Spiegelungseinstellungen sowie Drehung. Ihre `FlipH`‑ und `FlipV`‑Werte verwenden [NullableBool](https://reference.aspose.com/slides/de/cpp/aspose.slides/nullablebool/): `True` aktiviert die Spiegelung, `False` deaktiviert sie, und `NotDefined` bewahrt den nicht festgelegten/Standard‑Zustand.

Die Eingabepräsentation unten enthält eine nicht gespiegelt­e Form.

![Die Form vor dem Spiegeln](shape_to_be_flipped.png)

Das Beispiel bewahrt alle anderen Frame‑Werte und ersetzt nur die beiden Spiegelungs‑Einstellungen. Das ist wichtig, weil das Zuweisen eines neuen [Frame](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/set_frame/) den kompletten Frame ersetzt.

```cpp
#include <DOM/IShape.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeFrame.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto frame = shape->get_Frame();

Console::WriteLine(String::Format(u"Horizontal flip before change: {0}", frame->get_FlipH()));
Console::WriteLine(String::Format(u"Vertical flip before change: {0}", frame->get_FlipV()));

shape->set_Frame(MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y(), frame->get_Width(), frame->get_Height(), NullableBool::True, NullableBool::True, frame->get_Rotation()));

presentation->Save(u"flipped-shape.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Die gespeicherte Form ist horizontal und vertikal gespiegelt, während Position, Größe und Drehung erhalten bleiben.

![Die Form nach dem Spiegeln](flipped_shape.png)

## **FAQ**

**Soll ich einen Sammlungsindex als Formbezeichner verwenden?**

Nur für kurzlebige Vorgänge, wenn die Sammlung sich vor der Verwendung des Index nicht ändert. Bevorzugen Sie ein validiertes `Name`‑ oder `AlternativeText`‑Konzept für erstellte Vorlagen oder `OfficeInteropShapeId` für folienbezogene Interop‑Arbeiten.

**Entfernt das Ausblenden einer Form sie aus der Z‑Reihenfolge?**

Nein. Eine ausgeblendete Form bleibt in der Sammlung am selben Index. Sie kann gefunden, neu angeordnet, bearbeitet oder wieder sichtbar gemacht werden.

**Warum erschien eine geklonte Form vor einer anderen Form?**

`AddClone` fügt den Klon am Ende der Sammlung ein, was die Vorderseite der Z‑Reihenfolge ist. Verwenden Sie `InsertClone`, um den Anfangs‑Index zu wählen, oder `Reorder` nach dem Hinzufügen aller Formen.

**Kann ich einen festen Index verwenden, um eine vordefinierte Formanpassung zu identifizieren?**

Nur nach Validierung des genauen Presets und des Sammlungs‑Layouts. Bevorzugen Sie das Durchlaufen von `IGeometryShape::get_Adjustments` und das Prüfen von `IAdjustValue::get_Type`; verwenden Sie `IAdjustValue::get_Name` als zusätzliche Information, wenn derselbe semantische Typ mehr als einmal vorkommt.