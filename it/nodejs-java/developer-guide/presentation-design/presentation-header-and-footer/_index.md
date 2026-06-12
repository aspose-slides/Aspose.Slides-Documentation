---
title: Gestisci intestazioni e piè di pagina della presentazione in JavaScript
linktitle: Intestazione & Piè di pagina
type: docs
weight: 140
url: /it/nodejs-java/presentation-header-and-footer/
keywords:
- intestazione
- testo intestazione
- piè di pagina
- testo piè di pagina
- imposta intestazione
- imposta piè di pagina
- dispensa
- note
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Usa JavaScript e Aspose.Slides per Node.js per aggiungere e personalizzare intestazioni e piè di pagina in presentazioni PowerPoint e OpenDocument per un aspetto professionale."
---
## **Panoramica**

Aspose.Slides consente di gestire le impostazioni di intestazione e piè di pagina nelle presentazioni PowerPoint. Le intestazioni e i piè di pagina sono gestiti a livello del master della presentazione e l'API fornisce metodi per impostare il testo del piè di pagina, modificare la visibilità del piè di pagina e aggiornare il testo dell'intestazione nelle diapositive master delle note.

È inoltre possibile gestire intestazioni e piè di pagina per le diapositive di dispensa e di note. Questo include la modifica della visibilità e del testo dei segnaposto di intestazione, piè di pagina, numero diapositiva e data/ora per il master delle note, tutte le diapositive figlio delle note o una singola diapositiva delle note.

## **Gestisci Intestazione e Piè di pagina nella Presentazione**
Le note di alcune diapositive specifiche possono essere rimosse come mostrato nell'esempio seguente:

```javascript
// Carica presentazione
var pres = new aspose.slides.Presentation("headerTest.pptx");
try {
    // Impostazione del piè di pagina
    pres.getHeaderFooterManager().setAllFootersText("My Footer text");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);
    // Accesso e aggiornamento intestazione
    var masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (null != masterNotesSlide) {
        updateHeaderFooterText(masterNotesSlide);
    }
    // Salva presentazione
    pres.save("HeaderFooterJava.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
```javascript
function updateHeaderFooterText(master) {
    let shapes = master.getShapes();
    for (let i = 0; i < shapes.size(); i++) {
        let shape = shapes.get_Item(i); 
        if (shape.getPlaceholder() !== null) {
            if (shape.getPlaceholder().getType() === aspose.PlaceholderType.Header) {
                shape.getTextFrame().setText("HI there new header");
            }
        }
    }
}
```

## **Gestisci Intestazione e Piè di pagina nelle diapositive di dispensa e note**
Aspose.Slides for Node.js via Java supporta Intestazione e Piè di pagina nelle diapositive di dispensa e note. Segui i passaggi seguenti:

- Carica una [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation) contenente un video.
- Modifica le impostazioni di Intestazione e Piè di pagina per il master delle note e per tutte le diapositive delle note.
- Imposta i segnaposti Footer della diapositiva master delle note e di tutti i figli come visibili.
- Imposta i segnaposti Date e Time della diapositiva master delle note e di tutti i figli come visibili.
- Modifica le impostazioni di Intestazione e Piè di pagina solo per la prima diapositiva delle note.
- Imposta il segnaposto Header della diapositiva delle note come visibile.
- Imposta il testo del segnaposto Header della diapositiva delle note.
- Imposta il testo del segnaposto Date-time della diapositiva delle note.
- Scrivi il file di presentazione modificato.

Snippet di codice fornito nell'esempio sottostante.

```javascript
var pres = new aspose.slides.Presentation("presentation.pptx");
try {
    // Modifica le impostazioni di intestazione e piè di pagina per il master delle note e tutte le diapositive delle note
    var masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null) {
        var headerFooterManager = masterNotesSlide.getHeaderFooterManager();
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);// rendi visibili il master delle note e tutti i segnaposti Footer dei figli
        headerFooterManager.setFooterAndChildFootersVisibility(true);// rendi visibili il master delle note e tutti i segnaposti Header dei figli
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);// rendi visibili il master delle note e tutti i segnaposti SlideNumber dei figli
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);// rendi visibili il master delle note e tutti i segnaposti Data e ora dei figli
        headerFooterManager.setHeaderAndChildHeadersText("Header text");// imposta il testo sul master delle note e su tutti i segnaposti Header dei figli
        headerFooterManager.setFooterAndChildFootersText("Footer text");// imposta il testo sul master delle note e su tutti i segnaposti Footer dei figli
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");// imposta il testo sul master delle note e su tutti i segnaposti Data e ora dei figli
    }
    // Modifica le impostazioni di intestazione e piè di pagina per la prima diapositiva delle note soltanto
    var notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null) {
        var headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible()) {
            headerFooterManager.setHeaderVisibility(true);
        }// rendi visibile il segnaposto Header di questa diapositiva delle note
        if (!headerFooterManager.isFooterVisible()) {
            headerFooterManager.setFooterVisibility(true);
        }// rendi visibile il segnaposto Footer di questa diapositiva delle note
        if (!headerFooterManager.isSlideNumberVisible()) {
            headerFooterManager.setSlideNumberVisibility(true);
        }// rendi visibile il segnaposto SlideNumber di questa diapositiva delle note
        if (!headerFooterManager.isDateTimeVisible()) {
            headerFooterManager.setDateTimeVisibility(true);
        }// rendi visibile il segnaposto Date-time di questa diapositiva delle note
        headerFooterManager.setHeaderText("New header text");// imposta il testo sul segnaposto Header della diapositiva delle note
        headerFooterManager.setFooterText("New footer text");// imposta il testo sul segnaposto Footer della diapositiva delle note
        headerFooterManager.setDateTimeText("New date and time text");// imposta il testo sul segnaposto Date-time della diapositiva delle note
    }
    pres.save("testresult.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Posso aggiungere un "header" alle diapositive regolari?**

In PowerPoint, "Header" esiste solo per le note e le dispense; nelle diapositive regolari, gli elementi supportati sono il piè di pagina, data/ora e numero diapositiva. In Aspose.Slides ciò corrisponde alle stesse limitazioni: intestazione solo per Note/Dispensa, e nelle diapositive—Footer/DateTime/SlideNumber.

**E se il layout non contiene un'area piè di pagina—posso "attivarne" la visibilità?**

Sì. Controlla la visibilità tramite il gestore di intestazione/piè di pagina e abilitala se necessario. Questi indicatori e metodi API sono progettati per i casi in cui il segnaposto è mancante o nascosto.

**Come faccio a far iniziare la numerazione delle diapositive da un valore diverso da 1?**

Imposta il [first slide number](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/setfirstslidenumber/) della presentazione; dopo di ciò, tutta la numerazione viene ricalcolata. Per esempio, puoi iniziare da 0 o 10 e nascondere il numero nella diapositiva del titolo.

** Cosa succede a intestazioni/ piè di pagina quando si esporta in PDF/immagini/HTML?**

Vengono renderizzati come normali elementi di testo della presentazione. Cioè, se gli elementi sono visibili su diapositive/pagine delle note, appariranno anche nel formato di output insieme al resto del contenuto.