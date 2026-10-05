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

Dit artikel legt uit hoe u PowerPoint‑presentaties kunt converteren naar HTML5 met Aspose.Slides voor C++. Het behandelt basis‑export, controle van vormanimaties en dia‑overgangen, en commentaarindeling. Het vergelijkt ook de HTML5‑uitvoer met de SVG‑gebaseerde uitvoer van de standaard HTML‑export.

## **Export PowerPoint naar HTML5**

Het volgende voorbeeld laadt een presentatie uit de werkmap en slaat deze op in HTML5‑formaat. Het gebruikt de standaard exportinstellingen; het volgende voorbeeld laat zien hoe u de weergave van animaties expliciet kunt regelen. Vervang het invoerpad door het pad naar uw presentatie.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"pres.html", SaveFormat::Html5);
presentation->Dispose();
```

{{% alert color="info" title="Opmerking" %}}
Naast het HTML‑document schrijft de export ondersteunende CSS‑ en JavaScript‑bestanden voor dia‑styling, animaties, effecten en navigatie. Houd deze bestanden bij het HTML‑document wanneer u de output verplaatst of publiceert. De gegenereerde pagina laadt ook jQuery en Anime.js van openbare CDN’s; zonder hen werken dia‑navigatie en animaties niet.
{{% /alert %}}

Om te exporteren zonder vormanimaties of dia‑overgangen af te spelen, geeft u `false` door aan [set_AnimateShapes](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) en [set_AnimateTransitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/) in [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/). Deze instellingen zijn onafhankelijk, dus u kunt er één inschakelen terwijl u de andere uitschakelt. Het voorbeeld exporteert de presentatie met beide soorten animatie uitgeschakeld in de gegenereerde pagina.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(false);
html5Options->set_AnimateTransitions(false);

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"pres5.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

## **Export PowerPoint naar HTML**

De standaard HTML‑export gebruikt een andere renderingsaanpak: dia‑inhoud wordt weergegeven als SVG binnen een HTML‑pagina. Het volgende voorbeeld converteert een presentatie naar een HTML‑document met deze renderingsaanpak.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"pres.html", SaveFormat::Html);
presentation->Dispose();
```

De vereenvoudigde markup hieronder toont de structuur van de gegenereerde pagina. Het SVG‑element bevat de gerenderde dia‑inhoud; de placeholder‑tekst vertegenwoordigt die inhoud en is geen letterlijke exportoutput.

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Waarschuwing" color="warning" %}}
De op SVG gebaseerde export maakt PowerPoint‑vormen niet beschikbaar als afzonderlijke HTML‑elementen. Gebruik HTML5‑export wanneer u de vorm‑animatie‑ en dia‑overgangsopties nodig hebt die in dit artikel worden getoond.
{{% /alert %}}

## **Export PowerPoint naar HTML5-diaweergave**

HTML5‑export genereert een pagina voor het bekijken en navigeren van de presentatiedia’s in een browser. Dit voorbeeld geeft `true` door aan zowel [set_AnimateShapes](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) als [set_AnimateTransitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/) zodat de geëxporteerde diaweergave effecten uit de bronpresentatie kan afspelen.

Gebruik een presentatie die reeds vormanimaties en dia‑overgangen bevat om het effect van deze instellingen te zien. Het inschakelen voegt geen nieuwe effecten toe aan dia’s die er geen hebben. Open na het exporteren het gegenereerde HTML5‑document in een browser met de bijbehorende ondersteunende bestanden.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

## **Converteer een presentatie naar een HTML5‑document met opmerkingen**

U kunt bestaande dia‑opmerkingen opnemen in de HTML5‑output zodat lezers feedback naast de dia‑inhoud kunnen zien. Het voorbeeld in deze sectie gaat ervan uit dat de bronpresentatie opmerkingen bevat, zoals hieronder geïllustreerd. Het exporteert die opmerkingen; het maakt geen nieuwe aan.

![Twee opmerkingen op de presentatiedia](two_comments_pptx.png)

Geef een [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/) object door aan de [set_SlidesLayoutOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_slideslayoutoptions/) methode van [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/). Roep [set_CommentsPosition](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/set_commentsposition/) aan met `CommentsPositions::Right` uit de [CommentsPositions](https://reference.aspose.com/slides/cpp/aspose.slides.export/commentspositions/) enumeratie om de opmerkingen rechts van elke dia te plaatsen.

Het volgende voorbeeld exporteert de presentatie naar HTML5 met deze commentaarindeling. Een presentatie zonder opmerkingen zal geen commentaartekst weergeven.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/CommentsPositions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto layoutOptions = System::MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_CommentsPosition(CommentsPositions::Right);

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_SlidesLayoutOptions(layoutOptions);

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

![De opmerkingen in het HTML5‑outputdocument](two_comments_html5.png)

## **JavaScript‑hyperlinks uitsluiten tijdens export**

Stel dat `hyperlinks.pptx` tekst bevat met een `javascript:alert('Hello')`‑doel en een gewone `https://example.com/`‑link. Om de JavaScript‑hyperlink tijdens export uit te sluiten, roept u [SaveOptions::set_SkipJavaScriptLinks](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) aan met `true`. De standaardwaarde is `false`, dus deze links worden niet gefilterd tenzij u de optie inschakelt.

Het volgende voorbeeld laadt de presentatie uit de werkmap en exporteert deze met behulp van [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/):

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_SkipJavaScriptLinks(true);

auto presentation = System::MakeObject<Presentation>(u"hyperlinks.pptx");
presentation->Save(u"filtered-html5.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

Het geëxporteerde bestand laat de JavaScript‑hyperlink weg, maar behoudt de tekst en de gewone HTTPS‑link. De bronpresentatie blijft ongewijzigd.

Deze optie filtert JavaScript‑hyperlinks; hij verwijdert niet alle scripts of andere actieve inhoud, noch garandeert hij CSP‑naleving. Bijvoorbeeld, HTML5‑output bevat nog steeds scripts voor dia‑navigatie en animaties.

## **FAQ**

**Kan ik regelen of objectanimaties en dia‑overgangen worden afgespeeld in HTML5?**

Ja, HTML5‑export biedt afzonderlijke opties om [vormanimaties](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) en [dia‑overgangen](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/) in te schakelen of uit te schakelen.

**Worden opmerkingen ondersteund, en waar kunnen ze ten opzichte van de dia worden geplaatst?**

Ja, bestaande opmerkingen kunnen worden opgenomen in de HTML5‑output en via [indelingsinstellingen](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_slideslayoutoptions/) voor notities en opmerkingen gepositioneerd worden (bijvoorbeeld rechts van de dia).

**Kan ik links die JavaScript oproepen overslaan om veiligheids‑ of CSP‑redenen?**

Ja, de [set_SkipJavaScriptLinks](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) methode stelt u in staat om hyperlinks met JavaScript‑oproepen over te slaan tijdens het opslaan. De standaardwaarde is `false`. Zie [JavaScript‑hyperlinks uitsluiten tijdens export](/slides/nl/cpp/export-to-html5/#exclude-javascript-hyperlinks-during-export) voor een HTML5‑exportvoorbeeld en de reikwijdte van het filter. Deze instelling verwijdert niet de JavaScript die door de HTML5‑viewer wordt gebruikt voor navigatie en animaties.