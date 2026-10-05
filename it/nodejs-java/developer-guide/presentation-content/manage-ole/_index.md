---
title: Gestisci OLE nelle presentazioni usando JavaScript
linktitle: Gestisci OLE
type: docs
weight: 40
url: /it/nodejs-java/manage-ole/
keywords:
- oggetto OLE
- collegamento e incorporamento di oggetti
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Ottimizza la gestione degli oggetti OLE in PowerPoint e nei file OpenDocument con Aspose.Slides per Node.js via Java. Incorpora, aggiorna ed esporta i contenuti OLE in modo fluido."
---
## **Introduzione**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) è una tecnologia Microsoft che consente di posizionare dati e oggetti creati in un'applicazione all'interno di un'altra applicazione tramite collegamento o incorporamento. 

{{% /alert %}} 

Considera un grafico creato in MS Excel. Il grafico viene quindi inserito in una diapositiva PowerPoint. Quel grafico Excel è considerato un oggetto OLE. 

- Un oggetto OLE può apparire come icona. In questo caso, facendo doppio clic sull'icona, il grafico viene aperto nell'applicazione associata (Excel), oppure ti viene chiesto di selezionare un'applicazione per aprire o modificare l'oggetto.
- Un oggetto OLE può mostrare i suoi contenuti reali, come il contenuto di un grafico. In questo caso, il grafico viene attivato in PowerPoint, l'interfaccia del grafico si carica e puoi modificare i dati del grafico direttamente in PowerPoint.

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/nodejs-java/) consente di inserire OLE Object nei diapositivi come frame OLE Object ([OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame)).

## **Aggiunta di OLE Object Frame alle Diapositive**

Supponendo che tu abbia già creato un grafico in Microsoft Excel e desideri incorporarlo in una diapositiva come frame OLE Object utilizzando Aspose.Slides for Node.js via Java, puoi farlo in questo modo:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) .
1. Ottieni il riferimento a una diapositiva tramite il suo indice.
1. Leggi il file Excel come array di byte.
1. Aggiungi il [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) alla diapositiva contenente l'array di byte e altre informazioni sull'oggetto OLE.
1. Scrivi la presentazione modificata come file PPTX.

Nell'esempio sottostante, abbiamo aggiunto un grafico da un file Excel a una diapositiva come frame OLE Object utilizzando Aspose.Slides for Node.js via Java.
**Nota** che il costruttore [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleEmbeddedDataInfo) accetta un'estensione di oggetto incorporabile come secondo parametro. Questa estensione consente a PowerPoint di interpretare correttamente il tipo di file e scegliere l'applicazione giusta per aprire questo oggetto OLE.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

var presentation = new asposeSlides.Presentation();
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(0);

// Prepare data for the OLE object.
var oleStream = fs.readFileSync("book.xlsx");
var fileData = Array.from(oleStream);
var dataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", fileData), "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

### **Aggiunta di OLE Object Frame Collegati**

Aspose.Slides for Node.js via Java consente di aggiungere un [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) senza incorporare i dati, ma solo con un collegamento al file.

Questo codice JavaScript mostra come aggiungere un [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) con un file Excel collegato a una diapositiva:

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

// Aggiungi un frame OLE object con un file Excel collegato.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Accesso ai OLE Object Frame**

Se un oggetto OLE è già incorporato in una diapositiva, puoi trovarlo o accedervi facilmente in questo modo:

1. Carica una presentazione con l'oggetto OLE incorporato creando un'istanza della classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) .
2. Ottieni il riferimento della diapositiva utilizzando il suo indice.
3. Accedi alla forma [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame). Nel nostro esempio, abbiamo usato il PPTX precedentemente creato che ha una sola forma nella prima diapositiva.
4. Una volta acceduto al frame OLE Object, puoi eseguire qualsiasi operazione su di esso.

Nell'esempio sottostante, un frame OLE Object (un oggetto grafico Excel incorporato in una diapositiva) e i suoi dati file vengono accessi.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;
    
    // Ottieni i dati del file incorporato.
    var fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // Ottieni l'estensione del file incorporato.
    var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **Accesso alle Proprietà dei OLE Object Frame Collegati**

Aspose.Slides consente di accedere alle proprietà dei frame OLE Object collegati.

