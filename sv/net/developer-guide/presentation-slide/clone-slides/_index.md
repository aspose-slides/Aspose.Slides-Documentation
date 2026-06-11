---
title: Klona presentationsbilder i .NET
linktitle: Klona bilder
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

Kloning är processen att göra en exakt kopia eller replika av något. Aspose.Slides låter dig också kopiera (klona) vilken bild som helst och sedan infoga den klonade bilden i den aktuella presentationen eller någon annan öppen presentation. Bildkloning skapar en ny bild som utvecklare kan ändra utan att påverka den ursprungliga bilden. Det finns flera sätt att klona en bild:

- Klona i slutet av en presentation.
- Klona på en annan position inom en presentation.
- Klona i slutet av en annan presentation.
- Klona på en annan position i en annan presentation.
- Klona på en specifik position i en annan presentation.

I Aspose.Slides för .NET tillhandahåller bildsamlingen (en samling av [ISlide](https://reference.aspose.com/slides/sv/net/aspose.slides/islide/) objekt) som exponeras av [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/) objektet metoderna [AddClone](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection/addclone/) och [InsertClone](https://reference.aspose.com/slides/sv/net/aspose.slides/ishapecollection/insertclone/) för att utföra de bildkloningsoperationer som beskrivits ovan.

## **Klona en bild i slutet av en presentation**

Om du vill klona en bild och sedan använda den i samma presentationsfil i slutet av de befintliga bilderna, använd [AddClone](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection/methods/addclone/index) metoden enligt stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
1. Instansiera klassen [ISlideCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection) genom att referera till Slides‑samlingen som exponeras av [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation) objektet.
1. Anropa [AddClone](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection/methods/addclone/index) metoden som exponeras av [ISlideCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection) objektet och skicka bilden som ska klonas som parameter till [AddClone](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection/methods/addclone/index) metoden.
1. Skriv den modifierade presentationsfilen.

I exempel nedan har vi klonat en bild (som ligger på den första positionen – nollindex – i presentationen) till slutet av presentationen.

```c#
 // Instansiera Presentation-klassen som representerar en presentationsfil
 using (Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx"))
 {
 
     // Klona den önskade bilden till slutet av samlingen av bilder i samma presentation
     ISlideCollection slds = pres.Slides;
 
     slds.AddClone(pres.Slides[0]);
 
     // Skriv den modifierade presentationen till disken
     pres.Save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
 
 }
```


## **Klona en bild till en annan position inom en presentation**

Om du vill klona en bild och sedan använda den i samma presentationsfil men på en annan position, använd [InsertClone](https://reference.aspose.com/slides/sv/net/aspose.slides.ishapecollection/insertclone/methods/1) metoden:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation) klassen.
1. Instansiera klassen genom att referera till **Slides**‑samlingen som exponeras av [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation) objektet.
1. Anropa [InsertClone](https://reference.aspose.com/slides/sv/net/aspose.slides.ishapecollection/insertclone/methods/1) metoden som exponeras av [ISlideCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection) objektet och skicka bilden som ska klonas tillsammans med indexet för den nya positionen som parameter till [InsertClone](https://reference.aspose.com/slides/sv/net/aspose.slides.ishapecollection/insertclone/methods/1) metoden.
1. Skriv den modifierade presentationen som en PPTX‑fil.

I exempel nedan har vi klonat en bild (som ligger på nollindex – position 1 – i presentationen) till index 1 – Position 2 – i presentationen.

```c#
 // Instansiera Presentation-klassen som representerar en presentationsfil
 using (Presentation pres = new Presentation("CloneWithInSamePresentation.pptx"))
 {
 
     // Klona den önskade bilden till slutet av samlingen av bilder i samma presentation
     ISlideCollection slds = pres.Slides;
 
     // Klona den önskade bilden till det angivna indexet i samma presentation
     slds.InsertClone(2, pres.Slides[1]);
 
     // Skriv den modifierade presentationen till disken
     pres.Save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
 
 }
```


## **Klona en bild i slutet av en annan presentation**

Om du behöver klona en bild från en presentation och använda den i en annan presentationsfil, i slutet av de befintliga bilderna:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation) klassen som innehåller presentationen som bilden ska klonas från.
1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation) klassen som innehåller destinationspresentationen som bilden ska läggas till i.
1. Instansiera [ISlideCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection) klassen genom att referera till **Slides**‑samlingen som exponeras av Presentation‑objektet för destinationspresentationen.
1. Anropa [AddClone](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection/methods/addclone/index) metoden som exponeras av [ISlideCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection) objektet och skicka bilden från källpresentationen som parameter till [AddClone](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection/methods/addclone/index) metoden.
1. Skriv den modifierade destinationspresentationsfilen.

I exempel nedan har vi klonat en bild (från det första indexet i källpresentationen) till slutet av destinationspresentationen.

```c#
 // Instansiera Presentation-klassen för att läsa in källpresentationsfilen
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Instansiera Presentation-klassen för destinations-PPTX (där bilden ska klonas)
    using (Presentation destPres = new Presentation())
    {
        // Klona den önskade bilden från källpresentationen till slutet av samlingen av bilder i destinationspresentationen
        ISlideCollection slds = destPres.Slides;

        slds.AddClone(srcPres.Slides[0]);

        // Skriv destinationspresentationen till disken
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```


## **Klona en bild till en annan position i en annan presentation**

Om du behöver klona en bild från en presentation och använda den i en annan presentationsfil, på en specifik position:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation) klassen som innehåller källpresentationen som bilden ska klonas från.
1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation) klassen som innehåller presentationen som bilden ska läggas till i.
1. Instansiera [ISlideCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection) klassen genom att referera till Slides‑samlingen som exponeras av Presentation‑objektet för destinationspresentationen.
1. Anropa [InsertClone](https://reference.aspose.com/slides/sv/net/aspose.slides.ishapecollection/insertclone/methods/1) metoden som exponeras av [ISlideCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection) objektet och skicka bilden från källpresentationen tillsammans med önskad position som parameter till [InsertClone](https://reference.aspose.com/slides/sv/net/aspose.slides.ishapecollection/insertclone/methods/1) metoden.
1. Skriv den modifierade destinationspresentationsfilen.

I exempel nedan har vi klonat en bild (från nollindex i källpresentationen) till index 1 (position 2) i destinationspresentationen.

```c#
 // Instansiera Presentation-klassen för att läsa in källpresentationsfilen
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Instansiera Presentation-klassen för destinations-PPTX (där bilden ska klonas)
    using (Presentation destPres = new Presentation())
    {
        ISlideCollection slds = destPres.Slides;

        slds.InsertClone(2, srcPres.Slides[0]);

        // Skriv destinationspresentationen till disken
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```


## **Klona en bild på en specifik position i en annan presentation**

Om du behöver klona en bild med en masterbild från en presentation och använda den i en annan presentation, måste du först klona den önskade masterbilden från källpresentationen till destinationspresentationen. Därefter måste du använda den masterbilden för att klona bilden med masterbild. Metoden **AddClone(ISlide, IMasterSlide)** förväntar en masterbild från destinationspresentationen snarare än från källpresentationen. För att klona bilden med en master, följ stegen nedan:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation) klassen som innehåller källpresentationen som bilden ska klonas från.
2. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation) klassen som innehåller destinationspresentationen som bilden ska klonas till.
3. Kom åt bilden som ska klonas tillsammans med masterbilden.
4. Instansiera [IMasterSlideCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/imasterslidecollection) klassen genom att referera till Masters‑samlingen som exponeras av [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation) objektet för destinationspresentationen.
5. Anropa [AddClone](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection/methods/addclone/index) metoden som exponeras av [IMasterSlideCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/imasterslidecollection) objektet och skicka masterbilden från käll‑PPTX som ska klonas som parameter till [AddClone](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection/methods/addclone/index) metoden.
6. Instansiera [ISlideCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection) klassen genom att sätta referensen till Slides‑samlingen som exponeras av [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation) objektet för destinationspresentationen.
7. Anropa [AddClone](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection/methods/addclone/index) metoden som exponeras av [ISlideCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection) objektet och skicka bilden från källpresentationen som ska klonas samt masterbilden som parameter till [AddClone](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection/methods/addclone/index) metoden.
8. Skriv den modifierade destinationspresentationsfilen.

