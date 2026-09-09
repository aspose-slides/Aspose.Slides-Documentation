---
title: Tworzenie prezentacji w Pythonie przez Javę
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
description: "Twórz prezentacje w Pythonie przez Javę przy użyciu Aspose.Slides — twórz pliki PPT, PPTX i ODP, korzystaj z obsługi OpenDocument i zapisuj je programowo, aby uzyskać niezawodne wyniki."
---
## **Przegląd**

Ten artykuł pokazuje, jak utworzyć prezentację za pomocą Aspose.Slides dla Pythona przez Javę, dodać kształt z tekstem do pierwszego slajdu i zapisać wynik jako plik PPTX. Sekcja FAQ obejmuje formaty wyjściowe, szablony, rozmiar slajdów, wykorzystanie pamięci, wątkowanie, licencjonowanie, podpisy cyfrowe oraz obsługę VBA.

## **Utworzenie prezentacji**

Tworzenie pliku PowerPoint od podstaw w Aspose.Slides dla Pythona przez Javę jest tak proste, jak utworzenie klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/). Konstruktor automatycznie dostarcza pustą prezentację z jednym slajdem, dając od razu płótno do kształtów, tekstu, wykresów lub innej treści potrzebnej aplikacji. Po modyfikacji tego slajdu — lub dodaniu nowych — można zapisać wynik w formacie PPTX, starszym PPT lub nawet OpenDocument. Krótki przykład kodu poniżej ilustruje ten przepływ, dodając prosty kształt na pierwszy slajd.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
1. Pobierz pierwszy slajd według jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/autoshape/) typu [ShapeType.Cloud](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapetype/#Cloud) używając [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapecollection/#addAutoShape).
1. Ustaw tekst kształtu przy pomocy [TextFrame.setText](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframe/#setText).
1. Zapisz prezentację przy użyciu [Presentation.save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#save) z [SaveFormat.Pptx](https://reference.aspose.com/slides/pl/python-java/aspose.slides/saveformat/#Pptx).

Poniższy przykład wymaga Aspose.Slides dla Pythona przez Javę oraz kompatybilnego środowiska uruchomieniowego Javy. Uruchamia JVM, jeśli nie jest już uruchomiona, dodaje kształt chmury do pierwszego slajdu i zapisuje prezentację:

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

**Jakie formaty mogę zapisać nową prezentację?**

Możesz zapisać do [PPTX, PPT i ODP](/slides/pl/python-java/save-presentation/), a także eksportować do [PDF](/slides/pl/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/pl/python-java/convert-powerpoint-to-xps/), [HTML](/slides/pl/python-java/convert-powerpoint-to-html/), [SVG](/slides/pl/python-java/render-slide-as-svg/) oraz [obrazów](/slides/pl/python-java/convert-powerpoint-to-png/), między innymi.

**Czy mogę rozpocząć od szablonu (POTX/POTM) i zapisać jako standardowy PPTX?**

Tak. Załaduj szablon i zapisz w żądanym formacie; formaty POTX/POTM/PPTM i podobne [są obsługiwane](/slides/pl/python-java/supported-file-formats/).

**Jak kontrolować rozmiar slajdu/proporcje obrazu przy tworzeniu prezentacji?**

Ustaw [slide size](/slides/pl/python-java/slide-size/) (w tym predefiniowane 4:3 i 16:9 lub własne wymiary) i wybierz, jak ma być skalowana zawartość.

**W jakich jednostkach mierzone są rozmiary i współrzędne?**

W punktach: 1 cal = 72 jednostki.

**Jak radzić sobie z bardzo dużymi prezentacjami (z wieloma plikami multimedialnymi), aby zmniejszyć zużycie pamięci?**

Użyj [BLOB management strategies](/slides/pl/python-java/manage-blob/), ogranicz przechowywanie w pamięci, wykorzystując pliki tymczasowe, i preferuj przepływy pracy oparte na plikach zamiast wyłącznie strumieni w pamięci.

**Czy mogę tworzyć/zapisywać prezentacje równolegle?**

Nie możesz operować na tej samej instancji [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) z [multiple threads](/slides/pl/python-java/multithreading/). Uruchamiaj oddzielne, izolowane instancje na każdy wątek lub proces.

**Jak usunąć znak wodny wersji próbnej i ograniczenia?**

[Apply a license](/slides/pl/python-java/licensing/) raz na proces. XML licencji musi pozostać niezmieniony, a konfiguracja licencji powinna być zsynchronizowana, jeśli używane są wielowątkowe operacje.

**Czy mogę cyfrowo podpisać utworzony PPTX?**

Tak. [Digital signatures](/slides/pl/python-java/digital-signature-in-powerpoint/) (dodawanie i weryfikacja) są obsługiwane dla prezentacji.

**Czy makra (VBA) są obsługiwane w tworzonych prezentacjach?**

Tak. Możesz [create/edit VBA projects](/slides/pl/python-java/presentation-via-vba/) i zapisywać pliki z włączonymi makrami, takie jak PPTM/PPSM.