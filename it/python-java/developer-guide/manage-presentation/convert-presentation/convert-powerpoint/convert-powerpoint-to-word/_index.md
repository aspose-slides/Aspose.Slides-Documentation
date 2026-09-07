---
title: Converti presentazioni PowerPoint in documenti Word in Python tramite Java
linktitle: PowerPoint in Word
type: docs
weight: 110
url: /it/python-java/convert-powerpoint-to-word/
keywords:
- converti PowerPoint
- converti presentazione
- PowerPoint in Word
- presentazione in Word
- PPT in Word
- PPTX in Word
- ODP in Word
- PowerPoint in DOCX
- PPT in DOCX
- PPTX in DOCX
- PowerPoint in DOC
- salva PPT come DOCX
- salva PPTX come DOCX
- esporta PPT in DOCX
- esporta PPTX in DOCX
- Python
- Java
- Aspose.Slides
description: "Converti presentazioni PowerPoint e OpenDocument in Word in Python tramite Java con Aspose.Slides e Aspose.Words, combinando le immagini delle diapositive con testo modificabile."
---
## **Panoramica**

Questo articolo spiega come convertire presentazioni PowerPoint e OpenDocument in documenti Word utilizzando Aspose.Slides per Python tramite Java insieme a Aspose.Words per Java. Aspose.Slides rende ogni diapositiva e legge il suo testo, mentre Aspose.Words crea il documento Word tramite JPype. Microsoft Office non è necessario.

Il documento risultante contiene un'immagine della diapositiva seguita dal testo modificabile estratto dalle forme automatiche di livello superiore di quella diapositiva. L'immagine conserva l'aspetto visivo della diapositiva; forme individuali, grafici e tabelle non vengono convertiti in oggetti Word modificabili. Il testo estratto non mantiene la formattazione o la posizione originale del testo.

## **Converti PowerPoint in Word**

1. Installa [Aspose.Slides per Python tramite Java](/slides/it/python-java/installation/) e un runtime Java compatibile.
2. Scarica [Aspose.Words per Java](https://releases.aspose.com/words/java/). Posiziona il suo file JAR principale in una directory `lib` accanto al tuo script e rinominalo in `aspose-words.jar`, oppure regola il percorso nell'esempio per corrispondere al file scaricato.
3. Posiziona la presentazione di input, `sample.pptx`, nella directory di lavoro. Il percorso `lib/aspose-words.jar` è anch'esso relativo a quella directory.
4. Esegui il seguente codice Python per creare `output.docx`.

L'esempio carica la sorgente con [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) e rende le diapositive con [Slide.getImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/slide/#getImage). Utilizza [DocumentBuilder](https://reference.aspose.com/words/java/com.aspose.words/documentbuilder/) di Aspose.Words per inserire le immagini e il testo nel documento Word.

```python
from pathlib import Path

import jpype
import asposeslides

words_jar = Path("lib/aspose-words.jar").resolve()
jpype.addClassPath(str(words_jar))
if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, ImageFormat, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")
Document = jpype.JClass("com.aspose.words.Document")
DocumentBuilder = jpype.JClass("com.aspose.words.DocumentBuilder")
BreakType = jpype.JClass("com.aspose.words.BreakType")

presentation = Presentation("sample.pptx")
try:
    document = Document()
    builder = DocumentBuilder(document)
    page_setup = builder.getPageSetup()
    content_width = page_setup.getPageWidth() - page_setup.getLeftMargin() - page_setup.getRightMargin()
    slide_size = presentation.getSlideSize().getSize()
    image_height = content_width * slide_size.getHeight() / slide_size.getWidth()
    slide_count = presentation.getSlides().size()

    for slide_index in range(slide_count):
        if slide_index > 0:
            builder.insertBreak(BreakType.PAGE_BREAK)

        slide = presentation.getSlides().get_Item(slide_index)
        image = slide.getImage(1.0, 1.0)
        try:
            image_stream = ByteArrayOutputStream()
            try:
                image.save(image_stream, ImageFormat.Png)
                image_bytes = image_stream.toByteArray()
            finally:
                image_stream.close()
        finally:
            image.dispose()

        # Adatta l'immagine della diapositiva alla larghezza dell'area di testo, preservando il suo rapporto d'aspetto.
        builder.insertImage(image_bytes, content_width, image_height)
        builder.writeln()

        # Aggiungi testo semplice dalle forme automatiche di livello superiore, incluse le caselle di testo.
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                text_frame = shape.getTextFrame()
                if text_frame is not None:
                    text = str(text_frame.getText())
                    if text.strip():
                        builder.writeln(text)

    document.save("output.docx")
finally:
    presentation.dispose()
```

Ogni diapositiva inizia su una nuova pagina. Testi estratti lunghi o immagini diapositive insolitamente alte possono richiedere pagine aggiuntive. Il codice aggiunge interruzioni di pagina solo tra le diapositive e rilascia la presentazione e le immagini renderizzate nei blocchi `finally`. La JVM rimane disponibile per conversioni successive nello stesso processo Python.

## **Domande frequenti**

**Quali librerie sono necessarie?**

Utilizza Aspose.Slides per Python tramite Java, JPype, un runtime Java compatibile e Aspose.Words per Java. Entrambe le librerie Aspose vengono eseguite nella stessa JVM. Aspose.Slides gestisce la presentazione; Aspose.Words scrive il documento Word.

**Posso convertire file PPT e ODP oltre a PPTX?**

Sì. Sostituisci `sample.pptx` con un file PPT o ODP. Consulta [Formati di file supportati](/slides/it/python-java/supported-file-formats/) per i formati di input delle presentazioni.

**Tutto il contenuto della diapositiva è modificabile in Word?**

No. Ogni diapositiva viene inserita come immagine statica, con testo semplice dalle forme automatiche di livello superiore aggiunto sotto. Il testo all'interno di gruppi, tabelle, SmartArt e grafici, così come le note del relatore, non viene estratto da questo esempio. Animazioni e transizioni non sono replicate nel documento Word.

**Posso salvare come DOC invece di DOCX?**

Sì. Cambia il nome del file di output in `output.doc`. Aspose.Words seleziona il formato di output dall'estensione del nome file quando si utilizza questa overload di salvataggio.