---
title: Esporta presentazioni in XAML con PHP
linktitle: Presentazione in XAML
type: docs
weight: 30
url: /it/php-java/export-to-xaml/
keywords:
- esporta PowerPoint
- esporta OpenDocument
- esporta presentazione
- converti PowerPoint
- converti OpenDocument
- converti presentazione
- PowerPoint in XAML
- OpenDocument in XAML
- presentazione in XAML
- PPT in XAML
- PPTX in XAML
- ODP in XAML
- salva PPT come XAML
- salva PPTX come XAML
- salva ODP come XAML
- esporta PPT in XAML
- esporta PPTX in XAML
- esporta ODP in XAML
- PHP
- Aspose.Slides
description: "Converti le diapositive PowerPoint e OpenDocument in XAML usando Aspose.Slides per PHP via Java — soluzione rapida, senza Office, che conserva intatto il layout."
---
## **Panoramica**

Questo articolo spiega come esportare presentazioni PowerPoint in XAML utilizzando Aspose.Slides. Include una breve introduzione a XAML, mostra come salvare una presentazione in XAML con le impostazioni predefinite e dimostra come personalizzare l'esportazione tramite [XamlOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/xamloptions/), inclusa l'esportazione delle diapositive nascoste. L'articolo risponde inoltre a alcune domande frequenti relative ai font di fallback, alla compatibilità con gli stack XAML e al comportamento di esportazione delle diapositive nascoste.

## **Informazioni su XAML**

XAML è un linguaggio di markup basato su XML utilizzato per descrivere interfacce utente in framework come WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) e Xamarin.Forms.

È possibile lavorare con file XAML in un designer visuale oppure scrivere e modificare direttamente il markup.

## **Esporta presentazioni in XAML con opzioni predefinite**

Il seguente esempio PHP mostra come esportare una presentazione in XAML con le impostazioni predefinite. Inizializzare PHP Java Bridge e caricare `aspose.slides.php` prima di eseguire gli esempi in questo articolo. Posizionare `pres.pptx` nella directory di lavoro del server Java Bridge, oppure fornire un percorso assoluto accessibile a quel server.

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $presentation->save($options);
} finally {
    $presentation->dispose();
}
```

Per impostazione predefinita, le diapositive esportate vengono salvate in una sottocartella `pres` della directory di lavoro corrente del server Java Bridge. La cartella viene creata automaticamente e tutte le immagini richieste vengono salvate lì.

Il nome della cartella di output è ricavato dal nome del file sorgente senza estensione. Per `pres.pptx`, i file di output sono denominati `pres/Slide_1.xaml`, `pres/Slide_2.xaml` e così via. Anche se si passa un percorso assoluto alla presentazione di input, la cartella di output viene creata in relazione alla directory di lavoro corrente del server Java Bridge, non accanto al file di input.

## **Esporta presentazioni in XAML con opzioni personalizzate**

Utilizzare l'interfaccia [IXamlOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/ixamloptions/) per controllare il modo in cui Aspose.Slides esporta una presentazione in XAML.

Per salvare l'output in una posizione personalizzata, fornire un proxy Java che implementi [IXamlOutputSaver](https://reference.aspose.com/slides/it/java/com.aspose.slides/ixamloutputsaver/) e passare un'istanza della propria implementazione al metodo [setOutputSaver](https://reference.aspose.com/slides/it/php-java/aspose.slides/xamloptions/#setOutputSaver) di [XamlOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/xamloptions/).

Per includere le diapositive nascoste nell'output XAML, chiamare [setExportHiddenSlides](https://reference.aspose.com/slides/it/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) con `true`, come mostrato nel seguente esempio PHP:

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setExportHiddenSlides(true);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}
```

## **Acquisisci tutti gli artefatti XAML generati**

