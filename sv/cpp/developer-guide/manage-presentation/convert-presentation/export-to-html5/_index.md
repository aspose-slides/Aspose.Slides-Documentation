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

Denna artikel förklarar hur du konverterar PowerPoint-presentationer till HTML5 med Aspose.Slides. Den täcker grundläggande HTML5-export utan webb‑tillägg eller extra beroenden, samt alternativ för att styra form‑animationer och bildövergångar. Artikeln visar också den vanliga PowerPoint‑till‑HTML‑exportprocessen, beskriver hur du genererar HTML5‑utdata i bildvysläge och demonstrerar hur du inkluderar kommentarer i den exporterade dokumentet genom att konfigurera deras layout.

## **Exportera PowerPoint till HTML5**

Den här C++‑koden visar hur du exporterar en presentation till HTML5.

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html5);
```

{{% alert color="primary" %}} 
I detta fall får du ren HTML. 
{{% /alert %}}

Du kan ange inställningar för form‑animationer och bildövergångar på följande sätt:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto options = System::MakeObject<Html5Options>();
options->set_AnimateShapes(true);
options->set_AnimateTransitions(true);
pres->Save(u"pres.html", SaveFormat::Html5, options);
```

## **Exportera PowerPoint till HTML**

Den här C++‑koden demonstrerar den standardiserade PowerPoint‑till‑HTML‑processen:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html);
```

I detta fall renderas presentationsinnehållet genom SVG i en form som denna:

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
När du använder denna metod för att exportera PowerPoint till HTML, på grund av SVG‑renderingen, kommer du inte att kunna tillämpa stilar eller animera specifika element. 
{{% /alert %}}

## **Exportera PowerPoint till HTML5 Bildvysläge**

**Aspose.Slides** låter dig konvertera en PowerPoint-presentation till ett HTML5‑dokument där bilderna visas i bildvysläge. I det här fallet, när du öppnar den resulterande HTML5‑filen i en webbläsare, ser du presentationen i bildvysläge på en webbsida. 

Den här C++‑koden demonstrerar exportprocessen för PowerPoint till HTML5 bildvysläge:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);
pres->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
```

## **Konvertera en presentation till ett HTML5‑dokument med kommentarer**

Kommentarer i PowerPoint är ett verktyg som låter användare lämna anteckningar eller feedback på presentationsbilder. De är särskilt användbara i samarbetsprojekt, där flera personer kan lägga till förslag eller anmärkningar till specifika bildelement utan att ändra huvudinnehållet. Varje kommentar visar författarens namn, vilket gör det enkelt att följa vem som gjort anmärkningen.

Anta att vi har följande PowerPoint-presentation sparad i filen **"sample.pptx"**.

![Two comments on the presentation slide](two_comments_pptx.png)

När du konverterar en PowerPoint-presentation till ett HTML5‑dokument kan du enkelt ange om kommentarer från presentationen ska inkluderas i utdokumentet. För att göra det måste du ange display‑parametrarna för kommentarer i metoden `get_NotesCommentsLayouting` i klassen [Html5Options](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/html5options/).

Följande kodexempel konverterar en presentation till ett HTML5‑dokument med kommentarer placerade till höger om bilderna.
```cpp
auto html5Options = MakeObject<Html5Options>();
html5Options->get_NotesCommentsLayouting()->set_CommentsPosition(CommentsPositions::Right);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

Dokumentet **"output.html"** visas i bilden nedan.

![The comments in the output HTML5 document](two_comments_html5.png)

## **FAQ**

**Kan jag styra om objekt‑animationer och bild‑övergångar ska spelas upp i HTML5?**

Ja, HTML5 erbjuder separata alternativ för att aktivera eller inaktivera [shape animations](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/html5options/set_animateshapes/) och [slide transitions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/html5options/set_animatetransitions/).

**Stöds export av kommentarer, och var kan de placeras i förhållande till bilden?**

Ja, kommentarer kan läggas till i HTML5 och placeras (t.ex. till höger om bilden) via layoutinställningar för anteckningar och kommentarer.

**Kan jag hoppa över länkar som anropar JavaScript av säkerhets‑ eller CSP‑skäl?**

Ja, det finns en [setting](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) som låter dig hoppa över hyperlänkar med JavaScript‑anrop vid sparande. Detta hjälper till att följa strikta säkerhetspolicyer.