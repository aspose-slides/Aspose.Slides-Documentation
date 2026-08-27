---
title: Converti presentazioni PowerPoint in Markdown in C++
linktitle: PowerPoint in Markdown
type: docs
weight: 140
url: /it/cpp/convert-powerpoint-to-markdown/
keywords:
- converti PowerPoint
- converti presentazione
- converti diapositiva
- converti PPT
- converti PPTX
- PowerPoint in MD
- presentazione in MD
- diapositiva in MD
- PPT in MD
- PPTX in MD
- salva PowerPoint come Markdown
- salva presentazione come Markdown
- salva diapositiva come Markdown
- salva PPT come MD
- salva PPTX come MD
- esporta PPT in MD
- esporta PPTX in MD
- esportazione immagini Markdown
- collegamenti immagine CDN
- PowerPoint
- presentazione
- Markdown
- C++
- Aspose.Slides
description: "Converti presentazioni PPT e PPTX in Markdown in C++ e controlla dove vengono salvate e referenziate le immagini bitmap, metafile e SVG esportate."
---
## **Panoramica**

Aspose.Slides per C++ può convertire presentazioni PPT e PPTX in Markdown per documentazione, siti statici, migrazione di contenuti e flussi di lavoro di controllo versione. È possibile scegliere un flavor Markdown, controllare come il contenuto delle diapositive viene renderizzato e decidere dove vengono salvate le immagini esportate e come i collegamenti Markdown generati le fanno riferimento.

Per impostazione predefinita, l’esportazione Markdown utilizza output solo testo. Per esportare contenuti visivi, impostare il metodo [MarkdownSaveOptions::set_ExportType](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/markdownsaveoptions/set_exporttype/) sul valore `Sequential` o `Visual` dell’enumerazione [MarkdownExportType](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/markdownexporttype/). `Sequential` renderizza gli elementi della diapositiva separatamente e in ordine, mentre `Visual` mantiene insieme gli elementi raggruppati per preservare la loro relazione visiva. Il valore `TextOnly` non genera risorse immagine, quindi gli eventi di salvataggio delle immagini non vengono invocati in quella modalità.

## **Convertire una presentazione in Markdown**

Caricare il file di origine con la classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) e quindi chiamare il metodo [Presentation::Save](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/save/) con il valore `Md` dell’enumerazione [SaveFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/saveformat/).

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.md", SaveFormat::Md);
```

## **Selezionare un formato Markdown**

Il metodo [MarkdownSaveOptions::set_Flavor](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/markdownsaveoptions/set_flavor/) controlla la specifica Markdown utilizzata per l’output. L’enumerazione [Flavor](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/flavor/) include CommonMark, GitHub Flavored Markdown e altre varianti supportate.

L’esempio seguente esporta una presentazione come CommonMark:

```cpp
#include <DOM/Presentation.h>
#include <Export/Markdown/SaveOptions/Flavor.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto options = System::MakeObject<MarkdownSaveOptions>();
options->set_Flavor(Flavor::CommonMark);

presentation->Save(u"presentation.md", SaveFormat::Md, options);
```

## **Esportare le immagini usando il comportamento predefinito di salvataggio locale**

La classe [MarkdownSaveOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/markdownsaveoptions/) fornisce due metodi per configurare le immagini salvate localmente:

- [set_BasePath](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) specifica la directory di base per il documento Markdown e le sue risorse.
- [set_ImagesSaveFolderName](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/) specifica la sottodirectory delle immagini. Il suo valore predefinito è `Images`.

L’esempio seguente rende il contenuto visivo, scrive le immagini in `output/assets` e crea riferimenti immagine relativi nel documento Markdown:

```cpp
#include <DOM/Presentation.h>
#include <Export/Markdown/SaveOptions/MarkdownExportType.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>
#include <system/io/directory.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

const System::String outputDirectory = u"output";
Directory::CreateDirectory_(outputDirectory);

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto options = System::MakeObject<MarkdownSaveOptions>();
options->set_ExportType(MarkdownExportType::Visual);
options->set_BasePath(outputDirectory);
options->set_ImagesSaveFolderName(u"assets");

