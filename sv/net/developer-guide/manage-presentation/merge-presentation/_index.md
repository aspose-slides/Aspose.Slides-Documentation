---
title: Effektivt slå samman presentationer i .NET
linktitle: Slå samman presentationer
type: docs
weight: 40
url: /sv/net/merge-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "Lär dig hur du slår samman PowerPoint- och OpenDocument-presentationer i .NET genom att klona bilder, kontrollera masters och layouter, ändra storlek på bildinnehåll, bevara avsnitt och hantera skyddade eller stora filer."
---
## **Översikt**

Aspose.Slides för .NET sammanslår presentationer genom att klona bilder från en [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/) till en annan. Huvudoperationen är [ISlideCollection.AddClone](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection/addclone/), vilket kan bevara källbildens formatering eller fästa den klonade bilden till ett master‑ eller layout i destinationspresentationen.

Denna artikel täcker de vanligaste sammanslagningsarbetsflödena:

- klona alla bilder samtidigt som deras källformatering bevaras;
- klona utvalda bilder;
- tillämpa ett master från destinationspresentationen;
- tillämpa en specifik layout från destinationspresentationen;
- normalisera olika bildstorlekar innan sammanslagning;
- lägga till klonade bilder i ett avsnitt;
- sammanslå flera presentationer i ett end‑to‑end‑arbetsflöde;
- hantera masters, resurser, anteckningar, kommentarer, media, teckensnitt, lösenord, stora filer och multitrådningsfrågor.

## **Hur bildkloning påverkar masters och layouter**

En bild ärver mycket av sitt utseende från sin layout och master. Av den anledningen bestämmer den klonings‑overload du väljer hur den sammanslagna bilden integreras i destinationspresentationen.

Använd [ISlideCollection.AddClone](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection/addclone/) på ett av följande sätt:

- `AddClone(sourceSlide)` — bevara källbildens layout och formatering. Vid behov kan käll‑mastern klonas automatiskt in i destinationspresentationen. Aspose.Slides spårar automatiskt klonade masters så upprepade bilder som använder samma käll‑master inte klonar den flera gånger.
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — fästa den klonade bilden till ett specifikt destinations‑[IMasterSlide](https://reference.aspose.com/slides/sv/net/aspose.slides/imasterslide/). Aspose.Slides söker efter en matchande layout under den mastern efter layout‑typ eller namn.
- `AddClone(sourceSlide, destinationLayout)` — fästa den klonade bilden direkt till en specifik destinations‑[ILayoutSlide](https://reference.aspose.com/slides/sv/net/aspose.slides/ilayoutslide/).

Mastern eller layouten som skickas till en `AddClone`‑overload måste tillhöra **destinations**‑presentationen, inte källpresentationen.

## **Sammanfoga hela presentationer och bevara källformatering**

Den enklaste sammanslagningen kopierar varje bild från källpresentationen till destinationspresentationen. Detta är det lämpliga valet när de importerade bilderna ska behålla sitt ursprungliga tema, master och layout‑relationer.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide);
}

destination.Save("merged.pptx", SaveFormat.Pptx);
```

Den resulterande presentationen kan innehålla flera masters när käll‑ och destinationspresentationen använder olika designer. Detta är förväntat när källformatering uttryckligen bevaras.

## **Klona utvalda bilder**

Du behöver inte klona varje bild. Följande exempel importerar endast utvalda bild‑index från källpresentationen.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var slideIndexes = new[] { 0, 2, 4 };

foreach (var index in slideIndexes)
{
    destination.Slides.AddClone(source.Slides[index]);
}

destination.Save("merged-selected-slides.pptx", SaveFormat.Pptx);
```

Validera bild‑index innan kloning när de kommer från användarinmatning eller extern konfiguration.

## **Klona bilder med ett destinations‑master**

Använd [AddClone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection/addclone/)‑overload när importerade bilder ska följa ett master som redan finns i destinationspresentationen.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var destinationMaster = destination.Masters[0];

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, destinationMaster, allowCloneMissingLayout: true);
}

