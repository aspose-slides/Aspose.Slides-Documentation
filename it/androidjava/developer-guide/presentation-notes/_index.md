---
title: Gestire le note della presentazione su Android
linktitle: Note della presentazione
type: docs
weight: 110
url: /it/androidjava/presentation-notes/
keywords:
- note
- diapositiva delle note
- aggiungere note
- rimuovere note
- stile delle note
- note master
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Personalizza le note della presentazione con Aspose.Slides per Android via Java. Lavora senza sforzo con le note di PowerPowerPoint e OpenDocument per aumentare la tua produttività."
---
## **Panoramica**

Aspose.Slides supporta la rimozione delle diapositive delle note da una presentazione. In questo argomento introdurremo questa funzionalità, includendo come rimuovere le note e come applicare uno stile alle diapositive delle note in una presentazione. Aspose.Slides consente di rimuovere le note da qualsiasi diapositiva e anche di applicare uno stile alle note esistenti. Gli sviluppatori possono rimuovere le note nei seguenti modi:

- Rimuovere le note da una diapositiva specifica in una presentazione.
- Rimuovere le note da tutte le diapositive in una presentazione.

## **Rimuovere le note da una diapositiva**
Le note di una diapositiva specifica possono essere rimosse come mostrato nell'esempio seguente:

```java
// Istanziare un oggetto Presentation che rappresenta un file di presentazione
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Rimuovere le note della prima diapositiva
    INotesSlideManager mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();

    // Salvare la presentazione su disco
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Rimuovere le note da una presentazione**
Le note di tutte le diapositive di una presentazione possono essere rimosse come mostrato nell'esempio seguente:

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
    
    // Salvare la presentazione su disco
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Aggiungere uno stile alle note**
Il metodo [getNotesStyle](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) è stato aggiunto all'interfaccia [IMasterNotesSlide](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IMasterNotesSlide) e alla classe [MasterNotesSlide](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/MasterNotesSlide) rispettivamente. Questa proprietà specifica lo stile del testo delle note. L'implementazione è dimostrata nell'esempio seguente.

```java
// Istanziare un oggetto Presentation che rappresenta un file di presentazione
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // Ottenere lo stile del testo di MasterNotesSlide
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        // Impostare un bullet symbol per i paragrafi di primo livello
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

Le note sono accessibili tramite il gestore delle note della diapositiva: la diapositiva dispone di un [NotesSlideManager](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/notesslidemanager/) e di un [method](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/notesslidemanager/#getNotesSlide--) che restituisce l'oggetto note, o `null` se non ci sono note.

**Ci sono differenze nel supporto delle note tra le versioni di PowerPoint con cui la libreria funziona?**

La libreria supporta un'ampia gamma di formati Microsoft PowerPoint (97 e versioni successive) e ODP; le note sono supportate in questi formati senza dipendere da una copia installata di PowerPoint.