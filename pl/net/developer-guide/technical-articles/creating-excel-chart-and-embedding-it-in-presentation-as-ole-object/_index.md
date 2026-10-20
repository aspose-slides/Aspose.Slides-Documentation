---
title: Tworzenie wykresów Excel i osadzanie ich w prezentacjach jako obiekty OLE
type: docs
weight: 50
url: /pl/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Wykres Excel
- osadzanie wykresu
- obiekt OLE
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Utwórz wykres Excel przy użyciu Aspose.Cells dla .NET i osadź skoroszyt w prezentacji PowerPoint przy użyciu Aspose.Slides, włącznie z podglądem wykresu."
---
## **Przegląd**

Ten artykuł pokazuje, jak utworzyć wykres słupkowy Excel przy użyciu Aspose.Cells dla .NET i osadzić jego skoroszyt w prezentacji PowerPoint przy użyciu Aspose.Slides dla .NET. Osadzony skoroszyt zawiera zarówno dane źródłowe, jak i wykres. Oddzielny podgląd PNG wyświetla wykres na slajdzie przed aktywacją obiektu OLE.

Wynikiem jest osadzony obiekt Excel, a nie natywny wykres PowerPoint. Edycja skoroszytu przez OLE wymaga aplikacji desktopowej obsługującej aktywację OLE oraz kompatybilnej instalacji Excela.

## **Wymagania wstępne**

Dodaj odwołania do Aspose.Cells dla .NET oraz Aspose.Slides dla .NET w swoim projekcie C#. Przykład używa instrukcji poziomu najwyższego i wymaga C# 9 lub nowszego. Microsoft Office nie jest wymagany do generowania prezentacji przy użyciu tych bibliotek.

Żadne pliki wejściowe nie są wymagane: przykład tworzy dane i wykres w pamięci, a następnie zapisuje `OutputChart.pptx` w bieżącym katalogu roboczym. Zastosuj licencje dla obu produktów przy uruchamianiu poza trybem ewaluacji.

## **Jak działa osadzanie**

1. Utwórz skoroszyt z arkuszem danych i arkuszem wykresu.
2. Ustaw arkusz wykresu jako aktywny, aby skoroszyt otwierał się na wykresie.
3. Ustaw zakres wyświetlania OLE skoroszytu i wyrenderuj wykres do PNG.
4. Zapisz skoroszyt jako XLSX w pamięci i osadź te bajty na slajdzie.
5. Przypisz PNG jako podgląd obiektu OLE i zapisz prezentację jako PPTX.

