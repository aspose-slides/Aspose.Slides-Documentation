---
title: Recuperare e aggiornare le proprietà di visualizzazione della presentazione in C++
linktitle: Proprietà di visualizzazione
type: docs
weight: 80
url: /it/cpp/presentation-view-properties/
keywords:
- proprietà di visualizzazione
- visualizzazione normale
- contenuto della struttura
- icone della struttura
- aggancio divisore verticale
- visualizzazione singola
- stato della barra
- dimensione
- regolazione automatica
- zoom predefinito
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Scopri le proprietà di visualizzazione di Aspose.Slides per C++ per personalizzare i formati PPT, PPTX e ODP delle diapositive—regola layout, livelli di zoom e impostazioni di visualizzazione."
---
## **Introduzione**

La visualizzazione normale è composta da tre regioni di contenuto: la diapositiva stessa, una regione di contenuto laterale e una regione di contenuto inferiore. Proprietà relative al posizionamento delle diverse regioni di contenuto. Queste informazioni consentono all'applicazione di salvare lo stato della visualizzazione nel file, in modo che al riapertura la visualizzazione sia nello stesso stato in cui la presentazione è stata salvata l'ultima volta.

Il metodo [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/it/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) è stato aggiunto per fornire l'accesso alle proprietà della visualizzazione normale della presentazione.

