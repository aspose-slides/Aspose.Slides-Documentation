---
title: Android에서 프레젠테이션 도형 관리
linktitle: 도형 조작
type: docs
weight: 40
url: /ko/androidjava/shape-manipulations/
keywords:
- PowerPoint 도형
- 프레젠테이션 도형
- 슬라이드의 도형
- 도형 찾기
- 도형 복제
- 도형 삭제
- 도형 숨기기
- 도형 순서 변경
- Interop 도형 ID 가져오기
- 도형 대체 텍스트
- 도형 조정 포인트
- 미리 정의된 도형 조정
- 도형 기하
- 도형 레이아웃 형식
- SVG 형식 도형
- 도형을 SVG로 변환
- 도형 정렬
- 도형 뒤집기
- PowerPoint
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java를 사용하여 프레젠테이션 도형을 식별하고, 조정하고, 복제하고, 삭제하고, 숨기고, 순서를 변경하고, 내보내고, 정렬하고, 뒤집는 방법을 배웁니다."
---
## **개요**

Aspose.Slides for Android via Java는 슬라이드의 도형을 순서가 지정된 [IShapeCollection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishapecollection/)으로 나타냅니다. 컬렉션은 도형을 찾고 수정하는 장소이자 도형의 쌓임 순서의 원천이며, 인덱스 `0`은 가장 뒤에 있는 도형이고 마지막 인덱스는 가장 앞에 있는 도형입니다.

이 문서는 해당 모델을 따릅니다. 먼저 도형을 신뢰할 수 있게 식별하고 미리 정의된 도형 조정점을 수정하는 방법을 설명하고, 이어서 도형을 복제, 삭제, 숨기기 및 순서를 변경하는 방법을 보여줍니다. 마지막 섹션에서는 레이아웃 수준 서식, SVG 내보내기, 정렬 및 뒤집기 설정을 다룹니다. 각 예제는 독립적이므로 워크플로에 필요한 작업만 사용할 수 있습니다.

## **도형 식별 및 찾기**

컬렉션 인덱스는 알려진 파일을 처리할 때 편리하지만 안정적인 식별자는 아닙니다. 도형을 추가·삭제·재정렬하면 인덱스가 변경될 수 있습니다. 프레젠테이션이 작성·관리되는 방식에 따라 식별자를 선택하십시오.

