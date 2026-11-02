---
title: Zarządzanie właściwościami prezentacji w C++
linktitle: Właściwości prezentacji
type: docs
weight: 70
url: /pl/cpp/presentation-properties/
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
- C++
- Aspose.Slides
description: "Opanuj właściwości prezentacji w Aspose.Slides for C++ i usprawnij wyszukiwanie, branding oraz przepływ pracy w swoich plikach PowerPoint i OpenDocument."
---
## **Wprowadzenie**

Aspose.Slides for C++ obsługuje **wbudowane** i **niestandardowe** właściwości dokumentu. Użyj tych właściwości, aby odczytać i zaktualizować metadane prezentacji, takie jak autor, tytuł i wartości definiowane przez użytkownika.

Aspose.Slides pozwala pracować z właściwościami dokumentu prezentacji za pomocą interfejsu [IDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/) . Instancja tego interfejsu jest zwracana przez [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/). Poniższe przykłady pokazują, jak odczytywać, modyfikować i zarządzać tymi właściwościami.

{{% alert color="info" title="Note" %}}
Aspose.Slides zarządza metadanymi aplikacji i producenta podczas zapisywania prezentacji; pola te identyfikują oprogramowanie, które utworzyło wynik.
{{% /alert %}}

## **Zarządzanie właściwościami prezentacji**

Właściwości dokumentu przechowują opisowe informacje wraz z treścią prezentacji. Dzielą się na dwie kategorie:

- **Wbudowane właściwości** zawierają standardowe metadane, takie jak tytuł, autor i statystyki dokumentu.
- **Niestandardowe właściwości** przechowują pary nazw/wartości definiowane przez użytkownika.

Aspose.Slides for C++ zapewnia dostęp do obu kategorii. W programie PowerPoint wybierz **Plik → Informacje → Właściwości → Zaawansowane właściwości**, aby sprawdzić metadane dokumentu. Okno dialogowe grupuje informacje w zakładki, takie jak **Podsumowanie**, **Statystyki**, **Zawartość** i **Niestandardowe**. Użyj zakładki **Niestandardowe**, aby zarządzać właściwościami definiowanymi przez użytkownika.

## **Odczytanie publicznych właściwości z zaszyfrowanej prezentacji**

Hasło otwierające zwykle chroni zarówno treść prezentacji, jak i właściwości dokumentu. Gdy prezentacja jest szyfrowana przez przekazanie `false` do [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/), jej właściwości dokumentu pozostają publiczne. Aplikacja może wtedy przekazać `true` do [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) i odczytać publiczne metadane bez podawania hasła otwierającego.

[LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) kontroluje, co Aspose.Slides ładuje; nie odszyfrowuje niczego. Jeśli właściwości były objęte szyfrowaniem, ich ładowanie bez hasła kończy się niepowodzeniem. Jeśli prezentacja nie jest szyfrowana, opcja jest ignorowana i ładowana jest pełna prezentacja.

Przykład wymaga zaszyfrowanej prezentacji, której właściwości dokumentu zostały pozostawione publiczne. Weryfikuje tryb ładowania za pomocą [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/) i następnie odczytuje wbudowane właściwości poprzez [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/):

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <DOM/LoadOptions.h>
#include <DOM/IProtectionManager.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_OnlyLoadDocumentProperties(true);

auto presentation = System::MakeObject<Presentation>(u"public-properties-encrypted.pptx", loadOptions);

if (presentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    auto documentProperties = presentation->get_DocumentProperties();

    System::Console::WriteLine(u"Author: {0}", documentProperties->get_Author());
    System::Console::WriteLine(u"Title: {0}", documentProperties->get_Title());
    System::Console::WriteLine(u"Keywords: {0}", documentProperties->get_Keywords());
}
else
{
    System::Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}