I exempel nedan har vi klonat en bild med en master (som ligger på nollindex i källpresentationen) till slutet av destinationspresentationen med en master från källbilden.

```c#
 // Instansiera Presentation-klass för att läsa in källpresentationsfilen

using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
{
    // Instansiera Presentation-klass för destinationspresentationen (där bilden ska klonas)
    using (Presentation destPres = new Presentation())
    {

        // Instansiera ISlide från samlingen av bilder i källpresentationen tillsammans med
        // Master-bild
        ISlide SourceSlide = srcPres.Slides[0];
        IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Klona den önskade master-bilden från källpresentationen till samlingen av masters i
        // destinationspresentationen
        IMasterSlideCollection masters = destPres.Masters;
        IMasterSlide DestMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Klona den önskade master-bilden från källpresentationen till samlingen av masters i
        // destinationspresentationen
        IMasterSlide iSlide = masters.AddClone(SourceMaster);

        // Klona den önskade bilden från källpresentationen med den önskade master-bilden till slutet av
        // samlingen av bilder i destinationspresentationen
        ISlideCollection slds = destPres.Slides;
        slds.AddClone(SourceSlide, iSlide, true);
      
        // Klona den önskade master-bilden från källpresentationen till samlingen av masters i // destinationspresentationen
        // Spara destinationspresentationen till disken
        destPres.Save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);

    }
}
```


## **Klona en bild i slutet av ett specificerat avsnitt**

Med Aspose.Slides för .NET kan du klona en bild från ett avsnitt i en presentation och infoga den bilden i ett annat avsnitt i samma presentation. I detta fall måste du använda [AddClone](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection/methods/addclone/index) metoden från [ISlideCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection)‑gränssnittet.

Denna C#‑kod visar hur du klonar en bild och infogar den klonade bilden i ett specificerat avsnitt:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 150, 100, 100); // för att klona
    
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISection section = pres.Sections.AddSection("Section2", slide2);

    pres.Slides.AddClone(slide, section);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Vanliga frågor**

**Klonas talarnoter och granskningskommentarer?**

Ja. Notessidan och granskningskommentarerna inkluderas i klonen. Om du inte vill ha dem, [ta bort dem](/slides/sv/net/presentation-notes/) efter infogning.

**Hur hanteras diagram och deras datakällor?**

Diagramobjektet, formateringen och inbäddade data kopieras. Om diagrammet var länkat till en extern källa (t.ex. en OLE‑inbäddad arbetsbok) bevaras den länken som ett [OLE‑objekt](/slides/sv/net/manage-ole/). Efter flytt mellan filer, verifiera datatillgänglighet och uppdateringsbeteende.

**Kan jag kontrollera infogningspositionen och avsnitten för klonen?**

Ja. Du kan infoga klonen på ett specifikt bildindex och placera den i en vald [sektion](/slides/sv/net/slide-section/). Om målsektionen inte finns, skapa den först och flytta sedan bilden dit.