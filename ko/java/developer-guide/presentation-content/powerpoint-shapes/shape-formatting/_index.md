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
- 스케치 도형 선
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
- 3D 베벨 효과
- 3D 회전 효과
- 서식 초기화
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Java에서 PowerPoint 도형을 서식 지정하는 방법을 배우세요—PPT, PPTX 및 ODP 파일에 대해 정확하고 완전한 제어로 채우기, 선 및 효과 스타일을 설정합니다."
---
## **소개**

PowerPoint에서 슬라이드에 도형을 추가할 수 있습니다. 도형은 선으로 구성되어 있기 때문에 외곽선에 효과를 적용하거나 수정하여 서식을 지정할 수 있습니다. 또한 내부를 채우는 방식을 지정하여 도형을 포맷할 수 있습니다.

![형식 지정된 도형](format-shape-powerpoint.png)

Aspose.Slides for Java는 PowerPoint에서 사용할 수 있는 동일한 옵션을 사용하여 도형을 포맷할 수 있는 인터페이스와 메서드를 제공합니다.

## **선 서식 지정**

Aspose.Slides를 사용하면 도형에 사용자 정의 선 스타일을 지정할 수 있습니다. 절차는 다음과 같습니다:

1. [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
1. 슬라이드에 [IAutoShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iautoshape/)을 추가합니다.
1. 도형의 [line style](https://reference.aspose.com/slides/ko/java/com.aspose.slides/linestyle/)을 설정합니다.
1. 선 너비를 설정합니다.
1. 선의 [dash style](https://reference.aspose.com/slides/ko/java/com.aspose.slides/linedashstyle/)을 설정합니다.
1. 도형의 선 색상을 설정합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 코드는 사각형 `AutoShape`의 선을 포맷하는 방법을 보여 줍니다:

```java
import com.aspose.slides.*;
import java.awt.Color;

// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
Presentation presentation = new Presentation();
try {
    // 첫 번째 슬라이드를 가져옵니다.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle 유형의 자동 도형을 추가합니다.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // 사각형 도형의 채우기 색상을 설정합니다.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // 사각형 선에 서식을 적용합니다.
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // 사각형 선의 색상을 설정합니다.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // PPTX 파일을 디스크에 저장합니다.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![프레젠테이션의 서식이 지정된 선](formatted-lines.png)

## **도형 선에 스케치 효과 적용**

스케치 효과는 도형 선을 손으로 그린 것처럼 보이게 합니다. 선 설정에 접근하려면 [IShape.getLineFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/)을 사용하고, 스케치 설정에 접근하려면 [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ilineformat/)을 사용하며, [ISketchFormat.setSketchType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isketchformat/)을 사용해 [LineSketchType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/linesketchtype/) 열거형에서 값을 선택합니다.

다음 Java 코드는 [LineSketchType.Curved](https://reference.aspose.com/slides/ko/java/com.aspose.slides/linesketchtype/) 효과를 적용하고, 명시적으로 할당된 값을 읽으며, [LineSketchType.None](https://reference.aspose.com/slides/ko/java/com.aspose.slides/linesketchtype/)을 사용해 효과를 제거하는 방법을 보여 줍니다:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // 도형의 선 서식 및 스케치 서식에 접근합니다.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // 스케치 효과를 적용합니다.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // 도형에 직접 할당된 스케치 효과를 읽습니다.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // 스케치 효과를 제거합니다.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

[ISketchFormat.getSketchType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isketchformat/)이 반환하는 값은 도형에 직접 할당된 설정을 나타냅니다. 선 서식이 테마, 마스터 슬라이드 또는 레이아웃 슬라이드에서 상속될 수 있는 경우에는 [ILineFormat.getEffective](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ilineformat/)을 사용하고, [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ilineformateffectivedata/)에 접근한 다음 [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isketchformateffectivedata/)을 읽습니다. 유효 값은 상속이 해결된 후 실제 적용되는 서식을 반영합니다:

```java
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

다음은 세 가지 조인 타입 옵션입니다:

* 둥근
* 각진
* 베벨

PowerPoint에서는 기본적으로 두 선이 각도에서 연결될 때(**모서리** 등) **둥근** 설정을 사용합니다. 하지만 날카로운 각을 가진 도형을 그리는 경우 **각진** 옵션을 선호할 수 있습니다.

![프레젠테이션의 조인 스타일](join-style-powerpoint.png)

다음 Java 코드는 위 이미지와 같이 Miter, Bevel, Round 조인 타입 설정을 사용해 세 개의 사각형을 만든 예시를 보여 줍니다:

```java
import com.aspose.slides.*;
import java.awt.Color;

// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
Presentation presentation = new Presentation();
try {
    // 첫 번째 슬라이드를 가져옵니다.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle 유형의 자동 도형을 세 개 추가합니다.
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // 각 사각형 도형의 채우기 색상을 설정합니다.
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // 선 너비를 설정합니다.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // 각 사각형의 선 색상을 설정합니다.
    shape1.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape3.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // 조인 스타일을 설정합니다.
    shape1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shape2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shape3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // 각 사각형에 텍스트를 추가합니다.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // PPTX 파일을 디스크에 저장합니다.
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **그라디언트 채우기**

PowerPoint에서 그라디언트 채우기는 도형에 연속적인 색상 혼합을 적용할 수 있는 서식 옵션입니다. 예를 들어 두 개 이상의 색상을 사용해 하나가 서서히 다른 색으로 변하도록 할 수 있습니다.

Aspose.Slides를 사용해 도형에 그라디언트 채우기를 적용하는 방법은 다음과 같습니다:

1. [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
1. 슬라이드에 [IAutoShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iautoshape/)을 추가합니다.
1. 도형의 [FillType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/filltype/)을 `Gradient`로 설정합니다.
1. [IGradientFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/igradientformat/) 인터페이스가 제공하는 그라디언트 정지 컬렉션의 `add` 메서드를 사용해 원하는 두 색상과 위치를 추가합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 Java 코드는 타원에 그라디언트 채우기 효과를 적용하는 방법을 보여 줍니다:

```java
import com.aspose.slides.*;

// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
Presentation presentation = new Presentation();
try {
    // 첫 번째 슬라이드를 가져옵니다.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ellipse 유형의 자동 도형을 추가합니다.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // 타원에 그라디언트 서식을 적용합니다.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // 그라디언트 방향을 설정합니다.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // 두 개의 그라디언트 정지를 추가합니다.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // PPTX 파일을 디스크에 저장합니다.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![그라디언트 채우기가 적용된 타원](gradient-fill.png)

## **패턴 채우기**

PowerPoint에서 패턴 채우기는 두 가지 색상으로 구성된 디자인(점, 줄무늬, 교차 해치, 체크 등)을 도형에 적용할 수 있는 서식 옵션입니다. 패턴의 전경색과 배경색을 원하는 대로 지정할 수 있습니다.

Aspose.Slides는 45가지가 넘는 사전 정의된 패턴 스타일을 제공하여 도형의 시각적 매력을 높일 수 있습니다. 사전 정의된 패턴을 선택한 후에도 정확한 색상을 지정할 수 있습니다.

Aspose.Slides를 사용해 도형에 패턴 채우기를 적용하는 방법은 다음과 같습니다:

1. [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
1. 슬라이드에 [IAutoShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iautoshape/)을 추가합니다.
1. 도형의 [FillType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/filltype/)을 `Pattern`으로 설정합니다.
1. 사전 정의된 옵션 중에서 패턴 스타일을 선택합니다.
1. 패턴의 [Background Color](https://reference.aspose.com/slides/ko/java/com.aspose.slides/patternformat/#getBackColor--)를 설정합니다.
1. 패턴의 [Foreground Color](https://reference.aspose.com/slides/ko/java/com.aspose.slides/patternformat/#getForeColor--)를 설정합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 Java 코드는 사각형에 패턴 채우기를 적용하는 방법을 보여 줍니다:

```java
import com.aspose.slides.*;
import java.awt.Color;

// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
Presentation presentation = new Presentation();
try {
    // 첫 번째 슬라이드를 가져옵니다.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle 유형의 자동 도형을 추가합니다.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // FillType을 Pattern으로 설정합니다.
    shape.getFillFormat().setFillType(FillType.Pattern);

    // 패턴 스타일을 설정합니다.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // 패턴 배경색과 전경색을 설정합니다.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // PPTX 파일을 디스크에 저장합니다.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![패턴 채우기가 적용된 사각형](pattern-fill.png)

## **그림 채우기**

PowerPoint에서 그림 채우기는 이미지 파일을 도형 내부에 삽입하여 이미지가 도형의 배경이 되도록 하는 서식 옵션입니다.

Aspose.Slides를 사용해 도형에 그림 채우기를 적용하는 방법은 다음과 같습니다:

1. [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
1. 슬라이드에 [IAutoShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iautoshape/)을 추가합니다.
1. 도형의 [FillType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/filltype/)을 `Picture`로 설정합니다.
1. 그림 채우기 모드를 `Tile`(또는 다른 선호 모드)으로 설정합니다.
1. 사용하려는 이미지로부터 [IPPImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ippimage/) 객체를 생성합니다.
1. 해당 이미지를 `ISlidesPicture.setImage` 메서드에 전달합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음은 "lotus.png" 파일을 사용한 예시 이미지입니다:

![연꽃 그림](lotus.png)

다음 Java 코드는 그림을 사용해 도형을 채우는 방법을 보여 줍니다:

```java
import com.aspose.slides.*;

// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
Presentation presentation = new Presentation();
try {
    // 첫 번째 슬라이드를 가져옵니다.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle 유형의 자동 도형을 추가합니다.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // FillType을 Picture로 설정합니다.
    shape.getFillFormat().setFillType(FillType.Picture);

    // 그림 채우기 모드를 설정합니다.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // 이미지를 로드하고 프레젠테이션 리소스에 추가합니다.
    IImage image = Images.fromFile("lotus.png");
    IPPImage picture = presentation.getImages().addImage(image);
    image.dispose();

    // 그림을 설정합니다.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // PPTX 파일을 디스크에 저장합니다.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![그림 채우기가 적용된 도형](picture-fill.png)

### **텍스처로 타일 그림 사용**

타일 그림을 텍스처로 설정하고 타일링 동작을 사용자 정의하려면 [IPictureFillFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipicturefillformat/) 인터페이스와 [PictureFillFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/picturefillformat/) 클래스의 다음 메서드를 사용할 수 있습니다:

- [setPictureFillMode](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): `Tile` 또는 `Stretch` 모드를 설정합니다.
- [setTileAlignment](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): 도형 내 타일 정렬을 지정합니다.
- [setTileFlip](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): 타일을 수평, 수직 또는 동시에 뒤집을지 제어합니다.
- [setTileOffsetX](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): 도형 원점으로부터 타일의 가로 오프셋(포인트)을 설정합니다.
- [setTileOffsetY](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): 도형 원점으로부터 타일의 세로 오프셋(포인트)을 설정합니다.
- [setTileScaleX](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): 타일의 가로 비율을 백분율로 정의합니다.
- [setTileScaleY](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): 타일의 세로 비율을 백분율로 정의합니다.

다음 코드 샘플은 타일 그림 채우기가 적용된 사각형을 추가하고 타일 옵션을 구성하는 방법을 보여 줍니다:

```java
import com.aspose.slides.*;

// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
Presentation presentation = new Presentation();
try {
    // 첫 번째 슬라이드를 가져옵니다.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // 사각형 자동 도형을 추가합니다.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // 도형의 FillType을 Picture로 설정합니다.
    shape.getFillFormat().setFillType(FillType.Picture);

    // 이미지를 로드하고 프레젠테이션 리소스에 추가합니다.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // 이미지를 도형에 할당합니다.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // 그림 채우기 모드와 타일링 속성을 구성합니다.
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    // PPTX 파일을 디스크에 저장합니다.
    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![타일 옵션](tile-options.png)

## **단색 채우기**

PowerPoint에서 단색 채우기는 도형을 하나의 균일한 색상으로 채우는 서식 옵션입니다. 그라디언트, 텍스처 또는 패턴 없이 단순히 배경 색만 적용됩니다.

Aspose.Slides를 사용해 도형에 단색 채우기를 적용하려면 다음 단계를 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
1. 슬라이드에 [IAutoShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iautoshape/)을 추가합니다.
1. 도형의 [FillType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/filltype/)을 `Solid`로 설정합니다.
1. 원하는 채우기 색상을 도형에 지정합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 Java 코드는 슬라이드의 사각형에 단색 채우기를 적용하는 예시를 보여 줍니다:

```java
import com.aspose.slides.*;
import java.awt.Color;

// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
Presentation presentation = new Presentation();
try {
    // 첫 번째 슬라이드를 가져옵니다.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle 유형의 자동 도형을 추가합니다.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // FillType을 Solid로 설정합니다.
    shape.getFillFormat().setFillType(FillType.Solid);

    // 채우기 색상을 설정합니다.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // PPTX 파일을 디스크에 저장합니다.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![단색 채우기가 적용된 도형](solid-color-fill.png)

## **투명도 설정**

PowerPoint에서 도형에 단색, 그라디언트, 그림 또는 텍스처 채우기를 적용할 때 투명도 수준을 설정해 채우기의 불투명도를 조절할 수 있습니다. 투명도 값이 높을수록 도형이 더 투명해져 배경이나 하위 객체가 부분적으로 보이게 됩니다.

Aspose.Slides는 채우기에 사용되는 색상의 알파 값을 조정하여 투명도 수준을 설정할 수 있게 해 줍니다. 방법은 다음과 같습니다:

1. [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
1. 슬라이드에 [IAutoShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iautoshape/)을 추가합니다.
1. [FillType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/filltype/)을 `Solid`로 설정합니다.
1. `Color`를 사용해 투명도가 포함된 색상을 정의합니다(`alpha` 구성 요소가 투명도를 제어합니다).
1. 프레젠테이션을 저장합니다.

다음 Java 코드는 사각형에 투명 색채우기를 적용하는 예시를 보여 줍니다:

```java
import com.aspose.slides.*;
import java.awt.Color;

// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
Presentation presentation = new Presentation();
try {
    // 첫 번째 슬라이드를 가져옵니다.
    ISlide slide = presentation.getSlides().get_Item(0);

    // 단색 사각형 자동 도형을 추가합니다.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 단색 도형 위에 투명 사각형 자동 도형을 추가합니다.
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // PPTX 파일을 디스크에 저장합니다.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![투명도가 적용된 도형](shape-transparency.png)

## **도형 회전**

Aspose.Slides를 사용하면 PowerPoint 프레젠테이션에서 도형을 회전시킬 수 있습니다. 이는 특정 정렬이나 디자인 요구 사항에 맞게 시각 요소를 배치할 때 유용합니다.

슬라이드에서 도형을 회전시키려면 다음 단계를 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
1. 슬라이드에 [IAutoShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iautoshape/)을 추가합니다.
1. 도형의 회전 속성을 원하는 각도로 설정합니다.
1. 프레젠테이션을 저장합니다.

다음 Java 코드는 도형을 5도 회전시키는 방법을 보여 줍니다:

```java
import com.aspose.slides.*;

// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
Presentation presentation = new Presentation();
try {
    // 첫 번째 슬라이드를 가져옵니다.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle 유형의 자동 도형을 추가합니다.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 도형을 5도 회전합니다.
    shape.setRotation(5);

    // PPTX 파일을 디스크에 저장합니다.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![도형 회전](shape-rotation.png)

## **3D 베벨 효과 추가**

Aspose.Slides를 사용하면 [ThreeDFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/threedformat/) 속성을 구성하여 도형에 3D 베벨 효과를 적용할 수 있습니다.

도형에 3D 베벨 효과를 추가하려면 다음을 수행하십시오:

1. [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 클래스를 인스턴스화합니다.
1. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
1. 슬라이드에 [IAutoShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iautoshape/)을 추가합니다.
1. 도형의 [ThreeDFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/threedformat/)을 구성하여 베벨 설정을 정의합니다.
1. 프레젠테이션을 저장합니다.

다음 Java 코드는 도형에 3D 베벨 효과를 적용하는 예시를 보여 줍니다:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Presentation 클래스의 인스턴스를 생성합니다.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 슬라이드에 도형을 추가합니다.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE);
    shape.getLineFormat().setWidth(2.0);

    // 도형의 ThreeDFormat 속성을 설정합니다.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    // 프레젠테이션을 PPTX 파일로 저장합니다.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![3D 베벨 효과](3D-bevel-effect.png)

## **3D 회전 효과 추가**

Aspose.Slides를 사용하면 [ThreeDFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/threedformat/) 속성을 구성하여 도형에 3D 회전 효과를 적용할 수 있습니다.

도형에 3D 회전을 적용하려면:

1. [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
1. 슬라이드에 [IAutoShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iautoshape/)을 추가합니다.
1. [setCameraType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/icamera/#setCameraType-int-) 및 [setLightType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ilightrig/#setLightType-int-)을 사용해 3D 회전을 정의합니다.
1. 프레젠테이션을 저장합니다.

다음 Java 코드는 도형에 3D 회전 효과를 적용하는 예시를 보여 줍니다:

```java
import com.aspose.slides.*;

// Presentation 클래스의 인스턴스를 생성합니다.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    // 프레젠테이션을 PPTP 파일로 저장합니다.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![3D 회전 효과](3D-rotation-effect.png)

## **도형에 대한 흑백 렌더링 제어**

[IShape.setBlackWhiteMode](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) 메서드는 프레젠테이션을 흑백 모드로 보거나 처리할 때 개별 도형이 어떻게 렌더링되는지를 지정합니다. 이 메서드 자체가 흑백 표시를 활성화하는 것은 아니며, 일반 색상 모드에서 도형의 채우기, 선 또는 기타 서식을 변경하지도 않습니다.

[BlackWhiteMode](https://reference.aspose.com/slides/ko/java/com.aspose.slides/blackwhitemode/) 클래스의 값을 사용해 원하는 동작을 선택합니다. 예를 들어 `Automatic`은 렌더링 애플리케이션이 변환 방식을 결정하도록 하고, `Gray`와 `LightGray`는 회색으로, `BlackWhite`는 검은색과 흰색만, `Black`과 `White`는 단일 색으로, `Color`는 일반 색상을 유지하며, `Hidden`은 흑백 모드에서 도형을 생략합니다. `NotDefined`는 도형 수준에서 모드가 할당되지 않았음을 의미합니다.

다음 Java 코드는 색상이 있는 도형을 만들고 흑백 표시 모드에서 회색으로 보이게 합니다:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    // 컬러 모드에서는 주황색 채우기를 유지하고, 흑백 모드에서는 도형을 회색으로 렌더링합니다.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

일반 색상 모드에서는 사각형이 주황색 채우기를 유지합니다. 흑백 표시 워크플로에서는 모드가 `Gray`로 설정되어 있기 때문에 회색으로 렌더링됩니다. 이를 통해 전체 색상 슬라이드를 보존하면서 인쇄, 미리 보기 또는 프레젠테이션의 흑백 표시 설정을 따르는 다른 워크플로에 대해 별도의 외观을 정의할 수 있습니다.

## **서식 초기화**

다음 Java 코드는 슬라이드의 서식을 초기화하고 [LayoutSlide](https://reference.aspose.com/slides/ko/java/com.aspose.slides/layoutslide/)에 있는 모든 자리 표시자 도형의 위치, 크기 및 서식을 기본값으로 되돌리는 방법을 보여 줍니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // 슬라이드에 레이아웃 자리 표시자가 있는 각 도형을 재설정합니다.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**도형 서식이 최종 프레젠테이션 파일 크기에 영향을 줍니까?**

거의 영향을 주지 않습니다. 삽입된 이미지와 미디어가 파일 용량의 대부분을 차지하고, 색상, 효과, 그라디언트 등의 도형 매개변수는 메타데이터로 저장되어 거의 추가 용량을 차지하지 않습니다.

**같은 서식을 공유하는 도형을 어떻게 찾아서 그룹화할 수 있나요?**

각 도형의 핵심 서식 속성(채우기, 선, 효과 설정)을 비교합니다. 모든 해당 값이 일치하면 스타일이 동일하다고 판단하고 논리적으로 그룹화하면 이후 스타일 관리가 쉬워집니다.

**맞춤형 도형 스타일 세트를 별도 파일에 저장해 다른 프레젠테이션에서 재사용할 수 있나요?**

가능합니다. 원하는 스타일이 적용된 샘플 도형을 템플릿 슬라이드 덱이나 .POTX 템플릿 파일에 저장합니다. 새 프레젠테이션을 만들 때 템플릿을 열어 필요한 스타일 도형을 복제하고 필요한 곳에 서식을 다시 적용하면 됩니다.