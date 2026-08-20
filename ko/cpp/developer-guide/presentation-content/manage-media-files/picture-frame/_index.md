---
title: C++를 사용하여 프레젠테이션에서 그림 프레임 관리
linktitle: 그림 프레임
type: docs
weight: 10
url: /ko/cpp/picture-frame/
keywords:
- 그림 프레임
- 그림 프레임 추가
- 그림 프레임 만들기
- 삽입된 이미지
- 연결된 이미지
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
description: "Aspose.Slides for C++를 사용하여 프레젠테이션에서 그림 프레임을 만들고, 서식 지정하고, 연결하고, 자르고, 추출하고, 압축합니다."
---
## **개요**

그림 프레임은 이미지를 표시하는 슬라이드 모양입니다. Aspose.Slides에서는 이미지 리소스와 이를 표시하는 모양이 별개의 객체입니다: [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/)은 [image collection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/get_images/)을 통해 삽입된 이미지 리소스를 소유하고, [IPictureFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipictureframe/)은 이미지의 위치, 크기, 선 서식, 회전, 자르기, 그림 효과 및 기타 프레임 수준 설정을 제어합니다.

이러한 분리는 동일한 이미지를 여러 번 표시할 때 유용합니다. 이미지를 프레젠테이션에 한 번 추가하고 반환된 [IPPImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ippimage/)을 보관한 다음 그림 프레임을 만들 때 해당 이미지 리소스를 사용하십시오.

그림 프레임은 PNG 또는 JPEG와 같은 래스터 이미지와 SVG와 같은 벡터 이미지를 포함할 수 있습니다. 또한 프레젠테이션에 이미지 바이트를 저장하는 대신 연결된 이미지를 참조할 수도 있습니다. 선택에 따라 이동성, 파일 크기, 추출 및 내보내기 동작이 영향을 받으므로 서식 지정이나 최적화를 적용하기 전에 이미지 저장 방식을 결정하는 것이 유용합니다.

## **삽입된 이미지 추가 및 서식 지정**

삽입된 이미지의 경우 이미지 데이터를 프레젠테이션에 추가하고 [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/shapecollection/addpictureframe/)을 사용해 그림 프레임을 만듭니다. 이미지가 프레젠테이션 패키지의 일부가 되므로 프레젠테이션을 다른 컴퓨터로 이동해도 자체 포함됩니다.

다음 예제는 JPEG 이미지를 추가하고 이미지의 원래 크기로 프레임을 만든 다음 선 서식 및 회전을 적용합니다:

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

그림 프레임은 표시되는 기하학을 제어합니다; 프레임 크기를 변경해도 삽입된 이미지 리소스에 저장된 원본 픽셀 크기는 변경되지 않습니다. 이 구분은 나중에 이미지를 자르거나 압축할 때 중요합니다.

## **상대 스케일 사용**

[IPictureFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipictureframe/)은 프레임에 대한 상대 너비와 높이 스케일을 제공합니다. 값 `1.0`은 원본 그림 크기의 100%에 해당합니다. 상대 스케일은 최종 크기를 수동으로 계산하는 대신 원본 이미지 크기와의 비율을 유지해야 할 때 유용합니다.

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

상대 스케일은 프레임의 스케일 설정을 변경하지만 삽입된 이미지를 리샘플링하거나 압축하지는 않습니다.

## **삽입 및 연결 이미지**

삽입된 그림은 이미지 데이터를 프레젠테이션 내부에 저장하므로 이동성과 예측 가능한 렌더링에 가장 안전한 선택입니다. 연결된 그림은 [ISlidesPicture](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islidespicture/) 링크 경로를 통해 외부 위치를 저장하므로 이미지 데이터를 동일한 방식으로 삽입하지 않습니다.

연결된 이미지는 PPTX에 저장되는 이미지 데이터를 줄일 수 있지만 외부 종속성을 초래합니다. 연결된 파일은 프레젠테이션을 열거나 렌더링하는 애플리케이션이 접근할 수 있어야 합니다. 경로가 변경되거나 파일이 이동되거나 리소스를 사용할 수 없게 되면 연결된 그림이 예상대로 표시되지 않을 수 있습니다. 이메일로 전송하거나 보관하거나 격리된 환경에서 렌더링해야 하는 프레젠테이션의 경우, 삽입된 이미지가 일반적으로 더 신뢰할 수 있습니다.

