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

Denna artikel förklarar hur du konverterar PowerPoint-presentationer till HTML5 med Aspose.Slides för .NET. Den täcker grundläggande export, kontroll av formanimationer och bildövergångar samt kommentarer layout. Den jämför också HTML5-utdata med den SVG-baserade utdata från standard‑HTML‑export.

## **Exportera PowerPoint till HTML5**

Följande exempel laddar en presentation från arbetskatalogen och sparar den i HTML5‑format. Det använder standardexportinställningarna; nästa exempel visar hur du styr animeringsuppspelning explicit. Ersätt inmatningssökvägen med sökvägen till din presentation.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres.html", SaveFormat.Html5);
```

{{% alert color="info" title="Obs" %}}
Förutom HTML‑dokumentet skriver exporten stödjande CSS‑ och JavaScript‑filer för bildstil, animationer, effekter och navigation. Behåll dessa filer tillsammans med HTML‑dokumentet när du flyttar eller publicerar resultatet. Den genererade sidan laddar också jQuery och Anime.js från offentliga CDN:er; utan dem fungerar inte bildnavigering och animationer.
{{% /alert %}}

För att exportera utan att spela upp formanimationer eller bildövergångar, sätt [AnimateShapes](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) och [AnimateTransitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/) till `false` i [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/). Dessa inställningar är oberoende, så du kan aktivera den ena medan du inaktiverar den andra. Exemplet exporterar presentationen med båda typerna av animation inaktiverade i den genererade sidan.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    AnimateShapes = false,
    AnimateTransitions = false
};

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres5.html", SaveFormat.Html5, html5Options);
```
## **Exportera PowerPoint till HTML**

Den standardmässiga HTML‑exporten använder ett annat renderingssätt: bildinnehållet representeras av SVG i en HTML‑sida. Följande exempel konverterar en presentation till ett HTML‑dokument med detta renderingssätt.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres.html", SaveFormat.Html);
```

Den förenklade markupen nedan illustrerar strukturen på den genererade sidan. SVG‑elementet innehåller den renderade bildinnehållet; platshållartexten representerar det innehållet och är inte den faktiska exportutdata.

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Varning" color="warning" %}}
Den SVG‑baserade exporten exponerar inte PowerPoint‑former som individuella HTML‑element. Använd HTML5‑export när du behöver form‑animation och bild‑övergångsalternativ som demonstreras i denna artikel.
{{% /alert %}}

## **Exportera PowerPoint till HTML5‑bildvy**

HTML5‑export skapar en sida för att visa och navigera presentationens bilder i en webbläsare. Detta exempel aktiverar både [AnimateShapes](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) och [AnimateTransitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/) så att den exporterade bildvyn kan spela upp effekter från källpresentationen.

Använd en presentation som redan innehåller formanimationer och bildövergångar för att se effekten av dessa inställningar. Att aktivera dem lägger inte till nya effekter på bilder som inte har några. Efter export, öppna det genererade HTML5‑dokumentet i en webbläsare med dess stödjande filer tillgängliga.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    AnimateShapes = true,
    AnimateTransitions = true
};

using var presentation = new Presentation("pres.pptx");
presentation.Save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
```
## **Konvertera en presentation till ett HTML5‑dokument med kommentarer**

Du kan inkludera befintliga bildkommentarer i HTML5‑utdata så att läsare kan se återkoppling bredvid bildinnehållet. Exemplet i detta avsnitt förutsätter att källpresentationen innehåller kommentarer, som illustrerat nedan. Det exporterar dessa kommentarer; det skapar inga nya.

![Två kommentarer på presentationens bild](two_comments_pptx.png)

Tilldela ett [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/)‑objekt till egenskapen [SlidesLayoutOptions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/slideslayoutoptions/) i [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/). Sätt [CommentsPosition](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/commentsposition/) till `Right` från uppräkningen [CommentsPositions](https://reference.aspose.com/slides/net/aspose.slides.export/commentspositions/) för att placera kommentarerna till höger om varje bild.

Följande exempel exporterar presentationen till HTML5 med denna kommentarlayout. En presentation utan kommentarer kommer inte att ha någon kommentartext att visa.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var layoutOptions = new NotesCommentsLayoutingOptions
{
    CommentsPosition = CommentsPositions.Right
};

var html5Options = new Html5Options
{
    SlidesLayoutOptions = layoutOptions
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```

Bilden nedan visar det exporterade HTML5‑dokumentet med kommentarerna visade bredvid bilden.

![Kommentarerna i den exporterade HTML5‑dokumentet](two_comments_html5.png)

## **Uteslut JavaScript‑hyperlänkar vid export**

Anta att `hyperlinks.pptx` innehåller länkad text med ett `javascript:alert('Hello')`‑mål och en vanlig `https://example.com/`‑länk. För att utesluta JavaScript‑hyperlänken vid export, sätt [SaveOptions.SkipJavaScriptLinks](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) till `true`. Standardvärdet är `false`, så dessa länkar filtreras inte om du inte aktiverar alternativet.

Följande exempel laddar presentationen från arbetskatalogen och exporterar den med [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/):

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options { SkipJavaScriptLinks = true };

using var presentation = new Presentation("hyperlinks.pptx");
presentation.Save("filtered-html5.html", SaveFormat.Html5, html5Options);
```

Den exporterade filen utesluter JavaScript‑hyperlänken samtidigt som den behåller dess text och den vanliga HTTPS‑länken. Källpresentationen förblir oförändrad.

Detta alternativ filtrerar JavaScript‑hyperlänkar; det tar inte bort alla skript eller annat aktivt innehåll, och det garanterar inte CSP‑efterlevnad. Till exempel innehåller HTML5‑utdata fortfarande skript för bildnavigering och animationer.

## **Vanliga frågor**
**Kan jag kontrollera om objektanimationer och bildövergångar spelas upp i HTML5?**

Ja, HTML5‑exporten erbjuder separata alternativ för att aktivera eller inaktivera [formanimationer](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) och [bildövergångar](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/).

**Stöds kommentarer, och var kan de placeras i förhållande till bilden?**

Ja, befintliga kommentarer kan inkluderas i HTML5‑utdata och placeras (till exempel till höger om bilden) via [layoutinställningar](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/slideslayoutoptions/) för anteckningar och kommentarer.

**Kan jag hoppa över länkar som anropar JavaScript av säkerhets- eller CSP‑skäl?**

Ja, inställningen [SkipJavaScriptLinks](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) gör att du kan hoppa över hyperlänkar med JavaScript‑anrop vid sparande. Standardvärdet är `false`. Se [Uteslut JavaScript‑hyperlänkar vid export](/slides/sv/net/export-to-html5/#exclude-javascript-hyperlinks-during-export) för ett enkelt HTML‑, HTML5‑ och PDF‑exportexempel samt filterets omfattning. Denna inställning tar inte bort JavaScript som används av HTML5‑visaren för navigation och animationer.