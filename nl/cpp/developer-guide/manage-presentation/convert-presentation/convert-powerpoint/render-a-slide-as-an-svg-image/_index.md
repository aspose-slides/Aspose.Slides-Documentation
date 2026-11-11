---
title: Render presentatiedia's als SVG-afbeeldingen in C++
linktitle: Dia naar SVG
type: docs
weight: 50
url: /nl/cpp/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint naar SVG
- presentatie naar SVG
- dia naar SVG
- PPT naar SVG
- PPTX naar SVG
- SVG-exportopties
- interactieve SVG
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Exporteer PowerPoint-dia's als SVG-afbeeldingen in C++ en beheer lettertypen, tekst, afbeeldingen, ID's en events met Aspose.Slides."
---
## **Overzicht**

SVG is een schaalbaar XML-gebaseerd afbeeldingsformaat dat goed werkt voor webpublicatie, diavoorbeelders, toegankelijkheidsworkflows en geautomatiseerde naverwerking. Aspose.Slides for C++ exporteert elke dia naar een afzonderlijk SVG-bestand en stelt u in staat te bepalen hoe tekst, lettertypen, afbeeldingen en SVG-elementen worden geschreven.

Gebruik [SVGOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/) wanneer het geëxporteerde SVG compact, voorspelbaar over browsers heen, of klaar voor interactief gebruik moet zijn.

## **Exporteer een dia als SVG**

Maak een [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) aan, selecteer een dia en schrijf deze naar een stream. Het volgende voorbeeld exporteert elke dia in een presentatie naar een afzonderlijk SVG-bestand.

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

