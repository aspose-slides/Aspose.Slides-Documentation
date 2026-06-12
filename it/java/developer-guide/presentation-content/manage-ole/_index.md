---
title: Gestire OLE nelle presentazioni usando Java
linktitle: Gestire OLE
type: docs
weight: 40
url: /it/java/manage-ole/
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
- Java
- Aspose.Slides
description: "Ottimizza la gestione degli oggetti OLE in PowerPoint e nei file OpenDocument con Aspose.Slides per Java. Incorpora, aggiorna ed esporta i contenuti OLE senza problemi."
---
## **Introduzione**

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding) è una tecnologia Microsoft che consente di posizionare dati e oggetti creati in un’applicazione all’interno di un’altra applicazione mediante collegamento o incorporamento. 

{{% /alert %}} 

Considera un grafico creato in MS Excel. Il grafico viene poi inserito in una diapositiva PowerPoint. Quel grafico Excel è considerato un oggetto OLE. 

- Un oggetto OLE può apparire come un’icona. In questo caso, quando fai doppio clic sull’icona, il grafico viene aperto nella sua applicazione associata (Excel), oppure ti viene chiesto di selezionare un’applicazione per aprire o modificare l’oggetto. 
- Un oggetto OLE può visualizzare il suo contenuto reale, ad esempio il contenuto di un grafico. In questo caso, il grafico è attivato in PowerPoint, l’interfaccia del grafico viene caricata e puoi modificare i dati del grafico direttamente in PowerPoint.

[Aspose.Slides for Java](https://products.aspose.com/slides/it/java/) consente di inserire oggetti OLE nelle diapositive come frame di oggetti OLE ([OleObjectFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/OleObjectFrame)).

## **Aggiungere frame di oggetti OLE alle diapositive**

Supponendo di aver già creato un grafico in Microsoft Excel e di volerlo incorporare in una diapositiva come frame di oggetto OLE utilizzando Aspose.Slides for Java, è possibile procedere così:

1. Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).  
1. Ottieni il riferimento di una diapositiva tramite il suo indice.  
1. Leggi il file Excel come array di byte.  
1. Aggiungi il [OleObjectFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/OleObjectFrame) alla diapositiva includendo l’array di byte e le altre informazioni sull’oggetto OLE.  
1. Scrivi la presentazione modificata in un file PPTX.  

