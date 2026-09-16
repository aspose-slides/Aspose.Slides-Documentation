---
title: Esporta presentazioni in XAML con Java
linktitle: Presentazione in XAML
type: docs
weight: 30
url: /it/java/export-to-xaml/
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
- Java
- Aspose.Slides
description: "Converti le diapositive PowerPoint e OpenDocument in XAML con Java usando Aspose.Slides—soluzione rapida, senza Office, che mantiene intatto il layout."
---
## **Panoramica**

Questo articolo spiega come esportare presentazioni PowerPoint in XAML usando Aspose.Slides. Include una breve introduzione a XAML, mostra come salvare una presentazione in XAML con le impostazioni predefinite e dimostra come personalizzare l'esportazione tramite [XamlOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/xamloptions/), inclusa l'esportazione delle diapositive nascoste. L'articolo risponde anche a alcune domande comuni relative ai caratteri di fallback, alla compatibilità dello stack XAML e al comportamento dell'esportazione di diapositive nascoste.

## **Informazioni su XAML**

XAML è un linguaggio di markup basato su XML usato per descrivere interfacce utente in framework come WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) e Xamarin.Forms.

È possibile lavorare con i file XAML in un designer visuale o scrivere e modificare il markup direttamente.

## **Esporta presentazioni in XAML con opzioni predefinite**

Il seguente esempio Java mostra come esportare una presentazione in XAML con le impostazioni predefinite:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions xamlOptions = new XamlOptions();
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