Un'esportazione XAML può produrre un documento XAML per ciascuna diapositiva esportata più immagini separate e risorse di supporto. Assegnare un [IXamlOutputSaver](https://reference.aspose.com/slides/it/java/com.aspose.slides/ixamloutputsaver/) personalizzato a [XamlOptions::setOutputSaver](https://reference.aspose.com/slides/it/php-java/aspose.slides/xamloptions/#setOutputSaver) per ricevere questi artefatti anziché utilizzare il salvataggio predefinito sul file system. Avviare l'esportazione con la sovraccarico specifico XAML di [Presentation::save](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#save) che accetta le opzioni XAML.

La funzione `java_closure` del PHP Java Bridge espone un oggetto PHP come interfaccia Java. Tenere sia il saver PHP sia il suo proxy attivi fino al completamento dell'esportazione. I collegamenti dell'interfaccia puntano all'API Java implementata dal proxy.

### **Comprendere il ciclo di vita del callback**

L'esportatore chiama [IXamlOutputSaver::save](https://reference.aspose.com/slides/it/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) separatamente per ciascun artefatto generato:

- `path` identifica l'artefatto e può includere directory relative. Conservare queste informazioni perché XAML può fare riferimento a risorse usando percorsi relativi.
- `data` contiene i byte dell'artefatto. Immagini e altre risorse binarie non devono essere decodificate come testo.
- Il saver è responsabile di mantenere o persistere i dati prima di restituire. Gli esempi convertono ogni array di byte Java in una stringa binaria PHP gestita dall'applicazione.
- Considerare l'esportazione come riuscita solo quando l'operazione di salvataggio della presentazione restituisce e ogni callback è completato con successo. Non sopprimere errori di archiviazione né avviare scritture in background non osservate. Se la persistenza avviene successivamente, segnalare il successo complessivo solo dopo che anche quel passaggio ha avuto esito positivo.

[XamlOptions::setExportHiddenSlides](https://reference.aspose.com/slides/it/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) si applica anche a un saver personalizzato. L'impostazione predefinita, `false`, esclude i documenti XAML delle diapositive nascoste. Passare `true` le include insieme a tutte le risorse necessarie per l'esportazione. Il conteggio delle risorse dipende dalla presentazione; non presumere un callback per diapositiva o un ordine fisso dei callback.

### **Esporta in memoria e ispeziona gli artefatti**

Questo esempio completo carica `pres.pptx`, raccoglie ogni artefatto in un array associativo PHP di stringhe binarie e stampa il nome, il tipo e il conteggio dei byte. Mantiene i nomi forniti esattamente. I nomi duplicati invalidano la raccolta invece di sovrascrivere silenziosamente un artefatto. L'esempio verifica ciò prima di utilizzare i risultati.

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

class MemoryXamlSaver {
    public $artifacts = [];
    public $valid = true;

    public function save($path, $data) {
        $name = (string) java_values($path);
        if (array_key_exists($name, $this->artifacts)) {
            $this->valid = false;
            echo "Export rejected: duplicate artifact name: " . $name . PHP_EOL;
            return;
        }
        $bytes = java_values($data);
        if (is_string($bytes)) {
            $binary = $bytes;
        } else {
            $binary = "";
            foreach ($bytes as $byte) {
                $binary .= chr($byte & 0xff);
            }
        }
        $this->artifacts[$name] = $binary;
    }
}

$saver = new MemoryXamlSaver();
$proxy = java_closure($saver, null, java("com.aspose.slides.IXamlOutputSaver"));
$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setOutputSaver($proxy);
    $options->setExportHiddenSlides(true);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}

if (!$saver->valid) {
    echo "Export rejected: the artifact collection is invalid." . PHP_EOL;
    return;
}

$inspectXamlText = false;
foreach ($saver->artifacts as $name => $bytes) {
    $extension = strtolower(pathinfo($name, PATHINFO_EXTENSION));
    $isXaml = $extension === "xaml";
    $isImage = in_array($extension, ["png", "jpg", "jpeg", "gif", "bmp", "tif", "tiff", "svg"], true);
    $kind = $isXaml ? "slide XAML" : ($isImage ? "image" : "supporting resource");
    echo $name . ": " . strlen($bytes) . " bytes (" . $kind . ")" . PHP_EOL;

    // Solo XAML è trattato come testo UTF-8 per ispezione opzionale.
    if ($isXaml && $inspectXamlText) {
        echo $bytes . PHP_EOL;
    }
}
```

I controlli di estensione sono utili per l'ispezione; conservare tutti gli artefatti, inclusi i tipi di risorsa sconosciuti. Lasciare i byte invariati durante la memorizzazione o la trasmissione. Le stringhe PHP possono contenere dati binari, inclusi byte null. Trattare una stringa come testo UTF‑8 solo quando si ispeziona il XAML; non ricodificare i byte di immagini o risorse.

### **Impacchetta gli artefatti raccolti in un archivio ZIP**

Questo esempio indipendente raccoglie l'esportazione, ne valida i nomi e scrive i byte originali in un archivio ZIP. Una directory di lavoro creata esclusivamente separa i job di esportazione concorrenti. L'esempio richiede l'estensione PHP Phar con supporto ZIP. Le voci ZIP usano barre oblique e mantengono le directory relative. Nomi non sicuri o nomi che collidono dopo la normalizzazione rifiutano l'intero pacchetto prima della scrittura.

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

class MemoryXamlSaver {
    public $artifacts = [];
    public $valid = true;

    public function save($path, $data) {
        $name = (string) java_values($path);
        if (array_key_exists($name, $this->artifacts)) {
            $this->valid = false;
            echo "Export rejected: duplicate artifact name: " . $name . PHP_EOL;
            return;
        }
        $bytes = java_values($data);
        if (is_string($bytes)) {
            $binary = $bytes;
        } else {
            $binary = "";
            foreach ($bytes as $byte) {
                $binary .= chr($byte & 0xff);
            }
        }
        $this->artifacts[$name] = $binary;
    }
}

$saver = new MemoryXamlSaver();
$proxy = java_closure($saver, null, java("com.aspose.slides.IXamlOutputSaver"));
$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setOutputSaver($proxy);
    $options->setExportHiddenSlides(false);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}

if (!$saver->valid) {
    echo "Export rejected: the artifact collection is invalid." . PHP_EOL;
    return;
}

$entries = [];
$entryNames = [];
foreach ($saver->artifacts as $name => $bytes) {
    $entryName = str_replace("\\", "/", $name);
    $unsafeName = substr($entryName, 0, 1) === "/" || strpos($entryName, ":") !== false;
    foreach (explode("/", $entryName) as $segment) {
        $unsafeName = $unsafeName || trim($segment) === "" || $segment === "." || $segment === "..";
    }
    $key = strtolower($entryName);
    if ($unsafeName || isset($entryNames[$key])) {
        echo "Export rejected: unsafe or duplicate artifact name: " . $name . PHP_EOL;
        return;
    }
    $entryNames[$key] = true;
    $entries[$entryName] = $bytes;
}

$jobDirectory = "xaml-" . bin2hex(random_bytes(16));
if (!mkdir($jobDirectory, 0700)) {
    echo "Cannot create the export directory." . PHP_EOL;
    return;
}
$archivePath = $jobDirectory . "/export.zip";
try {
    $archive = new PharData($archivePath, 0, null, Phar::ZIP);
    foreach ($entries as $name => $bytes) {
        $archive->addFromString($name, $bytes);
    }
    unset($archive);
    echo "Saved " . count($entries) . " artifacts to " . $archivePath . PHP_EOL;
} catch (Throwable $exception) {
    unset($archive);
    echo "Archive persistence failed: " . $exception->getMessage() . PHP_EOL;
}
```

L'esempio utilizza [PharData](https://www.php.net/manual/en/class.phardata.php) per scrivere un archivio ZIP locale nella directory di lavoro del processo PHP; l'esportatore stesso non scrive file XAML o immagini sparsi. Per l'archiviazione remota, sostituire la fase di scrittura dell'archivio con upload delle stringhe binarie raccolte. Usare un identificatore di job di esportazione più il nome relativo completo dell'artefatto come chiave blob, oppure memorizzare l'identificatore del job, il nome relativo e i dati binari in una riga di database. Pubblicare il job solo dopo che tutti gli upload sono completati o la transazione del database è confermata. Pulire l'output parziale se la persistenza fallisce.

Per presentazioni di grandi dimensioni, un saver personalizzato può persistere ogni artefatto direttamente nello storage dell'applicazione per evitare di mantenere una copia aggiuntiva dell'intera esportazione in memoria. Mantenere ogni callback sincrona dal punto di vista dell'esportatore: restituire solo dopo che la destinazione ha accettato i byte e consentire ai fallimenti di raggiungere il chiamante.

### **Conserva i nomi delle risorse e verifica i riferimenti**

- Normalizzare i separatori di percorso quando la destinazione lo richiede, ma preservare le directory relative. Non usare solo [basename](https://www.php.net/manual/en/function.basename.php) a meno che ogni nome generato sia noto per essere unico e i riferimenti alle risorse rimangano validi.
- Applicare la convalida dei nomi specifica della destinazione. Quando si scrivono file sparsi, rifiutare percorsi assoluti e segmenti di traversata, risolvere la destinazione in un percorso assoluto e verificare che rimanga sotto la directory di esportazione prevista, includendo il separatore di directory nel controllo di contenimento. Utilizzare una directory controllata dall'applicazione senza collegamenti simbolici che possano dirottare le scritture.
- Usare un saver e uno spazio dei nomi di storage separati per ciascun job di esportazione. Rilevare collisioni dopo la normalizzazione dei separatori e secondo le regole di case‑sensitivity della destinazione.
- Prima della pubblicazione, analizzare ogni documento XAML come XML e ispezionare i riferimenti a risorse basati su file, come gli attributi `Source` o `ImageSource` delle immagini. Risolvere ogni URI relativo rispetto alla directory dell'artefatto XAML contenente, normalizzare il nome di storage risultante e confermare che la chiave di mappa corrispondente, la voce ZIP o l'oggetto memorizzato esista. Trattare gli URI esterni e le espressioni di markup XAML separatamente dai nomi di file relativi.

Ad esempio, se `pres/Slide_1.xaml` fa riferimento a `images/image1.png`, la risorsa memorizzata deve essere disponibile come `pres/images/image1.png`. Conservare solo `image1.png` romperebbe tale relazione. Per lo storage di oggetti, mantenere la stessa struttura sotto il prefisso del job e rendere quegli URL di risorsa accessibili al consumatore XAML. Riaprire lo ZIP completato per verificare i nomi delle voci e i byte delle risorse, e caricare diapositive rappresentative nell'ambiente XAML di destinazione per confermare che le immagini vengano risolte correttamente.

## **FAQ**

**Come posso garantire font prevedibili se il font originale non è disponibile sulla macchina?**

Chiamare [setDefaultRegularFont](https://reference.aspose.com/slides/it/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) in [XamlOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/xamloptions/) — viene utilizzato come font di fallback durante l'esportazione quando quello originale manca. Questo non garantisce che lo XAML generato faccia riferimento al font di fallback o che il font sia disponibile sulla macchina di destinazione. Assicurarsi che i font a cui fa riferimento lo XAML siano disponibili nell'ambiente in cui viene visualizzato.

**Lo XAML esportato è destinato solo a WPF o può essere usato anche in altri stack XAML?**

Aspose.Slides esporta XAML WPF tramite la sua API pubblica. La compatibilità con altri stack XAML, come UWP e Xamarin.Forms, non è garantita. Testare il markup generato nell'ambiente di destinazione.

**Le diapositive nascoste sono supportate e come posso impedire che vengano esportate per impostazione predefinita?**

Per impostazione predefinita, le diapositive nascoste non sono incluse. È possibile controllare questo comportamento tramite [setExportHiddenSlides](https://reference.aspose.com/slides/it/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) in [XamlOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/xamloptions/) — mantenerlo disabilitato se non è necessario esportarle.