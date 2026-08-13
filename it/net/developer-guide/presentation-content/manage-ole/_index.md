---
title: Gestire gli oggetti OLE nelle presentazioni in .NET
linktitle: Gestire OLE
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
description: "Ottimizza la gestione degli oggetti OLE in PowerPoint e nei file OpenDocument con Aspose.Slides per .NET. Incorpora, aggiorna ed esporta i contenuti OLE senza problemi."
---
## **Introduzione**

{{% alert title="Info" color="info" %}}

OLE (Object Linking & Embedding) è una tecnologia Microsoft che consente di inserire dati e oggetti creati in un’applicazione all’interno di un’altra applicazione tramite collegamento o incorporamento. 

{{% /alert %}} 

Considera un grafico creato in MS Excel. Il grafico viene poi inserito in una diapositiva di PowerPoint. Quel grafico Excel è considerato un oggetto OLE. 

- Un oggetto OLE può apparire come icona. In questo caso, facendo doppio clic sull’icona, il grafico si apre nell’applicazione associata (Excel), oppure ti viene chiesto di selezionare un’applicazione per aprire o modificare l’oggetto. 
- Un oggetto OLE può visualizzare il suo contenuto reale, ad esempio il contenuto di un grafico. In questo caso, il grafico è attivato in PowerPoint, si carica l’interfaccia del grafico e puoi modificare i dati del grafico all’interno di PowerPoint.

