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
description: "Converti le diapositive PowerPoint e OpenDocument in XAML con JavaScript usando Aspose.Slides—soluzione rapida, senza Office, che mantiene intatto il layout."
---
## **Panoramica**

Questo articolo spiega come esportare presentazioni PowerPoint in XAML usando Aspose.Slides. Include una breve introduzione a XAML, mostra come salvare una presentazione in XAML con impostazioni predefinite e dimostra come personalizzare l'esportazione tramite [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/), includendo l'esportazione delle diapositive nascoste. L'articolo risponde anche a alcune domande comuni relative ai font di riserva, alla compatibilità dello stack XAML e al comportamento dell'esportazione delle diapositive nascoste.

## **Informazioni su XAML**

XAML è un linguaggio di markup basato su XML usato per descrivere le interfacce utente in framework come WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) e Xamarin.Forms.

È possibile lavorare con i file XAML in un designer visuale o scrivere e modificare direttamente il markup.

## **Esporta presentazioni in XAML con opzioni predefinite**

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

Per impostazione predefinita, le diapositive esportate vengono salvate in una sottocartella `input` della directory di lavoro corrente del processo. La cartella viene creata automaticamente e anche tutte le immagini necessarie vengono salvate lì.

Il nome della cartella di output viene preso dal nome del file sorgente senza estensione. In Aspose.Slides for Node.js via Java 26.8, l'esportazione di `input.pptx` produce un percorso annidato come `input/input/Slide_1.xaml`. Conserva i percorsi generati completi quando gestisci l'output. L'output predefinito è relativo alla directory di lavoro corrente, piuttosto che necessariamente accanto al file di input.

## **Esporta presentazioni in XAML con opzioni personalizzate**

Usa l'interfaccia [IXamlOptions](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloptions/) per controllare come Aspose.Slides esporta una presentazione in XAML.

Per salvare l'output in una posizione personalizzata, implementa [IXamlOutputSaver](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/) e passa un'istanza della tua implementazione al metodo [setOutputSaver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) di [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/).

Per includere le diapositive nascoste nell'output XAML, chiama [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) con `true`, come mostrato nel seguente esempio JavaScript:

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

## **Acquisisci tutti gli artefatti XAML generati**

Un'esportazione XAML può generare un documento XAML per ciascuna diapositiva esportata più immagini separate e risorse di supporto. Assegna un [IXamlOutputSaver](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/) personalizzato a [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) per ricevere questi artefatti invece di utilizzare il salvataggio predefinito sul filesystem. Avvia l'esportazione con il sovraccarico specifico XAML di [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save) che accetta le opzioni XAML.

In Node.js, implementa l'interfaccia Java con `java.newProxy` dal pacchetto `java` utilizzato da Aspose.Slides. Mantieni il proxy raggiungibile fino al completamento dell'esportazione.

### **Comprendi il ciclo di vita del callback**

L'esportatore chiama [IXamlOutputSaver.save](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) separatamente per ogni artefatto generato:

- `path` identifica l'artefatto e può includere directory relative. Conserva queste informazioni perché XAML potrebbe fare riferimento a risorse usando percorsi relativi.
- `data` contiene i byte dell'artefatto. Immagini e altre risorse binarie non devono essere decodificate come testo.
- Il salvatore è responsabile di conservare o persistere i dati prima di restituire. Gli esempi copiano ogni array di byte Java in un buffer Node.js di proprietà dell'applicazione.
- Considera l'esportazione riuscita solo quando l'operazione di salvataggio della presentazione restituisce e ogni callback è terminata con successo. Non sopprimere gli errori di memorizzazione né avviare scritture in background non osservate. Se la persistenza avviene successivamente, segnala il successo complessivo solo dopo che anche quel passaggio è riuscito.

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) si applica anche a un salvatore personalizzato. L'impostazione predefinita, `false`, esclude i documenti XAML delle diapositive nascoste. Passare `true` li include insieme a tutte le risorse necessarie per la loro esportazione. Il conteggio delle risorse dipende dalla presentazione; non presumere un callback per diapositiva o un ordine fisso dei callback.

### **Esporta in memoria e ispeziona gli artefatti**

