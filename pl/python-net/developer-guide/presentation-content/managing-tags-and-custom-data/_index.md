---
title: Zarządzanie tagami i danymi niestandardowymi w prezentacjach przy użyciu Pythona
linktitle: Tagi i dane niestandardowe
type: docs
weight: 300
url: /pl/python-net/managing-tags-and-custom-data/
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
- Python
- Aspose.Slides
description: "Dowiedz się, jak zarządzać tagami i niestandardowymi danymi XML w prezentacjach PowerPoint przy użyciu Aspose.Slides for Python via .NET, w tym dodawanie, odczytywanie, aktualizowanie, audyt i usuwanie niestandardowych części XML."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak Aspose.Slides współpracuje z tagami i danymi niestandardowymi w prezentacjach PowerPoint. Dane specyficzne dla prezentacji mogą być przechowywane jako tagi lub niestandardowe części XML. Tagi są prostymi parami klucz-wartość typu string, natomiast niestandardowe części XML mogą przechowywać ustrukturyzowane metadane i aplikacyjne ładunki XML.

Aspose.Slides udostępnia API do dodawania, odczytywania, aktualizacji, audytu i usuwania niestandardowych części XML na poziomach prezentacji, slajdu i kształtu. Niestandardowe części XML są przydatne przy integracjach, które przechowują informacje takie jak identyfikatory systemów zarządzania dokumentami, stan workflow, metadane zgodności, dane powiązane z szablonem lub inne ustrukturyzowane dane aplikacyjne wewnątrz prezentacji.

## **Przechowywanie danych w plikach prezentacji**

Pliki PPTX — pliki z rozszerzeniem `.pptx` — są przechowywane w formacie PresentationML, będącym częścią specyfikacji Office Open XML. Office Open XML definiuje strukturę pakietu i relacje używane do przechowywania treści prezentacji oraz powiązanych danych.

Prezentacja zawiera wiele części połączonych relacjami. Na przykład część slajdu zawiera treść jednego slajdu i może mieć explicite zdefiniowane relacje do innych części zgodnie z ISO/IEC 29500.

Dane niestandardowe mogą być przechowywane jako tagi ([TagCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/tagcollection/)) lub niestandardowe części XML ([CustomXmlPartCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/customxmlpartcollection/)). Oba są dostępne przez klasę [`CustomData`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/customdata/).

{{% alert color="primary" %}}

Tagi przechowują proste pary klucz-wartość typu string. Niestandardowe części XML przechowują ustrukturyzowane dane XML i mogą być powiązane z prezentacją, slajdem lub kształtem.

{{% /alert %}}

## **Praca z niestandardowymi częściami XML**

Właściwość [`CustomData.custom_xml_parts`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/customdata/custom_xml_parts/) zwraca kolekcję niestandardowych części XML powiązanych z określonym obiektem prezentacji. Na przykład:

- `presentation.custom_data.custom_xml_parts` zawiera niestandardowe części XML powiązane z samą prezentacją.
- `slide.custom_data.custom_xml_parts` zawiera niestandardowe części XML powiązane z konkretnym slajdem.
- `shape.custom_data.custom_xml_parts` zawiera niestandardowe części XML powiązane z konkretnym kształtem.

Użyj [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/all_custom_xml_parts/) gdy potrzebujesz przejrzeć wszystkie niestandardowe części XML w prezentacji, niezależnie od tego, z czym są powiązane.

### **Dodanie niestandardowej części XML do prezentacji**

Użyj [`CustomXmlPartCollection.add`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/customxmlpartcollection/add/) aby dodać dane XML do kolekcji niestandardowych części XML. XML musi być poprawny i niepusty.

Poniższy przykład dodaje ustrukturyzowane metadane do kolekcji danych niestandardowych na poziomie prezentacji:

