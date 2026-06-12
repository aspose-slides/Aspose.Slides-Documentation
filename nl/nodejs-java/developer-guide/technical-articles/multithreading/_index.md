---
title: Multithreading in Aspose.Slides voor Node.js via Java
linktitle: Multithreading
type: docs
weight: 310
url: /nl/nodejs-java/multithreading/
keywords:
- multithreading
- meerdere threads
- parallel werk
- dia's converteren
- dia's naar afbeeldingen
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Multithreading met Aspose.Slides voor Node.js via Java verbetert de verwerking van PowerPoint en OpenDocument. Ontdek de beste praktijken voor efficiënte presentatiewerkstromen."
---
## **Introductie**

Hoewel parallel werken met presentaties mogelijk is (naast het parseren/laden/klonen) en alles doorgaans goed gaat (meestal), bestaat er een kleine kans dat je onjuiste resultaten krijgt wanneer je de bibliotheek in meerdere threads gebruikt.

We raden ten zeerste aan om **niet** één enkele [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation) instantie te gebruiken in een multi‑threading omgeving, omdat dit kan leiden tot onvoorspelbare fouten of problemen die moeilijk te detecteren zijn.

Het is **niet** veilig om een instantie van een [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation) klasse te laden, op te slaan en/of te klonen in meerdere threads. Dergelijke bewerkingen worden **niet** ondersteund. Als je zulke taken moet uitvoeren, moet je de bewerkingen parallel laten verlopen met meerdere single‑threaded processen – en elk van deze processen moet zijn eigen presentatietoepassing gebruiken.

## **Presentatie‑dia's parallel converteren naar afbeeldingen**

Stel dat we alle dia's van een PowerPoint‑presentatie parallel willen converteren naar PNG‑afbeeldingen. Omdat het onveilig is om één enkele `Presentation`‑instantie in meerdere threads te gebruiken, splitsen we de dia's op in aparte presentaties en converteren we de dia's parallel naar afbeeldingen, waarbij elke presentatie in een aparte thread wordt gebruikt. Het volgende code‑voorbeeld laat zien hoe dit gedaan wordt.

```javascript
const inputFilePath = "sample.pptx";
const outputFilePathTemplate = "slide_%d.png";
const imageScale = 2;

(async () => {
    const presentation = new aspose.slides.Presentation(inputFilePath);
    const slideCount = presentation.getSlides().size();
    const slideSize = presentation.getSlideSize().getSize();
    const slideWidth = slideSize.getWidth();
    const slideHeight = slideSize.getHeight();

    const conversionTasks = Array.from({ length: slideCount }, async (_, slideIndex) => {
        // Extraheer dia i naar een aparte presentatie.
        const slidePresentation = new aspose.slides.Presentation();
        slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.DoNotScale);
        slidePresentation.getSlides().removeAt(0);
        slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

        try {
            const slide = slidePresentation.getSlides().get_Item(0);
            const image = slide.getImage(imageScale, imageScale);
            const imageFilePath = outputFilePathTemplate.replace("%d", slideIndex + 1);

            image.save(imageFilePath, aspose.slides.ImageFormat.Png);
            console.log(`Saved slide ${slideIndex + 1} to ${imageFilePath}`);
        } catch (error) {
            console.error(`Error processing slide ${slideIndex + 1}: ${error.message}`);
        } finally {
            slidePresentation.dispose();
        }
    });

    // Wacht tot alle taken voltooid zijn.
    await Promise.all(conversionTasks);

    presentation.dispose();
})();
```

## **FAQ**

**Moet ik de licentie‑configuratie in elke thread aanroepen?**

Nee. Het volstaat om dit één keer per proces/app‑domain te doen voordat de threads starten. Als [license setup](/slides/nl/nodejs-java/licensing/) gelijktijdig kan worden aangeroepen (bijvoorbeeld tijdens lazy‑initialisatie), synchroniseer die aanroep omdat de licentie‑instellingsmethode zelf niet thread‑safe is.

**Kan ik `Presentation`‑ of `Slide`‑objecten tussen threads doorgeven?**

Het doorgeven van “live” presentatiesobjecten tussen threads wordt niet aanbevolen: gebruik onafhankelijke instanties per thread of maak vooraf afzonderlijke presentaties/diacontainers voor elke thread aan. Deze aanpak volgt de algemene aanbeveling om geen enkele presentatie‑instantie te delen tussen threads.

**Is het veilig om export naar verschillende formaten (PDF, HTML, afbeeldingen) te paralleliseren, mits elke thread zijn eigen `Presentation`‑instantie heeft?**

Ja. Met onafhankelijke instanties en afzonderlijke uitvoerpaden verlopen dergelijke taken meestal correct in parallel; vermijd gedeelde presentatiesobjecten en gedeelde I/O‑streams.

**Wat moet ik doen met globale lettertype‑instellingen (mappen, substituties) bij multithreading?**

Initialiseer alle globale lettertype‑instellingen voordat de threads worden gestart en wijzig ze niet tijdens het parallel uitvoeren. Dit voorkomt race‑condities bij het benaderen van gedeelde lettertype‑bronnen.