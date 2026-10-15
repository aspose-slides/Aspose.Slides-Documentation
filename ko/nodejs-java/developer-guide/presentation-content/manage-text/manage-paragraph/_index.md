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
- 글머리표 관리
- 단락 들여쓰기
- 걸이 들여쓰기
- 단락 글머리표
- 번호 매기기 목록
- 글머리표 목록
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
description: "Aspose.Slides for Node.js via Java 를 사용하여 단락, 구절, 글머리표, 번호 매기기 목록, 들여쓰기, HTML 콘텐츠 및 단락 이미지를 생성하고 서식 지정하는 방법을 배웁니다."
---
## **개요**

Aspose.Slides for Node.js via Java는 텍스트를 텍스트 프레임, 단락 및 Portion의 계층 구조로 표현합니다:

* [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) 텍스트 프레임은 도형 내의 텍스트 컨테이너를 나타내며 해당 도형의 단락 컬렉션에 대한 접근을 제공합니다.
* [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) 단락은 텍스트 프레임 내의 하나의 단락을 나타내며 구절 및 단락 수준 서식에 대한 접근을 제공합니다.
* [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) Portion은 단락 내의 텍스트 실행을 나타냅니다. 각 Portion은 자체 텍스트와 문자 수준 서식을 가질 수 있습니다.

따라서 단락은 여러 Portion을 사용하여 서로 다른 글꼴, 색상, 크기 및 기타 서식을 가진 텍스트를 포함할 수 있습니다.

## **단락 생성 및 서식 지정**

도형의 텍스트 프레임에서 단락을 생성하고 Portion을 사용하여 개별 텍스트 실행을 서식 지정합니다. 이 섹션에서는 각 단락 내에 여러 Portion을 결합하고 서로 다른 색상, 글꼴 크기 및 스타일을 적용하는 방법을 보여줍니다.

### **여러 Portion을 사용하여 단락 만들기**

다음 JavaScript 예제는 [Paragraph.getPortions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/getportions/)가 반환하는 컬렉션에 세 개의 텍스트 실행을 포함하는 세 개의 단락을 생성합니다. 기본 단락과 빈 Portion을 재사용한 뒤 나머지 단락과 Portion을 추가합니다. 서식은 [Portion.getPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/getportionformat/)을 통해 적용됩니다: 각 단락의 첫 번째 Portion은 빨간색, 굵게, 15포인트; 두 번째는 파란색, 이탤릭, 18포인트이며, 세 번째 Portion은 기본 서식을 유지합니다:

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

## **글머리표 및 번호 매기기 목록 만들기**

단락 텍스트를 기호, 번호 또는 사용자 지정 이미지가 있는 목록으로 구성합니다. 이 섹션의 예제에서는 글머리표 서식, 다중 레벨 목록 및 사용자 지정 시작 번호를 다룹니다.

### **글머리표 또는 번호 매기기 목록 만들기**

글머리표와 번호 매기기는 관련 항목을 더 쉽게 스캔할 수 있게 합니다. Aspose.Slides에서 목록 설정은 [BulletFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/)을 통해 정의됩니다.

다음 JavaScript 예제는 같은 텍스트 프레임에 기호 글머리표와 번호가 매겨진 항목을 추가합니다. [BulletFormat.setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/settype/)은 글머리표 유형을 선택하고, [BulletFormat.setChar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setchar/)은 기호를 제공하며, [BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstyle/)은 번호 매기기 스타일을 선택합니다. 두 항목 모두 높이가 100%이고 단락 들여쓰기가 25포인트인 검은색 글머리표를 사용합니다:

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

### **그림 글머리표 사용**

그림 글머리표를 사용하면 기호나 숫자 대신 사용자 지정 이미지를 사용할 수 있습니다.

다음 JavaScript 예제는 애플리케이션 작업 디렉터리에서 `image.png`를 로드하고, 이를 [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/)으로 프레젠테이션의 이미지 컬렉션에 추가한 뒤 단락 글머리표로 사용합니다. [BulletFormat.setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/settype/)을 호출하여 그림 글머리표를 사용하고, [BulletFormat.getPicture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/getpicture/)를 통해 이미지를 할당합니다. [BulletFormat.setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setheight/)을 100%로 설정하여 단락 텍스트에 비례하도록 글머리표 크기를 지정합니다:

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

