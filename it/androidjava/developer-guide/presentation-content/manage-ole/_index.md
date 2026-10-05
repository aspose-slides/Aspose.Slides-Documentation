---
title: Gestire OLE nelle presentazioni su Android
linktitle: Gestire OLE
type: docs
weight: 40
url: /it/androidjava/manage-ole/
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
- Android
- Java
- Aspose.Slides
description: "Ottimizza la gestione degli oggetti OLE in file PowerPoint e OpenDocument con Aspose.Slides per Android via Java. Incorpora, aggiorna ed esporta i contenuti OLE senza problemi."
---
## **Introduzione**

{{% alert color="info" title="Nota" %}}

OLE (Object Linking & Embedding) è una tecnologia Microsoft che consente di posizionare dati e oggetti creati in un'applicazione all'interno di un'altra applicazione tramite collegamento o incorporamento. 

{{% /alert %}} 

Considera un grafico creato in MS Excel. Il grafico viene poi inserito in una diapositiva di PowerPoint. Quel grafico Excel è considerato un oggetto OLE. 

- Un oggetto OLE può apparire come icona. In questo caso, quando fai doppio clic sull'icona, il grafico si apre nell'applicazione associata (Excel) oppure ti viene chiesto di selezionare un'applicazione per aprire o modificare l'oggetto.
- Un oggetto OLE può visualizzare il contenuto reale, ad esempio il contenuto di un grafico. In questo caso, il grafico viene attivato in PowerPoint, l'interfaccia del grafico si carica e puoi modificare i dati del grafico direttamente in PowerPoint.

