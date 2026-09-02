---
title: "JavaScript에서 프레젠테이션 도형 관리"
linktitle: "도형 조작"
type: docs
weight: 40
url: /ko/nodejs-java/shape-manipulations/
keywords:
- "PowerPoint 도형"
- "프레젠테이션 도형"
- "슬라이드의 도형"
- "도형 찾기"
- "도형 복제"
- "도형 삭제"
- "도형 숨기기"
- "도형 순서 변경"
- "interop 도형 ID 가져오기"
- "도형 대체 텍스트"
- "도형 레이아웃 서식"
- "SVG 형태 도형"
- "도형을 SVG로"
- "도형 정렬"
- "도형 뒤집기"
- "PowerPoint"
- "프레젠테이션"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Aspose.Slides for Node.js via Java를 사용하여 프레젠테이션 도형을 식별하고, 복제하고, 삭제하고, 숨기고, 순서를 변경하고, 내보내고, 정렬하고, 뒤집는 방법을 알아보세요."
---
## **개요**

Aspose.Slides for Node.js via Java 은 슬라이드의 도형을 정렬된 [ShapeCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shapecollection/) 으로 표현합니다. 이 컬렉션은 도형을 찾고 수정하는 위치이자, 도형의 쌓임 순서를 결정하는 원천입니다: 인덱스 `0` 은 가장 뒤쪽 도형이며, 마지막 인덱스는 가장 앞쪽 도형입니다.

이 문서는 해당 모델을 따릅니다. 먼저 도형을 안정적으로 식별하는 방법을 설명하고, 이어서 도형을 복제, 삭제, 숨기기 및 순서 변경하는 방법을 보여줍니다. 마지막 섹션에서는 레이아웃 수준 서식, SVG 내보내기, 정렬 및 뒤집기 설정을 다룹니다. 각 예시는 독립적이므로 작업 흐름에 필요한 작업만 사용할 수 있습니다.

## **도형 식별 및 검색**

컬렉션 인덱스는 알려진 파일을 처리할 때 편리하지만 안정적인 식별자는 아닙니다. 도형을 추가, 삭제 또는 순서를 바꾸면 인덱스가 변합니다. 프레젠테이션이 어떻게 제작·관리되는지에 따라 식별자를 선택하십시오:

- [Name](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/getname/) 은 개발자가 제어하는 템플릿에 유용하며 PowerPoint의 선택 창에서 쉽게 확인할 수 있습니다. 이름은 편집 가능하지만 고유성을 보장하지 않으므로 코드가 이름에 의존한다면 명명 규칙을 정의하십시오.
- [AlternativeText](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/getalternativetext/) 은 접근성 설명이나 작성자가 제공한 태그가 이미 도형을 식별할 때 유용합니다. 사용자는 이를 볼 수 있으며 현지화되거나 접근성을 위해 재작성될 수 있지만 고유성을 보장하지 않습니다. 의미 있는 접근성 텍스트를 데이터베이스 키로 무심코 재사용하지 마십시오.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/) 은 슬라이드 내에서 고유한 읽기 전용 식별자로, PowerPoint interop에서 사용하는 도형 ID와 일치합니다. PowerPoint와 통합하거나 도형 수명 동안 명확한 참조가 필요할 때 사용하십시오. 복제되거나 다시 생성된 도형은 다른 도형이며 자체 ID를 갖습니다.

관련 [getUniqueId](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/getuniqueid/) 메서드는 프레젠테이션 범위의 식별자를 반환하지만, 이 식별자는 애드인용이며 재할당될 수 있습니다. 영구적인 외부 키로 취급하지 말고, 장기적인 식별이 필요하다면 애플리케이션 데이터에 매핑을 보관하고 기대한 도형이 여전히 존재하는지 검증하십시오.

다음 예시는 정확히 일치하는 이름으로 검색하고 슬라이드 범위의 interop ID를 보고합니다. 템플릿에 기대한 도형이 없을 경우, 코드가 잘못된 객체로 진행하는 대신 해당 결과를 보고합니다.

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

작업이 특정 도형 유형에 국한될 경우, 유형‑특정 멤버를 사용하기 전에 런타임 클래스를 확인하십시오. 이 예시는 이름이 지정된 객체가 [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape/) 인 경우에만 텍스트와 대체 텍스트를 업데이트합니다.

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