```py
import uuid
import aspose.slides as slides

custom_xml_content = (
    '<?xml version="1.0" encoding="UTF-8"?>'
    '<metadata xmlns="urn:example:metadata">'
    '<documentId>DOC-1001</documentId>'
    '<workflowState>Draft</workflowState>'
    '</metadata>'
)

with slides.Presentation() as presentation:
    custom_xml_part = presentation.custom_data.custom_xml_parts.add(custom_xml_content)

    # add przypisuje identyfikator automatycznie. Ustaw konkretny GUID tylko w razie potrzeby.
    custom_xml_part.item_id = uuid.uuid4()

    presentation.save("presentation_with_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

Metoda `add` może także przyjmować XML jako tablicę bajtów lub strumień, co jest przydatne, gdy zawartość XML jest już dostępna w postaci binarnej.

### **Dodanie niestandardowej części XML do slajdu lub kształtu**

Dane XML mogą być powiązane z konkretnym slajdem lub kształtem zamiast z całą prezentacją. Jest to przydatne, gdy metadane opisują tylko jeden obiekt, np. klucz szablonu, zewnętrzny identyfikator rekordu lub informacje powiązania.

Poniższy przykład dodaje jedną niestandardową część XML do slajdu i drugą do kształtu:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.custom_data.custom_xml_parts.add(
        '<slideMetadata xmlns="urn:example:slides">'
        '<templateKey>TitleSlide</templateKey>'
        '</slideMetadata>'
    )

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 250, 80)

    shape.text_frame.text = "Customer data"
    shape.custom_data.custom_xml_parts.add(
        '<shapeMetadata xmlns="urn:example:shapes">'
        '<recordId>CRM-4281</recordId>'
        '</shapeMetadata>'
    )

    presentation.save("object_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

Poziom, na którym część jest dodawana, określa, która kolekcja `custom_data.custom_xml_parts` danego obiektu zawiera odwołanie do tej części. Dane na poziomie prezentacji są odpowiednie dla metadanych obejmujących cały dokument, dane na poziomie slajdu dla informacji przynależnych do konkretnego slajdu, a dane na poziomie kształtu dla metadanych powiązanych z pojedynczym kształtem.

### **Wypisanie i audyt wszystkich niestandardowych części XML**

Użyj [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/all_custom_xml_parts/) aby pobrać wszystkie niestandardowe części XML z prezentacji. Każdy [`CustomXmlPart`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/customxmlpart/) udostępnia swój identyfikator, treść XML oraz powiązane schematy przestrzeni nazw.

Poniższy przykład wypisuje wszystkie niestandardowe części XML oraz ich schematy przestrzeni nazw:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for custom_xml_part in presentation.all_custom_xml_parts:
        print("ItemId: " + str(custom_xml_part.item_id))
        print("XML:")
        print(custom_xml_part.xml_as_string)

        for namespace_schema in custom_xml_part.namespace_schemas:
            print("Namespace schema: " + namespace_schema)

        print()
```

[`CustomXmlPart.namespace_schemas`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/customxmlpart/namespace_schemas/) zwraca schematy XML powiązane z niestandardową częścią XML. Informacja ta może być przydatna przy audycie prezentacji zawierających XML generowany przez zewnętrzne systemy.

### **Odczyt i aktualizacja treści XML oraz ItemId**

Użyj [`CustomXmlPart.xml_as_string`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/customxmlpart/xml_as_string/) aby pracować z XML jako łańcuchem UTF‑8 lub [`CustomXmlPart.xml_data`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/customxmlpart/xml_data/) aby pracować z surowymi bajtami XML. Obie właściwości można odczytywać i aktualizować.

Właściwość [`CustomXmlPart.item_id`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/customxmlpart/item_id/) zawiera GUID identyfikujący niestandardową część XML w dokumencie Office Open XML. Może być także zmieniony, gdy integracja wymaga nowego identyfikatora.

Poniższy przykład aktualizuje treść XML oraz identyfikator:

