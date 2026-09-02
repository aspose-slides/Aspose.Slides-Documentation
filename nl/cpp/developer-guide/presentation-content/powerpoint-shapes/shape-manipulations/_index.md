---
title: Beheer Presentatievormen in C++
linktitle: Vormbewerkingen
type: docs
weight: 40
url: /nl/cpp/shape-manipulations/
keywords:
- PowerPoint-vorm
- presentatievorm
- vorm op dia
- vorm vinden
- vorm klonen
- vorm verwijderen
- vorm verbergen
- vormvolgorde wijzigen
- interop-vorm-ID ophalen
- alternatieve tekst van vorm
- vormlay-outformaten
- vorm als SVG
- vorm naar SVG
- vorm uitlijnen
- vorm spiegelen
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe u presentatievormen kunt identificeren, klonen, verwijderen, verbergen, herschikken, exporteren, uitlijnen en spiegelen met Aspose.Slides voor C++."
---
## **Overzicht**

Aspose.Slides for C++ vertegenwoordigt de vormen op een dia als een geordende [IShapeCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishapecollection/). De collectie is zowel de plek waar u vormen vindt en wijzigt als de bron van hun stapelvolgorde: index `0` is de achterste vorm, terwijl de laatste index de voorste vorm is.

Dit artikel volgt dat model. Het legt eerst uit hoe u een vorm betrouwbaar kunt identificeren, daarna wordt aangetoond hoe u vormen kunt klonen, verwijderen, verbergen en herschikken. De laatste secties behandelen lay-out‑niveau opmaak, SVG‑export, uitlijning en spiegelinstellingen. Elk voorbeeld staat op zichzelf, zodat u alleen de bewerkingen kunt gebruiken die uw workflow vereist.

## **Identificeren en Vinden van Vormen**

Collectie‑indexen zijn handig bij het verwerken van een bekend bestand, maar ze zijn geen stabiele identifiers. Het toevoegen, verwijderen of herschikken van een vorm kan de index wijzigen. Kies een identifier op basis van hoe de presentatie is gemaakt en onderhouden:

- [Name](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/get_name/) is handig voor door ontwikkelaars beheerde sjablonen en is eenvoudig te inspecteren in het Selection Pane van PowerPoint. Namen kunnen bewerkt worden en zijn niet gegarandeerd uniek, dus stel een naamgevingsconventie vast als code ervan afhankelijk is.
- [AlternativeText](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/get_alternativetext/) is nuttig wanneer een toegankelijkheidsbeschrijving of een door de auteur toegevoegde tag de vorm al identificeert. Het is zichtbaar voor gebruikers, kan gelokaliseerd of herschreven worden voor toegankelijkheid, en is niet gegarandeerd uniek. Gebruik geen toegankelijke tekst stilletjes als databasesleutel.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/get_officeinteropshapeid/) is een alleen‑lezen identifier die uniek is binnen een dia en overeenkomt met de shape‑ID die PowerPoint‑interop gebruikt. Gebruik deze bij integratie met PowerPoint of wanneer u een ondubbelzinnige referentie nodig heeft gedurende de levensduur van een vorm. Een gekloonde of opnieuw aangemaakte vorm is een andere vorm en krijgt een eigen ID.

De gerelateerde [UniqueId](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/get_uniqueid/)‑eigenschap heeft presentatie‑scope, maar is bedoeld voor add‑ins en kan opnieuw worden toegewezen. Beschouw het niet als een permanente externe sleutel. Als langdurige identiteit essentieel is, bewaar dan de mapping in applicatie‑data en controleer of de verwachte vorm nog bestaat.

Het volgende voorbeeld zoekt op `Name` en rapporteert de interop‑ID met dia‑scope. Wanneer de sjabloon de verwachte vorm niet bevat, rapporteert de code dat resultaat in plaats van door te gaan met het verkeerde object.

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

