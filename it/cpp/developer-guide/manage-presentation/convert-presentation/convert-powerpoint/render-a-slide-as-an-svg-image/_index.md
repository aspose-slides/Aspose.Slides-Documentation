---
title: Renderizza le diapositive della presentazione come immagini SVG in C++
linktitle: Diapositiva in SVG
type: docs
weight: 50
url: /it/cpp/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint in SVG
- presentazione in SVG
- diapositiva in SVG
- PPT in SVG
- PPTX in SVG
- opzioni di esportazione SVG
- SVG interattivo
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Esporta le diapositive PowerPoint come immagini SVG in C++ e controlla caratteri, testo, immagini, ID ed eventi con Aspose.Slides."
---
## **Panoramica**

SVG è un formato immagine basato su XML scalabile che funziona bene per la pubblicazione web, i visualizzatori di diapositive, i flussi di lavoro di accessibilità e l'elaborazione automatica post‑processing. Aspose.Slides per C++ esporta ogni diapositiva in un file SVG separato e consente di controllare come testo, caratteri, immagini e elementi SVG vengono scritti.

Utilizza [SVGOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/svgoptions/) quando l'SVG esportato deve essere compatto, prevedibile tra i browser o pronto per l'uso interattivo.

## **Esporta una diapositiva come SVG**

Crea una [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/), seleziona una diapositiva e scrivila in uno stream. L'esempio seguente esporta ogni diapositiva di una presentazione in un file SVG separato.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slideCount = presentation->get_Slides()->get_Count();

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    auto svgFileName = String::Format(u"slide-{0}.svg", slide->get_SlideNumber());
    auto svgStream = File::Create(svgFileName);

    slide->WriteAsSvg(svgStream);
    svgStream->Dispose();
}

presentation->Dispose();
```

Il nome file utilizza [ISlide::get_SlideNumber](https://reference.aspose.com/slides/it/cpp/aspose.slides/islide/get_slidenumber/) anziché l'indice del ciclo. È inoltre possibile esportare una forma individuale con [IShape::WriteAsSvg](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/writeassvg/) quando un visualizzatore di diapositive o una pagina web necessita solo di quella forma.

## **Configura l'output SVG**

[SVGOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/svgoptions/) controlla il rendering SVG. Per i riquadri di testo, [SVGOptions::set_UseFrameSize](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/svgoptions/set_useframesize/) include il riquadro di testo nell'area di rendering, e [SVGOptions::set_UseFrameRotation](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/svgoptions/set_useframerotation/) determina se viene applicata la rotazione del riquadro. Imposta [SVGOptions::set_DisableFontLigatures](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/svgoptions/set_disablefontligatures/) su `true` quando il testo deve essere renderizzato senza legature.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_DisableFontLigatures(true);
svgOptions->set_UseFrameSize(true);
svgOptions->set_UseFrameRotation(false);

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"slide-with-custom-options.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

## **Controlla testo e caratteri**

### **Vettorizza tutto il testo**

Imposta [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) su `true` per scrivere tutto il testo della diapositiva come grafica vettoriale. Questo elimina le dipendenze dai caratteri e rende il risultato visivo più coerente tra i browser, ma il testo non è più selezionabile o ricercabile come testo SVG.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_VectorizeText(true);

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"slide-with-vectorized-text.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

### **Scegli come gestire i caratteri esterni**

[SVGOptions::set_ExternalFontsHandling](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/svgoptions/set_externalfontshandling/) utilizza un valore [SvgExternalFontsHandling](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/svgexternalfontshandling/) per i caratteri caricati esternamente. Scegli `AddLinksToFontFiles` per fare riferimento a file di caratteri separati, `Embed` per includere i dati dei caratteri nell'SVG, o `Vectorize` per renderizzare solo il testo che utilizza caratteri esterni come grafica. Verifica le licenze dei caratteri prima di incorporarli.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SVGOptions.h>
#include <Export/SvgExternalFontsHandling.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);

auto linkedFontsOptions = MakeObject<SVGOptions>();
linkedFontsOptions->set_ExternalFontsHandling(SvgExternalFontsHandling::AddLinksToFontFiles);
auto linkedFontsStream = File::Create(u"slide-with-font-links.svg");
slide->WriteAsSvg(linkedFontsStream, linkedFontsOptions);
linkedFontsStream->Dispose();

auto embeddedFontsOptions = MakeObject<SVGOptions>();
embeddedFontsOptions->set_ExternalFontsHandling(SvgExternalFontsHandling::Embed);
auto embeddedFontsStream = File::Create(u"slide-with-embedded-fonts.svg");
slide->WriteAsSvg(embeddedFontsStream, embeddedFontsOptions);
embeddedFontsStream->Dispose();

auto vectorizedExternalFontsOptions = MakeObject<SVGOptions>();
vectorizedExternalFontsOptions->set_ExternalFontsHandling(SvgExternalFontsHandling::Vectorize);
auto vectorizedExternalFontsStream = File::Create(u"slide-with-vectorized-external-fonts.svg");
slide->WriteAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
vectorizedExternalFontsStream->Dispose();

presentation->Dispose();
```

