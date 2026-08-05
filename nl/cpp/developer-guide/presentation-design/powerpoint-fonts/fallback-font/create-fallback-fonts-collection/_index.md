---
title: Configureer fallback-lettertypecollecties in C++
linktitle: Fallback-lettertypecollectie
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

Nadat u de collectie hebt aangemaakt, kunt u deze toewijzen met de `set_FontFallBackRulesCollection`‑methode van de `FontsManager` van de presentatie. De `FontsManager` beheert lettertypen in de gehele presentatie, en elke `Presentation`‑instantie heeft zijn eigen `FontsManager`.

Zodra de `FontsManager` is geïnitialiseerd met de fallback‑lettertype‑collectie, worden de opgegeven fallback‑lettertypen toegepast tijdens het renderen van de presentatie.

## **Fallback‑regels toepassen**

Instanties van de [FontFallBackRule](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontfallbackrule/) klasse kunnen worden georganiseerd in een [FontFallBackRulesCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontfallbackrulescollection/), die de [IFontFallBackRulesCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ifontfallbackrulescollection/) interface implementeert. Het is mogelijk om regels aan de collectie toe te voegen of te verwijderen.

Vervolgens kan deze collectie worden doorgegeven aan de [set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/)‑methode van de [FontsManager](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsmanager/) klasse. FontsManager beheert lettertypen in de gehele presentatie.

Elke [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) heeft een [get_FontsManager()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_fontsmanager/)‑methode met zijn eigen instantie van de FontsManager‑klasse.

Hier is een voorbeeld hoe u een collectie fallback‑lettertype‑regels kunt maken en toewijzen aan de FontsManager van een bepaalde presentatie:  

``` cpp
auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```

Nadat de FontsManager is geïnitialiseerd met de fallback‑lettertype‑collectie, worden de fallback‑lettertypen toegepast tijdens het renderen van de presentatie.

{{% alert color="primary" %}} 
Lees meer hoe u een [Presentatie renderen met fallback‑lettertype](/slides/nl/cpp/render-presentation-with-fallback-font/) kunt uitvoeren.
{{% /alert %}}

## **FAQ**

**Worden mijn fallback‑regels ingebed in het PPTX‑bestand en zichtbaar in PowerPoint na het opslaan?**

Nee. Fallback‑regels zijn runtime‑renderinstellingen; ze worden niet geserialiseerd naar PPTX en zullen niet verschijnen in de gebruikersinterface van PowerPoint.

**Is fallback van toepassing op tekst in SmartArt, WordArt, grafieken en tabellen?**

Ja. Hetzelfde glyph‑substitutiemechanisme wordt gebruikt voor alle tekst in deze objecten.

**Distribueert Aspose lettertypen met de bibliotheek?**

Nee. U voegt zelf lettertypen toe en gebruikt ze op uw eigen verantwoordelijkheid.

**Kunnen vervanging/substitutie voor ontbrekende lettertypen en fallback voor ontbrekende glyphs samen worden gebruikt?**

Ja. Ze zijn onafhankelijke stappen in dezelfde font‑resolutiepijplijn: eerst bepaalt de engine de beschikbaarheid van lettertypen ([replacement](/slides/nl/cpp/font-replacement/)/[substitution](/slides/nl/cpp/font-substitution/)), daarna vult fallback de hiaten voor ontbrekende glyphs in beschikbare lettertypen.