---
title: Gestire intestazioni e piè di pagina della presentazione in Python via Java
linktitle: Intestazione e Piè di pagina
type: docs
weight: 140
url: /it/python-java/presentation-header-and-footer/
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
- Python
- Java
- Aspose.Slides
description: "Scopri come gestire i segnaposti di piè di pagina, data/ora, numero diapositiva e intestazione su diapositive, pagine note e opuscoli con Aspose.Slides per Python via Java."
---
## **Panoramica**

PowerPoint utilizza segnaposti di intestazione e piè di pagina diversi a seconda del tipo di pagina. Aspose.Slides for Python via Java consente di controllare il testo e la visibilità di questi segnaposti tramite le classi manager di intestazione/piè di pagina.

I segnaposti disponibili dipendono dall’ambito:

| Ambito | Intestazione | Piè di pagina | Data/ora | Numero diapositiva/pagina |
|---|---|---|---|---|
| Diapositiva regolare | No | Sì | Sì | Sì |
| Schema note | Sì | Sì | Sì | Sì |
| Diapositiva note | Sì | Sì | Sì | Sì |
| Schema opuscolo | Sì | Sì | Sì | Sì |

Una diapositiva regolare non ha un segnaposto di intestazione. Le intestazioni sono disponibili nelle pagine note e negli opuscoli. Per le diapositive regolari, utilizzare i segnaposti di piè di pagina, data/ora e numero diapositiva.

