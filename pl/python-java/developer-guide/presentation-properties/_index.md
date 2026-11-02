---
title: Zarządzanie własnościami prezentacji w Python
linktitle: Własności prezentacji
type: docs
weight: 70
url: /pl/python-java/presentation-properties/
keywords:
- własności PowerPoint
- własności prezentacji
- własności dokumentu
- własności wbudowane
- własności niestandardowe
- własności zaawansowane
- zarządzaj własnościami
- modyfikuj własności
- metadane dokumentu
- edytuj metadane
- język korekty
- język domyślny
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Zarządzaj własnościami prezentacji w Aspose.Slides dla Pythona via Java i usprawnij wyszukiwanie, branding oraz przepływ pracy w swoich plikach PowerPoint i OpenDocument."
---
## **Wprowadzenie**

Aspose.Slides for Python via Java obsługuje **wbudowane** i **niestandardowe** właściwości dokumentu. Użyj tych właściwości, aby odczytać i zaktualizować metadane prezentacji, takie jak autor, tytuł i wartości definiowane przez użytkownika.

Aspose.Slides umożliwia pracę z właściwościami dokumentu prezentacji za pomocą klasy [DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/) . Instancja tej klasy jest zwracana przez [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties). Poniższe przykłady pokazują, jak odczytywać, modyfikować i zarządzać tymi właściwościami.

{{% alert color="info" title="Uwaga" %}}

Aspose.Slides zarządza metadanymi aplikacji i producenta podczas zapisywania prezentacji; pola te identyfikują oprogramowanie, które utworzyło wynik.

{{% /alert %}}

## **Zarządzanie właściwościami prezentacji**

Właściwości dokumentu przechowują informacyjne dane opisowe razem z treścią prezentacji. Dzielą się na dwie kategorie:

- **Wbudowane właściwości** zawierają standardowe metadane, takie jak tytuł, autor i statystyki dokumentu.
- **Niestandardowe właściwości** przechowują pary nazwa/wartość definiowane przez użytkownika.

Aspose.Slides for Python via Java zapewnia dostęp do obu kategorii. W programie PowerPoint wybierz **File → Info → Properties → Advanced Properties**, aby przejrzeć metadane dokumentu. Okno dialogowe grupuje informacje w zakładki, takie jak **Summary**, **Statistics**, **Contents** i **Custom**. Użyj zakładki **Custom**, aby zarządzać własnymi właściwościami.

## **Odczyt publicznych właściwości z zaszyfrowanej prezentacji**

Hasło otwierające normalnie chroni zarówno treść prezentacji, jak i właściwości dokumentu. Gdy prezentacja jest szyfrowana po wywołaniu [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) z wartością `False`, jej właściwości dokumentu pozostają publiczne. Aplikacja może wtedy wywołać [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) z wartością `True` i odczytać publiczne metadane bez podawania hasła otwierającego.

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) kontroluje, co Aspose.Slides ładuje; nie odszyfrowuje niczego. Jeśli właściwości zostały objęte szyfrowaniem, ich ładowanie bez hasła kończy się niepowodzeniem. Jeśli prezentacja nie jest zaszyfrowana, opcja jest ignorowana i ładowana jest cała prezentacja.

Przykład wymaga zaszyfrowanej prezentacji, której właściwości dokumentu zostały pozostawione publiczne. Weryfikuje tryb ładowania za pomocą [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) i następnie odczytuje wbudowane właściwości przez [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties):

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

W tym trybie zawartość slajdów nie jest ładowana. Slajdy, wzorce, układy, kształty, multimedia i inne obiekty prezentacji są niedostępne. Aplikacje powinny zawsze sprawdzać [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) przed wykonaniem operacji wymagającej pełnego modelu obiektowego prezentacji.

{{% alert color="warning" title="Ostrzeżenie" %}}
Publiczne metadane mogą ujawnić imiona autorów, tytuły, tematy, słowa kluczowe, informacje o firmie, komentarze i wartości niestandardowe. Szyfruj wrażliwe właściwości razem z prezentacją. Pozostaw je publiczne tylko wtedy, gdy systemy indeksowania, klasyfikacji, wyszukiwania lub zarządzania dokumentami mają konkretny wymóg dostępu do nich bez hasła.
{{% /alert %}}

## **Aktualizacja właściwości zaszyfrowanej prezentacji**

Dla zaszyfrowanego pliku PPTX, prezentacja załadowana po wywołaniu [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) z `True` jest przeznaczona do odczytu publicznych metadanych. Aspose.Slides nie może zapisać zmienionych właściwości z tego obiektu zawierającego wyłącznie metadane, ponieważ publiczne właściwości muszą pozostać zgodne z odpowiadającymi danymi wewnątrz zaszyfrowanej prezentacji. Aktualizacja wymaga więc prawidłowego hasła otwierającego i pełnego załadowania.

