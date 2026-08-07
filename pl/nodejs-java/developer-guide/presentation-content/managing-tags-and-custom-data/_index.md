---
title: Zarządzanie tagami i danymi niestandardowymi w prezentacjach przy użyciu JavaScript
linktitle: Tagi i dane niestandardowe
type: docs
weight: 300
url: /pl/nodejs-java/managing-tags-and-custom-data/
keywords:
- właściwości dokumentu
- tag
- dane niestandardowe
- niestandardowy XML
- część niestandardowego XML
- metadane XML
- ItemId
- dodaj tag
- pary wartości
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Dowiedz się, jak zarządzać tagami i niestandardowymi danymi XML w prezentacjach PowerPoint przy użyciu Aspose.Slides dla Node.js via Java, w tym dodawanie, odczyt, aktualizację, audyt i usuwanie niestandardowych części XML."
---
## **Omówienie**

Ten artykuł wyjaśnia, jak Aspose.Slides współpracuje z tagami i danymi niestandardowymi w prezentacjach PowerPoint. Dane specyficzne dla prezentacji mogą być przechowywane jako tagi lub niestandardowe części XML. Tagi są prostymi parami klucz‑wartość w postaci łańcucha znaków, natomiast niestandardowe części XML mogą przechowywać strukturalne metadane i specyficzne dla aplikacji ładunki XML.

Aspose.Slides udostępnia interfejsy API do dodawania, odczytywania, aktualizacji, audytowania i usuwania niestandardowych części XML na poziomach prezentacji, slajdu i kształtu. Niestandardowe części XML są przydatne w integracjach, które przechowują informacje takie jak identyfikatory zarządzania dokumentami, stan przepływu pracy, metadane zgodności, dane wiążące szablon lub inne ustrukturyzowane dane aplikacji wewnątrz prezentacji.

## **Przechowywanie danych w plikach prezentacji**

Pliki PPTX — pliki z rozszerzeniem `.pptx` — są przechowywane w formacie PresentationML, który jest częścią specyfikacji Office Open XML. Office Open XML definiuje strukturę pakietu i relacje używane do przechowywania treści prezentacji oraz powiązanych danych.

Prezentacja zawiera wiele części połączonych relacjami. Na przykład część slajdu zawiera zawartość pojedynczego slajdu i może mieć jawne relacje do innych części zdefiniowane przez ISO/IEC 29500.

Dane niestandardowe mogą być przechowywane jako tagi ([TagCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/tagcollection/)) lub niestandardowe części XML ([CustomXmlPartCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/customxmlpartcollection/)). Obie są dostępne przez klasę [`CustomData`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/customdata/).

{{% alert color="primary" %}}
Tagi przechowują proste pary klucz‑wartość w postaci ciągów znaków. Niestandardowe części XML przechowują ustrukturyzowane dane XML i mogą być powiązane z prezentacją, slajdem lub kształtem.
{{% /alert %}}

## **Praca z niestandardowymi częściami XML**

Metoda `getCustomXmlParts()` klasy [`CustomData`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/customdata/) zwraca kolekcję niestandardowych części XML powiązanych z określonym obiektem prezentacji. Na przykład:

- `presentation.getCustomData().getCustomXmlParts()` zawiera niestandardowe części XML powiązane z samą prezentacją.
- `slide.getCustomData().getCustomXmlParts()` zawiera niestandardowe części XML powiązane z określonym slajdem.
- `shape.getCustomData().getCustomXmlParts()` zawiera niestandardowe części XML powiązane z określonym kształtem.

Użyj [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/), gdy potrzebujesz przeglądnąć wszystkie niestandardowe części XML w prezentacji, niezależnie od tego, z czym są powiązane.

### **Dodanie niestandardowej części XML do prezentacji**

Użyj metody `add` klasy [`CustomXmlPartCollection`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/customxmlpartcollection/), aby dodać dane XML do kolekcji niestandardowych części XML. XML musi być prawidłowy i niepusty.

Poniższy przykład dodaje ustrukturyzowane metadane do kolekcji danych niestandardowych na poziomie prezentacji:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const customXmlContent =
    '<?xml version="1.0" encoding="UTF-8"?>' +
    '<metadata xmlns="urn:example:metadata">' +
        '<documentId>DOC-1001</documentId>' +
        '<workflowState>Draft</workflowState>' +
    '</metadata>';

