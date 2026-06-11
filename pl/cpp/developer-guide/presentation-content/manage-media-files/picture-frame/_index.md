---
title: Zarządzanie ramkami obrazu w prezentacjach przy użyciu C++
linktitle: Ramka obrazu
type: docs
weight: 10
url: /pl/cpp/picture-frame/
keywords:
- ramka obrazu
- dodaj ramkę obrazu
- utwórz ramkę obrazu
- dodaj obraz
- utwórz obraz
- wyodrębnij obraz
- obraz rastrowy
- obraz wektorowy
- przytnij obraz
- przycięty obszar
- właściwość StretchOff
- formatowanie ramki obrazu
- właściwości ramki obrazu
- skala względna
- efekt obrazu
- proporcje
- przezroczystość obrazu
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Dodaj ramki obrazu do prezentacji PowerPoint i OpenDocument przy użyciu Aspose.Slides dla C++. Usprawnij przepływ pracy i ulepsz projekty slajdów."
---
## **Wprowadzenie**

Ramka obrazu jest kształtem zawierającym obraz — jest jak obraz w ramce. 

Możesz dodać obraz do slajdu przez ramkę obrazu. W ten sposób możesz formatować obraz, formatując ramkę obrazu.

{{% alert  title="Tip" color="primary" %}} 
Aspose udostępnia darmowe konwertery — [JPEG do PowerPoint](https://products.aspose.app/slides/pl/import/jpg-to-ppt) i [PNG do PowerPoint](https://products.aspose.app/slides/pl/import/png-to-ppt) — które umożliwiają szybkie tworzenie prezentacji z obrazów. 
{{% /alert %}} 

## **Utworzenie ramki obrazu**

1. Utwórz instancję [Presentation class](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation).
2. Pobierz referencję slajdu za pomocą jego indeksu. 
3. Utwórz obiekt [IPPImage](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_p_p_image) poprzez dodanie obrazu do [IImagescollection](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_image_collection) powiązanej z obiektem prezentacji, który będzie użyty do wypełnienia kształtu.
4. Określ szerokość i wysokość obrazu.
5. Utwórz [PictureFrame](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.picture_frame) na podstawie szerokości i wysokości obrazu za pomocą metody `AddPictureFrame` udostępnionej przez obiekt shape powiązany z odwołanym slajdem.
6. Dodaj ramkę obrazu (zawierającą obraz) do slajdu.
7. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod w C++ pokazuje, jak utworzyć ramkę obrazu:

```c++
// Ścieżka do katalogu dokumentów.
const String outPath = u"../out/PictureFrameFormatting_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Wczytaj żądaną prezentację
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Dostęp do pierwszego slajdu
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Wczytuje obraz, który zostanie dodany do kolekcji obrazów prezentacji
// Pobiera obraz
auto image = Images::FromFile(filePath);

// Dodaje obraz do kolekcji obrazów prezentacji
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Dodaje ramkę obrazu do slajdu
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Ustawia względną skalę szerokości i wysokości
pf->set_RelativeScaleHeight(0.8);
pf->set_RelativeScaleWidth(1.35);
// Stosuje formatowanie do ramki obrazu
pf->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pf->get_LineFormat()->set_Width ( 20);
pf->set_Rotation( 45);

// Zapisuje plik PPTX na dysk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert color="warning" %}} 
Ramki obrazu pozwalają szybko tworzyć slajdy prezentacji na podstawie obrazów. Gdy połączysz ramkę obrazu z opcjami zapisu Aspose.Slides, możesz manipulować operacjami wejścia/wyjścia, aby konwertować obrazy z jednego formatu na inny. Możesz chcieć zobaczyć te strony: konwertuj [obraz do JPG](https://products.aspose.com/slides/pl/cpp/conversion/image-to-jpg/); konwertuj [JPG do obrazu](https://products.aspose.com/slides/pl/cpp/conversion/jpg-to-image/); konwertuj [JPG do PNG](https://products.aspose.com/slides/pl/cpp/conversion/jpg-to-png/), konwertuj [PNG do JPG](https://products.aspose.com/slides/pl/cpp/conversion/png-to-jpg/); konwertuj [PNG do SVG](https://products.aspose.com/slides/pl/cpp/conversion/png-to-svg/), konwertuj [SVG do PNG](https://products.aspose.com/slides/pl/cpp/conversion/svg-to-png/).
{{% /alert %}}

## **Utworzenie ramki obrazu ze skalowaniem względnym**

Modyfikując względne skalowanie obrazu, możesz utworzyć bardziej złożoną ramkę obrazu. 

1. Utwórz instancję [Presentation class](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation).
2. Pobierz referencję slajdu za pomocą jego indeksu. 
3. Dodaj obraz do kolekcji obrazów prezentacji.
4. Utwórz obiekt [IPPImage](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_p_p_image) poprzez dodanie obrazu do [IImagescollection](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_image_collection) powiązanej z obiektem prezentacji, który będzie użyty do wypełnienia kształtu.
5. Określ względną szerokość i wysokość obrazu w ramce obrazu.
6. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod w C++ pokazuje, jak utworzyć ramkę obrazu ze skalowaniem względnym:

```c++
// Ścieżka do katalogu dokumentów.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Wczytuje żądaną prezentację
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Dostęp do pierwszego slajdu
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Wczytuje obraz, który zostanie dodany do kolekcji obrazów prezentacji
// Pobiera obraz
auto image = Images::FromFile(filePath);

// Dodaje obraz do kolekcji obrazów prezentacji
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Dodaje ramkę obrazu do slajdu
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Ustawia względną skalę szerokości i wysokości
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

//Zapisuje plik PPTX na dysk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Wyodrębnianie obrazów rastrowych z ramek obrazu**

Możesz wyodrębnić obrazy rastrowe z obiektów [PictureFrame](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.picture_frame) i zapisać je w formatach PNG, JPG i innych. Poniższy przykład kodu demonstruje, jak wyodrębnić obraz z dokumentu „sample.pptx” i zapisać go w formacie PNG.

```c++
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstSlide = presentation->get_Slide(0);
auto firstShape = firstSlide->get_Shape(0);
    
if (ObjectExt::Is<IPictureFrame>(firstShape))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(firstShape);
    auto image = pictureFrame->get_PictureFormat()->get_Picture()->get_Image()->get_SystemImage();

    image->Save(u"slide_1_shape_1.png", ImageFormat::get_Png());
}

presentation->Dispose();
```

## **Wyodrębnianie obrazów SVG z ramek obrazu**

Gdy prezentacja zawiera grafikę SVG umieszczoną wewnątrz kształtów [PictureFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/pictureframe/), Aspose.Slides dla C++ umożliwia pobranie oryginalnych obrazów wektorowych w pełnej jakości. Przeglądając kolekcję kształtów slajdu, możesz zidentyfikować każdy [PictureFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/pictureframe/), sprawdzić, czy leżący pod nim [IPPImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ippimage/) zawiera treść SVG, a następnie zapisać ten obraz na dysku lub w strumieniu w jego natywnym formacie SVG.

Poniższy przykład kodu demonstruje, jak wyodrębnić obraz SVG z ramki obrazu:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IPictureFrame>(shape))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto svgImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image()->get_SvgImage();
    if (svgImage != nullptr)
    {
        File::WriteAllText(u"output.svg", svgImage->get_SvgContent());
    }
}

