---
title: Animare il testo PowerPoint in JavaScript
linktitle: Testo animato
type: docs
weight: 60
url: /it/nodejs-java/animated-text/
keywords:
- testo animato
- animazione del testo
- paragrafo animato
- animazione del paragrafo
- effetto di animazione
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Crea testo animato dinamico in presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per Node.js, con esempi di codice ottimizzati e facili da seguire."
---
## **Panoramica**

Questo articolo spiega come lavorare con il testo animato in Aspose.Slides applicando effetti di animazione a singoli paragrafi e recuperando gli effetti già assegnati ai paragrafi in un riquadro di testo. Si concentra sui metodi API utilizzati per aggiungere animazioni a livello di paragrafo e per esaminare gli effetti di animazione dei paragrafi già presenti in una presentazione.

## **Aggiungere effetti di animazione ai paragrafi**

Abbiamo aggiunto il metodo [**addEffect()**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Sequence#addEffect-aspose.slides.IParagraph-int-int-int-) alle classi [**Sequence**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Sequence) e [**Sequence**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Sequence). Questo metodo consente di aggiungere effetti di animazione a un singolo paragrafo. Il codice di esempio mostra come aggiungere un effetto di animazione a un singolo paragrafo:

```javascript
var presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // seleziona il paragrafo a cui aggiungere l'effetto
    var autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    // aggiungi l'effetto di animazione Fly al paragrafo selezionato
    var effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(paragraph, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Left, aspose.slides.EffectTriggerType.OnClick);
    presentation.save("AnimationEffectinParagraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Ottenere gli effetti di animazione nei paragrafi**

Potresti decidere di scoprire gli effetti di animazione aggiunti a un paragrafo — ad esempio, in un caso potresti voler ottenere gli effetti di animazione in un paragrafo perché intendi applicarli a un altro paragrafo o forma.

Aspose.Slides per Node.js via Java consente di ottenere tutti gli effetti di animazione applicati ai paragrafi contenuti in un riquadro di testo (forma). Il codice di esempio mostra come ottenere gli effetti di animazione in un paragrafo:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    var autoShape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    for (let i = 0; i < autoShape.getTextFrame().getParagraphs().getCount(); i++) {
        let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(i);
        var effects = sequence.getEffectsByParagraph(paragraph);
        if (effects.length > 0) {
            console.log("Paragraph \"" + paragraph.getText() + "\" has " + effects[0].getType() + " effect.");
        }
    }
} finally {
    pres.dispose();
}
```

## **FAQ**

**In che modo le animazioni del testo differiscono dalle transizioni delle diapositive e possono essere combinate?**

Le animazioni del testo controllano il comportamento degli oggetti nel tempo su una diapositiva, mentre le [transizioni](/slides/it/nodejs-java/slide-transition/) controllano come le diapositive cambiano. Sono indipendenti e possono essere usate insieme; l'ordine di riproduzione è determinato dalla linea temporale dell'animazione e dalle impostazioni di transizione.

**Le animazioni del testo vengono preservate durante l'esportazione in PDF o immagini?**

No. PDF e immagini raster sono statici, quindi vedrai un unico stato della diapositiva senza movimento. Per mantenere il movimento, usa l'esportazione in [video](/slides/it/nodejs-java/convert-powerpoint-to-video/) o in [HTML](/slides/it/nodejs-java/export-to-html5/).

**Le animazioni del testo funzionano nei layout e nel master della diapositiva?**

Gli effetti applicati a oggetti di layout/master vengono ereditati dalle diapositive, ma la loro tempistica e l'interazione con le animazioni a livello di diapositiva dipendono dalla sequenza finale sulla diapositiva.