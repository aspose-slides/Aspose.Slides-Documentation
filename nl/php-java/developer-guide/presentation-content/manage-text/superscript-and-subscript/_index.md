---
title: Superscript en subscript beheren in presentaties met PHP
linktitle: Superscript en subscript
type: docs
weight: 80
url: /nl/php-java/superscript-and-subscript/
keywords:
- superscript
- subscript
- superscript toevoegen
- subscript toevoegen
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Beheers superscript en subscript in Aspose.Slides voor PHP via Java en til uw presentaties naar een hoger niveau met professionele tekstopmaak voor maximale impact."
---
## **Overzicht**

Aspose.Slides biedt mogelijkheden om superscript‑ en subscripttekst in uw PowerPoint‑ (PPT, PPTX) en OpenDocument‑ (ODP) presentaties te integreren. Of u nu chemische formules, wiskundige vergelijkingen wilt benadrukken of inhoud wilt voorzien van voetnoten, deze gespecialiseerde opmaakopties helpen de helderheid en precisie te behouden. In dit artikel leert u hoe u superscript‑ en subscriptstijlen naadloos kunt toepassen en professionele resultaten in elke dia kunt garanderen.

## **Superscript‑ en Subscripttekst beheren**
U kunt superscript‑ en subscripttekst toevoegen binnen elk alinea‑gedeelte. Om superscript‑ of subscripttekst toe te voegen in een Aspose.Slides‑tekstvak, moet u de [**setEscapement**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseportionformat/#setEscapement)‑methode van de [PortionFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/PortionFormat)‑klasse gebruiken.

Deze eigenschap geeft de superscript‑ of subscripttekst terug of stelt deze in (waarde van -100 % (subscript) tot 100 % (superscript)). Bijvoorbeeld:

- Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation)‑klasse.
- Verkrijg de referentie van een dia door gebruik te maken van de Index.
- Voeg een [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/) van het type [Rectangle](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ShapeType#Rectangle) toe aan de dia.
- Open het [TextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/) dat bij de [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/) hoort.
- Verwijder bestaande alinea’s.
- Maak een nieuw alinea‑object aan voor superscripttekst en voeg het toe aan de [IParagraphs collection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/#getParagraphs) van het [TextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/).
- Maak een nieuw portion‑object aan.
- Stel de Escapement‑eigenschap in voor het portion tussen 0 en 100 om superscript toe te voegen. (0 betekent geen superscript)
- Stel wat tekst in voor [Portion](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Portion) en voeg deze vervolgens toe aan de portion‑collectie van de alinea.
- Maak een nieuw alinea‑object aan voor subscripttekst en voeg het toe aan de IParagraphs‑collectie van de ITextFrame.
- Maak een nieuw portion‑object aan.
- Stel de Escapement‑eigenschap in voor het portion tussen 0 en -100 om subscript toe te voegen. (0 betekent geen subscript)
- Stel wat tekst in voor [Portion](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Portion) en voeg deze vervolgens toe aan de portion‑collectie van de alinea.
- Sla de presentatie op als een PPTX‑bestand.

De implementatie van de bovenstaande stappen wordt hieronder weergegeven.

```php
  # Instantieer een Presentation-klasse die een PPTX voorstelt
  $pres = new Presentation();
  try {
    # Haal dia op
    $slide = $pres->getSlides()->get_Item(0);
    # Maak tekstvak aan
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();
    # Maak alinea voor superscripttekst
    $superPar = new Paragraph();
    # Maak portion met gewone tekst
    $portion1 = new Portion();
    $portion1->setText("SlideTitle");
    $superPar->getPortions()->add($portion1);
    # Maak portion met superscripttekst
    $superPortion = new Portion();
    $superPortion->getPortionFormat()->setEscapement(30);
    $superPortion->setText("TM");
    $superPar->getPortions()->add($superPortion);
    # Maak alinea voor subscripttekst
    $paragraph2 = new Paragraph();
    # Maak portion met gewone tekst
    $portion2 = new Portion();
    $portion2->setText("a");
    $paragraph2->getPortions()->add($portion2);
    # Maak portion met subscripttekst
    $subPortion = new Portion();
    $subPortion->getPortionFormat()->setEscapement(-25);
    $subPortion->setText("i");
    $paragraph2->getPortions()->add($subPortion);
    # Voeg alinea's toe aan tekstvak
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

**Worden superscript en subscript behouden bij exporteren naar PDF of andere formaten?**

Ja, Aspose.Slides behoudt superscript‑ en subscriptopmaak correct bij het exporteren van presentaties naar PDF, PPT/PPTX, afbeeldingen en andere ondersteunde formaten. De gespecialiseerde opmaak blijft in alle uitvoerbestanden intact.

**Kunnen superscript en subscript gecombineerd worden met andere opmaakstijlen zoals vet of cursief?**

Ja, Aspose.Slides stelt u in staat verschillende tekststijlen te combineren binnen één portion tekst. U kunt vet, cursief, onderstrepen inschakelen en tegelijkertijd superscript of subscript toepassen door de bijbehorende eigenschappen in [PortionFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/portionformat/) te configureren.

**Werkt superscript‑ en subscriptopmaak voor tekst in tabellen, grafieken of SmartArt?**

Ja, Aspose.Slides ondersteunt opmaak binnen de meeste objecten, inclusief tabellen en grafiekelementen. Bij het werken met SmartArt moet u de juiste elementen (zoals [SmartArtNode](https://reference.aspose.com/slides/nl/php-java/aspose.slides/smartartnode/)) en hun tekstelementen benaderen en vervolgens de [PortionFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/portionformat/)‑eigenschappen op een vergelijkbare manier configureren.