---
title: ".NET에서 폴백 글꼴을 사용하여 프레젠테이션 렌더링"
linktitle: "프레젠테이션 렌더링"
type: docs
weight: 30
url: /ko/net/render-presentation-with-fallback-font/
keywords:
- "폴백 글꼴"
- "PowerPoint 렌더링"
- "프레젠테이션 렌더링"
- "슬라이드 렌더링"
- "PowerPoint"
- "OpenDocument"
- "프레젠테이션"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET에서 폴백 글꼴을 사용하여 프레젠테이션을 렌더링합니다 – PPT, PPTX 및 ODP에서 텍스트 일관성을 유지하고 단계별 C# 코드 샘플을 제공합니다."
---
## **개요**

Aspose.Slides는 폴백 글꼴 규칙을 사용하여 프레젠테이션을 렌더링할 수 있도록 합니다. 이 문서에서는 폴백 글꼴 규칙 컬렉션을 생성하고, 폴백 글꼴을 제거하거나 추가하여 규칙을 수정하고, 해당 컬렉션을 `FontsManager.FontFallBackRulesCollection` 속성에 할당하는 방법을 보여줍니다.

폴백 글꼴 규칙 컬렉션을 프레젠테이션의 `FontsManager`에 할당하면, 저장, 렌더링 및 프레젠테이션 변환과 같은 작업 중에 규칙이 적용됩니다. 이 예제에서는 슬라이드 썸네일을 렌더링하고 PNG 이미지로 저장할 때 구성된 규칙을 사용하는 방법을 보여줍니다.

## **폴백 글꼴 규칙을 사용하여 슬라이드 렌더링**

다음 예제에는 다음 단계가 포함됩니다:

1. 우리는 [fallback 글꼴 규칙 컬렉션을 생성](/slides/ko/net/create-fallback-fonts-collection/).
2. [Remove()](https://reference.aspose.com/slides/ko/net/aspose.slides/fontfallbackrule/methods/remove) 메서드로 폴백 글꼴 규칙을 제거하고 [AddFallBackFonts()](https://reference.aspose.com/slides/ko/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) 메서드로 다른 규칙에 추가합니다.
3. 규칙 컬렉션을 [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) 속성에 설정합니다.
4. [Presentation.Save()](https://reference.aspose.com/slides/ko/net/aspose.slides.presentation/save/methods/4) 메서드를 사용하면 프레젠테이션을 동일한 형식으로 저장하거나 다른 형식으로 저장할 수 있습니다. 폴백 글꼴 규칙 컬렉션을 FontsManager에 설정한 후에는 저장, 렌더링, 변환 등 프레젠테이션에 대한 모든 작업에서 이러한 규칙이 적용됩니다.

```c#
using Aspose.Slides;

// 규칙 컬렉션의 새 인스턴스를 생성합니다
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// 여러 규칙을 생성합니다
rulesList.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.Add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

foreach (IFontFallBackRule fallBackRule in rulesList)
{
	//로드된 규칙에서 폴백 글꼴 "Tahoma"를 제거하려고 시도합니다
	fallBackRule.Remove("Tahoma");

	//지정된 범위에 대한 규칙을 업데이트합니다
	if ((fallBackRule.RangeEndIndex >= 0x400) && (fallBackRule.RangeStartIndex < 0x500))
		fallBackRule.AddFallBackFonts("Verdana");
}

//또한 렌더링에 사용할 최소 하나의 규칙을 유지하면서 목록에서 기존 규칙을 모두 제거할 수 있습니다
if (rulesList.Count > 1)
	rulesList.Remove(rulesList[1]);

using (Presentation pres = new Presentation("input.pptx"))
{
    //사용을 위해 준비된 규칙 리스트를 할당합니다
    pres.FontsManager.FontFallBackRulesCollection = rulesList;

    // 초기화된 규칙 컬렉션을 사용하여 썸네일을 렌더링하고 PNG로 저장합니다
    using (IImage image = pres.Slides[0].GetImage(1f, 1f))
    {
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

{{% alert color="info" %}} 
프레젠테이션 저장 및 변환에 대해 자세히 알아보세요 [프레젠테이션 저장 및 변환](/slides/ko/net/convert-powerpoint-to-png/).
{{% /alert %}}