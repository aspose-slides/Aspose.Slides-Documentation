---
title: Multitrådning i Aspose.Slides för Python
linktitle: Multitrådning
type: docs
weight: 200
url: /sv/python-net/multithreading/
keywords:
- multitrådning
- flera trådar
- parallellt arbete
- konvertera bilder
- bilder till bildfiler
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Aspose.Slides för Python via .NET-multitrådning förbättrar bearbetning av PowerPoint och OpenDocument. Upptäck bästa praxis för effektiva presentationsarbetsflöden."
---
## **Introduktion**

Även om parallellt arbete med presentationer är möjligt (förutom parsning/inläsning/kloning) och allt går bra (oftast), finns det en liten risk att du kan få felaktiga resultat när du använder biblioteket i flera trådar.

Vi rekommenderar starkt att du **inte** använder en enda [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) instans i en multitrådad miljö eftersom det kan leda till oförutsägbara fel eller misslyckanden som inte är lätta att upptäcka.

Det är **inte** säkert att ladda, spara och/eller klona en instans av en [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) klass i flera trådar. Sådana operationer **stöds inte**. Om du behöver utföra sådana uppgifter måste du parallellisera operationerna med flera enklatrådade processer – och varje sådan process ska använda sin egen presentationsinstans.

## **Konvertera presentationsbilder till bilder parallellt**

Anta att vi vill konvertera alla bilder från en PowerPoint-presentation till PNG‑bilder parallellt. Eftersom det är osäkert att använda en enda `Presentation`‑instans i flera trådar delar vi upp presentationsbilderna i separata presentationer och konverterar bilderna till bilder parallellt, där varje presentation används i en separat tråd. Följande kodexempel visar hur man gör detta.

```py
input_file_path = "sample.pptx"
output_file_path_template = "slide_{0}.png"
image_scale = 2

presentation = Presentation(input_file_path)

slide_count = len(presentation.slides)
slide_size = presentation.slide_size.size

conversion_tasks = []


def convert_slide(slide_index):
    # Extrahera bild i till en separat presentation.
    with Presentation() as slide_presentation:
        slide_presentation.slide_size.set_size(slide_size.width, slide_size.height, SlideSizeScaleType.DO_NOT_SCALE)
        slide_presentation.slides.remove_at(0)
        slide_presentation.slides.add_clone(presentation.slides[slide_index])

        slide_number = slide_index + 1
        slide = slide_presentation.slides[0]

        # Konvertera bilden till en bild.
        with slide.get_image(image_scale, image_scale) as image:
            image_file_path = output_file_path_template.format(slide_number)
            image.save(image_file_path, ImageFormat.PNG)


with ThreadPoolExecutor() as thread_executor:
    for index in range(slide_count):
        conversion_tasks.append(thread_executor.submit(convert_slide, index))

# Vänta på att alla uppgifter ska slutföras.
for task in conversion_tasks:
    task.result()

del presentation
```

## **FAQ**

**Behöver jag anropa licensinställning i varje tråd?**

Nej. Det räcker att göra det en gång per process/app‑domän innan trådarna startar. Om [license setup](/slides/sv/python-net/licensing/) kan anropas samtidigt (till exempel under lat initiering), synkronisera det anropet eftersom licensinställningsmetoden i sig inte är trådsäker.

**Kan jag skicka `Presentation`‑ eller `Slide`‑objekt mellan trådar?**

Att skicka "levande" presentationsobjekt mellan trådar rekommenderas inte: använd oberoende instanser per tråd eller förhands skapa separata presentationer/slide‑behållare för varje tråd. Detta tillvägagångssätt följer den allmänna rekommendationen att inte dela en enda presentationsinstans över trådar.

**Är det säkert att parallellisera export till olika format (PDF, HTML, bilder) förutsatt att varje tråd har sin egen `Presentation`‑instans?**

Ja. Med oberoende instanser och separata utdatavägar parallelliseras sådana uppgifter vanligtvis korrekt; undvik delade presentationsobjekt och delade I/O‑strömmar.

**Vad ska jag göra med globala teckensnittsinställningar (mappar, ersättningar) i multitrådning?**

Initiera alla globala teckensnittsinställningar innan trådarna startas och ändra dem inte under parallellt arbete. Detta eliminerar tävlingsförhållanden när delade teckensnittresurser nås.