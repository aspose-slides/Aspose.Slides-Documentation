---
title: Standaardpresentatielettertypen opgeven in PHP
linktitle: Standaardlettertype
type: docs
weight: 30
url: /nl/php-java/default-font/
keywords:
- standaardlettertype
- normaal lettertype
- normaal lettertype
- Aziatisch lettertype
- PDF-export
- XPS-export
- afbeeldingsexport
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Stel standaardlettertypen in voor Aspose.Slides voor PHP via Java in om een correcte conversie van PowerPoint (PPT, PPTX) en OpenDocument (ODP) naar PDF, XPS en afbeeldingen te waarborgen."
---
## **Overzicht**

Aspose.Slides stelt u in staat om standaardlettertypen op te geven die worden gebruikt wanneer een presentatie wordt gerenderd. Dit is nuttig bij het genereren van miniaturen van dia's of het exporteren van een presentatie naar formaten zoals PDF en XPS. Standaardlettertypen worden geconfigureerd via `LoadOptions` voordat de presentatie wordt geladen.

De methode `setDefaultRegularFont` bepaalt het standaardlettertype voor normale tekst, terwijl `setDefaultAsianFont` het standaardlettertype voor Aziatische tekst bepaalt. Nadat deze opties zijn ingesteld, kan de presentatie worden geladen en gerenderd met de opgegeven lettertypen.

## **Standaardlettertypen gebruiken voor het renderen van een presentatie**
Aspose.Slides stelt u in staat het standaardlettertype in te stellen voor het renderen van de presentatie naar PDF, XPS of miniaturen. Dit artikel laat zien hoe u DefaultRegularFont en DefaultAsianFont kunt definiëren voor gebruik als standaardlettertypen. Volg de onderstaande stappen om lettertypen uit externe mappen te laden met behulp van Aspose.Slides voor PHP via de Java API:

1. Maak een instantie van [LoadOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/LoadOptions).
1. [Stel de DefaultRegularFont in](https://reference.aspose.com/slides/nl/php-java/aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) op het gewenste lettertype. In het volgende voorbeeld heb ik Wingdings gebruikt.
1. [Stel de DefaultAsianFont in](https://reference.aspose.com/slides/nl/php-java/aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) op het gewenste lettertype. Ik heb Wingdings gebruikt in het volgende voorbeeld.
1. Laad de presentatie met behulp van Presentation en stel de laadopties in.
1. Genereer nu de dia-miniatuur, PDF en XPS om de resultaten te verifiëren.

De implementatie hiervan wordt hieronder getoond.

```php
  # Gebruik laadopties om de standaard reguliere en Aziatische lettertypen te definiëren
  $loadOptions = new LoadOptions(LoadFormat::Auto);
  $loadOptions->setDefaultRegularFont("Wingdings");
  $loadOptions->setDefaultAsianFont("Wingdings");
  # Laad de presentatie
  $pres = new Presentation("DefaultFonts.pptx", $loadOptions);
  try {
    # Genereer diavoorbeeld
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1, 1);
    try {
      # Sla de afbeelding op de schijf.
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # Genereer PDF
    $pres->save("output_out.pdf", SaveFormat::Pdf);
    # Genereer XPS
    $pres->save("output_out.xps", SaveFormat::Xps);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Wat precies beïnvloeden DefaultRegularFont en DefaultAsianFont—alleen export, of ook miniaturen, PDF, XPS, HTML en SVG?**

Ze nemen deel aan de renderpijplijn voor alle ondersteunde outputformaten. Dit omvat dia-miniaturen, [PDF](/slides/nl/php-java/convert-powerpoint-to-pdf/), [XPS](/slides/nl/php-java/convert-powerpoint-to-xps/), [rasterafbeeldingen](/slides/nl/php-java/convert-powerpoint-to-png/), [HTML](/slides/nl/php-java/convert-powerpoint-to-html/), en [SVG](/slides/nl/php-java/render-a-slide-as-an-svg-image/), omdat Aspose.Slides dezelfde lay-out‑ en glyph‑resolutielogica gebruikt voor deze doelen.

**Worden standaardlettertypen toegepast bij het simpelweg lezen en opslaan van een PPTX zonder enige weergave?**

Nee. Standaardlettertypen zijn van belang wanneer tekst moet worden gemeten en getekend. Een eenvoudige open‑en‑opslaan van een presentatie verandert de opgeslagen lettertype‑runs of de structuur van het bestand niet.

**Als ik mijn eigen lettertype‑mappen toevoeg of lettertypen vanuit het geheugen lever, worden ze dan meegenomen bij het kiezen van standaardlettertypen?**

Ja. [Aangepaste lettertype‑bronnen](/slides/nl/php-java/custom-font/) breiden de catalogus van beschikbare families en glyphs uit die de engine kan gebruiken. Standaardlettertypen en eventuele [fallback‑regels](/slides/nl/php-java/fallback-font/) zullen eerst tegen die bronnen worden afgezet, waardoor een betrouwbaardere dekking op servers en in containers ontstaat.

**Zullen standaardlettertypen de tekstmetingen (kerning, voortschrijdingswaarden) en daardoor regeleinden en woordomslag beïnvloeden?**

Ja. Het wijzigen van het lettertype verandert de glyph‑metingen en kan regeleinden, woordomslag en paginering tijdens het renderen aanpassen. Voor stabiliteit van de lay-out, [embed de originele lettertypen](/slides/nl/php-java/embedded-font/) of kies metrisch compatibele standaard‑ en fallback‑families.

**Is er nog een reden om standaardlettertypen in te stellen als alle gebruikte lettertypen in de presentatie zijn ingesloten?**

Vaak is het niet nodig, omdat [ingesloten lettertypen](/slides/nl/php-java/embedded-font/) al zorgen voor een consistente weergave. Standaardlettertypen blijven echter nuttig als vangnet voor tekens die niet door de ingesloten subset worden gedekt of wanneer een bestand zowel ingesloten als niet‑ingesloten tekst bevat.