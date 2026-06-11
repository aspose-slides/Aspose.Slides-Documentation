---
title: Effektivt slå samman presentationer i PHP
linktitle: Slå samman presentationer
type: docs
weight: 40
url: /sv/php-java/merge-presentation/
keywords:
- slå ihop PowerPoint
- slå ihop presentationer
- slå ihop bilder
- slå ihop PPT
- slå ihop PPTX
- slå ihop ODP
- kombinera PowerPoint
- kombinera presentationer
- kombinera bilder
- kombinera PPT
- kombinera PPTX
- kombinera ODP
- PHP
- Aspose.Slides
description: "Slå enkelt samman PowerPoint (PPT, PPTX) och OpenDocument (ODP) presentationer med Aspose.Slides för PHP via Java, vilket effektiviserar ditt arbetsflöde."
---
## **Översikt**

Aspose.Slides låter dig slå samman presentationer genom att klona bilder från en presentation till en annan. Denna artikel förklarar hur du slår samman hela presentationer eller utvalda bilder, använder en bildmaster eller en specifik layout under sammanslagningen, hanterar presentationer med olika bildstorlekar och lägger till sammanslagna bilder i ett presentationsavsnitt. Den täcker också praktiska anteckningar relaterade till sammanslaget innehåll, inklusive talarnoter, kommentarer, lösenordsskyddade källfiler och trådanvändning.

## **Sammanslagning av presentationer**

När du slår samman en presentation med en annan kombinerar du i praktiken deras bilder i en enda presentation för att få en fil.

{{% alert title="Info" color="info" %}}
De flesta presentationsprogram (PowerPoint eller OpenOffice) saknar funktioner som tillåter användare att kombinera presentationer på detta sätt.

