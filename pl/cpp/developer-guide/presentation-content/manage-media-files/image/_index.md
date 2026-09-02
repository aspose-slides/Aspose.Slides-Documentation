---
title: Optymalizacja zarządzania obrazami w prezentacjach przy użyciu C++
linktitle: Zarządzanie obrazami
type: docs
weight: 10
url: /pl/cpp/image/
keywords:
- dodaj obraz
- dodaj grafikę
- dodaj bitmapę
- zamień obraz
- zamień grafikę
- z internetu
- tło
- dodaj PNG
- dodaj JPG
- dodaj SVG
- zewnętrzne zasoby SVG
- rozwiązywacz SVG
- powiązane obrazy SVG
- czcionki SVG
- dodaj EMF
- dodaj WMF
- dodaj TIFF
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Usprawnij zarządzanie obrazami w PowerPoint i OpenDocument przy użyciu Aspose.Slides dla C++, optymalizując wydajność i automatyzując przepływ pracy."
---
## **Wprowadzenie**

Obrazy sprawiają, że prezentacje są bardziej wciągające i atrakcyjne wizualnie. W Microsoft PowerPoint możesz wstawiać zdjęcia na slajdy z plików, internetu lub innych źródeł. Podobnie Aspose.Slides umożliwia dodawanie obrazów do slajdów prezentacji na kilka sposobów.

{{% alert title="Wskazówka" color="primary" %}} 

