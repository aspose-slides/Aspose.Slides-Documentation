---
title: Problema di anteprima dell'oggetto quando si aggiunge OleObjectFrame
linktitle: Problema oggetto OLE
type: docs
weight: 10
url: /it/net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- problema di anteprima
- oggetto incorporato
- file incorporato
- oggetto modificato
- anteprima dell'oggetto
- presentazione
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "Scopri perché appare il messaggio EMBEDDED OLE OBJECT quando si aggiunge OleObjectFrame in Aspose.Slides per .NET e come risolvere i problemi di anteprima nelle presentazioni PPT, PPTX e ODP."
---
## **Introduzione**

Usando Aspose.Slides per .NET, quando aggiungi un [OleObjectFrame](https://reference.aspose.com/slides/it/net/aspose.slides/oleobjectframe) a una diapositiva, sul risultato appare il messaggio "EMBEDDED OLE OBJECT". Questo messaggio è intenzionale e NON è un bug.

Per ulteriori informazioni sul lavoro con gli oggetti OLE, consulta [Manage OLE](/slides/it/net/manage-ole/). 

## **Spiegazione e Soluzione**

Aspose.Slides mostra il messaggio "EMBEDDED OLE OBJECT" per avvisarti che l'oggetto OLE è stato modificato e l'immagine di anteprima deve essere aggiornata. 

Ad esempio, se aggiungi un grafico Microsoft Excel come [OleObjectFrame](https://reference.aspose.com/slides/it/net/aspose.slides/oleobjectframe) a una diapositiva (per maggiori dettagli, vedi l'articolo "Manage OLE") e poi apri la presentazione in Microsoft PowerPoint, vedrai questa immagine nella diapositiva:

![Messaggio oggetto OLE](OLE_object_message.png)

Se desideri verificare e confermare che il tuo oggetto OLE è stato aggiunto alla diapositiva, devi fare doppio clic sul messaggio "EMBEDDED OLE OBJECT", oppure puoi fare clic con il pulsante destro del mouse su di esso e scegliere l'opzione **Oggetto > Modifica**.

![Oggetto OLE > Modifica](OLE_object_edit.png)

PowerPoint apre quindi l'oggetto OLE incorporato.

![Dati oggetto OLE](OLE_object_data.png)

La diapositiva potrebbe mantenere il messaggio "EMBEDDED OLE OBJECT". Una volta cliccato sull'oggetto OLE, l'anteprima della diapositiva viene aggiornata e il messaggio "EMBEDDED OLE OBJECT" viene sostituito dall'immagine reale dell'oggetto OLE. 

![Anteprima oggetto OLE](OLE_object_preview.png)

Ora potresti voler salvare la presentazione per assicurarti che l'immagine dell'oggetto OLE venga aggiornata correttamente. In questo modo, dopo aver salvato la presentazione, quando la riapri, NON vedrai più il messaggio "EMBEDDED OLE OBJECT". 

## **Altre Soluzioni**

### **Soluzione 1: Sostituire il messaggio "Embedded OLE Object" con un'immagine**

Se non vuoi rimuovere il messaggio "EMBEDDED OLE OBJECT" aprendo la presentazione in PowerPoint e poi salvandola, puoi sostituire il messaggio con l'immagine di anteprima che preferisci. Queste righe di codice mostrano il processo:

```cs
using var presentation = new Presentation("embeddedOLE.pptx");

var slide = presentation.Slides[0];
var oleFrame = (IOleObjectFrame)slide.Shapes[0];

// Aggiungi un'immagine alle risorse della presentazione.
using var imageStream = File.OpenRead("myImage.png");
var oleImage = presentation.Images.AddImage(imageStream);

// Imposta un titolo e l'immagine per l'anteprima dell'oggetto OLE.
oleFrame.SubstitutePictureTitle = "My title";
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
```

La diapositiva contenente il `OleObjectFrame` cambia quindi in questo:

![Nuova immagine oggetto OLE](OLE_object_new_image.png)

### **Soluzione 2: Creare un componente aggiuntivo per PowerPoint**

Puoi inoltre creare un componente aggiuntivo per Microsoft PowerPoint che aggiorna tutti gli oggetti OLE quando apri le presentazioni nel programma.