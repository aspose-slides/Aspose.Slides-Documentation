---
title: Efficiënt presentaties samenvoegen in C++
linktitle: Presentaties samenvoegen
type: docs
weight: 40
url: /nl/cpp/merge-presentation/
keywords:
- PowerPoint samenvoegen
- presentaties samenvoegen
- dia's samenvoegen
- PPT samenvoegen
- PPTX samenvoegen
- ODP samenvoegen
- PowerPoint combineren
- presentaties combineren
- dia's combineren
- PPT combineren
- PPTX combineren
- ODP combineren
- C++
- Aspose.Slides
description: "Leer hoe u PowerPoint- en OpenDocument-presentaties in C++ kunt samenvoegen door dia's te klonen, masters en lay-outs te beheersen, dia-inhoud te verkleinen, secties te behouden en beveiligde of grote bestanden te verwerken."
---
## **Overzicht**

Aspose.Slides for C++ voegt presentaties samen door dia's te klonen van één [Presentatie](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) naar een andere. De belangrijkste bewerking is [ISlideCollection::AddClone](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/addclone/), die de opmaak van de bron‑dia kan behouden of de gekloonde dia kan koppelen aan een master of lay-out in de bestemmingspresentatie.

Dit artikel behandelt de meest voorkomende samenvoeg‑workflows:

- alle dia's samenvoegen met behoud van hun bronopmaak;
- geselecteerde dia's samenvoegen;
- een master uit de bestemmingspresentatie toepassen;
- een specifieke lay-out uit de bestemmingspresentatie toepassen;
- verschillende diaformaten normaliseren vóór het samenvoegen;
- gekloonde dia's aan een sectie toevoegen;
- meerdere presentaties veilig in één end‑to‑end workflow samenvoegen;
- masters, resources, notities, opmerkingen, media, lettertypen, wachtwoorden, grote bestanden en multithreading‑aspecten afhandelen.

## **Hoe dia‑klooning masters en lay‑outs beïnvloedt**

Een dia erft een groot deel van zijn uiterlijk van de lay‑out en master. Om die reden bepaalt de overload die je kiest hoe de samengevoegde dia in de bestemmingspresentatie wordt geïntegreerd.

Gebruik [ISlideCollection::AddClone](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/addclone/) op een van de volgende manieren:

- `AddClone(sourceSlide)` — behoudt de lay‑out en opmaak van de bron‑dia. Indien nodig kan de bron‑master automatisch in de bestemmingspresentatie worden gekloond. Aspose.Slides houdt automatisch gekloonde masters bij, zodat herhaalde dia's die dezelfde bron‑master gebruiken die master niet herhaaldelijk klonen.
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — koppelt de gekloonde dia aan een specifieke bestemmings[IMasterSlide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasterslide/). Aspose.Slides zoekt onder die master naar een passende lay‑out op basis van lay‑outtype of naam.
- `AddClone(sourceSlide, destinationLayout)` — koppelt de gekloonde dia direct aan een specifieke bestemmings[ILayoutSlide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilayoutslide/).

De master of lay‑out die aan een `AddClone`‑overload wordt doorgegeven, moet behoren tot de **bestemmings**‑presentatie, niet tot de bron‑presentatie.

## **Volledige presentaties samenvoegen en bronopmaak behouden**

De eenvoudigste samenvoeging kopieert elke dia van de bron‑presentatie naar de bestemmingspresentatie. Dit is de juiste keuze wanneer de geïmporteerde dia's hun oorspronkelijke thema, master en lay‑outrelaties moeten behouden.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide);
}

destination->Save(u"merged.pptx", SaveFormat::Pptx);
```

De resulterende presentatie kan meerdere masters bevatten wanneer bron‑ en bestemmingspresentatie verschillende ontwerpen gebruiken. Dit is te verwachten wanneer bronopmaak bewust behouden wordt.

## **Geselecteerde dia's samenvoegen**

Je hoeft niet elke dia te klonen. Het volgende voorbeeld importeert alleen geselecteerde dia‑indexen uit de bron‑presentatie.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

int32_t slideIndexes[] = {0, 2, 4};

for (auto index : slideIndexes)
{
    destination->get_Slides()->AddClone(source->get_Slide(index));
}

destination->Save(u"merged-selected-slides.pptx", SaveFormat::Pptx);
```

