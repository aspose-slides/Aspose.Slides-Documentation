---
title: Gestire gli oggetti OLE nelle presentazioni in .NET
linktitle: Gestire OLE
type: docs
weight: 40
url: /it/net/manage-ole/
keywords:
- oggetto OLE
- Object Linking & Embedding
- aggiungere OLE
- incorporare OLE
- aggiungere oggetto
- incorporare oggetto
- aggiungere file
- incorporare file
- oggetto collegato
- file collegato
- modificare OLE
- icona OLE
- titolo OLE
- estrarre OLE
- estrarre oggetto
- estrarre file
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Ottimizza la gestione degli oggetti OLE in file PowerPoint e OpenDocument con Aspose.Slides per .NET. Incorporali, aggiornali ed esporta il contenuto OLE senza problemi."
---
## **Introduzione**

{{% alert title="Info" color="info" %}}

OLE (Object Linking & Embedding) è una tecnologia Microsoft che consente di inserire dati e oggetti creati in un'applicazione in un'altra applicazione tramite collegamento o incorporamento. 

{{% /alert %}} 

Considera un grafico creato in MS Excel. Il grafico viene poi inserito all'interno di una diapositiva PowerPoint. Quel grafico Excel è considerato un oggetto OLE. 

- Un oggetto OLE può apparire come icona. In tal caso, facendo doppio clic sull'icona, il grafico si apre nell'applicazione associata (Excel), oppure ti viene chiesto di selezionare un'applicazione per aprire o modificare l'oggetto. 
- Un oggetto OLE può visualizzare i propri contenuti reali, come quelli di un grafico. In questo caso, il grafico è attivato in PowerPoint, l'interfaccia del grafico si carica e puoi modificare i dati del grafico all'interno di PowerPoint.

