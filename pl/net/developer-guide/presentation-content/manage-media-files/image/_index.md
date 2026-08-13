---
title: Optymalizacja zarządzania obrazami w prezentacjach w .NET
linktitle: Zarządzanie obrazami
type: docs
weight: 10
url: /pl/net/image/
keywords:
- dodaj obraz
- dodaj zdjęcie
- dodaj bitmapę
- zastąp obraz
- zastąp zdjęcie
- z sieci
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
- .NET
- C#
- Aspose.Slides
description: "Usprawnij zarządzanie obrazami w PowerPoint i OpenDocument za pomocą Aspose.Slides dla .NET, optymalizując wydajność i automatyzując przepływ pracy."
---
## **Wprowadzenie**

Obrazy sprawiają, że prezentacje są bardziej angażujące i atrakcyjne wizualnie. W programie Microsoft PowerPoint możesz wstawiać zdjęcia na slajdy z plików, internetu lub innych źródeł. Podobnie Aspose.Slides umożliwia dodawanie obrazów do slajdów prezentacji na kilka sposobów.

{{% alert title="Wskazówka" color="info" %}} 

Aspose udostępnia bezpłatne konwertery —[JPEG to PowerPoint](https://products.aspose.app/slides/pl/import/jpg-to-ppt) i [PNG to PowerPoint](https://products.aspose.app/slides/pl/import/png-to-ppt) — które pozwalają szybko tworzyć prezentacje z obrazów. 

{{% /alert %}} 

{{% alert title="Informacja" color="info" %}}

Jeśli chcesz dodać obraz jako ramkę zdjęcia — zwłaszcza gdy planujesz zmieniać jego rozmiar, stosować efekty lub używać innych standardowych opcji formatowania — zobacz [Picture Frame](/slides/pl/net/picture-frame/). 

{{% /alert %}} 

{{% alert title="Uwaga" color="warning" %}}

Możesz konwertować obrazy z jednego formatu na inny. Zobacz następujące strony: konwersja [image to JPG](https://products.aspose.com/slides/pl/net/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/pl/net/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/pl/net/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/pl/net/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/pl/net/conversion/png-to-svg/), oraz [SVG to PNG](https://products.aspose.com/slides/pl/net/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides obsługuje obrazy w popularnych formatach, takich jak JPEG, PNG, BMP, GIF i innych. 

## **Dodawanie obrazów przechowywanych lokalnie do slajdów**

Możesz dodać jeden lub więcej obrazów przechowywanych na komputerze do slajdu prezentacji. Poniższy przykładowy kod C# pokazuje, jak dodać obraz do slajdu:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Dodawanie obrazów z sieci do slajdów**

Jeśli obraz, który chcesz dodać do slajdu, nie jest przechowywany na komputerze, możesz go dodać bezpośrednio z sieci. 

Poniższy przykładowy kod C# pokazuje, jak dodać obraz z sieci do slajdu:

```c#
using System.Net;
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] imageData;
    using (WebClient webClient = new WebClient()) 
    {
        imageData = webClient.DownloadData(new Uri("[REPLACE WITH URL]"));
    }
    
    IPPImage image = pres.Images.AddImage(imageData);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Dodawanie obrazów do szablonów slajdów**

Szablon slajdu przechowuje i kontroluje informacje takie jak motyw i układ slajdów, które go używają. Gdy dodasz obraz do szablonu slajdu, obraz pojawi się na każdym slajdzie opartym na tym szablonie. 

Poniższy przykładowy kod C# pokazuje, jak dodać obraz do szablonu slajdu:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IMasterSlide masterSlide = slide.LayoutSlide.MasterSlide;
    
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    masterSlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Dodawanie obrazów jako tła slajdów**

Możesz użyć obrazu jako tła jednego lub kilku slajdów. Szczegóły znajdziesz w *[Setting Images as Backgrounds for Slides](/slides/pl/net/presentation-background/#setting-images-as-background-for-slides)*.

## **Dodawanie SVG do prezentacji**

Zawartość SVG można dodać do prezentacji przy użyciu klasy [SvgImage](https://reference.aspose.com/slides/pl/net/aspose.slides/svgimage/). Uzyskany obiekt [ISvgImage](https://reference.aspose.com/slides/pl/net/aspose.slides/isvgimage/) może zostać dodany do kolekcji obrazów prezentacji i użyty do utworzenia ramki obrazu.

Poniższy przykład C# importuje samodzielny łańcuch SVG. Wszystkie obrazy, style i inne zasoby użyte w tym SVG są osadzone bezpośrednio w treści SVG.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

string svgContent = @"
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>";

using (Presentation presentation = new Presentation())
{
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage image = presentation.Images.AddImage(svgImage);

    presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 20, 20, image.Width, image.Height, image);

    presentation.Save("self-contained-svg.pptx", SaveFormat.Pptx);
}
```

## **Importowanie treści SVG z zasobami zewnętrznymi**

Pliki SVG eksportowane z narzędzi projektowych, edytorów diagramów, systemów ikon i potoków internetowych mogą odwoływać się do zasobów przechowywanych poza dokumentem SVG. Na przykład SVG może zawierać odnośnik do obrazu, taki jak `images/photo.png`, wartość CSS `url(...)` lub adres URL czcionki.

Aby zaimportować taką treść SVG, utwórz implementację [IExternalResourceResolver](https://reference.aspose.com/slides/pl/net/aspose.slides.import/iexternalresourceresolver/) i przekaż ją wraz z bazowym URI do odpowiedniego konstruktora `SvgImage`. Bazowy URI identyfikuje lokalizację dokumentu SVG i jest używany do rozwiązywania odnośników względnych.

Interfejs [ISvgImage](https://reference.aspose.com/slides/pl/net/aspose.slides/isvgimage/) zapewnia dostęp do informacji o zaimportowanym SVG:

- `SvgContent` zwraca kod SVG jako łańcuch znaków.
- `SvgData` zwraca treść SVG jako tablicę bajtów.
- `BaseUri` zwraca bazowy URI używany dla odnośników względnych.
- `ExternalResourceResolver` zwraca rozwiązywacz przypisany do obrazu SVG.

### **Implementacja rozwiązywacza zasobów zewnętrznych**

Rozwiązywacz posiada dwie metody:

- [ResolveUri](https://reference.aspose.com/slides/pl/net/aspose.slides.import/iexternalresourceresolver/resolveuri/) łączy bazowy URI i względny odnośnik zasobu i zwraca bezwzględny URI. Zwróć `null`, gdy odnośnik nie może zostać rozwiązany lub nie jest dozwolony.
- [GetEntity](https://reference.aspose.com/slides/pl/net/aspose.slides.import/iexternalresourceresolver/getentity/) zwraca strumień do odczytu dla bezwzględnego URI zasobu. Zwróć `null`, gdy zasób jest brakujący, zablokowany lub niedostępny. W razie potrzeby można zwrócić strumień zapasowy.

Poniższy rozwiązywacz ładuje powiązane zasoby wyłącznie z dozwolonego katalogu lokalnego. Zasoby sieciowe i ścieżki poza dozwolonym katalogiem są blokowane. Opcjonalny obraz zastępczy jest zwracany dla nierozwiązanych odnośników do obrazów.

```csharp
using System;
using System.IO;
using Aspose.Slides.Import;

internal sealed class LocalSvgResourceResolver : IExternalResourceResolver
{
    private readonly string _allowedRoot;
    private readonly byte[] _fallbackImageData;

    public LocalSvgResourceResolver(string allowedRoot, byte[] fallbackImageData = null)
    {
        _allowedRoot = Path.GetFullPath(allowedRoot);
        _fallbackImageData = fallbackImageData;
    }

    public string ResolveUri(string baseUri, string relativeUri)
    {
        if (string.IsNullOrWhiteSpace(baseUri) ||
            string.IsNullOrWhiteSpace(relativeUri))
        {
            return null;
        }

        if (!Uri.TryCreate(baseUri, UriKind.Absolute, out Uri baseAddress) ||
            !Uri.TryCreate(baseAddress, relativeUri, out Uri absoluteAddress))
        {
            return null;
        }

        // Ten rozwiązywacz celowo zezwala wyłącznie na pliki lokalne.
        if (!absoluteAddress.IsFile)
        {
            return null;
        }

        string resourcePath = Path.GetFullPath(absoluteAddress.LocalPath);
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return null;
        }

        return absoluteAddress.AbsoluteUri;
    }

    public Stream GetEntity(string absoluteUri)
    {
        if (!Uri.TryCreate(absoluteUri, UriKind.Absolute, out Uri resourceUri) ||
            !resourceUri.IsFile)
        {
            return null;
        }

        string resourcePath = Path.GetFullPath(resourceUri.LocalPath);
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return null;
        }

        if (File.Exists(resourcePath))
        {
            return File.OpenRead(resourcePath);
        }

        // Użyj zastępki tylko dla zasobów obrazów. Zwracanie strumienia obrazu
        // dla brakującej czcionki lub arkusza stylów nie byłoby prawidłowe.
        if (_fallbackImageData != null && IsImageFile(resourcePath))
        {
            return new MemoryStream(_fallbackImageData, writable: false);
        }

        return null;
    }

    private bool IsInsideAllowedRoot(string resourcePath)
    {
        string normalizedRoot = _allowedRoot.TrimEnd(
            Path.DirectorySeparatorChar,
            Path.AltDirectorySeparatorChar) + Path.DirectorySeparatorChar;

        string normalizedPath = Path.GetFullPath(resourcePath);
        StringComparison comparison = Path.DirectorySeparatorChar == '\\'
            ? StringComparison.OrdinalIgnoreCase
            : StringComparison.Ordinal;

        return normalizedPath.StartsWith(normalizedRoot, comparison) ||
               string.Equals(normalizedPath, _allowedRoot, comparison);
    }

    private static bool IsImageFile(string path)
    {
        string extension = Path.GetExtension(path);

        return extension.Equals(".png", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".gif", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".bmp", StringComparison.OrdinalIgnoreCase);
    }
}
```

### **Rozwiązywanie powiązanych zasobów podczas importu SVG**

Załóżmy, że `assets/diagram.svg` zawiera względne odwołanie, takie jak:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Poniższy przykład C# przekazuje URI pliku SVG jako bazowy URI i dostarcza własny rozwiązywacz. Rozwiązywacz konwertuje względny odnośnik obrazu na bezwzględny URI i zwraca strumień zawierający powiązany zasób, podczas gdy Aspose.Slides przetwarza SVG.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Import;

string svgFilePath = Path.GetFullPath(Path.Combine("assets", "diagram.svg"));
string assetDirectory = Path.GetDirectoryName(svgFilePath) ?? Directory.GetCurrentDirectory();
string svgContent = File.ReadAllText(svgFilePath);

// Bazowy URI reprezentuje lokalizację dokumentu SVG.
string baseUri = new Uri(svgFilePath).AbsoluteUri;

byte[] fallbackImageData = null;
string fallbackImagePath = Path.Combine(assetDirectory, "fallback.png");
if (File.Exists(fallbackImagePath))
{
    fallbackImageData = File.ReadAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory, fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// ISvgImage exposes the source content, binary data, base URI, and resolver.
string importedContent = svgImage.SvgContent;
byte[] importedData = svgImage.SvgData;
string importedBaseUri = svgImage.BaseUri;
IExternalResourceResolver importedResolver = svgImage.ExternalResourceResolver;

using (Presentation presentation = new Presentation())
{
    IPPImage image = presentation.Images.AddImage(svgImage);

    presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 20, 20, image.Width, image.Height, image);

    presentation.Save("svg-with-linked-resources.pptx", SaveFormat.Pptx);
}
```

Klasa `SvgImage` udostępnia również przeciążenia przyjmujące dane SVG jako tablicę bajtów lub strumień, wraz z rozwiązywaczem zasobów zewnętrznych i bazowym URI.

{{% alert title="Ważne" color="warning" %}}

Rozwiązywacz zasobów udostępnia zasoby zewnętrzne podczas przetwarzania i renderowania SVG przez Aspose.Slides. Nie modyfikuje on oryginalnego kodu SVG ani nie osadza automatycznie rozwiązanych zasobów w nim.

Gdy obiekt `ISvgImage` zostaje dodany do kolekcji obrazów prezentacji, plik PPTX może zawierać zarówno pierwotną reprezentację SVG, jak i rastrowy obraz zastępczy. Powiązany zasób może pojawić się w wygenerowanym obrazie zastępczym, podczas gdy względny odnośnik, np. `images/photo.png`, pozostaje niezmieniony w przechowywanym SVG. Aplikacja renderująca natywną reprezentację SVG może więc pominąć powiązaną zawartość, gdy oryginalny zasób zewnętrzny jest niedostępny.

{{% /alert %}}

### **Utworzenie przenośnego obrazu SVG**

Aby utworzyć obraz SVG niezależny od plików zewnętrznych, przed utworzeniem `SvgImage` spraw, aby SVG był samodzielny. Na przykład zamień powiązane adresy URL obrazów na URI `data:` zawierające dane obrazu:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Po osadzeniu wszystkich wymaganych zasobów w treści SVG, utwórz `SvgImage`, dodaj go do kolekcji obrazów prezentacji i wstaw do ramki obrazu, jak pokazano w poprzednim przykładzie.

### **Obsługa brakujących lub zablokowanych zasobów**

Zwróć `null` z `ResolveUri`, gdy URI zasobu jest nieprawidłowy, zabroniony lub nie może zostać rozwiązany. Zwróć `null` z `GetEntity`, gdy zasób nie może być odczytany. Aspose.Slides kontynuuje przetwarzanie SVG bez tego zasobu, jeśli to możliwe.

Strumień zastępczy może zostać zwrócony dla brakującego zasobu, ale jego zawartość musi być zgodna z żądanym typem zasobu. Na przykład zwróć strumień obrazu tylko dla brakującego obrazu, nie dla czcionki ani arkusza stylów.

{{% alert title="Bezpieczeństwo" color="warning" %}}

Nie rozwiązuj dowolnych ścieżek plików ani nieograniczonych adresów URL sieciowych z niezaufanych plików SVG. Ogranicz dozwolone schematy, katalogi i hosty. Dla zasobów sieciowych stosuj także limity czasu połączenia, ograniczenia rozmiaru odpowiedzi oraz weryfikację treści.

{{% /alert %}}

## **Konwersja SVG na zestaw kształtów**
Aspose.Slides może konwertować SVG na zestaw kształtów, podobnie jak odpowiadająca funkcja w PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

Funkcjonalność ta jest udostępniana przez przeciążenie metody [AddGroupShape](https://reference.aspose.com/slides/pl/net/aspose.slides.ishapecollection/addgroupshape/methods/1) interfejsu [IShapeCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/ishapecollection), które przyjmuje obiekt [ISvgImage](https://reference.aspose.com/slides/pl/net/aspose.slides/isvgimage) jako pierwszy argument.

Poniższy przykładowy kod C# pokazuje, jak użyć tej metody do konwersji pliku SVG na zestaw kształtów:

``` csharp 
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Nazwa pliku źródłowego SVG
string svgFileName = "sample.svg";

// Nazwa pliku wyjściowej prezentacji
string outPptxPath = "presentation.pptx";

// Utwórz nową prezentację
using (IPresentation presentation = new Presentation())
{
    // Odczytaj zawartość pliku SVG
    string svgContent = File.ReadAllText(svgFileName);

    // Utwórz obiekt SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // Pobierz rozmiar slajdu
    SizeF slideSize = presentation.SlideSize.Size;

    // Konwertuj obraz SVG na grupę kształtów i skaluj do rozmiaru slajdu
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // Zapisz prezentację w formacie PPTX
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **Dodawanie obrazów jako EMF do slajdów**
Aspose.Slides for .NET umożliwia generowanie obrazów EMF z arkuszy Excel przy użyciu Aspose.Cells i dodawanie ich do slajdów prezentacji.

Poniższy przykładowy kod C# pokazuje, jak to zrobić:

``` csharp 
using Aspose.Slides;
using Aspose.Cells;
using Aspose.Cells.Rendering;


using (Workbook book = new Workbook("chart.xlsx"))
{
    Worksheet sheet = book.Worksheets[0];
    ImageOrPrintOptions options = new ImageOrPrintOptions();
    options.HorizontalResolution = 200;
    options.VerticalResolution = 200;
    options.ImageType = Aspose.Cells.Drawing.ImageType.Emf;

    // Zapisz skoroszyt do strumienia
    SheetRender sr = new SheetRender(sheet, options);
    using (Presentation pres = new Presentation())
    {
        pres.Slides.RemoveAt(0);

        String EmfSheetName = "";
        for (int j = 0; j < sr.PageCount; j++)
        {
            EmfSheetName = "test" + sheet.Name + " Page" + (j + 1) + ".out.emf";
            sr.ToImage(j, EmfSheetName);

            var bytes = File.ReadAllBytes(EmfSheetName);
            var emfImage = pres.Images.AddImage(bytes);
            ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides.GetByType(SlideLayoutType.Blank));
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, pres.SlideSize.Size.Width, pres.SlideSize.Size.Height, emfImage);
        }

        pres.Save("Saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
```

## **Zastępowanie obrazów w kolekcji obrazów**

Aspose.Slides pozwala zastępować obrazy przechowywane w kolekcji obrazów prezentacji, w tym obrazy używane przez kształty slajdów. Ten rozdział opisuje kilka sposobów aktualizacji obrazów w kolekcji. Możesz zastąpić obraz używając surowych danych bajtowych, instancji [IImage](https://reference.aspose.com/slides/pl/net/aspose.slides/iimage/) lub innego obrazu, który już istnieje w kolekcji.

Postępuj według poniższych kroków:

1. Załaduj plik prezentacji zawierający obrazy przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/).
1. Załaduj nowy obraz z pliku do tablicy bajtów.
1. Zastąp docelowy obraz nowym obrazem przy użyciu tablicy bajtów.
1. W drugim podejściu, załaduj obraz do obiektu [IImage](https://reference.aspose.com/slides/pl/net/aspose.slides/iimage/) i zastąp docelowy obraz tym obiektem.
1. W trzecim podejściu, zastąp docelowy obraz obrazem, który już istnieje w kolekcji obrazów prezentacji.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
using Presentation presentation = new Presentation("sample.pptx");

// Pierwszy sposób.
byte[] imageData = File.ReadAllBytes("image0.jpeg");
IPPImage oldImage = presentation.Images[0];
oldImage.ReplaceImage(imageData);

// Drugi sposób.
using IImage newImage = Images.FromFile("image1.png");
oldImage = presentation.Images[1];
oldImage.ReplaceImage(newImage);

// Trzeci sposób.
oldImage = presentation.Images[2];
oldImage.ReplaceImage(presentation.Images[3]);

// Zapisz prezentację do pliku.
presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert title="Informacja" color="info" %}}

Korzystając z darmowego konwertera Aspose [Text to GIF](https://products.aspose.app/slides/pl/text-to-gif), możesz łatwo animować tekst i tworzyć GIF‑y z tekstu. 

{{% /alert %}}

## **FAQ**

**Czy oryginalna rozdzielczość obrazu pozostaje niezmieniona po wstawieniu?**

Tak. Piksele źródłowe są zachowane, ale ostateczny wygląd zależy od tego, jak [picture](/slides/pl/net/picture-frame/) jest skalowany na slajdzie oraz od ewentualnej kompresji przy zapisie.

**Jaki jest najlepszy sposób na jednoczesną zamianę tego samego logo na dziesiątkach slajdów?**

Umieść logo na slajdzie-mistrzu lub układzie i zastąp je w kolekcji obrazów prezentacji — zmiany zostaną propagowane do wszystkich elementów korzystających z tego zasobu.

**Czy wstawiony SVG może zostać przekształcony w edytowalne kształty?**

Tak. SVG można przekonwertować na grupę kształtów, po czym poszczególne części stają się edytowalne przy użyciu standardowych właściwości kształtów.

**Jak ustawić obraz jako tło wielu slajdów jednocześnie?**

[Przypisz obraz jako tło](/slides/pl/net/presentation-background/) na slajdzie‑mistrzu lub odpowiednim układzie — każdy slajd korzystający z tego mistrza/układu odziedziczy tło.

**Jak zapobiec nadmiernemu rozmiarowi prezentacji spowodowanemu dużą liczbą obrazów?**

Używaj jednego zasobu obrazu zamiast duplikatów, wybieraj rozsądne rozdzielczości, stosuj kompresję przy zapisie i przechowuj powtarzające się grafiki w mistrzu, jeśli to możliwe.