---
title: Zarządzanie placeholderami prezentacji w .NET
linktitle: Zarządzanie placeholderami
type: docs
weight: 10
url: /pl/net/manage-placeholder/
keywords:
- symbol zastępczy
- placeholder tekstowy
- placeholder obrazu
- placeholder wykresu
- placeholder treści
- tekst podpowiedzi
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak przeglądać i edytować placeholdery tekstowe, obrazowe, wykresów i treści oraz zrozumieć dziedziczenie placeholderów przy użyciu Aspose.Slides dla .NET."
---
## **Przegląd**

Placeholder jest kształtem, który rezerwuje pozycję dla określonego rodzaju treści w szablonie prezentacji. Typowe przykłady to placeholdery tytułu, treści, obrazu, wykresu oraz ogólnego przeznaczenia. W przeciwieństwie do zwykłego kształtu, placeholder może dziedziczyć swoją pozycję, rozmiar, formatowanie i inne ustawienia z slajdu układu lub slajdu nadrzędnego.

Aspose.Slides udostępnia informacje o placeholderach poprzez właściwość [IShape.Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/). Właściwość zwraca obiekt [IPlaceholder](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/) lub `null` dla zwykłego kształtu. Użyj [IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/), aby określić, co placeholder ma zawierać.

Interfejs kształtu nadal ma znaczenie po poznaniu typu placeholdera:

- Pusty placeholder tekstu, obrazu, wykresu lub treści jest zazwyczaj reprezentowany przez [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).
- Zapełniony placeholder obrazu może być reprezentowany przez [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/).
- Zapełniony placeholder wykresu może być reprezentowany przez [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/).
- Placeholder treści może zawierać kilka rodzajów treści. Sprawdź zarówno [IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) jak i interfejs kształtu w czasie wykonania, zamiast zakładać, że każdy placeholder jest [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) opisuje rolę placeholdera; nie gwarantuje typu kształtu w czasie wykonania. Zawsze używaj sprawdzania typu przed dostępem do członków specyficznych dla tekstu, obrazu, wykresu, tabeli lub multimediów.
{{% /alert %}}

## **Zrozumienie dziedziczenia placeholderów**

Placeholdery tworzą hierarchię:

1. Slajd master definiuje style wielokrotnego użytku i, w niektórych przypadkach, placeholdery na poziomie mastera.
2. Slajd układu definiuje rozmieszczenie używane przez jeden lub więcej normalnych slajdów i może dziedziczyć po masterze.
3. Normalny slajd zawiera placeholdery dla tego slajdu i może dziedziczyć po jego układzie.

Wywołaj [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/getbaseplaceholder/), aby przejść jeden poziom wyżej w tej hierarchii. Placeholder slajdu zazwyczaj zwraca swój placeholder układu; placeholder układu może zwrócić swój placeholder master. Metoda zwraca `null`, gdy kształt nie ma bazowego placeholdera.

