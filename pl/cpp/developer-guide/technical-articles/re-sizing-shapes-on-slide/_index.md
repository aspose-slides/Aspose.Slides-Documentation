---
title: Zmiana rozmiaru kształtów na slajdach prezentacji
type: docs
weight: 100
url: /pl/cpp/re-sizing-shapes-on-slide/
keywords:
- zmień rozmiar kształtu
- zmień rozmiar kształtu
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Łatwo zmieniaj rozmiar kształtów na slajdach PowerPoint i OpenDocument za pomocą Aspose.Slides dla C++ - automatyzuj dostosowywanie układu slajdów i zwiększaj wydajność."
---
## **Przegląd**

Jednym z najczęstszych pytań klientów Aspose.Slides for C++ jest, jak zmienić rozmiar kształtów, aby przy zmianie rozmiaru slajdu dane nie były obcinane. Ten krótki artykuł techniczny pokazuje, jak to zrobić.

## **Zmiana rozmiaru kształtów**

Aby zapobiec nieprawidłowemu wyrównaniu kształtów przy zmianie rozmiaru slajdu, zaktualizuj pozycję i wymiary każdego kształtu, aby odpowiadały nowemu układowi slajdu.

```cpp
// Załaduj plik prezentacji.
auto presentation = MakeObject<Presentation>(u"sample.ppt");

// Get the original slide size.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Change the slide size without scaling existing shapes.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);

// Get the new slide size.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

// Resize and reposition shapes on every slide.
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // Skaluj rozmiar kształtu.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Skaluj pozycję kształtu.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="primary" %}} 
Jeśli slajd zawiera tabelę, powyższy kod nie będzie działał poprawnie. W takim przypadku każda komórka w tabeli musi zostać przeskalowana.
{{% /alert %}} 

Użyj poniższego kodu po swojej stronie, aby zmienić rozmiar slajdów zawierających tabele. Dla tabel ustawianie szerokości lub wysokości jest przypadkiem specjalnym: musisz dostosować wysokość poszczególnych wierszy i szerokość kolumn, aby zmienić ogólny rozmiar tabeli.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Pobierz oryginalny rozmiar slajdu.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Zmień rozmiar slajdu bez skalowania istniejących kształtów.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
//presentation.SlideSize.Orientation = SlideOrienation.Portrait;

// Pobierz nowy rozmiar slajdu.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

for (auto&& master : presentation->get_Masters())
{
    for (auto&& shape : master->get_Shapes())
    {
        // Skaluj rozmiar kształtu.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Skaluj pozycję kształtu.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }

    for (auto&& layoutSlide : master->get_LayoutSlides())
    {
        for (auto&& shape : layoutSlide->get_Shapes())
        {
            // Skaluj rozmiar kształtu.
            shape->set_Height(shape->get_Height() * heightRatio);
            shape->set_Width(shape->get_Width() * widthRatio);

            // Skaluj pozycję kształtu.
            shape->set_Y(shape->get_Y() * heightRatio);
            shape->set_X(shape->get_X() * widthRatio);
        }
    }
}

for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // Skaluj rozmiar kształtu.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Skaluj pozycję kształtu.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);

        if (ObjectExt::Is<ITable>(shape))
        {
            SharedPtr<ITable> table = ExplicitCast<ITable>(shape);
            for (auto&& row : table->get_Rows())
            {
                row->set_MinimalHeight(row->get_MinimalHeight() * heightRatio);
            }
            for (auto&& column : table->get_Columns())
            {
                column->set_Width(column->get_Width() * widthRatio);
            }
        }
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Dlaczego kształty są zniekształcone lub obcięte po zmianie rozmiaru slajdu?**

Podczas zmiany rozmiaru slajdu kształty zachowują swoją pierwotną pozycję i rozmiar, chyba że skala zostanie explicite zmieniona. Może to spowodować przycięcie zawartości lub niewłaściwe wyrównanie kształtów.

**Czy dostarczony kod działa dla wszystkich typów kształtów?**

Podstawowy przykład działa dla większości typów kształtów (pola tekstowe, obrazy, wykresy itp.). Jednak w przypadku tabel trzeba obsłużyć wiersze i kolumny osobno, ponieważ wysokość i szerokość tabeli są determinowane przez wymiary poszczególnych komórek.

**Jak zmienić rozmiar tabel przy zmianie rozmiaru slajdu?**

Należy przeiterować wszystkie wiersze i kolumny tabeli oraz proporcjonalnie zmienić ich wysokość i szerokość, tak jak pokazano w drugim przykładzie kodu.

**Czy to skalowanie działa dla slajdów master i slajdów układu?**

Tak, ale należy również przeiterować [Mastery](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/get_masters/) i [slajdy układu](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/get_layoutslides/), i zastosować tę samą logikę skalowania do ich kształtów, aby zapewnić spójność w całej prezentacji.

**Czy mogę zmienić orientację slajdu (pionową/poziomą) wraz ze zmianą rozmiaru?**

Tak. Możesz użyć [presentation->get_SlideSize()->set_Orientation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidesize/set_orientation/), aby zmienić orientację. Upewnij się, że odpowiednio dostosujesz logikę skalowania, aby zachować układ.

**Czy istnieje limit rozmiaru slajdu, który mogę ustawić?**

Aspose.Slides obsługuje rozmiary niestandardowe, lecz bardzo duże rozmiary mogą wpływać na wydajność lub kompatybilność z niektórymi wersjami PowerPointa.

**Jak zapobiec zniekształceniu kształtów o stałym stosunku proporcji?**

Możesz sprawdzić metodę `get_AspectRatioLocked` kształtu przed skalowaniem. Jeśli jest zablokowana, dostosuj szerokość lub wysokość proporcjonalnie, zamiast skalować je osobno.