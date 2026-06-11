---
title: Hantera presentationssidhuvuden och sidfötter på Android
linktitle: Sidhuvud & Sidfot
type: docs
weight: 140
url: /sv/androidjava/presentation-header-and-footer/
keywords:
- sidhuvud
- sidhuvudstext
- sidfot
- sidfotstext
- sätt sidhuvud
- sätt sidfot
- utdelning
- anteckningar
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Använd Aspose.Slides för Android via Java för att lägga till och anpassa sidhuvuden och sidfötter i PowerPoint- och OpenDocument-presentationer för ett professionellt utseende."
---
## **Översikt**

Aspose.Slides låter dig hantera inställningar för sidhuvud och sidfot i PowerPoint-presentationer. Sidhuvuden och sidfötter hanteras på presentationsmästarens nivå, och API:et tillhandahåller metoder för att ange sidfotstext, ändra sidfotens synlighet och uppdatera sidhuvudstext på master‑notesslides.

Du kan också hantera sidhuvuden och sidfötter för utdelnings‑ och notesslides. Detta inkluderar att ändra synlighet och text för sidhuvud, sidfot, bildnummer och datum‑tid‑platshållare för notermästaren, alla underordnade notesslides eller en enskild notesslide.

## **Hantera sidhuvuden och sidfötter i en presentation**
Anteckningar för vissa specifika slides kan tas bort som visas i exemplet nedan:

```java
// Läs in presentation
Presentation pres = new Presentation("headerTest.pptx");
try {
    // Ställer in sidfot
    pres.getHeaderFooterManager().setAllFootersText("My Footer text");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);

    // Åtkomst och uppdatering av sidhuvud
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (null != masterNotesSlide)
    {
        updateHeaderFooterText(masterNotesSlide);
    }

    // Spara presentation
    pres.save("HeaderFooterJava.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
```java
// Metod för att sätta sidhuvud/sidfotstext
public static void updateHeaderFooterText(IBaseSlide master)
{
    for (IShape shape : master.getShapes())
    {
        if (shape.getPlaceholder() != null)
        {
            if (shape.getPlaceholder().getType() == PlaceholderType.Header)
            {
                ((IAutoShape)shape).getTextFrame().setText("HI there new header");
            }
        }
    }
}
```

## **Hantera sidhuvuden och sidfötter på utdelning‑ och notesslides**
Aspose.Slides för Android via Java stöder Sidhuvud och Sidfot i utdelnings‑ och notesslides. Följ stegen nedan:

- Läs in en [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation) som innehåller en video.
- Ändra inställningarna för Sidhuvud och Sidfot för notermästarens och alla notesslides.
- Gör alla Footer‑platshållare på master‑notesslide och underordnade synliga.
- Gör alla Date‑ och time‑platshållare på master‑notesslide och underordnade synliga.
- Ändra inställningarna för Sidhuvud och Sidfot endast för den första notessliden.
- Gör Header‑platshållaren på notessliden synlig.
- Sätt text för Header‑platshållaren på notessliden.
- Sätt text för Date‑time‑platshållaren på notessliden.
- Skriv den modifierade presentationsfilen.

Kodexempel ges i exemplet nedan.

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    // Ändra sidhuvud- och sidfotinställningar för notermästare och alla notesslides
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null)
    {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersVisibility(true); // gör master notessliden och alla underordnade Footer‑platshållare synliga
        headerFooterManager.setFooterAndChildFootersVisibility(true); // gör master notessliden och alla underordnade Header‑platshållare synliga
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // gör master notessliden och alla underordnade SlideNumber‑platshållare synliga
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // gör master notessliden och alla underordnade Date‑ och time‑platshållare synliga

        headerFooterManager.setHeaderAndChildHeadersText("Header text"); // sätt text till master notessliden och alla underordnade Header‑platshållare
        headerFooterManager.setFooterAndChildFootersText("Footer text"); // sätt text till master notessliden och alla underordnade Footer‑platshållare
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text"); // sätt text till master notessliden och alla underordnade Date‑ och time‑platshållare
    }

    // Ändra sidhuvud- och sidfotinställningar endast för den första notessliden
    INotesSlide notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null)
    {
        INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible())
            headerFooterManager.setHeaderVisibility(true); // gör denna notesslides Header‑platshållare synlig

        if (!headerFooterManager.isFooterVisible())
            headerFooterManager.setFooterVisibility(true); // gör denna notesslides Footer‑platshållare synlig

        if (!headerFooterManager.isSlideNumberVisible())
            headerFooterManager.setSlideNumberVisibility(true); // gör denna notesslides SlideNumber‑platshållare synlig

        if (!headerFooterManager.isDateTimeVisible())
            headerFooterManager.setDateTimeVisibility(true); // gör denna notesslides Date‑time‑platshållare synlig

        headerFooterManager.setHeaderText("New header text"); // sätt text till notesslides Header‑platshållare
        headerFooterManager.setFooterText("New footer text"); // sätt text till notesslides Footer‑platshållare
        headerFooterManager.setDateTimeText("New date and time text"); // sätt text till notesslides Date‑time‑platshållare
    }
    pres.save("testresult.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Kan jag lägga till ett "sidhuvud" på vanliga slides?**

I PowerPoint finns "Sidhuvud" bara för noteringar och utdelningar; på vanliga slides stöds endast sidfot, datum/tid och bildnummer. I Aspose.Slides gäller samma begränsningar: sidhuvud bara för Notes/Handout, och på slides — Footer/DateTime/SlideNumber.

**Vad händer om layouten inte innehåller ett sidfotområde—kan jag "aktivera" dess synlighet?**

Ja. Kontrollera synligheten via sidhuvuds-/sidfots‑hanteraren och aktivera den om det behövs. Dessa API‑indikatorer och metoder är avsedda för fall då platshållaren saknas eller är dold.

**Hur får jag bildnumret att börja från ett annat värde än 1?**

Ställ in presentationens [första bildnummer](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-); därefter beräknas all numrering om. Till exempel kan du börja på 0 eller 10, och dölja numret på titelsliden.

**Vad händer med sidhuvuden/sidfötter vid export till PDF/bilder/HTML?**

De renderas som vanliga textelement i presentationen. Det betyder att om elementen är synliga på slides/notessidor så visas de också i den exporterade filen tillsammans med resten av innehållet.