Zakres wyświetlania skoroszytu i ramka na slajdzie pełnią różne role. [SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) przyjmuje indeksy wiersza i kolumny rozpoczynające się od zera. Natomiast [ChartCollection.Add](https://reference.aspose.com/cells/net/aspose.cells.charts/chartcollection/add/) przyjmuje górny wiersz, lewą kolumnę, dolny wiersz i prawą kolumnę. Przykład używa indeksu wiersza 55 i indeksu kolumny 25 jako granic prawdolnych; wartości te są wyborami układu, a nie liczbą wierszy lub kolumn danych.

Ramka slajdu używa punktów. Przykład dopasowuje ją do slajdu i centruje, zachowując proporcje PNG, zamiast rozciągać podgląd, aby wypełnić slajd.

## **Utwórz i osadź wykres**

Poniższy kompletny przykład wypełnia `DataSheet` czterema wierszami i pięcioma kolumnami wartości. Każdy wiersz staje się serią wykresu. `ChartSheet` jest wybrany jako aktywny arkusz przed zapisaniem skoroszytu.

Skoroszyt jest wyraźnie zapisywany jako XLSX, pasując do rozszerzenia `xlsx` przekazanego do [OleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides.dom.ole/oleembeddeddatainfo/). PNG jest ładowany bezpośrednio ze swojego strumienia bez pośredniej konwersji bitmapy. Przypisanie go za pomocą [SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/substitutepictureformat/) zastępuje domyślny placeholder OLE.

```cs
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;

using var workbook = new Aspose.Cells.Workbook();
var dataSheet = workbook.Worksheets[0];
dataSheet.Name = "DataSheet";

int[,] values =
{
    { 67, 44, 46, 43, 24 },
    { 86, 64, 97, 29, 40 },
    { 68, 89, 78, 69, 38 },
    { 91, 48, 60, 26, 25 }
};

for (var row = 0; row < values.GetLength(0); row++)
{
    for (var column = 0; column < values.GetLength(1); column++)
    {
        dataSheet.Cells[row, column].PutValue(values[row, column]);
    }
}

var chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
var chartSheet = workbook.Worksheets[chartSheetIndex];
chartSheet.Name = "ChartSheet";

var lastChartRow = 55;
var lastChartColumn = 25;
var chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, 0, lastChartRow, lastChartColumn);
var chart = chartSheet.Charts[chartIndex];
for (var row = 1; row <= values.GetLength(0); row++)
{
    chart.NSeries.Add($"DataSheet!A{row}:E{row}", false);
}

workbook.Worksheets.ActiveSheetIndex = chartSheetIndex;
workbook.Worksheets.SetOleSize(0, lastChartRow, 0, lastChartColumn);

// Renderuj podgląd wykresu oraz osobno zserializuj edytowalny skoroszyt.
using var chartImageStream = new MemoryStream();
chart.ToImage(chartImageStream, Aspose.Cells.Drawing.ImageType.Png);
chartImageStream.Position = 0;
using var chartImage = Images.FromStream(chartImageStream);

using var workbookStream = new MemoryStream();
workbook.Save(workbookStream, Aspose.Cells.SaveFormat.Xlsx);
var workbookBytes = workbookStream.ToArray();

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var slideSize = presentation.SlideSize.Size;

// Fit the preview within the slide without changing its aspect ratio.
var scale = Math.Min(slideSize.Width / chartImage.Width, slideSize.Height / chartImage.Height);
var frameWidth = chartImage.Width * scale;
var frameHeight = chartImage.Height * scale;
var frameX = (slideSize.Width - frameWidth) / 2;
var frameY = (slideSize.Height - frameHeight) / 2;

var embeddedData = new OleEmbeddedDataInfo(workbookBytes, "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
var previewImage = presentation.Images.AddImage(chartImage);
oleFrame.SubstitutePictureFormat.Picture.Image = previewImage;

presentation.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Oczekiwany rezultat**

`OutputChart.pptx` zawiera jeden slajd z osadzonym skoroszytem Excel i podglądem wykresu. Skoroszyt zawiera oryginalne dane oraz wykres słupkowy z czterema seriami. Podgląd jest wyśrodkowany na slajdzie i zachowuje swoje proporcje.

![Wykres słupkowy Excel wyświetlany jako podgląd osadzonego skoroszytu](excel-chart-ole-preview.png)

W zgodnym środowisku PowerPoint na komputerze z dostępnym Excelem, dwukrotnie kliknij obiekt, aby aktywować i edytować osadzony skoroszyt. Aktywacja i edycja zależą od obsługi OLE przez aplikację hosta oraz od ustawień zabezpieczeń.

## **FAQ**

**Dlaczego potrzebny jest obraz podglądu?**

Osadzony skoroszyt i jego podgląd na slajdzie to odrębne treści. Dostarcz obraz wykresu, aby slajd wyświetlał wykres zamiast domyślnego placeholdera „EMBEDDED OLE OBJECT”. Zobacz [Problem z podglądem obiektu przy dodawaniu OleObjectFrame](/slides/pl/net/object-preview-issue-when-adding-oleobjectframe/).

**Czy podgląd aktualizuje się automatycznie po zmianie skoroszytu w kodzie?**

Traktuj podgląd jako migawkę. Po programowym zaktualizowaniu danych skoroszytu, wygeneruj ponownie obraz wykresu i zastąp podgląd oraz dane osadzonego skoroszytu.

**Czy mogę używać XLS zamiast XLSX?**

Tak. Zapisz skoroszyt w formacie XLS i użyj `xls` jako rozszerzenia danych osadzonych. Rozszerzenie musi odpowiadać rzeczywistemu formatowi skoroszytu; samo zmienienie rozszerzenia nie konwertuje danych.

**Dlaczego obiekt może zmienić rozmiar po aktywacji?**

Aplikacja hosta może zaktualizować prezentację obiektu OLE po aktywacji skoroszytu. Zarówno zakres wyświetlania OLE skoroszytu, jak i wymiary ramki slajdu mają znaczenie. Zobacz [Rozwiązanie działające dla zmiany rozmiaru wykresu w PPTX](/slides/pl/net/working-solution-for-chart-resizing-in-pptx/).

## **Powiązane sekcje**

- [Rozwiązanie działające dla zmiany rozmiaru wykresu w PPTX](/slides/pl/net/working-solution-for-chart-resizing-in-pptx/)
- [Problem z podglądem obiektu przy dodawaniu OleObjectFrame](/slides/pl/net/object-preview-issue-when-adding-oleobjectframe/)
- [Automatyczna aktualizacja obiektów OLE przy użyciu dodatku PowerPoint](/slides/pl/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)