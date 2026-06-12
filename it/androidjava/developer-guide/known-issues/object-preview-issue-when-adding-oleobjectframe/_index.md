---  
title: Problema di anteprima dell'oggetto aggiungendo OleObjectFrame  
linktitle: Problema OLE Object  
type: docs  
weight: 10  
url: /it/androidjava/object-preview-issue-when-adding-oleobjectframe/  
keywords:  
- OLE  
- problema di anteprima  
- oggetto incorporato  
- file incorporato  
- oggetto modificato  
- anteprima dell'oggetto  
- PowerPoint  
- presentazione  
- Android  
- Java  
- Aspose.Slides  
description: "Scopri perché compare il messaggio EMBEDDED OLE OBJECT quando si aggiunge OleObjectFrame in Aspose.Slides per Android tramite Java e come risolvere i problemi di anteprima nelle presentazioni PPT, PPTX e ODP."  
---
## **Introduzione**

Utilizzando Aspose.Slides per Android tramite Java, quando aggiungi [OleObjectFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/oleobjectframe/) a una diapositiva, viene visualizzato un messaggio "EMBEDDED OLE OBJECT" nella diapositiva di output. Questo messaggio è intenzionale e NOT un bug.

Per ulteriori informazioni sul lavoro con oggetti OLE, vedi [Manage OLE](/slides/it/androidjava/manage-ole/). 

## **Spiegazione e soluzione**

Aspose.Slides visualizza il messaggio "EMBEDDED OLE OBJECT" per informarti che l'oggetto OLE è stato modificato e l'immagine di anteprima deve essere aggiornata. 

Ad esempio, se aggiungi un Microsoft Excel сhart come [OleObjectFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/oleobjectframe/) a una diapositiva (per maggiori dettagli, vedi l'articolo "Manage OLE") e poi apri la presentazione in Microsoft PowerPoint, vedrai questa immagine nella diapositiva:

![OLE object message](OLE_object_message.png)

Se vuoi verificare e confermare che il tuo oggetto OLE è stato aggiunto alla diapositiva, devi fare doppio clic sul messaggio "EMBEDDED OLE OBJECT", oppure puoi fare clic con il pulsante destro su di esso e selezionare l'opzione **Object > Edit**.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint apre quindi l'oggetto OLE incorporato.

![OLE object data](OLE_object_data.png)

La diapositiva può mantenere il messaggio "EMBEDDED OLE OBJECT". Una volta che fai clic sull'oggetto OLE, l'anteprima della diapositiva viene aggiornata e il messaggio "EMBEDDED OLE OBJECT" viene sostituito dall'immagine reale dell'oggetto OLE. 

![OLE object preview](OLE_object_preview.png)

Ora, potresti voler salvare la presentazione per assicurarti che l'immagine dell'OLE Object venga aggiornata correttamente. In questo modo, dopo aver salvato la presentazione, quando la riapri, NON vedrai il messaggio "EMBEDDED OLE OBJECT". 

## **Altre soluzioni**

### **Soluzione 1: Sostituire il messaggio "Embedded OLE Object" con un'immagine**

Se non vuoi rimuovere il messaggio "EMBEDDED OLE OBJECT" aprendo la presentazione in PowerPoint e poi salvandola, puoi sostituire il messaggio con l'immagine di anteprima preferita. Queste righe di codice illustrano il processo:

```java
Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // Aggiungi un'immagine alle risorse della presentazione.
    IImage image = Images.fromFile("myImage.png");
    IPPImage oleImage = presentation.getImages().addImage(image);

    // Imposta un titolo e l'immagine per l'anteprima dell'oggetto OLE.
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

La diapositiva contenente `OleObjectFrame` quindi cambia in questo:

![New OLE object image](OLE_object_new_image.png)

### **Soluzione 2: Creare un componente aggiuntivo per PowerPoint**

Puoi anche creare un componente aggiuntivo per Microsoft PowerPoint che aggiorna tutti gli oggetti OLE quando apri le presentazioni nel programma.