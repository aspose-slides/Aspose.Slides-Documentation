---
title: Personalizza i caratteri PowerPoint in PHP
linktitle: Carattere personalizzato
type: docs
weight: 20
url: /it/php-java/custom-font/
keywords:
- carattere
- font personalizzato
- font esterno
- carica font
- gestisci font
- cartella dei font
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Personalizza i caratteri nelle diapositive PowerPoint con Aspose.Slides per PHP tramite Java per mantenere le tue presentazioni nitide e coerenti su qualsiasi dispositivo."
---
## **Panoramica**

Aspose.Slides consente di utilizzare caratteri personalizzati nelle presentazioni senza installarli sul sistema operativo. È possibile caricare i caratteri da cartelle personalizzate, fornire caratteri per una presentazione specifica tramite sorgenti di caratteri a livello di documento, o caricare caratteri esterni direttamente da dati binari.

I caratteri caricati vengono utilizzati quando una presentazione viene renderizzata o esportata, ad esempio in PDF, immagini e altri formati supportati. Questo aiuta a mantenere l'output della presentazione coerente tra diversi ambienti. L'articolo spiega anche come ispezionare le cartelle dei caratteri utilizzate da Aspose.Slides e come svuotare la cache dei caratteri dopo aver lavorato con caratteri esterni.

La registrazione di caratteri personalizzati per il rendering è separata dall'incorporamento dei caratteri in un file PPTX. Se un carattere deve essere memorizzato all'interno della presentazione stessa, utilizzare esplicitamente le funzionalità di incorporamento dei caratteri.

Un tema di presentazione può fare riferimento a diverse famiglie di caratteri per i singoli sistemi di scrittura. Queste mappature memorizzano i nomi dei caratteri ma non installano né caricano i file dei caratteri. Vedi [Script-Specific Theme Fonts](/slides/it/php-java/script-specific-font-mappings/) per gestire le mappature e utilizza le opzioni di caricamento qui sotto per rendere i caratteri di riferimento disponibili per un rendering coerente.

