---
title: Zarządzanie właściwościami prezentacji w Pythonie
linktitle: Właściwości prezentacji
type: docs
weight: 70
url: /pl/python-net/presentation-properties/
keywords:
- właściwości PowerPoint
- właściwości prezentacji
- właściwości dokumentu
- wbudowane właściwości
- niestandardowe właściwości
- zaawansowane właściwości
- zarządzanie właściwościami
- modyfikowanie właściwości
- metadane dokumentu
- edytowanie metadanych
- język korekty
- domyślny język
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Opanuj zarządzanie właściwościami prezentacji w Aspose.Slides dla Pythona via .NET i usprawnij wyszukiwanie, branding oraz przepływ pracy w swoich plikach PowerPoint."
---
## **Wprowadzenie**

Aspose.Slides obsługuje dwa typy właściwości dokumentu: **Built-in** i **Custom**. Oba te typy właściwości mogą być łatwo dostępne i zarządzane przy użyciu API Aspose.Slides.

Aspose.Slides pozwala pracować z właściwościami dokumentu prezentacji przy użyciu klasy [DocumentProperties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/documentproperties/). Instancja tej klasy jest zwracana przez właściwość [Presentation.document_properties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/document_properties/). Poniższe przykłady pokazują, jak odczytywać, modyfikować i zarządzać tymi właściwościami.

{{% alert color="primary" %}} 
Uwaga: nie możesz ustawiać wartości w polach **Application** i **Producer**, ponieważ w tych polach zostanie wyświetlone Aspose Ltd. oraz Aspose.Slides for Python via .NET x.x.x.
{{% /alert %}} 

## **Zarządzanie właściwościami prezentacji**

Microsoft PowerPoint udostępnia funkcję dodawania niektórych właściwości do plików prezentacji. Właściwości dokumentu pozwalają przechowywać przydatne informacje razem z dokumentami (plikami prezentacji). Istnieją dwa rodzaje właściwości dokumentu:

- Właściwości systemowe (Built-in)
- Właściwości użytkownika (Custom)

**Built-in** właściwości zawierają ogólne informacje o dokumencie, takie jak tytuł dokumentu, imię i nazwisko autora, statystyki dokumentu itp. **Custom** właściwości to te, które są definiowane przez użytkowników jako pary **Nazwa/Wartość**, gdzie zarówno nazwa, jak i wartość są określane przez użytkownika. Korzystając z Aspose.Slides for Python via .NET, programiści mogą uzyskać dostęp i modyfikować wartości wbudowanych oraz niestandardowych właściwości. Microsoft PowerPoint 2007 umożliwia zarządzanie właściwościami dokumentu plików prezentacji. Wystarczy kliknąć ikonę Office, a następnie pozycję menu **Prepare | Properties | Advanced Properties** w Microsoft PowerPoint 2007. Po wybraniu pozycji **Advanced Properties** pojawi się okno dialogowe pozwalające zarządzać właściwościami dokumentu pliku PowerPoint. W **Properties Dialog** można zobaczyć wiele kart, takich jak **General, Summary, Statistics, Contents i Custom**. Wszystkie te karty pozwalają konfigurować różne rodzaje informacji związanych z plikami PowerPoint. Karta **Custom** służy do zarządzania niestandardowymi właściwościami plików PowerPoint.

## **Dostęp do właściwości wbudowanych**
Te właściwości udostępniane przez obiekt **IDocumentProperties** obejmują: **Creator(Author)**, **Description**, **Keywords**, **Created** (Data utworzenia), **Modified** (Data modyfikacji), **Printed** (Data ostatniego wydruku), **LastModifiedBy**, **SharedDoc** (Czy współdzielony przez różnych producentów?), **PresentationFormat**, **Subject** oraz **Title**.
```py
import aspose.slides as slides

    # Utwórz instancję klasy Presentation, która reprezentuje prezentację
    with slides.Presentation(path + "AccessBuiltin Properties.pptx") as pres:
        # Utwórz odwołanie do obiektu powiązanego z prezentacją
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

## **Modyfikacja właściwości wbudowanych**

Modyfikowanie wbudowanych właściwości plików prezentacji jest tak proste, jak ich odczytywanie. Wystarczy przypisać wartość łańcucha znaków do dowolnej żądanej właściwości i wartość zostanie zmodyfikowana. W poniższym przykładzie pokazano, jak zmodyfikować wbudowane właściwości dokumentu prezentacji.

```py
import aspose.slides as slides