```

W tym trybie zawartość slajdów nie jest ładowana. Slajdy, wzorce, układy, kształty, multimedia i inne obiekty prezentacji są niedostępne. Aplikacje powinny zawsze sprawdzać [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/) przed wykonaniem operacji wymagającej pełnego modelu obiektowego prezentacji.

{{% alert color="warning" title="Security" %}}
Publiczne metadane mogą ujawniać nazwiska autorów, tytuły, tematy, słowa kluczowe, informacje o firmie, komentarze i niestandardowe wartości. Zaszyfruj wrażliwe właściwości razem z prezentacją. Pozostaw je publiczne tylko wtedy, gdy systemy indeksowania, klasyfikacji, wyszukiwania lub zarządzania dokumentami mają konkretny wymóg dostępu do nich bez hasła.
{{% /alert %}}

## **Aktualizacja właściwości zaszyfrowanej prezentacji**

Dla zaszyfrowanego pliku PPTX, prezentacja załadowana przez przekazanie `true` do [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) jest przeznaczona do odczytu publicznych metadanych. Aspose.Slides nie może zapisać zmienionych właściwości z tego obiektu zawierającego tylko metadane, ponieważ publiczne właściwości muszą pozostać zgodne z odpowiadającymi danymi wewnątrz zaszyfrowanej prezentacji. Aktualizacja wymaga więc poprawnego hasła otwierającego i pełnego załadowania.

Przykład wymaga zaszyfrowanej prezentacji PPTX z publicznymi właściwościami dokumentu i znanym hasłem otwierającym. Otwiera pełną prezentację przy użyciu [LoadOptions::set_Password](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_password/), aktualizuje publiczne wbudowane właściwości i zapisuje wynik. Następnie używa [IPresentationInfo::get_IsEncrypted](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/get_isencrypted/) do weryfikacji, że szyfrowanie zostało zachowane, i ponownie otwiera publiczne metadane bez hasła, aby sprawdzić nowe wartości:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <DOM/LoadOptions.h>
#include <DOM/IProtectionManager.h>
#include <DOM/PresentationFactory.h>
#include <DOM/IPresentationInfo.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

const System::String inputPath = u"public-properties-encrypted.pptx";
const System::String outputPath = u"updated-public-properties-encrypted.pptx";

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(inputPath, loadOptions);

auto documentProperties = presentation->get_DocumentProperties();
documentProperties->set_Title(u"Updated Product Roadmap");
documentProperties->set_Keywords(u"roadmap, planning, indexed");

presentation->Save(outputPath, SaveFormat::Pptx);

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(outputPath);
System::Console::WriteLine(u"The presentation is encrypted: {0}", presentationInfo->get_IsEncrypted());

auto metadataLoadOptions = System::MakeObject<LoadOptions>();
metadataLoadOptions->set_OnlyLoadDocumentProperties(true);

auto metadataPresentation = System::MakeObject<Presentation>(outputPath, metadataLoadOptions);

if (metadataPresentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    System::Console::WriteLine(u"Title: {0}", metadataPresentation->get_DocumentProperties()->get_Title());
    System::Console::WriteLine(u"Keywords: {0}", metadataPresentation->get_DocumentProperties()->get_Keywords());
}
else
{
    System::Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}
```

Jeśli aplikacja nie ma uprawnień do odszyfrowania lub załadowania treści prezentacji, musi traktować publiczne właściwości zaszyfrowanego pliku PPTX jako tylko do odczytu.

## **Dostęp do wbudowanych właściwości**

Interfejs [IDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/) udostępnia wbudowane metadane za pośrednictwem typowanych getterów, w tym [get_Author](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_author/), [get_Title](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_title/) i [get_CreatedTime](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_createdtime/). Ten przykład otwiera istniejącą prezentację i wypisuje jej zapisane metadane w konsoli. Wartości zależą od wejściowej prezentacji; niektóre pola mogą być puste.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"AccessBuiltInProperties.pptx");

auto documentProperties = presentation->get_DocumentProperties();

