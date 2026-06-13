---
title: JavaScript를 사용하여 프레젠테이션에서 상위 첨자 및 하위 첨자 관리
linktitle: 상위 첨자와 하위 첨자
type: docs
weight: 80
url: /ko/nodejs-java/superscript-and-subscript/
keywords:
- 상위 첨자
- 하위 첨자
- 상위 첨자 추가
- 하위 첨자 추가
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Java를 통해 Node.js용 Aspose.Slides에서 상위 첨자와 하위 첨자를 마스터하고, 전문적인 텍스트 서식을 사용해 프레젠테이션을 최대한 효과적으로 향상시킵니다."
---
## **개요**

Aspose.Slides는 PowerPoint(PPT, PPTX) 및 OpenDocument(ODP) 프레젠테이션에 상위 첨자와 하위 첨자 텍스트를 통합하는 기능을 제공합니다. 화학식, 수학 방정식 강조 또는 각주로 내용에 주석을 달아야 할 경우, 이러한 특수 서식 옵션은 명확성과 정확성을 유지하는 데 도움이 됩니다. 이 문서에서는 상위 첨자와 하위 첨자 스타일을 원활하게 적용하고 모든 슬라이드에서 전문적인 결과를 얻는 방법을 배웁니다.

## **상위 첨자 및 하위 첨자 텍스트 관리**

Any paragraph portion에 상위 첨자와 하위 첨자 텍스트를 추가할 수 있습니다. Aspose.Slides 텍스트 프레임에 상위 첨자 또는 하위 첨자 텍스트를 추가하려면 [**setEscapement**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/BasePortionFormat#setEscapement-float-) 메서드를 사용해야 합니다. 이 메서드는 [PortionFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/PortionFormat) 클래스에 있습니다.

이 속성은 상위 첨자 또는 하위 첨자 텍스트를 반환하거나 설정합니다(값 범위는 -100% (하위 첨자)부터 100% (상위 첨자)까지). 예를 들어:

- [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
- 인덱스를 사용하여 슬라이드의 참조를 가져옵니다.
- 슬라이드에 [Rectangle](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ShapeType#Rectangle) 유형의 [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/AutoShape)를 추가합니다.
- [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/AutoShape)와 연결된 [TextFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/TextFrame)에 접근합니다.
- 기존 Paragraphs를 지웁니다.
- 상위 첨자 텍스트를 보관할 새 Paragraph 객체를 생성하고 이를 [TextFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/TextFrame)의 [Paragraphs collection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/TextFrame#getParagraphs--)에 추가합니다.
- 새 Portion 객체를 생성합니다.
- 상위 첨자를 추가하려면 Escapement 속성을 0에서 100 사이로 설정합니다(0은 상위 첨자 없음).
- [Portion](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Portion)의 텍스트를 지정한 뒤 해당 Paragraph의 Portion 컬렉션에 추가합니다.
- 하위 첨자 텍스트를 보관할 새 Paragraph 객체를 생성하고 이를 ITextFrame의 IParagraphs 컬렉션에 추가합니다.
- 새 Portion 객체를 생성합니다.
- 하위 첨자를 추가하려면 Escapement 속성을 0에서 -100 사이로 설정합니다(0은 하위 첨자 없음).
- [Portion](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Portion)의 텍스트를 지정한 뒤 해당 Paragraph의 Portion 컬렉션에 추가합니다.
- 프레젠테이션을 PPTX 파일로 저장합니다.

위 단계들의 구현 예시는 아래에 나와 있습니다.

```javascript
// PPTX를 나타내는 Presentation 클래스를 인스턴스화합니다
var pres = new aspose.slides.Presentation();
try {
    // 슬라이드 가져오기
    var slide = pres.getSlides().get_Item(0);
    // 텍스트 상자 만들기
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();
    // 상위 첨자 텍스트용 단락 만들기
    var superPar = new aspose.slides.Paragraph();
    // 일반 텍스트가 포함된 Portion 만들기
    var portion1 = new aspose.slides.Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);
    // 상위 첨자 텍스트가 포함된 Portion 만들기
    var superPortion = new aspose.slides.Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);
    // 하위 첨자 텍스트용 단락 만들기
    var paragraph2 = new aspose.slides.Paragraph();
    // 일반 텍스트가 포함된 Portion 만들기
    var portion2 = new aspose.slides.Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);
    // 하위 첨자 텍스트가 포함된 Portion 만들기
    var subPortion = new aspose.slides.Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);
    // 단락을 텍스트 상자에 추가하기
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);
    pres.save("formatText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**PDF 또는 다른 형식으로 내보낼 때 상위 첨자와 하위 첨자가 유지되나요?**

예, Aspose.Slides는 프레젠테이션을 PDF, PPT/PPTX, 이미지 및 기타 지원 형식으로 내보낼 때 상위 첨자와 하위 첨자 서식을 올바르게 보존합니다. 특수 서식은 모든 출력 파일에 그대로 유지됩니다.

**상위 첨자와 하위 첨자를 굵게 또는 기울임꼴과 같은 다른 서식 스타일과 함께 사용할 수 있나요?**

예, Aspose.Slides는 하나의 Portion 내에서 다양한 텍스트 스타일을 혼합할 수 있도록 지원합니다. 굵게, 기울임꼴, 밑줄을 적용하면서 동시에 [PortionFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/portionformat/)의 해당 속성을 설정하여 상위 첨자 또는 하위 첨자를 적용할 수 있습니다.

**표, 차트 또는 SmartArt 내부의 텍스트에도 상위 첨자와 하위 첨자 서식이 적용되나요?**

예, Aspose.Slides는 표와 차트 요소를 포함한 대부분의 객체 내 서식을 지원합니다. SmartArt를 사용할 경우 적절한 요소(예: [SmartArtNode](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/smartartnode/))와 해당 텍스트 컨테이너에 접근한 다음, [PortionFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/portionformat/) 속성을 유사하게 구성하면 됩니다.