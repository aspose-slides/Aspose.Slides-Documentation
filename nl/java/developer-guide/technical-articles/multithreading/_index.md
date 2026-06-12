---
title: Multithreading in Aspose.Slides voor Java
linktitle: Multithreading
type: docs
weight: 310
url: /nl/java/multithreading/
keywords:
- multithreading
- meerdere threads
- parallel werk
- slides converteren
- slides naar afbeeldingen
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Aspose.Slides for Java multithreading verbetert de verwerking van PowerPoint en OpenDocument. Ontdek de beste praktijken voor efficiënte presentatieworkflows."
---
## **Inleiding**

Hoewel parallel werken met presentaties mogelijk is (naast parseren/laden/klooneren) en meestal alles goed gaat, bestaat er een kleine kans dat je onjuiste resultaten krijgt wanneer je de bibliotheek in meerdere threads gebruikt.

We raden ten zeerste aan om **geen** enkele [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) instantie te gebruiken in een multi‑threading omgeving, omdat dit kan leiden tot onvoorspelbare fouten of storingen die moeilijk te detecteren zijn.

Het is **niet** veilig om een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse te laden, op te slaan en/of te klonen in meerdere threads. Dergelijke bewerkingen worden **niet** ondersteund. Als je dergelijke taken moet uitvoeren, moet je de bewerkingen paralleliseren met meerdere single‑threaded processen—en elk van deze processen moet zijn eigen presentatie‑instantie gebruiken.

## **Presentatieslides parallel omzetten naar afbeeldingen**

Stel dat we alle slides van een PowerPoint‑presentatie parallel willen omzetten naar PNG‑afbeeldingen. Aangezien het onveilig is om één `Presentation`‑instantie in meerdere threads te gebruiken, splitsen we de slides op in afzonderlijke presentaties en zetten we de slides parallel om naar afbeeldingen, waarbij elke presentatie in een eigen thread wordt gebruikt. Het volgende code‑voorbeeld laat zien hoe dit te doen.

```java
String inputFilePath = "sample.pptx";
String outputFilePathTemplate = "slide_%d.png";
final float imageScale = 2;

Presentation presentation = new Presentation(inputFilePath);

int slideCount = presentation.getSlides().size();
Dimension2D slideSize = presentation.getSlideSize().getSize();
float slideWidth = (float) slideSize.getWidth();
float slideHeight = (float) slideSize.getHeight();

List<CompletableFuture<Void>> conversionTasks = new ArrayList<>(slideCount);

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
    // Extraheer dia i in een aparte presentatie.
    Presentation slidePresentation = new Presentation();
    slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);
    slidePresentation.getSlides().removeAt(0);
    slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

    // Converteer de dia naar een afbeelding in een aparte taak.
    final int slideNumber = slideIndex + 1;
    conversionTasks.add(CompletableFuture.runAsync(() -> {
        IImage image = null;
        try {
            ISlide slide = slidePresentation.getSlides().get_Item(0);

            image = slide.getImage(imageScale, imageScale);
            String imageFilePath = String.format(outputFilePathTemplate, slideNumber);
            image.save(imageFilePath, ImageFormat.Png);
        } finally {
            if (image != null) image.dispose();
            slidePresentation.dispose();
        }
    }));
}

// Wacht tot alle taken voltooid zijn.
CompletableFuture.allOf(conversionTasks.toArray(new CompletableFuture[0])).join();

presentation.dispose();
```

## **FAQ**

**Moet ik de licentie‑instelling in elke thread aanroepen?**

Nee. Het volstaat om dit één keer per proces/app‑domain uit te voeren voordat de threads starten. Als de [license setup](/slides/nl/java/licensing/) mogelijk gelijktijdig wordt aangeroepen (bijvoorbeeld tijdens lazy initialisatie), synchroniseer die oproep omdat de licentie‑instellingsmethode zelf niet thread‑safe is.

**Kan ik `Presentation`‑ of `Slide`‑objecten tussen threads doorgeven?**

Het doorgeven van ‘live’ presentatie‑objecten tussen threads wordt niet aanbevolen: gebruik onafhankelijke instanties per thread of maak vooraf afzonderlijke presentaties/slide‑containers voor elke thread aan. Deze aanpak volgt de algemene aanbeveling om geen enkele presentatie‑instantie over threads te delen.

**Is het veilig om export naar verschillende formaten (PDF, HTML, afbeeldingen) te paralleliseren, mits elke thread zijn eigen `Presentation`‑instantie heeft?**

Ja. Met onafhankelijke instanties en afzonderlijke uitvoer‑paden paralleliseren dergelijke taken doorgaans correct; vermijd gedeelde presentatie‑objecten en gedeelde I/O‑streams.

**Wat moet ik doen met globale lettertype‑instellingen (mappen, substituties) bij multithreading?**

Initialiseer alle globale [font settings](/slides/nl/java/powerpoint-fonts/) voordat je de threads start en wijzig ze niet tijdens parallel werk. Dit voorkomt race‑condities bij het benaderen van gedeelde lettertype‑bronnen.