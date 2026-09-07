---
title: Konwertuj prezentacje PowerPoint na XML w Pythonie za pomocą Java
linktitle: PowerPoint do XML
type: docs
weight: 145
url: /pl/python-java/convert-powerpoint-to-xml/
keywords:
- konwertuj PowerPoint na XML
- konwertuj prezentację na XML
- PPT do XML
- PPTX do XML
- ODP do XML
- Prezentacja PowerPoint XML
- SaveFormat.Xml
- zapisz prezentację jako XML
- eksportuj prezentację do XML
- strumień XML
- Python
- Java
- Aspose.Slides
description: "Konwertuj prezentacje PowerPoint i OpenDocument na pliki lub strumienie PowerPoint XML w Pythonie za pomocą Java przy użyciu Aspose.Slides dla Pythona przez Java."
---
## **Przegląd**

Aspose.Slides for Python via Java może konwertować prezentacje PowerPoint do formatu PowerPoint XML Presentation. Wyjście XML jest przydatne, gdy potrzebujesz tekstowej reprezentacji do przeglądania struktury prezentacji, rozwiązywania problemów z wygenerowanymi dokumentami, porównywania wygenerowanego wyniku w testach automatycznych lub integracji z przepływem pracy, który konsumuje XML zamiast pakietu prezentacji.

Użyj metody [Presentation.save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#save) z wartością [Xml](https://reference.aspose.com/slides/pl/python-java/aspose.slides/saveformat/#Xml) z klasy [SaveFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/saveformat/). Możesz zapisać wynik bezpośrednio do pliku lub do strumienia.

{{% alert color="info" title="Note" %}}
[SaveFormat.Xml](https://reference.aspose.com/slides/pl/python-java/aspose.slides/saveformat/#Xml) tworzy PowerPoint XML Presentation. Nie wyodrębnia on pojedynczych części Office Open XML przechowywanych w pakiecie PPTX. Jeśli potrzebujesz dokładnych części pakietu PPTX, takich jak `ppt/presentation.xml` lub pojedynczych plików XML slajdów, sprawdź sam pakiet PPTX.
{{% /alert %}}

## **Konwertuj prezentację na plik XML**

Załaduj źródłową prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/), a następnie przekaż ścieżkę wyjściową oraz [SaveFormat.Xml](https://reference.aspose.com/slides/pl/python-java/aspose.slides/saveformat/#Xml) do [Presentation.save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#save). Źródło może być w dowolnym formacie prezentacji obsługiwanym przy ładowaniu, takim jak PPT, PPTX lub ODP.

Poniższy przykład konwertuje prezentację PPTX na plik XML:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.xml", SaveFormat.Xml)
finally:
    presentation.dispose()
```

## **Zapisz wyjście XML do strumienia**

Użyj przeciążenia strumieniowego metody [Presentation.save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#save), gdy XML musi pozostać w pamięci lub być przekazany do innego komponentu, takiego jak usługa sieciowa, dostawca magazynu lub potok przetwarzania XML. Poniższy przykład zapisuje wynik do [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) i uzyskuje powstały XML jako obiekt bytes języka Python:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpjpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

presentation = Presentation("presentation.pptx")
try:
    xml_stream = ByteArrayOutputStream()
    try:
        presentation.save(xml_stream, SaveFormat.Xml)
        java_bytes = xml_stream.toByteArray()
        xml_data = bytes(java_bytes)

        # Przekaż xml_data do następnego komponentu w przepływie pracy.
    finally:
        xml_stream.close()
finally:
    presentation.dispose()
```

## **Porównaj XML z formatami prezentacji i eksportu**

Wybierz format wyjściowy w zależności od tego, jak wynik będzie używany:

| Format | Wynik | Typowe zastosowanie |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Prezentacja PowerPoint XML | Inspekcja struktury, rozwiązywanie problemów, porównywanie wygenerowanego wyniku i integracja oparta na XML |
| PPT (`.ppt`) | Starszy binarny plik prezentacji | Zgodność ze starszymi przepływami pracy PowerPoint |
| PPTX (`.pptx`) | Pakiet Office Open XML zawierający wiele części | Standardowa edycja PowerPoint i wymiana prezentacji |
| PDF lub TIFF | Strony o stałym układzie lub obraz wielostronicowy | Wyświetlanie, drukowanie i archiwizacja |
| PNG, JPEG lub SVG | Renderowane przedstawienie pojedynczego slajdu | Miniatury, podglądy i zasoby graficzne |
| HTML lub HTML5 | Wyjście prezentacji przeznaczone do sieci | Wyświetlanie w przeglądarce i publikowanie w sieci |

W przeciwieństwie do PPT i PPTX, wyjście XML jest przeznaczone przede wszystkim do inspekcji i przepływów pracy zorientowanych na dane. W przeciwieństwie do PDF, TIFF, HTML oraz formatów obrazów slajdów, reprezentuje ono dane prezentacji, a nie renderuje slajdów jako strony lub zasoby wizualne. Tabela [supported file formats](/slides/pl/python-java/supported-file-formats/) wymienia PowerPoint XML Presentation jako format jedynie do zapisu, więc nie używaj go, gdy przepływ pracy wymaga wczytania wyeksportowanego pliku z powrotem do Aspose.Slides w celu dalszej edycji.

## **FAQ**

**Czy eksport XML jest tym samym, co zapisywanie pliku PPTX?**

Nie. PPTX jest pakietem zawierającym wiele części Office Open XML, podczas gdy [SaveFormat.Xml](https://reference.aspose.com/slides/pl/python-java/aspose.slides/saveformat/#Xml) tworzy plik PowerPoint XML Presentation.

**Czy mogę zapisać wyjście XML bez tworzenia pliku na dysku?**

Tak. Przekaż zapisywalny strumień wyjściowy Java do [Presentation.save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#save). Na przykład użyj [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) do przetwarzania w pamięci.

**Czy Aspose.Slides może ponownie wczytać wyeksportowany plik XML?**

Nie. PowerPoint XML Presentation jest obecnie obsługiwany tylko do zapisu, a nie do wczytywania. Użyj PPTX lub innego obsługiwanego formatu prezentacji, gdy wymagane jest dwukierunkowe edytowanie.

**Czy konwersja XML renderuje każdy slajd jako stronę lub obraz?**

Nie. Konwersja XML zapisuje ustrukturyzowane dane prezentacji. Użyj PDF lub TIFF do wyjścia ukierunkowanego na strony, lub PNG, JPEG i SVG do obrazów poszczególnych slajdów.