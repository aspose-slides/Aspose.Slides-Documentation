---
title: Kloning av presentationsbilder i .NET
linktitle: Klona Slides
type: docs
weight: 40
url: /sv/net/clone-slides/
keywords:
- klona bild
- kopiera bild
- spara bild
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Duplicera snabbt PowerPoint-bilder med Aspose.Slides för .NET. Följ våra tydliga kodexempel för att automatisera skapandet av PPT på några sekunder och eliminera manuellt arbete."
---
## **Introduktion**

Kloning är processen att skapa en exakt kopia eller replik av något. Aspose.Slides gör det också möjligt att kopiera (klona) valfritt slide och sedan infoga det klonade sliden i den aktuella presentationen eller någon annan öppen presentation. Slide‑kloning skapar ett nytt slide som utvecklare kan ändra utan att påverka det ursprungliga slidet. Det finns flera sätt att klona ett slide:

- Klona i slutet av en presentation.
- Klona på en annan position i en presentation.
- Klona i slutet av en annan presentation.
- Klona på en annan position i en annan presentation.
- Klona tillsammans med dess master‑slide till en annan presentation.

I Aspose.Slides för .NET tillhandahåller slide‑samlingen (en samling av [ISlide](https://reference.aspose.com/slides/sv/net/aspose.slides/islide/)‑objekt) som exponeras av [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/)‑objektet metoderna [AddClone](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection/addclone/) och [InsertClone](https://reference.aspose.com/slides/sv/net/aspose.slides/ishapecollection/insertclone/) för att utföra de ovan beskrivna slide‑kloningsoperationerna.

## **Klona ett slide i slutet av en presentation**

Om du vill klona ett slide och sedan använda det i samma presentationsfil i slutet av de befintliga sliden, använd [AddClone](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection/methods/addclone/index)‑metoden enligt stegen nedan:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation)‑klassen.  
1. Instansiera [ISlideCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection)‑klassen genom att referera till Slides‑samlingen som exponeras av [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation)‑objektet.  
1. Anropa [AddClone](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection/methods/addclone/index)‑metoden som exponeras av [ISlideCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection)‑objektet och skicka sliden som ska klonas som parameter till [AddClone](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection/methods/addclone/index).  
1. Skriv den modifierade presentationsfilen.

I exemplet nedan har vi klonat ett slide (som ligger på första positionen – index 0 – i presentationen) till slutet av presentationen.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Skapa en Presentation-klass som representerar en presentationsfil
using (Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx"))
{

    // Klona önskat slide till slutet av samlingen av slides i samma presentation
    ISlideCollection slds = pres.Slides;

    slds.AddClone(pres.Slides[0]);

    // Spara den modifierade presentationen till disk
    pres.Save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);

}
```

## **Klona ett slide till en annan position i en presentation**
Om du vill klona ett slide och sedan använda det i samma presentationsfil men på en annan position, använd [InsertClone](https://reference.aspose.com/slides/sv/net/aspose.slides.ishapecollection/insertclone/methods/1)‑metoden:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation)‑klassen.  
1. Instansiera klassen genom att referera till **Slides**‑samlingen som exponeras av [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation)‑objektet.  
1. Anropa [InsertClone](https://reference.aspose.com/slides/sv/net/aspose.slides.ishapecollection/insertclone/methods/1)‑metoden som exponeras av [ISlideCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection)‑objektet och skicka sliden som ska klonas tillsammans med indexet för den nya positionen som parameter till [InsertClone](https://reference.aspose.com/slides/sv/net/aspose.slides.ishapecollection/insertclone/methods/1).  
1. Skriv den modifierade presentationen som en PPTX‑fil.

I exemplet nedan har vi klonat ett slide (som ligger på index 1 – position 2 – i presentationen) till index 2 – position 3 – i presentationen.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Skapa en Presentation-klass som representerar en presentationsfil
using (Presentation pres = new Presentation("CloneWithInSamePresentation.pptx"))
{

    // Klona önskat slide till slutet av samlingen av slides i samma presentation
    ISlideCollection slds = pres.Slides;

    // Klona önskat slide till det angivna indexet i samma presentation
    slds.InsertClone(2, pres.Slides[1]);

    // Spara den modifierade presentationen till disk
    pres.Save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);

}
```

## **Klona ett slide i slutet av en annan presentation**
Om du behöver klona ett slide från en presentation och använda det i en annan presentationsfil, i slutet av de befintliga sliden:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation)‑klassen som innehåller presentationen som sliden ska klonas från.  
1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation)‑klassen som innehåller målpresentationen som sliden ska läggas till i.  
1. Instansiera [ISlideCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection)‑klassen genom att referera till **Slides**‑samlingen som exponeras av Presentation‑objektet i målpresentationen.  
1. Anropa [AddClone](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection/methods/addclone/index)‑metoden som exponeras av [ISlideCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection)‑objektet och skicka sliden från källpresentationen som parameter till [AddClone](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection/methods/addclone/index).  
1. Skriv den modifierade målpresentationsfilen.

