---
title: Konvertera PowerPoint-bilder till PNG i Python
linktitle: PowerPoint till PNG
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
description: "Konvertera PowerPoint- och OpenDocument-presentationer till högkvalitativa PNG‑bilder snabbt med Aspose.Slides för Python via .NET, vilket säkerställer precisa, automatiserade resultat."
---
## **Översikt**

Den här artikeln förklarar hur du konverterar presentationsbilder till PNG‑bilder med Aspose.Slides för Python via .NET. Du kan läsa in presentationer i format som PPT, PPTX och ODP, rendera varje bild och spara den som en separat PNG‑fil.

Exemplen nedan demonstrerar rendering med standardskala, ökad skala, angivande av utgångsdimensioner i pixlar och val av en gradientrenderingsstil.

## **Konvertera PowerPoint till PNG**

Läs in en presentation med klassen [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) och få åtkomst till dess bilder via samlingen [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/). Exemplet renderar varje bild med [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) utan parametrar för att skapa en miniatyr. Det anropar därefter [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) med [ImageFormat.PNG](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/) för att spara varje renderad bild som en PNG‑fil.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image() as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

{{% alert color="info" title="Note" %}}
Den parameterlösa överlagringen av [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) renderar med en skala på 0,2. Till exempel producerar en bild som mäter 720 × 540 punkter en miniatyr på 144 × 108 pixlar. För att styra utgångsdimensionerna, använd överlagringarna med skalningsfaktorer eller en explicit bildstorlek som visas nedan.
{{% /alert %}}

## **Konvertera PowerPoint till PNG med anpassade dimensioner**

Skicka horisontella och vertikala skalningsfaktorer till [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) för att kontrollera de renderade dimensionerna. I detta exempel är båda faktorerna 2, så en bild som mäter 720 × 540 punkter ger en bild på 1440 × 1080 pixlar. Likadana skalningsfaktorer bevarar bildens bildförhållande. Varje bild sparas i PNG‑format med [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/).

```python
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **Konvertera PowerPoint till PNG med anpassad storlek**

För att ange utgångsdimensioner i pixlar, skicka en storlek till [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) istället för skalningsfaktorer. Detta exempel renderar varje bild i 960 × 720 pixlar och sparar resultatet med [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/). Välj dimensioner som matchar bildens bildförhållande för att undvika att bilden sträcks.

```python
import aspose.slides as slides

image_size = slides.Size(960, 720)

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(image_size) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **Välj en gradientrenderingsstil**

Anta att en bild innehåller gradientfyllningar, men övergångarna i den exporterade PNG‑filen ser ljusare eller på annat sätt annorlunda ut jämfört med vad du ser i PowerPoint. Du kan använda egenskapen [gradient_style](https://reference.aspose.com/slides/python-net/aspose.slides.export/saveoptions/gradient_style/) i [RenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/renderingoptions/) för att välja hur gradienterna renderas.

Ladda ner [gradient-styles.pptx](gradient-styles.pptx) och placera den i applikationens arbetskatalog. Dess första bild innehåller två linjära gradienter: cyan till orange högst upp och blå till gul längst ner. Varje gradient har två stopp, vid 0 % och 100 %.

Följande exempel läser in denna presentation och renderar samma första bild i båda lägena med [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/).

```python
import aspose.slides as slides

with slides.Presentation("gradient-styles.pptx") as presentation:
    slide = presentation.slides[0]

    gradient_styles = [slides.GradientStyle.DEFAULT, slides.GradientStyle.POWER_POINT_UI]
    for style in gradient_styles:
        options = slides.export.RenderingOptions()
        options.gradient_style = style

        with slide.get_image(options, 1.0, 1.0) as image:
            image.save(f"gradient-{style.name}.png", slides.ImageFormat.PNG)
```

Bilderna nedan visar resultatet från samma bild, med båda gradienterna i varje bild:

| Standard | PowerPointUI |
| --- | --- |
| ![Cyan‑till‑orange och blå‑till‑gul gradienter renderade med Standard](gradient-Default.png) | ![Samma gradienter renderade med PowerPointUI](gradient-PowerPointUI.png) |

I detta exempel ger `DEFAULT` ljusare mellanfärger, medan `POWER_POINT_UI` ger mörkare mellanfärger. Skillnaden beror på färgerna och stoppen i gradienten.

Välj `DEFAULT` när den standardmässiga Aspose.Slides‑utmatningen passar dina behov. Prova `POWER_POINT_UI` när ditt mål är att matcha utseendet i PowerPoint. Jämför båda resultaten med det önskade resultatet; ingen av lägena är generellt att föredra.

## **Vanliga frågor**

**Hur kan jag exportera en specifik form, till exempel ett diagram eller en bild, istället för hela bilden?**

Aspose.Slides stöder [generering av miniatyrer för enskilda former](/slides/sv/python-net/create-shape-thumbnails/), vilket gör att du kan rendera en form som en PNG‑bild.

**Stöds parallell konvertering på en server?**

Ja. Använd en separat presentationsinstans för varje tråd eller process; [dela inte en enda instans över trådar](/slides/sv/python-net/multithreading/).

**Vilka begränsningar finns i utvärderingsläget vid export till PNG?**

Utvärderingsläget lägger till ett vattenmärke på utdatabilderna och tillämpar [andra begränsningar](/slides/sv/python-net/licensing/) tills en licens har aktiverats.