```py
import uuid
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    custom_xml_part = presentation.all_custom_xml_parts[0]

    # Odczytaj bieżący XML jako tekst.
    current_xml_content = custom_xml_part.xml_as_string
    print(current_xml_content)

    # Zaktualizuj XML jako łańcuch UTF-8.
    custom_xml_part.xml_as_string = (
        '<metadata xmlns="urn:example:metadata">'
        '<documentId>DOC-1001</documentId>'
        '<workflowState>Approved</workflowState>'
        '</metadata>'
    )

    # xml_data dostarcza tę samą treść XML jako surowe bajty.
    custom_xml_data = custom_xml_part.xml_data
    print(custom_xml_data.decode("utf-8"))

    # Zastąp identyfikator, gdy jest to wymagane przez integrację.
    custom_xml_part.item_id = uuid.uuid4()

    presentation.save("updated_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

Przy przypisywaniu `xml_as_string` lub `xml_data` należy podać poprawny, niepusty XML. Użyj jednej z reprezentacji w zależności od tego, czy aplikacja pracuje głównie z łańcuchami, czy z danymi bajtowymi.

### **Usunięcie niestandardowej części XML**

Aspose.Slides oferuje kilka sposobów usunięcia danych XML:

- [`CustomXmlPart.remove`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/customxmlpart/remove/) usuwa niestandardową część XML z prezentacji.
- [`CustomXmlPartCollection.remove`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/customxmlpartcollection/remove/) usuwa konkretną część z kolekcji niestandardowych części XML.
- [`CustomXmlPartCollection.remove_at`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/customxmlpartcollection/remove_at/) usuwa część pod wskazanym indeksem kolekcji.
- [`CustomXmlPartCollection.clear`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/customxmlpartcollection/clear/) usuwa wszystkie części z określonej kolekcji.

Poniższy przykład usuwa jedną niestandardową część XML na poziomie prezentacji, odwołując się do niej bezpośrednio:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    custom_xml_parts = presentation.custom_data.custom_xml_parts

    if len(custom_xml_parts) > 0:
        custom_xml_part = custom_xml_parts[0]
        custom_xml_parts.remove(custom_xml_part)

    presentation.save("custom_xml_removed.pptx", slides.export.SaveFormat.PPTX)
```

Jeśli już masz obiekt `CustomXmlPart` i chcesz usunąć tę część z prezentacji, a nie z określonej kolekcji, wywołaj `custom_xml_part.remove()`.

Możesz także usunąć element po indeksie:

```py
presentation.custom_data.custom_xml_parts.remove_at(0)
```

### **Wyczyszczenie wszystkich niestandardowych części XML w kolekcji**

Użyj `clear`, gdy wszystkie niestandardowe części XML powiązane z danym obiektem prezentacji powinny zostać usunięte.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.slides[0].custom_data.custom_xml_parts.clear()

    presentation.save("slide_custom_xml_cleared.pptx", slides.export.SaveFormat.PPTX)
```

`clear` wpływa tylko na wybraną kolekcję. Na przykład wyczyszczenie kolekcji slajdu nie usuwa części na poziomie prezentacji ani kształtu.

Aby usunąć każdą niestandardową część XML w prezentacji, iteruj po `all_custom_xml_parts` i usuń każdą część:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for custom_xml_part in presentation.all_custom_xml_parts:
        custom_xml_part.remove()

    presentation.save("all_custom_xml_removed.pptx", slides.export.SaveFormat.PPTX)
```

### **Obsługa powiązanych lub współdzielonych części XML**

W prezentacji Office Open XML ta sama niestandardowa część XML może być odwoływana z więcej niż jednego obiektu prezentacji. Na przykład istniejący plik może zawierać relacje z wielu slajdów lub kształtów do tej samej części XML.

Współdzielona część powinna być traktowana jako jeden obiekt danych z wieloma odwołaniami:

- Aktualizacja `xml_as_string`, `xml_data` lub `item_id` zmienia podstawową część XML, więc zmiana obowiązuje wszędzie, gdzie jest odwoływana.
- `item_id` może służyć do identyfikacji tej samej części XML podczas audytu kolekcji na poziomie obiektów.
- Usunięcie części z konkretnej kolekcji `custom_xml_parts` usuwa ją tylko z tej kolekcji. Użyj `CustomXmlPart.remove()` gdy cała część ma zostać usunięta z prezentacji.
- Przed usunięciem lub zamianą współdzielonej części, sprawdź kolekcje na poziomie obiektów, aby określić, czy inne slajdy lub kształty nadal do niej odwołują się.

Przeciążenia `add` tworzą nową niestandardową część XML z treści XML; nie przyjmują istniejącego `CustomXmlPart`. Dlatego współdzielone relacje najczęściej występują przy ładowaniu prezentacji, które już je zawierają.

Poniższy przykład audytuje kolekcje na poziomie prezentacji, slajdu i kształtu według `item_id` i raportuje części odwoływane z więcej niż jednego miejsca:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    references_by_item_id = {}

    def register_custom_xml_parts(owner_name, custom_xml_parts):
        for custom_xml_part in custom_xml_parts:
            references_by_item_id.setdefault(custom_xml_part.item_id, []).append(owner_name)

    register_custom_xml_parts("Presentation", presentation.custom_data.custom_xml_parts)

    for slide_index, slide in enumerate(presentation.slides):
        register_custom_xml_parts(
            "Slide " + str(slide_index + 1),
            slide.custom_data.custom_xml_parts
        )

        for shape_index, shape in enumerate(slide.shapes):
            register_custom_xml_parts(
                "Slide " + str(slide_index + 1) + ", shape " + str(shape_index),
                shape.custom_data.custom_xml_parts
            )

    for item_id, owner_names in references_by_item_id.items():
        if len(owner_names) > 1:
            print("Shared custom XML part: " + str(item_id))

            for owner_name in owner_names:
                print("  Referenced by: " + owner_name)
