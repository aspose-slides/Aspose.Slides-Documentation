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

Met Aspose.Slides kunt u een collectie fallback‑lettertype‑regels voor een presentatie configureren. Elke fallback‑regel wordt weergegeven door de `FontFallBackRule`‑klasse en kan worden toegevoegd aan een `FontFallBackRulesCollection`, die de `IFontFallBackRulesCollection`‑interface implementeert.

Nadat u de collectie heeft aangemaakt, kunt u deze toewijzen via de `set_FontFallBackRulesCollection`‑methode van de `FontsManager` van de presentatie. De `FontsManager` beheert lettertypen in de gehele presentatie, en elke `Presentation`‑instantie heeft zijn eigen `FontsManager`.

Zodra de `FontsManager` is geïnitialiseerd met de fallback‑lettertype‑collectie, worden de opgegeven fallback‑lettertypen toegepast tijdens het renderen van de presentatie.

## **Toepassen van fallback‑regels**

Instanties van de [FontFallBackRule](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontfallbackrule/)‑klasse kunnen worden georganiseerd in een [FontFallBackRulesCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontfallbackrulescollection/), die de [IFontFallBackRulesCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ifontfallbackrulescollection/)‑interface implementeert. Het is mogelijk om regels toe te voegen aan of te verwijderen uit de collectie.

Vervolgens kan deze collectie worden doorgegeven aan de [set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/)‑methode van de [FontsManager](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsmanager/)‑klasse. FontsManager beheert lettertypen in de gehele presentatie.

Elke [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) heeft een [get_FontsManager()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_fontsmanager/)‑methode met zijn eigen instantie van de FontsManager‑klasse.

Hier volgt een voorbeeld hoe u een collectie fallback‑lettertype‑regels maakt en deze toewijst aan de FontsManager van een bepaalde presentatie:  

``` cpp
#include <DOM/Fonts/FontFallBackRule.h>
#include <DOM/Fonts/FontFallBackRulesCollection.h>
#include <DOM/IFontFallBackRule.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```

Nadat de FontsManager is geïnitialiseerd met de fallback‑lettertype‑collectie, worden de fallback‑lettertypen toegepast tijdens het renderen van de presentatie.

{{% alert color="info" %}} 
Lees meer over hoe u [Presentatie renderen met fallback‑lettertype](/slides/nl/cpp/render-presentation-with-fallback-font/) kunt.
{{% /alert %}}

## **FAQ**

### Worden mijn fallback‑regels ingebed in het PPTX‑bestand en zichtbaar in PowerPoint na het opslaan?

Nee. Fallback‑regels zijn runtime‑renderinstellingen; ze worden niet geserialiseerd in het PPTX‑bestand en verschijnen niet in de gebruikersinterface van PowerPoint.

### Wordt fallback toegepast op tekst in SmartArt, WordArt, grafieken en tabellen?

Ja. Hetzelfde glyph‑substitutiemechanisme wordt gebruikt voor alle tekst in deze objecten.

### Levert Aspose lettertypen mee met de bibliotheek?

Nee. U voegt lettertypen toe en gebruikt ze zelf, onder uw eigen verantwoordelijkheid.

### Kunnen vervanging/substitutie voor ontbrekende lettertypen en fallback voor ontbrekende glyphs samen worden gebruikt?

Ja. Het zijn onafhankelijke fasen van dezelfde lettertype‑resolutie‑pipeline: eerst bepaalt de engine de beschikbaarheid van lettertypen ([vervanging](/slides/nl/cpp/font-replacement/)/[substitutie](/slides/nl/cpp/font-substitution/)), vervolgens vult fallback de leemtes voor ontbrekende glyphs in beschikbare lettertypen.