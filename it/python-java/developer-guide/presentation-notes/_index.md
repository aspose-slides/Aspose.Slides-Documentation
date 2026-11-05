---
title: Gestire le note della presentazione in Python tramite Java
linktitle: Note della presentazione
type: docs
weight: 110
url: /it/python-java/presentation-notes/
keywords:
- note
- diapositiva note
- aggiungere note
- rimuovere note
- stile note
- note master
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Personalizza le note della presentazione con Aspose.Slides per Python tramite Java. Lavora senza problemi con le note di PowerPoint e OpenDocument per aumentare la tua produttività."
---
## **Panoramica**

Aspose.Slides supporta la rimozione delle diapositive delle note da una presentazione. Questo argomento presenta questa funzionalità, inclusa come rimuovere le note e come applicare uno stile alle diapositive delle note in una presentazione. Aspose.Slides consente di rimuovere le note da qualsiasi diapositiva e di applicare lo stile alle note esistenti. Gli sviluppatori possono rimuovere le note nei seguenti modi:

- Rimuovere le note da una diapositiva specifica in una presentazione.
- Rimuovere le note da tutte le diapositive in una presentazione.

Per leggere o modificare le dimensioni della pagina delle note, cambiare l'orientamento e verificare il comportamento di esportazione, vedere [Dimensioni pagina note](/slides/it/python-java/notes-size/).

## **Rimuovere le note da una diapositiva**

Le note da una diapositiva specifica possono essere rimosse come mostrato nell'esempio seguente:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instanzia un oggetto Presentation che rappresenta un file di presentazione.
presentation = Presentation("presWithNotes.pptx")
try:
    # Rimuovi le note dalla prima diapositiva.
    notes_manager = presentation.getSlides().get_Item(0).getNotesSlideManager()
    notes_manager.removeNotesSlide()

    # Salva la presentazione su disco.
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Rimuovere le note da una presentazione**

Le note da tutte le diapositive in una presentazione possono essere rimosse come mostrato nell'esempio seguente:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instanzia un oggetto Presentation che rappresenta un file di presentazione.
presentation = Presentation("presWithNotes.pptx")
try:
    # Rimuovi le note da tutte le diapositive.
    for i in range(presentation.getSlides().size()):
        notes_manager = presentation.getSlides().get_Item(i).getNotesSlideManager()
        notes_manager.removeNotesSlide()

    # Salva la presentazione su disco.
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Aggiungere uno stile alle note**

Il metodo [getNotesStyle](https://reference.aspose.com/slides/it/python-java/aspose.slides/masternotesslide/#getNotesStyle) della classe [MasterNotesSlide](https://reference.aspose.com/slides/it/python-java/aspose.slides/masternotesslide/) fornisce l'accesso allo stile del testo delle note. L'implementazione è mostrata nell'esempio seguente.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Presentation, SaveFormat

# Instanzia un oggetto Presentation che rappresenta un file di presentazione.
presentation = Presentation("demo.pptx")
try:
    notes_master = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if notes_master is not None:
        # Ottieni lo stile del testo della diapositiva master delle note.
        notes_style = notes_master.getNotesStyle()

        # Imposta i punti elenco a simbolo per i paragrafi di primo livello.
        paragraph_format = notes_style.getLevel(0)
        paragraph_format.getBullet().setType(BulletType.Symbol)

    presentation.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Quale entità API fornisce l'accesso alle note di una diapositiva specifica?**

Le note sono accessibili tramite il gestore delle note della diapositiva: la diapositiva dispone di un [NotesSlideManager](https://reference.aspose.com/slides/it/python-java/aspose.slides/notesslidemanager/) e di un metodo [getNotesSlide](https://reference.aspose.com/slides/it/python-java/aspose.slides/notesslidemanager/#getNotesSlide) che restituisce l'oggetto delle note, oppure `None` se non vi sono note.

**Ci sono differenze nel supporto delle note tra le versioni di PowerPoint con cui la libreria funziona?**

La libreria supporta un'ampia gamma di formati Microsoft PowerPoint (97 e versioni successive) e ODP; le note sono supportate all'interno di questi formati senza dipendere da una copia installata di PowerPoint.