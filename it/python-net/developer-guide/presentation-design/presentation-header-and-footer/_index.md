---
title: Gestire intestazioni e piè di pagina della presentazione con Python
linktitle: Intestazione e Piè di pagina
type: docs
weight: 140
url: /it/python-net/presentation-header-and-footer/
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
- Aspose.Slides
description: "Scopri come gestire i segnaposti di piè di pagina, data/ora, numero diapositiva e intestazione su diapositive, pagine delle note e opuscoli con Aspose.Slides per Python via .NET."
---
## **Panoramica**

PowerPoint utilizza segnaposti di intestazione e piè di pagina diversi a seconda del tipo di pagina. Aspose.Slides per Python via .NET consente di controllare il testo e la visibilità di questi segnaposti tramite le classi manager di intestazione/piè di pagina.

I segnaposti disponibili dipendono dall'ambito:

| Ambito | Intestazione | Piè di pagina | Data/ora | Numero diapositiva/pagina |
|---|---|---|---|---|
| Diapositiva normale | No | Sì | Sì | Sì |
| Master note | Sì | Sì | Sì | Sì |
| Diapositiva della nota | Sì | Sì | Sì | Sì |
| Master opuscolo | Sì | Sì | Sì | Sì |

Una diapositiva di presentazione normale non ha un segnaposto di intestazione. Le intestazioni sono disponibili sulle pagine delle note e sugli opuscoli. Per le diapositive normali, utilizzare invece i segnaposti di piè di pagina, data/ora e numero diapositiva.

L'ambito di una modifica dipende dal manager che si utilizza. La classe [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/it/python-net/aspose.slides/slideheaderfootermanager/) controlla una diapositiva normale. La classe [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/python-net/aspose.slides/notesslideheaderfootermanager/) controlla una diapositiva di note. I manager master e layout possono anche propagare le impostazioni alle diapositive dipendenti, mentre la classe [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/python-net/aspose.slides/masterhandoutslideheaderfootermanager/) controlla il master opuscolo.

## **Impostare piè di pagina, data/ora e numeri diapositiva sulle diapositive normali**

Per le diapositive normali, il flusso di lavoro di base consiste nell'accedere al manager di intestazione/piè di pagina di ciascuna diapositiva, impostare il testo del piè di pagina e della data/ora, abilitare i segnaposti richiesti e salvare la presentazione. I numeri di diapositiva sono generati dalla presentazione, quindi è necessario controllarne solo la visibilità.

