---
title: Recupera e aggiorna le proprietà di visualizzazione della presentazione in C++
linktitle: Proprietà di visualizzazione
type: docs
weight: 80
url: /it/cpp/presentation-view-properties/
keywords:
- proprietà di visualizzazione
- visualizzazione normale
- contenuto della struttura
- icone della struttura
- aggancia divisore verticale
- visualizzazione singola
- stato barra
- dimensione
- regolazione automatica
- zoom predefinito
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Utilizza Aspose.Slides per C++ per configurare il layout della visualizzazione normale, lo zoom delle diapositive e delle note, la spaziatura della griglia e la visibilità dei commenti nelle presentazioni PowerPoint."
---
## **Introduzione**

Nella visualizzazione normale di PowerPoint, la diapositiva appare tra un riquadro laterale per le miniature o un diagramma e un riquadro note nella parte inferiore. Aspose.Slides per C++ espone le preferenze di modifica salvate della presentazione tramite [Presentation::get_ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/). Queste includono il layout dei riquadri, i livelli di zoom, la spaziatura della griglia e la visibilità dei commenti.

## **Informazioni su INormalViewProperties**

Utilizzare [get_NormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) per accedere all'interfaccia [INormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/). [set_ShowOutlineIcons](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_showoutlineicons/) controlla se le icone appaiono accanto ai titoli delle diapositive nella struttura. [set_SnapVerticalSplitter](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_snapverticalsplitter/) consente al riquadro laterale di ripiegarsi nello stato ridotto quando l'utente lo restringe. [set_PreferSingleView](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_prefersingleview/) indica una preferenza per la visualizzazione di un unico riquadro nella finestra completa.

