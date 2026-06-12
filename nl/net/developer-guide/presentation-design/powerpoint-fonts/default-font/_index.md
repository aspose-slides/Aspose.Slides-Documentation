---
title: Standaardpresentatielettertypen opgeven in .NET
linktitle: Standaardlettertype
type: docs
weight: 30
url: /nl/net/default-font/
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
- .NET
- C#
- Aspose.Slides
description: "Stel standaardlettertypen in in Aspose.Slides voor .NET in om een correcte conversie van PowerPoint (PPT, PPTX) en OpenDocument (ODP) naar PDF, XPS en afbeeldingen te garanderen."
---
## **Overzicht**

Aspose.Slides stelt u in staat standaardlettertypen op te geven die worden gebruikt wanneer een presentatie wordt gerenderd. Dit is handig bij het genereren van dia‑miniaturen of het exporteren van een presentatie naar formaten zoals PDF en XPS. Standaardlettertypen worden geconfigureerd via `LoadOptions` voordat de presentatie wordt geladen.

De eigenschap `DefaultRegularFont` bepaalt het standaardlettertype voor gewone tekst, terwijl `DefaultAsianFont` het standaardlettertype voor Aziatische tekst definieert. Nadat deze opties zijn ingesteld, kan de presentatie worden geladen en gerenderd met de opgegeven lettertypen.

## **Gebruik standaardlettertypen voor het renderen van een presentatie**
Aspose.Slides laat u het standaardlettertype instellen voor het renderen van de presentatie naar PDF, XPS of miniaturen. Dit artikel laat zien hoe u DefaultRegularFont en DefaultAsianFont kunt definiëren voor gebruik als standaardlettertypen. Volg de onderstaande stappen om lettertypen uit externe mappen te laden met de Aspose.Slides for .NET‑API:

1. Maak een instantie van LoadOptions.
2. Stel de DefaultRegularFont in op het gewenste lettertype. In het volgende voorbeeld heb ik Wingdings gebruikt.
3. Stel de DefaultAsianFont in op het gewenste lettertype. Ik heb Wingdings gebruikt in het volgende voorbeeld.
4. Laad de presentatie met Presentation en stel de laadopties in.
5. Genereer nu de dia‑miniatuur, PDF en XPS om de resultaten te verifiëren.

De implementatie van het bovenstaande wordt hieronder getoond.

```c#
// Gebruik de laadopties om standaard reguliere en Aziatische lettertypen op te geven
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.DefaultRegularFont = "Wingdings";
loadOptions.DefaultAsianFont = "Wingdings";

using (Presentation pptx = new Presentation("DefaultFonts.pptx", loadOptions))
{
    using (IImage image = pptx.Slides[0].GetImage(1, 1))
    {
        image.Save("DefaultFonts_out.png", ImageFormat.Png);
    }

    pptx.Save("DefaultFonts_out.pdf", SaveFormat.Pdf);
    pptx.Save("DefaultFonts_out.xps", SaveFormat.Xps);
}
```

## **FAQ**

**Wat beïnvloeden DefaultRegularFont en DefaultAsianFont precies — alleen export, of ook miniaturen, PDF, XPS, HTML en SVG?**

Ze nemen deel aan de renderpijplijn voor alle ondersteunde uitvoerformaten. Dit omvat dia‑miniaturen, [PDF](/slides/nl/net/convert-powerpoint-to-pdf/), [XPS](/slides/nl/net/convert-powerpoint-to-xps/), [rasterafbeeldingen](/slides/nl/net/convert-powerpoint-to-png/), [HTML](/slides/nl/net/convert-powerpoint-to-html/), en [SVG](/slides/nl/net/render-a-slide-as-an-svg-image/), omdat Aspose.Slides dezelfde lay‑out‑ en glyph‑resolutie‑logica gebruikt voor deze doelwitten.

**Worden standaardlettertypen toegepast bij het simpelweg lezen en opslaan van een PPTX zonder enige rendering?**

Nee. Standaardlettertypen zijn van belang wanneer tekst moet worden gemeten en getekend. Een eenvoudige open‑save van een presentatie verandert de opgeslagen lettertype‑runs of de structuur van het bestand niet. Standaardlettertypen komen in beeld tijdens bewerkingen die tekst renderen of opnieuw laten vloeien.

**Als ik mijn eigen lettertype‑mappen toevoeg of lettertypen vanuit het geheugen lever, worden ze dan in aanmerking genomen bij het kiezen van standaardlettertypen?**

Ja. [Aangepaste lettertype‑bronnen](/slides/nl/net/custom-font/) breiden de catalogus van beschikbare families en glyphs uit die de engine kan gebruiken. Standaardlettertypen en eventuele [fallback‑regels](/slides/nl/net/fallback-font/) zullen eerst tegen die bronnen worden opgelost, waardoor er op servers en in containers een betrouwbaar‑dere dekking ontstaat.

**Zullen standaardlettertypen de tekstmetriek (kerning, voortgang) en daardoor regelafbrekingen en -omloop beïnvloeden?**

Ja. Het wijzigen van het lettertype verandert de glyph‑metriek en kan regelafbrekingen, omloop en paginering tijdens het renderen wijzigen. Voor stabiliteit van de lay‑out, [embed de originele lettertypen](/slides/nl/net/embedded-font/) of kies metrisch compatibele standaard‑ en fallback‑families.

**Heeft het instellen van standaardlettertypen nog zin als alle in de presentatie gebruikte lettertypen zijn ingesloten?**

Vaak is het niet nodig, omdat [ingesloten lettertypen](/slides/nl/net/embedded-font/) al een consistente weergave garanderen. Standaardlettertypen blijven echter nuttig als vangnet voor tekens die niet door de ingesloten subset worden gedekt of wanneer een bestand ingesloten en niet‑ingesloten tekst combineert.