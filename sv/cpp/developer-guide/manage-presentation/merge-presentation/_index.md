---
title: "Effektiv sammanslagning av presentationer i C++"
linktitle: "Sammanslå presentationer"
type: docs
weight: 40
url: /sv/cpp/merge-presentation/
keywords:
- "sammanfoga PowerPoint"
- "sammanfoga presentationer"
- "sammanfoga bilder"
- "sammanfoga PPT"
- "sammanfoga PPTX"
- "sammanfoga ODP"
- "kombinera PowerPoint"
- "kombinera presentationer"
- "kombinera bilder"
- "kombinera PPT"
- "kombinera PPTX"
- "kombinera ODP"
- "C++"
- "Aspose.Slides"
description: "Lär dig hur du sammanslår PowerPoint och OpenDocument-presentationer i C++ genom att klona bilder, styra masters och layouter, ändra storlek på bildinnehåll, bevara sektioner och hantera skyddade eller stora filer."
---
## **Översikt**

Aspose.Slides for C++ sammanslår presentationer genom att klona bilder från en [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) till en annan. Huvudoperationen är [ISlideCollection::AddClone](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidecollection/addclone/), som kan bevara källbildens formatering eller fästa den klonade bilden på ett master‑ eller layout‑objekt i mål‑presentationen.

Denna artikel täcker de vanligaste sammanslagningsarbetsflödena:

- slå samman alla bilder och bevara deras källformat;
- slå samman utvalda bilder;
- tillämpa ett master‑objekt från mål‑presentationen;
- tillämpa ett specifikt layout‑objekt från mål‑presentationen;
- normalisera olika bildstorlekar före sammanslagning;
- lägga till klonade bilder i ett avsnitt;
- slå samman flera presentationer i ett komplett arbetsflöde;
- hantera masters, resurser, anteckningar, kommentarer, media, teckensnitt, lösenord, stora filer och multitrådningsaspekter.

## **Hur bildkloning påverkar masters och layouter**

En bild ärver mycket av sitt utseende från sin layout och master. Av den anledningen avgör vilken överlagring av kloning du väljer hur den sammanslagna bilden integreras i mål‑presentationen.

Använd [ISlideCollection::AddClone](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidecollection/addclone/) på ett av följande sätt:

- `AddClone(sourceSlide)` — bevara källbildens layout och formatering. Vid behov kan käll‑mastern klonas automatiskt in i mål‑presentationen. Aspose.Slides spårar automatiskt klonade masters så att upprepade bilder som använder samma käll‑master inte får den klonad flera gånger.
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — fästa den klonade bilden på ett specifikt destination‑[IMasterSlide](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imasterslide/). Aspose.Slides söker efter en matchande layout under den mastern genom layout‑typ eller namn.
- `AddClone(sourceSlide, destinationLayout)` — fästa den klonade bilden direkt på ett specifikt destination‑[ILayoutSlide](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ilayoutslide/).

Den master eller layout som skickas till en `AddClone`‑överlagring måste tillhöra **mål**‑presentationen, inte käll‑presentationen.

## **Slå samman hela presentationer och bevara källformat**

Den enklaste sammanslagningen kopierar varje bild från käll‑presentationen till mål‑presentationen. Detta är det lämpliga valet när de importerade bilderna ska behålla sitt ursprungliga tema, master och layout‑relationer.

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

Den resulterande presentationen kan innehålla flera masters när käll‑ och mål‑presentationerna använder olika designer. Detta är förväntat när källformatet medvetet bevaras.

## **Slå samman utvalda bilder**

Du behöver inte klona varje bild. Följande exempel importerar endast utvalda bildindex från käll‑presentationen.

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

## **Slå samman bilder med ett mål‑master**

Använd överlagringen [AddClone(ISlide, IMasterSlide, bool)](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidecollection/addclone/) när importerade bilder ska följa en master som redan finns i mål‑presentationen.

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

Använd `false` när du vill att sammanslagningen ska misslyckas i stället för att lägga till en ytterligare layout i mål‑mastern.

## **Slå samman bilder med en specifik mål‑layout**

Använd överlagringen [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidecollection/addclone/) när du exakt vet vilken mål‑layout de importerade bilderna ska använda.

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

Att tillämpa en mål‑layout förändrar den ärvda layout‑relationen; den omformar inte källbildens innehåll. Om käll‑ och mål‑layouter har olika platshållarstrukturer, inspektera resultatet för att bekräfta att den ärvda formateringen och platshållarbeteendet är lämpliga.

## **Slå samman presentationer med olika bildstorlekar**

Presentationer med olika bilddimensioner kan slås samman, men att klona en bild till en presentation med annan bildstorlek omformar inte automatiskt innehållet för den nya dukstorleken. Former kan därför visas förskjutna, skalade oväntat eller utanför den synliga bildytan.

