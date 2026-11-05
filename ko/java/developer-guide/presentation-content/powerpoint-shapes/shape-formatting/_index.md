---
title: Java에서 PowerPoint 도형 서식 지정
linktitle: 도형 서식 지정
type: docs
weight: 20
url: /ko/java/shape-formatting/
keywords:
- 도형 서식
- 선 서식
- 스케치 효과
- 도형 선 스케치
- 조인 스타일 서식
- 그라디언트 채우기
- 패턴 채우기
- 그림 채우기
- 텍스처 채우기
- 단색 채우기
- 도형 투명도
- 흑백 도형 렌더링
- 회색조 도형 렌더링
- 도형 회전
- 3d 베벨 효과
- 3d 회전 효과
- 서식 재설정
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Java에서 PowerPoint 도형을 서식 지정하는 방법을 배웁니다—PPT 및 PPTX 파일에 대해 정확하고 완전한 제어로 채우기, 선 및 효과 스타일을 설정합니다."
---
## **소개**

PowerPoint에서 도형의 윤곽선, 채우기 및 효과를 조정하여 형식화합니다. Aspose.Slides for Java를 사용하면 투명도, 회전 및 3D 형식을 포함한 이러한 설정을 프로그래밍 방식으로 제어할 수 있습니다.

![PowerPoint에서 도형 형식 옵션](format-shape-powerpoint.png)

Aspose.Slides for Java는 PowerPoint에서 사용할 수 있는 동일한 옵션을 사용하여 도형을 형식화할 수 있는 인터페이스와 메서드를 제공합니다.

## **선 형식 지정**

[IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--)을 사용하여 도형의 윤곽선을 제어합니다. 이 예제는 파란색 점선 윤곽선을 가진 채우기되지 않은 사각형을 생성합니다. [ILineFormat.setStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setStyle-byte-)은 두꺼운‑가는 복합선을 선택하고, [ILineFormat.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setWidth-double-)는 폭을 7포인트로 설정하며, [ILineFormat.setDashStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setDashStyle-byte-)는 대시 패턴을 선택합니다.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![프레젠테이션에서 형식이 지정된 선](formatted-lines.png)

### **사용자 지정 선 대시 패턴 설정**

미리 정의된 선 스타일이 필요한 대시 길이와 간격을 제공하지 않을 때, 예를 들어 브랜드 윤곽선이나 기술 도면에서, [ILineFormat.setCustomDashPattern](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setCustomDashPattern-float---)을 사용합니다. 패턴을 할당하면 선 대시 스타일이 자동으로 [LineDashStyle.Custom](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/)으로 변경됩니다.

배열 항목은 대시와 간격 길이를 교대로 지정하며, 대시부터 시작합니다. 각 값은 선 폭의 배수입니다: `{ 4, 2 }`를 폭 3포인트에 적용하면 12포인트 대시 뒤에 6포인트 간격이 생성됩니다. 유한하고 음수가 아닌 값 쌍을 사용하여 완전한 대시‑간격 세그먼트를 정의합니다. 예제에서는 모두 양수 값을 사용하여 각 대시와 간격이 보이도록 합니다.

