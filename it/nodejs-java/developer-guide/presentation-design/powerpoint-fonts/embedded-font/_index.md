---
title: Incorpora font nelle presentazioni in JavaScript
linktitle: Font incorporati
type: docs
weight: 40
url: /it/nodejs-java/embedded-font/
keywords:
- aggiungi font
- incorpora font
- incorporamento font
- recupera font incorporato
- aggiungi font incorporato
- rimuovi font incorporato
- comprimi font incorporato
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Gestisci i font incorporati in PowerPoint con Aspose.Slides per Node.js via Java. Aggiungi, recupera, rimuovi e comprimi i font per preservare l'aspetto del testo e ridurre le dimensioni del file."
---
## **Introduzione**

L'incorporamento dei font memorizza i dati dei font all'interno di una presentazione PowerPoint. Quando un visualizzatore supporta i font incorporati, può visualizzare il testo utilizzando tali font anche se non sono installati sul sistema di destinazione. Questo aiuta a preservare le interruzioni di riga, la spaziatura del testo e il layout delle diapositive.

Aspose.Slides per Node.js tramite Java consente di recuperare, aggiungere e rimuovere i font incorporati attraverso la classe [FontsManager](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontsmanager/) restituita da [Presentation.getFontsManager](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/getfontsmanager/). È inoltre possibile ridurre le dimensioni dei dati dei font incorporati rimuovendo i caratteri che la presentazione non utilizza.

Gli esempi seguenti funzionano con file PPTX. Prima di incorporare un font, assicurati che i dati del font siano disponibili per Aspose.Slides e che la sua licenza ne consenta l'incorporamento.

## **Recuperare e rimuovere i font incorporati**

Usa [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) per elencare i font memorizzati in una presentazione. Per rimuoverne uno, passa un font da quell'elenco a [FontsManager.removeEmbeddedFont](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontsmanager/removeembeddedfont/), quindi salva la presentazione.

Il seguente esempio elenca i font incorporati in `EmbeddedFonts.pptx` e rimuove Calibri se è presente:
```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var embeddedFonts = fontsManager.getEmbeddedFonts();

    for (var i = 0; i < embeddedFonts.length; i++) {
        console.log(embeddedFonts[i].getFontName());
    }

    var fontToRemove = null;
    for (var i = 0; i < embeddedFonts.length; i++) {
        if (String(embeddedFonts[i].getFontName()).toLowerCase() === "calibri") {
            fontToRemove = embeddedFonts[i];
            break;
        }
    }

    if (fontToRemove !== null) {
        fontsManager.removeEmbeddedFont(fontToRemove);
        presentation.save("WithoutEmbeddedCalibri.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("Calibri is not embedded. No output file was created.");
    }
} finally {
    presentation.dispose();
}
```

Rimuovere un font incorporato elimina i dati del font memorizzati; non modifica il font assegnato al testo. Se il font è installato sul sistema di destinazione, il testo può ancora utilizzarlo. Altrimenti, il rendering potrebbe richiedere la [sostituzione dei font](/slides/it/nodejs-java/font-substitution/), il che può influire sul layout.

## **Ispezionare i dati dei font e i permessi di incorporamento**

