---
title: Gestire OLE nelle presentazioni usando Java
linktitle: Gestire OLE
type: docs
weight: 40
url: /it/java/manage-ole/
keywords:
- oggetto OLE
- Object Linking & Embedding
- aggiungi OLE
- incorpora OLE
- aggiungi oggetto
- incorpora oggetto
- aggiungi file
- incorpora file
- oggetto collegato
- file collegato
- cambia OLE
- icona OLE
- titolo OLE
- estrai OLE
- estrai oggetto
- estrai file
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Ottimizza la gestione degli oggetti OLE in file PowerPoint e OpenDocument con Aspose.Slides per Java. Incorporare, aggiornare ed esportare i contenuti OLE senza soluzione di continuità."
---
## **Introduzione**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) è una tecnologia Microsoft che consente di posizionare dati e oggetti creati in un'applicazione all'interno di un'altra applicazione tramite collegamento o incorporamento. 

{{% /alert %}} 

Considera un grafico creato in MS Excel. Il grafico viene quindi inserito in una diapositiva PowerPoint. Quel grafico Excel è considerato un oggetto OLE. 

- Un oggetto OLE può apparire come un'icona. In tal caso, facendo doppio clic sull'icona, il grafico si apre nell'applicazione associata (Excel) oppure viene richiesto di selezionare un'applicazione per aprire o modificare l'oggetto.  
- Un oggetto OLE può mostrare il contenuto reale, ad esempio il contenuto di un grafico. In questo caso, il grafico viene attivato in PowerPoint, l'interfaccia del grafico si carica e puoi modificare i dati del grafico all'interno di PowerPoint.  

[Aspose.Slides per Java](https://products.aspose.com/slides/java/) consente di inserire OLE Objects nelle diapositive come frame di oggetti OLE ([OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame)).

## **Aggiungere Frame di Oggetti OLE alle Diapositive**

Supponendo di aver già creato un grafico in Microsoft Excel e di volerlo incorporare in una diapositiva come frame di oggetto OLE usando Aspose.Slides per Java, è possibile procedere in questo modo:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).  
2. Ottieni un riferimento alla diapositiva tramite il suo indice.  
3. Leggi il file Excel come array di byte.  
4. Aggiungi il [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) alla diapositiva contenente l'array di byte e altre informazioni sull'oggetto OLE.  
5. Scrivi la presentazione modificata come file PPTX.  

