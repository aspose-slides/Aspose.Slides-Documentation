---
title: Efficiënt Presentaties Samenvoegen in C++
linktitle: Presentaties Samenvoegen
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
description: "Leer hoe u PowerPoint- en OpenDocument-presentaties kunt samenvoegen in C++ door dia's te klonen, masters en lay-outs te beheren, de dia-inhoud te herschalen, secties te behouden en beveiligde of grote bestanden te verwerken."
---
## **Overzicht**

Aspose.Slides for C++ voegt presentaties samen door dia's te klonen van één [Presentatie](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) naar een andere. De belangrijkste bewerking is [ISlideCollection::AddClone](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/addclone/), die de opmaak van de bron‑dia kan behouden of de gekloonde dia kan koppelen aan een master of lay‑out in de doelpresentatie.

Dit artikel behandelt de meest voorkomende samenvoeg‑workflows:

- alle dia’s samenvoegen terwijl hun bron‑opmaak behouden blijft;
- geselecteerde dia’s samenvoegen;
- een master van de doelpresentatie toepassen;
- een specifieke lay‑out van de doelpresentatie toepassen;
- verschillende dia‑groottes normaliseren vóór het samenvoegen;
- gekloonde dia’s aan een sectie toevoegen;
- meerdere presentaties samenvoegen in één end‑to‑end‑workflow;
- masters, resources, notities, opmerkingen, media, lettertypen, wachtwoorden, grote bestanden en multithreading‑aspecten afhandelen.

## **Hoe Dia‑Klonen Masters en Lay‑outs Beïnvloedt**

Een dia erft een groot deel van zijn uiterlijk van zijn lay‑out en master. Om die reden bepaalt de door u gekozen overload van het klonen hoe de samengevoegde dia wordt geïntegreerd in de doelpresentatie.

Gebruik [ISlideCollection::AddClone](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/addclone/) op één van de volgende manieren:

- `AddClone(sourceSlide)` — behoudt de lay‑out en opmaak van de bron‑dia. Indien nodig kan de bron‑master automatisch worden gekloond naar de doelpresentatie. Aspose.Slides houdt automatisch gekloonde masters bij zodat herhaalde dia’s die dezelfde bron‑master gebruiken die master niet telkens opnieuw klonen.
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — koppelt de gekloonde dia aan een specifieke doel‑[IMasterSlide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasterslide/). Aspose.Slides zoekt onder die master naar een overeenkomende lay‑out op type of naam.
- `AddClone(sourceSlide, destinationLayout)` — koppelt de gekloonde dia direct aan een specifieke doel‑[ILayoutSlide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilayoutslide/).

De master of lay‑out die aan een `AddClone`‑overload wordt doorgegeven, moet tot de **doel**‑presentatie behoren, niet tot de bron‑presentatie.

## **Gehele Presentaties Samenvoegen en Bron‑Opmaak Behouden**

De eenvoudigste samenvoeging copy‑t elke dia van de bron‑presentatie naar de doelpresentatie. Dit is de juiste keuze wanneer de geïmporteerde dia’s hun oorspronkelijke thema, master en lay‑out‑relaties moeten behouden.

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

De resulterende presentatie kan meerdere masters bevatten wanneer bron‑ en doel‑presentatie verschillende designs gebruiken. Dit is te verwachten wanneer bron‑opmaak bewust wordt bewaard.

## **Geselecteerde Dia’s Samenvoegen**

U hoeft niet elke dia te klonen. Het volgende voorbeeld importeert alleen geselecteerde dia‑indexen uit de bron‑presentatie.

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

Valideer dia‑indexen vóór het klonen wanneer ze afkomstig zijn van gebruikersinvoer of externe configuratie.

## **Dia’s Samenvoegen Met een Doel‑Master**

Gebruik de overload [AddClone(ISlide, IMasterSlide, bool)](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/addclone/) wanneer geïmporteerde dia’s een master moeten volgen die al tot de doelpresentatie behoort.

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

