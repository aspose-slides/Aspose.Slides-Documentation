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
- 도형을 SVG로
- 도형을 SVG로 변환
- 도형 정렬
- PowerPoint
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java에서 도형을 생성, 편집 및 최적화하고 고성능 PowerPoint 프레젠테이션을 제공하는 방법을 배우세요."
---
## **개요**

이 문서는 Aspose.Slides를 사용하여 프레젠테이션에서 도형을 다루는 방법을 설명합니다. 슬라이드에서 도형을 찾고, 복제하고, 제거하고, 숨기고, 순서를 변경하고, Interop 도형 ID를 가져오며, 식별 및 추가 처리를 위해 대체 텍스트를 설정하는 방법을 보여줍니다.

또한 도형의 레이아웃 형식에 접근하는 방법, 도형을 SVG로 렌더링하는 방법, 슬라이드에서 도형을 정렬하는 방법, 수평 및 수직 미러링을 위한 플립 속성 사용 방법을 다룹니다. 마지막으로 도형 결합, 쌓기 순서, 도형 잠금에 관한 짧은 FAQ도 포함됩니다.

## **슬라이드에서 도형 찾기**
이 항목에서는 개발자가 내부 Id를 사용하지 않고도 특정 슬라이드에서 도형을 쉽게 찾을 수 있는 간단한 기술을 설명합니다. PowerPoint 프레젠테이션 파일에는 내부 고유 Id를 제외하고 슬라이드의 도형을 식별할 방법이 없습니다. 내부 고유 Id를 사용해 도형을 찾는 것이 개발자에게 어려울 수 있습니다. 모든 슬라이드에 추가된 도형에는 일부 Alt Text가 있습니다. 우리는 개발자가 특정 도형을 찾기 위해 대체 텍스트를 사용할 것을 권장합니다. 향후 변경할 객체에 대한 대체 텍스트는 MS PowerPoint에서 정의할 수 있습니다.

원하는 도형의 대체 텍스트를 설정한 후, Aspose.Slides for Android via Java를 사용해 해당 프레젠테이션을 열고 슬라이드에 추가된 모든 도형을 순회하면 됩니다. 각 순회 단계에서 도형의 대체 텍스트를 확인하고, 일치하는 대체 텍스트를 가진 도형이 바로 필요한 도형이 됩니다. 이 기술을 더 쉽게 보여 주기 위해, 슬라이드에서 특정 도형을 찾아 반환하는 메서드 [findShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-)를 작성했습니다.

```java
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation("FindingShapeInSlide.pptx");
try {

    ISlide slide = pres.getSlides().get_Item(0);
    // 찾을 도형의 대체 텍스트
    IShape shape = findShape(slide, "Shape1");
    if (shape != null)
    {
        System.out.println("Shape Name: " + shape.getName());
    }
} finally {
    if (pres != null) pres.dispose();
}
```
```java
// 대체 텍스트를 사용하여 슬라이드에서 도형을 찾는 메서드 구현
public static IShape findShape(ISlide slide, String alttext)
{
    // 슬라이드 내 모든 도형을 반복합니다
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        // 슬라이드의 대체 텍스트가 요구하는 텍스트와 일치하면
        // 도형을 반환합니다
        if (slide.getShapes().get_Item(i).getAlternativeText().compareTo(alttext) == 0)
            return slide.getShapes().get_Item(i);
    }
    return null;
}
```

## **도형 복제**
Aspose.Slides for Android via Java를 사용하여 슬라이드에 도형을 복제하려면:

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
1. 인덱스를 사용해 슬라이드의 참조를 얻습니다.
1. 원본 슬라이드의 도형 컬렉션에 접근합니다.
1. 프레젠테이션에 새 슬라이드를 추가합니다.
1. 원본 슬라이드 도형 컬렉션에서 새 슬라이드로 도형을 복제합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예제는 슬라이드에 그룹 도형을 추가합니다.