[Aspose.Slides per Android via Java](https://products.aspose.com/slides/androidjava/) consente di inserire oggetti OLE nelle diapositive come frame di oggetti OLE ([OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame)).

## **Aggiungere frame di oggetti OLE alle diapositive**

Supponendo di aver già creato un grafico in Microsoft Excel e di volerlo incorporare in una diapositiva come frame di oggetto OLE usando Aspose.Slides per Android via Java, è possibile farlo in questo modo:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Ottenere il riferimento di una diapositiva tramite il suo indice.
1. Leggere il file Excel come array di byte.
1. Aggiungere il [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) alla diapositiva contenente l'array di byte e le altre informazioni sull'oggetto OLE.
1. Scrivere la presentazione modificata come file PPTX.

Nell'esempio seguente, abbiamo aggiunto un grafico da un file Excel a una diapositiva come frame di oggetto OLE usando Aspose.Slides per Android via Java.  
**Nota** che il costruttore [OleEmbeddedDataInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleEmbeddedDataInfo) accetta un'estensione di oggetto incorporabile come secondo parametro. Questa estensione consente a PowerPoint di interpretare correttamente il tipo di file e scegliere l'applicazione corretta per aprire questo oggetto OLE.

```java
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Preparare i dati per l'oggetto OLE.
File file = new File("book.xlsx");
byte fileData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(fileData);

IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Aggiungere il frame dell'oggetto OLE alla diapositiva.
slide.getShapes().addOleObjectFrame(0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Aggiungere frame di oggetti OLE collegati**

Aspose.Slides per Android via Java consente di aggiungere un [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) senza incorporare dati, ma solo con un collegamento al file.

Questo codice Java mostra come aggiungere un [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) con un file Excel collegato a una diapositiva:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Aggiungi un frame di oggetto OLE con un file Excel collegato.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Accedere ai frame di oggetti OLE**

Se un oggetto OLE è già incorporato in una diapositiva, è possibile trovarlo o accedervi facilmente in questo modo:

1. Caricare una presentazione con l'oggetto OLE incorporato creando un'istanza della classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Ottenere il riferimento della diapositiva usando il suo indice.
3. Accedere alla forma [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame).  
   Nel nostro esempio, abbiamo usato il PPTX creato in precedenza che ha una sola forma nella prima diapositiva. Abbiamo poi *cast* quell'oggetto come un [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/). Questo era il frame di oggetto OLE desiderato da accedere.
4. Una volta che il frame di oggetto OLE è stato accesso, è possibile eseguire qualsiasi operazione su di esso.

Nell'esempio seguente, vengono acceduti un frame di oggetto OLE (un grafico Excel incorporato in una diapositiva) e i dati del file associato.

```java
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

### **Accedere alle proprietà del frame di oggetto OLE collegato**

Aspose.Slides consente di accedere alle proprietà dei frame di oggetti OLE collegati.

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

{{% alert color="info" title="Nota" %}}

In questa sezione, l'esempio di codice qui sotto utilizza [Aspose.Cells per Android via Java](https://docs.aspose.com/cells/androidjava/).

{{% /alert %}}

Se un oggetto OLE è già incorporato in una diapositiva, è possibile accedere a quell'oggetto e modificarne i dati in questo modo:

1. Caricare una presentazione con l'oggetto OLE incorporato creando un'istanza della classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Ottenere il riferimento della diapositiva tramite il suo indice. 
3. Accedere alla forma del frame di oggetto OLE.  
   Nel nostro esempio, abbiamo usato il PPTX creato in precedenza che ha una forma nella prima diapositiva. Abbiamo poi *cast* quell'oggetto come un [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/). Questo era il frame di oggetto OLE desiderato da accedere.
4. Una volta che il frame di oggetto OLE è stato accesso, è possibile eseguire qualsiasi operazione su di esso.
5. Creare un oggetto `Workbook` e accedere ai dati OLE.
6. Accedere al `Worksheet` desiderato e modificare i dati.
7. Salvare il `Workbook` aggiornato in uno stream.
8. Modificare i dati dell'oggetto OLE dallo stream.

Nell'esempio seguente, un frame di oggetto OLE (un grafico Excel incorporato in una diapositiva) viene accesso e i suoi dati di file vengono modificati per aggiornare i dati del grafico.

```java
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

    // Cambia i dati dell'oggetto del frame OLE.
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Incorporare altri tipi di file nelle diapositive**

Oltre ai grafici Excel, Aspose.Slides per Android via Java consente di incorporare altri tipi di file nelle diapositive. Ad esempio, è possibile inserire file HTML, PDF e ZIP come oggetti. Quando l'utente fa doppio clic sull'oggetto inserito, questo si apre automaticamente nel programma pertinente, oppure viene chiesto di selezionare un programma appropriato per aprirlo.

Questo codice Java mostra come incorporare HTML e ZIP in una diapositiva:

```java
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

File fileHtml = new File("sample.html");
byte htmlData[] = new byte[(int) fileHtml.length()];
BufferedInputStream bisHtml = new BufferedInputStream(new FileInputStream(fileHtml));
DataInputStream disHtml = new DataInputStream(bisHtml);
disHtml.readFully(htmlData);
IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
IOleObjectFrame htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

File fileZip = new File("sample.zip");
byte zipData[] = new byte[(int) fileZip.length()];
BufferedInputStream bisZip = new BufferedInputStream(new FileInputStream(fileZip));
DataInputStream disZip = new DataInputStream(bisZip);
disZip.readFully(zipData);
IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
IOleObjectFrame zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Impostare i tipi di file per gli oggetti incorporati**

Durante il lavoro con le presentazioni, potresti dover sostituire vecchi oggetti OLE con nuovi o sostituire un oggetto OLE non supportato con uno supportato. Aspose.Slides per Android via Java consente di impostare il tipo di file per un oggetto incorporato, permettendo di aggiornare i dati del frame OLE o la sua estensione.

Questo codice Java mostra come impostare il tipo di file per un oggetto OLE incorporato su `zip`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

System.out.println("Current embedded file extension is: " + fileExtension);

// Cambia il tipo di file a ZIP.
oleFrame.setEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Impostare immagini icona e titoli per gli oggetti incorporati**

Dopo aver incorporato un oggetto OLE, viene aggiunta automaticamente un'anteprima costituita da un'immagine icona. Questa anteprima è ciò che gli utenti vedono prima di accedere o aprire l'oggetto OLE. Se desideri utilizzare un'immagine e un testo specifici come elementi dell'anteprima, puoi impostare l'immagine icona e il titolo utilizzando Aspose.Slides per Android via Java.

Questo codice Java mostra come impostare l'immagine icona e il titolo per un oggetto incorporato:

```java
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// Aggiungi un'immagine alle risorse della presentazione.
File file = new File("image.png");
byte imageData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(imageData);
IPPImage oleImage = presentation.getImages().addImage(imageData);

// Imposta un titolo e l'immagine per l'anteprima OLE.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Impedire il ridimensionamento e lo spostamento di un frame di oggetto OLE**

Dopo aver aggiunto un oggetto OLE collegato a una diapositiva della presentazione, aprendo la presentazione in PowerPoint potresti vedere un messaggio che ti chiede di aggiornare i collegamenti. Cliccando sul pulsante "Aggiorna collegamenti" PowerPoint potrebbe modificare la dimensione e la posizione del frame dell'oggetto OLE perché aggiorna i dati dall'oggetto OLE collegato e aggiorna l'anteprima dell'oggetto. Per impedire a PowerPoint di chiedere l'aggiornamento dei dati dell'oggetto, chiama il metodo [setUpdateAutomatic](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#setUpdateAutomatic-boolean-) dell'interfaccia [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/) con `false`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    oleFrame.setUpdateAutomatic(false);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Estrarre file incorporati**

Aspose.Slides per Android via Java consente di estrarre i file incorporati nelle diapositive come oggetti OLE in questo modo:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) contenente gli oggetti OLE da estrarre.
2. Scorrere tutte le forme nella presentazione e accedere alle forme [OLEObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/oleobjectframe).
3. Accedere ai dati dei file incorporati dai frame di oggetti OLE e scriverli su disco.

Questo codice Java mostra come estrarre i file incorporati in una diapositiva come oggetti OLE:

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);

for (int index = 0; index < slide.getShapes().size(); index++) {
    IShape shape = slide.getShapes().get_Item(index);

    if (shape instanceof IOleObjectFrame) {
        IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

        byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        FileOutputStream fos = new FileOutputStream(new File("OLE_object_" + index + fileExtension));
        fos.write(fileData);
        fos.close();
    }
}

presentation.dispose();
```

## **FAQ**

**Il contenuto OLE verrà renderizzato durante l'esportazione delle diapositive in PDF/immagini?**

Viene renderizzata la parte visibile della diapositiva—l'icona/immagine di sostituzione (anteprima). Il contenuto OLE "live" non viene eseguito durante il rendering. Se necessario, imposta la tua immagine di anteprima per garantire l'aspetto previsto nel PDF esportato.

Per preservare anche il file incorporato come allegato PDF, chiama [setIncludeOleData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) con `true`. Questa opzione è disabilitata per impostazione predefinita. Per un esempio e istruzioni su come verificare l'allegato, vedi [Preserve Embedded OLE Files as PDF Attachments](/slides/it/androidjava/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Come posso bloccare un oggetto OLE su una diapositiva in modo che gli utenti non possano spostarlo/modificarlo in PowerPoint?**

Blocca la forma: Aspose.Slides fornisce blocchi a livello di forma. Non è crittografia, ma impedisce efficacemente modifiche accidentali e spostamenti.

**Perché un oggetto Excel collegato "salta" o cambia dimensione quando apro la presentazione?**

PowerPoint potrebbe aggiornare l'anteprima dell'OLE collegato. Per un aspetto stabile, segui le pratiche della [Working Solution for Worksheet Resizing](/slides/it/androidjava/working-solution-for-worksheet-resizing/)—adatta il frame all'intervallo, oppure scala l'intervallo a un frame fisso e imposta un'immagine di sostituzione adeguata.

**I percorsi relativi per gli oggetti OLE collegati saranno conservati nel formato PPTX?**

Nel PPTX le informazioni sul "percorso relativo" non sono disponibili—solo il percorso completo. I percorsi relativi sono presenti nel vecchio formato PPT. Per la portabilità, preferisci percorsi assoluti affidabili/URI accessibili o l'incorporamento.