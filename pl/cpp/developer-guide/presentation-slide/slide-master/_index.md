---
title: Zarządzanie wzorcami slajdów w C++
linktitle: Wzorzec slajdu
type: docs
weight: 80
url: /pl/cpp/slide-master/
keywords:
- wzorzec slajdu
- slajd wzorca
- slajd wzorca PPT
- wiele wzorców slajdów
- porównaj wzorce slajdów
- tło
- element zastępczy
- klonuj wzorzec slajdu
- kopiuj wzorzec slajdu
- duplikuj wzorzec slajdu
- nieużywany wzorzec slajdu
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Zarządzaj wzorcami slajdów w Aspose.Slides dla C++: uzyskaj dostęp, edytuj, klonuj, porównuj i usuwaj wzorce slajdów w prezentacjach PowerPoint i OpenDocument."
---
## **Przegląd**

**Wzorzec slajdu** definiuje wspólne ustawienia projektowe dla grupy slajdów. Może zawierać wspólne kształty, logotypy, tła, style tekstu, ustawienia motywu oraz stopki. W PowerPoint edycja wzorca slajdu jest typowym sposobem zapewnienia spójności prezentacji bez powtarzania tego samego formatowania na każdym slajdzie.

Aspose.Slides dla C++ obsługuje ten sam model. Prezentacja może zawierać jeden lub więcej wzorców slajdów, a każdy wzorzec może zawierać kilka slajdów układu. Zwykłe slajdy zazwyczaj nie odwołują się bezpośrednio do wzorca. Zamiast tego używają slajdu układu, a ten slajd układu należy do wzorca.

Hierarchia wygląda następująco:

1. **Wzorzec slajdu** – definiuje współdzielony projekt i motyw.  
1. **Slajd układu** – definiuje konkretne rozmieszczenie elementów zastępczych i formatowanie na poziomie układu.  
1. **Zwykły slajd** – zawiera rzeczywistą treść prezentacji i korzysta z jednego slajdu układu.

![Hierarchia wzorców slajdów, slajdów układu i zwykłych slajdów](slide-master_2.jpg)

W Aspose.Slides wzorzec slajdu jest reprezentowany przez interfejs [IMasterSlide](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imasterslide/). Wszystkie wzorce slajdów w prezentacji są dostępne przez kolekcję [Presentation::get_Masters](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/get_masters/), która implementuje [IMasterSlideCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imasterslidecollection/).

{{% alert color="info" title="Dziedziczenie" %}}

Gdy ta sama właściwość jest zdefiniowana na więcej niż jednym poziomie, wygrywa poziom bardziej szczegółowy. Na przykład, jeśli wzorzec i slajd układu definiują tło, slajdy oparte na tym układzie użyją tła układu. Więcej informacji o slajdach układu znajdziesz w artykule [Apply or Change Slide Layouts](/slides/pl/cpp/slide-layout/).

{{% /alert %}}

## **Dostęp do wzorców slajdów**

W PowerPoint możesz otworzyć widok Wzorca slajdu z **Widok** > **Wzorzec slajdu**.

![Polecenie Wzorzec slajdu na karcie Widok w PowerPoint](slide-master_3.jpg)

W Aspose.Slides użyj kolekcji `get_Masters()` aby uzyskać dostęp do wzorców slajdów:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto firstMasterSlide = presentation->get_Master(0);
auto masterSlideCount = presentation->get_Masters()->get_Count();
auto firstMasterLayoutSlideCount = firstMasterSlide->get_LayoutSlides()->get_Count();

System::Console::WriteLine(System::String(u"Master slides: ") + masterSlideCount);
System::Console::WriteLine(System::String(u"Layouts in the first master: ") + firstMasterLayoutSlideCount);

presentation->Dispose();
```

Możesz także pobrać wzorzec slajdu używany przez zwykły slajd poprzez jego układ:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto slide = presentation->get_Slide(0);
auto layoutSlide = slide->get_LayoutSlide();
auto masterSlide = layoutSlide->get_MasterSlide();
auto masterSlideName = masterSlide->get_Name();

System::Console::WriteLine(masterSlideName);

presentation->Dispose();
```

