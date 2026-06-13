---
title: Java에서 프레젠테이션 줌 관리
linktitle: 줌 관리
type: docs
weight: 60
url: /ko/java/manage-zoom/
keywords:
- 줌
- 줌 프레임
- 슬라이드 줌
- 섹션 줌
- 요약 줌
- 줌 추가
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 줌을 만들고 사용자 지정하세요 — 섹션 간 이동, 썸네일 및 전환 효과를 PPT, PPTX 및 ODP 프레젠테이션에 추가합니다."
---
## **소개**

PowerPoint의 확대/축소 기능을 사용하면 프레젠테이션의 특정 슬라이드, 섹션 및 부분으로 빠르게 이동할 수 있습니다. 발표 중에 콘텐츠를 신속하게 탐색할 수 있는 이 기능은 매우 유용할 수 있습니다. 

![overview_image](overview.png)

* 전체 프레젠테이션을 한 슬라이드에 요약하려면 [Summary Zoom](#Summary-Zoom)을 사용하십시오.
* 선택한 슬라이드만 표시하려면 [Slide Zoom](#Slide-Zoom)을 사용하십시오.
* 하나의 섹션만 표시하려면 [Section Zoom](#Section-Zoom)을 사용하십시오.

## **슬라이드 확대/축소**
슬라이드 확대/축소를 사용하면 프레젠테이션을 보다 역동적으로 만들 수 있으며, 흐름을 방해하지 않으면서 원하는 순서대로 슬라이드 간을 자유롭게 이동할 수 있습니다. 슬라이드 확대/축소는 섹션이 많지 않은 짧은 프레젠테이션에 적합하지만, 다양한 프레젠테이션 시나리오에서도 사용할 수 있습니다.

슬라이드 확대/축소를 사용하면 단일 캔버스에 있는 것처럼 여러 정보 조각을 자세히 탐색할 수 있습니다. 

![overview_image](slidezoomsel.png)

슬라이드 확대/축소 개체에 대해 Aspose.Slides는 [ZoomImageType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ZoomImageType) 열거형, [IZoomFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IZoomFrame) 인터페이스 및 [IShapeCollection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IShapeCollection) 인터페이스 아래의 몇 가지 메서드를 제공합니다.

### **확대/축소 프레임 만들기**

다음과 같이 슬라이드에 확대/축소 프레임을 추가할 수 있습니다:

1.	[Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
2.	확대/축소 프레임을 연결하려는 새 슬라이드를 생성합니다. 
3.	생성된 슬라이드에 식별 텍스트와 배경을 추가합니다.
4.	첫 번째 슬라이드에 확대/축소 프레임(생성된 슬라이드에 대한 참조 포함)을 추가합니다.
5.	수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 Java 코드가 슬라이드에 확대/축소 프레임을 만드는 방법을 보여줍니다:

``` java
Presentation pres = new Presentation();
try {
    //프레젠테이션에 새 슬라이드 추가
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    //두 번째 슬라이드의 배경을 생성합니다
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    //두 번째 슬라이드에 텍스트 상자를 생성합니다
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    //세 번째 슬라이드의 배경을 생성합니다
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    //세 번째 슬라이드에 텍스트 상자를 생성합니다
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    //ZoomFrame 객체를 추가합니다
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    //프레젠테이션을 저장합니다
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **맞춤 이미지가 있는 확대/축소 프레임 만들기**
Aspose.Slides for Java를 사용하면 다음과 같이 다른 슬라이드 미리보기 이미지를 사용한 확대/축소 프레임을 만들 수 있습니다: 
1.	[Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
2.	확대/축소 프레임을 연결하려는 새 슬라이드를 생성합니다. 
3.	슬라이드에 식별 텍스트와 배경을 추가합니다.
4.	[Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation) 객체와 연결된 Images 컬렉션에 이미지를 추가하여 [IPPImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IPPImage) 객체를 만들고, 이를 프레임을 채우는 데 사용합니다.
5.	첫 번째 슬라이드에 확대/축소 프레임(생성된 슬라이드에 대한 참조 포함)을 추가합니다.
6.	수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 Java 코드가 다른 이미지를 사용한 확대/축소 프레임을 만드는 방법을 보여줍니다:

``` java
Presentation pres = new Presentation();
try {
    //프레젠테이션에 새 슬라이드 추가
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // 두 번째 슬라이드의 배경을 생성합니다
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // 세 번째 슬라이드에 텍스트 상자를 생성합니다
    IAutoShape autoshape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // 줌 객체를 위한 새로운 이미지를 생성합니다
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    //ZoomFrame 객체를 추가합니다
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);

    // 프레젠테이션을 저장합니다
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
### **확대/축소 프레임 서식 지정**
이전 섹션에서는 간단한 확대/축소 프레임을 만드는 방법을 보여주었습니다. 보다 복잡한 확대/축소 프레임을 만들려면 단순 프레임의 서식을 변경해야 합니다. 확대/축소 프레임에 적용할 수 있는 서식 옵션이 여러 가지 있습니다. 

다음과 같이 슬라이드에서 확대/축소 프레임의 서식을 제어할 수 있습니다:

1.	[Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
2.	확대/축소 프레임을 연결하려는 새 슬라이드를 생성합니다. 
3.	생성된 슬라이드에 식별 텍스트와 배경을 추가합니다.
4.	첫 번째 슬라이드에 확대/축소 프레임(생성된 슬라이드에 대한 참조 포함)을 추가합니다.
5.	[Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation) 객체와 연결된 Images 컬렉션에 이미지를 추가하여 [IPPImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IPPImage) 객체를 만들고, 이를 프레임을 채우는 데 사용합니다.
6.	첫 번째 확대/축소 프레임 객체에 맞춤 이미지를 설정합니다.
7.	두 번째 확대/축소 프레임 객체의 선 서식을 변경합니다.
8.	두 번째 확대/축소 프레임 객체 이미지의 배경을 제거합니다.
5.	수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 Java 코드가 슬라이드에서 확대/축소 프레임의 서식을 변경하는 방법을 보여줍니다: 

``` java 
Presentation pres = new Presentation();
try {
    //프레젠테이션에 새 슬라이드 추가
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    //두 번째 슬라이드의 배경을 생성합니다
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    //두 번째 슬라이드에 텍스트 상자를 생성합니다
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    //세 번째 슬라이드의 배경을 생성합니다
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    //세 번째 슬라이드에 텍스트 상자를 생성합니다
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    //ZoomFrame 객체를 추가합니다
    IZoomFrame zoomFrame1 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    //줌 객체를 위한 새로운 이미지를 생성합니다
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    //zoomFrame1 객체에 맞춤 이미지를 설정합니다
    zoomFrame1.setImage(picture);

    //zoomFrame2 객체에 줌 프레임 서식을 설정합니다
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink);
    zoomFrame2.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    //zoomFrame2 객체에 배경을 표시하지 않도록 설정합니다
    zoomFrame2.setShowBackground(false);

    //프레젠테이션을 저장합니다
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **섹션 확대/축소**

섹션 확대/축소는 프레젠테이션 내 섹션에 대한 링크입니다. 섹션 확대/축소를 사용하면 강조하고 싶은 섹션으로 다시 이동하거나, 프레젠테이션의 특정 부분이 어떻게 연결되는지 강조할 수 있습니다. 

![overview_image](seczoomsel.png)

섹션 확대/축소 개체에 대해 Aspose.Slides는 [ISectionZoomFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISectionZoomFrame) 인터페이스와 [IShapeCollection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IShapeCollection) 인터페이스 아래의 몇 가지 메서드를 제공합니다.

### **섹션 확대/축소 프레임 만들기**

다음과 같이 슬라이드에 섹션 확대/축소 프레임을 추가할 수 있습니다:

1.	[Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
2.	새 슬라이드를 하나 생성합니다. 
3.	생성된 슬라이드에 식별용 배경을 추가합니다.
4.	확대/축소 프레임을 연결하려는 새 섹션을 생성합니다. 
5.	첫 번째 슬라이드에 섹션 확대/축소 프레임(생성된 섹션에 대한 참조 포함)을 추가합니다.
6.	수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 Java 코드가 슬라이드에 섹션 확대/축소 프레임을 만드는 방법을 보여줍니다:

``` java
Presentation pres = new Presentation();
try {
    //프레젠테이션에 새 슬라이드 추가
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    //프레젠테이션에 새 섹션 추가
    pres.getSections().addSection("Section 1", slide);

    //SectionZoomFrame 객체 추가
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    //프레젠테이션 저장
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **맞춤 이미지가 있는 섹션 확대/축소 프레임 만들기**

Aspose.Slides for Java를 사용하면 다음과 같이 다른 슬라이드 미리보기 이미지를 사용한 섹션 확대/축소 프레임을 만들 수 있습니다: 

1.	[Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
2.	새 슬라이드를 하나 생성합니다.
3.	생성된 슬라이드에 식별용 배경을 추가합니다.
4.	확대/축소 프레임을 연결하려는 새 섹션을 생성합니다. 
5.	[Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation) 객체와 연결된 Images 컬렉션에 이미지를 추가하여 [IPPImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IPPImage) 객체를 만들고, 이를 프레임을 채우는 데 사용합니다.
5.	첫 번째 슬라이드에 섹션 확대/축소 프레임(생성된 섹션에 대한 참조 포함)을 추가합니다.
6.	수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 Java 코드가 다른 이미지를 사용한 섹션 확대/축소 프레임을 만드는 방법을 보여줍니다:

``` java 
Presentation pres = new Presentation();
try {
    //프레젠테이션에 새 슬라이드 추가
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // 프레젠테이션에 새 섹션 추가
    pres.getSections().addSection("Section 1", slide);

    // 줌 객체를 위한 새로운 이미지를 생성합니다
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // SectionZoomFrame 객체 추가
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1), picture);

    // 프레젠테이션 저장
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
### **섹션 확대/축소 프레임 서식 지정**

보다 복잡한 섹션 확대/축소 프레임을 만들려면 단순 프레임의 서식을 변경해야 합니다. 섹션 확대/축소 프레임에 적용할 수 있는 서식 옵션이 여러 가지 있습니다. 

다음과 같이 슬라이드에서 섹션 확대/축소 프레임의 서식을 제어할 수 있습니다:

1.	[Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
2.	새 슬라이드를 하나 생성합니다.
3.	생성된 슬라이드에 식별용 배경을 추가합니다.
4.	확대/축소 프레임을 연결하려는 새 섹션을 생성합니다. 
5.	첫 번째 슬라이드에 섹션 확대/축소 프레임(생성된 섹션에 대한 참조 포함)을 추가합니다.
6.	생성된 섹션 확대/축소 개체의 크기와 위치를 변경합니다.
7.	[Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation) 객체와 연결된 Images 컬렉션에 이미지를 추가하여 [IPPImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IPPImage) 객체를 만들고, 이를 프레임을 채우는 데 사용합니다.
8.	생성된 섹션 확대/축소 프레임 개체에 맞춤 이미지를 설정합니다.
9.	*링크된 섹션에서 원본 슬라이드로 돌아가기* 기능을 설정합니다. 
10.	섹션 확대/축소 프레임 개체 이미지의 배경을 제거합니다.
11.	두 번째 확대/축소 프레임 개체의 선 서식을 변경합니다.
12.	전환 지속 시간을 변경합니다.
13.	수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 Java 코드가 섹션 확대/축소 프레임의 서식을 변경하는 방법을 보여줍니다:

``` java
Presentation pres = new Presentation();
try {
    //새 슬라이드 추가
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // 새 섹션을 프레젠테이션에 추가
    pres.getSections().addSection("Section 1", slide);

    //SectionZoomFrame 객체 추가
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    //SectionZoomFrame 형식 지정
    sectionZoomFrame.setX(100);
    sectionZoomFrame.setY(300);
    sectionZoomFrame.setWidth(100);
    sectionZoomFrame.setHeight(75);

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
         picture = pres.getImages().addImage(image);
     } finally {
        if (image != null) image.dispose();
     }
    sectionZoomFrame.setImage(picture);

    sectionZoomFrame.setReturnToParent(true);
    sectionZoomFrame.setShowBackground(false);

    sectionZoomFrame.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    sectionZoomFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.gray);
    sectionZoomFrame.getLineFormat().setDashStyle(LineDashStyle.DashDot);
    sectionZoomFrame.getLineFormat().setWidth(2.5f);

    sectionZoomFrame.setTransitionDuration(1.5f);

    //프레젠테이션 저장
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **요약 확대/축소**

요약 확대/축소는 프레젠테이션의 모든 조각이 한 번에 표시되는 랜딩 페이지와 같습니다. 발표 중에 원하는 순서대로 프레젠테이션의 한 부분에서 다른 부분으로 이동하려면 확대/축소를 사용할 수 있습니다. 창의적으로 구성하거나, 앞부분을 건너뛰거나, 슬라이드 쇼의 일부를 다시 방문해도 발표 흐름을 방해하지 않습니다.

![overview_image](sumzoomsel.png)

요약 확대/축소 개체에 대해 Aspose.Slides는 [ISummaryZoomFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISummaryZoomFrame), [ISummaryZoomSection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISummaryZoomSection), [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISummaryZoomSectionCollection) 인터페이스와 [IShapeCollection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IShapeCollection) 인터페이스 아래의 몇 가지 메서드를 제공합니다.

### **요약 확대/축소 만들기**

다음과 같이 슬라이드에 요약 확대/축소 프레임을 추가할 수 있습니다:

1.	[Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
2.	식별용 배경과 새 섹션이 포함된 새 슬라이드를 여러 개 생성합니다.
3.	첫 번째 슬라이드에 요약 확대/축소 프레임을 추가합니다.
4.	수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 Java 코드가 슬라이드에 요약 확대/축소 프레임을 만드는 방법을 보여줍니다:

``` java 
Presentation pres = new Presentation();
try {
    //프레젠테이션에 새 슬라이드 추가
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    //프레젠테이션에 새 섹션 추가
    pres.getSections().addSection("Section 1", slide);

    //프레젠테이션에 새 슬라이드 추가
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    //프레젠테이션에 새 섹션 추가
    pres.getSections().addSection("Section 2", slide);

    //프레젠테이션에 새 슬라이드 추가
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    //프레젠테이션에 새 섹션 추가
    pres.getSections().addSection("Section 3", slide);

    //프레젠테이션에 새 슬라이드 추가
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.green);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    //프레젠테이션에 새 섹션 추가
    pres.getSections().addSection("Section 4", slide);

    //SummaryZoomFrame 객체 추가
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    //프레젠테이션 저장
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **요약 확대/축소 섹션 추가 및 제거**

요약 확대/축소 프레임의 모든 섹션은 [ISummaryZoomSection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISummaryZoomSection) 객체로 표현되며, 이는 [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISummaryZoomSectionCollection) 객체에 저장됩니다. 다음과 같이 [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISummaryZoomSectionCollection) 인터페이스를 사용해 요약 확대/축소 섹션 객체를 추가하거나 제거할 수 있습니다:

1.	[Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
2.	식별용 배경과 새 섹션이 포함된 새 슬라이드를 여러 개 생성합니다.
3.	첫 번째 슬라이드에 요약 확대/축소 프레임을 추가합니다.
4.	프레젠테이션에 새 슬라이드와 섹션을 추가합니다.
5.	생성된 섹션을 요약 확대/축소 프레임에 추가합니다.
6.	요약 확대/축소 프레임에서 첫 번째 섹션을 제거합니다.
7.	수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 Java 코드가 요약 확대/축소 프레임에서 섹션을 추가하고 제거하는 방법을 보여줍니다:

``` java
Presentation pres = new Presentation();
try {
    //프레젠테이션에 새 슬라이드 추가
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    //프레젠테이션에 새 섹션 추가
    pres.getSections().addSection("Section 1", slide);

    //프레젠테이션에 새 슬라이드 추가
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    //프레젠테이션에 새 섹션 추가
    pres.getSections().addSection("Section 2", slide);

    //SummaryZoomFrame 객체 추가
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    //프레젠테이션에 새 슬라이드 추가
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    //프레젠테이션에 새 섹션 추가
    ISection section3 = pres.getSections().addSection("Section 3", slide);

    //Summary Zoom에 섹션 추가
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);

    //Summary Zoom에서 섹션 제거
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));

    //프레젠테이션 저장
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **요약 확대/축소 섹션 서식 지정**

보다 복잡한 요약 확대/축소 섹션 객체를 만들려면 단순 프레임의 서식을 변경해야 합니다. 요약 확대/축소 섹션 객체에 적용할 수 있는 서식 옵션이 여러 가지 있습니다. 

다음과 같이 요약 확대/축소 프레임 내 섹션 객체의 서식을 제어할 수 있습니다:

1.	[Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
2.	식별용 배경과 새 섹션이 포함된 새 슬라이드를 여러 개 생성합니다.
3.	첫 번째 슬라이드에 요약 확대/축소 프레임을 추가합니다.
4.	`ISummaryZoomSectionCollection`에서 첫 번째 객체에 대한 요약 확대/축소 섹션 객체를 가져옵니다.
7.	[Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation) 객체와 연결된 images 컬렉션에 이미지를 추가하여 [IPPImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IPPImage) 객체를 만들고, 이를 프레임을 채우는 데 사용합니다.
8.	생성된 섹션 확대/축소 프레임 객체에 맞춤 이미지를 설정합니다.
9.	*링크된 섹션에서 원본 슬라이드로 돌아가기* 기능을 설정합니다. 
11.	두 번째 확대/축소 프레임 객체의 선 서식을 변경합니다.
12.	전환 지속 시간을 변경합니다.
13.	수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 Java 코드가 요약 확대/축소 섹션 객체의 서식을 변경하는 방법을 보여줍니다:

``` java
Presentation pres = new Presentation();
try {
    //프레젠테이션에 새 슬라이드 추가
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    //프레젠테이션에 새 섹션 추가
    pres.getSections().addSection("Section 1", slide);

    //프레젠테이션에 새 슬라이드 추가
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    //프레젠테이션에 새 섹션 추가
    pres.getSections().addSection("Section 2", slide);

    //SummaryZoomFrame 객체 추가
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    //첫 번째 SummaryZoomSection 객체 가져오기
    ISummaryZoomSection summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);

    //SummaryZoomSection 객체 서식 지정
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
    picture = pres.getImages().addImage(picture);
    } finally {
          if (image != null) image.dispose();
    }
    summarySection.setImage(picture);

    summarySection.setReturnToParent(false);

    summarySection.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    summarySection.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.black);
    summarySection.getLineFormat().setDashStyle(LineDashStyle.DashDot);
    summarySection.getLineFormat().setWidth(1.5f);

    summarySection.setTransitionDuration(1.5f);

    //프레젠테이션 저장
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**대상 슬라이드를 표시한 후 '부모' 슬라이드로 돌아가는 동작을 제어할 수 있나요?**

예. [Zoom frame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/zoomframe/) 또는 [section](https://reference.aspose.com/slides/ko/java/com.aspose.slides/sectionzoomframe/)에는 `ReturnToParent` 동작이 있어 이를 활성화하면 시청자를 대상 콘텐츠를 본 후 원래 슬라이드로 되돌릴 수 있습니다.

**Zoom 전환의 '속도' 또는 지속 시간을 조정할 수 있나요?**

예. Zoom은 `TransitionDuration`을 설정하여 점프 애니메이션의 지속 시간을 제어할 수 있습니다.

**프레젠테이션에 포함될 수 있는 Zoom 객체 수에 제한이 있나요?**

문서화된 명확한 API 제한은 없습니다. 실제 제한은 프레젠테이션 전체 복잡도와 뷰어 성능에 따라 달라집니다. 많은 Zoom 프레임을 추가할 수 있지만 파일 크기와 렌더링 시간을 고려하십시오.