---
title: Rendera presentationsbilder som SVG-bilder i C++
linktitle: Bild till SVG
type: docs
weight: 50
url: /sv/cpp/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint till SVG
- presentation till SVG
- bild till SVG
- PPT till SVG
- PPTX till SVG
- SVG-exportalternativ
- interaktiv SVG
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Exportera PowerPoint-bilder som SVG-bilder i C++ och kontrollera teckensnitt, text, bilder, ID:n och händelser med Aspose.Slides."
---
## **Översikt**

SVG är ett skalbart XML-baserat bildformat som fungerar bra för webbpublicering, bildspelsvisare, tillgänglighetsarbetsflöden och automatiserad efterbehandling. Aspose.Slides för C++ exporterar varje bild till en separat SVG-fil och låter dig kontrollera hur text, teckensnitt, bilder och SVG-element skrivs.

Använd [SVGOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/svgoptions/) när den exporterade SVG-filen måste vara kompakt, förutsägbar i olika webbläsare eller redo för interaktiv användning.

## **Exportera en bild som SVG**

Skapa en [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/), välj en bild och skriv den till en ström. Följande exempel exporterar varje bild i en presentation som en separat SVG-fil.

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

Filnamnet använder [ISlide::get_SlideNumber](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islide/get_slidenumber/) snarare än loopindexet. Du kan också exportera en enskild form med [IShape::WriteAsSvg](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/writeassvg/) när en bildvisare eller webbsida bara behöver den formen.

## **Konfigurera SVG-utdata**

[SVGOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/svgoptions/) styr SVG-renderingen. För textramar inkluderar [SVGOptions::set_UseFrameSize](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/svgoptions/set_useframesize/) textramen i renderingsområdet, och [SVGOptions::set_UseFrameRotation](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/svgoptions/set_useframerotation/) bestämmer om ramrotationen tillämpas. Ställ in [SVGOptions::set_DisableFontLigatures](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/svgoptions/set_disablefontligatures/) till `true` när text måste renderas utan ligaturer.

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

## **Kontrollera text och teckensnitt**

### **Vektoriserar all text**

Ställ in [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) till `true` för att skriva all bildtext som vektorgrafik. Detta eliminerar teckensnittberoenden och gör det visuella resultatet mer enhetligt i olika webbläsare, men texten blir inte längre markerbar eller sökbar som SVG-text.

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

### **Välj hur externa teckensnitt hanteras**

[SVGOptions::set_ExternalFontsHandling](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/svgoptions/set_externalfontshandling/) använder ett [SvgExternalFontsHandling](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/svgexternalfontshandling/)-värde för teckensnitt som laddas externt. Välj `AddLinksToFontFiles` för att referera separata teckensnittsfiler, `Embed` för att inkludera teckensnittsdatan i SVG-filen, eller `Vectorize` för att rendera endast text som använder externa teckensnitt som grafik. Verifiera teckensnittens licensiering innan du bäddar in teckensnitt.

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

## **Minska inbäddad bildstorlek**

Använd [SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/svgoptions/set_picturescompression/) för att minska upplösningen på inbäddade bilder, [SVGOptions::set_DeletePicturesCroppedAreas](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/svgoptions/set_deletepicturescroppedareas/) för att utesluta beskurna källområden, och [SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/svgoptions/set_jpegquality/) för att kontrollera JPEG-kodningskvaliteten. Dessa inställningar minskar filstorleken på bekostnad av bildkvalitet eller bevarad bilddata.

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

## **Tilldela stabila ID:n till former och text**

Använd [ISvgShapeFormattingController](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/isvgshapeformattingcontroller/) för att ange [ISvgShape::set_Id](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/isvgshape/set_id/) för varje SVG-form. För att även ange [ISvgTSpan::set_Id](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/isvgtspan/set_id/)‑värden på text‑`tspan`‑element, implementera [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/isvgshapeandtextformattingcontroller/). Tilldela någon av kontrollerna med [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/).

Följande kontrollör använder [IShape::get_OfficeInteropShapeId](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/get_officeinteropshapeid/), vilket är stabilt under formens livstid, och en repeterbar räknare för dess text‑spans. Detta gör de genererade ID:n lämpliga för efterbehandling av en oförändrad presentation.

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

## **Lägg till SVG‑händelsehanterare**

I en [ISvgShapeFormattingController](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/isvgshapeformattingcontroller/), anropa [ISvgShape::SetEventHandler](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/isvgshape/seteventhandler/) med ett [SvgEvent](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/svgevent/)-värde för att lägga till en JavaScript‑händelsehanterare till en exporterad form. Tilldela kontrollören med [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/) och definiera JavaScript‑funktionen i sidan eller SVG‑dokumentet som innehåller resultatet.

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

Värdsidan kan definiera JavaScript‑funktionen som refereras av hanteraren. Tilldelning av ID:n och händelsehanterare möjliggör bildvisare, tillgänglighetsförbättringar och andra interaktiva SVG‑arbetsflöden.

## **FAQ**

**När bör jag använda [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) istället för [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/svgexternalfontshandling/)?**

Använd [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) när all text måste vara oberoende av teckensnitt. Använd [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/svgexternalfontshandling/) när endast text som använder externa teckensnitt ska konverteras till grafik.

**Vad är det bästa sättet att göra en SVG mindre?**

Börja med att komprimera inbäddade bilder, ta bort beskurna bildområden och välja länkade teckensnittsfiler när målmiljön kan leverera dem. Testa resultatet eftersom lägre bildupplösning, lägre JPEG‑kvalitet och vektoriserad text alla har olika kvalitets‑ och storleksavvägningar.

**Kan jag ändra exporterade SVG‑element efter export?**

Ja. Tilldela ID:n via en formateringskontrollör och välj sedan de matchande SVG‑elementen i ditt efterbehandlingsverktyg eller browserskript.