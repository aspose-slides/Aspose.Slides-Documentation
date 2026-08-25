---
title: C++를 사용하여 프레젠테이션에서 그림 프레임 관리
linktitle: 그림 프레임
type: docs
weight: 10
url: /ko/cpp/picture-frame/
keywords:
- 그림 프레임
- 그림 프레임 추가
- 그림 프레임 생성
- 내장 이미지
- 링크된 이미지
- 이미지 추출
- 래스터 이미지
- SVG 이미지
- 이미지 자르기
- 잘린 영역 삭제
- 이미지 압축
- StretchOffset
- 그림 프레임 서식 지정
- 상대 스케일
- 이미지 효과
- 종횡비
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 프레젠테이션에서 그림 프레임을 만들고, 서식 지정하고, 연결하고, 자르고, 추출하며, 압축합니다."
---
## **개요**

그림 프레임은 이미지를 표시하는 슬라이드 도형입니다. Aspose.Slides에서는 이미지 리소스와 이를 표시하는 도형이 별개의 객체입니다: [프레젠테이션](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/)은 [이미지 컬렉션](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/get_images/)을 통해 내장 이미지 리소스를 소유하고, [IPictureFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipictureframe/)은 이미지의 위치, 크기, 선 서식, 회전, 자르기, 그림 효과 및 기타 프레임 수준 설정을 제어합니다.

같은 이미지를 여러 번 표시해야 할 때 이 구분이 유용합니다. 이미지를 프레젠테이션에 한 번 추가하고 반환된 [IPPImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ippimage/)을 보관한 다음, 그림 프레임을 만들 때 해당 이미지 리소스를 사용합니다.

그림 프레임은 PNG 또는 JPEG 같은 래스터 이미지와 SVG 같은 벡터 이미지를 포함할 수 있습니다. 또한 이미지 바이트를 프레젠테이션에 저장하는 대신 링크된 이미지를 참조할 수도 있습니다. 선택은 휴대성, 파일 크기, 추출 및 내보내기 동작에 영향을 미치므로 서식 지정이나 최적화를 적용하기 전에 이미지 저장 방식을 결정하는 것이 좋습니다.

## **내장 이미지 추가 및 서식 지정**

내장 이미지를 사용하려면 이미지 데이터를 프레젠테이션에 추가하고 [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/shapecollection/addpictureframe/)으로 그림 프레임을 만듭니다. 이미지는 프레젠테이션 패키지의 일부가 되므로 프레젠테이션을 다른 컴퓨터로 이동해도 자체 포함 상태를 유지합니다.

다음 예제는 JPEG 이미지를 추가하고 이미지의 고유 크기로 프레임을 만든 뒤, 선 서식과 회전을 적용합니다:

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 100, image->get_Width(), image->get_Height(), image);
pictureFrame->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pictureFrame->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pictureFrame->get_LineFormat()->set_Width(3.0);
pictureFrame->set_Rotation(15.0f);

presentation->Save(u"picture-frame.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

그림 프레임은 표시되는 기하학을 제어합니다; 프레임 크기를 변경해도 내장 이미지 리소스에 저장된 원본 픽셀 크기는 변하지 않습니다. 이 구분은 나중에 이미지를 자르거나 압축할 때 중요합니다.

## **상대 스케일 사용**

[IPictureFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipictureframe/)은 프레임에 대한 상대 너비와 높이 스케일을 제공합니다. 값 `1.0`은 원본 그림 크기의 100%에 해당합니다. 상대 스케일은 최종 크기를 수동으로 계산하기보다 원본 이미지 크기와의 비율을 유지해야 할 때 유용합니다.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, image);
pictureFrame->set_RelativeScaleWidth(1.35f);
pictureFrame->set_RelativeScaleHeight(0.8f);

presentation->Save(u"relative-scale.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

상대 스케일은 프레임의 스케일 설정만 변경하며, 내장 이미지를 재샘플링하거나 압축하지는 않습니다.

## **내장 이미지와 링크 이미지**

내장 그림은 이미지 데이터를 프레젠테이션 내부에 저장하므로 휴대성과 예측 가능한 렌더링 측면에서 가장 안전한 선택입니다. 링크된 그림은 [ISlidesPicture](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islidespicture/) 링크 경로를 통해 외부 위치를 저장하므로 동일한 방식으로 이미지 데이터를 내장하지 않습니다.

링크된 이미지는 PPTX 파일에 저장되는 이미지 데이터 양을 줄일 수 있지만 외부 의존성을 도입합니다. 링크된 파일은 프레젠테이션을 열거나 렌더링하는 애플리케이션이 접근할 수 있어야 합니다. 경로가 변경되거나 파일이 이동되거나 리소스를 사용할 수 없게 되면 링크된 그림이 예상대로 표시되지 않을 수 있습니다. 이메일로 전송하거나 아카이브하거나 격리된 환경에서 렌더링해야 하는 프레젠테이션의 경우 내장 이미지가 일반적으로 더 신뢰됩니다.

### **링크 이미지 추가**

다음 예제는 그림 프레임을 만들고 로컬 이미지 파일을 가리키도록 설정합니다. 이 예제는 이미지 링크만 다루며, 비디오 링크는 별도의 미디어 워크플로우이며 의도적으로 섞지 않았습니다.

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 320, 180, nullptr);
auto linkPath = Path::GetFullPath(u"linked-image.jpg");
pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(linkPath);

