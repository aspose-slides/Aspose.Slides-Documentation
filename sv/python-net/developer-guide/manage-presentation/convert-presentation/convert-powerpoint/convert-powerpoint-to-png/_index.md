---
title: Konvertera PowerPoint-bilder till PNG i Python
linktitle: Bild till PNG
type: docs
weight: 30
url: /sv/python-net/convert-powerpoint-to-png/
keywords:
- konvertera PowerPoint till PNG
- konvertera presentation till PNG
- konvertera bild till PNG
- konvertera PPT till PNG
- konvertera PPTX till PNG
- konvertera ODP till PNG
- PowerPoint till PNG
- presentation till PNG
- bild till PNG
- PPT till PNG
- PPTX till PNG
- ODP till PNG
- Python
- Aspose.Slides
description: "Konvertera PowerPoint- och OpenDocument-presentationer till högkvalitativa PNG-bilder snabbt med Aspose.Slides for Python via .NET, vilket säkerställer precisa, automatiserade resultat."
---
## **Översikt**

Aspose.Slides for Python via .NET gör det enkelt att konvertera PowerPoint-presentationer till PNG. Du laddar en presentation, itererar genom dess bilder, renderar varje bild till en rasterbild och sparar resultatet som PNG‑filer. Detta är idealiskt för att skapa förhandsgranskningar av bilder, bädda in bilder i webbsidor eller producera statiska resurser för vidare behandling.

## **Konvertera bilder till PNG**

Detta avsnitt visar det enklaste möjliga exemplet för att konvertera en PowerPoint‑presentation till PNG‑bilder med Aspose.Slides for Python via .NET.

Gå igenom dessa steg:

1. Instansiera klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
1. Hämta en bild från `Presentation.slides`‑samlingen (se klassen [Slide](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slide/)).
1. Använd metoden `Slide.get_image` för att generera en miniatyr av bilden.
1. Använd metoden `Presentation.save` för att spara bildens miniatyr i PNG‑format.

Denna Python‑kod visar hur man konverterar en PowerPoint‑presentation till PNG:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image() as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **Konvertera bilder till PNG med anpassade dimensioner**

För att exportera bilder till PNG i en anpassad skala, anropa `Slide.get_image` med horisontella och vertikala skalningsfaktorer. Dessa multiplikatorer ändrar storleken på utskriften i förhållande till bildens ursprungliga dimensioner – till exempel dubblerar `2.0` både bredd och höjd. Använd lika värden för `scale_x` och `scale_y` för att bevara bildförhållandet.

Denna Python‑kod demonstrerar den beskrivna operationen:

```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **Konvertera bilder till PNG med anpassad storlek**

Om du vill skapa PNG‑filer i en specifik storlek, ange önskade `width`‑ och `height`‑värden. Koden nedan visar hur man konverterar en PowerPoint till PNG medan bildstorleken specificeras: 

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

size = drawing.Size(960, 720)

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(size) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

{{% alert title="Tip" color="primary" %}}
Du kanske vill prova Asposes gratis **PowerPoint-till-PNG-omvandlare**—[PPTX till PNG](https://products.aspose.app/slides/sv/conversion/pptx-to-png) och [PPT till PNG](https://products.aspose.app/slides/sv/conversion/ppt-to-png). De erbjuder en live‑implementation av processen som beskrivs på den här sidan.
{{% /alert %}}

## **FAQ**

**Hur kan jag exportera endast en specifik form (t.ex. diagram eller bild) snarare än hela bilden?**

Aspose.Slides stöder [generering av miniatyrer för individuella former](/slides/sv/python-net/create-shape-thumbnails/); du kan rendera en form till en PNG‑bild.

**Stöds parallell konvertering på en server?**

Ja, men [dela inte](/slides/sv/python-net/multithreading/) en enda presentationsinstans mellan trådar. Använd en separat instans per tråd eller process.

**Vilka begränsningar finns i provversionen vid export till PNG?**

Utvärderingsläget lägger till ett vattenstämpel på de genererade bilderna och tillämpar [andra restriktioner](/slides/sv/python-net/licensing/) tills en licens har aktiverats.