Wanneer een bewerking specifiek is voor een bepaald vormtype, controleer dan de interface voordat u type‑specifieke leden gebruikt. Dit voorbeeld werkt tekst en alternatieve tekst bij alleen als het benoemde object een [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) is.

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

## **De Vormenverzameling Aanpassen**

De methoden voor toevoegen, klonen, verwijderen en herschikken werken direct op de collectie. Als een bewerking het aantal of de volgorde van vormen wijzigt, mag u niet blijven vertrouwen op indexen die vóór die bewerking zijn vastgelegd.

### **Een Vorm Klonen**

[AddClone](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishapecollection/addclone/) maakt een onafhankelijke kopie en voegt deze toe aan de doelcollectie. [InsertClone](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishapecollection/insertclone/) maakt eveneens een kopie maar plaatst deze op een opgegeven z‑order‑index. De overloads die coördinaten accepteren verplaatsen de kloon zonder de grootte te wijzigen; overloads met breedte en hoogte kunnen deze ook aanpassen.

Het voorbeeld maakt een doel‑dia, kloont een gelabelde rechthoek naar de voorgrond en voegt een tweede kloon toe aan de achtergrond. Wijzigingen aan een van beide klonen wijzigen de bronvorm niet.

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

Klonen kopieert de inhoud en opmaak van de vorm, inclusief naam en alternatieve tekst. Ken nieuwe logische identifiers toe aan de kloon wanneer die waarden uniek moeten zijn. Hulpbronnen die door complexe vormen worden gebruikt, worden door de presentatie afgehandeld, maar een kloon blijft een nieuw collectie‑item met een nieuwe vormidentiteit.

### **Vormen Verwijderen**

[Remove](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishapecollection/remove/) verwijdert een specifiek vormobject uit zijn collectie. Wanneer u meerdere overeenkomsten tijdens een geïndexeerde iteratie wilt verwijderen, doorloop dan van het einde zodat elke resterende index geldig blijft.

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

Na het verwijderen veranderen het aantal vormen en de indexen van de latere vormen. Verwijzingen naar ongewijzigde vormen blijven betrouwbaarder dan opgeslagen indexen. Houd ook rekening met connectoren, animaties en andere presentatiefuncties die naar het verwijderde object kunnen verwijzen; het verwijderen van een zichtbare vorm kan meer veranderen dan alleen het uiterlijk van de dia.

### **Een Vorm Verbergen**

Het instellen van [Hidden](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/set_hidden/) op `true` houdt de vorm in de collectie, maar voorkomt dat deze verschijnt in de normale diavoorstelling. De index, opmaak en inhoud blijven beschikbaar voor code, dus verbergen is geschikt voor optionele elementen die later hersteld kunnen worden.

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

Verbergen is geen verwijdering of beveiliging. Het object kan nog steeds worden ontdekt en weer zichtbaar gemaakt door een gebruiker of door code, en blijft deel uitmaken van het presentatie‑bestand.

### **De Z‑volgorde Wijzigen**

Overlappende vormen worden getekend in de volgorde van de collectie. [Reorder](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishapecollection/reorder/) verplaatst een bestaande vorm naar een doel‑index zonder deze te klonen. Index `0` is de achterkant; `Count - 1` is de voorkant.

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

De rechthoek wordt eerst gemaakt en staat aanvankelijk achter de ellips. Het naar de laatste index verplaatsen brengt hem naar voren. Voltooi de z‑order nadat u alle gerelateerde vormen heeft toegevoegd of gekloond, omdat die bewerkingen nieuwe collectie‑items toevoegen of invoegen en de beoogde stapel kunnen wijzigen.

## **Vormen Inspecteren op Layoutdia's**

Normale dia's, layout‑dia's en master‑dia's hebben afzonderlijke vormcollecties. Een vorm in een layout‑collectie is niet hetzelfde object als een gelijkaardige vorm op een normale dia. Inspecteer layout‑vormen wanneer u de opmaak die door een layout wordt geleverd wilt begrijpen of wijzigen.

