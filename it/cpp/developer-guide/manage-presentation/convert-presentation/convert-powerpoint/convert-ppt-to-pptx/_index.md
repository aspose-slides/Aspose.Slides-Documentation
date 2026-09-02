---
title: Converti PPT in PPTX in C++
linktitle: PPT in PPTX
type: docs
weight: 20
url: /it/cpp/convert-ppt-to-pptx/
keywords:
- converti PowerPoint
- converti presentazione
- converti diapositiva
- converti PPT
- PPT in PPTX
- salva PPT come PPTX
- esporta PPT in PPTX
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Converti i file PPT legacy in PPTX in C++ con Aspose.Slides. Include esempi C++ per la conversione di file singoli e batch, gestione degli errori e note sulla fedeltà."
---
## **Panoramica**

PPT è il formato binario legacy di PowerPoint, mentre PPTX è il nuovo formato Open XML. Aspose.Slides per C++ può caricare un file PPT e salvarlo come PPTX senza Microsoft PowerPoint. Questo articolo mostra come convertire un file o una directory di file e spiega cosa verificare dopo la conversione.

## **Convertire un file PPT in PPTX**

Carica il file di origine con la classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/), poi chiama [Presentation::Save](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/save/) passando [SaveFormat::Pptx](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/saveformat/). Rilascia la presentazione quando non è più necessaria per liberare le sue risorse.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Load the legacy PPT presentation.
auto presentation = System::MakeObject<Presentation>(u"presentation.ppt");

// Save the presentation in PPTX format.
presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

L'estensione del file non seleziona il formato di output da sola; lo fa l'argomento [SaveFormat::Pptx](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/saveformat/). Mantieni i percorsi di input e output diversi se devi conservare il file PPT originale.

## **Convertire più file PPT**

L'esempio seguente converte ogni file `.ppt` in una directory. Ogni file viene elaborato in modo indipendente, quindi un fallimento di conversione non interrompe il resto del batch.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

String inputDirectory = u"input";
String outputDirectory = u"output";
Directory::CreateDirectory_(outputDirectory);

auto inputPaths = Directory::GetFiles(inputDirectory, u"*.ppt", SearchOption::TopDirectoryOnly);
for (const auto& inputPath : inputPaths)
{
    auto outputFileName = Path::GetFileNameWithoutExtension(inputPath) + u".pptx";
    auto outputPath = Path::Combine(outputDirectory, outputFileName);

    try
    {
        auto presentation = MakeObject<Presentation>(inputPath);
        presentation->Save(outputPath, SaveFormat::Pptx);
        presentation->Dispose();
        Console::WriteLine(String::Format(u"Converted: {0}", inputPath));
    }
    catch (Exception& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Failed: {0} ({1})", inputPath, exception->get_Message()));
    }
}
```

Per carichi di lavoro di produzione, registra l'eccezione completa, decide se un file di output esistente può essere sovrascritto e scrivi i nomi dei file non riusciti in una coda di ripetizione o revisione. File corrotti, file protetti da password aperti senza la password richiesta, percorsi non accessibili e contenuti non supportati possono tutti causare un errore di conversione. Consulta [Presentazioni protette da password](/slides/it/cpp/password-protected-presentation/) per caricare file crittografati.

## **Fedeltà e funzionalità legacy**

La conversione di norma preserva diapositive, master, layout, testo, forme, immagini, tabelle e grafici. Tuttavia, PPT e PPTX non rappresentano ogni funzionalità nello stesso modo esatto. Una funzionalità legacy che non ha un equivalente PPTX, o non è supportata dalla libreria, può essere normalizzata, omessa o visualizzata in modo diverso.

Verifica il file convertito quando contiene animazioni, transizioni, oggetti OLE incorporati o collegati, controlli ActiveX, media incorporati, caratteri non comuni o macro VBA. Un file PPTX semplice non è un formato abilitato alle macro, quindi utilizza un flusso di lavoro appropriato per macro quando VBA deve rimanere disponibile. Verifica inoltre che i caratteri richiesti e le risorse esterne siano presenti nell'ambiente in cui la presentazione convertita verrà aperta o renderizzata.

Per documenti importanti, riapri il PPTX generato programmaticamente e ispeziona il numero chiave di diapositive e il contenuto, quindi confronta il suo aspetto e il comportamento della presentazione in visualizzatore previsto. Non considerare una chiamata riuscita a [Presentation::Save](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/save/) come prova che ogni funzionalità legacy abbia una rappresentazione PPTX esatta.

## **Quando utilizzare PPTX**

Utilizza PPTX quando la presentazione verrà modificata nelle versioni attuali di PowerPoint, scambiata con sistemi che lavorano con pacchetti Open XML, o archiviata in un formato più facile da ispezionare e recuperare rispetto al legacy binario PPT. Conserva il PPT originale come copia di archivio o di ripristino finché la presentazione convertita non supera i tuoi controlli di fedeltà.

Se hai bisogno invece di PDF, HTML, immagini, XPS o un altro tipo di output, usa le indicazioni specifiche per il formato in [Convertire le presentazioni in più formati](/slides/it/cpp/convert-presentation/) invece di presumere che tutti i target conservino le funzionalità modificabili di PowerPoint.

## **Convertitore online**

Per un file occasionale o un confronto rapido, puoi utilizzare il [convertitore online da PPT a PPTX](https://products.aspose.app/slides/it/conversion/ppt-to-pptx). Per conversioni ripetibili, elaborazione batch o gestione degli errori a livello di applicazione, usa l'API C++.

## **Articoli correlati**

- [Salvare le presentazioni in C++](/slides/it/cpp/save-presentation/)
- [Formati di file supportati](/slides/it/cpp/supported-file-formats/)
- [Aprire le presentazioni in C++](/slides/it/cpp/open-presentation/)

## **FAQ**

**Posso convertire PPT in PPTX senza Microsoft PowerPoint installato?**

Sì. Aspose.Slides per C++ carica e salva i file di presentazione senza richiedere Microsoft PowerPoint.

**La conversione da PPT a PPTX preserverà tutto il contenuto esattamente?**

Preserva il contenuto comune della presentazione, ma la fedeltà esatta non è garantita per ogni funzionalità legacy o non supportata. Verifica il file generato quando contiene macro, oggetti OLE o ActiveX, media, animazioni specializzate o caratteri non comuni.

**Posso convertire un file PPT protetto da password?**

Sì, se fornisci la password corretta durante il caricamento del file. Una password mancante o errata provoca il fallimento dell'operazione di caricamento.

**Devo eliminare il file PPT dopo la conversione?**

Conserva l'originale finché non hai verificato il PPTX nei visualizzatori e nei flussi di lavoro che ti interessano. Questo fornisce una copia di ripristino se una funzionalità legacy viene convertita in modo diverso.