destination.Save("merged-with-destination-master.pptx", SaveFormat.Pptx);
```

Aspose.Slides väljer en lämplig layout under den specificerade mastern genom att matcha källlayoutens typ eller namn. Om ingen passande layout finns och `allowCloneMissingLayout` är `true`, klonas källlayouten så att bilden kan läggas till. Om den är `false` kastas ett [PptxEditException](https://reference.aspose.com/slides/sv/net/aspose.slides/pptxeditexception/).

Använd `false` när du vill att sammanslagningen ska misslyckas istället för att införa en ytterligare layout i destinations‑mastern.

## **Klona bilder med en specifik destinations‑layout**

Använd [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection/addclone/)‑overload när du exakt vet vilken destinations‑layout de importerade bilderna ska använda.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var destinationLayout = destination.LayoutSlides[0];

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, destinationLayout);
}

destination.Save("merged-with-destination-layout.pptx", SaveFormat.Pptx);
```

Att tillämpa en destinations‑layout ändrar den ärvda layout‑relationen; den omdesignar inte källbildens innehåll. Om käll‑ och destinations‑layout har olika platshållarstrukturer, inspektera resultatet för att bekräfta att den ärvda formateringen och platshållarbeteendet är lämpliga.

## **Sammanfoga presentationer med olika bildstorlekar**

Presentationer med olika bilddimensioner kan slås ihop, men att klona en bild till en presentation med en annan bildstorlek omdesignar inte automatiskt innehållet för den nya ytan. Former kan därför visas förskjutna, skalerade oväntat eller utanför den synliga bildytan.

En praktisk metod är att ändra storlek på källpresentationen innan kloning. Metoden [SlideSize.SetSize](https://reference.aspose.com/slides/sv/net/aspose.slides/slidesize/setsize/) kan skala befintligt innehåll samtidigt som bilddimensionerna ändras. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/sv/net/aspose.slides/slidesizescaletype/) skalar innehållet så att det passar den begärda storleken.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

if (source.SlideSize.Size.Width != destination.SlideSize.Size.Width || 
    source.SlideSize.Size.Height != destination.SlideSize.Size.Height)
{
    source.SlideSize.SetSize(
        destination.SlideSize.Size.Width, 
        destination.SlideSize.Size.Height, 
        SlideSizeScaleType.EnsureFit);
}

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide);
}

destination.Save("merged-same-slide-size.pptx", SaveFormat.Pptx);
```

Att ändra storlek förändrar källpresentationens objekt i minnet. Om du behöver den ursprungliga källpresentationen orörd för andra operationer, öppna en separat instans för sammanslagningen.

## **Klona bilder till ett presentationsavsnitt**

Den grundläggande bild‑kloningsloopen återupptar inte källpresentationens avsnittshierarki. Om avsnitt är viktiga i utdata, skapa eller välj avsnitt i destinationspresentationen och klona bilder till dem explicit med [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection/addclone/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var importedSection = destination.Sections.AppendEmptySection("Imported slides");

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, importedSection);
}

destination.Save("merged-with-section.pptx", SaveFormat.Pptx);
```

De klonade bilderna läggs till i det specificerade destinations‑avsnittet. För att bevara flera källavsnitt, iterera över [Presentation.Sections](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/sections/), hämta varje källavsnitts aktuella bilder med [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/sv/net/aspose.slides/isection/getslideslistofsection/), återskapa avsnitten i destinationen och klona varje returnerad bild till motsvarande destinations‑avsnitt. Se [Manage Slide Sections](/slides/sv/net/slide-section/) för ett komplett exempel på avsnitt‑enumeration, inklusive tomma avsnitt och strukturella förändringar.

## **Sammanslå flera presentationer på ett säkert sätt**

Följande end‑to‑end‑exempel använder den första presentationen som destination, normaliserar bildstorleken för varje ytterligare källa, håller varje källa öppen endast medan den kopieras och sparar den slutliga filen en gång.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var inputFiles = new[] { "part1.pptx", "part2.pptx", "part3.pptx" };

using var merged = new Presentation(inputFiles[0]);

for (var fileIndex = 1; fileIndex < inputFiles.Length; fileIndex++)
{
    using var source = new Presentation(inputFiles[fileIndex]);

    if (source.SlideSize.Size.Width != merged.SlideSize.Size.Width || 
        source.SlideSize.Size.Height != merged.SlideSize.Size.Height)
    {
        source.SlideSize.SetSize(
            merged.SlideSize.Size.Width, 
            merged.SlideSize.Size.Height, 
            SlideSizeScaleType.EnsureFit);
    }

    foreach (var slide in source.Slides)
    {
        merged.Slides.AddClone(slide);
    }
}

