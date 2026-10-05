---
title: Gestire OLE nelle Presentazioni con PHP
linktitle: Gestisci OLE
type: docs
weight: 40
url: /it/php-java/manage-ole/
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
- PHP
- Aspose.Slides
description: "Ottimizza la gestione degli oggetti OLE in PowerPoint e nei file OpenDocument con Aspose.Slides per PHP via Java. Incorpora, aggiorna ed esporta i contenuti OLE senza problemi."
---
## **Introduzione**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) è una tecnologia Microsoft che consente ai dati e agli oggetti creati in un’applicazione di essere inseriti in un’altra applicazione tramite collegamento o incorporamento. 

{{% /alert %}} 

Considera un grafico creato in MS Excel. Il grafico viene quindi inserito all’interno di una diapositiva PowerPoint. Quel grafico Excel è considerato un oggetto OLE. 

- Un oggetto OLE può apparire come un’icona. In questo caso, facendo doppio clic sull’icona, il grafico si apre nell’applicazione associata (Excel) o viene chiesto di selezionare un’applicazione per aprire o modificare l’oggetto.
- Un oggetto OLE può visualizzare il suo contenuto reale, ad esempio il contenuto di un grafico. In questo caso, il grafico è attivato in PowerPoint, l’interfaccia del grafico si carica e puoi modificare i dati del grafico direttamente in PowerPoint.

[Aspose.Slides per PHP via Java](https://products.aspose.com/slides/php-java/) consente di inserire oggetti OLE nelle diapositive come cornici di oggetti OLE ([OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/)).

## **Aggiungere Cornici di Oggetti OLE alle Diapositive**

Supponendo di aver già creato un grafico in Microsoft Excel e di volerlo incorporare in una diapositiva come cornice di oggetto OLE usando Aspose.Slides per PHP via Java, è possibile farlo in questo modo:

1. Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Ottieni il riferimento a una diapositiva tramite il suo indice.
1. Leggi il file Excel come array di byte.
1. Aggiungi il [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) alla diapositiva contenente l’array di byte e le altre informazioni sull’oggetto OLE.
1. Scrivi la presentazione modificata come file PPTX.

Nell’esempio seguente, abbiamo aggiunto un grafico da un file Excel a una diapositiva come cornice di oggetto OLE usando Aspose.Slides per PHP via Java.  
**Nota** che il costruttore [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/) accetta un’estensione di oggetto incorporabile come secondo parametro. Questa estensione consente a PowerPoint di interpretare correttamente il tipo di file e di scegliere l’applicazione giusta per aprire questo oggetto OLE.

```php
$presentation = new Presentation();
$slideSize = $presentation->getSlideSize()->getSize();
$slide = $presentation->getSlides()->get_Item(0);

// Prepara i dati per l'oggetto OLE.
$fileData = file_get_contents("book.xlsx");
$dataInfo = new OleEmbeddedDataInfo($fileData, "xlsx");

// Aggiungi la cornice dell'oggetto OLE alla diapositiva.
$slide->getShapes()->addOleObjectFrame(0, 0, $slideSize->getWidth(), $slideSize->getHeight(), $dataInfo);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

### **Aggiungere Cornici di Oggetti OLE Collegate**

Aspose.Slides per PHP via Java consente di aggiungere un [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) senza incorporare dati, ma solo con un collegamento al file.

Questo codice PHP mostra come aggiungere un [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) con un file Excel collegato a una diapositiva:

```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

// Aggiungi una cornice di oggetto OLE con un file Excel collegato.
$slide->getShapes()->addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Accedere alle Cornici di Oggetti OLE**

Se un oggetto OLE è già incorporato in una diapositiva, è possibile trovarlo o accedervi facilmente in questo modo:

1. Carica una presentazione contenente l’oggetto OLE incorporato creando un’istanza della classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Ottieni il riferimento della diapositiva usando il suo indice.
3. Accedi alla forma [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/). Nel nostro esempio, abbiamo usato il PPTX creato in precedenza che contiene una sola forma nella prima diapositiva.
4. Una volta acceduta la cornice dell’oggetto OLE, è possibile eseguire qualsiasi operazione su di essa.

Nell’esempio seguente, una cornice di oggetto OLE (un oggetto grafico Excel incorporato in una diapositiva) e i dati del suo file vengono accessi.

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;
    
    // Ottieni i dati del file incorporato.
    // Ottieni l'estensione del file incorporato.
    // ...
}
```

### **Accedere alle Proprietà della Cornice di Oggetti OLE Collegata**

Aspose.Slides consente di accedere alle proprietà delle cornici di oggetti OLE collegate.

Questo codice PHP mostra come verificare se un oggetto OLE è collegato e quindi ottenere il percorso del file collegato:

```php
$presentation = new Presentation("sample.ppt");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    // Verifica se l'oggetto OLE è collegato.
    if (java_values($oleFrame->isObjectLink()) != 0) {
        // Stampa il percorso completo del file collegato.
        echo "OLE object frame is linked to: " . $oleFrame->getLinkPathLong() . PHP_EOL;

        // Stampa il percorso relativo del file collegato se presente.
        // Solo le presentazioni PPT possono contenere il percorso relativo.
        $relativePath = java_values($oleFrame->getLinkPathRelative());
        if (!is_null($relativePath) && $relativePath !== "") {
            echo "OLE object frame relative path: " . $oleFrame->getLinkPathRelative() . PHP_EOL;
        }
    }
}

