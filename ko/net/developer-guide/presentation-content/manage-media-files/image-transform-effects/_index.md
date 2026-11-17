---
title: .NET을 사용한 프레젠테이션에서 이미지 변환 효과 관리
linktitle: 이미지 변환 효과
type: docs
weight: 11
url: /ko/net/image-transform-effects/
keywords:
- 이미지 변환
- 그림 효과
- 밝기
- 대비
- 그레이스케일
- 듀오톤
- 틴트
- HSL
- 색상 교체
- 블러
- 투명도
- 알파 효과
- 효과 체인
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 그림 프레임에 대한 이미지 변환 효과를 적용하고, 체인화하고, 검사하고, 제거하며, 검증합니다."
---
## **개요**

Aspose.Slides는 그림 조정을 이미지 변환 작업의 순서가 지정된 컬렉션으로 나타냅니다. 그림 프레임의 경우, 프레임의 [ISlidesPicture](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/)에 접근하고 [ISlidesPicture.ImageTransform](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/imagetransform/)을 사용합니다. 반환된 [IImageTransformOperationCollection](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/)을 통해 원본 이미지 바이트를 다시 쓰지 않고도 효과를 추가, 열거, 검사, 제거 및 정리할 수 있습니다.

이 문서는 밝기와 대비, 색상 변환, 블러, 투명도, 순서가 지정된 효과 체인, 유효값, 제거 및 PPTX 라운드트립 검증에 대한 전체 워크플로를 보여줍니다.

## **효과 소유권 및 이미지 재사용 이해**

이미지 리소스와 이를 표시하는 그림은 다른 객체입니다.

- [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/)은 프레젠테이션이 소유하는 원본 이미지 데이터를 저장하거나 참조합니다.
- [ISlidesPicture](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/)은 그림 채우기에 속하며 이미지 리소스를 참조하면서 이미지 변환 컬렉션을 저장합니다.
- [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/)은 해당 그림 채우기, 기하학, 자르기 설정 및 기타 프레임 수준 서식을 소유하는 슬라이드 모양입니다.

따라서 이미지 변환 작업은 [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/)의 바이트를 수정하지 않습니다. 동일한 `IPPImage`를 [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addpictureframe/)에 여러 번 전달하면, 각 새 그림 프레임은 자체 `ISlidesPicture`와 자체 변환 컬렉션을 받습니다. 한 프레임에 그레이스케일을 적용해도 다른 프레임은 그레이스케일이 되지 않으며, 모두 동일한 임베디드 이미지 리소스를 재사용합니다.

동일한 `ISlidesPicture.ImageTransform` 모델은 도형이나 슬라이드 배경과 같은 다른 그림 채우기에도 사용됩니다. 아래 예제는 그림 프레임에 초점을 맞춥니다.

## **유효 매개변수 범위 및 단위 사용**

시연된 메서드는 다음과 같은 의미 범위와 단위를 사용합니다. 특정 라이브러리 버전이 모든 범위 초과 값을 즉시 거부하지 않더라도 이 범위 내에 값을 유지하십시오. 대상 프레젠테이션 형식이 저장 시 또는 PowerPoint가 파일을 열 때 잘못된 데이터를 정규화, 생략 또는 거부할 수 있습니다.

