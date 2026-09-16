---
title: Esporta presentazioni in XAML su Android
linktitle: Presentazione in XAML
type: docs
weight: 30
url: /it/androidjava/export-to-xaml/
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
- Android
- Java
- Aspose.Slides
description: "Converti diapositive PowerPoint e OpenDocument in XAML in Java usando Aspose.Slides per Android — soluzione rapida, senza Office, che conserva intatto il layout."
---
## **Panoramica**

Questo articolo spiega come esportare presentazioni PowerPoint in XAML usando Aspose.Slides per Android via Java. Include una breve introduzione a XAML, mostra come salvare una presentazione in XAML con le impostazioni predefinite e dimostra come personalizzare l'esportazione tramite [XamlOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/xamloptions/), inclusa l'esportazione delle diapositive nascoste. L'articolo risponde anche a alcune domande comuni relative ai caratteri di fallback, alla compatibilità con stack XAML e al comportamento di esportazione delle diapositive nascoste.

## **Informazioni su XAML**

XAML è un linguaggio di markup basato su XML utilizzato per descrivere interfacce utente in framework come WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) e Xamarin.Forms.

È possibile lavorare con file XAML in un designer visuale o scrivere e modificare direttamente il markup.

## **Esportare presentazioni in XAML con le opzioni predefinite**

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

Per impostazione predefinita, le diapositive esportate vengono salvate in una sottocartella `pres` della directory di lavoro corrente del processo. La cartella viene creata automaticamente e anche tutte le immagini richieste vengono salvate lì.

Il nome della cartella di output è ricavato dal nome del file di origine senza estensione. Per `pres.pptx`, i file di output sono nominati `pres/Slide_1.xaml`, `pres/Slide_2.xaml` e così via. Anche se si passa un percorso assoluto alla presentazione di input, la cartella di output viene creata in relazione alla directory di lavoro corrente, non accanto al file di input.

Su Android, utilizzare un file di input accessibile dall'app. La directory di lavoro corrente potrebbe non essere scrivibile; utilizzare un salvatore di output personalizzato per mantenere l'esportazione in memoria o scriverla nello storage dell'app, come mostrato di seguito. Lo XAML WPF generato è destinato a un consumatore compatibile e non è una risorsa di layout Android.

## **Esportare presentazioni in XAML con opzioni personalizzate**

Usare l'interfaccia [IXamlOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ixamloptions/) per controllare come Aspose.Slides esporta una presentazione in XAML.

Per salvare l'output in una posizione personalizzata, implementare [IXamlOutputSaver](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ixamloutputsaver/) e passare un'istanza della propria implementazione al metodo [setOutputSaver](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) di [XamlOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/xamloptions/).

Per includere le diapositive nascoste nell'output XAML, chiamare [setExportHiddenSlides](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) con `true`, come mostrato nel seguente esempio Java:

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

## **Catturare tutti gli artefatti XAML generati**

Un'esportazione XAML può produrre un documento XAML per ogni diapositiva esportata più immagini separate e risorse di supporto. Assegnare un [IXamlOutputSaver](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ixamloutputsaver/) personalizzato a [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) per ricevere questi artefatti anziché utilizzare il salvatore predefinito del file system. Avviare l'esportazione con la sovraccarico XAML‑specifica di [Presentation.save](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) che accetta le opzioni XAML.

### **Comprendere il ciclo di vita del callback**

L'esportatore chiama [IXamlOutputSaver.save](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) separatamente per ogni artefatto generato:

- `path` identifica l'artefatto e può includere directory relative. Conservare queste informazioni perché XAML può fare riferimento a risorse usando percorsi relativi.
- `data` contiene i byte dell'artefatto. Immagini e altre risorse binarie non devono essere decodificate come testo.
- Il salvatore è responsabile di mantenere o persistere i dati prima di restituire. Gli esempi copiano ogni array di byte nella memoria di proprietà dell'applicazione.
- Considerare l'esportazione riuscita solo quando l'operazione di salvataggio della presentazione restituisce e ogni callback è completato correttamente. Non ignorare errori di storage né avviare scritture in background non monitorate. Se la persistenza avviene successivamente, segnalare il successo complessivo solo dopo che anche quel passo è riuscito.

[​XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) si applica anche a un salvatore personalizzato. L'impostazione predefinita, `false`, esclude i documenti XAML delle diapositive nascoste. Impostare `true` le include insieme a tutte le risorse necessarie per la loro esportazione. Il numero di risorse dipende dalla presentazione; non assumere un callback per diapositiva o un ordine fisso dei callback.

### **Esportare in memoria e ispezionare gli artefatti**

