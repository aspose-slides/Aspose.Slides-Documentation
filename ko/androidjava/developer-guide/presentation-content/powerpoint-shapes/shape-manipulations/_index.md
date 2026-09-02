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
- 도형 제거
- 도형 숨기기
- 도형 순서 변경
- Interop 도형 ID 가져오기
- 도형 대체 텍스트
- 도형 레이아웃 형식
- SVG로 도형
- 도형을 SVG로 변환
- 도형 정렬
- 도형 뒤집기
- PowerPoint
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java를 사용하여 프레젠테이션 도형을 식별, 복제, 제거, 숨기기, 순서 변경, 내보내기, 정렬 및 뒤집는 방법을 배우세요."
---
## **개요**

Aspose.Slides for Android via Java는 슬라이드의 도형을 순서가 지정된 [IShapeCollection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishapecollection/)로 나타냅니다. 이 컬렉션은 도형을 찾고 수정하는 장소이자, 도형의 쌓임 순서를 결정하는 원천입니다: 인덱스 `0`은 가장 뒤에 있는 도형이며, 마지막 인덱스는 가장 앞에 있는 도형입니다.

이 문서는 해당 모델을 따릅니다. 먼저 도형을 안정적으로 식별하는 방법을 설명하고, 그 다음 도형을 복제, 제거, 숨기기 및 재정렬하는 방법을 보여줍니다. 마지막 섹션에서는 레이아웃 수준 서식, SVG 내보내기, 정렬 및 뒤집기 설정을 다룹니다. 각 예제는 독립적이므로 워크플로에 필요한 작업만 사용할 수 있습니다.

## **도형 식별 및 찾기**

컬렉션 인덱스는 알려진 파일을 처리할 때 편리하지만 안정적인 식별자는 아닙니다. 도형을 추가, 제거 또는 재정렬하면 인덱스가 바뀔 수 있습니다. 프레젠테이션이 어떻게 작성·관리되는지에 따라 식별자를 선택하십시오:

- [Name](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishape/#getName--)은 개발자가 제어하는 템플릿에 유용하며 PowerPoint 선택 창에서 쉽게 확인할 수 있습니다. 이름은 편집 가능하지만 고유성을 보장하지 않으므로 코드가 이름에 의존한다면 명명 규칙을 마련하십시오.
- [AlternativeText](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishape/#getAlternativeText--)는 접근성 설명이나 작성자가 제공한 태그가 이미 도형을 식별할 때 유용합니다. 사용자는 이를 볼 수 있으며 현지화되거나 접근성을 위해 재작성될 수 있지만 고유성을 보장하지 않습니다. 의미 있는 접근성 텍스트를 데이터베이스 키로 무심코 재사용하지 마십시오.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--)은 슬라이드 내에서 고유하고 PowerPoint interop에서 사용되는 도형 ID에 해당하는 읽기 전용 식별자입니다. PowerPoint와 통합하거나 도형 수명 동안 명확한 참조가 필요할 때 사용하십시오. 복제되거나 재생성된 도형은 다른 도형이며 자체 ID를 받습니다.

관련 [getUniqueId](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishape/#getUniqueId--) 메서드는 프레젠테이션 범위의 식별자를 반환하지만, 이 식별자는 애드인용이며 재할당될 수 있습니다. 영구적인 외부 키로 취급하지 말아야 합니다. 장기적인 정체성이 필수라면 애플리케이션 데이터에 매핑을 보관하고 예상 도형이 여전히 존재하는지 검증하십시오.

다음 예제는 정확히 일치하는 이름으로 검색하고 슬라이드 범위의 interop ID를 보고합니다. 템플릿에 예상 도형이 없을 경우 코드는 잘못된 객체를 계속 사용하지 않고 해당 결과를 보고합니다.

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

작업이 특정 도형 유형에 한정되는 경우, 유형별 멤버를 사용하기 전에 인터페이스를 확인하십시오. 이 예제는 이름이 지정된 객체가 [IAutoShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iautoshape/)인지 확인한 후 텍스트와 대체 텍스트를 업데이트합니다.

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

## **도형 컬렉션 수정**

추가, 복제, 제거 및 재정렬 메서드는 컬렉션에 즉시 영향을 줍니다. 작업이 도형 수나 순서를 바꾸면, 해당 작업 이전에 캡처한 인덱스에 계속 의존하지 마십시오.

### **도형 복제**

[addClone](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-)은 독립적인 복제본을 만들고 대상 컬렉션에 추가합니다. [insertClone](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-)도 복제본을 만들지만 지정된 z‑order 인덱스에 배치합니다. 좌표를 받는 오버로드는 크기를 변경하지 않고 복제본을 이동하고, 너비와 높이를 받는 오버로드는 크기도 조절합니다.

예제는 대상 슬라이드를 만든 뒤 라벨이 붙은 사각형을 앞쪽에 복제하고, 두 번째 복제본을 뒤쪽에 삽입합니다. 두 복제본 중 어느 하나를 변경해도 원본 도형은 수정되지 않습니다.

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

복제는 도형의 내용과 서식, 이름 및 대체 텍스트까지 복사합니다. 이러한 값이 고유해야 한다면 복제본에 새로운 논리 식별자를 할당하십시오. 복잡한 도형에 사용되는 리소스는 프레젠테이션에서 관리하지만, 복제본은 새로운 컬렉션 항목이자 새로운 도형 ID를 갖습니다.

### **도형 제거**

[remove](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-)은 특정 도형 객체를 컬렉션에서 삭제합니다. 인덱스 기반 반복 중에 여러 매치를 제거할 경우, 남은 인덱스가 유효하도록 끝에서부터 순회하십시오.

이 예제는 지정된 이름을 가진 모든 도형을 제거합니다. 고정된 컬렉션 항목이 아니라 현재 인덱스의 도형을 읽으며, 불필요하게 형변환하지도 않습니다.

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

제거 후에는 도형 개수와 이후 도형들의 인덱스가 바뀝니다. 영향을 받지 않은 도형에 대한 참조는 저장된 인덱스보다 더 신뢰할 수 있습니다. 또한 연결선, 애니메이션 및 다른 프레젠테이션 기능이 제거된 객체를 참조할 수 있으니, 보이는 도형을 삭제하면 슬라이드 외관 이상을 초래할 수 있음을 고려하십시오.

### **도형 숨기기**

[Hidden](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishape/#setHidden-boolean-)을 `true`로 설정하면 도형이 컬렉션에 남아 있지만 일반 슬라이드 쇼에서는 표시되지 않습니다. 인덱스, 서식 및 내용은 코드에서 계속 접근 가능하므로, 나중에 복원할 수 있는 선택적 요소에 적합합니다.

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

숨기기는 삭제나 보안과 다릅니다. 객체는 여전히 발견·해제될 수 있으며 프레젠테이션 파일의 일부로 남아 있습니다.

### **Z‑Order 변경**

겹치는 도형은 컬렉션 순서대로 그려집니다. [reorder](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-)은 복제 없이 기존 도형을 목표 인덱스로 이동합니다. 인덱스 `0`은 뒤쪽, `size() - 1`은 앞쪽을 의미합니다.

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

사각형을 먼저 만들면 처음에는 타원 뒤에 위치합니다. 최종 인덱스로 이동하면 앞쪽에 놓이게 됩니다. 모든 관련 도형을 추가·복제한 뒤에 Z‑order를 확정하십시오. 이러한 작업은 컬렉션에 새 항목을 추가하거나 삽입해 스택을 바꿀 수 있기 때문입니다.

## **레이아웃 슬라이드의 도형 검사**

일반 슬라이드, 레이아웃 슬라이드 및 마스터 슬라이드는 각각 별도 도형 컬렉션을 가집니다. 레이아웃 컬렉션의 도형은 일반 슬라이드의 동일 위치 도형과 다른 객체입니다. 레이아웃이 제공하는 서식을 이해하거나 변경해야 할 때 레이아웃 도형을 검사하십시오.

다음 예제는 각 레이아웃 도형의 [FillFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishape/#getFillFormat--) 및 [LineFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishape/#getLineFormat--)을 읽으며, 모든 도형이 `AutoShape`인 것으로 가정하지 않습니다.

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

레이아웃을 편집하면 해당 레이아웃을 사용하는 여러 슬라이드에 영향을 미칩니다. 레이아웃 도형을 변경하기 전에 일반 슬라이드가 객체를 상속하는지 혹은 로컬 오버라이드가 있는지 판단하고, 레이아웃을 사용하는 모든 슬라이드를 테스트하십시오.

## **도형을 SVG로 내보내기**

[writeAsSvg](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) 메서드는 하나의 도형 렌더링 내용을 스트림에 씁니다. 결과에는 해당 도형만 포함되며 슬라이드 배경이나 주변 도형은 포함되지 않습니다.

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

렌더링 중에는 프레젠테이션을 열어 두십시오. 출력은 도형 서식과 폰트·이미지 같은 리소스에 따라 달라집니다. 전체 구성이 필요하면 개별 도형이 아니라 슬라이드를 내보내십시오. 호출자가 스트림을 소유하며 반드시 닫아야 합니다.

## **도형 정렬**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) 오버로드는 모든 도형이나 선택된 컬렉션 인덱스를 정렬합니다. [ShapesAlignmentType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/shapesalignmenttype/)은 가장자리, 중심선 또는 배분 모드를 지정합니다. `alignToSlide`을 `true`로 설정하면 슬라이드 가장자리를 기준으로, `false`로 설정하면 선택된 도형들 간의 상대 정렬을 수행합니다.

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

정렬은 위치만 바꾸고 Z‑order는 변경하지 않습니다. 상대 정렬은 보통 두 개 이상의 도형이 필요하고, 가로·세로 배분은 충분한 도형 수가 있어야 간격을 정의할 수 있습니다. 메서드 호출 전에 컬렉션을 수정했다면 인덱스를 다시 계산하십시오.

## **도형 뒤집기**

[ShapeFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/shapeframe/) 클래스는 위치, 크기, 가·세로 뒤집기 설정 및 회전을 저장합니다. `getFlipH`와 `getFlipV` 값은 [NullableBool](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/nullablebool/)을 사용합니다: `True`는 뒤집기를 활성화하고, `False`는 비활성화하며, `NotDefined`는 지정되지 않거나 기본 상태를 유지합니다.

아래 입력 프레젠테이션에는 뒤집히지 않은 도형 하나가 포함되어 있습니다.

![The shape before flipping](shape_to_be_flipped.png)

예제는 다른 모든 프레임 값을 그대로 두고 두 뒤집기 설정만 교체합니다. 이는 새로운 [Frame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-)을 할당하면 전체 프레임이 교체되기 때문에 중요합니다.

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

저장된 도형은 수평·수직으로 각각 뒤집히며 위치·크기·회전은 그대로 유지됩니다.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**컬렉션 인덱스를 도형 식별자로 사용해도 될까요?**

컬렉션이 변경되지 않을 짧은 처리 과정에서만 사용하십시오. 작성된 템플릿에는 검증된 `Name` 또는 `AlternativeText` 규칙을, 슬라이드 범위 interop 작업에는 `OfficeInteropShapeId`를 권장합니다.

**도형을 숨기면 Z‑order에서 제거되나요?**

아니요. 숨겨진 도형은 같은 인덱스로 컬렉션에 남아 있습니다. 찾을 수 있고, 재정렬·편집·다시 표시가 가능합니다.

**복제된 도형이 다른 도형 앞에 나타난 이유는?**

`addClone`은 복제본을 컬렉션 끝에 추가하므로 Z‑order의 앞쪽이 됩니다. 초기 인덱스를 지정하려면 `insertClone`을 사용하거나 모든 도형을 추가한 뒤 `reorder`를 사용하십시오.