Le interfacce [INormalViewProperties](https://reference.aspose.com/slides/it/cpp/aspose.slides/inormalviewproperties/), [INormalViewRestoredProperties](https://reference.aspose.com/slides/it/cpp/aspose.slides/inormalviewrestoredproperties/) e i loro discendenti, nonché l'enumerazione [SplitterBarStateType](https://reference.aspose.com/slides/it/cpp/aspose.slides/splitterbarstatetype/) sono state aggiunte.

## **Informazioni su INormalViewProperties**

Rappresenta le proprietà della visualizzazione normale.

La proprietà **ShowOutlineIcons** specifica se l'applicazione deve mostrare le icone quando visualizza il contenuto della struttura in una delle regioni di contenuto della modalità visualizzazione normale.

La proprietà **SnapVerticalSplitter** specifica se il divisore verticale deve scattare a uno stato ridotto quando la regione laterale è sufficientemente piccola.

La proprietà **PreferSingleView** specifica se l'utente preferisce vedere un'unica regione di contenuto a finestra intera anziché la visualizzazione normale standard con tre regioni di contenuto. Se abilitata, l'applicazione può scegliere di visualizzare una delle regioni di contenuto nell'intera finestra.

Le proprietà **VerticalBarState** e **HorizontalBarState** specificano lo stato in cui la barra divisoria verticale o orizzontale deve essere mostrata. Una barra divisoria orizzontale separa la diapositiva dalla regione di contenuto sottostante, mentre la barra divisoria verticale separa la diapositiva dalla regione laterale. I valori possibili sono: **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** e **SplitterBarStateType.Restored**.

Le proprietà **RestoredLeft** e **RestoredTop** specificano le dimensioni della regione superiore o laterale della diapositiva della visualizzazione normale, quando per **VerticalBarState** e **HorizontalBarState** è stato applicato il valore **SplitterBarStateType.Restored**.

## **Informazioni sul ripristino di INormalViewProperties**

Specifica le dimensioni della regione della diapositiva (larghezza quando figlia di RestoredTop, altezza quando figlia di RestoredLeft) della visualizzazione normale, quando la regione è di dimensione variabile ripristinata (né ridotta né massimizzata).

La proprietà **DimensionSize** specifica la dimensione della regione della diapositiva (larghezza quando figlia di RestoredTop, altezza quando figlia di RestoredLeft).

La proprietà **AutoAdjust** specifica se la dimensione della regione di contenuto laterale deve compensare la nuova dimensione durante il ridimensionamento della finestra che contiene la visualizzazione nell'applicazione.

Un esempio è fornito di seguito per mostrare come accedere alle proprietà **ViewProperties.NormalViewProperties** di una presentazione.

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

## **Impostare il valore di zoom predefinito**

Aspose.Slides per C++ ora supporta l'impostazione del valore di zoom predefinito per una presentazione in modo che, al suo apertura, lo zoom sia già impostato. È possibile farlo impostando le [ViewProperties](https://reference.aspose.com/slides/it/cpp/aspose.slides/viewproperties/) di una presentazione. Le proprietà della visualizzazione della diapositiva così come [get_NotesViewProperties](https://reference.aspose.com/slides/it/cpp/aspose.slides/viewproperties/get_notesviewproperties/) possono essere impostate programmaticamente. In questo argomento vedremo, con un esempio, come impostare le proprietà di visualizzazione di una presentazione in Aspose.Slides.

Per impostare le proprietà di visualizzazione, seguite i passaggi seguenti:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/)  
1. Impostare le [ViewProperties](https://reference.aspose.com/slides/it/cpp/aspose.slides/viewproperties/) della presentazione  
1. Scrivere la presentazione come file PPTX  

Nel esempio mostrato di seguito, abbiamo impostato il valore di zoom sia per la visualizzazione della diapositiva sia per la visualizzazione delle note.

``` cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// Impostare le proprietà di visualizzazione della presentazione
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // Valore di zoom in percentuale per la visualizzazione della diapositiva
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // Valore di zoom in percentuale per la visualizzazione delle note 

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```

## **Impostare la spaziatura della griglia**

Utilizzare [Presentation::get_ViewProperties](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/get_viewproperties/) per accedere alle impostazioni di visualizzazione a livello di presentazione. I metodi [IViewProperties::get_GridSpacing](https://reference.aspose.com/slides/it/cpp/aspose.slides/iviewproperties/get_gridspacing/) e [IViewProperties::set_GridSpacing](https://reference.aspose.com/slides/it/cpp/aspose.slides/iviewproperties/set_gridspacing/) leggono o modificano l'intervallo della griglia di editing sottostante. Questa impostazione si applica all'intera presentazione, non a una singola diapositiva. La spaziatura della griglia è specificata in punti, dove 72 punti corrispondono a un pollice. Utilizzare un valore positivo, come richiesto dalla documentazione dell'API.

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

La griglia è diversa dalle [drawing guides](/slides/it/cpp/drawing-guides/). La spaziatura della griglia controlla un intervallo regolare, mentre le guide di disegno sono linee di allineamento orizzontali o verticali posizionate singolarmente. Aggiungere, spostare o cancellare le guide di disegno non modifica la spaziatura della griglia.

Sia la griglia sia le guide di disegno sono ausili di editing. Non vengono renderizzate come contenuto della diapositiva in PDF, immagini, SVG o presentazioni. Memorizzare la spaziatura della griglia non garantisce che un editor la visualizzi: la sua visibilità dipende anche dalle preferenze del visualizzatore o dell'editor.

## **FAQ**

**Perché la griglia non è visibile dopo aver riaperto la presentazione?**  
Il file memorizza la spaziatura della griglia, ma l'editor controlla se la griglia viene visualizzata. Controllare le impostazioni di visibilità della griglia nell'editor.

**La cancellazione delle guide di disegno modifica la spaziatura della griglia?**  
No. Le guide di disegno e la spaziatura della griglia sono impostazioni indipendenti. Cancellare le guide lascia invariato l'intervallo della griglia memorizzato.

**Posso impostare diverse impostazioni di visualizzazione per sezioni diverse di una presentazione?**  
Le [view settings](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/get_viewproperties/) sono definite a livello di presentazione ([Normal View](https://reference.aspose.com/slides/it/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/it/cpp/aspose.slides/viewproperties/get_slideviewproperties/)), non per sezione, quindi un unico set di parametri si applica all'intero documento all'apertura.

**Posso predefinire stati di visualizzazione diversi per utenti diversi?**  
No. Le impostazioni sono memorizzate nel file e sono condivise. Le applicazioni di visualizzazione possono rispettare le preferenze dell'utente, ma il file stesso contiene un unico set di proprietà di visualizzazione.

**Posso preparare un modello con le View Properties predefinite in modo che le nuove presentazioni si aprano nello stesso modo?**  
Sì. Poiché le [view properties](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/get_viewproperties/) sono memorizzate a livello di presentazione, è possibile includerle in un modello e creare nuovi documenti da esso con la stessa configurazione di visualizzazione iniziale.