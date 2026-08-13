---
title: Konvertera presentationer till HTML5 i .NET
linktitle: Presentation till HTML5
type: docs
weight: 40
url: /sv/net/export-to-html5/
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
- .NET
- C#
- Aspose.Slides
description: "Exportera PowerPoint- och OpenDocument-presentationer till responsiv HTML5 med Aspose.Slides för .NET. Bevara formatering, animationer och interaktivitet."
---
## **Översikt**

Den här artikeln förklarar hur man konverterar PowerPoint‑presentationer till HTML5 med Aspose.Slides. Den täcker grundläggande HTML5‑export, samt alternativ för att styra formanimationer och bildövergångar. Artikeln visar också den standardiserade PowerPoint‑till‑HTML‑exportprocessen, förklarar hur man genererar HTML5‑utdata i bildvyerläge, och demonstrerar hur man inkluderar kommentarer i det exporterade dokumentet genom att konfigurera deras layout.

## **Exportera PowerPoint till HTML5**

Den här C#‑koden visar hur man exporterar en presentation till HTML5:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html5);
}
```

{{% alert color="info" %}} 

Förutom HTML‑dokumentet skriver exporten de stödjande filer som den refererar till: `pres.css`, `master.css`, `animation.js`, `effects.js` och `navigation.js`. Den genererade sidan laddar också jQuery och Anime.js från offentliga CDN‑er; utan dem fungerar inte bildnavigering och animationer. 

{{% /alert %}}

Du kan ange inställningar för formanimationer och bildövergångar på följande sätt:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres5.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = false,
       AnimateTransitions = false
   });
}
```

## **Exportera PowerPoint till HTML**

Den här C#‑koden demonstrerar den standardiserade PowerPoint‑till‑HTML‑processen:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html);
}
```

I detta fall renderas presentationsinnehållet via SVG i ett format som detta:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Obs" color="warning" %}} 

När du använder den här metoden för att exportera PowerPoint till HTML, på grund av SVG‑renderingen, kommer du inte att kunna tillämpa stilar eller animera specifika element. 

{{% /alert %}}

## **Exportera PowerPoint till HTML5‑bildvy**

**Aspose.Slides** gör det möjligt att konvertera en PowerPoint‑presentation till ett HTML5‑dokument där bilderna visas i bildvyerläge. I detta fall, när du öppnar den resulterande HTML5‑filen i en webbläsare, visas presentationen i bildvyerläge på en webbsida. 

Den här C#‑koden demonstrerar exportprocessen för PowerPoint till HTML5‑bildvy:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("HTML5-slide-view.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = true,
       AnimateTransitions = true
   });
}
```

## **Konvertera en presentation till ett HTML5‑dokument med kommentarer**

Kommentarer i PowerPoint är ett verktyg som låter användare lämna noteringar eller återkoppling på presentationsbilder. De är särskilt användbara i samarbeten, där flera personer kan lägga till sina förslag eller anmärkningar på specifika bildelement utan att ändra huvudinnehållet. Varje kommentar visar författarens namn, vilket gör det enkelt att spåra vem som skrev anmärkningen.

Låt oss säga att vi har följande PowerPoint‑presentation sparad i filen "sample.pptx".

![Två kommentarer på presentationsbilden](two_comments_pptx.png)

När du konverterar en PowerPoint‑presentation till ett HTML5‑dokument kan du enkelt ange om kommentarer från presentationen ska inkluderas i utdatasdokumentet. För att göra detta måste du ange visningsparametrarna för kommentarer i egenskapen `NotesCommentsLayouting` i klassen [Html5Options](https://reference.aspose.com/slides/sv/net/aspose.slides.export/html5options/) .

Följande kodexempel konverterar en presentation till ett HTML5‑dokument med kommentarer som visas till höger om bilderna.
```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        CommentsPosition = CommentsPositions.Right
    }
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```

Det resulterande "output.html"-dokumentet visas i bilden nedan.

![Kommentarfälten i det exporterade HTML5‑dokumentet](two_comments_html5.png)

## **FAQ**

### Kan jag styra om objektanimationer och bildövergångar ska spelas upp i HTML5?

Ja, HTML5 erbjuder separata alternativ för att aktivera eller inaktivera [formanimationer](https://reference.aspose.com/slides/sv/net/aspose.slides.export/html5options/animateshapes/) och [bildövergångar](https://reference.aspose.com/slides/sv/net/aspose.slides.export/html5options/animatetransitions/).

### Stöds export av kommentarer, och var kan de placeras i förhållande till bilden?

Ja, kommentarer kan läggas till i HTML5 och positioneras (t.ex. till höger om bilden) via [layoutinställningar](https://reference.aspose.com/slides/sv/net/aspose.slides.export/html5options/notescommentslayouting/) för anteckningar och kommentarer.

### Kan jag hoppa över länkar som anropar JavaScript av säkerhets- eller CSP‑skäl?

Ja, det finns en [inställning](https://reference.aspose.com/slides/sv/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) som låter dig hoppa över hyperlänkar med JavaScript‑anrop vid sparande. Detta hjälper till att följa strikta säkerhetspolicyer.