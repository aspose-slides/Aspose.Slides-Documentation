---
title: Zarządzanie tagami i danymi niestandardowymi w prezentacjach przy użyciu PHP
linktitle: Tagi i dane niestandardowe
type: docs
weight: 300
url: /pl/php-java/managing-tags-and-custom-data/
keywords:
- właściwości dokumentu
- tag
- dane niestandardowe
- niestandardowy XML
- niestandardowa część XML
- metadane XML
- ItemId
- dodaj tag
- pary wartości
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Dowiedz się, jak zarządzać tagami i niestandardowymi danymi XML w prezentacjach PowerPoint przy użyciu Aspose.Slides dla PHP via Java, w tym dodawanie, odczytywanie, aktualizowanie, audyt i usuwanie niestandardowych części XML."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak Aspose.Slides współpracuje z tagami i danymi niestandardowymi w prezentacjach PowerPoint. Dane specyficzne dla prezentacji mogą być przechowywane jako tagi lub niestandardowe części XML. Tagi to proste pary klucz-wartość w formie łańcucha znaków, natomiast niestandardowe części XML mogą przechowywać strukturalne metadane i specyficzne dla aplikacji ładunki XML.

Aspose.Slides udostępnia API do dodawania, odczytywania, aktualizacji, audytowania i usuwania niestandardowych części XML na poziomie prezentacji, slajdu i kształtu. Niestandardowe części XML są przydatne w integracjach, które przechowują informacje takie jak identyfikatory systemów zarządzania dokumentami, stan przepływu pracy, metadane zgodności, dane powiązane z szablonem lub inne ustrukturyzowane dane aplikacyjne wewnątrz prezentacji.

## **Przechowywanie danych w plikach prezentacji**

Pliki PPTX — pliki z rozszerzeniem `.pptx` — są przechowywane w formacie PresentationML, będącym częścią specyfikacji Office Open XML. Office Open XML definiuje strukturę pakietu i relacje używane do przechowywania zawartości prezentacji oraz powiązanych danych.

Prezentacja zawiera wiele części połączonych relacjami. Na przykład część slajdu zawiera treść jednego slajdu i może mieć jawne relacje do innych części zgodnie z ISO/IEC 29500.

Dane niestandardowe mogą być przechowywane jako tagi ([TagCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/tagcollection/)) lub niestandardowe części XML ([CustomXmlPartCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/customxmlpartcollection/)). Oba są dostępne poprzez klasę [`CustomData`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/customdata/).

{{% alert color="primary" %}}
Tagi przechowują proste pary klucz‑wartość w formie łańcucha znaków. Niestandardowe części XML przechowują strukturalne dane XML i mogą być powiązane z prezentacją, slajdem lub kształtem.
{{% /alert %}}

## **Praca z niestandardowymi częściami XML**

