---
title: Gestire Intestazioni e Piè di pagina della Presentazione in JavaScript
linktitle: Intestazione e Piè di pagina
type: docs
weight: 140
url: /it/nodejs-java/presentation-header-and-footer/
keywords:
- intestazione
- testo intestazione
- piè di pagina
- testo piè di pagina
- imposta intestazione
- imposta piè di pagina
- documento
- note
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Scopri come gestire i segnaposti di piè di pagina, data-ora, numero diapositiva e intestazione su diapositive, pagine note e documenti con Aspose.Slides per Node.js tramite Java."
---
## **Panoramica**

PowerPoint utilizza segnaposti di intestazione e piè di pagina diversi a seconda del tipo di pagina. Aspose.Slides per Node.js tramite Java consente di controllare il testo e la visibilità di questi segnaposti tramite le classi manager di intestazione/piè di pagina.

I segnaposti disponibili dipendono dall’ambito:

| Ambito | Intestazione | Piè di pagina | Data/ora | Numero diapositiva/pagina |
|---|---|---|---|---|
| Diapositiva normale | No | Sì | Sì | Sì |
| Master note | Sì | Sì | Sì | Sì |
| Diapositiva note | Sì | Sì | Sì | Sì |
| Master documento | Sì | Sì | Sì | Sì |

Una diapositiva normale della presentazione non ha un segnaposto di intestazione. Le intestazioni sono disponibili nelle pagine note e nei documenti. Per le diapositive normali, utilizzare i segnaposti di piè di pagina, data/ora e numero diapositiva.

L’ambito di una modifica dipende dal manager che si utilizza. La classe [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slideheaderfootermanager/) controlla una singola diapositiva normale. La classe [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/notesslideheaderfootermanager/) controlla una singola diapositiva note. I manager master e layout possono inoltre propagare le impostazioni alle diapositive dipendenti, mentre la classe [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/masterhandoutslideheaderfootermanager/) controlla il master documento.

## **Imposta Piè di pagina, Data/Ora e Numeri Diapositiva su Diapositive Normali**

Per le diapositive normali, il flusso di lavoro di base consiste nell’accedere al manager di intestazione/piè di pagina di ciascuna diapositiva, impostare il testo del piè di pagina e della data/ora, abilitare i segnaposti richiesti e salvare la presentazione. I numeri di diapositiva sono generati dalla presentazione, quindi è necessario controllarne solo la visibilità.

Utilizzare [`setFooterText`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterText) e [`setDateTimeText`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeText) per impostare il testo, e utilizzare [`setFooterVisibility`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility), [`setDateTimeVisibility`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility) e [`setSlideNumberVisibility`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility) per mostrare i corrispondenti segnaposti.

Il seguente esempio end‑to‑end applica lo stesso piè di pagina, testo data/ora e visibilità del numero di diapositiva a tutte le diapositive normali:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const headerFooterManager = slide.getHeaderFooterManager();

        headerFooterManager.setFooterText("Company Confidential");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_slide_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Se è necessario aggiornare una sola diapositiva, accedere a quella diapositiva direttamente tramite il metodo [`getSlides`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/getslides/) invece di iterare sull’intera collezione.

## **Imposta Intestazioni e Piè di pagina sul Master Note**

Il master note definisce formattazione comune e comportamento dei segnaposti per le pagine note. Utilizzare la classe [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) quando si desidera modificare solo il master note stesso.

