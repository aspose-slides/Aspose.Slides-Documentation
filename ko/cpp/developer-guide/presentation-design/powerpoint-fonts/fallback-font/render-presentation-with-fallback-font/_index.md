---
title: C++에서 폴백 글꼴로 프레젠테이션 렌더링
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
description: "Aspose.Slides의 C++용 폴백 글꼴을 사용하여 프레젠테이션을 렌더링합니다 – PPT, PPTX 및 ODP에서 텍스트 일관성을 유지하기 위해 단계별 C++ 코드 샘플을 제공합니다."
---
## **개요**

Aspose.Slides는 폴백 글꼴 규칙을 사용하여 프레젠테이션을 렌더링할 수 있도록 합니다. 이 문서에서는 폴백 글꼴 규칙 컬렉션을 생성하고, 규칙을 제거하거나 폴백 글꼴을 추가하여 수정한 뒤 `FontsManager::set_FontFallBackRulesCollection` 메서드를 사용하여 컬렉션을 할당하는 방법을 보여줍니다.

폴백 글꼴 규칙 컬렉션을 프레젠테이션의 `FontsManager`에 할당하면 저장, 렌더링, 변환 등 작업 중에 해당 규칙이 적용됩니다. 예제에서는 슬라이드 썸네일을 렌더링하고 PNG 이미지로 저장할 때 구성된 규칙을 사용하는 방법을 시연합니다.

## **폴백 글꼴 규칙을 사용하여 슬라이드 렌더링**

다음 예제는 다음 단계로 구성됩니다:

1. 우리는 [폴백 글꼴 규칙 컬렉션 만들기](/slides/ko/cpp/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontfallbackrule/remove/) 로 폴백 글꼴 규칙을 제거하고 [AddFallBackFonts()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontfallbackrule/addfallbackfonts/) 로 다른 규칙에 추가합니다.
1. 규칙 컬렉션을 [FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) 메서드에 전달합니다.
1. [Presentation::Save()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/save/) 메서드를 사용하면 동일한 형식으로 프레젠테이션을 저장하거나 다른 형식으로 저장할 수 있습니다. 폴백 글꼴 규칙 컬렉션이 FontsManager에 설정되면 저장, 렌더링, 변환 등 프레젠테이션에 대한 모든 작업에 해당 규칙이 적용됩니다.

``` cpp
// Create new instance of a rules collection
// 규칙 컬렉션의 새 인스턴스를 생성합니다
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// Create a number of rules
// 여러 규칙을 생성합니다
rulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x400), static_cast<uint32_t>(0x4FF), u"Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

for (const auto& fallBackRule : rulesList)
{
	// Trying to remove FallBack font "Tahoma" from loaded rules
	// "Tahoma" 폰트를 로드된 규칙에서 제거하려고 시도합니다
	fallBackRule->Remove(u"Tahoma");

	// And to update of rules for specified range
	// 그리고 지정된 범위에 대한 규칙을 업데이트합니다
	if ((fallBackRule->get_RangeEndIndex() >= static_cast<uint32_t>(0x4000)) && 
		(fallBackRule->get_RangeStartIndex() < static_cast<uint32_t>(0x5000)))
	{
		fallBackRule->AddFallBackFonts(u"Verdana");
	}
}

// Also we can remove any existing rules from list
// 또한 목록에서 기존 규칙을 제거할 수 있습니다
if (rulesList->get_Count() > 0)
{
	rulesList->Remove(rulesList->idx_get(0));
}

auto pres = System::MakeObject<Presentation>(u"input.pptx");
// Assigning a prepared rules list for using
pres->get_FontsManager()->set_FontFallBackRulesCollection(rulesList);

// Rendering of thumbnail with using of initialized rules collection and saving to PNG
auto image = pres->get_Slide(0)->GetImage(1.f, 1.f);
image->Save(u"Slide_0.png", ImageFormat::Png);
image->Dispose();

pres->Dispose();
```

{{% alert color="primary" %}} 
C++에서 PowerPoint 슬라이드를 PNG로 변환하는 방법에 대해 자세히 알아보세요. [/slides/ko/cpp/convert-powerpoint-to-png/]( /slides/ko/cpp/convert-powerpoint-to-png/) 
{{% /alert %}}