Controleer dia‑indexen vóór het klonen wanneer ze afkomstig zijn van gebruikersinvoer of een externe configuratie.

## **Dia's samenvoegen met een bestemmingsmaster**

Gebruik de [AddClone(ISlide, IMasterSlide, bool)](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/addclone/) overload wanneer geïmporteerde dia's een master moeten volgen die al behoort tot de bestemmingspresentatie.

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationMaster = destination->get_Master(0);

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, destinationMaster, true);
}

destination->Save(u"merged-with-destination-master.pptx", SaveFormat::Pptx);
```

Aspose.Slides kiest een passende lay‑out onder de opgegeven master door de bron‑lay‑out te vergelijken op type of naam. Als er geen geschikte lay‑out bestaat en `allowCloneMissingLayout` is `true`, wordt de bron‑lay‑out gekloond zodat de dia kan worden toegevoegd. Als deze `false` is, wordt een [PptxEditException](https://reference.aspose.com/slides/nl/cpp/aspose.slides/details_pptxeditexception/) opgegooid.

Gebruik `false` wanneer je wilt dat de samenvoeging faalt in plaats van een extra lay‑out aan de bestemmingsmaster toe te voegen.

## **Dia's samenvoegen met een specifieke bestemmingslay‑out**

Gebruik de [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/addclone/) overload wanneer je precies weet welke bestemmingslay‑out de geïmporteerde dia's moeten gebruiken.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationLayout = destination->get_LayoutSlide(0);

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, destinationLayout);
}

destination->Save(u"merged-with-destination-layout.pptx", SaveFormat::Pptx);
```

Het toepassen van een bestemmingslay‑out verandert de geërfde lay‑outrelatie; het ontwerpt de inhoud van de bron‑dia niet opnieuw. Als de bron‑ en bestemmingslay‑outs verschillende placeholder‑structuren hebben, inspecteer dan het resultaat om te bevestigen dat de geërfde opmaak en placeholder‑gedrag passend zijn.

## **Presentaties met verschillende diaformaten samenvoegen**

Presentaties met verschillende dia‑afmetingen kunnen worden samengevoegd, maar een dia klonen naar een presentatie met een andere dia‑grootte herschept de inhoud niet automatisch voor het nieuwe canvas. Vormen kunnen daardoor verschoven, onverwacht geschaald of buiten het zichtbare dia‑gebied verschijnen.

Een praktische aanpak is om de bron‑presentatie vóór het klonen te herschalen. De [SlideSize::SetSize](https://reference.aspose.com/slides/nl/cpp/aspose.slides/slidesize/setsize/) methode kan bestaande inhoud schalen terwijl de dia‑afmetingen worden gewijzigd. [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/nl/cpp/aspose.slides/slidesizescaletype/) schaalt inhoud zodat deze binnen de gewenste grootte past.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationSize = destination->get_SlideSize()->get_Size();
auto sourceSize = source->get_SlideSize()->get_Size();

if (sourceSize.get_Width() != destinationSize.get_Width() || 
    sourceSize.get_Height() != destinationSize.get_Height())
{
    source->get_SlideSize()->SetSize(
        destinationSize.get_Width(), 
        destinationSize.get_Height(), 
        SlideSizeScaleType::EnsureFit);
}

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide);
}

destination->Save(u"merged-same-slide-size.pptx", SaveFormat::Pptx);
```

Het herschalen wijzigt het bron‑presentatie‑object in het geheugen. Als je de oorspronkelijke bron‑presentatie ongewijzigd nodig hebt voor andere bewerkingen, open dan een afzonderlijke instantie voor de samenvoeging.

## **Dia's samenvoegen in een presentatiesectie**

De basis‑dia‑kloonlus maakt de sectie‑hiërarchie van de bron‑presentatie niet opnieuw. Als secties belangrijk zijn in de output, maak of selecteer dan secties in de bestemmingspresentatie en kloon dia's expliciet naar die secties met [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/addclone/).

```cpp
#include <DOM/ISectionCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto importedSection = destination->get_Sections()->AppendEmptySection(u"Imported slides");

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, importedSection);
}