const presentation = new aspose.slides.Presentation();
try {
    const customXmlPart = presentation.getCustomData().getCustomXmlParts().add(customXmlContent);

    // add automatycznie przypisuje identyfikator. Ustaw określony UUID tylko w razie potrzeby.
    const itemId = java.callStaticMethodSync("java.util.UUID", "randomUUID");
    customXmlPart.setItemId(itemId);

    presentation.save("presentation_with_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Metoda `add` może także przyjmować XML jako tablicę bajtów, co jest przydatne, gdy zawartość XML jest już dostępna w formie binarnej.

### **Dodanie niestandardowej części XML do slajdu lub kształtu**

Dane XML mogą być powiązane z konkretnym slajdem lub kształtem zamiast z całą prezentacją. Jest to przydatne, gdy metadane opisują tylko jeden obiekt, np. klucz szablonu, zewnętrzny identyfikator rekordu lub informacje wiążące.

Poniższy przykład dodaje jedną niestandardową część XML do slajdu i drugą do kształtu:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getCustomData().getCustomXmlParts().add(
        '<slideMetadata xmlns="urn:example:slides">' +
            '<templateKey>TitleSlide</templateKey>' +
        '</slideMetadata>');

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 250, 80);

    shape.getTextFrame().setText("Customer data");
    shape.getCustomData().getCustomXmlParts().add(
        '<shapeMetadata xmlns="urn:example:shapes">' +
            '<recordId>CRM-4281</recordId>' +
        '</shapeMetadata>');

    presentation.save("object_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Poziom, na którym część jest dodawana, określa, która kolekcja `getCustomData().getCustomXmlParts()` zawiera odwołanie do tej części. Dane na poziomie prezentacji są odpowiednie dla metadanych obejmujących cały dokument, dane na poziomie slajdu – dla informacji związanych z określonym slajdem, a dane na poziomie kształtu – dla metadanych powiązanych z pojedynczym kształtem.

### **Wypisanie i audyt wszystkich niestandardowych części XML**

Użyj [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/), aby pobrać wszystkie niestandardowe części XML z prezentacji. Każdy [`CustomXmlPart`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/customxmlpart/) udostępnia swój identyfikator, zawartość XML oraz powiązane schematy przestrzeni nazw.

Poniższy przykład wypisuje wszystkie niestandardowe części XML oraz ich schematy przestrzeni nazw:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getAllCustomXmlParts();

    for (let partIndex = 0; partIndex < customXmlParts.length; partIndex++) {
        const customXmlPart = customXmlParts[partIndex];

        console.log("ItemId: " + customXmlPart.getItemId());
        console.log("XML:");
        console.log(customXmlPart.getXmlAsString());

        const namespaceSchemas = customXmlPart.getNamespaceSchemas();
        for (let schemaIndex = 0; schemaIndex < namespaceSchemas.length; schemaIndex++) {
            console.log("Namespace schema: " + namespaceSchemas[schemaIndex]);
        }

        console.log();
    }
} finally {
    presentation.dispose();
}
```

Metoda [`CustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/customxmlpart/) zwraca schematy XML powiązane z daną częścią. Informacja ta może być przydatna przy audycie prezentacji zawierających XML generowany przez systemy zewnętrzne.

### **Odczyt i aktualizacja zawartości XML oraz ItemId**

Użyj `getXmlAsString()` i `setXmlAsString()` z klasy [`CustomXmlPart`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/customxmlpart/), aby pracować z XML jako łańcuchem UTF‑8, lub `getXmlData()` i `setXmlData()`, aby pracować z surowymi bajtami XML.

Metoda `getItemId()` zwraca UUID identyfikujący niestandardową część XML w dokumencie Office Open XML. Użyj `setItemId()`, gdy integracja wymaga nowego identyfikatora.

