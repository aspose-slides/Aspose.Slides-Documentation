---
title: Gestire le note della presentazione in .NET
linktitle: Note della presentazione
type: docs
weight: 110
url: /it/net/presentation-notes/
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
- .NET
- C#
- Aspose.Slides
description: "Personalizza le note della presentazione con Aspose.Slides per .NET. Lavora senza problemi con le note di PowerPoint e OpenDocument per aumentare la tua produttività."
---
## **Panoramica**

Aspose.Slides supporta la rimozione delle diapositive di note da una presentazione. In questo articolo, introdurremo questa funzionalità, includendo come rimuovere le note e come applicare uno stile alle diapositive di note in una presentazione. Aspose.Slides consente di rimuovere le note da qualsiasi diapositiva e di applicare stili alle note esistenti. Gli sviluppatori possono rimuovere le note nei seguenti modi:

- Rimuovere le note da una diapositiva specifica in una presentazione.
- Rimuovere le note da tutte le diapositive in una presentazione.

Per leggere o modificare le dimensioni della pagina delle note, cambiare orientamento e verificare il comportamento di esportazione, vedere [Dimensioni pagina note](/slides/it/net/notes-size/).

## **Rimuovere le note da una diapositiva**
Le note di una diapositiva specifica possono essere rimosse come mostrato nell'esempio seguente:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanzia un oggetto Presentation che rappresenta un file di presentazione
Presentation presentation = new Presentation("AccessSlides.pptx");

// Rimuove le note della prima diapositiva
INotesSlideManager mgr = presentation.Slides[0].NotesSlideManager;
mgr.RemoveNotesSlide();

// Salva la presentazione su disco
presentation.Save("RemoveNotesAtSpecificSlide_out.pptx", SaveFormat.Pptx);
```

## **Rimuovere le note da tutte le diapositive**
Le note di tutte le diapositive di una presentazione possono essere rimosse come mostrato nell'esempio seguente:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanzia un oggetto Presentation che rappresenta un file di presentazione
Presentation presentation = new Presentation("AccessSlides.pptx");

// Rimuove le note di tutte le diapositive
INotesSlideManager mgr = null;
for (int i = 0; i < presentation.Slides.Count; i++)
{
    mgr = presentation.Slides[i].NotesSlideManager;
    mgr.RemoveNotesSlide();
}
// Salva la presentazione su disco
presentation.Save("RemoveNotesFromAllSlides_out.pptx", SaveFormat.Pptx);
```

## **Aggiungere uno stile alle note**
La proprietà NotesStyle è stata aggiunta all'interfaccia [IMasterNotesSlide](https://reference.aspose.com/slides/it/net/aspose.slides/imasternotesslide) e alla classe [MasterNotesSlide](https://reference.aspose.com/slides/it/net/aspose.slides/masternotesslide) rispettivamente. Questa proprietà specifica lo stile del testo delle note. L'implementazione è mostrata nell'esempio seguente.

```c#
using Aspose.Slides;

// Instanzia la classe Presentation che rappresenta il file di presentazione
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;

    if (notesMaster != null)
    {
        // Ottieni lo stile del testo di MasterNotesSlide
        ITextStyle notesStyle = notesMaster.NotesStyle;

        //Imposta il bullet simbolo per i paragrafi di primo livello
        IParagraphFormat paragraphFormat = notesStyle.GetLevel(0);
        paragraphFormat.Bullet.Type = BulletType.Symbol;
    }

    // Salva il file PPTX su disco
    presentation.Save("AddNotesSlideWithNotesStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

}
```

## **FAQ**

### Quale entità API fornisce l'accesso alle note di una diapositiva specifica?

Le note sono accessibili tramite il gestore delle note della diapositiva: la diapositiva possiede un [NotesSlideManager](https://reference.aspose.com/slides/it/net/aspose.slides/notesslidemanager/) e una [proprietà](https://reference.aspose.com/slides/it/net/aspose.slides/notesslidemanager/notesslide/) che restituisce l'oggetto delle note, o `null` se non ci sono note.

### Ci sono differenze nel supporto delle note tra le versioni di PowerPoint con cui funziona la libreria?

La libreria supporta un'ampia gamma di formati Microsoft PowerPoint (97–versioni più recenti) e ODP; le note sono supportate in questi formati senza dipendere da una copia installata di PowerPoint.