Aspose udostępnia darmowe konwertery — [JPEG do PowerPoint](https://products.aspose.app/slides/pl/import/jpg-to-ppt) i [PNG do PowerPoint](https://products.aspose.app/slides/pl/import/png-to-ppt) — które pozwalają szybko tworzyć prezentacje z obrazów. 

{{% /alert %}} 

{{% alert title="Informacja" color="info" %}}

Jeśli chcesz dodać obraz jako ramkę obrazu — szczególnie jeśli zamierzasz zmieniać jego rozmiar, stosować efekty lub używać innych standardowych opcji formatowania — zobacz [Ramka obrazu](/slides/pl/cpp/picture-frame/). 

{{% /alert %}} 

{{% alert title="Uwaga" color="warning" %}}

Możesz konwertować obrazy z jednego formatu na inny. Zobacz następujące strony: konwertuj [obraz do JPG](https://products.aspose.com/slides/pl/cpp/conversion/image-to-jpg/), [JPG do obrazu](https://products.aspose.com/slides/pl/cpp/conversion/jpg-to-image/), [JPG do PNG](https://products.aspose.com/slides/pl/cpp/conversion/jpg-to-png/), [PNG do JPG](https://products.aspose.com/slides/pl/cpp/conversion/png-to-jpg/), [PNG do SVG](https://products.aspose.com/slides/pl/cpp/conversion/png-to-svg/), oraz [SVG do PNG](https://products.aspose.com/slides/pl/cpp/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides obsługuje obrazy w popularnych formatach, takich jak JPEG, PNG, BMP, GIF i inne.

## **Dodawanie obrazów przechowywanych lokalnie do slajdów**

Możesz dodać jeden lub więcej obrazów przechowywanych na komputerze do slajdu prezentacji. Poniższy przykładowy kod C++ pokazuje, jak dodać obraz do slajdu:

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```



## **Dodawanie obrazów z sieci do slajdów**

Jeśli obraz, który chcesz dodać do slajdu, nie jest przechowywany na komputerze, możesz go dodać bezpośrednio z sieci.

Poniższy przykładowy kod C++ pokazuje, jak dodać obraz z sieci do slajdu:

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <net/web_client.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);

auto webClient = System::MakeObject<System::Net::WebClient>();
auto imageData = webClient->DownloadData(System::MakeObject<Uri>(u"[REPLACE WITH URL]"));

auto image = pres->get_Images()->AddImage(imageData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Dodawanie obrazów do masterów slajdów**

Master slajdu przechowuje i kontroluje informacje, takie jak motyw i układ, dla slajdów z niego korzystających. Gdy dodasz obraz do mastera slajdu, obraz pojawi się na każdym slajdzie opartym na tym masterze.

Poniższy przykładowy kod C++ pokazuje, jak dodać obraz do mastera slajdu:

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto masterSlide = slide->get_LayoutSlide()->get_MasterSlide();

auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
masterSlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Dodawanie obrazów jako tła slajdów**

Możesz użyć obrazu jako tła dla jednego lub wielu slajdów. Szczegóły znajdziesz w *[Ustawianie obrazów jako tła slajdów](/slides/pl/cpp/presentation-background/#setting-images-as-background-for-slides)*.

## **Dodawanie SVG do prezentacji**

Zawartość SVG można dodać do prezentacji za pomocą klasy [SvgImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/svgimage/). Uzyskany obiekt [ISvgImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isvgimage/) może następnie zostać dodany do kolekcji obrazów prezentacji i użyty do utworzenia ramki obrazu.

Poniższy przykład C++ importuje samodzielny ciąg SVG. Wszystkie obrazy, style i inne zasoby używane przez ten SVG są wbudowane bezpośrednio w treść SVG.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto svgContent = String(uR"(
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>)");

auto presentation = MakeObject<Presentation>();
auto svgImage = MakeObject<SvgImage>(svgContent);
auto image = presentation->get_Images()->AddImage(svgImage);

presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle, 20.0f, 20.0f,
    static_cast<float>(image->get_Width()),
    static_cast<float>(image->get_Height()),
    image);

presentation->Save(u"self-contained-svg.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Importowanie zawartości SVG z zasobami zewnętrznymi**

Pliki SVG eksportowane z narzędzi projektowych, edytorów diagramów, systemów ikon i potoków internetowych mogą odwoływać się do zasobów przechowywanych poza dokumentem SVG. Na przykład SVG może zawierać odnośnik do obrazu taki jak `images/photo.png`, wartość CSS `url(...)` lub adres URL czcionki.

Aby zaimportować taką zawartość SVG, utwórz implementację [IExternalResourceResolver](https://reference.aspose.com/slides/pl/cpp/aspose.slides.import/iexternalresourceresolver/) i przekaż ją, razem z bazowym URI, do odpowiedniego konstruktora `SvgImage`. Bazowy URI określa lokalizację dokumentu SVG i jest używany do rozwiązywania względnych odnośników.

Interfejs [ISvgImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isvgimage/) udostępnia informacje o zaimportowanym SVG:

- `get_SvgContent()` zwraca znacznik SVG jako ciąg znaków.
- `get_SvgData()` zwraca zawartość SVG jako tablicę bajtów.
- `get_BaseUri()` zwraca bazowy URI używany dla względnych odnośników.
- `get_ExternalResourceResolver()` zwraca rozwiązywacz przypisany do obrazu SVG.

### **Implementacja rozwiązywacza zasobów zewnętrznych**

Rozwiązywacz posiada dwie metody:

- [ResolveUri](https://reference.aspose.com/slides/pl/cpp/aspose.slides.import/iexternalresourceresolver/resolveuri/) łączy bazowy URI i względny odnośnik do zasobu, zwracając absolutny URI. Zwróć pusty ciąg, gdy odnośnik nie może być rozwiązany lub nie jest dozwolony.
- [GetEntity](https://reference.aspose.com/slides/pl/cpp/aspose.slides.import/iexternalresourceresolver/getentity/) zwraca strumień do odczytu dla absolutnego URI zasobu. Zwróć `nullptr`, gdy zasób jest brakujący, zablokowany lub niedostępny. W odpowiednich przypadkach można zwrócić strumień awaryjny.

Poniższy rozwiązywacz ładuje połączone zasoby wyłącznie z dozwolonego katalogu lokalnego. Zasoby sieciowe i ścieżki poza tym katalogiem są blokowane. Opcjonalny obraz awaryjny jest zwracany dla nie rozwiązanych odnośników do obrazów.

```cpp
#include <Import/IExternalResourceResolver.h>
#include <system/array.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>
#include <system/io/path.h>
#include <system/io/stream.h>
#include <system/string.h>
#include <system/smart_ptr.h>
#include <system/string_comparison.h>
#include <system/uri.h>

using namespace Aspose::Slides::Import;
using namespace System;
using namespace System::IO;

class LocalSvgResourceResolver : public IExternalResourceResolver
{
public:
    LocalSvgResourceResolver(String allowedRoot, ArrayPtr<uint8_t> fallbackImageData = nullptr)
        : _allowedRoot(Path::GetFullPath(allowedRoot)),
          _fallbackImageData(fallbackImageData)
    {
    }

    String ResolveUri(String baseUri, String relativeUri) override
    {
        if (String::IsNullOrWhiteSpace(baseUri) ||
            String::IsNullOrWhiteSpace(relativeUri))
        {
            return String::Null;
        }

        auto baseAddress = SharedPtr<Uri>();
        auto absoluteAddress = SharedPtr<Uri>();
        if (!Uri::TryCreate(baseUri, UriKind::Absolute, baseAddress) ||
            !Uri::TryCreate(baseAddress, relativeUri, absoluteAddress))
        {
            return String::Null;
        }

        // Ten rozwiązywacz celowo zezwala tylko na pliki lokalne.
        if (!absoluteAddress->get_IsFile())
        {
            return String::Null;
        }

        auto resourcePath = Path::GetFullPath(absoluteAddress->get_LocalPath());
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return String::Null;
        }

        return absoluteAddress->get_AbsoluteUri();
    }

    SharedPtr<Stream> GetEntity(String absoluteUri) override
    {
        auto resourceUri = SharedPtr<Uri>();
        if (!Uri::TryCreate(absoluteUri, UriKind::Absolute, resourceUri) ||
            !resourceUri->get_IsFile())
        {
            return nullptr;
        }

        auto resourcePath = Path::GetFullPath(resourceUri->get_LocalPath());
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return nullptr;
        }

        if (File::Exists(resourcePath))
        {
            return File::OpenRead(resourcePath);
        }

        // Użyj awaryjnego obrazu tylko dla zasobów graficznych. Zwracanie strumienia obrazu
        // dla brakującej czcionki lub arkusza stylów nie byłoby poprawne.
        if (_fallbackImageData != nullptr && IsImageFile(resourcePath))
        {
            return MakeObject<MemoryStream>(_fallbackImageData, false);
        }

        return nullptr;
    }

private:
    String _allowedRoot;
    ArrayPtr<uint8_t> _fallbackImageData;

    bool IsInsideAllowedRoot(String resourcePath)
    {
        auto normalizedRoot = _allowedRoot;
        auto directorySeparator = String(Path::DirectorySeparatorChar, 1);
        if (!normalizedRoot.EndsWith(directorySeparator))
        {
            normalizedRoot += directorySeparator;
        }

        auto normalizedPath = Path::GetFullPath(resourcePath);
        auto comparison = Path::DirectorySeparatorChar == u'\\'
            ? StringComparison::OrdinalIgnoreCase
            : StringComparison::Ordinal;

        return normalizedPath.StartsWith(normalizedRoot, comparison) ||
               String::Equals(normalizedPath, _allowedRoot, comparison);
    }

    static bool IsImageFile(String path)
    {
        auto extension = Path::GetExtension(path);

        return String::Equals(extension, u".png", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".jpg", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".jpeg", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".gif", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".bmp", StringComparison::OrdinalIgnoreCase);
    }
};
```

### **Rozwiązywanie połączonych zasobów podczas importu SVG**

Załóżmy, że `assets/diagram.svg` zawiera względne odwołanie takie jak:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Poniższy przykład C++ przekazuje URI pliku SVG jako bazowy URI i dostarcza własny rozwiązywacz. Rozwiązywacz konwertuje względny odnośnik obrazu na absolutny URI i zwraca strumień zawierający połączony zasób, podczas gdy Aspose.Slides przetwarza SVG.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <Import/IExternalResourceResolver.h>
#include <system/array.h>
#include <system/environment.h>
#include <system/io/file.h>
#include <system/io/path.h>
#include <system/string.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Import;
using namespace System;
using namespace System::IO;

auto svgFilePath = Path::GetFullPath(Path::Combine(u"assets", u"diagram.svg"));
auto assetDirectory = Path::GetDirectoryName(svgFilePath);
if (String::IsNullOrEmpty(assetDirectory))
{
    assetDirectory = Environment::get_CurrentDirectory();
}

auto svgContent = File::ReadAllText(svgFilePath);

// Bazowy URI reprezentuje lokalizację dokumentu SVG.
auto baseUri = MakeObject<Uri>(svgFilePath)->get_AbsoluteUri();

auto fallbackImageData = ArrayPtr<uint8_t>();
auto fallbackImagePath = Path::Combine(assetDirectory, u"fallback.png");
if (File::Exists(fallbackImagePath))
{
    fallbackImageData = File::ReadAllBytes(fallbackImagePath);
}

auto resolver = MakeObject<LocalSvgResourceResolver>(assetDirectory, fallbackImageData);
auto svgImage = MakeObject<SvgImage>(svgContent, resolver, baseUri);

// ISvgImage udostępnia zawartość źródłową, dane binarne, bazowy URI oraz rozwiązywacz.
auto importedContent = svgImage->get_SvgContent();
auto importedData = svgImage->get_SvgData();
auto importedBaseUri = svgImage->get_BaseUri();
auto importedResolver = svgImage->get_ExternalResourceResolver();

auto presentation = MakeObject<Presentation>();
auto image = presentation->get_Images()->AddImage(svgImage);

presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle, 20.0f, 20.0f,
    static_cast<float>(image->get_Width()),
    static_cast<float>(image->get_Height()),
    image);

presentation->Save(u"svg-with-linked-resources.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Klasa `SvgImage` udostępnia również przeciążenia akceptujące dane SVG jako tablicę bajtów lub strumień, wraz z rozwiązywaczem zasobów zewnętrznych i bazowym URI.

{{% alert title="Ważne" color="warning" %}}

Rozwiązywacz zasobów udostępnia zasoby zewnętrzne podczas przetwarzania i renderowania SVG w Aspose.Slides. Nie modyfikuje on oryginalnego znacznika SVG ani automatycznie nie osadza rozwiązanych zasobów w nim.

Gdy `ISvgImage` zostanie dodany do kolekcji obrazów prezentacji, plik PPTX może zawierać zarówno pierwotną reprezentację SVG, jak i rasterowy obraz awaryjny. Połączony zasób może pojawić się w wygenerowanym obrazie awaryjnym, podczas gdy względny odnośnik taki jak `images/photo.png` pozostaje niezmieniony w zapisie SVG. Aplikacja renderująca natywną reprezentację SVG może więc pominąć połączoną treść, gdy oryginalny zasób zewnętrzny jest niedostępny.

{{% /alert %}}

### **Utworzenie przenośnego obrazu SVG**

Aby utworzyć obraz SVG niezależny od plików zewnętrznych, przygotuj SVG jako samodzielny przed stworzeniem `SvgImage`. Na przykład zamień połączone adresy URL obrazów na URI `data:`, które zawierają dane obrazu:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Po osadzeniu wszystkich wymaganych zasobów w treści SVG, utwórz `SvgImage`, dodaj go do kolekcji obrazów prezentacji i wstaw do ramki obrazu, jak pokazano w poprzednim przykładzie.

### **Obsługa brakujących lub zablokowanych zasobów**

Zwróć pusty ciąg z `ResolveUri`, gdy URI zasobu jest nieprawidłowy, zabroniony lub nie może być rozwiązany. Zwróć `nullptr` z `GetEntity`, gdy zasób nie może być odczytany. Aspose.Slides kontynuuje przetwarzanie SVG bez tego zasobu, gdy to możliwe.

Strumień awaryjny może być zwrócony dla brakującego zasobu, ale jego zawartość musi być zgodna z żądanym typem zasobu. Na przykład zwróć strumień obrazu wyłącznie dla brakującego obrazu, nie dla czcionki lub arkusza stylów.

{{% alert title="Bezpieczeństwo" color="warning" %}}

Nie rozwiązuj dowolnych ścieżek plików ani nieograniczonych adresów URL sieciowych z niezweryfikowanych plików SVG. Ogranicz dozwolone schematy, katalogi i hosty. W przypadku zasobów sieciowych stosuj także limity czasu połączenia, ograniczenia rozmiaru odpowiedzi i walidację treści.

{{% /alert %}}

## **Konwersja SVG na zestaw kształtów**
Aspose.Slides może konwertować SVG na zestaw kształtów, podobnie jak odpowiadająca funkcjonalność w PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

Funkcjonalność tę zapewnia przeciążenie metody [AddGroupShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishapecollection/) interfejsu [IShapeCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishapecollection/), które przyjmuje obiekt [ISvgImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isvgimage/) jako pierwszy argument.

Poniższy przykładowy kod C++ pokazuje, jak użyć tej metody do konwersji pliku SVG na zestaw kształtów:

``` cpp 
#include <DOM/IPresentation.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

