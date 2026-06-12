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
description: "Ottimizza la gestione degli oggetti OLE in PowerPoint e nei file OpenDocument con Aspose.Slides per Android via Java. Incorpora, aggiorna ed esporta i contenuti OLE in modo fluido."
---
## **Introduzione**

{{% alert color="primary" %}} 
OLE (Object Linking & Embedding) è una tecnologia Microsoft che consente di collocare dati e oggetti creati in un'applicazione all'interno di un'altra applicazione tramite collegamento o incorporamento. 
{{% /alert %}} 

Considera un grafico creato in MS Excel. Il grafico viene poi inserito all'interno di una diapositiva PowerPoint. Tale grafico Excel è considerato un oggetto OLE. 

- Un oggetto OLE può apparire come icona. In questo caso, facendo doppio clic sull'icona, il grafico si apre nell'applicazione associata (Excel), oppure viene chiesto di selezionare un'applicazione per aprire o modificare l'oggetto. 
- Un oggetto OLE può visualizzare il proprio contenuto reale, ad esempio il contenuto di un grafico. In questo caso, il grafico viene attivato in PowerPoint, l'interfaccia del grafico si carica e puoi modificare i dati del grafico all'interno di PowerPoint.

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/it/androidjava/) consente di inserire oggetti OLE nelle diapositive come frame di oggetti OLE ([OleObjectFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/OleObjectFrame)).

## **Aggiungere frame di oggetti OLE alle diapositive**

Supponendo di aver già creato un grafico in Microsoft Excel e di volerlo incorporare in una diapositiva come frame di oggetto OLE usando Aspose.Slides for Android via Java, puoi procedere in questo modo:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation).  
1. Ottieni il riferimento di una diapositiva tramite il suo indice.  
1. Leggi il file Excel come array di byte.  
1. Aggiungi l'[OleObjectFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/OleObjectFrame) alla diapositiva contenente l'array di byte e le altre informazioni sull'oggetto OLE.  
1. Scrivi la presentazione modificata come file PPTX.  

Nell'esempio seguente, abbiamo aggiunto un grafico da un file Excel a una diapositiva come frame di oggetto OLE usando Aspose.Slides for Android via Java.  
**Nota** che il costruttore [OleEmbeddedDataInfo](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/OleEmbeddedDataInfo) accetta un'estensione di oggetto incorporabile come secondo parametro. Questa estensione consente a PowerPoint di interpretare correttamente il tipo di file e di scegliere l'applicazione giusta per aprire questo oggetto OLE.  

```java 
Presentation presentation = new Presentation();
SizeF slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Prepara i dati per l'oggetto OLE.
File file = new File("book.xlsx");
byte fileData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(fileData);

IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Aggiungi il frame dell'oggetto OLE alla diapositiva.
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Aggiungere frame di oggetti OLE collegati**

Aspose.Slides for Android via Java consente di aggiungere un [OleObjectFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/OleObjectFrame) senza incorporare dati, ma solo con un collegamento al file.  

Questo codice Java mostra come aggiungere un [OleObjectFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/OleObjectFrame) con un file Excel collegato a una diapositiva:  

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Aggiungi un frame di oggetto OLE con un file Excel collegato.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Accedere ai frame di oggetti OLE**

Se un oggetto OLE è già incorporato in una diapositiva, puoi facilmente trovarlo o accedervi in questo modo:

1. Carica una presentazione con l'oggetto OLE incorporato creando un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation).  
2. Ottieni il riferimento della diapositiva utilizzando il suo indice.  
3. Accedi alla forma [OleObjectFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/OleObjectFrame). Nel nostro esempio, abbiamo usato il PPTX creato in precedenza che ha una sola forma sulla prima diapositiva. Abbiamo quindi *castato* quell'oggetto come [IOleObjectFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ioleobjectframe/). Questo era il frame di oggetto OLE desiderato da accedere.  
4. Una volta che il frame dell'oggetto OLE è stato accesso, puoi eseguire qualsiasi operazione su di esso.  

Nell'esempio seguente, vengono acceduti un frame di oggetto OLE (un oggetto grafico Excel incorporato in una diapositiva) e i suoi dati file.  

```java 
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

Aspose.Slides consente di accedere alle proprietà del frame di oggetto OLE collegato.  

Questo codice Java mostra come verificare se un oggetto OLE è collegato e poi ottenere il percorso del file collegato:  

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

{{% alert color="primary" %}} 
In questa sezione, l'esempio di codice seguente utilizza [Aspose.Cells for Android via Java](/cells/androidjava/).  
{{% /alert %}} 

Se un oggetto OLE è già incorporato in una diapositiva, puoi facilmente accedere a quell'oggetto e modificarne i dati in questo modo:

1. Carica una presentazione con l'oggetto OLE incorporato creando un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation).  
2. Ottieni il riferimento della diapositiva tramite il suo indice.  
3. Accedi alla forma del frame dell'oggetto OLE. Nel nostro esempio, abbiamo usato il PPTX creato in precedenza che ha una forma sulla prima diapositiva. Abbiamo quindi *castato* quell'oggetto come [IOleObjectFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ioleobjectframe/). Questo era il frame di oggetto OLE desiderato da accedere.  
4. Una volta che il frame dell'oggetto OLE è stato accesso, puoi eseguire qualsiasi operazione su di esso.  
5. Crea un oggetto `Workbook` e accedi ai dati OLE.  
6. Accedi al `Worksheet` desiderato e modifica i dati.  
7. Salva il `Workbook` aggiornato in uno stream.  
8. Modifica i dati dell'oggetto OLE dallo stream.  

