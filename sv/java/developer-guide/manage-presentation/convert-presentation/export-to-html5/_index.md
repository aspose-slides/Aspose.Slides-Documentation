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

Den här artikeln förklarar hur du konverterar PowerPoint-presentationer till HTML5 med Aspose.Slides. Den täcker grundläggande HTML5-export utan webbutökningar eller extra beroenden, samt alternativ för att kontrollera formanimationer och bildövergångar. Artikeln visar också den standardiserade PowerPoint‑till‑HTML‑exportprocessen, förklarar hur du genererar HTML5‑utdata i bildvysläge och demonstrerar hur du inkluderar kommentarer i det exporterade dokumentet genom att konfigurera deras layout.

## **Exportera PowerPoint till HTML5**

Den här Java‑koden visar hur du exporterar en presentation till HTML5 utan webbutökningar och beroenden:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html5);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 
I det här fallet får du ren HTML. 
{{% /alert %}}

Du kan vilja ange inställningar för formanimationer och bildövergångar på detta sätt:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Html5Options html5Options = new Html5Options();
    html5Options.setAnimateShapes(false);
    html5Options.setAnimateTransitions(false);
    
    pres.save("pres5.html", SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Exportera PowerPoint till HTML**

Den här Java‑koden demonstrerar den standardiserade PowerPoint‑till‑HTML‑processen:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
}
```

I det här fallet renderas presentationsinnehållet via SVG i en form som detta:

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
När du använder denna metod för att exportera PowerPoint till HTML, på grund av SVG‑renderingen, kommer du inte kunna applicera stilar eller animera specifika element. 
{{% /alert %}}

## **Exportera PowerPoint till HTML5‑bildvysläge**

**Aspose.Slides** gör det möjligt att konvertera en PowerPoint-presentation till ett HTML5‑dokument där bilderna visas i bildvysläge. I det här fallet, när du öppnar den resulterande HTML5‑filen i en webbläsare, ser du presentationen i bildvysläge på en webbsida. 

Den här Java‑koden demonstrerar PowerPoint‑till‑HTML5‑bildvys‑exportprocessen:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Html5Options html5Options = new Html5Options();
    html5Options.setAnimateShapes(true);
    html5Options.setAnimateTransitions(true);

    pres.save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Konvertera presentationer till HTML5‑dokument med kommentarer**

Kommentarer i PowerPoint är ett verktyg som låter användare lämna anteckningar eller återkoppling på presentationsbilder. De är särskilt användbara i samarbetsprojekt, där flera personer kan lägga till sina förslag eller anmärkningar på specifika bildelement utan att ändra huvudinnehållet. Varje kommentar visar författarens namn, vilket gör det enkelt att spåra vem som lämnat anmärkningen.

Låt oss säga att vi har följande PowerPoint-presentation sparad i filen "sample.pptx".

![Två kommentarer på presentationsbilden](two_comments_pptx.png)

När du konverterar en PowerPoint-presentation till ett HTML5‑dokument kan du enkelt ange om kommentarer från presentationen ska inkluderas i utdokumentet. För att göra detta måste du ange visningsparametrarna för kommentarer i `getNotesCommentsLayouting`‑metoden i klassen [Html5Options](https://reference.aspose.com/slides/sv/java/com.aspose.slides/html5options/).

Följande kodexempel konverterar en presentation till ett HTML5‑dokument med kommentarer placerade till höger om bilderna.
```java
Html5Options html5Options = new Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(CommentsPositions.Right);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

Dokumentet "output.html" visas på bilden nedan.

![Kommentarerna i det exporterade HTML5‑dokumentet](two_comments_html5.png)

## **FAQ**

**Kan jag styra om objektanimationer och bildövergångar ska spelas upp i HTML5?**

Ja, HTML5 erbjuder separata alternativ för att aktivera eller inaktivera [shape animations](https://reference.aspose.com/slides/sv/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) och [slide transitions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).

**Stöds kommentarer i utskriften, och var kan de placeras i förhållande till bilden?**

Ja, kommentarer kan läggas till i HTML5 och placeras (t.ex. till höger om bilden) via [layout settings](https://reference.aspose.com/slides/sv/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) för anteckningar och kommentarer.

**Kan jag hoppa över länkar som anropar JavaScript av säkerhets- eller CSP-skäl?**

Ja, det finns en [setting](https://reference.aspose.com/slides/sv/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) som låter dig hoppa över hyperlänkar med JavaScript‑anrop under sparning. Detta underlättar efterlevnad av strikta säkerhetspolicys.