---
title: Android 프레젠테이션의 글꼴 교체 간소화
linktitle: 글꼴 교체
type: docs
weight: 60
url: /ko/androidjava/font-replacement/
keywords:
- 글꼴
- 글꼴 교체
- 글꼴 교체
- 글꼴 변경
- PowerPoint
- OpenDocument
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android에서 Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션의 타이포그래피 일관성을 보장하면서 글꼴을 원활하게 교체합니다."
---
## **개요**

Aspose.Slides를 사용하면 프레젠테이션 전체에서 한 글꼴을 다른 글꼴로 교체할 수 있습니다. 글꼴이 교체되면 원래 글꼴이 사용된 모든 인스턴스가 새 글꼴로 변경됩니다.

글꼴 교체를 수행하려면 프레젠테이션을 로드하고, 원본 글꼴과 교체 글꼴을 정의한 다음, 글꼴 교체 메서드를 호출하고 수정된 프레젠테이션을 PPTX 파일로 저장합니다. 이 방법은 프레젠테이션 전체에서 특정 글꼴 패밀리를 다른 패밀리로 의도적으로 전환하려는 경우에 유용합니다.

## **글꼴 교체**

글꼴 사용에 대한 결정을 바꾸고 싶다면 해당 글꼴을 다른 글꼴로 교체할 수 있습니다. 이전 글꼴이 사용된 모든 인스턴스가 새 글꼴로 교체됩니다.

Aspose.Slides는 다음과 같이 글꼴을 교체할 수 있도록 지원합니다:

1. 관련 프레젠테이션을 로드합니다.  
2. 교체될 글꼴을 로드합니다.  
3. 새 글꼴을 로드합니다.  
4. 글꼴을 교체합니다.  
5. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 Java 코드는 글꼴 교체를 보여줍니다:

```java
// 프레젠테이션을 로드합니다
Presentation pres = new Presentation("Fonts.pptx");
try {
    // 교체될 원본 글꼴을 로드합니다
    IFontData sourceFont = new FontData("Arial");
    
    // 새 글꼴을 로드합니다
    IFontData destFont = new FontData("Times New Roman");
    
    // 글꼴을 교체합니다
    pres.getFontsManager().replaceFont(sourceFont, destFont);
    
    // 프레젠테이션을 저장합니다
    pres.save("UpdatedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
특정 상황(예: 글꼴에 접근할 수 없는 경우)에서 발생하는 동작을 결정하는 규칙을 설정하려면 [**글꼴 대체**](/slides/ko/androidjava/font-substitution/)를 참조하십시오. 
{{% /alert %}}

## **FAQ**

**"글꼴 교체", "글꼴 대체", 및 "대체 글꼴"의 차이점은 무엇입니까?**  
교체는 문서 전체에서 한 패밀리를 다른 패밀리로 의도적으로 전환하는 것입니다. [대체](/slides/ko/androidjava/font-substitution/)는 "글꼴을 사용할 수 없을 경우 X를 사용"과 같은 규칙입니다. [대체 글꼴](/slides/ko/androidjava/fallback-font/)은 기본 글꼴이 설치되어 있지만 필요한 문자를 포함하고 있지 않을 때 개별 누락된 글리프에만 적용됩니다.

**교체가 마스터 슬라이드, 레이아웃, 노트 및 댓글에도 적용합니까?**  
예. 교체는 원래 글꼴을 사용하는 모든 프레젠테이션 객체에 영향을 미치며, 여기에는 마스터 슬라이드와 노트가 포함됩니다. 댓글도 문서의 일부이며 글꼴 엔진이 고려합니다.

**삽입된 OLE 개체(예: Excel) 내부의 글꼴이 변경됩니까?**  
아니요. [OLE 콘텐츠](/slides/ko/androidjava/manage-ole/)는 자체 애플리케이션에서 관리됩니다. 프레젠테이션에서의 교체는 내부 OLE 데이터를 재포맷하지 않으며, 해당 내용은 이미지로 표시되거나 외부에서 편집 가능한 형태로 나타날 수 있습니다.

**프레젠테이션의 일부(슬라이드 또는 영역)만에 글꼴을 교체할 수 있습니까?**  
전체 문서에 전역 교체를 적용하는 대신 필요한 객체/범위 수준에서 글꼴을 변경하면 대상별 교체가 가능합니다. 렌더링 중 전체 글꼴 선택 로직은 동일하게 유지됩니다.

**프레젠테이션이 사용하는 모든 글꼴을 사전에 어떻게 확인할 수 있나요?**  
프레젠테이션의 [글꼴 관리자](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/fontsmanager/): 사용 중인 [패밀리](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/fontsmanager/#getFonts--)와 [대체/"알 수 없는" 글꼴](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/fontsmanager/#getSubstitutions--) 정보를 제공하므로 교체 계획에 도움이 됩니다.

**PDF/이미지로 변환할 때 글꼴 교체가 작동합니까?**  
예. 내보내기 시 Aspose.Slides는 동일한 [글꼴 선택/대체 순서](/slides/ko/androidjava/font-selection-sequence/)를 적용하므로 사전에 수행된 교체가 변환 과정에서 적용됩니다.

**시스템에 대상 글꼴을 설치해야 합니까, 아니면 폰트 폴더를 첨부할 수 있습니까?**  
설치는 필요하지 않습니다. 라이브러리는 사용자 폴더에서 [외부 글꼴 로드](/slides/ko/androidjava/custom-font/)를 지원하며, 이는 [렌더링 및 내보내기](/slides/ko/androidjava/convert-powerpoint/) 중에 사용됩니다.

**교체가 문자 대신 나타나는 '두부'(네모) 문제를 해결합니까?**  
대상 글꼴에 실제로 필요한 글리프가 포함된 경우에만 해결됩니다. 포함되지 않은 경우, 누락된 문자를 보완하기 위해 [대체 글꼴 구성](/slides/ko/androidjava/fallback-font/)을 설정하십시오.