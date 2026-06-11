---
title: Zarządzanie ramkami obrazu w prezentacjach w .NET
linktitle: Ramka obrazu
type: docs
weight: 10
url: /pl/net/picture-frame/
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
- proporcje obrazu
- przezroczystość obrazu
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dodawaj ramki obrazu do prezentacji PowerPoint i OpenDocument za pomocą Aspose.Slides dla .NET. Usprawnij przepływ pracy i ulepsz projekty slajdów."
---
## **Wstęp**

Rama obrazu jest kształtem, który zawiera obraz — jest jak obraz w ramce. 

Możesz dodać obraz do slajdu za pomocą ramki obrazu. W ten sposób możesz formatować obraz, formatując ramkę obrazu.

{{% alert  title="Tip" color="primary" %}} 
Aspose udostępnia darmowe konwertery —[JPEG do PowerPoint](https://products.aspose.app/slides/pl/import/jpg-to-ppt) i [PNG do PowerPoint](https://products.aspose.app/slides/pl/import/png-to-ppt)—które umożliwiają szybkie tworzenie prezentacji z obrazów. 
{{% /alert %}} 

## **Utwórz ramkę obrazu**

1. Utwórz instancję klasy [Presentation ](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation)class. 
2. Pobierz referencję slajdu za pomocą jego indeksu. 
3. Utwórz obiekt [IPPImage](https://reference.aspose.com/slides/pl/net/aspose.slides/ippimage) przez dodanie obrazu do [IImagescollection](https://reference.aspose.com/slides/pl/net/aspose.slides/iimagecollection) powiązanej z obiektem prezentacji, który będzie używany do wypełnienia kształtu.
4. Określ szerokość i wysokość obrazu.
5. Utwórz [PictureFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/pictureframe) oparty na szerokości i wysokości obrazu, używając metody `AddPictureFrame` udostępnionej przez obiekt kształtu powiązany z referencyjnym slajdem.
6. Dodaj ramkę obrazu (zawierającą obraz) do slajdu.
7. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod C# pokazuje, jak utworzyć ramkę obrazu:

```c#
// Tworzy instancję klasy Presentation, która reprezentuje plik PPTX
using (Presentation pres = new Presentation())
{
    // Pobiera pierwszy slajd
    ISlide slide = pres.Slides[0];

    // Ładuje obraz i dodaje go do kolekcji obrazów prezentacji
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Dodaje ramkę obrazu o tej samej wysokości i szerokości
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Zastosowuje formatowanie do ramki obrazu
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // Zapisuje prezentację do pliku PPTX
    pres.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" %}} 
Ramki obrazu pozwalają szybko tworzyć slajdy prezentacji na podstawie obrazów. Gdy połączysz ramkę obrazu z opcjami zapisu Aspose.Slides, możesz manipulować operacjami wejścia/wyjścia, aby konwertować obrazy z jednego formatu na inny. Być może będziesz chciał zobaczyć te strony: konwertuj [obraz do JPG](https://products.aspose.com/slides/pl/net/conversion/image-to-jpg/); konwertuj [JPG do obrazu](https://products.aspose.com/slides/pl/net/conversion/jpg-to-image/); konwertuj [JPG do PNG](https://products.aspose.com/slides/pl/net/conversion/jpg-to-png/), konwertuj [PNG do JPG](https://products.aspose.com/slides/pl/net/conversion/png-to-jpg/); konwertuj [PNG do SVG](https://products.aspose.com/slides/pl/net/conversion/png-to-svg/), konwertuj [SVG do PNG](https://products.aspose.com/slides/pl/net/conversion/svg-to-png/).
{{% /alert %}}

## **Utwórz ramkę obrazu ze skalowaniem względnym**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation) class.
2. Pobierz referencję slajdu za pomocą jego indeksu. 
3. Dodaj obraz do kolekcji obrazów prezentacji.
4. Utwórz obiekt [IPPImage](https://reference.aspose.com/slides/pl/net/aspose.slides/ippimage) przez dodanie obrazu do [IImagescollection](https://reference.aspose.com/slides/pl/net/aspose.slides/iimagecollection) powiązanej z obiektem prezentacji, który będzie używany do wypełnienia kształtu.
5. Określ względną szerokość i wysokość obrazu w ramce obrazu.
6. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod C# pokazuje, jak utworzyć ramkę obrazu ze skalowaniem względnym:

```c#
// Tworzy instancję klasy Presentation, która reprezentuje plik PPTX
using (Presentation presentation = new Presentation())
{
    // Ładuje obraz i dodaje go do kolekcji obrazów prezentacji
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Dodaje ramkę obrazu do slajdu
    IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // Ustawia względną skalę szerokości i wysokości
    pictureFrame.RelativeScaleHeight = 0.8f;
    pictureFrame.RelativeScaleWidth = 1.35f;

    // Zapisuje prezentację
    presentation.Save("Adding Picture Frame with Relative Scale_out.pptx", SaveFormat.Pptx);
}
```

## **Wyodrębnij obrazy rastrowe z ramek obrazu**

Możesz wyodrębnić obrazy rastrowe z obiektów [PictureFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/pictureframe) i zapisać je w formacie PNG, JPG i innych. Poniższy przykład kodu pokazuje, jak wyodrębnić obraz z dokumentu "sample.pptx" i zapisać go w formacie PNG.

```c#
using (var presentation = new Presentation("sample.pptx"))
{
    var firstSlide = presentation.Slides[0];
    var firstShape = firstSlide.Shapes[0];

    if (firstShape is IPictureFrame pictureFrame)
    {
        var image = pictureFrame.PictureFormat.Picture.Image.SystemImage;
        image.Save("slide_1_shape_1.png", ImageFormat.Png);
    }
}
```

## **Wyodrębnij obrazy SVG z ramek obrazu**

Jeśli prezentacja zawiera grafikę SVG umieszczoną wewnątrz kształtów [PictureFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/pictureframe/) , Aspose.Slides dla .NET umożliwia pobranie oryginalnych obrazów wektorowych w pełnej jakości. Przeglądając kolekcję kształtów slajdu, możesz zidentyfikować każdy [PictureFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/pictureframe/), sprawdzić, czy powiązany [IPPImage](https://reference.aspose.com/slides/pl/net/aspose.slides/ippimage/) zawiera zawartość SVG, a następnie zapisać ten obraz na dysk lub strumień w natywnym formacie SVG.

Poniższy przykład kodu demonstruje, jak wyodrębnić obraz SVG z ramki obrazu:

```cs
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

if (shape is IPictureFrame pictureFrame)
{
    var svgImage = pictureFrame.PictureFormat.Picture.Image.SvgImage;
    if (svgImage != null)
    {
        File.WriteAllText("output.svg", svgImage.SvgContent);
    }
}
```

## **Pobierz przezroczystość obrazu**

Aspose.Slides umożliwia pobranie efektu przezroczystości zastosowanego do obrazu. Ten kod C# demonstruje operację:

```c#
using (var presentation = new Presentation("Test.pptx"))
{
    var pictureFrame = (IPictureFrame)presentation.Slides[0].Shapes[0];
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    foreach (var effect in imageTransform)
    {
        if (effect is IAlphaModulateFixed alphaModulateFixed)
        {
            var transparencyValue = 100 - alphaModulateFixed.Amount;
            Console.WriteLine("Picture transparency: " + transparencyValue);
        }
    }
}
```

{{% alert color="primary" %}} 
Wszystkie efekty zastosowane do obrazów można znaleźć w [Aspose.Slides.Effects](https://reference.aspose.com/slides/pl/net/aspose.slides.effects/).
{{% /alert %}}

## **Formatowanie ramki obrazu**

Aspose.Slides oferuje wiele opcji formatowania, które można zastosować do ramki obrazu. Korzystając z tych opcji, możesz zmodyfikować ramkę obrazu, aby spełniała określone wymagania.

1. Utwórz instancję klasy [Presentation](http://www.aspose.com/api/net/slides/pl/aspose.slides/) class.
2. Pobierz referencję slajdu za pomocą jego indeksu. 
3. Utwórz obiekt [IPPImage](https://reference.aspose.com/slides/pl/net/aspose.slides/ippimage) przez dodanie obrazu do [IImagescollection](https://reference.aspose.com/slides/pl/net/aspose.slides/iimagecollection) powiązanej z obiektem prezentacji, który będzie używany do wypełnienia kształtu.
4. Określ szerokość i wysokość obrazu.
5. Utwórz `PictureFrame` oparty na szerokości i wysokości obrazu, używając metody [AddPictureFrame](http://www.aspose.com/api/net/slides/pl/aspose.slides/ishapecollection/methods/addpictureframe) udostępnionej przez obiekt [IShapes](http://www.aspose.com/api/net/slides/pl/aspose.slides/ishapecollection) powiązany z referencyjnym slajdem.
6. Dodaj ramkę obrazu (zawierającą obraz) do slajdu.
7. Ustaw kolor linii ramki obrazu.
8. Ustaw szerokość linii ramki obrazu.
9. Obróć ramkę obrazu, podając wartość dodatnią lub ujemną.
   * Wartość dodatnia obraca obraz zgodnie z ruchem wskazówek zegara. 
   * Wartość ujemna obraca obraz przeciwnie do ruchu wskazówek zegara.
10. Dodaj ramkę obrazu (zawierającą obraz) do slajdu.
11. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod C# demonstruje proces formatowania ramki obrazu:

```c#
// Tworzy instancję klasy Presentation, która reprezentuje plik PPTX
using (Presentation presentation = new Presentation())
{
    // Pobiera pierwszy slajd
    ISlide slide = presentation.Slides[0];

    // Ładuje obraz i dodaje go do kolekcji obrazów prezentacji
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Dodaje ramkę obrazu o tej samej wysokości i szerokości co obraz
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Stosuje formatowanie do ramki obrazu
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // Zapisuje prezentację do pliku PPTX
    presentation.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}}

Aspose niedawno opracowało [darmowy Collage Maker](https://products.aspose.app/slides/pl/collage). Jeśli kiedykolwiek potrzebujesz [połączyć obrazy JPG/JPEG](https://products.aspose.app/slides/pl/collage/jpg) lub PNG, [tworzyć siatki ze zdjęć](https://products.aspose.app/slides/pl/collage/photo-grid), możesz użyć tej usługi. 

{{% /alert %}}

## **Dodaj obraz jako link**

Aby uniknąć dużych rozmiarów prezentacji, możesz dodawać obrazy (lub wideo) przy użyciu linków zamiast osadzania plików bezpośrednio w prezentacjach. Ten kod C# pokazuje, jak dodać obraz i wideo do elementu zastępczego:

```c#
using (var presentation = new Presentation("input.pptx"))
{
    var shapesToRemove = new List<IShape>();
    int shapesCount = presentation.Slides[0].Shapes.Count;

    for (var i = 0; i < shapesCount; i++)
    {
        var autoShape = presentation.Slides[0].Shapes[i];

        if (autoShape.Placeholder == null)
        {
            continue;
        }

        switch (autoShape.Placeholder.Type)
        {
            case PlaceholderType.Picture:
                var pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle,
                        autoShape.X, autoShape.Y, autoShape.Width, autoShape.Height, null);

                pictureFrame.PictureFormat.Picture.LinkPathLong =
                    "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg";

                shapesToRemove.Add(autoShape);
                break;

            case PlaceholderType.Media:
                var videoFrame = presentation.Slides[0].Shapes.AddVideoFrame(
                    autoShape.X, autoShape.Y, autoShape.Width, autoShape.Height, "");

                videoFrame.PictureFormat.Picture.LinkPathLong =
                    "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg";

                videoFrame.LinkPathLong = "https://youtu.be/t_1LYZ102RA";

                shapesToRemove.Add(autoShape);
                break;
        }
    }

    foreach (var shape in shapesToRemove)
    {
        presentation.Slides[0].Shapes.Remove(shape);
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Przytnij obrazy**

Ten kod C# pokazuje, jak przyciąć istniejący obraz na slajdzie:

```c#
using (Presentation presentation = new Presentation())
{
    // Tworzy nowy obiekt obrazu
    IImage image = Images.FromFile(imagePath);
    IPPImage newImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Dodaje ramkę obrazu do slajdu
    IPictureFrame picFrame = presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 100, 100, 420, 250, newImage);

    // Przycina obraz (wartości procentowe)
    picFrame.PictureFormat.CropLeft = 23.6f;
    picFrame.PictureFormat.CropRight = 21.5f;
    picFrame.PictureFormat.CropTop = 3;
    picFrame.PictureFormat.CropBottom = 31;

    // Zapisuje wynik
    presentation.Save("PictureFrameCrop.pptx", SaveFormat.Pptx);
}
```

## **Usuń przycięte obszary obrazu**

Jeśli chcesz usunąć przycięte obszary obrazu zawartego w ramce, możesz użyć metody [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/pl/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/). Metoda ta zwraca przycięty obraz lub oryginalny obraz, jeśli przycinanie nie jest konieczne.

Ten kod C# demonstruje tę operację:

```c#
using (Presentation presentation = new Presentation("PictureFrameCrop.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Pobiera ramkę obrazu z pierwszego slajdu
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // Usuwa przycięte obszary obrazu w ramce obrazu i zwraca przycięty obraz
    IPPImage croppedImage = picFrame.PictureFormat.DeletePictureCroppedAreas();

    // Zapisuje wynik
    presentation.Save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
}
```

{{% alert title="NOTE" color="warning" %}} 
Metoda [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/pl/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) dodaje przycięty obraz do kolekcji obrazów prezentacji. Jeśli obraz jest używany wyłącznie w przetwarzanym [PictureFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/pictureframe/), takie ustawienie może zmniejszyć rozmiar prezentacji. W przeciwnym razie liczba obrazów w wynikowej prezentacji wzrośnie.

Metoda ta konwertuje pliki metafile WMF/EMF na rastrowy obraz PNG podczas operacji przycinania. 
{{% /alert %}}

## **Kompresuj obrazy**

Możesz skompresować obraz w prezentacji przy użyciu metody [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/pl/net/aspose.slides/ipicturefillformat/compressimage/). Metoda ta kompresuje obraz, zmniejszając jego rozmiar w oparciu o rozmiar kształtu i określoną rozdzielczość, z opcją usunięcia przyciętych obszarów.

Dostosowuje rozmiar i rozdzielczość obrazu podobnie jak funkcja PowerPoint **Picture Format → Compress Pictures → Resolution**.

Poniższe przykłady C# demonstrują, jak skompresować obraz w prezentacji, określając docelową rozdzielczość i opcjonalnie usuwając przycięte obszary:

```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // Skompresuj obraz z docelową rozdzielczością 150 DPI (rozdzielczość sieciowa) i usuń przycięte obszary.
    bool result = pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);

    // Sprawdź wynik kompresji.
    if (result)
    {
        Console.WriteLine("Image successfully compressed.");
    }
    else
    {
        Console.WriteLine("Image compression failed or no changes were necessary.");
    }

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

Lub bezpośrednio używając własnej wartości DPI:

```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // Skompresuj obraz do 150 DPI (rozdzielczość internetowa), usuwając przycięte obszary.
    pictureFrame.PictureFormat.CompressImage(true, 150f);

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

{{% alert title="NOTE" color="warning" %}} 
Metoda konwertuje obraz do niższej rozdzielczości w zależności od rozmiaru kształtu i podanego DPI. Przycięte regiony mogą być również usunięte w celu optymalizacji rozmiaru pliku.  
Jeśli obraz jest metafilem (WMF/EMF) lub SVG, kompresja nie zostanie zastosowana. Ponadto jakość JPEG jest zachowywana lub nieznacznie obniżana w zależności od rozdzielczości, podobnie jak PowerPoint obsługuje obrazy JPEG wysokiej rozdzielczości.
{{% /alert %}}

## **Zablokuj proporcje**

Jeśli chcesz, aby kształt zawierający obraz zachował proporcje nawet po zmianie wymiarów obrazu, możesz użyć własności [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/pl/net/aspose.slides/ipictureframelock/aspectratiolocked/) aby ustawić opcję *Lock Aspect Ratio*. 

Ten kod C# pokazuje, jak zablokować proporcje kształtu:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ILayoutSlide layout = pres.LayoutSlides.GetByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.Slides.AddEmptySlide(layout);

    IImage image = Images.FromFile("image.png");
    IPPImage presImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = emptySlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, presImage.Width, presImage.Height, presImage);

    // Ustawia kształt, aby zachował proporcje przy zmianie rozmiaru
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```

{{% alert title="NOTE" color="warning" %}} 
Ustawienie *Lock Aspect Ratio* zachowuje tylko proporcje kształtu, a nie obrazu, który on zawiera.
{{% /alert %}}

## **Użyj właściwości StretchOff**

Używając właściwości [StretchOffsetLeft](https://reference.aspose.com/slides/pl/net/aspose.slides/picturefillformat/properties/stretchoffsetleft), [StretchOffsetTop](https://reference.aspose.com/slides/pl/net/aspose.slides/picturefillformat/properties/stretchoffsettop), [StretchOffsetRight](https://reference.aspose.com/slides/pl/net/aspose.slides/picturefillformat/properties/stretchoffsetright) i [StretchOffsetBottom](https://reference.aspose.com/slides/pl/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) z interfejsu [IPictureFillFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/ipicturefillformat) oraz klasy [PictureFillFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/picturefillformat), możesz określić prostokąt wypełnienia. 

Kiedy dla obrazu określono rozciąganie, prostokąt źródłowy jest skalowany, aby pasował do określonego prostokąta wypełnienia. Każda krawędź prostokąta wypełnienia jest określona przez procentowy offset od odpowiedniej krawędzi ramki ograniczającej kształt. Procent dodatni określa wcięcie, a procent ujemny określa wystawienie.

1. Utwórz instancję klasy [Presentation](http://www.aspose.com/api/net/slides/pl/aspose.slides/) class.
2. Pobierz referencję slajdu za pomocą jego indeksu.
3. Dodaj prostokąt `AutoShape`. 
4. Utwórz obraz. 
5. Ustaw typ wypełnienia kształtu.
6. Ustaw tryb wypełnienia obrazu kształtu.
7. Dodaj ustawiony obraz, aby wypełnić kształt.
8. Określ offsety obrazu względem odpowiedniej krawędzi ramki ograniczającej kształt
9. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod C# demonstruje proces użycia właściwości StretchOff:

```c#
using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // Ustawia obraz rozciągnięty od każdej krawędzi w ciele kształtu
    pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
    pictureFrame.PictureFormat.StretchOffsetLeft = 24;
    pictureFrame.PictureFormat.StretchOffsetRight = 24;
    pictureFrame.PictureFormat.StretchOffsetTop = 24;
    pictureFrame.PictureFormat.StretchOffsetBottom = 24;

    pres.Save("imageStretch.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Jak mogę sprawdzić, które formaty obrazów są obsługiwane przez PictureFrame?**

Aspose.Slides obsługuje zarówno obrazy rastrowe (PNG, JPEG, BMP, GIF itp.), jak i obrazy wektorowe (np. SVG) poprzez obiekt obrazu przypisany do [PictureFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/pictureframe/). Lista obsługiwanych formatów zazwyczaj pokrywa się z możliwościami silnika konwersji slajdów i obrazów.

**Jak dodanie dziesiątek dużych obrazów wpłynie na rozmiar i wydajność pliku PPTX?**

Osadzanie dużych obrazów zwiększa rozmiar pliku i zużycie pamięci; linkowanie obrazów pomaga utrzymać mały rozmiar prezentacji, ale wymaga, aby pliki zewnętrzne pozostały dostępne. Aspose.Slides umożliwia dodawanie obrazów jako linków, aby zmniejszyć rozmiar pliku.

**Jak mogę zablokować obiekt obrazu przed przypadkowym przemieszczaniem/skalowaniem?**

Użyj [blokad kształtu](https://reference.aspose.com/slides/pl/net/aspose.slides/pictureframe/pictureframelock/) dla [PictureFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/pictureframe/) (np. wyłącz przenoszenie lub skalowanie). Mechanizm blokowania opisano w osobnym [artykule o ochronie](/slides/pl/net/applying-protection-to-presentation/), jest on obsługiwany dla różnych typów kształtów, w tym [PictureFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/pictureframe/).

**Czy jakość wektora SVG jest zachowywana przy eksportowaniu prezentacji do PDF/obrazów?**

Aspose.Slides umożliwia wyodrębnienie SVG z [PictureFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/pictureframe/) jako oryginalnego wektora. Przy [eksportowaniu do PDF](/slides/pl/net/convert-powerpoint-to-pdf/) lub [formatów rastrowych](/slides/pl/net/convert-powerpoint-to-png/), wynik może być rastrowany w zależności od ustawień eksportu; fakt, że oryginalny SVG jest przechowywany jako wektor, jest potwierdzony przez zachowanie wyodrębniania.