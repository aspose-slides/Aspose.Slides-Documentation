---
title: Zarządzanie znacznikami i danymi własnymi w prezentacjach przy użyciu C++
linktitle: Tagi i dane własne
type: docs
weight: 300
url: /pl/cpp/managing-tags-and-custom-data/
keywords:
- właściwości dokumentu
- znacznik
- dane własne
- niestandardowy XML
- niestandardowa część XML
- metadane XML
- ItemId
- dodaj znacznik
- wartości par
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Dowiedz się, jak zarządzać znacznikami i niestandardowymi danymi XML w prezentacjach PowerPoint przy użyciu Aspose.Slides dla C++, w tym jak dodawać, odczytywać, aktualizować, audytować i usuwać niestandardowe części XML."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak Aspose.Slides współpracuje z tagami i danymi własnymi w prezentacjach PowerPoint. Dane specyficzne dla prezentacji mogą być przechowywane jako tagi lub niestandardowe części XML. Tagi są prostymi parami klucz‑wartość typu string, natomiast niestandardowe części XML mogą przechowywać ustrukturyzowane metadane i ładunki XML specyficzne dla aplikacji.

Aspose.Slides udostępnia interfejsy API do dodawania, odczytywania, aktualizowania, audytowania i usuwania niestandardowych części XML na poziomach prezentacji, slajdu i obiektu. Niestandardowe części XML są przydatne przy integracjach, które przechowują informacje takie jak identyfikatory zarządzania dokumentami, stan przepływu pracy, metadane zgodności, dane powiązane z szablonem lub inne ustrukturyzowane dane aplikacji wewnątrz prezentacji.

## **Przechowywanie danych w plikach prezentacji**

Pliki PPTX — pliki z rozszerzeniem `.pptx` — są przechowywane w formacie PresentationML, który jest częścią specyfikacji Office Open XML. Office Open XML definiuje strukturę pakietu i relacje używane do przechowywania treści prezentacji oraz powiązanych danych.

Prezentacja zawiera wiele części połączonych relacjami. Na przykład część slajdu zawiera treść pojedynczego slajdu i może mieć jawne relacje do innych części określone w ISO/IEC 29500.

Dane własne mogą być przechowywane jako tagi ([ITagCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itagcollection/)) lub niestandardowe części XML ([ICustomXmlPartCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icustomxmlpartcollection/)). Oba są dostępne za pośrednictwem interfejsu [`ICustomData`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icustomdata/).

{{% alert color="info" %}}
Tagi przechowują proste pary klucz‑wartość typu string. Niestandardowe części XML przechowują ustrukturyzowane dane XML i mogą być powiązane z prezentacją, slajdem lub kształtem.
{{% /alert %}}

## **Praca z niestandardowymi częściami XML**

Metoda [`ICustomData::get_CustomXmlParts`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icustomdata/get_customxmlparts/) zwraca kolekcję niestandardowych części XML powiązanych z danym obiektem prezentacji. Na przykład:

- `presentation->get_CustomData()->get_CustomXmlParts()` zawiera niestandardowe części XML powiązane z samą prezentacją.
- `slide->get_CustomData()->get_CustomXmlParts()` zawiera niestandardowe części XML powiązane z określonym slajdem.
- `shape->get_CustomData()->get_CustomXmlParts()` zawiera niestandardowe części XML powiązane z określonym kształtem.

Użyj [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/get_allcustomxmlparts/), gdy potrzebujesz przejrzeć wszystkie niestandardowe części XML w prezentacji, niezależnie od tego, z czym są powiązane.

### **Dodaj niestandardową część XML do prezentacji**

Użyj [`ICustomXmlPartCollection::Add`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icustomxmlpartcollection/add/) aby dodać dane XML do kolekcji niestandardowych części XML. XML musi być poprawny i niepusty.

Poniższy przykład dodaje ustrukturyzowane metadane do kolekcji danych niestandardowych na poziomie prezentacji:

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPart.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/guid.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

System::String customXmlContent =
    u"<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
    u"<metadata xmlns=\"urn:example:metadata\">"
        u"<documentId>DOC-1001</documentId>"
        u"<workflowState>Draft</workflowState>"
    u"</metadata>";

