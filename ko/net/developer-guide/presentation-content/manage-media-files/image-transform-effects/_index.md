---
title: .NET을 사용하여 프레젠테이션에서 이미지 변환 효과 관리
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
- 색조
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
description: "Aspose.Slides for .NET을 사용하여 그림 프레임에 대한 이미지 변환 효과를 적용, 연결, 검사, 제거 및 검증합니다."
---
## **개요**

Aspose.Slides는 그림 조정을 이미지 변환 작업의 순서가 지정된 컬렉션으로 나타냅니다. 그림 프레임의 경우, 해당 프레임의 [ISlidesPicture](https://reference.aspose.com/slides/ko/net/aspose.slides/islidespicture/)를 시작점으로 삼고 [ISlidesPicture.ImageTransform](https://reference.aspose.com/slides/ko/net/aspose.slides/islidespicture/imagetransform/)에 접근합니다. 반환된 [IImageTransformOperationCollection](https://reference.aspose.com/slides/ko/net/aspose.slides.effects/iimagetransformoperationcollection/)를 사용하면 원본 이미지 바이트를 다시 작성하지 않고도 효과를 추가, 열거, 검사, 제거 및 전체 삭제할 수 있습니다.

이 문서는 밝기 및 대비, 색상 변환, 블러, 투명도, 순서가 지정된 효과 체인, 유효값, 제거 및 PPTX 라운드트립 검증을 위한 전체 워크플로우를 보여줍니다.

## **효과 소유권 및 이미지 재사용 이해**

이미지 리소스와 이를 표시하는 그림은 서로 다른 객체입니다.

- [IPPImage](https://reference.aspose.com/slides/ko/net/aspose.slides/ippimage/)은 프레젠테이션이 소유하는 원본 이미지 데이터를 저장하거나 참조합니다.
- [ISlidesPicture](https://reference.aspose.com/slides/ko/net/aspose.slides/islidespicture/)는 그림 채우기에 속하며 이미지 리소스를 가리키면서 이미지 변환 컬렉션을 저장합니다.
- [IPictureFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/ipictureframe/)는 해당 그림 채우기, 기하학, 자르기 설정 및 기타 프레임 수준 서식을 소유하는 슬라이드 도형입니다.

따라서 이미지 변환 작업은 [IPPImage](https://reference.aspose.com/slides/ko/net/aspose.slides/ippimage/)의 바이트를 수정하지 않습니다. 동일한 `IPPImage`를 [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/ishapecollection/addpictureframe/)에 여러 번 전달하면, 각 새로운 그림 프레임은 자체 `ISlidesPicture`와 자체 변환 컬렉션을 받습니다. 한 프레임에 그레이스케일을 적용해도 다른 프레임은 그레이스케일이 되지 않으며, 모든 프레임이 동일한 임베디드 이미지 리소스를 재사용한다는 점은 변함이 없습니다.

동일한 `ISlidesPicture.ImageTransform` 모델은 도형이나 슬라이드 배경과 같은 다른 그림 채우기에서도 사용됩니다. 아래 예제는 그림 프레임에 초점을 맞춥니다.

## **유효 매개변수 범위 및 단위 사용**

데모 메서드는 다음과 같은 의미적 범위와 단위를 사용합니다. 특정 라이브러리 버전이 즉시 모든 범위 초과 값을 거부하지 않더라도, 대상 프레젠테이션 형식은 저장 시 또는 PowerPoint가 파일을 열 때 잘못된 데이터를 정규화, 생략 또는 거부할 수 있습니다.

| 작업 | 매개변수 | 유효 범위 및 단위 |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/ko/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100`~`100` 사이, 퍼센트; `0`은 해당 구성 요소를 변경하지 않음. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/ko/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | 없음 | 숫자 매개변수 없음. 알파는 변경되지 않음. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/ko/net/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | 어두운 픽셀과 밝은 픽셀을 위한 두 색상. `System.Drawing.Color`의 RGB 및 알파 채널은 `0`~`255` 범위 사용. |
| [AddTintEffect](https://reference.aspose.com/slides/ko/net/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | 색조는 `0`(포함)~`360`(미포함)도, `amount`는 `-100`~`100` 퍼센트. |
| [AddHSLEffect](https://reference.aspose.com/slides/ko/net/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | 색조는 `0`~`360` 도, 포화도와 명도는 `-100`~`100` 퍼센트. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/ko/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | 교체 색상은 `0`~`255` 범위의 채널 값을 사용. 기존 알파 값은 변경되지 않음. |
| [AddBlurEffect](https://reference.aspose.com/slides/ko/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | 반경은 음수가 아니며 포인트 단위; `grow`는 블러된 내용이 원본 경계 밖으로 확장될 수 있는지를 제어하는 Boolean. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/ko/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | 음수가 아닌 퍼센트. 일반적인 불투명도 스케일링을 위해 `0`~`100` 사용: `0`은 완전 투명, `100`은 기존 알파 유지. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/ko/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0`~`100` 퍼센트 불투명도. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/ko/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0`~`100` 퍼센트 알파 임계값. 임계값 이하에서는 투명, 임계값 이상에서는 불투명. |

고정 알파 조절의 경우, 투명도와 불투명도는 보완 관계입니다. 예를 들어 35% 투명도는 알파 조절 값 65%에 해당합니다.

## **밝기 및 대비 적용**

[IImageTransformOperationCollection.AddBrightnessContrastEffect](https://reference.aspose.com/slides/ko/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/)는 [IBrightnessContrast](https://reference.aspose.com/slides/ko/net/aspose.slides.effects/ibrightnesscontrast/) 작업을 반환합니다. 스칼라 설정은 작업 생성 시 제공됩니다. [IBrightnessContrast.GetEffective](https://reference.aspose.com/slides/ko/net/aspose.slides.effects/brightnesscontrast/geteffective/)은 읽기 전용으로 계산된 값을 반환하며, 이를 검사하거나 로그에 기록할 수 있습니다.

다음 예제는 밝기를 15% 증가시키고 대비를 20% 증가시킨 뒤, 임베디드 이미지를 변경하지 않고 미리보기를 렌더링합니다.

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

[BrightnessContrast](https://reference.aspose.com/slides/ko/net/aspose.slides.effects/brightnesscontrast/)는 Office 2010 그림 효과 확장 기능이며 표준 DrawingML 명도 효과보다 포터블하지 않습니다. 밝기와 대비를 PPTX 라운드 트립 후에도 편집 가능하게 유지해야 한다면 [IImageTransformOperationCollection.AddLuminanceEffect](https://reference.aspose.com/slides/ko/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/)를 사용하고 파일을 다시 연 뒤 결과를 확인하십시오. 형식 제한 섹션에서 이 차이에 대해 자세히 설명합니다.

## **색상 변환 적용**

색상 효과는 하나의 이미지 리소스를 재사용하는 서로 다른 그림 프레임에 독립적으로 적용할 수 있습니다. 아래 예제는 다섯 개 프레임을 만든 뒤 그레이스케일, 듀오톤, 색조, HSL 조정 및 색상 교체를 적용합니다.

[IDuotone](https://reference.aspose.com/slides/ko/net/aspose.slides.effects/iduotone/)에는 `Color1`(어두운 픽셀 매핑)과 `Color2`(밝은 픽셀 매핑)라는 두 개의 독립적인 색상 매개변수가 있습니다. 이는 단일 스칼라 값보다 복잡한 설정을 가진 효과 예제로 유용합니다.

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

[AddColorReplaceEffect](https://reference.aspose.com/slides/ko/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/)는 알파를 유지하면서 모든 픽셀 색상을 고정 색상으로 교체합니다. 이는 한 원본 색상을 다른 색상으로 매핑하고 원본 및 대상 색상 형식을 모두 노출하는 [AddColorChangeEffect](https://reference.aspose.com/slides/ko/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/)와 다릅니다.

## **블러, 투명도 및 알파 효과 추가**

[AddBlurEffect](https://reference.aspose.com/slides/ko/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/)는 알파를 포함한 모든 색상 채널에 영향을 줍니다. 블러된 가장자리가 원본 그림 경계를 넘어설 수 있는 경우 `grow`를 `true`로 설정하십시오.

균일한 투명도를 위해서는 [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/ko/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/)를 사용합니다. 이 효과는 기존 알파 값을 모두 곱하므로 부분 투명 픽셀은 비례적으로 차이를 유지합니다. [AddAlphaReplaceEffect](https://reference.aspose.com/slides/ko/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/)는 모든 픽셀에 동일한 알파 값을 할당하고, [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/ko/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/)는 임계값에 따라 알파를 두 단계로 변환합니다.

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

매개변수가 없는 기타 알파 작업으로는 모든 비영 제 알파를 완전 불투명하게 만드는 [AddAlphaCeilingEffect](https://reference.aspose.com/slides/ko/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/), 알파가 100% 미만인 경우 완전 투명하게 만드는 [AddAlphaFloorEffect](https://reference.aspose.com/slides/ko/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/), 그리고 `100% - alpha` 로 알파를 반전시키는 [AddAlphaInverseEffect](https://reference.aspose.com/slides/ko/net/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/)이 있습니다.

## **순서가 지정된 효과 체인 구축**

각 `Add...Effect` 메서드는 새 작업을 컬렉션 끝에 추가합니다. 렌더러는 컬렉션을 순서가 지정된 파이프라인으로 사용합니다: 작업 0의 출력이 작업 1의 입력이 되고, 이런 식으로 이어집니다. 따라서 같은 작업을 다른 순서로 배치하면 다른 이미지가 생성될 수 있습니다.

예를 들어, 그레이스케일 후 색조를 적용하면 색채 정보가 먼저 제거된 뒤 명도 결과에 색조가 입혀집니다. 색조 후 그레이스케일을 적용하면 색조가 다시 제거됩니다. 마찬가지로 알파 교체는 앞선 작업에서 계산된 알파 값을 덮어쓸 수 있고, 알파 조절은 상대적인 차이를 유지합니다.

다음 예제는 네 개 작업으로 구성된 체인을 만들고, PPTX로 저장한 뒤 프레젠테이션을 다시 열어 작업 유형과 순서를 확인하고, 다시 연 결과를 렌더링합니다.

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

컬렉션은 색상, 알파 및 블러 작업을 별도 체인으로 제한하는 호환성 매트릭스를 강제하지 않습니다. 이들을 결합할 수 있지만 항상 유용한 것은 아닙니다. 고정 색상 교체는 앞선 색상 효과가 만든 RGB 변화를 없애고, 듀오톤 뒤 그레이스케일은 두 선택 색을 제거하며, 알파 천장·바닥·교체·이진 레벨 작업은 앞서 만든 알파 디테일을 버릴 수 있습니다. 원하는 픽셀 처리 순서에 따라 체인을 구성하고, 아이템을 무순서 포맷 플래그처럼 취급하지 마십시오.

## **편집 가능한 값과 유효값 검사**

편집 가능한 작업은 `ISlidesPicture.ImageTransform`에 저장된 객체입니다. 효과에 따라 직접 쓰기 가능한 멤버를 노출할 수 있습니다. 예를 들어, [IBlur](https://reference.aspose.com/slides/ko/net/aspose.slides.effects/iblur/)는 쓰기 가능한 `Radius`와 `Grow`를 노출하고, [IAlphaModulateFixed](https://reference.aspose.com/slides/ko/net/aspose.slides.effects/ialphamodulatefixed/)는 쓰기 가능한 `Amount`를, [IAlphaBiLevel](https://reference.aspose.com/slides/ko/net/aspose.slides.effects/ialphabilevel/)는 쓰기 가능한 `Threshold`를 노출합니다. [IDuotone](https://reference.aspose.com/slides/ko/net/aspose.slides.effects/iduotone/)과 같은 색상 효과는 변경 가능한 [IColorFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/icolorformat/) 객체를 제공합니다.

[IBrightnessContrast](https://reference.aspose.com/slides/ko/net/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/ko/net/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/ko/net/aspose.slides.effects/itint/) 및 [IAlphaReplace](https://reference.aspose.com/slides/ko/net/aspose.slides.effects/ialphareplace/)와 같은 일부 인터페이스는 생성 시 스칼라 값을 쓰기 가능한 속성으로 노출하지 않습니다. 이러한 설정을 변경하려면 작업을 제거하고 원하는 위치에 새 작업을 추가하십시오.

`GetEffective()`이 반환하는 유효 데이터는 계산된 읽기 전용 값이며, 테마 의존 색상 해결 및 렌더러가 사용하는 정규화된 값을 확인하는 데 유용합니다. 그러나 또 다른 편집 표면은 아닙니다. 아래 예제는 체인을 열거하고 해당 API가 제공하는 경우 유효값을 검사합니다.

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

그레이스케일, 알파 천장 및 알파 역전과 같은 매개변수 없는 효과도 유효 데이터 객체를 가지고 있지만 출력할 스칼라 설정이 없습니다. 컬렉션 내에서의 존재와 위치가 중요한 정보입니다.

## **이미지 변환 제거 또는 전체 삭제**

[IImageTransformOperationCollection.RemoveAt](https://reference.aspose.com/slides/ko/net/aspose.slides.effects/iimagetransformoperationcollection/removeat/)를 사용해 인덱스로 하나의 작업을 제거합니다. 인덱스는 제거 후 이동하므로 먼저 대상 작업을 찾은 다음 열거 후 제거하십시오. `Clear()`를 사용하면 전체 체인을 삭제합니다.

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

변환을 제거하거나 전체를 삭제해도 그림 서식만 변경됩니다. 재사용되는 [IPPImage](https://reference.aspose.com/slides/ko/net/aspose.slides/ippimage/) 리소스는 삭제, 재압축 또는 기타 방식으로 변경되지 않습니다.

## **프레젠테이션 형식 및 내보내기 대상 고려**

이미지 변환은 DrawingML에서 시작되므로 효과 체인에 가장 적합한 편집 형식은 PPTX입니다. PPTX라도 모든 작업이 동일한 포터블성을 보장하지는 않습니다.

- 명도, 그레이스케일, 듀오톤, 색조, HSL, 블러 및 일반 알파 작업과 같은 표준 DrawingML 작업은 PPTX 라운드 트립에서 살아남을 확률이 가장 높습니다. 보존이 필요할 경우 파일을 다시 열고 컬렉션을 검사하십시오.
- [BrightnessContrast](https://reference.aspose.com/slides/ko/net/aspose.slides.effects/brightnesscontrast/)는 표준 DrawingML 명도 작업이 아닌 Office 2010 확장 기능입니다. 메모리 내 렌더링에는 사용할 수 있지만 저장 후 PPTX를 다시 열었을 때 편집 가능한 [IBrightnessContrast](https://reference.aspose.com/slides/ko/net/aspose.slides.effects/ibrightnesscontrast/)로 남을 보장은 없습니다. 지속적인 밝기·대비 조정을 위해서는 [AddLuminanceEffect](https://reference.aspose.com/slides/ko/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/)를 선호하십시오.
- 이진 PPT 형식은 완전한 DrawingML 효과 모델보다 오래되었습니다. PPT로 저장하면 지원되지 않는 작업이 생략되거나 체인이 지원되는 부분만 남거나 외형을 근사화할 수 있습니다. 복잡한 편집 체인의 검증 형식으로 PPT를 사용하지 마십시오.
- PNG, JPEG, TIFF, PDF, SVG, HTML 등 시각적 출력 형식은 지원되는 체인을 적용해 렌더링된 모습을 제공합니다. 이러한 출력에는 편집 가능한 `IImageTransformOperationCollection`이 포함되지 않으며, 래스터 형식은 결과를 픽셀로 평탄화하고 문서/벡터 형식은 자체 렌더링 표현을 저장합니다.
- 효과는 연결된 이미지를 자동으로 자체 포함하도록 만들지 않습니다. 연결된 그림을 렌더링하려면 프레젠테이션이 로드될 때 해당 연결 리소스가 여전히 사용 가능해야 합니다.

여러 알파 또는 색상 양자화 작업을 조합할 경우 일부 프레젠테이션 뷰어가 가장자리 케이스를 다르게 렌더링할 수 있습니다. 중요한 출력물은 편집 가능한 라운드 트립과 최종 내보내기 형식을 모두 동일한 Aspose.Slides 버전으로 테스트하십시오.

## **FAQ**

**이미지 변환 효과가 임베디드 이미지 데이터를 수정합니까?**

아니오. 작업은 그림 채우기에 사용되는 `ISlidesPicture`에 속합니다. 기본 `IPPImage` 바이트는 변경되지 않습니다.

**같은 이미지를 재사용하는 두 그림 프레임이 효과를 공유합니까?**

아니오. `IPPImage`를 재사용하면 이미지 데이터 중복을 피할 수 있지만 각 그림 프레임은 일반적으로 별도의 `ISlidesPicture`와 이미지 변환 컬렉션을 가집니다.

**색상, 블러 및 알파 효과를 결합할 수 있습니까?**

예. 컬렉션은 하나의 순서가 지정된 체인으로 이들을 허용합니다. 교체 및 임계값 작업은 앞선 색상·알파 디테일을 버릴 수 있으므로 각 작업이 이전 작업 결과에 어떤 영향을 미치는지 고려하십시오.

**왜 유효값은 읽기 전용입니까?**

유효 데이터는 렌더링에 사용되는 계산된 값(색상 해결 포함)을 나타내며 편집 가능한 표면이 아닙니다. 쓰기 가능한 멤버가 있는 경우 변환 컬렉션에 저장된 작업을 편집하고, 그렇지 않으면 작업을 제거하고 새 매개변수로 교체하십시오.

**어떤 형식이 변환 체인을 보존하기에 적합합니까?**

PPTX를 사용하고 파일을 다시 열어 확인하십시오. 레거시 PPT는 전체 DrawingML 효과 모델을 표현하지 못하며, 렌더링된 내보내기 형식은 외형을 보존하지만 편집 가능한 변환 작업을 포함하지 않습니다.