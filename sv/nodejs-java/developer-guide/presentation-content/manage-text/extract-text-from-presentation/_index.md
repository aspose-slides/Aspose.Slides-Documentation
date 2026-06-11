---
title: Avancerad textextraktion från presentationer i JavaScript
linktitle: Extrahera text
type: docs
weight: 90
url: /sv/nodejs-java/extract-text-from-presentation/
keywords:
- extrahera text
- extrahera text från bild
- extrahera text från presentation
- extrahera text från PowerPoint
- extrahera text från OpenDocument
- extrahera text från PPT
- extrahera text från PPTX
- extrahera text från ODP
- hämta text
- hämta text från bild
- hämta text från presentation
- hämta text från PowerPoint
- hämta text från OpenDocument
- hämta text från PPT
- hämta text från PPTX
- hämta text från ODP
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Extrahera snabbt text från PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Node.js via Java. Följ vår enkla, steg-för-steg-guide för att spara tid."
---
## **Översikt**

Att extrahera text från presentationer är en vanlig men ändå viktig uppgift för utvecklare som arbetar med bildspelsinnehåll. Oavsett om du hanterar Microsoft PowerPoint‑filer i PPT‑ eller PPTX‑format, eller OpenDocument‑presentationer (ODP), kan åtkomst till och hämtning av textdata vara avgörande för analys, automatisering, indexering eller innehållsmigrering.

Denna artikel ger en heltäckande guide för hur du effektivt extraherar text från olika presentationsformat, inklusive PPT, PPTX och ODP, med Aspose.Slides för Node.js via Java. Du lär dig hur du systematiskt itererar genom presentationsobjekt för att exakt hämta den text du behöver.

## **Extrahera text från en bild**

