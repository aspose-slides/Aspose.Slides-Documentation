---
title: "Zarządzanie obiektami tuszu w prezentacji w C++"
linktitle: "Zarządzaj tuszem"
type: docs
weight: 95
url: /pl/cpp/manage-ink/
keywords:
- tusz
- obiekt tuszu
- ślad tuszu
- zarządzaj tuszem
- rysuj tusz
- rysowanie
- eksport tuszu
- renderowanie tuszu
- ukryj tusz
- IInkOptions
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Zarządzaj obiektami tuszu PowerPoint, edytuj ślady i właściwości pędzla oraz kontroluj wygląd tuszu podczas eksportu do PDF, HTML, SVG, TIFF i obrazów przy użyciu Aspose.Slides dla C++."
---
## **Wprowadzenie**

PowerPoint udostępnia funkcję tuszu, która pozwala na rysowanie odręcznych pociągnięć. Tusz można wykorzystać do podświetlania innych obiektów, pokazywania połączeń i procesów oraz zwracania uwagi na konkretne elementy na slajdzie.

Przestrzeń nazw [Aspose.Slides.Ink](https://reference.aspose.com/slides/pl/cpp/aspose.slides.ink/) zawiera klasy i interfejsy niezbędne do pracy z obiektami tuszu. Na przykład interfejs [IInk](https://reference.aspose.com/slides/pl/cpp/aspose.slides.ink/iink/) reprezentuje obiekt tuszu na slajdzie.

## **Różnice między obiektami zwykłymi a obiektami tuszu**

Obiekty na slajdzie PowerPointa są zazwyczaj reprezentowane przez obiekty kształtu. W najprostszej formie kształt jest kontenerem definiującym obszar samego obiektu (jego ramkę) wraz z właściwościami takimi jak rozmiar kontenera, kształt i tło. Więcej informacji znajdziesz w sekcji [Shape Layout Format](https://docs.aspose.com/slides/pl/cpp/shape-manipulations/#access-layout-formats-for-shape).

Jednak gdy PowerPoint obsługuje obiekt tuszu, ignoruje wszystkie właściwości ramki obiektu (kontenera) z wyjątkiem jego rozmiaru. Rozmiar obszaru kontenera jest określany przez standardowe metody [IShape::get_Width](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishape/get_width/) i [IShape::get_Height](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishape/get_height/):

![ink_powerpoint1](ink_powerpoint1.png)

## **Ślady tuszu**

Ślad tuszu jest podstawowym elementem służącym do zapisu trajektorii pióra podczas pisania cyfrowego tuszu. Ślad przechowuje sekwencję połączonych punktów.

Najprostsza forma kodowania określa współrzędne X i Y każdego punktu próbki. Po wyrenderowaniu wszystkich połączonych punktów powstaje obraz podobny do tego:

![ink_powerpoint2](ink_powerpoint2.png)

## **Właściwości pędzla do rysowania**

Pędzel jest używany do rysowania linii łączących punkty śladu tuszu. Pędzel ma własny kolor i rozmiar, określany metodami [IInkBrush::get_Color](https://reference.aspose.com/slides/pl/cpp/aspose.slides.ink/iinkbrush/get_color/) oraz [IInkBrush::get_Size](https://reference.aspose.com/slides/pl/cpp/aspose.slides.ink/iinkbrush/get_size/).

### **Ustawienie koloru pędzla tuszu**

Ten kod C++ pokazuje, jak ustawić kolor pędzla tuszu:

```cpp
#include <DOM/Ink/IInk.h>
#include <DOM/Ink/IInkBrush.h>
#include <DOM/Ink/IInkTrace.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Ink::IInk;
using Aspose::Slides::Presentation;
using System::ExplicitCast;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"pres.pptx");
auto ink = ExplicitCast<IInk>(presentation->get_Slide(0)->get_Shape(0));
auto inkTrace = ink->get_Traces()[0];
auto brush = inkTrace->get_Brush();
brush->set_Color(System::Drawing::Color::get_Red());

presentation->Dispose();
```

### **Ustawienie rozmiaru pędzla tuszu**

Ten kod C++ pokazuje, jak ustawić rozmiar pędzla tuszu:

```cpp
#include <DOM/Ink/IInk.h>
#include <DOM/Ink/IInkBrush.h>
#include <DOM/Ink/IInkTrace.h>
#include <DOM/Presentation.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Ink::IInk;
using Aspose::Slides::Presentation;
using System::ExplicitCast;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"pres.pptx");
auto ink = ExplicitCast<IInk>(presentation->get_Slide(0)->get_Shape(0));
auto inkTrace = ink->get_Traces()[0];
auto brush = inkTrace->get_Brush();
brush->set_Size(System::Drawing::SizeF(5.0f, 10.0f));

presentation->Dispose();
```

Z reguły szerokość i wysokość pędzla nie są sobie równe, więc PowerPoint nie wyświetla rozmiaru pędzla (odpowiednia sekcja danych jest wyszarzona). Gdy szerokość i wysokość pędzla są równe, PowerPoint wyświetla jego rozmiar w następujący sposób:

![ink_powerpoint3](ink_powerpoint3.png)

Dla przejrzystości zwiększmy wysokość obiektu tuszu i przyjrzyjmy się istotnym wymiarom:

![ink_powerpoint4](ink_powerpoint4.png)

Kontener (ramka) nie uwzględnia rozmiaru pędzli – zawsze zakłada, że grubość linii wynosi zero (patrz poprzedni obraz).

Dlatego, aby określić widoczny obszar całego obiektu tuszu, należy wziąć pod uwagę rozmiar pędzla jego śladów. Tutaj obiekt docelowy (ślad odręcznego tekstu) został przeskalowany do rozmiaru kontenera (ramki). Gdy rozmiar kontenera się zmienia, rozmiar pędzla pozostaje stały i odwrotnie.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint stosuje podobne zachowanie dla obiektów tekstowych:

![ink_powerpoint6](ink_powerpoint6.png)

## **Sterowanie wyglądem tuszu podczas eksportu i renderowania**

Aspose.Slides udostępnia interfejs [IInkOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/iinkoptions/), który pozwala kontrolować sposób wyświetlania obiektów tuszu w wyjściu eksportowanym lub renderowanym. Za pomocą jego metod można całkowicie ukryć tusz lub zmienić sposób interpretacji operacji maski pędzla tuszu.

Opcje tuszu są dostępne poprzez opcje eksportu lub renderowania dla kilku typów wyjściowych:

| Wyjście | Metoda opcji tuszu |
| --- | --- |
| PDF | [PdfOptions::get_InkOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/pdfoptions/get_inkoptions/) |
| HTML | [HtmlOptions::get_InkOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/htmloptions/get_inkoptions/) |
| SVG | [SVGOptions::get_InkOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/svgoptions/get_inkoptions/) |
| TIFF | [TiffOptions::get_InkOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/tiffoptions/get_inkoptions/) |
| Obraz slajdu | [RenderingOptions::get_InkOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/renderingoptions/get_inkoptions/) |

Te same dwa ustawienia są dostępne za pomocą powyższych metod:

- [IInkOptions::set_HideInk](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/iinkoptions/set_hideink/) określa, czy obiekty tuszu są uwzględniane w wyjściu. Domyślna wartość to `false`.
- [IInkOptions::set_InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/iinkoptions/set_interpretmaskopasopacity/) określa, czy operacja maski jest interpretowana jako nieprzezroczystość podczas renderowania pędzla tuszu. Domyślna wartość to `true`; ustaw `false`, aby użyć operacji ROP zamiast niej.

### **Ukrywanie obiektów tuszu w wyjściu PDF**

Domyślnie obiekty tuszu pozostają widoczne podczas eksportu. Wywołaj [IInkOptions::set_HideInk](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/iinkoptions/set_hideink/) z wartością `true`, gdy potrzebny jest czysty wynik bez odręcznych adnotacji lub innej treści tuszu.

Poniższy przykład w C++ eksportuje prezentację do PDF, ukrywając wszystkie obiekty tuszu:

```cpp
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::PdfOptions;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->get_InkOptions()->set_HideInk(true);

presentation->Save(u"presentation_without_ink.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **Ukrywanie obiektów tuszu podczas renderowania slajdu jako obrazu**

Aby ukryć obiekty tuszu przy renderowaniu slajdów jako obrazy bitmapowe, skonfiguruj [RenderingOptions::get_InkOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/renderingoptions/get_inkoptions/) i przekaż opcje renderowania do metody [ISlide::GetImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islide/getimage/).

Poniższy przykład w C++ renderuje pierwszy slajd jako obraz PNG bez obiektów tuszu:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/RenderingOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::ImageFormat;
using Aspose::Slides::Presentation;
using Aspose::Slides::Export::RenderingOptions;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->get_InkOptions()->set_HideInk(true);

auto image = presentation->get_Slide(0)->GetImage(renderingOptions);
image->Save(u"slide_without_ink.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

### **Sterowanie renderowaniem maski tuszu**

Metoda [IInkOptions::set_InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/iinkoptions/set_interpretmaskopasopacity/) kontroluje, jak operacje maski są interpretowane przy renderowaniu pędzli tuszu. Domyślna wartość to `true`, co oznacza użycie nieprzezroczystości. Wywołaj metodę z `false`, aby zamiast tego użyć operacji ROP.

Poniższy przykład w C++ eksportuje slajd do SVG i używa renderowania opartego na ROP dla operacji maski tuszu:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SVGOptions;
using System::MakeObject;
using System::IO::File;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->get_InkOptions()->set_InterpretMaskOpAsOpacity(false);

auto stream = File::Create(u"slide.svg");
presentation->get_Slide(0)->WriteAsSvg(stream, svgOptions);

stream->Dispose();
presentation->Dispose();
```

To samo ustawienie można zastosować przez [TiffOptions::get_InkOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/tiffoptions/get_inkoptions/) przy eksportowaniu prezentacji lub renderowaniu slajdu do TIFF.

### **Wybór, czy ukrywać, czy zachować tusz**

Użyj [IInkOptions::set_HideInk](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/iinkoptions/set_hideink/) z wartością `true`, gdy eksportowany plik ma być czystą wersją prezentacji z adnotacjami, np. finalną kopią przeznaczoną do dystrybucji bez znaczników recenzji.

Pozostaw tusz widoczny (domyślne ustawienie `false`), gdy adnotacje tuszu są częścią zamierzonej treści, takiej jak komentarze recenzji, odręczne notatki, podkreślenia lub rysunki, które mają pozostać widoczne w wyniku eksportu. Umożliwia to aplikacjom generowanie oddzielnych wersji recenzji i finalnych z tej samej prezentacji bez modyfikowania źródłowych obiektów tuszu.

## **FAQ**

**Czy mogę zmienić kolor lub rozmiar istniejącego pociągnięcia tuszu?**

Tak. Pobierz ślad z [IInk::get_Traces](https://reference.aspose.com/slides/pl/cpp/aspose.slides.ink/iink/get_traces/), a następnie zmień jego [IInkTrace::get_Brush](https://reference.aspose.com/slides/pl/cpp/aspose.slides.ink/iinktrace/get_brush/). Możesz wywołać [IInkBrush::set_Color](https://reference.aspose.com/slides/pl/cpp/aspose.slides.ink/iinkbrush/set_color/) oraz [IInkBrush::set_Size](https://reference.aspose.com/slides/pl/cpp/aspose.slides.ink/iinkbrush/set_size/) na pędzlu.

**Czy ukrywanie tuszu zmienia źródłową prezentację?**

Nie. [IInkOptions::set_HideInk](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/iinkoptions/set_hideink/) wpływa wyłącznie na wynik renderowany lub eksportowany; nie usuwa ani nie modyfikuje obiektów tuszu w źródłowej prezentacji.

**Które formaty eksportu obsługują opcje tuszu?**

Możesz konfigurować opcje tuszu dla PDF, HTML, SVG, TIFF oraz bitmapowych obrazów slajdów poprzez odpowiadające opcje eksportu lub renderowania wymienione powyżej.

**Dalsza lektura**

* Aby dowiedzieć się więcej o kształtach, zobacz sekcję [PowerPoint Shapes](https://docs.aspose.com/slides/pl/cpp/powerpoint-shapes/).
* Po więcej informacji o wartościach efektywnych, zobacz [Shape Effective Properties](https://docs.aspose.com/slides/pl/cpp/shape-effective-properties/#get-effective-font-height-value).
* Szczegóły eksportu do PDF znajdziesz w [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/pl/cpp/convert-powerpoint-to-pdf/).
* Szczegóły eksportu do HTML znajdziesz w [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/pl/cpp/convert-powerpoint-to-html/).
* Szczegóły eksportu do SVG znajdziesz w [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/pl/cpp/render-a-slide-as-an-svg-image/).
* Szczegóły eksportu do TIFF znajdziesz w [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/pl/cpp/convert-powerpoint-to-tiff/).
* Szczegóły renderowania slajdów na obrazy znajdziesz w [Convert Presentation Slides to Images](https://docs.aspose.com/slides/pl/cpp/convert-slide/).