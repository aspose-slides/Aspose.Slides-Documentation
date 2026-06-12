---
title: Gestire le note della presentazione in Java
linktitle: Note della presentazione
type: docs
weight: 110
url: /it/java/presentation-notes/
keywords:
- note
- diapositiva note
- aggiungere note
- rimuovere note
- stile note
- master notes
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Personalizza le note della presentazione con Aspose.Slides per Java. Lavora in modo fluido con le note di PowerPoint e OpenDocument per aumentare la tua produttività."
---
## **Panoramica**

Aspose.Slides supporta la rimozione delle diapositive note da una presentazione. In questo argomento introdurremo questa funzionalità, inclusi i modi per rimuovere le note e per applicare uno stile alle diapositive note in una presentazione. Aspose.Slides consente di rimuovere le note da qualsiasi diapositiva e di applicare uno stile alle note esistenti. Gli sviluppatori possono rimuovere le note nei seguenti modi:

- Rimuovere le note da una diapositiva specifica in una presentazione.
- Rimuovere le note da tutte le diapositive in una presentazione.

## **Rimuovi le note da una diapositiva**
Le note di una diapositiva specifica possono essere rimosse come mostrato nell'esempio sottostante:

```java
// Istanziare un oggetto Presentation che rappresenta un file di presentazione
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Rimuovere le note della prima diapositiva
    INotesSlideManager mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();

    // Salvataggio della presentazione su disco
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Rimuovi le note da una presentazione**
Le note di tutte le diapositive di una presentazione possono essere rimosse come mostrato nell'esempio sottostante:

```java
// Istanziare un oggetto Presentation che rappresenta un file di presentazione
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Rimuovere le note di tutte le diapositive
    INotesSlideManager mgr = null;
    for (int i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    
    // Salvataggio della presentazione su disco
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Aggiungi uno stile alle note**
Il metodo [getNotesStyle](https://reference.aspose.com/slides/it/java/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) è stato aggiunto all'interfaccia [IMasterNotesSlide](https://reference.aspose.com/slides/it/java/com.aspose.slides/IMasterNotesSlide) e alla classe [MasterNotesSlide](https://reference.aspose.com/slides/it/java/com.aspose.slides/MasterNotesSlide) rispettivamente. Questa proprietà specifica lo stile del testo delle note. L'implementazione è mostrata nell'esempio sottostante.

```java
// Istanziare un oggetto Presentation che rappresenta un file di presentazione
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // Ottenere lo stile del testo di MasterNotesSlide
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        // Impostare il bullet simbolo per i paragrafi di primo livello
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

Le note sono accessibili tramite il gestore delle note della diapositiva: la diapositiva possiede un [NotesSlideManager](https://reference.aspose.com/slides/it/java/com.aspose.slides/notesslidemanager/) e un [method](https://reference.aspose.com/slides/it/java/com.aspose.slides/notesslidemanager/#getNotesSlide--) che restituisce l'oggetto note, o `null` se non ci sono note.

**Ci sono differenze nel supporto delle note tra le versioni di PowerPoint con cui la libreria funziona?**

La libreria supporta un'ampia gamma di formati Microsoft PowerPoint (97-e successivi) e ODP; le note sono supportate in questi formati senza dipendere da una copia installata di PowerPoint.