---
title: Problema di anteprima dell'oggetto quando si aggiunge OleObjectFrame
linktitle: Problema oggetto OLE
type: docs
weight: 10
url: /it/nodejs-java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- problema di anteprima
- oggetto incorporato
- file incorporato
- oggetto modificato
- anteprima oggetto
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Scopri perché appare EMBEDDED OLE OBJECT quando si aggiunge OleObjectFrame in Aspose.Slides per Node.js e come risolvere i problemi di anteprima in presentazioni PPT, PPTX e ODP."
---
## **Introduzione**

Usando Aspose.Slides per Java, quando aggiungi [OleObjectFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/oleobjectframe/) a una diapositiva, viene visualizzato un messaggio "EMBEDDED OLE OBJECT" sulla diapositiva di output. Questo messaggio è intenzionale e NON è un bug.

Per ulteriori informazioni sul lavoro con gli oggetti OLE, consulta [Manage OLE](/slides/it/nodejs-java/manage-ole/).

## **Spiegazione e Soluzione**

Aspose.Slides visualizza il messaggio "EMBEDDED OLE OBJECT" per informarti che l'oggetto OLE è stato modificato e l'immagine di anteprima deve essere aggiornata.

Ad esempio, se aggiungi un grafico Microsoft Excel come [OleObjectFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/oleobjectframe/) a una diapositiva (per maggiori dettagli, vedi l'articolo "Manage OLE") e poi apri la presentazione in Microsoft PowerPoint, vedrai questa immagine sulla diapositiva:

![OLE object message](OLE_object_message.png)

Se vuoi verificare e confermare che il tuo oggetto OLE è stato aggiunto alla diapositiva, devi fare doppio clic sul messaggio "EMBEDDED OLE OBJECT", oppure puoi fare clic con il pulsante destro del mouse su di esso e scegliere l'opzione **Object > Edit**.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint apre quindi l'oggetto OLE incorporato.

![OLE object data](OLE_object_data.png)

La diapositiva può mantenere il messaggio "EMBEDDED OLE OBJECT". Una volta cliccato sull'oggetto OLE, l'anteprima della diapositiva viene aggiornata e il messaggio "EMBEDDED OLE OBJECT" viene sostituito dall'immagine reale dell'oggetto OLE.

![OLE object preview](OLE_object_preview.png)

Ora potresti voler salvare la presentazione per garantire che l'immagine dell'oggetto OLE venga aggiornata correttamente. In questo modo, dopo aver salvato la presentazione, riaprendola non vedrai più il messaggio "EMBEDDED OLE OBJECT".

## **Altre Soluzioni**

### **Soluzione 1: Sostituire il messaggio "Embedded OLE Object" con un'immagine**

Se non desideri rimuovere il messaggio "EMBEDDED OLE OBJECT" aprendo la presentazione in PowerPoint e poi salvandola, puoi sostituire il messaggio con l'immagine di anteprima preferita. Queste righe di codice mostrano il processo:

```javascript
const presentation = new aspose.slides.Presentation("embeddedOLE.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const oleFrame = slide.getShapes().get_Item(0);

    // Aggiungi un'immagine alle risorse della presentazione.
    const image = aspose.slides.Images.fromFile("myImage.png");
    const oleImage = presentation.getImages().addImage(image);

    // Imposta un titolo e l'immagine per l'anteprima dell'oggetto OLE.
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

La diapositiva contenente `OleObjectFrame` cambia quindi in questa:

![New OLE object image](OLE_object_new_image.png)

### **Soluzione 2: Creare un componente aggiuntivo per PowerPoint**

Puoi anche creare un componente aggiuntivo per Microsoft PowerPoint che aggiorna tutti gli oggetti OLE quando apri le presentazioni nel programma.