I exemplet nedan har vi klonat ett slide (från första index i källpresentationen) till slutet av målpresentationen.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instansiera Presentation-klass för att läsa in källpresentationen
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Instansiera Presentation-klass för målpresentationen PPTX (där sliden ska klonas)
    using (Presentation destPres = new Presentation())
    {
        // Klona önskat slide från källpresentationen till slutet av samlingen av slides i målpresentationen
        ISlideCollection slds = destPres.Slides;

        slds.AddClone(srcPres.Slides[0]);

        // Spara målpresentationen till disk
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **Klona ett slide till en annan position i en annan presentation**
Om du behöver klona ett slide från en presentation och använda det i en annan presentationsfil, på en specifik position:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation)‑klassen som innehåller källpresentationen som sliden ska klonas från.  
1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation)‑klassen som innehåller presentationen som sliden ska läggas till i.  
1. Instansiera [ISlideCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection)‑klassen genom att referera till Slides‑samlingen som exponeras av Presentation‑objektet i målpresentationen.  
1. Anropa [InsertClone](https://reference.aspose.com/slides/sv/net/aspose.slides.ishapecollection/insertclone/methods/1)‑metoden som exponeras av [ISlideCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection)‑objektet och skicka sliden från källpresentationen tillsammans med önskad position som parameter till [InsertClone](https://reference.aspose.com/slides/sv/net/aspose.slides.ishapecollection/insertclone/methods/1).  
1. Skriv den modifierade målpresentationsfilen.

I exemplet nedan har vi klonat ett slide (från index 0 i källpresentationen) till index 1 (position 2) i målpresentationen.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instansiera Presentation-klass för att läsa in källpresentationens fil
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Instansiera Presentation-klass för destinations-PPTX (där sliden ska klonas)
    using (Presentation destPres = new Presentation())
    {
        ISlideCollection slds = destPres.Slides;

        slds.InsertClone(2, srcPres.Slides[0]);

        // Spara destinationspresentationen till disk
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **Klona ett slide med dess master‑slide till en annan presentation**
Om du behöver klona ett slide med en master‑slide från en presentation och använda det i en annan presentation, måste du först klona den önskade master‑sliden från källpresentationen till målpresentationen. Därefter använder du den master‑sliden för att klona sliden med master‑slide. **AddClone(ISlide, IMasterSlide)** förväntar sig en master‑slide från målpresentationen snarare än från källpresentationen. Följ stegen nedan för att klona ett slide med master:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation)‑klassen som innehåller källpresentationen som sliden ska klonas från.  
1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation)‑klassen som innehåller målpresentationen som sliden ska klonas till.  
1. Åtkom sliden som ska klonas tillsammans med dess master‑slide.  
1. Instansiera [IMasterSlideCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/imasterslidecollection)‑klassen genom att referera till Masters‑samlingen som exponeras av [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation)‑objektet i målpresentationen.  
1. Anropa [AddClone](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection/methods/addclone/index)‑metoden som exponeras av [IMasterSlideCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/imasterslidecollection)‑objektet och skicka master‑sliden från käll‑PPTX som ska klonas som parameter till [AddClone](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection/methods/addclone/index).  
1. Instansiera [ISlideCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection)‑klassen genom att sätta referensen till Slides‑samlingen som exponeras av [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation)‑objektet i målpresentationen.  
1. Anropa [AddClone](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection/methods/addclone/index)‑metoden som exponeras av [ISlideCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection)‑objektet och skicka sliden från källpresentationen som ska klonas samt master‑sliden som parameter till [AddClone](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection/methods/addclone/index).  
1. Skriv den modifierade målpresentationsfilen.