## **Riduci le dimensioni delle immagini incorporate**

Utilizza [SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/svgoptions/set_picturescompression/) per ridurre la risoluzione delle immagini incorporate, [SVGOptions::set_DeletePicturesCroppedAreas](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/svgoptions/set_deletepicturescroppedareas/) per omettere le aree di origine ritagliate e [SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/svgoptions/set_jpegquality/) per controllare la qualità della codifica JPEG. Queste impostazioni riducono la dimensione del file a spese della fedeltà dell'immagine o dei dati delle immagini conservati.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_PicturesCompression(PicturesCompression::Dpi150);
svgOptions->set_DeletePicturesCroppedAreas(true);
svgOptions->set_JpegQuality(80);

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"compressed-slide.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

## **Assegna ID stabili a forme e testo**

Usa [ISvgShapeFormattingController](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/isvgshapeformattingcontroller/) per impostare [ISvgShape::set_Id](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/isvgshape/set_id/) per ciascuna forma SVG. Per impostare i valori [ISvgTSpan::set_Id](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/isvgtspan/set_id/) anche sugli elementi `tspan` del testo, implementa [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/isvgshapeandtextformattingcontroller/). Assegna uno dei due controller con [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/).

Il controller seguente utilizza [IShape::get_OfficeInteropShapeId](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/get_officeinteropshapeid/), che è stabile per la durata della forma, e un contatore ripetibile per i suoi `tspan` di testo. Questo rende gli ID generati adatti per il post‑processing di una presentazione non modificata.

```cpp
#include <DOM/IPortion.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/ISvgShape.h>
#include <Export/ISvgShapeAndTextFormattingController.h>
#include <Export/ISvgTSpan.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

class StableSvgIdController : public ISvgShapeAndTextFormattingController
{
private:
    String m_currentShapeId;
    int m_textSpanIndex = 0;

public:
    void FormatShape(SharedPtr<ISvgShape> svgShape, SharedPtr<IShape> shape) override
    {
        m_currentShapeId = String::Format(u"shape-{0}", shape->get_OfficeInteropShapeId());
        m_textSpanIndex = 0;
        svgShape->set_Id(m_currentShapeId);
    }

    void FormatText(SharedPtr<ISvgTSpan> svgTSpan, SharedPtr<IPortion> portion,
                    SharedPtr<ITextFrame> textFrame) override
    {
        auto currentTextSpanIndex = m_textSpanIndex;
        m_textSpanIndex++;
        svgTSpan->set_Id(String::Format(u"{0}-text-{1}", m_currentShapeId, currentTextSpanIndex));
    }
};

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_ShapeFormattingController(MakeObject<StableSvgIdController>());

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"slide-with-stable-ids.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

## **Aggiungi gestori di eventi SVG**

In un [ISvgShapeFormattingController](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/isvgshapeformattingcontroller/), chiama [ISvgShape::SetEventHandler](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/isvgshape/seteventhandler/) con un valore [SvgEvent](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/svgevent/) per aggiungere un gestore di eventi JavaScript a una forma esportata. Assegna il controller con [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/) e definisci la funzione JavaScript nella pagina o nel documento SVG che ospita il risultato.

```cpp
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/ISvgShape.h>
#include <Export/ISvgShapeFormattingController.h>
#include <Export/SVGOptions.h>
#include <Export/SvgEvent.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

class SvgEventController : public ISvgShapeFormattingController
{
public:
    void FormatShape(SharedPtr<ISvgShape> svgShape, SharedPtr<IShape> shape) override
    {
        if (shape->get_Name() == u"ActionButton")
        {
            svgShape->set_Id(u"action-button");
            svgShape->SetEventHandler(SvgEvent::OnClick, u"handleShapeClick(event)");
        }
    }
};

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_ShapeFormattingController(MakeObject<SvgEventController>());

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"interactive-slide.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

La pagina host può definire la funzione JavaScript a cui fa riferimento il gestore. L'assegnazione di ID e gestori di eventi permette visualizzatori di diapositive, miglioramenti di accessibilità e altri flussi di lavoro SVG interattivi.

## **FAQ**

**Quando dovrei usare [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) invece di [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/svgexternalfontshandling/)?**

Usa [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) quando tutto il testo deve essere indipendente dai caratteri. Usa [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/svgexternalfontshandling/) quando solo il testo che utilizza caratteri esterni dovrebbe essere convertito in grafica.

**Qual è il modo migliore per ridurre le dimensioni di un SVG?**

Inizia comprimendo le immagini incorporate, eliminando le aree ritagliate e scegliendo file di caratteri collegati quando l'ambiente di destinazione può servirli. Testa il risultato perché risoluzione inferiore dell'immagine, qualità JPEG più bassa e testo vettorizzato hanno ciascuno compromessi diversi in termini di qualità e dimensione.

**Posso modificare gli elementi SVG esportati dopo l'esportazione?**

Sì. Assegna ID tramite un controller di formattazione, quindi seleziona gli elementi SVG corrispondenti nel tuo strumento di post‑processing o script del browser.