$presentation->dispose();
```

## **Modificare i Dati degli Oggetti OLE**

{{% alert color="info" title="Note" %}}

In questa sezione, l’esempio di codice sottostante utilizza [Aspose.Cells per PHP via Java](https://docs.aspose.com/cells/php-java/).

{{% /alert %}}

Se un oggetto OLE è già incorporato in una diapositiva, è possibile accedere a quell’oggetto e modificarne i dati in questo modo:

1. Carica una presentazione contenente l’oggetto OLE incorporato creando un’istanza della classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Ottieni il riferimento della diapositiva tramite il suo indice. 
3. Accedi alla forma [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/). Nel nostro esempio, abbiamo usato il PPTX creato in precedenza che contiene una forma nella prima diapositiva.
4. Una volta acceduta la cornice dell’oggetto OLE, è possibile eseguire qualsiasi operazione su di essa.
5. Crea un oggetto `Workbook` e accedi ai dati OLE.
6. Accedi al `Worksheet` desiderato e modifica i dati.
7. Salva il `Workbook` aggiornato in uno stream.
8. Modifica i dati dell’oggetto OLE dallo stream.

Nell’esempio seguente, una cornice di oggetto OLE (un oggetto grafico Excel incorporato in una diapositiva) viene accessa e i dati del suo file vengono modificati per aggiornare i dati del grafico.

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    $oleStream = new Java("java.io.ByteArrayInputStream", $oleFrame->getEmbeddedData()->getEmbeddedFileData());

    // Leggi i dati dell'oggetto OLE come oggetto Workbook.
    $workbook = new Workbook($oleStream);

    $newOleStream = new Java("java.io.ByteArrayOutputStream");

    // Modifica i dati del workbook.
    $workbook->getWorksheets()->get(0)->getCells()->get(0, 4)->putValue("E");
    $workbook->getWorksheets()->get(0)->getCells()->get(1, 4)->putValue(12);
    $workbook->getWorksheets()->get(0)->getCells()->get(2, 4)->putValue(14);
    $workbook->getWorksheets()->get(0)->getCells()->get(3, 4)->putValue(15);

    $fileOptions = new OoxmlSaveOptions(SaveFormat::XLSX);
    $workbook->save($newOleStream, $fileOptions);

    // Modifica i dati dell'oggetto cornice OLE.
    $newData = new OleEmbeddedDataInfo($newOleStream->toByteArray(), $oleFrame->getEmbeddedData()->getEmbeddedFileExtension());
    $oleFrame->setEmbeddedData($newData);

    $newOleStream->close();
    $oleStream->close();
}

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Incorporare Altri Tipi di File nelle Diapositive**

Oltre ai grafici Excel, Aspose.Slides per PHP via Java consente di incorporare altri tipi di file nelle diapositive. Ad esempio, è possibile inserire file HTML, PDF e ZIP come oggetti. Quando l’utente fa doppio clic sull’oggetto inserito, questo si apre automaticamente nel programma pertinente, oppure viene richiesto all’utente di selezionare un programma appropriato per aprirlo.

Questo codice PHP mostra come incorporare HTML e ZIP in una diapositiva:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);

$htmlData = file_get_contents("sample.html");
$htmlDataInfo = new OleEmbeddedDataInfo($htmlData, "html");
$htmlOleFrame = $slide->getShapes()->addOleObjectFrame(150, 120, 50, 50, $htmlDataInfo);
$htmlOleFrame->setObjectIcon(true);

$zipData = file_get_contents("sample.zip");
$zipDataInfo = new OleEmbeddedDataInfo($zipData, "zip");
$zipOleFrame = $slide->getShapes()->addOleObjectFrame(150, 220, 50, 50, $zipDataInfo);
$zipOleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Impostare i Tipi di File per gli Oggetti Incorporati**

Durante il lavoro con le presentazioni, potresti dover sostituire vecchi oggetti OLE con nuovi o sostituire un oggetto OLE non supportato con uno supportato. Aspose.Slides per PHP via Java consente di impostare il tipo di file per un oggetto incorporato, permettendo di aggiornare i dati della cornice OLE o la sua estensione.

Questo codice PHP mostra come impostare il tipo di file per un oggetto OLE incorporato a `zip`:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

$fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();
$fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

echo "Current embedded file extension is: " . $fileExtension . PHP_EOL;

// Cambia il tipo di file in ZIP.
$oleFrame->setEmbeddedData(new OleEmbeddedDataInfo($fileData, "zip"));

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Impostare Immagini e Titoli dell'Icona per gli Oggetti Incorporati**

Dopo aver incorporato un oggetto OLE, viene aggiunta automaticamente un’anteprima costituita da un’immagine icona. Questa anteprima è ciò che gli utenti vedono prima di accedere o aprire l’oggetto OLE. Se desideri utilizzare un’immagine e un testo specifici come elementi dell’anteprima, puoi impostare l’immagine icona e il titolo usando Aspose.Slides per PHP via Java.

Questo codice PHP mostra come impostare l’immagine icona e il titolo per un oggetto incorporato:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

// Aggiungi un'immagine alle risorse della presentazione.
$imageData = file_get_contents("image.png");
$oleImage = $presentation->getImages()->addImage($imageData);

// Imposta un titolo e l'immagine per l'anteprima OLE.
$oleFrame->setSubstitutePictureTitle("My title");
$oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
$oleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Impedire che una Cornice di Oggetto OLE venga Ridimensionata e Riposizionata**

Dopo aver aggiunto un oggetto OLE collegato a una diapositiva di presentazione, aprendo la presentazione in PowerPoint potresti visualizzare un messaggio che ti chiede di aggiornare i collegamenti. Il pulsante “Update Links” potrebbe modificare dimensione e posizione della cornice OLE perché PowerPoint aggiorna i dati dall’oggetto OLE collegato e rinfresca l’anteprima dell’oggetto. Per impedire a PowerPoint di chiedere l’aggiornamento dei dati dell’oggetto, chiama il metodo [setUpdateAutomatic](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) della classe [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) con `false`:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

$oleFrame->setUpdateAutomatic(false);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Estrazione dei File Incorporati**

Aspose.Slides per PHP via Java consente di estrarre i file incorporati nelle diapositive come oggetti OLE in questo modo:

1. Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) contenente gli oggetti OLE che intendi estrarre.
2. Scorri tutte le forme nella presentazione e accedi alle forme [OLEObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/).
3. Accedi ai dati dei file incorporati dalle cornici OLE e scrivili su disco.

Questo codice PHP mostra come estrarre i file incorporati in una diapositiva come oggetti OLE:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);

$shapeCount = java_values($slide->getShapes()->size());
for ($index = 0; $index < $shapeCount; $index++) {
    $shape = $slide->getShapes()->get_Item($index);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
        $oleFrame = $shape;

        $fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();
        $fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();

        $filePath = "OLE_object_" . $index . $fileExtension;
        file_put_contents($filePath, $fileData);
    }
}

$presentation->dispose();
```

