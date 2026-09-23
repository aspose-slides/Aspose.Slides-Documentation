---
title: Recupera e Aggiorna le Proprietà di Visualizzazione della Presentazione in C++
linktitle: Proprietà di Visualizzazione
type: docs
weight: 80
url: /it/cpp/presentation-view-properties/
keywords:
- proprietà di visualizzazione
- visualizzazione normale
- contenuto scaletta
- icone della scaletta
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
description: "Scopri le proprietà di visualizzazione di Aspose.Slides per C++ per personalizzare i formati PPT, PPTX e ODP—regola layout, livelli di zoom e impostazioni di visualizzazione."
---
## **Introduzione**

La visualizzazione normale è composta da tre aree di contenuto: la diapositiva stessa, un'area di contenuto laterale e un'area di contenuto inferiore. Proprietà relative al posizionamento delle diverse aree di contenuto. Queste informazioni consentono all'applicazione di salvare lo stato della visualizzazione nel file, in modo che, al riapertura, la visualizzazione sia nello stesso stato in cui la presentazione è stata salvata l'ultima volta.

Il metodo [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/it/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) è stato aggiunto per fornire l'accesso alle proprietà della visualizzazione normale di una presentazione. 

Le interfacce [INormalViewProperties](https://reference.aspose.com/slides/it/cpp/aspose.slides/inormalviewproperties/), [INormalViewRestoredProperties](https://reference.aspose.com/slides/it/cpp/aspose.slides/inormalviewrestoredproperties/) e i loro discendenti, l'enumerazione [SplitterBarStateType](https://reference.aspose.com/slides/it/cpp/aspose.slides/splitterbarstatetype/) sono state aggiunte.

## **Informazioni su INormalViewProperties**

Rappresenta le proprietà della visualizzazione normale.

La proprietà **ShowOutlineIcons** specifica se l'applicazione deve mostrare le icone quando visualizza il contenuto della scaletta in una qualsiasi delle aree di contenuto della modalità visualizzazione normale.

La proprietà **SnapVerticalSplitter** specifica se il divisore verticale deve aderire a uno stato ridotto quando l'area laterale è sufficientemente piccola.

La proprietà **PreferSingleView** specifica se l'utente preferisce vedere un'unica area di contenuto a finestra intera rispetto alla visualizzazione normale standard con tre aree di contenuto. Se abilitata, l'applicazione può scegliere di visualizzare una delle aree di contenuto in tutta la finestra.

Le proprietà **VerticalBarState** e **HorizontalBarState** specificano lo stato in cui la barra divisoria orizzontale o verticale deve essere mostrata. Una barra divisoria orizzontale separa la diapositiva dall'area di contenuto sotto la diapositiva, la barra divisoria verticale separa la diapositiva dall'area di contenuto laterale. I valori possibili sono: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** e **SplitterBarStateType.Restored**.

Le proprietà **RestoredLeft** e **RestoredTop** specificano le dimensioni dell'area superiore o laterale della diapositiva nella visualizzazione normale, quando il valore **SplitterBarStateType.Restored** è applicato rispettivamente a **VerticalBarState** e **HorizontalBarState**.

## **Informazioni sul ripristino di INormalViewProperties**

Specifică le dimensioni dell'area della diapositiva (larghezza quando è figlia di RestoredTop, altezza quando è figlia di RestoredLeft) nella visualizzazione normale, quando l'area ha una dimensione ripristinata variabile (né ridotta né massimizzata).

La proprietà **DimensionSize** specifica le dimensioni dell'area della diapositiva (larghezza quando è figlia di restoredTop, altezza quando è figlia di restoredLeft).

La proprietà **AutoAdjust** specifica se le dimensioni dell'area di contenuto laterale devono compensare la nuova dimensione quando si ridimensiona la finestra contenente la visualizzazione all'interno dell'applicazione.

Un esempio è mostrato di seguito per indicare come accedere alle proprietà **ViewProperties.NormalViewProperties** di una presentazione.

``` cpp
#include <DOM/INormalViewProperties.h>
#include <DOM/INormalViewRestoredProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <DOM/SplitterBarStateType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"demo.pptx");
pres->get_ViewProperties()->get_NormalViewProperties()->set_HorizontalBarState(SplitterBarStateType::Restored);
pres->get_ViewProperties()->get_NormalViewProperties()->set_VerticalBarState(SplitterBarStateType::Maximized);

// Ripristina le proprietà di visualizzazione della presentazione
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **Imposta il valore di zoom predefinito**

Aspose.Slides per C++ supporta ora l'impostazione del valore di zoom predefinito per una presentazione in modo che, quando la presentazione viene aperta, lo zoom sia già impostato. Questo può essere fatto impostando le [ViewProperties](https://reference.aspose.com/slides/it/cpp/aspose.slides/viewproperties/) di una presentazione. Le proprietà della visualizzazione della diapositiva così come [get_NotesViewProperties](https://reference.aspose.com/slides/it/cpp/aspose.slides/viewproperties/get_notesviewproperties/) possono essere impostate programmaticamente. In questo argomento vedremo, con un esempio, come impostare le proprietà di visualizzazione di una presentazione in Aspose.Slides.

Per impostare le proprietà di visualizzazione, seguire i passaggi seguenti:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/)
1. Impostare le [Properties](https://reference.aspose.com/slides/it/cpp/aspose.slides/viewproperties/) di visualizzazione della presentazione
1. Scrivere la presentazione come file PPTX

Nell'esempio mostrato di seguito, abbiamo impostato il valore di zoom per la visualizzazione della diapositiva e per quella delle note.

``` cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// Impostazione delle proprietà di visualizzazione della presentazione
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // Valore di zoom in percentuale per la visualizzazione della diapositiva
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // Valore di zoom in percentuale per la visualizzazione delle note 

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```

## **Imposta la spaziatura della griglia**

Utilizzare [Presentation::get_ViewProperties](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/get_viewproperties/) per accedere alle impostazioni di visualizzazione a livello di presentazione. I metodi [IViewProperties::get_GridSpacing](https://reference.aspose.com/slides/it/cpp/aspose.slides/iviewproperties/get_gridspacing/) e [IViewProperties::set_GridSpacing](https://reference.aspose.com/slides/it/cpp/aspose.slides/iviewproperties/set_gridspacing/) leggono o modificano l'intervallo della griglia di editing sottostante. Questa impostazione si applica all'intera presentazione, non a una diapositiva singola. La spaziatura della griglia è specificata in punti, dove 72 punti corrispondono a un pollice. Utilizzare un valore positivo, come richiesto dalla documentazione dell'API.

L'esempio seguente apre un file `demo.pptx` esistente, stampa la spaziatura della griglia corrente, imposta un intervallo di un quarto di pollice e salva il risultato.

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto gridSpacing = presentation->get_ViewProperties()->get_GridSpacing();
System::Console::WriteLine(u"Current grid spacing: {0} points", gridSpacing);

presentation->get_ViewProperties()->set_GridSpacing(18.0f);
presentation->Save(u"grid-spacing.pptx", SaveFormat::Pptx);
```

La griglia è diversa dalle [guide di disegno](/slides/it/cpp/drawing-guides/). La spaziatura della griglia controlla un intervallo regolare, mentre le guide di disegno sono linee di allineamento orizzontali o verticali posizionate individualmente. Aggiungere, spostare o cancellare le guide di disegno non modifica la spaziatura della griglia.

Sia la griglia che le guide di disegno sono ausili per la modifica. Non vengono renderizzate come contenuto della diapositiva in PDF, immagini, SVG o presentazioni. Memorizzare la spaziatura della griglia non garantisce che un editor la visualizzi: la sua visibilità dipende anche dalle preferenze del visualizzatore o dell'editor.

## **Mostra o nascondi i commenti all'apertura di una presentazione**

Utilizzare [Presentation::get_ViewProperties](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/get_viewproperties/) per accedere alle impostazioni di visualizzazione a livello di presentazione. Utilizzare [IViewProperties::get_ShowComments](https://reference.aspose.com/slides/it/cpp/aspose.slides/iviewproperties/get_showcomments/) e [IViewProperties::set_ShowComments](https://reference.aspose.com/slides/it/cpp/aspose.slides/iviewproperties/set_showcomments/) per memorizzare una preferenza su se i commenti debbano essere mostrati quando la presentazione viene aperta in PowerPoint o in un altro editor compatibile.

Questa impostazione controlla solo la preferenza di visualizzazione memorizzata. Non aggiunge, rimuove, modifica o risolve i commenti. Nascondere i commenti ne preserva il contenuto, gli autori, le posizioni, le risposte e gli stati. Vedere [Presentation Comments](/slides/it/cpp/presentation-comments/) per le operazioni che modificano i commenti stessi.

L'esempio seguente richiede un file `comments.pptx` esistente contenente commenti. Stampa l'impostazione di visibilità corrente, richiede di nascondere i commenti e salva un nuovo PPTX senza rimuovere alcun commento. Utilizza inoltre [IViewProperties::set_LastView](https://reference.aspose.com/slides/it/cpp/aspose.slides/iviewproperties/set_lastview/) con [ViewType::SlideView](https://reference.aspose.com/slides/it/cpp/aspose.slides/viewtype/) per configurare la visualizzazione di editing iniziale insieme alla visibilità dei commenti.

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
auto showComments = presentation->get_ViewProperties()->get_ShowComments();
System::Console::WriteLine(u"Current comment visibility: {0}", showComments);

presentation->get_ViewProperties()->set_ShowComments(NullableBool::False);
presentation->get_ViewProperties()->set_LastView(ViewType::SlideView);
presentation->Save(u"comments-hidden.pptx", SaveFormat::Pptx);
```

Questa impostazione non determina se i commenti siano inclusi nelle esportazioni PDF, HTML, immagine, note o diapositive. Configurare separatamente le opzioni specifiche di esportazione rilevanti.

## **FAQ**

**Perché la griglia non è visibile dopo aver riaperto la presentazione?**

Il file memorizza la spaziatura della griglia, ma l'editor controlla se la griglia è visualizzata. Verificare le impostazioni di visibilità della griglia nell'editor.

**La cancellazione delle guide di disegno modifica la spaziatura della griglia?**

No. Le guide di disegno e la spaziatura della griglia sono impostazioni indipendenti. Cancellare le guide lascia invariato l'intervallo di griglia memorizzato.

**Posso impostare impostazioni di visualizzazione diverse per sezioni diverse di una presentazione?**

Le [impostazioni di visualizzazione](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/get_viewproperties/) sono definite a livello di presentazione ([Normal View](https://reference.aspose.com/slides/it/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/it/cpp/aspose.slides/viewproperties/get_slideviewproperties/)), non per sezione, quindi un unico set di parametri si applica all'intero documento all'apertura.

**Posso predefinire stati di visualizzazione diversi per utenti diversi?**

No. Le impostazioni sono memorizzate nel file e vengono condivise. Le applicazioni di visualizzazione possono rispettare le preferenze dell'utente, ma il file stesso contiene un unico set di proprietà di visualizzazione.

**Posso preparare un modello con le proprietà di visualizzazione predefinite in modo che le nuove presentazioni si aprano allo stesso modo?**

Sì. Poiché le [proprietà di visualizzazione](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/get_viewproperties/) sono memorizzate a livello di presentazione, è possibile incorporarle in un modello e creare nuovi documenti da esso con la stessa configurazione di visualizzazione iniziale.