---
title: Zarządzanie masterami slajdów prezentacji w C++
linktitle: Master slajd
type: docs
weight: 80
url: /pl/cpp/slide-master/
keywords:
- master slajdu
- master slajd
- master slajd PPT
- wiele masterów slajdów
- porównaj mastery slajdów
- tło
- pole zastępcze
- klonuj master slajd
- kopiuj master slajd
- duplikuj master slajd
- nieużywany master slajd
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Zarządzaj masterami slajdów w Aspose.Slides dla C++: uzyskaj dostęp, edytuj, klonuj, porównuj i usuwaj mastery slajdów w prezentacjach PowerPoint i OpenDocument."
---
## **Przegląd**

**Master slajd** definiuje wspólne ustawienia projektu dla grupy slajdów. Może zawierać wspólne kształty, loga, tła, style tekstu, ustawienia motywu i stopki. W programie PowerPoint edycja mastera slajdu jest typowym sposobem utrzymania spójności prezentacji bez powtarzania tego samego formatowania na każdym slajdzie.

Aspose.Slides for C++ obsługuje ten sam model. Prezentacja może zawierać jeden lub więcej masterów slajdów, a każdy master może zawierać kilka slajdów układu. Zwykłe slajdy zazwyczaj nie odwołują się bezpośrednio do mastera. Zamiast tego używają slajdu układu, który należy do mastera.

Hierarchia jest następująca:

1. **Master slajd** – definiuje współdzielony projekt i motyw.  
1. **Slajd układu** – definiuje określone rozmieszczenie pól zastępczych i formatowanie poziomu układu.  
1. **Normalny slajd** – zawiera rzeczywistą treść prezentacji i używa jednego slajdu układu.

![The hierarchy of master slides, layout slides, and normal slides](slide-master_2.jpg)

W Aspose.Slides master slajd jest reprezentowany przez interfejs [IMasterSlide](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imasterslide/). Wszystkie mastery slajdów w prezentacji są dostępne przez kolekcję [Presentation::get_Masters](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/get_masters/), która implementuje [IMasterSlideCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imasterslidecollection/).

{{% alert color="info" title="Inheritance" %}}
Gdy ta sama własność jest zdefiniowana na więcej niż jednym poziomie, wygrywa poziom bardziej szczegółowy. Na przykład, jeśli master i slajd układu definiują tło, slajdy oparte na tym układzie używają tła układu. Więcej informacji o slajdach układu znajdziesz w [Apply or Change Slide Layouts](/slides/pl/cpp/slide-layout/).
{{% /alert %}}

## **Uzyskiwanie dostępu do masterów slajdów**

W PowerPoint możesz otworzyć widok Master slajdu z **View** > **Slide Master**.

![The Slide Master command on the PowerPoint View tab](slide-master_3.jpg)

W Aspose.Slides użyj kolekcji `get_Masters()` aby uzyskać dostęp do masterów slajdów:

```cpp
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto firstMasterSlide = presentation->get_Master(0);
auto masterSlideCount = presentation->get_Masters()->get_Count();
auto firstMasterLayoutSlideCount = firstMasterSlide->get_LayoutSlides()->get_Count();

System::Console::WriteLine(System::String(u"Master slides: ") + masterSlideCount);
System::Console::WriteLine(System::String(u"Layouts in the first master: ") + firstMasterLayoutSlideCount);

presentation->Dispose();
```

Możesz także pobrać master slajd używany przez normalny slajd poprzez jego układ:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto slide = presentation->get_Slide(0);
auto layoutSlide = slide->get_LayoutSlide();
auto masterSlide = layoutSlide->get_MasterSlide();
auto masterSlideName = masterSlide->get_Name();

System::Console::WriteLine(masterSlideName);

