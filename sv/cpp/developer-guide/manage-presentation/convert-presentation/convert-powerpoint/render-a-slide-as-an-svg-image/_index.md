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

SVG är ett skalbart XML‑baserat bildformat som fungerar bra för webbutgivning, bildspelsvisare, tillgänglighetsarbetsflöden och automatiserad efterbehandling. Aspose.Slides för C++ exporterar varje bildruta till en separat SVG‑fil och låter dig styra hur text, teckensnitt, bilder och SVG‑element skrivs.

Använd [SVGOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/) när den exporterade SVG‑filen måste vara kompakt, förutsägbar i olika webbläsare eller klar för interaktiv användning.

## **Exportera en bildruta som SVG**

Skapa en [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/), välj en bildruta och skriv den till en ström. Följande exempel exporterar varje bildruta i en presentation till en separat SVG‑fil.

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

Filnamnet använder [ISlide::get_SlideNumber](https://reference.aspose.com/slides/cpp/aspose.slides/islide/get_slidenumber/) i stället för loop‑indexet. Du kan också exportera en enskild form med [IShape::WriteAsSvg](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/writeassvg/) när en bildspelsvisare eller webbsida endast behöver den formen.

## **Konfigurera SVG-utdata**

[SVGOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/) styr SVG‑renderingen. För textramar inkluderar [SVGOptions::set_UseFrameSize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_useframesize/) textramen i renderingsområdet, och [SVGOptions::set_UseFrameRotation](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_useframerotation/) bestämmer om ramrotationen tillämpas. Sätt [SVGOptions::set_DisableFontLigatures](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_disablefontligatures/) till `true` när text måste renderas utan ligaturer.

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

## **Kontrollera beskärning av linjeändar vid pilspetsar**

SVG 1.1 har ingen marker‑inset‑inställning för att ange var en linje ska sluta under en pilspets. Som standard förkortar Aspose.Slides den exporterade linjen så att dess penseldrag inte sticker igenom markören. Sätt [SVGOptions::set_DisableLineEndCropping](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_disablelineendcropping/) till `true` för att rita penseldraget hela vägen till linjens ursprungliga slutpunkt. Denna inställning påverkar endast SVG‑utdata. Linjen behåller sin position och längd på bildrutan.

Exemplet ritar triangel‑ och diamantpilspetsar på linjer 2 och 10 punkts breda. Det exporterar samma bildruta två gånger och ändrar bara beskärningsalternativet.

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

Jämförelsen visar den triangulära pilspetsen på 10‑punktslinjen. Med beskärning aktiverad är spetsen skarp. Med beskärning inaktiverad sticker penseldraget igenom de lutande sidorna av markören och lämnar ett platt slut.

![Enlarged 10-point triangle with a sharp tip when cropping is enabled and a flat end when cropping is disabled](line-end-cropping.png)

I de andra linjerna i exemplet är det utskjutande penseldraget mindre synligt på 2‑punktstriangeln. Den fyllda diamanten täcker penseldragets slut vid båda breddarna.

## **Kontrollera text och teckensnitt**

När du exporterar bildrutor till SVG kan du styra om text ska förbli text eller konverteras till vektorgrafik samt hur externa teckensnitt inkluderas eller refereras. Följande alternativ hjälper dig att balansera visuell konsistens, textval och teckensnittsberoenden i den exporterade SVG‑filen.

### **Vektorisera all text**

Sätt [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) till `true` för att skriva all bildruttstext som vektorgrafik. Detta eliminerar teckensnittsberoenden och gör det visuella resultatet mer enhetligt i olika webbläsare, men texten är inte längre valbar eller sökbar som SVG‑text.

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

[SVGOptions::set_ExternalFontsHandling](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_externalfontshandling/) använder ett [SvgExternalFontsHandling](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/)‑värde för teckensnitt som laddas externt. Välj `AddLinksToFontFiles` för att referera separata teckensnittsfiler, `Embed` för att inkludera teckensnittsdata i SVG‑filen, eller `Vectorize` för att rendera endast den text som använder externa teckensnitt som grafik. Verifiera teckensnittslicensen innan du bäddar in teckensnitt.

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

## **Reducera storlek på inbäddade bilder**

Använd [SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_picturescompression/) för att minska upplösningen på inbäddade bilder, [SVGOptions::set_DeletePicturesCroppedAreas](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_deletepicturescroppedareas/) för att utelämna beskurna källområden och [SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_jpegquality/) för att styra JPEG‑kodningskvalitet. Dessa inställningar minskar filstorleken på bekostnad av bildkvalitet eller bevarad bilddata.

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

## **Kontrollera rasteriseringsupplösning för metafiler**

[SVGOptions::set_MetafileRasterizationDpi](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_metafilerasterizationdpi/) anger den lägre upplösningsgränsen för rasterisering av metafiler under SVG‑export. Använd den för att balansera detaljrikedom och filstorlek när en EMF‑ eller WMF‑bild rasteriseras. Den definierar inte ett globalt DPI för SVG‑filen eller tvingar varje objekt på bildrutan att bli en rasterbild.

Ladda ner [metafile-rasterization.pptx](metafile-rasterization.pptx), som innehåller en EMF‑bild med tätt placerade diagonala linjer. Följande exempel exporterar dess första bildruta med tre rasteriseringsupplösningar via [ISlide::WriteAsSvg](https://reference.aspose.com/slides/cpp/aspose.slides/islide/writeassvg/). Alla andra exportinställningar förblir identiska så att resultaten kan jämföras.

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

I resultatet blev EMF‑filen en inbäddad PNG i varje SVG. Följande mått gäller den medföljande presentationen; de är inte en generell formel för att konvertera DPI till pixelmått.

| Metafilerasteriserings‑DPI | Inbäddade PNG‑dimensioner | SVG‑filstorlek (bytes) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Jämförelsen nedan visar samma område av den inbäddade rasterbilden i samma förstora visningsstorlek. De diagonala linjerna visar synlig pixelering vid 72 DPI och jämnare kanter vid högre upplösningar, samtidigt som SVG‑filen växer. Att öka värdet förbättrar inte nödvändigtvis varje detalj eller förändrar varje exporterad bild.

![Enlarged diagonal-line detail at 72, 150, and 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_picturescompression/) styr bildupplösningsreducering och kan maskera effekten av att ändra rasteriseringsupplösningen för metafiler. [SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_jpegquality/) styr JPEG‑kodningskvalitet, inte rasteriseringsupplösning för metafiler.

## **Tilldela stabila ID:n till former och text**

Använd [ISvgShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeformattingcontroller/) för att sätta [ISvgShape::set_Id](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshape/set_id/) för varje SVG‑form. För att också sätta [ISvgTSpan::set_Id](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgtspan/set_id/) på text‑`tspan`‑element, implementera [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeandtextformattingcontroller/). Tilldela någon av kontrollerna med [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/).

Följande controller använder [IShape::get_OfficeInteropShapeId](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_officeinteropshapeid/), som är stabilt under formens livstid, och en återupprepningsbar räknare för dess textsprång. Detta gör de genererade ID:n lämpliga för efterbehandling av en oförändrad presentation.

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

I en [ISvgShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeformattingcontroller/) anropar du [ISvgShape::SetEventHandler](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshape/seteventhandler/) med ett [SvgEvent](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgevent/)‑värde för att lägga till en JavaScript‑händelsehanterare till en exporterad form. Tilldela controllern med [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/) och definiera JavaScript‑funktionen i sidan eller SVG‑dokumentet som är värd för resultatet.

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

Värdsidan kan definiera JavaScript‑funktionen som refereras av hanteraren. Att tilldela ID:n och händelsehanterare möjliggör bildspelsvisare, tillgänglighetsförbättringar och andra interaktiva SVG‑arbetsflöden.

## **Vanliga frågor**

**När bör jag använda [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) i stället för [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/)?**

Använd [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) när all text måste vara oberoende av teckensnitt. Använd [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/) när endast den text som använder externa teckensnitt ska konverteras till grafik.

**Vad är det bästa sättet att göra en SVG mindre?**

Börja med att komprimera inbäddade bilder, ta bort beskurna bildområden och välja länkade teckensnittsfiler när målmiljön kan servera dem. Testa resultatet eftersom lägre bildupplösning, lägre JPEG‑kvalitet och vektorisering av text alla har olika kvalitet‑ och storhetsavvägningar.

**Kan jag modifiera exporterade SVG‑element efter export?**

Ja. Tilldela ID:n via en formateringscontroller, välj sedan motsvarande SVG‑element i ditt efterbehandlingsverktyg eller browserskript.