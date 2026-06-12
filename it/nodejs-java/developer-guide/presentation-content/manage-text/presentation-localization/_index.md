---
title: Automatizzare la localizzazione delle presentazioni in JavaScript
linktitle: Localizzazione delle presentazioni
type: docs
weight: 100
url: /it/nodejs-java/presentation-localization/
keywords:
- cambiare lingua
- controllo ortografico
- ID lingua
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Automatizza la localizzazione di diapositive PowerPoint e OpenDocument in JavaScript con Aspose.Slides, utilizzando esempi di codice pratici e consigli per una distribuzione globale più rapida."
---
## **Panoramica**

Questo articolo spiega come impostare il `LanguageId` per il testo in una presentazione utilizzando Aspose.Slides. Mostra come aprire una presentazione, aggiungere una forma con testo, assegnare un identificatore di lingua a una parte di testo e salvare il risultato come file PPTX.

## **Modifica della lingua per la presentazione e il testo della forma**

- Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
- Ottieni il riferimento di una diapositiva utilizzando il suo indice.
- Aggiungi un [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/AutoShape) di tipo [Rectangle](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ShapeType#Rectangle) alla diapositiva.
- Aggiungi del testo al TextFrame.
- [Impostazione ID lingua](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/BasePortionFormat#setLanguageId-java.lang.String-) al testo.
- Scrivi la presentazione come file PPTX.

L'implementazione dei passaggi precedenti è mostrata di seguito in un esempio.

```javascript
var pres = new aspose.slides.Presentation("test.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    shape.addTextFrame("Text to apply spellcheck language");
    shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLanguageId("en-EN");
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**L'ID lingua attiva la traduzione automatica del testo?**

No. [setLanguageId](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) in Aspose.Slides memorizza la lingua per il controllo ortografico e la correzione grammaticale, ma non traduce né modifica il contenuto del testo. È un metadato che PowerPoint comprende per la correzione.

**L'ID lingua influisce sull'uso della sillabazione e delle interruzioni di riga durante il rendering?**

In Aspose.Slides, [setLanguageId](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) è destinato alla correzione. La qualità della sillabazione e dell'andamento delle righe dipende principalmente dalla disponibilità di [font appropriati](/slides/it/nodejs-java/powerpoint-fonts/) e dalle impostazioni di layout/interruzione di riga per il sistema di scrittura. Per garantire un rendering corretto, rende disponibili i font necessari, configura le [regole di sostituzione dei font](/slides/it/nodejs-java/font-substitution/) e/o [incorpora i font](/slides/it/nodejs-java/embedded-font/) nella presentazione.

**Posso impostare lingue diverse all'interno di un unico paragrafo?**

Sì. [setLanguageId](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) viene applicato a livello di porzione di testo, quindi un singolo paragrafo può mescolare più lingue con impostazioni di correzione distinte.