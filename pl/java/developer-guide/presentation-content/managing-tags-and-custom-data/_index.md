---
title: Zarządzanie tagami i danymi niestandardowymi w prezentacjach przy użyciu Javy
linktitle: Tagi i dane niestandardowe
type: docs
weight: 300
url: /pl/java/managing-tags-and-custom-data/
keywords:
- właściwości dokumentu
- znacznik
- dane niestandardowe
- niestandardowy XML
- niestandardowa część XML
- metadane XML
- ItemId
- dodaj znacznik
- pary wartości
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Dowiedz się, jak zarządzać tagami i niestandardowymi danymi XML w prezentacjach PowerPoint przy użyciu Aspose.Slides for Java, w tym jak dodawać, odczytywać, aktualizować, audytować i usuwać niestandardowe części XML."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak Aspose.Slides działa z tagami i danymi niestandardowymi w prezentacjach PowerPoint. Dane specyficzne dla prezentacji mogą być przechowywane jako tagi lub niestandardowe części XML. Tagi są prostymi parami klucz‑wartość w postaci ciągów znaków, natomiast niestandardowe części XML mogą przechowywać strukturalne metadane i ładunki XML specyficzne dla aplikacji.

Aspose.Slides udostępnia interfejsy API do dodawania, odczytywania, aktualizowania, audytowania i usuwania niestandardowych części XML na poziomach prezentacji, slajdu i kształtu. Niestandardowe części XML są przydatne w integracjach, które przechowują informacje takie jak identyfikatory zarządzania dokumentami, stan przepływu pracy, metadane zgodności, dane wiązania szablonu lub inne strukturalne dane aplikacji wewnątrz prezentacji.

## **Przechowywanie danych w plikach prezentacji**

Pliki PPTX — pliki z rozszerzeniem `.pptx` — są przechowywane w formacie PresentationML, który jest częścią specyfikacji Office Open XML. Office Open XML definiuje strukturę pakietu i relacje używane do przechowywania treści prezentacji oraz powiązanych danych.

Prezentacja zawiera wiele części połączonych relacjami. Na przykład część slajdu zawiera treść pojedynczego slajdu i może mieć jawne relacje do innych części określonych przez ISO/IEC 29500.

Dane niestandardowe mogą być przechowywane jako tagi ([ITagCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ITagCollection)) lub niestandardowe części XML ([ICustomXmlPartCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ICustomXmlPartCollection)). Oba są dostępne przez interfejs [`ICustomData`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ICustomData/) .

{{% alert color="info" %}}
Tagi przechowują proste pary klucz‑wartość typu string. Niestandardowe części XML przechowują strukturalne dane XML i mogą być powiązane z prezentacją, slajdem lub kształtem.
{{% /alert %}}

## **Praca z niestandardowymi częściami XML**

