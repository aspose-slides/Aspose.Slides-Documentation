---
title: Lettertypen beheren in presentaties met PHP
linktitle: Lettertypen beheren
type: docs
weight: 10
url: /nl/php-java/manage-fonts/
keywords:
- lettertypen beheren
- lettertype-eigenschappen
- paragraaf
- tekstopmaak
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Lettertypen in PHP beheren met Aspose.Slides: insluiten, substitueren en aangepaste lettertypen laden om PPT-, PPTX- en ODP-presentaties duidelijk, merk-veilig en consistent te houden."
---
## **Beheer Lettertypegerelateerde Eigenschappen**
{{% alert color="primary" %}} 

Presentaties bevatten meestal zowel tekst als afbeeldingen. De tekst kan op verschillende manieren worden opgemaakt, hetzij om specifieke secties en woorden te benadrukken of om te voldoen aan bedrijfsstijlen. Tekstopmaak helpt gebruikers het uiterlijk en gevoel van de presentatiesinhoud te variëren. Dit artikel laat zien hoe je Aspose.Slides voor PHP via Java gebruikt om de lettertype‑eigenschappen van tekstparagrafen op dia's te configureren.

{{% /alert %}} 

Om de lettertype‑eigenschappen van een alinea te beheren met Aspose.Slides voor PHP via Java:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation) klasse aan.
1. Haal een referentie naar een dia op door gebruik te maken van de index.
1. Toegang tot de [Placeholder](https://reference.aspose.com/slides/nl/php-java/aspose.slides/placeholder/) vormen op de dia en cast ze naar [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/).
1. Haal de [Paragraph](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraph/) op uit het [TextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/) dat door de [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/) wordt blootgesteld.
1. Schik de alinea uit.
1. Toegang tot de tekst [Portion] van een [Paragraph].
1. Definieer het lettertype met [FontData] en stel het **Font** van de tekst-[Portion] dienovereenkomstig in.
   1. Stel het lettertype in op vet.
   1. Stel het lettertype in op cursief.
1. Stel de kleur van het lettertype in met behulp van het [FillFormat] dat beschikbaar wordt gesteld door het [Portion]-object.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

De implementatie van de bovenstaande stappen staat hieronder. Het neemt een niet‑aangepaste presentatie en formatteert de lettertypen op één van de dia’s. De screenshots die volgen tonen het invoerbestand en hoe de code‑fragmenten het wijzigen. De code wijzigt het lettertype, de kleur en de stijl van het lettertype.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Figuur: De tekst in het invoerbestand**|

|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Figuur: Dezelfde tekst met bijgewerkte opmaak**|

```php
  # Een Presentation‑object maken dat een PPTX‑bestand vertegenwoordigt
  $pres = new Presentation("FontProperties.pptx");
  try {
    # Een dia benaderen met behulp van zijn positie
    $slide = $pres->getSlides()->get_Item(0);
    # De eerste en tweede placeholder in de dia benaderen en typecasten naar AutoShape
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # De eerste alinea benaderen
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # De alinea uitlijnen
    $para2->getParagraphFormat()->setAlignment(TextAlignment->JustifyLow);
    # Het eerste gedeelte benaderen
    $port1 = $para1->getPortions()->get_Item(0);
    $port2 = $para2->getPortions()->get_Item(0);
    # Nieuwe lettertypen definiëren
    $fd1 = new FontData("Elephant");
    $fd2 = new FontData("Castellar");
    # Nieuwe lettertypen toewijzen aan het gedeelte
    $port1->getPortionFormat()->setLatinFont($fd1);
    $port2->getPortionFormat()->setLatinFont($fd2);
    # Lettertype vet instellen
    $port1->getPortionFormat()->setFontBold(NullableBool::True);
    $port2->getPortionFormat()->setFontBold(NullableBool::True);
    # Lettertype cursief instellen
    $port1->getPortionFormat()->setFontItalic(NullableBool::True);
    $port2->getPortionFormat()->setFontItalic(NullableBool::True);
    # Letterkleur instellen
    $port1->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port1->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $port2->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port2->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # De PPTX opslaan op schijf
    $pres->save("WelcomeFont.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Stel Tekstlettertype‑eigenschappen In**
{{% alert color="primary" %}} 

Zoals vermeld in **Beheer Lettertypegerelateerde Eigenschappen**, wordt een [Portion] gebruikt om tekst met een vergelijkbare opmaakstijl in een alinea vast te houden. Dit artikel laat zien hoe je Aspose.Slides voor PHP via Java gebruikt om een tekstvak met enige tekst te creëren en vervolgens een specifiek lettertype en diverse andere eigenschappen van de lettertype‑familie te definiëren.

{{% /alert %}} 

Om een tekstvak te maken en de lettertype‑eigenschappen van de tekst erin in te stellen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation) klasse aan.
1. Haal een referentie naar een dia op door gebruik te maken van de index.
1. Voeg een [AutoShape] van het type **Rectangle** toe aan de dia.
1. Verwijder de vullingsstijl die aan de [AutoShape] is gekoppeld.
1. Toegang tot het [TextFrame] van de [AutoShape].
1. Voeg enige tekst toe aan het [TextFrame].
1. Toegang tot het [Portion]-object dat bij het [TextFrame] hoort.
1. Definieer het lettertype dat voor de [Portion] moet worden gebruikt.
1. Stel andere lettertype‑eigenschappen in, zoals vet, cursief, onderstrepen, kleur en hoogte, met behulp van de relevante eigenschappen die door het [Portion]-object worden blootgesteld.
1. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

De implementatie van de bovenstaande stappen staat hieronder.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Figuur: Tekst met enkele lettertype‑eigenschappen ingesteld door Aspose.Slides voor PHP via Java**|

```php
  # Een Presentation‑object maken dat een PPTX‑bestand vertegenwoordigt
  $pres = new Presentation();
  try {
    # De eerste dia ophalen
    $sld = $pres->getSlides()->get_Item(0);
    # Een AutoShape van het type Rechthoek toevoegen
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    # Eventuele vullingsstijl die aan de AutoShape is gekoppeld verwijderen
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Het TextFrame benaderen dat bij de AutoShape hoort
    $tf = $ashp->getTextFrame();
    $tf->setText("Aspose TextBox");
    # Het Portion benaderen dat bij het TextFrame hoort
    $port = $tf->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    # Het lettertype voor het Portion instellen
    $port->getPortionFormat()->setLatinFont(new FontData("Times New Roman"));
    # De eigenschap Vet van het lettertype instellen
    $port->getPortionFormat()->setFontBold(NullableBool::True);
    # De eigenschap Cursief van het lettertype instellen
    $port->getPortionFormat()->setFontItalic(NullableBool::True);
    # De eigenschap Onderstrepen van het lettertype instellen
    $port->getPortionFormat()->setFontUnderline(TextUnderlineType::Single);
    # De hoogte van het lettertype instellen
    $port->getPortionFormat()->setFontHeight(25);
    # De kleur van het lettertype instellen
    $port->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # De presentatie opslaan op schijf
    $pres->save("pptxFont.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```