presentation->Dispose();
```

## **Pobranie przezroczystości obrazu**

Aspose.Slides pozwala pobrać efekt przezroczystości zastosowany do obrazu. Ten kod w C++ demonstruje tę operację:

```c++
auto presentation = System::MakeObject<Presentation>(u"Test.pptx");
auto pictureFrame = System::ExplicitCast<IPictureFrame>(presentation->get_Slide(0)->get_Shape(0));
auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
for (auto&& effect : imageTransform)
{
    if (System::ObjectExt::Is<IAlphaModulateFixed>(effect))
    {
        float transparencyValue = 100.0f - (System::ExplicitCast<IAlphaModulateFixed>(effect))->get_Amount();
        System::Console::WriteLine(System::String(u"Picture transparency: ") + transparencyValue);
    }
}
```

{{% alert color="primary" %}} 
Wszystkie efekty stosowane do obrazów można znaleźć w [Aspose::Slides::Effects](https://reference.aspose.com/slides/pl/cpp/aspose.slides.effects/).
{{% /alert %}}

## **Formatowanie ramki obrazu**

Aspose.Slides udostępnia wiele opcji formatowania, które można zastosować do ramki obrazu. Korzystając z tych opcji, możesz zmienić ramkę obrazu, aby spełniała określone wymagania.

1. Utwórz instancję [Presentation class](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation).
2. Pobierz referencję slajdu za pomocą jego indeksu. 
3. Utwórz obiekt [IPPImage](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_p_p_image) poprzez dodanie obrazu do [IImagescollection](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_image_collection) powiązanej z obiektem prezentacji, który będzie użyty do wypełnienia kształtu.
4. Określ szerokość i wysokość obrazu.
5. Utwórz `PictureFrame` na podstawie szerokości i wysokości obrazu za pomocą metody [AddPictureFrame](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) udostępnionej przez obiekt [IShapes](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_shape_collection) powiązany z odwołanym slajdem.
6. Dodaj ramkę obrazu (zawierającą obraz) do slajdu.
7. Ustaw kolor linii ramki obrazu.
8. Ustaw szerokość linii ramki obrazu.
9. Obróć ramkę obrazu, podając jej wartość dodatnią lub ujemną.
   * Wartość dodatnia obraca obraz zgodnie z ruchem wskazówek zegara. 
   * Wartość ujemna obraca obraz przeciwnie do ruchu wskazówek zegara.
10. Dodaj ramkę obrazu (zawierającą obraz) do slajdu.
11. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod w C++ demonstruje proces formatowania ramki obrazu:

```c++
// Ścieżka do katalogu dokumentów.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Wczytuje żądaną prezentację
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Dostęp do pierwszego slajdu
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Wczytuje obraz, który zostanie dodany do kolekcji obrazów prezentacji
// Pobiera obraz
auto image = Images::FromFile(filePath);

