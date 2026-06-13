---
title: C++에서 프레젠테이션 줌 관리
linktitle: 줌 관리
type: docs
weight: 60
url: /ko/cpp/manage-zoom/
keywords:
- 줌
- 줌 프레임
- 슬라이드 줌
- 섹션 줌
- 요약 줌
- 줌 추가
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 줌을 만들고 사용자 지정합니다 — 섹션 간 이동, 썸네일 추가 및 PPT, PPTX, ODP 프레젠테이션 전반에 걸친 전환을 구현합니다."
---
## **소개**

PowerPoint의 Zoom 기능을 사용하면 프레젠테이션의 특정 슬라이드, 섹션 및 부분으로 이동하거나 돌아올 수 있습니다. 발표 중에 콘텐츠를 빠르게 탐색하는 이 기능은 매우 유용할 수 있습니다.

![개요 이미지](Overview.png)

* 전체 프레젠테이션을 한 슬라이드에 요약하려면 [Summary Zoom](#Summary-Zoom)을 사용하십시오.
* 선택한 슬라이드만 표시하려면 [Slide Zoom](#Slide-Zoom)을 사용하십시오.
* 단일 섹션만 표시하려면 [Section Zoom](#Section-Zoom)을 사용하십시오.

## **슬라이드 줌**
슬라이드 줌을 사용하면 프레젠테이션을 보다 역동적으로 만들 수 있으며, 발표 흐름을 방해하지 않고 원하는 순서대로 슬라이드 사이를 자유롭게 탐색할 수 있습니다. 슬라이드 줌은 섹션이 많지 않은 짧은 프레젠테이션에 적합하지만, 다양한 시나리오에서도 사용할 수 있습니다.

슬라이드 줌을 사용하면 여러 정보 조각을 하나의 캔버스에 있는 듯이 확대하여 볼 수 있습니다.

![개요 이미지](slidezoomsel.png)

슬라이드 줌 객체에 대해 Aspose.Slides는 [ZoomImageType](https://reference.aspose.com/slides/ko/cpp/aspose.slides/zoomimagetype/) 열거형, [IZoomFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/izoomframe/) 인터페이스 및 [IShapeCollection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishapecollection/) 인터페이스 아래에 있는 몇 가지 메서드를 제공합니다.

### **Zoom 프레임 만들기**

슬라이드에 Zoom 프레임을 추가하려면 다음과 같이 합니다:

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. Zoom 프레임을 연결할 새 슬라이드를 생성합니다. 
3. 생성된 슬라이드에 식별 텍스트와 배경을 추가합니다.
4. 첫 번째 슬라이드에 Zoom 프레임(생성된 슬라이드에 대한 참조 포함)을 추가합니다.
5. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 C++ 코드는 슬라이드에 Zoom 프레임을 만드는 방법을 보여 줍니다:

``` cpp 
void SetSlideBackground(SharedPtr<ISlide> slide, Color color)
{
    slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
    slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(color);
    slide->get_Background()->set_Type(BackgroundType::OwnBackground);
}
```

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Adds new slides to the presentation
auto slide2 = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

// Creates a background for the second slide
SetSlideBackground(slide2, Color::get_Cyan());

// Creates a text box for the second slide
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// Creates a background for the third slide
SetSlideBackground(slide3, Color::get_DarkKhaki());

// Create a text box for the third slide
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Trird Slide");

//Adds ZoomFrame objects
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
slide0->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

// Saves the presentation
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **사용자 지정 이미지가 있는 Zoom 프레임 만들기**
Aspose.Slides for C++를 사용하면 다음과 같이 다른 슬라이드 미리 보기 이미지를 사용한 Zoom 프레임을 만들 수 있습니다: 
1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. Zoom 프레임을 연결할 새 슬라이드를 생성합니다. 
3. 슬라이드에 식별 텍스트와 배경을 추가합니다.
4. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 개체와 연결된 Images 컬렉션에 이미지를 추가하여 [IPPImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ippimage/) 객체를 만들고, 이를 프레임을 채우는 데 사용합니다.
5. 첫 번째 슬라이드에 Zoom 프레임(생성된 슬라이드에 대한 참조 포함)을 추가합니다.
6. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 C++ 코드는 다른 이미지를 사용한 Zoom 프레임을 만드는 방법을 보여 줍니다:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//프레젠테이션에 새 슬라이드를 추가합니다
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

// 두 번째 슬라이드의 배경을 생성합니다
SetSlideBackground(slide, Color::get_Cyan());

// 세 번째 슬라이드에 텍스트 상자를 생성합니다
auto autoshape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// 줌 객체용 새 이미지를 생성합니다
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

//ZoomFrame 객체를 추가합니다
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, slide, image);

// 프레젠테이션을 저장합니다
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Zoom 프레임 서식 지정**
앞 섹션에서는 간단한 Zoom 프레임을 만드는 방법을 보여 주었습니다. 보다 복잡한 Zoom 프레임을 만들려면 간단한 프레임의 서식을 변경해야 합니다. Zoom 프레임에 적용할 수 있는 서식 옵션이 여러 가지 있습니다. 

슬라이드에서 Zoom 프레임의 서식을 제어하려면 다음과 같이 합니다:

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. Zoom 프레임을 연결할 새 슬라이드를 생성합니다. 
3. 생성된 슬라이드에 식별 텍스트와 배경을 추가합니다.
4. 첫 번째 슬라이드에 Zoom 프레임(생성된 슬라이드에 대한 참조 포함)을 추가합니다.
5. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 개체와 연결된 Images 컬렉션에 이미지를 추가하여 [IPPImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ippimage/) 객체를 만들고, 이를 프레임을 채우는 데 사용합니다.
6. 첫 번째 Zoom 프레임 객체에 사용자 지정 이미지를 설정합니다.
7. 두 번째 Zoom 프레임 객체의 선 서식을 변경합니다.
8. 두 번째 Zoom 프레임 객체 이미지의 배경을 제거합니다.
9. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 C++ 코드는 슬라이드에서 Zoom 프레임의 서식을 변경하는 방법을 보여 줍니다: 

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide1 = pres->get_Slides()->idx_get(0);
//프레젠테이션에 새 슬라이드를 추가합니다
auto slide2 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());

// 두 번째 슬라이드의 배경을 생성합니다
SetSlideBackground(slide2, Color::get_Cyan());

// 두 번째 슬라이드에 텍스트 상자를 생성합니다
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// 세 번째 슬라이드의 배경을 생성합니다
SetSlideBackground(slide3, Color::get_DarkKhaki());

// 세 번째 슬라이드에 텍스트 상자를 생성합니다
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Trird Slide");

//ZoomFrame 객체를 추가합니다
auto zoomFrame1 = slide1->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
auto zoomFrame2 = slide1->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

// 줌 객체용 새 이미지를 생성합니다
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
// zoomFrame1 객체에 사용자 지정 이미지를 설정합니다
zoomFrame1->set_Image(image);

// zoomFrame2 객체에 줌 프레임 서식을 설정합니다
zoomFrame2->get_LineFormat()->set_Width(5);
zoomFrame2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
zoomFrame2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_HotPink());
zoomFrame2->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);

