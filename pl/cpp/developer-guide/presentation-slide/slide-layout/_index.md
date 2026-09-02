---
title: Zastosowanie lub zmiana układów slajdów w C++
linktitle: Układ slajdu
type: docs
weight: 60
url: /pl/cpp/slide-layout/
keywords:
- układ slajdu
- układ treści
- pole zastępcze
- projektowanie prezentacji
- projektowanie slajdu
- nieużywany układ
- widoczność stopki
- slajd tytułowy
- tytuł i treść
- nagłówek sekcji
- dwa elementy treści
- porównanie
- tylko tytuł
- pusty układ
- treść z podpisem
- obraz z podpisem
- tytuł i pionowy tekst
- pionowy tytuł i tekst
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Zastosuj, utwórz i modyfikuj układy slajdów w Aspose.Slides dla C++, dodaj pola zastępcze, usuń nieużywane układy i kontroluj widoczność stopki."
---
## **Przegląd**

Układ slajdu definiuje pozycje i formatowanie pól zastępczych, takich jak tytuły, tekst, obrazy, wykresy i tabele. Zastosowanie układu zapewnia spójną strukturę slajdów, jednocześnie pozwalając każdemu slajdowi zawierać własną treść.

Najczęściej używane układy to:

- **Slajd tytułowy**: Zawiera pola zastępcze tytułu i podtytułu.
- **Tytuł i treść**: Zawiera pole zastępcze tytułu oraz ogólne pole zastępcze treści.
- **Pusty**: Nie zawiera pól zastępczych i jest przydatny, gdy wszystkie kształty będą rozmieszczane ręcznie.

## **Zrozumienie dziedziczenia układów**

Prezentacja ma trzy powiązane poziomy:

1. [Slajd nadrzędny](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imasterslide/) definiuje motyw, współdzielone formatowanie, tła i wspólne obiekty.
1. [Układ slajdu](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilayoutslide/) należy do slajdu nadrzędnego i określa konkretny układ pól zastępczych.
1. [Zwykły slajd](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islide/) używa jednego układu i przechowuje treść wprowadzoną dla tego slajdu.

Zwykły slajd dziedziczy motyw i formatowanie z jego układu, a układ dziedziczy z nadrzędnego. Wartość ustawiona bezpośrednio na zwykłym slajdzie nadpisuje dziedziczoną wartość na tym poziomie. Gdy tworzony jest zwykły slajd, jego kształty pól zastępczych są generowane na podstawie wybranego układu, natomiast treść wprowadzona do tych pól należy do zwykłego slajdu.

Dodaj wymagane pola zastępcze do układu przed tworzeniem z niego slajdów. Dodanie kolejnego pola zastępczego do układu później nie dodaje automatycznie odpowiadającego kształtu pola zastępczego do istniejących zwykłych slajdów.

Ten związek ma dwa ważne konsekwencje:

- Zmiana dziedziczonego formatowania lub istniejącej geometrii pól zastępczych w układzie może zaktualizować każdy slajd, który od niego zależy. Przed edycją układu, który jest już używany, sprawdź jego zależne slajdy i przejrzyj powstałą prezentację.
- Układ, który jest nadal używany przez slajd, nie może być usunięty. Przypisz najpierw jego zależne slajdy do innego układu lub usuń tylko nieużywane układy.

Po więcej informacji o najwyższym poziomie tej hierarchii, zobacz [Slide Master](/slides/pl/cpp/slide-master/).

## **Wybór i zastosowanie układu slajdu**

Używaj typu układu, gdy prezentacja stosuje standardowe definicje układów PowerPoint. Nazwy układów są edytowalne przez użytkownika i mogą być lokalizowane, więc wybór oparty na nazwie jest mniej niezawodny, chyba że kontrolujesz szablon źródłowy.

Poniższy przykład wyszukuje **Title and Content** na pierwszym masterze. Jeśli ten układ nie jest dostępny, celowo przechodzi do **Blank**. Drugi warunek null jest potrzebny, ponieważ prezentacja może zawierać tylko niestandardowe układy. Wybrany układ jest następnie stosowany do pierwszego zwykłego slajdu za pomocą metody [ISlide::set_LayoutSlide](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islide/set_layoutslide/).

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto layoutSlides = presentation->get_Master(0)->get_LayoutSlides();
auto targetLayout = layoutSlides->GetByType(SlideLayoutType::TitleAndObject);

