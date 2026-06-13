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
- 이미지 추가
- 이미지 생성
- 이미지 추출
- 래스터 이미지
- 벡터 이미지
- 이미지 자르기
- 잘린 영역
- StretchOff 속성
- 그림 프레임 포맷팅
- 그림 프레임 속성
- 상대 스케일
- 이미지 효과
- 가로세로 비율
- 이미지 투명도
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에 그림 프레임을 추가합니다. 워크플로를 간소화하고 슬라이드 디자인을 향상시키세요."
---
## **소개**

그림 프레임은 이미지를 포함하는 모양으로, 프레임 안의 그림과 같습니다.  

그림 프레임을 통해 슬라이드에 이미지를 추가할 수 있습니다. 이렇게 하면 그림 프레임을 포맷함으로써 이미지를 포맷할 수 있습니다.

{{% alert  title="Tip" color="primary" %}} 

Aspose는 무료 변환기—[JPEG to PowerPoint](https://products.aspose.app/slides/ko/import/jpg-to-ppt) 및 [PNG to PowerPoint](https://products.aspose.app/slides/ko/import/png-to-ppt)—를 제공하여 사용자가 이미지를 빠르게 프레젠테이션으로 만들 수 있게 합니다. 

{{% /alert %}} 

## **그림 프레임 만들기**

1. 프레젠테이션 클래스의 인스턴스를 생성합니다.([Presentation class](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation))
2. 인덱스를 통해 슬라이드 참조를 가져옵니다. 
3. 프레젠테이션 개체와 연결된 [IImagescollection](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_image_collection)에 이미지를 추가하여 [IPPImage](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_p_p_image) 객체를 생성합니다. 이 객체는 모양을 채우는 데 사용됩니다. 
4. 이미지의 너비와 높이를 지정합니다. 
5. 참조된 슬라이드와 연결된 shape 객체가 제공하는 `AddPictureFrame` 메서드를 사용하여 이미지의 너비와 높이를 기반으로 [PictureFrame](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.picture_frame)을 생성합니다. 
6. 그림이 포함된 그림 프레임을 슬라이드에 추가합니다. 
7. 수정된 프레젠테이션을 PPTX 파일로 저장합니다. 

이 C++ 코드는 그림 프레임을 만드는 방법을 보여줍니다:

```c++
// 문서 디렉터리 경로.
const String outPath = u"../out/PictureFrameFormatting_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// 원하는 프레젠테이션을 로드합니다
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 첫 번째 슬라이드에 접근
SharedPtr<ISlide> slide = pres->get_Slide(0);

// 프레젠테이션 이미지 컬렉션에 추가될 이미지를 로드합니다
// 그림을 가져옵니다
auto image = Images::FromFile(filePath);

// 프레젠테이션 이미지 컬렉션에 이미지를 추가합니다
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// 슬라이드에 그림 프레임을 추가합니다
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// 상대 스케일 너비와 높이를 설정합니다
pf->set_RelativeScaleHeight(0.8);
pf->set_RelativeScaleWidth(1.35);
// 그림 프레임에 일부 포맷을 적용합니다
pf->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pf->get_LineFormat()->set_Width ( 20);
pf->set_Rotation( 45);

// PPTX 파일을 디스크에 저장합니다
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert color="warning" %}} 

그림 프레임을 사용하면 이미지를 기반으로 프레젠테이션 슬라이드를 빠르게 만들 수 있습니다. 그림 프레임을 Aspose.Slides 저장 옵션과 결합하면 입력/출력 작업을 조작해 이미지를 다른 형식으로 변환할 수 있습니다. 다음 페이지를 참고하세요: [image to JPG](https://products.aspose.com/slides/ko/cpp/conversion/image-to-jpg/) 변환; [JPG to image](https://products.aspose.com/slides/ko/cpp/conversion/jpg-to-image/) 변환; [JPG to PNG](https://products.aspose.com/slides/ko/cpp/conversion/jpg-to-png/) 변환, [PNG to JPG](https://products.aspose.com/slides/ko/cpp/conversion/png-to-jpg/) 변환; [PNG to SVG](https://products.aspose.com/slides/ko/cpp/conversion/png-to-svg/) 변환, [SVG to PNG](https://products.aspose.com/slides/ko/cpp/conversion/svg-to-png/) 변환. 

{{% /alert %}}

## **상대 스케일을 사용한 그림 프레임 만들기**

이미지의 상대 스케일을 변경하면 보다 복잡한 그림 프레임을 만들 수 있습니다. 

1. 프레젠테이션 클래스의 인스턴스를 생성합니다.([Presentation class](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation))
2. 인덱스를 통해 슬라이드 참조를 가져옵니다. 
3. 프레젠테이션 이미지 컬렉션에 이미지를 추가합니다. 
4. 프레젠테이션 개체와 연결된 [IImagescollection](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_image_collection)에 이미지를 추가하여 [IPPImage](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_p_p_image) 객체를 생성합니다. 
5. 그림 프레임에서 이미지의 상대 너비와 높이를 지정합니다. 
6. 수정된 프레젠테이션을 PPTX 파일로 저장합니다. 

이 C++ 코드는 상대 스케일을 사용한 그림 프레임 만드는 방법을 보여줍니다:

```c++
// 문서 디렉터리 경로.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// 원하는 프레젠테이션을 로드합니다
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 첫 번째 슬라이드에 접근합니다
SharedPtr<ISlide> slide = pres->get_Slide(0);

// 프레젠테이션 이미지 컬렉션에 추가될 이미지를 로드합니다
// 그림을 가져옵니다
auto image = Images::FromFile(filePath);

// 프레젠테이션 이미지 컬렉션에 이미지를 추가합니다
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// 슬라이드에 그림 프레임을 추가합니다
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// 상대 스케일 너비와 높이를 설정합니다
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

// PPTX 파일을 디스크에 저장합니다
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **그림 프레임에서 래스터 이미지 추출**

[PictureFrame](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.picture_frame) 객체에서 래스터 이미지를 추출하여 PNG, JPG 등 다양한 형식으로 저장할 수 있습니다. 아래 코드 예제는 문서 “sample.pptx”에서 이미지를 추출해 PNG 형식으로 저장하는 방법을 보여줍니다.

```c++
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstSlide = presentation->get_Slide(0);
auto firstShape = firstSlide->get_Shape(0);
    
if (ObjectExt::Is<IPictureFrame>(firstShape))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(firstShape);
    auto image = pictureFrame->get_PictureFormat()->get_Picture()->get_Image()->get_SystemImage();

    image->Save(u"slide_1_shape_1.png", ImageFormat::get_Png());
}

presentation->Dispose();
```

## **그림 프레임에서 SVG 이미지 추출**

프레젠테이션에 [PictureFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/pictureframe/) 모양 안에 SVG 그래픽이 포함된 경우, Aspose.Slides for C++를 사용하면 원본 벡터 이미지를 완전한 품질로 가져올 수 있습니다. 슬라이드의 shape 컬렉션을 순회하면서 각 [PictureFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/pictureframe/)을 확인하고, 해당 [IPPImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ippimage/)이 SVG 콘텐츠를 포함하고 있는지 판단한 뒤, 원시 SVG 형식으로 디스크나 스트림에 저장합니다.

다음 코드 예제는 그림 프레임에서 SVG 이미지를 추출하는 방법을 보여줍니다:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IPictureFrame>(shape))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto svgImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image()->get_SvgImage();
    if (svgImage != nullptr)
    {
        File::WriteAllText(u"output.svg", svgImage->get_SvgContent());
    }
}