```

Ten typ audytu jest przydatny przed modyfikacją lub usunięciem danych XML w prezentacjach tworzonych przez systemy zewnętrzne, ponieważ ta sama część metadanych może uczestniczyć w wielu relacjach.

## **Pobieranie wartości tagów**

W slajdach tag odpowiada właściwości `DocumentProperties.keywords`. Ten przykładowy kod pokazuje, jak pobrać wartość tagu przy użyciu Aspose.Slides for Python via .NET dla [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/):

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    keywords = presentation.document_properties.keywords
```

## **Dodawanie tagów do prezentacji**

Aspose.Slides umożliwia dodawanie tagów do prezentacji. Tag zazwyczaj składa się z dwóch elementów:

- nazwy własności niestandardowej, np. `MyTag`;
- wartości własności niestandardowej, np. `My Tag Value`.

Jeśli potrzebujesz klasyfikować prezentacje według określonej reguły lub własności, możesz dodać odpowiednie tagi. Na przykład, aby kategoryzować prezentacje z krajów Ameryki Północnej, możesz utworzyć tag „NorthAmerican” i przypisać jako wartość odpowiedni kraj.

Ten przykładowy kod pokazuje, jak dodać tag do [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) przy użyciu Aspose.Slides for Python via .NET:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    tags = presentation.custom_data.tags
    tags.add("MyTag", "My Tag Value")
```

Tagi mogą być również ustawiane dla [Slide](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slide/):

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.custom_data.tags.add("tag", "value")
```

Lub dla pojedynczego [Shape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/):

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "My text"
    shape.custom_data.tags.add("tag", "value")
```

### **Ograniczenia**

Tagi dodane poprzez kolekcję `custom_data.tags` są przechowywane wyłącznie w pliku PowerPoint. Nie są **przenoszone** do struktury tagów PDF podczas eksportu prezentacji do PDF. W konsekwencji niestandardowy identyfikator zapisany jako tag nie może być odczytany z otagowanego pliku PDF.

**Obchodzenie problemu**: możesz przechowywać niestandardowy identyfikator w **Alt Text** obiektu (np. `shape.alternative_text = "MyId"`). Po eksporcie do PDF, Alt Text może pojawić się w strukturze tagów PDF.

## **FAQ**

**Czy mogę usunąć wszystkie tagi z prezentacji, slajdu lub kształtu w jednej operacji?**

Tak. Kolekcja [tag collection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/tagcollection/) obsługuje operację [clear](https://reference.aspose.com/slides/pl/python-net/aspose.slides/tagcollection/clear/), która usuwa wszystkie pary klucz‑wartość jednocześnie.

**Jak usunąć pojedynczy tag po jego nazwie bez iteracji po całej kolekcji?**

Użyj [remove(name)](https://reference.aspose.com/slides/pl/python-net/aspose.slides/tagcollection/remove/) na [TagCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/tagcollection/), aby usunąć tag po kluczu.

**Jak uzyskać pełną listę nazw tagów do analizy lub filtrowania?**

Użyj [get_names_of_tags](https://reference.aspose.com/slides/pl/python-net/aspose.slides/tagcollection/get_names_of_tags/) na [tag collection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/tagcollection/); metoda zwraca tablicę wszystkich nazw tagów.

**Jak znaleźć wszystkie niestandardowe części XML niezależnie od miejsca ich przechowywania?**

Użyj [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/all_custom_xml_parts/), aby pobrać wszystkie niestandardowe części XML w prezentacji.

**Czy powinienem używać `xml_as_string` czy `xml_data` do aktualizacji niestandardowej części XML?**

Użyj `xml_as_string`, gdy aplikacja pracuje z tekstem XML w formacie UTF‑8. Użyj `xml_data`, gdy XML jest już dostępny jako tablica bajtów lub gdy przetwarzanie binarne jest wygodniejsze. Obie właściwości reprezentują tę samą treść XML niestandardowej części.