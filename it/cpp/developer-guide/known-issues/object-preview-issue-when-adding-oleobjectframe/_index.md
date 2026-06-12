---
title: Problema di anteprima dell'oggetto aggiungendo OleObjectFrame
linktitle: Problema oggetto OLE
type: docs
weight: 10
url: /it/cpp/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- problema di anteprima
- oggetto incorporato
- file incorporato
- oggetto modificato
- anteprima oggetto
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Scopri perché compare EMBEDDED OLE OBJECT quando si aggiunge OleObjectFrame in Aspose.Slides for C++ e come risolvere i problemi di anteprima in presentazioni PPT, PPTX e ODP."
---
## **Introduzione**

Utilizzando Aspose.Slides per C++, quando aggiungi [OleObjectFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/oleobjectframe/) a una diapositiva, viene mostrato un messaggio "EMBEDDED OLE OBJECT" sulla diapositiva di output. Questo messaggio è intenzionale e NON è un bug.

Per ulteriori informazioni su come lavorare con gli oggetti OLE, vedi [Manage OLE](/slides/it/cpp/manage-ole/). 

## **Spiegazione e Soluzione**

Aspose.Slides visualizza il messaggio "EMBEDDED OLE OBJECT" per informarti che l'oggetto OLE è stato modificato e l'immagine di anteprima deve essere aggiornata. 

Ad esempio, se aggiungi un grafico Microsoft Excel come [OleObjectFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/oleobjectframe/) a una diapositiva (per maggiori dettagli, consulta l'articolo "Manage OLE") e poi apri la presentazione in Microsoft PowerPoint, vedrai questa immagine sulla diapositiva:

![Messaggio oggetto OLE](OLE_object_message.png)

Se vuoi verificare e confermare che il tuo oggetto OLE è stato aggiunto alla diapositiva, devi fare doppio clic sul messaggio "EMBEDDED OLE OBJECT", oppure puoi fare clic con il pulsante destro del mouse su di esso e scegliere l'opzione **Object > Edit**.

![Oggetto OLE > Modifica](OLE_object_edit.png)

PowerPoint apre quindi l'oggetto OLE incorporato.

![Dati oggetto OLE](OLE_object_data.png)

La diapositiva potrebbe mantenere il messaggio "EMBEDDED OLE OBJECT". Quando fai clic sull'oggetto OLE, l'anteprima della diapositiva viene aggiornata e il messaggio "EMBEDDED OLE OBJECT" viene sostituito dall'immagine reale dell'oggetto OLE. 

![Anteprima oggetto OLE](OLE_object_preview.png)

Ora potresti voler salvare la presentazione per garantire che l'immagine per l'OLE Object venga aggiornata correttamente. In questo modo, dopo aver salvato la presentazione, quando la riapri, NON vedrai più il messaggio "EMBEDDED OLE OBJECT". 

## **Altre soluzioni**

### **Soluzione 1: Sostituire il messaggio "Embedded OLE Object" con un'immagine**

Se non vuoi rimuovere il messaggio "EMBEDDED OLE OBJECT" aprendo la presentazione in PowerPoint e poi salvandola, puoi sostituire il messaggio con l'immagine di anteprima desiderata. Queste righe di codice dimostrano il processo:

```cpp
auto presentation = MakeObject<Presentation>(u"embeddedOLE.pptx");

auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

// Add an image to presentation resources.
auto imageStream = File::OpenRead(u"myImage.png");
auto oleImage = presentation->get_Images()->AddImage(imageStream);
imageStream->Dispose();

// Set a title and the image for the OLE object preview.
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"embeddedOLE-newImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

La diapositiva contenente il `OleObjectFrame` cambia quindi in questo:

![Nuova immagine oggetto OLE](OLE_object_new_image.png)

### **Soluzione 2: Creare un add-in per PowerPoint**

Puoi anche creare un add-in per Microsoft PowerPoint che aggiorna tutti gli oggetti OLE quando apri le presentazioni nel programma.