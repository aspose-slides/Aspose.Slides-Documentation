---
title: JavaScript에서 PowerPoint 텍스트 단락 관리
linktitle: 단락 관리
type: docs
weight: 40
url: /ko/nodejs-java/manage-paragraph/
aliases:
  - /nodejs-java/paragraph/
  - /nodejs-java/portion/
keywords:
- 텍스트 추가
- 단락 추가
- 텍스트 관리
- 단락 관리
- 글머리 기호 관리
- 단락 들여쓰기
- 내어쓰기
- 단락 글머리 기호
- 번호 매긴 목록
- 글머리 기호 목록
- 단락 속성
- HTML 가져오기
- 텍스트를 HTML로
- 단락을 HTML로
- 단락을 이미지로
- 텍스트를 이미지로
- 단락 내보내기
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java를 사용하여 단락, 구절, 글머리 기호, 번호 매긴 목록, 들여쓰기, HTML 콘텐츠 및 단락 이미지를 만들고 서식 지정하는 방법을 배웁니다."
---
## **개요**

Aspose.Slides for Node.js via Java는 텍스트를 텍스트 프레임, 단락 및 구절의 계층 구조로 나타냅니다.

* [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) 텍스트 프레임은 도형 내의 텍스트 컨테이너를 나타내며, 해당 도형의 단락 컬렉션에 접근할 수 있게 합니다.
* [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) 단락은 텍스트 프레임 내의 하나의 단락을 나타내며, 구절 및 단락 수준 서식에 접근할 수 있게 합니다.
* [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) 구절은 단락 내의 텍스트 실행을 나타냅니다. 각 구절은 자체 텍스트와 글자 수준 서식을 가질 수 있습니다.

따라서 단락은 여러 구절을 사용하여 서로 다른 글꼴, 색상, 크기 및 기타 서식이 적용된 텍스트를 포함할 수 있습니다.

## **단락 만들기 및 서식 지정**

### **여러 구절이 있는 단락 만들기**

다음 단계는 세 개의 단락을 각각 세 개의 구절을 포함하는 텍스트 프레임을 생성합니다.

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 통해 해당 슬라이드에 접근합니다.
3. 슬라이드에 사각형 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/)을 추가합니다.
4. 도형의 [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/)에 접근합니다.
5. 기본 단락을 사용하고 두 개의 추가 [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) 개체를 텍스트 프레임에 추가합니다.
6. 각 단락에 세 개의 구절을 포함하도록 충분한 [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) 개체를 추가합니다. 기본 단락에는 이미 하나의 빈 구절이 포함되어 있습니다.
7. 각 구절의 텍스트를 설정합니다.
8. [Portion.getPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/getportionformat/)을 통해 글자 수준 서식을 적용합니다.
9. 수정된 프레젠테이션을 저장합니다.

다음 JavaScript 예제가 위 단계를 구현합니다:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 300, 150);
    const textFrame = shape.getTextFrame();

    const firstParagraph = textFrame.getParagraphs().get_Item(0);
    firstParagraph.getPortions().add(new aspose.slides.Portion());
    firstParagraph.getPortions().add(new aspose.slides.Portion());

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    textFrame.getParagraphs().add(secondParagraph);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    textFrame.getParagraphs().add(thirdParagraph);

    const paragraphCount = textFrame.getParagraphs().getCount();
    for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
        const portionCount = paragraph.getPortions().getCount();
        for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            const portion = paragraph.getPortions().get_Item(portionIndex);
            portion.setText("Portion " + (paragraphIndex + 1) + "." + (portionIndex + 1));

            if (portionIndex === 0) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
                portion.getPortionFormat().setFontHeight(15);
            } else if (portionIndex === 1) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
                portion.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    presentation.save("paragraphs_with_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **글머리 기호 및 번호 목록 만들기**

### **글머리 기호 또는 번호 목록 만들기**

글머리 기호와 번호는 관련 항목을 빠르게 파악하도록 도와줍니다. Aspose.Slides에서는 [BulletFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/)을 통해 목록 설정을 정의합니다.

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 통해 해당 슬라이드에 접근합니다.
3. 선택한 슬라이드에 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/)를 추가합니다.
4. 도형의 [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/)에 접근합니다.
5. 텍스트 프레임에서 기본 단락을 제거합니다.
6. 기호 글머리 기호용 [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/)을 생성합니다.
7. [BulletFormat.setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/settype/)을 [BulletType.Symbol](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bullettype/)으로 설정하고 글머리 기호 문자를 지정합니다.
8. 단락 텍스트, 들여쓰기, 글머리 기호 색상 및 높이를 설정합니다.
9. 단락을 텍스트 프레임에 추가합니다.
10. 두 번째 단락을 생성하고 [BulletFormat.setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/settype/)을 [BulletType.Numbered](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bullettype/)으로 설정합니다.
11. 번호 매긴 글머리 기호 스타일을 구성하고 단락을 텍스트 프레임에 추가합니다.
12. 프레젠테이션을 저장합니다.