presentation->Dispose();
```

## **이미지 투명도 가져오기**

Aspose.Slides를 사용하면 이미지에 적용된 투명도 효과를 가져올 수 있습니다. 이 C++ 코드는 해당 작업을 보여줍니다:

```c++
auto presentation = System::MakeObject<Presentation>(u"Test.pptx");
auto pictureFrame = System::ExplicitCast<IPictureFrame>(presentation->get_Slide(0)->get_Shape(0));
auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
for (auto&& effect : imageTransform)
{
    if (System::ObjectExt::Is<IAlphaModulateFixed>(effect))
    {
        float transparencyValue = 100.0f - (System::ExplicitCast<IAlphaModulateFixed>(effect))->get_Amount();
        System::Console::WriteLine(System::String(u"Picture transparency: ") + transparencyValue);
    }
}
```

{{% alert color="primary" %}} 
이미지에 적용된 모든 효과는 [Aspose::Slides::Effects](https://reference.aspose.com/slides/ko/cpp/aspose.slides.effects/)에서 확인할 수 있습니다. 
{{% /alert %}}

## **그림 프레임 포맷팅**

Aspose.Slides는 그림 프레임에 적용할 수 있는 다양한 포맷 옵션을 제공합니다. 이러한 옵션을 사용하면 특정 요구 사항에 맞게 그림 프레임을 조정할 수 있습니다.

1. 프레젠테이션 클래스의 인스턴스를 생성합니다.([Presentation class](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation))
2. 인덱스를 통해 슬라이드 참조를 가져옵니다. 
3. 프레젠테이션 개체와 연결된 [IImagescollection](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_image_collection)에 이미지를 추가하여 [IPPImage](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_p_p_image) 객체를 생성합니다. 
4. 이미지의 너비와 높이를 지정합니다. 
5. [IShapes](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_shape_collection) 객체가 제공하는 [AddPictureFrame](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) 메서드를 통해 이미지의 너비와 높이를 기반으로 `PictureFrame`을 생성합니다. 
6. 그림이 포함된 그림 프레임을 슬라이드에 추가합니다. 
7. 그림 프레임의 선 색상을 설정합니다. 
8. 그림 프레임의 선 두께를 설정합니다. 
9. 양수 또는 음수 값을 지정하여 그림 프레임을 회전합니다. 
   * 양수 값은 시계 방향으로 회전합니다. 
   * 음수 값은 반시계 방향으로 회전합니다. 
10. 그림 프레임(그림 포함)을 슬라이드에 다시 추가합니다. 
11. 수정된 프레젠테이션을 PPTX 파일로 저장합니다. 

이 C++ 코드는 그림 프레임 포맷팅 과정을 보여줍니다:

```c++
// 문서 디렉터리 경로.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// 원하는 프레젠테이션을 로드합니다
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 첫 번째 슬라이드에 접근합니다
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// 프레젠테이션 이미지 컬렉션에 추가될 이미지를 로드합니다
// 그림을 가져옵니다
auto image = Images::FromFile(filePath);

