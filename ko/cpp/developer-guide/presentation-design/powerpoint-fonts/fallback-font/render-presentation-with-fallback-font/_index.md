---
title: C++에서 대체 폰트로 프레젠테이션 렌더링
linktitle: 프레젠테이션 렌더링
type: docs
weight: 30
url: /ko/cpp/render-presentation-with-fallback-font/
keywords:
- 대체 폰트
- PowerPoint 렌더링
- 프레젠테이션 렌더링
- 슬라이드 렌더링
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++에서 대체 폰트를 사용하여 프레젠테이션을 렌더링합니다 – PPT, PPTX 및 ODP 전반에 걸쳐 텍스트 일관성을 유지하는 단계별 C++ 코드 샘플."
---
## **개요**

Aspose.Slides는 대체 폰트 규칙을 사용하여 프레젠테이션을 렌더링할 수 있게 합니다. 이 문서에서는 대체 폰트 규칙 컬렉션을 생성하고, 대체 폰트를 제거하거나 추가하여 규칙을 수정한 뒤, `FontsManager::set_FontFallBackRulesCollection` 메서드를 사용하여 컬렉션을 할당하는 방법을 보여줍니다.

대체 폰트 규칙 컬렉션이 프레젠테이션의 `FontsManager`에 할당되면, 저장, 렌더링 및 프레젠테이션 변환과 같은 작업 중에 규칙이 적용됩니다. 이 예제는 슬라이드 썸네일을 렌더링하고 PNG 이미지로 저장할 때 구성된 규칙을 사용하는 방법을 보여줍니다.

## **대체 폰트 규칙을 사용하여 슬라이드 렌더링**

다음 예제는 다음 단계들을 포함합니다:

1. 우리는 [대체 폰트 규칙 컬렉션을 생성합니다](/slides/ko/cpp/create-fallback-fonts-collection/).
2. [Remove()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontfallbackrule/remove/) 대체 폰트 규칙을 제거하고 [AddFallBackFonts()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontfallbackrule/addfallbackfonts/) 다른 규칙에 추가합니다.
3. 규칙 컬렉션을 [FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) 메서드에 전달합니다.
4. [Presentation::Save()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/save/) 메서드를 사용하면 프레젠테이션을 동일한 형식으로 저장하거나 다른 형식으로 저장할 수 있습니다. 대체 폰트 규칙 컬렉션이 FontsManager에 설정된 후에는 저장, 렌더링, 변환 등 프레젠테이션에 대한 모든 작업 중에 이러한 규칙이 적용됩니다.

``` cpp
// 규칙 컬렉션의 새 인스턴스를 생성합니다
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// 여러 규칙을 생성합니다
rulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x400), static_cast<uint32_t>(0x4FF), u"Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

for (const auto& fallBackRule : rulesList)
{
	// 로드된 규칙에서 대체 폰트 "Tahoma"를 제거하려고 합니다
	fallBackRule->Remove(u"Tahoma");

	// 그리고 지정된 범위에 대한 규칙을 업데이트합니다
	if ((fallBackRule->get_RangeEndIndex() >= static_cast<uint32_t>(0x4000)) && 
		(fallBackRule->get_RangeStartIndex() < static_cast<uint32_t>(0x5000)))
	{
		fallBackRule->AddFallBackFonts(u"Verdana");
	}
}

// 또한 목록에서 기존 규칙을 제거할 수 있습니다
if (rulesList->get_Count() > 0)
{
	rulesList->Remove(rulesList->idx_get(0));
}

auto pres = System::MakeObject<Presentation>(u"input.pptx");
// 사용을 위해 준비된 규칙 목록을 할당합니다
pres->get_FontsManager()->set_FontFallBackRulesCollection(rulesList);

// 초기화된 규칙 컬렉션을 사용하여 썸네일을 렌더링하고 PNG로 저장합니다
auto image = pres->get_Slide(0)->GetImage(1.f, 1.f);
image->Save(u"Slide_0.png", ImageFormat::Png);
image->Dispose();

pres->Dispose();
```

{{% alert color="primary" %}} 
[C++에서 PowerPoint 슬라이드를 PNG로 변환](/slides/ko/cpp/convert-powerpoint-to-png/)하는 방법에 대해 자세히 알아보세요.
{{% /alert %}}