auto presentation = System::MakeObject<Presentation>();
auto customXmlPart = presentation->get_CustomData()->get_CustomXmlParts()->Add(customXmlContent);

// Add przypisuje identyfikator automatycznie. Ustaw określony GUID tylko w razie potrzeby.
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"presentation_with_custom_xml.pptx", SaveFormat::Pptx);
```

Metoda `Add` może również przyjmować XML jako tablicę bajtów lub strumień, co jest przydatne, gdy zawartość XML jest już dostępna w formie binarnej.

### **Dodaj niestandardową część XML do slajdu lub kształtu**

Dane XML mogą być powiązane z konkretnym slajdem lub kształtem zamiast z całą prezentacją. Jest to przydatne, gdy metadane opisują tylko jeden obiekt, np. klucz szablonu, zewnętrzny identyfikator rekordu lub informacje o powiązaniu.

Poniższy przykład dodaje jedną niestandardową część XML do slajdu i drugą do kształtu:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

slide->get_CustomData()->get_CustomXmlParts()->Add(
    u"<slideMetadata xmlns=\"urn:example:slides\">"
        u"<templateKey>TitleSlide</templateKey>"
    u"</slideMetadata>");

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 250.0f, 80.0f);

shape->get_TextFrame()->set_Text(u"Customer data");
shape->get_CustomData()->get_CustomXmlParts()->Add(
    u"<shapeMetadata xmlns=\"urn:example:shapes\">"
        u"<recordId>CRM-4281</recordId>"
    u"</shapeMetadata>");

presentation->Save(u"object_custom_xml.pptx", SaveFormat::Pptx);
```

Poziom, na którym część jest dodawana, określa, której kolekcji `get_CustomData()->get_CustomXmlParts()` obiektu zawiera odwołanie do tej części. Dane na poziomie prezentacji są odpowiednie dla metadanych obejmujących cały dokument, dane na poziomie slajdu dla informacji należących do konkretnego slajdu, a dane na poziomie kształtu dla metadanych powiązanych z pojedynczym kształtem.

### **Wylistuj i audytuj wszystkie niestandardowe części XML**

Użyj [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/get_allcustomxmlparts/) aby pobrać wszystkie niestandardowe części XML z prezentacji. Każdy [`ICustomXmlPart`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icustomxmlpart/) udostępnia swój identyfikator, zawartość XML oraz powiązane schematy przestrzeni nazw.

Poniższy przykład wyświetla wszystkie niestandardowe części XML oraz ich schematy przestrzeni nazw:

```cpp
#include <DOM/ICustomXmlPart.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

for (auto customXmlPart : presentation->get_AllCustomXmlParts())
{
    System::Console::WriteLine(System::String(u"ItemId: ") + customXmlPart->get_ItemId().ToString());
    System::Console::WriteLine(u"XML:");
    System::Console::WriteLine(customXmlPart->get_XmlAsString());

    for (auto namespaceSchema : customXmlPart->get_NamespaceSchemas())
    {
        System::Console::WriteLine(System::String(u"Namespace schema: ") + namespaceSchema);
    }

    System::Console::WriteLine();
}
```

`ICustomXmlPart::get_NamespaceSchemas`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icustomxmlpart/get_namespaceschemas/) zwraca schematy XML powiązane z niestandardową częścią XML. Informacje te mogą być przydatne przy audycie prezentacji zawierających XML generowany przez systemy zewnętrzne.

### **Odczyt i aktualizacja zawartości XML oraz ItemId**

Użyj [`ICustomXmlPart::get_XmlAsString`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icustomxmlpart/get_xmlasstring/) i `set_XmlAsString`, aby pracować z XML jako ciągiem UTF‑8, lub [`ICustomXmlPart::get_XmlData`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icustomxmlpart/get_xmldata/) i `set_XmlData`, aby pracować z nieprzetworzonymi bajtami XML. Obie reprezentacje można odczytywać i aktualizować.

Metoda [`ICustomXmlPart::get_ItemId`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icustomxmlpart/get_itemid/) zwraca GUID identyfikujący niestandardową część XML w dokumencie Office Open XML. Identyfikator może być również zmieniony za pomocą `set_ItemId`, gdy integracja wymaga nowego identyfikatora.

