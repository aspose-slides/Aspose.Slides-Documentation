---
title: Převést snímky PowerPoint do PNG v C++
linktitle: PowerPoint na PNG
type: docs
weight: 30
url: /cs/cpp/convert-powerpoint-to-png/
keywords:
- převést PowerPoint
- převést prezentaci
- převést snímek
- převést PPT
- převést PPTX
- PowerPoint na PNG
- prezentace na PNG
- snímek na PNG
- PPT na PNG
- PPTX na PNG
- uložit PPT jako PNG
- uložit PPTX jako PNG
- exportovat PPT do PNG
- exportovat PPTX do PNG
- C++
- Aspose.Slides
description: "Převést prezentace PowerPoint na vysoce kvalitní PNG obrázky rychle pomocí Aspose.Slides pro C++, což zajišťuje přesné a automatizované výsledky."
---
## **Přehled**

Tento článek vysvětluje, jak převést snímky prezentace na obrázky PNG pomocí Aspose.Slides pro C++. Můžete načíst prezentace ve formátech jako PPT, PPTX a ODP, vykreslit každý snímek a uložit jej jako samostatný PNG obrázek.

Níže uvedené příklady ukazují vykreslování v výchozím měřítku, zvýšení měřítka, určení výstupních rozměrů v pixelech a výběr stylu vykreslování gradientu.

## **Převést PowerPoint na PNG**

Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) a přistupujte k jejím snímkům přes přístupový prvek [Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/). Příklad vykresluje každý snímek pomocí [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) bez parametrů pro vytvoření miniatury. Poté volá [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) s [ImageFormat::Png](https://reference.aspose.com/slides/cpp/aspose.slides/imageformat/) pro uložení každého vykresleného snímku jako PNG obrázku.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage();
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Přetížení [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) bez parametrů vykresluje v měřítku 0,2. Například snímek o velikosti 720 × 540 bodů vytvoří miniaturu 144 × 108 pixelů. Pro řízení výstupních rozměrů použijte přetížení se škálovacími faktory nebo explicitní velikostí obrázku uvedenou níže.
{{% /alert %}}

## **Převést PowerPoint na PNG se vlastními rozměry**

Předávejte horizontální a vertikální škálovací faktory metodě [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) pro řízení vykreslených rozměrů. V tomto příkladu jsou oba faktory 2, takže snímek o velikosti 720 × 540 bodů vytvoří obrázek 1440 × 1080 pixelů. Stejné faktory zachovají poměr stran snímku. Každý obrázek je uložen ve formátu PNG pomocí [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/).

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto scaleX = 2.f;
auto scaleY = scaleX;

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(scaleX, scaleY);
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

## **Převést PowerPoint na PNG s vlastní velikostí**

Pro určení výstupních rozměrů v pixelech předávejte velikost metodě [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) místo škálovacích faktorů. Tento příklad vykresluje každý snímek v 960 × 720 pixelech a ukládá výsledek pomocí [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/). Zvolte rozměry, které odpovídají poměru stran snímku, aby nedošlo k roztažení obrázku.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>
#include <drawing/size.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto imageSize = System::Drawing::Size(960, 720);

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(imageSize);
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

## **Zvolte styl vykreslování gradientu**

Předpokládejme, že snímek obsahuje výplně gradienty, ale přechody v exportovaném PNG vypadají světleji nebo jinak než v PowerPointu. Můžete použít metodu [SaveOptions::set_GradientStyle](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_gradientstyle/) třídy [RenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/renderingoptions/) pro výběr způsobu vykreslování gradientů.

Stáhněte [gradient-styles.pptx](gradient-styles.pptx) a umístěte jej do pracovního adresáře aplikace. Jeho první snímek obsahuje dva lineární gradienty: azurový k oranžové nahoře a modrý k žluté dole. Každý gradient má dvě zastávky, při 0 % a 100 %.

Následující příklad načte tuto prezentaci a vykreslí první snímek v obou režimech pomocí [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/).

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>
#include <DOM/GradientStyle.h>
#include <Export/RenderingOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"gradient-styles.pptx");
auto slide = presentation->get_Slide(0);

auto gradientStyles = { GradientStyle::Default, GradientStyle::PowerPointUI };
for (auto style : gradientStyles)
{
    auto options = MakeObject<RenderingOptions>();
    options->set_GradientStyle(style);

    auto image = slide->GetImage(options, 1.f, 1.f);
    auto styleName = style == GradientStyle::Default ? u"Default" : u"PowerPointUI";
    image->Save(String::Format(u"gradient-{0}.png", styleName), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

Obrázky níže zobrazují výstup ze stejného snímku s oběma gradienty v každém obrázku:

| Default | PowerPointUI |
| --- | --- |
| ![Cyan-to-orange and blue-to-yellow gradients rendered with Default](gradient-Default.png) | ![The same gradients rendered with PowerPointUI](gradient-PowerPointUI.png) |

V tomto příkladu `Default` produkuje světlejší mezilehlé barvy, zatímco `PowerPointUI` produkuje tmavší mezilehlé barvy. Rozdíl závisí na barvách a zastávkách gradientu.

Zvolte `Default`, pokud vám vyhovuje standardní výstup Aspose.Slides. Vyzkoušejte `PowerPointUI`, pokud je vaší prioritou shoda vzhledu s PowerPointem. Porovnejte oba výstupy s požadovaným výsledkem; žádný režim není obecně upřednostňován.

## **FAQ**

**Jak mohu exportovat konkrétní tvar, například graf nebo obrázek, místo celého snímku?**

Aspose.Slides podporuje [generování miniatur pro jednotlivé tvary](/slides/cs/cpp/shape-thumbnails/), což vám umožní vykreslit tvar jako PNG obrázek.

**Je paralelní převod podporován na serveru?**

Ano. Používejte samostatnou instanci prezentace pro každý vláken nebo proces; [nesdílejte jednu instanci napříč vlákny](/slides/cs/cpp/multithreading/).

**Jaká jsou omezení evaluačního režimu při exportu do PNG?**

Evaluační režim přidává vodoznak do výstupních obrázků a aplikuje [další omezení](/slides/cs/cpp/licensing/) dokud není licence aplikována.