// Dodaje obraz do kolekcji obrazów prezentacji
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Dodaje ramkę obrazu do slajdu
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Ustawia względną skalę szerokości i wysokości
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

//Zapisuje plik PPTX na dysk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert title="Tip" color="primary" %}}
Aspose niedawno opracował [darmowy Collage Maker](https://products.aspose.app/slides/pl/collage). Jeśli kiedykolwiek będziesz potrzebować [scalić obrazy JPG/JPEG](https://products.aspose.app/slides/pl/collage/jpg) lub PNG, [tworzyć siatki ze zdjęć](https://products.aspose.app/slides/pl/collage/photo-grid), możesz skorzystać z tej usługi. 
{{% /alert %}}

## **Dodanie obrazu jako linku**

Aby zmniejszyć rozmiar prezentacji, możesz dodawać obrazy (lub filmy) za pomocą linków zamiast osadzania plików bezpośrednio w prezentacji. Ten kod w C++ pokazuje, jak dodać obraz i wideo do wstawki:

```cpp
auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto shapesToRemove = System::MakeObject<System::Collections::Generic::List<System::SharedPtr<IShape>>>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

for (auto& autoShape : shapes)
{
    if (autoShape->get_Placeholder() == nullptr)
        continue;

    switch (autoShape->get_Placeholder()->get_Type())
    {
        case Aspose::Slides::PlaceholderType::Picture:
        {
            auto pictureFrame = shapes->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, autoShape->get_X(), autoShape->get_Y(), autoShape->get_Width(), autoShape->get_Height(), nullptr);
            pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
            shapesToRemove->Add(autoShape);
            break;
        }

        case Aspose::Slides::PlaceholderType::Media:
        {
            auto videoFrame = shapes->AddVideoFrame(autoShape->get_X(), autoShape->get_Y(), autoShape->get_Width(), autoShape->get_Height(), u"");
            videoFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
            videoFrame->set_LinkPathLong(u"https://youtu.be/t_1LYZ102RA");
            shapesToRemove->Add(autoShape);
            break;
        }
    }
}

for (auto& shape : shapesToRemove)
{
    shapes->Remove(shape);
}

presentation->Save(u"output.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Kadrowanie obrazów**

Ten kod w C++ pokazuje, jak przyciąć istniejący obraz na slajdzie: 

``` CPP
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;
    
auto presentation = System::MakeObject<Presentation>();
// Tworzy nowy obiekt obrazu
auto newImage = presentation->get_Images()->AddImage(Images::FromFile(imagePath));

// Dodaje PictureFrame do slajdu
auto picFrame = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 100.0f, 100.0f, 420.0f, 250.0f, newImage);

// Przycina obraz (wartości procentowe)
picFrame->get_PictureFormat()->set_CropLeft(23.6f);
picFrame->get_PictureFormat()->set_CropRight(21.5f);
picFrame->get_PictureFormat()->set_CropTop(3.0f);
picFrame->get_PictureFormat()->set_CropBottom(31.0f);

