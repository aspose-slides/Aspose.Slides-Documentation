---
title: Gestire Intestazioni e Piè di pagina della Presentazione in Java
linktitle: Intestazione e Piè di pagina
type: docs
weight: 140
url: /it/java/presentation-header-and-footer/
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
- Java
- Aspose.Slides
description: "Scopri come gestire i segnaposti di piè di pagina, data/ora, numero diapositiva e intestazione su diapositive, pagine note e handout con Aspose.Slides per Java."
---
## **Panoramica**

PowerPoint utilizza diversi segnaposti di intestazione e piè di pagina a seconda del tipo di pagina. Aspose.Slides for Java consente di controllare il testo e la visibilità di questi segnaposti tramite le interfacce di gestione intestazione/piè di pagina.

I segnaposti disponibili dipendono dall'ambito:

| Ambito | Intestazione | Piè di pagina | Data/ora | Numero diapositiva/pagina |
|---|---|---|---|---|
| Diapositiva regolare | No | Sì | Sì | Sì |
| Maestro note | Sì | Sì | Sì | Sì |
| Diapositiva note | Sì | Sì | Sì | Sì |
| Maestro di handout | Sì | Sì | Sì | Sì |

Una diapositiva di presentazione regolare non ha un segnaposto di intestazione. Le intestazioni sono disponibili nelle pagine delle note e nei handout. Per le diapositive regolari, utilizzare invece i segnaposti di piè di pagina, data/ora e numero diapositiva.

L'ambito di una modifica dipende dal manager che si utilizza. L'interfaccia [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/it/java/com.aspose.slides/islideheaderfootermanager/) controlla una singola diapositiva regolare. L'interfaccia [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/java/com.aspose.slides/inotesslideheaderfootermanager/) controlla una singola diapositiva note. I manager di master e layout possono anche propagare le impostazioni alle diapositive dipendenti, mentre l'interfaccia [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/java/com.aspose.slides/imasterhandoutslideheaderfootermanager/) controlla il master handout.

## **Imposta Piè di pagina, Data/Ora e Numeri di Diapositiva su Diapositive Regolari**

Per le diapositive regolari, il flusso di lavoro di base consiste nell'accedere al manager intestazione/piè di pagina di ciascuna diapositiva, impostare il testo del piè di pagina e della data/ora, abilitare i segnaposti richiesti e salvare la presentazione. I numeri di diapositiva sono generati dalla presentazione, quindi è necessario controllarne solo la visibilità.

Usa [`setFooterText`](https://reference.aspose.com/slides/it/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterText-java.lang.String-) e [`setDateTimeText`](https://reference.aspose.com/slides/it/java/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeText-java.lang.String-) per impostare il testo, e usa [`setFooterVisibility`](https://reference.aspose.com/slides/it/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-), [`setDateTimeVisibility`](https://reference.aspose.com/slides/it/java/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility-boolean-), e [`setSlideNumberVisibility`](https://reference.aspose.com/slides/it/java/com.aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility-boolean-) per mostrare i segnaposti corrispondenti.

L'esempio end‑to‑end seguente applica lo stesso piè di pagina, testo data/ora e visibilità del numero diapositiva a tutte le diapositive regolari:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideHeaderFooterManager headerFooterManager = slide.getHeaderFooterManager();

        headerFooterManager.setFooterText("Company Confidential");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_slide_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Se devi aggiornare solo una diapositiva, accedi direttamente a quella diapositiva tramite il metodo [`getSlides`](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#getSlides--) invece di iterare sull'intera collezione.

## **Imposta Intestazioni e Piè di pagina sul Maestro delle Note**

Il maestro delle note definisce la formattazione comune e il comportamento dei segnaposti per le pagine delle note. Usa l'interfaccia [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/java/com.aspose.slides/imasternotesslideheaderfootermanager/) quando vuoi modificare solo il maestro delle note stesso.

L'esempio seguente imposta intestazione, piè di pagina e testo data/ora sul maestro delle note e rende visibili tutti i segnaposti supportati su quel master:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterNotesSlide masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide != null) {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Notes header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Notes footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il metodo [`getMasterNotesSlide`](https://reference.aspose.com/slides/it/java/com.aspose.slides/imasternotesslidemanager/#getMasterNotesSlide--) restituisce `null` quando la presentazione non contiene un maestro delle note.

## **Applica le impostazioni del Maestro Note alle diapositive figlie delle note**

Un maestro delle note può applicare le impostazioni di intestazione e piè di pagina a sé stesso e a tutte le diapositive note dipendenti. Usa i metodi di propagazione dedicati su [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/java/com.aspose.slides/imasternotesslideheaderfootermanager/) quando le stesse impostazioni devono essere applicate all'intera gerarchia delle note.

Ad esempio, [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/it/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersText-java.lang.String-) e [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/it/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility-boolean-) aggiornano l'intestazione del maestro delle note e tutte le intestazioni figlie. Metodi equivalenti sono disponibili per piè di pagina, data/ora e numeri di diapositiva.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterNotesSlide masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide != null) {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersText("Notes header");
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);

        headerFooterManager.setFooterAndChildFootersText("Notes footer");
        headerFooterManager.setFooterAndChildFootersVisibility(true);

        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    presentation.save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

I metodi di propagazione usati sopra sono [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/it/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersText-java.lang.String-), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/it/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility-boolean-), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/it/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText-java.lang.String-), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/it/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility-boolean-), e [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/it/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility-boolean-).

