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
- 가변 하이퍼링크
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션의 하이퍼링크를 손쉽게 관리하고, 몇 분 만에 상호 작용성과 워크플로우를 향상시키세요."
---
## **소개**

하이퍼링크는 객체, 데이터 또는 특정 위치에 대한 참조입니다. 다음은 PowerPoint 프레젠테이션에서 일반적인 하이퍼링크입니다:

* 텍스트, 도형 또는 미디어 내의 웹사이트 링크
* 슬라이드 링크

Aspose.Slides for Node.js via Java는 프레젠테이션에서 하이퍼링크와 관련된 다양한 작업을 수행할 수 있게 해줍니다.

{{% alert color="primary" %}} 

Aspose 간단한, [무료 온라인 PowerPoint 편집기](https://products.aspose.app/slides/ko/editor)를 확인해 보세요.

{{% /alert %}} 

## **URL 하이퍼링크 추가**

### **텍스트에 URL 하이퍼링크 추가**

이 JavaScript 코드는 텍스트에 웹사이트 하이퍼링크를 추가하는 방법을 보여줍니다:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var shape1 = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50, false);
    shape1.addTextFrame("Aspose: File Format APIs");
    var portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    portionFormat.setFontHeight(32);
    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

### **도형 또는 프레임에 URL 하이퍼링크 추가**

이 JavaScript 샘플 코드는 도형에 웹사이트 하이퍼링크를 추가하는 방법을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50);
    shape.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    shape.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **미디어에 URL 하이퍼링크 추가**

Aspose.Slides를 사용하면 이미지, 오디오 및 비디오 파일에 하이퍼링크를 추가할 수 있습니다.

이 샘플 코드는 **이미지**에 하이퍼링크를 추가하는 방법을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // 프레젠테이션에 이미지를 추가합니다
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(picture);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // 이전에 추가한 이미지를 기반으로 슬라이드 1에 사진 프레임을 생성합니다
    var pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pictureFrame.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    pictureFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

이 샘플 코드는 **오디오 파일**에 하이퍼링크를 추가하는 방법을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var audio = pres.getAudios().addAudio(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "audio.mp3")));
    var audioFrame = pres.getSlides().get_Item(0).getShapes().addAudioFrameEmbedded(10, 10, 100, 100, audio);
    audioFrame.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    audioFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

이 샘플 코드는 **비디오**에 하이퍼링크를 추가하는 방법을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var video = pres.getVideos().addVideo(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "video.avi")));
    var videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video);
    videoFrame.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    videoFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{%  alert  title="Tip"  color="primary"  %}} 

다음 *[OLE 관리](/slides/ko/nodejs-java/manage-ole/)* 를 확인해 보세요.

{{% /alert %}}

## **하이퍼링크를 사용한 목차 만들기**

하이퍼링크를 사용하면 객체나 위치에 대한 참조를 추가할 수 있으므로 목차를 만들 때 활용할 수 있습니다.

