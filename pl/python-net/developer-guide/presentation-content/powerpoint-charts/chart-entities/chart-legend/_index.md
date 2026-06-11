---
title: Dostosuj legendy wykresów w prezentacjach przy użyciu Pythona
linktitle: Legenda wykresu
type: docs
url: /pl/python-net/chart-legend/
keywords:
- legenda wykresu
- pozycja legendy
- rozmiar czcionki
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Dostosuj legendy wykresów za pomocą Aspose.Slides for Python via .NET, aby zoptymalizować prezentacje PowerPoint i OpenDocument dzięki spersonalizowanemu formatowaniu legend."
---
## **Przegląd**

Aspose.Slides for Python zapewnia pełną kontrolę nad legendami wykresów, dzięki czemu możesz uczynić etykiety danych czytelne i gotowe do prezentacji. Możesz pokazać lub ukryć legendę, wybrać jej pozycję na slajdzie oraz dostosować układ, aby zapobiec nakładaniu się na obszar rysunku. API umożliwia stylizowanie tekstu i znaczników, precyzyjne dostosowanie odstępów i tła oraz formatowanie krawędzi i wypełnień, aby pasowały do Twojego motywu. Programiści mogą także uzyskać dostęp do poszczególnych pozycji legendy, aby zmienić ich nazwę lub przefiltrować je, zapewniając wyświetlanie tylko najważniejszych serii. Dzięki tym możliwościom wykresy pozostają czytelne, spójne i zgodne ze standardami projektu prezentacji.

## **Pozycjonowanie legendy**

Korzystając z Aspose.Slides, możesz szybko kontrolować, gdzie pojawia się legenda wykresu i jak pasuje do układu slajdu. Dowiedz się, jak precyzyjnie umieścić legendę.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
2. Uzyskaj odniesienie do slajdu.
3. Dodaj wykres do slajdu.
4. Ustaw właściwości legendy.
5. Zapisz prezentację jako plik PPTX.

W poniższym przykładzie ustawiamy pozycję i rozmiar legendy wykresu:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Utwórz instancję klasy Presentation.
with slides.Presentation() as presentation:

    # Uzyskaj odniesienie do slajdu.
    slide = presentation.slides[0]

    # Dodaj wykres kolumnowy grupowany do slajdu.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 300)

    # Ustaw właściwości legendy.
    chart.legend.x = 80 / chart.width
    chart.legend.y = 20 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    # Zapisz prezentację na dysku.
    presentation.save("legend_positioning.pptx", slides.export.SaveFormat.PPTX)
```

## **Ustaw rozmiar czcionki legendy**

Legenda wykresu powinna być tak czytelna, jak dane, które wyjaśnia. Ta sekcja pokazuje, jak dostosować rozmiar czcionki legendy, aby dopasować go do typografii prezentacji i zwiększyć dostępność.

1. Zainicjuj klasę [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
2. Utwórz wykres.
3. Ustaw rozmiar czcionki.
4. Zapisz prezentację na dysku.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.legend.text_format.portion_format.font_height = 20

    presentation.save("font_size.pptx", slides.export.SaveFormat.PPTX)
```

## **Ustaw rozmiar czcionki dla pozycji legendy**

Aspose.Slides umożliwia precyzyjne dostosowanie wyglądu legend wykresów poprzez formatowanie poszczególnych pozycji. Poniższy przykład pokazuje, jak wybrać konkretną pozycję legendy i ustawić jej właściwości, nie zmieniając reszty legendy.

1. Zainicjuj klasę [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
2. Utwórz wykres.
3. Uzyskaj dostęp do pozycji legendy.
4. Ustaw właściwości pozycji.
5. Zapisz prezentację na dysku.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    text_format = chart.legend.entries[1].text_format

    text_format.portion_format.font_bold = slides.NullableBool.TRUE
    text_format.portion_format.font_height = 20
    text_format.portion_format.font_italic = slides.NullableBool.TRUE
    text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("legend_entry.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Czy mogę włączyć legendę, aby wykres automatycznie przydzielał dla niej miejsce zamiast nakładać ją?**

Tak. Użyj trybu bez nakładania ([overlay](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/legend/overlay/) = `false`); w tym przypadku obszar rysunku zostanie zmniejszony, aby pomieścić legendę.

**Czy mogę tworzyć wieloliniowe etykiety legendy?**

Tak. Długie etykiety zawijają się automatycznie, gdy brakuje miejsca; wymuszone podziały linii są obsługiwane poprzez znaki nowej linii w nazwie serii.

**Jak sprawić, aby legenda dostosowywała się do schematu kolorów motywu prezentacji?**

Nie ustawiaj explicite kolorów/wypełnień/czcionek dla legendy ani jej tekstu. Wówczas zostaną one odziedziczone z motywu i będą się prawidłowo aktualizować przy zmianie projektu.