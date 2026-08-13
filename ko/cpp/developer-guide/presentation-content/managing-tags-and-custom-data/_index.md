---
title: C++를 사용한 프레젠테이션에서 태그 및 사용자 정의 데이터 관리
linktitle: 태그 및 사용자 정의 데이터
type: docs
weight: 300
url: /ko/cpp/managing-tags-and-custom-data/
keywords:
- 문서 속성
- 태그
- 사용자 정의 데이터
- 사용자 정의 XML
- 사용자 정의 XML 파트
- XML 메타데이터
- ItemId
- 태그 추가
- 키-값 쌍
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 프레젠테이션에서 태그와 사용자 정의 XML 데이터를 관리하는 방법을 배우세요. 여기에는 사용자 정의 XML 파트 추가, 읽기, 업데이트, 감사 및 제거가 포함됩니다."
---
## **개요**

이 문서에서는 Aspose.Slides가 PowerPoint 프레젠테이션에서 태그와 사용자 정의 데이터를 어떻게 처리하는지 설명합니다. 프레젠테이션 별 데이터는 태그 또는 사용자 정의 XML 파트로 저장할 수 있습니다. 태그는 간단한 키-값 문자열 쌍이며, 사용자 정의 XML 파트는 구조화된 메타데이터와 애플리케이션 전용 XML 페이로드를 저장할 수 있습니다.

Aspose.Slides는 프레젠테이션, 슬라이드 및 도형 수준에서 사용자 정의 XML 파트를 추가, 읽기, 업데이트, 감사 및 제거하는 API를 제공합니다. 사용자 정의 XML 파트는 문서 관리 식별자, 워크플로 상태, 규정 준수 메타데이터, 템플릿 바인딩 데이터 또는 프레젠테이션 내부의 기타 구조화된 애플리케이션 데이터를 저장하는 통합에 유용합니다.

## **프레젠테이션 파일의 데이터 저장**

PPTX 파일(`.pptx` 확장자를 가진 파일)은 Office Open XML 사양의 일부인 PresentationML 형식으로 저장됩니다. Office Open XML은 프레젠테이션 콘텐츠와 관련 데이터를 저장하기 위해 사용되는 패키지 구조와 관계를 정의합니다.

프레젠테이션은 관계에 의해 연결된 여러 파트로 구성됩니다. 예를 들어, 슬라이드 파트는 단일 슬라이드의 내용을 포함하며 ISO/IEC 29500에 정의된 다른 파트와 명시적인 관계를 가질 수 있습니다.

