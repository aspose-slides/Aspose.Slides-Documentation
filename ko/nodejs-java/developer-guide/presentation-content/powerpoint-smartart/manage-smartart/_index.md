---
title: JavaScript를 사용하여 PowerPoint 프레젠테이션에서 SmartArt 관리
linktitle: SmartArt 관리
type: docs
weight: 10
url: /ko/nodejs-java/manage-smartart/
keywords:
- SmartArt
- SmartArt 텍스트
- 레이아웃 유형
- 숨김 속성
- 조직도
- 그림 조직도
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "명확한 JavaScript 코드 샘플을 활용하여 Node.js용 Aspose.Slides로 PowerPoint SmartArt를 구축하고 편집하는 방법을 배우고, 슬라이드 디자인 및 자동화를 빠르게 수행합니다."
---
## **개요**

SmartArt는 노드, 노드 모양 및 레이아웃으로 구성된 PowerPoint 다이어그램입니다. Aspose.Slides for Node.js via Java를 사용하면 SmartArt를 만들고, 노드에서 텍스트를 읽고, 레이아웃을 변경하고, 숨겨진 노드를 검사하고, 조직도 레이아웃을 구성하며, 그림 조직도를 만들 수 있습니다.

## **SmartArt 객체에서 텍스트 가져오기**

SmartArt 노드에는 하나 이상의 모양이 포함될 수 있습니다. 노드 모양에서 텍스트를 읽으려면 [SmartArt.getAllNodes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/getallnodes/)을 반복한 다음 [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartshape/gettextframe/)이 반환하는 [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/)을 읽습니다.

예제는 최소 하나의 슬라이드와 해당 슬라이드의 첫 번째 모양으로 SmartArt 객체가 포함된 프레젠테이션이 필요합니다. 각 사용 가능한 텍스트 프레임을 콘솔에 출력합니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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
    } else {
        console.log("The first shape is not a SmartArt object.");
    }
} finally {
    presentation.dispose();
}
```

## **SmartArt 객체의 레이아웃 유형 변경**

SmartArt 레이아웃은 노드가 배치되고 연결되는 방식을 제어합니다. 다음 예제는 [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) `BasicBlockList` 값을 사용하여 SmartArt 객체를 만든 다음 `BasicProcess` 값으로 변경하고 프레젠테이션을 저장합니다. [ShapeCollection.addSmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addsmartart/)에 전달되는 위치와 크기는 포인트 단위입니다. 레이아웃을 변경하려면 [SmartArt.setLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/setlayout/)를 사용합니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicBlockList);
    smartArt.setLayout(aspose.slides.SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **SmartArt 노드가 숨겨져 있는지 확인**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/ishidden/)는 SmartArt 데이터 모델에서 노드가 숨겨져 있는지 여부를 나타냅니다. 선택된 레이아웃이 노드를 가시적인 다이어그램 요소로 표시하지 않더라도 숨겨진 노드는 구조에 존재할 수 있습니다.

다음 예제는 [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) `RadialCycle` 값을 사용하는 SmartArt 객체에 노드를 추가하고, 추가된 노드의 숨김 상태를 확인합니다. 노드가 숨겨져 있으면 메시지를 출력하고 다이어그램을 저장합니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.RadialCycle);
    let node = smartArt.getAllNodes().addNode();
    let isHidden = node.isHidden();

    if (isHidden) {
        console.log("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **조직도 레이아웃 가져오기 또는 설정하기**

조직도 레이아웃을 사용하는 SmartArt 다이어그램의 경우, [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/getorganizationchartlayout/) 및 [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/setorganizationchartlayout/)은 자식 노드가 상위 노드 아래에서 어떻게 배치되는지를 정의합니다. 예를 들어, 선택된 [OrganizationChartLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/organizationchartlayouttype/)에 따라 자식 노드를 왼쪽, 오른쪽 또는 양쪽에 매달리도록 설정할 수 있습니다.

다음 예제는 조직도를 만들고 첫 번째 노드의 레이아웃을 [OrganizationChartLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/organizationchartlayouttype/) `LeftHanging` 값으로 설정합니다. 0부터 시작하는 인덱스 `0`은 첫 번째 최상위 노드를 선택하며, 해당 노드의 자식 노드들은 선택된 배치를 사용합니다. 수정된 프레젠테이션을 저장합니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.OrganizationChart);
    let rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(aspose.slides.OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **그림 조직도 만들기**

그림 조직도는 이미지 자리 표시자를 포함하는 계층 구조 다이어그램을 위해 설계된 SmartArt 레이아웃입니다. 슬라이드에 SmartArt 객체를 추가할 때 [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` 값을 사용합니다. 이 예제는 이미지 자리 표시자가 포함된 다이어그램을 저장하지만, 자리 표시자를 이미지로 채우지는 않습니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **레거시 다이어그램을 그룹 형태로 변환**