Per impostazione predefinita, le diapositive esportate vengono salvate in una sottocartella `pres` della directory di lavoro corrente del processo, risolta da un percorso vuoto con [Paths.get](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Paths.html#get-java.lang.String-java.lang.String...-). La cartella viene creata automaticamente e anche le eventuali immagini necessarie vengono salvate lì.

Il nome della cartella di output è preso dal nome del file sorgente senza la sua estensione. Per `pres.pptx`, i file di output sono denominati `pres/Slide_1.xaml`, `pres/Slide_2.xaml` e così via. Anche se si passa un percorso assoluto alla presentazione di input, la cartella di output viene creata in modo relativo alla directory di lavoro corrente, anziché accanto al file di input.

## **Esporta presentazioni in XAML con opzioni personalizzate**

Usa l'interfaccia [IXamlOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/ixamloptions/) per controllare come Aspose.Slides esporta una presentazione in XAML.

Per salvare l'output in una posizione personalizzata, implementa [IXamlOutputSaver](https://reference.aspose.com/slides/it/java/com.aspose.slides/ixamloutputsaver/) e passa un'istanza della tua implementazione al metodo [setOutputSaver](https://reference.aspose.com/slides/it/java/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) di [XamlOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/xamloptions/).

Per includere le diapositive nascoste nell'output XAML, chiama [setExportHiddenSlides](https://reference.aspose.com/slides/it/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) con `true`, come mostrato nel seguente esempio Java:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions xamlOptions = new XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

## **Cattura tutti gli artefatti XAML generati**

Un'esportazione XAML può produrre un documento XAML per ogni diapositiva esportata più immagini separate e risorse di supporto. Assegna un [IXamlOutputSaver](https://reference.aspose.com/slides/it/java/com.aspose.slides/ixamloutputsaver/) personalizzato a [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/it/java/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) per ricevere questi artefatti invece di utilizzare il salvatore predefinito del file system. Avvia l'esportazione con la sovraccarico specifica XAML di [Presentation.save](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) che accetta le opzioni XAML.

### **Comprendere il ciclo di vita del callback**

L'esportatore chiama [IXamlOutputSaver.save](https://reference.aspose.com/slides/it/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) separatamente per ogni artefatto generato:
- `path` identifica l'artefatto e può includere directory relative. Conserva queste informazioni perché XAML potrebbe fare riferimento a risorse usando percorsi relativi.
- `data` contiene i byte dell'artefatto. Immagini e altre risorse binarie non devono essere decodificate come testo.
- Il salvatore è responsabile di trattenere o persistere i dati prima di restituire. Gli esempi copiano ogni array di byte nella memoria dell'applicazione.
- Considera l'esportazione riuscita solo quando l'operazione di salvataggio della presentazione restituisce e ogni callback è completata con successo. Non nascondere gli errori di archiviazione né avviare scritture in background non osservate. Se la persistenza avviene successivamente, segnala il successo complessivo solo dopo che anche quel passaggio ha avuto esito positivo.

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/it/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) si applica anche a un salvatore personalizzato. L'impostazione predefinita, `false`, esclude i documenti XAML delle diapositive nascoste. Passare `true` li include insieme a tutte le risorse necessarie per la loro esportazione. Il conteggio delle risorse dipende dalla presentazione; non presumere un callback per diapositiva o un ordine fisso dei callback.

### **Esporta in memoria e ispeziona gli artefatti**

Questo esempio completo carica `pres.pptx`, raccoglie ogni artefatto in una [Map<String, byte[]>](https://docs.oracle.com/javase/8/docs/api/java/util/Map.html) e stampa il suo nome, tipo e conteggio dei byte. Conserva esattamente i nomi forniti. Nomi duplicati contrassegnano la raccolta come non valida anziché sovrascrivere silenziosamente un artefatto. L'esempio verifica ciò prima di utilizzare i risultati.

```java
import com.aspose.slides.*;
import java.util.LinkedHashMap;
import java.util.Map;
import java.nio.charset.StandardCharsets;
import java.util.Locale;

class MemoryXamlSaver implements IXamlOutputSaver {
    final Map<String, byte[]> artifacts = new LinkedHashMap<>();
    boolean valid = true;

    @Override
    public void save(String path, byte[] data) {
        if (artifacts.containsKey(path)) {
            valid = false;
            System.err.println("Export rejected: duplicate artifact name: " + path);
            return;
        }
        byte[] retainedData = data.clone();
        artifacts.put(path, retainedData);
    }
}

MemoryXamlSaver saver = new MemoryXamlSaver();
Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions options = new XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(true);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!saver.valid) {
    System.err.println("Export rejected: the artifact collection is invalid.");
    return;
}

boolean inspectXamlText = false;
for (Map.Entry<String, byte[]> artifact : saver.artifacts.entrySet()) {
    String name = artifact.getKey().toLowerCase(Locale.ROOT);
    boolean isXaml = name.endsWith(".xaml");
    boolean isImage = name.matches(".*\\.(png|jpg|jpeg|gif|bmp|tif|tiff|svg)$");
    String kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
    System.out.println(artifact.getKey() + ": " + artifact.getValue().length + " bytes (" + kind + ")");

    // Decodifica solo XAML, e solo quando è necessaria l'ispezione testuale.
    if (isXaml && inspectXamlText) {
        String markup = new String(artifact.getValue(), StandardCharsets.UTF_8);
        System.out.println(markup);
    }
}
```

I controlli di estensione sono utili per l'ispezione; conserva tutti gli artefatti, inclusi i tipi di risorsa sconosciuti. Mantieni i byte invariati durante l'archiviazione o la trasmissione. Usa il [costruttore String](https://docs.oracle.com/javase/8/docs/api/java/lang/String.html#String-byte:A-java.nio.charset.Charset-) con UTF-8 solo per XAML che richiede elaborazione testuale.

### **Impacchetta gli artefatti raccolti in un archivio ZIP**

Questo esempio indipendente raccoglie l'esportazione, convalida i suoi nomi e scrive i byte originali in un archivio ZIP. Un nome di archivio univoco separa i lavori di esportazione concorrenti. Le voci ZIP usano barre oblique e conservano le directory relative. Nomi non sicuri o nomi che collidono dopo la normalizzazione rifiutano l'intero pacchetto prima che venga scritto.

```java
import com.aspose.slides.*;
import java.util.LinkedHashMap;
import java.util.Map;
import java.io.IOException;
import java.io.OutputStream;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.nio.file.StandardOpenOption;
import java.util.Set;
import java.util.TreeSet;
import java.util.UUID;
import java.util.zip.ZipEntry;
import java.util.zip.ZipOutputStream;

class MemoryXamlSaver implements IXamlOutputSaver {
    final Map<String, byte[]> artifacts = new LinkedHashMap<>();
    boolean valid = true;

    @Override
    public void save(String path, byte[] data) {
        if (artifacts.containsKey(path)) {
            valid = false;
            System.err.println("Export rejected: duplicate artifact name: " + path);
            return;
        }
        byte[] retainedData = data.clone();
        artifacts.put(path, retainedData);
    }
}

MemoryXamlSaver saver = new MemoryXamlSaver();
Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions options = new XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(false);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!saver.valid) {
    System.err.println("Export rejected: the artifact collection is invalid.");
    return;
}

Map<String, byte[]> entries = new LinkedHashMap<>();
Set<String> entryNames = new TreeSet<>(String.CASE_INSENSITIVE_ORDER);
for (Map.Entry<String, byte[]> artifact : saver.artifacts.entrySet()) {
    String entryName = artifact.getKey().replace('\\', '/');
    String[] segments = entryName.split("/", -1);
    boolean unsafeName = entryName.startsWith("/") || entryName.contains(":");
    for (String segment : segments) {
        unsafeName |= segment.trim().isEmpty() || segment.equals(".") || segment.equals("..");
    }

    if (unsafeName || !entryNames.add(entryName)) {
        System.err.println("Export rejected: unsafe or duplicate artifact name: " + artifact.getKey());
        return;
    }
    entries.put(entryName, artifact.getValue());
}

Path archivePath = Paths.get("xaml-" + UUID.randomUUID() + ".zip");
try {
    OutputStream output = Files.newOutputStream(archivePath, StandardOpenOption.CREATE_NEW, StandardOpenOption.WRITE);
    try (OutputStream archiveOutput = output; ZipOutputStream archive = new ZipOutputStream(archiveOutput)) {
        for (Map.Entry<String, byte[]> artifact : entries.entrySet()) {
            ZipEntry entry = new ZipEntry(artifact.getKey());
            archive.putNextEntry(entry);
            archive.write(artifact.getValue());
            archive.closeEntry();
        }
    }

    // La directory ZIP è stata finalizzata chiudendo prima di segnalare il successo.
    System.out.println("Saved " + entries.size() + " artifacts to " + archivePath);
} catch (IOException exception) {
    System.err.println("Archive persistence failed: " + exception.getMessage());
}
```

L'esempio utilizza [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) per scrivere un archivio locale; l'esportatore stesso non scrive file XAML o immagini sparsi. Per l'archiviazione remota, sostituisci la fase di scrittura dell'archivio con il caricamento degli array di byte raccolti. Usa un identificatore di job di esportazione più il nome relativo completo dell'artefatto come chiave blob, oppure memorizza l'identificatore del job, il nome relativo e i dati binari in una riga di database. Pubblica il job solo dopo che tutti i caricamenti sono completati o la transazione del database è confermata. Pulisci l'output parziale se la persistenza fallisce.

Per presentazioni di grandi dimensioni, un salvatore personalizzato può persistere ogni artefatto direttamente nello storage dell'applicazione per evitare di mantenere una copia aggiuntiva dell'intera esportazione in memoria. Mantieni ogni callback sincrono dal punto di vista dell'esportatore: restituisci solo dopo che la destinazione ha accettato i byte e consenti che gli errori raggiungano il chiamante.

### **Conserva i nomi delle risorse e verifica i riferimenti**

- Normalizza i separatori di percorso quando la destinazione lo richiede, ma conserva le directory relative. Non usare solo [Path.getFileName](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Path.html#getFileName--) a meno che ogni nome generato sia noto per essere unico e i riferimenti alle risorse rimangano validi.
- Applica la convalida dei nomi specifica per la destinazione. Quando scrivi file separati, rifiuta percorsi radicati e segmenti di traversata, risolvi la destinazione con [Path.toAbsolutePath](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Path.html#toAbsolutePath--), e verifica che rimanga al di sotto della directory di esportazione prevista, includendo il separatore di directory nella verifica di contenimento. Usa una directory controllata dall'applicazione senza link simbolici che potrebbero reindirizzare le scritture.
- Usa un salvatore e uno spazio dei nomi di storage separati per ogni job di esportazione. Rileva le collisioni dopo la normalizzazione dei separatori e secondo le regole di sensibilità al maiuscolo/minuscolo della destinazione.
- Prima di pubblicare, analizza ogni documento XAML come XML e ispeziona i suoi riferimenti alle risorse basate su file, come gli attributi `Source` o `ImageSource` delle immagini. Risolvi ogni URI relativo rispetto alla directory dell'artefatto XAML contenente, normalizza il nome di storage risultante e conferma che la chiave di mappa corrispondente, la voce ZIP o l'oggetto memorizzato esista. Tratta separatamente gli URI esterni e le espressioni di markup XAML rispetto ai nomi di file relativi.

Ad esempio, se `pres/Slide_1.xaml` fa riferimento a `images/image1.png`, la risorsa memorizzata deve essere disponibile come `pres/images/image1.png`. Conservare solo `image1.png` romperebbe tale relazione. Per lo storage a oggetti, mantieni la stessa struttura sotto il prefisso del job e rendi quegli URL di risorsa accessibili al consumatore XAML. Riapri il ZIP completato per verificare i nomi delle voci e i byte delle risorse, e carica diapositive rappresentative nell'ambiente XAML di destinazione per confermare che le immagini vengano risolte correttamente.

## **FAQ**

**Come posso garantire caratteri prevedibili se il carattere originale non è disponibile sulla macchina?**

Chiama [setDefaultRegularFont](https://reference.aspose.com/slides/it/java/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) in [XamlOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/xamloptions/) — viene utilizzato come carattere di fallback durante l'esportazione quando quello originale è mancante. Questo non garantisce che lo XAML generato faccia riferimento al carattere di fallback o che il carattere sia disponibile sulla macchina di destinazione. Assicurati che i caratteri a cui fa riferimento lo XAML siano disponibili nell'ambiente in cui viene visualizzato.

**Lo XAML esportato è destinato solo a WPF o può essere utilizzato anche in altri stack XAML?**

Aspose.Slides esporta XAML WPF tramite la sua API pubblica. La compatibilità con altri stack XAML, come UWP e Xamarin.Forms, non è garantita. Prova il markup generato nel tuo ambiente di destinazione.

**Le diapositive nascoste sono supportate e come posso impedirne l'esportazione per impostazione predefinita?**

Per impostazione predefinita, le diapositive nascoste non sono incluse. Puoi controllare questo comportamento tramite [setExportHiddenSlides](https://reference.aspose.com/slides/it/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) in [XamlOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/xamloptions/) — tienilo disabilitato se non è necessario esportarle.