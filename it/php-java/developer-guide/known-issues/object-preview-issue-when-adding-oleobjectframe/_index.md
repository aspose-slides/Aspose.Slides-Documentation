---
title: Problema di anteprima dell'oggetto quando si aggiunge OleObjectFrame
linktitle: Problema oggetto OLE
type: docs
weight: 10
url: /it/php-java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- problema di anteprima
- oggetto incorporato
- file incorporato
- oggetto modificato
- anteprima dell'oggetto
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Scopri perché appare EMBEDDED OLE OBJECT quando si aggiunge OleObjectFrame in Aspose.Slides per PHP e come risolvere i problemi di anteprima in presentazioni PPT, PPTX e ODP."
---
## **Introduzione**

Utilizzando Aspose.Slides per PHP tramite Java, quando aggiungi [OleObjectFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/oleobjectframe/) a una diapositiva, viene mostrato il messaggio "EMBEDDED OLE OBJECT" nella diapositiva di output. Questo messaggio è intenzionale e NON è un bug.

Per ulteriori informazioni sul lavoro con gli oggetti OLE, vedere [Manage OLE](/slides/it/php-java/manage-ole/).

## **Spiegazione e Soluzione**

Aspose.Slides visualizza il messaggio "EMBEDDED OLE OBJECT" per avvisarti che l'oggetto OLE è stato modificato e l'immagine di anteprima deve essere aggiornata.

Ad esempio, se aggiungi un grafico Microsoft Excel come [OleObjectFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/oleobjectframe/) a una diapositiva (per ulteriori dettagli, consulta l'articolo "Manage OLE") e poi apri la presentazione in Microsoft PowerPoint, vedrai questa immagine sulla diapositiva:

![Messaggio oggetto OLE](OLE_object_message.png)

Se vuoi verificare e confermare che il tuo oggetto OLE è stato aggiunto alla diapositiva, devi fare doppio clic sul messaggio "EMBEDDED OLE OBJECT", oppure puoi fare clic con il pulsante destro del mouse e scegliere l'opzione **Object > Edit**.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint quindi apre l'oggetto OLE incorporato.

![Dati oggetto OLE](OLE_object_data.png)

La diapositiva può mantenere il messaggio "EMBEDDED OLE OBJECT". Una volta che fai clic sull'oggetto OLE, l'anteprima della diapositiva viene aggiornata e il messaggio "EMBEDDED OLE OBJECT" viene sostituito dall'immagine reale dell'oggetto OLE.

![Anteprima oggetto OLE](OLE_object_preview.png)

Ora potresti voler salvare la presentazione per assicurarti che l'immagine dell'oggetto OLE venga aggiornata correttamente. In questo modo, dopo aver salvato la presentazione, quando la riapri, NON vedrai più il messaggio "EMBEDDED OLE OBJECT".

## **Altre Soluzioni**

### **Soluzione 1: Sostituire il messaggio "Embedded OLE Object" con un'immagine**

Se non vuoi rimuovere il messaggio "EMBEDDED OLE OBJECT" aprendo la presentazione in PowerPoint e poi salvandola, puoi sostituire il messaggio con l'immagine di anteprima che preferisci. Queste righe di codice mostrano il processo:

```php
$presentation = new Presentation("embeddedOLE.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $oleFrame = $slide->getShapes()->get_Item(0);

    // Aggiungi un'immagine alle risorse della presentazione.
    $image = Images::fromFile("myImage.png");
    $oleImage = $presentation->getImages()->addImage($image);
    $image->dispose();

    // Imposta un titolo e l'immagine per l'anteprima dell'oggetto OLE.
    $oleFrame->setSubstitutePictureTitle("My title");
    $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
    $oleFrame->setObjectIcon(false);

    $presentation->save("embeddedOLE-newImage.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

La diapositiva contenente il `OleObjectFrame` quindi cambia in questa:

![Nuova immagine oggetto OLE](OLE_object_new_image.png)

### **Soluzione 2: Creare un componente aggiuntivo per PowerPoint**

Puoi anche creare un componente aggiuntivo per Microsoft PowerPoint che aggiorna tutti gli oggetti OLE quando apri le presentazioni nel programma.