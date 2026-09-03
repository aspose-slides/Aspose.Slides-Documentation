---
title: Incorporare i caratteri nelle presentazioni in .NET
linktitle: Caratteri incorporati
type: docs
weight: 40
url: /it/net/embedded-font/
keywords:
- aggiungi carattere
- incorpora carattere
- incorporamento dei caratteri
- recupera carattere incorporato
- aggiungi carattere incorporato
- rimuovi carattere incorporato
- comprimi carattere incorporato
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Gestisci i caratteri incorporati in PowerPoint con Aspose.Slides per .NET. Usa C# per aggiungere, recuperare, rimuovere e comprimere i caratteri per preservare l'aspetto del testo e ridurre le dimensioni del file."
---
## **Introduzione**

L'incorporamento dei caratteri memorizza i dati del carattere all'interno di una presentazione PowerPoint. Quando un visualizzatore supporta i caratteri incorporati, può visualizzare il testo usando tali caratteri anche se non sono installati sul sistema di destinazione. Questo aiuta a preservare le interruzioni di riga, la spaziatura del testo e il layout delle diapositive.

Aspose.Slides for .NET consente di recuperare, aggiungere e rimuovere i caratteri incorporati tramite la proprietà [FontsManager](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/fontsmanager/) di una [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/). È inoltre possibile ridurre le dimensioni dei dati dei caratteri incorporati rimuovendo i caratteri che la presentazione non utilizza.

Gli esempi seguenti funzionano con file PPTX. Prima di incorporare un carattere, assicurati che i dati del carattere siano disponibili per Aspose.Slides e che la sua licenza consenta l'incorporamento.

## **Recuperare e rimuovere i caratteri incorporati**

