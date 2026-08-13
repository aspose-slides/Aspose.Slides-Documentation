---
title: "Zarządzanie znacznikami i danymi niestandardowymi w prezentacjach na Androidzie"
linktitle: "Znaczniki i dane niestandardowe"
type: docs
weight: 300
url: /pl/androidjava/managing-tags-and-custom-data
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
- Android
- Java
- Aspose.Slides
description: "Naucz się, jak zarządzać znacznikami i niestandardowymi danymi XML w prezentacjach PowerPoint przy użyciu Aspose.Slides dla Androida w Javie, w tym dodawania, odczytywania, aktualizacji, audytu oraz usuwania niestandardowych części XML."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak Aspose.Slides współpracuje ze znacznikami i danymi niestandardowymi w prezentacjach PowerPoint. Dane specyficzne dla prezentacji mogą być przechowywane jako znaczniki lub niestandardowe części XML. Znaczniki to proste pary klucz‑wartość typu string, natomiast niestandardowe części XML mogą przechowywać ustrukturyzowane metadane i aplikacyjne ładunki XML.

Aspose.Slides udostępnia interfejsy API do dodawania, odczytywania, aktualizacji, audytu i usuwania niestandardowych części XML na poziomie prezentacji, slajdu i kształtu. Niestandardowe części XML są przydatne w integracjach, które przechowują informacje takie jak identyfikatory zarządzania dokumentami, stan przepływu pracy, metadane zgodności, dane powiązane z szablonem lub inne ustrukturyzowane dane aplikacji wewnątrz prezentacji.

## **Przechowywanie danych w plikach prezentacji**

Pliki PPTX — pliki z rozszerzeniem `.pptx` — są przechowywane w formacie PresentationML, będącym częścią specyfikacji Office Open XML. Office Open XML definiuje strukturę pakietu i relacje używane do przechowywania treści prezentacji oraz powiązanych danych.

Prezentacja zawiera wiele części połączonych relacjami. Na przykład część slajdu zawiera treść jednego slajdu i może mieć explicite relacje do innych części określonych w ISO/IEC 29500.

Dane niestandardowe mogą być przechowywane jako znaczniki ([ITagCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ITagCollection)) lub niestandardowe części XML ([ICustomXmlPartCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ICustomXmlPartCollection)). Oba są dostępne poprzez interfejs [`ICustomData`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ICustomData/) .

{{% alert color="info" %}}
Znaczniki przechowują proste pary klucz‑wartość typu string. Niestandardowe części XML przechowują ustrukturyzowane dane XML i mogą być powiązane z prezentacją, slajdem lub kształtem.
{{% /alert %}}

## **Praca z niestandardowymi częściami XML**