```java
// Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation("Source Frame.pptx");
try {
    IShapeCollection sourceShapes = pres.getSlides().get_Item(0).getShapes();
    ILayoutSlide blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);
    ISlide destSlide = pres.getSlides().addEmptySlide(blankLayout);
    IShapeCollection destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);

    // PPTX 파일을 디스크에 저장합니다
    pres.save("CloneShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **도형 제거**
Aspose.Slides for Android via Java를 사용하면 개발자가 모든 도형을 제거할 수 있습니다. 슬라이드에서 도형을 제거하려면 다음 단계를 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
1. 첫 번째 슬라이드에 접근합니다.
1. 특정 AlternativeText를 가진 도형을 찾습니다.
1. 도형을 제거합니다.
1. 파일을 디스크에 저장합니다.

```java
// Presentation 객체를 생성합니다
Presentation pres = new Presentation();
try {
    // 첫 번째 슬라이드를 가져옵니다
    ISlide sld = pres.getSlides().get_Item(0);

    // 사각형 타입의 자동 도형을 추가합니다
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String altText = "User Defined";
    int iCount = sld.getShapes().size();
    for (int i = 0; i < iCount; i++)
    {
        AutoShape ashp = (AutoShape)sld.getShapes().get_Item(0);
        if (alttext.equals(ashp.getAlternativeText()))
        {
            sld.getShapes().remove(ashp);
        }
    }

    // 프레젠테이션을 디스크에 저장합니다
    pres.save("RemoveShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **도형 숨기기**
Aspose.Slides for Android via Java를 사용하면 개발자가 모든 도형을 숨길 수 있습니다. 슬라이드에서 도형을 숨기려면 다음 단계를 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
1. 첫 번째 슬라이드에 접근합니다.
1. 특정 AlternativeText를 가진 도형을 찾습니다.
1. 도형을 숨깁니다.
1. 파일을 디스크에 저장합니다.

```java
// PPTX를 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation();
try {
    // 첫 번째 슬라이드를 가져옵니다
    ISlide sld = pres.getSlides().get_Item(0);

    // 사각형 타입 자동 도형을 추가합니다
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String alttext = "User Defined";
    int iCount = sld.getShapes().size();
    for (int i = 0; i < iCount; i++)
    {
        AutoShape ashp = (AutoShape)sld.getShapes().get_Item(i);
        if (alttext.equals(ashp.getAlternativeText()))
        {
            ashp.setHidden(true);
        }
    }

    // 프레젠테이션을 디스크에 저장합니다
    pres.save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **도형 순서 변경**
Aspose.Slides for Android via Java를 사용하면 개발자가 도형 순서를 재배치할 수 있습니다. 도형 순서를 재배치하면 어떤 도형이 앞에, 어떤 도형이 뒤에 있는지를 지정할 수 있습니다. 슬라이드에서 도형 순서를 변경하려면 다음 단계를 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
1. 첫 번째 슬라이드에 접근합니다.
1. 도형을 추가합니다.
1. 도형의 텍스트 프레임에 텍스트를 입력합니다.
1. 동일한 좌표에 또 다른 도형을 추가합니다.
1. 도형 순서를 재배치합니다.
1. 파일을 디스크에 저장합니다.

```java
Presentation pres = new Presentation("ChangeShapeOrder.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape shp3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 365, 400, 150);
    shp3.getFillFormat().setFillType(FillType.NoFill);
    shp3.addTextFrame(" ");

    IParagraph para = shp3.getTextFrame().getParagraphs().get_Item(0);
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("Watermark Text Watermark Text Watermark Text");

    shp3 = slide.getShapes().addAutoShape(ShapeType.Triangle, 200, 365, 400, 150);

    slide.getShapes().reorder(2, shp3);

    pres.save("Reshape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Interop 도형 ID 가져오기**
Aspose.Slides for Android via Java를 사용하면 슬라이드 범위에서 고유한 도형 식별자를 가져올 수 있습니다. 이는 프레젠테이션 전체 범위에서 고유 식별자를 제공하는 [getUniqueId](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IShape#getUniqueId--) 메서드와 대비됩니다. 메서드 [getOfficeInteropShapeId](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IShape#getOfficeInteropShapeId--)는 [IShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IShape) 인터페이스와 [Shape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Shape) 클래스에 각각 추가되었습니다. [getOfficeInteropShapeId](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IShape#getOfficeInteropShapeId--) 메서드가 반환하는 값은 Microsoft.Office.Interop.PowerPoint.Shape 객체의 Id 값에 해당합니다. 아래에 샘플 코드가 제공됩니다.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // 슬라이드 범위에서 고유 도형 식별자 가져오기
    long officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();

} finally {
    if (pres != null) pres.dispose();
}
```

## **도형에 대체 텍스트 설정**
Aspose.Slides for Android via Java를 사용하면 개발자가 任意의 도형에 AlternateText를 설정할 수 있습니다. 프레젠테이션의 도형은 [AlternativeText](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) 또는 [Shape Name](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IShape#setName-java.lang.String-) 메서드를 통해 구분될 수 있습니다. [setAlternativeText](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) 및 [getAlternativeText](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IShape#getAlternativeText--) 메서드는 Aspose.Slides와 Microsoft PowerPoint 모두에서 읽거나 설정할 수 있습니다. 이 메서드를 사용하면 도형에 태그를 달아 도형 제거, 도형 숨기기, 슬라이드에서 도형 순서 재배치와 같은 다양한 작업을 수행할 수 있습니다. 도형의 AlternateText를 설정하려면 다음 단계를 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
1. 첫 번째 슬라이드에 접근합니다.
1. 슬라이드에 任意의 도형을 추가합니다.
1. 새로 추가된 도형으로 작업을 수행합니다.
1. 도형들을 순회하여 원하는 도형을 찾습니다.
1. AlternativeText를 설정합니다.
1. 파일을 디스크에 저장합니다.

```java
// PPTX를 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation();
try {
    // 첫 번째 슬라이드를 가져옵니다
    ISlide sld = pres.getSlides().get_Item(0);

    // 사각형 타입 자동 도형을 추가합니다
    IShape shp1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    IShape shp2 = sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);
    shp2.getFillFormat().setFillType(FillType.Solid);
    shp2.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        AutoShape shape = (AutoShape) sld.getShapes().get_Item(i);
        if (shape != null)
        {
            shape.setAlternativeText("User Defined");
        }
    }

    // 프레젠테이션을 디스크에 저장합니다
    pres.save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **도형에 대한 레이아웃 형식 접근**
Aspose.Slides for Android via Java는 도형에 대한 레이아웃 형식에 접근하기 위한 간단한 API를 제공합니다. 이 문서에서는 레이아웃 형식에 접근하는 방법을 보여 줍니다.

아래에 샘플 코드가 제공됩니다.

```java
Presentation pres = new Presentation("pres.pptx");
try {
    for (ILayoutSlide layoutSlide : pres.getLayoutSlides())
    {
        for (IShape shape : layoutSlide.getShapes())
        {
            IFillFormat fillFormats = shape.getFillFormat();
            ILineFormat lineFormats = shape.getLineFormat();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **도형을 SVG로 렌더링**
이제 Aspose.Slides for Android via Java는 도형을 SVG로 렌더링하는 기능을 지원합니다. 메서드 [writeAsSvg](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IShape#writeAsSvg-java.io.OutputStream-) (및 오버로드 버전)이 [Shape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Shape) 클래스와 [IShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IShape) 인터페이스에 추가되었습니다. 이 메서드를 사용하면 도형의 내용을 SVG 파일로 저장할 수 있습니다. 아래 코드 조각은 슬라이드의 도형을 SVG 파일로 내보내는 방법을 보여 줍니다.

```java
Presentation pres = new Presentation("TestExportShapeToSvg.pptx");
try {
    FileOutputStream stream = new FileOutputStream("SingleShape.svg");
    try {
        pres.getSlides().get_Item(0).getShapes().get_Item(0).writeAsSvg(stream);
    } finally {
        if (stream != null) stream.close();
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **도형 정렬**
Aspose.Slides는 도형을 슬라이드 여백에 상대적으로 또는 서로에 상대적으로 정렬할 수 있습니다. 이를 위해 오버로드된 메서드 [SlidesUtil.alignShape()](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-)가 추가되었습니다. [ShapesAlignmentType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ShapesAlignmentType) 열거형은 가능한 정렬 옵션을 정의합니다.

**예제 1**

아래 소스 코드는 인덱스 1, 2, 4인 도형을 슬라이드 상단 경계에 정렬합니다.

```java
Presentation pres = new Presentation("example.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IShape shape1 = slide.getShapes().get_Item(1);
    IShape shape2 = slide.getShapes().get_Item(2);
    IShape shape3 = slide.getShapes().get_Item(4);
    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, true, pres.getSlides().get_Item(0), new int[]
    {
        slide.getShapes().indexOf(shape1),
        slide.getShapes().indexOf(shape2),
        slide.getShapes().indexOf(shape3)
    });
} finally {
    if (pres != null) pres.dispose();
}
}
```

**예제 2**

아래 예제는 컬렉션 전체를 컬렉션에서 가장 아래에 있는 도형에 상대적으로 정렬하는 방법을 보여 줍니다.

```java
Presentation pres = new Presentation("example.pptx");
try {
    SlideUtil.alignShapes(ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) pres.dispose();
}
```

## **플립 속성**

Aspose.Slides에서 [ShapeFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/shapeframe/) 클래스는 `flipH` 및 `flipV` 속성을 통해 도형의 수평 및 수직 미러링을 제어합니다. 두 속성 모두 `byte` 형식이며, `1`은 플립, `0`은 플립 없음, `-1`은 기본 동작을 사용함을 의미합니다. 이러한 값은 도형의 [Frame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishape/#getFrame--)에서 접근할 수 있습니다.

플립 설정을 수정하려면 현재 위치와 크기, 원하는 `flipH` 및 `flipV` 값, 회전 각도를 사용해 새로운 [ShapeFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/shapeframe/) 인스턴스를 구성합니다. 이 인스턴스를 도형의 [Frame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishape/#getFrame--)에 할당하고 프레젠테이션을 저장하면 미러 변환이 적용되고 출력 파일에 커밋됩니다.

예를 들어, 첫 번째 슬라이드에 기본 플립 설정을 가진 단일 도형이 포함된 sample.pptx 파일이 있다고 가정해 보겠습니다.

![플립될 도형](shape_to_be_flipped.png)

다음 코드 예제는 도형의 현재 플립 속성을 가져와 수평 및 수직으로 모두 플립합니다.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    // 도형의 수평 플립 속성을 가져옵니다.
    byte horizontalFlip = shape.getFrame().getFlipH();
    System.out.println("Horizontal flip: " + horizontalFlip);

    // 도형의 수직 플립 속성을 가져옵니다.
    byte verticalFlip = shape.getFrame().getFlipV();
    System.out.println("Vertical flip: " + verticalFlip);

    float x = shape.getFrame().getX();
    float y = shape.getFrame().getY();
    float width = shape.getFrame().getWidth();
    float height = shape.getFrame().getHeight();
    byte flipH = NullableBool.True; // Flip horizontally.
    byte flipV = NullableBool.True; // Flip horizontally.
    float rotation = shape.getFrame().getRotation();

    shape.setFrame(new ShapeFrame(x, y, width, height, flipH, flipV, rotation));

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![플립된 도형](flipped_shape.png)

## **FAQ**

**슬라이드에서 도형을 (합집합/교집합/차집합) 형태로 결합할 수 있나요?**

내장된 Boolean 연산 API는 없습니다. 원하는 외곽을 직접 구성하여 근사화할 수 있습니다—예를 들어 [GeometryPath](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/geometrypath/)를 사용해 결과 기하를 계산하고 해당 윤곽을 가진 새 도형을 만든 뒤 원본을 선택적으로 제거합니다.

**도형이 항상 “맨 위”에 있도록 쌓기 순서(z-order)를 제어하려면 어떻게 해야 하나요?**

슬라이드의 [shapes](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/baseslide/#getShapes--) 컬렉션 내에서 삽입/이동 순서를 변경합니다. 예측 가능한 결과를 위해 모든 다른 슬라이드 수정 작업이 끝난 후에 z-order를 최종 확정하는 것이 좋습니다.

**PowerPoint에서 사용자가 도형을 편집하지 못하도록 “잠그” 수 있나요?**

가능합니다. 도형 수준 보호 플래그(예: 선택 잠금, 이동 잠금, 크기 조정 잠금, 텍스트 편집 잠금)를 설정합니다. 필요에 따라 마스터 또는 레이아웃에 제한을 적용할 수도 있습니다. 이는 UI 수준 보호이며 보안 기능은 아닙니다. 더 강력한 보호를 원한다면 [읽기 전용 권장 사항 또는 암호](/slides/ko/androidjava/password-protected-presentation/)와 같은 파일 수준 제한을 함께 사용하십시오.