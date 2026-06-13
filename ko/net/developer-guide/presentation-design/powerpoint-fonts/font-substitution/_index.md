---
title: .NET에서 프레젠테이션의 글꼴 대체 구성
linktitle: 글꼴 대체
type: docs
weight: 70
url: /ko/net/font-substitution/
keywords:
- 글꼴
- 대체 글꼴
- 글꼴 대체
- 글꼴 교체
- 글꼴 교체
- 대체 규칙
- 교체 규칙
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "PowerPoint 및 OpenDocument 프레젠테이션을 다른 파일 형식으로 변환할 때 .NET용 Aspose.Slides에서 최적의 글꼴 대체를 활성화합니다."
---
## **개요**

Font substitution을 사용하면 Aspose.Slides가 렌더링 또는 변환 중에 원본 프레젠테이션 글꼴을 사용할 수 없을 때 다른 글꼴을 사용할 수 있습니다. `IFontsManager` 인터페이스의 `GetSubstitutions` 메서드를 사용하여 대체된 글꼴을 확인할 수 있습니다.

Aspose.Slides는 또한 글꼴 대체 규칙을 정의할 수 있게 합니다. 예를 들어, 접근할 수 없는 글꼴을 다른 사용 가능한 글꼴로 교체하도록 지정하고 프레젠테이션의 글꼴 관리자를 통해 해당 규칙을 적용할 수 있습니다.

## **글꼴 대체 가져오기**

