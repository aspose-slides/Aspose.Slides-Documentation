---
title: Hantera upphöjd och nedsänkt text i presentationer med PHP
linktitle: Upphöjd och nedsänkt text
type: docs
weight: 80
url: /sv/php-java/superscript-and-subscript/
keywords:
- upphöjd
- nedsänkt
- lägg till upphöjd
- lägg till nedsänkt
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Behärska upphöjd och nedsänkt text i Aspose.Slides för PHP via Java och höj dina presentationer med professionell textformatering för maximal effekt."
---
## **Översikt**

Aspose.Slides tillhandahåller funktioner för att integrera upphöjd och nedsänkt text i dina PowerPoint (PPT, PPTX) och OpenDocument (ODP) presentationer. Oavsett om du behöver markera kemiska formler, matematiska ekvationer eller annotera innehåll med fotnoter, hjälper dessa specialiserade formateringsalternativ till att bevara tydlighet och precision. I den här artikeln lär du dig hur du enkelt tillämpar upphöjd‑ och nedsänkt‑stilar och säkerställer professionella resultat i varje bild.

## **Hantera upphöjd och nedsänkt text**
Du kan lägga till upphöjd och nedsänkt text i någon paragrafdel. För att lägga till upphöjd eller nedsänkt text i ett Aspose.Slides‑textframe måste du använda metoden [**setEscapement**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/baseportionformat/#setEscapement) i klassen [PortionFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/PortionFormat).

Denna egenskap returnerar eller anger upphöjd eller nedsänkt text (värde från -100 % (nedsänkt) till 100 % (upphöjd)). Till exempel:

- Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation) klass.
- Hämta referensen till en bild genom att använda dess Index.
- Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/) av typen [Rectangle](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ShapeType#Rectangle) till bilden.
- Åtkomst till [TextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/) som är associerad med [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/).
- Rensa befintliga stycken
- Skapa ett nytt styckeobjekt för att hålla upphöjd text och lägg till det i [IParagraphs collection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/#getParagraphs) av [TextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/).
- Skapa ett nytt portion‑objekt
- Ange Escapement‑egenskapen för portionen till ett värde mellan 0 och 100 för att lägga till upphöjd text. (0 betyder ingen upphöjd text)
- Ange någon text för [Portion](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Portion) och lägg sedan till den i portionssamlingen för stycket.
- Skapa ett nytt styckeobjekt för att hålla nedsänkt text och lägg till det i IParagraphs‑samlingen för ITextFrame.
- Skapa ett nytt portion‑objekt
- Ange Escapement‑egenskapen för portionen till ett värde mellan 0 och -100 för att lägga till nedsänkt text. (0 betyder ingen nedsänkt text)
- Ange någon text för [Portion](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Portion) och lägg sedan till den i portionssamlingen för stycket.
- Spara presentationen som en PPTX‑fil.

Implementeringen av stegen ovan ges nedan.

```php
  # Instansiera en Presentation-klass som representerar en PPTX
  $pres = new Presentation();
  try {
    # Hämta bild
    $slide = $pres->getSlides()->get_Item(0);
    # Skapa textruta
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();
    # Skapa stycke för upphöjd text
    $superPar = new Paragraph();
    # Skapa portion med vanlig text
    $portion1 = new Portion();
    $portion1->setText("SlideTitle");
    $superPar->getPortions()->add($portion1);
    # Skapa portion med upphöjd text
    $superPortion = new Portion();
    $superPortion->getPortionFormat()->setEscapement(30);
    $superPortion->setText("TM");
    $superPar->getPortions()->add($superPortion);
    # Skapa stycke för nedsänkt text
    $paragraph2 = new Paragraph();
    # Skapa portion med vanlig text
    $portion2 = new Portion();
    $portion2->setText("a");
    $paragraph2->getPortions()->add($portion2);
    # Skapa portion med nedsänkt text
    $subPortion = new Portion();
    $subPortion->getPortionFormat()->setEscapement(-25);
    $subPortion->setText("i");
    $paragraph2->getPortions()->add($subPortion);
    # Lägg till stycken i textrutan
    $textFrame->getParagraphs()->add($superPar);
    $textFrame->getParagraphs()->add($paragraph2);
    $pres->save("formatText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Kommer upphöjd och nedsänkt text att bevaras vid export till PDF eller andra format?**

Ja, Aspose.Slides behåller korrekt upphöjd och nedsänkt formatering när presentationer exporteras till PDF, PPT/PPTX, bilder och andra stödjade format. Den specialiserade formateringen förblir intakt i alla utdatafiler.

**Kan upphöjd och nedsänkt text kombineras med andra formateringsstilar såsom fetstil eller kursiv?**

Ja, Aspose.Slides låter dig blanda olika textstilar inom en enda textportion. Du kan aktivera fetstil, kursiv, understrykning och samtidigt tillämpa upphöjd eller nedsänkt text genom att konfigurera motsvarande egenskaper i [PortionFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/portionformat/).

**Fungerar upphöjd och nedsänkt formatering för text i tabeller, diagram eller SmartArt?**

Ja, Aspose.Slides stödjer formatering i de flesta objekt, inklusive tabeller och diagramelement. När du arbetar med SmartArt måste du komma åt de lämpliga elementen (t.ex. [SmartArtNode](https://reference.aspose.com/slides/sv/php-java/aspose.slides/smartartnode/)) och deras textbehållare, och sedan konfigurera [PortionFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/portionformat/)‑egenskaperna på ett liknande sätt.