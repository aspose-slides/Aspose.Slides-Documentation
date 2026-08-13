---
title: C++에서 폴백 글꼴을 사용한 프레젠테이션 렌더링
linktitle: 프레젠테이션 렌더링
type: docs
weight: 30
url: /ko/cpp/render-presentation-with-fallback-font/
keywords:
- 폴백 글꼴
- PowerPoint 렌더링
- 프레젠테이션 렌더링
- 슬라이드 렌더링
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++에서 폴백 글꼴을 사용해 프레젠테이션을 렌더링합니다 – 단계별 C++ 코드 샘플을 통해 PPT, PPTX 및 ODP 전반에 걸쳐 텍스트 일관성을 유지합니다."
---
## **개요**

Aspose.Slides는 폴백 글꼴 규칙을 사용하여 프레젠테이션을 렌더링할 수 있게 합니다. 이 문서에서는 폴백 글꼴 규칙 컬렉션을 만들고, 폴백 글꼴을 제거하거나 추가하여 규칙을 수정하고, `FontsManager::set_FontFallBackRulesCollection` 메서드를 사용하여 컬렉션을 할당하는 방법을 보여줍니다.

폴백 글꼴 규칙 컬렉션이 프레젠테이션의 `FontsManager`에 할당되면, 저장, 렌더링 및 프레젠테이션 변환과 같은 작업 중에 규칙이 적용됩니다. 예제에서는 슬라이드 섬네일을 렌더링하고 PNG 이미지로 저장할 때 구성된 규칙을 사용하는 방법을 보여줍니다.

## **폴백 글꼴 규칙을 사용하여 슬라이드 렌더링**

다음 예제는 다음 단계로 구성됩니다:

1. 우리는 [폴백 글꼴 규칙 컬렉션을 생성합니다](/slides/ko/cpp/create-fallback-fonts-collection/).
2. [Remove()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontfallbackrule/remove/) 폴백 글꼴 규칙을 제거하고 다른 규칙에 [AddFallBackFonts()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontfallbackrule/addfallbackfonts/) 추가합니다.
3. 규칙 컬렉션을 [FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) 메서드에 전달합니다.
4. [Presentation::Save()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/save/) 메서드를 사용하면 프레젠테이션을 동일한 형식으로 저장하거나 다른 형식으로 저장할 수 있습니다. 폴백 글꼴 규칙 컬렉션이 FontsManager에 설정된 후에는 이러한 규칙이 프레젠테이션에 대한 모든 작업(저장, 렌더링, 변환 등) 중에 적용됩니다.

``` cpp
#include <DOM/Fonts/FontFallBackRule.h>
#include <DOM/Fonts/FontFallBackRulesCollection.h>
#include <DOM/IFontsManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

// 규칙 컬렉션의 새 인스턴스를 생성합니다
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// 여러 규칙을 생성합니다
rulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x400), static_cast<uint32_t>(0x4FF), u"Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

for (const auto& fallBackRule : rulesList)
{
	// 로드된 규칙에서 폴백 글꼴 "Tahoma"를 제거 시도
	fallBackRule->Remove(u"Tahoma");

	// 지정된 범위에 대한 규칙을 업데이트
	if ((fallBackRule->get_RangeEndIndex() >= static_cast<uint32_t>(0x4000)) &&
		(fallBackRule->get_RangeStartIndex() < static_cast<uint32_t>(0x5000)))
	{
		fallBackRule->AddFallBackFonts(u"Verdana");
	}
}

// 리스트에서 기존 규칙을 모두 제거할 수도 있습니다
if (rulesList->get_Count() > 0)
{
	rulesList->Remove(rulesList->idx_get(0));
}

auto pres = System::MakeObject<Presentation>(u"input.pptx");
// 사용을 위해 준비된 규칙 목록을 할당합니다
pres->get_FontsManager()->set_FontFallBackRulesCollection(rulesList);

// 초기화된 규칙 컬렉션을 사용하여 썸네일을 렌더링하고 PNG로 저장합니다
auto image = pres->get_Slide(0)->GetImage(1.f, 1.f);
image->Save(u"Slide_0.png", Aspose::Slides::ImageFormat::Png);
image->Dispose();

pres->Dispose();
```

{{% alert color="info" %}} 
C++에서 PowerPoint 슬라이드를 PNG로 변환하는 방법에 대해 자세히 알아보려면 [C++에서 PowerPoint 슬라이드를 PNG로 변환](/slides/ko/cpp/convert-powerpoint-to-png/)을 참조하십시오.
{{% /alert %}}