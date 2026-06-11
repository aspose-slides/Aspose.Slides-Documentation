---
title: Hantera bildsektioner i presentationer med PHP
linktitle: Bildsektion
type: docs
weight: 90
url: /sv/php-java/slide-section/
keywords:
- skapa sektion
- lägga till sektion
- redigera sektion
- ändra sektion
- sektionens namn
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Effektivisera bildsektioner i PowerPoint och OpenDocument med Aspose.Slides för PHP via Java — dela, byta namn och omordna för att optimera PPTX- och ODP-arbetsflöden."
---
## **Introduktion**

Med Aspose.Slides för PHP via Java kan du organisera en PowerPoint‑presentation i sektioner. Du kan skapa sektioner som innehåller specifika bilder.

Du kan vilja skapa sektioner och använda dem för att organisera eller dela upp bilder i en presentation i logiska delar i följande situationer:

- När du arbetar med en stor presentation tillsammans med andra personer eller ett team – och du behöver tilldela vissa bilder till en kollega eller några teammedlemmar. 
- När du arbetar med en presentation som innehåller många bilder – och du har svårt att hantera eller redigera dess innehåll på en gång.

Idealt bör du skapa en sektion som innehåller liknande bilder – bilderna har något gemensamt eller kan grupperas baserat på en regel – och ge sektionen ett namn som beskriver bilderna i den. 

## **Skapa sektioner i presentationer**

För att lägga till en sektion som kommer att innehålla bilder i en presentation tillhandahåller Aspose.Slides för PHP via Java metoden [addSection()](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sectioncollection/#addSection) som låter dig ange namnet på sektionen du vill skapa och bilden där sektionen börjar.

Den här exempelkoden visar hur du skapar en sektion i en presentation :

```php
  $pres = new Presentation();
  try {
    $defaultSlide = $pres->getSlides()->get_Item(0);
    $newSlide1 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide2 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide3 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide4 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $section1 = $pres->getSections()->addSection("Section 1", $newSlide1);
    $section2 = $pres->getSections()->addSection("Section 2", $newSlide3);// section1 kommer att avslutas vid newSlide2 och därefter startar section2

    $pres->save("pres-sections.pptx", SaveFormat::Pptx);
    $pres->getSections()->reorderSectionWithSlides($section2, 0);
    $pres->save("pres-sections-moved.pptx", SaveFormat::Pptx);
    $pres->getSections()->removeSectionWithSlides($section2);
    $pres->getSections()->appendEmptySection("Last empty section");
    $pres->save("pres-section-with-empty.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ändra namn på sektioner**

Efter att du har skapat en sektion i en PowerPoint‑presentation kan du bestämma dig för att ändra dess namn. 

Den här exempelkoden visar hur du ändrar namnet på en sektion i en presentation med hjälp av Aspose.Slides:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $section = $pres->getSections()->get_Item(0);
    $section->setName("My section");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Behålls sektioner när du sparar till PPT (PowerPoint 97–2003) formatet?**

Nej. PPT‑formatet stöder inte sektionmetadata, så sektionerna förloras när du sparar till .ppt.

**Kan en hel sektion "gömmas"?**

Nej. Endast individuella bilder kan döljas. En sektion som enhet har inget "gömt" tillstånd.

**Kan jag snabbt hitta en sektion via en bild och, omvänt, den första bilden i en sektion?**

Ja. En sektion definieras unikt av sin startbild; med en given bild kan du avgöra vilken sektion den tillhör, och för en sektion kan du komma åt dess första bild.