| Operation | Parameters | Valid range and unit |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100`에서 `100`까지, 백분율; `0`은 해당 요소를 변경하지 않음. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | None | 숫자 매개변수가 없음. 알파는 변경되지 않음. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | 어두운 픽셀과 밝은 픽셀에 대한 두 색상. `System.Drawing.Color`의 RGB 및 알파 채널은 `0`부터 `255`까지 사용. |
| [AddTintEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | 색조는 `0` 포함에서 `360` 미포함까지, 단위는 도; 양은 `-100`에서 `100`까지, 백분율. |
| [AddHSLEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | 색조는 `0` 포함에서 `360` 미포함까지, 단위는 도; 채도와 휘도는 `-100`에서 `100`까지, 백분율. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | 대체 색상은 채널 값을 `0`부터 `255`까지 사용합니다. 기존 알파 값은 변경되지 않음. |
| [AddBlurEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | 반경은 음수가 아니며 포인트 단위로 측정됩니다; `grow`는 흐려진 내용이 원래 경계 밖으로 확장될 수 있는지를 제어하는 부울값입니다. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | 음수가 아닌 백분율. 일반 불투명도 스케일링에는 `0`부터 `100`까지 사용: `0`은 완전 투명, `100`은 기존 알파를 유지. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0`부터 `100`까지, 백분율 불투명도. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0`부터 `100`까지, 백분율 알파 임계값. 이 값 이하이면 투명해지고, 이상이면 불투명해짐. |

고정 알파 변조의 경우 투명도와 불투명도는 보완 관계에 있습니다. 예를 들어 35% 투명도는 알파 변조 양 65%에 해당합니다.

## **밝기와 대비 적용**

[IImageTransformOperationCollection.AddBrightnessContrastEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/)은 [IBrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/ibrightnesscontrast/) 연산을 반환합니다. 스칼라 설정은 연산이 생성될 때 제공됩니다. [IBrightnessContrast.GetEffective](https://reference.aspose.com/slides/net/aspose.slides.effects/brightnesscontrast/geteffective/)은 계산된 읽기 전용 값을 반환하며, 이를 검사하거나 로그에 기록할 수 있습니다.

다음 예제는 밝기를 15%, 대비를 20% 증가시킨 다음, 임베디드 이미지를 수정하지 않고 미리보기를 렌더링합니다.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Effects;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
IBrightnessContrast brightnessContrast = imageTransform.AddBrightnessContrastEffect(15f, 20f);

var effectiveValues = brightnessContrast.GetEffective();
Console.WriteLine("Brightness: " + effectiveValues.Brightness + "%");
Console.WriteLine("Contrast: " + effectiveValues.Contrast + "%");

using var preview = slide.GetImage();
preview.Save("brightness-contrast-preview.png", ImageFormat.Png);
```

[BrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/brightnesscontrast/)은 Office 2010 그림 효과 확장이며 표준 DrawingML 휘도 효과보다 이동성이 낮습니다. 밝기와 대비를 PPTX 라운드트립 후에도 편집 가능하게 유지해야 하면 [IImageTransformOperationCollection.AddLuminanceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/)를 사용하고 파일을 다시 열어 결과를 확인하십시오. 형식 제한 섹션에서 이 구분을 더 자세히 설명합니다.

## **색상 변환 적용**

색상 효과는 동일한 이미지 리소스를 재사용하는 서로 다른 그림 프레임에 독립적으로 적용할 수 있습니다. 다음 예제는 다섯 개의 프레임을 만들고 그레이스케일, 듀오톤, 틴트, HSL 조정 및 색상 교체를 적용합니다.

