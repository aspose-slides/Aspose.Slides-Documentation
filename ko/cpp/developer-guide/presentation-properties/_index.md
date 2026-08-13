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
- 사용자 지정 속성
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
description: "Aspose.Slides for C++에서 프레젠테이션 속성을 완벽하게 관리하고 PowerPoint 및 OpenDocument 파일에서 검색, 브랜딩 및 워크플로를 간소화합니다."
---
## **소개**

Aspose.Slides는 두 종류의 문서 속성을 지원합니다: **내장** 및 **사용자 정의**. 이러한 속성 유형은 Aspose.Slides API를 사용하면 쉽게 접근하고 관리할 수 있습니다.

Aspose.Slides는 [IDocumentProperties](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_document_properties) 인터페이스를 통해 프레젠테이션 문서 속성을 작업할 수 있도록 합니다. 이 인터페이스의 인스턴스는 [Presentation::get_DocumentProperties](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/get_documentproperties/) 메서드에 의해 반환됩니다. 다음 예제에서는 이러한 속성을 읽고, 수정하고, 관리하는 방법을 보여줍니다.

{{% alert color="info" %}} 
주의: **Application** 및 **Producer** 필드에 값을 설정할 수 없습니다. 해당 필드에는 Aspose Ltd.와 Aspose.Slides for C++ x.x.x 버전이 표시됩니다.
{{% /alert %}} 

## **프레젠테이션 속성 관리**

Microsoft PowerPoint는 프레젠테이션 파일에 일부 속성을 추가하는 기능을 제공합니다. 이러한 문서 속성은 문서(프레젠테이션 파일)와 함께 유용한 정보를 저장할 수 있게 해줍니다. 문서 속성은 다음 두 가지 종류가 있습니다.

- 시스템 정의(내장) 속성
- 사용자 정의(사용자 지정) 속성

**내장** 속성은 문서 제목, 작성자 이름, 문서 통계 등과 같은 일반 정보를 포함합니다. **사용자 정의** 속성은 사용자가 **이름/값** 쌍으로 정의하는 속성으로, 이름과 값 모두 사용자가 지정합니다. Aspose.Slides for C++를 사용하면 내장 속성뿐만 아니라 사용자 정의 속성의 값도 접근하고 수정할 수 있습니다. Microsoft PowerPoint 2007에서는 프레젠테이션 파일의 문서 속성을 관리할 수 있습니다. Office 아이콘을 클릭한 뒤 **Prepare | Properties | Advanced Properties** 메뉴 항목을 선택하기만 하면 됩니다. **Advanced Properties** 메뉴 항목을 선택하면 PowerPoint 파일의 문서 속성을 관리할 수 있는 대화 상자가 나타납니다. **Properties Dialog**에는 **General**, **Summary**, **Statistics**, **Contents**, **Custom**과 같은 여러 탭이 표시됩니다. 이러한 탭은 PowerPoint 파일과 관련된 다양한 정보를 구성할 수 있게 해줍니다. **Custom** 탭은 PowerPoint 파일의 사용자 정의 속성을 관리하는 데 사용됩니다.

## **내장 속성 접근**

**IDocumentProperties** 객체를 통해 노출되는 이러한 속성에는 **Creator(Author)**, **Description**, **KeyWords**, **Created**(작성 날짜), **Modified**(수정 날짜), **Printed**(마지막 인쇄 날짜), **LastModifiedBy**, **Keywords**, **SharedDoc**(다른 작성자와 공유 여부), **PresentationFormat**, **Subject**, **Title** 등이 포함됩니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **내장 속성 수정**

프레젠테이션 파일의 내장 속성을 수정하는 것은 접근하는 것만큼 쉽습니다. 원하는 속성에 문자열 값을 할당하면 해당 속성 값이 수정됩니다. 아래 예제에서는 프레젠테이션 파일의 내장 문서 속성을 어떻게 수정할 수 있는지 보여줍니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **사용자 정의 프레젠테이션 속성 추가**

Aspose.Slides for C++는 개발자가 프레젠테이션 문서 속성에 사용자 정의 값을 추가할 수 있게 합니다. 아래 예제는 프레젠테이션에 사용자 정의 속성을 설정하는 방법을 보여줍니다.

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

// 사용자 지정 속성 추가
documentProperties->idx_set(u"New Custom", ObjectExt::Box<int32_t>(12));
documentProperties->idx_set(u"My Name", ObjectExt::Box<String>(u"Mudassir"));
documentProperties->idx_set(u"Custom", ObjectExt::Box<int32_t>(124));

// 특정 인덱스의 속성 이름 가져오기
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// 선택한 속성 제거
documentProperties->RemoveCustomProperty(getPropertyName);

// 프레젠테이션 저장
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **사용자 정의 속성 접근 및 수정**

Aspose.Slides for C++는 개발자가 사용자 정의 속성의 값을 접근할 수 있게 합니다. 아래 예제는 프레젠테이션의 모든 사용자 정의 속성을 어떻게 접근하고 수정할 수 있는지 보여줍니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **교정 언어 설정**

Aspose.Slides는 [PortionFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/portionformat/) 클래스에서 노출되는 [LanguageId](https://reference.aspose.com/slides/ko/cpp/aspose.slides/baseportionformat/set_languageid/) 속성을 제공하여 PowerPoint 문서의 교정 언어를 설정할 수 있게 합니다. 교정 언어는 PowerPoint에서 맞춤법 및 문법 검사가 수행되는 언어를 의미합니다.

다음 C++ 코드는 PowerPoint의 교정 언어를 설정하는 방법을 보여줍니다:

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
// 교정 언어의 ID를 설정합니다

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

// 첫 번째 구간의 언어를 확인합니다
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **실시간 예제**

Aspose.Slides API를 사용하여 문서 속성을 작업하는 방법을 확인하려면 온라인 앱 **[Aspose.Slides Metadata](https://products.aspose.app/slides/ko/metadata)**을 사용해 보세요:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/ko/metadata)

## ***FAQ**

### 프레젠테이션에서 내장 속성을 제거할 수 있나요?

내장 속성은 프레젠테이션의 핵심 부분이며 완전히 제거할 수 없습니다. 다만, 특정 속성이 허용하는 경우 해당 값을 변경하거나 빈 값으로 설정할 수 있습니다.

### 이미 존재하는 사용자 정의 속성을 추가하면 어떻게 되나요?

이미 존재하는 사용자 정의 속성을 추가하면 기존 값이 새로운 값으로 덮어쓰여집니다. 별도로 속성을 제거하거나 확인할 필요 없이 Aspose.Slides가 자동으로 속성 값을 업데이트합니다.

### 프레젠테이션을 완전히 로드하지 않고 속성에 접근할 수 있나요?

네, [PresentationFactory](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentationfactory/) 클래스의 `GetPresentationInfo` 메서드를 사용하면 프레젠테이션을 완전히 로드하지 않고도 속성에 접근할 수 있습니다. 그런 다음 [IPresentationInfo](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipresentationinfo/) 인터페이스가 제공하는 `ReadDocumentProperties` 메서드를 활용하여 속성을 효율적으로 읽어 메모리를 절약하고 성능을 향상시킬 수 있습니다.