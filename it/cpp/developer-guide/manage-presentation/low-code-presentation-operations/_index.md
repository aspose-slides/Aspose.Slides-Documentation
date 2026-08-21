---
title: Operazioni di presentazione Low-Code in C++
linktitle: API Low-Code
type: docs
weight: 50
url: /it/cpp/low-code-presentation-operations/
keywords:
- API di presentazione low-code
- convertire presentazione
- unire presentazioni
- iterare slide
- iterare forme
- iterare testo
- raccogliere forme
- comprimere presentazione
- rimuovere slide master inutilizzate
- rimuovere slide layout inutilizzate
- comprimere font incorporati
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Utilizza l'API low-code di Aspose.Slides in C++ per convertire e unire le presentazioni, iterare attraverso i contenuti, raccogliere le forme e ridurre le dimensioni della presentazione."
---
## **Panoramica**

Lo spazio dei nomi [Aspose::Slides::LowCode](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/) fornisce classi di supporto statiche per operazioni comuni sulle presentazioni. Queste classi di supporto racchiudono i flussi di lavoro del modello di oggetti frequentemente usati in metodi mirati, così puoi convertire o unire file, elaborare gli elementi della presentazione, raccogliere shape e rimuovere contenuti inutilizzati con meno codice.

Gli helper low-code sono più utili quando l'operazione si applica a un intero file o presentazione e il flusso di lavoro predefinito soddisfa i requisiti. Usa il [modello di oggetti Aspose.Slides](https://reference.aspose.com/slides/it/cpp/aspose.slides/) quando hai bisogno di un controllo fine su slide individuali, master, layout, shape, impostazioni di esportazione o relazioni tra gli elementi della presentazione.

| Helper | Per cosa usarlo |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/convert/) | Conversione di una presentazione in un altro formato con una chiamata diretto file-to-file. |
| [Merger](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/merger/) | Combinazione di file di presentazione completi dello stesso formato. |
| [ForEach](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/foreach/) | Esecuzione di un'azione per ogni slide, shape, paragrafo o porzione di testo. |
| [Collect](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/collect/) | Recupero delle shape dall'intera presentazione per elaborazioni o analisi ripetute. |
| [Compress](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/compress/) | Rimozione di master e layout inutilizzati e riduzione dei dati dei font incorporati. |

## **Convertire una presentazione**

Usa [Convert::AutoByExtension](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/convert/autobyextension/) quando l'estensione del file di output è sufficiente per selezionare il formato di esportazione. Il metodo apre la presentazione di origine, determina il formato necessario dal percorso di output e scrive il risultato.

```cpp
#include <LowCode/Convert.h>

using namespace Aspose::Slides::LowCode;

Convert::AutoByExtension(u"input.pptx", u"output.pdf");
```

La classe [Convert](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/convert/) fornisce inoltre metodi dedicati per l'output PDF, SVG, JPEG, PNG e TIFF. Usa il modello di oggetti completo quando devi ispezionare o modificare la presentazione prima dell'esportazione o configurare un'opzione di esportazione non esposta dall'helper selezionato. Vedi [Converti presentazione](/cpp/convert-presentation/) per flussi di lavoro e opzioni specifiche per formato.

## **Unire presentazioni**

Usa [Merger::Process](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/merger/process/) per combinare file di presentazione completi con una sola chiamata. Le presentazioni di input devono avere lo stesso formato di file.

```cpp
#include <LowCode/Merger.h>
#include <system/array.h>
#include <system/string.h>

using namespace Aspose::Slides::LowCode;

auto inputFiles = System::MakeArray<System::String>({u"part-1.pptx", u"part-2.pptx"});
Merger::Process(inputFiles, u"merged.pptx");
```

L'helper è appropriato quando tutte le slide devono essere aggiunte a un unico risultato senza selezionarle o rimapparle singolarmente. Usa il modello di oggetti completo quando devi unire slide selezionate, applicare un master o layout di destinazione, preservare esplicitamente le sezioni o conciliare diverse dimensioni di slide. Vedi [Unire presentazioni](/cpp/merge-presentation/) per questi scenari.

## **Iterare attraverso gli elementi della presentazione**

La classe [ForEach](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/foreach/) invoca una callback per ciascun tipo richiesto di elemento della presentazione. Evita loop di collezioni annidati ed è comoda per ispezioni o modifiche di formattazione su tutta la presentazione.

Il seguente esempio utilizza [ForEach::Slide](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/foreach/slide/), [ForEach::Shape](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/foreach/shape/), [ForEach::Paragraph](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/foreach/paragraph/), e [ForEach::Portion](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/foreach/portion/) per ispezionare gli elementi corrispondenti:

```cpp
#include <DOM/BaseSlide.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/Shape.h>
#include <DOM/Slide.h>
#include <LowCode/ForEach.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <functional>

using namespace Aspose::Slides;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");

auto slideCallback = std::function<void(System::SharedPtr<Slide>, int32_t)>([](System::SharedPtr<Slide> slide, int32_t index)
{
    System::Console::WriteLine(u"Slide {0}: {1} shapes", index, slide->get_Shapes()->get_Count());
});
ForEach::Slide(presentation, slideCallback);

auto shapeCallback = std::function<void(System::SharedPtr<Shape>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Shape> shape, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Shape {0}: {1}", index, shape->get_Name());
});
ForEach::Shape(presentation, shapeCallback);

auto paragraphCallback = std::function<void(System::SharedPtr<Paragraph>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Paragraph> paragraph, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Paragraph {0}: {1}", index, paragraph->get_Text());
});
ForEach::Paragraph(presentation, paragraphCallback);

auto portionCallback = std::function<void(System::SharedPtr<Portion>, System::SharedPtr<Paragraph>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Portion> portion, System::SharedPtr<Paragraph> paragraph, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Portion {0}: {1}", index, portion->get_Text());
});
ForEach::Portion(presentation, portionCallback);
```

