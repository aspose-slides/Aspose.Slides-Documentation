---
title: Optymalizacja zarządzania obrazami w prezentacjach przy użyciu C++
linktitle: Zarządzaj obrazami
type: docs
weight: 10
url: /pl/cpp/image/
keywords:
- dodaj obraz
- dodaj zdjęcie
- dodaj bitmapę
- zamień obraz
- zamień zdjęcie
- z internetu
- tło
- dodaj PNG
- dodaj JPG
- dodaj SVG
- dodaj EMF
- dodaj WMF
- dodaj TIFF
- PowerPoint
- OpenDocument
- prezentacja
- EMF
- SVG
- C++
- Aspose.Slides
description: "Usprawnij zarządzanie obrazami w PowerPoint i OpenDocument za pomocą Aspose.Slides dla C++, optymalizując wydajność i automatyzując swój przepływ pracy."
---
## **Wprowadzenie**

Obrazy sprawiają, że prezentacje są bardziej angażujące i interesujące. W programie Microsoft PowerPoint można wstawiać obrazy z pliku, Internetu lub innych lokalizacji na slajdy. Podobnie, Aspose.Slides pozwala dodawać obrazy do slajdów w prezentacjach za pomocą różnych metod. 

{{% alert title="Wskazówka" color="primary" %}} 