Questo codice JavaScript mostra come verificare se un oggetto OLE è collegato e quindi ottenere il percorso del file collegato:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.ppt");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    // Verifica se l'oggetto OLE è collegato.
    if (oleFrame.isObjectLink()) {
        // Stampa il percorso completo del file collegato.
        console.log("OLE object frame is linked to:", oleFrame.getLinkPathLong());

        // Stampa il percorso relativo del file collegato, se presente.
        // Solo le presentazioni PPT possono contenere il percorso relativo.
        if (oleFrame.getLinkPathRelative() != null && oleFrame.getLinkPathRelative() != "") {
            console.log("OLE object frame relative path:", oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **Modifica dei Dati di OLE Object**

{{% alert color="info" title="Note" %}}

In questa sezione, l'esempio di codice sottostante utilizza [Aspose.Cells for Java](https://docs.aspose.com/cells/java/).

{{% /alert %}}

Se un oggetto OLE è già incorporato in una diapositiva, puoi accedere facilmente a quell'oggetto e modificarne i dati in questo modo:

1. Carica una presentazione con l'oggetto OLE incorporato creando un'istanza della classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) .
2. Ottieni il riferimento della diapositiva tramite il suo indice. 
3. Accedi alla forma del frame OLE Object. Nel nostro esempio, abbiamo usato il PPTX precedentemente creato che ha una forma nella prima diapositiva.
4. Una volta acceduto al frame OLE Object, puoi eseguire qualsiasi operazione su di esso.
5. Crea un oggetto `Workbook` e accedi ai dati OLE.
6. Accedi al `Worksheet` desiderato e modifica i dati.
7. Salva il `Workbook` aggiornato in uno stream.
8. Modifica i dati dell'oggetto OLE dallo stream.

Nell'esempio sottostante, un frame OLE Object (un oggetto grafico Excel incorporato in una diapositiva) viene accesso e i suoi dati file vengono modificati per aggiornare i dati del grafico.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    var embeddedData = Array.from(oleFrame.getEmbeddedData().getEmbeddedFileData());
    var oleStream = java.newInstanceSync("java.io.ByteArrayInputStream", java.newArray("byte", embeddedData));

    // Leggi i dati dell'oggetto OLE come oggetto Workbook.
    var workbook = java.newInstanceSync("com.aspose.cells.Workbook", oleStream);

    var newOleStream = java.newInstanceSync("java.io.ByteArrayOutputStream");

    // Modifica i dati del workbook.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    var fileOptions = java.newInstanceSync("com.aspose.cells.OoxmlSaveOptions", java.getStaticFieldValue("com.aspose.cells.SaveFormat", "XLSX"));
    workbook.save(newOleStream, fileOptions);

    // Cambia i dati dell'oggetto OLE frame.
    var newFileData = java.newArray("byte", Array.from(newOleStream.toByteArray()));
    var newData = new asposeSlides.OleEmbeddedDataInfo(newFileData, oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);

    newOleStream.close();
    oleStream.close();
}

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Incorporamento di Altri Tipi di File nelle Diapositive**

Oltre ai grafici Excel, Aspose.Slides for Node.js via Java consente di incorporare altri tipi di file nelle diapositive. Ad esempio, è possibile inserire file HTML, PDF e ZIP come oggetti. Quando l'utente fa doppio clic sull'oggetto inserito, questo si apre automaticamente nel programma pertinente, oppure all'utente viene chiesto di selezionare un programma appropriato per aprirlo.

Questo codice JavaScript mostra come incorporare HTML e ZIP in una diapositiva:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

var htmlBuffer = fs.readFileSync("sample.html");
var htmlData = Array.from(htmlBuffer);
var htmlDataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", htmlData), "html");
var htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

var zipBuffer = fs.readFileSync("sample.zip");
var zipData = Array.from(zipBuffer);
var zipDataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", zipData), "zip");
var zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Impostazione dei Tipi di File per gli Oggetti Incorporati**

Quando lavori con le presentazioni, potresti dover sostituire vecchi oggetti OLE con nuovi o sostituire un oggetto OLE non supportato con uno supportato. Aspose.Slides for Node.js via Java consente di impostare il tipo di file per un oggetto incorporato, permettendoti di aggiornare i dati del frame OLE o la sua estensione.

Questo codice JavaScript mostra come impostare il tipo di file per un oggetto OLE incorporato su `zip`:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
var oleFileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

console.log("Current embedded file extension is:", fileExtension);

// Cambia il tipo di file in ZIP.
var fileData = java.newArray("byte", Array.from(oleFileData));
oleFrame.setEmbeddedData(new asposeSlides.OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Impostazione di Immagini Icona e Titoli per gli Oggetti Incorporati**

Dopo aver incorporato un oggetto OLE, viene aggiunta automaticamente un'anteprima costituita da un'immagine icona. Questa anteprima è ciò che gli utenti vedono prima di accedere o aprire l'oggetto OLE. Se desideri utilizzare un'immagine e un testo specifici come elementi dell'anteprima, puoi impostare l'immagine icona e il titolo utilizzando Aspose.Slides for Node.js via Java.

Questo codice JavaScript mostra come impostare l'immagine icona e il titolo per un oggetto incorporato:

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

// Aggiungi un'immagine alle risorse della presentazione.
var image = asposeSlides.Images.fromFile("image.png");
var oleImage = presentation.getImages().addImage(image);
image.dispose();

// Imposta un titolo e l'immagine per l'anteprima OLE.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Impedire il Ridimensionamento e il Reposizionamento di un OLE Object Frame**

Dopo aver aggiunto un oggetto OLE collegato a una diapositiva, quando apri la presentazione in PowerPoint potresti vedere un messaggio che ti chiede di aggiornare i collegamenti. Cliccando sul pulsante "Update Links" la dimensione e la posizione del frame OLE Object potrebbero cambiare perché PowerPoint aggiorna i dati dall'oggetto OLE collegato e aggiorna l'anteprima dell'oggetto. Per impedire a PowerPoint di chiedere l'aggiornamento dei dati dell'oggetto, chiama il metodo [setUpdateAutomatic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) della classe [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/) con `false`:

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

oleFrame.setUpdateAutomatic(false);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Estrazione dei File Incorporati**

Aspose.Slides for Node.js via Java consente di estrarre i file incorporati nelle diapositive come oggetti OLE in questo modo:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) contenente gli oggetti OLE che intendi estrarre.
2. Scorri tutte le forme nella presentazione e accedi alle forme [OLEObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe).
3. Accedi ai dati dei file incorporati dai frame OLE Object e scrivili su disco.

Questo codice JavaScript mostra come estrarre i file incorporati in una diapositiva come oggetti OLE:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);

