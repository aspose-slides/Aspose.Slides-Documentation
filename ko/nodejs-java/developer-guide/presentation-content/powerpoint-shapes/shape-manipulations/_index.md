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
- Interop 도형 ID 가져오기
- 도형 대체 텍스트
- 도형 레이아웃 형식
- SVG 도형
- 도형을 SVG로
- 도형 정렬
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript와 Aspose.Slides for Node.js via Java를 사용하여 도형을 만들고, 편집하고, 최적화하며 고성능 PowerPoint 프레젠테이션을 제공하는 방법을 배웁니다."
---
## **개요**

이 문서는 Aspose.Slides를 사용하여 프레젠테이션에서 도형을 작업하는 방법을 설명합니다. 슬라이드에서 도형을 찾고, 복제하고, 제거하고, 숨기고, 순서를 변경하고, Interop 도형 ID를 가져오며, 식별 및 추가 처리를 위해 대체 텍스트를 설정하는 방법을 보여줍니다.

또한 도형의 레이아웃 형식에 접근하는 방법, 도형을 SVG로 렌더링하는 방법, 슬라이드에서 도형을 정렬하는 방법, 수평 및 수직 미러링을 위한 플립 속성을 사용하는 방법을 다룹니다. 마지막으로 도형 결합, 쌓기 순서, 도형 잠금에 관한 간단한 FAQ도 포함되어 있습니다.

## **슬라이드에서 도형 찾기**
이 항목에서는 개발자가 내부 Id를 사용하지 않고 슬라이드에서 특정 도형을 찾는 간단한 기술을 설명합니다. PowerPoint 프레젠테이션 파일은 내부 고유 Id 외에 슬라이드에서 도형을 식별할 방법이 없습니다. 내부 고유 Id를 사용해 도형을 찾는 것은 개발자에게 어려울 수 있습니다. 슬라이드에 추가된 모든 도형에는 일부 대체 텍스트가 있습니다. 우리는 개발자에게 특정 도형을 찾기 위해 대체 텍스트를 사용할 것을 권장합니다. 향후 변경할 객체에 대한 대체 텍스트는 MS PowerPoint에서 정의할 수 있습니다.

