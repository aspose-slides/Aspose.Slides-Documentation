---
title: Ottenere le callback di avviso per la sostituzione dei caratteri
type: docs
weight: 70
url: /it/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- callback di avviso
- sostituzione dei caratteri
- processo di rendering
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Impara a ottenere le callback di avviso per la sostituzione dei caratteri in Aspose.Slides per C++ e a visualizzare correttamente le presentazioni PowerPoint e OpenDocument."
---
## **Introduzione**

Aspose.Slides per C++ consente di ricevere callback di avviso per la sostituzione dei caratteri quando un carattere richiesto non è disponibile sulla macchina durante il rendering. Queste callback aiutano a diagnosticare problemi con caratteri mancanti o inaccessibili.

## **Abilitare le Callback di Avviso**

Aspose.Slides per C++ fornisce API semplici per ricevere callback di avviso durante il rendering delle diapositive di presentazione. Segui questi passaggi per configurare le callback di avviso:

1. Crea una classe di callback personalizzata che implementa l'interfaccia [IWarningCallback](https://reference.aspose.com/slides/it/cpp/aspose.slides.warnings/iwarningcallback/) per gestire gli avvisi.
2. Imposta la callback di avviso utilizzando classi di opzioni come [RenderingOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/renderingoptions/), [PdfOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/htmloptions/) e altre.
3. Carica una presentazione che utilizza un carattere non disponibile sulla macchina di destinazione.
4. Genera una miniatura della diapositiva o esporta la presentazione per osservare l'effetto.

**Classe di Callback di Avviso Personalizzata:**

```cpp
#include <Warnings/IWarningCallback.h>

class FontWarningHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override;
};

ReturnAction FontWarningHandler::Warning(SharedPtr<IWarningInfo> warning)
{
    if (warning->get_WarningType() == WarningType::DataLoss)
    {
        Console::WriteLine(warning->get_Description());
    }

    return ReturnAction::Continue;
}

// Esempio di output:
//
// Il carattere verrà sostituito da XYZ a {Calibri,Cambria Math,MS Gothic,Gulim,Arial Unicode,SimSun,Segoe UI Symbol}}
```

**Genera una Miniatura della Diapositiva:**

```cpp
// Configura una callback di avviso per gestire gli avvisi relativi ai caratteri durante il rendering delle diapositive.
auto options = MakeObject<RenderingOptions>();
options->set_WarningCallback(MakeObject<FontWarningHandler>());

// Carica la presentazione dal percorso file specificato.
auto presentation = MakeObject<Presentation>(u"sample.pptx");
    
// Genera un'immagine in miniatura per ogni diapositiva nella presentazione.
for(auto&& slide : presentation->get_Slides())
{
    // Ottieni l'immagine in miniatura della diapositiva utilizzando le opzioni di rendering specificate.
    auto image = slide->GetImage(options);
    // ...

    image->Dispose();
}

presentation->Dispose();
```

**Esporta in Formato PDF:**

```cpp
// Configura una callback di avviso per gestire gli avvisi relativi ai caratteri durante l'esportazione PDF.
auto options = MakeObject<PdfOptions>();
options->set_WarningCallback(MakeObject<FontWarningHandler>());

// Carica la presentazione dal percorso file specificato.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Esporta la presentazione come PDF.
auto stream = MakeObject<MemoryStream>();
presentation->Save(stream, SaveFormat::Pdf, options);
// ...

stream->Dispose();
presentation->Dispose();
```

**Esporta in Formato HTML:**

```cpp
// Configura una callback di avviso per gestire gli avvisi relativi ai caratteri durante l'esportazione HTML.
auto options = MakeObject<HtmlOptions>();
options->set_WarningCallback(MakeObject<FontWarningHandler>());

// Carica la presentazione dal percorso file specificato.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Esporta la presentazione nel formato HTML.
auto stream = MakeObject<MemoryStream>();
presentation->Save(stream, SaveFormat::Html, options);
// ...

stream->Dispose();
presentation->Dispose();
```