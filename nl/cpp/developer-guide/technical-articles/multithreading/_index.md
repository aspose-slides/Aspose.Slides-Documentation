---
title: Multithreading in Aspose.Slides voor C++
linktitle: Multithreading
type: docs
weight: 200
url: /nl/cpp/multithreading/
keywords:
- multithreading
- meerdere threads
- parallelle verwerking
- dia's converteren
- dia's naar afbeeldingen
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Aspose.Slides voor C++ multithreading verbetert de verwerking van PowerPoint en OpenDocument. Ontdek de beste praktijken voor efficiënte presentatiewerkstromen."
---
## **Inleiding**

Hoewel parallel werken met presentaties mogelijk is (naast het parseren/laden/klonen) en meestal alles goed gaat, is er een kleine kans dat je onjuiste resultaten krijgt wanneer je de bibliotheek in meerdere threads gebruikt.

We raden ten zeerste aan **niet** één enkele [Presentation](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation) instantie te gebruiken in een multithread‑omgeving, omdat dit onvoorspelbare fouten of storingen kan veroorzaken die moeilijk te detecteren zijn.

Het is **niet** veilig om een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation) te laden, op te slaan en/of te klonen in meerdere threads. Dergelijke bewerkingen worden **niet** ondersteund. Als je dergelijke taken moet uitvoeren, moet je de bewerkingen paralleliseren met meerdere single‑threaded processen—en elk van deze processen moet zijn eigen presentaties‑instantie gebruiken.

## **Presentatieslides parallel omzetten naar afbeeldingen**

Stel dat we alle dia's van een PowerPoint‑presentatie parallel willen omzetten naar PNG‑afbeeldingen. Omdat het onveilig is om één enkele `Presentation`‑instantie in meerdere threads te gebruiken, splitten we de presentatiedia's op in afzonderlijke presentaties en zetten we de dia's parallel om naar afbeeldingen, waarbij elke presentatie in een eigen thread wordt gebruikt. Het volgende code‑voorbeeld laat zien hoe dit te doen.

```cpp
auto inputFilePath = u"sample.pptx";
auto outputFilePathTemplate = u"slide_{0}.png";
auto imageScale = 2;

auto presentation = MakeObject<Presentation>(inputFilePath);

auto slideCount = presentation->get_Slides()->get_Count();
auto slideSize = presentation->get_SlideSize()->get_Size();

std::vector<std::future<void>> conversionTasks;

for (auto slideIndex = 0; slideIndex < slideCount; slideIndex++) {
    // Extraheer dia i in een aparte presentatie.
    auto slidePresentation = MakeObject<Presentation>();
    slidePresentation->get_SlideSize()->SetSize(slideSize.get_Width(), slideSize.get_Height(), SlideSizeScaleType::DoNotScale);
    slidePresentation->get_Slides()->RemoveAt(0);
    slidePresentation->get_Slides()->AddClone(presentation->get_Slide(slideIndex));

    // Converteer de dia naar een afbeelding in een aparte taak.
    auto slideNumber = slideIndex + 1;
    conversionTasks.push_back(std::async(std::launch::async, [slidePresentation = std::move(slidePresentation), slideNumber, outputFilePathTemplate, imageScale]() {
        SharedPtr<IImage> image = nullptr;
        try {
            auto slide = slidePresentation->get_Slide(0);

            auto image = slide->GetImage(imageScale, imageScale);
            auto imageFilePath = String::Format(outputFilePathTemplate, slideNumber);
            image->Save(imageFilePath, ImageFormat::Png);
        }
        catch (Exception e) {
            if(image != nullptr) image->Dispose();
            slidePresentation->Dispose();
        }
    }));
}

// Wacht tot alle taken voltooid zijn.
for (auto& task : conversionTasks) {
    task.get();
}

presentation->Dispose();
```

## **FAQ**

**Moet ik de licentie‑instelling in elke thread aanroepen?**

Nee. Het volstaat om dit één keer per proces/app‑domain uit te voeren voordat de threads starten. Als de [license setup](/slides/nl/cpp/licensing/) mogelijk gelijktijdig wordt aangeroepen (bijvoorbeeld tijdens lazy initialisatie), synchroniseer die aanroep omdat de licentie‑instellingsmethode zelf niet thread‑safe is.

**Kan ik `Presentation`‑ of `Slide`‑objecten tussen threads doorgeven?**

Het doorgeven van “live” presentatiesobjecten tussen threads wordt niet aanbevolen: gebruik onafhankelijke instanties per thread of maak vooraf afzonderlijke presentaties/slide‑containers voor elke thread aan. Deze aanpak volgt de algemene aanbeveling om geen enkele presentatie‑instantie te delen tussen threads.

**Is het veilig om de export naar verschillende formaten (PDF, HTML, afbeeldingen) te paralleliseren, mits elke thread zijn eigen `Presentation`‑instantie heeft?**

Ja. Met onafhankelijke instanties en aparte uitvoer‑paden paralleliseren dergelijke taken over het algemeen goed; vermijd gedeelde presentatiesobjecten en gedeelde I/O‑streams.

**Wat moet ik doen met globale lettertype‑instellingen (mappen, substituties) bij multithreading?**

Initialiseer alle globale lettertype‑instellingen voordat de threads worden gestart en wijzig ze niet tijdens parallel werk. Dit voorkomt race‑condities bij het benaderen van gedeelde lettertype‑bronnen.