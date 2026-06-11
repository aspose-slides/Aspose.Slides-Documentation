---
title: Zarządzanie kształtami prezentacji w C++
linktitle: Manipulacja kształtami
type: docs
weight: 40
url: /pl/cpp/shape-manipulations/
keywords:
- Kształt PowerPoint
- Kształt prezentacji
- Kształt na slajdzie
- Znajdź kształt
- Klonuj kształt
- Usuń kształt
- Ukryj kształt
- Zmień kolejność kształtów
- Pobierz identyfikator Interop kształtu
- Tekst alternatywny kształtu
- Formaty układu kształtu
- Kształt jako SVG
- Kształt do SVG
- Wyrównaj kształt
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Naucz się tworzyć, edytować i optymalizować kształty w Aspose.Slides dla C++ i dostarczać wysokowydajne prezentacje PowerPoint."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z kształtami w prezentacjach przy użyciu Aspose.Slides. Pokazuje, jak znaleźć kształt na slajdzie, go sklonować, usunąć, ukryć, zmienić kolejność, uzyskać jego identyfikator Interop oraz ustawić tekst alternatywny w celu identyfikacji i dalszego przetwarzania.

Omówiono również, jak uzyskać dostęp do formatów układu dla kształtów, renderować kształt jako SVG, wyrównywać kształty na slajdzie oraz używać właściwości odbicia do poziomego i pionowego lustrzanego odbicia. Dodatkowo artykuł zawiera krótkie FAQ dotyczące łączenia kształtów, kolejności nakładania i blokowania kształtów.

## **Find a Shape on a Slide**
Ten temat opisuje prostą technikę ułatwiającą programistom znajdowanie konkretnego kształtu na slajdzie bez użycia jego wewnętrznego Id. Ważne jest, aby wiedzieć, że pliki PowerPoint nie mają żadnego sposobu identyfikacji kształtów na slajdzie poza wewnętrznym unikalnym Id. Dla programistów może być trudne znalezienie kształtu przy użyciu tego wewnętrznego Id. Wszystkie kształty dodane do slajdów mają jakiś tekst alternatywny. Zalecamy programistom użycie tekstu alternatywnego do znajdowania konkretnego kształtu. Można użyć programu MS PowerPoint, aby określić tekst alternatywny dla obiektów, które planujesz zmienić w przyszłości.

Po ustawieniu tekstu alternatywnego dowolnego pożądanego kształtu, możesz otworzyć tę prezentację przy użyciu Aspose.Slides for C++ i przeiterować wszystkie kształty dodane do slajdu. Podczas każdej iteracji możesz sprawdzić tekst alternatywny kształtu, a kształt z pasującym tekstem alternatywnym będzie tym, którego potrzebujesz. Aby lepiej zilustrować tę technikę, stworzyliśmy metodę [FindShape](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.util.slide_util#ad6ecc982512ef758ea4d5d28672db71f), która realizuje wyszukiwanie konkretnego kształtu na slajdzie i zwraca go.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FindShapeInSlide-FindShapeInSlide.cpp" >}}

## **Clone a Shape**
Aby sklonować kształt na slajdzie przy użyciu Aspose.Slides for C++:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation).
1. Pobierz referencję do slajdu, używając jego indeksu.
1. Uzyskaj dostęp do kolekcji kształtów slajdu źródłowego.
1. Dodaj nowy slajd do prezentacji.
1. Sklonuj kształty z kolekcji kształtów slajdu źródłowego do nowego slajdu.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Poniższy przykład dodaje grupowy kształt do slajdu.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneShapes-CloneShapes.cpp" >}}

## **Remove a Shape**
Aspose.Slides for C++ umożliwia programistom usunięcie dowolnego kształtu. Aby usunąć kształt z dowolnego slajdu, postępuj zgodnie z poniższymi krokami:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation).
1. Uzyskaj dostęp do pierwszego slajdu.
1. Znajdź kształt o określonym AlternativeText.
1. Usuń kształt.
1. Zapisz plik na dysku.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveShape-RemoveShape.cpp" >}}

## **Hide a Shape**
Aspose.Slides for C++ umożliwia programistom ukrycie dowolnego kształtu. Aby ukryć kształt na dowolnym slajdzie, postępuj zgodnie z poniższymi krokami:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation).
1. Uzyskaj dostęp do pierwszego slajdu.
1. Znajdź kształt o określonym AlternativeText.
1. Ukryj kształt.
1. Zapisz plik na dysku.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-Hidingshapes-Hidingshapes.cpp" >}}

