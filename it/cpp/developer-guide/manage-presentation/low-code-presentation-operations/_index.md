---
title: Operazioni di presentazione low-code in C++
linktitle: API low-code
type: docs
weight: 50
url: /it/cpp/low-code-presentation-operations/
keywords:
- API di presentazione low-code
- converti presentazione
- unisci presentazioni
- itera diapositive
- itera forme
- itera testo
- raccogli forme
- comprimi presentazione
- rimuovi master diapositive non utilizzati
- rimuovi diapositive layout non utilizzate
- comprimi caratteri incorporati
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Usa l'API low-code di Aspose.Slides in C++ per convertire e unire presentazioni, iterare attraverso i contenuti, raccogliere forme e ridurre le dimensioni della presentazione."
---
## **Panoramica**

Lo spazio dei nomi [Aspose::Slides::LowCode](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/) fornisce classi di supporto statiche per operazioni comuni sulle presentazioni. Questi helper avvolgono i flussi di lavoro del modello a oggetti più usati in metodi focalizzati, così puoi convertire o unire file, elaborare gli elementi della presentazione, raccogliere forme e rimuovere contenuti non utilizzati con meno codice.

Gli helper low-code sono più utili quando l'operazione si applica a un intero file o a una presentazione e il flusso di lavoro predefinito soddisfa i requisiti. Usa il modello a oggetti completo di [Aspose.Slides object model](https://reference.aspose.com/slides/it/cpp/aspose.slides/) quando hai bisogno di un controllo fine su singole diapositive, master, layout, forme, impostazioni di esportazione o relazioni tra gli elementi della presentazione.

La tabella seguente riepiloga gli helper disponibili:

| Helper | A cosa serve |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/convert/) | Conversione di una presentazione in un altro formato con una chiamata diretta file-a-file. |
| [Merger](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/merger/) | Unione di file di presentazioni completi dello stesso formato. |
| [ForEach](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/foreach/) | Esecuzione di un'azione per ogni diapositiva, forma, paragrafo o porzione di testo. |
| [Collect](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/collect/) | Recupero delle forme dall'intera presentazione per elaborazioni o analisi ripetute. |
| [Compress](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/compress/) | Rimozione di master e layout non utilizzati e riduzione dei dati dei caratteri incorporati. |

## **Converti una presentazione**

Usa [Convert::AutoByExtension](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/convert/autobyextension/) quando l'estensione del file di output è sufficiente per selezionare il formato di esportazione. Il metodo apre la presentazione di origine, determina il formato richiesto dal percorso di output e scrive il risultato.

```cpp
#include <LowCode/Convert.h>

using namespace Aspose::Slides::LowCode;

Convert::AutoByExtension(u"input.pptx", u"output.pdf");
```

La classe [Convert](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/convert/) fornisce inoltre metodi dedicati per l'output PDF, SVG, JPEG, PNG e TIFF. Usa il modello a oggetti completo quando devi ispezionare o modificare la presentazione prima dell'esportazione o configurare un'opzione di esportazione non esposta dall'helper selezionato. Vedi [Convert Presentation](/slides/it/cpp/convert-presentation/) per flussi di lavoro e opzioni specifiche per formato.

## **Unisci presentazioni**

Usa [Merger::Process](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/merger/process/) per combinare file di presentazioni completi con una sola chiamata. Le presentazioni di input devono avere lo stesso formato di file.

```cpp
#include <LowCode/Merger.h>
#include <system/array.h>
#include <system/string.h>

using namespace Aspose::Slides::LowCode;

auto inputFiles = System::MakeArray<System::String>({u"part-1.pptx", u"part-2.pptx"});
Merger::Process(inputFiles, u"merged.pptx");
```

L'helper è appropriato quando tutte le diapositive devono essere aggiunte a un unico risultato senza selezionarle o rimapparle individualmente. Usa il modello a oggetti completo quando devi unire diapositive selezionate, applicare un master o layout di destinazione, preservare sezioni in modo esplicito o conciliare diverse dimensioni di diapositiva. Vedi [Merge Presentations](/slides/it/cpp/merge-presentation/) per questi scenari.

## **Itera gli elementi della presentazione**

La classe [ForEach](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/foreach/) invoca una callback per ogni tipo richiesto di elemento della presentazione. Evita cicli di raccolta annidati ed è comoda per ispezioni o modifiche di formattazione su tutta la presentazione.

L'esempio seguente utilizza [ForEach::Slide](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/foreach/slide/), [ForEach::Shape](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/foreach/shape/), [ForEach::Paragraph](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/foreach/paragraph/) e [ForEach::Portion](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/foreach/portion/) per ispezionare gli elementi corrispondenti:

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

