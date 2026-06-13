---
title: PowerPoint 프레젠테이션에서 JavaScript로 SmartArt 관리
linktitle: SmartArt 관리
type: docs
weight: 10
url: /ko/nodejs-java/manage-smartart/
keywords:
- 스마트아트
- 스마트아트 텍스트
- 레이아웃 유형
- 숨김 속성
- 조직도
- 그림 조직도
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js를 사용하여 명확한 JavaScript 코드 샘플로 슬라이드 디자인과 자동화를 가속화하면서 PowerPoint SmartArt를 구축하고 편집하는 방법을 배우십시오."
---
## **개요**

SmartArt는 노드, 노드 모양 및 레이아웃으로 구성된 PowerPoint 다이어그램입니다. Java를 통해 Node.js용 Aspose.Slides를 사용하면 SmartArt를 생성하고, 노드에서 텍스트를 읽으며, 레이아웃을 변경하고, 숨겨진 노드를 검사하며, 조직도 레이아웃을 구성하고, 사진 조직도를 만들 수 있습니다.

## **SmartArt 개체에서 텍스트 가져오기**

SmartArt 노드에는 하나 이상의 모양이 포함될 수 있습니다. 표시되는 텍스트를 읽으려면 [SmartArt.getAllNodes](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/smartart/#getAllNodes--)를 반복하고, [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/smartartshape/#getTextFrame--)이 반환하는 [TextFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/)을 읽으십시오.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
        let smartArt = shape;
        let nodes = smartArt.getAllNodes();

        for (let nodeIndex = 0; nodeIndex < nodes.size(); nodeIndex++) {
            let node = nodes.get_Item(nodeIndex);
            let nodeShapes = node.getShapes();

            for (let shapeIndex = 0; shapeIndex < nodeShapes.size(); shapeIndex++) {
                let nodeShape = nodeShapes.get_Item(shapeIndex);

                if (nodeShape.getTextFrame() != null) {
                    console.log(nodeShape.getTextFrame().getText());
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **SmartArt 개체의 레이아웃 유형 변경**

SmartArt 레이아웃은 노드가 배열되고 연결되는 방식을 제어합니다. 다음 예제는 [SmartArtLayoutType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/smartartlayouttype/) `BasicBlockList` 값을 사용하여 SmartArt 개체를 생성하고, 이를 `BasicProcess` 값으로 변경한 후 프레젠테이션을 저장합니다.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicBlockList);

    smartArt.setLayout(aspose.slides.SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **SmartArt 노드가 숨겨졌는지 확인하기**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/smartartnode/ishidden/)은 노드가 SmartArt 데이터 모델에서 숨겨져 있는지 여부를 나타냅니다. 선택된 레이아웃이 해당 노드를 표시하지 않더라도 숨겨진 노드는 구조에 존재할 수 있습니다.

다음 예제는 [SmartArtLayoutType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/smartartlayouttype/) `RadialCycle` 값을 사용하는 SmartArt 개체에 노드를 추가하고 해당 노드의 숨김 상태를 확인합니다.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.RadialCycle);

    let node = smartArt.getAllNodes().addNode();
    let isHidden = node.isHidden();

    if (isHidden) {
        console.log("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **조직도 레이아웃 가져오기 또는 설정하기**

조직도 레이아웃을 사용하는 SmartArt 다이어그램의 경우, [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/smartartnode/#getOrganizationChartLayout--) 및 [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/smartartnode/#setOrganizationChartLayout-int-)은 자식 노드가 상위 노드 아래에서 배치되는 방식을 정의합니다. 예를 들어, 선택된 [OrganizationChartLayoutType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/organizationchartlayouttype/)에 따라 자식 노드를 왼쪽, 오른쪽 또는 양쪽에 매달리도록 설정할 수 있습니다.

다음 예제는 조직도를 만들고 첫 번째 노드의 레이아웃을 [OrganizationChartLayoutType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/organizationchartlayouttype/) `LeftHanging` 값으로 설정합니다.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.OrganizationChart);

    let rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(aspose.slides.OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **그림 조직도 만들기**

그림 조직도는 이미지 자리표시자를 포함하는 계층 구조 다이어그램을 위해 설계된 SmartArt 레이아웃입니다. 슬라이드에 SmartArt 개체를 추가할 때 [SmartArtLayoutType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` 값을 사용하십시오.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        0, 0, 400, 400, aspose.slides.SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **자주 묻는 질문**

**SmartArt가 RTL 언어에 대해 미러링이나 반전 기능을 지원합니까?**

예. 선택된 SmartArt 레이아웃이 반전을 지원하는 경우, [SmartArt.setReversed](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/smartart/setreversed/) 메서드는 다이어그램 방향을 왼쪽에서 오른쪽으로부터 오른쪽에서 왼쪽으로(또는 그 반대로) 전환합니다.

**포맷을 유지하면서 같은 슬라이드 또는 다른 프레젠테이션에 SmartArt를 복사하려면 어떻게 해야 합니까?**

SmartArt 형태를 [clone the SmartArt shape](/slides/ko/nodejs-java/shape-manipulations/)을 사용하여 [ShapeCollection.addClone](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shapecollection/addclone/)하거나, SmartArt가 포함된 전체 슬라이드를 [clone the whole slide](/slides/ko/nodejs-java/clone-slides/)할 수 있습니다. 두 방법 모두 크기, 위치 및 서식을 유지합니다.

**SmartArt를 미리 보기 또는 웹 내보내기를 위한 래스터 이미지로 렌더링하려면 어떻게 해야 합니까?**

[Render the slide](/slides/ko/nodejs-java/convert-powerpoint-to-png/) 또는 전체 프레젠테이션을 PNG 또는 JPEG 형식으로 렌더링합니다. SmartArt는 슬라이드의 일부로 렌더링됩니다.

**여러 개가 있을 때 슬라이드에서 특정 SmartArt 객체를 어떻게 찾을 수 있습니까?**

SmartArt 형태에 고유한 [Shape.setAlternativeText](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/setalternativetext/) 또는 [Shape.setName](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/setname/) 값을 설정하고, [BaseSlide.getShapes](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/baseslide/#getShapes)에서 해당 값을 검색한 뒤, 일치하는 형태가 [SmartArt](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/smartart/)인지 확인하십시오.