Poniższy przykład aktualizuje zawartość XML oraz identyfikator:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlPart = presentation.getAllCustomXmlParts()[0];

    // Odczytaj bieżący XML jako tekst.
    const currentXmlContent = customXmlPart.getXmlAsString();
    console.log(currentXmlContent);

    // Zaktualizuj XML jako ciąg UTF-8.
    customXmlPart.setXmlAsString(
        '<metadata xmlns="urn:example:metadata">' +
            '<documentId>DOC-1001</documentId>' +
            '<workflowState>Approved</workflowState>' +
        '</metadata>');

    // getXmlData dostarcza tę samą zawartość XML jako surowe bajty.
    const customXmlData = customXmlPart.getXmlData();
    console.log(Buffer.from(customXmlData).toString("utf8"));

    // Zastąp identyfikator, gdy wymaga tego integracja.
    const itemId = java.callStaticMethodSync("java.util.UUID", "randomUUID");
    customXmlPart.setItemId(itemId);

    presentation.save("updated_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Podczas wywoływania `setXmlAsString` lub `setXmlData` podawaj prawidłowy, niepusty XML. Wybierz jedną z reprezentacji w zależności od tego, czy aplikacja głównie pracuje z łańcuchami znaków, czy z danymi bajtowymi.

### **Usunięcie niestandardowej części XML**

Aspose.Slides oferuje kilka sposobów usuwania niestandardowych danych XML:

- [`CustomXmlPart.remove`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/customxmlpart/) usuwa niestandardową część XML z prezentacji.
- [`CustomXmlPartCollection.remove`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/customxmlpartcollection/) usuwa określoną część z kolekcji części XML.
- [`CustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/customxmlpartcollection/) usuwa część pod określonym indeksem w kolekcji.
- [`CustomXmlPartCollection.clear`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/customxmlpartcollection/) usuwa wszystkie części z danej kolekcji.

Poniższy przykład usuwa jedną niestandardową część XML na poziomie prezentacji, odwołując się do niej bezpośrednio:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getCustomData().getCustomXmlParts();

    if (customXmlParts.size() > 0) {
        const customXmlPart = customXmlParts.get_Item(0);
        customXmlParts.remove(customXmlPart);
    }

    presentation.save("custom_xml_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Jeśli już masz obiekt `CustomXmlPart` i chcesz usunąć tę część z prezentacji, a nie z konkretnej kolekcji, wywołaj `customXmlPart.remove()`.

Możesz także usunąć element według indeksu:

```javascript
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **Wyczyszczenie wszystkich niestandardowych części XML w kolekcji**

Użyj `clear`, gdy wszystkie niestandardowe części XML powiązane z określonym obiektem prezentacji powinny zostać usunięte.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear();

    presentation.save("slide_custom_xml_cleared.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`clear` wpływa tylko na wybraną kolekcję. Na przykład wyczyszczenie kolekcji slajdu nie usuwa części na poziomie prezentacji ani kształtu.

Aby usunąć każdą niestandardową część XML w prezentacji, przeiteruj `getAllCustomXmlParts()` i usuń każdą część:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getAllCustomXmlParts();

    for (let partIndex = 0; partIndex < customXmlParts.length; partIndex++) {
        customXmlParts[partIndex].remove();
    }

    presentation.save("all_custom_xml_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Obsługa powiązanych lub współdzielonych niestandardowych części XML**

W prezentacji Office Open XML ta sama niestandardowa część XML może być odwoływana z więcej niż jednego obiektu prezentacji. Na przykład istniejący plik może zawierać relacje z wielu slajdów lub kształtów do tej samej części XML.

Współdzielona część powinna być traktowana jako jeden obiekt danych z wieloma odwołaniami:

- Aktualizacja jej za pomocą `setXmlAsString`, `setXmlData` lub `setItemId` zmienia podstawową część XML, więc zmiana obowiązuje wszędzie, gdzie część jest odwoływana.
- `getItemId()` może być użyte do identyfikacji tej samej części XML podczas audytu kolekcji na poziomie obiektów.
- Usunięcie części z konkretnej kolekcji `getCustomXmlParts()` usuwa ją tylko z tej kolekcji. Użyj `CustomXmlPart.remove()`, gdy sama część ma zostać usunięta z prezentacji.
- Przed usunięciem lub zamianą współdzielonej części, sprawdź kolekcje na poziomie obiektów, aby określić, czy inne slajdy lub kształty nadal do niej odwołują.

Przeciążenia `add` tworzą nową niestandardową część XML z podanej zawartości XML; nie przyjmują istniejącego `CustomXmlPart`. Dlatego współdzielone relacje najczęściej występują przy wczytywaniu prezentacji, które już je zawierają.

Poniższy przykład audytuje kolekcje na poziomie prezentacji, slajdu i kształtu według `ItemId` i zgłasza części odwoływane z więcej niż jednego miejsca:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const referencesByItemId = new Map();

    const registerCustomXmlParts = (ownerName, customXmlParts) => {
        for (let partIndex = 0; partIndex < customXmlParts.size(); partIndex++) {
            const customXmlPart = customXmlParts.get_Item(partIndex);
            const itemId = customXmlPart.getItemId().toString();

            if (!referencesByItemId.has(itemId)) {
                referencesByItemId.set(itemId, []);
            }

            referencesByItemId.get(itemId).push(ownerName);
        }
    };

    registerCustomXmlParts("Presentation", presentation.getCustomData().getCustomXmlParts());

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);

        registerCustomXmlParts("Slide " + (slideIndex + 1), slide.getCustomData().getCustomXmlParts());

        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);

            registerCustomXmlParts("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.getCustomData().getCustomXmlParts());
        }
    }

    for (const [itemId, owners] of referencesByItemId) {
        if (owners.length > 1) {
            console.log("Shared custom XML part: " + itemId);

            for (const ownerName of owners) {
                console.log("  Referenced by: " + ownerName);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Tego typu audyt jest przydatny przed modyfikacją lub usunięciem danych XML w prezentacjach utworzonych przez systemy zewnętrzne, ponieważ ta sama część metadanych może uczestniczyć w wielu relacjach.

## **Pobieranie wartości tagów**

W Slides tag odpowiada metodzie `DocumentProperties.getKeywords()`. Ten przykładowy kod pokazuje, jak odczytać wartość tagu przy użyciu Aspose.Slides dla Node.js via Java dla [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **Dodawanie tagów do prezentacji**

Aspose.Slides umożliwia dodawanie tagów do prezentacji. Tag zazwyczaj składa się z dwóch elementów:

- nazwy własnej właściwości, np. `MyTag`;
- wartości własnej właściwości, np. `My Tag Value`.

Jeśli potrzebujesz klasyfikować prezentacje według określonej reguły lub właściwości, możesz dodać odpowiednie tagi. Na przykład, aby kategoryzować prezentacje z krajów Ameryki Północnej, możesz utworzyć tag „NorthAmerican” i przypisać jako wartość odpowiedni kraj.

Ten przykładowy kod pokazuje, jak dodać tag do [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) przy użyciu Aspose.Slides dla Node.js via Java:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const tags = presentation.getCustomData().getTags();
    tags.set_Item("MyTag", "My Tag Value");
} finally {
    presentation.dispose();
}
```

Tagi można także ustawić dla [Slide](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slide/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

Lub dla pojedynczego [Shape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 50);

    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

### **Ograniczenia**

Tagi dodane poprzez kolekcję `getCustomData().getTags()` są przechowywane wyłącznie w pliku PowerPoint. Nie są **przenoszone** do struktury tagów PDF podczas eksportu prezentacji do PDF. W konsekwencji niestandardowy identyfikator przypisany jako tag nie może zostać odczytany z otagowanego pliku PDF.

**Obejście**: Możesz przechowywać niestandardowy identyfikator w **Alt Text** obiektu (np. `shape.setAlternativeText("MyId")`). Po eksporcie do PDF tekst alternatywny może pojawić się w strukturze tagów PDF.

## **FAQ**

**Czy mogę usunąć wszystkie tagi z prezentacji, slajdu lub kształtu w jednej operacji?**

Tak. [Kolekcja tagów](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/tagcollection/) obsługuje operację [clear](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/tagcollection/), która usuwa wszystkie pary klucz‑wartość jednocześnie.

**Jak usunąć pojedynczy tag po nazwie bez iteracji po całej kolekcji?**

Użyj `remove(name)` na [kolekcji tagów](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/tagcollection/), aby usunąć tag po jego kluczu.

**Jak pobrać pełną listę nazw tagów w celach analitycznych lub filtrowania?**

Użyj `getNamesOfTags()` na [kolekcji tagów](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/tagcollection/); metoda zwraca tablicę wszystkich nazw tagów.

**Jak znaleźć wszystkie niestandardowe części XML niezależnie od miejsca ich przechowywania?**

Użyj [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/), aby pobrać wszystkie niestandardowe części XML w prezentacji.

**Czy powinienem używać `getXmlAsString`/`setXmlAsString` czy `getXmlData`/`setXmlData` do aktualizacji niestandardowej części XML?**

Użyj `getXmlAsString` i `setXmlAsString`, gdy aplikacja pracuje z tekstem XML w kodowaniu UTF‑8. Użyj `getXmlData` i `setXmlData`, gdy XML jest już dostępny jako tablica bajtów lub gdy przetwarzanie binarne jest wygodniejsze. Obie pary metod odnoszą się do tej samej zawartości XML danej niestandardowej części.