// Zapisuje wynik
presentation->Save(outPptxFile, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Usuwanie przyciętych obszarów obrazu**

Jeśli chcesz usunąć przycięte obszary obrazu zawartego w ramce, możesz użyć metody [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/). Metoda ta zwraca przycięty obraz lub obraz wyjściowy, jeśli przycinanie nie jest konieczne.

Ten kod w C++ demonstruje operację: 

```c++
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"PictureFrameCrop.pptx");
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Gets the PictureFrame from the first slide
System::SharedPtr<IPictureFrame> picFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Deletes cropped areas of the PictureFrame image and returns the cropped image
System::SharedPtr<IPPImage> croppedImage = picFrame->get_PictureFormat()->DeletePictureCroppedAreas();

// Saves the result
presentation->Save(u"PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
```

{{% alert title="NOTE" color="warning" %}} 
Metoda [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) dodaje przycięty obraz do kolekcji obrazów prezentacji. Jeśli obraz jest używany wyłącznie w przetwarzanej [PictureFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/pictureframe/), to ustawienie może zmniejszyć rozmiar prezentacji. W przeciwnym razie liczba obrazów w wynikowej prezentacji się zwiększy.

Metoda konwertuje pliki metafile WMF/EMF na rastrowy obraz PNG podczas operacji przycinania. 
{{% /alert %}}

## **Kompresja obrazów**

Możesz skompresować obraz w prezentacji, używając metody [IPictureFillFormat::CompressImage()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipicturefillformat/compressimage/). Metoda ta zmniejsza rozmiar obrazu w zależności od rozmiaru kształtu i określonej rozdzielczości, z opcją usunięcia przyciętych obszarów.

Dostosowuje rozmiar i rozdzielczość obrazu podobnie jak funkcja **Picture Format -> Compress Pictures -> Resolution** w programie PowerPoint.

Poniższe przykłady w C++ pokazują, jak skompresować obraz w prezentacji, podając docelową rozdzielczość i opcjonalnie usuwając przycięte obszary:

```c++
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Skompresuj obraz do docelowej rozdzielczości 150 DPI (rozdzielczość internetowa) i usuń przycięte obszary.
bool result = pictureFrame->get_PictureFormat()->CompressImage(true, PicturesCompression::Dpi150);

// Sprawdź wynik kompresji.
if (result)
{
    System::Console::WriteLine(u"Image successfully compressed.");
}
else
{
    System::Console::WriteLine(u"Image compression failed or no changes were necessary.");
}

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Lub bezpośrednio używając własnej wartości DPI:

```c++
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Skompresuj obraz do 150 DPI (rozdzielczość internetowa), usuwając przycięte obszary.
pictureFrame->get_PictureFormat()->CompressImage(true, 150.0f);

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}} 
Metoda konwertuje obraz do niższej rozdzielczości w oparciu o rozmiar kształtu i podane DPI. Przycięte fragmenty można także usunąć, aby zoptymalizować rozmiar pliku.
Jeśli obraz jest metafilem (WMF/EMF) lub SVG, kompresja nie zostanie zastosowana. Ponadto jakość JPEG jest zachowywana lub nieznacznie obniżana w zależności od rozdzielczości, podobnie jak w PowerPoint przy obsłudze wysokiej rozdzielczości JPEG.
{{% /alert %}}

## **Zablokowanie proporcji**

Jeśli chcesz, aby kształt zawierający obraz zachował proporcje nawet po zmianie wymiarów obrazu, możesz użyć metody [set_AspectRatioLocked()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/), aby ustawić opcję *Lock Aspect Ratio*. 

Ten kod w C++ pokazuje, jak zablokować proporcje kształtu:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ILayoutSlide> layout = pres->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
System::SharedPtr<ISlide> emptySlide = pres->get_Slides()->AddEmptySlide(layout);

System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
System::SharedPtr<IPPImage> presImage = pres->get_Images()->AddImage(image);

System::SharedPtr<IPictureFrame> pictureFrame = emptySlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 150.0f, static_cast<float>(presImage->get_Width()), static_cast<float>(presImage->get_Height()), presImage);