Poniższy przykład aktualizuje zawartość XML oraz identyfikator:

```cpp
#include <DOM/ICustomXmlPart.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/guid.h>
#include <system/text/encoding.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto customXmlPart = presentation->get_AllCustomXmlParts()->idx_get(0);

// Read the current XML as text.
auto currentXmlContent = customXmlPart->get_XmlAsString();
System::Console::WriteLine(currentXmlContent);

// Update the XML as a UTF-8 string.
customXmlPart->set_XmlAsString(
    u"<metadata xmlns=\"urn:example:metadata\">"
        u"<documentId>DOC-1001</documentId>"
        u"<workflowState>Approved</workflowState>"
    u"</metadata>");

// XmlData provides the same XML content as raw bytes.
auto customXmlData = customXmlPart->get_XmlData();
System::Console::WriteLine(System::Text::Encoding::get_UTF8()->GetString(customXmlData));

// Replace the identifier when required by the integration.
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"updated_custom_xml.pptx", SaveFormat::Pptx);
```

Przy przypisywaniu XML za pomocą `set_XmlAsString` lub `set_XmlData` podaj poprawny, niepusty XML. Użyj jednej z reprezentacji w zależności od tego, czy aplikacja głównie pracuje z ciągami znaków, czy z danymi bajtowymi.

### **Usunięcie niestandardowej części XML**

Aspose.Slides oferuje kilka sposobów usunięcia niestandardowych danych XML:

- [`ICustomXmlPart::Remove`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icustomxmlpart/remove/) usuwa niestandardową część XML z prezentacji.
- [`ICustomXmlPartCollection::Remove`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icustomxmlpartcollection/remove/) usuwa określoną część z kolekcji niestandardowych części XML.
- [`ICustomXmlPartCollection::RemoveAt`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icustomxmlpartcollection/removeat/) usuwa część pod wskazanym indeksem w kolekcji.
- [`ICustomXmlPartCollection::Clear`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icustomxmlpartcollection/clear/) usuwa wszystkie części z określonej kolekcji.

Poniższy przykład usuwa jedną niestandardową część XML na poziomie prezentacji za pomocą odwołania:

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto customXmlParts = presentation->get_CustomData()->get_CustomXmlParts();

if (customXmlParts->get_Count() > 0)
{
    auto customXmlPart = customXmlParts->idx_get(0);
    customXmlParts->Remove(customXmlPart);
}

presentation->Save(u"custom_xml_removed.pptx", SaveFormat::Pptx);
```

Jeśli już masz obiekt `ICustomXmlPart` i chcesz usunąć tę część z prezentacji, a nie z konkretnej kolekcji, wywołaj `customXmlPart->Remove()`.

Możesz także usunąć element według indeksu:

```cpp
presentation->get_CustomData()->get_CustomXmlParts()->RemoveAt(0);
```

### **Wyczyszczenie wszystkich niestandardowych części XML z kolekcji**

Użyj `Clear`, gdy wszystkie niestandardowe części XML powiązane z danym obiektem prezentacji powinny zostać usunięte.

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->get_Slides()->idx_get(0)->get_CustomData()->get_CustomXmlParts()->Clear();

presentation->Save(u"slide_custom_xml_cleared.pptx", SaveFormat::Pptx);
```

`Clear` wpływa tylko na wybraną kolekcję. Na przykład wyczyszczenie kolekcji slajdu nie usuwa kolekcji na poziomie prezentacji ani kształtu.

Aby usunąć każdą niestandardową część XML w prezentacji, przeiteruj `get_AllCustomXmlParts()` i usuń każdą część:

```cpp
#include <DOM/ICustomXmlPart.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

for (auto customXmlPart : presentation->get_AllCustomXmlParts())
{
    customXmlPart->Remove();
}

presentation->Save(u"all_custom_xml_removed.pptx", SaveFormat::Pptx);
```

### **Obsługa powiązanych lub współdzielonych niestandardowych części XML**

