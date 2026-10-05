---
title: Konvertera presentationer till HTML5 i Java
linktitle: Presentation till HTML5
type: docs
weight: 40
url: /sv/java/export-to-html5/
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
- Java
- Aspose.Slides
description: "Exportera PowerPoint- och OpenDocument-presentationer till responsiv HTML5 med Aspose.Slides för Java. Bevara formatering, animationer och interaktivitet."
---
## **Översikt**

Den här artikeln förklarar hur du konverterar PowerPoint‑presentationer till HTML5 med Aspose.Slides för Java. Den täcker grundläggande export, kontroll av formanimationer och bildövergångar samt kommentarlayout. Den jämför också HTML5‑utdata med den SVG‑baserade utdata som standard‑HTML‑exporten ger.

## **Exportera PowerPoint till HTML5**

Följande exempel läser in en presentation från arbetskatalogen och sparar den i HTML5‑format. Det använder standardexportinställningarna; nästa exempel visar hur du kontrollerar uppspelning av animationer explicit. Byt ut inmatningssökvägen mot sökvägen till din presentation.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres.html", SaveFormat.Html5);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Förutom HTML‑dokumentet skriver exporten stödjande CSS‑ och JavaScript‑filer för bildstyling, animationer, effekter och navigering. Behåll dessa filer tillsammans med HTML‑dokumentet när du flyttar eller publicerar utdata. Den genererade sidan laddar även jQuery och Anime.js från offentliga CDN:er; utan dem fungerar inte bildnavigering och animationer.
{{% /alert %}}

För att exportera utan att spela upp formanimationer eller bildövergångar, skicka `false` till [setAnimateShapes](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) och [setAnimateTransitions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) i [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/). Dessa inställningar är oberoende, så du kan aktivera den ena och inaktivera den andra. Exemplet exporterar presentationen med båda typerna av animationer inaktiverade i den genererade sidan.

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setAnimateShapes(false);
html5Options.setAnimateTransitions(false);

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres5.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **Exportera PowerPoint till HTML**

Standard‑HTML‑exporten använder en annan renderingsmetod: bildinnehållet representeras av SVG i en HTML‑sida. Följande exempel konverterar en presentation till ett HTML‑dokument med denna renderingsmetod.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Den förenklade markupen nedan illustrerar strukturen på den genererade sidan. SVG‑elementet innehåller det renderade bildinnehållet; platshållartexten representerar det innehållet och är inte den faktiska exportutdata.

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
Den SVG‑baserade exporten exponerar inte PowerPoint‑former som enskilda HTML‑element. Använd HTML5‑export när du behöver de form‑animations‑ och bild‑övergångsalternativ som demonstreras i den här artikeln.
{{% /alert %}}

## **Exportera PowerPoint till HTML5‑bildvy**

HTML5‑export skapar en sida för visning och navigering av presentationsbilder i en webbläsare. Detta exempel aktiverar både [setAnimateShapes](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) och [setAnimateTransitions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) så att den exporterade bildvyn kan spela upp effekter från källpresentationen.

Använd en presentation som redan innehåller formanimationer och bildövergångar för att se effekten av dessa inställningar. Att aktivera dem lägger inte till nya effekter på bilder som saknar dem. Efter export, öppna det genererade HTML5‑dokumentet i en webbläsare med dess stödjande filer tillgängliga.

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setAnimateShapes(true);
html5Options.setAnimateTransitions(true);

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **Konvertera en presentation till ett HTML5‑dokument med kommentarer**

Du kan inkludera befintliga bildkommentarer i HTML5‑utdata så att läsare kan se återkoppling bredvid bildinnehållet. Exemplet i det här avsnittet förutsätter att källpresentationen innehåller kommentarer, som illustrerat nedan. Det exporterar dessa kommentarer; det skapar inga nya.

![Two comments on the presentation slide](two_comments_pptx.png)

Skicka ett [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/notescommentslayoutingoptions/)‑objekt till [setSlidesLayoutOptions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-)‑metoden i [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/). Använd [setCommentsPosition](https://reference.aspose.com/slides/java/com.aspose.slides/notescommentslayoutingoptions/#setCommentsPosition-int-) för att välja `Right` från uppräkningen [CommentsPositions](https://reference.aspose.com/slides/java/com.aspose.slides/commentspositions/) för att placera kommentarerna till höger om varje bild.

Följande exempel exporterar presentationen till HTML5 med denna kommentarslayout. En presentation utan kommentarer kommer inte att ha någon kommentarstext att visa.

```java
import com.aspose.slides.*;

NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
layoutOptions.setCommentsPosition(CommentsPositions.Right);

Html5Options html5Options = new Html5Options();
html5Options.setSlidesLayoutOptions(layoutOptions);

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

Bilden nedan visar det exporterade HTML5‑dokumentet med kommentarerna visas bredvid bilden.

![The comments in the output HTML5 document](two_comments_html5.png)

## **Exkludera JavaScript‑hyperlänkar under export**

Anta att `hyperlinks.pptx` innehåller länkad text med ett `javascript:alert('Hello')`‑mål och en vanlig `https://example.com/`‑länk. För att exkludera JavaScript‑hyperlänken under export, skicka `true` till [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-). Standardvärdet är `false`, så dessa länkar filtreras inte om du inte aktiverar alternativet.

Följande exempel läser in presentationen från arbetskatalogen och exporterar den med [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/):

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setSkipJavaScriptLinks(true);

Presentation presentation = new Presentation("hyperlinks.pptx");
try {
    presentation.save("filtered-html5.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

Den exporterade filen utelämnar JavaScript‑hyperlänken men behåller dess text och den vanliga HTTPS‑länken. Källpresentationen förblir oförändrad.

Detta alternativ filtrerar JavaScript‑hyperlänkar; det tar inte bort alla skript eller annat aktivt innehåll, och det garanterar inte CSP‑efterlevnad. Till exempel innehåller HTML5‑utdata fortfarande skript för bildnavigering och animationer.

## **FAQ**

**Kan jag styra om objektanimationer och bildövergångar ska spelas upp i HTML5?**

Ja, HTML5‑exporten erbjuder separata alternativ för att aktivera eller inaktivera [shape animations](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) och [slide transitions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).

**Stöds kommentarer, och var kan de placeras i förhållande till bilden?**

Ja, befintliga kommentarer kan inkluderas i HTML5‑utdata och placeras (till exempel till höger om bilden) via [layout settings](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) för anteckningar och kommentarer.

**Kan jag hoppa över länkar som anropar JavaScript av säkerhets- eller CSP‑skäl?**

Ja, inställningen [setSkipJavaScriptLinks](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) låter dig hoppa över hyperlänkar med JavaScript‑anrop vid sparande. Standardvärdet är `false`. Se [Exkludera JavaScript‑hyperlänkar under export](/slides/sv/java/export-to-html5/#exclude-javascript-hyperlinks-during-export) för ett HTML5‑exportexempel och filteromfånget. Denna inställning tar inte bort JavaScript som används av HTML5‑visaren för navigering och animationer.