---
title: Zarządzanie tagami i danymi niestandardowymi w prezentacjach przy użyciu Java
linktitle: Tagi i dane niestandardowe
type: docs
weight: 300
url: /pl/java/managing-tags-and-custom-data/
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
- Java
- Aspose.Slides
description: "Dowiedz się, jak zarządzać tagami i niestandardowymi danymi XML w prezentacjach PowerPoint przy użyciu Aspose.Slides dla Java, w tym dodawanie, odczytywanie, aktualizowanie, audyt i usuwanie niestandardowych części XML."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak Aspose.Slides współpracuje z tagami i danymi niestandardowymi w prezentacjach PowerPoint. Dane specyficzne dla prezentacji mogą być przechowywane jako tagi lub niestandardowe części XML. Tagi są prostymi parami klucz-wartość w postaci łańcucha znaków, podczas gdy niestandardowe części XML mogą przechowywać ustrukturyzowane metadane i specyficzne dla aplikacji ładunki XML.

Aspose.Slides udostępnia interfejsy API do dodawania, odczytywania, aktualizacji, audytu i usuwania niestandardowych części XML na poziomie prezentacji, slajdu i kształtu. Niestandardowe części XML są przydatne w integracjach, które przechowują informacje takie jak identyfikatory systemu zarządzania dokumentami, stan przepływu pracy, metadane zgodności, dane powiązane z szablonem lub inne ustrukturyzowane dane aplikacji wewnątrz prezentacji.

## **Przechowywanie danych w plikach prezentacji**

Pliki PPTX — pliki z rozszerzeniem `.pptx` — są przechowywane w formacie PresentationML, który jest częścią specyfikacji Office Open XML. Office Open XML definiuje strukturę pakietu oraz relacje używane do przechowywania treści prezentacji i powiązanych danych.

Prezentacja zawiera wiele części połączonych relacjami. Na przykład część slajdu zawiera treść pojedynczego slajdu i może mieć explicite określone relacje do innych części zdefiniowane w ISO/IEC 29500.

Dane niestandardowe mogą być przechowywane jako tagi ([ITagCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ITagCollection)) lub niestandardowe części XML ([ICustomXmlPartCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ICustomXmlPartCollection)). Obie są dostępne poprzez interfejs [`ICustomData`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ICustomData/) .

{{% alert color="primary" %}}

Tagi przechowują proste pary klucz-wartość w postaci łańcucha znaków. Niestandardowe części XML przechowują ustrukturyzowane dane XML i mogą być powiązane z prezentacją, slajdem lub kształtem.

{{% /alert %}}

## **Praca z niestandardowymi częściami XML**