presentation->Save(u"linked-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

외부 파일 관리를 의도적으로 할 경우에만 링크를 사용하십시오. 압축을 대체하기 위해 사용하면 안 됩니다: 깨진 이미지 종속성이 있는 작은 PPTX는 일반적으로 크기가 큰 자체 포함 프레젠테이션보다 덜 유용합니다.

## **그림 프레임에서 이미지 추출**

기존 프레젠테이션에서 이미지를 추출하기 전에 도형이 실제로 [IPictureFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipictureframe/)인지, 내장 이미지를 포함하고 있는지 확인하십시오. 링크된 그림 프레임은 같은 방식으로 추출할 수 있는 이미지 바이트를 포함하지 않을 수 있습니다.

### **래스터 이미지 추출**

최신 이미지 API는 [IImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iimage/)을 직접 사용합니다. 다음 예제는 슬라이드에서 첫 번째 내장 래스터 그림을 찾아 PNG로 저장합니다:

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IPictureFrame>(shape))
    {
        continue;
    }

    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto embeddedImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image();
    if (embeddedImage == nullptr || embeddedImage->get_SvgImage() != nullptr)
    {
        continue;
    }

    auto rasterImage = embeddedImage->get_Image();
    rasterImage->Save(u"extracted-image.png", ImageFormat::Png);
    break;
}

presentation->Dispose();
```

[IImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iimage/)를 통해 저장하면 추출된 이미지를 원하는 출력 형식으로 변환합니다. 프레젠테이션에 저장된 인코딩된 바이트가 필요하면 변환된 래스터 파일 대신 이미지 리소스의 바이너리 데이터를 사용하십시오.

### **SVG 이미지 추출**

SVG 그림의 경우, [IPPImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ippimage/)이 [ISvgImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isvgimage/) 객체를 제공합니다. 이를 통해 먼저 그림을 래스터화하지 않고 SVG 데이터를 직접 가져올 수 있습니다.

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IPictureFrame>(shape))
    {
        continue;
    }

    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto embeddedImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image();
    if (embeddedImage == nullptr)
    {
        continue;
    }

    auto svgImage = embeddedImage->get_SvgImage();
    if (svgImage == nullptr)
    {
        continue;
    }

    File::WriteAllBytes(u"extracted-image.svg", svgImage->get_SvgData());
    break;
}

presentation->Dispose();
```

SVG 내용을 SVG로 유지하면 프레젠테이션 내부에 벡터 소스를 보존합니다. PNG 또는 JPEG 같은 래스터 내보내기는 해당 벡터 내용을 픽셀로 렌더링합니다. PDF 또는 SVG 슬라이드 내보내기도 렌더링 작업이므로, 원본 내장 SVG의 바이트-투-바이트 복사본으로 취급해서는 안 됩니다; 원본 벡터 리소스가 필요할 때는 내장 [ISvgImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isvgimage/) 데이터를 사용하십시오.

## **이미지 자르기**

자르기는 프레임 내부에 표시되는 이미지 영역을 변경합니다. [IPictureFillFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipicturefillformat/)의 자르기 값은 원본 이미지 차원의 백분율입니다. 자르기는 초기에는 숨겨진 픽셀을 삭제하지 않고 보이는 영역만 변경합니다.