Aspose udostępnia darmowe konwertery — [JPEG do PowerPoint](https://products.aspose.app/slides/pl/import/jpg-to-ppt) i [PNG do PowerPoint](https://products.aspose.app/slides/pl/import/png-to-ppt) — które umożliwiają szybkie tworzenie prezentacji z obrazów. 

{{% /alert %}} 

{{% alert title="Informacja" color="info" %}}

Jeśli chcesz dodać obraz jako obiekt ramki — szczególnie jeśli planujesz używać standardowych opcji formatowania, aby zmienić jego rozmiar, dodać efekty itp. — zobacz [Ramka obrazu](/slides/pl/cpp/picture-frame/). 

{{% /alert %}} 

{{% alert title="Uwaga" color="warning" %}}

Możesz manipulować operacjami wejścia/wyjścia związanymi z obrazami i prezentacjami PowerPoint, aby konwertować obraz z jednego formatu na inny. Zobacz te strony: konwertuj [image to JPG](https://products.aspose.com/slides/pl/cpp/conversion/image-to-jpg/); konwertuj [JPG to image](https://products.aspose.com/slides/pl/cpp/conversion/jpg-to-image/); konwertuj [JPG to PNG](https://products.aspose.com/slides/pl/cpp/conversion/jpg-to-png/), konwertuj [PNG to JPG](https://products.aspose.com/slides/pl/cpp/conversion/png-to-jpg/); konwertuj [PNG to SVG](https://products.aspose.com/slides/pl/cpp/conversion/png-to-svg/), konwertuj [SVG to PNG](https://products.aspose.com/slides/pl/cpp/conversion/svg-to-png/). 

{{% /alert %}}

Aspose.Slides obsługuje operacje na obrazach w tych popularnych formatach: JPEG, PNG, GIF i inne. 

## **Dodawanie obrazów przechowywanych lokalnie do slajdów**

Możesz dodać jeden lub kilka obrazów z komputera na slajd w prezentacji. Ten przykładowy kod w C++ pokazuje, jak dodać obraz do slajdu:

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```



## **Dodawanie obrazów z sieci do slajdów**

Jeśli obraz, który chcesz dodać do slajdu, nie jest dostępny na komputerze, możesz dodać go bezpośrednio z sieci. 

Ten przykładowy kod pokazuje, jak dodać obraz z sieci do slajdu w C++:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
    
auto webClient = System::MakeObject<WebClient>();
auto imageData = webClient->DownloadData(System::MakeObject<Uri>(u"[REPLACE WITH URL]"));

auto image = pres->get_Images()->AddImage(imageData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Dodawanie obrazów do mistrza slajdów**

Mistrz slajdu to górny slajd, który przechowuje i kontroluje informacje (temat, układ itp.) o wszystkich slajdach pod nim. Dlatego, gdy dodasz obraz do mistrza slajdów, obraz ten pojawia się na każdym slajdzie pod tym mistrzem. 

Ten przykładowy kod w C++ pokazuje, jak dodać obraz do mistrza slajdów:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto masterSlide = slide->get_LayoutSlide()->get_MasterSlide();

auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
masterSlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Dodawanie obrazów jako tło slajdów**

Możesz zdecydować się użyć obrazu jako tła dla konkretnego slajdu lub kilku slajdów. W takim przypadku należy zobaczyć *[Ustawianie obrazów jako tła slajdów](https://docs.aspose.com/slides/pl/cpp/presentation-background/#setting-images-as-background-for-slides)*.

## **Dodawanie SVG do prezentacji**
Możesz dodać lub wstawić dowolny obraz do prezentacji, używając metody [AddPictureFrame](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9), która należy do interfejsu [IShapeCollection](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_shape_collection).

Aby utworzyć obiekt obrazu na podstawie obrazu SVG, możesz zrobić to w następujący sposób:

1. Utwórz obiekt SvgImage, aby wstawić go do ImageShapeCollection
2. Utwórz obiekt PPImage z ISvgImage
3. Utwórz obiekt PictureFrame przy użyciu interfejsu IPPImage

Ten przykładowy kod pokazuje, jak wdrożyć powyższe kroki, aby dodać obraz SVG do prezentacji:
``` cpp 
// Ścieżka do katalogu dokumentów
System::String dataDir = u"D:\\Documents\\";

// Nazwa pliku SVG źródłowego
System::String svgFileName = dataDir + u"sample.svg";

// Nazwa pliku wyjściowej prezentacji
System::String outPptxPath = dataDir + u"presentation.pptx";

// Utwórz nową prezentację
auto p = System::MakeObject<Presentation>();

// Odczytaj zawartość pliku SVG
System::String svgContent = File::ReadAllText(svgFileName);

// Utwórz obiekt SvgImage
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// Utwórz obiekt PPImage
System::SharedPtr<IPPImage> ppImage = p->get_Images()->AddImage(svgImage);

// Tworzy nową ramkę obrazu 
p->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 200.0f, 100.0f, static_cast<float>(ppImage->get_Width()), static_cast<float>(ppImage->get_Height()), ppImage);

// Zapisz prezentację w formacie PPTX
p->Save(outPptxPath, SaveFormat::Pptx);
```

## **Konwertowanie SVG na zestaw kształtów**
Konwersja SVG na zestaw kształtów w Aspose.Slides jest podobna do funkcjonalności PowerPoint używanej do pracy z obrazami SVG:

![Menu podręczne PowerPoint](img_01_01.png)

Funkcjonalność jest zapewniona przez jedną z przeciążeń metody [AddGroupShape](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_shape_collection#a07def8851fe87a8f73a1621d2375d13b) interfejsu [IShapeCollection](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_shape_collection), która przyjmuje obiekt [ISvgImage](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_svg_image) jako pierwszy argument.

Ten przykładowy kod pokazuje, jak użyć opisanego sposobu, aby przekonwertować plik SVG na zestaw kształtów:

``` cpp 
// Ścieżka do katalogu dokumentów
System::String dataDir = u"D:\\Documents\\";

// Nazwa pliku SVG źródłowego
System::String svgFileName = dataDir + u"sample.svg";

// Nazwa pliku wyjściowej prezentacji
System::String outPptxPath = dataDir + u"presentation.pptx";

// Utwórz nową prezentację
System::SharedPtr<IPresentation> presentation = System::MakeObject<Presentation>();

// Odczytaj zawartość pliku SVG
System::String svgContent = File::ReadAllText(svgFileName);

// Utwórz obiekt SvgImage
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// Pobierz rozmiar slajdu
System::Drawing::SizeF slideSize = presentation->get_SlideSize()->get_Size();

// Konwertuj obraz SVG na grupę kształtów skalując go do rozmiaru slajdu
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// Zapisz prezentację w formacie PPTX
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **Dodawanie obrazów jako EMF do slajdów**
Aspose.Slides for C++ umożliwia generowanie obrazów EMF z arkuszy Excel i dodawanie ich jako EMF do slajdów przy użyciu Aspose.Cells. 

Ten przykładowy kod pokazuje, jak wykonać opisaną czynność:

``` cpp 
System::String dataDir = u"D:\\Documents\\";

StringPtr cellsXls = new String(dataDir.ToWCS().c_str());
cellsXls->Append(L"chart.xls");
intrusive_ptr<Aspose::Cells::IWorkbook> book = Aspose::Cells::Factory::CreateIWorkbook(cellsXls);

intrusive_ptr<Aspose::Cells::IWorksheet> sheet = book->GetIWorksheets()->GetObjectByIndex(0);
intrusive_ptr<Aspose::Cells::Rendering::IImageOrPrintOptions> options = Aspose::Cells::Factory::CreateIImageOrPrintOptions();
options->SetHorizontalResolution(200);
options->SetVerticalResolution(200);
options->SetImageFormat(Aspose::Cells::Systems::Drawing::Imaging::ImageFormat::GetEmf());

// Zapisz skoroszyt do strumienia
intrusive_ptr<Aspose::Cells::Rendering::ISheetRender> sr = Aspose::Cells::Factory::CreateISheetRender(sheet, options);

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

pres->get_Slides()->RemoveAt(0);

System::String EmfSheetName;
for (int32_t j = 0; j < sr->GetPageCount(); j++)
{
    EmfSheetName = dataDir + u"test" + System::String::FromWCS(sheet->GetName()->value()) + u" Page" + (j + 1) + u".out.emf";
    sr->ToImage(j, new String(EmfSheetName.ToWCS().c_str()));

    auto bytes = System::IO::File::ReadAllBytes(EmfSheetName);
    auto emfImage = pres->get_Images()->AddImage(bytes);

    System::SharedPtr<ISlide> slide = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->GetByType(SlideLayoutType::Blank));
    auto slideSize = pres->get_SlideSize()->get_Size();
    slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, slideSize.get_Width(), slideSize.get_Height(), emfImage);
}

pres->Save(dataDir + u"Saved.pptx", SaveFormat::Pptx);
```

## **Zastępowanie obrazów w kolekcji obrazów**

Aspose.Slides pozwala zastąpić obrazy przechowywane w kolekcji obrazów prezentacji (w tym te używane przez kształty slajdów). Ten rozdział przedstawia kilka podejść do aktualizacji obrazów w kolekcji. API udostępnia proste metody do zastąpienia obrazu przy użyciu surowych danych bajtowych, instancji [IImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iimage/) lub innego obrazu, który już istnieje w kolekcji.

1. Załaduj plik prezentacji zawierający obrazy przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
1. Załaduj nowy obraz z pliku do tablicy bajtów.
1. Zastąp docelowy obraz nowym obrazem przy użyciu tablicy bajtów.
1. W drugim podejściu załaduj obraz do obiektu [IImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iimage/) i zastąp docelowy obraz tym obiektem.
1. W trzecim podejściu zastąp docelowy obraz obrazem, który już istnieje w kolekcji obrazów prezentacji.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```cpp
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Pierwszy sposób.
auto imageData = File::ReadAllBytes(u"image0.jpeg");
auto oldImage = presentation->get_Image(0);
oldImage->ReplaceImage(imageData);

// Drugi sposób.
auto newImage = Images::FromFile(u"image1.png");
oldImage = presentation->get_Image(1);
oldImage->ReplaceImage(newImage);
newImage->Dispose();

// Trzeci sposób.
oldImage = presentation->get_Image(2);
oldImage->ReplaceImage(presentation->get_Image(3));

// Zapisz prezentację do pliku.
presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="Informacja" color="info" %}}

Korzystając z darmowego konwertera Aspose FREE [Text to GIF](https://products.aspose.app/slides/pl/text-to-gif), możesz łatwo animować teksty, tworzyć GIF‑y z tekstów itp. 

{{% /alert %}}

## **FAQ**

**Czy oryginalna rozdzielczość obrazu pozostaje niezmieniona po wstawieniu?**

Tak. Piksele źródłowe są zachowane, ale ostateczny wygląd zależy od tego, jak [obraz](/slides/pl/cpp/picture-frame/) jest skalowany na slajdzie oraz od ewentualnej kompresji przy zapisie.

**Jaki jest najlepszy sposób na jednoczesne zastąpienie tego samego logo na dziesiątkach slajdów?**

Umieść logo na master‑slajdzie lub układzie i zastąp je w kolekcji obrazów prezentacji — aktualizacje zostaną rozpropagowane do wszystkich elementów korzystających z tego zasobu.

**Czy wstawiony SVG może zostać przekonwertowany na edytowalne kształty?**

Tak. Możesz skonwertować SVG na grupę kształtów, po czym poszczególne części stają się edytowalne przy użyciu standardowych właściwości kształtów.

**Jak ustawić obraz jako tło dla wielu slajdów jednocześnie?**

[Przypisz obraz jako tło](/slides/pl/cpp/presentation-background/) na master‑slajdzie lub odpowiednim układzie — wszystkie slajdy korzystające z tego mastera/układu odziedziczą tło.

**Jak zapobiec nadmiernemu rozrostowi rozmiaru prezentacji z powodu wielu obrazów?**

Używaj jednego zasobu obrazu zamiast duplikatów, wybieraj rozsądne rozdzielczości, stosuj kompresję przy zapisie i umieszczaj powtarzające się grafiki na master‑slajdzie tam, gdzie to ma sens.