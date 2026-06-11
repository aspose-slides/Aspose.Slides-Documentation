---
title: "Konvertera presentationer till HTML5 i Python"
linktitle: "Exportera till HTML5"
type: docs
weight: 40
url: /sv/python-net/export-to-html5/
keywords:
- PowerPoint till HTML5
- OpenDocument till HTML5
- presentation till HTML5
- bild till HTML5
- PPT till HTML5
- PPTX till HTML5
- ODP till HTML5
- konvertera PowerPoint
- konvertera OpenDocument
- konvertera presentation
- konvertera bild
- HTML5-export
- exportera presentation
- exportera bild
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Exportera PowerPoint- och OpenDocument-presentationer till responsiv HTML5 med Aspose.Slides för Python via .NET. Bevara formatering, animationer och interaktivitet."
---
## **Översikt**

Den här artikeln förklarar hur du konverterar PowerPoint-presentationer till HTML5 med Aspose.Slides. Den täcker grundläggande HTML5-export utan webbläsartillägg eller extra beroenden, samt alternativ för att styra formanimationer och bildövergångar. Artikeln visar också den standardiserade PowerPoint‑till‑HTML‑exportprocessen, förklarar hur du genererar HTML5‑utdata i bildvyläge och demonstrerar hur du inkluderar kommentarer i det exporterade dokumentet genom att konfigurera deras layout.

## **Exportera PowerPoint till HTML5**

Den här Python‑koden visar hur du exporterar en presentation till HTML5 utan webbläsartillägg och beroenden:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML5)
```

{{% alert color="primary" %}} 
I det här fallet får du ren HTML. 
{{% /alert %}}

Du kanske vill ange inställningarna för formanimationer och bildövergångar på detta sätt:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    options = slides.export.Html5Options()
    options.animate_shapes = False
    options.animate_transitions = False

    presentation.save("index.html", slides.export.SaveFormat.HTML5, options)
```

## **Exportera PowerPoint till HTML**

Den här Python‑koden demonstrerar den standardiserade PowerPoint‑till‑HTML‑processen:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML)
```

I det här fallet renderas presentationsinnehållet via SVG i en form som denna:

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
När du använder denna metod för att exportera PowerPoint till HTML, på grund av SVG‑renderingen, kommer du inte kunna tillämpa stilar eller animera specifika element. 
{{% /alert %}}

## **Exportera PowerPoint till HTML5‑bildvy**

**Aspose.Slides** låter dig konvertera en PowerPoint-presentation till ett HTML5‑dokument där bilderna visas i bildvyläge. I det här fallet, när du öppnar den resulterande HTML5‑filen i en webbläsare, ser du presentationen i bildvyläge på en webbsida. 

Den här Python‑koden demonstrerar exportprocessen för PowerPoint till HTML5‑bildvy:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    # Exportera en presentation som innehåller bildövergångar, animationer och formanimationer till HTML5
    options = slides.export.Html5Options()
    options.animate_shapes = True
    options.animate_transitions = True

    # Spara presentation
    pres.save("HTML5-slide-view.html", slides.export.SaveFormat.HTML5, options)
```

## **Konvertera en presentation till ett HTML5‑dokument med kommentarer**

Kommentarer i PowerPoint är ett verktyg som låter användare lämna anteckningar eller återkoppling på presentationsbilder. De är särskilt användbara i samarbeten, där flera personer kan lägga till sina förslag eller anmärkningar till specifika bildelement utan att ändra huvudinnehållet. Varje kommentar visar författarens namn, vilket gör det enkelt att följa vem som skrev anmärkningen.

Låt oss säga att vi har följande PowerPoint-presentation sparad i filen "sample.pptx".

![Två kommentarer på presentationsbilden](two_comments_pptx.png)

När du konverterar en PowerPoint-presentation till ett HTML5‑dokument kan du enkelt ange om kommentarer från presentationen ska inkluderas i utdokumentet. För att göra detta måste du ange visningsparametrarna för kommentarer i egenskapen `notes_comments_layouting` i klassen [Html5Options](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/html5options/).

Följande kodexempel konverterar en presentation till ett HTML5‑dokument med kommentarer placerade till höger om bilderna.
```py
html5_options = Html5Options()
html5_options.notes_comments_layouting.comments_position = CommentsPositions.RIGHT

with Presentation("sample.pptx") as presentation:
    presentation.save("output.html", SaveFormat.HTML5, html5_options)
```

Dokumentet "output.html" visas i bilden nedan.

![Kommentarerna i det exporterade HTML5‑dokumentet](two_comments_html5.png)

## **Vanliga frågor**

**Kan jag kontrollera om objektanimationer och bildövergångar spelas upp i HTML5?**

Ja, HTML5 erbjuder separata alternativ för att aktivera eller inaktivera [shape animations](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/html5options/animate_shapes/) och [slide transitions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/html5options/animate_transitions/).

**Stöds export av kommentarer, och var kan de placeras i förhållande till bilden?**

Ja, kommentarer kan läggas till i HTML5 och placeras (till exempel till höger om bilden) via [layout settings](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/html5options/notes_comments_layouting/) för anteckningar och kommentarer.

**Kan jag hoppa över länkar som anropar JavaScript av säkerhets- eller CSP‑skäl?**

Ja, det finns en [setting](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/html5options/skip_java_script_links/) som låter dig hoppa över hyperlänkar med JavaScript‑anrop under sparning. Detta hjälper till att följa strikta säkerhetspolicyer.