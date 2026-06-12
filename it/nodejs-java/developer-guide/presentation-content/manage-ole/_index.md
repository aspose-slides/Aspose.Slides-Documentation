---
title: Gestire OLE nelle presentazioni usando JavaScript
linktitle: Gestisci OLE
type: docs
weight: 40
url: /it/nodejs-java/manage-ole/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Ottimizza la gestione degli oggetti OLE in PowerPoint e nei file OpenDocument con Aspose.Slides per Node.js tramite Java. Incorpora, aggiorna ed esporta i contenuti OLE senza problemi."
---
## **Introduzione**

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding) è una tecnologia Microsoft che consente di posizionare dati e oggetti creati in un’applicazione all’interno di un’altra tramite collegamento o incorporamento. 

{{% /alert %}} 

Considera un grafico creato in MS Excel. Il grafico viene quindi inserito all’interno di una diapositiva PowerPoint. Quel grafico Excel è considerato un oggetto OLE. 

- Un oggetto OLE può apparire come un’icona. In questo caso, quando fai doppio clic sull’icona, il grafico viene aperto nella sua applicazione associata (Excel), oppure ti viene chiesto di selezionare un’applicazione per l’apertura o la modifica dell’oggetto. 
- Un oggetto OLE può visualizzare il suo contenuto reale, ad esempio il contenuto di un grafico. In questo caso, il grafico è attivato in PowerPoint, l’interfaccia del grafico si carica e puoi modificare i dati del grafico all’interno di PowerPoint.