### **연결된 이미지 추가**

다음 예제는 그림 프레임을 만들고 로컬 이미지 파일을 가리키도록 설정합니다. 이 예제는 이미지 연결만 다루며, 비디오 연결은 별도의 미디어 워크플로이며 의도적으로 혼합되지 않았습니다.

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

외부 파일 관리가 의도된 경우에만 링크를 사용하십시오. 압축을 대체하기 위해 링크를 사용하지 마십시오: 깨진 이미지 종속성을 가진 작은 PPTX는 일반적으로 더 큰 자체 포함 프레젠테이션보다 유용하지 않습니다.

## **그림 프레임에서 이미지 추출**

기존 프레젠테이션에서 이미지를 추출하기 전에 해당 모양이 실제로 [IPictureFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipictureframe/)인지 그리고 삽입된 이미지를 포함하고 있는지 확인하십시오. 연결된 그림 프레임은 동일한 방식으로 추출할 수 있는 이미지 바이트를 포함하지 않을 수 있습니다.

### **래스터 이미지 추출**

최신 이미지 API는 [IImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iimage/)를 직접 사용합니다. 다음 예제는 슬라이드에서 첫 번째 삽입된 래스터 그림을 찾아 PNG로 저장합니다:

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

[IImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iimage/)를 통해 저장하면 추출된 이미지를 요청된 출력 형식으로 변환합니다. 프레젠테이션에 저장된 인코딩된 바이트가 필요하고 변환된 래스터 파일이 필요하지 않은 경우 이미지 리소스의 바이너리 데이터를 사용하십시오.

### **SVG 이미지 추출**

SVG 그림의 경우 [IPPImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ippimage/)가 [ISvgImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isvgimage/) 객체를 제공합니다. 이를 통해 먼저 그림을 래스터화하지 않고 SVG 데이터를 직접 가져올 수 있습니다.

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

SVG 콘텐츠를 SVG로 유지하면 프레젠테이션 내부에 벡터 소스가 보존됩니다. PNG 또는 JPEG와 같은 래스터 내보내기는 해당 벡터 콘텐츠를 픽셀로 렌더링합니다. PDF 또는 SVG 슬라이드 내보내기도 렌더링 작업이므로, 내보낸 그래픽을 원본 삽입된 SVG와 바이트 단위로 동일하게 취급해서는 안 됩니다; 원본 벡터 리소스가 필요할 때는 삽입된 [ISvgImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isvgimage/) 데이터를 사용하십시오.

## **이미지 자르기**

자르기는 프레임 내에서 이미지의 어느 부분이 보일지를 변경합니다. [IPictureFillFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipicturefillformat/)의 자르기 값은 소스 이미지 차원의 백분율입니다. 자르기는 처음에 숨겨진 픽셀을 삽입된 이미지에서 삭제하지 않으며, 보이는 영역만 변경합니다.

다음 예제는 그림 프레임을 안전하게 찾고 자르기 값을 적용합니다:

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

숨겨진 이미지 데이터는 여전히 존재하므로 원본 픽셀을 잃지 않고 나중에 자르기를 변경할 수 있습니다. 파일 크기가 중요하고 복구 가능성이 덜 필요하다면 다음 섹션에 설명된 대로 자른 영역을 물리적으로 제거할 수 있습니다.

## **잘린 이미지 데이터 제거**

[IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/)는 현재 자르기 사각형 외부의 이미지 데이터를 제거하고 결과 이미지 리소스를 반환합니다. 이는 파일 크기를 줄일 수 있지만 파괴적인 최적화입니다: 프레젠테이션을 저장한 후에는 제거된 픽셀이 이후에 복구될 수 없습니다.

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

이 메서드는 프레젠테이션에 새로운 이미지 리소스를 추가할 수 있습니다. 원본 이미지가 다른 그림 프레임에서도 사용되는 경우 해당 프레임은 기존 리소스를 계속 필요로 하므로 잘린 영역을 삭제해도 전체 이미지 수가 반드시 줄어들지는 않습니다. WMF 또는 EMF 콘텐츠를 이 방법으로 자르면 결과가 PNG로 래스터화됩니다.

