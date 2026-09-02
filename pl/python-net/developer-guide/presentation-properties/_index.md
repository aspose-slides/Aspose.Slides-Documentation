---
title: Zarządzanie właściwościami prezentacji w Pythonie
linktitle: Właściwości prezentacji
type: docs
weight: 70
url: /pl/python-net/presentation-properties/
keywords:
- Właściwości PowerPoint
- Właściwości prezentacji
- Właściwości dokumentu
- Wbudowane właściwości
- Własne właściwości
- Zaawansowane właściwości
- Zarządzanie właściwościami
- Modyfikowanie właściwości
- Metadane dokumentu
- Edytowanie metadanych
- Język korekty
- Domyślny język
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Opanuj właściwości prezentacji w Aspose.Slides dla Pythona poprzez .NET i usprawnij wyszukiwanie, branding oraz przepływ pracy w plikach PowerPoint."
---
## **Wprowadzenie**

Aspose.Slides obsługuje dwa typy właściwości dokumentu: **Built-in** i **Custom**. Oba typy właściwości można łatwo odczytać i zarządzać nimi przy użyciu API Aspose.Slides.

Aspose.Slides umożliwia pracę z właściwościami dokumentu prezentacji za pośrednictwem klasy [DocumentProperties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/documentproperties/). Instancja tej klasy jest zwracana przez właściwość [Presentation.document_properties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/document_properties/). Poniższe przykłady pokazują, jak odczytywać, modyfikować i zarządzać tymi właściwościami.

{{% alert color="info" title="Note" %}}

Należy pamiętać, że nie można ustawiać wartości w polach **Application** i **Producer**, ponieważ w tych polach zostanie wyświetlona nazwa Aspose Ltd. oraz Aspose.Slides for Python via .NET x.x.x.

{{% /alert %}} 

## **Zarządzanie właściwościami prezentacji**

Microsoft PowerPoint udostępnia funkcję umożliwiającą dodawanie niektórych właściwości do plików prezentacji. Te właściwości dokumentu pozwalają przechowywać przydatne informacje wspólnie z dokumentami (plikami prezentacji). Istnieją dwa rodzaje właściwości dokumentu:

- Właściwości zdefiniowane przez system (Built-in) Properties
- Właściwości definiowane przez użytkownika (Custom) Properties

**Built-in** właściwości zawierają ogólne informacje o dokumencie, takie jak tytuł dokumentu, nazwisko autora, statystyki dokumentu itp. **Custom** właściwości to pary **Name/Value**, które są definiowane przez użytkownika, gdzie zarówno nazwa, jak i wartość są określane przez użytkownika. Korzystając z Aspose.Slides for Python via .NET, programiści mogą odczytywać i modyfikować wartości wbudowanych oraz własnych właściwości. Microsoft PowerPoint 2007 umożliwia zarządzanie właściwościami dokumentu plików prezentacji. Wystarczy kliknąć ikonę Office, a następnie wybrać pozycję menu **Prepare | Properties | Advanced Properties** w Microsoft PowerPoint 2007. Po wybraniu pozycji **Advanced Properties** pojawi się dialog umożliwiający zarządzanie właściwościami dokumentu pliku PowerPoint. W **Properties Dialog** można zobaczyć wiele zakładek, takich jak **General**, **Summary**, **Statistics**, **Contents** i **Custom**. Wszystkie te zakładki umożliwiają konfigurowanie różnych rodzajów informacji związanych z plikami PowerPoint. Zakładka **Custom** służy do zarządzania własnymi właściwościami plików PowerPoint.

