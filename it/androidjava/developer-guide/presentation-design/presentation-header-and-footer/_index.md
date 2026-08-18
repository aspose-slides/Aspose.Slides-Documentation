---
title: Gestisci intestazioni e piè di pagina della presentazione su Android
linktitle: Intestazione e piè di pagina
type: docs
weight: 140
url: /it/androidjava/presentation-header-and-footer/
keywords:
- intestazione
- testo intestazione
- piè di pagina
- testo piè di pagina
- imposta intestazione
- imposta piè di pagina
- foglio illustrativo
- note
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Scopri come gestire i segnaposti di piè di pagina, data/ora, numero di diapositiva e intestazione su diapositive, pagine note e fogli illustrativi con Aspose.Slides per Android tramite Java."
---
## **Panoramica**

PowerPoint utilizza diversi segnaposti di intestazione e piè di pagina a seconda del tipo di pagina. Aspose.Slides for Android via Java consente di controllare il testo e la visibilità di questi segnaposti tramite le interfacce del gestore intestazione/piè di pagina.

I segnaposti disponibili dipendono dall’ambito:

| Ambito | Intestazione | Piè di pagina | Data/ora | Numero di diapositiva/pagina |
|---|---|---|---|---|
| Diapositiva regolare | No | Sì | Sì | Sì |
| Master note | Sì | Sì | Sì | Sì |
| Diapositiva note | Sì | Sì | Sì | Sì |
| Master handout | Sì | Sì | Sì | Sì |

Una diapositiva di presentazione normale non ha un segnaposto di intestazione. Le intestazioni sono disponibili nelle pagine note e nei fogli illustrativi. Per le diapositive regolari, utilizzare i segnaposti piè di pagina, data/ora e numero di diapositiva.

L’ambito di una modifica dipende dal gestore che si utilizza. L’interfaccia [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islideheaderfootermanager/) controlla una singola diapositiva regolare. L’interfaccia [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/inotesslideheaderfootermanager/) controlla una singola diapositiva note. I gestori master e layout possono anche propagare le impostazioni alle diapositive dipendenti, mentre l’interfaccia [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/imasterhandoutslideheaderfootermanager/) controlla il master del foglio illustrativo.

## **Imposta Piè di pagina, Data/Ora e Numeri di diapositiva su diapositive regolari**

Per le diapositive regolari, il flusso di lavoro di base consiste nell’accedere al gestore intestazione/piè di pagina di ciascuna diapositiva, impostare il testo del piè di pagina e della data/ora, abilitare i segnaposti richiesti e salvare la presentazione. I numeri di diapositiva sono generati dalla presentazione, quindi è necessario controllarne solo la visibilità.

Usa [`setFooterText`](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setFooterText-java.lang.String-) e [`setDateTimeText`](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeText-java.lang.String-) per impostare il testo, e usa [`setFooterVisibility`](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-), [`setDateTimeVisibility`](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility-boolean-), e [`setSlideNumberVisibility`](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility-boolean-) per mostrare i corrispondenti segnaposti.

L’esempio end‑to‑end seguente applica lo stesso piè di pagina, testo data/ora e visibilità del numero di diapositiva a tutte le diapositive regolari:

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

Se è necessario aggiornare una sola diapositiva, accedi direttamente a quella diapositiva tramite il metodo [`getSlides`](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#getSlides--) invece di iterare sull’intera collezione.

## **Imposta intestazioni e piè di pagina sul master note**

Il master note definisce la formattazione comune e il comportamento dei segnaposti per le pagine note. Usa l’interfaccia [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/) quando desideri modificare solo il master note stesso.

L’esempio seguente imposta intestazione, piè di pagina e testo data/ora sul master note e rende tutti i segnaposti supportati visibili su quel master:

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

Il metodo [`getMasterNotesSlide`](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/imasternotesslidemanager/#getMasterNotesSlide--) restituisce `null` quando la presentazione non contiene un master note.

## **Applica impostazioni del master note alle diapositive note figlie**

Un master note può applicare le impostazioni di intestazione e piè di pagina a sé stesso e a tutte le diapositive note dipendenti. Usa i metodi di propagazione dedicati su [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/) quando le stesse impostazioni devono essere applicate all’intera gerarchia note.

Ad esempio, [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersText-java.lang.String-) e [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility-boolean-) aggiornano l’intestazione del master note e tutte le intestazioni figlie. Metodi equivalenti sono disponibili per i piè di pagina, data/ora e numeri di diapositiva.

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

I metodi di propagazione usati sopra sono [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersText-java.lang.String-), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility-boolean-), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText-java.lang.String-), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility-boolean-), e [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility-boolean-).

