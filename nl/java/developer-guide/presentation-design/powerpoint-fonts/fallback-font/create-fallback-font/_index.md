---
title: Specificeer fallback-lettertypen voor presentaties in Java
linktitle: Fallback-lettertype
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
- correcte glyph
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Beheers Aspose.Slides voor Java om fallback-lettertypen in PPT-, PPTX- en ODP-bestanden in te stellen, zodat de weergave van tekst op elk apparaat of besturingssysteem consistent blijft."
---
## **Overzicht**

Aspose.Slides stelt u in staat om fallback-lettertypen op te geven voor het renderen en exporteren van presentaties. Fallback-lettertypen worden gebruikt wanneer het primaire lettertype geen glyphs bevat voor bepaalde tekens.

Het fallback-gedrag wordt geconfigureerd via fallback-regels. Elke regel koppelt een Unicode-bereik aan een of meer lettertypen die de benodigde glyphs kunnen bevatten. U kunt regels definiëren voor verschillende tekenreeksen, fallback-lettertypen toevoegen of verwijderen uit bestaande regels, en meerdere regels organiseren in een collectie van fallback-lettertype-regels.

Fallback-regels zijn runtime-renderingsinstellingen. Ze wijzigen het presentatiebestand zelf niet en worden niet opgeslagen in het PPTX‑bestand.

## **Fallback-regels**

Aspose.Slides ondersteunt de [IFontFallBackRule](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IFontFallBackRule) interface en [FontFallBackRule](https://reference.aspose.com/slides/nl/java/com.aspose.slides/FontFallBackRule) klasse om de regels op te geven die een fallback-lettertype toepassen. De [FontFallBackRule](https://reference.aspose.com/slides/nl/java/com.aspose.slides/FontFallBackRule) klasse vertegenwoordigt een koppeling tussen het gespecificeerde Unicode-bereik, gebruikt voor het zoeken naar ontbrekende glyphs, en een lijst van lettertypen die de juiste glyphs kunnen bevatten:

```java
import com.aspose.slides.*;

long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Met meerdere manieren kun je een lettertype‑lijst toevoegen:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Het is ook mogelijk om een fallback-lettertype te [remove](https://reference.aspose.com/slides/nl/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) of [addFallBackFonts](https://reference.aspose.com/slides/nl/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) toe te voegen aan een bestaand [FontFallBackRule](https://reference.aspose.com/slides/nl/java/com.aspose.slides/FontFallBackRule) object.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/FontFallBackRulesCollection) kan worden gebruikt om een lijst van [FontFallBackRule](https://reference.aspose.com/slides/nl/java/com.aspose.slides/FontFallBackRule) objecten te organiseren, wanneer er behoefte is om fallback-lettertype-vervangingsregels op te geven voor meerdere Unicode-bereiken.

{{% alert color="info" title="Zie ook" %}} 
- [Collectie fallback-lettertypen maken](/slides/nl/java/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

### Wat is het verschil tussen een fallback-lettertype, font substitution en font embedding?

Een fallback-lettertype wordt alleen gebruikt voor tekens die ontbreken in het primaire lettertype. [Font substitution](/slides/nl/java/font-substitution/) vervangt het volledig opgegeven lettertype door een ander lettertype. [Font embedding](/slides/nl/java/embedded-font/) verpakt de lettertypen in het uitvoerbestand zodat ontvangers de tekst zoals bedoeld kunnen bekijken.

### Worden fallback-lettertypen toegepast tijdens exporten zoals PDF, PNG of SVG, of alleen bij weergave op het scherm?

Ja. Fallback beïnvloedt alle [rendering and export operations](/slides/nl/java/convert-presentation/) waarbij tekens getekend moeten worden maar ontbreken in het bronlettertype.

### Verandert het configureren van fallback het presentatiebestand zelf, en blijft de instelling bestaan bij toekomstige opengevingen?

Nee. Fallback-regels zijn runtime‑renderingsinstellingen in uw code; ze worden niet opgeslagen in de .pptx en verschijnen niet in PowerPoint.

### Hebben het besturingssysteem (Windows/Linux/macOS) en de reeks lettertype‑mappen invloed op de fallback‑selectie?

Ja. De engine zoekt lettertypen op in de beschikbare systeemmappen en in alle [additional paths](/slides/nl/java/custom-font/) die u opgeeft. Als een lettertype niet fysiek beschikbaar is, kan een regel die ernaar verwijst niet van kracht worden.

### Werkt fallback voor WordArt, SmartArt en diagrammen?

Ja. Wanneer deze objecten tekst bevatten, wordt hetzelfde glyph‑substitutiemechanisme toegepast om ontbrekende tekens weer te geven.