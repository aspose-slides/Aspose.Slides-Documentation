---
title: Tworzenie prezentacji w Javie
linktitle: Utwórz prezentację
type: docs
weight: 10
url: /pl/java/create-presentation/
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
- Java
- Aspose.Slides
description: "Tworzenie prezentacji w Javie z Aspose.Slides — generuj pliki PPT, PPTX i ODP, korzystaj z obsługi OpenDocument i zapisuj je programowo, aby uzyskać niezawodne wyniki."
---
## **Przegląd**

Ten artykuł pokazuje, jak utworzyć prezentację w Aspose.Slides, dodać prostą zawartość do slajdu i zapisać wynik jako plik. Demonstracja obejmuje również tworzenie i zapisywanie nowej prezentacji, otwieranie istniejącej prezentacji w obsługiwanym formacie oraz zapisywanie jej w innym formacie. Dodatkowo artykuł zawiera krótkie FAQ obejmujące typowe pytania dotyczące formatów, szablonów, rozmiaru slajdów, jednostek, zużycia pamięci, wielowątkowości, licencjonowania, podpisów cyfrowych i obsługi VBA.

## **Utworzenie prezentacji**

Tworzenie pliku PowerPoint od podstaw w Aspose.Slides dla Javy jest tak proste, jak utworzenie instancji klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) . Konstruktor automatycznie dostarcza pustą prezentację z jednym slajdem, dając natychmiastowe płótno dla kształtów, tekstu, wykresów lub dowolnej innej treści potrzebnej Twojej aplikacji. Po modyfikacji tego slajdu—lub dodaniu nowych—możesz zapisać wynik jako PPTX, starszy PPT lub nawet formaty OpenDocument. Poniższy krótki przykład kodu ilustruje ten proces, dodając prosty kształt na pierwszym slajdzie.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/).
1. Pobierz odniesienie do slajdu według jego indeksu.
1. Dodaj obiekt [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/) typu `Cloud` przy użyciu metody `addAutoShape` udostępnionej przez kolekcję `Shapes`.
1. Dodaj tekst do auto-shape.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

W poniższym przykładzie do pierwszego slajdu prezentacji dodano kształt chmury.

```java
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
Presentation presentation = new Presentation();
try {
    // Pobierz pierwszy slajd.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Dodaj auto-kształt typu Cloud.
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    // Zapisz prezentację jako plik PPTX.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Nowa prezentacja](new_presentation.png)

## **FAQ**

**Jakie formaty mogę zapisać nową prezentację?**

Możesz zapisać do [PPTX, PPT i ODP](/slides/pl/java/save-presentation/), a także wyeksportować do [PDF](/slides/pl/java/convert-powerpoint-to-pdf/), [XPS](/slides/pl/java/convert-powerpoint-to-xps/), [HTML](/slides/pl/java/convert-powerpoint-to-html/), [SVG](/slides/pl/java/convert-powerpoint-to-png/) oraz [obrazów](/slides/pl/java/convert-powerpoint-to-png/), między innymi.

**Czy mogę rozpocząć od szablonu (POTX/POTM) i zapisać jako zwykły PPTX?**

Tak. Załaduj szablon i zapisz w żądanym formacie; formaty POTX/POTM/PPTM i podobne [są obsługiwane](/slides/pl/java/supported-file-formats/).

**Jak kontrolować rozmiar i proporcje slajdu przy tworzeniu prezentacji?**

Ustaw [rozmiar slajdu](/slides/pl/java/slide-size/) (w tym wstępne ustawienia, takie jak 4:3 i 16:9, lub własne wymiary) i wybierz, jak zawartość ma być skalowana.

**W jakich jednostkach mierzone są rozmiary i współrzędne?**

W punktach: 1 cal to 72 jednostki.

**Jak radzić sobie z bardzo dużymi prezentacjami (z wieloma plikami multimedialnymi), aby zmniejszyć zużycie pamięci?**

Użyj [strategii zarządzania BLOB](/slides/pl/java/manage-blob/), ogranicz przechowywanie w pamięci, korzystając z plików tymczasowych, i preferuj przepływy oparte na plikach zamiast wyłącznie strumieni w pamięci.

**Czy mogę tworzyć/zapisywać prezentacje równolegle?**

Nie możesz operować na tej samej instancji [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) z [wielu wątków](/slides/pl/java/multithreading/). Uruchamiaj oddzielne, izolowane instancje na każdy wątek lub proces.

**Jak usunąć znak wodny wersji próbnej i ograniczenia?**

[Zastosuj licencję](/slides/pl/java/licensing/) raz na proces. Plik XML licencji musi pozostać niezmieniony, a konfiguracja licencji powinna być synchronizowana, jeśli zaangażowane są wiele wątków.

**Czy mogę cyfrowo podpisać tworzony przeze mnie PPTX?**

Tak. [Podpisy cyfrowe](/slides/pl/java/digital-signature-in-powerpoint/) (dodawanie i weryfikacja) są obsługiwane dla prezentacji.

**Czy makra (VBA) są obsługiwane w tworzonych prezentacjach?**

Tak. Możesz [tworzyć/edytować projekty VBA](/slides/pl/java/presentation-via-vba/) i zapisywać pliki z włączonymi makrami, takie jak PPTM/PPSM.