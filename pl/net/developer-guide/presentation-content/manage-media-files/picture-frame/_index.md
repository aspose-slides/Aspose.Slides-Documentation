---
title: Zarządzanie ramkami obrazów w prezentacjach w .NET
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
- skalowanie względne
- efekt obrazu
- proporcje obrazu
- przezroczystość obrazu
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dodaj ramki obrazu do prezentacji PowerPoint i OpenDocument przy użyciu Aspose.Slides dla .NET. Usprawnij swój proces pracy i ulepsz projekty slajdów."
---
## **Wprowadzenie**

Ramka obrazu to kształt, który zawiera obraz — jest to jak obraz w ramce. 

Możesz dodać obraz do slajdu za pomocą ramki obrazu. W ten sposób możesz formatować obraz, formatując ramkę obrazu.

{{% alert  title="Tip" color="primary" %}} 
Aspose udostępnia bezpłatne konwertery — [JPEG do PowerPoint](https://products.aspose.app/slides/pl/import/jpg-to-ppt) i [PNG do PowerPoint](https://products.aspose.app/slides/pl/import/png-to-ppt) — które umożliwiają szybkie tworzenie prezentacji z obrazów. 
{{% /alert %}} 

## **Utwórz ramkę obrazu**

1. Utwórz instancję klasy [Presentation ](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
2. Uzyskaj referencję do slajdu za pomocą jego indeksu. 
3. Utwórz obiekt [IPPImage](https://reference.aspose.com/slides/pl/net/aspose.slides/ippimage), dodając obraz do [IImagescollection](https://reference.aspose.com/slides/pl/net/aspose.slides/iimagecollection) powiązanej z obiektem prezentacji, który będzie używany do wypełnienia kształtu.
4. Określ szerokość i wysokość obrazu.
5. Utwórz [PictureFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/pictureframe) na podstawie szerokości i wysokości obrazu, korzystając z metody `AddPictureFrame` udostępnionej przez obiekt kształtu powiązany z referencyjnym slajdem.
6. Dodaj ramkę obrazu (zawierającą obraz) do slajdu.
7. Zapisz zmodyfikowaną prezentację jako plik PPTX.

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

    // Dodaje ramkę obrazu o takiej samej wysokości i szerokości
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Stosuje pewne formatowanie do ramki obrazu
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // Zapisuje prezentację do pliku PPTX
    pres.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" %}} 
Ramki obrazu pozwalają szybko tworzyć slajdy prezentacji na podstawie obrazów. Łącząc ramkę obrazu z opcjami zapisu Aspose.Slides, możesz manipulować operacjami wejścia/wyjścia, aby konwertować obrazy z jednego formatu na inny. Możesz zainteresować się następującymi stronami: konwersja [image to JPG](https://products.aspose.com/slides/pl/net/conversion/image-to-jpg/); konwersja [JPG to image](https://products.aspose.com/slides/pl/net/conversion/jpg-to-image/); konwersja [JPG to PNG](https://products.aspose.com/slides/pl/net/conversion/jpg-to-png/), konwersja [PNG to JPG](https://products.aspose.com/slides/pl/net/conversion/png-to-jpg/); konwersja [PNG to SVG](https://products.aspose.com/slides/pl/net/conversion/png-to-svg/), konwersja [SVG to PNG](https://products.aspose.com/slides/pl/net/conversion/svg-to-png/).
{{% /alert %}}

## **Utwórz ramkę obrazu ze skalowaniem względnym**

Poprzez zmianę względnego skalowania obrazu możesz utworzyć bardziej zaawansowaną ramkę obrazu. 

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
2. Uzyskaj referencję do slajdu za pomocą jego indeksu. 
3. Dodaj obraz do kolekcji obrazów prezentacji.
4. Utwórz obiekt [IPPImage](https://reference.aspose.com/slides/pl/net/aspose.slides/ippimage), dodając obraz do [IImagescollection](https://reference.aspose.com/slides/pl/net/aspose.slides/iimagecollection) powiązanej z obiektem prezentacji, który będzie używany do wypełnienia kształtu.
5. Określ względną szerokość i wysokość obrazu w ramce obrazu.
6. Zapisz zmodyfikowaną prezentację jako plik PPTX.

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

Możesz wyodrębnić obrazy rastrowe z obiektów [PictureFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/pictureframe) i zapisać je w formatach PNG, JPG i innych. Poniższy przykład kodu pokazuje, jak wyodrębnić obraz z dokumentu "sample.pptx" i zapisać go w formacie PNG.

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

Kiedy prezentacja zawiera grafikę SVG umieszczoną wewnątrz kształtów [PictureFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/pictureframe/), Aspose.Slides dla .NET umożliwia pobranie oryginalnych obrazów wektorowych z pełną wiernością. Przeglądając kolekcję kształtów slajdu, możesz zidentyfikować każdy [PictureFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/pictureframe/), sprawdzić, czy leżący pod nim [IPPImage](https://reference.aspose.com/slides/pl/net/aspose.slides/ippimage/) zawiera treść SVG, a następnie zapisać ten obraz na dysku lub do strumienia w natywnym formacie SVG.

Poniższy przykład kodu pokazuje, jak wyodrębnić obraz SVG z ramki obrazu:

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

Aspose.Slides umożliwia pobranie efektu przezroczystości zastosowanego do obrazu. Ten kod C# demonstruje tę operację:

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

## **Pobierz jasność i kontrast obrazu**

Aspose.Slides umożliwia pobranie efektu jasności i kontrastu zastosowanego do obrazu. Interfejs [ILuminance](https://reference.aspose.com/slides/pl/net/aspose.slides.effects/iluminance/) reprezentuje tę transformację obrazu.

Ten kod C# pokazuje, jak pobrać ustawienia jasności i kontrastu z ramki obrazu:

```csharp
using (var presentation = new Presentation("sample.pptx"))
{
    var slide = presentation.Slides[0];
    var shape = slide.Shapes[0];
    var pictureFrame = (IPictureFrame)shape;

    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    foreach (var effect in imageTransform)
    {
        if (effect is ILuminance luminanceEffect)
        {
            var luminance = luminanceEffect.GetEffective();
            var brightness = luminance.Brightness;
            var contrast = luminance.Contrast;

            Console.WriteLine("Brightness: " + brightness);
            Console.WriteLine("Contrast: " + contrast);
        }
    }
}
```

{{% alert color="primary" %}} 
Wszystkie efekty stosowane do obrazów można znaleźć w [Aspose.Slides.Effects](https://reference.aspose.com/slides/pl/net/aspose.slides.effects/).
{{% /alert %}}

## **Formatowanie ramki obrazu**

Aspose.Slides udostępnia wiele opcji formatowania, które można zastosować do ramki obrazu. Korzystając z tych opcji, możesz dostosować ramkę obrazu do konkretnych wymagań.

1. Utwórz instancję klasy [Presentation](http://www.aspose.com/api/net/slides/pl/aspose.slides/) .
2. Uzyskaj referencję do slajdu za pomocą jego indeksu. 
3. Utwórz obiekt [IPPImage](https://reference.aspose.com/slides/pl/net/aspose.slides/ippimage) poprzez dodanie obrazu do [IImagescollection](https://reference.aspose.com/slides/pl/net/aspose.slides/iimagecollection) powiązanej z obiektem prezentacji, który będzie używany do wypełnienia kształtu.
4. Określ szerokość i wysokość obrazu.
5. Utwórz `PictureFrame` na podstawie szerokości i wysokości obrazu, korzystając z metody [AddPictureFrame](http://www.aspose.com/api/net/slides/pl/aspose.slides/ishapecollection/methods/addpictureframe) udostępnionej przez obiekt [IShapes](http://www.aspose.com/api/net/slides/pl/aspose.slides/ishapecollection) powiązany z referencyjnym slajdem.
6. Dodaj ramkę obrazu (zawierającą obraz) do slajdu.
7. Ustaw kolor linii ramki obrazu.
8. Ustaw szerokość linii ramki obrazu.
9. Obróć ramkę obrazu, podając wartość dodatnią lub ujemną.  
   * Dodatnia wartość obraca obraz zgodnie z ruchem wskazówek zegara.  
   * Ujemna wartość obraca obraz przeciwnie do ruchu wskazówek zegara.
10. Dodaj ramkę obrazu (zawierającą obraz) do slajdu.
11. Zapisz zmodyfikowaną prezentację jako plik PPTX.

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

    // Dodaje ramkę obrazu o takiej samej wysokości i szerokości jak obraz
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Stosuje pewne formatowanie do ramki obrazu
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // Zapisuje prezentację do pliku PPTX
    presentation.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}}

Aspose niedawno opracował [bezpłatny Collage Maker](https://products.aspose.app/slides/pl/collage). Jeśli kiedykolwiek będziesz potrzebować [scalić JPG/JPEG](https://products.aspose.app/slides/pl/collage/jpg) lub obrazy PNG, [tworzyć siatki ze zdjęć](https://products.aspose.app/slides/pl/collage/photo-grid), możesz skorzystać z tej usługi. 
{{% /alert %}}

## **Dodaj obraz jako odnośnik**

Aby uniknąć dużych rozmiarów prezentacji, możesz dodawać obrazy (lub filmy) za pomocą odnośników zamiast osadzania plików bezpośrednio w prezentacjach. Ten kod C# pokazuje, jak dodać obraz i film do zastępnika:

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

Jeśli chcesz usunąć przycięte obszary obrazu zawartego w ramce, możesz użyć metody [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/pl/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/). Metoda ta zwraca przycięty obraz lub oryginalny obraz, jeśli przycinanie nie jest potrzebne.

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
Metoda [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/pl/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) dodaje przycięty obraz do kolekcji obrazów prezentacji. Jeśli obraz jest używany wyłącznie w przetwarzanej [PictureFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/pictureframe/), to rozwiązanie może zmniejszyć rozmiar prezentacji. W przeciwnym razie liczba obrazów w wynikowej prezentacji wzrośnie.

Metoda konwertuje metapliki WMF/EMF na rastrowe obrazy PNG w trakcie przycinania. 
{{% /alert %}}

## **Kompresuj obrazy**

Możesz skompresować obraz w prezentacji, używając metody [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/pl/net/aspose.slides/ipicturefillformat/compressimage/). Metoda ta kompresuje obraz, zmniejszając jego rozmiar w zależności od rozmiaru kształtu i określonej rozdzielczości, z opcją usunięcia przyciętych obszarów. 

Działa podobnie jak funkcja PowerPoint **Picture Format → Compress Pictures → Resolution**.

Poniższe przykłady C# pokazują, jak skompresować obraz w prezentacji, podając docelową rozdzielczość i opcjonalnie usuwając przycięte obszary:

```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // Kompresuje obraz z docelową rozdzielczością 150 DPI (rozdzielczość sieciowa) i usuwa przycięte obszary.
    bool result = pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);

    // Sprawdza wynik kompresji.
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

Albo bezpośrednio używając własnej wartości DPI:

```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // Kompresuje obraz do 150 DPI (rozdzielczość internetowa), usuwając przycięte obszary.
    pictureFrame.PictureFormat.CompressImage(true, 150f);

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

{{% alert title="NOTE" color="warning" %}} 
Metoda konwertuje obraz do niższej rozdzielczości w zależności od rozmiaru kształtu i podanego DPI. Przycięte fragmenty mogą być również usuwane w celu optymalizacji rozmiaru pliku.  
Jeśli obraz jest metafilem (WMF/EMF) lub SVG, kompresja nie zostanie zastosowana. Jakość JPEG jest zachowywana lub nieznacznie obniżana w zależności od rozdzielczości, podobnie jak w PowerPoint przy obsłudze wysokiej rozdzielczości JPEG.
{{% /alert %}}

## **Zablokuj proporcje**

Jeśli chcesz, aby kształt zawierający obraz zachował proporcje nawet po zmianie wymiarów obrazu, możesz użyć właściwości [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/pl/net/aspose.slides/ipictureframelock/aspectratiolocked/) do ustawienia opcji *Lock Aspect Ratio*. 

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

    // Ustawia kształt tak, aby zachować proporcje przy zmianie rozmiaru
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```

{{% alert title="NOTE" color="warning" %}} 
Ustawienie *Lock Aspect Ratio* zachowuje wyłącznie proporcje kształtu, a nie obrazu, który zawiera.
{{% /alert %}}

## **Użyj właściwości StretchOff**

Korzystając z właściwości [StretchOffsetLeft](https://reference.aspose.com/slides/pl/net/aspose.slides/picturefillformat/properties/stretchoffsetleft), [StretchOffsetTop](https://reference.aspose.com/slides/pl/net/aspose.slides/picturefillformat/properties/stretchoffsettop), [StretchOffsetRight](https://reference.aspose.com/slides/pl/net/aspose.slides/picturefillformat/properties/stretchoffsetright) i [StretchOffsetBottom](https://reference.aspose.com/slides/pl/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) interfejsu [IPictureFillFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/ipicturefillformat) oraz klasy [PictureFillFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/picturefillformat), możesz określić prostokąt wypełnienia. 

Gdy określone jest rozciąganie obrazu, prostokąt źródłowy jest skalowany, aby pasował do określonego prostokąta wypełnienia. Każda krawędź prostokąta wypełnienia jest definiowana jako procentowy offset od odpowiedniej krawędzi obwiedni kształtu. Pozytywny procent oznacza wcięcie, natomiast ujemny procent oznacza wyjście poza obwiednię.

1. Utwórz instancję klasy [Presentation](http://www.aspose.com/api/net/slides/pl/aspose.slides/) .
2. Uzyskaj referencję do slajdu za pomocą jego indeksu.
3. Dodaj prostokąt `AutoShape`. 
4. Utwórz obraz.
5. Ustaw typ wypełnienia kształtu.
6. Ustaw tryb wypełnienia obrazu kształtu.
7. Dodaj obraz do wypełnienia kształtu.
8. Określ offsety obrazu względem odpowiedniej krawędzi obwiedni kształtu.
9. Zapisz zmodyfikowaną prezentację jako plik PPTX.

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

**Jak mogę dowiedzieć się, które formaty obrazów są obsługiwane przez PictureFrame?**

Aspose.Slides obsługuje zarówno obrazy rastrowe (PNG, JPEG, BMP, GIF itp.), jak i obrazy wektorowe (na przykład SVG) poprzez obiekt obrazu przypisany do [PictureFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/pictureframe/). Lista obsługiwanych formatów zazwyczaj pokrywa się z możliwościami silnika konwersji slajdów i obrazów.

**Jak dodanie dziesiątek dużych obrazów wpłynie na rozmiar i wydajność pliku PPTX?**

Osadzanie dużych obrazów zwiększa rozmiar pliku i zużycie pamięci; łączenie obrazów za pomocą odnośników pomaga utrzymać mały rozmiar prezentacji, ale wymaga, aby pliki zewnętrzne pozostały dostępne. Aspose.Slides umożliwia dodawanie obrazów jako odnośników w celu zmniejszenia rozmiaru pliku.

**Jak mogę zablokować obiekt obrazu przed przypadkowym przemieszczaniem/skalowaniem?**

Użyj [shape locks](https://reference.aspose.com/slides/pl/net/aspose.slides/pictureframe/pictureframelock/) dla [PictureFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/pictureframe/) (np. wyłącz przesuwanie lub skalowanie). Mechanizm blokowania opisano w osobnym [artykule o ochronie](/slides/pl/net/applying-protection-to-presentation/) i jest obsługiwany dla różnych typów kształtów, w tym [PictureFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/pictureframe/).

**Czy wierność wektorowa SVG jest zachowywana przy eksporcie prezentacji do PDF/obrazów?**

Aspose.Slides pozwala wyodrębnić SVG z [PictureFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/pictureframe/) jako oryginalny wektor. Przy [eksportowaniu do PDF](/slides/pl/net/convert-powerpoint-to-pdf/) lub [formatów rastrowych](/slides/pl/net/convert-powerpoint-to-png/), wynik może być rasteryzowany w zależności od ustawień eksportu; fakt, że oryginalny SVG jest przechowywany jako wektor, jest potwierdzony przez zachowanie wyodrębniania.