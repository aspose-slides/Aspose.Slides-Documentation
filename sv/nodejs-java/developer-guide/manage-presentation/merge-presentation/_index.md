---
title: Effektivt slå samman presentationer i JavaScript
linktitle: Slå samman presentationer
type: docs
weight: 40
url: /sv/nodejs-java/merge-presentation/
keywords:
- slå samman PowerPoint
- slå samman presentationer
- slå samman bilder
- slå samman PPT
- slå samman PPTX
- slå samman ODP
- kombinera PowerPoint
- kombinera presentationer
- kombinera bilder
- kombinera PPT
- kombinera PPTX
- kombinera ODP
- Node.js
- JavaScript
- Aspose.Slides
description: "Lär dig hur du slår samman PowerPoint- och OpenDocument-presentationer i JavaScript genom att klona bilder, styra master och layouter, ändra storlek på bildinnehållet, bevara sektioner samt hantera skyddade eller stora filer."
---
## **Översikt**

Aspose.Slides för Node.js via Java sammanslår presentationer genom att klona bilder från en [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/) till en annan. Huvudoperationen är [SlideCollection.addClone](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-), som kan bevara källbildens formatering eller fästa den klonade bilden till en master eller layout i målpresentationen.

Den här artikeln täcker de vanligaste sammanslagningsarbetsflödena:

- sammanfoga alla bilder samtidigt som deras källformatering bevaras;
- sammanfoga valda bilder;
- tillämpa en master från målpresentationen;
- tillämpa en specifik layout från målpresentationen;
- normalisera olika bildstorlekar innan sammanslagning;
- lägga till klonade bilder i en sektion;
- sammanfoga flera presentationer i ett komplett arbetsflöde;
- hantera master, resurser, anteckningar, kommentarer, media, typsnitt, lösenord, stora filer och multitrådningsfrågor.

## **Hur bildkloning påverkar master och layouter**

En bild ärver mycket av sitt utseende från sin layout och master. Av den anledningen avgör det klonings‑overload du väljer hur den sammanslagna bilden integreras i målpresentationen.

Använd [SlideCollection.addClone](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slidecollection/) på ett av följande sätt:

- `addClone(sourceSlide)` — bevara källbildens layout och formatering. Vid behov kan källmastern klonas automatiskt in i målpresentationen. Aspose.Slides spårar automatiskt klonade master så att upprepade bilder som använder samma källmaster inte får masterkloning flera gånger.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — fästa den klonade bilden till en specifik mål‑[MasterSlide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/masterslide/). Aspose.Slides letar efter en matchande layout under den mastern efter layouttyp eller namn.
- `addClone(sourceSlide, destinationLayout)` — fästa den klonade bilden direkt till en specifik mål‑[LayoutSlide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/layoutslide/).

Den master eller layout som skickas till ett `addClone`‑overload måste tillhöra **mål**‑presentationen, inte källpresentationen.

## **Sammanfoga hela presentationer och bevara källformatering**

