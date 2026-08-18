---
title: Gestisci intestazioni e piè di pagina della presentazione in C++
linktitle: Intestazione e Piè di pagina
type: docs
weight: 140
url: /it/cpp/presentation-header-and-footer/
keywords:
- intestazione
- testo intestazione
- piè di pagina
- testo piè di pagina
- imposta intestazione
- imposta piè di pagina
- opuscolo
- note
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Scopri come gestire i segnaposti di piè di pagina, data/ora, numero diapositiva e intestazione su diapositive, pagine delle note e opuscoli con Aspose.Slides per C++."
---
## **Panoramica**

PowerPoint utilizza segnaposti di intestazione e piè di pagina diversi a seconda del tipo di pagina. Aspose.Slides per C++ consente di controllare il testo e la visibilità di questi segnaposti tramite le interfacce del gestore intestazione/piè di pagina.

I segnaposti disponibili dipendono dall'ambito:

| Ambito | Intestazione | Piè di pagina | Data/ora | Numero diapositiva/pagina |
|---|---|---|---|---|
| Diapositiva regolare | No | Sì | Sì | Sì |
| Master delle note | Sì | Sì | Sì | Sì |
| Diapositiva delle note | Sì | Sì | Sì | Sì |
| Master degli opuscoli | Sì | Sì | Sì | Sì |

Una diapositiva di presentazione regolare non ha un segnaposto di intestazione. Le intestazioni sono disponibili nelle pagine delle note e negli opuscoli. Per le diapositive regolari, utilizzare invece i segnaposti di piè di pagina, data/ora e numero diapositiva.

L'ambito di una modifica dipende dal gestore che si utilizza. L'interfaccia [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/it/cpp/aspose.slides/islideheaderfootermanager/) controlla una diapositiva regolare. L'interfaccia [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/cpp/aspose.slides/inotesslideheaderfootermanager/) controlla una diapositiva delle note. I gestori master e layout possono anche propagare le impostazioni alle diapositive dipendenti, mentre l'interfaccia [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/cpp/aspose.slides/imasterhandoutslideheaderfootermanager/) controlla il master degli opuscoli.

## **Imposta Piè di pagina, Data/Ora e Numeri Diapositiva su Diapositive Regolari**

Per le diapositive regolari, il flusso di lavoro di base consiste nell'accedere al gestore intestazione/piè di pagina di ciascuna diapositiva, impostare il testo del piè di pagina e della data/ora, abilitare i segnaposti richiesti e salvare la presentazione. I numeri di diapositiva sono generati dalla presentazione, quindi è necessario controllare solo la loro visibilità.

Utilizzare [`SetFooterText`](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootertext/) e [`SetDateTimeText`](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibaseslideheaderfootermanager/setdatetimetext/) per impostare il testo, e utilizzare [`SetFooterVisibility`](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootervisibility/), [`SetDateTimeVisibility`](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibaseslideheaderfootermanager/setdatetimevisibility/), e [`SetSlideNumberVisibility`](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibaseslideheaderfootermanager/setslidenumbervisibility/) per mostrare i corrispondenti segnaposti.

Il seguente esempio completo applica lo stesso piè di pagina, testo data/ora e visibilità del numero diapositiva a tutte le diapositive regolari:

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

