---
title: Standaardlettertypen voor presentaties op Android
linktitle: Standaardlettertype
type: docs
weight: 30
url: /nl/androidjava/default-font/
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
- Android
- Java
- Aspose.Slides
description: "Stel standaardlettertypen in Aspose.Slides voor Android via Java in om een correcte conversie van PowerPoint (PPT, PPTX) en OpenDocument (ODP) naar PDF, XPS en afbeeldingen te garanderen."
---
## **Overzicht**

Aspose.Slides stelt je in staat om standaardlettertypen op te geven die worden gebruikt wanneer een presentatie wordt gerenderd. Dit is handig bij het genereren van miniatuurafbeeldingen van dia's of het exporteren van een presentatie naar formaten zoals PDF en XPS. Standaardlettertypen worden geconfigureerd via `LoadOptions` voordat de presentatie wordt geladen.

De `setDefaultRegularFont`-methode definieert het standaardlettertype voor gewone tekst, terwijl `setDefaultAsianFont` het standaardlettertype voor Aziatische tekst bepaalt. Nadat deze opties zijn ingesteld, kan de presentatie worden geladen en gerenderd met de opgegeven lettertypen.

## **Gebruik Standaardlettertypen voor het Renderen van een Presentatie**
Aspose.Slides laat je het standaardlettertype instellen voor het renderen van de presentatie naar PDF, XPS of miniaturen. Dit artikel laat zien hoe je DefaultRegularFont en DefaultAsianFont kunt definiëren voor gebruik als standaardlettertypen. Volg de onderstaande stappen om lettertypen uit externe mappen te laden met Aspose.Slides voor Android via de Java-API:

1. Maak een instantie van [LoadOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/LoadOptions).
1. [Stel het DefaultRegularFont in](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) op het gewenste lettertype. In het volgende voorbeeld heb ik Wingdings gebruikt.
1. [Stel het DefaultAsianFont in](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) op het gewenste lettertype. Ik heb Wingdings gebruikt in het volgende voorbeeld.
1. Laad de presentatie met behulp van Presentation en stel de laadopties in.
1. Genereer nu de miniatuur van de dia, PDF en XPS om de resultaten te verifiëren.

De implementatie van het bovenstaande wordt hieronder gegeven.

```java
// Gebruik loadopties om de standaard reguliere en Aziatische lettertypen te definiëren
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");

// Laad de presentatie
Presentation pres = new Presentation("DefaultFonts.pptx", loadOptions);
try {
    // Genereer dia-miniatuur
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
         // sla de afbeelding op de schijf op.
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }

    // Genereer PDF
    pres.save("output_out.pdf", SaveFormat.Pdf);

    // Genereer XPS
    pres.save("output_out.xps", SaveFormat.Xps);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Wat beïnvloeden DefaultRegularFont en DefaultAsianFont precies—alleen export, of ook miniaturen, PDF, XPS, HTML en SVG?**

Ze nemen deel aan de renderpipeline voor alle ondersteunde outputformaten. Dit omvat dia-miniaturen, [PDF](/slides/nl/androidjava/convert-powerpoint-to-pdf/), [XPS](/slides/nl/androidjava/convert-powerpoint-to-xps/), [raster-afbeeldingen](/slides/nl/androidjava/convert-powerpoint-to-png/), [HTML](/slides/nl/androidjava/convert-powerpoint-to-html/), en [SVG](/slides/nl/androidjava/render-a-slide-as-an-svg-image/), omdat Aspose.Slides dezelfde layout- en glyf-resolutielogica gebruikt voor deze doelwitten.

**Worden standaardlettertypen toegepast bij het simpelweg lezen en opslaan van een PPTX zonder enige rendering?**

Nee. Standaardlettertypen zijn relevant wanneer tekst moet worden gemeten en getekend. Een directe open-save van een presentatie wijzigt geen opgeslagen lettertype-runs of de bestandsstructuur. Standaardlettertypen komen in beeld bij bewerkingen die tekst renderen of opnieuw laten vloeien.

**Als ik mijn eigen lettertype-mappen toevoeg of lettertypen uit het geheugen aanlever, worden ze dan in aanmerking genomen bij het kiezen van standaardlettertypen?**

Ja. [Aangepaste lettertype-bronnen](/slides/nl/androidjava/custom-font/) breiden de catalogus van beschikbare families en glyfen uit die de engine kan gebruiken. Standaardlettertypen en eventuele [fallback-regels](/slides/nl/androidjava/fallback-font/) worden eerst tegen die bronnen afgewogen, wat zorgt voor een betrouwbaardere dekking op servers en in containers.

**Zullen standaardlettertypen invloed hebben op tekstmetingen (kerning, breedtes) en daardoor op regeleinde- en afbrekingsgedrag?**

Ja. Het wijzigen van het lettertype verandert de glyf-metingen en kan regeleinden, afbrekingen en paginering tijdens het renderen wijzigen. Voor layout-stabiliteit kun je [de originele lettertypen insluiten](/slides/nl/androidjava/embedded-font/) of metrisch compatibele standaard- en fallback-families kiezen.

**Heeft het nut om standaardlettertypen in te stellen als alle gebruikte lettertypen in de presentatie zijn ingesloten?**

Vaak is het niet nodig, omdat [ingesloten lettertypen](/slides/nl/androidjava/embedded-font/) al zorgen voor een consistente weergave. Standaardlettertypen blijven echter een veiligheidsnet voor tekens die niet door de ingesloten subset worden gedekt of wanneer een bestand zowel ingesloten als niet-ingesloten tekst bevat.