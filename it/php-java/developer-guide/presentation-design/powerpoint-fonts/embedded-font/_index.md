---
title: "Incorpora i font nelle presentazioni usando PHP"
linktitle: "Font incorporati"
type: docs
weight: 40
url: /it/php-java/embedded-font/
keywords:
- "aggiungi font"
- "incorpora font"
- "incorporamento dei font"
- "ottieni font incorporato"
- "aggiungi font incorporato"
- "rimuovi font incorporato"
- "comprime font incorporato"
- "PowerPoint"
- "presentazione"
- "PHP"
- "Aspose.Slides"
description: "Gestisci i font incorporati in PowerPoint con Aspose.Slides per PHP via Java. Aggiungi, recupera, rimuovi e comprimi i font per preservare l'aspetto del testo e ridurre le dimensioni del file."
---
## **Introduzione**

L'incorporamento dei caratteri memorizza i dati del carattere all'interno di una presentazione PowerPoint. Quando un visualizzatore supporta i caratteri incorporati, può visualizzare il testo utilizzando tali caratteri anche se non sono installati sul sistema di destinazione. Ciò aiuta a preservare le interruzioni di riga, la spaziatura del testo e il layout delle diapositive.

Aspose.Slides per PHP via Java consente di recuperare, aggiungere e rimuovere caratteri incorporati tramite la classe [FontsManager](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontsmanager/) restituita da [Presentation::getFontsManager](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#getFontsManager). È inoltre possibile ridurre la dimensione dei dati dei caratteri incorporati rimuovendo i caratteri non utilizzati nella presentazione.

Gli esempi seguenti funzionano con file PPTX. Prima di incorporare un carattere, assicurarsi che i dati del carattere siano disponibili per Aspose.Slides e che la sua licenza ne consenta l'incorporamento.

## **Recuperare e rimuovere i caratteri incorporati**

Utilizzare [FontsManager::getEmbeddedFonts](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) per elencare i caratteri memorizzati in una presentazione. Per rimuoverne uno, passare un carattere da quell'elenco a [FontsManager::removeEmbeddedFont](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontsmanager/#removeEmbeddedFont), quindi salvare la presentazione.

Il seguente esempio elenca i caratteri incorporati in `EmbeddedFonts.pptx` e rimuove Calibri se è presente:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("EmbeddedFonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $embeddedFonts = $fontsManager->getEmbeddedFonts();

    foreach ($embeddedFonts as $font) {
        echo java_values($font->getFontName()) . PHP_EOL;
    }

    $fontToRemove = null;
    foreach ($embeddedFonts as $font) {
        $fontName = java_values($font->getFontName());
        if (strcasecmp($fontName, "Calibri") === 0) {
            $fontToRemove = $font;
            break;
        }
    }

    if ($fontToRemove !== null) {
        $fontsManager->removeEmbeddedFont($fontToRemove);
        $presentation->save("WithoutEmbeddedCalibri.pptx", SaveFormat::Pptx);
    } else {
        echo "Calibri is not embedded. No output file was created." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Rimuovere un carattere incorporato elimina i dati del carattere memorizzati; non modifica il carattere assegnato al testo. Se il carattere è installato sul sistema di destinazione, il testo può comunque utilizzarlo. Altrimenti, il rendering potrebbe richiedere la [sostituzione dei caratteri](/slides/it/php-java/font-substitution/), il che può influire sul layout.

## **Ispezionare i dati dei caratteri e i permessi di incorporamento**

Utilizzare la classe [FontsManager](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontsmanager/) per ispezionare i caratteri prima di incorporarli. Chiamare [FontsManager::getFonts](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontsmanager/#getFonts) per recuperare i caratteri usati nella presentazione. Per ciascun carattere, passare un oggetto [FontData](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontdata/) e il valore richiesto di [FontStyleType](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontstyletype/) a [FontsManager::getFontBytes](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontsmanager/#getFontBytes). Il metodo restituisce i dati binari per quello stile di carattere, oppure `null` quando il carattere o lo stile richiesto non è disponibile. Non passare un risultato `null` a [FontsManager::getFontEmbeddingLevel](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel), poiché quel metodo richiede un array di byte.

[EmbeddingLevel](https://reference.aspose.com/slides/it/php-java/aspose.slides/embeddinglevel/) è una enumerazione di flag che riporta le restrizioni di incorporamento memorizzate nel carattere:

- `Installable` consente l'incorporamento e l'installazione permanente su un altro sistema, soggetto alla licenza del carattere.
- `Restricted` vieta l'incorporamento a meno che non venga ottenuta l'autorizzazione dal legale proprietario del carattere quando è l'unica bandiera di permesso d'uso.
- `PreviewPrint` consente l'uso temporaneo per visualizzazione e stampa; un documento contenente il carattere deve essere di sola lettura.
- `Editable` consente l'uso temporaneo e permette di modificare e salvare il documento.
- `NoSubsetting` è una restrizione aggiuntiva che vieta l'incorporamento di solo un sottoinsieme dei glifi. Incorpora tutti i caratteri quando questa bandiera è presente.
- `BitmapOnly` è una restrizione aggiuntiva che consente di incorporare solo le bitmap, non i dati di contorno. Se il carattere non ha bitmap, non può essere incorporato.

I primi quattro valori descrivono il permesso d'uso, mentre `NoSubsetting` e `BitmapOnly` possono essere combinati con essi. Verificare i modificatori con operazioni bitwise. Poiché `Installable` è zero, mascherare i bit di permesso d'uso e confrontare il risultato con `Installable` invece di controllarlo come un flag. I caratteri attuali dovrebbero impostare al massimo un bit di permesso d'uso. Per compatibilità con caratteri più vecchi che impostano più di uno, l'aiutante qui sotto seleziona il permesso meno restrittivo: `Editable`, poi `PreviewPrint`, poi `Restricted`.

Il seguente esempio verifica i dati regolari, grassetto, corsivo e grassetto‑corsivo disponibili per ogni carattere restituito da `FontsManager::getFonts`. Salta gli stili non disponibili, i caratteri limitati, i caratteri solo‑bitmap, i caratteri limitati a anteprima e stampa perché l'output rimane editabile, e i caratteri già incorporati. Se qualche stile disponibile ha `NoSubsetting`, incorpora tutti i caratteri per quella famiglia di caratteri.

```php
use aspose\slides\EmbedFontCharacters;
use aspose\slides\EmbeddingLevel;
use aspose\slides\FontStyleType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

function getUsagePermission($level) {
    $permissionMask = EmbeddingLevel::Restricted | EmbeddingLevel::PreviewPrint | EmbeddingLevel::Editable;
    $permissions = $level & $permissionMask;

    if (($permissions & EmbeddingLevel::Editable) !== 0) {
        return EmbeddingLevel::Editable;
    }

    if (($permissions & EmbeddingLevel::PreviewPrint) !== 0) {
        return EmbeddingLevel::PreviewPrint;
    }

    if (($permissions & EmbeddingLevel::Restricted) !== 0) {
        return EmbeddingLevel::Restricted;
    }

    return EmbeddingLevel::Installable;
}

$presentation = new Presentation("Fonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $fontStyles = [
        FontStyleType::Regular,
        FontStyleType::Bold,
        FontStyleType::Italic,
        FontStyleType::Bold | FontStyleType::Italic
    ];

    $embeddedFontNames = [];
    foreach ($fontsManager->getEmbeddedFonts() as $embeddedFont) {
        $fontName = java_values($embeddedFont->getFontName());
        $embeddedFontNames[strtolower($fontName)] = true;
    }

    $fontsToEmbed = [];
    $embeddingRules = [];
    foreach ($fontsManager->getFonts() as $font) {
        $fontName = java_values($font->getFontName());
        if (isset($embeddedFontNames[strtolower($fontName)])) {
            echo $fontName . ": already embedded." . PHP_EOL;
            continue;
        }

        $hasAvailableData = false;
        $allAvailableStylesCanBeEmbedded = true;
        $previewPrintOnly = false;
        $requiresFullFont = false;

        foreach ($fontStyles as $fontStyle) {
            $fontBytes = $fontsManager->getFontBytes($font, $fontStyle);
            if (java_is_null($fontBytes)) {
                echo $fontName . " (" . $fontStyle . "): font data is unavailable." . PHP_EOL;
                continue;
            }

            $hasAvailableData = true;
            $embeddingLevel = java_values($fontsManager->getFontEmbeddingLevel($fontBytes, $fontName));
            $usagePermission = getUsagePermission($embeddingLevel);
            $noSubsetting = ($embeddingLevel & EmbeddingLevel::NoSubsetting) !== 0;
            $bitmapOnly = ($embeddingLevel & EmbeddingLevel::BitmapOnly) !== 0;

            $requiresFullFont = $requiresFullFont || $noSubsetting;
            $previewPrintOnly = $previewPrintOnly || $usagePermission === EmbeddingLevel::PreviewPrint;
            $allAvailableStylesCanBeEmbedded = $allAvailableStylesCanBeEmbedded && $usagePermission !== EmbeddingLevel::Restricted && !$bitmapOnly;

            echo $fontName . " (" . $fontStyle . "): " . $embeddingLevel . "." . PHP_EOL;
        }

        if (!$hasAvailableData) {
            echo $fontName . ": skipped because no requested style is available." . PHP_EOL;
        } elseif (!$allAvailableStylesCanBeEmbedded) {
            echo $fontName . ": skipped because at least one available style does not permit outline embedding." . PHP_EOL;
        } elseif ($previewPrintOnly) {
            echo $fontName . ": skipped because this example produces an editable presentation." . PHP_EOL;
        } else {
            $rule = $requiresFullFont ? EmbedFontCharacters::All : EmbedFontCharacters::OnlyUsed;
            $fontsToEmbed[] = $font;
            $embeddingRules[] = $rule;
        }
    }

    for ($i = 0; $i < count($fontsToEmbed); $i++) {
        $fontsManager->addEmbeddedFont($fontsToEmbed[$i], $embeddingRules[$i]);
    }

    $presentation->save("WithAuditedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Questa ispezione riporta le restrizioni codificate in ciascun file di carattere. Non concede una licenza, non dimostra che il carattere sia stato ottenuto legalmente e non sostituisce il controllo del contratto di licenza del carattere prima di distribuire una copia incorporata.

## **Aggiungere caratteri incorporati**

Utilizzare [FontsManager::addEmbeddedFont](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontsmanager/#addEmbeddedFont) per incorporare un carattere. Le sue overload accettano un oggetto [FontData](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontdata/) oppure un array di byte contenente i dati del carattere. L'enumerazione [EmbedFontCharacters](https://reference.aspose.com/slides/it/php-java/aspose.slides/embedfontcharacters/) controlla quali caratteri sono inclusi:

- [All](https://reference.aspose.com/slides/it/php-java/aspose.slides/embedfontcharacters/) incorpora tutti i caratteri del carattere. Utilizzare questa opzione quando i destinatari devono modificare la presentazione e inserire nuovo testo.
- [OnlyUsed](https://reference.aspose.com/slides/it/php-java/aspose.slides/embedfontcharacters/) incorpora solo i caratteri usati nella presentazione per ridurre le dimensioni del file. Scegliere questa opzione per una presentazione finale destinata principalmente alla visualizzazione.

Il seguente esempio usa [FontsManager::getFonts](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontsmanager/#getFonts) per recuperare i caratteri usati in `Fonts.pptx` e incorpora quelli non ancora incorporati. I caratteri da aggiungere devono essere disponibili sulla macchina che esegue il codice. I caratteri già incorporati mantengono i set di caratteri attuali.

```php
use aspose\slides\EmbedFontCharacters;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Fonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $allFonts = $fontsManager->getFonts();
    $embeddedFonts = $fontsManager->getEmbeddedFonts();
    $embeddedFontNames = [];

    foreach ($embeddedFonts as $embeddedFont) {
        $fontName = java_values($embeddedFont->getFontName());
        $embeddedFontNames[strtolower($fontName)] = true;
    }

    foreach ($allFonts as $font) {
        $fontName = java_values($font->getFontName());
        $normalizedFontName = strtolower($fontName);
        if (!isset($embeddedFontNames[$normalizedFontName])) {
            $fontsManager->addEmbeddedFont($font, EmbedFontCharacters::All);
            $embeddedFontNames[$normalizedFontName] = true;
        }
    }

    $presentation->save("WithEmbeddedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Comprimere i caratteri incorporati**

[Compress::compressEmbeddedFonts](https://reference.aspose.com/slides/it/php-java/aspose.slides/compress/#compressEmbeddedFonts) riduce i dati dei caratteri incorporati rimuovendo i caratteri non utilizzati. Opera su caratteri già incorporati, quindi la riduzione delle dimensioni dipende da quanti dati di carattere inutilizzati contiene la presentazione.

Il seguente esempio comprime i caratteri in `EmbeddedFonts.pptx` e salva il risultato in un file separato:

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("EmbeddedFonts.pptx");
try {
    Compress::compressEmbeddedFonts($presentation);
    $presentation->save("CompressedEmbeddedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Conservare il file originale se i destinatari potrebbero dover aggiungere testo in seguito. I caratteri rimossi durante la compressione non sono più disponibili nel carattere incorporato, anche se in origine erano stati incorporati tutti i caratteri.

## **FAQ**

**Come posso verificare se un carattere incorporato verrà ancora sostituito durante il rendering?**

Chiamare [FontsManager::getSubstitutions](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontsmanager/#getSubstitutions) nell'ambiente in cui si rende la presentazione per vedere quali caratteri Aspose.Slides sostituirà. Controllare anche le impostazioni di [sostituzione dei caratteri](/slides/it/php-java/font-substitution/) e le regole di [font fallback](/slides/it/php-java/fallback-font/). Il fallback gestisce i caratteri mancanti, quindi l'incorporamento di un carattere non risolve i caratteri che il carattere stesso non contiene.

**Devo incorporare i caratteri comuni come Arial e Calibri?**

Basare la decisione sull'ambiente di destinazione. Se i caratteri richiesti sono disponibili su ogni macchina che apre o rende la presentazione, incorporarli potrebbe aumentare inutilmente le dimensioni del file. Se i destinatari o i server potrebbero non disporre di quei caratteri, incorporarli può aiutare a preservare l'aspetto previsto, purché le loro licenze lo consentano.