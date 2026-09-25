---
title: Beheer presentatie‑vormen in C++
linktitle: Vormmanipulatie
type: docs
weight: 40
url: /nl/cpp/shape-manipulations/
keywords:
- PowerPoint‑vorm
- presentatievorm
- vorm op dia
- vorm vinden
- vorm klonen
- vorm verwijderen
- vorm verbergen
- vormvolgorde wijzigen
- interop‑vorm‑ID ophalen
- alternatieve tekst van vorm
- aanpassingspunt van vorm
- vormaanpassing van preset
- vormgeometrie
- vorm‑lay-outformaten
- vorm als SVG
- vorm naar SVG
- vorm uitlijnen
- vorm spiegelen
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe u presentatie‑vormen kunt identificeren, aanpassen, klonen, verwijderen, verbergen, herschikken, exporteren, uitlijnen en spiegelen met Aspose.Slides voor C++."
---
## **Overzicht**

Aspose.Slides voor C++ stelt de vormen op een dia voor als een geordende [IShapeCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishapecollection/). De collectie is zowel de plaats waar je vormen vindt en wijzigt als de bron van hun stapelvolgorde: index `0` is de verste achterste vorm, terwijl de laatste index de voorste vorm is.

Dit artikel volgt dat model. Het legt eerst uit hoe je een vorm betrouwbaar kunt identificeren en preset‑aanpassingspunten van een vorm kunt wijzigen, en laat vervolgens zien hoe je vormen kunt klonen, verwijderen, verbergen en herschikken. De laatste secties behandelen formattering op lay-outniveau, SVG-export, uitlijning en spiegelinstellingen. Elk voorbeeld staat op zichzelf, zodat je alleen de bewerkingen kunt gebruiken die jouw workflow vereist.

## **Identificeren en vinden van vormen**

Collectie‑indexen zijn handig bij het verwerken van een bekend bestand, maar ze zijn geen stabiele identifier. Het toevoegen, verwijderen of herschikken van een vorm kan de index wijzigen. Kies een identifier op basis van hoe de presentatie is gemaakt en onderhouden:

- [Name](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/get_name/) is bruikbaar voor door ontwikkelaars beheerde sjablonen en is gemakkelijk te inspecteren in het selectiepaneel van PowerPoint. Namen kunnen worden bewerkt en zijn niet gegarandeerd uniek, dus stel een naamgevingsconventie in als code ervan afhankelijk is.
- [AlternativeText](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/get_alternativetext/) is nuttig wanneer een toegankelijkheidsbeschrijving of een door de auteur toegevoegde tag de vorm al identificeert. Het is zichtbaar voor gebruikers, kan worden gelokaliseerd of herschreven voor toegankelijkheid, en is niet gegarandeerd uniek. Gebruik geen betekenisvolle toegankelijkheidstekst stilletjes als databasesleutel.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/get_officeinteropshapeid/) is een alleen‑lezen identifier die uniek is binnen een dia en overeenkomt met de vorm‑ID die PowerPoint‑interop gebruikt. Gebruik deze bij integratie met PowerPoint of wanneer je een ondubbelzinnige referentie nodig hebt gedurende de levensduur van een vorm. Een gekloonde of opnieuw gecreëerde vorm is een andere vorm en krijgt een eigen ID.

De gerelateerde [UniqueId](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/get_uniqueid/)‑eigenschap heeft een presentatie‑scope, maar is bedoeld voor add‑ins en kan worden herkend. Deze moet niet worden behandeld als een permanente externe sleutel. Als een langdurige identiteit cruciaal is, bewaar de koppeling in applicatie‑data en valideer dat de verwachte vorm nog steeds bestaat.

Voor een praktisch voorbeeld van het lezen en bijwerken van zowel de alternatieve‑tekst‑titel als de beschrijving, zie [Manage Alternative Text Titles and Descriptions](/slides/nl/cpp/presentation-accessibility/). Gebruik alternatieve tekst om de betekenis van het visuele element uit te leggen aan lezers, en houd het gescheiden van de vormnamen die door code worden gebruikt om vormen te vinden.

Het volgende voorbeeld zoekt op `Name` en rapporteert de dia‑specifieke interop‑ID. Wanneer de sjabloon de verwachte vorm niet bevat, geeft de code dat resultaat terug in plaats van door te gaan met het verkeerde object.

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

