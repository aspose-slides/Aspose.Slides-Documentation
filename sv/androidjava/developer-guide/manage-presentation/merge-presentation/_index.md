---
title: Effektivt sammanslå presentationer på Android
linktitle: Sammanslå presentationer
type: docs
weight: 40
url: /sv/androidjava/merge-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Lär dig hur du sammanslår PowerPoint- och OpenDocument-presentationer på Android genom att klona bilder, styra masters och layouter, ändra storlek på bildinnehåll, bevara avsnitt och hantera skyddade eller stora filer."
---
## **Översikt**

Aspose.Slides för Android via Java sammanslår presentationer genom att klona bilder från en [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/) till en annan. Huvudoperationen är [ISlideCollection.addClone](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-), som kan bevara källbildens formatering eller fästa den klonade bilden till en master eller layout i destinationspresentationen.

Den här artikeln täcker de vanligaste sammanslagningsarbetsflödena:

- sammanslå alla bilder samtidigt som deras källformatering bevaras;
- sammanslå utvalda bilder;
- tillämpa en master från destinationspresentationen;
- tillämpa en specifik layout från destinationspresentationen;
- normalisera olika bildstorlekar innan sammanslagning;
- lägga till klonade bilder i ett avsnitt;
- sammanslå flera presentationer i ett end‑to‑end‑arbetsflöde;
- hantera masters, resurser, anteckningar, kommentarer, media, typsnitt, lösenord, stora filer och multitrådningsaspekter.

## **Hur bildkloning påverkar masters och layouter**

En bild ärver mycket av sitt utseende från sin layout och master. Av den anledningen bestämmer den klonings‑overload du väljer hur den sammanslagna bilden integreras i destinationspresentationen.

Använd [ISlideCollection.addClone](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/islidecollection/) på ett av följande sätt:

- `addClone(sourceSlide)` — bevara källbildens layout och formatering. Vid behov kan källmaster automatiskt klonas in i destinationspresentationen. Aspose.Slides spårar automatiskt klonade masters så att återkommande bilder som använder samma källmaster inte leder till att master klonas flera gånger.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — fästa den klonade bilden till ett specifikt destinations-[IMasterSlide](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imasterslide/). Aspose.Slides söker efter en matchande layout under den mastern efter layouttyp eller namn.
- `addClone(sourceSlide, destinationLayout)` — fästa den klonade bilden direkt till en specifik destinations-[ILayoutSlide](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ilayoutslide/).

Den master eller layout som skickas till en `addClone`‑overload måste tillhöra **destinations**‑presentationen, inte källpresentationen.

## **Sammanslå hela presentationer och bevara källformatering**

Den enklaste sammanslagningen kopierar varje bild från källpresentationen till destinationspresentationen. Detta är det lämpliga valet när de importerade bilderna ska behålla sitt ursprungliga tema, master och layoutrelationer.

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

Den resulterande presentationen kan innehålla flera masters när käll‑ och destinationspresentationerna använder olika designer. Detta är förväntat när källformatering avsiktligt bevaras.

## **Sammanslå utvalda bilder**

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

Validera bildindex innan du klonar när de kommer från användarinmatning eller extern konfiguration.

## **Sammanslå bilder med en destinations‑master**

Använd overloaden [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) när importerade bilder ska följa en master som redan tillhör destinationspresentationen.

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

Aspose.Slides väljer en lämplig layout under den angivna mastern genom att matcha källlayoutens typ eller namn. Om ingen lämplig layout finns och `allowCloneMissingLayout` är `true` klonas källlayouten så att bilden kan läggas till. Om den är `false` kastas ett [PptxEditException](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/pptxeditexception/).

Använd `false` när du vill att sammanslagningen ska misslyckas istället för att introducera en ytterligare layout i destinationsmastern.

## **Sammanslå bilder med en specifik destinations‑layout**

Använd overloaden [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) när du exakt vet vilken destinations‑layout de importerade bilderna ska använda.

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

Att tillämpa en destinations‑layout förändrar den ärvda layoutrelationen; den omdesignar inte källbildens innehåll. Om käll‑ och destinations‑layouter har olika platshållarstrukturer, inspektera resultatet för att bekräfta att den ärvda formateringen och platshållarbeteendet är lämpliga.

## **Sammanslå presentationer med olika bildstorlekar**

Presentationer med olika bilddimensioner kan sammanslås, men att klona en bild till en presentation med en annan bildstorlek omdesignar inte automatiskt dess innehåll för den nya canvasen. Former kan därför visas förskjutna, skalerade oväntat eller utanför den synliga bildytan.

