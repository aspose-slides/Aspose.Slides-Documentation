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
description: "Duplicera snabbt PowerPoint-bilder med Aspose.Slides för PHP. Följ våra tydliga kodexempel för att automatisera skapandet av PPT på sekunder och eliminera manuellt arbete."
---
## **Introduktion**

Kloning är processen att göra en exakt kopia eller replik av något. Aspose.Slides för PHP via Java möjliggör också att göra en kopia eller klon av vilken bild som helst och sedan infoga den klonade bilden i den aktuella eller någon annan öppen presentation. Processen för bildkloning skapar en ny bild som kan modifieras av utvecklare utan att ändra den ursprungliga bilden. Det finns flera möjliga sätt att klona en bild:

- Klona i slutet inom en presentation.
- Klona till en annan position inom en presentation.
- Klona i slutet i en annan presentation.
- Klona till en annan position i en annan presentation.
- Klona till en specifik position i en annan presentation.

I Aspose.Slides för PHP via Java tillhandahåller (en samling av [Slide](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Slide)‑objekt) som exponeras av [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation)‑objektet metoderna [addClone](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SlideCollection/#addClone) och [insertClone](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SlideCollection/#insertClone) för att utföra ovanstående typer av bildkloning

## **Klona en bild i slutet av en presentation**
Om du vill klona en bild och sedan använda den i samma presentationsfil i slutet av de befintliga bilderna, använd metoden [addClone](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SlideCollection/#addClone) enligt stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation).
2. Hämta objektet [SlideCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation/#getSlides) genom att referera till bildsamlingen som exponeras av objektet [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation).
3. Anropa metoden [addClone](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SlideCollection/#addClone) som exponeras av objektet [SlideCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation/#getSlides) och skicka den bild som ska klonas som en parameter till metoden [addClone](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SlideCollection/#addClone).
4. Skriv den modifierade presentationsfilen.

I exemplet nedan har vi klonat en bild (som ligger på den första positionen – index 0 – i presentationen) till slutet av presentationen.

```php
  # Instansiera Presentation-klassen som representerar en presentationsfil
  $pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
  try {
    # Klona den önskade bilden till slutet av samlingen av bilder i samma presentation
    $slds = $pres->getSlides();
    $slds->addClone($pres->getSlides()->get_Item(0));
    # Skriv den modifierade presentationen till disk
    $pres->save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Klona en bild till en annan position inom en presentation**
Om du vill klona en bild och sedan använda den i samma presentationsfil men på en annan position, använd metoden [insertClone](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SlideCollection/#insertClone):

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation).
2. Hämta objektet [SlideCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SlideCollection) genom att referera till samlingen [**Slides**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation/#getSlides) som exponeras av objektet [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation).
3. Anropa metoden [insertClone](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SlideCollection/#insertClone) som exponeras av objektet [SlideCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation/#getSlides) och skicka den bild som ska klonas tillsammans med indexet för den nya positionen som en parameter till metoden [insertClone](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SlideCollection/#insertClone).
4. Skriv den modifierade presentationen som en PPTX‑fil.

I exemplet nedan har vi klonat en bild (som ligger på index 0 – position 1 – i presentationen) till index 1 – position 2 – i presentationen.

```php
  # Instansiera Presentation-klass som representerar en presentationsfil
  $pres = new Presentation("CloneWithInSamePresentation.pptx");
  try {
    # Klona den önskade bilden till slutet av samlingen av bilder i samma presentation
    $slds = $pres->getSlides();
    # Klona den önskade bilden till det angivna indexet i samma presentation
    $slds->insertClone(2, $pres->getSlides()->get_Item(1));
    # Skriv den modifierade presentationen till disk
    $pres->save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Klona en bild i slutet av en annan presentation**
Om du behöver klona en bild från en presentation och använda den i en annan presentationsfil, i slutet av de befintliga bilderna:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation) som innehåller den presentation som bilden ska klonas från.
2. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation) som innehåller destinationspresentationen som bilden ska läggas till i.
3. Hämta objektet [SlideCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SlideCollection) genom att referera till samlingen [**Slides**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation/#getSlides) som exponeras av Presentation‑objektet för destinationspresentationen.
4. Anropa metoden [addClone](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SlideCollection/#addClone) som exponeras av objektet [SlideCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation/#getSlides) och skicka bilden från källpresentationen som en parameter till metoden [addClone](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SlideCollection/#addClone).
5. Skriv den modifierade destinationspresentationsfilen.

I exemplet nedan har vi klonat en bild (från första indexet i källpresentationen) till slutet av destinationspresentationen.

```php
  # Instansiera Presentation-klass för att läsa in källpresentationsfilen
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Instansiera Presentation-klass för destinations-PPTX (där bilden ska klonas)
    $destPres = new Presentation();
    try {
      # Klona den önskade bilden från källpresentationen till slutet av bildsamlingen i destinationspresentationen
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

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation) som innehåller källpresentationen som bilden ska klonas från.
2. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation) som innehåller presentationen som bilden ska läggas till i.
3. Hämta klassen [SlideCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation/#getSlides) genom att referera till Slides‑samlingen som exponeras av Presentation‑objektet för destinationspresentationen.
4. Anropa metoden [insertClone](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SlideCollection/#insertClone) som exponeras av objektet [SlideCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation/#getSlides) och skicka bilden från källpresentationen tillsammans med önskad position som en parameter till metoden [insertClone](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SlideCollection/#insertClone).
5. Skriv den modifierade destinationspresentationsfilen.

I exemplet nedan har vi klonat en bild (från index 0 i källpresentationen) till index 1 (position 2) i destinationspresentationen.

```php
  # Instansiera Presentation-klass för att läsa in källpresentationsfilen
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Instansiera Presentation-klass för destinations-PPTX (där bilden ska klonas)
    $destPres = new Presentation();
    try {
      # Klona den önskade bilden från källpresentationen till slutet av bildsamlingen i destinationspresentationen
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
Om du behöver klona en bild med en huvudinbild (master slide) från en presentation och använda den i en annan presentation, måste du först klona den önskade huvudinbilden från källpresentationen till destinationspresentationen. Därefter måste du använda den huvudinbilden för att klona bilden med huvudinbild. Metoden [**addClone(Slide, MasterSlide, boolean)**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidecollection/addclone/) förväntar sig en huvudinbild från destinationspresentationen snarare än från källpresentationen. För att klona bilden med en huvudinbild, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation) som innehåller källpresentationen som bilden ska klonas från.
2. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation) som innehåller destinationspresentationen som bilden ska klonas till.
3. Åtkomst till bilden som ska klonas tillsammans med huvudinbilden.
4. Instansiera klassen [MasterSlideCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/MasterSlideCollection) genom att referera till Masters‑samlingen som exponeras av [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation)‑objektet för destinationspresentationen.
5. Anropa metoden [addClone](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SlideCollection/#addClone) som exponeras av objektet [MasterSlideCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/MasterSlideCollection) och skicka huvudinbilden från käll‑PPTX som ska klonas som parameter till metoden [addClone](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SlideCollection/#addClone).
6. Instansiera klassen [SlideCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation/#getSlides) genom att ställa in referensen till Slides‑samlingen som exponeras av [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation)‑objektet för destinationspresentationen.
7. Anropa metoden [addClone](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SlideCollection/#addClone) som exponeras av objektet [SlideCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation/#getSlides) och skicka bilden från källpresentationen som ska klonas samt huvudinbilden som parametrar till metoden [addClone](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SlideCollection/#addClone).
8. Skriv den modifierade destinationspresentationsfilen.

I exemplet nedan har vi klonat en bild med en huvudinbild (som ligger på index 0 i källpresentationen) till slutet av destinationspresentationen med en huvudinbild från källbilden.

```php
  # Instansiera Presentation-klass för att läsa in källpresentationsfilen
  $srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
  try {
    # Instansiera Presentation-klass för destinationspresentationen (där bilden ska klonas)
    $destPres = new Presentation();
    try {
      # Instansiera ISlide från samlingen av bilder i källpresentationen tillsammans med
      # Huvudinbilden
      $SourceSlide = $srcPres->getSlides()->get_Item(0);
      $SourceMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # Klona den önskade huvudinbilden från källpresentationen till samlingen av huvudinbilder i
      # Destinationspresentationen
      $masters = $destPres->getMasters();
      $DestMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # Klona den önskade huvudinbilden från källpresentationen till samlingen av huvudinbilder i
      # Destinationspresentationen
      $iSlide = $masters->addClone($SourceMaster);
      # Klona den önskade bilden från källpresentationen med den önskade huvudinbilden till slutet av
      # samlingen av bilder i destinationspresentationen
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

## **Klona en bild i slutet av en specificerad sektion**
Om du vill klona en bild och sedan använda den i samma presentationsfil men i en annan sektion, använd då metoden [addClone](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SlideCollection/#addClone) som exponeras av klassen [SlideCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SlideCollection). Aspose.Slides för PHP via Java möjliggör att klona en bild från den första sektionen och sedan infoga den klonade bilden i den andra sektionen i samma presentation.

Följande kodsnutt visar hur du klonar en bild och infogar den klonade bilden i en specificerad sektion.

```php
  $presentation = new Presentation();
  try {
    $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 50, 300, 100);
    $presentation->getSections()->addSection("Section 1", $presentation->getSlides()->get_Item(0));
    $section2 = $presentation->getSections()->appendEmptySection("Section 2");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0), $section2);
    # Spara destinationspresentationen till disk
    $presentation->save($dataDir . "CloneSlideIntoSpecifiedSection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **FAQ**

**Klonas talarnoteringar och granskarkommentarer?**

Ja. Noteringssidan och granskningskommentarerna inkluderas i klonen. Om du inte vill ha dem, [ta bort dem](/slides/sv/php-java/presentation-notes/) efter infogning.

**Hur hanteras diagram och deras datakällor?**

Diagramobjektet, formateringen och inbäddade data kopieras. Om diagrammet var länkat till en extern källa (t.ex. en OLE‑inbäddad arbetsbok) behålls den länken som ett [OLE‑objekt](/slides/sv/php-java/manage-ole/). Efter flytt mellan filer, kontrollera datatillgänglighet och uppdateringsbeteende.

**Kan jag styra infogningsposition och sektioner för klonen?**

Ja. Du kan infoga klonen på ett specifikt bildindex och placera den i en vald [sektion](/slides/sv/php-java/slide-section/). Om målsektionen inte finns, skapa den först och flytta sedan bilden dit.