presentation->Dispose();
```

## **Co zawiera master slajd**

Master slajd jest obiektem podobnym do slajdu. Implementuje [IBaseSlide](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ibaseslide/), więc udostępnia wiele tych samych własności slajdu używanych przez slajdy normalne i układy. Członkowie specyficzni dla mastera są wymienieni na stronie API [IMasterSlide](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imasterslide/).

Często używane członki mastera slajdu to:

| Członek | Cel |
| --- | --- |
| `get_Background()` | Ustawia tło mastera slajdu. |
| `get_Shapes()` | Przechowuje kształty umieszczone na masterze, takie jak loga, ramki obrazów i współdzielony tekst. |
| `get_LayoutSlides()` | Przechowuje slajdy układu należące do mastera. |
| `get_ThemeManager()` | Udostępnia dostęp do API motywu mastera. |
| `get_HeaderFooterManager()` | Kontroluje nagłówki, stopki, daty i numery slajdów dla mastera i jego układów podrzędnych. |
| `GetDependingSlides()` | Zwraca slajdy normalne, które zależą od mastera poprzez ich układy. |

## **Dodanie obrazu do mastera slajdu**

Gdy dodasz obraz do mastera slajdu, pojawi się on na slajdach korzystających z układów z tego mastera. Jest to przydatne dla logo, znaków wodnych, ozdobnych pasków i innych powtarzających się elementów graficznych.

Poniższy przykład dodaje logo do pierwszego mastera slajdu:

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto logoBytes = System::IO::File::ReadAllBytes(u"logo.png");
auto logoImage = presentation->get_Images()->AddImage(logoBytes);

masterSlide->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle,
    20.0f,
    20.0f,
    80.0f,
    80.0f,
    logoImage);

presentation->Save(u"presentation-with-logo.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Więcej informacji o ramkach obrazów znajdziesz w [Picture Frame](/slides/pl/cpp/picture-frame/).

## **Kontrola widoczności grafiki mastera**

Użyj [IBaseSlide::set_ShowMasterShapes](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ibaseslide/set_showmastershapes/), aby ukryć dziedziczoną grafikę mastera, taką jak loga lub ozdobne kształty, bez usuwania ich z mastera. Przekaż `false` do [Slide::set_ShowMasterShapes](https://reference.aspose.com/slides/pl/cpp/aspose.slides/slide/set_showmastershapes/) na slajdzie, który ma pominąć tę grafikę, oraz `true` na slajdach, które mają ją wyświetlać.

Poniższy samodzielny przykład tworzy niebieski ozdobny pasek na masterze i dwóch slajdach korzystających z tego samego pustego układu. Pasek jest widoczny na pierwszym slajdzie i ukryty na drugim. Nie wymaga żadnej wejściowej prezentacji ani obrazu.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILineFormat.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);
auto layoutSlide = masterSlide->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
layoutSlide->set_ShowMasterShapes(true);

auto slideHeight = presentation->get_SlideSize()->get_Size().get_Height();
auto band = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0.0f, 0.0f, 60.0f, slideHeight);
band->get_FillFormat()->set_FillType(FillType::Solid);
band->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_SteelBlue());
band->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

auto visibleSlide = presentation->get_Slide(0);
visibleSlide->set_LayoutSlide(layoutSlide);
visibleSlide->get_Shapes()->Clear();

auto hiddenSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);

visibleSlide->set_ShowMasterShapes(true);
hiddenSlide->set_ShowMasterShapes(false);

presentation->Save(u"master-graphics.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Przykład używa układu **Blank** dostarczonego z nową prezentacją i usuwa początkowe pola zastępcze ze slajdu.

### **Wybór zakresu ustawienia**

Normalny slajd używa swojego mastera przez [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islide/get_layoutslide/) oraz [ILayoutSlide::get_MasterSlide](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilayoutslide/get_masterslide/). Ustawienie własności na pojedynczym slajdzie wpływa tylko na ten slajd. Przekazanie `false` do [LayoutSlide::set_ShowMasterShapes](https://reference.aspose.com/slides/pl/cpp/aspose.slides/layoutslide/set_showmastershapes/) ukrywa grafikę mastera dla wszystkich slajdów używających tego wspólnego układu, nawet jeśli ich własne ustawienie jest `true`. Aby ukryć grafikę tylko na jednym slajdzie, zmień własność slajdu i pozostaw niezmieniony wspólny układ.

Ustawienie nie jest obsługiwane jako kontrola widoczności bezpośrednio na masterze. Na masterze zawsze zwraca `false`, a przypisanie `true` powoduje `System::NotSupportedException`. Zastosuj je do normalnego slajdu lub układu.

### **Rozróżnienie grafiki od tła**

| Operacja | Efekt |
| --- | --- |
| Ukryj grafikę mastera | Kontroluje widoczność dziedziczonych kształtów mastera bez ich usuwania ani zmiany własnych kształtów slajdu. |
| Zmień wypełnienie tła slajdu | Zmienia kolor, gradient lub obraz tła. Grafika mastera to osobne kształty i może pozostać widoczna nad tym tłem. Zobacz [Presentation Background](/slides/pl/cpp/presentation-background/). |
| Usuń kształt z mastera | Usuwa współdzielony kształt źródłowy, więc nie jest już dostępny dla żadnego slajdu używającego tego mastera. |

## **Praca z polami zastępczymi**

Pola zastępcze są zwykle definiowane na slajdach układu. Master slajd zapewnia współdzielony styl i motyw, które te układy dziedziczą, podczas gdy każdy układ decyduje, które pola są dostępne i gdzie są umieszczone.

W PowerPoint polecenia pól zastępczych są dostępne w widoku Master slajdu.

![The Insert Placeholder command in PowerPoint Slide Master view](slide-master_5.png)

Aby dodać nowe pola zastępcze w Aspose.Slides, pracuj ze slajdem układu należącym do mastera:

```cpp
#include <DOM/ILayoutPlaceholderManager.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto blankLayoutSlide = masterSlide->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (blankLayoutSlide == nullptr)
{
    blankLayoutSlide = masterSlide->get_LayoutSlides()->Add(SlideLayoutType::Blank, u"Blank");
}

