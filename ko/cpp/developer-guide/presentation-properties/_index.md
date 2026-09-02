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
- 맞춤 속성
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
description: "Aspose.Slides for C++에서 프레젠테이션 속성을 마스터하고 PowerPoint 및 OpenDocument 파일에서 검색, 브랜드 관리 및 워크플로를 간소화합니다."
---
## **소개**

Aspose.Slides는 두 종류의 문서 속성을 지원합니다: **Built-in** 및 **Custom**. 이러한 속성 유형은 Aspose.Slides API를 사용하면 쉽게 액세스하고 관리할 수 있습니다.

Aspose.Slides를 통해 프레젠테이션 문서 속성을 [IDocumentProperties](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_document_properties) 인터페이스로 작업할 수 있습니다. 이 인터페이스의 인스턴스는 [Presentation::get_DocumentProperties](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/get_documentproperties/) 메서드가 반환합니다. 다음 예제에서는 이러한 속성을 읽고, 수정하고, 관리하는 방법을 보여줍니다.

{{% alert color="info" title="Note" %}}
Application 및 Producer 필드에 값을 설정할 수 없습니다. Aspose Ltd.와 Aspose.Slides for C++ x.x.x가 해당 필드에 표시됩니다.
{{% /alert %}} 

## **프레젠테이션 속성 관리**

Microsoft PowerPoint는 프레젠테이션 파일에 일부 속성을 추가하는 기능을 제공합니다. 이러한 문서 속성을 통해 문서(프레젠테이션 파일)와 함께 유용한 정보를 저장할 수 있습니다. 문서 속성에는 다음 두 종류가 있습니다.

- System Defined (Built-in) Properties
- User Defined (Custom) Properties

**Built-in** 속성은 문서 제목, 저자 이름, 문서 통계 등과 같은 일반 정보를 포함합니다. **Custom** 속성은 사용자가 **Name/Value** 쌍으로 정의하는 것으로, 이름과 값 모두 사용자가 정의합니다. Aspose.Slides for C++를 사용하면 내장 속성 및 맞춤 속성 값을 액세스하고 수정할 수 있습니다. Microsoft PowerPoint 2007은 프레젠테이션 파일의 문서 속성을 관리할 수 있는 기능을 제공합니다. Office 아이콘을 클릭하고 **Prepare | Properties | Advanced Properties** 메뉴를 선택하면 됩니다. **Advanced Properties** 메뉴를 선택하면 PowerPoint 파일의 문서 속성을 관리할 수 있는 대화 상자가 나타납니다. **Properties Dialog**에서 **General, Summary, Statistics, Contents, Custom**과 같은 여러 탭을 볼 수 있습니다. 각 탭은 PowerPoint 파일과 관련된 다양한 정보를 구성할 수 있게 합니다. **Custom** 탭은 PowerPoint 파일의 맞춤 속성을 관리하는 데 사용됩니다.

## **내장 속성 액세스**

IDocumentProperties 객체가 노출하는 이러한 속성에는 **Creator(Author)**, **Description**, **KeyWords**, **Created**(Creation Date), **Modified**(Modification Date), **Printed**(Last Print Date), **LastModifiedBy**, **Keywords**, **SharedDoc**(Is shared between different producers?), **PresentationFormat**, **Subject**, **Title** 등이 포함됩니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **내장 속성 수정**

프레젠테이션 파일의 내장 속성을 수정하는 것은 액세스하는 것만큼 간단합니다. 원하는 속성에 문자열 값을 할당하면 속성 값이 수정됩니다. 아래 예제에서는 프레젠테이션 파일의 내장 문서 속성을 어떻게 수정하는지 보여줍니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **맞춤 프레젠테이션 속성 추가**

Aspose.Slides for C++는 개발자가 프레젠테이션 문서 속성에 맞춤 값을 추가하도록 허용합니다. 아래 예제는 프레젠테이션에 맞춤 속성을 설정하는 방법을 보여줍니다.

``` cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Presentation 클래스 인스턴스화
auto presentation = System::MakeObject<Presentation>();

// 문서 속성 가져오기
auto documentProperties = presentation->get_DocumentProperties();

// 맞춤 속성 추가
documentProperties->idx_set(u"New Custom", ObjectExt::Box<int32_t>(12));
documentProperties->idx_set(u"My Name", ObjectExt::Box<String>(u"Mudassir"));
documentProperties->idx_set(u"Custom", ObjectExt::Box<int32_t>(124));

// 특정 인덱스에서 속성 이름 가져오기
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// 선택한 속성 제거
documentProperties->RemoveCustomProperty(getPropertyName);

// 프레젠테이션 저장
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **맞춤 속성 액세스 및 수정**

Aspose.Slides for C++는 개발자가 맞춤 속성 값을 액세스하도록 허용합니다. 아래 예제는 프레젠테이션에 대한 모든 맞춤 속성을 액세스하고 수정하는 방법을 보여줍니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **교정 언어 설정**

Aspose.Slides는 [LanguageId](https://reference.aspose.com/slides/ko/cpp/aspose.slides/baseportionformat/set_languageid/) 속성( [PortionFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/portionformat/) 클래스에서 노출됨)을 제공하여 PowerPoint 문서의 교정 언어를 설정할 수 있습니다. 교정 언어는 PowerPoint에서 맞춤법 및 문법 검사가 수행되는 언어입니다.

다음 C++ 코드는 PowerPoint에 교정 언어를 설정하는 방법을 보여줍니다:

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
// 교정 언어의 ID 설정

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **기본 언어 설정**

다음 C++ 코드는 전체 PowerPoint 프레젠테이션에 대한 기본 언어를 설정하는 방법을 보여줍니다:

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

// 새 사각형 모양을 텍스트와 함께 추가합니다
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// 첫 번째 부분의 언어를 확인합니다
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **실시간 예제**

Aspose.Slides Metadata 온라인 앱을 사용해 보세요:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/ko/metadata)

## **FAQ**

**프레젠테이션에서 내장 속성을 제거할 수 있나요?**

내장 속성은 프레젠테이션의 필수 부분이며 완전히 제거할 수 없습니다. 다만 특정 속성이 허용하는 경우 값을 변경하거나 빈 값으로 설정할 수 있습니다.

**이미 존재하는 맞춤 속성을 추가하면 어떻게 되나요?**

이미 존재하는 맞춤 속성을 추가하면 기존 값이 새 값으로 덮어써집니다. 속성을 미리 제거하거나 확인할 필요가 없으며, Aspose.Slides가 자동으로 속성 값을 업데이트합니다.

**프레젠테이션을 완전히 로드하지 않고 속성에 접근할 수 있나요?**

예. [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/)를 사용한 다음 [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/)를 호출하면 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 인스턴스를 생성하지 않고도 저장된 문서 메타데이터를 읽을 수 있습니다. 전체 보고 예제와 형식별 제한 사항은 [Build a Lightweight Presentation Inventory](/slides/ko/cpp/examine-presentation/)를 참조하세요.