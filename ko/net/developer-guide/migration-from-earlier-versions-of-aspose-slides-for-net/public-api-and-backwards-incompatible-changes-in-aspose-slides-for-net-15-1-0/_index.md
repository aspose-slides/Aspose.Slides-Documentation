---
title: Aspose.Slides for .NET 15.1.0의 퍼블릭 API 및 뒤돌아 호환되지 않는 변경 사항
linktitle: Aspose.Slides for .NET 15.1.0
type: docs
weight: 130
url: /ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/
keywords:
- 마이그레이션
- 레거시 코드
- 최신 코드
- 레거시 접근법
- 최신 접근법
- 파워포인트
- 오픈문서
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET에서 퍼블릭 API 업데이트와 주요 변경 사항을 검토하여 PowerPoint PPT, PPTX 및 ODP 프레젠테이션 솔루션을 원활하게 마이그레이션하십시오."
---
{{% alert color="info" %}} 

이 페이지에서는 Aspose.Slides for .NET 15.1.0 API와 함께 도입된 모든 [added](/slides/ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) 또는 [removed](/slides/ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) 클래스, 메서드, 속성 등을 비롯한 기타 변경 사항을 나열합니다.

{{% /alert %}} 
## **Public API Chages**
#### **Fonts Substitutions Functinality Has Been Added**
프레젠테이션 전체에 폰트를 전역적으로 교체하고 렌더링 시 일시적으로 교체할 수 있는 가능성이 추가되었습니다.

Presentation 클래스에 새 속성 "FontsManager"가 도입되었습니다. FontsManager 클래스에는 다음 멤버가 있습니다:

**IFontSubstRuleCollection FontSubstRuleList** Property

이 컬렉션은 렌더링 중에 폰트를 대체하기 위해 사용되는 IFontSubstRule 인스턴스들의 집합입니다. IFontSubstRule에는 IFontData 인터페이스를 구현하는 SourceFont 및 DestFont 속성과 교체 조건을 선택할 수 있는 ReplaceFontCondition 속성( "WhenInaccessible" 또는 "Always")이 있습니다.

**IFontData[] GetFonts()** Method

현재 프레젠테이션에서 사용되는 모든 폰트를 검색하는 데 사용됩니다.

**ReplaceFont** Methods

프레젠테이션에서 폰트를 지속적으로 교체하는 데 사용됩니다. 

다음 예제는 프레젠테이션에서 폰트를 교체하는 방법을 보여줍니다:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


             Presentation pres = new Presentation("PresContainsArialFont.pptx");

            IFontData sourceFont = new FontData("Arial");

            IFontData destFont = new FontData("Times New Roman");

            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            pres.Save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);


``` 

또 다른 예제는 접근할 수 없을 때 렌더링을 위한 폰트 대체를 보여줍니다:

``` csharp
using Aspose.Slides;


             Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

            IFontData sourceFont = new FontData("SomeRareFont");

            IFontData destFont = new FontData("Arial");

            IFontSubstRule fontSubstRule = new FontSubstRule(

                sourceFont, destFont, FontSubstCondition.WhenInaccessible);

            IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

            fontSubstRuleCollection.Add(fontSubstRule);

            pres.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

            // 접근할 수 없을 때 SomeRareFont 대신 Arial 폰트가 사용됩니다

            pres.Slides[0].GetImage();

```