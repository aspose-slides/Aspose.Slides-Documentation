---
title: "Specificeer fallback-lettertypen voor presentaties in Java"
linktitle: "Fallback-lettertype"
type: docs
weight: 10
url: /nl/java/create-fallback-font/
keywords:
- fallback-lettertype
- fallback-regel
- lettertype toepassen
- lettertype vervangen
- Unicode-bereik
- ontbrekende glyph
- juiste glyph
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Beheer Aspose.Slides for Java om fallback-lettertypen in PPT-, PPTX- en ODP-bestanden in te stellen, zodat de tekstweergave consistent blijft op elk apparaat of besturingssysteem."
---
## **Overzicht**

Aspose.Slides stelt je in staat om fallback-lettertypen op te geven voor het renderen en exporteren van presentaties. Fallback-lettertypen worden gebruikt wanneer het primaire lettertype geen glyphs bevat voor bepaalde tekens.

Het fallback‑gedrag wordt geconfigureerd via fallback‑regels. Elke regel koppelt een Unicode‑bereik aan een of meer lettertypen die de benodigde glyphs kunnen bevatten. Je kunt regels definiëren voor verschillende tekenbereiken, fallback-lettertypen toevoegen of verwijderen uit bestaande regels, en meerdere regels organiseren in een collectie van fallback‑lettertype‑regels.

Fallback‑regels zijn runtime‑renderingsinstellingen. Ze wijzigen het presentatie‑bestand niet en worden niet opgeslagen in het PPTX‑bestand.

## **Fallback‑regels**

Aspose.Slides ondersteunt [IFontFallBackRule](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IFontFallBackRule) interface en [FontFallBackRule](https://reference.aspose.com/slides/nl/java/com.aspose.slides/FontFallBackRule) klasse om de regels op te geven die een fallback‑lettertype toepassen. [FontFallBackRule](https://reference.aspose.com/slides/nl/java/com.aspose.slides/FontFallBackRule) klasse vertegenwoordigt een associatie tussen het opgegeven Unicode‑bereik, gebruikt om missen glyphs te zoeken, en een lijst van lettertypen die de juiste glyphs kunnen bevatten:

```java
long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Met meerdere methoden kun je een lijst met lettertypen toevoegen:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Het is ook mogelijk om een fallback‑lettertype te [remove](https://reference.aspose.com/slides/nl/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) of [addFallBackFonts](https://reference.aspose.com/slides/nl/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) toe te voegen aan een bestaande [FontFallBackRule](https://reference.aspose.com/slides/nl/java/com.aspose.slides/FontFallBackRule) object.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/FontFallBackRulesCollection) kan worden gebruikt om een lijst van [FontFallBackRule](https://reference.aspose.com/slides/nl/java/com.aspose.slides/FontFallBackRule) objecten te organiseren, wanneer er een behoefte is om fallback‑lettertype‑vervangingsregels op te geven voor meerdere Unicode‑bereiken.

{{% alert color="primary" title="See also" %}} 
- [Maak fallback-lettertypecollectie](/slides/nl/java/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Wat is het verschil tussen een fallback-lettertype, lettertypevervanging en het insluiten van lettertypen?**

Een fallback‑lettertype wordt alleen gebruikt voor tekens die ontbreken in het primaire lettertype. [Lettertypevervanging](/slides/nl/java/font-substitution/) vervangt het volledige opgegeven lettertype door een ander lettertype. [Lettertype‑insluiten](/slides/nl/java/embedded-font/) verpakt de lettertypen in het uitvoerbestand zodat ontvangers de tekst kunnen bekijken zoals bedoeld.

**Worden fallback-lettertypen toegepast tijdens exporten zoals PDF, PNG of SVG, of alleen bij weergave op het scherm?**

Ja. Fallback beïnvloedt alle [renderings‑ en exportbewerkingen](/slides/nl/java/convert-presentation/) waarbij tekens getekend moeten worden maar ontbreken in het bronlettertype.

**Verandert het configureren van fallback het presentatie‑bestand zelf, en blijft de instelling bewaard voor toekomstige openingen?**

Nee. Fallback‑regels zijn runtime‑renderingsinstellingen in jouw code; ze worden niet opgeslagen in de .pptx en verschijnen niet in PowerPoint.

**Heeft het besturingssysteem (Windows/Linux/macOS) en de set van lettertype‑mappen invloed op de selectie van fallback?**

Ja. De engine zoekt lettertypen in de beschikbare systeem‑mappen en eventuele [extra paden](/slides/nl/java/custom-font/) die je opgeeft. Als een lettertype fysiek niet beschikbaar is, kan een regel die ernaar verwijst geen effect hebben.

**Werkt fallback voor WordArt, SmartArt en diagrammen?**

Ja. Wanneer deze objecten tekst bevatten, wordt hetzelfde glyph‑vervangingsmechanisme toegepast om ontbrekende tekens te renderen.