[Aspose.Slides per .NET](https://products.aspose.com/slides/it/net/) consente di inserire oggetti OLE nelle diapositive come frame di oggetti OLE ([OleObjectFrame](https://reference.aspose.com/slides/it/net/aspose.slides/oleobjectframe)).

## **Aggiungere Frame di Oggetti OLE alle Diapositive**

Supponendo che tu abbia già creato un grafico in Microsoft Excel e desideri incorporarlo in una diapositiva come frame di oggetto OLE usando Aspose.Slides per .NET, puoi farlo in questo modo:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).  
2. Ottieni il riferimento a una diapositiva tramite il suo indice.  
3. Leggi il file Excel come array di byte.  
4. Aggiungi il [OleObjectFrame](https://reference.aspose.com/slides/it/net/aspose.slides/oleobjectframe) alla diapositiva includendo l'array di byte e le altre informazioni sull'oggetto OLE.  
5. Scrivi la presentazione modificata come file PPTX.  

Nel esempio sotto, abbiamo aggiunto un grafico da un file Excel a una diapositiva come [OleObjectFrame](https://reference.aspose.com/slides/it/net/aspose.slides/oleobjectframe) usando Aspose.Slides per .NET.  
**Nota** che il costruttore [OleEmbeddedDataInfo](https://reference.aspose.com/slides/it/net/aspose.slides.dom.ole/oleembeddeddatainfo/) accetta un'estensione di oggetto incorporabile come secondo parametro. Questa estensione consente a PowerPoint di interpretare correttamente il tipo di file e di scegliere l'applicazione giusta per aprire questo oggetto OLE.

```csharp 
using (Presentation presentation = new Presentation())
{
    SizeF slideSize = presentation.SlideSize.Size;
    ISlide slide = presentation.Slides[0];

    // Prepara i dati per l'oggetto OLE.
    byte[] fileData = File.ReadAllBytes("book.xlsx");
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

    // Aggiungi il frame dell'oggetto OLE alla diapositiva.
    slide.Shapes.AddOleObjectFrame(0, 0, slideSize.Width, slideSize.Height, dataInfo);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

### **Aggiungere Frame OLE Collegati**

Aspose.Slides per .NET consente di aggiungere un [OleObjectFrame](https://reference.aspose.com/slides/it/net/aspose.slides/oleobjectframe) senza incorporare dati ma solo con un collegamento al file.

Questo codice C# mostra come aggiungere un [OleObjectFrame](https://reference.aspose.com/slides/it/net/aspose.slides/oleobjectframe) con un file Excel collegato a una diapositiva:

```csharp 
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Aggiungi un frame di oggetto OLE con un file Excel collegato.
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Accedere ai Frame di Oggetti OLE**

Se un oggetto OLE è già incorporato in una diapositiva, puoi trovarlo o accedervi facilmente in questo modo:

1. Carica una presentazione con l'oggetto OLE incorporato creando un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).  
2. Ottieni il riferimento della diapositiva utilizzando il suo indice.  
3. Accedi alla forma [OleObjectFrame](https://reference.aspose.com/slides/it/net/aspose.slides/oleobjectframe).  
   Nel nostro esempio, abbiamo utilizzato il PPTX creato in precedenza che contiene una sola forma nella prima diapositiva. Abbiamo quindi *convertito* quell'oggetto in un [IOleObjectFrame](https://reference.aspose.com/slides/it/net/aspose.slides/ioleobjectframe). Questo era il frame OLE desiderato da accedere.  
4. Una volta accesso il frame OLE, puoi eseguire qualsiasi operazione su di esso.

Nel esempio sotto, un frame di oggetto OLE (un oggetto grafico Excel incorporato in una diapositiva) e i suoi dati file sono acceduti.

```csharp 
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Ottieni la prima forma come frame di oggetto OLE.
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

### **Accedere alle Proprietà del Frame OLE Collegato**

Aspose.Slides consente di accedere alle proprietà del frame OLE collegato.

Questo codice C# mostra come verificare se un oggetto OLE è collegato e quindi ottenere il percorso del file collegato:

```csharp
using (Presentation presentation = new Presentation("sample.ppt"))
{
    ISlide slide = presentation.Slides[0];

    // Ottieni la prima forma come frame di oggetto OLE.
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

## **Modificare i Dati dell'Oggetto OLE**

{{% alert color="primary" %}} 

In questa sezione, l'esempio di codice qui sotto utilizza [Aspose.Cells per .NET](/cells/net/).

{{% /alert %}}

Se un oggetto OLE è già incorporato in una diapositiva, puoi accedere facilmente a quell'oggetto e modificarne i dati in questo modo:

1. Carica una presentazione con l'oggetto OLE incorporato creando un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).  
2. Ottieni il riferimento della diapositiva tramite il suo indice.  
3. Accedi alla forma [OLEObjectFrame](https://reference.aspose.com/slides/it/net/aspose.slides/oleobjectframe).  
   Nel nostro esempio, abbiamo utilizzato il PPTX creato in precedenza che contiene una forma nella prima diapositiva. Abbiamo quindi *convertito* quell'oggetto in un [IOleObjectFrame](https://reference.aspose.com/slides/it/net/aspose.slides/ioleobjectframe). Questo era il frame OLE desiderato da accedere.  
4. Una volta accesso il frame OLE, puoi eseguire qualsiasi operazione su di esso.  
5. Crea un oggetto `Workbook` e accedi ai dati OLE.  
6. Accedi al `Worksheet` desiderato e modifica i dati.  
7. Salva il `Workbook` aggiornato in uno stream.  
8. Modifica i dati dell'oggetto OLE dallo stream.

Nel esempio sotto, un frame di oggetto OLE (un oggetto grafico Excel incorporato in una diapositiva) è accessato e i suoi dati file sono modificati per aggiornare i dati del grafico.

```csharp 
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Ottieni la prima forma come frame di oggetto OLE.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        using (MemoryStream oleStream = new MemoryStream(oleFrame.EmbeddedData.EmbeddedFileData))
        {
            // Leggi i dati dell'oggetto OLE come oggetto Workbook.
            Workbook workbook = new Workbook(oleStream);

            using (MemoryStream newOleStream = new MemoryStream())
            {
                // Modifica i dati del workbook.
                workbook.Worksheets[0].Cells[0, 4].PutValue("E");
                workbook.Worksheets[0].Cells[1, 4].PutValue(12);
                workbook.Worksheets[0].Cells[2, 4].PutValue(14);
                workbook.Worksheets[0].Cells[3, 4].PutValue(15);

                OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
                workbook.Save(newOleStream, fileOptions);

                // Modifica i dati dell'oggetto del frame OLE.
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.ToArray(), oleFrame.EmbeddedData.EmbeddedFileExtension);
                oleFrame.SetEmbeddedData(newData);
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Incorporare Altri Tipi di File nelle Diapositive**

Oltre ai grafici Excel, Aspose.Slides per .NET consente di incorporare altri tipi di file nelle diapositive. Ad esempio, è possibile inserire file HTML, PDF e ZIP come oggetti. Quando un utente fa doppio clic sull'oggetto inserito, questo si apre automaticamente nel programma pertinente, oppure all'utente viene chiesto di selezionare un programma appropriato per aprirlo.

Questo codice C# mostra come incorporare HTML e ZIP in una diapositiva:

```c#
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

## **Impostare i Tipi di File per gli Oggetti Incorporati**

Quando lavori con le presentazioni, potresti dover sostituire vecchi oggetti OLE con nuovi o sostituire un oggetto OLE non supportato con uno supportato. Aspose.Slides per .NET consente di impostare il tipo di file per un oggetto incorporato, permettendoti di aggiornare i dati del frame OLE o la sua estensione.

Questo codice C# mostra come impostare il tipo di file per un oggetto OLE incorporato a `zip`:

```c#
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

## **Impostare Immagini Icona e Titoli per gli Oggetti Incorporati**

Dopo aver incorporato un oggetto OLE, viene aggiunta automaticamente un'anteprima costituita da un'immagine icona. Questa anteprima è ciò che gli utenti vedono prima di accedere o aprire l'oggetto OLE. Se desideri utilizzare un'immagine e un testo specifici come elementi dell'anteprima, puoi impostare l'immagine icona e il titolo usando Aspose.Slides per .NET.

Questo codice C# mostra come impostare l'immagine icona e il titolo per un oggetto incorporato: 

```c#
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

## **Impedire il Ridimensionamento e il Riposizionamento di un Frame OLE**

Dopo aver aggiunto un oggetto OLE collegato a una diapositiva di una presentazione, quando apri la presentazione in PowerPoint potresti vedere un messaggio che ti chiede di aggiornare i collegamenti. Cliccando sul pulsante "Update Links" la dimensione e la posizione del frame OLE possono cambiare perché PowerPoint aggiorna i dati dall'oggetto OLE collegato e rinfresca l'anteprima dell'oggetto. Per impedire a PowerPoint di richiedere l'aggiornamento dei dati dell'oggetto, imposta la proprietà `UpdateAutomatic` dell'interfaccia [IOleObjectFrame](https://reference.aspose.com/slides/it/net/aspose.slides/ioleobjectframe/) a `false`:

```cs
oleFrame.UpdateAutomatic = false;
```

## **Estrarre File Incorporati**

Aspose.Slides per .NET consente di estrarre i file incorporati nelle diapositive come oggetti OLE in questo modo:
1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) contenente gli oggetti OLE da estrarre.  
2. Scorri tutte le forme nella presentazione ed accedi alle forme [OLEObjectFrame](https://reference.aspose.com/slides/it/net/aspose.slides/oleobjectframe).  
3. Accedi ai dati dei file incorporati dalle forme OLEObjectFrame e scrivili su disco.

Questo codice C# mostra come estrarre i file incorporati in una diapositiva come oggetti OLE:

```c#
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

**Il contenuto OLE verrà renderizzato durante l'esportazione delle diapositive in PDF/immagini?**

Ciò che è visibile sulla diapositiva viene renderizzato — l'icona/immagine sostitutiva (anteprima). Il contenuto OLE "live" non viene eseguito durante il rendering. Se necessario, imposta la tua immagine di anteprima per garantire l'aspetto previsto nel PDF esportato.

**Come posso bloccare un oggetto OLE su una diapositiva in modo che gli utenti non possano spostarlo/modificarlo in PowerPoint?**

Blocca la forma: Aspose.Slides fornisce [blocchi a livello di forma](/slides/it/net/applying-protection-to-presentation/). Non è una crittografia, ma impedisce efficacemente modifiche e spostamenti accidentali.

**Perché un oggetto Excel collegato "salta" o cambia dimensione quando apro la presentazione?**

PowerPoint può aggiornare l'anteprima dell'OLE collegato. Per un aspetto stabile, segui le pratiche della [Soluzione funzionante per il ridimensionamento dei fogli di lavoro](/slides/it/net/working-solution-for-worksheet-resizing/) — adatta il frame all'intervallo, oppure scala l'intervallo a un frame fisso e imposta un'immagine sostitutiva appropriata.

**I percorsi relativi per gli oggetti OLE collegati saranno mantuti nel formato PPTX?**

Nel PPTX le informazioni sul "percorso relativo" non sono disponibili — solo il percorso completo. I percorsi relativi sono presenti nel formato PPT più vecchio. Per la portabilità, è preferibile utilizzare percorsi assoluti affidabili / URI accessibili o incorporare i file.