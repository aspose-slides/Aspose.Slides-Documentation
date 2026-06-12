---
title: Presentaties naar HTML5 converteren in .NET
linktitle: Presentatie naar HTML5
type: docs
weight: 40
url: /nl/net/export-to-html5/
keywords:
- PowerPoint naar HTML5
- OpenDocument naar HTML5
- presentatie naar HTML5
- dia naar HTML5
- PPT naar HTML5
- PPTX naar HTML5
- ODP naar HTML5
- opslaan PPT als HTML5
- opslaan PPTX als HTML5
- opslaan ODP als HTML5
- exporteer PPT naar HTML5
- exporteer PPTX naar HTML5
- exporteer ODP naar HTML5
- .NET
- C#
- Aspose.Slides
description: "Exporteer PowerPoint- en OpenDocument-presentaties naar responsieve HTML5 met Aspose.Slides voor .NET. Behoud opmaak, animaties en interactiviteit."
---
## **Overzicht**

Dit artikel legt uit hoe u PowerPoint‑presentaties kunt converteren naar HTML5 met Aspose.Slides. Het behandelt een basis‑HTML5‑export zonder web‑extensies of extra afhankelijkheden, evenals opties om vorm‑animaties en dia‑overgangen te beheren. Het artikel toont ook het standaard PowerPoint‑naar‑HTML‑exportproces, legt uit hoe u HTML5‑output genereert in diaweergavemodus, en laat zien hoe u opmerkingen in het geëxporteerde document kunt opnemen door hun lay‑out te configureren.

## **PowerPoint exporteren naar HTML5**

Deze C#‑code laat zien hoe u een presentatie kunt exporteren naar HTML5 zonder web‑extensies en afhankelijkheden:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html5);
}
```

{{% alert color="primary" %}} 
In dit geval krijgt u schone HTML. 
{{% /alert %}}

U kunt op deze manier instellingen specificeren voor vorm‑animaties en dia‑overgangen:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres5.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = false,
       AnimateTransitions = false
   });
}
```

## **PowerPoint exporteren naar HTML**

Deze C#‑code demonstreert het standaard PowerPoint‑naar‑HTML‑proces:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html);
}
```

In dit geval wordt de presentatie‑inhoud gerenderd via SVG in een vorm als volgt:

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
Wanneer u deze methode gebruikt om PowerPoint naar HTML te exporteren, kunt u door de SVG‑rendering geen stijlen toepassen of specifieke elementen animeren. 
{{% /alert %}}

## **PowerPoint exporteren naar HTML5 in diaweergave**

**Aspose.Slides** stelt u in staat een PowerPoint‑presentatie te converteren naar een HTML5‑document waarin de dia’s in een diaweergavemodus worden gepresenteerd. In dit geval ziet u bij het openen van het resulterende HTML5‑bestand in een browser de presentatie in diaweergavemodus op een webpagina. 

Deze C#‑code demonstreert het exportproces van PowerPoint naar HTML5‑diaweergave:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("HTML5-slide-view.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = true,
       AnimateTransitions = true
   });
}
```

## **Een presentatie omzetten naar een HTML5‑document met opmerkingen**

Opmerkingen in PowerPoint zijn een hulpmiddel waarmee gebruikers notities of feedback op dia’s kunnen achterlaten. Ze zijn vooral nuttig in samenwerkingsprojecten, waarbij meerdere personen hun suggesties of aantekeningen bij specifieke dia‑elementen kunnen toevoegen zonder de hoofdinhoud te wijzigen. Elke opmerking toont de naam van de auteur, zodat duidelijk is wie de opmerking heeft geplaatst.

Stel dat we de volgende PowerPoint‑presentatie hebben opgeslagen in het bestand **"sample.pptx"**.

![Twee opmerkingen op de presentatiedia](two_comments_pptx.png)

Wanneer u een PowerPoint‑presentatie converteert naar een HTML5‑document, kunt u eenvoudig aangeven of u opmerkingen uit de presentatie wilt opnemen in het uiteindelijke document. Hiervoor moet u de weergave‑parameters voor opmerkingen opgeven in de `NotesCommentsLayouting`‑eigenschap van de [Html5Options](https://reference.aspose.com/slides/nl/net/aspose.slides.export/html5options/)‑klasse.

De volgende code‑voorbeeld converteert een presentatie naar een HTML5‑document met opmerkingen die aan de rechterkant van de dia’s worden weergegeven.
```cs
var html5Options = new Html5Options
{
    NotesCommentsLayouting =
    {
        CommentsPosition = CommentsPositions.Right
    }
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```

Het document **"output.html"** wordt weergegeven in de afbeelding hieronder.

![De opmerkingen in het output‑HTML5‑document](two_comments_html5.png)

## **FAQ**

**Kan ik bepalen of object‑animaties en dia‑overgangen worden afgespeeld in HTML5?**

Ja, HTML5 biedt afzonderlijke opties om [shape animations](https://reference.aspose.com/slides/nl/net/aspose.slides.export/html5options/animateshapes/) en [slide transitions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/html5options/animatetransitions/) in te schakelen of uit te schakelen.

**Wordt de weergave van opmerkingen ondersteund en waar kunnen ze ten opzichte van de dia worden geplaatst?**

Ja, opmerkingen kunnen worden toegevoegd in HTML5 en gepositioneerd (bijvoorbeeld aan de rechterkant van de dia) via [layout settings](https://reference.aspose.com/slides/nl/net/aspose.slides.export/html5options/notescommentslayouting/) voor notities en opmerkingen.

**Kan ik links die JavaScript aanroepen overslaan om beveiligings‑ of CSP‑redenen?**

Ja, er is een [setting](https://reference.aspose.com/slides/nl/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) die het mogelijk maakt hyperlinks met JavaScript‑aanroepen over te slaan tijdens het opslaan. Dit helpt te voldoen aan strenge beveiligingsbeleid.