## **Change Shape Order**
Aspose.Slides for C++ umożliwia programistom zmianę kolejności kształtów. Zmiana kolejności określa, który kształt jest na wierzchu, a który znajduje się z tyłu. Aby zmienić kolejność kształtów na dowolnym slajdzie, postępuj zgodnie z poniższymi krokami:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation).
1. Uzyskaj dostęp do pierwszego slajdu.
1. Dodaj kształt.
1. Dodaj tekst do ramki tekstowej kształtu.
1. Dodaj kolejny kształt w tych samych współrzędnych.
1. Zmień kolejność kształtów.
1. Zapisz plik na dysku.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeShapeOrder-ChangeShapeOrder.cpp" >}}

## **Get the Interop Shape ID**
Aspose.Slides for C++ umożliwia programistom uzyskanie unikalnego identyfikatora kształtu w zakresie slajdu, w przeciwieństwie do właściwości UniqueId, która pozwala uzyskać unikalny identyfikator w zakresie całej prezentacji. W interfejsach IShape oraz w klasie Shape dodano właściwość OfficeInteropShapeId. Wartość zwracana przez właściwość OfficeInteropShapeId odpowiada wartości Id obiektu Microsoft.Office.Interop.PowerPoint.Shape. Poniżej znajduje się przykładowy kod.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-InterlopShapeID-InterlopShapeID.cpp" >}}

## **Set the AlternativeText Property**
Aspose.Slides for C++ umożliwia programistom ustawienie właściwości AlternativeText dowolnego kształtu. Aby ustawić AlternativeText kształtu, postępuj zgodnie z poniższymi krokami:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation).
1. Uzyskaj dostęp do pierwszego slajdu.
1. Dodaj dowolny kształt do slajdu.
1. Wykonaj operacje na nowo dodanym kształcie.
1. Przejdź przez kształty, aby znaleźć konkretny kształt.
1. Ustaw AlternativeText.
1. Zapisz plik na dysku.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAlternativeText-SetAlternativeText.cpp" >}}

## **Access Layout Formats for a Shape**
Aspose.Slides for C++ umożliwia programistom dostęp do formatów układu dla kształtu. Ten artykuł pokazuje, jak uzyskać dostęp do właściwości **FillFormat** i **LineFormat** kształtu.

Poniżej znajduje się przykładowy kod.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AccessLayoutFormats-AccessLayoutFormats.cpp" >}}

## **Render a Shape as SVG**
Teraz Aspose.Slides for C++ obsługuje renderowanie kształtu jako SVG. Metoda WriteAsSvg (oraz jej przeciążenie) została dodana do klasy Shape i interfejsu IShape. Metoda pozwala zapisać zawartość kształtu jako plik SVG. Poniższy fragment kodu pokazuje, jak wyeksportować kształt ze slajdu do pliku SVG.

``` cpp
String outSvgFileName = u"SingleShape.svg";

auto pres = System::MakeObject<Presentation>(u"TestExportShapeToSvg.pptx");

auto stream = System::MakeObject<FileStream>(outSvgFileName, FileMode::Create, FileAccess::Write);
pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0)->WriteAsSvg(stream);
```

## **Shapes Alignment**
Aspose.Slides umożliwia wyrównywanie kształtów względem marginesów slajdu lub względem siebie. W tym celu dodano przeciążoną metodę [SlidesUtil.AlignShapes()](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.util.slide_util#a2263709efa423c11706e57b21014d3ab). Wyliczenie [ShapesAlignmentType](https://reference.aspose.com/slides/pl/cpp/namespace/aspose.slides#aeb3015a196294029a0ee1f545bc5887f) definiuje możliwe opcje wyrównania.

**Example 1**

Poniższy kod źródłowy wyrównuje kształty o indeksach 1, 2 i 4 wzdłuż górnej krawędzi slajdu.

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"example.pptx");

SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);
SharedPtr<IShape> shape1 = slide->get_Shapes()->idx_get(1);
SharedPtr<IShape> shape2 = slide->get_Shapes()->idx_get(2);
SharedPtr<IShape> shape3 = slide->get_Shapes()->idx_get(4);
SlideUtil::AlignShapes(ShapesAlignmentType::AlignTop, true, pres->get_Slides()->idx_get(0), 
System::MakeArray<int32_t>(
    {
        slide->get_Shapes()->IndexOf(shape1),
        slide->get_Shapes()->IndexOf(shape2),
        slide->get_Shapes()->IndexOf(shape3)
    }));
