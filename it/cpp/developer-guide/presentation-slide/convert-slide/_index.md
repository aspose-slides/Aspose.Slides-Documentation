---
title: Convertire le diapositive della presentazione in immagini in C++
linktitle: Diapositiva a immagine
type: docs
weight: 41
url: /it/cpp/convert-slide/
keywords:
- convertire diapositiva
- esportare diapositiva
- diapositiva a immagine
- salvare diapositiva come immagine
- diapositiva a EMF
- diapositiva a PNG
- diapositiva a JPEG
- diapositiva a bitmap
- diapositiva a TIFF
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Converti diapositive da presentazioni PPT, PPTX e ODP in PNG, JPEG, GIF, TIFF, EMF e altri formati immagine in C++ con Aspose.Slides per C++."
---
## **Introduzione**

Aspose.Slides per C++ può rendere singole diapositive da presentazioni PowerPoint e OpenDocument in formati immagine come PNG, JPEG, GIF, TIFF e altri.

Per convertire una diapositiva in un'immagine, seguire questi passaggi:

1. Caricare la presentazione con la classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
2. Selezionare la diapositiva che si desidera renderizzare.
3. Se necessario, configurare il rendering con la classe [RenderingOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/renderingoptions/) o [TiffOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/tiffoptions/).
4. Chiamare il metodo [ISlide::GetImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/islide/getimage/). Restituisce un oggetto [IImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/iimage/).
5. Chiamare il metodo [IImage::Save](https://reference.aspose.com/slides/it/cpp/aspose.slides/iimage/save/) e specificare il formato di output con un valore [ImageFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/imageformat/).

## **Convertire una diapositiva in un'immagine PNG**

La conversione più semplice utilizza le impostazioni di rendering predefinite. L'oggetto [IImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/iimage/) risultante può essere elaborato in memoria o salvato su file.

Il seguente esempio C++ rende la prima diapositiva e la salva come immagine PNG:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage();
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

## **Convertire diapositive in immagini con dimensioni personalizzate**

Utilizzare la sovraccarico di [ISlide::GetImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/islide/getimage/) che accetta un valore [Size](https://reference.aspose.com/slides/it/cpp/system.drawing/size/) per renderizzare una diapositiva con dimensioni in pixel precise.

Il seguente esempio crea un'immagine JPEG 1820 × 1040:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Drawing;

Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(imageSize);
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

## **Convertire diapositive con note e commenti in immagini**

Per impostazione predefinita, le immagini delle diapositive non includono note o commenti. Assegnare un oggetto [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/notescommentslayoutingoptions/) al metodo [RenderingOptions::set_SlidesLayoutOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/renderingoptions/set_slideslayoutoptions/) per controllare dove appaiono note e commenti.

Il seguente esempio posiziona note troncate sotto la diapositiva e commenti a destra:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/CommentsPositions.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/RenderingOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

float scaleX = 2.0f;
float scaleY = scaleX;

auto layoutOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_NotesPosition(NotesPositions::BottomTruncated);
layoutOptions->set_CommentsPosition(CommentsPositions::Right);
layoutOptions->set_CommentsAreaWidth(500);
layoutOptions->set_CommentsAreaColor(Color::get_AntiqueWhite());

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layoutOptions);

auto presentation = MakeObject<Presentation>(u"Presentation_with_notes_and_comments.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(renderingOptions, scaleX, scaleY);
image->Save(u"Image_with_notes_and_comments_0.gif", ImageFormat::Gif);

image->Dispose();
presentation->Dispose();
```

{{% alert title="Attenzione" color="warning" %}}
Per la conversione diapositiva‑immagine, non impostare il metodo [NotesCommentsLayoutingOptions::set_NotesPosition](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) su [BottomFull](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/notespositions/). Le note possono contenere più testo rispetto a quanto la dimensione fissa dell'immagine possa contenere. Utilizzare invece [BottomTruncated](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/notespositions/).
{{% /alert %}}

## **Convertire diapositive in immagini utilizzando le opzioni TIFF**

La classe [TiffOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/tiffoptions/) consente di controllare dimensione, risoluzione e altre proprietà dell'immagine TIFF renderizzata.

Il seguente esempio rende la prima diapositiva come immagine TIFF 2160 × 2880 a 300 DPI:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/TiffOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_ImageSize(Size(2160, 2880));
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(tiffOptions);
image->Save(u"output.tiff", ImageFormat::Tiff);

image->Dispose();
presentation->Dispose();
```

## **Convertire tutte le diapositive in immagini**

Iterare la collezione di diapositive per convertire l'intera presentazione in una serie di immagini. Le diapositive nascoste sono incluse a meno che non vengano saltate esplicitamente.

Il seguente esempio rende ogni diapositiva come immagine JPEG con fattori di scala orizzontali e verticali pari a 2:

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

float scaleX = 2.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

int32_t slideCount = presentation->get_Slides()->get_Count();
for (int32_t index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(scaleX, scaleY);
    image->Save(String::Format(u"Slide_{0}.jpg", index), ImageFormat::Jpeg);
    image->Dispose();
}

presentation->Dispose();
```

## **Creare output Enhanced Metafile**

Enhanced Metafile (EMF) è utile quando è necessario scambiare grafica vettoriale con Microsoft Office o altre applicazioni Windows che supportano i metafile Windows. A differenza di un'immagine raster, un EMF può conservare le operazioni di disegno vettoriale che si scalano senza perdita di nitidezza. Tuttavia, EMF è principalmente un formato di compatibilità per le applicazioni con supporto ai metafile Windows, non un formato di interscambio universale. Inoltre, contenuti complessi delle diapositive, come immagini bitmap e alcuni effetti, possono essere memorizzati come elementi rasterizzati all'interno del contenitore vettoriale.

### **Esportare una diapositiva in EMF**

Il metodo [ISlide::WriteAsEmf](https://reference.aspose.com/slides/it/cpp/aspose.slides/islide/writeasemf/) scrive una [ISlide](https://reference.aspose.com/slides/it/cpp/aspose.slides/islide/) in uno stream di destinazione in formato EMF. Il seguente esempio carica una presentazione, seleziona la prima diapositiva e la scrive in uno stream di file EMF:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto emfStream = File::Create(u"Slide_0.emf");
slide->WriteAsEmf(emfStream);

emfStream->Close();
presentation->Dispose();
```

Il chiamante possiede lo stream passato a [ISlide::WriteAsEmf](https://reference.aspose.com/slides/it/cpp/aspose.slides/islide/writeasemf/) e deve chiuderlo o smaltirlo. Aspose.Slides scrive nella posizione corrente dello stream e lo lascia aperto.

### **Convertire un'immagine SVG in EMF e aggiungerla a una presentazione**

Usare [ISvgImage::WriteAsEmf](https://reference.aspose.com/slides/it/cpp/aspose.slides/isvgimage/writeasemf/) per convertire contenuto SVG in EMF. I byte risultanti possono essere aggiunti alla presentazione tramite [IImageCollection::AddImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/iimagecollection/addimage/) e inseriti su una diapositiva con [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides.ishapecollection/addpictureframe/).

Il seguente esempio crea un [SvgImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/svgimage/) da markup SVG, lo converte in un EMF in memoria, inserisce il metafile sulla prima diapositiva e salva la presentazione:

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

String svgContent = u"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
auto svgImage = MakeObject<SvgImage>(svgContent);

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto emfStream = MakeObject<MemoryStream>();
svgImage->WriteAsEmf(emfStream);

auto emfData = emfStream->ToArray();
auto image = presentation->get_Images()->AddImage(emfData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20, 20, 200, 100, image);

presentation->Save(u"Presentation_with_emf.pptx", SaveFormat::Pptx);

emfStream->Close();
presentation->Dispose();
```

[ISvgImage::WriteAsEmf](https://reference.aspose.com/slides/it/cpp/aspose.slides/isvgimage/writeasemf/) non assume la proprietà dello stream di destinazione. Dopo la scrittura, la posizione dello stream è alla fine dei dati generati. L'esempio chiama [MemoryStream::ToArray](https://reference.aspose.com/slides/it/cpp/system.io/memorystream/toarray/) per ottenere il buffer completo indipendentemente dalla posizione corrente dello stream, quindi passa quell'array di byte a [IImageCollection::AddImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/iimagecollection/addimage/). Mantenere lo stream aperto finché il consumatore non ha terminato la lettura, quindi chiuderlo successivamente.

La generazione di EMF è disponibile sui sistemi operativi supportati da Aspose.Slides per C++, ma il rendering può variare tra le piattaforme quando i font o le dipendenze grafiche native non sono disponibili. Installare i font utilizzati dal contenuto sorgente o configurare sostituzioni adeguate, seguire i [requisiti di piattaforma](/slides/it/cpp/system-requirements/) per Aspose.Slides per C++ e convalidare il risultato nell'applicazione di destinazione che consuma EMF. Le applicazioni Linux e macOS spesso hanno supporto limitato o incoerente per la visualizzazione e la modifica dei metafile Windows.

## **Rendering di Emoji a Colori**

{{% alert title="Nota" color="info" %}}
Per rendere correttamente le emoji a colori quando si convertono le diapositive in immagini, i font emoji utilizzati nella presentazione devono essere installati e disponibili sul sistema che esegue la conversione. Per esempio, se la presentazione usa **Segoe UI Emoji** e questo font è mancante, le emoji potrebbero apparire in bianco‑nero nelle immagini di output.
{{% /alert %}}

## **FAQ**

**Aspose.Slides supporta il rendering di diapositive con animazioni?**

No. Il metodo [ISlide::GetImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/islide/getimage/) rende un'immagine statica della diapositiva e non esporta animazioni.

**Le diapositive nascoste possono essere esportate come immagini?**

Sì. Le diapositive nascoste possono essere renderizzate come diapositive normali. Includerle nel ciclo di processing, come mostrato nell'esempio sopra.

**Ombre e altri effetti vengono conservati nelle immagini delle diapositive?**

Sì. Aspose.Slides rende ombre, trasparenza e altri effetti grafici supportati nelle immagini delle diapositive.