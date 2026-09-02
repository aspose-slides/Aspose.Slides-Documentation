---
title: Effektiv sammanslagning av presentationer i C++
linktitle: Sammanslå presentationer
type: docs
weight: 40
url: /sv/cpp/merge-presentation/
keywords:
- sammanfoga PowerPoint
- sammanfoga presentationer
- sammanfoga bilder
- sammanfoga PPT
- sammanfoga PPTX
- sammanfoga ODP
- kombinera PowerPoint
- kombinera presentationer
- kombinera bilder
- kombinera PPT
- kombinera PPTX
- kombinera ODP
- C++
- Aspose.Slides
description: "Lär dig hur du sammanslår PowerPoint- och OpenDocument-presentationer i C++ genom att klona bilder, styra masters och layouter, ändra storlek på bildinnehåll, bevara sektioner och hantera skyddade eller stora filer."
---
## **Översikt**

Aspose.Slides for C++ kombinerar presentationer genom att klona bilder från en [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) till en annan. Huvudoperationen är [ISlideCollection::AddClone](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidecollection/addclone/), som kan bevara källbildens formatering eller fästa den klonade bilden på ett master‑ eller layout‑objekt i destinationspresentationen.

Denna artikel täcker de vanligaste sammanslagningsarbetsflödena:

- slå samman alla bilder samtidigt som deras källformatering bevaras;
- slå samman utvalda bilder;
- tillämpa ett master‑objekt från destinationspresentationen;
- tillämpa ett specifikt layout‑objekt från destinationspresentationen;
- normalisera olika bildstorlekar innan sammanslagning;
- lägga till klonade bilder i ett avsnitt;
- slå samman flera presentationer i ett end‑to‑end‑arbetsflöde;
- hantera masters, resurser, anteckningar, kommentarer, media, typsnitt, lösenord, stora filer och flerkärniga problem.

## **Hur bildkloning påverkar masters och layouter**

En bild ärver mycket av sitt utseende från sin layout och master. Av den anledningen bestämmer den överlagring av kloning du väljer hur den sammanslagna bilden integreras i destinationspresentationen.

Använd [ISlideCollection::AddClone](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidecollection/addclone/) på ett av följande sätt:

- `AddClone(sourceSlide)` — bevara källbildens layout och formatering. Vid behov kan käll‑master automatiskt klonas in i destinationspresentationen. Aspose.Slides spårar automatiskt klonade masters så att upprepade bilder som använder samma käll‑master inte leder till att master‑objektet klonas flera gånger.
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — fästa den klonade bilden på ett specifikt destinations‑[IMasterSlide](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imasterslide/). Aspose.Slides söker efter en matchande layout under den mastern efter layout‑typ eller namn.
- `AddClone(sourceSlide, destinationLayout)` — fästa den klonade bilden direkt på ett specifikt destinations‑[ILayoutSlide](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ilayoutslide/).

Den master eller layout som skickas till en `AddClone`‑overload måste tillhöra **destinations**‑presentationen, inte källpresentationen.

## **Slå samman hela presentationer och bevara källformatering**

Den enklaste sammanslagningen kopierar varje bild från källpresentationen till destinationspresentationen. Detta är det lämpliga valet när de importerade bilderna ska behålla sitt ursprungliga tema, master och layout‑relationer.

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

Den resulterande presentationen kan innehålla flera masters när käll‑ och destinationspresentationen använder olika designer. Detta är förväntat när källformatering avsiktligt bevaras.

## **Slå samman utvalda bilder**

Du behöver inte klona varje bild. Följande exempel importerar endast valda bildindex från källpresentationen.

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

Validera bildindex innan kloning när de kommer från användarinmatning eller extern konfiguration.

## **Slå samman bilder med ett destinations‑master**

Använd overloaden [AddClone(ISlide, IMasterSlide, bool)](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidecollection/addclone/) när importerade bilder ska följa ett master‑objekt som redan finns i destinationspresentationen.

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

