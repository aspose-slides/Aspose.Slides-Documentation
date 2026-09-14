---
title: Zarządzanie właściwościami prezentacji w Pythonie
linktitle: Właściwości prezentacji
type: docs
weight: 70
url: /pl/python-java/presentation-properties/
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
- Edycja metadanych
- Język korekty
- Domyślny język
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Opanuj zarządzanie właściwościami prezentacji w Aspose.Slides dla Pythona poprzez Java oraz usprawnij wyszukiwanie, markę i przepływ pracy w swoich plikach PowerPoint i OpenDocument."
---
## **Wprowadzenie**

Aspose.Slides obsługuje dwa rodzaje właściwości dokumentu: **Built-in** i **Custom**. Oba typy właściwości można łatwo odczytać i zarządzać przy użyciu API Aspose.Slides.

Aspose.Slides umożliwia pracę z właściwościami dokumentu prezentacji za pomocą klasy [DocumentProperties](https://reference.aspose.com/slides/pl/python-java/aspose.slides/documentproperties/). Instancja tej klasy jest zwracana przez [Presentation.getDocumentProperties](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getDocumentProperties). Poniższe przykłady pokazują, jak odczytywać, modyfikować i zarządzać tymi właściwościami.

{{% alert color="info" title="Note" %}}
Należy pamiętać, że pola **Application** i **AppVersion** nie mogą być modyfikowane. Aspose.Slides nadpisuje je przy każdym zapisie, więc zapisana prezentacja zawsze zgłasza „Aspose.Slides for Java” oraz wersję biblioteki, która ją wygenerowała. Każda wartość przekazana do [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/pl/python-java/aspose.slides/documentproperties/#setNameOfApplication) jest odrzucana podczas zapisu prezentacji.
{{% /alert %}}

## **Właściwości dokumentu w programie PowerPoint**

Microsoft PowerPoint 2007 umożliwia zarządzanie właściwościami dokumentu plików prezentacji. Kliknij ikonę Office i wybierz **Prepare | Properties | Advanced Properties**, jak pokazano poniżej:

|**Wybranie pozycji menu Zaawansowane właściwości**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/ZrmuCD6.jpg)|

Po wybraniu **Advanced Properties** pojawia się okno dialogowe, w którym można zarządzać właściwościami dokumentu pliku PowerPoint:

|**Okno właściwości**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/LibmdQd.jpg)|
Okno **Properties Dialog** zawiera zakładki takie jak **General**, **Summary**, **Statistics**, **Contents** i **Custom**. Zakładki te pozwalają konfigurować różne informacje o plikach PowerPoint. Użyj zakładki **Custom**, aby zarządzać własnymi właściwościami.

## **Praca z właściwościami dokumentu przy użyciu Aspose.Slides dla Pythona poprzez Java**