Nell'esempio seguente abbiamo aggiunto un grafico da un file Excel a una diapositiva come frame di oggetto OLE usando Aspose.Slides per Java.  
**Nota** che il costruttore [OleEmbeddedDataInfo](https://reference.aspose.com/slides/java/com.aspose.slides/OleEmbeddedDataInfo) accetta come secondo parametro un'estensione di oggetto incorporabile. Questa estensione consente a PowerPoint di interpretare correttamente il tipo di file e scegliere l'applicazione giusta per aprire questo oggetto OLE.

``` java 
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.nio.file.Files;
import java.nio.file.Paths;

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

### **Aggiungere Frame OLE Collegati**

Aspose.Slides per Java consente di aggiungere un [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) senza incorporare i dati ma solo con un collegamento al file.

Questo codice Java mostra come aggiungere un [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) con un file Excel collegato a una diapositiva:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Aggiungi un frame di oggetto OLE con un file Excel collegato.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Accedere ai Frame di Oggetti OLE**

Se un oggetto OLE è già incorporato in una diapositiva, è possibile trovarlo o accedervi facilmente in questo modo:

1. Carica una presentazione con l'oggetto OLE incorporato creando un'istanza della classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).  
2. Ottieni il riferimento della diapositiva utilizzando il suo indice.  
3. Accedi alla forma [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame).  
   Nel nostro esempio, abbiamo usato il PPTX creato in precedenza che contiene una sola forma nella prima diapositiva. Abbiamo quindi *cast*ato quell'oggetto come un [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IOleObjectFrame). Questo era il frame OLE desiderato da accedere.  
4. Una volta che il frame OLE è stato accesso, è possibile eseguire qualsiasi operazione su di esso.  

Nell'esempio seguente viene acceduto un frame di oggetto OLE (un oggetto grafico Excel incorporato in una diapositiva) e i dati del suo file.

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

### **Accedere alle proprietà del frame OLE collegato**

Aspose.Slides consente di accedere alle proprietà del frame OLE collegato.

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

        // Stampa il percorso relativo del file collegato, se presente.
        // Solo le presentazioni PPT possono contenere il percorso relativo.
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **Modificare i dati dell'oggetto OLE**

{{% alert color="info" title="Note" %}}

In questa sezione, l'esempio di codice sottostante utilizza [Aspose.Cells for Java](https://docs.aspose.com/cells/java/).

{{% /alert %}}

Se un oggetto OLE è già incorporato in una diapositiva, è possibile accedere a quell'oggetto e modificarne i dati in questo modo:

1. Carica una presentazione con l'oggetto OLE incorporato creando un'istanza della classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).  
2. Ottieni il riferimento della diapositiva tramite il suo indice.  
3. Accedi alla forma del frame OLE.  
   Nel nostro esempio, abbiamo usato il PPTX creato in precedenza che contiene una forma nella prima diapositiva. Abbiamo quindi *cast*ato quell'oggetto come un [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IOleObjectFrame). Questo era il frame OLE desiderato da accedere.  
4. Una volta che il frame OLE è stato accesso, è possibile eseguire qualsiasi operazione su di esso.  
5. Crea un oggetto `Workbook` e accedi ai dati OLE.  
6. Accedi al `Worksheet` desiderato e modifica i dati.  
7. Salva il `Workbook` aggiornato in uno stream.  
8. Modifica i dati dell'oggetto OLE dallo stream.  

Nell'esempio seguente, un frame di oggetto OLE (un oggetto grafico Excel incorporato in una diapositiva) viene accesso e i dati del suo file vengono modificati per aggiornare i dati del grafico.

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

    // Modifica i dati dell'oggetto frame OLE.
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Incorporare altri tipi di file nelle diapositive**

Oltre ai grafici Excel, Aspose.Slides per Java consente di incorporare altri tipi di file nelle diapositive. Ad esempio, è possibile inserire file HTML, PDF e ZIP come oggetti. Quando l'utente fa doppio clic sull'oggetto inserito, questo si apre automaticamente nel programma pertinente, oppure all'utente viene chiesto di selezionare un programma appropriato per aprirlo.

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

## **Impostare i tipi di file per gli oggetti incorporati**

Quando si lavora con le presentazioni, potrebbe essere necessario sostituire vecchi oggetti OLE con nuovi o sostituire un oggetto OLE non supportato con uno supportato. Aspose.Slides per Java consente di impostare il tipo di file per un oggetto incorporato, permettendo di aggiornare i dati del frame OLE o la sua estensione.

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

## **Impostare le immagini dell'icona e i titoli per gli oggetti incorporati**

Dopo aver incorporato un oggetto OLE, viene aggiunta automaticamente un'anteprima costituita da un'immagine icona. Questa anteprima è ciò che gli utenti vedono prima di accedere o aprire l'oggetto OLE. Se desideri utilizzare un'immagine e un testo specifici come elementi dell'anteprima, puoi impostare l'immagine icona e il titolo usando Aspose.Slides per Java.

Questo codice Java mostra come impostare l'immagine icona e il titolo per un oggetto incorporato:

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

// Set a title and the image for the OLE preview.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Impedire che un frame di oggetto OLE venga ridimensionato e riposizionato**

Dopo aver aggiunto un oggetto OLE collegato a una diapositiva di presentazione, aprendo la presentazione in PowerPoint potrebbe comparire un messaggio che richiede di aggiornare i collegamenti. Cliccando sul pulsante "Update Links" le dimensioni e la posizione del frame OLE potrebbero cambiare perché PowerPoint aggiorna i dati dall'oggetto OLE collegato e aggiorna l'anteprima dell'oggetto. Per impedire a PowerPoint di richiedere l'aggiornamento dei dati dell'oggetto, chiama il metodo [setUpdateAutomatic](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#setUpdateAutomatic-boolean-) dell'interfaccia [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/) con `false`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

oleFrame.setUpdateAutomatic(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Estrarre i file incorporati**

Aspose.Slides per Java consente di estrarre i file incorporati nelle diapositive come oggetti OLE in questo modo:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) contenente gli oggetti OLE da estrarre.  
2. Scorri tutte le forme della presentazione e accedi alle forme [OLEObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/oleobjectframe).  
3. Accedi ai dati dei file incorporati dai frame OLE e scrivili su disco.  

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

**Il contenuto OLE verrà renderizzato esportando le diapositive in PDF/immagini?**

Ciò che è visibile nella diapositiva viene renderizzato—l'icona/immagine sostitutiva (anteprima). Il contenuto OLE "live" non viene eseguito durante il rendering. Se necessario, imposta un'immagine di anteprima personalizzata per assicurare l'aspetto previsto nel PDF esportato.

Per conservare anche il file incorporato come allegato PDF, chiama [setIncludeOleData](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) con `true`. Questa opzione è disabilitata per impostazione predefinita. Per un esempio e le istruzioni su come verificare l'allegato, vedi [Conservare i file OLE incorporati come allegati PDF](/slides/it/java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Come posso bloccare un oggetto OLE su una diapositiva così che gli utenti non possano spostarlo/modificarlo in PowerPoint?**

Blocca la forma: Aspose.Slides fornisce [blocchi a livello di forma](/slides/it/java/applying-protection-to-presentation/). Questo non è una crittografia, ma impedisce efficacemente modifiche accidentali e spostamenti.

**Perché un oggetto Excel collegato "salta" o cambia dimensione quando apro la presentazione?**

PowerPoint potrebbe aggiornare l'anteprima dell'OLE collegato. Per un aspetto stabile, segui le pratiche della [Soluzione operativa per il ridimensionamento del foglio di lavoro](/slides/it/java/working-solution-for-worksheet-resizing/)—adatta il frame all'intervallo oppure scala l'intervallo a un frame fisso e imposta un'immagine sostitutiva appropriata.

**I percorsi relativi per gli oggetti OLE collegati saranno preservati nel formato PPTX?**

Nel PPTX le informazioni sul "percorso relativo" non sono disponibili—solo il percorso completo. I percorsi relativi sono presenti nel formato PPT più vecchio. Per la portabilità, preferisci percorsi assoluti affidabili/URI accessibili o l'incorporamento.