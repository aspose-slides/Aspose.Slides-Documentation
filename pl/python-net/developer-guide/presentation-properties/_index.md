---
title: Zarządzaj właściwościami prezentacji w Pythonie
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
- Zarządzaj właściwościami
- Modyfikuj właściwości
- Metadane dokumentu
- Edytuj metadane
- Język korekty
- Domyślny język
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Opanuj zarządzanie właściwościami prezentacji w Aspose.Slides dla Pythona via .NET i usprawnij wyszukiwanie, branding oraz przepływ pracy w swoich plikach PowerPoint."
---
## **Wprowadzenie**

Aspose.Slides for Python via .NET obsługuje **wbudowane** i **niestandardowe** właściwości dokumentu. Użyj tych właściwości do odczytu i aktualizacji metadanych prezentacji, takich jak autor, tytuł i wartości zdefiniowane przez użytkownika.

Aspose.Slides umożliwia pracę z właściwościami dokumentu prezentacji za pomocą klasy [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) . Instancja tej klasy jest zwracana przez [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/) . Poniższe przykłady pokazują, jak odczytywać, modyfikować i zarządzać tymi właściwościami.

{{% alert color="info" title="Note" %}}
Aspose.Slides zarządza metadanymi aplikacji i producenta podczas zapisywania prezentacji; pola te identyfikują oprogramowanie, które utworzyło wyjście.
{{% /alert %}}

## **Zarządzanie właściwościami prezentacji**

Właściwości dokumentu przechowują opisowe informacje wraz z treścią prezentacji. Dzielą się na dwie kategorie:

- **Wbudowane właściwości** zawierają standardowe metadane, takie jak tytuł, autor i statystyki dokumentu.
- **Niestandardowe właściwości** przechowują pary nazw/wartości definiowane przez użytkownika.

Aspose.Slides for Python via .NET zapewnia dostęp do obu kategorii. W programie PowerPoint wybierz **Plik → Informacje → Właściwości → Zaawansowane właściwości**, aby przejrzeć metadane dokumentu. Okno dialogowe grupuje informacje w zakładki takie jak **Podsumowanie**, **Statystyki**, **Zawartość** i **Niestandardowe**. Użyj zakładki **Niestandardowe**, aby zarządzać właściwościami definiowanymi przez użytkownika.

## **Odczyt publicznych właściwości z zaszyfrowanej prezentacji**

Hasło otwierające zwykle chroni zarówno treść prezentacji, jak i właściwości dokumentu. Gdy prezentacja jest zaszyfrowana przy użyciu [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) ustawionego na `False`, jej właściwości dokumentu pozostają publiczne. Aplikacja może wtedy ustawić [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) na `True` i odczytać publiczne metadane bez podawania hasła otwierającego.

[LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) kontroluje, co Aspose.Slides ładuje; nie odszyfrowuje niczego. Jeśli właściwości zostały uwzględnione w szyfrowaniu, ich ładowanie bez hasła kończy się niepowodzeniem. Jeśli prezentacja nie jest zaszyfrowana, opcja jest ignorowana i ładowana jest pełna prezentacja.

Przykład wymaga zaszyfrowanej prezentacji, której właściwości dokumentu pozostają publiczne. Weryfikuje tryb ładowania za pomocą [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) i następnie odczytuje wbudowane właściwości przez [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/) :

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.only_load_document_properties = True