Aspose.Slides väljer en lämplig layout under den angivna mastern genom att matcha käll‑layoutens typ eller namn. Om ingen passande layout finns och `allowCloneMissingLayout` är `true` klonas käll‑layouten så att bilden kan läggas till. Om den är `false` kastas ett [PptxEditException](https://reference.aspose.com/slides/sv/cpp/aspose.slides/details_pptxeditexception/).

Använd `false` när du vill att sammanslagningen ska misslyckas istället för att introducera en extra layout i destinations‑mastern.

## **Slå samman bilder med en specifik destinations‑layout**

Använd overloaden [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidecollection/addclone/) när du exakt vet vilken destinations‑layout de importerade bilderna ska använda.

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

Att tillämpa en destinations‑layout ändrar den ärvda layout‑relationen; den redesignar inte källbildens innehåll. Om käll‑ och destinations‑layouter har olika platshållarstrukturer, inspektera resultatet för att bekräfta att den ärvda formateringen och platshållarbeteendet är lämpliga.

## **Slå samman presentationer med olika bildstorlekar**

Presentationer med olika bilddimensioner kan slås samman, men att klona en bild till en presentation med en annan bildstorlek redesignar inte automatiskt innehållet för den nya duken. Former kan därför visas förskjutna, skalade oväntat eller utanför det synliga bildområdet.

Ett praktiskt tillvägagångssätt är att ändra storlek på källpresentationen innan kloning. Metoden [SlideSize::SetSize](https://reference.aspose.com/slides/sv/cpp/aspose.slides/slidesize/setsize/) kan skala befintligt innehåll medan bilddimensionerna ändras. [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/sv/cpp/aspose.slides/slidesizescaletype/) skalar innehållet så att det passar inom den begärda storleken.

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

Att ändra storlek påverkar källpresentationens objekt i minnet. Om du behöver den ursprungliga källpresentationen oförändrad för andra operationer, öppna en separat instans för sammanslagningen.

## **Slå samman bilder i ett presentations‑avsnitt**

Den grundläggande bildkloningsloopen återskapar inte källpresentationens avsnittshierarki. Om avsnitt är viktiga i resultatet, skapa eller välj avsnitt i destinationspresentationen och klona bilder in i dem explicit med [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidecollection/addclone/).

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

De klonade bilderna läggs till i det angivna destinations‑avsnittet. För att bevara flera käll‑avsnitt, iterera över [Presentation::get_Sections](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_sections/), hämta varje käll‑avsnitts aktuella bilder med [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isection/getslideslistofsection/), återskapa avsnitten i destinationen och klona varje återlämnad bild till motsvarande destinations‑avsnitt. Se [Manage Slide Sections](/slides/sv/cpp/slide-section/) för ett komplett exempel på avsnitts‑enumeration, inklusive tomma avsnitt och strukturella förändringar.

## **Slå samman flera presentationer på ett säkert sätt**

Följande end‑to‑end‑exempel använder den första presentationen som destination, normaliserar bildstorleken för varje ytterligare källa, håller varje källa öppen endast medan den kopieras och sparar slutfilen en gång.

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

Detta är en användbar grund för att bevara källformatering på importerade bilder. Om ditt resultat måste använda ett enhetligt destinations‑tema, ersätt det enkla `AddClone(slide)`‑anropet med den lämpliga destinations‑master‑ eller destinations‑layout‑overloaden som visades tidigare.

## **Praktiska överväganden**

### **Masters, layouter och formateringsfidelity**

Standardbildkloning kan automatiskt föra in ett nödvändigt käll‑master‑objekt i destinationspresentationen. Aspose.Slides håller ett internt register för automatiskt klonade masters för att undvika att klona samma master flera gånger. Manuellt klonade masters spåras inte av registret, så undvik att förklona masters såvida du inte behöver explicit kontroll över master‑strukturen.

Anta inte att två masters eller layouter med samma namn är visuellt identiska. Om en företagsmall måste kontrollera den slutliga utformningen, välj ett destinations‑master‑ eller layout‑objekt explicit och verifiera resultatet efter sammanslagning.

### **Anteckningar och kommentarer**

Talarnoteringar och bildkommentarer är kopplade till bildens innehåll och kopieras när en bild klonas. Aspose.Slides erbjuder också dedikerade API:er för [presentation notes](/slides/sv/cpp/presentation-notes/) och [presentation comments](/slides/sv/cpp/presentation-comments/).

Om formatering av anteckningssidan är viktig, verifiera den sammanslagna presentationen eftersom antecknings‑masters är presentations‑nivåobjekt och kan skilja sig mellan källfiler. För granskningsarbetsflöden, verifiera även kommentar‑författare och trådade kommentarer efter kombination av filer från olika författare eller mallar.

### **Bilder, ljud, video, OLE‑objekt och externa länkar**

Bilder kan referera till presentations‑nivåresurser såsom bilder, inbäddat ljud, inbäddad video och OLE‑data. Klona själva bilden istället för att bara kopiera dess synliga former så att Aspose.Slides kan behålla bildens relationer till resurserna.

Inbäddade och länkade resurser bör behandlas olika. En länkad ljud‑, video‑, OLE‑objekt‑ eller hyperlänk‑fil förblir beroende av sitt externa mål; kloning av en bild omvandlar inte en extern länk till inbäddat innehåll. Testa sökvägar och URL:er för länkade resurser i den miljö där den sammanslagna presentationen ska öppnas.

Aspose.Slides spårar automatiskt klonade masters, men detta bör inte betraktas som en generell garanti för att identiska binära resurser från orelaterade källpresentationer alltid dedupliceras. Om filstorlek är viktig, inspektera det sammanslagna paketet och mät resultatet istället för att förlita dig på implicit deduplicering.

### **Inbäddade typsnitt och typsnittstillgänglighet**

Typsnitt hanteras på presentationsnivå. Om typografi måste vara konsekvent över maskiner, anta inte att enbart bildkloning garanterar att varje behövt typsnitt finns tillgängligt i destinationsmiljön. Du kan inspektera inbäddade typsnitt med [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsmanager/getembeddedfonts/) och hantera inbäddning explicit enligt [Embed Fonts in Presentations](/slides/sv/cpp/embedded-font/).

Verifiera också att du har rätt att bädda in de typsnitt som används av källfilerna. Typsnittslicenser kan begränsa inbäddning.

### **Lösenordsskyddade presentationer**

En lösenordsskyddad källa måste öppnas framgångsrikt innan dess bilder kan klonas. Ange lösenordet via [LoadOptions::set_Password](https://reference.aspose.com/slides/sv/cpp/aspose.slides/loadoptions/set_password/).

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");

auto source = System::MakeObject<Presentation>(u"protected.pptx", loadOptions);
```

Att öppna en krypterad källa applicerar inte automatiskt samma skydd på destinationspresentationen. Konfigurera utdata‑skydd separat när det behövs.

### **Stora presentationer och minnesanvändning**

Stora presentationer som innehåller högupplösta bilder, ljud, video eller andra stora binära objekt kan förbruka betydande minne. [LoadOptions::set_BlobManagementOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides/loadoptions/set_blobmanagementoptions/) ger kontroll över BLOB‑hantering och temporära filer. Se [Manage Presentation BLOBs](/slides/sv/cpp/manage-blob/) för strategier för stora filer.

För stora filer, föredra inläsning från filsökvägar när det är möjligt, disponera varje källpresentation så snart den har slagits samman och undvik att spara mellansteg upprepade gånger om inte arbetsflödet kräver checkpoint‑punkter.

### **Trådsäkerhet**

Ladda inte, modifiera inte, spara inte eller klona inte samma [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/)‑instans samtidigt från flera trådar. Håll varje presentationsinstans begränsad till en sammanslagningsoperation. Om du parallelliserar oberoende jobb, använd oberoende presentationsinstanser och följ [Aspose.Slides multithreading guidance](/slides/sv/cpp/multithreading/).

## **FAQ**

**Hur behåller jag varje källpresentationens ursprungliga design?**

Använd [AddClone](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidecollection/addclone/) utan att ange ett destinations‑master eller layout. Aspose.Slides kan automatiskt klona käll‑mastern när den behövs av den importerade bilden.

**Hur får jag importerade bilder att använda destinations‑temat?**

Använd overloaden som accepterar ett destinations‑master. Skicka ett master‑objekt från destinationspresentationen, inte från källan. Aspose.Slides försöker kartlägga varje källbild till en lämplig layout under den mastern.

**När bör jag använda en specifik destinations‑layout istället för ett destinations‑master?**

Använd en specifik layout när varje importerad bild ska använda en känd layout. Använd ett master när du vill att Aspose.Slides ska välja bland masterns layouter baserat på käll‑layoutens typ eller namn.

**Kan presentationer med olika bildstorlekar slås samman?**

Ja, men bildinnehållet redesignas inte automatiskt för destinationsdimensionerna. Ändra storlek på källpresentationen först när du behöver förutsägbar placering, till exempel med [SlideSize::SetSize](https://reference.aspose.com/slides/sv/cpp/aspose.slides/slidesize/setsize/) och [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/sv/cpp/aspose.slides/slidesizescaletype/).


**Kan jag slå samman PPT, PPTX och ODP‑presentationer till en fil?**

Ja. Läs in varje källpresentation, klona de erforderliga bilderna till en destination och spara destinationen i ett stödformat. Eftersom presentationsformaten inte stödjer exakt samma funktionsuppsättning, verifiera komplext innehåll efter kors‑format‑sammanfogning. Se [Supported File Formats](/slides/sv/cpp/supported-file-formats/).

**Bevaras källavsnitt automatiskt?**

Inte av en grundläggande loop som bara klonar bilder. Återskapa de nödvändiga avsnitten i destinationen och använd avsnitt‑overloaden av [AddClone](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidecollection/addclone/) när avsnittsstruktur måste bevaras.

**Bevaras talarnoteringar och kommentarer?**

De kopieras med den klonade bilden. För arbetsflöden som beror på antecknings‑master‑stil, kommentar‑författare eller trådade granskningsdata, verifiera det sammanslagna resultatet eftersom dessa scenarier involverar både presentations‑ och bildnivåstrukturer.

**Vad händer med ljud, video, OLE‑objekt och hyperlänkar?**

Inbäddat innehåll tas med som en del av den klonade bildens resursrelationer. Externa länkar förblir externa, så deras mål‑filer eller URL:er måste fortfarande vara tillgängliga efter sammanslagning.

**Garanti för att inbäddade typsnitt från alla källor finns i den sammanslagna presentationen?**

Lita inte på enbart bildkloning för typsnittsutplacering. Inspektera destinationens inbäddade typsnitt och hantera typsnittsinbäddning eller extern typsnittstillgänglighet explicit när typografi är viktig.

**Hur slår jag ihop en lösenordsskyddad fil?**

Öppna den med rätt [LoadOptions::set_Password](https://reference.aspose.com/slides/sv/cpp/aspose.slides/loadoptions/set_password/), klona sedan dess bilder som vanligt. Utdata‑skydd konfigureras separat.

**Hur hanterar jag mycket stora presentationer?**

Använd BLOB‑hantering när stora binära objekt dominerar minnesanvändning, föredra inläsning från filsökväg för mycket stora filer, disponera källpresentationer snabbt och spara slutresultatet endast när det behövs.

**Kan jag klona bilder från flera trådar?**

Använd inte en och samma [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/)‑instans samtidigt från flera trådar. Håll varje sammanslagningsoperation isolerad till sina egna presentationsinstanser.