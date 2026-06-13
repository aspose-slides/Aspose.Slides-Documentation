---
title: "JavaScript에서 PowerPoint 텍스트 단락 관리"
linktitle: "단락 관리"
type: docs
weight: 40
url: /ko/nodejs-java/manage-paragraph/
keywords:
- "텍스트 추가"
- "단락 추가"
- "텍스트 관리"
- "단락 관리"
- "글머리표 관리"
- "단락 들여쓰기"
- "매달린 들여쓰기"
- "단락 글머리표"
- "번호 매기기 목록"
- "글머리표 목록"
- "단락 속성"
- "HTML 가져오기"
- "텍스트를 HTML로"
- "단락을 HTML로"
- "단락을 이미지로"
- "텍스트를 이미지로"
- "단락 내보내기"
- "PowerPoint"
- "OpenDocument"
- "프레젠테이션"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Aspose.Slides for Node.js를 Java를 통해 사용하여 단락 서식을 마스터하고, PPT, PPTX 및 ODP 프레젠테이션에서 정렬, 간격 및 스타일을 최적화합니다."
---
## **소개**

Aspose.Slides는 Java에서 PowerPoint 텍스트, 단락 및 구문을 작업하는 데 필요한 모든 클래스와 클래스를 제공합니다.

* Aspose.Slides는 [TextFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/) 클래스를 제공하여 단락을 나타내는 개체를 추가할 수 있게 합니다. `TextFame` 개체는 하나 이상의 단락을 가질 수 있습니다(각 단락은 캐리지 리턴을 통해 생성됩니다).
* Aspose.Slides는 [Paragraph](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/paragraph/) 클래스를 제공하여 구문을 나타내는 개체를 추가할 수 있게 합니다. `Paragraph` 개체는 하나 이상의 구문(텍스트 구문 개체의 컬렉션)을 가질 수 있습니다.
* Aspose.Slides는 [Portion](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/portion/) 클래스를 제공하여 텍스트와 해당 서식 속성을 나타내는 개체를 추가할 수 있게 합니다.

`Paragraph` 개체는 기본 `Portion` 개체를 통해 다양한 서식 속성을 가진 텍스트를 처리할 수 있습니다.

## **여러 구문을 포함하는 여러 단락 추가**

다음 단계에서는 3개의 단락을 포함하고 각 단락마다 3개의 구문을 포함하는 텍스트 프레임을 추가하는 방법을 보여줍니다:

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 통해 해당 슬라이드에 대한 참조에 접근합니다.
3. 슬라이드에 사각형 [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape/)을 추가합니다.
4. [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape/)와 연결된 ITextFrame을 가져옵니다.
5. 두 개의 [Paragraph](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/paragraph/) 개체를 생성하고 이를 [TextFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/)의 `IParagraphs` 컬렉션에 추가합니다.
6. 각 새로운 `Paragraph`에 대해 세 개의 [Portion](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/portion/) 개체를 생성(기본 단락에는 두 개의 Portion)하고 각 `Portion` 개체를 해당 `Paragraph`의 IPortion 컬렉션에 추가합니다.
7. 각 구문에 텍스트를 설정합니다.
8. `Portion` 개체가 제공하는 서식 속성을 사용하여 각 구문에 원하는 서식을 적용합니다.
9. 수정된 프레젠테이션을 저장합니다.

다음 Javascript 코드는 구문을 포함하는 단락을 추가하는 단계를 구현한 예시입니다:

