---
title: Incorporare i font nelle presentazioni in .NET
linktitle: Font incorporati
type: docs
weight: 40
url: /it/net/embedded-font/
keywords:
- aggiungere font
- incorporare font
- incorporamento di font
- recuperare font incorporato
- aggiungere font incorporato
- rimuovere font incorporato
- comprimere font incorporato
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Gestisci i font incorporati in PowerPoint con Aspose.Slides per .NET. Usa C# per aggiungere, recuperare, rimuovere e comprimere i font per preservare l'aspetto del testo e ridurre le dimensioni del file."
---
## **Introduzione**

L’incorporamento dei font memorizza i dati del font all’interno di una presentazione PowerPoint. Quando un visualizzatore supporta i font incorporati, può visualizzare il testo usando tali font anche se non sono installati sul sistema di destinazione. Questo aiuta a preservare le interruzioni di riga, la spaziatura del testo e il layout delle diapositive.

Aspose.Slides per .NET consente di recuperare, aggiungere e rimuovere font incorporati tramite la proprietà [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/) di una [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/). È inoltre possibile ridurre le dimensioni dei dati del font incorporato rimuovendo i caratteri non usati nella presentazione.

Gli esempi seguenti funzionano con file PPTX. Prima di incorporare un font, assicurarsi che i dati del font siano disponibili per Aspose.Slides e che la licenza consenta l’incorporamento.

## **Ottenere e rimuovere i font incorporati**

Utilizzare [GetEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getembeddedfonts/) per elencare i font memorizzati in una presentazione. Per rimuoverne uno, passare un font da tale elenco a [RemoveEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/removeembeddedfont/), quindi salvare la presentazione.

Il seguente esempio elenca i font incorporati in `EmbeddedFonts.pptx` e rimuove Calibri se presente:

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

La rimozione di un font incorporato elimina i dati del font memorizzati; non modifica il font assegnato al testo. Se il font è installato sul sistema di destinazione, il testo può comunque usarlo. In caso contrario, il rendering potrebbe richiedere la [font substitution](/slides/it/net/font-substitution/), il che può influire sul layout.

## **Ispezionare i dati del font e i permessi di incorporamento**