Questo esempio completo carica `pres.pptx`, raccoglie ogni artefatto in una [Map<String, byte[]>](https://docs.oracle.com/javase/8/docs/api/java/util/Map.html) e stampa il suo nome, tipo e conteggio byte. Preserva esattamente i nomi forniti. Nomi duplicati invalidano la collezione anziché sovrascrivere silenziosamente un artefatto. L'esempio verifica ciò prima di utilizzare i risultati.

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

I controlli di estensione sono utili per l'ispezione; conservare tutti gli artefatti, inclusi tipi di risorse sconosciuti. Lasciare i byte invariati durante la memorizzazione o la trasmissione. Usare il costruttore [String](https://docs.oracle.com/javase/8/docs/api/java/lang/String.html#String-byte:A-java.nio.charset.Charset-) con UTF‑8 solo per XAML che necessita di elaborazione testuale.

### **Imballare gli artefatti raccolti in un archivio ZIP**

Questo esempio indipendente raccoglie l'esportazione, ne valida i nomi e scrive i byte originali in un archivio ZIP. Sostituire `/path/to/app/files` con il percorso restituito dal metodo [getFilesDir](https://developer.android.com/reference/android/content/Context#getFilesDir()) del contesto Android. Un nome di archivio unico separa i lavori di esportazione concorrenti. Le voci ZIP usano slash (`/`) e conservano le directory relative. Nomi non sicuri o che collidono dopo la normalizzazione rifiutano l'intero pacchetto prima della scrittura.

```java
import com.aspose.slides.*;
import java.util.LinkedHashMap;
import java.util.Map;
import java.io.IOException;
import java.io.File;
import java.io.FileOutputStream;
import java.util.Set;
import java.util.TreeSet;
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

File exportDirectory = new File("/path/to/app/files");
try {
    File archiveFile = File.createTempFile("xaml-", ".zip", exportDirectory);
    try (FileOutputStream archiveOutput = new FileOutputStream(archiveFile); ZipOutputStream archive = new ZipOutputStream(archiveOutput)) {
        for (Map.Entry<String, byte[]> artifact : entries.entrySet()) {
            ZipEntry entry = new ZipEntry(artifact.getKey());
            archive.putNextEntry(entry);
            archive.write(artifact.getValue());
            archive.closeEntry();
        }
    }

    // La directory ZIP è stata finalizzata chiudendo prima di segnalare il successo.
    System.out.println("Saved " + entries.size() + " artifacts to " + archiveFile);
} catch (IOException exception) {
    System.err.println("Archive persistence failed: " + exception.getMessage());
}
```

L'esempio utilizza [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) per scrivere un archivio locale; l'esportatore stesso non scrive file XAML o immagini sparsi. Per lo storage remoto, sostituire la fase di scrittura dell'archivio con upload degli array di byte raccolti. Usare un identificatore del lavoro di esportazione più il nome relativo completo dell'artefatto come chiave blob, oppure memorizzare l'identificatore, il nome relativo e i dati binari in una riga di database. Pubblicare il lavoro solo dopo che tutti gli upload sono completati o la transazione del database è confermata. Pulire l'output parziale se la persistenza fallisce.

Per presentazioni di grandi dimensioni, un salvatore personalizzato può persistere ogni artefatto direttamente nello storage dell'applicazione per evitare di mantenere una copia aggiuntiva dell'intera esportazione in memoria. Mantenere ogni callback sincrono dal punto di vista dell'esportatore: restituire solo dopo che la destinazione ha accettato i byte e consentire che gli errori raggiungano il chiamante.

### **Conservare i nomi delle risorse e verificare i riferimenti**

- Normalizzare i separatori di percorso quando la destinazione lo richiede, ma preservare le directory relative. Non usare solo [File.getName](https://developer.android.com/reference/java/io/File#getName()) a meno che ogni nome generato sia noto per essere unico e i riferimenti alle risorse rimangano validi.
- Applicare la validazione dei nomi specifica della destinazione. Quando si scrivono file sparsi, rifiutare percorsi radicati e segmenti di traversata, risolvere la destinazione con [File.getCanonicalPath](https://developer.android.com/reference/java/io/File#getCanonicalPath()) e verificare che rimanga sotto la directory di esportazione prevista, includendo il separatore di directory nella verifica di contenimento. Usare una directory controllata dall'applicazione senza link simbolici che possano reindirizzare le scritture.
- Utilizzare un salvatore e uno spazio dei nomi di storage separati per ogni lavoro di esportazione. Rilevare collisioni dopo la normalizzazione dei separatori e secondo le regole di case‑sensitivity della destinazione.
- Prima della pubblicazione, analizzare ogni documento XAML come XML e ispezionare i riferimenti a risorse basate su file, come gli attributi `Source` o `ImageSource`. Risolvere ogni URI relativo rispetto alla directory dell'artefatto XAML contenente, normalizzare il nome di storage risultante e confermare che la chiave della mappa corrispondente, la voce ZIP o l'oggetto memorizzato esista. Trattare separatamente URI esterni e espressioni di markup XAML rispetto ai nomi di file relativi.

Ad esempio, se `pres/Slide_1.xaml` fa riferimento a `images/image1.png`, la risorsa memorizzata deve essere disponibile come `pres/images/image1.png`. Conservare solo `image1.png` romperebbe tale relazione. Per lo storage di oggetti, mantenere la stessa struttura sotto il prefisso del lavoro e rendere quegli URL di risorsa accessibili al consumatore XAML. Riaprire il ZIP completato per verificare i nomi delle voci e i byte delle risorse, e caricare diapositive rappresentative nell'ambiente XAML di destinazione per confermare che le immagini vengano risolte correttamente.

## **FAQ**

**Come posso garantire caratteri prevedibili se il carattere originale non è disponibile sulla macchina?**

Chiamare [setDefaultRegularFont](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) in [XamlOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/xamloptions/) — viene usato come carattere di fallback durante l'esportazione quando quello originale è mancante. Questo non garantisce che lo XAML generato faccia riferimento al carattere di fallback o che il carattere sia disponibile sulla macchina target. Assicurarsi che i caratteri referenziati dallo XAML siano disponibili nell'ambiente in cui viene visualizzato.

**Lo XAML esportato è destinato solo a WPF o può essere usato anche in altri stack XAML?**

Aspose.Slides esporta XAML WPF tramite la sua API pubblica. La compatibilità con altri stack XAML, come UWP e Xamarin.Forms, non è garantita. Testare il markup generato nell'ambiente di destinazione.

**Le diapositive nascoste sono supportate e come posso impedirne l'esportazione per impostazione predefinita?**

Per impostazione predefinita, le diapositive nascoste non sono incluse. È possibile controllare questo comportamento tramite [setExportHiddenSlides](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) in [XamlOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/xamloptions/) — mantenerlo disabilitato se non si ha bisogno di esportarle.