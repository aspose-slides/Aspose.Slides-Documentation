---
title: "Lettertype‑substitutie configureren in presentaties met PHP"
linktitle: "Lettertype‑substitutie"
type: docs
weight: 70
url: /nl/php-java/font-substitution/
keywords:
- "lettertype"
- "vervangend lettertype"
- "lettertype‑substitutie"
- "lettertype vervangen"
- "lettertype‑vervanging"
- "substitutieregel"
- "vervangingsregel"
- "PowerPoint"
- "OpenDocument"
- "presentatie"
- "PHP"
- "Aspose.Slides"
description: "Schakel optimale lettertype‑substitutie in Aspose.Slides voor PHP via Java in bij het converteren van PowerPoint‑ en OpenDocument‑presentaties naar andere bestandsformaten."
---
## **Inleiding**

Lettertype‑substitutie stelt Aspose.Slides in staat om een ander lettertype te gebruiken wanneer het oorspronkelijke lettertype van de presentatie niet beschikbaar is tijdens het renderen of converteren. Je kunt zien welke lettertypen zijn vervangen met de methode `getSubstitutions` van de klasse `FontsManager`.

Aspose.Slides maakt het ook mogelijk om regels voor lettertype‑substitutie te definiëren. Je kunt bijvoorbeeld aangeven dat een ontoegankelijk lettertype moet worden vervangen door een ander beschikbaar lettertype en die regels vervolgens toepassen via de font‑manager van de presentatie.

## **Lettertype‑substitutieregels instellen**

Aspose.Slides laat je regels definiëren voor lettertypen die bepalen wat er moet gebeuren onder bepaalde omstandigheden (bijvoorbeeld wanneer een lettertype niet toegankelijk is) op de volgende manier:

1. Laad de betreffende presentatie.
2. Laad het lettertype dat vervangen moet worden.
3. Laad het nieuwe lettertype.
4. Voeg een regel toe voor de vervanging.
5. Voeg de regel toe aan de verzameling regels voor lettertype‑vervanging van de presentatie.
6. Genereer de slide‑afbeelding om het effect te observeren.

Deze PHP‑code demonstreert het proces van lettertype‑substitutie:

```php
  # Laadt een presentatie
  $pres = new Presentation("Fonts.pptx");
  try {
    # Laadt het bronlettertype dat wordt vervangen
    $sourceFont = new FontData("SomeRareFont");
    # Laadt het nieuwe lettertype
    $destFont = new FontData("Arial");
    # Voegt een lettertype‑regel toe voor lettertype‑vervanging
    $fontSubstRule = new FontSubstRule($sourceFont, $destFont, FontSubstCondition->WhenInaccessible);
    # Voegt de regel toe aan de verzameling substitutieregels voor lettertypen
    $fontSubstRuleCollection = new FontSubstRuleCollection();
    $fontSubstRuleCollection->add($fontSubstRule);
    # Voegt een verzameling lettertype‑regels toe aan de regel‑lijst
    $pres->getFontsManager()->setFontSubstRuleList($fontSubstRuleCollection);
    # Het lettertype Arial wordt gebruikt in plaats van SomeRareFont wanneer dat laatste ontoegankelijk is
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    # Slaat de afbeelding op schijf in JPEG‑formaat
    try {
      $slideImage->save("Thumbnail_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{%  alert title="NOTE"  color="warning"   %}} 

Je wilt misschien [**Font Replacement**](/slides/nl/php-java/font-replacement/) bekijken.

{{% /alert %}}

## **Beperkingen voor wiskundige vergelijking‑lettertypen**

Lettertype‑substitutieregels maken deel uit van het standaard lettertype‑selectieproces dat wordt gebruikt tijdens het renderen en converteren. Ze zijn geschikt voor gewone tekstscenario’s waarin Aspose.Slides een ontoegankelijk lettertype kan vervangen door een ander beschikbaar lettertype volgens de geconfigureerde regel.

Echter, Office‑wiskunde‑vergelijkingen hebben een belangrijke beperking. Als een vergelijking is gemaakt met **Cambria Math**, kan Aspose.Slides nog steeds het oorspronkelijke **Cambria Math**‑lettertype nodig hebben om de lay‑out van de vergelijking correct te berekenen en te renderen. Daarom wordt het vervangen van **Cambria Math** door een ander wiskunde‑lettertype, zoals **STIX Two Math**, niet ondersteund voor het renderen van vergelijkingen en kan dit nog steeds resulteren in een uitzondering die aangeeft dat **Cambria Math** vereist is.

Om dergelijke presentaties succesvol te converteren, zorg ervoor dat **Cambria Math** beschikbaar is voor Aspose.Slides tijdens runtime. Je kunt het lettertype installeren in het besturingssysteem of aanbieden als een [external font](/slides/nl/php-java/custom-font/) zodat het kan deelnemen aan het normale lettertype‑selectieproces tijdens het renderen en converteren.

Deze beperking is specifiek voor het renderen van vergelijkingen. De bovenstaande standaard lettertype‑substitutieregels blijven van toepassing op reguliere presentatietekst wanneer het oorspronkelijke lettertype ontoegankelijk is.

## **FAQ**

**Wat is het verschil tussen lettertype‑vervanging en lettertype‑substitutie?**

[Replacement](/slides/nl/php-java/font-replacement/) is een dwingende overschrijving van het ene lettertype door een ander in de hele presentatie. Substitutie is een regel die geactiveerd wordt onder een specifieke conditie, bijvoorbeeld wanneer het oorspronkelijke lettertype niet beschikbaar is, waarna een aangewezen fallback‑lettertype wordt gebruikt.

**Wanneer precies worden substitutieregels toegepast?**

De regels nemen deel aan de standaard [font selection](/slides/nl/php-java/font-selection-sequence/) volgorde die wordt geëvalueerd tijdens het laden, renderen en converteren; als het gekozen lettertype niet beschikbaar is, wordt vervanging of substitutie toegepast.

**Wat is het standaardgedrag als noch vervanging noch substitutie is geconfigureerd en het lettertype ontbreekt op het systeem?**

De bibliotheek probeert het dichtstbijzijnde beschikbare systeem‑lettertype te kiezen, vergelijkbaar met hoe PowerPoint zich zou gedragen.

**Kan ik aangepaste externe lettertypen toevoegen tijdens runtime om substitutie te voorkomen?**

Ja. Je kunt [add external fonts](/slides/nl/php-java/custom-font/) toevoegen tijdens runtime zodat de bibliotheek ze meeneemt bij selectie en rendering, ook voor latere conversies.

**Distribueert Aspose lettertypen met de bibliotheek?**

Nee. Aspose distribueert geen betaalde of gratis lettertypen; je voegt lettertypen toe en gebruikt ze op eigen risico en verantwoordelijkheid.

**Zijn er verschillen in substitutiegedrag op Windows, Linux en macOS?**

Ja. Het zoeken naar lettertypen start in de lettertype‑mappen van het besturingssysteem. De set standaard beschikbare lettertypen en de zoekpaden verschillen per platform, wat invloed heeft op beschikbaarheid en de noodzaak voor substitutie.

**Hoe moet ik de omgeving voorbereiden om onverwachte substitutie tijdens batch‑conversies te minimaliseren?**

Synchroniseer de set lettertypen over machines of containers, [add the external fonts](/slides/nl/php-java/custom-font/) die nodig zijn voor de output‑documenten, en [embed fonts](/slides/nl/php-java/embedded-font/) in presentaties waar mogelijk zodat de gekozen lettertypen beschikbaar zijn tijdens het renderen.