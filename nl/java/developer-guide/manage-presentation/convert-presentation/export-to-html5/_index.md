---
title: Presentaties converteren naar HTML5 in Java
linktitle: Presentatie naar HTML5
type: docs
weight: 40
url: /nl/java/export-to-html5/
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
- Java
- Aspose.Slides
description: "Exporteer PowerPoint- en OpenDocument-presentaties naar responsieve HTML5 met Aspose.Slides voor Java. Behoud opmaak, animaties en interactiviteit."
---
## **Overzicht**

Dit artikel legt uit hoe u PowerPoint‑presentaties naar HTML5 converteert met Aspose.Slides. Het behandelt basis‑HTML5‑export zonder webextensies of extra afhankelijkheden, evenals opties voor het beheersen van vormanimaties en diaovergangen. Het artikel toont ook het standaard PowerPoint‑naar‑HTML‑exportproces, legt uit hoe u HTML5‑output in diaweergavemodus genereert, en demonstreert hoe u opmerkingen in het geëxporteerde document kunt opnemen door hun lay‑out te configureren.

## **PowerPoint exporteren naar HTML5**

Deze Java‑code laat zien hoe u een presentatie naar HTML5 exporteert zonder webextensies en afhankelijkheden:

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

U kunt instellingen voor vormanimaties en diaovergangen op deze manier opgeven:

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

In dit geval wordt de inhoud van de presentatie gerenderd via SVG in een vorm als deze:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Opmerking" color="warning" %}}Wanneer u deze methode gebruikt om PowerPoint naar HTML te exporteren, zult u door de SVG‑rendering geen stijlen kunnen toepassen of specifieke elementen animeren.{{% /alert %}}

## **PowerPoint exporteren naar HTML5‑diaweergave**

**Aspose.Slides** stelt u in staat een PowerPoint‑presentatie te converteren naar een HTML5‑document waarin de dia's worden gepresenteerd in diaweergavemodus. In dit geval, wanneer u het resulterende HTML5‑bestand in een browser opent, ziet u de presentatie in diaweergavemodus op een webpagina.

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

## **Presentaties converteren naar HTML5‑documenten met opmerkingen**

Opmerkingen in PowerPoint zijn een hulpmiddel waarmee gebruikers notities of feedback op presentatiedia’s kunnen achterlaten. Ze zijn vooral nuttig in samenwerkingsprojecten, waarbij meerdere personen hun suggesties of aantekeningen bij specifieke diavermeldingen kunnen toevoegen zonder de hoofdinhoud te wijzigen. Elke opmerking toont de naam van de auteur, zodat u gemakkelijk kunt zien wie de opmerking heeft geplaatst.

Stel dat we de volgende PowerPoint‑presentatie hebben opgeslagen in het bestand “sample.pptx”.

![Twee opmerkingen op de presentatiedia](two_comments_pptx.png)

Wanneer u een PowerPoint‑presentatie naar een HTML5‑document converteert, kunt u eenvoudig aangeven of de opmerkingen uit de presentatie in het uitvoerdocument moeten worden meegenomen. Geef hiervoor de weergave‑parameters voor opmerkingen door aan de `setSlidesLayoutOptions`‑methode van de [Html5Options](https://reference.aspose.com/slides/nl/java/com.aspose.slides/html5options/)‑klasse.

De volgende codevoorbeelden converteren een presentatie naar een HTML5‑document met opmerkingen weergegeven rechts van de dia’s.
```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();

NotesCommentsLayoutingOptions layoutingOptions = new NotesCommentsLayoutingOptions();
layoutingOptions.setCommentsPosition(CommentsPositions.Right);
html5Options.setSlidesLayoutOptions(layoutingOptions);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

Het “output.html”‑document wordt getoond in de afbeelding hieronder.

![De opmerkingen in het HTML5‑uitvoerdocument](two_comments_html5.png)

## **FAQ**

### Kan ik regelen of objectanimaties en diaovergangen worden afgespeeld in HTML5?

Ja, HTML5 biedt afzonderlijke opties om [shape animations](https://reference.aspose.com/slides/nl/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) en [slide transitions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) in of uit te schakelen.

### Wordt de uitvoer van opmerkingen ondersteund, en waar kunnen ze ten opzichte van de dia worden geplaatst?

Ja, opmerkingen kunnen in HTML5 worden toegevoegd en gepositioneerd (bijvoorbeeld rechts van de dia) via [layout settings](https://reference.aspose.com/slides/nl/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) voor notities en opmerkingen.

### Kan ik koppelingen die JavaScript aanroepen overslaan om veiligheids‑ of CSP‑redenen?

Ja, er is een [setting](https://reference.aspose.com/slides/nl/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) die het mogelijk maakt hyperlinks met JavaScript‑aanroepen over te slaan tijdens het opslaan. Dit helpt te voldoen aan strikte beveiligings‑beleid.