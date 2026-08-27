---
title: JavaScript에서 프레젠테이션 도형 관리
linktitle: 도형 조작
type: docs
weight: 40
url: /ko/nodejs-java/shape-manipulations/
keywords:
- PowerPoint 도형
- 프레젠테이션 도형
- 슬라이드의 도형
- 도형 찾기
- 도형 복제
- 도형 제거
- 도형 숨기기
- 도형 순서 변경
- interop 도형 ID 가져오기
- 도형 대체 텍스트
- 도형 조정 포인트
- 사전 설정 도형 조정
- 도형 기하
- 도형 레이아웃 형식
- SVG 형태 도형
- 도형을 SVG로
- 도형 정렬
- 도형 플립
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java를 사용하여 프레젠테이션 도형을 식별, 조정, 복제, 제거, 숨기기, 순서 변경, 내보내기, 정렬 및 플립하는 방법을 배우십시오."
---
## **개요**

Aspose.Slides for Node.js via Java 은 슬라이드의 도형을 순서가 있는 [ShapeCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shapecollection/) 으로 표현합니다. 이 컬렉션은 도형을 찾고 수정하는 위치이자, 쌓이는 순서의 원천입니다: 인덱스 `0` 은 가장 뒤쪽 도형이며, 마지막 인덱스는 가장 앞쪽 도형입니다.

이 문서는 해당 모델을 따릅니다. 먼저 도형을 신뢰성 있게 식별하고 사전 설정된 도형 조정 포인트를 수정하는 방법을 설명한 뒤, 도형을 복제, 제거, 숨기기 및 순서 변경하는 방법을 보여줍니다. 마지막 섹션에서는 레이아웃 수준 서식, SVG 내보내기, 정렬 및 플립 설정을 다룹니다. 각 예제는 독립적이므로 워크플로에 필요한 작업만 사용할 수 있습니다.

## **도형 식별 및 찾기**

컬렉션 인덱스는 알려진 파일을 처리할 때 편리하지만 안정적인 식별자는 아닙니다. 도형을 추가, 제거 또는 순서를 바꾸면 인덱스가 변할 수 있습니다. 프레젠테이션이 어떻게 작성되고 유지되는지에 따라 식별자를 선택하세요.

- [Name](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/getname/) 은 개발자가 제어하는 템플릿에 유용하며 PowerPoint 선택 창에서 쉽게 확인할 수 있습니다. 이름은 편집할 수 있지만 고유함이 보장되지 않으므로 코드가 이름에 의존한다면 명명 규칙을 정하십시오.
- [AlternativeText](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/getalternativetext/) 은 접근성 설명이나 작성자가 제공한 태그가 이미 도형을 식별할 때 유용합니다. 사용자가 볼 수 있으며 현지화되거나 접근성을 위해 재작성될 수 있지만 고유함이 보장되지 않습니다. 의미 있는 접근성 텍스트를 데이터베이스 키로 무단 재사용하지 마세요.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/) 은 슬라이드 내에서 고유한 읽기 전용 식별자로, PowerPoint interop에서 사용하는 도형 ID와 일치합니다. PowerPoint와 통합하거나 도형 수명 동안 명확한 참조가 필요할 때 사용하세요. 복제되거나 재생성된 도형은 다른 도형이며 자체 ID를 가집니다.

관련 [getUniqueId](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/getuniqueid/) 메서드는 프레젠테이션 범위의 식별자를 반환하지만, 이 식별자는 애드인용이며 재할당될 수 있습니다. 영구적인 외부 키로 취급해서는 안 됩니다. 장기적인 정체성이 필요하다면 애플리케이션 데이터에 매핑을 보관하고 기대한 도형이 여전히 존재하는지 검증하세요.