## **Dostęp do wbudowanych właściwości**
Te właściwości udostępniane przez obiekt **IDocumentProperties** obejmują: **Creator(Author)**, **Description**, **Keywords**, **Created** (Data utworzenia), **Modified** (Data modyfikacji), **Printed** (Data ostatniego wydruku), **LastModifiedBy**, **Keywords**, **SharedDoc** (Czy jest współdzielony między różnymi producentami?), **PresentationFormat**, **Subject** oraz **Title**
```py
import aspose.slides as slides

# Utwórz instancję klasy Presentation, która reprezentuje prezentację
with slides.Presentation("AccessBuiltin Properties.pptx") as pres:
    # Utwórz odwołanie do obiektu związanego z prezentacją
    documentProperties = pres.document_properties

    # Wyświetl wbudowane właściwości
    print("category : " + documentProperties.category)
    print("Current Status : " + documentProperties.content_status)
    print("Creation Date : " + str(documentProperties.created_time))
    print("Author : " + documentProperties.author)
    print("Description : " + documentProperties.comments)
    print("KeyWords : " + documentProperties.keywords)
    print("Last Modified By : " + documentProperties.last_saved_by)
    print("Supervisor : " + documentProperties.manager)
    print("Modified Date : " + str(documentProperties.last_saved_time))
    print("Presentation Format : " + documentProperties.presentation_format)
    print("Last Print Date : " + str(documentProperties.last_printed))
    print("Is Shared between producers : " + str(documentProperties.shared_doc))
    print("Subject : " + documentProperties.subject)
    print("Title : " + documentProperties.title)
```

## **Modyfikowanie wbudowanych właściwości**

Modyfikowanie wbudowanych właściwości plików prezentacji jest tak proste, jak ich odczyt. Wystarczy przypisać wartość łańcuchową do dowolnej żądanej właściwości, a wartość tej właściwości zostanie zmieniona. W poniższym przykładzie pokazano, jak można zmodyfikować wbudowane właściwości dokumentu prezentacji.

```py
import aspose.slides as slides

# Utwórz instancję klasy Presentation, która reprezentuje prezentację
with slides.Presentation("ModifyBuiltinProperties.pptx") as presentation:
    # Utwórz odwołanie do obiektu powiązanego z prezentacją
    documentProperties = presentation.document_properties

    # Ustaw wbudowane właściwości
    documentProperties.author = "Aspose.Slides for .NET"
    documentProperties.title = "Modifying Presentation Properties"
    documentProperties.subject = "Aspose Subject"
    documentProperties.comments = "Aspose Description"
    documentProperties.manager = "Aspose Manager"

    # Zapisz swoją prezentację do pliku
    presentation.save("DocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Dodawanie własnych właściwości prezentacji**

Aspose.Slides for Python via .NET umożliwia również programistom dodawanie własnych wartości do właściwości dokumentu prezentacji. Poniżej znajduje się przykład pokazujący, jak ustawić własne właściwości dla prezentacji.

```py
import aspose.slides as slides

