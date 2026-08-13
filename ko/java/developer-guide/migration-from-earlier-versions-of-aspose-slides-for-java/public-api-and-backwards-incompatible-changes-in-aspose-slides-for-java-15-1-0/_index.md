---
title: Aspose.Slides for Java 15.1.0의 공개 API 및 이전 버전과 호환되지 않는 변경 사항
linktitle: Aspose.Slides for Java 15.1.0
type: docs
weight: 100
url: /ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/
keywords:
- 마이그레이션
- 레거시 코드
- 최신 코드
- 레거시 접근 방식
- 최신 접근 방식
- 파워포인트
- 오픈도큐먼트
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java의 공개 API 업데이트와 파괴적인 변경 사항을 검토하여 PowerPoint PPT, PPTX 및 ODP 프레젠테이션 솔루션을 원활하게 마이그레이션하세요."
---
{{% alert color="info" %}} 

이 페이지에서는 Aspose.Slides for Java 15.1.0 API에 도입된 모든 [추가된](/slides/ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) 클래스, 메서드, 속성 등과 새로운 제한 사항 및 기타 [변경](/slides/ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/)을 나열합니다.

{{% /alert %}} {{% alert color="info" %}} 

일부 이미지 글머리표와 WordArt 개체에 알려진 문제가 있으며, 이는 Aspose.Slides for Java 15.2.0에서 해결될 예정입니다.

{{% /alert %}} 
## **공개 API 변경 사항**
### **글꼴 교체 기능이 추가되었습니다**
프레젠테이션 전체에서 글꼴을 전역적으로 교체하거나 렌더링 시 임시로 교체할 수 있는 기능이 추가되었습니다.

Presentation 클래스에 새로운 메서드 **getFontsManager()** 가 도입되었습니다. FontsManager 클래스에는 다음 멤버가 포함됩니다:

**IFontSubstRuleCollection getFontSubstRuleList**() 메서드  

이는 렌더링 중에 글꼴을 교체하는 데 사용되는 IFontSubstRule 인스턴스들의 컬렉션입니다. IFontSubstRule 은 IFontData 인터페이스를 구현하는 **getSourceFont()** 와 **getDestFont()** 메서드와 교체 조건을 선택할 수 있는 **getReplaceFontCondition()** 메서드(“WhenInaccessible” 또는 “Always”)를 제공합니다.

**IFontData[] getFonts()** 메서드를 사용하여 현재 프레젠테이션에서 사용되는 모든 글꼴을 가져올 수 있습니다.

**replaceFont(...)** 메서드를 사용하면 프레젠테이션에서 글꼴을 지속적으로 교체할 수 있습니다.

다음 예제는 프레젠테이션에서 글꼴을 교체하는 방법을 보여줍니다:

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("PresContainsArialFont.pptx");

IFontData sourceFont = new FontData("Arial");

IFontData destFont = new FontData("Times New Roman");

pres.getFontsManager().replaceFont(sourceFont, destFont);

pres.save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);

```

또 다른 예제는 접근할 수 없는 경우 렌더링을 위해 글꼴을 교체하는 방법을 보여줍니다:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");
try {
    IFontData sourceFont = new FontData("SomeRareFont");
    IFontData destFont = new FontData("Arial");

    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);

    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);

    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);

    // Arial 글꼴은 SomeRareFont에 접근할 수 없을 때 대신 사용됩니다.
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    slideImage.dispose();
} finally {
    if (pres != null) pres.dispose();
}
```