## **래스터 이미지 압축**

[IPictureFillFormat::CompressImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipicturefillformat/compressimage/)는 그림이 표시되는 크기에 비례하여 래스터 이미지 해상도를 낮춥니다. 동일한 작업에서 잘린 영역을 제거할 수도 있습니다. 메서드는 이미지가 크기 조정 또는 자르기된 경우 `true`를, 변경이 필요하지 않은 경우 `false`를 반환합니다.

표준 대상 해상도가 충분할 때는 미리 정의된 [PicturesCompression](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/picturescompression/) 값을 사용하십시오:

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

특정 목표가 필요할 경우 열거형 값 대신 양의 DPI 값을 직접 지정할 수 있습니다.

압축은 래스터 이미지에 적용됩니다. SVG 및 메타파일 콘텐츠는 이 래스터 압축 워크플로로 축소되지 않습니다. 또한 낮은 해상도와 삭제된 잘린 영역은 최적화된 프레젠테이션에서 복구할 수 없다는 점을 기억하십시오. 전체적으로 가장 낮은 DPI를 적용하기보다 실제로 보이거나 내보내질 최대 크기를 기준으로 목표 해상도를 선택하십시오.

## **이미지 효과 검사**

그림 효과는 프레임이 사용하는 그림에 저장됩니다. 이미지 변환 컬렉션에는 투명도를 위한 고정 알파 변조와 밝기·대비를 위한 휘도와 같은 효과가 포함될 수 있습니다. 아래 예제는 슬라이드의 첫 번째 그림 프레임에서 두 종류의 효과를 안전하게 읽습니다:

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ILuminance.h>
#include <DOM/Effects/ILuminanceEffectiveData.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
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
    auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();

    for (auto&& effect : imageTransform)
    {
        if (ObjectExt::Is<IAlphaModulateFixed>(effect))
        {
            auto alphaModulateFixed = ExplicitCast<IAlphaModulateFixed>(effect);
            auto transparency = 100.0f - alphaModulateFixed->get_Amount();
            Console::WriteLine(String(u"Transparency: ") + transparency);
        }

        if (ObjectExt::Is<ILuminance>(effect))
        {
            auto luminanceEffect = ExplicitCast<ILuminance>(effect);
            auto luminance = luminanceEffect->GetEffective();
            Console::WriteLine(String(u"Brightness: ") + luminance->get_Brightness());
            Console::WriteLine(String(u"Contrast: ") + luminance->get_Contrast());
        }
    }
}

