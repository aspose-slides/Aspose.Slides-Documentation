---
title: "Optymalizacja zarządzania obrazami w prezentacjach przy użyciu C++"
linktitle: "Zarządzanie obrazami"
type: docs
weight: 10
url: /pl/cpp/image/
keywords:
- "dodaj obraz"
- "dodaj zdjęcie"
- "dodaj bitmapę"
- "zamień obraz"
- "zamień zdjęcie"
- "z internetu"
- "tło"
- "dodaj PNG"
- "dodaj JPG"
- "dodaj SVG"
- "zewnętrzne zasoby SVG"
- "resolver SVG"
- "powiązane obrazy SVG"
- "czcionki SVG"
- "dodaj EMF"
- "dodaj WMF"
- "dodaj TIFF"
- "PowerPoint"
- "OpenDocument"
- "prezentacja"
- "C++"
- "Aspose.Slides"
description: "Usprawnij zarządzanie obrazami w PowerPoint i OpenDocument przy użyciu Aspose.Slides dla C++, optymalizując wydajność i automatyzując przepływ pracy."
---
## **Wprowadzenie**

Obrazy sprawiają, że prezentacje są bardziej angażujące i atrakcyjne wizualnie. W programie Microsoft PowerPoint można wstawiać obrazy na slajdy z plików, internetu lub innych źródeł. Podobnie, Aspose.Slides umożliwia dodawanie obrazów do slajdów prezentacji na kilka sposobów. 

{{% alert title="Wskazówka" color="info" %}} 

