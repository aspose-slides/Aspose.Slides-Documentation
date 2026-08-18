---
title: Gestisci intestazioni e piè di pagina della presentazione in PHP
linktitle: Intestazione e piè di pagina
type: docs
weight: 140
url: /it/php-java/presentation-header-and-footer/
keywords:
- intestazione
- testo intestazione
- piè di pagina
- testo piè di pagina
- imposta intestazione
- imposta piè di pagina
- dispensa
- note
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Scopri come gestire i segnaposti di piè di pagina, data/ora, numero diapositiva e intestazione su diapositive, pagine note e dispense con Aspose.Slides per PHP via Java."
---
## **Panoramica**

PowerPoint utilizza diversi segnaposti di intestazione e piè di pagina a seconda del tipo di pagina. Aspose.Slides per PHP via Java consente di controllare il testo e la visibilità di questi segnaposti tramite le classi manager di intestazione/piè di pagina.

I segnaposti disponibili dipendono dall'ambito:

| Ambito | Intestazione | Piè di pagina | Data/ora | Numero diapositiva/pagina |
|---|---|---|---|---|
| Diapositiva normale | No | Sì | Sì | Sì |
| Schema note | Sì | Sì | Sì | Sì |
| Diapositiva note | Sì | Sì | Sì | Sì |
| Schema dispense | Sì | Sì | Sì | Sì |

Una diapositiva di presentazione normale non dispone di un segnaposto per l'intestazione. Le intestazioni sono disponibili nelle pagine delle note e nei dispense. Per le diapositive normali, utilizzare invece i segnaposti per il piè di pagina, data/ora e numero diapositiva.

L'ambito di una modifica dipende dal manager che utilizzi. La classe [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/it/php-java/aspose.slides/slideheaderfootermanager/) controlla una diapositiva normale. La classe [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/php-java/aspose.slides/notesslideheaderfootermanager/) controlla una diapositiva di note. I manager master e layout possono anche propagare le impostazioni alle diapositive dipendenti, mentre la classe [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/php-java/aspose.slides/masterhandoutslideheaderfootermanager/) controlla lo schema dispense.

## **Imposta Piè di pagina, Data/Ora e Numeri di Diapositiva su Diapositive Normali**

Per le diapositive normali, il flusso di lavoro di base consiste nell'accedere al manager di intestazione/piè di pagina di ciascuna diapositiva, impostare il testo del piè di pagina e della data/ora, abilitare i segnaposti richiesti e salvare la presentazione. I numeri di diapositiva sono generati dalla presentazione, quindi è necessario controllarne solo la visibilità.

