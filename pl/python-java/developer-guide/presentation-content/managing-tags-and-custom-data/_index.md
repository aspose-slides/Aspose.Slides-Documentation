---
title: Zarządzanie tagami i danymi niestandardowymi w prezentacjach przy użyciu Pythona
linktitle: Tagi i dane niestandardowe
type: docs
weight: 300
url: /pl/python-java/managing-tags-and-custom-data/
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
description: "Dowiedz się, jak zarządzać tagami i niestandardowymi danymi XML w prezentacjach PowerPoint za pomocą Aspose.Slides dla Pythona via Java, w tym dodawanie, odczytywanie, aktualizowanie, audytowanie i usuwanie niestandardowych części XML."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak Aspose.Slides działa z tagami i danymi niestandardowymi w prezentacjach PowerPoint. Dane specyficzne dla prezentacji mogą być przechowywane jako tagi lub niestandardowe części XML. Tagi są prostymi parami klucz‑wartość w formie łańcucha znaków, podczas gdy niestandardowe części XML mogą przechowywać ustrukturyzowane metadane oraz specyficzne dla aplikacji ładunki XML.

Aspose.Slides udostępnia interfejsy API do dodawania, odczytywania, aktualizowania, audytowania i usuwania niestandardowych części XML na poziomach prezentacji, slajdu i kształtu. Niestandardowe części XML są przydatne w integracjach, które przechowują informacje takie jak identyfikatory zarządzania dokumentami, stan przepływu pracy, metadane zgodności, dane powiązane z szablonem lub inne ustrukturyzowane dane aplikacji wewnątrz prezentacji.

## **Przechowywanie danych w plikach prezentacji**

Pliki PPTX — pliki z rozszerzeniem `.pptx` — są przechowywane w formacie PresentationML, który jest częścią specyfikacji Office Open XML. Office Open XML definiuje strukturę pakietu i relacje używane do przechowywania treści prezentacji oraz powiązanych danych.

Prezentacja zawiera wiele części połączonych relacjami. Na przykład część slajdu zawiera treść pojedynczego slajdu i może mieć wyraźne relacje do innych części określonych w ISO/IEC 29500.

