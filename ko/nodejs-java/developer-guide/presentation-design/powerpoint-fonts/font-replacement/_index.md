---
title: JavaScript를 사용한 프레젠테이션 글꼴 교체 간소화
linktitle: 글꼴 교체
type: docs
weight: 60
url: /ko/nodejs-java/font-replacement/
keywords:
- 글꼴
- 글꼴 교체
- 글꼴 교체
- 글꼴 변경
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js를 사용하여 Java를 통해 JavaScript에서 글꼴을 원활하게 교체하여 PowerPoint 및 OpenDocument 프레젠테이션에서 일관된 타이포그래피를 보장합니다."
---
## **개요**

Aspose.Slides를 사용하면 프레젠테이션 전체에서 하나의 글꼴을 다른 글꼴로 교체할 수 있습니다. 글꼴을 교체하면 원본 글꼴의 모든 인스턴스가 새 글꼴로 변경됩니다.

글꼴 교체를 수행하려면 프레젠테이션을 로드하고, 원본 글꼴과 교체할 글꼴을 정의한 다음, 글꼴 교체 메서드를 호출하고, 수정된 프레젠테이션을 PPTX 파일로 저장하면 됩니다. 이 방법은 프레젠테이션 전체에서 의도적으로 한 글꼴 패밀리에서 다른 글꼴 패밀리로 전환하려는 경우에 유용합니다.

## **글꼴 교체**

글꼴 사용을 변경하려는 경우 해당 글꼴을 다른 글꼴로 교체할 수 있습니다. 이전 글꼴의 모든 인스턴스가 새 글꼴로 교체됩니다.

Aspose.Slides에서 글꼴을 교체하는 방법은 다음과 같습니다:

1. 관련 프레젠테이션을 로드합니다. 
2. 교체될 글꼴을 로드합니다. 
3. 새 글꼴을 로드합니다. 
4. 글꼴을 교체합니다. 
5. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 JavaScript 코드는 글꼴 교체를 보여 줍니다:

```javascript
// 프레젠테이션을 로드합니다
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    // 교체될 원본 글꼴을 로드합니다
    var sourceFont = new aspose.slides.FontData("Arial");
    // 새 글꼴을 로드합니다
    var destFont = new aspose.slides.FontData("Times New Roman");
    // 글꼴을 교체합니다
    pres.getFontsManager().replaceFont(sourceFont, destFont);
    // 프레젠테이션을 저장합니다
    pres.save("UpdatedFont_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="참고" color="warning" %}} 
특정 조건(예: 글꼴에 접근할 수 없는 경우)에서 발생하는 동작을 정의하는 규칙을 설정하려면 [**글꼴 대체**](/slides/ko/nodejs-java/font-substitution/)를 참조하십시오.
{{% /alert %}}

## **자주 묻는 질문**

**"글꼴 교체", "글꼴 대체", "대체 글꼴" 사이의 차이점은 무엇입니까?**

교체는 전체 문서에서 한 글꼴 패밀리를 다른 패밀리로 의도적으로 교체하는 것입니다. [대체](/slides/ko/nodejs-java/font-substitution/)는 "해당 글꼴을 사용할 수 없을 경우 X를 사용한다"는 규칙이며, [대체 글꼴](/slides/ko/nodejs-java/fallback-font/)은 기본 글꼴이 설치되어 있지만 필요한 문자를 포함하지 않을 때 개별 누락 글리프에 대해 외과적으로 적용됩니다.

**교체가 마스터 슬라이드, 레이아웃, 노트 및 댓글에도 적용됩니까?**

예. 교체는 마스터 슬라이드와 노트를 포함한 원본 글꼴을 사용하는 모든 프레젠테이션 개체에 영향을 미칩니다. 댓글도 문서의 일부이며 글꼴 엔진에서 고려됩니다.

**내장 OLE 개체(예: Excel) 내부의 글꼴도 변경됩니까?**

아니요. [OLE 콘텐츠](/slides/ko/nodejs-java/manage-ole/)는 해당 애플리케이션에 의해 제어됩니다. 프레젠테이션에서의 교체는 내부 OLE 데이터의 형식을 변경하지 않으며, 이미지로 표시되거나 외부에서 편집 가능한 콘텐츠로 표시될 수 있습니다.

**프레젠테이션의 일부(슬라이드별 또는 영역별)만 글꼴을 교체할 수 있습니까?**

대상 범위의 객체/범위 수준에서 글꼴을 변경하면 전체 문서에 대한 전역 교체가 아니라 선택적인 교체가 가능합니다. 렌더링 중 전반적인 글꼴 선택 로직은 동일하게 유지됩니다.

**프레젠테이션이 사용하는 모든 글꼴을 미리 어떻게 확인합니까?**

프레젠테이션의 [font manager](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontsmanager/)를 사용하십시오. 여기에서 사용 중인 [글꼴 패밀리]([https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontsmanager/getfonts/]) 목록과 [대체/“알 수 없는” 글꼴]([https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/]) 정보를 제공하여 교체 계획을 세울 수 있습니다.

**PDF/이미지로 변환할 때 글꼴 교체가 작동합니까?**

예. 내보내기 중 Aspose.Slides는 동일한 [글꼴 선택/대체 순서](/slides/ko/nodejs-java/font-selection-sequence/)를 적용하므로 사전에 수행된 교체가 변환 시에도 반영됩니다.

**시스템에 대상 글꼴을 설치해야 합니까, 아니면 폰트 폴더를 첨부할 수 있습니까?**

설치가 필요하지 않습니다. 라이브러리는 [외부 글꼴 로드](/slides/ko/nodejs-java/custom-font/)를 지원하므로 사용자 폴더에서 로드한 글꼴을 [렌더링 및 내보내기](/slides/ko/nodejs-java/convert-powerpoint/) 중에 사용할 수 있습니다.

**교체가 문자 대신 “토푸”(사각형)를 해결합니까?**

대상 글꼴에 실제로 필요한 글리프가 포함된 경우에만 작동합니다. 포함되지 않은 경우 [대체 글꼴](/slides/ko/nodejs-java/fallback-font/)을 구성하여 누락된 문자를 보완하십시오.