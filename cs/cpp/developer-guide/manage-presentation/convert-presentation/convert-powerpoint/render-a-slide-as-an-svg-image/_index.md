---
title: Vykreslit snímky prezentace jako SVG obrázky v C++
linktitle: Snímek do SVG
type: docs
weight: 50
url: /cs/cpp/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint do SVG
- prezentace do SVG
- snímek do SVG
- PPT do SVG
- PPTX do SVG
- Možnosti exportu SVG
- interaktivní SVG
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Exportujte snímky PowerPointu jako SVG obrázky v C++ a ovládejte písma, text, obrázky, ID a události pomocí Aspose.Slides."
---
## **Přehled**

SVG je škálovatelný formát obrázků založený na XML, který se dobře hodí pro webové publikování, prohlížeče snímků, workflow přístupnosti a automatické následné zpracování. Aspose.Slides pro C++ exportuje každý snímek do samostatného souboru SVG a umožňuje řídit, jak jsou zapisovány text, písma, obrázky a SVG prvky.

Použijte [SVGOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/svgoptions/) když exportovaný SVG musí být kompaktní, předvídatelný napříč prohlížeči nebo připravený pro interaktivní použití.

## **Exportovat snímek jako SVG**

Vytvořte [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/), vyberte snímek a zapište jej do proudu. Následující příklad exportuje každý snímek v prezentaci do samostatného souboru SVG.

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

Název souboru používá [ISlide::get_SlideNumber](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islide/get_slidenumber/) místo indexu smyčky. Můžete také exportovat jednotlivý tvar pomocí [IShape::WriteAsSvg](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/writeassvg/), pokud prohlížeč snímků nebo webová stránka potřebuje jen tento tvar.

## **Konfigurovat výstup SVG**

[SVGOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/svgoptions/) řídí vykreslování SVG. Pro textové rámečky [SVGOptions::set_UseFrameSize](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/svgoptions/set_useframesize/) zahrnuje textový rámec do vykreslovací oblasti a [SVGOptions::set_UseFrameRotation](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/svgoptions/set_useframerotation/) určuje, zda je aplikována rotace rámce. Nastavte [SVGOptions::set_DisableFontLigatures](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/svgoptions/set_disablefontligatures/) na `true`, pokud musí být text vykreslen bez ligatur.

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

## **Řídit text a písma**

### **Vektorizovat celý text**

Nastavte [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) na `true`, aby byl celý text snímku zapsán jako vektorová grafika. Tím se odstraní závislosti na fontech a vizuální výsledek bude konzistentnější napříč prohlížeči, ale text již nebude možné vybírat ani vyhledávat jako SVG text.

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

### **Zvolit, jak jsou zpracovávána externí písma**

[SVGOptions::set_ExternalFontsHandling](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/svgoptions/set_externalfontshandling/) používá hodnotu [SvgExternalFontsHandling](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/svgexternalfontshandling/) pro písma načítaná externě. Zvolte `AddLinksToFontFiles` pro odkaz na samostatné soubory písem, `Embed` pro zahrnutí dat písma do SVG, nebo `Vectorize` pro vykreslení pouze textu používajícího externí písma jako grafiky. Před vložením písem ověřte licenční podmínky.

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

## **Snížit velikost vložených obrázků**

Použijte [SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/svgoptions/set_picturescompression/) ke snížení rozlišení vložených obrázků, [SVGOptions::set_DeletePicturesCroppedAreas](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/svgoptions/set_deletepicturescroppedareas/) k vynechání oříznutých částí zdrojových obrázků a [SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/svgoptions/set_jpegquality/) ke kontrole kvality kódování JPEG. Tato nastavení snižují velikost souboru na úkor věrnosti obrazu nebo zachovaných dat obrázku.

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

## **Přiřadit stabilní ID tvarům a textu**

Použijte [ISvgShapeFormattingController](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/isvgshapeformattingcontroller/) k nastavení [ISvgShape::set_Id](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/isvgshape/set_id/) pro každý SVG tvar. Pro nastavení hodnot [ISvgTSpan::set_Id](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/isvgtspan/set_id/) na elementech textu `tspan` implementujte [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/isvgshapeandtextformattingcontroller/). Přiřaďte kterýkoli řadič pomocí [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/).

Následující řadič používá [IShape::get_OfficeInteropShapeId](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/get_officeinteropshapeid/), který je stabilní po celou životnost tvaru, a opakovatelný čítač pro jeho textové rozpětí. To dělá vygenerovaná ID vhodná pro následné zpracování nezměněné prezentace.

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

## **Přidat SVG manipulátory událostí**

V [ISvgShapeFormattingController](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/isvgshapeformattingcontroller/) zavolejte [ISvgShape::SetEventHandler](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/isvgshape/seteventhandler/) s hodnotou [SvgEvent](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/svgevent/) pro přidání JavaScriptového manipulátoru události k exportovanému tvaru. Přiřaďte řadič pomocí [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/) a definujte JavaScriptovou funkci na stránce nebo v SVG dokumentu, který výsledek hostí.

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

Hostitelská stránka může definovat JavaScriptovou funkci odkazovanou manipulátorem. Přiřazení ID a manipulátorů událostí umožňuje prohlížeče snímků, vylepšení přístupnosti a další interaktivní SVG workflow.

## **Často kladené otázky**

**Kdy mám použít [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) místo [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/svgexternalfontshandling/)?**

Použijte [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/svgoptions/set_vectorizetext/), pokud musí být celý text nezávislý na fontech. Použijte [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/svgexternalfontshandling/), pokud má být do grafiky převeden pouze text používající externí písma.

**Jaký je nejlepší způsob, jak zmenšit SVG?**

Začněte kompresí vložených obrázků, odstraněním oříznutých částí obrazu a volbou odkazovaných souborů písem, pokud je cílové prostředí schopno je poskytovat. Otestujte výsledek, protože nižší rozlišení obrázku, nižší kvalita JPEG a vektorizovaný text mají různé kompromisy mezi kvalitou a velikostí.

**Mohu po exportu upravit exportované SVG elementy?**

Ano. Přidělte ID pomocí řadiče formátování a poté vyberte odpovídající SVG elementy ve svém nástroji pro následné zpracování nebo ve skriptu prohlížeče.