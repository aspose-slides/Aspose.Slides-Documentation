---
title: Hantera presentationsrubriker och -sidfötter på Android
linktitle: Rubrik och sidfot
type: docs
weight: 140
url: /sv/androidjava/presentation-header-and-footer/
keywords:
- rubrik
- rubriktext
- sidfot
- sidfottext
- ställ in rubrik
- ställ in sidfot
- utdelning
- anteckningar
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Lär dig hur du hanterar sidfot-, datum-tid-, bildnummer- och rubrik-platshållare på bilder, anteckningssidor och utdelningar med Aspose.Slides för Android via Java."
---
## **Översikt**

PowerPoint använder olika rubrik- och sidfotplatshållare beroende på sidtyp. Aspose.Slides för Android via Java låter dig kontrollera texten och synligheten för dessa platshållare via rubrik-/sidfotshanterargränssnitt.

De tillgängliga platshållarna beror på omfånget:

| Omfång | Rubrik | Sidfot | Datum/tid | Bild-/sidnummer |
|---|---|---|---|---|
| Vanlig bild | Nej | Ja | Ja | Ja |
| Anteckningsmaster | Ja | Ja | Ja | Ja |
| Anteckningsbild | Ja | Ja | Ja | Ja |
| Utdelningsmaster | Ja | Ja | Ja | Ja |

En vanlig presentationsbild har ingen rubrikplatshållare. Rubriker finns på anteckningssidor och utdelningar. För vanliga bilder, använd sidfot-, datum/tid- och bild-/sidnummerplatshållare istället.

Omfånget för en ändring beror på den hanterare du använder. Gränssnittet [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/islideheaderfootermanager/) styr en vanlig bild. Gränssnittet [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/inotesslideheaderfootermanager/) styr en anteckningsbild. Master‑ och layout‑hanterare kan också sprida inställningarna till beroende bilder, medan gränssnittet [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imasterhandoutslideheaderfootermanager/) styr utdelningsmastern.

## **Ställ in sidfot, datum/tid och bildnummer på vanliga bilder**

För vanliga bilder är det grundläggande arbetsflödet att komma åt varje bilds rubrik-/sidfotshanterare, sätta sidfot- och datum/tid‑text, aktivera de nödvändiga platshållarna och spara presentationen. Bildnumren genereras av presentationen, så du behöver bara kontrollera deras synlighet.

Använd [`setFooterText`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setFooterText-java.lang.String-) och [`setDateTimeText`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeText-java.lang.String-) för att ställa in text, och använd [`setFooterVisibility`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-), [`setDateTimeVisibility`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility-boolean-), och [`setSlideNumberVisibility`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility-boolean-) för att visa motsvarande platshållare.

Följande helhetsexempel tillämpar samma sidfot, datum/tid‑text och bildnummer‑synlighet på alla vanliga bilder:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideHeaderFooterManager headerFooterManager = slide.getHeaderFooterManager();

        headerFooterManager.setFooterText("Company Confidential");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_slide_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Om du bara behöver uppdatera en bild, åtkom den bilden direkt via metoden [`getSlides`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#getSlides--) istället för att iterera genom hela samlingen.

## **Ställ in rubriker och sidfot på anteckningsmastern**

Anteckningsmastern definierar gemensam formatering och platshållarbeteende för anteckningssidor. Använd gränssnittet [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/) när du vill ändra endast anteckningsmastern.

Följande exempel sätter rubrik, sidfot och datum/tid‑text på anteckningsmastern och gör alla stödda platshållare synliga på den mastern:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterNotesSlide masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide != null) {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Notes header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Notes footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Metoden [`getMasterNotesSlide`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imasternotesslidemanager/#getMasterNotesSlide--) returnerar `null` när presentationen inte innehåller en anteckningsmaster.

## **Tillämpa anteckningsmasterinställningar på underordnade anteckningsbilder**

En anteckningsmaster kan tillämpa rubrik- och sidfotsinställningar på sig själv och på alla beroende anteckningsbilder. Använd de dedikerade spridningsmetoderna på [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/) när samma inställningar ska tillämpas över hela anteckningshierarkin.

Till exempel uppdaterar [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersText-java.lang.String-) och [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility-boolean-) anteckningsmasterns rubrik och alla barnrubriker. Liknande metoder finns för sidfot, datum/tid och bildnummer.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterNotesSlide masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide != null) {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersText("Notes header");
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);

        headerFooterManager.setFooterAndChildFootersText("Notes footer");
        headerFooterManager.setFooterAndChildFootersVisibility(true);

        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    presentation.save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Spridningsmetoderna som användes ovan är [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersText-java.lang.String-), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility-boolean-), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText-java.lang.String-), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility-boolean-), och [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility-boolean-).