// zoomFrame2 객체에 배경을 표시하지 않도록 설정합니다
zoomFrame2->set_ShowBackground(false);

// 프레젠테이션을 저장합니다
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

## **섹션 줌**

섹션 줌은 프레젠테이션의 특정 섹션에 대한 링크입니다. 강조하고 싶은 섹션으로 다시 이동하거나, 프레젠테이션의 특정 부분이 어떻게 연결되는지 강조하는 데 사용할 수 있습니다. 

![개요 이미지](seczoomsel.png)

섹션 줌 객체에 대해 Aspose.Slides는 [ISectionZoomFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isectionzoomframe/) 인터페이스와 [IShapeCollection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishapecollection/) 인터페이스 아래에 있는 몇 가지 메서드를 제공합니다.

### **섹션 줌 프레임 만들기**

슬라이드에 섹션 줌 프레임을 추가하려면 다음과 같이 합니다:

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 새 슬라이드를 생성합니다. 
3. 생성된 슬라이드에 식별용 배경을 추가합니다.
4. 연결할 새 섹션을 생성합니다. 
5. 첫 번째 슬라이드에 섹션 줌 프레임(생성된 섹션에 대한 참조 포함)을 추가합니다.
6. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 C++ 코드는 슬라이드에 섹션 줌 프레임을 만드는 방법을 보여 줍니다:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//프레젠테이션에 새 슬라이드를 추가합니다
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// 프레젠테이션에 새 섹션을 추가합니다
pres->get_Sections()->AddSection(u"Section 1", slide);

