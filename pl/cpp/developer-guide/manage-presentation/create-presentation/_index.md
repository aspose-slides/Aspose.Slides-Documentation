---
title: Tworzenie prezentacji w C++
linktitle: Utwórz prezentację
type: docs
weight: 10
url: /pl/cpp/create-presentation/
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
- C++
- Aspose.Slides
description: "Twórz prezentacje w C++ przy użyciu Aspose.Slides - twórz pliki PPT, PPTX i ODP, korzystaj z obsługi OpenDocument i zapisuj je programowo dla niezawodnych rezultatów."
---
## **Przegląd**

Ten artykuł pokazuje, jak utworzyć prezentację w Aspose.Slides, dodać prostą treść do slajdu i zapisać wynik jako plik.

## **Utworzenie prezentacji PowerPoint**

Aby dodać prostą linię do wybranego slajdu prezentacji, postępuj zgodnie z poniższymi krokami:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation).
2. Uzyskaj referencję do slajdu, używając jego indeksu.
3. Dodaj AutoShape typu Linia, używając metody AddAutoShape udostępnionej przez obiekt Shapes.
4. Zapisz zmodyfikowaną prezentację jako plik PPTX.

W poniższym przykładzie dodaliśmy linię do pierwszego slajdu prezentacji.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateNewPresentation-CreateNewPresentation.cpp" >}}

## **FAQ**

**Jakie formaty mogę zapisać nową prezentację?**

Możesz zapisać do [PPTX, PPT i ODP](/slides/pl/cpp/save-presentation/), a także wyeksportować do [PDF](/slides/pl/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/pl/cpp/convert-powerpoint-to-xps/), [HTML](/slides/pl/cpp/convert-powerpoint-to-html/), [SVG](/slides/pl/cpp/convert-powerpoint-to-png/) i [obrazów](/slides/pl/cpp/convert-powerpoint-to-png/), między innymi.

**Czy mogę rozpocząć od szablonu (POTX/POTM) i zapisać jako zwykły PPTX?**

Tak. Załaduj szablon i zapisz w żądanym formacie; formaty POTX/POTM/PPTM i podobne [są obsługiwane](/slides/pl/cpp/supported-file-formats/).

**Jak kontrolować rozmiar slajdu i proporcje obrazu podczas tworzenia prezentacji?**

Ustaw [rozmiar slajdu](/slides/pl/cpp/slide-size/) (w tym predefiniowane proporcje, takie jak 4:3 i 16:9, lub własne wymiary) i wybierz sposób skalowania treści.

**W jakich jednostkach mierzone są rozmiary i współrzędne?**

W punktach: 1 cal równa się 72 jednostkom.

**Jak radzić sobie z bardzo dużymi prezentacjami (z wieloma plikami multimedialnymi), aby zmniejszyć zużycie pamięci?**

Użyj [strategii zarządzania BLOB](/slides/pl/cpp/manage-blob/), ogranicz przechowywanie w pamięci poprzez wykorzystanie plików tymczasowych i preferuj przepływy pracy oparte na plikach zamiast wyłącznie strumieni w pamięci.

**Czy mogę tworzyć/zapisywać prezentacje równolegle?**

Nie możesz operować na tej samej instancji [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) z [wielu wątków](/slides/pl/cpp/multithreading/). Uruchamiaj oddzielne, izolowane instancje dla każdego wątku lub procesu.

**Jak usunąć znak wodny wersji próbnej i ograniczenia?**

[Zastosuj licencję](/slides/pl/cpp/licensing/) raz na proces. Plik XML licencji musi pozostać niezmodyfikowany, a konfiguracja licencji powinna być synchronizowana, jeśli zaangażowane są wiele wątków.

**Czy mogę cyfrowo podpisać utworzony przeze mnie plik PPTX?**

Tak. [Podpisy cyfrowe](/slides/pl/cpp/digital-signature-in-powerpoint/) (dodawanie i weryfikacja) są obsługiwane dla prezentacji.

**Czy makra (VBA) są obsługiwane w tworzonych prezentacjach?**

Tak. Możesz [tworzyć/edytować projekty VBA](/slides/pl/cpp/presentation-via-vba/) i zapisywać pliki z włączonymi makrami, takie jak PPTM/PPSM.