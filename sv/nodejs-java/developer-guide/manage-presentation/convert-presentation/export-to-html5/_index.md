---
title: Konvertera presentationer till HTML5 i JavaScript
linktitle: Presentation till HTML5
type: docs
weight: 40
url: /sv/nodejs-java/export-to-html5/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Exportera PowerPoint- och OpenDocument-presentationer till responsiv HTML5 med Aspose.Slides för Node.js. Bevara formatering, animationer och interaktivitet."
---
## **Översikt**

Denna artikel förklarar hur du konverterar PowerPoint-presentationer till HTML5 med Aspose.Slides för Node.js via Java. Den täcker grundläggande export, kontroll av formanimationer och bildövergångar samt kommentarlayout. Den jämför också HTML5-utdata med den SVG‑baserade utdata från standard‑HTML‑export.

## **Exportera PowerPoint till HTML5**

Följande exempel läser in en presentation från arbetskatalogen och sparar den i HTML5-format. Det använder standardinställningarna för export; nästa exempel visar hur du explicit styr uppspelning av animationer. Ersätt inmatningssökvägen med sökvägen till din presentation.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres.html", aspose.slides.SaveFormat.Html5);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Förutom HTML-dokumentet skriver exporten ut stödjande CSS‑ och JavaScript‑filer för bildstil, animationer, effekter och navigation. Behåll dessa filer tillsammans med HTML-dokumentet när du flyttar eller publicerar utdata. Den genererade sidan laddar även jQuery och Anime.js från offentliga CDN‑er; utan dem fungerar inte bildnavigation och animationer.
{{% /alert %}}

För att exportera utan att spela upp formanimationer eller bildövergångar, skicka `false` till [setAnimateShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-) och [setAnimateTransitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-) i [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/). Dessa inställningar är oberoende, så du kan aktivera den ena och inaktivera den andra. Exemplet exporterar presentationen med båda typerna av animation inaktiverade i den genererade sidan.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setAnimateShapes(false);
html5Options.setAnimateTransitions(false);

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```
## **Exportera PowerPoint till HTML**

Den standardmässiga HTML‑exporten använder en annan renderingsmetod: bildinnehållet representeras av SVG i en HTML‑sida. Följande exempel konverterar en presentation till ett HTML‑dokument med denna renderingsmetod.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres.html", aspose.slides.SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Den förenklade markupen nedan illustrerar strukturen för den genererade sidan. SVG‑elementet innehåller det renderade bildinnehållet; platshållartexten representerar det innehållet och är inte den faktiska exportutdata.

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
Den SVG‑baserade exporten exponerar inte PowerPoint‑former som individuella HTML‑element. Använd HTML5‑export när du behöver alternativ för formanimation och bildövergång som demonstreras i denna artikel.
{{% /alert %}}

## **Exportera PowerPoint till HTML5‑bildvy**

HTML5‑exporten genererar en sida för att visa och navigera presentationens bilder i en webbläsare. Detta exempel aktiverar både [setAnimateShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-) och [setAnimateTransitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-) så att den exporterade bildvyn kan spela effekter från källpresentationen.

Använd en presentation som redan innehåller formanimationer och bildövergångar för att se effekten av dessa inställningar. Att aktivera dem lägger inte till nya effekter på bilder som saknar dem. Efter export, öppna det genererade HTML5‑dokumentet i en webbläsare med dess stödjande filer tillgängliga.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setAnimateShapes(true);
html5Options.setAnimateTransitions(true);

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("HTML5-slide-view.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```
## **Konvertera en presentation till ett HTML5‑dokument med kommentarer**

Du kan inkludera befintliga bildkommentarer i HTML5‑utdata så att läsarna kan se återkoppling bredvid bildinnehållet. Exemplet i detta avsnitt förväntar sig att källpresentationen innehåller kommentarer, som visas nedan. Det exporterar dessa kommentarer; det skapar inga nya.

![Två kommentarer på presentationsbilden](two_comments_pptx.png)

Skicka ett [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notescommentslayoutingoptions/)‑objekt till metoden [setSlidesLayoutOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setSlidesLayoutOptions-aspose.slides.ISlidesLayoutOptions-) på [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/). Använd [setCommentsPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition-int-) för att välja `Right` från uppräkningen [CommentsPositions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentspositions/) för att placera kommentarerna till höger om varje bild.

Följande exempel exporterar presentationen till HTML5 med denna kommentarlayout. En presentation utan kommentarer kommer inte att ha någon kommentartext att visa.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);

const html5Options = new aspose.slides.Html5Options();
html5Options.setSlidesLayoutOptions(layoutOptions);

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

Bilden nedan visar den exporterade HTML5‑dokumentet med kommentarerna placerade bredvid bilden.

![Kommentarerna i den exporterade HTML5‑dokumentet](two_comments_html5.png)

## **Exkludera JavaScript‑hyperlänkar vid export**

Anta att `hyperlinks.pptx` innehåller länkad text med ett `javascript:alert('Hello')`‑mål och en vanlig `https://example.com/`‑länk. För att exkludera JavaScript‑hyperlänken vid export, skicka `true` till [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-). Standardvärdet är `false`, så dessa länkar filtreras inte om du inte aktiverar alternativet.

Följande exempel läser in presentationen från arbetskatalogen och exporterar den med [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setSkipJavaScriptLinks(true);

const presentation = new aspose.slides.Presentation("hyperlinks.pptx");
try {
    presentation.save("filtered-html5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

Den exporterade filen utelämnar JavaScript‑hyperlänken men behåller dess text och den vanliga HTTPS‑länken. Källpresentationen förblir oförändrad.

Detta alternativ filtrerar JavaScript‑hyperlänkar; det tar inte bort alla skript eller annat aktivt innehåll, och det garanterar inte CSP‑efterlevnad. Till exempel innehåller HTML5‑utdata fortfarande skript för bildnavigation och animationer.

## **Vanliga frågor**

**Kan jag kontrollera om objektanimationer och bildövergångar ska spelas i HTML5?**

Ja, HTML5‑exporten erbjuder separata alternativ för att aktivera eller inaktivera [shape animations](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-) och [slide transitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-).

**Stöds kommentarer, och var kan de placeras i förhållande till bilden?**

Ja, befintliga kommentarer kan inkluderas i HTML5‑utdata och placeras (till exempel till höger om bilden) via [layoutinställningar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setSlidesLayoutOptions-aspose.slides.ISlidesLayoutOptions-) för anteckningar och kommentarer.

**Kan jag hoppa över länkar som anropar JavaScript av säkerhets- eller CSP‑skäl?**

Ja, inställningen [setSkipJavaScriptLinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) låter dig hoppa över hyperlänkar med JavaScript‑anrop vid sparande. Standardvärdet är `false`. Se [Exkludera JavaScript‑hyperlänkar vid export](/slides/sv/nodejs-java/export-to-html5/#exclude-javascript-hyperlinks-during-export) för ett HTML5‑exportexempel och filterets omfattning. Denna inställning tar inte bort JavaScript som används av HTML5‑visaren för navigation och animationer.