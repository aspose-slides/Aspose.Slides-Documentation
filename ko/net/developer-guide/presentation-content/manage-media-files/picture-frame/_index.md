---
title: .NET에서 프레젠테이션의 그림 프레임 관리
linktitle: 그림 프레임
type: docs
weight: 10
url: /ko/net/picture-frame/
keywords:
- 그림 프레임
- 그림 프레임 추가
- 그림 프레임 생성
- 삽입된 이미지
- 링크된 이미지
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
description: "Aspose.Slides for .NET으로 프레젠테이션에서 그림 프레임을 만들고, 서식 지정하고, 연결하고, 자르고, 추출하고, 압축합니다."
---
## **개요**

Picture frame은 이미지를 표시하는 슬라이드 도형입니다. Aspose.Slides에서는 이미지 리소스와 이를 표시하는 도형이 별개의 객체입니다: [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 은 [Images](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/images/) 컬렉션을 통해 삽입된 이미지 리소스를 소유하고, [IPictureFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/ipictureframe/) 은 이미지의 위치, 크기, 선 서식, 회전, 자르기, 그림 효과 및 기타 프레임 수준 설정을 제어합니다.

같은 이미지를 여러 번 표시해야 할 때 이 분리 구조가 유용합니다. 이미지를 프레젠테이션에 한 번 추가하고 반환된 [IPPImage](https://reference.aspose.com/slides/ko/net/aspose.slides/ippimage/) 를 보관한 뒤, picture frame을 만들 때 해당 이미지 리소스를 사용합니다.

Picture frame은 PNG 또는 JPEG와 같은 래스터 이미지와 SVG와 같은 벡터 이미지를 포함할 수 있습니다. 또한 프레젠테이션에 이미지 바이트를 저장하는 대신 링크된 이미지를 참조하도록 할 수 있습니다. 선택은 이동성, 파일 크기, 추출 및 내보내기 동작에 영향을 주므로 서식 지정이나 최적화를 적용하기 전에 이미지 저장 방식을 결정하는 것이 좋습니다.

## **삽입된 이미지 추가 및 서식 지정**

삽입된 이미지의 경우 이미지 데이터를 프레젠테이션에 추가하고 [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/ishapecollection/addpictureframe/) 으로 picture frame을 생성합니다. 이미지가 프레젠테이션 패키지의 일부가 되므로 프레젠테이션을 다른 컴퓨터로 이동해도 자체 포함됩니다.

다음 예제는 JPEG 이미지를 추가하고 이미지의 원래 차원으로 프레임을 만든 뒤 선 서식과 회전을 적용합니다:

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

picture frame은 표시되는 기하학을 제어합니다. 프레임 크기를 변경해도 삽입된 이미지 리소스에 저장된 원본 픽셀 차원은 변하지 않습니다. 이 구분은 나중에 이미지를 자르거나 압축할 때 중요해집니다.

## **상대 스케일 사용**

[IPictureFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/ipictureframe/) 은 프레임에 대한 상대적인 너비와 높이 스케일을 제공합니다. 값 `1.0` 은 원본 사진 크기의 100%에 해당합니다. 상대 스케일은 워크플로에서 최종 크기를 수동으로 계산하지 않고 원본 이미지 크기와의 비율을 유지해야 할 때 유용합니다.

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

상대 스케일은 프레임의 스케일 설정을 변경하지만 삽입된 이미지를 재샘플링하거나 압축하지는 않습니다.

## **삽입 및 링크된 이미지**

삽입된 picture는 이미지 데이터를 프레젠테이션 내부에 저장하므로 이동성 및 일관된 렌더링 측면에서 가장 안전한 선택입니다. 링크된 picture는 이미지 데이터를 삽입하는 대신 [ISlidesPicture](https://reference.aspose.com/slides/ko/net/aspose.slides/islidespicture/) 링크 경로를 통해 외부 위치를 저장합니다.

링크된 이미지는 PPTX에 저장되는 이미지 데이터 양을 줄일 수 있지만 외부 의존성을 도입합니다. 링크된 파일은 프레젠테이션을 열거나 렌더링하는 애플리케이션이 접근할 수 있어야 합니다. 경로가 변경되거나 파일이 이동되거나 리소스를 사용할 수 없게 되면 링크된 picture가 예상대로 표시되지 않을 수 있습니다. 이메일, 아카이브 또는 격리된 환경에서 렌더링해야 하는 프레젠테이션의 경우 삽입된 이미지가 일반적으로 더 신뢰할 수 있습니다.

### **링크된 이미지 추가**

다음 예제는 picture frame을 생성하고 로컬 이미지 파일을 가리키도록 설정합니다. 이 예제는 이미지 링크만 다루며, 비디오 링크는 별도의 미디어 워크플로이며 의도적으로 이 예제에 섞여 있지 않습니다.

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

외부 파일 관리를 의도적으로 할 경우에만 링크를 사용하세요. 압축을 대체하기 위해 사용하면 안 됩니다. 깨진 이미지 종속성을 가진 작은 PPTX는 일반적으로 더 큰 자체 포함 프레젠테이션보다 유용하지 않습니다.

## **Picture Frame에서 이미지 추출**

기존 프레젠테이션에서 이미지를 추출하기 전에 해당 도형이 실제로 [IPictureFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/ipictureframe/) 인지와 삽입된 이미지를 포함하고 있는지 확인하세요. 링크된 picture frame은 동일한 방식으로 추출할 수 있는 이미지 바이트를 포함하지 않을 수 있습니다.

### **래스터 이미지 추출**

최신 이미지 API는 [IImage](https://reference.aspose.com/slides/ko/net/aspose.slides/iimage/) 를 직접 사용하며 이전 시스템 이미지 래퍼를 요구하지 않습니다. 다음 예제는 슬라이드에서 첫 번째 삽입된 래스터 picture를 찾아 PNG로 저장합니다:

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

[IImage](https://reference.aspose.com/slides/ko/net/aspose.slides/iimage/) 를 통해 저장하면 추출된 이미지를 요청된 출력 형식으로 변환합니다. 변환된 래스터 파일이 아니라 프레젠테이션에 저장된 인코딩된 바이트가 필요하면 이미지 리소스의 바이너리 데이터를 사용하세요.

### **SVG 이미지 추출**

SVG picture의 경우 [IPPImage](https://reference.aspose.com/slides/ko/net/aspose.slides/ippimage/) 가 [ISvgImage](https://reference.aspose.com/slides/ko/net/aspose.slides/isvgimage/) 객체를 노출합니다. 이를 통해 SVG 데이터를 직접 가져올 수 있으며, 먼저 picture를 래스터화할 필요가 없습니다.

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

SVG 내용을 SVG 그대로 유지하면 프레젠테이션 내부에 벡터 소스가 보존됩니다. PNG나 JPEG와 같은 래스터 내보내기는 해당 벡터 내용을 픽셀로 렌더링합니다. PDF 또는 SVG 슬라이드 내보내기도 렌더링 작업이므로, 내보낸 그래픽을 원본 삽입된 SVG와 바이트 단위로 동일하게 취급해서는 안 됩니다; 원본 벡터 리소스가 필요할 경우 삽입된 [ISvgImage](https://reference.aspose.com/slides/ko/net/aspose.slides/isvgimage/) 데이터를 사용하세요.

## **이미지 자르기**

자르기는 프레임 내부에서 이미지의 어느 부분이 보이는지를 변경합니다. [IPictureFillFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/ipicturefillformat/) 의 자르기 값은 원본 이미지 차원의 백분율입니다. 자르기는 처음에 숨겨진 픽셀을 삽입된 이미지에서 삭제하지 않고 보이는 영역만 변경합니다.

다음 예제는 picture frame을 안전하게 찾아 자르기 값을 적용합니다:

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

숨겨진 이미지 데이터가 여전히 존재하기 때문에, 원본 픽셀을 잃지 않고 나중에 자르기 값을 변경할 수 있습니다. 파일 크기가 복원성보다 더 중요하다면 다음 섹션에 설명된 대로 물리적으로 자른 영역을 제거할 수 있습니다.

## **잘린 이미지 데이터 제거**

[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/ko/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) 은 현재 자르기 사각형 밖에 있는 이미지 데이터를 제거하고 결과 이미지 리소스를 반환합니다. 이는 파일 크기를 줄일 수 있지만 파괴적인 최적화입니다: 프레젠테이션을 저장한 후에는 제거된 픽셀이 더 이상 복원되지 않습니다.

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

이 메서드는 프레젠테이션에 새로운 이미지 리소스를 추가할 수 있습니다. 원본 이미지가 다른 picture frame에서도 사용되고 있다면 해당 프레임들은 기존 리소스를 계속 필요로 하므로, 잘린 영역을 삭제해도 전체 이미지 수가 반드시 감소하진 않습니다. WMF 또는 EMF 콘텐츠를 이 메서드로 자르면 결과가 PNG로 래스터화됩니다.

## **래스터 이미지 압축**

[IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/ko/net/aspose.slides/ipicturefillformat/compressimage/) 은 picture가 표시되는 크기에 비례하여 래스터 이미지 해상도를 낮춥니다. 또한 동일한 작업에서 잘린 영역을 제거할 수 있습니다. 메서드는 이미지가 리사이즈되었거나 자르기가 적용된 경우 `true` 를, 변화가 필요 없을 경우 `false` 를 반환합니다.

표준 목표 해상도가 충분히 만족스러울 때는 미리 정의된 [PicturesCompression](https://reference.aspose.com/slides/ko/net/aspose.slides.export/picturescompression/) 값을 사용하세요:

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

특정 목표가 필요할 경우 열거형 값 대신 양수 DPI 값을 전달할 수 있습니다.

압축은 래스터 이미지에만 적용됩니다. SVG 및 메타파일 콘텐츠는 이 래스터 압축 워크플로로 감소되지 않습니다. 또한 낮은 해상도와 삭제된 잘린 영역은 최적화된 프레젠테이션에서 복구할 수 없다는 점을 기억하세요. 전역적으로 가장 낮은 DPI를 적용하기보다 이미지가 실제로 표시되거나 내보내질 가장 큰 크기를 기준으로 목표 해상도를 선택하세요.

## **이미지 변환 효과 관리**

밝기, 대비, 색상 변환, 블러, 알파 효과, 순차 체인, 검사, 제거 및 라운드 트립 검증을 포함하는 전체 워크플로는 [Image Transform Effects](/slides/ko/net/image-transform-effects/) 를 참조하세요.

## **Picture Frame 기하학 고정**

[IPictureFrameLock](https://reference.aspose.com/slides/ko/net/aspose.slides/ipictureframelock/) 설정은 picture frame에 대해 어떤 편집 작업을 비활성화할지 제어합니다. 예를 들어 가로세로 비율 고정은 크기 조정 시 도형 비율을 유지합니다.

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

잠금은 picture frame 도형에만 적용됩니다. 원본 이미지를 재샘플링하거나 영구적으로 같은 가로세로 비율로 변경하도록 강제하지는 않습니다.

## **StretchOffset 값 조정**

picture fill 모드가 stretch인 경우 [IPictureFillFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/ipicturefillformat/) 의 stretch‑offset 값은 picture frame 경계 상자에 대해 상대적인 채우기 사각형을 정의합니다. 양수 백분율은 가장자리에서 안쪽으로 inset을 만들고, 음수 백분율은 바깥쪽으로 outset을 만듭니다.

이는 자르기와 다릅니다. 자르기 값은 원본 이미지의 어느 부분이 보일지를 선택하고, stretch offset은 보이는 picture fill이 늘어나는 사각형을 변경합니다.

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

채우기 위치 지정에는 stretch offset을 사용하고, 원본 이미지 가장자리를 숨기는 것이 목표라면 자르기 속성을 사용하세요.

## **스토리지, 파일 크기 및 내보내기 고려사항**

이미지 스토리지와 picture‑frame 서식을 별도로 취급할 때 주요 절충점이 더 명확해집니다:

- **삽입된 이미지**는 프레젠테이션을 자체 포함하게 하며 공유 및 서버‑사이드 렌더링에 가장 신뢰성을 제공합니다. 하지만 큰 래스터 이미지는 PPTX 크기와 메모리 사용량을 증가시킵니다.
- **링크된 이미지**는 패키지를 작게 유지할 수 있지만, 프레젠테이션은 저장된 경로나 위치에 외부 파일이 남아 있어야 합니다.
- **자르기**는 초기에는 비파괴적입니다. 숨겨진 픽셀은 잘린 영역을 명시적으로 삭제하거나 압축 중에 제거하기 전까지 삽입된 상태로 유지됩니다.
- **압축**은 과도하게 큰 래스터 이미지의 파일 크기를 크게 줄일 수 있지만 원본 해상도를 포기합니다. 슬라이드에 표시될 최종 크기가 확정된 후에 적용해야 합니다.
- **SVG 이미지**는 벡터 보존이 중요할 때 SVG 그대로 유지하십시오. 벡터 리소스 자체가 필요하면 삽입된 SVG를 직접 추출하세요. 래스터 슬라이드 내보내기는 항상 렌더링된 슬라이드를 픽셀로 변환합니다.
- **반복 이미지**는 가능한 한 기존 [IPPImage](https://reference.aspose.com/slides/ko/net/aspose.slides/ippimage/) 리소스를 재사용하고, 동일 파일을 프레젠테이션 워크플로에 반복 로드하지 마세요.

대용량 프레젠테이션의 경우 이미지 최적화는 선택적으로 수행할 때 가장 효과적입니다: 로고와 다이어그램은 벡터 콘텐츠로 유지하고, 사진은 실제 표시 크기에 맞게 압축하며, 나중에 편집이 필요 없을 경우에만 잘린 픽셀을 제거하고, 외부 링크는 종속성 관리가 배포 설계의 일부가 아닌 한 피하십시오.

## **FAQ**

**picture frame과 이미지 리소스의 차이점은 무엇인가요?**

[IPPImage](https://reference.aspose.com/slides/ko/net/aspose.slides/ippimage/) 은 프레젠테이션과 연결된 이미지 리소스를 나타냅니다. [IPictureFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/ipictureframe/) 은 슬라이드에 배치된 도형으로, 이미지 표시와 크기, 회전, 자르기 값, 효과, 잠금 등 프레임 수준의 기하학 및 서식을 저장합니다.

**이미지를 삽입해야 할까요, 링크해야 할까요?**

프레젠테이션을 이동 가능하게 하거나 아카이브하거나 외부 리소스 없이 렌더링해야 할 경우 이미지를 삽입하세요. 이미지 파일을 PPTX 외부에 두고 외부 위치를 신뢰성 있게 유지할 수 있는 경우에만 링크를 사용하세요.

**자르기가 PPTX 파일 크기를 줄이나요?**

단독으로는 줄어들지 않습니다. 일반적인 자르기 설정은 이미지 일부를 숨기지만 기반 픽셀은 유지합니다. 픽셀을 영구적으로 삭제하려면 [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/ko/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) 나 잘린 영역 제거가 포함된 이미지 압축을 사용하세요.

**압축 후 이미지 품질을 복원할 수 있나요?**

아닙니다. 압축은 저장된 래스터 해상도를 낮추고, 잘린 영역을 제거하면 이미지 데이터가 사라집니다. 나중에 고해상도 편집이 필요하면 원본 이미지를 프레젠테이션 외부에 보관하세요.

**SVG 이미지는 어떻게 다루어야 하나요?**

벡터 정확성이 중요할 때 SVG 내용을 SVG 그대로 유지하세요. 삽입된 [ISvgImage](https://reference.aspose.com/slides/ko/net/aspose.slides/isvgimage/) 를 직접 추출할 수 있습니다. PNG나 JPEG와 같은 래스터 형식으로 슬라이드를 렌더링하면 SVG가 슬라이드 이미지의 일부로 래스터화됩니다.

**기존 슬라이드를 읽을 때 안전하지 않은 캐스트를 어떻게 피할 수 있나요?**

picture‑frame‑특정 멤버를 사용하기 전에 도형 유형을 확인하세요. [IPictureFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/ipictureframe/) 로 패턴 매칭하거나 해당 인터페이스로 도형 컬렉션을 필터링하면 잘못된 캐스트를 방지하고 picture frame이 없는 슬라이드도 정상적으로 처리할 수 있습니다.