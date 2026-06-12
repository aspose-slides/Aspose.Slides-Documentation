---
title: Gestisci le note della presentazione in .NET
linktitle: Note della presentazione
type: docs
weight: 110
url: /it/net/presentation-notes/
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
- .NET
- C#
- Aspose.Slides
description: "Personalizza le note della presentazione con Aspose.Slides per .NET. Lavora senza interruzioni con le note di PowerPoint e OpenDocument per aumentare la tua produttività."
---
## **Panoramica**

Aspose.Slides supporta la rimozione delle diapositive delle note da una presentazione. In questo argomento, introdurremo questa funzionalità, inclusa la rimozione delle note e l'applicazione di uno stile alle diapositive delle note in una presentazione. Aspose.Slides consente di rimuovere le note da qualsiasi diapositiva e anche di applicare uno stile alle note esistenti. Gli sviluppatori possono rimuovere le note nei seguenti modi:

- Rimuovere le note da una diapositiva specifica in una presentazione.
- Rimuovere le note da tutte le diapositive in una presentazione.

## **Rimuovere le note da una diapositiva**
Le note di una diapositiva specifica possono essere rimosse come mostrato nell'esempio seguente:

```c#
// Istanziare un oggetto Presentation che rappresenta un file di presentazione 
Presentation presentation = new Presentation(dataDir + "AccessSlides.pptx");

// Rimuovere le note della prima diapositiva
INotesSlideManager mgr = presentation.Slides[0].NotesSlideManager;
mgr.RemoveNotesSlide();

// Salvare la presentazione su disco
presentation.Save(dataDir + "RemoveNotesAtSpecificSlide_out.pptx", SaveFormat.Pptx);
```

## **Rimuovere le note da tutte le diapositive**
Le note di tutte le diapositive di una presentazione possono essere rimosse come mostrato nell'esempio seguente:

```c#
// Istanziare un oggetto Presentation che rappresenta un file di presentazione 
Presentation presentation = new Presentation("AccessSlides.pptx");

// Rimuovere le note di tutte le diapositive
INotesSlideManager mgr = null;
for (int i = 0; i < presentation.Slides.Count; i++)
{
    mgr = presentation.Slides[i].NotesSlideManager;
    mgr.RemoveNotesSlide();
}
// Salvare la presentazione su disco
presentation.Save("RemoveNotesFromAllSlides_out.pptx", SaveFormat.Pptx);
```

## **Aggiungere uno stile alle note**
La proprietà NotesStyle è stata aggiunta all'interfaccia [IMasterNotesSlide](https://reference.aspose.com/slides/it/net/aspose.slides/imasternotesslide) e alla classe [MasterNotesSlide](https://reference.aspose.com/slides/it/net/aspose.slides/masternotesslide) rispettivamente. Questa proprietà specifica lo stile del testo delle note. L'implementazione è mostrata nell'esempio seguente.

```c#
// Istanziare la classe Presentation che rappresenta il file di presentazione
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;

    if (notesMaster != null)
    {
        // Ottieni lo stile del testo di MasterNotesSlide
        ITextStyle notesStyle = notesMaster.NotesStyle;

        //Imposta il simbolo puntatore per i paragrafi di primo livello
        IParagraphFormat paragraphFormat = notesStyle.GetLevel(0);
        paragraphFormat.Bullet.Type = BulletType.Symbol;
    }

    // Salva il file PPTX su disco
    presentation.Save("AddNotesSlideWithNotesStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

}
```

## **FAQ**

**Quale entità API fornisce accesso alle note di una diapositiva specifica?**

Le note sono accessibili tramite il gestore delle note della diapositiva: la diapositiva dispone di un [NotesSlideManager](https://reference.aspose.com/slides/it/net/aspose.slides/notesslidemanager/) e di una [property](https://reference.aspose.com/slides/it/net/aspose.slides/notesslidemanager/notesslide/) che restituisce l'oggetto delle note, o `null` se non ci sono note.

**Ci sono differenze nel supporto delle note tra le versioni di PowerPoint con cui la libreria funziona?**

La libreria supporta un'ampia gamma di formati Microsoft PowerPoint (da 97 in poi) e ODP; le note sono supportate in questi formati senza dipendere da una copia installata di PowerPoint.