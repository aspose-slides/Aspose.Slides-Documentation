---
title: Gestisci intestazioni e piè di pagina della presentazione in .NET
linktitle: Intestazione e Piè di pagina
type: docs
weight: 140
url: /it/net/presentation-header-and-footer/
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
- .NET
- C#
- Aspose.Slides
description: "Scopri come gestire i segnaposti di piè di pagina, data/ora, numero diapositiva e intestazione su diapositive, pagine note e opuscoli con Aspose.Slides per .NET."
---
## **Panoramica**

PowerPoint utilizza segnaposti di intestazione e piè di pagina diversi a seconda del tipo di pagina. Aspose.Slides per .NET consente di controllare il testo e la visibilità di questi segnaposti tramite le interfacce del gestore intestazione/piè di pagina.

I segnaposti disponibili dipendono dall'ambito:

| Ambito | Intestazione | Piè di pagina | Data/ora | Numero diapositiva/pagina |
|---|---|---|---|---|
| Diapositiva normale | No | Sì | Sì | Sì |
| Master note | Sì | Sì | Sì | Sì |
| Diapositiva note | Sì | Sì | Sì | Sì |
| Master opuscolo | Sì | Sì | Sì | Sì |

Una diapositiva di presentazione normale non ha un segnaposto di intestazione. Le intestazioni sono disponibili su pagine note e opuscoli. Per le diapositive normali, utilizzare i segnaposti di piè di pagina, data/ora e numero diapositiva.

L'ambito di una modifica dipende dal gestore che si utilizza. L'interfaccia [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/it/net/aspose.slides/islideheaderfootermanager/) controlla una diapositiva normale. L'interfaccia [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/net/aspose.slides/inotesslideheaderfootermanager/) controlla una diapositiva note. I gestori master e layout possono anche propagare le impostazioni alle diapositive dipendenti, mentre l'interfaccia [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/net/aspose.slides/imasterhandoutslideheaderfootermanager/) controlla il master opuscolo.

## **Imposta Piè di pagina, Data/Ora e Numeri Diapositiva su Diapositive Normali**

Per le diapositive normali, il flusso di lavoro di base consiste nel accedere al gestore intestazione/piè di pagina di ogni diapositiva, impostare il testo del piè di pagina e della data/ora, abilitare i segnaposti richiesti e salvare la presentazione. I numeri delle diapositive sono generati dalla presentazione, quindi è necessario controllarne solo la visibilità.