기존 프레젠테이션을 최신화할 때 PowerPoint 97–2003에서 원래 만든 조직도를 업데이트해야 할 수 있습니다. Aspose.Slides는 이러한 레거시 다이어그램을 [LegacyDiagram](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/) 객체로 나타냅니다. 다이어그램을 개별 시각 요소를 편집할 수 있도록 그룹 형태로 변환하려면 [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/converttogroupshape/)을 사용합니다. 자세한 내용은 [LegacyDiagram API 참조](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/)를 참조하십시오.

변환은 원본 다이어그램을 제거하지 않고 새로운 그룹을 모양 컬렉션에 추가합니다. 변환이 성공하면 [ShapeCollection.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/remove/)를 사용하여 원본을 제거하여 중복 콘텐츠를 방지합니다. 변환하기 전에 레거시 다이어그램을 목록에 수집하면 모양을 추가·제거해도 반복이 중단되지 않습니다.

다음 예제는 프레젠테이션을 열고, 모든 슬라이드를 검색하여 다이어그램을 그룹 형태로 변환한 뒤, 업데이트된 프레젠테이션을 PPTX로 저장합니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("legacy-diagrams.ppt");
try {
    let slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        let slide = slides.get_Item(slideIndex);
        let shapes = slide.getShapes();
        let legacyDiagrams = [];
        for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
            let shape = shapes.get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.ILegacyDiagram")) {
                legacyDiagrams.push(shape);
            }
        }

        for (let legacyDiagram of legacyDiagrams) {
            let groupShape = legacyDiagram.convertToGroupShape();

            if (groupShape != null) {
                shapes.remove(legacyDiagram);
            }
        }
    }

    presentation.save("modernized.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

저장된 프레젠테이션에는 변환된 레거시 다이어그램 대신 편집 가능한 모양 그룹이 포함되어 있으며, 원본 다이어그램은 남아 있지 않습니다. PPTX를 PowerPoint에서 열어 각 그룹 내 개별 요소(텍스트, 채우기, 위치 등)를 편집할 수 있습니다.

## **FAQ**

**SmartArt가 RTL 언어에 대해 미러링이나 반전 기능을 지원합니까?**

예. 선택된 SmartArt 레이아웃이 반전을 지원하는 경우, [SmartArt.setReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/setreversed/) 메서드는 다이어그램 방향을 좌에서 우로부터 우에서 좌로(또는 그 반대로) 전환합니다.

**SmartArt를 동일한 슬라이드 또는 다른 프레젠테이션에 복사하면서 서식을 유지하려면 어떻게 해야 하나요?**

[SmartArt 모양을 복제](/slides/ko/nodejs-java/shape-manipulations/)는 [ShapeCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addclone/)을 사용하거나, SmartArt가 포함된 전체 슬라이드를 [복제](/slides/ko/nodejs-java/clone-slides/)할 수 있습니다. 두 방법 모두 크기, 위치 및 서식을 유지합니다.

**SmartArt를 미리 보기 또는 웹 내보내기를 위해 래스터 이미지로 렌더링하려면 어떻게 해야 하나요?**

[슬라이드를 렌더링](/slides/ko/nodejs-java/convert-powerpoint-to-png/)하거나 전체 프레젠테이션을 PNG 또는 JPEG로 렌더링합니다. SmartArt는 슬라이드의 일부로 렌더링됩니다.

**여러 개의 SmartArt 객체가 있는 경우 특정 SmartArt 객체를 슬라이드에서 어떻게 찾을 수 있나요?**

슬라이드에 있는 SmartArt 모양에 고유한 대체 텍스트 또는 이름을 할당하려면 [Shape.setAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setalternativetext/) 또는 [Shape.setName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setname/)을 사용하고, [BaseSlide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes)에서 해당 값을 검색한 다음, 일치하는 모양이 [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/)인지 확인합니다.