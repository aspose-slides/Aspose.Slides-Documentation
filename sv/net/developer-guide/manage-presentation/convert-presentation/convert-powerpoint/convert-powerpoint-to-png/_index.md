---
title: Konvertera PowerPoint-bilder till PNG i .NET
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
description: "Konvertera PowerPoint-presentationer till högkvalitativa PNG-bilder snabbt med Aspose.Slides för .NET, vilket säkerställer precisa, automatiserade resultat."
---
## **Översikt**

Denna artikel förklarar hur du konverterar PowerPoint-presentationer till PNG‑bilder med Aspose.Slides. Den visar hur du läser in presentationsfiler i format som PPT, PPTX och ODP, renderar bilder som bilder och sparar resultatet i PNG‑format.

Artikeln visar också hur du anpassar de genererade PNG‑bilderna genom att ange skalvärden eller specificera önskad bredd och höjd.

## **Konvertera PowerPoint till PNG**

Följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
2. Hämta bildobjektet från samlingen [Presentation.Slides](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/properties/slides) under gränssnittet [ISlide](https://reference.aspose.com/slides/sv/net/aspose.slides/islide).
3. Använd metoden [ISlide.GetImage](https://reference.aspose.com/slides/sv/net/aspose.slides/islide/getimage/) för att hämta miniatyrbilden för varje bild.
4. Använd metoden [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.ipresentation/save/methods/5) för att spara bildens miniatyr till PNG‑format.

Den här C#‑koden visar hur du konverterar en PowerPoint-presentation till PNG. Presentation‑objektet kan läsa in PPT, PPTX, ODP med mera, och varje bild i presentationsobjektet konverteras sedan till PNG‑format eller andra bildformat.

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage())
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **Konvertera PowerPoint till PNG med anpassade dimensioner**

Om du vill få PNG‑filer med en viss skala kan du sätta värdena för `desiredX` och `desiredY`, som bestämmer dimensionerna på den resulterande miniatyrbilden.

Denna C#‑kod demonstrerar den beskrivna operationen:

```c#
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

Om du vill få PNG‑filer med en viss storlek kan du skicka dina föredragna argument `width` och `height` för `imageSize`.

Denna kod visar hur du konverterar en PowerPoint till PNG samtidigt som du specificerar storleken för bilderna:

```c#
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

## **Vanliga frågor**

**Hur kan jag exportera endast en specifik form (t.ex. diagram eller bild) istället för hela bilden?**

Aspose.Slides stödjer att generera miniatyrbilder för enskilda former; du kan rendera en form till en PNG‑bild.

**Stöds parallell konvertering på en server?**

Ja, men dela inte en enda presentation‑instans över trådar. Använd en separat instans per tråd eller process.

**Vilka begränsningar gäller för provversionen vid export till PNG?**

Utvärderingsläget lägger till ett vattenmärke på utdatasbilder och tillämpar andra begränsningar tills en licens har aktiverats.