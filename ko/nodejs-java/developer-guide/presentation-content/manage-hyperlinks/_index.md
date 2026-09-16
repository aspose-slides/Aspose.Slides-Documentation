---
title: JavaScript에서 프레젠테이션 하이퍼링크 관리
linktitle: 하이퍼링크 관리
type: docs
weight: 20
url: /ko/nodejs-java/manage-hyperlinks/
keywords:
- URL 추가
- 하이퍼링크 추가
- 하이퍼링크 생성
- 하이퍼링크 서식 지정
- 하이퍼링크 제거
- 하이퍼링크 업데이트
- 텍스트 하이퍼링크
- 슬라이드 하이퍼링크
- 도형 하이퍼링크
- 이미지 하이퍼링크
- 비디오 하이퍼링크
- 변경 가능한 하이퍼링크
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Java를 통해 Node.js용 Aspose.Slides를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 하이퍼링크를 추가, 서식 지정, 업데이트 및 제거합니다. JavaScript 예제를 사용합니다."
---
## **소개**

하이퍼링크는 프레젠테이션 콘텐츠를 웹사이트나 프레젠테이션 내의 위치에 연결합니다. PowerPoint에서 하이퍼링크는 일반적으로 두 가지 용도로 사용됩니다:

* 텍스트, 도형 또는 미디어 프레임에서 웹사이트를 엽니다.
* 목차와 같이 다른 슬라이드로 이동합니다.

Aspose.Slides for Node.js via Java를 사용하면 이러한 링크를 추가하고, 표시와 사운드를 제어하며, 속성을 업데이트하고, 제거할 수 있습니다. 아래 예제에서는 개별 요소에서 하이퍼링크를 다루는 방법과 프레젠테이션, 슬라이드, 텍스트 프레임 수준에서 하이퍼링크에 접근하는 방법을 보여줍니다.