## **Imposta Intestazioni e Piè di pagina su una Diapositiva Note Individuale**

Una diapositiva note appartiene a una specifica diapositiva regolare. Usa la sua interfaccia [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/java/com.aspose.slides/inotesslideheaderfootermanager/) quando vuoi personalizzare solo quella pagina delle note.

Il metodo [`addNotesSlide`](https://reference.aspose.com/slides/it/java/com.aspose.slides/inotesslidemanager/#addNotesSlide--) restituisce la diapositiva delle note per la diapositiva corrente e ne crea una se non esiste già. L'esempio seguente configura la pagina delle note associata alla prima diapositiva della presentazione:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();
    INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();

    headerFooterManager.setHeaderText("Header for the first notes page");
    headerFooterManager.setHeaderVisibility(true);

    headerFooterManager.setFooterText("Footer for the first notes page");
    headerFooterManager.setFooterVisibility(true);

    headerFooterManager.setDateTimeText("Date and time text");
    headerFooterManager.setDateTimeVisibility(true);

    headerFooterManager.setSlideNumberVisibility(true);

    presentation.save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Se prima propaghi le impostazioni dal maestro delle note e poi modifichi una diapositiva note individuale, le impostazioni successive per diapositiva consentono di personalizzare quella pagina delle note in modo indipendente.

## **Imposta Intestazioni e Piè di pagina sul Maestro Handout**

Le pagine handout utilizzano il master handout per i loro segnaposti di intestazione, piè di pagina, data/ora e numero di pagina. Diversamente dalle pagine delle note, le impostazioni handout sono gestite tramite il master handout anziché tramite singole diapositive handout.

Usa il metodo [`getMasterHandoutSlide`](https://reference.aspose.com/slides/it/java/com.aspose.slides/imasterhandoutslidemanager/#getMasterHandoutSlide--) per accedere al master handout. Se non è presente, chiama [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/it/java/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) per creare il master handout predefinito.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterHandoutSlide masterHandoutSlide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();

    if (masterHandoutSlide == null) {
        masterHandoutSlide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();
    }

    if (masterHandoutSlide != null) {
        IMasterHandoutSlideHeaderFooterManager headerFooterManager = masterHandoutSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Handout header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Handout footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_handout_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Comprendere l'Ambito e l'Ereditarietà**

Scegli il manager intestazione/piè di pagina che corrisponde all'ambito che desideri modificare:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/it/java/com.aspose.slides/islideheaderfootermanager/) modifica le impostazioni di piè di pagina, data/ora e numero diapositiva per una singola diapositiva regolare.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilayoutslideheaderfootermanager/) controlla una diapositiva layout e può propagare le impostazioni supportate alle diapositive dipendenti.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/java/com.aspose.slides/imasterslideheaderfootermanager/) controlla un master di diapositiva regolare e può propagare le impostazioni supportate alle diapositive dipendenti.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/java/com.aspose.slides/imasternotesslideheaderfootermanager/) controlla il master delle note e può propagare le impostazioni a tutte le diapositive note dipendenti.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/java/com.aspose.slides/inotesslideheaderfootermanager/) modifica una singola diapositiva note e supporta un segnaposto di intestazione oltre a piè di pagina, data/ora e numero diapositiva.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/java/com.aspose.slides/imasterhandoutslideheaderfootermanager/) modifica il master handout e supporta tutti e quattro i tipi di segnaposto.

Usa la propagazione da un master o layout quando la stessa impostazione deve essere applicata a tutta la sua gerarchia. Usa un manager di diapositiva individuale o di diapositiva note quando è necessaria un'impostazione locale per una sola pagina.

## **FAQ**

**Posso aggiungere un'intestazione a una diapositiva regolare?**

No. PowerPoint non definisce un segnaposto di intestazione per le diapositive regolari. Su diapositive regolari, utilizza i segnaposti di piè di pagina, data/ora e numero diapositiva. I segnaposti di intestazione sono disponibili nelle pagine delle note e nei handout.

**Cosa succede se un segnaposto di piè di pagina, data/ora o numero diapositiva non è visibile?**

Usa il manager intestazione/piè di pagina corrispondente per verificare la sua visibilità e attivarla quando necessario. Per esempio, [`isFooterVisible`](https://reference.aspose.com/slides/it/java/com.aspose.slides/baseslideheaderfootermanager/#isFooterVisible--) segnala se è presente un segnaposto di piè di pagina, e [`setFooterVisibility`](https://reference.aspose.com/slides/it/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-) ne modifica la visibilità.

**Come posso avviare la numerazione delle diapositive da un valore diverso da 1?**

Chiama il metodo [`setFirstSlideNumber`](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-) della presentazione. I segnaposti del numero diapositiva utilizzeranno quindi la sequenza di numerazione aggiornata.

** Cosa accade a intestazioni e piè di pagina durante l'esportazione in PDF, immagini o HTML?**

Gli elementi di intestazione e piè di pagina visibili vengono renderizzati insieme al resto del contenuto della presentazione nel formato di output. Il loro aspetto dipende dal tipo di pagina esportata e dalle impostazioni di visibilità dei rispettivi segnaposti.