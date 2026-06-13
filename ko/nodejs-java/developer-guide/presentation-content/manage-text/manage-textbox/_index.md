---
title: 프레젠테이션에서 JavaScript를 사용하여 텍스트 상자 관리
linktitle: 텍스트 상자 관리
type: docs
weight: 20
url: /ko/nodejs-java/manage-textbox/
keywords:
- 텍스트 상자
- 텍스트 프레임
- 텍스트 추가
- 텍스트 업데이트
- 텍스트 상자 생성
- 텍스트 상자 확인
- 텍스트 열 추가
- 하이퍼링크 추가
- 파워포인트
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js는 PowerPoint 및 OpenDocument 파일에서 텍스트 상자를 쉽게 생성, 편집 및 복제할 수 있게 하여 프레젠테이션 자동화를 강화합니다."
---
## **소개**

슬라이드의 텍스트는 일반적으로 텍스트 상자나 도형에 존재합니다. 따라서 슬라이드에 텍스트를 추가하려면 텍스트 상자를 추가하고 그 텍스트 상자 안에 텍스트를 넣어야 합니다. Aspose.Slides for Node.js via Java는 텍스트를 포함한 도형을 추가할 수 있는 [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/AutoShape) 클래스를 제공합니다.

{{% alert title="Info" color="info" %}}
Aspose.Slides는 슬라이드에 도형을 추가할 수 있는 [Shape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Shape) 클래스도 제공합니다. 그러나 `Shape` 클래스를 통해 추가된 모든 도형이 텍스트를 담을 수 있는 것은 아닙니다. 하지만 [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/AutoShape) 클래스를 통해 추가된 도형은 텍스트를 포함할 수 있습니다.
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
따라서 텍스트를 추가하려는 도형을 다룰 때는 해당 도형이 `AutoShape` 클래스로 캐스팅되었는지 확인해야 할 수도 있습니다. 그래야만 `AutoShape` 아래 속성인 [TextFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/TextFrame)를 사용할 수 있습니다. 이 페이지의 [Update Text](https://docs.aspose.com/slides/ko/nodejs-java/manage-textbox/#update-text) 섹션을 참고하십시오.
{{% /alert %}}

## **슬라이드에 텍스트 상자 만들기**

슬라이드에 텍스트 상자를 만들려면 다음 단계를 수행하십시오:

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.  
2. 새로 만든 프레젠테이션의 첫 번째 슬라이드에 대한 참조를 얻습니다.  
3. 슬라이드의 지정된 위치에 `ShapeType`을 `Rectangle`로 설정한 [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/AutoShape) 객체를 추가하고 새로 추가된 `AutoShape` 객체에 대한 참조를 얻습니다.  
4. 텍스트를 포함할 `TextFrame` 속성을 `AutoShape` 객체에 추가합니다. 아래 예제에서는 *Aspose TextBox* 라는 텍스트를 추가했습니다.  
5. 마지막으로 `Presentation` 객체를 통해 PPTX 파일을 저장합니다.  

위 단계들을 구현한 JavaScript 코드는 슬라이드에 텍스트를 추가하는 방법을 보여줍니다:

```javascript
// 프레젠테이션 인스턴스화
var pres = new aspose.slides.Presentation();
try {
    // 프레젠테이션에서 첫 번째 슬라이드 가져오기
    var sld = pres.getSlides().get_Item(0);
    // 형식을 Rectangle로 설정한 AutoShape 추가
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // Rectangle에 TextFrame 추가
    ashp.addTextFrame(" ");
    // 텍스트 프레임에 액세스
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

## **텍스트 상자 도형 확인**

Aspose.Slides는 [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape/) 클래스의 [isTextBox](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape/#isTextBox) 메서드를 제공하여 도형을 검사하고 텍스트 상자를 식별할 수 있게 합니다.

![Text box and shape](istextbox.png)

다음 JavaScript 코드는 도형이 텍스트 상자로 생성되었는지 확인하는 방법을 보여줍니다:

```javascript
var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    java.callStaticMethodSync("ForEach", "shape", presentation, (shape, slide, index) -> {
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            var autoShape = shape;
            console.log(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
        }
    });
} finally {
    presentation.dispose();
}
```

`addAutoShape` 메서드를 사용해 [ShapeCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shapecollection/) 클래스에서 자동 도형을 단순히 추가하면 해당 자동 도형의 `isTextBox` 메서드는 `false`를 반환합니다. 그러나 `addTextFrame` 메서드나 `setText` 메서드를 사용해 자동 도형에 텍스트를 추가하면 `isTextBox` 속성이 `true`를 반환합니다.

```javascript
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

## **텍스트 상자에 열 추가**

