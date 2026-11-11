---
title: Renderovat snímky prezentace jako SVG obrázky v C++
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
description: "Exportujte snímky PowerPoint jako SVG obrázky v C++ a ovládejte písma, text, obrázky, ID a události pomocí Aspose.Slides."
---
## **Přehled**

SVG je škálovatelný formát obrázků založený na XML, který dobře funguje pro webové publikování, prohlížeče snímků, pracovní postupy přístupnosti a automatické následné zpracování. Aspose.Slides pro C++ exportuje každý snímek do samostatného souboru SVG a umožňuje řídit, jak jsou zapisovány text, písma, obrázky a elementy SVG.

Použijte [SVGOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/) když exportovaný SVG musí být kompaktní, předvídatelný napříč prohlížeči nebo připravený pro interaktivní použití.

## **Export snímku jako SVG**

Vytvořte [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/), vyberte snímek a zapište jej do streamu. Následující příklad exportuje každý snímek v prezentaci do samostatného souboru SVG.

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

Název souboru používá [ISlide::get_SlideNumber](https://reference.aspose.com/slides/cpp/aspose.slides/islide/get_slidenumber/) místo indexu smyčky. Můžete také exportovat jednotlivý tvar pomocí [IShape::WriteAsSvg](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/writeassvg/), pokud prohlížeč snímků nebo webová stránka potřebuje pouze tento tvar.

## **Konfigurace výstupu SVG**

[SVGOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/) řídí vykreslování SVG. Pro textové rámce [SVGOptions::set_UseFrameSize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_useframesize/) zahrnuje textový rámec do oblasti vykreslování a [SVGOptions::set_UseFrameRotation](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_useframerotation/) určuje, zda se použije rotace rámce. Nastavte [SVGOptions::set_DisableFontLigatures](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_disablefontligatures/) na `true`, když text musí být vykreslen bez ligatur.

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

## **Řízení oříznutí konců čar u šipek**

SVG 1.1 nemá nastavení vnitřního posunu markeru, které by určovalo, kde má čára končit pod šipkou. Ve výchozím nastavení Aspose.Slides zkracuje exportovanou čáru, aby její tah nevyčníval skrz marker. Nastavte [SVGOptions::set_DisableLineEndCropping](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_disablelineendcropping/) na `true`, aby se tah kreslil až po původní koncový bod čáry. Toto nastavení ovlivňuje pouze výstup SVG. Čára si zachovává svou pozici a délku na snímku.

Příklad vykresluje trojúhelníkové a diamantové šipky na čarách o šířce 2 a 10 bodů. Exportuje stejný snímek dvakrát, mění jen možnost oříznutí.

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

Srovnání ukazuje trojúhelníkovou šipku na 10bodové čáře. Při zapnutém oříznutí je špička ostrá. Při vypnutém oříznutí tah vyčnívá skrz nakloněné strany markeru a zanechává plochý konec.

![Zvětšený 10bodový trojúhelník s ostrým hrotem při zapnutém oříznutí a plochým koncem při vypnutém oříznutí](line-end-cropping.png)

V ostatních čarách z příkladu je vyčnívající tah méně viditelný na 2bodovém trojúhelníku. Vyplněný diamant zakrývá konec tahu v obou šířkách.

## **Řízení textu a písem**

Při exportu snímků do SVG můžete řídit, zda text zůstane jako text, nebo bude převeden na vektorovou grafiku, a jak jsou zahrnuta nebo odkazována externí písma. Následující možnosti vám pomohou vyvážit vizuální konzistenci, možnost výběru textu a závislosti na písměch v exportovaném SVG.

### **Vektorizovat celý text**

Nastavte [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) na `true`, aby byl veškerý text snímku zapsán jako vektorová grafika. Tím se odstraní závislost na písmu a výsledek bude vizuálně konzistentnější napříč prohlížeči, ale text již nebude možné vybírat ani vyhledávat jako SVG text.

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

### **Zvolte, jak zacházet s externími písmy**

[SVGOptions::set_ExternalFontsHandling](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_externalfontshandling/) používá hodnotu [SvgExternalFontsHandling](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/) pro písma načítaná externě. Zvolte `AddLinksToFontFiles` pro odkazování na samostatné soubory písem, `Embed` pro zahrnutí dat písma do SVG, nebo `Vectorize` pro vykreslení pouze textu používajícího externí písma jako grafiky. Před vložením písem ověřte licenční podmínky.

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

## **Snížení velikosti vložených obrázků**

Použijte [SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_picturescompression/) ke snížení rozlišení vložených obrázků, [SVGOptions::set_DeletePicturesCroppedAreas](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_deletepicturescroppedareas/) k vynechání oříznutých částí zdrojových oblastí a [SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_jpegquality/) k řízení kvality JPEG kódování. Tato nastavení snižují velikost souboru na úkor kvality obrazu nebo zachování dat obrázku.

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

## **Řízení rozlišení rasterizace metafile**

[SVGOptions::set_MetafileRasterizationDpi](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_metafilerasterizationdpi/) nastavuje dolní limit rozlišení při rasterizaci metafile během exportu SVG. Použijte jej k vyvážení detailu a velikosti souboru, když je EMF nebo WMF obrázek rasterizován. Nedefinuje globální DPI pro SVG ani nevyžaduje, aby každý objekt na snímku se stal rastrovým obrázkem.

Stáhněte si [metafile-rasterization.pptx](metafile-rasterization.pptx), který obsahuje EMF obrázek s úzce umístěnými diagonálními čarami. Následující příklad exportuje jeho první snímek ve třech rozlišeních rasterizace pomocí [ISlide::WriteAsSvg](https://reference.aspose.com/slides/cpp/aspose.slides/islide/writeassvg/). Všechna ostatní nastavení exportu zůstávají stejná, aby bylo možné výsledky porovnat.

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

Ve výstupu se EMF stal jedním vloženým PNG v každém SVG. Následující měření jsou pro dodanou prezentaci; nejsou obecnou formulí pro převod DPI na rozměry v pixelech.

| Rasterizace metafile DPI | Rozměry vloženého PNG | Velikost souboru SVG (bajty) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Srovnání níže ukazuje stejnou oblast vloženého rastru ve stejném zvětšeném zobrazení. Diagonální čáry vykazují viditelnou pixelaci při 72 DPI a hladší hrany při vyšších rozlišeních, zatímco velikost SVG souboru roste. Zvýšení hodnoty nutně neznamená zlepšení každého detailu nebo změnu každého exportovaného obrázku.

![Zvětšený detail diagonální čáry při 72, 150 a 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_picturescompression/) řídí snížení rozlišení obrázku a může zakrýt vliv změny rozlišení rasterizace metafile. [SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_jpegquality/) řídí kvalitu JPEG kódování, nikoli rozlišení rasterizace metafile.

## **Přiřazení stabilních ID tvarům a textu**

Použijte [ISvgShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeformattingcontroller/) k nastavení [ISvgShape::set_Id](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshape/set_id/) pro každý SVG tvar. Pro nastavení hodnot [ISvgTSpan::set_Id](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgtspan/set_id/) na textových elementech `tspan` také, implementujte [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeandtextformattingcontroller/). Přiřaďte kterýkoli z těchto kontrolerů pomocí [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/).

Následující kontroler používá [IShape::get_OfficeInteropShapeId](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_officeinteropshapeid/), který je stabilní po celou životnost tvaru, a opakovatelný čítač pro jeho textové span. Toto dělá generovaná ID vhodná pro následné zpracování nezměněné prezentace.

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

## **Přidání SVG obslužných událostí**

V [ISvgShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeformattingcontroller/) zavolejte [ISvgShape::SetEventHandler](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshape/seteventhandler/) s hodnotou [SvgEvent](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgevent/) , abyste přidali JavaScriptový obslužný události k exportovanému tvaru. Přiřaďte kontroler pomocí [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/) a definujte JavaScriptovou funkci na stránce nebo v SVG dokumentu, který výsledek hostí.

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

Hostitelská stránka může definovat JavaScriptovou funkci odkazovanou obslužným událostí. Přiřazení ID a obslužných událostí umožňuje prohlížeče snímků, vylepšení přístupnosti a další interaktivní SVG pracovní postupy.

## **FAQ**

**Kdy bych měl použít [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) místo [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/)?**

Použijte [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) když veškerý text musí být nezávislý na písměch. Použijte [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/) když má být pouze text používající externí písma převeden na grafiku.

**Jaký je nejlepší způsob, jak zmenšit SVG?**

Začněte kompresí vložených obrázků, mazáním oříznutých oblastí obrázků a volbou odkazovaných souborů písem, pokud cílové prostředí může tyto soubory poskytovat. Otestujte výsledek, protože nižší rozlišení obrázku, nižší kvalita JPEG a vektorizace textu mají různé kompromisy mezi kvalitou a velikostí.

**Mohu po exportu upravovat exportované SVG elementy?**

Ano. Přiřaďte ID pomocí formátovacího kontroleru, poté vyberte odpovídající SVG elementy ve vašem nástroji pro následné zpracování nebo skriptu v prohlížeči.