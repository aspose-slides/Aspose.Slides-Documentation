---
title: Gestisci intestazioni e piè di pagina della presentazione con Python
linktitle: Intestazione e piè di pagina
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
- volantino
- note
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Utilizza Aspose.Slides per Python tramite .NET per aggiungere e personalizzare intestazioni e piè di pagina in presentazioni PowerPoint e OpenDocument per un aspetto professionale."
---
## **Panoramica**

Aspose.Slides for Python consente di controllare i segnaposto di intestazione e piè di pagina in un’intera presentazione con precisione. Il testo del piè di pagina, la data/ora e i numeri delle diapositive sono gestiti a livello master e possono essere applicati globalmente o regolati per diapositiva. Le intestazioni sono supportate su note e volanti, dove è possibile attivare la visibilità e impostare il testo per intestazione, piè di pagina, data/ora e numeri di pagina tramite il gestore intestazione e piè di pagina dedicato sul master delle note o su singole diapositive delle note. Questo articolo descrive i modelli principali per aggiornare questi segnaposto e propagare le modifiche in modo coerente in tutta la presentazione.

## **Gestire testo intestazione e piè di pagina**

In questa sezione imparerai a gestire il contenuto di intestazione e piè di pagina in una presentazione—abilitare o modificare il piè di pagina, data e ora e numeri di diapositiva. Illustreremo brevemente gli ambiti di applicazione di queste impostazioni (intera presentazione, singole diapositive e visualizzazioni note/volante) e mostreremo come utilizzare le API di Aspose.Slides per aggiornarle rapidamente e in modo coerente.

Il codice di esempio qui sotto apre una presentazione, abilita e imposta il testo del piè di pagina, aggiorna il testo dell’intestazione sul master delle note e salva il file.

```py
import aspose.slides as slides

# Funzione per impostare il testo dell'intestazione.
def update_header_footer_text(master):
    for shape in master.shapes:
        if shape.placeholder is not None:
            if shape.placeholder.type == slides.PlaceholderType.HEADER:
                shape.text_frame.text = "Hi, there is a header"


# Carica la presentazione.
with slides.Presentation("sample.pptx") as presentation:
    # Imposta il piè di pagina.
    presentation.header_footer_manager.set_all_footers_text("My Footer text")
    presentation.header_footer_manager.set_all_footers_visibility(True)

    # Accedi e aggiorna l'intestazione.
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        update_header_footer_text(master_notes_slide)

    # Salva la presentazione.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Gestire intestazione e piè di pagina nelle diapositive delle note**

In questa sezione imparerai a gestire intestazioni e piè di pagina specificamente per le diapositive delle note in Aspose.Slides. Tratteremo l’attivazione dei segnaposto rilevanti, l’impostazione del testo per piè di pagina, data/ora e numeri di pagina, e l’applicazione coerente di queste modifiche sul master delle note e sulle singole pagine delle note.

Segui i passaggi seguenti:

1. Carica un file di presentazione.  
2. Ottieni la diapositiva master delle note e il suo [header & footer manager](https://reference.aspose.com/slides/it/python-net/aspose.slides/masternotesslideheaderfootermanager/).  
3. Sulla diapositiva master delle note, abilita la visibilità di Header, Footer, Slide number e Date-time per il master e tutte le diapositive delle note figlie.  
4. Sulla diapositiva master delle note, imposta il testo per Header, Footer e Date-time per il master e tutte le diapositive delle note figlie.  
5. Ottieni la diapositiva delle note per la prima diapositiva della presentazione e il suo [header & footer manager](https://reference.aspose.com/slides/it/python-net/aspose.slides/notesslideheaderfootermanager/).  
6. Solo per questa prima diapositiva delle note, assicurati che Header, Footer, Slide number e Date-time siano visibili (attiva quelli spenti).  
7. Solo per questa prima diapositiva delle note, imposta il testo per Header, Footer e Date-time.  
8. Salva la presentazione in formato PPTX.  

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        # Rendi visibile la diapositiva master delle note e tutti i segnaposto di intestazione, piè di pagina, numero diapositiva e data/ora dei figli.
        header_footer_manager.set_header_and_child_headers_visibility(True)
        header_footer_manager.set_footer_and_child_footers_visibility(True)
        header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
        header_footer_manager.set_date_time_and_child_date_times_visibility(True)

        # Imposta il testo sulla diapositiva master delle note e su tutti i segnaposto di intestazione, piè di pagina e data/ora dei figli.
        header_footer_manager.set_header_and_child_headers_text("Header text")
        header_footer_manager.set_footer_and_child_footers_text("Footer text")
        header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    # Modifica le impostazioni di intestazione, piè di pagina, numero diapositiva e data/ora solo per la prima diapositiva delle note.
    notesSlide = presentation.slides[0].notes_slide_manager.notes_slide
    if notesSlide is not None:
        header_footer_manager = notesSlide.header_footer_manager

        # Assicurati che i segnaposto di intestazione, piè di pagina, numero diapositiva e data/ora siano visibili.
        if not header_footer_manager.is_header_visible:
            header_footer_manager.set_header_visibility(True)

        if not header_footer_manager.is_footer_visible:
            header_footer_manager.set_footer_visibility(True)

        if not header_footer_manager.is_slide_number_visible:
            header_footer_manager.set_slide_number_visibility(True)

        if not header_footer_manager.is_date_time_visible:
            header_footer_manager.set_date_time_visibility(True)

        # Imposta il testo sui segnaposto di intestazione, piè di pagina e data/ora della diapositiva delle note.
        header_footer_manager.set_header_text("New header text")
        header_footer_manager.set_footer_text("New footer text")
        header_footer_manager.set_date_time_text("New date and time text")

    # Salva la presentazione.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Posso aggiungere un "header" alle diapositive normali?**

In PowerPoint, "Header" esiste solo per le note e i volanti; nelle diapositive normali, gli elementi supportati sono il Footer, DateTime e SlideNumber. In Aspose.Slides ciò corrisponde alle stesse limitazioni: header solo per Notes/Handout, e su diapositive—Footer/DateTime/SlideNumber.

**Cosa succede se il layout non contiene un'area piè di pagina—posso "attivare" la sua visibilità?**

Sì. Verifica la visibilità tramite il header/footer manager e abilitala se necessario. Questi indicatori e metodi API sono progettati per i casi in cui il segnaposto è assente o nascosto.

**Come faccio a far partire il numero della diapositiva da un valore diverso da 1?**

Imposta il [first slide number](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/first_slide_number/) della presentazione; dopo di che, tutta la numerazione viene ricalcolata. Ad esempio, puoi iniziare da 0 o 10, e nascondere il numero nella diapositiva del titolo.

**Cosa succede a intestazioni e piè di pagina quando si esporta in PDF/immagini/HTML?**

Vengono renderizzate come normali elementi di testo della presentazione. Vale a dire, se gli elementi sono visibili nelle diapositive/nelle pagine delle note, appariranno anche nel formato di output insieme al resto del contenuto.