for (var index = 0; index < slide.getShapes().size(); index++) {
    var shape = slide.getShapes().get_Item(index);

    if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
        var oleFrame = shape;

        var fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        var filePath = "OLE_object_" + index + fileExtension;
        fs.writeFileSync(filePath, Buffer.from(fileData));
    }
}

presentation.dispose();
```

## **FAQ**

**Il contenuto OLE verrà renderizzato durante l'esportazione delle diapositive in PDF/immagini?**

Ciò che è visibile sulla diapositiva viene renderizzato—l'icona/immagine sostitutiva (anteprima). Il contenuto OLE "live" non viene eseguito durante il rendering. Se necessario, imposta una tua immagine di anteprima per garantire l'aspetto previsto nel PDF esportato.

Per preservare anche il file incorporato come allegato PDF, chiama [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/#setIncludeOleData) con `true`. Questa opzione è disabilitata per impostazione predefinita. Per un esempio e istruzioni su come verificare l'allegato, vedi [Preserve Embedded OLE Files as PDF Attachments](/slides/it/nodejs-java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Come posso bloccare un oggetto OLE su una diapositiva in modo che gli utenti non possano spostarlo/modificarlo in PowerPoint?**

Blocca la forma: Aspose.Slides offre blocchi a livello di forma. Non si tratta di crittografia, ma impedisce efficacemente modifiche accidentali e spostamenti.

**I percorsi relativi per gli oggetti OLE collegati verranno conservati nel formato PPTX?**

Nel PPTX, le informazioni sul "percorso relativo" non sono disponibili—solo il percorso completo. I percorsi relativi si trovano nel formato PPT più vecchio. Per la portabilità, preferisci percorsi assoluti affidabili/URI accessibili o l'incorporamento.