이 예제는 동일한 길이와 평면 캡을 가진 파란색 선 5개를 생성합니다. 처음 세 개는 폭 3포인트에서 패턴을 비교하고, 네 번째는 첫 번째 패턴을 두 배 폭으로 반복하여 대시와 간격 길이를 모두 두 배로 늘립니다. 다섯 번째는 사용자 지정 패턴에서 실선으로 전환합니다.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(600, 300, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[][] patterns = {
        { 4, 2 },
        { 1, 2 },
        { 6, 2, 1, 2 },
        { 4, 2 },
        { 4, 2 }
    };

    for (int i = 0; i < patterns.length; i++) {
        IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 50, 50 + i * 50, 500, 0);
        line.getLineFormat().setWidth(i == 3 ? 6 : 3);
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
        line.getLineFormat().setCapStyle(LineCapStyle.Flat);
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setCustomDashPattern(patterns[i]);
    }

    // 마지막 선을 실선 스타일로 되돌립니다.
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(LineDashStyle.Solid);

    presentation.save("custom_dash_patterns.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

미리 정의된 점선 스타일로 되돌리려면 [ILineFormat.setDashStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setDashStyle-byte-)에 [LineDashStyle.Dash](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/)을 전달합니다. 선택된 스타일이 선의 외관을 제어합니다.

PowerPoint에서 위에서 아래 순서로 결과: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; 및 **Solid, 3 pt**.

![세 개의 사용자 지정 대시 패턴, 첫 번째 패턴을 사용한 더 넓은 선 및 실선이 PowerPoint에 표시된 모습](custom-dash-patterns.png)

### **선 캡 설정**

[ILineFormat.setCapStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setCapStyle-byte-)을 사용하여 열린 선의 끝을 설정합니다. [LineCapStyle](https://reference.aspose.com/slides/java/com.aspose.slides/linecapstyle/) 클래스는 세 가지 명시적 캡 스타일을 제공합니다:

- `Flat`: 스트로크가 끝점에서 멈춥니다.
- `Round`: 반원형 캡이 선 폭의 절반만큼 끝점을 넘어 확장됩니다.
- `Square`: 정사각형 캡이 선 폭의 절반만큼 끝점을 넘어 확장됩니다.

클래스에는 `NotDefined`도 포함되어 있으며, 이는 캡 스타일이 명시적으로 할당되지 않았음을 의미합니다.

캡은 선 끝에 기호를 추가하는 화살표와, 선 세그먼트 사이의 모서리를 제어하는 조인과는 다릅니다. 이 예제는 [ILineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setBeginArrowheadStyle-byte-) 및 [ILineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setEndArrowheadStyle-byte-)을 사용하여 화살표를 비활성화하고 캡 모양만 비교합니다.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(500, 240, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] capStyles = new byte[] { LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square };

    for (int i = 0; i < capStyles.length; i++) {
        IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0);
        line.getLineFormat().setWidth(20);
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
        line.getLineFormat().setDashStyle(LineDashStyle.Solid);
        line.getLineFormat().setCapStyle(capStyles[i]);
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None);
    }

    presentation.save("line_caps.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

PowerPoint에서 위에서 아래 순서로 결과: **Flat**, **Round**, 및 **Square**.

![PowerPoint에서 동일한 굵기의 선에 평면, 원형 및 사각형 캡이 적용된 모습](line-caps.png)

## **도형 선에 스케치 효과 적용**

스케치 효과는 도형 선을 손으로 그린 것처럼 보이게 합니다. [IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--)을 사용하여 선 설정에 접근하고, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getSketchFormat--)을 사용하여 스케치 설정에 접근한 다음, [ISketchFormat.setSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/#setSketchType-int-)을 사용하여 [LineSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) 클래스에서 값을 선택합니다.

다음 Java 코드는 [LineSketchType.Curved](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) 효과를 적용하고, 명시적으로 할당된 값을 읽으며, [LineSketchType.None](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/)으로 효과를 제거하는 방법을 보여줍니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();
    sketchFormat.setSketchType(LineSketchType.Curved);
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

[ISketchFormat.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/#getSketchType--)이 반환하는 값은 도형에 직접 할당된 설정을 나타냅니다. 선 형식이 테마, 마스터 슬라이드 또는 레이아웃 슬라이드에서 상속될 수 있는 경우, [ILineFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getEffective--)을 사용하고, [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformateffectivedata/#getSketchFormat--)에 접근한 다음, [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformateffectivedata/#getSketchType--)을 읽습니다. 유효 값은 상속이 해결된 후 실제로 적용된 형식을 반영합니다. 이 예제는 첫 번째 슬라이드에 최소 하나의 도형이 있는 기존 프레젠테이션이 필요하며 두 값을 출력합니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    ILineFormat lineFormat = shape.getLineFormat();
    int explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    ILineFormatEffectiveData effectiveLineFormat = lineFormat.getEffective();
    int effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    System.out.println("Explicit sketch type: " + explicitSketchType);
    System.out.println("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **조인 스타일 서식 지정**

다음은 세 가지 조인 유형 옵션입니다:

* Round
* Miter
* Bevel

조인 스타일은 두 윤곽선 세그먼트가 모서리에서 어떻게 만나는지를 제어합니다. **Round**는 둥근 모서리, **Miter**는 날카로운 모서리, **Bevel**은 평평한 모서리를 사용합니다.

![프레젠테이션의 조인 스타일](join-style-powerpoint.png)

이 예제는 폭 15포인트인 파란색 윤곽선을 가진 검은색 사각형 3개를 생성합니다. 각각 [LineJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/linejoinstyle/)의 miter, bevel, round 값을 설정하기 위해 [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setJoinStyle-byte-)을 사용합니다.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape miterShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape bevelShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape roundShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    miterShape.getFillFormat().setFillType(FillType.Solid);
    miterShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    bevelShape.getFillFormat().setFillType(FillType.Solid);
    bevelShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    roundShape.getFillFormat().setFillType(FillType.Solid);
    roundShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    miterShape.getLineFormat().setWidth(15);
    bevelShape.getLineFormat().setWidth(15);
    roundShape.getLineFormat().setWidth(15);

    miterShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    miterShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    bevelShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    bevelShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    roundShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    roundShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    miterShape.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    bevelShape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    roundShape.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    miterShape.getTextFrame().setText("Miter Join Style");
    bevelShape.getTextFrame().setText("Bevel Join Style");
    roundShape.getTextFrame().setText("Round Join Style");

    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **날카로운 모서리에서 마이터 조인 제한**

[ILineFormat.setMiterLimit](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setMiterLimit-float-)을 사용하고, [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setJoinStyle-byte-)를 [LineJoinStyle.Miter](https://reference.aspose.com/slides/java/com.aspose.slides/linejoinstyle/)로 설정하여 날카로운 모서리가 얼마나 멀리 뻗을 수 있는지를 제한합니다.

제한값은 조인 내부와 외부 모서리 사이 거리와 선 폭의 비율입니다. 예를 들어 `8`은 마이터 길이가 선 폭의 최대 8배까지 허용됨을 의미하며, 포인트 단위 측정이 아닙니다. 모서리가 제한을 초과하면 PowerPoint는 해당 모서리에 베벨 조인을 사용합니다. 더 큰 제한값은 더 날카로운 점을 허용합니다. 이 설정은 마이터 조인에만 영향을 미치며, 모서리가 두 제한값 모두 내에 있을 때는 눈에 보이는 효과가 없습니다.

이 예제는 폭 20포인트인 윤곽선을 가진 동일한 형태의 채우기되지 않은 삼각형 두 개를 생성합니다. 왼쪽 삼각형은 제한값 `2`를 사용하고, 오른쪽은 `8`을 사용합니다. 각 삼각형의 너비는 80포인트, 높이는 160포인트이며, 상단 모서리의 마이터 길이‑선 폭 비율은 약 `4.12`입니다. 따라서 PowerPoint는 왼쪽 꼭짓점을 베벨 처리하고 오른쪽 꼭짓점은 그대로 유지합니다.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(500, 320, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[] miterLimits = new float[] { 2f, 8f };

    for (int i = 0; i < miterLimits.length; i++) {
        IAutoShape triangle = slide.getShapes().addAutoShape(ShapeType.Triangle, 90 + i * 240, 110, 80, 160);
        triangle.getFillFormat().setFillType(FillType.NoFill);
        triangle.getLineFormat().setWidth(20);
        triangle.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        triangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
        triangle.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
        triangle.getLineFormat().setMiterLimit(miterLimits[i]);
    }

    presentation.save("miter_limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

PowerPoint에서 결과: 왼쪽은 **Miter limit 2**, 오른쪽은 **miter limit 8**.

![PowerPoint에서 마이터 제한 2인 베벨 꼭짓점과 마이터 제한 8인 뾰족한 꼭짓점](miter-limits.png)

## **그라디언트 채우기**

그라디언트 채우기는 도형 전체에 색상을 혼합합니다. 이 예제는 [IFillFormat.getGradientFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getGradientFormat--)을 사용하여 빨간색에서 보라색으로 45도 각도의 선형 그라디언트를 타원에 적용합니다. [IGradientStopCollection.addPresetColor](https://reference.aspose.com/slides/java/com.aspose.slides/igradientstopcollection/#addPresetColor-float-int-) 메서드는 그라디언트 시작(0)과 끝(1)에 색상 정지를 배치합니다. 기존 정지를 지우면 두 색상만 사용됩니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
    shape.getFillFormat().getGradientFormat().setLinearGradientAngle(45);
    shape.getFillFormat().getGradientFormat().getGradientStops().clear();
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0f, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0f, PresetColor.Red);

    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![그라디언트 채우기가 적용된 타원](gradient-fill.png)

그라디언트가 내보낸 이미지에서 PowerPoint와 다르게 보이는 경우, [Choose a Gradient Rendering Style](/slides/ko/java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style)를 참조하십시오. 프레젠테이션에 저장된 그라디언트 채우기를 변경하지 않고 렌더링 스타일만 선택할 수 있습니다.

### **선형 그라디언트 각도 설정**

[IGradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-)을 사용하여 [GradientShape.Linear](https://reference.aspose.com/slides/java/com.aspose.slides/gradientshape/) 채우기의 방향을 제어합니다. 각도는 도 단위이며 시계 방향으로 증가합니다: `0`은 왼쪽에서 오른쪽, `90`은 위에서 아래, `180`은 오른쪽에서 왼쪽, `270`은 아래에서 위로 흐릅니다. 소수 각도도 지원됩니다. `[0, 360)` 범위 밖의 유한 각도는 한 바퀴로 정규화됩니다; 예를 들어 `-45`는 `315`가 되고 `360`은 `0`이 됩니다.

이 예제는 동일한 빨강, 초록, 파랑 정지를 `0`, `0.5`, `1` 위치에 배치한 직사각형 6개를 생성합니다. 스케일을 비활성화하여 각도를 사각형 비율과 무관하게 비교할 수 있게 합니다. 왼쪽에서 오른쪽으로 첫 행은 `0`, `45`, `90`도, 두 번째 행은 `135`, `180`, `270`도입니다.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[] angles = new float[] { 0, 45, 90, 135, 180, 270 };

    for (int i = 0; i < angles.length; i++) {
        int x = 30 + (i % 3) * 230;
        int y = 30 + (i / 3) * 190;

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 200, 150);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        shape.getFillFormat().setFillType(FillType.Gradient);

        IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(GradientShape.Linear);
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0f, Color.RED);
        gradient.getGradientStops().add(0.5f, Color.GREEN);
        gradient.getGradientStops().add(1f, Color.BLUE);
        gradient.setLinearGradientScaled(NullableBool.False);
        gradient.setLinearGradientAngle(angles[i]);
    }

    presentation.save("linear_gradient_angles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

PowerPoint에서 결과:

![위 행은 0°, 45°, 90°, 아래 행은 135°, 180°, 270°인 선형 그라디언트](linear-gradient-angles.png)

### **도형에 선형 그라디언트 스케일링**

[IGradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientScaled-byte-)은 [NullableBool](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) 값을 허용합니다. `False`로 명시하면 도형 비율이 변해도 기하학적 그라디언트 각도를 유지하고, `True`로 설정하면 그라디언트가 도형의 너비와 높이에 맞게 스케일됩니다. 스케일이 활성화되면 비정사각형 도형에서 보이는 각도가 할당된 각도와 다를 수 있습니다.

다음 예제는 `45`도 각도와 동일한 색상 정지를 사용합니다. 왼쪽 열은 `False`, 오른쪽 열은 `True`를 사용합니다. 각 열에는 넓은 직사각형 위에 높은 직사각형이 있습니다. 두 번째 직사각형의 너비와 높이를 변경하여 채우기가 크기 조정에 어떻게 반응하는지 보여줍니다.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 460, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] scalingOptions = new byte[] { NullableBool.False, NullableBool.True };

    for (int column = 0; column < scalingOptions.length; column++) {
        for (int row = 0; row < 2; row++) {
            int x = 30 + column * 360;
            int y = row == 0 ? 30 : 150;

            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 300, 90);
            shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
            shape.getFillFormat().setFillType(FillType.Gradient);

            IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
            gradient.setGradientShape(GradientShape.Linear);
            gradient.getGradientStops().clear();
            gradient.getGradientStops().add(0f, Color.RED);
            gradient.getGradientStops().add(0.5f, Color.GREEN);
            gradient.getGradientStops().add(1f, Color.BLUE);
            gradient.setLinearGradientAngle(45);
            gradient.setLinearGradientScaled(scalingOptions[column]);

            if (row == 1) {
                shape.setWidth(90);
                shape.setHeight(280);
            }
        }
    }

    presentation.save("linear_gradient_scaling.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

PowerPoint에서 결과(왼쪽은 스케일 비활성화, 오른쪽은 활성화):

![넓은 직사각형과 높은 직사각형에 45도 그라디언트를 적용한 예시, 왼쪽은 LinearGradientScaled False, 오른쪽은 True](linear-gradient-scaling.png)

스케일이 비활성화되면 두 직사각형 모두 대각선 색대가 같은 방향을 유지합니다. 스케일이 활성화되면 색대가 도형 비율에 맞게 늘어납니다. 이는 템플릿의 그라디언트를 다른 크기의 도형에 적용할 때 도움이 됩니다. 정사각형에서는 스케일을 켜도 이 `45`도 그라디언트의 모습은 변하지 않습니다.

각도와 스케일 설정은 선형 그라디언트에만 적용되며, [GradientShape.Radial] 또는 [GradientShape.Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/gradientshape/) 채우기에는 영향을 주지 않습니다.

### **각도와 그라디언트 방향 결합**

[IGradientFormat.setGradientDirection](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setGradientDirection-int-)은 [GradientDirection](https://reference.aspose.com/slides/java/com.aspose.slides/gradientdirection/) 클래스에서 그라디언트 스타일을 선택하며, 숫자 각도의 대체물이 아닙니다. 선형 그라디언트의 경우, 코너 스타일에 따라 색상이 분배되는 영역이 달라질 수 있지만 [setLinearGradientAngle](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-)을 통해 지정된 각도는 변하지 않습니다. 각도 또는 스케일을 비교할 때는 방향을 변경하지 마세요.

다음 예제는 같은 설정을 역순으로 적용합니다. 두 직사각형은 동일한 외관을 가지고 있으며, 방향을 각도 앞이나 뒤에 지정해도 결과가 바뀌지 않습니다.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (int i = 0; i < 2; i++) {
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30 + i * 140, 320, 100);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        shape.getFillFormat().setFillType(FillType.Gradient);

        IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(GradientShape.Linear);
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0f, Color.RED);
        gradient.getGradientStops().add(0.5f, Color.GREEN);
        gradient.getGradientStops().add(1f, Color.BLUE);
        gradient.setLinearGradientScaled(NullableBool.True);

        if (i == 0) {
            gradient.setGradientDirection(GradientDirection.FromCorner1);
            gradient.setLinearGradientAngle(30);
        } else {
            gradient.setLinearGradientAngle(30);
            gradient.setGradientDirection(GradientDirection.FromCorner1);
        }
    }

    presentation.save("linear_gradient_direction.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **패턴 채우기**

패턴 채우기는 점, 줄무늬 또는 격자와 같은 두 색상의 디자인을 적용합니다. 이 예제는 [IPatternFormat.setPatternStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#setPatternStyle-byte-)을 사용하여 격자 패턴을 선택합니다. [IPatternFormat.getBackColor](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#getBackColor--)은 밝은 회색 배경을 제공하고, [IPatternFormat.getForeColor](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#getForeColor--)은 노란색 패턴 색을 제공합니다.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Pattern);
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![패턴 채우기가 적용된 직사각형](pattern-fill.png)

## **그림 채우기**

그림 채우기는 도형 내부에 이미지를 사용합니다. 이 예제는 로컬 이미지를 필요로 하며, [Images.fromFile](https://reference.aspose.com/slides/java/com.aspose.slides/images/#fromFile-java.lang.String-)을 사용해 프레젠테이션 이미지 컬렉션에 로드합니다. [IPictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-)을 타일 모드로 설정하면 사각형 안에 이미지가 반복됩니다. 아래에 사용된 원본 이미지는 다음과 같습니다:

![연꽃 사진](lotus.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    IImage image = Images.fromFile("lotus.png");
    IPPImage picture;
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![그림 채우기가 적용된 도형](picture-fill.png)

### **텍스처로 그림 타일링**

타일 그림을 텍스처로 설정하고 타일링 동작을 사용자 지정하려면 다음 [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) 인터페이스와 [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillformat/) 클래스의 메서드를 사용할 수 있습니다:

- [setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): 그림 채우기 모드를 `Tile` 또는 `Stretch`로 설정합니다.
- [setTileAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): 도형 내 타일 정렬을 지정합니다.
- [setTileFlip](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): 타일을 수평, 수직 또는 두 방향으로 뒤집을지 제어합니다.
- [setTileOffsetX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): 도형 원점에서 타일의 수평 오프셋(포인트)을 설정합니다.
- [setTileOffsetY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): 도형 원점에서 타일의 수직 오프셋(포인트)을 설정합니다.
- [setTileScaleX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): 타일의 수평 스케일을 백분율로 정의합니다.
- [setTileScaleY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): 타일의 수직 스케일을 백분율로 정의합니다.

이 예제는 로컬 이미지를 필요로 하며, 원본 크기의 50%로 반복하도록 [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/)을 구성합니다. `-32`포인트 오프셋은 타일을 수평·수직으로 이동하고, 오른쪽 아래 정렬 및 양쪽 플립은 반복 텍스처 배치를 결정합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);
    shape.getFillFormat().setFillType(FillType.Picture);

    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![타일 옵션](tile-options.png)

## **단색 채우기**

단색 채우기는 도형에 단일, 균일한 색을 제공합니다. 이 예제는 [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-)을 사용하여 단색 채우기 모드를 설정하고, [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--)을 통해 노란색을 지정한 뒤 사각형을 프레젠테이션에 저장합니다.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![단색 채우기가 적용된 도형](solid-color-fill.png)

### **테마 참조를 유지하면서 색상 복사**

[IColorFormat.copyFrom](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/#copyFrom-com.aspose.slides.IColorFormat-)을 사용하면 색상 유형, 테마 참조 및 변환을 포함한 색상 정의를 복사할 수 있습니다. 이는 채우기 색상을 도형 간에 옮기면서 프레젠테이션 테마를 계속 따르게 할 때 유용합니다. 이 메서드는 색상만 복사하고 채우기 유형, 윤곽선 또는 기타 도형 서식은 복사하지 않습니다. 대상의 채우기 유형은 [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-)으로 명시적으로 설정합니다.

이 예제는 왼쪽부터 오른쪽 순서로 원본, 테마를 인식한 복사본, 고정 RGB 복사본의 세 개 직사각형을 생성합니다. 원본은 [IColorFormat.setSchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/#setSchemeColor-int-)을 사용해 첫 번째 강조 색을 참조하고, [IColorOperationCollection.add](https://reference.aspose.com/slides/java/com.aspose.slides/icoloroperationcollection/#add-int-float-)으로 색조를 추가합니다. RGB 복사본은 원본의 유효 채우기 색상을 사용해 처음에 모두 동일하게 보입니다. [IColorFormat.setColor](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/#setColor-java.awt.Color-)를 호출하면 고정 RGB 값이 설정되고 기존 색상 변환이 모두 제거됩니다.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(660, 220, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(new Color(65, 105, 225));

    IAutoShape source = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 40, 180, 140);
    IAutoShape themeCopy = slide.getShapes().addAutoShape(ShapeType.Rectangle, 240, 40, 180, 140);
    IAutoShape rgbCopy = slide.getShapes().addAutoShape(ShapeType.Rectangle, 450, 40, 180, 140);

    for (IAutoShape shape : new IAutoShape[] { source, themeCopy, rgbCopy }) {
        shape.getFillFormat().setFillType(FillType.Solid);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    }

    IColorFormat sourceColor = source.getFillFormat().getSolidFillColor();
    sourceColor.setSchemeColor(SchemeColor.Accent1);
    sourceColor.getColorTransform().add(ColorTransformOperation.Tint, 0.75f);

    themeCopy.getFillFormat().getSolidFillColor().copyFrom(sourceColor);
    rgbCopy.getFillFormat().getSolidFillColor().setColor(source.getFillFormat().getEffective().getSolidFillColor());

    IImage before = slide.getImage(1f, 1f);
    try {
        before.save("color-copy-before.png", ImageFormat.Png);
    } finally {
        before.dispose();
    }

    // 테마 참조는 새 강조 색을 따르며, 고정된 RGB 값은 따르지 않습니다.
    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(new Color(255, 69, 0));

    IImage after = slide.getImage(1f, 1f);
    try {
        after.save("color-copy-after.png", ImageFormat.Png);
    } finally {
        after.dispose();
    }
    presentation.save("copied_colors.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

테마 변경 전, 세 개의 채우기가 모두 동일한 파란색으로 일치합니다:

![원본, copyFrom 대상, 고정 RGB 대상이 동일한 파란색 채우기로 표시된 모습](color-copy-before.png)

테마 변경 후, 원본과 테마 인식 복사본은 새로운 강조 색을 따르고 색조를 유지합니다. 고정 RGB 복사본은 파란색 그대로 유지됩니다:

![원본과 copyFrom 대상이 주황색 채우기로 표시되고, 고정 RGB 대상은 파란색 그대로 유지되는 모습](color-copy-after.png)

복사된 정의는 원본과 독립적이며, 이후 원본의 테마 참조를 변경하거나 다른 색을 할당하거나 변환을 추가·제거해도 대상에는 영향을 주지 않습니다. 그러나 두 도형이 동일한 테마 색을 각각 참조하고 있기 때문에 테마가 변경되면 두 도형 모두 영향을 받습니다.

프레젠테이션을 저장하고 다시 열면 [IColorFormat.getColorType](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/#getColorType--)이 반환하는 색상 유형, 테마 참조 및 [IColorFormat.getColorTransform](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/#getColorTransform--)이 반환하는 변환 컬렉션이 보존됩니다. 정의가 RGB로 평탄화되지 않으므로 테마 변경 시에도 올바른 색상 적용이 유지됩니다.

다른 테마 컨텍스트(예: 강조 색 팔레트가 다른 프레젠테이션) 간에 복사할 경우, 복사된 참조는 대상의 테마에 따라 해석됩니다. 같은 참조와 변환이 다른 눈에 보이는 색상을 만들 수 있습니다. 자세한 내용은 [Presentation Theme](/slides/ko/java/presentation-theme/)을 참고하십시오.

## **슬라이드 배경을 도형 채우기로 사용**

슬라이드 배경과 일치하도록 도형을 설정하려면 [IAutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#setUseBackgroundFill-boolean-)을 사용합니다. 먼저 [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-)을 [FillType.NotDefined](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/)으로 설정하여 명시적 채우기를 제거합니다. 이렇게 하면 도형이 슬라이드 배경을 자체 채우기 대신 사용합니다. 플래그만 활성화해도 기존 명시적 채우기는 제거되지 않습니다.

이는 [FillType.NoFill](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/)과 다릅니다. 배경 채우기는 도형 뒤의 객체를 슬라이드 배경 영역으로 가리며, 무채우기는 해당 객체를 그대로 보이게 합니다. 그라디언트는 슬라이드에 맞춰 정렬되고 각 도형 내부에서 다시 시작되지 않습니다.

다음 예제는 슬라이드가 상속하는 마스터 배경을 만들고, 세 직사각형 뒤에 마젠타 색 밴드를 배치합니다. 왼쪽 직사각형은 배경을 사용하고, 가운데 직사각형은 무채우기, 오른쪽 직사각형은 배경 채우기에서 명시적 주황색 채우기로 전환합니다.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    // 마스터에서 그라디언트를 상속합니다.
    slide.getBackground().setType(BackgroundType.NotDefined);
    slide.getLayoutSlide().getBackground().setType(BackgroundType.NotDefined);
    IBackground background = slide.getLayoutSlide().getMasterSlide().getBackground();
    background.setType(BackgroundType.OwnBackground);
    background.getFillFormat().setFillType(FillType.Gradient);
    IGradientFormat gradient = background.getFillFormat().getGradientFormat();
    gradient.setGradientShape(GradientShape.Linear);
    gradient.setLinearGradientAngle(0);
    gradient.getGradientStops().clear();
    gradient.getGradientStops().add(0, new Color(0, 0, 139));
    gradient.getGradientStops().add(1, new Color(135, 206, 250));

    // 이 객체를 먼저 추가하여 사각형 뒤에 표시됩니다.
    IAutoShape band = slide.getShapes().addAutoShape(ShapeType.Rectangle, 25, 150, 670, 100);
    band.getFillFormat().setFillType(FillType.Solid);
    band.getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    IAutoShape backgroundShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 100, 160, 200);
    backgroundShape.getFillFormat().setFillType(FillType.NotDefined);
    backgroundShape.setUseBackgroundFill(true);

    IAutoShape noFillShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 280, 100, 160, 200);
    noFillShape.getFillFormat().setFillType(FillType.NoFill);

    IAutoShape explicitShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 510, 100, 160, 200);
    explicitShape.getFillFormat().setFillType(FillType.NotDefined);
    explicitShape.setUseBackgroundFill(true);

    // 명시적 채우기를 적용하기 전에 배경 채우기를 비활성화합니다.
    explicitShape.setUseBackgroundFill(false);
    explicitShape.getFillFormat().setFillType(FillType.Solid);
    explicitShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));

    presentation.save("background_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과(왼쪽에서 오른쪽 순): **배경 채우기**, **무채우기**, **명시적 채우기**. 마젠타 밴드는 왼쪽과 오른쪽 직사각형에 가려지지만 가운데 직사각형을 통해 보입니다.

![마젠타 밴드 위에 배경 채우기, 무채우기 및 명시적 주황색 채우기가 적용된 모습](background-fill.png)

동일한 동작은 슬라이드에 직접 정의된 배경이나 레이아웃에서 상속된 배경에도 적용됩니다. 도형은 슬라이드의 최종 배경을 사용하며, 예제에서는 슬라이드와 레이아웃 배경을 모두 정의하지 않아 마스터가 제공하도록 했습니다.

## **투명도 설정**

단색 채우기의 경우 색상의 알파 구성 요소가 불투명도를 제어합니다: 0은 완전 투명, 255는 완전 불투명합니다. 이 예제는 알파 값을 128로 설정하여 노란색 직사각형을 약 50% 투명하게 만들며, 아래에 있는 직사각형이 보이도록 합니다. 색상은 [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--)을 통해 할당됩니다.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 128));

    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![투명한 도형](shape-transparency.png)

## **도형 회전**

[IShape.setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setRotation-float-)을 사용하여 슬라이드 평면에서 도형을 회전합니다. 각도는 도 단위이며 시계 방향입니다; 이 예제는 직사각형을 5도 시계 방향으로 회전하고 프레젠테이션을 저장합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.setRotation(5);

    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![도형 회전](shape-rotation.png)

## **3D 베벨 효과 추가**

[IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--)을 사용하면 도형에 깊이와 베벨 가장자리를 부여할 수 있습니다. 이 예제는 녹색 타원을 만들고 주황색 윤곽선을 지정한 뒤, [IThreeDFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setDepth-double-)으로 깊이를 4포인트로 설정하고, [IThreeDFormat.getBevelTop](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getBevelTop--)을 통해 폭과 높이가 6포인트인 원형 상단 베벨을 적용합니다. 정면 직교 카메라와 삼점 조명이 베벨을 가시화합니다.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(0, 128, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));
    shape.getLineFormat().setWidth(2.0);
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![3D 베벨 효과](3D-bevel-effect.png)

## **3D 회전 효과 추가**

도형의 3D 뷰는 카메라 설정으로 제어됩니다. 이 예제는 [ICamera.setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setRotation-float-float-float-)을 사용하여 위도, 경도 및 회전 각도를 각각 40°, 35°, 20°로 설정합니다. [ICamera.setCameraType](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setCameraType-int-)을 통해 등축 카메라를 선택하고, [ILightRig.setLightType](https://reference.aspose.com/slides/java/com.aspose.slides/ilightrig/#setLightType-int-)를 사용해 균형 조명을 적용한 뒤 형식이 지정된 직사각형을 저장합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![3D 회전 효과](3D-rotation-effect.png)

## **도형의 흑백 렌더링 제어**

[IShape.setBlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) 메서드는 프레젠테이션이 흑백 모드로 표시되거나 처리될 때 개별 도형이 어떻게 렌더링되는지를 지정합니다. 이 메서드만으로 흑백 표시가 활성화되는 것은 아니며, 일반 색상 모드에서는 도형의 채우기, 윤곽선 또는 기타 서식을 변경하지도 않습니다.

[BlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/blackwhitemode/) 클래스의 값을 사용하여 원하는 동작을 선택합니다. 예를 들어 `Automatic`은 렌더링 애플리케이션이 변환을 선택하도록 하고, `Gray`와 `LightGray`는 회색 색상을 사용하며, `BlackWhite`는 흑백만 사용하고, `Black`와 `White`는 단일 색상을 강제하고, `Color`는 일반 색상을 유지하며, `Hidden`은 흑백 모드에서 도형을 생략합니다. `NotDefined`는 도형 수준 모드가 지정되지 않았음을 의미합니다.

이 예제는 주황색 직사각형을 만들고 [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-)을 사용해 모드를 회색으로 설정합니다. 저장된 도형은 일반 색상 표시에서는 주황색 채우기를 유지하고, 흑백 표시를 지원하는 애플리케이션에서는 회색 색상을 요청합니다.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

일반 색상 모드에서는 직사각형이 주황색 채우기를 유지합니다. 흑백 표시 워크플로에서는 모드가 `Gray`로 설정되어 있기 때문에 회색 색상이 사용됩니다. 이를 통해 전체 색상 슬라이드를 유지하면서 인쇄, 미리 보기 또는 흑백 표시 설정을 지원하는 워크플로에 대해 별도 외관을 정의할 수 있습니다.

## **형식 재설정**

[ISlide.reset](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#reset--)을 사용하면 레이아웃 자리표시자와 연결된 슬라이드 자리표시자의 위치, 크기 및 서식을 복원합니다. 이 예제는 레이아웃에 연결된 자리표시자가 있는 기존 프레젠테이션이 필요하며, 저장 전에 모든 슬라이드를 재설정합니다. 대응하는 레이아웃 자리표시자가 없는 도형은 재설정되지 않습니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        slide.reset();
    }

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**도형 서식이 최종 프레젠테이션 파일 크기에 영향을 줍니까?**

색상, 선 스타일 및 효과 설정은 일반적으로 삽입된 이미지와 미디어에 비해 데이터가 거의 추가되지 않습니다. 그림 채우기는 이미지가 프레젠테이션에 저장되므로 파일 크기가 증가할 수 있습니다.

**동일한 서식을 공유하는 슬라이드의 도형을 감지하여 그룹화하려면 어떻게 해야 합니까?**

각 도형의 핵심 서식 속성(채우기, 선, 효과 설정)을 비교하십시오. 모든 해당 값이 일치하면 스타일을 동일하게 간주하고 해당 도형을 논리적으로 그룹화하면 이후 스타일 관리가 간소화됩니다.

**맞춤 도형 스타일 세트를 별도 파일에 저장하여 다른 프레젠테이션에서 재사용할 수 있습니까?**

예. 원하는 스타일이 적용된 샘플 도형을 템플릿 슬라이드 파일(.POTX)이나 슬라이드 데크에 저장합니다. 새 프레젠테이션을 만들 때 템플릿을 열고 필요한 스타일이 적용된 도형을 복제한 뒤 필요한 곳에 서식을 다시 적용합니다.