---
title: Gestire gli oggetti OLE nelle presentazioni in .NET
linktitle: Gestisci OLE
type: docs
weight: 40
url: /it/net/manage-ole/
keywords:
- oggetto OLE
- Collegamento e incorporamento di oggetti
- aggiungi OLE
- incorpora OLE
- aggiungi oggetto
- incorpora oggetto
- aggiungi file
- incorpora file
- oggetto collegato
- file collegato
- modifica OLE
- icona OLE
- titolo OLE
- estrai OLE
- estrai oggetto
- estrai file
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Ottimizza la gestione degli oggetti OLE in PowerPoint e nei file OpenDocument con Aspose.Slides per .NET. Incorpora, aggiorna ed esporta contenuti OLE senza problemi."
---
## **Introduzione**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) è una tecnologia Microsoft che consente di inserire dati e oggetti creati in un'applicazione in un'altra applicazione tramite collegamento o incorporamento. 

{{% /alert %}} 

Considera un grafico creato in MS Excel. Il grafico viene quindi inserito all'interno di una diapositiva PowerPoint. Tale grafico Excel è considerato un oggetto OLE. 

- Un oggetto OLE può apparire come un'icona. In questo caso, facendo doppio clic sull'icona, il grafico si apre nell'applicazione associata (Excel), oppure ti viene chiesto di selezionare un'applicazione per aprire o modificare l'oggetto. 
- Un oggetto OLE può mostrare i suoi contenuti effettivi, come i contenuti di un grafico. In questo caso, il grafico viene attivato in PowerPoint, l'interfaccia del grafico si carica e puoi modificare i dati del grafico all'interno di PowerPoint.

[Aspose.Slides for .NET](https://products.aspose.com/slides/net/) consente di inserire oggetti OLE nelle diapositive come frame oggetto OLE ([OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)).

## **Aggiungere frame oggetto OLE alle diapositive**

Assumendo di aver già creato un grafico in Microsoft Excel e di volerlo incorporare in una diapositiva come frame oggetto OLE usando Aspose.Slides for .NET, puoi farlo in questo modo:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).  
2. Ottieni un riferimento alla diapositiva tramite il suo indice.  
3. Leggi il file Excel come array di byte.  
4. Aggiungi l'[OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) alla diapositiva contenente l'array di byte e altre informazioni sull'oggetto OLE.  
5. Scrivi la presentazione modificata come file PPTX.  

Nell'esempio seguente, abbiamo aggiunto un grafico da un file Excel a una diapositiva come [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) usando Aspose.Slides for .NET.  **Nota** che il costruttore [OleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides.dom.ole/oleembeddeddatainfo/) accetta un'estensione di oggetto incorporabile come secondo parametro. Questa estensione consente a PowerPoint di interpretare correttamente il tipo di file e scegliere l'applicazione appropriata per aprire questo oggetto OLE.

```csharp 
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    SizeF slideSize = presentation.SlideSize.Size;
    ISlide slide = presentation.Slides[0];

    // Prepara i dati per l'oggetto OLE.
    byte[] fileData = File.ReadAllBytes("book.xlsx");
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

    // Aggiungi il frame oggetto OLE alla diapositiva.
    slide.Shapes.AddOleObjectFrame(0, 0, slideSize.Width, slideSize.Height, dataInfo);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

### **Aggiungere frame oggetto OLE collegati**

Aspose.Slides for .NET consente di aggiungere un [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) senza incorporare dati ma solo con un collegamento al file.

Questo codice C# mostra come aggiungere un [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) con un file Excel collegato a una diapositiva:

```csharp 
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Aggiungi un frame oggetto OLE con un file Excel collegato.
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Accedere ai frame oggetto OLE**

Se un oggetto OLE è già incorporato in una diapositiva, puoi facilmente trovarlo o accedervi in questo modo:

1. Carica una presentazione con l'oggetto OLE incorporato creando un'istanza della classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).  
2. Ottieni il riferimento della diapositiva usando il suo indice.  
3. Accedi alla forma [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe).  
   Nel nostro esempio, abbiamo usato il PPTX creato in precedenza che ha una sola forma nella prima diapositiva.  Abbiamo quindi *cast* quell'oggetto come un [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe). Questo era il frame oggetto OLE desiderato da accedere.  
4. Una volta acceduto al frame oggetto OLE, puoi eseguire qualsiasi operazione su di esso.  

Nell'esempio seguente, un frame oggetto OLE (un oggetto grafico Excel incorporato in una diapositiva) e i suoi dati file vengono acceduti.

```csharp 
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Ottieni la prima forma come frame oggetto OLE.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        // Ottieni i dati del file incorporato.
        byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

        // Ottieni l'estensione del file incorporato.
        string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

        // ...
    }
}
```

### **Accedere alle proprietà del frame oggetto OLE collegato**

Aspose.Slides consente di accedere alle proprietà del frame oggetto OLE collegato.