다음 JavaScript 예제가 기호 글머리 기호와 번호 매긴 글머리 기호를 생성합니다:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const symbolParagraph = new aspose.slides.Paragraph();
    symbolParagraph.setText("Welcome to Aspose.Slides");
    symbolParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    symbolParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    symbolParagraph.getParagraphFormat().setIndent(25);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    symbolParagraph.getParagraphFormat().getBullet().setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    symbolParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(symbolParagraph);

    const numberedParagraph = new aspose.slides.Paragraph();
    numberedParagraph.setText("This is a numbered item");
    numberedParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    numberedParagraph.getParagraphFormat().getBullet().setNumberedBulletStyle(java.newByte(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain));
    numberedParagraph.getParagraphFormat().setIndent(25);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    numberedParagraph.getParagraphFormat().getBullet().setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    numberedParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(numberedParagraph);

    presentation.save("bulleted_and_numbered_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **그림 글머리 기호 사용**

그림 글머리 기호를 사용하면 기호나 숫자 대신 사용자 지정 이미지를 사용할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 통해 해당 슬라이드에 접근합니다.
3. [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/)를 추가하고 해당 [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/)에 접근합니다.
4. 텍스트 프레임에서 기본 단락을 제거합니다.
5. 글머리 기호 이미지를 로드하고 프레젠테이션의 이미지 컬렉션에 [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/)로 추가합니다.
6. [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/)을 생성하고 텍스트를 설정합니다.
7. [BulletFormat.setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/settype/)을 [BulletType.Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bullettype/)으로 설정합니다.
8. [BulletFormat.getPicture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/getpicture/)을 통해 이미지를 지정하고 글머리 기호 높이를 설정합니다.
9. 단락을 텍스트 프레임에 추가합니다.
10. 수정된 프레젠테이션을 저장합니다.

다음 JavaScript 예제가 그림 글머리 기호를 생성합니다:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const bulletImage = aspose.slides.Images.fromFile("image.png");
    let presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(bulletImage);
    } finally {
        bulletImage.dispose();
    }

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph = new aspose.slides.Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    paragraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Picture));
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentationImage);
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(paragraph);

    presentation.save("picture_bullet.pptx", aspose.slides.SaveFormat.Pptx);
    presentation.save("picture_bullet.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

### **다단계 목록 만들기**

[ParagraphFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setdepth/)을 설정하여 단락을 목록의 서로 다른 수준에 배치합니다. 최상위 수준의 깊이는 `0`입니다.

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)을 생성하고 슬라이드에 접근합니다.
2. [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/)를 추가하고 해당 텍스트 프레임에서 기본 단락을 제거합니다.
3. 네 개의 단락을 만들고 글머리 기호 기호를 구성합니다.
4. 각 단락의 [ParagraphFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setdepth/) 값을 `0`, `1`, `2`, `3`으로 설정합니다.
5. 단락을 텍스트 프레임에 추가하고 프레젠테이션을 저장합니다.

