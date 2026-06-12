---
title: Gestisci i segnaposto delle presentazioni in JavaScript
linktitle: Gestisci segnaposto
type: docs
weight: 10
url: /it/nodejs-java/manage-placeholder/
keywords:
- segnaposto
- segnaposto di testo
- segnaposto immagine
- segnaposto grafico
- testo di suggerimento
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Gestisci i segnaposto in Aspose.Slides per Node.js via Java con facilità: sostituisci il testo, personalizza i suggerimenti e imposta la trasparenza delle immagini in PowerPoint e OpenDocument."
---
## **Panoramica**

Aspose.Slides consente di gestire i segnaposto delle presentazioni in modo programmatico. Questo articolo spiega come trovare i segnaposto nelle diapositive e modificarne il testo, impostare testi di suggerimento personalizzati per i layout dei segnaposto e regolare la trasparenza di un'immagine utilizzata come sfondo del segnaposto. Include anche una breve FAQ che chiarisce la differenza tra segnaposto di base e forme locali, spiega come le modifiche ai segnaposto possono essere applicate tramite layout o master e indica la gestione dei segnaposto di intestazione e piè di pagina.

## **Modifica del testo nel segnaposto**

Utilizzando [Aspose.Slides for Node.js via Java](/slides/it/nodejs-java/), è possibile trovare e modificare i segnaposto nelle diapositive delle presentazioni. Aspose.Slides consente di apportare modifiche al testo di un segnaposto.

**Prerequisito**: È necessaria una presentazione che contenga un segnaposto. È possibile creare tale presentazione con l'app Microsoft PowerPoint standard.

Ecco come utilizzare Aspose.Slides per sostituire il testo del segnaposto in quella presentazione:

1. Istanziare la classe [`Presentation`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation) e passare la presentazione come argomento.
2. Ottenere un riferimento a una diapositiva tramite il suo indice.
3. Iterare tra le forme per trovare il segnaposto.
4. Eseguire il cast della forma segnaposto a un [`AutoShape`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/AutoShape) e modificare il testo usando il [`TextFrame`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/TextFrame) associato all'[`AutoShape`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/AutoShape).
5. Salvare la presentazione modificata.

```javascript
// Istanzia una classe Presentation
var pres = new aspose.slides.Presentation("ReplacingText.pptx");
try {
    // Accede alla prima diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Itera tra le forme per trovare il segnaposto
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (shp.getPlaceholder() != null) {
            // Modifica il testo in ogni segnaposto
            shp.getTextFrame().setText("This is Placeholder");
        }
    }
    // Salva la presentazione su disco
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Imposta il testo di suggerimento nel segnaposto**

I layout standard e predefiniti contengono testi di suggerimento per i segnaposto come ***Click to add a title*** o ***Click to add a subtitle***. Utilizzando Aspose.Slides, è possibile inserire i propri testi di suggerimento nei layout dei segnaposto.

Questo codice JavaScript mostra come impostare il testo di suggerimento in un segnaposto:

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    // Itera attraverso la diapositiva
    for (let i = 0; i < slide.getSlide().getShapes().size(); i++) {
        let shape = slide.getSlide().getShapes().get_Item(i);
        if ((shape.getPlaceholder() != null) && (java.instanceOf(shape, "com.aspose.slides.AutoShape"))) {
            var text = "";
            // PowerPoint visualizza "Click to add title"
            if (shape.getPlaceholder().getType() == aspose.slides.PlaceholderType.CenteredTitle) {
                text = "Add Title";
            } else // Aggiunge sottotitolo
            if (shape.getPlaceholder().getType() == aspose.slides.PlaceholderType.Subtitle) {
                text = "Add Subtitle";
            }
            shape.getTextFrame().setText(text);
            console.log("Placeholder with text: " + text);
        }
    }
    pres.save("Placeholders_PromptText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Imposta la trasparenza dell'immagine del segnaposto**

Aspose.Slides consente di impostare la trasparenza dell'immagine di sfondo in un segnaposto di testo. Regolando la trasparenza dell'immagine in tale cornice, è possibile far risaltare il testo o l'immagine (a seconda dei colori del testo e dell'immagine).

Questo codice JavaScript mostra come impostare la trasparenza per lo sfondo di un'immagine (all'interno di una forma):

```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var operationCollection = shape.getFillFormat().getPictureFillFormat().getPicture().getImageTransform();
for (var i = 0; i < operationCollection.size(); i++) {
    if (java.instanceOf(operationCollection.get_Item(i), "com.aspose.slides.AlphaModulateFixed")) {
        var alphaModulate = operationCollection.get_Item(i);
        var currentValue = 100 - alphaModulate.getAmount();
        console.log("Current transparency value: " + currentValue);
        var alphaValue = 40;
        alphaModulate.setAmount(100 - alphaValue);
    }
}
presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
```

## **FAQ**

**Qual è un segnaposto di base e in che modo differisce da una forma locale in una diapositiva?**

Un segnaposto di base è la forma originale in un layout o master da cui la forma della diapositiva eredita—tipo, posizione e alcune formattazioni provengono da essa. Una forma locale è indipendente; se non esiste un segnaposto di base, l'ereditarietà non si applica.

**Come posso aggiornare tutti i titoli o le didascalie in un'intera presentazione senza iterare su ogni diapositiva?**

Modificare il segnaposto corrispondente nel layout o nel master. Le diapositive basate su quei layout/master erediteranno automaticamente la modifica.

**Come gestire i segnaposto standard di intestazione/piè di pagina—data e ora, numero diapositiva e testo del piè di pagina?**

Utilizzare i gestori HeaderFooter nello scopo appropriato (diapositive normali, layout, master, note/dispense) per attivare o disattivare tali segnaposto e per impostarne il contenuto.