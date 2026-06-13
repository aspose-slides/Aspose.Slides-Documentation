---
title: JavaScript에서 프레젠테이션 확대 관리
linktitle: 확대 관리
type: docs
weight: 60
url: /ko/nodejs-java/manage-zoom/
keywords:
- 확대
- 확대 프레임
- 슬라이드 확대
- 섹션 확대
- 요약 확대
- 확대 추가
- 파워포인트
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js를 사용하여 확대/축소를 만들고 사용자 정의합니다 — 섹션 간 이동, 썸네일 및 전환 효과를 PPT, PPTX 및 ODP 프레젠테이션에 추가합니다."
---
## **소개**

PowerPoint의 확대/축소 기능을 사용하면 프레젠테이션의 특정 슬라이드, 섹션 및 부분으로 자유롭게 이동할 수 있습니다. 프레젠테이션 중에 콘텐츠를 빠르게 탐색할 수 있는 이 기능은 매우 유용할 수 있습니다. 

![overview_image](overview.png)

* 전체 프레젠테이션을 한 슬라이드에 요약하려면 [요약 확대](#Summary-Zoom)를 사용합니다.
* 선택한 슬라이드만 표시하려면 [슬라이드 확대](#Slide-Zoom)를 사용합니다.
* 단일 섹션만 표시하려면 [섹션 확대](#Section-Zoom)를 사용합니다.

## **슬라이드 확대**

슬라이드 확대를 사용하면 발표 흐름을 방해하지 않고 원하는 순서대로 슬라이드 사이를 자유롭게 이동할 수 있어 프레젠테이션을 보다 역동적으로 만들 수 있습니다. 슬라이드 확대는 섹션이 많지 않은 짧은 프레젠테이션에 적합하지만 다양한 시나리오에서도 사용할 수 있습니다.

슬라이드 확대를 통해 하나의 캔버스에 있는 듯한 느낌으로 여러 정보를 자세히 들여다볼 수 있습니다. 

![overview_image](slidezoomsel.png)

슬라이드 확대 개체와 관련하여 Aspose.Slides는 [ZoomImageType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ZoomImageType) 열거형, [ZoomFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ZoomFrame) 클래스 및 [ShapeCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ShapeCollection) 클래스의 일부 메서드를 제공합니다.

### **확대 프레임 만들기**

다음과 같이 슬라이드에 확대 프레임을 추가할 수 있습니다:

1.	[Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
2.	확대 프레임을 연결할 새 슬라이드를 만듭니다. 
3.	생성한 슬라이드에 식별 텍스트와 배경을 추가합니다.
4.	첫 번째 슬라이드에 확대 프레임(생성한 슬라이드에 대한 참조 포함)을 추가합니다.
5.	수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 JavaScript 코드는 슬라이드에 확대 프레임을 만드는 방법을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // 프레젠테이션에 새 슬라이드를 추가합니다
    var slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    var slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // 두 번째 슬라이드에 배경을 생성합니다
    slide2.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // 두 번째 슬라이드에 텍스트 상자를 생성합니다
    var autoshape = slide2.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // 세 번째 슬라이드에 배경을 생성합니다
    slide3.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "darkGray"));
    // 세 번째 슬라이드에 텍스트 상자를 생성합니다
    autoshape = slide3.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");
    // ZoomFrame 개체를 추가합니다
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);
    // 프레젠테이션을 저장합니다
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **사용자 지정 이미지가 있는 확대 프레임 만들기**

Node.js용 Aspose.Slides for Java를 사용하면 다음과 같이 다른 슬라이드 미리보기 이미지를 사용한 확대 프레임을 만들 수 있습니다:
1.	[Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
2.	확대 프레임을 연결할 새 슬라이드를 만듭니다. 
3.	슬라이드에 식별 텍스트와 배경을 추가합니다.
4.	프레임을 채우는 데 사용할 [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 개체와 연결된 Images 컬렉션에 이미지를 추가하여 [PPImage](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/PPImage) 개체를 만듭니다.
5.	첫 번째 슬라이드에 확대 프레임(생성한 슬라이드에 대한 참조 포함)을 추가합니다.
6.	수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 JavaScript 코드는 다른 이미지를 사용한 확대 프레임을 만드는 방법을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // 프레젠테이션에 새 슬라이드를 추가합니다
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // 두 번째 슬라이드에 배경을 생성합니다
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // 세 번째 슬라이드에 텍스트 상자를 생성합니다
    var autoshape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // 확대 개체를 위한 새 이미지를 생성합니다
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // ZoomFrame 개체를 추가합니다
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);
    // 프레젠테이션을 저장합니다
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **확대 프레임 서식 지정**

앞섹션에서는 간단한 확대 프레임을 만드는 방법을 보여주었습니다. 보다 복잡한 확대 프레임을 만들려면 단순 프레임의 서식을 변경해야 합니다. 확대 프레임에 적용할 수 있는 서식 옵션은 여러 가지가 있습니다. 

다음과 같이 슬라이드에서 확대 프레임의 서식을 제어할 수 있습니다:

1.	[Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
2.	확대 프레임을 연결할 새 슬라이드를 만듭니다. 
3.	생성한 슬라이드에 식별 텍스트와 배경을 추가합니다.
4.	첫 번째 슬라이드에 확대 프레임(생성한 슬라이드에 대한 참조 포함)을 추가합니다.
5.	프레임을 채우는 데 사용할 [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 개체와 연결된 Images 컬렉션에 이미지를 추가하여 [PPImage](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/PPImage) 개체를 만듭니다.
6.	첫 번째 확대 프레임 개체에 사용자 지정 이미지를 설정합니다.
7.	두 번째 확대 프레임 개체의 선 서식을 변경합니다.
8.	두 번째 확대 프레임 개체 이미지의 배경을 제거합니다.
5.	수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 JavaScript 코드는 슬라이드에서 확대 프레임의 서식을 변경하는 방법을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // 프레젠테이션에 새 슬라이드를 추가합니다
    var slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    var slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // 두 번째 슬라이드에 배경을 생성합니다
    slide2.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // 두 번째 슬라이드에 텍스트 상자를 생성합니다
    var autoshape = slide2.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // 세 번째 슬라이드에 배경을 생성합니다
    slide3.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "darkGray"));
    // 세 번째 슬라이드에 텍스트 상자를 생성합니다
    autoshape = slide3.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");
    // ZoomFrame 개체를 추가합니다
    var zoomFrame1 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    var zoomFrame2 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);
    // 확대 개체를 위한 새 이미지를 생성합니다
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // zoomFrame1 개체에 사용자 지정 이미지를 설정합니다
    zoomFrame1.setImage(picture);
    // zoomFrame2 개체에 확대 프레임 서식을 설정합니다
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "pink"));
    zoomFrame2.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    // zoomFrame2 개체에 대해 배경을 표시하지 않도록 설정합니다
    zoomFrame2.setShowBackground(false);
    // 프레젠테이션을 저장합니다
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **섹션 확대**