## **Co zawiera wzorzec slajdu**

Wzorzec slajdu jest obiektem podobnym do slajdu. Implementuje [IBaseSlide](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ibaseslide/), więc udostępnia wiele tych samych właściwości slajdu używanych przez zwykłe i układowe slajdy. Członkowie specyficzni dla wzorca są wymienieni na stronie API [IMasterSlide](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imasterslide/).

Często używane członki wzorca slajdu to:

| Członek | Cel |
| --- | --- |
| `get_Background()` | Ustawia tło slajdu na poziomie wzorca. |
| `get_Shapes()` | Przechowuje kształty umieszczone na wzorcu, takie jak logotypy, ramki obrazu i wspólny tekst. |
| `get_LayoutSlides()` | Przechowuje slajdy układu należące do wzorca. |
| `get_ThemeManager()` | Zapewnia dostęp do interfejsów API motywu wzorca. |
| `get_HeaderFooterManager()` | Steruje nagłówkami, stopkami, datami i numerami slajdów dla wzorca oraz jego układów podrzędnych. |
| `GetDependingSlides()` | Zwraca zwykłe slajdy, które zależą od wzorca poprzez ich układy. |

## **Dodanie obrazu do wzorca slajdu**

Gdy dodasz obraz do wzorca slajdu, pojawi się on na slajdach korzystających z układów tego wzorca. Jest to przydatne przy logotypach, znakach wodnych, dekoracyjnych pasach i innych powtarzających się elementach graficznych.

Poniższy przykład dodaje logo do pierwszego wzorca slajdu:

```cpp
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

Więcej informacji o ramkach obrazu znajdziesz w artykule [Picture Frame](/slides/pl/cpp/picture-frame/).

## **Praca z elementami zastępczymi**

Elementy zastępcze są zazwyczaj definiowane na slajdach układu. Wzorzec slajdu zapewnia wspólny styl i motyw, które te układy dziedziczą, a każdy układ decyduje, które elementy zastępcze są dostępne i gdzie są umieszczone.

W PowerPoint polecenia elementów zastępczych są dostępne w widoku Wzorca slajdu.

![Polecenie Wstaw element zastępczy w widoku Wzorzec slajdu w PowerPoint](slide-master_5.png)

Aby dodać nowe elementy zastępcze w Aspose.Slides, pracuj ze slajdem układu należącym do wzorca:

```cpp
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

Możesz także sformatować istniejące już na wzorcu kształty zastępcze. Poniższy przykład znajduje element zastępczy tytułu i stosuje wypełnienie gradientem liniowym:

```cpp
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

![Sformatowany element zastępczy tytułu dziedziczony przez zwykłe slajdy](slide-master_8.png)

Więcej opcji formatowania elementów zastępczych i tekstu znajdziesz w artykułach [Set Prompt Text in Placeholder](/slides/pl/cpp/manage-placeholder/) oraz [Text Formatting](/slides/pl/cpp/text-formatting/).

## **Zmiana tła wzorca slajdu**

Tło wzorca jest dziedziczone przez układy i slajdy, które go nie nadpisują. Poniższy przykład ustawia jednolity kolor tła dla pierwszego wzorca slajdu:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto masterBackgroundColor = System::Drawing::Color::get_ForestGreen();

masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(masterBackgroundColor);

presentation->Save(u"presentation-master-background.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Powiązane tematy: [Presentation Background](/slides/pl/cpp/presentation-background/) oraz [Presentation Theme](/slides/pl/cpp/presentation-theme/).

## **Klonowanie wzorca slajdu do innej prezentacji**

Użyj [IMasterSlideCollection::AddClone](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imasterslidecollection/addclone/), aby skopiować wzorzec slajdu do innej prezentacji. Skopiowany wzorzec może następnie być używany przez układy i slajdy w prezentacji docelowej.

```cpp
auto sourcePresentation = System::MakeObject<Presentation>(u"source.pptx");
auto destinationPresentation = System::MakeObject<Presentation>(u"destination.pptx");

auto sourceMasterSlide = sourcePresentation->get_Master(0);
auto clonedMasterSlide = destinationPresentation->get_Masters()->AddClone(sourceMasterSlide);

