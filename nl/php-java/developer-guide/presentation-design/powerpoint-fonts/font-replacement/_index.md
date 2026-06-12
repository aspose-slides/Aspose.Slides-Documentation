---
title: Stroomlijn lettertypevervanging in presentaties met PHP
linktitle: Lettertypevervanging
type: docs
weight: 60
url: /nl/php-java/font-replacement/
keywords:
- lettertype
- lettertype vervangen
- lettertypevervanging
- lettertype wijzigen
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Vervang moeiteloos lettertypen in Aspose.Slides voor PHP via Java om consistente typografie te garanderen in PowerPoint- en OpenDocument-presentaties."
---
## **Overzicht**

Aspose.Slides stelt u in staat om één lettertype door een ander te vervangen in een hele presentatie. Wanneer een lettertype wordt vervangen, worden alle exemplaren van het oorspronkelijke lettertype gewijzigd naar het nieuwe lettertype.

Om een lettertypevervanging uit te voeren, laadt u de presentatie, definieert u het bronlettertype en het vervangende lettertype, roept u de methode voor lettertypevervanging aan en slaat u de aangepaste presentatie op als een PPTX‑bestand. Deze aanpak is nuttig wanneer u bewust van het ene lettertype‑familie naar een andere wilt schakelen in de gehele presentatie.

## **Lettertypevervanging**

Als u van gedachten verandert over het gebruik van een lettertype, kunt u dat lettertype door een ander vervangen. Alle exemplaren van het oude lettertype worden vervangen door het nieuwe lettertype.

Aspose.Slides maakt het op deze manier mogelijk om een lettertype te vervangen:

1. Laad de betreffende presentatie. 
2. Laad het te vervangen lettertype.
3. Laad het nieuwe lettertype. 
4. Vervang het lettertype. 
5. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

Deze PHP‑code demonstreert lettertypevervanging:

```php
  # Laadt een presentatie
  $pres = new Presentation("Fonts.pptx");
  try {
    # Laadt het bronlettertype dat vervangen zal worden
    $sourceFont = new FontData("Arial");
    # Laadt het nieuwe lettertype
    $destFont = new FontData("Times New Roman");
    # Vervangt de lettertypen
    $pres->getFontsManager()->replaceFont($sourceFont, $destFont);
    # Slaat de presentatie op
    $pres->save("UpdatedFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Note" color="warning" %}} 
Om regels in te stellen die bepalen wat er in bepaalde omstandigheden gebeurt (bijvoorbeeld wanneer een lettertype niet toegankelijk is), zie [**Lettertype‑substitutie**](/slides/nl/php-java/font-substitution/).
{{% /alert %}}

## **FAQ**

**Wat is het verschil tussen “lettertypevervanging”, “lettertype‑substitutie” en “fallback‑lettertypen”?**

Vervanging is een bewuste omschakeling van de ene familie naar de andere in het gehele document. [Substitutie](/slides/nl/php-java/font-substitution/) is een regel zoals “als het lettertype niet beschikbaar is, gebruik X.” [Fallback](/slides/nl/php-java/fallback-font/) wordt chirurgisch toegepast op individuele ontbrekende glyphs wanneer het basistelettertype geïnstalleerd is maar niet de vereiste tekens bevat.

**Is vervanging van toepassing op master‑slides, lay‑outs, notities en opmerkingen?**

Ja. Vervanging beïnvloedt alle presentatie‑objecten die het oorspronkelijke lettertype gebruiken, inclusief master‑slides en notities; opmerkingen maken ook deel uit van het document en worden in aanmerking genomen door de lettertype‑engine.

**Verandert het lettertype binnen ingebedde OLE‑objecten (bijvoorbeeld Excel)?**

Nee. [OLE‑inhoud](/slides/nl/php-java/manage-ole/) wordt beheerd door de eigen toepassing. Vervanging in de presentatie reformatteert de interne OLE‑gegevens niet; ze kunnen worden weergegeven als een afbeelding of als extern bewerkbare inhoud.

**Kan ik een lettertype alleen in een deel van de presentatie vervangen (per slide of regio)?**

Gerichte vervanging is mogelijk wanneer u het lettertype wijzigt op het niveau van de benodigde objecten/bereiken in plaats van een globale vervanging toe te passen op het volledige document. De algemene logica voor lettertype‑selectie tijdens het renderen blijft ongewijzigd.

**Hoe kan ik vooraf bepalen welke lettertypen de presentatie gebruikt?**

Gebruik de presentatie’s [lettertype‑manager](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontsmanager/): hij geeft een lijst van de [gebruikte families](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontsmanager/getfonts/) en informatie over [substituties/“onbekende” lettertypen](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontsmanager/getsubstitutions/), die helpt bij het plannen van de vervanging.

**Werkt lettertypevervanging bij het converteren naar PDF/afbeeldingen?**

Ja. Tijdens export past Aspose.Slides dezelfde [lettertype‑selectie‑/‑substitutie‑volgorde](/slides/nl/php-java/font-selection-sequence/) toe, zodat een vooraf uitgevoerde vervanging wordt gerespecteerd bij de conversie.

**Moet ik het doel‑lettertype in het systeem installeren, of kan ik een lettertype‑map bijvoegen?**

Installatie is niet vereist: de bibliotheek maakt het mogelijk om [externe lettertypen](/slides/nl/php-java/custom-font/) uit gebruikersmappen te laden voor gebruik tijdens het [renderen en exporteren](/slides/nl/php-java/convert-powerpoint/).

**Zal vervanging “tofu” (vierkanten) in plaats van tekens oplossen?**

Alleen als het doel‑lettertype daadwerkelijk de vereiste glyphs bevat. Zo niet, [configureer fallback](/slides/nl/php-java/fallback-font/) om de ontbrekende tekens te dekken.