# Utwórz instancję klasy Presentation
with slides.Presentation() as presentation:
    # Pobieranie właściwości dokumentu
    documentProperties = presentation.document_properties

    # Dodawanie własnych właściwości
    documentProperties.set_custom_property_value("New Custom", 12)
    documentProperties.set_custom_property_value("My Nam", "Mudassir")
    documentProperties.set_custom_property_value("Custom", 124)

    # Pobieranie nazwy właściwości pod określonym indeksem
    getPropertyName = documentProperties.get_custom_property_name(2)

    # Usuwanie wybranej właściwości
    documentProperties.remove_custom_property(getPropertyName)

    # Zapisywanie prezentacji
    presentation.save("CustomDocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Dostęp i modyfikacja własnych właściwości**

Aspose.Slides for Python via .NET umożliwia również programistom dostęp do wartości własnych właściwości. Poniżej znajduje się przykład, który pokazuje, jak można uzyskać dostęp i zmodyfikować wszystkie te własne właściwości dla prezentacji.

```py
import aspose.slides as slides

# Utwórz instancję klasy Presentation, która reprezentuje plik PPTX
with slides.Presentation("AccessModifyingProperties.pptx") as presentation:
    # Utwórz odwołanie do obiektu document_properties powiązanego z prezentacją
    documentProperties = presentation.document_properties

    # Uzyskaj dostęp i modyfikuj własne właściwości
    for i in range(documentProperties.count_of_custom_properties):
        property_name = documentProperties.get_custom_property_name(i)

        # Wyświetl nazwy i wartości własnych właściwości
        property_value = [""]
        documentProperties.get_custom_property_value(property_name, property_value)
        print("Custom Property Name : " + property_name)
        print("Custom Property Value : " + property_value[0])

        # Modyfikuj wartości własnych właściwości
        documentProperties.set_custom_property_value(property_name, "New Value " + str(i + 1))
    # Zapisz swoją prezentację do pliku
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

`get_custom_property_value` zwraca wartość poprzez jednowierszową listę przekazaną jako drugi argument, a przechowywana wartość jest rzutowana na typ elementu już znajdującego się w tej liście. Powyższy przykład używa `[""]`, więc odczytuje właściwości typu string; aby odczytać właściwość przechowywaną jako liczba, przekaż placeholder numeryczny, np. `[0]` — w przeciwnym razie wywołanie zgłosi `InvalidCastException`.

## **Ustaw język korekty**

Aspose.Slides udostępnia właściwość `Language_Id` (udostępnianą przez klasę [PortionFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides/portionformat/)), aby umożliwić ustawienie języka korekty dla dokumentu PowerPoint. Język korekty to język, dla którego sprawdzane są pisownia i gramatyka w PowerPoint.

Ten kod w Pythonie pokazuje, jak ustawić język korekty dla PowerPoint:

```python
import aspose.slides as slides

with slides.Presentation("SetProofingLanguage.pptx") as pres:
    auto_shape = pres.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    new_portion = slides.Portion()
    font = slides.FontData("SimSun")
    portion_format = new_portion.portion_format
    portion_format.complex_script_font = font
    portion_format.east_asian_font = font
    portion_format.latin_font = font

    # ustaw Id języka korekty
    portion_format.language_id = "zh-CN"
    new_portion.text = "1。"

    paragraph.portions.add(new_portion)
```

## **Ustaw domyślny język**

Ten kod w Pythonie pokazuje, jak ustawić domyślny język dla całej prezentacji PowerPoint:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en_US"

with slides.Presentation(load_options) as pres:
    shp = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 150)
    text_frame = shp.text_frame
    text_frame.text = "New Text"

    print(text_frame.paragraphs[0].portions[0].portion_format.language_id)
```

## **Przykład na żywo**

Wypróbuj aplikację online [**Aspose.Slides Metadata**](https://products.aspose.app/slides/pl/metadata), aby zobaczyć, jak pracować z właściwościami dokumentu przy użyciu Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/pl/metadata)

## **FAQ**

**Jak mogę usunąć wbudowaną właściwość z prezentacji?**

Wbudowane właściwości są integralną częścią prezentacji i nie mogą być całkowicie usunięte. Można jednak zmienić ich wartości lub, jeśli to dozwolone, ustawić je jako puste.

**Co się stanie, jeśli dodam własną właściwość, która już istnieje?**

Jeśli dodasz własną właściwość, która już istnieje, jej bieżąca wartość zostanie nadpisana nową. Nie musisz usuwać ani sprawdzać właściwości wcześniej, ponieważ Aspose.Slides automatycznie aktualizuje wartość właściwości.

**Czy mogę uzyskać dostęp do właściwości prezentacji bez pełnego ładowania prezentacji?**

Tak. Użyj [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationfactory/get_presentation_info/) i następnie [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationinfo/read_document_properties/), aby odczytać zapisane metadane dokumentu bez tworzenia instancji [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/). Zobacz [Build a Lightweight Presentation Inventory](/slides/pl/python-net/examine-presentation/) po kompletny przykład raportowania oraz ograniczenia specyficzne dla formatów.