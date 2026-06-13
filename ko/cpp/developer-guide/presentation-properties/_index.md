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
- 기본 속성
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
description: "Aspose.Slides for C++에서 프레젠테이션 속성을 마스터하고 PowerPoint 및 OpenDocument 파일의 검색, 브랜드화 및 워크플로를 효율화합니다."
---
## **소개**

Aspose.Slides는 두 종류의 문서 속성을 지원합니다: **Built-in** 및 **Custom**. 이러한 속성 유형은 모두 Aspose.Slides API를 사용하여 손쉽게 액세스하고 관리할 수 있습니다.

Aspose.Slides를 사용하면 [IDocumentProperties](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_document_properties) 인터페이스를 통해 프레젠테이션 문서 속성을 작업할 수 있습니다. 이 인터페이스의 인스턴스는 [Presentation::get_DocumentProperties](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/get_documentproperties/) 메서드에 의해 반환됩니다. 다음 예제에서는 이러한 속성을 읽고, 수정하고, 관리하는 방법을 보여줍니다.

{{% alert color="primary" %}} 

참고: **Application** 및 **Producer** 필드에는 값을 설정할 수 없습니다. Aspose Ltd.와 Aspose.Slides for C++ x.x.x가 해당 필드에 표시되기 때문입니다.

{{% /alert %}} 

## **프레젠테이션 속성 관리**

Microsoft PowerPoint는 프레젠테이션 파일에 일부 속성을 추가하는 기능을 제공합니다. 이러한 문서 속성을 통해 문서(프레젠테이션 파일)와 함께 유용한 정보를 저장할 수 있습니다. 문서 속성은 다음과 같이 두 종류가 있습니다

- 시스템 정의 (Built-in) 속성
- 사용자 정의 (Custom) 속성

**Built-in** 속성은 문서 제목, 작성자 이름, 문서 통계 등과 같은 일반 정보를 포함합니다. **Custom** 속성은 사용자가 **Name/Value** 쌍으로 정의하는 속성으로, 이름과 값 모두 사용자가 지정합니다. Aspose.Slides for C++를 사용하면 개발자가 Built-in 속성과 Custom 속성의 값을 액세스하고 수정할 수 있습니다. Microsoft PowerPoint 2007은 프레젠테이션 파일의 문서 속성을 관리할 수 있도록 합니다. 수행해야 할 작업은 Office 아이콘을 클릭한 후 Microsoft PowerPoint 2007의 **Prepare | Properties | Advanced Properties** 메뉴 항목을 선택하는 것입니다. **Advanced Properties** 메뉴 항목을 선택하면 PowerPoint 파일의 문서 속성을 관리할 수 있는 대화 상자가 표시됩니다. **Properties Dialog**에서는 **General, Summary, Statistics, Contents and Custom**과 같은 여러 탭 페이지를 확인할 수 있습니다. 이러한 탭 페이지는 PowerPoint 파일과 관련된 다양한 정보를 구성하도록 허용합니다. **Custom** 탭은 PowerPoint 파일의 사용자 정의 속성을 관리하는 데 사용됩니다.

## **Built-in 속성 액세스**

다음은 **IDocumentProperties** 객체가 노출하는 속성들로, **Creator(Author)**, **Description**, **KeyWords**, **Created** (생성 날짜), **Modified** (수정 날짜), **Printed** (마지막 인쇄 날짜), **LastModifiedBy**, **Keywords**, **SharedDoc** (다른 제작자와 공유되는가?), **PresentationFormat**, **Subject**, 및 **Title**이 포함됩니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **Built-in 속성 수정**

프레젠테이션 파일의 Built-in 속성을 수정하는 것은 접근하는 것만큼 쉽습니다. 원하는 속성에 문자열 값을 할당하면 해당 속성 값이 수정됩니다. 아래 예제에서는 프레젠테이션 파일의 Built-in 문서 속성을 어떻게 수정할 수 있는지 보여줍니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **맞춤 프레젠테이션 속성 추가**

Aspose.Slides for C++를 사용하면 개발자가 프레젠테이션 문서 속성에 사용자 정의 값을 추가할 수 있습니다. 아래 예제에서는 프레젠테이션에 맞춤 속성을 설정하는 방법을 보여줍니다.

``` cpp
// Presentation 클래스 인스턴스화
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

## **맞춤 속성 액세스 및 수정**

Aspose.Slides for C++를 사용하면 개발자가 사용자 정의 속성 값을 액세스할 수도 있습니다. 아래 예제에서는 프레젠테이션의 모든 맞춤 속성을 어떻게 액세스하고 수정할 수 있는지 보여줍니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **교정 언어 설정**

Aspose.Slides는 PowerPoint 문서에 대한 교정 언어를 설정할 수 있도록 [LanguageId](https://reference.aspose.com/slides/ko/cpp/aspose.slides/baseportionformat/set_languageid/) 속성( [PortionFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/portionformat/) 클래스에서 노출됨)을 제공합니다. 교정 언어는 PowerPoint에서 맞춤법 및 문법 검사가 수행되는 언어를 의미합니다.

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(pptxFileName);
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
// 교정 언어의 Id 설정

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **기본 언어 설정**

다음 C++ 코드에서는 전체 PowerPoint 프레젠테이션의 기본 언어를 설정하는 방법을 보여줍니다.

```c++
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

Aspose.Slides API를 사용하여 문서 속성을 다루는 방법을 확인하려면 온라인 앱인 [**Aspose.Slides Metadata**](https://products.aspose.app/slides/ko/metadata)을 사용해 보세요:

[![PowerPoint 메타데이터 보기 및 편집](slides-metadata.png)](https://products.aspose.app/slides/ko/metadata)

## ***FAQ**

**프레젠테이션에서 Built-in 속성을 제거하려면 어떻게 해야 합니까?**

Built-in 속은 프레젠테이션의 필수 요소이며 완전히 제거할 수 없습니다. 다만, 해당 속성이 허용하는 경우 값을 변경하거나 빈 값으로 설정할 수 있습니다.

**이미 존재하는 사용자 정의 속성을 추가하면 어떻게 됩니까?**

이미 존재하는 사용자 정의 속성을 추가하면 기존 값이 새로운 값으로 덮어써집니다. Aspose.Slides가 자동으로 속성 값을 업데이트하므로 사전에 속성을 제거하거나 확인할 필요가 없습니다.

**프레젠테이션을 완전히 로드하지 않고 속성에 접근할 수 있나요?**

예, [PresentationFactory](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentationfactory/) 클래스의 `GetPresentationInfo` 메서드를 사용하면 프레젠테이션을 완전히 로드하지 않고도 속성에 접근할 수 있습니다. 그런 다음 [IPresentationInfo](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipresentationinfo/) 인터페이스에서 제공하는 `ReadDocumentProperties` 메서드를 활용하면 메모리를 절약하고 성능을 향상시키면서 속성을 효율적으로 읽을 수 있습니다.