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

Den här artikeln förklarar hur du konverterar PowerPoint‑presentationer till HTML5 med Aspose.Slides för C++. Den täcker grundläggande export, kontroll av formanimationer och bildövergångar samt kommentarslayout. Den jämför också HTML5‑utdata med den SVG‑baserade utexporten från standard‑HTML‑export.

## **Exportera PowerPoint till HTML5**

Följande exempel läser in en presentation från arbetskatalogen och sparar den i HTML5‑format. Det använder standardinställningarna för export; nästa exempel visar hur du explicit styr animeringsuppspelning. Ersätt inmatningssökvägen med sökvägen till din presentation.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"pres.html", SaveFormat::Html5);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Förutom HTML‑dokumentet skriver exporten ut stödjande CSS‑ och JavaScript‑filer för bildstil, animationer, effekter och navigering. Behåll dessa filer tillsammans med HTML‑dokumentet när du flyttar eller publicerar resultatet. Den genererade sidan laddar också jQuery och Anime.js från offentliga CDN:er; utan dem fungerar inte bildnavigering och animationer.
{{% /alert %}}

För att exportera utan att spela upp formanimationer eller bildövergångar, skicka `false` till [set_AnimateShapes](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) och [set_AnimateTransitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/) i [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/). Dessa inställningar är oberoende, så du kan aktivera den ena och inaktivera den andra. Exemplet exporterar presentationen med båda typerna av animation inaktiverade i den genererade sidan.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(false);
html5Options->set_AnimateTransitions(false);

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"pres5.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

## **Exportera PowerPoint till HTML**

Den standardmässiga HTML‑exporten använder en annan renderingsmetod: bildinnehållet representeras av SVG i en HTML‑sida. Följande exempel konverterar en presentation till ett HTML‑dokument med denna renderingsmetod.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"pres.html", SaveFormat::Html);
presentation->Dispose();
```

Den förenklade markupen nedan illustrerar strukturen för den genererade sidan. SVG‑elementet innehåller den renderade bildinnehållet; platshållartexten representerar detta innehåll och är inte en faktisk exportutdata.

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Warning" color="warning" %}}
Den SVG‑baserade exporten exponerar inte PowerPoint‑former som individuella HTML‑element. Använd HTML5‑export när du behöver de form‑animationer och bild‑övergångsalternativ som demonstreras i den här artikeln.
{{% /alert %}}

## **Exportera PowerPoint till HTML5‑bildvisning**

HTML5‑export skapar en sida för att visa och navigera presentationens bilder i en webbläsare. Detta exempel skickar `true` till både [set_AnimateShapes](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) och [set_AnimateTransitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/) så att den exporterade bildvyn kan spela upp effekter från källpresentationen.

Använd en presentation som redan innehåller formanimationer och bildövergångar för att se effekten av dessa inställningar. Att aktivera dem lägger inte till nya effekter på bilder som saknar dem. Efter export, öppna det genererade HTML5‑dokumentet i en webbläsare med dess stödjande filer tillgängliga.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

## **Konvertera en presentation till ett HTML5‑dokument med kommentarer**

Du kan inkludera befintliga bildkommentarer i HTML5‑utdata så att läsare kan se återkoppling tillsammans med bildens innehåll. Exemplet i detta avsnitt förväntar sig att källpresentationen innehåller kommentarer, som illustrerat nedan. Det exporterar dessa kommentarer; det skapar inga nya.

![Två kommentarer på presentationsbilden](two_comments_pptx.png)

Skicka ett [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/)‑objekt till metoden [set_SlidesLayoutOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_slideslayoutoptions/) i [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/). Anropa [set_CommentsPosition](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/set_commentsposition/) med `CommentsPositions::Right` från uppräkningen [CommentsPositions](https://reference.aspose.com/slides/cpp/aspose.slides.export/commentspositions/) för att placera kommentarer till höger om varje bild.

Följande exempel exporterar presentationen till HTML5 med denna kommentarslayout. En presentation utan kommentarer kommer inte att ha någon kommentartext att visa.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/CommentsPositions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto layoutOptions = System::MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_CommentsPosition(CommentsPositions::Right);

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_SlidesLayoutOptions(layoutOptions);

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

Bilden nedan visar det exporterade HTML5‑dokumentet med kommentarerna visade bredvid bilden.

![Kommentarerna i den exporterade HTML5‑dokumentet](two_comments_html5.png)

## **Uteslut JavaScript‑hyperlänkar vid export**

Anta att `hyperlinks.pptx` innehåller länkad text med ett `javascript:alert('Hello')`‑mål och en vanlig `https://example.com/`‑länk. För att utesluta JavaScript‑hyperlänken vid export, anropa [SaveOptions::set_SkipJavaScriptLinks](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) med `true`. Standardvärdet är `false`, så dessa länkar filtreras inte förrän du aktiverar alternativet.

Följande exempel läser in presentationen från arbetskatalogen och exporterar den med [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/):

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_SkipJavaScriptLinks(true);

auto presentation = System::MakeObject<Presentation>(u"hyperlinks.pptx");
presentation->Save(u"filtered-html5.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

Den exporterade filen utesluter JavaScript‑hyperlänken samtidigt som dess text och den vanliga HTTPS‑länken behålls. Källpresentationen förblir oförändrad.

Detta alternativ filtrerar JavaScript‑hyperlänkar; det tar inte bort alla skript eller annat aktivt innehåll, och det garanterar inte CSP‑efterlevnad. Till exempel innehåller HTML5‑utdata fortfarande skript för bildnavigering och animationer.

## **FAQ**

**Kan jag styra om objektanimationer och bildövergångar spelas upp i HTML5?**

Ja, HTML5‑exporten erbjuder separata alternativ för att aktivera eller inaktivera [formanimationer](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) och [bildövergångar](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/).

**Stöds kommentarer, och var kan de placeras i förhållande till bilden?**

Ja, befintliga kommentarer kan inkluderas i HTML5‑utdata och placeras (till exempel till höger om bilden) via [layoutinställningar](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_slideslayoutoptions/) för anteckningar och kommentarer.

**Kan jag hoppa över länkar som anropar JavaScript av säkerhets‑ eller CSP‑skäl?**

Ja, metoden [set_SkipJavaScriptLinks](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) låter dig hoppa över hyperlänkar med JavaScript‑anrop under sparande. Standardvärdet är `false`. Se [Uteslut JavaScript‑hyperlänkar vid export](/slides/sv/cpp/export-to-html5/#exclude-javascript-hyperlinks-during-export) för ett HTML5‑exportexempel och filterns omfattning. Denna inställning tar inte bort JavaScript som används av HTML5‑visaren för navigering och animationer.