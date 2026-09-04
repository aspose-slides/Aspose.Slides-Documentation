---
title: Z zarządzanie właściwościami prezentacji w Pythonie
linktitle: Właściwości prezentacji
type: docs
weight: 70
url: /pl/python-net/presentation-properties/
keywords:
- Właściwości PowerPoint
- Właściwości prezentacji
- Właściwości dokumentu
- Wbudowane właściwości
- Niestandardowe właściwości
- Zaawansowane właściwości
- Zarządzanie właściwościami
- Modyfikowanie właściwości
- Metadane dokumentu
- Edycja metadanych
- Język korekty
- Domyślny język
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Opanuj właściwości prezentacji w Aspose.Slides for Python via .NET i usprawnij wyszukiwanie, branding oraz przepływ pracy w swoich plikach PowerPoint."
---
## **Wstęp**

Aspose.Slides obsługuje dwa typy właściwości dokumentu: **Wbudowane** i **Niestandardowe**. Oba te typy właściwości mogą być łatwo dostępne i zarządzane przy użyciu API Aspose.Slides.

Aspose.Slides umożliwia pracę z właściwościami dokumentu prezentacji za pośrednictwem klasy [DocumentProperties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/documentproperties/). Instancja tej klasy jest zwracana przez właściwość [Presentation.document_properties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/document_properties/). Poniższe przykłady pokazują, jak odczytywać, modyfikować i zarządzać tymi właściwościami.

{{% alert color="info" title="Uwaga" %}}
Należy pamiętać, że nie można ustawiać wartości w polach **Application** i **Producer**, ponieważ w tych polach będą wyświetlane informacje o Aspose Ltd. oraz Aspose.Slides for Python via .NET x.x.x.
{{% /alert %}} 

## **Zarządzanie właściwościami prezentacji**

Microsoft PowerPoint udostępnia funkcję umożliwiającą dodawanie niektórych właściwości do plików prezentacji. Te właściwości dokumentu pozwalają przechowywać przydatne informacje razem z dokumentami (plikami prezentacji). Istnieją dwa rodzaje właściwości dokumentu, jak poniżej

- Właściwości systemowe (wbudowane)
- Właściwości definiowane przez użytkownika (niestandardowe)

**Wbudowane** właściwości zawierają ogólne informacje o dokumencie, takie jak tytuł dokumentu, nazwisko autora, statystyki dokumentu i podobne. **Niestandardowe** właściwości to te definiowane przez użytkowników jako pary **Nazwa/Wartość**, gdzie zarówno nazwa, jak i wartość są określane przez użytkownika. Korzystając z Aspose.Slides for Python via .NET, programiści mogą uzyskać dostęp i modyfikować wartości wbudowanych oraz niestandardowych właściwości. Microsoft PowerPoint 2007 umożliwia zarządzanie właściwościami dokumentu plików prezentacji. Wystarczy kliknąć ikonę Office, a następnie pozycję menu **Prepare | Properties | Advanced Properties** w Microsoft PowerPoint 2007. Po wybraniu pozycji menu **Advanced Properties** pojawi się okno dialogowe umożliwiające zarządzanie właściwościami dokumentu pliku PowerPoint. W **Properties Dialog** widać wiele kart, takich jak **General, Summary, Statistics, Contents i Custom**. Wszystkie te karty pozwalają konfigurować różne rodzaje informacji związane z plikami PowerPoint. Karta **Custom** służy do zarządzania niestandardowymi właściwościami plików PowerPoint.

## **Odczyt publicznych właściwości z zaszyfrowanej prezentacji**

Hasło otwierające zazwyczaj chroni zarówno zawartość prezentacji, jak i właściwości dokumentu. Gdy prezentacja jest zaszyfrowana z ustawieniem [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) na `False`, jej właściwości dokumentu pozostają publiczne. Aplikacja może wtedy ustawić [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/loadoptions/only_load_document_properties/) na `True` i odczytać publiczne metadane bez podawania hasła otwierającego.

`only_load_document_properties` kontroluje, co Aspose.Slides ładuje; nie odszyfrowuje niczego. Jeśli właściwości były objęte szyfrowaniem, ich ładowanie bez hasła kończy się niepowodzeniem. Jeśli prezentacja nie jest zaszyfrowana, opcja jest ignorowana i ładowana jest cała prezentacja.