다음 JavaScript 예제가 네 단계의 글머리 기호 목록을 생성합니다:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("Content");
    firstParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    firstParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setDepth(java.newShort(0));

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("Second level");
    secondParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    secondParagraph.getParagraphFormat().getBullet().setChar(java.newChar(45));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setDepth(java.newShort(1));

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("Third level");
    thirdParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    thirdParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.getParagraphFormat().setDepth(java.newShort(2));

    const fourthParagraph = new aspose.slides.Paragraph();
    fourthParagraph.setText("Fourth level");
    fourthParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    fourthParagraph.getParagraphFormat().getBullet().setChar(java.newChar(45));
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    fourthParagraph.getParagraphFormat().setDepth(java.newShort(3));

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);
    textFrame.getParagraphs().add(fourthParagraph);

    presentation.save("multilevel_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **번호 매긴 목록 항목을 사용자 지정 값에서 시작**

[BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/)을 사용하여 번호 매긴 단락에 표시되는 초기 번호를 설정합니다.

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)을 생성하고 슬라이드에 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/)를 추가합니다.
2. 도형의 텍스트 프레임에서 기본 단락을 제거합니다.
3. 세 개의 번호 매긴 단락을 생성합니다.
4. 각각의 단락에 대해 [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/)을 `2`, `3`, `7`로 설정합니다.
5. 단락을 텍스트 프레임에 추가하고 프레젠테이션을 저장합니다.

다음 JavaScript 예제가 각 단락에 사용자 지정 시작 번호를 할당합니다:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("Start at 2");
    firstParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    firstParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(2));
    textFrame.getParagraphs().add(firstParagraph);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("Start at 3");
    secondParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    secondParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(3));
    textFrame.getParagraphs().add(secondParagraph);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("Start at 7");
    thirdParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    thirdParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(7));
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("custom_numbered_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **단락 레이아웃 및 끝 속성 제어**

### **첫 줄 들여쓰기 설정**

[ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/)을 사용하여 단락의 첫 줄 들여쓰기를 제어합니다. 이 메서드는 단락의 왼쪽 여백에 대해 첫 번째 줄만 이동시킵니다. 양수 값은 첫 줄을 오른쪽으로 이동시키고, 나머지 줄은 단락 본문에 맞춰 정렬됩니다.

전체 단락을 이동해야 할 경우에는 [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/)를 사용하고, 첫 줄만 이동하려면 [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/)를 사용합니다.

아래 예제는 여러 단락을 만들고 서로 다른 [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) 값을 적용하여 첫 줄 들여쓰기가 단락 레이아웃에 어떤 영향을 주는지 보여줍니다.

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 대상 슬라이드에 접근합니다.
3. 슬라이드에 사각형 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/)를 추가합니다.
4. 도형의 [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/)에 접근하고 기본 단락을 제거합니다.
5. 여러 단락을 생성하고 각각에 다른 [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) 값을 설정합니다.
6. 단락을 텍스트 프레임에 추가합니다.
7. 수정된 프레젠테이션을 저장합니다.

다음 코드는 단락 들여쓰기를 설정하는 방법을 보여줍니다:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setMarginLeft(20);
    firstParagraph.getParagraphFormat().setIndent(0);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setMarginLeft(20);
    secondParagraph.getParagraphFormat().setIndent(20);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.getParagraphFormat().setMarginLeft(20);
    thirdParagraph.getParagraphFormat().setIndent(40);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![문단의 첫 번째 줄 들여쓰기](first_line_indent.png)

### **내어쓰기(행걸이) 설정**

내어쓰기는 첫 번째 줄이 나머지 줄보다 왼쪽에 시작되는 단락 레이아웃입니다. Aspose.Slides에서는 [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/)에 음수 값을 전달하여 첫 번째 줄을 왼쪽으로 이동시킵니다.

실제로는 [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/)가 단락 본문의 왼쪽 위치를 정의하고, [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/)가 그 여백에 대한 첫 줄 위치를 정의합니다. 내어쓰기를 만들려면 `setMarginLeft`에 양수 값을, `setIndent`에 음수 값을 전달합니다.

이 서식은 참고문헌, 인용구, 용어집 항목 등 줄 바꿈이 단락 본문 아래에 정렬되어야 하는 경우에 유용합니다.

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 대상 슬라이드에 접근합니다.
3. 슬라이드에 사각형 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/)를 추가합니다.
4. 도형의 [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/)에 접근하고 기본 단락을 제거합니다.
5. 각 단락에 대해 [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/)에 양수 값을 전달합니다.
6. [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/)에 음수 값을 전달하여 내어쓰기 효과를 만듭니다.
7. 단락을 텍스트 프레임에 추가합니다.
8. 수정된 프레젠테이션을 저장합니다.

