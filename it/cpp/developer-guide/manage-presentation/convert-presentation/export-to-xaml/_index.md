---
title: Esporta presentazioni in XAML in C++
linktitle: Presentazione in XAML
type: docs
weight: 30
url: /it/cpp/export-to-xaml/
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
- C++
- Aspose.Slides
description: "Converti le diapositive PowerPoint e OpenDocument in XAML con C++ usando Aspose.Slides—soluzione veloce, senza Office, che mantiene intatto il layout."
---
## **Panoramica**

Questo articolo spiega come esportare presentazioni PowerPoint in XAML usando Aspose.Slides. Include una breve introduzione a XAML, mostra come salvare una presentazione in XAML con le impostazioni predefinite e dimostra come personalizzare l'esportazione tramite [XamlOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export.xaml/xamloptions/), inclusa l'esportazione delle diapositive nascoste. L'articolo risponde anche a alcune domande comuni relative ai caratteri di fallback, alla compatibilità con altre stack XAML e al comportamento dell'esportazione delle diapositive nascoste.

## **Informazioni su XAML**

XAML è un linguaggio di markup basato su XML utilizzato per descrivere interfacce utente in framework come WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) e Xamarin.Forms.

È possibile lavorare con file XAML in un designer visivo oppure scrivere e modificare direttamente il markup.

## **Esporta presentazioni in XAML con opzioni predefinite**

Il seguente esempio C++ mostra come esportare una presentazione in XAML con le impostazioni predefinite:

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/XamlOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto xamlOptions = System::MakeObject<XamlOptions>();
presentation->Save(xamlOptions);
```

Per impostazione predefinita, le diapositive esportate vengono salvate in una sottocartella `pres` nella directory di lavoro corrente del processo, come restituito da [Directory::GetCurrentDirectory](https://reference.aspose.com/slides/it/cpp/system.io/directory/getcurrentdirectory/). La cartella viene creata automaticamente e tutte le immagini necessarie vengono salvate lì.

Il nome della cartella di output è ricavato dal nome del file sorgente senza estensione. Per `pres.pptx`, i file di output sono denominati `pres/Slide_1.xaml`, `pres/Slide_2.xaml` e così via. Anche se si passa un percorso assoluto alla presentazione di input, la cartella di output viene creata in modo relativo alla directory di lavoro corrente, anziché accanto al file di input.

## **Esporta presentazioni in XAML con opzioni personalizzate**

Utilizzare l'interfaccia [IXamlOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export.xaml/ixamloptions/) per controllare come Aspose.Slides esporta una presentazione in XAML.

Per salvare l'output in una posizione personalizzata, implementare [IXamlOutputSaver](https://reference.aspose.com/slides/it/cpp/aspose.slides.export.xaml/ixamloutputsaver/) e passare un'istanza della propria implementazione al metodo [set_OutputSaver](https://reference.aspose.com/slides/it/cpp/aspose.slides.export.xaml/xamloptions/set_outputsaver/) di [XamlOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export.xaml/xamloptions/).

Per includere le diapositive nascoste nell'output XAML, passare `true` al metodo [set_ExportHiddenSlides](https://reference.aspose.com/slides/it/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/), come mostrato nel seguente esempio C++:

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/XamlOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto xamlOptions = System::MakeObject<XamlOptions>();
xamlOptions->set_ExportHiddenSlides(true);
presentation->Save(xamlOptions);
```

## **Acquisisci tutti gli artefatti XAML generati**

Un'esportazione XAML può produrre un documento XAML per ogni diapositiva esportata più immagini separate e risorse di supporto. Passare un [IXamlOutputSaver](https://reference.aspose.com/slides/it/cpp/aspose.slides.export.xaml/ixamloutputsaver/) personalizzato a [XamlOptions::set_OutputSaver](https://reference.aspose.com/slides/it/cpp/aspose.slides.export.xaml/xamloptions/set_outputsaver/) per ricevere questi artefatti invece di utilizzare il salvatore predefinito del file system. Avviare l'esportazione con la sovraccarico specifico XAML di [Presentation::Save](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/save/) che accetta le opzioni XAML.

### **Comprendere il ciclo di vita del callback**