destination->Save(u"merged-with-section.pptx", SaveFormat::Pptx);
```

De gekloonde dia's worden toegevoegd aan de opgegeven bestemmingssectie. Om meerdere bron‑secties te behouden, maak die secties opnieuw aan in de bestemming en koppel elke bron‑dia aan de overeenkomstige bestemmingssectie.

## **Meerdere presentaties veilig samenvoegen**

Het volgende end‑to‑end voorbeeld gebruikt de eerste presentatie als bestemming, normaliseert de dia‑grootte van elke extra bron, houdt elke bron alleen open zolang deze wordt gekopieerd, en slaat het uiteindelijke bestand één keer op.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

System::String inputFiles[] = {u"part1.pptx", u"part2.pptx", u"part3.pptx"};
const int32_t inputFileCount = 3;

auto merged = System::MakeObject<Presentation>(inputFiles[0]);
auto mergedSize = merged->get_SlideSize()->get_Size();

for (int32_t fileIndex = 1; fileIndex < inputFileCount; fileIndex++)
{
    auto source = System::MakeObject<Presentation>(inputFiles[fileIndex]);
    auto sourceSize = source->get_SlideSize()->get_Size();

    if (sourceSize.get_Width() != mergedSize.get_Width() || 
        sourceSize.get_Height() != mergedSize.get_Height())
    {
        source->get_SlideSize()->SetSize(
            mergedSize.get_Width(), 
            mergedSize.get_Height(), 
            SlideSizeScaleType::EnsureFit);
    }

    for (const auto& slide : source->get_Slides())
    {
        merged->get_Slides()->AddClone(slide);
    }
}

merged->Save(u"merged.pptx", SaveFormat::Pptx);
```

Dit vormt een nuttige basislijn voor het behouden van de bronopmaak van geïmporteerde dia's. Als je output een enkel bestemmings‑thema moet gebruiken, vervang dan de eenvoudige `AddClone(slide)`‑aanroep door de geschikte bestemmings‑master‑ of bestemmings‑lay‑out‑overload die eerder werd getoond.

## **Praktische overwegingen**

### **Masters, lay‑outs en opmaakgetrouwheid**

Standaard dia‑klooning kan automatisch een benodigde bron‑master in de bestemmingspresentatie brengen. Aspose.Slides houdt een intern register bij voor automatisch gekloonde masters om te voorkomen dat dezelfde master herhaaldelijk wordt gekloond. Handmatig gekloonde masters worden niet door dat register gevolgd, dus vermijd het vooraf klonen van masters tenzij je expliciete controle over de master‑structuur nodig hebt.

Ga er niet van uit dat twee masters of lay‑outs met dezelfde naam visueel gelijk zijn. Als een corporate‑template het eindresultaat moet bepalen, kies dan expliciet een bestemmings‑master of -lay‑out en controleer het resultaat na het samenvoegen.

### **Aantekeningen en opmerkingen**