Usa [`setFooterText`](https://reference.aspose.com/slides/it/php-java/aspose.slides/baseslideheaderfootermanager/setfootertext/) e [`setDateTimeText`](https://reference.aspose.com/slides/it/php-java/aspose.slides/baseslideheaderfootermanager/setdatetimetext/) per impostare il testo, e usa [`setFooterVisibility`](https://reference.aspose.com/slides/it/php-java/aspose.slides/baseslideheaderfootermanager/setfootervisibility/), [`setDateTimeVisibility`](https://reference.aspose.com/slides/it/php-java/aspose.slides/baseslideheaderfootermanager/setdatetimevisibility/) e [`setSlideNumberVisibility`](https://reference.aspose.com/slides/it/php-java/aspose.slides/baseslideheaderfootermanager/setslidenumbervisibility/) per mostrare i segnaposti corrispondenti.

Il seguente esempio end‑to‑end applica lo stesso piè di pagina, testo data/ora e visibilità del numero di diapositiva a tutte le diapositive normali:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getSlides() as $slide) {
        $headerFooterManager = $slide->getHeaderFooterManager();

        $headerFooterManager->setFooterText("Company Confidential");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_slide_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Se hai bisogno di aggiornare solo una diapositiva, accedi direttamente a quella diapositiva tramite il metodo [`getSlides`](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/getslides/) anziché iterare sull'intera collezione.

## **Imposta Intestazioni e Piè di pagina sullo Schema Note**

Lo schema note definisce la formattazione comune e il comportamento dei segnaposti per le pagine delle note. Usa la classe [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/php-java/aspose.slides/masternotesslideheaderfootermanager/) quando desideri modificare solo lo schema note stesso.

Il seguente esempio imposta intestazione, piè di pagina e testo data/ora sullo schema note e rende visibili tutti i segnaposti supportati su quello schema:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterNotesSlide = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();

    if (!java_is_null($masterNotesSlide)) {
        $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderText("Notes header");
        $headerFooterManager->setHeaderVisibility(true);

        $headerFooterManager->setFooterText("Notes footer");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_notes_master_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il metodo [`getMasterNotesSlide`](https://reference.aspose.com/slides/it/php-java/aspose.slides/masternotesslidemanager/getmasternotesslide/) restituisce `null` quando la presentazione non contiene uno schema note.

## **Applica le Impostazioni dello Schema Note alle Diapositive Note Figlie**

Uno schema note può applicare le impostazioni di intestazione e piè di pagina a se stesso e a tutte le diapositive note dipendenti. Usa i metodi di propagazione dedicati su [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/php-java/aspose.slides/masternotesslideheaderfootermanager/) quando le stesse impostazioni devono essere applicate all'intera gerarchia delle note.

Ad esempio, [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/it/php-java/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheaderstext/) e [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/it/php-java/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) aggiornano l'intestazione dello schema note e tutte le intestazioni figlie. Metodi equivalenti sono disponibili per i piè di pagina, data/ora e numeri di diapositiva.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterNotesSlide = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();

    if (!java_is_null($masterNotesSlide)) {
        $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderAndChildHeadersText("Notes header");
        $headerFooterManager->setHeaderAndChildHeadersVisibility(true);

        $headerFooterManager->setFooterAndChildFootersText("Notes footer");
        $headerFooterManager->setFooterAndChildFootersVisibility(true);

        $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");
        $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);

        $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    $presentation->save("presentation_with_child_notes_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

I metodi di propagazione usati sopra sono [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/it/php-java/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfooterstext/), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/it/php-java/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfootersvisibility/), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/it/php-java/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/it/php-java/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/), e [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/it/php-java/aspose.slides/masternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/).

## **Imposta Intestazioni e Piè di pagina su una Diapositiva Note Individuale**

Una diapositiva di note appartiene a una specifica diapositiva regolare. Usa la sua classe [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/php-java/aspose.slides/notesslideheaderfootermanager/) quando desideri personalizzare solo quella pagina di note.

Il metodo [`addNotesSlide`](https://reference.aspose.com/slides/it/php-java/aspose.slides/notesslidemanager/addnotesslide/) restituisce la diapositiva di note per la diapositiva corrente e ne crea una se non esiste già. Il seguente esempio configura la pagina di note associata alla prima diapositiva della presentazione:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $notesSlide = $slide->getNotesSlideManager()->addNotesSlide();
    $headerFooterManager = $notesSlide->getHeaderFooterManager();

    $headerFooterManager->setHeaderText("Header for the first notes page");
    $headerFooterManager->setHeaderVisibility(true);

    $headerFooterManager->setFooterText("Footer for the first notes page");
    $headerFooterManager->setFooterVisibility(true);

    $headerFooterManager->setDateTimeText("Date and time text");
    $headerFooterManager->setDateTimeVisibility(true);

    $headerFooterManager->setSlideNumberVisibility(true);

    $presentation->save("presentation_with_custom_notes_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Se prima propaghi le impostazioni dallo schema note e poi modifichi una diapositiva di note individuale, le impostazioni per diapositiva successive ti consentono di personalizzare quella pagina di note in modo indipendente.

## **Imposta Intestazioni e Piè di pagina sullo Schema Dispense**

Le pagine di dispense utilizzano lo schema dispense per i loro segnaposti di intestazione, piè di pagina, data/ora e numero pagina. A differenza delle pagine di note, le impostazioni dei dispense sono gestite tramite lo schema dispense anziché tramite le singole diapositive di dispense.

Usa il metodo [`getMasterHandoutSlide`](https://reference.aspose.com/slides/it/php-java/aspose.slides/masterhandoutslidemanager/getmasterhandoutslide/) per accedere allo schema dispense. Se non è presente, chiama [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/it/php-java/aspose.slides/masterhandoutslidemanager/setdefaultmasterhandoutslide/) per creare lo schema dispense predefinito.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterHandoutSlide = $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide();

    if (java_is_null($masterHandoutSlide)) {
        $masterHandoutSlide = $presentation->getMasterHandoutSlideManager()->setDefaultMasterHandoutSlide();
    }

    if (!java_is_null($masterHandoutSlide)) {
        $headerFooterManager = $masterHandoutSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderText("Handout header");
        $headerFooterManager->setHeaderVisibility(true);

        $headerFooterManager->setFooterText("Handout footer");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_handout_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Comprendere Ambito ed Ereditarietà**

Scegli il manager di intestazione/piè di pagina che corrisponde all'ambito che vuoi modificare:

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/it/php-java/aspose.slides/slideheaderfootermanager/) modifica le impostazioni di piè di pagina, data/ora e numero diapositiva per una diapositiva normale.
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/php-java/aspose.slides/layoutslideheaderfootermanager/) controlla una diapositiva layout e può propagare le impostazioni supportate alle diapositive dipendenti.
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/php-java/aspose.slides/masterslideheaderfootermanager/) controlla uno schema diapositiva regolare e può propagare le impostazioni supportate alle diapositive dipendenti.
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/php-java/aspose.slides/masternotesslideheaderfootermanager/) controlla lo schema note e può propagare le impostazioni a tutte le diapositive note dipendenti.
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/php-java/aspose.slides/notesslideheaderfootermanager/) modifica una diapositiva di note e supporta un segnaposto di intestazione oltre a piè di pagina, data/ora e numero diapositiva.
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/php-java/aspose.slides/masterhandoutslideheaderfootermanager/) modifica lo schema dispense e supporta tutti e quattro i tipi di segnaposto.