## **도형 컬렉션 수정**

add, clone, remove, reorder 메서드는 컬렉션에 즉시 적용됩니다. 작업이 도형 수나 순서를 변경하면, 그 작업 이전에 캡처한 인덱스에 의존하지 마십시오.

### **도형 복제**

[addClone](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shapecollection/addclone/) 은 독립적인 복사본을 생성하고 대상 컬렉션에 추가합니다. [insertClone](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shapecollection/insertclone/) 도 복사본을 만들지만 지정된 z‑order 인덱스에 배치합니다. 좌표를 받아들이는 오버로드는 크기를 변경하지 않고 복제본을 이동하고, 너비와 높이를 받아들이는 오버로드는 크기도 조정합니다.

예시는 목적 슬라이드를 만들고, 라벨이 붙은 사각형을 앞쪽에 복제한 뒤, 두 번째 복제본을 뒤쪽에 삽입합니다. 어느 복제본을 변경해도 원본 도형은 수정되지 않습니다.

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

복제는 도형의 내용과 서식을 복사하며, 이름과 대체 텍스트도 포함합니다. 이러한 값이 고유해야 할 경우 복제본에 새로운 논리 식별자를 할당하십시오. 복잡한 도형이 사용하는 리소스는 프레젠테이션이 관리하지만, 복제본은 새로운 컬렉션 항목이자 새로운 도형 아이덴티티를 가집니다.

### **도형 삭제**

[remove](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shapecollection/remove/) 은 특정 도형 객체를 컬렉션에서 삭제합니다. 인덱스를 사용한 반복 중에 여러 매치를 삭제할 경우, 남은 인덱스가 계속 유효하도록 역순으로 순회하십시오.

이 예시는 지정된 이름을 가진 모든 도형을 삭제합니다. 현재 인덱스의 도형을 읽고 특정 도형 유형을 가정하지 않습니다.

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

삭제 후에는 도형 수와 이후 도형들의 인덱스가 변합니다. 영향을 받지 않은 도형에 대한 참조는 저장된 인덱스보다 더 신뢰할 수 있습니다. 또한 연결선, 애니메이션 등 삭제된 객체를 참조할 수 있는 프레젠테이션 기능을 고려하십시오; 보이는 도형을 삭제하면 슬라이드 외관 이상의 변화가 발생할 수 있습니다.

### **도형 숨기기**

[Hidden](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/sethidden/) 을 `true` 로 설정하면 도형이 컬렉션에 남아 있지만 일반 슬라이드 쇼에서는 표시되지 않습니다. 인덱스, 서식, 내용은 코드에서 여전히 사용할 수 있으므로, 나중에 복구할 수 있는 선택 요소에 적합합니다.

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

숨기기는 삭제나 보안이 아닙니다. 사용자는 물론 코드도 객체를 발견하고 다시 보이게 할 수 있으며, 파일에 그대로 유지됩니다.

### **Z‑Order 변경**

겹치는 도형은 컬렉션 순서대로 그려집니다. [reorder](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shapecollection/reorder/) 은 복제 없이 기존 도형을 목표 인덱스로 이동합니다. 인덱스 `0` 은 뒤쪽, `size() - 1` 은 앞쪽입니다.

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

사각형을 먼저 생성하면 처음에는 타원 뒤에 놓입니다. 마지막 인덱스로 이동하면 앞쪽에 위치하게 됩니다. 모든 관련 도형을 추가하거나 복제한 후에 z‑order 를 최종 확정하십시오. 이러한 작업은 새 컬렉션 항목을 추가하거나 삽입하여 의도한 스택을 변경할 수 있기 때문입니다.

## **레이아웃 슬라이드의 도형 검사**

일반 슬라이드, 레이아웃 슬라이드, 마스터 슬라이드는 각각 별도 도형 컬렉션을 가집니다. 레이아웃 컬렉션의 도형은 일반 슬라이드에 동일한 위치에 있더라도 같은 객체가 아닙니다. 레이아웃이 제공하는 서식을 이해하거나 변경해야 할 때 레이아웃 도형을 검사하십시오.

