---
title: Problema di anteprima dell'oggetto durante l'aggiunta di OleObjectFrame
linktitle: Problema oggetto OLE
type: docs
weight: 10
url: /it/python-java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- problema di anteprima
- oggetto incorporato
- file incorporato
- oggetto modificato
- anteprima dell'oggetto
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Scopri perché appare EMBEDDED OLE OBJECT quando si aggiunge OleObjectFrame in Aspose.Slides per Python tramite Java e come risolvere i problemi di anteprima in presentazioni PPT, PPTX e ODP."
---
## **Introduzione**

Quando usi Aspose.Slides per Python tramite Java per aggiungere un [OleObjectFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/oleobjectframe/) a una diapositiva, viene mostrato il messaggio "EMBEDDED OLE OBJECT" sulla diapositiva di output. Questo messaggio è voluto e non è un bug.

Per ulteriori informazioni su come lavorare con gli oggetti OLE, consulta [Gestisci OLE](/slides/it/python-java/manage-ole/).

## **Spiegazione e soluzione**

Aspose.Slides visualizza il messaggio "EMBEDDED OLE OBJECT" per informarti che l'oggetto OLE è stato modificato e l'immagine di anteprima deve essere aggiornata.

Ad esempio, se aggiungi un grafico di Microsoft Excel come [OleObjectFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/oleobjectframe/) a una diapositiva (per maggiori dettagli, vedi l'articolo "Gestisci OLE") e poi apri la presentazione in Microsoft PowerPoint, vedrai questa immagine sulla diapositiva:

![Messaggio oggetto OLE](OLE_object_message.png)

Per confermare che il tuo oggetto OLE sia stato aggiunto alla diapositiva, fai doppio clic sul messaggio "EMBEDDED OLE OBJECT", oppure fai clic con il tasto destro e seleziona **Object > Edit**.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint quindi apre l'oggetto OLE incorporato.

![Dati oggetto OLE](OLE_object_data.png)

La diapositiva potrebbe mantenere il messaggio "EMBEDDED OLE OBJECT". Una volta fatto clic sull'oggetto OLE, l'anteprima della diapositiva viene aggiornata e il messaggio "EMBEDDED OLE OBJECT" viene sostituito dall'immagine reale dell'oggetto OLE.

![Anteprima oggetto OLE](OLE_object_preview.png)

Salva la presentazione per conservare l'immagine di anteprima aggiornata dell'oggetto OLE. Quando riapri la presentazione, non vedrai più il messaggio "EMBEDDED OLE OBJECT".

## **Altra soluzione**

Se non desideri rimuovere il messaggio "EMBEDDED OLE OBJECT" aprendo la presentazione in PowerPoint e poi salvandola, puoi sostituire il messaggio con l'immagine di anteprima che preferisci. Il seguente codice dimostra il processo:

```python
import jpype
import asposeslides

if not jpide.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation("embeddedOLE.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    # Aggiungi un'immagine alle risorse della presentazione.
    image = Images.fromFile("myImage.png")
    try:
        ole_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # Imposta un titolo e l'immagine per l'anteprima dell'oggetto OLE.
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(False)

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La diapositiva contenente il [OleObjectFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/oleobjectframe/) cambia quindi in questo:

![Nuova immagine oggetto OLE](OLE_object_new_image.png)

## **FAQ**

**Perché appare il messaggio "EMBEDDED OLE OBJECT"?**

Il messaggio indica che l'oggetto OLE è cambiato e la sua immagine di anteprima deve essere aggiornata. Questo comportamento è intenzionale.

**Come posso aggiornare l'anteprima in PowerPoint?**

Fai doppio clic sul messaggio o seleziona **Object > Edit** per aprire l'oggetto OLE incorporato. Fai clic sull'oggetto OLE per aggiornare l'anteprima, quindi salva la presentazione.

**Posso sostituire il messaggio senza aprire la presentazione in PowerPoint?**

Sì. Puoi assegnare un'immagine di anteprima preferita all'oggetto OLE, come mostrato nell'esempio di codice sopra.