다음 코드는 단락에 내어쓰기를 설정하는 방법을 보여줍니다:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setMarginLeft(40);
    firstParagraph.getParagraphFormat().setIndent(-20);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setMarginLeft(60);
    secondParagraph.getParagraphFormat().setIndent(-30);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![문단의 내어쓰기](hanging_indent.png)

### **단락 끝 실행 속성 설정**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/)은 단락 끝 표시의 서식을 제어합니다. 아래 예제는 두 번째 단락의 끝 표시에 글꼴 크기와 라틴 글꼴을 지정합니다.

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)을 생성하거나 로드하고 슬라이드에 접근합니다.
2. [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/)를 추가하고 기본 단락을 삭제합니다.
3. 두 개의 단락을 만들고 텍스트 구절을 추가합니다.
4. 두 번째 단락 끝 표시용 [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/)을 생성합니다.
5. [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight)와 [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLatinFont)를 설정합니다.
6. [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/)으로 서식을 적용하고 프레젠테이션을 저장합니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 200, 250);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getPortions().add(new aspose.slides.Portion("Sample text"));

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getPortions().add(new aspose.slides.Portion("Sample text 2"));

    const endParagraphFormat = new aspose.slides.PortionFormat();
    endParagraphFormat.setFontHeight(48);
    endParagraphFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    secondParagraph.setEndParagraphPortionFormat(endParagraphFormat);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("end_paragraph_format.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **렌더링된 행 수 세기**

줄 끝에서 자동 줄 바꿈 및 구두점 처리에 영향을 주는 단락 규칙은 [Control Line Breaking](/slides/ko/nodejs-java/text-formatting/#control-line-breaking) 및 [Control Hanging Punctuation](/slides/ko/nodejs-java/text-formatting/#control-hanging-punctuation)을 참조하십시오.

[Paragraph.getLinesCount](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getLinesCount)를 사용하면 텍스트 레이아웃 후 단락이 차지하는 행 수를 셀 수 있습니다(자동 줄 바꿈 포함). 이는 프레젠테이션 템플릿에서 텍스트 길이와 레이아웃을 확인할 때 유용합니다.

단락은 [TextFrame.getParagraphs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParagraphs)에서 하나의 항목이며, 여러 렌더링된 행을 차지할 수 있습니다. 단락 내 명시적 줄 바꿈은 새 행을 강제하지만 새로운 단락을 만들지는 않습니다. 자동 줄 바꿈은 텍스트에 명시적 줄 바꿈을 삽입하지 않고 가용 너비에 따라 행을 생성합니다. 따라서 단락 수나 줄 바꿈 문자 수만으로는 실제 렌더링된 행 수를 알 수 없습니다.

아래 예제는 텍스트 도형을 만들고, 행 수를 셀하고, 도형을 좁힌 뒤 텍스트를 짧은 문자열로 교체합니다. 줄 바꿈은 활성화되고 자동 맞춤은 비활성화되어 도형 너비가 줄 바꿈을 제어하도록 합니다. 도형 크기는 포인트 단위이며, 마지막으로 또 다른 단락을 추가하고 텍스트 프레임 전체의 행 수를 합산합니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.True));
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));

    const paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    paragraph.setText("This text demonstrates how automatic wrapping changes the number of rendered lines.");
    console.log("Original width: " + paragraph.getLinesCount());

    shape.setWidth(150);
    console.log("Narrower shape: " + paragraph.getLinesCount());

    paragraph.setText("Short text.");
    console.log("Shorter text: " + paragraph.getLinesCount());

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("Another paragraph.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    textFrame.getParagraphs().add(secondParagraph);

    let totalLineCount = 0;
    for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
        const currentParagraph = textFrame.getParagraphs().get_Item(i);
        totalLineCount += currentParagraph.getLinesCount();
    }
    console.log("Total lines in the text frame: " + totalLineCount);
} finally {
    presentation.dispose();
}
```

이 텍스트와 차원에서는 도형을 좁히면 행 수가 증가하고, 짧은 문자열로 교체하면 감소합니다. 정확한 행 수는 글꼴 가용성 및 대체, 글꼴 크기, 여백, 들여쓰기, 줄 바꿈 및 자동 맞춤 설정에 따라 달라질 수 있습니다. 템플릿을 확인할 때는 대상 환경에 맞는 글꼴 및 레이아웃 설정을 사용하십시오.

행 수만으로 텍스트가 컨테이너를 넘는지 여부를 판단할 수 없습니다. 사용 가능한 높이, 행 높이, 단락 및 행 간격, 자동 맞춤 동작도 영향을 미칩니다; 자동 맞춤이 비활성화된 경우 한 줄만 있어도 가용 너비를 초과할 수 있습니다.

## **단락 내용 가져오기 및 내보내기**

### **HTML 텍스트를 단락으로 가져오기**

[ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/)을 사용하면 HTML 마크업을 텍스트 프레임 내의 단락 및 구절로 변환할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 슬라이드에 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/)를 추가합니다.
3. 도형의 [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/)에 접근하고 기본 단락을 삭제합니다.
4. 소스 HTML 문자열을 정의하거나 읽어옵니다.
5. HTML 문자열을 [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/)에 전달합니다.
6. 수정된 프레젠테이션을 저장합니다.

다음 JavaScript 예제가 텍스트 프레임에 HTML을 가져옵니다:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shapeWidth = presentation.getSlideSize().getSize().getWidth() - 20;
    const shapeHeight = presentation.getSlideSize().getSize().getHeight() - 20;
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().getParagraphs().clear();

    const html = "<p><b>Aspose.Slides</b> imports HTML text into presentation paragraphs.</p>";
    shape.getTextFrame().getParagraphs().addFromHtml(html);
    presentation.save("html_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **단락 텍스트를 HTML로 내보내기**

[ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/)을 사용하면 선택한 범위의 단락을 HTML로 내보낼 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 인스턴스를 생성하거나 로드합니다.
2. 슬라이드에 접근하고 텍스트가 포함된 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/)을 찾습니다.
3. 도형의 [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/)에 접근합니다.
4. 시작 단락 인덱스와 내보낼 단락 수를 지정하여 [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/)을 호출합니다.
5. 반환된 HTML 문자열을 파일에 씁니다.

다음 자체 포함 JavaScript 예제가 텍스트 도형을 만들고 모든 단락을 내보냅니다:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 100);
    const sourceTextFrame = sourceShape.getTextFrame();
    sourceTextFrame.getParagraphs().clear();
    for (const text of ["First paragraph", "Second paragraph", "Third paragraph"]) {
        const sourceParagraph = new aspose.slides.Paragraph();
        sourceParagraph.setText(text);
        sourceTextFrame.getParagraphs().add(sourceParagraph);
    }
    const shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        const textFrame = shape.getTextFrame();
        if (textFrame !== null) {
            const paragraphs = textFrame.getParagraphs();
            const html = paragraphs.exportToHtml(0, paragraphs.getCount(), null);
            fs.writeFileSync("paragraphs.html", html, "utf8");
        } else {
            console.log("The first shape does not contain a text frame.");
        }
    } else {
        console.log("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

### **단락을 이미지로 렌더링하기**

[Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage)는 개별 단락을 직접 렌더링하고 [IImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/)를 반환합니다. 반환된 이미지는 [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save)로 파일에 저장할 수 있습니다. 컨테이너 도형을 렌더링하거나 비트맵을 수동으로 자를 필요가 없습니다.

[Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage)는 단락이 상위 컬렉션에 없거나, 유효한 렌더링 경계가 없거나, 렌더링할 수 없는 경우 `null`을 반환할 수 있습니다. 저장하기 전에 결과를 확인하고 사용 후에는 반환된 이미지를 해제하십시오.

#### **기본 스케일로 단락 렌더링**

다음 텍스트 상자에는 세 개의 단락이 포함되어 있습니다:

![세 개의 단락이 있는 텍스트 상자](paragraph_to_image_input.png)

다음 예제는 일반 텍스트 도형에서 두 번째 단락을 기본 스케일로 렌더링하고 PNG 형식으로 저장합니다. `finally` 블록은 이미지가 올바르게 해제되도록 합니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 100);
    const sourceTextFrame = sourceShape.getTextFrame();
    sourceTextFrame.getParagraphs().clear();
    for (const text of ["First paragraph", "Second paragraph", "Third paragraph"]) {
        const sourceParagraph = new aspose.slides.Paragraph();
        sourceParagraph.setText(text);
        sourceTextFrame.getParagraphs().add(sourceParagraph);
    }
    const shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        const textFrame = shape.getTextFrame();
        if (textFrame !== null && textFrame.getParagraphs().getCount() > 1) {
            const paragraph = textFrame.getParagraphs().get_Item(1);
            const paragraphImage = paragraph.getImage();

            if (paragraphImage !== null) {
                try {
                    paragraphImage.save("paragraph.png", aspose.slides.ImageFormat.Png);
                } finally {
                    paragraphImage.dispose();
                }
            } else {
                console.log("The paragraph could not be rendered.");
            }
        } else {
            console.log("The expected paragraph was not found.");
        }
    } else {
        console.log("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

결과:

![단락 이미지](paragraph_to_image_output.png)

#### **표 셀에서 스케일링을 적용해 단락 렌더링**

`scaleX`와 `scaleY` 매개변수를 받아 가로 및 세로 스케일을 설정하는 [Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) 오버로드를 사용합니다. 아래 예제는 표를 만들고 첫 번째 셀의 단락을 기본 너비와 높이의 두 배로 렌더링한 뒤 PNG 이미지로 저장합니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const scaleX = 2;
const scaleY = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const columnWidths = java.newArray("double", [300]);
    const rowHeights = java.newArray("double", [80]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);
    const paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0);
    paragraph.setText("Text in a table cell");

    const paragraphImage = paragraph.getImage(scaleX, scaleY);
    if (paragraphImage !== null) {
        try {
            paragraphImage.save("table_paragraph.png", aspose.slides.ImageFormat.Png);
        } finally {
            paragraphImage.dispose();
        }
    } else {
        console.log("The paragraph could not be rendered.");
    }
} finally {
    presentation.dispose();
}
```

