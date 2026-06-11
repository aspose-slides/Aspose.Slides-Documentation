---
title: Tworzenie prezentacji w Pythonie
linktitle: Utwórz prezentację
type: docs
weight: 10
url: /pl/python-net/create-presentation/
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
- Python
- Aspose.Slides
description: "Twórz prezentacje PowerPoint w Pythonie przy użyciu Aspose.Slides — twórz pliki PPT, PPTX i ODP, korzystaj ze wsparcia OpenDocument i zapisuj je programowo, aby uzyskać niezawodne wyniki."
---
## **Przegląd**

Aspose.Slides for Python umożliwia tworzenie nowego pliku prezentacji w całości przy użyciu kodu. Ten artykuł przedstawia podstawowy przepływ pracy — tworzenie obiektu [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/), pobieranie pierwszego slajdu, wstawianie prostego kształtu i zapisywanie wyniku — aby pokazać, jak mało ustawień jest potrzebnych do wygenerowania prezentacji bez Microsoft Office. Ponieważ to samo API zapisuje pliki PPT, PPTX i ODP, możesz obsługiwać zarówno tradycyjne formaty PowerPoint, jak i OpenDocument z jednej bazy kodu. Aspose.Slides nadaje się do środowisk desktopowych, internetowych lub serwerowych, dając aplikacji Python efektywny punkt wyjścia do dodawania bogatszej zawartości, takiej jak tekst, obrazy czy wykresy, po utworzeniu początkowego zestawu slajdów.

## **Utworzenie prezentacji**

Tworzenie pliku PowerPoint od podstaw w Aspose.Slides for Python jest tak proste, jak zainicjowanie klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/). Konstruktor automatycznie dostarcza pustą prezentację z jednym slajdem, dając natychmiastowe płótno dla kształtów, tekstu, wykresów lub dowolnej innej zawartości, której potrzebuje Twoja aplikacja. Po zmodyfikowaniu tego slajdu — lub dodaniu nowych — możesz zapisać wynik jako PPTX, starszy PPT lub nawet w formacie OpenDocument. Krótkie przykładowe wycinki kodu poniżej ilustrują ten przepływ, dodając prosty kształt do pierwszego slajdu.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Pobierz odwołanie do slajdu według jego indeksu.
1. Dodaj obiekt [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/) typu `CLOUD` przy użyciu metody `add_auto_shape` udostępnionej kolekcji `shapes`.
1. Dodaj tekst do automatycznego kształtu.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

W przykładowym kodzie poniżej do pierwszego slajdu prezentacji dodano kształt chmury.

```py
import aspose.slides as slides

# Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
with slides.Presentation() as presentation:
    # Pobierz pierwszy slajd.
    slide = presentation.slides[0]

    # Dodaj auto-kształt typu CLOUD.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # Zapisz prezentację jako plik PPTX.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

Wynik:

![Nowa prezentacja](new_presentation.png)

## **FAQ**

**Jakie formaty mogę zapisać dla nowej prezentacji?**

Możesz zapisać w formatach [PPTX, PPT i ODP](/slides/pl/python-net/save-presentation/), a także eksportować do [PDF](/slides/pl/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/pl/python-net/convert-powerpoint-to-xps/), [HTML](/slides/pl/python-net/convert-powerpoint-to-html/), [SVG](/slides/pl/python-net/convert-powerpoint-to-png/) i [obrazów](/slides/pl/python-net/convert-powerpoint-to-png/), oraz innych.

**Czy mogę rozpocząć od szablonu (POTX/POTM) i zapisać jako zwykły PPTX?**

Tak. Załaduj szablon i zapisz w żądanym formacie; formaty POTX/POTM/PPTM i podobne [są obsługiwane](/slides/pl/python-net/supported-file-formats/).

**Jak kontrolować rozmiar slajdu/ proporcje przy tworzeniu prezentacji?**

Ustaw [rozmiar slajdu](/slides/pl/python-net/slide-size/) (w tym gotowe ustawienia, takie jak 4:3 i 16:9 lub własne wymiary) i wybierz, w jaki sposób treść ma być skalowana.

**W jakich jednostkach mierzone są rozmiary i współrzędne?**

W punktach: 1 cal to 72 jednostki.

**Jak radzić sobie z bardzo dużymi prezentacjami (z wieloma plikami multimedialnymi), aby zmniejszyć zużycie pamięci?**

Korzystaj ze [strategii zarządzania BLOB](/slides/pl/python-net/manage-blob/), ograniczaj przechowywanie w pamięci, wykorzystując pliki tymczasowe, i preferuj przepływy oparte na plikach zamiast wyłącznie strumieni w pamięci.

**Czy mogę tworzyć/zapisywać prezentacje równolegle?**

Nie możesz operować na tej samej instancji [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) z [wielu wątków](/slides/pl/python-net/multithreading/). Uruchom oddzielne, izolowane instancje na każdy wątek lub proces.

**Jak usunąć znak wodny wersji próbnej i ograniczenia?**

[Zastosuj licencję](/slides/pl/python-net/licensing/) raz na proces. XML licencji musi pozostać niezmieniony, a konfigurację licencji należy synchronizować, jeśli używane są wielowątkowe operacje.

**Czy mogę cyfrowo podpisać utworzony PPTX?**

Tak. [Podpisy cyfrowe](/slides/pl/python-net/digital-signature-in-powerpoint/) (dodawanie i weryfikacja) są obsługiwane dla prezentacji.

**Czy makra (VBA) są obsługiwane w tworzonych prezentacjach?**

Tak. Możesz [tworzyć/edytować projekty VBA](/slides/pl/python-net/presentation-via-vba/) i zapisywać pliki z włączonymi makrami, takie jak PPTM/PPSM.