{{% alert color="info" title="Note" %}}
또한 [무료 온라인 Aspose PowerPoint 편집기](https://products.aspose.app/slides/ko/editor)를 사용하여 프레젠테이션을 편집할 수 있습니다.
{{% /alert %}} 

## **URL 하이퍼링크 추가**

텍스트, 도형 또는 미디어 프레임에 웹사이트 URL을 지정할 수 있습니다. 하이퍼링크를 지정하는 요소에 따라 클릭 가능한 영역이 결정됩니다: 텍스트 부분은 선택한 텍스트에 링크를 걸고, 도형이나 프레임은 슬라이드 개체에 링크를 겁니다.

### **텍스트에 URL 하이퍼링크 추가**

텍스트를 웹사이트에 연결하려면 아래와 같이 텍스트 부분의 [setHyperlinkClick](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/PortionFormat#setHyperlinkClick) 메서드에 [Hyperlink](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Hyperlink) 객체를 전달합니다. 해당 텍스트 부분만 클릭 가능하게 됩니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const textShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50, false);
    textShape.addTextFrame("Aspose: File Format APIs");
    const portionFormat = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");
    portionFormat.setFontHeight(32);

    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **도형 및 미디어 프레임에 URL 하이퍼링크 추가**

도형이나 프레임을 클릭 가능하게 만들려면 해당 객체의 [setHyperlinkClick](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Shape#setHyperlinkClick) 메서드를 호출합니다. 하이퍼링크는 내부 텍스트 부분이 아니라 객체 자체에 속합니다.

그림, 오디오 및 비디오 프레임에도 동일한 방법이 적용됩니다: 프레임에 하이퍼링크를 할당하고 필요한 경우 [setTooltip](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Hyperlink#setTooltip) 메서드를 호출합니다.

다음 예제는 사각형을 클릭 가능하게 합니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50);

    shape.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");

    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **하이퍼링크를 사용하여 목차 만들기**

내부 하이퍼링크를 사용하면 독자가 목차에서 특정 슬라이드로 이동할 수 있습니다. 다음 예제에서는 첫 번째 슬라이드의 “Page 2” 텍스트를 두 번째 슬라이드에 연결하기 위해 [setInternalHyperlinkClick](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/HyperlinkManager#setInternalHyperlinkClick) 메서드를 사용합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    const tableOfContents = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 300, 100);
    tableOfContents.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    tableOfContents.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    tableOfContents.getTextFrame().getParagraphs().clear();

    const paragraph = new aspose.slides.Paragraph();
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    paragraph.setText("Title of slide 2 .......... ");

    const linkPortion = new aspose.slides.Portion();
    linkPortion.setText("Page 2");
    linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);

    paragraph.getPortions().add(linkPortion);
    tableOfContents.getTextFrame().getParagraphs().add(paragraph);

    presentation.save("link_to_slide.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **하이퍼링크 서식 지정**

### **색상**

[Hyperlink](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Hyperlink)의 [setColorSource](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Hyperlink#setColorSource) 메서드는 하이퍼링크가 프레젠테이션의 하이퍼링크 색상을 사용할지 텍스트 부분의 서식을 사용할지를 결정합니다. 사용자 정의 텍스트 색상을 적용하려면 [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/HyperlinkColorSource)를 선택하고 해당 부분의 채우기 색을 설정합니다. 이 기능은 PowerPoint 2019에서 도입되었으며 이전 버전에서는 적용되지 않습니다.

다음 예제는 동일한 슬라이드에 두 개의 텍스트 하이퍼링크를 추가합니다. 첫 번째는 빨간색 텍스트 채우기를 사용하고, 두 번째는 기본 하이퍼링크 색상을 유지합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const coloredShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 450, 50, false);
    coloredShape.addTextFrame("This hyperlink uses a custom color.");
    const coloredPortionFormat = coloredShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    coloredPortionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    coloredPortionFormat.getHyperlinkClick().setColorSource(aspose.slides.HyperlinkColorSource.PortionFormat);
    coloredPortionFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    coloredPortionFormat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));

    const defaultShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 450, 50, false);
    defaultShape.addTextFrame("This hyperlink uses the default color.");
    defaultShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));

    presentation.save("presentation-out-hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **소리**

하이퍼링크는 활성화될 때 사운드를 재생하거나 이미 재생 중인 사운드를 중지할 수 있습니다. 다음 메서드를 사용하여 이러한 동작을 구성합니다:

- [Hyperlink.setSound](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Hyperlink#setSound) 은 하이퍼링크와 연결된 오디오를 지정합니다.
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick) 은 하이퍼링크를 활성화할 때 이전 사운드를 중지할지 여부를 제어합니다.

#### **하이퍼링크 사운드 추가**

다음 예제는 `sampleaudio.wav` 파일을 로드하고 첫 번째 슬라이드의 버튼에 연결합니다. 버튼을 클릭하면 사운드가 재생되고 다음 슬라이드로 이동합니다. 같은 슬라이드의 두 번째 도형은 클릭 시 이전 사운드를 중지하지만 네비게이션 동작은 수행하지 않습니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sampleaudio.wav");
    let hyperlinkSound;
    try {
        hyperlinkSound = presentation.getAudios().addAudio(audioStream);
    } finally {
        audioStream.close();
    }

    const firstSlide = presentation.getSlides().get_Item(0);

    const playButton = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.SoundButton, 100, 100, 100, 50);
    playButton.setHyperlinkClick(aspose.slides.Hyperlink.getNextSlide());

    if (!playButton.getHyperlinkClick().getStopSoundOnClick() && playButton.getHyperlinkClick().getSound() == null)
    {
        playButton.getHyperlinkClick().setSound(hyperlinkSound);
    }

    const secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    const stopButton = secondSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 100, 50);
    stopButton.setHyperlinkClick(aspose.slides.Hyperlink.getNoAction());

    stopButton.getHyperlinkClick().setStopSoundOnClick(true);

    presentation.save("hyperlink-sound.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

#### **하이퍼링크 사운드 추출**

다음 예제는 앞에서 만든 프레젠테이션을 열고 첫 번째 도형의 하이퍼링크 오디오를 [getSound](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Hyperlink#getSound) 및 [getBinaryData](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Audio#getBinaryData) 메서드를 통해 메모리로 읽어들입니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("hyperlink-sound.pptx");
try {
    if (presentation.getSlides().size() > 0 && presentation.getSlides().get_Item(0).getShapes().size() > 0) {
        const hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick();
        const sound = hyperlink == null ? null : hyperlink.getSound();
        if (sound != null) {
            const audioData = sound.getBinaryData();
            console.log("Extracted " + audioData.length + " bytes of hyperlink audio.");
        } else {
            console.log("The first shape has no hyperlink sound.");
        }
    } else {
        console.log("The presentation has no first slide or shape to inspect.");
    }
} finally {
    presentation.dispose();
}
```

### **툴팁 및 상호 작용 설정**

텍스트나 도형에 하이퍼링크를 할당한 후 다음 [Hyperlink](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Hyperlink) 메서드를 호출할 수 있습니다:

- [setTooltip](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Hyperlink#setTooltip) 은 사용자가 링크에 대한 힌트로 표시할 텍스트를 설정합니다.
- [setTargetFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Hyperlink#setTargetFrame) 은 적용 가능한 경우 상위 HTML 프레임셋 내의 대상 프레임을 지정합니다.
- [setHistory](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Hyperlink#setHistory) 은 링크를 활성화할 때 해당 목적지를 열람한 하이퍼링크 목록에 추가할지 여부를 제어합니다.
- [setHighlightClick](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Hyperlink#setHighlightClick) 은 클릭 시 하이퍼링크가 강조 표시될지 여부를 제어합니다.

## **프레젠테이션에서 하이퍼링크 제거**

[getAnyHyperlinks](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) 메서드를 사용하여 텍스트 부분 링크를 포함한 하이퍼링크 컨테이너를 수집한 후 변경합니다. 다음 예제는 첫 번째 슬라이드에서 두 가지 활성화 유형을 모두 제거합니다. 하나만 제거하려면 [removeHyperlinkClick](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) 또는 [removeHyperlinkMouseOver](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver)만 호출하면 됩니다; 클릭 동작을 제거해도 마우스 오버 동작은 제거되지 않습니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    if (presentation.getSlides().size() > 0) {
        const found = presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks();
        const containers = [];
        for (let index = 0; index < found.size(); index++) {
            containers.push(found.get_Item(index));
        }
        for (const container of containers) {
            container.getHyperlinkManager().removeHyperlinkClick();
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
        presentation.save("pres-removed-hyperlinks.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("The presentation has no slides to process.");
    }
} finally {
    presentation.dispose();
}
```

조건 없이 제거하려면 [removeAllHyperlinks](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) 메서드를 사용하여 선택된 범위에서 두 가지 활성화 유형을 한 번에 제거합니다. 마스터, 레이아웃 및 노트에 대한 선택적 정리 및 적용 범위에 대해서는 [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks)를 참조하십시오.

## **전체 하이퍼링크 인벤토리 작성**

프레젠테이션을 배포하기 전에 인터랙티브 동작과 웹 링크를 모두 인벤토리합니다. [getAnyHyperlinks](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) 메서드는 URL 문자열의 단순 리스트가 아니라 하이퍼링크 컨테이너를 반환합니다. 각 컨테이너에 대해 [getHyperlinkClick](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Shape#getHyperlinkClick) 및 [getHyperlinkMouseOver](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Shape#getHyperlinkMouseOver)를 모두 검사합니다. 이들은 독립적이며, 같은 컨테이너가 두 동작을 모두 제공할 수 있으므로 전체 보고서에는 컨테이너당 최대 두 행이 필요합니다.

도형 수준 하이퍼링크만 스캔하면 텍스트 부분에 연결된 링크를 놓칠 수 있습니다. 대신 적절한 범위를 쿼리하고 반환된 컨테이너를 보관하여 이후에 동작을 업데이트하거나 제거할 수 있도록 합니다.

### **프레젠테이션, 슬라이드 및 텍스트 프레임 범위 쿼리**

[HyperlinkQueries](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/HyperlinkQueries) 클래스는 [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation#getHyperlinkQueries), [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/BaseSlide#getHyperlinkQueries), [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries) 를 통해 사용할 수 있습니다. 각 범위는 동일한 쿼리를 지원합니다:

- [getHyperlinkClicks](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkClicks) 은 클릭 동작이 있는 컨테이너를 반환합니다.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkMouseOvers) 은 마우스 오버 동작이 있는 컨테이너를 반환합니다.
- [getAnyHyperlinks](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) 은 하나 또는 두 동작이 있는 컨테이너를 반환합니다.

다음 예제는 외부 클릭 링크, 파일 마우스 오버 링크, 내부 슬라이드 네비게이션, 텍스트 마우스 오버 링크 및 매크로 동작을 포함하는 `hyperlink-audit-input.pptx` 파일을 생성합니다. 이 예제는 이러한 동작을 실행하지 않습니다. 동일한 세 가지 쿼리는 모든 범위에서 작동하며, 카운트는 컨테이너 수를 나타내며 동작 총합이 아닙니다. 텍스트 프레임 범위는 포함하는 도형 자체의 링크를 제외합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

function printQueryCounts(scope, queries) {
const clickCount = queries.getHyperlinkClicks().size();
const mouseOverCount = queries.getHyperlinkMouseOvers().size();
const anyCount = queries.getAnyHyperlinks().size();
console.log(scope + ": click=" + clickCount + ", mouse-over=" + mouseOverCount + ", any=" + anyCount);
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide());
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Click the text to go to slide 2");
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/");
    shape.getHyperlinkClick().setTooltip("Public website");
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    const portionFormat = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.getHyperlinkManager().setInternalHyperlinkClick(destination);
    portionFormat.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help");
    const macroButton = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 120, 200, 60);
    macroButton.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation");

    printQueryCounts("Presentation", presentation.getHyperlinkQueries());
    printQueryCounts("Slide 1", slide.getHyperlinkQueries());
    printQueryCounts("Text frame", shape.getTextFrame().getHyperlinkQueries());
    presentation.save("hyperlink-audit-input.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

이 예제에서는 프레젠테이션 및 슬라이드 쿼리가 각각 클릭 컨테이너 3개, 마우스 오버 컨테이너 2개, 어느 동작이든 포함하는 컨테이너 3개를 보고합니다. 텍스트 프레임 쿼리는 각 카테고리마다 하나의 컨테이너를 보고합니다.

### **동작 및 목적지 분류**

[Hyperlink.getActionType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Hyperlink#getActionType) 메서드를 사용하여 목적지를 해석하기 전에 동작을 해석합니다. [HyperlinkActionType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/HyperlinkActionType) 값은 웹 네비게이션을 넘어 다양한 동작을 포함합니다:

| 값 | 감사 시 의미 |
| --- | --- |
| `Hyperlink` | 외부 하이퍼링크; URL 및 스킴을 검사합니다. |
| `JumpSpecificSlide` | 특정 슬라이드로 내부 네비게이션. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | 슬라이드쇼 내장 네비게이션, 슬라이드쇼 컨텍스트에서 해결됩니다. |
| `JumpEndShow`, `StartCustomSlideShow` | 현재 쇼를 종료하거나 맞춤 쇼를 시작합니다. |
| `StartMacro` | 매크로를 실행합니다. |
| `StartProgram` | 프로그램을 실행합니다. |
| `OpenFile`, `OpenPresentation` | 파일 또는 다른 프레젠테이션을 엽니다; 웹 URL과 별도로 검토합니다. |
| `StartStopMedia` | 미디어 재생을 시작하거나 중지합니다. |
| `NoAction`, `Unknown` | 네비게이션 동작이 없거나 인식되지 않은 동작으로 검토가 필요합니다. |

[getExternalUrl](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Hyperlink#getExternalUrl) 메서드로 외부 목적지를, [getTargetSlide](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Hyperlink#getTargetSlide) 메서드로 특정 내부 목적지를 읽습니다. 내부 동작 및 내장 명령은 외부 URL이 없을 수도 있으며, 빈 URL가 컨테이너에 동작이 없다는 의미는 아닙니다. 정규화된 URL과 다를 경우 [getExternalUrlOriginal](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Hyperlink#getExternalUrlOriginal) 로 반환된 값을 보존하고, 가능한 경우 [getTooltip](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Hyperlink#getTooltip) 로 반환된 툴팁도 포함하십시오.

### **보고, 정리 및 검증 하이퍼링크**

다음 JavaScript 예제는 기존 프레젠테이션을 읽고(위에서 생성한 파일 사용), `hyperlink-audit.json` 파일을 작성한 후 정책을 적용하고 `hyperlink-sanitized.pptx` 로 저장한 뒤 다시 열어 두 활성화 유형을 다시 확인합니다. 변경하기 전에 컨테이너를 수집하고 동일한 컨테이너를 두 번 처리하지 않도록 레퍼런스 동등성을 사용합니다. 프레젠테이션 쿼리는 일반 슬라이드를 포함하며, 패키지 전체 인벤토리를 위해서는 마스터, 레이아웃, 노트 및 노트와 핸드아웃 마스터도 명시적으로 쿼리합니다.

보고서는 가능한 경우 1부터 시작하는 슬라이드 인덱스와 [getSlideId](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/BaseSlide#getSlideId)를 기록합니다. [getSlide](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Shape#getSlide) 메서드는 지원되는 컨테이너에 대한 소유 슬라이드를 제공합니다. 마스터, 레이아웃 및 노트는 일반 슬라이드 인덱스가 없으며 범위로 식별됩니다. 도형 컨테이너와 텍스트-부분 포맷 컨테이너는 별도로 라벨링되며, 다른 컨테이너 유형은 런타임 타입 이름을 유지합니다. 각 컨테이너는 보고서 내에서 로컬 ID를 부여받아 두 동작을 연관시킬 수 있습니다. 보고서에는 HyperlinkActionType 열거형에 정의된 정수 상수 형태로 동작 유형이 저장됩니다.

이 의도적으로 제한적인 적용 정책은 절대 HTTPS URL과 유효한 내부 슬라이드 대상만 허용합니다. 매크로, 프로그램, 파일 동작, 기타 슬라이드쇼 동작, 알 수 없는 동작 및 기타 URL 스킴은 거부합니다. 이러한 거부는 정책상의 결정이며 Aspose.Slides의 안전성 판단이 아닙니다. HTTPS만으로는 신뢰를 보장하지 않으므로 애플리케이션에 호스트 허용 목록 및 기타 검사를 추가하십시오. 원본 및 정규화된 외부 URL 모두가 검사됩니다. 예제는 링크를 따라가거나 동작을 실행하지 않고 메타데이터만 감사합니다.

수정 작업을 위해 컨테이너의 [getHyperlinkManager](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Shape#getHyperlinkManager) 메서드는 [setExternalHyperlinkClick](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/HyperlinkManager#setExternalHyperlinkClick), [removeHyperlinkClick](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick), [removeHyperlinkMouseOver](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver) 를 지원합니다. 여기서는 금지된 외부 클릭 링크를 고정된 HTTPS 랜딩 페이지로 교체하고, 다른 금지된 클릭 및 금지된 마우스 오버 동작은 각각 독립적으로 제거합니다. `replaceExternalClicks` 를 `false` 로 설정하면 모든 정책 위반을 제거합니다. 배포 전에 애플리케이션이 소유한 교체 페이지를 선택하십시오.

보고서의 내보내기 플래그는 보수적인 PDF 검토 정책을 사용합니다: 마우스 오버 동작 및 외부 링크나 특정 슬라이드 점프가 아닌 모든 동작을 잠재적으로 지원되지 않을 수 있다고 표시합니다. 이는 검토 힌트이며, 기능 테스트나 표시되지 않은 링크가 내보내기에서 유지된다는 보장이 아닙니다. 지원되는 [PDF](/slides/ko/nodejs-java/convert-powerpoint-to-pdf/) 및 [HTML](/slides/ko/nodejs-java/convert-powerpoint-to-html/) 내보내기는 동작, 내보내기 옵션 및 뷰어에 따라 하이퍼링크를 보존할 수 있습니다. 래스터 [이미지](/slides/ko/nodejs-java/convert-powerpoint-to-png/)와 [비디오](/slides/ko/nodejs-java/convert-powerpoint-to-video/)는 인터랙티브 하이퍼링크를 보존할 수 없으므로 해당 출력에 대한 감사를 수행할 때 모든 동작을 표시하십시오.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

function slideIndex(presentation, slide) {
    if (slide == null) return null;
    for (let index = 0; index < presentation.getSlides().size(); index++) {
        if (presentation.getSlides().get_Item(index).equals(slide)) return index + 1;
    }
    return null;
}

function isHttps(value) {
    if (value == null || value.length === 0) return false;
    try {
        const uri = java.newInstanceSync("java.net.URI", value);
        const scheme = uri.getScheme();
        return uri.isAbsolute() && scheme != null && scheme.toLowerCase() === "https" && uri.getHost() != null;
    } catch (exception) {
        return false;
    }
}

function policyViolation(link) {
    if (link == null) return null;
    if (link.getActionType() === aspose.slides.HyperlinkActionType.JumpSpecificSlide) {
        return link.getTargetSlide() == null ? "Missing target slide" : null;
    }
    if (link.getActionType() !== aspose.slides.HyperlinkActionType.Hyperlink) return "Action is not allowed";
    if (!isHttps(link.getExternalUrl())) return "Normalized URL is not absolute HTTPS";
    const original = link.getExternalUrlOriginal();
    if (original != null && original.length > 0 && !isHttps(original)) return "Original URL is not absolute HTTPS";
    return null;
}

function collectContainers(presentation) {
    const found = [];
    function addQueries(queries) {
        const containers = queries.getAnyHyperlinks();
        for (let index = 0; index < containers.size(); index++) {
            found.push(containers.get_Item(index));
        }
    }
    function addScope(slide) {
        if (slide != null) addQueries(slide.getHyperlinkQueries());
    }
    addQueries(presentation.getHyperlinkQueries());
    for (let index = 0; index < presentation.getMasters().size(); index++) {
        addScope(presentation.getMasters().get_Item(index));
    }
    for (let index = 0; index < presentation.getLayoutSlides().size(); index++) {
        addScope(presentation.getLayoutSlides().get_Item(index));
    }
    for (let index = 0; index < presentation.getSlides().size(); index++) {
        addScope(presentation.getSlides().get_Item(index).getNotesSlideManager().getNotesSlide());
    }
    addScope(presentation.getMasterNotesSlideManager().getMasterNotesSlide());
    addScope(presentation.getMasterHandoutSlideManager().getMasterHandoutSlide());
    const seen = java.newInstanceSync("java.util.IdentityHashMap");
    const unique = [];
    for (const container of found) {
        if (!seen.containsKey(container)) {
            seen.put(container, true);
            unique.push(container);
        }
    }
    return unique;
}

function addRow(rows, presentation, link, activation, container, containerId) {
    if (link == null) return;
    const ownerSlide = java.instanceOf(container, "com.aspose.slides.ISlideComponent") ? container.getSlide() : null;
    const targetSlide = link.getTargetSlide();
    const violation = policyViolation(link);
    const ownerType = java.instanceOf(container, "com.aspose.slides.IShape") ? "Shape" : java.instanceOf(container, "com.aspose.slides.IPortionFormat") ? "Text portion" : container.getClass().getSimpleName();
    const ordinaryAction = link.getActionType() === aspose.slides.HyperlinkActionType.Hyperlink || link.getActionType() === aspose.slides.HyperlinkActionType.JumpSpecificSlide;
    rows.push({
        ContainerId: containerId,
        SlideIndex: slideIndex(presentation, ownerSlide),
        SlideId: ownerSlide == null ? null : ownerSlide.getSlideId(),
        Scope: ownerSlide == null ? null : ownerSlide.getClass().getSimpleName(),
        OwnerType: ownerType,
        Activation: activation,
        ActionType: link.getActionType(),
        ExternalUrl: link.getExternalUrl(),
        TargetSlideIndex: slideIndex(presentation, targetSlide),
        TargetSlideId: targetSlide == null ? null : targetSlide.getSlideId(),
        Tooltip: link.getTooltip(),
        OriginalExternalUrl: link.getExternalUrlOriginal() === link.getExternalUrl() ? null : link.getExternalUrlOriginal(),
        PotentiallyUnsafe: violation != null,
        PolicyViolation: violation,
        TargetExport: "PDF",
        PotentiallyUnsupportedByExport: activation === "mouse-over" || !ordinaryAction
    });
}

const replaceExternalClicks = true;
const replacementUrl = "https://example.com/blocked-link";
const presentation = new aspose.slides.Presentation("hyperlink-audit-input.pptx");
try {
    const containers = collectContainers(presentation);
    const rows = [];
    for (let index = 0; index < containers.length; index++) {
        const container = containers[index];
        addRow(rows, presentation, container.getHyperlinkClick(), "click", container, index + 1);
        addRow(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, index + 1);
    }
    const json = JSON.stringify(rows, null, 2);
    fs.writeFileSync("hyperlink-audit.json", json, "utf8");

    for (const container of containers) {
        const click = container.getHyperlinkClick();
        if (policyViolation(click) != null) {
            if (replaceExternalClicks && click.getActionType() === aspose.slides.HyperlinkActionType.Hyperlink) {
                container.getHyperlinkManager().setExternalHyperlinkClick(replacementUrl);
            } else {
                container.getHyperlinkManager().removeHyperlinkClick();
            }
        }
        if (policyViolation(container.getHyperlinkMouseOver()) != null) {
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
    }
    presentation.save("hyperlink-sanitized.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("hyperlink-sanitized.pptx");
    try {
        const remainingContainers = collectContainers(reopened);
        let violations = 0;
        for (const container of remainingContainers) {
            if (policyViolation(container.getHyperlinkClick()) != null) violations++;
            if (policyViolation(container.getHyperlinkMouseOver()) != null) violations++;
        }
        console.log("Audit rows: " + rows.length + "; prohibited actions after reopening: " + violations);
        if (violations !== 0) {
            console.log("Verification failed: do not distribute the saved presentation.");
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

위에서 만든 입력을 사용하면 보고서에 다섯 개의 동작 행이 포함됩니다. 파일 마우스 오버 링크와 매크로 클릭은 제거되고, HTTPS 링크와 내부 슬라이드 네비게이션은 남습니다. 검증 결과 금지된 동작이 없다고 출력됩니다. 금지된 외부 클릭 URL을 포함한 입력은 교체 분기도 실행합니다. 허용된 클릭과 금지된 마우스 오버를 가진 컨테이너는 클릭 동작을 유지합니다.

이 선택적 정리는 정책에 관계없이 선택된 범위 전체에서 두 활성화 유형을 모두 제거하는 [removeAllHyperlinks](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks)와 다릅니다. 여기서 검증은 하이퍼링크 동작만 확인하며, 포함된 VBA 프로젝트, OLE 객체 또는 기타 활성 콘텐츠를 제거하지 않으며, 내보낸 PDF 또는 HTML 파일을 검증하지도 않습니다.

## **FAQ**

**섹션 또는 섹션의 첫 슬라이드에 어떻게 링크할 수 있나요?**

PowerPoint의 섹션은 슬라이드를 그룹화하지만 내부 하이퍼링크는 개별 슬라이드를 대상으로 합니다. 섹션으로 이동하려면 해당 섹션의 첫 번째 슬라이드에 링크하십시오.

**마스터 슬라이드 요소에 하이퍼링크를 연결하면 모든 슬라이드에 적용될까요?**

예. 마스터 슬라이드 및 레이아웃 요소는 하이퍼링크를 지원합니다. 이러한 요소에 대한 링크는 해당 마스터 또는 레이아웃을 사용하는 슬라이드 쇼 중에 사용할 수 있습니다.

**PDF, HTML, 이미지 또는 비디오로 내보낼 때 하이퍼링크가 유지되나요?**

지원되는 PDF 및 HTML 내보내기는 하이퍼링크를 보존할 수 있지만, 래스터 이미지와 비디오는 보존할 수 없습니다. 자세한 내용은 [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) 섹션을 참고하십시오.