다음 예제는 이름을 정확히 비교하여 검색하고 슬라이드 범위의 interop ID를 보고합니다. 템플릿에 기대하는 도형이 없을 경우, 코드는 잘못된 객체로 진행하지 않고 해당 결과를 보고합니다.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var targetShape = null;
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "RevenueChart") {
            targetShape = shape;
            break;
        }
    }

    if (targetShape === null) {
        console.log("The shape 'RevenueChart' was not found on slide 1.");
    } else {
        console.log("Found " + targetShape.getName() + "; interop ID: " + targetShape.getOfficeInteropShapeId());
    }
} finally {
    presentation.dispose();
}
```

도형 유형에 특화된 작업을 수행할 때는 런타임 클래스를 확인한 후 타입별 멤버를 사용하세요. 이 예제는 명명된 객체가 [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape/) 인 경우에만 텍스트와 대체 텍스트를 업데이트합니다.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var candidate = null;
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "StatusLabel") {
            candidate = shape;
            break;
        }
    }

    if (candidate !== null && java.instanceOf(candidate, "com.aspose.slides.AutoShape")) {
        candidate.getTextFrame().setText("Approved");
        candidate.setAlternativeText("Approval status: approved");
        presentation.save("identified-shape.pptx", asposeSlides.SaveFormat.Pptx);
    } else {
        console.log("'StatusLabel' is missing or is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

## **사전 설정 도형 조정 식별 및 수정**

사전 설정 기하 도형은 코너 크기, 화살표 비율, 호 각도와 같은 기능을 제어하는 조정 포인트를 노출할 수 있습니다. 읽기 전용 [GeometryShape.getAdjustments](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/geometryshape/) 컬렉션을 통해 접근하세요. 컬렉션 자체는 도형이 제공하지만, 각 [AdjustValue](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/adjustvalue/) 에는 변경 가능한 값이 들어 있습니다.

고정된 컬렉션 인덱스에만 의존하지 마세요. 조정을 반복하며 읽기 전용 [getType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/adjustvalue/) 메서드를 검사하세요. 이 메서드의 [ShapeAdjustmentType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shapeadjustmenttype/) 값은 조정이 제어하는 내용을 설명합니다. 읽기 전용 [getName](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/adjustvalue/getname/) 메서드는 추가 식별 정보를 제공하며, 동일한 의미 유형이 여러 개 포함된 사전 설정에 특히 유용합니다.

조정 의미에 맞는 값 메서드를 사용하세요:

| Adjustment type | Purpose | Value to change |
|---|---|---|
| `CornerSize` | 둥근 코너 크기 | [setRawValue](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/adjustvalue/setrawvalue/) |
| `ArrowTailThickness` | 화살표 꼬리 두께 | `setRawValue` |
| `ArrowheadLength` | 화살촉 길이 | `setRawValue` |
| `ArrowheadWidth` | 화살촉 너비 | `setRawValue` |
| `StartAngle` | 파이·호의 시작 각도 | [setAngleValue](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/adjustvalue/setanglevalue/) |
| `EndAngle` | 파이·호의 끝 각도 | `setAngleValue` |

`getType` 과 `getName` 은 읽기 전용 정보를 반환합니다. `getRawValue` 와 `setRawValue` 는 사전 설정 고유의 기하 단위 정수를 사용하며, `getAngleValue` 와 `setAngleValue` 는 각도를 도 단위로 사용합니다. 조정의 개수, 순서, 의미 및 유효 범위는 사전 설정 [GeometryShape.getShapeType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/geometryshape/) 에 따라 달라집니다. 한 사전 설정에 유효한 값이 다른 사전 설정에서는 무효이거나 다른 효과를 낼 수 있습니다.

`getType` 이 `ShapeAdjustmentType.Custom` 을 반환하면 API 가 표준 의미를 인식하지 못합니다. `getName` 과 사전 유형, 기존 값을 검토하고 기대하는 의미와 범위가 명확하지 않으면 조정을 변경하지 마세요. 인식 가능한 유형이라도 동일 유형이 여러 번 등장하는지 확인한 후 값을 선택하십시오. [Connector](/slides/ko/nodejs-java/connector/) 문서에 연결선 굽힘 조정 사례가 소개되어 있습니다.

다음 완전한 예제는 세 가지 사전 설정 도형의 기본 및 수정 버전을 생성합니다. 모든 조정을 반복하면서 이름과 유형을 보고, `setRawValue` 로 크기 관련 값을 변경하고, `setAngleValue` 로 각도를 변경한 뒤 결과를 저장합니다. 왼쪽 열은 기본 기하를 유지하고, 오른쪽 열은 조정된 둥근 사각형, 사방향 화살표, 파이를 보여줍니다.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    // 기본 및 조정된 도형 열에 헤더를 추가합니다.
    var defaultColumnLabel = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 20, 250, 30);
    defaultColumnLabel.getTextFrame().setText("Default preset geometry");
    var adjustedColumnLabel = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 390, 20, 250, 30);
    adjustedColumnLabel.getTextFrame().setText("Modified adjustment values");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
    var modifiedRoundedRectangle = slide.getShapes().addAutoShape(asposeSlides.ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
    modifiedRoundedRectangle.setName("ModifiedRoundedRectangle");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.QuadArrow, 80, 180, 160, 110);
    var modifiedArrow = slide.getShapes().addAutoShape(asposeSlides.ShapeType.QuadArrow, 430, 180, 160, 110);
    modifiedArrow.setName("ModifiedQuadArrow");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.Pie, 95, 330, 130, 130);
    var modifiedPie = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Pie, 445, 330, 130, 130);
    modifiedPie.setName("ModifiedPie");

    var shapesToAdjust = [modifiedRoundedRectangle, modifiedArrow, modifiedPie];

    for (var shapeIndex = 0; shapeIndex < shapesToAdjust.length; shapeIndex++) {
        var shape = shapesToAdjust[shapeIndex];
        for (var adjustmentIndex = 0; adjustmentIndex < shape.getAdjustments().size(); adjustmentIndex++) {
            var adjustment = shape.getAdjustments().get_Item(adjustmentIndex);
            console.log(shape.getName() + " / " + adjustment.getName() + ": " + adjustment.getType());

            switch (adjustment.getType()) {
                case asposeSlides.ShapeAdjustmentType.CornerSize:
                    adjustment.setRawValue(5000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowTailThickness:
                    adjustment.setRawValue(25000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowheadLength:
                    adjustment.setRawValue(30000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowheadWidth:
                    adjustment.setRawValue(40000);
                    break;
                case asposeSlides.ShapeAdjustmentType.StartAngle:
                    adjustment.setAngleValue(30);
                    break;
                case asposeSlides.ShapeAdjustmentType.EndAngle:
                    adjustment.setAngleValue(300);
                    break;
                case asposeSlides.ShapeAdjustmentType.Custom:
                    console.log("Custom adjustment '" + adjustment.getName() + "' was not changed.");
                    break;
            }
        }
    }

    presentation.save("preset-shape-adjustments.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

값을 변경하기 전에 의미 유형을 확인하면 코드가 의도를 명확히 드러내고, 서로 다른 사전 설정 도형에서 같은 컬렉션 인덱스가 같은 의미를 가진다고 가정하는 실수를 방지합니다.

## **도형 컬렉션 수정**

추가, 복제, 제거 및 순서 변경 메서드는 컬렉션에 즉시 적용됩니다. 작업이 도형 수나 순서를 바꾸면, 해당 작업 이전에 캡처한 인덱스에 계속 의존하지 마세요.

### **도형 복제**

[addClone](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shapecollection/addclone/) 은 독립적인 사본을 만들고 대상 컬렉션에 추가합니다. [insertClone](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shapecollection/insertclone/) 도 사본을 만들지만 지정된 Z‑order 인덱스에 배치합니다. 좌표를 받아들이는 오버로드는 크기를 변경하지 않고 복제 위치만 이동시키고, 폭·높이를 받는 오버로드는 크기 조정도 가능합니다.

예제는 대상 슬라이드를 만들고 라벨이 붙은 사각형을 앞쪽에 복제한 뒤, 두 번째 복제를 뒤쪽에 삽입합니다. 두 복제 중 어느 하나를 수정해도 원본 도형은 변경되지 않습니다.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var sourceSlide = presentation.getSlides().get_Item(0);
    var sourceShape = sourceSlide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 180, 60);
    sourceShape.setName("SourceLabel");
    sourceShape.getTextFrame().setText("Source");

    var blankLayout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(java.newByte(asposeSlides.SlideLayoutType.Blank));
    var destinationSlide = presentation.getSlides().addEmptySlide(blankLayout);

    var frontClone = destinationSlide.getShapes().addClone(sourceShape, 80, 80);
    frontClone.setName("FrontClone");
    if (java.instanceOf(frontClone, "com.aspose.slides.AutoShape")) {
        frontClone.getTextFrame().setText("Front clone");
    } else {
        console.log("The front clone is not an AutoShape; its text was not changed.");
    }

    var backClone = destinationSlide.getShapes().insertClone(0, sourceShape, 80, 180);
    backClone.setName("BackClone");
    if (java.instanceOf(backClone, "com.aspose.slides.AutoShape")) {
        backClone.getTextFrame().setText("Back clone");
    } else {
        console.log("The back clone is not an AutoShape; its text was not changed.");
    }

    presentation.save("cloned-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

복제는 도형의 내용과 서식을 복사하며, 이름과 대체 텍스트도 포함합니다. 해당 값들이 고유해야 한다면 복제본에 새로운 논리 식별자를 할당하세요. 복합 도형이 사용하는 리소스는 프레젠테이션이 관리하지만, 복제는 새로운 컬렉션 항목이자 새로운 도형 ID를 갖습니다.

### **도형 제거**

[remove](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shapecollection/remove/) 은 특정 도형 객체를 컬렉션에서 삭제합니다. 인덱스 기반 반복 중 여러 일치를 제거할 때는 뒤에서부터 순회하여 남은 인덱스가 유효하도록 하세요.

이 예제는 지정된 이름을 가진 모든 도형을 제거합니다. 현재 인덱스의 도형을 읽고 특정 도형 유형을 가정하지 않습니다.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var keepShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 140, 60);
    keepShape.setName("Keep");

    var firstTemporaryShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 220, 40, 80, 80);
    firstTemporaryShape.setName("Temporary");

    var secondTemporaryShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Triangle, 340, 40, 100, 80);
    secondTemporaryShape.setName("Temporary");

    for (var i = slide.getShapes().size() - 1; i >= 0; i--) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "Temporary") {
            slide.getShapes().remove(shape);
        }
    }

    presentation.save("removed-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

제거 후에는 도형 수와 뒤쪽 도형들의 인덱스가 변화합니다. 영향을 받지 않은 도형에 대한 참조는 저장된 인덱스보다 더 신뢰할 수 있습니다. 또한 연결선, 애니메이션 및 기타 프레젠테이션 기능이 제거된 객체를 참조할 수 있으므로, 보이는 도형을 제거하면 슬라이드 외관 이상을 변경할 수 있음을 고려하세요.

### **도형 숨기기**

[Hidden](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/sethidden/) 을 `true` 로 설정하면 도형이 컬렉션에 남아 있지만 일반 슬라이드 쇼에서는 표시되지 않습니다. 인덱스, 서식, 내용은 코드에서 그대로 접근 가능하므로, 나중에 복원될 수 있는 선택적 요소에 적합합니다.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var visibleShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 160, 60);
    visibleShape.setName("VisibleLabel");

    var optionalShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Moon, 240, 40, 100, 100);
    optionalShape.setName("OptionalDecoration");

    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "OptionalDecoration") {
            shape.setHidden(true);
        }
    }

    presentation.save("hidden-shape.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

숨기기는 삭제나 보안이 아닙니다. 사용자가 혹은 코드가 도형을 발견하고 다시 표시할 수 있으며, 프레젠테이션 파일의 일부로 계속 존재합니다.

### **Z‑Order 변경**

겹치는 도형은 컬렉션 순서대로 그려집니다. [reorder](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shapecollection/reorder/) 은 기존 도형을 복제하지 않고 목표 인덱스로 이동합니다. 인덱스 `0` 은 뒤쪽, `size() - 1` 은 앞쪽을 의미합니다.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var blueRectangle = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 100, 100, 220, 120);
    blueRectangle.setName("BlueRectangle");
    blueRectangle.getFillFormat().setFillType(java.newByte(asposeSlides.FillType.Solid));
    blueRectangle.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    var orangeEllipse = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 180, 140, 220, 120);
    orangeEllipse.setName("OrangeEllipse");
    orangeEllipse.getFillFormat().setFillType(java.newByte(asposeSlides.FillType.Solid));
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

사각형을 먼저 만들면 처음엔 타원 뒤에 놓입니다. 최종 인덱스로 이동하면 앞쪽에 배치됩니다. 모든 관련 도형을 추가하거나 복제한 뒤에 Z‑order 를 최종 지정하세요. 이러한 작업은 새 컬렉션 항목을 추가하거나 삽입하면서 스택 순서를 바꿀 수 있습니다.

## **레이아웃 슬라이드의 도형 검사**

보통 슬라이드, 레이아웃 슬라이드, 마스터 슬라이드는 각각 별도 도형 컬렉션을 가집니다. 레이아웃 컬렉션의 도형은 일반 슬라이드에 동일한 위치에 있더라도 같은 객체가 아닙니다. 레이아웃이 제공하는 서식을 이해하거나 변경해야 할 때 레이아웃 도형을 검사하세요.

다음 예제는 각 레이아웃 도형의 [FillFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/getfillformat/) 과 [LineFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/getlineformat/) 을 읽으며, 모든 도형이 `AutoShape` 인 것으로 가정하지 않습니다.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    for (var i = 0; i < presentation.getLayoutSlides().size(); i++) {
        var layoutSlide = presentation.getLayoutSlides().get_Item(i);
        for (var j = 0; j < layoutSlide.getShapes().size(); j++) {
            var shape = layoutSlide.getShapes().get_Item(j);
            var fillType = shape.getFillFormat().getFillType();
            var lineWidth = shape.getLineFormat().getWidth();
            console.log(layoutSlide.getName() + " / " + shape.getName() + ": fill=" + fillType + ", line width=" + lineWidth);
        }
    }
} finally {
    presentation.dispose();
}
```

