---
title: Effektiv sammanslagning av presentationer på Android
linktitle: Sammanslå presentationer
type: docs
weight: 40
url: /sv/androidjava/merge-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Sammanfoga enkelt PowerPoint (PPT, PPTX) och OpenDocument (ODP) presentationer med Aspose.Slides för Android via Java, vilket förenklar ditt arbetsflöde."
---
## **Översikt**

Att slå samman PowerPoint- och OpenDocument-presentationer är en vanlig uppgift i många Android-applikationer, särskilt när man genererar rapporter, sammanställer bilder från olika källor eller automatiserar presentationsarbetsflöden. Aspose.Slides tillhandahåller ett kraftfullt och lättanvänt API för att kombinera flera PPT-, PPTX- eller ODP‑filer till en enda presentation utan att behöva installera Microsoft PowerPoint, LibreOffice eller OpenOffice.

I den här guiden lär du dig hur du slår samman PowerPoint- och OpenDocument-presentationer med bara några kodrader. Vi tillhandahåller färdiga exempel och visar hur du bevarar bildformatering, layouter och andra presentationselement under sammanslagningsprocessen.

Oavsett om du bygger en företagsapplikation eller ett enkelt automatiseringsverktyg gör Aspose.Slides sammanslagning av presentationer snabbt, pålitligt och skalbart. Aspose.Slides låter dig slå samman presentationer på olika sätt. Du kan kombinera presentationer med alla deras former, stilar, text, formatering, kommentarer, animationer och mer – utan att oroa dig för kvalitet- eller dataförlust.