Nell’esempio seguente, abbiamo aggiunto un grafico da un file Excel a una diapositiva come frame di oggetto OLE usando Aspose.Slides for Java.  
**Nota** che il costruttore [OleEmbeddedDataInfo](https://reference.aspose.com/slides/it/java/com.aspose.slides/OleEmbeddedDataInfo) accetta un’estensione di oggetto incorporabile come secondo parametro. Questa estensione consente a PowerPoint di interpretare correttamente il tipo di file e di scegliere l’applicazione giusta per aprire l’oggetto OLE.

``` java 
Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Prepara i dati per l'oggetto OLE.
byte[] fileData = Files.readAllBytes(Paths.get("book.xlsx"));
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Aggiungi il frame dell'oggetto OLE alla diapositiva.
slide.getShapes().addOleObjectFrame(0, 0, (float)slideSize.getWidth(), (float)slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Aggiungere frame di oggetti OLE collegati**

Aspose.Slides for Java consente di aggiungere un [OleObjectFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/OleObjectFrame) senza incorporare dati, ma solo con un collegamento al file.

Questo codice Java mostra come aggiungere un [OleObjectFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/OleObjectFrame) con un file Excel collegato a una diapositiva:

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Aggiungi un frame di oggetto OLE con un file Excel collegato.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Accedere ai frame di oggetti OLE**

Se un oggetto OLE è già incorporato in una diapositiva, è possibile trovarlo o accedervi in questo modo:

1. Carica una presentazione con l’oggetto OLE incorporato creando un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).  
2. Ottieni il riferimento della diapositiva usando il suo indice.  
3. Accedi alla forma [OleObjectFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/OleObjectFrame).  
   Nel nostro esempio, abbiamo usato il PPTX creato in precedenza che contiene una sola forma nella prima diapositiva. Abbiamo poi *convertito* quell’oggetto a un [IOleObjectFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/IOleObjectFrame). Questo era il frame OLE desiderato da accedere.  
4. Una volta accesso il frame OLE, puoi eseguire qualsiasi operazione su di esso.  

Nell’esempio seguente, un frame di oggetto OLE (un oggetto grafico Excel incorporato in una diapositiva) e i dati del file vengono acceduti.

``` java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // Ottieni i dati del file incorporato.
    byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // Ottieni l'estensione del file incorporato.
    String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **Accedere alle proprietà del frame OLE collegato**

Aspose.Slides consente di accedere alle proprietà dei frame OLE collegati.

Questo codice Java mostra come verificare se un oggetto OLE è collegato e quindi ottenere il percorso del file collegato:

```java
Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // Verifica se l'oggetto OLE è collegato.
    if (oleFrame.isObjectLink()) {
        // Stampa il percorso completo del file collegato.
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // Stampa il percorso relativo del file collegato se presente.
        // Solo le presentazioni PPT possono contenere il percorso relativo.
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **Modificare i dati dell’oggetto OLE**

{{% alert color="primary" %}} 

In questa sezione, l’esempio di codice sotto utilizza [Aspose.Cells for Java](/cells/java/).

{{% /alert %}}

Se un oggetto OLE è già incorporato in una diapositiva, è possibile accedere a quell’oggetto e modificarne i dati in questo modo:

1. Carica una presentazione con l’oggetto OLE incorporato creando un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).  
2. Ottieni il riferimento della diapositiva tramite il suo indice.  
3. Accedi alla forma del frame OLE.  
   Nel nostro esempio, abbiamo usato il PPTX creato in precedenza che contiene una forma nella prima diapositiva. Abbiamo poi *convertito* quell’oggetto a un [IOleObjectFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/IOleObjectFrame). Questo era il frame OLE desiderato da accedere.  
4. Una volta accesso il frame OLE, puoi eseguire qualsiasi operazione su di esso.  
5. Crea un oggetto `Workbook` e accedi ai dati OLE.  
6. Accedi al `Worksheet` desiderato e modifica i dati.  
7. Salva il `Workbook` aggiornato in uno stream.  
8. Modifica i dati dell’oggetto OLE dallo stream.  

Nell’esempio seguente, un frame di oggetto OLE (un oggetto grafico Excel incorporato in una diapositiva) viene accesso e i suoi dati file vengono modificati per aggiornare i dati del grafico.

``` java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    ByteArrayInputStream oleStream = new ByteArrayInputStream(oleFrame.getEmbeddedData().getEmbeddedFileData());

    // Leggi i dati dell'oggetto OLE come oggetto Workbook.
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // Modifica i dati del workbook.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
    workbook.save(newOleStream, fileOptions);

    // Modifica i dati dell'oggetto del frame OLE.
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Incorporare altri tipi di file nelle diapositive**

Oltre ai grafici Excel, Aspose.Slides for Java consente di incorporare altri tipi di file nelle diapositive. Ad esempio, è possibile inserire file HTML, PDF e ZIP come oggetti. Quando l’utente fa doppio clic sull’oggetto inserito, questo si apre automaticamente nel programma pertinente, oppure all’utente viene chiesto di selezionare un programma appropriato per aprirlo.

Questo codice Java mostra come incorporare HTML e ZIP in una diapositiva:

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

byte[] htmlData = Files.readAllBytes(Paths.get("sample.html"));
IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
IOleObjectFrame htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

byte[] zipData = Files.readAllBytes(Paths.get("sample.zip"));
IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
IOleObjectFrame zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Impostare i tipi di file per gli oggetti incorporati**

Durante il lavoro con le presentazioni, potresti dover sostituire vecchi oggetti OLE con nuovi o sostituire un oggetto OLE non supportato con uno supportato. Aspose.Slides for Java consente di impostare il tipo di file per un oggetto incorporato, permettendo di aggiornare i dati del frame OLE o la sua estensione.

Questo codice Java mostra come impostare il tipo di file per un oggetto OLE incorporato su `zip`:

```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

System.out.println("Current embedded file extension is: " + fileExtension);

// Cambia il tipo di file in ZIP.
oleFrame.setEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Impostare immagini icona e titoli per gli oggetti incorporati**

Dopo aver incorporato un oggetto OLE, viene aggiunta automaticamente un’anteprima costituita da un’immagine icona. Questa anteprima è ciò che gli utenti vedono prima di accedere o aprire l’oggetto OLE. Se desideri usare un’immagine e un testo specifici come elementi dell’anteprima, puoi impostare l’immagine icona e il titolo tramite Aspose.Slides for Java.

Questo codice Java mostra come impostare l’immagine icona e il titolo per un oggetto incorporato:

```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// Aggiungi un'immagine alle risorse della presentazione.
byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
IPPImage oleImage = presentation.getImages().addImage(imageData);

// Imposta un titolo e l'immagine per l'anteprima OLE.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Impedire che un frame di oggetto OLE venga ridimensionato e riposizionato**

Dopo aver aggiunto un oggetto OLE collegato a una diapositiva, quando apri la presentazione in PowerPoint potresti vedere un messaggio che ti chiede di aggiornare i collegamenti. Cliccando sul pulsante “Update Links” l’aspetto e la posizione del frame OLE potrebbero cambiare perché PowerPoint aggiorna i dati dal collegamento OLE e raffresca l’anteprima dell’oggetto. Per impedire che PowerPoint chieda l’aggiornamento dei dati dell’oggetto, imposta il metodo `setUpdateAutomatic` dell’interfaccia [IOleObjectFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/ioleobjectframe/) a `false`:

```java
oleFrame.setUpdateAutomatic(false);
```

## **Estrarre file incorporati**

Aspose.Slides for Java consente di estrarre i file incorporati nelle diapositive come oggetti OLE in questo modo:

1. Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation) contenente gli oggetti OLE da estrarre.  
2. Scorri tutte le forme nella presentazione e accedi alle forme [OLEObjectFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/oleobjectframe).  
3. Accedi ai dati dei file incorporati dai frame OLE e scrivili su disco.  