다음 예제는 그림 프레임을 안전하게 찾아 자르기 값을 적용합니다:

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    pictureFrame->get_PictureFormat()->set_CropLeft(23.6f);
    pictureFrame->get_PictureFormat()->set_CropRight(21.5f);
    pictureFrame->get_PictureFormat()->set_CropTop(3.0f);
    pictureFrame->get_PictureFormat()->set_CropBottom(31.0f);
    presentation->Save(u"cropped-image.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

숨겨진 이미지 데이터가 여전히 존재하므로, 원본 픽셀을 손실 없이 나중에 자르기를 변경할 수 있습니다. 파일 크기가 더 중요하고 복구 가능성이 필요 없을 경우, 다음 섹션에서 설명한 대로 자른 영역을 물리적으로 제거할 수 있습니다.

## **잘린 이미지 데이터 제거**

[IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/)는 현재 자르기 사각형 외부의 이미지 데이터를 제거하고 결과 이미지 리소스를 반환합니다. 이는 파일 크기를 줄일 수 있지만 파괴적인 최적화이며, 프레젠테이션을 저장한 후에는 제거된 픽셀이 나중에 복원되지 않습니다.

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"cropped-image.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto croppedImage = pictureFrame->get_PictureFormat()->DeletePictureCroppedAreas();
    if (croppedImage != nullptr)
    {
        presentation->Save(u"cropped-data-removed.pptx", SaveFormat::Pptx);
    }
}