섹션 확대는 프레젠테이션 내 섹션에 대한 링크입니다. 강조하고 싶은 섹션으로 돌아가거나 프레젠테이션의 특정 부분이 어떻게 연결되는지 강조하는 데 사용할 수 있습니다. 

![overview_image](seczoomsel.png)

섹션 확대 개체와 관련하여 Aspose.Slides는 [SectionZoomFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SectionZoomFrame) 클래스 및 [ShapeCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ShapeCollection) 클래스의 일부 메서드를 제공합니다.

### **섹션 확대 프레임 만들기**

다음과 같이 슬라이드에 섹션 확대 프레임을 추가할 수 있습니다:

1.	[Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
2.	새 슬라이드를 만듭니다. 
3.	생성한 슬라이드에 식별 배경을 추가합니다.
4.	확대 프레임을 연결할 새 섹션을 만듭니다. 
5.	첫 번째 슬라이드에 섹션 확대 프레임(생성한 섹션에 대한 참조 포함)을 추가합니다.
6.	수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 JavaScript 코드는 슬라이드에 확대 프레임을 만드는 방법을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // 프레젠테이션에 새 슬라이드를 추가합니다
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // 프레젠테이션에 새 섹션을 추가합니다
    pres.getSections().addSection("Section 1", slide);
    // SectionZoomFrame 객체를 추가합니다
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));
    // 프레젠테이션을 저장합니다
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **사용자 지정 이미지가 있는 섹션 확대 프레임 만들기**

