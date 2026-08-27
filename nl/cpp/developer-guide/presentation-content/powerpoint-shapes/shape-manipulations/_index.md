---
title: Beheer presentatievormen in C++
linktitle: Vormmanipulatie
type: docs
weight: 40
url: /nl/cpp/shape-manipulations/
keywords:
- PowerPoint-vorm
- presentatie-vorm
- vorm op dia
- vorm vinden
- vorm klonen
- vorm verwijderen
- vorm verbergen
- volgorde van vorm wijzigen
- interop-vorm-ID ophalen
- alternatieve tekst van vorm
- aanpassingspunt van vorm
- voorafgeconfigureerde vormaanpassing
- vormgeometrie
- vormlay-outformaten
- vorm als SVG
- vorm naar SVG
- vorm uitlijnen
- vorm spiegelen
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe u presentatievormen kunt identificeren, aanpassen, klonen, verwijderen, verbergen, herschikken, exporteren, uitlijnen en spiegelen met Aspose.Slides voor C++."
---
## **Overzicht**

Aspose.Slides for C++ stelt de vormen op een dia voor als een geordende [IShapeCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishapecollection/). De collectie is zowel de plek waar je vormen vindt en wijzigt als de bron van hun stapelvolgorde: index `0` is de vorm die het verst achterin staat, terwijl de laatste index de voorste vorm is.

Dit artikel volgt dat model. Het legt eerst uit hoe je een vorm betrouwbaar kunt identificeren en vooraf ingestelde aanpassingspunten van vormen kunt wijzigen, daarna wordt getoond hoe je vormen kunt klonen, verwijderen, verbergen en opnieuw ordenen. De laatste secties behandelen opmaak op lay-outniveau, SVG-export, uitlijning en spiegelinstellingen. Elk voorbeeld staat op zichzelf, zodat je alleen de bewerkingen kunt gebruiken die jouw workflow vereist.

## **Identificeer en vind vormen**

Collectie‑indexen zijn handig bij het verwerken van een bekend bestand, maar ze zijn geen stabiele identificatoren. Het toevoegen, verwijderen of herschikken van een vorm kan de index wijzigen. Kies een identifier op basis van hoe de presentatie is gemaakt en onderhouden:

- [Name](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/get_name/) is nuttig voor door ontwikkelaars beheerde sjablonen en is gemakkelijk te inspecteren in het selectie‑paneel van PowerPoint. Namen kunnen worden bewerkt en zijn niet gegarandeerd uniek, dus stel een naamgevingsconventie vast als code ervan afhankelijk is.
- [AlternativeText](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/get_alternativetext/) is nuttig wanneer een toegankelijke beschrijving of een door de auteur toegevoegde tag de vorm al identificeert. Het is zichtbaar voor gebruikers, kan worden gelokaliseerd of herschreven voor toegankelijkheid, en is niet gegarandeerd uniek. Gebruik niet stilzwijgend betekenisvolle toegankelijkheidstekst als een databasesleutel.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/get_officeinteropshapeid/) is een alleen‑lezen identifier die uniek is binnen een dia en overeenkomt met de vorm‑ID die door PowerPoint‑interop wordt gebruikt. Gebruik deze bij integratie met PowerPoint of wanneer je een ondubbelzinnige referentie nodig hebt gedurende de levensduur van een vorm. Een gekloonde of opnieuw gemaakte vorm is een andere vorm en krijgt een eigen ID.

De gerelateerde [UniqueId](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/get_uniqueid/)‑eigenschap heeft een presentatiescope, maar is bedoeld voor add‑ins en kan worden her toegewezen. Het moet niet worden behandeld als een permanente externe sleutel. Als langdurige identiteit essentieel is, bewaar dan de koppeling in applicatiedata en controleer of de verwachte vorm nog bestaat.

Het volgende voorbeeld zoekt op `Name` en rapporteert de interop‑ID scoped aan de dia. Wanneer de sjabloon de verwachte vorm niet bevat, rapporteert de code dat resultaat in plaats van verder te gaan met het verkeerde object.

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

