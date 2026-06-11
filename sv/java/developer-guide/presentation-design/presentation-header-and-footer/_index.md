---
title: Hantera presentationers sidhuvuden och sidfötter i Java
linktitle: Sidhuvud och sidfot
type: docs
weight: 140
url: /sv/java/presentation-header-and-footer/
keywords:
- sidhuvud
- sidhuvudstext
- sidfot
- sidfotstext
- ange sidhuvud
- ange sidfot
- handout
- anteckningar
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Använd Aspose.Slides for Java för att lägga till och anpassa sidhuvuden och sidfötter i PowerPoint- och OpenDocument-presentationer för ett professionellt utseende."
---
## **Översikt**

Aspose.Slides låter dig hantera inställningar för sidhuvud och sidfot i PowerPoint-presentationer. Sidhuvuden och sidfötter hanteras på presentationsmasternivå, och API:t tillhandahåller metoder för att ange sidfotstext, ändra sidfotens synlighet och uppdatera sidhuvudstext på master‑notssidor.

Du kan också hantera sidhuvuden och sidfötter för handout och notssidor. Detta inkluderar att ändra synlighet och text för sidhuvud, sidfot, bildnummer och datum‑tid‑platshållare för notsmaster, alla underordnade notssidor eller en enskild notssida.

## **Hantera sidhuvuden och sidfötter i en presentation**
Anteckningar för vissa specifika bilder kan tas bort som visas i exemplet nedan:

```java
// Ladda presentation
Presentation pres = new Presentation("headerTest.pptx");
try {
    // Ange sidfot
    pres.getHeaderFooterManager().setAllFootersText("My Footer text");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);

    // Åtkomst och uppdatera sidhuvud
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
// Metod för att ange sidhuvud/sidfots text
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

## **Hantera sidhuvuden och sidfötter på handout‑ och notssidor**
Aspose.Slides for Java stödjer sidhuvud och sidfot i handout‑ och notssidor. Följ stegen nedan:

- Ladda en [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation) som innehåller en video.
- Ändra inställningarna för sidhuvud och sidfot för notsmaster och alla notssidor.
- Ställ in att master‑notssidan och alla underordnade sidfot‑platshållare ska vara synliga.
- Ställ in att master‑notssidan och alla underordnade datum‑och‑tid‑platshållare ska vara synliga.
- Ändra inställningarna för sidhuvud och sidfot endast för den första notssidan.
- Gör sidhuvud‑platshållaren på notssidan synlig.
- Ange text för sidhuvud‑platshållaren på notssidan.
- Ange text för datum‑tid‑platshållaren på notssidan.
- Skriv den ändrade presentationsfilen.

Kodavsnitt som tillhandahålls i exemplet nedan.

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    // Ändra inställningarna för sidhuvud och sidfot för notsmaster och alla notssidor
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null)
    {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersVisibility(true); // gör master‑notssidan och alla underordnade Footer‑platshållare synliga
        headerFooterManager.setFooterAndChildFootersVisibility(true); // gör master‑notssidan och alla underordnade Header‑platshållare synliga
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // gör master‑notssidan och alla underordnade SlideNumber‑platshållare synliga
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // gör master‑notssidan och alla underordnade Date and time‑platshållare synliga

        headerFooterManager.setHeaderAndChildHeadersText("Header text"); // ange text till master‑notssidan och alla underordnade Header‑platshållare
        headerFooterManager.setFooterAndChildFootersText("Footer text"); // ange text till master‑notssidan och alla underordnade Footer‑platshållare
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text"); // ange text till master‑notssidan och alla underordnade Date and time‑platshållare
    }

    // Ändra inställningarna för sidhuvud och sidfot endast för den första notssidan
    INotesSlide notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null)
    {
        INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible())
            headerFooterManager.setHeaderVisibility(true); // gör denna notssidas Header‑platshållare synlig

        if (!headerFooterManager.isFooterVisible())
            headerFooterManager.setFooterVisibility(true); // gör denna notssidas Footer‑platshållare synlig

        if (!headerFooterManager.isSlideNumberVisible())
            headerFooterManager.setSlideNumberVisibility(true); // gör denna notssidas SlideNumber‑platshållare synlig

        if (!headerFooterManager.isDateTimeVisible())
            headerFooterManager.setDateTimeVisibility(true); // gör denna notssidas Date-time‑platshållare synlig

        headerFooterManager.setHeaderText("New header text"); // ange text till notssidans Header‑platshållare
        headerFooterManager.setFooterText("New footer text"); // ange text till notssidans Footer‑platshållare
        headerFooterManager.setDateTimeText("New date and time text"); // ange text till notssidans Date-time‑platshållare
    }
    pres.save("testresult.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Kan jag lägga till ett "sidhuvud" på vanliga bilder?**

I PowerPoint finns “Header” bara för noteringar och handouts; på vanliga bilder är de stödda elementen sidfot, datum/tid och bildnummer. I Aspose.Slides stämmer detta överens med samma begränsningar: sidhuvud endast för Notes/Handout, och på bilder — Footer/DateTime/SlideNumber.

**Vad om layouten inte innehåller ett sidfotområde—kan jag "slå på" dess synlighet?**

Ja. Kontrollera synligheten via sidhuvud/‑sidfot‑hanteraren och aktivera den vid behov. Dessa API‑indikatorer och metoder är avsedda för fall då platshållaren saknas eller är dold.

**Hur får jag bildnumret att börja från ett annat värde än 1?**

Ställ in presentationens [first slide number](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-); därefter räknas all numrering om. Till exempel kan du börja på 0 eller 10 och dölja numret på titelsliden.

**Vad händer med sidhuvuden/sidfötter vid export till PDF/bilder/HTML?**

De renderas som vanliga textelement i presentationen. Det innebär att om elementen är synliga på bild‑/notssidor kommer de även att visas i den exporterade formatet tillsammans med resten av innehållet.