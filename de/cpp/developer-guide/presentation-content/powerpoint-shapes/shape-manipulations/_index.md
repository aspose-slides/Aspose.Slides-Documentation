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
- Interop-Form-ID abrufen
- Alternativtext der Form
- Anpassungspunkt der Form
- Voreingestellte Formanpassung
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

Aspose.Slides for C++ stellt die Formen auf einer Folie als geordnete [IShapeCollection](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishapecollection/) dar. Die Sammlung ist sowohl der Ort, an dem Sie Formen finden und ändern, als auch die Quelle ihrer Stapelreihenfolge: Index `0` ist die hinterste Form, während der letzte Index die vorderste Form ist.

Dieser Artikel folgt diesem Modell. Er erklärt zuerst, wie man eine Form zuverlässig identifiziert und voreingestellte Formanpassungspunkte ändert, und zeigt dann, wie man Formen klont, entfernt, ausblendet und neu ordnet. Die letzten Abschnitte behandeln Layout‑Ebene‑Formatierung, SVG‑Export, Ausrichtung und Flip‑Einstellungen. Jeder Abschnitt ist unabhängig, sodass Sie nur die Vorgänge verwenden können, die Ihr Arbeitsablauf erfordert.

## **Formen identifizieren und finden**

Sammlungsindizes sind beim Verarbeiten einer bekannten Datei praktisch, aber sie sind keine stabilen Kennungen. Das Hinzufügen, Entfernen oder Neuordnen einer Form kann ihren Index ändern. Wählen Sie eine Kennung entsprechend der Art und Weise, wie die Präsentation erstellt und gepflegt wird:

- [Name](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/get_name/) ist nützlich für von Entwicklern gesteuerte Vorlagen und lässt sich leicht im Auswahlfenster von PowerPoint prüfen. Namen können bearbeitet werden und sind nicht garantiert eindeutig, daher sollten Sie eine Namenskonvention festlegen, wenn Code von ihnen abhängt.
- [AlternativeText](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/get_alternativetext/) ist sinnvoll, wenn eine Zugänglichkeits‑Beschreibung oder ein vom Autor bereitgestelltes Tag die Form bereits identifiziert. Es ist für Benutzer sichtbar, kann lokalisiert oder für die Barrierefreiheit umgeschrieben werden und ist nicht garantiert eindeutig. Verwenden Sie nicht stillschweigend bedeutungsvollen Barrierefreiheitstext als Datenbankschlüssel.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/get_officeinteropshapeid/) ist ein schreibgeschützter Bezeichner, der innerhalb einer Folie eindeutig ist und der von PowerPoint‑Interop verwendeten Shape‑ID entspricht. Verwenden Sie ihn, wenn Sie mit PowerPoint integrieren oder während der Lebensdauer einer Form einen eindeutigen Verweis benötigen. Eine geklonte oder neu erstellte Form ist eine andere Form und erhält ihre eigene ID.

Die zugehörige [UniqueId](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/get_uniqueid/)‑Eigenschaft hat den Geltungsbereich einer Präsentation, ist aber für Add‑ins gedacht und kann neu zugewiesen werden. Sie sollte nicht als permanenter externer Schlüssel behandelt werden. Wenn eine langfristige Identität entscheidend ist, behalten Sie die Zuordnung in Anwendungsdaten und prüfen Sie, ob die erwartete Form noch existiert.

Das folgende Beispiel sucht nach `Name` und gibt die folienspezifische Interop‑ID aus. Wenn die Vorlage nicht die erwartete Form enthält, meldet der Code dieses Ergebnis, anstatt mit dem falschen Objekt fortzufahren.

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

Wenn ein Vorgang spezifisch für einen Formtyp ist, prüfen Sie das Interface, bevor Sie typspezifische Mitglieder verwenden. Dieses Beispiel aktualisiert Text und Alternativtext nur, wenn das benannte Objekt eine [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/) ist.

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

## **Voreingestellte Formanpassungen identifizieren und ändern**

