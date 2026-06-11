---
title: Zarządzaj znakami miejsc prezentacji w C++
linktitle: Zarządzaj znakami miejsc
type: docs
weight: 10
url: /pl/cpp/manage-placeholder/
keywords:
- znak zastępczy
- znak tekstowy
- znak obrazu
- znak wykresu
- tekst podpowiedzi
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Bezproblemowo zarządzaj znakami miejsc w Aspose.Slides dla C++: zamieniaj tekst, dostosowuj podpowiedzi i ustawiaj przezroczystość obrazu w PowerPoint i OpenDocument."
---
## **Przegląd**

Aspose.Slides pozwala zarządzać znakowymi miejscami prezentacji programowo. Ten artykuł wyjaśnia, jak znaleźć znaki miejsc na slajdach i zmienić ich tekst, ustawić własny tekst podpowiedzi dla układów znaków miejsc oraz dostosować przezroczystość obrazu używanego jako tło znaku miejsca. Zawiera także krótkie FAQ, które wyjaśnia różnicę między podstawowymi znakami miejsc a lokalnymi kształtami, opisuje, jak zmiany znaków miejsc mogą być stosowane przez układy lub wzorce, oraz wskazuje zarządzanie znakami miejsc nagłówka i stopki.

## **Zmienianie tekstu w znaku miejsca**
Korzystając z [Aspose.Slides for C++](/slides/pl/cpp/), możesz znajdować i modyfikować znaki miejsc na slajdach w prezentacjach. Aspose.Slides umożliwia wprowadzanie zmian w tekście znaku miejsca.

**Wymaganie wstępne**: Potrzebujesz prezentacji zawierającej znak miejsca. Taką prezentację możesz stworzyć w standardowej aplikacji Microsoft PowerPoint.

Tak możesz użyć Aspose.Slides, aby zastąpić tekst w znaku miejsca w tej prezentacji:

1. Utwórz instancję klasy [`Presentation`](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation/) i przekaż prezentację jako argument.
2. Uzyskaj odwołanie do slajdu przez jego indeks.
3. Iteruj po kształtach, aby znaleźć znak miejsca.
4. Rzutuj kształt znaku miejsca na [`AutoShape`](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.auto_shape/) i zmień tekst przy użyciu [`TextFrame`](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.text_frame/), powiązanego z [`AutoShape`](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.auto_shape/).
5. Zapisz zmodyfikowaną prezentację.

Ten kod C++ pokazuje, jak zmienić tekst w znaku miejsca:

```c++
// Ścieżka do katalogu dokumentów.
const String outPath = u"../out/ReplacingText_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// Ładuje żądaną prezentację
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// Uzyskuje dostęp do pierwszego slajdu
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Uzyskuje dostęp do pierwszego i drugiego znaku miejsca na slajdzie i rzutuje go jako AutoShape
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);
SharedPtr<AutoShape> ashp = ExplicitCast<Aspose::Slides::AutoShape>(shape);

SharedPtr<ITextFrame> textframe = ashp->get_TextFrame();

textframe->set_Text(u"This is Placeholder");
    
// Zapisuje prezentację na dysku
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Ustawianie tekstu podpowiedzi w znaku miejsca**
Standardowe i wbudowane układy zawierają teksty podpowiedzi znaków miejsc, takie jak ***Kliknij, aby dodać tytuł*** lub ***Kliknij, aby dodać podtytuł***. Korzystając z Aspose.Slides, możesz wstawić własne teksty podpowiedzi do układów znaków miejsc.

Ten kod C++ pokazuje, jak ustawić tekst podpowiedzi w znaku miejsca:

```c++
const System::String templatePath = u"../templates/Presentation2.pptx";
    
auto pres = System::MakeObject<Presentation>(templatePath);
auto slide = pres->get_Slides()->idx_get(0);

for (auto& shape : slide->get_Shapes())
{
    if (shape->get_Placeholder() != NULL)
    {
        System::String text = u"";
        if (shape->get_Placeholder()->get_Type() == PlaceholderType::CenteredTitle) // Gdy nie ma w nim tekstu, PowerPoint wyświetla "Click to add title". 
        {
            text = u"Click to add title";
        }
        else if (shape->get_Placeholder()->get_Type() == PlaceholderType::Subtitle) // Robi to samo dla podtytułu.
        {
            text = u"Click to add subtitle";
        }
        System::Console::WriteLine(u"Placeholder : {0}", text);
    }
}

pres->Save(u"../out/Placeholders_PromptText.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Ustawianie przezroczystości obrazu w znaku miejsca**

Aspose.Slides umożliwia ustawienie przezroczystości obrazu tła w znaku miejsca tekstowego. Dostosowując przezroczystość obrazu w takim ramce, możesz uwydatnić tekst lub obraz (w zależności od kolorów tekstu i obrazu).

Ten kod C++ pokazuje, jak ustawić przezroczystość tła obrazu (wewnątrz kształtu):

```c++
auto presentation = System::MakeObject<Presentation>();
    
auto autoShape = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);
    
auto fillFormat = autoShape->get_FillFormat();
fillFormat->set_FillType(Aspose::Slides::FillType::Picture);
fillFormat->get_PictureFillFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(System::IO::File::ReadAllBytes(u"image.png")));

auto pictureFillFormat = fillFormat->get_PictureFillFormat();
pictureFillFormat->set_PictureFillMode(Aspose::Slides::PictureFillMode::Stretch);
pictureFillFormat->get_Picture()->get_ImageTransform()->AddAlphaModulateFixedEffect(75.0f);
```

## **FAQ**

**Czym jest podstawowy znak miejsca i jak różni się od lokalnego kształtu na slajdzie?**

Podstawowy znak miejsca to oryginalny kształt w układzie lub szablonie, z którego dziedziczy kształt slajdu — typ, pozycja i niektóre formatowanie pochodzą z niego. Lokalny kształt jest niezależny; jeśli nie ma podstawowego znaku miejsca, dziedziczenie nie ma zastosowania.

**Jak mogę zaktualizować wszystkie tytuły lub podpisy w całej prezentacji bez iteracji po każdym slajdzie?**

Edytuj odpowiedni znak miejsca w układzie lub szablonie. Slajdy oparte na tych układach/szablonie automatycznie odziedziczą zmianę.

**Jak zarządzać standardowymi znakami miejsc nagłówka/stopki — datą i godziną, numerem slajdu oraz tekstem stopki?**

Użyj menedżerów HeaderFooter w odpowiednim zakresie (zwykłe slajdy, układy, szablon, notatki/rozdania), aby włączyć lub wyłączyć te znaki miejsca i ustawić ich zawartość.