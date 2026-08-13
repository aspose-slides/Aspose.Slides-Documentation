---
title: Effektiv sammanslagning av presentationer på Android
linktitle: Slå samman presentationer
type: docs
weight: 40
url: /sv/androidjava/merge-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Sammanfoga enkelt PowerPoint‑presentationer (PPT, PPTX) och OpenDocument‑presentationer (ODP) med Aspose.Slides för Android via Java och förenkla ditt arbetsflöde."
---
## **Översikt**

Att slå samman PowerPoint- och OpenDocument-presentationer är en vanlig uppgift i många Android-applikationer, särskilt när man genererar rapporter, sammanställer bilder från olika källor eller automatiserar presentationsarbetsflöden. Aspose.Slides tillhandahåller ett kraftfullt och lättanvänt API för att kombinera flera PPT-, PPTX- eller ODP-filer till en enda presentation utan att installera Microsoft PowerPoint, LibreOffice eller OpenOffice.

I den här guiden lär du dig hur du slår samman PowerPoint- och OpenDocument-presentationer med bara några kodrader. Vi tillhandahåller färdiga exempel och visar hur du bevarar bildformatering, layouter och andra presentationselement under sammanslagningsprocessen.

Oavsett om du bygger en företagsklassad applikation eller ett enkelt automatiseringsverktyg gör Aspose.Slides sammanslagning av presentationer snabb, pålitlig och skalbar. Aspose.Slides låter dig slå samman presentationer på olika sätt. Du kan kombinera presentationer med alla deras former, stilar, text, formatering, kommentarer, animationer och mer—utan att oroa dig för kvalitets- eller datförlust.

{{% alert color="info" %}}
Se även: [Klona bilder](https://docs.aspose.com/slides/sv/androidjava/clone-slides/)
{{% /alert %}}

### **Vad kan slås samman**

Med Aspose.Slides kan du slå samman 

* hela presentationer. Alla bilder från presentationerna hamnar i en enda presentation
* specifika bilder. Utvalda bilder hamnar i en enda presentation
* presentationer i samma format (PPT till PPT, PPTX till PPTX, etc.) och i olika format (PPT till PPTX, PPTX till ODP, etc.) med varandra. 

### **Sammanslagningsalternativ**

Du kan tillämpa alternativ som avgör om

* varje bild i den resulterande presentationen behåller en unik stil
* en specifik stil används för alla bilder i den resulterande presentationen. 

För att slå samman presentationer tillhandahåller Aspose.Slides [AddClone](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) metoder (från [ISlideCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISlideCollection) -gränssnittet). Det finns flera implementationer av `AddClone`‑metoderna som definierar parametrarna för presentationssammanfogningsprocessen. Varje Presentation‑objekt har en [Slides](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation#getSlides--) samling, så du kan anropa en `AddClone`‑metod från den presentation som du vill slå samman bilder i.

`AddClone`‑metoden returnerar ett `ISlide`‑objekt, som är en klon av källbilden. Bilderna i en resultatpresentation är helt enkelt en kopia av bilderna från källan. Därför kan du göra ändringar i de resulterande bilderna (till exempel tillämpa stilar, formateringsalternativ eller layouter) utan att oroa dig för att källpresentationerna påverkas.

## **Slå samman presentationer** 

Aspose.Slides tillhandahåller [**AddClone(ISlide)**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) metoden som låter dig kombinera bilder samtidigt som bilderna behåller sina layouter och stilar (standardparametrar).

Den här Java‑koden visar hur du slår samman presentationer:

```java
import com.aspose.slides.*;

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

## **Slå samman presentationer med en bildmaster** 

Aspose.Slides tillhandahåller [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) metoden som låter dig kombinera bilder samtidigt som du tillämpar en bildmaster‑presentationstmall. På så sätt kan du, vid behov, ändra stilen för bilder i den resulterande presentationen.

Den här Java‑koden demonstrerar den beskrivna operationen:

```java
import com.aspose.slides.*;

Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres1.getMasters().get_Item(0), true);
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
Bildlayouten för bildmastern bestäms automatiskt. När en lämplig layout inte kan bestämmas, om den booleska parametern `allowCloneMissingLayout` för `AddClone`‑metoden är satt till true, används layouten för källbilden. Annars kommer ett [PptxEditException](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/PptxEditException) att kastas.
{{% /alert %}}

Om du vill att bilderna i den resulterande presentationen ska ha en annan bildlayout, använd istället [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) metoden vid sammanslagning.

## **Slå samman specifika bilder från presentationer** 

Att slå samman specifika bilder från flera presentationer är användbart för att skapa anpassade bildspel. Aspose.Slides för Android via Java låter dig välja och importera endast de bilder du behöver. API‑et bevarar formatering, layout och design på de ursprungliga bilderna.

Följande Java‑kod skapar en ny presentation, lägger till titelslides från två andra presentationer och sparar resultatet till en fil:

```java
import com.aspose.slides.*;

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
import com.aspose.slides.*;

static ISlide getTitleSlide(IPresentation presentation) {
    for (ISlide slide : presentation.getSlides()) {
        if (slide.getLayoutSlide().getLayoutType() == SlideLayoutType.Title) {
            return slide;
        }
    }
    return null;
}
```

## **Slå samman presentationer med en bildlayout** 

Denna Java‑kod visar hur du kombinerar bilder från presentationer samtidigt som du tillämpar din föredragna bildlayout på dem för att få en enda resultatpresentation:

```java
import com.aspose.slides.*;

Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres1.getLayoutSlides().get_Item(0));
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}

```

## **Slå samman presentationer med olika bildstorlekar** 

{{% alert title="Note" color="warning" %}} 
Du kan inte slå samman presentationer med olika bildstorlekar. 
{{% /alert %}}

För att slå samman 2 presentationer med olika bildstorlekar måste du ändra storleken på den ena presentationen så att den matchar den andras. 

Denna exempel­kod demonstrerar den beskrivna operationen:

```java
import com.aspose.slides.*;

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

## **Slå samman bilder till ett presentationsavsnitt** 

Denna Java‑kod visar hur du slår samman en specifik bild till ett avsnitt i en presentation:

```java
import com.aspose.slides.*;

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

{{% alert title="Tip" color="info" %}} 
Aspose tillhandahåller en [GRATIS Collage‑webbapp](https://products.aspose.app/slides/sv/collage). Med den här onlinetjänsten kan du slå samman [JPG till JPG](https://products.aspose.app/slides/sv/collage/jpg) eller PNG till PNG‑bilder, skapa [foto‑rutnät](https://products.aspose.app/slides/sv/collage/photo-grid) och så vidare. 
{{% /alert %}}

## **FAQ**

### Finns det några begränsningar för antalet bilder när man slår samman presentationer?

Inga strikta begränsningar. Aspose.Slides kan hantera stora filer, men prestandan beror på storlek och systemresurser. För mycket stora presentationer rekommenderas att använda en 64‑bit JVM och allokera tillräckligt med heap‑minne.

### Kan jag slå samman presentationer med inbäddad video eller audio?

Ja, Aspose.Slides bevarar multimediainnehåll som är inbäddat i bilder, men den slutliga presentationen kan bli avsevärt större.

### Kommer teckensnitt att bevaras när man slår samman presentationer?

Ja. Teckensnitt som används i källpresentationerna bevaras i resultatsfilen, förutsatt att de är installerade på systemet eller [inbäddade](/slides/sv/androidjava/embedded-font/).