presentation->Dispose();
```

이러한 효과는 프레임 내에서 이미지가 어떻게 렌더링되는지를 변경하지만 원본 삽입 이미지 바이트를 다시 쓰지는 않습니다.

## **그림 프레임 기하학 고정**

[IPictureFrameLock](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipictureframelock/) 설정은 그림 프레임에 대해 어떤 편집 작업이 비활성화될지를 제어합니다. 예를 들어, [aspect-ratio lock](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/)은 크기 조정 시 모양의 비율을 유지합니다.

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

잠금은 그림 프레임 모양에 적용됩니다. 이는 소스 이미지를 리샘플링하거나 영구적으로 동일한 종횡비로 변경하도록 강제하지 않습니다.

## **StretchOffset 값 조정**

그림 채우기 모드가 stretch인 경우, [IPictureFillFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipicturefillformat/)의 stretch‑offset 값은 그림 프레임 경계 상자에 대한 채우기 사각형을 정의합니다. 양의 백분율은 가장자리에서 안쪽으로 들어가게 하고, 음의 백분율은 바깥쪽으로 나오게 합니다.

이는 자르기와 다릅니다. 자르기 값은 소스 이미지의 어느 부분이 보일지를 선택하고, stretch offset은 보이는 그림 채우기가 늘어나는 사각형을 변경합니다.

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

채우기 위치를 지정하려면 stretch offset을 사용하십시오. 소스 이미지 가장자리를 숨기는 것이 목표라면 자르기 속성을 사용하십시오.

## **스토리지, 파일 크기 및 내보내기 고려 사항**

이미지 스토리지와 그림 프레임 서식을 별도로 처리할 때 주요 트레이드오프를 관리하기가 더 쉽습니다:

- **삽입된 이미지**는 프레젠테이션을 자체 포함하게 하며 공유 및 서버 측 렌더링에 가장 신뢰할 수 있지만, 큰 래스터 이미지는 PPTX 크기와 메모리 사용량을 증가시킵니다.
- **연결된 이미지**는 패키지를 작게 유지할 수 있지만, 프레젠테이션은 지정된 경로나 위치에 외부 파일이 남아 있어야 합니다.
- **자르기**는 처음에 비파괴적입니다. 숨겨진 픽셀은 명시적으로 삭제되거나 압축 중에 제거될 때까지 삽입된 상태로 유지됩니다.
- **압축**은 과도하게 큰 래스터 이미지의 파일 크기를 크게 줄일 수 있지만 원본 해상도를 포기합니다. 슬라이드 내에서 실제 표시될 크기가 알려진 후에 적용해야 합니다.
- **SVG 이미지**는 벡터 보존이 중요할 때 SVG로 유지해야 합니다. 벡터 리소스 자체가 필요할 때는 삽입된 SVG를 직접 추출하십시오. 래스터 슬라이드 내보내기는 항상 렌더링된 슬라이드를 픽셀로 변환합니다.
- **중복 이미지**는 가능한 경우 기존 [IPPImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ippimage/) 리소스를 재사용하고 동일한 파일을 프레젠테이션 워크플로에 반복해서 로드하지 않도록 하십시오.

대규모 프레젠테이션에서는 이미지 최적화를 선택적으로 수행하는 것이 가장 효과적입니다: 로고와 다이어그램은 벡터 콘텐츠로 유지하고, 사진은 실제 표시 크기에 따라 압축하며, 이후 편집이 필요하지 않을 때만 잘린 픽셀을 제거하고, 외부 링크는 종속성 관리가 배포 설계의 일부가 아닌 한 피하십시오.

## **FAQ**

**그림 프레임과 이미지 리소스의 차이점은 무엇인가요?**

[IPPImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ippimage/)는 프레젠테이션에 연결된 이미지 리소스를 나타냅니다. [IPictureFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipictureframe/)은 이미지를 표시하고 크기, 회전, 자르기 값, 효과 및 잠금과 같은 프레임 수준 기하학 및 서식을 저장하는 슬라이드의 모양입니다.

**이미지를 삽입해야 할까요, 연결해야 할까요?**

프레젠테이션을 이동 가능하게 하거나 보관하거나 외부 리소스 없이 렌더링해야 할 경우 이미지를 삽입하십시오. 이미지 파일을 PPTX 외부에 두는 것이 의도적이며 외부 위치를 신뢰성 있게 관리할 수 있는 경우에만 연결을 사용하십시오.

**자르기가 PPTX 파일 크기를 줄이나요?**

그 자체로는 줄지 않습니다. 일반적인 자르기 설정은 소스 이미지의 일부를 숨기지만 기본 픽셀은 유지합니다. 픽셀을 영구적으로 삭제하려면 [IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/)를 사용하거나 잘린 영역 제거와 함께 이미지 압축을 수행하십시오.

**압축 후에 이미지 품질을 복원할 수 있나요?**

아니요. 압축은 저장된 래스터 해상도를 낮추고, 잘린 영역을 제거하면 이미지 데이터가 사라집니다. 나중에 고해상도 편집이 필요할 경우 원본 소스 이미지를 프레젠테이션 외부에 보관하십시오.

**SVG 이미지는 어떻게 다루어야 하나요?**

벡터 정확성이 중요한 경우 SVG 콘텐츠를 SVG로 유지하십시오. 삽입된 [ISvgImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isvgimage/)를 직접 추출할 수 있습니다. PNG 또는 JPEG와 같은 래스터 형식으로 슬라이드를 렌더링하면 SVG가 슬라이드 이미지의 일부로 래스터화됩니다.

**기존 슬라이드를 읽을 때 안전하지 않은 캐스트를 피하려면 어떻게 해야 하나요?**

그림 프레임 전용 멤버를 사용하기 전에 모양 유형을 확인하십시오. 런타임 캐스트를 적용하기 전에 [IPictureFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipictureframe/)로 모양을 테스트하고, 캐스트 결과를 로컬 변수에 할당한 후에 그림 프레임 전용 멤버에 접근하십시오.