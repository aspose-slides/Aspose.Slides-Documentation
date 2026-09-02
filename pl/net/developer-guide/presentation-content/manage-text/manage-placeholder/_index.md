---
title: Zarządzanie placeholderami prezentacji w .NET
linktitle: Zarządzaj placeholderami
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
description: "Dowiedz się, jak przeglądać i edytować placeholdery tekstu, obrazu, wykresu i treści oraz zrozumieć dziedziczenie placeholderów za pomocą Aspose.Slides dla .NET."
---
## **Przegląd**

Placeholder to kształt, który rezerwuje pozycję dla określonego rodzaju treści w szablonie prezentacji. Typowe przykłady to placeholdery tytułu, treści, obrazu, wykresu oraz ogólnego przeznaczenia. W przeciwieństwie do zwykłego kształtu, placeholder może dziedziczyć swoją pozycję, rozmiar, formatowanie i inne ustawienia z slajdu układu lub slajdu nadrzędnego.

Aspose.Slides udostępnia informacje o placeholderach za pośrednictwem właściwości [IShape.Placeholder](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/placeholder/). Właściwość zwraca obiekt [IPlaceholder](https://reference.aspose.com/slides/pl/net/aspose.slides/iplaceholder/) lub `null` dla zwykłego kształtu. Użyj [IPlaceholder.Type](https://reference.aspose.com/slides/pl/net/aspose.slides/iplaceholder/type/), aby określić, co placeholder ma zawierać.

Interfejs kształtu nadal ma znaczenie po poznaniu typu placeholdera:

- Pusty placeholder tekstowy, obrazu, wykresu lub treści jest zazwyczaj reprezentowany przez [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/).
- Wypełniony placeholder obrazu może być reprezentowany przez [IPictureFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/ipictureframe/).
- Wypełniony placeholder wykresu może być reprezentowany przez [IChart](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichart/).
- Placeholder treści może zawierać kilka rodzajów treści. Sprawdzaj zarówno [IPlaceholder.Type](https://reference.aspose.com/slides/pl/net/aspose.slides/iplaceholder/type/), jak i interfejs kształtu w czasie wykonania, zamiast zakładać, że każdy placeholder jest [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/).

{{% alert color="warning" title="Ostrzeżenie" %}}
[IPlaceholder.Type](https://reference.aspose.com/slides/pl/net/aspose.slides/iplaceholder/type/) opisuje rolę placeholdera; nie gwarantuje typu kształtu w czasie wykonania. Zawsze używaj sprawdzenia typu przed dostępem do członków specyficznych dla tekstu, obrazu, wykresu, tabeli lub mediów.
{{% /alert %}}

## **Zrozumienie dziedziczenia placeholderów**

Placeholdery tworzą hierarchię:

1. Slajd nadrzędny definiuje współdzielone style i, w niektórych przypadkach, placeholdery na poziomie nadrzędnym.
2. Slajd układu definiuje układ używany przez jeden lub więcej zwykłych slajdów i może dziedziczyć z nadrzędnego.
3. Zwykły slajd zawiera placeholdery dla tego slajdu i może dziedziczyć z jego układu.

Wywołaj [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/getbaseplaceholder/), aby przejść o jeden poziom wyżej w tej hierarchii. Placeholder slajdu zwykle zwraca placeholder układu; placeholder układu może zwrócić placeholder nadrzędny. Metoda zwraca `null`, gdy kształt nie ma podstawowego placeholdera.

Poniższy przykład wypisuje placeholdery na pierwszym slajdzie i raportuje ich podstawowe placeholdery:

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

Edycja placeholdera na zwykłym slajdzie tworzy lub zmienia lokalne nadpisanie dla tego slajdu. Edycja powiązanego układu lub nadrzędnego może wpłynąć na wszystkie slajdy, które nadal dziedziczą to ustawienie. Zwykły lokalny kształt nie ma podstawowego placeholdera i nie zaczyna dziedziczyć tylko dlatego, że zajmuje te same współrzędne.

## **Zmiana tekstu w placeholderze**

Placeholdery tytułu, tytułu wyśrodkowanego, podtytułu, treści i tekstu zazwyczaj obsługują tekst. Sprawdź, czy kształt jest [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/), zanim użyjesz jego właściwości [TextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/textframe/).

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

Ten wzorzec unika rzutowania placeholderów obrazu, wykresu, tabeli lub mediów na [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/). Identyfikuje także placeholder według przeznaczenia, zamiast polegać na kruchej kolejności indeksów kształtów.

## **Ustawienie tekstu podpowiedzi na układzie**

Tekst podpowiedzi to instrukcja wyświetlana w pustym placeholderze w czasie projektowania, np. *Kliknij, aby dodać tytuł*. Ustaw własny tekst podpowiedzi na placeholderze układu, zamiast odwoływać się do niego przez kolekcję kształtów zwykłego slajdu. Uzyskaj dostęp do układu poprzez [ISlide.LayoutSlide](https://reference.aspose.com/slides/pl/net/aspose.slides/islide/layoutslide/) i iteruj po [ILayoutSlide.Shapes](https://reference.aspose.com/slides/pl/net/aspose.slides/ibaseslide/shapes/).

Poniższy przykład zmienia podpowiedzi tytułu i podtytułu w układzie używanym przez pierwszy slajd:

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

Tekst podpowiedzi nie jest normalną treścią slajdu. Jest przeznaczony dla pustych placeholderów w aplikacjach edytorskich, takich jak PowerPoint. Po tym, gdy użytkownik lub program dostarczy prawdziwą treść, podpowiedź przestaje być wyświetlana. Zmiana podpowiedzi nie zastępuje istniejącego tekstu na slajdach wykorzystujących ten układ.

## **Aktualizacja placeholdera obrazu**

Istnieją dwa przypadki do obsłużenia:

- Jeśli placeholder obrazu jest już wypełniony i reprezentowany przez [IPictureFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/ipictureframe/), zamień obraz przy użyciu [IPictureFillFormat.Picture](https://reference.aspose.com/slides/pl/net/aspose.slides/ipicturefillformat/picture/) oraz [ISlidesPicture.Image](https://reference.aspose.com/slides/pl/net/aspose.slides/islidespicture/image/).
- Jeśli jest nadal pustym placeholderem, dodaj ramkę obrazu w współrzędnych placeholdera przy pomocy [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/ishapecollection/addpictureframe/) i usuń pusty placeholder.

Kolejny przykład obsługuje oba przypadki i zapisuje prezentację:

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

Zamiana utworzona dla pustego placeholdera jest lokalną ramką obrazu, a nie nowym placeholderem, ponieważ [IShape.Placeholder](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/placeholder/) jest tylko do odczytu. Zachowuje zarezerwowaną pozycję, ale nie dziedziczy już zachowań specyficznych dla placeholdera. Jeśli zachowanie relacji placeholdera jest kluczowe, najpierw przygotuj i wypełnij placeholder w PowerPoint, a potem zaktualizuj powstały [IPictureFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/ipictureframe/) przy użyciu Aspose.Slides.

Informacje o przezroczystości obrazu, przycinaniu i innych efektach specyficznych dla obrazu znajdziesz w artykule [Manage Picture Frames](/slides/pl/net/picture-frame/). Te operacje dotyczą ramki obrazu lub wypełnienia obrazu, a nie metadanych placeholdera.

## **Praca z placeholderami wykresów i treści**

Wypełniony placeholder wykresu może być reprezentowany przez [IChart](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichart/). Przykład poniżej znajduje taki wykres zarówno po typie placeholdera, jak i interfejsie w czasie wykonania, zmienia jego tytuł i zapisuje plik:

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

Ogólny placeholder treści zazwyczaj ma [PlaceholderType.Object](https://reference.aspose.com/slides/pl/net/aspose.slides/placeholdertype/). W PowerPoint działa jako uruchamiacz dla kilku typów treści, w tym wykresów, tabel, diagramów, obrazów i mediów. Po jego wypełnieniu sprawdź faktyczny interfejs kształtu, aby dowiedzieć się, co zawiera. Specjalistyczne układy mogą również udostępniać [PlaceholderType.Chart](https://reference.aspose.com/slides/pl/net/aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/pl/net/aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/pl/net/aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/pl/net/aspose.slides/placeholdertype/), lub [PlaceholderType.Diagram](https://reference.aspose.com/slides/pl/net/aspose.slides/placeholdertype/).

Aspose.Slides nie konwertuje pustego placeholdera [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/) w [IChart](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichart/) jedynie przez zmianę [IPlaceholder.Type](https://reference.aspose.com/slides/pl/net/aspose.slides/iplaceholder/type/); typ jest tylko do odczytu. Aby programowo wypełnić pusty obszar wykresu lub treści, dodaj wymagany obiekt w współrzędnych placeholdera, a następnie usuń pusty placeholder. Poniższy przykład robi to dla wykresu:

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

Dodany wykres jest zwykłym lokalnym wykresem. Zajmuje obszar placeholdera, ale nie dziedziczy z placeholdera układu. Skorzystaj z dedykowanych artykułów o zarządzaniu wykresami [chart management articles](/slides/pl/net/powerpoint-charts/), gdy potrzebujesz zamienić kategorie, serie lub dane skoroszytu.

## **Pełny przykład: Aktualizacja tekstu lub obrazu**

Poniższy, kompletny przykład otwiera szablon, przeszukuje pierwszy slajd pod kątem placeholdera tytułu lub obrazu, sprawdza typy placeholdera i kształtu, aktualizuje odpowiednią treść i zapisuje wynik. Przykład celowo unika zakładania indeksu kształtu lub rzutowania każdego placeholdera na ten sam interfejs.

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

**Co to jest podstawowy placeholder?**

Podstawowy placeholder to odpowiadający mu kształt na układzie lub nadrzędnym, z którego inny placeholder dziedziczy. Użyj [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/getbaseplaceholder/), aby go pobrać. Zwykły lokalny kształt zwraca `null`, ponieważ nie jest częścią hierarchii placeholderów.

**Czy mogę zmienić wszystkie tytuły slajdów, edytując placeholder układu?**

Możesz zmienić dziedziczone formatowanie lub tekst podpowiedzi poprzez układ, ale istniejąca treść tytułów jest przechowywana na normalnych slajdach. Aby zastąpić faktyczny tekst tytułu w całej prezentacji, iteruj po slajdach i zaktualizuj każdy placeholder tytułu.

**Jak zarządzać placeholderami daty, numeru slajdu, nagłówka i stopki?**

Użyj menedżerów nagłówka i stopki w odpowiednim zakresie: slajdu, układu, nadrzędnego, notatek lub wersji rozdania. Zobacz [Manage Presentation Header and Footer](/slides/pl/net/presentation-header-and-footer/) po pełne przykłady.