Utilizzare l’interfaccia [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/) per ispezionare i font prima di incorporarli. Chiamare [IFontsManager.GetFonts](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getfonts/) per recuperare i font usati nella presentazione. Per ogni font, passare un oggetto [IFontData](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/) e il valore richiesto di [FontStyleType](https://reference.aspose.com/slides/net/aspose.slides/fontstyletype/) a [IFontsManager.GetFontBytes](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getfontbytes/). Il metodo restituisce i dati binari per quello stile di font, o `null` quando il font o lo stile richiesto non è disponibile. Non passare un risultato `null` a [IFontsManager.GetFontEmbeddingLevel](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getfontembeddinglevel/), poiché quel metodo richiede un array di byte.

[EmbeddingLevel](https://reference.aspose.com/slides/net/aspose.slides/embeddinglevel/) è un’enumerazione a flag che riporta le restrizioni di incorporamento memorizzate nel font:

- `Installable` consente l’incorporamento e l’installazione permanente su un altro sistema, soggetto alla licenza del font.
- `Restricted` vieta l’incorporamento a meno che non venga ottenuta l’autorizzazione dal proprietario legale del font quando è l’unico flag di permesso di utilizzo.
- `PreviewPrint` consente l’uso temporaneo per visualizzazione e stampa; un documento contenente il font deve essere di sola lettura.
- `Editable` consente l’uso temporaneo e permette di modificare e salvare il documento.
- `NoSubsetting` è una restrizione aggiuntiva che vieta l’incorporamento di un sottoinsieme di glifi. Incorporare tutti i caratteri quando questo flag è presente.
- `BitmapOnly` è una restrizione aggiuntiva che consente di incorporare solo le versioni bitmap, non i dati di contorno. Se il font non dispone di versioni bitmap, non può essere incorporato.

I primi quattro valori descrivono il permesso di utilizzo, mentre `NoSubsetting` e `BitmapOnly` possono essere combinati con essi. Verificare i modificatori con operazioni bitwise. Poiché `Installable` è zero, non usare `HasFlag` per rilevarlo; mascherare i bit di permesso di utilizzo e confrontare il risultato con `Installable`. I font attuali dovrebbero impostare al massimo un bit di permesso di utilizzo. Per compatibilità con font più vecchi che impostano più di uno, l’aiuto qui sotto seleziona il permesso meno restrittivo: `Editable`, poi `PreviewPrint`, poi `Restricted`.

Il seguente esempio verifica i dati regolari, grassetto, corsivo e grassetto‑corsivo disponibili per ogni font restituito da `GetFonts`. Salta gli stili non disponibili, i font con restrizioni, i font solo bitmap, i font limitati a anteprima e stampa perché l’output rimane modificabile, e i font già incorporati. Se qualche stile disponibile ha `NoSubsetting`, incorpora tutti i caratteri per quella famiglia di font.

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

Questa ispezione denuncia le restrizioni codificate in ogni file di font. Non concede una licenza, non dimostra che il font è stato ottenuto legalmente e non sostituisce la verifica del contratto di licenza del font prima di distribuire una copia incorporata.

## **Aggiungere font incorporati**

Utilizzare [AddEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/addembeddedfont/) per incorporare un font. Le sue sovraccariche accettano un oggetto [IFontData](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/) oppure un array di byte contenente i dati del font. L’enumerazione [EmbedFontCharacters](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) controlla quali caratteri includere:

- [All](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) incorpora tutti i caratteri del font. Usare questa opzione quando i destinatari hanno bisogno di modificare la presentazione e inserire nuovo testo.
- [OnlyUsed](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) incorpora solo i caratteri usati nella presentazione per ridurre le dimensioni del file. Scegliere questa opzione per una presentazione finita destinata principalmente alla visualizzazione.

Il seguente esempio usa [GetFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getfonts/) per recuperare i font usati in `Fonts.pptx` e incorpora quelli non ancora incorporati. I font da aggiungere devono essere disponibili sulla macchina che esegue il codice. I font già incorporati mantengono i set di caratteri correnti.

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

## **Comprimere i font incorporati**

[CompressEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressembeddedfonts/) riduce i dati dei font incorporati rimuovendo i caratteri inutilizzati. Opera sui font già incorporati, quindi la riduzione delle dimensioni dipende da quanti dati di font inutilizzati contiene la presentazione.

Il seguente esempio comprime i font in `EmbeddedFonts.pptx` e salva il risultato in un file separato:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("EmbeddedFonts.pptx");
Compress.CompressEmbeddedFonts(presentation);
presentation.Save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
```

Conservare il file originale se i destinatari potrebbero aver bisogno di aggiungere testo in seguito. I caratteri rimossi durante la compressione non sono più disponibili dal font incorporato, anche se originariamente erano stati incorporati tutti i caratteri.

Per consentire a un font registrato corrispondente di avere priorità durante l’esportazione senza rimuovere il font incorporato, vedere [Prefer Registered Fonts over Embedded Fonts](/slides/it/net/font-selection-sequence/#prefer-registered-fonts-over-embedded-fonts) (.NET 26.11 o versioni successive).

## **FAQ**

**Come posso verificare se un font incorporato verrà comunque sostituito durante il rendering?**

Chiamare [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getsubstitutions/) nell’ambiente in cui si rende la presentazione per vedere quali font Aspose.Slides sostituirà. Controllare anche le impostazioni di [font substitution](/slides/it/net/font-substitution/) e le regole di [font fallback](/slides/it/net/fallback-font/). Il fallback gestisce i caratteri mancanti, quindi incorporare un font non risolve i caratteri che il font stesso non contiene.

**Devo incorporare font comuni come Arial e Calibri?**

Basare la decisione sull’ambiente di destinazione. Se i font richiesti sono disponibili su ogni macchina che apre o rende la presentazione, incorporarli può aggiungere dimensioni inutili al file. Se i destinatari o i server potrebbero non disporre di tali font, incorporarli può aiutare a preservare l’aspetto previsto, purché le loro licenze lo consentano.