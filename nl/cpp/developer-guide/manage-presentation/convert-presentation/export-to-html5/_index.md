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
- PPT opslaan als HTML5
- PPTX opslaan als HTML5
- ODP opslaan als HTML5
- PPT exporteren naar HTML5
- PPTX exporteren naar HTML5
- ODP exporteren naar HTML5
- C++
- Aspose.Slides
description: "Exporteer PowerPoint- en OpenDocument-presentaties naar responsieve HTML5 met Aspose.Slides voor C++. Behoud opmaak, animaties en interactiviteit."
---
## **Overzicht**

Dit artikel legt uit hoe u PowerPoint‑presentaties naar HTML5 kunt converteren met Aspose.Slides. Het behandelt basale HTML5‑export zonder web‑extensies of extra afhankelijkheden, evenals opties om vormanimaties en dia‑overgangen te regelen. Het artikel toont ook het standaard PowerPoint‑naar‑HTML‑exportproces, legt uit hoe u HTML5‑output in dia‑weergavemodus kunt genereren, en demonstreert hoe u opmerkingen in het geëxporteerde document kunt opnemen door hun lay‑out te configureren.

## **PowerPoint exporteren naar HTML5**

Deze C++‑code laat zien hoe u een presentatie naar HTML5 exporteert.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html5);
```

{{% alert color="info" %}} 
In dit geval krijgt u schone HTML. 
{{% /alert %}}

U kunt op deze manier instellingen voor vormanimaties en dia‑overgangen opgeven:

```cpp
#include <DOM/Presentation.h>
#include <Export/Html5Options.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto options = System::MakeObject<Html5Options>();
options->set_AnimateShapes(true);
options->set_AnimateTransitions(true);
pres->Save(u"pres.html", SaveFormat::Html5, options);
```

## **PowerPoint exporteren naar HTML**

Deze C++‑code toont het standaard PowerPoint‑naar‑HTML‑proces:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html);
```

In dit geval wordt de presentatie‑inhoud via SVG weergegeven in een vorm zoals deze:

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
Wanneer u deze methode gebruikt om PowerPoint naar HTML te exporteren, kunt u door de SVG‑weergave geen stijlen toepassen of specifieke elementen animeren. 
{{% /alert %}}

## **PowerPoint exporteren naar HTML5‑diaweergave**

**Aspose.Slides** stelt u in staat een PowerPoint‑presentatie te converteren naar een HTML5‑document waarin de dia’s worden weergegeven in dia‑weergavemodus. In dit geval ziet u bij het openen van het resulterende HTML5‑bestand in een browser de presentatie in dia‑weergavemodus op een webpagina. 

Deze C++‑code toont het PowerPoint‑naar‑HTML5‑diaweergave‑exportproces:

```c++
#include <DOM/Presentation.h>
#include <Export/Html5Options.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);
pres->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
```

## **Een presentatie converteren naar een HTML5‑document met opmerkingen**

Opmerkingen in PowerPoint zijn een hulpmiddel waarmee gebruikers notities of feedback op presentatiedia’s kunnen achterlaten. Ze zijn vooral nuttig in samenwerkingsprojecten, waarbij meerdere personen hun suggesties of opmerkingen kunnen toevoegen aan specifieke dia‑elementen zonder de hoofdinhoud te wijzigen. Elke opmerking toont de naam van de auteur, waardoor het makkelijk is te zien wie de opmerking heeft geplaatst.

Stel, we hebben de volgende PowerPoint‑presentatie opgeslagen in het bestand "sample.pptx".

![Twee opmerkingen op de presentatiedia](two_comments_pptx.png)

Wanneer u een PowerPoint‑presentatie converteert naar een HTML5‑document, kunt u eenvoudig aangeven of u opmerkingen uit de presentatie wilt opnemen in het uitvoerdocument. Daartoe moet u de weergave‑parameters voor opmerkingen opgeven in de `get_NotesCommentsLayouting`‑methode van de [Html5Options](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/html5options/)‑klasse.

De volgende code‑voorbeeld converteert een presentatie naar een HTML5‑document met opmerkingen die rechts van de dia’s worden weergegeven.
```cpp
#include <DOM/Presentation.h>
#include <Export/CommentsPositions.h>
#include <Export/Html5Options.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto layoutingOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutingOptions->set_CommentsPosition(CommentsPositions::Right);

auto html5Options = MakeObject<Html5Options>();
html5Options->set_SlidesLayoutOptions(layoutingOptions);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

Het document "output.html" wordt hieronder weergegeven.

![De opmerkingen in het geëxporteerde HTML5‑document](two_comments_html5.png)

## **Veelgestelde vragen**

### Kan ik bepalen of objectanimaties en dia‑overgangen worden afgespeeld in HTML5?

Ja, HTML5 biedt afzonderlijke opties om [vormanimaties](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/html5options/set_animateshapes/) en [dia‑overgangen](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/html5options/set_animatetransitions/) in of uit te schakelen.

### Wordt de weergave van opmerkingen ondersteund, en waar kunnen ze ten opzichte van de dia worden geplaatst?

Ja, opmerkingen kunnen in HTML5 worden toegevoegd en gepositioneerd (bijvoorbeeld rechts van de dia) via layout‑instellingen voor notities en opmerkingen.

### Kan ik links die JavaScript aanroepen overslaan om veiligheids‑ of CSP‑redenen?

Ja, er is een [instelling](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) die het mogelijk maakt om hyperlinks met JavaScript‑aanroepen over te slaan tijdens het opslaan. Dit helpt te voldoen aan strenge beveiligingsbeleid.