원하는 도형의 대체 텍스트를 설정한 후, Aspose.Slides for Node.js via Java를 사용해 해당 프레젠테이션을 열고 슬라이드에 추가된 모든 도형을 반복합니다. 각 반복에서 도형의 대체 텍스트를 확인하고, 일치하는 대체 텍스트를 가진 도형이 필요한 도형이 됩니다. 이 기술을 더 잘 보여주기 위해, 슬라이드에서 특정 도형을 찾아 반환하는 메서드 [findShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SlideUtil#findShape-aspose.slides.IBaseSlide-java.lang.String-)을 만들었습니다.

```javascript
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
var pres = new aspose.slides.Presentation("FindingShapeInSlide.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    // 찾고자 하는 도형의 대체 텍스트
    var shape = findShape(slide, "Shape1");
    if (shape != null) {
        console.log("Shape Name: " + shape.getName());
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
```javascript
function findShape(slide, altText) {
    let shapes = slide.getShapes();
    
    for (let i = 0; i < shapes.size(); i++) {
        let shape = shapes.get_Item(i);
        
        if (shape.getAlternativeText() === altText) {
            return shape;
        }
    }

    return null;
}
```

## **도형 복제**
Aspose.Slides for Node.js via Java를 사용하여 슬라이드에 도형을 복제하려면:

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
1. 인덱스를 사용해 슬라이드 참조를 얻습니다.
1. 원본 슬라이드의 도형 컬렉션에 접근합니다.
1. 프레젠테이션에 새 슬라이드를 추가합니다.
1. 원본 슬라이드 도형 컬렉션에서 새 슬라이드로 도형을 복제합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예제는 슬라이드에 그룹 도형을 추가합니다.

```javascript
// Presentation 클래스를 인스턴스화합니다
var pres = new aspose.slides.Presentation("Source Frame.pptx");
try {
    var sourceShapes = pres.getSlides().get_Item(0).getShapes();
    var blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank);
    var destSlide = pres.getSlides().addEmptySlide(blankLayout);
    var destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);
    // PPTX 파일을 디스크에 저장합니다
    pres.save("CloneShape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **도형 제거**
Aspose.Slides for Node.js via Java는 개발자가 모든 도형을 제거할 수 있도록 합니다. 슬라이드에서 도형을 제거하려면 아래 단계를 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
1. 첫 번째 슬라이드에 접근합니다.
1. 특정 AlternativeText를 가진 도형을 찾습니다.
1. 도형을 제거합니다.
1. 파일을 디스크에 저장합니다.

```javascript
// Presentation 객체를 생성합니다
var pres = new aspose.slides.Presentation();
try {
    // 첫 번째 슬라이드를 가져옵니다
    var sld = pres.getSlides().get_Item(0);
    // 사각형 유형의 자동 도형을 추가합니다
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    var altText = "User Defined";
    var iCount = sld.getShapes().size();
    for (var i = 0; i < iCount; i++) {
        var ashp = sld.getShapes().get_Item(0);
        if (alttext === ashp.getAlternativeText()) {
            sld.getShapes().remove(ashp);
        }
    }
    // 프레젠테이션을 디스크에 저장합니다
    pres.save("RemoveShape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **도형 숨기기**
Aspose.Slides for Node.js via Java는 개발자가 모든 도형을 숨길 수 있도록 합니다. 슬라이드에서 도형을 숨기려면 아래 단계를 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
1. 첫 번째 슬라이드에 접근합니다.
1. 특정 AlternativeText를 가진 도형을 찾습니다.
1. 도형을 숨깁니다.
1. 파일을 디스크에 저장합니다.

```javascript
// PPTX를 나타내는 Presentation 클래스를 인스턴스화합니다
var pres = new aspose.slides.Presentation();
try {
    // 첫 번째 슬라이드를 가져옵니다
    var sld = pres.getSlides().get_Item(0);
    // 사각형 유형의 자동 도형을 추가합니다
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    var alttext = "User Defined";
    var iCount = sld.getShapes().size();
    for (var i = 0; i < iCount; i++) {
        var ashp = sld.getShapes().get_Item(i);
        if (alttext === ashp.getAlternativeText()) {
            ashp.setHidden(true);
        }
    }
    // 프레젠테이션을 디스크에 저장합니다
    pres.save("Hiding_Shapes_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **도형 순서 변경**
Aspose.Slides for Node.js via Java는 개발자가 도형의 순서를 변경할 수 있도록 합니다. 도형 순서를 변경하면 어떤 도형이 앞에, 어떤 도형이 뒤에 있는지를 지정합니다. 슬라이드에서 도형 순서를 변경하려면 아래 단계를 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
1. 첫 번째 슬라이드에 접근합니다.
1. 도형을 추가합니다.
1. 도형의 텍스트 프레임에 텍스트를 입력합니다.
1. 동일한 좌표에 또 다른 도형을 추가합니다.
1. 도형 순서를 재조정합니다.
1. 파일을 디스크에 저장합니다.

```javascript
var pres = new aspose.slides.Presentation("ChangeShapeOrder.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var shp3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 365, 400, 150);
    shp3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shp3.addTextFrame(" ");
    var para = shp3.getTextFrame().getParagraphs().get_Item(0);
    var portion = para.getPortions().get_Item(0);
    portion.setText("Watermark Text Watermark Text Watermark Text");
    shp3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Triangle, 200, 365, 400, 150);
    slide.getShapes().reorder(2, shp3);
    pres.save("Reshape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Interop 도형 ID 가져오기**
Aspose.Slides for Node.js via Java는 개발자가 슬라이드 범위 내에서 고유 도형 식별자를 가져올 수 있게 합니다. 이는 프레젠테이션 범위에서 고유 식별자를 가져오는 [getUniqueId](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Shape#getUniqueId--) 메서드와 대비됩니다. [Shape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Shape) 클래스에 추가된 메서드 [getOfficeInteropShapeId](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Shape#getOfficeInteropShapeId--)는 Microsoft.Office.Interop.PowerPoint.Shape 객체의 Id 값에 해당합니다. 아래에 샘플 코드가 제공됩니다.

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // 슬라이드 범위 내 고유 도형 식별자 가져오기
    var officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **도형에 대체 텍스트 설정**
Aspose.Slides for Node.js via Java는 개발자가 도형의 AlternateText를 설정할 수 있게 합니다. 프레젠테이션의 도형은 [AlternativeText](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Shape#setAlternativeText-java.lang.String-) 또는 [Shape Name](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Shape#setName-java.lang.String-) 메서드를 통해 구분될 수 있습니다. [setAlternativeText](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Shape#setAlternativeText-java.lang.String-)와 [getAlternativeText](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Shape#getAlternativeText--) 메서드는 Aspose.Slides와 Microsoft PowerPoint 모두에서 읽고 쓸 수 있습니다. 이 메서드를 사용하면 도형에 태그를 지정하고 도형 제거, 숨기기, 슬라이드에서 도형 재정렬과 같은 다양한 작업을 수행할 수 있습니다. 도형의 AlternateText를 설정하려면 아래 단계를 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
1. 첫 번째 슬라이드에 접근합니다.
1. 슬라이드에任意의 도형을 추가합니다.
1. 새로 추가된 도형을 사용해 작업을 수행합니다.
1. 도형을 순회하며 원하는 도형을 찾습니다.
1. AlternativeText를 설정합니다.
1. 파일을 디스크에 저장합니다.

```javascript
// PPTX를 나타내는 Presentation 클래스를 인스턴스화합니다
var pres = new aspose.slides.Presentation();
try {
    // 첫 번째 슬라이드를 가져옵니다
    var sld = pres.getSlides().get_Item(0);
    // 사각형 유형의 자동 도형을 추가합니다
    var shp1 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    var shp2 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    shp2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    for (var i = 0; i < sld.getShapes().size(); i++) {
        var shape = sld.getShapes().get_Item(i);
        if (shape != null) {
            shape.setAlternativeText("User Defined");
        }
    }
    // 프레젠테이션을 디스크에 저장합니다
    pres.save("Set_AlternativeText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **도형 레이아웃 형식 접근**
Aspose.Slides for Node.js via Java는 도형의 레이아웃 형식에 접근하기 위한 간단한 API를 제공합니다. 이 문서에서는 레이아웃 형식에 접근하는 방법을 시연합니다.

아래에 샘플 코드가 제공됩니다.

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    for (let i = 0; i < pres.getLayoutSlides().size(); i++) {
        let layoutSlide = pres.getLayoutSlides().get_Item(i);
        for (let j = 0; j < layoutSlide.getShapes().size(); j++) {
            let shape = layoutSlide.getShapes().get_Item(j);
            var fillFormats = shape.getFillFormat();
            var lineFormats = shape.getLineFormat();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **도형을 SVG로 렌더링**
이제 Aspose.Slides for Node.js via Java는 도형을 SVG로 렌더링하는 기능을 지원합니다. 메서드 [writeAsSvg](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Shape#writeAsSvg-java.io.OutputStream-) (및 오버로드 버전)가 [Shape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Shape) 클래스에 추가되었습니다. 이 메서드를 사용하면 도형 내용을 SVG 파일로 저장할 수 있습니다. 아래 코드 스니펫은 슬라이드 도형을 SVG 파일로 내보내는 방법을 보여줍니다.

```javascript
var pres = new aspose.slides.Presentation("TestExportShapeToSvg.pptx");
try {
    var stream = java.newInstanceSync("java.io.FileOutputStream", "SingleShape.svg");
    try {
        pres.getSlides().get_Item(0).getShapes().get_Item(0).writeAsSvg(stream);
    } finally {
        if (stream != null) {
            stream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **도형 정렬**
Aspose.Slides는 도형을 슬라이드 여백에 상대하거나 서로에 상대하여 정렬할 수 있게 합니다. 이를 위해 오버로드된 메서드 [SlidesUtil.alignShape()](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SlideUtil#alignShapes-int-boolean-aspose.slides.IBaseSlide-int:A-)가 추가되었습니다. [ShapesAlignmentType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ShapesAlignmentType) 열거형은 가능한 정렬 옵션을 정의합니다.

**예제 1**

아래 소스 코드는 인덱스 1, 2, 4인 도형을 슬라이드 상단 테두리에 맞춰 정렬합니다.

```javascript
var pres = new aspose.slides.Presentation("example.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var shape1 = slide.getShapes().get_Item(1);
    var shape2 = slide.getShapes().get_Item(2);
    var shape3 = slide.getShapes().get_Item(4);
    aspose.slides.SlideUtil.alignShapes(aspose.slides.ShapesAlignmentType.AlignTop, true, pres.getSlides().get_Item(0), java.newArray("int", [slide.getShapes().indexOf(shape1), slide.getShapes().indexOf(shape2), slide.getShapes().indexOf(shape3)]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

**예제 2**

아래 예제는 컬렉션에 포함된 모든 도형을 컬렉션 내 가장 아래에 있는 도형에 상대적으로 정렬하는 방법을 보여줍니다.

```javascript
var pres = new aspose.slides.Presentation("example.pptx");
try {
    aspose.slides.SlideUtil.alignShapes(aspose.slides.ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **플립 속성**

Aspose.Slides에서 [ShapeFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shapeframe/) 클래스는 `flipH`와 `flipV` 속성을 통해 도형의 수평 및 수직 미러링을 제어합니다. 두 속성은 `byte` 타입이며, `1`은 플립, `0`은 플립 없음, `-1`은 기본 동작을 사용함을 나타냅니다. 이러한 값은 도형의 [Frame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/#getFrame)에서 접근할 수 있습니다.

플립 설정을 수정하려면, 현재 위치와 크기, 원하는 `flipH`와 `flipV` 값, 회전 각도를 사용해 새로운 [ShapeFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shapeframe/) 인스턴스를 생성합니다. 이 인스턴스를 도형의 [Frame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/#getFrame)에 할당하고 프레젠테이션을 저장하면 미러 변환이 적용되어 출력 파일에 반영됩니다.

예를 들어, 첫 번째 슬라이드에 기본 플립 설정을 가진 단일 도형이 포함된 sample.pptx 파일이 있다고 가정합니다.

![플립될 도형](shape_to_be_flipped.png)

다음 코드 예제는 도형의 현재 플립 속성을 가져와 수평 및 수직으로 모두 플립합니다.

```js
var presentation = new asposeSlides.Presentation("sample.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    var shape = slide.getShapes().get_Item(0);

    // 도형의 수평 플립 속성을 가져옵니다.
    var horizontalFlip = shape.getFrame().getFlipH();
    console.log("Horizontal flip:", horizontalFlip);

    // 도형의 수직 플립 속성을 가져옵니다.
    var verticalFlip = shape.getFrame().getFlipV();
    console.log("Vertical flip:", verticalFlip);

    var x = java.newFloat(shape.getFrame().getX());
    var y = java.newFloat(shape.getFrame().getY());
    var width = java.newFloat(shape.getFrame().getWidth());
    var height = java.newFloat(shape.getFrame().getHeight());
    var flipH = java.newByte(asposeSlides.NullableBool.True); // Flip horizontally.
    var flipV = java.newByte(asposeSlides.NullableBool.True); // Flip vertically.
    var rotation = shape.getFrame().getRotation();

    shape.setFrame(new asposeSlides.ShapeFrame(x, y, width, height, flipH, flipV, rotation));

    presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![플립된 도형](flipped_shape.png)

## **FAQ**

**슬라이드에서 도형을 (합집합/교집합/차집합)처럼 데스크톱 편집기처럼 결합할 수 있나요?**

내장된 Boolean 연산 API는 없습니다. 원하는 윤곽을 직접 구성해 근사화할 수 있습니다—예를 들어 [GeometryPath](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/geometrypath/)를 사용해 결과 기하를 계산하고 해당 컨투어로 새 도형을 만든 뒤, 원본 도형을 선택적으로 제거합니다.

**도형이 항상 “맨 위”에 위치하도록 z‑order(쌓기 순서)를 제어하려면 어떻게 해야 하나요?**

슬라이드의 [shapes](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/baseslide/#getShapes) 컬렉션 내 삽입/이동 순서를 변경합니다. 예측 가능한 결과를 위해 다른 슬라이드 수정 작업을 모두 마친 뒤 z‑order를 최종 설정합니다.

**PowerPoint에서 사용자가 도형을 편집하지 못하도록 “잠그는” 방법이 있나요?**

예. 도형 수준 보호 플래그(선택 잠금, 이동 잠금, 크기 조정 잠금, 텍스트 편집 잠금 등)를 설정합니다. 필요하다면 마스터 또는 레이아웃에 제한을 적용할 수 있습니다. 이는 UI 수준 보호이며 보안 기능이 아닙니다; 더 강력한 보호가 필요하면 [읽기 전용 권장 사항 또는 암호](/slides/ko/nodejs-java/password-protected-presentation/)와 같은 파일 수준 제한과 결합하세요.