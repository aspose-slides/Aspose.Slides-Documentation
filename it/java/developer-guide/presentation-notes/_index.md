---
title: Gestisci le Note della Presentazione in Java
linktitle: Note della Presentazione
type: docs
weight: 110
url: /it/java/presentation-notes/
keywords:
- note
- diapositiva note
- aggiungi note
- rimuovi note
- stile note
- note master
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Personalizza le note della presentazione con Aspose.Slides per Java. Lavora senza problemi con le note di PowerPoint e OpenDocument per aumentare la tua produttività."
---
## **Panoramica**

Aspose.Slides supporta la rimozione delle diapositive note da una presentazione. In questo articolo presenteremo questa funzionalità, includendo come rimuovere le note e come applicare uno stile alle diapositive note in una presentazione. Aspose.Slides consente di rimuovere le note da qualsiasi diapositiva e anche di applicare uno stile alle note esistenti. Gli sviluppatori possono rimuovere le note nei seguenti modi:

- Rimuovere le note da una diapositiva specifica in una presentazione.
- Rimuovere le note da tutte le diapositive in una presentazione.

Per leggere o modificare le dimensioni della pagina delle note, cambiare orientamento e verificare il comportamento di esportazione, vedere [Dimensioni pagina note](/slides/it/java/notes-size/).

## **Rimuovere le note da una diapositiva**
Le note di una diapositiva specifica possono essere rimosse come mostrato nell'esempio seguente:

```java
import com.aspose.slides.*;

// Instanzia un oggetto Presentation che rappresenta un file di presentazione
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Rimuove le note della prima diapositiva
    INotesSlideManager mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();

    // Salva la presentazione su disco
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Rimuovere le note da una presentazione**
Le note di tutte le diapositive in una presentazione possono essere rimosse come mostrato nell'esempio seguente:

```java
import com.aspose.slides.*;

// Instanzia un oggetto Presentation che rappresenta un file di presentazione
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Rimuove le note di tutte le diapositive
    INotesSlideManager mgr = null;
    for (int i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    
    // Salva la presentazione su disco
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Aggiungere uno stile alle note**
Il metodo [getNotesStyle](https://reference.aspose.com/slides/it/java/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) è stato aggiunto all'interfaccia [IMasterNotesSlide](https://reference.aspose.com/slides/it/java/com.aspose.slides/IMasterNotesSlide) e alla classe [MasterNotesSlide](https://reference.aspose.com/slides/it/java/com.aspose.slides/MasterNotesSlide) rispettivamente. Questa proprietà specifica lo stile del testo delle note. L'implementazione è mostrata nell'esempio seguente.

```java
import com.aspose.slides.*;

// Instanzia un oggetto Presentation che rappresenta un file di presentazione
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // Ottieni lo stile del testo di MasterNotesSlide
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        // Imposta un simbolo di elenco puntato per i paragrafi di primo livello
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Quale entità API fornisce l'accesso alle note di una diapositiva specifica?**

Le note sono accessibili tramite il gestore delle note della diapositiva: la diapositiva dispone di un [NotesSlideManager](https://reference.aspose.com/slides/it/java/com.aspose.slides/notesslidemanager/) e di un [metodo](https://reference.aspose.com/slides/it/java/com.aspose.slides/notesslidemanager/#getNotesSlide--) che restituisce l'oggetto note, oppure `null` se non ci sono note.

**Esistono differenze nel supporto delle note tra le versioni di PowerPoint con cui la libreria è compatibile?**

La libreria supporta un'ampia gamma di formati Microsoft PowerPoint (97‑versione più recente) e ODP; le note sono supportate in questi formati senza dipendere da una copia installata di PowerPoint.