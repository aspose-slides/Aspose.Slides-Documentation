---
title: Specificeer fallback-lettertypen voor presentaties in JavaScript
linktitle: Fallback-lettertype
type: docs
weight: 10
url: /nl/nodejs-java/create-fallback-font/
keywords:
  - fallback-lettertype
  - fallback-regel
  - lettertype toepassen
  - lettertype vervangen
  - Unicode-bereik
  - missende glyph
  - juiste glyph
  - PowerPoint
  - OpenDocument
  - presentatie
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "Beheers Aspose.Slides voor Node.js om fallback-lettertypen in PPT-, PPTX- en ODP-bestanden in JavaScript in te stellen, waardoor een consistente weergave van tekst op elk apparaat of besturingssysteem wordt gegarandeerd."
---
## **Overzicht**

Met Aspose.Slides kunt u fallback‑lettertypen opgeven voor het renderen en exporteren van presentaties. Fallback‑lettertypen worden gebruikt wanneer het primaire lettertype geen glyphs voor bepaalde tekens bevat.

Het fallback‑gedrag wordt geconfigureerd via fallback‑regels. Elke regel koppelt een Unicode‑bereik aan een of meer lettertypen die de benodigde glyphs kunnen bevatten. U kunt regels definiëren voor verschillende tekenbereiken, fallback‑lettertypen toevoegen of verwijderen uit bestaande regels, en meerdere regels organiseren in een collectie van fallback‑lettertype‑regels.

Fallback‑regels zijn runtime‑renderinstellingen. Ze wijzigen het presentatie‑bestand zelf niet en worden niet opgeslagen in het PPTX‑bestand.

## **Fallback‑regels**

Aspose.Slides ondersteunt de klasse [FontFallBackRule](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/FontFallBackRule) en de klasse [FontFallBackRule](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/FontFallBackRule) om de regels te specificeren die een fallback‑lettertype toepassen. De klasse [FontFallBackRule](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/FontFallBackRule) vertegenwoordigt een associatie tussen het opgegeven Unicode‑bereik, dat wordt gebruikt om missende glyphs te zoeken, en een lijst van lettertypen die de juiste glyphs kunnen bevatten:

```javascript
var startUnicodeIndex = 0xb80;
var endUnicodeIndex = 0xbff;
var firstRule = new aspose.slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
var secondRule = new aspose.slides.FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic");
// Met verschillende methoden kun je een lijst met lettertypen toevoegen:
var fontNames = java.newArray("java.lang.String", ["Segoe UI Emoji, Segoe UI Symbol", "Arial"]));
var thirdRule = new aspose.slides.FontFallBackRule(0x1f300, 0x1f64f, fontNames);
```

Het is ook mogelijk om een fallback‑lettertype te [remove](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) of [addFallBackFonts](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) toe te voegen aan een bestaand [FontFallBackRule](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/FontFallBackRule) object.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/FontFallBackRulesCollection) kan worden gebruikt om een lijst van [FontFallBackRule](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/FontFallBackRule) objecten te organiseren, wanneer er behoefte is om fallback‑lettertype‑vervangingsregels te specificeren voor meerdere Unicode‑bereiken.

{{% alert color="primary" title="Zie ook" %}} 
- [Collectie van fallback‑lettertypen aanmaken](/slides/nl/nodejs-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **Veelgestelde vragen**

**Wat is het verschil tussen een fallback‑lettertype, font substitution en het insluiten van lettertypen?**

Een fallback‑lettertype wordt alleen gebruikt voor tekens die ontbreken in het primaire lettertype. [Font substitution](/slides/nl/nodejs-java/font-substitution/) vervangt het volledig opgegeven lettertype door een ander lettertype. [Font embedding](/slides/nl/nodejs-java/embedded-font/) verpakt de lettertypen in het uitvoerbestand zodat ontvangers de tekst kunnen zien zoals bedoeld.

**Worden fallback‑lettertypen toegepast tijdens exporten zoals PDF, PNG of SVG, of alleen bij weergave op het scherm?**

Ja. Fallback beïnvloedt alle [rendering and export operations](/slides/nl/nodejs-java/convert-presentation/) waarbij tekens moeten worden getekend maar afwezig zijn in het bronlettertype.

**Verandert het configureren van fallback het presentatiedocument zelf, en blijft de instelling behouden bij toekomstige openingen?**

Nee. Fallback‑regels zijn runtime‑renderinstellingen in uw code; ze worden niet opgeslagen in de .pptx en verschijnen niet in PowerPoint.

**Hebben het besturingssysteem (Windows/Linux/macOS) en de reeks lettertype‑mappen invloed op de selectie van fallback‑lettertypen?**

Ja. De engine zoekt lettertypen op in de beschikbare systeemmappen en eventuele [additional paths](/slides/nl/nodejs-java/custom-font/) die u opgeeft. Als een lettertype fysiek niet beschikbaar is, kan een regel die hiernaar verwijst geen effect hebben.

**Werkt fallback voor WordArt, SmartArt en grafieken?**

Ja. Wanneer deze objecten tekst bevatten, wordt hetzelfde glyph‑substitutiemechanisme toegepast om missende tekens weer te geven.