---
title: Tworzenie prezentacji w Pythonie
linktitle: Utwórz prezentację
type: docs
weight: 10
url: /pl/python-net/create-presentation/
keywords:
- tworzenie prezentacji
- nowa prezentacja
- utwórz PPT
- nowy PPT
- utwórz PPTX
- nowy PPTX
- utwórz ODP
- nowy ODP
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Twórz prezentacje PowerPoint w języku Python przy użyciu Aspose.Slides — twórz pliki PPT, PPTX i ODP, korzystaj z obsługi OpenDocument i zapisuj je programowo, aby uzyskać niezawodne wyniki."
---
## **Przegląd**

Ten artykuł pokazuje, jak utworzyć prezentację przy użyciu Aspose.Slides dla Pythona poprzez .NET, dodać kształt z tekstem do jej pierwszego slajdu oraz zapisać wynik jako plik PPTX. To samo API umożliwia zapisywanie prezentacji jako PPT i ODP, więc można obsługiwać zarówno formaty PowerPoint, jak i OpenDocument z jednej bazy kodu, bez Microsoft Office. Krótkie FAQ na końcu obejmuje typowe pytania dotyczące formatów, szablonów, rozmiaru slajdów, jednostek, zużycia pamięci, wątkowości, licencjonowania, podpisów cyfrowych i obsługi VBA.

Przed rozpoczęciem zainstaluj pakiet z PyPI za pomocą `pip install aspose.slides`. Zobacz [Instalacja](/slides/pl/python-net/installation/) aby dowiedzieć się, jakie biblioteki są również potrzebne w systemach Linux i macOS oraz o wirtualnym środowisku wymaganym przez systemowy Python w Debianie i Ubuntu.

## **Utwórz prezentację**

Aby utworzyć prezentację i umieścić kształt z tekstem na jej pierwszym slajdzie, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/). Nowa prezentacja już zawiera jeden pusty slajd.
2. Pobierz ten slajd z kolekcji [slides](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/slides/pl/) według indeksu 0.
3. Dodaj chmurowy [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/) przy użyciu metody [add_auto_shape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shapecollection/add_auto_shape/) kolekcji [shapes](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slide/shapes/) slajdu i ustaw jego [text](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/text/).
4. Zapisz prezentację jako plik PPTX przy użyciu metody [save](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/save/).

```py
import aspose.slides as slides

# Utwórz instancję klasy Presentation reprezentującej plik prezentacji.
with slides.Presentation() as presentation:
    # Pobierz pierwszy slajd.
    slide = presentation.slides[0]

    # Dodaj auto-kształt typu CLOUD.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # Zapisz prezentację jako plik PPTX.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

Lewy górny róg chmury znajduje się 20 punktów od lewej krawędzi i 20 punktów od górnej krawędzi slajdu, a chmura ma 200 punktów szerokości i 80 punktów wysokości. Instrukcja `with` zwalnia zasoby prezentacji po zakończeniu bloku. Skrypt zapisuje *new_presentation.pptx* w bieżącym folderze, z jednym slajdem zawierającym chmurę i jej tekst. Bez licencji Aspose.Slides również dodaje znak wodny oceny do każdego zapisanego slajdu; zobacz [Licencjonowanie](/slides/pl/python-net/licensing/).

Wynik:

![Nowa prezentacja](new_presentation.png)

## **FAQ**

### Jakie formaty mogę zapisać nową prezentację?

Możesz zapisać w formatach [PPTX, PPT i ODP](/slides/pl/python-net/save-presentation/), a także eksportować do [PDF](/slides/pl/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/pl/python-net/convert-powerpoint-to-xps/), [HTML](/slides/pl/python-net/convert-powerpoint-to-html/), [SVG](/slides/pl/python-net/render-a-slide-as-an-svg-image/) oraz [obrazów](/slides/pl/python-net/convert-powerpoint-to-png/), i innych.

### Czy mogę rozpocząć od szablonu (POTX/POTM) i zapisać jako zwykły PPTX?

Tak. Załaduj szablon i zapisz w żądanym formacie; formaty POTX/POTM/PPTM i podobne [są obsługiwane](/slides/pl/python-net/supported-file-formats/).

### Jak kontrolować rozmiar/slup proporcje slajdu przy tworzeniu prezentacji?

Ustaw [slide size](/slides/pl/python-net/slide-size/) (w tym predefiniowane 4:3 i 16:9 lub własne wymiary) i wybierz, jak treść ma być skalowana.

### W jakich jednostkach mierzone są rozmiary i współrzędne?

W punktach: 1 cal = 72 jednostki.

### Jak radzić sobie z bardzo dużymi prezentacjami (z wieloma plikami multimedialnymi), aby zmniejszyć zużycie pamięci?

Użyj [strategii zarządzania BLOB](/slides/pl/python-net/manage-blob/), ogranicz przechowywanie w pamięci, wykorzystując pliki tymczasowe, i preferuj przepływy pracy oparte na plikach zamiast wyłącznie pamięciowych strumieni.

### Czy mogę tworzyć/zapisywać prezentacje równocześnie?

Nie możesz operować na tej samej instancji [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) z [wielu wątków](/slides/pl/python-net/multithreading/). Uruchom oddzielne, izolowane instancje na każdy wątek lub proces.

### Jak usunąć znak wodny wersji próbnej i ograniczenia?

[Zastosuj licencję](/slides/pl/python-net/licensing/) raz na proces. Plik XML licencji musi pozostać niezmieniony, a konfiguracja licencji powinna być zsynchronizowana, jeśli używane są wiele wątków.

### Czy mogę cyfrowo podpisać tworzony przeze mnie PPTX?

Tak. [Podpisy cyfrowe](/slides/pl/python-net/digital-signature-in-powerpoint/) (dodawanie i weryfikacja) są obsługiwane w prezentacjach.

### Czy makra (VBA) są obsługiwane w tworzonych prezentacjach?

Tak. Możesz [tworzyć/edytować projekty VBA](/slides/pl/python-net/presentation-via-vba/) i zapisywać pliki z włączonymi makrami, takie jak PPTM/PPSM.