Voreingestellte Geometrieformen können Anpassungspunkte bereitstellen, die Merkmale wie Eckgröße, Pfeilproportionen oder Bogenwinkel steuern. Greifen Sie über die schreibgeschützte [IGeometryShape::get_Adjustments](https://reference.aspose.com/slides/de/cpp/aspose.slides/igeometryshape/get_adjustments/)‑Sammlung darauf zu. Die Sammlung wird von der Form bereitgestellt, aber jedes [IAdjustValue](https://reference.aspose.com/slides/de/cpp/aspose.slides/iadjustvalue/) enthält einen Wert, der geändert werden kann.

Verlassen Sie sich nicht ausschließlich auf einen festen Sammlungsindex. Durchlaufen Sie die Anpassungen und prüfen Sie die schreibgeschützte [IAdjustValue::get_Type](https://reference.aspose.com/slides/de/cpp/aspose.slides/iadjustvalue/get_type/)‑Eigenschaft, deren [ShapeAdjustmentType](https://reference.aspose.com/slides/de/cpp/aspose.slides/shapeadjustmenttype/)‑Wert beschreibt, was die Anpassung kontrolliert. Die schreibgeschützte [IAdjustValue::get_Name](https://reference.aspose.com/slides/de/cpp/aspose.slides/iadjustvalue/get_name/)‑Eigenschaft liefert zusätzliche Identifikationsinformationen und ist besonders nützlich, wenn eine Voreinstellung mehr als eine Anpassung desselben semantischen Typs enthält.

Verwenden Sie die Eigenschaft, die der Bedeutung der Anpassung entspricht:

| Anpassungstyp | Zweck | Zu ändernder Wert |
|---|---|---|
| `CornerSize` | Größe abgerundeter Ecken | [RawValue](https://reference.aspose.com/slides/de/cpp/aspose.slides/iadjustvalue/set_rawvalue/) |
| `ArrowTailThickness` | Dicke des Pfeilschafts | `RawValue` |
| `ArrowheadLength` | Länge der Pfeilspitze | `RawValue` |
| `ArrowheadWidth` | Breite der Pfeilspitze | `RawValue` |
| `StartAngle` | Startwinkel eines Kreissegments oder Bogens | [AngleValue](https://reference.aspose.com/slides/de/cpp/aspose.slides/iadjustvalue/set_anglevalue/) |
| `EndAngle` | Endwinkel eines Kreissegments oder Bogens | `AngleValue` |

`Type` und `Name` können nicht zugewiesen werden. `RawValue` ist ein les‑/schreibbarer Integer in den nativen Geometrie‑Einheiten der Voreinstellung, während `AngleValue` ein les‑/schreibbarer Winkel in Grad ist. Anzahl, Reihenfolge, Bedeutung und gültiger Bereich der Anpassungen hängen von der jeweiligen Voreinstellung [ShapeType](https://reference.aspose.com/slides/de/cpp/aspose.slides/igeometryshape/get_shapetype/) ab. Ein für eine Voreinstellung gültiger Wert kann für eine andere ungültig sein oder eine andere Wirkung haben.

Wenn `Type` `ShapeAdjustmentType::Custom` ist, erkennt die API keine standardisierte semantische Bedeutung. Prüfen Sie `Name`, den Voreinstellungs‑Typ und den vorhandenen Wert und lassen Sie die Anpassung unverändert, sofern die erwartete Bedeutung und der Bereich nicht bekannt sind. Auch bei anerkannten Typen sollte geprüft werden, ob derselbe Typ mehr als einmal vorkommt, bevor ein Wert gewählt wird. Der Artikel [Connector](/slides/de/cpp/connector/) zeigt diese Situation mit Biegeschwellen von Connectors.

Das folgende vollständige Beispiel erstellt Standard‑ und modifizierte Versionen von drei Voreinstellungsformen. Es durchläuft jede Anpassung, gibt deren `Name` und `Type` aus, ändert größenbezogene Werte über `RawValue`, ändert Winkel über `AngleValue` und speichert das Ergebnis. Die linke Spalte behält die Standardgeometrie; die rechte Spalte zeigt das angepasste abgerundete Rechteck, den vier‑weg‑Pfeil und das Kuchenstück.

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

Das Prüfen des semantischen Typs vor dem Ändern eines Werts macht den Code explizit hinsichtlich seiner Absicht und verhindert Annahmen, dass ein bestimmter Sammlungsindex dieselbe Bedeutung bei unterschiedlichen Voreinstellungsformen hat.

## **Formsammlung ändern**

Die Methoden zum Hinzufügen, Klonen, Entfernen und Neuordnen wirken sofort auf die Sammlung. Wenn ein Vorgang die Anzahl oder Reihenfolge von Formen ändert, verlassen Sie sich nicht mehr auf vor dem Vorgang erfasste Indizes.

### **Eine Form klonen**

[AddClone](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishapecollection/addclone/) erstellt eine unabhängige Kopie und fügt sie an das Ziel‑Collection‑Ende an. [InsertClone](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishapecollection/insertclone/) erzeugt ebenfalls eine Kopie, platziert sie jedoch an einem angegebenen Z‑Order‑Index. Die Überladungen, die Koordinaten akzeptieren, verschieben den Klon, ohne seine Größe zu ändern; Überladungen mit Breite und Höhe können ihn ebenfalls skalieren.

Das Beispiel erstellt eine Ziel‑Folien, klont ein beschriftetes Rechteck nach vorne und fügt einen zweiten Klon hinten ein. Änderungen an einem der Klone verändern nicht die Quellform.

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

Das Klonen kopiert den Inhalt und die Formatierung der Form, einschließlich Name und Alternativtext. Weisen Sie dem Klon neue logische Kennungen zu, wenn diese Werte eindeutig sein müssen. Ressourcen, die von komplexen Formen verwendet werden, werden von der Präsentation verwaltet, aber ein Klon bleibt ein neues Collection‑Element mit neuer Form‑Identität.

### **Formen entfernen**

[Remove](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishapecollection/remove/) löscht ein bestimmtes Form‑Objekt aus seiner Sammlung. Beim Entfernen mehrerer Treffer während einer indizierten Iteration sollte von hinten nach vorne traversiert werden, sodass jeder verbleibende Index gültig bleibt.

Dieses Beispiel entfernt jede Form mit einem festgelegten Namen. Es liest die aktuell indizierte Form, nicht ein festes Collection‑Item, und wirft die Form nicht unnötig.

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

Nach dem Entfernen ändern sich die Form‑Anzahl und die Indizes nachfolgender Formen. Verweise auf unbeeinflusste Formen bleiben zuverlässiger als gespeicherte Indizes. Berücksichtigen Sie außerdem Connectors, Animationen und andere Präsentations‑Features, die auf das entfernte Objekt verweisen könnten; das Entfernen einer sichtbaren Form kann mehr verändern als nur das Aussehen der Folie.

### **Eine Form ausblenden**

Das Setzen von [Hidden](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/set_hidden/) auf `true` lässt die Form in der Sammlung, verhindert jedoch ihr Erscheinen in der normalen Bildschirmanzeige. Ihr Index, ihre Formatierung und ihr Inhalt bleiben für Code verfügbar, sodass das Ausblenden für optionale Elemente geeignet ist, die später wiederhergestellt werden können.

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

Ausblenden ist kein Löschen oder Sicherheitsmechanismus. Das Objekt kann weiterhin entdeckt und vom Nutzer oder Code wieder eingeblendet werden und bleibt Teil der Präsentationsdatei.

### **Z‑Order ändern**

Überlappende Formen werden in der Reihenfolge der Sammlung gezeichnet. [Reorder](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishapecollection/reorder/) verschiebt eine vorhandene Form zu einem Ziel‑Index, ohne sie zu klonen. Index `0` ist hinten; `Count - 1` ist vorne.

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

Das Rechteck wird zuerst erstellt und liegt zunächst hinter der Ellipse. Das Verschieben zum letzten Index bringt es nach vorne. Finalisieren Sie die Z‑Order, nachdem Sie alle zugehörigen Formen hinzugefügt oder geklont haben, da diese Vorgänge neue Collection‑Items anhängen oder einfügen und die beabsichtigte Stapelung ändern können.

## **Formen auf Layout‑Folien prüfen**

Normale Folien, Layout‑Folien und Master‑Folien besitzen separate Form‑Sammlungen. Eine Form in einer Layout‑Collection ist nicht dasselbe Objekt wie eine ähnlich positionierte Form auf einer normalen Folie. Prüfen Sie Layout‑Formen, wenn Sie Formatierungen verstehen oder ändern müssen, die von einem Layout bereitgestellt werden.

Das folgende Beispiel liest für jede Layout‑Form das [FillFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/get_fillformat/) und das [LineFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/get_lineformat/), ohne anzunehmen, dass jede Form eine `AutoShape` ist.

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

Das Bearbeiten eines Layouts kann mehrere Folien betreffen, die es verwenden. Bevor Sie eine Layout‑Form ändern, bestimmen Sie, ob eine normale Folie das Objekt erbt oder eine lokale Überschreibung enthält, und testen Sie jede Folie, die dieses Layout nutzt.

## **Eine Form als SVG exportieren**

[WriteAsSvg](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/writeassvg/) schreibt den gerenderten Inhalt einer einzelnen Form in einen Stream. Das Ergebnis enthält nur die Form, nicht den gesamten Folienhintergrund oder benachbarte Formen.

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

Halten Sie die Präsentation während des Renderns offen. Die Ausgabe hängt von der Formatierung der Form sowie von Ressourcen wie Schriften und Bildern ab. Wenn Sie die gesamte Komposition benötigen, exportieren Sie die Folie statt einer einzelnen Form. Der Aufrufer besitzt den Stream und muss ihn schließen oder freigeben.

## **Formen ausrichten**

Die [SlideUtil::AlignShapes](https://reference.aspose.com/slides/de/cpp/aspose.slides.util/slideutil/alignshapes/)‑Überladungen richten entweder alle Formen oder ausgewählte Collection‑Indizes aus. [ShapesAlignmentType](https://reference.aspose.com/slides/de/cpp/aspose.slides/shapesalignmenttype/) legt die Kante, Mittellinie oder Verteilungsmodus fest. Setzen Sie `alignToSlide` auf `true`, um die Folienkanten zu verwenden; setzen Sie es auf `false`, um die ausgewählten Formen relativ zueinander auszurichten.

Dieses Beispiel richtet drei Formen am oberen Rand der Folie aus. Die zurückgegebenen Form‑Referenzen werden unmittelbar vor der Ausrichtung in ihre aktuellen Indizes umgewandelt.

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

Ausrichtung ändert Positionen, nicht die Z‑Order. Relative Ausrichtung erfordert normalerweise mindestens zwei Formen, während horizontale oder vertikale Verteilung genügend Formen zum Definieren des Abstands braucht. Berechnen Sie Indizes neu, wenn Sie die Collection vor dem Aufruf der Methode ändern.

## **Eine Form spiegeln**

Die Klasse [ShapeFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/shapeframe/) speichert Position, Größe, horizontale und vertikale Spiegel‑Einstellungen sowie Drehung. Ihre Werte `FlipH` und `FlipV` verwenden [NullableBool](https://reference.aspose.com/slides/de/cpp/aspose.slides/nullablebool/): `True` aktiviert die Spiegelung, `False` deaktiviert sie, und `NotDefined` bewahrt den nicht definierten/Standard‑Zustand.

Die untenstehende Eingabe‑Präsentation enthält eine nicht gespiegelte Form.

![Die Form vor dem Spiegeln](shape_to_be_flipped.png)

Das Beispiel behält alle anderen Frame‑Werte bei und ersetzt nur die beiden Spiegel‑Einstellungen. Das ist wichtig, weil das Setzen eines neuen [Frame](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/set_frame/) den gesamten Frame ersetzt.

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

Die gespeicherte Form wird horizontal und vertikal gespiegelt, während Position, Größe und Drehung erhalten bleiben.

![Die Form nach dem Spiegeln](flipped_shape.png)

## **FAQ**

**Soll ich einen Collection‑Index als Form‑Kennung verwenden?**

Nur für kurzlebige Verarbeitung, wenn die Collection vor der Nutzung des Index nicht geändert wird. Bevorzugen Sie für erstellte Vorlagen eine validierte `Name`‑ oder `AlternativeText`‑Konvention bzw. `OfficeInteropShapeId` für folienspezifische Interop‑Arbeiten.

**Entfernt das Ausblenden einer Form ihre Z‑Order?**

Nein. Eine ausgeblendete Form bleibt in der Collection am gleichen Index. Sie kann gefunden, neu geordnet, bearbeitet oder wieder sichtbar gemacht werden.

**Warum erschien eine geklonte Form vor einer anderen Form?**

`AddClone` hängt den Klon an das Ende der Collection an, was dem vorderen Teil der Z‑Order entspricht. Verwenden Sie `InsertClone`, um den Anfangs‑Index zu wählen, oder `Reorder` nach dem Hinzufügen aller Formen.

**Kann ich einen festen Index zur Identifizierung einer voreingestellten Formanpassung verwenden?**

Nur nach Validierung der genauen Voreinstellung und des Collection‑Layouts. Bevorzugen Sie das Durchlaufen von `IGeometryShape::get_Adjustments` und das Prüfen von `IAdjustValue::get_Type`; verwenden Sie `IAdjustValue::get_Name` als zusätzliche Information, wenn derselbe semantische Typ mehr als einmal vorkommt.