Metoda [`CustomData::getCustomXmlParts()`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/customdata/#getCustomXmlParts) zwraca kolekcję niestandardowych części XML powiązanych z określonym obiektem prezentacji. Na przykład:

- `$presentation->getCustomData()->getCustomXmlParts()` zawiera niestandardowe części XML powiązane z samą prezentacją.
- `$slide->getCustomData()->getCustomXmlParts()` zawiera niestandardowe części XML powiązane z konkretnym slajdem.
- `$shape->getCustomData()->getCustomXmlParts()` zawiera niestandardowe części XML powiązane z konkretnym kształtem.

Użyj [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#getAllCustomXmlParts), gdy potrzebujesz przejrzeć wszystkie niestandardowe części XML w prezentacji, niezależnie od tego, z czym są powiązane.

### **Dodanie niestandardowej części XML do prezentacji**

Użyj [`CustomXmlPartCollection::add`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/customxmlpartcollection/#add), aby dodać dane XML do kolekcji niestandardowych części XML. XML musi być prawidłowy i niepusty.

Poniższy przykład dodaje ustrukturyzowane metadane do kolekcji danych niestandardowych na poziomie prezentacji:

```php
$customXmlContent =
    '<?xml version="1.0" encoding="UTF-8"?>' .
    '<metadata xmlns="urn:example:metadata">' .
        '<documentId>DOC-1001</documentId>' .
        '<workflowState>Draft</workflowState>' .
    '</metadata>';

$presentation = new Presentation();
try {
    $customXmlPart = $presentation->getCustomData()->getCustomXmlParts()->add($customXmlContent);

    // add automatycznie przypisuje identyfikator. Ustaw konkretny UUID tylko w razie potrzeby.
    $UUID = new JavaClass("java.util.UUID");
    $customXmlPart->setItemId($UUID->randomUUID());

    $presentation->save("presentation_with_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Metoda `add` może również przyjmować XML jako tablicę bajtów lub strumień wejściowy, co jest przydatne, gdy zawartość XML jest już dostępna w formie binarnej.

### **Dodanie niestandardowej części XML do slajdu lub kształtu**

Dane XML mogą być powiązane z konkretnym slajdem lub kształtem zamiast z całą prezentacją. Jest to przydatne, gdy metadane opisują tylko jeden obiekt, np. klucz szablonu, zewnętrzny identyfikator rekordu lub informacje o powiązaniu.

Poniższy przykład dodaje jedną niestandardową część XML do slajdu i drugą do kształtu:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getCustomData()->getCustomXmlParts()->add(
        '<slideMetadata xmlns="urn:example:slides">' .
            '<templateKey>TitleSlide</templateKey>' .
        '</slideMetadata>'
    );

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 250, 80);

    $shape->getTextFrame()->setText("Customer data");
    $shape->getCustomData()->getCustomXmlParts()->add(
        '<shapeMetadata xmlns="urn:example:shapes">' .
            '<recordId>CRM-4281</recordId>' .
        '</shapeMetadata>'
    );

    $presentation->save("object_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Poziom, na którym część jest dodana, określa, która kolekcja `getCustomData()->getCustomXmlParts()` zawiera relację do tej części. Dane na poziomie prezentacji są odpowiednie dla metadanych obejmujących cały dokument, dane na poziomie slajdu dla informacji przypisanych konkretnemu slajdowi, a dane na poziomie kształtu dla metadanych powiązanych z pojedynczym kształtem.

### **Wyświetlenie i audyt wszystkich niestandardowych części XML**

Użyj [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#getAllCustomXmlParts), aby pobrać wszystkie niestandardowe części XML z prezentacji. Każdy [`CustomXmlPart`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/customxmlpart/) udostępnia swój identyfikator, zawartość XML oraz powiązane schematy przestrzeni nazw.

Poniższy przykład wymienia wszystkie niestandardowe części XML i ich schematy przestrzeni nazw:

```php
$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getAllCustomXmlParts() as $customXmlPart) {
        echo "ItemId: " . $customXmlPart->getItemId() . PHP_EOL;
        echo "XML:" . PHP_EOL;
        echo $customXmlPart->getXmlAsString() . PHP_EOL;

        foreach ($customXmlPart->getNamespaceSchemas() as $namespaceSchema) {
            echo "Namespace schema: " . $namespaceSchema . PHP_EOL;
        }

        echo PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

[`CustomXmlPart::getNamespaceSchemas()`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/customxmlpart/#getNamespaceSchemas) zwraca schematy XML powiązane z niestandardową częścią XML. Informacja ta może być przydatna przy audytowaniu prezentacji zawierających XML generowany przez systemy zewnętrzne.

### **Odczyt i aktualizacja treści XML oraz ItemId**

Użyj [`CustomXmlPart::getXmlAsString()`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/customxmlpart/#getXmlAsString) i [`setXmlAsString()`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/customxmlpart/#setXmlAsString), aby pracować z XML jako ciągiem UTF‑8, lub [`getXmlData()`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/customxmlpart/#getXmlData) i [`setXmlData()`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/customxmlpart/#setXmlData), aby pracować z surowymi bajtami XML.

Metoda [`CustomXmlPart::getItemId()`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/customxmlpart/#getItemId) zwraca UUID identyfikujący niestandardową część XML w dokumencie Office Open XML. Użyj [`setItemId()`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/customxmlpart/#setItemId), gdy integracja wymaga nowego identyfikatora.

Poniższy przykład aktualizuje zawartość XML oraz identyfikator:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $customXmlPart = $presentation->getAllCustomXmlParts()[0];

    // Odczytaj bieżący XML jako tekst.
    $currentXmlContent = $customXmlPart->getXmlAsString();
    echo $currentXmlContent . PHP_EOL;

    // Zaktualizuj XML jako ciąg UTF-8.
    $customXmlPart->setXmlAsString(
        '<metadata xmlns="urn:example:metadata">' .
            '<documentId>DOC-1001</documentId>' .
            '<workflowState>Approved</workflowState>' .
        '</metadata>'
    );

    // getXmlData dostarcza tę samą zawartość XML w postaci surowych bajtów.
    $customXmlData = $customXmlPart->getXmlData();

    // Zastąp identyfikator, gdy wymaga tego integracja.
    $UUID = new JavaClass("java.util.UUID");
    $customXmlPart->setItemId($UUID->randomUUID());

    $presentation->save("updated_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Przy wywoływaniu `setXmlAsString` lub `setXmlData` podawaj prawidłowy, niepusty XML. Użyj jednej reprezentacji albo drugiej w zależności od tego, czy aplikacja głównie pracuje z łańcuchami, czy z danymi bajtowymi.

### **Usunięcie niestandardowej części XML**

Aspose.Slides oferuje kilka sposobów usunięcia niestandardowych danych XML:

- [`CustomXmlPart::remove`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/customxmlpart/#remove) usuwa niestandardową część XML z prezentacji.
- [`CustomXmlPartCollection::remove`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/customxmlpartcollection/#remove) usuwa konkretną część z kolekcji niestandardowych części XML.
- [`CustomXmlPartCollection::removeAt`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/customxmlpartcollection/#removeAt) usuwa część o określonym indeksie w kolekcji.
- [`CustomXmlPartCollection::clear`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/customxmlpartcollection/#clear) usuwa wszystkie części z danej kolekcji.

Poniższy przykład usuwa jedną niestandardową część XML na poziomie prezentacji, odwołując się do niej bezpośrednio:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $customXmlParts = $presentation->getCustomData()->getCustomXmlParts();

    if (java_values($customXmlParts->size()) > 0) {
        $customXmlPart = $customXmlParts->get_Item(0);
        $customXmlParts->remove($customXmlPart);
    }

    $presentation->save("custom_xml_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Jeśli masz już obiekt `CustomXmlPart` i chcesz usunąć tę część z prezentacji, a nie z konkretnej kolekcji, wywołaj `$customXmlPart->remove()`.

Możesz także usunąć element według indeksu:

```php
$presentation->getCustomData()->getCustomXmlParts()->removeAt(0);
```

### **Wyczyść wszystkie niestandardowe części XML w kolekcji**

Użyj `clear`, gdy wszystkie niestandardowe części XML powiązane z danym obiektem prezentacji mają zostać usunięte.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getSlides()->get_Item(0)->getCustomData()->getCustomXmlParts()->clear();

    $presentation->save("slide_custom_xml_cleared.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`clear` wpływa tylko na wybraną kolekcję. Na przykład wyczyszczenie kolekcji slajdu nie usuwa części na poziomie prezentacji ani kształtu.

Aby usunąć każdą niestandardową część XML w prezentacji, iteruj po `getAllCustomXmlParts()` i usuń każdą część:

```php
$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getAllCustomXmlParts() as $customXmlPart) {
        $customXmlPart->remove();
    }

    $presentation->save("all_custom_xml_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Obsługa powiązanych lub współdzielonych niestandardowych części XML**

W prezentacji Office Open XML ta sama niestandardowa część XML może być odwoływana z więcej niż jednego obiektu prezentacji. Na przykład istniejący plik może zawierać relacje z wielu slajdów lub kształtów do tej samej podstawowej części XML.

Współdzielona część powinna być traktowana jako pojedynczy obiekt danych z wieloma odwołaniami:

- Aktualizacja przy użyciu `setXmlAsString`, `setXmlData` lub `setItemId` zmienia podstawową część XML, więc zmiana obowiązuje wszędzie, gdzie część jest referencjonowana.
- `getItemId()` może być użyte do identyfikacji tej samej części XML podczas audytu kolekcji na poziomie obiektów.
- Usunięcie części z konkretnej kolekcji `getCustomXmlParts()` usuwa ją tylko z tej kolekcji. Użyj `CustomXmlPart::remove()` gdy cała część ma zostać usunięta z prezentacji.
- Przed usunięciem lub zamianą współdzielonej części, sprawdź kolekcje na poziomie obiektów, aby ustalić, czy inne slajdy lub kształty nadal do niej odwołują się.

Przeciążenia `add` tworzą nową niestandardową część XML z treści XML; nie przyjmują istniejącego `CustomXmlPart`. Dlatego współdzielone relacje najczęściej występują przy ładowaniu prezentacji, które już je zawierają.

Poniższy przykład audytuje kolekcje na poziomie prezentacji, slajdu i kształtu według `ItemId` i raportuje części odwoływane z więcej niż jednego miejsca:

```php
function registerCustomXmlParts($ownerName, $customXmlParts, &$referencesByItemId) {
    $partCount = java_values($customXmlParts->size());

    for ($i = 0; $i < $partCount; $i++) {
        $customXmlPart = $customXmlParts->get_Item($i);
        $itemId = java_values($customXmlPart->getItemId()->toString());

        if (!isset($referencesByItemId[$itemId])) {
            $referencesByItemId[$itemId] = [];
        }

        $referencesByItemId[$itemId][] = $ownerName;
    }
}

$presentation = new Presentation("presentation.pptx");
try {
    $referencesByItemId = [];

    registerCustomXmlParts(
        "Presentation",
        $presentation->getCustomData()->getCustomXmlParts(),
        $referencesByItemId
    );

    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        registerCustomXmlParts(
            "Slide " . ($slideIndex + 1),
            $slide->getCustomData()->getCustomXmlParts(),
            $referencesByItemId
        );

        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            registerCustomXmlParts(
                "Slide " . ($slideIndex + 1) . ", shape " . $shapeIndex,
                $shape->getCustomData()->getCustomXmlParts(),
                $referencesByItemId
            );
        }
    }

    foreach ($referencesByItemId as $itemId => $owners) {
        if (count($owners) > 1) {
            echo "Shared custom XML part: " . $itemId . PHP_EOL;

            foreach ($owners as $ownerName) {
                echo "  Referenced by: " . $ownerName . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Ten typ audytu jest przydatny przed modyfikacją lub usunięciem danych XML w prezentacjach tworzonych przez systemy zewnętrzne, ponieważ ta sama część metadanych może uczestniczyć w więcej niż jednej relacji.

## **Pobieranie wartości tagów**

W slides tag odpowiada metodzie `DocumentProperties::getKeywords()`. Ten przykładowy kod pokazuje, jak uzyskać wartość taga przy użyciu Aspose.Slides for PHP via Java dla [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/):

```php
$presentation = new Presentation("presentation.pptx");
try {
    $keywords = $presentation->getDocumentProperties()->getKeywords();
} finally {
    $presentation->dispose();
}
```

## **Dodawanie tagów do prezentacji**

Aspose.Slides umożliwia dodawanie tagów do prezentacji. Tag zazwyczaj składa się z dwóch elementów:

- nazwy własności niestandardowej, na przykład `MyTag`;
- wartości własności niestandardowej, na przykład `My Tag Value`.

Jeśli potrzebujesz klasyfikować prezentacje według określonej reguły lub własności, możesz dodać odpowiednie tagi. Na przykład, aby kategoryzować prezentacje z krajów Ameryki Północnej, możesz utworzyć tag „NorthAmerican” i przypisać jako wartość odpowiedni kraj.

Ten przykładowy kod pokazuje, jak dodać tag do [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) przy użyciu Aspose.Slides for PHP via Java:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $tags = $presentation->getCustomData()->getTags();
    $tags->set_Item("MyTag", "My Tag Value");
} finally {
    $presentation->dispose();
}
```

Tagi można także ustawić dla [Slide](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slide/):

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getCustomData()->getTags()->set_Item("tag", "value");
} finally {
    $presentation->dispose();
}
```

Lub dla pojedynczego [Shape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/):

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 50);
    $shape->getTextFrame()->setText("My text");
    $shape->getCustomData()->getTags()->set_Item("tag", "value");
} finally {
    $presentation->dispose();
}
```

### **Ograniczenia**

Tagi dodane poprzez kolekcję `getCustomData()->getTags()` są przechowywane wyłącznie w pliku PowerPoint. Nie są **przenoszone** do struktury tagów PDF podczas eksportu prezentacji do PDF. W konsekwencji niestandardowy identyfikator przypisany jako tag nie może być odczytany z otagowanego PDF‑a.

**Rozwiązanie**: Możesz przechowywać niestandardowy identyfikator w **Alt Text** obiektu (np. `$shape->setAlternativeText("MyId")`). Po eksporcie do PDF tekst alternatywny może pojawić się w strukturze tagów PDF.

## **FAQ**

**Czy mogę usunąć wszystkie tagi z prezentacji, slajdu lub kształtu w jednej operacji?**

Tak. Kolekcja [tagów](https://reference.aspose.com/slides/pl/php-java/aspose.slides/tagcollection/) obsługuje operację [clear](https://reference.aspose.com/slides/pl/php-java/aspose.slides/tagcollection/#clear), która jednocześnie usuwa wszystkie pary klucz‑wartość.

**Jak usunąć pojedynczy tag po jego nazwie, nie iterując całej kolekcji?**

Użyj `remove(name)` na [kolekcji tagów](https://reference.aspose.com/slides/pl/php-java/aspose.slides/tagcollection/), aby usunąć tag po kluczu.

**Jak pobrać pełną listę nazw tagów w celach analitycznych lub filtrowania?**

Użyj `getNamesOfTags` na [kolekcji tagów](https://reference.aspose.com/slides/pl/php-java/aspose.slides/tagcollection/); metoda zwraca tablicę wszystkich nazw tagów.

**Jak znaleźć wszystkie niestandardowe części XML, niezależnie od miejsca ich przechowywania?**

Użyj [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#getAllCustomXmlParts), aby pobrać wszystkie niestandardowe części XML w prezentacji.

**Czy powinienem używać `getXmlAsString`/`setXmlAsString` czy `getXmlData`/`setXmlData` do aktualizacji niestandardowej części XML?**

Używaj `getXmlAsString` i `setXmlAsString`, gdy aplikacja pracuje z tekstem XML w formacie UTF‑8. Używaj `getXmlData` i `setXmlData`, gdy XML jest już dostępny jako tablica bajtów lub gdy wygodniejsze jest przetwarzanie binarne. Obie reprezentacje odnoszą się do tej samej zawartości XML niestandardowej części.