### **다중 레벨 목록 만들기**

[ParagraphFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setdepth/)을 설정하여 목록의 서로 다른 레벨에 단락을 배치합니다. 최상위 레벨의 깊이는 `0`입니다.

다음 JavaScript 예제는 [ParagraphFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setdepth/) 값을 0에서 3까지 네 개의 단락에 지정하여 하나의 텍스트 프레임 내에 계층 구조를 만듭니다. 각 단락은 기호 글머리표를 사용하며, [BulletFormat.setChar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setchar/)를 사용해 원형 글머리표와 하이픈을 번갈아가며 인접 레벨을 구분합니다:

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

### **사용자 지정 값으로 번호 매기기 목록 시작**

[BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/)을 사용하여 번호 매기기 단락에 표시되는 초기 번호를 설정합니다.

다음 JavaScript 예제는 세 개의 단락에 번호 매기기를 사용하도록 [BulletFormat.setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/settype/)을 설정하고, [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) 값을 각각 2, 3, 7로 지정합니다. 시작 값은 각 단락마다 별도로 설정되어 표시되는 번호가 건너뛰게 됩니다:

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

## **단락 레이아웃 및 종결 속성 제어**

단락 여백 및 들여쓰기를 조정하여 첫 번째 줄과 줄바꿈된 줄의 위치를 제어합니다. 또한 단락 종결 표시를 보이는 텍스트 구절과 별도로 서식 지정할 수 있습니다.

### **첫 줄 들여쓰기 설정**

[ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) 메서드를 사용하여 단락의 첫 줄 들여쓰기를 제어합니다. 이 설정은 단락 왼쪽 여백에 대해 첫 줄만 이동시킵니다. 양수 값은 첫 줄을 오른쪽으로 이동시키고, 나머지 줄은 단락 본문에 맞게 정렬됩니다.

전체 단락을 이동해야 할 경우에는 [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/)를 사용합니다. 첫 줄만 이동해야 할 경우에는 [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/)를 사용합니다.

다음 예제는 세 개의 단락에 동일한 [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) 20포인트와 [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) 값을 0, 20, 40포인트씩 적용합니다. 첫 줄은 점점 큰 오프셋에서 시작하고, 줄바꿈된 줄은 동일한 왼쪽 여백을 유지합니다:

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

![단락의 첫 줄 들여쓰기](first_line_indent.png)

### **걸이 들여쓰기 설정**

걸이 들여쓰기는 첫 줄이 나머지 줄보다 왼쪽에 시작되는 단락 레이아웃입니다. Aspose.Slides에서는 [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) 메서드에 음수 값을 지정하여 첫 줄을 왼쪽으로 이동시킵니다.

실제로는 [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/)가 단락 본문의 왼쪽 위치를 정의하고, [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/)가 해당 여백에 대한 첫 줄 위치를 정의합니다. 걸이 들여쓰기를 만들려면 양의 왼쪽 여백과 음의 들여쓰기를 설정합니다.

이 서식은 서지, 참고 문헌, 용어 사전 항목 등 줄바꿈된 줄이 첫 줄 첫 글자 아래가 아니라 단락 본문 아래에 정렬되어야 하는 경우에 유용합니다.

다음 JavaScript 예제는 [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) 값을 40과 60포인트로, [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) 값을 -20과 -30포인트로 지정합니다. 각 단락에서 첫 줄은 줄바꿈된 줄보다 왼쪽에서 시작하며, 두 번째 단락은 더 깊은 걸이 들여쓰기를 가집니다:

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

![단락의 걸이 들여쓰기](hanging_indent.png)

### **단락 종결 실행 속성 설정**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) 메서드는 단락 종결 표시의 서식을 제어합니다. 다음 예제는 [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/)을 생성하고, [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) 를 48포인트, [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLatinFont) 를 Times New Roman으로 설정합니다. 이 서식을 두 번째 단락의 종결 표시에 할당하고, 보이는 텍스트 구절은 변경하지 않습니다:

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