L’ambito di una modifica dipende dal manager utilizzato. La classe [SlideHeaderFooterManager](https://reference.aspose.com/slides/it/python-java/aspose.slides/slideheaderfootermanager/) controlla una singola diapositiva regolare. La classe [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/it/python-java/aspose.slides/notesslideheaderfootermanager/) controlla una singola diapositiva note. I manager di schema e layout possono anche propagare le impostazioni alle diapositive dipendenti, mentre la classe [MasterHandoutSlideHeaderFooterManager](https://reference.aspose.com/slides/it/python-java/aspose.slides/masterhandoutslideheaderfootermanager/) controlla lo schema opuscolo.

## **Imposta piè di pagina, data/ora e numeri di diapositiva sulle diapositive regolari**

Per le diapositive regolari, il flusso di lavoro base è accedere al manager di intestazione/piè di pagina di ciascuna diapositiva, impostare il testo del piè di pagina e della data/ora, abilitare i segnaposti richiesti e salvare la presentazione. I numeri di diapositiva sono generati dalla presentazione, quindi è necessario controllarne solo la visibilità.

Usa [setFooterText](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterText) e [setDateTimeText](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeText) per impostare il testo, e utilizza [setFooterVisibility](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility), [setDateTimeVisibility](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility) e [setSlideNumberVisibility](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility) per mostrare i corrispondenti segnaposti.

Il seguente esempio end‑to‑end applica lo stesso piè di pagina, testo data/ora e visibilità del numero di diapositiva a tutte le diapositive regolari:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        header_footer_manager = slide.getHeaderFooterManager()

        header_footer_manager.setFooterText("Company Confidential")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_slide_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Se è necessario aggiornare una sola diapositiva, accedi direttamente a quella diapositiva tramite il metodo [getSlides](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getSlides) anziché iterare sull’intera collezione.

## **Imposta intestazioni e piè di pagina sullo schema note**

Lo schema note definisce la formattazione comune e il comportamento dei segnaposti per le pagine note. Usa la classe [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/it/python-java/aspose.slides/masternotesslideheaderfootermanager/) quando vuoi modificare solo lo schema note stesso.

Il seguente esempio imposta intestazione, piè di pagina e testo data/ora sullo schema note e rende tutti i segnaposti supportati visibili su quello schema:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_notes_slide = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderText("Notes header")
        header_footer_manager.setHeaderVisibility(True)

        header_footer_manager.setFooterText("Notes footer")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il metodo `getMasterNotesSlide` restituisce `None` quando la presentazione non contiene uno schema note.

## **Applica le impostazioni dello schema note alle diapositive note figlie**

Uno schema note può applicare le impostazioni di intestazione e piè di pagina a sé stesso e a tutte le diapositive note dipendenti. Usa i metodi di propagazione dedicati su [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/it/python-java/aspose.slides/masternotesslideheaderfootermanager/) quando le stesse impostazioni devono essere applicate all’intera gerarchia delle note.

Ad esempio, [setHeaderAndChildHeadersText](https://reference.aspose.com/slides/it/python-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersText) e [setHeaderAndChildHeadersVisibility](https://reference.aspose.com/slides/it/python-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility) aggiornano l’intestazione dello schema note e tutte le intestazioni figlie. Metodi equivalenti sono disponibili per i piè di pagina, data/ora e numeri di diapositiva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_notes_slide = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderAndChildHeadersText("Notes header")
        header_footer_manager.setHeaderAndChildHeadersVisibility(True)

        header_footer_manager.setFooterAndChildFootersText("Notes footer")
        header_footer_manager.setFooterAndChildFootersVisibility(True)

        header_footer_manager.setDateTimeAndChildDateTimesText("Date and time text")
        header_footer_manager.setDateTimeAndChildDateTimesVisibility(True)

        header_footer_manager.setSlideNumberAndChildSlideNumbersVisibility(True)

    presentation.save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

I metodi di propagazione usati sopra sono [setFooterAndChildFootersText](https://reference.aspose.com/slides/it/python-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersText), [setFooterAndChildFootersVisibility](https://reference.aspose.com/slides/it/python-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility), [setDateTimeAndChildDateTimesText](https://reference.aspose.com/slides/it/python-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText), [setDateTimeAndChildDateTimesVisibility](https://reference.aspose.com/slides/it/python-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility) e [setSlideNumberAndChildSlideNumbersVisibility](https://reference.aspose.com/slides/it/python-java/aspose.slides/masternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility).

## **Imposta intestazioni e piè di pagina su una singola diapositiva note**

Una diapositiva note appartiene a una specifica diapositiva regolare. Usa la sua classe [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/it/python-java/aspose.slides/notesslideheaderfootermanager/) quando vuoi personalizzare solo quella pagina note.

Il metodo [addNotesSlide](https://reference.aspose.com/slides/it/python-java/aspose.slides/notesslidemanager/#addNotesSlide) restituisce la diapositiva note per la diapositiva corrente e ne crea una se non esiste già. Il seguente esempio configura la pagina note associata alla prima diapositiva della presentazione:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    header_footer_manager = notes_slide.getHeaderFooterManager()

    header_footer_manager.setHeaderText("Header for the first notes page")
    header_footer_manager.setHeaderVisibility(True)

    header_footer_manager.setFooterText("Footer for the first notes page")
    header_footer_manager.setFooterVisibility(True)

    header_footer_manager.setDateTimeText("Date and time text")
    header_footer_manager.setDateTimeVisibility(True)

    header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Se prima propaghi le impostazioni dallo schema note e poi modifichi una diapositiva note individuale, le impostazioni successive per diapositiva consentono di personalizzare quella pagina note in modo indipendente.

## **Imposta intestazioni e piè di pagina sullo schema opuscolo**

Le pagine opuscolo usano lo schema opuscolo per i loro segnaposti di intestazione, piè di pagina, data/ora e numero pagina. A differenza delle pagine note, le impostazioni degli opuscoli sono gestite tramite lo schema opuscolo anziché tramite singole diapositive opuscolo.

Usa il metodo `getMasterHandoutSlide` per accedere allo schema opuscolo. Se non è presente, chiama `setDefaultMasterHandoutSlide` per creare lo schema opuscolo predefinito.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_handout_slide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide()

    if master_handout_slide is None:
        master_handout_slide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide()

    if master_handout_slide is not None:
        header_footer_manager = master_handout_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderText("Handout header")
        header_footer_manager.setHeaderVisibility(True)

        header_footer_manager.setFooterText("Handout footer")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_handout_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Comprendi ambito ed ereditarietà**

Scegli il manager di intestazione/piè di pagina che corrisponde all’ambito che desideri modificare:

- [SlideHeaderFooterManager](https://reference.aspose.com/slides/it/python-java/aspose.slides/slideheaderfootermanager/) modifica le impostazioni di piè di pagina, data/ora e numero diapositiva per una singola diapositiva regolare.
- [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/it/python-java/aspose.slides/layoutslideheaderfootermanager/) controlla una diapositiva layout e può propagare le impostazioni supportate alle diapositive dipendenti.
- [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/it/python-java/aspose.slides/masterslideheaderfootermanager/) controlla uno schema diapositiva regolare e può propagare le impostazioni supportate alle diapositive dipendenti.
- [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/it/python-java/aspose.slides/masternotesslideheaderfootermanager/) controlla lo schema note e può propagare le impostazioni a tutte le diapositive note dipendenti.
- [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/it/python-java/aspose.slides/notesslideheaderfootermanager/) modifica una singola diapositiva note e supporta un segnaposto di intestazione oltre a piè di pagina, data/ora e numero diapositiva.
- [MasterHandoutSlideHeaderFooterManager](https://reference.aspose.com/slides/it/python-java/aspose.slides/masterhandoutslideheaderfootermanager/) modifica lo schema opuscolo e supporta tutti e quattro i tipi di segnaposto.

Usa la propagazione da uno schema o layout quando la stessa impostazione deve applicarsi a tutta la gerarchia. Usa un manager di diapositiva individuale o di diapositiva note quando hai bisogno di un’impostazione locale per una sola pagina.

## **FAQ**

**Posso aggiungere un’intestazione a una diapositiva regolare?**

No. PowerPoint non definisce un segnaposto di intestazione per le diapositive regolari. Su diapositive regolari, usa i segnaposti di piè di pagina, data/ora e numero diapositiva. I segnaposti di intestazione sono disponibili nelle pagine note e negli opuscoli.

**Cosa succede se un segnaposto di piè di pagina, data/ora o numero diapositiva non è visibile?**

Usa il manager di intestazione/piè di pagina corrispondente per verificare la sua visibilità e abilitarlo quando necessario. Per esempio, [isFooterVisible](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseslideheaderfootermanager/#isFooterVisible) indica se è presente un segnaposto di piè di pagina, e [setFooterVisibility](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility) ne modifica la visibilità.

**Come faccio a far partire la numerazione delle diapositive da un valore diverso da 1?**

Chiama il metodo [setFirstSlideNumber](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#setFirstSlideNumber) della presentazione. I segnaposti di numero diapositiva utilizzeranno la sequenza di numerazione aggiornata.

**Cosa succede a intestazioni e piè di pagina quando si esporta in PDF, immagini o HTML?**

Gli elementi di intestazione e piè di pagina visibili vengono renderizzati insieme al resto del contenuto della presentazione nel formato di output. La loro apparenza dipende dal tipo di pagina esportata e dalle impostazioni di visibilità dei segnaposti corrispondenti.