merged.Save("merged.pptx", SaveFormat.Pptx);
```

Detta är en användbar baslinje för att bevara källformateringen i importerade bilder. Om din utdata måste använda ett enda destinations‑tema, ersätt det enkla `AddClone(slide)`‑anropet med den lämpliga destinations‑master‑ eller destinations‑layout‑overload som visades tidigare.

## **Praktiska överväganden**

### **Masters, layouter och formateringsprecision**

Standard‑bildkloning kan automatiskt föra in ett nödvändigt käll‑master i destinationspresentationen. Aspose.Slides har ett internt register för automatiskt klonade masters för att undvika att samma master klonas flera gånger. Manuellt klonade masters spåras inte av det registret, så undvik förkloning av masters om du inte behöver explicit kontroll över master‑strukturen.

Anta inte att två masters eller layouter med samma namn är visuellt identiska. Om en företagsmall måste styra det slutliga utseendet, välj ett destinations‑master eller en layout explicit och verifiera resultatet efter sammanslagning.

### **Anteckningar och kommentarer**

Talarnoteringar och bildkommentarer är associerade med bildinnehållet och kopieras när en bild klonas. Aspose.Slides exponerar även dedikerade API:er för [presentation notes](/slides/sv/net/presentation-notes/) och [presentation comments](/slides/sv/net/presentation-comments/).

Om formatering av noteringssidan är viktig, verifiera den sammanslagna presentationen eftersom notes‑masters är objekt på presentationsnivå och kan skilja sig mellan källfiler. För granskningsarbetsflöden, verifiera även kommentar‑författare och trådade kommentarer efter kombination av filer från olika författare eller mallar.

### **Bilder, ljud, video, OLE‑objekt och externa länkar**

Bilder kan referera till resurser på presentationsnivå såsom bilder, inbäddat ljud, inbäddad video och OLE‑data. Klona själva bilden istället för att bara kopiera dess synliga former så att Aspose.Slides kan bevara bildens relationer till dess resurser.

Inbäddade och länkade resurser bör behandlas olika. En länkad ljud‑, video‑, OLE‑objekt‑ eller hyperlänk förblir beroende av sin externa målfil; att klona en bild gör inte en extern länk till inbäddat innehåll. Testa sökvägar och URL:er för länkade resurser i den miljö där den sammanslagna presentationen kommer att öppnas.

Aspose.Slides spårar explicit automatiskt klonade masters, men detta bör inte betraktas som en generell garanti för att identiska binära resurser från orelaterade källpresentationer alltid dedupliceras. Om filstorlek är viktig, inspektera det sammanslagna paketet och mät resultatet i stället för att förlita dig på implicit deduplicering.

### **Inbäddade teckensnitt och teckensnittstillgänglighet**

Teckensnitt hanteras på presentationsnivå. Om typografi måste förbli konsekvent över maskiner, anta inte att bildkloning ensam garanterar att varje nödvändigt teckensnitt finns tillgängligt i destinationsmiljön. Du kan inspektera inbäddade teckensnitt med [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/sv/net/aspose.slides/fontsmanager/getembeddedfonts/) och hantera inbäddning explicit som beskrivet i [Embed Fonts in Presentations](/slides/sv/net/embedded-font/).

Verifiera också att du har tillstånd att inbädda de teckensnitt som används i källfilerna. Teckensnittslicenser kan begränsa inbäddning.

### **Lösenordsskyddade presentationer**

En lösenordsskyddad källa måste öppnas framgångsrikt innan dess bilder kan klonas. Ange lösenordet via [LoadOptions.Password](https://reference.aspose.com/slides/sv/net/aspose.slides/loadoptions/password/).

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "YOUR_PASSWORD" };

using var source = new Presentation("protected.pptx", loadOptions);
```

Att öppna en krypterad källa applicerar inte automatiskt samma skydd på destinationspresentationen. Konfigurera utdata‑skydd separat när det krävs.

### **Stora presentationer och minnesanvändning**

Stora presentationer som innehåller högupplösta bilder, ljud, video eller andra stora binära objekt kan konsumera betydande minne. [LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/sv/net/aspose.slides/loadoptions/blobmanagementoptions/) ger kontroller för BLOB‑hantering och temporär‑filanvändning. Se [Manage Presentation BLOBs](/slides/sv/net/manage-blob/) för strategier för stora filer.