Aspose.Slides för Node.js via Java tillhandahåller klassen [SlideUtil](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slideutil/). Denna klass exponerar flera överlagrade statiska metoder för att extrahera all text från en presentation eller bild. För att extrahera text från en bild i en presentation, använd metoden [getAllTextBoxes](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slideutil/#getAllTextBoxes-aspose.slides.IBaseSlide-). Denna metod accepterar ett bildobjekt som parameter. När den körs skannar metoden hela bilden efter text och returnerar en array av [TextFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/)-objekt, med bibehållen formatering.

Följande kodsnutt extraherar all text från presentationens första bild:

```javascript
const slideIndex = 0;

const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(slideIndex);

    const textFrames = aspose.slides.SlideUtil.getAllTextBoxes(slide);

    for (let textFrameIndex = 0; textFrameIndex < textFrames.length; textFrameIndex++) {
        const textFrame = textFrames[textFrameIndex];

        const paragraphs = textFrame.getParagraphs();
        const paragraphCount = paragraphs.getCount();
        for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
            const paragraph = paragraphs.get_Item(paragraphIndex);

            const portions = paragraph.getPortions();
            const portionCount = portions.getCount();
            for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                const portion = portions.get_Item(portionIndex);

                const portionText = portion.getText();
                console.log(portionText);

                const portionFormat = portion.getPortionFormat();
                const fontHeight = portionFormat.getFontHeight();
                console.log(fontHeight);

                const latinFont = portionFormat.getLatinFont();
                if (latinFont !== null) {
                    const fontName = latinFont.getFontName();
                    console.log(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Extrahera text från en presentation**

För att skanna text från hela presentationen, använd den statiska metoden [getAllTextFrames](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slideutil/#getAllTextFrames-aspose.slides.IPresentation-boolean-) som exponeras av klassen [SlideUtil](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slideutil/). Den accepterar två parametrar:

1. Först ett [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/)-objekt som representerar en PowerPoint‑ eller OpenDocument‑presentation från vilken text ska extraheras.  
2. Ett `boolean`‑värde som anger om masterbilder ska inkluderas när text skannas från presentationen.

Metoden returnerar en array av [TextFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/)-objekt, inklusive information om textformatering. Koden nedan skannar texten och formateringsdetaljerna från en presentation, inklusive masterbilder.

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const includeMasterSlides = true;
    const textFrames = aspose.slides.SlideUtil.getAllTextFrames(presentation, includeMasterSlides);

    for (let textFrameIndex = 0; textFrameIndex < textFrames.length; textFrameIndex++) {
        const textFrame = textFrames[textFrameIndex];

        const paragraphs = textFrame.getParagraphs();
        const paragraphCount = paragraphs.getCount();
        for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
            const paragraph = paragraphs.get_Item(paragraphIndex);

            const portions = paragraph.getPortions();
            const portionCount = portions.getCount();
            for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                const portion = portions.get_Item(portionIndex);

                const portionText = portion.getText();
                console.log(portionText);

                const portionFormat = portion.getPortionFormat();
                const fontHeight = portionFormat.getFontHeight();
                console.log(fontHeight);

                const latinFont = portionFormat.getLatinFont();
                if (latinFont !== null) {
                    const fontName = latinFont.getFontName();
                    console.log(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Kategoriserad och snabb textextraktion**

Klassen [PresentationFactory](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentationfactory/) tillhandahåller också metoder för att extrahera all text från presentationer:

```javascript
PresentationText getPresentationText(String file, int mode);
PresentationText getPresentationText(InputStream stream, int mode);
PresentationText getPresentationText(InputStream stream, int mode, LoadOptions options);
```

Argumentet [TextExtractionArrangingMode](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textextractionarrangingmode/) i enum anger läget för att organisera resultatet av textextraktionen och kan sättas till följande värden:
- `Unarranged` – Råtext utan hänsyn till dess position på bilden.  
- `Arranged` – Texten är ordnad i samma ordning som på bilden.

Det oordnade läget kan användas när hastighet är kritisk; det är snabbare än det ordnade läget.

[PresentationText](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentationtext/) representerar den råa texten som extraherats från presentationen. Dess `getSlidesText`‑metod returnerar en array av objekt, där varje objekt representerar texten på motsvarande bild. Varje bildtextobjekt har följande metoder:

- Dess `getText`‑metod returnerar texten i bildens former.  
- Dess `getMasterText`‑metod returnerar texten i masterbildens former som är kopplade till denna bild.  
- Dess `getLayoutText`‑metod returnerar texten i layoutbildens former som är kopplade till denna bild.  
- Dess `getNotesText`‑metod returnerar texten i noteringsbildens former som är kopplade till denna bild.  
- Dess `getCommentsText`‑metod returnerar texten i kommentarer som är kopplade till denna bild.

```javascript
const presentationPath = "presentation.ppt";
const arrangingMode = aspose.slides.TextExtractionArrangingMode.Unarranged;
const presentationText = aspose.slides.PresentationFactory.getInstance().getPresentationText(presentationPath, arrangingMode);
const firstSlideText = presentationText.getSlidesText()[0];

console.log(firstSlideText.getText());
console.log(firstSlideText.getLayoutText());
console.log(firstSlideText.getMasterText());
console.log(firstSlideText.getNotesText());
console.log(firstSlideText.getCommentsText());
```

## **Vanliga frågor**

**Hur snabbt bearbetar Aspose.Slides stora presentationer under textextraktion?**  
Aspose.Slides är optimerat för hög prestanda och kan bearbeta även [stora presentationer](/slides/sv/nodejs-java/open-presentation/), vilket gör det lämpligt för realtids- eller massbearbetningsscenarier.

**Kan Aspose.Slides extrahera text från tabeller och diagram i presentationer?**  
Ja. Aspose.Slides kan extrahera text från många bildelement, inklusive tabeller och diagramrelaterade objekt, så att du kan komma åt och analysera textinnehåll i vanliga presentationsstrukturer.

**Behöver jag en speciell Aspose.Slides‑licens för att extrahera text från presentationer?**  
Du kan extrahera text med den kostnadsfria provversionen av Aspose.Slides, men den har [vissa begränsningar](/slides/sv/nodejs-java/licensing/), såsom att endast bearbeta ett begränsat antal bilder. För obegränsad användning och för att hantera större presentationer rekommenderas att köpa en full licens.