Sprekers‑notities en dia‑opmerkingen zijn gekoppeld aan de dia‑inhoud en worden gekopieerd wanneer een dia wordt gekloond. Aspose.Slides biedt daarnaast speciale API’s voor [presentatienotities](https://docs.aspose.com/slides/nl/cpp/presentation-notes/) en [presentatie‑opmerkingen](https://docs.aspose.com/slides/nl/cpp/presentation-comments/).

Als de opmaak van de notitie‑pagina belangrijk is, controleer dan de samengevoegde presentatie omdat notitie‑masters objecten op presentatieniveau zijn en kunnen verschillen tussen bron‑bestanden. Voor review‑workflows, controleer ook de auteurs van opmerkingen en gepaarde discussies na het combineren van bestanden van verschillende auteurs of templates.

### **Afbeeldingen, audio, video, OLE‑objecten en externe koppelingen**

Dia's kunnen verwijzen naar resources op presentatieniveau, zoals afbeeldingen, ingebedde audio, ingebedde video en OLE‑data. Kloon de hele dia in plaats van alleen de zichtbare vormen, zodat Aspose.Slides de relaties van de dia met zijn resources kan behouden.

Ingesloten en gekoppelde resources moeten verschillend worden behandeld. Een gekoppelde audio‑, video‑, OLE‑object‑ of hyperlink blijft afhankelijk van het externe doel; een dia‑kloon verandert een externe link niet in ingesloten inhoud. Test paden en URL’s van gekoppelde resources in de omgeving waarin de samengevoegde presentatie wordt geopend.

Aspose.Slides houdt automatisch gekloonde masters expliciet bij, maar dit moet niet worden gezien als een algemene garantie dat identieke binaire resources uit niet‑gerelateerde bron‑presentaties altijd worden gededupliceerd. Als de grootte van het uitvoerbestand belangrijk is, inspecteer dan het samengevoegde pakket en meet het resultaat in plaats van te vertrouwen op impliciete deduplicatie.

### **Ingesloten lettertypen en beschikbaarheid van lettertypen**

Lettertypen worden beheerd op presentatieniveau. Als typografie consistent moet blijven over verschillende machines, ga er niet van uit dat het alleen klonen van dia's garandeert dat elk vereist lettertype beschikbaar is in de bestemmingsomgeving. Je kunt ingesloten lettertypen inspecteren met [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsmanager/getembeddedfonts/) en het insluiten expliciet beheren zoals beschreven in [Lettertypen insluiten in presentaties](https://docs.aspose.com/slides/nl/cpp/embedded-font/).

Controleer ook dat je toestemming hebt om de lettertypen die in de bronbestanden worden gebruikt in te sluiten. Lettertype‑licenties kunnen insluiting beperken.

### **Wachtwoord‑beveiligde presentaties**

Een wachtwoord‑beveiligde bron moet succesvol worden geopend voordat de dia's kunnen worden gekloond. Geef het wachtwoord door via [LoadOptions::set_Password](https://reference.aspose.com/slides/nl/cpp/aspose.slides/loadoptions/set_password/).

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");

auto source = System::MakeObject<Presentation>(u"protected.pptx", loadOptions);
```

Het openen van een versleutelde bron past de bescherming niet automatisch toe op de bestemmingspresentatie. Stel de output‑beveiliging apart in wanneer dat vereist is.

### **Grote presentaties en geheugengebruik**

Grote presentaties met hoge‑resolutie afbeeldingen, audio, video of andere grote binaire objecten kunnen aanzienlijk geheugen verbruiken. [LoadOptions::set_BlobManagementOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides/loadoptions/set_blobmanagementoptions/) biedt controle over BLOB‑afhandeling en het gebruik van tijdelijke bestanden. Zie [Presentatie‑BLOB’s beheren](https://docs.aspose.com/slides/nl/cpp/manage-blob/) voor strategieën bij grote bestanden.

Voor grote bestanden, laad bij voorkeur via bestands‑paden, sluit elke bron‑presentatie zodra deze is samengevoegd, en vermijd herhaaldelijk opslaan van tussenresultaten tenzij de workflow checkpoints vereist.

### **Thread‑veiligheid**

Laad, wijzig, sla op of kloon dezelfde [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑instantie niet gelijktijdig vanuit meerdere threads. Houd elke presentatiewinstandigheid beperkt tot één samenvoeg‑operatie. Als je onafhankelijke taken paralleliseert, gebruik dan onafhankelijke presentatiewinstandigheden en volg de [Aspose.Slides multithreading‑richtlijnen](https://docs.aspose.com/slides/nl/cpp/multithreading/).

## **Veelgestelde vragen**

**Hoe houd ik het oorspronkelijke ontwerp van elke bronpresentatie behouden?**

Gebruik [`AddClone(sourceSlide)`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/addclone/) zonder een bestemmings‑master of -lay‑out op te geven. Aspose.Slides kan automatisch de bron‑master klonen wanneer deze door de geïmporteerde dia nodig is.

**Hoe laat ik geïmporteerde dia's het bestemmings‑thema gebruiken?**

Gebruik de overload die een bestemmings‑master accepteert. Geef een master uit de bestemmingspresentatie op, niet uit de bron. Aspose.Slides probeert elke bron‑dia te koppelen aan een passende lay‑out onder die master.

**Wanneer moet ik een specifieke bestemmingslay‑out gebruiken in plaats van een bestemmingsmaster?**

Gebruik een specifieke lay‑out wanneer elke geïmporteerde dia één bekende lay‑out moet gebruiken. Gebruik een master wanneer je wilt dat Aspose.Slides een lay‑out kiest uit die master op basis van het type of de naam van de bron‑lay‑out.

**Kunnen presentaties met verschillende diaformaten worden samengevoegd?**

Ja, maar de inhoud van de dia wordt niet automatisch aangepast aan de dimensies van de bestemming. Schaal de bron‑presentatie eerst wanneer je voorspelbare plaatsing nodig hebt, bijvoorbeeld met [SlideSize::SetSize](https://reference.aspose.com/slides/nl/cpp/aspose.slides/slidesize/setsize/) en [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/nl/cpp/aspose.slides/slidesizescaletype/).

**Kan ik PPT‑, PPTX‑ en ODP‑presentaties in één bestand samenvoegen?**

Ja. Laad elke bron‑presentatie, kloon de benodigde dia's naar één bestemming, en sla de bestemming op in een ondersteund uitvoerformaat. Omdat presentatiespecifieke formaten niet exact dezelfde functionaliteit bieden, controleer complexe inhoud na cross‑format samenvoegingen. Zie [Ondersteunde bestandsindelingen](https://docs.aspose.com/slides/nl/cpp/supported-file-formats/).

**Worden bronsecties automatisch bewaard?**

Niet door een eenvoudige lus die alleen dia's kloont. Maak de vereiste secties opnieuw aan in de bestemming en gebruik de sectie‑overload van [AddClone](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/addclone/) wanneer de sectiestructuur behouden moet blijven.

**Worden aantekeningen en opmerkingen bewaard?**

Ze worden gekopieerd met de gekloonde dia. Voor workflows die afhankelijk zijn van de styling van notitie‑masters, auteurs van opmerkingen of gepaarde review‑gegevens, controleer het samengevoegde resultaat omdat deze scenario's zowel presentatieniveau‑structuren als dia‑niveau‑inhoud omvatten.

**Wat gebeurt er met audio, video, OLE‑objecten en hyperlinks?**

Ingesloten inhoud wordt meegenomen als onderdeel van de resource‑relaties van de gekloonde dia. Externe links blijven extern, dus hun doelbestanden of URL’s moeten nog steeds beschikbaar zijn na de samenvoeging.

**Zijn ingesloten lettertypen van elke bron gegarandeerd beschikbaar in de samengevoegde presentatie?**

Vertrouw niet alleen op dia‑klooning voor font‑distributie. Inspecteer de ingesloten lettertypen van de bestemming en beheer expliciet het insluiten of de beschikbaarheid van externe lettertypen wanneer typografie belangrijk is.

**Hoe voeg ik een wachtwoord‑beveiligd bestand samen?**

Open het met de juiste [LoadOptions::set_Password](https://reference.aspose.com/slides/nl/cpp/aspose.slides/loadoptions/set_password/), kloon daarna de dia's normaal. De bescherming van de output wordt apart geconfigureerd.

**Hoe moet ik zeer grote presentaties verwerken?**

Gebruik BLOB‑beheer wanneer grote binaire objecten het geheugen aanzienlijk belasten, geef de voorkeur aan bestands‑pad‑laden voor zeer grote bestanden, sluit bron‑presentaties direct na het samenvoegen en sla het eindresultaat alleen op wanneer dat nodig is.

**Kan ik dia's vanuit meerdere threads samenvoegen?**

Gebruik geen enkele [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑instantie gelijktijdig vanuit meerdere threads. Houd elke samenvoeg‑operatie geïsoleerd tot eigen presentatiewinstandigheden.