Metoda [`ICustomData.getCustomXmlParts()`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ICustomData#getCustomXmlParts--) zwraca kolekcję niestandardowych części XML powiązanych z danym obiektem prezentacji. Na przykład:

- `presentation.getCustomData().getCustomXmlParts()` zawiera niestandardowe części XML powiązane z samą prezentacją.
- `slide.getCustomData().getCustomXmlParts()` zawiera niestandardowe części XML powiązane z określonym slajdem.
- `shape.getCustomData().getCustomXmlParts()` zawiera niestandardowe części XML powiązane z określonym kształtem.

Użyj [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) gdy potrzebujesz przejrzeć wszystkie niestandardowe części XML w prezentacji, niezależnie od tego, z czym są powiązane.

### **Dodanie niestandardowej części XML do prezentacji**

Użyj [`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-) aby dodać dane XML do kolekcji niestandardowych części XML. XML musi być poprawny i niepusty.

Poniższy przykład dodaje ustrukturyzowane metadane do kolekcji danych niestandardowych na poziomie prezentacji:

```java
import com.aspose.slides.*;
import java.util.UUID;

String customXmlContent =
    "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Draft</workflowState>" +
    "</metadata>";

Presentation presentation = new Presentation();
try {
    ICustomXmlPart customXmlPart = presentation.getCustomData().getCustomXmlParts().add(customXmlContent);

    // operacja add przypisuje identyfikator automatycznie. Ustaw konkretny UUID tylko w razie potrzeby.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Metoda `add` może także przyjąć XML jako tablicę bajtów lub strumień wejściowy, co jest przydatne, gdy treść XML jest już dostępna w formie binarnej.

### **Dodanie niestandardowej części XML do slajdu lub kształtu**

Dane XML mogą być powiązane z określonym slajdem lub kształtem zamiast z całą prezentacją. Jest to przydatne, gdy metadane opisują tylko jeden obiekt, np. klucz szablonu, zewnętrzny identyfikator rekordu lub informacje o powiązaniu.

Poniższy przykład dodaje jedną niestandardową część XML do slajdu i drugą do kształtu:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getCustomData().getCustomXmlParts().add(
        "<slideMetadata xmlns=\"urn:example:slides\">" +
            "<templateKey>TitleSlide</templateKey>" +
        "</slideMetadata>");

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 250, 80);

    shape.getTextFrame().setText("Customer data");
    shape.getCustomData().getCustomXmlParts().add(
        "<shapeMetadata xmlns=\"urn:example:shapes\">" +
            "<recordId>CRM-4281</recordId>" +
        "</shapeMetadata>");

    presentation.save("object_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Poziom, na którym część jest dodana, określa, która kolekcja `getCustomData().getCustomXmlParts()` zawiera relację do tej części. Dane na poziomie prezentacji są odpowiednie dla metadanych obejmujących cały dokument, dane na poziomie slajdu dla informacji należących do konkretnego slajdu, a dane na poziomie kształtu dla metadanych powiązanych z pojedynczym kształtem.

### **Wymienianie i audyt wszystkich niestandardowych części XML**

Użyj [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) aby pobrać wszystkie niestandardowe części XML z prezentacji. Każdy [`ICustomXmlPart`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ICustomXmlPart/) udostępnia swój identyfikator, treść XML oraz powiązane schematy przestrzeni nazw.

Poniższy przykład wyświetla wszystkie niestandardowe części XML oraz ich schematy przestrzeni nazw:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ICustomXmlPart customXmlPart : presentation.getAllCustomXmlParts()) {
        System.out.println("ItemId: " + customXmlPart.getItemId());
        System.out.println("XML:");
        System.out.println(customXmlPart.getXmlAsString());

        for (String namespaceSchema : customXmlPart.getNamespaceSchemas()) {
            System.out.println("Namespace schema: " + namespaceSchema);
        }

        System.out.println();
    }
} finally {
    presentation.dispose();
}
```

[`ICustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ICustomXmlPart#getNamespaceSchemas--) zwraca schematy XML powiązane z niestandardową częścią XML. Informacja ta może być przydatna podczas audytu prezentacji zawierających XML generowany przez systemy zewnętrzne.

### **Odczyt i aktualizacja treści XML oraz ItemId**

Użyj [`ICustomXmlPart.getXmlAsString()`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ICustomXmlPart#getXmlAsString--) i [`setXmlAsString()`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ICustomXmlPart#setXmlAsString-java.lang.String-) aby pracować z XML jako łańcuchem UTF‑8, lub [`getXmlData()`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ICustomXmlPart#getXmlData--) i [`setXmlData()`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ICustomXmlPart#setXmlData-byte:A-) aby pracować z surowymi bajtami XML.

Metoda [`ICustomXmlPart.getItemId()`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ICustomXmlPart#getItemId--) zwraca UUID identyfikujący niestandardową część XML w dokumencie Office Open XML. Użyj [`setItemId()`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ICustomXmlPart#setItemId-java.util.UUID-) gdy integracja wymaga nowego identyfikatora.

Poniższy przykład aktualizuje treść XML oraz identyfikator:

```java
import com.aspose.slides.*;
import java.nio.charset.StandardCharsets;
import java.util.UUID;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ICustomXmlPart customXmlPart = presentation.getAllCustomXmlParts()[0];

    // Odczytaj bieżący XML jako tekst.
    String currentXmlContent = customXmlPart.getXmlAsString();
    System.out.println(currentXmlContent);

    // Zaktualizuj XML jako ciąg UTF-8.
    customXmlPart.setXmlAsString(
        "<metadata xmlns=\"urn:example:metadata\">" +
            "<documentId>DOC-1001</documentId>" +
            "<workflowState>Approved</workflowState>" +
        "</metadata>");

    // getXmlData zwraca tę samą treść XML jako surowe bajty.
    byte[] customXmlData = customXmlPart.getXmlData();
    System.out.println(new String(customXmlData, StandardCharsets.UTF_8));

    // Zastąp identyfikator, gdy wymaga tego integracja.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Podczas wywoływania `setXmlAsString` lub `setXmlData` podaj poprawny, niepusty XML. Użyj jednej z reprezentacji w zależności od tego, czy aplikacja pracuje głównie z łańcuchami znaków, czy z danymi bajtowymi.

### **Usuwanie niestandardowej części XML**

Aspose.Slides oferuje kilka sposobów usuwania danych XML:

- [`ICustomXmlPart.remove`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ICustomXmlPart#remove--) usuwa niestandardową część XML z prezentacji.
- [`ICustomXmlPartCollection.remove`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ICustomXmlPartCollection#remove-com.aspose.slides.ICustomXmlPart-) usuwa konkretną część z kolekcji niestandardowych części XML.
- [`ICustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ICustomXmlPartCollection#removeAt-int-) usuwa część o podanym indeksie w kolekcji.
- [`ICustomXmlPartCollection.clear`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ICustomXmlPartCollection#clear--) usuwa wszystkie części z danej kolekcji.

Poniższy przykład usuwa jedną niestandardową część XML na poziomie prezentacji, podając referencję:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ICustomXmlPartCollection customXmlParts = presentation.getCustomData().getCustomXmlParts();

    if (customXmlParts.size() > 0) {
        ICustomXmlPart customXmlPart = customXmlParts.get_Item(0);
        customXmlParts.remove(customXmlPart);
    }

    presentation.save("custom_xml_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Jeśli masz już obiekt `ICustomXmlPart` i chcesz usunąć tę część z prezentacji, a nie z konkretnej kolekcji, wywołaj `customXmlPart.remove()`.

Możesz także usunąć element po indeksie:

```java
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **Usuwanie wszystkich niestandardowych części XML z kolekcji**

Użyj `clear`, gdy wszystkie niestandardowe części XML powiązane z określonym obiektem prezentacji powinny zostać usunięte.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear();

    presentation.save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`clear` wpływa tylko na wybraną kolekcję. Na przykład wyczyszczenie kolekcji slajdu nie usuwa części na poziomie prezentacji ani kształtu.

Aby usunąć każdą niestandardową część XML w prezentacji, przeiteruj `getAllCustomXmlParts()` i usuń każdą część:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ICustomXmlPart customXmlPart : presentation.getAllCustomXmlParts()) {
        customXmlPart.remove();
    }

    presentation.save("all_custom_xml_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Obsługa powiązanych lub współdzielonych niestandardowych części XML**

W prezentacji Office Open XML ta sama niestandardowa część XML może być odwoływana z więcej niż jednego obiektu prezentacji. Na przykład istniejący plik może zawierać relacje z wielu slajdów lub kształtów do tej samej części XML.

Współdzielona część powinna być traktowana jako jeden obiekt danych z wieloma odwołaniami:

- Aktualizacja jej przy użyciu `setXmlAsString`, `setXmlData` lub `setItemId` zmienia podstawową część XML, więc zmiana obowiązuje wszędzie, gdzie część jest odwoływana.
- `getItemId()` może być użyte do identyfikacji tej samej części XML podczas audytu kolekcji na poziomie obiektów.
- Usunięcie części z określonej kolekcji `getCustomXmlParts()` usuwa ją tylko z tej kolekcji. Użyj `ICustomXmlPart.remove()` gdy sama część ma zostać usunięta z prezentacji.
- Przed usunięciem lub zastąpieniem współdzielonej części, sprawdź kolekcje na poziomie obiektów, aby określić, czy inne slajdy lub kształty nadal do niej odwołują się.

Przeciążenia `add` tworzą nową niestandardową część XML z treści XML; nie przyjmują istniejącego `ICustomXmlPart`. Dlatego współdzielone relacje najczęściej występują przy wczytywaniu prezentacji, które już je zawierają.

Poniższy przykład audytuje kolekcje na poziomie prezentacji, slajdu i kształtu według `ItemId` i zgłasza części odwoływane z więcej niż jednego miejsca:

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.UUID;
import java.util.function.BiConsumer;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Map<UUID, List<String>> referencesByItemId = new HashMap<>();

    BiConsumer<String, ICustomXmlPartCollection> registerCustomXmlParts =
        (ownerName, customXmlParts) -> {
            for (int i = 0; i < customXmlParts.size(); i++) {
                ICustomXmlPart customXmlPart = customXmlParts.get_Item(i);
                UUID itemId = customXmlPart.getItemId();

                if (!referencesByItemId.containsKey(itemId)) {
                    referencesByItemId.put(itemId, new ArrayList<>());
                }

                referencesByItemId.get(itemId).add(ownerName);
            }
        };

    registerCustomXmlParts.accept("Presentation", presentation.getCustomData().getCustomXmlParts());

    for (int slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        registerCustomXmlParts.accept("Slide " + (slideIndex + 1), slide.getCustomData().getCustomXmlParts());

        for (int shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            IShape shape = slide.getShapes().get_Item(shapeIndex);
            registerCustomXmlParts.accept("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.getCustomData().getCustomXmlParts());
        }
    }

    for (Map.Entry<UUID, List<String>> referenceEntry : referencesByItemId.entrySet()) {
        if (referenceEntry.getValue().size() > 1) {
            System.out.println("Shared custom XML part: " + referenceEntry.getKey());

            for (String ownerName : referenceEntry.getValue()) {
                System.out.println("  Referenced by: " + ownerName);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Tego typu audyt jest przydatny przed modyfikacją lub usunięciem danych XML w prezentacjach tworzonych przez systemy zewnętrzne, ponieważ ta sama część metadanych może uczestniczyć w więcej niż jednej relacji.

## **Pobieranie wartości tagów**

W slajdach tag odpowiada metodzie `IDocumentProperties.getKeywords()`. Ten fragment kodu pokazuje, jak pobrać wartość tagu przy użyciu Aspose.Slides for Java dla [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    String keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **Dodawanie tagów do prezentacji**

Aspose.Slides umożliwia dodawanie tagów do prezentacji. Tag zazwyczaj składa się z dwóch elementów:

- nazwy własnej właściwości, np. `MyTag`;
- wartości własnej właściwości, np. `My Tag Value`.

Jeśli musisz klasyfikować prezentacje według określonej reguły lub właściwości, możesz dodać odpowiednie tagi. Na przykład, aby kategoryzować prezentacje z krajów Ameryki Północnej, możesz utworzyć tag „NorthAmerican” i przypisać mu nazwę kraju jako wartość.

Ten fragment kodu pokazuje, jak dodać tag do [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation) przy użyciu Aspose.Slides for Java:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ITagCollection tags = presentation.getCustomData().getTags();
    tags.set_Item("MyTag", "My Tag Value");
} finally {
    presentation.dispose();
}
```

Tagi można również ustawić dla [Slide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISlide):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

Lub dla pojedynczego [Shape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IAutoShape):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

### **Ograniczenia**

Tagi dodane poprzez kolekcję `getCustomData().getTags()` są przechowywane wyłącznie w pliku PowerPoint. Nie są **przenoszone** do struktury tagów PDF przy eksporcie prezentacji do PDF. W konsekwencji, niestandardowy identyfikator przypisany jako tag nie może zostać odczytany z otagowanego pliku PDF.

**Obejście**: możesz przechowywać niestandardowy identyfikator w **Alternate Text** obiektu (np. `shape.setAlternativeText("MyId")`). Po eksporcie do PDF, Alternate Text może pojawić się w strukturze tagów PDF.

## **FAQ**

**Czy mogę usunąć wszystkie tagi z prezentacji, slajdu lub kształtu jednocześnie?**

Tak. [Kolekcja tagów](https://reference.aspose.com/slides/pl/java/com.aspose.slides/tagcollection/) obsługuje operację [clear](https://reference.aspose.com/slides/pl/java/com.aspose.slides/tagcollection/#clear--) usuwającą wszystkie pary klucz‑wartość naraz.

**Jak usunąć pojedynczy tag po nazwie bez iteracji po całej kolekcji?**

Użyj [remove(name)](https://reference.aspose.com/slides/pl/java/com.aspose.slides/tagcollection/#remove-java.lang.String-) na [kolekcji tagów](https://reference.aspose.com/slides/pl/java/com.aspose.slides/tagcollection/) aby usunąć tag po jego kluczu.

**Jak pobrać pełną listę nazw tagów w celu analizy lub filtrowania?**

Użyj [getNamesOfTags](https://reference.aspose.com/slides/pl/java/com.aspose.slides/tagcollection/#getNamesOfTags--) na [kolekcji tagów](https://reference.aspose.com/slides/pl/java/com.aspose.slides/tagcollection/); zwróci ona tablicę wszystkich nazw tagów.

**Jak znaleźć wszystkie niestandardowe części XML, niezależnie od miejsca ich przechowywania?**

Użyj [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) aby pobrać wszystkie niestandardowe części XML w prezentacji.

**Czy powinienem używać `getXmlAsString`/`setXmlAsString` czy `getXmlData`/`setXmlData` do aktualizacji niestandardowej części XML?**

Użyj `getXmlAsString` i `setXmlAsString`, gdy aplikacja pracuje z tekstem XML w kodowaniu UTF‑8. Użyj `getXmlData` i `setXmlData`, gdy XML jest już dostępny jako tablica bajtów lub gdy przetwarzanie binarne jest wygodniejsze. Obie reprezentacje odnoszą się do tej samej treści XML niestandardowej części.