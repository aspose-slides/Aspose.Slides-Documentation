---
title: Dostosowywanie legend wykresów w prezentacjach w .NET
linktitle: Legenda wykresu
type: docs
url: /pl/net/chart-legend/
keywords:
- legenda wykresu
- pozycja legendy
- rozmiar czcionki
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dostosuj legendy wykresów za pomocą Aspose.Slides dla .NET, aby zoptymalizować prezentacje PowerPoint dzięki spersonalizowanemu formatowaniu legendy."
---
## **Przegląd**

Aspose.Slides oferuje opcje dostosowywania legend wykresów w prezentacjach PowerPoint. Ten artykuł pokazuje, jak ustawić pozycję i rozmiar legendy, określić rozmiar czcionki dla całej legendy oraz zastosować formatowanie do pojedynczego elementu legendy.

Opisuje również kilka powiązanych zachowań w sekcji FAQ, w tym użycie trybu bez nakładania, aby obszar wykresu zostawił miejsce dla legendy, umożliwienie długim etykietom legendy zawijania lub używania znaków nowej linii oraz pozwolenie, aby formatowanie legendy dziedziczyło po temacie prezentacji, gdy nie są ustawione wyraźne kolory tekstu i wypełnienia.

## **Pozycjonowanie legendy**
Aby ustawić właściwości legendy, postępuj zgodnie z poniższymi krokami:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
- Uzyskaj referencję do slajdu.
- Dodaj wykres na slajdzie.
- Ustaw właściwości legendy.
- Zapisz prezentację jako plik PPTX.

W poniższym przykładzie ustawiliśmy pozycję i rozmiar legendy wykresu.

```c#
// Utwórz instancję klasy Presentation
Presentation presentation = new Presentation();

// Pobierz odwołanie do slajdu
ISlide slide = presentation.Slides[0];

// Dodaj wykres kolumnowy grupowany na slajdzie
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

// Ustaw właściwości legendy
chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

// Zapisz prezentację na dysku
presentation.Save("Legend_out.pptx", SaveFormat.Pptx);
```

## **Ustaw rozmiar czcionki legendy**
Aspose.Slides dla .NET umożliwia programistom ustawienie rozmiaru czcionki legendy. Postępuj zgodnie z poniższymi krokami:

- Utwórz instancję klasy `Presentation`.
- Utwórz domyślny wykres.
- Ustaw rozmiar czcionki.
- Ustaw minimalną wartość osi.
- Ustaw maksymalną wartość osi.
- Zapisz prezentację na dysku.

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 600, 400);

	chart.Legend.TextFormat.PortionFormat.FontHeight = 20;
	chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
	chart.Axes.VerticalAxis.MinValue = -5;
	chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
	chart.Axes.VerticalAxis.MaxValue = 10;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Ustaw rozmiar czcionki pojedynczej legendy**
Aspose.Slides dla .NET umożliwia programistom ustawienie rozmiaru czcionki poszczególnych elementów legendy. Postępuj zgodnie z poniższymi krokami:

- Utwórz instancję klasy `Presentation`.
- Utwórz domyślny wykres.
- Uzyskaj dostęp do elementu legendy.
- Ustaw rozmiar czcionki.
- Ustaw minimalną wartość osi.
- Ustaw maksymalną wartość osi.
- Zapisz prezentację na dysku.

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
	IChartTextFormat tf = chart.Legend.Entries[1].TextFormat;

	tf.PortionFormat.FontBold = NullableBool.True;
	tf.PortionFormat.FontHeight = 20;
	tf.PortionFormat.FontItalic = NullableBool.True;
	tf.PortionFormat.FillFormat.FillType = FillType.Solid; ;
	tf.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Czy mogę włączyć legendę tak, aby wykres automatycznie przydzielał dla niej miejsce zamiast nakładać ją?**

Tak. Użyj trybu bez nakładania ([Overlay](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/legend/overlay/) = `false`); w tym przypadku obszar wykresu zostanie zmniejszony, aby pomieścić legendę.

**Czy mogę tworzyć etykiety legendy wieloliniowe?**

Tak. Długie etykiety są automatycznie zawijane, gdy brakuje miejsca; wymuszone przełamania wierszy są obsługiwane przy użyciu znaków nowej linii w nazwie serii.

**Jak sprawić, aby legenda podążała za schematem kolorów tematu prezentacji?**

Nie ustawiaj explicite kolorów/wypełnień/czcionek dla legendy ani jej tekstu. Następnie będą one dziedziczyć po temacie i zostaną poprawnie zaktualizowane po zmianie projektu.