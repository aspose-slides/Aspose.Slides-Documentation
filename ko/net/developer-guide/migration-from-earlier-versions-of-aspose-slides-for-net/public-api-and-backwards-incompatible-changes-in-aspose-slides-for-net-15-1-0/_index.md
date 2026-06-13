---
title: Aspose.Slides for .NET 15.1.0의 공개 API 및 이전 버전과 호환되지 않는 변경 사항
linktitle: Aspose.Slides for .NET 15.1.0
type: docs
weight: 130
url: /ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/
keywords:
- 마이그레이션
- 레거시 코드
- 현대 코드
- 레거시 접근 방식
- 현대 접근 방식
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET의 공개 API 업데이트 및 파괴적 변경 사항을 검토하여 PowerPoint PPT, PPTX 및 ODP 프레젠테이션 솔루션을 원활하게 마이그레이션하십시오."
---
{{% alert color="primary" %}} 

이 페이지는 Aspose.Slides for .NET 15.1.0 API에 도입된 [added](/slides/ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) 또는 [removed](/slides/ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) 클래스, 메서드, 속성 등을 모두 나열합니다.

{{% /alert %}} 
## **Public API 변경 사항**
#### **글꼴 대체 기능이 추가되었습니다**
프레젠테이션 전체에서 전역적으로 글꼴을 교체하고, 렌더링 시 일시적으로 교체할 수 있는 기능이 추가되었습니다.

Presentation 클래스에 새 속성 "FontsManager"가 소개되었습니다. FontsManager 클래스에는 다음과 같은 멤버가 있습니다:

**IFontSubstRuleCollection FontSubstRuleList** 속성

렌더링 중에 글꼴을 대체하는 데 사용되는 IFontSubstRule 인스턴스의 컬렉션입니다. IFontSubstRule은 IFontData 인터페이스를 구현하는 SourceFont 및 DestFont 속성과, 교체 조건("WhenInaccessible" 또는 "Always")을 선택할 수 있는 ReplaceFontCondition 속성을 가지고 있습니다.

**IFontData[] GetFonts()** 메서드

현재 프레젠테이션에서 사용되는 모든 글꼴을 가져오는 데 사용됩니다.

**ReplaceFont** 메서드

프레젠테이션 내의 글꼴을 영구적으로 교체하는 데 사용됩니다.

다음 예제는 프레젠테이션에서 글꼴을 교체하는 방법을 보여줍니다:

``` csharp

             Presentation pres = new Presentation("PresContainsArialFont.pptx");

            IFontData sourceFont = new FontData("Arial");

            IFontData destFont = new FontData("Times New Roman");

            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            pres.Save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);


``` 

또 다른 예제는 접근할 수 없을 때 렌더링을 위한 글꼴 대체를 보여줍니다:

``` csharp

             Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

            IFontData sourceFont = new FontData("SomeRareFont");

            IFontData destFont = new FontData("Arial");

            IFontSubstRule fontSubstRule = new FontSubstRule(

                sourceFont, destFont, FontSubstCondition.WhenInaccessible);

            IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

            fontSubstRuleCollection.Add(fontSubstRule);

            pres.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

            // Arial 글꼴이 SomeRareFont에 접근할 수 없을 때 대신 사용됩니다

            pres.Slides[0].GetThumbnail();

```