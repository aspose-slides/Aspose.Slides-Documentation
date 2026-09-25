---
title: Hantera presentationstillgänglighet i C++
linktitle: Presentationstillgänglighet
type: docs
weight: 30
url: /sv/cpp/presentation-accessibility/
keywords:
- presentationstillgänglighet
- alternativ text
- alternativ texttitel
- alternativ textbeskrivning
- markera som dekorativ
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Automatisera kontroller av presentationstillgänglighet i PPT-, PPTX- och ODP-filer med Aspose.Slides för C++—förbättra skärmläsarupplevelsen och öka efterlevnaden."
---
## **Introduktion**

Alternativ text hjälper personer som använder hjälpmedel att förstå betydelsen av bilder, diagram och andra informativa former. Den här artikeln förklarar hur man läser och uppdaterar alternativa texttitlar och beskrivningar med Aspose.Slides för C++, skiljer åt tillgänglighetsbeskrivningar från formnamn som används i kod och kontrollerar om en form är markerad som dekorativ.

Dessa funktioner stödjer presentationstillgänglighet, men garanterar den inte. Läseriktning, färgkontrast, textläsbarhet och andra tillgänglighetskrav behöver också granskas.

## **Hantera alternativa texttitlar och beskrivningar**

Använd alternativ text för att förklara betydelsen av bilder, diagram och andra informativa former för personer som inte kan se dem. Följande egenskaper har olika syften:

| Egenskap eller innehåll | Syfte |
| --- | --- |
| [AlternativeTextTitle](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/get_alternativetexttitle/) | En kort titel för den alternativa beskrivningen. |
| [AlternativeText](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/get_alternativetext/) | En meningsfull beskrivning av formens innehåll eller syfte i bildens sammanhang. |
| [Name](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/get_name/) | Formens namn, som kod kan använda för att hitta en specifik form i presentationen. |
| Visible text | Innehåll som visas på bilden, till exempel en forms text eller ett diagramtitel och etiketter. Att uppdatera alternativ text förändrar inte detta innehåll. |

När en presentation återanvänds som en mall kan kod hitta en form via dess [Name](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/get_name/) innan den uppdateras. Detta namn har ett annat syfte än alternativ text, som förklarar vad den visuella delen förmedlar till läsaren. Sökning efter namn gör det möjligt för författare att förbättra eller översätta beskrivningar utan att ändra hur koden hittar formen. Namn kan redigeras och garanteras inte vara unika, så kontrollera att namnet matchar den avsedda formen; se [Identify and Find Shapes](/slides/sv/cpp/shape-manipulations/#identify-and-find-shapes).

Följande exempel kräver `input.pptx` med en bild av ett kontorsentré som den första formen på den första bilden. Bilden bör inte vara markerad som dekorativ. Exemplet läser och skriver ut dess nuvarande alternativa texttitel och beskrivning, uppdaterar båda värdena och sparar presentationen som `output.pptx`. Anpassa formuleringen till den faktiska bilden och den information den förmedlar.

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

Att bara lägga till alternativ text garanterar inte presentationstillgänglighet eller efterlevnad av tillgänglighetsstandarder. Granska beskrivningarna för noggrannhet och relevans, och kontrollera även läseriktning, färgkontrast, läsbar text och andra tillgänglighetskrav. Informativa visuella element bör inte markeras som dekorativa; nästa avsnitt visar hur man läser [IsDecorative](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/get_isdecorative/).

## **Markera som dekorativ**

Markera som dekorativ flaggar rent dekorativa visuella element så att skärmläsare hoppar över dem, vilket minskar brus och håller fokus på meningsfullt innehåll. Använd den för bakgrunder, prydnader och avståndsmarkörer – aldrig för diagram, ikoner eller bilder som förmedlar information. Aspose.Slides exponerar denna flagga för detektering och validering, vilket möjliggör automatiska tillgänglighetskontroller och rensning.

![Mark as Decorative](mark_as_decorative.png)

Följande kodexempel visar hur man avgör om en form är markerad som dekorativ.

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

## **Vanliga frågor**

**Vad bör jag placera i den alternativa texttiteln och beskrivningen?**

Använd en kort titel för att identifiera ämnet och en beskrivning för att förklara den information den visuella delen förmedlar i bildens sammanhang. För ett diagram, beskriv den relevanta trenden eller jämförelsen istället för att bara säga "diagram".

**Bör jag använda alternativ text för att hitta former i en mall?**

Föredra att hitta formen via dess [Name](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/get_name/) och kontrollera att den är den förväntade formen. Alternativ text kan redigeras eller översättas, vilket kan bryta kod som söker efter en exakt beskrivning; se [Identify and Find Shapes](/slides/sv/cpp/shape-manipulations/).

**När bör en form markeras som dekorativ?**

Använd den dekorativa flaggan för visuella element som inte tillför någon information, till exempel ornamentala prydnader. Bilder och diagram som förmedlar mening behöver istället en lämplig beskrivning.

**Gör tillägg av alternativ text en presentation fullt tillgänglig?**

Nej. Alternativ text täcker bara en del av tillgängligheten. Granska också läseriktning, färgkontrast, textläsbarhet och andra tillämpliga krav; att endast sätta dessa egenskaper etablerar inte efterlevnad.