presentation->Dispose();
```

이 메서드는 프레젠테이션에 새로운 이미지 리소스를 추가할 수 있습니다. 원본 이미지가 다른 그림 프레임에서도 사용되는 경우, 해당 프레임은 기존 리소스를 계속 필요로 하므로 잘린 영역을 삭제해도 전체 이미지 수가 반드시 감소하는 것은 아닙니다. WMF 또는 EMF 콘텐츠를 이 메서드로 자르면 결과가 PNG로 래스터화됩니다.

## **래스터 이미지 압축**

[IPictureFillFormat::CompressImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipicturefillformat/compressimage/)는 그림이 표시되는 크기에 비례하여 래스터 이미지 해상도를 낮춥니다. 동일한 작업에서 잘린 영역을 제거할 수도 있습니다. 메서드는 이미지가 크기 조정 또는 자르기가 수행되면 `true`를 반환하고, 변경이 필요 없으면 `false`를 반환합니다.

표준 목표 해상도가 충분할 때는 미리 정의된 [PicturesCompression](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/picturescompression/) 값을 사용하십시오:

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto compressed = pictureFrame->get_PictureFormat()->CompressImage(true, PicturesCompression::Dpi150);
    Console::WriteLine(compressed ? String(u"The image was compressed.") : String(u"No compression was necessary."));
    presentation->Save(u"compressed-image.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

특정 목표가 필요한 경우 열거형 값 대신 양의 DPI 값을 직접 전달할 수 있습니다.

압축은 래스터 이미지에만 적용됩니다. SVG 및 메타파일 콘텐츠는 이 래스터 압축 워크플로우에서 감소되지 않습니다. 또한 낮은 해상도와 삭제된 잘린 영역은 최적화된 프레젠테이션에서 복구할 수 없음을 기억하십시오. 전역적으로 가장 낮은 DPI를 적용하기보다 실제로 보이거나 내보내질 최대 크기를 기준으로 목표 해상도를 선택하십시오.

## **이미지 변환 효과 관리**

밝기, 대비, 색상 변환, 블러, 알파 효과, 순서 체인, 검사, 제거 및 라운드트립 검증을 포함하는 전체 워크플로우는 [이미지 변환 효과](/slides/ko/cpp/image-transform-effects/)를 참고하십시오.

## **그림 프레임 기하학 잠금**

[IPictureFrameLock](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipictureframelock/) 설정은 그림 프레임에 대해 어떤 편집 작업이 비활성화되는지를 제어합니다. 예를 들어, [종횡비 잠금](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/)은 크기를 조정할 때 도형의 비율을 유지합니다.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 100, image->get_Width(), image->get_Height(), image);
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);

presentation->Save(u"locked-picture-frame.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

잠금은 그림 프레임 도형에만 적용됩니다. 소스 이미지를 재샘플링하거나 영구적으로 동일한 종횡비로 변경하도록 강제하지는 않습니다.

## **StretchOffset 값 조정**

그림 채우기 모드가 스트레치인 경우, [IPictureFillFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipicturefillformat/)의 stretch‑offset 값은 그림 프레임 경계 상자에 상대적인 채우기 사각형을 정의합니다. 양의 백분율은 가장자리에서 안쪽으로 들여쓰기하고, 음의 백분율은 바깥쪽으로 돌출시킵니다.

이는 자르기와 다릅니다. 자르기 값은 원본 이미지의 어느 부분을 표시할지 선택하고, stretch‑offset은 보이는 그림 채우기가 늘어나는 사각형을 변경합니다.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.png");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10, 10, 400, 300, image);
pictureFrame->get_PictureFormat()->set_PictureFillMode(PictureFillMode::Stretch);
pictureFrame->get_PictureFormat()->set_StretchOffsetLeft(12.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetRight(12.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetTop(8.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetBottom(8.0f);

presentation->Save(u"stretch-offsets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

채우기 위치를 지정하려면 stretch‑offset을 사용하고, 원본 이미지 가장자리를 숨기려면 자르기 속성을 사용하십시오.

## **스토리지, 파일 크기 및 내보내기 고려 사항**

이미지 스토리지와 그림‑프레임 서식을 별도로 다룰 때 주요 트레이드오프를 관리하기가 쉬워집니다:

- **내장 이미지**는 프레젠테이션을 자체 포함하게 만들어 공유 및 서버‑사이드 렌더링에 가장 신뢰할 수 있지만, 큰 래스터 이미지는 PPTX 크기와 메모리 사용량을 증가시킵니다.
- **링크 이미지**는 패키지 크기를 줄일 수 있지만, 프레젠테이션은 지정된 경로나 위치에 외부 파일이 유지되는지에 의존합니다.
- **자르기**는 처음에 비파괴적이며, 숨겨진 픽셀은 명시적으로 삭제하거나 압축 중에 제거하기 전까지는 남아 있습니다.
- **압축**은 과도한 래스터 이미지의 파일 크기를 크게 줄일 수 있지만 원본 해상도를 포기합니다. 슬라이드에 표시될 최종 크기를 알게 된 후에 적용해야 합니다.
- **SVG 이미지**는 벡터 보존이 중요할 때 SVG 형태로 유지해야 합니다. 벡터 리소스 자체가 필요할 때는 내장 SVG를 직접 추출하십시오. 래스터 슬라이드 내보내기는 항상 렌더링된 슬라이드를 픽셀로 변환합니다.
- **반복 이미지**는 가능한 경우 기존 [IPPImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ippimage/) 리소스를 재사용하고 동일 파일을 여러 번 로드하지 않도록 하십시오.

대형 프레젠테이션의 경우 이미지 최적화는 선택적으로 수행할 때 가장 효과적입니다: 로고와 다이어그램은 벡터 콘텐츠로 유지하고, 사진은 실제 표시 크기에 따라 압축하며, 나중에 편집이 필요하지 않을 경우에만 잘린 픽셀을 제거하고, 외부 링크는 의존성 관리가 배포 설계의 일부가 아닌 한 피하십시오.

## **FAQ**

**그림 프레임과 이미지 리소스의 차이는 무엇인가요?**

[IPPImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ippimage/)은 프레젠테이션에 연결된 이미지 리소스를 나타냅니다. [IPictureFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipictureframe/)은 슬라이드에 있는 도형으로, 이미지를 표시하고 크기, 회전, 자르기 값, 효과, 잠금 등 프레임 수준의 기하학 및 서식을 저장합니다.

**이미지를 내장할지 링크할지 어떻게 결정해야 하나요?**

프레젠테이션을 휴대 가능하게 만들거나 아카이브하거나 외부 리소스 없이 렌더링해야 한다면 이미지를 내장하십시오. 이미지 파일을 PPTX 외부에 두고 외부 위치를 안정적으로 유지할 수 있는 경우에만 링크하십시오.

**자르기가 PPTX 파일 크기를 줄이나요?**

자체적으로는 그렇지 않습니다. 일반적인 자르기 설정은 소스 이미지의 일부를 숨기지만 기본 픽셀은 유지합니다. 픽셀을 영구적으로 삭제하려면 [IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/)를 사용하거나 잘린 영역 제거와 함께 이미지 압축을 수행하십시오.

**압축 후에 이미지 품질을 복구할 수 있나요?**

없습니다. 압축은 저장된 래스터 해상도를 낮추고, 잘린 영역을 제거하면 이미지 데이터가 삭제됩니다. 나중에 고해상도 편집이 필요할 경우 원본 소스 이미지를 프레젠테이션 외부에 보관하십시오.

**SVG 이미지는 어떻게 처리해야 하나요?**

벡터 정확도가 중요할 때 SVG 내용을 SVG로 유지하십시오. 내장된 [ISvgImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isvgimage/)를 직접 추출할 수 있습니다. PNG 또는 JPEG와 같은 래스터 형식으로 슬라이드를 렌더링하면 SVG가 픽셀로 변환됩니다.

**기존 슬라이드를 읽을 때 안전하지 않은 형변환을 피하려면 어떻게 해야 하나요?**

도형 유형을 확인한 후에 그림‑프레임 전용 멤버를 사용하십시오. 런타임 형변환을 적용하기 전에 [IPictureFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipictureframe/)인지 테스트하고, 변환 결과를 로컬 변수에 할당한 뒤 그림‑프레임 전용 멤버에 접근하십시오.