Aspose udostępnia darmowe konwertery — [JPEG do PowerPoint](https://products.aspose.app/slides/pl/import/jpg-to-ppt) i [PNG do PowerPoint](https://products.aspose.app/slides/pl/import/png-to-ppt) — które pozwalają szybko tworzyć prezentacje z obrazów. 

{{% /alert %}} 

{{% alert title="Informacja" color="info" %}}

Jeśli chcesz dodać obraz jako ramkę zdjęcia — szczególnie jeśli planujesz zmienić jego rozmiar, zastosować efekty lub użyć innych standardowych opcji formatowania — zobacz [Ramka obrazu](/slides/pl/cpp/picture-frame/). 

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

Jeśli obraz, który chcesz dodać do slajdu, nie jest przechowywany na Twoim komputerze, możesz dodać go bezpośrednio z sieci. 

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

Master slajdu przechowuje i kontroluje informacje, takie jak motyw i układ slajdów, które go używają. Gdy dodasz obraz do mastera slajdu, obraz pojawia się na każdym slajdzie opartym na tym masterze. 

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

Możesz użyć obrazu jako tła jednego lub kilku slajdów. Szczegóły znajdziesz w *[Ustawianie obrazów jako tła slajdów](/slides/pl/cpp/presentation-background/#setting-images-as-background-for-slides)*.

## **Dodawanie SVG do prezentacji**

Zawartość SVG można dodać do prezentacji przy użyciu klasy [SvgImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/svgimage/). Uzyskany obiekt [ISvgImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isvgimage/) może zostać dodany do kolekcji obrazów prezentacji i użyty do utworzenia ramki zdjęcia.

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

## **Importowanie treści SVG z zasobami zewnętrznymi**

Pliki SVG eksportowane z narzędzi projektowych, edytorów diagramów, systemów ikon oraz potoków sieciowych mogą odwoływać się do zasobów przechowywanych poza dokumentem SVG. Na przykład SVG może zawierać odnośnik do obrazu taki jak `images/photo.png`, wartość CSS `url(...)` lub adres URL czcionki. 

Aby zaimportować taką treść SVG, utwórz implementację [IExternalResourceResolver](https://reference.aspose.com/slides/pl/cpp/aspose.slides.import/iexternalresourceresolver/) i przekaż ją, wraz z bazowym URI, odpowiedniemu konstruktorowi `SvgImage`. Bazowy URI wskazuje lokalizację dokumentu SVG i jest używany do rozwiązywania linków względnych.

Interfejs [ISvgImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isvgimage/) zapewnia dostęp do informacji o zaimportowanym SVG:

- `get_SvgContent()` zwraca znacznik SVG jako ciąg znaków.
- `get_SvgData()` zwraca zawartość SVG jako tablicę bajtów.
- `get_BaseUri()` zwraca bazowy URI używany dla linków względnych.
- `get_ExternalResourceResolver()` zwraca resolver przypisany do obrazu SVG.

### **Implementacja resolvera zasobów zewnętrznych**

Resolver posiada dwie metody:

- [ResolveUri](https://reference.aspose.com/slides/pl/cpp/aspose.slides.import/iexternalresourceresolver/resolveuri/) łączy bazowy URI i względny link do zasobu oraz zwraca absolutny URI. Zwróć pusty łańcuch, gdy link nie może zostać rozwiązany lub nie jest dozwolony.
- [GetEntity](https://reference.aspose.com/slides/pl/cpp/aspose.slides.import/iexternalresourceresolver/getentity/) zwraca czytelny strumień dla absolutnego URI zasobu. Zwróć `nullptr`, gdy zasób jest brakujący, zablokowany lub niedostępny. W odpowiednich sytuacjach może zostać zwrócony strumień zastępczy.

Poniższy resolver ładuje połączone zasoby wyłącznie z dozwolonego lokalnego katalogu. Zasoby sieciowe i ścieżki poza dozwolonym katalogiem są blokowane. Opcjonalny obraz zastępczy jest zwracany dla nieodnalezonych linków do obrazów.

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

        // Ten resolver celowo zezwala tylko na pliki lokalne.
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

        // Użyj zasobu zastępczego tylko dla zasobów obrazu. Zwracanie strumienia obrazu
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

Załóżmy, że `assets/diagram.svg` zawiera odniesienie względne, takie jak:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Poniższy przykład C++ przekazuje URI pliku SVG jako bazowy URI i dostarcza własny resolver. Resolver konwertuje względny link do obrazu na absolutny URI i zwraca strumień zawierający połączony zasób, podczas gdy Aspose.Slides przetwarza SVG.

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

// ISvgImage exposes the source content, binary data, base URI, and resolver.
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

Klasa `SvgImage` oferuje również przeciążenia, które akceptują dane SVG jako tablicę bajtów lub strumień, wraz z resolverem zasobów zewnętrznych i bazowym URI.

{{% alert title="Ważne" color="warning" %}}

Resolver zasobów udostępnia zewnętrzne zasoby podczas przetwarzania i renderowania SVG przez Aspose.Slides. Nie modyfikuje on oryginalnego znacznika SVG ani nie wstawia automatycznie rozwiązanych zasobów do niego.

Gdy obiekt `ISvgImage` zostanie dodany do kolekcji obrazów prezentacji, plik PPTX może zawierać zarówno oryginalną reprezentację SVG, jak i rastrowy obraz zastępczy. Połączony zasób może pojawić się w wygenerowanym obrazie zastępczym, podczas gdy względny link taki jak `images/photo.png` pozostaje niezmieniony w zapisanym SVG. Aplikacja renderująca natywną reprezentację SVG może więc pominąć połączoną treść, gdy pierwotny zasób zewnętrzny jest niedostępny.

{{% /alert %}}

### **Utworzenie przenośnego obrazu SVG**

Aby utworzyć obraz SVG niezależny od plików zewnętrznych, najpierw spraw, by SVG był samodzielny przed stworzeniem `SvgImage`. Na przykład zamień połączone adresy URL obrazów na URI `data:`, które zawierają dane obrazu:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Po osadzeniu wszystkich wymaganych zasobów w treści SVG, utwórz `SvgImage`, dodaj go do kolekcji obrazów prezentacji i wstaw do ramki zdjęcia, jak pokazano w poprzednim przykładzie.

### **Obsługa brakujących lub zablokowanych zasobów**

Zwróć pusty łańcuch z `ResolveUri`, gdy URI zasobu jest nieprawidłowy, zakazany lub nie może zostać rozwiązany. Zwróć `nullptr` z `GetEntity`, gdy zasób nie może być odczytany. Aspose.Slides kontynuuje przetwarzanie SVG bez tego zasobu, gdy to możliwe.

Strumień zastępczy może zostać zwrócony dla brakującego zasobu, ale jego zawartość musi być zgodna z żądanym typem zasobu. Na przykład zwracaj strumień obrazu tylko w przypadku brakującego obrazu, nie dla czcionki czy arkusza stylów.

{{% alert title="Bezpieczeństwo" color="warning" %}}

Nie rozwiązuj dowolnych ścieżek plików ani nieograniczonych adresów URL sieciowych z niezaufanych plików SVG. Ogranicz dozwolone schematy, katalogi i hosty. Dla zasobów sieciowych stosuj także limity czasu połączenia, limity rozmiaru odpowiedzi oraz weryfikację zawartości.

{{% /alert %}}

## **Konwersja SVG na zestaw kształtów**
Aspose.Slides może konwertować SVG na zestaw kształtów, podobnie jak odpowiadająca funkcja w PowerPoint:

![Menu podręczne PowerPoint](img_01_01.png)

Ta funkcjonalność jest udostępniana przez przeciążenie metody [AddGroupShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishapecollection/) interfejsu [IShapeCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishapecollection/), które przyjmuje obiekt [ISvgImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isvgimage/) jako pierwszy argument.

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

// Nazwa pliku SVG źródłowego
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

// Konwertuj obraz SVG na grupę kształtów i skaluj go do rozmiaru slajdu
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// Zapisz prezentację w formacie PPTX
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **Dodawanie obrazów jako EMF do slajdów**
Aspose.Slides for C++ umożliwia generowanie obrazów EMF z arkuszy Excel przy użyciu Aspose.Cells i dodawanie ich do slajdów prezentacji. 

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

// Aspose.Cells dla C++ musi być uruchomiony przed użyciem jakichkolwiek jego typów.
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

## **Zastępowanie obrazów w kolekcji obrazów**

Aspose.Slides pozwala zastępować obrazy przechowywane w kolekcji obrazów prezentacji, w tym obrazy używane przez kształty slajdów. Ten rozdział opisuje kilka metod aktualizacji obrazów w kolekcji. Możesz zastąpić obraz przy użyciu surowych danych bajtowych, instancji [IImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iimage/) lub innego obrazu, który już istnieje w kolekcji.

1. Załaduj plik prezentacji zawierający obrazy przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
1. Załaduj nowy obraz z pliku do tablicy bajtów.
1. Zastąp docelowy obraz nowym obrazem, używając tablicy bajtów.
1. W drugim podejściu załaduj obraz do obiektu [IImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iimage/) i zastąp docelowy obraz tym obiektem.
1. W trzecim podejściu zastąp docelowy obraz obrazem, który już istnieje w kolekcji obrazów prezentacji.
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

**Czy oryginalna rozdzielczość obrazu pozostaje niezmieniona po wstawieniu?**

Tak. Piksele źródłowe są zachowane, ale ostateczny wygląd zależy od tego, jak [obraz](/slides/pl/cpp/picture-frame/) jest skalowany na slajdzie oraz od ewentualnej kompresji przy zapisie.

**Jaki jest najlepszy sposób, aby jednocześnie zastąpić to samo logo na dziesiątkach slajdów?**

Umieść logo na masterze slajdu lub układzie i zastąp je w kolekcji obrazów prezentacji — aktualizacje będą propagowane do wszystkich elementów korzystających z tego zasobu.

**Czy wstawiony SVG można przekonwertować na edytowalne kształty?**

Tak. Możesz konwertować SVG na grupę kształtów, po czym poszczególne części stają się edytowalne przy użyciu standardowych właściwości kształtów.

**Jak ustawić obraz jako tło wielu slajdów jednocześnie?**

[Przypisz obraz jako tło](/slides/pl/cpp/presentation-background/) na masterze slajdu lub odpowiednim układzie — wszystkie slajdy korzystające z tego mastera/układu odziedziczą tło.

**Jak zapobiec nadmiernemu rozmiarowi prezentacji spowodowanemu dużą liczbą obrazów?**

Używaj jednego zasobu obrazu zamiast duplikatów, wybieraj rozsądne rozdzielczości, stosuj kompresję przy zapisie i, w miarę możliwości, umieszczaj powtarzające się grafiki w masterze.