Utilizzare [`SetFooterText`](https://reference.aspose.com/slides/it/net/aspose.slides/baseslideheaderfootermanager/setfootertext/) e [`SetDateTimeText`](https://reference.aspose.com/slides/it/net/aspose.slides/baseslideheaderfootermanager/setdatetimetext/) per impostare il testo, e utilizzare [`SetFooterVisibility`](https://reference.aspose.com/slides/it/net/aspose.slides/baseslideheaderfootermanager/setfootervisibility/), [`SetDateTimeVisibility`](https://reference.aspose.com/slides/it/net/aspose.slides/baseslideheaderfootermanager/setdatetimevisibility/), e [`SetSlideNumberVisibility`](https://reference.aspose.com/slides/it/net/aspose.slides/baseslideheaderfootermanager/setslidenumbervisibility/) per mostrare i corrispondenti segnaposti.

Il seguente esempio completo applica lo stesso piè di pagina, testo della data/ora e visibilità del numero di diapositiva a tutte le diapositive normali:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    var headerFooterManager = slide.HeaderFooterManager;

    headerFooterManager.SetFooterText("Company Confidential");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_slide_footers.pptx", SaveFormat.Pptx);
```

Se è necessario aggiornare una sola diapositiva, accedere a quella diapositiva direttamente tramite la collezione [`Slides`](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/slides/it/) anziché iterare sull'intera collezione.

## **Imposta Intestazioni e Piè di pagina sul Master Note**

Il master note definisce la formattazione comune e il comportamento dei segnaposti per le pagine note. Utilizzare l'interfaccia [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/net/aspose.slides/imasternotesslideheaderfootermanager/) quando si desidera modificare solo il master note.

Il seguente esempio imposta intestazione, piè di pagina e testo della data/ora sul master note e rende tutti i segnaposti supportati visibili su quel master:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;

if (masterNotesSlide != null)
{
    var headerFooterManager = masterNotesSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderText("Notes header");
    headerFooterManager.SetHeaderVisibility(true);

    headerFooterManager.SetFooterText("Notes footer");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx);
```

La proprietà [`MasterNotesSlide`](https://reference.aspose.com/slides/it/net/aspose.slides/imasternotesslidemanager/masternotesslide/) restituisce `null` quando la presentazione non contiene un master note.

## **Applica le impostazioni del Master Note alle Diapositive Note Figlie**

Un master note può applicare le impostazioni di intestazione e piè di pagina a se stesso e a tutte le diapositive note dipendenti. Utilizzare i metodi di propagazione dedicati su [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/net/aspose.slides/imasternotesslideheaderfootermanager/) quando le stesse impostazioni devono essere applicate in tutta la gerarchia delle note.

Ad esempio, [`SetHeaderAndChildHeadersText`](https://reference.aspose.com/slides/it/net/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheaderstext/) e [`SetHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/it/net/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) aggiornano l'intestazione del master note e tutte le intestazioni figlie. Metodi equivalenti sono disponibili per i piè di pagina, data/ora e numeri diapositiva.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;

if (masterNotesSlide != null)
{
    var headerFooterManager = masterNotesSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderAndChildHeadersText("Notes header");
    headerFooterManager.SetHeaderAndChildHeadersVisibility(true);

    headerFooterManager.SetFooterAndChildFootersText("Notes footer");
    headerFooterManager.SetFooterAndChildFootersVisibility(true);

    headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");
    headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
}

presentation.Save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx);
```

I metodi di propagazione utilizzati sopra sono [`SetFooterAndChildFootersText`](https://reference.aspose.com/slides/it/net/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfooterstext/), [`SetFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/it/net/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfootersvisibility/), [`SetDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/it/net/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/), [`SetDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/it/net/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/), e [`SetSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/it/net/aspose.slides/masternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/).

## **Imposta Intestazioni e Piè di pagina su una Diapositiva Note Individuale**

Una diapositiva note appartiene a una specifica diapositiva normale. Utilizzare la sua interfaccia [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/net/aspose.slides/inotesslideheaderfootermanager/) quando si desidera personalizzare solo quella pagina note.

Il metodo [`AddNotesSlide`](https://reference.aspose.com/slides/it/net/aspose.slides/inotesslidemanager/addnotesslide/) restituisce la diapositiva note per la diapositiva corrente e ne crea una se non esiste già. Il seguente esempio configura la pagina note associata alla prima diapositiva della presentazione:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var notesSlide = presentation.Slides[0].NotesSlideManager.AddNotesSlide();
var headerFooterManager = notesSlide.HeaderFooterManager;

headerFooterManager.SetHeaderText("Header for the first notes page");
headerFooterManager.SetHeaderVisibility(true);

headerFooterManager.SetFooterText("Footer for the first notes page");
headerFooterManager.SetFooterVisibility(true);

headerFooterManager.SetDateTimeText("Date and time text");
headerFooterManager.SetDateTimeVisibility(true);

headerFooterManager.SetSlideNumberVisibility(true);

presentation.Save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx);
```

Se prima si propagano le impostazioni dal master note e poi si modifica una singola diapositiva note, le impostazioni per‑diapositiva successive consentono di personalizzare quella pagina note in modo indipendente.

## **Imposta Intestazioni e Piè di pagina sul Master Opuscolo**

Le pagine opuscolo utilizzano il master opuscolo per i loro segnaposti di intestazione, piè di pagina, data/ora e numero di pagina. A differenza delle pagine note, le impostazioni dell'opuscolo sono gestite attraverso il master opuscolo piuttosto che tramite singole diapositive opuscolo.

Utilizzare la proprietà [`MasterHandoutSlide`](https://reference.aspose.com/slides/it/net/aspose.slides/imasterhandoutslidemanager/masterhandoutslide/) per accedere al master opuscolo. Se non è presente, chiamare [`SetDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/it/net/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) per creare il master opuscolo predefinito.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterHandoutSlide = presentation.MasterHandoutSlideManager.MasterHandoutSlide;

if (masterHandoutSlide == null)
{
    presentation.MasterHandoutSlideManager.SetDefaultMasterHandoutSlide();
    masterHandoutSlide = presentation.MasterHandoutSlideManager.MasterHandoutSlide;
}

if (masterHandoutSlide != null)
{
    var headerFooterManager = masterHandoutSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderText("Handout header");
    headerFooterManager.SetHeaderVisibility(true);

    headerFooterManager.SetFooterText("Handout footer");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_handout_footers.pptx", SaveFormat.Pptx);
```

## **Comprendere Ambito ed Ereditarietà**

Scegliere il gestore intestazione/piè di pagina che corrisponde all'ambito che si desidera modificare:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/it/net/aspose.slides/islideheaderfootermanager/) modifica le impostazioni di piè di pagina, data/ora e numero diapositiva per una singola diapositiva normale.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/net/aspose.slides/ilayoutslideheaderfootermanager/) controlla una diapositiva layout e può propagare le impostazioni supportate alle diapositive dipendenti.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/net/aspose.slides/imasterslideheaderfootermanager/) controlla un master diapositiva normale e può propagare le impostazioni supportate alle diapositive dipendenti.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/net/aspose.slides/imasternotesslideheaderfootermanager/) controlla il master note e può propagare le impostazioni a tutte le diapositive note dipendenti.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/net/aspose.slides/inotesslideheaderfootermanager/) modifica una singola diapositiva note e supporta un segnaposto di intestazione oltre a piè di pagina, data/ora e numero diapositiva.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/net/aspose.slides/imasterhandoutslideheaderfootermanager/) modifica il master opuscolo e supporta tutti e quattro i tipi di segnaposto.

Utilizzare la propagazione da un master o layout quando la stessa impostazione deve essere applicata in tutta la sua gerarchia. Utilizzare un gestore di diapositiva individuale o di diapositiva note quando è necessaria un'impostazione locale per una singola pagina.

## **FAQ**

**Posso aggiungere un'intestazione a una diapositiva normale?**

No. PowerPoint non definisce un segnaposto di intestazione per le diapositive normali. Su diapositive normali, utilizzare i segnaposti di piè di pagina, data/ora e numero diapositiva. I segnaposti di intestazione sono disponibili su pagine note e opuscoli.

**Cosa succede se un segnaposto di piè di pagina, data/ora o numero diapositiva non è visibile?**

Utilizzare il gestore intestazione/piè di pagina corrispondente per verificare la sua visibilità e abilitarla quando necessario. Ad esempio, [`IsFooterVisible`](https://reference.aspose.com/slides/it/net/aspose.slides/baseslideheaderfootermanager/isfootervisible/) indica se è presente un segnaposto di piè di pagina, e [`SetFooterVisibility`](https://reference.aspose.com/slides/it/net/aspose.slides/baseslideheaderfootermanager/setfootervisibility/) ne cambia la visibilità.

**Come avvio la numerazione delle diapositive da un valore diverso da 1?**

Impostare la proprietà [`FirstSlideNumber`](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/firstslidenumber/) della presentazione. I segnaposti di numero diapositiva utilizzeranno quindi la sequenza di numerazione aggiornata.

**Cosa succede a intestazioni e piè di pagina quando si esporta in PDF, immagini o HTML?**

Gli elementi di intestazione e piè di pagina visibili vengono renderizzati insieme al resto del contenuto della presentazione nel formato di output. Il loro aspetto dipende dal tipo di pagina esportata e dalle relative impostazioni di visibilità dei segnaposti.