System::Console::WriteLine(u"Category: {0}", documentProperties->get_Category());
System::Console::WriteLine(u"Content status: {0}", documentProperties->get_ContentStatus());
System::Console::WriteLine(u"Creation date: {0}", documentProperties->get_CreatedTime());
System::Console::WriteLine(u"Author: {0}", documentProperties->get_Author());
System::Console::WriteLine(u"Comments: {0}", documentProperties->get_Comments());
System::Console::WriteLine(u"Keywords: {0}", documentProperties->get_Keywords());
System::Console::WriteLine(u"Last modified by: {0}", documentProperties->get_LastSavedBy());
System::Console::WriteLine(u"Manager: {0}", documentProperties->get_Manager());
System::Console::WriteLine(u"Modified date: {0}", documentProperties->get_LastSavedTime());
System::Console::WriteLine(u"Presentation format: {0}", documentProperties->get_PresentationFormat());
System::Console::WriteLine(u"Last print date: {0}", documentProperties->get_LastPrinted());
System::Console::WriteLine(u"Is shared between producers: {0}", documentProperties->get_SharedDoc());
System::Console::WriteLine(u"Subject: {0}", documentProperties->get_Subject());
System::Console::WriteLine(u"Title: {0}", documentProperties->get_Title());
```

## **Modyfikacja wbudowanych właściwości**

Aby zaktualizować wbudowane metadane, użyj setterów na obiekcie zwróconym przez [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/). Ten przykład otwiera istniejącą prezentację, wywołuje [set_Author](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_author/), [set_Title](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_title/), [set_Subject](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_subject/), [set_Comments](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_comments/) i [set_Manager](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_manager/), a następnie zapisuje zaktualizowaną prezentację przy użyciu [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/). Zapisany plik PPTX zawiera nowe metadane.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"ModifyBuiltInProperties.pptx");

auto documentProperties = presentation->get_DocumentProperties();

documentProperties->set_Author(u"Aspose.Slides for C++");
documentProperties->set_Title(u"Manage PowerPoint Presentation Properties");
documentProperties->set_Subject(u"Modify Built-in Properties");
documentProperties->set_Comments(u"Aspose description");
documentProperties->set_Manager(u"Aspose manager");

presentation->Save(u"DocumentProperties_output.pptx", SaveFormat::Pptx);
```

## **Zarządzanie bazą hiperlinków**

[IDocumentProperties::get_HyperlinkBase](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_hyperlinkbase/) odczytuje bazowy adres dokumentu dla względnych hiperlinków. Jest to przydatne przy przenoszeniu prezentacji i powiązanych plików w inne miejsce. To oddzielna wartość od indywidualnego hiperlinku [IHyperlink::get_ExternalUrl](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_externalurl/): zmiana bazy nie przepisuje zapisanych adresów linków ani nie zmienia ich bezwzględnych celów.

Przykład wymaga prezentacji zawierającej zarówno względny link, np. `target.html`, jak i bezwzględny link, np. `https://example.org/absolute.html`. Odczytuje istniejącą bazę, przypisuje nowy adres bazy przy pomocy [IDocumentProperties::set_HyperlinkBase](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_hyperlinkbase/), zapisuje i ponownie otwiera prezentację, aby sprawdzić wartość. Następnie czyści bazę przy użyciu `u""` i weryfikuje pustą wartość w osobnym zapisanym pliku. Zastąp przykładowy adres bazy lokalizacją swoich powiązanych plików.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"hyperlinks.pptx");

System::Console::WriteLine(u"Original base: {0}", presentation->get_DocumentProperties()->get_HyperlinkBase());

const System::String newBase = u"https://example.com/new/";
presentation->get_DocumentProperties()->set_HyperlinkBase(newBase);
presentation->Save(u"hyperlinks-updated.pptx", SaveFormat::Pptx);

auto updatedPresentation = System::MakeObject<Presentation>(u"hyperlinks-updated.pptx");
System::Console::WriteLine(u"Base preserved: {0}", (updatedPresentation->get_DocumentProperties()->get_HyperlinkBase() == newBase));

updatedPresentation->get_DocumentProperties()->set_HyperlinkBase(u"");
updatedPresentation->Save(u"hyperlinks-cleared.pptx", SaveFormat::Pptx);

auto clearedPresentation = System::MakeObject<Presentation>(u"hyperlinks-cleared.pptx");
System::Console::WriteLine(u"Base cleared: {0}", (clearedPresentation->get_DocumentProperties()->get_HyperlinkBase() == u""));
```

Dwie wiadomości weryfikacyjne powinny wypisać `True`. Czyszczenie bazy pozostawia niezmienione adresy poszczególnych hiperlinków.

Względny link do `target.pptx` otwierał `old/target.pptx`, gdy baza wskazywała na folder `old`. Po zmianie bazy na folder `new`, zapisaniu i ponownym otwarciu prezentacji, ten sam link otworzył `new/target.pptx`. Bezpośredni link nadal otwierał ten sam plik. Przetestuj swoje względne linki w PowerPoint przed i po przeniesieniu prezentacji lub zmianie jej bazy.

## **Dodawanie niestandardowych właściwości prezentacji**

Niestandardowe właściwości przechowują metadane, które nie mają odpowiadającego im pola wbudowanego. [IDocumentProperties::idx_set](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_set/) umożliwia przypisanie wartości przez nazwę właściwości. Ten przykład tworzy prezentację, dodaje dwie wartości tekstowe i jedną wartość wersji całkowitej, a następnie zapisuje prezentację przy użyciu [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/). Przypisanie wartości do istniejącej nazwy zastępuje wartość tej właściwości.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto documentProperties = presentation->get_DocumentProperties();

documentProperties->idx_set(u"Reviewed by", System::ObjectExt::Box<System::String>(u"John Smith"));
documentProperties->idx_set(u"Confidentiality level", System::ObjectExt::Box<System::String>(u"Internal"));
documentProperties->idx_set(u"Document version", System::ObjectExt::Box(2));

presentation->Save(u"CustomDocumentProperties_output.pptx", SaveFormat::Pptx);
```

