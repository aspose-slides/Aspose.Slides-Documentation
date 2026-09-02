---
title: Effectieve vormeigenschappen ophalen uit presentaties in C++
linktitle: Effectieve eigenschappen
type: docs
weight: 50
url: /nl/cpp/shape-effective-properties/
keywords:
- vormeigenschappen
- camera-eigenschappen
- lichtrig
- schuine rand vorm
- tekstframe
- tekststijl
- letterhoogte
- vulformaat
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe u Aspose.Slides voor C++ kunt gebruiken om lokale, geërfde en effectieve vormopmaak te onderscheiden in PowerPoint-presentaties."
---
## **Begrijp lokale, geërfde en effectieve eigenschappen**

PowerPoint-opmaak kan uit verschillende bronnen komen. De waarde die rechtstreeks op een object wordt opgeslagen is zijn **lokale waarde**. Als die waarde niet is ingesteld, kijkt PowerPoint naar de opmaakbronnen van de bovenliggende objecten, zoals een alinea‑standaard, een tekststijl, een lay‑out of masterdia, een thema, of standaardinstellingen op presentatieniveau. Die waarden zijn **geërfde waarden**. De waarde die overblijft nadat de volledige hiërarchie is opgelost, is de **effectieve waarde** — de waarde die wordt gebruikt om het object weer te geven.

Bijvoorbeeld, een tekstdelen kan zijn eigen lettergrootte niet definiëren. Zijn lokale [letterhoogte](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibaseportionformat/) is dan `std::numeric_limits<float>::quiet_NaN()`, wat betekent "niet hier ingesteld". Het deel kan een hoogte erven van zijn alinea, de standaardtekststijl van de presentatie, of een andere toepasselijke bron. Het aanroepen van [GetEffective](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iportionformat/) op het deel‑format geeft de uiteindelijk opgeloste hoogte terug.

Gebruik de twee soorten opmaakdata voor verschillende doeleinden:

- Lees of wijzig een lokaal opmaakobject, zoals [IPortionFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iportionformat/), wanneer je moet bepalen waar een waarde is gedefinieerd.
- Lees een effectief data‑object, zoals [IPortionFormatEffectiveData](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iportionformateffectivedata/), wanneer je het uiteindelijke, gerenderde resultaat nodig hebt. Effectieve data is alleen‑lezen.

## **Vergelijk lokale, geërfde en effectieve waarden**

Het volgende volledige voorbeeld maakt een vorm aan en past letterhoogtes toe op presentatie‑, alinea‑ en deel‑niveau. Elke stap drukt de op die niveaus gedefinieerde waarden af en de resulterende effectieve waarde voor hetzelfde tekstdelen. Het laat ook zien waarom effectieve data opnieuw moet worden gelezen na opmaakwijzigingen.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <cmath>
#include <limits>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 500.0f, 80.0f, false);
auto textFrame = shape->AddTextFrame(u"Effective formatting");
auto paragraph = textFrame->get_Paragraph(0);
auto portion = paragraph->get_Portion(0);

// Definieer geërfde waarden op twee verschillende niveaus.
presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->set_FontHeight(20.0f);
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(28.0f);

auto formatLocalValue = [](float value) -> System::String
{
    return std::isnan(value) ? System::String(u"<not set>") : System::ObjectExt::ToString(value);
};

auto printFontHeights = [&](System::String caption)
{
    auto presentationValue = presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->get_FontHeight();
    auto paragraphValue = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FontHeight();
    auto localValue = portion->get_PortionFormat()->get_FontHeight();

    // Lees effectieve data na de voorgaande wijzigingen.
    auto effectiveValue = portion->get_PortionFormat()->GetEffective()->get_FontHeight();

    System::Console::WriteLine(caption);
    System::Console::WriteLine(System::String(u"  Presentation default: ") + formatLocalValue(presentationValue));
    System::Console::WriteLine(System::String(u"  Paragraph default:    ") + formatLocalValue(paragraphValue));
    System::Console::WriteLine(System::String(u"  Portion local:        ") + formatLocalValue(localValue));
    System::Console::WriteLine(System::String(u"  Portion effective:    ") + effectiveValue);
};

printFontHeights(u"The portion inherits from the paragraph");

