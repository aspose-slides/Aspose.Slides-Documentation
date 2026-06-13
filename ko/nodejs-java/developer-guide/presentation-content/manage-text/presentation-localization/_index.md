---
title: JavaScript에서 프레젠테이션 현지화 자동화
linktitle: 프레젠테이션 현지화
type: docs
weight: 100
url: /ko/nodejs-java/presentation-localization/
keywords:
- 언어 변경
- 맞춤법 검사
- 언어 ID
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides를 사용하여 JavaScript에서 PowerPoint 및 OpenDocument 슬라이드 현지화를 자동화하고, 실용적인 코드 샘플과 팁을 통해 글로벌 롤아웃을 빠르게 진행합니다."
---
## **개요**

이 문서는 Aspose.Slides를 사용하여 프레젠테이션의 텍스트에 `LanguageId`를 설정하는 방법을 설명합니다. 프레젠테이션을 열고, 텍스트가 포함된 도형을 추가하고, 텍스트 부분에 언어 식별자를 할당한 다음, 결과를 PPTX 파일로 저장하는 과정을 보여줍니다.

## **프레젠테이션 및 도형 텍스트의 언어 변경**

- [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
- 인덱스를 사용하여 슬라이드의 참조를 가져옵니다.
- 슬라이드에 [Rectangle](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ShapeType#Rectangle) 유형의 [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/AutoShape)을 추가합니다.
- TextFrame에 텍스트를 추가합니다.
- 텍스트에 [Setting Language Id](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/BasePortionFormat#setLanguageId-java.lang.String-)을 설정합니다.
- 프레젠테이션을 PPTX 파일로 저장합니다.

위 단계들의 구현은 아래 예제에서 보여줍니다.

```javascript
var pres = new aspose.slides.Presentation("test.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    shape.addTextFrame("Text to apply spellcheck language");
    shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLanguageId("en-EN");
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**언어 ID가 자동 텍스트 번역을 트리거합니까?**

아니요. Aspose.Slides의 [setLanguageId](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/baseportionformat/#setLanguageId)은 맞춤법 검사와 문법 교정을 위해 언어를 저장하지만, 텍스트 내용을 번역하거나 변경하지는 않습니다. 이는 PowerPoint이 교정을 위해 이해하는 메타데이터입니다.

**언어 ID가 렌더링 중 하이픈 삽입 및 줄 바꿈에 영향을 줍니까?**

Aspose.Slides에서 [setLanguageId]는 교정을 위한 것입니다. 하이픈 품질과 줄 바꿈은 주로 [proper fonts](/slides/ko/nodejs-java/powerpoint-fonts/)와 쓰기 시스템에 대한 레이아웃/줄 바꿈 설정에 의존합니다. 올바른 렌더링을 위해 필요한 글꼴을 제공하고, [font substitution rules](/slides/ko/nodejs-java/font-substitution/)를 구성하거나, 프레젠테이션에 [embed fonts](/slides/ko/nodejs-java/embedded-font/)를 포함하십시오.

**단일 문단 내에서 다른 언어를 설정할 수 있습니까?**

예. [setLanguageId]는 텍스트 부분 수준에 적용되므로, 하나의 문단에서 서로 다른 언어와 개별 교정 설정을 혼합할 수 있습니다.