[set_VerticalBarState](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_verticalbarstate/) controlla il divisore tra il riquadro laterale e la diapositiva. [set_HorizontalBarState](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_horizontalbarstate/) controlla il divisore sopra il riquadro note. Entrambi accettano un valore [SplitterBarStateType](https://reference.aspose.com/slides/cpp/aspose.slides/splitterbarstatetype/) di `Minimized`, `Maximized` o `Restored`.

## **Informazioni sul ripristino di INormalViewProperties**

Quando un divisore viene ripristinato, [get_RestoredLeft](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredleft/) fornisce la dimensione salvata del riquadro laterale e [get_RestoredTop](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredtop/) fornisce la dimensione salvata dell'area superiore della diapositiva. Entrambi espongono [INormalViewRestoredProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/). Il suo metodo [set_DimensionSize](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/set_dimensionsize/) accetta una percentuale da 0 a 100, e [set_AutoAdjust](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/set_autoadjust/) controlla se l'editor regola la dimensione quando la finestra viene ridimensionata.

Questo esempio aggiorna una presentazione esistente. Ripristina il divisore orizzontale, imposta la dimensione dell'area superiore della diapositiva esposta da [get_RestoredTop](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredtop/) all'80% con regolazione automatica abilitata, e massimizza il divisore verticale. Abilita inoltre le icone della struttura con [set_ShowOutlineIcons](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_showoutlineicons/) per la visualizzazione della struttura.

```cpp
#include <DOM/INormalViewProperties.h>
#include <DOM/INormalViewRestoredProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <DOM/SplitterBarStateType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto normalView = presentation->get_ViewProperties()->get_NormalViewProperties();
normalView->set_HorizontalBarState(SplitterBarStateType::Restored);
normalView->set_VerticalBarState(SplitterBarStateType::Maximized);
auto restoredTop = normalView->get_RestoredTop();
restoredTop->set_AutoAdjust(true);
restoredTop->set_DimensionSize(80.0f);
normalView->set_ShowOutlineIcons(true);

presentation->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **Imposta il valore di zoom predefinito**

[get_SlideViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_slideviewproperties/) e [get_NotesViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_notesviewproperties/) memorizzano impostazioni di zoom indipendenti per l'editor. Queste impostazioni non influenzano le dimensioni delle diapositive, la riproduzione della presentazione o la risoluzione di esportazione delle immagini.

Questo esempio apre una presentazione esistente e abilita il ridimensionamento automatico con [set_VariableScale](https://reference.aspose.com/slides/cpp/aspose.slides/icommonslideviewproperties/set_variablescale/) per adattare la diapositiva alla finestra di modifica. Per la pagina delle note, disabilita il ridimensionamento automatico e utilizza [set_Scale](https://reference.aspose.com/slides/cpp/aspose.slides/icommonslideviewproperties/set_scale/) per impostare uno zoom fisso dell'80%.

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto viewProperties = presentation->get_ViewProperties();
viewProperties->get_SlideViewProperties()->set_VariableScale(true);
auto notesView = viewProperties->get_NotesViewProperties();
notesView->set_VariableScale(false);
notesView->set_Scale(80);

presentation->Save(u"zoom.pptx", SaveFormat::Pptx);
```

## **Imposta la spaziatura della griglia**

[set_GridSpacing](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_gridspacing/) imposta la distanza tra le linee della griglia di modifica in tutta la presentazione. Accetta un valore positivo in punti, con 72 punti per pollice. Questo esempio stampa la spaziatura corrente in una presentazione esistente e salva una griglia di un quarto di pollice impostando l'intervallo a 18 punti.

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto viewProperties = presentation->get_ViewProperties();
auto gridSpacing = viewProperties->get_GridSpacing();
System::Console::WriteLine(u"Current grid spacing: {0} points", gridSpacing);

viewProperties->set_GridSpacing(18.0f);

presentation->Save(u"grid-spacing.pptx", SaveFormat::Pptx);
```

La griglia si ripete a intervalli fissi. [Guide di disegno](/slides/it/cpp/drawing-guides/) contraddistinguono posizioni orizzontali o verticali singole. Entrambe sono ausili per la modifica e appaiono solo negli editor che le visualizzano. Le presentazioni e le esportazioni in PDF, immagini o SVG le omettono.

## **Mostra o nascondi i commenti all'apertura di una presentazione**

[set_ShowComments](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_showcomments/) memorizza una preferenza che gli editor compatibili usano all'apertura della presentazione. Per una presentazione esistente con commenti, questo esempio stampa l'impostazione corrente e salva una copia con i commenti nascosti. Chiama inoltre [set_LastView](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_lastview/) con [ViewType::SlideView](https://reference.aspose.com/slides/cpp/aspose.slides/viewtype/) in modo che la copia si apra nella vista diapositiva.

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <ViewType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"comments.pptx");

auto viewProperties = presentation->get_ViewProperties();
auto showComments = viewProperties->get_ShowComments();
System::Console::WriteLine(u"Current comment visibility: {0}", showComments);

viewProperties->set_ShowComments(NullableBool::False);
viewProperties->set_LastView(ViewType::SlideView);

presentation->Save(u"comments-hidden.pptx", SaveFormat::Pptx);
```

Nascondere i commenti ne preserva testo, autori, posizioni, risposte e stati. Per modificare i commenti stessi, vedere [Commenti della presentazione](/slides/it/cpp/presentation-comments/). Le impostazioni di esportazione controllano se i commenti appaiono in PDF, HTML, immagini, note o dispense.

## **FAQ**

**Perché la griglia è nascosta quando riapro la presentazione?**

La presentazione memorizza l'intervallo della griglia. Per vedere la griglia, abilita la visibilità della griglia nell'editor.

**La cancellazione delle guide di disegno modifica la spaziatura della griglia?**

No. L'aggiunta, lo spostamento o la rimozione di una guida non alterano l'intervallo della griglia.

**Le diverse sezioni di una presentazione possono avere impostazioni di visualizzazione differenti?**

No. [Presentation::get_ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/) si applica all'intera presentazione.

**Posso salvare impostazioni di visualizzazione diverse per utenti diversi?**

Il file memorizza un unico set di proprietà di visualizzazione per tutti. Un editor può anche applicare le preferenze locali di un utente.

**Posso salvare le impostazioni di visualizzazione in un modello?**

Sì. Le presentazioni create dal modello ereditano le impostazioni di visualizzazione salvate dal modello.