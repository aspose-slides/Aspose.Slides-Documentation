---
title: C++에서 프레젠테이션 하이퍼링크 관리
linktitle: 하이퍼링크 관리
type: docs
weight: 20
url: /ko/cpp/manage-hyperlinks/
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 하이퍼링크를 손쉽게 관리하고, 몇 분 만에 인터랙티브성과 작업 흐름을 강화하세요."
---
## **소개**

하이퍼링크는 객체나 데이터, 혹은 무언가 안의 위치에 대한 참조입니다. 다음은 PowerPoint 프레젠테이션에서 흔히 사용되는 하이퍼링크입니다:

* 텍스트, 도형 또는 미디어 내부의 웹사이트 링크
* 슬라이드에 대한 링크

Aspose.Slides for C++를 사용하면 프레젠테이션에서 하이퍼링크와 관련된 다양한 작업을 수행할 수 있습니다.

{{% alert color="primary" %}} 

Aspose 간단한, [무료 온라인 PowerPoint 편집기.](https://products.aspose.app/slides/ko/editor)를 확인해 보세요.

{{% /alert %}} 

## **URL 하이퍼링크 추가**

### **텍스트에 URL 하이퍼링크 추가**

다음 C++ 코드는 텍스트에 웹사이트 하이퍼링크를 추가하는 방법을 보여줍니다:

``` cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f, false);
shape->AddTextFrame(u"Aspose: File Format APIs");

auto portionFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
portionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
portionFormat->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");
portionFormat->set_FontHeight(32.0f);

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```

### **도형 또는 프레임에 URL 하이퍼링크 추가**

다음 C++ 샘플 코드는 도형에 웹사이트 하이퍼링크를 추가하는 방법을 보여줍니다:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f);

shape->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shape->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

### **미디어에 URL 하이퍼링크 추가**

Aspose.Slides를 사용하면 이미지, 오디오 및 비디오 파일에 하이퍼링크를 추가할 수 있습니다. 

다음 샘플 코드는 **이미지**에 하이퍼링크를 추가하는 방법을 보여줍니다:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
// 프레젠테이션에 이미지 추가
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
// 슬라이드 1에 이전에 추가된 이미지를 기반으로 그림 프레임 생성
auto pictureFrame = shapes->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pictureFrame->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
pictureFrame->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

다음 샘플 코드는 **오디오 파일**에 하이퍼링크를 추가하는 방법을 보여줍니다:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto audio = pres->get_Audios()->AddAudio(File::ReadAllBytes(u"audio.mp3"));
auto audioFrame = shapes->AddAudioFrameEmbedded(10.0f, 10.0f, 100.0f, 100.0f, audio);

audioFrame->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
audioFrame->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

다음 샘플 코드는 **비디오**에 하이퍼링크를 추가하는 방법을 보여줍니다:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto video = pres->get_Videos()->AddVideo(File::ReadAllBytes(u"video.avi"));
auto videoFrame = shapes->AddVideoFrame(10.0f, 10.0f, 100.0f, 100.0f, video);

videoFrame->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
videoFrame->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

{{%  alert  title="Tip"  color="primary"  %}} 