[Aspose.Slides per .NET](https://products.aspose.com/slides/it/net/) consente di inserire OLE Object nei diapositivi come frame OLE ([OleObjectFrame](https://reference.aspose.com/slides/it/net/aspose.slides/oleobjectframe)).

## **Aggiungere frame OLE Object ai diapositivi**

Supponendo di aver già creato un grafico in Microsoft Excel e di volerlo incorporare in una diapositiva come frame OLE Object usando Aspose.Slides per .NET, è possibile procedere così:

1. Creare un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
2. Ottenere il riferimento a una diapositiva tramite il suo indice.
3. Leggere il file Excel come array di byte.
4. Aggiungere il [OleObjectFrame](https://reference.aspose.com/slides/it/net/aspose.slides/oleobjectframe) alla diapositiva contenente l’array di byte e altre informazioni sull’oggetto OLE.
5. Scrivere la presentazione modificata come file PPTX.

Nell’esempio seguente, abbiamo aggiunto un grafico da un file Excel a una diapositiva come [OleObjectFrame](https://reference.aspose.com/slides/it/net/aspose.slides/oleobjectframe) usando Aspose.Slides per .NET.  
**Nota** che il costruttore di [OleEmbeddedDataInfo](https://reference.aspose.com/slides/it/net/aspose.slides.dom.ole/oleembeddeddatainfo/) accetta un’estensione di oggetto incorporabile come secondo parametro. Questa estensione consente a PowerPoint di interpretare correttamente il tipo di file e scegliere l’applicazione giusta per aprire l’oggetto OLE.

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

    // Aggiungi il frame dell'oggetto OLE alla diapositiva.
    slide.Shapes.AddOleObjectFrame(0, 0, slideSize.Width, slideSize.Height, dataInfo);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

### **Aggiungere frame OLE Object collegati**

Aspose.Slides per .NET consente di aggiungere un [OleObjectFrame](https://reference.aspose.com/slides/it/net/aspose.slides/oleobjectframe) senza incorporare i dati, ma solo con un collegamento al file.

Questo codice C# mostra come aggiungere un [OleObjectFrame](https://reference.aspose.com/slides/it/net/aspose.slides/oleobjectframe) con un file Excel collegato a una diapositiva:

```csharp 
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Aggiungi un frame OLE con un file Excel collegato.
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Accedere ai frame OLE Object**

Se un oggetto OLE è già incorporato in una diapositiva, è possibile trovarlo o accedervi facilmente in questo modo:

1. Caricare una presentazione con l’oggetto OLE incorporato creando un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
2. Ottenere il riferimento alla diapositiva usando il suo indice.
3. Accedere alla forma [OleObjectFrame](https://reference.aspose.com/slides/it/net/aspose.slides/oleobjectframe).  
   Nel nostro esempio, abbiamo utilizzato il PPTX creato in precedenza che contiene una sola forma nella prima diapositiva. Abbiamo quindi *castato* quell’oggetto come [IOleObjectFrame](https://reference.aspose.com/slides/it/net/aspose.slides/ioleobjectframe). Questo era il frame OLE desiderato da accedere.
4. Una volta ottenuto il frame OLE, è possibile eseguire qualsiasi operazione su di esso.

Nel seguente esempio, un frame OLE Object (un grafico Excel incorporato in una diapositiva) e i suoi dati file vengono acceduti.

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

### **Accedere alle proprietà del frame OLE Object collegato**

Aspose.Slides consente di accedere alle proprietà dei frame OLE Object collegati.

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

{{% alert color="info" %}} 

In questa sezione, l’esempio di codice sottostante utilizza [Aspose.Cells per .NET](/cells/net/).

{{% /alert %}}

Se un oggetto OLE è già incorporato in una diapositiva, è possibile accedere a quell’oggetto e modificarne i dati in questo modo:

1. Caricare una presentazione con l’oggetto OLE incorporato creando un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
2. Ottenere il riferimento alla diapositiva tramite il suo indice. 
3. Accedere alla forma [OLEObjectFrame](https://reference.aspose.com/slides/it/net/aspose.slides/oleobjectframe).  
   Nel nostro esempio, abbiamo utilizzato il PPTX creato in precedenza che contiene una forma nella prima diapositiva. Abbiamo quindi *castato* quell’oggetto come [IOleObjectFrame](https://reference.aspose.com/slides/it/net/aspose.slides/ioleobjectframe). Questo era il frame OLE desiderato da accedere.
4. Una volta ottenuto il frame OLE, è possibile eseguire qualsiasi operazione su di esso.
5. Creare un oggetto `Workbook` e accedere ai dati OLE.
6. Accedere al `Worksheet` desiderato e modificare i dati.
7. Salvare il `Workbook` aggiornato in uno stream.
8. Modificare i dati dell’oggetto OLE dallo stream.

Nel seguente esempio, un frame OLE Object (un grafico Excel incorporato in una diapositiva) viene accessato e i suoi dati file vengono modificati per aggiornare i dati del grafico.

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

                // Cambia i dati dell'oggetto del frame OLE.
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.ToArray(), oleFrame.EmbeddedData.EmbeddedFileExtension);
                oleFrame.SetEmbeddedData(newData);
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Incorporare altri tipi di file nei diapositivi**

Oltre ai grafici Excel, Aspose.Slides per .NET consente di incorporare altri tipi di file nei diapositivi. Ad esempio, è possibile inserire file HTML, PDF e ZIP come oggetti. Quando l’utente fa doppio clic sull’oggetto inserito, questo si apre automaticamente nel programma pertinente, oppure viene chiesto di selezionare un programma appropriato per aprirlo.

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

Durante il lavoro con le presentazioni, potresti dover sostituire vecchi oggetti OLE con nuovi o sostituire un oggetto OLE non supportato con uno supportato. Aspose.Slides per .NET consente di impostare il tipo di file per un oggetto incorporato, permettendo di aggiornare i dati del frame OLE o la sua estensione.

Questo codice C# mostra come impostare il tipo di file per un oggetto OLE incorporato su `zip`:

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

Dopo aver incorporato un oggetto OLE, viene aggiunta automaticamente un’anteprima costituita da un’immagine icona. Quest’anteprima è ciò che gli utenti vedono prima di accedere o aprire l’oggetto OLE. Se desideri utilizzare un’immagine e un testo specifici come elementi dell’anteprima, puoi impostare l’immagine icona e il titolo tramite Aspose.Slides per .NET.

Questo codice C# mostra come impostare l’immagine icona e il titolo per un oggetto incorporato: 

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

## **Impedire il ridimensionamento e il riposizionamento del frame OLE Object**

Dopo aver aggiunto un oggetto OLE collegato a una diapositiva della presentazione, aprendo la presentazione in PowerPoint potresti vedere un messaggio che ti chiede di aggiornare i collegamenti. Cliccando sul pulsante “Update Links” il frame OLE potrebbe cambiare dimensione e posizione perché PowerPoint aggiorna i dati dall’oggetto OLE collegato e rinfresca l’anteprima dell’oggetto. Per evitare che PowerPoint chieda di aggiornare i dati dell’oggetto, imposta la proprietà `UpdateAutomatic` dell’interfaccia [IOleObjectFrame](https://reference.aspose.com/slides/it/net/aspose.slides/ioleobjectframe/) su `false`:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IOleObjectFrame oleFrame = (IOleObjectFrame)presentation.Slides[0].Shapes[0];

    // Mantieni la dimensione e la posizione del frame OLE quando PowerPoint aggiorna il collegamento.
    oleFrame.UpdateAutomatic = false;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Estrarre file incorporati**

Aspose.Slides per .NET consente di estrarre i file incorporati nei diapositivi come oggetti OLE in questo modo:
1. Creare un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) che contiene gli oggetti OLE da estrarre.
2. Scorrere tutte le forme nella presentazione e accedere alle forme [OLEObjectFrame](https://reference.aspose.com/slides/it/net/aspose.slides/oleobjectframe).
3. Accedere ai dati dei file incorporati dai frame OLE Object e scriverli su disco.

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

### Il contenuto OLE verrà renderizzato durante l’esportazione delle diapositive in PDF/immagini?

Viene renderizzata solo la parte visibile nella diapositiva—l’icona/immagine sostitutiva (anteprima). Il contenuto OLE “live” non viene eseguito durante il rendering. Se necessario, imposta una tua immagine di anteprima per garantire l’aspetto previsto nel PDF esportato.

### Come posso bloccare un oggetto OLE su una diapositiva in modo che gli utenti non possano spostarlo/modificarlo in PowerPoint?

Blocca la forma: Aspose.Slides fornisce [blocchi a livello di forma](/slides/it/net/applying-protection-to-presentation/). Non è crittografia, ma impedisce efficacemente modifiche e spostamenti accidentali.

### Perché un oggetto Excel collegato “salta” o cambia dimensione quando apro la presentazione?

PowerPoint potrebbe aggiornare l’anteprima dell’OLE collegato. Per un aspetto stabile, segui le pratiche della [Soluzione funzionante per il ridimensionamento del foglio di lavoro](/slides/it/net/working-solution-for-worksheet-resizing/)—adatta il frame all’intervallo o scala l’intervallo a un frame fisso e imposta un’immagine sostitutiva appropriata.

### I percorsi relativi per gli oggetti OLE collegati saranno conservati nel formato PPTX?

Nel PPTX le informazioni sui “percorsi relativi” non sono disponibili—solo il percorso completo. I percorsi relativi si trovano nel vecchio formato PPT. Per la portabilità, preferisci percorsi assoluti affidabili/URI accessibili o l’incorporamento.