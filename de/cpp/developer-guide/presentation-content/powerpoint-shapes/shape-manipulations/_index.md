---
title: Verwalten von Präsentationsformen in C++
linktitle: Formenmanipulation
type: docs
weight: 40
url: /de/cpp/shape-manipulations/
keywords:
- PowerPoint-Form
- Präsentationsform
- Form auf Folie
- Form finden
- Form duplizieren
- Form entfernen
- Form ausblenden
- Reihenfolge der Form ändern
- Interop-Form-ID abrufen
- Alternativtext der Form
- Layout-Formate der Form
- Form als SVG
- Form zu SVG
- Form ausrichten
- Form spiegeln
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie Präsentationsformen mit Aspose.Slides für C++ identifizieren, duplizieren, entfernen, ausblenden, neu anordnen, exportieren, ausrichten und spiegeln."
---
## **Übersicht**

Aspose.Slides for C++ stellt die Formen auf einer Folie als geordnete [IShapeCollection](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishapecollection/). Die Sammlung ist sowohl der Ort, an dem Sie Formen finden und ändern, als auch die Quelle ihrer Stapelreihenfolge: Index `0` ist die am weitesten hinten liegende Form, während der letzte Index die vorderste Form ist.

Dieser Artikel folgt diesem Modell. Zunächst wird erklärt, wie man eine Form zuverlässig identifiziert, dann wird gezeigt, wie man Formen dupliziert, entfernt, ausblendet und neu anordnet. Die abschließenden Abschnitte behandeln Layout‑bezogene Formatierungen, den SVG‑Export, Ausrichtung und Spiegelungseinstellungen. Jedes Beispiel ist unabhängig, sodass Sie nur die Vorgänge verwenden können, die Ihr Arbeitsablauf erfordert.

## **Formen identifizieren und finden**

Sammlungsindizes sind beim Verarbeiten einer bekannten Datei praktisch, aber sie sind keine stabilen Bezeichner. Das Hinzufügen, Entfernen oder Neuordnen einer Form kann ihren Index ändern. Wählen Sie einen Bezeichner entsprechend der Art und Weise, wie die Präsentation erstellt und gepflegt wird:

- [Name](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/get_name/) ist nützlich für von Entwicklern gesteuerte Vorlagen und lässt sich leicht im Auswahlbereich von PowerPoint inspizieren. Namen können bearbeitet werden und sind nicht garantiert eindeutig, daher sollte ein Namenskonventionsschema festgelegt werden, wenn Code von ihnen abhängt.
- [AlternativeText](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/get_alternativetext/) ist nützlich, wenn eine Zugänglichkeitsbeschreibung oder ein vom Autor bereitgestelltes Tag die Form bereits identifiziert. Sie ist für Benutzer sichtbar, kann lokalisiert oder für Barrierefreiheit umgeschrieben werden und ist nicht garantiert eindeutig. Verwenden Sie bedeutungsvollen Barrierefreiheitstext nicht stillschweigend als Datenbankschlüssel.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/get_officeinteropshapeid/) ist ein schreibgeschützter Bezeichner, der innerhalb einer Folie eindeutig ist und der von PowerPoint‑Interop verwendeten Form‑ID entspricht. Verwenden Sie ihn, wenn Sie mit PowerPoint integrieren oder eine eindeutige Referenz während der Lebensdauer einer Form benötigen. Eine duplizierte oder neu erstellte Form ist eine andere Form und erhält ihre eigene ID.

Die zugehörige Eigenschaft [UniqueId](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/get_uniqueid/) gilt für die gesamte Präsentation, ist jedoch für Add‑Ins gedacht und kann neu zugewiesen werden. Sie sollte nicht als permanenter externer Schlüssel verwendet werden. Wenn eine langfristige Identität entscheidend ist, bewahren Sie die Zuordnung in Anwendungsdaten auf und prüfen Sie, ob die erwartete Form noch existiert.

Das folgende Beispiel sucht nach `Name` und gibt die Folien‑bezogene Interop‑ID zurück. Wenn die Vorlage die erwartete Form nicht enthält, gibt der Code dieses Ergebnis aus, anstatt mit dem falschen Objekt fortzufahren.

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