```javascript
// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
var pres = new aspose.slides.Presentation();
try {
    // 첫 번째 슬라이드에 접근합니다
    var slide = pres.getSlides().get_Item(0);
    // Rectangle 유형의 AutoShape을 추가합니다
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 300, 150);
    // AutoShape의 TextFrame에 접근합니다
    var tf = ashp.getTextFrame();
    // 다양한 텍스트 형식으로 Paragraph와 Portion을 생성합니다
    var para0 = tf.getParagraphs().get_Item(0);
    var port01 = new aspose.slides.Portion();
    var port02 = new aspose.slides.Portion();
    para0.getPortions().add(port01);
    para0.getPortions().add(port02);
    var para1 = new aspose.slides.Paragraph();
    tf.getParagraphs().add(para1);
    var port10 = new aspose.slides.Portion();
    var port11 = new aspose.slides.Portion();
    var port12 = new aspose.slides.Portion();
    para1.getPortions().add(port10);
    para1.getPortions().add(port11);
    para1.getPortions().add(port12);
    var para2 = new aspose.slides.Paragraph();
    tf.getParagraphs().add(para2);
    var port20 = new aspose.slides.Portion();
    var port21 = new aspose.slides.Portion();
    var port22 = new aspose.slides.Portion();
    para2.getPortions().add(port20);
    para2.getPortions().add(port21);
    para2.getPortions().add(port22);
    for (var i = 0; i < 3; i++) {
        for (var j = 0; j < 3; j++) {
            var portion = tf.getParagraphs().get_Item(i).getPortions().get_Item(j);
            portion.setText("Portion0" + j);
            if (j == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                portion.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (j == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
                portion.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }
    // PPTX를 디스크에 저장합니다
    pres.save("multiParaPort_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **단락 글머리표 관리**

글머리표 목록은 정보를 빠르고 효율적으로 구성하고 제시하는 데 도움이 됩니다. 글머리표가 있는 단락은 항상 읽고 이해하기 쉽습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 통해 해당 슬라이드에 대한 참조에 접근합니다.
3. 선택한 슬라이드에 [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape/)를 추가합니다.
4. 자동 도형의 [TextFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/)에 접근합니다.
5. `TextFrame`의 기본 단락을 제거합니다.
6. [Paragraph](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/paragraph/) 클래스를 사용하여 첫 번째 단락 인스턴스를 생성합니다.
7. 단락의 글머리표 `Type`을 `Symbol`로 설정하고 글머리표 문자를 지정합니다.
8. 단락의 `Text`를 설정합니다.
9. 글머리표에 대한 단락 `Indent`를 설정합니다.
10. 글머리표 색상을 지정합니다.
11. 글머리표 높이를 설정합니다.
12. 새로운 단락을 `TextFrame` 단락 컬렉션에 추가합니다.
13. 두 번째 단락을 추가하고 7~12단계를 반복합니다.
14. 프레젠테이션을 저장합니다.

다음 Javascript 코드는 단락 글머리표를 추가하는 방법을 보여줍니다:

```javascript
    // PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
    var pres = new aspose.slides.Presentation();
    try {
        // 첫 번째 슬라이드에 접근합니다
        var slide = pres.getSlides().get_Item(0);
        // AutoShape을 추가하고 접근합니다
        var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
        // AutoShape의 텍스트 프레임에 접근합니다
        var txtFrm = aShp.getTextFrame();
        // 기본 단락을 제거합니다
        txtFrm.getParagraphs().removeAt(0);
        // 단락을 생성합니다
        var para = new aspose.slides.Paragraph();
        // 단락 글머리표 스타일과 기호를 설정합니다
        para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
        para.getParagraphFormat().getBullet().setChar(8226);
        // 단락 텍스트를 설정합니다
        para.setText("Welcome to Aspose.Slides");
        // 글머리표 들여쓰기를 설정합니다
        para.getParagraphFormat().setIndent(25);
        // 글머리표 색상을 설정합니다
        para.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
        para.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
        para.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True);// IsBulletHardColor를 true로 설정하여 자체 글머리표 색상을 사용합니다
        // 글머리표 높이를 설정합니다
        para.getParagraphFormat().getBullet().setHeight(100);
        // 단락을 텍스트 프레임에 추가합니다
        txtFrm.getParagraphs().add(para);
        // 두 번째 단락을 생성합니다
        var para2 = new aspose.slides.Paragraph();
        // 단락 글머리표 유형과 스타일을 설정합니다
        para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
        para2.getParagraphFormat().getBullet().setNumberedBulletStyle(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain);
        // 단락 텍스트를 추가합니다
        para2.setText("This is numbered bullet");
        // 글머리표 들여쓰기를 설정합니다
        para2.getParagraphFormat().setIndent(25);
        // 글머리표 색상을 설정합니다
        para2.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
        para2.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
        para2.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True);// IsBulletHardColor를 true로 설정하여 자체 글머리표 색상을 사용합니다
        // 글머리표 높이를 설정합니다
        para2.getParagraphFormat().getBullet().setHeight(100);
        // 단락을 텍스트 프레임에 추가합니다
        txtFrm.getParagraphs().add(para2);
        // 수정된 프레젠테이션을 저장합니다
        pres.save("Bullet_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **그림 글머리표 관리**

글머리표 목록은 정보를 빠르고 효율적으로 구성하고 제시하는 데 도움이 됩니다. 그림 단락은 읽고 이해하기 쉽습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 통해 해당 슬라이드에 대한 참조에 접근합니다.
3. 슬라이드에 [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape/)를 추가합니다.
4. 자동 도형의 [TextFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/)에 접근합니다.
5. `TextFrame`의 기본 단락을 제거합니다.
6. [Paragraph](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/paragraph/) 클래스를 사용하여 첫 번째 단락 인스턴스를 생성합니다.
7. [PPImage](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ppimage/)에 이미지를 로드합니다.
8. 글머리표 유형을 [Picture](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ppimage/)로 설정하고 이미지를 지정합니다.
9. 단락 `Text`를 설정합니다.
10. 글머리표에 대한 단락 `Indent`를 설정합니다.
11. 글머리표 색상을 지정합니다.
12. 글머리표 높이를 설정합니다.
13. 새로운 단락을 `TextFrame` 단락 컬렉션에 추가합니다.
14. 두 번째 단락을 추가하고 이전 단계들을 반복합니다.
15. 수정된 프레젠테이션을 저장합니다.

다음 Javascript 코드는 그림 글머리표를 추가하고 관리하는 방법을 보여줍니다:

```javascript
// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
var presentation = new aspose.slides.Presentation();
try {
    // 첫 번째 슬라이드에 접근합니다
    var slide = presentation.getSlides().get_Item(0);
    // 글머리표용 이미지를 인스턴스화합니다
    var picture;
    var image = aspose.slides.Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // AutoShape을 추가하고 접근합니다
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // AutoShape의 텍스트 프레임에 접근합니다
    var textFrame = autoShape.getTextFrame();
    // 기본 단락을 제거합니다
    textFrame.getParagraphs().removeAt(0);
    // 새 단락을 생성합니다
    var paragraph = new aspose.slides.Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    // 단락 글머리표 스타일과 이미지를 설정합니다
    paragraph.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);
    // 글머리표 높이를 설정합니다
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    // 단락을 텍스트 프레임에 추가합니다
    textFrame.getParagraphs().add(paragraph);
    // 프레젠테이션을 PPTX 파일로 저장합니다
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", aspose.slides.SaveFormat.Pptx);
    // 프레젠테이션을 PPT 파일로 저장합니다
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", aspose.slides.SaveFormat.Ppt);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **다단계 글머리표 관리**

글머리표 목록은 정보를 빠르고 효율적으로 구성하고 제시하는 데 도움이 됩니다. 다단계 글머리표는 읽고 이해하기 쉽습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 통해 해당 슬라이드에 대한 참조에 접근합니다.
3. 새 슬라이드에 [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape/)를 추가합니다.
4. 자동 도형의 [TextFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/)에 접근합니다.
5. `TextFrame`의 기본 단락을 제거합니다.
6. [Paragraph](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/paragraph/) 클래스를 통해 첫 번째 단락 인스턴스를 생성하고 깊이를 0으로 설정합니다.
7. `Paragraph` 클래스를 통해 두 번째 단락 인스턴스를 생성하고 깊이를 1로 설정합니다.
8. `Paragraph` 클래스를 통해 세 번째 단락 인스턴스를 생성하고 깊이를 2로 설정합니다.
9. `Paragraph` 클래스를 통해 네 번째 단락 인스턴스를 생성하고 깊이를 3으로 설정합니다.
10. 새로운 단락들을 `TextFrame` 단락 컬렉션에 추가합니다.
11. 수정된 프레젠테이션을 저장합니다.

다음 Javascript 코드는 다단계 글머리표를 추가하고 관리하는 방법을 보여줍니다:

```javascript
// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
var pres = new aspose.slides.Presentation();
try {
    // 첫 번째 슬라이드에 접근합니다
    var slide = pres.getSlides().get_Item(0);
    // AutoShape을 추가하고 접근합니다
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // 생성된 AutoShape의 텍스트 프레임에 접근합니다
    var text = aShp.addTextFrame("");
    // 기본 단락을 삭제합니다
    text.getParagraphs().clear();
    // 첫 번째 단락을 추가합니다
    var para1 = new aspose.slides.Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar(8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // 글머리표 수준을 설정합니다
    para1.getParagraphFormat().setDepth(0);
    // 두 번째 단락을 추가합니다
    var para2 = new aspose.slides.Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // 글머리표 수준을 설정합니다
    para2.getParagraphFormat().setDepth(1);
    // 세 번째 단락을 추가합니다
    var para3 = new aspose.slides.Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar(8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // 글머리표 수준을 설정합니다
    para3.getParagraphFormat().setDepth(2);
    // 네 번째 단락을 추가합니다
    var para4 = new aspose.slides.Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // 글머리표 수준을 설정합니다
    para4.getParagraphFormat().setDepth(3);
    // 단락들을 컬렉션에 추가합니다
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);
    // 프레젠테이션을 PPTX 파일로 저장합니다
    pres.save("MultilevelBullet.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **사용자 지정 번호 매기기 목록이 있는 단락 관리**

[BulletFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/bulletformat/) 클래스는 [NumberedBulletStartWith](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) 속성 등 여러 속성을 제공하여 사용자 지정 번호 매기기 또는 서식이 적용된 단락을 관리할 수 있게 합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 단락이 포함된 슬라이드에 접근합니다.
3. 슬라이드에 [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape/)를 추가합니다.
4. 자동 도형의 [TextFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/)에 접근합니다.
5. `TextFrame`의 기본 단락을 제거합니다.
6. [Paragraph](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/paragraph/) 클래스를 통해 첫 번째 단락 인스턴스를 생성하고 [NumberedBulletStartWith](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-)을 2로 설정합니다.
7. `Paragraph` 클래스를 통해 두 번째 단락 인스턴스를 생성하고 `NumberedBulletStartWith`을 3으로 설정합니다.
8. `Paragraph` 클래스를 통해 세 번째 단락 인스턴스를 생성하고 `NumberedBulletStartWith`을 7로 설정합니다.
9. 새로운 단락들을 `TextFrame` 단락 컬렉션에 추가합니다.
10. 수정된 프레젠테이션을 저장합니다.

다음 Javascript 코드는 사용자 지정 번호 매기기 또는 서식이 적용된 단락을 추가하고 관리하는 방법을 보여줍니다:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // 생성된 AutoShape의 텍스트 프레임에 접근합니다
    var textFrame = shape.getTextFrame();
    // 기본 존재 단락을 제거합니다
    textFrame.getParagraphs().removeAt(0);
    // 첫 번째 목록
    var paragraph1 = new aspose.slides.Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth(4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith(2);
    paragraph1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph1);
    var paragraph2 = new aspose.slides.Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth(4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith(3);
    paragraph2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph2);
    var paragraph5 = new aspose.slides.Paragraph();
    paragraph5.setText("bullet 7");
    paragraph5.getParagraphFormat().setDepth(4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith(7);
    paragraph5.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph5);
    presentation.save("SetCustomBulletsNumber-slides.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **단락에 첫 줄 들여쓰기 적용**

[ParagraphFormat.setIndent](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/paragraphformat/setindent/) 메서드를 사용하여 단락의 첫 줄 들여쓰기를 제어합니다. 이 메서드는 단락의 왼쪽 여백에 상대적으로 첫 번째 줄만 이동합니다. 양수 값은 첫 줄을 오른쪽으로 이동시키고, 나머지 줄은 본문에 맞춰 정렬됩니다.

전체 단락을 이동하려면 [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/paragraphformat/setmarginleft/)를 사용합니다. 첫 줄만 이동하려면 [ParagraphFormat.setIndent](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/paragraphformat/setindent/)를 사용합니다.

아래 예제는 여러 단락을 생성하고 서로 다른 들여쓰기 값을 적용하여 첫 줄 들여쓰기가 단락 레이아웃에 미치는 영향을 보여줍니다.

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 대상 슬라이드에 접근합니다.
3. 슬라이드에 사각형 [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape/)를 추가합니다.
4. 도형에 빈 [TextFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/)을 추가하고 기본 단락을 제거합니다.
5. 여러 단락을 생성하고 각각에 대해 다른 [Indent](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/paragraphformat/setindent/) 값을 설정합니다.
6. 단락들을 텍스트 프레임에 추가합니다.
7. 수정된 프레젠테이션을 저장합니다.

다음 코드는 단락 들여쓰기를 설정하는 방법을 보여줍니다:

```js
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let rectangleShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    rectangleShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    let textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().removeAt(0);

    let firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().setMarginLeft(20);
    firstParagraph.getParagraphFormat().setIndent(0);

    let secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().setMarginLeft(20);
    secondParagraph.getParagraphFormat().setIndent(20);

    let thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().setMarginLeft(20);
    thirdParagraph.getParagraphFormat().setIndent(40);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

결과:

![단락의 첫 줄 들여쓰기](first_line_indent.png)

## **단락에 매달린 들여쓰기 적용**

매달린 들여쓰기란 첫 줄이 나머지 줄보다 왼쪽에 시작되는 단락 레이아웃을 말합니다. Aspose.Slides에서는 [ParagraphFormat.setIndent](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/paragraphformat/setindent/) 메서드에 음수 값을 지정하여 첫 줄을 본문보다 왼쪽으로 이동시킵니다.

실제로는 [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/paragraphformat/setmarginleft/)가 단락 본문의 왼쪽 위치를 정의하고, [ParagraphFormat.setIndent](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/paragraphformat/setindent/)가 그 여백에 대한 첫 줄의 위치를 정의합니다. 매달린 들여쓰기를 만들려면 양의 `MarginLeft` 값을 설정하고 음의 `Indent` 값을 지정합니다.

이 서식은 참고문헌, 인용, 용어 설명 등 줄이 단락 본문 아래에 정렬되어야 하는 경우에 유용합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 대상 슬라이드에 접근합니다.
3. 슬라이드에 사각형 [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape/)를 추가합니다.
4. 도형에 빈 [TextFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/)을 추가하고 기본 단락을 제거합니다.
5. 각 단락에 대해 양의 [MarginLeft](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) 값을 설정합니다.
6. 매달린 들여쓰기 효과를 만들기 위해 음의 [Indent](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/paragraphformat/setindent/) 값을 설정합니다.
7. 단락들을 텍스트 프레임에 추가합니다.
8. 수정된 프레젠테이션을 저장합니다.

다음 코드는 단락에 매달린 들여쓰기를 적용하는 방법을 보여줍니다:

```js
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let rectangleShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    rectangleShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    let textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().removeAt(0);

    let firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().setMarginLeft(40);
    firstParagraph.getParagraphFormat().setIndent(-20);

    let secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().setMarginLeft(60);
    secondParagraph.getParagraphFormat().setIndent(-30);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

결과:

![단락의 매달린 들여쓰기](hanging_indent.png)

## **단락 종료 실행 속성 관리**

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 위치를 통해 단락이 포함된 슬라이드에 대한 참조를 얻습니다.
1. 슬라이드에 사각형 [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape/)를 추가합니다.
1. 사각형에 두 개의 단락이 포함된 [TextFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/)을 추가합니다.
1. 단락의 `FontHeight`와 글꼴 유형을 설정합니다.
1. 단락의 End 속성을 설정합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 Javascript 코드는 PowerPoint 단락의 End 속성을 설정하는 방법을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 200, 250);
    var para1 = new aspose.slides.Paragraph();
    para1.getPortions().add(new aspose.slides.Portion("Sample text"));
    var para2 = new aspose.slides.Paragraph();
    para2.getPortions().add(new aspose.slides.Portion("Sample text 2"));
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(48);
    portionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    para2.setEndParagraphPortionFormat(portionFormat);
    shape.getTextFrame().getParagraphs().add(para1);
    shape.getTextFrame().getParagraphs().add(para2);
    pres.save(resourcesOutputPath + "pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **HTML 텍스트를 단락으로 가져오기**

Aspose.Slides는 HTML 텍스트를 단락으로 가져오는 기능을 강화했습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 통해 해당 슬라이드에 대한 참조에 접근합니다.
3. 슬라이드에 [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape/)를 추가합니다.
4. `AutoShape`의 [TextFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/)에 접근하고 추가합니다.
5. `TextFrame`의 기본 단락을 제거합니다.
6. TextReader를 사용하여 소스 HTML 파일을 읽습니다.
7. [Paragraph](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/paragraph/) 클래스를 통해 첫 번째 단락 인스턴스를 생성합니다.
8. 읽은 TextReader의 HTML 내용을 TextFrame의 [ParagraphCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/paragraphcollection/)에 추가합니다.
9. 수정된 프레젠테이션을 저장합니다.

다음 Javascript 코드는 HTML 텍스트를 단락으로 가져오는 단계 구현 예시입니다:

```javascript
// 빈 프레젠테이션 인스턴스를 생성합니다
var pres = new aspose.slides.Presentation();
try {
    // 프레젠테이션의 기본 첫 번째 슬라이드에 접근합니다
    var slide = pres.getSlides().get_Item(0);
    // HTML 내용을 수용하기 위해 AutoShape을 추가합니다
    var ashape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, pres.getSlideSize().getSize().getWidth() - 20, pres.getSlideSize().getSize().getHeight() - 10);
    ashape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // 도형에 텍스트 프레임을 추가합니다
    ashape.addTextFrame("");
    // 추가된 텍스트 프레임의 모든 단락을 제거합니다
    ashape.getTextFrame().getParagraphs().clear();
    // 스트림 리더를 사용해 HTML 파일을 로드합니다
    var tr = java.newInstanceSync("StreamReader", "file.html");
    // 텍스트 프레임에 HTML 스트림 리더의 텍스트를 추가합니다
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());
    // 프레젠테이션을 저장합니다
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **단락 텍스트를 HTML로 내보내기**

Aspose.Slides는 단락에 포함된 텍스트를 HTML로 내보내는 기능을 강화했습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성하고 원하는 프레젠테이션을 로드합니다.
2. 인덱스를 통해 해당 슬라이드에 대한 참조에 접근합니다.
3. HTML로 내보낼 텍스트가 포함된 도형에 접근합니다.
4. 도형의 [TextFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/)에 접근합니다.
5. `StreamWriter` 인스턴스를 생성하고 새 HTML 파일을 추가합니다.
6. 시작 인덱스를 `StreamWriter`에 제공하고 원하는 단락을 내보냅니다.

다음 Javascript 코드는 PowerPoint 단락 텍스트를 HTML로 내보내는 방법을 보여줍니다:

```javascript
// 프레젠테이션 파일을 로드합니다
var pres = new aspose.slides.Presentation("ExportingHTMLText.pptx");
try {
    // 프레젠테이션의 기본 첫 번째 슬라이드에 접근합니다
    var slide = pres.getSlides().get_Item(0);
    // 원하는 인덱스
    var index = 0;
    // 추가된 도형에 접근합니다
    var ashape = slide.getShapes().get_Item(index);
    // 출력 HTML 파일을 생성합니다
    var os = java.newInstanceSync("java.io.FileOutputStream", "output.html");
    var writer = java.newInstanceSync("java.io.OutputStreamWriter", os, "UTF-8");
    // 첫 번째 단락을 HTML로 추출합니다
    // 단락 시작 인덱스와 복사할 총 단락 수를 지정하여 단락 데이터를 HTML로 작성합니다
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **단락을 이미지로 저장**

이 섹션에서는 [Paragraph](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/paragraph/) 클래스로 표현되는 텍스트 단락을 이미지로 저장하는 두 가지 예제를 살펴봅니다. 두 예제 모두 [Shape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/) 클래스의 `getImage` 메서드를 사용해 단락을 포함하는 도형의 이미지를 얻고, 도형 내 단락의 경계를 계산한 뒤 비트맵 이미지로 내보내는 과정을 포함합니다. 이러한 방법을 통해 PowerPoint 프레젠테이션에서 텍스트의 특정 부분을 추출하여 별도 이미지로 저장할 수 있어 다양한 시나리오에 활용하기 편리합니다.

예제로 사용할 프레젠테이션 파일은 sample.pptx이며, 하나의 슬라이드에 첫 번째 도형이 세 개의 단락을 포함한 텍스트 상자라고 가정합니다.

![세 개의 단락이 포함된 텍스트 상자](paragraph_to_image_input.png)

**예제 1**

이 예제에서는 두 번째 단락을 이미지로 추출합니다. 프레젠테이션의 첫 번째 슬라이드에서 도형의 이미지를 추출한 뒤, 해당 도형 텍스트 프레임에서 두 번째 단락의 경계를 계산합니다. 이후 단락을 새 비트맵 이미지에 다시 그려 PNG 형식으로 저장합니다. 이 방법은 특정 단락을 별도의 이미지로 저장하면서 텍스트의 정확한 크기와 서식을 유지해야 할 때 특히 유용합니다.

```java
const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // 메모리에서 도형을 비트맵으로 저장합니다.
    const shapeImage = firstShape.getImage();
        
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();
    shapeImageStream.flush();
    
    // 메모리에서 도형 비트맵을 생성합니다.
    const byteBuffer = java.callMethodSync(shapeImageStream, "toByteArray");    
    const javaBytes = java.newArray("byte", Array.from(byteBuffer));
    const ByteArrayInputStream = java.import("java.io.ByteArrayInputStream");
    const shapeImageInputStream = new ByteArrayInputStream(javaBytes);
    const shapeBitmap = imageio.read(shapeImageInputStream);

    // 두 번째 단락의 경계 영역을 계산합니다.
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();

    // 출력 이미지의 좌표와 크기를 계산합니다 (최소 크기 - 1x1 픽셀).
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // 도형 비트맵을 잘라서 단락 비트맵만 얻습니다.
    const paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    const file = java.newInstanceSync("java.io.File", "paragraph.png");

    imageio.write(paragraphBitmap, "png", file);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

결과:

![단락 이미지](paragraph_to_image_output.png)

**예제 2**

이 예제에서는 이전 방법에 스케일링 팩터를 추가합니다. 도형을 추출하고 스케일 팩터 `2`로 이미지로 저장하여 고해상도 출력을 얻습니다. 그런 다음 스케일을 고려하여 단락 경계를 계산합니다. 스케일링은 고품질 인쇄물 등 자세한 이미지가 필요할 때 유용합니다.

```java
const imageScaleX = 2;
const imageScaleY = imageScaleX;

const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // 스케일링을 적용하여 도형을 메모리의 비트맵으로 저장합니다.
    const shapeImage = firstShape.getImage(aspose.slides.ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();

    // 메모리에서 도형 비트맵을 생성합니다.
    const byteBuffer = java.callMethodSync(shapeImageStream, "toByteArray");    
    const javaBytes = java.newArray("byte", Array.from(byteBuffer));
    const ByteArrayInputStream = java.import("java.io.ByteArrayInputStream");
    const shapeImageInputStream = new ByteArrayInputStream(javaBytes);
    const shapeBitmap = imageio.read(shapeImageInputStream);

    // 두 번째 단락의 경계 영역을 계산합니다.
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.setRect(
            paragraphRectangle.getX() * imageScaleX,
            paragraphRectangle.getY() * imageScaleY,
            paragraphRectangle.getWidth() * imageScaleX,
            paragraphRectangle.getHeight() * imageScaleY
    );

    // 출력 이미지의 좌표와 크기를 계산합니다 (최소 크기 - 1x1 픽셀).
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // 도형 비트맵을 잘라 단락 비트맵만 얻습니다.
    const paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    const file = java.newInstanceSync("java.io.File", "paragraph.png");

    imageio.write(paragraphBitmap, "png", file);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **FAQ**

**텍스트 프레임 안에서 줄 바꿈을 완전히 비활성화할 수 있나요?**

예. 텍스트 프레임의 줄 바꿈 설정([setWrapText](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframeformat/setwraptext/))을 사용해 줄 바꿈을 끄면 프레임 가장자리에서 줄이 깨지지 않습니다.

**특정 단락의 정확한 슬라이드 상 위치를 어떻게 얻을 수 있나요?**

단락(및 단일 구문)의 경계 사각형을 가져와 슬라이드에서의 정확한 위치와 크기를 확인할 수 있습니다.

**단락 정렬(왼쪽/오른쪽/가운데/양쪽 맞춤)은 어디서 제어하나요?**

[setAlignment](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/paragraphformat/setalignment/)은 [ParagraphFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/paragraphformat/)에 있는 단락 수준 설정 메서드로, 개별 구문 서식과 무관하게 전체 단락에 적용됩니다.

**단락의 일부분(예: 한 단어)만 맞춤법 검사 언어를 설정할 수 있나요?**

예. 언어는 구문 수준([PortionFormat.setLanguageId](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/baseportionformat/#setLanguageId))에서 설정되므로 하나의 단락 내에 여러 언어를 섞어 사용할 수 있습니다.