Wanneer een bewerking specifiek is voor een bepaald vormtype, controleer dan de interface voordat je type‑specifieke leden gebruikt. Dit voorbeeld werkt tekst en alternatieve tekst bij alleen als het benoemde object een [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) is.

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

## **Identificeren en aanpassen van preset‑vormaanpassingen**

Preset‑geomatrie‑vormen kunnen aanpassingspunten blootleggen die eigenschappen als hoekgrootte, pijlpauwen of booghoeken regelen. Benader ze via de alleen‑lezen [IGeometryShape::get_Adjustments](https://reference.aspose.com/slides/nl/cpp/aspose.slides/igeometryshape/get_adjustments/)‑collectie. De collectie zelf wordt geleverd door de vorm, maar elk [IAdjustValue](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iadjustvalue/) bevat een waarde die kan worden gewijzigd.

Betrek niet uitsluitend een vaste collectie‑index. Loop door de aanpassingen en inspecteer de alleen‑lezen [IAdjustValue::get_Type](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iadjustvalue/get_type/)‑eigenschap, waarvan de [ShapeAdjustmentType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/shapeadjustmenttype/)‑waarde beschrijft wat de aanpassing regelt. De alleen‑lezen [IAdjustValue::get_Name](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iadjustvalue/get_name/)‑eigenschap biedt extra identificatie‑informatie en is vooral nuttig wanneer een preset meer dan één aanpassing met hetzelfde semantische type bevat.

Gebruik de waarde‑eigenschap die overeenkomt met de betekenis van de aanpassing:

| Aanpassingstype | Doel | Waarde om te wijzigen |
|---|---|---|
| `CornerSize` | Grootte van afgeronde hoeken | [RawValue](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iadjustvalue/set_rawvalue/) |
| `ArrowTailThickness` | Dikte van een pijlpoot | `RawValue` |
| `ArrowheadLength` | Lengte van een pijlpunt | `RawValue` |
| `ArrowheadWidth` | Breedte van een pijlpunt | `RawValue` |
| `StartAngle` | Starthoek van een taart- of boogstuk | [AngleValue](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iadjustvalue/set_anglevalue/) |
| `EndAngle` | Eindhoek van een taart- of boogstuk | `AngleValue` |

`Type` en `Name` kunnen niet worden toegewezen. `RawValue` is een lees‑/schrijf‑integer in de native eenheden van de preset‑geomatrie, terwijl `AngleValue` een lees‑/schrijf‑hoek in graden is. Het aantal, de volgorde, de betekenis en het geldige bereik van aanpassingen hangen af van het preset‑[ShapeType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/igeometryshape/get_shapetype/). Een waarde die geldig is voor één preset kan ongeldig of met een ander effect zijn voor een andere.

Wanneer `Type` `ShapeAdjustmentType::Custom` is, herkent de API geen standaard semantische betekenis. Inspecteer `Name`, het preset‑type en de bestaande waarde, en laat de aanpassing ongewijzigd als de verwachte betekenis en het bereik niet bekend zijn. Zelfs voor herkende types, controleer of hetzelfde type meer dan eens voorkomt voordat je een waarde selecteert. Het artikel [Connector](/slides/nl/cpp/connector/) laat deze situatie zien met buig‑aanpassingen van connectoren.

Het volgende volledige voorbeeld maakt standaard‑ en gewijzigde versies van drie preset‑vormen. Het doorloopt elke aanpassing, rapporteert `Name` en `Type`, wijzigt grootte‑gerelateerde waarden via `RawValue`, wijzigt hoeken via `AngleValue`, en slaat het resultaat op. De linkerkolom behoudt de standaardgeomatrie; de rechterkolom toont het aangepaste afgeronde rechthoek, de vier‑weg‑pijl en de taart.

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

// Voegt kopteksten toe voor de standaard- en aangepaste vormkolommen.
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

De semantische type controleren voordat je een waarde wijzigt, maakt de code expliciet in zijn bedoeling en voorkomt het aannemen dat een bepaalde collectie‑index dezelfde betekenis heeft bij verschillende preset‑vormen.

## **De vormcollectie aanpassen**

De methoden toevoegen, klonen, verwijderen en herschikken werken direct op de collectie. Als een bewerking het aantal of de volgorde van vormen wijzigt, vertrouw dan niet op indexen die vóór die bewerking zijn vastgelegd.

### **Een vorm klonen**

[AddClone](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishapecollection/addclone/) maakt een onafhankelijke kopie en voegt deze toe aan de doelcollectie. [InsertClone](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishapecollection/insertclone/) maakt ook een kopie, maar plaatst deze op een opgegeven z‑order‑index. De overloads die coördinaten accepteren verplaatsen de kloon zonder de grootte te wijzigen; overloads met breedte en hoogte kunnen deze ook aanpassen.

Het voorbeeld maakt een doel‑dia, kloont een gelabelde rechthoek naar de voorgrond en voegt een tweede kloon toe aan de achtergrond. Wijzigingen aan één van de klonen wijzigen de bronvorm niet.

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

Klonen kopieert de inhoud en opmaak van de vorm, inclusief naam en alternatieve tekst. Ken nieuwe logische identifiers toe aan de kloon wanneer die waarden uniek moeten zijn. Bronnen die door complexe vormen worden gebruikt, worden beheerd door de presentatie, maar een kloon blijft een nieuw collectie‑item met een nieuwe vorm‑identiteit.

### **Vormen verwijderen**

[Remove](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishapecollection/remove/) verwijdert een specifiek vormobject uit zijn collectie. Bij het verwijderen van meerdere overeenkomsten tijdens een geïndexeerde iteratie, loop van het einde zodat elke resterende index geldig blijft.

Dit voorbeeld verwijdert elke vorm met een aangewezen naam. Het leest de huidige geïndexeerde vorm, niet een vaste collectie‑item, en gooit de vorm niet onnodig om naar een andere interface.

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

Na het verwijderen veranderen het aantal vormen en de indexen van latere vormen. Verwijzingen naar onaangetaste vormen blijven betrouwbaarder dan opgeslagen indexen. Houd ook rekening met connectoren, animaties en andere presentatiefuncties die naar het verwijderde object kunnen verwijzen; het verwijderen van een zichtbare vorm kan meer beïnvloeden dan alleen het uiterlijk van de dia.

### **Een vorm verbergen**

Het instellen van [Hidden](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/set_hidden/) op `true` houdt de vorm in de collectie, maar voorkomt dat deze verschijnt in de normale diavoorstelling. De index, opmaak en inhoud blijven beschikbaar voor code, dus verbergen is geschikt voor optionele elementen die later kunnen worden hersteld.

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

Verbergen is geen verwijdering of beveiliging. Het object kan nog steeds worden ontdekt en weergegeven door een gebruiker of door code, en maakt nog steeds deel uit van het presentatie‑bestand.

### **De Z‑order wijzigen**

Overlapende vormen worden getekend volgens de collectie‑volgorde. [Reorder](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishapecollection/reorder/) verplaatst een bestaande vorm naar een doel‑index zonder deze te klonen. Index `0` is de achterkant; `Count - 1` is de voorkant.

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

De rechthoek wordt eerst gemaakt en staat oorspronkelijk achter de ellips. Verplaatsen naar de laatste index brengt deze naar de voorkant. Finaliseer de z‑order na het toevoegen of klonen van alle gerelateerde vormen, want die bewerkingen voegen nieuwe collectie‑items toe of schrijven bestaande weg en kunnen de beoogde stapel wijzigen.

## **Vormen op lay‑outdia’s inspecteren**

Normale dia’s, lay‑outdia’s en masterdia’s hebben afzonderlijke vormcollecties. Een vorm in een lay‑outcollectie is niet hetzelfde object als een gelijk gepositioneerde vorm op een normale dia. Inspecteer lay‑outvormen wanneer je de door een lay‑out geleverde opmaak wilt begrijpen of wijzigen.

Het volgende voorbeeld leest voor elke lay‑outvorm de [FillFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/get_fillformat/) en [LineFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/get_lineformat/) zonder aan te nemen dat elke vorm een `AutoShape` is.

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

Het bewerken van een lay‑out kan meerdere dia’s beïnvloeden die deze gebruiken. Voordat je een lay‑outvorm wijzigt, bepaal of een normale dia het object erft of een lokale overschrijving bevat, en test elke dia die die lay‑out gebruikt.

## **Een vorm exporteren naar SVG**

[WriteAsSvg](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/writeassvg/) schrijft de gerenderde inhoud van één vorm naar een stream. Het resultaat bevat alleen de vorm, niet de volledige achtergrond van de dia of naburige vormen.

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

Houd de presentatie open tijdens het renderen. De uitvoer hangt af van de opmaak van de vorm en van bronnen zoals lettertypen en afbeeldingen. Als je de volledige compositie nodig hebt, exporteer dan de dia in plaats van een individuele vorm. De aanroeper bezit de stream en moet deze sluiten of vrijgeven.

## **Vormen uitlijnen**

De [SlideUtil::AlignShapes](https://reference.aspose.com/slides/nl/cpp/aspose.slides.util/slideutil/alignshapes/) overloads kunnen ofwel alle vormen of geselecteerde collectie‑indexen uitlijnen. [ShapesAlignmentType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/shapesalignmenttype/) geeft de rand, middellijn of distributiemodus aan. Zet `alignToSlide` op `true` om de dia‑randen te gebruiken; zet het op `false` om de geselecteerde vormen ten opzichte van elkaar uit te lijnen.

Dit voorbeeld lijnt drie vormen uit op de bovenrand van de dia. De geretourneerde vormreferenties worden direct vóór uitlijning geconverteerd naar hun huidige indexen.

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

Uitlijning verandert posities, niet de z‑order. Relatieve uitlijning vereist normaal gesproken minimaal twee vormen, terwijl horizontale of verticale distributie voldoende vormen nodig heeft om de afstand te bepalen. Herbereken indexen als je de collectie wijzigt vóór het aanroepen van de methode.

## **Een vorm spiegelen**

De [ShapeFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/shapeframe/)‑klasse slaat positie, grootte, horizontale en verticale spiegelinstellingen en rotatie op. De waarden `FlipH` en `FlipV` gebruiken [NullableBool](https://reference.aspose.com/slides/nl/cpp/aspose.slides/nullablebool/): `True` activeert de spiegel, `False` deactiveert deze, en `NotDefined` behoudt de niet‑gespecificeerde/standaard status.

De invoerpresentatie hieronder bevat één niet‑gespiegelde vorm.

![The shape before flipping](shape_to_be_flipped.png)

Het voorbeeld behoudt alle andere frame‑waarden en vervangt alleen de twee spiegelinstellingen. Dit is belangrijk omdat het toewijzen van een nieuw [Frame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/set_frame/) het volledige frame vervangt.

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

De opgeslagen vorm wordt horizontaal en verticaal gespiegeld terwijl positie, grootte en rotatie behouden blijven.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Moet ik een collectie‑index gebruiken als vorm‑identifier?**

Alleen voor korte‑levensduur verwerking wanneer de collectie niet wijzigt vóór het moment dat de index wordt gebruikt. Geef de voorkeur aan een gevalideerde `Name`‑ of `AlternativeText`‑conventie voor door auteurs gemaakte sjablonen, of `OfficeInteropShapeId` voor interop‑werk binnen een dia‑scope.

**Verwijdert het verbergen van een vorm deze uit de z‑order?**

Nee. Een verborgen vorm blijft in de collectie op dezelfde index. Hij kan worden gevonden, herschikt, bewerkt of opnieuw zichtbaar gemaakt.

**Waarom verscheen een gekloonde vorm vóór een andere vorm?**

`AddClone` voegt de kloon toe aan het einde van de collectie, wat de voorkant van de z‑order is. Gebruik `InsertClone` om de initiële index te kiezen of `Reorder` nadat alle vormen zijn toegevoegd.

**Kan ik een vaste index gebruiken om een preset‑vormaanpassing te identificeren?**

Alleen na het valideren van de exacte preset en collectie‑indeling. Geef de voorkeur aan itereren door `IGeometryShape::get_Adjustments` en het controleren van `IAdjustValue::get_Type`; gebruik `IAdjustValue::get_Name` als aanvullende informatie wanneer hetzelfde semantische type meer dan één keer voorkomt.