// 프레젠테이션 이미지 컬렉션에 이미지를 추가합니다
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// 슬라이드에 그림 프레임을 추가합니다
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// 상대 스케일 너비와 높이를 설정합니다
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

// PPTX 파일을 디스크에 저장합니다
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert title="Tip" color="primary" %}}

Aspose는 최근에 무료 [Collage Maker](https://products.aspose.app/slides/ko/collage)를 출시했습니다. JPG/JPEG 또는 PNG 이미지를 병합하거나([merge JPG/JPEG](https://products.aspose.app/slides/ko/collage/jpg)), 사진으로 그리드([create grids from photos](https://products.aspose.app/slides/ko/collage/photo-grid))를 만들고 싶을 때 이 서비스를 사용할 수 있습니다. 

{{% /alert %}}

## **이미지를 링크로 추가**

프레젠테이션 파일 크기를 줄이기 위해 파일을 직접 포함하는 대신 링크를 통해 이미지(또는 비디오)를 추가할 수 있습니다. 이 C++ 코드는 플레이스홀더에 이미지와 비디오를 추가하는 방법을 보여줍니다:

```cpp
auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto shapesToRemove = System::MakeObject<System::Collections::Generic::List<System::SharedPtr<IShape>>>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

for (auto& autoShape : shapes)
{
    if (autoShape->get_Placeholder() == nullptr)
        continue;

    switch (autoShape->get_Placeholder()->get_Type())
    {
        case Aspose::Slides::PlaceholderType::Picture:
        {
            auto pictureFrame = shapes->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, autoShape->get_X(), autoShape->get_Y(), autoShape->get_Width(), autoShape->get_Height(), nullptr);
            pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
            shapesToRemove->Add(autoShape);
            break;
        }

        case Aspose::Slides::PlaceholderType::Media:
        {
            auto videoFrame = shapes->AddVideoFrame(autoShape->get_X(), autoShape->get_Y(), autoShape->get_Width(), autoShape->get_Height(), u"");
            videoFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
            videoFrame->set_LinkPathLong(u"https://youtu.be/t_1LYZ102RA");
            shapesToRemove->Add(autoShape);
            break;
        }
    }
}

for (auto& shape : shapesToRemove)
{
    shapes->Remove(shape);
}

presentation->Save(u"output.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **이미지 자르기**

이 C++ 코드는 슬라이드에 있는 기존 이미지를 자르는 방법을 보여줍니다: 

``` CPP
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;
    
auto presentation = System::MakeObject<Presentation>();
// 새 이미지 객체를 생성합니다
auto newImage = presentation->get_Images()->AddImage(Images::FromFile(imagePath));

// 슬라이드에 PictureFrame을 추가합니다
auto picFrame = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 100.0f, 100.0f, 420.0f, 250.0f, newImage);

// 이미지를 자릅니다 (백분율 값)
picFrame->get_PictureFormat()->set_CropLeft(23.6f);
picFrame->get_PictureFormat()->set_CropRight(21.5f);
picFrame->get_PictureFormat()->set_CropTop(3.0f);
picFrame->get_PictureFormat()->set_CropBottom(31.0f);

