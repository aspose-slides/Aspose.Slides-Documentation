---
title: .NET에서 대체 폰트로 프레젠테이션 렌더링
linktitle: 프레젠테이션 렌더링
type: docs
weight: 30
url: /ko/net/render-presentation-with-fallback-font/
keywords:
- 대체 폰트
- PowerPoint 렌더링
- 프레젠테이션 렌더링
- 슬라이드 렌더링
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET에서 대체 폰트를 사용해 프레젠테이션을 렌더링합니다 – PPT, PPTX 및 ODP 전반에 걸쳐 텍스트를 일관되게 유지하는 단계별 C# 코드 샘플."
---
## **개요**

Aspose.Slides를 사용하면 대체 폰트 규칙을 사용하여 프레젠테이션을 렌더링할 수 있습니다. 이 문서에서는 대체 폰트 규칙 컬렉션을 생성하고, 대체 폰트를 제거하거나 추가하여 규칙을 수정하고, 해당 컬렉션을 `FontsManager.FontFallBackRulesCollection` 속성에 할당하는 방법을 보여줍니다.

대체 폰트 규칙 컬렉션이 프레젠테이션의 `FontsManager`에 할당되면 저장, 렌더링 및 프레젠테이션 변환과 같은 작업 중에 규칙이 적용됩니다. 이 예제에서는 슬라이드 썸네일을 렌더링하고 PNG 이미지로 저장할 때 구성된 규칙을 사용하는 방법을 보여줍니다.

## **대체 폰트 규칙을 사용하여 슬라이드 렌더링**

다음 예제는 다음 단계로 구성됩니다:

1. 우리는 [대체 폰트 규칙 컬렉션 만들기](/slides/ko/net/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/ko/net/aspose.slides/fontfallbackrule/methods/remove) 대체 폰트 규칙을 제거하고 [AddFallBackFonts()](https://reference.aspose.com/slides/ko/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) 다른 규칙에 추가합니다.
1. 규칙 컬렉션을 [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) 속성에 설정합니다.
1. [Presentation.Save()](https://reference.aspose.com/slides/ko/net/aspose.slides.presentation/save/methods/4) 메서드를 사용하면 프레젠테이션을 동일한 형식으로 저장하거나 다른 형식으로 저장할 수 있습니다. 대체 폰트 규칙 컬렉션이 FontsManager에 설정된 후, 이러한 규칙은 프레젠테이션에 대한 모든 작업(저장, 렌더링, 변환 등) 중에 적용됩니다.

```c#
// 규칙 컬렉션의 새 인스턴스 생성
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// 여러 규칙 생성
rulesList.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

foreach (IFontFallBackRule fallBackRule in rulesList)
{
	// 로드된 규칙에서 대체 폰트 "Tahoma"를 제거하려고 함
	fallBackRule.Remove("Tahoma");

	// 지정된 범위에 대한 규칙을 업데이트
	if ((fallBackRule.RangeEndIndex >= 0x4000) && (fallBackRule.RangeStartIndex < 0x5000))
		fallBackRule.AddFallBackFonts("Verdana");
}

// 또한 목록에서 기존 규칙을 제거할 수 있음
if (rulesList.Count > 0)
	rulesList.Remove(rulesList[0]);

using (Presentation pres = new Presentation("input.pptx"))
{
    // 사용을 위해 준비된 규칙 목록 할당
    pres.FontsManager.FontFallBackRulesCollection = rulesList;

    // 초기화된 규칙 컬렉션을 사용하여 썸네일을 렌더링하고 PNG로 저장
    using (IImage image = pres.Slides[0].GetImage(1f, 1f))
    {
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

{{% alert color="primary" %}} 
프레젠테이션에서 저장 및 변환에 대해 자세히 보려면 [Save and Convertion in Presentation](/slides/ko/net/convert-powerpoint-to-png/)를 확인하십시오.
{{% /alert %}}