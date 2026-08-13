---
title: Effektiv sammanslagning av presentationer i .NET
linktitle: Sammanslå presentationer
type: docs
weight: 40
url: /sv/net/merge-presentation/
keywords:
- sammanfoga PowerPoint
- sammanfoga presentationer
- sammanfoga bilder
- sammanfoga PPT
- sammanfoga PPTX
- sammanfoga ODP
- kombinera PowerPoint
- kombinera presentationer
- kombinera bilder
- kombinera PPT
- kombinera PPTX
- kombinera ODP
- .NET
- C#
- Aspose.Slides
description: "Sammanfoga enkelt PowerPoint (PPT, PPTX) och OpenDocument (ODP) presentationer med Aspose.Slides för .NET, vilket förenklar ditt arbetsflöde."
---
## **Översikt**

Aspose.Slides låter dig slå ihop presentationer genom att klona bilder från en presentation till en annan. Denna artikel förklarar hur du slår ihop hela presentationer eller utvalda bilder, använder ett bildmaster eller en specifik layout under sammanslagningen, hanterar presentationer med olika bildstorlekar, och lägger till sammanslagna bilder i ett presentationsavsnitt. Den täcker också praktiska noteringar relaterade till sammanslaget innehåll, inklusive talarnoter, kommentarer, lösenordsskyddade källfiler och trådanvändning.

## **Optimera din presentationssammanfogning**