L'esportatore chiama [IXamlOutputSaver::Save](https://reference.aspose.com/slides/it/cpp/aspose.slides.export.xaml/ixamloutputsaver/save/) separatamente per ogni artefatto generato:

- `path` identifica l'artefatto e può includere directory relative. Conservare queste informazioni perché XAML può fare riferimento a risorse usando percorsi relativi.
- `data` contiene i byte dell'artefatto. Immagini e altre risorse binarie non devono essere decodificate come testo.
- Il salvatore è responsabile di conservare o persistere i dati prima di restituire. Gli esempi copiano ogni array di byte nella memoria di proprietà dell'applicazione.
- Considerare l'esportazione come riuscita solo quando l'operazione di salvataggio della presentazione restituisce e ogni callback è terminato correttamente. Non sopprimere errori di archiviazione né avviare scritture in background non osservate. Se la persistenza avviene successivamente, segnalare il successo complessivo solo dopo che anche quel passaggio è riuscito.

[XamlOptions::set_ExportHiddenSlides](https://reference.aspose.com/slides/it/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) si applica anche a un salvatore personalizzato. L'impostazione predefinita, `false`, esclude i documenti XAML delle diapositive nascoste. Impostandola a `true` le include insieme a tutte le risorse necessarie per la loro esportazione. Il conteggio delle risorse dipende dalla presentazione; non presumere un callback per diapositiva o un ordine di callback fisso.

### **Esporta in memoria e ispeziona gli artefatti**

Questo esempio completo carica `pres.pptx`, raccoglie ogni artefatto in un [Dictionary<String, ArrayPtr<uint8_t>>](https://reference.aspose.com/slides/it/cpp/system.collections.generic/dictionary/), e stampa nome, tipo e dimensione in byte. Preserva esattamente i nomi forniti. Nomi duplicati provocano il fallimento della raccolta anziché sovrascrivere silenziosamente un artefatto.

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/IXamlOutputSaver.h>
#include <Export/Xaml/XamlOptions.h>
#include <system/array.h>
#include <system/collections/dictionary.h>
#include <system/console.h>
#include <system/string_comparer.h>
#include <system/io/path.h>
#include <system/text/encoding.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;
using namespace System::Text;

class InMemoryXamlExample
{
    class MemoryXamlSaver : public IXamlOutputSaver
    {
    public:
        using ArtifactDictionary = Dictionary<String, ArrayPtr<uint8_t>>;
        SharedPtr<ArtifactDictionary> Artifacts = MakeObject<ArtifactDictionary>(StringComparer::get_Ordinal());

        void Save(String path, ArrayPtr<uint8_t> data) override
        {
            auto retainedData = data->Clone();
            Artifacts->Add(path, retainedData);
        }
    };

public:
    static void Run()
    {
        auto saver = MakeObject<MemoryXamlSaver>();
        auto presentation = MakeObject<Presentation>(u"pres.pptx");
        auto options = MakeObject<XamlOptions>();
        options->set_OutputSaver(saver);
        options->set_ExportHiddenSlides(true);
        presentation->Save(options);

        auto inspectXamlText = false;
        for (const auto& artifact : saver->Artifacts)
        {
            auto extension = Path::GetExtension(artifact.get_Key()).ToLowerInvariant();
            auto isXaml = extension == u".xaml";
            auto isImage = extension == u".png" || extension == u".jpg" || extension == u".jpeg" || extension == u".gif" || extension == u".bmp" || extension == u".tif" || extension == u".tiff" || extension == u".svg";
            String kind = isXaml ? u"slide XAML" : isImage ? u"image" : u"supporting resource";
            Console::WriteLine(u"{0}: {1} bytes ({2})", artifact.get_Key(), artifact.get_Value()->get_Length(), kind);

            // Decodifica solo XAML, e solo quando è necessaria l'ispezione testuale.
            if (isXaml && inspectXamlText)
            {
                auto markup = Encoding::get_UTF8()->GetString(artifact.get_Value());
                Console::WriteLine(markup);
            }
        }
    }
};
```

Chiamare `InMemoryXamlExample::Run` dalla propria applicazione. I controlli di estensione sono utili per l'ispezione; conservare tutti gli artefatti, inclusi tipi di risorse sconosciuti. Lasciare i byte invariati durante la memorizzazione o la trasmissione. Utilizzare [Encoding::GetString](https://reference.aspose.com/slides/it/cpp/system.text/encoding/getstring/) con codifica UTF-8 solo per XAML che richiede elaborazione testuale.

### **Raccogli gli artefatti in un archivio ZIP**

Questo esempio indipendente raccoglie l'esportazione, ne valida i nomi e scrive i byte originali in un archivio ZIP. Un nome archivio unico separa le attività di esportazione concorrenti. Le voci ZIP usano la barra obliqua (`/`) e conservano le directory relative. Nomi non sicuri o nomi che collidono dopo la normalizzazione rifiutano l'intero pacchetto prima della scrittura.

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/IXamlOutputSaver.h>
#include <Export/Xaml/XamlOptions.h>
#include <system/array.h>
#include <system/collections/dictionary.h>
#include <system/console.h>
#include <system/string_comparer.h>
#include <system/guid.h>
#include <system/io/file_access.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/io/path.h>
#include <zip/zip_file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;
using namespace Aspose::Zip;

class ZipXamlExample
{
    class CollectedXamlSaver : public IXamlOutputSaver
    {
    public:
        using ArtifactDictionary = Dictionary<String, ArrayPtr<uint8_t>>;
        SharedPtr<ArtifactDictionary> Artifacts = MakeObject<ArtifactDictionary>(StringComparer::get_Ordinal());

        void Save(String path, ArrayPtr<uint8_t> data) override
        {
            auto retainedData = data->Clone();
            Artifacts->Add(path, retainedData);
        }
    };

public:
    static void Run()
    {
        auto saver = MakeObject<CollectedXamlSaver>();
        auto presentation = MakeObject<Presentation>(u"pres.pptx");
        auto options = MakeObject<XamlOptions>();
        options->set_OutputSaver(saver);
        options->set_ExportHiddenSlides(false);
        presentation->Save(options);

        auto entries = MakeObject<Dictionary<String, ArrayPtr<uint8_t>>>(StringComparer::get_OrdinalIgnoreCase());
        for (const auto& artifact : saver->Artifacts)
        {
            auto entryName = artifact.get_Key().Replace(u'\\', u'/');
            auto segments = entryName.Split(u'/');
            auto unsafeName = entryName.StartsWith(u"/", StringComparison::Ordinal) || entryName.Contains(u":");
            for (const auto& segment : segments)
            {
                unsafeName |= String::IsNullOrWhiteSpace(segment) || segment == u"." || segment == u"..";
            }

            if (unsafeName || entries->ContainsKey(entryName))
            {
                Console::WriteLine(u"Export rejected: unsafe or duplicate artifact name: {0}", artifact.get_Key());
                return;
            }
            entries->Add(entryName, artifact.get_Value());
        }

        auto jobId = Guid::NewGuid();
        auto archivePath = u"xaml-" + jobId.ToString(u"N") + u".zip";
        auto archive = MakeObject<ZipFile>();
        for (const auto& artifact : entries)
        {
            auto fileName = Path::GetFileName(artifact.get_Key());
            auto directoryName = Path::GetDirectoryName(artifact.get_Key()).Replace(u'\\', u'/');
            archive->AddEntry(fileName, directoryName, artifact.get_Value());
        }

        auto output = MakeObject<FileStream>(archivePath, FileMode::CreateNew, FileAccess::Write);
        archive->Save(output);
        output->Close();
        archive->Dispose();

        // Save finalizza la directory ZIP; chiudi il file prima di segnalare il successo.
        Console::WriteLine(u"Saved {0} artifacts to {1}", entries->get_Count(), archivePath);
    }
};
```

Chiamare `ZipXamlExample::Run` dalla propria applicazione. L'esempio utilizza `Aspose::Zip::ZipFile` del runtime C++ per scrivere un archivio locale; l'esportatore stesso non scrive file XAML o immagini singole. Per l'archiviazione remota, sostituire la fase di scrittura dell'archivio con il caricamento degli array di byte raccolti. Utilizzare un identificatore del lavoro di esportazione più il nome relativo completo dell'artefatto come chiave blob, oppure memorizzare l'identificatore del lavoro, il nome relativo e i dati binari in una riga di database. Pubblicare il lavoro solo dopo che tutti i caricamenti sono completi o la transazione del database è confermata. Pulire l'output parziale se la persistenza fallisce.

Per presentazioni di grandi dimensioni, un salvatore personalizzato può persistere ogni artefatto direttamente nello storage dell'applicazione per evitare di mantenere una copia aggiuntiva dell'intera esportazione in memoria. L'esportatore continua a raccogliere tutti gli artefatti generati in memoria prima di chiamare il salvatore. Mantenere ogni callback sincrona dal punto di vista dell'esportatore: restituire solo dopo che la destinazione ha accettato i byte e consentire ai fallimenti di raggiungere il chiamante.

### **Preservare i nomi delle risorse e verificare i riferimenti**

- Normalizzare i separatori di percorso quando la destinazione lo richiede, ma conservare le directory relative. Non utilizzare solo [Path::GetFileName](https://reference.aspose.com/slides/it/cpp/system.io/path/getfilename/) a meno che ogni nome generato sia noto per essere unico e i riferimenti alle risorse rimangano validi.
- Applicare la convalida dei nomi specifica per la destinazione. Quando si scrivono file sparsi, rifiutare percorsi radicati e segmenti di attraversamento, risolvere la destinazione con [Path::GetFullPath](https://reference.aspose.com/slides/it/cpp/system.io/path/getfullpath/), e verificare che rimanga al di sotto della directory di esportazione prevista, includendo il separatore di directory nel controllo di contenimento. Utilizzare una directory controllata dall'applicazione senza collegamenti simbolici che possano reindirizzare le scritture.
- Utilizzare un salvatore e uno spazio di nomi di storage separati per ogni lavoro di esportazione. Rilevare collisioni dopo la normalizzazione dei separatori e secondo le regole di case‑sensitivity della destinazione.
- Prima della pubblicazione, analizzare ogni documento XAML come XML e ispezionare i riferimenti a risorse basati su file, come gli attributi `Source` o `ImageSource` delle immagini. Risolvere ogni URI relativo rispetto alla directory dell'artefatto XAML contenente, normalizzare il nome di storage risultante e confermare che la chiave corrispondente del dizionario, la voce ZIP o l'oggetto memorizzato esista. Trattare separatamente gli URI esterni e le espressioni di markup XAML rispetto ai nomi di file relativi.

Ad esempio, se `pres/Slide_1.xaml` fa riferimento a `images/image1.png`, la risorsa memorizzata deve essere disponibile come `pres/images/image1.png`. Conservare solo `image1.png` romperebbe tale relazione. Per lo storage di oggetti, preservare la stessa struttura sotto il prefisso del lavoro e rendere quegli URL di risorsa accessibili al consumatore XAML. Riaprire lo ZIP completato per verificare i nomi delle voci e i byte delle risorse, e caricare diapositive rappresentative nell'ambiente XAML di destinazione per confermare che le immagini vengono risolte correttamente.

## **FAQ**

**Come posso garantire caratteri prevedibili se il carattere originale non è disponibile sulla macchina?**

Utilizzare [set_DefaultRegularFont](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) in [XamlOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export.xaml/xamloptions/) — è usato come carattere di fallback durante l'esportazione quando l'originale è mancante. Questo non garantisce che lo XAML generato faccia riferimento al carattere di fallback o che il carattere sia disponibile sulla macchina di destinazione. Assicurarsi che i caratteri a cui fa riferimento lo XAML siano presenti nell'ambiente in cui viene visualizzato.

**Lo XAML esportato è destinato solo a WPF o può essere usato anche in altre stack XAML?**

Aspose.Slides esporta XAML WPF tramite la sua API pubblica. La compatibilità con altre stack XAML, come UWP e Xamarin.Forms, non è garantita. Testare il markup generato nell'ambiente di destinazione.

**Le diapositive nascoste sono supportate e come posso impedire che vengano esportate per impostazione predefinita?**

Per impostazione predefinita, le diapositive nascoste non sono incluse. È possibile controllare questo comportamento tramite [set_ExportHiddenSlides](https://reference.aspose.com/slides/it/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) in [XamlOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export.xaml/xamloptions/) — lasciarlo disabilitato se non è necessario esportarle.