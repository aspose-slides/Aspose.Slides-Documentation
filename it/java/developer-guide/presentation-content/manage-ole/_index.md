---
title: Gestire OLE nelle presentazioni con Java
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

{{% alert color="info" %}} 

OLE (Object Linking & Embedding) è una tecnologia Microsoft che consente di posizionare dati e oggetti creati in un’applicazione all’interno di un’altra applicazione mediante collegamento o incorporamento. 

{{% /alert %}} 

Considera un grafico creato in MS Excel. Il grafico viene poi inserito in una diapositiva di PowerPoint. Quel grafico Excel è considerato un oggetto OLE. 

- Un oggetto OLE può apparire come icona. In questo caso, facendo doppio clic sull’icona, il grafico si apre nella relativa applicazione (Excel), oppure viene chiesto di selezionare un’applicazione per l’apertura o la modifica dell’oggetto. 
- Un oggetto OLE può visualizzare i propri contenuti reali, ad esempio i dati di un grafico. In questo caso, il grafico è attivato in PowerPoint, l’interfaccia del grafico viene caricata e puoi modificare i dati del grafico direttamente in PowerPoint.

[Aspose.Slides for Java](https://products.aspose.com/slides/it/java/) consente di inserire oggetti OLE nelle diapositive come fotogrammi di oggetti OLE ([OleObjectFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/OleObjectFrame)).

## **Aggiungere fotogrammi di oggetti OLE alle diapositive**

Supponendo di aver già creato un grafico in Microsoft Excel e di volerlo incorporare in una diapositiva come fotogramma di oggetto OLE usando Aspose.Slides for Java, è possibile farlo in questo modo:

1. Creare un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).  
1. Ottenere il riferimento a una diapositiva tramite il suo indice.  
1. Leggere il file Excel come array di byte.  
1. Aggiungere il [OleObjectFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/OleObjectFrame) alla diapositiva contenente l’array di byte e le altre informazioni sull’oggetto OLE.  
1. Scrivere la presentazione modificata come file PPTX.  

