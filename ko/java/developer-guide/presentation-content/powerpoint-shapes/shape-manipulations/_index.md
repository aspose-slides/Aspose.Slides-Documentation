---
title: Java에서 프레젠테이션 모양 관리
linktitle: 모양 조작
type: docs
weight: 40
url: /ko/java/shape-manipulations/
keywords:
- PowerPoint 모양
- 프레젠테이션 모양
- 슬라이드의 모양
- 모양 찾기
- 모양 복제
- 모양 제거
- 모양 숨기기
- 모양 순서 변경
- Interop 모양 ID 가져오기
- 모양 대체 텍스트
- 모양 조정점
- 사전 정의 모양 조정
- 모양 기하
- 모양 레이아웃 서식
- SVG 형식 모양
- 모양을 SVG로
- 모양 정렬
- 모양 뒤집기
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 프레젠테이션 모양을 식별, 조정, 복제, 제거, 숨기기, 순서 변경, 내보내기, 정렬 및 뒤집는 방법을 알아보세요."
---
## **개요**

Aspose.Slides for Java는 슬라이드의 모양을 순서가 있는 [IShapeCollection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishapecollection/) 로 나타냅니다. 이 컬렉션은 모양을 찾고 수정하는 위치이자 쌓이는 순서의 원천이며, 인덱스 `0`은 가장 뒤에 있는 모양이고 마지막 인덱스는 가장 앞에 있는 모양을 의미합니다.

이 문서는 해당 모델을 따라 설명합니다. 먼저 모양을 안정적으로 식별하고 사전 정의된 모양 조정점을 수정하는 방법을 설명한 뒤, 모양을 복제, 제거, 숨기기 및 순서 변경하는 방법을 보여줍니다. 마지막 섹션에서는 레이아웃 수준 서식, SVG 내보내기, 정렬 및 뒤집기 설정을 다룹니다. 각 예제는 독립적이므로 워크플로에 필요한 작업만 사용할 수 있습니다.

## **모양 식별 및 찾기**

컬렉션 인덱스는 알려진 파일을 처리할 때 편리하지만 안정적인 식별자는 아닙니다. 모양을 추가, 제거 또는 순서를 변경하면 인덱스가 변할 수 있습니다. 프레젠테이션이 어떻게 작성되고 유지되는지에 따라 식별자를 선택하십시오.