- [Name](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishape/#getName--)은 개발자가 제어하는 템플릿에 유용하며 PowerPoint 선택 창에서 쉽게 확인할 수 있습니다. 이름은 편집 가능하고 고유성을 보장하지 않으므로 코드가 이름에 의존한다면 명명 규칙을 정하십시오.
- [AlternativeText](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishape/#getAlternativeText--)는 접근성 설명이나 작성자가 지정한 태그가 이미 도형을 식별할 때 유용합니다. 사용자는 이 텍스트를 볼 수 있으며 현지화되거나 접근성을 위해 재작성될 수 있지만 고유성을 보장하지 않습니다. 의미 있는 접근성 텍스트를 데이터베이스 키로 무심코 재사용하지 마십시오.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--)은 읽기 전용 식별자로 슬라이드 내에서 고유하며 PowerPoint 상호 운용에서 사용하는 도형 ID와 일치합니다. PowerPoint와 통합하거나 도형 수명 동안 명확한 참조가 필요할 때 사용하십시오. 복제되거나 다시 생성된 도형은 다른 도형이며 자체 ID를 갖습니다.

관련 [getUniqueId](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishape/#getUniqueId--) 메서드는 프레젠테이션 범위의 식별자를 반환하지만, 이는 애드인용으로 설계되었으며 재할당될 수 있습니다. 영구적인 외부 키로 간주해서는 안 됩니다. 장기간 신원 확인이 필수라면 애플리케이션 데이터에 매핑을 보관하고 예상 도형이 여전히 존재하는지 검증하십시오.

다음 예제는 정확한 비교를 사용해 이름으로 검색하고 슬라이드 범위의 interop ID를 보고합니다. 템플릿에 예상 도형이 없을 경우 코드는 잘못된 객체로 진행하지 않고 해당 결과를 보고합니다.

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

작업이 특정 도형 유형에만 적용되는 경우 인터페이스를 확인한 후 유형별 멤버를 사용하십시오. 이 예제는 명명된 객체가 [IAutoShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iautoshape/)인 경우에만 텍스트와 대체 텍스트를 업데이트합니다.

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

## **미리 정의된 도형 조정식 식별 및 수정**

미리 정의된 기하 도형은 모서리 크기, 화살표 비율, 호 각도와 같은 특징을 제어하는 조정점을 노출할 수 있습니다. 읽기 전용 [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/igeometryshape/#getAdjustments--) 컬렉션을 통해 접근하십시오. 컬렉션 자체는 도형에 의해 제공되지만 각 [IAdjustValue](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iadjustvalue/)는 변경 가능한 값을 포함합니다.

고정된 컬렉션 인덱스에만 의존하지 마십시오. 조정들을 반복하면서 읽기 전용 [getType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iadjustvalue/#getType--) 메서드를 검사하십시오. 이 메서드의 [ShapeAdjustmentType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/shapeadjustmenttype/) 값은 조정이 제어하는 내용을 설명합니다. 읽기 전용 [getName](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iadjustvalue/#getName--) 메서드는 추가 식별 정보를 제공하며, 동일한 의미 유형의 조정이 여러 개 포함된 경우 특히 유용합니다.

조정 의미에 맞는 값 메서드를 사용하십시오:

| 조정 유형 | 목적 | 변경할 값 |
|---|---|---|
| `CornerSize` | 둥근 모서리의 크기 | [setRawValue](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iadjustvalue/#setRawValue-long-) |
| `ArrowTailThickness` | 화살표 꼬리 두께 | `setRawValue` |
| `ArrowheadLength` | 화살표 머리 길이 | `setRawValue` |
| `ArrowheadWidth` | 화살표 머리 너비 | `setRawValue` |
| `StartAngle` | 파이 또는 호의 시작 각도 | [setAngleValue](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iadjustvalue/#setAngleValue-float-) |
| `EndAngle` | 파이 또는 호의 끝 각도 | `setAngleValue` |

`getType` 및 `getName`은 읽기 전용 정보를 반환합니다. `getRawValue`와 `setRawValue`는 프리셋 고유 기하 단위의 정수와 작업하고, `getAngleValue`와 `setAngleValue`는 각도를 도(degree) 단위로 작업합니다. 조정의 개수, 순서, 의미 및 유효 범위는 프리셋 [ShapeType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/igeometryshape/#getShapeType--)에 따라 다릅니다. 한 프리셋에 유효한 값이 다른 프리셋에서는 무효이거나 다른 효과를 가질 수 있습니다.

`getType`이 `ShapeAdjustmentType.Custom`을 반환하면 API가 표준 의미를 인식하지 못합니다. `getName`, 프리셋 유형 및 기존 값을 조사하고, 예상 의미와 범위가 명확하지 않다면 조정을 변경하지 마십시오. 인식된 유형이라도 동일한 유형이 여러 번 나타나는지 확인한 후 값을 선택하십시오. [Connector](/slides/ko/androidjava/connector/) 문서에서 커넥터 굽힘 조정 상황을 확인할 수 있습니다.

다음 완전한 예제는 세 가지 프리셋 도형의 기본 및 수정 버전을 생성합니다. 모든 조정을 반복하면서 이름과 유형을 보고, `setRawValue`로 크기 관련 값을 변경하고, `setAngleValue`로 각도를 변경한 뒤 결과를 저장합니다. 왼쪽 열은 기본 기하를 유지하고, 오른쪽 열은 조정된 둥근 사각형, 4방향 화살표 및 파이를 보여줍니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 기본 및 조정된 도형 열에 대한 헤더를 추가합니다.
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

값을 변경하기 전에 의미 유형을 확인하면 코드가 의도를 명확히 표시하고 서로 다른 프리셋 도형 간에 동일한 컬렉션 인덱스가 같은 의미를 가진다고 가정하는 실수를 방지합니다.

## **도형 컬렉션 수정**

추가, 복제, 삭제 및 재정렬 메서드는 컬렉션에 즉시 적용됩니다. 작업이 도형 수 또는 순서를 변경하면, 해당 작업 전후에 캡처한 인덱스에 의존하지 말고 최신 인덱스를 사용하십시오.

### **도형 복제**

[addClone](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-)은 독립적인 복사본을 만들고 대상 컬렉션에 추가합니다. [insertClone](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-)도 복사본을 만들지만 지정된 z-순서 인덱스에 배치합니다. 좌표를 받는 오버로드는 크기를 변경하지 않고 복제본을 이동시키며, 너비와 높이를 받는 오버로드는 크기도 조정할 수 있습니다.

예제는 대상 슬라이드를 만든 뒤, 라벨이 붙은 사각형을 앞쪽으로 복제하고 두 번째 복제본을 뒤쪽에 삽입합니다. 두 복제본 중 어느 하나를 변경해도 원본 도형은 영향을 받지 않습니다.

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

복제는 도형의 내용과 서식(이름 및 대체 텍스트 포함)을 복사합니다. 해당 값이 고유해야 한다면 복제본에 새로운 논리 식별자를 할당하십시오. 복잡한 도형이 사용하는 리소스는 프레젠테이션에서 관리되지만, 복제본은 새로운 컬렉션 항목이자 새로운 도형 ID를 갖습니다.

### **도형 삭제**

[remove](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-)은 특정 도형 객체를 컬렉션에서 삭제합니다. 인덱스를 사용한 순회 중 다수의 일치를 삭제할 경우, 남은 인덱스가 유효하도록 끝에서부터 순회하십시오.

이 예제는 지정된 이름을 가진 모든 도형을 삭제합니다. 고정된 컬렉션 항목이 아니라 현재 인덱스의 도형을 읽으며, 불필요한 형변환을 하지 않습니다.

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

삭제 후에는 도형 개수와 이후 도형들의 인덱스가 변합니다. 영향을 받지 않은 도형에 대한 참조는 저장된 인덱스보다 더 신뢰할 수 있습니다. 또한 커넥터, 애니메이션 등 삭제된 객체를 참조할 수 있는 프레젠테이션 요소를 고려하십시오; 보이는 도형을 삭제하면 슬라이드 외관 이상을 변경할 수 있습니다.

### **도형 숨기기**

[Hidden](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishape/#setHidden-boolean-)을 `true`로 설정하면 도형이 컬렉션에 남아 있지만 일반 슬라이드 쇼에 표시되지 않습니다. 인덱스, 서식 및 내용은 코드에서 계속 사용할 수 있으므로 나중에 복원될 수 있는 선택적 요소에 적합합니다.

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

숨기기는 삭제나 보안이 아닙니다. 사용자는 물론 코드도 여전히 도형을 발견하고 다시 표시할 수 있으며, 파일 내에 그대로 존재합니다.

### **Z-순서 변경**

겹치는 도형은 컬렉션 순서대로 그려집니다. [reorder](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-)는 복제 없이 기존 도형을 목표 인덱스로 이동시킵니다. 인덱스 `0`은 뒤쪽, `size() - 1`은 앞쪽을 의미합니다.

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
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

사각형을 먼저 만들면 처음에 타원 뒤에 놓입니다. 최종 인덱스로 이동하면 앞쪽에 배치됩니다. 모든 관련 도형을 추가·복제한 후에 z-순서를 최종 조정하십시오. 이러한 작업은 새 컬렉션 항목을 추가하거나 삽입하면서 스택을 변경할 수 있기 때문입니다.

## **레이아웃 슬라이드의 도형 검사**

일반 슬라이드, 레이아웃 슬라이드 및 마스터 슬라이드는 각각 별도의 도형 컬렉션을 가집니다. 레이아웃 컬렉션의 도형은 동일한 위치에 있는 일반 슬라이드의 도형과 동일 객체가 아닙니다. 레이아웃이 제공하는 서식을 이해하거나 변경해야 할 때 레이아웃 도형을 검사하십시오.

다음 예제는 각 레이아웃 도형의 [FillFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishape/#getFillFormat--) 및 [LineFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishape/#getLineFormat--)을 읽으며, 모든 도형이 `AutoShape`이라고 가정하지 않습니다.

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

레이아웃을 편집하면 해당 레이아웃을 사용하는 여러 슬라이드에 영향을 줄 수 있습니다. 레이아웃 도형을 변경하기 전에 일반 슬라이드가 객체를 상속하는지, 로컬 오버라이드가 있는지 판단하고, 해당 레이아웃을 사용하는 모든 슬라이드를 테스트하십시오.

## **도형을 SVG로 내보내기**

[writeAsSvg](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-)는 하나의 도형이 렌더링된 내용을 스트림에 기록합니다. 결과에는 도형만 포함되며 전체 슬라이드 배경이나 주변 도형은 포함되지 않습니다.

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

렌더링 중에는 프레젠테이션을 열어 두십시오. 출력은 도형의 서식과 글꼴·이미지와 같은 리소스에 따라 달라집니다. 전체 구성이 필요하면 개별 도형이 아니라 슬라이드를 내보내십시오. 호출자는 스트림을 소유하며 반드시 닫아야 합니다.

## **도형 정렬**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) 오버로드는 모든 도형 또는 선택된 컬렉션 인덱스를 정렬합니다. [ShapesAlignmentType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/shapesalignmenttype/)은 가장자리, 중앙선 또는 배치 방식을 지정합니다. `alignToSlide`을 `true`로 설정하면 슬라이드 가장자리를 기준으로, `false`로 설정하면 선택된 도형들 간의 상대 정렬을 사용합니다.

이 예제는 세 도형을 슬라이드 상단 가장자리에 정렬합니다. 반환된 도형 참조는 정렬 직전에 현재 인덱스로 변환됩니다.

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

정렬은 위치만 변경하고 z-순서는 바꾸지 않습니다. 상대 정렬은 일반적으로 두 개 이상의 도형이 필요하고, 가로나 세로 배치는 충분한 도형이 있어야 간격을 정의할 수 있습니다. 메서드 호출 전에 컬렉션을 수정했다면 인덱스를 다시 계산하십시오.

## **도형 뒤집기**

[ShapeFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/shapeframe/) 클래스는 위치, 크기, 수평·수직 뒤집기 설정 및 회전을 저장합니다. `getFlipH`와 `getFlipV` 값은 [NullableBool](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/nullablebool/)을 사용합니다: `True`는 뒤집기를 활성화하고, `False`는 비활성화하며, `NotDefined`는 지정되지 않거나 기본 상태를 유지합니다.

아래 입력 프레젠테이션에는 뒤집히지 않은 도형 하나가 포함되어 있습니다.

![The shape before flipping](shape_to_be_flipped.png)

예제는 기타 프레임 값을 그대로 두고 두 뒤집기 설정만 교체합니다. 새로운 [Frame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-)을 지정하면 전체 프레임이 교체되므로 주의가 필요합니다.

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

저장된 도형은 위치·크기·회전을 유지한 채 수평·수직으로 각각 거울 반사됩니다.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**컬렉션 인덱스를 도형 식별자로 사용해도 될까요?**

컬렉션이 인덱스 사용 전에 변경되지 않을 짧은 기간의 처리에만 사용하십시오. 작성된 템플릿에는 검증된 `Name` 또는 `AlternativeText` 규칙을, 슬라이드 범위의 interop 작업에는 `OfficeInteropShapeId`를 우선하십시오.

**도형을 숨기면 z-순서에서 제거되나요?**

아니요. 숨긴 도형은 동일 인덱스에 그대로 남으며, 찾기·재정렬·편집·다시 표시가 가능합니다.

**복제된 도형이 다른 도형 앞에 나타난 이유는?**

`addClone`은 복제본을 컬렉션 끝에 추가하므로 z-순서의 앞쪽에 배치됩니다. 초기 인덱스를 지정하려면 `insertClone`을 사용하거나 모든 도형을 추가한 뒤 `reorder`로 조정하십시오.

**고정 인덱스로 미리 정의된 도형 조정을 식별해도 될까요?**

정확한 프리셋과 컬렉션 레이아웃을 검증한 경우에만 가능합니다. `IGeometryShape.getAdjustments`를 반복하면서 `IAdjustValue.getType`을 확인하고, 동일 의미 유형이 여러 번 나타날 때는 `IAdjustValue.getName`을 추가 정보로 활용하십시오.