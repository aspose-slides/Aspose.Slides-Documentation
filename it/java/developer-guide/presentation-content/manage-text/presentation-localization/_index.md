---
title: Automatizzare la localizzazione delle presentazioni in Java
linktitle: Localizzazione della presentazione
type: docs
weight: 100
url: /it/java/presentation-localization/
keywords:
- cambio lingua
- controllo ortografico
- ID lingua
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Automatizza la localizzazione di slide PowerPoint e OpenDocument in Java con Aspose.Slides, usando esempi di codice pratici e suggerimenti per una distribuzione globale più veloce."
---
## **Panoramica**

Questo articolo spiega come impostare il `LanguageId` per il testo in una presentazione utilizzando Aspose.Slides. Mostra come aprire una presentazione, aggiungere una forma con testo, assegnare un identificatore di lingua a una porzione di testo e salvare il risultato come file PPTX.

## **Modificare la lingua per una presentazione e il testo di una forma**
- Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).
- Ottieni il riferimento di una diapositiva utilizzando il suo indice.
- Aggiungi un [IAutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/IAutoShape) di tipo [Rectangle](https://reference.aspose.com/slides/it/java/com.aspose.slides/ShapeType#Rectangle) alla diapositiva.
- Aggiungi del testo al TextFrame.
- [Impostazione dell'ID lingua](https://reference.aspose.com/slides/it/java/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) al testo.
- Scrivi la presentazione come file PPTX.

L'implementazione dei passaggi precedenti è mostrata di seguito in un esempio.

```java
Presentation pres = new Presentation("test.pptx");
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.addTextFrame("Text to apply spellcheck language");

    shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLanguageId("en-EN");

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**L'ID lingua attiva la traduzione automatica del testo?**

No. [Language ID](https://reference.aspose.com/slides/it/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) in Aspose.Slides memorizza la lingua per il controllo ortografico e la correzione grammaticale, ma non traduce né modifica il contenuto del testo. È un metadato che PowerPoint comprende per la revisione.

**L'ID lingua influisce sulla sillabazione e le interruzioni di riga durante il rendering?**

In Aspose.Slides, [language ID](https://reference.aspose.com/slides/it/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) è destinato alla revisione. La qualità della sillabazione e l'adattamento delle righe dipendono principalmente dalla disponibilità di [font appropriati](/slides/it/java/powerpoint-fonts/) e dalle impostazioni di layout/interruzione di riga per il sistema di scrittura. Per garantire un rendering corretto, rendi disponibili i font richiesti, configura le [regole di sostituzione dei font](/slides/it/java/font-substitution/) e/o [incorpora i font](/slides/it/java/embedded-font/) nella presentazione.

**Posso impostare lingue diverse all'interno di un unico paragrafo?**

Sì. [Language ID](https://reference.aspose.com/slides/it/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) viene applicato a livello di porzione di testo, quindi un singolo paragrafo può mescolare più lingue con impostazioni di revisione distinte.