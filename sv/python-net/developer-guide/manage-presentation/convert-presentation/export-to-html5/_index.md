---
title: Konvertera presentationer till HTML5 i Python
linktitle: Presentation till HTML5
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
- spara PPT som HTML5
- spara PPTX som HTML5
- spara ODP som HTML5
- exportera PPT till HTML5
- exportera PPTX till HTML5
- exportera ODP till HTML5
- Python
- Aspose.Slides
description: "Exportera PowerPoint- och OpenDocument-presentationer till responsiv HTML5 med Aspose.Slides för Python via .NET. Bevara formatering, animationer och interaktivitet."
---
## **Översikt**

Den här artikeln förklarar hur du konverterar PowerPoint-presentationer till HTML5 med Aspose.Slides för Python via .NET. Den täcker grundläggande export, styrning av formanimationer och bildövergångar samt kommentarslayout. Den jämför också HTML5-utdata med den SVG-baserade utdata från standard‑HTML‑export.

## **Exportera PowerPoint till HTML5**

Följande exempel laddar en presentation från arbetskatalogen och sparar den i HTML5-format. Det använder standardexportinställningarna; nästa exempel visar hur du styr uppspelning av animationer explicit. Ersätt inmatningssökvägen med sökvägen till din presentation.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres.html", slides.export.SaveFormat.HTML5)
```

{{% alert color="info" title="Note" %}}
Förutom HTML‑dokumentet skriver exporten stödfiler för CSS och JavaScript för bildstil, animationer, effekter och navigering. Behåll dessa filer tillsammans med HTML‑dokumentet när du flyttar eller publicerar utdata. Den genererade sidan laddar också jQuery och Anime.js från offentliga CDN:n; utan dem fungerar inte bildnavigering och animationer.
{{% /alert %}}

För att exportera utan att spela upp formanimationer eller bildövergångar, sätt [animate_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) och [animate_transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/) till `False` i [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/). Dessa inställningar är oberoende, så du kan aktivera den ena medan du inaktiverar den andra. Exemplet exporterar presentationen med båda typer av animationer inaktiverade i den genererade sidan.

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.animate_shapes = False
html5_options.animate_transitions = False

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres5.html", slides.export.SaveFormat.HTML5, html5_options)
```

## **Exportera PowerPoint till HTML**

Den standardmässiga HTML‑exporten använder en annan renderingsmetod: bildinnehåll representeras av SVG i en HTML‑sida. Följande exempel konverterar en presentation till ett HTML‑dokument med denna renderingsmetod.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres.html", slides.export.SaveFormat.HTML)
```

Den förenklade markupen nedan illustrerar strukturen för den genererade sidan. SVG‑elementet innehåller det renderade bildinnehållet; platshållartexten representerar det innehållet och är inte det faktiska exportutdata.

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
Den SVG‑baserade exporten visar inte PowerPoint‑former som individuella HTML‑element. Använd HTML5‑export när du behöver de form‑animationer och bild‑övergångsalternativ som demonstreras i den här artikeln.
{{% /alert %}}

## **Exportera PowerPoint till HTML5‑bildvisning**

HTML5‑exporten skapar en sida för visning och navigering av presentationens bilder i en webbläsare. Detta exempel aktiverar både [animate_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) och [animate_transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/) så att den exporterade bildvyn kan spela upp effekter från källpresentationen.

Använd en presentation som redan innehåller formanimationer och bildövergångar för att se effekten av dessa inställningar. Att aktivera dem lägger inte till nya effekter på bilder som saknar dem. Efter export, öppna det genererade HTML5‑dokumentet i en webbläsare med dess stödfiler tillgängliga.

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.animate_shapes = True
html5_options.animate_transitions = True

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("HTML5-slide-view.html", slides.export.SaveFormat.HTML5, html5_options)
```

## **Konvertera en presentation till ett HTML5‑dokument med kommentarer**

Du kan inkludera befintliga bildkommentarer i HTML5‑utdata så att läsare kan se återkoppling bredvid bildinnehållet. Exemplet i detta avsnitt förutsätter att källpresentationen innehåller kommentarer, som illustrerat nedan. Det exporterar dessa kommentarer; det skapar inga nya.

![Två kommentarer på presentationsbilden](two_comments_pptx.png)

Tilldela ett [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/)‑objekt till egenskapen [slides_layout_options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/slides_layout_options/) i [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/). Ställ in [comments_position](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/comments_position/) till `RIGHT` från uppräkningen [CommentsPositions](https://reference.aspose.com/slides/python-net/aspose.slides.export/commentspositions/) för att placera kommentarerna till höger om varje bild.

```python
import aspose.slides as slides

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.comments_position = slides.export.CommentsPositions.RIGHT

html5_options = slides.export.Html5Options()
html5_options.slides_layout_options = layout_options

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.html", slides.export.SaveFormat.HTML5, html5_options)
```

Följande exempel exporterar presentationen till HTML5 med denna kommentarslayout. En presentation utan kommentarer kommer inte ha någon kommentarstext att visa.

![Kommentarerna i den exporterade HTML5-dokumentet](two_comments_html5.png)

## **Exkludera JavaScript‑hyperlänkar vid export**

Anta att `hyperlinks.pptx` innehåller länkt text med ett `javascript:alert('Hello')`‑mål och en vanlig `https://example.com/`‑länk. För att exkludera JavaScript‑hyperlänken vid export, sätt [Html5Options.skip_java_script_links](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/skip_java_script_links/) till `True`. Standardvärdet är `False`, så dessa länkar filtreras inte om du inte aktiverar alternativet.

Följande exempel laddar presentationen från arbetskatalogen och exporterar den med hjälp av [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/):

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.skip_java_script_links = True

with slides.Presentation("hyperlinks.pptx") as presentation:
    presentation.save("filtered-html5.html", slides.export.SaveFormat.HTML5, html5_options)
```

Den exporterade filen utelämnar JavaScript‑hyperlänken samtidigt som den behåller dess text och den vanliga HTTPS‑länken. Källpresentationen förblir oförändrad.

Detta alternativ filtrerar JavaScript‑hyperlänkar; det tar inte bort alla skript eller annat aktivt innehåll, och det garanterar inte CSP‑efterlevnad. Till exempel innehåller HTML5‑utdata fortfarande skript för bildnavigering och animationer.

## **FAQ**

**Kan jag kontrollera om objektanimationer och bildövergångar spelas upp i HTML5?**

Ja, HTML5‑exporten erbjuder separata alternativ för att aktivera eller inaktivera [shape animations](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) och [slide transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/).

**Stöds kommentarer, och var kan de placeras i förhållande till bilden?**

Ja, befintliga kommentarer kan inkluderas i HTML5‑utdata och positioneras (till exempel till höger om bilden) via [layoutinställningar](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/slides_layout_options/) för anteckningar och kommentarer.

**Kan jag hoppa över länkar som anropar JavaScript av säkerhets- eller CSP‑skäl?**

Ja, inställningen [skip_java_script_links](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/skip_java_script_links/) låter dig hoppa över hyperlänkar med JavaScript‑anrop vid sparande. Standardvärdet är `False`. Se [Exkludera JavaScript‑hyperlänkar vid export](/slides/sv/python-net/export-to-html5/#exclude-javascript-hyperlinks-during-export) för ett HTML5‑exportexempel och filteromfånget. Denna inställning tar inte bort JavaScript som används av HTML5‑visaren för navigering och animationer.