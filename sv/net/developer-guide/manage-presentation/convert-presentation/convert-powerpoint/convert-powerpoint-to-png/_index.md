---
title: Konvertera PowerPoint‑bilder till PNG i .NET
linktitle: PowerPoint till PNG
type: docs
weight: 30
url: /sv/net/convert-powerpoint-to-png/
keywords:
- konvertera PowerPoint
- konvertera presentation
- konvertera bild
- konvertera PPT
- konvertera PPTX
- PowerPoint till PNG
- presentation till PNG
- bild till PNG
- PPT till PNG
- PPTX till PNG
- spara PPT som PNG
- spara PPTX som PNG
- exportera PPT till PNG
- exportera PPTX till PNG
- .NET
- C#
- Aspose.Slides
description: "Konvertera PowerPoint‑presentationer till högkvalitativa PNG‑bilder snabbt med Aspose.Slides för .NET, vilket säkerställer precisa, automatiserade resultat."
---
## **Översikt**

Den här artikeln förklarar hur man konverterar PowerPoint‑presentationer till PNG‑bilder med Aspose.Slides. Den visar hur man laddar presentationsfiler i format som PPT, PPTX och ODP, renderar bilder som bilder och sparar resultaten i PNG‑format.

Artikeln demonstrerar också hur man anpassar de genererade PNG‑bilderna genom att ange skalvärden eller specificera önskad bredd och höjd.

## **Konvertera PowerPoint till PNG**

Gå igenom dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
2. Hämta bildobjektet från samlingen [Presentation.Slides](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/properties/slides) under gränssnittet [ISlide](https://reference.aspose.com/slides/sv/net/aspose.slides/islide).
3. Använd metoden [ISlide.GetImage(float, float)](https://reference.aspose.com/slides/sv/net/aspose.slides/islide/getimage/) för att rendera varje bild i den skala du behöver.
4. Använd metoden [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.ipresentation/save/methods/5) för att spara bildens miniatyr till PNG‑format.

Den här C#‑koden visar hur man konverterar en PowerPoint‑presentation till PNG. Presentationsobjektet kan läsa in PPT, PPTX, ODP osv, och varje bild i presentationsobjektet konverteras till PNG‑format eller andra bildformat.

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(1f, 1f))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

{{% alert color="info" %}} 
**Obs:** Skalargumenten `1f, 1f` renderar varje bild i sin fulla storlek, så en 720×540 pt‑bild ger en 720×540 px‑bild. Den parameterlösa överlagringen [GetImage()](https://reference.aspose.com/slides/sv/net/aspose.slides/islide/getimage/) returnerar istället en mycket mindre förhandsminiatyr. 
{{% /alert %}} 

## **Konvertera PowerPoint till PNG med anpassade dimensioner**

Om du vill få PNG‑filer i en viss skala kan du sätta värdena för `desiredX` och `desiredY`, som bestämmer dimensionerna på den resulterande miniatyren. 

Den här C#‑koden demonstrerar den beskrivna operationen:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    float scaleX = 2f;
    float scaleY = 2f;
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(scaleX, scaleY))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **Konvertera PowerPoint till PNG med anpassad storlek**

Om du vill få PNG‑filer i en viss storlek kan du ange dina föredragna argument `width` och `height` för `imageSize`. 

Den här koden visar hur du konverterar en PowerPoint till PNG samtidigt som du specificerar storleken på bilderna: 

```c#
using System.Drawing;
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    Size size = new Size(960, 720);
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(size))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **FAQ**

### Hur kan jag exportera endast en specifik form (t.ex. diagram eller bild) istället för hela bilden?

Aspose.Slides stöder [generering av miniatyrer för enskilda former](/slides/sv/net/create-shape-thumbnails/); du kan rendera en form till en PNG‑bild.

### Stöds parallell konvertering på en server?

Ja, men [dela inte](/slides/sv/net/multithreading/) en enda presentationsinstans mellan trådar. Använd en separat instans per tråd eller process.

### Vilka begränsningar finns för provversionen vid export till PNG?

Utvärderingsläget lägger till ett vattenmärke på utskriftsbilder och tillämpar [andra begränsningar](/slides/sv/net/licensing/) tills en licens har aktiverats.