destinationPresentation->Save(u"destination-with-master.pptx", SaveFormat::Pptx);
destinationPresentation->Dispose();
sourcePresentation->Dispose();
```

Jeśli potrzebujesz sklonować zwykłe slajdy wraz z ich wzorcem, zobacz [Clone Slides](/slides/pl/cpp/clone-slides/).

## **Dodawanie wielu wzorców slajdów**

Prezentacja może zawierać wiele wzorców slajdów. Jest to przydatne, gdy różne sekcje wymagają odmiennych identyfikacji wizualnych, struktury stron lub ustawień motywu.

![Polecenia PowerPoint służące do wstawiania i zarządzania wzorcami slajdów](slide-master_9.jpg)

Poniższy przykład klonuje domyślny wzorzec, nadaje klonowi inne tło, tworzy układ pod tym sklonowanym wzorcem i dodaje nowy slajd oparty na tym układzie:

```cpp
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

## **Porównywanie wzorców slajdów**

Wzorce slajdów można porównać metodą `Equals` odziedziczoną po [IBaseSlide](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ibaseslide/). Porównanie sprawdza strukturę oraz statyczną zawartość, taką jak kształty, tekst, formatowanie, animacje i inne ustawienia slajdu. Nie porównuje on unikalnych identyfikatorów, takich jak ID slajdu, ani dynamicznych wartości elementów zastępczych, np. bieżącej daty.

```cpp
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

Więcej informacji znajdziesz w artykule [Compare Presentation Slides](/slides/pl/cpp/compare-slides/).

## **Ustawienie widoku Wzorca slajdu jako widoku domyślnego**

Użyj metody `set_LastView` na [ViewProperties](https://reference.aspose.com/slides/pl/cpp/aspose.slides/viewproperties/), aby określić widok, który PowerPoint otwiera jako pierwszy. Poniższy przykład otwiera prezentację w widoku Wzorca slajdu:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);
presentation->Save(u"presentation-master-view.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Więcej ustawień widoku znajdziesz w artykule [Save Presentation](/slides/pl/cpp/save-presentation/).

## **Usuwanie nieużywanych wzorców slajdów**

Prezentacje czasami zawierają wzorce slajdów, które nie są już używane przez żadne zwykłe slajdy. Usunięcie nieużywanych wzorców może zmniejszyć rozmiar pliku i uprościć utrzymanie szablonu.

Użyj [MasterSlideCollection::RemoveUnused](https://reference.aspose.com/slides/pl/cpp/aspose.slides/masterslidecollection/removeunused/), aby usunąć nieużywane wzorce ze zbioru `get_Masters()`:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_Masters()->RemoveUnused(true);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Możesz także skorzystać z metody niskokodowej [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/):

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(presentation);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Jaka jest różnica między wzorcem slajdu a slajdem układu?**

Wzorzec slajdu definiuje wspólne ustawienia projektowe, takie jak motyw, tło, wspólne kształty i style tekstu. Slajd układu należy do wzorca i określa konkretne rozmieszczenie elementów zastępczych. Zwykły slajd używa slajdu układu, więc dziedziczy zarówno z układu, jak i z wzorca.

**Czy jedna prezentacja może zawierać kilka wzorców slajdów?**

Tak. Prezentacja może zawierać wiele wzorców slajdów. Używaj wielu wzorców, gdy różne sekcje wymagają odmiennych systemów wizualnych lub identyfikacji marki.

**Czy powinienem dodawać elementy zastępcze do wzorca slajdu czy do slajdu układu?**

W większości przypadków elementy zastępcze dodaje się do slajdów układu. Na wzorcu umieszczaj wspólne elementy graficzne i formatowanie, a na układach – miejsca przeznaczone na treść, które będą używane przez zwykłe slajdy.

**Czy mogę usunąć wzorzec slajdu, który jest nadal używany?**

Nie. Wzorzec, od którego zależą slajdy, nie może być bezpiecznie usunięty. Najpierw przenieś te slajdy do układów pod innym wzorcem lub skorzystaj z metody czyszczenia nieużywanych wzorców, która usuwa tylko te, które nie są używane.