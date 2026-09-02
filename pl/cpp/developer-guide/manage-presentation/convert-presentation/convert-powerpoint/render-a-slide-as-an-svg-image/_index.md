---
title: Renderowanie slajdów prezentacji jako obrazy SVG w C++
linktitle: Slajd do SVG
type: docs
weight: 50
url: /pl/cpp/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint do SVG
- prezentacja do SVG
- slajd do SVG
- PPT do SVG
- PPTX do SVG
- Opcje eksportu SVG
- Interaktywny SVG
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Eksportuj slajdy PowerPoint jako obrazy SVG w C++ i kontroluj czcionki, tekst, obrazy, identyfikatory oraz zdarzenia za pomocą Aspose.Slides."
---
## **Przegląd**

SVG jest skalowalnym formatem obrazu opartym na XML, który dobrze sprawdza się w publikacji internetowej, przeglądarkach slajdów, przepływach pracy związanych z dostępnością oraz automatycznym przetwarzaniu końcowemu. Aspose.Slides for C++ eksportuje każdy slajd do osobnego pliku SVG i pozwala kontrolować, w jaki sposób zapisywany jest tekst, czcionki, obrazy i elementy SVG.

Użyj [SVGOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/svgoptions/) gdy wyeksportowany SVG musi być kompaktowy, przewidywalny w różnych przeglądarkach lub gotowy do interaktywnego użycia.

## **Eksport slajdu jako SVG**

Utwórz [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/), wybierz slajd i zapisz go do strumienia. Poniższy przykład eksportuje każdy slajd prezentacji jako osobny plik SVG.

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

Nazwa pliku używa [ISlide::get_SlideNumber](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islide/get_slidenumber/) zamiast indeksu pętli. Możesz także wyeksportować pojedynczy kształt za pomocą [IShape::WriteAsSvg](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishape/writeassvg/), gdy przeglądarka slajdów lub strona internetowa potrzebuje tylko tego kształtu.

## **Konfiguracja wyjścia SVG**

[SVGOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/svgoptions/) kontroluje renderowanie SVG. Dla ramek tekstowych, [SVGOptions::set_UseFrameSize](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/svgoptions/set_useframesize/) uwzględnia ramkę tekstu w obszarze renderowania, a [SVGOptions::set_UseFrameRotation](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/svgoptions/set_useframerotation/) określa, czy rotacja ramki jest stosowana. Ustaw [SVGOptions::set_DisableFontLigatures](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/svgoptions/set_disablefontligatures/) na `true`, gdy tekst ma być renderowany bez ligatur.

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

## **Kontrola tekstu i czcionek**

### **Wektoryzacja całego tekstu**

Ustaw [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) na `true`, aby zapisać cały tekst slajdu jako grafikę wektorową. Dzięki temu usuwa się zależności od czcionek i uzyskuje bardziej spójny wizualnie rezultat w różnych przeglądarkach, ale tekst nie jest już możliwy do zaznaczenia ani wyszukiwania jako tekst SVG.

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

### **Wybierz sposób obsługi czcionek zewnętrznych**

[SVGOptions::set_ExternalFontsHandling](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/svgoptions/set_externalfontshandling/) używa wartości [SvgExternalFontsHandling](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/svgexternalfontshandling/) dla czcionek ładowanych zewnętrznie. Wybierz `AddLinksToFontFiles`, aby odwoływać się do osobnych plików czcionek, `Embed`, aby dołączyć dane czcionki do SVG, lub `Vectorize`, aby renderować tylko tekst używający czcionek zewnętrznych jako grafikę. Zweryfikuj licencję czcionek przed ich osadzeniem.

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

## **Zmniejsz rozmiar osadzonych obrazów**

Użyj [SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/svgoptions/set_picturescompression/), aby zmniejszyć rozdzielczość osadzonych obrazów, [SVGOptions::set_DeletePicturesCroppedAreas](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/svgoptions/set_deletepicturescroppedareas/), aby pominąć przycięte fragmenty źródłowe, oraz [SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/svgoptions/set_jpegquality/), aby kontrolować jakość kodowania JPEG. Te ustawienia zmniejszają rozmiar pliku kosztem jakości obrazu lub zachowanych danych obrazu.

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

## **Przypisywanie stabilnych identyfikatorów do kształtów i tekstu**

Użyj [ISvgShapeFormattingController](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/isvgshapeformattingcontroller/), aby ustawić [ISvgShape::set_Id](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/isvgshape/set_id/) dla każdego kształtu SVG. Aby również ustawić wartości [ISvgTSpan::set_Id](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/isvgtspan/set_id/) na elementach tekstowych `tspan`, zaimplementuj [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/isvgshapeandtextformattingcontroller/). Przypisz dowolny kontroler za pomocą [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/).

Poniższy kontroler używa [IShape::get_OfficeInteropShapeId](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishape/get_officeinteropshapeid/), który jest stabilny przez cały okres życia kształtu, oraz powtarzalnego licznika dla jego fragmentów tekstu. Dzięki temu generowane identyfikatory są odpowiednie do przetwarzania pośredniego niezmienionej prezentacji.

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

## **Dodawanie obsługi zdarzeń SVG**

W [ISvgShapeFormattingController](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/isvgshapeformattingcontroller/) wywołaj [ISvgShape::SetEventHandler](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/isvgshape/seteventhandler/) z wartością [SvgEvent](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/svgevent/), aby dodać obsługę zdarzenia JavaScript do wyeksportowanego kształtu. Przypisz kontroler za pomocą [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/) i zdefiniuj funkcję JavaScript na stronie lub w dokumencie SVG, który hostuje wynik.

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

Strona hostująca może zdefiniować funkcję JavaScript odwoływaną przez obsługę zdarzenia. Przypisywanie identyfikatorów i obsług zdarzeń umożliwia przeglądarki slajdów, ulepszenia dostępności oraz inne interaktywne przepływy pracy z SVG.

## **FAQ**

**Kiedy powinienem używać [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) zamiast [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/svgexternalfontshandling/)?**

Użyj [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/svgoptions/set_vectorizetext/), gdy cały tekst musi być niezależny od czcionek. Użyj [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/svgexternalfontshandling/), gdy tylko tekst korzystający z czcionek zewnętrznych powinien zostać przekonwertowany na grafikę.

**Jaki jest najlepszy sposób, aby zmniejszyć rozmiar SVG?**

Zacznij od kompresji osadzonych obrazów, usunięcia przyciętych obszarów obrazów oraz wyboru połączonych plików czcionek, gdy środowisko docelowe może je udostępniać. Przetestuj wynik, ponieważ niższa rozdzielczość obrazu, niższa jakość JPEG i wektoryzowany tekst mają różne kompromisy między jakością a rozmiarem.

**Czy mogę modyfikować wyeksportowane elementy SVG po ich wyeksportowaniu?**

Tak. Przypisz identyfikatory za pomocą kontrolera formatowania, a następnie wybierz pasujące elementy SVG w swoim narzędziu do post‑processingu lub skrypcie przeglądarki.