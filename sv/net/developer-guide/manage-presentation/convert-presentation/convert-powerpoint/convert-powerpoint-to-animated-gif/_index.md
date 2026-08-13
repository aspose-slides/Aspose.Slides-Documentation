---
title: Konvertera PowerPoint-presentationer till animerade GIF-filer i .NET
linktitle: PowerPoint till GIF
type: docs
weight: 65
url: /sv/net/convert-powerpoint-to-animated-gif/
keywords:
- animerad GIF
- konvertera PowerPoint
- konvertera presentation
- konvertera bild
- konvertera PPT
- konvertera PPTX
- PowerPoint till GIF
- presentation till GIF
- bild till GIF
- PPT till GIF
- PPTX till GIF
- spara PPT som GIF
- spara PPTX som GIF
- exportera PPT som GIF
- exportera PPTX som GIF
- standardinställningar
- anpassade inställningar
- .NET
- C#
- Aspose.Slides
description: "Konvertera enkelt PowerPoint-presentationer (PPT, PPTX) till animerade GIF-filer med Aspose.Slides för .NET. Snabba, högkvalitativa resultat."
---
## **Översikt**

Aspose.Slides låter dig konvertera PowerPoint-presentationer till animerade GIF-filer med bara några rader kod. Detta är användbart när du behöver dela bildinnehåll i ett lättviktigt, brett stödt animerat format som kan bäddas in i webbsidor, meddelanden eller dokumentation. Den här artikeln förklarar hur du exporterar en presentation till GIF med standardinställningar och hur du anpassar utdata genom att konfigurera alternativ som bildstorlek, bildfördröjning och övergångens bildhastighet via [GifOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/gifoptions/).

## **Konvertera presentationer till animerad GIF med standardinställningar**

Denna exempelkod i C# visar hur du konverterar en presentation till animerad GIF med standardinställningar:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif);
}
```

Den animerade GIF-filen skapas med standardparametrar.

{{%  alert  title="TIP"  color="info"  %}} 
Om du föredrar att anpassa parametrarna för GIF-filen kan du använda klassen [GifOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/gifoptions). Se exempelkoden nedan. 
{{% /alert %}} 

## **Konvertera presentationer till animerad GIF med anpassade inställningar**

Denna exempelkod visar hur du konverterar en presentation till animerad GIF med anpassade inställningar i C#:

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif, new GifOptions
    {
        FrameSize = new Size(960, 720), // storleken på den resulterande GIF-filen  
        DefaultDelay = 2000, // hur länge varje bild visas innan den byts till nästa
        TransitionFps = 35 // öka FPS för bättre övergångsanimeringskvalitet
    });
}
```

{{% alert title="Info" color="info" %}}
Du kanske vill titta på en GRATIS [Text to GIF](https://products.aspose.app/slides/sv/text-to-gif)-konverterare som utvecklats av Aspose. 
{{% /alert %}}

## **Vanliga frågor**

### Vad händer om typsnitten som används i presentationen inte är installerade på systemet?

Installera de saknade typsnitten eller [konfigurera reservtypsnitt](/slides/sv/net/powerpoint-fonts/). Aspose.Slides kommer att ersätta dem, men utseendet kan skilja sig. För varumärkesprofilering, se alltid till att de nödvändiga teckensnitten är explicit tillgängliga.

### Kan jag lägga ett vattenmärke över GIF-ramarna?

Ja. [Add a semi-transparent object/logo](/slides/sv/net/watermark/) till mastern på bilden eller till enskilda bilder innan export – vattenmärket kommer att visas på varje ram.