Ett praktiskt tillvägagångssätt är att ändra storlek på källpresentationen innan kloning. Metoden [SlideSize.setSize](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) kan skala befintligt innehåll samtidigt som bilddimensionerna ändras. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/slidesizescaletype/) skalar innehållet så att det passar inom den begärda storleken.

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

## **Sammanslå bilder i ett presentationsavsnitt**

Den grundläggande bildkloningsloopen återskapar inte källpresentationens avsnittshierarki. Om avsnitt är viktiga i resultatet, skapa eller välj avsnitt i destinationspresentationen och klona bilder till dem explicit med [addClone(ISlide, ISection)](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-).

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

De klonade bilderna läggs till i det angivna destinationsavsnittet. För att bevara flera källavsnitt, återskapa dessa avsnitt i destinationen och mappa varje källbild till motsvarande destinationsavsnitt.

## **Sammanslå flera presentationer säkert**

Följande end‑to‑end‑exempel använder den första presentationen som destination, normaliserar bildstorleken för varje ytterligare källa, håller varje källa öppen endast medan den kopieras, och sparar den slutgiltiga filen en gång.

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

Detta är en användbar grundlinje för att bevara källformateringen för importerade bilder. Om ditt resultat måste använda ett enda destinations‑tema, ersätt det enkla `addClone(slide)`‑anropet med den lämpliga destination‑master‑ eller destination‑layout‑overloaden som visas tidigare.

## **Praktiska överväganden**

### **Masters, layouter och formateringsprecision**

Standardbildkloning kan automatiskt föra in en nödvändig käll‑master i destinationspresentationen. Aspose.Slides håller ett internt register för automatiskt klonade masters för att undvika att samma master klonas flera gånger. Manuell klonade masters spåras inte av det registret, så undvik förkloning av masters om du inte behöver explicit kontroll över masterstrukturen.

Anta inte att två masters eller layouter med samma namn är visuellt ekvivalenta. Om en företagsmall måste styra det slutgiltiga utseendet, välj en destinations‑master eller layout explicit och verifiera resultatet efter sammanslagning.

### **Anteckningar och kommentarer**

