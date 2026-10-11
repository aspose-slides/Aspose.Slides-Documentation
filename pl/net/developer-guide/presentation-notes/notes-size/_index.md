---
title: Zmień rozmiar i orientację strony notatek w .NET
linktitle: Rozmiar strony notatek
type: docs
weight: 10
url: /pl/net/notes-size/
keywords:
- rozmiar strony notatek
- orientacja notatek
- notatki poziome
- notatki pionowe
- rozmiar materiału pomocniczego
- PowerPoint
- prezentacja
- PPT
- PPTX
- C#
- Aspose.Slides
description: "Czytaj i zmieniaj wymiary strony notatek w Aspose.Slides dla .NET, przełączaj orientację, weryfikuj zapisane rozmiary oraz eksportuj notatki lub materiały pomocnicze do PDF i obrazów."
---
## **Przegląd**

Użyj [Presentation.NotesSize](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/notessize/) aby uzyskać dostęp do ustawień strony notatek prezentacji. Zwraca ona obiekt [INotesSize](https://reference.aspose.com/slides/pl/net/aspose.slides/inotessize/) którego własność [Size](https://reference.aspose.com/slides/pl/net/aspose.slides/inotessize/size/) jest zapisywalna. Chociaż sam obiekt ustawień jest tylko do odczytu, możesz przypisać nowe wymiary do jego właściwości size.

Szerokość i wysokość podawane są w **punktach**, przy 72 punktach na cal. Na przykład 900 × 600 punktów to 12.5 × 8⅓ cala. Te ustawienia dotyczą całej prezentacji, a nie notatek pojedynczego slajdu.

| Ustawienie | Cel |
| --- | --- |
| [Presentation.NotesSize](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/notessize/) | Kontroluje wymiary strony notatek oraz wymiary strony używane przy eksporcie materiałów pomocniczych. |
| [Presentation.SlideSize](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/slidesize/) | Kontroluje wymiary standardowych slajdów prezentacji za pomocą [ISlideSize](https://reference.aspose.com/slides/pl/net/aspose.slides/islidesize/). |

Zmiana któregokolwiek ustawienia nie zmienia automatycznie drugiego. Zmiana orientacji strony notatek nie obraca również standardowych slajdów. Zobacz [Slide Size](/slides/pl/net/slide-size/), aby zmienić rozmiar standardowych slajdów.

Poniższe przykłady używają istniejącego pliku `sample.pptx`. Dla przykładów eksportu użyj prezentacji zawierającej przynajmniej jeden slajd z notatkami prelegenta. Każdy przykład może być uruchomiony niezależnie.

## **Odczyt rozmiaru i orientacji strony notatek**

Odczytaj szerokość i wysokość i porównaj je, aby określić orientację: szersza strona to orientacja pozioma, wyższa – pionowa, a równe wymiary opisują stronę kwadratową. Ten przykład wypisuje rzeczywiste wymiary w punktach, nie zakładając standardowego rozmiaru papieru.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var size = presentation.NotesSize.Size;
var orientation = "Square";

if (size.Width > size.Height)
    orientation = "Landscape";
else if (size.Width < size.Height)
    orientation = "Portrait";

Console.WriteLine($"Notes page: {size.Width} x {size.Height} points");
Console.WriteLine($"Orientation: {orientation}");
```

## **Przejście do orientacji poziomej bez zmiany rozmiaru papieru**

Aby zmienić tylko orientację, zamień istniejącą szerokość i wysokość miejscami. Dzięki temu zachowane zostają długości obu boków, w tym te dla niestandardowego rozmiaru papieru. Warunek poniżej zapobiega przekształceniu już poziomej strony z powrotem na pionową i pozostawia stronę kwadratową niezmienioną.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var size = presentation.NotesSize.Size;

if (size.Width < size.Height)
    presentation.NotesSize.Size = new SizeF(size.Height, size.Width);

presentation.Save("landscape-notes.pptx", SaveFormat.Pptx);
```

Dla orientacji pionowej użyj tego samego przypisania, gdy `size.Width > size.Height`. Nie podstawiaj wymiarów A4 ani Letter, chyba że chcesz również zmienić rozmiar papieru.

## **Ustaw i zweryfikuj niestandardowy rozmiar strony notatek**

Przypisz oba wymiary jednocześnie, a następnie użyj [Presentation.Save](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/save/) aby zapisać prezentację. Ten przykład ustawia stronę poziomą o wymiarach 900 × 600 punktów, zapisuje ją jako PPTX i ponownie otwiera zapisany plik, aby sprawdzić zachowane wartości. Porównanie dopuszcza tolerancję 0.01 punktu dla wartości zmiennoprzecinkowych; nie jest to gwarancja precyzji dla każdego formatu pliku.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var expectedSize = new SizeF(900, 600);
presentation.NotesSize.Size = expectedSize;
presentation.Save("custom-notes.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("custom-notes.pptx");
var actualSize = reopened.NotesSize.Size;
var widthMatches = Math.Abs(actualSize.Width - expectedSize.Width) < 0.01f;
var heightMatches = Math.Abs(actualSize.Height - expectedSize.Height) < 0.01f;
var preserved = widthMatches && heightMatches;

Console.WriteLine($"Stored notes page: {actualSize.Width} x {actualSize.Height} points");
Console.WriteLine($"Size preserved: {preserved}");
```

Oczekiwany rezultat to `900 x 600 points` oraz `Size preserved: True`. Sprawdzenie nowo otwartej prezentacji weryfikuje zapisany plik, a nie jedynie ustawienia w pamięci.

## **Eksport notatek i materiałów pomocniczych**

Wymiary strony określają dostępny obszar dla układów notatek lub materiałów pomocniczych. Same w sobie nie włączają tych układów: należy również skonfigurować opcje eksportu. Eksport standardowych slajdów nadal używa wymiarów slajdu.

### **Eksport notatek do PDF i PNG**

Przypisz [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/notescommentslayoutingoptions/) do [PdfOptions.SlidesLayoutOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/pdfoptions/slideslayoutoptions/), aby uwzględnić notatki w PDF. Ten przykład renderuje również pierwszy slajd z notatkami do PNG przy użyciu [Slide.GetImage](https://reference.aspose.com/slides/pl/net/aspose.slides/slide/getimage/) oraz [RenderingOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/renderingoptions/).

Tryb [BottomTruncated](https://reference.aspose.com/slides/pl/net/aspose.slides.export/notespositions/) utrzymuje notatki na jednej stronie; notatki, które nie mieszczą się, mogą być obcięte. PDF używa stron o wymiarach 900 × 600 punktów. Przy skali obrazu 1 × 1 użytej poniżej, PNG ma wymiary 900 × 600 pikseli. Punkty opisują geometrię strony; piksele opisują wyjście rastrowe, którego wymiary zależą również od skali renderowania.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
presentation.NotesSize.Size = new SizeF(900, 600);

var layout = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomTruncated
};

var pdfOptions = new PdfOptions { SlidesLayoutOptions = layout };
presentation.Save("notes.pdf", SaveFormat.Pdf, pdfOptions);

var renderingOptions = new RenderingOptions { SlidesLayoutOptions = layout };
using var image = presentation.Slides[0].GetImage(renderingOptions, 1, 1);
image.Save("first-slide-notes.png", ImageFormat.Png);
```

Dla eksportu PDF z długimi notatkami, [BottomFull](https://reference.aspose.com/slides/pl/net/aspose.slides.export/notespositions/) umożliwia dodanie kolejnych stron w razie potrzeby. Nie używaj tego trybu z wywołaniem obrazu pojedynczego slajdu powyżej, które go nie obsługuje. Po zmianie rozmiaru sprawdź wyjście pod kątem przyciętych notatek i położenia istniejących obiektów notes-master; zmiana rozmiaru strony sama w sobie nie gwarantuje, że cała treść się zmieści. Zobacz [Convert PowerPoint to PDF with Notes](/slides/pl/net/convert-powerpoint-to-pdf-with-notes/) po więcej informacji o eksporcie notatek.

### **Eksport materiałów pomocniczych do PDF**

Użyj [HandoutLayoutingOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/handoutlayoutingoptions/) do umieszczenia wielu miniaturek slajdów na jednej stronie. Następujący przykład ustawia stronę o wymiarach 900 × 600 punktów i wykorzystuje [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/pl/net/aspose.slides.export/handouttype/), aby rozmieszczać do czterech slajdów na stronę. Ustawienie poziome kontroluje kolejność slajdów; orientacja strony pochodzi z jej szerokości i wysokości.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
presentation.NotesSize.Size = new SizeF(900, 600);

var layout = new HandoutLayoutingOptions
{
    Handout = HandoutType.Handouts4Horizontal
};

var pdfOptions = new PdfOptions { SlidesLayoutOptions = layout };
presentation.Save("handouts.pdf", SaveFormat.Pdf, pdfOptions);
```

Zmiana rozmiaru strony zmienia obszar dostępny dla siatki materiałów pomocniczych bez zmiany wymiarów slajdów źródłowych. Dla obrazów materiałów pomocniczych użyj [Presentation.GetImages](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/getimages/) z układem handoutu, zamiast metody obrazu pojedynczego slajdu. W Aspose.Slides renderowanie handoutu na poziomie prezentacji wykorzystuje wymiary strony notatek, natomiast wywołanie obrazu pojedynczego slajdu nie generuje strony handout. Zobacz [Handoff Mode](/slides/pl/net/convert-powerpoint-in-handout-mode/) po opcje układu.

## **Rozmiar strony w przeglądarkach, eksportach i druku**

Utrzymuj odrębne rozmiary: przechowywany rozmiar prezentacji, rozmiar strony po eksporcie oraz rozmiar papieru po wydrukowaniu:

- **Przeglądarki prezentacji:** Przeglądarka może wyświetlać lub drukować notatki według własnych reguł układu. Jeśli inna aplikacja zapisze plik, otwórz go ponownie i sprawdź wymiary; konwersja formatu przez tę aplikację może je znormalizować.
- **Formaty eksportu:** Przykłady PDF notatek i materiałów pomocniczych powyżej używają skonfigurowanych wymiarów strony. Obrazy rastrowe używają całkowitych wymiarów w pikselach i skali renderowania, więc ułamkowe wartości punktów mogą być zaokrąglane w wyjściu obrazu. Eksport standardowych slajdów nie używa rozmiaru strony notatek.
- **Sterowniki drukarek:** Wybór papieru, automatyczna rotacja i ustawienia dopasowania do strony mogą zmienić fizyczny wynik bez zmiany wymiarów zapisanych w prezentacji lub PDF. Dla konkretnego rozmiaru papieru dopasuj ustawienia drukarki i sprawdź podgląd wydruku.

## **FAQ**

**Czy mogę ustawić rozmiar notatek tylko dla jednego slajdu?**

Rozmiar strony notatek jest ustawieniem na poziomie całej prezentacji. Poszczególne slajdy mogą mieć różną treść notatek, ale ta właściwość nie umożliwia określenia osobnego rozmiaru strony dla każdego slajdu.

**Dlaczego zmiana orientacji notatek nie zmieniła moich slajdów?**

Strony notatek i standardowe slajdy mają niezależne wymiary. Użyj ustawień rozmiaru standardowych slajdów, gdy chcesz zmienić rozmiar samych slajdów.

**Dlaczego mój zapisany lub wydrukowany rezultat ma inny rozmiar?**

Najpierw otwórz ponownie zapisaną prezentację i porównaj wymiary notatek. Jeśli uległy one zmianie, sprawdź, czy zapis lub konwersja pliku w innej aplikacji zmieniły ustawienia strony. Jeśli nie, sprawdź układ eksportu, skalę obrazu, ustawienia przeglądarki oraz wybór papieru w drukarce.