# Utwórz instancję klasy Presentation, która reprezentuje prezentację
with slides.Presentation(path + "ModifyBuiltinProperties.pptx") as presentation:
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

## **Dodawanie niestandardowych właściwości prezentacji**

Aspose.Slides for Python via .NET umożliwia także programistom dodawanie niestandardowych wartości do właściwości dokumentu prezentacji. Poniżej znajduje się przykład, który pokazuje, jak ustawić niestandardowe właściwości dla prezentacji.

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

## **Dostęp i modyfikacja niestandardowych właściwości**

Aspose.Slides for Python via .NET umożliwia także programistom dostęp do wartości niestandardowych właściwości. Poniżej znajduje się przykład, który pokazuje, jak uzyskać dostęp i modyfikować wszystkie te niestandardowe właściwości w prezentacji.

```py
import aspose.slides as slides

# Utwórz instancję klasy Presentation, która reprezentuje plik PPTX
with slides.Presentation(path + "AccessModifyingProperties.pptx") as presentation:
    # Utwórz odwołanie do obiektu document_properties powiązanego z prezentacją
    documentProperties = presentation.document_properties

    # Uzyskaj dostęp i zmodyfikuj własne właściwości
    for i in range(documentProperties.count_of_custom_properties):
        # Wyświetl nazwy i wartości własnych właściwości
        print("Custom Property Name : " + documentProperties.get_custom_property_name(i))
        print("Custom Property Value : " + documentProperties.get_custom_property_value[documentProperties.get_custom_property_name(i)])

        # Modyfikuj wartości własnych właściwości
        documentProperties.set_custom_property_value(documentProperties.get_custom_property_name(i), "New Value " + str(i + 1))
    # Zapisz swoją prezentację do pliku
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ustaw język korekty**

Aspose.Slides udostępnia właściwość `Language_Id` (udostępnianą przez klasę [PortionFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides/portionformat/)), aby umożliwić ustawienie języka korekty dla dokumentu PowerPoint. Język korekty to język, w którym sprawdzane są pisownia i gramatyka w PowerPoint.

Ten kod w Pythonie pokazuje, jak ustawić język korekty dla PowerPoint:

```python
import aspose.slides as slides

with slides.Presentation(path + "SetProofingLanguage.pptx") as pres:
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

Wypróbuj aplikację online [**Aspose.Slides Metadata**](https://products.aspose.app/slides/pl/metadata), aby zobaczyć, jak pracować z właściwościami dokumentu za pomocą API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/pl/metadata)

## **FAQ**

**Jak mogę usunąć wbudowaną właściwość z prezentacji?**

Wbudowane właściwości są integralną częścią prezentacji i nie mogą być całkowicie usunięte. Możesz jednak zmienić ich wartości lub ustawić je jako puste, o ile pozwala na to dana właściwość.

**Co się stanie, jeśli dodam niestandardową właściwość, która już istnieje?**

Jeśli dodasz niestandardową właściwość, która już istnieje, jej bieżąca wartość zostanie nadpisana nową. Nie musisz usuwać ani sprawdzać właściwości wcześniej, ponieważ Aspose.Slides automatycznie aktualizuje jej wartość.

**Czy mogę uzyskać dostęp do właściwości prezentacji bez pełnego ładowania prezentacji?**

Tak, możesz uzyskać dostęp do właściwości prezentacji bez pełnego ładowania jej, używając metody [get_presentation_info](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationfactory/get_presentation_info/) z klasy [PresentationFactory](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationfactory/). Następnie skorzystaj z metody [read_document_properties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationinfo/read_document_properties/) udostępnionej przez klasę [PresentationInfo](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationinfo/), aby efektywnie odczytać właściwości, oszczędzając pamięć i zwiększając wydajność.