다음 예시는 각 레이아웃 도형의 [FillFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/getfillformat/) 과 [LineFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/getlineformat/) 을 읽으며, 모든 도형이 `AutoShape` 인 것은 가정하지 않습니다.

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

레이아웃을 편집하면 해당 레이아웃을 사용하는 여러 슬라이드에 영향을 줄 수 있습니다. 레이아웃 도형을 변경하기 전에 일반 슬라이드가 객체를 상속받는지, 로컬 오버라이드가 있는지 확인하고, 해당 레이아웃을 사용하는 모든 슬라이드를 테스트하십시오.

## **도형을 SVG 로 내보내기**

[writeAsSvg](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/writeassvg/) 은 하나의 도형을 렌더링한 내용을 스트림에 기록합니다. 결과에는 해당 도형만 포함되며 슬라이드 전체 배경이나 주변 도형은 포함되지 않습니다.

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

렌더링 중에는 프레젠테이션을 열어 두어야 합니다. 출력은 도형의 서식과 폰트·이미지와 같은 리소스에 따라 달라집니다. 전체 구성이 필요하면 개별 도형이 아니라 슬라이드를 내보내십시오. 스트림의 소유자는 스트림을 닫아야 합니다.

## **도형 정렬**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slideutil/alignshapes/) 오버로드는 모든 도형 또는 선택된 컬렉션 인덱스를 정렬합니다. [ShapesAlignmentType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shapesalignmenttype/) 은 가장자리, 중앙선 또는 배치 모드를 지정합니다. `alignToSlide` 를 `true` 로 설정하면 슬라이드 가장자리를 기준으로 정렬하고, `false` 로 설정하면 선택된 도형끼리 상대적으로 정렬합니다.

이 예시는 세 도형을 슬라이드 상단 가장자리에 정렬합니다. 반환된 도형 참조는 정렬 직전에 현재 인덱스로 변환됩니다.

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

정렬은 위치만 변경하고 z‑order 는 바꾸지 않습니다. 상대 정렬은 보통 최소 두 개의 도형이 필요하고, 수평·수직 배치는 충분한 도형이 있어야 간격을 정의할 수 있습니다. 메서드를 호출하기 전에 컬렉션을 수정했다면 인덱스를 다시 계산하십시오.

## **도형 뒤집기**

[ShapeFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shapeframe/) 클래스는 위치, 크기, 가로·세로 뒤집기 설정 및 회전을 저장합니다. `getFlipH` 와 `getFlipV` 값은 [NullableBool](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/nullablebool/) 을 사용합니다: `True` 가 뒤집기를 활성화하고, `False` 가 비활성화하며, `NotDefined` 가 지정되지 않은/기본 상태를 유지합니다.

아래 입력 프레젠테이션에는 뒤집히지 않은 도형 하나가 포함되어 있습니다.

![The shape before flipping](shape_to_be_flipped.png)

예시는 다른 모든 프레임 값을 그대로 유지하면서 두 뒤집기 설정만 교체합니다. 이는 새로운 [Frame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/setframe/) 을 할당하면 전체 프레임이 교체되기 때문에 중요합니다.

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

저장된 도형은 위치·크기·회전은 유지한 채 가로·세로로 각각 반전됩니다.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**컬렉션 인덱스를 도형 식별자로 사용해도 될까요?**

컬렉션이 변하지 않을 짧은 처리 과정에만 사용하십시오. 작성된 템플릿에는 검증된 `Name` 또는 `AlternativeText` 규칙을, 슬라이드 범위의 interop 작업에는 `OfficeInteropShapeId` 를 선호하십시오.

**도형을 숨기면 z‑order 에서 사라지나요?**

아니요. 숨긴 도형은 동일한 인덱스에 그대로 남아 있으며, 찾고, 순서를 바꾸고, 편집하거나 다시 보이게 할 수 있습니다.

**복제된 도형이 다른 도형 앞에 나타난 이유는?**

`addClone` 은 복제본을 컬렉션 끝에 추가하므로 z‑order 의 앞쪽에 위치합니다. 초기 인덱스를 지정하려면 `insertClone` 을 사용하거나 모든 도형을 추가한 뒤 `reorder` 로 위치를 조정하십시오.