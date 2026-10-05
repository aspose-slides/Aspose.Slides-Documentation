---
title: Konvertera presentationer till HTML5 i Python via Java
linktitle: Presentation till HTML5
type: docs
weight: 40
url: /sv/python-java/export-to-html5/
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
- Java
- Aspose.Slides
description: "Exportera PowerPoint- och OpenDocument-presentationer till responsiv HTML5 med Aspose.Slides för Python via Java. Bevara formatering, animationer och interaktivitet."
---
## **Översikt**

Denna artikel förklarar hur du konverterar PowerPoint‑presentationer till HTML5 med Aspose.Slides för Python via Java. Den täcker grundläggande export, kontroll av formanimationer och bildövergångar samt kommentarlayout. Den jämför också HTML5‑utdata med den SVG‑baserade utdata från standard‑HTML‑export.

Exemplen kräver Aspose.Slides för Python via Java och en kompatibel Java‑runtime. Placera inmatningspresentationerna i den aktuella arbetskatalogen. Varje exempel startar JVM endast om den inte redan körs.

## **Exportera PowerPoint till HTML5**

Följande exempel läser in en presentation från arbetskatalogen och sparar den i HTML5‑format. Det använder standardexportinställningarna; nästa exempel visar hur du explicit styr uppspelning av animationer. Ersätt inmatningssökvägen med sökvägen till din presentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres.html", SaveFormat.Html5)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Förutom HTML‑dokumentet skriver exporten ut stödjande CSS‑ och JavaScript‑filer för bildstil, animationer, effekter och navigation. Behåll dessa filer tillsammans med HTML‑dokumentet när du flyttar eller publicerar resultatet. Den genererade sidan laddar också jQuery och Anime.js från offentliga CDN‑n; utan dem fungerar inte bildnavigation och animationer.
{{% /alert %}}

För att exportera utan att spela upp formanimationer eller bildövergångar, skicka `False` till [setAnimateShapes](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateShapes) och [setAnimateTransitions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateTransitions) i [Html5Options](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/). Dessa inställningar är oberoende, så du kan aktivera den ena medan du inaktiverar den andra. Exempelexporten sparar presentationen med båda typerna av animationer inaktiverade i den genererade sidan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

html5_options = Html5Options()
html5_options.setAnimateShapes(False)
html5_options.setAnimateTransitions(False)

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres5.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **Exportera PowerPoint till HTML**

Standard‑HTML‑exporten använder en annan renderingsmetod: bildinnehållet representeras av SVG i en HTML‑sida. Följande exempel konverterar en presentation till ett HTML‑dokument med denna renderingsmetod.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres.html", SaveFormat.Html)
finally:
    presentation.dispose()