Utilizzare [`set_footer_text`](https://reference.aspose.com/slides/it/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_text/) e [`set_date_time_text`](https://reference.aspose.com/slides/it/python-net/aspose.slides/baseslideheaderfootermanager/set_date_time_text/) per impostare il testo, e utilizzare [`set_footer_visibility`](https://reference.aspose.com/slides/it/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_visibility/), [`set_date_time_visibility`](https://reference.aspose.com/slides/it/python-net/aspose.slides/baseslideheaderfootermanager/set_date_time_visibility/), e [`set_slide_number_visibility`](https://reference.aspose.com/slides/it/python-net/aspose.slides/baseslideheaderfootermanager/set_slide_number_visibility/) per mostrare i corrispondenti segnaposti.

L'esempio end‑to‑end seguente applica lo stesso piè di pagina, testo data/ora e visibilità del numero diapositiva a tutte le diapositive normali:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        header_footer_manager = slide.header_footer_manager

        header_footer_manager.set_footer_text("Company Confidential")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_slide_footers.pptx", slides.export.SaveFormat.PPTX)
```

Se è necessario aggiornare solo una diapositiva, accedere a quella diapositiva direttamente tramite la collezione [`slides`](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/slides/it/) invece di iterare sull'intera collezione.

## **Impostare intestazioni e piè di pagina sul master note**

Il master note definisce la formattazione comune e il comportamento dei segnaposti per le pagine delle note. Utilizzare la classe [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/python-net/aspose.slides/masternotesslideheaderfootermanager/) quando si desidera modificare solo il master note stesso.

L'esempio seguente imposta intestazione, piè di pagina e testo data/ora sul master note e rende visibili tutti i segnaposti supportati in quel master:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        header_footer_manager.set_header_text("Notes header")
        header_footer_manager.set_header_visibility(True)

        header_footer_manager.set_footer_text("Notes footer")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_notes_master_footers.pptx", slides.export.SaveFormat.PPTX)
```

Una presentazione potrebbe non contenere un master note, quindi verificare il valore restituito per `None` prima di modificarlo.

## **Applicare le impostazioni del master note alle diapositive di note figlie**

Un master note può applicare le impostazioni di intestazione e piè di pagina a sé stesso e a tutte le diapositive di note dipendenti. Utilizzare i metodi di propagazione dedicati su [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/python-net/aspose.slides/masternotesslideheaderfootermanager/) quando le stesse impostazioni devono essere applicate all'intera gerarchia delle note.

Ad esempio, [`set_header_and_child_headers_text`](https://reference.aspose.com/slides/it/python-net/aspose.slides/masternotesslideheaderfootermanager/set_header_and_child_headers_text/) e [`set_header_and_child_headers_visibility`](https://reference.aspose.com/slides/it/python-net/aspose.slides/masternotesslideheaderfootermanager/set_header_and_child_headers_visibility/) aggiornano l'intestazione del master note e tutte le intestazioni figlie. Metodi equivalenti sono disponibili per i piè di pagina, data/ora e numeri diapositiva.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        header_footer_manager.set_header_and_child_headers_text("Notes header")
        header_footer_manager.set_header_and_child_headers_visibility(True)

        header_footer_manager.set_footer_and_child_footers_text("Notes footer")
        header_footer_manager.set_footer_and_child_footers_visibility(True)

        header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")
        header_footer_manager.set_date_time_and_child_date_times_visibility(True)

        header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)

    presentation.save("presentation_with_child_notes_footers.pptx", slides.export.SaveFormat.PPTX)
```

I metodi di propagazione usati sopra sono [`set_footer_and_child_footers_text`](https://reference.aspose.com/slides/it/python-net/aspose.slides/masternotesslideheaderfootermanager/set_footer_and_child_footers_text/), [`set_footer_and_child_footers_visibility`](https://reference.aspose.com/slides/it/python-net/aspose.slides/masternotesslideheaderfootermanager/set_footer_and_child_footers_visibility/), [`set_date_time_and_child_date_times_text`](https://reference.aspose.com/slides/it/python-net/aspose.slides/masternotesslideheaderfootermanager/set_date_time_and_child_date_times_text/), [`set_date_time_and_child_date_times_visibility`](https://reference.aspose.com/slides/it/python-net/aspose.slides/masternotesslideheaderfootermanager/set_date_time_and_child_date_times_visibility/), e [`set_slide_number_and_child_slide_numbers_visibility`](https://reference.aspose.com/slides/it/python-net/aspose.slides/masternotesslideheaderfootermanager/set_slide_number_and_child_slide_numbers_visibility/).

## **Impostare intestazioni e piè di pagina su una diapositiva di note individuale**

Una diapositiva di note appartiene a una diapositiva normale specifica. Utilizzare la sua classe [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/python-net/aspose.slides/notesslideheaderfootermanager/) quando si desidera personalizzare solo quella pagina di note.

Il metodo [`add_notes_slide`](https://reference.aspose.com/slides/it/python-net/aspose.slides/notesslidemanager/add_notes_slide/) restituisce la diapositiva di note per la diapositiva corrente e ne crea una se non esiste già. L'esempio seguente configura la pagina di note associata alla prima diapositiva della presentazione:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    notes_slide = presentation.slides[0].notes_slide_manager.add_notes_slide()
    header_footer_manager = notes_slide.header_footer_manager

    header_footer_manager.set_header_text("Header for the first notes page")
    header_footer_manager.set_header_visibility(True)

    header_footer_manager.set_footer_text("Footer for the first notes page")
    header_footer_manager.set_footer_visibility(True)

    header_footer_manager.set_date_time_text("Date and time text")
    header_footer_manager.set_date_time_visibility(True)

    header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_custom_notes_footers.pptx", slides.export.SaveFormat.PPTX)
```

Se prima si propagano le impostazioni dal master note e poi si modifica una diapositiva di note individuale, le impostazioni per diapositiva successive consentono di personalizzare quella pagina di note in modo indipendente.

## **Impostare intestazioni e piè di pagina sul master opuscolo**

Le pagine dell'opuscolo utilizzano il master opuscolo per i loro segnaposti di intestazione, piè di pagina, data/ora e numero pagina. Diversamente dalle pagine delle note, le impostazioni dell'opuscolo sono gestite tramite il master opuscolo anziché tramite singole diapositive di opuscolo.

Utilizzare la proprietà [`master_handout_slide`](https://reference.aspose.com/slides/it/python-net/aspose.slides/imasterhandoutslidemanager/master_handout_slide/) per accedere al master opuscolo. Se non è presente, chiamare [`set_default_master_handout_slide`](https://reference.aspose.com/slides/it/python-net/aspose.slides/imasterhandoutslidemanager/set_default_master_handout_slide/) per creare il master opuscolo predefinito.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_handout_slide = presentation.master_handout_slide_manager.master_handout_slide

    if master_handout_slide is None:
        presentation.master_handout_slide_manager.set_default_master_handout_slide()
        master_handout_slide = presentation.master_handout_slide_manager.master_handout_slide

    if master_handout_slide is not None:
        header_footer_manager = master_handout_slide.header_footer_manager

        header_footer_manager.set_header_text("Handout header")
        header_footer_manager.set_header_visibility(True)

        header_footer_manager.set_footer_text("Handout footer")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_handout_footers.pptx", slides.export.SaveFormat.PPTX)
```

## **Comprendere ambito ed ereditarietà**

Scegliere il manager di intestazione/piè di pagina che corrisponde all'ambito da modificare:

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/it/python-net/aspose.slides/slideheaderfootermanager/) modifica le impostazioni di piè di pagina, data/ora e numero diapositiva per una diapositiva normale.
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/python-net/aspose.slides/layoutslideheaderfootermanager/) controlla una diapositiva layout e può propagare le impostazioni supportate alle diapositive dipendenti.
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/python-net/aspose.slides/masterslideheaderfootermanager/) controlla un master diapositiva normale e può propagare le impostazioni supportate alle diapositive dipendenti.
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/python-net/aspose.slides/masternotesslideheaderfootermanager/) controlla il master note e può propagare le impostazioni a tutte le diapositive di note dipendenti.
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/python-net/aspose.slides/notesslideheaderfootermanager/) modifica una singola diapositiva di note e supporta un segnaposto di intestazione oltre a piè di pagina, data/ora e numero diapositiva.
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/it/python-net/aspose.slides/masterhandoutslideheaderfootermanager/) modifica il master opuscolo e supporta tutti e quattro i tipi di segnaposto.

Utilizzare la propagazione da un master o layout quando la stessa impostazione deve essere applicata a tutta la sua gerarchia. Utilizzare un manager di diapositiva individuale o di diapositiva di note quando è necessario un'impostazione locale per una sola pagina.

## **FAQ**

**Posso aggiungere un'intestazione a una diapositiva normale?**

No. PowerPoint non definisce un segnaposto di intestazione per le diapositive normali. Su queste diapositive, utilizzare i segnaposti di piè di pagina, data/ora e numero diapositiva. I segnaposti di intestazione sono disponibili sulle pagine delle note e sugli opuscoli.

**Cosa succede se un segnaposto di piè di pagina, data/ora o numero diapositiva non è visibile?**

Utilizzare il manager di intestazione/piè di pagina corrispondente per verificare la sua visibilità e abilitarlo quando necessario. Ad esempio, [`is_footer_visible`](https://reference.aspose.com/slides/it/python-net/aspose.slides/baseslideheaderfootermanager/is_footer_visible/) indica se è presente un segnaposto di piè di pagina, e [`set_footer_visibility`](https://reference.aspose.com/slides/it/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_visibility/) ne modifica la visibilità.

**Come avvio la numerazione delle diapositive da un valore diverso da 1?**

Impostare la proprietà [`first_slide_number`](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/first_slide_number/) della presentazione. I segnaposti del numero diapositiva utilizzeranno la sequenza di numerazione aggiornata.

**Cosa succede a intestazioni e piè di pagina durante l'esportazione in PDF, immagini o HTML?**

Gli elementi di intestazione e piè di pagina visibili sono renderizzati insieme al resto del contenuto della presentazione nel formato di output. La loro apparizione dipende dal tipo di pagina esportata e dalle impostazioni di visibilità dei relativi segnaposti.