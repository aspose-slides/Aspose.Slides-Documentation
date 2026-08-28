---
title: Konwertuj slajdy prezentacji na obrazy w .NET
linktitle: Slajd na obraz
type: docs
weight: 41
url: /pl/net/convert-slide/
keywords:
- konwertuj slajd
- eksportuj slajd
- slajd do obrazu
- zapisz slajd jako obraz
- slajd do EMF
- slajd do PNG
- slajd do JPEG
- slajd do bitmapy
- slajd do TIFF
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Konwertuj slajdy z prezentacji PPT, PPTX i ODP na PNG, JPEG, GIF, TIFF, EMF oraz inne formaty obrazów w C# przy użyciu Aspose.Slides for .NET."
---
## **Wprowadzenie**

Aspose.Slides for .NET może renderować pojedyncze slajdy z prezentacji PowerPoint i OpenDocument jako PNG, JPEG, GIF, TIFF i inne formaty obrazów.

Aby przekonwertować slajd na obraz, wykonaj następujące kroki:

1. Załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/).
2. Wybierz slajd, który chcesz wyrenderować.
3. Jeśli to konieczne, skonfiguruj renderowanie przy użyciu klasy [RenderingOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/renderingoptions/) lub [TiffOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/tiffoptions/).
4. Wywołaj metodę [GetImage](https://reference.aspose.com/slides/pl/net/aspose.slides/islide/getimage/). Zwraca ona obiekt [IImage](https://reference.aspose.com/slides/pl/net/aspose.slides/iimage/).
5. Wywołaj metodę [IImage.Save](https://reference.aspose.com/slides/pl/net/aspose.slides/iimage/save/) i określ format wyjściowy przy użyciu wartości [ImageFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/imageformat/).

## **Konwersja slajdu do obrazu PNG**

Najprostsza konwersja używa domyślnych ustawień renderowania. Powstały obiekt [IImage](https://reference.aspose.com/slides/pl/net/aspose.slides/iimage/) może być przetwarzany w pamięci lub zapisany do pliku.

Poniższy przykład w C# renderuje pierwszy slajd i zapisuje go jako obraz PNG:

```cs
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage();
image.Save("Slide_0.png", ImageFormat.Png);
```

## **Konwersja slajdów do obrazów o niestandardowych rozmiarach**

Użyj przeciążenia [GetImage](https://reference.aspose.com/slides/pl/net/aspose.slides/islide/getimage/) które przyjmuje wartość [Size](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.size), aby wyrenderować slajd o dokładnych wymiarach w pikselach.

Poniższy przykład tworzy obraz JPEG o wymiarach 1820 × 1040:

```cs
using System.Drawing;
using Aspose.Slides;

var imageSize = new Size(1820, 1040);

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(imageSize);
image.Save("Slide_0.jpg", ImageFormat.Jpeg);
```

## **Konwersja slajdów z notatkami i komentarzami do obrazów**

Domyślnie obrazy slajdów nie zawierają notatek ani komentarzy. Przypisz obiekt [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/notescommentslayoutingoptions/) do właściwości [RenderingOptions.SlidesLayoutOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/renderingoptions/slideslayoutoptions/), aby kontrolować miejsce wyświetlania notatek i komentarzy.

Poniższy przykład umieszcza przycięte notatki pod slajdem oraz komentarze po jego prawej stronie:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var scaleX = 2f;
var scaleY = scaleX;

var layoutOptions = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomTruncated,
    CommentsPosition = CommentsPositions.Right,
    CommentsAreaWidth = 500,
    CommentsAreaColor = Color.AntiqueWhite
};

var renderingOptions = new RenderingOptions { SlidesLayoutOptions = layoutOptions };

using var presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(renderingOptions, scaleX, scaleY);
image.Save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
```

{{% alert title="Warning" color="warning" %}}
Podczas konwersji slajdu na obraz nie ustawiaj właściwości [NotesPosition](https://reference.aspose.com/slides/pl/net/aspose.slides.export/inotescommentslayoutingoptions/notesposition/) na [BottomFull](https://reference.aspose.com/slides/pl/net/aspose.slides.export/notespositions/). Notatki mogą zawierać więcej tekstu niż stały rozmiar obrazu może pomieścić. Zamiast tego użyj [BottomTruncated](https://reference.aspose.com/slides/pl/net/aspose.slides.export/notespositions/).
{{% /alert %}}

## **Konwersja slajdów do obrazów przy użyciu opcji TIFF**

Klasa [TiffOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/tiffoptions/) pozwala kontrolować rozmiar, rozdzielczość i inne właściwości renderowanego obrazu TIFF.

Poniższy przykład renderuje pierwszy slajd jako obraz TIFF o wymiarach 2160 × 2880 przy 300 DPI:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var tiffOptions = new TiffOptions
{
    ImageSize = new Size(2160, 2880),
    DpiX = 300,
    DpiY = 300
};

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(tiffOptions);
image.Save("output.tiff", ImageFormat.Tiff);
```

## **Konwersja wszystkich slajdów do obrazów**

Iteruj po kolekcji slajdów, aby przekonwertować całą prezentację na serię obrazów. Ukryte slajdy są uwzględniane, chyba że jawnie je pominiesz.

Poniższy przykład renderuje każdy slajd jako obraz JPEG z poziomymi i pionowymi współczynnikami skalowania równymi 2:

```cs
using Aspose.Slides;

var scaleX = 2f;
var scaleY = scaleX;

using var presentation = new Presentation("Presentation.pptx");

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(scaleX, scaleY);
    image.Save($"Slide_{index}.jpg", ImageFormat.Jpeg);
}
```

## **Tworzenie wyjścia w formacie Enhanced Metafile**

Enhanced Metafile (EMF) jest przydatny, gdy grafika wektorowa musi być wymieniana z Microsoft Office lub innymi aplikacjami Windows obsługującymi metafile Windows. W przeciwieństwie do obrazu rastrowego, EMF może zachować operacje rysowania wektorowego, które skalują się bez utraty ostrości. Jednak EMF jest przede wszystkim formatem kompatybilności dla aplikacji obsługujących metafile Windows, a nie uniwersalnym formatem wymiany. Dodatkowo, złożona zawartość slajdu, taka jak obrazy bitmapowe i niektóre efekty, może być przechowywana jako elementy rasteryzowane w wewnątrz kontenera metafile wektorowego.

### **Eksport slajdu do EMF**

Metoda [ISlide.WriteAsEmf](https://reference.aspose.com/slides/pl/net/aspose.slides/islide/writeasemf/) zapisuje [ISlide](https://reference.aspose.com/slides/pl/net/aspose.slides/islide/) do docelowego strumienia w formacie EMF. Poniższy przykład ładuje prezentację, wybiera pierwszy slajd i zapisuje go do strumienia pliku EMF:

```cs
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var emfStream = File.Create("Slide_0.emf");
slide.WriteAsEmf(emfStream);
```

Wywołujący posiada strumień przekazany do [ISlide.WriteAsEmf](https://reference.aspose.com/slides/pl/net/aspose.slides/islide/writeasemf/) i musi go zamknąć lub zwolnić. Aspose.Slides zapisuje w bieżącej pozycji strumienia i pozostawia go otwartym.

### **Konwersja obrazu SVG do EMF i dodanie go do prezentacji**

Użyj [ISvgImage.WriteAsEmf](https://reference.aspose.com/slides/pl/net/aspose.slides/isvgimage/writeasemf/), aby przekonwertować zawartość SVG na EMF. Powstałe bajty mogą być dodane do prezentacji za pomocą [IImageCollection.AddImage](https://reference.aspose.com/slides/pl/net/aspose.slides/iimagecollection/addimage/) i umieszczone na slajdzie przy pomocy [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/ishapecollection/addpictureframe/).

Poniższy przykład tworzy [SvgImage](https://reference.aspose.com/slides/pl/net/aspose.slides/svgimage/) z kodu SVG, konwertuje go na EMF w pamięci, wstawia metafile na pierwszym slajdzie i zapisuje prezentację:

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var emfStream = new MemoryStream();
svgImage.WriteAsEmf(emfStream);

emfStream.Position = 0;
var image = presentation.Images.AddImage(emfStream);
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 100, image);

presentation.Save("Presentation_with_emf.pptx", SaveFormat.Pptx);
```

[ISvgImage.WriteAsEmf](https://reference.aspose.com/slides/pl/net/aspose.slides/isvgimage/writeasemf/) nie przejmuje własności docelowego strumienia. Po zapisaniu pozycja strumienia znajduje się na końcu wygenerowanych danych. Zresetuj `Position` na początek przed przekazaniem tego samego strumienia możliwego do przeszukania do czytnika, jak pokazano powyżej. Trzymaj strumień otwarty, aż konsument zakończy jego odczyt, i zwolnij go później. Alternatywnie, wywołaj `ToArray` i przekaż zwróconą tablicę bajtów do [IImageCollection.AddImage](https://reference.aspose.com/slides/pl/net/aspose.slides/iimagecollection/addimage/); `ToArray` zwraca pełny bufor niezależnie od bieżącej pozycji strumienia.

Generowanie EMF jest dostępne na systemach operacyjnych obsługiwanych przez wybraną wersję Aspose.Slides for .NET, ale renderowanie może się różnić między platformami, gdy czcionki lub natywne zależności graficzne są niedostępne. Zainstaluj czcionki używane w oryginalnej treści lub skonfiguruj odpowiednie zamienniki, postępuj zgodnie z [platform requirements](/slides/pl/net/system-requirements/) dla pakietu Aspose.Slides i zweryfikuj wynik w docelowej aplikacji konsumującej EMF. Aplikacje na Linux i macOS często mają ograniczone lub niespójne wsparcie dla wyświetlania i edycji metafile Windows.

## **Renderowanie kolorowych emoji**

{{% alert title="Note" color="info" %}}
Aby prawidłowo renderować kolorowe emoji przy konwersji slajdów prezentacji na obrazy, czcionki emoji użyte w prezentacji muszą być zainstalowane i dostępne w systemie wykonującym konwersję. Na przykład, jeśli prezentacja używa **Segoe UI Emoji** i ta czcionka jest nieobecna, emoji mogą pojawiać się w wersji monochromatycznej w obrazach wyjściowych.
{{% /alert %}}

## **FAQ**

**Czy Aspose.Slides obsługuje renderowanie slajdów z animacjami?**

Nie. Metoda [GetImage](https://reference.aspose.com/slides/pl/net/aspose.slides/islide/getimage/) renderuje statyczny obraz slajdu i nie eksportuje animacji.

**Czy ukryte slajdy mogą być eksportowane jako obrazy?**

Tak. Ukryte slajdy mogą być renderowane tak jak zwykłe slajdy. Uwzględnij je w pętli przetwarzania, jak pokazano w powyższym przykładzie.

**Czy cienie i inne efekty są zachowywane w obrazach slajdów?**

Tak. Aspose.Slides renderuje cienie, przezroczystość i inne obsługiwane efekty graficzne w obrazach slajdów.