Usa la propagazione da uno schema o layout quando la stessa impostazione deve applicarsi a tutta la sua gerarchia. Usa un manager di diapositiva individuale o di diapositiva di note quando ti serve un'impostazione locale per una singola pagina.

## **FAQ**

**Posso aggiungere un'intestazione a una diapositiva normale?**

No. PowerPoint non definisce un segnaposto di intestazione per le diapositive normali. Su diapositive normali, utilizza i segnaposti per il piè di pagina, data/ora e numero diapositiva. I segnaposti di intestazione sono disponibili nelle pagine delle note e nei dispense.

**Cosa succede se un segnaposto di piè di pagina, data/ora o numero diapositiva non è visibile?**

Usa il manager di intestazione/piè di pagina corrispondente per verificarne la visibilità e abilitarlo quando necessario. Ad esempio, [`isFooterVisible`](https://reference.aspose.com/slides/it/php-java/aspose.slides/baseslideheaderfootermanager/isfootervisible/) indica se è presente un segnaposto di piè di pagina, e [`setFooterVisibility`](https://reference.aspose.com/slides/it/php-java/aspose.slides/baseslideheaderfootermanager/setfootervisibility/) ne cambia la visibilità.

**Come avvio la numerazione delle diapositive da un valore diverso da 1?**

Chiama il metodo [`setFirstSlideNumber`](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/setfirstslidenumber/) della presentazione. I segnaposti di numero diapositiva utilizzeranno quindi la sequenza di numerazione aggiornata.

**Cosa succede a intestazioni e piè di pagina durante l'esportazione in PDF, immagini o HTML?**

Gli elementi di intestazione e piè di pagina visibili vengono renderizzati insieme al resto del contenuto della presentazione nel formato di output. Il loro aspetto dipende dal tipo di pagina esportata e dalle impostazioni di visibilità dei segnaposti corrispondenti.