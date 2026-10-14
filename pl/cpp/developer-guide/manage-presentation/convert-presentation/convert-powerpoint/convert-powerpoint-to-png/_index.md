---
title: Konwertuj slajdy PowerPoint na PNG w C++
linktitle: PowerPoint do PNG
type: docs
weight: 30
url: /pl/cpp/convert-powerpoint-to-png/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj slajd
- konwertuj PPT
- konwertuj PPTX
- PowerPoint do PNG
- prezentacja do PNG
- slajd do PNG
- PPT do PNG
- PPTX do PNG
- zapisz PPT jako PNG
- zapisz PPTX jako PNG
- eksportuj PPT do PNG
- eksportuj PPTX do PNG
- C++
- Aspose.Slides
description: "Konwertuj prezentacje PowerPoint na wysokiej jakości obrazy PNG szybko przy użyciu Aspose.Slides dla C++, zapewniając precyzyjne, zautomatyzowane wyniki."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak konwertować slajdy prezentacji na obrazy PNG przy użyciu Aspose.Slides dla C++. Można ładować prezentacje w formatach takich jak PPT, PPTX i ODP, renderować każdy slajd i zapisywać go jako osobny obraz PNG.

Poniższe przykłady pokazują renderowanie w domyślnej skali, zwiększanie skali, określanie wymiarów wyjściowych w pikselach oraz wybór stylu renderowania gradientu.

## **Konwertuj PowerPoint do PNG**

Załaduj prezentację przy pomocy klasy [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) i uzyskaj dostęp do jej slajdów za pomocą akcesora [Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/). Przykład renderuje każdy slajd metodą [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) bez parametrów, aby utworzyć miniaturę. Następnie wywołuje [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) z [ImageFormat::Png](https://reference.aspose.com/slides/cpp/aspose.slides/imageformat/), aby zapisać każdy wyrenderowany slajd jako obraz PNG.

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
Przeciążenie [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) bez parametrów renderuje w skali 0,2. Na przykład slajd o wymiarach 720 × 540 punktów generuje miniaturę 144 × 108 pikseli. Aby kontrolować wymiary wyjściowe, użyj przeciążeń ze współczynnikami skali lub explicytnego rozmiaru obrazu, jak pokazano poniżej.
{{% /alert %}}

## **Konwertuj PowerPoint do PNG z niestandardowymi wymiarami**

Przekaż poziome i pionowe współczynniki skali do [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/), aby kontrolować wymiar renderowanego obrazu. W tym przykładzie oba współczynniki wynoszą 2, więc slajd o wymiarach 720 × 540 punktów generuje obraz 1440 × 1080 pikseli. Równe współczynniki zachowują proporcje slajdu. Każdy obraz jest zapisywany w formacie PNG przy użyciu [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/).

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

## **Konwertuj PowerPoint do PNG z niestandardowym rozmiarem**

Aby określić wymiary wyjściowe w pikselach, przekaż rozmiar do [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) zamiast współczynników skali. Ten przykład renderuje każdy slajd w rozdzielczości 960 × 720 pikseli i zapisuje wynik przy użyciu [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/). Wybierz wymiary odpowiadające proporcjom slajdu, aby uniknąć rozciągnięcia obrazu.

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

## **Wybierz styl renderowania gradientu**

Załóżmy, że slajd zawiera wypełnienia gradientowe, ale przejścia w wyeksportowanym PNG są jaśniejsze lub inaczej wyglądają niż w PowerPoint. Można użyć metody [SaveOptions::set_GradientStyle](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_gradientstyle/) klasy [RenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/renderingoptions/), aby wybrać sposób renderowania gradientów.

Pobierz plik [gradient-styles.pptx](gradient-styles.pptx) i umieść go w katalogu roboczym aplikacji. Jej pierwszy slajd zawiera dwa gradienty liniowe: od cyjanu do pomarańczy na górze oraz od niebieskiego do żółci na dole. Każdy gradient ma dwa punkty przystankowe: 0% i 100%.

Poniższy przykład ładuje tę prezentację i renderuje ten sam pierwszy slajd w obu trybach przy użyciu [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/).

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

Poniższe obrazy przedstawiają wynik z tego samego slajdu, z obu gradientami w każdym obrazie:

| Default | PowerPointUI |
| --- | --- |
| ![Gradienty od cyjanu do pomarańczy i od niebieskiego do żółci renderowane z użyciem Default](gradient-Default.png) | ![Te same gradienty renderowane z użyciem PowerPointUI](gradient-PowerPointUI.png) |

W tym przykładzie `Default` generuje jaśniejsze kolory pośrednie, natomiast `PowerPointUI` generuje ciemniejsze kolory pośrednie. Różnica zależy od kolorów i punktów przystankowych w gradiencie.

Wybierz `Default`, gdy standardowy wynik Aspose.Slides spełnia Twoje potrzeby. Wypróbuj `PowerPointUI`, gdy priorytetem jest dopasowanie wyglądu do PowerPoint. Porównaj oba wyniki z zamierzonym rezultatem; żaden tryb nie jest uniwersalnie lepszy.

## **FAQ**

**Jak mogę wyeksportować konkretny kształt, na przykład wykres lub obraz, zamiast całego slajdu?**

Aspose.Slides obsługuje [generowanie miniatur dla pojedynczych kształtów](/slides/pl/cpp/shape-thumbnails/), umożliwiając renderowanie kształtu jako obrazu PNG.

**Czy konwersja równoległa jest obsługiwana na serwerze?**

Tak. Używaj osobnej instancji prezentacji dla każdego wątku lub procesu; [nie udostępniaj jednej instancji wielokrotnie wątkom](/slides/pl/cpp/multithreading/).

**Jakie są ograniczenia wersji ewaluacyjnej przy eksportowaniu do PNG?**

Tryb ewaluacji dodaje znak wodny do wyjściowych obrazów i stosuje [inne ograniczenia](/slides/pl/cpp/licensing/), dopóki nie zostanie zastosowana licencja.