프레젠테이션 렌더링 과정에서 대체된 프레젠테이션 글꼴을 확인할 수 있도록 Aspose.Slides는 [IFontsManager](https://reference.aspose.com/slides/ko/net/aspose.slides/ifontsmanager/) 인터페이스의 [GetSubstitution](https://reference.aspose.com/slides/ko/net/aspose.slides/fontsmanager/getsubstitutions/) 메서드를 제공합니다.

다음 C# 코드는 프레젠테이션이 렌더링될 때 수행되는 모든 글꼴 대체를 가져오는 방법을 보여줍니다:
```c#
using (Presentation pres = new Presentation(@"Presentation.pptx"))
{
    foreach (var fontSubstitution in pres.FontsManager.GetSubstitutions())
    {
        Console.WriteLine("{0} -> {1}", fontSubstitution.OriginalFontName, fontSubstitution.SubstitutedFontName);
    }
}
```

## **글꼴 대체 규칙 설정**

Aspose.Slides를 사용하면 특정 조건(예: 글꼴에 접근할 수 없을 때)에서 수행해야 할 작업을 결정하는 글꼴 규칙을 다음과 같이 설정할 수 있습니다:

1. 관련 프레젠테이션을 로드합니다.
2. 교체될 글꼴을 로드합니다.
3. 새 글꼴을 로드합니다.
4. 교체에 대한 규칙을 추가합니다.
5. 프레젠테이션 글꼴 교체 규칙 컬렉션에 규칙을 추가합니다.
6. 슬라이드 이미지를 생성하여 효과를 확인합니다.

다음 C# 코드는 글꼴 대체 과정을 보여줍니다:

```c#
// 프레젠테이션을 로드합니다
Presentation presentation = new Presentation("Fonts.pptx");

// 교체될 소스 글꼴을 로드합니다
IFontData sourceFont = new FontData("SomeRareFont");

// 새 글꼴을 로드합니다
IFontData destFont = new FontData("Arial");

// 글꼴 교체를 위한 규칙을 추가합니다
IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);

// 규칙을 글꼴 대체 규칙 컬렉션에 추가합니다
IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
fontSubstRuleCollection.Add(fontSubstRule);

// 글꼴 규칙 컬렉션을 규칙 리스트에 추가합니다
presentation.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

using (IImage image = presentation.Slides[0].GetImage(1f, 1f))
{
    // 이미지를 JPEG 형식으로 디스크에 저장합니다
    image.Save("Thumbnail_out.jpg", ImageFormat.Jpeg);
}
```
{{%  alert title="NOTE"  color="warning"   %}} 
다음 [**Font Replacement**](/slides/ko/net/font-replacement/)를 확인해 보시기 바랍니다. 
{{% /alert %}}

## **수학 방정식 글꼴 제한 사항**

글꼴 대체 규칙은 렌더링 및 변환 중에 사용되는 표준 글꼴 선택 프로세스에 참여합니다. 구성된 규칙에 따라 Aspose.Slides가 접근할 수 없는 글꼴을 다른 사용 가능한 글꼴로 교체할 수 있는 일반 텍스트 시나리오에 적합합니다.

하지만 Office 수학 방정식에는 중요한 제한이 있습니다. 방정제가 **Cambria Math**로 작성된 경우, Aspose.Slides는 방정식 레이아웃을 올바르게 계산하고 렌더링하기 위해 원본 **Cambria Math** 글꼴이 여전히 필요할 수 있습니다. 따라서 **Cambria Math**를 **STIX Two Math**와 같은 다른 수학 글꼴로 대체하는 것은 방정식 렌더링에서 지원되지 않으며, 여전히 **Cambria Math**가 필요하다는 예외가 발생할 수 있습니다.

이러한 프레젠테이션을 성공적으로 변환하려면 런타임에 **Cambria Math**가 Aspose.Slides에서 사용 가능하도록 해야 합니다. 운영 체제에 글꼴을 설치하거나 [external font](/slides/ko/net/custom-font/) 로 제공하여 렌더링 및 변환 중에 정상적인 글꼴 선택 프로세스에 참여하도록 할 수 있습니다.

이 제한은 방정식 렌더링에만 적용됩니다. 위에서 설명한 표준 글꼴 대체 규칙은 원본 글꼴에 접근할 수 없는 일반 프레젠테이션 텍스트에도 여전히 적용됩니다.

## **FAQ**

**글꼴 교체와 글꼴 대체의 차이점은 무엇입니까?**

[Replacement](/slides/ko/net/font-replacement/)은 전체 프레젠테이션에서 한 글꼴을 다른 글꼴로 강제로 교체하는 것입니다. 대체는 특정 조건(예: 원본 글꼴이 사용할 수 없을 때)에서 트리거되는 규칙이며, 지정된 대체 글꼴이 사용됩니다.

**대체 규칙은 정확히 언제 적용됩니까?**

규칙은 로드, 렌더링 및 변환 중에 평가되는 표준 [font selection](/slides/ko/net/font-selection-sequence/) 순서에 참여합니다; 선택한 글꼴을 사용할 수 없는 경우 교체 또는 대체가 적용됩니다.

**시스템에 글꼴이 없고 교체나 대체가 구성되지 않은 경우 기본 동작은 무엇입니까?**

라이브러리는 PowerPoint와 유사하게 가장 가까운 사용 가능한 시스템 글꼴을 선택하려고 시도합니다.

**런타임에 사용자 정의 외부 글꼴을 연결하여 대체를 방지할 수 있나요?**

예. 런타임에 [external fonts](/slides/ko/net/custom-font/)를 추가하면 라이브러리가 선택 및 렌더링 시 해당 글꼴을 고려하게 되며, 이후 변환에도 적용됩니다.

**Aspose가 라이브러리와 함께 글꼴을 배포하나요?**

아니요. Aspose는 유료 또는 무료 글꼴을 배포하지 않으며, 사용자는 필요에 따라 직접 글꼴을 추가하고 사용해야 합니다.

**Windows, Linux, macOS에서 대체 동작에 차이가 있나요?**

예. 글꼴 검색은 운영 체제의 글꼴 디렉터리에서 시작됩니다. 기본 제공 글꼴 집합 및 검색 경로가 플랫폼마다 다르므로 사용 가능 여부와 대체 필요성에 영향을 미칩니다.

**배치 변환 중 예기치 않은 대체를 최소화하려면 환경을 어떻게 준비해야 하나요?**

머신이나 컨테이너 간에 글꼴 세트를 동기화하고, 출력 문서에 필요한 [external fonts](/slides/ko/net/custom-font/)를 추가하며, 가능한 경우 프레젠테이션에 [embed fonts](/slides/ko/net/embedded-font/)를 삽입하여 렌더링 시 선택된 글꼴이 사용 가능하도록 합니다.