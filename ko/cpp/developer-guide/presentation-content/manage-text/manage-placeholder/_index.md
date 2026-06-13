---
title: C++에서 프레젠테이션 플레이스홀더 관리
linktitle: 플레이스홀더 관리
type: docs
weight: 10
url: /ko/cpp/manage-placeholder/
keywords:
- 플레이스홀더
- 텍스트 플레이스홀더
- 이미지 플레이스홀더
- 차트 플레이스홀더
- 프롬프트 텍스트
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++에서 플레이스홀더를 손쉽게 관리하세요: 텍스트 교체, 프롬프트 사용자 정의 및 PowerPoint와 OpenDocument에서 이미지 투명도 설정."
---
## **개요**

Aspose.Slides를 사용하면 프레젠테이션 플레이스홀더를 프로그래밍 방식으로 관리할 수 있습니다. 이 문서에서는 슬라이드에서 플레이스홀더를 찾고 텍스트를 변경하는 방법, 플레이스홀더 레이아웃에 사용자 지정 프롬프트 텍스트를 설정하는 방법, 플레이스홀더 배경으로 사용되는 그림의 투명도를 조정하는 방법을 설명합니다. 또한 기본 플레이스홀더와 슬라이드의 로컬 도형 차이, 레이아웃이나 마스터를 통해 플레이스홀더 변경을 적용하는 방법, 머리글 및 바닥글 플레이스홀더 관리에 대한 짧은 FAQ도 포함되어 있습니다.

## **플레이스홀더의 텍스트 변경**
[Aspose.Slides for C++](/slides/ko/cpp/)를 사용하면 프레젠테이션의 슬라이드에서 플레이스홀더를 찾아 수정할 수 있습니다. Aspose.Slides를 통해 플레이스홀더의 텍스트를 변경할 수 있습니다.

**전제조건**: 플레이스홀더가 포함된 프레젠테이션이 필요합니다. 해당 프레젠테이션은 표준 Microsoft PowerPoint 응용 프로그램에서 만들 수 있습니다.

다음은 Aspose.Slides를 사용하여 해당 프레젠테이션의 플레이스홀더 텍스트를 교체하는 방법입니다:

1. [`Presentation`](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation/) 클래스를 인스턴스화하고 프레젠테이션을 인수로 전달합니다.
2. 인덱스를 통해 슬라이드 참조를 가져옵니다.
3. 모양을 반복하여 플레이스홀더를 찾습니다.
4. 플레이스홀더 도형을 [`AutoShape`](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.auto_shape/) 로 형변환하고, 해당 [`AutoShape`](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.auto_shape/) 에 연결된 [`TextFrame`](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.text_frame/) 을 사용해 텍스트를 변경합니다.
5. 수정된 프레젠테이션을 저장합니다.

이 C++ 코드는 플레이스홀더의 텍스트를 변경하는 방법을 보여줍니다:

```c++
// 문서 디렉터리 경로.
const String outPath = u"../out/ReplacingText_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// 원하는 프레젠테이션을 로드합니다.
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// 첫 번째 슬라이드에 접근합니다.
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// 슬라이드에서 첫 번째와 두 번째 플레이스홀더에 접근하고 AutoShape로 형변환합니다.
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);
SharedPtr<AutoShape> ashp = ExplicitCast<Aspose::Slides::AutoShape>(shape);

SharedPtr<ITextFrame> textframe = ashp->get_TextFrame();

textframe->set_Text(u"This is Placeholder");
	
// 프레젠테이션을 디스크에 저장합니다.
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **플레이스홀더에 프롬프트 텍스트 설정**
표준 및 사전 구축 레이아웃에는 ***Click to add a title*** 또는 ***Click to add a subtitle*** 와 같은 플레이스홀더 프롬프트 텍스트가 포함되어 있습니다. Aspose.Slides를 사용하면 원하는 프롬프트 텍스트를 플레이스홀더 레이아웃에 삽입할 수 있습니다.

이 C++ 코드는 플레이스홀더에 프롬프트 텍스트를 설정하는 방법을 보여줍니다:

```c++
const System::String templatePath = u"../templates/Presentation2.pptx";
    
auto pres = System::MakeObject<Presentation>(templatePath);
auto slide = pres->get_Slides()->idx_get(0);

for (auto& shape : slide->get_Shapes())
{
    if (shape->get_Placeholder() != NULL)
    {
        System::String text = u"";
        if (shape->get_Placeholder()->get_Type() == PlaceholderType::CenteredTitle) // 텍스트가 없을 경우 PowerPoint는 "Click to add title"을 표시합니다. 
        {
            text = u"Click to add title";
        }
        else if (shape->get_Placeholder()->get_Type() == PlaceholderType::Subtitle) // 부제목에도 동일하게 적용됩니다.
        {
            text = u"Click to add subtitle";
        }
        System::Console::WriteLine(u"Placeholder : {0}", text);
    }
}

pres->Save(u"../out/Placeholders_PromptText.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **플레이스홀더 이미지 투명도 설정**

Aspose.Slides를 사용하면 텍스트 플레이스홀더의 배경 이미지 투명도를 설정할 수 있습니다. 해당 프레임 내 그림의 투명도를 조정하면 텍스트와 이미지 색상에 따라 텍스트 또는 이미지를 돋보이게 할 수 있습니다.

이 C++ 코드는 그림 배경(도형 내부)의 투명도를 설정하는 방법을 보여줍니다:

```c++
auto presentation = System::MakeObject<Presentation>();
    
auto autoShape = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);
    
auto fillFormat = autoShape->get_FillFormat();
fillFormat->set_FillType(Aspose::Slides::FillType::Picture);
fillFormat->get_PictureFillFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(System::IO::File::ReadAllBytes(u"image.png")));

auto pictureFillFormat = fillFormat->get_PictureFillFormat();
pictureFillFormat->set_PictureFillMode(Aspose::Slides::PictureFillMode::Stretch);
pictureFillFormat->get_Picture()->get_ImageTransform()->AddAlphaModulateFixedEffect(75.0f);
```

## **FAQ**

**기본 플레이스홀더란 무엇이며 슬라이드의 로컬 도형과 어떻게 다릅니다?**

기본 플레이스홀더는 레이아웃이나 마스터에 있는 원본 도형으로, 슬라이드의 도형이 유형, 위치 및 일부 서식을 상속받습니다. 로컬 도형은 독립적이며 기본 플레이스홀더가 없을 경우 상속이 적용되지 않습니다.

**프레젠테이션 전체의 제목이나 캡션을 모든 슬라이드를 반복하지 않고 업데이트하려면 어떻게 해야 하나요?**

레이아웃이나 마스터의 해당 플레이스홀더를 편집하면 됩니다. 해당 레이아웃/마스터를 기반으로 하는 슬라이드는 자동으로 변경 사항을 상속합니다.

**표준 머리글/바닥글 플레이스홀더(날짜 및 시간, 슬라이드 번호, 바닥글 텍스트)를 어떻게 제어합니까?**

적절한 범위(일반 슬라이드, 레이아웃, 마스터, 메모/핸드아웃)에서 HeaderFooter 관리자를 사용하여 해당 플레이스홀더를 켜거나 끄고 내용을 설정합니다.