---
title: JavaScript로 프레젠테이션에서 도형 실제 속성 가져오기
linktitle: 실제 속성
type: docs
weight: 50
url: /ko/nodejs-java/shape-effective-properties/
keywords:
- 도형 속성
- 카메라 속성
- 조명 장치
- 베벨 도형
- 텍스트 프레임
- 텍스트 스타일
- 글꼴 높이
- 채우기 형식
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint 프레젠테이션에서 로컬, 상속 및 실제 도형 형식을 구분하는 방법을 위해 Java를 통한 Node.js용 Aspose.Slides 사용법을 배웁니다."
---
## **로컬, 상속 및 실제 속성**

PowerPoint 형식은 여러 곳에서 올 수 있습니다. 개체에 직접 저장된 값은 **로컬 값**입니다. 해당 값이 설정되지 않으면 PowerPoint는 단락 기본값, 텍스트 스타일, 레이아웃 또는 마스터 슬라이드, 테마, 프레젠테이션 수준 기본값과 같은 상위 형식 원본을 확인합니다. 이러한 값은 **상속 값**입니다. 전체 계층 구조가 해결된 후 남는 값이 **실제 값**—개체를 렌더링하는 데 사용되는 값입니다.

예를 들어, 텍스트 부분은 자체 글꼴 높이를 정의하지 않을 수 있습니다. 해당 로컬 [getFontHeight](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/portionformat/#getFontHeight) 값은 `NaN`이며, 이는 "여기에 설정되지 않음"을 의미합니다. 이 부분은 단락, 프레젠테이션 기본 텍스트 스타일 또는 기타 적용 가능한 소스에서 높이를 상속받을 수 있습니다. 부분 형식에서 [getEffective](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/portionformat/#getEffective)를 호출하면 최종 해결된 높이가 반환됩니다.

다른 목적에 따라 두 종류의 형식 데이터를 사용하십시오:

- 값이 정의된 위치를 제어해야 할 때는 [PortionFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/portionformat/)과 같은 로컬 형식 개체를 읽거나 변경하십시오.
- 최종 렌더링 결과가 필요할 때는 [PortionFormat.getEffective](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/portionformat/#getEffective)에서 반환되는 **실제 데이터**를 읽으십시오. 실제 데이터는 읽기 전용입니다.

예제를 실행하기 전에 [install Aspose.Slides for Node.js via Java](/slides/ko/nodejs-java/installation/)를 수행하십시오.

## **로컬, 상속 및 실제 값 비교**

다음 전체 예제는 도형을 만들고 프레젠테이션, 단락 및 부분 수준에서 글꼴 높이를 적용합니다. 각 단계는 해당 수준에서 정의된 값을 출력하고 동일한 텍스트 부분에 대한 결과적인 실제 값을 보여줍니다. 또한 형식 변경 후 실제 데이터를 다시 읽어야 하는 이유를 설명합니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function formatLocalValue(value) {
    return Number.isNaN(value) ? "<not set>" : value.toString();
}

function printFontHeights(caption, presentation, paragraph, portion) {
    const presentationValue = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight();
    const paragraphValue = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight();
    const localValue = portion.getPortionFormat().getFontHeight();

    // 이전 변경 사항 후에 실제 데이터를 읽습니다.
    const effectiveValue = portion.getPortionFormat().getEffective().getFontHeight();

    console.log(caption);
    console.log("  Presentation default: " + formatLocalValue(presentationValue));
    console.log("  Paragraph default:    " + formatLocalValue(paragraphValue));
    console.log("  Portion local:        " + formatLocalValue(localValue));
    console.log("  Portion effective:    " + effectiveValue);
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 500, 80, false);
    const textFrame = shape.addTextFrame("Effective formatting");
    const paragraph = textFrame.getParagraphs().get_Item(0);
    const portion = paragraph.getPortions().get_Item(0);

    // 두 가지 다른 레벨에서 상속 값을 정의합니다.
    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);

    printFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

    // 부분에 대한 로컬 값이 두 상속 값을 모두 덮어씁니다.
    portion.getPortionFormat().setFontHeight(36);
    printFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

    // 상속 값을 변경해도 기존 로컬 값을 덮어쓰지 않습니다.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30);
    printFontHeights("The local value still has priority", presentation, paragraph, portion);

    // 로컬 값을 지웁니다. 이제 부분이 다시 단락에서 상속받습니다.
    portion.getPortionFormat().setFontHeight(java.newFloat(Number.NaN));
    printFontHeights("The local value is cleared", presentation, paragraph, portion);

    // 단락 값을 지웁니다. 이제 프레젠테이션 기본값이 결과를 제공합니다.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(java.newFloat(Number.NaN));
    printFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

    presentation.save("effective-properties.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

이 예제에서 우선 순위는 부분 로컬 형식, 그 다음 단락 형식, 그 다음 프레젠테이션 기본값입니다. 다른 개체는 다른 상속 체인을 가질 수 있지만 원칙은 동일합니다: 더 구체적인 명시적 값이 우선하며, [getEffective](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/portionformat/#getEffective)는 최종 결과를 반환합니다.

## **실제 텍스트 속성 가져오기**

텍스트 형식은 여러 개체에 걸쳐 분할됩니다:

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframeformat/#getEffective) 은 여백, 고정, 자동 맞춤 및 수직 텍스트 방향과 같은 텍스트 프레임 속성을 해결합니다.
- [TextStyle.getEffective](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textstyle/#getEffective) 은 각 텍스트 스타일 수준에 대한 단락 형식을 해결합니다.
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/paragraphformat/#getEffective) 은 정렬, 들여쓰기 및 글머리표와 같은 단락 속성을 해결합니다.
- [PortionFormat.getEffective](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/portionformat/#getEffective) 은 글꼴 높이, 서체, 색상, 굵게 및 기울임꼴과 같은 문자 속성을 해결합니다.

다음 예제를 사용하려면 `text-formatting.pptx`에 최소 하나의 슬라이드와 텍스트 프레임이 비어 있지 않은 [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape/)가 포함되어 있어야 합니다. AutoShape는 도형 컬렉션의 어느 위치에 있든 상관없으며, 코드는 적절한 개체를 찾아 사용 전에 검증합니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function hasNonEmptyText(shape) {
    if (shape.getTextFrame() == null) {
        return false;
    }
    if (shape.getTextFrame().getParagraphs().getCount() === 0) {
        return false;
    }
    return shape.getTextFrame().getParagraphs().get_Item(0).getPortions().getCount() > 0;
}

function findAutoShapeWithText(slide) {
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const candidate = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(candidate, "com.aspose.slides.AutoShape") && hasNonEmptyText(candidate)) {
            return candidate;
        }
    }
    return null;
}

const presentation = new aspose.slides.Presentation("text-formatting.pptx");
try {
    if (presentation.getSlides().size() === 0) {
        throw new Error("The presentation contains no slides.");
    }

    const shape = findAutoShapeWithText(presentation.getSlides().get_Item(0));
    if (shape == null) {
        throw new Error("The first slide must contain an AutoShape with non-empty text.");
    }

    const textFrame = shape.getTextFrame();
    const paragraph = textFrame.getParagraphs().get_Item(0);
    const portion = paragraph.getPortions().get_Item(0);

    const textFrameEffective = textFrame.getTextFrameFormat().getEffective();
    const paragraphEffective = paragraph.getParagraphFormat().getEffective();
    const portionEffective = portion.getPortionFormat().getEffective();

    console.log("Text frame margins:");
    console.log("  Left: " + textFrameEffective.getMarginLeft());
    console.log("  Top: " + textFrameEffective.getMarginTop());
    console.log("  Right: " + textFrameEffective.getMarginRight());
    console.log("  Bottom: " + textFrameEffective.getMarginBottom());
    console.log("Paragraph alignment: " + paragraphEffective.getAlignment());
    console.log("Font height: " + portionEffective.getFontHeight());
    console.log("Bold: " + portionEffective.getFontBold());

    const effectiveTextStyle = textFrame.getTextFrameFormat().getTextStyle().getEffective();
    for (let level = 0; level < 9; level++) {
        const levelEffective = effectiveTextStyle.getLevel(level);
        console.log("Level " + level + " indent: " + levelEffective.getIndent());
    }
} finally {
    presentation.dispose();
}
```

## **실제 3D 속성 가져오기**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/threedformat/#getEffective) 은 모든 해결된 3D 설정을 그룹화하는 단일 실제 데이터 개체를 반환합니다. 해당 개체의 [getCamera](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/threedformat/#getCamera), [getLightRig](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/threedformat/#getLightRig), [getBevelTop](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/threedformat/#getBevelTop) 및 [getBevelBottom](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/threedformat/#getBevelBottom) 메서드는 각각의 실제 데이터를 노출합니다. 이러한 관련 설정을 함께 읽으면 도형의 최종 3D 외관을 이해하기가 더 쉽습니다.

이 예제를 위해 `shape-3d.pptx`에는 첫 번째 슬라이드에 최소 하나의 도형이 포함되어 있어야 합니다. 기본값 이외의 값을 출력하려면 해당 도형에 3D 카메라, 조명 또는 베벨 설정을 적용하십시오.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("shape-3d.pptx");
try {
    if (presentation.getSlides().size() === 0 || presentation.getSlides().get_Item(0).getShapes().size() === 0) {
        throw new Error("The first slide must contain a shape.");
    }

    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const threeDEffective = shape.getThreeDFormat().getEffective();

    console.log("Camera:");
    console.log("  Type: " + threeDEffective.getCamera().getCameraType());
    console.log("  Field of view: " + threeDEffective.getCamera().getFieldOfViewAngle());
    console.log("  Zoom: " + threeDEffective.getCamera().getZoom());

    console.log("Light rig:");
    console.log("  Type: " + threeDEffective.getLightRig().getLightType());
    console.log("  Direction: " + threeDEffective.getLightRig().getDirection());

    console.log("Top bevel:");
    console.log("  Type: " + threeDEffective.getBevelTop().getBevelType());
    console.log("  Width: " + threeDEffective.getBevelTop().getWidth());
    console.log("  Height: " + threeDEffective.getBevelTop().getHeight());
} finally {
    presentation.dispose();
}
```

## **실제 테이블 형식 가져오기**

테이블 형식은 테이블 스타일과 전체 테이블, 열, 행 또는 개별 셀에 적용된 형식에서 올 수 있습니다. 명시적으로 정의된 채우기 간 충돌이 발생하면 우선 순위는 셀 → 행 → 열 → 전체 테이블 순입니다. 셀의 실제 형식은 해당 셀을 그릴 때 사용되는 최종 형식입니다.

이 예제를 위해 `table-formatting.pptx`에는 첫 번째 슬라이드에 최소 하나의 테이블이 포함되어 있어야 합니다. 테이블에는 최소 하나의 행과 하나의 열이 있어야 합니다. 코드는 `getShapes().get_Item(0)`이 테이블이라고 가정하는 대신 [Table](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/table/)을 찾습니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function findTable(slide) {
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.Table")) {
            return shape;
        }
    }
    return null;
}

const presentation = new aspose.slides.Presentation("table-formatting.pptx");
try {
    if (presentation.getSlides().size() === 0) {
        throw new Error("The presentation contains no slides.");
    }

    const table = findTable(presentation.getSlides().get_Item(0));
    if (table == null) {
        throw new Error("The first slide must contain a table.");
    }
    if (table.getRows().size() === 0 || table.getColumns().size() === 0) {
        throw new Error("The table must contain at least one cell.");
    }

    const tableEffective = table.getTableFormat().getEffective();
    const rowEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    const columnEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    const cellEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    console.log("Table fill: " + tableEffective.getFillFormat().getFillType());
    console.log("Row fill: " + rowEffective.getFillFormat().getFillType());
    console.log("Column fill: " + columnEffective.getFillFormat().getFillType());
    console.log("Final cell fill: " + cellEffective.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

색상 자체가 필요하고 채우기 유형만이 아니라면 먼저 실제 [getFillType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fillformat/#getFillType)를 확인한 다음 해당 유형에 적용되는 메서드를 읽으십시오—예를 들어, 고정 색상의 경우 [getSolidFillColor](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fillformat/#getSolidFillColor)를 사용합니다.

## **변경 후 실제 데이터 다시 읽기**

실제 데이터는 해결 시점의 형식 계층 구조를 설명합니다. 해당 계층 구조에 참여할 수 있는 항목을 변경한 후에는 `getEffective`을 다시 호출하십시오. 포함 항목:

- 개체의 로컬 형식;
- 단락 또는 텍스트 프레임 기본값;
- 테이블 스타일, 테이블, 열, 행 또는 셀 형식;
- 레이아웃 또는 마스터 슬라이드 형식;
- 테마 데이터 또는 프레젠테이션 수준 기본값;
- 슬라이드에 할당된 레이아웃 또는 마스터.

실제 데이터 객체를 영구 스냅샷으로 보관하지 마십시오. Aspose.Slides는 일부 실제 데이터를 내부적으로 캐시할 수 있으며, 이후 `getEffective` 호출이 해당 데이터를 새로 고칠 수 있습니다. 변경 전후 값을 비교해야 하는 경우, 변경을 수행하기 전에 글꼴 높이, 색상, 정렬 또는 베벨 너비와 같은 필요한 스칼라 값을 자체 변수에 복사하십시오.

값을 변경하려면 해당 로컬 형식 개체를 업데이트한 다음 `getEffective`을 호출해 결과를 확인하십시오. 실제 데이터 객체 자체는 읽기 전용입니다.

## **FAQ**

**실제 값을 제공한 수준을 어떻게 알 수 있나요?**

실제 데이터에는 최종 값만 포함되어 있으며 원본은 제공되지 않습니다. 가장 구체적인 수준부터 외부로 이동하면서 해당 로컬 개체들을 검사하십시오. 텍스트의 경우 부분, 단락, 텍스트 프레임, 레이아웃, 마스터, 테마 및 프레젠테이션 기본값이 포함될 수 있습니다. `NaN` 또는 `null`과 같은 정의되지 않은 값은 검색이 다른 수준으로 계속됨을 나타냅니다.

**어떠한 수준에서도 속성을 정의하지 않으면 어떻게 되나요?**

Aspose.Slides는 적절한 PowerPoint 또는 라이브러리 기본값을 해결합니다. 해당 해결된 값은 실제 데이터에 표시되며, 로컬 개체가 명시적으로 정의하지 않았더라도 포함됩니다.

**실제 값이 때때로 로컬 값과 동일한 이유는 무엇인가요?**

로컬 값이 상속 계산에서 승리했기 때문입니다. 이는 개체에 속성이 명시적으로 설정되어 있고 더 구체적인 규칙이 이를 덮어쓰지 않을 때 발생합니다.

**언제 로컬 데이터를 사용하고 실제 데이터를 사용해야 하나요?**

특정 형식 수준을 검사하거나 편집하려면 로컬 데이터를 사용하십시오. 상속, 테마 규칙 및 적용 가능한 스타일이 모두 해결된 후 최종 외관이 필요하면 실제 데이터를 사용하십시오. [complete comparison example](#compare-local-inherited-and-effective-values)는 동일한 워크플로우에서 두 가지를 모두 보여줍니다.