Questo codice C# mostra come verificare se un oggetto OLE è collegato e quindi ottenere il percorso del file collegato:

```csharp
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.ppt"))
{
    ISlide slide = presentation.Slides[0];

    // Ottieni la prima forma come frame oggetto OLE.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    // Verifica se l'oggetto OLE è collegato.
    if (oleFrame != null && oleFrame.IsObjectLink)
    {
        // Stampa il percorso completo del file collegato.
        Console.WriteLine("OLE object frame is linked to: " + oleFrame.LinkPathLong);

        // Stampa il percorso relativo del file collegato se presente.
        // Solo le presentazioni PPT possono contenere il percorso relativo.
        if (!string.IsNullOrEmpty(oleFrame.LinkPathRelative))
        {
            Console.WriteLine("OLE object frame relative path: " + oleFrame.LinkPathRelative);
        }
    }
}
```

## **Modificare i dati dell'oggetto OLE**

{{% alert color="info" title="Note" %}}

In questa sezione, l'esempio di codice seguente utilizza [Aspose.Cells for .NET](https://docs.aspose.com/cells/net/).

{{% /alert %}}

Se un oggetto OLE è già incorporato in una diapositiva, puoi facilmente accedere a quell'oggetto e modificarne i dati in questo modo:

1. Carica una presentazione con l'oggetto OLE incorporato creando un'istanza della classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).  
2. Ottieni il riferimento della diapositiva tramite il suo indice.  
3. Accedi alla forma [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe).  
   Nel nostro esempio, abbiamo usato il PPTX creato in precedenza che ha una sola forma nella prima diapositiva. Abbiamo quindi *cast* quell'oggetto come un [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe). Questo era il frame oggetto OLE desiderato da accedere.  
4. Una volta acceduto al frame oggetto OLE, puoi eseguire qualsiasi operazione su di esso.  
5. Crea un oggetto `Workbook` e accedi ai dati OLE.  
6. Accedi al `Worksheet` desiderato e modifica i dati.  
7. Salva il `Workbook` aggiornato in uno stream.  
8. Modifica i dati dell'oggetto OLE dallo stream.  

Nell'esempio seguente, un frame oggetto OLE (un oggetto grafico Excel incorporato in una diapositiva) viene accesso e i suoi dati file vengono modificati per aggiornare i dati del grafico.

```csharp 
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Ottieni la prima forma come frame oggetto OLE.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        using (MemoryStream oleStream = new MemoryStream(oleFrame.EmbeddedData.EmbeddedFileData))
        {
            // Leggi i dati dell'oggetto OLE come oggetto Workbook.
            Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook(oleStream);

            using (MemoryStream newOleStream = new MemoryStream())
            {
                // Modifica i dati del workbook.
                workbook.Worksheets[0].Cells[0, 4].PutValue("E");
                workbook.Worksheets[0].Cells[1, 4].PutValue(12);
                workbook.Worksheets[0].Cells[2, 4].PutValue(14);
                workbook.Worksheets[0].Cells[3, 4].PutValue(15);

                Aspose.Cells.OoxmlSaveOptions fileOptions = new Aspose.Cells.OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
                workbook.Save(newOleStream, fileOptions);

                // Cambia i dati dell'oggetto frame OLE.
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.ToArray(), oleFrame.EmbeddedData.EmbeddedFileExtension);
                oleFrame.SetEmbeddedData(newData);
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Incorporare altri tipi di file nelle diapositive**

Oltre ai grafici Excel, Aspose.Slides for .NET consente di incorporare altri tipi di file nelle diapositive. Ad esempio, è possibile inserire file HTML, PDF e ZIP come oggetti. Quando un utente fa doppio clic sull'oggetto inserito, questo si apre automaticamente nel programma pertinente, oppure all'utente viene chiesto di selezionare un programma appropriato per aprirlo.

Questo codice C# mostra come incorporare HTML e ZIP in una diapositiva:

```c#
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    byte[] htmlData = File.ReadAllBytes("sample.html");
    IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
    IOleObjectFrame htmlOleFrame = slide.Shapes.AddOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
    htmlOleFrame.IsObjectIcon = true;

    byte[] zipData = File.ReadAllBytes("sample.zip");
    IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
    IOleObjectFrame zipOleFrame = slide.Shapes.AddOleObjectFrame(150, 220, 50, 50, zipDataInfo);
    zipOleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Impostare i tipi di file per gli oggetti incorporati**

Quando si lavora con le presentazioni, potrebbe essere necessario sostituire vecchi oggetti OLE con nuovi o sostituire un oggetto OLE non supportato con uno supportato. Aspose.Slides for .NET consente di impostare il tipo di file per un oggetto incorporato, permettendo di aggiornare i dati del frame OLE o la sua estensione.

Questo codice C# mostra come impostare il tipo di file per un oggetto OLE incorporato a `zip`:

```c#
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;
    byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

    Console.WriteLine($"Current embedded file extension is: {fileExtension}");

    // Cambia il tipo di file in ZIP.
    oleFrame.SetEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Impostare immagini icona e titoli per gli oggetti incorporati**

Dopo aver incorporato un oggetto OLE, viene aggiunta automaticamente un'anteprima costituita da un'immagine icona. Questa anteprima è ciò che gli utenti vedono prima di accedere o aprire l'oggetto OLE. Se desideri utilizzare un'immagine e un testo specifici come elementi nell'anteprima, puoi impostare l'immagine icona e il titolo usando Aspose.Slides for .NET.

Questo codice C# mostra come impostare l'immagine icona e il titolo per un oggetto incorporato: 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    // Aggiungi un'immagine alle risorse della presentazione.
    byte[] imageData = File.ReadAllBytes("image.png");
    IPPImage oleImage = presentation.Images.AddImage(imageData);

    // Imposta un titolo e l'immagine per l'anteprima OLE.
    oleFrame.SubstitutePictureTitle = "My title";
    oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
    oleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Impedire il ridimensionamento e lo spostamento di un frame oggetto OLE**

 Dopo aver aggiunto un oggetto OLE collegato a una diapositiva della presentazione, aprendo la presentazione in PowerPoint potresti vedere un messaggio che ti chiede di aggiornare i collegamenti. Cliccando sul pulsante "Update Links" la dimensione e la posizione del frame oggetto OLE potrebbero cambiare perché PowerPoint aggiorna i dati dall'oggetto OLE collegato e aggiorna l'anteprima dell'oggetto. Per impedire a PowerPoint di chiedere l'aggiornamento dei dati dell'oggetto, imposta la proprietà `UpdateAutomatic` dell'interfaccia [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/) su `false`:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IOleObjectFrame oleFrame = (IOleObjectFrame)presentation.Slides[0].Shapes[0];

    // Mantieni la dimensione e la posizione del frame oggetto OLE quando PowerPoint aggiorna il collegamento.
    oleFrame.UpdateAutomatic = false;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Estrarre file incorporati**

Aspose.Slides for .NET consente di estrarre i file incorporati nelle diapositive come oggetti OLE in questo modo:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) che contiene gli oggetti OLE che intendi estrarre.  
2. Scorri tutte le forme nella presentazione e accedi alle forme [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe).  
3. Accedi ai dati dei file incorporati dai frame oggetto OLE e scrivili su disco.  

Questo codice C# mostra come estrarre i file incorporati in una diapositiva come oggetti OLE:

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    for (int index = 0; index < slide.Shapes.Count; index++)
    {
        IShape shape = slide.Shapes[index];
        IOleObjectFrame oleFrame = shape as IOleObjectFrame;

        if (oleFrame != null)
        {
            byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;
            string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

            string filePath = $"OLE_object_{index}{fileExtension}";
            File.WriteAllBytes(filePath, fileData);
        }
    }
}
```

## **FAQ**

**Il contenuto OLE verrà renderizzato quando si esportano le diapositive in PDF/immagini?**

Ciò che è visibile sulla diapositiva viene renderizzato: l'icona/immagine sostitutiva (anteprima). Il contenuto OLE "live" non viene eseguito durante il rendering. Se necessario, imposta la tua immagine di anteprima per garantire l'aspetto previsto nel PDF esportato.

Per preservare anche il file incorporato come allegato PDF, imposta [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) su `true`. Questa opzione è disabilitata per impostazione predefinita. Per un esempio e istruzioni su come verificare l'allegato, vedi [Preservare i file OLE incorporati come allegati PDF](/slides/it/net/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Come posso bloccare un oggetto OLE su una diapositiva in modo che gli utenti non possano spostarlo/modificarlo in PowerPoint?**

Blocca la forma: Aspose.Slides fornisce [blocchi a livello di forma](/slides/it/net/applying-protection-to-presentation/). Questo non è una crittografia, ma impedisce efficacemente modifiche accidentali e spostamenti.

**Perché un oggetto Excel collegato "salta" o cambia dimensione quando apro la presentazione?**

PowerPoint potrebbe aggiornare l'anteprima dell'OLE collegato. Per un aspetto stabile, segui le pratiche di [Soluzione funzionante per il ridimensionamento del foglio di lavoro](/slides/it/net/working-solution-for-worksheet-resizing/) — oppure adatta il frame all'intervallo, oppure scala l'intervallo a un frame fisso e imposta un'immagine sostitutiva appropriata.

**I percorsi relativi per gli oggetti OLE collegati saranno preservati nel formato PPTX?**

Nel PPTX le informazioni sul "percorso relativo" non sono disponibili—solo il percorso completo. I percorsi relativi si trovano nel formato PPT più vecchio. Per la portabilità, preferisci percorsi assoluti affidabili/URI accessibili o l'incorporamento.