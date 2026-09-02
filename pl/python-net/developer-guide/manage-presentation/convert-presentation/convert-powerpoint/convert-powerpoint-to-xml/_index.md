---
title: Konwertuj prezentacje PowerPoint do XML w Pythonie
linktitle: PowerPoint do XML
type: docs
weight: 145
url: /pl/python-net/convert-powerpoint-to-xml/
keywords:
- konwertować PowerPoint do XML
- konwertować prezentację do XML
- PPT do XML
- PPTX do XML
- ODP do XML
- Prezentacja PowerPoint XML
- SaveFormat.XML
- zapisz prezentację jako XML
- wyeksportuj prezentację do XML
- strumień XML
- Python
- Aspose.Slides
description: "Konwertuj prezentacje PowerPoint i OpenDocument do plików lub strumieni PowerPoint XML w Pythonie przy użyciu Aspose.Slides."
---
## **Przegląd**

Aspose.Slides for Python via .NET może konwertować prezentacje PowerPoint na format PowerPoint XML Presentation. Wyjście XML jest przydatne, gdy potrzebujesz reprezentacji tekstowej do przeglądania struktury prezentacji, rozwiązywania problemów z wygenerowanymi dokumentami, porównywania wyników w testach automatycznych lub integracji z przepływem pracy, który konsumuje XML zamiast pakietu prezentacji.

Użyj metody [Presentation.save](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/save/) z wartością `XML` z wyliczenia [SaveFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/saveformat/). Możesz zapisać wynik bezpośrednio do pliku lub do strumienia.

{{% alert color="info" title="Uwaga" %}}

`SaveFormat.XML` tworzy PowerPoint XML Presentation. Nie wyodrębnia on poszczególnych części Office Open XML przechowywanych w pakiecie PPTX. Jeśli potrzebujesz dokładnych części pakietu PPTX, takich jak `ppt/presentation.xml` lub pojedynczych plików XML slajdów, sprawdź sam pakiet PPTX.

{{% /alert %}}

## **Konwertuj prezentację do pliku XML**

Załaduj źródłową prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) i następnie przekaż ścieżkę wyjściową oraz `SaveFormat.XML` do [Presentation.save](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/save/). Źródłem może być dowolny format prezentacji obsługiwany przy ładowaniu, taki jak PPT, PPTX lub ODP.

Poniższy przykład konwertuje prezentację PPTX na plik XML:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.xml", slides.export.SaveFormat.XML)
```

## **Zapisz wyjście XML do strumienia**

Użyj przeciążenia strumieniowego metody [Presentation.save](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/save/) gdy XML musi pozostać w pamięci lub być przekazane do innego komponentu, takiego jak usługa sieciowa, dostawca pamięci lub potok przetwarzania XML. Poniższy przykład zapisuje wynik do strumienia [BytesIO](https://docs.python.org/3/library/io.html#io.BytesIO) i przewija go do początku w celu późniejszego odczytu:

```py
from io import BytesIO

import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    xml_stream = BytesIO()
    presentation.save(xml_stream, slides.export.SaveFormat.XML)
    xml_stream.seek(0)

    # Przekaż xml_stream do następnego komponentu w przepływie pracy.
```

## **Porównaj XML z formatami prezentacji i eksportu**

Wybierz format wyjściowy w zależności od tego, jak wynik będzie używany:

| Format | Wyjście | Typowe zastosowanie |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Prezentacja PowerPoint XML | Przeglądanie struktury, rozwiązywanie problemów, porównywanie wygenerowanego wyniku oraz integracja oparta na XML |
| PPT (`.ppt`) | Starszy binarny plik prezentacji | Kompatybilność ze starszymi przepływami pracy PowerPoint |
| PPTX (`.pptx`) | Pakiet Office Open XML zawierający wiele części | Standardowa edycja PowerPoint i wymiana prezentacji |
| PDF lub TIFF | Strony o stałym układzie lub obraz wielostronicowy | Wyświetlanie, drukowanie i archiwizacja |
| PNG, JPEG lub SVG | Wygenerowana reprezentacja pojedynczego slajdu | Miniatury, podglądy i zasoby graficzne |
| HTML lub HTML5 | Wyjście prezentacji skierowane do sieci | Wyświetlanie w przeglądarce i publikowanie w sieci |

W przeciwieństwie do PPT i PPTX, wyjście XML jest przeznaczone głównie do inspekcji i przepływów pracy opartych na danych. W odróżnieniu od PDF, TIFF, HTML i formatów obrazów slajdów, reprezentuje ono dane prezentacji, a nie renderuje slajdów jako strony lub zasoby wizualne. Tabela [supported file formats](/slides/pl/python-net/supported-file-formats/) wskazuje PowerPoint XML Presentation jako format jedynie do zapisu, więc nie używaj go, gdy przepływ pracy musi wczytać wyeksportowany plik z powrotem do Aspose.Slides w celu dalszej edycji.

## **FAQ**

**Czy `SaveFormat.XML` jest tym samym co zapisanie pliku PPTX?**

Nie. PPTX jest pakietem zawierającym wiele części Office Open XML, podczas gdy `SaveFormat.XML` tworzy plik PowerPoint XML Presentation.

**Czy mogę zapisać wyjście XML bez tworzenia pliku na dysku?**

Tak. Przekaż zapisywalny strumień do [Presentation.save](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/save/). Na przykład użyj strumienia [BytesIO](https://docs.python.org/3/library/io.html#io.BytesIO) do przetwarzania w pamięci.

**Czy Aspose.Slides może ponownie wczytać wyeksportowany plik XML?**

Nie. PowerPoint XML Presentation jest obecnie obsługiwany jedynie do zapisu, nie do odczytu. Użyj PPTX lub innego obsługiwanego formatu prezentacji, gdy wymagana jest edycja w obie strony.

**Czy konwersja XML renderuje każdy slajd jako stronę lub obraz?**

Nie. Konwersja XML zapisuje ustrukturyzowane dane prezentacji. Użyj PDF lub TIFF do wyjścia o charakterze stron, albo PNG, JPEG i SVG do obrazów pojedynczych slajdów.