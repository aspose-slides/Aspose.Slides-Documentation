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
description: "Zarządzaj właściwościami prezentacji w Aspose.Slides dla C++ oraz usprawnij wyszukiwanie, branding i przepływ pracy w swoich plikach PowerPoint i OpenDocument."
---
## **Wprowadzenie**

Aspose.Slides obsługuje dwa typy właściwości dokumentu: **Wbudowane** i **Niestandardowe**. Oba te typy właściwości można łatwo odczytywać i zarządzać nimi przy użyciu interfejsu API Aspose.Slides.

Aspose.Slides umożliwia pracę z właściwościami dokumentu prezentacji za pośrednictwem interfejsu [IDocumentProperties](https://reference.aspose.com/slides/pl/cpp/aspose.slides/idocumentproperties/). Instancja tego interfejsu jest zwracana przez [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentation/get_documentproperties/). Poniższe przykłady pokazują, jak odczytywać, modyfikować i zarządzać tymi właściwościami.

{{% alert color="info" title="Uwaga" %}}
Należy pamiętać, że nie można ustawiać wartości w polach **Application** i **Producer**, ponieważ w tych polach zostaną wyświetlone odpowiednio Aspose Ltd. oraz Aspose.Slides for C++ x.x.x.
{{% /alert %}} 

## **Zarządzanie właściwościami prezentacji**

Microsoft PowerPoint udostępnia funkcję umożliwiającą dodawanie niektórych właściwości do plików prezentacji. Te właściwości dokumentu pozwalają przechowywać przydatne informacje razem z dokumentami (plikami prezentacji). Istnieją dwa rodzaje właściwości dokumentu, jak poniżej

- Właściwości systemowe (wbudowane)
- Właściwości definiowane przez użytkownika (niestandardowe)

**Wbudowane** właściwości zawierają ogólne informacje o dokumencie, takie jak tytuł dokumentu, nazwisko autora, statystyki dokumentu itp. **Niestandardowe** właściwości to te definiowane przez użytkowników jako pary **Name/Value**, gdzie zarówno nazwa, jak i wartość są określane przez użytkownika. Korzystając z Aspose.Slides dla C++, programiści mogą odczytywać i modyfikować wartości zarówno wbudowanych, jak i niestandardowych właściwości. Microsoft PowerPoint 2007 umożliwia zarządzanie właściwościami dokumentu plików prezentacji. Wystarczy kliknąć ikonę Office, a następnie pozycję menu **Prepare | Properties | Advanced Properties** w Microsoft PowerPoint 2007. Po wybraniu pozycji **Advanced Properties** pojawi się okno dialogowe umożliwiające zarządzanie właściwościami dokumentu pliku PowerPoint. W **Properties Dialog** można zobaczyć wiele zakładek, takich jak **General, Summary, Statistics, Contents i Custom**. Wszystkie te zakładki umożliwiają konfigurowanie różnych rodzajów informacji związanych z plikami PowerPoint. Zakładka **Custom** służy do zarządzania niestandardowymi właściwościami plików PowerPoint.

## **Odczyt publicznych właściwości z zaszyfrowanej prezentacji**

Hasło otwierające zazwyczaj chroni zarówno zawartość prezentacji, jak i właściwości dokumentu. Gdy prezentacja jest szyfrowana poprzez przekazanie `false` do [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/), jej właściwości dokumentu pozostają publiczne. Aplikacja może wtedy przekazać `true` do [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/pl/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/), aby odczytać publiczne metadane bez podawania hasła otwierającego.

`set_OnlyLoadDocumentProperties` kontroluje, co Aspose.Slides ładuje; nie odszyfrowuje żadnych danych. Jeśli właściwości były objęte szyfrowaniem, ich ładowanie bez hasła kończy się niepowodzeniem. Jeśli prezentacja nie jest szyfrowana, opcja jest ignorowana i ładowana jest cała prezentacja.

Następujący przykład weryfikuje tryb ładowania za pomocą [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/), a następnie odczytuje wbudowane właściwości za pomocą [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentation/get_documentproperties/):

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_OnlyLoadDocumentProperties(true);

auto presentation = MakeObject<Presentation>(u"public-properties-encrypted.pptx", loadOptions);

if (presentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    auto properties = presentation->get_DocumentProperties();

    Console::WriteLine(u"Author: " + properties->get_Author());
    Console::WriteLine(u"Title: " + properties->get_Title());
    Console::WriteLine(u"Keywords: " + properties->get_Keywords());
}
else
{
    Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}

presentation->Dispose();
```

W tym trybie zawartość slajdów nie jest ładowana. Slajdy, mastery, układy, kształty, multimedia i inne obiekty prezentacji są niedostępne. Aplikacje powinny zawsze sprawdzać `get_IsOnlyDocumentPropertiesLoaded` przed wykonaniem operacji wymagającej pełnego modelu obiektowego prezentacji.

{{% alert color="warning" title="Ostrzeżenie" %}}
Należy pamiętać, że publiczne metadane mogą ujawniać nazwiska autorów, tytuły, tematy, słowa kluczowe, informacje o firmie, komentarze oraz wartości niestandardowe. Szyfruj wrażliwe właściwości razem z prezentacją. Pozostaw je publiczne tylko wtedy, gdy systemy indeksowania, klasyfikacji, wyszukiwania lub zarządzania dokumentami mają konkretny wymóg dostępu do nich bez hasła.
{{% /alert %}}

## **Aktualizacja właściwości zaszyfrowanej prezentacji**

Dla zaszyfrowanego pliku PPTX, prezentacja załadowana po wywołaniu `set_OnlyLoadDocumentProperties(true)` służy do odczytu publicznych metadanych. Aspose.Slides nie może zapisać zmienionych właściwości z tego obiektu zawierającego jedynie metadane, ponieważ publiczne właściwości muszą pozostać zgodne z odpowiednimi danymi w zaszyfrowanej prezentacji. Aktualizacja wymaga więc prawidłowego hasła otwierającego i pełnego załadowania.

Następny przykład otwiera prezentację przy użyciu [LoadOptions::set_Password](https://reference.aspose.com/slides/pl/cpp/aspose.slides/loadoptions/set_password/), aktualizuje publiczne wbudowane właściwości i zapisuje wynik. Następnie wykorzystuje [IPresentationInfo::get_IsEncrypted](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentationinfo/get_isencrypted/), aby zweryfikować, że szyfrowanie zostało zachowane, i ponownie otwiera publiczne metadane bez hasła w celu sprawdzenia nowych wartości:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/PresentationFactory.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

const String inputPath = u"public-properties-encrypted.pptx";
const String outputPath = u"updated-public-properties-encrypted.pptx";

{
    auto loadOptions = MakeObject<LoadOptions>();
    loadOptions->set_Password(u"open_password");

    auto presentation = MakeObject<Presentation>(inputPath, loadOptions);
    presentation->get_DocumentProperties()->set_Title(u"Updated Product Roadmap");
    presentation->get_DocumentProperties()->set_Keywords(u"roadmap, planning, indexed");
    presentation->Save(outputPath, SaveFormat::Pptx);
    presentation->Dispose();
}

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(outputPath);
Console::WriteLine(presentationInfo->get_IsEncrypted() ? u"The presentation is encrypted." : u"The presentation is not encrypted.");

auto metadataLoadOptions = MakeObject<LoadOptions>();
metadataLoadOptions->set_OnlyLoadDocumentProperties(true);

auto metadataPresentation = MakeObject<Presentation>(outputPath, metadataLoadOptions);

if (metadataPresentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    Console::WriteLine(u"Title: " + metadataPresentation->get_DocumentProperties()->get_Title());
    Console::WriteLine(u"Keywords: " + metadataPresentation->get_DocumentProperties()->get_Keywords());
}
else
{
    Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}

metadataPresentation->Dispose();
```

Jeśli aplikacja nie ma uprawnień do odszyfrowania lub załadowania zawartości prezentacji, musi traktować publiczne właściwości zaszyfrowanego pliku PPTX jako tylko do odczytu.

## **Dostęp do wbudowanych właściwości**

Te właściwości, udostępniane przez obiekt **IDocumentProperties**, obejmują: **Creator(Author)**, **Description**, **KeyWords**, **Created** (Data utworzenia), **Modified** (Data modyfikacji), **Printed** (Data ostatniego drukowania), **LastModifiedBy**, **Keywords**, **SharedDoc** (Czy współdzielony między różnymi producentami?), **PresentationFormat**, **Subject** oraz **Title**

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **Modyfikacja wbudowanych właściwości**

Modyfikowanie wbudowanych właściwości plików prezentacji jest tak proste, jak ich odczytywanie. Można po prostu przypisać wartość łańcucha znaków do dowolnej żądanej właściwości, a wartość tej właściwości zostanie zmieniona. W poniższym przykładzie pokazaliśmy, jak można modyfikować wbudowane właściwości dokumentu pliku prezentacji.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **Dodawanie niestandardowych właściwości prezentacji**

Aspose.Slides dla C++ umożliwia również programistom dodawanie niestandardowych wartości do właściwości dokumentu prezentacji. Poniżej znajduje się przykład pokazujący, jak ustawić niestandardowe właściwości dla prezentacji.

``` cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Utwórz instancję klasy Presentation
auto presentation = System::MakeObject<Presentation>();

// Pobieranie właściwości dokumentu
auto documentProperties = presentation->get_DocumentProperties();

// Dodawanie własnych właściwości
documentProperties->idx_set(u"New Custom", ObjectExt::Box<int32_t>(12));
documentProperties->idx_set(u"My Name", ObjectExt::Box<String>(u"Mudassir"));
documentProperties->idx_set(u"Custom", ObjectExt::Box<int32_t>(124));

// Pobieranie nazwy właściwości pod określonym indeksem
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// Usuwanie wybranej właściwości
documentProperties->RemoveCustomProperty(getPropertyName);

// Zapisywanie prezentacji
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **Dostęp i modyfikacja niestandardowych właściwości**

Aspose.Slides dla C++ umożliwia również programistom dostęp do wartości niestandardowych właściwości. Poniżej znajduje się przykład, który pokazuje, jak uzyskać dostęp i zmodyfikować wszystkie te niestandardowe właściwości w prezentacji.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **Ustawienie języka korekty**

Aspose.Slides udostępnia właściwość [LanguageId](https://reference.aspose.com/slides/pl/cpp/aspose.slides/baseportionformat/set_languageid/) (udostępnianą przez klasę [PortionFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/portionformat/)), aby umożliwić ustawienie języka korekty dla dokumentu PowerPoint. Język korekty to język, dla którego w PowerPoint sprawdzane są pisownia i gramatyka.

Ten kod C++ pokazuje, jak ustawić język korekty dla PowerPointa:

```c++
#include <DOM/AutoShape.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/IFontData.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"sample.pptx");
System::SharedPtr<AutoShape> autoShape = System::ExplicitCast<AutoShape>(pres->get_Slide(0)->get_Shape(0));

System::SharedPtr<IParagraph> paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
System::SharedPtr<IPortionCollection> portions = paragraph->get_Portions();
portions->Clear();

System::SharedPtr<Portion> newPortion = System::MakeObject<Portion>();

System::SharedPtr<IFontData> font = System::MakeObject<FontData>(u"SimSun");
System::SharedPtr<IPortionFormat> portionFormat = newPortion->get_PortionFormat();
portionFormat->set_ComplexScriptFont(font);
portionFormat->set_EastAsianFont(font);
portionFormat->set_LatinFont(font);

portionFormat->set_LanguageId(u"zh-CN");
// ustaw Id języka korekty

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **Ustawienie domyślnego języka**

Ten kod C++ pokazuje, jak ustawić domyślny język dla całej prezentacji PowerPoint:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
using namespace Aspose::Slides;

System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// Dodaje nowy prostokątny kształt z tekstem
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// Sprawdza język pierwszej części
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **Przykład na żywo**

Wypróbuj aplikację online [**Aspose.Slides Metadata**](https://products.aspose.app/slides/pl/metadata), aby zobaczyć, jak pracować z właściwościami dokumentu za pomocą API Aspose.Slides:

[![Zobacz i edytuj metadane PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/pl/metadata)

## **FAQ**

**Jak mogę usunąć wbudowaną właściwość z prezentacji?**

Wbudowane właściwości są integralną częścią prezentacji i nie mogą być całkowicie usunięte. Można jednak zmienić ich wartości lub ustawić je jako puste, jeśli dana właściwość na to pozwala.

**Co się stanie, jeśli dodam niestandardową właściwość, która już istnieje?**

Jeśli dodasz niestandardową właściwość, która już istnieje, jej istniejąca wartość zostanie nadpisana nową. Nie ma potrzeby usuwania lub sprawdzania właściwości wcześniej, ponieważ Aspose.Slides automatycznie aktualizuje wartość właściwości.

**Czy mogę uzyskać dostęp do właściwości prezentacji bez pełnego ładowania prezentacji?**

Tak. Użyj [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) i następnie [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/), aby odczytać przechowywane metadane dokumentu bez tworzenia instancji [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/). Zobacz [Build a Lightweight Presentation Inventory](/slides/pl/cpp/examine-presentation/) po kompletny przykład raportowania oraz ograniczenia specyficzne dla formatu.

**Czy mogę odczytać publiczne właściwości zaszyfrowanej prezentacji bez jej hasła otwierającego?**

Tak. Prezentacja musi być zaszyfrowana poprzez przekazanie `false` do `set_EncryptDocumentProperties`, a następnie załadowana przy użyciu `true` w `set_OnlyLoadDocumentProperties`.

**Czy mogę zaktualizować zaszyfrowany plik PPTX w trybie tylko-właściwości-dokumentu?**

Nie. Publiczne i zaszyfrowane dane właściwości muszą pozostać zgodne, więc aktualizacja zaszyfrowanego pliku PPTX wymaga pełnego załadowania prezentacji z prawidłowym hasłem otwierającym.