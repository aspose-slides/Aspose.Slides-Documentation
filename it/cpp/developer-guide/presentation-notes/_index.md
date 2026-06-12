---
title: Gestisci le note della presentazione in C++
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
description: "Personalizza le note della presentazione con Aspose.Slides per C++. Lavora senza problemi con le note PowerPoint e OpenDocument per aumentare la tua produttività."
---
## **Panoramica**

Aspose.Slides supporta la rimozione delle diapositive delle note da una presentazione. In questo argomento introdurremo questa funzionalità, inclusi come rimuovere le note e come applicare uno stile alle diapositive delle note in una presentazione. Aspose.Slides consente di rimuovere le note da qualsiasi diapositiva e di applicare anche formattazioni alle note esistenti. Gli sviluppatori possono rimuovere le note nei seguenti modi:

- Rimuovere le note da una diapositiva specifica in una presentazione.
- Rimuovere le note da tutte le diapositive in una presentazione.

## **Rimuovi le note da una diapositiva specifica**
Le note di una diapositiva specifica possono essere rimosse come mostrato nell'esempio seguente:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesAtSpecificSlide-RemoveNotesAtSpecificSlide.cpp" >}}
## **Rimuovi le note da tutte le diapositive**
Le note di tutte le diapositive di una presentazione possono essere rimosse come mostrato nell'esempio seguente:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesFromAllSlides-RemoveNotesFromAllSlides.cpp" >}}
## **Aggiungi uno stile alle note**
La proprietà NotesStyle è stata aggiunta all'interfaccia IMasterNotesSlide e alla classe MasterNotesSlide rispettivamente. Questa proprietà specifica lo stile del testo delle note. L'implementazione è dimostrata nell'esempio seguente.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNotesSlideWithNotesStyle-AddNotesSlideWithNotesStyle.cpp" >}}

## **FAQ**

**Quale entità API fornisce l'accesso alle note di una diapositiva specifica?**

Le note sono accessibili tramite il gestore delle note della diapositiva: la diapositiva dispone di un [NotesSlideManager](https://reference.aspose.com/slides/it/cpp/aspose.slides/notesslidemanager/) e di un [metodo](https://reference.aspose.com/slides/it/cpp/aspose.slides/notesslidemanager/get_notesslide/) che restituisce l'oggetto delle note, oppure `null` se non ci sono note.

**Ci sono differenze nel supporto delle note tra le versioni di PowerPoint con cui la libreria funziona?**

La libreria supporta un'ampia gamma di formati Microsoft PowerPoint (97 e successivi) e ODP; le note sono supportate all'interno di questi formati senza dipendere da una copia installata di PowerPoint.