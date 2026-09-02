---
title: Effektivt slå ihop presentationer på Android
linktitle: Slå ihop presentationer
type: docs
weight: 40
url: /sv/androidjava/merge-presentation/
keywords:
- slå ihop PowerPoint
- slå ihop presentationer
- slå ihop bilder
- slå ihop PPT
- slå ihop PPTX
- slå ihop ODP
- kombinera PowerPoint
- kombinera presentationer
- kombinera bilder
- kombinera PPT
- kombinera PPTX
- kombinera ODP
- Android
- Java
- Aspose.Slides
description: "Lär dig hur du slår ihop PowerPoint- och OpenDocument-presentationer på Android genom att klona bilder, styra master och layouter, ändra storlek på bildinnehåll, bevara sektioner samt hantera skyddade eller stora filer."
---
## **Översikt**

Aspose.Slides för Android via Java sammanslår presentationer genom att klona bilder från en [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/) till en annan. Huvudoperationen är [ISlideCollection.addClone](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-), som kan bevara källbildens formatering eller fästa den klonade bilden till ett master- eller layout i målpresentationen.

Denna artikel täcker de vanligaste sammanslagningsarbetsflödena:

- sammanfoga alla bilder samtidigt som deras källformat bevaras;
- sammanfoga valda bilder;
- tillämpa ett master från målpresentationen;
- tillämpa ett specifikt layout från målpresentationen;
- normalisera olika bildstorlekar innan sammanslagning;
- lägga till klonade bilder i ett avsnitt;
- sammanfoga flera presentationer i ett end‑to‑end‑arbetsflöde;
- hantera master, resurser, anteckningar, kommentarer, media, typsnitt, lösenord, stora filer och trådsäkerhetsaspekter.

## **Hur bildkloning påverkar master och layouter**

En bild ärver mycket av sitt utseende från sitt layout och master. Av den anledningen bestämmer vilken överlagring av kloning du väljer hur den sammanslagna bilden integreras i målpresentationen.

Använd [ISlideCollection.addClone](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/islidecollection/) på ett av följande sätt:

- `addClone(sourceSlide)` — bevara källbildens layout och formatering. Vid behov kan källmastern klonas automatiskt in i målpresentationen. Aspose.Slides spårar automatiskt klonade master så att upprepade bilder som använder samma källmaster inte får den master klonad flera gånger.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — fäst den klonade bilden till ett specifikt mål-[IMasterSlide](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imasterslide/). Aspose.Slides söker efter ett matchande layout under den mastern efter layout‑typ eller namn.
- `addClone(sourceSlide, destinationLayout)` — fäst den klonade bilden direkt till ett specifikt mål-[ILayoutSlide](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ilayoutslide/).

Den master eller layout som skickas till en `addClone`‑överlagring måste tillhöra **mål**‑presentationen, inte källpresentationen.

## **Sammanfoga hela presentationer och bevara källformat**

