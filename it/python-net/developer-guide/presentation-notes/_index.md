---
title: Gestisci le note della presentazione in Python
linktitle: Note della presentazione
type: docs
weight: 110
url: /it/python-net/presentation-notes/
keywords:
- note
- diapositiva delle note
- aggiungi note
- rimuovi note
- stile delle note
- note master
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Personalizza le note della presentazione con Aspose.Slides per Python tramite .NET. Lavora senza sforzo con le note di PowerPowerPoint e OpenDocument per aumentare la tua produttività."
---
## **Panoramica**

Aspose.Slides supporta la rimozione delle diapositive delle note da una presentazione. In questo argomento, introdurremo questa funzionalità, inclusa la rimozione delle note e l'applicazione di uno stile alle diapositive delle note in una presentazione. Aspose.Slides consente di rimuovere le note da qualsiasi diapositiva e anche di applicare stili alle note esistenti. Gli sviluppatori possono rimuovere le note nei seguenti modi:

- Rimuovere le note da una diapositiva specifica in una presentazione.
- Rimuovere le note da tutte le diapositive in una presentazione.

## **Rimuovi le note dalla diapositiva**
Le note di una diapositiva specifica possono essere rimosse come mostrato nell'esempio seguente:

```py
import aspose.slides as slides

# Istanzia un oggetto Presentation che rappresenta un file di presentazione 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Rimozione delle note della prima diapositiva
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # salva la presentazione su disco
    presentation.save("RemoveNotesAtSpecificSlide_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Rimuovi le note da tutte le diapositive**
Le note di tutte le diapositive di una presentazione possono essere rimosse come mostrato nell'esempio seguente:

```py
import aspose.slides as slides

# Instanzia un oggetto Presentation che rappresenta un file di presentazione 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Rimozione delle note di tutte le diapositive
    for i in range(len(presentation.slides)):
        mgr = presentation.slides[i].notes_slide_manager
        mgr.remove_notes_slide()
    # salva la presentazione su disco
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Aggiungi NotesStyle**
La proprietà [notes_style](https://reference.aspose.com/slides/it/python-net/aspose.slides/masternotesslide/notes_style/) è stata aggiunta alla classe [MasterNotesSlide](https://reference.aspose.com/slides/it/python-net/aspose.slides/masternotesslide/). Questa proprietà specifica lo stile di un testo delle note. L'implementazione è mostrata nell'esempio seguente.

```py
import aspose.slides as slides

# Instanzia la classe Presentation che rappresenta il file di presentazione
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # Ottieni lo stile del testo di MasterNotesSlide
        notesStyle = notesMaster.notes_style

        #Imposta bullet simbolico per i paragrafi di primo livello
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # salva il file PPTX sul disco
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Quale entità API fornisce l'accesso alle note di una diapositiva specifica?**

Le note sono accessibili tramite il gestore delle note della diapositiva: la diapositiva ha un [NotesSlideManager](https://reference.aspose.com/slides/it/python-net/aspose.slides/notesslidemanager/) e una [property](https://reference.aspose.com/slides/it/python-net/aspose.slides/notesslidemanager/notes_slide/) che restituisce l'oggetto note, o `None` se non ci sono note.

**Ci sono differenze nel supporto alle note tra le versioni di PowerPoint con cui la libreria funziona?**

La libreria supporta un'ampia gamma di formati Microsoft PowerPoint (97–versioni successive) e ODP; le note sono supportate in questi formati senza dipendere da una copia installata di PowerPoint.