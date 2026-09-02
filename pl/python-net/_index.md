---
title: Aspose.Slides dla Pythona via .NET
second_title: Aspose.Slides dla Pythona
type: docs
weight: 35
url: /pl/python-net/
is_root: true
keywords:
- Aspose.Slides dla Pythona
- Automatyzacja PowerPoint w Pythonie
- Biblioteka PPT w Pythonie
- Eksport PowerPoint do PDF w Pythonie
- Eksport PowerPoint do SVG w Pythonie
- Edycja PowerPoint w Pythonie
- PowerPoint w Pythonie bez Microsoft Office
- Zarządzanie PPTX w Pythonie
- Podgląd slajdów w Pythonie
- Dodawanie dźwięku do slajdów w Pythonie
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET oferuje kompleksowy zestaw funkcji, w tym zarządzanie tekstem, kształtami, tabelami i animacjami, dodawanie dźwięku i wideo do slajdów, podgląd slajdów oraz eksport do SVG, PDF i innych formatów."
---
{{% alert color="primary" %}}

**Witamy w Aspose.Slides for Python via .NET**

![Logo produktu Aspose.Slides for Python via .NET](aspose_slides-for-python.png)

Aspose.Slides for Python via .NET to solidna biblioteka klas, która pozwala Twoim aplikacjom odczytywać i zapisywać prezentacje PowerPoint® bez konieczności posiadania Microsoft PowerPoint®.

Jest to pierwszy i jedyny komponent, który zapewnia pełną obsługę zarządzania dokumentami PowerPoint® dla programistów Pythona.

Aspose.Slides for Python via .NET zawiera szeroki zakres funkcji, takich jak praca z tekstem, kształtami, tabelami i animacjami; dodawanie dźwięku i wideo; podgląd slajdów; oraz eksport slajdów do formatów takich jak SVG, PDF i inne.

{{% /alert %}}

## Zainstaluj Aspose.Slides for Python via .NET

```bash
pip install aspose.slides
```

Pakiet zawiera niezbędny runtime .NET, więc nie ma nic dodatkowego do zainstalowania, a Microsoft PowerPoint nie jest wymagany. Python 3.7 lub nowszy na systemach Windows, Linux lub macOS.

## Utwórz prezentację PowerPoint w Pythonie

Ten przykład tworzy prezentację, dodaje kształt z tekstem do pierwszego slajdu i zapisuje wynik jako plik PPTX oraz PDF.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 600, 100)
    shape.text_frame.text = "Created with Aspose.Slides for Python via .NET"

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF)
```

Po uruchomieniu zapisuje `presentation.pptx` (ok. 34 KB) i `presentation.pdf` (ok. 36 KB) w bieżącym katalogu.

Bez licencji biblioteka działa w trybie ewaluacyjnym, który dodaje znak wodny i ogranicza liczbę slajdów. Zobacz [Licencjonowanie](/slides/pl/python-net/licensing/), aby ją zastosować.

## Zasoby Aspose.Slides for Python via .NET

Zapoznaj się z następującymi przydatnymi zasobami:

- [Dokumentacja online Aspose.Slides for Python via .NET](/slides/pl/python-net/)
- [Funkcje Aspose.Slides for Python via .NET](/slides/pl/python-net/features-overview/)
- [Informacje o wydaniu Aspose.Slides for Python via .NET](https://releases.aspose.com/slides/pl/python-net/release-notes/)
- [Strona produktu Aspose.Slides for Python via .NET](https://products.aspose.com/slides/pl/python-net/)
- [Pobierz Aspose.Slides for Python via .NET](https://releases.aspose.com/slides/pl/python-net/)
- [Zainstaluj pakiet PyPi Aspose.Slides for Python via .NET](https://pypi.org/project/aspose.slides/)
- [Przewodnik po odniesieniach API Aspose.Slides for Python via .NET](https://reference.aspose.com/slides/pl/python-net/)
- [Forum darmowego wsparcia Aspose.Slides for Python via .NET](https://forum.aspose.com/c/slides/pl/11)
- [Płatny helpdesk wsparcia Aspose.Slides for Python via .NET](https://helpdesk.aspose.com/)

## FAQ

### Czym jest Aspose.Slides for Python via .NET?

Aspose.Slides for Python via .NET to potężna biblioteka Pythona, która pozwala programowo tworzyć, edytować i konwertować prezentacje PowerPoint (PPT, PPTX, ODP) bez zainstalowanego Microsoft PowerPoint.

### Jakie funkcje prezentacji obsługuje Aspose.Slides?

Biblioteka obsługuje zarządzanie tekstem, kształtami, tabelami, wykresami, animacjami, slajdami nadrzędnymi, dźwiękiem, wideo i wiele więcej. Umożliwia także podgląd slajdów, renderowanie, drukowanie oraz eksport do formatów takich jak PDF, SVG, HTML i obrazy.

### Czy mogę konwertować prezentacje na inne formaty przy użyciu Aspose.Slides?

Tak. Aspose.Slides umożliwia konwersję plików PowerPoint do formatu PDF, SVG, HTML, JPG, PNG, TIFF i innych, zachowując wysoką wierność i wydajność.

### Czy Microsoft PowerPoint jest wymagany do używania Aspose.Slides?

Nie. Aspose.Slides jest samodzielnym API i nie wymaga Microsoft Office ani żadnego oprogramowania firm trzecich.

### Na jakich platformach działa Aspose.Slides for Python via .NET?

Jest to rozwiązanie wieloplatformowe i działa w środowiskach Windows, Linux oraz macOS.

### Jak rozpocząć pracę z Aspose.Slides for Python?

Możesz zainstalować go za pomocą PyPi i zapoznać się z [Przewodnikiem dewelopera](/slides/pl/python-net/developer-guide/), aby rozpocząć z przykładami, odniesieniami API i samouczkami.