Wenn ein Vorgang spezifisch für einen Formtyp ist, prüfen Sie die Schnittstelle, bevor Sie typspezifische Member verwenden. Dieses Beispiel aktualisiert Text und Alternativtext nur, wenn das benannte Objekt ein [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/) ist.

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

## **Formensammlung ändern**

Die Methoden zum Hinzufügen, Duplizieren, Entfernen und Neuordnen wirken sofort auf die Sammlung. Wenn ein Vorgang die Anzahl oder Reihenfolge von Formen ändert, sollten Sie nicht weiter auf vorher ermittelte Indizes vertrauen.

### **Form duplizieren**

[AddClone](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishapecollection/addclone/) erstellt eine unabhängige Kopie und fügt sie an das Ziel‑Collection hinzu. [InsertClone](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishapecollection/insertclone/) erstellt ebenfalls eine Kopie, platziert sie jedoch an einem angegebenen Z‑Order‑Index. Die Überladungen, die Koordinaten akzeptieren, verschieben die Kopie, ohne ihre Größe zu ändern; Überladungen mit Breite und Höhe können sie zudem skalieren.

Das Beispiel erstellt eine Ziel‑Folien, dupliziert ein beschriftetes Rechteck nach vorne und fügt eine zweite Kopie hinten ein. Änderungen an einer der Kopien verändern nicht die Quellform.

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

Das Duplizieren kopiert den Inhalt und die Formatierung der Form, einschließlich ihres Namens und Alternativtexts. Weisen Sie der Kopie neue logische Bezeichner zu, wenn diese Werte eindeutig sein müssen. Ressourcen, die von komplexen Formen verwendet werden, werden von der Präsentation verwaltet, aber eine Kopie bleibt ein neues Collection‑Element mit einer neuen Formidentität.

### **Formen entfernen**

[Remove](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishapecollection/remove/) löscht ein bestimmtes Formobjekt aus seiner Sammlung. Beim Entfernen mehrerer Treffer während einer indizierten Iteration sollten Sie von hinten nach vorne durchlaufen, damit jeder verbleibende Index gültig bleibt.

Dieses Beispiel entfernt jede Form mit einem festgelegten Namen. Es liest die aktuell indizierte Form, nicht ein festes Collection‑Element, und wirft die Form nicht unnötig um.

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

Nach dem Entfernen ändern sich die Formanzahl und die Indizes nachfolgender Formen. Verweise auf unveränderte Formen bleiben zuverlässiger als gespeicherte Indizes. Berücksichtigen Sie außerdem Verbinder, Animationen und andere Präsentations‑Features, die sich auf das entfernte Objekt beziehen können; das Entfernen einer sichtbaren Form kann mehr als nur das Aussehen der Folie verändern.

### **Form ausblenden**

Setzt man [Hidden](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/set_hidden/) auf `true`, bleibt die Form in der Sammlung, wird jedoch nicht in der normalen Diashow angezeigt. Ihr Index, ihre Formatierung und ihr Inhalt bleiben für den Code verfügbar, sodass das Ausblenden für optionale Elemente geeignet ist, die später wiederhergestellt werden können.

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

Ausblenden ist weder Löschen noch Sicherheit. Das Objekt kann weiterhin von einem Benutzer oder vom Code entdeckt und wieder eingeblendet werden und bleibt Teil der Präsentationsdatei.

### **Z‑Reihenfolge ändern**

Überlappende Formen werden in der Reihenfolge der Sammlung gezeichnet. [Reorder](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishapecollection/reorder/) verschiebt eine vorhandene Form zu einem Ziel‑Index, ohne sie zu duplizieren. Index `0` ist hinten; `Count - 1` ist vorne.

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

Das Rechteck wird zuerst erstellt und liegt zunächst hinter der Ellipse. Das Verschieben auf den End‑Index bringt es nach vorne. Finalisieren Sie die Z‑Reihenfolge, nachdem alle zugehörigen Formen hinzugefügt oder dupliziert wurden, da diese Vorgänge neue Collection‑Elemente anhängen oder einfügen und den beabsichtigten Stapel verändern können.

## **Formen auf Layout‑Folien untersuchen**

Normale Folien, Layout‑Folien und Master‑Folien besitzen separate Form‑Sammlungen. Eine Form in einer Layout‑Sammlung ist nicht dasselbe Objekt wie eine ähnlich positionierte Form auf einer normalen Folie. Untersuchen Sie Layout‑Formen, wenn Sie die von einem Layout bereitgestellte Formatierung verstehen oder ändern müssen.

