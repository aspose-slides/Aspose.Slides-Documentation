---
title: Dia's van presentaties renderen als SVG-afbeeldingen in C++
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
description: "Exporteer PowerPoint-dia's als SVG-afbeeldingen in C++ en beheer lettertypen, tekst, afbeeldingen, ID's en gebeurtenissen met Aspose.Slides."
---
## **Overzicht**

SVG is een schaalbaar, op XML gebaseerd afbeeldingformaat dat goed werkt voor webpublicatie, diavoorstellingen, toegankelijkheidswerkstromen en geautomatiseerde nabewerking. Aspose.Slides for C++ exporteert elke dia naar een afzonderlijk SVG‑bestand en stelt u in staat te regelen hoe tekst, lettertypen, afbeeldingen en SVG‑elementen worden weggeschreven.

Gebruik [SVGOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/svgoptions/) wanneer het geëxporteerde SVG compact moet zijn, voorspelbaar in verschillende browsers, of klaar voor interactief gebruik.

## **Een dia exporteren als SVG**

Maak een [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) aan, selecteer een dia en schrijf deze naar een stream. Het volgende voorbeeld exporteert elke dia in een presentatie naar een afzonderlijk SVG‑bestand.

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

De bestandsnaam gebruikt [ISlide::get_SlideNumber](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islide/get_slidenumber/) in plaats van de lusindex. U kunt ook een afzonderlijke vorm exporteren met [IShape::WriteAsSvg](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/writeassvg/) wanneer een diaviewer of webpagina alleen die vorm nodig heeft.

## **SVG‑uitvoer configureren**

[SVGOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/svgoptions/) regelt de weergave van SVG. Voor tekstkaders zorgt [SVGOptions::set_UseFrameSize](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/svgoptions/set_useframesize/) ervoor dat het tekstkader in het rendergebied wordt opgenomen, en [SVGOptions::set_UseFrameRotation](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/svgoptions/set_useframerotation/) bepaalt of de rotatie van het kader wordt toegepast. Stel [SVGOptions::set_DisableFontLigatures](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/svgoptions/set_disablefontligatures/) in op `true` wanneer tekst zonder ligaturen moet worden gerenderd.

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

## **Tekst en lettertypen beheren**

### **Alle tekst vectoriseren**

Stel [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) in op `true` om alle dia‑tekst als vector‑graphics te schrijven. Dit verwijdert afhankelijkheden van lettertypen en zorgt voor een visueel resultaat dat consistenter is over verschillende browsers, maar de tekst is niet langer selecteerbaar of doorzoekbaar als SVG‑tekst.

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

[SVGOptions::set_ExternalFontsHandling](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/svgoptions/set_externalfontshandling/) gebruikt een [SvgExternalFontsHandling](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/svgexternalfontshandling/)‑waarde voor lettertypen die extern worden geladen. Kies AddLinksToFontFiles om naar afzonderlijke lettertypebestanden te verwijzen, Embed om lettertype‑data in de SVG op te nemen, of Vectorize om alleen tekst die externe lettertypen gebruikt als graphics te renderen. Controleer de licentie van het lettertype voordat u lettertypen insluit.

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

## **Ingesloten afbeeldinggrootte verkleinen**

Gebruik [SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/svgoptions/set_picturescompression/) om de resolutie van ingesloten afbeeldingen te verlagen, [SVGOptions::set_DeletePicturesCroppedAreas](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/svgoptions/set_deletepicturescroppedareas/) om bijgesneden brongebieden weg te laten, en [SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/svgoptions/set_jpegquality/) om de kwaliteit van de JPEG‑codering te regelen. Deze instellingen verkleinen de bestandsgrootte ten koste van de beeldkwaliteit of behouden afbeeldingsgegevens.

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

## **Stabiele ID's toewijzen aan vormen en tekst**

Gebruik [ISvgShapeFormattingController](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/isvgshapeformattingcontroller/) om [ISvgShape::set_Id](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/isvgshape/set_id/) in te stellen voor elke SVG‑vorm. Om ook [ISvgTSpan::set_Id](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/isvgtspan/set_id/)‑waarden op tekst‑`tspan`‑elementen in te stellen, implementeer [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/isvgshapeandtextformattingcontroller/). Wijs een van beide controllers toe met [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/).

De onderstaande controller gebruikt [IShape::get_OfficeInteropShapeId](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/get_officeinteropshapeid/), die stabiel is gedurende de levensduur van de vorm, en een herhaalbare teller voor de tekst‑spans. Dit maakt de gegenereerde ID's geschikt voor nabewerking van een onveranderde presentatie.

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

## **SVG‑eventhandlers toevoegen**

In een [ISvgShapeFormattingController](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/isvgshapeformattingcontroller/) roept u [ISvgShape::SetEventHandler](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/isvgshape/seteventhandler/) aan met een [SvgEvent](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/svgevent/)‑waarde om een JavaScript‑eventhandler aan een geëxporteerde vorm toe te voegen. Wijs de controller toe met [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/) en definieer de JavaScript‑functie in de pagina of het SVG‑document dat het resultaat host.

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

De host‑pagina kan de JavaScript‑functie definiëren waar de handler naar verwijst. Het toewijzen van ID's en eventhandlers maakt diaviewers, toegankelijkheidsverbeteringen en andere interactieve SVG‑werkstromen mogelijk.

## **FAQ**

**Wanneer moet ik SVGOptions::set_VectorizeText gebruiken in plaats van SvgExternalFontsHandling::Vectorize?**

Gebruik [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) wanneer alle tekst onafhankelijk van lettertypen moet zijn. Gebruik [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/svgexternalfontshandling/) wanneer alleen tekst die externe lettertypen gebruikt moet worden omgezet naar graphics.

**Wat is de beste manier om een SVG kleiner te maken?**

Begin met het comprimeren van ingesloten afbeeldingen, het verwijderen van bijgesneden afbeeldingsgebieden, en kies voor gekoppelde lettertypebestanden wanneer de doelomgeving deze kan leveren. Test het resultaat, want een lagere afbeeldingsresolutie, lagere JPEG‑kwaliteit en gevectoriseerde tekst hebben elk verschillende afwegingen tussen kwaliteit en grootte.

**Kan ik geëxporteerde SVG‑elementen na het exporteren wijzigen?**

Ja. Wijs ID's toe via een formatteringscontroller en selecteer vervolgens de overeenkomstige SVG‑elementen in uw nabewerkings‑tool of browserscript.