---
title: Converti presentazioni PowerPoint in documenti Word in Java
linktitle: PowerPoint in Word
type: docs
weight: 110
url: /it/java/convert-powerpoint-to-word/
keywords:
- converti PowerPoint
- converti presentazione
- converti diapositiva
- converti PPT
- converti PPTX
- PowerPoint in Word
- presentazione in Word
- diapositiva in Word
- PPT in Word
- PPTX in Word
- PowerPoint in DOCX
- presentazione in DOCX
- diapositiva in DOCX
- PPT in DOCX
- PPTX in DOCX
- PowerPoint in DOC
- presentazione in DOC
- diapositiva in DOC
- PPT in DOC
- PPTX in DOC
- salva PPT come DOCX
- salva PPTX come DOCX
- esporta PPT in DOCX
- esporta PPTX in DOCX
- Java
- Aspose.Slides
description: "Converti diapositive PowerPoint PPT e PPTX in documenti Word modificabili in Java utilizzando Aspose.Slides con layout preciso, immagini e formattazione preservati."
---
## **Panoramica**

Questo articolo fornisce una soluzione per gli sviluppatori per convertire presentazioni PowerPoint e OpenDocument in documenti Word utilizzando Aspose.Slides e Aspose.Words. La guida passo‑passo ti accompagna attraverso ogni fase del processo di conversione.

## **Converti PowerPoint in Word**

Segui le istruzioni seguenti per convertire una presentazione PowerPoint o OpenDocument in un documento Word:

1. Scarica le librerie [Aspose.Slides for Java](https://downloads.aspose.com/slides/it/java) e [Aspose.Words for Java](https://downloads.aspose.com/words/java).
2. Aggiungi *aspose-slides-x.x-jdk16.jar* e *aspose-words-x.x-jdk16.jar* al tuo CLASSPATH.
3. Usa questo frammento di codice per convertire il PowerPoint in Word:

```java
Presentation pres = new Presentation("sample.pptx");

Document doc = new Document();
DocumentBuilder builder = new DocumentBuilder(doc);

for (ISlide slide : pres.getSlides()) {
    // genera un'immagine della diapositiva come flusso di array di byte
    IImage image = slide.getImage(1, 1);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();
    image.save(imageStream, ImageFormat.Png);
    image.dispose();

    builder.insertImage(imageStream.toByteArray());

    // inserisce i testi della diapositiva
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof AutoShape) {
            builder.writeln(((AutoShape) shape).getTextFrame().getText());
        }
    }

    builder.insertBreak(BreakType.PAGE_BREAK);
}

doc.save("output.docx");
pres.dispose();
```

## **Domande frequenti**

**Quali componenti devono essere installati per convertire presentazioni PowerPoint e OpenDocument in documenti Word?**

Devi solo aggiungere il pacchetto corrispondente per [Aspose.Slides for Java](https://releases.aspose.com/slides/it/java/) e [Aspose.Words for Java](https://releases.aspose.com/words/java/) al tuo progetto. Entrambe le librerie funzionano come API autonome e non è necessario avere Microsoft Office installato.

**Sono supportati tutti i formati di presentazione PowerPoint e OpenDocument?**

Aspose.Slides [supporta tutti i formati di presentazione](/slides/it/java/supported-file-formats/), tra cui PPT, PPTX, ODP e altri tipi di file comuni. Questo garantisce che tu possa lavorare con presentazioni create in varie versioni di Microsoft PowerPoint.