with slides.Presentation("public-properties-encrypted.pptx", load_options) as presentation:
    if presentation.protection_manager.is_only_document_properties_loaded:
        document_properties = presentation.document_properties

        print("Author: " + document_properties.author)
        print("Title: " + document_properties.title)
        print("Keywords: " + document_properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

W tym trybie zawartość slajdów nie jest ładowana. Slajdy, podstawowe szablony, układy, kształty, multimedia i inne obiekty prezentacji są niedostępne. Aplikacje powinny zawsze sprawdzać [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) przed wykonaniem operacji wymagającej pełnego modelu obiektowego prezentacji.

{{% alert color="warning" title="Security" %}}
Publiczne metadane mogą ujawniać nazwiska autorów, tytuły, tematy, słowa kluczowe, informacje o firmie, komentarze i wartości niestandardowe. Szyfruj wrażliwe właściwości razem z prezentacją. Pozostaw je publiczne tylko wtedy, gdy systemy indeksujące, klasyfikujące, wyszukujące lub zarządzające dokumentami mają konkretny wymóg dostępu do nich bez hasła.
{{% /alert %}}

## **Aktualizacja właściwości zaszyfrowanej prezentacji**

Dla zaszyfrowanego pliku PPTX, prezentacja załadowana przy użyciu [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) jest przeznaczona do odczytu publicznych metadanych. Aspose.Slides nie może zapisać zmienionych właściwości z tego obiektu zawierającego tylko metadane, ponieważ publiczne właściwości muszą pozostawać zgodne z odpowiadającymi danymi wewnątrz zaszyfrowanej prezentacji. Aktualizacja wymaga więc prawidłowego hasła otwierającego i pełnego załadowania.

Przykład wymaga zaszyfrowanej prezentacji PPTX z publicznymi właściwościami dokumentu i znanym hasłem otwierającym. Otwiera pełną prezentację przy użyciu [LoadOptions.password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/), aktualizuje publiczne wbudowane właściwości i zapisuje wynik. Następnie używa [PresentationInfo.is_encrypted](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/is_encrypted/) , aby zweryfikować, że szyfrowanie jest zachowane, i ponownie otwiera publiczne metadane bez hasła, aby zweryfikować nowe wartości :

```python
import aspose.slides as slides

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation(input_path, load_options) as presentation:
    document_properties = presentation.document_properties
    document_properties.title = "Updated Product Roadmap"
    document_properties.keywords = "roadmap, planning, indexed"
    
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

Jeśli aplikacja nie ma uprawnienia do odszyfrowania lub załadowania zawartości prezentacji, musi traktować publiczne właściwości zaszyfrowanego pliku PPTX jako tylko do odczytu.

## **Dostęp do wbudowanych właściwości**

Klasa [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) udostępnia wbudowane metadane poprzez typowane właściwości, w tym [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/), [DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/) i [DocumentProperties.created_time](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/created_time/). Ten przykład otwiera istniejącą prezentację i wypisuje jej zapisane metadane w konsoli. Wartości zależą od wejściowej prezentacji; niektóre pola mogą być puste.

```python
import aspose.slides as slides

with slides.Presentation("AccessBuiltInProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    print("Category:", document_properties.category)
    print("Content status:", document_properties.content_status)
    print("Creation date:", document_properties.created_time)
    print("Author:", document_properties.author)
    print("Comments:", document_properties.comments)
    print("Keywords:", document_properties.keywords)
    print("Last modified by:", document_properties.last_saved_by)
    print("Manager:", document_properties.manager)
    print("Modified date:", document_properties.last_saved_time)
    print("Presentation format:", document_properties.presentation_format)
    print("Last print date:", document_properties.last_printed)
    print("Is shared between producers:", document_properties.shared_doc)
    print("Subject:", document_properties.subject)
    print("Title:", document_properties.title)
```

## **Modyfikacja wbudowanych właściwości**

Aby zaktualizować wbudowane metadane, przypisz wartości do zapisywalnych właściwości udostępnionych przez [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/). Ten przykład otwiera istniejącą prezentację, ustawia [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/), [DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/), [DocumentProperties.subject](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/subject/), [DocumentProperties.comments](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/comments/), oraz [DocumentProperties.manager](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/manager/), następnie zapisuje zaktualizowaną prezentację przy użyciu [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). Zapisany plik PPTX zawiera nowe metadane.

```python
import aspose.slides as slides

with slides.Presentation("ModifyBuiltInProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    document_properties.author = "Aspose.Slides for Python via .NET"
    document_properties.title = "Manage PowerPoint Presentation Properties"
    document_properties.subject = "Modify Built-in Properties"
    document_properties.comments = "Aspose description"
    document_properties.manager = "Aspose manager"

    presentation.save("DocumentProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

## **Zarządzanie podstawą hiperłącza**

[DocumentProperties.hyperlink_base](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/hyperlink_base/) przechowuje podstawowy poziom dokumentu dla względnych hiperłączy. Jest to przydatne przy przenoszeniu prezentacji i jej powiązanych plików do innej lokalizacji. Jest oddzielny od [Hyperlink.external_url](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url/) pojedynczego hiperłącza: zmiana podstawy nie przepisuje zapisanych adresów linków ani nie zmienia docelowych lokalizacji bezwzględnych.

Przykład wymaga prezentacji zawierającej zarówno względne łącze, takie jak `target.html`, jak i bezwzględne łącze do pliku lub strony internetowej. Odczytuje istniejącą podstawę, przypisuje nowy adres podstawy i zapisuje oraz ponownie otwiera prezentację, aby sprawdzić wartość. Następnie czyści podstawę ustawiając `""` i weryfikuje pustą wartość w osobnym zapisanym pliku. Zamień przykładowy adres podstawy na lokalizację swoich powiązanych plików.

```python
import aspose.slides as slides

with slides.Presentation("hyperlinks.pptx") as presentation:
    print("Original base:", presentation.document_properties.hyperlink_base)

    new_base = "https://example.com/new/"
    presentation.document_properties.hyperlink_base = new_base
    presentation.save("hyperlinks-updated.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlinks-updated.pptx") as updated_presentation:
    print("Base preserved:", updated_presentation.document_properties.hyperlink_base == new_base)

    updated_presentation.document_properties.hyperlink_base = ""
    updated_presentation.save("hyperlinks-cleared.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlinks-cleared.pptx") as cleared_presentation:
    print("Base cleared:", cleared_presentation.document_properties.hyperlink_base == "")
```

Dwa komunikaty weryfikacyjne powinny wypisać `True`. Czyszczenie podstawy pozostawia niezmienione adresy poszczególnych hiperłączy.

Względne łącze do `target.pptx` otwierało `old/target.pptx`, gdy podstawa wskazywała folder `old`. Po zmianie podstawy na folder `new`, zapisaniu i ponownym otwarciu prezentacji to samo łącze otwierało `new/target.pptx`. Bezpośrednie łącze nadal otwierało ten sam plik. Przetestuj swoje względne łącza w PowerPoint przed i po przeniesieniu prezentacji lub zmianie jej podstawy.

## **Dodawanie niestandardowych właściwości prezentacji**

Własne właściwości przechowują metadane, które nie mają odpowiedniego wbudowanego pola. Metoda [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/) pozwala przypisać wartość według nazwy właściwości. Ten przykład tworzy prezentację, dodaje dwie wartości tekstowe i wartość wersji całkowitej, a następnie zapisuje prezentację przy użyciu [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). Przypisanie wartości do istniejącej nazwy zastępuje wartość tej właściwości.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    document_properties = presentation.document_properties

    document_properties.set_custom_property_value("Reviewed by", "John Smith")
    document_properties.set_custom_property_value("Confidentiality level", "Internal")
    document_properties.set_custom_property_value("Document version", 2)

    presentation.save("CustomDocumentProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

## **Dostęp i modyfikacja własnych właściwości**

Ten przykład otwiera prezentację zawierającą własne właściwości i używa [DocumentProperties.count_of_custom_properties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/count_of_custom_properties/) , aby iterować po nich. [DocumentProperties.get_custom_property_name](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_name/) przyjmuje indeks zerowy i zwraca nazwę używaną przez [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/). Przykład wymaga prezentacji, w której wszystkie własne właściwości są łańcuchami znaków. Wypisuje każdą oryginalną nazwę i wartość, zastępuje każdą wartość numerowanym łańcuchem i zapisuje zmiany. Jeśli nie ma własnych właściwości, pętla nie wprowadza zmian.

```python
import aspose.slides as slides

with slides.Presentation("AccessAndModifyProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    for i in range(document_properties.count_of_custom_properties):
        property_name = document_properties.get_custom_property_name(i)
        property_value = [""]
        document_properties.get_custom_property_value(property_name, property_value)

        print("Custom property name:", property_name)
        print("Custom property value:", property_value[0])

        document_properties.set_custom_property_value(property_name, "New Value " + str(i + 1))

    presentation.save("CustomProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

[DocumentProperties.get_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_value/) zwraca wartość poprzez jednowymiarową listę przekazaną jako drugi argument. Symbol zastępczy musi odpowiadać typowi przechowywanej właściwości: użyj `[""]` dla łańcucha znaków lub `[0]` dla liczby całkowitej. Niepasujący typ powoduje `InvalidCastException`; wybierz symbol zastępczy zgodnie ze schematem własnych właściwości.

## **Przykład na żywo**

Wypróbuj aplikację online [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata), aby zobaczyć, jak pracować z właściwościami dokumentu przy użyciu API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**Jak mogę usunąć wbudowaną właściwość z prezentacji?**

Wbudowane właściwości są integralną częścią prezentacji i nie mogą być całkowicie usunięte. Można jednak zmienić ich wartości lub ustawić je jako puste, o ile pozwala na to konkretna właściwość.

**Co się stanie, jeśli dodam własną właściwość, która już istnieje?**

Jeśli dodasz własną właściwość, która już istnieje, jej dotychczasowa wartość zostanie nadpisana nową. Nie musisz usuwać ani sprawdzać właściwości wcześniej, ponieważ Aspose.Slides automatycznie aktualizuje wartość właściwości.

**Czy mogę uzyskać dostęp do właściwości prezentacji bez pełnego ładowania prezentacji?**

Tak. Użyj [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/get_presentation_info/) , a następnie [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/) , aby odczytać zapisane metadane dokumentu bez tworzenia instancji [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) . Zobacz [Build a Lightweight Presentation Inventory](/slides/pl/python-net/examine-presentation/) po pełny przykład raportowania oraz ograniczenia specyficzne dla formatu.

**Czy mogę odczytać publiczne właściwości zaszyfrowanej prezentacji bez hasła otwierającego?**

Tak. Prezentacja musi być zaszyfrowana przy użyciu [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) ustawionego na `False`, oraz musi być załadowana przy użyciu [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) ustawionego na `True`.

**Czy mogę zaktualizować zaszyfrowany plik PPTX w trybie tylko właściwości dokumentu?**

Nie. Publiczne i zaszyfrowane dane właściwości muszą pozostawać spójne, więc aktualizacja zaszyfrowanego pliku PPTX wymaga pełnego załadowania prezentacji z prawidłowym hasłem otwierającym.