Il seguente esempio imposta intestazione, piè di pagina e testo data/ora sul master note e rende visibili tutti i segnaposti supportati su quel master:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide !== null) {
        const headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Notes header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Notes footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_notes_master_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il metodo [`getMasterNotesSlide`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/masternotesslidemanager/#getMasterNotesSlide) restituisce `null` quando la presentazione non contiene un master note.

## **Applica le impostazioni del Master Note alle Diapositive Note Figlie**

Un master note può applicare le impostazioni di intestazione e piè di pagina a sé stesso e a tutte le diapositive note dipendenti. Utilizzare i metodi di propagazione dedicati su [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) quando le stesse impostazioni devono essere applicate all’intera gerarchia note.

Ad esempio, [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersText) e [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility) aggiornano l’intestazione del master note e tutte le intestazioni figlie. Metodi equivalenti sono disponibili per i piè di pagina, data/ora e numeri di diapositiva.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide !== null) {
        const headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersText("Notes header");
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);

        headerFooterManager.setFooterAndChildFootersText("Notes footer");
        headerFooterManager.setFooterAndChildFootersVisibility(true);

        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    presentation.save("presentation_with_child_notes_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

I metodi di propagazione usati sopra sono [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersText), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility) e [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility).

## **Imposta Intestazioni e Piè di pagina su una Diapositiva Note Individuale**

Una diapositiva note appartiene a una specifica diapositiva normale. Utilizzare la sua classe [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/notesslideheaderfootermanager/) quando si desidera personalizzare solo quella pagina note.

Il metodo [`addNotesSlide`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/notesslidemanager/#addNotesSlide) restituisce la diapositiva note per la diapositiva corrente e ne crea una se non esiste già. Il seguente esempio configura la pagina note associata alla prima diapositiva della presentazione:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const headerFooterManager = slide.getNotesSlideManager().addNotesSlide().getHeaderFooterManager();

    headerFooterManager.setHeaderText("Header for the first notes page");
    headerFooterManager.setHeaderVisibility(true);

    headerFooterManager.setFooterText("Footer for the first notes page");
    headerFooterManager.setFooterVisibility(true);

    headerFooterManager.setDateTimeText("Date and time text");
    headerFooterManager.setDateTimeVisibility(true);

    headerFooterManager.setSlideNumberVisibility(true);

    presentation.save("presentation_with_custom_notes_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Se prima si propagano le impostazioni dal master note e poi si modifica una diapositiva note individuale, le impostazioni successive per diapositiva consentono di personalizzare quella pagina note in modo indipendente.

## **Imposta Intestazioni e Piè di pagina sul Master Documento**

Le pagine documento utilizzano il master documento per i loro segnaposti di intestazione, piè di pagina, data/ora e numero di pagina. A differenza delle pagine note, le impostazioni del documento vengono gestite tramite il master documento anziché tramite le singole diapositive documento.

Utilizzare [`getMasterHandoutSlide`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/masterhandoutslidemanager/#getMasterHandoutSlide) per accedere al master documento. Se non è presente, chiamare [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/masterhandoutslidemanager/#setDefaultMasterHandoutSlide) per creare il master documento predefinito.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    let masterHandoutSlide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();

    if (masterHandoutSlide === null) {
        masterHandoutSlide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();
    }

    if (masterHandoutSlide !== null) {
        const headerFooterManager = masterHandoutSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Handout header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Handout footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_handout_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Comprendere Ambito ed Ereditarietà**

Scegliere il manager di intestazione/piè di pagina che corrisponde all’ambito che si desidera modificare:

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slideheaderfootermanager/) modifica le impostazioni di piè di pagina, data/ora e numero diapositiva per una singola diapositiva normale.
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/layoutslideheaderfootermanager/) controlla una diapositiva layout e può propagare le impostazioni supportate alle diapositive dipendenti.
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/masterslideheaderfootermanager/) controlla un master diapositiva normale e può propagare le impostazioni supportate alle diapositive dipendenti.
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) controlla il master note e può propagare le impostazioni a tutte le diapositive note dipendenti.
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/notesslideheaderfootermanager/) modifica una singola diapositiva note e supporta un segnaposto di intestazione oltre a piè di pagina, data/ora e numero diapositiva.
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/masterhandoutslideheaderfootermanager/) modifica il master documento e supporta tutti e quattro i tipi di segnaposto.

Utilizzare la propagazione da un master o layout quando la stessa impostazione deve essere applicata a tutta la gerarchia. Utilizzare un manager di diapositiva o di diapositiva note individuale quando è necessaria un’impostazione locale per una singola pagina.

## **FAQ**

**Posso aggiungere un'intestazione a una diapositiva normale?**

No. PowerPoint non definisce un segnaposto di intestazione per le diapositive normali. Su queste diapositive, utilizzare i segnaposti di piè di pagina, data/ora e numero diapositiva. I segnaposti di intestazione sono disponibili su pagine note e documenti.

**Cosa succede se un segnaposto di piè di pagina, data/ora o numero diapositiva non è visibile?**

Utilizzare il corrispondente manager di intestazione/piè di pagina per verificarne la visibilità e abilitarlo quando necessario. Ad esempio, [`isFooterVisible`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/baseslideheaderfootermanager/#isFooterVisible) indica se è presente un segnaposto di piè di pagina, e [`setFooterVisibility`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility) ne modifica la visibilità.

**Come posso iniziare la numerazione delle diapositive da un valore diverso da 1?**

Chiamare il metodo [`setFirstSlideNumber`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/setfirstslidenumber/) della presentazione. I segnaposti di numero diapositiva utilizzeranno quindi la sequenza di numerazione aggiornata.

**Cosa accade a intestazioni e piè di pagina quando si esporta in PDF, immagini o HTML?**

Gli elementi di intestazione e piè di pagina visibili vengono renderizzati insieme al resto del contenuto della presentazione nel formato di output. La loro apparizione dipende dal tipo di pagina esportata e dalle impostazioni di visibilità dei relativi segnaposti.