Per impostazione predefinita, l'attraversamento di shape e testo su tutta la presentazione include slide normali, master e layout. Le sovraccariche con un parametro `includeNotes` possono anche elaborare le slide delle note. Usa loop di collezione diretti quando l'ordine di attraversamento, l'uscita anticipata, il filtraggio prima della chiamata della callback o il controllo dettagliato padre-figlio sono importanti.

## **Raccogliere shape**

Usa [Collect::Shapes](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/collect/shapes/) quando ti serve una collezione di tutte le shape in una presentazione invece di una callback per ciascuna shape. È utile quando lo stesso insieme verrà filtrato, contato o elaborato più volte.

```cpp
#include <DOM/Presentation.h>
#include <DOM/Shape.h>
#include <LowCode/Collect.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto shapes = Collect::Shapes(presentation);

for (const auto& shape : shapes)
{
    System::Console::WriteLine(shape->get_Name());
}
```

Usa invece [ForEach::Shape](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/foreach/shape/) quando ogni shape può essere gestita immediatamente e non è necessario conservare il risultato raccolto.

## **Comprimere il contenuto della presentazione**

La classe [Compress](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/compress/) può rimuovere elementi strutturali inutilizzati e ridurre i dati dei font incorporati:

- [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) rimuove le slide di layout che non sono referenziate da nessuna slide normale.
- [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) rimuove le slide master che non sono più utilizzate.
- [Compress::CompressEmbeddedFonts](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) rimuove i caratteri inutilizzati dai font incorporati.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);
Compress::RemoveUnusedMasterSlides(presentation);
Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed.pptx", SaveFormat::Pptx);
```

Rimuovi i layout inutilizzati prima dei master inutilizzati, così un master che diventa non referenziato dopo la pulizia dei layout può essere rimosso. Salva la presentazione ottimizzata in un nuovo file se potresti aver bisogno in seguito dei master, dei layout originali o dei dati completi dei font incorporati. Per maggiori dettagli, vedi [Master della slide](/cpp/slide-master/) e [Font incorporato](/cpp/embedded-font/).

## **FAQ**

**Quando dovrei usare l'API low-code invece del modello di oggetti completo?**

Usa gli helper low-code quando un'operazione standard si applica a un file o una presentazione completa e non richiede un controllo dettagliato sugli elementi individuali. Usa il modello di oggetti completo quando devi selezionare slide specifiche, controllare le relazioni tra master e layout, ispezionare lo stato intermedio o configurare un comportamento che l'helper non espone.

**Il Merger può combinare presentazioni in formati di file diversi?**

No. [Merger::Process](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/merger/process/) richiede che le presentazioni di input siano nello stesso formato. Converti prima i file di input in un formato comune, ad esempio con [Convert::AutoByExtension](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/convert/autobyextension/), e quindi unisci i file convertiti.

**ForEach elabora slide master, layout e note?**

[ForEach::Slide](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/foreach/slide/) itera attraverso le slide normali della presentazione. Le operazioni [ForEach::Shape](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/foreach/shape/), [ForEach::Paragraph](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/foreach/paragraph/) e [ForEach::Portion](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/foreach/portion/) su tutta la presentazione includono di default le slide normali, master e layout. Usa le loro sovraccariche con `includeNotes` impostato a `true` per includere le slide delle note.

**Qual è la differenza tra ForEach::Shape e Collect::Shapes?**

Usa [ForEach::Shape](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/foreach/shape/) per elaborare ogni shape immediatamente tramite una callback. Usa [Collect::Shapes](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/collect/shapes/) quando ti serve un risultato enumerabile che può essere conservato, filtrato, contato o attraversato più volte.

**Compress rende sempre il file della presentazione più piccolo?**

Non necessariamente. Il risultato dipende dal fatto che la presentazione contenga layout inutilizzati, master inutilizzati o font incorporati con caratteri inutilizzati. Se nessuno di questi è presente, le operazioni [Compress](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/compress/) corrispondenti potrebbero non ridurre la dimensione del file.

**Le modifiche apportate da ForEach o Compress vengono salvate automaticamente?**

No. Questi helper operano sull'oggetto [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) caricato in memoria. Dopo aver modificato gli elementi in una callback di [ForEach](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/foreach/) o aver eseguito [Compress](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/compress/), chiama [Presentation::Save](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/save/) per scrivere il risultato.

## **Articoli correlati**

- [Converti presentazione](/cpp/convert-presentation/)
- [Unire presentazioni](/cpp/merge-presentation/)
- [Master della slide](/cpp/slide-master/)
- [Gestire casella di testo](/cpp/manage-textbox/)
- [Font incorporato](/cpp/embedded-font/)