Usa la classe [FontsManager](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontsmanager/) per ispezionare i font prima di incorporarli. Chiama [FontsManager.getFonts](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontsmanager/getfonts/) per recuperare i font utilizzati nella presentazione. Per ogni font, passa un oggetto [FontData](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontdata/) e il valore richiesto di [FontStyleType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontstyletype/) a [FontsManager.getFontBytes](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontsmanager/#getFontBytes). Il metodo restituisce i dati binari per quello stile di font, oppure `null` quando il font o lo stile richiesto non è disponibile. Non passare un risultato `null` a [FontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel), poiché quel metodo richiede un array di byte. In Node.js, converti l'array JavaScript restituito in un array di byte Java con `java.newArray` prima di passarlo a `getFontEmbeddingLevel`.

[EmbeddingLevel](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/embeddinglevel/) riporta le restrizioni di incorporamento memorizzate nel font come un insieme di flag:

- `Installable` consente l'incorporamento e l'installazione permanente su un altro sistema, soggetto alla licenza del font.
- `Restricted` proibisce l'incorporamento a meno che non venga ottenuta l'autorizzazione dal proprietario legale del font quando è l'unico flag di permesso d'uso.
- `PreviewPrint` consente l'uso temporaneo per visualizzare e stampare; un documento contenente il font deve essere di sola lettura.
- `Editable` consente l'uso temporaneo e permette al documento di essere modificato e salvato.
- `NoSubsetting` è una restrizione aggiuntiva che proibisce l'incorporamento di solo un sottoinsieme dei glifi. Incorpora tutti i caratteri quando questo flag è presente.
- `BitmapOnly` è una restrizione aggiuntiva che consente di incorporare solo le versioni bitmap, non i dati di contorno. Se il font non ha versioni bitmap, non può essere incorporato.

I primi quattro valori descrivono il permesso d'uso, mentre `NoSubsetting` e `BitmapOnly` possono essere combinati con essi. Controlla i modificatori con operazioni bitwise. Poiché `Installable` è zero, maschera i bit di permesso d'uso e confronta il risultato con `Installable` invece di verificarlo come flag. I font attuali dovrebbero impostare al massimo un bit di permesso d'uso. Per compatibilità con font più vecchi che impostano più di uno, l'aiutante sotto seleziona il permesso meno restrittivo: `Editable`, poi `PreviewPrint`, poi `Restricted`.

Il seguente esempio controlla i dati regolari, grassetto, corsivo e grassetto‑corsivo disponibili per ogni font restituito da `getFonts`. Salta gli stili non disponibili, i font con restrizioni, i font solo bitmap, i font limitati a anteprima e stampa perché l'output rimane modificabile, e i font già incorporati. Se qualche stile disponibile ha `NoSubsetting`, incorpora tutti i caratteri per quella famiglia di font.
```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
var java = require("java");

function getUsagePermission(level) {
    var permissionMask = aspose.slides.EmbeddingLevel.Restricted | aspose.slides.EmbeddingLevel.PreviewPrint | aspose.slides.EmbeddingLevel.Editable;
    var permissions = level & permissionMask;

    if ((permissions & aspose.slides.EmbeddingLevel.Editable) !== 0) {
        return aspose.slides.EmbeddingLevel.Editable;
    }

    if ((permissions & aspose.slides.EmbeddingLevel.PreviewPrint) !== 0) {
        return aspose.slides.EmbeddingLevel.PreviewPrint;
    }

    if ((permissions & aspose.slides.EmbeddingLevel.Restricted) !== 0) {
        return aspose.slides.EmbeddingLevel.Restricted;
    }

    return aspose.slides.EmbeddingLevel.Installable;
}

var presentation = new aspose.slides.Presentation("Fonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var fontStyles = [aspose.slides.FontStyleType.Regular, aspose.slides.FontStyleType.Bold, aspose.slides.FontStyleType.Italic, aspose.slides.FontStyleType.Bold | aspose.slides.FontStyleType.Italic];

    var embeddedFontNames = new Set();
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    for (var i = 0; i < embeddedFonts.length; i++) {
        embeddedFontNames.add(String(embeddedFonts[i].getFontName()).toLowerCase());
    }

    var fontsToEmbed = [];
    var embeddingRules = [];
    var fonts = fontsManager.getFonts();
    for (var i = 0; i < fonts.length; i++) {
        var font = fonts[i];
        var fontName = String(font.getFontName());
        if (embeddedFontNames.has(fontName.toLowerCase())) {
            console.log(fontName + ": already embedded.");
            continue;
        }

        var hasAvailableData = false;
        var allAvailableStylesCanBeEmbedded = true;
        var previewPrintOnly = false;
        var requiresFullFont = false;

        for (var j = 0; j < fontStyles.length; j++) {
            var fontStyle = fontStyles[j];
            var fontBytes = fontsManager.getFontBytes(font, fontStyle);
            if (fontBytes === null) {
                console.log(fontName + " (" + fontStyle + "): font data is unavailable.");
                continue;
            }

            hasAvailableData = true;
            var fontByteValues = Array.from(fontBytes);
            var javaFontBytes = java.newArray("byte", fontByteValues);
            var embeddingLevel = fontsManager.getFontEmbeddingLevel(javaFontBytes, fontName);
            var usagePermission = getUsagePermission(embeddingLevel);
            var noSubsetting = (embeddingLevel & aspose.slides.EmbeddingLevel.NoSubsetting) !== 0;
            var bitmapOnly = (embeddingLevel & aspose.slides.EmbeddingLevel.BitmapOnly) !== 0;

            requiresFullFont = requiresFullFont || noSubsetting;
            previewPrintOnly = previewPrintOnly || usagePermission === aspose.slides.EmbeddingLevel.PreviewPrint;
            allAvailableStylesCanBeEmbedded = allAvailableStylesCanBeEmbedded && usagePermission !== aspose.slides.EmbeddingLevel.Restricted && !bitmapOnly;

            console.log(fontName + " (" + fontStyle + "): " + embeddingLevel + ".");
        }

        if (!hasAvailableData) {
            console.log(fontName + ": skipped because no requested style is available.");
        } else if (!allAvailableStylesCanBeEmbedded) {
            console.log(fontName + ": skipped because at least one available style does not permit outline embedding.");
        } else if (previewPrintOnly) {
            console.log(fontName + ": skipped because this example produces an editable presentation.");
        } else {
            var rule = requiresFullFont ? aspose.slides.EmbedFontCharacters.All : aspose.slides.EmbedFontCharacters.OnlyUsed;
            fontsToEmbed.push(font);
            embeddingRules.push(rule);
        }
    }

    for (var i = 0; i < fontsToEmbed.length; i++) {
        fontsManager.addEmbeddedFont(fontsToEmbed[i], embeddingRules[i]);
    }

    presentation.save("WithAuditedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Questa ispezione riporta le restrizioni codificate in ogni file di font. Non concede una licenza, non prova che tu abbia ottenuto il font legalmente, né sostituisce il controllo dell'accordo di licenza del font prima di distribuire una copia incorporata.

## **Aggiungere font incorporati**

Usa [FontsManager.addEmbeddedFont](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontsmanager/addembeddedfont/) per incorporare un font. Le sue overload accettano un oggetto [FontData](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontdata/) o un array di byte contenente i dati del font. [EmbedFontCharacters](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/embedfontcharacters/) controlla quali caratteri sono inclusi:

- `All` incorpora tutti i caratteri del font. Usa questa opzione quando i destinatari devono modificare la presentazione e inserire nuovo testo.
- `OnlyUsed` incorpora solo i caratteri utilizzati nella presentazione per ridurre le dimensioni del file. Scegli questa opzione per una presentazione finita destinata principalmente alla visualizzazione.

Il seguente esempio utilizza [FontsManager.getFonts](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontsmanager/getfonts/) per recuperare i font usati in `Fonts.pptx` e incorpora quelli che non sono già incorporati. I font da aggiungere devono essere disponibili sulla macchina che esegue il codice. I font incorporati esistenti mantengono i loro set di caratteri attuali.
```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("Fonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var allFonts = fontsManager.getFonts();
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    var embeddedFontNames = new Set();
    var fontStyles = [aspose.slides.FontStyleType.Regular, aspose.slides.FontStyleType.Bold, aspose.slides.FontStyleType.Italic, aspose.slides.FontStyleType.Bold | aspose.slides.FontStyleType.Italic];

    for (var i = 0; i < embeddedFonts.length; i++) {
        embeddedFontNames.add(String(embeddedFonts[i].getFontName()).toLowerCase());
    }

    for (var i = 0; i < allFonts.length; i++) {
        var font = allFonts[i];
        var fontName = String(font.getFontName()).toLowerCase();
        if (!embeddedFontNames.has(fontName)) {
            var hasAvailableData = false;
            for (var j = 0; j < fontStyles.length; j++) {
                if (fontsManager.getFontBytes(font, fontStyles[j]) !== null) {
                    hasAvailableData = true;
                    break;
                }
            }

            if (hasAvailableData) {
                fontsManager.addEmbeddedFont(font, aspose.slides.EmbedFontCharacters.All);
                embeddedFontNames.add(fontName);
            } else {
                console.log(font.getFontName() + ": skipped because its font data is unavailable.");
            }
        }
    }

    presentation.save("WithEmbeddedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Comprimere i font incorporati**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/compress/compressembeddedfonts/) riduce i dati dei font incorporati rimuovendo i caratteri non utilizzati. Funziona su font già incorporati, quindi la riduzione delle dimensioni dipende da quanti dati di font inutilizzati contiene la presentazione.

Il seguente esempio comprime i font in `EmbeddedFonts.pptx` e salva il risultato in un file separato:
```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    aspose.slides.Compress.compressEmbeddedFonts(presentation);
    presentation.save("CompressedEmbeddedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Conserva il file originale se i destinatari potrebbero aver bisogno di aggiungere testo in seguito. I caratteri rimossi durante la compressione non sono più disponibili dal font incorporato, anche se inizialmente hai incorporato tutti i caratteri.

## **FAQ**

**Come posso verificare se un font incorporato verrà comunque sostituito durante il rendering?**

Chiama [FontsManager.getSubstitutions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) nell'ambiente in cui renderizzi la presentazione per vedere quali font Aspose.Slides sostituirà. Controlla anche le impostazioni di [sostituzione dei font](/slides/it/nodejs-java/font-substitution/) e le regole di [fallback dei font](/slides/it/nodejs-java/fallback-font/). Il fallback gestisce i caratteri mancanti, quindi l'incorporamento di un font non risolve i caratteri che il font stesso non contiene.

**Devo incorporare font comuni come Arial e Calibri?**

Base la decisione sull'ambiente di destinazione. Se i font richiesti sono disponibili su ogni macchina che apre o rende la presentazione, incorporarli può aumentare inutilmente le dimensioni del file. Se i destinatari o i server potrebbero non disporre di quei font, incorporarli può aiutare a preservare l'aspetto previsto, a condizione che le loro licenze lo consentano.