// Nazwa pliku źródłowego SVG
auto svgFileName = System::String(u"sample.svg");

// Nazwa pliku wyjściowej prezentacji
auto outPptxPath = System::String(u"presentation.pptx");

// Utwórz nową prezentację
auto presentation = System::MakeObject<Presentation>();

// Odczytaj zawartość pliku SVG
auto svgContent = File::ReadAllText(svgFileName);

// Utwórz obiekt SvgImage
auto svgImage = System::MakeObject<SvgImage>(svgContent);

// Pobierz rozmiar slajdu
auto slideSize = presentation->get_SlideSize()->get_Size();

// Konwertuj obraz SVG do grupy kształtów i skaluj go do rozmiaru slajdu
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// Zapisz prezentację w formacie PPTX
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **Dodawanie obrazów jako EMF do slajdów**
Aspose.Slides for C++ umożliwia generowanie obrazów EMF z arkuszy Excel przy użyciu Aspose.Cells i dodawanie ich do slajdów prezentacji.

Poniższy przykładowy kod C++ pokazuje, jak to zrobić:

``` cpp 
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/ImageOrPrintOptions.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/SheetRender.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Aspose.Cells dla C++ musi być uruchomione przed użyciem jakiegokolwiek z jego typów.
Aspose::Cells::Startup();

auto workbook = Aspose::Cells::Workbook(u"chart.xls");
auto sheet = workbook.GetWorksheets().Get(0);

// Renderuj arkusz jako EMF.
auto options = Aspose::Cells::ImageOrPrintOptions();
options.SetHorizontalResolution(200);
options.SetVerticalResolution(200);
options.SetImageType(Aspose::Cells::Drawing::ImageType::Emf);

auto sheetRender = Aspose::Cells::SheetRender(sheet, options);

auto presentation = System::MakeObject<Presentation>();
presentation->get_Slides()->RemoveAt(0);

for (auto pageIndex = 0; pageIndex < sheetRender.GetPageCount(); pageIndex++)
{
    // Aspose.Cells zwraca wyrenderowaną stronę jako bufor, który Aspose.Slides dodaje jako obraz.
    auto emfData = sheetRender.ToImage(pageIndex);
    auto emfBytes = System::MakeArray<uint8_t>(emfData.GetLength(), emfData.GetData());
    auto emfImage = presentation->get_Images()->AddImage(emfBytes);

    auto slide = presentation->get_Slides()->AddEmptySlide(
        presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank));
    auto slideSize = presentation->get_SlideSize()->get_Size();
    slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, slideSize.get_Width(), slideSize.get_Height(), emfImage);
}

presentation->Save(u"Saved.pptx", SaveFormat::Pptx);
presentation->Dispose();
workbook.Dispose();

Aspose::Cells::Cleanup();
```

