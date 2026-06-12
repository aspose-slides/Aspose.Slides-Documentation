---
title: Configureer fallback-lettertypecollecties in C++
linktitle: Fallback Lettertypecollectie
type: docs
weight: 20
url: /nl/cpp/create-fallback-fonts-collection/
keywords:
- fallback-lettertype
- fallback-regel
- lettertypecollectie
- lettertype configureren
- lettertype instellen
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Stel een fallback-lettertypecollectie in Aspose.Slides voor C++ in om tekst consistent en scherp te houden in PowerPoint- en OpenDocument-presentaties."
---
## **Overzicht**

Aspose.Slides stelt u in staat om een verzameling fallback‑lettertype‑regels voor een presentatie te configureren. Elke fallback‑regel wordt vertegenwoordigd door de `FontFallBackRule`‑klasse en kan worden toegevoegd aan een `FontFallBackRulesCollection`, die de `IFontFallBackRulesCollection`‑interface implementeert.

Nadat de collectie is aangemaakt, kunt u deze toewijzen via de `set_FontFallBackRulesCollection`‑methode van de `FontsManager` van de presentatie. De `FontsManager` beheert lettertypen in de hele presentatie, en elke `Presentation`‑instantie heeft zijn eigen `FontsManager`.

Zodra de `FontsManager` is geïnitialiseerd met de fallback‑lettertypecollectie, worden de opgegeven fallback‑lettertypen toegepast tijdens het renderen van de presentatie.

## **Fallback‑regels toepassen**

Instanties van de [FontFallBackRule](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontfallbackrule/)‑klasse kunnen worden georganiseerd in een [FontFallBackRulesCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontfallbackrulescollection/), die de [IFontFallBackRulesCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ifontfallbackrulescollection/)‑interface implementeert. Het is mogelijk om regels toe te voegen of te verwijderen uit de collectie.

Deze collectie kan vervolgens worden doorgegeven aan de [set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/)‑methode van de [FontsManager](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsmanager/)‑klasse. FontsManager beheert lettertypen in de hele presentatie.

Elke [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) heeft een [get_FontsManager()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_fontsmanager/)‑methode met zijn eigen instantie van de FontsManager‑klasse.

Hier is een voorbeeld van hoe u een verzameling fallback‑lettertype‑regels maakt en toewijst aan de FontsManager van een bepaalde presentatie:  

``` cpp
auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```

Nadat de FontsManager is geïnitialiseerd met de fallback‑lettertypecollectie, worden de fallback‑lettertypen toegepast tijdens het renderen van de presentatie.

{{% alert color="primary" %}} 
Lees meer over hoe u [Presentatie renderen met fallback‑lettertype](/slides/nl/cpp/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Worden mijn fallback‑regels ingebed in het PPTX‑bestand en zichtbaar in PowerPoint na het opslaan?**

Nee. Fallback‑regels zijn runtime‑renderingsinstellingen; ze worden niet geserialiseerd naar PPTX en verschijnen niet in de gebruikersinterface van PowerPoint.

**Wordt fallback toegepast op tekst in SmartArt, WordArt, grafieken en tabellen?**

Ja. Hetzelfde glyf‑substitutiemechanisme wordt gebruikt voor alle tekst in deze objecten.

**Distribueert Aspose lettertypen met de bibliotheek?**

Nee. U voegt zelf lettertypen toe en gebruikt ze onder uw eigen verantwoordelijkheid.

**Kunnen vervanging/substitutie voor ontbrekende lettertypen en fallback voor ontbrekende glyfen samen worden gebruikt?**

Ja. Het zijn onafhankelijke fases van dezelfde lettertype‑resolutiepijplijn: eerst lost de engine de beschikbaarheid van lettertypen op ([vervanging](/slides/nl/cpp/font-replacement/)/[substitutie](/slides/nl/cpp/font-substitution/)), daarna vult fallback de gaten voor ontbrekende glyfen in beschikbare lettertypen.