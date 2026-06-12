---
title: Ottenere le callback di avviso per la sostituzione dei caratteri in .NET
type: docs
weight: 120
url: /it/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- callback di avviso
- sostituzione dei caratteri
- processo di rendering
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Impara a ottenere le callback di avviso per la sostituzione dei caratteri in Aspose.Slides per .NET e a visualizzare correttamente le presentazioni PowerPoint e OpenDocument."
---
## **Introduzione**

Aspose.Slides for .NET consente di ricevere callback di avviso per la sostituzione dei caratteri quando un carattere richiesto non è disponibile sul computer durante il rendering. Queste callback aiutano a diagnosticare problemi legati a caratteri mancanti o inaccessibili.

## **Abilitare le Callback di Avviso**

Aspose.Slides for .NET fornisce API semplici per ricevere callback di avviso durante il rendering delle diapositive di una presentazione. Segui questi passaggi per configurare le callback di avviso:

1. Crea una classe di callback personalizzata che implementa l'interfaccia [IWarningCallback](https://reference.aspose.com/slides/it/net/aspose.slides.warnings/iwarningcallback/) per gestire gli avvisi.  
2. Imposta la callback di avviso utilizzando classi di opzioni come [RenderingOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/renderingoptions/), [PdfOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/htmloptions/), e altre.  
3. Carica una presentazione che utilizza un carattere non disponibile sulla macchina di destinazione.  
4. Genera una miniatura della diapositiva o esporta la presentazione per osservare l'effetto.

**Classe di Callback di Avviso Personalizzata:**

```c#
class FontWarningHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss)
        {
            Console.WriteLine(warning.Description);
        }

        return ReturnAction.Continue;
    }
}

// Esempio di output:
//
// Il font verrà sostituito da XYZ a {Calibri,Cambria Math,MS Gothic,Gulim,Arial Unicode,SimSun,Segoe UI Symbol}}
```

**Genera una Miniatura della Diapositiva:**

```c#
// Configura una callback di avviso per gestire gli avvisi relativi ai caratteri durante il rendering delle diapositive.
var options = new RenderingOptions();
options.WarningCallback = new FontWarningHandler();

// Carica la presentazione dal percorso file specificato.
using var presentation = new Presentation("sample.pptx");

// Genera un'immagine miniatura per ogni diapositiva nella presentazione.
foreach (var slide in presentation.Slides)
{
    // Ottieni l'immagine miniatura della diapositiva usando le opzioni di rendering specificate.
    using var image = slide.GetImage(options);
    // ...
}
```

**Esporta in Formato PDF:**

```c#
// Configura una callback di avviso per gestire gli avvisi relativi ai caratteri durante l'esportazione PDF.
var options = new PdfOptions();
options.WarningCallback = new FontWarningHandler();

// Carica la presentazione dal percorso file specificato.
using var presentation = new Presentation("sample.pptx");

// Esporta la presentazione come PDF.
using var stream = new MemoryStream();
presentation.Save(stream, SaveFormat.Pdf, options);
// ...
```

**Esporta in Formato HTML:**

```c#
// Configura una callback di avviso per gestire gli avvisi relativi ai caratteri durante l'esportazione HTML.
var options = new HtmlOptions();
options.WarningCallback = new FontWarningHandler();

// Carica la presentazione dal percorso file specificato.
using var presentation = new Presentation("sample.pptx");

// Esporta la presentazione in formato HTML.
using var stream = new MemoryStream();
presentation.Save(stream, SaveFormat.Html, options);
// ...
```