blankLayoutSlide->get_PlaceholderManager()->AddTextPlaceholder(
    60.0f,
    120.0f,
    600.0f,
    80.0f);

presentation->get_Slides()->AddEmptySlide(blankLayoutSlide);
presentation->Save(u"presentation-with-placeholder.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Możesz także formatować kształty pól zastępczych, które już istnieją na masterze. Poniższy przykład znajduje pole zastępcze tytułu i stosuje liniowy gradient:

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShapeCollection.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
System::SharedPtr<IAutoShape> titlePlaceholder;

for (auto&& shape : masterSlide->get_Shapes())
{
    auto autoShape = System::AsCast<IAutoShape>(shape);

    if (autoShape != nullptr &&
        autoShape->get_Placeholder() != nullptr &&
        autoShape->get_Placeholder()->get_Type() == PlaceholderType::Title)
    {
        titlePlaceholder = autoShape;
        break;
    }
}

if (titlePlaceholder != nullptr)
{
    auto fillFormat = titlePlaceholder->get_FillFormat();
    fillFormat->set_FillType(FillType::Gradient);

    auto gradientFormat = fillFormat->get_GradientFormat();
    gradientFormat->set_GradientShape(GradientShape::Linear);

    auto gradientStops = gradientFormat->get_GradientStops();
    auto redGradientColor = System::Drawing::Color::FromArgb(255, 0, 0);
    auto purpleGradientColor = System::Drawing::Color::FromArgb(128, 0, 128);

    gradientStops->Add(0.0f, redGradientColor);
    gradientStops->Add(255.0f, purpleGradientColor);
}

presentation->Save(u"presentation-title-style.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Formatted title placeholder inherited by normal slides](slide-master_8.png)

Więcej opcji formatowania pól zastępczych i tekstu znajdziesz w [Set Prompt Text in Placeholder](/slides/pl/cpp/manage-placeholder/) oraz [Text Formatting](/slides/pl/cpp/text-formatting/).

## **Zmiana tła mastera slajdu**

Tło mastera jest dziedziczone przez układy i slajdy, które go nie nadpisują. Poniższy przykład ustawia jednolity kolor tła dla pierwszego mastera slajdu:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto masterBackgroundColor = System::Drawing::Color::get_ForestGreen();

masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(masterBackgroundColor);

presentation->Save(u"presentation-master-background.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Powiązane tematy: [Presentation Background](/slides/pl/cpp/presentation-background/) i [Presentation Theme](/slides/pl/cpp/presentation-theme/).

## **Klonnowanie mastera slajdu do innej prezentacji**

Użyj [IMasterSlideCollection::AddClone](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imasterslidecollection/addclone/), aby skopiować master slajd do innej prezentacji. Skopiowany master może być następnie używany przez układy i slajdy w docelowej prezentacji.

```cpp
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto sourcePresentation = System::MakeObject<Presentation>(u"source.pptx");
auto destinationPresentation = System::MakeObject<Presentation>(u"destination.pptx");

auto sourceMasterSlide = sourcePresentation->get_Master(0);
auto clonedMasterSlide = destinationPresentation->get_Masters()->AddClone(sourceMasterSlide);

destinationPresentation->Save(u"destination-with-master.pptx", SaveFormat::Pptx);
destinationPresentation->Dispose();
sourcePresentation->Dispose();
```

Jeśli potrzebujesz sklonować slajdy normalne razem z ich masterem, zobacz [Clone Slides](/slides/pl/cpp/clone-slides/).

## **Dodawanie wielu masterów slajdów**

Prezentacja może zawierać wiele masterów slajdów. Jest to przydatne, gdy różne sekcje wymagają odmiennych identyfikacji wizualnych, struktury stron lub ustawień motywu.

![PowerPoint commands for inserting and managing master slides](slide-master_9.jpg)

Poniższy przykład klonuje domyślny master, nadaje klonowi inne tło, tworzy układ pod tym sklonowanym masterem i dodaje nowy slajd oparty na tym układzie:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto defaultMasterSlide = presentation->get_Master(0);
auto sectionMasterSlide = presentation->get_Masters()->AddClone(defaultMasterSlide);
auto sectionMasterBackgroundColor = System::Drawing::Color::get_LightSteelBlue();

sectionMasterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
sectionMasterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
sectionMasterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(sectionMasterBackgroundColor);

auto sourceBlankLayout = defaultMasterSlide->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (sourceBlankLayout == nullptr)
{
    sourceBlankLayout = defaultMasterSlide->get_LayoutSlide(0);
}

auto sectionBlankLayout = sectionMasterSlide->get_LayoutSlides()->AddClone(sourceBlankLayout);

presentation->get_Slides()->AddEmptySlide(sectionBlankLayout);
presentation->Save(u"presentation-with-multiple-masters.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Porównywanie masterów slajdów**

Mastery slajdów można porównać metodą `Equals` odziedziczoną po [IBaseSlide](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ibaseslide/). Porównanie sprawdza strukturę i statyczną zawartość, taką jak kształty, tekst, formatowanie, animacje i inne ustawienia slajdu. Nie porównuje unikalnych identyfikatorów, takich jak ID slajdu, ani dynamicznych wartości pól zastępczych, takich jak bieżąca data.

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto firstPresentation = System::MakeObject<Presentation>(u"first.pptx");
auto secondPresentation = System::MakeObject<Presentation>(u"second.pptx");
auto firstPresentationMasterCount = firstPresentation->get_Masters()->get_Count();
auto secondPresentationMasterCount = secondPresentation->get_Masters()->get_Count();

for (int32_t firstMasterIndex = 0;
     firstMasterIndex < firstPresentationMasterCount;
     firstMasterIndex++)
{
    for (int32_t secondMasterIndex = 0;
         secondMasterIndex < secondPresentationMasterCount;
         secondMasterIndex++)
    {
        auto firstMasterSlide = firstPresentation->get_Master(firstMasterIndex);
        auto secondMasterSlide = secondPresentation->get_Master(secondMasterIndex);
        auto areMasterSlidesEqual = firstMasterSlide->Equals(secondMasterSlide);

        if (areMasterSlidesEqual)
        {
            System::Console::WriteLine(
                System::String::Format(
                    u"first.pptx master #{0} equals second.pptx master #{1}",
                    firstMasterIndex,
                    secondMasterIndex));
        }
    }
}

secondPresentation->Dispose();
firstPresentation->Dispose();
```

Więcej informacji znajdziesz w [Compare Presentation Slides](/slides/pl/cpp/compare-slides/).

## **Ustawienie widoku Master slajdu jako widoku domyślnego**

Użyj metody `set_LastView` na [ViewProperties](https://reference.aspose.com/slides/pl/cpp/aspose.slides/viewproperties/), aby kontrolować widok, który PowerPoint otwiera jako pierwszy. Poniższy przykład otwiera prezentację w widoku Master slajdu:

```cpp
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <ViewType.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);
presentation->Save(u"presentation-master-view.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Więcej ustawień widoku znajdziesz w [Save Presentation](/slides/pl/cpp/save-presentation/).

## **Usuwanie nieużywanych masterów slajdów**

Prezentacje czasami zawierają mastery slajdów, które nie są używane przez żadne slajdy normalne. Usunięcie nieużywanych masterów może zmniejszyć rozmiar pliku i uprościć utrzymanie szablonów.

Użyj [MasterSlideCollection::RemoveUnused](https://reference.aspose.com/slides/pl/cpp/aspose.slides/masterslidecollection/removeunused/), aby usunąć nieużywane mastery z kolekcji `get_Masters()`:

```cpp
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_Masters()->RemoveUnused(true);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Możesz także użyć metody low-code [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/):

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(presentation);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Jaka jest różnica między masterem slajdu a slajdem układu?**

Master slajd definiuje współdzielone ustawienia projektu, takie jak motyw, tło, wspólne kształty i style tekstu. Slajd układu należy do mastera i definiuje określone rozmieszczenie pól zastępczych. Normalny slajd używa slajdu układu, więc dziedziczy zarówno z układu, jak i z mastera.

**Czy jedna prezentacja może zawierać kilka masterów slajdów?**

Tak. Prezentacja może zawierać kilka masterów slajdów. Używaj wielu masterów, gdy różne sekcje wymagają odmiennych systemów wizualnych lub identyfikacji marki.

**Czy powinienem dodawać pola zastępcze do mastera slajdu czy do slajdu układu?**

W większości przypadków dodawaj pola zastępcze do slajdów układu. Umieść wspólne elementy wizualne i współdzielone formatowanie na masterze, a pola zawartości na układach, z których będą korzystać slajdy normalne.

**Czy mogę usunąć master slajd, który jest nadal używany?**

Nie. Master slajd, który ma zależne slajdy, nie może być bezpiecznie usunięty bezpośrednio. Najpierw przenieś te slajdy do układów pod innym masterem lub użyj metody czyszczenia nieużywanych masterów, która usuwa tylko mastery niebędące w użyciu.