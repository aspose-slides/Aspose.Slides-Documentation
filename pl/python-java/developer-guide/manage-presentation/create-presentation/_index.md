---
title: Tworzenie prezentacji w Pythonie za pomocą Java
linktitle: Utwórz prezentację
type: docs
weight: 10
url: /pl/python-java/create-presentation/
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
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Twórz prezentacje w Pythonie za pomocą Java i Aspose.Slides—generuj pliki PPT, PPTX i ODP, korzystaj ze wsparcia OpenDocument i zapisuj je programowo dla niezawodnych wyników."
---
## **Przegląd**

Ten artykuł pokazuje, jak utworzyć prezentację przy użyciu Aspose.Slides for Python via Java, dodać kształt z tekstem do pierwszego slajdu i zapisać wynik jako plik PPTX. FAQ opisuje formaty wyjściowe, szablony, rozmiary slajdów, zużycie pamięci, wielowątkowość, licencjonowanie, podpisy cyfrowe oraz obsługę VBA.

Zanim rozpoczniesz, zainstaluj Pythona, JDK, JPype oraz Aspose.Slides for Python via Java. Zobacz [Instalacja](/slides/pl/python-java/installation/) po kroki dla Windows, Linux i macOS.

## **Utwórz prezentację**

Tworzenie pliku PowerPoint od podstaw w Aspose.Slides for Python via Java jest tak proste, jak utworzenie instancji klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/). Konstruktor automatycznie dostarcza pustą prezentację z jednym slajdem, dając natychmiastowy obszar roboczy dla kształtów, tekstu, wykresów lub innej treści, której potrzebuje Twoja aplikacja. Po zmodyfikowaniu tego slajdu — lub dodaniu nowych — możesz zapisać wynik w formacie PPTX, starszym PPT lub nawet OpenDocument. Krótki przykład kodu poniżej ilustruje ten przepływ, dodając prosty kształt na pierwszy slajd.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
1. Pobierz pierwszy slajd po jego indeksie, 0.
1. Dodaj [AutoShape](/slides/pl/python-java/aspose.slides/autoshape/) typu [ShapeType.Cloud](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapetype/#Cloud) przy użyciu [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapecollection/#addAutoShape).
1. Ustaw tekst kształtu za pomocą [TextFrame.setText](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframe/#setText).
1. Zapisz prezentację używając [Presentation.save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#save) z [SaveFormat.Pptx](https://reference.aspose.com/slides/pl/python-java/aspose.slides/saveformat/#Pptx).

Przykład poniżej uruchamia maszynę wirtualną Javy (JVM), jeśli nie jest już uruchomiona, dodaje kształt chmury z tekstem do pierwszego slajdu i zapisuje prezentację. Zapisz go jako *create_presentation.py*:

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

Uruchom skrypt w środowisku, w którym zainstalowano pakiety:

```sh
python create_presentation.py
```

Górny lewy róg chmury znajduje się 20 punktów od lewej i górnej krawędzi slajdu, a chmura ma szerokość 200 punktów i wysokość 80 punktów. Skrypt zapisuje *new_presentation.pptx* w bieżącym katalogu roboczym, z jednym slajdem zawierającym chmurę i jej tekst. JVM działa, dopóki proces Pythona nie zakończy się; zobacz [Ograniczenia i różnice API](/slides/pl/python-java/limitations-and-api-differences/#import-the-library). Bez licencji Aspose.Slides dodaje również tekstowe pole z wodnym znakiem oceny do każdego zapisanego slajdu; zobacz [Licencjonowanie](/slides/pl/python-java/licensing/).

Wynik:

![Nowa prezentacja](new_presentation.png)

## **FAQ**

**Jakie formaty mogę zapisać nową prezentację?**

Możesz zapisać w formacie [PPTX, PPT i ODP](/slides/pl/python-java/save-presentation/), a także wyeksportować do [PDF](/slides/pl/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/pl/python-java/convert-powerpoint-to-xps/), [HTML](/slides/pl/python-java/convert-powerpoint-to-html/), [SVG](/slides/pl/python-java/render-a-slide-as-an-svg-image/) oraz [obrazów](/slides/pl/python-java/convert-powerpoint-to-png/), entre innych.

**Czy mogę rozpocząć od szablonu (POTX/POTM) i zapisać jako zwykły PPTX?**

Tak. Załaduj szablon i zapisz w żądanym formacie; formaty POTX/POTM/PPTM i podobne [są obsługiwane](/slides/pl/python-java/supported-file-formats/).

**Jak kontrolować rozmiar slajdu/współczynnik proporcji przy tworzeniu prezentacji?**

Ustaw [rozmiar slajdu](/slides/pl/python-java/slide-size/) (w tym ustawienia wstępne takie jak 4:3 i 16:9 lub niestandardowe wymiary) i wybierz sposób skalowania treści.

**W jakich jednostkach mierzone są rozmiary i współrzędne?**

W punktach: 1 cal to 72 jednostki.

**Jak radzić sobie z bardzo dużymi prezentacjami (z wieloma plikami multimedialnymi), aby zmniejszyć zużycie pamięci?**

Użyj [strategii zarządzania BLOB](/slides/pl/python-java/manage-blob/), ogranicz przechowywanie w pamięci przy pomocy plików tymczasowych i preferuj przepływy oparte na plikach zamiast wyłącznie strumieni w pamięci.

**Czy mogę tworzyć/zapisywać prezentacje równolegle?**

Nie możesz operować na tej samej [Presentation](/slides/pl/python-java/multithreading/) z [wielu wątków](/slides/pl/python-java/multithreading/). Uruchom oddzielne, izolowane instancje na wątek lub proces.

**Jak usunąć znak wodny wersji próbnej i ograniczenia?**

[Zastosuj licencję](/slides/pl/python-java/licensing/) raz na proces. Plik XML licencji musi pozostać niezmieniony, a konfiguracja licencji powinna być zsynchronizowana, jeśli używane są wielokrotne wątki.

**Czy mogę cyfrowo podpisać utworzony PPTX?**

Tak. [Podpisy cyfrowe](/slides/pl/python-java/digital-signature-in-powerpoint/) (dodawanie i weryfikacja) są obsługiwane dla prezentacji.

**Czy makra (VBA) są obsługiwane w tworzonych prezentacjach?**

Tak. Możesz [tworzyć/edytować projekty VBA](/slides/pl/python-java/presentation-via-vba/) i zapisywać pliki z włączonymi makrami, takie jak PPTM/PPSM.