[Aspose.Slides per Node.js tramite Java](https://products.aspose.com/slides/it/nodejs-java/) consente di inserire OLE Objects nelle diapositive come cornici di oggetti OLE ([OleObjectFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/OleObjectFrame)).

## **Aggiungere Cornici di Oggetti OLE alle Diapositive**

Supponendo che tu abbia già creato un grafico in Microsoft Excel e desideri incorporarlo in una diapositiva come cornice di oggetto OLE utilizzando Aspose.Slides per Node.js tramite Java, puoi farlo in questo modo:

1. Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
2. Ottieni il riferimento di una diapositiva tramite il suo indice.
3. Leggi il file Excel come array di byte.
4. Aggiungi il [OleObjectFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/OleObjectFrame) alla diapositiva contenente l’array di byte e le altre informazioni sull’oggetto OLE.
5. Scrivi la presentazione modificata come file PPTX.

Nell’esempio sottostante, abbiamo aggiunto un grafico da un file Excel a una diapositiva come cornice di oggetto OLE utilizzando Aspose.Slides per Node.js tramite Java. **Nota** che il costruttore [OleEmbeddedDataInfo](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/OleEmbeddedDataInfo) accetta un’estensione di oggetto incorporabile come secondo parametro. Questa estensione consente a PowerPoint di interpretare correttamente il tipo di file e scegliere l’applicazione giusta per aprire questo oggetto OLE.

```javascript
var presentation = new asposeSlides.Presentation();
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(0);

// Prepara i dati per l'oggetto OLE.
var oleStream = fs.readFileSync("book.xlsx");
var fileData = Array.from(oleStream);
var dataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", fileData), "xlsx");

// Aggiungi la cornice dell'oggetto OLE alla diapositiva.
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

### **Aggiungere Cornici di Oggetti OLE Collegati**

Aspose.Slides per Node.js tramite Java consente di aggiungere un [OleObjectFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/OleObjectFrame) senza incorporare dati ma solo con un collegamento al file.

Questo codice JavaScript mostra come aggiungere un [OleObjectFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/OleObjectFrame) con un file Excel collegato a una diapositiva:

```javascript
var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

// Aggiungi una cornice di oggetto OLE con un file Excel collegato.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Accedere alle Cornici di Oggetti OLE**

Se un oggetto OLE è già incorporato in una diapositiva, puoi trovarlo o accedervi facilmente in questo modo:

1. Carica una presentazione con l’oggetto OLE incorporato creando un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
2. Ottieni il riferimento della diapositiva usando il suo indice.
3. Accedi alla forma [OleObjectFrame]. Nel nostro esempio, abbiamo usato il PPTX creato in precedenza che ha una sola forma nella prima diapositiva.
4. Una volta che la cornice dell’oggetto OLE è stata accessa, puoi eseguire qualsiasi operazione su di essa.

Nell’esempio sottostante, una cornice di oggetto OLE (un oggetto grafico Excel incorporato in una diapositiva) e i suoi dati file vengono acceduti.

```javascript
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

### **Accedere alle Proprietà della Cornice di Oggetto OLE Collegata**

Aspose.Slides consente di accedere alle proprietà della cornice di oggetto OLE collegata.

Questo codice JavaScript mostra come verificare se un oggetto OLE è collegato e quindi ottenere il percorso del file collegato:

```javascript
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

## **Modificare i Dati dell'Oggetto OLE**

{{% alert color="primary" %}} 

In questa sezione, l’esempio di codice sotto utilizza [Aspose.Cells for Java](/cells/java/).

{{% /alert %}}

Se un oggetto OLE è già incorporato in una diapositiva, puoi accedere facilmente a quell’oggetto e modificarne i dati in questo modo:

1. Carica una presentazione con l’oggetto OLE incorporato creando un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
2. Ottieni il riferimento della diapositiva attraverso il suo indice. 
3. Accedi alla forma della cornice dell’oggetto OLE. Nel nostro esempio, abbiamo usato il PPTX creato in precedenza che ha una forma nella prima diapositiva.
4. Una volta che la cornice dell’oggetto OLE è stata accessa, puoi eseguire qualsiasi operazione su di essa.
5. Crea un oggetto `Workbook` e accedi ai dati OLE.
6. Accedi al `Worksheet` desiderato e modifica i dati.
7. Salva il `Workbook` aggiornato in uno stream.
8. Modifica i dati dell’oggetto OLE dallo stream.

Nell’esempio sottostante, una cornice di oggetto OLE (un oggetto grafico Excel incorporato in una diapositiva) è acceduta e i suoi dati file sono modificati per aggiornare i dati del grafico.

```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    var oleStream = java.newInstanceSync("java.io.ByteArrayInputStream", oleFrame.getEmbeddedData().getEmbeddedFileData());

    // Leggi i dati dell'oggetto OLE come oggetto Workbook.
    var workbook = java.newInstanceSync("Workbook", oleStream);

    var newOleStream = java.newInstanceSync("java.io.ByteArrayOutputStream");

    // Modifica i dati del workbook.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    var fileOptions = java.newInstanceSync("OoxmlSaveOptions", java.getStaticFieldValue("com.aspose.cells.SaveFormat", "XLSX"));
    workbook.save(newOleStream, fileOptions);

    // Cambia i dati dell'oggetto cornice OLE.
    var newData = new asposeSlides.OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);

    newOleStream.close();
    oleStream.close();
}

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Incorporare Altri Tipi di File nelle Diapositive**

Oltre ai grafici Excel, Aspose.Slides per Node.js tramite Java consente di incorporare altri tipi di file nelle diapositive. Ad esempio, puoi inserire file HTML, PDF e ZIP come oggetti. Quando l’utente fa doppio clic sull’oggetto inserito, questo si apre automaticamente nel programma pertinente, oppure all’utente viene chiesto di selezionare un programma appropriato per aprirlo.

Questo codice JavaScript mostra come incorporare HTML e ZIP in una diapositiva:

```javascript
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

## **Impostare i Tipi di File per gli Oggetti Incorporati**

Durante la gestione delle presentazioni, potresti dover sostituire vecchi oggetti OLE con nuovi o sostituire un oggetto OLE non supportato con uno supportato. Aspose.Slides per Node.js tramite Java consente di impostare il tipo di file per un oggetto incorporato, consentendo di aggiornare i dati della cornice OLE o la sua estensione.

Questo codice JavaScript mostra come impostare il tipo di file per un oggetto OLE incorporato a `zip`:

```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
var oleFileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

console.log("Current embedded file extension is:", fileExtension);

// Modifica il tipo di file in ZIP.
var fileData = java.newArray("byte", Array.from(oleFileData));
oleFrame.setEmbeddedData(new asposeSlides.OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Impostare Immagini Icona e Titoli per gli Oggetti Incorporati**

Dopo aver incorporato un oggetto OLE, viene aggiunta automaticamente un’anteprima costituita da un’immagine icona. Questa anteprima è ciò che gli utenti vedono prima di accedere o aprire l’oggetto OLE. Se desideri usare un’immagine e un testo specifici come elementi dell’anteprima, puoi impostare l’immagine icona e il titolo usando Aspose.Slides per Node.js tramite Java.

Questo codice JavaScript mostra come impostare l’immagine icona e il titolo per un oggetto incorporato:

```javascript
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

## **Impedire il Ridimensionamento e il Riposizionamento della Cornice di Oggetto OLE**

Dopo aver aggiunto un oggetto OLE collegato a una diapositiva della presentazione, quando apri la presentazione in PowerPoint potresti vedere un messaggio che ti chiede di aggiornare i collegamenti. Cliccando sul pulsante “Update Links” potrebbe cambiare le dimensioni e la posizione della cornice dell’oggetto OLE perché PowerPoint aggiorna i dati dall’oggetto OLE collegato e rinfresca l’anteprima dell’oggetto. Per impedire a PowerPoint di richiedere l’aggiornamento dei dati dell’oggetto, usa il metodo `setUpdateAutomatic` della classe [OleObjectFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/oleobjectframe/) con valore `false`:

```javascript
oleFrame.setUpdateAutomatic(false);
```

## **Estrazione dei File Incorporati**

Aspose.Slides per Node.js tramite Java consente di estrarre i file incorporati nelle diapositive come oggetti OLE in questo modo:

1. Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation) contenente gli oggetti OLE che intendi estrarre.
2. Scorri tutte le forme nella presentazione e accedi alle forme [OLEObjectFrame].
3. Accedi ai dati dei file incorporati dalle cornici di oggetti OLE e scrivili su disco.

Questo codice JavaScript mostra come estrarre i file incorporati in una diapositiva come oggetti OLE:

```javascript
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

Ciò che è visibile sulla diapositiva viene renderizzato—l'icona/immagine sostitutiva (anteprima). Il contenuto OLE “live” non viene eseguito durante il rendering. Se necessario, imposta una tua immagine di anteprima per garantire l’aspetto atteso nel PDF esportato.

**Come posso bloccare un oggetto OLE su una diapositiva affinché gli utenti non possano spostarlo/modificarlo in PowerPoint?**

Blocca la forma: Aspose.Slides fornisce blocchi a livello di forma. Non è crittografia, ma impedisce efficacemente modifiche e spostamenti accidentali.

**I percorsi relativi per gli oggetti OLE collegati saranno preservati nel formato PPTX?**

Nel PPTX le informazioni sul “percorso relativo” non sono disponibili—solo il percorso completo. I percorsi relativi sono presenti nel vecchio formato PPT. Per la portabilità, è preferibile usare percorsi assoluti affidabili/URI accessibili o l’incorporamento.