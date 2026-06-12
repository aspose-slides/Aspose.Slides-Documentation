---
title: Automatizzare la localizzazione delle presentazioni su Android
linktitle: Localizzazione della presentazione
type: docs
weight: 100
url: /it/androidjava/presentation-localization/
keywords:
- cambio lingua
- controllo ortografico
- ID lingua
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Automatizza la localizzazione delle diapositive PowerPoint e OpenDocument in Java con Aspose.Slides per Android, utilizzando esempi di codice pratici e consigli per una distribuzione globale più rapida."
---
## **Panoramica**

Questo articolo spiega come impostare il `LanguageId` per il testo in una presentazione utilizzando Aspose.Slides. Mostra come aprire una presentazione, aggiungere una forma con testo, assegnare un identificatore di lingua a una porzione di testo e salvare il risultato come file PPTX.

## **Modifica la lingua per una presentazione e il testo di una forma**
- Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation).
- Ottieni il riferimento di una diapositiva utilizzando il suo indice.
- Aggiungi un [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IAutoShape) di tipo [Rectangle](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ShapeType#Rectangle) alla diapositiva.
- Aggiungi del testo al TextFrame.
- [Impostare Language Id](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) al testo.
- Scrivi la presentazione come file PPTX.

L'implementazione dei passaggi sopra è mostrata di seguito in un esempio.

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

No. L'[ID lingua](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) in Aspose.Slides memorizza la lingua per il controllo ortografico e la revisione grammaticale, ma non traduce né modifica il contenuto del testo. È un metadato che PowerPoint interpreta per la revisione.

**L'ID lingua influisce sulla sillabazione e sulle interruzioni di riga durante il rendering?**

In Aspose.Slides, l'[ID lingua](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) è per la revisione. La qualità della sillabazione e l'andamento delle interruzioni di riga dipendono principalmente dalla disponibilità dei [font appropriati](/slides/it/androidjava/powerpoint-fonts/) e dalle impostazioni di layout/interruzione di riga per il sistema di scrittura. Per garantire un rendering corretto, rendi disponibili i font necessari, configura le [regole di sostituzione dei font](/slides/it/androidjava/font-substitution/) e/o [incorpora i font](/slides/it/androidjava/embedded-font/) nella presentazione.

**Posso impostare lingue diverse all'interno di un unico paragrafo?**

Sì. L'[ID lingua](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) viene applicato a livello di porzione di testo, quindi un unico paragrafo può mescolare più lingue con impostazioni di revisione distinte.