---
title: Standaardlettertypen voor presentaties opgeven in Java
linktitle: Standaardlettertype
type: docs
weight: 30
url: /nl/java/default-font/
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
- Java
- Aspose.Slides
description: "Standaardlettertypen instellen in Aspose.Slides voor Java om een correcte conversie van PowerPoint (PPT, PPTX) en OpenDocument (ODP) naar PDF, XPS en afbeeldingen te waarborgen."
---
## **Overzicht**

Aspose.Slides stelt u in staat om standaardlettertypen op te geven die worden gebruikt wanneer een presentatie wordt gerenderd. Dit is handig bij het genereren van miniaturen van dia’s of bij het exporteren van een presentatie naar formaten zoals PDF en XPS. Standaardlettertypen worden geconfigureerd via `LoadOptions` voordat de presentatie wordt geladen.

De `setDefaultRegularFont`‑methode definieert het standaardlettertype voor gewone tekst, terwijl `setDefaultAsianFont` het standaardlettertype voor Aziatische tekst bepaalt. Nadat deze opties zijn ingesteld, kan de presentatie worden geladen en gerenderd met de opgegeven lettertypen.

## **Standaardlettertypen gebruiken voor het renderen van een presentatie**
Aspose.Slides laat u het standaardlettertype instellen voor het renderen van de presentatie naar PDF, XPS of miniaturen. In dit artikel wordt uitgelegd hoe u DefaultRegularFont en DefaultAsianFont definieert als standaardlettertypen. Volg de onderstaande stappen om lettertypen uit externe mappen te laden met de Aspose.Slides for Java‑API:

1. Maak een instantie aan van [LoadOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/LoadOptions).
1. [Set the DefaultRegularFont](https://reference.aspose.com/slides/nl/java/com.aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) naar het gewenste lettertype. In het volgende voorbeeld heb ik Wingdings gebruikt.
1. [Set the DefaultAsianFont](https://reference.aspose.com/slides/nl/java/com.aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) naar het gewenste lettertype. Ook hier heb ik Wingdings gebruikt.
1. Laad de presentatie met Presentation en stel de load‑opties in.
1. Genereer nu de dia‑miniatuur, PDF en XPS om de resultaten te verifiëren.

De implementatie van het bovenstaande wordt hieronder getoond.

```java
// Gebruik laadopties om de standaard reguliere en Aziatische lettertypen te definiëren
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");

// Laad de presentatie
Presentation pres = new Presentation("DefaultFonts.pptx", loadOptions);
try {
    // Miniatuur van dia genereren
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
         // sla de afbeelding op op de schijf.
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }

    // PDF genereren
    pres.save("output_out.pdf", SaveFormat.Pdf);

    // XPS genereren
    pres.save("output_out.xps", SaveFormat.Xps);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Wat precies beïnvloeden DefaultRegularFont en DefaultAsianFont – alleen export, of ook miniaturen, PDF, XPS, HTML en SVG?**

Ze maken deel uit van de render‑pipeline voor alle ondersteunde uitvoerformaten. Dit omvat dia‑miniaturen, [PDF](/slides/nl/java/convert-powerpoint-to-pdf/), [XPS](/slides/nl/java/convert-powerpoint-to-xps/), [raster‑afbeeldingen](/slides/nl/java/convert-powerpoint-to-png/), [HTML](/slides/nl/java/convert-powerpoint-to-html/) en [SVG](/slides/nl/java/render-a-slide-as-an-svg-image/), omdat Aspose.Slides dezelfde lay‑out‑ en glyph‑resolutie‑logica gebruikt voor deze doelstellingen.

**Worden standaardlettertypen toegepast bij het simpelweg lezen en opslaan van een PPTX zonder enige rendering?**

Nee. Standaardlettertypen zijn van belang wanneer tekst moet worden gemeten en getekend. Een directe open‑save‑bewerking van een presentatie wijzigt de opgeslagen lettertype‑runs of de structuur van het bestand niet. Standaardlettertypen komen in beeld tijdens bewerkingen die tekst renderen of opnieuw laten vloeien.

**Als ik mijn eigen lettertype‑mappen toevoeg of lettertypen vanuit het geheugen aanbied, worden die dan meegenomen bij het bepalen van de standaardlettertypen?**

Ja. [Custom font sources](/slides/nl/java/custom-font/) breiden de catalogus van beschikbare families en glyphs uit die de engine kan gebruiken. Standaardlettertypen en eventuele [fallback‑regels](/slides/nl/java/fallback-font/) zullen eerst tegen die bronnen worden afgewogen, wat zorgt voor een bredere dekking op servers en in containers.

**Zullen standaardlettertypen invloed hebben op tekst‑metrieken (kerning, advances) en daardoor op regeleinden en woordafbreking?**

Ja. Het wijzigen van het lettertype verandert de glyph‑metrieken en kan regeleinden, woordafbreking en paginering tijdens het renderen beïnvloeden. Voor layout‑stabiliteit kunt u de oorspronkelijke lettertypen [embedden](/slides/nl/java/embedded-font/) of metrisch compatibele standaard‑ en fallback‑families kiezen.

**Heeft het instellen van standaardlettertypen nog zin als alle lettertypen in de presentatie al zijn ingebed?**

Vaak niet nodig, omdat [embedded fonts](/slides/nl/java/embedded-font/) al zorgen voor een consistente weergave. Standaardlettertypen blijven echter een vangnet bieden voor tekens die niet door de ingebedde subset worden gedekt of wanneer een bestand zowel ingebedde als niet‑ingebedde tekst bevat.