---
title: Specificeer fallback-lettertypen voor presentaties op Android
linktitle: Fallback lettertype
type: docs
weight: 10
url: /nl/androidjava/create-fallback-font/
keywords:
- fallback lettertype
- fallback regel
- lettertype toepassen
- lettertype vervangen
- Unicode bereik
- ontbrekende glyph
- juiste glyph
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Beheers Aspose.Slides voor Android via Java om fallback-lettertypen in PPT-, PPTX- en ODP-bestanden in te stellen, zodat de tekstconsistentie op elk apparaat of besturingssysteem behouden blijft."
---
## **Overzicht**

Aspose.Slides stelt u in staat fallback‑lettertypen op te geven voor het renderen en exporteren van presentaties. Fallback‑lettertypen worden gebruikt wanneer het primaire lettertype geen glyphs bevat voor bepaalde tekens.

Fallback‑gedrag wordt geconfigureerd via fallback‑regels. Iedere regel koppelt een Unicode‑bereik aan een of meer lettertypen die de benodigde glyphs kunnen bevatten. U kunt regels definiëren voor verschillende tekenbereiken, fallback‑lettertypen toevoegen of verwijderen uit bestaande regels, en meerdere regels organiseren in een collectie van fallback‑lettertype‑regels.

Fallback‑regels zijn runtime‑renderinstellingen. Ze wijzigen het presentatie‑bestand zelf niet en worden niet opgeslagen in het PPTX‑bestand.

## **Fallback‑regels**

Aspose.Slides ondersteunt de [IFontFallBackRule](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IFontFallBackRule)‑interface en de [FontFallBackRule](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/FontFallBackRule)‑klasse om de regels te specificeren die een fallback‑lettertype toepassen. De [FontFallBackRule](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/FontFallBackRule)‑klasse vertegenwoordigt een koppeling tussen het opgegeven Unicode‑bereik, dat wordt gebruikt om ontbrekende glyphs te zoeken, en een lijst van lettertypen die de juiste glyphs kunnen bevatten:

```java
long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Gebruik meerdere manieren om een lijst met lettertypen toe te voegen:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Het is ook mogelijk om een fallback‑lettertype te [remove](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) of [addFallBackFonts](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) toe te voegen aan een bestaand [FontFallBackRule](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/FontFallBackRule) object.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/FontFallBackRulesCollection) kan worden gebruikt om een lijst van [FontFallBackRule](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/FontFallBackRule) objecten te organiseren wanneer er een behoefte is om fallback‑lettertype‑vervangingsregels op te geven voor meerdere Unicode‑bereiken.

{{% alert color="primary" title="Zie ook" %}} 
- [Create Fallback Fonts Collection](/slides/nl/androidjava/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Wat is het verschil tussen een fallback‑lettertype, fonts substitutie en fonts insluiten?**

Een fallback‑lettertype wordt alleen gebruikt voor tekens die ontbreken in het primaire lettertype. [Font substitution](/slides/nl/androidjava/font-substitution/) vervangt het volledige opgegeven lettertype door een ander lettertype. [Font embedding](/slides/nl/androidjava/embedded-font/) verpakt de lettertypen in het uitvoerbestand zodat ontvangers de tekst zoals bedoeld kunnen bekijken.

**Worden fallback‑lettertypen toegepast tijdens exporten zoals PDF, PNG of SVG, of alleen tijdens weergave op het scherm?**

Ja. Fallback beïnvloedt alle [rendering and export operations](/slides/nl/androidjava/convert-presentation/) waarbij tekens getekend moeten worden maar niet aanwezig zijn in het bronlettertype.

**Wijzigt het configureren van fallback het presentatie‑bestand zelf, en blijft de instelling bewaard voor toekomstige openingen?**

Nee. Fallback‑regels zijn runtime‑renderinstellingen in uw code; ze worden niet opgeslagen in de .pptx en verschijnen niet in PowerPoint.

**Heeft het besturingssysteem (Windows/Linux/macOS) en de set van lettertype‑mappen invloed op de fallback‑selectie?**

Ja. De engine zoekt lettertypen in de beschikbare systeemfolders en in eventuele [additional paths](/slides/nl/androidjava/custom-font/) die u opgeeft. Als een lettertype niet fysiek beschikbaar is, kan een regel die ernaar verwijst geen effect hebben.

**Werkt fallback voor WordArt, SmartArt en grafieken?**

Ja. Wanneer deze objecten tekst bevatten, wordt hetzelfde glyph‑substitutiemechanisme toegepast om ontbrekende tekens weer te geven.