Dla przykładu poniżej wyświetlone są placeholdery na pierwszym slajdzie oraz ich bazowe placeholdery:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = shape.Placeholder.Type;
    var typeName = shape.GetType().Name;
    Console.WriteLine($"Slide placeholder: {placeholderType}; shape interface: {typeName}");

    var layoutPlaceholder = shape.GetBasePlaceholder();
    if (layoutPlaceholder != null)
    {
        var layoutPlaceholderType = layoutPlaceholder.Placeholder?.Type;
        Console.WriteLine($"  Layout placeholder: {layoutPlaceholderType}");

        var masterPlaceholder = layoutPlaceholder.GetBasePlaceholder();
        if (masterPlaceholder != null)
        {
            var masterPlaceholderType = masterPlaceholder.Placeholder?.Type;
            Console.WriteLine($"  Master placeholder: {masterPlaceholderType}");
        }
    }
}
```

Edytowanie placeholdera na normalnym slajdzie tworzy lub zmienia lokalne nadpisanie dla tego slajdu. Edytowanie powiązanego układu lub mastera może wpływać na wszystkie slajdy, które nadal dziedziczą to ustawienie. Zwykły lokalny kształt nie ma bazowego placeholdera i nie zaczyna dziedziczyć tylko dlatego, że zajmuje te same współrzędne.

## **Usunięcie statusu placeholdera**

Podczas dostosowywania szablonu użyj [IShape.RemovePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/removeplaceholder/), aby zachować istniejący obiekt jako zwykły kształt. Jego właściwość [Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/) staje się `null`, ale kształt pozostaje w kolekcji slajdu. Natomiast [IShapeCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/remove/) usuwa kształt z tej kolekcji.

Poniższy przykład wymaga pliku `template.pptx` z co najmniej jednym slajdem i niepustym placeholderem tekstowym na pierwszym slajdzie. Użyj placeholdera z formatowaniem odziedziczonym po jego układzie lub masterze, aby zobaczyć efekt usunięcia tej relacji. Przykład sprawdza, że ten sam kształt pozostaje, wywołuje metodę ponownie na teraz zwykłym kształcie i zapisuje wynik.

{{% alert color="warning" title="Warning" %}}
Usunięcie statusu placeholdera nie zachowuje automatycznie odziedziczonych ustawień wyglądu. Poniższy przykład świadomie pozostawia te ustawienia niezmienione, więc wynik może wyglądać inaczej. Kształt, którego pozycja i rozmiar są całkowicie dziedziczone, może po wywołaniu mieć zerowe współrzędne i wymiary i stać się niewidoczny, mimo że pozostaje w kolekcji.
{{% /alert %}}

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
var found = false;

for (var index = 0; index < slide.Shapes.Count; index++)
{
    if (slide.Shapes[index] is not IAutoShape shape || 
        shape.Placeholder == null || 
        string.IsNullOrEmpty(shape.TextFrame?.Text))
    {
        continue;
    }

    var shapeCount = slide.Shapes.Count;
    shape.RemovePlaceholder();

    Console.WriteLine($"Placeholder removed: {shape.Placeholder == null}");
    Console.WriteLine($"Same shape retained: {ReferenceEquals(slide.Shapes[index], shape)}");
    Console.WriteLine($"Shape count unchanged: {slide.Shapes.Count == shapeCount}");

    // Wywołanie metody na zwykłym kształcie nie ma żadnego efektu.
    shape.RemovePlaceholder();
    found = true;
    break;
}

if (found)
{
    presentation.Save("placeholder-status-removed.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("No nonempty text placeholder was found on the first slide.");
}
```

Dla pasującego placeholdera wszystkie trzy sprawdzenia wypisują `True`. Tekst pozostaje, ale po usunięciu relacji placeholdera mogą się zmienić dziedziczone pozycja, rozmiar, obrót, czcionka, wyrównanie akapitu, marginesy ramki tekstowej, pionowe zakotwiczenie, wypełnienie i ustawienia linii. Na przykład dziedziczone formatowanie tytułu może powrócić do zwykłego formatowania tekstu. Zobacz [Slide Layout](/slides/pl/net/slide-layout/) po więcej informacji o układach.

Aby zachować zamierzony wygląd, przechwyć rozwiązane pozycję, rozmiar i obrót przed wywołaniem i skopiuj wymagane skuteczne wartości formatowania do oddzielnych zmiennych. Pobierz te wartości przez [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/), [IParagraphFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/geteffective/), [ITextFrameFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/geteffective/), [IFillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/geteffective/), oraz [ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/). Nie polegaj wyłącznie na obiektach formatowania efektywnego, ponieważ ich wartości formatowania tekstu mogą zmienić się po usunięciu relacji. Zastosuj wyraźnie przechwycone wartości do zwykłego kształtu po tym, w tym rodzinę czcionki, rozmiar, styl, kolor, ustawienia akapitu, ustawienia ramki tekstowej, wypełnienie i linię używaną w szablonie.