## **Imposta intestazioni e piè di pagina su una diapositiva note individuale**

Una diapositiva note appartiene a una specifica diapositiva regolare. Usa la sua interfaccia [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/inotesslideheaderfootermanager/) quando desideri personalizzare solo quella pagina note.

Il metodo [`addNotesSlide`](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/inotesslidemanager/#addNotesSlide--) restituisce la diapositiva note per la diapositiva corrente e ne crea una se non esiste già. L’esempio seguente configura la pagina note associata alla prima diapositiva della presentazione:

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

Se prima propaghi le impostazioni dal master note e poi modifichi una diapositiva note singola, le impostazioni successive per diapositiva consentono di personalizzare quella pagina note in modo indipendente.

## **Imposta intestazioni e piè di pagina sul master handout**

Le pagine handout utilizzano il master handout per i loro segnaposti di intestazione, piè di pagina, data/ora e numero di pagina. A differenza delle pagine note, le impostazioni handout sono gestite tramite il master handout anziché tramite singole diapositive handout.

Usa il metodo [`getMasterHandoutSlide`](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/imasterhandoutslidemanager/#getMasterHandoutSlide--) per accedere al master handout. Se non è presente, chiama [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) per creare il master handout predefinito.

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

## **Comprendere ambito ed eredità**

Scegli il gestore intestazione/piè di pagina che corrisponde all’ambito che desideri modificare:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islideheaderfootermanager/) modifica le impostazioni di piè di pagina, data/ora e numero di diapositiva per una singola diapositiva regolare.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ilayoutslideheaderfootermanager/) controlla una diapositiva layout e può propagare le impostazioni supportate alle diapositive dipendenti.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/imasterslideheaderfootermanager/) controlla un master diapositiva regolare e può propagare le impostazioni supportate alle diapositive dipendenti.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/) controlla il master note e può propagare le impostazioni a tutte le diapositive note dipendenti.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/inotesslideheaderfootermanager/) modifica una singola diapositiva note e supporta un segnaposto di intestazione oltre a piè di pagina, data/ora e numero di diapositiva.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/imasterhandoutslideheaderfootermanager/) modifica il master handout e supporta tutti e quattro i tipi di segnaposto.

Usa la propagazione da un master o layout quando la stessa impostazione deve applicarsi a tutta la sua gerarchia. Usa un gestore di diapositiva individuale o di diapositiva note quando è necessaria un’impostazione locale per una sola pagina.

## **FAQ**

**Posso aggiungere un’intestazione a una diapositiva regolare?**

No. PowerPoint non definisce un segnaposto di intestazione per le diapositive regolari. Su diapositive regolari, utilizza i segnaposti di piè di pagina, data/ora e numero di diapositiva. I segnaposti di intestazione sono disponibili su pagine note e handout.

**Cosa succede se un segnaposto di piè di pagina, data/ora o numero di diapositiva non è visibile?**

Usa il gestore intestazione/piè di pagina corrispondente per verificare la sua visibilità e abilitarlo quando necessario. Ad esempio, [`isFooterVisible`](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/baseslideheaderfootomanager/#isFooterVisible--) segnala se un segnaposto di piè di pagina è presente, e [`setFooterVisibility`](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/baseslideheaderfootomanager/#setFooterVisibility-boolean-) ne cambia la visibilità.

**Come faccio a far partire la numerazione delle diapositive da un valore diverso da 1?**

Chiama il metodo [`setFirstSlideNumber`](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) della presentazione. I segnaposti di numero di diapositiva utilizzeranno la sequenza di numerazione aggiornata.

**Cosa accade alle intestazioni e ai piè di pagina durante l’esportazione in PDF, immagini o HTML?**

Gli elementi di intestazione e piè di pagina visibili vengono renderizzati insieme al resto del contenuto della presentazione nel formato di output. Il loro aspetto dipende dal tipo di pagina esportata e dalle impostazioni di visibilità dei segnaposti corrispondenti.