레이아웃을 편집하면 해당 레이아웃을 사용하는 여러 슬라이드에 영향을 미칠 수 있습니다. 레이아웃 도형을 변경하기 전에 일반 슬라이드가 해당 객체를 상속받는지, 로컬 오버라이드가 있는지 확인하고, 해당 레이아웃을 사용하는 모든 슬라이드에서 테스트하세요.

## **도형을 SVG 로 내보내기**

[writeAsSvg](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/writeassvg/) 은 하나의 도형이 렌더링된 내용을 스트림에 기록합니다. 결과에는 해당 도형만 포함되며 전체 슬라이드 배경이나 주변 도형은 포함되지 않습니다.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() === 0) {
        console.log("Slide 1 does not contain a shape to export.");
    } else {
        var shape = slide.getShapes().get_Item(0);
        var svgStream = null;
        try {
            svgStream = java.newInstanceSync("java.io.FileOutputStream", "shape.svg");
            shape.writeAsSvg(svgStream);
        } catch (error) {
            console.log("The SVG file could not be written: " + error.message);
        } finally {
            if (svgStream !== null) {
                svgStream.close();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

렌더링 중에는 프레젠테이션을 열어 두세요. 출력은 도형 서식과 글꼴, 이미지와 같은 리소스에 따라 달라집니다. 전체 구성이 필요하면 개별 도형이 아니라 슬라이드를 내보내세요. 호출자가 스트림을 소유하며, 스트림은 반드시 닫아야 합니다.

## **도형 정렬**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slideutil/alignshapes/) 오버로드는 모든 도형이나 선택된 컬렉션 인덱스를 정렬합니다. [ShapesAlignmentType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shapesalignmenttype/) 은 가장자리, 중앙선 또는 분포 모드를 지정합니다. `alignToSlide` 를 `true` 로 설정하면 슬라이드 가장자리를 기준으로, `false` 로 설정하면 선택된 도형 간의 상대 정렬을 수행합니다.

다음 예제는 세 도형을 슬라이드 상단 가장자리에 맞춥니다. 반환된 도형 참조는 정렬 직전에 현재 인덱스로 변환됩니다.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var firstShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 60, 80, 120, 50);
    var secondShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 240, 160, 120, 50);
    var thirdShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Triangle, 420, 240, 120, 50);
    firstShape.setName("FirstAlignedShape");
    secondShape.setName("SecondAlignedShape");
    thirdShape.setName("ThirdAlignedShape");

    var shapeIndexes = java.newArray("int", [slide.getShapes().indexOf(firstShape), slide.getShapes().indexOf(secondShape), slide.getShapes().indexOf(thirdShape)]);

    asposeSlides.SlideUtil.alignShapes(asposeSlides.ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
    presentation.save("aligned-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

정렬은 위치만 변경하고 Z‑order는 바꾸지 않습니다. 상대 정렬은 보통 두 개 이상의 도형이 필요하고, 가로나 세로 분포는 충분한 도형이 있어야 간격을 정의할 수 있습니다. 메서드 호출 전에 컬렉션을 수정했다면 인덱스를 다시 계산하세요.

## **도형 플립**

[ShapeFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shapeframe/) 클래스는 위치, 크기, 수평·수직 플립 설정 및 회전을 저장합니다. `getFlipH` 와 `getFlipV` 값은 [NullableBool](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/nullablebool/) 를 사용합니다: `True` 는 플립을 활성화하고, `False` 는 비활성화하며, `NotDefined` 는 지정되지 않은/기본 상태를 유지합니다.

아래 입력 프레젠테이션에는 플립되지 않은 도형 하나가 포함되어 있습니다.

![The shape before flipping](shape_to_be_flipped.png)

예제는 모든 다른 프레임 값을 그대로 유지하면서 두 플립 설정만 교체합니다. 이는 새로운 [Frame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/setframe/) 을 할당하면 전체 프레임이 교체되기 때문에 중요합니다.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    var frame = shape.getFrame();

    console.log("Horizontal flip before change: " + frame.getFlipH());
    console.log("Vertical flip before change: " + frame.getFlipV());

    var changedFrame = new asposeSlides.ShapeFrame(java.newFloat(frame.getX()), java.newFloat(frame.getY()), java.newFloat(frame.getWidth()), java.newFloat(frame.getHeight()), java.newByte(asposeSlides.NullableBool.True), java.newByte(asposeSlides.NullableBool.True), java.newFloat(frame.getRotation()));
    shape.setFrame(changedFrame);

    presentation.save("flipped-shape.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

저장된 도형은 수평·수직으로 모두 미러링되지만 위치, 크기 및 회전은 그대로 유지됩니다.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**컬렉션 인덱스를 도형 식별자로 사용해도 될까요?**

컬렉션이 인덱스 사용 전까지 변하지 않을 짧은 처리 과정에서만 사용하세요. 작성된 템플릿에는 검증된 `Name` 또는 `AlternativeText` 규약을, 슬라이드 범위 interop 작업에는 `OfficeInteropShapeId` 를 권장합니다.

**도형을 숨기면 Z‑order 에서 제거되나요?**

아니요. 숨긴 도형은 동일한 인덱스에 남아 있으며, 찾아내고, 순서를 바꾸고, 편집하거나 다시 표시할 수 있습니다.

**복제된 도형이 다른 도형 앞에 나타난 이유는?**

`addClone` 은 복제본을 컬렉션 끝에 추가하므로 Z‑order 의 앞쪽에 배치됩니다. 초기 인덱스를 지정하려면 `insertClone` 을 사용하거나 모든 도형을 추가한 뒤 `reorder` 로 위치를 조정하세요.

**고정 인덱스로 사전 설정 도형 조정을 식별해도 될까요?**

정확한 사전 설정과 컬렉션 레이아웃을 검증한 경우에만 가능합니다. `GeometryShape.getAdjustments` 를 반복하면서 `AdjustValue.getType` 을 확인하고, 같은 의미 유형이 여러 번 나타날 경우 `AdjustValue.getName` 을 추가 정보로 활용하세요.