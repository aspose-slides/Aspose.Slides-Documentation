---
title: Esporta presentazioni in XAML con JavaScript
linktitle: Presentazione in XAML
type: docs
weight: 30
url: /it/nodejs-java/export-to-xaml/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Converti diapositive PowerPoint e OpenDocument in XAML con JavaScript usando Aspose.Slides—soluzione rapida, senza Office, che mantiene intatto il layout."
---
## **Panoramica**

Questo articolo spiega come esportare presentazioni PowerPoint in XAML utilizzando Aspose.Slides. Include una breve introduzione a XAML, mostra come salvare una presentazione in XAML con le impostazioni predefinite e dimostra come personalizzare l’esportazione tramite [XamlOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/xamloptions/), incluso l’esportazione di diapositive nascoste. L’articolo risponde inoltre a alcune domande comuni relative ai font di fallback, alla compatibilità con le varie stack XAML e al comportamento di esportazione delle diapositive nascoste.

## **Informazioni su XAML**

XAML è un linguaggio di markup basato su XML usato per descrivere interfacce utente in framework come WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) e Xamarin.Forms.

È possibile lavorare con i file XAML in un designer visuale oppure scrivere e modificare il markup direttamente.

## **Esporta presentazioni in XAML con le opzioni predefinite**

Il seguente esempio JavaScript mostra come esportare una presentazione in XAML con le impostazioni predefinite:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xamlOptions = new aspose.slides.XamlOptions();
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

Per impostazione predefinita, le diapositive esportate vengono salvate in una sottocartella `input` della directory di lavoro corrente del processo. La cartella viene creata automaticamente e anche le eventuali immagini richieste vengono salvate lì.

Il nome della cartella di output è ricavato dal nome del file di origine senza estensione. In Aspose.Slides per Node.js via Java 26.8, l’esportazione di `input.pptx` produce un percorso annidato come `input/input/Slide_1.xaml`. Conserva i percorsi completi generati quando gestisci l’output. L’output predefinito è relativo alla directory di lavoro corrente, non necessariamente accanto al file di input.

## **Esporta presentazioni in XAML con opzioni personalizzate**

Usa l’interfaccia [IXamlOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/ixamloptions/) per controllare come Aspose.Slides esporta una presentazione in XAML.