Den enklaste sammanslagningen kopierar varje bild från källpresentationen till målpresentationen. Detta är det lämpliga valet när de importerade bilderna ska behålla sitt ursprungliga tema, master och layout‑relationer.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide);
    }

    destination.save("merged.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Den resulterande presentationen kan innehålla flera master när käll‑ och målpresentationen använder olika designer. Detta är förväntat när källformat avsiktligt bevaras.

## **Sammanfoga valda bilder**

Du behöver inte klona varje bild. Följande exempel importerar endast utvalda bildindex från källpresentationen.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    int[] slideIndexes = { 0, 2, 4 };

    for (int index : slideIndexes) {
        destination.getSlides().addClone(source.getSlides().get_Item(index));
    }

    destination.save("merged-selected-slides.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Validera bildindex innan kloning när de kommer från användarinmatning eller extern konfiguration.

## **Sammanfoga bilder med ett mål‑master**

Använd överlagringen [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) när importerade bilder ska följa ett master som redan finns i målpresentationen.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    IMasterSlide destinationMaster = destination.getMasters().get_Item(0);

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, destinationMaster, true);
    }

    destination.save("merged-with-destination-master.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Aspose.Slides väljer ett lämpligt layout under den angivna mastern genom att matcha källlayoutens typ eller namn. Om inget passande layout finns och `allowCloneMissingLayout` är `true` klonas källlayouten så att bilden kan läggas till. Om det är `false` kastas ett [PptxEditException](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/pptxeditexception/).

Använd `false` när du vill att sammanslagningen ska misslyckas istället för att introducera ett ytterligare layout i mål‑mastern.

## **Sammanfoga bilder med ett specifikt mål‑layout**

Använd överlagringen [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) när du exakt vet vilket mål‑layout de importerade bilderna ska använda.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    ILayoutSlide destinationLayout = destination.getLayoutSlides().get_Item(0);

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, destinationLayout);
    }

    destination.save("merged-with-destination-layout.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Att tillämpa ett mål‑layout ändrar den ärvda layout‑relationen; det omdesignar inte innehållet i källbilden. Om käll‑ och mål‑layouter har olika platshållarstrukturer, inspektera resultatet för att bekräfta att den ärvda formateringen och platshållarbeteendet är lämpligt.

## **Sammanfoga presentationer med olika bildstorlekar**

Presentationer med olika bilddimensioner kan slås ihop, men att klona en bild till en presentation med en annan bildstorlek omformar inte automatiskt dess innehåll för den nya duken. Former kan därför visas förskjutna, skalade oväntat eller utanför den synliga bildytan.

En praktisk metod är att ändra storlek på källpresentationen innan kloning. Metoden [SlideSize.setSize](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) kan skala befintligt innehåll medan bilddimensionerna ändras. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/slidesizescaletype/) skalar innehåll för att passa inom den begärda storleken.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    SizeF sourceSize = source.getSlideSize().getSize();
    SizeF destinationSize = destination.getSlideSize().getSize();

    if (sourceSize.getWidth() != destinationSize.getWidth() || 
        sourceSize.getHeight() != destinationSize.getHeight()) {
        source.getSlideSize().setSize(
            destinationSize.getWidth(), 
            destinationSize.getHeight(), 
            SlideSizeScaleType.EnsureFit);
    }

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide);
    }

    destination.save("merged-same-slide-size.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Att ändra storlek ändrar källpresentationens objekt i minnet. Om du behöver den ursprungliga källpresentationen oförändrad för andra operationer, öppna en separat instans för sammanslagningen.

## **Sammanfoga bilder i ett presentationsavsnitt**

Den grundläggande bildkloningsloopen återställer inte källpresentationens avsnittshierarki. Om avsnitt är viktiga i resultatet, skapa eller välj avsnitt i målpresentationen och klona bilder in i dem explicit med [addClone(ISlide, ISection)](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-).

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    ISection importedSection = destination.getSections().appendEmptySection("Imported slides");

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, importedSection);
    }

    destination.save("merged-with-section.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

De klonade bilderna läggs till i det angivna mål‑avsnittet. För att bevara flera käll‑avsnitt, enumerera [Presentation.getSections](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#getSections--), hämta varje käll‑avsnitts aktuella bilder med [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--), återskapa avsnitten i målpresentationen och klona varje returnerad bild till motsvarande mål‑avsnitt. Se [Manage Slide Sections](/slides/sv/androidjava/slide-section/) för ett komplett exempel på avsnittsenumerering, inklusive tomma avsnitt och strukturella förändringar.

## **Sammanslå flera presentationer på ett säkert sätt**

Det följande end‑to‑end‑exemplet använder den första presentationen som mål, normaliserar bildstorleken för varje ytterligare källa, håller varje källa öppen endast medan den kopieras, och sparar den slutgiltiga filen en gång.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

String[] inputFiles = { "part1.pptx", "part2.pptx", "part3.pptx" };

Presentation merged = new Presentation(inputFiles[0]);
try {
    SizeF mergedSize = merged.getSlideSize().getSize();

    for (int fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        Presentation source = new Presentation(inputFiles[fileIndex]);
        try {
            SizeF sourceSize = source.getSlideSize().getSize();

            if (sourceSize.getWidth() != mergedSize.getWidth() || 
                sourceSize.getHeight() != mergedSize.getHeight()) {
                source.getSlideSize().setSize(
                    mergedSize.getWidth(), 
                    mergedSize.getHeight(), 
                    SlideSizeScaleType.EnsureFit);
            }

            for (ISlide slide : source.getSlides()) {
                merged.getSlides().addClone(slide);
            }
        } finally {
            source.dispose();
        }
    }

    merged.save("merged.pptx", SaveFormat.Pptx);
} finally {
    merged.dispose();
}
```

Detta är en användbar grundmodell för att bevara källformatet på importerade bilder. Om ditt resultat måste använda ett enda måltema, ersätt det enkla anropet `addClone(slide)` med den lämpliga mål‑master‑ eller mål‑layout‑överlagringen som visas tidigare.

## **Praktiska överväganden**

### **Master, layouter och formateringsfidelity**

Standardbildkloning kan automatiskt föra in en nödvändig käll‑master i målpresentationen. Aspose.Slides håller ett internt register för automatiskt klonade master för att undvika att samma master klonas upprepade gånger. Manuellt klonade master spåras inte av det registret, så undvik förkloning av master om du inte behöver explicit kontroll över master‑strukturen.

Anta inte att två master eller layouter med samma namn är visuellt ekvivalenta. Om en företagsmall måste styra det slutliga utseendet, välj ett mål‑master eller layout explicit och verifiera resultatet efter sammanslagning.

### **Anteckningar och kommentarer**

Talarnoteringar och bildkommentarer är knutna till bildinnehållet och kopieras när en bild klonas. Aspose.Slides erbjuder även dedikerade API:er för [presentation notes](/slides/sv/androidjava/presentation-notes/) och [presentation comments](/slides/sv/androidjava/presentation-comments/).

Om formatering av anteckningssidan är viktig, verifiera den sammanslagna presentationen eftersom antecknings‑master är objekt på presentationsnivå och kan skilja sig mellan källfiler. För granskningsarbetsflöden, verifiera även kommentar­författare och trådade kommentarer efter att filer från olika författare eller mallar kombinerats.

### **Bilder, ljud, video, OLE‑objekt och externa länkar**

Bilder kan referera resurser på presentationsnivå såsom bilder, inbäddat ljud, inbäddad video och OLE‑data. Klona själva bilden snarare än att bara kopiera dess synliga former så att Aspose.Slides kan behålla bildens relationer till sina resurser.

Inbäddade och länkade resurser bör behandlas olika. En länkad ljud‑, video‑, OLE‑objekt‑ eller hyperlänk förblir beroende av sitt externa mål; att klona en bild omvandlar inte en extern länk till inbäddat innehåll. Testa länkrevas‑vägar och URL:er i den miljö där den sammanslagna presentationen kommer att öppnas.

Aspose.Slides spårar automatiskt klonade master, men detta bör inte ses som en generell garanti för att identiska binära resurser från orelaterade källpresentationer alltid dedupliceras. Om filstorlek är viktig, inspektera det sammanslagna paketet och mät resultatet i stället för att förlita dig på implicit deduplicering.

### **Inbäddade typsnitt och typsnittstillgänglighet**

Typsnitt hanteras på presentationsnivå. Om typografi måste förbli konsekvent över maskiner, anta inte att enbart kloning av bilder garanterar att varje nödvändigt typsnitt är tillgängligt i målmiljön. Du kan inspektera inbäddade typsnitt med [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) och hantera inbäddning explicit enligt [Embed Fonts in Presentations](/slides/sv/androidjava/embedded-font/).

Verifiera också att du har rätt att bädda in de typsnitt som används i källfilerna. Typsnittslicenser kan begränsa inbäddning.

### **Lösenordsskyddade presentationer**

En lösenordsskyddad källa måste öppnas framgångsrikt innan dess bilder kan klonas. Ange lösenordet via [LoadOptions.setPassword](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-).

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation source = new Presentation("protected.pptx", loadOptions);
try {
    // Arbeta med den dekrypterade presentationen.
} finally {
    source.dispose();
}
```

Att öppna en krypterad källa applicerar inte automatiskt samma skydd på målpresentationen. Konfigurera utdata‑skydd separat när det krävs.

### **Stora presentationer och minnesanvändning**

Stora presentationer som innehåller högupplösta bilder, ljud, video eller andra stora binära objekt kan förbruka betydande minne. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) ger kontroll över BLOB‑hantering och temporära filer. Se [Manage Presentation BLOBs](/slides/sv/androidjava/manage-blob/) för strategier med stora filer.

För stora filer, föredra inläsning från filsökvägar när möjligt, avlossa varje källpresentation så snart den har slagits samman, och undvik att upprepade gånger spara mellansteg om inte arbetsflödet kräver kontrollpunkter.

### **Trådsäkerhet**

Läs inte, ändra, spara eller klona samma [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/)‑instans samtidigt från flera trådar. Håll varje presentationsinstans begränsad till en sammanslagningsoperation. Om du parallellt kör oberoende jobb, använd oberoende presentationsinstanser och följ [Aspose.Slides multithreading guidance](/slides/sv/androidjava/multithreading/).

## **FAQ**

**Hur behåller jag varje källpresentations ursprungliga design?**

Använd [addClone](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) utan att ange ett mål‑master eller layout. Aspose.Slides kan automatiskt klona käll‑mastern när den behövs av den importerade bilden.

**Hur får jag importerade bilder att använda måltemat?**

Använd överlagringen som accepterar ett mål‑master. Skicka ett master från målpresentationen, inte från källan. Aspose.Slides försöker mappa varje källbild till ett lämpligt layout under den mastern.

**När bör jag använda ett specifikt mål‑layout istället för ett mål‑master?**

Använd ett specifikt layout när varje importerad bild ska använda ett känt layout. Använd ett master när du vill att Aspose.Slides ska välja bland masterns layouter baserat på källbildens layout‑typ eller namn.

**Kan presentationer med olika bildstorlekar slås ihop?**

Ja, men bildinnehållet omdesignas inte automatiskt för mål‑dimensionerna. Ändra storlek på källpresentationen först när du behöver förutsägbar placering, exempelvis med [SlideSize.setSize](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) och [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/slidesizescaletype/).

**Kan jag slå ihop PPT, PPTX och ODP‑presentationer i en fil?**

Ja. Läs in varje källpresentation, klona de nödvändiga bilderna till en destination och spara destinationen i ett stödformat. Eftersom presentationsformaten inte stödjer exakt samma funktionsuppsättning, verifiera komplext innehåll efter kors‑format‑sammanslagningar. Se [Supported File Formats](/slides/sv/androidjava/supported-file-formats/).

**Behålls källavsnitt automatiskt?**

Inte med en grundloop som bara klonar bilder. Återskapa de nödvändiga avsnitten i målet och använd avsnitts‑överlagringen av [addClone](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) när avsnittsstrukturen måste bevaras.

**Behålls talarnoteringar och kommentarer?**

De kopieras med den klonade bilden. För arbetsflöden som beror på antecknings‑master‑stil, kommentar‑författare eller trådad granskningsdata, verifiera det sammanslagna resultatet eftersom dessa scenarier involverar både presentations‑ och bildnivå‑strukturer.

**Vad händer med ljud, video, OLE‑objekt och hyperlänkar?**

Inbäddat innehåll bärs som en del av den klonade bildens resursrelationer. Externa länkar förblir externa, så deras mål‑filer eller URL:er måste fortfarande vara tillgängliga efter sammanslagningen.

**Garanti för att inbäddade typsnitt från varje källa finns i den sammanslagna presentationen?**

Lita inte på att bara bildkloning hanterar typsnittsdistribution. Inspektera destinationens inbäddade typsnitt och hantera typsnittsinbäddning eller extern typsnittstillgänglighet explicit när typografi är viktig.

**Hur slår jag ihop en lösenordsskyddad fil?**

Öppna den med rätt [LoadOptions.setPassword](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), klona sedan dess bilder som vanligt. Utdata‑skydd konfigureras separat.

**Hur hanterar jag mycket stora presentationer?**

Använd BLOB‑hantering när stora binära objekt dominerar minnesanvändning, föredra fil‑sökvägs‑inläsning för mycket stora filer, avlossa källpresentationer snabbt, och spara det slutliga resultatet endast när det behövs.

**Kan jag slå ihop bilder från flera trådar?**

Använd inte en och samma [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/)‑instans samtidigt från flera trådar. Håll varje sammanslagningsoperation isolerad till sina egna presentationsinstanser.