Node.js용 Aspose.Slides for Java를 사용하면 다음과 같이 다른 슬라이드 미리보기 이미지를 사용한 섹션 확대 프레임을 만들 수 있습니다:

1.	[Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
2.	새 슬라이드를 만듭니다.
3.	생성한 슬라이드에 식별 배경을 추가합니다.
4.	확대 프레임을 연결할 새 섹션을 만듭니다. 
5.	프레임을 채우는 데 사용할 [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 개체와 연결된 Images 컬렉션에 이미지를 추가하여 [PPImage](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/PPImage) 개체를 만듭니다.
5.	첫 번째 슬라이드에 섹션 확대 프레임(생성한 섹션에 대한 참조 포함)을 추가합니다.
6.	수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 JavaScript 코드는 다른 이미지를 사용한 확대 프레임을 만드는 방법을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // 프레젠테이션에 새 슬라이드를 추가합니다
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // 프레젠테이션에 새 섹션을 추가합니다
    pres.getSections().addSection("Section 1", slide);
    // 확대 개체를 위한 새 이미지를 생성합니다
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // SectionZoomFrame 객체를 추가합니다
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1), picture);
    // 프레젠테이션을 저장합니다
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **섹션 확대 프레임 서식 지정**

보다 복잡한 섹션 확대 프레임을 만들려면 단순 프레임의 서식을 변경해야 합니다. 섹션 확대 프레임에 적용할 수 있는 서식 옵션은 여러 가지가 있습니다. 

다음과 같이 슬라이드에서 섹션 확대 프레임의 서식을 제어할 수 있습니다:

1.	[Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
2.	새 슬라이드를 만듭니다.
3.	생성한 슬라이드에 식별 배경을 추가합니다.
4.	확대 프레임을 연결할 새 섹션을 만듭니다. 
5.	첫 번째 슬라이드에 섹션 확대 프레임(생성한 섹션에 대한 참조 포함)을 추가합니다.
6.	생성한 섹션 확대 개체의 크기와 위치를 변경합니다.
7.	프레임을 채우는 데 사용할 [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 개체와 연결된 Images 컬렉션에 이미지를 추가하여 [PPImage](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/PPImage) 개체를 만듭니다.
8.	생성한 섹션 확대 프레임 개체에 사용자 지정 이미지를 설정합니다.
9.	*링크된 섹션에서 원본 슬라이드로 돌아가기* 기능을 설정합니다. 
10.	섹션 확대 프레임 개체 이미지의 배경을 제거합니다.
11.	두 번째 확대 프레임 개체의 선 서식을 변경합니다.
12.	전환 지속 시간을 변경합니다.
13.	수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 JavaScript 코드는 섹션 확대 프레임의 서식을 변경하는 방법을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // 프레젠테이션에 새 슬라이드를 추가합니다
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // 프레젠테이션에 새 섹션을 추가합니다
    pres.getSections().addSection("Section 1", slide);
    // SectionZoomFrame 객체를 추가합니다
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));
    // SectionZoomFrame의 서식 지정
    sectionZoomFrame.setX(100);
    sectionZoomFrame.setY(300);
    sectionZoomFrame.setWidth(100);
    sectionZoomFrame.setHeight(75);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    sectionZoomFrame.setImage(picture);
    sectionZoomFrame.setReturnToParent(true);
    sectionZoomFrame.setShowBackground(false);
    sectionZoomFrame.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    sectionZoomFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    sectionZoomFrame.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    sectionZoomFrame.getLineFormat().setWidth(2.5);
    sectionZoomFrame.setTransitionDuration(1.5);
    // 프레젠테이션을 저장합니다
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **요약 확대**