W prezentacji Office Open XML ta sama niestandardowa część XML może być odwoływana z więcej niż jednego obiektu prezentacji. Na przykład istniejący plik może zawierać relacje z wielu slajdów lub kształtów do tej samej podstawowej części XML.

Współdzielona część powinna być traktowana jako jeden obiekt danych z wieloma odwołaniami:

- Aktualizacja przy użyciu `set_XmlAsString`, `set_XmlData` lub `set_ItemId` zmienia podstawową niestandardową część XML, więc zmiana obowiązuje wszędzie, gdzie ta część jest odwoływana.
- `get_ItemId()` może być użyte do zidentyfikowania tej samej niestandardowej części XML podczas audytu kolekcji na poziomie obiektów.
- Usunięcie części z konkretnej kolekcji `get_CustomXmlParts()` usuwa ją z tej kolekcji. Użyj `ICustomXmlPart::Remove()`, gdy sama część ma zostać usunięta z prezentacji.
- Przed usunięciem lub zastąpieniem współdzielonej części, sprawdź kolekcje na poziomie obiektów, aby ustalić, czy inne slajdy lub kształty nadal odwołują się do niej.

Przeciążenia `Add` tworzą nową niestandardową część XML na podstawie treści XML; nie przyjmują istniejącego `ICustomXmlPart`. Dlatego współdzielone relacje najczęściej występują podczas wczytywania prezentacji, które już je zawierają.

Poniższy przykład audytuje kolekcje na poziomie prezentacji, slajdu i kształtu według `ItemId` i raportuje części odwoływane z więcej niż jednego miejsca:

```cpp
#include <algorithm>
#include <vector>
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPart.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/guid.h>
#include <system/string.h>

using namespace Aspose::Slides;

struct CustomXmlReferenceEntry
{
    System::Guid itemId;
    std::vector<System::String> owners;
};

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
std::vector<CustomXmlReferenceEntry> referencesByItemId;

auto registerCustomXmlParts = [&referencesByItemId](
    const System::String& ownerName,
    const System::SharedPtr<ICustomXmlPartCollection>& customXmlParts)
{
    for (int32_t partIndex = 0; partIndex < customXmlParts->get_Count(); ++partIndex)
    {
        auto customXmlPart = customXmlParts->idx_get(partIndex);
        auto itemId = customXmlPart->get_ItemId();

        auto entry = std::find_if(
            referencesByItemId.begin(),
            referencesByItemId.end(),
            [&itemId](const CustomXmlReferenceEntry& referenceEntry)
            {
                return referenceEntry.itemId == itemId;
            });

        if (entry == referencesByItemId.end())
        {
            referencesByItemId.push_back({ itemId, { ownerName } });
        }
        else
        {
            entry->owners.push_back(ownerName);
        }
    }
};

registerCustomXmlParts(u"Presentation", presentation->get_CustomData()->get_CustomXmlParts());

for (int32_t slideIndex = 0; slideIndex < presentation->get_Slides()->get_Count(); ++slideIndex)
{
    auto slide = presentation->get_Slides()->idx_get(slideIndex);
    registerCustomXmlParts(
        System::String::Format(u"Slide {0}", slideIndex + 1),
        slide->get_CustomData()->get_CustomXmlParts());

    for (int32_t shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
    {
        auto shape = slide->get_Shapes()->idx_get(shapeIndex);
        registerCustomXmlParts(
            System::String::Format(u"Slide {0}, shape {1}", slideIndex + 1, shapeIndex),
            shape->get_CustomData()->get_CustomXmlParts());
    }
}

for (const auto& referenceEntry : referencesByItemId)
{
    if (referenceEntry.owners.size() > 1)
    {
        System::Console::WriteLine(
            System::String(u"Shared custom XML part: ") + referenceEntry.itemId.ToString());

        for (const auto& ownerName : referenceEntry.owners)
        {
            System::Console::WriteLine(System::String(u"  Referenced by: ") + ownerName);
        }
    }
}
```

Ten rodzaj audytu jest przydatny przed modyfikacją lub usunięciem niestandardowych danych XML w prezentacjach tworzonych przez systemy zewnętrzne, ponieważ ta sama część metadanych może uczestniczyć w więcej niż jednej relacji.