```

Den förenklade markupen nedan illustrerar strukturen i den genererade sidan. SVG‑elementet innehåller det renderade bildinnehållet; platshållartexten representerar detta innehåll och är inte den faktiska exportutdata.

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
Den SVG‑baserade exporten exponeras inte PowerPoint‑former som enskilda HTML‑element. Använd HTML5‑export när du behöver de form‑animation‑ och bild‑övergångsalternativ som demonstreras i den här artikeln.
{{% /alert %}}

## **Exportera PowerPoint till HTML5‑bildvy**

HTML5‑exporten skapar en sida för att visa och navigera presentationsbilder i en webbläsare. Detta exempel aktiverar både [setAnimateShapes](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateShapes) och [setAnimateTransitions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateTransitions) så att den exporterade bildvyn kan spela upp effekter från källpresentationen.

Använd en presentation som redan innehåller formanimationer och bildövergångar för att se effekten av dessa inställningar. Att aktivera dem lägger inte till nya effekter på bilder som saknar dem. Efter export, öppna det genererade HTML5‑dokumentet i en webbläsare med dess stödjande filer tillgängliga.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

html5_options = Html5Options()
html5_options.setAnimateShapes(True)
html5_options.setAnimateTransitions(True)

presentation = Presentation("pres.pptx")
try:
    presentation.save("HTML5-slide-view.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **Konvertera en presentation till ett HTML5‑dokument med kommentarer**

Du kan inkludera befintliga bildkommentarer i HTML5‑utdata så att läsare kan se återkoppling tillsammans med bildinnehållet. Exemplet i detta avsnitt förväntar sig att källpresentationen innehåller kommentarer, som illustrerat nedan. Det exporterar dessa kommentarer; det skapar inga nya.

![Två kommentarer på presentationsbilden](two_comments_pptx.png)

Skicka ett [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-java/aspose.slides/notescommentslayoutingoptions/)‑objekt till metoden [setSlidesLayoutOptions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) i [Html5Options](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/). Använd [setCommentsPosition](https://reference.aspose.com/slides/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) för att välja `Right` från uppräkningen [CommentsPositions](https://reference.aspose.com/slides/python-java/aspose.slides/commentspositions/) så att kommentarerna placeras till höger om varje bild.

Följande exempel exporterar presentationen till HTML5 med den här kommentarlayouten. En presentation utan kommentarer kommer inte ha någon kommentartext att visa.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, Html5Options, NotesCommentsLayoutingOptions, Presentation, SaveFormat

layout_options = NotesCommentsLayoutingOptions()
layout_options.setCommentsPosition(CommentsPositions.Right)

html5_options = Html5Options()
html5_options.setSlidesLayoutOptions(layout_options)

presentation = Presentation("sample.pptx")
try:
    presentation.save("output.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

![Kommentarerna i det exporterade HTML5‑dokumentet](two_comments_html5.png)

## **Exkludera JavaScript‑hyperlänkar vid export**

Anta att `hyperlinks.pptx` innehåller länkad text med ett mål `javascript:alert('Hello')` och en vanlig `https://example.com/`‑länk. För att exkludera JavaScript‑hyperlänken vid export, skicka `True` till [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks). Standardvärdet är `False`, så dessa länkar filtreras inte om du inte aktiverar alternativet.

Följande exempel läser in presentationen från arbetskatalogen och exporterar den med [Html5Options](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

html5_options = Html5Options()
html5_options.setSkipJavaScriptLinks(True)

presentation = Presentation("hyperlinks.pptx")
try:
    presentation.save("filtered-html5.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

Den exporterade filen utelämnar JavaScript‑hyperlänken men behåller dess text och den vanliga HTTPS‑länken. Källpresentationen förblir oförändrad.

Detta alternativ filtrerar JavaScript‑hyperlänkar; det tar inte bort alla skript eller annat aktivt innehåll, och garanterar inte CSP‑efterlevnad. Till exempel inkluderar HTML5‑utdata fortfarande skript för bildnavigation och animationer.

## **Vanliga frågor**

**Kan jag styra om objektanimationer och bildövergångar spelas upp i HTML5?**

Ja, HTML5‑exporten erbjuder separata alternativ för att aktivera eller inaktivera [shape animations](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateShapes) och [slide transitions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateTransitions).

**Stöds kommentarer, och var kan de placeras i förhållande till bilden?**

Ja, befintliga kommentarer kan inkluderas i HTML5‑utdata och placeras (t.ex. till höger om bilden) via [layoutinställningar](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) för noteringar och kommentarer.

**Kan jag hoppa över länkar som anropar JavaScript av säkerhets‑ eller CSP‑skäl?**

Ja, inställningen [setSkipJavaScriptLinks](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) låter dig hoppa över hyperlänkar med JavaScript‑anrop vid sparande. Standardvärdet är `False`. Se [Exkludera JavaScript‑hyperlänkar vid export](/slides/sv/python-java/export-to-html5/#exclude-javascript-hyperlinks-during-export) för ett exempel på HTML5‑export och filterets omfattning. Denna inställning tar inte bort JavaScript som används av HTML5‑visaren för navigation och animationer.