Questo esempio completo carica `input.pptx`, raccoglie ogni artefatto in una mappa JavaScript di nomi a buffer e stampa il suo nome, tipo e conteggio dei byte. Conserva esattamente i nomi forniti. I nomi duplicati segnano la collezione come non valida invece di sovrascrivere silenziosamente un artefatto. L'esempio verifica ciò prima di utilizzare i risultati.

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

        // Decodifica solo XAML, e solo quando è necessaria un'ispezione testuale.
        if (isXaml && inspectXamlText) {
            console.log(data.toString("utf8"));
        }
    }
}
```

I controlli di estensione sono utili per l'ispezione; conserva tutti gli artefatti, inclusi i tipi di risorse non familiari. Lascia i byte invariati durante l'archiviazione o la trasmissione. Usa la decodifica UTF-8 solo per XAML che richiede elaborazione testuale.

### **Imballa gli artefatti raccolti in un archivio ZIP**

Questo esempio indipendente raccoglie l'esportazione, valida i suoi nomi e scrive i byte originali in un archivio ZIP usando il ponte Java. Il ZIP viene assemblato in memoria prima di essere salvato su disco. Un nome di archivio unico separa i lavori di esportazione concorrenti. Le voci ZIP usano barre oblique forward e conservano le directory relative. Nomi non sicuri o nomi che collidono dopo la normalizzazione rifiutano l'intero pacchetto prima della scrittura.

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
            const bytes = java.newArray("byte", Array.from(data));
            archive.write(bytes);
            archive.closeEntry();
        }
    } finally {
        archive.close();
    }

    // La chiusura finalizza la directory ZIP prima che l'archivio sia persistito.
    const archiveData = Buffer.from(output.toByteArray());
    try {
        fs.writeFileSync(archivePath, archiveData, { flag: "wx" });
        console.log("Saved " + entries.size + " artifacts to " + archivePath);
    } catch (error) {
        console.error("Archive persistence failed: " + error.message);
    }
}
```

L'esempio utilizza [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) per scrivere un archivio locale; l'esportatore stesso non scrive file XAML o immagini sparsi. Per l'archiviazione remota, sostituisci la fase di scrittura dell'archivio con caricamenti degli array di byte raccolti. Usa un identificatore del lavoro di esportazione più il nome relativo completo dell'artefatto come chiave blob, oppure memorizza l'identificatore del lavoro, il nome relativo e i dati binari in una riga di database. Pubblica il lavoro solo dopo che tutti i caricamenti sono completati o la transazione del database è confermata. Pulisci l'output parziale se la persistenza fallisce.

Per presentazioni di grandi dimensioni, un salvatore personalizzato può persistere ogni artefatto direttamente nello storage dell'applicazione per evitare di mantenere una copia aggiuntiva dell'intera esportazione nella memoria dell'applicazione. Mantieni ogni callback sincrono dal punto di vista dell'esportatore: restituisci solo dopo che la destinazione ha accettato i byte e consenti ai fallimenti di raggiungere il chiamante.

### **Conserva i nomi delle risorse e verifica i riferimenti**

- Normalizza i separatori di percorso quando la destinazione lo richiede, ma conserva le directory relative. Non usare solo il nome base a meno che ogni nome generato sia noto per essere unico e i riferimenti alle risorse rimangano validi.
- Applica la convalida dei nomi specifica per la destinazione. Quando scrivi file sparsi, rifiuta percorsi radicati e segmenti di traversata, risolvi la destinazione in un percorso assoluto e verifica che rimanga sotto la directory di esportazione prevista, includendo il separatore di directory nel controllo di contenimento. Usa una directory controllata dall'applicazione senza collegamenti simbolici che potrebbero reindirizzare le scritture.
- Usa un salvatore e uno spazio dei nomi di storage separati per ogni lavoro di esportazione. Rileva collisioni dopo la normalizzazione dei separatori e secondo le regole di sensibilità al caso della destinazione.
- Prima di pubblicare, analizza ogni documento XAML come XML e ispeta i suoi riferimenti a risorse basati su file, come gli attributi `Source` o `ImageSource` delle immagini. Risolvi ogni URI relativo rispetto alla directory dell'artefatto XAML contenente, normalizza il nome di storage risultante e conferma che la chiave della mappa corrispondente, l'entry ZIP o l'oggetto memorizzato esista. Tratta gli URI esterni e le espressioni di markup XAML separatamente dai nomi di file relativi.

Ad esempio, se `input/Slide_1.xaml` fa riferimento a `images/image1.png`, la risorsa memorizzata deve essere disponibile come `input/images/image1.png`. Conservare solo `image1.png` romperebbe quella relazione. Per lo storage di oggetti, conserva la stessa struttura sotto il prefisso del lavoro e rendi quegli URL di risorsa accessibili al consumatore XAML. Riabbassa il ZIP completato per verificare i nomi delle voci e i byte delle risorse, e carica diapositive rappresentative nell'ambiente XAML di destinazione per confermare che le immagini si risolvano correttamente.

## **FAQ**

**Come posso garantire font prevedibili se il font originale non è disponibile sulla macchina?**

Chiama [setDefaultRegularFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) in [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) — viene usato come font di riserva durante l'esportazione quando l'originale è mancante. Ciò non garantisce che lo XAML generato faccia riferimento al font di riserva o che il font sia disponibile sulla macchina di destinazione. Assicurati che i font a cui fa riferimento lo XAML siano disponibili nell'ambiente in cui viene visualizzato.

**Lo XAML esportato è destinato solo a WPF o può essere usato anche in altri stack XAML?**

Aspose.Slides esporta XAML WPF tramite la sua API pubblica. La compatibilità con altri stack XAML, come UWP e Xamarin.Forms, non è garantita. Prova il markup generato nel tuo ambiente di destinazione.

**Le diapositive nascoste sono supportate e come posso impedirne l'esportazione per impostazione predefinita?**

Per impostazione predefinita, le diapositive nascoste non sono incluse. Puoi controllare questo comportamento tramite [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) in [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) — mantienilo disabilitato se non devi esportarle.