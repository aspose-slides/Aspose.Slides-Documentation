---
title: Gestire gli oggetti Ink della presentazione in C++
linktitle: Gestisci Ink
type: docs
weight: 95
url: /it/cpp/manage-ink/
keywords:
- inchiostro
- oggetto inchiostro
- traccia inchiostro
- gestire inchiostro
- disegnare inchiostro
- disegno
- esportazione inchiostro
- rendering inchiostro
- nascondere inchiostro
- IInkOptions
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Gestisci gli oggetti ink di PowerPoint, modifica le tracce e le proprietà del pennello, e controlla l'aspetto dell'ink durante l'esportazione in PDF, HTML, SVG, TIFF e immagini con Aspose.Slides per C++."
---
## **Introduzione**

PowerPoint fornisce una funzionalità ink che consente di disegnare tratti liberi. L'inchiostro può essere utilizzato per evidenziare altri oggetti, mostrare connessioni e processi e attirare l'attenzione su elementi specifici in una diapositiva.

Lo spazio dei nomi [Aspose.Slides.Ink](https://reference.aspose.com/slides/it/cpp/aspose.slides.ink/) contiene le classi e le interfacce necessarie per lavorare con gli oggetti ink. Ad esempio, l'interfaccia [IInk](https://reference.aspose.com/slides/it/cpp/aspose.slides.ink/iink/) rappresenta un oggetto ink in una diapositiva.

## **Differenze tra Oggetti Regolari e Oggetti Ink**

Gli oggetti in una diapositiva PowerPoint sono tipicamente rappresentati da oggetti forma. Nella sua forma più semplice, una forma è un contenitore che definisce l'area dell'oggetto stesso (il suo riquadro) insieme a proprietà come le dimensioni del contenitore, la forma e lo sfondo. Per ulteriori informazioni, vedere [Formato di Layout della Forma](https://docs.aspose.com/slides/it/cpp/shape-manipulations/#access-layout-formats-for-shape).

Tuttavia, quando PowerPoint gestisce un oggetto ink, ignora tutte le proprietà del riquadro dell'oggetto (contenitore) tranne le sue dimensioni. Le dimensioni dell'area del contenitore sono determinate dai metodi standard [IShape::get_Width](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/get_width/) e [IShape::get_Height](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/get_height/) :

![ink_powerpoint1](ink_powerpoint1.png)

## **Tracce Ink**

Una traccia ink è un elemento di base usato per registrare la traiettoria di una penna mentre l'utente scrive inchiostro digitale. Una traccia memorizza una sequenza di punti collegati.

La forma più semplice di codifica specifica le coordinate X e Y di ciascun punto di campionamento. Quando tutti i punti collegati vengono renderizzati, producono un'immagine come questa:

![ink_powerpoint2](ink_powerpoint2.png)

## **Proprietà del Pennello per il Disegno**

Un pennello è usato per disegnare linee che collegano i punti di una traccia ink. Il pennello ha il proprio colore e le proprie dimensioni, rappresentati dai metodi [IInkBrush::get_Color](https://reference.aspose.com/slides/it/cpp/aspose.slides.ink/iinkbrush/get_color/) e [IInkBrush::get_Size](https://reference.aspose.com/slides/it/cpp/aspose.slides.ink/iinkbrush/get_size/) .

### **Impostare il Colore del Pennello Ink**

Questo codice C++ mostra come impostare il colore di un pennello ink:

```cpp
#include <DOM/Ink/IInk.h>
#include <DOM/Ink/IInkBrush.h>
#include <DOM/Ink/IInkTrace.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Ink::IInk;
using Aspose::Slides::Presentation;
using System::ExplicitCast;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"pres.pptx");
auto ink = ExplicitCast<IInk>(presentation->get_Slide(0)->get_Shape(0));
auto inkTrace = ink->get_Traces()[0];
auto brush = inkTrace->get_Brush();
brush->set_Color(System::Drawing::Color::get_Red());

presentation->Dispose();
```

### **Impostare le Dimensioni del Pennello Ink**

Questo codice C++ mostra come impostare le dimensioni di un pennello ink:

```cpp
#include <DOM/Ink/IInk.h>
#include <DOM/Ink/IInkBrush.h>
#include <DOM/Ink/IInkTrace.h>
#include <DOM/Presentation.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Ink::IInk;
using Aspose::Slides::Presentation;
using System::ExplicitCast;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"pres.pptx");
auto ink = ExplicitCast<IInk>(presentation->get_Slide(0)->get_Shape(0));
auto inkTrace = ink->get_Traces()[0];
auto brush = inkTrace->get_Brush();
brush->set_Size(System::Drawing::SizeF(5.0f, 10.0f));

presentation->Dispose();
```

In generale, la larghezza e l'altezza di un pennello non corrispondono, quindi PowerPoint non visualizza le dimensioni del pennello (la relativa sezione dati è grigia). Quando larghezza e altezza del pennello coincidono, PowerPoint visualizza le sue dimensioni in questo modo:

![ink_powerpoint3](ink_powerpoint3.png)

Per maggiore chiarezza, aumentiamo l'altezza dell'oggetto ink e rivediamo le dimensioni importanti:

![ink_powerpoint4](ink_powerpoint4.png)

Il contenitore (riquadro) non tiene conto delle dimensioni dei pennelli: assume sempre che lo spessore della linea sia zero (vedi l'immagine precedente).

Pertanto, per determinare l'area visibile dell'intero oggetto ink, è necessario considerare le dimensioni del pennello delle sue tracce. Qui l'oggetto di destinazione (la traccia di testo scritto a mano) è stato scalato alle dimensioni del contenitore (riquadro). Quando le dimensioni del contenitore cambiano, le dimensioni del pennello rimangono costanti, e viceversa.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint utilizza un comportamento simile per gli oggetti di testo:

![ink_powerpoint6](ink_powerpoint6.png)

## **Controllare l'Aspetto dell'Ink Durante l'Esportazione e il Rendering**

Aspose.Slides fornisce l'interfaccia [IInkOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/iinkoptions/) per controllare come gli oggetti ink appaiono nell'output esportato o renderizzato. È possibile usare i suoi metodi per nascondere completamente l'ink o per modificare il modo in cui le operazioni di maschera del pennello ink vengono interpretate.

Le opzioni ink sono disponibili tramite le opzioni di esportazione o rendering per diversi tipi di output:

| Output | Metodo opzioni Ink |
| --- | --- |
| PDF | [PdfOptions::get_InkOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/pdfoptions/get_inkoptions/) |
| HTML | [HtmlOptions::get_InkOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/htmloptions/get_inkoptions/) |
| SVG | [SVGOptions::get_InkOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/svgoptions/get_inkoptions/) |
| TIFF | [TiffOptions::get_InkOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/tiffoptions/get_inkoptions/) |
| Immagine della diapositiva | [RenderingOptions::get_InkOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/renderingoptions/get_inkoptions/) |

Gli stessi due settaggi sono disponibili attraverso questi metodi:

- [IInkOptions::set_HideInk](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/iinkoptions/set_hideink/) determina se gli oggetti ink sono inclusi nell'output. Il valore predefinito è `false`.
- [IInkOptions::set_InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/iinkoptions/set_interpretmaskopasopacity/) determina se un'operazione di maschera è interpretata come opacità durante il rendering di un pennello ink. Il valore predefinito è `true`; impostarlo a `false` per utilizzare l'operazione ROP invece.

### **Nascondere gli Oggetti Ink nell'Output PDF**

Per impostazione predefinita, gli oggetti ink rimangono visibili durante l'esportazione. Chiamare [IInkOptions::set_HideInk](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/iinkoptions/set_hideink/) con `true` quando è necessario un output pulito senza annotazioni scritte a mano o altri contenuti ink.

Il seguente esempio C++ esporta una presentazione in PDF nascondendo tutti gli oggetti ink:

```cpp
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::PdfOptions;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->get_InkOptions()->set_HideInk(true);

presentation->Save(u"presentation_without_ink.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **Nascondere gli Oggetti Ink Durante il Rendering di una Diapositiva come Immagine**

Per nascondere gli oggetti ink quando le diapositive vengono renderizzate come immagini bitmap, configurare [RenderingOptions::get_InkOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/renderingoptions/get_inkoptions/) e passare le opzioni di rendering al metodo [ISlide::GetImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/islide/getimage/) .

Il seguente esempio C++ rende la prima diapositiva come immagine PNG senza oggetti ink:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/RenderingOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::ImageFormat;
using Aspose::Slides::Presentation;
using Aspose::Slides::Export::RenderingOptions;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->get_InkOptions()->set_HideInk(true);

auto image = presentation->get_Slide(0)->GetImage(renderingOptions);
image->Save(u"slide_without_ink.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

### **Controllare il Rendering della Maschera Ink**

Il metodo [IInkOptions::set_InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/iinkoptions/set_interpretmaskopasopacity/) controlla come le operazioni di maschera sono interpretate durante il rendering dei pennelli ink. Il valore predefinito è `true`, che utilizza l'opacità. Chiamare il metodo con `false` per utilizzare l'operazione ROP invece.

Il seguente esempio C++ esporta una diapositiva in SVG e utilizza il rendering basato su ROP per le operazioni di maschera ink:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SVGOptions;
using System::MakeObject;
using System::IO::File;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->get_InkOptions()->set_InterpretMaskOpAsOpacity(false);

auto stream = File::Create(u"slide.svg");
presentation->get_Slide(0)->WriteAsSvg(stream, svgOptions);

stream->Dispose();
presentation->Dispose();
```

Lo stesso settaggio può essere applicato tramite [TiffOptions::get_InkOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/tiffoptions/get_inkoptions/) durante l'esportazione di una presentazione o il rendering di una diapositiva in TIFF.

### **Scegliere Se Nascondere o Preservare l'Ink**

Usare [IInkOptions::set_HideInk](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/iinkoptions/set_hideink/) con `true` quando il file esportato deve essere una versione pulita di una presentazione annotata, ad esempio una copia finale destinata alla distribuzione senza segni di revisione.

Mantenere l'ink visibile (impostazione predefinita `false`) quando le annotazioni ink fanno parte del contenuto previsto, come commenti di revisione, note scritte a mano, evidenziazioni o disegni che devono rimanere visibili nel risultato esportato. Questo consente alle applicazioni di generare uscite di revisione e finali separate dalla stessa presentazione senza modificare gli oggetti ink di origine.

## **FAQ**

**Posso cambiare il colore o le dimensioni di un tratto ink esistente?**

Sì. Ottieni la traccia da [IInk::get_Traces](https://reference.aspose.com/slides/it/cpp/aspose.slides.ink/iink/get_traces/), quindi modifica il suo [IInkTrace::get_Brush](https://reference.aspose.com/slides/it/cpp/aspose.slides.ink/iinktrace/get_brush/). Puoi chiamare [IInkBrush::set_Color](https://reference.aspose.com/slides/it/cpp/aspose.slides.ink/iinkbrush/set_color/) e [IInkBrush::set_Size](https://reference.aspose.com/slides/it/cpp/aspose.slides.ink/iinkbrush/set_size/) sul pennello.

**Nascondere l'ink modifica la presentazione di origine?**

No. [IInkOptions::set_HideInk](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/iinkoptions/set_hideink/) influisce solo sul risultato renderizzato o esportato; non rimuove né modifica gli oggetti ink nella presentazione di origine.

**Quali formati di esportazione supportano le opzioni ink?**

È possibile configurare le opzioni ink per PDF, HTML, SVG, TIFF e immagini bitmap delle diapositive tramite le corrispondenti opzioni di esportazione o rendering mostrate sopra.

**Ulteriori letture**

* Per informazioni generali sulle forme, vedere la sezione [Forme PowerPoint](https://docs.aspose.com/slides/it/cpp/powerpoint-shapes/) .
* Per maggiori informazioni sui valori effettivi, vedere [Proprietà Effettive della Forma](https://docs.aspose.com/slides/it/cpp/shape-effective-properties/#get-effective-font-height-value) .
* Per i dettagli sull'esportazione PDF, vedere [Convertire PPT e PPTX in PDF](https://docs.aspose.com/slides/it/cpp/convert-powerpoint-to-pdf/) .
* Per i dettagli sull'esportazione HTML, vedere [Convertire Presentazioni PowerPoint in HTML](https://docs.aspose.com/slides/it/cpp/convert-powerpoint-to-html/) .
* Per i dettagli sull'esportazione SVG, vedere [Renderizzare Diapositive di Presentazione come Immagini SVG](https://docs.aspose.com/slides/it/cpp/render-a-slide-as-an-svg-image/) .
* Per i dettagli sull'esportazione TIFF, vedere [Convertire Presentazioni PowerPoint in TIFF](https://docs.aspose.com/slides/it/cpp/convert-powerpoint-to-tiff/) .
* Per i dettagli sul rendering di diapositive in immagini, vedere [Convertire Diapositive di Presentazione in Immagini](https://docs.aspose.com/slides/it/cpp/convert-slide/) .