스케일 계수 `1`은 해당 축을 기본 픽셀 크기로 유지합니다. 예를 들어 두 계수를 모두 `2`로 설정하면 이미지의 너비와 높이가 대략 두 배가 되어 픽셀 수가 네 배가 됩니다. 큰 계수는 확대하거나 고해상도 출력 시 텍스트를 더 선명하게 만들지만 메모리 사용량과 파일 크기도 증가합니다. `1`보다 작은 계수는 세부 정보가 적은 작은 이미지를 생성합니다. 가로와 세로 계수를 동일하게 설정하면 단락의 종횡비를 유지할 수 있으며, 서로 다르게 설정하면 출력이 각각 늘어나게 됩니다.

전체 도형을 렌더링하려면 [Shape.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage)를 사용하는 것이 여전히 유용합니다(도형의 채우기, 테두리 등 시각적 컨텍스트가 필요할 때). 단락 전용 이미지가 필요하면 [Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage)를 사용하십시오.

## **FAQ**

**텍스트 프레임 안에서 줄 바꿈을 완전히 비활성화할 수 있나요?**

예. [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setwraptext/)을 설정하면 줄 바꿈이 비활성화되어 텍스트 프레임 가장자리를 넘어선 줄이 끊기지 않습니다.

**특정 단락의 슬라이드 내 정확한 경계값을 어떻게 얻나요?**

[Paragraph.getRect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/getrect/)을 사용하면 단락의 경계 사각형을 가져올 수 있습니다. [Portion.getRect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/#getRect)은 개별 구절의 경계를 제공합니다.

**단락 정렬(왼쪽, 오른쪽, 가운데, 양쪽 맞춤)은 어디에서 제어되나요?**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setalignment/)은 단락 수준 설정이며, 개별 구절 서식과 관계없이 전체 단락에 적용됩니다.

각 줄에서 서로 다른 글꼴 크기의 구절을 수직으로 정렬하려면 [Align Fonts Within a Line](/slides/ko/nodejs-java/text-formatting/#align-fonts-within-a-line)를 참조하십시오.

**단락의 일부에 교정 언어를 설정할 수 있나요?**

예. 개별 구절에 대해 [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId)를 설정하면 하나의 단락에 여러 언어 텍스트를 포함할 수 있습니다.