// ustawić kształt, aby zachować proporcje przy zmianie rozmiaru
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);
```

{{% alert title="NOTE" color="warning" %}} 
Ustawienie *Lock Aspect Ratio* zachowuje tylko proporcje kształtu, a nie obrazu, który on zawiera.
{{% /alert %}}

## **Użycie właściwości StretchOff**

Korzystając z właściwości [StretchOffsetLeft](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.picture_fill_format#ad730bf8db88f47979d84643eb30d1471), [StretchOffsetTop](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.picture_fill_format#aa512e1f022e9c7ff83e9c51ba100709a), [StretchOffsetRight](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.picture_fill_format#ac3597692f9b7e3327d0f4a4169a53127) i [StretchOffsetBottom](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.picture_fill_format#a72acf6945f372a5729c0b760f4a5dc39) z interfejsu [IPictureFillFormat](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_picture_fill_format) oraz klasy [PictureFillFormat](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.picture_fill_format) możesz określić prostokąt wypełnienia. 

Gdy określone jest rozciąganie obrazu, prostokąt źródłowy jest skalowany, aby dopasować się do podanego prostokąta wypełnienia. Każda krawędź prostokąta wypełnienia jest definiowana jako procentowy offset od odpowiedniej krawędzi ramki ograniczającej kształt. Pozytywny procent oznacza wcięcie, a negatywny procent oznacza wystawienie poza ramkę.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation).
2. Pobierz referencję slajdu za pomocą jego indeksu.
3. Dodaj prostokąt `AutoShape`. 
4. Utwórz obraz.
5. Ustaw typ wypełnienia kształtu.
6. Ustaw tryb wypełnienia obrazu kształtu.
7. Dodaj obraz ustawiony jako wypełnienie kształtu.
8. Określ offsety obrazu względem odpowiedniej krawędzi ramki kształtu
9. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod w C++ demonstruje proces, w którym używana jest właściwość StretchOff:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto ppImage = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
auto slide = pres->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 400.0f, 400.0f, ppImage);

// Ustawia obraz rozciągnięty od każdej strony w ciele kształtu
auto pictureFormat = pictureFrame->get_PictureFormat();
pictureFormat->set_PictureFillMode(PictureFillMode::Stretch);
pictureFormat->set_StretchOffsetLeft(24.0f);
pictureFormat->set_StretchOffsetRight(24.0f);
pictureFormat->set_StretchOffsetTop(24.0f);
pictureFormat->set_StretchOffsetBottom(24.0f);

pres->Save(u"imageStretch.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Jak mogę sprawdzić, które formaty obrazów są obsługiwane dla PictureFrame?**

Aspose.Slides obsługuje zarówno obrazy rastrowe (PNG, JPEG, BMP, GIF itp.), jak i obrazy wektorowe (np. SVG) za pośrednictwem obiektu obrazu przypisanego do [PictureFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/pictureframe/). Lista obsługiwanych formatów zazwyczaj pokrywa się z możliwościami silnika konwersji slajdów i obrazów.

**Jak dodanie dziesiątek dużych obrazów wpłynie na rozmiar i wydajność pliku PPTX?**

Osadzanie dużych obrazów zwiększa rozmiar pliku i zużycie pamięci; linkowanie obrazów pomaga utrzymać rozmiar prezentacji w ryzach, ale wymaga, aby pliki zewnętrzne pozostały dostępne. Aspose.Slides umożliwia dodawanie obrazów za pomocą linku, aby zmniejszyć rozmiar pliku.

**Jak mogę zablokować obiekt obrazu przed przypadkowym przesuwaniem/skalowaniem?**

Użyj [blokad kształtu](https://reference.aspose.com/slides/pl/cpp/aspose.slides/pictureframe/get_pictureframelock/) dla [PictureFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/pictureframe/) (np. wyłączając przesuwanie lub skalowanie). Mechanizm blokowania jest opisany w oddzielnym [artykule o ochronie](/slides/pl/cpp/applying-protection-to-presentation/) i jest wspierany dla różnych typów kształtów, w tym [PictureFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/pictureframe/).

**Czy wierność wektorowa SVG jest zachowana przy eksportowaniu prezentacji do PDF/obrazów?**

Aspose.Slides pozwala wyodrębnić SVG z [PictureFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/pictureframe/) jako oryginalny wektor. Przy [eksportowaniu do PDF](/slides/pl/cpp/convert-powerpoint-to-pdf/) lub [formatów rastrowych](/slides/pl/cpp/convert-powerpoint-to-png/), wynik może być rasteryzowany w zależności od ustawień eksportu; fakt, że oryginalny SVG jest przechowywany jako wektor, potwierdza zachowanie przy wyodrębnianiu.