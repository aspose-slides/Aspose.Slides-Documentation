---
title: JavaScript에서 프레젠테이션의 도형 유효 속성 가져오기
linktitle: 유효 속성
type: docs
weight: 50
url: /ko/nodejs-java/shape-effective-properties/
keywords:
- 도형 속성
- 카메라 속성
- 라이트 릭
- 베벨 도형
- 텍스트 프레임
- 텍스트 스타일
- 글꼴 높이
- 채우기 서식
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js가 Java를 통해 정확한 PowerPoint 렌더링을 위해 도형 유효 속성을 계산하고 적용하는 방법을 알아보세요."
---
## **개요**

이 항목에서는 **local** 및 **effective** 속성의 차이점을 설명합니다. Local 값은 특정 서식 수준에서 직접 설정된 값으로, 예를 들어 다음과 같습니다:

1. 슬라이드의 구역 속성.
1. 구역의 텍스트 프레임 도형에 해당하는 경우, 레이아웃 또는 마스터 슬라이드의 프로토타입 도형 텍스트 스타일.
1. 프레젠테이션의 전역 텍스트 설정.

Local 값은 어느 수준에서도 정의하거나 생략할 수 있습니다. Aspose.Slides가 최종 “렌더링된” 서식이 필요할 때는 상속 체인을 해결하고 **effective** 값을 반환합니다. 로컬 서식 객체에서 `getEffective` 메서드를 호출하면 이를 얻을 수 있습니다.

다음 예제는 Effective 값을 가져오는 방법을 보여줍니다. 첫 번째 슬라이드의 첫 번째 도형이 텍스트 프레임과 최소 하나의 구역을 가진 [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape/)이라고 가정합니다.

```javascript

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let localTextFrameFormat = shape.getTextFrame().getTextFrameFormat();
    let effectiveTextFrameFormat = localTextFrameFormat.getEffective();

    let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    let localPortionFormat = paragraph.getPortions().get_Item(0).getPortionFormat();
    let effectivePortionFormat = localPortionFormat.getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
Effective 서식 데이터는 상속이 적용된 후 계산된 현재 서식을 나타냅니다. 현재 구현에서는 일부 Effective 데이터 객체가 내부적으로 캐시될 수 있습니다. 상위 또는 상속된 서식을 변경한 후 다시 `getEffective`를 호출하면 캐시된 데이터가 새로 고쳐지고, 이전에 얻은 객체는 더 이상 이전 상태를 나타내지 않을 수 있습니다. 나중에 재사용하려면 글꼴 높이, 채우기 색, 글꼴 스타일 또는 정렬과 같은 필요한 속성을 복사하여 자체 데이터 객체에 보관하십시오.
{{% /alert %}}

## **카메라의 유효 속성 가져오기**

Aspose.Slides를 사용하면 카메라의 유효 속성을 가져올 수 있습니다. 유효 카메라 데이터 객체는 변경할 수 없는 카메라 속성을 포함하며, [ThreeDFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/threedformat/)에 대해 반환된 유효 값으로 노출됩니다.

다음 코드 샘플은 카메라의 유효 속성을 가져오는 방법을 보여줍니다. 첫 번째 슬라이드의 첫 번째 도형에 3D 서식이 적용되어 있다고 가정합니다.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let camera = threeDEffectiveData.getCamera();
    let cameraType = camera.getCameraType();
    let fieldOfViewAngle = camera.getFieldOfViewAngle();
    let zoom = camera.getZoom();

    console.log("= Effective camera properties =");
    console.log("Type: " + cameraType);
    console.log("Field of view: " + fieldOfViewAngle);
    console.log("Zoom: " + zoom);
} finally {
    presentation.dispose();
}
```

## **라이트 릭의 유효 속성 가져오기**

Aspose.Slides를 사용하면 라이트 릭의 유효 속성을 가져올 수 있습니다. 유효 라이트 릭 데이터 객체는 변경할 수 없는 라이트 릭 속성을 포함하며, [ThreeDFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/threedformat/)에 대해 반환된 유효 값으로 노출됩니다.

