---
title: Multithreading in Aspose.Slides voor Python
linktitle: Multithreading
type: docs
weight: 200
url: /nl/python-net/multithreading/
keywords:
- multithreading
- meerdere threads
- parallelle verwerking
- dia's converteren
- dia's naar afbeeldingen
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Aspose.Slides voor Python via .NET multithreading versnelt de verwerking van PowerPoint- en OpenDocument-bestanden. Ontdek de beste praktijken voor efficiënte presentatieworkflows."
---
## **Inleiding**

Hoewel parallel werken met presentaties mogelijk is (naast parseren/laden/kloon) en meestal alles goed gaat, bestaat er een kleine kans dat je onjuiste resultaten krijgt wanneer je de bibliotheek in meerdere threads gebruikt.

We raden ten zeerste aan om **niet** één enkele [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) instantie in een multi-threading-omgeving te gebruiken, omdat dit kan leiden tot onvoorspelbare fouten of storingen die niet gemakkelijk worden gedetecteerd. 

Het is **niet** veilig om een instantie van een [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse in meerdere threads te laden, op te slaan en/of te klonen. Dergelijke bewerkingen worden **niet** ondersteund. Als je zulke taken moet uitvoeren, moet je de bewerkingen paralleliseren met meerdere single-threaded processen – en elk van deze processen moet zijn eigen presentatie‑instantie gebruiken. 

## **Presentatieslides naar afbeeldingen converteren in parallel**

Stel dat we alle dia's van een PowerPoint‑presentatie parallel naar PNG‑afbeeldingen willen omzetten. Aangezien het onveilig is om één enkele `Presentation`‑instantie in meerdere threads te gebruiken, splitsen we de presentatiedia's op in afzonderlijke presentaties en zetten de dia's parallel om naar afbeeldingen, waarbij elke presentatie in een aparte thread wordt gebruikt. Het volgende code‑voorbeeld toont hoe dit te doen.

```py
input_file_path = "sample.pptx"
output_file_path_template = "slide_{0}.png"
image_scale = 2

presentation = Presentation(input_file_path)

slide_count = len(presentation.slides)
slide_size = presentation.slide_size.size

conversion_tasks = []


def convert_slide(slide_index):
    # Haal dia i op in een afzonderlijke presentatie.
    with Presentation() as slide_presentation:
        slide_presentation.slide_size.set_size(slide_size.width, slide_size.height, SlideSizeScaleType.DO_NOT_SCALE)
        slide_presentation.slides.remove_at(0)
        slide_presentation.slides.add_clone(presentation.slides[slide_index])

        slide_number = slide_index + 1
        slide = slide_presentation.slides[0]

        # Converteer de dia naar een afbeelding.
        with slide.get_image(image_scale, image_scale) as image:
            image_file_path = output_file_path_template.format(slide_number)
            image.save(image_file_path, ImageFormat.PNG)


with ThreadPoolExecutor() as thread_executor:
    for index in range(slide_count):
        conversion_tasks.append(thread_executor.submit(convert_slide, index))

# Wacht tot alle taken voltooid zijn.
for task in conversion_tasks:
    task.result()

del presentation
```

## **Veelgestelde vragen**

**Moet ik de licentie‑instelling in elke thread aanroepen?**

Nee. Het volstaat om dit één keer per proces/app‑domein uit te voeren voordat de threads starten. Als [license setup](/slides/nl/python-net/licensing/) mogelijk gelijktijdig wordt aangeroepen (bijvoorbeeld tijdens lazy‑initialisatie), synchroniseer die oproep omdat de licentie‑instellingsmethode zelf niet thread‑veilig is.

**Kan ik `Presentation`‑ of `Slide`‑objecten tussen threads doorgeven?**

Het doorgeven van "live" presentatiesobjecten tussen threads wordt niet aanbevolen: gebruik onafhankelijke instanties per thread of maak vooraf afzonderlijke presentaties/slide‑containers voor elke thread aan. Deze benadering volgt de algemene aanbeveling om geen enkele presentatie‑instantie te delen tussen threads.

**Is het veilig om export naar verschillende formaten (PDF, HTML, afbeeldingen) te paralleliseren, mits elke thread zijn eigen `Presentation`‑instantie heeft?**

Ja. Met onafhankelijke instanties en aparte uitvoer‑paden kunnen dergelijke taken doorgaans correct parallel worden uitgevoerd; vermijd gedeelde presentatiesobjecten en gedeelde I/O‑streams.

**Wat moet ik doen met globale lettertype‑instellingen (mappen, substituties) bij multi‑threading?**

Initialiseer alle globale lettertype‑instellingen voordat je de threads start en wijzig ze niet tijdens parallel werk. Dit elimineert race‑condities bij het benaderen van gedeelde lettertype‑bronnen.