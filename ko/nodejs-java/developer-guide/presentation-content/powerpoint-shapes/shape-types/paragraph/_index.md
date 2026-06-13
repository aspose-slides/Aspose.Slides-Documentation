---
title: JavaScript에서 프레젠테이션의 단락 경계 가져오기
linktitle: 단락
type: docs
weight: 60
url: /ko/nodejs-java/paragraph/
keywords:
- 단락 경계
- 텍스트 부분 경계
- 단락 좌표
- 부분 좌표
- 단락 크기
- 텍스트 부분 크기
- 텍스트 프레임
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js를 사용하여 JavaScript에서 단락 및 텍스트 부분 경계를 가져오는 방법을 배우고, PowerPoint 프레젠테이션에서 텍스트 위치를 최적화합니다."
---
## **개요**

이 문서에서는 Aspose.Slides에서 단락 및 텍스트 부분의 경계, 크기 및 좌표를 가져오는 방법을 설명합니다. `getRect()`를 사용하여 `TextFrame` 내 단락의 사각형을 검색하는 방법, 표 셀 텍스트 프레임 내부의 단락 및 부분 좌표를 가져오는 방법을 보여주며, 측정 단위, 텍스트 래핑이 경계에 미치는 영향, 픽셀 변환 및 유효 단락 서식 값과 같은 중요한 세부 사항을 강조합니다.

## **텍스트 프레임에서 단락 및 부분 좌표 가져오기**
Java를 통해 Aspose.Slides for Node.js를 사용하면 개발자는 이제 TextFrame의 단락 컬렉션 내 단락에 대한 사각형 좌표를 가져올 수 있습니다. 또한 단락의 부분 컬렉션 내부에 있는 [부분 좌표](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Portion#getCoordinates--)를 가져올 수 있습니다. 이 항목에서는 예제를 통해 단락에 대한 사각형 좌표와 단락 내부 부분의 위치를 ​​가져오는 방법을 설명합니다.

```javascript
var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
var textFrame = shape.getTextFrame();
for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
    const paragraph = textFrame.getParagraphs().get_Item(i);
    for (let j = 0; j < paragraph.getPortions().getCount(); j++) {
        const portion = paragraph.getPortions().get_Item(j);
        var point = portion.getCoordinates();
    }
}
```

## **단락의 사각형 좌표 가져오기**
[**getRect()**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Paragraph#getRect--) 메서드를 사용하면 개발자는 단락 경계 사각형을 가져올 수 있습니다.

```javascript
var pres = new aspose.slides.Presentation("HelloWorld.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var textFrame = shape.getTextFrame();
    var rect = textFrame.getParagraphs().get_Item(0).getRect();
    console.log("X: " + rect.x + " Y: " + rect.y + " Width: " + rect.width + " Height: " + rect.height);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **표 셀 텍스트 프레임 내부의 단락 및 부분 크기 가져오기**
표 셀 텍스트 프레임에서 [Portion](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Portion) 또는 [Paragraph](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Paragraph)의 크기와 좌표를 가져오려면 [Portion.getRect](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Portion#getRect--) 및 [Paragraph.getRect](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Paragraph#getRect--) 메서드를 사용할 수 있습니다.

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var tbl = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var cell = tbl.getRows().get_Item(1).get_Item(1);
    var x = tbl.getX() + tbl.getRows().get_Item(1).get_Item(1).getOffsetX();
    var y = tbl.getY() + tbl.getRows().get_Item(1).get_Item(1).getOffsetY();
    
    for (let i = 0; i < cell.getTextFrame().getParagraphs().getCount(); i++) {
        const para = cell.getTextFrame().getParagraphs().get_Item(i);
        if (para.getText() === "") {
            continue;
        }
        var rect = para.getRect();
        var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, java.newFloat(rect.getX() + x), java.newFloat(rect.getY() + y), java.newFloat(rect.getWidth()), java.newFloat(rect.getHeight()));
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        for (let j = 0; j < para.getPortions().getCount(); j++) {
            const portion = para.getPortions().get_Item(j);
            if (portion.getText().includes("0")) {
                rect = portion.getRect();
                shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, java.newFloat(rect.getX() + x), java.newFloat(rect.getY() + y), java.newFloat(rect.getWidth()), java.newFloat(rect.getHeight()));
                shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            }
        }
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**단락 및 텍스트 부분의 좌표는 어떤 단위로 반환됩니까?**  
포인트 단위이며, 1인치 = 72포인트입니다. 이는 슬라이드의 모든 좌표와 치수에 적용됩니다.

**단어 래핑이 단락의 경계에 영향을 줍니까?**  
예. [자동 줄바꿈](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframeformat/setwraptext/)이 [TextFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/)에서 활성화된 경우, 텍스트가 영역 너비에 맞게 줄바꿈되어 단락의 실제 경계가 변경됩니다.

**단락 좌표를 내보낸 이미지의 픽셀에 신뢰성 있게 매핑할 수 있습니까?**  
예. 다음 공식을 사용하여 포인트를 픽셀로 변환합니다: pixels = points × (DPI / 72). 결과는 렌더링/내보내기에 선택된 DPI에 따라 달라집니다.

**스타일 상속을 고려한 “실제(effective)” 단락 서식 매개변수를 어떻게 가져오나요?**  
[실제 단락 서식 데이터 구조](/slides/ko/nodejs-java/shape-effective-properties/)를 사용합니다; 들여쓰기, 간격, 래핑, RTL 등에 대한 최종 통합 값을 반환합니다.