다음 코드 샘플은 라이트 릭의 유효 속성을 가져오는 방법을 보여줍니다. 첫 번째 슬라이드의 첫 번째 도형에 3D 서식이 적용되어 있다고 가정합니다.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let lightRig = threeDEffectiveData.getLightRig();
    let lightType = lightRig.getLightType();
    let direction = lightRig.getDirection();

    console.log("= Effective light rig properties =");
    console.log("Type: " + lightType);
    console.log("Direction: " + direction);
} finally {
    presentation.dispose();
}
```

## **베벨 형태의 유효 속성 가져오기**

Aspose.Slides를 사용하면 형태 베벨의 유효 속성을 가져올 수 있습니다. 유효 형태 베벨 데이터 객체는 형태에 대한 불변 얼굴-릴리프 속성을 포함하며, [ThreeDFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/threedformat/)에 대해 반환된 유효 값으로 노출됩니다.

다음 코드 샘플은 형태 상단 베벨의 유효 속성을 가져오는 방법을 보여줍니다. 첫 번째 슬라이드의 첫 번째 도형에 3D 서식이 적용되어 있다고 가정합니다.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let bevelTop = threeDEffectiveData.getBevelTop();
    let bevelType = bevelTop.getBevelType();
    let bevelWidth = bevelTop.getWidth();
    let bevelHeight = bevelTop.getHeight();

    console.log("= Effective shape's top face relief properties =");
    console.log("Type: " + bevelType);
    console.log("Width: " + bevelWidth);
    console.log("Height: " + bevelHeight);
} finally {
    presentation.dispose();
}
```

## **텍스트 프레임의 유효 속성 가져오기**

Aspose.Slides를 사용하면 텍스트 프레임의 유효 속성을 가져올 수 있습니다. 반환된 유효 데이터 객체는 텍스트 프레임 서식 속성을 포함합니다.

다음 코드 샘플은 텍스트 프레임 서식의 유효 속성을 가져오는 방법을 보여줍니다. 첫 번째 슬라이드의 첫 번째 도형이 텍스트 프레임을 가진 [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape/)이라고 가정합니다.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    let effectiveTextFrameFormat = textFrameFormat.getEffective();
    let anchoringType = effectiveTextFrameFormat.getAnchoringType();
    let autofitType = effectiveTextFrameFormat.getAutofitType();
    let textVerticalType = effectiveTextFrameFormat.getTextVerticalType();
    let marginLeft = effectiveTextFrameFormat.getMarginLeft();
    let marginTop = effectiveTextFrameFormat.getMarginTop();
    let marginRight = effectiveTextFrameFormat.getMarginRight();
    let marginBottom = effectiveTextFrameFormat.getMarginBottom();

    console.log("Anchoring type: " + anchoringType);
    console.log("Autofit type: " + autofitType);
    console.log("Text vertical type: " + textVerticalType);
    console.log("Margins");
    console.log("   Left: " + marginLeft);
    console.log("   Top: " + marginTop);
    console.log("   Right: " + marginRight);
    console.log("   Bottom: " + marginBottom);
} finally {
    presentation.dispose();
}
```

## **텍스트 스타일의 유효 속성 가져오기**

Aspose.Slides를 사용하면 텍스트 스타일의 유효 속성을 가져올 수 있습니다. 반환된 유효 데이터 객체는 텍스트 스타일 속성을 포함합니다.

다음 코드 샘플은 텍스트 스타일의 유효 속성을 가져오는 방법을 보여줍니다. 첫 번째 슬라이드의 첫 번째 도형이 텍스트 프레임을 가진 [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape/)이라고 가정합니다.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);
    let effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    let levelCount = 9;

    for (let levelIndex = 0; levelIndex < levelCount; levelIndex++) {
        let effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);
        let depth = effectiveStyleLevel.getDepth();
        let indent = effectiveStyleLevel.getIndent();
        let alignment = effectiveStyleLevel.getAlignment();
        let fontAlignment = effectiveStyleLevel.getFontAlignment();

        console.log("= Effective paragraph formatting for style level #" + levelIndex + " =");

        console.log("Depth: " + depth);
        console.log("Indent: " + indent);
        console.log("Alignment: " + alignment);
        console.log("Font alignment: " + fontAlignment);
    }
} finally {
    presentation.dispose();
}
```

## **유효 글꼴 높이 값 가져오기**