Nell’esempio seguente, abbiamo aggiunto un grafico da un file Excel a una diapositiva come fotogramma di oggetto OLE usando Aspose.Slides for Java.  
**Nota**: il costruttore [OleEmbeddedDataInfo](https://reference.aspose.com/slides/it/java/com.aspose.slides/OleEmbeddedDataInfo) accetta un’estensione di oggetto incorporabile come secondo parametro. Questa estensione consente a PowerPoint di interpretare correttamente il tipo di file e di scegliere l’applicazione giusta per aprire l’oggetto OLE.

``` java 
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Prepare data for the OLE object.
byte[] fileData = Files.readAllBytes(Paths.get("book.xlsx"));
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, (float)slideSize.getWidth(), (float)slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Aggiungere fotogrammi di oggetti OLE collegati**

Aspose.Slides for Java consente di aggiungere un [OleObjectFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/OleObjectFrame) senza incorporare i dati, ma solo con un collegamento al file.

Questo codice Java mostra come aggiungere un [OleObjectFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/OleObjectFrame) con un file Excel collegato a una diapositiva:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Aggiungi un fotogramma di oggetto OLE con un file Excel collegato.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Accedere ai fotogrammi di oggetti OLE**

Se un oggetto OLE è già incorporato in una diapositiva, è possibile trovarlo o accedervi facilmente in questo modo:

1. Caricare una presentazione con l’oggetto OLE incorporato creando un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).  
2. Ottenere il riferimento alla diapositiva usando il suo indice.  
3. Accedere alla forma [OleObjectFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/OleObjectFrame).  
   Nel nostro esempio, abbiamo utilizzato il PPTX creato in precedenza che contiene una sola forma nella prima diapositiva. Abbiamo quindi *castato* quell’oggetto come [IOleObjectFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/IOleObjectFrame). Questo era il fotogramma OLE desiderato da accedere.  
4. Una volta acceso al fotogramma OLE, è possibile eseguire qualsiasi operazione su di esso.  

Nell’esempio seguente, viene mostrato l’accesso a un fotogramma di oggetto OLE (un oggetto grafico Excel incorporato in una diapositiva) e ai dati del file.

``` java 
import com.aspose.slides.*;

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

### **Accedere alle proprietà dei fotogrammi OLE collegati**

Aspose.Slides consente di accedere alle proprietà dei fotogrammi OLE collegati.

Questo codice Java mostra come verificare se un oggetto OLE è collegato e quindi ottenere il percorso del file collegato:

```java
import com.aspose.slides.*;

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

## **Modificare i dati di un oggetto OLE**

{{% alert color="info" %}} 

In questa sezione, l’esempio di codice utilizza [Aspose.Cells for Java](/cells/java/).  

{{% /alert %}}

Se un oggetto OLE è già incorporato in una diapositiva, è possibile accedere a quell’oggetto e modificare i suoi dati in questo modo:

1. Caricare una presentazione con l’oggetto OLE incorporato creando un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).  
2. Ottenere il riferimento alla diapositiva tramite il suo indice.  
3. Accedere alla forma del fotogramma OLE.  
   Nel nostro esempio, abbiamo usato il PPTX creato in precedenza che contiene una forma nella prima diapositiva. Abbiamo quindi *castato* quell’oggetto come [IOleObjectFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/IOleObjectFrame). Questo era il fotogramma OLE desiderato da accedere.  
4. Una volta acceso al fotogramma OLE, è possibile eseguire qualsiasi operazione su di esso.  
5. Creare un oggetto `Workbook` e accedere ai dati OLE.  
6. Accedere al `Worksheet` desiderato e modificare i dati.  
7. Salvare il `Workbook` aggiornato in uno stream.  
8. Modificare i dati dell’oggetto OLE dallo stream.  

Nell’esempio seguente, viene mostrato l’accesso a un fotogramma di oggetto OLE (un oggetto grafico Excel incorporato in una diapositiva) e la modifica dei dati del file per aggiornare i dati del grafico.

``` java 
import com.aspose.slides.*;
import com.aspose.cells.Workbook;
import com.aspose.cells.OoxmlSaveOptions;
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;

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

    // Modifica i dati dell'oggetto OLE del fotogramma.
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Incorporare altri tipi di file nelle diapositive**

Oltre ai grafici Excel, Aspose.Slides for Java consente di incorporare altri tipi di file nelle diapositive. Ad esempio, è possibile inserire file HTML, PDF e ZIP come oggetti. Quando l’utente fa doppio clic sull’oggetto inserito, questo si apre automaticamente nel programma pertinente, oppure viene chiesto di selezionare un programma appropriato per aprirlo.

Questo codice Java mostra come incorporare HTML e ZIP in una diapositiva:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

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

## **Impostare il tipo di file per gli oggetti incorporati**

Durante la gestione delle presentazioni, potrebbe essere necessario sostituire vecchi oggetti OLE con nuovi o sostituire un oggetto OLE non supportato con uno supportato. Aspose.Slides for Java consente di impostare il tipo di file per un oggetto incorporato, permettendo di aggiornare i dati del fotogramma OLE o la sua estensione.

Questo codice Java mostra come impostare il tipo di file per un oggetto OLE incorporato su `zip`:

```java
import com.aspose.slides.*;

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

## **Impostare l’immagine dell’icona e il titolo per gli oggetti incorporati**

Dopo aver incorporato un oggetto OLE, viene aggiunta automaticamente un’anteprima costituita da un’immagine icona. Questa anteprima è ciò che gli utenti vedono prima di accedere o aprire l’oggetto OLE. Se si desidera utilizzare un’immagine e un testo specifici come elementi dell’anteprima, è possibile impostare l’immagine icona e il titolo tramite Aspose.Slides for Java.

Questo codice Java mostra come impostare l’immagine icona e il titolo per un oggetto incorporato:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

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

## **Impedire il ridimensionamento e il riposizionamento di un fotogramma OLE**

Dopo aver aggiunto un oggetto OLE collegato a una diapositiva, all’apertura della presentazione in PowerPoint potrebbe apparire un messaggio che richiede l’aggiornamento dei collegamenti. Cliccando sul pulsante “Update Links” si potrebbe modificare le dimensioni e la posizione del fotogramma OLE perché PowerPoint aggiorna i dati dall’oggetto collegato e aggiorna l’anteprima. Per evitare che PowerPoint chieda l’aggiornamento dei dati dell’oggetto, impostare il metodo `setUpdateAutomatic` dell’interfaccia [IOleObjectFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/ioleobjectframe/) su `false`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

oleFrame.setUpdateAutomatic(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Estrarre file incorporati**

Aspose.Slides for Java consente di estrarre i file incorporati nelle diapositive come oggetti OLE in questo modo:

1. Creare un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation) contenente gli oggetti OLE da estrarre.  
2. Scorrere tutte le forme nella presentazione e accedere alle forme [OLEObjectFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/oleobjectframe).  
3. Accedere ai dati dei file incorporati dai fotogrammi OLE e scriverli su disco.  

Questo codice Java mostra come estrarre i file incorporati in una diapositiva come oggetti OLE:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

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

### Il contenuto OLE verrà renderizzato quando le diapositive vengono esportate in PDF/immagini?

Viene renderizzata la parte visibile della diapositiva — l’icona/immagine di anteprima. Il contenuto OLE “live” non viene eseguito durante il rendering. Se necessario, impostare un’immagine di anteprima personalizzata per garantire l’aspetto previsto nel PDF esportato.

### Come posso bloccare un oggetto OLE su una diapositiva in modo che gli utenti non possano spostarlo/modificarlo in PowerPoint?

Bloccare la forma: Aspose.Slides fornisce [blocchi a livello di forma](/slides/it/java/applying-protection-to-presentation/). Non si tratta di crittografia, ma impedisce efficacemente modifiche e spostamenti accidentali.

### Perché un oggetto Excel collegato “salta” o cambia dimensione quando apro la presentazione?

PowerPoint potrebbe aggiornare l’anteprima dell’OGgetto OLE collegato. Per un aspetto stabile, seguire le pratiche descritte nella [Soluzione operativa per il ridimensionamento del foglio di lavoro](/slides/it/java/working-solution-for-worksheet-resizing/): adattare il fotogramma all’intervallo oppure scalare l’intervallo a un fotogramma fisso e impostare un’immagine sostitutiva adeguata.

### I percorsi relativi per gli oggetti OLE collegati vengono conservati nel formato PPTX?

Nel PPTX le informazioni sui “percorsi relativi” non sono disponibili — è memorizzato solo il percorso completo. I percorsi relativi sono presenti nel vecchio formato PPT. Per la portabilità, preferire percorsi assoluti affidabili/URI accessibili o l’incorporamento.