Dane niestandardowe mogą być przechowywane jako tagi ([TagCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/tagcollection/)) lub niestandardowe części XML ([CustomXmlPartCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/customxmlpartcollection/)). Oba są dostępne za pośrednictwem klasy [CustomData](https://reference.aspose.com/slides/pl/python-java/aspose.slides/customdata/).

{{% alert color="info" title="Note" %}}
Tagi przechowują proste pary klucz‑wartość w postaci łańcucha znaków. Niestandardowe części XML przechowują ustrukturyzowane dane XML i mogą być powiązane z prezentacją, slajdem lub kształtem.
{{% /alert %}}

## **Praca z niestandardowymi częściami XML**

Metoda [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/pl/python-java/aspose.slides/customdata/#getCustomXmlParts) zwraca kolekcję niestandardowych części XML powiązanych z określonym obiektem prezentacji. Na przykład:

- Kolekcja [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/pl/python-java/aspose.slides/customdata/#getCustomXmlParts) prezentacji zawiera niestandardowe części XML powiązane bezpośrednio z samą prezentacją.
- Kolekcja [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/pl/python-java/aspose.slides/customdata/#getCustomXmlParts) slajdu zawiera niestandardowe części XML powiązane z określonym slajdem.
- Kolekcja [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/pl/python-java/aspose.slides/customdata/#getCustomXmlParts) kształtu zawiera niestandardowe części XML powiązane z określonym kształtem.

Użyj [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getAllCustomXmlParts), gdy potrzebujesz przejrzeć wszystkie niestandardowe części XML w prezentacji, niezależnie od tego, z czym są powiązane.

### **Dodaj niestandardową część XML do prezentacji**

Użyj [CustomXmlPartCollection.add](https://reference.aspose.com/slides/pl/python-java/aspose.slides/customxmlpartcollection/#add), aby dodać dane XML do kolekcji niestandardowych części XML. XML musi być poprawny i niepusty.

Poniższy przykład dodaje ustrukturyzowane metadane do kolekcji danych niestandardowych na poziomie prezentacji:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.util import UUID

presentation = Presentation()
try:
    custom_xml_content = '<?xml version="1.0" encoding="UTF-8"?><metadata xmlns="urn:example:metadata"><documentId>DOC-1001</documentId><workflowState>Draft</workflowState></metadata>'
    custom_xml_part = presentation.getCustomData().getCustomXmlParts().add(custom_xml_content)

    # add przypisuje identyfikator automatycznie. Ustaw konkretny UUID tylko w razie potrzeby.
    item_id = UUID.randomUUID()
    custom_xml_part.setItemId(item_id)

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Metoda [add](https://reference.aspose.com/slides/pl/python-java/aspose.slides/customxmlpartcollection/#add) może także przyjmować XML jako tablicę bajtów lub strumień wejściowy, co jest przydatne, gdy zawartość XML jest już dostępna w formie binarnej.

### **Dodaj niestandardową część XML do slajdu lub kształtu**

Dane XML mogą być powiązane z konkretnym slajdem lub kształtem zamiast z całą prezentacją. Jest to przydatne, gdy metadane opisują tylko jeden obiekt, taki jak klucz szablonu, zewnętrzny identyfikator rekordu lub informacje o powiązaniu.

Poniższy przykład dodaje jedną niestandardową część XML do slajdu i inną do kształtu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide_xml_content = '<slideMetadata xmlns="urn:example:slides"><templateKey>TitleSlide</templateKey></slideMetadata>'
    slide.getCustomData().getCustomXmlParts().add(slide_xml_content)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 250, 80)
    shape.getTextFrame().setText("Customer data")
    shape_xml_content = '<shapeMetadata xmlns="urn:example:shapes"><recordId>CRM-4281</recordId></shapeMetadata>'
    shape.getCustomData().getCustomXmlParts().add(shape_xml_content)

    presentation.save("object_custom_xml.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Poziom, na którym dodawana jest część, określa, w której kolekcji [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/pl/python-java/aspose.slides/customdata/#getCustomXmlParts) znajduje się relacja do tej części. Dane na poziomie prezentacji są odpowiednie dla metadanych obejmujących cały dokument, dane na poziomie slajdu dla informacji przypisanych do konkretnego slajdu, a dane na poziomie kształtu dla metadanych powiązanych z pojedynczym kształtem.

### **Wyświetl i audytuj wszystkie niestandardowe części XML**

Użyj [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getAllCustomXmlParts), aby pobrać wszystkie niestandardowe części XML z prezentacji. Każdy [CustomXmlPart](https://reference.aspose.com/slides/pl/python-java/aspose.slides/customxmlpart/) udostępnia swój identyfikator, zawartość XML oraz powiązane schematy przestrzeni nazw.

Poniższy przykład wyświetla wszystkie niestandardowe części XML oraz ich schematy przestrzeni nazw:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    for custom_xml_part in presentation.getAllCustomXmlParts():
        print("ItemId:", custom_xml_part.getItemId())
        print("XML:")
        print(custom_xml_part.getXmlAsString())

        for namespace_schema in custom_xml_part.getNamespaceSchemas():
            print("Namespace schema:", namespace_schema)

        print()
finally:
    presentation.dispose()
```

[CustomXmlPart.getNamespaceSchemas](https://reference.aspose.com/slides/pl/python-java/aspose.slides/customxmlpart/#getNamespaceSchemas) zwraca schematy XML powiązane z niestandardową częścią XML. Informacja ta może być przydatna podczas audytu prezentacji zawierających XML wygenerowany przez systemy zewnętrzne.

### **Odczyt i aktualizacja zawartości XML oraz ItemId**

Użyj [CustomXmlPart.getXmlAsString](https://reference.aspose.com/slides/pl/python-java/aspose.slides/customxmlpart/#getXmlAsString) i [setXmlAsString](https://reference.aspose.com/slides/pl/python-java/aspose.slides/customxmlpart/#setXmlAsString), aby pracować z XML jako ciągiem UTF‑8, lub [getXmlData](https://reference.aspose.com/slides/pl/python-java/aspose.slides/customxmlpart/#getXmlData) i [setXmlData](https://reference.aspose.com/slides/pl/python-java/aspose.slides/customxmlpart/#setXmlData), aby pracować z surowymi bajtami XML.

Metoda [CustomXmlPart.getItemId](https://reference.aspose.com/slides/pl/python-java/aspose.slides/customxmlpart/#getItemId) zwraca UUID identyfikujący niestandardową część XML w dokumencie Office Open XML. Użyj [setItemId](https://reference.aspose.com/slides/pl/python-java/aspose.slides/customxmlpart/#setItemId), gdy integracja wymaga nowego identyfikatora.

Poniższy przykład aktualizuje zawartość XML oraz identyfikator:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.util import UUID

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getAllCustomXmlParts()
    if len(custom_xml_parts) > 0:
        custom_xml_part = custom_xml_parts[0]

        # Odczytaj bieżący XML jako tekst.
        current_xml_content = custom_xml_part.getXmlAsString()
        print(current_xml_content)

        # Zaktualizuj XML jako ciąg UTF-8.
        custom_xml_content = '<metadata xmlns="urn:example:metadata"><documentId>DOC-1001</documentId><workflowState>Approved</workflowState></metadata>'
        custom_xml_part.setXmlAsString(custom_xml_content)

        # getXmlData dostarcza tę samą zawartość XML jako surowe bajty.
        custom_xml_data = custom_xml_part.getXmlData()
        print(bytes(custom_xml_data).decode("utf-8"))

        # Zastąp identyfikator, gdy wymaga tego integracja.
        item_id = UUID.randomUUID()
        custom_xml_part.setItemId(item_id)

        presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx)
    else:
        print("No custom XML parts found.")
finally:
    presentation.dispose()
```

Podczas wywoływania [setXmlAsString](https://reference.aspose.com/slides/pl/python-java/aspose.slides/customxmlpart/#setXmlAsString) lub [setXmlData](https://reference.aspose.com/slides/pl/python-java/aspose.slides/customxmlpart/#setXmlData), podaj prawidłowy, niepusty XML. Użyj jednej z reprezentacji w zależności od tego, czy aplikacja pracuje głównie z łańcuchami znaków czy danymi bajtowymi.

### **Usuń niestandardową część XML**

Aspose.Slides udostępnia kilka sposobów usuwania danych XML:

- [CustomXmlPart.remove](https://reference.aspose.com/slides/pl/python-java/aspose.slides/customxmlpart/#remove) usuwa niestandardową część XML z prezentacji.
- [CustomXmlPartCollection.remove](https://reference.aspose.com/slides/pl/python-java/aspose.slides/customxmlpartcollection/#remove) usuwa określoną część z kolekcji niestandardowych części XML.
- [CustomXmlPartCollection.removeAt](https://reference.aspose.com/slides/pl/python-java/aspose.slides/customxmlpartcollection/#removeAt) usuwa część pod określonym indeksem w kolekcji.
- [CustomXmlPartCollection.clear](https://reference.aspose.com/slides/pl/python-java/aspose.slides/customxmlpartcollection/#clear) usuwa wszystkie części z danej kolekcji.

Poniższy przykład usuwa jedną niestandardową część XML na poziomie prezentacji przy użyciu odwołania:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getCustomData().getCustomXmlParts()
    if custom_xml_parts.size() > 0:
        custom_xml_part = custom_xml_parts.get_Item(0)
        custom_xml_parts.remove(custom_xml_part)

    presentation.save("custom_xml_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Jeśli już masz [CustomXmlPart](https://reference.aspose.com/slides/pl/python-java/aspose.slides/customxmlpart/) i chcesz usunąć tę część z prezentacji, a nie z konkretnej kolekcji, wywołaj [CustomXmlPart.remove](https://reference.aspose.com/slides/pl/python-java/aspose.slides/customxmlpart/#remove).

Możesz także usunąć element według indeksu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getCustomData().getCustomXmlParts()
    if custom_xml_parts.size() > 0:
        custom_xml_parts.removeAt(0)
finally:
    presentation.dispose()
```

### **Wyczyść wszystkie niestandardowe części XML z kolekcji**

Użyj [clear](https://reference.aspose.com/slides/pl/python-java/aspose.slides/customxmlpartcollection/#clear), gdy wszystkie niestandardowe części XML powiązane z danym obiektem prezentacji mają zostać usunięte.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear()

    presentation.save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[clear](https://reference.aspose.com/slides/pl/python-java/aspose.slides/customxmlpartcollection/#clear) wpływa tylko na wybraną kolekcję. Na przykład wyczyszczenie kolekcji slajdu nie usuwa kolekcji na poziomie prezentacji ani kształtu.

Aby usunąć każdą niestandardową część XML w prezentacji, przeiteruj [getAllCustomXmlParts](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getAllCustomXmlParts) i usuń każdą część:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    for custom_xml_part in presentation.getAllCustomXmlParts():
        custom_xml_part.remove()

    presentation.save("all_custom_xml_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Obsługa powiązanych lub współdzielonych niestandardowych części XML**

W prezentacji Office Open XML ta sama niestandardowa część XML może być odwoływana z więcej niż jednego obiektu prezentacji. Na przykład istniejący plik może zawierać relacje z wielu slajdów lub kształtów do tej samej podstawowej części XML.

Współdzielona część powinna być traktowana jako pojedynczy obiekt danych z wieloma odwołaniami:

- Aktualizacja przy użyciu [setXmlAsString](https://reference.aspose.com/slides/pl/python-java/aspose.slides/customxmlpart/#setXmlAsString), [setXmlData](https://reference.aspose.com/slides/pl/python-java/aspose.slides/customxmlpart/#setXmlData) lub [setItemId](https://reference.aspose.com/slides/pl/python-java/aspose.slides/customxmlpart/#setItemId) zmienia podstawową niestandardową część XML, więc zmiana obowiązuje wszędzie, gdzie ta część jest odwoływana.
- [getItemId](https://reference.aspose.com/slides/pl/python-java/aspose.slides/customxmlpart/#getItemId) może być użyte do identyfikacji tej samej niestandardowej części XML podczas audytu kolekcji na poziomie obiektów.
- Usunięcie części z konkretnej kolekcji [getCustomXmlParts](https://reference.aspose.com/slides/pl/python-java/aspose.slides/customdata/#getCustomXmlParts) usuwa ją z tej kolekcji. Użyj [CustomXmlPart.remove](https://reference.aspose.com/slides/pl/python-java/aspose.slides/customxmlpart/#remove), gdy sama część ma zostać usunięta z prezentacji.
- Przed usunięciem lub zamianą współdzielonej części, sprawdź kolekcje na poziomie obiektów, aby ustalić, czy inne slajdy lub kształty nadal odwołują się do niej.

Przeciążenia [add](https://reference.aspose.com/slides/pl/python-java/aspose.slides/customxmlpartcollection/#add) tworzą nową niestandardową część XML z zawartości XML; nie przyjmują istniejącego [CustomXmlPart](https://reference.aspose.com/slides/pl/python-java/aspose.slides/customxmlpart/). W związku z tym współdzielone relacje najczęściej występują podczas ładowania prezentacji, które już je zawierają.

Poniższy przykład audytuje kolekcje na poziomie prezentacji, slajdu i kształtu według `ItemId` i raportuje części odwoływane z więcej niż jednego miejsca:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    references_by_item_id = {}

    def register_custom_xml_parts(owner_name, custom_xml_parts):
        for i in range(custom_xml_parts.size()):
            custom_xml_part = custom_xml_parts.get_Item(i)
            item_id = str(custom_xml_part.getItemId())
            references_by_item_id.setdefault(item_id, []).append(owner_name)

    register_custom_xml_parts("Presentation", presentation.getCustomData().getCustomXmlParts())

    for slide_index in range(presentation.getSlides().size()):
        slide = presentation.getSlides().get_Item(slide_index)
        register_custom_xml_parts(f"Slide {slide_index + 1}", slide.getCustomData().getCustomXmlParts())

        for shape_index in range(slide.getShapes().size()):
            shape = slide.getShapes().get_Item(shape_index)
            register_custom_xml_parts(f"Slide {slide_index + 1}, shape {shape_index}", shape.getCustomData().getCustomXmlParts())

    for item_id, owner_names in references_by_item_id.items():
        if len(owner_names) > 1:
            print("Shared custom XML part:", item_id)
            for owner_name in owner_names:
                print("  Referenced by:", owner_name)
finally:
    presentation.dispose()
```

Ten rodzaj audytu jest przydatny przed modyfikacją lub usunięciem niestandardowych danych XML w prezentacjach tworzonych przez systemy zewnętrzne, ponieważ ta sama część metadanych może uczestniczyć w więcej niż jednej relacji.

## **Pobieranie wartości tagów**

W slajdach tag odpowiada metodzie [DocumentProperties.getKeywords](https://reference.aspose.com/slides/pl/python-java/aspose.slides/documentproperties/#getKeywords). Ten przykładowy kod pokazuje, jak uzyskać wartość tagu przy użyciu Aspose.Slides dla Pythona via Java dla [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    keywords = presentation.getDocumentProperties().getKeywords()
finally:
    presentation.dispose()
```

## **Dodawanie tagów do prezentacji**

Aspose.Slides umożliwia dodawanie tagów do prezentacji. Tag zazwyczaj składa się z dwóch elementów:

- nazwy własnej właściwości, na przykład `MyTag`;
- wartości własnej właściwości, na przykład `My Tag Value`.

Jeśli potrzebujesz klasyfikować prezentacje według określonej reguły lub właściwości, możesz dodać odpowiednie tagi. Na przykład, jeśli chcesz kategoryzować prezentacje z krajów Ameryki Północnej, możesz utworzyć tag Ameryka Północna i przypisać jako jego wartość odpowiedni kraj.

Ten przykładowy kod pokazuje, jak dodać tag do [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) używając Aspose.Slides dla Pythona via Java:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    tags = presentation.getCustomData().getTags()
    tags.set_Item("MyTag", "My Tag Value")
finally:
    presentation.dispose()
```

Tagi mogą być również ustawiane dla [Slide](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slide/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide.getCustomData().getTags().set_Item("tag", "value")
finally:
    presentation.dispose()
```

Lub dla pojedynczego [Shape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50)
    shape.getTextFrame().setText("My text")
    shape.getCustomData().getTags().set_Item("tag", "value")
finally:
    presentation.dispose()
```

### **Ograniczenia**

Tagi dodane za pośrednictwem kolekcji [CustomData.getTags](https://reference.aspose.com/slides/pl/python-java/aspose.slides/customdata/#getTags) są przechowywane wyłącznie w pliku PowerPoint. Nie są **przenoszone** do struktury tagów PDF podczas eksportu prezentacji do PDF. W konsekwencji niestandardowy identyfikator przypisany jako tag nie może być odczytany z otagowanego pliku PDF.

**Rozwiązanie**: Możesz przechowywać niestandardowy identyfikator w **Alt Text** obiektu (na przykład [Shape.setAlternativeText](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#setAlternativeText) z wartością `"MyId"`). Po wyeksportowaniu do PDF, Alt Text może pojawić się w strukturze tagów PDF.

## **FAQ**

**Czy mogę usunąć wszystkie tagi z prezentacji, slajdu lub kształtu w jednej operacji?**

Tak. [Kolekcja tagów](https://reference.aspose.com/slides/pl/python-java/aspose.slides/tagcollection/) obsługuje operację [clear](https://reference.aspose.com/slides/pl/python-java/aspose.slides/tagcollection/#clear), która usuwa wszystkie pary klucz‑wartość jednocześnie.

**Jak usunąć pojedynczy tag po nazwie bez iteracji po całej kolekcji?**

Użyj [remove](https://reference.aspose.com/slides/pl/python-java/aspose.slides/tagcollection/#remove) na [kolekcji tagów](https://reference.aspose.com/slides/pl/python-java/aspose.slides/tagcollection/), aby usunąć tag po jego kluczu.

**Jak mogę pobrać pełną listę nazw tagów w celu analizy lub filtrowania?**

Użyj [getNamesOfTags](https://reference.aspose.com/slides/pl/python-java/aspose.slides/tagcollection/#getNamesOfTags) na [kolekcji tagów](https://reference.aspose.com/slides/pl/python-java/aspose.slides/tagcollection/); zwraca tablicę wszystkich nazw tagów.

**Jak mogę znaleźć wszystkie niestandardowe części XML niezależnie od miejsca ich przechowywania?**

Użyj [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getAllCustomXmlParts), aby pobrać wszystkie niestandardowe części XML w prezentacji.

**Czy powinienem używać [getXmlAsString]/[setXmlAsString] czy [getXmlData]/[setXmlData] do aktualizacji niestandardowej części XML?**

Użyj [getXmlAsString] i [setXmlAsString], gdy aplikacja pracuje z tekstem XML w UTF‑8. Użyj [getXmlData] i [setXmlData], gdy XML jest już dostępny jako tablica bajtów lub gdy wygodniejsze jest przetwarzanie binarne. Obie reprezentacje odnoszą się do tej samej zawartości XML niestandardowej części.