// Een lokale waarde op het deel overschrijft beide geërfde waarden.
portion->get_PortionFormat()->set_FontHeight(36.0f);
printFontHeights(u"A local value overrides inherited values");

// Het wijzigen van een geërfde waarde overschrijft geen bestaande lokale waarde.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(30.0f);
printFontHeights(u"The local value still has priority");

// Wis de lokale waarde. Het deel erft nu opnieuw van de alinea.
portion->get_PortionFormat()->set_FontHeight(std::numeric_limits<float>::quiet_NaN());
printFontHeights(u"The local value is cleared");

// Wis de alinea‑waarde. De presentatiestandaard levert nu het resultaat.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(std::numeric_limits<float>::quiet_NaN());
printFontHeights(u"The paragraph value is cleared");

presentation->Save(u"effective-properties.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

De prioriteit in dit voorbeeld is eerst lokale opmaak van het deel, daarna alinea‑opmaak, en daarna de standaard van de presentatie. Andere objecten kunnen verschillende erfenisketens hebben, maar het principe is hetzelfde: een meer specifieke expliciete waarde heeft voorrang, en [GetEffective](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iportionformat/) geeft het uiteindelijke resultaat terug.

## **Haal effectieve tekst‑eigenschappen op**

Tekstopmaak is verdeeld over verschillende objecten:

- [ITextFrameFormat::GetEffective](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframeformat/) lost tekst‑frame‑eigenschappen op zoals marges, verankering, autofit en verticale tekstrichting.
- [ITextStyle::GetEffective](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextstyle/) lost alinea‑opmaak op voor elk tekststijlniveau.
- [IParagraphFormat::GetEffective](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/) lost alinea‑eigenschappen op zoals uitlijning, inspringing en opsommingstekens.
- [IPortionFormat::GetEffective](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iportionformat/) lost teken‑eigenschappen op zoals letterhoogte, lettertype, kleur, vet en cursief.

Voor het volgende voorbeeld moet `text-formatting.pptx` minstens één dia en één [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) bevatten met een niet‑lege tekst‑frame. De IAutoShape kan zich op elke positie in de vormcollectie bevinden; de code zoekt naar een geschikt object en valideert dit vóór gebruik.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/ITextStyle.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"text-formatting.pptx");

if (presentation->get_Slides()->get_Count() == 0)
    throw System::InvalidOperationException(u"The presentation contains no slides.");

auto slide = presentation->get_Slide(0);
System::SharedPtr<IAutoShape> shape;

