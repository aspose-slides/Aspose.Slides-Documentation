---
title: Standaardlettertypen voor Presentaties opgeven in JavaScript
linktitle: Standaardlettertype
type: docs
weight: 30
url: /nl/nodejs-java/default-font/
keywords:
- standaardlettertype
- regulier lettertype
- normaal lettertype
- Aziatisch lettertype
- PDF-export
- XPS-export
- afbeeldingsexport
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Stel standaardlettertypen in Aspose.Slides voor Node.js via Java in om een correcte conversie van PowerPoint (PPT, PPTX) en OpenDocument (ODP) naar PDF, XPS en afbeeldingen te waarborgen."
---
## **Overzicht**

Aspose.Slides stelt u in staat om standaardlettertypen op te geven die worden gebruikt wanneer een presentatie wordt gerenderd. Dit is handig bij het genereren van dia‑miniaturen of het exporteren van een presentatie naar formaten zoals PDF en XPS. Standaardlettertypen worden geconfigureerd via `LoadOptions` voordat de presentatie wordt geladen.

`setDefaultRegularFont`‑methode definieert het standaardlettertype voor gewone tekst, terwijl `setDefaultAsianFont` het standaardlettertype voor Aziatische tekst definieert. Nadat deze opties zijn ingesteld, kan de presentatie worden geladen en gerenderd met de opgegeven lettertypen.

## **Standaardlettertypen gebruiken voor het renderen van een presentatie**
Aspose.Slides laat u het standaardlettertype instellen voor het renderen van de presentatie naar PDF, XPS of miniaturen. Dit artikel toont hoe u DefaultRegularFont en DefaultAsianFont kunt definiëren voor gebruik als standaardlettertypen. Volg de onderstaande stappen om lettertypen uit externe mappen te laden met Aspose.Slides voor Node.js via de Java‑API:

1. Maak een instantie van [LoadOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/LoadOptions).
2. [Stel de DefaultRegularFont in](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) op het gewenste lettertype. In het volgende voorbeeld heb ik Wingdings gebruikt.
3. [Stel de DefaultAsianFont in](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) op het gewenste lettertype. Ik heb Wingdings in het volgende voorbeeld gebruikt.
4. Laad de presentatie met behulp van Presentation en stel de load‑opties in.
5. Genereer nu de dia‑miniatuur, PDF en XPS om de resultaten te verifiëren.

```javascript
// Gebruik load‑opties om de standaard reguliere en Aziatische lettertypen te definiëren
var loadOptions = new aspose.slides.LoadOptions(aspose.slides.LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");
// Laad de presentatie
var pres = new aspose.slides.Presentation("DefaultFonts.pptx", loadOptions);
try {
    // Genereer dia‑miniatuur
    var slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
        // sla de afbeelding op de schijf op.
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    // Genereer PDF
    pres.save("output_out.pdf", aspose.slides.SaveFormat.Pdf);
    // Genereer XPS
    pres.save("output_out.xps", aspose.slides.SaveFormat.Xps);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Veelgestelde vragen**

**Wat beïnvloeden DefaultRegularFont en DefaultAsianFont precies—alleen export, of ook miniaturen, PDF, XPS, HTML en SVG?**

Ze maken deel uit van de render‑pipeline voor alle ondersteunde uitvoerformaten. Dit omvat dia‑miniaturen, [PDF](/slides/nl/nodejs-java/convert-powerpoint-to-pdf/), [XPS](/slides/nl/nodejs-java/convert-powerpoint-to-xps/), [rasterafbeeldingen](/slides/nl/nodejs-java/convert-powerpoint-to-png/), [HTML](/slides/nl/nodejs-java/convert-powerpoint-to-html/), en [SVG](/slides/nl/nodejs-java/render-a-slide-as-an-svg-image/), omdat Aspose.Slides dezelfde lay‑out‑ en glyph‑resolutie‑logica gebruikt voor deze doelwitten.

**Worden standaardlettertypen toegepast bij het eenvoudigweg lezen en opslaan van een PPTX zonder enige rendering?**

Nee. Standaardlettertypen zijn relevant wanneer tekst moet worden gemeten en getekend. Een directe open‑save van een presentatie wijzigt de opgeslagen lettertype‑runs of de bestandsstructuur niet. Standaardlettertypen komen in beeld bij bewerkingen die tekst renderen of opnieuw indelen.

**Als ik mijn eigen lettertype‑mappen toevoeg of lettertypen vanuit het geheugen lever, worden die dan meegenomen bij het kiezen van standaardlettertypen?**

Ja. [Aangepaste fontbronnen](/slides/nl/nodejs-java/custom-font/) breiden de catalogus van beschikbare families en glyphs uit die de engine kan gebruiken. Standaardlettertypen en eventuele [fallback‑regels](/slides/nl/nodejs-java/fallback-font/) worden eerst tegen die bronnen afgehandeld, waardoor er betrouwbaardere dekking is op servers en in containers.

**Zullen standaardlettertypen de tekstmetriek (kerning, voortgang) beïnvloeden en daardoor regeleinden en afbrekingen?**

Ja. Het wijzigen van het lettertype verandert de glyph‑metriek en kan regeleinden, afbrekingen en paginering tijdens het renderen beïnvloeden. Voor een stabiele lay‑out, [insluit de originele lettertypen](/slides/nl/nodejs-java/embedded-font/) of selecteer metrisch compatibele standaard‑ en fallback‑families.

**Is het zinvol om standaardlettertypen in te stellen als alle gebruikte lettertypen in de presentatie ingebed zijn?**

Vaak is het niet nodig, omdat [ingesloten lettertypen](/slides/nl/nodejs-java/embedded-font/) al zorgen voor een consistente weergave. Standaardlettertypen blijven echter nuttig als vangnet voor tekens die niet door de ingebedde subset worden gedekt of wanneer een bestand zowel ingebedde als niet‑ingebedde tekst bevat.