Przykład wymaga zaszyfrowanej prezentacji PPTX z publicznymi właściwościami dokumentu oraz znanego hasła otwierającego. Otwiera pełną prezentację przy użyciu [LoadOptions.setPassword](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setPassword), aktualizuje publiczne wbudowane właściwości i zapisuje wynik. Następnie używa [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#isEncrypted), aby zweryfikować, że szyfrowanie zostało zachowane, oraz ponownie otwiera publiczne metadane bez hasła, aby sprawdzić nowe wartości:

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

Klasa [DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/) udostępnia wbudowane metadane poprzez metody getter, w tym [getAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getAuthor), [getTitle](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getTitle) i [getCreatedTime](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCreatedTime). Ten przykład otwiera istniejącą prezentację i wypisuje jej zapisane metadane w konsoli. Wartości zależą od wejściowej prezentacji; niektóre pola mogą być puste.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("AccessBuiltInProperties.pptx")
try:
    document_properties = presentation.getDocumentProperties()

    print("Category:", document_properties.getCategory())
    print("Content status:", document_properties.getContentStatus())
    print("Creation date:", document_properties.getCreatedTime())
    print("Author:", document_properties.getAuthor())
    print("Comments:", document_properties.getComments())
    print("Keywords:", document_properties.getKeywords())
    print("Last modified by:", document_properties.getLastSavedBy())
    print("Manager:", document_properties.getManager())
    print("Modified date:", document_properties.getLastSavedTime())
    print("Presentation format:", document_properties.getPresentationFormat())
    print("Last print date:", document_properties.getLastPrinted())
    print("Is shared between producers:", document_properties.getSharedDoc())
    print("Subject:", document_properties.getSubject())
    print("Title:", document_properties.getTitle())
finally:
    presentation.dispose()
```

## **Modyfikacja wbudowanych właściwości**

Aby zaktualizować wbudowane metadane, użyj metod setter na obiekcie zwróconym przez [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties). Ten przykład otwiera istniejącą prezentację, wywołuje [setAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setAuthor), [setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setTitle), [setSubject](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setSubject), [setComments](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setComments) i [setManager](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setManager), a następnie zapisuje zaktualizowaną prezentację przy użyciu [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save). Zapisany plik PPTX zawiera nowe metadane.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("ModifyBuiltInProperties.pptx")
try:
    document_properties = presentation.getDocumentProperties()

    document_properties.setAuthor("Aspose.Slides for Python via Java")
    document_properties.setTitle("Manage PowerPoint Presentation Properties")
    document_properties.setSubject("Modify Built-in Properties")
    document_properties.setComments("Aspose description")
    document_properties.setManager("Aspose manager")

    presentation.save("DocumentProperties_output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zarządzanie bazą hiperłączy**

[DocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getHyperlinkBase) zwraca bazę na poziomie dokumentu dla względnych hiperłącz. Użyj [DocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setHyperlinkBase), aby ją zmienić lub wyczyścić. Jest to przydatne przy przenoszeniu prezentacji i powiązanych plików w inne miejsce. Nie ma to wpływu na indywidualny adres hiperłącza uzyskiwany przez [Hyperlink.getExternalUrl](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrl): zmiana bazy nie przepisuje zapisanych adresów linków ani nie zmienia ich bezwzględnych docelowych lokalizacji.

Przykład wymaga prezentacji zawierającej zarówno względny link, np. `target.html`, jak i bezwzględny link, np. `https://example.org/absolute.html`. Odczytuje istniejącą bazę, nadaje nowy adres bazy, zapisuje i ponownie otwiera prezentację w celu sprawdzenia wartości. Następnie czyści bazę, ustawiając pusty ciąg znaków, i weryfikuje pustą wartość w osobnym zapisanym pliku. Zamień przykładowy adres bazy na lokalizację swoich powiązanych plików.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("hyperlinks.pptx")
try:
    print("Original base:", presentation.getDocumentProperties().getHyperlinkBase())

    new_base = "https://example.com/new/"
    presentation.getDocumentProperties().setHyperlinkBase(new_base)
    presentation.save("hyperlinks-updated.pptx", SaveFormat.Pptx)

    updated_presentation = Presentation("hyperlinks-updated.pptx")
    try:
        print("Base preserved:", new_base == updated_presentation.getDocumentProperties().getHyperlinkBase())

        updated_presentation.getDocumentProperties().setHyperlinkBase("")
        updated_presentation.save("hyperlinks-cleared.pptx", SaveFormat.Pptx)

        cleared_presentation = Presentation("hyperlinks-cleared.pptx")
        try:
            print("Base cleared:", "" == cleared_presentation.getDocumentProperties().getHyperlinkBase())
        finally:
            cleared_presentation.dispose()
    finally:
        updated_presentation.dispose()
finally:
    presentation.dispose()
```

Oba komunikaty weryfikacyjne powinny wypisać `True`. Czyszczenie bazy pozostawia niezmienione indywidualne adresy hiperłączy.

Względny link do `target.pptx` otwierał `old/target.pptx`, gdy baza wskazywała na folder `old`. Po zmianie bazy na folder `new`, zapisaniu i ponownym otwarciu prezentacji, ten sam link otworzył `new/target.pptx`. Bezpośredni link nadal otwierał ten sam plik. Przetestuj swoje względne linki w PowerPoint przed i po przeniesieniu prezentacji lub zmianie jej bazy.

## **Dodawanie niestandardowych właściwości prezentacji**

Niestandardowe właściwości przechowują metadane, które nie mają odpowiadającego im pola wbudowanego. Metoda [DocumentProperties.set_Item](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#set_Item) pozwala przypisać wartość według nazwy właściwości. Ten przykład tworzy prezentację, dodaje dwie wartości tekstowe oraz wartość wersji całkowitej (używając `jpype.JInt` do przekazania liczby całkowitej Java) i zapisuje prezentację przy użyciu [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save). Przypisanie wartości do istniejącej nazwy zastępuje poprzednią wartość tej właściwości.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    document_properties = presentation.getDocumentProperties()

    document_properties.set_Item("Reviewed by", "John Smith")
    document_properties.set_Item("Confidentiality level", "Internal")
    document_properties.set_Item("Document version", jpype.JInt(2))

    presentation.save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Dostęp i modyfikacja niestandardowych właściwości**

Ten przykład otwiera prezentację zawierającą niestandardowe właściwości i używa [getCountOfCustomProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCountOfCustomProperties) do iteracji po nich. [getCustomPropertyName](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCustomPropertyName) przyjmuje indeks zerowy i zwraca nazwę używaną przez [DocumentProperties.set_Item](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#set_Item). Przykład wypisuje każdą oryginalną nazwę i wartość, zamienia każdą wartość na numerowany ciąg znaków niezależnie od pierwotnego typu i zapisuje zmiany. Jeśli nie ma niestandardowych właściwości, pętla nie wprowadza żadnych zmian.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("AccessAndModifyProperties.pptx")
try:
    document_properties = presentation.getDocumentProperties()

    for i in range(document_properties.getCountOfCustomProperties()):
        property_name = document_properties.getCustomPropertyName(i)
        property_value = document_properties.get_Item(property_name)

        print("Custom property name:", property_name)
        print("Custom property value:", property_value)

        document_properties.set_Item(property_name, f"New Value {i + 1}")

    presentation.save("CustomProperties_output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Przykład na żywo**

Wypróbuj aplikację online [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata), aby zobaczyć, jak pracować z właściwościami dokumentu przy użyciu API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**Jak mogę usunąć wbudowaną właściwość z prezentacji?**

Wbudowane właściwości są integralną częścią prezentacji i nie mogą być całkowicie usunięte. Można jednak zmienić ich wartości lub ustawić je jako pustą, jeśli dana właściwość na to pozwala.

**Co się stanie, jeśli dodam niestandardową właściwość, która już istnieje?**

Jeśli dodasz niestandardową właściwość, która już istnieje, jej istniejąca wartość zostanie nadpisana nową. Nie musisz usuwać ani sprawdzać właściwości wcześniej, ponieważ Aspose.Slides automatycznie aktualizuje wartość właściwości.

**Czy mogę uzyskać dostęp do właściwości prezentacji bez pełnego wczytywania prezentacji?**

Tak. Użyj [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/python-java/aspose.slides/presentationfactory/#getPresentationInfo), a następnie [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#readDocumentProperties), aby odczytać zapisane metadane dokumentu bez tworzenia instancji [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/). Zobacz [Build a Lightweight Presentation Inventory](/slides/pl/python-java/examine-presentation/) po kompletny przykład raportowania i ograniczenia specyficzne dla formatów.

**Czy mogę odczytać publiczne właściwości zaszyfrowanej prezentacji bez jej hasła otwierającego?**

Tak. Prezentacja musi być zaszyfrowana po wywołaniu [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) z `False`, a następnie załadowana po wywołaniu [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) z `True`.

**Czy mogę zaktualizować zaszyfrowany plik PPTX w trybie tylko właściwości dokumentu?**

Nie. Publiczne i zaszyfrowane dane właściwości muszą pozostać spójne, więc aktualizacja zaszyfrowanego pliku PPTX wymaga pełnego załadowania prezentacji z prawidłowym hasłem otwierającym.