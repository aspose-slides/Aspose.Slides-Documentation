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

Den här artikeln förklarar hur man konverterar PowerPoint-presentationer till HTML5 med Aspose.Slides. Den täcker grundläggande HTML5-export utan webbläsartillägg eller ytterligare beroenden, samt alternativ för att styra formernas animationer och bildövergångar. Artikeln visar också den standardiserade PowerPoint‑till‑HTML-exportprocessen, förklarar hur man genererar HTML5‑utdata i bildvisningsläge och demonstrerar hur man inkluderar kommentarer i det exporterade dokumentet genom att konfigurera deras layout.

## **Exportera PowerPoint till HTML5**

Den här C#-koden visar hur du exporterar en presentation till HTML5 utan webbläsartillägg och beroenden:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html5);
}
```

{{% alert color="primary" %}} 
I det här fallet får du ren HTML. 
{{% /alert %}}

Du kanske vill ange inställningar för formernas animationer och bildövergångar på detta sätt:

```c#
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

Denna C#-kod demonstrerar den standardiserade PowerPoint‑till‑HTML‑processen:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html);
}
```

I det här fallet renderas presentationsinnehållet via SVG på följande sätt:

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
När du använder denna metod för att exportera PowerPoint till HTML, på grund av SVG-renderingen, kommer du inte att kunna applicera stilar eller animera specifika element. 
{{% /alert %}}

## **Exportera PowerPoint till HTML5 bildvisning**

**Aspose.Slides** gör att du kan konvertera en PowerPoint-presentation till ett HTML5-dokument där bilderna visas i bildvisningsläge. I det här fallet, när du öppnar den resulterande HTML5-filen i en webbläsare, ser du presentationen i bildvisningsläge på en webbsida. 

Denna C#-kod demonstrerar exportprocessen för PowerPoint till HTML5‑bildvisning:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("HTML5-slide-view.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = true,
       AnimateTransitions = true
   });
}
```

## **Konvertera en presentation till ett HTML5-dokument med kommentarer**

Kommentarer i PowerPoint är ett verktyg som låter användare lämna anteckningar eller återkoppling på presentationsbilder. De är särskilt användbara i samarbeten, där flera personer kan lägga till sina förslag eller anmärkningar på specifika bildelement utan att ändra huvudinnehållet. Varje kommentar visar författarens namn, vilket gör det enkelt att följa vem som lämnade anmärkningen.

Låt oss säga att vi har följande PowerPoint-presentation sparad i filen "sample.pptx".

![Två kommentarer på presentationsbilden](two_comments_pptx.png)

När du konverterar en PowerPoint-presentation till ett HTML5-dokument kan du enkelt ange om kommentarer från presentationen ska inkluderas i utskriftsdokumentet. För att göra detta måste du specificera visningsparametrarna för kommentarer i egenskapen `NotesCommentsLayouting` i klassen [Html5Options](https://reference.aspose.com/slides/sv/net/aspose.slides.export/html5options/).

Följande kodexempel konverterar en presentation till ett HTML5-dokument med kommentarer placerade till höger om bilderna.
```cs
var html5Options = new Html5Options
{
    NotesCommentsLayouting =
    {
        CommentsPosition = CommentsPositions.Right
    }
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```

"output.html"-dokumentet visas på bilden nedan.

![Kommentarerna i det exporterade HTML5-dokumentet](two_comments_html5.png)

## **FAQ**

**Kan jag kontrollera om objektanimationer och bildövergångar spelas upp i HTML5?**

Ja, HTML5 erbjuder separata alternativ för att aktivera eller inaktivera [formanimationer](https://reference.aspose.com/slides/sv/net/aspose.slides.export/html5options/animateshapes/) och [bildövergångar](https://reference.aspose.com/slides/sv/net/aspose.slides.export/html5options/animatetransitions/).

**Stöds kommentarer i utdata, och var kan de placeras i förhållande till bilden?**

Ja, kommentarer kan läggas till i HTML5 och placeras (t.ex. till höger om bilden) via [layoutinställningar](https://reference.aspose.com/slides/sv/net/aspose.slides.export/html5options/notescommentslayouting/) för anteckningar och kommentarer.

**Kan jag hoppa över länkar som anropar JavaScript av säkerhets- eller CSP-anledningar?**

Ja, det finns en [inställning](https://reference.aspose.com/slides/sv/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) som låter dig hoppa över hyperlänkar med JavaScript-anrop vid sparning. Detta hjälper till att följa strikta säkerhetspolicyer.