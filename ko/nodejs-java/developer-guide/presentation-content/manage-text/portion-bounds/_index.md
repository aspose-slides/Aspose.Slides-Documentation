---
title: JavaScript에서 프레젠테이션의 텍스트 부분 경계 가져오기
linktitle: 부분 경계
type: docs
weight: 47
url: /ko/nodejs-java/portion-bounds/
keywords:
- 텍스트 부분 경계
- 텍스트 부분
- 텍스트 조각
- 텍스트 좌표
- 텍스트 위치
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Java를 통해 Node.js용 Aspose.Slides를 사용하여 PowerPoint 프레젠테이션에서 텍스트 부분 경계를 검색하는 방법을 알아보세요."
---
## **개요**

텍스트 부분은 단락 내부의 특정 텍스트 조각을 나타내며, 주변 콘텐츠와 독립적으로 해당 조각을 작업할 수 있게 합니다. Aspose.Slides에서 텍스트 부분은 텍스트 조각의 경계를 가져오거나, 단락의 일부분에만 서식을 적용하거나, 보다 세부적인 수준에서 텍스트 동작을 제어해야 할 때 사용할 수 있습니다.

이 문서에서는 [Portion.getRect](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/portion/getrect/)을 사용하여 텍스트 부분의 경계 사각형을 얻는 방법을 보여줍니다. 또한 [Portion.getCoordinates](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/portion/getcoordinates/)를 사용하여 텍스트 부분 시작점의 좌표를 얻는 방법을 설명합니다. 추가로, 단일 텍스트 조각에 하이퍼링크를 적용하거나, 서식이 텍스트 부분, 단락, 텍스트 프레임 및 테마 상속을 통해 어떻게 해결되는지 이해하고, 지정된 글꼴이 없을 경우를 처리하는 등 일반적인 텍스트 부분 관련 시나리오를 강조합니다.

## **텍스트 부분의 경계 가져오기**

[Portion.getRect](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/portion/getrect/)를 사용하여 텍스트 부분의 경계 사각형을 가져옵니다:

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraphs = shape.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        const portions = paragraph.getPortions();

        for (let portionIndex = 0; portionIndex < portions.getCount(); portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const rectangle = portion.getRect();
            console.log("X = " + rectangle.x + "; Y = " + rectangle.y + "; Width = " + rectangle.width + "; Height = " + rectangle.height);
        }
    }
} finally {
    presentation.dispose();
}
```

## **텍스트 부분의 좌표 가져오기**

[Portion.getCoordinates](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/portion/getcoordinates/)를 사용하여 텍스트 부분 시작점의 좌표를 가져옵니다:

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraphs = shape.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        const portions = paragraph.getPortions();

        for (let portionIndex = 0; portionIndex < portions.getCount(); portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const point = portion.getCoordinates();
            console.log("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**단일 단락 내 텍스트의 일부에만 하이퍼링크를 적용할 수 있나요?**

예, 개별 텍스트 부분에 [하이퍼링크 할당](/slides/ko/nodejs-java/manage-hyperlinks/)을 할 수 있습니다. 해당 조각만 클릭 가능하고 전체 단락은 클릭할 수 없습니다.

**스타일 상속은 어떻게 작동하나요: 텍스트 부분은 무엇을 재정의하고, 단락이나 텍스트 프레임에서 무엇을 상속받나요?**

텍스트 부분 수준의 속성이 가장 높은 우선 순위를 가집니다. 해당 속성이 [Portion](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/portion/)에 설정되지 않은 경우, Aspose.Slides는 [Paragraph](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/paragraph/)에서 가져옵니다. 그곳에도 설정되지 않으면, Aspose.Slides는 [TextFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/) 또는 [theme](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/theme/) 스타일을 사용합니다.

**텍스트 부분에 지정된 글꼴이 대상 머신이나 서버에 없으면 어떻게 되나요?**

[글꼴 대체 규칙](/slides/ko/nodejs-java/font-selection-sequence/)이 적용됩니다. 텍스트가 다시 흐를 수 있으며, 메트릭, 하이픈 삽입 및 폭이 변화할 수 있어 정확한 위치 지정에 영향을 줍니다.

**텍스트 부분에만 적용되는 텍스트 채우기 투명도나 그라디언트를 설정할 수 있나요?**

예, [Portion](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/portion/) 수준에서 텍스트 색상, 채우기 및 투명도를 인접 조각과 다르게 설정할 수 있습니다.