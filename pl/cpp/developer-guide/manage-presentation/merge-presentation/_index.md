---
title: Efektywne scalanie prezentacji w C++
linktitle: Scal prezentacje
type: docs
weight: 40
url: /pl/cpp/merge-presentation/
keywords:
- scal PowerPoint
- scal prezentacje
- scal slajdy
- scal PPT
- scal PPTX
- scal ODP
- połącz PowerPoint
- połącz prezentacje
- połącz slajdy
- połącz PPT
- połącz PPTX
- połącz ODP
- C++
- Aspose.Slides
description: "Bezproblemowo scal prezentacje PowerPoint (PPT, PPTX) oraz OpenDocument (ODP) przy użyciu Aspose.Slides dla C++, upraszczając swój proces pracy."
---
## **Przegląd**

Aspose.Slides umożliwia łączenie prezentacji poprzez klonowanie slajdów z jednej prezentacji do drugiej. Ten artykuł wyjaśnia, jak łączyć całe prezentacje lub wybrane slajdy, używać szablonu mastera slajdów lub określonego układu podczas łączenia, obsługiwać prezentacje o różnych rozmiarach slajdów oraz dodawać scalone slajdy do sekcji prezentacji. Omówiono również praktyczne uwagi dotyczące scalonych treści, w tym notatek prelegenta, komentarzy, plików zabezpieczonych hasłem oraz użycia wątków.

## **Scalanie prezentacji**

Podczas łączenia jednej prezentacji z drugą efektywnie łączysz ich slajdy w jednej prezentacji, uzyskując jeden plik. 

{{% alert title="Informacja" color="info" %}}

Większość programów do prezentacji (PowerPoint lub OpenOffice) nie posiada funkcji umożliwiających użytkownikom łączenie prezentacji w taki sposób. 

