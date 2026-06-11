---
title: Ta bort bilder från presentationer i .NET
linktitle: Ta bort bild
type: docs
weight: 30
url: /sv/net/remove-slide-from-presentation/
keywords:
- ta bort bild
- radera bild
- ta bort oanvänd bild
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Ta enkelt bort bilder från PowerPoint- och OpenDocument-presentationer med Aspose.Slides för .NET. Få tydliga C#-kodexempel och förbättra ditt arbetsflöde."
---
## **Introduktion**

Om en bild (eller dess innehåll) blir överflödig kan du ta bort den. Aspose.Slides erbjuder klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/) som kapslar in [ISlideCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection), vilket är ett arkiv för alla bilder i en presentation. Genom att använda pekare (referens eller index) för ett känt [ISlide](https://reference.aspose.com/slides/sv/net/aspose.slides/islide/)‑objekt kan du ange den bild du vill ta bort. 

## **Ta bort en bild genom referens**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation) .
1. Hämta en referens till den bild du vill ta bort via dess ID eller index.
1. Ta bort den refererade bilden från presentationen.
1. Spara den ändrade presentationen. 

Den här C#‑koden visar hur du tar bort en bild genom dess referens:

```c#
// Skapar ett Presentation-objekt som representerar en presentationsfil
using (Presentation pres = new Presentation("RemoveSlideUsingReference.pptx"))
{

    // Åtkomst till en bild via dess index i bildsamlingen
    ISlide slide = pres.Slides[0];

    // Tar bort en bild via dess referens
    pres.Slides.Remove(slide);

    // Sparar den ändrade presentationen
    pres.Save("modified_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Ta bort en bild genom index**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation) .
1. Ta bort bilden från presentationen via dess indexposition.
1. Spara den ändrade presentationen. 

Den här C#‑koden visar hur du tar bort en bild genom dess index:

```c#
// Skapar ett Presentation-objekt som representerar en presentationsfil
using (Presentation pres = new Presentation("RemoveSlideUsingIndex.pptx"))
{

    // Tar bort en bild via dess bildindex
    pres.Slides.RemoveAt(0);

    // Sparar den ändrade presentationen
    pres.Save("modified_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Ta bort oanvända layoutbilder**

Aspose.Slides tillhandahåller metoden [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) (från klassen [Compress](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/compress/) ) för att låta dig ta bort oönskade och oanvända layoutbilder. Den här C#‑koden visar hur du tar bort en layoutbild från en PowerPoint‑presentation:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **Ta bort oanvända masterbilder**

Aspose.Slides tillhandahåller metoden [RemoveUnusedMasterSlides](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) (från klassen [Compress](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/compress/) ) för att låta dig ta bort oönskade och oanvända masterbilder. Den här C#‑koden visar hur du tar bort en masterbild från en PowerPoint‑presentation:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Vad händer med bildindex efter att jag har raderat en bild?**

Efter raderingen omindexeras [collection](https://reference.aspose.com/slides/sv/net/aspose.slides/slidecollection/) : varje efterföljande bild flyttas ett steg åt vänster, så tidigare indexnummer blir föråldrade. Om du behöver en stabil referens, använd varje bilds beständiga ID snarare än dess index.

**Är en bilds ID annorlunda än dess index, och förändras det när närliggande bilder tas bort?**

Ja. Indexet är bildens position och förändras när bilder läggs till eller tas bort. Bildens ID är en beständig identifierare och förändras inte när andra bilder tas bort.

**Hur påverkar borttagning av en bild bildsektioner?**

Om bilden tillhörde en sektion kommer den sektionen bara att innehålla en bild mindre. Sektionsstrukturen förblir; om en sektion blir tom kan du [remove or reorganize sections](/slides/sv/net/slide-section/) vid behov.

**Vad händer med anteckningar och kommentarer som är kopplade till en bild när den raderas?**

[Notes](/slides/sv/net/presentation-notes/) och [comments](/slides/sv/net/presentation-comments/) är knutna till den specifika bilden och tas bort tillsammans med den. Innehållet på andra bilder påverkas inte.

**Hur skiljer sig borttagning av bilder från att rensa oanvända layouter/masterbilder?**

Att radera tar bort specifika vanliga bilder från presentationen. Att rensa oanvända layouter/masterbilder tar bort layout‑ eller masterbilder som inget refererar till, vilket minskar filstorleken utan att förändra återstående bildinnehåll. Dessa åtgärder är kompletterande: vanligtvis raderas först, sedan rensas.