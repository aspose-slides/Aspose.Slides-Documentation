---
title: Gestire le note della presentazione in C++
linktitle: Note della presentazione
type: docs
weight: 110
url: /it/cpp/presentation-notes/
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
- C++
- Aspose.Slides
description: "Personalizza le note della presentazione con Aspose.Slides per C++. Lavora senza interruzioni con le note di PowerPoint e OpenDocument per aumentare la tua produttività."
---
## **Panoramica**

Aspose.Slides supporta la rimozione delle diapositive delle note da una presentazione. In questo argomento, introdurremo questa funzionalità, includendo come rimuovere le note e come applicare uno stile alle diapositive delle note in una presentazione. Aspose.Slides consente di rimuovere le note da qualsiasi diapositiva e anche di applicare uno stile alle note esistenti. Gli sviluppatori possono rimuovere le note nei seguenti modi:

- Rimuovere le note da una diapositiva specifica in una presentazione.
- Rimuovere le note da tutte le diapositive in una presentazione.

Per leggere o modificare le dimensioni della pagina delle note, cambiare orientamento e verificare il comportamento di esportazione, vedere [Notes Page Size](/slides/it/cpp/notes-size/).

## **Rimuovere le Note da una Diapositiva Specifica**
Le note da una diapositiva specifica possono essere rimosse come mostrato nell'esempio seguente:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesAtSpecificSlide-RemoveNotesAtSpecificSlide.cpp" >}}
## **Rimuovere le Note da Tutte le Diapositive**
Le note da tutte le diapositive in una presentazione possono essere rimosse come mostrato nell'esempio seguente:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesFromAllSlides-RemoveNotesFromAllSlides.cpp" >}}
## **Aggiungere uno Stile alle Note**
La proprietà NotesStyle è stata aggiunta all'interfaccia IMasterNotesSlide e alla classe MasterNotesSlide. Questa proprietà specifica lo stile del testo delle note. L'implementazione è dimostrata nell'esempio seguente.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNotesSlideWithNotesStyle-AddNotesSlideWithNotesStyle.cpp" >}}

## **FAQ**

### Quale entità API fornisce l'accesso alle note di una diapositiva specifica?
Le note sono accessibili tramite il gestore delle note della diapositiva: la diapositiva ha un [NotesSlideManager](https://reference.aspose.com/slides/it/cpp/aspose.slides/notesslidemanager/) e un [metodo](https://reference.aspose.com/slides/it/cpp/aspose.slides/notesslidemanager/get_notesslide/) che restituisce l'oggetto note, o `null` se non ci sono note.

### Ci sono differenze nel supporto delle note tra le versioni di PowerPoint con cui la libreria funziona?
La libreria supporta un'ampia gamma di formati Microsoft PowerPoint (da 97 in poi) e ODP; le note sono supportate in questi formati senza dipendere da una copia installata di PowerPoint.