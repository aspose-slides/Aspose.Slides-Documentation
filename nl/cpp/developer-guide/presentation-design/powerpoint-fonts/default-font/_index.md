---
title: Standaardpresentatielettertypen opgeven in C++
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
- C++
- Aspose.Slides
description: "Stel standaardlettertypen in Aspose.Slides voor C++ in om een juiste conversie van PowerPoint (PPT, PPTX) en OpenDocument (ODP) naar PDF, XPS en afbeeldingen te garanderen."
---
## **Overzicht**

Aspose.Slides stelt u in staat om standaardlettertypen op te geven die worden gebruikt wanneer een presentatie wordt gerenderd. Dit is nuttig bij het genereren van miniatuurafbeeldingen van dia’s of bij het exporteren van een presentatie naar formaten zoals PDF en XPS. Standaardlettertypen worden geconfigureerd via `LoadOptions` voordat de presentatie wordt geladen.

De methode `set_DefaultRegularFont` definieert het standaardlettertype voor gewone tekst, terwijl `set_DefaultAsianFont` het standaardlettertype voor Aziatische tekst definieert. Nadat deze opties zijn ingesteld, kan de presentatie worden geladen en gerenderd met de opgegeven lettertypen.

## **Standaardlettertypen gebruiken voor het renderen van een presentatie**
Aspose.Slides laat u het standaardlettertype instellen voor het renderen van de presentatie naar PDF, XPS of miniaturen. Dit artikel toont hoe u DefaultRegularFont en DefaultAsianFont kunt definiëren als standaardlettertypen. Volg de onderstaande stappen om lettertypen uit externe mappen te laden met behulp van de Aspose.Slides for C++ API:

1. Maak een instantie van LoadOptions.  
1. Stel DefaultRegularFont in op het gewenste lettertype. In het volgende voorbeeld heb ik Wingdings gebruikt.  
1. Stel DefaultAsianFont in op het gewenste lettertype. Ik heb Wingdings gebruikt in het volgende voorbeeld.  
1. Laad de presentatie met Presentation en stel de laadopties in.  
1. Genereer nu de miniatuur van de dia, PDF en XPS om de resultaten te verifieren.

De implementatie van het bovenstaande staat hieronder.

```cpp
// Gebruik de laadopties om standaardreguliere en Aziatische lettertypen op te geven
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

**Wat beïnvloeden DefaultRegularFont en DefaultAsianFont precies—alleen export, of ook miniaturen, PDF, XPS, HTML en SVG?**

Ze nemen deel aan de renderpipeline voor alle ondersteunde outputs. Dit omvat dia‑miniaturen, [PDF](/slides/nl/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/nl/cpp/convert-powerpoint-to-xps/), [rasterafbeeldingen](/slides/nl/cpp/convert-powerpoint-to-png/), [HTML](/slides/nl/cpp/convert-powerpoint-to-html/), en [SVG](/slides/nl/cpp/render-a-slide-as-an-svg-image/), omdat Aspose.Slides dezelfde layout‑ en glyph‑resolutielogica gebruikt voor deze doelen.

**Worden standaardlettertypen toegepast bij eenvoudig inlezen en opslaan van een PPTX zonder enige rendering?**

Nee. Standaardlettertypen zijn relevant wanneer tekst moet worden gemeten en getekend. Een eenvoudige open‑save van een presentatie wijzigt de opgeslagen lettertype‑runs of de structuur van het bestand niet. Standaardlettertypen komen in beeld tijdens bewerkingen die tekst renderen of herflowen.

**Als ik mijn eigen lettertype‑mappen toevoeg of lettertypen vanuit het geheugen lever, worden die dan meegenomen bij het kiezen van standaardlettertypen?**

Ja. [Aangepaste lettertypebronnen](/slides/nl/cpp/custom-font/) breiden de catalogus van beschikbare families en glyphs uit die de engine kan gebruiken. Standaardlettertypen en eventuele [fallback‑regels](/slides/nl/cpp/fallback-font/) worden eerst tegen die bronnen afgehandeld, wat zorgt voor betrouwbaardere dekking op servers en in containers.

**Zullen standaardlettertypen de tekstmetingen (kerning, advances) beïnvloeden en dus regeleinden en woordafbreking?**

Ja. Het wijzigen van het lettertype wijzigt de glyph‑metingen en kan regeleinden, woordafbreking en paginering tijdens het renderen veranderen. Voor layout‑stabiliteit kunt u [de originele lettertypen insluiten](/slides/nl/cpp/embedded-font/) of metrisch compatibele standaard‑ en fallback‑families kiezen.

**Heeft het inzetten van standaardlettertypen nog nut als alle lettertypen in de presentatie zijn ingesloten?**

Vaak is het niet nodig, omdat [ingesloten lettertypen](/slides/nl/cpp/embedded-font/) al zorgen voor een consistente weergave. Standaardlettertypen blijven echter een vangnet voor tekens die niet door de ingesloten subset worden gedekt of wanneer een bestand een mix van ingesloten en niet‑ingesloten tekst bevat.