## **Dostęp i modyfikacja niestandardowych właściwości**

Ten przykład otwiera prezentację zawierającą niestandardowe właściwości i używa [get_CountOfCustomProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_countofcustomproperties/) do iteracji po nich. [GetCustomPropertyName](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/getcustompropertyname/) przyjmuje indeks zerowy i zwraca nazwę używaną przez [IDocumentProperties::idx_get](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_get/) i [idx_set](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_set/). Przykład wypisuje każdą oryginalną nazwę i wartość, zastępuje każdą wartość numerowanym ciągiem niezależnie od pierwotnego typu i zapisuje zmiany. Jeśli nie ma niestandardowych właściwości, pętla nie wprowadza żadnych zmian.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"AccessAndModifyProperties.pptx");

auto documentProperties = presentation->get_DocumentProperties();

for (auto i = 0; i < documentProperties->get_CountOfCustomProperties(); i++)
{
    auto propertyName = documentProperties->GetCustomPropertyName(i);
    auto propertyValue = documentProperties->idx_get(propertyName);

    System::Console::WriteLine(u"Custom property name: {0}", propertyName);
    System::Console::WriteLine(u"Custom property value: {0}", propertyValue);

    documentProperties->idx_set(propertyName, System::ObjectExt::Box(System::String::Format(u"New Value {0}", i + 1)));
}

presentation->Save(u"CustomProperties_output.pptx", SaveFormat::Pptx);
```

## **Przykład na żywo**

Wypróbuj aplikację online [**Wyświetl i edytuj metadane PowerPoint**](https://products.aspose.app/slides/metadata), aby zobaczyć, jak pracować z właściwościami dokumentu przy użyciu API Aspose.Slides:

[![Wyświetl i edytuj metadane PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**Jak mogę usunąć wbudowaną właściwość z prezentacji?**

Wbudowane właściwości są integralną częścią prezentacji i nie mogą być całkowicie usunięte. Można jednak zmienić ich wartości lub ustawić je jako puste, jeśli dana właściwość na to pozwala.

**Co się stanie, jeśli dodam niestandardową właściwość, która już istnieje?**

Jeśli dodasz niestandardową właściwość, która już istnieje, jej bieżąca wartość zostanie nadpisana nową. Nie musisz usuwać ani sprawdzać właściwości wcześniej, ponieważ Aspose.Slides automatycznie aktualizuje wartość właściwości.

**Czy mogę uzyskać dostęp do właściwości prezentacji bez pełnego załadowania prezentacji?**

Tak. Użyj [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/cpp/aspose.slides/presentationfactory/getpresentationinfo/) i następnie [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/), aby odczytać zapisane metadane dokumentu bez tworzenia instancji [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/). Zobacz [Build a Lightweight Presentation Inventory](/slides/pl/cpp/examine-presentation/) po pełny przykład raportowania oraz ograniczenia specyficzne dla formatów.

**Czy mogę odczytać publiczne właściwości zaszyfrowanej prezentacji bez jej hasła otwierającego?**

Tak. Prezentacja musi być zaszyfrowana przez przekazanie `false` do [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/), a musi być załadowana przez przekazanie `true` do [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/).

**Czy mogę zaktualizować zaszyfrowany plik PPTX w trybie tylko-właściwości-dokumentu?**

Nie. Publiczne i zaszyfrowane dane właściwości muszą pozostawać spójne, więc aktualizacja zaszyfrowanego pliku PPTX wymaga pełnego załadowania prezentacji z prawidłowym hasłem otwierającym.