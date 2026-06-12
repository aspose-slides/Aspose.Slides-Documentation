---
title: Presentaties converteren naar HTML5 in JavaScript
linktitle: Presentatie naar HTML5
type: docs
weight: 40
url: /nl/nodejs-java/export-to-html5/
keywords:
- PowerPoint naar HTML5
- OpenDocument naar HTML5
- presentatie naar HTML5
- dia naar HTML5
- PPT naar HTML5
- PPTX naar HTML5
- ODP naar HTML5
- PPT opslaan als HTML5
- PPTX opslaan als HTML5
- ODP opslaan als HTML5
- PPT exporteren naar HTML5
- PPTX exporteren naar HTML5
- ODP exporteren naar HTML5
- Node.js
- JavaScript
- Aspose.Slides
description: "Exporteer PowerPoint‑ en OpenDocument‑presentaties naar responsieve HTML5 met Aspose.Slides voor Node.js. Behoud opmaak, animaties en interactiviteit."
---
## **Overzicht**

Dit artikel legt uit hoe u PowerPoint‑presentaties naar HTML5 kunt converteren met Aspose.Slides. Het behandelt basale HTML5‑export zonder web‑extensies of extra afhankelijkheden, evenals opties om vorm‑animaties en dia‑overgangen te regelen. Het artikel toont ook het standaard PowerPoint‑naar‑HTML‑exportproces, legt uit hoe u HTML5‑output in dia‑weergavemodus genereert, en demonstreert hoe u opmerkingen in het geëxporteerde document kunt opnemen door hun lay‑out te configureren.

## **PowerPoint exporteren naar HTML5**

Deze JavaScript‑code laat zien hoe u een presentatie naar HTML5 exporteert zonder web‑extensies en afhankelijkheden:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.html", aspose.slides.SaveFormat.Html5);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" %}} 
In dit geval krijgt u schone HTML. 
{{% /alert %}}

U kunt op deze manier instellingen voor vorm‑animaties en dia‑overgangen opgeven:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var html5Options = new aspose.slides.Html5Options();
    html5Options.setAnimateShapes(false);
    html5Options.setAnimateTransitions(false);
    pres.save("pres5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **PowerPoint exporteren naar HTML**

Deze JavaScript‑code demonstreert het standaard PowerPoint‑naar‑HTML‑proces:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.html", aspose.slides.SaveFormat.Html);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

In dit geval wordt de presentatiewaarde gerenderd via SVG in een vorm als deze:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Opmerking" color="warning" %}} 
Wanneer u deze methode gebruikt om PowerPoint naar HTML te exporteren, zult u vanwege de SVG‑rendering geen stijlen kunnen toepassen of specifieke elementen animeren. 
{{% /alert %}}

## **PowerPoint exporteren naar HTML5 slideweergave**

**Aspose.Slides** maakt het mogelijk om een PowerPoint‑presentatie te converteren naar een HTML5‑document waarin de dia's in slideweergave‑modus worden gepresenteerd. In dit geval ziet u, wanneer u het resulterende HTML5‑bestand in een browser opent, de presentatie in slideweergave‑modus op een webpagina.

Deze JavaScript‑code demonstreert het PowerPoint‑naar‑HTML5‑slideweergave‑exportproces:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var html5Options = new aspose.slides.Html5Options();
    html5Options.setAnimateShapes(true);
    html5Options.setAnimateTransitions(true);
    pres.save("HTML5-slide-view.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Een presentatie converteren naar een HTML5‑document met opmerkingen**

Opmerkingen in PowerPoint zijn een hulpmiddel waarmee gebruikers notities of feedback op presentatiedia's kunnen achterlaten. Ze zijn vooral nuttig in samenwerkingsprojecten, waarbij meerdere personen hun suggesties of opmerkingen kunnen toevoegen aan specifieke dia‑elementen zonder de hoofdinhoud te wijzigen. Elke opmerking toont de naam van de auteur, zodat u gemakkelijk kunt zien wie de opmerking heeft geplaatst.

Stel dat we de volgende PowerPoint‑presentatie hebben opgeslagen in het bestand "sample.pptx".

![Twee opmerkingen op de presentatiedia](two_comments_pptx.png)

Wanneer u een PowerPoint‑presentatie converteert naar een HTML5‑document, kunt u eenvoudig opgeven of opmerkingen uit de presentatie in het uitvoerdocument moeten worden opgenomen. Hiervoor moet u de weergave‑parameters voor opmerkingen opgeven in de `notes_comments_layouting`‑eigenschap van de [Html5Options](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/html5options/)‑klasse.

Het volgende code‑voorbeeld converteert een presentatie naar een HTML5‑document met opmerkingen die rechts van de dia's worden weergegeven.
```javascript
let html5Options = new aspose.slides.Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(aspose.slides.CommentsPositions.Right);

let presentation = new aspose.slides.Presentation("sample.pptx");
presentation.save("output.html", aspose.slides.SaveFormat.Html5, html5Options);
presentation.dispose();
```

Het document "output.html" wordt weergegeven in de afbeelding hieronder.

![De opmerkingen in het uitvoer‑HTML5‑document](two_comments_html5.png)

## **Veelgestelde vragen**

**Kan ik bepalen of object‑animaties en dia‑overgangen in HTML5 worden afgespeeld?**

Ja, HTML5 biedt afzonderlijke opties om [vorm‑animaties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/html5options/setanimateshapes/) en [dia‑overgangen](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/html5options/setanimatetransitions/) in of uit te schakelen.

**Worden opmerkingen ondersteund in de output, en waar kunnen ze ten opzichte van de dia worden geplaatst?**

Ja, opmerkingen kunnen in HTML5 worden toegevoegd en gepositioneerd (bijvoorbeeld rechts van de dia) via [layout‑instellingen](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/html5options/#setNotesCommentsLayouting) voor notities en opmerkingen.

**Kan ik links die JavaScript aanroepen overslaan om veiligheids- of CSP‑redenen?**

Ja, er is een [instelling](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) die het mogelijk maakt om hyperlinks met JavaScript‑aanroepen over te slaan tijdens het opslaan. Dit helpt om te voldoen aan strenge beveiligingsbeleid.