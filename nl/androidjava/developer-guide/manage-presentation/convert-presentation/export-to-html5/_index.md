---
title: Presentaties converteren naar HTML5 op Android
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
- Sla PPT op als HTML5
- Sla PPTX op als HTML5
- Sla ODP op als HTML5
- Exporteer PPT naar HTML5
- Exporteer PPTX naar HTML5
- Exporteer ODP naar HTML5
- Android
- Java
- Aspose.Slides
description: "Exporteer PowerPoint- en OpenDocument-presentaties naar responsieve HTML5 met Aspose.Slides voor Android via Java. Behoud opmaak, animaties en interactiviteit."
---
## **Overzicht**

Dit artikel legt uit hoe je PowerPoint‑presentaties kunt converteren naar HTML5 met Aspose.Slides. Het behandelt een basis‑HTML5‑export zonder web‑extensies of extra afhankelijkheden, evenals opties om vorm‑animaties en dia‑overgangen te beheersen. Het artikel laat ook het standaard PowerPoint‑naar‑HTML‑exportproces zien, legt uit hoe je HTML5‑output genereert in dia‑weergavemodus, en toont hoe je opmerkingen in het geëxporteerde document kunt opnemen door hun lay‑out te configureren.

## **Exporteer PowerPoint naar HTML5**

Deze Java‑code laat zien hoe je een presentatie naar HTML5 exporteert zonder web‑extensies en afhankelijkheden:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html5);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 
In dit geval krijg je schone HTML. 
{{% /alert %}}

Je wilt mogelijk instellingen voor vorm‑animaties en dia‑overgangen op deze manier opgeven:

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

## **Exporteer PowerPoint naar HTML**

Deze Java‑code demonstreert het standaard PowerPoint‑naar‑HTML‑proces:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
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
Wanneer je deze methode gebruikt om PowerPoint naar HTML te exporteren, kun je door de SVG‑rendering geen stijlen toepassen of specifieke elementen animeren. 
{{% /alert %}}

## **Exporteer PowerPoint naar HTML5‑diaweergave**

**Aspose.Slides** maakt het mogelijk om een PowerPoint‑presentatie te converteren naar een HTML5‑document waarin de dia’s worden weergegeven in een dia‑weergavemodus. In dit geval zie je, wanneer je het resulterende HTML5‑bestand in een browser opent, de presentatie in dia‑weergavemodus op een webpagina. 

Deze Java‑code demonstreert het PowerPoint‑naar‑HTML5‑diaweergave‑exportproces:

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

## **Converteer een presentatie naar een HTML5‑document met opmerkingen**

Opmerkingen in PowerPoint zijn een hulpmiddel waarmee gebruikers notities of feedback op presentatiedia’s kunnen achterlaten. Ze zijn vooral nuttig in samenwerkingsprojecten, waarin meerdere personen hun suggesties of opmerkingen kunnen toevoegen aan specifieke dia‑elementen zonder de hoofdinhoud te wijzigen. Elke opmerking toont de naam van de auteur, waardoor je gemakkelijk kunt zien wie de opmerking heeft geplaatst.

Stel dat we de volgende PowerPoint‑presentatie hebben opgeslagen in het bestand **“sample.pptx”**.

![Twee opmerkingen op de presentatiedia](two_comments_pptx.png)

Wanneer je een PowerPoint‑presentatie naar een HTML5‑document converteert, kun je eenvoudig opgeven of je opmerkingen uit de presentatie in het uitvoerdocument wilt opnemen. Hiervoor moet je de weergave‑parameters voor opmerkingen specificeren in de `getNotesCommentsLayouting`‑methode van de [Html5Options](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/html5options/)‑klasse.

De volgende code‑voorbeeld converteert een presentatie naar een HTML5‑document met opmerkingen die rechts van de dia’s worden weergegeven.
```java
Html5Options html5Options = new Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(CommentsPositions.Right);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

Het document **“output.html”** wordt hieronder getoond.

![De opmerkingen in het output‑HTML5‑document](two_comments_html5.png)

## **FAQ**

**Kan ik bepalen of object‑animaties en dia‑overgangen worden afgespeeld in HTML5?**

Ja, HTML5 biedt afzonderlijke opties om [shape animations](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) en [slide transitions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) in te schakelen of uit te schakelen.

**Wordt de uitvoer van opmerkingen ondersteund, en waar kunnen ze worden geplaatst ten opzichte van de dia?**

Ja, opmerkingen kunnen in HTML5 worden toegevoegd en gepositioneerd (bijvoorbeeld rechts van de dia) via [layout settings](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) voor notities en opmerkingen.

**Kan ik koppelingen die JavaScript aanroepen overslaan om veiligheids‑ of CSP‑redenen?**

Ja, er is een [setting](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) waarmee je hyperlinks met JavaScript‑aanroepen tijdens het opslaan kunt overslaan. Dit helpt om te voldoen aan strikte beveiligingsbeleid.