// 결과를 저장합니다
presentation->Save(outPptxFile, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **그림의 잘린 영역 삭제**

프레임에 포함된 이미지의 잘린 영역을 삭제하려면 [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) 메서드를 사용할 수 있습니다. 이 메서드는 잘린 이미지를 반환하거나, 잘라낼 필요가 없을 경우 원본 이미지를 반환합니다.

이 C++ 코드는 해당 작업을 시연합니다: 

```c++
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"PictureFrameCrop.pptx");
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Gets the PictureFrame from the first slide
System::SharedPtr<IPictureFrame> picFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Deletes cropped areas of the PictureFrame image and returns the cropped image
System::SharedPtr<IPPImage> croppedImage = picFrame->get_PictureFormat()->DeletePictureCroppedAreas();

// Saves the result
presentation->Save(u"PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
```

{{% alert title="NOTE" color="warning" %}} 

[IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) 메서드는 잘린 이미지를 프레젠테이션 이미지 컬렉션에 추가합니다. 해당 이미지가 처리된 [PictureFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/pictureframe/)에만 사용된다면 프레젠테이션 크기를 줄일 수 있습니다. 그렇지 않으면 결과 프레젠테이션에 포함된 이미지 수가 증가합니다.  

이 메서드는 잘라내기 작업 중 WMF/EMF 메타파일을 래스터 PNG 이미지로 변환합니다. 

{{% /alert %}}

## **이미지 압축**

[IPictureFillFormat::CompressImage()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipicturefillformat/compressimage/) 메서드를 사용하여 프레젠테이션의 그림을 압축할 수 있습니다. 이 메서드는 모양 크기와 지정된 해상도를 기준으로 이미지 크기를 줄이며, 옵션으로 잘린 영역을 삭제할 수 있습니다.

PowerPoint의 **Picture Format → Compress Pictures → Resolution** 기능과 동일하게 그림의 크기와 해상도를 조정합니다.

다음 C++ 예제는 목표 해상도를 지정하고 필요에 따라 잘린 영역을 제거하여 프레젠테이션에서 이미지를 압축하는 방법을 보여줍니다:

```c++
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Compress the image with a target resolution of 150 DPI (Web resolution) and remove cropped areas.
bool result = pictureFrame->get_PictureFormat()->CompressImage(true, PicturesCompression::Dpi150);

// Check the result of the compression.
if (result)
{
    System::Console::WriteLine(u"Image successfully compressed.");
}
else
{
    System::Console::WriteLine(u"Image compression failed or no changes were necessary.");
}

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

또는 직접 사용자 지정 DPI 값을 사용합니다:

```c++
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// 이미지를 150 DPI(웹 해상도)로 압축하고, 잘린 영역을 제거합니다.
pictureFrame->get_PictureFormat()->CompressImage(true, 150.0f);

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}}

이 메서드는 모양 크기와 제공된 DPI를 기준으로 이미지를 낮은 해상도로 변환합니다. 파일 크기 최적화를 위해 잘린 영역을 삭제할 수도 있습니다. 이미지가 메타파일(WMF/EMF)이나 SVG인 경우 압축이 적용되지 않습니다. 또한 JPEG 품질은 해상도에 따라 그대로 유지되거나 약간 감소합니다(PowerPoint에서 고해상도 JPEG를 처리하는 방식과 유사). 

{{% /alert %}}

## **가로세로 비율 잠금**

이미지를 포함한 모양의 가로세로 비율을 이미지 크기를 변경한 후에도 유지하려면 [set_AspectRatioLocked()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) 메서드를 사용하여 *Lock Aspect Ratio* 설정을 적용할 수 있습니다. 

이 C++ 코드는 모양의 가로세로 비율을 잠그는 방법을 보여줍니다:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ILayoutSlide> layout = pres->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
System::SharedPtr<ISlide> emptySlide = pres->get_Slides()->AddEmptySlide(layout);

System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
System::SharedPtr<IPPImage> presImage = pres->get_Images()->AddImage(image);

System::SharedPtr<IPictureFrame> pictureFrame = emptySlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 150.0f, static_cast<float>(presImage->get_Width()), static_cast<float>(presImage->get_Height()), presImage);