Per impostazione predefinita, l'attraversamento di forme e testo su tutta la presentazione include diapositive normali, master e layout. Le sovraccariche con un parametro `includeNotes` possono anche elaborare le diapositive delle note. Usa cicli di raccolta diretti quando l'ordine di attraversamento, l'uscita anticipata, il filtraggio prima della chiamata di callback o il controllo dettagliato padre-figlio sono importanti.

## **Raccogli forme**

Usa [Collect::Shapes](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/collect/shapes/) quando ti serve una collezione di tutte le forme in una presentazione anziché una callback per ogni forma. È utile quando lo stesso insieme verrà filtrato, conteggiato o elaborato più volte.

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

Usa invece [ForEach::Shape](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/foreach/shape/) quando ogni forma può essere gestita immediatamente e non è necessario conservare il risultato raccolto.

## **Comprimi il contenuto della presentazione**

La classe [Compress](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/compress/) può rimuovere elementi strutturali non utilizzati e ridurre i dati dei caratteri incorporati:

- [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) rimuove le diapositive di layout che non sono riferite da alcuna diapositiva normale.
- [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) rimuove i master che non sono più utilizzati.
- [Compress::CompressEmbeddedFonts](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) rimuove i caratteri non usati dai caratteri incorporati.

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

Rimuovi i layout non utilizzati prima dei master non utilizzati in modo che un master che diventa non riferito dopo la pulizia dei layout possa essere rimosso. Salva la presentazione ottimizzata in un nuovo file se potresti aver bisogno in seguito dei master, dei layout originali o dei dati completi dei caratteri incorporati. Per ulteriori dettagli, vedi [Slide Master](/slides/it/cpp/slide-master/) e [Embedded Font](/slides/it/cpp/embedded-font/).

## **FAQ**

**Quando dovrei usare l'API low‑code invece del modello a oggetti completo?**

Usa gli helper low‑code quando un'operazione standard si applica a un file o a una presentazione completa e non richiede un controllo dettagliato sugli elementi individuali. Usa il modello a oggetti completo quando devi selezionare diapositive specifiche, controllare le relazioni tra master e layout, ispezionare lo stato intermedio o configurare un comportamento che l'helper non espone.

**Il Merger può combinare presentazioni in formati di file diversi?**

No. [Merger::Process](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/merger/process/) richiede che le presentazioni di input siano nello stesso formato. Converti prima i file di input in un formato comune, ad esempio con [Convert::AutoByExtension](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/convert/autobyextension/), e poi unisci i file convertiti.

**ForEach elabora master, layout e diapositive delle note?**

[ForEach::Slide](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/foreach/slide/) itera sulle diapositive normali della presentazione. Le operazioni [ForEach::Shape](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/foreach/shape/), [ForEach::Paragraph](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/foreach/paragraph/) e [ForEach::Portion](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/foreach/portion/) su tutta la presentazione includono diapositive normali, master e layout per impostazione predefinita. Usa le loro sovraccariche con `includeNotes` impostato a `true` per includere le diapositive delle note.

**Qual è la differenza tra ForEach::Shape e Collect::Shapes?**

Usa [ForEach::Shape](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/foreach/shape/) per elaborare ogni forma immediatamente tramite una callback. Usa [Collect::Shapes](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/collect/shapes/) quando ti serve un risultato enumerabile che può essere conservato, filtrato, contato o attraversato più volte.

**Compress riduce sempre la dimensione del file della presentazione?**

Non necessariamente. Il risultato dipende dal fatto che la presentazione contenga layout non utilizzati, master non utilizzati o caratteri incorporati con caratteri non usati. Se nessuno di questi è presente, le relative operazioni [Compress](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/compress/) potrebbero non ridurre le dimensioni del file.

**Le modifiche effettuate da ForEach o Compress vengono salvate automaticamente?**

No. questi helper operano sull'oggetto [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) caricato in memoria. Dopo aver modificato gli elementi in una callback di [ForEach](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/foreach/) o aver eseguito [Compress](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/compress/), chiama [Presentation::Save](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/save/) per scrivere il risultato.

## **Articoli correlati**

- [Converti presentazione](/slides/it/cpp/convert-presentation/)
- [Unisci presentazioni](/slides/it/cpp/merge-presentation/)
- [Master diapositiva](/slides/it/cpp/slide-master/)
- [Gestisci casella di testo](/slides/it/cpp/manage-textbox/)
- [Carattere incorporato](/slides/it/cpp/embedded-font/)