I exemplet nedan har vi klonat ett slide med en master (som ligger på index 0 i källpresentationen) till slutet av målpresentationen med en master från käll‑slide.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instansiera Presentation-klass för att läsa in källpresentationens fil

using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
{
    // Instansiera Presentation-klass för destinationspresentationen (där sliden ska klonas)
    using (Presentation destPres = new Presentation())
    {

        // Instansiera ISlide från samlingen av slides i källpresentationen tillsammans med
        // Master slide
        ISlide SourceSlide = srcPres.Slides[0];
        IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Klona önskad master‑slide från källpresentationen till samlingen av masters i
        // destinationspresentationen
        IMasterSlideCollection masters = destPres.Masters;
        IMasterSlide DestMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Klona önskad master‑slide från källpresentationen till samlingen av masters i
        // destinationspresentationen
        IMasterSlide iSlide = masters.AddClone(SourceMaster);

        // Klona önskat slide från källpresentationen med den önskade master‑sliden till slutet av
        // samlingen av slides i destinationspresentationen
        ISlideCollection slds = destPres.Slides;
        slds.AddClone(SourceSlide, iSlide, true);
      
        // Klona önskad master‑slide från källpresentationen till samlingen av masters i // destinationspresentationen
        // Spara destinationspresentationen till disk
        destPres.Save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);

    }
}
```

## **Klona ett slide i slutet av ett angivet avsnitt**

Med Aspose.Slides för .NET kan du klona ett slide från ett avsnitt i en presentation och infoga det i ett annat avsnitt i samma presentation. I detta fall måste du använda [AddClone](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection/methods/addclone/index)‑metoden från [ISlideCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection)‑gränssnittet.

Denna C#‑kod visar hur du klonar ett slide och infogar det klonade sliden i ett angivet avsnitt:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 150, 100, 100); // att klona
    
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISection section = pres.Sections.AddSection("Section2", slide2);

    pres.Slides.AddClone(slide, section);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Säkerställ att slide‑storleken matchar**

När du klonar sliden till en annan presentation, se till att målpresentationen har samma slide‑storlek som källpresentationen. Om slide‑storlekarna skiljer sig, skalar inte Aspose.Slides de klonade formerna automatiskt – deras ursprungliga koordinater och dimensioner bevaras, vilket kan leda till att innehållet blir feljusterat eller sträcker sig utanför slide‑gränserna.

Du kan sätta målpresentationens slide‑storlek så att den matchar källpresentationen innan du klonar master‑sliden och sliden:

```cs
SizeF sourceSize = sourcePresentation.SlideSize.Size;

targetPresentation.SlideSize.SetSize(
    sourceSize.Width, sourceSize.Height, SlideSizeScaleType.DoNotScale);
```

Gör detta innan du klonar master‑sliden och sliden.

## **FAQ**

**Klonas talarmanus och granskningskommentarer?**

Ja. Notessidan och granskningskommentarerna inkluderas i klonen. Om du inte vill ha dem, [ta bort dem](/slides/sv/net/presentation-notes/) efter infogning.

**Hur hanteras diagram och deras datakällor?**

Diagramobjektet, formateringen och inbäddade data kopieras. Om diagrammet var länkat till en extern källa (t.ex. en OLE‑inbäddad arbetsbok), bevaras den länken som ett [OLE‑objekt](/slides/sv/net/manage-ole/). Efter flytt mellan filer, verifiera datatillgänglighet och uppdateringsbeteende.

**Kan jag styra infogningspositionen och avsnitten för klonen?**

Ja. Du kan infoga klonen på ett specifikt slide‑index och placera den i ett valt [avsnitt](/slides/sv/net/slide-section/). Om mål‑avsnittet inte finns, skapa det först och flytta sedan sliden dit.