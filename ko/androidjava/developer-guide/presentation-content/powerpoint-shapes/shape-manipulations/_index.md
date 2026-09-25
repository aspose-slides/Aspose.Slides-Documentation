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
- interop 도형 ID 가져오기
- 도형 대체 텍스트
- 도형 조정 포인트
- 프리셋 도형 조정
- 도형 기하학
- 도형 레이아웃 서식
- SVG 형식 도형
- 도형을 SVG로
- 도형 정렬
- 도형 플립
- PowerPoint
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java를 사용하여 프레젠테이션 도형을 식별, 조정, 복제, 삭제, 숨기기, 순서 변경, 내보내기, 정렬 및 플립하는 방법을 배웁니다."
---
## **개요**

Aspose.Slides for Android via Java은 슬라이드의 도형을 정렬된 [IShapeCollection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishapecollection/)으로 나타냅니다. 이 컬렉션은 도형을 찾고 수정하는 위치이자, 도형의 겹침 순서의 원천입니다: 인덱스 `0`은 가장 뒤에 있는 도형이며, 마지막 인덱스는 가장 앞에 있는 도형입니다.

이 문서는 해당 모델을 따릅니다. 먼저 도형을 안정적으로 식별하고 미리 정의된 도형 조정 포인트를 수정하는 방법을 설명하고, 이어서 도형을 복제, 삭제, 숨기기 및 순서 변경하는 방법을 보여줍니다. 마지막 섹션에서는 레이아웃 수준 서식, SVG 내보내기, 정렬 및 플립 설정을 다룹니다. 각 예제는 독립적이므로 워크플로에 필요한 작업만 사용할 수 있습니다.

## **도형 식별 및 찾기**

컬렉션 인덱스는 알려진 파일을 처리할 때 편리하지만 안정적인 식별자는 아닙니다. 도형을 추가, 삭제 또는 순서를 변경하면 인덱스가 바뀔 수 있습니다. 프레젠테이션이 어떻게 작성·관리되는지에 따라 식별자를 선택하세요.

