---
title: .NET에서 프레젠테이션의 그림 프레임 관리
linktitle: 그림 프레임
type: docs
weight: 10
url: /ko/net/picture-frame/
keywords:
- 그림 프레임
- 그림 프레임 추가
- 그림 프레임 만들기
- 임베드 이미지
- 연결된 이미지
- 이미지 추출
- 래스터 이미지
- SVG 이미지
- 이미지 자르기
- 잘린 영역 삭제
- 이미지 압축
- StretchOffset
- 그림 프레임 서식
- 상대 스케일
- 이미지 효과
- 가로세로 비율
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET를 사용하여 프레젠테이션에서 그림 프레임을 만들고, 서식 지정하고, 연결하고, 자르고, 추출하고, 압축합니다."
---
## **개요**

그림 프레임은 이미지를 표시하는 슬라이드 모양입니다. Aspose.Slides에서 이미지 리소스와 이를 표시하는 모양은 별개의 객체입니다: [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 은 [Images](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/images/) 컬렉션을 통해 포함된 이미지 리소스를 소유하고, [IPictureFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/ipictureframe/) 은 이미지의 위치, 크기, 선 서식, 회전, 자르기, 그림 효과 및 기타 프레임 수준 설정을 제어합니다.

동일한 이미지를 여러 번 표시할 때 이 분리가 유용합니다. 이미지를 프레젠테이션에 한 번 추가하고 반환된 [IPPImage](https://reference.aspose.com/slides/ko/net/aspose.slides/ippimage/) 를 보관한 뒤, 그림 프레임을 만들 때 해당 이미지 리소스를 사용하세요.

그림 프레임은 PNG 또는 JPEG와 같은 래스터 이미지와 SVG와 같은 벡터 이미지를 포함할 수 있습니다. 또한 이미지 바이트를 프레젠테이션에 저장하지 않고 연결된 이미지를 참조할 수도 있습니다. 이러한 선택은 이식성, 파일 크기, 추출 및 내보내기 동작에 영향을 주므로, 서식 지정이나 최적화를 적용하기 전에 이미지가 어떻게 저장될지 결정하는 것이 유용합니다.

## **임베드된 이미지 추가 및 서식 지정**

임베드된 이미지의 경우, 이미지 데이터를 프레젠테이션에 추가하고 [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/ishapecollection/addpictureframe/) 으로 그림 프레임을 생성합니다. 이미지가 프레젠테이션 패키지의 일부가 되므로, 프레젠테이션을 다른 컴퓨터로 이동해도 자체 포함된 상태를 유지합니다.

다음 예제는 JPEG 이미지를 추가하고, 이미지의 기본 크기로 프레임을 생성한 뒤, 선 서식과 회전을 적용합니다:

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 100, image.Width, image.Height, image);
pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
pictureFrame.LineFormat.Width = 3;
pictureFrame.Rotation = 15;

presentation.Save("picture-frame.pptx", SaveFormat.Pptx);
```

그림 프레임은 표시되는 기하학을 제어합니다. 프레임 크기를 변경해도 임베드된 이미지 리소스에 저장된 원래 픽셀 차원은 변경되지 않습니다. 이 구분은 나중에 이미지를 자르거나 압축할 때 중요해집니다.

## **상대 스케일 사용**

[IPictureFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/ipictureframe/) 은 프레임에 대한 상대적인 너비 및 높이 스케일을 제공합니다. 값 `1.0` 은 원본 그림 크기의 100%에 해당합니다. 상대 스케일은 워크플로에서 최종 차원을 직접 계산하지 않고 원본 이미지 크기와의 비율을 유지해야 할 때 유용합니다.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image);
pictureFrame.RelativeScaleWidth = 1.35f;
pictureFrame.RelativeScaleHeight = 0.8f;

presentation.Save("relative-scale.pptx", SaveFormat.Pptx);
```

상대 스케일은 프레임의 스케일 설정만 변경하며, 임베드된 이미지를 다시 샘플링하거나 압축하지는 않습니다.

## **임베드 이미지와 연결 이미지**

임베드된 그림은 이미지 데이터를 프레젠테이션 내부에 저장하므로 이식성과 예측 가능한 렌더링을 위해 가장 안전한 선택입니다. 연결된 그림은 [ISlidesPicture](https://reference.aspose.com/slides/ko/net/aspose.slides/islidespicture/) 링크 경로를 통해 외부 위치를 저장하므로 이미지 데이터를 동일한 방식으로 임베드하지 않습니다.

연결된 이미지는 PPTX에 저장되는 이미지 데이터 양을 줄일 수 있지만 외부 종속성을 도입합니다. 연결된 파일은 프레젠테이션을 열거나 렌더링하는 애플리케이션이 접근할 수 있어야 합니다. 경로가 변경되거나 파일이 이동되거나 리소스를 사용할 수 없게 되면 연결된 그림이 예상대로 표시되지 않을 수 있습니다. 이메일 전송, 보관 또는 격리된 환경에서 렌더링해야 하는 프레젠테이션의 경우 임베드된 이미지가 일반적으로 더 신뢰됩니다.

### **연결된 이미지 추가**

다음 예제는 그림 프레임을 생성하고 로컬 이미지 파일을 가리키도록 합니다. 이 예제는 이미지 연결만 다루며, 비디오 연결은 별도의 미디어 워크플로이며 의도적으로 혼합되지 않았습니다.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, null);
pictureFrame.PictureFormat.Picture.LinkPathLong = Path.GetFullPath("linked-image.jpg");

presentation.Save("linked-image.pptx", SaveFormat.Pptx);
```

외부 파일 관리가 의도된 경우에만 링크를 사용하세요. 압축 대체 수단으로만 사용하지 마세요. 깨진 이미지 종속성을 가진 작은 PPTX는 보통 큰 자체 포함 프레젠테이션보다 덜 유용합니다.

## **그림 프레임에서 이미지 추출**

기존 프레젠테이션에서 이미지를 추출하기 전에, 해당 모양이 실제로 [IPictureFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/ipictureframe/) 인지와 임베드된 이미지를 포함하고 있는지 확인하세요. 연결된 그림 프레임은 같은 방식으로 추출할 수 있는 이미지 바이트를 포함하지 않을 수도 있습니다.

### **래스터 이미지 추출**

최신 이미지 API는 [IImage](https://reference.aspose.com/slides/ko/net/aspose.slides/iimage/) 를 직접 사용하며, 이전의 시스템 이미지 래퍼가 필요하지 않습니다. 다음 예제는 슬라이드에서 첫 번째 임베드된 래스터 그림을 찾아 PNG 로 저장합니다:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IPictureFrame pictureFrame)
    {
        continue;
    }

    var embeddedImage = pictureFrame.PictureFormat.Picture.Image;
    if (embeddedImage == null || embeddedImage.SvgImage != null)
    {
        continue;
    }

    using var rasterImage = embeddedImage.Image;
    rasterImage.Save("extracted-image.png", Aspose.Slides.ImageFormat.Png);
    break;
}
```

[IImage](https://reference.aspose.com/slides/ko/net/aspose.slides/iimage/) 를 통한 저장은 추출된 이미지를 요청된 출력 형식으로 변환합니다. 변환된 래스터 파일이 아니라 프레젠테이션에 저장된 인코딩된 바이트가 필요하다면 이미지 리소스의 이진 데이터를 사용하세요.

### **SVG 이미지 추출**

SVG 그림의 경우, [IPPImage](https://reference.aspose.com/slides/ko/net/aspose.slides/ippimage/) 가 [ISvgImage](https://reference.aspose.com/slides/ko/net/aspose.slides/isvgimage/) 객체를 제공합니다. 이를 통해 SVG 데이터를 직접 가져올 수 있어, 먼저 그림을 래스터화할 필요가 없습니다.

```csharp
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IPictureFrame pictureFrame)
    {
        continue;
    }

    var embeddedImage = pictureFrame.PictureFormat.Picture.Image;
    var svgImage = embeddedImage?.SvgImage;
    if (svgImage == null)
    {
        continue;
    }

    File.WriteAllBytes("extracted-image.svg", svgImage.SvgData);
    break;
}
```

SVG 내용을 SVG 로 유지하면 프레젠테이션 내부에 벡터 소스가 보존됩니다. PNG나 JPEG와 같은 래스터 내보내기는 해당 벡터 내용을 픽셀로 렌더링합니다. PDF나 SVG 슬라이드 내보내기도 렌더링 작업이므로, 내보낸 그래픽을 원본 임베드된 SVG와 바이트 단위로 동일하게 취급하지 말고, 원본 벡터 리소스가 필요할 때는 임베드된 [ISvgImage](https://reference.aspose.com/slides/ko/net/aspose.slides/isvgimage/) 데이터를 사용하세요.

## **이미지 자르기**

자르기는 프레임 내부에 표시되는 이미지 부분을 변경합니다. [IPictureFillFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/ipicturefillformat/) 의 자르기 값은 원본 이미지 차원의 백분율입니다. 자르기는 초기에는 임베드된 이미지에서 숨겨진 픽셀을 삭제하지 않고, 표시 영역만 변경합니다.

다음 예제는 그림 프레임을 안전하게 찾은 뒤 자르기 값을 적용합니다:

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    pictureFrame.PictureFormat.CropLeft = 23.6f;
    pictureFrame.PictureFormat.CropRight = 21.5f;
    pictureFrame.PictureFormat.CropTop = 3f;
    pictureFrame.PictureFormat.CropBottom = 31f;
    presentation.Save("cropped-image.pptx", SaveFormat.Pptx);
}
```

숨겨진 이미지 데이터가 여전히 존재하기 때문에, 나중에 원본 픽셀을 잃지 않고 자르기 설정을 변경할 수 있습니다. 파일 크기가 중요한 경우 다음 섹션에서 설명하는 대로 자른 영역을 물리적으로 제거할 수 있습니다.

## **잘린 이미지 데이터 제거**

[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/ko/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) 은 현재 자르기 사각형 밖에 있는 이미지 데이터를 제거하고 결과 이미지 리소스를 반환합니다. 이는 파일 크기를 줄일 수 있지만 파괴적인 최적화이며, 프레젠테이션이 저장된 후에는 제거된 픽셀이 나중에 복구되지 않습니다.

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("cropped-image.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var croppedImage = pictureFrame.PictureFormat.DeletePictureCroppedAreas();
    if (croppedImage != null)
    {
        presentation.Save("cropped-data-removed.pptx", SaveFormat.Pptx);
    }
}
```

이 메서드는 프레젠테이션에 새 이미지 리소스를 추가할 수 있습니다. 원본 이미지가 다른 그림 프레임에서도 사용되는 경우, 해당 프레임은 기존 리소스를 계속 필요로 하므로 잘린 영역을 삭제한다고 해서 전체 이미지 수가 반드시 감소하는 것은 아닙니다. 이 메서드로 WMF 또는 EMF 콘텐츠를 자르면 결과가 PNG 로 래스터화됩니다.

## **래스터 이미지 압축**

[IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/ko/net/aspose.slides/ipicturefillformat/compressimage/) 은 그림이 표시되는 크기에 비례하여 래스터 이미지 해상도를 낮춥니다. 동일한 작업에서 잘린 영역을 제거할 수도 있습니다. 이미지가 리사이즈되거나 잘렸을 때 `true`, 변경이 필요 없을 때 `false` 를 반환합니다.

표준 목표 해상도가 충분한 경우 미리 정의된 [PicturesCompression](https://reference.aspose.com/slides/ko/net/aspose.slides.export/picturescompression/) 값을 사용하세요:

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var compressed = pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);
    Console.WriteLine(compressed ? "The image was compressed." : "No compression was necessary.");
    presentation.Save("compressed-image.pptx", SaveFormat.Pptx);
}
```

특정 목표가 필요한 경우 enum 값 대신 양의 DPI 값을 직접 전달할 수 있습니다.

압축은 래스터 이미지에만 적용됩니다. SVG 및 메타파일 콘텐츠는 이 래스터 압축 워크플로에 의해 감소되지 않습니다. 또한 낮은 해상도와 삭제된 잘린 영역은 최적화된 프레젠테이션에서 복구할 수 없다는 점을 기억하세요. 전체적으로 가장 낮은 DPI 를 적용하기보다 실제로 표시되거나 내보내질 가장 큰 크기를 기준으로 목표 해상도를 선택하세요.

## **이미지 효과 검사**

그림 효과는 프레임이 사용하는 그림에 저장됩니다. 이미지 변환 컬렉션에는 투명도를 위한 고정 알파 변조와 밝기·대비를 위한 명도와 같은 효과가 포함될 수 있습니다. 아래 예제는 슬라이드의 첫 번째 그림 프레임에서 두 종류의 효과를 안전하게 읽습니다:

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Effects;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    foreach (var effect in pictureFrame.PictureFormat.Picture.ImageTransform)
    {
        if (effect is IAlphaModulateFixed alphaModulateFixed)
        {
            var transparency = 100 - alphaModulateFixed.Amount;
            Console.WriteLine("Transparency: " + transparency);
        }

        if (effect is ILuminance luminanceEffect)
        {
            var luminance = luminanceEffect.GetEffective();
            Console.WriteLine("Brightness: " + luminance.Brightness);
            Console.WriteLine("Contrast: " + luminance.Contrast);
        }
    }
}
```

이러한 효과는 프레임 내에서 이미지가 렌더링되는 방식을 변경하지만, 원본 임베드된 이미지 바이트를 다시 쓰지는 않습니다.

## **그림 프레임 기하학 잠금**

[IPictureFrameLock](https://reference.aspose.com/slides/ko/net/aspose.slides/ipictureframelock/) 설정은 그림 프레임에 대해 어떤 편집 작업이 비활성화되는지를 제어합니다. 예를 들어 가로·세로 비율 잠금은 크기를 조정할 때 모양의 비율을 유지합니다.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 100, image.Width, image.Height, image);
pictureFrame.PictureFrameLock.AspectRatioLocked = true;

presentation.Save("locked-picture-frame.pptx", SaveFormat.Pptx);
```

잠금은 그림 프레임 모양에만 적용됩니다. 원본 이미지를 리샘플링하거나 영구적으로 동일한 가로·세로 비율로 변경하도록 강제하지는 않습니다.

## **StretchOffset 값 조정**

그림 채우기 모드가 stretch 일 때, [IPictureFillFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/ipicturefillformat/) 의 stretch‑offset 값은 그림 프레임 경계 상자에 대한 채우기 사각형을 정의합니다. 양의 백분율은 가장자리에서 안쪽으로 삽입을 만들고, 음의 백분율은 바깥쪽으로 돌출을 만듭니다.

이는 자르기와 다릅니다. 자르기 값은 원본 이미지의 어느 부분이 보이는지를 선택하고, stretch offset 은 보이는 그림 채우기가 늘어나는 사각형을 변경합니다.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image);
pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
pictureFrame.PictureFormat.StretchOffsetLeft = 12f;
pictureFrame.PictureFormat.StretchOffsetRight = 12f;
pictureFrame.PictureFormat.StretchOffsetTop = 8f;
pictureFrame.PictureFormat.StretchOffsetBottom = 8f;

presentation.Save("stretch-offsets.pptx", SaveFormat.Pptx);
```

채우기 위치를 조정할 때는 stretch offset 을 사용하고, 원본 이미지 가장자리를 숨기려면 자르기 속성을 사용하세요.

## **저장, 파일 크기 및 내보내기 고려사항**

이미지 저장 방식과 그림 프레임 서식 지정이 별도로 처리될 때 주요 절충점이 관리하기 쉬워집니다:

- **임베드 이미지**: 프레젠테이션을 자체 포함하게 만들어 공유 및 서버 측 렌더링에 가장 신뢰할 수 있지만, 큰 래스터 이미지는 PPTX 크기와 메모리 사용량을 증가시킵니다.
- **연결 이미지**: 패키지 크기를 작게 유지할 수 있지만, 프레젠테이션은 저장된 경로나 위치에 외부 파일이 남아 있어야 합니다.
- **자르기**: 처음에는 비파괴적입니다. 숨겨진 픽셀은 잘린 영역을 명시적으로 삭제하거나 압축 중에 제거하기 전까지는 임베드된 상태로 남아 있습니다.
- **압축**: 과도한 래스터 이미지의 파일 크기를 크게 줄일 수 있지만 원본 해상도를 포기합니다. 슬라이드에 표시될 최종 크기를 알고 난 후 적용해야 합니다.
- **SVG 이미지**: 벡터 보존이 중요한 경우 SVG 로 유지하세요. 벡터 리소스 자체가 필요할 때는 임베드된 SVG 를 직접 추출하세요. 래스터 슬라이드 내보내기는 항상 렌더링된 슬라이드를 픽셀로 변환합니다.
- **반복 이미지**: 가능한 경우 동일한 [IPPImage](https://reference.aspose.com/slides/ko/net/aspose.slides/ippimage/) 리소스를 재사용하여 동일 파일을 여러 번 로드하지 않도록 하세요.

대용량 프레젠테이션의 경우 이미지 최적화는 선택적으로 수행할 때 가장 효과적입니다: 로고와 다이어그램은 벡터 콘텐츠로 유지하고, 사진은 실제 표시 크기에 맞게 압축하며, 이후 편집이 필요하지 않은 경우에만 잘린 픽셀을 제거하고, 외부 링크는 종속성 관리가 배포 설계의 일부가 아닌 이상 피하세요.

## **FAQ**

**그림 프레임과 이미지 리소스의 차이점은 무엇인가요?**

[IPPImage](https://reference.aspose.com/slides/ko/net/aspose.slides/ippimage/) 는 프레젠테이션에 연결된 이미지 리소스를 나타냅니다. [IPictureFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/ipictureframe/) 은 이미지를 표시하고 크기, 회전, 자르기 값, 효과, 잠금과 같은 프레임 수준 기하학 및 서식을 저장하는 슬라이드상의 모양입니다.

**이미지를 임베드해야 할까요, 링크해야 할까요?**

프레젠테이션을 이식 가능하게 유지하거나 보관·외부 리소스 없이 렌더링해야 할 경우 이미지를 임베드하세요. 이미지 파일을 PPTX 외부에 두고 외부 위치를 신뢰할 수 있을 때만 이미지를 링크하세요.

**자르기가 PPTX 파일 크기를 감소시키나요?**

그 자체로는 감소시키지 않습니다. 일반적인 자르기 설정은 원본 이미지의 일부를 숨기지만 기본 픽셀은 유지합니다. 픽셀을 영구적으로 삭제하려면 [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/ko/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) 나 잘린 영역 제거와 함께 이미지 압축을 사용하세요.

**압축 후에 이미지 품질을 복원할 수 있나요?**

아닙니다. 압축은 저장된 래스터 해상도를 낮추고, 잘린 영역을 제거하면 이미지 데이터가 삭제됩니다. 후에 고해상도 편집이 필요할 경우 원본 이미지를 프레젠테이션 외부에 보관하세요.

**SVG 이미지는 어떻게 다루어야 하나요?**

벡터 정밀도가 중요한 경우 SVG 내용을 SVG 로 유지하세요. 임베드된 [ISvgImage](https://reference.aspose.com/slides/ko/net/aspose.slides/isvgimage/) 를 직접 추출할 수 있습니다. PNG나 JPEG와 같은 래스터 형식으로 슬라이드를 렌더링하면 SVG 가 픽셀로 변환됩니다.

**기존 슬라이드를 읽을 때 안전하지 않은 형 변환을 어떻게 피할 수 있나요?**

모양 유형을 확인한 후에 그림 프레임 전용 멤버를 사용하세요. [IPictureFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/ipictureframe/) 로 패턴 매칭하거나 해당 인터페이스로 모양 컬렉션을 필터링하면 잘못된 형 변환을 방지하고 그림 프레임이 없는 슬라이드도 정상적으로 처리할 수 있습니다.