if (targetLayout == nullptr)
{
    targetLayout = layoutSlides->GetByType(SlideLayoutType::Blank);
}

if (targetLayout == nullptr)
{
    throw InvalidOperationException(u"The first master does not contain a suitable layout slide.");
}

presentation->get_Slide(0)->set_LayoutSlide(targetLayout);
presentation->Save(u"output-with-new-layout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Zmiana układu slajdu nie usuwa zwykłych kształtów dodanych bezpośrednio do slajdu. Jednak pozycje pól zastępczych, dziedziczone formatowanie i powiązania między istniejącymi polami a nowym układem mogą się zmienić, więc sprawdź wynik przy przełączaniu między znacznie różnymi układami.

## **Dodanie układu slajdu**

Wybór i tworzenie to odrębne operacje. Poprzedni przykład wybiera istniejący układ; nie tworzy go. Aby utworzyć układ, wywołaj metodę [IMasterLayoutSlideCollection::Add](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imasterlayoutslidecollection/add/) na kolekcji układów docelowego mastera.

Poniższy przykład zawsze dodaje nowy układ **Title and Content** o nazwie `Report Title and Content`, a następnie dodaje zwykły slajd oparty na nim. Nazwy układów muszą być unikalne w ramach kolekcji.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto masterSlide = presentation->get_Master(0);
auto reportLayout = masterSlide->get_LayoutSlides()->Add(SlideLayoutType::TitleAndObject, u"Report Title and Content");
presentation->get_Slides()->AddEmptySlide(reportLayout);

presentation->Save(u"output-with-report-layout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Dodawaj układ tylko wtedy, gdy szablon rzeczywiście potrzebuje kolejnej wielokrotnego użytku struktury. Jeśli odpowiedni układ już istnieje, wybierz i użyj go ponownie zamiast tworzyć duplikat.

## **Dodawanie pól zastępczych do układu slajdu**

Metoda [ILayoutSlide::get_PlaceholderManager](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/) udostępnia [ILayoutPlaceholderManager](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilayoutplaceholdermanager/) do dodawania kształtów pól zastępczych do układu.

| PowerPoint Placeholder              | `ILayoutPlaceholderManager` Method |
| ----------------------------------- | ---------------------------------- |
| ![Content](content.png)             | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilayoutplaceholdermanager/addcontentplaceholder/) |
| ![Content (Vertical)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilayoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![Text](text.png)                   | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilayoutplaceholdermanager/addtextplaceholder/) |
| ![Text (Vertical)](textV.png)       | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilayoutplaceholdermanager/addverticaltextplaceholder/) |
| ![Picture](picture.png)             | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilayoutplaceholdermanager/addpictureplaceholder/) |
| ![Chart](chart.png)                 | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilayoutplaceholdermanager/addchartplaceholder/) |
| ![Table](table.png)                 | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilayoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png)           | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilayoutplaceholdermanager/addsmartartplaceholder/) |
| ![Media](media.png)                 | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilayoutplaceholdermanager/addmediaplaceholder/) |
| ![Online Image](onlineImage.png)    | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilayoutplaceholdermanager/addonlineimageplaceholder/) |

Poniższy przykład weryfikuje, że istnieje układ **Blank**, dodaje do niego cztery pola zastępcze, a następnie tworzy zwykły slajd korzystający z zmodyfikowanego układu. Kolejność jest zamierzona: pola zastępcze są dodawane przed utworzeniem zwykłego slajdu, aby Aspose.Slides mógł wygenerować odpowiadające kształty pól zastępczych na tym slajdzie.

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutPlaceholderManager.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (blankLayout == nullptr)
{
    throw InvalidOperationException(u"The presentation does not contain a Blank layout slide.");
}

auto placeholderManager = blankLayout->get_PlaceholderManager();
placeholderManager->AddContentPlaceholder(20.0f, 20.0f, 310.0f, 270.0f);
placeholderManager->AddVerticalTextPlaceholder(350.0f, 20.0f, 350.0f, 270.0f);
placeholderManager->AddChartPlaceholder(20.0f, 310.0f, 310.0f, 180.0f);
placeholderManager->AddTablePlaceholder(350.0f, 310.0f, 350.0f, 180.0f);

