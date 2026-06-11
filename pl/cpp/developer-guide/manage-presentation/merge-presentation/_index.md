---
title: Efektywne łączenie prezentacji w C++
linktitle: Łączenie prezentacji
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
description: "Bezproblemowo scal prezentacje PowerPoint (PPT, PPTX) i OpenDocument (ODP) przy użyciu Aspose.Slides dla C++, usprawniając Twój przepływ pracy."
---
## **Przegląd**

Aspose.Slides umożliwia łączenie prezentacji poprzez klonowanie slajdów z jednej prezentacji do drugiej. Ten artykuł wyjaśnia, jak łączyć całe prezentacje lub wybrane slajdy, używać szablonu masterowego lub określonego układu podczas łączenia, obsługiwać prezentacje o różnych rozmiarach slajdów oraz dodawać połączone slajdy do sekcji prezentacji. Omówione są również praktyczne uwagi dotyczące połączonej zawartości, w tym notatki prelegenta, komentarze, pliki źródłowe zabezpieczone hasłem oraz użycie wątków.

## **Łączenie prezentacji**

Podczas łączenia jednej prezentacji z drugą, efektywnie łączysz ich slajdy w jednej prezentacji, uzyskując jeden plik. 

{{% alert title="Info" color="info" %}}

Większość programów do tworzenia prezentacji (PowerPoint lub OpenOffice) nie posiada funkcji umożliwiających użytkownikom łączenie prezentacji w taki sposób. 