- [Name](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishape/#getName--)은 개발자가 제어하는 템플릿에 유용하고 PowerPoint 선택 창에서 쉽게 확인할 수 있습니다. 이름은 편집 가능하지만 고유성을 보장하지 않으므로 코드가 이름에 의존한다면 명명 규칙을 정하십시오.
- [AlternativeText](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishape/#getAlternativeText--)는 접근성 설명이나 작성자가 제공한 태그가 이미 도형을 식별할 때 유용합니다. 사용자에게 표시되며 현지화되거나 접근성을 위해 재작성될 수 있지만 고유성을 보장하지 않습니다. 의미 있는 접근성 텍스트를 데이터베이스 키로 조용히 재사용하지 마십시오.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--)은 읽기 전용 식별자로, 슬라이드 내에서 고유하며 PowerPoint 인터옵에서 사용되는 도형 ID와 일치합니다. PowerPoint와 통합하거나 도형 수명 동안 명확한 참조가 필요할 때 사용하십시오. 복제되거나 재생성된 도형은 다른 도형이며 자체 ID를 받습니다.

관련 [getUniqueId](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishape/#getUniqueId--) 메서드는 프레젠테이션 범위의 식별자를 반환하지만, 해당 식별자는 애드인용으로 재할당될 수 있으므로 영구적인 외부 키로 취급하지 말아야 합니다. 장기적인 정체성이 필수라면 애플리케이션 데이터에 매핑을 보관하고 기대하는 도형이 여전히 존재하는지 검증하십시오.

대체 텍스트 제목과 설명을 읽고 업데이트하는 실제 예제는 [Manage Alternative Text Titles and Descriptions](/slides/ko/androidjava/presentation-accessibility/)를 참고하십시오. 대체 텍스트는 시각 요소의 의미를 독자에게 설명하기 위해 사용하고, 코드가 도형을 찾는 데 사용하는 이름과는 별도로 관리하십시오.

다음 예제는 정확히 일치하는 이름으로 검색하고 슬라이드 범위의 인터옵 ID를 보고합니다. 템플릿에 기대하는 도형이 없을 경우, 코드가 잘못된 객체를 계속 사용하지 않고 해당 결과를 보고합니다.

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

작업이 특정 도형 유형에만 해당되는 경우, 형식별 멤버를 사용하기 전에 인터페이스를 확인하십시오. 이 예제는 명명된 객체가 [IAutoShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iautoshape/)인지 확인한 뒤 텍스트와 대체 텍스트를 업데이트합니다.

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

## **미리 정의된 도형 조정 변경하기**

미리 정의된 기하학 도형은 모서리 크기, 화살표 비율 또는 호 각도와 같은 기능을 제어하는 조정 포인트를 노출할 수 있습니다. 읽기 전용 [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/igeometryshape/#getAdjustments--) 컬렉션을 통해 접근하십시오. 컬렉션 자체는 도형이 제공하지만, 각 [IAdjustValue](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iadjustvalue/)는 변경 가능한 값을 포함합니다.

고정된 컬렉션 인덱스에만 의존하지 마십시오. 조정을 반복하면서 읽기 전용 [getType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iadjustvalue/#getType--) 메서드를 검사하십시오. 이 메서드의 [ShapeAdjustmentType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/shapeadjustmenttype/) 값은 조정이 제어하는 항목을 설명합니다. 읽기 전용 [getName](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iadjustvalue/#getName--) 메서드는 추가 식별 정보를 제공하며, 동일한 의미 유형을 가진 조정이 여러 개 있는 경우 특히 유용합니다.

조정 의미에 맞는 값 메서드를 사용하십시오:

| 조정 유형 | 목적 | 변경할 값 |
|---|---|---|
| `CornerSize` | 둥근 모서리 크기 | [setRawValue](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iadjustvalue/#setRawValue-long-) |
| `ArrowTailThickness` | 화살표 꼬리 두께 | `setRawValue` |
| `ArrowheadLength` | 화살표 머리 길이 | `setRawValue` |
| `ArrowheadWidth` | 화살표 머리 너비 | `setRawValue` |
| `StartAngle` | 파이 또는 호의 시작 각도 | [setAngleValue](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iadjustvalue/#setAngleValue-float-) |
| `EndAngle` | 파이 또는 호의 끝 각도 | `setAngleValue` |

`getType`과 `getName`은 읽기 전용 정보를 반환합니다. `getRawValue`와 `setRawValue`는 미리 정의된 도형의 기본 기하학 단위에서 정수를 사용하고, `getAngleValue`와 `setAngleValue`는 각도를 도 단위로 사용합니다. 조정의 개수, 순서, 의미 및 유효 범위는 미리 정의된 [ShapeType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/igeometryshape/#getShapeType--)에 따라 달라집니다. 한 프리셋에 유효한 값이 다른 프리셋에서는 무효이거나 다른 효과를 낼 수 있습니다.

`getType`이 `ShapeAdjustmentType.Custom`을 반환하면 API가 표준 의미를 인식하지 못합니다. `getName`, 프리셋 유형 및 기존 값을 검토하고, 기대하는 의미와 범위를 알지 못한다면 조정을 변경하지 마십시오. 인식된 유형이라도 동일한 유형이 여러 번 나타나는지 확인한 후 값을 선택하십시오. [Connector](/slides/ko/androidjava/connector/) 문서에서는 커넥터 굽힘 조정 상황을 보여줍니다.

다음 완전한 예제는 세 가지 프리셋 도형의 기본 및 수정 버전을 생성합니다. 모든 조정을 반복하면서 이름과 유형을 보고, `setRawValue`로 크기 관련 값을, `setAngleValue`로 각도를 변경하고 결과를 저장합니다. 왼쪽 열은 기본 기하학을 유지하고, 오른쪽 열은 조정된 둥근 사각형, 사방향 화살표 및 파이를 보여줍니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 기본 및 조정된 도형 열에 헤더를 추가합니다.
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

값을 변경하기 전에 의미 유형을 확인하면 코드가 의도를 명확히 나타내고 서로 다른 프리셋 도형 간에 동일한 컬렉션 인덱스가 같은 의미를 가진다고 가정하는 오류를 방지합니다.

## **도형 컬렉션 수정하기**

추가, 복제, 삭제 및 순서 변경 메서드는 컬렉션에 즉시 적용됩니다. 작업이 도형 수나 순서를 바꾸면, 해당 작업 이전에 캡처한 인덱스에 계속 의존하지 마십시오.

### **도형 복제**

[addClone](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-)는 독립적인 복사본을 생성하고 대상 컬렉션에 추가합니다. [insertClone](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-)도 복사본을 만들지만 지정된 z‑order 인덱스에 삽입합니다. 좌표를 받아들이는 오버로드는 크기를 변경하지 않고 복제본을 이동하고, 폭·높이를 받아들이는 오버로드는 크기도 조정합니다.

예제는 대상 슬라이드를 만들고 라벨이 붙은 사각형을 앞쪽에 복제한 뒤, 두 번째 복제본을 뒤쪽에 삽입합니다. 어느 복제본을 수정해도 원본 도형에는 영향을 주지 않습니다.

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

복제는 도형의 내용과 서식을 복사하며 이름과 대체 텍스트도 포함합니다. 해당 값들이 고유해야 한다면 복제본에 새로운 논리 식별자를 부여하십시오. 복잡한 도형이 사용하는 리소스는 프레젠테이션이 관리하지만, 복제본은 새로운 컬렉션 항목이자 새로운 도형 아이덴티티를 가집니다.

### **도형 삭제**

[remove](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-)은 특정 도형 객체를 컬렉션에서 삭제합니다. 인덱스를 이용한 반복 중에 여러 개를 삭제해야 할 경우, 남은 인덱스가 유효하도록 끝부터 역순으로 탐색하십시오.

이 예제는 지정된 이름을 가진 모든 도형을 삭제합니다. 고정된 컬렉션 항목이 아니라 현재 인덱스의 도형을 읽으며, 불필요한 형변환도 하지 않습니다.

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

삭제 후에는 도형 수와 이후 도형들의 인덱스가 변경됩니다. 영향을 받지 않은 도형에 대한 참조는 저장된 인덱스보다 더 신뢰할 수 있습니다. 또한 커넥터, 애니메이션 및 프레젠테이션의 다른 기능이 삭제된 객체를 참조할 수 있으니, 보이는 도형을 삭제하면 슬라이드 외관 이상의 변화가 발생할 수 있음을 고려하십시오.

### **도형 숨기기**

[Hidden](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishape/#setHidden-boolean-)을 `true`로 설정하면 도형은 컬렉션에 남아 있지만 일반 슬라이드 쇼에서는 표시되지 않습니다. 인덱스·서식·내용은 코드에서 여전히 사용할 수 있으므로, 나중에 복구할 수 있는 선택적 요소에 적합합니다.

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

숨기기는 삭제나 보안이 아닙니다. 사용자는 물론 코드에서도 해당 객체를 찾아 다시 표시할 수 있으며, 파일 내에도 여전히 존재합니다.

### **Z‑Order 변경**

겹치는 도형은 컬렉션 순서대로 그려집니다. [reorder](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-)는 도형을 복제하지 않고 대상 인덱스로 이동합니다. 인덱스 `0`은 뒤쪽, `size() - 1`은 앞쪽을 의미합니다.

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

먼저 사각형을 만들면 타원 뒤에 배치됩니다. 최종 인덱스로 이동시키면 앞쪽에 표시됩니다. 모든 관련 도형을 추가·복제한 후에 Z‑order를 최종 확정하십시오. 이러한 작업은 컬렉션에 새 항목을 추가하거나 삽입해 스택 구조를 바꿀 수 있기 때문입니다.

## **레이아웃 슬라이드의 도형 검사하기**

일반 슬라이드, 레이아웃 슬라이드, 마스터 슬라이드는 각각 별도의 도형 컬렉션을 가집니다. 레이아웃 컬렉션에 있는 도형은 일반 슬라이드에 동일한 위치에 있더라도 같은 객체가 아닙니다. 레이아웃에서 제공하는 서식을 이해하거나 변경해야 할 때 레이아웃 도형을 검사하십시오.

다음 예제는 각 레이아웃 도형의 [FillFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishape/#getFillFormat--)과 [LineFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishape/#getLineFormat--)을 읽으며, 모든 도형이 `AutoShape`이라고 가정하지 않습니다.

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

레이아웃을 편집하면 해당 레이아웃을 사용하는 여러 슬라이드에 영향을 미칩니다. 레이아웃 도형을 변경하기 전에 일반 슬라이드가 객체를 상속하는지, 로컬 오버라이드가 있는지 판단하고, 해당 레이아웃을 사용하는 모든 슬라이드를 테스트하십시오.

## **도형을 SVG로 내보내기**

[writeAsSvg](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-)는 하나의 도형이 렌더링된 내용을 스트림에 기록합니다. 결과에는 해당 도형만 포함되며 슬라이드 배경이나 인접 도형은 포함되지 않습니다.

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

렌더링 중에는 프레젠테이션을 열어 두어야 합니다. 출력은 도형의 서식과 글꼴·이미지와 같은 리소스에 따라 달라집니다. 전체 구성을 원하면 개별 도형이 아니라 슬라이드를 내보내십시오. 스트림은 호출자가 소유하며 반드시 닫아야 합니다.

## **도형 정렬**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) 오버로드는 모든 도형 또는 선택된 컬렉션 인덱스를 정렬합니다. [ShapesAlignmentType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/shapesalignmenttype/)은 가장자리·중심선·분포 모드를 지정합니다. `alignToSlide`을 `true`로 하면 슬라이드 가장자리를 기준으로, `false`로 하면 선택된 도형들끼리 상대적으로 정렬합니다.

다음 예제는 세 도형을 슬라이드 상단 가장자리에 정렬합니다. 반환된 도형 참조는 정렬 직전에 현재 인덱스로 변환됩니다.

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

정렬은 위치만 바꾸며 Z‑order는 변경하지 않습니다. 상대 정렬에는 최소 두 개의 도형이 필요하고, 수평·수직 분포에는 간격을 정의할 충분한 도형이 필요합니다. 메서드 호출 전에 컬렉션을 수정했다면 인덱스를 다시 계산하십시오.

## **도형 플립**

[ShapeFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/shapeframe/) 클래스는 위치·크기·수평·수직 플립 설정·회전을 저장합니다. `getFlipH`와 `getFlipV` 값은 [NullableBool](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/nullablebool/)을 사용합니다: `True`는 플립을 활성화하고, `False`는 비활성화하며, `NotDefined`는 지정되지 않은/기본 상태를 유지합니다.

아래 입력 프레젠테이션에는 플립되지 않은 도형 하나가 포함되어 있습니다.

![The shape before flipping](shape_to_be_flipped.png)

예제는 다른 모든 프레임 값을 유지하면서 두 플립 설정만 교체합니다. 이는 새로운 [Frame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-)을 할당하면 전체 프레임이 교체되기 때문에 중요합니다.

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

저장된 도형은 수평·수직으로 미러링되지만 위치·크기·회전은 그대로 유지됩니다.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**컬렉션 인덱스를 도형 식별자로 사용해도 될까?**

컬렉션이 변하지 않을 짧은 처리 과정에만 사용하십시오. 템플릿을 작성한 경우 검증된 `Name` 또는 `AlternativeText` 규칙을, 슬라이드 범위 인터옵 작업에는 `OfficeInteropShapeId`를 선호하십시오.

**도형을 숨기면 Z‑order에서 제거되나요?**

아니요. 숨긴 도형은 같은 인덱스에 남아 있으며, 찾고, 순서를 바꾸고, 편집하거나 다시 표시할 수 있습니다.

**복제된 도형이 다른 도형 앞에 나타난 이유는?**

`addClone`은 복제본을 컬렉션 끝에 추가하므로 Z‑order의 앞쪽에 위치합니다. 초기 인덱스를 지정하려면 `insertClone`을 사용하거나 모든 도형 추가 후 `reorder`로 조정하십시오.

**프리셋 도형 조정을 식별하기 위해 고정 인덱스를 사용해도 될까?**

정확한 프리셋과 컬렉션 레이아웃을 검증한 후에만 가능합니다. `IGeometryShape.getAdjustments`를 반복하면서 `IAdjustValue.getType`을 확인하고, 동일한 의미 유형이 여러 번 나타날 경우 `IAdjustValue.getName`을 추가 정보로 활용하십시오.