이 샘플 코드는 하이퍼링크를 사용하여 목차를 만드는 방법을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var firstSlide = pres.getSlides().get_Item(0);
    var secondSlide = pres.getSlides().addEmptySlide(firstSlide.getLayoutSlide());
    var contentTable = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 300, 100);
    contentTable.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    contentTable.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    contentTable.getTextFrame().getParagraphs().clear();
    var paragraph = new aspose.slides.Paragraph();
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    paragraph.setText("Title of slide 2 .......... ");
    var linkPortion = new aspose.slides.Portion();
    linkPortion.setText("Page 2");
    linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);
    paragraph.getPortions().add(linkPortion);
    contentTable.getTextFrame().getParagraphs().add(paragraph);
    pres.save("link_to_slide.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **하이퍼링크 서식 지정**

### **색상**

[Hyperlink](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Hyperlink) 클래스의 [setColorSource](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Hyperlink#setColorSource-int-) 메서드를 사용하면 하이퍼링크 색상을 설정하고 하이퍼링크에서 색상 정보를 가져올 수 있습니다. 이 기능은 PowerPoint 2019에서 처음 도입되었으므로 해당 속성에 대한 변경 사항은 이전 PowerPoint 버전에는 적용되지 않습니다.

다양한 색상의 하이퍼링크가 동일한 슬라이드에 추가되는 작업을 보여주는 샘플 코드입니다:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 450, 50, false);
    shape1.addTextFrame("This is a sample of colored hyperlink.");
    var portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setColorSource(aspose.slides.HyperlinkColorSource.PortionFormat);
    portionFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portionFormat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    var shape2 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 450, 50, false);
    shape2.addTextFrame("This is a sample of usual hyperlink.");
    shape2.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    pres.save("presentation-out-hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **프레젠테이션에서 하이퍼링크 제거**

### **텍스트에서 하이퍼링크 제거**

이 JavaScript 코드는 프레젠테이션 슬라이드의 텍스트에서 하이퍼링크를 제거하는 방법을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation("text.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let slide = pres.getSlides().get_Item(i);
        for (let j = 0; j < slide.getShapes().size(); j++) {
            let shape = slide.getShapes().get_Item(j);
            // 형상이 텍스트 프레임(IAutoShape)을 지원하는지 확인합니다.
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                var autoShape = shape;
                // 텍스트 프레임의 문단을 반복합니다
                for (let i1 = 0; i1 < autoShape.getTextFrame().getParagraphs().getCount(); i1++) {
                    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(i1);
                    // 문단의 각 구절을 반복합니다
                    for (let j1 = 0; j1 < paragraph.getPortions().getCount(); j1++) {
                        let portion = paragraph.getPortions().get_Item(j1)
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

### **도형 또는 프레임에서 하이퍼링크 제거**

이 JavaScript 코드는 프레젠테이션 슬라이드의 도형에서 하이퍼링크를 제거하는 방법을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        shape.getHyperlinkManager().removeHyperlinkClick();
    }
    pres.save("pres-removed-hyperlinks.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **가변 하이퍼링크**

[Hyperlink](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Hyperlink) 클래스는 가변입니다. 이 클래스를 사용하면 다음 속성값을 변경할 수 있습니다:

- [Hyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Hyperlink#setTargetFrame-java.lang.String-)
- [Hyperlink.setTooltip(String value)](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Hyperlink#setTooltip-java.lang.String-)
- [Hyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Hyperlink#setHistory-boolean-)
- [Hyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Hyperlink#setHighlightClick-boolean-)
- [Hyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick-boolean-)

다음 코드 스니펫은 슬라이드에 하이퍼링크를 추가하고 나중에 툴팁을 편집하는 방법을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50, false);
    shape1.addTextFrame("Aspose: File Format APIs");
    var portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    portionFormat.setFontHeight(32);
    pres.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **IHyperlinkQueries에서 지원되는 속성**

프레젠테이션, 슬라이드 또는 하이퍼링크가 정의된 텍스트에서 [HyperlinkQueries](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/HyperlinkQueries)를 액세스할 수 있습니다.

- [Presentation.getHyperlinkQueries()](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation#getHyperlinkQueries--)
- [BaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/BaseSlide#getHyperlinkQueries--)
- [TextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries--)

[HyperlinkQueries](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/HyperlinkQueries) 클래스는 다음 메서드와 속성을 지원합니다:

- [HyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkClicks--)
- [HyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkMouseOvers--)
- [HyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks--)
- [HyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks--)

## **FAQ**

**슬라이드뿐만 아니라 "섹션"이나 섹션의 첫 슬라이드로 이동하는 내부 내비게이션을 만들려면 어떻게 해야 하나요?**

PowerPoint에서 섹션은 슬라이드의 그룹이며, 내비게이션은 기술적으로 특정 슬라이드를 대상으로 합니다. "섹션으로 이동"하려면 보통 해당 섹션의 첫 슬라이드에 링크합니다.

**마스터 슬라이드 요소에 하이퍼링크를 연결하여 모든 슬라이드에서 작동하도록 할 수 있나요?**

예. 마스터 슬라이드와 레이아웃 요소는 하이퍼링크를 지원합니다. 이러한 링크는 하위 슬라이드에 표시되며 슬라이드 쇼 중에 클릭할 수 있습니다.

**PDF, HTML, 이미지 또는 비디오로 내보낼 때 하이퍼링크가 유지됩니까?**

[PDF](/slides/ko/nodejs-java/convert-powerpoint-to-pdf/)와 [HTML](/slides/ko/nodejs-java/convert-powerpoint-to-html/)에서는 일반적으로 링크가 유지됩니다. [이미지](/slides/ko/nodejs-java/convert-powerpoint-to-png/)와 [비디오](/slides/ko/nodejs-java/convert-powerpoint-to-video/)로 내보낼 경우 해당 포맷의 특성상(래스터 프레임/비디오는 하이퍼링크를 지원하지 않음) 클릭 가능성이 유지되지 않습니다.