[**Aspose.Slides for C++**](https://products.aspose.com/slides/pl/cpp/), jednakże, pozwala łączyć prezentacje na różne sposoby. Możesz połączyć prezentacje ze wszystkimi ich kształtami, stylami, tekstami, formatowaniem, komentarzami, animacjami itp., nie martwiąc się o utratę jakości czy danych. 

**Zobacz także**

[Clone Slides](https://docs.aspose.com/slides/pl/cpp/clone-slides/)*.* 

{{% /alert %}}

### **Co można łączyć**

Za pomocą Aspose.Slides możesz łączyć 

* całe prezentacje. Wszystkie slajdy z prezentacji trafiają do jednej prezentacji
* wybrane slajdy. Wybrane slajdy trafiają do jednej prezentacji
* prezentacje w jednym formacie (PPT do PPT, PPTX do PPTX itp.) oraz w różnych formatach (PPT do PPTX, PPTX do ODP itp.) ze sobą. 

{{% alert title="Note" color="warning" %}} 

Oprócz prezentacji, Aspose.Slides pozwala łączyć inne pliki:

* [Images](https://products.aspose.com/slides/pl/cpp/merger/image-to-image/), takie jak [JPG to JPG](https://products.aspose.com/slides/pl/cpp/merger/jpg-to-jpg/) lub [PNG to PNG](https://products.aspose.com/slides/pl/cpp/merger/png-to-png/)
* Dokumenty, takie jak [PDF to PDF](https://products.aspose.com/slides/pl/cpp/merger/pdf-to-pdf/) lub [HTML to HTML](https://products.aspose.com/slides/pl/cpp/merger/html-to-html/)
* Dwa różne pliki, na przykład [image to PDF](https://products.aspose.com/slides/pl/cpp/merger/image-to-pdf/) lub [JPG to PDF](https://products.aspose.com/slides/pl/cpp/merger/jpg-to-pdf/) lub [TIFF to PDF](https://products.aspose.com/slides/pl/cpp/merger/tiff-to-pdf/).

{{% /alert %}}

### **Opcje łączenia**

Możesz zastosować opcje określające, czy

* każdy slajd w prezentacji wynikowej zachowuje unikalny styl
* konkretny styl jest używany dla wszystkich slajdów w prezentacji wynikowej. 

Aby połączyć prezentacje, Aspose.Slides udostępnia metody [AddClone](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) (z interfejsu [ISlideCollection](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_slide_collection)). Istnieje kilka implementacji metod `AddClone`, które definiują parametry procesu łączenia prezentacji. Każdy obiekt Presentation posiada kolekcję [Slides](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c), więc możesz wywołać metodę `AddClone` z prezentacji, do której chcesz dodać slajdy. 

Metoda `AddClone` zwraca obiekt `ISlide`, będący klonem slajdu źródłowego. Slajdy w prezentacji wynikowej są po prostu kopią slajdów ze źródła. Dzięki temu możesz zmieniać wynikowe slajdy (np. stosować style, opcje formatowania lub układy), nie martwiąc się o wpływ na prezentacje źródłowe. 

## **Łączenie prezentacji** 

Aspose.Slides udostępnia metodę [**AddClone (ISlide)**](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee), która pozwala połączyć slajdy, zachowując ich układy i style (domyślne parametry). 

Ten kod C++ pokazuje, jak połączyć prezentacje:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Łączenie prezentacji przy użyciu szablonu masterowego slajdów**

Aspose.Slides udostępnia metodę [**AddClone (ISlide, IMasterSlide, bool)**](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_slide_collection#a6b040e6b30f52ab4644fafdbc650b640), która pozwala połączyć slajdy, stosując szablon prezentacji masterowej. Dzięki temu, w razie potrzeby, możesz zmienić styl slajdów w prezentacji wynikowej. 

Ten kod w C++ demonstruje opisaną operację:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_Masters()->idx_get(0), true);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 

Układ slajdu masterowego jest określany automatycznie. Gdy nie można określić odpowiedniego układu, a parametr boolowski `allowCloneMissingLayout` metody `AddClone` jest ustawiony na true, używany jest układ slajdu źródłowego. W przeciwnym razie zostanie rzucony wyjątek [PptxEditException](https://reference.aspose.com/slides/pl/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d). 

{{% /alert %}}

Jeśli chcesz, aby slajdy w prezentacji wynikowej miały inny układ, użyj metody [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_slide_collection#a0ed5909b2d92555159007046760ff2f1) podczas łączenia. 

## **Łączenie wybranych slajdów z prezentacji**

Łączenie wybranych slajdów z wielu prezentacji jest przydatne przy tworzeniu niestandardowych zestawów slajdów. Aspose.Slides C++ pozwala wybrać i zaimportować tylko potrzebne slajdy. API zachowuje formatowanie, układ i projekt oryginalnych slajdów.

Poniższy kod C++ tworzy nową prezentację, dodaje slajdy tytułowe z dwóch innych prezentacji i zapisuje wynik do pliku:

```cpp
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

## **Łączenie prezentacji przy użyciu układu slajdu**

Ten kod C++ pokazuje, jak połączyć slajdy z prezentacji, stosując wybrany układ slajdu, aby uzyskać jedną prezentację wynikową:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_LayoutSlides()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Łączenie prezentacji o różnym rozmiarze slajdów**

{{% alert title="Note" color="warning" %}} 

Nie można łączyć prezentacji o różnych rozmiarach slajdów. 

{{% /alert %}}

Aby połączyć 2 prezentacje o różnych rozmiarach slajdów, należy zmienić rozmiar jednej z prezentacji, aby dopasować go do rozmiaru drugiej. 

Ten przykładowy kod demonstruje opisaną operację:

```cpp
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

## **Łączenie slajdów do sekcji prezentacji**

Ten kod C++ pokazuje, jak połączyć określony slajd z sekcją w prezentacji:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (int32_t index = 0; index < pres2->get_Slides()->get_Count(); index++)
{
    auto slide = pres2->get_Slides()->idx_get(index);
    pres1->get_Slides()->AddClone(slide, pres1->get_Sections()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

Slajd zostaje dodany na końcu sekcji. 

{{% alert title="Tip" color="primary" %}}

Aspose udostępnia [DARMOWĄ aplikację webową Collage](https://products.aspose.app/slides/pl/collage). Korzystając z tej usługi online, możesz łączyć [JPG to JPG](https://products.aspose.app/slides/pl/collage/jpg) lub obrazy PNG do PNG, tworzyć [siatki zdjęć](https://products.aspose.app/slides/pl/collage/photo-grid) i tak dalej. 

{{% /alert %}}

## **FAQ**

**Czy notatki prelegenta są zachowywane podczas łączenia?**

Tak. Przy klonowaniu slajdów Aspose.Slides przenosi wszystkie elementy slajdu, w tym notatki, formatowanie i animacje.

**Czy komentarze i ich autorzy są przenoszeni?**

Komentarze, jako część zawartości slajdu, są kopiowane razem ze slajdem. Etykiety autorów komentarzy są zachowywane jako obiekty komentarzy w wynikowej prezentacji.

**Co zrobić, jeśli prezentacja źródłowa jest zabezpieczona hasłem?**

Należy ją [otworzyć przy użyciu hasła](/slides/pl/cpp/password-protected-presentation/) za pomocą [LoadOptions::set_Password](https://reference.aspose.com/slides/pl/cpp/aspose.slides/loadoptions/set_password/); po załadowaniu te slajdy mogą być bezpiecznie klonowane do niechronionego pliku docelowego (lub również chronionego).

**Jak bezpieczna jest operacja łączenia w kontekście wątków?**

Nie używaj tej samej instancji [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) z [wielu wątków](/slides/pl/cpp/multithreading/). Zalecana zasada to „jeden dokument — jeden wątek”; różne pliki można przetwarzać równolegle w oddzielnych wątkach.