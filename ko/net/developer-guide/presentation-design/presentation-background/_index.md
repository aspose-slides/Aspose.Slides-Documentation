---
title: .NET에서 프레젠테이션 배경 관리
linktitle: 슬라이드 배경
type: docs
weight: 20
url: /ko/net/presentation-background/
keywords:
- 프레젠테이션 배경
- 슬라이드 배경
- 단색
- 그라디언트 색상
- 이미지 배경
- 배경 투명도
- 배경 속성
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 PowerPoint 및 OpenDocument 파일에서 동적 배경을 설정하는 방법을 배우고, 프레젠테이션을 향상시키는 코드 팁을 확인하세요."
---
## **소개**

단색, 그라디언트 및 이미지는 슬라이드 배경에 일반적으로 사용됩니다. **일반 슬라이드**(단일 슬라이드) 또는 **마스터 슬라이드**(한 번에 여러 슬라이드에 적용) 배경을 설정할 수 있습니다.

![PowerPoint background](powerpoint-background.png)

## **일반 슬라이드에 단색 배경 설정**

Aspose.Slides는 프레젠테이션의 특정 슬라이드에 단색을 배경으로 설정할 수 있게 해줍니다—프레젠테이션이 마스터 슬라이드를 사용하더라도. 이 변경은 선택된 슬라이드에만 적용됩니다.

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 슬라이드의 [BackgroundType](https://reference.aspose.com/slides/ko/net/aspose.slides/backgroundtype/) 을 `OwnBackground` 로 설정합니다.
3. 슬라이드 배경의 [FillType](https://reference.aspose.com/slides/ko/net/aspose.slides/filltype/) 을 `Solid` 로 설정합니다.
4. [FillFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/fillformat/) 의 [SolidFillColor](https://reference.aspose.com/slides/ko/net/aspose.slides/fillformat/solidfillcolor/) 속성을 사용하여 단색 배경 색을 지정합니다.
5. 수정된 프레젠테이션을 저장합니다.

다음 C# 예제는 일반 슬라이드 배경을 파란색 단색으로 설정하는 방법을 보여줍니다:

```cs
// Presentation 클래스의 인스턴스를 생성합니다.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 슬라이드의 배경 색을 파란색으로 설정합니다.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Blue;

    // 프레젠테이션을 디스크에 저장합니다.
    presentation.Save("SolidColorBackground.pptx", SaveFormat.Pptx);
}
```

## **마스터 슬라이드에 단색 배경 설정**

Aspose.Slides는 프레젠테이션의 마스터 슬라이드에 단색을 배경으로 설정할 수 있게 해줍니다. 마스터 슬라이드는 모든 슬라이드의 서식을 제어하는 템플릿 역할을 하므로, 마스터 슬라이드 배경에 단색을 선택하면 모든 슬라이드에 적용됩니다.

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 마스터 슬라이드의 [BackgroundType](https://reference.aspose.com/slides/ko/net/aspose.slides/backgroundtype/) (via `masters`) 을 `OwnBackground` 로 설정합니다.
3. 마스터 슬라이드 배경의 [FillType](https://reference.aspose.com/slides/ko/net/aspose.slides/filltype/) 을 `Solid` 로 설정합니다.
4. [SolidFillColor](https://reference.aspose.com/slides/ko/net/aspose.slides/fillformat/solidfillcolor/) 를 사용하여 단색 배경 색을 지정합니다.
5. 수정된 프레젠테이션을 저장합니다.

다음 C# 예제는 마스터 슬라이드 배경을 숲 녹색 단색으로 설정하는 방법을 보여줍니다:

```cs
// Presentation 클래스의 인스턴스를 생성합니다.
using (Presentation presentation = new Presentation())
{
    IMasterSlide masterSlide = presentation.Masters[0];

    // 마스터 슬라이드의 배경 색을 포레스트 그린으로 설정합니다.
    masterSlide.Background.Type = BackgroundType.OwnBackground;
    masterSlide.Background.FillFormat.FillType = FillType.Solid;
    masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

    // 프레젠테이션을 디스크에 저장합니다.
    presentation.Save("MasterSlideBackground.pptx", SaveFormat.Pptx);
}
```

## **슬라이드에 그라디언트 배경 설정**

그라디언트는 색상이 점진적으로 변하는 그래픽 효과입니다. 슬라이드 배경으로 사용하면 프레젠테이션이 더 예술적이고 전문적으로 보일 수 있습니다. Aspose.Slides는 슬라이드 배경을 그라디언트 색상으로 설정할 수 있게 해줍니다.

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 슬라이드의 [BackgroundType](https://reference.aspose.com/slides/ko/net/aspose.slides/backgroundtype/) 을 `OwnBackground` 로 설정합니다.
3. 슬라이드 배경의 [FillType](https://reference.aspose.com/slides/ko/net/aspose.slides/filltype/) 을 `Gradient` 로 설정합니다.
4. [FillFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/fillformat/) 의 [GradientFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/fillformat/gradientformat/) 속성을 사용하여 원하는 그라디언트 설정을 구성합니다.
5. 수정된 프레젠테이션을 저장합니다.

다음 C# 예제는 슬라이드 배경을 그라디언트 색상으로 설정하는 방법을 보여줍니다:

```cs
// Presentation 클래스의 인스턴스를 생성합니다.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 배경에 그라디언트 효과를 적용합니다.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Gradient;
    slide.Background.FillFormat.GradientFormat.TileFlip = TileFlip.FlipBoth;

    // 프레젠테이션을 디스크에 저장합니다.
    presentation.Save("GradientBackground.pptx", SaveFormat.Pptx);
}
```

## **슬라이드를 이미지 배경으로 설정**

단색 및 그라디언트 채우기 외에도 Aspose.Slides는 이미지를 슬라이드 배경으로 사용할 수 있게 해줍니다.

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 슬라이드의 [BackgroundType](https://reference.aspose.com/slides/ko/net/aspose.slides/backgroundtype/) 을 `OwnBackground` 로 설정합니다.
3. 슬라이드 배경의 [FillType](https://reference.aspose.com/slides/ko/net/aspose.slides/filltype/) 을 `Picture` 로 설정합니다.
4. 슬라이드 배경으로 사용할 이미지를 로드합니다.
5. 이미지를 프레젠테이션의 이미지 컬렉션에 추가합니다.
6. [FillFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/fillformat/) 의 [PictureFillFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/fillformat/picturefillformat/) 속성을 사용하여 이미지를 배경으로 지정합니다.
7. 수정된 프레젠테이션을 저장합니다.

다음 C# 예제는 슬라이드 배경을 이미지로 설정하는 방법을 보여줍니다:

```c#
// Presentation 클래스의 인스턴스를 생성합니다.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 배경 이미지 속성을 설정합니다.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Picture;
    slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

    // 이미지를 로드합니다.
    IImage image = Images.FromFile("Tulips.jpg");
    // 이미지를 프레젠테이션의 이미지 컬렉션에 추가합니다.
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    slide.Background.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // 프레젠테이션을 디스크에 저장합니다.
    presentation.Save("ImageAsBackground.pptx", SaveFormat.Pptx);
}
```

다음 코드 샘플은 배경 채우기 유형을 타일형 이미지로 설정하고 타일 속성을 수정하는 방법을 보여줍니다:

```cs
using (Presentation presentation = new Presentation())
{
    ISlide firstSlide = presentation.Slides[0];

    IBackground background = firstSlide.Background;

    background.Type = BackgroundType.OwnBackground;
    background.FillFormat.FillType = FillType.Picture;

    IPPImage ppImage;
    using (IImage newImage = Aspose.Slides.Images.FromFile("image.png"))
        ppImage = presentation.Images.AddImage(newImage);

    // 배경 채우기에 사용할 이미지를 설정합니다.
    IPictureFillFormat backPictureFillFormat = background.FillFormat.PictureFillFormat;
    backPictureFillFormat.Picture.Image = ppImage;

    // 그림 채우기 모드를 타일로 설정하고 타일 속성을 조정합니다.
    backPictureFillFormat.PictureFillMode = PictureFillMode.Tile;
    backPictureFillFormat.TileOffsetX = 15f;
    backPictureFillFormat.TileOffsetY = 15f;
    backPictureFillFormat.TileScaleX = 46f;
    backPictureFillFormat.TileScaleY = 87f;
    backPictureFillFormat.TileAlignment = RectangleAlignment.Center;
    backPictureFillFormat.TileFlip = TileFlip.FlipY;

    presentation.Save("TileBackground.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}}
자세히 보기: [**Tile Picture As Texture**](/slides/ko/net/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **배경 이미지 투명도 변경**

슬라이드의 배경 이미지 투명도를 조정하여 슬라이드 내용이 더 돋보이게 할 수 있습니다. 다음 C# 코드는 슬라이드 배경 이미지의 투명도를 변경하는 방법을 보여줍니다:

```cs
var transparencyValue = 30; // 예시.

var imageTransform = slide.Background.FillFormat.PictureFillFormat.Picture.ImageTransform; // 그림 변환 작업 컬렉션을 가져옵니다.

// 기존 고정 비율 투명도 효과를 찾습니다.
var transparencyOperation = null as IAlphaModulateFixed;
foreach (var operation in imageTransform)
{
    if (operation is IAlphaModulateFixed alphaModulateFixed)
    {
        transparencyOperation = alphaModulateFixed;
        break;
    }
}

// 새로운 투명도 값을 설정합니다.
if (transparencyOperation == null)
{
    imageTransform.AddAlphaModulateFixedEffect(100 - transparencyValue);
}
else
{
    transparencyOperation.Amount = (100 - transparencyValue);
}
```

## **슬라이드 배경 값 가져오기**

Aspose.Slides는 슬라이드의 실제 배경 값을 검색하기 위해 [IBackgroundEffectiveData](https://reference.aspose.com/slides/ko/net/aspose.slides/ibackgroundeffectivedata/) 인터페이스를 제공합니다. 이 인터페이스는 실제 [FillFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/ibackgroundeffectivedata/fillformat/) 및 [EffectFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/ibackgroundeffectivedata/effectformat/)을 노출합니다.

[BaseSlide](https://reference.aspose.com/slides/ko/net/aspose.slides/baseslide/) 클래스의 `background` 속성을 사용하면 슬라이드의 실제 배경을 얻을 수 있습니다.

다음 C# 예제는 슬라이드의 실제 배경 값을 가져오는 방법을 보여줍니다:

```cs
// Presentation 클래스의 인스턴스를 생성합니다.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    ISlide slide = presentation.Slides[0];  

    // 마스터, 레이아웃 및 테마를 고려하여 실제 배경을 가져옵니다.
    IBackgroundEffectiveData effBackground = slide.Background.GetEffective();

    if (effBackground.FillFormat.FillType == FillType.Solid)
        Console.WriteLine("Fill color: " + effBackground.FillFormat.SolidFillColor);
    else
        Console.WriteLine("Fill type: " + effBackground.FillFormat.FillType);
}
```

## **FAQ**

**맞춤 배경을 재설정하고 테마/레이아웃 배경을 복원할 수 있나요?**

예. 슬라이드의 맞춤 채우기를 제거하면 배경이 해당 [layout](/slides/ko/net/slide-layout/)/[master](/slides/ko/net/slide-master/) 슬라이드(즉, [theme background](/slides/ko/net/presentation-theme/))에서 다시 상속됩니다.

**프레젠테이션의 테마를 나중에 변경하면 배경이 어떻게 되나요?**

슬라이드에 자체 채우기가 있는 경우 변경되지 않습니다. 배경이 [layout](/slides/ko/net/slide-layout/)/[master](/slides/ko/net/slide-master/)에서 상속된 경우 새 테마에 맞게 업데이트됩니다.