auto markdownPath = Path::Combine(outputDirectory, u"presentation.md");
presentation->Save(markdownPath, SaveFormat::Md, options);
```

Questo comportamento serve anche come fallback quando un gestore di salvataggio immagini personalizzato restituisce `false`.

## **Personalizzare il salvataggio delle immagini e i collegamenti Markdown**

Usare l’evento `MarkdownSaveOptions::ImageSaving` per le risorse bitmap e metafile non‑SVG emesse durante l’esportazione Markdown. Il suo delegato [MarkdownImageSavingHandler](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/markdownsaveoptions/markdownimagesavinghandler/) riceve l’oggetto [IImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/iimage/), il suo [ImageFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/imageformat/) e il collegamento Markdown generato come parametro `System::String&`. Salvare o caricare l’immagine con il formato fornito e sostituire `link` con il riferimento che deve comparire nell’output Markdown.

Le risorse emesse in formato SVG sono gestite separatamente. Sottoscrivere l’evento `MarkdownSaveOptions::SvgImageSaving`, il cui delegato [MarkdownSvgImageSavingHandler](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/markdownsaveoptions/markdownsvgimagesavinghandler/) riceve un oggetto [ISvgImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/isvgimage/) e il parametro `System::String& link`. Un SVG non ha argomento `ImageFormat`; scrivere o caricare i dati XML dal metodo [ISvgImage::get_SvgData](https://reference.aspose.com/slides/it/cpp/aspose.slides/isvgimage/get_svgdata/). A seconda della modalità di esportazione e del raggruppamento visivo, uno SVG nella presentazione di origine può essere rasterizzato o combinato con altri contenuti; la risorsa non‑SVG risultante viene quindi passata a `ImageSaving`. Sottoscrivere entrambi gli eventi quando ogni risorsa visiva esportata richiede una elaborazione personalizzata.

Il valore di ritorno del gestore determina chi elabora l’immagine:

- Restituire `true` dopo che il gestore ha salvato, caricato, trasformato o altrimenti processato l’immagine e ha assegnato un valore valido a `link`. Aspose.Slides scrive quel valore nel documento Markdown e non esegue il salvataggio locale predefinito.
- Restituire `false` per consentire ad Aspose.Slides di salvare l’immagine localmente e generare il collegamento secondo [MarkdownSaveOptions::set_BasePath](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) e [MarkdownSaveOptions::set_ImagesSaveFolderName](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/).

{{% alert color="warning" title="Important" %}}
Un gestore che restituisce `true` assume la responsabilità dell’immagine. Se restituisce `true` senza assegnare un collegamento valido e non vuoto, l’esportazione fallisce con un `InvalidOperationException`.
{{% /alert %}}

### **Salvare le immagini in una directory origin CDN e utilizzare URL esterni**

L’esempio seguente tratta `cdn-origin/presentations/quarterly-report` come una directory di origine CDN montata o sincronizzata. Ogni gestore estrae il nome file generato, salva l’immagine in quella directory personalizzata e sostituisce il riferimento locale generato con un URL CDN pubblico. L’esempio stesso non esegue alcun upload di rete: l’URL diventa valido solo dopo che la directory è montata come origine CDN o i suoi file sono pubblicati sul CDN. Per l’archiviazione di oggetti, sostituire la scrittura sul file system con l’operazione di upload dell’Sdk di storage e assegnare `link` solo dopo che l’upload ha avuto successo.

```cpp
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <Export/Markdown/SaveOptions/MarkdownExportType.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <functional>
#include <system/io/directory.h>
#include <system/io/file.h>
#include <system/io/path.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

const System::String outputDirectory = u"output";
const System::String publicBaseUrl = u"https://cdn.example.com/presentations/quarterly-report";
const System::String storageDirectory = Path::Combine(u"cdn-origin", u"presentations", u"quarterly-report");
Directory::CreateDirectory_(outputDirectory);
Directory::CreateDirectory_(storageDirectory);

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto options = System::MakeObject<MarkdownSaveOptions>();
options->set_ExportType(MarkdownExportType::Visual);
options->set_BasePath(outputDirectory);
options->set_ImagesSaveFolderName(u"fallback-images");

options->ImageSaving.connect(std::function<bool(System::SharedPtr<IImage>, ImageFormat, System::String&)>([storageDirectory, publicBaseUrl](System::SharedPtr<IImage> image, ImageFormat format, System::String& link) -> bool
{
    if (image->get_Width() < 128 || image->get_Height() < 128)
    {
        return false;
    }

    auto urlCompatibleLink = link.Replace(u"\\", u"/");
    auto fileName = urlCompatibleLink.Substring(urlCompatibleLink.LastIndexOf(u'/') + 1);
    auto storagePath = Path::Combine(storageDirectory, fileName);
    image->Save(storagePath, format);
    link = publicBaseUrl + u"/" + System::Uri::EscapeDataString(fileName);
    return true;
}));

