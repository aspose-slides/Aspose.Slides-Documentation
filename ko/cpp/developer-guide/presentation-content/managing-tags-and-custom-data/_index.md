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
- 태그 추가
- 쌍 값
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++에서 태그 및 사용자 정의 데이터를 추가, 읽기, 업데이트 및 제거하는 방법을 배우고, PowerPoint 및 OpenDocument 프레젠테이션 예제를 확인하세요."
---
## **개요**

이 문서는 Aspose.Slides가 PowerPoint 프레젠테이션에서 태그와 사용자 정의 데이터를 어떻게 사용하는지 설명합니다. PPTX 파일에 데이터가 어떻게 저장되는지 간략히 개요를 제공하고, 프레젠테이션별 데이터가 태그와 사용자 정의 XML 부분으로 존재할 수 있음을 언급하며, 태그를 키‑값 문자열 쌍으로 설명합니다.

또한 태그 값을 읽는 방법과 프레젠테이션, 개별 슬라이드 또는 도형에 태그를 추가하는 방법을 보여줍니다. 추가로 모든 태그를 지우기, 이름으로 태그 제거, 태그 이름 목록 검색과 같은 일반적인 태그 관리 작업을 다룹니다.

## **프레젠테이션 파일의 데이터 저장**

PPTX 파일—.pptx 확장자를 가진 항목—은 Office Open XML 사양의 일부인 PresentationML 형식으로 저장됩니다. Office Open XML 형식은 프레젠테이션에 포함된 데이터 구조를 정의합니다.

*슬라이드*는 프레젠테이션 요소 중 하나이며, *슬라이드 파트*는 단일 슬라이드의 내용을 포함합니다. 슬라이드 파트는 ISO/IEC 29500에서 정의된 사용자 정의 태그와 같은 다수의 파트와 명시적 관계를 가질 수 있습니다.

프레젠테이션에 특화된 사용자 정의 데이터는 태그([ITagCollection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itagcollection/))와 CustomXmlParts([ICustomXmlPartCollection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/icustomxmlpartcollection/)) 형태로 존재할 수 있습니다.

{{% alert color="primary" %}} 
태그는 본질적으로 문자열‑키 쌍 값입니다. 
{{% /alert %}} 

## **태그 값 가져오기**

슬라이드에서 태그는 IDocumentProperties.Keywords 속성과 대응합니다. 이 샘플 코드는 Aspose.Slides for C++를 사용하여 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/)에서 태그 값을 가져오는 방법을 보여줍니다:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
System::String keywords = pres->get_DocumentProperties()->get_Keywords();
```

## **프레젠테이션에 태그 추가**

Aspose.Slides를 사용하면 프레젠테이션에 태그를 추가할 수 있습니다. 태그는 일반적으로 두 항목으로 구성됩니다:

- 사용자 정의 속성 이름 - `MyTag`
- 사용자 정의 속성 값 - `My Tag Value`

특정 규칙이나 속성을 기준으로 프레젠테이션을 분류해야 하는 경우 태그를 추가하면 유용합니다. 예를 들어, 북미 국가의 모든 프레젠테이션을 하나로 묶고 싶다면 북미 태그를 만들고 해당 국가(미국, 멕시코, 캐나다)를 값으로 지정할 수 있습니다.

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ITagCollection> tags = pres->get_CustomData()->get_Tags();
pres->get_CustomData()->get_Tags()->idx_set(u"MyTag", u"My Tag Value");
```

태그는 [Slide](https://reference.aspose.com/slides/ko/cpp/aspose.slides/slide/)에도 설정할 수 있습니다:

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
slide->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

또는 개별 [Shape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/shape/)에도 설정할 수 있습니다:

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"My text");
shape->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

### **제한 사항**

`get_CustomData()->get_Tags()`를 사용하여 사용자 정의 데이터 태그 컬렉션에 추가된 태그는 PowerPoint 파일에만 저장됩니다. 프레젠테이션을 PDF로 내보낼 때 이 태그는 PDF 태그 구조로 **전송되지 않습니다**. 따라서 태그로 지정된 사용자 정의 식별자를 태그가 적용된 PDF에서 검색할 수 없습니다.

**우회 방법**: 객체의 **Alt Text**에 사용자 정의 식별자를 저장할 수 있습니다(예: `shape->set_AlternativeText(u"MyId")`). PDF로 내보낸 후 Alt Text가 PDF 태그 구조에 표시될 수 있습니다.

## **FAQ**

**프레젠테이션, 슬라이드 또는 도형에서 모든 태그를 한 번에 제거할 수 있나요?**

예. [tag collection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/tagcollection/)은 [clear](https://reference.aspose.com/slides/ko/cpp/aspose.slides/tagcollection/clear/) 연산을 지원하여 모든 키‑값 쌍을 한 번에 삭제합니다.

**전체 컬렉션을 반복하지 않고 이름으로 단일 태그를 삭제하려면 어떻게 해야 하나요?**

[TagCollection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/tagcollection/)에서 [Remove(name)](https://reference.aspose.com/slides/ko/cpp/aspose.slides/tagcollection/remove/) 연산을 사용하여 키로 태그를 삭제합니다.

**분석 또는 필터링을 위해 태그 이름 전체 목록을 어떻게 가져올 수 있나요?**

[tag collection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/tagcollection/)에서 [GetNamesOfTags](https://reference.aspose.com/slides/ko/cpp/aspose.slides/tagcollection/getnamesoftags/)을 사용하면 모든 태그 이름이 포함된 배열이 반환됩니다.