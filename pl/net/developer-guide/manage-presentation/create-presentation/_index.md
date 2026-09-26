---
title: Utwórz prezentacje w .NET
linktitle: Utwórz prezentację
type: docs
weight: 10
url: /pl/net/create-presentation/
keywords:
- tworzenie prezentacji
- nowa prezentacja
- tworzenie PPT
- nowy PPT
- tworzenie PPTX
- nowy PPTX
- tworzenie ODP
- nowy ODP
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Twórz prezentacje w .NET przy użyciu Aspose.Slides — twórz pliki PPT, PPTX i ODP, korzystaj ze wsparcia OpenDocument i zapisuj je programowo, aby uzyskać niezawodne wyniki."
---
## **Przegląd**

Ten artykuł pokazuje, jak utworzyć prezentację w Aspose.Slides, dodać pole tekstowe do jej pierwszego slajdu i zapisać wynik jako plik. Pokazuje również, jak utworzyć i zapisać pustą prezentację oraz jak otworzyć istniejącą prezentację w obsługiwanym formacie i zapisać ją w innym formacie. Krótkie FAQ na końcu obejmuje typowe pytania dotyczące formatów, szablonów, rozmiaru slajdów, jednostek, zużycia pamięci, wątków, licencjonowania, podpisów cyfrowych i obsługi VBA.

Zanim zacznieš, dodaj Aspose.Slides do swojego projektu z NuGet. Zobacz [Instalacja](/slides/pl/net/installation/) aby uzyskać pakiet do użycia w systemach Windows, Linux i macOS.

## **Utwórz prezentację PowerPoint**

aby utworzyć prezentację i umieścić pole tekstowe na jej pierwszym slajdzie, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/). Nowa prezentacja zawiera już jeden pusty slajd.
2. Pobierz ten slajd z kolekcji [Slides](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/slides/pl/) przy użyciu indeksu 0.
3. Dodaj prostokąt za pomocą metody [AddAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/ishapecollection/addautoshape/) i ustaw jego [text](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/text/).
4. Zapisz prezentację jako plik PPTX za pomocą metody [Save](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/save/).

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);
```

Lewy górny róg prostokąta znajduje się 50 punktów od lewej krawędzi i 50 punktów od górnej krawędzi slajdu, a prostokąt ma szerokość 400 punktów i wysokość 100 punktów. Zapisany plik zawiera jeden slajd z tym prostokątem i jego tekstem. Bez licencji Aspose.Slides dodaje również znak wodny oceny do każdego zapisanego slajdu; zobacz [Licencjonowanie](/slides/pl/net/licensing/).

## **Utwórz i zapisz prezentację**

<a name="csharp-create-save-presentation"></a>

Aby utworzyć pustą prezentację i zapisać ją, utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) i zapisz ją w dowolnym formacie z wyliczenia [SaveFormat](https://reference.aspose.com/slides/pl/net/aspose.slides.export/saveformat/). Wynikiem jest prezentacja z jednym pustym slajdem.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);
```

## **Otwórz i zapisz prezentację**

<a name="csharp-open-save-presentation"></a>

Aby przekonwertować prezentację z jednego formatu na inny, otwórz ją, przekazując jej ścieżkę do konstruktora [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/presentation/), a następnie zapisz w docelowym formacie. Aspose.Slides wykrywa format wejściowy, taki jak PPT, PPTX lub ODP, na podstawie samego pliku.

Poniższy przykład zakłada, że w katalogu roboczym znajduje się prezentacja OpenDocument o nazwie *Sample.odp* i zapisuje ją jako PPTX.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.odp");
presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);
```

## **FAQ**

### Jakie formaty mogę zapisać nową prezentację?

Możesz zapisać jako [PPTX, PPT i ODP](/slides/pl/net/save-presentation/), a także wyeksportować do [PDF](/slides/pl/net/convert-powerpoint-to-pdf/), [XPS](/slides/pl/net/convert-powerpoint-to-xps/), [HTML](/slides/pl/net/convert-powerpoint-to-html/), [SVG](/slides/pl/net/render-a-slide-as-an-svg-image/) i [obrazów](/slides/pl/net/convert-powerpoint-to-png/), między innymi.

### Czy mogę rozpocząć od szablonu (POTX/POTM) i zapisać jako zwykły PPTX?

Tak. Załaduj szablon i zapisz w żądanym formacie; formaty POTX/POTM/PPTM i podobne [są obsługiwane](/slides/pl/net/supported-file-formats/).

### Jak kontrolować rozmiar slajdu/ proporcje przy tworzeniu prezentacji?

Ustaw [rozmiar slajdu](/slides/pl/net/slide-size/) (w tym predefiniowane, takie jak 4:3 i 16:9, lub własne wymiary) i wybierz, jak treść ma być skalowana.

### W jakich jednostkach mierzone są rozmiary i współrzędne?

W punktach: 1 cal to 72 jednostki.

### Jak radzić sobie z bardzo dużymi prezentacjami (z wieloma plikami multimedialnymi), aby zmniejszyć zużycie pamięci?

Użyj [strategii zarządzania BLOB](/slides/pl/net/manage-blob/), ogranicz pamięć wirtualną wykorzystując pliki tymczasowe i preferuj przepływy pracy oparte na plikach zamiast wyłącznie strumieni w pamięci.

### Czy mogę tworzyć/zapisywać prezentacje równolegle?

Nie możesz operować na tej samej instancji [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) z [wielu wątków](/slides/pl/net/multithreading/). Uruchom oddzielne, izolowane instancje na każdy wątek lub proces.

### Jak usunąć znak wodny wersji próbnej i ograniczenia?

[Zastosuj licencję](/slides/pl/net/licensing/) raz na proces. Plik XML licencji musi pozostać niezmieniony, a konfiguracja licencji powinna być synchronizowana, jeśli zaangażowane są wielowątkowe operacje.

### Czy mogę cyfrowo podpisać utworzony przeze mnie plik PPTX?

Tak. [Podpisy cyfrowe](/slides/pl/net/digital-signature-in-powerpoint/) (dodawanie i weryfikacja) są obsługiwane w prezentacjach.

### Czy makra (VBA) są obsługiwane w tworzonych prezentacjach?

Tak. Możesz [tworzyć/edytować projekty VBA](/slides/pl/net/presentation-via-vba/) i zapisywać pliki z włączonymi makrami, takie jak PPTM/PPSM.