---
title: Genera le diapositive di presentazione come immagini SVG in C++
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
description: "Esporta le diapositive PowerPoint come immagini SVG in C++ e controlla i caratteri, il testo, le immagini, gli ID e gli eventi con Aspose.Slides."
---
## **Panoramica**

SVG è un formato immagine scalabile basato su XML che funziona bene per la pubblicazione web, i visualizzatori di diapositive, i flussi di lavoro di accessibilità e l'elaborazione automatica. Aspose.Slides per C++ esporta ogni diapositiva in un file SVG separato e consente di controllare come vengono scritti testo, caratteri, immagini e gli elementi SVG.

Utilizza [SVGOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/) quando l'SVG esportato deve essere compatto, prevedibile tra i browser o pronto per l'uso interattivo.

## **Esporta una diapositiva come SVG**

Crea una [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/), seleziona una diapositiva e scrivila in uno stream. L'esempio seguente esporta ogni diapositiva di una presentazione in un file SVG separato.

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

Il nome file utilizza [ISlide::get_SlideNumber](https://reference.aspose.com/slides/cpp/aspose.slides/islide/get_slidenumber/) invece dell'indice del ciclo. È inoltre possibile esportare una forma individuale con [IShape::WriteAsSvg](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/writeassvg/) quando un visualizzatore di diapositive o una pagina web ha bisogno solo di quella forma.

## **Configura l'output SVG**

[SVGOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/) controlla il rendering SVG. Per i riquadri di testo, [SVGOptions::set_UseFrameSize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_useframesize/) include il riquadro di testo nell'area di rendering, e [SVGOptions::set_UseFrameRotation](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_useframerotation/) determina se viene applicata la rotazione del riquadro. Imposta [SVGOptions::set_DisableFontLigatures](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_disablefontligatures/) su `true` quando il testo deve essere renderizzato senza legature.

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

## **Controlla il ritaglio delle estremità della linea alle teste delle frecce**

SVG 1.1 non dispone di un'impostazione di inserimento del marcatore per specificare dove una linea dovrebbe fermarsi sotto una punta di freccia. Per impostazione predefinita, Aspose.Slides accorcia la linea esportata in modo che il tratto non fuoriesca dal marcatore. Imposta [SVGOptions::set_DisableLineEndCropping](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_disablelineendcropping/) su `true` per disegnare il tratto fino al punto finale originale della linea. Questa impostazione influisce solo sull'output SVG. La linea mantiene la sua posizione e lunghezza nella diapositiva.

L'esempio disegna teste di freccia a triangolo e a diamante su linee larghe rispettivamente 2 e 10 punti. Esporta la stessa diapositiva due volte, modificando solo l'opzione di ritaglio.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/FillType.h>
#include <DOM/LineArrowheadStyle.h>
#include <DOM/ShapeType.h>
#include <Export/SVGOptions.h>
#include <drawing/color.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto y = 40;
const LineArrowheadStyle styles[] = { LineArrowheadStyle::Triangle, LineArrowheadStyle::Diamond };
const int widths[] = { 2, 10 };

for (auto style : styles)
{
    for (auto width : widths)
    {
        auto line = slide->get_Shapes()->AddAutoShape(ShapeType::Line, 40, y, 200, 0);
        auto format = line->get_LineFormat();
        format->get_FillFormat()->set_FillType(FillType::Solid);
        format->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
        format->set_Width(width);
        format->set_EndArrowheadStyle(style);
        y += 50;
    }
}

auto options = MakeObject<SVGOptions>();
options->set_DisableLineEndCropping(false);
auto cropped = File::Create(u"cropped.svg");
slide->WriteAsSvg(cropped, options);
cropped->Dispose();

options->set_DisableLineEndCropping(true);
auto uncropped = File::Create(u"uncropped.svg");
slide->WriteAsSvg(uncropped, options);
uncropped->Dispose();

presentation->Dispose();
```

Il confronto mostra la punta triangolare sulla linea da 10 punti. Con il ritaglio abilitato, la punta è affilata. Con il ritaglio disabilitato, il tratto fuoriesce dai lati inclinati del marcatore lasciando un'estremità piatta.

![Enlarged 10-point triangle with a sharp tip when cropping is enabled and a flat end when cropping is disabled](line-end-cropping.png)

Nelle altre linee dell'esempio, il tratto sporgente è meno visibile sul triangolo da 2 punti. Il diamante pieno copre l'estremità del tratto a entrambe le larghezze.

## **Controlla testo e caratteri**

Quando si esportano diapositive in SVG, è possibile controllare se il testo rimane come testo o viene convertito in grafica vettoriale, e come i caratteri esterni vengono inclusi o referenziati. Le opzioni seguenti aiutano a bilanciare la coerenza visiva, la selezione del testo e le dipendenze dai caratteri nell'SVG esportato.

### **Vettorializza tutto il testo**

Imposta [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) su `true` per scrivere tutto il testo della diapositiva come grafica vettoriale. Questo elimina le dipendenze dai caratteri e rende il risultato visivo più coerente tra i browser, ma il testo non è più selezionabile né ricercabile come testo SVG.

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

[SVGOptions::set_ExternalFontsHandling](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_externalfontshandling/) utilizza un valore [SvgExternalFontsHandling](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/) per i caratteri caricati esternamente. Scegli `AddLinksToFontFiles` per referenziare file di carattere separati, `Embed` per includere i dati del carattere nell'SVG, o `Vectorize` per renderizzare solo il testo che utilizza caratteri esterni come grafica. Verifica la licenza dei caratteri prima di includerli.

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

Utilizza [SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_picturescompression/) per ridurre la risoluzione delle immagini incorporate, [SVGOptions::set_DeletePicturesCroppedAreas](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_deletepicturescroppedareas/) per omettere le aree ritagliate delle immagini di origine, e [SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_jpegquality/) per controllare la qualità della codifica JPEG. queste impostazioni riducono la dimensione del file a scapito della fedeltà dell'immagine o dei dati immagine conservati.

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

## **Controlla la risoluzione di rasterizzazione dei metafile**

[SVGOptions::set_MetafileRasterizationDpi](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_metafilerasterizationdpi/) imposta il limite inferiore di risoluzione per la rasterizzazione dei metafile durante l'esportazione SVG. Usalo per bilanciare dettaglio e dimensione del file quando un'immagine EMF o WMF viene rasterizzata. Non definisce un DPI globale per l'SVG né forza ogni oggetto della diapositiva a diventare un'immagine raster.

Scarica [metafile-rasterization.pptx](metafile-rasterization.pptx), che contiene un'immagine EMF con linee diagonali ravvicinate. L'esempio seguente esporta la sua prima diapositiva a tre risoluzioni di rasterizzazione tramite [ISlide::WriteAsSvg](https://reference.aspose.com/slides/cpp/aspose.slides/islide/writeassvg/). Tutte le altre impostazioni di esportazione rimangono identiche così che i risultati possano essere confrontati.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"metafile-rasterization.pptx");
auto slide = presentation->get_Slide(0);
const int resolutions[] = { 72, 150, 300 };

for (auto dpi : resolutions)
{
    auto svgOptions = MakeObject<SVGOptions>();
    svgOptions->set_MetafileRasterizationDpi(dpi);
    svgOptions->set_PicturesCompression(PicturesCompression::Dpi330);
    svgOptions->set_JpegQuality(90);

    auto svgFileName = String::Format(u"slide-{0}.svg", dpi);
    auto svgStream = File::Create(svgFileName);
    slide->WriteAsSvg(svgStream, svgOptions);
    svgStream->Dispose();
}

presentation->Dispose();
```

Nell'output, l'EMF è diventato un PNG incorporato in ciascun SVG. Le misurazioni seguenti si riferiscono alla presentazione fornita; non rappresentano una formula generale per convertire DPI in dimensioni pixel.

| DPI rasterizzazione metafile | Dimensioni PNG incorporato | Dimensione file SVG (byte) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Il confronto sotto mostra la stessa area del raster incorporato alla stessa dimensione di visualizzazione ingrandita. Le linee diagonali mostrano una pixelatura visibile a 72 DPI e bordi più lisci a risoluzioni più alte, mentre il file SVG aumenta. Incrementare il valore non migliora necessariamente ogni dettaglio né cambia ogni immagine esportata.

![Enlarged diagonal-line detail at 72, 150, and 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_picturescompression/) controlla la riduzione della risoluzione delle immagini e può mascherare l'effetto della variazione della risoluzione di rasterizzazione del metafile. [SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_jpegquality/) controlla la qualità della codifica JPEG, non la risoluzione di rasterizzazione del metafile.

## **Assegna ID stabili a forme e testo**

Utilizza [ISvgShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeformattingcontroller/) per impostare [ISvgShape::set_Id](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshape/set_id/) per ogni forma SVG. Per impostare i valori [ISvgTSpan::set_Id](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgtspan/set_id/) sugli elementi `tspan` del testo, implementa [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeandtextformattingcontroller/). Assegna uno dei due controller con [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/).

Il controller seguente utilizza [IShape::get_OfficeInteropShapeId](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_officeinteropshapeid/), che è stabile per la durata della forma, e un contatore ripetibile per i suoi span di testo. Questo rende gli ID generati idonei per il post‑processing di una presentazione non modificata.

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

In un [ISvgShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeformattingcontroller/), chiama [ISvgShape::SetEventHandler](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshape/seteventhandler/) con un valore [SvgEvent](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgevent/) per aggiungere un gestore di eventi JavaScript a una forma esportata. Assegna il controller con [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/) e definisci la funzione JavaScript nella pagina o nel documento SVG che ospita il risultato.

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

La pagina host può definire la funzione JavaScript referenziata dal gestore. L'assegnazione di ID e gestori di eventi consente visualizzatori di diapositive, miglioramenti di accessibilità e altri flussi di lavoro SVG interattivi.

## **FAQ**

**Quando dovrei usare [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) invece di [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/)?**

Usa [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) quando tutto il testo deve essere indipendente dai caratteri. Usa [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/) quando solo il testo che utilizza caratteri esterni deve essere convertito in grafica.

**Qual è il modo migliore per rendere un SVG più piccolo?**

Inizia comprimendo le immagini incorporate, eliminando le aree di immagine ritagliate e scegliendo file di carattere collegati quando l'ambiente di destinazione può servirli. Verifica il risultato perché una risoluzione immagine più bassa, una qualità JPEG inferiore e il testo vettorializzato hanno diversi compromessi tra qualità e dimensione.

**Posso modificare gli elementi SVG esportati dopo l'esportazione?**

Sì. Assegna ID tramite un controller di formattazione, quindi seleziona gli elementi SVG corrispondenti nel tuo strumento di post‑processing o nello script del browser.