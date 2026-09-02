---
title: Klona presentationsbilder i PHP
linktitle: Klona bilder
type: docs
weight: 35
url: /sv/php-java/clone-slides/
keywords:
- klona bild
- kopiera bild
- spara bild
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Snabbt duplicera PowerPoint-bilder med Aspose.Slides för PHP. Följ våra tydliga kodexempel för att automatisera PPT-skapande på några sekunder och eliminera manuellt arbete."
---
## **Introduktion**

Kloning är processen att skapa en exakt kopia eller replica av något. Aspose.Slides for PHP via Java gör det också möjligt att göra en kopia eller klon av vilken bild som helst och sedan infoga den klonade bilden i den aktuella eller någon annan öppnad presentation. Processen för bildkloning skapar en ny bild som kan modifieras av utvecklare utan att ändra den ursprungliga bilden. Det finns flera möjliga sätt att klona en bild:

- Klona i slutet inom en presentation.
- Klona på en annan position inom presentationen.
- Klona i slutet i en annan presentation.
- Klona på en annan position i en annan presentation.
- Klona på en specifik position i en annan presentation.

I Aspose.Slides for PHP via Java (en samling av [Slide](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Slide) objekt) som exponeras av [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation) objektet tillhandahåller metoderna [addClone](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SlideCollection/#addClone) och [insertClone](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SlideCollection/#insertClone) för att utföra ovanstående typer av bildkloning

## **Klona en bild i slutet av en presentation**
Om du vill klona en bild och sedan använda den i samma presentationsfil i slutet av de befintliga bilderna, använd metoden [addClone](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SlideCollection/#addClone) enligt stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation).
1. Hämta objektet [SlideCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation/#getSlides) genom att referera till bildsamlingen som exponeras av [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation) objektet.
1. Anropa metoden [addClone](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SlideCollection/#addClone) som exponeras av [SlideCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation/#getSlides) objektet och skicka med bilden som ska klonas som parameter till metoden [addClone](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SlideCollection/#addClone).
1. Skriv den ändrade presentationsfilen.

I exemplet nedan har vi klonat en bild (som ligger på den första positionen – nollindex – i presentationen) till slutet av presentationen.

```php
  # Instansiera Presentation-klassen som representerar en presentationsfil
  $pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
  try {
    # Klona den önskade bilden till slutet av samlingen av bilder i samma presentation
    $slds = $pres->getSlides();
    $slds->addClone($pres->getSlides()->get_Item(0));
    # Skriv den ändrade presentationen till disk
    $pres->save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Klona en bild till en annan position inom en presentation**
Om du vill klona en bild och sedan använda den i samma presentationsfil men på en annan position, använd metoden [insertClone](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SlideCollection/#insertClone):

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation).
1. Hämta objektet [SlideCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SlideCollection) genom att referera till [**Slides**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation/#getSlides) samlingen som exponeras av [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation) objektet.
1. Anropa metoden [insertClone](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SlideCollection/#insertClone) som exponeras av [SlideCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation/#getSlides) objektet och skicka med bilden som ska klonas tillsammans med indexet för den nya positionen som parameter till metoden [insertClone](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SlideCollection/#insertClone).
1. Skriv den modifierade presentationen som en PPTX‑fil.

I exemplet nedan har vi klonat en bild (som ligger på nollindex – position 1 – i presentationen) till index 1 – position 2 – i presentationen.

```php
  # Instansiera Presentation-klassen som representerar en presentationsfil
  $pres = new Presentation("CloneWithInSamePresentation.pptx");
  try {
    # Klona den önskade bilden till slutet av samlingen av bilder i samma presentation
    $slds = $pres->getSlides();
    # Klona den önskade bilden till det specificerade indexet i samma presentation
    $slds->insertClone(2, $pres->getSlides()->get_Item(1));
    # Skriv den ändrade presentationen till disk
    $pres->save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Klona en bild i slutet av en annan presentation**
Om du behöver klona en bild från en presentation och använda den i en annan presentationsfil, i slutet av de befintliga bilderna:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation) som innehåller presentationen bilden ska klonas från.
1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation) som innehåller mål‑presentationen som bilden ska läggas till i.
1. Hämta objektet [SlideCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SlideCollection) genom att referera till [**Slides**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation/#getSlides) samlingen som exponeras av Presentation‑objektet för mål‑presentationen.
1. Anropa metoden [addClone](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SlideCollection/#addClone) som exponeras av [SlideCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation/#getSlides) objektet och skicka med bilden från källpresentationen som parameter till metoden [addClone](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SlideCollection/#addClone).
1. Skriv den modifierade mål‑presentationsfilen.

I exemplet nedan har vi klonat en bild (från första indexet i källpresentationen) till slutet av mål‑presentationen.

```php
  # Instansiera Presentation-klassen för att läsa in källpresentationsfilen
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Instansiera Presentation-klassen för destinations-PPTX (där bilden ska klonas)
    $destPres = new Presentation();
    try {
      # Klona den önskade bilden från källpresentationen till slutet av samlingen av bilder i destinationspresentationen
      $slds = $destPres->getSlides();
      $slds->addClone($srcPres->getSlides()->get_Item(0));
      # Skriv destinationspresentationen till disk
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Klona en bild till en annan position i en annan presentation**
Om du behöver klona en bild från en presentation och använda den i en annan presentationsfil, på en specifik position:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation) som innehåller källpresentationen bilden ska klonas från.
1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation) som innehåller presentationen som bilden ska läggas till i.
1. Hämta klassen [SlideCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation/#getSlides) genom att referera till Slides‑samlingen som exponeras av Presentation‑objektet för mål‑presentationen.
1. Anropa metoden [insertClone](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SlideCollection/#insertClone) som exponeras av [SlideCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation/#getSlides) objektet och skicka med bilden från källpresentationen tillsammans med önskad position som parameter till metoden [insertClone](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SlideCollection/#insertClone).
1. Skriv den modifierade mål‑presentationsfilen.

I exemplet nedan har vi klonat en bild (från nollindex i källpresentationen) till index 1 (position 2) i mål‑presentationen.

```php
  # Instansiera Presentation-klassen för att läsa in källpresentationsfilen
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Instansiera Presentation-klassen för destinations-PPTX (där bilden ska klonas)
    $destPres = new Presentation();
    try {
      # Klona den önskade bilden från källpresentationen till slutet av samlingen av bilder i destinationspresentationen
      $slds = $destPres->getSlides();
      $slds->insertClone(2, $srcPres->getSlides()->get_Item(0));
      # Skriv destinationspresentationen till disk
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Klona en bild på en specifik position i en annan presentation**
Om du behöver klona en bild med en huvudbild (master slide) från en presentation och använda den i en annan presentation, måste du först klona den önskade huvudbilden från källpresentationen till mål‑presentationen. Därefter använder du den huvudbilden för att klona bilden med huvudbilden. Metoden [**addClone(Slide, MasterSlide, boolean)**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidecollection/addclone/) förväntar en huvudbild från mål‑presentationen snarare än från källpresentationen. För att klona bilden med en huvudbild, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation) som innehåller källpresentationen bilden ska klonas från.
1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation) som innehåller mål‑presentationen bilden ska klonas till.
1. Åtkomst till bilden som ska klonas tillsammans med huvudbilden.
1. Instansiera klassen [MasterSlideCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/MasterSlideCollection) genom att referera till Masters‑samlingen som exponeras av [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation) objektet för mål‑presentationen.
1. Anropa metoden [addClone](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SlideCollection/#addClone) som exponeras av [MasterSlideCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/MasterSlideCollection) objektet och skicka med huvudbilden från käll‑PPTX som ska klonas som parameter till metoden [addClone](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SlideCollection/#addClone).
1. Instansiera klassen [SlideCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation/#getSlides) genom att sätta referensen till Slides‑samlingen som exponeras av [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation) objektet för mål‑presentationen.
1. Anropa metoden [addClone](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SlideCollection/#addClone) som exponeras av [SlideCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation/#getSlides) objektet och skicka med bilden från källpresentationen som ska klonas samt huvudbilden som parameter till metoden [addClone](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SlideCollection/#addClone).
1. Skriv den modifierade mål‑presentationsfilen.

I exemplet nedan har vi klonat en bild med en huvudbild (liggande på nollindex i källpresentationen) till slutet av mål‑presentationen med en huvudbild från käll‑bilden.

```php
  # Instansiera Presentation-klassen för att läsa in källpresentationsfilen
  $srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
  try {
    # Instansiera Presentation-klassen för destinationspresentationen (där bilden ska klonas)
    $destPres = new Presentation();
    try {
      # Instansiera ISlide från samlingen av bilder i källpresentationen tillsammans med
      # Huvudbilden
      $SourceSlide = $srcPres->getSlides()->get_Item(0);
      $SourceMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # Klona den önskade huvudbilden från källpresentationen till samlingen av huvudbilder i den
      # Destinationspresentationen
      $masters = $destPres->getMasters();
      $DestMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # Klona den önskade huvudbilden från källpresentationen till samlingen av huvudbilder i den
      # Destinationspresentationen
      $iSlide = $masters->addClone($SourceMaster);
      # Klona den önskade bilden från källpresentationen med den önskade huvudbilden till slutet av
      # Samlingen av bilder i destinationspresentationen
      $slds = $destPres->getSlides();
      $slds->addClone($SourceSlide, $iSlide, true);
      # Spara destinationspresentationen till disk
      $destPres->save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Klona en bild i slutet av ett specificerat avsnitt**
Om du vill klona en bild och sedan använda den i samma presentationsfil men i ett annat avsnitt, använd då [addClone](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SlideCollection/#addClone)‑metoden som exponeras av klassen [SlideCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SlideCollection). Aspose.Slides for PHP via Java gör det möjligt att klona en bild från det första avsnittet och sedan infoga den klonade bilden i det andra avsnittet i samma presentation.

Följande kodsnutt visar hur du klonar en bild och infogar den klonade bilden i ett specificerat avsnitt.

```php
  $presentation = new Presentation();
  try {
    $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 50, 300, 100);
    $presentation->getSections()->addSection("Section 1", $presentation->getSlides()->get_Item(0));
    $section2 = $presentation->getSections()->appendEmptySection("Section 2");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0), $section2);
    # Spara destinationpresentationen till disk
    $presentation->save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Säkerställ att bildstorleken matchar**

När du klonar bilder till en annan presentation, se till att mål‑presentationens bildstorlek är densamma som källpresentationens. Om bildstorlekarna skiljer sig, kommer inte Aspose.Slides automatiskt att skala om de klonade formerna – deras ursprungliga koordinater och dimensioner bevaras, vilket kan leda till att innehållet blir feljusterat eller sträcker sig utanför bildens gränser.

Du kan ställa in mål‑presentationens bildstorlek så att den matchar källan innan du klonar huvudbilden och bilden:

```php
$sourceSize = $sourcePresentation->getSlideSize()->getSize();

$targetPresentation->getSlideSize()->setSize(
    $sourceSize->getWidth(), $sourceSize->getHeight(), SlideSizeScaleType::DoNotScale);
```

Gör detta innan du klonar huvudbilden och bilden.

## **FAQ**

**Klonas talarnoteringar och granskningskommentarer?**

Ja. Notessidan och granskningskommentarerna inkluderas i klonen. Om du inte vill ha dem, [ta bort dem](/slides/sv/php-java/presentation-notes/) efter insättning.

**Hur hanteras diagram och deras datakällor?**

Diagramobjektet, formatering och inbäddade data kopieras. Om diagrammet var länkat till en extern källa (t.ex. en OLE‑inbäddad arbetsbok), bevaras den länken som ett [OLE‑objekt](/slides/sv/php-java/manage-ole/). Efter att ha flyttat mellan filer, verifiera datatillgänglighet och uppdateringsbeteende.

**Kan jag styra infogningspositionen och avsnitten för klonen?**

Ja. Du kan infoga klonen på ett specifikt bildindex och placera den i ett valt [avsnitt](/slides/sv/php-java/slide-section/). Om mål‑avsnittet inte finns, skapa det först och flytta sedan bilden dit.