[IDuotone](https://reference.aspose.com/slides/net/aspose.slides.effects/iduotone/)은 두 개의 독립적으로 편집 가능한 색상 매개변수를 갖습니다: `Color1`은 어두운 픽셀을, `Color2`는 밝은 픽셀을 매핑합니다. 이는 단일 스칼라 값보다 설정이 복잡한 효과의 유용한 예시입니다.

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var grayFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
grayFrame.PictureFormat.Picture.ImageTransform.AddGrayScaleEffect();

var duotoneFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
var duotone = duotoneFrame.PictureFormat.Picture.ImageTransform.AddDuotoneEffect();
duotone.Color1.Color = Color.Navy;
duotone.Color2.Color = Color.Gold;

var tintFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
tintFrame.PictureFormat.Picture.ImageTransform.AddTintEffect(210f, 35f);

var hslFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
hslFrame.PictureFormat.Picture.ImageTransform.AddHSLEffect(30f, 20f, -10f);

var replacementFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
var colorReplacement = replacementFrame.PictureFormat.Picture.ImageTransform.AddColorReplaceEffect();
colorReplacement.Color.Color = Color.CornflowerBlue;

presentation.Save("color-transformations.pptx", SaveFormat.Pptx);
```

[AddColorReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/)은 알파를 유지하면서 모든 픽셀의 색을 하나의 고정 색으로 교체합니다. 이는 [AddColorChangeEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/)와 달리, 하나의 원본 색을 다른 색으로 매핑하고 원본 및 대상 색 포맷을 모두 노출합니다.

### **라미넌스 임계값 적용**

라미넌스 임계값을 사용하면 스캔한 페이지의 희미한 흔적을 배경과 구분하기 쉬워집니다. [AddGrayScaleEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/)은 중간 회색 음영을 보존합니다. [AddBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addbileveleffect/)은 라미넌스를 검정 또는 백색으로 매핑하고, [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/)은 불투명도에 임계값을 적용합니다.

라미넌스 임계값은 0%에서 100%까지(포함)이며, 임계값 이하의 픽셀은 검정이 되고, 임계값 이상은 백색이 됩니다. 임계값을 높이면 더 많은 음영이 검정으로 변환됩니다.

Download [grayscale-swatches.png](grayscale-swatches.png) to the working directory. Each label gives the original gray level on a scale from 0 to 255. The example places the original beside two copies and saves each copy's threshold in the presentation.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 150, SlideSizeScaleType.DoNotScale);
var shapes = presentation.Slides[0].Shapes;

var imageData = File.ReadAllBytes("grayscale-swatches.png");
var image = presentation.Images.AddImage(imageData);

IPictureFrame AddFrame(float x, string caption)
{
    shapes.AddAutoShape(ShapeType.Rectangle, x, 12, 216, 36).TextFrame.Text = caption;
    return shapes.AddPictureFrame(ShapeType.Rectangle, x, 60, 216, 72, image);
}

AddFrame(12, "Original");

var lowThreshold = AddFrame(252, "Threshold 20%");
lowThreshold.PictureFormat.Picture.ImageTransform.AddBiLevelEffect(20f);

var highThreshold = AddFrame(492, "Threshold 60%");
highThreshold.PictureFormat.Picture.ImageTransform.AddBiLevelEffect(60f);

presentation.Save("luminance-threshold.pptx", SaveFormat.Pptx);
```

Open the output presentation in PowerPoint to compare the three frames. The swatch labeled 96 has about 38% luminance (96 out of 255). It turns white at the 20% threshold and black at the 60% threshold.

![라미넌스 임계값 20% 및 60%에서 검은색-흰색 결과와 나란히 원본 그레이스케일 견본](luminance-threshold.png)

## **블러, 투명도 및 알파 효과 추가**

[AddBlurEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/)은 알파를 포함한 모든 색상 채널에 영향을 줍니다. 흐려진 가장자리가 원본 그림 경계를 벗어날 수 있는 경우 `grow`를 `true`로 설정하십시오.

균일한 투명도를 위해서는 [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/)를 사용합니다. 이 효과는 기존 알파 값을 모두 곱하므로 부분적으로 투명한 픽셀은 비례적으로 차이를 유지합니다. [AddAlphaReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/)는 모든 픽셀에 하나의 알파 값을 할당하고, [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/)는 임계값에 따라 알파를 두 단계로 변환합니다.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var blurredFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image);
var blur = blurredFrame.PictureFormat.Picture.ImageTransform.AddBlurEffect(4.5, true);
blur.Radius = 5;

var transparentFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image);
var alphaModulate = transparentFrame.PictureFormat.Picture.ImageTransform.AddAlphaModulateFixedEffect(65f);
alphaModulate.Amount = 60f;

var uniformAlphaFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image);
uniformAlphaFrame.PictureFormat.Picture.ImageTransform.AddAlphaReplaceEffect(55f);

var binaryAlphaFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image);
var alphaBiLevel = binaryAlphaFrame.PictureFormat.Picture.ImageTransform.AddAlphaBiLevelEffect(50f);
alphaBiLevel.Threshold = 45f;
binaryAlphaFrame.PictureFormat.Picture.ImageTransform.AddAlphaInverseEffect();

