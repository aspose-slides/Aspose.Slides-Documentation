---
title: Zastosowanie lub zmiana układów slajdów w C++
linktitle: Układ slajdu
type: docs
weight: 60
url: /pl/cpp/slide-layout/
keywords:
- układ slajdu
- układ treści
- element zastępczy
- projektowanie prezentacji
- projektowanie slajdu
- nieużywany układ
- widoczność stopki
- slajd tytułowy
- tytuł i treść
- nagłówek sekcji
- dwie treści
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
description: "Zastosuj, twórz i modyfikuj układy slajdów w Aspose.Slides dla C++, dodawaj elementy zastępcze, usuwaj nieużywane układy i kontroluj widoczność stopki."
---
## **Omówienie**

Układ slajdu definiuje pozycje i formatowanie elementów zastępczych, takich jak tytuły, tekst, obrazy, wykresy i tabele. Zastosowanie układu zapewnia spójną strukturę slajdów, jednocześnie umożliwiając każdy slajd wypełnić własną treścią.

Najczęściej używane układy to:

- **Slajd tytułowy**: Zawiera elementy zastępcze tytułu i podtytułu.
- **Tytuł i treść**: Zawiera element zastępczy tytułu oraz ogólny element zastępczy treści.
- **Pusty**: Nie zawiera elementów zastępczych i jest przydatny, gdy każdy kształt zostanie rozmieszczony ręcznie.

## **Zrozumienie dziedziczenia układów**

Prezentacja ma trzy powiązane poziomy:

1. [slajd‑mistrz](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imasterslide/) definiuje motyw, wspólne formatowanie, tła i obiekty wspólne.
2. [układ‑slajdu](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilayoutslide/) należy do mistrza i określa konkretny układ elementów zastępczych.
3. [zwykły slajd](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islide/) używa jednego układu i przechowuje wprowadzoną na nim treść.

Zwykły slajd dziedziczy motyw i formatowanie z układu, a układ dziedziczy z mistrza. Wartość ustawiona bezpośrednio na zwykłym slajdzie zastępuje dziedziczoną wartość na tym poziomie. Podczas tworzenia zwykłego slajdu jego elementy zastępcze są generowane na podstawie wybranego układu, a treść wprowadzona w tych elementach należy do zwykłego slajdu.

Dodaj wymagane elementy zastępcze do układu przed tworzeniem z niego slajdów. Dodanie kolejnego elementu zastępczego do układu później nie doda automatycznie odpowiadającego kształtu elementu zastępczego do istniejących zwykłych slajdów.

Relacja ta ma dwa istotne skutki:

- Zmiana dziedziczonego formatowania lub istniejącej geometrii elementu zastępczego w układzie może zaktualizować każdy slajd, który od niego zależy. Przed edycją układu już używanego, sprawdź jego zależne slajdy i przejrzyj wynikową prezentację.
- Układ, który jest nadal używany przez slajd, nie może być usunięty. Przypisz najpierw jego zależne slajdy do innego układu lub usuń tylko nieużywane układy.

Po więcej informacji o najwyższym poziomie tej hierarchii zobacz [Mistrz slajdów](/slides/pl/cpp/slide-master/).

Aby ukryć dziedziczone logotypy lub dekoracyjne kształty mistrza na jednym slajdzie lub poprzez współdzielony układ, zobacz [Kontrolowanie widoczności grafiki mistrza](/slides/pl/cpp/slide-master/). Przykład porównuje dwa slajdy używające tego samego mistrza.

## **Wybór i zastosowanie układu slajdu**

Używaj typu układu, gdy prezentacja podąża za standardowymi definicjami układów PowerPoint. Nazwy układów są edytowalne przez użytkownika i mogą być lokalizowane, więc wybór oparty na nazwie jest mniej niezawodny, chyba że kontrolujesz szablon źródłowy.

Poniższy przykład wyszukuje **Tytuł i treść** w pierwszym mistrzu. Jeśli ten układ jest niedostępny, celowo przechodzi do **Pusty**. Drugi warunek null jest potrzebny, ponieważ prezentacja może zawierać wyłącznie własne układy. Wybrany układ jest następnie zastosowany do pierwszego zwykłego slajdu za pomocą metody [ISlide::set_LayoutSlide](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islide/set_layoutslide/).

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

Zmiana układu slajdu nie usuwa zwykłych kształtów dodanych bezpośrednio do slajdu. Jednak pozycje elementów zastępczych, dziedziczone formatowanie i zgodność istniejących elementów zastępczych z nowym układem mogą się zmienić, więc sprawdź wynik przy przełączaniu między znacznie różnymi układami.

## **Dodanie układu slajdu**

Wybór i tworzenie to oddzielne operacje. Poprzedni przykład wybiera istniejący układ; nie tworzy go. Aby utworzyć układ, wywołaj metodę [IMasterLayoutSlideCollection::Add](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imasterlayoutslidecollection/add/) na kolekcji układów docelowego mistrza.

Poniższy przykład zawsze dodaje nowy układ **Tytuł i treść** o nazwie `Report Title and Content`, a następnie dodaje zwykły slajd oparty na tym układzie. Nazwy układów muszą być unikalne w kolekcji.

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

Dodawaj układ tylko wtedy, gdy szablon naprawdę potrzebuje kolejnej wielokrotnego użytku struktury. Jeśli odpowiedni układ już istnieje, wybierz i użyj go ponownie zamiast tworzyć duplikat.

## **Dodawanie elementów zastępczych do układu slajdu**

