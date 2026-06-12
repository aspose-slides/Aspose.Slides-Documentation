---
title: Accesso alle diapositive della presentazione in JavaScript
linktitle: Accesso diapositiva
type: docs
weight: 20
url: /it/nodejs-java/access-slide-in-presentation/
keywords:
- accedere alla diapositiva
- indice della diapositiva
- ID diapositiva
- posizione della diapositiva
- modifica posizione
- proprietà della diapositiva
- numero della diapositiva
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Scopri come accedere e gestire le diapositive in presentazioni PowerPoint e OpenDocument con Aspose.Slides per Node.js. Aumenta la produttività con esempi di codice."
---
## **Panoramica**

Questo articolo spiega come accedere e gestire le diapositive in una presentazione utilizzando Aspose.Slides. Mostra come recuperare le diapositive mediante il loro indice basato su zero dalla collezione di diapositive e come accedere a una diapositiva tramite il suo ID univoco utilizzando il metodo `getSlideById`.

Imparerai anche come modificare la posizione di una diapositiva utilizzando il metodo `setSlideNumber` e come definire il numero di diapositiva iniziale per una presentazione con il metodo `setFirstSlideNumber`. Gli esempi mostrano come caricare una presentazione, ottenere riferimenti alle diapositive, aggiornare l'ordine o la numerazione delle diapositive e salvare la presentazione modificata.

## **Accedi alla diapositiva per indice**

Tutte le diapositive in una presentazione sono ordinate numericamente in base alla posizione della diapositiva a partire da 0. La prima diapositiva è accessibile tramite l'indice 0; la seconda diapositiva è accessibile tramite l'indice 1; ecc.

La classe Presentation, che rappresenta un file di presentazione, espone tutte le diapositive come una collezione [SlideCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slidecollection/) (collezione di oggetti [Slide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slide/)). Questo codice JavaScript mostra come accedere a una diapositiva tramite il suo indice:

```javascript
// Istanzia un oggetto Presentation che rappresenta un file di presentazione
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // Accede a una diapositiva usando il suo indice
    var slide = pres.getSlides().get_Item(0);
} finally {
    pres.dispose();
}
```

## **Accedi alla diapositiva per ID**

Ogni diapositiva in una presentazione ha un ID univoco associato. È possibile utilizzare il metodo [getSlideById](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#getSlideById-long-) (esposto dalla classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/)) per puntare a quell'ID. Questo codice JavaScript mostra come fornire un ID diapositiva valido e accedere a quella diapositiva tramite il metodo [getSlideById](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#getSlideById-long-):

```javascript
// Istanzia un oggetto Presentation che rappresenta un file di presentazione
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // Ottiene l'ID di una diapositiva
    var id = pres.getSlides().get_Item(0).getSlideId();
    // Accede alla diapositiva tramite il suo ID
    var slide = pres.getSlideById(id);
} finally {
    pres.dispose();
}
```

## **Modifica posizione diapositiva**

Aspose.Slides consente di modificare la posizione di una diapositiva. Ad esempio, è possibile specificare che la prima diapositiva diventi la seconda diapositiva.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
1. Ottieni il riferimento della diapositiva (la cui posizione desideri modificare) tramite il suo indice
1. Imposta una nuova posizione per la diapositiva tramite la proprietà [setSlideNumber](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slide/#setSlideNumber-int-).
1. Salva la presentazione modificata.

Questo codice JavaScript dimostra un'operazione in cui la diapositiva nella posizione 1 viene spostata nella posizione 2:

```javascript
// Istanzia un oggetto Presentation che rappresenta un file di presentazione
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Ottiene la diapositiva la cui posizione verrà cambiata
    var sld = pres.getSlides().get_Item(0);
    // Imposta la nuova posizione per la diapositiva
    sld.setSlideNumber(2);
    // Salva la presentazione modificata
    pres.save("helloworld_Pos.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

La prima diapositiva è diventata la seconda; la seconda diapositiva è diventata la prima. Quando si modifica la posizione di una diapositiva, le altre diapositive vengono regolate automaticamente.

## **Imposta numero diapositiva**

Utilizzando la proprietà [setFirstSlideNumber](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#setFirstSlideNumber-int-) (esposta dalla classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/)), è possibile specificare un nuovo numero per la prima diapositiva di una presentazione. Questa operazione fa sì che gli altri numeri delle diapositive vengano ricalcolati.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
1. Ottieni il numero della diapositiva.
1. Imposta il numero della diapositiva.
1. Salva la presentazione modificata.

Questo codice JavaScript dimostra un'operazione in cui il numero della prima diapositiva è impostato a 10:

```javascript
// Istanzia un oggetto Presentation che rappresenta un file di presentazione
var pres = new aspose.slides.Presentation("HelloWorld.pptx");
try {
    // Ottiene il numero della diapositiva
    var firstSlideNumber = pres.getFirstSlideNumber();
    // Imposta il numero della diapositiva
    pres.setFirstSlideNumber(10);
    // Salva la presentazione modificata
    pres.save("Set_Slide_Number_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Se preferisci saltare la prima diapositiva, puoi avviare la numerazione dalla seconda diapositiva (e nascondere la numerazione per la prima diapositiva) in questo modo:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var layoutSlide = presentation.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    // Imposta il numero per la prima diapositiva della presentazione
    presentation.setFirstSlideNumber(0);
    // Mostra i numeri delle diapositive per tutte le diapositive
    presentation.getHeaderFooterManager().setAllSlideNumbersVisibility(true);
    // Nasconde il numero della diapositiva per la prima diapositiva
    presentation.getSlides().get_Item(0).getHeaderFooterManager().setSlideNumberVisibility(false);
    // Salva la presentazione modificata
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **FAQ**

**Il numero della diapositiva che vede l'utente corrisponde all'indice basato su zero della collezione?**

Il numero mostrato su una diapositiva può partire da un valore arbitrario (ad es. 10) e non deve corrispondere all'indice; la relazione è controllata dall'impostazione [first slide number](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/setfirstslidenumber/) della presentazione.

**Le diapositive nascoste influenzano l'indicizzazione?**

Sì. Una diapositiva nascosta rimane nella collezione ed è conteggiata nell'indicizzazione; "hidden" si riferisce alla visualizzazione, non alla sua posizione nella collezione.

**L'indice di una diapositiva cambia quando vengono aggiunte o rimosse altre diapositive?**

Sì. Gli indici riflettono sempre l'ordine corrente delle diapositive e vengono ricalcolati durante le operazioni di inserimento, eliminazione e spostamento.