Wanneer een bewerking specifiek is voor een vormtype, controleer dan de interface voordat je type‑specifieke leden gebruikt. Dit voorbeeld werkt tekst en alternatieve tekst bij alleen als het benoemde object een [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) is.

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

## **Identificeer en wijzig vooraf ingestelde vormaanpassingen**

Vooraf ingestelde geometrievormen kunnen aanpassingspunten blootstellen die eigenschappen zoals hoekgrootte, pijlverhoudingen of booghoeken regelen. Toegang hiertoe krijg je via de alleen‑lezen collectie [IGeometryShape::get_Adjustments](https://reference.aspose.com/slides/nl/cpp/aspose.slides/igeometryshape/get_adjustments/). De collectie zelf wordt geleverd door de vorm, maar elk [IAdjustValue](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iadjustvalue/) bevat een waarde die kan worden gewijzigd.

Vertrouw niet uitsluitend op een vaste collectie‑index. Loop door de aanpassingen en controleer de alleen‑lezen eigenschap [IAdjustValue::get_Type](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iadjustvalue/get_type/), waarvan de [ShapeAdjustmentType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/shapeadjustmenttype/)‑waarde beschrijft wat de aanpassing regelt. De alleen‑lezen eigenschap [IAdjustValue::get_Name](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iadjustvalue/get_name/) biedt extra identificatie‑informatie en is vooral nuttig wanneer een preset meer dan één aanpassing met hetzelfde semantische type bevat.

Gebruik de eigenschap die overeenkomt met de betekenis van de aanpassing:

| Adjustment type | Purpose | Value to change |
|---|---|---|
| `CornerSize` | Grootte van afgeronde hoeken | [RawValue](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iadjustvalue/set_rawvalue/) |
| `ArrowTailThickness` | Dikte van een pijpstaart | `RawValue` |
| `ArrowheadLength` | Lengte van een pijlkop | `RawValue` |
| `ArrowheadWidth` | Breedte van een pijlkop | `RawValue` |
| `StartAngle` | Beginhoek van een taart‑ of boogvorm | [AngleValue](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iadjustvalue/set_anglevalue/) |
| `EndAngle` | Eindhoek van een taart‑ of boogvorm | `AngleValue` |

`Type` en `Name` kunnen niet worden toegewezen. `RawValue` is een lees‑/schrijf‑integer in de native eenheden van de preset‑geometrie, terwijl `AngleValue` een lees‑/schrijf‑hoek in graden is. Het aantal, de volgorde, de betekenis en het geldige bereik van aanpassingen hangen af van het preset‑[ShapeType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/igeometryshape/get_shapetype/). Een waarde die geldig is voor één preset kan ongeldig zijn of een ander effect hebben voor een andere.

Wanneer `Type` `ShapeAdjustmentType::Custom` is, herkent de API geen standaard semantische betekenis. Inspecteer `Name`, het preset‑type en de bestaande waarde, en laat de aanpassing ongewijzigd tenzij de verwachte betekenis en het bereik bekend zijn. Zelfs voor herkende types, controleer of hetzelfde type meer dan één keer voorkomt voordat je een waarde selecteert. Het artikel over [Connector](/slides/nl/cpp/connector/) toont deze situatie met buig‑aanpassingen van connectoren.

Het volgende volledige voorbeeld maakt standaard‑ en gewijzigde versies van drie preset‑vormen. Het doorloopt elke aanpassing, rapporteert diens `Name` en `Type`, wijzigt grootte‑gerelateerde waarden via `RawValue`, wijzigt hoeken via `AngleValue` en slaat het resultaat op. De linkerkolom behoudt de standaardgeometrie; de rechterkolom toont de aangepaste afgeronde rechthoek, de vier‑richtingspijl en de taart.

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

// Voegt koppen toe voor de standaard- en aangepaste vormkolommen.
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

Het controleren van het semantische type vóór het wijzigen van een waarde maakt de code expliciet in zijn intentie en voorkomt dat je aanneemt dat een bepaalde collectie‑index dezelfde betekenis heeft bij verschillende preset‑vormen.

## **Wijzig de vormcollectie**

De methoden voor toevoegen, klonen, verwijderen en herschikken werken direct op de collectie. Als een bewerking het aantal of de volgorde van vormen wijzigt, vertrouw dan niet meer op indexen die vóór die bewerking zijn vastgelegd.

### **Kloon een vorm**

[AddClone](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishapecollection/addclone/) maakt een onafhankelijke kopie en voegt deze toe aan de doelcollectie. [InsertClone](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishapecollection/insertclone/) maakt ook een kopie maar plaatst deze op een opgegeven z‑order‑index. De overloads die coördinaten accepteren verplaatsen de kloon zonder de grootte te wijzigen; overloads met breedte en hoogte kunnen deze ook aanpassen.

Het voorbeeld maakt een doel‑dia, kloont een gelabelde rechthoek naar voren en voegt een tweede kloon toe achteraan. Wijzigingen aan zowel de eerste als de tweede kloon wijzigen de bronvorm niet.

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

Klonen kopieert de inhoud en opmaak van de vorm, inclusief naam en alternatieve tekst. Ken nieuwe logische identifiers toe aan de kloon wanneer die waarden uniek moeten zijn. Bronnen die door complexe vormen worden gebruikt, worden afgehandeld door de presentatie, maar een kloon blijft een nieuw collectie‑item met een nieuwe vormidentiteit.

### **Verwijder vormen**

[Remove](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishapecollection/remove/) verwijdert een specifiek vormobject uit zijn collectie. Wanneer je tijdens een geïndexeerde iteratie meerdere overeenkomsten wilt verwijderen, doorloop dan de collectie van achteren zodat elk overgebleven index geldig blijft.

Dit voorbeeld verwijdert elke vorm met een opgegeven naam. Het leest de huidige geïndexeerde vorm, niet een vast collectie‑item, en cast de vorm niet onnodig.

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

Na verwijdering veranderen het aantal vormen en de indexen van latere vormen. Verwijzingen naar onaangetaste vormen blijven betrouwbaarder dan opgeslagen indexen. Houd ook rekening met connectoren, animaties en andere presentatiefuncties die naar het verwijderde object kunnen verwijzen; het verwijderen van een zichtbare vorm kan meer beïnvloeden dan alleen het uiterlijk van de dia.

### **Verberg een vorm**

Instellen van [Hidden](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/set_hidden/) op `true` houdt de vorm in de collectie, maar verhindert dat deze voorkomt in de normale diavoorstelling. De index, opmaak en inhoud blijven beschikbaar voor code, dus verbergen is geschikt voor optionele elementen die later eventueel hersteld kunnen worden.

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

Verbergen is geen verwijdering of beveiliging. Het object kan nog steeds worden ontdekt en weer zichtbaar worden gemaakt door een gebruiker of door code, en het blijft deel uitmaken van het presentatie‑bestand.

### **Wijzig de Z‑order**

Overschotende vormen worden getekend in de volgorde van de collectie. [Reorder](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishapecollection/reorder/) verplaatst een bestaande vorm naar een doel‑index zonder deze te klonen. Index `0` is de achterkant; `Count - 1` is de voorkant.

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

De rechthoek wordt eerst aangemaakt en zit initieel achter de ellips. Verplaatsen naar de laatste index brengt hem naar voren. Voltooi de z‑order nadat alle gerelateerde vormen zijn toegevoegd of gekloond, want die bewerkingen voegen nieuwe collectie‑items toe of plaatsen ze in, waardoor de beoogde stapel kan verschuiven.

## **Inspecteer vormen op lay‑outdia's**

Normale dia's, lay‑outdia's en masterdia's hebben gescheiden vormcollecties. Een vorm in een lay‑outcollectie is niet hetzelfde object als een vergelijkbaar gepositioneerde vorm op een normale dia. Inspecteer lay‑outvormen wanneer je de opmaak die door een lay‑out wordt geleverd wilt begrijpen of wijzigen.

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

Het bewerken van een lay‑out kan meerdere dia's die het gebruiken beïnvloeden. Controleer voordat je een lay‑outvorm wijzigt of een normale dia het object erft of een lokale overschrijving bevat, en test elke dia die die lay‑out gebruikt.

## **Exporteer een vorm naar SVG**

[WriteAsSvg](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/writeassvg/) schrijft de gerenderde inhoud van één vorm naar een stream. Het resultaat bevat alleen de vorm, niet de volledige dia‑achtergrond of naburige vormen.

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

Houd de presentatie open tijdens het renderen. De output hangt af van de opmaak van de vorm en van bronnen zoals lettertypen en afbeeldingen. Als je de volledige compositie nodig hebt, exporteer dan de dia in plaats van een individuele vorm. De aanroeper bezit de stream en moet deze sluiten of vrijgeven.

## **Lijn vormen uit**

[SlideUtil::AlignShapes](https://reference.aspose.com/slides/nl/cpp/aspose.slides.util/slideutil/alignshapes/) overloads lijnen ofwel alle vormen uit ofwel geselecteerde collectie‑indexen uit. [ShapesAlignmentType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/shapesalignmenttype/) specificeert de rand, het middellijn‑ of distributiemodus. Stel `alignToSlide` in op `true` om de dia‑randen te gebruiken; stel het in op `false` om de geselecteerde vormen ten opzichte van elkaar uit te lijnen.

Dit voorbeeld lijnt drie vormen uit langs de bovenrand van de dia. De geretourneerde vormreferenties worden direct vóór uitlijning naar hun huidige indexen geconverteerd.

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

Uitlijning wijzigt posities, niet de z‑order. Relatieve uitlijning vereist normaal gezien minimaal twee vormen, terwijl horizontale of verticale distributie genoeg vormen nodig heeft om de afstand te bepalen. Herbereken indexen als je de collectie wijzigt vóór het aanroepen van de methode.

## **Spiegel een vorm**

De [ShapeFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/shapeframe/)‑klasse slaat positie, grootte, horizontale en verticale spiegelinstellingen en rotatie op. De waarden `FlipH` en `FlipV` gebruiken [NullableBool](https://reference.aspose.com/slides/nl/cpp/aspose.slides/nullablebool/): `True` activeert de spiegeling, `False` deactiveert deze, en `NotDefined` behoudt de niet‑gespecificeerde/standaardstatus.

De invoerpresentatie hieronder bevat één niet‑gespiegelde vorm.

![De vorm vóór het spiegelen](shape_to_be_flipped.png)

Het voorbeeld behoudt elke andere frame‑waarde en vervangt alleen de twee spiegelinstellingen. Dit is belangrijk omdat het toewijzen van een nieuwe [Frame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/set_frame/) het volledige frame vervangt.

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

![De vorm na het spiegelen](flipped_shape.png)

## **FAQ**

**Moet ik een collectie‑index gebruiken als vorm‑identifier?**

Alleen voor kortdurende verwerking wanneer de collectie niet verandert vóórdat de index wordt gebruikt. Geef de voorkeur aan een gevalideerde `Name`‑ of `AlternativeText`‑conventie voor gemaakte sjablonen, of `OfficeInteropShapeId` voor interop‑werk op dia‑niveau.

**Verwijdert het verbergen van een vorm deze uit de z‑order?**

Nee. Een verborgen vorm blijft in de collectie op dezelfde index. Hij kan worden gevonden, herschikt, bewerkt of opnieuw zichtbaar worden gemaakt.

**Waarom verscheen een gekloonde vorm vóór een andere vorm?**

`AddClone` voegt de kloon toe aan het einde van de collectie, wat de voorkant van de z‑order is. Gebruik `InsertClone` om een initiële index te kiezen of `Reorder` nadat alle vormen zijn toegevoegd.

**Kan ik een vaste index gebruiken om een preset‑vormaanpassing te identificeren?**

Alleen na het valideren van de exacte preset en collectie‑lay‑out. Geef de voorkeur aan itereren door `IGeometryShape::get_Adjustments` en controleren van `IAdjustValue::get_Type`; gebruik `IAdjustValue::get_Name` als extra informatie wanneer hetzelfde semantische type meer dan één keer voorkomt.