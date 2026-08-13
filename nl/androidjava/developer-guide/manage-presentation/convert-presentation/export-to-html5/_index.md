---
title: Presentaties omzetten naar HTML5 op Android
linktitle: Presentatie naar HTML5
type: docs
weight: 40
url: /nl/androidjava/export-to-html5/
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
- Android
- Java
- Aspose.Slides
description: "Exporteer PowerPoint- en OpenDocument-presentaties naar responsieve HTML5 met Aspose.Slides voor Android via Java. Behoud opmaak, animaties en interactiviteit."
---
## **Overzicht**

Dit artikel legt uit hoe u PowerPoint‑presentaties kunt converteren naar HTML5 met Aspose.Slides. Het behandelt basale HTML5‑export zonder web‑extensies of extra afhankelijkheden, evenals opties om vormanimaties en dia‑overgangen te regelen. Het artikel toont ook het standaard PowerPoint‑naar‑HTML‑exportproces, legt uit hoe u HTML5‑output genereert in dia‑weergavemodus, en laat zien hoe u opmerkingen in het geëxporteerde document kunt opnemen door hun lay‑out te configureren.

## **PowerPoint exporteren naar HTML5**

Deze Java‑code laat zien hoe u een presentatie exporteert naar HTML5 zonder web‑extensies en afhankelijkheden:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html5);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}}In dit geval krijgt u schone HTML.{{% /alert %}}

U kunt op deze manier instellingen voor vormanimaties en dia‑overgangen opgeven:

```java
import com.aspose.slides.*;

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

## **PowerPoint exporteren naar HTML**

Deze Java‑code demonstreert het standaard PowerPoint‑naar‑HTML‑proces:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
}
```

In dit geval wordt de presentatie‑inhoud gerenderd via SVG in een vorm zoals deze:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Opmerking" color="warning" %}}Wanneer u deze methode gebruikt om PowerPoint naar HTML te exporteren, kunt u vanwege de SVG‑rendering geen stijlen toepassen of specifieke elementen animeren.{{% /alert %}}

## **PowerPoint exporteren naar HTML5‑diaweergave**

**Aspose.Slides** maakt het mogelijk een PowerPoint‑presentatie te converteren naar een HTML5‑document waarin de dia’s worden weergegeven in een diaweergavemodus. In dit geval ziet u bij het openen van het gegenereerde HTML5‑bestand in een browser de presentatie in diaweergavemodus op een webpagina.

Deze Java‑code demonstreert het PowerPoint‑naar‑HTML5‑diaweergave‑exportproces:

```java
import com.aspose.slides.*;

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

## **Een presentatie omzetten naar een HTML5‑document met opmerkingen**

Opmerkingen in PowerPoint zijn een hulpmiddel waarmee gebruikers notities of feedback kunnen achterlaten op dia’s van een presentatie. Ze zijn bijzonder nuttig bij samenwerkingsprojecten, waarbij meerdere personen hun suggesties of opmerkingen kunnen toevoegen aan specifieke dia‑elementen zonder de hoofdinhoud te wijzigen. Elke opmerking toont de naam van de auteur, waardoor het eenvoudig is te zien wie de opmerking heeft geplaatst.

Stel dat we de volgende PowerPoint‑presentatie hebben opgeslagen in het bestand “sample.pptx”.

![Twee opmerkingen op de presentatiedia](two_comments_pptx.png)

Wanneer u een PowerPoint‑presentatie converteert naar een HTML5‑document, kunt u eenvoudig opgeven of u de opmerkingen uit de presentatie in het uitvoer‑document wilt opnemen. Om dit te doen, moet u de weergave‑parameters voor opmerkingen doorgeven aan de `setSlidesLayoutOptions`‑methode van de [Html5Options](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/html5options/)‑klasse.

De volgende code‑voorbeeld zet een presentatie om in een HTML5‑document met opmerkingen weergegeven aan de rechterkant van de dia’s.
```java
import com.aspose.slides.*;

NotesCommentsLayoutingOptions layoutingOptions = new NotesCommentsLayoutingOptions();
layoutingOptions.setCommentsPosition(CommentsPositions.Right);

Html5Options html5Options = new Html5Options();
html5Options.setSlidesLayoutOptions(layoutingOptions);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

Het document “output.html” wordt hieronder getoond.

![De opmerkingen in het uitvoer‑HTML5‑document](two_comments_html5.png)

## **FAQ**

### Kan ik bepalen of objectanimaties en dia‑overgangen worden afgespeeld in HTML5?

Ja, HTML5 biedt afzonderlijke opties om [vormanimaties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) en [dia‑overgangen](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) in of uit te schakelen.

### Wordt de uitvoer van opmerkingen ondersteund, en waar kunnen ze ten opzichte van de dia worden geplaatst?

Ja, opmerkingen kunnen in HTML5 worden toegevoegd en geplaatst (bijvoorbeeld aan de rechterkant van de dia) via [lay‑outinstellingen](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) voor notities en opmerkingen.

### Kan ik koppelingen die JavaScript aanroepen overslaan om veiligheids‑ of CSP‑redenen?

Ja, er is een [instelling](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) die u toestaat hyperlinks met JavaScript‑aanroepen over te slaan tijdens het opslaan. Dit helpt naleving van strenge beveiligingsregels.