---
title: ".NET에서 프레젠테이션 확대/축소 관리"
linktitle: "확대/축소 관리"
type: docs
weight: 60
url: /ko/net/manage-zoom/
keywords:
- "줌"
- "줌 프레임"
- "슬라이드 줌"
- "섹션 줌"
- "요약 줌"
- "줌 추가"
- "PowerPoint"
- "프레젠테이션"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET를 사용하여 줌을 만들고 맞춤 설정하세요 — 섹션 간 이동, 썸네일 및 전환을 PPT, PPTX 및 ODP 프레젠테이션에 추가합니다."
---
## **소개**

PowerPoint의 확대/축소 기능을 사용하면 프레젠테이션의 특정 슬라이드, 섹션 및 부분으로 이동하거나 되돌아갈 수 있습니다. 프레젠테이션을 진행할 때, 콘텐츠를 빠르게 탐색할 수 있는 이 기능이 매우 유용할 수 있습니다.

![overview_image](overview.png)

* 전체 프레젠테이션을 한 슬라이드에 요약하려면 [Summary Zoom](#Summary-Zoom)을 사용하십시오.
* 선택한 슬라이드만 표시하려면 [Slide Zoom](#Slide-Zoom)을 사용하십시오.
* 단일 섹션만 표시하려면 [Section Zoom](#Section-Zoom)을 사용하십시오.

## **슬라이드 확대/축소**

슬라이드 확대/축소는 프레젠테이션을 더욱 역동적으로 만들어 주며, 원하는 순서대로 슬라이드 사이를 자유롭게 탐색할 수 있게 하여 프레젠테이션 흐름을 방해하지 않습니다. 슬라이드 확대/축소는 섹션이 많지 않은 짧은 프레젠테이션에 적합하지만, 다양한 프레젠테이션 상황에서도 사용할 수 있습니다.

슬라이드 확대/축소를 사용하면 하나의 캔버스에 있는 듯한 느낌으로 여러 정보 조각을 자세히 살펴볼 수 있습니다.

![overview_image](slidezoomsel.png)

Aspose.Slides는 [ZoomImageType](https://reference.aspose.com/slides/ko/net/aspose.slides/zoomimagetype) 열거형, [IZoomFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/izoomframe) 인터페이스 및 [IShapeCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/ishapecollection) 인터페이스 아래의 몇몇 메서드를 제공합니다.

### **줌 프레임 만들기**

다음과 같이 슬라이드에 줌 프레임을 추가할 수 있습니다:

1.   [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 만듭니다.
2.   줌 프레임을 연결하려는 새 슬라이드를 만듭니다.
3.   생성된 슬라이드에 식별 텍스트와 배경을 추가합니다.
4.   첫 번째 슬라이드에 줌 프레임(생성된 슬라이드에 대한 참조 포함)을 추가합니다.
5.   변경된 프레젠테이션을 PPTX 파일로 저장합니다.

``` csharp
using (Presentation pres = new Presentation())
{
    //프레젠테이션에 새 슬라이드를 추가합니다
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISlide slide3 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // 두 번째 슬라이드에 배경을 생성합니다
    slide2.Background.Type = BackgroundType.OwnBackground;
    slide2.Background.FillFormat.FillType = FillType.Solid;
    slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // 두 번째 슬라이드에 텍스트 상자를 생성합니다
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // 세 번째 슬라이드에 배경을 생성합니다
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // 세 번째 슬라이드에 텍스트 상자를 생성합니다
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Trird Slide";

    //ZoomFrame 객체를 추가합니다
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // 프레젠테이션을 저장합니다
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **사용자 지정 이미지가 있는 줌 프레임 만들기**

다음과 같이 Aspose.Slides for .NET을 사용하여 다른 슬라이드 미리 보기 이미지가 있는 줌 프레임을 만들 수 있습니다:

1.   [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 만듭니다.
2.   줌 프레임을 연결하려는 새 슬라이드를 만듭니다.
3.   슬라이드에 식별 텍스트와 배경을 추가합니다.
4.   프레임을 채우는 데 사용할 이미지 컬렉션에 이미지를 추가하여 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 객체와 연관된 Images 컬렉션에 [IPPImage](https://reference.aspose.com/slides/ko/net/aspose.slides/ippimage) 객체를 생성합니다.
5.   첫 번째 슬라이드에 줌 프레임(생성된 슬라이드에 대한 참조 포함)을 추가합니다.
6.   변경된 프레젠테이션을 PPTX 파일로 저장합니다.

``` csharp
using (Presentation pres = new Presentation())
{
    //프레젠테이션에 새 슬라이드를 추가합니다
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // 두 번째 슬라이드에 배경을 생성합니다
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // 세 번째 슬라이드에 텍스트 상자를 생성합니다
    IAutoShape autoshape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // 줌 객체를 위한 새 이미지를 생성합니다
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    //ZoomFrame 객체를 추가합니다
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 300, 200, slide, ppImage);

    // 프레젠테이션을 저장합니다
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **줌 프레임 서식 지정**

앞선 섹션에서는 간단한 줌 프레임을 만드는 방법을 보여드렸습니다. 보다 복잡한 줌 프레임을 만들려면 단순 프레임의 서식을 변경해야 합니다. 줌 프레임에 적용할 수 있는 서식 옵션이 여러 가지 있습니다.

다음과 같이 슬라이드에 줌 프레임의 서식을 제어할 수 있습니다:

1.   [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 만듭니다.
2.   줌 프레임을 연결하려는 새 슬라이드를 만듭니다.
3.   생성된 슬라이드에 식별 텍스트와 배경을 추가합니다.
4.   첫 번째 슬라이드에 줌 프레임(생성된 슬라이드에 대한 참조 포함)을 추가합니다.
5.   프레임을 채우는 데 사용할 이미지 컬렉션에 이미지를 추가하여 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 객체와 연관된 Images 컬렉션에 [IPPImage](https://reference.aspose.com/slides/ko/net/aspose.slides/ippimage) 객체를 생성합니다.
6.   첫 번째 줌 프레임 객체에 사용자 지정 이미지를 설정합니다.
7.   두 번째 줌 프레임 객체의 선 서식을 변경합니다.
8.   두 번째 줌 프레임 객체 이미지에서 배경을 제거합니다.
5.   변경된 프레젠테이션을 PPTX 파일로 저장합니다.

``` csharp
using (Presentation pres = new Presentation())
{
    //프레젠테이션에 새 슬라이드를 추가합니다
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISlide slide3 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // 두 번째 슬라이드에 배경을 생성합니다
    slide2.Background.Type = BackgroundType.OwnBackground;
    slide2.Background.FillFormat.FillType = FillType.Solid;
    slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // 두 번째 슬라이드에 텍스트 상자를 생성합니다
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // 세 번째 슬라이드에 배경을 생성합니다
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // 세 번째 슬라이드에 텍스트 상자를 생성합니다
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Trird Slide";

    //ZoomFrame 객체를 추가합니다
    IZoomFrame zoomFrame1 = pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // 줌 객체를 위한 새 이미지를 생성합니다
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // zoomFrame1 객체에 사용자 지정 이미지를 설정합니다
    zoomFrame1.ZoomImage = ppImage;

    // zoomFrame2 객체에 줌 프레임 형식을 설정합니다
    zoomFrame2.LineFormat.Width = 5;
    zoomFrame2.LineFormat.FillFormat.FillType = FillType.Solid;
    zoomFrame2.LineFormat.FillFormat.SolidFillColor.Color = Color.HotPink;
    zoomFrame2.LineFormat.DashStyle = LineDashStyle.DashDot;

    // zoomFrame2 객체에 배경을 표시하지 않도록 설정합니다
    zoomFrame2.ShowBackground = false;

    // 프레젠테이션을 저장합니다
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

## **섹션 확대/축소**

섹션 확대/축소는 프레젠테이션의 섹션에 대한 링크입니다. 강조하고 싶은 섹션으로 돌아가려면 섹션 확대/축소를 사용할 수 있습니다. 또는 프레젠테이션의 특정 부분이 어떻게 연결되는지를 강조하는 데 사용할 수 있습니다.

![overview_image](seczoomsel.png)

섹션 확대/축소 객체의 경우, Aspose.Slides는 [ISectionZoomFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/isectionzoomframe) 인터페이스와 [IShapeCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/ishapecollection) 인터페이스 아래의 몇몇 메서드를 제공합니다.

### **섹션 확대/축소 프레임 만들기**

다음과 같이 슬라이드에 섹션 확대/축소 프레임을 추가할 수 있습니다:

1.   [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 만듭니다.
2.   새 슬라이드를 만듭니다.
3.   생성된 슬라이드에 식별 배경을 추가합니다.
4.   줌 프레임을 연결하려는 새 섹션을 만듭니다.
5.   첫 번째 슬라이드에 섹션 확대/축소 프레임(생성된 섹션에 대한 참조 포함)을 추가합니다.
6.   변경된 프레젠테이션을 PPTX 파일로 저장합니다.

``` csharp
using (Presentation pres = new Presentation())
{
    //새 슬라이드를 프레젠테이션에 추가합니다
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 새 섹션을 프레젠테이션에 추가합니다
    pres.Sections.AddSection("Section 1", slide);

    // SectionZoomFrame 객체를 추가합니다
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // 프레젠테이션을 저장합니다
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **사용자 지정 이미지가 있는 섹션 확대/축소 프레임 만들기**

다음과 같이 Aspose.Slides for .NET을 사용하여 다른 슬라이드 미리 보기 이미지가 있는 섹션 확대/축소 프레임을 만들 수 있습니다:

1.   [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 만듭니다.
2.   새 슬라이드를 만듭니다.
3.   생성된 슬라이드에 식별 배경을 추가합니다.
4.   줌 프레임을 연결하려는 새 섹션을 만듭니다.
5.   프레임을 채우는 데 사용할 이미지 컬렉션에 이미지를 추가하여 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 객체와 연관된 Images 컬렉션에 [IPPImage](https://reference.aspose.com/slides/ko/net/aspose.slides/ippimage) 객체를 생성합니다.
5.   첫 번째 슬라이드에 섹션 확대/축소 프레임(생성된 섹션에 대한 참조 포함)을 추가합니다.
6.   변경된 프레젠테이션을 PPTX 파일로 저장합니다.

``` csharp
using (Presentation pres = new Presentation())
{
    //프레젠테이션에 새 슬라이드를 추가합니다
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 프레젠테이션에 새 섹션을 추가합니다
    pres.Sections.AddSection("Section 1", slide);

    // 줌 객체를 위한 새 이미지를 생성합니다
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // SectionZoomFrame 객체를 추가합니다
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1], ppImage);

    // 프레젠테이션을 저장합니다
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **섹션 확대/축소 프레임 서식 지정**

보다 복잡한 섹션 확대/축소 프레임을 만들려면 단순 프레임의 서식을 변경해야 합니다. 섹션 확대/축소 프레임에 적용할 수 있는 서식 옵션이 여러 가지 있습니다.

다음과 같이 슬라이드에 섹션 확대/축소 프레임의 서식을 제어할 수 있습니다:

1.   [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 만듭니다.
2.   새 슬라이드를 만듭니다.
3.   생성된 슬라이드에 식별 배경을 추가합니다.
4.   줌 프레임을 연결하려는 새 섹션을 만듭니다.
5.   첫 번째 슬라이드에 섹션 확대/축소 프레임(생성된 섹션에 대한 참조 포함)을 추가합니다.
6.   생성된 섹션 확대/축소 객체의 크기와 위치를 변경합니다.
7.   프레임을 채우는 데 사용할 이미지 컬렉션에 이미지를 추가하여 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 객체와 연관된 Images 컬렉션에 [IPPImage](https://reference.aspose.com/slides/ko/net/aspose.slides/ippimage) 객체를 생성합니다.
8.   생성된 섹션 확대/축소 프레임 객체에 사용자 지정 이미지를 설정합니다.
9.   *링크된 섹션에서 원본 슬라이드로 돌아가는* 기능을 설정합니다.
10.   섹션 확대/축소 프레임 객체 이미지에서 배경을 제거합니다.
11.   두 번째 줌 프레임 객체의 선 서식을 변경합니다.
12.   전환 지속 시간을 변경합니다.
13.   변경된 프레젠테이션을 PPTX 파일로 저장합니다.

``` csharp
using (Presentation pres = new Presentation())
{
    //프레젠테이션에 새 슬라이드를 추가합니다
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    //프레젠테이션에 새 섹션을 추가합니다
    pres.Sections.AddSection("Section 1", slide);

    //SectionZoomFrame 객체를 추가합니다
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    //SectionZoomFrame의 서식 지정
    sectionZoomFrame.X = 100;
    sectionZoomFrame.Y = 300;
    sectionZoomFrame.Width = 100;
    sectionZoomFrame.Height = 75;

    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    sectionZoomFrame.ZoomImage = ppImage;

    sectionZoomFrame.ReturnToParent = true;
    sectionZoomFrame.ShowBackground = false;

    sectionZoomFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    sectionZoomFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Brown;
    sectionZoomFrame.LineFormat.DashStyle = LineDashStyle.DashDot;
    sectionZoomFrame.LineFormat.Width = 2.5f;

    sectionZoomFrame.TransitionDuration = 1.5f;

    //프레젠테이션을 저장합니다
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

## **요약 확대/축소**

요약 확대/축소는 프레젠테이션의 모든 조각이 한 번에 표시되는 랜딩 페이지와 같습니다. 프레젠테이션 중에 원하는 순서대로 한 부분에서 다른 부분으로 이동할 수 있습니다. 창의적으로 진행하거나, 앞쪽을 건너뛰거나, 슬라이드 쇼의 일부를 다시 방문하면서도 프레젠테이션 흐름을 방해하지 않을 수 있습니다.

![overview_image](sumzoomsel.png)

요약 확대/축소 객체의 경우, Aspose.Slides는 [ISummaryZoomFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/isummaryzoomframe), [ISummaryZoomFrameSection](https://reference.aspose.com/slides/ko/net/aspose.slides/isummaryzoomsection), [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/isummaryzoomsectioncollection) 인터페이스와 [IShapeCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/ishapecollection) 인터페이스 아래의 몇몇 메서드를 제공합니다.

### **요약 확대/축소 만들기**

다음과 같이 슬라이드에 요약 확대/축소 프레임을 추가할 수 있습니다:

1.   [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 만듭니다.
2.   식별 배경과 새 섹션이 포함된 새 슬라이드를 만들고, 생성된 슬라이드에 대한 섹션을 추가합니다.
3.   첫 번째 슬라이드에 요약 확대/축소 프레임을 추가합니다.
4.   변경된 프레젠테이션을 PPTX 파일로 저장합니다.

``` csharp 
using (Presentation pres = new Presentation())
{
    //새 슬라이드를 프레젠테이션에 추가합니다
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 프레젠테이션에 새 섹션을 추가합니다
    pres.Sections.AddSection("Section 1", slide);

    //새 슬라이드를 프레젠테이션에 추가합니다
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 프레젠테이션에 새 섹션을 추가합니다
    pres.Sections.AddSection("Section 2", slide);

    //새 슬라이드를 프레젠테이션에 추가합니다
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 프레젠테이션에 새 섹션을 추가합니다
    pres.Sections.AddSection("Section 3", slide);

    //새 슬라이드를 프레젠테이션에 추가합니다
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.DarkGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 프레젠테이션에 새 섹션을 추가합니다
    pres.Sections.AddSection("Section 4", slide);

    // SummaryZoomFrame 객체를 추가합니다
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // 프레젠테이션을 저장합니다
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **요약 확대/축소 섹션 추가 및 제거**

요약 확대/축소 프레임의 모든 섹션은 [ISummaryZoomFrameSection](https://reference.aspose.com/slides/ko/net/aspose.slides/isummaryzoomsection) 객체로 표현되며, 이는 [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/isummaryzoomsectioncollection) 객체에 저장됩니다. 다음과 같이 [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/isummaryzoomsectioncollection) 인터페이스를 통해 요약 확대/축소 섹션 객체를 추가하거나 제거할 수 있습니다:

1.   [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 만듭니다.
2.   식별 배경과 새 섹션이 포함된 새 슬라이드를 만들고, 생성된 슬라이드에 대한 섹션을 추가합니다.
3.   첫 번째 슬라이드에 요약 확대/축소 프레임을 추가합니다.
4.   프레젠테이션에 새 슬라이드와 섹션을 추가합니다.
5.   생성된 섹션을 요약 확대/축소 프레임에 추가합니다.
6.   요약 확대/축소 프레임에서 첫 번째 섹션을 제거합니다.
7.   변경된 프레젠테이션을 PPTX 파일로 저장합니다.

``` csharp 
using (Presentation pres = new Presentation())
{
    //새 슬라이드를 프레젠테이션에 추가합니다
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 프레젠테이션에 새 섹션을 추가합니다
    pres.Sections.AddSection("Section 1", slide);

    //새 슬라이드를 프레젠테이션에 추가합니다
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 프레젠테이션에 새 섹션을 추가합니다
    pres.Sections.AddSection("Section 2", slide);

    // SummaryZoomFrame 객체를 추가합니다
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    //새 슬라이드를 프레젠테이션에 추가합니다
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 프레젠테이션에 새 섹션을 추가합니다
    ISection section3 = pres.Sections.AddSection("Section 3", slide);

    // Summary Zoom에 섹션을 추가합니다
    summaryZoomFrame.SummaryZoomCollection.AddSummaryZoomSection(section3);

    // Summary Zoom에서 섹션을 제거합니다
    summaryZoomFrame.SummaryZoomCollection.RemoveSummaryZoomSection(pres.Sections[1]);

    // 프레젠테이션을 저장합니다
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **요약 확대/축소 섹션 서식 지정**

보다 복잡한 요약 확대/축소 섹션 객체를 만들려면 단순 프레임의 서식을 변경해야 합니다. 요약 확대/축소 섹션 객체에 적용할 수 있는 서식 옵션이 여러 가지 있습니다.

다음과 같이 요약 확대/축소 프레임의 섹션 객체 서식을 제어할 수 있습니다:

1.   [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 만듭니다.
2.   식별 배경과 새 섹션이 포함된 새 슬라이드를 만들고, 생성된 슬라이드에 대한 섹션을 추가합니다.
3.   첫 번째 슬라이드에 요약 확대/축소 프레임을 추가합니다.
4.   `ISummaryZoomSectionCollection`에서 첫 번째 섹션 객체를 가져옵니다.
7.   프레임을 채우는 데 사용할 이미지 컬렉션에 이미지를 추가하여 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 객체와 연관된 Images 컬렉션에 [IPPImage](https://reference.aspose.com/slides/ko/net/aspose.slides/ippimage) 객체를 생성합니다.
8.   생성된 섹션 확대/축소 프레임 객체에 사용자 지정 이미지를 설정합니다.
9.   *링크된 섹션에서 원본 슬라이드로 돌아가는* 기능을 설정합니다.
11.   두 번째 줌 프레임 객체의 선 서식을 변경합니다.
12.   전환 지속 시간을 변경합니다.
13.   변경된 프레젠테이션을 PPTX 파일로 저장합니다.

``` csharp 
using (Presentation pres = new Presentation())
{
    //새 슬라이드를 프레젠테이션에 추가합니다
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 새 섹션을 프레젠테이션에 추가합니다
    pres.Sections.AddSection("Section 1", slide);

    //새 슬라이드를 프레젠테이션에 추가합니다
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 새 섹션을 프레젠테이션에 추가합니다
    pres.Sections.AddSection("Section 2", slide);

    // SummaryZoomFrame 객체를 추가합니다
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // 첫 번째 SummaryZoomSection 객체를 가져옵니다
    ISummaryZoomSection summarySection = summaryZoomFrame.SummaryZoomCollection[0];

    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // SummaryZoomSection 객체 서식 지정
    summarySection.ZoomImage = ppImage;
    summarySection.ReturnToParent = false;

    summarySection.LineFormat.FillFormat.FillType = FillType.Solid;
    summarySection.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    summarySection.LineFormat.DashStyle = LineDashStyle.DashDot;
    summarySection.LineFormat.Width = 1.5f;

    summarySection.TransitionDuration = 1.5f;

    // 프레젠테이션을 저장합니다
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**대상 슬라이드를 표시한 후 '부모' 슬라이드로 돌아가는 것을 제어할 수 있나요?**

예. [Zoom frame](https://reference.aspose.com/slides/ko/net/aspose.slides/zoomframe/) 또는 [section](https://reference.aspose.com/slides/ko/net/aspose.slides/sectionzoomframe/)에는 `ReturnToParent` 동작이 있어, 활성화하면 사용자를 대상 콘텐츠를 본 후 원본 슬라이드로 되돌려 보냅니다.

**Zoom 전환의 '속도' 또는 지속 시간을 조정할 수 있나요?**

예. Zoom는 `TransitionDuration`을 설정하여 점프 애니메이션의 지속 시간을 제어할 수 있습니다.

**프레젠테이션에 포함될 수 있는 Zoom 객체의 개수에 제한이 있나요?**

문서화된 명확한 API 제한은 없습니다. 실제 제한은 프레젠테이션의 전체 복잡성과 뷰어의 성능에 따라 달라집니다. 많은 Zoom 프레임을 추가할 수 있지만 파일 크기와 렌더링 시간을 고려해야 합니다.