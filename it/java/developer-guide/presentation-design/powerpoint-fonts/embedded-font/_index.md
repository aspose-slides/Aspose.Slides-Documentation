---
title: Incorporare i caratteri nelle presentazioni in Java
linktitle: Caratteri incorporati
type: docs
weight: 40
url: /it/java/embedded-font/
keywords:
- aggiungi carattere
- incorpora carattere
- incorporamento carattere
- ottieni carattere incorporato
- aggiungi carattere incorporato
- rimuovi carattere incorporato
- comprimi carattere incorporato
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Gestisci i caratteri incorporati in PowerPoint con Aspose.Slides per Java. Aggiungi, recupera, rimuovi e comprimi i caratteri per preservare l'aspetto del testo e ridurre le dimensioni del file."
---
## **Introduzione**

L’incorporamento dei caratteri memorizza i dati del font all’interno di una presentazione PowerPoint. Quando un visualizzatore supporta i caratteri incorporati, può visualizzare il testo usando tali caratteri anche se non sono installati sul sistema di destinazione. Questo aiuta a preservare le interruzioni di riga, la spaziatura del testo e il layout delle diapositive.

Aspose.Slides for Java consente di recuperare, aggiungere e rimuovere caratteri incorporati tramite l’interfaccia [IFontsManager](https://reference.aspose.com/slides/it/java/com.aspose.slides/ifontsmanager/) restituita da [Presentation.getFontsManager](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#getFontsManager--). È inoltre possibile ridurre le dimensioni dei dati dei caratteri incorporati rimuovendo i caratteri che la presentazione non utilizza.

Gli esempi seguenti funzionano con file PPTX. Prima di incorporare un carattere, assicurarsi che i dati del carattere siano disponibili per Aspose.Slides e che la licenza lo consenta.

## **Recuperare e rimuovere i caratteri incorporati**

Usa [getEmbeddedFonts](https://reference.aspose.com/slides/it/java/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) per elencare i caratteri memorizzati in una presentazione. Per rimuoverne uno, passa un carattere da quell’elenco a [removeEmbeddedFont](https://reference.aspose.com/slides/it/java/com.aspose.slides/ifontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-), quindi salva la presentazione.

L’esempio seguente elenca i caratteri incorporati in `EmbeddedFonts.pptx` e rimuove Calibri se presente:

```java
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("EmbeddedFonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    for (IFontData font : embeddedFonts) {
        System.out.println(font.getFontName());
    }

    IFontData fontToRemove = null;
    for (IFontData font : embeddedFonts) {
        if ("Calibri".equalsIgnoreCase(font.getFontName())) {
            fontToRemove = font;
            break;
        }
    }

    if (fontToRemove != null) {
        fontsManager.removeEmbeddedFont(fontToRemove);
        presentation.save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("Calibri is not embedded. No output file was created.");
    }
} finally {
    presentation.dispose();
}
```

Rimuovere un carattere incorporato elimina i dati del carattere memorizzati; non modifica il carattere assegnato al testo. Se il carattere è installato sul sistema di destinazione, il testo può comunque usarlo. Altrimenti, il rendering potrebbe richiedere la [sostituzione dei caratteri](/slides/it/java/font-substitution/), il che può influire sul layout.

## **Ispezionare i dati del carattere e le autorizzazioni di incorporamento**

Usa l’interfaccia [IFontsManager](https://reference.aspose.com/slides/it/java/com.aspose.slides/ifontsmanager/) per ispezionare i caratteri prima di incorporarli. Chiama [IFontsManager.getFonts](https://reference.aspose.com/slides/it/java/com.aspose.slides/ifontsmanager/#getFonts--) per recuperare i caratteri utilizzati nella presentazione. Per ogni carattere, passa un oggetto [IFontData](https://reference.aspose.com/slides/it/java/com.aspose.slides/ifontdata/) e il valore richiesto di [FontStyleType](https://reference.aspose.com/slides/it/java/com.aspose.slides/fontstyletype/) a [IFontsManager.getFontBytes](https://reference.aspose.com/slides/it/java/com.aspose.slides/ifontsmanager/#getFontBytes-com.aspose.slides.IFontData-int-). Il metodo restituisce i dati binari per quello stile di carattere, o `null` quando il carattere o lo stile richiesto non è disponibile. Non passare un risultato `null` a [IFontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/it/java/com.aspose.slides/ifontsmanager/#getFontEmbeddingLevel-byte---java.lang.String-), poiché quel metodo richiede un array di byte.

[EmbeddingLevel](https://reference.aspose.com/slides/it/java/com.aspose.slides/embeddinglevel/) è una enumerazione a flag che segnala le restrizioni di incorporamento memorizzate nel carattere:

- `Installable` consente l’incorporamento e l’installazione permanente su un altro sistema, secondo la licenza del carattere.
- `Restricted` vieta l’incorporamento a meno che non sia ottenuto il permesso dal proprietario legale del carattere quando è l’unico flag di autorizzazione all’uso.
- `PreviewPrint` consente l’uso temporaneo per visualizzare e stampare; un documento contenente il carattere deve essere di sola lettura.
- `Editable` consente l’uso temporaneo e permette al documento di essere modificato e salvato.
- `NoSubsetting` è una restrizione aggiuntiva che vieta l’incorporamento di un sottoinsieme di glifi. Incorporare tutti i caratteri quando è presente questo flag.
- `BitmapOnly` è una restrizione aggiuntiva che consente di incorporare solo le varianti bitmap, non i dati contorno. Se il carattere non ha varianti bitmap, non può essere incorporato.

I primi quattro valori descrivono l’autorizzazione all’uso, mentre `NoSubsetting` e `BitmapOnly` possono essere combinati con essi. Controlla i modificatori con operazioni bitwise. Poiché `Installable` è zero, maschera i bit di autorizzazione all’uso e confronta il risultato con `Installable` invece di verificarlo come flag. I caratteri attuali dovrebbero impostare al più un bit di autorizzazione all’uso. Per compatibilità con caratteri più vecchi che ne impostano più di uno, l’aiuto mostrato di seguito seleziona l’autorizzazione meno restrittiva: `Editable`, poi `PreviewPrint`, poi `Restricted`.

L’esempio seguente esamina i dati regolari, grassetto, corsivo e grassetto‑corsivo disponibili per ogni carattere restituito da `getFonts`. Salta gli stili non disponibili, i caratteri con restrizioni, i caratteri solo‑bitmap, i caratteri limitati a anteprima e stampa perché l’output rimane modificabile, e i caratteri già incorporati. Se uno stile disponibile ha `NoSubsetting`, incorpora tutti i caratteri per quella famiglia di caratteri.

```java
import com.aspose.slides.EmbedFontCharacters;
import com.aspose.slides.EmbeddingLevel;
import com.aspose.slides.FontStyleType;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Locale;
import java.util.Set;

class EmbeddingPermission {
    int getUsagePermission(int level) {
        int permissionMask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable;
        int permissions = level & permissionMask;

        if ((permissions & EmbeddingLevel.Editable) != 0) {
            return EmbeddingLevel.Editable;
        }

        if ((permissions & EmbeddingLevel.PreviewPrint) != 0) {
            return EmbeddingLevel.PreviewPrint;
        }

        if ((permissions & EmbeddingLevel.Restricted) != 0) {
            return EmbeddingLevel.Restricted;
        }

        return EmbeddingLevel.Installable;
    }
}

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    int[] fontStyles = {
        FontStyleType.Regular,
        FontStyleType.Bold,
        FontStyleType.Italic,
        FontStyleType.Bold | FontStyleType.Italic
    };

    Set<String> embeddedFontNames = new HashSet<String>();
    for (IFontData embeddedFont : fontsManager.getEmbeddedFonts()) {
        embeddedFontNames.add(embeddedFont.getFontName().toLowerCase(Locale.ROOT));
    }

    EmbeddingPermission permissionHelper = new EmbeddingPermission();
    List<IFontData> fontsToEmbed = new ArrayList<IFontData>();
    List<Integer> embeddingRules = new ArrayList<Integer>();
    for (IFontData font : fontsManager.getFonts()) {
        if (embeddedFontNames.contains(font.getFontName().toLowerCase(Locale.ROOT))) {
            System.out.println(font.getFontName() + ": already embedded.");
            continue;
        }

        boolean hasAvailableData = false;
        boolean allAvailableStylesCanBeEmbedded = true;
        boolean previewPrintOnly = false;
        boolean requiresFullFont = false;

        for (int fontStyle : fontStyles) {
            byte[] fontBytes = fontsManager.getFontBytes(font, fontStyle);
            if (fontBytes == null) {
                System.out.println(font.getFontName() + " (" + fontStyle + "): font data is unavailable.");
                continue;
            }

            hasAvailableData = true;
            int embeddingLevel = fontsManager.getFontEmbeddingLevel(fontBytes, font.getFontName());
            int usagePermission = permissionHelper.getUsagePermission(embeddingLevel);
            boolean noSubsetting = (embeddingLevel & EmbeddingLevel.NoSubsetting) != 0;
            boolean bitmapOnly = (embeddingLevel & EmbeddingLevel.BitmapOnly) != 0;

            requiresFullFont |= noSubsetting;
            previewPrintOnly |= usagePermission == EmbeddingLevel.PreviewPrint;
            allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel.Restricted && !bitmapOnly;

            System.out.println(font.getFontName() + " (" + fontStyle + "): " + embeddingLevel + ".");
        }

        if (!hasAvailableData) {
            System.out.println(font.getFontName() + ": skipped because no requested style is available.");
        } else if (!allAvailableStylesCanBeEmbedded) {
            System.out.println(font.getFontName() + ": skipped because at least one available style does not permit outline embedding.");
        } else if (previewPrintOnly) {
            System.out.println(font.getFontName() + ": skipped because this example produces an editable presentation.");
        } else {
            int rule = requiresFullFont ? EmbedFontCharacters.All : EmbedFontCharacters.OnlyUsed;
            fontsToEmbed.add(font);
            embeddingRules.add(rule);
        }
    }

    for (int i = 0; i < fontsToEmbed.size(); i++) {
        fontsManager.addEmbeddedFont(fontsToEmbed.get(i), embeddingRules.get(i));
    }

    presentation.save("WithAuditedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Questa ispezione segnala le restrizioni codificate in ciascun file di carattere. Non concede una licenza, non dimostra che il carattere sia stato ottenuto legalmente e non sostituisce il controllo del contratto di licenza del carattere prima di distribuire una copia incorporata.

## **Aggiungere caratteri incorporati**

Usa [addEmbeddedFont](https://reference.aspose.com/slides/it/java/com.aspose.slides/ifontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) per incorporare un carattere. Le sue sovraccarichi accettano sia un oggetto [IFontData](https://reference.aspose.com/slides/it/java/com.aspose.slides/ifontdata/) sia un array di byte contenente i dati del carattere. L’enumerazione [EmbedFontCharacters](https://reference.aspose.com/slides/it/java/com.aspose.slides/embedfontcharacters/) controlla quali caratteri sono inclusi:

- [All](https://reference.aspose.com/slides/it/java/com.aspose.slides/embedfontcharacters/) incorpora tutti i caratteri del font. Usa questa opzione quando i destinatari devono modificare la presentazione e inserire nuovo testo.
- [OnlyUsed](https://reference.aspose.com/slides/it/java/com.aspose.slides/embedfontcharacters/) incorpora solo i caratteri usati nella presentazione per ridurre le dimensioni del file. Scegli questa opzione per una presentazione definitiva destinata principalmente alla visualizzazione.

L’esempio seguente utilizza [getFonts](https://reference.aspose.com/slides/it/java/com.aspose.slides/ifontsmanager/#getFonts--) per recuperare i caratteri usati in `Fonts.pptx` e incorpora quelli non già incorporati. I caratteri da aggiungere devono essere disponibili sulla macchina che esegue il codice. I caratteri incorporati esistenti mantengono i set di caratteri correnti.

```java
import com.aspose.slides.EmbedFontCharacters;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.util.HashSet;
import java.util.Locale;
import java.util.Set;

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    IFontData[] allFonts = fontsManager.getFonts();
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();
    Set<String> embeddedFontNames = new HashSet<String>();

    for (IFontData embeddedFont : embeddedFonts) {
        embeddedFontNames.add(embeddedFont.getFontName().toLowerCase(Locale.ROOT));
    }

    for (IFontData font : allFonts) {
        String fontName = font.getFontName().toLowerCase(Locale.ROOT);
        if (!embeddedFontNames.contains(fontName)) {
            fontsManager.addEmbeddedFont(font, EmbedFontCharacters.All);
            embeddedFontNames.add(fontName);
        }
    }

    presentation.save("WithEmbeddedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Comprimere i caratteri incorporati**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/it/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) riduce i dati dei caratteri incorporati eliminando i caratteri inutilizzati. Operano sui caratteri già incorporati, quindi la riduzione delle dimensioni dipende da quanti dati di carattere inutilizzati contiene la presentazione.

L’esempio seguente comprime i caratteri in `EmbeddedFonts.pptx` e salva il risultato in un file separato:

```java
import com.aspose.slides.Compress;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("EmbeddedFonts.pptx");
try {
    Compress.compressEmbeddedFonts(presentation);
    presentation.save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Conserva il file originale se i destinatari potrebbero aver bisogno di aggiungere testo in seguito. I caratteri rimossi durante la compressione non sono più disponibili dal carattere incorporato, anche se inizialmente erano stati incorporati tutti i caratteri.

## **FAQ**

**Come posso verificare se un carattere incorporato verrà comunque sostituito durante il rendering?**

Chiama [getSubstitutions](https://reference.aspose.com/slides/it/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) nell’ambiente in cui esegui il rendering della presentazione per vedere quali caratteri Aspose.Slides sostituirà. Controlla anche le impostazioni di [sostituzione dei caratteri](/slides/it/java/font-substitution/) e le regole di [fallback dei caratteri](/slides/it/java/fallback-font/). Il fallback gestisce i caratteri mancanti, quindi incorporare un carattere non risolve i caratteri che il carattere stesso non contiene.

**Devo incorporare caratteri comuni come Arial e Calibri?**

Fai la scelta in base all’ambiente di destinazione. Se i caratteri richiesti sono disponibili su ogni macchina che apre o rende la presentazione, incorporarli potrebbe aggiungere una dimensione di file non necessaria. Se i destinatari o i server potrebbero non avere quei caratteri, incorporarli può aiutare a preservare l’aspetto previsto, a condizione che le loro licenze lo consentano.