요약 확대는 프레젠테이션의 모든 부분을 한 번에 표시하는 랜딩 페이지와 같습니다. 발표 중에 원하는 순서대로 프레젠테이션의 한 위치에서 다른 위치로 이동할 수 있습니다. 창의적으로 진행하거나 앞쪽을 건너뛰거나 슬라이드 쇼의 일부를 다시 살펴볼 수 있어 발표 흐름을 방해하지 않습니다.

![overview_image](sumzoomsel.png)

요약 확대 개체와 관련하여 Aspose.Slides는 [SummaryZoomFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SummaryZoomFrame), [SummaryZoomSection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SummaryZoomSection) 및 [SummaryZoomSectionCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SummaryZoomSectionCollection) 클래스를 제공하며, [ShapeCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ShapeCollection) 클래스의 일부 메서드도 사용할 수 있습니다.

### **요약 확대 만들기**

다음과 같이 슬라이드에 요약 확대 프레임을 추가할 수 있습니다:

1.	[Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
2.	식별 배경과 새 섹션이 포함된 새 슬라이드를 생성합니다.
3.	첫 번째 슬라이드에 요약 확대 프레임을 추가합니다.
4.	수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 JavaScript 코드는 슬라이드에 요약 확대 프레임을 만드는 방법을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // 프레젠테이션에 새 슬라이드를 추가합니다
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // 프레젠테이션에 새 섹션을 추가합니다
    pres.getSections().addSection("Section 1", slide);
    // 프레젠테이션에 새 슬라이드를 추가합니다
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // 프레젠테이션에 새 섹션을 추가합니다
    pres.getSections().addSection("Section 2", slide);
    // 프레젠테이션에 새 슬라이드를 추가합니다
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "magenta"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // 프레젠테이션에 새 섹션을 추가합니다
    pres.getSections().addSection("Section 3", slide);
    // 프레젠테이션에 새 슬라이드를 추가합니다
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "green"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // 프레젠테이션에 새 섹션을 추가합니다
    pres.getSections().addSection("Section 4", slide);
    // SummaryZoomFrame 객체를 추가합니다
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // 프레젠테이션을 저장합니다
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **요약 확대 섹션 추가 및 제거**

요약 확대 프레임의 모든 섹션은 [SummaryZoomSection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SummaryZoomSection) 개체로 표시되며, 이는 [SummaryZoomSectionCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SummaryZoomSectionCollection) 객체에 저장됩니다. 다음과 같이 [SummaryZoomSectionCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SummaryZoomSectionCollection) 클래스를 통해 요약 확대 섹션 개체를 추가하거나 제거할 수 있습니다:

1.	[Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
2.	식별 배경과 새 섹션이 포함된 새 슬라이드를 생성합니다.
3.	첫 번째 슬라이드에 요약 확대 프레임을 추가합니다.
4.	프레젠테이션에 새 슬라이드와 섹션을 추가합니다.
5.	생성한 섹션을 요약 확대 프레임에 추가합니다.
6.	요약 확대 프레임에서 첫 번째 섹션을 제거합니다.
7.	수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 JavaScript 코드는 요약 확대 프레임에서 섹션을 추가하고 제거하는 방법을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // 프레젠테이션에 새 슬라이드를 추가합니다
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // 프레젠테이션에 새 섹션을 추가합니다
    pres.getSections().addSection("Section 1", slide);
    // 프레젠테이션에 새 슬라이드를 추가합니다
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // 프레젠테이션에 새 섹션을 추가합니다
    pres.getSections().addSection("Section 2", slide);
    // SummaryZoomFrame 객체를 추가합니다
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // 프레젠테이션에 새 슬라이드를 추가합니다
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "magenta"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // 프레젠테이션에 새 섹션을 추가합니다
    var section3 = pres.getSections().addSection("Section 3", slide);
    // Summary Zoom에 섹션을 추가합니다
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);
    // Summary Zoom에서 섹션을 제거합니다
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));
    // 프레젠테이션을 저장합니다
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **요약 확대 섹션 서식 지정**

