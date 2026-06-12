---
title: Gestire le note della presentazione in JavaScript
linktitle: Note della presentazione
type: docs
weight: 110
url: /it/nodejs-java/presentation-notes/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Personalizza le note della presentazione in JavaScript con Aspose.Slides per Node.js. Lavora senza soluzione di continuità con le note di PowerPoint e OpenDocument per aumentare la tua produttività."
---
## **Panoramica**

Aspose.Slides supporta la rimozione delle diapositive delle note da una presentazione. In questo argomento introdurremo questa funzionalità, incluso come rimuovere le note e come applicare uno stile alle diapositive delle note in una presentazione. Aspose.Slides consente di rimuovere le note da qualsiasi diapositiva e anche di applicare uno stile alle note esistenti. Gli sviluppatori possono rimuovere le note nei seguenti modi:

- Rimuovere le note da una diapositiva specifica in una presentazione.
- Rimuovere le note da tutte le diapositive in una presentazione.

## **Rimuovere le note dalla diapositiva**
Le note di una diapositiva specifica possono essere rimosse come mostrato nell'esempio seguente:

```javascript
// Istanziare un oggetto Presentation che rappresenta un file di presentazione
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // Rimuovere le note della prima diapositiva
    var mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();
    // Salvare la presentazione su disco
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Rimuovere le note dalla presentazione**
Le note di tutte le diapositive di una presentazione possono essere rimosse come mostrato nell'esempio seguente:

```javascript
// Istanziare un oggetto Presentation che rappresenta un file di presentazione
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // Rimuovere le note di tutte le diapositive
    var mgr = null;
    for (var i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    // Salvare la presentazione su disco
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Aggiungere NotesStyle**
[getNotesStyle](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/MasterNotesSlide#getNotesStyle--) method è stato aggiunto alla classe [MasterNotesSlide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/MasterNotesSlide) e alla classe [MasterNotesSlide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/MasterNotesSlide) rispettivamente. Questa proprietà specifica lo stile di un testo delle note. L'implementazione è mostrata nell'esempio seguente.

```javascript
// Istanziare un oggetto Presentation che rappresenta un file di presentazione
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    var notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        // Ottenere lo stile del testo di MasterNotesSlide
        var notesStyle = notesMaster.getNotesStyle();
        // Impostare il punto elenco simbolo per i paragrafi di primo livello
        var paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(aspose.slides.BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Quale entità API fornisce l'accesso alle note di una diapositiva specifica?**

Le note sono accessibili tramite il gestore delle note della diapositiva: la diapositiva dispone di un [NotesSlideManager](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/notesslidemanager/) e di un [method](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/notesslidemanager/getnotesslide/) che restituisce l'oggetto delle note, oppure `null` se non ci sono note.

**Ci sono differenze nel supporto delle note tra le versioni di PowerPoint con cui la libreria funziona?**

La libreria supporta un'ampia gamma di formati Microsoft PowerPoint (97‑e versioni successive) e ODP; le note sono supportate in questi formati senza dipendere da una copia installata di PowerPoint.