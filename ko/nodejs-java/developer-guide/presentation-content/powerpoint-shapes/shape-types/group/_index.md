---
title: JavaScript에서 그룹 프레젠테이션 도형
linktitle: 도형 그룹
type: docs
weight: 40
url: /ko/nodejs-java/group/
keywords:
- 그룹 도형
- 도형 그룹
- 그룹 추가
- 대체 텍스트
- 파워포인트
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java를 사용하여 PowerPoint 프레젠테이션에서 도형을 그룹화하고 그룹 해제하는 방법을 배우세요 — 빠르고 단계별 가이드와 무료 JavaScript 코드 제공."
---
## **개요**

이 문서는 Aspose.Slides에서 그룹 도형을 사용하는 방법을 설명합니다. 슬라이드에 그룹 도형을 추가하고, 그 안에 도형을 배치한 뒤, 갱신된 프레젠테이션을 저장하는 방법을 보여줍니다. 또한 그룹에 포함된 도형에 접근하여 `AlternativeText` 값을 읽는 방법을 시연합니다. 추가로 중첩 그룹, z-순서 및 잠금 옵션과 같은 관련 그룹 도형 기능도 간략히 다룹니다.

## **그룹 도형 추가**
Aspose.Slides는 슬라이드에서 그룹 도형을 작업하는 것을 지원합니다. 이 기능을 통해 개발자는 보다 풍부한 프레젠테이션을 구현할 수 있습니다. Aspose.Slides for Node.js via Java는 그룹 도형을 추가하거나 접근하는 것을 지원합니다. 추가된 그룹 도형에 도형을 넣어 채우거나 그룹 도형의 모든 속성에 접근할 수 있습니다. Aspose.Slides for Node.js via Java를 사용하여 슬라이드에 그룹 도형을 추가하려면:

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
1. 인덱스를 사용하여 슬라이드의 참조를 얻습니다.
1. 슬라이드에 그룹 도형을 추가합니다.
1. 추가된 그룹 도형에 도형들을 추가합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예제는 슬라이드에 그룹 도형을 추가합니다.

```javascript
// Presentation 클래스를 인스턴스화합니다
var pres = new aspose.slides.Presentation();
try {
    // 첫 번째 슬라이드를 가져옵니다
    var sld = pres.getSlides().get_Item(0);
    // 슬라이드의 도형 컬렉션에 접근합니다
    var slideShapes = sld.getShapes();
    // 슬라이드에 그룹 도형을 추가합니다
    var groupShape = slideShapes.addGroupShape();
    // 추가된 그룹 도형 안에 도형을 추가합니다
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 300, 100, 100);
    // 그룹 도형 프레임을 추가합니다
    groupShape.setFrame(new aspose.slides.ShapeFrame(100, 300, 500, 40, aspose.slides.NullableBool.False, aspose.slides.NullableBool.False, 0));
    // PPTX 파일을 디스크에 저장합니다
    pres.save("GroupShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **AltText 속성 액세스**
이 항목에서는 그룹 도형을 추가하고 슬라이드의 그룹 도형에 대한 AltText 속성에 접근하는 간단한 단계와 코드 예제를 제공합니다. Aspose.Slides for Node.js via Java를 사용하여 슬라이드의 그룹 도형 AltText에 접근하려면:

1. PPTX 파일을 나타내는 [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스를 인스턴스화합니다.
1. 인덱스를 사용하여 슬라이드의 참조를 얻습니다.
1. 슬라이드의 도형 컬렉션에 접근합니다.
1. 그룹 도형에 접근합니다.
1. [getAlternativeText](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Shape#getAlternativeText--) 속성을 호출합니다.

아래 예제는 그룹 도형의 대체 텍스트에 접근합니다.

```javascript
// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
var pres = new aspose.slides.Presentation("AltText.pptx");
try {
    // 첫 번째 슬라이드를 가져옵니다
    var sld = pres.getSlides().get_Item(0);
    for (var i = 0; i < sld.getShapes().size(); i++) {
        // 슬라이드의 도형 컬렉션에 접근합니다
        var shape = sld.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.GroupShape")) {
            // 그룹 도형에 접근합니다.
            var grphShape = shape;
            for (var j = 0; j < grphShape.getShapes().size(); j++) {
                var shape2 = grphShape.getShapes().get_Item(j);
                // AltText 속성에 접근합니다
                console.log(shape2.getAlternativeText());
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**중첩 그룹화(그룹 내부에 그룹)가 지원되나요?**

예. [GroupShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/groupshape/)에는 [getParentGroup](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/getparentgroup/) 메서드가 있어 계층 구조 지원을 직접 나타냅니다(그룹은 다른 그룹의 하위 그룹이 될 수 있음).

**슬라이드의 다른 개체에 대한 그룹의 z-순서를 어떻게 제어합니까?**

[GroupShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/groupshape/)의 [getZOrderPosition](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/getzorderposition/) 메서드를 사용하여 디스플레이 스택에서의 위치를 확인합니다.

**이동/편집/그룹 해제 를 방지할 수 있나요?**

예. 그룹의 잠금 섹션은 [GroupShapeLock](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/groupshape/getgroupshapelock/)을 통해 노출되며, 이를 사용해 개체에 대한 작업을 제한할 수 있습니다.