보다 복잡한 요약 확대 섹션 개체를 만들려면 단순 프레임의 서식을 변경해야 합니다. 요약 확대 섹션 개체에 적용할 수 있는 서식 옵션은 여러 가지가 있습니다. 

다음과 같이 요약 확대 프레임 내 섹션 개체의 서식을 제어할 수 있습니다:

1.	[Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
2.	식별 배경과 새 섹션이 포함된 새 슬라이드를 생성합니다.
3.	첫 번째 슬라이드에 요약 확대 프레임을 추가합니다.
4.	`ISummaryZoomSectionCollection`에서 첫 번째 섹션 개체를 가져옵니다.
7.	프레임을 채우는 데 사용할 [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 개체와 연결된 Images 컬렉션에 이미지를 추가하여 [PPImage](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/PPImage) 개체를 만듭니다.
8.	생성한 섹션 확대 프레임 개체에 사용자 지정 이미지를 설정합니다.
9.	*링크된 섹션에서 원본 슬라이드로 돌아가기* 기능을 설정합니다. 
11.	두 번째 확대 프레임 개체의 선 서식을 변경합니다.
12.	전환 지속 시간을 변경합니다.
13.	수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 JavaScript 코드는 요약 확대 섹션 개체의 서식을 변경하는 방법을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // 프레젠테이션에 새 슬라이드를 추가합니다
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // 프레젠테이션에 새 섹션을 추가합니다
    pres.getSections().addSection("Section 1", slide);
    // 프레젠테이션에 새 슬라이드를 추가합니다
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // 프레젠테이션에 새 섹션을 추가합니다
    pres.getSections().addSection("Section 2", slide);
    // SummaryZoomFrame 객체를 추가합니다
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // 첫 번째 SummaryZoomSection 객체를 가져옵니다
    var summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);
    // SummaryZoomSection 객체의 서식 지정
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(picture);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    summarySection.setImage(picture);
    summarySection.setReturnToParent(false);
    summarySection.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    summarySection.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "black"));
    summarySection.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    summarySection.getLineFormat().setWidth(1.5);
    summarySection.setTransitionDuration(1.5);
    // 프레젠테이션을 저장합니다
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**대상 내용을 표시한 후 '상위' 슬라이드로 돌아가는 것을 제어할 수 있나요?**

예. [Zoom frame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/zoomframe/) 또는 [section](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/sectionzoomframe/) 에는 `setReturnToParent` 메서드가 있으며, 이를 활성화하면 사용자를 대상 콘텐츠를 본 후 원본 슬라이드로 되돌릴 수 있습니다.

**Zoom 전환의 '속도' 또는 지속 시간을 조정할 수 있나요?**

예. Zoom에는 `setTransitionDuration` 메서드가 있어 점프 애니메이션의 길이를 제어할 수 있습니다.

**프레젠테이션에 포함될 수 있는 Zoom 개체 수에 제한이 있나요?**

문서화된 강제 API 제한은 없습니다. 실제 제한은 전체 프레젠테이션 복잡도와 뷰어 성능에 따라 달라집니다. 많은 Zoom 프레임을 추가할 수 있지만 파일 크기와 렌더링 시간을 고려해야 합니다.