## **렌더링된 줄 수 세기**

줄 끝에서 자동 줄 바꿈 및 구두점에 영향을 주는 단락 규칙에 대해서는 [Control Line Breaking](/slides/ko/nodejs-java/text-formatting/#control-line-breaking) 및 [Control Hanging Punctuation](/slides/ko/nodejs-java/text-formatting/#control-hanging-punctuation)을 참고하십시오.

[Paragraph.getLinesCount](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getLinesCount) 를 사용하여 텍스트 레이아웃 후 단락이 차지하는 줄 수를 셉니다. 자동 줄 바꿈을 포함합니다. 이는 프레젠테이션 템플릿에서 텍스트 길이와 레이아웃을 확인할 때 유용합니다.

단락은 [TextFrame.getParagraphs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/getparagraphs/) 에서 하나의 항목이며, 여러 렌더링된 줄을 차지할 수 있습니다. 단락 내 명시적 줄 바꿈은 새로운 줄을 강제로 만들지만 새 단락을 생성하지는 않습니다. 자동 줄 바꿈은 텍스트에 명시적 줄 바꿈 문자를 삽입하지 않고 가용 너비에 따라 줄을 생성합니다. 따라서 단락 수나 줄 바꿈 문자 수를 세는 것으로는 렌더링된 줄 수를 알 수 없습니다.

다음 예제는 텍스트 도형을 만들고, 줄 수를 계산한 뒤 도형을 좁히고, 텍스트를 짧은 문자열로 교체합니다. 예제는 [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setwraptext/) 로 줄 바꿈을 활성화하고, [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setautofittype/) 로 자동 맞춤을 비활성화하여 도형 너비가 줄 바꿈을 제어하도록 합니다. 각 측정은 [Paragraph.getLinesCount](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getLinesCount) 를 사용합니다. 도형 크기는 포인트 단위입니다. 마지막으로 예제는 또 다른 단락을 추가하고 텍스트 프레임 전체의 줄 수를 합산합니다.

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

이 텍스트와 이 차원에서는, 도형을 좁히면 줄 수가 증가하고, 짧은 문자열로 교체하면 줄 수가 감소합니다. 정확한 줄 수는 폰트 가용성 및 대체, 폰트 크기, 여백, 들여쓰기, 줄 바꿈 및 자동 맞춤 설정에 따라 달라질 수 있습니다. 템플릿을 확인할 때는 대상 환경에서 사용될 폰트 및 레이아웃 설정을 사용하십시오.

줄 수만으로 텍스트가 컨테이너를 넘는지 여부를 판단할 수 없습니다. 사용 가능한 높이, 줄 높이, 단락 및 줄 간격, 자동 맞춤 동작도 영향을 미치며, 줄 바꿈이 비활성화된 경우 단일 줄도 가용 너비를 초과할 수 있습니다.

## **단락 내용 가져오기 및 내보내기**

HTML을 사용하여 텍스트를 프레젠테이션에 가져오거나 기존 단락을 외부에서 사용할 수 있도록 내보낼 수 있습니다. 이 섹션에서는 표 셀의 단락을 포함한 개별 단락을 이미지로 렌더링하는 방법도 보여줍니다.

### **HTML 텍스트를 단락으로 가져오기**

[ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/) 를 사용하면 HTML 마크업을 텍스트 프레임 내의 단락 및 Portion으로 변환할 수 있습니다.

다음 JavaScript 예제는 애플리케이션 작업 디렉터리의 `file.html` 에서 HTML을 읽어 [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/) 에 전달합니다. 텍스트 프레임의 기본 단락을 지워 프레임에 가져온 내용만 포함되도록 합니다. 사각형 도형은 슬라이드 각 면에 10포인트 여백을 남깁니다:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeWidth = presentation.getSlideSize().getSize().getWidth() - 20;
    const shapeHeight = presentation.getSlideSize().getSize().getHeight() - 20;
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().getParagraphs().clear();

    const html = fs.readFileSync("file.html", "utf8");
    shape.getTextFrame().getParagraphs().addFromHtml(html);
    presentation.save("html_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **단락 텍스트를 HTML로 내보내기**

[ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) 를 사용하여 선택한 단락 범위를 HTML로 내보낼 수 있습니다. 프레젠테이션 텍스트를 웹사이트에 재사용할 때, 프레젠테이션의 글꼴, 크기 또는 텍스트 상자 스타일을 유지하지 않고 로컬 강조만 유지하고 싶을 수 있습니다. [TextToHtmlConversionOptions.setTextInheritanceLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/texttohtmlconversionoptions/settextinheritancelimit/) 을 설정하여 내보내기가 서식 상속을 얼마나 따라갈지 제어합니다.

[샘플 프레젠테이션](text-inheritance.pptx) 을 다운로드하고 애플리케이션 작업 디렉터리에 배치하십시오. 첫 번째 슬라이드에는 텍스트 "Inherited text; explicit red 18pt"가 있는 텍스트 도형 하나가 들어 있습니다. 입력은 의도적으로 여러 서식 레벨을 사용합니다:

- 프레젠테이션 기본 텍스트 스타일은 Calibri와 28pt 크기를 제공합니다.
- 텍스트 프레임의 1단계 텍스트 스타일은 파란색 텍스트와 이탤릭을 제공합니다.
- 단락은 굵은 텍스트를 명시적으로 설정합니다.
- 두 번째 Portion인 "explicit red 18pt"는 빨간색 텍스트와 18pt 크기를 명시적으로 설정합니다.

다음 전체 예제는 동일한 단락을 세 번 내보냅니다. [TextToHtmlConversionOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/texttohtmlconversionoptions/) 을 내보내기 메서드에 전달하고, 각각의 결과를 별도의 UTF-8 HTML 파일로 기록합니다:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("text-inheritance.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        const textFrame = shape.getTextFrame();
        if (textFrame !== null) {
            const paragraphs = textFrame.getParagraphs();

            const modes = [aspose.slides.TextInheritanceLimit.All, aspose.slides.TextInheritanceLimit.TextBox, aspose.slides.TextInheritanceLimit.ParagraphOnly];
            const fileNames = ["All.html", "TextBox.html", "ParagraphOnly.html"];

            for (let i = 0; i < modes.length; i++) {
                const options = new aspose.slides.TextToHtmlConversionOptions();
                options.setTextInheritanceLimit(modes[i]);

                const html = paragraphs.exportToHtml(0, paragraphs.getCount(), options);
                fs.writeFileSync(fileNames[i], html, "utf8");
            }
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

생성된 HTML에는 첫 번째 Portion인 "Inherited text; "에 대한 다음 CSS가 포함됩니다. 표는 관련 선언을 나열하고, 다른 생성 속성은 명확성을 위해 생략했습니다.

| 출력 | 첫 번째 구절에 대한 관련 CSS | 모양 |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Calibri가 사용 가능하면 28pt, 파란색, 굵게, 이탤릭 텍스트 |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | 파란색, 굵게, 이탤릭 텍스트; 주변 페이지 또는 브라우저가 글꼴 패밀리와 크기를 제공합니다 |
| `ParagraphOnly.html` | `font-weight:bold` | 굵은 텍스트; 주변 페이지 또는 브라우저가 글꼴 패밀리, 크기, 색상 및 이탤릭 스타일을 제공합니다 |

두 번째 Portion은 세 출력 모두에서 `color:#ff0000`, `font-size:18pt`, `font-weight:bold` 를 유지합니다. 또한 `All` 및 `TextBox`에서는 이탤릭을 유지하지만 `ParagraphOnly`에서는 유지하지 않습니다. 상속 제한은 단락이나 Portion에 명시적으로 지정된 서식을 제거하지 않음을 보여줍니다.

같은 브라우저에서 파일을 열어 비교하십시오. 제한된 두 모드에서는 누락된 CSS 속성이 목적지 페이지 스타일이나 브라우저 기본값에 의해 해결되므로 최종 모양은 HTML이 사용되는 위치에 따라 달라집니다.

### **단락을 이미지로 렌더링**

[Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) 은 개별 단락을 직접 렌더링하고 [IImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/) 를 반환합니다. 결과를 [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) 로 파일이나 스트림에 저장하십시오. 포함된 도형을 렌더링하거나 비트맵을 수동으로 자를 필요가 없습니다.

[Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) 은 단락이 상위 컬렉션에 없거나 유효한 렌더링 경계가 없거나 렌더링할 수 없는 경우 `null` 을 반환할 수 있습니다. 저장하기 전에 결과를 확인하고 사용 후 반환된 이미지를 해제하십시오.

#### **기본 스케일에서 단락 렌더링**

예제는 첫 번째 도형이 세 개의 단락을 포함하는 텍스트 상자인 프레젠테이션을 만듭니다.

![세 개의 단락이 있는 텍스트 상자](paragraph_to_image_input.png)

다음 예제는 인덱스 1에 있는 두 번째 단락을 선택하고 스케일 매개변수 없이 [Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) 를 호출합니다. 도형에 필요한 단락이 포함되어 있는지 확인하고, 렌더링이 이미지를 반환하는지 확인한 뒤 [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) 로 PNG 형식으로 저장합니다. `finally` 블록에서 사용 후 이미지를 해제합니다.

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

#### **테이블 셀에서 스케일을 적용하여 단락 렌더링**

`scaleX` 와 `scaleY` 매개변수를 받는 [Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) 오버로드를 사용하여 가로 및 세로 스케일을 설정합니다. 다음 예제는 표를 만든 뒤 첫 번째 셀의 단락을 기본 너비와 높이의 두 배로 렌더링하고 PNG 이미지로 저장합니다.

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

스케일 팩터 `1` 은 해당 축을 기본 픽셀 크기로 유지합니다. 예를 들어 두 축에 `2` 를 지정하면 너비와 높이가 약 두 배가 되어 픽셀이 네 배가 됩니다. 큰 팩터는 확대하거나 고해상도 출력 시 텍스트를 더 선명하게 하지만 메모리 사용량과 파일 크기도 증가합니다. `1` 이하의 팩터는 세부 정보가 적은 작은 이미지를 만듭니다. 비율을 유지하려면 동일한 팩터를 사용하고, 가로와 세로 팩터를 다르게 지정하면 출력이 각각 늘어나거나 줄어듭니다.

[Shape.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) 로 전체 도형을 렌더링하는 것이 도형의 채우기, 테두리 또는 기타 시각적 컨텍스트를 포함해야 할 때 유용합니다. 단락 전용 이미지가 필요할 때는 [Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) 를 사용하십시오.

## **FAQ**

**텍스트 프레임 내부에서 줄 바꿈을 완전히 비활성화할 수 있나요?**

예. [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setwraptext/) 을 설정하여 줄 바꿈을 비활성화하면 줄이 텍스트 프레임 가장자리를 넘어 깨지지 않습니다.

**특정 단락의 정확한 슬라이드 내 경계를 어떻게 얻을 수 있나요?**

[Paragraph.getRect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/getrect/) 을 사용하여 단락의 경계 사각형을 가져옵니다. [Portion.getRect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/getrect/) 은 개별 Portion의 경계를 제공합니다.

**단락 정렬(왼쪽, 오른쪽, 가운데 또는 양쪽 맞춤)은 어디에서 제어되나요?**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setalignment/) 은 단락 수준 설정이며 개별 Portion 서식과 관계없이 전체 단락에 적용됩니다.

각 줄에서 서로 다른 글꼴 크기의 Portion을 수직으로 정렬하려면 [Align Fonts Within a Line](/slides/ko/nodejs-java/text-formatting/#align-fonts-within-a-line) 를 참고하십시오.

**단락의 일부에 교정 언어를 설정할 수 있나요?**

예. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) 을 개별 Portion에 설정하면 하나의 단락에 여러 언어의 텍스트를 포함할 수 있습니다.