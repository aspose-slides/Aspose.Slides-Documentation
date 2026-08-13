---
title: Konvertera presentationer till HTML5 i C++
linktitle: Presentation till HTML5
type: docs
weight: 40
url: /sv/cpp/export-to-html5/
keywords:
- PowerPoint till HTML5
- OpenDocument till HTML5
- presentation till HTML5
- bild till HTML5
- PPT till HTML5
- PPTX till HTML5
- ODP till HTML5
- spara PPT som HTML5
- spara PPTX som HTML5
- spara ODP som HTML5
- exportera PPT till HTML5
- exportera PPTX till HTML5
- exportera ODP till HTML5
- C++
- Aspose.Slides
description: "Exportera PowerPoint- och OpenDocument-presentationer till responsiv HTML5 med Aspose.Slides för C++. Bevara formatering, animationer och interaktivitet."
---
## **Översikt**

Den här artikeln förklarar hur du konverterar PowerPoint-presentationer till HTML5 med Aspose.Slides. Den täcker grundläggande HTML5‑export utan webb‑tillägg eller extra beroenden, samt alternativ för att styra formanimationer och bildövergångar. Artikeln visar också den vanliga PowerPoint‑till‑HTML‑exportprocessen, förklarar hur du genererar HTML5‑utdata i bildvisningsläge och demonstrerar hur du inkluderar kommentarer i det exporterade dokumentet genom att konfigurera deras layout.

## **Exportera PowerPoint till HTML5**

Denna C++‑kod visar hur du exporterar en presentation till HTML5.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html5);
```

{{% alert color="info" %}} 
I det här fallet får du ren HTML. 
{{% /alert %}}

Du kan ange inställningar för formanimationer och bildövergångar på följande sätt:

```cpp
#include <DOM/Presentation.h>
#include <Export/Html5Options.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto options = System::MakeObject<Html5Options>();
options->set_AnimateShapes(true);
options->set_AnimateTransitions(true);
pres->Save(u"pres.html", SaveFormat::Html5, options);
```

## **Exportera PowerPoint till HTML**

Denna C++‑kod demonstrerar den standardmässiga PowerPoint‑till‑HTML‑processen:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html);
```

I detta fall renderas presentationsinnehållet genom SVG på ett format som detta:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Note" color="warning" %}} 
När du använder den här metoden för att exportera PowerPoint till HTML, på grund av SVG‑renderingen kommer du inte kunna applicera stilar eller animera specifika element. 
{{% /alert %}}

## **Exportera PowerPoint till HTML5 Bildvisning**

**Aspose.Slides** låter dig konvertera en PowerPoint-presentation till ett HTML5‑dokument där bilderna visas i bildvisningsläge. I detta fall, när du öppnar den resulterande HTML5‑filen i en webbläsare, ser du presentationen i bildvisningsläge på en webbsida. 

Denna C++‑kod demonstrerar PowerPoint‑till‑HTML5‑Bildvisning‑exportprocessen:

```c++
#include <DOM/Presentation.h>
#include <Export/Html5Options.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);
pres->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
```

## **Konvertera en presentation till ett HTML5‑dokument med kommentarer**

Kommentarer i PowerPoint är ett verktyg som låter användare lämna anteckningar eller återkoppling på presentationsbilder. De är särskilt användbara i samarbeten där flera personer kan lägga till sina förslag eller anmärkningar på specifika bild‑element utan att ändra huvudinnehållet. Varje kommentar visar författarens namn, vilket gör det enkelt att följa vem som gjort anmärkningen.

Låt oss säga att vi har följande PowerPoint‑presentation sparad i filen "sample.pptx".

![Two comments on the presentation slide](two_comments_pptx.png)

När du konverterar en PowerPoint‑presentation till ett HTML5‑dokument kan du enkelt ange om kommentarer från presentationen ska inkluderas i utskriftsdokumentet. För att göra detta måste du ange visningsparametrarna för kommentarer i `get_NotesCommentsLayouting`‑metoden i klassen [Html5Options](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/html5options/).

Följande kodexempel konverterar en presentation till ett HTML5‑dokument med kommentarer som visas till höger om bilderna.
```cpp
#include <DOM/Presentation.h>
#include <Export/CommentsPositions.h>
#include <Export/Html5Options.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto layoutingOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutingOptions->set_CommentsPosition(CommentsPositions::Right);

auto html5Options = MakeObject<Html5Options>();
html5Options->set_SlidesLayoutOptions(layoutingOptions);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

Dokumentet "output.html" visas i bilden nedan.

![The comments in the output HTML5 document](two_comments_html5.png)

## **FAQ**

### Kan jag styra om objektanimationer och bildövergångar spelas upp i HTML5?

Ja, HTML5 erbjuder separata alternativ för att aktivera eller inaktivera [shape animations](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/html5options/set_animateshapes/) och [slide transitions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/html5options/set_animatetransitions/).

### Stöds utdata av kommentarer, och var kan de placeras i förhållande till bilden?

Ja, kommentarer kan läggas till i HTML5 och placeras (t.ex. till höger om bilden) genom layoutinställningar för anteckningar och kommentarer.

### Kan jag hoppa över länkar som anropar JavaScript av säkerhets‑ eller CSP‑skäl?

Ja, det finns en [setting](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) som låter dig hoppa över hyperlänkar med JavaScript‑anrop under sparande. Detta hjälper till att följa strikta säkerhetspolicyer.