---
title: Tworzenie prezentacji w PHP
linktitle: Utwórz prezentację
type: docs
weight: 10
url: /pl/php-java/create-presentation/
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
- PHP
- Aspose.Slides
description: "Twórz prezentacje przy użyciu Aspose.Slides dla PHP via Java — generuj pliki PPT, PPTX i ODP oraz zapisuj je programowo, aby uzyskać niezawodne rezultaty."
---
## **Przegląd**

Ten artykuł pokazuje, jak utworzyć prezentację w Aspose.Slides, dodać pole tekstowe do jej pierwszego slajdu i zapisać wynik jako plik. Pokazuje również, jak utworzyć i zapisać pustą prezentację oraz jak otworzyć istniejącą prezentację w obsługiwanym formacie i zapisać ją w innym formacie. Krótkie FAQ na końcu zawiera najczęstsze pytania dotyczące formatów, szablonów, rozmiaru slajdów, jednostek, zużycia pamięci, wątków, licencjonowania, podpisów cyfrowych i obsługi VBA.

Przed rozpoczęciem zainstaluj Aspose.Slides for PHP via Java przy użyciu Composer i uruchom PHP/Java Bridge w Apache Tomcat. Zobacz [Instalacja](/slides/pl/php-java/installation/) po pełną konfigurację. Przykłady poniżej zakładają, że Tomcat działa na `localhost:8080`, a folder `vendor` Composer znajduje się obok skryptu.

## **Utworzenie prezentacji PowerPoint**

Aby utworzyć prezentację i umieścić pole tekstowe na jej pierwszym slajdzie, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/). Nowa prezentacja zawiera już jeden pusty slajd.
1. Uzyskaj ten slajd z kolekcji zwróconej przez [Presentation::getSlides](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/getslides/), używając indeksu 0.
1. Dodaj prostokąt metodą [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/addautoshape/) i ustaw jego tekst przy użyciu [TextFrame::setText](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/settext/).
1. Zapisz prezentację jako plik PPTX przy użyciu metody [Presentation::save](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/save/).

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/pl/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    $shape->getTextFrame()->setText("Hello, Aspose.Slides!");
    $presentation->save(__DIR__ . "/hello.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Dwie linie `require_once` ładują klienta PHP/Java Bridge z Tomcata oraz klasy Aspose.Slides z pakietu Composer. Górny lewy róg prostokąta znajduje się 50 punktów od lewej krawędzi i 50 punktów od górnej krawędzi slajdu, a prostokąt ma szerokość 400 punktów i wysokość 100 punktów. Zapisany plik zawiera jeden slajd z tym prostokątem i jego tekstem. Bez licencji Aspose.Slides dodaje również znak wodny oceny do każdego zapisanego slajdu; zobacz [Licencjonowanie](/slides/pl/php-java/licensing/).

{{% alert color="info" title="Note" %}}
Aspose.Slides odczytuje i zapisuje pliki wewnątrz Tomcata, a nie w Twoim procesie PHP, dlatego ścieżka względna, taka jak `"hello.pptx"`, jest rozwiązywana względem katalogu roboczego Tomcata. Przykłady na tej stronie tworzą ścieżki bezwzględne przy użyciu `__DIR__`, więc pliki są odczytywane i zapisywane obok skryptu.
{{% /alert %}}

## **Utworzenie i zapisanie prezentacji**

Aby utworzyć pustą prezentację i zapisać ją, utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) i zapisz ją w dowolnym formacie z wyliczenia [SaveFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/saveformat/). Wynikiem jest prezentacja z jednym pustym slajdem.

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/pl/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $presentation->save(__DIR__ . "/OutputPresentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Otwarcie i zapisanie prezentacji**

Aby przekonwertować prezentację z jednego formatu na drugi, otwórz ją, przekazując jej ścieżkę do konstruktora [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/), a następnie zapisz w docelowym formacie. Aspose.Slides wykrywa format wejściowy, taki jak PPT, PPTX lub ODP, na podstawie samego pliku.

Poniższy przykład zakłada, że prezentacja OpenDocument o nazwie *Sample.odp* znajduje się obok skryptu i zapisuje ją jako PPTX.

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/pl/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation(__DIR__ . "/Sample.odp");
try {
    $presentation->save(__DIR__ . "/OutputPresentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

### W jakich formatach mogę zapisać nową prezentację?

Możesz zapisać do [PPTX, PPT i ODP](/slides/pl/php-java/save-presentation/), a także wyeksportować do [PDF](/slides/pl/php-java/convert-powerpoint-to-pdf/), [XPS](/slides/pl/php-java/convert-powerpoint-to-xps/), [HTML](/slides/pl/php-java/convert-powerpoint-to-html/), [SVG](/slides/pl/php-java/render-a-slide-as-an-svg-image/) oraz [obrazów](/slides/pl/php-java/convert-powerpoint-to-png/), i innych.

### Czy mogę rozpocząć od szablonu (POTX/POTM) i zapisać jako zwykły PPTX?

Tak. Załaduj szablon i zapisz w żądanym formacie; formaty POTX/POTM/PPTM i podobne [są obsługiwane](/slides/pl/php-java/supported-file-formats/).

### Jak kontrolować rozmiar/ proporcje slajdu przy tworzeniu prezentacji?

Ustaw [rozmiar slajdu](/slides/pl/php-java/slide-size/) (w tym predefiniowane 4:3 i 16:9 lub własne wymiary) i wybierz, jak ma być skalowana zawartość.

### W jakich jednostkach mierzone są rozmiary i współrzędne?

W punktach: 1 cal równa się 72 jednostkom.

### Jak radzić sobie z bardzo dużymi prezentacjami (z wieloma plikami multimedialnymi), aby zmniejszyć zużycie pamięci?

Użyj [strategii zarządzania BLOB](/slides/pl/php-java/manage-blob/), ogranicz przechowywanie w pamięci poprzez korzystanie z plików tymczasowych i preferuj przepływy oparte na plikach zamiast wyłącznie pamięciowych strumieni.

### Czy mogę tworzyć/zapisywać prezentacje równolegle?

Nie możesz operować na tej samej instancji [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) z [wielu wątków](/slides/pl/php-java/multithreading/). Uruchamiaj oddzielne, izolowane instancje w każdym wątku lub procesie.

### Jak usunąć znak wodny wersji próbnej i ograniczenia?

[Zastosuj licencję](/slides/pl/php-java/licensing/) raz na proces. Plik XML licencji musi pozostać niezmieniony, a konfiguracja licencji powinna być zsynchronizowana, jeśli zaangażowane są wielowątkowość.

### Czy mogę cyfrowo podpisać utworzony PPTX?

Tak. [Podpisy cyfrowe](/slides/pl/php-java/digital-signature-in-powerpoint/) (dodawanie i weryfikacja) są obsługiwane w prezentacjach.

### Czy makra (VBA) są obsługiwane w tworzonych prezentacjach?

Tak. Możesz [tworzyć/edytować projekty VBA](/slides/pl/php-java/presentation-via-vba/) i zapisywać pliki z włączonymi makrami, takie jak PPTM/PPSM.