## **Zamiana obrazów w kolekcji obrazów**

Aspose.Slides pozwala na zamianę obrazów przechowywanych w kolekcji obrazów prezentacji, w tym obrazów używanych przez kształty slajdów. Ten rozdział opisuje kilka sposobów aktualizacji obrazów w kolekcji. Możesz zamienić obraz, używając surowych danych bajtowych, instancji [IImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iimage/) lub innego obrazu już istniejącego w kolekcji.

Postępuj zgodnie z poniższymi krokami:

1. Załaduj plik prezentacji zawierający obrazy przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
1. Załaduj nowy obraz z pliku do tablicy bajtów.
1. Zamień docelowy obraz nowym obrazem, używając tablicy bajtów.
1. W drugim podejściu załaduj obraz do obiektu [IImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iimage/) i zamień docelowy obraz tym obiektem.
1. W trzecim podejściu zamień docelowy obraz obrazem, który już istnieje w kolekcji obrazów prezentacji.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```cpp
#include <DOM/IPPImage.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

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

Korzystając z darmowego konwertera Aspose [Text to GIF](https://products.aspose.app/slides/pl/text-to-gif), możesz łatwo animować tekst i tworzyć GIF‑y z tekstu. 

{{% /alert %}}

## **FAQ**

**Czy pierwotna rozdzielczość obrazu pozostaje nienaruszona po wstawieniu?**

Tak. Piksele źródłowe są zachowane, ale ostateczny wygląd zależy od tego, jak [obraz](/slides/pl/cpp/picture-frame/) jest skalowany na slajdzie i od ewentualnej kompresji przy zapisie.

**Jaki jest najlepszy sposób na jednoczesną wymianę tego samego logo na dziesiątkach slajdów?**

Umieść logo na masterze slajdu lub układzie i zamień je w kolekcji obrazów prezentacji — zmiany będą propagowane do wszystkich elementów korzystających z tego zasobu.

**Czy wstawiony SVG może zostać przekształcony w edytowalne kształty?**

Tak. Możesz skonwertować SVG do grupy kształtów, po czym poszczególne części staną się edytowalne przy użyciu standardowych właściwości kształtów.

**Jak ustawić obraz jako tło dla wielu slajdów jednocześnie?**

[Przypisz obraz jako tło](/slides/pl/cpp/presentation-background/) na masterze slajdu lub odpowiednim układzie — wszystkie slajdy używające tego mastera/układu odziedziczą tło.

**Jak zapobiec nadmiernemu rozmiarowi prezentacji z powodu wielu obrazów?**

Używaj jednego zasobu obrazu zamiast duplikatów, wybieraj rozsądne rozdzielczości, stosuj kompresję przy zapisie i, w miarę możliwości, przechowuj powtarzające się grafiki w masterze.