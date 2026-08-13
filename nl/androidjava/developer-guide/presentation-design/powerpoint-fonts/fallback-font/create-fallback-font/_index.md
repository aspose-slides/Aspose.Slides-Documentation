---
title: Specificeer fallback-lettertypen voor presentaties op Android
linktitle: Fallback-lettertype
type: docs
weight: 10
url: /nl/androidjava/create-fallback-font/
keywords:
- fallback-lettertype
- fallback-regel
- lettertype toepassen
- lettertype vervangen
- Unicode-bereik
- ontbrekende glyf
- juiste glyf
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Beheers Aspose.Slides voor Android via Java om fallback-lettertypen in PPT-, PPTX- en ODP-bestanden in te stellen, waardoor consistente tekstweergave op elk apparaat of besturingssysteem wordt gegarandeerd."
---
## **Overzicht**

Aspose.Slides stelt je in staat om fallback-lettertypen op te geven voor weergave‑ en export‑bewerkingen van presentaties. Fallback‑lettertypen worden gebruikt wanneer het primaire lettertype geen glyfen bevat voor bepaalde tekens.

Het fallback‑gedrag wordt geconfigureerd via fallback‑regels. Elke regel koppelt een Unicode‑bereik aan één of meer lettertypen die de benodigde glyfen kunnen bevatten. Je kunt regels definiëren voor verschillende tekenbereiken, fallback‑lettertypen toevoegen of verwijderen uit bestaande regels, en meerdere regels organiseren in een collectie van fallback‑lettertype‑regels.

Fallback‑regels zijn runtime‑renderingsinstellingen. Ze wijzigen het presentatie‑bestand zelf niet en worden niet opgeslagen in het PPTX‑bestand.

## **Fallback‑regels**

Aspose.Slides ondersteunt de interface [IFontFallBackRule](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IFontFallBackRule) en de klasse [FontFallBackRule](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/FontFallBackRule) om de regels te specificeren die een fallback‑lettertype toepassen. De klasse [FontFallBackRule](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/FontFallBackRule) vertegenwoordigt een associatie tussen het opgegeven Unicode‑bereik, dat wordt gebruikt om ontbrekende glyfen te zoeken, en een lijst van lettertypen die de juiste glyfen kunnen bevatten:

```java
import com.aspose.slides.*;

long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Met verschillende manieren kun je een lijst met lettertypen toevoegen:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Het is ook mogelijk om een fallback‑lettertype te [remove](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) of [addFallBackFonts](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) toe te voegen aan een bestaand [FontFallBackRule](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/FontFallBackRule) object.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/FontFallBackRulesCollection) kan worden gebruikt om een lijst van [FontFallBackRule](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/FontFallBackRule)‑objecten te organiseren, wanneer er een behoefte is om fallback‑lettertype‑vervangingsregels op te geven voor meerdere Unicode‑bereiken.

{{% alert color="info" title="Zie ook" %}} 
- [Maak fallback-lettertypen collectie](/slides/nl/androidjava/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

### Wat is het verschil tussen een fallback‑lettertype, lettertypevervanging en lettertype‑inbedden?

Een fallback‑lettertype wordt alleen gebruikt voor tekens die ontbreken in het primaire lettertype. [Lettertypevervanging](/slides/nl/androidjava/font-substitution/) vervangt het volledige opgegeven lettertype door een ander lettertype. [Lettertype‑inbedden](/slides/nl/androidjava/embedded-font/) verpakt de lettertypen in het uitvoerbestand zodat ontvangers de tekst zoals bedoeld kunnen bekijken.

### Worden fallback‑lettertypen toegepast tijdens exporten zoals PDF, PNG of SVG, of alleen bij weergave op het scherm?

Ja. Fallback beïnvloedt alle [renderings‑ en export‑bewerkingen](/slides/nl/androidjava/convert-presentation/) waarbij tekens moeten worden getekend maar afwezig zijn in het bronlettertype.

### Verandert het configureren van fallback het presentatie‑bestand zelf, en blijft de instelling bewaard voor toekomstige openingen?

Nee. Fallback‑regels zijn runtime‑renderingsinstellingen in je code; ze worden niet opgeslagen in de .pptx en verschijnen niet in PowerPoint.

### Heeft het besturingssysteem (Windows/Linux/macOS) en de set van lettertype‑mappen invloed op de fallback‑selectie?

Ja. De engine zoekt lettertypen in beschikbare systeem‑mappen en eventuele [extra paden](/slides/nl/androidjava/custom-font/) die je opgeeft. Als een lettertype fysiek niet beschikbaar is, kan een regel die hiernaar verwijst niet effect hebben.

### Werkt fallback voor WordArt, SmartArt en grafieken?

Ja. Wanneer deze objecten tekst bevatten, wordt hetzelfde glyf‑vervangingsmechanisme toegepast om ontbrekende tekens weer te geven.