## **Ställ in rubriker och sidfot på en enskild anteckningsbild**

En anteckningsbild tillhör en specifik vanlig bild. Använd dess gränssnitt [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/inotesslideheaderfootermanager/) när du vill anpassa endast den anteckningssidan.

Metoden [`addNotesSlide`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/inotesslidemanager/#addNotesSlide--) returnerar anteckningsbilden för den aktuella bilden och skapar en om den ännu inte finns. Följande exempel konfigurerar anteckningssidan som är kopplad till den första presentationsbilden:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();
    INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();

    headerFooterManager.setHeaderText("Header for the first notes page");
    headerFooterManager.setHeaderVisibility(true);

    headerFooterManager.setFooterText("Footer for the first notes page");
    headerFooterManager.setFooterVisibility(true);

    headerFooterManager.setDateTimeText("Date and time text");
    headerFooterManager.setDateTimeVisibility(true);

    headerFooterManager.setSlideNumberVisibility(true);

    presentation.save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Om du först sprider inställningar från anteckningsmastern och sedan ändrar en enskild anteckningsbild, låter de senare per‑bild‑inställningarna dig anpassa den anteckningssidan oberoende.

## **Ställ in rubriker och sidfot på utdelningsmastern**

Utdelningssidor använder utdelningsmastern för sina rubrik-, sidfot-, datum/tid- och sidnummer‑platshållare. Till skillnad från anteckningssidor hanteras utdelningsinställningarna via utdelningsmastern istället för enskilda utdelningsbilder.

Använd metoden [`getMasterHandoutSlide`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imasterhandoutslidemanager/#getMasterHandoutSlide--) för att komma åt utdelningsmastern. Om den inte finns, anropa [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) för att skapa standard‑utdelningsmastern.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterHandoutSlide masterHandoutSlide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();

    if (masterHandoutSlide == null) {
        masterHandoutSlide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();
    }

    if (masterHandoutSlide != null) {
        IMasterHandoutSlideHeaderFooterManager headerFooterManager = masterHandoutSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Handout header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Handout footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_handout_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Förstå omfång och arv**

Välj den rubrik-/sidfotshanterare som motsvarar det omfång du vill ändra:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/islideheaderfootermanager/) ändrar sidfot-, datum/tid- och bildnummerinställningar för en vanlig bild.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ilayoutslideheaderfootermanager/) styr en layout‑bild och kan sprida stödda inställningar till beroende bilder.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imasterslideheaderfootermanager/) styr en vanlig bildmaster och kan sprida stödda inställningar till beroende bilder.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/) styr anteckningsmastern och kan sprida inställningar till alla beroende anteckningsbilder.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/inotesslideheaderfootermanager/) ändrar en anteckningsbild och stöder en rubrik‑platshållare utöver sidfot, datum/tid och bildnummer.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imasterhandoutslideheaderfootermanager/) ändrar utdelningsmastern och stöder alla fyra platshållartyper.

Använd spridning från en master eller layout när samma inställning ska gälla i hela dess hierarki. Använd en enskild bild‑ eller antecknings‑bild‑hanterare när du behöver en lokal inställning för en sida.

## **Vanliga frågor**

**Kan jag lägga till en rubrik på en vanlig bild?**

Nej. PowerPoint definierar ingen rubrik‑platshållare för vanliga bilder. På vanliga bilder använder du sidfot-, datum/tid- och bildnummer‑platshållare. Rubrik‑platshållare finns på anteckningssidor och utdelningar.

**Vad händer om en sidfot-, datum/tid- eller bildnummer‑platshållare inte är synlig?**

Använd motsvarande rubrik-/sidfotshanterare för att kontrollera dess synlighet och aktivera den vid behov. Till exempel rapporterar [`isFooterVisible`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/baseslideheaderfootermanager/#isFooterVisible--) om en sidfot‑platshållare finns, och [`setFooterVisibility`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-) ändrar dess synlighet.

**Hur startar jag bildnumreringen från ett annat värde än 1?**

Anropa presentationens metod [`setFirstSlideNumber`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-). Bildnummer‑platshållarna använder då den uppdaterade nummersekvensen.

**Vad händer med rubriker och sidfot när man exporterar till PDF, bilder eller HTML?**

Synliga rubrik‑ och sidfotselement renderas tillsammans med resten av presentationsinnehållet i det exporterade formatet. Deras utseende beror på den sidtyp som exporteras och de motsvarande platshållar‑synlighetsinställningarna.