- [Name](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/#getName--) 은 개발자가 제어하는 템플릿에 유용하며 PowerPoint 선택 창에서 쉽게 확인할 수 있습니다. 이름은 편집 가능하지만 고유성을 보장하지 않으므로 코드가 이름에 의존한다면 명명 규칙을 마련하십시오.
- [AlternativeText](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/#getAlternativeText--) 은 접근성 설명이나 작성자가 제공한 태그가 이미 모양을 식별할 때 유용합니다. 사용자가 볼 수 있고 지역화되거나 접근성을 위해 재작성될 수 있지만 고유성을 보장하지 않습니다. 의미 있는 접근성 텍스트를 데이터베이스 키로 은밀히 재사용하지 마십시오.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--) 은 읽기 전용 식별자로 슬라이드 내에서 고유하며 PowerPoint 인터옵에서 사용하는 모양 ID와 일치합니다. PowerPoint와 통합하거나 모양 수명 동안 명확한 참조가 필요할 때 사용하십시오. 복제되거나 다시 생성된 모양은 다른 모양이며 자체 ID를 가집니다.

관련 [getUniqueId](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/#getUniqueId--) 메서드는 프레젠테이션 범위의 식별자를 반환하지만, 이는 애드인용이며 재할당될 수 있습니다. 영구적인 외부 키로 취급해서는 안 됩니다. 장기적인 정체성이 필요하면 애플리케이션 데이터에 매핑을 보관하고 기대한 모양이 여전히 존재하는지 검증하십시오.

대체 텍스트 제목과 설명을 읽고 업데이트하는 실용적인 예제는 [대체 텍스트 제목 및 설명 관리](/slides/ko/java/presentation-accessibility/) 를 참조하십시오. 대체 텍스트는 시각 요소의 의미를 독자에게 설명하는 데 사용하고, 코드가 모양을 찾는 데 사용하는 이름과는 별도로 유지하십시오.

다음 예제는 정확히 일치하는 이름으로 검색하고 슬라이드 범위의 인터옵 ID를 보고합니다. 템플릿에 예상 모양이 없을 경우, 코드는 잘못된 객체로 진행하지 않고 해당 결과를 보고합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape targetShape = null;
    for (IShape shape : slide.getShapes()) {
        if ("RevenueChart".equals(shape.getName())) {
            targetShape = shape;
            break;
        }
    }

    if (targetShape == null) {
        System.out.println("The shape 'RevenueChart' was not found on slide 1.");
    } else {
        System.out.println("Found " + targetShape.getName() + "; interop ID: " + targetShape.getOfficeInteropShapeId());
    }
} finally {
    presentation.dispose();
}
```

작업이 특정 모양 유형에만 적용되는 경우, 타입별 멤버를 사용하기 전에 인터페이스를 확인하십시오. 이 예제는 명명된 객체가 [IAutoShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iautoshape/) 인 경우에만 텍스트와 대체 텍스트를 업데이트합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape candidate = null;
    for (IShape shape : slide.getShapes()) {
        if ("StatusLabel".equals(shape.getName())) {
            candidate = shape;
            break;
        }
    }

    if (candidate instanceof IAutoShape) {
        IAutoShape autoShape = (IAutoShape) candidate;
        autoShape.getTextFrame().setText("Approved");
        autoShape.setAlternativeText("Approval status: approved");
        presentation.save("identified-shape.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("'StatusLabel' is missing or is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

## **사전 정의된 모양 조정 식별 및 수정**

사전 정의된 기하학 모양은 코너 크기, 화살표 비율, 호 각도와 같은 특징을 제어하는 조정점을 노출할 수 있습니다. 이러한 조정점은 읽기 전용 [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/ko/java/com.aspose.slides/igeometryshape/#getAdjustments--) 컬렉션을 통해 접근합니다. 컬렉션 자체는 모양이 제공하지만, 각 [IAdjustValue](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iadjustvalue/) 은 변경 가능한 값을 포함합니다.

고정된 컬렉션 인덱스에만 의존하지 마십시오. 조정점을 반복하면서 읽기 전용 [getType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iadjustvalue/#getType--) 메서드를 검사하십시오. 이 메서드의 [ShapeAdjustmentType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/shapeadjustmenttype/) 값은 조정이 제어하는 내용을 설명합니다. 읽기 전용 [getName](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iadjustvalue/#getName--) 메서드는 추가 식별 정보를 제공하며, 동일한 의미 유형의 조정이 여러 개 포함된 사전 정의에 특히 유용합니다.

조정 의미에 맞는 값 메서드를 사용하십시오:

| Adjustment type | Purpose | Value to change |
|---|---|---|
| `CornerSize` | 둥근 모서리의 크기 | [setRawValue](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iadjustvalue/#setRawValue-long-) |
| `ArrowTailThickness` | 화살표 꼬리의 두께 | `setRawValue` |
| `ArrowheadLength` | 화살표 머리의 길이 | `setRawValue` |
| `ArrowheadWidth` | 화살표 머리의 너비 | `setRawValue` |
| `StartAngle` | 파이 또는 호의 시작 각도 | [setAngleValue](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iadjustvalue/#setAngleValue-float-) |
| `EndAngle` | 파이 또는 호의 종료 각도 | `setAngleValue` |

`getType` 및 `getName` 은 읽기 전용 정보를 반환합니다. `getRawValue`와 `setRawValue`는 사전 정의의 원시 기하 단위 정수를 사용하고, `getAngleValue`와 `setAngleValue`는 각도를 도 단위로 사용합니다. 조정의 개수, 순서, 의미 및 유효 범위는 사전 정의된 [ShapeType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/igeometryshape/#getShapeType--)에 따라 달라집니다. 한 사전 정의에 유효한 값이 다른 사전 정의에서는 무효이거나 다른 효과를 가질 수 있습니다.

`getType`이 `ShapeAdjustmentType.Custom`을 반환하면 API가 표준 의미를 인식하지 못합니다. `getName`, 사전 정의 유형 및 기존 값을 검토하고, 기대하는 의미와 범위가 명확하지 않은 경우 조정값을 변경하지 마십시오. 인식된 유형이라도 동일한 유형이 여러 번 나타나는 경우 값을 선택하기 전에 확인하십시오. [Connector](/slides/ko/java/connector/) 문서에서 커넥터 굽힘 조정 상황을 확인할 수 있습니다.

다음 완전한 예제는 세 가지 사전 정의 모양의 기본 및 수정 버전을 생성합니다. 모든 조정을 반복하면서 이름과 유형을 보고하고, `setRawValue`로 크기 관련 값을, `setAngleValue`로 각도를 변경한 뒤 결과를 저장합니다. 왼쪽 열은 기본 기하를 유지하고, 오른쪽 열은 조정된 둥근 사각형, 네방향 화살표 및 파이를 보여줍니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 기본 및 조정된 모양 열에 대한 헤더를 추가합니다.
    IAutoShape defaultColumnLabel = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 20, 250, 30);
    defaultColumnLabel.getTextFrame().setText("Default preset geometry");
    IAutoShape adjustedColumnLabel = slide.getShapes().addAutoShape(ShapeType.Rectangle, 390, 20, 250, 30);
    adjustedColumnLabel.getTextFrame().setText("Modified adjustment values");

    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
    IGeometryShape modifiedRoundedRectangle = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
    modifiedRoundedRectangle.setName("ModifiedRoundedRectangle");

    slide.getShapes().addAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110);
    IGeometryShape modifiedArrow = slide.getShapes().addAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110);
    modifiedArrow.setName("ModifiedQuadArrow");

    slide.getShapes().addAutoShape(ShapeType.Pie, 95, 330, 130, 130);
    IGeometryShape modifiedPie = slide.getShapes().addAutoShape(ShapeType.Pie, 445, 330, 130, 130);
    modifiedPie.setName("ModifiedPie");

    IGeometryShape[] shapesToAdjust = {
        modifiedRoundedRectangle,
        modifiedArrow,
        modifiedPie
    };

    for (IGeometryShape shape : shapesToAdjust) {
        for (int adjustmentIndex = 0; adjustmentIndex < shape.getAdjustments().size(); adjustmentIndex++) {
            IAdjustValue adjustment = shape.getAdjustments().get_Item(adjustmentIndex);
            System.out.println(shape.getName() + " / " + adjustment.getName() + ": " + adjustment.getType());

            switch (adjustment.getType()) {
                case ShapeAdjustmentType.CornerSize:
                    adjustment.setRawValue(5000);
                    break;
                case ShapeAdjustmentType.ArrowTailThickness:
                    adjustment.setRawValue(25000);
                    break;
                case ShapeAdjustmentType.ArrowheadLength:
                    adjustment.setRawValue(30000);
                    break;
                case ShapeAdjustmentType.ArrowheadWidth:
                    adjustment.setRawValue(40000);
                    break;
                case ShapeAdjustmentType.StartAngle:
                    adjustment.setAngleValue(30);
                    break;
                case ShapeAdjustmentType.EndAngle:
                    adjustment.setAngleValue(300);
                    break;
                case ShapeAdjustmentType.Custom:
                    System.out.println("Custom adjustment '" + adjustment.getName() + "' was not changed.");
                    break;
            }
        }
    }

    presentation.save("preset-shape-adjustments.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

값을 변경하기 전에 의미 유형을 확인하면 코드가 의도를 명확히 드러내며, 다른 사전 정의 모양에서 동일한 컬렉션 인덱스가 같은 의미를 갖는다고 가정하는 실수를 방지합니다.

## **모양 컬렉션 수정**

add, clone, remove 및 reorder 메서드는 컬렉션에 즉시 적용됩니다. 작업이 모양 수 또는 순서를 변경하면, 해당 작업 이전에 캡처한 인덱스에 의존하지 말아야 합니다.

### **모양 복제**

[addClone](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) 은 독립적인 복사본을 만들고 대상 컬렉션에 추가합니다. [insertClone](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) 도 복사본을 만들지만 지정된 z‑order 인덱스에 배치합니다. 좌표만 받는 오버로드는 크기를 변경하지 않고 복제하며, 너비와 높이를 받는 오버로드는 크기도 조절할 수 있습니다.

예제는 대상 슬라이드를 만든 뒤, 라벨이 붙은 사각형을 앞쪽에 복제하고 두 번째 복제본을 뒤쪽에 삽입합니다. 두 복제본 중 어느 하나를 수정해도 원본 모양은 변경되지 않습니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide sourceSlide = presentation.getSlides().get_Item(0);
    IAutoShape sourceShape = sourceSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 180, 60);
    sourceShape.setName("SourceLabel");
    sourceShape.getTextFrame().setText("Source");

    ILayoutSlide blankLayout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);
    ISlide destinationSlide = presentation.getSlides().addEmptySlide(blankLayout);

    IShape frontCloneShape = destinationSlide.getShapes().addClone(sourceShape, 80, 80);
    frontCloneShape.setName("FrontClone");
    if (frontCloneShape instanceof IAutoShape) {
        IAutoShape frontClone = (IAutoShape) frontCloneShape;
        frontClone.getTextFrame().setText("Front clone");
    } else {
        System.out.println("The front clone is not an AutoShape; its text was not changed.");
    }

    IShape backCloneShape = destinationSlide.getShapes().insertClone(0, sourceShape, 80, 180);
    backCloneShape.setName("BackClone");
    if (backCloneShape instanceof IAutoShape) {
        IAutoShape backClone = (IAutoShape) backCloneShape;
        backClone.getTextFrame().setText("Back clone");
    } else {
        System.out.println("The back clone is not an AutoShape; its text was not changed.");
    }

    presentation.save("cloned-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

복제는 모양의 내용과 서식(이름 및 대체 텍스트 포함)을 복사합니다. 해당 값들이 고유해야 한다면 복제본에 새로운 논리 식별자를 할당하십시오. 복잡한 모양이 사용하는 리소스는 프레젠테이션이 관리하지만, 복제본은 새로운 컬렉션 항목이며 새로운 모양 ID를 갖습니다.

### **모양 제거**

[remove](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) 은 특정 모양 객체를 컬렉션에서 삭제합니다. 인덱스 기반 반복 중 여러 개를 제거할 경우, 남은 인덱스가 유효하도록 역순으로 순회하십시오.

이 예제는 지정된 이름을 가진 모든 모양을 제거합니다. 고정된 컬렉션 항목이 아니라 현재 인덱스에 있는 모양을 읽으며, 불필요한 형변환을 하지 않습니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape keepShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 140, 60);
    keepShape.setName("Keep");

    IAutoShape firstTemporaryShape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 220, 40, 80, 80);
    firstTemporaryShape.setName("Temporary");

    IAutoShape secondTemporaryShape = slide.getShapes().addAutoShape(ShapeType.Triangle, 340, 40, 100, 80);
    secondTemporaryShape.setName("Temporary");

    for (int i = slide.getShapes().size() - 1; i >= 0; i--) {
        IShape shape = slide.getShapes().get_Item(i);
        if ("Temporary".equals(shape.getName())) {
            slide.getShapes().remove(shape);
        }
    }

    presentation.save("removed-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

제거 후에는 모양 개수와 이후 모양들의 인덱스가 변합니다. 영향을 받지 않은 모양에 대한 참조는 저장된 인덱스보다 더 신뢰할 수 있습니다. 또한 커넥터, 애니메이션 등 제거된 객체를 참조할 수 있는 프레젠테이션 기능도 고려하십시오. 보이는 모양을 제거하면 슬라이드 외관뿐만 아니라 다른 요소에도 영향을 줄 수 있습니다.

### **모양 숨기기**

[Hidden](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/#setHidden-boolean-) 을 `true` 로 설정하면 모양은 컬렉션에 남아 있지만 일반 슬라이드 쇼에서는 표시되지 않습니다. 인덱스, 서식, 내용은 코드를 통해 그대로 접근 가능하므로, 나중에 다시 복원될 수 있는 선택적 요소에 적합합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape visibleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 160, 60);
    visibleShape.setName("VisibleLabel");

    IAutoShape optionalShape = slide.getShapes().addAutoShape(ShapeType.Moon, 240, 40, 100, 100);
    optionalShape.setName("OptionalDecoration");

    for (IShape shape : slide.getShapes()) {
        if ("OptionalDecoration".equals(shape.getName())) {
            shape.setHidden(true);
        }
    }

    presentation.save("hidden-shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

숨기기는 삭제나 보안이 아닙니다. 사용자가 또는 코드가 이를 발견하고 다시 표시할 수 있으며, 파일 내에 계속 존재합니다.

### **Z-Order 변경**

겹치는 모양은 컬렉션 순서대로 그려집니다. [reorder](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) 은 복제하지 않고 기존 모양을 목표 인덱스로 이동합니다. 인덱스 `0` 은 뒤쪽, `size() - 1` 은 앞쪽을 의미합니다.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape blueRectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 220, 120);
    blueRectangle.setName("BlueRectangle");
    blueRectangle.getFillFormat().setFillType(FillType.Solid);
    blueRectangle.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    IAutoShape orangeEllipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 180, 140, 220, 120);
    orangeEllipse.setName("OrangeEllipse");
    orangeEllipse.getFillFormat().setFillType(FillType.Solid);
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

예제에서는 사각형을 먼저 만들고 처음에는 타원 뒤에 배치됩니다. 이를 최종 인덱스로 이동하면 앞쪽에 놓이게 됩니다. 모든 관련 모양을 추가하거나 복제한 뒤에 Z‑order 를 최종 조정하십시오. 이러한 작업은 새 컬렉션 항목을 추가하거나 삽입하여 기존 스택을 바꿀 수 있기 때문입니다.

## **레이아웃 슬라이드의 모양 검사**

일반 슬라이드, 레이아웃 슬라이드 및 마스터 슬라이드는 각각 별도의 모양 컬렉션을 갖습니다. 레이아웃 컬렉션의 모양은 일반 슬라이드에 동일한 위치에 있더라도 같은 객체가 아닙니다. 레이아웃이 제공하는 서식을 이해하거나 변경해야 할 때 레이아웃 모양을 검사하십시오.

다음 예제는 각 레이아웃 모양의 [FillFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/#getFillFormat--) 및 [LineFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/#getLineFormat--) 을 읽으며, 모든 모양이 `AutoShape` 인 것으로 가정하지 않습니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ILayoutSlide layoutSlide : presentation.getLayoutSlides()) {
        for (IShape shape : layoutSlide.getShapes()) {
            int fillType = shape.getFillFormat().getFillType();
            double lineWidth = shape.getLineFormat().getWidth();
            System.out.println(layoutSlide.getName() + " / " + shape.getName() + ": fill=" + fillType + ", line width=" + lineWidth);
        }
    }
} finally {
    presentation.dispose();
}
```

레이아웃을 편집하면 해당 레이아웃을 사용하는 여러 슬라이드에 영향을 미칩니다. 레이아웃 모양을 변경하기 전에 일반 슬라이드가 해당 객체를 상속받는지 로컬 오버라이드가 있는지 판단하고, 레이아웃을 사용하는 모든 슬라이드를 테스트하십시오.

## **모양을 SVG로 내보내기**

[writeAsSvg](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) 은 하나의 모양이 렌더링된 내용을 스트림에 기록합니다. 결과에는 해당 모양만 포함되며 슬라이드 배경이나 인접 모양은 포함되지 않습니다.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() == 0) {
        System.out.println("Slide 1 does not contain a shape to export.");
    } else {
        IShape shape = slide.getShapes().get_Item(0);
        try (FileOutputStream svgStream = new FileOutputStream("shape.svg")) {
            shape.writeAsSvg(svgStream);
        } catch (IOException exception) {
            System.out.println("The SVG file could not be written: " + exception.getMessage());
        }
    }
} finally {
    presentation.dispose();
}
```

렌더링 중에는 프레젠테이션을 열어 둬야 합니다. 출력은 모양의 서식과 폰트, 이미지와 같은 리소스에 따라 달라집니다. 전체 구성을 원한다면 개별 모양이 아니라 슬라이드를 내보내십시오. 호출자는 스트림을 소유하며 반드시 닫아야 합니다.

## **모양 정렬**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/ko/java/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) 은 모든 모양 또는 선택된 컬렉션 인덱스를 정렬합니다. [ShapesAlignmentType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/shapesalignmenttype/) 은 가장자리, 중앙선 또는 배분 모드를 지정합니다. `alignToSlide` 를 `true` 로 설정하면 슬라이드 가장자리를 기준으로, `false` 로 설정하면 선택된 모양들 간의 상대 정렬을 수행합니다.

예제는 세 모양을 슬라이드 상단 가장자리에 정렬합니다. 반환된 모양 참조는 정렬 직전에 현재 인덱스로 변환됩니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape firstShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 60, 80, 120, 50);
    IAutoShape secondShape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 240, 160, 120, 50);
    IAutoShape thirdShape = slide.getShapes().addAutoShape(ShapeType.Triangle, 420, 240, 120, 50);
    firstShape.setName("FirstAlignedShape");
    secondShape.setName("SecondAlignedShape");
    thirdShape.setName("ThirdAlignedShape");

    int[] shapeIndexes = {slide.getShapes().indexOf(firstShape), slide.getShapes().indexOf(secondShape), slide.getShapes().indexOf(thirdShape)};

    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
    presentation.save("aligned-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

정렬은 위치를 변경하지만 Z‑order 를 바꾸지는 않습니다. 상대 정렬은 최소 두 개의 모양이 필요하고, 수평 또는 수직 배분은 충분한 모양이 있어야 간격을 정의할 수 있습니다. 메서드 호출 전 컬렉션을 수정했다면 인덱스를 다시 계산하십시오.

## **모양 뒤틀기**

[ShapeFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/shapeframe/) 클래스는 위치, 크기, 수평·수직 뒤틀기 설정 및 회전을 저장합니다. `getFlipH` 와 `getFlipV` 값은 [NullableBool](https://reference.aspose.com/slides/ko/java/com.aspose.slides/nullablebool/) 을 사용하며, `True` 는 뒤틀기를 활성화하고, `False` 는 비활성화, `NotDefined` 는 지정되지 않음/기본 상태를 유지합니다.

아래 입력 프레젠테이션에는 뒤틀기되지 않은 모양이 하나 포함되어 있습니다.

![뒤집기 전 모양](shape_to_be_flipped.png)

예제는 다른 모든 프레임 값을 유지하고 두 뒤틀기 설정만 교체합니다. 이는 새로운 [Frame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) 을 할당하면 전체 프레임이 교체되기 때문에 중요합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IShapeFrame frame = shape.getFrame();

    System.out.println("Horizontal flip before change: " + frame.getFlipH());
    System.out.println("Vertical flip before change: " + frame.getFlipV());

    shape.setFrame(new ShapeFrame(frame.getX(), frame.getY(), frame.getWidth(), frame.getHeight(), NullableBool.True, NullableBool.True, frame.getRotation()));

    presentation.save("flipped-shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

저장된 모양은 위치, 크기 및 회전을 유지한 채 수평·수직으로 미러링됩니다.

![뒤집기 후 모양](flipped_shape.png)

## **FAQ**

**컬렉션 인덱스를 모양 식별자로 사용해야 하나요?**

짧은 기간 동안 컬렉션이 변하지 않을 경우에만 사용하십시오. 작성된 템플릿이라면 검증된 `Name` 또는 `AlternativeText` 규칙을, 슬라이드 범위 인터옵 작업이라면 `OfficeInteropShapeId` 를 사용하는 것이 좋습니다.

**모양을 숨기면 Z-Order에서 제거되나요?**

아니요. 숨긴 모양은 같은 인덱스에 그대로 남으며, 찾거나 순서를 바꾸고, 편집하거나 다시 표시할 수 있습니다.

**복제된 모양이 다른 모양 앞에 나타난 이유는 무엇인가요?**

`addClone` 은 복제본을 컬렉션 끝에 추가하므로 Z‑order 의 앞쪽에 위치합니다. 초기 인덱스를 지정하려면 `insertClone` 을 사용하거나 모든 모양을 추가한 뒤 `reorder` 로 조정하십시오.

**고정 인덱스를 사용하여 사전 정의된 모양 조정을 식별할 수 있나요?**

정확한 사전 정의와 컬렉션 레이아웃을 검증한 경우에만 가능합니다. 일반적으로는 `IGeometryShape.getAdjustments` 를 반복하면서 `IAdjustValue.getType` 을 확인하고, 동일 의미 유형이 여러 번 나타날 경우 `IAdjustValue.getName` 을 추가 정보로 활용하십시오.