Ett praktiskt tillvägagångssätt är att ändra storlek på käll‑presentationen innan kloning. Metoden [SlideSize::SetSize](https://reference.aspose.com/slides/sv/cpp/aspose.slides/slidesize/setsize/) kan skala befintligt innehåll samtidigt som bilddimensionerna ändras. [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/sv/cpp/aspose.slides/slidesizescaletype/) skalar innehållet så att det passar i den begärda storleken.

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

Att ändra storlek förändrar käll‑presentationens objekt i minnet. Om du behöver den ursprungliga käll‑presentationen oförändrad för andra operationer, öppna en separat instans för sammanslagningen.

## **Slå samman bilder i ett presentations‑avsnitt**

Den grundläggande bildklonings‑loopen återskapar inte käll‑presentationens avsnittshierarki. Om avsnitt är viktiga i utdata, skapa eller välj avsnitt i mål‑presentationen och klona bilderna explicit med [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidecollection/addclone/).

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

De klonade bilderna läggs till i det angivna mål‑avsnittet. För att bevara flera käll‑avsnitt, återställ dessa avsnitt i mål‑presentationen och mappa varje käll‑bild till motsvarande mål‑avsnitt.

## **Slå samman flera presentationer på ett säkert sätt**

Det följande end‑to‑end‑exemplet använder den första presentationen som mål, normaliserar bildstorleken för varje ytterligare källa, håller varje källa öppen endast medan den kopieras och sparar den slutliga filen en gång.

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

Detta är en användbar utgångspunkt för att bevara källformateringen på importerade bilder. Om ditt resultat måste använda ett enskilt mål‑tema, ersätt det enkla anropet `AddClone(slide)` med den lämpliga mål‑master‑ eller mål‑layout‑överlagringen som visades tidigare.

## **Praktiska överväganden**

### **Masters, layouter och formateringsintegritet**

Standardkloning av bilder kan automatiskt föra in en behövd käll‑master i mål‑presentationen. Aspose.Slides håller ett internt register för automatiskt klonade masters för att undvika att samma master klonas flera gånger. Manuellt klonade masters spåras inte av det registret, så undvik att förklona masters om du inte behöver explicit kontroll över master‑strukturen.

Anta inte att två masters eller layouter med samma namn är visuellt likvärdiga. Om en företagsmall måste styra det slutliga utseendet, välj ett mål‑master‑ eller layout‑objekt explicit och verifiera resultatet efter sammanslagning.

### **Anteckningar och kommentarer**

Talarnoteringar och bildkommentarer är knutna till bildinnehållet och kopieras när en bild klonas. Aspose.Slides erbjuder även dedikerade API:er för [presentation notes](https://docs.aspose.com/slides/sv/cpp/presentation-notes/) och [presentation comments](https://docs.aspose.com/slides/sv/cpp/presentation-comments/).

Om formatering av notessidan är viktig, verifiera den sammanslagna presentationen eftersom notemaster‑objekt är på presentationsnivå och kan skilja sig mellan källfiler. För granskningsarbetsflöden, verifiera även kommentarförfattare och trådade kommentarer efter att filer från olika författare eller mallar kombinerats.

### **Bilder, ljud, video, OLE‑objekt och externa länkar**

Bilder kan referera till resurser på presentationsnivå såsom bilder, inbäddat ljud, inbäddad video och OLE‑data. Klona hela bilden istället för att bara kopiera de synliga formerna så att Aspose.Slides kan bevara bildens relationer till dess resurser.

Inbäddade och länkade resurser bör behandlas separat. En länkad ljud‑, video‑, OLE‑objekt‑ eller hyperlänk‑fil förblir beroende av sitt externa mål; att klona en bild gör inte en extern länk till inbäddat innehåll. Testa länkriktiga sökvägar och URL:er i den miljö där den sammanslagna presentationen kommer att öppnas.

Aspose.Slides spårar automatiskt klonade masters, men detta bör inte betraktas som en generell garanti för att identiska binära resurser från orelaterade källpresentationer alltid dedupliceras. Om utfilens storlek är viktig, inspektera det sammanslagna paketet och mät resultatet i stället för att förlita dig på implicit deduplicering.

### **Inbäddade teckensnitt och teckensnittstillgänglighet**

Teckensnitt hanteras på presentationsnivå. Om typografi måste vara konsekvent mellan maskiner, anta inte att bildkloning ensamt garanterar att varje nödvändigt teckensnitt finns tillgängligt i mål‑miljön. Du kan inspektera inbäddade teckensnitt med [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsmanager/getembeddedfonts/) och hantera inbäddning explicit enligt [Embed Fonts in Presentations](https://docs.aspose.com/slides/sv/cpp/embedded-font/).

Verifiera även att du har rätt att bädda in de teckensnitt som används i källfilerna. Teckensnittslicenser kan begränsa inbäddning.

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

Att öppna en krypterad källa applicerar inte automatiskt samma skydd på mål‑presentationen. Konfigurera eventuell utdata‑skydd separat när det behövs.

### **Stora presentationer och minnesanvändning**

Stora presentationer som innehåller högupplösta bilder, ljud, video eller andra stora binära objekt kan förbruka avseväsentligt minne. [LoadOptions::set_BlobManagementOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides/loadoptions/set_blobmanagementoptions/) ger kontroll över BLOB‑hantering och temporära filer. Se [Manage Presentation BLOBs](https://docs.aspose.com/slides/sv/cpp/manage-blob/) för strategier för stora filer.

För stora filer, föredra laddning från filvägar när det är möjligt, frigör varje käll‑presentation så snart den har slagits samman och undvik att spara mellansteg upprepade gånger om inte arbetsflödet kräver checkpoints.

### **Trådsäkerhet**

Läs inte, modifiera, spara eller klona samma [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/)‑instans parallellt från flera trådar. Håll varje presentationsinstans begränsad till en sammanslagningsoperation. Om du parallelliserar oberoende jobb, använd separata presentationsinstanser och följ [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/sv/cpp/multithreading/).

## **FAQ**

**Hur behåller jag varje käll‑presentations ursprungliga design?**

Använd [`AddClone(sourceSlide)`](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidecollection/addclone/) utan att ange ett mål‑master eller layout. Aspose.Slides kan automatiskt klona käll‑mastern när den behövs av den importerade bilden.

**Hur får jag att importerade bilder använder mål‑temat?**

Använd överlagringen som accepterar ett mål‑master. Skicka en master från mål‑presentationen, inte från käll‑presentationen. Aspose.Slides försöker mappa varje käll‑bild till en lämplig layout under den mastern.

**När bör jag använda en specifik mål‑layout istället för ett mål‑master?**

Använd en specifik layout när varje importerad bild ska använda en känd layout. Använd ett master när du vill att Aspose.Slides ska välja bland masterns layouter baserat på käll‑layoutens typ eller namn.

**Kan presentationer med olika bildstorlekar slås samman?**

Ja, men bildinnehållet omformas inte automatiskt för mål‑dimensionalerna. Ändra storlek på käll‑presentationen först när du behöver förutsägbara placeringar, till exempel med [SlideSize::SetSize](https://reference.aspose.com/slides/sv/cpp/aspose.slides/slidesize/setsize/) och [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/sv/cpp/aspose.slides/slidesizescaletype/).


**Kan jag slå samman PPT, PPTX och ODP‑presentationer till en fil?**

Ja. Läs in varje käll‑presentation, klona de nödvändiga bilderna till en mål‑presentation och spara målet i ett stödformat. Eftersom presentationsformaten inte stödjer exakt samma funktionsuppsättning, verifiera komplext innehåll efter kors‑format‑sammanfogningar. Se [Supported File Formats](https://docs.aspose.com/slides/sv/cpp/supported-file-formats/).

**Behåller avsnitten i käll‑presentationen sig automatiskt?**

Inte med en grundläggande slinga som bara klonar bilder. Återskapa de nödvändiga avsnitten i mål‑presentationen och använd avsnitts‑överlagringen av [AddClone](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidecollection/addclone/) när avsnittsstrukturen måste bevaras.

**Behålls talarnoteringar och kommentarer?**

De kopieras med den klonade bilden. För arbetsflöden som är beroende av notemaster‑stil, kommentar‑författare eller trådade granskningsdata, verifiera det sammanslagna resultatet eftersom dessa scenarier involverar strukturer på presentationsnivå såväl som bildnivå.

**Vad händer med ljud, video, OLE‑objekt och hyperlänkar?**

Inbäddat innehåll transporteras som en del av den klonade bildens resursrelationer. Externa länkar förblir externa, så deras mål‑filer eller URL:er måste fortfarande vara tillgängliga efter sammanslagning.

**Garanteras inbäddade teckensnitt från varje källa i den sammanslagna presentationen?**

Lita inte påbart på enbart bildkloning för teckensnittsdistribution. Inspektera mål‑presentationens inbäddade teckensnitt och hantera teckensnittsinbäddning eller extern teckensnittstillgänglighet explicit när typografi är viktig.

**Hur slår jag samman en lösenordsskyddad fil?**

Öppna den med rätt [LoadOptions::set_Password](https://reference.aspose.com/slides/sv/cpp/aspose.slides/loadoptions/set_password/), klona sedan dess bilder som vanligt. Utdata‑skydd konfigureras separat.

**Hur hanterar jag mycket stora presentationer?**

Använd BLOB‑hantering när stora binära objekt dominerar minnesanvändning, föredra fil‑väg‑laddning för mycket stora filer, frigör käll‑presentationer omedelbart och spara slutresultatet endast när det behövs.

**Kan jag klona bilder från flera trådar?**

Använd inte en och samma [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/)‑instans samtidigt från flera trådar. Håll varje sammanslagningsoperation isolerad till sina egna presentations‑instanser.