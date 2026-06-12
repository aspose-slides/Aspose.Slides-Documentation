---
title: Standaardpresentatielettertypen opgeven in С++
linktitle: Standaardlettertype
type: docs
weight: 30
url: /nl/cpp/default-font/
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
- С++
- Aspose.Slides
description: "Stel standaardlettertypen in Aspose.Slides voor С++ in om een correcte conversie van PowerPoint (PPT, PPTX) en OpenDocument (ODP) naar PDF, XPS en afbeeldingen te garanderen."
---
## **Overzicht**

Aspose.Slides maakt het mogelijk om standaardlettertypen op te geven die worden gebruikt wanneer een presentatie wordt gerenderd. Dit is handig bij het genereren van miniaturen van dia’s of bij het exporteren van een presentatie naar formaten zoals PDF en XPS. Standaardlettertypen worden geconfigureerd via `LoadOptions` voordat de presentatie wordt geladen.

`set_DefaultRegularFont`-methode definieert het standaardlettertype voor normale tekst, terwijl `set_DefaultAsianFont` het standaardlettertype voor Aziatische tekst definieert. Nadat deze opties zijn ingesteld, kan de presentatie worden geladen en gerenderd met de opgegeven lettertypen.

## **Standaardlettertypen gebruiken voor het renderen van een presentatie**
Aspose.Slides stelt u in staat om het standaardlettertype in te stellen voor het renderen van de presentatie naar PDF, XPS of miniaturen. Dit artikel laat zien hoe u DefaultRegularFont en DefaultAsianFont definieert als standaardlettertypen. Volg de onderstaande stappen om lettertypen uit externe mappen te laden met de Aspose.Slides for C++ API:

1. Maak een instantie van LoadOptions aan.  
2. Stel DefaultRegularFont in op het gewenste lettertype. In het volgende voorbeeld heb ik Wingdings gebruikt.  
3. Stel DefaultAsianFont in op het gewenste lettertype. Ik heb Wingdings gebruikt in het volgende voorbeeld.  
4. Laad de presentatie met Presentation en stel de laadopties in.  
5. Genereer nu de dia-miniatuur, PDF en XPS om de resultaten te verifiëren.  

De implementatie van het bovenstaande staat hieronder.

```cpp
// Gebruik de laadopties om standaard reguliere en Aziatische lettertypen op te geven
auto loadOptions = MakeObject<LoadOptions>(LoadFormat::Auto);
loadOptions->set_DefaultRegularFont(u"Wingdings");
loadOptions->set_DefaultAsianFont(u"Wingdings");

auto pptx = MakeObject<Presentation>(u"DefaultFonts.pptx", loadOptions);

auto image = pptx->get_Slide(0)->GetImage(1, 1);
image->Save(u"DefaultFonts_out.png", ImageFormat::Png);
image->Dispose();

pptx->Save(u"DefaultFonts_out.pdf", SaveFormat::Pdf);
pptx->Save(u"DefaultFonts_out.xps", SaveFormat::Xps);

pptx->Dispose();
```

## **FAQ**

**Wat beïnvloeden DefaultRegularFont en DefaultAsianFont precies — alleen export, of ook miniaturen, PDF, XPS, HTML en SVG?**

Ze nemen deel aan de renderpijplijn voor alle ondersteunde uitvoerformaten. Dit omvat dia-miniaturen, [PDF](/slides/nl/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/nl/cpp/convert-powerpoint-to-xps/), [rasterafbeeldingen](/slides/nl/cpp/convert-powerpoint-to-png/), [HTML](/slides/nl/cpp/convert-powerpoint-to-html/), en [SVG](/slides/nl/cpp/render-a-slide-as-an-svg-image/), omdat Aspose.Slides dezelfde lay-out- en glyph‑resolutie‑logica gebruikt voor deze doelwitten.

**Worden standaardlettertypen toegepast bij het simpelweg lezen en opslaan van een PPTX zonder enige renderen?**

Nee. Standaardlettertypen zijn van belang wanneer tekst moet worden gemeten en getekend. Een simpel open‑en‑opslaan van een presentatie verandert de opgeslagen lettertype‑runs of de structuur van het bestand niet. Standaardlettertypen komen in beeld tijdens bewerkingen die tekst renderen of opnieuw laten vloeien.

**Als ik mijn eigen lettertype‑mappen toevoeg of lettertypen vanuit het geheugen lever, worden ze dan in overweging genomen bij het kiezen van standaardlettertypen?**

Ja. [Custom font sources](/slides/nl/cpp/custom-font/) breiden de catalogus van beschikbare families en glyphs uit die de engine kan gebruiken. Standaardlettertypen en eventuele [fallback rules](/slides/nl/cpp/fallback-font/) zullen eerst tegen die bronnen worden afgewogen, wat zorgt voor meer betrouwbare dekking op servers en in containers.

**Zullen standaardlettertypen invloed hebben op tekstmetriek (kerning, advances) en daardoor op regeleinden en wrapping?**

Ja. Het wijzigen van het lettertype verandert de glyph‑metriek en kan regeleinden, wrapping en paginering tijdens het renderen beïnvloeden. Voor stabiliteit van de lay-out, [embed the original fonts](/slides/nl/cpp/embedded-font/) of kies metrisch compatibele standaard‑ en fallback‑families.

**Heeft het zin om standaardlettertypen in te stellen als alle gebruikte lettertypen in de presentatie zijn ingesloten?**

Vaak is het niet nodig, omdat [embedded fonts](/slides/nl/cpp/embedded-font/) al zorgen voor een consistente weergave. Standaardlettertypen blijven nuttig als vangnet voor tekens die niet door de ingesloten subset worden gedekt of wanneer een bestand zowel ingesloten als niet‑ingesloten tekst bevat.