{{% alert color="primary" %}}
Se även: [Clone Slides](https://docs.aspose.com/slides/sv/androidjava/clone-slides/)
{{% /alert %}}

### **Vad kan slås samman**

* hela presentationer. Alla bilderna från presentationerna hamnar i en enda presentation
* specifika bilder. Valda bilder hamnar i en enda presentation
* presentationer i ett format (PPT till PPT, PPTX till PPTX, osv) och i olika format (PPT till PPTX, PPTX till ODP, osv) till varandra.

### **Sammanslagningsalternativ**

Du kan tillämpa alternativ som avgör om

* varje bild i resultatpresentationen behåller en unik stil
* en specifik stil används för alla bilder i resultatpresentationen.

För att slå samman presentationer tillhandahåller Aspose.Slides [AddClone](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) metoder (från [ISlideCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISlideCollection)‑gränssnittet). Det finns flera implementationer av `AddClone`‑metoderna som definierar parametrarna för presentationssammanfogningsprocessen. Varje Presentation‑objekt har en [Slides](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation#getSlides--) samling, så du kan anropa en `AddClone`‑metod från den presentation du vill slå samman bilder i.

`AddClone`‑metoden returnerar ett `ISlide`‑objekt, som är en klon av källbilden. Bilderna i en resultatpresentation är helt enkelt en kopia av bilderna från källan. Därför kan du göra ändringar i de resulterande bilderna (till exempel tillämpa stilar, formateringsalternativ eller layouter) utan att oroa dig för att källpresentationerna påverkas.

## **Slå ihop presentationer**

Aspose.Slides tillhandahåller metoden [**AddClone(ISlide)**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) som låter dig kombinera bilder samtidigt som bilderna behåller sina layouter och stilar (standardparametrar).

Denna Java‑kod visar hur du slår samman presentationer:
```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

## **Slå ihop presentationer med en bildmaster**

Aspose.Slides tillhandahåller metoden [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) som låter dig kombinera bilder samtidigt som du tillämpar en bildmaster‑presentationsmall. På så sätt kan du, om det behövs, ändra stilen för bilderna i resultatpresentationen.

Denna kod i Java demonstrerar den beskrivna operationen:
```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres2.getMasters().get_Item(0), true);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

{{% alert title="Note" color="warning" %}}
Slide‑layouten för bildmastern bestäms automatiskt. När en lämplig layout inte kan bestämmas, om den booleska parametern `allowCloneMissingLayout` för `AddClone`‑metoden är satt till true, används layouten för källbilden. Annars kommer ett [PptxEditException](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/PptxEditException) att kastas.
{{% /alert %}}

Om du vill att bilderna i resultatpresentationen ska ha en annan bildlayout, använd metoden [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) istället när du slår ihop.

## **Slå ihop specifika bilder från presentationer**

Att slå ihop specifika bilder från flera presentationer är användbart för att skapa anpassade bildspel. Aspose.Slides för Android via Java låter dig välja och importera endast de bilder du behöver. API:et bevarar formatering, layout och design på de ursprungliga bilderna.

Följande Java‑kod skapar en ny presentation, lägger till titelbilder från två andra presentationer och sparar resultatet till en fil:
```java
Presentation presentation = new Presentation();
Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    presentation.getSlides().removeAt(0);
    
    ISlide slide1 = getTitleSlide(presentation1);

    if (slide1 != null)
        presentation.getSlides().addClone(slide1);

    ISlide slide2 = getTitleSlide(presentation2);

    if (slide2 != null)
        presentation.getSlides().addClone(slide2);

    presentation.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
    presentation.dispose();
}
```
```java
static ISlide getTitleSlide(IPresentation presentation) {
    for (ISlide slide : presentation.getSlides()) {
        if (slide.getLayoutSlide().getLayoutType() == SlideLayoutType.Title) {
            return slide;
        }
    }
    return null;
}
```

## **Slå ihop presentationer med en bildlayout**

Denna Java‑kod visar hur du kombinerar bilder från presentationer samtidigt som du tillämpar den önskade bildlayouten för att få en sammanhållen resultatpresentation:
```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres2.getLayoutSlides().get_Item(0));
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}

```

## **Slå ihop presentationer med olika bildstorlekar**

{{% alert title="Note" color="warning" %}}
Du kan inte slå ihop presentationer med olika bildstorlekar.
{{% /alert %}}

För att slå ihop två presentationer med olika bildstorlekar måste du ändra storleken på en av presentationerna så att den matchar den andra presentationens storlek.

Denna exempel­kod demonstrerar den beskrivna operationen:
```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        pres2.getSlideSize().setSize((float)pres1.getSlideSize().getSize().getWidth(), (float)pres1.getSlideSize().getSize().getHeight(), SlideSizeScaleType.EnsureFit);

        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

## **Slå ihop bilder till ett presentationsavsnitt**

Denna Java‑kod visar hur du slår ihop en specifik bild till ett avsnitt i en presentation:
```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres1.getSections().get_Item(0));
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

Bilden läggs till i slutet av avsnittet.

{{% alert title="Tip" color="primary" %}}
Aspose erbjuder en [GRATIS Collage‑webapp](https://products.aspose.app/slides/sv/collage). Med den här onlinetjänsten kan du slå ihop [JPG till JPG](https://products.aspose.app/slides/sv/collage/jpg) eller PNG till PNG‑bilder, skapa [fotogrid‑layouter](https://products.aspose.app/slides/sv/collage/photo-grid) och så vidare.
{{% /alert %}}

## **FAQ**

**Finns det några begränsningar för antalet bilder när man slår ihop presentationer?**

Inga strikta begränsningar. Aspose.Slides kan hantera stora filer, men prestandan beror på filens storlek och systemresurser. För mycket stora presentationer rekommenderas att använda en 64‑bitars JVM och allokera tillräckligt med heap‑minne.

**Kan jag slå ihop presentationer med inbäddad video eller ljud?**

Ja, Aspose.Slides bevarar multimediainnehåll som är inbäddat i bilder, men den slutliga presentationen kan bli avsevärt större.

**Kommer typsnitt att bevaras när man slår ihop presentationer?**

Ja. Typsnitt som används i källpresentationerna bevaras i resultatfilen, förutsatt att de är installerade på systemet eller [inbäddade](/slides/sv/androidjava/embedded-font/).