---
title: Gestire le note della presentazione in Python
linktitle: Note della presentazione
type: docs
weight: 110
url: /it/python-net/presentation-notes/
keywords:
- note
- diapositiva di note
- aggiungere note
- rimuovere note
- stile delle note
- note master
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Personalizza le note della presentazione con Aspose.Slides per Python via .NET. Lavora senza problemi con le note di PowerPowerPoint e OpenDocument per aumentare la tua produttività."
---
## **Panoramica**

Aspose.Slides supporta la rimozione delle diapositive di note da una presentazione. In questo argomento, introdurremo questa funzionalità, inclusa la rimozione delle note e l'applicazione di uno stile alle diapositive di note in una presentazione. Aspose.Slides consente di rimuovere le note da qualsiasi diapositiva e di applicare lo stile alle note esistenti. Gli sviluppatori possono rimuovere le note nei seguenti modi:

- Rimuovere le note da una diapositiva specifica in una presentazione.
- Rimuovere le note da tutte le diapositive in una presentazione.

Per leggere o modificare le dimensioni della pagina delle note, cambiare orientamento e verificare il comportamento di esportazione, vedere [Dimensioni della pagina delle note](/slides/it/python-net/notes-size/).

## **Rimuovere le note da una diapositiva**
Le note da una diapositiva specifica possono essere rimosse come mostrato nell'esempio sottostante:

```py
import aspose.slides as slides

# Istanziare un oggetto Presentation che rappresenta un file di presentazione 
with slides.Presentation("AccessSlides.pptx") as presentation:
    # Rimuovere le note della prima diapositiva
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # salvare la presentazione su disco
    presentation.save("RemoveNotesAtSpecificSlide_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Rimuovere le note da tutte le diapositive**
Le note da tutte le diapositive in una presentazione possono essere rimosse come mostrato nell'esempio sottostante:

```py
import aspose.slides as slides

# Istanziare un oggetto Presentation che rappresenta un file di presentazione 
with slides.Presentation("AccessSlides.pptx") as presentation:
    # Rimuovere le note di tutte le diapositive
    for i in range(len(presentation.slides)):
        mgr = presentation.slides[i].notes_slide_manager
        mgr.remove_notes_slide()
    # salvare la presentazione su disco
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Applicare uno stile alle note**
La proprietà [notes_style](https://reference.aspose.com/slides/it/python-net/aspose.slides/masternotesslide/notes_style/) è stata aggiunta alla classe [MasterNotesSlide](https://reference.aspose.com/slides/it/python-net/aspose.slides/masternotesslide/). Questa proprietà specifica lo stile del testo delle note. L'implementazione è mostrata nell'esempio sottostante.

```py
import aspose.slides as slides

# Istanziere la classe Presentation che rappresenta il file di presentazione
with slides.Presentation("AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # Ottieni lo stile del testo della MasterNotesSlide
        notesStyle = notesMaster.notes_style

        #Set simbolo bullet per i paragrafi di primo livello
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # salva il file PPTX su disco
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Quale entità API fornisce l'accesso alle note di una diapositiva specifica?**

Le note sono accessibili tramite il gestore delle note della diapositiva: la diapositiva ha un [NotesSlideManager](https://reference.aspose.com/slides/it/python-net/aspose.slides/notesslidemanager/) e una [property](https://reference.aspose.com/slides/it/python-net/aspose.slides/notesslidemanager/notes_slide/) che restituisce l'oggetto note, o `None` se non ci sono note.

**Ci sono differenze nel supporto delle note tra le versioni di PowerPoint con cui funziona la libreria?**

La libreria supporta un'ampia gamma di formati Microsoft PowerPoint (da 97 in poi) e ODP; le note sono supportate in questi formati senza dipendere da una copia installata di PowerPoint.