Dziedziczona geometria kształtu może również wymagać explicite przypisania poprzez [IGeometryShape.ShapeType](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/shapetype/). Dla prostokątnego placeholdera tekstowego oznacza to przypisanie [ShapeType.Rectangle](https://reference.aspose.com/slides/net/aspose.slides/shapetype/); przywrócenie tylko wypełnienia i linii może nie przywrócić widzialnego prostokąta. Szablony z dodatkowymi efektami lub bardziej złożonym formatowaniem wymagają również obsługi tych ustawień.

## **Zmiana tekstu w placeholderze**

Placeholdery tytułu, wyśrodkowanego tytułu, podtytułu, ciała i tekstu zazwyczaj obsługują tekst. Sprawdź [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) zanim użyjesz jego właściwości [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/).

Ten przykład aktualizuje pierwszy placeholder tytułu na pierwszym slajdzie i zapisuje wynik:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
IAutoShape? titleShape = null;

foreach (var shape in slide.Shapes)
{
    if (shape is not IAutoShape autoShape || autoShape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = autoShape.Placeholder.Type;
    if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle)
    {
        titleShape = autoShape;
        break;
    }
}

if (titleShape == null)
{
    throw new InvalidOperationException("The first slide does not contain a title placeholder.");
}

titleShape.TextFrame.Text = "Quarterly Business Review";
presentation.Save("title-placeholder-updated.pptx", SaveFormat.Pptx);
```

Ten wzorzec unika rzutowania placeholderów obrazu, wykresu, tabeli lub multimediów na [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/). Ponadto identyfikuje placeholder według przeznaczenia, zamiast polegać na kruchej indeksacji kształtów.

## **Ustawianie tekstu podpowiedzi w układzie**

Tekst podpowiedzi to instrukcja wyświetlana w pustym placeholderze w czasie projektowania, np. *Kliknij, aby dodać tytuł*. Ustaw niestandardowy tekst podpowiedzi na placeholderze układu, zamiast próbować uzyskać go przez kolekcję kształtów normalnego slajdu. Uzyskaj dostęp do układu przez [ISlide.LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/islide/layoutslide/) i iteruj po [ILayoutSlide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/shapes/).

Przykład poniżej zmienia podpowiedzi tytułu i podtytułu w układzie używanym przez pierwszy slajd:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var layoutSlide = presentation.Slides[0].LayoutSlide;

foreach (var shape in layoutSlide.Shapes)
{
    if (shape is not IAutoShape autoShape || autoShape.Placeholder == null)
    {
        continue;
    }

    switch (autoShape.Placeholder.Type)
    {
        case PlaceholderType.Title:
        case PlaceholderType.CenteredTitle:
            autoShape.TextFrame.Text = "Enter a concise slide title";
            break;
        case PlaceholderType.Subtitle:
            autoShape.TextFrame.Text = "Enter a subtitle or reporting period";
            break;
    }
}

presentation.Save("custom-placeholder-prompts.pptx", SaveFormat.Pptx);
```

Tekst podpowiedzi nie jest normalną treścią slajdu. Jest przeznaczony dla pustych placeholderów w aplikacjach edytujących, takich jak PowerPoint. Gdy użytkownik lub program dostarczy prawdziwą treść, podpowiedź przestaje być wyświetlana. Zmiana podpowiedzi nie zastępuje również istniejącego tekstu na slajdach korzystających z tego układu.

## **Aktualizacja placeholdera obrazu**

Istnieją dwa przypadki do obsłużenia:

- Jeśli placeholder obrazu jest już zapełniony i reprezentowany przez [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/), zastąp obraz poprzez [IPictureFillFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picture/) i [ISlidesPicture.Image](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/image/).
- Jeśli jest nadal pustym placeholderem, dodaj ramkę obrazu w współrzędnych placeholdera przy użyciu [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addpictureframe/) i usuń pusty placeholder.

Przykład poniżej obsługuje oba przypadki i zapisuje prezentację:

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("picture-template.pptx");
var slide = presentation.Slides[0];
IShape? picturePlaceholder = null;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder?.Type == PlaceholderType.Picture)
    {
        picturePlaceholder = shape;
        break;
    }
}

if (picturePlaceholder == null)
{
    throw new InvalidOperationException("The first slide does not contain a picture placeholder.");
}

var imageBytes = File.ReadAllBytes("replacement.png");
var image = presentation.Images.AddImage(imageBytes);

if (picturePlaceholder is IPictureFrame pictureFrame)
{
    pictureFrame.PictureFormat.Picture.Image = image;
}
else
{
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, picturePlaceholder.X, picturePlaceholder.Y, picturePlaceholder.Width, picturePlaceholder.Height, image);
    slide.Shapes.Remove(picturePlaceholder);
}

presentation.Save("picture-placeholder-updated.pptx", SaveFormat.Pptx);
```

Zastępstwo utworzone dla pustego placeholdera jest lokalną ramką obrazu, a nie nowym placeholderem, ponieważ [IShape.Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/) jest tylko do odczytu. Zachowuje zarezerwowaną pozycję, ale nie dziedziczy już zachowań specyficznych dla placeholdera. Jeśli utrzymanie relacji placeholdera jest kluczowe, najpierw przygotuj i wypełnij placeholder w PowerPoint, a potem zaktualizuj powstały [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/) przy użyciu Aspose.Slides.

W celu uzyskania przezroczystości obrazu, przycinania i innych efektów specyficznych dla obrazu, zobacz [Manage Picture Frames](/slides/pl/net/picture-frame/). Te operacje dotyczą ramki obrazu lub wypełnienia obrazu, a nie metadanych placeholdera.

## **Praca z placeholderami wykresów i treści**

Zapełniony placeholder wykresu może być reprezentowany przez [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/). Ten przykład znajduje taki wykres zarówno po typie placeholdera, jak i interfejsie w czasie wykonania, zmienia jego tytuł i zapisuje plik:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart-template.pptx");
var slide = presentation.Slides[0];
IChart? placeholderChart = null;

foreach (var shape in slide.Shapes)
{
    if (shape is IChart chart && shape.Placeholder?.Type == PlaceholderType.Chart)
    {
        placeholderChart = chart;
        break;
    }
}

if (placeholderChart == null)
{
    throw new InvalidOperationException("The first slide does not contain a populated chart placeholder.");
}

placeholderChart.HasTitle = true;
placeholderChart.ChartTitle.AddTextFrameForOverriding("Quarterly Revenue");
presentation.Save("chart-placeholder-updated.pptx", SaveFormat.Pptx);
```

