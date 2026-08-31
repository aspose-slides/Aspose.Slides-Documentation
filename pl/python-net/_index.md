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
{{% alert color="info" %}}

**Witamy w Aspose.Slides for Python via .NET**

![Logo produktu Aspose.Slides for Python via .NET](aspose_slides-for-python.png)

Aspose.Slides for Python via .NET to solidna biblioteka klas, która pozwala aplikacjom odczytywać i zapisywać prezentacje PowerPoint® bez konieczności posiadania Microsoft PowerPoint®.

Jest to pierwszy i jedyny komponent, który zapewnia pełną obsługę dokumentów PowerPoint® dla programistów Pythona.

Aspose.Slides for Python via .NET zawiera szeroki zakres funkcji, takich jak praca z tekstem, kształtami, tabelami i animacjami; dodawanie dźwięku i wideo; podgląd slajdów; oraz eksport slajdów do formatów takich jak SVG, PDF i inne.

{{% /alert %}}

## Instalacja Aspose.Slides for Python via .NET

```bash
pip install aspose.slides
```

Pakiet zawiera potrzebny runtime .NET, więc nie ma nic więcej do zainstalowania, a Microsoft PowerPoint nie jest wymagany. Python 3.7 lub nowszy na systemach Windows, Linux lub macOS.

## Utworzenie prezentacji PowerPoint w Python

Ten przykład tworzy prezentację, dodaje kształt z tekstem do pierwszego slajdu i zapisuje wynik zarówno jako PPTX, jak i PDF.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 600, 100)
    shape.text_frame.text = "Created with Aspose.Slides for Python via .NET"

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF)
```

Po uruchomieniu zostaną zapisane pliki `presentation.pptx` (ok. 34 KB) oraz `presentation.pdf` (ok. 36 KB) w bieżącym katalogu.

Bez licencji biblioteka działa w trybie ewaluacyjnym, który dodaje znak wodny i ogranicza liczbę slajdów. Zobacz [Licensing](/slides/pl/python-net/licensing/) aby dodać licencję.

## Zasoby Aspose.Slides for Python via .NET

Poznaj te przydatne zasoby:

- [Aspose.Slides for Python via .NET Online Documentation](/slides/pl/python-net/)
- [Aspose.Slides for Python via .NET Features](/slides/pl/python-net/features-overview/)
- [Aspose.Slides for Python via .NET Release Notes](https://releases.aspose.com/slides/pl/python-net/release-notes/)
- [Aspose.Slides for Python via .NET Product Page](https://products.aspose.com/slides/pl/python-net/)
- [Download Aspose.Slides for Python via .NET](https://releases.aspose.com/slides/pl/python-net/)
- [Install Aspose.Slides for Python via .NET PyPi Package](https://pypi.org/project/aspose.slides/)
- [Aspose.Slides for Python via .NET API Reference Guide](https://reference.aspose.com/slides/pl/python-net/)
- [Aspose.Slides for Python via .NET Free Support Forum](https://forum.aspose.com/c/slides/pl/11)
- [Aspose.Slides for Python via .NET Paid Support Helpdesk](https://helpdesk.aspose.com/)

## FAQ

### Czym jest Aspose.Slides for Python via .NET?

Aspose.Slides for Python via .NET to potężna biblioteka Pythona, która umożliwia programowe tworzenie, edytowanie i konwertowanie prezentacji PowerPoint (PPT, PPTX, ODP) bez zainstalowanego Microsoft PowerPoint.

### Jakie funkcje prezentacji obsługuje Aspose.Slides?

Biblioteka obsługuje zarządzanie tekstem, kształtami, tabelami, wykresami, animacjami, slajdami master, dźwiękiem, wideo i wieloma innymi elementami. Umożliwia także podgląd slajdów, renderowanie oraz eksport do formatów takich jak PDF, SVG, HTML i obrazy.

### Czy mogę konwertować prezentacje na inne formaty przy użyciu Aspose.Slides?

Tak. Aspose.Slides umożliwia konwersję plików PowerPoint do PDF, SVG, HTML, JPG, PNG, TIFF i innych formatów z wysoką dokładnością i wydajnością.

### Czy Microsoft PowerPoint jest wymagany do używania Aspose.Slides?

Nie. Aspose.Slides jest samodzielnym API i nie wymaga Microsoft Office ani żadnego oprogramowania firm trzecich.

### Jakie platformy są obsługiwane przez Aspose.Slides for Python via .NET?

Jest to rozwiązanie wieloplatformowe, działające w środowiskach Windows, Linux i macOS.

### Jak rozpocząć pracę z Aspose.Slides for Python?

Możesz zainstalować go z PyPi i zapoznać się z [Developer Guide](/slides/pl/python-net/developer-guide/), aby rozpocząć korzystanie z przykładów, referencji API i samouczków.