[**Aspose.Slides for PHP via Java**](https://products.aspose.com/slides/sv/php-java/), tillåter dig dock att slå samman presentationer på olika sätt. Du kan slå samman presentationer med alla deras former, stilar, texter, formatering, kommentarer, animationer etc. utan att behöva oroa dig för förlust av kvalitet eller data.

**Se även**

[Klona bilder](/slides/sv/php-java/clone-slides/).

{{% /alert %}}

### **Vad som kan slås samman**

Med Aspose.Slides kan du slå samman 

* hela presentationer. Alla bilder från presentationerna blir i en enda presentation
* specifika bilder. Utvalda bilder blir i en enda presentation
* presentationer i samma format (PPT till PPT, PPTX till PPTX osv.) och i olika format (PPT till PPTX, PPTX till ODP osv.) till varandra. 

{{% alert title="Note" color="warning" %}} 

Förutom presentationer låter Aspose.Slides dig slå samman andra filer:

* [Bilder](https://products.aspose.com/slides/sv/php-java/merger/image-to-image/), såsom [JPG till JPG](https://products.aspose.com/slides/sv/php-java/merger/jpg-to-jpg/) eller [PNG till PNG](https://products.aspose.com/slides/sv/php-java/merger/png-to-png/)
* Dokument, såsom [PDF till PDF](https://products.aspose.com/slides/sv/php-java/merger/pdf-to-pdf/) eller [HTML till HTML](https://products.aspose.com/slides/sv/php-java/merger/html-to-html/)
* Och två olika filer såsom [bild till PDF](https://products.aspose.com/slides/sv/php-java/merger/image-to-pdf/) eller [JPG till PDF](https://products.aspose.com/slides/sv/php-java/merger/jpg-to-pdf/) eller [TIFF till PDF](https://products.aspose.com/slides/sv/php-java/merger/tiff-to-pdf/).

{{% /alert %}}

### **Sammanslagningsalternativ**

Du kan tillämpa alternativ som avgör om

* varje bild i den resulterande presentationen behåller en unik stil
* en specifik stil används för alla bilder i den resulterande presentationen. 

För att slå samman presentationer erbjuder Aspose.Slides [addClone](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidecollection/addclone/)-metoder (från klassen [SlideCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidecollection/)). Det finns flera implementationer av `addClone`-metoderna som definierar parametrarna för presentationssammanslagningsprocessen. Varje Presentation‑objekt har en [slide](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/getslides/)-samling, så du kan anropa en `addClone`-metod från den presentation du vill slå samman bilder till.

`addClone`‑metoden returnerar ett `Slide`‑objekt, som är en klon av källbilden. Bilderna i en resulterande presentation är helt enkelt en kopia av bilderna från källan. Därför kan du göra ändringar i de resulterande bilderna (t.ex. applicera stilar eller formateringsalternativ eller layouter) utan att oroa dig för att källpresentationerna påverkas.

## **Slå samman presentationer** 

Aspose.Slides tillhandahåller metoden [addClone(Slide)](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidecollection/addclone/) som låter dig kombinera bilder samtidigt som bilderna behåller sina layouter och stilar (standardparametrar).

Detta PHP‑kodexempel visar hur du slår samman presentationer:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **Slå samman presentationer med en bildmaster**

Aspose.Slides erbjuder metoden [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidecollection/addclone/) som låter dig kombinera bilder samtidigt som du tillämpar en bildmaster‑presentationmall. På så sätt kan du vid behov ändra stilen för bilderna i den resulterande presentationen.

Denna kod demonstrerar den beskrivna operationen:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres2->getMasters()->get_Item(0), true);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

{{% alert title="Note" color="warning" %}} 

Bildlayouten för bildmastern bestäms automatiskt. När en lämplig layout inte kan bestämmas, om den booleska parametern `allowCloneMissingLayout` för `addClone`‑metoden är satt till true, används layouten för källbilden. Annars kommer [PptxEditException](https://reference.aspose.com/slides/sv/php-java/aspose.slides/PptxEditException) att kastas.

{{% /alert %}}

Om du vill att bilderna i den resulterande presentationen ska ha en annan bildlayout, använd metoden [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidecollection/addclone/) istället vid sammanslagning.

## **Slå samman specifika bilder från presentationer**

Att slå samman specifika bilder från flera presentationer är användbart för att skapa anpassade bildpaket. Aspose.Slides for PHP via Java låter dig välja och importera bara de bilder du behöver. API:n bevarar formatering, layout och design från de ursprungliga bilderna.

Följande PHP‑kod skapar en ny presentation, lägger till titelbilder från två andra presentationer och sparar resultatet till en fil:

```php
function getTitleSlide(Presentation $presentation) {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        if (java_values($slide->getLayoutSlide()->getLayoutType()) === SlideLayoutType::Title) {
            return $slide;
        }
    }
    return null;
}
```
```php
$presentation = new Presentation();
$presentation1 = new Presentation($folderPath . "presentation1.pptx");
$presentation2 = new Presentation($folderPath . "presentation2.pptx");
try {
    $presentation->getSlides()->removeAt(0);
    
    $slide1 = getTitleSlide($presentation1);

    if ($slide1 != null)
        $presentation->getSlides()->addClone($slide1);

    $slide2 = getTitleSlide($presentation2);

    if ($slide2 != null)
        $presentation->getSlides()->addClone($slide2);

    $presentation->save($folderPath . "combined.pptx", SaveFormat::Pptx);
} finally {
    $presentation2->dispose();
    $presentation1->dispose();
    $presentation->dispose();
}
```

## **Slå samman presentationer med en bildlayout**

Detta PHP‑kodexempel visar hur du kombinerar bilder från presentationer samtidigt som du tillämpar din föredragna bildlayout för att få en enda utdata‑presentation:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres2->getLayoutSlides()->get_Item(0));
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **Slå samman presentationer med olika bildstorlekar**

{{% alert title="Note" color="warning" %}} 

Du kan inte slå samman presentationer med olika bildstorlekar. 

{{% /alert %}}

För att slå samman 2 presentationer med olika bildstorlekar måste du ändra storleken på en av presentationerna så att dess storlek matchar den andra presentationens. 

Detta kodexempel demonstrerar den beskrivna operationen:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      $pres2->getSlideSize()->setSize($pres1->getSlideSize()->getSize()->getWidth(), $pres1->getSlideSize()->getSize()->getHeight(), SlideSizeScaleType::EnsureFit);
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **Slå samman bilder till ett presentationsavsnitt**

Detta PHP‑kodexempel visar hur du slår samman en specifik bild till ett avsnitt i en presentation:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres1->getSections()->get_Item(0));
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

Bilden läggs till i slutet av avsnittet. 

## **Se även**

Aspose erbjuder en [GRATIS Online Collage Maker](https://products.aspose.app/slides/sv/collage). Med den här onlinetjänsten kan du slå samman [JPG till JPG](https://products.aspose.app/slides/sv/collage/jpg) eller PNG till PNG‑bilder, skapa [fotogallerier](https://products.aspose.app/slides/sv/collage/photo-grid), och mer.

Kolla in [Aspose GRATIS Online Merger](https://products.aspose.app/slides/sv/merger). Den låter dig slå samman PowerPoint‑presentationer i samma format (t.ex. PPT till PPT, PPTX till PPTX) eller över olika format (t.ex. PPT till PPTX, PPTX till ODP).

[![Aspose GRATIS Online Merger](slides-merger.png)](https://products.aspose.app/slides/sv/merger)

## **Vanliga frågor**

**Finns det några begränsningar för antalet bilder när man slår samman presentationer?**

Det finns inga strikta begränsningar. Aspose.Slides kan hantera stora filer, men prestandan beror på filens storlek och systemresurser. För mycket stora presentationer rekommenderas att använda en 64‑bits JVM och tilldela tillräckligt med heap‑minne.

**Kan jag slå samman presentationer med inbäddad video eller ljud?**

Ja, Aspose.Slides bevarar multimedia‑innehåll som är inbäddat i bilderna, men den slutliga presentationen kan bli avsevärt större.

**Kommer teckensnitt att bevaras när man slår samman presentationer?**

Ja. Teckensnitt som används i källpresentationerna bevaras i den resulterande filen, förutsatt att de är installerade på systemet eller [inbäddade](/slides/sv/php-java/embedded-font/).