Następujący przykład weryfikuje tryb ładowania za pomocą [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/pl/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) oraz odczytuje wbudowane właściwości za pomocą [Presentation.document_properties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/document_properties/):

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.only_load_document_properties = True

with slides.Presentation("public-properties-encrypted.pptx", load_options) as presentation:
    if presentation.protection_manager.is_only_document_properties_loaded:
        properties = presentation.document_properties

        print("Author: " + properties.author)
        print("Title: " + properties.title)
        print("Keywords: " + properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

W tym trybie zawartość slajdów nie jest ładowana. Slajdy, szablony, układy, kształty, multimedia i inne obiekty prezentacji są niedostępne. Aplikacje powinny zawsze sprawdzać `is_only_document_properties_loaded` przed wykonaniem operacji wymagającej pełnego modelu obiektowego prezentacji.

{{% alert color="warning" title="Bezpieczeństwo" %}}
Publiczne metadane mogą ujawnić nazwiska autorów, tytuły, tematy, słowa kluczowe, informacje o firmie, komentarze i wartości niestandardowe. Zaszyfruj wrażliwe właściwości razem z prezentacją. Pozostaw je publiczne tylko wtedy, gdy systemy indeksowania, klasyfikacji, wyszukiwania lub zarządzania dokumentami mają konkretny wymóg dostępu do nich bez hasła.
{{% /alert %}}

## **Aktualizacja właściwości zaszyfrowanej prezentacji**

Dla zaszyfrowanego pliku PPTX, prezentacja załadowana z `only_load_document_properties` ma służyć do odczytu publicznych metadanych. Aspose.Slides nie może zapisać zmienionych właściwości z tego obiektu zawierającego tylko metadane, ponieważ publiczne właściwości muszą pozostać zgodne z odpowiadającymi danymi wewnątrz zaszyfrowanej prezentacji. Aktualizacja wymaga więc poprawnego hasła otwierającego i pełnego załadowania.

Następujący przykład otwiera prezentację za pomocą [LoadOptions.password](https://reference.aspose.com/slides/pl/python-net/aspose.slides/loadoptions/password/), aktualizuje publiczne wbudowane właściwości i zapisuje wynik. Następnie używa [PresentationInfo.is_encrypted](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationinfo/is_encrypted/), aby zweryfikować, że szyfrowanie zostało zachowane, i ponownie otwiera publiczne metadane bez hasła w celu sprawdzenia nowych wartości:

```python
import aspose.slides as slides

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation(input_path, load_options) as presentation:
    presentation.document_properties.title = "Updated Product Roadmap"
    presentation.document_properties.keywords = "roadmap, planning, indexed"
    presentation.save(output_path, slides.export.SaveFormat.PPTX)

presentation_info = slides.PresentationFactory.instance.get_presentation_info(output_path)
print("The presentation is encrypted: " + str(presentation_info.is_encrypted))

metadata_load_options = slides.LoadOptions()
metadata_load_options.only_load_document_properties = True

with slides.Presentation(output_path, metadata_load_options) as metadata_presentation:
    if metadata_presentation.protection_manager.is_only_document_properties_loaded:
        print("Title: " + metadata_presentation.document_properties.title)
        print("Keywords: " + metadata_presentation.document_properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

Jeśli aplikacja nie ma uprawnień do odszyfrowania lub załadowania zawartości prezentacji, musi traktować publiczne właściwości zaszyfrowanego pliku PPTX jako tylko do odczytu.

## **Dostęp do wbudowanych właściwości**

Te właściwości udostępniane przez obiekt **IDocumentProperties** obejmują: **Creator(Author)**, **Description**, **Keywords**, **Created** (Data utworzenia), **Modified** (Data modyfikacji), **Printed** (Data ostatniego wydruku), **LastModifiedBy**, **Keywords**, **SharedDoc** (Czy współdzielone między różnymi producentami?), **PresentationFormat**, **Subject** i **Title**

```py
import aspose.slides as slides

# Utwórz instancję klasy Presentation, która reprezentuje prezentację
with slides.Presentation("AccessBuiltin Properties.pptx") as pres:
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

## **Modyfikacja wbudowanych właściwości**

Modyfikacja wbudowanych właściwości plików prezentacji jest tak prosta jak ich dostęp. Można po prostu przypisać wartość tekstową do dowolnej wybranej właściwości i wartość tej właściwości zostanie zmieniona. W poniższym przykładzie pokazaliśmy, jak możemy zmodyfikować wbudowane właściwości dokumentu pliku prezentacji.

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

    # Zapisz prezentację do pliku
    presentation.save("DocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Dodawanie niestandardowych właściwości prezentacji**

Aspose.Slides for Python via .NET umożliwia również programistom dodawanie niestandardowych wartości dla właściwości dokumentu prezentacji. Poniżej podano przykład pokazujący, jak ustawić niestandardowe właściwości dla prezentacji.

```py
import aspose.slides as slides

# Utwórz instancję klasy Presentation
with slides.Presentation() as presentation:
    # Pobieranie właściwości dokumentu
    documentProperties = presentation.document_properties

    # Dodawanie właściwości niestandardowych
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

Aspose.Slides for Python via .NET umożliwia także programistom dostęp do wartości niestandardowych właściwości. Poniżej podano przykład, który pokazuje, jak można uzyskać dostęp i modyfikować wszystkie te niestandardowe właściwości dla prezentacji.

```py
import aspose.slides as slides

# Utwórz instancję klasy Presentation, która reprezentuje plik PPTX
with slides.Presentation("AccessModifyingProperties.pptx") as presentation:
    # Utwórz odwołanie do obiektu document_properties powiązanego z prezentacją
    documentProperties = presentation.document_properties

    # Uzyskaj dostęp i modyfikuj właściwości niestandardowe
    for i in range(documentProperties.count_of_custom_properties):
        property_name = documentProperties.get_custom_property_name(i)

        # Wyświetl nazwy i wartości właściwości niestandardowych
        property_value = [""]
        documentProperties.get_custom_property_value(property_name, property_value)
        print("Custom Property Name : " + property_name)
        print("Custom Property Value : " + property_value[0])

        # Modyfikuj wartości właściwości niestandardowych
        documentProperties.set_custom_property_value(property_name, "New Value " + str(i + 1))
    # Zapisz prezentację do pliku
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

`get_custom_property_value` zwraca wartość poprzez jednowymiarową listę przekazaną jako drugi argument, a przechowywana wartość jest rzutowana na typ elementu już znajdującego się na tej liście. Powyższy przykład używa `[""]`, więc odczytuje właściwości jako ciągi znaków; aby odczytać właściwość przechowywaną jako liczba, przekaż numeryczny placeholder, np. `[0]` — w przeciwnym razie wywołanie zgłasza `InvalidCastException`.

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

Wypróbuj aplikację online [**Aspose.Slides Metadata**](https://products.aspose.app/slides/pl/metadata) aby zobaczyć, jak pracować z właściwościami dokumentu za pomocą API Aspose.Slides:

[![Zobacz i edytuj metadane PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/pl/metadata)

## **FAQ**

**Jak mogę usunąć wbudowaną właściwość z prezentacji?**

Wbudowane właściwości są integralną częścią prezentacji i nie mogą być całkowicie usunięte. Można jednak zmienić ich wartości lub ustawić je jako puste, o ile pozwala na to konkretna właściwość.

**Co się stanie, jeśli dodam niestandardową właściwość, która już istnieje?**

Jeśli dodasz niestandardową właściwość, która już istnieje, jej bieżąca wartość zostanie nadpisana nową. Nie musisz usuwać ani sprawdzać właściwości wcześniej, ponieważ Aspose.Slides automatycznie aktualizuje wartość właściwości.

**Czy mogę uzyskać dostęp do właściwości prezentacji bez pełnego ładowania prezentacji?**

Tak. Użyj [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationfactory/get_presentation_info/) oraz [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationinfo/read_document_properties/), aby odczytać przechowywane metadane dokumentu bez tworzenia instancji [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/). Zobacz [Build a Lightweight Presentation Inventory](/slides/pl/python-net/examine-presentation/) po pełny przykład raportowania i ograniczenia specyficzne dla formatu.

**Czy mogę odczytać publiczne właściwości zaszyfrowanej prezentacji bez hasła otwierającego?**

Tak. Prezentacja musi być zaszyfrowana z ustawieniem `encrypt_document_properties` na `False`, a następnie załadowana z `only_load_document_properties` ustawionym na `True`.

**Czy mogę zaktualizować zaszyfrowany plik PPTX w trybie tylko-właściwości-dokumentu?**

Nie. Publiczne i zaszyfrowane dane właściwości muszą pozostawać zgodne, więc aktualizacja zaszyfrowanego pliku PPTX wymaga pełnego załadowania prezentacji przy użyciu prawidłowego hasła otwierającego.