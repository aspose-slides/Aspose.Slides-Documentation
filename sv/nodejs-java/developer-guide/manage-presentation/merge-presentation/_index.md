---
title: Effektiv sammanslagning av presentationer i JavaScript
linktitle: Slå samman presentationer
type: docs
weight: 40
url: /sv/nodejs-java/merge-presentation/
keywords:
- slå samman PowerPoint
- slå samman presentationer
- slå samman bilder
- slå samman PPT
- slå samman PPTX
- slå samman ODP
- kombinera PowerPoint
- kombinera presentationer
- kombinera bilder
- kombinera PPT
- kombinera PPTX
- kombinera ODP
- Node.js
- JavaScript
- Aspose.Slides
description: "Slå enkelt samman PowerPoint (PPT, PPTX) och OpenDocument (ODP) presentationer i JavaScript med Aspose.Slides för Node.js, och förenkla ditt arbetsflöde."
---
## **Översikt**

Aspose.Slides låter dig slå samman presentationer genom att klona bilder från en presentation till en annan. Denna artikel förklarar hur du slår samman hela presentationer eller utvalda bilder, använder en bildmaster eller en specifik layout under sammanslagningen, hanterar presentationer med olika bildstorlekar och lägger till sammanslagna bilder i ett presentationsavsnitt. Den täcker också praktiska anteckningar relaterade till sammanslaget innehåll, inklusive talarnoter, kommentarer, lösenordsskyddade källfiler och trådanvändning.

## **Sammanslagning av presentationer**

När du slår samman en presentation med en annan kombinerar du i praktiken deras bilder i en enda presentation för att få en fil.

{{% alert title="Info" color="info" %}}

De flesta presentationsprogram (PowerPoint eller OpenOffice) saknar funktioner som låter användare kombinera presentationer på detta sätt. 

[**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/sv/nodejs-java/), tillåter dig dock att slå samman presentationer på olika sätt. Du kan slå samman presentationer med alla deras former, stilar, texter, formatering, kommentarer, animationer etc. utan att behöva oroa dig för kvalitets- eller dataförlust.

**Se även**

[Klona bilder](https://docs.aspose.com/slides/sv/nodejs-java/clone-slides/).

{{% /alert %}}

### **Vad kan slås samman**

Med Aspose.Slides kan du slå samman 

* hela presentationer. Alla bildrutor från presentationerna hamnar i en enda presentation
* specifika bilder. Utvalda bildrutor hamnar i en enda presentation
* presentationer i samma format (PPT till PPT, PPTX till PPTX, etc) och i olika format (PPT till PPTX, PPTX till ODP, etc) till varandra. 

### **Sammanslagningsalternativ**

Du kan tillämpa alternativ som bestämmer om

* varje bild i resultspresentationen behåller en unik stil
* en specifik stil används för alla bilder i resultspresentationen. 

För att slå samman presentationer tillhandahåller Aspose.Slides [addClone](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) metoder (från klassen [SlideCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SlideCollection)). Det finns flera implementationer av `addClone`‑metoderna som definierar parametrarna för presentationssammanfogningsprocessen. Varje Presentation‑objekt har en [Slides](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation#getSlides--) samling, så du kan anropa en `addClone`‑metod från den presentation du vill slå samman bilder i.

`addClone`‑metoden returnerar ett `Slide`‑objekt, som är en klon av källbilden. Bilderna i en resultspresentation är helt enkelt en kopia av bilderna från källan. Därför kan du göra ändringar i de resulterande bilderna (t.ex. applicera stilar, formateringsalternativ eller layouter) utan att oroa dig för att källpresentationerna påverkas.

## **Slå samman presentationer** 

Aspose.Slides tillhandahåller metoden [**AddClone(ISlide)**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) som låter dig kombinera bilder medan bilderna behåller sina layouter och stilar (standardparametrar).

Denna JavaScript‑kod visar hur du slår samman presentationer:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

## **Slå samman presentationer med bildmaster** 

Aspose.Slides tillhandahåller metoden [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) som låter dig kombinera bilder samtidigt som du tillämpar en bildmaster‑presentationstemplate. På så sätt kan du, om nödvändigt, ändra stilen för bilderna i resultspresentationen.

Denna kod i JavaScript demonstrerar den beskrivna operationen:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres2.getMasters().get_Item(0), true);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

{{% alert title="Note" color="warning" %}} 

Layouten för bildmastern bestäms automatiskt. När en lämplig layout inte kan bestämmas, och om den booleska parametern `allowCloneMissingLayout` för `addClone`‑metoden är satt till true, används layouten för källbilden. Annars kommer ett [PptxEditException](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/PptxEditException) att kastas.

{{% /alert %}}

Om du vill att bilderna i resultspresentationen ska ha en annan layout, använd metoden [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-) istället vid sammanslagning.

## **Slå samman specifika bilder från presentationer** 

Att slå samman specifika bilder från flera presentationer är användbart för att skapa anpassade bilddeckar. Aspose.Slides för Node.js via Java låter dig välja och importera endast de bilder du behöver. API:et bevarar formatering, layout och design på de ursprungliga bilderna.

Följande JavaScript‑kod skapar en ny presentation, lägger till titelslides från två andra presentationer och sparar resultatet till en fil:

```js
function getTitleSlide(presentation) {
  for (let i = 0; i < presentation.getSlides().size(); i++) {
    let slide = presentation.getSlides().get_Item(i);
    if (slide.getLayoutSlide().getLayoutType() == aspose.slides.SlideLayoutType.Title) {
      return slide;
    }
  }
  return null;
}
```
```js
let presentation = new aspose.slides.Presentation();
let presentation1 = new aspose.slides.Presentation("presentation1.pptx");
let presentation2 = new aspose.slides.Presentation("presentation2.pptx");
try {
    presentation.getSlides().removeAt(0);
    
    let slide1 = getTitleSlide(presentation1);

    if (slide1 != null)
        presentation.getSlides().addClone(slide1);

    let slide2 = getTitleSlide(presentation2);

    if (slide2 != null)
        presentation.getSlides().addClone(slide2);

    presentation.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
    presentation.dispose();
}
```

## **Slå samman presentationer med bildlayout** 

Denna JavaScript‑kod visar hur du kombinerar bilder från presentationer samtidigt som du tillämpar din föredragna bildlayout på dem för att få en enda resultspresentation:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres2.getLayoutSlides().get_Item(0));
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