Het volgende voorbeeld leest elke layout‑vorm's [FillFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/get_fillformat/) en [LineFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/get_lineformat/) zonder aan te nemen dat elke vorm een `AutoShape` is.

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

Het bewerken van een layout kan meerdere dia's die de layout gebruiken beïnvloeden. Voordat u een layout‑vorm wijzigt, bepaal of een normale dia het object erft of een lokale overschrijving bevat, en test elke dia die die layout gebruikt.

## **Een Vorm Exporteren naar SVG**

[WriteAsSvg](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/writeassvg/) schrijft de gerenderde inhoud van één vorm naar een stream. Het resultaat bevat alleen de vorm, niet de volledige dia‑achtergrond of aangrenzende vormen.

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

Houd de presentatie open tijdens het renderen. De output hangt af van de opmaak van de vorm en van hulpbronnen zoals lettertypen en afbeeldingen. Als u de volledige compositie nodig hebt, exporteer dan de dia in plaats van een individuele vorm. De aanroeper bezit de stream en moet deze sluiten of disposen.

## **Vormen Uitlijnen**

De [SlideUtil::AlignShapes](https://reference.aspose.com/slides/nl/cpp/aspose.slides.util/slideutil/alignshapes/) overloads lijnen ofwel alle vormen of geselecteerde collectie‑indexen uit. [ShapesAlignmentType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/shapesalignmenttype/) bepaalt de rand, middenlijn of distributiemodus. Zet `alignToSlide` op `true` om de randen van de dia te gebruiken; zet het op `false` om de geselecteerde vormen ten opzichte van elkaar uit te lijnen.

Dit voorbeeld lijnt drie vormen uit op de bovenrand van de dia. De geretourneerde vormreferenties worden direct vóór het uitlijnen omgezet naar hun huidige indexen.

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

Uitlijnen wijzigt posities, niet de z‑order. Relatieve uitlijning vereist normaal gezien ten minste twee vormen, terwijl horizontale of verticale distributie voldoende vormen nodig heeft om de afstand te bepalen. Herbereken de indexen als u de collectie wijzigt vóór het aanroepen van de methode.

## **Een Vorm Spiegelen**

De [ShapeFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/shapeframe/) klasse slaat positie, grootte, horizontale en verticale spiegelinstellingen, en rotatie op. De `FlipH` en `FlipV` waarden gebruiken [NullableBool](https://reference.aspose.com/slides/nl/cpp/aspose.slides/nullablebool/): `True` schakelt het spiegelen in, `False` schakelt het uit, en `NotDefined` behoudt de ongedefinieerde/standaard toestand.

De invoerpresentatie hieronder bevat één niet‑gespiegelde vorm.

![De vorm vóór het spiegelen](shape_to_be_flipped.png)

Het voorbeeld behoudt elke andere frame‑waarde en vervangt alleen de twee spiegelinstellingen. Dit is belangrijk omdat het toewijzen van een nieuw [Frame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/set_frame/) het volledige frame vervangt.

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

## **Veelgestelde Vragen**

**Moet ik een collectie-index gebruiken als vormidentificator?**

Alleen voor kortstondige verwerking wanneer de collectie niet zal veranderen vóórdat de index wordt gebruikt. Geef de voorkeur aan een gevalideerde `Name`‑ of `AlternativeText`‑conventie voor gemaakte sjablonen, of `OfficeInteropShapeId` voor interop‑werk met dia‑scope.

**Verwijdert het verbergen van een vorm deze uit de Z‑volgorde?**

Nee. Een verborgen vorm blijft in de collectie op dezelfde index. Hij kan worden gevonden, herschikt, bewerkt of weer zichtbaar worden gemaakt.

**Waarom verscheen een gekloonde vorm voor een andere vorm?**

`AddClone` voegt de kloon toe aan het einde van de collectie, wat de voorgrond van de Z‑volgorde is. Gebruik `InsertClone` om de initiële index te kiezen of `Reorder` nadat alle vormen zijn toegevoegd.