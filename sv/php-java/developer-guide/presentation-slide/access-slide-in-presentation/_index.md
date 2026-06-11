---
title: Åtkomst till presentationsbildrutor i PHP
linktitle: Åtkomst till bildruta
type: docs
weight: 20
url: /sv/php-java/access-slide-in-presentation/
keywords:
- åtkomst bildruta
- bildruta index
- bildruta id
- bildruta position
- ändra position
- bildruta egenskaper
- bildruta nummer
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Lär dig hur du får åtkomst till och hanterar bildrutor i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för PHP via Java. Öka produktiviteten med kodexempel."
---
## **Översikt**

Denna artikel förklarar hur du får åtkomst till och hanterar bildrutor i en presentation med Aspose.Slides. Den visar hur du hämtar bildrutor via deras nollbaserade index från bildrutsamlingen och hur du får åtkomst till en bildruta via dess unika ID med metoden `getSlideById`.

Du kommer också att lära dig hur du ändrar en bildruts position med metoden `setSlideNumber` och hur du definierar startnumret för bildrutor i en presentation med metoden `setFirstSlideNumber`. Exemplen demonstrerar hur du laddar en presentation, får bildrutsreferenser, uppdaterar bildrutsordning eller numrering, och sparar den ändrade presentationen.

## **Åtkomst till en bildruta via index**

Alla bildrutor i en presentation är ordnade numeriskt baserat på bildrutans position med början från 0. Den första bildrutan är tillgänglig via index 0; den andra bildrutan via index 1; osv.

Presentation‑klassen, som representerar en presentationsfil, exponerar alla bildrutor som en [SlideCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidecollection/)‑samling (samling av [Slide](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slide/)‑objekt). Denna PHP‑kod visar hur du får åtkomst till en bildruta via dess index:

```php
  # Skapar ett Presentation-objekt som representerar en presentationsfil
  $pres = new Presentation("demo.pptx");
  try {
    # Hämtar en bildruta med dess bildrutinindex
    $slide = $pres->getSlides()->get_Item(0);
  } finally {
    $pres->dispose();
  }
```

## **Åtkomst till en bildruta via ID**

Varje bildruta i en presentation har ett unikt ID associerat med sig. Du kan använda [getSlideById](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#getSlideById-long-)‑metoden (exponerad av [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/)‑klassen) för att rikta in dig på det ID‑t. Denna PHP‑kod visar hur du anger ett giltigt bildruts‑ID och får åtkomst till den bildrutan via [getSlideById](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#getSlideById-long-)‑metoden:

```php
  # Skapar ett Presentation-objekt som representerar en presentationsfil
  $pres = new Presentation("demo.pptx");
  try {
    # Hämtar en bildrutans ID
    $id = $pres->getSlides()->get_Item(0)->getSlideId();
    # Åtkomst till bildrutan via dess ID
    $slide = $pres->getSlideById($id);
  } finally {
    $pres->dispose();
  }
```

## **Ändra bildrutans position**

Aspose.Slides låter dig ändra en bildruts position. Till exempel kan du ange att den första bildrutan ska bli den andra bildrutan.

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/)‑klassen.
1. Hämta bildrutans referens (den vars position du vill ändra) via dess index
1. Ställ in en ny position för bildrutan via [setSlideNumber](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slide/#setSlideNumber)‑metoden.
1. Spara den modifierade presentationen.

Denna PHP‑kod demonstrerar en operation där bildrutan på position 1 flyttas till position 2:

```php
  # Skapar ett Presentation-objekt som representerar en presentationsfil
  $pres = new Presentation("Presentation.pptx");
  try {
    # Hämtar bildrutan vars position kommer att ändras
    $sld = $pres->getSlides()->get_Item(0);
    # Ställer in den nya positionen för bildrutan
    $sld->setSlideNumber(2);
    # Sparar den modifierade presentationen
    $pres->save("helloworld_Pos.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

Den första bildrutan blev den andra; den andra bildrutan blev den första. När du ändrar en bildruts position justeras övriga bildrutor automatiskt.

## **Ställ in bildrutans nummer**

Genom att använda [setFirstSlideNumber](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#setFirstSlideNumber-int-)‑metoden (exponerad av [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/)‑klassen) kan du ange ett nytt nummer för den första bildrutan i en presentation. Denna operation får andra bildrutsnummer att beräknas om.

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/)‑klassen.
1. Hämta bildrutans nummer.
1. Ställ in bildrutans nummer.
1. Spara den modifierade presentationen.

Denna PHP‑kod demonstrerar en operation där den första bildrutans nummer sätts till 10:

```php
  # Skapar ett Presentation-objekt som representerar en presentationsfil
  $pres = new Presentation("HelloWorld.pptx");
  try {
    # Hämtar bildrutans nummer
    $firstSlideNumber = $pres->getFirstSlideNumber();
    # Ställer in bildrutans nummer
    $pres->setFirstSlideNumber(10);
    # Sparar den modifierade presentationen
    $pres->save("Set_Slide_Number_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

Om du föredrar att hoppa över den första bildrutan kan du börja numreringen från den andra bildrutan (och dölja numreringen för den första bildrutan) på följande sätt:

```php
  $presentation = new Presentation();
  try {
    $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    # Ställer in numret för den första presentationsbildrutan
    $presentation->setFirstSlideNumber(0);
    # Visar bildrutsnummer för alla bildrutor
    $presentation->getHeaderFooterManager()->setAllSlideNumbersVisibility(true);
    # Döljer bildrutsnumret för den första bildrutan
    $presentation->getSlides()->get_Item(0)->getHeaderFooterManager()->setSlideNumberVisibility(false);
    # Sparar den modifierade presentationen
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **FAQ**

**Matchar bildrutans nummer som en användare ser samlingens nollbaserade index?**

Numret som visas på en bildruta kan starta från ett godtyckligt värde (t.ex. 10) och behöver inte matcha indexet; förhållandet styrs av presentationens [first slide number](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/setfirstslidenumber/)‑inställning.

**Påverkar dolda bildrutor indexeringen?**

Ja. En dold bildruta finns kvar i samlingen och räknas med i indexeringen; "dold" avser visning, inte dess position i samlingen.

**Ändras en bildruts index när andra bildrutor läggs till eller tas bort?**

Ja. Indexen återspeglar alltid den aktuella ordningen i bildrutorna och beräknas om vid insättning, borttagning och flyttning.