## **Slå samman presentationer med olika bildstorlekar** 

{{% alert title="Note" color="warning" %}} 

Du kan inte slå samman presentationer med olika bildstorlekar. 

{{% /alert %}}

För att slå samman två presentationer med olika bildstorlekar måste du ändra storleken på en av presentationerna så att den matchar den andra presentationens storlek. 

Denna exempel‑kod demonstrerar den beskrivna operationen:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        pres2.getSlideSize().setSize(pres1.getSlideSize().getSize().getWidth(), pres1.getSlideSize().getSize().getHeight(), aspose.slides.SlideSizeScaleType.EnsureFit);
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

## **Slå samman bilder till presentationsavsnitt** 

Denna JavaScript‑kod visar hur du slår samman en specifik bild till ett avsnitt i en presentation:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres1.getSections().get_Item(0));
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

Bilden läggs till i slutet av avsnittet. 

## **Vanliga frågor** 

**Bevaras talarnoter vid sammanslagning?**

Ja. När bilder klonas överför Aspose.Slides alla bildelement, inklusive anteckningar, formatering och animationer.

**Överförs kommentarer och deras författare?**

Kommentarer, som en del av bildinnehållet, kopieras med bilden. Kommentarförfattar‑etiketter bevaras som kommentarsobjekt i den resulterande presentationen.

**Vad händer om källpresentationen är lösenordsskyddad?**

Den måste [öppnas med lösenordet](/slides/sv/nodejs-java/password-protected-presentation/) via [LoadOptions.setPassword](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/loadoptions/setpassword/); efter inläsning kan dessa bilder säkert klonas till en ohärdad målfil (eller även en skyddad).

**Hur trådsäker är sammanslagningsoperationen?**

Använd inte samma [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/)‑instans från [flera trådar](/slides/sv/nodejs-java/multithreading/). Den rekommenderade regeln är "ett dokument — en tråd"; olika filer kan behandlas parallellt i separata trådar.

## **Se även** 

Aspose tillhandahåller en [GRATIS online Collage‑skapare](https://products.aspose.app/slides/sv/collage). Med denna onlinetjänst kan du slå samman [JPG till JPG](https://products.aspose.app/slides/sv/collage/jpg) eller PNG till PNG‑bilder, skapa [foto‑rutnät](https://products.aspose.app/slides/sv/collage/photo-grid) och mer.

Kolla in [Aspose GRATIS online‑sammanfogare](https://products.aspose.app/slides/sv/merger). Den låter dig slå samman PowerPoint‑presentationer i samma format (t.ex. PPT till PPT, PPTX till PPTX) eller i olika format (t.ex. PPT till PPTX, PPTX till ODP).

[![Aspose FREE Online Merger](slides-merger.png)](https://products.aspose.app/slides/sv/merger)