De bestandsnaam gebruikt [ISlide::get_SlideNumber](https://reference.aspose.com/slides/cpp/aspose.slides/islide/get_slidenumber/) in plaats van de lusindex. U kunt ook een individueel object exporteren met [IShape::WriteAsSvg](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/writeassvg/) wanneer een diavoorbeelder of webpagina alleen dat object nodig heeft.

## **Configureer SVG-uitvoer**

[SVGOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/) bepaalt de SVG-rendering. Voor tekstframes zorgt [SVGOptions::set_UseFrameSize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_useframesize/) ervoor dat het tekstframe in het rendergebied wordt opgenomen, en [SVGOptions::set_UseFrameRotation](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_useframerotation/) bepaalt of de rotatie van het frame wordt toegepast. Stel [SVGOptions::set_DisableFontLigatures](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_disablefontligatures/) in op `true` wanneer tekst zonder ligatures moet worden gerenderd.

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

## **Beheer tekst en lettertypen**

Bij het exporteren van dia's naar SVG kunt u bepalen of tekst behouden blijft als tekst of wordt omgezet in vectorgraphics, en hoe externe lettertypen worden opgenomen of gerefereerd. De volgende opties helpen u de visuele consistentie, tekstselectie en lettertype-afhankelijkheden in het geëxporteerde SVG in balans te brengen.

### **Vectoriseer alle tekst**

Stel [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) in op `true` om alle dia-tekst als vectorgraphics te schrijven. Dit verwijdert lettertype-afhankelijkheden en maakt het visuele resultaat consistenter over browsers, maar de tekst is niet langer selecteerbaar of doorzoekbaar als SVG-tekst.

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

### **Kies hoe externe lettertypen worden behandeld**

[SVGOptions::set_ExternalFontsHandling](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_externalfontshandling/) gebruikt een [SvgExternalFontsHandling](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/) waarde voor lettertypen die extern worden geladen. Kies `AddLinksToFontFiles` om naar afzonderlijke lettertype-bestanden te verwijzen, `Embed` om lettertype-data in het SVG op te nemen, of `Vectorize` om alleen tekst die externe lettertypen gebruikt als graphics te renderen. Controleer de licentie van het lettertype voordat u lettertypen insluit.

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

## **Verminder de grootte van ingesloten afbeeldingen**

Gebruik [SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_picturescompression/) om de resolutie van ingesloten afbeeldingen te verlagen, [SVGOptions::set_DeletePicturesCroppedAreas](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_deletepicturescroppedareas/) om bijgesneden bronomgevingen weg te laten, en [SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_jpegquality/) om de JPEG-codeerkwaliteit te regelen. Deze instellingen verkleinen de bestandsgrootte ten koste van beeldfidelity of bewaarde beeldgegevens.

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

## **Beheer resolutie van metafile-rasterisatie**

[SVGOptions::set_MetafileRasterizationDpi](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_metafilerasterizationdpi/) stelt de ondergrens voor de resolutie in bij het rasteren van metafiles tijdens SVG-export. Gebruik dit om detail en bestandsgrootte in balans te brengen wanneer een EMF- of WMF-afbeelding wordt gerasterd. Het definieert geen globale DPI voor het SVG en dwingt niet elk object op de dia om een rasterafbeelding te worden.

Download [metafile-rasterization.pptx](metafile-rasterization.pptx), dat een EMF-afbeelding bevat met dicht opeengepakte diagonale lijnen. Het volgende voorbeeld exporteert de eerste dia op drie rasterisatie-resoluties via [ISlide::WriteAsSvg](https://reference.aspose.com/slides/cpp/aspose.slides/islide/writeassvg/). Alle andere exportinstellingen blijven gelijk zodat de resultaten vergeleken kunnen worden.

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

In de uitvoer is de EMF omgezet naar één ingesloten PNG in elk SVG. De onderstaande metingen gelden voor de meegeleverde presentatie; ze zijn geen algemene formule voor het omrekenen van DPI naar pixelafmetingen.

| Metafile-rasterisatie DPI | Ingesloten PNG-afmetingen | SVG-bestandsgrootte (bytes) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

De onderstaande vergelijking toont hetzelfde gebied van de ingesloten rasterafbeelding op dezelfde vergrote weergavegrootte. De diagonale lijnen vertonen zichtbare pixelvorming bij 72 DPI en gladdere randen bij hogere resoluties, terwijl het SVG-bestand groeit. Het verhogen van de waarde verbetert niet per se elk detail of verandert elke geëxporteerde afbeelding.

![Uitvergrote diagonale-lijndetail bij 72, 150 en 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_picturescompression/) regelt de vermindering van beeldresolutie en kan het effect van het wijzigen van de metafile-rasterisatie-resolutie maskeren. [SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_jpegquality/) regelt de JPEG-codeerkwaliteit, niet de metafile-rasterisatie-resolutie.

## **Wijs stabiele ID's toe aan vormen en tekst**

Gebruik [ISvgShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeformattingcontroller/) om [ISvgShape::set_Id](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshape/set_id/) voor elke SVG-vorm in te stellen. Om ook [ISvgTSpan::set_Id](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgtspan/set_id/) waarden op tekst-`tspan`-elementen te zetten, implementeer [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeandtextformattingcontroller/). Wijs een van beide controllers toe met [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/).

De onderstaande controller gebruikt [IShape::get_OfficeInteropShapeId](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_officeinteropshapeid/), die stabiel is gedurende de levensduur van de vorm, en een herhaalbare teller voor de bijbehorende tekst-spans. Hierdoor zijn de gegenereerde ID's geschikt voor post-processing van een onveranderde presentatie.

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

## **Voeg SVG-eventhandlers toe**

In een [ISvgShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeformattingcontroller/) roept u [ISvgShape::SetEventHandler](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshape/seteventhandler/) aan met een [SvgEvent](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgevent/) waarde om een JavaScript-eventhandler toe te voegen aan een geëxporteerde vorm. Wijs de controller toe met [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/) en definieer de JavaScript-functie in de pagina of het SVG-document dat het resultaat host.

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

De host-pagina kan de JavaScript-functie definiëren die door de handler wordt aangeroepen. Het toewijzen van ID's en event-handlers maakt diavoorbeelders, toegankelijkheidsverbeteringen en andere interactieve SVG-workflows mogelijk.

## **Veelgestelde vragen**

**Wanneer moet ik [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) gebruiken in plaats van [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/)?**

Gebruik [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) wanneer alle tekst onafhankelijk moet zijn van lettertypen. Gebruik [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/) wanneer alleen tekst die externe lettertypen gebruikt moet worden omgezet naar graphics.

**Wat is de beste manier om een SVG kleiner te maken?**

Begin met het comprimeren van ingesloten afbeeldingen, het verwijderen van bijgesneden afbeeldingsgebieden, en het kiezen van gelinkte lettertypebestanden wanneer de doelomgeving ze kan leveren. Test het resultaat omdat lagere beeldresolutie, lagere JPEG-kwaliteit en gevectoriseerde tekst elk verschillende kwaliteit- en omvang-afwegingen hebben.

**Kan ik geëxporteerde SVG-elementen na export aanpassen?**

Ja. Wijs ID's toe via een formatteringscontroller, en selecteer vervolgens de overeenkomstige SVG-elementen in uw post-processing-tool of browserscript.