presentation.Save("blur-and-alpha-effects.pptx", SaveFormat.Pptx);
```

매개변수가 없는 다른 알파 작업으로는 [AddAlphaCeilingEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/)가 있으며, 이는 0이 아닌 모든 알파를 완전 불투명하게 만들고, [AddAlphaFloorEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/)는 100% 미만의 모든 알파를 완전 투명하게 만들며, [AddAlphaInverseEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/)는 알파를 `100% - alpha`로 변경합니다.

## **순서가 지정된 효과 체인 구축**

모든 `Add...Effect` 메서드는 새 작업을 컬렉션 끝에 추가합니다. 렌더러는 컬렉션을 순서가 지정된 파이프라인으로 사용합니다: 작업 0의 출력이 작업 1의 입력이 되고, 이렇게 이어집니다. 따라서 같은 작업이라도 순서가 다르면 다른 이미지를 생성할 수 있습니다.

예를 들어, 그레이스케일 뒤에 틴트를 적용하면 색상 정보가 먼저 제거된 뒤 라미넌스 결과가 다시 색칠됩니다. 틴트 뒤에 그레이스케일을 적용하면 틴트가 다시 제거됩니다. 유사하게 알파 교체는 이전 작업에서 계산된 알파 값을 덮어쓸 수 있으며, 알파 변조는 상대적 차이를 유지합니다.

다음 예제는 네 개의 작업 체인을 구축하고, PPTX로 저장한 뒤 프레젠테이션을 다시 열어 작업 유형 및 순서를 확인하고, 재개방된 결과를 렌더링합니다.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
imageTransform.AddGrayScaleEffect();
imageTransform.AddTintEffect(220f, 25f);
imageTransform.AddBlurEffect(2.5, false);
imageTransform.AddAlphaModulateFixedEffect(80f);

presentation.Save("image-transform-chain.pptx", SaveFormat.Pptx);

using var reopenedPresentation = new Presentation("image-transform-chain.pptx");
var reopenedShape = reopenedPresentation.Slides[0].Shapes[0];

if (reopenedShape is IPictureFrame reopenedFrame)
{
    var reopenedTransform = reopenedFrame.PictureFormat.Picture.ImageTransform;
    var orderIsPreserved = reopenedTransform.Count == 4 && 
            reopenedTransform[0] is IGrayScale && 
            reopenedTransform[1] is ITint && 
            reopenedTransform[2] is IBlur && 
            reopenedTransform[3] is IAlphaModulateFixed;
    Console.WriteLine(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

    using var renderedSlide = reopenedPresentation.Slides[0].GetImage();
    renderedSlide.Save("reopened-effect-chain.png", ImageFormat.Png);
}
else
{
    Console.WriteLine("The reopened shape is not a picture frame.");
}
```

컬렉션은 색상, 알파 및 블러 작업을 별도 체인으로 제한하는 호환성 매트릭스를 강제하지 않습니다. 결합이 가능하지만 항상 유용한 것은 아닙니다. 고정 색상 교체는 이전 색상 효과가 만든 RGB 변화를 제거하고, 듀오톤 뒤에 그레이스케일을 적용하면 선택된 두 색상이 사라지며, 알파 천장, 바닥, 교체 또는 이중 레벨 작업은 이전에 만든 알파 세부 정보를 없앨 수 있습니다. 원하는 픽셀 처리 순서에 따라 체인을 구축하고, 무작위 서식 플래그로 여기지 마세요.

