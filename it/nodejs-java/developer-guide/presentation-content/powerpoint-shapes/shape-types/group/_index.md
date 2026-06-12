---
title: Forme di Gruppo nelle Presentazioni in JavaScript
linktitle: Gruppo di Forme
type: docs
weight: 40
url: /it/nodejs-java/group/
keywords:
- forma di gruppo
- gruppo di forme
- aggiungi gruppo
- testo alternativo
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Impara a raggruppare e separare forme nelle presentazioni PowerPoint utilizzando Aspose.Slides per Node.js via Java - guida rapida, passo-passo con codice JavaScript gratuito."
---
## **Panoramica**

Questo articolo spiega come lavorare con le forme di gruppo in Aspose.Slides. Mostra come aggiungere una forma di gruppo a una diapositiva, posizionare forme all'interno e salvare la presentazione aggiornata. Dimostra inoltre come accedere alle forme contenute in un gruppo e leggere i valori di `AlternativeText`. Inoltre, l'articolo tratta brevemente le funzionalità correlate alle forme di gruppo, come gruppi nidificati, ordine Z e opzioni di blocco.

## **Aggiungi Forma di Gruppo**
Aspose.Slides supporta la gestione delle forme di gruppo nelle diapositive. Questa funzionalità aiuta gli sviluppatori a creare presentazioni più ricche. Aspose.Slides per Node.js via Java consente di aggiungere o accedere alle forme di gruppo. È possibile aggiungere forme a una forma di gruppo appena creata per popolarla o accedere a qualsiasi proprietà della forma di gruppo. Per aggiungere una forma di gruppo a una diapositiva usando Aspose.Slides per Node.js via Java:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
1. Ottieni il riferimento di una diapositiva usando il suo indice
1. Aggiungi una forma di gruppo alla diapositiva.
1. Aggiungi le forme alla forma di gruppo appena aggiunta.
1. Salva la presentazione modificata come file PPTX.

L'esempio seguente aggiunge una forma di gruppo a una diapositiva.

```javascript
// Istanziare la classe Presentation
var pres = new aspose.slides.Presentation();
try {
    // Ottieni la prima diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Accesso alla collezione di forme delle diapositive
    var slideShapes = sld.getShapes();
    // Aggiunta di una forma di gruppo alla diapositiva
    var groupShape = slideShapes.addGroupShape();
    // Aggiunta di forme all'interno della forma di gruppo aggiunta
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 300, 100, 100);
    // Aggiunta del frame della forma di gruppo
    groupShape.setFrame(new aspose.slides.ShapeFrame(100, 300, 500, 40, aspose.slides.NullableBool.False, aspose.slides.NullableBool.False, 0));
    // Scrivi il file PPTX su disco
    pres.save("GroupShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Accedi alla proprietà AltText**
Questo argomento mostra passaggi semplici, completi di esempi di codice, per aggiungere una forma di gruppo e accedere alla proprietà AltText delle forme di gruppo nelle diapositive. Per accedere a AltText di una forma di gruppo in una diapositiva usando Aspose.Slides per Node.js via Java:

1. Istanzia la classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation) che rappresenta il file PPTX.
1. Ottieni il riferimento di una diapositiva usando il suo indice.
1. Accedi alla collezione di forme delle diapositive.
1. Accedi alla forma di gruppo.
1. Chiama la proprietà [getAlternativeText](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Shape#getAlternativeText--).

L'esempio seguente accede al testo alternativo della forma di gruppo.

```javascript
// Istanziare la classe Presentation che rappresenta il file PPTX
var pres = new aspose.slides.Presentation("AltText.pptx");
try {
    // Ottieni la prima diapositiva
    var sld = pres.getSlides().get_Item(0);
    for (var i = 0; i < sld.getShapes().size(); i++) {
        // Accesso alla collezione di forme delle diapositive
        var shape = sld.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.GroupShape")) {
            // Accesso alla forma di gruppo.
            var grphShape = shape;
            for (var j = 0; j < grphShape.getShapes().size(); j++) {
                var shape2 = grphShape.getShapes().get_Item(j);
                // Accesso alla proprietà AltText
                console.log(shape2.getAlternativeText());
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Il raggruppamento nidificato (un gruppo all'interno di un altro gruppo) è supportato?**

Sì. [GroupShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/groupshape/) ha un metodo [getParentGroup](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/getparentgroup/) che indica direttamente il supporto alla gerarchia (un gruppo può essere figlio di un altro gruppo).

**Come posso controllare l'ordine Z del gruppo rispetto ad altri oggetti nella diapositiva?**

Usa il metodo [getZOrderPosition](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/getzorderposition/) della [GroupShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/groupshape/) per verificare la sua posizione nello stack di visualizzazione.

**Posso impedire lo spostamento/modifica/scioglimento del gruppo?**

Sì. La sezione di blocco del gruppo è esposta tramite [GroupShapeLock](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/groupshape/getgroupshapelock/), che consente di limitare le operazioni sull'oggetto.