Jak opisano wcześniej, Aspose.Slides dla Pythona poprzez Java obsługuje zarówno **Built-in**, jak i **Custom** właściwości dokumentu. Klasa [DocumentProperties](https://reference.aspose.com/slides/pl/python-java/aspose.slides/documentproperties/) reprezentuje właściwości dokumentu powiązane z plikiem prezentacji.

Użyj [Presentation.getDocumentProperties](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getDocumentProperties), aby uzyskać dostęp do tych właściwości, jak opisano poniżej.

## **Odczyt publicznych właściwości z zaszyfrowanej prezentacji**

Normalnie hasło otwierające chroni zarówno zawartość prezentacji, jak i właściwości dokumentu. Gdy prezentacja jest szyfrowana przy przekazaniu `false` do [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/pl/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties), jej właściwości pozostają publiczne. Aplikacja może wtedy przekazać `true` do [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/pl/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) i odczytać publiczne metadane bez podawania hasła otwierającego.

Opcja ładowania wyłącznie właściwości dokumentu określa, co Aspose.Slides ładuje; nie odszyfrowuje ona niczego. Jeśli właściwości były objęte szyfrowaniem, ich ładowanie bez hasła kończy się niepowodzeniem. Jeśli prezentacja nie jest szyfrowana, opcja jest ignorowana i ładowana jest pełna prezentacja.

Poniższy przykład weryfikuje tryb ładowania za pomocą [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/pl/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) i następnie odczytuje wbudowane właściwości przez [Presentation.getDocumentProperties](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getDocumentProperties):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions

load_options = LoadOptions()
load_options.setOnlyLoadDocumentProperties(True)

presentation = Presentation("public-properties-encrypted.pptx", load_options)
try:
    if presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded():
        properties = presentation.getDocumentProperties()

        print("Author: ", properties.getAuthor())
        print("Title: ", properties.getTitle())
        print("Keywords: ", properties.getKeywords())
    else:
        print("The presentation was not loaded in document-properties-only mode.")

finally:
    presentation.dispose()
```

W tym trybie zawartość slajdów nie jest ładowana. Slajdy, mastery, układy, kształty, media i inne obiekty prezentacji są niedostępne. Aplikacje powinny zawsze sprawdzać [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/pl/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) przed wykonaniem operacji wymagającej pełnego modelu obiektowego prezentacji.

{{% alert color="warning" title="Warning" %}}
Publiczne metadane mogą ujawnić nazwy autorów, tytuły, tematy, słowa kluczowe, informacje o firmie, komentarze i własne wartości. Szyfruj wrażliwe właściwości razem z prezentacją. Pozostaw je publiczne wyłącznie wtedy, gdy systemy indeksowania, klasyfikacji, wyszukiwania lub zarządzania dokumentami wymagają dostępu bez hasła.
{{% /alert %}}

## **Aktualizacja właściwości zaszyfrowanej prezentacji**

Dla zaszyfrowanego pliku PPTX prezentacja ładowana w trybie wyłącznie właściwości dokumentu służy do odczytu publicznych metadanych. Aspose.Slides nie może zapisać zmienionych właściwości z tego obiektu zawierającego jedynie metadane, ponieważ publiczne właściwości muszą pozostać spójne z odpowiadającymi danymi w zaszyfrowanej prezentacji. Ich aktualizacja wymaga więc prawidłowego hasła otwierającego oraz pełnego załadowania prezentacji.

Poniższy przykład otwiera prezentację przy pomocy [LoadOptions.setPassword](https://reference.aspose.com/slides/pl/python-java/aspose.slides/loadoptions/#setPassword), aktualizuje publiczne wbudowane właściwości i zapisuje wynik. Następnie używa [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentationinfo/#isEncrypted), aby zweryfikować, że szyfrowanie zostało zachowane, oraz ponownie otwiera publiczne metadane bez hasła, aby sprawdzić nowe wartości:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions, PresentationFactory, SaveFormat

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation(input_path, load_options)
try:
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap")
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed")
    presentation.save(output_path, SaveFormat.Pptx)
finally:
    presentation.dispose()

presentation_info = PresentationFactory.getInstance().getPresentationInfo(output_path)
print("The presentation is encrypted: ", presentation_info.isEncrypted())

metadata_load_options = LoadOptions()
metadata_load_options.setOnlyLoadDocumentProperties(True)

metadata_presentation = Presentation(output_path, metadata_load_options)
try:
    if metadata_presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded():
        print("Title: ", metadata_presentation.getDocumentProperties().getTitle())
        print("Keywords: ", metadata_presentation.getDocumentProperties().getKeywords())
    else:
        print("The presentation was not loaded in document-properties-only mode.")

finally:
    metadata_presentation.dispose()
```

Jeśli aplikacja nie ma uprawnień do odszyfrowania lub załadowania zawartości prezentacji, musi traktować publiczne właściwości zaszyfrowanego pliku PPTX jako tylko do odczytu.

## **Dostęp do wbudowanych właściwości**

Wbudowane właściwości udostępniane przez [DocumentProperties](https://reference.aspose.com/slides/pl/python-java/aspose.slides/documentproperties/) obejmują: **Creator** (Autor), **Description**, **Created** (Data utworzenia), **Modified** (Data modyfikacji), **Printed** (Data ostatniego wydruku), **LastModifiedBy**, **Keywords**, **SharedDoc** (Czy dokument jest współdzielony?), **PresentationFormat**, **Subject** oraz **Title**.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, DocumentProperties

# Utwórz instancję klasy Presentation reprezentującej prezentację
presentation = Presentation("Presentation.pptx")
try:
    # Utwórz odniesienie do obiektu DocumentProperties powiązanego z prezentacją
    properties = presentation.getDocumentProperties()

    # Wyświetl wbudowane właściwości
    print("Category : ", properties.getCategory())
    print("Current Status : ", properties.getContentStatus())
    print("Creation Date : ", properties.getCreatedTime())
    print("Author : ", properties.getAuthor())
    print("Description : ", properties.getComments())
    print("KeyWords : ", properties.getKeywords())
    print("Last Modified By : ", properties.getLastSavedBy())
    print("Supervisor : ", properties.getManager())
    print("Modified Date : ", properties.getLastSavedTime())
    print("Presentation Format : ", properties.getPresentationFormat())
    print("Last Print Date : ", properties.getLastPrinted())
    print("Is Shared between producers : ", properties.getSharedDoc())
    print("Subject : ", properties.getSubject())
    print("Title : ", properties.getTitle())
finally:
    presentation.dispose()
```

## **Modyfikowanie wbudowanych właściwości**

Modyfikowanie wbudowanych właściwości jest tak proste, jak ich odczyt. Użyj odpowiedniego settera, aby przypisać nową wartość. Poniższy przykład modyfikuje wbudowane właściwości dokumentu przy użyciu Aspose.Slides dla Pythona poprzez Java.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, DocumentProperties

presentation = Presentation("Presentation.pptx")
try:
    # Utwórz odniesienie do obiektu DocumentProperties powiązanego z prezentacją
    properties = presentation.getDocumentProperties()

    # Ustaw wbudowane właściwości
    properties.setAuthor("Aspose.Slides for Python via Java")
    properties.setTitle("Modifying Presentation Properties")
    properties.setSubject("Aspose Subject")
    properties.setComments("Aspose Description")
    properties.setManager("Aspose Manager")

    # Zapisz prezentację do pliku
    presentation.save("DocProps.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ten przykład zmienia wbudowane właściwości prezentacji, co można zobaczyć na poniższym zrzucie:

|**Wbudowane właściwości dokumentu po modyfikacji**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/zz1N9de.jpg)|

## **Dodawanie własnych właściwości dokumentu**

Aspose.Slides dla Pythona poprzez Java umożliwia również programistom dodawanie własnych właściwości dokumentu do prezentacji. Poniższy przykład dodaje trzy własne właściwości, następnie odczytuje nazwę przechowywaną pod indeksem 2 i usuwa tę właściwość, tak że zapisana prezentacja zachowuje dwie z nich. Własne właściwości są indeksowane w kolejności alfabetycznej, a nie w kolejności ich dodania.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Pobieranie właściwości dokumentu
    properties = presentation.getDocumentProperties()

    # Dodawanie własnych właściwości
    properties.set_Item("New Custom", jpype.JInt(12))
    properties.set_Item("My Name", "Mudassir")
    properties.set_Item("Custom", jpype.JInt(124))

    # Pobieranie nazwy właściwości pod określonym indeksem
    property_name = properties.getCustomPropertyName(2)

    # Usuwanie wybranej właściwości
    properties.removeCustomProperty(property_name)

    # Zapisywanie prezentacji
    presentation.save("CustomDemo.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|**Dodane własne właściwości dokumentu**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/HdKcxI9.png)|

## **Dostęp i modyfikacja własnych właściwości**

Aspose.Slides dla Pythona poprzez Java umożliwia również programistom dostęp do wartości własnych właściwości. Poniższy przykład pokazuje, jak odczytać i zmodyfikować wszystkie własne właściwości w prezentacji.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, DocumentProperties

presentation = Presentation("Presentation.pptx")
try:
    # Utwórz odniesienie do obiektu DocumentProperties powiązanego z prezentacją
    properties = presentation.getDocumentProperties()

    # Uzyskaj dostęp i zmodyfikuj własne właściwości
    for i in range(properties.getCountOfCustomProperties()):
        property_name = properties.getCustomPropertyName(i)
        # Wyświetl nazwy i wartości własnych właściwości
        print("Custom Property Name : ", property_name)
        print("Custom Property Value : ", properties.get_Item(property_name))

        # Zmodyfikuj wartości własnych właściwości
        properties.set_Item(property_name, f"New Value {i + 1}")

    # Zapisz prezentację do pliku
    presentation.save("CustomDemoModified.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Przykład modyfikuje własne właściwości prezentacji [PPTX](https://docs.fileformat.com/presentation/pptx/). Poniższe ilustracje przedstawiają własne właściwości prezentacji przed i po modyfikacji:

|**Własne właściwości przed modyfikacją**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/Ze7YHvi.jpg)|

|**Własne właściwości po modyfikacji**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/Tofu0CL.jpg)|

## **Zaawansowane właściwości dokumentu**

{{% alert color="info" title="Note" %}}
Do klasy [PresentationInfo](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentationinfo/) dodano nowe metody [readDocumentProperties](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentationinfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) oraz [writeBindedPresentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentationinfo/#writeBindedPresentation), a zachowanie metody [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/pl/python-java/aspose.slides/documentproperties/#setLastSavedTime) uległo zmianie.
{{% /alert %}}

Dwie nowe metody [readDocumentProperties](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentationinfo/#readDocumentProperties) i [updateDocumentProperties](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) zostały dodane do klasy [PresentationInfo](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentationinfo/). Umożliwiają one szybki dostęp do właściwości dokumentu oraz ich zmianę i aktualizację bez ładowania całej prezentacji.

Typowy przepływ pracy polegający na ładowaniu właściwości, zmianie ich wartości i aktualizacji dokumentu można zaimplementować w następujący sposób:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

# Odczytaj informacje o prezentacji
presentation_info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx")

# Pobierz bieżące właściwości
properties = presentation_info.readDocumentProperties()

# Ustaw nowe wartości pól Autor i Tytuł
properties.setAuthor("New Author")
properties.setTitle("New Title")

# Zaktualizuj prezentację nowymi wartościami
presentation_info.updateDocumentProperties(properties)
presentation_info.writeBindedPresentation("presentation.pptx")
```

Istnieje inny sposób użycia właściwości konkretnej prezentacji jako szablonu do aktualizacji właściwości w innych prezentacjach:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("template.pptx")
template = presentation_info.readDocumentProperties()

template.setAuthor("Template Author")
template.setTitle("Template Title")
template.setCategory("Template Category")
template.setKeywords("Keyword1, Keyword2, Keyword3")
template.setCompany("Our Company")
template.setComments("Created from template")
template.setContentType("Template Content")
template.setSubject("Template Subject")

for path in ["doc1.pptx", "doc2.odp", "doc3.ppt"]:
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

def update_by_template(path, template):
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

Nowy szablon można utworzyć od podstaw, a następnie używać go do aktualizacji wielu prezentacji:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory, DocumentProperties

template = DocumentProperties()

template.setAuthor("Template Author")
template.setTitle("Template Title")
template.setCategory("Template Category")
template.setKeywords("Keyword1, Keyword2, Keyword3")
template.setCompany("Our Company")
template.setComments("Created from template")
template.setContentType("Template Content")
template.setSubject("Template Subject")

for path in ["doc1.pptx", "doc2.odp", "doc3.ppt"]:
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

## **Ustawienie języka korekty**

Aspose.Slides udostępnia metodę [PortionFormat.setLanguageId](https://reference.aspose.com/slides/pl/python-java/aspose.slides/portionformat/#setLanguageId), która pozwala ustawić język korekty dla dokumentu PowerPoint. Język korekty to język, dla którego w prezentacji sprawdzane są ortografia i gramatyka.

Ten kod w Pythonie pokazuje, jak ustawić język korekty dla PowerPointa:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Portion, FontData

pptx_file_name = "presentation.pptx"

presentation = Presentation(pptx_file_name)
try:
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    new_portion = Portion()

    font = FontData("SimSun")
    portion_format = new_portion.getPortionFormat()
    portion_format.setComplexScriptFont(font)
    portion_format.setEastAsianFont(font)
    portion_format.setLatinFont(font)

    portion_format.setLanguageId("zh-CN") # ustaw identyfikator języka korekty

    new_portion.setText("1。")
    paragraph.getPortions().add(new_portion)
finally:
    presentation.dispose()
```

## **Ustawienie domyślnego języka**

Ten kod w Pythonie pokazuje, jak ustawić domyślny język dla całej prezentacji PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("en-US")

presentation = Presentation(load_options)
try:
    # Dodaje prostokątny kształt z tekstem
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("New Text")

    # Sprawdza język pierwszej części
    print(shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **Przykład na żywo**

Wypróbuj aplikację online [**Aspose.Slides Metadata**](https://products.aspose.app/slides/pl/metadata), aby zobaczyć, jak pracować z właściwościami dokumentu przy użyciu API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/pl/metadata)

## **FAQ**

**Jak mogę usunąć wbudowaną właściwość z prezentacji?**

Wbudowane właściwości są integralną częścią prezentacji i nie mogą być całkowicie usunięte. Można jednak zmienić ich wartości lub ustawić je na pustą wartość, o ile dana właściwość na to pozwala.

**Co się stanie, jeśli dodam własną właściwość, która już istnieje?**

Jeśli dodasz własną właściwość, która już istnieje, jej dotychczasowa wartość zostanie nadpisana nową. Nie musisz najpierw usuwać ani sprawdzać tej właściwości, ponieważ Aspose.Slides automatycznie aktualizuje jej wartość.

**Czy mogę uzyskać dostęp do właściwości prezentacji bez pełnego ładowania prezentacji?**

Tak. Użyj [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentationfactory/#getPresentationInfo), a następnie [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentationinfo/#readDocumentProperties), aby odczytać zapisane metadane dokumentu bez tworzenia instancji [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/). Zobacz sekcję [Build a Lightweight Presentation Inventory](/slides/pl/python-java/examine-presentation/) dla pełnego przykładu raportowania oraz ograniczeń zależnych od formatu.

**Czy mogę odczytać publiczne właściwości zaszyfrowanej prezentacji bez hasła otwierającego?**

Tak. Szyfrowanie właściwości dokumentu musiało być wyłączone przed zaszyfrowaniem prezentacji, a prezentacja musi być załadowana w trybie wyłącznie właściwości dokumentu.

**Czy mogę zaktualizować zaszyfrowany plik PPTX w trybie wyłącznie właściwości dokumentu?**

Nie. Publiczne i zaszyfrowane dane właściwości muszą pozostać spójne, więc aktualizacja zaszyfrowanego pliku PPTX wymaga pełnego załadowania prezentacji z prawidłowym hasłem otwierającym.