```

**Example 2**

Przykład poniżej pokazuje, jak wyrównać całą kolekcję kształtów względem najniższego kształtu w kolekcji.

``` cpp
SharedPtr<Presentation> pres = MakeObject<Presentation>(u"example.pptx");
SlideUtil::AlignShapes(ShapesAlignmentType::AlignBottom, false, pres->get_Slides()->idx_get(0)->get_Shapes());
```

## **Flip Properties**

W Aspose.Slides klasa [ShapeFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/shapeframe/) zapewnia kontrolę nad poziomym i pionowym lustrzanym odbiciem kształtów za pomocą właściwości `flipH` i `flipV`. Obie właściwości są typu [NullableBool](https://reference.aspose.com/slides/pl/cpp/aspose.slides/nullablebool/) i mogą przyjmować wartości `True` (odwrócenie), `False` (brak odwrócenia) lub `NotDefined` (domyślne zachowanie). Wartości te są dostępne z właściwości [Frame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishape/get_frame/) kształtu.

Aby zmodyfikować ustawienia odbicia, tworzy się nową instancję [ShapeFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/shapeframe/) z aktualną pozycją i rozmiarem kształtu, pożądanymi wartościami `flipH` i `flipV` oraz kątem obrotu. Przypisanie tej instancji do [Frame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishape/get_frame/) kształtu i zapis prezentacji powoduje zastosowanie transformacji lustrzanej i zapisuje je w pliku wyjściowym.

Załóżmy, że mamy plik sample.pptx, w którym pierwszy slajd zawiera pojedynczy kształt z domyślnymi ustawieniami odbicia, jak pokazano poniżej.

![The shape to be flipped](shape_to_be_flipped.png)

Poniższy przykład kodu pobiera bieżące właściwości odbicia kształtu i odwraca go zarówno w poziomie, jak i w pionie.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);

// Pobierz poziomą właściwość odbicia kształtu.
auto horizontalFlip = shape->get_Frame()->get_FlipH();
Console::WriteLine(u"Horizontal flip: " + ObjectExt::ToString(horizontalFlip));

// Pobierz pionową właściwość odbicia kształtu.
auto verticalFlip = shape->get_Frame()->get_FlipV();
Console::WriteLine(u"Vertical flip: " + ObjectExt::ToString(verticalFlip));

auto x = shape->get_Frame()->get_X();
auto y = shape->get_Frame()->get_Y();
auto width = shape->get_Frame()->get_Width();
auto height = shape->get_Frame()->get_Height();
auto flipH = NullableBool::True; // Odwróć poziomo.
auto flipV = NullableBool::True; // Odwróć poziomo.
auto rotation = shape->get_Frame()->get_Rotation();

shape->set_Frame(MakeObject<ShapeFrame>(x, y, width, height, flipH, flipV, rotation));

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Wynik:

![The flipped shape](flipped_shape.png)

## **FAQ**

**Can I combine shapes (union/intersect/subtract) on a slide like in a desktop editor?**

Nie ma wbudowanego API do operacji boolowskich. Można je przybliżyć, budując własny kontur — np. obliczając powstałą geometrię (przez [GeometryPath](https://reference.aspose.com/slides/pl/cpp/aspose.slides/geometrypath/)) i tworząc nowy kształt z tym konturem, opcjonalnie usuwając pierwotne kształty.

**How can I control the stacking order (z-order) so a shape always stays "on top"?**

Zmień kolejność wstawiania/przenoszenia w kolekcji [shapes](https://reference.aspose.com/slides/pl/cpp/aspose.slides/baseslide/get_shapes/) slajdu. Dla przewidywalnych rezultatów ustal z‑order po zakończeniu wszystkich innych modyfikacji slajdu.

**Can I "lock" a shape to prevent users from editing it in PowerPoint?**

Tak. Ustaw flagi ochrony na poziomie kształtu ([shape-level protection flags](/slides/pl/cpp/applying-protection-to-presentation/)) (np. blokada zaznaczania, przemieszczania, zmiany rozmiaru, edycji tekstu). W razie potrzeby zastosuj ograniczenia również na poziomie szablonu lub układu. Należy pamiętać, że jest to ochrona na poziomie interfejsu użytkownika, a nie zabezpieczenie; dla silniejszej ochrony połącz ją z ograniczeniami na poziomie pliku, takimi jak zalecenia tylko‑do‑odczytu lub hasła ([read-only recommendations or passwords](/slides/pl/cpp/password-protected-presentation/)).