Aspose.Slides를 사용하면 유효 글꼴 높이를 가져올 수 있습니다. 다음 코드는 프레젠테이션 구조의 다양한 수준에서 로컬 글꼴 높이 값을 설정한 후 구역의 유효 글꼴 높이가 어떻게 변하는지 보여줍니다.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shapeType = aspose.slides.ShapeType.Rectangle;
    let autoShape = slide.getShapes().addAutoShape(shapeType, 100, 100, 400, 75, false);
    autoShape.addTextFrame("");

    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    let firstPortion = new aspose.slides.Portion("Sample text with first portion");
    let secondPortion = new aspose.slides.Portion(" and second portion.");

    paragraph.getPortions().add(firstPortion);
    paragraph.getPortions().add(secondPortion);

    let firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    let secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    let firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    let secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height just after creation:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting the presentation default font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting paragraph default font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    firstPortion.getPortionFormat().setFontHeight(55);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting portion #0 font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    secondPortion.getPortionFormat().setFontHeight(18);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting portion #1 font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    let saveFormat = aspose.slides.SaveFormat.Pptx;
    presentation.save("SetLocalFontHeightValues.pptx", saveFormat);
} finally {
    presentation.dispose();
}
```

## **표에 대한 유효 채우기 서식 가져오기**

Aspose.Slides를 사용하면 표의 여러 부분에 대한 유효 채우기 서식을 가져올 수 있습니다. 반환된 유효 데이터 객체는 채우기 서식 속성을 포함합니다. 셀 서식은 행 서식보다, 행 서식은 열 서식보다, 열 서식은 전체 표 서식보다 우선순위가 높습니다.

그 결과, 셀에 대한 유효 채우기 서식 속성이 표 셀을 그리는 데 사용됩니다. 다음 코드 샘플은 표의 다양한 부분에 대한 유효 채우기 서식을 가져오는 방법을 보여줍니다. 첫 번째 슬라이드의 첫 번째 도형이 [Table](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/table/)이라고 가정합니다.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let table = slide.getShapes().get_Item(0);

    let tableFormatEffective = table.getTableFormat().getEffective();
    let rowFormatEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    let columnFormatEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    let cellFormatEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    let tableFillFormatEffective = tableFormatEffective.getFillFormat();
    let rowFillFormatEffective = rowFormatEffective.getFillFormat();
    let columnFillFormatEffective = columnFormatEffective.getFillFormat();
    let cellFillFormatEffective = cellFormatEffective.getFillFormat();
} finally {
    presentation.dispose();
}
```

## **FAQ**

**`getEffective` 메서드는 스냅샷을 반환합니까?**

항상 그렇지는 않습니다. Effective 데이터는 상속이 적용된 후 계산된 서식을 나타내지만, 일부 Effective 데이터 객체는 내부적으로 캐시될 수 있습니다. 이후 `getEffective` 호출은 서식을 다시 계산하고 캐시된 데이터를 새로 고칠 수 있으므로, 이전에 얻은 객체를 영구적인 스냅샷으로 취급해서는 안 됩니다.

**언제 다시 유효 속성을 읽어야 합니까?**

로컬 서식, 상위 스타일, 레이아웃 서식, 마스터 서식 또는 프레젠테이션 수준 기본값을 변경한 후 `getEffective`를 다시 호출하십시오. 다음 호출은 서식 계층을 재평가하고 현재 유효 결과를 반환합니다.

**레이아웃/마스터 슬라이드를 변경하거나 제거하면 이미 가져온 유효 속성에 영향을 줍니까?**

예, 변경 내용은 다음 `getEffective` 호출 시 반영됩니다. 상위 서식 원본이 변경되거나 제거되면 이전에 얻은 유효 데이터는 오래될 수 있습니다. `getEffective`를 다시 호출하면 Aspose.Slides가 서식 트리를 재평가하고 글꼴, 색상, 크기 등의 값이 변경될 수 있습니다.

**유효 데이터 객체를 통해 값을 수정할 수 있습니까?**

아닙니다. 유효 데이터 객체는 계산된 값만 노출합니다. 로컬 서식 객체에서 변경하고 다시 유효 값을 얻어야 합니다.

**속성이 도형 수준, 레이아웃/마스터, 전역 설정 중 어디에도 설정되지 않은 경우 어떻게 됩니까?**

유효 값은 PowerPoint 및 Aspose.Slides 기본값을 포함하는 기본 메커니즘에 의해 결정됩니다. 해석된 값이 현재 유효 데이터의 일부가 됩니다.

**유효 글꼴 값만 보고 어느 수준에서 크기나 글꼴이 제공됐는지 알 수 있습니까?**

직접적으로는 알 수 없습니다. 유효 데이터는 최종 값을 반환합니다. 원본을 찾으려면 구역, 단락, 텍스트 프레임 및 레이아웃, 마스터, 프레젠테이션 수준의 텍스트 스타일에서 로컬 값을 확인하여 첫 번째 명시적 정의가 어디에 있는지 확인해야 합니다.

**왜 유효 값이 때때로 로컬 값과 동일해 보입니까?**

로컬 값이 최종 값이 된 경우(상위 레벨에서 상속이 필요 없었던 경우)에도 그렇게 보입니다. 이러한 경우 유효 값은 로컬 값과 일치합니다.

**언제 유효 속성을 사용하고 언제 로컬 속성만 사용해야 합니까?**

모든 상속이 적용된 후 “렌더링된” 결과가 필요한 경우(색상 정렬, 들여쓰기 또는 크기 등) 유효 데이터를 사용하십시오. 이후 서식 변경에 관계없이 해당 값을 보존해야 하면 필요한 속성을 복사해 자체 객체에 저장하십시오. 특정 레벨에서 서식을 변경하려면 로컬 속성을 수정하고 필요에 따라 유효 데이터를 다시 읽어 결과를 확인하십시오.