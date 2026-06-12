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

Dit artikel legt uit hoe u PowerPoint‑presentaties converteert naar HTML5 met Aspose.Slides. Het behandelt de basis‑HTML5‑export zonder web‑extensies of extra afhankelijkheden, evenals opties voor het beheersen van vormanimaties en dia‑overgangen. Het artikel toont tevens het standaard PowerPoint‑naar‑HTML‑exportproces, legt uit hoe u HTML5‑output genereert in slide‑view‑modus, en demonstreert hoe u opmerkingen in het geëxporteerde document kunt opnemen door hun lay‑out te configureren.

## **PowerPoint exporteren naar HTML5**

Deze Java‑code laat zien hoe u een presentatie exporteert naar HTML5 zonder web‑extensies en afhankelijkheden:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html5);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 
In dit geval krijgt u schone HTML. 
{{% /alert %}}

U kunt op deze manier instellingen voor vormanimaties en dia‑overgangen opgeven:

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

## **PowerPoint exporteren naar HTML**

Deze Java‑code demonstreert het standaard PowerPoint‑naar‑HTML‑proces:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
}
```

In dit geval wordt de inhoud van de presentatie weergegeven via SVG in een vorm als deze:

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
Wanneer u deze methode gebruikt om PowerPoint te exporteren naar HTML, kunt u vanwege de SVG‑weergave geen stijlen toepassen of specifieke elementen animeren. 
{{% /alert %}}

## **PowerPoint exporteren naar HTML5 slide‑view**

**Aspose.Slides** maakt het mogelijk om een PowerPoint‑presentatie te converteren naar een HTML5‑document waarin de dia's worden weergegeven in een slide‑view‑modus. In dit geval, wanneer u het resulterende HTML5‑bestand in een browser opent, ziet u de presentatie in slide‑view‑modus op een webpagina. 

Deze Java‑code demonstreert het PowerPoint‑naar‑HTML5‑slide‑view‑exportproces:

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

## **Presentaties converteren naar HTML5‑documenten met opmerkingen**

Opmerkingen in PowerPoint zijn een hulpmiddel waarmee gebruikers notities of feedback kunnen achterlaten op presentatiedia's. Ze zijn vooral nuttig in samenwerkingsprojecten, waarbij meerdere personen hun suggesties of opmerkingen bij specifieke dia‑elementen kunnen toevoegen zonder de hoofdinhoud te wijzigen. Elke opmerking toont de naam van de auteur, waardoor het eenvoudig is te zien wie de opmerking heeft geplaatst.

Stel dat we de volgende PowerPoint‑presentatie hebben opgeslagen in het bestand "sample.pptx".

![Twee opmerkingen op de presentatiedia](two_comments_pptx.png)

Wanneer u een PowerPoint‑presentatie converteert naar een HTML5‑document, kunt u eenvoudig opgeven of u opmerkingen uit de presentatie in het uitvoerdocument wilt opnemen. Hiervoor moet u de weergave‑parameters voor opmerkingen opgeven in de `getNotesCommentsLayouting`‑methode van de [Html5Options](https://reference.aspose.com/slides/nl/java/com.aspose.slides/html5options/)‑klasse.

Het volgende code‑voorbeeld converteert een presentatie naar een HTML5‑document met opmerkingen die rechts van de dia's worden weergegeven.
```java
Html5Options html5Options = new Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(CommentsPositions.Right);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

Het document "output.html" wordt hieronder weergegeven.

![De opmerkingen in het uitvoer‑HTML5‑document](two_comments_html5.png)

## **Veelgestelde vragen**

**Kan ik regelen of object‑animaties en dia‑overgangen worden afgespeeld in HTML5?**

Ja, HTML5 biedt afzonderlijke opties om [shape animations](https://reference.aspose.com/slides/nl/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) en [slide transitions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) in of uit te schakelen.

**Wordt de uitvoer van opmerkingen ondersteund, en waar kunnen ze ten opzichte van de dia geplaatst worden?**

Ja, opmerkingen kunnen in HTML5 worden toegevoegd en via [layout settings](https://reference.aspose.com/slides/nl/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) voor notities en opmerkingen worden gepositioneerd (bijvoorbeeld rechts van de dia).

**Kan ik koppelingen die JavaScript aanroepen overslaan om veiligheids‑ of CSP‑redenen?**

Ja, er is een [setting](https://reference.aspose.com/slides/nl/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) die u in staat stelt hyperkoppelingen met JavaScript‑oproepen over te slaan tijdens het opslaan. Dit helpt te voldoen aan strenge beveiligingsbeleid.