## **Pobieranie wartości tagów**

W slajdach tag odpowiada właściwości `IDocumentProperties::get_Keywords`. Ten przykładowy kod pokazuje, jak pobrać wartość tagu przy użyciu Aspose.Slides for C++ dla [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/):

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto keywords = presentation->get_DocumentProperties()->get_Keywords();
```

## **Dodawanie tagów do prezentacji**

Aspose.Slides umożliwia dodawanie tagów do prezentacji. Tag zazwyczaj składa się z dwóch elementów:

- nazwy własnej właściwości, na przykład `MyTag`;
- wartości własnej właściwości, na przykład `My Tag Value`.

Jeśli potrzebujesz klasyfikować prezentacje na podstawie określonej reguły lub właściwości, możesz dodać odpowiednie tagi. Na przykład, jeśli chcesz kategoryzować prezentacje z krajów Ameryki Północnej, możesz utworzyć tag „North American” i przypisać jako jego wartość odpowiedni kraj.

Ten przykładowy kod pokazuje, jak dodać tag do [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) przy użyciu Aspose.Slides for C++:

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ITagCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto tags = presentation->get_CustomData()->get_Tags();
tags->idx_set(u"MyTag", u"My Tag Value");
```

Tagi mogą być również ustawiane dla [Slide](https://reference.aspose.com/slides/pl/cpp/aspose.slides/slide/):

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITagCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
slide->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

Lub dla pojedynczego [Shape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/shape/):

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ICustomData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITagCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"My text");
shape->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

### **Ograniczenia**

Tagi dodane za pomocą kolekcji `get_CustomData()->get_Tags()` są przechowywane wyłącznie w pliku PowerPoint. Nie są **przenoszone** do struktury tagów PDF podczas eksportu prezentacji do PDF. W konsekwencji niestandardowy identyfikator przypisany jako tag nie może być odzyskany z otagowanego pliku PDF.

**Obejście**: Możesz przechowywać niestandardowy identyfikator w **Alt Text** obiektu (na przykład `shape->set_AlternativeText(u"MyId")`). Po eksporcie do PDF tekst alternatywny może pojawić się w strukturze tagów PDF.

## **FAQ**

**Czy mogę usunąć wszystkie tagi z prezentacji, slajdu lub kształtu w jednej operacji?**

Tak. [Kolekcja tagów](https://reference.aspose.com/slides/pl/cpp/aspose.slides/tagcollection/) obsługuje operację [Clear](https://reference.aspose.com/slides/pl/cpp/aspose.slides/tagcollection/clear/), która usuwa wszystkie pary klucz‑wartość jednocześnie.

**Jak usunąć pojedynczy tag po nazwie, nie iterując po całej kolekcji?**

Użyj [Remove(name)](https://reference.aspose.com/slides/pl/cpp/aspose.slides/tagcollection/remove/) na [TagCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/tagcollection/), aby usunąć tag po jego kluczu.

**Jak mogę pobrać pełną listę nazw tagów do analizy lub filtrowania?**

Użyj [GetNamesOfTags](https://reference.aspose.com/slides/pl/cpp/aspose.slides/tagcollection/getnamesoftags/) na [kolekcji tagów](https://reference.aspose.com/slides/pl/cpp/aspose.slides/tagcollection/); zwraca ona tablicę wszystkich nazw tagów.

**Jak mogę znaleźć wszystkie niestandardowe części XML, niezależnie od miejsca ich przechowywania?**

Użyj [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/get_allcustomxmlparts/) aby pobrać wszystkie niestandardowe części XML w prezentacji.

**Czy powinienem używać `get_XmlAsString`/`set_XmlAsString` czy `get_XmlData`/`set_XmlData` do aktualizacji niestandardowej części XML?**

Używaj `get_XmlAsString` i `set_XmlAsString`, gdy aplikacja pracuje z tekstem XML w formacie UTF‑8. Używaj `get_XmlData` i `set_XmlData`, gdy XML jest już dostępny jako tablica bajtów lub gdy wygodniejsze jest przetwarzanie binarne. Obie reprezentacje odnoszą się do zawartości XML tej samej niestandardowej części XML.