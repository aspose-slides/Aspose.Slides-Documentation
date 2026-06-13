---
title: JavaScript를 사용하여 프레젠테이션에서 텍스트 부분 관리
linktitle: 텍스트 부분
type: docs
weight: 70
url: /ko/nodejs-java/portion/
keywords:
- 텍스트 부분
- 텍스트 파트
- 텍스트 좌표
- 텍스트 위치
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Java와 Aspose.Slides for Node.js를 통해 JavaScript와 Aspose.Slides를 사용하여 PowerPoint 프레젠테이션의 텍스트 부분을 관리하고 성능과 맞춤화를 향상시키는 방법을 배웁니다."
---
## **개요**

텍스트 부분은 단락 내의 특정 텍스트 조각을 나타내며, 주변 내용과 독립적으로 해당 조각을 작업할 수 있게 합니다. Aspose.Slides에서는 텍스트 조각의 위치를 ​​검색하거나, 단락의 일부에만 서식을 적용하거나, 텍스트 동작을 보다 세부적으로 제어해야 할 때 부분을 사용할 수 있습니다.

이 문서에서는 `getCoordinates()` 메서드를 사용하여 부분의 시작 좌표를 가져오는 방법을 보여줍니다. 또한 단일 텍스트 조각에 하이퍼링크를 적용하고, 서식이 부분, 단락, 텍스트 프레임 및 테마 상속을 통해 어떻게 결정되는지 이해하며, 지정된 글꼴을 사용할 수 없는 경우를 처리하는 등 일반적인 부분 관련 시나리오를 강조합니다. 추가로, 같은 단락 내 개별 부분마다 텍스트 채우기, 색상 및 투명성을 다르게 설정할 수 있음을 언급합니다.

## **부분의 위치 좌표 가져오기**
[**getCoordinates()**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Portion#getCoordinates--) 메서드가 [Portion](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/portion/) 클래스에 추가되어 부분 시작 좌표를 검색할 수 있게 되었습니다.

```javascript
// PPTX를 나타내는 Prseetation 클래스를 인스턴스화합니다
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // 프레젠테이션의 컨텍스트 재구성
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var textFrame = shape.getTextFrame();
    for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
        const paragraph = textFrame.getParagraphs().get_Item(i);
        for (let j = 0; j < paragraph.getPortions().getCount(); j++) {
            const portion = paragraph.getPortions().get_Item(j);
            var point = portion.getCoordinates();
            console.log("X: " + point.x + " Y: " + point.y);
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**단일 단락 내 텍스트의 일부에만 하이퍼링크를 적용할 수 있나요?**

예, 개별 부분에 [assign a hyperlink](/slides/ko/nodejs-java/manage-hyperlinks/)을 지정할 수 있습니다; 해당 조각만 클릭 가능하고 전체 단락은 클릭되지 않습니다.

**스타일 상속은 어떻게 작동하나요: Portion가 무엇을 오버라이드하고, Paragraph/TextFrame에서 무엇을 가져오나요?**

Portion 수준 속성이 가장 높은 우선순위를 갖습니다. 속성이 [Portion](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/portion/)에 설정되지 않은 경우 엔진은 [Paragraph](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/paragraph/)에서 가져오고, 거기에도 설정되지 않으면 [TextFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/) 또는 [theme](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/theme/) 스타일에서 가져옵니다.

**Portion에 지정된 글꼴이 대상 머신/서버에 없으면 어떻게 되나요?**

[Font substitution rules](/slides/ko/nodejs-java/font-selection-sequence/)가 적용됩니다. 텍스트가 재배치될 수 있으며, 메트릭, 하이픈 처리 및 폭이 변경될 수 있어 정확한 위치 지정에 영향을 줍니다.

**Paragraph의 나머지와 독립적으로 Portion 전용 텍스트 채우기 투명도나 그라디언트를 설정할 수 있나요?**

예, [Portion](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/portion/) 수준에서 텍스트 색상, 채우기 및 투명도를 인접 조각과 다르게 설정할 수 있습니다.