För stora filer, föredra inläsning från filsökvägar när det är möjligt, disponera varje källpresentation så snart den har slutfört sammanslagningen och undvik att spara mellanresultat upprepade gånger om inte arbetsflödet kräver kontrollpunkter.

### **Trådsäkerhet**

Ladda, modifiera, spara eller klona inte samma [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/)‑instans samtidigt från flera trådar. Håll varje presentationsinstans begränsad till en sammanslagningsoperation. Om du parallelliserar oberoende jobb, använd oberoende presentationsinstanser och följ [Aspose.Slides multithreading guidance](/slides/sv/net/multithreading/).

## **FAQ**

**Hur behåller jag varje källpresentationens ursprungliga design?**

Använd [AddClone](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection/addclone/) utan att ange ett destinations‑master eller en layout. Aspose.Slides kan automatiskt klona käll‑mastern när den behövs av den importerade bilden.

**Hur får jag importerade bilder att använda destinations‑temat?**

Använd den overload som accepterar ett destinations‑master. Skicka ett master från destinationspresentationen, inte från källan. Aspose.Slides försöker mappa varje källbild till en lämplig layout under den mastern.

**När bör jag använda en specifik destinations‑layout istället för ett destinations‑master?**

Använd en specifik layout när varje importerad bild ska använda en känd layout. Använd ett master när du vill att Aspose.Slides ska välja bland masterns layouter baserat på källlayoutens typ eller namn.

**Kan presentationer med olika bildstorlekar slås ihop?**

Ja, men bildinnehållet omdesignas inte automatiskt för destinationsdimensionerna. Ändra storlek på källpresentationen först när du behöver förutsägbar placering, exempelvis med [SlideSize.SetSize](https://reference.aspose.com/slides/sv/net/aspose.slides/slidesize/setsize/) och [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/sv/net/aspose.slides/slidesizescaletype/).

**Kan jag slå samman PPT-, PPTX- och ODP-presentationer till en fil?**

Ja. Läs in varje källpresentation, klona de nödvändiga bilderna till en destination och spara destinationen i ett stödformat. Eftersom presentationsformaten inte stödjer exakt samma funktionsuppsättning, verifiera komplext innehåll efter kors‑format‑sammanfogning. Se [Supported File Formats](/slides/sv/net/supported-file-formats/).

**Behålls källavsnitt automatiskt?**

Inte av en grundläggande loop som bara klonar bilder. Återskapa de nödvändiga avsnitten i destinationen och använd avsnitts‑overloaden av [AddClone](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection/addclone/) när avsnittsstruktur måste bevaras.

**Behålls talaranteckningar och kommentarer?**

De kopieras med den klonade bilden. För arbetsflöden som är beroende av notes‑master‑stil, kommentar‑författare eller trådade granskningsdata, verifiera det sammanslagna resultatet eftersom dessa scenarier också involverar strukturer på presentationsnivå samt bildinnehåll.

**Vad händer med ljud, video, OLE‑objekt och hyperlänkar?**

Inbäddat innehåll för medföljer som en del av den klonade bildens resursrelationer. Externa länkar förblir externa, så deras mål‑filer eller URL:er måste fortfarande vara tillgängliga efter sammanslagning.

**Garanti för att inbäddade teckensnitt från varje källa finns i den sammanslagna presentationen?**

Lita inte på enbart bildkloning för teckensnittsdistribution. Inspektera destinationens inbäddade teckensnitt och hantera inbäddning eller extern teckensnittstillgänglighet explicit när typografi är viktig.

**Hur slår jag samman en lösenordsskyddad fil?**

Öppna den med rätt [LoadOptions.Password](https://reference.aspose.com/slides/sv/net/aspose.slides/loadoptions/password/), klona sedan dess bilder som vanligt. Utdata‑skydd konfigureras separat.

**Hur ska jag hantera mycket stora presentationer?**

Använd BLOB‑hantering när stora binära objekt dominerar minnesanvändning, föredra filsökvägs‑inläsning för mycket stora filer, disponera källpresentationer omedelbart och spara det slutliga resultatet endast när det behövs.

**Kan jag slå samman bilder från flera trådar?**

Använd inte en och samma [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/)‑instans samtidigt från flera trådar. Håll varje sammanslagningsoperation isolerad till sina egna presentationsinstanser.