## **FAQ**

**Il contenuto OLE verrà renderizzato durante l'esportazione delle diapositive in PDF/immagini?**

Viene renderizzata solo la parte visibile nella diapositiva—l’icona/immagine sostitutiva (anteprima). Il contenuto OLE “live” non viene eseguito durante il rendering. Se necessario, imposta la tua immagine di anteprima per garantire l’aspetto previsto nel PDF esportato.

Per conservare anche il file incorporato come allegato PDF, chiama [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setIncludeOleData) con `true`. Questa opzione è disabilitata per impostazione predefinita. Per un esempio e istruzioni su come verificare l’allegato, vedi [Preserva i File OLE Incorporati come Allegati PDF](/slides/it/php-java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Come posso bloccare un oggetto OLE su una diapositiva in modo che gli utenti non possano spostarlo/modificarlo in PowerPoint?**

Blocca la forma: Aspose.Slides fornisce blocchi a livello di forma. Non è crittografia, ma impedisce efficacemente modifiche accidentali e spostamenti.

**I percorsi relativi per gli oggetti OLE collegati saranno conservati nel formato PPTX?**

Nel PPTX le informazioni sul “percorso relativo” non sono disponibili—solo il percorso completo. I percorsi relativi sono presenti nel vecchio formato PPT. Per la portabilità, preferisci percorsi assoluti affidabili/URI accessibili o l’incorporamento.