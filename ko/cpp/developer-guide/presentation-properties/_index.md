---
title: C++에서 프레젠테이션 속성 관리
linktitle: 프레젠테이션 속성
type: docs
weight: 70
url: /ko/cpp/presentation-properties/
keywords:
- PowerPoint 속성
- 프레젠테이션 속성
- 문서 속성
- 내장 속성
- 사용자 정의 속성
- 고급 속성
- 속성 관리
- 속성 수정
- 문서 메타데이터
- 메타데이터 편집
- 교정 언어
- 기본 언어
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++에서 프레젠테이션 속성을 마스터하고 PowerPoint 및 OpenDocument 파일에서 검색, 브랜드 관리 및 작업 흐름을 간소화합니다."
---
## **소개**

Aspose.Slides는 두 가지 유형의 문서 속성을 지원합니다: **Built-in** 및 **Custom**. 이러한 속성 유형은 Aspose.Slides API를 사용하여 쉽게 액세스하고 관리할 수 있습니다.

Aspose.Slides를 사용하면 [IDocumentProperties](https://reference.aspose.com/slides/ko/cpp/aspose.slides/idocumentproperties/) 인터페이스를 통해 프레젠테이션 문서 속성을 사용할 수 있습니다. 이 인터페이스의 인스턴스는 [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipresentation/get_documentproperties/)에서 반환됩니다. 다음 예제에서는 이러한 속성을 읽고, 수정하고, 관리하는 방법을 보여줍니다.

{{% alert color="info" title="참고" %}}
다음 사항을 유의하시기 바랍니다. **Application** 및 **Producer** 필드에 값을 설정할 수 없습니다. 해당 필드에는 Aspose Ltd.와 Aspose.Slides for C++ x.x.x가 표시됩니다.
{{% /alert %}} 

## **프레젠테이션 속성 관리**

Microsoft PowerPoint는 프레젠테이션 파일에 몇 가지 속성을 추가하는 기능을 제공합니다. 이러한 문서 속성을 통해 문서(프레젠테이션 파일)와 함께 유용한 정보를 저장할 수 있습니다. 문서 속성에는 다음과 같이 두 종류가 있습니다

- 시스템 정의 (Built-in) 속성
- 사용자 정의 (Custom) 속성

**Built-in** 속성은 문서 제목, 저자 이름, 문서 통계 등과 같은 일반 정보를 포함합니다. **Custom** 속성은 사용자가 **Name/Value** 쌍으로 정의하는 것으로, 이름과 값 모두 사용자가 정의합니다. Aspose.Slides for C++를 사용하면 개발자는 Built-in 속성과 Custom 속성의 값을 액세스하고 수정할 수 있습니다. Microsoft PowerPoint 2007은 프레젠테이션 파일의 문서 속성을 관리할 수 있게 해줍니다. 수행해야 할 작업은 Office 아이콘을 클릭하고 Microsoft PowerPoint 2007의 **Prepare | Properties | Advanced Properties** 메뉴 항목을 선택하는 것입니다. **Advanced Properties** 메뉴 항목을 선택하면 PowerPoint 파일의 문서 속성을 관리할 수 있는 대화 상자가 나타납니다. **Properties Dialog**에서는 **General, Summary, Statistics, Contents and Custom**과 같은 여러 탭 페이지를 볼 수 있습니다. 이러한 탭 페이지는 PowerPoint 파일과 관련된 다양한 정보를 구성할 수 있게 해줍니다. **Custom** 탭은 PowerPoint 파일의 사용자 정의 속성을 관리하는 데 사용됩니다.

## **암호화된 프레젠테이션에서 공개 속성 읽기**

열기 암호는 일반적으로 프레젠테이션 내용과 문서 속성을 모두 보호합니다. 프레젠테이션을 [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/)에 `false`를 전달하여 암호화하면 해당 문서 속성은 공개 상태로 유지됩니다. 그런 다음 애플리케이션은 [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/ko/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/)에 `true`를 전달하여 열기 암호 없이 공개 메타데이터를 읽을 수 있습니다.

`set_OnlyLoadDocumentProperties`은 Aspose.Slides가 로드하는 항목을 제어합니다; 암호를 해독하지는 않습니다. 속성이 암호화에 포함된 경우 암호 없이 로드하면 실패합니다. 프레젠테이션이 암호화되지 않은 경우 이 옵션은 무시되고 전체 프레젠테이션이 로드됩니다.

다음 예제는 [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/)를 사용하여 로드 모드를 확인한 후 [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipresentation/get_documentproperties/)를 통해 Built-in 속성을 읽습니다:

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

이 모드에서는 슬라이드 내용이 로드되지 않습니다. 슬라이드, 마스터, 레이아웃, 도형, 미디어 및 기타 프레젠테이션 개체를 사용할 수 없습니다. 전체 프레젠테이션 객체 모델이 필요한 작업을 수행하기 전에 애플리케이션은 항상 `get_IsOnlyDocumentPropertiesLoaded`를 확인해야 합니다.

{{% alert color="warning" title="경고" %}}
공개 메타데이터는 저자 이름, 제목, 주제, 키워드, 회사 정보, 댓글 및 사용자 정의 값을 노출할 수 있습니다. 민감한 속성은 프레젠테이션과 함께 암호화하십시오. 인덱싱, 분류, 검색 또는 문서 관리 시스템이 암호 없이 접근해야 하는 특정 요구 사항이 있는 경우에만 공개 상태로 유지하십시오.
{{% /alert %}}

## **암호화된 프레젠테이션 속성 업데이트**

암호화된 PPTX 파일의 경우 `set_OnlyLoadDocumentProperties(true)`를 호출한 후 로드된 프레젠테이션은 공개 메타데이터를 읽기 위한 용도입니다. Aspose.Slides는 해당 메타데이터 전용 개체에서 변경된 속성을 저장할 수 없습니다. 공개 속성은 암호화된 프레젠테이션 내부의 해당 데이터와 일관성을 유지해야 하기 때문입니다. 따라서 속성을 업데이트하려면 올바른 열기 암호와 전체 로드가 필요합니다.

다음 예제는 [LoadOptions::set_Password](https://reference.aspose.com/slides/ko/cpp/aspose.slides/loadoptions/set_password/)를 사용하여 프레젠테이션을 열고, 공개 Built-in 속성을 업데이트한 후 결과를 저장합니다. 그런 다음 [IPresentationInfo::get_IsEncrypted](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipresentationinfo/get_isencrypted/)를 사용하여 암호화가 유지되는지 확인하고, 암호 없이 공개 메타데이터를 다시 열어 새로운 값을 검증합니다:

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

애플리케이션이 프레젠테이션 내용을 해독하거나 로드할 수 없는 경우, 암호화된 PPTX 파일의 공개 속성을 읽기 전용으로 취급해야 합니다.

## **Built-in 속성 액세스**

**IDocumentProperties** 객체를 통해 노출되는 이 속성에는 **Creator(Author)**, **Description**, **KeyWords**, **Created**(생성일), **Modified**(수정일), **Printed**(마지막 인쇄일), **LastModifiedBy**, **Keywords**, **SharedDoc**(다른 제작자와 공유 여부), **PresentationFormat**, **Subject**, **Title**이 포함됩니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **Built-in 속성 수정**

프레젠테이션 파일의 Built-in 속성을 수정하는 것은 액세스하는 것만큼 쉽습니다. 원하는 속성에 문자열 값을 할당하면 해당 속성 값이 변경됩니다. 아래 예제에서는 프레젠테이션 파일의 Built-in 문서 속성을 어떻게 수정할 수 있는지 보여줍니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **사용자 정의 프레젠테이션 속성 추가**

Aspose.Slides for C++는 개발자가 프레젠테이션 문서 속성에 사용자 정의 값을 추가할 수도 있습니다. 아래 예제는 프레젠테이션에 사용자 정의 속성을 설정하는 방법을 보여줍니다.

``` cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Presentation 클래스를 인스턴스화합니다
auto presentation = System::MakeObject<Presentation>();

// 문서 속성 가져오기
auto documentProperties = presentation->get_DocumentProperties();

// 사용자 정의 속성 추가
documentProperties->idx_set(u"New Custom", ObjectExt::Box<int32_t>(12));
documentProperties->idx_set(u"My Name", ObjectExt::Box<String>(u"Mudassir"));
documentProperties->idx_set(u"Custom", ObjectExt::Box<int32_t>(124));

// 특정 인덱스의 속성 이름 가져오기
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// 선택된 속성 제거
documentProperties->RemoveCustomProperty(getPropertyName);

// 프레젠테이션 저장
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **사용자 정의 속성 액세스 및 수정**

Aspose.Slides for C++는 개발자가 사용자 정의 속성 값을 액세스할 수도 있습니다. 아래 예제는 프레젠테이션의 모든 사용자 정의 속성에 액세스하고 수정하는 방법을 보여줍니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **맞춤법 검사 언어 설정**

Aspose.Slides는 [LanguageId](https://reference.aspose.com/slides/ko/cpp/aspose.slides/baseportionformat/set_languageid/) 속성([PortionFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/portionformat/) 클래스에 의해 노출)을 제공하여 PowerPoint 문서의 맞춤법 검사 언어를 설정할 수 있게 합니다. 맞춤법 검사 언어는 PowerPoint에서 맞춤법 및 문법 검사를 수행하는 언어입니다.

다음 C++ 코드는 PowerPoint의 맞춤법 검사 언어를 설정하는 방법을 보여줍니다:

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
// set the Id of a proofing language

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **기본 언어 설정**

다음 C++ 코드는 전체 PowerPoint 프레젠테이션의 기본 언어를 설정하는 방법을 보여줍니다:

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

// 새 텍스트가 있는 사각형 도형을 추가합니다
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// Checks the first portion language
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **실시간 예제**

온라인 앱인 [**Aspose.Slides Metadata**](https://products.aspose.app/slides/ko/metadata)를 사용해 보세요. Aspose.Slides API를 통해 문서 속성을 어떻게 다루는지 확인할 수 있습니다:

[![PowerPoint 메타데이터 보기 및 편집](slides-metadata.png)](https://products.aspose.app/slides/ko/metadata)

## **FAQ**

**프레젠테이션에서 Built-in 속성을 제거하려면 어떻게 해야 하나요?**

Built-in 속성은 프레젠테이션의 필수 요소이므로 완전히 제거할 수 없습니다. 그러나 특정 속성이 허용하는 경우 값을 변경하거나 빈 값으로 설정할 수 있습니다.

**이미 존재하는 사용자 정의 속성을 추가하면 어떻게 되나요?**

이미 존재하는 사용자 정의 속성을 추가하면 기존 값이 새 값으로 덮어쓰여집니다. 속성을 미리 제거하거나 확인할 필요가 없으며, Aspose.Slides가 자동으로 속성 값을 업데이트합니다.

**프레젠테이션을 완전히 로드하지 않고도 속성에 접근할 수 있나요?**

예. [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/)를 사용한 후 [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/)를 호출하면 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 인스턴스를 생성하지 않고 저장된 문서 메타데이터를 읽을 수 있습니다. 전체 보고 예제와 형식별 제한 사항은 [Build a Lightweight Presentation Inventory](/slides/ko/cpp/examine-presentation/)를 참고하십시오.

**암호화된 프레젠테이션의 공개 속성을 열기 암호 없이 읽을 수 있나요?**

예. 프레젠테이션이 `set_EncryptDocumentProperties`에 `false`를 전달하여 암호화되어야 하며, `set_OnlyLoadDocumentProperties`에 `true`를 전달하여 로드되어야 합니다.

**문서 속성 전용 모드에서 암호화된 PPTX 파일을 업데이트할 수 있나요?**

아니오. 공개 속성과 암호화된 속성 데이터는 일관성을 유지해야 하므로, 암호화된 PPTX 파일을 업데이트하려면 올바른 열기 암호와 함께 전체 프레젠테이션을 로드해야 합니다.