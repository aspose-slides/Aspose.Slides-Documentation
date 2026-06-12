---
title: Problema di anteprima dell'oggetto quando si aggiunge OleObjectFrame
linktitle: Problema oggetto OLE
type: docs
weight: 10
url: /it/python-net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- problema di anteprima
- oggetto incorporato
- file incorporato
- oggetto modificato
- anteprima oggetto
- presentazione
- PowerPoint
- Python
- Aspose.Slides
description: "Scopri perché appare EMBEDDED OLE OBJECT quando si aggiunge OleObjectFrame in Aspose.Slides per Python e come risolvere i problemi di anteprima in presentazioni PPT, PPTX e ODP."
---
## **Introduzione**

Utilizzando Aspose.Slides per Python tramite .NET, quando aggiungi [OleObjectFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/oleobjectframe/) a una diapositiva, viene visualizzato un messaggio "EMBEDDED OLE OBJECT" sulla diapositiva risultante. Questo messaggio è intenzionale e NON è un bug.

Per ulteriori informazioni sul lavoro con gli oggetti OLE, consulta [Manage OLE](/slides/it/python-net/manage-ole/).

## **Spiegazione e Soluzione**

Aspose.Slides visualizza il messaggio "EMBEDDED OLE OBJECT" per informarti che l'oggetto OLE è stato modificato e l'immagine di anteprima deve essere aggiornata. 

Ad esempio, se aggiungi un grafico Microsoft Excel come [OleObjectFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/oleobjectframe/) a una diapositiva (per maggiori dettagli, vedi l'articolo "Manage OLE") e poi apri la presentazione in Microsoft PowerPoint, vedrai questa immagine nella diapositiva:

![OLE object message](OLE_object_message.png)

Se vuoi verificare e confermare che il tuo oggetto OLE è stato aggiunto alla diapositiva, devi fare doppio clic sul messaggio "EMBEDDED OLE OBJECT", oppure puoi fare clic con il pulsante destro su di esso e selezionare l'opzione **Object > Edit**.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint apre quindi l'oggetto OLE incorporato.

![OLE object data](OLE_object_data.png)

La diapositiva potrebbe mantenere il messaggio "EMBEDDED OLE OBJECT". Una volta cliccato sull'oggetto OLE, l'anteprima della diapositiva viene aggiornata e il messaggio "EMBEDDED OLE OBJECT" viene sostituito dall'immagine reale dell'oggetto OLE. 

![OLE object preview](OLE_object_preview.png)

Ora potresti voler salvare la tua presentazione per assicurarti che l'immagine dell'oggetto OLE venga aggiornata correttamente. In questo modo, dopo aver salvato la presentazione, quando la riapri, NON vedrai più il messaggio "EMBEDDED OLE OBJECT". 

## **Altre Soluzioni**

### **Soluzione 1: Sostituire il messaggio "Embedded OLE Object" con un'immagine**

Se non vuoi rimuovere il messaggio "EMBEDDED OLE OBJECT" aprendo la presentazione in PowerPoint e poi salvandola, puoi sostituire il messaggio con l'immagine di anteprima preferita. Queste righe di codice illustrano il processo:

```py
with Presentation("embeddedOLE.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # Aggiungi un'immagine alle risorse della presentazione.
    with Images.from_file("myImage.png") as image:
        ole_image = presentation.images.add_image(image)

    # Imposta un titolo e l'immagine per l'anteprima dell'oggetto OLE.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = False

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.PPTX)
```

La diapositiva contenente `OleObjectFrame` quindi cambia in questo:

![New OLE object image](OLE_object_new_image.png)

### **Soluzione 2: Creare un componente aggiuntivo per PowerPoint**

Puoi anche creare un componente aggiuntivo per Microsoft PowerPoint che aggiorna tutti gli oggetti OLE quando apri le presentazioni nel programma.