Metoda [ILayoutSlide::get_PlaceholderManager](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/) udostępnia [ILayoutPlaceholderManager](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilayoutplaceholdermanager/) do dodawania kształtów elementów zastępczych do układu.

| Placeholder programu PowerPoint   | `ILayoutPlaceholderManager` Method |
| --------------------------------- | ---------------------------------- |
| ![Content](content.png)           | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilayoutplaceholdermanager/addcontentplaceholder/) |
| ![Content (Vertical)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilayoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![Text](text.png)                 | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilayoutplaceholdermanager/addtextplaceholder/) |
| ![Text (Vertical)](textV.png)     | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilayoutplaceholdermanager/addverticaltextplaceholder/) |
| ![Picture](picture.png)           | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilayoutplaceholdermanager/addpictureplaceholder/) |
| ![Chart](chart.png)               | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilayoutplaceholdermanager/addchartplaceholder/) |
| ![Table](table.png)               | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilayoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png)         | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilayoutplaceholdermanager/addsmartartplaceholder/) |
| ![Media](media.png)               | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilayoutplaceholdermanager/addmediaplaceholder/) |
| ![Online Image](onlineImage.png)  | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilayoutplaceholdermanager/addonlineimageplaceholder/) |

Poniższy przykład sprawdza, czy istnieje układ **Pusty**, dodaje do niego cztery elementy zastępcze, a następnie tworzy zwykły slajd używający zmodyfikowanego układu. Kolejność jest zamierzona: elementy zastępcze są dodawane przed utworzeniem zwykłego slajdu, dzięki czemu Aspose.Slides może wygenerować odpowiadające im kształty na tym slajdzie.

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

Rezultat:

![Elementy zastępcze na slajdzie układu](add_placeholders.png)

{{% alert color="warning" title="Ostrzeżenie" %}}
Zmiana dziedziczonego formatowania lub geometrii istniejących elementów zastępczych w układzie może wpływać na slajdy zależne. Nowo dodany element zastępczy układu nie jest automatycznie wstawiany do istniejących zwykłych slajdów. Testuj zmiany układów na kopii prezentacji i sprawdzaj każdy slajd zależny.
{{% /alert %}}

## **Usuwanie nieużywanych układów slajdu**

Użyj metody [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) aby usunąć układy, do których nie odwołuje żaden zwykły slajd. Metoda pozostawia nienaruszone układy nadal będące w użyciu.

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

Aby usunąć konkretny układ, najpierw użyj jego metody [get_HasDependingSlides](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilayoutslide/get_hasdependingslides/) lub [GetDependingSlides](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilayoutslide/getdependingslides/). Przypisz wszelkie zależne slajdy przed wywołaniem [ILayoutSlide::Remove](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilayoutslide/remove/). Próba usunięcia używanego układu generuje [PptxEditException](https://reference.aspose.com/slides/pl/cpp/aspose.slides/pptxeditexception/).

## **Kontrola widoczności stopki na układzie slajdu**

Układ posiada własne elementy zastępcze stopki, numeru slajdu i daty‑czasu. Użyj metody [ILayoutSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilayoutslide/get_headerfootermanager/) aby sterować tymi elementami dla jednego układu. Jest to przydatne, gdy na przykład układy treści powinny wyświetlać stopki, a układy tytułów nie powinny.

Poniższy przykład wybiera układ w bezpieczny sposób i sprawia, że jego elementy stopki są widoczne:

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

## **Kontrola widoczności stopki na mistrzu i jego układach potomnych**

Aby zastosować spójne ustawienia stopki w całej hierarchii mistrza, użyj metody [IMasterSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imasterslide/get_headerfootermanager/). Metody propagacji [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imasterslideheaderfootermanager/) działają na mistrzu oraz jego zależnych układach i zwykłych slajdach; nie dotyczą pojedynczego zwykłego slajdu.

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

**Jaka jest różnica między slajdem‑mistrzem a układem slajdu?**

Slajd‑mistrz definiuje motyw prezentacji i wspólne formatowanie. Układ slajdu należy do mistrza i określa jedną wielokrotnie używaną konfigurację elementów zastępczych. Zwykłe slajdy korzystają z tych układów i przechowują treść specyficzną dla slajdu.

**Czy mogę skopiować układ slajdu z jednej prezentacji do drugiej?**

Tak. Dodaj kopię do docelowej kolekcji metodą [IGlobalLayoutSlideCollection::AddClone](https://reference.aspose.com/slides/pl/cpp/aspose.slides/igloballayoutslidecollection/addclone/). Przy kopiowaniu między prezentacjami sprawdź także czcionki, motywy, obrazy i inne zasoby używane przez źródłowy układ.

**Co się stanie, gdy zmodyfikuję układ, który jest już używany?**

Slajdy zależne odziedziczą zmiany układu, chyba że nadpiszą dotknięte formatowanie lub obiekty lokalnie. Geometria elementów zastępczych i dziedziczone style mogą więc zmienić się jednocześnie na wielu slajdach. Użyj [GetDependingSlides](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilayoutslide/getdependingslides/), aby przed edycją układu zidentyfikować dotknięte slajdy.

**Co się stanie, jeśli usunę układ, który jest nadal używany?**

Aspose.Slides zgłasza [PptxEditException](https://reference.aspose.com/slides/pl/cpp/aspose.slides/pptxeditexception/). Najpierw przypisz zależne slajdy do innego układu lub użyj [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/), aby usunąć tylko nieodwoływane układy.