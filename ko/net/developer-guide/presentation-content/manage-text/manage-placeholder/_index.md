---
title: .NET에서 프레젠테이션 자리표시자 관리
linktitle: 자리표시자 관리
type: docs
weight: 10
url: /ko/net/manage-placeholder/
keywords:
- 자리표시자
- 텍스트 자리표시자
- 이미지 자리표시자
- 차트 자리표시자
- 프롬프트 텍스트
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET에서 자리표시자를 손쉽게 관리하세요: 텍스트 교체, 프롬프트 맞춤 설정 및 PowerPoint와 OpenDocument에서 이미지 투명도 설정."
---
## **Overview**

Aspose.Slides를 사용하면 프레젠테이션 자리표시자를 프로그래밍 방식으로 관리할 수 있습니다. 이 문서에서는 슬라이드에서 자리표시자를 찾고 텍스트를 변경하는 방법, 자리표시자 레이아웃에 사용자 지정 프롬프트 텍스트를 설정하는 방법, 그리고 배경으로 사용되는 그림의 투명도를 조정하는 방법을 설명합니다. 또한 기본 자리표시자와 슬라이드에 있는 로컬 도형의 차이점, 레이아웃 또는 마스터를 통해 자리표시자 변경을 적용하는 방법, 헤더 및 푸터 자리표시자 관리에 대한 짧은 FAQ도 포함합니다.

## **Change Text in a Placeholder**
[Aspose.Slides for .NET](/slides/ko/net/)를 사용하면 프레젠테이션의 슬라이드에서 자리표시자를 찾아 수정할 수 있습니다. Aspose.Slides를 이용하면 자리표시자에 있는 텍스트를 변경할 수 있습니다.

**Prerequisite**: 자리표시자가 포함된 프레젠테이션이 필요합니다. 이와 같은 프레젠테이션은 일반 Microsoft PowerPoint 앱에서 만들 수 있습니다.

다음은 Aspose.Slides를 사용해 해당 프레젠테이션의 자리표시자 텍스트를 교체하는 방법입니다:

1. [`Presentation`](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스를 인스턴스화하고 프레젠테이션을 인수로 전달합니다.
2. 인덱스를 통해 슬라이드 참조를 가져옵니다.
3. 도형들을 순회하며 자리표시자를 찾습니다.
4. 자리표시자 도형을 [`AutoShape`](https://reference.aspose.com/slides/ko/net/aspose.slides/autoshape/)로 타입 캐스팅하고, 해당 [`AutoShape`](https://reference.aspose.com/slides/ko/net/aspose.slides/autoshape/)와 연결된 [`TextFrame`](https://reference.aspose.com/slides/ko/net/aspose.slides/textframe/)을 사용해 텍스트를 변경합니다. 
5. 수정된 프레젠테이션을 저장합니다.

다음 C# 코드는 자리표시자 텍스트를 변경하는 방법을 보여줍니다:

```c#
// Presentation 클래스를 인스턴스화합니다
using (Presentation pres = new Presentation("ReplacingText.pptx"))
{

    // 첫 번째 슬라이드에 접근합니다
    ISlide sld = pres.Slides[0];

    // 자리표시자를 찾기 위해 도형들을 순회합니다
    foreach (IShape shp in sld.Shapes)
        if (shp.Placeholder != null)
        {
            // 각 자리표시자의 텍스트를 변경합니다
            ((IAutoShape)shp).TextFrame.Text = "This is a Placeholder";
        }

    // 프레젠테이션을 디스크에 저장합니다
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Set Prompt Text in a Placeholder**
표준 및 사전 구축된 레이아웃에는 ***Click to add a title*** 또는 ***Click to add a subtitle***과 같은 자리표시자 프롬프트 텍스트가 포함되어 있습니다. Aspose.Slides를 사용하면 이러한 레이아웃에 원하는 프롬프트 텍스트를 삽입할 수 있습니다.

다음 C# 코드는 자리표시자에 프롬프트 텍스트를 설정하는 방법을 보여줍니다:

```c#
using (Presentation pres = new Presentation("Presentation2.pptx"))
{
    ISlide slide = pres.Slides[0];
    foreach (IShape shape in slide.Slide.Shapes) // 슬라이드를 순회합니다
    {
        if (shape.Placeholder != null && shape is AutoShape)
        {
            string text = "";
            if (shape.Placeholder.Type == PlaceholderType.CenteredTitle) // PowerPoint에서 "Click to add title"을 표시합니다
            {
                text = "Add Title";
            }
            else if (shape.Placeholder.Type == PlaceholderType.Subtitle) // 부제목을 추가합니다
            {
                text = "Add Subtitle";
            }

            ((IAutoShape)shape).TextFrame.Text = text;

            Console.WriteLine($"Placeholder with text: {text}");
        }
    }

    pres.Save("Placeholders_PromptText.pptx", SaveFormat.Pptx);
}
```

## **Set Placeholder Image Transparency**

Aspose.Slides를 사용하면 텍스트 자리표시자 배경 이미지의 투명도를 설정할 수 있습니다. 프레임 안의 그림 투명도를 조정하면 텍스트와 그림의 색상에 따라 텍스트 또는 이미지를 돋보이게 할 수 있습니다.

다음 C# 코드는 그림 배경(도형 내부)의 투명도를 설정하는 방법을 보여줍니다:

```c#
using (var presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    
    autoShape.FillFormat.FillType = FillType.Picture;
    autoShape.FillFormat.PictureFillFormat.Picture.Image = presentation.Images.AddImage(File.ReadAllBytes("image.png"));
    autoShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    autoShape.FillFormat.PictureFillFormat.Picture.ImageTransform.AddAlphaModulateFixedEffect(75);
}
```

## **FAQ**

**What is a base placeholder, and how is it different from a local shape on a slide?**

기본 자리표시자는 레이아웃 또는 마스터에 있는 원본 도형으로, 슬라이드의 도형이 유형, 위치 및 일부 서식 정보를 상속받습니다. 로컬 도형은 독립적이며, 기본 자리표시자가 없을 경우 상속이 적용되지 않습니다.

**How can I update all titles or captions across a presentation without iterating over every slide?**

레이아웃이나 마스터에 해당 자리표시자를 편집하면 됩니다. 해당 레이아웃/마스터를 기반으로 만든 모든 슬라이드가 자동으로 변경 사항을 상속합니다.

**How do I control the standard header/footer placeholders—date & time, slide number, and footer text?**

적절한 범위(보통 슬라이드, 레이아웃, 마스터, 노트/핸드아웃)에서 HeaderFooter 관리자를 사용하여 해당 자리표시자를 켜거나 끄고 내용을 설정합니다.