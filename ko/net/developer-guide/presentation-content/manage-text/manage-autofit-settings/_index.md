---
title: ".NET에서 AutoFit을 활용해 프레젠테이션을 향상시키세요"
linktitle: "AutoFit 설정"
type: docs
weight: 30
url: /ko/net/manage-autofit-settings/
keywords:
- "텍스트 상자"
- "자동 맞춤"
- "자동 맞춤 안 함"
- "텍스트 맞춤"
- "텍스트 축소"
- "텍스트 줄 바꿈"
- "도형 크기 조정"
- "PowerPoint"
- "프레젠테이션"
- "C#"
- ".NET"
- "Aspose.Slides"
description: "Aspose.Slides for .NET에서 AutoFit 설정을 관리하여 PowerPoint 및 OpenDocument 프레젠테이션의 텍스트 표시를 최적화하고 콘텐츠 가독성을 향상시키는 방법을 알아보세요."
---
## **소개**

기본적으로 텍스트 상자를 추가하면 Microsoft PowerPoint는 텍스트 상자에 **Resize shape to fit text** 설정을 사용합니다—텍스트가 항상 들어가도록 텍스트 상자의 크기를 자동으로 조정합니다.

![PowerPoint의 텍스트 상자](textbox-in-powerpoint.png)

* 텍스트 상자 안의 텍스트가 더 길어지거나 커지면 PowerPoint가 텍스트 상자를 자동으로 확대하여—높이를 증가시켜—더 많은 텍스트를 수용할 수 있게 합니다.
* 텍스트 상자 안의 텍스트가 짧아지거나 작아지면 PowerPoint가 텍스트 상자를 자동으로 축소하여—높이를 감소시켜—불필요한 공간을 없앱니다.

PowerPoint에서는 텍스트 상자의 자동 맞춤 동작을 제어하는 네 가지 중요한 매개변수 또는 옵션이 있습니다:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape**

![PowerPoint의 자동 맞춤 옵션](autofit-options-powerpoint.png)

Aspose.Slides for .NET는 유사한 옵션—[TextFrameFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/textframeformat) 클래스의 속성—을 제공하여 프레젠테이션에서 텍스트 상자의 자동 맞춤 동작을 제어할 수 있습니다.

## **텍스트에 맞게 도형 크기 조정**

텍스트가 변경된 후에도 박스 안의 텍스트가 항상 박스에 맞도록 하려면 **Resize shape to fit text** 옵션을 사용해야 합니다. 이 설정을 지정하려면 [TextFrameFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/textframeformat) 클래스의 `AutofitType` 속성을 `Shape`으로 설정합니다.

![텍스트에 맞게 도형 크기 조정 설정](alwaysfit-setting-powerpoint.png)

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```

텍스트가 더 길어지거나 커지면 텍스트 상자가 자동으로 크기가 조정(높이 증가)되어 모든 텍스트가 들어가도록 합니다. 텍스트가 짧아지면 반대로 작아집니다.

## **자동 맞춤 안 함**

텍스트 상자나 도형이 텍스트 변경과 관계없이 크기를 유지하도록 하려면 **Do not Autofit** 옵션을 사용해야 합니다. 이 설정을 지정하려면 [TextFrameFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/textframeformat) 클래스의 `AutofitType` 속성을 `None`으로 설정합니다.

![PowerPoint의 "Do not Autofit" 설정](donotautofit-setting-powerpoint.png)

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.None;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```

텍스트가 박스에 비해 너무 길어지면 텍스트가 밖으로 흘러 나옵니다.

## **오버플로 시 텍스트 축소**

텍스트가 박스에 비해 너무 길어지면 **Shrink text on overflow** 옵션을 사용하여 텍스트의 크기와 간격을 줄여 박스에 맞추도록 지정할 수 있습니다. 이 설정을 지정하려면 [TextFrameFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/textframeformat) 클래스의 `AutofitType` 속성을 `Normal`로 설정합니다.

![PowerPoint의 "Shrink text on overflow" 설정](shrinktextonoverflow-setting-powerpoint.png)

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.Normal;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```

{{% alert title="Info" color="info" %}}
**Shrink text on overflow** 옵션을 사용하면, 설정은 텍스트가 박스에 비해 너무 길어질 때에만 적용됩니다.
{{% /alert %}}

## **텍스트 줄 바꿈**

텍스트가 도형의 경계(가로만) 너머로 넘어갈 때 텍스트를 도형 안에서 자동으로 줄 바꿈하려면 **Wrap text in shape** 매개변수를 사용해야 합니다. 이 설정을 지정하려면 [TextFrameFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/textframeformat) 클래스의 `WrapText` 속성을 `NullableBool.True`로 설정합니다.

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.WrapText = NullableBool.True;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```

{{% alert title="Note" color="warning" %}} 
도형에 대해 `WrapText` 속성을 `NullableBool.False`로 설정하면, 도형 내부의 텍스트가 도형 너비보다 길어질 때 텍스트가 한 줄로 도형 경계를 넘어 확장됩니다.
{{% /alert %}}

## **FAQ**

**텍스트 프레임의 내부 여백이 AutoFit에 영향을 줍니까?**

예. 패딩(내부 여백)은 텍스트가 사용할 수 있는 영역을 줄이므로 AutoFit이 더 일찍 작동하여 글꼴을 축소하거나 도형 크기를 더 빨리 조정합니다. AutoFit을 조정하기 전에 여백을 확인하고 조정하십시오.

**AutoFit은 수동 및 연속 줄 바꿈과 어떻게 상호 작용합니까?**

강제 줄 바꿈은 그대로 유지되고, AutoFit은 해당 위치 주변의 글꼴 크기와 간격을 조정합니다. 불필요한 줄 바꿈을 제거하면 AutoFit이 텍스트를 축소하는 정도를 줄일 수 있습니다.

**테마 글꼴을 변경하거나 글꼴 대체를 트리거하면 AutoFit 결과에 영향을 줍니까?**

예. 다른 글리프 메트릭을 가진 글꼴로 대체하면 텍스트의 너비/높이가 변하여 최종 글꼴 크기와 줄 바꿈에 영향을 줄 수 있습니다. 글꼴을 변경하거나 대체한 후에는 슬라이드를 다시 확인하십시오.