Talarnoteringar och bildkommentarer är associerade med bildinnehållet och kopieras när en bild klonas. Aspose.Slides erbjuder också dedikerade API:er för [presentation‑notes](https://docs.aspose.com/slides/sv/androidjava/presentation-notes/) och [presentation‑comments](https://docs.aspose.com/slides/sv/androidjava/presentation-comments/).

Om formateringen av notes‑sidan är viktig, verifiera den sammanslagna presentationen eftersom notes‑masters är objekt på presentationsnivå och kan skilja sig mellan källfiler. För granskningsarbetsflöden, verifiera också kommentarförfattare och trådade kommentarer efter kombination av filer från olika författare eller mallar.

### **Bilder, ljud, video, OLE‑objekt och externa länkar**

Bilder kan referera till resurser på presentationsnivå såsom bilder, inbäddat ljud, inbäddad video och OLE‑data. Klona själva bilden snarare än att bara kopiera dess synliga former så att Aspose.Slides kan underhålla bildens relationer till dess resurser.

Inbäddade och länkade resurser bör behandlas olika. En länkad ljud‑, video‑, OLE‑objekt‑ eller hyperlänk‑fil förblir beroende av sitt externa mål; kloning av en bild förvandlar inte en extern länk till inbäddat innehåll. Testa sökvägar och URL:er för länkade resurser i den miljö där den sammanslagna presentationen ska öppnas.

Aspose.Slides spårar automatiskt klonade masters, men detta bör inte betraktas som en generell garanti för att identiska binära resurser från orelaterade källpresentationer alltid dedupliceras. Om filstorlek är viktig, inspektera det sammanslagna paketet och mät resultatet istället för att förlita dig på implicit deduplicering.

### **Inbäddade typsnitt och typsnittstillgänglighet**

Typsnitt hanteras på presentationsnivå. Om typografi måste vara konsekvent över maskiner, anta inte att bara bildkloning garanterar att varje nödvändigt typsnitt är tillgängligt i destinationsmiljön. Du kan inspektera inbäddade typsnitt med [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) och hantera inbäddning explicit enligt [Embed Fonts in Presentations](https://docs.aspose.com/slides/sv/androidjava/embedded-font/).

Verifiera också att du har rätt att inbädda de typsnitt som används i källfilerna. Typsnittslicenser kan begränsa inbäddning.

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

Att öppna en krypterad källa applicerar inte automatiskt samma skydd på destinationspresentationen. Konfigurera utdata‑skydd separat när det krävs.

### **Stora presentationer och minnesanvändning**

Stora presentationer som innehåller högupplösta bilder, ljud, video eller andra stora binära objekt kan förbruka betydande minne. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) ger kontroller för BLOB‑hantering och temporär‑filanvändning. Se [Manage Presentation BLOBs](https://docs.aspose.com/slides/sv/androidjava/manage-blob/) för strategier för stora filer.

För stora filer, föredra inläsning från filvägar när det är möjligt, disponera varje källpresentation så snart den har sammanslagits, och undvik att upprepade gånger spara mellanresultat om arbetsflödet inte kräver kontrollpunkter.

### **Trådsäkerhet**

Läs inte, modifiera, spara eller klona samma [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/)‑instans samtidigt från flera trådar. Håll varje presentationsinstans begränsad till en sammanslagningsoperation. Om du parallelliserar oberoende jobb, använd oberoende presentationsinstanser och följ [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/sv/androidjava/multithreading/).

## **FAQ**

**Hur behåller jag varje källpresentations ursprungliga design?**

Använd [`addClone(sourceSlide)`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) utan att ange en destinations‑master eller layout. Aspose.Slides kan automatiskt klona käll‑mastern när den behövs av den importerade bilden.

**Hur får jag importerade bilder att använda destinations‑temat?**

Använd overloaden som accepterar en destinations‑master. Skicka en master från destinationspresentationen, inte från källan. Aspose.Slides försöker mappa varje källbild till en lämplig layout under den mastern.

**När bör jag använda en specifik destinations‑layout istället för en destinations‑master?**

Använd en specifik layout när varje importerad bild ska använda en känd layout. Använd en master när du vill att Aspose.Slides ska välja bland masterns layouter baserat på källlayoutens typ eller namn.

**Kan presentationer med olika bildstorlekar sammanslås?**

Ja, men bildinnehållet redesignas inte automatiskt för destinationsdimensionerna. Ändra storlek på källpresentationen först när du behöver förutsägbar placering, till exempel med [SlideSize.setSize](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) och [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/slidesizescaletype/).

**Kan jag sammanslå PPT, PPTX och ODP‑presentationer i en fil?**

Ja. Läs in varje källpresentation, klona de nödvändiga bilderna till en destination, och spara destinationen i ett stödd format. Eftersom presentationsformaten inte stödjer exakt samma funktionsuppsättning, verifiera komplext innehåll efter korsformat‑sammanslagningar. Se [Supported File Formats](https://docs.aspose.com/slides/sv/androidjava/supported-file-formats/).

**Behålls källavsnitt automatiskt?**

Inte med en grundloop som bara klonar bilder. Återskapa de nödvändiga avsnitten i destinationen och använd avsnitts‑overloaden av [addClone](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) när avsnittsstruktur måste bevaras.

**Behålls talarnoteringar och kommentarer?**

De kopieras med den klonade bilden. För arbetsflöden som beror på notes‑master‑stil, kommentarförfattare eller trådade granskningsdata, verifiera det sammanslagna resultatet eftersom dessa scenarier involverar både presentations‑ och bildnivå‑strukturer.

**Vad händer med ljud, video, OLE‑objekt och hyperlänkar?**

Inbäddat innehåll transporteras som en del av den klonade bildens resursrelationer. Externa länkar förblir externa, så deras mål‑filer eller URL:er måste fortfarande vara tillgängliga efter sammanslagningen.

**Garanteras inbäddade typsnitt från varje källa i den sammanslagna presentationen?**

Räkna inte med att bara bildkloning säkerställer typsnittsdistribution. Inspektera destinationens inbäddade typsnitt och hantera typsnittsinbäddning eller extern typsnittstillgänglighet explicit när typografi är viktig.

**Hur sammanslår jag en lösenordsskyddad fil?**

Öppna den med rätt [LoadOptions.setPassword](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), klona sedan dess bilder som vanligt. Utdata‑skydd konfigureras separat.

**Hur hanterar jag mycket stora presentationer?**

Använd BLOB‑hantering när stora binära objekt dominerar minnesanvändningen, föredra inläsning från filväg för mycket stora filer, disponera källpresentationer omedelbart och spara det slutgiltiga resultatet endast när det behövs.

**Kan jag klona bilder från flera trådar?**

Använd inte samma [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/)‑instans samtidigt från flera trådar. Håll varje sammanslagningsoperation isolerad till sina egna presentationsinstanser.