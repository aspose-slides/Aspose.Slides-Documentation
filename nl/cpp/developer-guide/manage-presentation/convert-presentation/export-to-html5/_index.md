---
title: Presentaties converteren naar HTML5 in C++
linktitle: Presentatie naar HTML5
type: docs
weight: 40
url: /nl/cpp/export-to-html5/
keywords:
- PowerPoint naar HTML5
- OpenDocument naar HTML5
- presentatie naar HTML5
- dia naar HTML5
- PPT naar HTML5
- PPTX naar HTML5
- ODP naar HTML5
- sla PPT op als HTML5
- sla PPTX op als HTML5
- sla ODP op als HTML5
- exporteer PPT naar HTML5
- exporteer PPTX naar HTML5
- exporteer ODP naar HTML5
- C++
- Aspose.Slides
description: "Export PowerPoint‑ en OpenDocument‑presentaties naar responsieve HTML5 met Aspose.Slides voor C++. Bewaar opmaak, animaties en interactiviteit."
---
## **Overzicht**

Dit artikel legt uit hoe je PowerPoint‑presentaties kunt converteren naar HTML5 met Aspose.Slides. Het behandelt basis‑HTML5‑export zonder web‑extensies of extra afhankelijkheden, evenals opties om vormanimaties en dia‑overgangen te beheersen. Het artikel toont ook het standaard PowerPoint‑naar‑HTML‑exportproces, legt uit hoe je HTML5‑output genereert in dia‑weergavemodus, en demonstreert hoe je opmerkingen in het geëxporteerde document kunt opnemen door hun lay‑out te configureren.

## **Export PowerPoint naar HTML5**

Deze C++‑code laat zien hoe je een presentatie exporteert naar HTML5.

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html5);
```

{{% alert color="primary" %}} 
In dit geval krijg je schone HTML. 
{{% /alert %}}

Je kunt de instellingen voor vormanimaties en dia‑overgangen op deze manier specificeren:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto options = System::MakeObject<Html5Options>();
options->set_AnimateShapes(true);
options->set_AnimateTransitions(true);
pres->Save(u"pres.html", SaveFormat::Html5, options);
```

## **Export PowerPoint naar HTML**

Deze C++‑code demonstreert het standaard PowerPoint‑naar‑HTML‑proces:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html);
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

{{% alert title="Opmerking" color="warning" %}} 
Wanneer je deze methode gebruikt om PowerPoint naar HTML te exporteren, kun je door de SVG‑rendering geen stijlen toepassen of specifieke elementen animeren. 
{{% /alert %}}

## **Export PowerPoint naar HTML5‑diaweergave**

**Aspose.Slides** maakt het mogelijk om een PowerPoint‑presentatie te converteren naar een HTML5‑document waarin de dia’s in een dia‑weergavemodus worden getoond. In dit geval, wanneer je het resulterende HTML5‑bestand in een browser opent, zie je de presentatie in dia‑weergavemodus op een webpagina. 

Deze C++‑code demonstreert het PowerPoint‑naar‑HTML5‑diaweergave‑exportproces:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);
pres->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
```

## **Converteer een presentatie naar een HTML5‑document met opmerkingen**

Opmerkingen in PowerPoint zijn een hulpmiddel waarmee gebruikers notities of feedback op dia’s kunnen achterlaten. Ze zijn vooral nuttig in samenwerkingsprojecten, waarbij meerdere personen hun suggesties of opmerkingen bij specifieke dia‑elementen kunnen toevoegen zonder de hoofdinhoud te wijzigen. Elke opmerking toont de naam van de auteur, waardoor het makkelijk is te achterhalen wie de opmerking heeft geplaatst.

Stel, we hebben de volgende PowerPoint‑presentatie opgeslagen in het bestand "sample.pptx".

![Twee opmerkingen op de presentatiedia](two_comments_pptx.png)

Wanneer je een PowerPoint‑presentatie converteert naar een HTML5‑document, kun je eenvoudig aangeven of je opmerkingen uit de presentatie wilt opnemen in het uitvoerdocument. Hiervoor moet je de weergave‑parameters voor opmerkingen opgeven in de `get_NotesCommentsLayouting`‑methode van de [Html5Options](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/html5options/) klasse.

Het volgende code‑voorbeeld converteert een presentatie naar een HTML5‑document met opmerkingen die rechts van de dia’s worden weergegeven.
```cpp
auto html5Options = MakeObject<Html5Options>();
html5Options->get_NotesCommentsLayouting()->set_CommentsPosition(CommentsPositions::Right);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

Het document "output.html" wordt hieronder getoond.

![De opmerkingen in het HTML5‑outputdocument](two_comments_html5.png)

## **FAQ**

**Kan ik bepalen of objectanimaties en dia‑overgangen worden afgespeeld in HTML5?**

Ja, HTML5 biedt afzonderlijke opties om [shape animations](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/html5options/set_animateshapes/) en [slide transitions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/html5options/set_animatetransitions/) in te schakelen of uit te schakelen.

**Wordt output van opmerkingen ondersteund, en waar kunnen ze ten opzichte van de dia worden geplaatst?**

Ja, opmerkingen kunnen worden toegevoegd in HTML5 en gepositioneerd (bijvoorbeeld rechts van de dia) via lay‑outinstellingen voor notities en opmerkingen.

**Kan ik links die JavaScript aanroepen overslaan om veiligheids‑ of CSP‑redenen?**

Ja, er is een [setting](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) die je in staat stelt hyperlinks met JavaScript‑aanroepen tijdens het opslaan over te slaan. Dit helpt te voldoen aan strikte beveiligings‑beleid.