Questo codice Java mostra come estrarre i file incorporati in una diapositiva come oggetti OLE:

```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);

for (int index = 0; index < slide.getShapes().size(); index++) {
    IShape shape = slide.getShapes().get_Item(index);

    if (shape instanceof IOleObjectFrame) {
        IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

        byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        Path filePath = Paths.get("OLE_object_" + index + fileExtension);
        Files.write(filePath, fileData);
    }
}

presentation.dispose();
```

## **FAQ**

**Il contenuto OLE verrà renderizzato quando le diapositive vengono esportate in PDF/immagini?**

Viene renderizzato ciò che è visibile nella diapositiva—l’icona/immagine sostitutiva (anteprima). Il contenuto OLE “live” non viene eseguito durante il rendering. Se necessario, imposta una tua immagine di anteprima per garantire l’aspetto previsto nel PDF esportato.

**Come posso bloccare un oggetto OLE su una diapositiva in modo che gli utenti non possano spostarlo/modificarlo in PowerPoint?**

Blocca la forma: Aspose.Slides fornisce [blocchi a livello di forma](/slides/it/java/applying-protection-to-presentation/). Non si tratta di crittografia, ma impedisce efficacemente modifiche o spostamenti accidentali.

**Perché un oggetto Excel collegato “salta” o cambia dimensione quando apro la presentazione?**

PowerPoint può aggiornare l’anteprima dell’OLE collegato. Per un aspetto stabile, segui le pratiche della [Soluzione funzionante per ridimensionamento del foglio di lavoro](/slides/it/java/working-solution-for-worksheet-resizing/)—adatta il frame all’intervallo o scala l’intervallo a un frame fisso e imposta un’immagine sostitutiva appropriata.

**I percorsi relativi per gli oggetti OLE collegati saranno preservati nel formato PPTX?**

Nel PPTX le informazioni sul “percorso relativo” non sono disponibili—solo il percorso completo. I percorsi relativi sono presenti nel vecchio formato PPT. Per la portabilità, preferisci percorsi assoluti affidabili/URI accessibili o l’incorporamento.