<!-- visual-explanation:image-transform-effects:start -->
[![같은 이미지가 그레이스케일 → 틴트 순서와 틴트 → 그레이스케일 순서로 처리됨. 두 최종 그레이스케일 이미지가 서로 다른 톤을 가짐](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*이 예시 Aspose.Slides for .NET 26.11 렌더링에서 220° 틴트를 25% 적용하면 그레이스케일 이미지가 변경되지 않습니다. 같은 틴트를 그레이스케일 전에 적용하면 다른 톤이 생성됩니다.*
<!-- visual-explanation:image-transform-effects:end -->

## **편집 가능한 및 유효값 검사**

편집 가능한 작업은 `ISlidesPicture.ImageTransform`에 저장된 객체입니다. 효과에 따라 직접 수정 가능한 멤버를 노출할 수 있습니다. 예를 들어, [IBlur](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/)는 수정 가능한 `Radius`와 `Grow`를, [IAlphaModulateFixed](https://reference.aspose.com/slides/net/aspose.slides.effects/ialphamodulatefixed/)는 수정 가능한 `Amount`를, [IAlphaBiLevel](https://reference.aspose.com/slides/net/aspose.slides.effects/ialphabilevel/)는 수정 가능한 `Threshold`를 노출합니다. [IDuotone](https://reference.aspose.com/slides/net/aspose.slides.effects/iduotone/)과 같은 색상 효과는 변경 가능한 [IColorFormat](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/) 객체를 노출합니다.

[IBrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/net/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/net/aspose.slides.effects/itint/), [IAlphaReplace](https://reference.aspose.com/slides/net/aspose.slides.effects/ialphareplace/)와 같은 일부 인터페이스는 생성 스칼라를 수정 가능한 속성으로 노출하지 않습니다. 이러한 설정을 변경하려면 작업을 제거하고 필요한 위치에 교체 작업을 추가하십시오.

`GetEffective()`이 반환하는 유효 데이터는 계산된 읽기 전용 값이며, 테마 의존 색상을 해석하고 렌더러가 사용하는 정규화 값을 읽는 데 유용합니다. 그러나 이것이 또 다른 편집 표면은 아닙니다. 다음 예제는 체인을 열거하고 해당 API가 제공하는 경우 유효값을 검사합니다.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Effects;

using var presentation = new Presentation("image-transform-chain.pptx");
var pictureFrame = presentation.Slides[0].Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;

    for (var index = 0; index < imageTransform.Count; index++)
    {
        var operation = imageTransform[index];
        Console.WriteLine(index + ": " + operation.GetType().Name);

        switch (operation)
        {
            case IBrightnessContrast brightnessContrast:
                var brightnessContrastData = brightnessContrast.GetEffective();
                Console.WriteLine("  Brightness: " + brightnessContrastData.Brightness);
                Console.WriteLine("  Contrast: " + brightnessContrastData.Contrast);
                break;
            case ILuminance luminance:
                var luminanceData = luminance.GetEffective();
                Console.WriteLine("  Brightness: " + luminanceData.Brightness);
                Console.WriteLine("  Contrast: " + luminanceData.Contrast);
                break;
            case IDuotone duotone:
                var duotoneData = duotone.GetEffective();
                Console.WriteLine("  Dark color: " + duotoneData.Color1);
                Console.WriteLine("  Light color: " + duotoneData.Color2);
                break;
            case IColorReplace colorReplace:
                var colorReplaceData = colorReplace.GetEffective();
                Console.WriteLine("  Replacement color: " + colorReplaceData.Color);
                break;
            case IHSL hsl:
                var hslData = hsl.GetEffective();
                Console.WriteLine("  HSL: " + hslData.Hue + ", " + hslData.Saturation + ", " + hslData.Luminance);
                break;
            case ITint tint:
                var tintData = tint.GetEffective();
                Console.WriteLine("  Tint: " + tintData.Hue + ", " + tintData.Amount);
                break;
            case IBlur blur:
                var blurData = blur.GetEffective();
                Console.WriteLine("  Blur radius: " + blurData.Radius + " pt");
                break;
            case IAlphaModulateFixed alphaModulate:
                var alphaData = alphaModulate.GetEffective();
                Console.WriteLine("  Alpha amount: " + alphaData.Amount + "%");
                break;
            case IAlphaReplace alphaReplace:
                var alphaReplaceData = alphaReplace.GetEffective();
                Console.WriteLine("  Replacement alpha: " + alphaReplaceData.Alpha + "%");
                break;
            case IAlphaBiLevel alphaBiLevel:
                var alphaBiLevelData = alphaBiLevel.GetEffective();
                Console.WriteLine("  Alpha threshold: " + alphaBiLevelData.Threshold + "%");
                break;
        }
    }
}
```

그레이스케일, 알파 천장, 알파 역전과 같은 매개변수 없는 효과도 유효 데이터 객체를 갖지만 출력할 스칼라 설정이 없습니다. 컬렉션 내 존재 여부와 위치가 중요한 정보입니다.

## **이미지 변환 제거 또는 정리**

[ IImageTransformOperationCollection.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/removeat/)을 사용해 인덱스로 하나의 작업을 제거합니다. 인덱스는 제거 후 이동하므로 먼저 목표 작업을 찾은 뒤 열거가 끝난 후 제거하십시오. `Clear()`를 사용하면 전체 체인을 제거할 수 있습니다.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Export;

using var presentation = new Presentation("image-transform-chain.pptx");
var pictureFrame = presentation.Slides[0].Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    var blurIndex = -1;

    for (var index = 0; index < imageTransform.Count; index++)
    {
        if (imageTransform[index] is IBlur)
        {
            blurIndex = index;
            break;
        }
    }

    if (blurIndex >= 0)
    {
        imageTransform.RemoveAt(blurIndex);
        Console.WriteLine("The blur operation was removed.");
    }

    imageTransform.Clear();
    Console.WriteLine("Remaining operations: " + imageTransform.Count);
    presentation.Save("image-transforms-cleared.pptx", SaveFormat.Pptx);
}
```

변환을 제거하거나 정리하면 그림 서식만 변경됩니다. 재사용되는 [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) 리소스는 삭제, 재압축 또는 다른 방식으로 변경되지 않습니다.

## **프레젠테이션 형식 및 내보내기 대상 고려**

이미지 변환은 DrawingML에서 시작되므로 효과 체인에 가장 적합한 편집 형식은 PPTX입니다. PPTX에서도 모든 작업이 동일한 이동성을 갖는 것은 아닙니다.

- 일반 DrawingML 작업(휘도, 그레이스케일, 듀오톤, 틴트, HSL, 블러 및 일반 알파 작업)은 PPTX 라운드트립에서 살아남을 가능성이 가장 높습니다. 보존이 요구될 경우 생성된 파일을 다시 열어 컬렉션을 반드시 검사하십시오.
- [BrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/brightnesscontrast/)는 표준 DrawingML 휘도 작업이 아닌 Office 2010 확장입니다. 메모리 내 렌더링에는 사용할 수 있지만, 저장 후 PPTX를 다시 열었을 때 편집 가능한 [IBrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/ibrightnesscontrast/)가 유지된다는 보장은 없습니다. 지속적인 밝기와 대비 조정을 위해서는 [AddLuminanceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/)를 선호하십시오.
- 이진 PPT 형식은 완전한 DrawingML 효과 모델보다 오래되었습니다. PPT로 저장하면 지원되지 않는 작업이 생략되거나 체인이 지원되는 하위 집합으로 축소되거나 외형이 근사될 수 있습니다. 복잡한 편집 체인의 검증 형식으로 PPT를 사용하지 마십시오.
- PNG, JPEG, TIFF, PDF, SVG, HTML 등 시각적 출력 형식은 지원되는 체인을 렌더링된 결과에 적용합니다. 이러한 출력에는 편집 가능한 `IImageTransformOperationCollection`이 포함되지 않으며, 래스터 형식은 결과를 픽셀로 평탄화하고 문서/벡터 내보내기는 자체 렌더링 표현을 저장합니다.
- 효과는 연결된 이미지를 자체 포함형으로 만들지 않습니다. 연결된 그림을 렌더링하려면 프레젠테이션이 로드될 때 연결된 리소스가 사용 가능해야 합니다.

다양한 프레젠테이션 소비자는 특히 여러 알파 또는 색상 양자화 작업이 결합된 경우 가장자리 상황을 다르게 렌더링할 수 있습니다. 중요한 출력물의 경우 실제 생산 환경에서 사용 중인 동일한 Aspose.Slides 버전으로 편집 라운드트립과 최종 내보내기 형식을 모두 테스트하십시오.

## **FAQ**

**이미지 변환 효과가 임베디드 이미지 데이터를 수정합니까?**

아니오. 작업은 그림 채우기에서 사용되는 `ISlidesPicture`에 속합니다. 기본 `IPPImage` 바이트는 변경되지 않습니다.

**같은 이미지를 재사용하는 두 그림 프레임이 효과를 공유합니까?**

아니오. `IPPImage`를 재사용하면 이미지 데이터 중복을 피할 수 있지만, 각 그림 프레임은 일반적으로 별도의 `ISlidesPicture`와 이미지 변환 컬렉션을 가집니다.

**색상, 블러 및 알파 효과를 동시에 적용할 수 있습니까?**

예. 컬렉션은 하나의 순서가 지정된 체인으로 이들을 허용합니다. 각 작업이 이전 작업의 출력에 어떤 영향을 미치는지 고려하십시오. 교체 및 임계값 작업은 이전 색상이나 알파 세부 정보를 삭제할 수 있습니다.

**왜 유효값이 읽기 전용입니까?**

유효 데이터는 렌더링에 사용되는 계산된 값(해석된 색상 포함)을 나타냅니다. 수정 가능한 멤버가 있는 경우 변환 컬렉션에 저장된 작업을 편집하십시오; 그렇지 않으면 해당 작업을 제거하고 새로운 생성 매개변수를 가진 교체 작업을 추가하십시오.

**어떤 형식을 사용해야 변환 체인을 보존할 수 있습니까?**

PPTX를 사용하고 파일을 다시 열어 확인하십시오. 레거시 PPT는 전체 DrawingML 효과 모델을 표현할 수 없으며, 렌더링된 내보내기 형식은 편집 가능한 변환 작업이 아닌 외형만 보존합니다.