Aspose.Slides는 [TextFrameFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/TextFrameFormat) 클래스의 [setColumnCount](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) 및 [setColumnSpacing](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/TextFrameFormat#setColumnSpacing-double-) 메서드를 제공하여 텍스트 상자에 열을 추가할 수 있게 합니다. 텍스트 상자의 열 수를 지정하고 열 사이의 간격을 포인트 단위로 설정할 수 있습니다.

다음 JavaScript 코드는 위 동작을 시연합니다:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // 프레젠테이션에서 첫 번째 슬라이드 가져오기
    var slide = pres.getSlides().get_Item(0);
    // 형식을 Rectangle로 설정한 AutoShape 추가
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // Rectangle에 TextFrame 추가
    aShape.addTextFrame((("All these columns are limited to be within a single text container -- " + "you can add or delete text and the new or remaining text automatically adjusts ") + "itself to flow within the container. You cannot have text flow from one container ") + "to other though -- we told you PowerPoint's column options for text are limited!");
    // TextFrame의 텍스트 형식 가져오기
    var format = aShape.getTextFrame().getTextFrameFormat();
    // TextFrame의 열 수 지정
    format.setColumnCount(3);
    // 열 사이의 간격 지정
    format.setColumnSpacing(10);
    // 프레젠테이션 저장
    pres.save("ColumnCount.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **텍스트 프레임에 열 추가**

Aspose.Slides for Node.js via Java는 [TextFrameFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/TextFrameFormat) 클래스의 [setColumnCount](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) 메서드를 제공하여 텍스트 프레임에 열을 추가할 수 있게 합니다. 이 속성을 사용해 텍스트 프레임에 원하는 열 수를 지정할 수 있습니다.

다음 JavaScript 코드는 텍스트 프레임 안에 열을 추가하는 방법을 보여줍니다:

```javascript
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
        java.callStaticMethodSync("Assert", "assertTrue", 2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", java.getStaticFieldValue("java.lang.Double", "NaN") == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
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
        java.callStaticMethodSync("Assert", "assertTrue", 2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", 20 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
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
        java.callStaticMethodSync("Assert", "assertTrue", 3 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", 15 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
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

## **텍스트 업데이트**

Aspose.Slides를 사용하면 텍스트 상자에 포함된 텍스트 혹은 프레젠테이션 전체에 포함된 모든 텍스트를 변경하거나 업데이트할 수 있습니다. 

다음 JavaScript 코드는 프레젠테이션의 모든 텍스트를 업데이트하거나 변경하는 작업을 시연합니다:

```javascript
var pres = new aspose.slides.Presentation("text.pptx");
try {
    for (let s = 0; s < pres.getSlides().size(); s++) {
        let slide = pres.getSlides().get_Item(s);
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // shape가 텍스트 프레임(IAutoShape)을 지원하는지 확인합니다.
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                var autoShape = shape;
                // 텍스트 프레임의 단락들을 반복합니다.
                for (let j = 0; j < autoShape.getTextFrame().getParagraphs().getCount(); j++) {
                    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(j);
                    // 단락의 각 포션을 반복합니다.
                    for (let k = 0; k < paragraph.getPortions().getCount(); k++) {
                        let portion = paragraph.getPortions().get_Item(k);
                        portion.setText(portion.getText().replace("years", "months"));// 텍스트를 변경합니다.
                        portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));// 서식을 변경합니다.
                    }
                }
            }
        }
    }
    // 수정된 프레젠테이션을 저장합니다.
    pres.save("text-changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **하이퍼링크가 있는 텍스트 상자 추가** 

텍스트 상자 안에 링크를 삽입할 수 있습니다. 텍스트 상자를 클릭하면 사용자는 해당 링크를 열게 됩니다. 

링크가 포함된 텍스트 상자를 추가하려면 다음 단계를 수행하십시오:

1. `Presentation` 클래스의 인스턴스를 생성합니다.  
2. 새로 만든 프레젠테이션의 첫 번째 슬라이드에 대한 참조를 얻습니다.  
3. 슬라이드의 지정된 위치에 `ShapeType`을 `Rectangle`로 설정한 `AutoShape` 객체를 추가하고 새로 추가된 AutoShape 객체에 대한 참조를 얻습니다.  
4. 기본 텍스트가 *Aspose TextBox* 인 `AutoShape` 객체에 `TextFrame`을 추가합니다.  
5. `HyperlinkManager` 클래스를 인스턴스화합니다.  
6. `HyperlinkManager` 객체를 원하는 `TextFrame` 부분에 연결된 [HyperlinkClick](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Shape#getHyperlinkClick--) 속성에 할당합니다.  
7. 마지막으로 `Presentation` 객체를 통해 PPTX 파일을 저장합니다. 

위 단계들을 구현한 JavaScript 코드는 하이퍼링크가 포함된 텍스트 상자를 슬라이드에 추가하는 방법을 보여줍니다:

```javascript
// PPTX를 나타내는 Presentation 클래스를 인스턴스화합니다
var pres = new aspose.slides.Presentation();
try {
    // 프레젠테이션에서 첫 번째 슬라이드 가져오기
    var slide = pres.getSlides().get_Item(0);
    // 형식을 Rectangle로 설정한 AutoShape 객체를 추가합니다
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 150, 50);
    // shape를 AutoShape로 캐스팅합니다
    var pptxAutoShape = shape;
    // AutoShape와 연결된 ITextFrame 속성에 접근합니다
    pptxAutoShape.addTextFrame("");
    var textFrame = pptxAutoShape.getTextFrame();
    // 프레임에 텍스트를 추가합니다
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");
    // 포션 텍스트에 하이퍼링크를 설정합니다
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

**마스터 슬라이드 작업 시 텍스트 상자와 텍스트 자리표시자(플레이스홀더)의 차이점은 무엇인가요?**

A [placeholder](/slides/ko/nodejs-java/manage-placeholder/)는 [master](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/masterslide/)의 스타일/위치를 상속받으며 [layouts](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/layoutslide/)에서 재정의될 수 있지만, 일반 텍스트 상자는 특정 슬라이드에 독립된 객체이며 레이아웃을 전환해도 변경되지 않습니다.

**차트, 표, SmartArt 내부 텍스트를 건드리지 않고 프레젠테이션 전체의 텍스트를 일괄 교체하려면 어떻게 해야 하나요?**

텍스트 프레임이 있는 자동 도형만 반복 대상으로 제한하고, 삽입된 객체([charts](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chart/), [tables](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/smartart/))는 별도로 컬렉션을 순회하거나 해당 객체 유형을 건너뛰어 제외하십시오.