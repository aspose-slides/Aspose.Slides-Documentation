---
title: Konwertuj prezentacje PowerPoint do XML w PHP
linktitle: PowerPoint do XML
type: docs
weight: 145
url: /pl/php-java/convert-powerpoint-to-xml/
keywords:
- konwertuj PowerPoint do XML
- konwertuj prezentację do XML
- PPT do XML
- PPTX do XML
- ODP do XML
- Prezentacja PowerPoint XML
- SaveFormat.Xml
- zapisz prezentację jako XML
- wyeksportuj prezentację do XML
- strumień XML
- PHP
- Aspose.Slides
description: "Konwertuj prezentacje PowerPoint i OpenDocument na pliki lub strumienie PowerPoint XML w PHP przy użyciu Aspose.Slides dla PHP via Java."
---
## **Przegląd**

Aspose.Slides for PHP via Java może konwertować prezentacje PowerPoint do formatu PowerPoint XML Presentation. Wyjście XML jest przydatne, gdy potrzebna jest tekstowa reprezentacja do analizowania struktury prezentacji, rozwiązywania problemów z wygenerowanymi dokumentami, porównywania wyników w testach automatycznych lub integracji z przepływem pracy, który konsumuje XML zamiast pakietu prezentacji.

Użyj metody [Presentation::save](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) z wartością `Xml` z wyliczenia [SaveFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/saveformat/). Wynik można zapisać bezpośrednio do pliku lub do strumienia.

{{% alert color="info" title="Note" %}}
`SaveFormat::Xml` tworzy PowerPoint XML Presentation. Nie wyodrębnia poszczególnych części Office Open XML przechowywanych w pakiecie PPTX. Jeśli potrzebujesz dokładnych części pakietu PPTX, takich jak `ppt/presentation.xml` lub indywidualnych plików XML slajdów, sprawdź sam pakiet PPTX.
{{% /alert %}}

## **Konwertuj prezentację na plik XML**

Załaduj prezentację źródłową przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/), a następnie przekaż ścieżkę wyjściową i `SaveFormat::Xml` do [Presentation::save](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/). Źródło może być w dowolnym formacie obsługiwanym przy ładowaniu, takim jak PPT, PPTX lub ODP.

Poniższy przykład konwertuje prezentację PPTX na plik XML:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.xml";
$presentation = new Presentation($inputPath);
try {
    $presentation->save($outputPath, SaveFormat::Xml);
} finally {
    $presentation->dispose();
}
```

## **Zapisz wyjście XML do strumienia**

Użyj przeciążenia strumieniowego metody [Presentation::save](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/), gdy XML musi pozostać w pamięci lub być przekazany do innego komponentu, takiego jak usługa sieciowa, dostawca przechowywania lub potok przetwarzania XML. Poniższy przykład zapisuje wynik do [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) i uzyskuje wygenerowany XML jako tablicę bajtów:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$presentation = new Presentation($inputPath);
try {
    $xmlStream = new Java("java.io.ByteArrayOutputStream");
    try {
        $presentation->save($xmlStream, SaveFormat::Xml);
        $xmlBytes = $xmlStream->toByteArray();

        // Przekaż $xmlBytes do następnego komponentu w przepływie pracy.
    } finally {
        $xmlStream->close();
    }
} finally {
    $presentation->dispose();
}
```

`ByteArrayOutputStream` przechowuje wszystkie wygenerowane dane w pamięci, więc przed wywołaniem `toByteArray` nie jest wymagane resetowanie pozycji.

## **Porównaj XML z formatami prezentacji i eksportu**

Wybierz format wyjściowy w zależności od tego, jak wynik będzie używany:

| Format | Wyjście | Typowe zastosowanie |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Prezentacja PowerPoint XML | Analiza struktury, rozwiązywanie problemów, porównywanie wygenerowanego wyniku oraz integracja oparta na XML |
| PPT (`.ppt`) | Plik prezentacji w starszym formacie binarnym | Kompatybilność ze starszymi przepływami pracy PowerPoint |
| PPTX (`.pptx`) | Pakiet Office Open XML zawierający wiele części | Standardowa edycja PowerPoint i wymiana prezentacji |
| PDF lub TIFF | Strony o stałym układzie lub obraz wielostronicowy | Przeglądanie, drukowanie i archiwizacja |
| PNG, JPEG lub SVG | Wizualna reprezentacja pojedynczego slajdu | Miniatury, podglądy i zasoby graficzne |
| HTML lub HTML5 | Wyjście prezentacji przeznaczone dla sieci | Wyświetlanie w przeglądarce i publikowanie w sieci |

W przeciwieństwie do PPT i PPTX, wyjście XML jest przeznaczone głównie do inspekcji i przepływów pracy opartych na danych. W przeciwieństwie do PDF, TIFF, HTML i formatów obrazów slajdów, reprezentuje dane prezentacji, a nie renderuje slajdów jako strony lub zasoby wizualne. W tabeli [obsługiwane formaty plików](/slides/pl/php-java/supported-file-formats/) format PowerPoint XML Presentation jest wymieniony jako jedynie do zapisu, więc nie należy go używać, gdy przepływ pracy musi ponownie wczytać wyeksportowany plik do Aspose.Slides w celu dalszej edycji.

## **FAQ**

**Czy `SaveFormat::Xml` jest tym samym, co zapisanie pliku PPTX?**

Nie. PPTX jest pakietem zawierającym wiele części Office Open XML, natomiast `SaveFormat::Xml` tworzy plik PowerPoint XML Presentation.

**Czy mogę zapisać wyjście XML bez tworzenia pliku na dysku?**

Tak. Przekaż zapisywalny strumień do [Presentation::save](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/). Na przykład użyj [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) do przetwarzania w pamięci.

**Czy Aspose.Slides może ponownie wczytać wyeksportowany plik XML?**

Nie. PowerPoint XML Presentation jest obecnie obsługiwany wyłącznie do zapisu, a nie do odczytu. Użyj PPTX lub innego obsługiwanego formatu prezentacji, gdy wymagana jest edycja w obie strony.

**Czy konwersja XML renderuje każdy slajd jako stronę lub obraz?**

Nie. Konwersja XML zapisuje ustrukturyzowane dane prezentacji. Użyj PDF lub TIFF do wyjścia w formie stron, lub PNG, JPEG i SVG do obrazów poszczególnych slajdów.