Das folgende Beispiel liest für jede Layout‑Form das [FillFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/get_fillformat/) und [LineFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/get_lineformat/), ohne anzunehmen, dass jede Form ein `AutoShape` ist.

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

Das Bearbeiten eines Layouts kann mehrere Folien, die es verwenden, beeinflussen. Bevor Sie eine Layout‑Form ändern, prüfen Sie, ob eine normale Folie das Objekt erbt oder eine lokale Überschreibung enthält, und testen Sie jede Folie, die dieses Layout verwendet.

## **Eine Form als SVG exportieren**

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

Halten Sie die Präsentation während des Renderns geöffnet. Die Ausgabe hängt von der Formatierung der Form sowie von Ressourcen wie Schriftarten und Bildern ab. Wenn Sie die gesamte Komposition benötigen, exportieren Sie die Folie statt einer einzelnen Form. Der Aufrufer besitzt den Stream und muss ihn schließen oder freigeben.

## **Formen ausrichten**

Die Überladungen von [SlideUtil::AlignShapes](https://reference.aspose.com/slides/de/cpp/aspose.slides.util/slideutil/alignshapes/) richten entweder alle Formen oder ausgewählte Collection‑Indizes aus. [ShapesAlignmentType](https://reference.aspose.com/slides/de/cpp/aspose.slides/shapesalignmenttype/) gibt die Kante, Mittelachse oder den Verteilungsmodus an. Setzen Sie `alignToSlide` auf `true`, um die Folienkanten zu verwenden; setzen Sie es auf `false`, um die ausgewählten Formen relativ zueinander auszurichten.

Dieses Beispiel richtet drei Formen an der oberen Kante der Folie aus. Die zurückgegebenen Formreferenzen werden unmittelbar vor der Ausrichtung in ihre aktuellen Indizes umgewandelt.

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

Die Ausrichtung ändert Positionen, nicht die Z‑Reihenfolge. Relative Ausrichtung erfordert normalerweise mindestens zwei Formen, während horizontale oder vertikale Verteilung genügend Formen zum Definieren von Abständen benötigt. Berechnen Sie die Indizes neu, wenn Sie die Collection vor dem Aufruf der Methode ändern.

## **Form spiegeln**

Die Klasse [ShapeFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/shapeframe/) speichert Position, Größe, horizontale und vertikale Spiegel‑Einstellungen sowie Drehung. Ihre Werte `FlipH` und `FlipV` verwenden [NullableBool](https://reference.aspose.com/slides/de/cpp/aspose.slides/nullablebool/): `True` aktiviert die Spiegelung, `False` deaktiviert sie, und `NotDefined` behält den nicht angegebenen/Standardzustand bei.

Die unten gezeigte Eingabe‑Präsentation enthält eine nicht gespiegelte Form.

![Die Form vor dem Spiegeln](shape_to_be_flipped.png)

Das Beispiel bewahrt alle anderen Frame‑Werte und ersetzt nur die beiden Spiegel‑Einstellungen. Das ist wichtig, weil das Zuweisen eines neuen [Frame](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/set_frame/) den gesamten Frame ersetzt.

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

**Sollte ich einen Sammlungsindex als Form‑Bezeichner verwenden?**

Nur für kurzlebige Verarbeitungen, bei denen sich die Sammlung nicht ändert, bevor der Index verwendet wird. Bevorzugen Sie eine validierte `Name`‑ oder `AlternativeText`‑Konvention für erstellte Vorlagen oder `OfficeInteropShapeId` für folienbezogene Interop‑Arbeiten.

**Entfernt das Ausblenden einer Form sie aus der Z‑Reihenfolge?**

Nein. Eine ausgeblendete Form bleibt in der Sammlung am selben Index. Sie kann gefunden, neu angeordnet, bearbeitet oder wieder sichtbar gemacht werden.

**Warum erschien eine duplizierte Form vor einer anderen Form?**

`AddClone` fügt die Kopie am Ende der Sammlung hinzu, was dem vorderen Teil der Z‑Reihenfolge entspricht. Verwenden Sie `InsertClone`, um den Anfangs‑Index zu wählen, oder `Reorder`, nachdem alle Formen hinzugefügt wurden.