Metoda [`ICustomData.getCustomXmlParts()`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ICustomData#getCustomXmlParts--) zwraca kolekcję niestandardowych części XML powiązanych z określonym obiektem prezentacji. Przykłady:

- `presentation.getCustomData().getCustomXmlParts()` zawiera niestandardowe części XML powiązane z samą prezentacją.
- `slide.getCustomData().getCustomXmlParts()` zawiera niestandardowe części XML powiązane z konkretnym slajdem.
- `shape.getCustomData().getCustomXmlParts()` zawiera niestandardowe części XML powiązane z konkretnym kształtem.

Użyj [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) kiedy potrzebujesz przeglądnąć wszystkie niestandardowe części XML w prezentacji, niezależnie od tego, z czym są powiązane.

### **Dodaj niestandardową część XML do prezentacji**

Użyj [`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-) aby dodać dane XML do kolekcji niestandardowych części XML. XML musi być poprawny i niepusty.

Poniższy przykład dodaje strukturalne metadane do kolekcji danych niestandardowych na poziomie prezentacji:

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

    // add przypisuje identyfikator automatycznie. Ustaw konkretny UUID tylko w razie potrzeby.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Metoda `add` może także przyjmować XML jako tablicę bajtów lub strumień wejściowy, co jest przydatne, gdy treść XML jest już dostępna w formie binarnej.

### **Dodaj niestandardową część XML do slajdu lub kształtu**

Dane XML mogą być powiązane z konkretnym slajdem lub kształtem zamiast z całą prezentacją. Jest to przydatne, gdy metadane opisują tylko jeden obiekt, np. klucz szablonu, zewnętrzny identyfikator rekordu lub informacje o powiązaniu.

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

Poziom, na którym część jest dodana, decyduje, której kolekcji `getCustomData().getCustomXmlParts()` zawiera odniesienie do tej części. Dane na poziomie prezentacji są odpowiednie dla metadanych obejmujących cały dokument, dane na poziomie slajdu dla informacji należących do konkretnego slajdu, a dane na poziomie kształtu dla metadanych związanych z pojedynczym kształtem.

### **Wypisz i audytuj wszystkie niestandardowe części XML**

Użyj [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) aby pobrać wszystkie niestandardowe części XML z prezentacji. Każdy [`ICustomXmlPart`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ICustomXmlPart/) udostępnia swój identyfikator, treść XML oraz powiązane schematy przestrzeni nazw.

Poniższy przykład wypisuje wszystkie niestandardowe części XML i ich schematy przestrzeni nazw:

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

[`ICustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ICustomXmlPart#getNamespaceSchemas--) zwraca schematy XML powiązane z niestandardową częścią XML. Informacje te mogą być przydatne przy audycie prezentacji zawierających XML generowany przez systemy zewnętrzne.

### **Odczyt i aktualizacja treści XML oraz ItemId**

Użyj [`ICustomXmlPart.getXmlAsString()`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ICustomXmlPart#getXmlAsString--) i [`setXmlAsString()`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ICustomXmlPart#setXmlAsString-java.lang.String-) aby pracować z XML jako łańcuchem UTF‑8, lub [`getXmlData()`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ICustomXmlPart#getXmlData--) i [`setXmlData()`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ICustomXmlPart#setXmlData-byte:A-) aby pracować z surowymi bajtami XML.

Metoda [`ICustomXmlPart.getItemId()`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ICustomXmlPart#getItemId--) zwraca UUID identyfikujący niestandardową część XML w dokumencie Office Open XML. Użyj [`setItemId()`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ICustomXmlPart#setItemId-java.util.UUID-) gdy integracja wymaga nowego identyfikatora.

Poniższy przykład aktualizuje treść XML i identyfikator:

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

    // Zaktualizuj XML jako łańcuch UTF-8.
    customXmlPart.setXmlAsString(
        "<metadata xmlns=\"urn:example:metadata\">" +
            "<documentId>DOC-1001</documentId>" +
            "<workflowState>Approved</workflowState>" +
        "</metadata>");

    // getXmlData zwraca tę samą zawartość XML jako surowe bajty.
    byte[] customXmlData = customXmlPart.getXmlData();
    System.out.println(new String(customXmlData, StandardCharsets.UTF_8));

    // Zastąp identyfikator, gdy jest wymagany przez integrację.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Podczas wywoływania `setXmlAsString` lub `setXmlData` należy podać poprawny, niepusty XML. Użyj jednej z reprezentacji w zależności od tego, czy aplikacja pracuje głównie z łańcuchami znaków, czy z danymi bajtowymi.

### **Usuń niestandardową część XML**

Aspose.Slides oferuje kilka sposobów usuwania danych XML:

- [`ICustomXmlPart.remove`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ICustomXmlPart#remove--) usuwa niestandardową część XML z prezentacji.
- [`ICustomXmlPartCollection.remove`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ICustomXmlPartCollection#remove-com.aspose.slides.ICustomXmlPart-) usuwa określoną część z kolekcji niestandardowych części XML.
- [`ICustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ICustomXmlPartCollection#removeAt-int-) usuwa część znajdującą się pod podanym indeksem kolekcji.
- [`ICustomXmlPartCollection.clear`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ICustomXmlPartCollection#clear--) usuwa wszystkie części z określonej kolekcji.

Poniższy przykład usuwa jedną niestandardową część XML na poziomie prezentacji przy użyciu referencji:

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

Jeśli już posiadasz obiekt `ICustomXmlPart` i chcesz usunąć tę część z prezentacji, a nie z konkretnej kolekcji, wywołaj `customXmlPart.remove()`.

Możesz także usunąć element po indeksie:

```java
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **Wyczyść wszystkie niestandardowe części XML w kolekcji**

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

Aby usunąć każdą niestandardową część XML w prezentacji, iteruj po `getAllCustomXmlParts()` i usuń każdą część:

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

### **Obsługa powiązanych lub współdzielonych części XML**

W prezentacji Office Open XML ta sama niestandardowa część XML może być odwoływana z więcej niż jednego obiektu prezentacji. Przykładowo istniejący plik może zawierać relacje z wielu slajdów lub kształtów do tej samej części XML.

Współdzielona część powinna być traktowana jako jeden obiekt danych z wieloma odwołaniami:

- Aktualizacja jej za pomocą `setXmlAsString`, `setXmlData` lub `setItemId` zmienia bazową część XML, więc zmiana objawia się wszędzie, gdzie część jest odwoływana.
- `getItemId()` może być użyte do identyfikacji tej samej części XML podczas audytu kolekcji na poziomie obiektów.
- Usunięcie części z konkretnej kolekcji `getCustomXmlParts()` usuwa ją tylko z tej kolekcji. Użyj `ICustomXmlPart.remove()` gdy sama część ma zostać usunięta z prezentacji.
- Przed usunięciem lub zastąpieniem współdzielonej części, sprawdź kolekcje na poziomie obiektów, aby określić, czy inne slajdy lub kształty nadal do niej odwołują się.

Przeciążenia `add` tworzą nową niestandardową część XML z treści XML; nie przyjmują istniejącego `ICustomXmlPart`. Dlatego współdzielone relacje najczęściej występują przy ładowaniu prezentacji, które już je zawierają.

Poniższy przykład audytuje kolekcje na poziomie prezentacji, slajdu i kształtu według `ItemId` i raportuje części odwoływane z więcej niż jednego miejsca:

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

Ten typ audytu jest przydatny przed modyfikacją lub usunięciem danych XML w prezentacjach tworzonych przez systemy zewnętrzne, ponieważ ta sama część metadanych może uczestniczyć w wielu relacjach.

## **Pobieranie wartości tagów**

W slajdach tag odpowiada metodzie `IDocumentProperties.getKeywords()`. Ten przykładowy kod pokazuje, jak pobrać wartość tagu przy użyciu Aspose.Slides for Java dla [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation):

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

- nazwy właściwości niestandardowej, np. `MyTag`;
- wartości właściwości niestandardowej, np. `My Tag Value`.

Jeśli musisz klasyfikować prezentacje według określonej reguły lub właściwości, możesz dodać odpowiednie tagi. Przykładowo, aby kategoryzować prezentacje z krajów Ameryki Północnej, możesz utworzyć tag „NorthAmerican” i przypisać jako wartość odpowiedni kraj.

Ten przykładowy kod pokazuje, jak dodać tag do [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation) przy użyciu Aspose.Slides for Java:

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

Tagi mogą być również ustawiane dla [Slide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISlide):

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

lub dla pojedynczego [Shape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IAutoShape):

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

Tagi dodane przez kolekcję `getCustomData().getTags()` są przechowywane wyłącznie w pliku PowerPoint. Nie są **przenoszone** do struktury tagów PDF podczas eksportu prezentacji do PDF. W konsekwencji niestandardowy identyfikator zapisany jako tag nie może być odczytany z otagowanego pliku PDF.

**Obejście**: możesz przechowywać niestandardowy identyfikator w **Alternatywnym tekście** obiektu (np. `shape.setAlternativeText("MyId")`). Po eksporcie do PDF alternatywny tekst może pojawić się w strukturze tagów PDF.

## **FAQ**

**Czy mogę usunąć wszystkie tagi z prezentacji, slajdu lub kształtu w jednej operacji?**

Tak. Kolekcja [tagów](https://reference.aspose.com/slides/pl/java/com.aspose.slides/tagcollection/) obsługuje operację [clear](https://reference.aspose.com/slides/pl/java/com.aspose.slides/tagcollection/#clear--) usuwającą wszystkie pary klucz‑wartość jednocześnie.

**Jak usunąć pojedynczy tag po nazwie, bez iteracji po całej kolekcji?**

Użyj `remove(name)` na [kolekcji tagów](https://reference.aspose.com/slides/pl/java/com.aspose.slides/tagcollection/) aby usunąć tag po jego kluczu.

**Jak uzyskać pełną listę nazw tagów w celu analizy lub filtrowania?**

Użyj `getNamesOfTags` na [kolekcji tagów](https://reference.aspose.com/slides/pl/java/com.aspose.slides/tagcollection/); metoda zwraca tablicę wszystkich nazw tagów.

**Jak znaleźć wszystkie niestandardowe części XML, niezależnie od miejsca ich przechowywania?**

Użyj [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) aby pobrać wszystkie niestandardowe części XML w prezentacji.

**Czy powinienem używać `getXmlAsString`/`setXmlAsString` czy `getXmlData`/`setXmlData` do aktualizacji niestandardowej części XML?**

Użyj `getXmlAsString` i `setXmlAsString`, gdy aplikacja pracuje z tekstem XML w kodowaniu UTF‑8. Użyj `getXmlData` i `setXmlData`, gdy XML jest już dostępny jako tablica bajtów lub gdy przetwarzanie binarne jest wygodniejsze. Obie reprezentacje odnoszą się do tej samej treści XML niestandardowej części.