presentation->get_Slides()->AddEmptySlide(blankLayout);
presentation->Save(u"output-with-placeholders.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Wynik:

![The placeholders on the layout slide](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}

Zmiana dziedziczonego formatowania lub geometrii istniejących pól zastępczych w układzie może wpłynąć na zależne slajdy. Nowo dodane pole zastępcze nie jest automatycznie uzupełniane w istniejących zwykłych slajdach. Testuj zmiany układu na kopii prezentacji i sprawdzaj każdy zależny slajd.

{{% /alert %}}

## **Usuwanie nieużywanych układów slajdów**

Użyj metody [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) aby usunąć układy, do których nie odwołuje żaden zwykły slajd. Metoda pozostawia niezmienione układy wciąż używane.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);
presentation->Save(u"output-without-unused-layouts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Aby usunąć konkretny układ, najpierw użyj jego metody [get_HasDependingSlides](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilayoutslide/get_hasdependingslides/) lub [GetDependingSlides](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilayoutslide/getdependingslides/). Przypisz wszystkie zależne slajdy przed wywołaniem [ILayoutSlide::Remove](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilayoutslide/remove/). Próba usunięcia używanego układu generuje [PptxEditException](https://reference.aspose.com/slides/pl/cpp/aspose.slides/pptxeditexception/).

## **Kontrola widoczności stopki w układzie slajdu**

Układ ma własne pola zastępcze stopki, numeru slajdu i daty/czasu. Użyj metody [ILayoutSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilayoutslide/get_headerfootermanager/) aby sterować tymi polami dla jednego układu. Jest to przydatne, gdy na przykład układy treści powinny wyświetlać stopki, a układy tytułowe nie.

Poniższy przykład bezpiecznie wybiera układ i ustawia jego elementy stopki jako widoczne:

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILayoutSlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::TitleAndObject);

if (layoutSlide == nullptr)
{
    layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
}

if (layoutSlide == nullptr)
{
    throw InvalidOperationException(u"The presentation does not contain a suitable layout slide.");
}

auto headerFooterManager = layoutSlide->get_HeaderFooterManager();
headerFooterManager->SetFooterVisibility(true);
headerFooterManager->SetSlideNumberVisibility(true);
headerFooterManager->SetDateTimeVisibility(true);
headerFooterManager->SetFooterText(u"Footer text");
headerFooterManager->SetDateTimeText(u"Date and time text");

presentation->Save(u"output-with-layout-footers.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Kontrola widoczności stopki w masterze i jego podukładach**

Aby zastosować spójne ustawienia stopki w całej hierarchii mastera, użyj metody [IMasterSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imasterslide/get_headerfootermanager/). Metody propagacji z [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imasterslideheaderfootermanager/) działają na masterze oraz jego zależnych układach i zwykłych slajdach; nie dotyczą pojedynczego zwykłego slajdu.

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto headerFooterManager = presentation->get_Master(0)->get_HeaderFooterManager();
headerFooterManager->SetFooterAndChildFootersVisibility(true);
headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);
headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");

presentation->Save(u"output-with-master-footers.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Jaka jest różnica między slajdem master a układem slajdu?**

Slajd master definiuje motyw prezentacji i współdzielone formatowanie. Układ slajdu należy do mastera i definiuje jeden wielokrotnego użytku układ pól zastępczych. Zwykłe slajdy używają tych układów i przechowują treść specyficzną dla slajdu.

**Czy mogę skopiować układ slajdu z jednej prezentacji do drugiej?**

Tak. Dodaj kopię do docelowej kolekcji za pomocą metody [IGlobalLayoutSlideCollection::AddClone](https://reference.aspose.com/slides/pl/cpp/aspose.slides/igloballayoutslidecollection/addclone/). Przy kopiowaniu między prezentacjami sprawdź również czcionki, motywy, obrazy i inne zasoby użyte przez źródłowy układ.

**Co się stanie, gdy zmodyfikuję układ, który jest już używany?**

Zależne slajdy dziedziczą zmiany układu, chyba że nadpisują dotknięte formatowanie lub obiekty lokalnie. Geometria pól zastępczych i dziedziczone style mogą więc zmienić się na wielu slajdach jednocześnie. Użyj [GetDependingSlides](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilayoutslide/getdependingslides/) aby zidentyfikować dotknięte slajdy przed edycją układu.

**Co się stanie, jeśli usunę układ, który jest nadal używany?**

Aspose.Slides zgłasza [PpptxEditException](https://reference.aspose.com/slides/pl/cpp/aspose.slides/pptxeditexception/). Najpierw przypisz zależne slajdy lub użyj [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) aby usunąć tylko niepowiązane układy.