Per salvare l’output in una posizione personalizzata, implementa [IXamlOutputSaver](https://reference.aspose.com/slides/it/java/com.aspose.slides/ixamloutputsaver/) e passa un’istanza della tua implementazione al metodo [setOutputSaver](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) di [XamlOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/xamloptions/).

Per includere le diapositive nascoste nell’output XAML, chiama [setExportHiddenSlides](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) con `true`, come mostrato nel seguente esempio JavaScript:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xamlOptions = new aspose.slides.XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

## **Cattura tutti gli artefatti XAML generati**

Un’esportazione XAML può produrre un documento XAML per ogni diapositiva esportata più immagini separate e risorse di supporto. Assegna un [IXamlOutputSaver](https://reference.aspose.com/slides/it/java/com.aspose.slides/ixamloutputsaver/) personalizzato a [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) per ricevere questi artefatti invece di utilizzare il salvataggio predefinito sul file system. Avvia l’esportazione con la sovraccarico XAML‑specifico di [Presentation.save](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#save) che accetta le opzioni XAML.

In Node.js, implementa l’interfaccia Java con `java.newProxy` dal pacchetto `java` usato da Aspose.Slides. Mantieni il proxy raggiungibile finché l’esportazione non è completata.

### **Comprendere il ciclo di vita del callback**

L’esportatore chiama [IXamlOutputSaver.save](https://reference.aspose.com/slides/it/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) separatamente per ogni artefatto generato:

- `path` identifica l’artefatto e può includere directory relative. Conserva queste informazioni perché XAML può fare riferimento a risorse usando percorsi relativi.
- `data` contiene i byte dell’artefatto. Immagini e altre risorse binarie non devono essere decodificate come testo.
- Il salvatore è responsabile di preservare o persistere i dati prima di restituire. Gli esempi copiano ogni array di byte Java in un buffer Node.js di proprietà dell’applicazione.
- Considera l’esportazione riuscita solo quando l’operazione di salvataggio della presentazione restituisce e tutti i callback sono completati con successo. Non ignorare errori di archiviazione né avviare scritture in background non monitorate. Se la persistenza avviene successivamente, segnala il successo complessivo solo dopo che anche quel passaggio è riuscito.

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) si applica anche a un salvatore personalizzato. L’impostazione predefinita, `false`, esclude i documenti XAML delle diapositive nascoste. Passare `true` li include insieme a tutte le risorse necessarie per la loro esportazione. Il conteggio delle risorse dipende dalla presentazione; non presumere un callback per diapositiva o un ordine fisso dei callback.

### **Esporta in memoria e ispeziona gli artefatti**

Questo esempio completo carica `input.pptx`, raccoglie ogni artefatto in una mappa JavaScript di nomi a buffer e stampa il nome, il tipo e il conteggio dei byte. Mantiene i nomi forniti esattamente. Nomi duplicati invalidano la collezione anziché sovrascrivere silenziosamente un artefatto. L’esempio verifica ciò prima di utilizzare i risultati.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const artifacts = new Map();
let valid = true;
const saver = java.newProxy("com.aspose.slides.IXamlOutputSaver", {
    save: function(path, data) {
        const name = String(path);
        if (artifacts.has(name)) {
            valid = false;
            console.error("Export rejected: duplicate artifact name: " + name);
            return;
        }
        const retainedData = Buffer.from(data);
        artifacts.set(name, retainedData);
    }
});

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(true);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!valid) {
    console.error("Export rejected: the artifact collection is invalid.");
} else {
    const inspectXamlText = false;
    for (const [name, data] of artifacts) {
        const isXaml = /\.xaml$/i.test(name);
        const isImage = /\.(png|jpg|jpeg|gif|bmp|tif|tiff|svg)$/i.test(name);
        const kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
        console.log(name + ": " + data.length + " bytes (" + kind + ")");

        // Decodifica solo XAML, e solo quando è necessaria l'ispezione testuale.
        if (isXaml && inspectXamlText) {
            console.log(data.toString("utf8"));
        }
    }
}
```

I controlli di estensione sono utili per l’ispezione; conserva tutti gli artefatti, inclusi i tipi di risorsa sconosciuti. Lascia i byte invariati quando li archivi o li trasmetti. Usa la decodifica UTF‑8 solo per XAML che necessita di elaborazione testuale.

### **Confeziona gli artefatti raccolti in un archivio ZIP**

Questo esempio autonomo raccoglie l’esportazione, ne valida i nomi e scrive i byte originali in un archivio ZIP usando il bridge Java. Lo ZIP è assemblato in memoria prima di essere salvato su disco. Un nome di archivio univoco separa i job di esportazione concorrenti. Le voci ZIP usano la barra normale (`/`) e mantengono le directory relative. Nomi non sicuri o nomi che collidono dopo la normalizzazione rifiutano l’intero pacchetto prima della scrittura.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const artifacts = new Map();
let valid = true;
const saver = java.newProxy("com.aspose.slides.IXamlOutputSaver", {
    save: function(path, data) {
        const name = String(path);
        if (artifacts.has(name)) {
            valid = false;
            console.error("Export rejected: duplicate artifact name: " + name);
            return;
        }
        const retainedData = Buffer.from(data);
        artifacts.set(name, retainedData);
    }
});

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(false);
    presentation.save(options);
} finally {
    presentation.dispose();
}

const entries = new Map();
const entryNames = new Set();
for (const [name, data] of artifacts) {
    const entryName = name.replace(/\\/g, "/");
    const segments = entryName.split("/");
    const unsafeName = entryName.startsWith("/") || entryName.includes(":") || segments.some(segment => segment.trim() === "" || segment === "." || segment === "..");
    const comparisonName = entryName.toLowerCase();
    if (unsafeName || entryNames.has(comparisonName)) {
        valid = false;
        console.error("Export rejected: unsafe or duplicate artifact name: " + name);
        break;
    }
    entryNames.add(comparisonName);
    entries.set(entryName, data);
}

if (!valid) {
    console.error("Export rejected: the artifact collection is invalid.");
} else {
    const fs = require("node:fs");
    const crypto = require("node:crypto");
    const archivePath = "xaml-" + crypto.randomUUID() + ".zip";
    const output = java.newInstanceSync("java.io.ByteArrayOutputStream");
    const archive = java.newInstanceSync("java.util.zip.ZipOutputStream", output);
    try {
        for (const [name, data] of entries) {
            const entry = java.newInstanceSync("java.util.zip.ZipEntry", name);
            archive.putNextEntry(entry);
            const signedBytes = Array.from(data, value => value > 127 ? value - 256 : value);
            const bytes = java.newArray("byte", signedBytes);
            archive.write(bytes);
            archive.closeEntry();
        }
    } finally {
        archive.close();
    }

    // La chiusura finalizza la directory ZIP prima che l'archivio venga salvato.
    const archiveData = Buffer.from(output.toByteArray());
    try {
        fs.writeFileSync(archivePath, archiveData, { flag: "wx" });
        console.log("Saved " + entries.size + " artifacts to " + archivePath);
    } catch (error) {
        console.error("Archive persistence failed: " + error.message);
    }
}
```

L’esempio usa [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) per scrivere un archivio locale; l’esportatore stesso non scrive file XAML o immagini separati. Per lo storage remoto, sostituisci la fase di scrittura dell’archivio con upload degli array di byte raccolti. Usa un identificatore di job di esportazione più il nome relativo completo dell’artefatto come chiave blob, oppure memorizza l’identificatore del job, il nome relativo e i dati binari in una riga di database. Pubblica il job solo dopo che tutti gli upload sono completati o la transazione del database è confermata. Pulisci l’output parziale se la persistenza fallisce.

Per presentazioni di grandi dimensioni, un salvatore personalizzato può persistere ogni artefatto direttamente nello storage dell’applicazione per evitare di mantenere una copia aggiuntiva dell’intera esportazione in memoria. Mantieni ogni callback sincrono dal punto di vista dell’esportatore: restituisci solo dopo che la destinazione ha accettato i byte e consenti ai fallimenti di raggiungere il chiamante.

### **Preserva i nomi delle risorse e verifica i riferimenti**

- Normalizza i separatori di percorso quando la destinazione lo richiede, ma conserva le directory relative. Non utilizzare solo il nome base a meno che tutti i nomi generati siano noti per essere unici e i riferimenti alle risorse rimangano validi.
- Applica la convalida dei nomi specifica della destinazione. Quando scrivi file sparsi, rifiuta percorsi assoluti e segmenti di traversata, risolvi la destinazione in un percorso assoluto e verifica che rimanga sotto la directory di esportazione prevista, includendo il separatore di directory nel controllo di contenimento. Usa una directory controllata dall’applicazione senza link simbolici che possano reindirizzare le scritture.
- Usa un salvatore e uno spazio di nomi di storage separati per ogni job di esportazione. Rileva collisioni dopo la normalizzazione dei separatori e secondo le regole di sensibilità al caso della destinazione.
- Prima della pubblicazione, analizza ogni documento XAML come XML e ispeziona i riferimenti a risorse basati su file, come gli attributi `Source` o `ImageSource` delle immagini. Risolvi ogni URI relativa rispetto alla directory dell’artefatto XAML contenente, normalizza il nome di storage risultante e conferma che la chiave della mappa corrispondente, la voce ZIP o l’oggetto memorizzato esista. Tratta separatamente gli URI esterni e le espressioni di markup XAML rispetto ai nomi di file relativi.

Ad esempio, se `input/Slide_1.xaml` fa riferimento a `images/image1.png`, la risorsa memorizzata deve essere disponibile come `input/images/image1.png`. Conservare solo `image1.png` romperebbe tale relazione. Per lo storage a oggetti, mantieni lo stesso layout sotto il prefisso del job e rendi quegli URL delle risorse accessibili al consumer XAML. Riapri lo ZIP completato per verificare i nomi delle voci e i byte delle risorse, e carica diapositive rappresentative nell’ambiente XAML di destinazione per confermare che le immagini vengano risolte correttamente.

## **FAQ**

**Come posso garantire font prevedibili se il font originale non è disponibile sulla macchina?**

Chiama [setDefaultRegularFont](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) in [XamlOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/xamloptions/) — viene usato come font di fallback durante l’esportazione quando l’originale è mancante. Questo non garantisce che lo XAML generato faccia riferimento al font di fallback o che il font sia disponibile sulla macchina di destinazione. Assicurati che i font a cui fa riferimento lo XAML siano presenti nell’ambiente in cui viene visualizzato.

**Lo XAML esportato è destinato solo a WPF o può essere usato anche in altre stack XAML?**

Aspose.Slides esporta XAML WPF tramite la sua API pubblica. La compatibilità con altre stack XAML, come UWP e Xamarin.Forms, non è garantita. Testa il markup generato nel tuo ambiente di destinazione.

**Le diapositive nascoste sono supportate e come posso impedirne l’esportazione per impostazione predefinita?**

Per impostazione predefinita, le diapositive nascoste non sono incluse. Puoi controllare questo comportamento tramite [setExportHiddenSlides](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) in [XamlOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/xamloptions/) — mantienilo disabilitato se non è necessario esportarle.