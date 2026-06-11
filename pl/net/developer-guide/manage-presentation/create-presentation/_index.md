---
title: Tworzenie prezentacji w .NET
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
description: "Twórz prezentacje w .NET z użyciem Aspose.Slides — generuj pliki PPT, PPTX i ODP, korzystaj z obsługi OpenDocument i zapisuj je programowo, aby uzyskać niezawodne rezultaty."
---
## **Przegląd**

Ten artykuł pokazuje, jak utworzyć prezentację w Aspose.Slides, dodać prostą treść do slajdu i zapisać wynik jako plik. Demonstruje także, jak utworzyć i zapisać nową prezentację, otworzyć istniejącą prezentację w obsługiwanym formacie i zapisać ją w innym formacie. Dodatkowo artykuł zawiera krótkie FAQ obejmujące typowe pytania dotyczące formatów, szablonów, rozmiaru slajdów, jednostek, zużycia pamięci, wątków, licencjonowania, podpisów cyfrowych oraz wsparcia VBA.

## **Utwórz prezentację PowerPoint**

Aby dodać prostą linię do wybranego slajdu prezentacji, postępuj zgodnie z poniższymi krokami:

1. Utwórz instancję klasy Presentation.
2. Uzyskaj odniesienie do slajdu, korzystając z jego indeksu.
3. Dodaj AutoShape typu Linia, używając metody AddAutoShape udostępnionej przez obiekt Shapes.
4. Zapisz zmodyfikowaną prezentację jako plik PPTX.

W poniższym przykładzie dodaliśmy linię do pierwszego slajdu prezentacji.

```c#
// Utwórz obiekt Presentation, który reprezentuje plik prezentacji
using (Presentation presentation = new Presentation())
{
    // Pobierz pierwszy slajd
    ISlide slide = presentation.Slides[0];

    // Dodaj autoshape typu linia
    slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
    presentation.Save("NewPresentation_out.pptx", SaveFormat.Pptx);
}
```

## **Utwórz i zapisz prezentację**

<a name="csharp-create-save-presentation"><strong>Kroki: Utwórz i zapisz prezentację w C#</strong></a>

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/).
2. Zapisz _Presentation_ w dowolnym formacie obsługiwanym przez [SaveFormat](https://reference.aspose.com/slides/pl/net/aspose.slides.export/saveformat/).

```c#
Presentation presentation = new Presentation();

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```

## **Otwórz i zapisz prezentację**

<a name="csharp-open-save-presentation"><strong>Kroki: Otwórz i zapisz prezentację w C#</strong></a>

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) w dowolnym formacie, np. PPT, PPTX, ODP itp.
2. Zapisz _Presentation_ w dowolnym formacie obsługiwanym przez [SaveFormat](https://reference.aspose.com/slides/pl/net/aspose.slides.export/saveformat/).

```c#
// Załaduj dowolny obsługiwany plik w Presentation, np. ppt, pptx, odp itp.
Presentation presentation = new Presentation("Sample.odp");

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Jakie formaty mogę zapisać nową prezentację?**

Możesz zapisać w formatach [PPTX, PPT i ODP](/slides/pl/net/save-presentation/), a także wyeksportować do [PDF](/slides/pl/net/convert-powerpoint-to-pdf/), [XPS](/slides/pl/net/convert-powerpoint-to-xps/), [HTML](/slides/pl/net/convert-powerpoint-to-html/), [SVG](/slides/pl/net/convert-powerpoint-to-png/) oraz [obrazów](/slides/pl/net/convert-powerpoint-to-png/), między innymi.

**Czy mogę rozpocząć od szablonu (POTX/POTM) i zapisać jako zwykły PPTX?**

Tak. Załaduj szablon i zapisz w żądanym formacie; formaty POTX/POTM/PPTM i podobne [są obsługiwane](/slides/pl/net/supported-file-formats/).

**Jak kontrolować rozmiar slajdu lub proporcje przy tworzeniu prezentacji?**

Ustaw [rozmiar slajdu](/slides/pl/net/slide-size/) (w tym gotowe ustawienia, takie jak 4:3 i 16:9, lub własne wymiary) i wybierz sposób skalowania treści.

**W jakich jednostkach mierzone są rozmiary i współrzędne?**

W punktach: 1 cal to 72 jednostki.

**Jak radzić sobie z bardzo dużymi prezentacjami (z wieloma plikami multimedialnymi), aby zmniejszyć zużycie pamięci?**

Użyj [strategii zarządzania BLOB](/slides/pl/net/manage-blob/), ogranicz pamięć w RAM, korzystając z plików tymczasowych, i preferuj przepływy pracy oparte na plikach zamiast wyłącznie strumieni w pamięci.

**Czy mogę tworzyć/zapisywać prezentacje równolegle?**

Nie możesz operować na tej samej instancji [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) z [wielu wątków](/slides/pl/net/multithreading/). Uruchom osobne, izolowane instancje dla każdego wątku lub procesu.

**Jak usunąć znak wodny wersji próbnej i ograniczenia?**

[Zastosuj licencję](/slides/pl/net/licensing/) raz na proces. Plik XML licencji musi pozostać niezmieniony, a konfiguracja licencji powinna być synchronizowana, jeśli zaangażowane są wielokrotne wątki.

**Czy mogę cyfrowo podpisać utworzony przeze mnie plik PPTX?**

Tak. [Podpisy cyfrowe](/slides/pl/net/digital-signature-in-powerpoint/) (dodawanie i weryfikacja) są obsługiwane w prezentacjach.

**Czy makra (VBA) są obsługiwane w tworzonych prezentacjach?**

Tak. Możesz [tworzyć/edytować projekty VBA](/slides/pl/net/presentation-via-vba/) i zapisywać pliki z włączonymi makrami, takie jak PPTM/PPSM.