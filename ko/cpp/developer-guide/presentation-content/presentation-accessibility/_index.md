---
title: C++에서 프레젠테이션 접근성 관리
linktitle: 프레젠테이션 접근성
type: docs
weight: 30
url: /ko/cpp/presentation-accessibility/
keywords:
- 프레젠테이션 접근성
- 대체 텍스트
- 대체 텍스트 제목
- 대체 텍스트 설명
- 장식으로 표시
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PPT, PPTX 및 ODP 파일의 프레젠테이션 접근성 검사를 자동화하고 스크린 리더 경험을 향상시키며 컴플라이언스를 높입니다."
---
## **소개**

대체 텍스트는 보조 기술을 사용하는 사람들이 이미지, 차트 및 기타 정보성 도형의 의미를 이해하도록 돕습니다. 이 문서에서는 Aspose.Slides for C++를 사용하여 대체 텍스트 제목과 설명을 읽고 업데이트하는 방법, 코드에서 사용되는 도형 이름과 접근성 설명을 구분하는 방법, 그리고 도형이 장식용으로 표시되었는지 확인하는 방법을 설명합니다.

이러한 기능은 프레젠테이션 접근성을 지원하지만 보장을 의미하지는 않습니다. 읽기 순서, 색상 대비, 텍스트 가독성 및 기타 접근성 요구 사항도 검토해야 합니다.

## **대체 텍스트 제목 및 설명 관리**

대체 텍스트를 사용하여 이미지를 볼 수 없는 사람들에게 이미지, 차트 및 기타 정보성 도형의 의미를 설명합니다. 다음 속성은 각각 다른 용도로 사용됩니다.

| 속성 또는 내용 | 목적 |
| --- | --- |
| [AlternativeTextTitle](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/get_alternativetexttitle/) | 대체 설명에 대한 짧은 제목입니다. |
| [AlternativeText](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/get_alternativetext/) | 슬라이드 컨텍스트에서 도형의 콘텐츠 또는 목적에 대한 의미 있는 설명입니다. |
| [Name](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/get_name/) | 프레젠테이션에서 특정 도형을 찾기 위해 코드가 사용할 수 있는 도형 이름입니다. |
| Visible text | 도형 텍스트나 차트 제목 및 라벨과 같이 슬라이드에 표시되는 콘텐츠입니다. 대체 텍스트를 업데이트해도 이 콘텐츠는 변경되지 않습니다. |

프레젠테이션을 템플릿으로 재사용할 때 코드는 [Name](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/get_name/)을 사용해 도형을 찾은 후 업데이트할 수 있습니다. 이 이름은 시각적 내용이 독자에게 전달되는 방식을 설명하는 대체 텍스트와 다른 목적을 가집니다. 이름으로 검색하면 저자는 설명을 수정하거나 번역하면서 코드는 도형을 동일하게 찾을 수 있습니다. 이름은 편집 가능하고 고유성을 보장하지 않으므로 해당 이름이 원하는 도형과 일치하는지 확인하십시오. 자세한 내용은 [Identify and Find Shapes](/slides/ko/cpp/shape-manipulations/#identify-and-find-shapes)를 참조하세요.

다음 예제는 첫 번째 슬라이드 첫 번째 도형으로 사무실 입구 이미지가 포함된 `input.pptx` 파일이 필요합니다. 해당 이미지는 장식용으로 표시되지 않아야 합니다. 예제는 현재 대체 텍스트 제목과 설명을 읽고 출력한 뒤 두 값을 업데이트하고 프레젠테이션을 `output.pptx`로 저장합니다. 실제 이미지와 전달하려는 정보를 반영하도록 문구를 조정하십시오.

```cpp
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

Console::WriteLine(u"Alternative text title: {0}", shape->get_AlternativeTextTitle());
Console::WriteLine(u"Alternative text description: {0}", shape->get_AlternativeText());

shape->set_AlternativeTextTitle(u"Office entrance");
shape->set_AlternativeText(u"The office entrance has a wheelchair ramp to the right of the steps.");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

대체 텍스트만 추가한다고 해서 프레젠테이션 접근성이나 접근성 표준 준수가 보장되는 것은 아닙니다. 설명의 정확성과 적절성을 검토하고, 읽기 순서, 색상 대비, 가독성 텍스트 및 기타 접근성 요구 사항도 확인하십시오. 정보성 시각 자료는 장식용으로 표시되지 않아야 하며, 다음 섹션에서는 [IsDecorative](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/get_isdecorative/)를 읽는 방법을 보여줍니다.

## **장식으로 표시**

장식으로 표시 플래그는 순수 장식용 시각 자료에 설정하여 스크린 리더가 이를 건너뛰게 하여 잡음을 줄이고 의미 있는 콘텐츠에 집중하도록 합니다. 배경, 장식 요소, 간격용 도형 등에 적용하고 차트, 아이콘 또는 정보를 전달하는 이미지에는 절대 사용하지 마십시오. Aspose.Slides는 이 플래그를 감지 및 검증할 수 있도록 제공하므로 자동 접근성 검사와 정리 작업에 활용할 수 있습니다.

![장식으로 표시](mark_as_decorative.png)

다음 코드 샘플은 도형이 장식용으로 표시되었는지 확인하는 방법을 보여줍니다.

```cpp
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);
Console::WriteLine(u"Is shape decorative: {0}", shape->get_IsDecorative());

presentation->Dispose();
```

## **FAQ**

**대체 텍스트 제목과 설명에 무엇을 넣어야 하나요?**

주제를 식별할 수 있는 짧은 제목을 사용하고, 해당 시각 자료가 슬라이드 컨텍스트에서 전달하는 정보를 설명하는 내용을 설명에 포함합니다. 차트의 경우 단순히 “차트”라고 적는 대신 관련 추세나 비교를 설명하십시오.

**템플릿에서 도형을 찾을 때 대체 텍스트를 사용해야 하나요?**

가능하면 [Name](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/get_name/)을 사용해 도형을 찾고, 기대하는 도형인지 확인하십시오. 대체 텍스트는 편집되거나 번역될 수 있어 정확한 설명을 검색하는 코드를 깨뜨릴 수 있습니다. 자세한 내용은 [Identify and Find Shapes](/slides/ko/cpp/shape-manipulations/)를 참고하세요.

**언제 도형을 장식용으로 표시해야 하나요?**

정보를 추가하지 않는 순수 장식용 시각 자료, 예를 들어 장식적인 플러시 등을 위해 장식 플래그를 사용합니다. 의미를 전달하는 이미지와 차트는 적절한 설명이 필요합니다.

**대체 텍스트를 추가하면 프레젠테이션이 완전히 접근 가능해지나요?**

아니요. 대체 텍스트는 접근성의 일부만 다룹니다. 읽기 순서, 색상 대비, 텍스트 가독성 및 기타 적용 가능한 요구 사항도 검토해야 하며, 이 속성들만 설정한다고 해서 준수가 보장되는 것은 아닙니다.