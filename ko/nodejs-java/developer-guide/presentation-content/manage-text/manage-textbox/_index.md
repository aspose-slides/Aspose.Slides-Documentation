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
description: "Aspose.Slides for Node.js를 사용하면 PowerPoint 및 OpenDocument 파일에서 텍스트 상자를 쉽게 만들고, 편집하고, 복제할 수 있어 프레젠테이션 자동화를 향상시킵니다."
---
## **슬라이드에 텍스트 상자 만들기**

슬라이드의 텍스트는 일반적으로 텍스트 상자나 도형에 존재합니다. 따라서 슬라이드에 텍스트를 추가하려면 텍스트 상자를 추가하고 그 안에 텍스트를 넣어야 합니다. Aspose.Slides for Node.js via Java는 텍스트를 포함하는 도형을 추가할 수 있는 [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/AutoShape) 클래스를 제공합니다.

{{% alert title="Info" color="info" %}}
Aspose.Slides는 슬라이드에 도형을 추가할 수 있는 [Shape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Shape) 클래스도 제공합니다. 하지만 `Shape` 클래스를 통해 추가된 모든 도형이 텍스트를 포함할 수 있는 것은 아닙니다. 그러나 [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/AutoShape) 클래스를 통해 추가된 도형은 텍스트를 포함할 수 있습니다.
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
따라서 텍스트를 추가하려는 도형을 다룰 때는 해당 도형이 `AutoShape` 클래스로 캐스팅되었는지 확인해야 할 수 있습니다. 그래야만 `AutoShape` 아래의 속성인 [TextFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/TextFrame)을 사용할 수 있습니다. 이 페이지의 [Update Text](https://docs.aspose.com/slides/ko/nodejs-java/manage-textbox/#update-text) 섹션을 참고하십시오.
{{% /alert %}}

## **Create Text Box on Slide**

슬라이드에 텍스트 상자를 만들려면 다음 단계로 진행하십시오:

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
2. 새로 만든 프레젠테이션의 첫 번째 슬라이드에 대한 참조를 얻습니다.
3. [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/AutoShape) 객체를 추가하고, [ShapeType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/GeometryShape#setShapeType-int-)을 `Rectangle` 로 지정하여 슬라이드의 지정된 위치에 배치한 뒤 새로 추가된 `AutoShape` 객체에 대한 참조를 얻습니다.
4. `AutoShape` 객체에 텍스트를 포함할 `TextFrame` 속성을 추가합니다. 아래 예제에서는 다음 텍스트를 추가했습니다: *Aspose TextBox*
5. 마지막으로 `Presentation` 객체를 사용하여 PPTX 파일을 저장합니다. 

다음 JavaScript 코드는 위 단계들을 구현한 것으로, 슬라이드에 텍스트를 추가하는 방법을 보여줍니다:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// 프레젠테이션 인스턴스 생성
var pres = new aspose.slides.Presentation();
try {
    // 프레젠테이션의 첫 번째 슬라이드 가져오기
    var sld = pres.getSlides().get_Item(0);
    // 타입을 Rectangle 로 설정하여 AutoShape 추가
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // Rectangle에 TextFrame 추가
    ashp.addTextFrame(" ");
    // 텍스트 프레임에 접근
    var txtFrame = ashp.getTextFrame();
    // 텍스트 프레임용 Paragraph 객체 생성
    var para = txtFrame.getParagraphs().get_Item(0);
    // Paragraph용 Portion 객체 생성
    var portion = para.getPortions().get_Item(0);
    // 텍스트 설정
    portion.setText("Aspose TextBox");
    // 프레젠테이션을 디스크에 저장
    pres.save("TextBox_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Check for Text Box Shape**

Aspose.Slides는 [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape/) 클래스의 [isTextBox](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape/#isTextBox) 메서드를 제공하여 도형을 검사하고 텍스트 상자를 식별할 수 있게 합니다.

![Text box and shape](istextbox.png)

다음 JavaScript 코드는 도형이 텍스트 상자로 생성되었는지 확인하는 방법을 보여줍니다:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (var slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        var slide = presentation.getSlides().get_Item(slideIndex);
        for (var shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            var shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                var autoShape = shape;
                console.log(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

참고로 [ShapeCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shapecollection/) 클래스의 `addAutoShape` 메서드를 사용해 단순히 자동 도형을 추가하면 해당 자동 도형의 `isTextBox` 메서드는 `false`를 반환합니다. 그러나 `addTextFrame` 메서드나 `setText` 메서드를 사용해 자동 도형에 텍스트를 추가하면 `isTextBox` 속성이 `true`를 반환합니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
var slide = presentation.getSlides().get_Item(0);

var shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox()는 false를 반환합니다
shape1.addTextFrame("shape 1");
// shape1.isTextBox()는 true를 반환합니다

var shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox()는 false를 반환합니다
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox()는 true를 반환합니다

var shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox()는 false를 반환합니다
shape3.addTextFrame("");
// shape3.isTextBox()는 false를 반환합니다

var shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox()는 false를 반환합니다
shape4.getTextFrame().setText("");
// shape4.isTextBox()는 false를 반환합니다
```

## **Find the Shape That Owns a Text Frame**

일반적인 텍스트 처리 코드에서는 [TextFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/)을 받게 될 수 있지만, 이를 포함하고 있는 프레젠테이션 객체가 어느 것인지 모를 수 있습니다. [TextFrame.getParentShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/#getParentShape--) 메서드를 사용하면 해당 [Shape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/)으로 되돌아갈 수 있습니다.

[AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape/) 또는 다른 텍스트를 포함하는 도형에 속한 텍스트 프레임의 경우, [TextFrame.getParentShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/#getParentShape--)은 소유자를 반환하고 [TextFrame.getParentCell](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/#getParentCell--)은 `null`을 반환합니다. 두 메서드는 읽기 전용 탐색을 제공하므로 호출해도 소유권이 변경되지 않습니다. 도형에 접근하기 전에 반환값이 `null`인지 항상 확인하십시오.

SmartArt 노드와 연관된 도형을 포함하여 도형 및 테이블 셀 소유자를 식별하는 전체 예제는 [Search and Replace Text](/slides/ko/nodejs-java/search-and-replace-text/)를 참조하십시오.

## **Add Column In Text Box**

Aspose.Slides는 텍스트 상자에 열을 추가할 수 있는 [TextFrameFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/TextFrameFormat) 클래스의 [setColumnCount](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) 및 [setColumnSpacing](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/TextFrameFormat#setColumnSpacing-double-) 메서드를 제공합니다. 이를 통해 텍스트 상자의 열 수를 지정하고 열 사이의 간격을 포인트 단위로 설정할 수 있습니다.

다음 JavaScript 코드는 위에서 설명한 동작을 보여줍니다: 

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    // 프레젠테이션의 첫 번째 슬라이드를 가져옵니다
    var slide = pres.getSlides().get_Item(0);
    // 타입을 Rectangle 로 설정하여 AutoShape을 추가합니다
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // Rectangle에 TextFrame을 추가합니다
    aShape.addTextFrame((("All these columns are limited to be within a single text container -- " + "you can add or delete text and the new or remaining text automatically adjusts ") + "itself to flow within the container. You cannot have text flow from one container ") + "to other though -- we told you PowerPoint's column options for text are limited!");
    // TextFrame의 텍스트 형식을 가져옵니다
    var format = aShape.getTextFrame().getTextFrameFormat();
    // TextFrame의 열 수를 지정합니다
    format.setColumnCount(3);
    // 열 사이의 간격을 지정합니다
    format.setColumnSpacing(10);
    // 프레젠테이션을 저장합니다
    pres.save("ColumnCount.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Add Column In Text Frame**

Aspose.Slides for Node.js via Java는 텍스트 프레임에 열을 추가할 수 있는 [TextFrameFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/TextFrameFormat) 클래스의 [setColumnCount](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) 메서드를 제공합니다. 이 속성을 사용하면 텍스트 프레임의 원하는 열 수를 지정할 수 있습니다.

다음 JavaScript 코드는 텍스트 프레임 안에 열을 추가하는 방법을 보여줍니다:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const assert = require("assert");

var outPptxFileName = "ColumnsTest.pptx";
var pres = new aspose.slides.Presentation();
try {
    var shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    var format = shape1.getTextFrame().getTextFrameFormat();
    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " + "you can add or delete text - and the new or remaining text automatically adjusts " + "itself to stay within the container. You cannot have text spill over from one container " + "to other, though -- because PowerPoint's column options for text are limited!");
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test.getSlides().get_Item(0).getShapes().get_Item(0);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnCount(), 2);
        // 열 간격이 설정되지 않았으므로 NaN으로 보고됩니다.
        assert.ok(Number.isNaN(autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing()));
    } finally {
        if (test != null) {
            test.dispose();
        }
    }
    format.setColumnSpacing(20);
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test1 = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test1.getSlides().get_Item(0).getShapes().get_Item(0);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnCount(), 2);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing(), 20);
    } finally {
        if (test1 != null) {
            test1.dispose();
        }
    }
    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test2 = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test2.getSlides().get_Item(0).getShapes().get_Item(0);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnCount(), 3);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing(), 15);
    } finally {
        if (test2 != null) {
            test2.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Update Text**

Aspose.Slides를 사용하면 텍스트 상자에 포함된 텍스트 또는 프레젠테이션에 포함된 모든 텍스트를 변경하거나 업데이트할 수 있습니다.

다음 JavaScript 코드는 프레젠테이션의 모든 텍스트를 업데이트하거나 변경하는 작업을 보여줍니다:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation("text.pptx");
try {
    for (let s = 0; s < pres.getSlides().size(); s++) {
        let slide = pres.getSlides().get_Item(s);
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // 형상이 텍스트 프레임(IAutoShape)을 지원하는지 확인합니다.
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                var autoShape = shape;
                // 텍스트 프레임의 단락을 반복합니다
                for (let j = 0; j < autoShape.getTextFrame().getParagraphs().getCount(); j++) {
                    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(j);
                    // 단락의 각 구간을 반복합니다
                    for (let k = 0; k < paragraph.getPortions().getCount(); k++) {
                        let portion = paragraph.getPortions().get_Item(k);
                        portion.setText(portion.getText().replace("years", "months"));// 텍스트를 변경합니다
                        portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));// 서식을 변경합니다
                    }
                }
            }
        }
    }
    // 수정된 프레젠테이션을 저장합니다
    pres.save("text-changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Add Text Box with Hyperlink** 

텍스트 상자 안에 링크를 삽입할 수 있습니다. 텍스트 상자를 클릭하면 사용자가 해당 링크를 열게 됩니다.

링크가 포함된 텍스트 상자를 추가하려면 다음 단계로 진행하십시오:

1. `Presentation` 클래스의 인스턴스를 생성합니다.
2. 새로 만든 프레젠테이션의 첫 번째 슬라이드에 대한 참조를 얻습니다.
3. `ShapeType`이 `Rectangle`인 `AutoShape` 객체를 슬라이드의 지정된 위치에 추가하고 새로 추가된 AutoShape 객체에 대한 참조를 얻습니다.
4. `AutoShape` 객체에 `TextFrame`을 추가하고 첫 번째 구간의 텍스트를 설정합니다. 아래 예제에서는 다음 텍스트를 사용했습니다: *Aspose.Slides*
5. `PortionFormat`을 통해 해당 구간의 `HyperlinkManager`를 가져옵니다.
6. `HyperlinkManager`에서 `setExternalHyperlinkClick`을 호출하여 구간에 링크를 연결합니다.
7. 마지막으로 `Presentation` 객체를 사용하여 PPTX 파일을 저장합니다. 

다음 JavaScript 코드는 위 단계들을 구현한 것으로, 슬라이드에 하이퍼링크가 포함된 텍스트 상자를 추가하는 방법을 보여줍니다:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// PPTX를 나타내는 Presentation 클래스를 인스턴스화합니다
var pres = new aspose.slides.Presentation();
try {
    // 프레젠테이션의 첫 번째 슬라이드를 가져옵니다
    var slide = pres.getSlides().get_Item(0);
    // 타입을 Rectangle 로 설정하여 AutoShape 객체를 추가합니다
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 150, 50);
    // 도형을 AutoShape으로 캐스팅합니다
    var pptxAutoShape = shape;
    // AutoShape에 연결된 ITextFrame 속성에 접근합니다
    pptxAutoShape.addTextFrame("");
    var textFrame = pptxAutoShape.getTextFrame();
    // 프레임에 텍스트를 추가합니다
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");
    // 구간 텍스트에 하이퍼링크를 설정합니다
    var hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");
    // PPTX 프레젠테이션을 저장합니다
    pres.save("hLink_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**마스터 슬라이드 작업 시 텍스트 상자와 텍스트 플레이스홀더의 차이점은 무엇인가요?**

[placeholder](/slides/ko/nodejs-java/manage-placeholder/)는 [master](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/masterslide/)로부터 스타일/위치를 상속받으며 [layouts](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/layoutslide/)에서 재정의될 수 있습니다. 반면 일반 텍스트 상자는 특정 슬라이드에 존재하는 독립적인 객체이며 레이아웃을 전환해도 변경되지 않습니다.

**차트, 테이블, SmartArt 내부의 텍스트를 건드리지 않고 프레젠테이션 전체에서 대량 텍스트 교체를 수행하려면 어떻게 해야 하나요?**

텍스트 프레임을 가진 자동 도형만 반복 대상으로 제한하고, 임베디드 객체인 [charts](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chart/), [tables](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/smartart/)는 별도의 컬렉션을 순회하거나 해당 객체 유형을 건너뛰어 제외합니다.