Usa [GetEmbeddedFonts](https://reference.aspose.com/slides/it/net/aspose.slides/fontsmanager/getembeddedfonts/) per elencare i caratteri memorizzati in una presentazione. Per rimuoverne uno, passa un carattere da quell'elenco a [RemoveEmbeddedFont](https://reference.aspose.com/slides/it/net/aspose.slides/fontsmanager/removeembeddedfont/), quindi salva la presentazione.

Il seguente esempio elenca i caratteri incorporati in `EmbeddedFonts.pptx` e rimuove Calibri se presente:
```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("EmbeddedFonts.pptx");
var fontsManager = presentation.FontsManager;
var embeddedFonts = fontsManager.GetEmbeddedFonts();

foreach (var font in embeddedFonts)
{
    Console.WriteLine(font.FontName);
}

var fontToRemove = Array.Find(embeddedFonts, font => string.Equals(font.FontName, "Calibri", StringComparison.OrdinalIgnoreCase));
if (fontToRemove != null)
{
    fontsManager.RemoveEmbeddedFont(fontToRemove);
    presentation.Save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Calibri is not embedded. No output file was created.");
}
```

Rimuovere un carattere incorporato elimina i dati del carattere memorizzati; non cambia il carattere assegnato al testo. Se il carattere è installato sul sistema di destinazione, il testo può comunque usarlo. Altrimenti, il rendering potrebbe richiedere la [sostituzione dei caratteri](/slides/it/net/font-substitution/), che può influire sul layout.

## **Ispezionare i dati dei caratteri e le autorizzazioni di incorporamento**

Usa l'interfaccia [IFontsManager](https://reference.aspose.com/slides/it/net/aspose.slides/ifontsmanager/) per ispezionare i caratteri prima di incorporarli. Chiama [IFontsManager.GetFonts](https://reference.aspose.com/slides/it/net/aspose.slides/ifontsmanager/getfonts/) per recuperare i caratteri usati nella presentazione. Per ogni carattere, passa un oggetto [IFontData](https://reference.aspose.com/slides/it/net/aspose.slides/ifontdata/) e il valore richiesto di [FontStyleType](https://reference.aspose.com/slides/it/net/aspose.slides/fontstyletype/) a [IFontsManager.GetFontBytes](https://reference.aspose.com/slides/it/net/aspose.slides/ifontsmanager/getfontbytes/). Il metodo restituisce i dati binari per quello stile di carattere, o `null` quando il carattere o lo stile richiesto non è disponibile. Non passare un risultato `null` a [IFontsManager.GetFontEmbeddingLevel](https://reference.aspose.com/slides/it/net/aspose.slides/ifontsmanager/getfontembeddinglevel/), perché quel metodo richiede un array di byte.

[EmbeddingLevel](https://reference.aspose.com/slides/it/net/aspose.slides/embeddinglevel/) è un'enumerazione a flag che riporta le restrizioni di incorporamento memorizzate nel carattere:
- `Installable` consente l'incorporamento e l'installazione permanente su un altro sistema, soggetto alla licenza del carattere.
- `Restricted` vieta l'incorporamento a meno che non venga ottenuta l'autorizzazione dal proprietario legale del carattere quando è l'unico flag di autorizzazione all'uso.
- `PreviewPrint` consente l'uso temporaneo per visualizzazione e stampa; un documento contenente il carattere deve essere di sola lettura.
- `Editable` consente l'uso temporaneo e permette al documento di essere modificato e salvato.
- `NoSubsetting` è una restrizione aggiuntiva che vieta l'incorporamento solo di un sottoinsieme di glifi. Incorpora tutti i caratteri quando questo flag è presente.
- `BitmapOnly` è una restrizione aggiuntiva che consente l'incorporamento solo di versioni bitmap, non dei dati vettoriali. Se il carattere non ha versioni bitmap, non può essere incorporato.

I primi quattro valori descrivono l'autorizzazione all'uso, mentre `NoSubsetting` e `BitmapOnly` possono essere combinati con essi. Verifica i modificatori con operazioni bitwise. Poiché `Installable` è zero, non usare `HasFlag` per rilevarlo; maschera i bit di autorizzazione all'uso e confronta il risultato con `Installable`. I caratteri attuali dovrebbero impostare al massimo un bit di autorizzazione all'uso. Per compatibilità con caratteri più vecchi che impostano più di un bit, l'utilità sottostante seleziona l'autorizzazione meno restrittiva: `Editable`, poi `PreviewPrint`, poi `Restricted`.

Il seguente esempio verifica i dati regolari, grassetto, corsivo e grassetto‑corsivo disponibili per ogni carattere restituito da `GetFonts`. Salta gli stili non disponibili, i caratteri limitati, i caratteri bitmap‑only, i caratteri limitati a anteprima e stampa perché l'output rimane modificabile, e i caratteri già incorporati. Se qualche stile disponibile ha `NoSubsetting`, incorpora tutti i caratteri per quella famiglia di caratteri.
```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

static EmbeddingLevel GetUsagePermission(EmbeddingLevel level)
{
    const EmbeddingLevel permissionMask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable;
    var permissions = level & permissionMask;

    if ((permissions & EmbeddingLevel.Editable) != 0)
    {
        return EmbeddingLevel.Editable;
    }

    if ((permissions & EmbeddingLevel.PreviewPrint) != 0)
    {
        return EmbeddingLevel.PreviewPrint;
    }

    if ((permissions & EmbeddingLevel.Restricted) != 0)
    {
        return EmbeddingLevel.Restricted;
    }

    return EmbeddingLevel.Installable;
}

using var presentation = new Presentation("Fonts.pptx");
var fontsManager = presentation.FontsManager;
var fontStyles = new[]
{
    FontStyleType.Regular,
    FontStyleType.Bold,
    FontStyleType.Italic,
    FontStyleType.Bold | FontStyleType.Italic
};

var embeddedFontNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
foreach (var embeddedFont in fontsManager.GetEmbeddedFonts())
{
    embeddedFontNames.Add(embeddedFont.FontName);
}

var embeddingPlan = new List<(IFontData Font, EmbedFontCharacters Rule)>();
foreach (var font in fontsManager.GetFonts())
{
    if (embeddedFontNames.Contains(font.FontName))
    {
        Console.WriteLine($"{font.FontName}: already embedded.");
        continue;
    }

    var hasAvailableData = false;
    var allAvailableStylesCanBeEmbedded = true;
    var previewPrintOnly = false;
    var requiresFullFont = false;

    foreach (var fontStyle in fontStyles)
    {
        var fontBytes = fontsManager.GetFontBytes(font, fontStyle);
        if (fontBytes == null)
        {
            Console.WriteLine($"{font.FontName} ({fontStyle}): font data is unavailable.");
            continue;
        }

        hasAvailableData = true;
        var embeddingLevel = fontsManager.GetFontEmbeddingLevel(fontBytes, font.FontName);
        var usagePermission = GetUsagePermission(embeddingLevel);
        var noSubsetting = (embeddingLevel & EmbeddingLevel.NoSubsetting) != 0;
        var bitmapOnly = (embeddingLevel & EmbeddingLevel.BitmapOnly) != 0;

        requiresFullFont |= noSubsetting;
        previewPrintOnly |= usagePermission == EmbeddingLevel.PreviewPrint;
        allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel.Restricted && !bitmapOnly;

        Console.WriteLine($"{font.FontName} ({fontStyle}): {embeddingLevel}.");
    }

    if (!hasAvailableData)
    {
        Console.WriteLine($"{font.FontName}: skipped because no requested style is available.");
    }
    else if (!allAvailableStylesCanBeEmbedded)
    {
        Console.WriteLine($"{font.FontName}: skipped because at least one available style does not permit outline embedding.");
    }
    else if (previewPrintOnly)
    {
        Console.WriteLine($"{font.FontName}: skipped because this example produces an editable presentation.");
    }
    else
    {
        var rule = requiresFullFont ? EmbedFontCharacters.All : EmbedFontCharacters.OnlyUsed;
        embeddingPlan.Add((font, rule));
    }
}

foreach (var item in embeddingPlan)
{
    fontsManager.AddEmbeddedFont(item.Font, item.Rule);
}

presentation.Save("WithAuditedFonts.pptx", SaveFormat.Pptx);
```

Questa ispezione segnala le restrizioni codificate in ogni file di carattere. Non concede una licenza, non dimostra che il carattere sia stato ottenuto legalmente, né sostituisce il controllo del contratto di licenza del carattere prima di distribuire una copia incorporata.

## **Aggiungere caratteri incorporati**

Usa [AddEmbeddedFont](https://reference.aspose.com/slides/it/net/aspose.slides/fontsmanager/addembeddedfont/) per incorporare un carattere. Le sue sovraccarichi accettano sia un oggetto [IFontData](https://reference.aspose.com/slides/it/net/aspose.slides/ifontdata/) sia un array di byte contenente i dati del carattere. L'enumerazione [EmbedFontCharacters](https://reference.aspose.com/slides/it/net/aspose.slides.export/embedfontcharacters/) controlla quali caratteri sono inclusi:
- [All](https://reference.aspose.com/slides/it/net/aspose.slides.export/embedfontcharacters/) incorpora tutti i caratteri nel font. Usa questa opzione quando i destinatari devono modificare la presentazione e inserire nuovo testo.
- [OnlyUsed](https://reference.aspose.com/slides/it/net/aspose.slides.export/embedfontcharacters/) incorpora solo i caratteri usati nella presentazione per ridurre la dimensione del file. Scegli questa opzione per una presentazione finita destinata principalmente alla visualizzazione.

Il seguente esempio utilizza [GetFonts](https://reference.aspose.com/slides/it/net/aspose.slides/fontsmanager/getfonts/) per recuperare i caratteri usati in `Fonts.pptx` e incorpora quelli non ancora incorporati. I caratteri da aggiungere devono essere disponibili sulla macchina che esegue il codice. I caratteri già incorporati mantengono i loro set di caratteri attuali.
```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Fonts.pptx");
var fontsManager = presentation.FontsManager;
var allFonts = fontsManager.GetFonts();
var embeddedFonts = fontsManager.GetEmbeddedFonts();
var embeddedFontNames = embeddedFonts.Select(font => font.FontName);
var embeddedNames = new HashSet<string>(embeddedFontNames, StringComparer.OrdinalIgnoreCase);

foreach (var font in allFonts)
{
    if (!embeddedNames.Contains(font.FontName))
    {
        fontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
        embeddedNames.Add(font.FontName);
    }
}

presentation.Save("WithEmbeddedFonts.pptx", SaveFormat.Pptx);
```

## **Comprimere i caratteri incorporati**

[CompressEmbeddedFonts](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/compress/compressembeddedfonts/) riduce i dati dei caratteri incorporati rimuovendo i caratteri inutilizzati. Opera sui caratteri già incorporati, quindi la riduzione delle dimensioni dipende da quanti dati di carattere inutilizzati contiene la presentazione.

Il seguente esempio comprime i caratteri in `EmbeddedFonts.pptx` e salva il risultato in un file separato:
```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("EmbeddedFonts.pptx");
Compress.CompressEmbeddedFonts(presentation);
presentation.Save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
```

Conserva il file originale se i destinatari potrebbero aver bisogno di aggiungere testo in seguito. I caratteri rimossi durante la compressione non sono più disponibili dal carattere incorporato, anche se inizialmente hai incorporato tutti i caratteri.

## **FAQ**

**Come posso verificare se un carattere incorporato verrà comunque sostituito durante il rendering?**

Chiama [GetSubstitutions](https://reference.aspose.com/slides/it/net/aspose.slides/fontsmanager/getsubstitutions/) nell'ambiente in cui renderizzi la presentazione per vedere quali caratteri Aspose.Slides sostituirà. Controlla anche le impostazioni di [sostituzione dei caratteri](/slides/it/net/font-substitution/) e le regole di [fallback dei caratteri](/slides/it/net/fallback-font/). Il fallback gestisce i caratteri mancanti, quindi l'incorporamento di un carattere non risolve i caratteri che il carattere stesso non contiene.

**Devo incorporare caratteri comuni come Arial e Calibri?**

Basare la decisione sull'ambiente di destinazione. Se i caratteri richiesti sono disponibili su ogni macchina che apre o rende la presentazione, incorporarli potrebbe aggiungere una dimensione di file non necessaria. Se i destinatari o i server potrebbero non disporre di quei caratteri, incorporarli può aiutare a preservare l'aspetto previsto, a condizione che le loro licenze lo consentano.