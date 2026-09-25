---
title: Beheer presentatie-toegankelijkheid in C++
linktitle: Presentatie-toegankelijkheid
type: docs
weight: 30
url: /nl/cpp/presentation-accessibility/
keywords:
- presentatietoegankelijkheid
- alternatieve tekst
- alternatieve tekst titel
- alternatieve tekst beschrijving
- markeer als decoratief
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Automatiseer controles op presentatie-toegankelijkheid in PPT, PPTX en ODP bestanden met Aspose.Slides voor C++ - verbeter de ervaring voor schermlezers en verhoog de naleving."
---
## **Inleiding**

Alternatieve tekst helpt mensen die assistieve technologieën gebruiken om de betekenis van afbeeldingen, grafieken en andere informatieve vormen te begrijpen. Dit artikel legt uit hoe je alternatieve tekst‑titels en beschrijvingen kunt lezen en bijwerken met Aspose.Slides for C++, hoe je toegankelijkheidsbeschrijvingen onderscheidt van vormnamen die in code worden gebruikt, en hoe je controleert of een vorm gemarkeerd is als decoratief.

Deze functies ondersteunen de toegankelijkheid van presentaties, maar garanderen deze niet. Ook moet de leesvolgorde, het kleurcontrast, de leesbaarheid van tekst en andere toegankelijkheidseisen worden beoordeeld.

## **Beheer van alternatieve tekst‑titels en beschrijvingen**

Gebruik alternatieve tekst om de betekenis van afbeeldingen, grafieken en andere informatieve vormen uit te leggen aan mensen die ze niet kunnen zien. De volgende eigenschappen dienen verschillende doelen:

| Eigenschap of inhoud | Doel |
| --- | --- |
| [AlternativeTextTitle](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/get_alternativetexttitle/) | Een korte titel voor de alternatieve beschrijving. |
| [AlternativeText](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/get_alternativetext/) | Een betekenisvolle beschrijving van de inhoud of het doel van de vorm in de context van de dia. |
| [Name](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/get_name/) | De naam van de vorm, die code kan gebruiken om een specifieke vorm in de presentatie te vinden. |
| Zichtbare tekst | Inhoud die op de dia wordt weergegeven, zoals de tekst van een vorm of de titel en labels van een grafiek. Het bijwerken van alternatieve tekst verandert deze inhoud niet. |

Wanneer een presentatie opnieuw wordt gebruikt als sjabloon, kan code een vorm vinden via haar [Name](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/get_name/) vóórdat deze wordt bijgewerkt. Deze naam dient een ander doel dan alternatieve tekst, die uitlegt wat het visuele element communiceert aan de lezer. Zoeken op naam stelt auteurs in staat om beschrijvingen te verbeteren of te vertalen zonder de manier waarop code de vorm vindt te wijzigen. Namen kunnen bewerkt worden en zijn niet gegarandeerd uniek, controleer dus dat de naam overeenkomt met de bedoelde vorm; zie [Identificeer en vind vormen](/slides/nl/cpp/shape-manipulations/#identify-and-find-shapes).

Het volgende voorbeeld vereist `input.pptx` met een afbeelding van een kantoorinlaat als de eerste vorm op de eerste dia. De afbeelding mag niet gemarkeerd zijn als decoratief. Het voorbeeld leest en toont de huidige alternatieve tekst‑titel en beschrijving, werkt beide waarden bij, en slaat de presentatie op als `output.pptx`. Pas de bewoording aan op de feitelijke afbeelding en de informatie die deze overbrengt.

```cpp
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

Console::WriteLine(u"Alternative text title: {0}", shape->get_AlternativeTextTitle());
Console::WriteLine(u"Alternative text description: {0}", shape->get_AlternativeText());

shape->set_AlternativeTextTitle(u"Office entrance");
shape->set_AlternativeText(u"The office entrance has a wheelchair ramp to the right of the steps.");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Alleen alternatieve tekst toevoegen garandeert geen toegankelijke presentatie of naleving van toegankelijkheidsnormen. Controleer de beschrijvingen op juistheid en relevantie, en bekijk ook de leesvolgorde, het kleurcontrast, leesbare tekst en andere toegankelijkheidseisen. Informatieve visuals mogen niet gemarkeerd worden als decoratief; de volgende sectie toont hoe je [IsDecorative](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/get_isdecorative/) kunt lezen.

## **Markeren als decoratief**

Markeren als decoratief geeft puur ornamentale visuals een vlag zodat schermlezers ze overslaan, ruis verminderen en de focus op betekenisvolle inhoud houden. Pas dit toe op achtergronden, versieringen en tussenruimtes — nooit op grafieken, pictogrammen of afbeeldingen die informatie overbrengen. Aspose.Slides maakt deze vlag beschikbaar voor detectie en validatie, waardoor geautomatiseerde toegankelijkheidscontroles en opschoning mogelijk zijn.

![Mark as Decorative](mark_as_decorative.png)

De volgende code‑voorbeeld laat zien hoe je kunt bepalen of een vorm gemarkeerd is als decoratief.

```cpp
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);
Console::WriteLine(u"Is shape decorative: {0}", shape->get_IsDecorative());

presentation->Dispose();
```

## **FAQ**

**Wat moet ik in de alternatieve tekst‑titel en beschrijving opnemen?**

Gebruik een korte titel om het onderwerp te identificeren en een beschrijving om de informatie die het visuele element overbrengt in de context van de dia uit te leggen. Beschrijf voor een grafiek de relevante trend of vergelijking in plaats van alleen “grafiek” te vermelden.

**Moet ik alternatieve tekst gebruiken om vormen in een sjabloon te lokaliseren?**

Geef de voorkeur aan het vinden van de vorm via haar [Name](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/get_name/) en controleer dat het de verwachte vorm is. Alternatieve tekst kan bewerkt of vertaald worden, waardoor code die exact zoekt kan breken; zie [Identificeer en vind vormen](/slides/nl/cpp/shape-manipulations/).

**Wanneer moet een vorm gemarkeerd worden als decoratief?**

Gebruik de decoratieve vlag voor visuals die geen informatie toevoegen, zoals ornamentale versieringen. Afbeeldingen en grafieken die een betekenis overbrengen hebben een passende beschrijving nodig.

**Zorgt het toevoegen van alternatieve tekst voor een volledig toegankelijke presentatie?**

Nee. Alternatieve tekst behandelt slechts een deel van de toegankelijkheid. Controleer ook de leesvolgorde, het kleurcontrast, de leesbaarheid van tekst en andere toepasselijke eisen; alleen het instellen van deze eigenschappen leidt niet tot naleving.