for (int shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
{
    auto candidate = slide->get_Shapes()->idx_get(shapeIndex);

    if (!System::ObjectExt::Is<IAutoShape>(candidate))
        continue;

    auto autoShape = System::ExplicitCast<IAutoShape>(candidate);
    auto candidateTextFrame = autoShape->get_TextFrame();

    if (candidateTextFrame == nullptr || candidateTextFrame->get_Paragraphs()->get_Count() == 0)
        continue;

    if (candidateTextFrame->get_Paragraph(0)->get_Portions()->get_Count() == 0)
        continue;

    shape = autoShape;
    break;
}

if (shape == nullptr)
    throw System::InvalidOperationException(u"The first slide must contain an IAutoShape with non-empty text.");

auto textFrame = shape->get_TextFrame();
auto paragraph = textFrame->get_Paragraph(0);
auto portion = paragraph->get_Portion(0);

auto textFrameEffective = textFrame->get_TextFrameFormat()->GetEffective();
auto paragraphEffective = paragraph->get_ParagraphFormat()->GetEffective();
auto portionEffective = portion->get_PortionFormat()->GetEffective();

System::Console::WriteLine(u"Text frame margins:");
System::Console::WriteLine(System::String(u"  Left: ") + textFrameEffective->get_MarginLeft());
System::Console::WriteLine(System::String(u"  Top: ") + textFrameEffective->get_MarginTop());
System::Console::WriteLine(System::String(u"  Right: ") + textFrameEffective->get_MarginRight());
System::Console::WriteLine(System::String(u"  Bottom: ") + textFrameEffective->get_MarginBottom());
System::Console::WriteLine(System::String(u"Paragraph alignment: ") + System::ObjectExt::ToString(paragraphEffective->get_Alignment()));
System::Console::WriteLine(System::String(u"Font height: ") + portionEffective->get_FontHeight());
System::Console::WriteLine(System::String(u"Bold: ") + System::ObjectExt::ToString(portionEffective->get_FontBold()));

auto effectiveTextStyle = textFrame->get_TextFrameFormat()->get_TextStyle()->GetEffective();
for (int level = 0; level < 9; ++level)
{
    auto levelEffective = effectiveTextStyle->GetLevel(level);
    System::Console::WriteLine(System::String(u"Level ") + level + u" indent: " + levelEffective->get_Indent());
}

presentation->Dispose();
```

## **Haal effectieve 3D‑eigenschappen op**

[IThreeDFormat::GetEffective](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformat/) retourneert één [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ithreedformateffectivedata/) object dat alle opgeloste 3D‑instellingen groepeert. De [camera](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icameraeffectivedata/), [licht‑rig](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilightrigeffectivedata/), [boven‑schuine rand](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishapebeveleffectivedata/) en [onder‑schuine rand](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishapebeveleffectivedata/) gegevens tonen de overeenkomstige effectieve instellingen. Het gezamenlijk lezen van deze gerelateerde instellingen maakt het makkelijker om het uiteindelijke 3D‑uiterlijk van een vorm te begrijpen.

Voor dit voorbeeld moet `shape-3d.pptx` minstens één vorm op de eerste dia bevatten. Pas 3D‑camera-, verlichtings‑ of schuine‑rand‑instellingen toe op die vorm als je wilt dat de output waarden bevat die afwijken van de standaardwaarden.

```cpp
#include <DOM/ICameraEffectiveData.h>
#include <DOM/ILightRigEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/IShapeBevelEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/IThreeDFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"shape-3d.pptx");

if (presentation->get_Slides()->get_Count() == 0 || presentation->get_Slide(0)->get_Shapes()->get_Count() == 0)
    throw System::InvalidOperationException(u"The first slide must contain a shape.");

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto threeDEffective = shape->get_ThreeDFormat()->GetEffective();

System::Console::WriteLine(u"Camera:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_Camera()->get_CameraType()));
System::Console::WriteLine(System::String(u"  Field of view: ") + threeDEffective->get_Camera()->get_FieldOfViewAngle());
System::Console::WriteLine(System::String(u"  Zoom: ") + threeDEffective->get_Camera()->get_Zoom());

System::Console::WriteLine(u"Light rig:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_LightRig()->get_LightType()));
System::Console::WriteLine(System::String(u"  Direction: ") + System::ObjectExt::ToString(threeDEffective->get_LightRig()->get_Direction()));

System::Console::WriteLine(u"Top bevel:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_BevelTop()->get_BevelType()));
System::Console::WriteLine(System::String(u"  Width: ") + threeDEffective->get_BevelTop()->get_Width());
System::Console::WriteLine(System::String(u"  Height: ") + threeDEffective->get_BevelTop()->get_Height());

presentation->Dispose();
```

## **Haal effectieve tabelopmaak op**

Tabelopmaak kan afkomstig zijn van de tabelstijl en van opmaak die wordt toegepast op de hele tabel, een kolom, een rij of een individuele cel. Bij conflicten tussen expliciet gedefinieerde vullingen is de prioriteit cel, rij, kolom en daarna de hele tabel. De effectieve opmaak van een cel is de uiteindelijke opmaak die wordt gebruikt om die cel te tekenen.

Voor dit voorbeeld moet `table-formatting.pptx` minstens één tabel op de eerste dia bevatten. De tabel moet minstens één rij en één kolom hebben. De code zoekt naar een [ITable](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itable/) in plaats van ervan uit te gaan dat de eerste vorm een tabel is.

```cpp
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IColumn.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/Table/IColumnFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IRowFormat.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ITableFormat.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"table-formatting.pptx");

if (presentation->get_Slides()->get_Count() == 0)
    throw System::InvalidOperationException(u"The presentation contains no slides.");

auto slide = presentation->get_Slide(0);
System::SharedPtr<ITable> table;

for (int shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
{
    auto candidate = slide->get_Shapes()->idx_get(shapeIndex);

    if (System::ObjectExt::Is<ITable>(candidate))
    {
        table = System::ExplicitCast<ITable>(candidate);
        break;
    }
}

if (table == nullptr)
    throw System::InvalidOperationException(u"The first slide must contain a table.");

if (table->get_Rows()->get_Count() == 0 || table->get_Columns()->get_Count() == 0)
    throw System::InvalidOperationException(u"The table must contain at least one cell.");

auto tableEffective = table->get_TableFormat()->GetEffective();
auto rowEffective = table->get_Row(0)->get_RowFormat()->GetEffective();
auto columnEffective = table->get_Column(0)->get_ColumnFormat()->GetEffective();
auto cellEffective = table->idx_get(0, 0)->get_CellFormat()->GetEffective();

System::Console::WriteLine(System::String(u"Table fill: ") + System::ObjectExt::ToString(tableEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Row fill: ") + System::ObjectExt::ToString(rowEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Column fill: ") + System::ObjectExt::ToString(columnEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Final cell fill: ") + System::ObjectExt::ToString(cellEffective->get_FillFormat()->get_FillType()));

presentation->Dispose();
```

Als je de kleur nodig hebt in plaats van alleen het vultype, controleer dan eerst de effectieve [FillType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ifillformateffectivedata/), en lees vervolgens de eigenschap die bij dat type hoort — bijvoorbeeld [SolidFillColor](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ifillformateffectivedata/) voor een effen vulling.

## **Lees effectieve data opnieuw na wijzigingen**

Effectieve data beschrijft de opmaakhiërarchie op het moment dat deze wordt opgelost. Roep `GetEffective` opnieuw aan nadat je iets hebt gewijzigd dat aan die hiërarchie kan deelnemen, inclusief:

- de lokale opmaak van het object;
- alinea‑ of tekst‑frame‑standaardinstellingen;
- een tabel‑stijl, tabel, kolom, rij of cel‑opmaak;
- lay‑out‑ of master‑dia‑opmaak;
- themagegevens of standaardinstellingen op presentatieniveau;
- de lay‑out of master die aan een dia is toegewezen.

Bewaar een effectief data‑object niet als een permanente snapshot. Aspose.Slides kan sommige effectieve data intern cachen, en een latere `GetEffective`‑aanroep kan die data vernieuwen. Als je waarden vóór en na een wijziging moet vergelijken, kopieer dan de scalare waarden die je nodig hebt — zoals een letterhoogte, kleur, uitlijning of schuine‑rand‑breedte — naar je eigen variabelen voordat je de wijziging uitvoert.

Om een waarde te wijzigen, werk je het juiste lokale opmaakobject bij en roep je vervolgens `GetEffective` aan om het resultaat te verifiëren. Effectieve data‑objecten zelf zijn alleen‑lezen.

## **FAQ**

**Hoe kan ik zien welk niveau een effectieve waarde heeft geleverd?**

Effectieve data bevat de uiteindelijke waarde, niet de bron ervan. Inspecteer de toepasselijke lokale objecten van het meest specifieke niveau naar buiten. Voor tekst kan dit het deel, de alinea, het tekst‑frame, de lay‑out, de master, het thema en de standaardinstellingen van de presentatie omvatten. Niet‑gedefinieerde waarden zoals `std::numeric_limits<float>::quiet_NaN()` of `nullptr` geven aan dat de zoektocht doorgaat naar een ander niveau.

**Wat gebeurt er als geen niveau een eigenschap definieert?**

Aspose.Slides lost de juiste PowerPoint‑ of bibliotheek‑standaard op. Die opgeloste waarde verschijnt in de effectieve data, zelfs al definieert geen lokaal object deze expliciet.

**Waarom is een effectieve waarde soms gelijk aan de lokale waarde?**

De lokale waarde heeft de erfenisberekening gewonnen. Dit is te verwachten wanneer de eigenschap expliciet op het object is ingesteld en geen specifiekere regel deze overschrijft.

**Wanneer moet ik lokale data gebruiken in plaats van effectieve data?**

Gebruik lokale data om een specifiek opmaakniveau te inspecteren of te bewerken. Gebruik effectieve data wanneer je de uiteindelijke weergave nodig hebt na erfenis, themaregels en toepasselijke stijlen. Het [volledige vergelijkingsvoorbeeld](#compare-local-inherited-and-effective-values) toont beide in dezelfde workflow.