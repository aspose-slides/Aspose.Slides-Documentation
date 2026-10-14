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

Denna artikel förklarar hur du konverterar presentationsbilder till PNG‑bilder med Aspose.Slides för .NET. Du kan läsa in presentationer i format som PPT, PPTX och ODP, rendera varje bild och spara den som en separat PNG‑bild.

Exemplen nedan demonstrerar rendera miniatyrbilder, ange skalningsfaktorer, specificera utdata-dimensionerna i pixlar och välja en gradientrenderingsstil.

## **Konvertera PowerPoint till PNG**

Läs in en presentation med klassen [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) och få åtkomst till dess bilder via samlingen [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/). Exemplet renderar varje bild med [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) utan parametrar för att skapa en miniatyrbild. Det anropar sedan [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) med [ImageFormat.Png](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) för att spara varje renderad bild som en PNG‑bild.

```cs
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage();
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

{{% alert color="info" title="Note" %}}
Den parameterlösa [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/)‑överladdningen renderar med en skala på 0,2. Till exempel ger en bild som mäter 720 × 540 punkter en miniatyr på 144 × 108 pixlar. För att kontrollera utdata‑dimensionerna, använd överladdningarna med skalningsfaktorer eller en explicit bildstorlek som visas nedan.
{{% /alert %}}

## **Konvertera PowerPoint till PNG med anpassade dimensioner**

Skicka horisontella och vertikala skalningsfaktorer till [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) för att kontrollera de renderade dimensionerna. I detta exempel är båda faktorerna 2, så en bild som mäter 720 × 540 punkter ger en bild på 1440 × 1080 pixlar. Lika skalningsfaktorer bevarar bildens bildförhållande. Varje bild sparas i PNG‑format med [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/).

```cs
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var scaleX = 2f;
var scaleY = scaleX;

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(scaleX, scaleY);
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

## **Konvertera PowerPoint till PNG med anpassad storlek**

För att ange utdata‑dimensioner i pixlar, skicka en storlek till [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) istället för skalningsfaktorer. Detta exempel renderar varje bild i 960 × 720 pixlar och sparar resultatet med [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/). Välj dimensioner som matchar bildens bildförhållande för att undvika att bilden sträcks.

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var imageSize = new Size(960, 720);

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(imageSize);
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

## **Välj en gradientrenderingsstil**

Anta att en bild innehåller gradientfyllningar, men övergångarna i den exporterade PNG‑filen ser ljusare eller på annat sätt annorlunda ut än vad du ser i PowerPoint. Du kan använda egenskapen [GradientStyle](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/gradientstyle/) i [RenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/renderingoptions/) för att välja hur gradienterna renderas.

Ladda ner [gradient-styles.pptx](gradient-styles.pptx) och placera den i applikationens arbetskatalog. Dess första bild innehåller två linjära gradienter: cyan till orange högst upp och blå till gul längst ner. Varje gradient har två stopp, vid 0 % och 100 %.

Följande exempel läser in denna presentation och renderar samma första bild i båda lägen med [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/).

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("gradient-styles.pptx");
var slide = presentation.Slides[0];

var gradientStyles = new[] { GradientStyle.Default, GradientStyle.PowerPointUI };
foreach (var style in gradientStyles)
{
    var options = new RenderingOptions { GradientStyle = style };
    using var image = slide.GetImage(options, 1f, 1f);
    image.Save($"gradient-{style}.png", ImageFormat.Png);
}
```

Bilderna nedan visar resultatet från samma bild, med båda gradienterna i varje bild:

| Default | PowerPointUI |
| --- | --- |
| ![Cyan-till-orange och blå-till-gul gradienter renderade med Default](gradient-Default.png) | ![Samma gradienter renderade med PowerPointUI](gradient-PowerPointUI.png) |

I detta exempel ger `Default` ljusare mellanfärger, medan `PowerPointUI` ger mörkare mellanfärger. Skillnaden beror på färgerna och stoppen i gradienten.

Välj `Default` när den standardmässiga Aspose.Slides‑utgången passar dina behov. Prova `PowerPointUI` när din prioritet är att matcha utseendet i PowerPoint. Jämför båda utgångarna med ditt önskade resultat; inget läge är generellt föredraget.

## **Vanliga frågor**

**Hur kan jag exportera en specifik form, till exempel ett diagram eller en bild, istället för hela bilden?**

Aspose.Slides stöder [generera miniatyrbilder för enskilda former](/slides/sv/net/create-shape-thumbnails/), vilket gör att du kan rendera en form som en PNG‑bild.

**Stöds parallell konvertering på en server?**

Ja. Använd en separat presentationsinstans för varje tråd eller process; [dela inte en enda instans över trådar](/slides/sv/net/multithreading/).

**Vilka är utvärderingsbegränsningarna vid export till PNG?**

Utvärderingsläget lägger till ett vattenstämpel på utdata‑bilder och tillämpar [andra begränsningar](/slides/sv/net/licensing/) tills en licens har tillämpats.