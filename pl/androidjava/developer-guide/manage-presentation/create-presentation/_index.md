---
title: Tworzenie prezentacji na Androidzie
linktitle: Utwórz prezentację
type: docs
weight: 10
url: /pl/androidjava/create-presentation/
keywords:
- tworzyć prezentację
- nowa prezentacja
- tworzyć PPT
- nowy PPT
- tworzyć PPTX
- nowy PPTX
- tworzyć ODP
- nowy ODP
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Twórz prezentacje w Javie z Aspose.Slides dla Androida - twórz pliki PPT, PPTX i ODP, korzystaj z obsługi OpenDocument i zapisuj je programowo, aby uzyskać niezawodne rezultaty."
---
## **Przegląd**

Ten artykuł pokazuje, jak utworzyć prezentację w Aspose.Slides, dodać prostą treść do slajdu i zapisać wynik jako plik. Demonstruje również, jak utworzyć i zapisać nową prezentację, otworzyć istniejącą prezentację w obsługiwanym formacie oraz zapisać ją w innym formacie.

## **Utwórz prezentację PowerPoint**
Aby dodać prostą prostą linię do wybranego slajdu prezentacji, postępuj zgodnie z poniższymi krokami:

1. Utwórz instancję klasy Presentation.
1. Uzyskaj odwołanie do slajdu, używając jego indeksu.
1. Dodaj AutoShape typu Line, używając metody addAutoShape udostępnionej przez obiekt Shapes.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

W poniższym przykładzie dodaliśmy linię do pierwszego slajdu prezentacji.

```java
// Utwórz obiekt Presentation, który reprezentuje plik prezentacji
Presentation pres = new Presentation();
try {
    // Pobierz pierwszy slajd
    ISlide slide = pres.getSlides().get_Item(0);

    // Dodaj autoshape typu linia
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    pres.save("NewPresentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Jakie formaty mogę wybrać przy zapisywaniu nowej prezentacji?**

Możesz zapisać do [PPTX, PPT i ODP](/slides/pl/androidjava/save-presentation/), a także wyeksportować do [PDF](/slides/pl/androidjava/convert-powerpoint-to-pdf/), [XPS](/slides/pl/androidjava/convert-powerpoint-to-xps/), [HTML](/slides/pl/androidjava/convert-powerpoint-to-html/), [SVG](/slides/pl/androidjava/convert-powerpoint-to-png/) i [obrazów](/slides/pl/androidjava/convert-powerpoint-to-png/), oraz innych formatów.

**Czy mogę rozpocząć od szablonu (POTX/POTM) i zapisać jako zwykły PPTX?**

Tak. Załaduj szablon i zapisz do żądanego formatu; formaty POTX/POTM/PPTM i podobne [są obsługiwane](/slides/pl/androidjava/supported-file-formats/).

**Jak kontrolować rozmiar slajdu/ proporcje przy tworzeniu prezentacji?**

Ustaw [rozmiar slajdu](/slides/pl/androidjava/slide-size/) (w tym predefiniowane jak 4:3 i 16:9 lub własne wymiary) i wybierz sposób skalowania treści.

**W jakich jednostkach podawane są rozmiary i współrzędne?**

W punktach: 1 cal to 72 jednostki.

**Jak radzić sobie z bardzo dużymi prezentacjami (z wieloma plikami multimedialnymi), aby zmniejszyć zużycie pamięci?**

Używaj [strategii zarządzania BLOB](/slides/pl/androidjava/manage-blob/), ogranicz pamięć podręczną poprzez korzystanie z plików tymczasowych oraz preferuj przepływy pracy oparte na plikach zamiast wyłącznie strumieni w pamięci.

**Czy mogę tworzyć/zapisywać prezentacje równolegle?**

Nie możesz operować na tej samej instancji [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) z [wielu wątków](/slides/pl/androidjava/multithreading/). Uruchamiaj oddzielne, izolowane instancje na każdy wątek lub proces.

**Jak usunąć znak wodny wersji próbnej i ograniczenia?**

[Zastosuj licencję](/slides/pl/androidjava/licensing/) raz na proces. Plik XML licencji musi pozostać niezmieniony, a konfiguracja licencji powinna być synchronizowana, jeśli używane są wiele wątków.

**Czy mogę cyfrowo podpisać utworzony PPTX?**

Tak. [Podpisy cyfrowe](/slides/pl/androidjava/digital-signature-in-powerpoint/) (dodawanie i weryfikacja) są obsługiwane dla prezentacji.

**Czy makra (VBA) są obsługiwane w tworzonych prezentacjach?**

Tak. Możesz [tworzyć/edytować projekty VBA](/slides/pl/androidjava/presentation-via-vba/) i zapisywać pliki z włączonymi makrami, takie jak PPTM/PPSM.