Med [Aspose.Slides for .NET](https://products.aspose.com/slides/sv/net/) kan du sömlöst kombinera PowerPoint-presentationer samtidigt som du bevarar stilar, layouter och alla element. Till skillnad från andra verktyg blandar Aspose.Slides presentationer utan att kompromissa med kvalitet eller förlora data. Slå ihop hela presentationer, specifika bilder och även olika filformat (PPT till PPTX, etc.).

### **Sammanfogningsfunktioner**

- **Fullständig presentationssammanfogning:** Samla alla bilder i en enda fil.
- **Specifik bildsammanfogning:** Välj och kombinera utvalda bilder.
- **Tvärformatssammanslagning:** Integrera presentationer av olika format, med bibehållen integritet.

{{% alert title="Tips" color="info" %}}  

Letar du efter ett snabbt och **gratis onlineverktyg** för att **slå ihop PowerPoint-presentationer**? Prova [**Aspose PowerPoint Merger**](https://products.aspose.app/slides/sv/merger).  

- **Slå enkelt ihop PowerPoint-filer**: Kombinera flera **PPT, PPTX, ODP**-presentationer till en enda fil.  
- **Stöder olika format**: Slå ihop **PPT till PPTX**, **PPTX till ODP**, och mer.  
- **Ingen installation krävs**: Fungerar direkt i din webbläsare, snabbt och säkert.  

[![Merge PowerPoint Files Online](slides-merger.png)](https://products.aspose.app/slides/sv/merger)  

Börja slå ihop dina PowerPoint-filer med **Aspose gratis onlineverktyg** idag!  

{{% /alert %}}

## **Presentationssammanfogning**

När du [slår ihop en presentation med en annan](https://products.aspose.com/slides/sv/net/merger/ppt/) kombinerar du i praktiken deras bilder i en enda presentation för att få en fil. 

{{% alert title="Info" color="info" %}}

De flesta presentationsprogram (PowerPoint eller OpenOffice) saknar funktioner som låter användare kombinera presentationer på detta sätt. 

[**Aspose.Slides for .NET**](https://products.aspose.com/slides/sv/net/) låter dig dock slå ihop presentationer på olika sätt. Du kan slå ihop presentationer med alla deras former, stilar, texter, formatering, kommentarer, animationer osv. utan att behöva oroa dig för förlust av kvalitet eller data. 

**Se också**

[Klona bilder](https://docs.aspose.com/slides/sv/net/cloning-commenting-and-manipulating-slides/#cloning-commentingandmanipulatingslides-cloningslides)*.* 

{{% /alert %}}

### **Vad kan slås ihop**

Med Aspose.Slides, kan du slå ihop

* hela presentationer. Alla bilder från presentationerna hamnar i en enda presentation
* specifika bilder. Utvalda bilder hamnar i en enda presentation
* presentationer i ett format (PPT till PPT, PPTX till PPTX, etc) och i olika format (PPT till PPTX, PPTX till ODP, etc) till varandra. 

{{% alert title="Obs" color="warning" %}} 

Förutom presentationer låter Aspose.Slides dig slå ihop andra filer:

* [Bilder](https://products.aspose.com/slides/sv/net/merger/image-to-image/), såsom [JPG till JPG](https://products.aspose.com/slides/sv/net/merger/jpg-to-jpg/) eller [PNG till PNG](https://products.aspose.com/slides/sv/net/merger/png-to-png/)
* Dokument, såsom [PDF till PDF](https://products.aspose.com/slides/sv/net/merger/pdf-to-pdf/) eller [HTML till HTML](https://products.aspose.com/slides/sv/net/merger/html-to-html/)
* Och två olika filer såsom [bild till PDF](https://products.aspose.com/slides/sv/net/merger/image-to-pdf/) eller [JPG till PDF](https://products.aspose.com/slides/sv/net/merger/jpg-to-pdf/) eller [TIFF till PDF](https://products.aspose.com/slides/sv/net/merger/tiff-to-pdf/).

{{% /alert %}}

### **Sammanfogningsalternativ**

Du kan tillämpa alternativ som bestämmer om

* varje bild i den resulterande presentationen behåller en unik stil
* en specifik stil används för alla bilder i den resulterande presentationen. 

För att slå ihop presentationer tillhandahåller Aspose.Slides [AddClone](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection/methods/addclone)-metoder (från [ISlideCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection)-gränssnittet). Det finns flera implementationer av `AddClone`‑metoderna som definierar parametrarna för presentationssammanfogningen. Varje Presentation‑objekt har en [Slides](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/properties/slides)-samling, så du kan anropa en `AddClone`‑metod från den presentation som du vill slå ihop bilder i. 

`AddClone`‑metoden returnerar ett `ISlide`‑objekt, som är en klon av källbilden. Bilderna i den resulterande presentationen är helt enkelt en kopia av bilderna från källan. Därför kan du göra ändringar i de resulterande bilderna (t.ex. tillämpa stilar, formateringsalternativ eller layouter) utan att oroa dig för att källpresentationerna påverkas. 

## **Slå ihop presentationer** 

Aspose.Slides tillhandahåller [**AddClone (ISlide)**](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection/methods/addclone)-metoden som låter dig kombinera bilder medan bilderna behåller sina layouter och stilar (standardparametrar). 

Denna C#-kod visar hur du slår ihop presentationer:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    foreach (ISlide slide in pres2.Slides)
    {
        pres1.Slides.AddClone(slide);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

## **Slå ihop presentationer med en bildmaster**

Aspose.Slides tillhandahåller [**AddClone (ISlide, IMasterSlide, Boolean)**](https://reference.aspose.com/slides/sv/net/aspose.slides.islidecollection/addclone/methods/2)-metoden som låter dig kombinera bilder samtidigt som du tillämpar en bildmaster‑presentationsmall. På så sätt kan du vid behov ändra stilen för bilderna i den resulterande presentationen. 

Denna C#-kod demonstrerar den beskrivna operationen:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    foreach (ISlide slide in pres2.Slides)
    {
        pres1.Slides.AddClone(slide, pres2.Masters[0], allowCloneMissingLayout: true);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

{{% alert title="Obs" color="warning" %}} 

Bildlayouten för bildmastern bestäms automatiskt. När en lämplig layout inte kan bestämmas, om den booleska parametern `allowCloneMissingLayout` för `AddClone`‑metoden är satt till true, används layouten för källbilden. Annars kommer ett [PptxEditException](https://reference.aspose.com/slides/sv/net/aspose.slides/pptxeditexception)-undantag att kastas. 

{{% /alert %}}

Om du vill att bilderna i den resulterande presentationen ska ha en annan bildlayout, använd [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/sv/net/aspose.slides.islidecollection/addclone/methods/1)-metoden istället vid sammanslagning. 

## **Slå ihop specifika bilder från presentationer**

Att slå ihop specifika bilder från flera presentationer är användbart för att skapa anpassade bildsamlingar. Aspose.Slides for .NET låter dig välja och importera endast de bilder du behöver. API:n bevarar formatering, layout och design på de ursprungliga bilderna. 

Följande C#-kod skapar en ny presentation, lägger till titelbilder från två andra presentationer och sparar resultatet till en fil:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
using (Presentation presentation1 = new Presentation("presentation1.pptx"))
using (Presentation presentation2 = new Presentation("presentation2.pptx"))
{
    presentation.Slides.RemoveAt(0);

    ISlide slide1 = GetTitleSlide(presentation1);

    if (slide1 != null)
        presentation.Slides.AddClone(slide1);

    ISlide slide2 = GetTitleSlide(presentation2);

    if (slide2 != null)
        presentation.Slides.AddClone(slide2);

    presentation.Save("combined.pptx", SaveFormat.Pptx);
}

static ISlide GetTitleSlide(IPresentation presentation)
{
    foreach (ISlide slide in presentation.Slides)
    {
        if (slide.LayoutSlide.LayoutType == SlideLayoutType.Title)
        {
            return slide;
        }
    }
    return null;
}
```
```cs
using Aspose.Slides;

static ISlide GetTitleSlide(IPresentation presentation)
{
    foreach (ISlide slide in presentation.Slides)
    {
        if (slide.LayoutSlide.LayoutType == SlideLayoutType.Title)
        {
            return slide;
        }
    }
    return null;
}
```

## **Slå ihop presentationer med en bildlayout**

Denna C#-kod visar hur du kombinerar bilder från presentationer samtidigt som du tillämpar din föredragna bildlayout för att få en enda resulterande presentation:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    foreach (ISlide slide in pres2.Slides)
    {
        pres1.Slides.AddClone(slide, pres2.LayoutSlides[0]);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

## **Slå ihop presentationer med olika bildstorlekar**

{{% alert title="Obs" color="warning" %}} 

Att slå ihop presentationer med olika bildstorlekar ger ingen felkod, men de sammanslagna bilderna antar målpresentationens bildstorlek medan deras former behåller sina ursprungliga positioner och storlekar, så innehåll kan hamna felplacerat eller utanför bildens gränser. 

{{% /alert %}}

För att slå ihop två presentationer med olika bildstorlekar och behålla deras innehåll korrekt placerat, ändra storleken på en av presentationerna så att den matchar den andras storlek. 

Denna exempelkod demonstrerar den beskrivna operationen:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres1 = new Presentation("pres1.pptx"),
   pres2 = new Presentation("pres2.pptx"))
{
   pres2.SlideSize.SetSize(pres1.SlideSize.Size.Width, pres1.SlideSize.Size.Height, SlideSizeScaleType.EnsureFit);
 
   foreach (ISlide slide in pres2.Slides)
   {
       pres1.Slides.AddClone(slide);
   }
 
   pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

## **Slå ihop bilder till ett presentationsavsnitt**

Denna C#-kod visar hur du slår ihop en specifik bild till ett avsnitt i en presentation:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    for (var index = 0; index < pres2.Slides.Count; index++)
    {
        ISlide slide = pres2.Slides[index];
        pres1.Slides.AddClone(slide, pres1.Sections[0]);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

Bilden läggs till i slutet av avsnittet. 

{{% alert title="Tips" color="info" %}}

Aspose erbjuder en [GRATIS Collage‑webapp](https://products.aspose.app/slides/sv/collage). Med den här onlinetjänsten kan du slå ihop [JPG till JPG](https://products.aspose.app/slides/sv/collage/jpg) eller PNG till PNG‑bilder, skapa [fotogrids](https://products.aspose.app/slides/sv/collage/photo-grid), och så vidare. 

{{% /alert %}}

## **Vanliga frågor**

### **Behålls talarnoter vid sammanslagning?**

**Ja.** När bilder klonas överför Aspose.Slides alla bildelement, inklusive noteringar, formatering och animationer.

### **Överförs kommentarer och deras författare?**

Kommentarer, som en del av bildens innehåll, kopieras med bilden. Kommentarförfattarnas etiketter bevaras som kommentarsobjekt i den resulterande presentationen.

### **Vad händer om källpresentationen är lösenordsskyddad?**

Den måste [öppnas med lösenord](/slides/sv/net/password-protected-presentation/) via [LoadOptions.Password](https://reference.aspose.com/slides/sv/net/aspose.slides/loadoptions/password/); efter inläsning kan dessa bilder säkert klonas till en oskyddad målfil (eller även en skyddad).

### **Hur trådsäker är sammanslagningsoperationen?**

Använd inte samma [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/)‑instans från [flera trådar](/slides/sv/net/multithreading/). Den rekommenderade regeln är "ett dokument — en tråd"; olika filer kan bearbetas parallellt i separata trådar.