[**Aspose.Slides for C++**](https://products.aspose.com/slides/pl/cpp/), umożliwia łączenie prezentacji na różne sposoby. Możesz łączyć prezentacje wraz ze wszystkimi ich kształtami, stylami, tekstami, formatowaniem, komentarzami, animacjami itp., nie martwiąc się o utratę jakości lub danych. 

**Zobacz także**

[Clone Slides](https://docs.aspose.com/slides/pl/cpp/clone-slides/)*.* 

{{% /alert %}}

### **Co można scalić**

Przy użyciu Aspose.Slides możesz scalić 

* całe prezentacje. Wszystkie slajdy z prezentacji trafiają do jednej prezentacji
* określone slajdy. Wybrane slajdy trafiają do jednej prezentacji
* prezentacje w jednym formacie (PPT do PPT, PPTX do PPTX itp.) oraz w różnych formatach (PPT do PPTX, PPTX do ODP itp.) ze sobą. 

{{% alert title="Uwaga" color="warning" %}} 

Oprócz prezentacji, Aspose.Slides umożliwia łączenie innych plików:

* [Images](https://products.aspose.com/slides/pl/cpp/merger/image-to-image/), takie jak [JPG to JPG](https://products.aspose.com/slides/pl/cpp/merger/jpg-to-jpg/) lub [PNG to PNG](https://products.aspose.com/slides/pl/cpp/merger/png-to-png/)
* Dokumentów, takich jak [PDF to PDF](https://products.aspose.com/slides/pl/cpp/merger/pdf-to-pdf/) lub [HTML to HTML](https://products.aspose.com/slides/pl/cpp/merger/html-to-html/)
* Dwa różne pliki, takie jak [image to PDF](https://products.aspose.com/slides/pl/cpp/merger/image-to-pdf/) lub [JPG to PDF](https://products.aspose.com/slides/pl/cpp/merger/jpg-to-pdf/) lub [TIFF to PDF](https://products.aspose.com/slides/pl/cpp/merger/tiff-to-pdf/).

{{% /alert %}}

### **Opcje scalania**

Możesz zastosować opcje określające, czy

* każdy slajd w prezentacji wynikowej zachowuje unikalny styl
* określony styl jest używany dla wszystkich slajdów w prezentacji wynikowej. 

Aby scalić prezentacje, Aspose.Slides udostępnia metodę [AddClone](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) (z interfejsu [ISlideCollection](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_slide_collection)). Istnieje kilka implementacji metod `AddClone`, które definiują parametry procesu scalania prezentacji. Każdy obiekt Presentation ma kolekcję [Slides](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c), więc możesz wywołać metodę `AddClone` z prezentacji, do której chcesz scalić slajdy. 

Metoda `AddClone` zwraca obiekt `ISlide`, będący klonem slajdu źródłowego. Slajdy w prezentacji wynikowej są po prostu kopią slajdów ze źródła. Dzięki temu możesz wprowadzać zmiany w otrzymanych slajdach (np. stosować style, opcje formatowania lub układy), nie martwiąc się o wpływ na prezentacje źródłowe. 

## **Scalanie prezentacji** 

Aspose.Slides udostępnia metodę [**AddClone (ISlide)**](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee), która pozwala łączyć slajdy, zachowując ich układy i style (parametry domyślne). 

Poniższy kod C++ pokazuje, jak scalić prezentacje:

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Scalanie prezentacji z użyciem szablonu mastera slajdów**

Aspose.Slides udostępnia metodę [**AddClone (ISlide, IMasterSlide, bool)**](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_slide_collection#a6b040e6b30f52ab4644fafdbc650b640), która pozwala łączyć slajdy, stosując szablon mastera prezentacji. Dzięki temu, w razie potrzeby, możesz zmienić styl slajdów w prezentacji wynikowej. 

Ten kod w C++ demonstruje opisaną operację:

```cpp
#include <DOM/IMasterSlideCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_Masters()->idx_get(0), true);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

{{% alert title="Uwaga" color="warning" %}} 

Układ slajdu dla mastera jest określany automatycznie. Jeśli nie można określić odpowiedniego układu, a parametr bool `allowCloneMissingLayout` metody `AddClone` jest ustawiony na true, używany jest układ slajdu źródłowego. W przeciwnym razie zostanie wyrzucony [PptxEditException](https://reference.aspose.com/slides/pl/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d). 

{{% /alert %}}

Jeśli chcesz, aby slajdy w prezentacji wynikowej miały inny układ slajdu, użyj zamiast tego metody [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_slide_collection#a0ed5909b2d92555159007046760ff2f1) podczas scalania. 

## **Scalanie wybranych slajdów z prezentacji**

Scalanie wybranych slajdów z wielu prezentacji jest przydatne przy tworzeniu własnych zestawów slajdów. Aspose.Slides C++ umożliwia wybranie i zaimportowanie tylko potrzebnych slajdów. API zachowuje formatowanie, układ i projekt oryginalnych slajdów.

Poniższy kod C++ tworzy nową prezentację, dodaje slajdy tytułowe z dwóch innych prezentacji i zapisuje wynik do pliku:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IPresentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/SlideLayoutType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

SmartPtr<ISlide> GetTitleSlide(SmartPtr<IPresentation> presentation)
{
    for (auto&& slide : presentation->get_Slides())
    {
        if (slide->get_LayoutSlide()->get_LayoutType() == SlideLayoutType::Title)
        {
            return slide;
        }
    }
    return nullptr;
}
```
```cpp
#include <DOM/IPresentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Zadeklarowano w powyższym kodzie.
SmartPtr<ISlide> GetTitleSlide(SmartPtr<IPresentation> presentation);

auto presentation = MakeObject<Presentation>();
auto presentation1 = MakeObject<Presentation>(u"presentation1.pptx");
auto presentation2 = MakeObject<Presentation>(u"presentation2.pptx");

presentation->get_Slides()->RemoveAt(0);

auto slide1 = GetTitleSlide(presentation1);

if (slide1 != nullptr)
    presentation->get_Slides()->AddClone(slide1);

auto slide2 = GetTitleSlide(presentation2);

if (slide2 != nullptr)
    presentation->get_Slides()->AddClone(slide2);

presentation->Save(u"combined.pptx", SaveFormat::Pptx);

presentation2->Dispose();
presentation1->Dispose();
presentation->Dispose();
```

## **Scalanie prezentacji z użyciem układu slajdu**

Ten kod C++ pokazuje, jak połączyć slajdy z prezentacji, stosując wybrany układ slajdu, aby uzyskać jedną prezentację wynikową:

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_LayoutSlides()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Scalanie prezentacji o różnych rozmiarach slajdów**

{{% alert title="Uwaga" color="warning" %}} 

Nie można scalać prezentacji o różnych rozmiarach slajdów. 

{{% /alert %}}

Aby scalić 2 prezentacje o różnych rozmiarach slajdów, musisz zmienić rozmiar jednej z prezentacji, aby dopasować go do rozmiaru drugiej. 

Ten przykładowy kod demonstruje opisaną operację:

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres1Size = pres1->get_SlideSize()->get_Size();

auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
pres2->get_SlideSize()->SetSize(pres1Size.get_Width(), pres1Size.get_Height(), SlideSizeScaleType::EnsureFit);

for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Scalanie slajdów do sekcji prezentacji**

Ten kod C++ pokazuje, jak scalić określony slajd do sekcji w prezentacji:

```cpp
#include <DOM/ISectionCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (int32_t index = 0; index < pres2->get_Slides()->get_Count(); index++)
{
    auto slide = pres2->get_Slides()->idx_get(index);
    pres1->get_Slides()->AddClone(slide, pres1->get_Sections()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

Slajd jest dodawany na końcu sekcji. 

{{% alert title="Wskazówka" color="info" %}}

Aspose udostępnia [DARMOWĄ aplikację internetową Collage](https://products.aspose.app/slides/pl/collage). Korzystając z tej usługi online, możesz scalać [JPG to JPG](https://products.aspose.app/slides/pl/collage/jpg) lub PNG do PNG, tworzyć [siatki zdjęć](https://products.aspose.app/slides/pl/collage/photo-grid) i tak dalej. 

{{% /alert %}}

## **FAQ**

### Czy notatki prelegenta są zachowywane podczas scalania?

Tak. Podczas klonowania slajdów Aspose.Slides przenosi wszystkie elementy slajdu, w tym notatki, formatowanie i animacje.

### Czy komentarze i ich autorzy są przenoszeni?

Komentarze, jako część treści slajdu, są kopiowane wraz ze slajdem. Etykiety autorów komentarzy są zachowywane jako obiekty komentarzy w powstałej prezentacji.

### Co zrobić, gdy prezentacja źródłowa jest zabezpieczona hasłem?

Należy ją [otworzyć przy użyciu hasła](/slides/pl/cpp/password-protected-presentation/) za pomocą [LoadOptions::set_Password](https://reference.aspose.com/slides/pl/cpp/aspose.slides/loadoptions/set_password/); po załadowaniu te slajdy mogą być bezpiecznie klonowane do nieszyfrowanego pliku docelowego (lub również zabezpieczonego).

### Jak bezpieczne wątkowo jest wykonywanie scalania?

Nie używaj tej samej instancji [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) z [wielu wątków](/slides/pl/cpp/multithreading/). Zalecana zasada to „jeden dokument — jeden wątek”; różne pliki mogą być przetwarzane równolegle w oddzielnych wątkach.