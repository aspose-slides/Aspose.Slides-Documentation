---
title: Multitrådad i Aspose.Slides för C++
linktitle: Multitrådad
type: docs
weight: 200
url: /sv/cpp/multithreading/
keywords:
- multitrådad
- flera trådar
- parallellt arbete
- konvertera bildspel
- bildspel till bilder
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Aspose.Slides för C++ multitrådad förbättrar bearbetning av PowerPoint och OpenDocument. Upptäck bästa praxis för effektiva presentationsarbetsflöden."
---
## **Introduction**

Även om parallellt arbete med presentationer är möjligt (förutom parsning/inläsning/kloning) och allt går bra (oftast), finns det en liten risk att du kan få felaktiga resultat när du använder biblioteket i flera trådar.

Vi rekommenderar starkt att du **inte** använder en enda [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation) instans i en multitrådad miljö eftersom det kan leda till oförutsägbara fel eller misslyckanden som inte lätt upptäcks. 

Det är **inte** säkert att ladda, spara och/eller klona en instans av en [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation) klass i flera trådar. Sådana operationer **stöds inte**. Om du behöver utföra sådana uppgifter måste du parallellisera operationerna med flera enkeltrådade processer – och varje process ska använda sin egen presentationsinstans. 

## **Convert Presentation Slides to Images in Parallel**

Låt oss säga att vi vill konvertera alla bildspel från en PowerPoint-presentation till PNG‑bilder parallellt. Eftersom det är osäkert att använda en enda `Presentation`‑instans i flera trådar, delar vi upp presentationsbilderna i separata presentationer och konverterar bilderna till bilder parallellt, genom att använda varje presentation i en separat tråd. Följande kodexempel visar hur man gör detta.

```cpp
auto inputFilePath = u"sample.pptx";
auto outputFilePathTemplate = u"slide_{0}.png";
auto imageScale = 2;

auto presentation = MakeObject<Presentation>(inputFilePath);

auto slideCount = presentation->get_Slides()->get_Count();
auto slideSize = presentation->get_SlideSize()->get_Size();

std::vector<std::future<void>> conversionTasks;

for (auto slideIndex = 0; slideIndex < slideCount; slideIndex++) {
    // Extrahera bild i till en separat presentation.
    auto slidePresentation = MakeObject<Presentation>();
    slidePresentation->get_SlideSize()->SetSize(slideSize.get_Width(), slideSize.get_Height(), SlideSizeScaleType::DoNotScale);
    slidePresentation->get_Slides()->RemoveAt(0);
    slidePresentation->get_Slides()->AddClone(presentation->get_Slide(slideIndex));

    // Konvertera sliden till en bild i en separat uppgift.
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

// Vänta tills alla uppgifter är klara.
for (auto& task : conversionTasks) {
    task.get();
}

presentation->Dispose();
```

## **FAQ**

**Behöver jag anropa licensinställning i varje tråd?**

Nej. Det räcker att göra det en gång per process/app‑domän innan trådarna startar. Om [license setup](/slides/sv/cpp/licensing/) kan anropas samtidigt (till exempel vid latinitiering), synkronisera det anropet eftersom licensinställningsmetoden i sig inte är trådsäker.

**Kan jag skicka `Presentation`‑ eller `Slide`‑objekt mellan trådar?**

Att skicka "levande" presentationsobjekt mellan trådar rekommenderas inte: använd oberoende instanser per tråd eller förhandsSkapa separata presentationer/slide‑behållare för varje tråd. Detta tillvägagångssätt följer den allmänna rekommendationen att inte dela en enda presentationsinstans över trådar.

**Är det säkert att parallellisera export till olika format (PDF, HTML, bilder) förutsatt att varje tråd har sin egen `Presentation`‑instans?**

Ja. Med oberoende instanser och separata utdata‑sökvägar parallelliseras sådana uppgifter vanligtvis korrekt; undvik delade presentationsobjekt och delade I/O‑strömmar.

**Vad bör jag göra med globala teckensnittsinställningar (mappar, ersättningar) i multitrådning?**

Initiera alla globala teckensnittsinställningar innan trådarna startas och ändra dem inte under parallellt arbete. Detta eliminerar race‑förhållanden när delade teckensnittsr​esurser används.