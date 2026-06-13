---
title: 프레젠테이션에서 JavaScript를 사용한 글꼴 관리
linktitle: 글꼴 관리
type: docs
weight: 10
url: /ko/nodejs-java/manage-fonts/
keywords:
- 글꼴 관리
- 글꼴 속성
- 단락
- 텍스트 서식
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java를 사용하여 글꼴을 제어합니다: 글꼴을 삽입, 대체 및 사용자 정의 글꼴을 로드하여 PPT, PPTX 및 ODP 프레젠테이션을 명확하고 일관되게 유지합니다."
---
## **소개**

프레젠테이션에는 보통 텍스트와 이미지가 모두 포함됩니다. 텍스트는 특정 섹션이나 단어를 강조하거나 기업 스타일에 맞추기 위해 다양한 방식으로 서식이 지정될 수 있습니다. 텍스트 서식은 사용자가 프레젠테이션 내용의 모양과 느낌을 다양하게 할 수 있도록 도와줍니다. 이 문서에서는 Aspose.Slides for Node.js via Java를 사용하여 슬라이드의 텍스트 단락에 대한 글꼴 속성을 구성하는 방법을 보여줍니다.

## **글꼴 관련 속성 관리**

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
1. 인덱스를 사용하여 슬라이드의 참조를 얻습니다.
1. 슬라이드에서 [Placeholder](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/placeholder/) 모양에 접근하고 이를 [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape/)으로 형변환합니다.
1. [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape/)에서 노출되는 [TextFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/)으로부터 [Paragraph](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/paragraph/)을 가져옵니다.
1. 단락을 양쪽 정렬합니다.
1. [Paragraph](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/paragraph/)의 텍스트 [Portion](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/portion/)에 접근합니다.
1. [FontData](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontdata/)를 사용하여 글꼴을 정의하고 텍스트 [Portion](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/portion/)의 **Font**를 그에 따라 설정합니다.
   1. 글꼴을 굵게 설정합니다.
   1. 글꼴을 기울임꼴로 설정합니다.
1. [Portion](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/portion/) 객체에서 노출되는 [FillFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fillformat/)를 사용하여 글꼴 색상을 설정합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

위 단계들의 구현은 아래에 제공됩니다. 기본 프레젠테이션을 가져와 한 슬라이드의 글꼴을 서식 지정합니다. 다음 스크린샷은 입력 파일과 코드 조각이 어떻게 변경하는지를 보여줍니다. 코드는 글꼴, 색상 및 글꼴 스타일을 변경합니다.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**그림: 입력 파일의 텍스트**|

|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**그림: 업데이트된 서식이 적용된 동일한 텍스트**|

```javascript
// PPTX 파일을 나타내는 Presentation 객체를 인스턴스화합니다
var pres = new aspose.slides.Presentation("FontProperties.pptx");
try {
    // 슬라이드 위치를 사용하여 슬라이드에 접근합니다
    var slide = pres.getSlides().get_Item(0);
    // 슬라이드의 첫 번째 및 두 번째 자리 표시자에 접근하고 이를 AutoShape으로 형변환합니다
    var tf1 = slide.getShapes().get_Item(0).getTextFrame();
    var tf2 = slide.getShapes().get_Item(1).getTextFrame();
    // 첫 번째 Paragraph에 접근합니다
    var para1 = tf1.getParagraphs().get_Item(0);
    var para2 = tf2.getParagraphs().get_Item(0);
    // 단락을 양쪽 정렬합니다
    para2.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.JustifyLow);
    // 첫 번째 Portion에 접근합니다
    var port1 = para1.getPortions().get_Item(0);
    var port2 = para2.getPortions().get_Item(0);
    // 새 글꼴을 정의합니다
    var fd1 = new aspose.slides.FontData("Elephant");
    var fd2 = new aspose.slides.FontData("Castellar");
    // 새 글꼴을 Portion에 할당합니다
    port1.getPortionFormat().setLatinFont(fd1);
    port2.getPortionFormat().setLatinFont(fd2);
    // 글꼴을 굵게 설정합니다
    port1.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // 글꼴을 기울임꼴로 설정합니다
    port1.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // 글꼴 색상을 설정합니다
    port1.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    port2.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    // PPTX를 디스크에 저장합니다
    pres.save("WelcomeFont.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **텍스트 글꼴 속성 설정**
{{% alert color="primary" %}} 

**글꼴 관련 속성 관리**에서 언급했듯이, [Portion](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/portion/)은 단락 내에서 서식이 동일한 텍스트를 보관하는 데 사용됩니다. 이 문서에서는 Aspose.Slides for Node.js via Java를 사용하여 텍스트가 포함된 텍스트 상자를 만들고 특정 글꼴 및 글꼴 패밀리 범주의 다양한 속성을 정의하는 방법을 보여줍니다.

{{% /alert %}} 

텍스트 상자를 만들고 그 안의 텍스트에 대한 글꼴 속성을 설정하려면:

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
1. 인덱스를 사용하여 슬라이드의 참조를 얻습니다.
1. [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape/) 중 **Rectangle** 유형을 슬라이드에 추가합니다.
1. [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape/)와 연결된 채우기 스타일을 제거합니다.
1. [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape/)의 [TextFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/)에 접근합니다.
1. [TextFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/)에 일부 텍스트를 추가합니다.
1. [TextFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/)과 연결된 [Portion](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/portion/) 객체에 접근합니다.
1. [Portion](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/portion/)에서 사용할 글꼴을 정의합니다.
1. [Portion](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/portion/) 객체에서 노출되는 관련 속성을 사용하여 굵게, 기울임, 밑줄, 색상 및 높이와 같은 다른 글꼴 속성을 설정합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

위 단계들의 구현은 아래에 제공됩니다.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**그림: Aspose.Slides for Node.js via Java에 의해 설정된 일부 글꼴 속성이 적용된 텍스트**|

```javascript
// PPTX 파일을 나타내는 Presentation 객체를 인스턴스화합니다
var pres = new aspose.slides.Presentation();
try {
    // 첫 번째 슬라이드를 가져옵니다
    var sld = pres.getSlides().get_Item(0);
    // Rectangle 유형의 AutoShape을 추가합니다
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    // AutoShape과 연결된 모든 채우기 스타일을 제거합니다
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // AutoShape과 연결된 TextFrame에 접근합니다
    var tf = ashp.getTextFrame();
    tf.setText("Aspose TextBox");
    // TextFrame과 연결된 Portion에 접근합니다
    var port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
    // Portion에 대한 글꼴을 설정합니다
    port.getPortionFormat().setLatinFont(new aspose.slides.FontData("Times New Roman"));
    // 글꼴의 굵게 속성을 설정합니다
    port.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // 글꼴의 기울임꼴 속성을 설정합니다
    port.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // 글꼴의 밑줄 속성을 설정합니다
    port.getPortionFormat().setFontUnderline(aspose.slides.TextUnderlineType.Single);
    // 글꼴의 높이를 설정합니다
    port.getPortionFormat().setFontHeight(25);
    // 글꼴 색상을 설정합니다
    port.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    // 프레젠테이션을 디스크에 저장합니다
    pres.save("pptxFont.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```