---
title: Multithreading in Aspose.Slides voor .NET
linktitle: Multithreading
type: docs
weight: 310
url: /nl/net/multithreading/
keywords:
- multithreading
- meerdere threads
- parallel werk
- dia's converteren
- dia's naar afbeeldingen
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides voor .NET multithreading versnelt de verwerking van PowerPoint en OpenDocument. Ontdek de beste praktijken voor efficiënte presentatieworkflows."
---
## **Inleiding**

Hoewel parallel werken met presentaties mogelijk is (naast het ontleden/laden/kloon) en meestal alles goed gaat, is er een kleine kans dat je onjuiste resultaten krijgt wanneer je de bibliotheek in meerdere threads gebruikt.

We raden ten zeerste aan om **niet** een enkele [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)‑instantie te gebruiken in een multi‑threading‑omgeving, omdat dit kan leiden tot onvoorspelbare fouten of problemen die niet gemakkelijk worden gedetecteerd.

Het is **niet** veilig om een instantie van een [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)‑klasse te laden, op te slaan en/of te klonen in meerdere threads. Dergelijke bewerkingen worden **niet** ondersteund. Als je zulke taken moet uitvoeren, moet je de bewerkingen paralleliseren met meerdere single‑threaded processen — en elk van deze processen moet zijn eigen presentatie‑instantie gebruiken.

## **Presentatieslides parallel naar afbeeldingen converteren**

Stel dat we alle dia's van een PowerPoint‑presentatie parallel willen omzetten naar PNG‑afbeeldingen. Omdat het onveilig is om één `Presentation`‑instantie in meerdere threads te gebruiken, splitsen we de presentatiedia’s in afzonderlijke presentaties en converteren we de dia’s parallel naar afbeeldingen, waarbij elke presentatie in een aparte thread wordt gebruikt. Het volgende code‑voorbeeld laat zien hoe dit werkt.

```cs
var inputFilePath = "sample.pptx";
var outputFilePathTemplate = "slide_{0}.png";
var imageScale = 2;

using var presentation = new Presentation(inputFilePath);

var slideCount = presentation.Slides.Count;
var slideSize = presentation.SlideSize.Size;

var conversionTasks = new List<Task>(slideCount);

for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    // Extraheer dia i in een aparte presentatie.
    var slidePresentation = new Presentation();
    slidePresentation.SlideSize.SetSize(slideSize.Width, slideSize.Height, SlideSizeScaleType.DoNotScale);
    slidePresentation.Slides.RemoveAt(0);
    slidePresentation.Slides.AddClone(presentation.Slides[slideIndex]);

    // Converteer de dia naar een afbeelding in een aparte taak.
    var slideNumber = slideIndex + 1;
    conversionTasks.Add(Task.Run(() =>
    {
        try
        {
            var slide = slidePresentation.Slides[0];

            using var image = slide.GetImage(imageScale, imageScale);
            var imageFilePath = string.Format(outputFilePathTemplate, slideNumber);
            image.Save(imageFilePath, ImageFormat.Png);
        }
        finally
        {
            slidePresentation.Dispose();
        }
    }));
}

await Task.WhenAll(conversionTasks);
```


## **FAQ**

**Moet ik licentie‑inrichting in elke thread aanroepen?**

Nee. Het volstaat om dit één keer per proces/app‑domain te doen voordat de threads starten. Als [license setup](/slides/nl/net/licensing/) gelijktijdig kan worden aangeroepen (bijvoorbeeld tijdens lazy initialisatie), synchroniseer die oproep omdat de licentie‑inrichtingsmethode zelf niet thread‑safe is.

**Kan ik `Presentation`‑ of `Slide`‑objecten tussen threads doorgeven?**

Het doorgeven van “levende” presentatie‑objecten tussen threads wordt niet aanbevolen: gebruik onafhankelijke instanties per thread of maak vooraf afzonderlijke presentaties/slide‑containers voor elke thread. Deze aanpak volgt de algemene aanbeveling om geen enkele presentatie‑instantie te delen over threads heen.

**Is het veilig om export naar verschillende formaten (PDF, HTML, afbeeldingen) te paralleliseren, mits elke thread zijn eigen `Presentation`‑instantie heeft?**

Ja. Met onafhankelijke instanties en aparte uitvoer‑paden verlopen dergelijke taken doorgaans correct parallel; vermijd gedeelde presentatie‑objecten en gedeelde I/O‑streams.

**Wat moet ik doen met globale lettertype‑instellingen (mappen, substituties) in een multi‑threading‑scenario?**

Initialiseer alle globale lettertype‑instellingen voordat de threads worden gestart en wijzig ze niet tijdens parallel werk. Dit voorkomt race‑condities bij het benaderen van gedeelde lettertype‑bronnen.