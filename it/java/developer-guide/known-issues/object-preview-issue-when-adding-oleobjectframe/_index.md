---
title: Segnaposto dell'anteprima dell'oggetto quando si aggiunge OleObjectFrame
linktitle: Segnaposto anteprima OLE
type: docs
weight: 10
url: /it/java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- problema di anteprima
- segnaposto di anteprima
- per design
- oggetto incorporato
- file incorporato
- oggetto modificato
- anteprima dell'oggetto
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Perché un oggetto OLE aggiunto con Aspose.Slides per Java mostra un segnaposto EMBEDDED OLE OBJECT fino a quando la sua anteprima non viene aggiornata, e come impostare la propria immagine di anteprima."
---
## **Introduzione**

Utilizzando Aspose.Slides per Java, quando aggiungi [OleObjectFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/oleobjectframe/) a una diapositiva, viene visualizzato un messaggio "EMBEDDED OLE OBJECT" sulla diapositiva di output. Questo messaggio è intenzionale e NON è un bug.

Per ulteriori informazioni sul lavoro con gli oggetti OLE, consulta [Gestisci OLE](/slides/it/java/manage-ole/).

## **Spiegazione e Soluzione**

Aspose.Slides visualizza il messaggio "EMBEDDED OLE OBJECT" per informarti che l'oggetto OLE è stato modificato e che l'immagine di anteprima deve essere aggiornata.

Ad esempio, se aggiungi un grafico Microsoft Excel come [OleObjectFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/oleobjectframe/) a una diapositiva (per ulteriori dettagli, consulta l'articolo "Gestisci OLE") e poi apri la presentazione in Microsoft PowerPoint, vedrai questa immagine nella diapositiva:

![Messaggio oggetto OLE](OLE_object_message.png)

Se vuoi verificare e confermare che il tuo oggetto OLE è stato aggiunto alla diapositiva, devi fare doppio clic sul messaggio "EMBEDDED OLE OBJECT", oppure puoi fare clic con il tasto destro su di esso e passare all'opzione **Object > Edit**.

![Oggetto > Modifica](OLE_object_edit.png)

PowerPoint apre quindi l'oggetto OLE incorporato.

![Dati oggetto OLE](OLE_object_data.png)

La diapositiva può mantenere il messaggio "EMBEDDED OLE OBJECT". Una volta fatto clic sull'oggetto OLE, l'anteprima della diapositiva viene aggiornata e il messaggio "EMBEDDED OLE OBJECT" viene sostituito dall'immagine reale dell'oggetto OLE.

![Anteprima oggetto OLE](OLE_object_preview.png)

Ora potresti voler salvare la tua presentazione per assicurarti che l'immagine dell'OLE Object venga aggiornata correttamente. In questo modo, dopo aver salvato la presentazione, quando la apri nuovamente, NON vedrai il messaggio "EMBEDDED OLE OBJECT".

## **Altra Soluzione**

Se non vuoi rimuovere il messaggio "EMBEDDED OLE OBJECT" aprendo la presentazione in PowerPoint e poi salvandola, puoi sostituire il messaggio con l'immagine di anteprima che preferisci. Queste righe di codice dimostrano il processo. Suppongono che la prima forma nella prima diapositiva di *embeddedOLE.pptx* sia il frame dell'oggetto OLE e che *myImage.png* contenga l'immagine da mostrare, e salvano il risultato come *embeddedOLE-newImage.pptx*:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // Aggiungi un'immagine alle risorse della presentazione.
    IImage image = Images.fromFile("myImage.png");
    IPPImage oleImage = presentation.getImages().addImage(image);
    image.dispose();

    // Imposta l'immagine per l'anteprima dell'oggetto OLE.
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La diapositiva contenente il `OleObjectFrame` allora cambia così:

![Nuova immagine oggetto OLE](OLE_object_new_image.png)