// SectionZoomFrame 객체를 추가합니다
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

// 프레젠테이션을 저장합니다
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```
### **사용자 지정 이미지가 있는 섹션 줌 프레임 만들기**

Aspose.Slides for C++를 사용하면 다음과 같이 다른 슬라이드 미리 보기 이미지를 사용한 섹션 줌 프레임을 만들 수 있습니다: 

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 새 슬라이드를 생성합니다.
3. 생성된 슬라이드에 식별용 배경을 추가합니다.
4. 연결할 새 섹션을 생성합니다. 
5. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 개체와 연결된 Images 컬렉션에 이미지를 추가하여 [IPPImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ippimage/) 객체를 만들고, 이를 프레임을 채우는 데 사용합니다.
6. 첫 번째 슬라이드에 섹션 줌 프레임(생성된 섹션에 대한 참조 포함)을 추가합니다.
7. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 C++ 코드는 다른 이미지를 사용한 섹션 줌 프레임을 만드는 방법을 보여 줍니다:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//프레젠테이션에 새 슬라이드를 추가합니다
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// 새 섹션을 프레젠테이션에 추가합니다
pres->get_Sections()->AddSection(u"Section 1", slide);

// 줌 객체용 새 이미지를 생성합니다
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

// SectionZoomFrame 객체를 추가합니다
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1), image);

// 프레젠테이션을 저장합니다
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **섹션 줌 프레임 서식 지정**

보다 복잡한 섹션 줌 프레임을 만들려면 간단한 프레임의 서식을 변경해야 합니다. 섹션 줌 프레임에 적용할 수 있는 서식 옵션이 여러 가지 있습니다. 

슬라이드에서 섹션 줌 프레임의 서식을 제어하려면 다음과 같이 합니다:

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 새 슬라이드를 생성합니다.
3. 생성된 슬라이드에 식별용 배경을 추가합니다.
4. 연결할 새 섹션을 생성합니다. 
5. 첫 번째 슬라이드에 섹션 줌 프레임(생성된 섹션에 대한 참조 포함)을 추가합니다.
6. 생성된 섹션 줌 객체의 크기와 위치를 변경합니다.
7. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 개체와 연결된 Images 컬렉션에 이미지를 추가하여 [IPPImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ippimage/) 객체를 만들고, 이를 프레임을 채우는 데 사용합니다.
8. 생성된 섹션 줌 프레임 객체에 사용자 지정 이미지를 설정합니다.
9. *링크된 섹션에서 원래 슬라이드로 돌아가기* 옵션을 설정합니다. 
10. 섹션 줌 프레임 객체 이미지의 배경을 제거합니다.
11. 두 번째 줌 프레임 객체의 선 서식을 변경합니다.
12. 전환 지속 시간을 변경합니다.
13. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 C++ 코드는 섹션 줌 프레임의 서식을 변경하는 방법을 보여 줍니다:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//프레젠테이션에 새 슬라이드를 추가합니다
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// 프레젠테이션에 새 섹션을 추가합니다
pres->get_Sections()->AddSection(u"Section 1", slide);

// SectionZoomFrame 객체를 추가합니다
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

// SectionZoomFrame의 서식 지정
sectionZoomFrame->set_X(100.0f);
sectionZoomFrame->set_Y(300.0f);
sectionZoomFrame->set_Width(100.0f);
sectionZoomFrame->set_Height(75.0f);

auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
sectionZoomFrame->set_Image(image);

sectionZoomFrame->set_ReturnToParent(true);
sectionZoomFrame->set_ShowBackground(false);

auto sectionZoomLineFormat = sectionZoomFrame->get_LineFormat();
sectionZoomLineFormat->get_FillFormat()->set_FillType(FillType::Solid);
sectionZoomLineFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Brown());
sectionZoomLineFormat->set_DashStyle(LineDashStyle::DashDot);
sectionZoomLineFormat->set_Width(2.5f);

sectionZoomFrame->set_TransitionDuration(1.5f);

// 프레젠테이션을 저장합니다
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


## **요약 줌**

요약 줌은 프레젠테이션의 모든 조각을 한 번에 표시하는 랜딩 페이지와 같습니다. 발표 중에 줌을 사용하면 프레젠테이션 내 어느 위치에서든 원하는 순서로 이동할 수 있습니다. 흐름을 방해하지 않고 앞뒤로 이동하거나 특정 슬라이드 쇼 부분을 다시 방문할 수 있어 창의적인 활용이 가능합니다.

![개요 이미지](sumzoomsel.png)

요약 줌 객체에 대해 Aspose.Slides는 [ISummaryZoomFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isummaryzoomframe/), [ISummaryZoomSection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isummaryzoomsection/), [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isummaryzoomsectioncollection/) 인터페이스와 [IShapeCollection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishapecollection/) 인터페이스 아래에 있는 몇 가지 메서드를 제공합니다.

### **요약 줌 만들기**

슬라이드에 요약 줌 프레임을 추가하려면 다음과 같이 합니다:

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 식별용 배경과 새 섹션이 포함된 새 슬라이드를 생성합니다.
3. 첫 번째 슬라이드에 요약 줌 프레임을 추가합니다.
4. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 C++ 코드는 슬라이드에 요약 줌 프레임을 만드는 방법을 보여 줍니다:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

// 프레젠테이션에 새 슬라이드를 추가합니다
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// 프레젠테이션에 새 섹션을 추가합니다
pres->get_Sections()->AddSection(u"Section 1", slide);

// 프레젠테이션에 새 슬라이드를 추가합니다
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// 프레젠테이션에 새 섹션을 추가합니다
pres->get_Sections()->AddSection(u"Section 2", slide);

// 프레젠테이션에 새 슬라이드를 추가합니다
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Chartreuse());

// 프레젠테이션에 새 섹션을 추가합니다
pres->get_Sections()->AddSection(u"Section 3", slide);

// 프레젠테이션에 새 슬라이드를 추가합니다
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_DarkGreen());

// 프레젠테이션에 새 섹션을 추가합니다
pres->get_Sections()->AddSection(u"Section 4", slide);

// SummaryZoomFrame 객체를 추가합니다
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

// 프레젠테이션을 저장합니다
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **요약 줌 섹션 추가 및 제거**

요약 줌 프레임의 모든 섹션은 [ISummaryZoomSection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isummaryzoomsection/) 객체로 표현되며, 이는 [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isummaryzoomsectioncollection/) 객체에 저장됩니다. 다음과 같이 [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isummaryzoomsectioncollection/) 인터페이스를 통해 요약 줌 섹션 객체를 추가하거나 제거할 수 있습니다:

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 식별용 배경과 새 섹션이 포함된 새 슬라이드를 생성합니다.
3. 첫 번째 슬라이드에 요약 줌 프레임을 추가합니다.
4. 프레젠테이션에 새 슬라이드와 섹션을 추가합니다.
5. 생성된 섹션을 요약 줌 프레임에 추가합니다.
6. 첫 번째 섹션을 요약 줌 프레임에서 제거합니다.
7. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 C++ 코드는 요약 줌 프레임에서 섹션을 추가하고 제거하는 방법을 보여 줍니다:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//프레젠테이션에 새 슬라이드를 추가합니다
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// 프레젠테이션에 새 섹션을 추가합니다
pres->get_Sections()->AddSection(u"Section 1", slide);

//Adds a new slide to the presentation
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// 프레젠테이션에 새 섹션을 추가합니다
pres->get_Sections()->AddSection(u"Section 2", slide);

// Adds SummaryZoomFrame object
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

//Adds a new slide to the presentation
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Chartreuse());

// 프레젠테이션에 새 섹션을 추가합니다
auto section3 = pres->get_Sections()->AddSection(u"Section 3", slide);

// Summary Zoom에 섹션을 추가합니다
summaryZoomFrame->get_SummaryZoomCollection()->AddSummaryZoomSection(section3);

// Summary Zoom에서 섹션을 제거합니다
summaryZoomFrame->get_SummaryZoomCollection()->RemoveSummaryZoomSection(pres->get_Sections()->idx_get(1));

// 프레젠테이션을 저장합니다
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **요약 줌 섹션 서식 지정**

보다 복잡한 요약 줌 섹션 객체를 만들려면 간단한 프레임의 서식을 변경해야 합니다. 요약 줌 섹션 객체에 적용할 수 있는 서식 옵션이 여러 가지 있습니다. 

요약 줌 프레임 내 섹션 객체의 서식을 제어하려면 다음과 같이 합니다:

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 식별용 배경과 새 섹션이 포함된 새 슬라이드를 생성합니다.
3. 첫 번째 슬라이드에 요약 줌 프레임을 추가합니다.
4. `ISummaryZoomSectionCollection`에서 첫 번째 섹션 객체를 가져옵니다.
5. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 개체와 연결된 Images 컬렉션에 이미지를 추가하여 [IPPImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ippimage/) 객체를 만들고, 이를 프레임을 채우는 데 사용합니다.
6. 생성된 섹션 줌 프레임 객체에 사용자 지정 이미지를 설정합니다.
7. *링크된 섹션에서 원래 슬라이드로 돌아가기* 옵션을 설정합니다. 
8. 두 번째 줌 프레임 객체의 선 서식을 변경합니다.
9. 전환 지속 시간을 변경합니다.
10. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 C++ 코드는 요약 줌 섹션 객체의 서식을 변경하는 방법을 보여 줍니다:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//프레젠테이션에 새 슬라이드를 추가합니다
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

//프레젠테이션에 새 섹션을 추가합니다
pres->get_Sections()->AddSection(u"Section 1", slide);

//프레젠테이션에 새 슬라이드를 추가합니다
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

//프레젠테이션에 새 섹션을 추가합니다
pres->get_Sections()->AddSection(u"Section 2", slide);

// SummaryZoomFrame 객체를 추가합니다
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

// 첫 번째 SummaryZoomSection 객체를 가져옵니다
auto summarySection = summaryZoomFrame->get_SummaryZoomCollection()->idx_get(0);

// SummaryZoomSection 객체의 서식 지정
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
summarySection->set_Image(image);

summarySection->set_ReturnToParent(false);

summarySection->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
summarySection->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
summarySection->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);
summarySection->get_LineFormat()->set_Width(1.5f);

summarySection->set_TransitionDuration(1.5f);

// 프레젠테이션을 저장합니다
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

## **FAQ**

**대상 슬라이드 표시 후 '상위' 슬라이드로 돌아가는 경우를 제어할 수 있나요?**

예. [Zoom frame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/zoomframe/)이나 [section](https://reference.aspose.com/slides/ko/cpp/aspose.slides/sectionzoomframe/)에는 `set_ReturnToParent` 메서드가 있어, 사용자가 대상 콘텐츠를 탐색한 후 원래 슬라이드로 되돌아가게 할 수 있습니다.

**Zoom 전환의 '속도' 혹은 지속 시간을 조정할 수 있나요?**

예. Zoom은 전환 지속 시간을 설정하도록 지원하므로 점프 애니이션이 지속되는 시간을 제어할 수 있습니다.

**프레젠테이션에 포함할 수 있는 Zoom 객체 수에 제한이 있나요?**

문서화된 명확한 API 제한은 없습니다. 실제 제한은 프레젠테이션 전체 복잡도와 뷰어 성능에 따라 달라집니다. Zoom 프레임을 많이 추가할 수 있지만 파일 크기와 렌더링 시간을 고려해야 합니다.