다음 *[OLE 관리](https://docs.aspose.com/slides/ko/cpp/manage-ole/)*를 확인해 보세요.

{{% /alert %}}

## **하이퍼링크를 사용하여 목차 만들기**

하이퍼링크를 사용하면 객체나 위치에 대한 참조를 추가할 수 있으므로, 이를 이용해 목차를 만들 수 있습니다. 

다음 샘플 코드는 하이퍼링크가 포함된 목차를 만드는 방법을 보여줍니다:

``` cpp
auto presentation = System::MakeObject<Presentation>();
auto firstSlide = presentation->get_Slides()->idx_get(0);
auto secondSlide = presentation->get_Slides()->AddEmptySlide(firstSlide->get_LayoutSlide());

auto contentTable = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40.0f, 40.0f, 300.0f, 100.0f);
contentTable->get_FillFormat()->set_FillType(FillType::NoFill);
contentTable->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
contentTable->get_TextFrame()->get_Paragraphs()->Clear();

auto paragraph = System::MakeObject<Paragraph>();
auto paragraphFillFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
paragraphFillFormat->set_FillType(FillType::Solid);
paragraphFillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
paragraph->set_Text(u"Title of slide 2 .......... ");

auto linkPortion = System::MakeObject<Portion>();
linkPortion->set_Text(u"Page 2");
linkPortion->get_PortionFormat()->get_HyperlinkManager()->SetInternalHyperlinkClick(secondSlide);

paragraph->get_Portions()->Add(linkPortion);
contentTable->get_TextFrame()->get_Paragraphs()->Add(paragraph);
```

## **하이퍼링크 서식 지정**

### **색상**

[IHyperlink](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_hyperlink) 인터페이스의 [set_ColorSource()](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_hyperlink#ab739ae21025485366d44a3b72e0d7dac) 및 [get_ColorSource()](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_hyperlink#af5370af1ba9fba7b22fcc8a7ce344494) 메서드를 사용하면 하이퍼링크의 색상을 설정하고 색상 정보를 가져올 수 있습니다. 이 기능은 PowerPoint 2019에서 처음 도입되었으며, 해당 속성에 대한 변경은 이전 PowerPoint 버전에는 적용되지 않습니다.

다음 샘플 코드는 동일한 슬라이드에 서로 다른 색상의 하이퍼링크가 추가되는 작업을 보여줍니다:

``` cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();
auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 450.0f, 50.0f, false);
shape1->AddTextFrame(u"This is a sample of colored hyperlink.");
auto shape1PortionFormat = shape1->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
shape1PortionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shape1PortionFormat->get_HyperlinkClick()->set_ColorSource(HyperlinkColorSource::PortionFormat);
shape1PortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
shape1PortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 450.0f, 50.0f, false);
shape2->AddTextFrame(u"This is a sample of usual hyperlink.");
auto shape2PortionFormat = shape2->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
shape2PortionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));

presentation->Save(u"presentation-out-hyperlink.pptx", SaveFormat::Pptx);
```

## **프레젠테이션에서 하이퍼링크 제거**

### **텍스트에서 하이퍼링크 제거**

다음 C++ 코드는 프레젠테이션 슬라이드의 텍스트에서 하이퍼링크를 제거하는 방법을 보여줍니다:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto slide = pres->get_Slides()->idx_get(0);
for (const auto& shape : slide->get_Shapes())
{
    auto autoShape = System::AsCast<IAutoShape>(shape);
    if (autoShape != nullptr)
    {
        for (const auto& paragraph : autoShape->get_TextFrame()->get_Paragraphs())
        {
            for (const auto& portion : paragraph->get_Portions())
            {
                auto hyperlinkManager = portion->get_PortionFormat()->get_HyperlinkManager();
                hyperlinkManager->RemoveHyperlinkClick();
            }
        }
    }
}

pres->Save(u"pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
```

### **도형 또는 프레임에서 하이퍼링크 제거**

다음 C++ 코드는 프레젠테이션 슬라이드의 도형에서 하이퍼링크를 제거하는 방법을 보여줍니다: 

``` cpp
auto pres = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = pres->get_Slides()->idx_get(0);
for (const auto& shape : slide->get_Shapes())
{
    shape->get_HyperlinkManager()->RemoveHyperlinkClick();
}
pres->Save(u"pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
```

## **가변 하이퍼링크**

The [Hyperlink](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.hyperlink) 클래스는 가변(mutable)입니다. 이 클래스를 사용하면 다음 메서드들의 값을 변경할 수 있습니다:

- [IHyperlink::set_TargetFrame()](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_hyperlink#af2d9c5672517d98afe5868903a5a637f)
- [IHyperlink::set_Tooltip()](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_hyperlink#adf1c8eee89bd292292293e58da79a6f2)
- [IHyperlink.set_History()](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_hyperlink#a1a4a96d280f54b641e3ada3557b6688d)
- [IHyperlink.set_HighlightClick()](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_hyperlink#ac48a0fa4106cff14cb5772269399587e)
- [IHyperlink.set_StopSoundOnClick()](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_hyperlink#ad0db04da8009b329d2c79019642aaa43)

다음 코드 스니펫은 슬라이드에 하이퍼링크를 추가하고 나중에 툴팁을 편집하는 방법을 보여줍니다:

``` cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f, false);

shape->AddTextFrame(u"Aspose: File Format APIs");

auto shapePortionFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
shapePortionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shapePortionFormat->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");
shapePortionFormat->set_FontHeight(32.0f);

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```

## **IHyperlinkQueries에서 지원되는 메서드**

프레젠테이션, 슬라이드 또는 하이퍼링크가 정의된 텍스트에서 IHyperlinkQueries에 접근할 수 있습니다. 

- [IPresentation::get_HyperlinkQueries()](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_presentation#a7e84086f34ddc742ea9124ab11727691)
- [IBaseSlide::get_HyperlinkQueries()](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_base_slide#a8593a5a5f6b7e051aa859ec373c66421)
- [ITextFrame::get_HyperlinkQueries()](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_text_frame#a1303ef71d3c50d471e35434dcaaa2e4e)

IHyperlinkQueries 클래스는 다음 메서드를 지원합니다: 

- [IHyperlinkQueries::GetHyperlinkClicks()](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_hyperlink_queries#aaea0b1b68ff2e65240612fb1f08361c1)
- [IHyperlinkQueries::GetHyperlinkMouseOvers()](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_hyperlink_queries#ac68ac55d183323f11e604b40760b0e4b)
- [IHyperlinkQueries::GetAnyHyperlinks()](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_hyperlink_queries#acaf9ded3920056054e0e70c24129d73a)
- [IHyperlinkQueries::RemoveAllHyperlinks()](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_hyperlink_queries#a289f52c992f939fe46282536cec7222d)

## **FAQ**

**슬라이드 뿐 아니라 "섹션" 또는 섹션의 첫 슬라이드로 내부 탐색을 만들려면 어떻게 해야 하나요?**

PowerPoint에서 섹션은 슬라이드 그룹이며, 탐색은 기술적으로 특정 슬라이드를 대상으로 합니다. "섹션으로 이동"하려면 일반적으로 해당 섹션의 첫 슬라이드에 링크합니다.

**마스터 슬라이드 요소에 하이퍼링크를 붙여 모든 슬라이드에서 작동하도록 할 수 있나요?**

예. 마스터 슬라이드와 레이아웃 요소는 하이퍼링크를 지원합니다. 이러한 링크는 하위 슬라이드에 표시되며 슬라이드 쇼 중에 클릭할 수 있습니다.

**PDF, HTML, 이미지 또는 비디오로 내보낼 때 하이퍼링크가 유지됩니까?**

[PDF](/slides/ko/cpp/convert-powerpoint-to-pdf/)와 [HTML](/slides/ko/cpp/convert-powerpoint-to-html/)에서는 일반적으로 링크가 유지됩니다. [이미지](/slides/ko/cpp/convert-powerpoint-to-png/)와 [비디오](/slides/ko/cpp/convert-powerpoint-to-video/)로 내보낼 경우, 해당 포맷의 특성상(래스터 프레임/비디오는 하이퍼링크를 지원하지 않음) 클릭 가능성이 유지되지 않습니다.