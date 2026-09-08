---
title: Tworzenie prezentacji w Pythonie via Java
linktitle: Utwórz prezentację
type: docs
weight: 10
url: /pl/python-java/create-presentation/
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
- Python
- Java
- Aspose.Slides
description: "Twórz prezentacje w Pythonie via Java przy użyciu Aspose.Slides — generuj pliki PPT, PPTX i ODP, korzystaj z obsługi OpenDocument i zapisuj je programowo dla niezawodnych wyników."
---
## **Przegląd**

Ten artykuł pokazuje, jak utworzyć prezentację za pomocą Aspose.Slides dla Pythona via Java, dodać kształt z tekstem do pierwszego slajdu i zapisać wynik jako plik PPTX. FAQ obejmuje formaty wyjściowe, szablony, rozmiary slajdów, zużycie pamięci, wątkowość, licencjonowanie, podpisy cyfrowe oraz obsługę VBA.

## **Utworzenie prezentacji**

Tworzenie pliku PowerPoint od podstaw w Aspose.Slides dla Pythona via Java jest tak proste, jak utworzenie instancji klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) . Konstruktor automatycznie dostarcza pustą księgę z jednym slajdem, dając natychmiastowe płótno dla kształtów, tekstu, wykresów lub dowolnej innej treści, której potrzebuje Twoja aplikacja. Po zmodyfikowaniu tego slajdu — lub dodaniu nowych — możesz zachować wynik w formacie PPTX, starszym PPT lub nawet w formatach OpenDocument. Krótkie przykładowe kodu poniżej ilustruje ten przepływ, dodając prosty kształt do pierwszego slajdu.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
1. Pobierz pierwszy slajd za pomocą jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/autoshape/) typu [ShapeType.Cloud](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapetype/#Cloud) przy użyciu [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapecollection/#addAutoShape).
1. Ustaw tekst kształtu za pomocą [TextFrame.setText](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframe/#setText).
1. Zapisz prezentację przy użyciu [Presentation.save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#save) z [SaveFormat.Pptx](https://reference.aspose.com/slides/pl/python-java/aspose.slides/saveformat/#Pptx).

Przykład poniżej wymaga Aspose.Slides dla Pythona via Java oraz kompatybilnego środowiska uruchomieniowego Javy. Uruchamia JVM, jeśli nie jest jeszcze uruchomiona, dodaje kształt chmury do pierwszego slajdu i zapisuje prezentację:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Utwórz prezentację z jednym pustym slajdem.
presentation = Presentation()
try:
    # Pobierz pierwszy slajd.
    slide = presentation.getSlides().get_Item(0)

    # Dodaj kształt chmury i ustaw jego tekst.
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # Zapisz prezentację jako plik PPTX.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wynik:

![Nowa prezentacja](new_presentation.png)

## **FAQ**

**W jakich formatach mogę zapisać nową prezentację?**

Możesz zapisać do [PPTX, PPT i ODP](/slides/pl/python-java/save-presentation/), oraz wyeksportować do [PDF](/slides/pl/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/pl/python-java/convert-powerpoint-to-xps/), [HTML](/slides/pl/python-java/convert-powerpoint-to-html/), [SVG](/slides/pl/python-java/render-slide-as-svg/), oraz [obrazów](/slides/pl/python-java/convert-powerpoint-to-png/), między innymi.

**Czy mogę rozpocząć od szablonu (POTX/POTM) i zapisać jako zwykły PPTX?**

Tak. Wczytaj szablon i zapisz w żądanym formacie; formaty POTX/POTM/PPTM i podobne [są obsługiwane](/slides/pl/python-java/supported-file-formats/).

**Jak kontrolować rozmiar slajdu i proporcje przy tworzeniu prezentacji?**

Ustaw [rozmiar slajdu](/slides/pl/python-java/slide-size/) (w tym predefiniowane proporcje 4:3 i 16:9 lub własne wymiary) i wybierz, jak treść ma być skalowana.

**W jakich jednostkach mierzone są rozmiary i współrzędne?**

W punktach: 1 cal równa się 72 jednostkom.

**Jak radzić sobie z bardzo dużymi prezentacjami (z wieloma plikami multimedialnymi), aby zmniejszyć zużycie pamięci?**

Użyj [strategii zarządzania BLOB](/slides/pl/python-java/manage-blob/), ogranicz przechowywanie w pamięci, korzystając z plików tymczasowych, oraz preferuj przepływy pracy oparte na plikach zamiast wyłącznie strumieni w pamięci.

**Czy mogę tworzyć/zapisywać prezentacje równolegle?**

Nie możesz operować na tej samej instancji [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) z [wielu wątków](/slides/pl/python-java/multithreading/). Uruchamiaj oddzielne, izolowane instancje per wątek lub proces.

**Jak usunąć znak wodny wersji próbnej i ograniczenia?**

[Zastosuj licencję](/slides/pl/python-java/licensing/) raz na proces. Plik XML licencji musi pozostać niezmieniony, a konfiguracja licencji powinna być synchronizowana, jeśli zaangażowane są wielokrotne wątki.

**Czy mogę cyfrowo podpisać utworzone przeze mnie PPTX?**

Tak. [Podpisy cyfrowe](/slides/pl/python-java/digital-signature-in-powerpoint/) (dodawanie i weryfikacja) są obsługiwane w prezentacjach.

**Czy makra (VBA) są obsługiwane w tworzonych prezentacjach?**

Tak. Możesz [tworzyć/edytować projekty VBA](/slides/pl/python-java/presentation-via-vba/) i zapisywać pliki z włączonymi makrami, takie jak PPTM/PPSM.