for (const auto& slide : System::IterateOver(presentation->get_Slides()))
{
    auto headerFooterManager = slide->get_HeaderFooterManager();

    headerFooterManager->SetFooterText(u"Company Confidential");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_slide_footers.pptx", SaveFormat::Pptx);
```

Se è necessario aggiornare solo una diapositiva, accedere direttamente a quella diapositiva tramite [`Presentation::get_Slide`](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/get_slide/) invece di iterare l'intera collezione di diapositive.

## **Imposta Intestazioni e Piè di pagina sul Master delle Note**

Il master delle note definisce la formattazione comune e il comportamento dei segnaposti per le pagine delle note. Utilizzare l'interfaccia [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/cpp/aspose.slides/imasternotesslideheaderfootermanager/) quando si desidera modificare solo il master delle note.

Il seguente esempio imposta intestazione, piè di pagina e testo data/ora sul master delle note e rende visibili tutti i segnaposti supportati su quel master:

```cpp
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideHeaderFooterManager.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();

if (masterNotesSlide != nullptr)
{
    auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderText(u"Notes header");
    headerFooterManager->SetHeaderVisibility(true);

    headerFooterManager->SetFooterText(u"Notes footer");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_notes_master_footers.pptx", SaveFormat::Pptx);
```

Il metodo [`IMasterNotesSlideManager::get_MasterNotesSlide`](https://reference.aspose.com/slides/it/cpp/aspose.slides/imasternotesslidemanager/get_masternotesslide/) restituisce `nullptr` quando la presentazione non contiene un master delle note.

## **Applica le Impostazioni del Master delle Note alle Diapositive Note Figlie**

Un master delle note può applicare le impostazioni di intestazione e piè di pagina a se stesso e a tutte le diapositive delle note dipendenti. Utilizzare i metodi di propagazione dedicati su [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/cpp/aspose.slides/imasternotesslideheaderfootermanager/) quando le stesse impostazioni devono essere applicate all'intera gerarchia delle note.

Ad esempio, [`SetHeaderAndChildHeadersText`](https://reference.aspose.com/slides/it/cpp/aspose.slides/imasternotesslideheaderfootermanager/setheaderandchildheaderstext/) e [`SetHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/it/cpp/aspose.slides/imasternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) aggiornano l'intestazione del master delle note e tutte le intestazioni figlie. Metodi equivalenti sono disponibili per i piè di pagina, data/ora e numeri di diapositiva.

```cpp
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideHeaderFooterManager.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();

if (masterNotesSlide != nullptr)
{
    auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderAndChildHeadersText(u"Notes header");
    headerFooterManager->SetHeaderAndChildHeadersVisibility(true);

    headerFooterManager->SetFooterAndChildFootersText(u"Notes footer");
    headerFooterManager->SetFooterAndChildFootersVisibility(true);

    headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");
    headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
}

presentation->Save(u"presentation_with_child_notes_footers.pptx", SaveFormat::Pptx);
```

I metodi di propagazione usati sopra sono [`SetFooterAndChildFootersText`](https://reference.aspose.com/slides/it/cpp/aspose.slides/imasternotesslideheaderfootermanager/setfooterandchildfooterstext/), [`SetFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/it/cpp/aspose.slides/imasternotesslideheaderfootermanager/setfooterandchildfootersvisibility/), [`SetDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/it/cpp/aspose.slides/imasternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/), [`SetDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/it/cpp/aspose.slides/imasternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/), e [`SetSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/it/cpp/aspose.slides/imasternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/).

## **Imposta Intestazioni e Piè di pagina su una Diapositiva Note Individuale**

Una diapositiva delle note appartiene a una specifica diapositiva regolare. Utilizzare la sua interfaccia [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/cpp/aspose.slides/inotesslideheaderfootermanager/) quando si desidera personalizzare solo quella pagina delle note.

Il metodo [`INotesSlideManager::AddNotesSlide`](https://reference.aspose.com/slides/it/cpp/aspose.slides/inotesslidemanager/addnotesslide/) restituisce la diapositiva delle note per la diapositiva corrente e ne crea una se non esiste già. Il seguente esempio configura la pagina delle note associata alla prima diapositiva della presentazione:

```cpp
#include <DOM/INotesSlide.h>
#include <DOM/INotesSlideHeaderFooterManager.h>
#include <DOM/INotesSlideManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);
auto notesSlide = slide->get_NotesSlideManager()->AddNotesSlide();
auto headerFooterManager = notesSlide->get_HeaderFooterManager();

headerFooterManager->SetHeaderText(u"Header for the first notes page");
headerFooterManager->SetHeaderVisibility(true);

headerFooterManager->SetFooterText(u"Footer for the first notes page");
headerFooterManager->SetFooterVisibility(true);

headerFooterManager->SetDateTimeText(u"Date and time text");
headerFooterManager->SetDateTimeVisibility(true);

headerFooterManager->SetSlideNumberVisibility(true);

presentation->Save(u"presentation_with_custom_notes_footers.pptx", SaveFormat::Pptx);
```

Se prima si propagano le impostazioni dal master delle note e poi si modifica una diapositiva delle note individuale, le impostazioni successive per diapositiva consentono di personalizzare quella pagina delle note in modo indipendente.

## **Imposta Intestazioni e Piè di pagina sul Master degli Opuscoli**

Le pagine degli opuscoli utilizzano il master degli opuscoli per i segnaposti di intestazione, piè di pagina, data/ora e numero di pagina. A differenza delle pagine delle note, le impostazioni degli opuscoli sono gestite attraverso il master degli opuscoli anziché tramite diapositive di opuscolo individuali.

Utilizzare [`IMasterHandoutSlideManager::get_MasterHandoutSlide`](https://reference.aspose.com/slides/it/cpp/aspose.slides/imasterhandoutslidemanager/get_masterhandoutslide/) per accedere al master degli opuscoli. Se non è presente, chiamare [`IMasterHandoutSlideManager::SetDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/it/cpp/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) per creare il master degli opuscoli predefinito.

```cpp
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideHeaderFooterManager.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterHandoutSlideManager = presentation->get_MasterHandoutSlideManager();
auto masterHandoutSlide = masterHandoutSlideManager->get_MasterHandoutSlide();

if (masterHandoutSlide == nullptr)
{
    masterHandoutSlide = masterHandoutSlideManager->SetDefaultMasterHandoutSlide();
}

if (masterHandoutSlide != nullptr)
{
    auto headerFooterManager = masterHandoutSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderText(u"Handout header");
    headerFooterManager->SetHeaderVisibility(true);

    headerFooterManager->SetFooterText(u"Handout footer");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_handout_footers.pptx", SaveFormat::Pptx);
```

## **Comprendere Ambito ed Ereditarietà**

Scegliere il gestore intestazione/piè di pagina che corrisponde all'ambito che si desidera modificare:

- `ISlideHeaderFooterManager` modifica le impostazioni di piè di pagina, data/ora e numero diapositiva per una diapositiva regolare.
- `ILayoutSlideHeaderFooterManager` controlla una diapositiva layout e può propagare le impostazioni supportate alle diapositive dipendenti.
- `IMasterSlideHeaderFooterManager` controlla un master di diapositive regolari e può propagare le impostazioni supportate alle diapositive dipendenti.
- `IMasterNotesSlideHeaderFooterManager` controlla il master delle note e può propagare le impostazioni a tutte le diapositive delle note dipendenti.
- `INotesSlideHeaderFooterManager` modifica una diapositiva delle note e supporta un segnaposto di intestazione oltre a piè di pagina, data/ora e numero diapositiva.
- `IMasterHandoutSlideHeaderFooterManager` modifica il master degli opuscoli e supporta tutti e quattro i tipi di segnaposto.

Utilizzare la propagazione da un master o layout quando la stessa impostazione deve essere applicata lungo tutta la gerarchia. Utilizzare un gestore di diapositiva individuale o di diapositiva delle note quando è necessaria un'impostazione locale per una singola pagina.

## **FAQ**

**Posso aggiungere un'intestazione a una diapositiva regolare?**

No. PowerPoint non definisce un segnaposto di intestazione per le diapositive regolari. Su diapositive regolari, utilizzare i segnaposti di piè di pagina, data/ora e numero diapositiva. I segnaposti di intestazione sono disponibili nelle pagine delle note e negli opuscoli.

**Cosa succede se un segnaposto di piè di pagina, data/ora o numero diapositiva non è visibile?**

Utilizzare il gestore intestazione/piè di pagina corrispondente per verificare la sua visibilità e abilitarla quando necessario. Ad esempio, [`get_IsFooterVisible`](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibaseslideheaderfootermanager/get_isfootervisible/) indica se è presente un segnaposto di piè di pagina, e [`SetFooterVisibility`](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootervisibility/) ne modifica la visibilità.

**Come avvio la numerazione delle diapositive da un valore diverso da 1?**

Utilizzare [`Presentation::set_FirstSlideNumber`](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/set_firstslidenumber/) per impostare il numero della prima diapositiva. I segnaposti di numero diapositiva utilizzeranno quindi la sequenza di numerazione aggiornata.

**Cosa succede alle intestazioni e ai piè di pagina durante l'esportazione in PDF, immagini o HTML?**

Gli elementi di intestazione e piè di pagina visibili vengono renderizzati insieme al resto del contenuto della presentazione nel formato di output. Il loro aspetto dipende dal tipo di pagina esportata e dalle impostazioni di visibilità dei corrispondenti segnaposti.