Aspose.Slides selecteert onder de opgegeven master een passende lay‑out door het type of de naam van de bron‑lay‑out te matchen. Als er geen geschikte lay‑out bestaat en `allowCloneMissingLayout` is `true`, wordt de bron‑lay‑out gekloond zodat de dia kan worden toegevoegd. Is het `false`, dan wordt een [PptxEditException](https://reference.aspose.com/slides/nl/cpp/aspose.slides/details_pptxeditexception/) gegooid.

Gebruik `false` wanneer u wilt dat de samenvoeging faalt in plaats van een extra lay‑out aan de doel‑master toe te voegen.

## **Dia’s Samenvoegen Met een Specifieke Doel‑Lay‑out**

Gebruik de overload [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/addclone/) wanneer u precies weet welke doel‑lay‑out de geïmporteerde dia’s moeten gebruiken.

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

Het toepassen van een doel‑lay‑out wijzigt de geërfde lay‑outrelatie; het herschept de inhoud van de bron‑dia niet. Als de bron‑ en doel‑lay‑outs verschillende placeholder‑structuren hebben, controleer dan het resultaat om te bevestigen dat de geërfde opmaak en placeholder‑gedrag geschikt zijn.

## **Presentaties Met Verschillende Dia‑Grootten Samenvoegen**

Presentaties met verschillende dia‑afmetingen kunnen worden samengevoegd, maar het klonen van een dia naar een presentatie met een andere dia‑grootte herschept de inhoud niet automatisch voor het nieuwe canvas. Vormen kunnen daardoor verschoven, onverwacht geschaald of buiten het zichtbare dia‑gebied terechtkomen.

Een praktische aanpak is om de bron‑presentatie vóór het klonen te herschalen. De methode [SlideSize::SetSize](https://reference.aspose.com/slides/nl/cpp/aspose.slides/slidesize/setsize/) kan bestaande inhoud schalen terwijl de dia‑afmetingen worden aangepast. [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/nl/cpp/aspose.slides/slidesizescaletype/) schaalt de inhoud zodat deze past binnen de opgegeven grootte.

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

Het herschalen verandert het bron‑presentatie‑object in het geheugen. Als u de originele bron‑presentatie ongewijzigd wilt behouden voor andere bewerkingen, open dan een aparte instantie voor de samenvoeging.

## **Dia’s Samenvoegen in een Presentatie‑Sectie**

De eenvoudige dia‑klonlus maakt de sectie‑hiërarchie van de bron‑presentatie niet opnieuw aan. Als secties belangrijk zijn in de uitvoer, maak of selecteer dan secties in de doelpresentatie en kloon dia’s er expliciet in met [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/addclone/).

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

De gekloonde dia’s worden toegevoegd aan de opgegeven doel‑sectie. Om meerdere bron‑secties te behouden, doorloop [Presentation::get_Sections](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_sections/), haal elke bron‑sectie‑dia op met [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isection/getslideslistofsection/), recreëer de secties in de doel‑presentatie, en kloon elke opgehaalde dia naar de overeenkomstige doel‑sectie. Zie [Manage Slide Sections](/slides/nl/cpp/slide-section/) voor een volledig voorbeeld van sectie‑enumeratie, inclusief lege secties en structurele wijzigingen.

## **Meerdere Presentaties Veiliger Samenvoegen**

Het volgende end‑to‑end‑voorbeeld gebruikt de eerste presentatie als bestemming, normaliseert de dia‑grootte van elke extra bron, houdt elke bron alleen open zolang deze wordt gekopieerd, en slaat het uiteindelijke bestand pas op.

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

Dit is een nuttige basis om de bron‑opmaak van geïmporteerde dia’s te behouden. Als uw uitvoer een enkel doel‑thema moet gebruiken, vervang dan de eenvoudige `AddClone(slide)`‑aanroep door de eerder getoonde overload met doel‑master of doel‑lay‑out.

## **Praktische Overwegingen**

### **Masters, Lay‑outs en Opmaak‑Nauwkeurigheid**

Standaard dia‑klonen kan een vereiste bron‑master automatisch naar de doelpresentatie brengen. Aspose.Slides houdt een interne register bij van automatisch gekloonde masters om te voorkomen dat dezelfde master herhaaldelijk wordt gekloond. Handmatig gekloonde masters worden niet in dat register bijgehouden; vermijd daarom het vooraf klonen van masters tenzij u expliciete controle over de master‑structuur nodig heeft.

Ga er niet van uit dat twee masters of lay‑outs met dezelfde naam visueel gelijkwaardig zijn. Als een bedrijfs­sjabloon de uiteindelijke uitstraling moet bepalen, kies dan expliciet een doel‑master of –lay‑out en verifieer het resultaat na het samenvoegen.

### **Notities en Opmerkingen**

Sprekersnotities en dia‑commentaren zijn gekoppeld aan de dia‑inhoud en worden gekopieerd wanneer een dia wordt gekloond. Aspose.Slides biedt ook specifieke API’s voor [presentation notes](/slides/nl/cpp/presentation-notes/) en [presentation comments](/slides/nl/cpp/presentation-comments/).

Als de opmaak van de notitie‑pagina belangrijk is, controleer dan de samengevoegde presentatie omdat notitie‑masters objecten op presentatieniveau zijn en kunnen verschillen tussen bron‑bestanden. Voor review‑workflows, controleer ook de auteurs van opmerkingen en gearchiveerde discussies na het combineren van bestanden van verschillende auteurs of sjablonen.

### **Afbeeldingen, Audio, Video, OLE‑objecten en Externe Links**

Dia’s kunnen verwijzen naar resources op presentatieniveau, zoals afbeeldingen, ingesloten audio, ingesloten video en OLE‑data. Kloon de dia zelf in plaats van alleen de zichtbare vormen, zodat Aspose.Slides de relaties van de dia met zijn resources kan behouden.

Ingesloten en gekoppelde resources moeten anders worden behandeld. Een gekoppeld audio‑, video‑, OLE‑object of hyperlink blijft afhankelijk van het externe doel; het klonen van een dia maakt van een externe link geen ingesloten inhoud. Test de paden en URL’s van gekoppelde resources in de omgeving waar de samengevoegde presentatie wordt geopend.

Aspose.Slides houdt automatisch gekloonde masters bij, maar dit moet niet worden gezien als een algemene garantie dat identieke binaire resources uit niet‑gerelateerde bron‑presentaties altijd worden gededupliceerd. Als de bestandsgrootte van belang is, inspecteer dan het samengevoegde pakket en meet het resultaat in plaats van te vertrouwen op impliciete deduplicatie.

### **Ingesloten Lettertypen en Beschikbaarheid**

Lettertypen worden beheerd op presentatieniveau. Als typografie consistent moet blijven over verschillende computers, ga er niet van uit dat alleen dia‑klonen garandeert dat elk vereist lettertype beschikbaar is in de doelomgeving. U kunt ingesloten lettertypen inspecteren met [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsmanager/getembeddedfonts/) en expliciet beheren zoals beschreven in [Embed Fonts in Presentations](/slides/nl/cpp/embedded-font/).

Controleer eveneens of u toestemming heeft om de door de bron‑bestanden gebruikte lettertypen in te sluiten. Lettertype‑licenties kunnen het insluiten beperken.

### **Wachtwoord‑Beveiligde Presentaties**

Een bron die met wachtwoord beveiligd is, moet eerst succesvol worden geopend voordat de dia’s kunnen worden gekloond. Geef het wachtwoord door via [LoadOptions::set_Password](https://reference.aspose.com/slides/nl/cpp/aspose.slides/loadoptions/set_password/).

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");

auto source = System::MakeObject<Presentation>(u"protected.pptx", loadOptions);
```

Het openen van een versleutelde bron brengt de bescherming niet automatisch over naar de doelpresentatie. Configureer de uitvoerbeveiliging apart indien nodig.

### **Grote Presentaties en Geheugengebruik**

Grote presentaties met hoge‑resolutie‑afbeeldingen, audio, video of andere omvangrijke binaire objecten kunnen veel geheugen verbruiken. [LoadOptions::set_BlobManagementOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides/loadoptions/set_blobmanagementoptions/) biedt controle over BLOB‑afhandeling en tijdelijk‑bestandgebruik. Zie [Manage Presentation BLOBs](/slides/nl/cpp/manage-blob/) voor strategieën bij grote bestanden.

Voor grote bestanden: laad bij voorkeur vanaf bestands‑paden, maak elke bron‑presentatie vrij zodra deze is samengevoegd, en vermijd het herhaaldelijk opslaan van tussenresultaten tenzij de workflow checkpoints vereist.

### **Thread‑Veiligheid**

Laad, wijzig, sla op of kloon niet dezelfde [Presentatie](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) instantie gelijktijdig vanuit meerdere threads. Houd elke presentatienaam beperkt tot één samenvoeg‑operatie. Als u onafhankelijke taken paralleliseert, gebruik dan onafhankelijke presentatie‑instanties en volg de [Aspose.Slides multithreading guidance](/slides/nl/cpp/multithreading/).

## **FAQ**

**Hoe behoud ik het oorspronkelijke ontwerp van elke bron‑presentatie?**

Gebruik [AddClone](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/addclone/) zonder een doel‑master of -lay‑out op te geven. Aspose.Slides kan de bron‑master automatisch klonen wanneer deze door de geïmporteerde dia nodig is.

**Hoe laat ik geïmporteerde dia’s het doel‑thema gebruiken?**

Gebruik de overload die een doel‑master accepteert. Geef een master uit de doel‑presentatie door, niet uit de bron. Aspose.Slides probeert elke bron‑dia te koppelen aan een passende lay‑out onder die master.

**Wanneer moet ik een specifieke doel‑lay‑out gebruiken in plaats van een doel‑master?**

Gebruik een specifieke lay‑out wanneer elke geïmporteerde dia één bekende lay‑out moet gebruiken. Gebruik een master wanneer u wilt dat Aspose.Slides onder die master een passende lay‑out selecteert op basis van het type of de naam van de bron‑lay‑out.

**Kunnen presentaties met verschillende dia‑groottes worden samengevoegd?**

Ja, maar de dia‑inhoud wordt niet automatisch herschikt voor de doel‑afmetingen. Pas de bron‑presentatie eerst aan wanneer u voorspelbare plaatsing nodig heeft, bijvoorbeeld met [SlideSize::SetSize](https://reference.aspose.com/slides/nl/cpp/aspose.slides/slidesize/setsize/) en [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/nl/cpp/aspose.slides/slidesizescaletype/).

**Kan ik PPT, PPTX en ODP presentaties in één bestand samenvoegen?**

Ja. Laad elke bron‑presentatie, kloon de benodigde dia’s naar één doel‑presentatie en sla de doel‑presentatie op in een ondersteund uitvoerformaat. Omdat bestandsformaten niet exact dezelfde functionaliteit bieden, controleer complexe inhoud na cross‑formaat‑samenvoegingen. Zie [Supported File Formats](/slides/nl/cpp/supported-file-formats/).

**Worden bron‑secties automatisch bewaard?**

Nee, niet door een eenvoudige lus die alleen dia’s kloont. Maak de benodigde secties in de doel‑presentatie opnieuw aan en gebruik de sectie‑overload van [AddClone](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/addclone/) wanneer de sectiestructuur bewaard moet blijven.

**Worden sprekersnotities en opmerkingen bewaard?**

Ze worden gekopieerd met de gekloonde dia. Voor workflows die afhankelijk zijn van de styling van notitie‑masters, auteurs van opmerkingen, of gearchiveerde review‑data, controleer dan het samengevoegde resultaat omdat deze scenario’s zowel presentatieniveau‑structuren als dia‑niveau‑inhoud betreffen.

**Wat gebeurt er met audio, video, OLE‑objecten en hyperlinks?**

Ingesloten inhoud wordt meegenomen als onderdeel van de resource‑relaties van de gekloonde dia. Externe links blijven extern, dus hun doel‑bestanden of URL’s moeten nog steeds beschikbaar zijn na de samenvoeging.

**Zijn ingesloten lettertypen van elke bron gegarandeerd beschikbaar in de samengevoegde presentatie?**

Vertrouw niet alleen op dia‑klonen voor lettertype‑distributie. Inspecteer de ingesloten lettertypen van de doel‑presentatie en beheer expliciet de insluiting of beschikbaarheid van externe lettertypen wanneer typografie belangrijk is.

**Hoe voeg ik een wachtwoord‑beveiligd bestand samen?**

Open het met de juiste [LoadOptions::set_Password](https://reference.aspose.com/slides/nl/cpp/aspose.slides/loadoptions/set_password/), kloon daarna de dia’s normaal. Output‑beveiliging wordt apart geconfigureerd.

**Hoe moet ik zeer grote presentaties afhandelen?**

Gebruik BLOB‑beheer wanneer grote binaire objecten het geheugen sterk belasten, laad grote bestanden bij voorkeur via bestands‑paden, maak bron‑presentaties direct na gebruik vrij, en sla het eindresultaat alleen op wanneer nodig.

**Kan ik dia’s vanuit meerdere threads samenvoegen?**

Gebruik niet één [Presentatie](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) instantie gelijktijdig vanuit meerdere threads. Houd elke samenvoeg‑operatie geïsoleerd in eigen presentatie‑instanties.