options->SvgImageSaving.connect(std::function<bool(System::SharedPtr<ISvgImage>, System::String&)>([storageDirectory, publicBaseUrl](System::SharedPtr<ISvgImage> svgImage, System::String& link) -> bool
{
    auto urlCompatibleLink = link.Replace(u"\\", u"/");
    auto fileName = urlCompatibleLink.Substring(urlCompatibleLink.LastIndexOf(u'/') + 1);
    auto storagePath = Path::Combine(storageDirectory, fileName);
    File::WriteAllBytes(storagePath, svgImage->get_SvgData());
    link = publicBaseUrl + u"/" + System::Uri::EscapeDataString(fileName);
    return true;
}));

auto markdownPath = Path::Combine(outputDirectory, u"presentation.md");
presentation->Save(markdownPath, SaveFormat::Md, options);
```

Il gestore bitmap restituisce deliberatamente `false` per le immagini più piccole di 128 × 128 pixel, così Aspose.Slides salva tali immagini in `output/fallback-images` utilizzando il comportamento predefinito. Le risorse bitmap e metafile più grandi, così come le risorse SVG, sono gestite dal codice personalizzato. Ad esempio, un riferimento locale generato come `fallback-images/image1.png` diventa `https://cdn.example.com/presentations/quarterly-report/image1.png`. I gestori usano percorsi del sistema operativo solo quando scrivono file; i collegamenti scritti nel Markdown usano barre oblique e nomi di file codificati per URL. Applicare la stessa regola quando si costruiscono collegamenti relativi: usare `/`, non il separatore di directory specifico della piattaforma.

## **FAQ**

**Un gestore può elaborare sia immagini raster che immagini SVG?**

No. Utilizzare `MarkdownSaveOptions::ImageSaving` per le risorse bitmap e metafile emesse e `MarkdownSaveOptions::SvgImageSaving` per le risorse emesse come SVG. Il primo fornisce un oggetto [IImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/iimage/) e un [ImageFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/imageformat/); il secondo fornisce un oggetto [ISvgImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/isvgimage/) il cui dato SVG può essere letto con [ISvgImage::get_SvgData](https://reference.aspose.com/slides/it/cpp/aspose.slides/isvgimage/get_svgdata/). Un SVG di origine rasterizzato durante l’esportazione è elaborato da `ImageSaving`.

**Cosa succede quando un gestore di salvataggio immagine restituisce `false`?**

Aspose.Slides utilizza il suo comportamento predefinito di salvataggio locale. La posizione dell’immagine e il riferimento generato sono controllati da [MarkdownSaveOptions::set_BasePath](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) e [MarkdownSaveOptions::set_ImagesSaveFolderName](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/).

**Un gestore può fornire un URL senza salvare l’immagine localmente?**

Sì. Il gestore può caricare l’immagine su storage di oggetti o passare a un altro servizio, assegnare l’URL risultante a `link` e restituire `true`. Il gestore deve completare l’elaborazione; restituire `true` impedisce il salvataggio locale predefinito.

**Perché l’esportazione Markdown genera un `InvalidOperationException` da un gestore?**

Questa eccezione si verifica quando il gestore restituisce `true` ma non fornisce un collegamento valido. Assegnare il percorso relativo o l’URL esterno che dovrebbe essere scritto nel Markdown prima di restituire `true`.

**Quale separatore di percorso devono usare i collegamenti alle immagini?**

Utilizzare le barre oblique (`/`) nei collegamenti Markdown e negli URL. Utilizzare `Path::Combine` solo per i percorsi del file system, quindi costruire o normalizzare il riferimento Markdown separatamente.

**I collegamenti ipertestuali vengono conservati durante l’esportazione Markdown?**

Sì. I [collegamenti ipertestuali](/slides/it/cpp/manage-hyperlinks/) nel testo vengono conservati come normali collegamenti Markdown. Le [transizioni](/slides/it/cpp/slide-transition/) e le [animazioni](/slides/it/cpp/powerpoint-animation/) delle diapositive non vengono convertite.

**Le presentazioni possono essere convertite in Markdown in parallelo?**

È possibile elaborare file di presentazione diversi in parallelo, ma non condividere la stessa istanza di [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) tra thread. Seguire le [linee guida sul multithreading](/slides/it/cpp/multithreading/) e utilizzare un’istanza separata per ogni file.