Nell'esempio seguente, viene accesso un frame di oggetto OLE (un oggetto grafico Excel incorporato in una diapositiva) e i suoi dati file vengono modificati per aggiornare i dati del grafico.  

```java 
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

Oltre ai grafici Excel, Aspose.Slides for Android via Java consente di incorporare altri tipi di file nelle diapositive. Ad esempio, è possibile inserire file HTML, PDF e ZIP come oggetti. Quando un utente fa doppio clic sull'oggetto inserito, questo si apre automaticamente nel programma pertinente, oppure viene chiesto all'utente di selezionare un programma appropriato per aprirlo.  

Questo codice Java mostra come incorporare HTML e ZIP in una diapositiva:  

```java
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

Quando si lavora con le presentazioni, potresti dover sostituire vecchi oggetti OLE con nuovi o sostituire un oggetto OLE non supportato con uno supportato. Aspose.Slides for Android via Java consente di impostare il tipo di file per un oggetto incorporato, permettendo di aggiornare i dati del frame OLE o la sua estensione.  

Questo codice Java mostra come impostare il tipo di file per un oggetto OLE incorporato su `zip`:  

```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

System.out.println("Current embedded file extension is: " + fileExtension);

// Modifica il tipo di file in ZIP.
oleFrame.setEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Impostare le immagini icona e i titoli per gli oggetti incorporati**

Dopo aver incorporato un oggetto OLE, viene aggiunta automaticamente un'anteprima composta da un'immagine icona. Questa anteprima è ciò che gli utenti vedono prima di accedere o aprire l'oggetto OLE. Se desideri utilizzare un'immagine e un testo specifici come elementi dell'anteprima, puoi impostare l'immagine icona e il titolo usando Aspose.Slides for Android via Java.  

Questo codice Java mostra come impostare l'immagine icona e il titolo per un oggetto incorporato:  

```java
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

## **Impedire il ridimensionamento e il riposizionamento di un frame di oggetto OLE**

Dopo aver aggiunto un oggetto OLE collegato a una diapositiva della presentazione, aprendo la presentazione in PowerPoint potresti vedere un messaggio che ti chiede di aggiornare i collegamenti. Cliccando sul pulsante "Update Links" la dimensione e la posizione del frame dell'oggetto OLE potrebbero cambiare perché PowerPoint aggiorna i dati dell'oggetto OLE collegato e rinfresca l'anteprima dell'oggetto. Per impedire a PowerPoint di chiedere l'aggiornamento dei dati dell'oggetto, imposta il metodo `setUpdateAutomatic` dell'interfaccia [IOleObjectFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ioleobjectframe/) su `false`:  

```java
oleFrame.setUpdateAutomatic(false);
```

## **Estrazione di file incorporati**

Aspose.Slides for Android via Java consente di estrarre i file incorporati nelle diapositive come oggetti OLE in questo modo:  

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation) che contiene gli oggetti OLE che intendi estrarre.  
2. Scorri tutte le forme nella presentazione e accedi alle forme [OLEObjectFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/oleobjectframe).  
3. Accedi ai dati dei file incorporati dai frame OLEObjectFrame e scrivili su disco.  

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

        FileOutputStream fos = new FileOutputStream(new File("OLE_object_" + index + fileExtension));
        fos.write(fileData);
        fos.close();
    }
}

presentation.dispose();
```

## **FAQ**

**Il contenuto OLE verrà renderizzato quando si esportano le diapositive in PDF/immagini?**  
Viene renderizzata solo la parte visibile nella diapositiva—l'icona/immagine di sostituzione (anteprima). Il contenuto OLE "live" non viene eseguito durante il rendering. Se necessario, imposta un'immagine di anteprima personalizzata per garantire l'aspetto atteso nel PDF esportato.

**Come posso bloccare un oggetto OLE su una diapositiva in modo che gli utenti non possano spostarlo/modificarlo in PowerPoint?**  
Blocca la forma: Aspose.Slides fornisce blocchi a livello di forma. Non è una crittografia, ma impedisce efficacemente modifiche accidentali e spostamenti.

**Perché un oggetto Excel collegato "salta" o cambia dimensione quando apro la presentazione?**  
PowerPoint può aggiornare l'anteprima dell'OLE collegato. Per un aspetto stabile, segui le pratiche della [Working Solution for Worksheet Resizing](/slides/it/androidjava/working-solution-for-worksheet-resizing/)—adatta il frame all'intervallo, oppure scala l'intervallo a un frame fisso e imposta un'immagine di sostituzione appropriata.

**I percorsi relativi per gli oggetti OLE collegati saranno preservati nel formato PPTX?**  
Nel PPTX le informazioni sul "percorso relativo" non sono disponibili—solo il percorso completo. I percorsi relativi si trovano nel formato PPT più vecchio. Per la portabilità, è preferibile usare percorsi assoluti affidabili/URI accessibili o incorporare.