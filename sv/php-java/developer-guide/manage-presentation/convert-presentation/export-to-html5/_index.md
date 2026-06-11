---
title: Konvertera presentationer till HTML5 i PHP
linktitle: Presentation till HTML5
type: docs
weight: 40
url: /sv/php-java/export-to-html5/
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
- PHP
- Aspose.Slides
description: "Exportera PowerPoint- och OpenDocument-presentationer till responsiv HTML5 med Aspose.Slides för PHP via Java. Bevara formatering, animationer och interaktivitet."
---
## **Översikt**

Denna artikel förklarar hur du konverterar PowerPoint-presentationer till HTML5 med Aspose.Slides. Den täcker grundläggande HTML5-export utan webbförlängningar eller ytterligare beroenden, samt alternativ för att styra formanimationer och bildövergångar. Artikeln visar också den vanliga PowerPoint‑till‑HTML‑exportprocessen, förklarar hur du genererar HTML5‑utdata i bildvyerläge och demonstrerar hur du inkluderar kommentarer i det exporterade dokumentet genom att konfigurera deras layout.

## **Exportera PowerPoint till HTML5**

Denna PHP‑kod visar hur du exporterar en presentation till HTML5 utan webbförlängningar och beroenden:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save("pres.html", SaveFormat::Html5);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 
I detta fall får du ren HTML. 
{{% /alert %}}

Du kan vilja ange inställningar för formanimationer och bildövergångar på följande sätt:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $html5Options = new Html5Options();
    $html5Options->setAnimateShapes(false);
    $html5Options->setAnimateTransitions(false);
    $pres->save("pres5.html", SaveFormat::Html5, $html5Options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Exportera PowerPoint till HTML**

Denna Java‑kod demonstrerar den vanliga PowerPoint‑till‑HTML‑processen:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save("pres.html", SaveFormat::Html);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

I detta fall renderas presentationsinnehållet genom SVG i en form som följer:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```php

```

{{% alert title="Note" color="warning" %}} 

When you use this method to export PowerPoint to HTML, due to the SVG rendering, you will not be to apply styles or animate specific elements. 

{{% /alert %}}

## **Export PowerPoint to HTML5 Slide View**

**Aspose.Slides** allows you to convert a PowerPoint presentation to an HTML5 document in which the slides are presented in a slide view mode. In this case, when you open the resulting HTML5 file in a browser, you see the presentation in slide view mode on a web page. 

This PHP code demonstrates the PowerPoint to HTML5 Slide View export process:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $html5Options = new Html5Options();
    $html5Options->setAnimateShapes(true);
    $html5Options->setAnimateTransitions(true);
    $pres->save("HTML5-slide-view.html", SaveFormat::Html5, $html5Options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Convert Presentations to HTML5 Documents with Comments**

Comments in PowerPoint are a tool that allows users to leave notes or feedback on presentation slides. They are especially useful in collaborative projects, where multiple people can add their suggestions or remarks to specific slide elements without altering the main content. Each comment shows the author's name, making it easy to track who left the remark.

Let's say we have the following PowerPoint presentation saved in the "sample.pptx" file.

![Two comments on the presentation slide](two_comments_pptx.png)

When you convert a PowerPoint presentation to an HTML5 document, you can easily specify whether to include comments from the presentation in the output document. To do this, you need to specify the display parameters for comments in the `getNotesCommentsLayouting` method of the `Html5Options` class.

The following code example converts a presentation to an HTML5 document with comments displayed to the right of the slides.
```php

Dokumentet "output.html" visas i bilden nedan.

![Kommentarerna i det exporterade HTML5-dokumentet](two_comments_html5.png)

## **Vanliga frågor**

**Kan jag kontrollera om objektanimationer och bildövergångar ska spelas upp i HTML5?**

Ja, HTML5 erbjuder separata alternativ för att aktivera eller inaktivera [formanimationer](https://reference.aspose.com/slides/sv/php-java/aspose.slides/html5options/setanimateshapes/) och [bildövergångar](https://reference.aspose.com/slides/sv/php-java/aspose.slides/html5options/setanimatetransitions/).

**Stöds export av kommentarer, och var kan de placeras i förhållande till bilden?**

Ja, kommentarer kan läggas till i HTML5 och positioneras (t.ex. till höger om bilden) via [layoutinställningar](https://reference.aspose.com/slides/sv/php-java/aspose.slides/html5options/#setSlidesLayoutOptions) för anteckningar och kommentarer.

**Kan jag hoppa över länkar som anropar JavaScript av säkerhets- eller CSP‑skäl?**

Ja, det finns en [inställning](https://reference.aspose.com/slides/sv/php-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) som låter dig hoppa över hyperlänkar med JavaScript‑anrop vid sparning. Detta hjälper till att följa strikta säkerhetspolicyer.