Den enklaste sammanslagningen kopierar varje bild från källpresentationen till målpresentationen. Detta är det lämpliga valet när de importerade bilderna ska behålla sitt ursprungliga tema, master och layout‑relationer.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i));
    }

    destination.save("merged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Den resulterande presentationen kan innehålla flera master när käll‑ och målpresentationen använder olika designer. Detta är förväntat när källformatering medvetet bevaras.

## **Sammanfoga valda bilder**

Du behöver inte klona varje bild. Följande exempel importerar endast utvalda bildindex från källpresentationen.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const slideIndexes = [0, 2, 4];

    for (const index of slideIndexes) {
        destination.getSlides().addClone(source.getSlides().get_Item(index));
    }

    destination.save("merged-selected-slides.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Validera bildindex innan kloning när de kommer från användarinmatning eller extern konfiguration.

## **Sammanfoga bilder med en mål‑master**

Använd overloaden [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) när importerade bilder ska följa en master som redan finns i målpresentationen.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const destinationMaster = destination.getMasters().get_Item(0);

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), destinationMaster, true);
    }

    destination.save("merged-with-destination-master.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Aspose.Slides väljer en lämplig layout under den angivna mastern genom att matcha källlayoutens typ eller namn. Om ingen passande layout finns och `allowCloneMissingLayout` är `true` klonas källayouten så att bilden kan läggas till. Om den är `false` kastas ett [PptxEditException](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pptxeditexception/).

Använd `false` när du vill att sammanslagningen ska misslyckas i stället för att införa en extra layout i mål‑mastern.

## **Sammanfoga bilder med en specifik mål‑layout**

Använd overloaden [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-) när du exakt vet vilken mål‑layout de importerade bilderna ska använda.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const destinationLayout = destination.getLayoutSlides().get_Item(0);

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), destinationLayout);
    }

    destination.save("merged-with-destination-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Att tillämpa en mål‑layout förändrar den ärvda layout‑relationen; den omdesignar inte bildens innehåll. Om käll‑ och mål‑layouter har olika platshållarstrukturer, inspektera resultatet för att bekräfta att den ärvda formateringen och platshållarbeteendet är lämpliga.

## **Sammanfoga presentationer med olika bildstorlekar**

Presentationer med olika bilddimensioner kan sammanslås, men att klona en bild till en presentation med annan bildstorlek redesignar inte automatiskt innehållet för den nya duken. Former kan därför hamna förskjutna, skalade oväntat eller utanför den synliga bildytan.

Ett praktiskt tillvägagångssätt är att ändra storlek på källpresentationen innan kloning. Metoden [SlideSize.setSize](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) kan skala befintligt innehåll samtidigt som bilddimensionerna ändras. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slidesizescaletype/) skalar innehållet så att det får plats inom den begärda storleken.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const sourceSize = source.getSlideSize().getSize();
    const destinationSize = destination.getSlideSize().getSize();
    const sizesDiffer = sourceSize.getWidth() !== destinationSize.getWidth() || 
                        sourceSize.getHeight() !== destinationSize.getHeight();

    if (sizesDiffer) {
        source.getSlideSize().setSize(
            destinationSize.getWidth(), 
            destinationSize.getHeight(), 
            aspose.slides.SlideSizeScaleType.EnsureFit);
    }

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i));
    }

    destination.save("merged-same-slide-size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Att ändra storlek förändrar källpresentationens objekt i minnet. Om du behöver den ursprungliga källpresentationen oförändrad för andra operationer, öppna en separat instans för sammanslagningen.

## **Sammanfoga bilder i en presentationssektion**

Den grundläggande bild‑kloningsloopen återskapar inte källpresentationens sektionshierarki. Om sektioner är viktiga i utdata, skapa eller välj sektioner i målpresentationen och klona bilder explicit till dem med [addClone(Slide, Section)](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-).

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const importedSection = destination.getSections().appendEmptySection("Imported slides");

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), importedSection);
    }

    destination.save("merged-with-section.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

De klonade bilderna läggs till i den angivna målsektionen. För att bevara flera källsektioner, lista [Presentation.getSections](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#getSections), hämta varje källsektionens aktuella bilder med [Section.getSlidesListOfSection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/section/#getSlidesListOfSection), återskapa sektionerna i målpresentationen och klona varje bild till motsvarande målsektion. Se [Hantera bildsektioner](/slides/sv/nodejs-java/slide-section/) för ett komplett exempel på sektion‑enumeration, inklusive tomma sektioner och strukturella ändringar.

## **Sammanfoga flera presentationer på ett säkert sätt**

Det följande end‑to‑end‑exemplet använder den första presentationen som mål, normaliserar bildstorleken för varje ytterligare källa, håller varje källa öppen endast under kopieringen och sparar den slutgiltiga filen en gång.

```javascript
const aspose = require("aspose.slides.via.java");

const inputFiles = ["part1.pptx", "part2.pptx", "part3.pptx"];

const merged = new aspose.slides.Presentation(inputFiles[0]);
try {
    const mergedSize = merged.getSlideSize().getSize();

    for (let fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        const source = new aspose.slides.Presentation(inputFiles[fileIndex]);
        try {
            const sourceSize = source.getSlideSize().getSize();
            const sizesDiffer = sourceSize.getWidth() !== mergedSize.getWidth() || 
                                sourceSize.getHeight() !== mergedSize.getHeight();

            if (sizesDiffer) {
                source.getSlideSize().setSize(
                    mergedSize.getWidth(), 
                    mergedSize.getHeight(), 
                    aspose.slides.SlideSizeScaleType.EnsureFit);
            }

            for (let slideIndex = 0; slideIndex < source.getSlides().size(); slideIndex++) {
                merged.getSlides().addClone(source.getSlides().get_Item(slideIndex));
            }
        } finally {
            source.dispose();
        }
    }

    merged.save("merged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    merged.dispose();
}
```

Detta är ett användbart grundläggande exempel för att bevara källformateringen på importerade bilder. Om ditt resultat måste använda ett enda måltema, ersätt det enkla `addClone(sourceSlide)`‑anropet med den lämpliga mål‑master‑ eller mål‑layout‑overloaden som visas tidigare.

## **Praktiska överväganden**

### **Master, layouter och formateringsnoggrannhet**

Standardkloning av bilder kan automatiskt föra in en nödvändig källmaster i målpresentationen. Aspose.Slides håller ett internt register för automatiskt klonade master för att undvika att samma master klonas flera gånger. Manuellt klonade master spåras inte av registret, så undvik förkloning av master om du inte behöver explicit kontroll över masterstrukturen.

Anta inte att två master eller layouter med samma namn är visuellt identiska. Om ett företagsmall måste styra det slutliga utseendet, välj en mål‑master eller layout explicit och verifiera resultatet efter sammanslagning.

### **Anteckningar och kommentarer**

Talarnoteringar och bildkommentarer är knutna till bildens innehåll och kopieras när en bild klonas. Aspose.Slides erbjuder även dedikerade API:er för [presentationsanteckningar](/slides/sv/nodejs-java/presentation-notes/) och [presentationskommentarer](/slides/sv/nodejs-java/presentation-comments/).

Om formatering på notes‑sidan är viktig, verifiera den sammanslagna presentationen eftersom notes‑master är objekt på presentationsnivå och kan skilja sig mellan källfiler. För granskningsarbetsflöden, verifiera även kommentar‑författare och trådade kommentarer efter sammanslagning av filer från olika författare eller mallar.

### **Bilder, ljud, video, OLE‑objekt och externa länkar**

Bilder kan referera till resurser på presentationsnivå såsom bilder, inbäddat ljud, inbäddad video och OLE‑data. Klona själva bilden istället för att bara kopiera dess synliga former så att Aspose.Slides kan behålla bildens relationer till resurserna.

Inbäddade och länkade resurser bör behandlas olika. En länkad ljud‑, video‑, OLE‑objekt‑ eller hyperlänk‑fil förblir beroende av sin externa mål; kloning av en bild gör inte en extern länk till inbäddat innehåll. Testa länkreferenser och URL:er i den miljö där den sammanslagna presentationen kommer att öppnas.

Aspose.Slides spårar automatiskt klonade master, men detta bör inte ses som en generell garanti för att identiska binära resurser från orelaterade källpresentationer alltid dedupliceras. Om filstorlek är viktig, inspektera det sammanslagna paketet och mät resultatet i stället för att förlita dig på implicit deduplicering.

### **Inbäddade typsnitt och typsnittstillgänglighet**

Typsnitt hanteras på presentationsnivå. Om typografi måste vara konsekvent på olika maskiner, anta inte att kloning av bilder ensam garanterar att varje nödvändigt typsnitt finns tillgängligt i målmiljön. Du kan inspektera inbäddade typsnitt med [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) och hantera inbäddning explicit enligt [Inbädda typsnitt i presentationer](/slides/sv/nodejs-java/embedded-font/).

Verifiera även att du har rätt att inbädda de typsnitt som används i källfilerna. Typsnittslicenser kan begränsa inbäddning.

### **Lösenordsskyddade presentationer**

En lösenordsskyddad källa måste öppnas framgångsrikt innan dess bilder kan klonas. Ange lösenordet via [LoadOptions.setPassword](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/loadoptions/#setPassword-String-).

```javascript
const aspose = require("aspose.slides.via.java");

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

const source = new aspose.slides.Presentation("protected.pptx", loadOptions);
try {
    // Arbeta med den dekrypterade presentationen.
} finally {
    source.dispose();
}
```

Att öppna en krypterad källa applicerar inte automatiskt samma skydd på målpresentationen. Konfigurera skydd för utdata separat när så krävs.

### **Stora presentationer och minnesanvändning**

Stora presentationer som innehåller högupplösta bilder, ljud, video eller andra stora binära objekt kan förbruka betydande minne. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions--) ger kontroller för BLOB‑hantering och temporära filer. Se [Hantera presentations‑BLOB‑ar](/slides/sv/nodejs-java/manage-blob/) för strategier för stora filer.

För stora filer, föredra inläsning från filvägar när det är möjligt, avlasta varje källpresentation så snart den har sammanslagits och undvik att spara mellanresultat upprepade gånger om arbetsflödet inte kräver checkpoints.

### **Trådsäkerhet**

Ladda, spara eller klona inte en [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/)‑instans i flera trådar. Dessa operationer stöds inte för multitrådad användning. Om du behöver parallellisera oberoende sammanslagningsjobb, använd flera enkla‑trådade processer, var och en med egna presentationsinstanser, och följ [Aspose.Slides multitrådnings‑riktlinjer](/slides/sv/nodejs-java/multithreading/).

## **FAQ**

**Hur behåller jag varje källpresentationers ursprungliga design?**

Använd [addClone](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-) utan att ange en mål‑master eller layout. Aspose.Slides kan automatiskt klona källmastern när den behövs av den importerade bilden.

**Hur får jag att importerade bilder använder måltemat?**

Använd overloaden som accepterar en mål‑master. Skicka en master från målpresentationen, inte från källan. Aspose.Slides kommer att försöka mappa varje källbild till en lämplig layout under den mastern.

**När ska jag använda en specifik mål‑layout i stället för en mål‑master?**

Använd en specifik layout när varje importerad bild ska använda en känd layout. Använd en master när du vill att Aspose.Slides ska välja bland masterns layouter baserat på källlayoutens typ eller namn.

**Kan presentationer med olika bildstorlekar sammanslås?**

Ja, men bildinnehållet redesignas inte automatiskt för mål‑dimensionerna. Ändra storlek på källpresentationen först när du behöver förutsägbara placeringar, exempelvis med [SlideSize.setSize](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) och [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slidesizescaletype/).

**Kan jag sammanslå PPT, PPTX och ODP‑presentationer till en fil?**

Ja. Läs in varje källpresentation, klona de önskade bilderna till en mål‑presentation och spara mål‑presentationen i ett stödformat. Eftersom formatens funktionsuppsättningar kan skilja sig, verifiera komplext innehåll efter kors‑format‑sammanslagning. Se [Stödda filformat](/slides/sv/nodejs-java/supported-file-formats/).

**Behålls källsektioner automatiskt?**

Inte av en grundläggande loop som bara klonar bilder. Återskapa de behövda sektionerna i målpresentationen och använd sektion‑overloaden för [addClone](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-) när sektionstrukturen måste bevaras.

**Behålls talarnoteringar och kommentarer?**

De kopieras med den klonade bilden. För arbetsflöden som är beroende av notes‑master‑stil, kommentar‑författare eller trådad granskningsdata, verifiera det sammanslagna resultatet eftersom dessa scenarier involverar både presentations‑ och bild‑nivå‑strukturer.

**Vad händer med ljud, video, OLE‑objekt och hyperlänkar?**

Inbäddat innehåll följer med som en del av den klonade bildens resursrelationer. Externa länkar förblir externa, så deras mål‑filer eller URL:er måste fortfarande vara tillgängliga efter sammanslagning.

**Garanti för att inbäddade typsnitt från alla källor finns i den sammanslagna presentationen?**

Lita inte enbart på bildkloning för typsnittsutplacering. Inspektera mål‑presentationens inbäddade typsnitt och hantera typsnittsinbäddning eller extern typsnittstillgänglighet explicit när typografi är viktig.

**Hur sammanslår jag en lösenordsskyddad fil?**

Öppna den med rätt [LoadOptions.setPassword](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/loadoptions/#setPassword-String-), klona sedan dess bilder som vanligt. Utdata‑skydd konfigureras separat.

**Hur hanterar jag mycket stora presentationer?**

Använd BLOB‑hantering när stora binära objekt dominerar minnesanvändning, föredra inläsning från filvägar för mycket stora filer, avlasta källpresentationer omedelbart efter sammanslagning och spara slutresultatet endast när det behövs.

**Kan jag klona bilder från flera trådar?**

Ladda, spara eller klona inte presentations‑instanser i flera trådar. För parallella sammanslagningsjobb, använd separata enkla‑trådade processer med egna presentations‑instanser.