Ogólny placeholder treści zazwyczaj ma [PlaceholderType.Object](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/). W PowerPoint działa jako uruchamiacz kilku typów treści, w tym wykresów, tabel, diagramów, obrazów i multimediów. Po jego wypełnieniu sprawdź rzeczywisty interfejs kształtu, aby dowiedzieć się, co zawiera. Specjalistyczne układy mogą również udostępniać [PlaceholderType.Chart](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), lub [PlaceholderType.Diagram](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/).

Aspose.Slides nie konwertuje pustego placeholdera [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) na [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/) jedynie poprzez zmianę [IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/); typ jest tylko do odczytu. Aby programowo wypełnić pusty obszar wykresu lub treści, dodaj wymagany obiekt w współrzędnych placeholdera, a następnie usuń pusty placeholder. Przykład poniżej realizuje to dla wykresu:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("content-template.pptx");
var slide = presentation.Slides[0];
IShape? targetPlaceholder = null;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder?.Type is PlaceholderType.Chart or PlaceholderType.Object)
    {
        targetPlaceholder = shape;
        break;
    }
}

if (targetPlaceholder == null)
{
    throw new InvalidOperationException("The first slide does not contain a chart or content placeholder.");
}

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, targetPlaceholder.X, targetPlaceholder.Y, targetPlaceholder.Width, targetPlaceholder.Height);
chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("Quarterly Revenue");
slide.Shapes.Remove(targetPlaceholder);
presentation.Save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx);
```

Dodany wykres jest zwykłym lokalnym wykresem. Zajmuje obszar placeholdera, ale nie dziedziczy z placeholdera układu. Skorzystaj z dedykowanych [chart management articles](/slides/pl/net/powerpoint-charts/), gdy potrzebujesz zastąpić jego kategorie, serie lub dane skoroszytu.

## **Pełny przykład: aktualizacja treści tekstowej lub obrazowej**

Poniższy przykład end‑to‑end otwiera szablon, przeszukuje pierwszy slajd pod kątem placeholdera tytułu lub obrazu, sprawdza typy placeholdera i kształtu, aktualizuje odpowiednią treść i zapisuje wynik. Przykład celowo unika zakładania indeksu kształtu lub rzutowania każdego placeholdera na ten sam interfejs.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
var updated = false;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = shape.Placeholder.Type;

    if ((placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) && shape is IAutoShape titleShape)
    {
        titleShape.TextFrame.Text = "Quarterly Business Review";
        updated = true;
        break;
    }

    if (placeholderType == PlaceholderType.Picture)
    {
        var imageBytes = File.ReadAllBytes("replacement.png");
        var image = presentation.Images.AddImage(imageBytes);

        if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.PictureFormat.Picture.Image = image;
        }
        else
        {
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, shape.X, shape.Y, shape.Width, shape.Height, image);
            slide.Shapes.Remove(shape);
        }

        updated = true;
        break;
    }
}

if (!updated)
{
    throw new InvalidOperationException("No supported title or picture placeholder was found on the first slide.");
}

presentation.Save("placeholder-content-updated.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Czym jest bazowy placeholder?**

Bazowy placeholder to odpowiadający mu kształt na układzie lub masterze, z którego dziedziczy inny placeholder. Użyj [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/getbaseplaceholder/), aby go pobrać. Zwykły lokalny kształt zwraca `null`, ponieważ nie jest częścią hierarchii placeholderów.

**Czy mogę zmienić wszystkie tytuły slajdów, edytując placeholder układu?**

Możesz zmienić dziedziczone formatowanie lub tekst podpowiedzi poprzez układ, ale istniejąca treść tytułu jest przechowywana na normalnych slajdach. Aby zastąpić rzeczywisty tekst tytułu w całej prezentacji, iteruj po slajdach i zaktualizuj każdy placeholder tytułu.

**Jak zarządzać placeholderami daty, numeru slajdu, nagłówka i stopki?**

Użyj menedżerów nagłówka i stopki w odpowiednim zakresie slajdu, układu, mastera, notatek lub zrzutów. Zobacz [Manage Presentation Header and Footer](/slides/pl/net/presentation-header-and-footer/) po pełne przykłady.