{{% alert color="info" title="Nota" %}}
Aspose Slides consente di caricare questi caratteri utilizzando il metodo [loadExternalFonts](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* Caratteri TrueType (.ttf) e TrueType Collection (.ttc). Vedi [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Caratteri OpenType (.otf). Vedi [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **Carica Caratteri Personalizzati**

Aspose.Slides consente di caricare i caratteri utilizzati in una presentazione senza installarli sul sistema. Questo influisce sull'output di esportazione — come PDF, immagini e altri formati supportati — in modo che i documenti risultanti abbiano un aspetto coerente tra gli ambienti. I caratteri vengono caricati da directory personalizzate.

1. Specificare una o più cartelle che contengono i file dei caratteri.
2. Chiamare il metodo statico [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) per caricare i caratteri da quelle cartelle.
3. Caricare e renderizzare/esportare la presentazione.
4. Chiamare [FontsLoader::clearCache](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontsloader/#clearCache--) per svuotare la cache dei caratteri.

Il seguente esempio di codice dimostra il processo di caricamento dei caratteri:

```php
// Definisci le cartelle che contengono file di caratteri personalizzati.
$externalFontFolder1 = __DIR__ . "/external-fonts-1";
$externalFontFolder2 = __DIR__ . "/external-fonts-2";
$fontFolders = array($externalFontFolder1, $externalFontFolder2);

// Load custom fonts from the specified folders.
FontsLoader::loadExternalFonts($fontFolders);

$presentation = null;
try {
    $presentationPath = __DIR__ . "/sample.pptx";
    $presentation = new Presentation($presentationPath);
    
    // Renderizza/esporta la presentazione (ad esempio in PDF, immagini o altri formati) usando i caratteri caricati.
    $outputPath = __DIR__ . "/output.pdf";
    $presentation->save($outputPath, SaveFormat::Pdf);
} finally {
    if ($presentation != null) $presentation->dispose();

    // Svuota la cache dei caratteri dopo aver terminato il lavoro.
    FontsLoader::clearCache();
}
```

{{% alert color="info" title="Nota" %}}
[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) aggiunge cartelle aggiuntive ai percorsi di ricerca dei caratteri, ma non modifica l'ordine di inizializzazione dei caratteri.
I caratteri sono inizializzati in questo ordine:

1. Il percorso predefinito dei caratteri del sistema operativo.
2. I percorsi caricati tramite [FontsLoader](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontsloader/).
{{%/alert %}}

## **Ottieni Cartelle dei Caratteri Personalizzati**
Aspose.Slides fornisce il metodo [getFontFolders](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontsloader/#getFontFolders--) per consentire di trovare le cartelle dei caratteri. Questo metodo restituisce le cartelle aggiunte tramite il metodo `LoadExternalFonts` e le cartelle di caratteri di sistema.

Questo codice PHP mostra come utilizzare [getFontFolders](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontsloader/#getFontFolders--):

```php
# Questa riga restituisce le cartelle dove vengono cercati i file dei caratteri.
# Sono le cartelle aggiunte tramite il metodo LoadExternalFonts e le cartelle di caratteri di sistema.
$fontFolders = FontsLoader::getFontFolders();
```

## **Specificare i Caratteri Personalizzati Usati con una Presentazione**
Aspose.Slides fornisce il metodo [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/it/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) per consentire di specificare i caratteri esterni che saranno usati con la presentazione.

Questo codice PHP mostra come utilizzare il metodo [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/it/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

```php
$javaArray = new JavaClass("java.lang.reflect.Array");
$javaByteType = (new JavaClass("java.lang.Byte"))->TYPE;

$customFontsDirectory = __DIR__ . "/customfonts/";
$customFont1Path = $customFontsDirectory . "CustomFont1.ttf";
$customFontFile1 = new Java("java.io.File", $customFont1Path);
$customFontFile1Length = $customFontFile1->length();
$memoryFont1 = $javaArray->newInstance($javaByteType, $customFontFile1Length);
$dataInputStream1 = null;
try {
    $fileInputStream1 = new Java("java.io.FileInputStream", $customFontFile1);
    $dataInputStream1 = new Java("java.io.DataInputStream", $fileInputStream1);
    $dataInputStream1->readFully($memoryFont1);
} finally {
    if (!java_is_null($dataInputStream1)) $dataInputStream1->close();
}

$customFont2Path = $customFontsDirectory . "CustomFont2.ttf";
$customFontFile2 = new Java("java.io.File", $customFont2Path);
$customFontFile2Length = $customFontFile2->length();
$memoryFont2 = $javaArray->newInstance($javaByteType, $customFontFile2Length);
$dataInputStream2 = null;
try {
    $fileInputStream2 = new Java("java.io.FileInputStream", $customFontFile2);
    $dataInputStream2 = new Java("java.io.DataInputStream", $fileInputStream2);
    $dataInputStream2->readFully($memoryFont2);
} finally {
    if (!java_is_null($dataInputStream2)) $dataInputStream2->close();
}

$loadOptions = new LoadOptions();
$assetFontsFolder = __DIR__ . "/assets/fonts";
$globalFontsFolder = __DIR__ . "/global/fonts";
$loadOptions->getDocumentLevelFontSources()->setFontFolders(array($assetFontsFolder, $globalFontsFolder));
$loadOptions->getDocumentLevelFontSources()->setMemoryFonts(array($memoryFont1, $memoryFont2 ));

$presentationPath = __DIR__ . "/MyPresentation.pptx";
$presentation = new Presentation($presentationPath, $loadOptions);
try {
    # Lavora con la presentazione
    # CustomFont1, CustomFont2 e i font dalle cartelle assets\fonts e global\fonts e le loro sottocartelle sono disponibili per la presentazione
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Gestire i Caratteri Esternamente**

Aspose.Slides fornisce il metodo [loadExternalFont](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) per consentire di caricare caratteri esterni da dati binari.

Questo codice PHP dimostra il processo di caricamento dei caratteri da array di byte:

```php
$javaArray = new JavaClass("java.lang.reflect.Array");
$javaByteType = (new JavaClass("java.lang.Byte"))->TYPE;
$fontDirectory = __DIR__ . "/";

$dataInputStream = null;
try {
    $fontPath = $fontDirectory . "ARIALN.TTF";
    $fileInputStream = new Java("java.io.FileInputStream", $fontPath);
    $dataInputStream = new Java("java.io.DataInputStream", $fileInputStream);
    $fontBytes = $javaArray->newInstance($javaByteType, $dataInputStream->available());
    $dataInputStream->readFully($fontBytes);
} finally {
    if (!java_is_null($dataInputStream)) $dataInputStream->close();
}
FontsLoader::loadExternalFont($fontBytes);

$dataInputStream = null;
try {
    $fontPath = $fontDirectory . "ARIALNBI.TTF";
    $fileInputStream = new Java("java.io.FileInputStream", $fontPath);
    $dataInputStream = new Java("java.io.DataInputStream", $fileInputStream);
    $fontBytes = $javaArray->newInstance($javaByteType, $dataInputStream->available());
    $dataInputStream->readFully($fontBytes);
} finally {
    if (!java_is_null($dataInputStream)) $dataInputStream->close();
}
FontsLoader::loadExternalFont($fontBytes);

$dataInputStream = null;
try {
    $fontPath = $fontDirectory . "ARIALNI.TTF";
    $fileInputStream = new Java("java.io.FileInputStream", $fontPath);
    $dataInputStream = new Java("java.io.DataInputStream", $fileInputStream);
    $fontBytes = $javaArray->newInstance($javaByteType, $dataInputStream->available());
    $dataInputStream->readFully($fontBytes);
} finally {
    if (!java_is_null($dataInputStream)) $dataInputStream->close();
}
FontsLoader::loadExternalFont($fontBytes);

try {
    $presentation = new Presentation();
    try {
        # font esterno caricato durante la durata della presentazione
    } finally {
        if (!java_is_null($presentation)) {
            $presentation->dispose();
        }
    }
} finally {
    FontsLoader->clearCache();
}
```

## **Domande frequenti**

### I caratteri personalizzati influenzano l'esportazione in tutti i formati (PDF, PNG, SVG, HTML)?
Sì. I caratteri collegati vengono utilizzati dal renderer per tutti i formati di esportazione.

### I caratteri personalizzati vengono incorporati automaticamente nel PPTX risultante?
No. Registrare un carattere per il rendering non è la stessa cosa dell'incorporamento in un PPTX. Se è necessario che il carattere sia contenuto nel file di presentazione, occorre utilizzare le [funzionalità di incorporamento](/slides/it/php-java/embedded-font/).

### Posso controllare il comportamento di fallback quando un carattere personalizzato non dispone di alcuni glifi?
Sì. Configura [sostituzione dei caratteri](/slides/it/php-java/font-substitution/), [regole di sostituzione](/slides/it/php-java/font-replacement/) e [insiemi di fallback](/slides/it/php-java/fallback-font/) per definire esattamente quale carattere usare quando il glifo richiesto è assente.

### Posso usare i caratteri in contenitori Linux/Docker senza installarli a livello di sistema?
Sì. Indica le tue cartelle dei caratteri o carica i caratteri da array di byte. Questo elimina qualsiasi dipendenza dalle directory dei caratteri di sistema nell'immagine del contenitore.

### E per quanto riguarda le licenze — è possibile incorporare qualsiasi carattere personalizzato senza restrizioni?
Sei responsabile della conformità alle licenze dei caratteri. I termini variano; alcune licenze vietano l'incorporamento o l'uso commerciale. Consulta sempre la EULA del carattere prima di distribuire i risultati.