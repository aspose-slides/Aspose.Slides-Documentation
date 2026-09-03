---
title: JavaScript를 사용하여 프레젠테이션에서 텍스트 상자 관리
linktitle: 텍스트 상자 관리
type: docs
weight: 20
url: /ko/nodejs-java/manage-textbox/
keywords:
- 텍스트 상자
- 텍스트 프레임
- 텍스트 추가
- 텍스트 업데이트
- 텍스트 상자 만들기
- 텍스트 상자 확인
- 텍스트 열 추가
- 하이퍼링크 추가
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 텍스트 상자를 생성, 식별, 서식 지정 및 업데이트합니다."
---
## **소개**

Aspose.Slides for Node.js via Java에서는 슬라이드 텍스트가 도형에 속하는 텍스트 프레임에 저장됩니다. [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape/) 클래스는 가장 일반적인 텍스트를 포함하는 도형을 나타내며, 해당 텍스트를 [AutoShape.getTextFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape/#getTextFrame) 메서드를 통해 제공합니다.

{{% alert color="info" title="참고" %}}
모든 자동 도형은 [Shape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/)에서 파생되지만, 모든 도형이 자동 도형이거나 텍스트 프레임을 지원하는 것은 아닙니다. 기존 프레젠테이션을 처리할 때, 텍스트에 접근하기 전에 도형이 [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape/)의 인스턴스인지 확인하십시오.
{{% /alert %}}

## **슬라이드에 텍스트 상자 만들기**

텍스트 상자를 만들려면 슬라이드에 자동 도형을 추가하고, 텍스트 프레임에 텍스트를 입력한 다음 프레젠테이션을 저장합니다. 다음 예제는 직사각형 텍스트 상자를 생성합니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 300, 50);
    textBox.addTextFrame("Aspose TextBox");

    presentation.save("TextBox.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[ShapeCollection.addAutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shapecollection/#addAutoShape) 에 전달되는 좌표와 크기는 포인트 단위입니다. [AutoShape.addTextFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape/#addTextFrame) 은 제공된 텍스트로 텍스트 프레임을 초기화합니다.

## **텍스트 상자 모양 확인**

자동 도형이 텍스트 상자로 취급되는지 확인하려면 [AutoShape.isTextBox](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape/#isTextBox) 메서드를 사용합니다. 이 메서드는 프레젠테이션에 텍스트가 포함된 도형과 순수 그래픽 자동 도형이 모두 있을 때 유용합니다.

![텍스트 상자와 모양](istextbox.png)

다음 예제는 프레젠테이션의 모든 자동 도형을 검사합니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 120, 40);
    textBox.addTextFrame("Text box");
    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 150, 10, 40, 40);

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const currentSlide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < currentSlide.getShapes().size(); shapeIndex++) {
            const shape = currentSlide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                console.log(shape.isTextBox() ? "The shape is a text box." : "The shape is not a text box.");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

새로 추가된 자동 도형은 비어 있지 않은 텍스트를 포함할 때까지 텍스트 상자로 간주되지 않습니다. 해당 텍스트는 [AutoShape.addTextFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape/#addTextFrame) 또는 [TextFrame.setText](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/#setText) 을 통해 제공할 수 있습니다. 빈 문자열을 추가하거나 할당하면 [AutoShape.isTextBox](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape/#isTextBox) 은 `false` 를 반환합니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 40);
    shape1.addTextFrame("Shape 1");
    console.log(shape1.isTextBox());

    const shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 100, 40);
    shape2.getTextFrame().setText("Shape 2");
    console.log(shape2.isTextBox());

    const shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 100, 40);
    shape3.addTextFrame("");
    console.log(shape3.isTextBox());

    const shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 100, 40);
    shape4.getTextFrame().setText("");
    console.log(shape4.isTextBox());
} finally {
    presentation.dispose();
}
```

첫 번째와 두 번째 호출은 `true` 를 출력하고, 마지막 두 호출은 `false` 를 출력합니다.

## **텍스트 프레임을 소유하는 도형 찾기**

일반적인 텍스트 처리 코드는 어떤 프레젠테이션 개체에 포함되어 있는지 모르는 [TextFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/)을 받을 수 있습니다. 읽기 전용 [TextFrame.getParentShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/#getParentShape) 메서드를 사용하여 소유자 [Shape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/) 으로 돌아갈 수 있습니다.

자동 도형이나 다른 텍스트를 포함하는 도형이 소유하는 텍스트 프레임의 경우, [TextFrame.getParentShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/#getParentShape) 은 소유자를 반환하고 [TextFrame.getParentCell](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/#getParentCell) 은 `null` 을 반환합니다. 접근하기 전에 반환값을 확인하십시오. 도형과 테이블 셀 소유자를 모두 식별하려면, SmartArt 노드와 연결된 도형을 포함하여 [Search and Replace Text](/slides/ko/nodejs-java/search-and-replace-text/) 를 참조하십시오.

## **텍스트 상자에 열 추가**

[TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframeformat/#setColumnCount) 메서드는 텍스트 프레임을 여러 열로 나누고, [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframeformat/#setColumnSpacing) 은 열 사이의 간격을 포인트 단위로 설정합니다. 두 설정 모두 [TextFrameFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframeformat/) 에 속하며 기존 텍스트 상자의 텍스트 프레임을 통해 변경할 수 있습니다. 텍스트는 같은 도형 안에서 열 사이에 다시 흐르며, 다른 도형으로 이어지지는 않습니다.

다음 예제는 열 사이에 10포인트 간격을 두고 세 열 텍스트 상자를 만든 뒤 프레젠테이션을 저장하고, 출력 파일에서 저장된 설정을 다시 읽어옵니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 200);
    textBox.addTextFrame("This text is distributed automatically across all columns in the text box.");

    const textFrameFormat = textBox.getTextFrame().getTextFrameFormat();
    textFrameFormat.setColumnCount(3);
    textFrameFormat.setColumnSpacing(10);

    presentation.save("TextBoxColumns.pptx", aspose.slides.SaveFormat.Pptx);

    const savedPresentation = new aspose.slides.Presentation("TextBoxColumns.pptx");
    try {
        const savedTextBox = savedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedFormat = savedTextBox.getTextFrame().getTextFrameFormat();
        console.log("Columns: " + savedFormat.getColumnCount() + "; spacing: " + savedFormat.getColumnSpacing() + " points");
    } finally {
        savedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **개별 열에서 텍스트 추출**

[TextFrame.splitTextByColumns](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/#splitTextByColumns) 를 사용하면 기존 텍스트 프레임의 각 시각적 열에 할당된 텍스트를 가져올 수 있습니다. 이 메서드는 열 기반 읽기 순서대로 각 열에 대한 문자열을 반환합니다. 단일 열 텍스트 프레임은 하나의 요소를 가진 배열을 반환하고, 빈 열은 빈 문자열로 표시됩니다. 반환된 문자열은 순수 텍스트만 포함하며, 부분 수준 서식은 보존되지 않습니다.

다음과 같은 경우에 유용합니다:
- 열 기반 읽기 순서를 유지하면서 텍스트를 추출해야 할 때.
- 다중 열 슬라이드의 내용을 인덱싱하거나 비교할 때.
- 각 열을 별도 파일, 데이터베이스 필드 또는 다른 대상에 내보낼 때.
- [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframeformat/#setColumnCount), [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframeformat/#setColumnSpacing), 글꼴 또는 텍스트 프레임 크기를 변경한 후 텍스트가 어떻게 재배치되는지 검사할 때.

이 메서드는 현재 [TextFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/) 내에 배분된 텍스트를 보고할 뿐이며, 별도의 도형이나 텍스트 상자 간에 텍스트를 자동으로 흐르게 하지 않습니다. 열 배분은 사용 가능한 글꼴 및 기타 텍스트 레이아웃 설정에 따라 달라질 수 있으므로, 일관된 결과가 중요한 경우 필요한 글꼴이 확보되어 있는지 확인하십시오.

다음 예제는 프레젠테이션을 로드하고, 텍스트 프레임을 가진 첫 번째 다중 열 자동 도형을 찾아 구성된 열 개수를 읽은 뒤, 각 열의 텍스트를 별도 파일에 기록합니다. 텍스트 프레임을 제공하지 않는 도형은 건너뛰됩니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("MultiColumnText.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let textBox = null;
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            const textFrame = shape.getTextFrame();
            if (textFrame != null) {
                const columnCount = textFrame.getTextFrameFormat().getColumnCount();
                if (columnCount > 1) {
                    textBox = shape;
                    break;
                }
            }
        }
    }

    if (textBox == null) {
        console.log("No multi-column text frame was found.");
    } else {
        const textFrame = textBox.getTextFrame();
        const configuredColumnCount = textFrame.getTextFrameFormat().getColumnCount();
        const columnTexts = textFrame.splitTextByColumns();

        console.log("Configured columns: " + configuredColumnCount);

        for (let columnIndex = 0; columnIndex < columnTexts.length; columnIndex++) {
            const columnNumber = columnIndex + 1;
            const columnText = columnTexts[columnIndex];
            console.log("Column " + columnNumber + ": " + columnText);
            const outputPath = "Column-" + columnNumber + ".txt";
            try {
                fs.writeFileSync(outputPath, columnText, "utf8");
            } catch (error) {
                console.log("Could not write column " + columnNumber + ": " + error.message);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **텍스트 업데이트**

프레젠테이션 전체의 텍스트를 업데이트하려면 슬라이드와 도형을 순회하고 자동 도형을 선택한 뒤 텍스트 부분을 편집합니다. 부분 수준에서 작업하면 텍스트와 문자 서식을 모두 변경할 수 있습니다.

다음 예제는 자동 도형 텍스트에서 `years` 를 `months` 로 모두 교체하고, 영향을 받은 각 부분을 굵게 만듭니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const fontBold = java.newByte(aspose.slides.NullableBool.True);
const presentation = new aspose.slides.Presentation("Text.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                continue;
            }

            const textFrame = shape.getTextFrame();
            if (textFrame == null) {
                continue;
            }

            for (let paragraphIndex = 0; paragraphIndex < textFrame.getParagraphs().getCount(); paragraphIndex++) {
                const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
                for (let portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    const text = portion.getText();
                    if (text != null && text.includes("years")) {
                        portion.setText(text.replace(/years/g, "months"));
                        portion.getPortionFormat().setFontBold(fontBold);
                    }
                }
            }
        }
    }

    presentation.save("TextChanged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

이 순회는 자동 도형의 텍스트만 업데이트합니다. 테이블, 차트, SmartArt 또는 그룹화된 도형에 저장된 텍스트는 해당 개체의 컬렉션을 순회해야 변경됩니다.

## **하이퍼링크가 있는 텍스트 상자 추가**

하이퍼링크는 특정 텍스트 부분에 할당할 수 있으므로 해당 �스트만 클릭 가능한 링크가 됩니다. [HyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick) 를 사용하여 부분을 외부 URL에 연결하십시오.

다음 예제는 링크된 텍스트를 만들고 프레젠테이션에 저장합니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 200, 50);
    textBox.addTextFrame("Aspose.Slides");

    const textPortion = textBox.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/");

    presentation.save("Hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**마스터 또는 레이아웃 슬라이드에서 텍스트 상자와 텍스트 자리 표시자의 차이점은 무엇인가요?**

[placeholder](/slides/ko/nodejs-java/manage-placeholder/) 은 [master slide](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/masterslide/) 또는 [layout slide](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/layoutslide/) 로부터 위치와 서식을 상속받을 수 있습니다. 일반 텍스트 상자는 생성된 슬라이드에 독립적인 도형이며, 레이아웃이 변경될 때 자리 표시자 동작을 획득하지 않습니다.

**차트, 표 또는 SmartArt의 텍스트를 변경하지 않고 텍스트만 교체하려면 어떻게 해야 하나요?**

텍스트 교체 예제와 같이 [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape/) 인스턴스인 도형만 순회하도록 제한하십시오. 차트, 표, SmartArt 는 자체 객체 모델에 텍스트를 저장하므로 해당 루프에서는 수정되지 않습니다.