// 크기 조정 시 가로세로 비율을 유지하도록 모양을 설정합니다
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);
```

{{% alert title="NOTE" color="warning" %}} 

*Lock Aspect Ratio* 설정은 모양 자체의 비율만 유지하고, 모양이 포함하고 있는 이미지의 비율은 유지하지 않습니다. 

{{% /alert %}}

## **StretchOff 속성 사용**

[IPictureFillFormat](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_picture_fill_format) 인터페이스와 [PictureFillFormat](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.picture_fill_format) 클래스의 [StretchOffsetLeft](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.picture_fill_format#ad730bf8db88f47979d84643eb30d1471), [StretchOffsetTop](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.picture_fill_format#aa512e1f022e9c7ff83e9c51ba100709a), [StretchOffsetRight](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.picture_fill_format#ac3597692f9b7e3327d0f4a4169a53127) 및 [StretchOffsetBottom](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.picture_fill_format#a72acf6945f372a5729c0b760f4a5dc39) 속성을 사용하면 채우기 사각형을 지정할 수 있습니다. 

이미지 스트레칭을 지정하면 소스 사각형이 지정된 채우기 사각형에 맞게 확대/축소됩니다. 채우기 사각형의 각 가장자리는 모양 경계 상자의 해당 가장자리에서 백분율 오프셋으로 정의됩니다. 양수 백분율은 내부 오프셋을 의미하고, 음수 백분율은 외부 오프셋을 의미합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation) 클래스의 인스턴스를 생성합니다. 
2. 인덱스를 통해 슬라이드 참조를 가져옵니다. 
3. 사각형 `AutoShape`을 추가합니다. 
4. 이미지를 생성합니다. 
5. 모양의 채우기 유형을 설정합니다. 
6. 모양의 그림 채우기 모드를 설정합니다. 
7. 채우기에 사용할 이미지를 지정합니다. 
8. 모양 경계 상자의 해당 가장자리에서 이미지 오프셋을 지정합니다. 
9. 수정된 프레젠테이션을 PPTX 파일로 저장합니다. 

이 C++ 코드는 StretchOff 속성을 사용하는 과정을 시연합니다:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto ppImage = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
auto slide = pres->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 400.0f, 400.0f, ppImage);

// 모양 본문에서 각 측면으로 이미지를 스트레치하도록 설정합니다
auto pictureFormat = pictureFrame->get_PictureFormat();
pictureFormat->set_PictureFillMode(PictureFillMode::Stretch);
pictureFormat->set_StretchOffsetLeft(24.0f);
pictureFormat->set_StretchOffsetRight(24.0f);
pictureFormat->set_StretchOffsetTop(24.0f);
pictureFormat->set_StretchOffsetBottom(24.0f);

pres->Save(u"imageStretch.pptx", SaveFormat::Pptx);
```

## **FAQ**

**그림 프레임에서 지원되는 이미지 형식은 어떻게 확인하나요?**

Aspose.Slides는 [PictureFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/pictureframe/)에 할당된 이미지 객체를 통해 래스터 이미지(PNG, JPEG, BMP, GIF 등)와 벡터 이미지(예: SVG)를 모두 지원합니다. 지원되는 형식 목록은 슬라이드 및 이미지 변환 엔진 기능과 대부분 겹칩니다.

**수십 개의 대용량 이미지를 추가하면 PPTX 크기와 성능에 어떤 영향을 미치나요?**

대용량 이미지를 직접 포함하면 파일 크기와 메모리 사용량이 증가합니다. 이미지 링크를 사용하면 프레젠테이션 크기를 줄일 수 있지만 외부 파일이 계속 접근 가능해야 합니다. Aspose.Slides는 파일 크기를 줄이기 위해 링크로 이미지를 추가하는 기능을 제공합니다.

**이미지 개체를 실수로 이동하거나 크기 조정되지 않도록 잠그려면 어떻게 해야 하나요?**

[PictureFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/pictureframe/)에 대해 [shape locks](https://reference.aspose.com/slides/ko/cpp/aspose.slides/pictureframe/get_pictureframelock/)를 사용하십시오(예: 이동 또는 크기 조정 비활성화). 잠금 메커니즘은 별도의 [보호 기사](/slides/ko/cpp/applying-protection-to-presentation/)에 설명되어 있으며, 다양한 shape 유형에 대해 지원됩니다.

**SVG 벡터 품질이 PDF/이미지로 내보낼 때 유지되나요?**

Aspose.Slides는 [PictureFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/pictureframe/)에서 SVG를 원본 벡터 형태로 추출할 수 있습니다. PDF([exporting to PDF](/slides/ko/cpp/convert-powerpoint-to-pdf/)) 또는 래스터 형식([exporting to PNG](/slides/ko/cpp/convert-powerpoint-to-png/))으로 내보낼 때는 내보내기 설정에 따라 래스터화될 수 있으며, 추출 동작을 통해 원본 SVG가 벡터로 저장된다는 점이 확인됩니다.