Metoda [`ICustomData.getCustomXmlParts()`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ICustomData#getCustomXmlParts--) zwraca kolekcję niestandardowych części XML powiązanych z danym obiektem prezentacji. Na przykład:

- `presentation.getCustomData().getCustomXmlParts()` zawiera niestandardowe części XML powiązane z samą prezentacją.
- `slide.getCustomData().getCustomXmlParts()` zawiera niestandardowe części XML powiązane z konkretnym slajdem.
- `shape.getCustomData().getCustomXmlParts()` zawiera niestandardowe części XML powiązane z konkretnym kształtem.

Użyj [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) kiedy potrzebujesz przejrzeć wszystkie niestandardowe części XML w prezentacji, niezależnie od tego, z czym są powiązane.

### **Dodaj część XML do prezentacji**

Użyj [`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-) aby dodać dane XML do kolekcji niestandardowych części XML. XML musi być poprawny i niepusty.

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

    // add przypisuje identyfikator automatycznie. Ustaw konkretny UUID tylko w razie potrzeby.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Metoda `add` może również przyjmować XML jako tablicę bajtów lub strumień wejściowy, co jest przydatne, gdy zawartość XML jest już dostępna w formie binarnej.

### **Dodaj część XML do slajdu lub kształtu**

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

Poziom, na którym część jest dodawana, określa, w której kolekcji `getCustomData().getCustomXmlParts()` znajduje się relacja do tej części. Dane na poziomie prezentacji są odpowiednie dla metadanych obejmujących cały dokument, dane na poziomie slajdu dla informacji należących do konkretnego slajdu, a dane na poziomie kształtu dla metadanych powiązanych z pojedynczym kształtem.

### **Wymień i audytuj wszystkie części XML**

Użyj [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) aby pobrać wszystkie niestandardowe części XML z prezentacji. Każdy [`ICustomXmlPart`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ICustomXmlPart/) udostępnia swój identyfikator, zawartość XML oraz powiązane schematy przestrzeni nazw.

Poniższy przykład wymienia wszystkie niestandardowe części XML i ich schematy przestrzeni nazw:

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

[`ICustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ICustomXmlPart#getNamespaceSchemas--) zwraca schematy XML powiązane z niestandardową częścią XML. Informacja ta może być przydatna przy audycie prezentacji zawierających XML wygenerowany przez systemy zewnętrzne.

### **Odczyt i aktualizacja zawartości XML oraz ItemId**

Użyj [`ICustomXmlPart.getXmlAsString()`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ICustomXmlPart#getXmlAsString--) i [`setXmlAsString()`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ICustomXmlPart#setXmlAsString-java.lang.String-) aby pracować z XML jako ciągiem UTF‑8, lub [`getXmlData()`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ICustomXmlPart#getXmlData--) i [`setXmlData()`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ICustomXmlPart#setXmlData-byte:A-) aby pracować z surowymi bajtami XML.

Metoda [`ICustomXmlPart.getItemId()`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ICustomXmlPart#getItemId--) zwraca UUID identyfikujący niestandardową część XML w dokumencie Office Open XML. Użyj [`setItemId()`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ICustomXmlPart#setItemId-java.util.UUID-) gdy integracja wymaga nowego identyfikatora.

Poniższy przykład aktualizuje zawartość XML oraz identyfikator:

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

    // getXmlData dostarcza tę samą zawartość XML w postaci surowych bajtów.
    byte[] customXmlData = customXmlPart.getXmlData();
    System.out.println(new String(customXmlData, StandardCharsets.UTF_8));

    // Zastąp identyfikator, gdy jest wymagany przez integrację.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Podczas wywoływania `setXmlAsString` lub `setXmlData` podaj prawidłowy, niepusty XML. Użyj jednej reprezentacji lub drugiej w zależności od tego, czy aplikacja pracuje głównie z tekstem, czy z danymi bajtowymi.

### **Usuń część XML**

Aspose.Slides oferuje kilka sposobów usunięcia danych XML:

- [`ICustomXmlPart.remove`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ICustomXmlPart#remove--) usuwa niestandardową część XML z prezentacji.
- [`ICustomXmlPartCollection.remove`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ICustomXmlPartCollection#remove-com.aspose.slides.ICustomXmlPart-) usuwa określoną część z kolekcji niestandardowych części XML.
- [`ICustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ICustomXmlPartCollection#removeAt-int-) usuwa część pod wskazanym indeksem w kolekcji.
- [`ICustomXmlPartCollection.clear`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ICustomXmlPartCollection#clear--) usuwa wszystkie części z konkretnej kolekcji.

Poniższy przykład usuwa jedną niestandardową część XML na poziomie prezentacji, odwołując się do niej:

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

Jeśli już posiadasz obiekt `ICustomXmlPart` i chcesz usunąć tę część z prezentacji, a nie z określonej kolekcji, wywołaj `customXmlPart.remove()`.

Możesz również usunąć element po indeksie:

```java
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **Wyczyść wszystkie części XML z kolekcji**

Użyj `clear`, gdy wszystkie niestandardowe części XML powiązane z danym obiektem prezentacji powinny zostać usunięte.

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

`clear` wpływa tylko na wybraną kolekcję. Na przykład wyczyszczenie kolekcji slajdu nie usuwa kolekcji na poziomie prezentacji ani kształtu.

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

### **Obsługa powiązanych lub współdzielonych części XML**

W prezentacji Office Open XML ta sama niestandardowa część XML może być odwoływana z więcej niż jednego obiektu prezentacji. Na przykład istniejący plik może zawierać relacje z wielu slajdów lub kształtów do tej samej podstawowej części XML.

Współdzielona część powinna być traktowana jako jeden obiekt danych z wieloma referencjami:

- Aktualizacja jej metodami `setXmlAsString`, `setXmlData` lub `setItemId` zmienia podstawową część XML, więc zmiana obowiązuje wszędzie, gdzie część jest odwoływana.
- `getItemId()` może być użyte do zidentyfikowania tej samej części XML podczas audytu kolekcji na poziomie obiektów.
- Usunięcie części z konkretnej kolekcji `getCustomXmlParts()` usuwa ją tylko z tej kolekcji. Użyj `ICustomXmlPart.remove()` gdy cała część ma zostać usunięta z prezentacji.
- Przed usunięciem lub zamianą współdzielonej części, sprawdź kolekcje na poziomie obiektów, aby określić, czy inne slajdy lub kształty nadal do niej odwołują się.

Przeciążenia metody `add` tworzą nową niestandardową część XML z zawartości XML; nie przyjmują istniejącego obiektu `ICustomXmlPart`. Dlatego relacje współdzielone najczęściej występują przy ładowaniu prezentacji, które już je zawierają.

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

Tego typu audyt jest przydatny przed modyfikacją lub usunięciem danych XML w prezentacjach tworzonych przez systemy zewnętrzne, ponieważ ta sama część metadanych może uczestniczyć w wielu relacjach.

## **Pobieranie wartości znaczników**

W slajdach znacznik odpowiada metodzie `IDocumentProperties.getKeywords()`. Ten przykład kodu pokazuje, jak pobrać wartość znacznika przy użyciu Aspose.Slides for Android via Java dla [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    String keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **Dodawanie znaczników do prezentacji**

Aspose.Slides umożliwia dodawanie znaczników do prezentacji. Znacznik zazwyczaj składa się z dwóch elementów:

- nazwy własności niestandardowej, np. `MyTag`;
- wartości własności niestandardowej, np. `My Tag Value`.

Jeśli musisz klasyfikować prezentacje według określonej reguły lub własności, możesz dodać odpowiednie znaczniki. Na przykład, aby kategoryzować prezentacje pochodzące z krajów Ameryki Północnej, możesz utworzyć znacznik „North American” i przypisać mu odpowiedni kraj jako wartość.

Ten przykład kodu pokazuje, jak dodać znacznik do [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation) przy użyciu Aspose.Slides for Android via Java:

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

Znaczniki można również ustawić dla [Slide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlide):

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

Lub dla pojedynczego [Shape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IAutoShape):

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

Znaczniki dodane przez kolekcję `getCustomData().getTags()` są przechowywane wyłącznie w pliku PowerPoint. Nie są **przenoszone** do struktury znaczników PDF przy eksporcie prezentacji do formatu PDF. W konsekwencji niestandardowy identyfikator przypisany jako znacznik nie może być odczytany z otagowanego pliku PDF.

**Rozwiązanie obejścia**: możesz przechowywać niestandardowy identyfikator w **Alt Text** obiektu (np. `shape.setAlternativeText("MyId")`). Po eksporcie do PDF tekst alternatywny może pojawić się w strukturze znaczników PDF.

## **FAQ**

**Czy mogę usunąć wszystkie znaczniki z prezentacji, slajdu lub kształtu w jednej operacji?**

Tak. Kolekcja [tag collection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/tagcollection/) obsługuje operację [clear](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/tagcollection/#clear--) usuwającą wszystkie pary klucz‑wartość jednocześnie.

**Jak usunąć pojedynczy znacznik po nazwie, nie iterując całej kolekcji?**

Użyj `remove(name)` na [tag collection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/tagcollection/) aby usunąć znacznik po jego kluczu.

**Jak pobrać pełną listę nazw znaczników w celach analitycznych lub filtrowania?**

Użyj `getNamesOfTags` na [tag collection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/tagcollection/); metoda zwraca tablicę wszystkich nazw znaczników.

**Jak znaleźć wszystkie niestandardowe części XML, niezależnie od miejsca ich przechowywania?**

Użyj [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) aby pobrać wszystkie niestandardowe części XML w prezentacji.

**Czy powinienem używać `getXmlAsString`/`setXmlAsString` czy `getXmlData`/`setXmlData` do aktualizacji niestandardowej części XML?**

Używaj `getXmlAsString` i `setXmlAsString`, gdy aplikacja pracuje z tekstem XML w kodowaniu UTF‑8. Używaj `getXmlData` i `setXmlData`, gdy XML jest już dostępny jako tablica bajtów lub gdy przetwarzanie binarne jest wygodniejsze. Obie reprezentacje odnoszą się do tej samej zawartości XML niestandardowej części.