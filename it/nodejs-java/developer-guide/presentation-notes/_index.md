---
title: Gestisci le note della presentazione in JavaScript
linktitle: Note della presentazione
type: docs
weight: 110
url: /it/nodejs-java/presentation-notes/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Personalizza le note della presentazione in JavaScript con Aspose.Slides per Node.js. Lavora senza problemi con le note di PowerPoint e OpenDocument per aumentare la tua produttività."
---
## **Panoramica**

Aspose.Slides supporta la rimozione delle diapositive delle note da una presentazione. In questo argomento presenteremo questa funzionalità, includendo come rimuovere le note e come applicare uno stile alle diapositive delle note in una presentazione. Aspose.Slides consente di rimuovere le note da qualsiasi diapositiva e anche di applicare uno stile alle note esistenti. Gli sviluppatori possono rimuovere le note nei seguenti modi:

- Rimuovere le note da una diapositiva specifica in una presentazione.
- Rimuovere le note da tutte le diapositive in una presentazione.

Per leggere o modificare le dimensioni della pagina delle note, cambiare orientamento e verificare il comportamento di esportazione, vedere [Notes Page Size](/slides/it/nodejs-java/notes-size/).

## **Rimuovi note da una diapositiva**
Le note da una diapositiva specifica possono essere rimosse come mostrato nell'esempio seguente:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Istanziare un oggetto Presentation che rappresenta un file di presentazione
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // Rimozione delle note della prima diapositiva
    var mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();
    // Salvataggio della presentazione su disco
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Rimuovi note da una presentazione**
Le note da tutte le diapositive in una presentazione possono essere rimosse come mostrato nell'esempio seguente:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Istanziare un oggetto Presentation che rappresenta un file di presentazione
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // Rimozione delle note di tutte le diapositive
    var mgr = null;
    for (var i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    // Salvataggio della presentazione su disco
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Aggiungi NotesStyle**
Il metodo [getNotesStyle](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/MasterNotesSlide#getNotesStyle--) è stato aggiunto alla classe [MasterNotesSlide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/MasterNotesSlide) e alla classe [MasterNotesSlide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/MasterNotesSlide) rispettivamente. Questa proprietà specifica lo stile del testo delle note. L'implementazione è dimostrata nell'esempio seguente.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Istanziare un oggetto Presentation che rappresenta un file di presentazione
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    var notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        // Ottenere lo stile del testo di MasterNotesSlide
        var notesStyle = notesMaster.getNotesStyle();
        // Impostare il simbolo di bullet per i paragrafi di primo livello
        var paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
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

Le note sono accessibili tramite il gestore delle note della diapositiva: la diapositiva possiede un [NotesSlideManager](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/notesslidemanager/) e un [method](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/notesslidemanager/getnotesslide/) che restituisce l'oggetto note, o `null` se non ci sono note.

**Esistono differenze nel supporto delle note tra le versioni di PowerPoint con cui funziona la libreria?**

La libreria supporta un'ampia gamma di formati Microsoft PowerPoint (97‑newer) e ODP; le note sono supportate in questi formati senza dipendere da una copia installata di PowerPoint.