사용자 정의 데이터는 태그([ITagCollection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itagcollection/)) 또는 사용자 정의 XML 파트([ICustomXmlPartCollection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/icustomxmlpartcollection/))로 저장할 수 있습니다. 두 가지 모두 [`ICustomData`](https://reference.aspose.com/slides/ko/cpp/aspose.slides/icustomdata/) 인터페이스를 통해 사용할 수 있습니다.

{{% alert color="info" %}}
태그는 간단한 문자열 키-값 쌍을 저장합니다. 사용자 정의 XML 파트는 구조화된 XML 데이터를 저장하며 프레젠테이션, 슬라이드 또는 도형에 연결될 수 있습니다.
{{% /alert %}}

## **사용자 정의 XML 파트 작업**

[`ICustomData::get_CustomXmlParts`](https://reference.aspose.com/slides/ko/cpp/aspose.slides/icustomdata/get_customxmlparts/) 메서드는 특정 프레젠테이션 객체와 연결된 사용자 정의 XML 파트 컬렉션을 반환합니다. 예시:

- `presentation->get_CustomData()->get_CustomXmlParts()` 에는 프레젠테이션 자체와 연결된 사용자 정의 XML 파트가 포함됩니다.
- `slide->get_CustomData()->get_CustomXmlParts()` 에는 특정 슬라이드와 연결된 사용자 정의 XML 파트가 포함됩니다.
- `shape->get_CustomData()->get_CustomXmlParts()` 에는 특정 도형과 연결된 사용자 정의 XML 파트가 포함됩니다.

`[`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/get_allcustomxmlparts/)` 를 사용하면 파트가 어디에 연결되어 있는지에 관계없이 프레젠테이션의 모든 사용자 정의 XML 파트를 검사할 수 있습니다.

### **프레젠테이션에 사용자 정의 XML 파트 추가**

[`ICustomXmlPartCollection::Add`](https://reference.aspose.com/slides/ko/cpp/aspose.slides/icustomxmlpartcollection/add/) 를 사용하여 XML 데이터를 사용자 정의 XML 파트 컬렉션에 추가합니다. XML은 유효하고 비어 있지 않아야 합니다.

다음 예제는 프레젠테이션 수준 사용자 정의 데이터 컬렉션에 구조화된 메타데이터를 추가합니다:

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

// Add는 식별자를 자동으로 할당합니다. 필요할 때만 특정 GUID를 설정하십시오.
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"presentation_with_custom_xml.pptx", SaveFormat::Pptx);
```

`Add` 메서드는 XML을 바이트 배열이나 스트림으로도 받아들일 수 있으며, XML 콘텐츠가 이미 바이너리 형태로 존재할 때 유용합니다.

### **슬라이드 또는 도형에 사용자 정의 XML 파트 추가**

사용자 정의 XML 데이터는 전체 프레젠테이션이 아니라 특정 슬라이드 또는 도형에 연결될 수 있습니다. 이는 메타데이터가 템플릿 키, 외부 레코드 식별자 또는 바인딩 정보와 같이 하나의 객체만을 설명할 때 유용합니다.

다음 예제는 슬라이드에 하나의 사용자 정의 XML 파트를, 도형에 또 하나를 추가합니다:

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

파트를 추가하는 수준에 따라 해당 파트와의 관계를 포함하는 객체의 `get_CustomData()->get_CustomXmlParts()` 컬렉션이 결정됩니다. 프레젠테이션 수준 데이터는 문서 전체 메타데이터에 적합하고, 슬라이드 수준 데이터는 특정 슬라이드에 속하는 정보를, 도형 수준 데이터는 개별 도형에 연결된 메타데이터에 적합합니다.

### **모든 사용자 정의 XML 파트 나열 및 감사**

[`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/get_allcustomxmlparts/) 를 사용하여 프레젠테이션에서 모든 사용자 정의 XML 파트를 검색합니다. 각 [`ICustomXmlPart`](https://reference.aspose.com/slides/ko/cpp/aspose.slides/icustomxmlpart/) 은 식별자, XML 콘텐츠 및 연관된 네임스페이스 스키마를 공개합니다.

다음 예제는 모든 사용자 정의 XML 파트와 그 네임스페이스 스키마를 나열합니다:

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

`[`ICustomXmlPart::get_NamespaceSchemas`](https://reference.aspose.com/slides/ko/cpp/aspose.slides/icustomxmlpart/get_namespaceschemas/)` 은 사용자 정의 XML 파트와 연관된 XML 스키마를 반환합니다. 이 정보는 외부 시스템에서 생성된 XML을 포함하는 프레젠테이션을 감사할 때 유용합니다.

### **XML 콘텐츠 및 ItemId 읽기 및 업데이트**

[`ICustomXmlPart::get_XmlAsString`](https://reference.aspose.com/slides/ko/cpp/aspose.slides/icustomxmlpart/get_xmlasstring/) 와 `set_XmlAsString` 을 사용하여 XML을 UTF-8 문자열로 작업하거나, `[`ICustomXmlPart::get_XmlData`](https://reference.aspose.com/slides/ko/cpp/aspose.slides/icustomxmlpart/get_xmldata/) 와 `set_XmlData` 를 사용하여 원시 XML 바이트를 작업합니다. 두 표현 모두 읽고 업데이트할 수 있습니다.

[`ICustomXmlPart::get_ItemId`](https://reference.aspose.com/slides/ko/cpp/aspose.slides/icustomxmlpart/get_itemid/) 메서드는 Office Open XML 문서에서 사용자 정의 XML 파트를 식별하는 GUID를 반환합니다. 통합에서 새 식별자가 필요할 경우 `set_ItemId` 로 식별자를 변경할 수도 있습니다.

다음 예제는 XML 콘텐츠와 식별자를 업데이트합니다:

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

// 현재 XML을 텍스트로 읽습니다.
auto currentXmlContent = customXmlPart->get_XmlAsString();
System::Console::WriteLine(currentXmlContent);

// XML을 UTF-8 문자열로 업데이트합니다.
customXmlPart->set_XmlAsString(
    u"<metadata xmlns=\"urn:example:metadata\">"
        u"<documentId>DOC-1001</documentId>"
        u"<workflowState>Approved</workflowState>"
    u"</metadata>");

// XmlData는 동일한 XML 콘텐츠를 원시 바이트 형태로 제공합니다.
auto customXmlData = customXmlPart->get_XmlData();
System::Console::WriteLine(System::Text::Encoding::get_UTF8()->GetString(customXmlData));

// 통합에서 필요할 경우 식별자를 교체합니다.
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"updated_custom_xml.pptx", SaveFormat::Pptx);
```

`set_XmlAsString` 또는 `set_XmlData` 로 XML을 할당할 때는 유효하고 비어 있지 않은 XML을 제공하십시오. 애플리케이션이 주로 문자열로 작업하는지 바이트 데이터로 작업하는지에 따라 하나의 표현을 사용하십시오.

### **사용자 정의 XML 파트 제거**

Aspose.Slides는 사용자 정의 XML 데이터를 제거하는 여러 방법을 제공합니다:

- `[`ICustomXmlPart::Remove`](https://reference.aspose.com/slides/ko/cpp/aspose.slides/icustomxmlpart/remove/)` 은 프레젠테이션에서 사용자 정의 XML 파트를 제거합니다.
- `[`ICustomXmlPartCollection::Remove`](https://reference.aspose.com/slides/ko/cpp/aspose.slides/icustomxmlpartcollection/remove/)` 은 사용자 정의 XML 파트 컬렉션에서 특정 파트를 제거합니다.
- `[`ICustomXmlPartCollection::RemoveAt`](https://reference.aspose.com/slides/ko/cpp/aspose.slides/icustomxmlpartcollection/removeat/)` 은 지정된 컬렉션 인덱스에 있는 파트를 제거합니다.
- `[`ICustomXmlPartCollection::Clear`](https://reference.aspose.com/slides/ko/cpp/aspose.slides/icustomxmlpartcollection/clear/)` 은 특정 컬렉션의 모든 파트를 제거합니다.

다음 예제는 참조를 통해 하나의 프레젠테이션 수준 사용자 정의 XML 파트를 제거합니다:

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

`ICustomXmlPart` 를 이미 보유하고 있고 특정 컬렉션을 지정하지 않으며 프레젠테이션에서 해당 파트를 제거하려면 `customXmlPart->Remove()` 를 호출하십시오.

인덱스로 항목을 제거할 수도 있습니다:

```cpp
presentation->get_CustomData()->get_CustomXmlParts()->RemoveAt(0);
```

### **컬렉션에서 모든 사용자 정의 XML 파트 삭제**

특정 프레젠테이션 객체와 연결된 모든 사용자 정의 XML 파트를 제거해야 할 경우 `Clear` 를 사용합니다.

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

`Clear` 는 선택된 컬렉션에만 영향을 미칩니다. 예를 들어, 슬라이드의 컬렉션을 비우는 것은 프레젠테이션 수준 또는 도형 수준 컬렉션을 비우지 않습니다.

프레젠테이션의 모든 사용자 정의 XML 파트를 제거하려면 `get_AllCustomXmlParts()` 를 반복하면서 각 파트를 제거하십시오:

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

### **연결되거나 공유된 사용자 정의 XML 파트 처리**

Office Open XML 프레젠테이션에서는 동일한 사용자 정의 XML 파트가 둘 이상의 프레젠테이션 객체에서 참조될 수 있습니다. 예를 들어, 기존 파일은 여러 슬라이드 또는 도형에서 동일한 기본 사용자 정의 XML 파트로의 관계를 포함할 수 있습니다.

공유 파트는 여러 참조를 가진 하나의 데이터 객체로 취급해야 합니다:

- `set_XmlAsString`, `set_XmlData` 또는 `set_ItemId` 로 업데이트하면 기본 사용자 정의 XML 파트가 변경되며, 해당 파트를 참조하는 모든 곳에 변경 사항이 적용됩니다.
- `get_ItemId()` 는 객체 수준 컬렉션을 감사할 때 동일한 사용자 정의 XML 파트를 식별하는 데 사용할 수 있습니다.
- 특정 `get_CustomXmlParts()` 컬렉션에서 파트를 제거하면 해당 컬렉션에서만 제거됩니다. 파트 자체를 프레젠테이션에서 제거해야 할 경우 `ICustomXmlPart::Remove()` 를 사용하십시오.
- 공유 파트를 삭제하거나 교체하기 전에 객체 수준 컬렉션을 검사하여 다른 슬라이드나 도형이 여전히 해당 파트를 참조하고 있는지 확인하십시오.

`Add` 오버로드는 XML 콘텐츠로부터 새로운 사용자 정의 XML 파트를 생성하며 기존 `ICustomXmlPart` 를 받아들이지 않습니다. 따라서 공유 관계는 이미 해당 파트를 포함하고 있는 프레젠테이션을 로드할 때 가장 흔히 발생합니다.

다음 예제는 `ItemId` 로 프레젠테이션, 슬라이드 및 도형 수준 컬렉션을 감사하고 하나 이상의 위치에서 참조되는 파트를 보고합니다:

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

이러한 감사는 외부 시스템에서 만든 프레젠테이션의 사용자 정의 XML 데이터를 수정하거나 삭제하기 전에 유용합니다. 동일한 메타데이터 파트가 둘 이상의 관계에 참여할 수 있기 때문입니다.

## **태그 값 가져오기**

슬라이드에서 태그는 `IDocumentProperties::get_Keywords` 속성에 해당합니다. 이 샘플 코드는 Aspose.Slides for C++를 사용하여 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/)에서 태그 값을 가져오는 방법을 보여줍니다:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto keywords = presentation->get_DocumentProperties()->get_Keywords();
```

## **프레젠테이션에 태그 추가**

Aspose.Slides를 사용하면 프레젠테이션에 태그를 추가할 수 있습니다. 태그는 일반적으로 두 항목으로 구성됩니다:

- 예를 들어, `MyTag` 와 같은 사용자 정의 속성 이름;
- 예를 들어, `My Tag Value` 와 같은 사용자 정의 속성 값.

특정 규칙이나 속성을 기반으로 프레젠테이션을 분류해야 하는 경우 해당 목적을 위해 태그를 추가할 수 있습니다. 예를 들어, 북미 국가의 프레젠테이션을 분류하려면 북미 태그를 만들고 해당 국가를 값으로 지정하면 됩니다.

다음 샘플 코드는 Aspose.Slides for C++를 사용하여 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/)에 태그를 추가하는 방법을 보여줍니다:

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ITagCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto tags = presentation->get_CustomData()->get_Tags();
tags->idx_set(u"MyTag", u"My Tag Value");
```

태그는 [Slide](https://reference.aspose.com/slides/ko/cpp/aspose.slides/slide/)에 대해서도 설정할 수 있습니다:

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

또는 개별 [Shape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/shape/)에 대해 설정할 수 있습니다:

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

### **제한 사항**

`get_CustomData()->get_Tags()` 컬렉션을 통해 추가된 태그는 PowerPoint 파일에만 저장됩니다. 프레젠테이션을 PDF로 내보낼 때 태그 구조로 **전송되지** 않습니다. 따라서 태그로 할당된 사용자 정의 식별자는 태그가 지정된 PDF에서 검색할 수 없습니다.

**우회 방법**: 객체의 **Alt Text** 에 사용자 정의 식별자를 저장할 수 있습니다(예: `shape->set_AlternativeText(u\"MyId\")`). PDF로 내보낸 후 Alt Text가 PDF 태그 구조에 나타날 수 있습니다.

## **FAQ**

**프레젠테이션, 슬라이드 또는 도형에서 모든 태그를 한 번에 제거할 수 있나요?**

예. [tag collection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/tagcollection/) 은 모든 키-값 쌍을 한 번에 삭제하는 [Clear](https://reference.aspose.com/slides/ko/cpp/aspose.slides/tagcollection/clear/) 작업을 지원합니다.

**전체 컬렉션을 반복하지 않고 이름으로 단일 태그를 삭제하려면 어떻게 해야 하나요?**

[TagCollection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/tagcollection/) 에서 [Remove(name)](https://reference.aspose.com/slides/ko/cpp/aspose.slides/tagcollection/remove/) 를 사용하여 키로 태그를 삭제합니다.

**분석 또는 필터링을 위해 태그 이름 전체 목록을 가져오려면 어떻게 해야 하나요?**

[tag collection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/tagcollection/) 에서 [GetNamesOfTags](https://reference.aspose.com/slides/ko/cpp/aspose.slides/tagcollection/getnamesoftags/) 를 사용하면 모든 태그 이름의 배열을 반환합니다.

**저장 위치와 관계없이 모든 사용자 정의 XML 파트를 찾으려면 어떻게 해야 하나요?**

[`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/get_allcustomxmlparts/) 을 사용하여 프레젠테이션의 모든 사용자 정의 XML 파트를 검색합니다.

**사용자 정의 XML 파트를 업데이트할 때 `get_XmlAsString`/`set_XmlAsString` 와 `get_XmlData`/`set_XmlData` 중 어느 것을 사용해야 하나요?**

애플리케이션이 UTF-8 XML 텍스트로 작업할 경우 `get_XmlAsString` 과 `set_XmlAsString` 을 사용하십시오. XML이 이미 바이트 배열 형태이거나 바이너리 중심 처리가 더 편리한 경우 `get_XmlData` 와 `set_XmlData` 를 사용하십시오. 두 표현 모두 동일한 사용자 정의 XML 파트의 XML 콘텐츠를 나타냅니다.