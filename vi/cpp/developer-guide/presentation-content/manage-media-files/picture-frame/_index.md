---
title: Quản lý khung hình trong bản trình chiếu bằng C++
linktitle: Khung Hình
type: docs
weight: 10
url: /vi/cpp/picture-frame/
keywords:
- khung hình
- thêm khung hình
- tạo khung hình
- thêm hình ảnh
- tạo hình ảnh
- trích xuất hình ảnh
- hình ảnh raster
- hình ảnh vector
- cắt hình ảnh
- vùng đã cắt
- thuộc tính StretchOff
- định dạng khung hình
- thuộc tính khung hình
- tỷ lệ tương đối
- hiệu ứng hình ảnh
- tỷ lệ khung hình
- độ trong suốt hình ảnh
- PowerPoint
- OpenDocument
- bản trình chiếu
- C++
- Aspose.Slides
description: "Thêm khung hình vào các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho C++. Tối ưu quy trình làm việc và nâng cao thiết kế slide."
---
## **Giới thiệu**

Khung hình là một hình dạng chứa một hình ảnh—nó giống như một bức tranh trong khung.

Bạn có thể thêm một hình ảnh vào slide thông qua khung hình. Nhờ vậy, bạn có thể định dạng hình ảnh bằng cách định dạng khung hình.

{{% alert title="Mẹo" color="info" %}} 
Aspose cung cấp các bộ chuyển đổi miễn phí—[JPEG to PowerPoint](https://products.aspose.app/slides/vi/import/jpg-to-ppt) và [PNG to PowerPoint](https://products.aspose.app/slides/vi/import/png-to-ppt)—giúp người dùng tạo bản trình chiếu nhanh chóng từ hình ảnh. 
{{% /alert %}} 

## **Tạo Khung Hình Ảnh**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation).
2. Lấy tham chiếu đến một slide theo chỉ mục của nó. 
3. Tạo một đối tượng [IPPImage](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_p_p_image) bằng cách thêm một hình ảnh vào [IImagesCollection](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_image_collection) được liên kết với đối tượng presentation sẽ được dùng để lấp đầy hình dạng.
4. Xác định chiều rộng và chiều cao của hình ảnh.
5. Tạo một [PictureFrame](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.picture_frame) dựa trên chiều rộng và chiều cao của hình ảnh thông qua phương thức `AddPictureFrame` được cung cấp bởi đối tượng shape liên kết với slide đã tham chiếu.
6. Thêm khung hình (chứa hình ảnh) vào slide.
7. Ghi bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Mã C++ này cho bạn thấy cách tạo một khung hình:

```c++
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
#include <Util/Images.h>
#include <drawing/color.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Đường dẫn tới thư mục tài liệu.
const String outPath = u"../out/PictureFrameFormatting_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Tải bản trình chiếu mong muốn
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Truy cập slide đầu tiên
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Tải hình ảnh sẽ được thêm vào bộ sưu tập hình ảnh của bản trình chiếu
// Lấy hình ảnh
auto image = Images::FromFile(filePath);

// Thêm một hình ảnh vào bộ sưu tập hình ảnh của bản trình chiếu
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Thêm khung hình vào slide
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Đặt tỷ lệ tương đối cho chiều rộng và chiều cao
pf->set_RelativeScaleHeight(0.8);
pf->set_RelativeScaleWidth(1.35);
// Áp dụng một số định dạng cho PictureFrame
pf->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pf->get_LineFormat()->set_Width ( 20);
pf->set_Rotation( 45);

//Ghi tệp PPTX ra đĩa
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert color="warning" %}} 
Khung hình cho phép bạn nhanh chóng tạo các slide trình chiếu dựa trên hình ảnh. Khi bạn kết hợp khung hình với các tùy chọn lưu của Aspose.Slides, bạn có thể thao tác các thao tác nhập/xuất để chuyển đổi hình ảnh từ định dạng này sang định dạng khác. Bạn có thể tham khảo các trang này: chuyển đổi [image to JPG](https://products.aspose.com/slides/vi/cpp/conversion/image-to-jpg/); chuyển đổi [JPG to image](https://products.aspose.com/slides/vi/cpp/conversion/jpg-to-image/); chuyển đổi [JPG to PNG](https://products.aspose.com/slides/vi/cpp/conversion/jpg-to-png/), chuyển đổi [PNG to JPG](https://products.aspose.com/slides/vi/cpp/conversion/png-to-jpg/); chuyển đổi [PNG to SVG](https://products.aspose.com/slides/vi/cpp/conversion/png-to-svg/), chuyển đổi [SVG to PNG](https://products.aspose.com/slides/vi/cpp/conversion/svg-to-png/). 
{{% /alert %}}

## **Tạo Khung Hình Ảnh với Tỷ Lệ Tương Đối**

Bằng cách thay đổi tỷ lệ tương đối của hình ảnh, bạn có thể tạo một khung hình phức tạp hơn. 

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation).
2. Lấy tham chiếu đến một slide theo chỉ mục của nó. 
3. Thêm một hình ảnh vào bộ sưu tập hình ảnh của presentation.
4. Tạo một đối tượng [IPPImage](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_p_p_image) bằng cách thêm một hình ảnh vào [IImagesCollection](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_image_collection) được liên kết với đối tượng presentation sẽ được dùng để lấp đầy hình dạng.
5. Xác định chiều rộng và chiều cao tương đối của hình ảnh trong khung hình.
6. Ghi bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Mã C++ này cho bạn thấy cách tạo một khung hình với tỷ lệ tương đối:

```c++
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <Util/Images.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Đường dẫn tới thư mục tài liệu.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Tải bản trình chiếu mong muốn
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Truy cập slide đầu tiên
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Tải hình ảnh sẽ được thêm vào bộ sưu tập hình ảnh của bản trình chiếu
// Lấy hình ảnh
auto image = Images::FromFile(filePath);

// Thêm một hình ảnh vào bộ sưu tập hình ảnh của bản trình chiếu
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Thêm khung hình vào slide
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Đặt tỷ lệ tương đối cho chiều rộng và chiều cao
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

//Ghi tệp PPTX ra đĩa
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Trích Xuất Hình Ảnh Raster Từ Khung Hình**

Bạn có thể trích xuất các hình ảnh raster từ các đối tượng [PictureFrame](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.picture_frame) và lưu chúng dưới dạng PNG, JPG và các định dạng khác. Ví dụ mã dưới đây minh họa cách trích xuất một hình ảnh từ tài liệu “sample.pptx” và lưu nó ở định dạng PNG.

```c++
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstSlide = presentation->get_Slide(0);
auto firstShape = firstSlide->get_Shape(0);

if (ObjectExt::Is<IPictureFrame>(firstShape))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(firstShape);
    auto image = pictureFrame->get_PictureFormat()->get_Picture()->get_Image()->get_Image();

    image->Save(u"slide_1_shape_1.png", ImageFormat::Png);
}

presentation->Dispose();
```

## **Trích Xuất Hình Ảnh SVG Từ Khung Hình**

Khi một bản trình chiếu chứa đồ họa SVG được đặt bên trong các hình dạng [PictureFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/pictureframe/), Aspose.Slides cho C++ cho phép bạn lấy lại các hình ảnh vector gốc với độ trung thực đầy đủ. Bằng cách duyệt qua bộ sưu tập hình dạng của slide, bạn có thể xác định từng [PictureFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/pictureframe/), kiểm tra xem [IPPImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ippimage/) nền có chứa nội dung SVG hay không, và sau đó lưu hình ảnh đó vào đĩa hoặc luồng dưới dạng SVG nguyên bản.

Mã ví dụ sau cho bạn thấy cách trích xuất một hình ảnh SVG từ một khung hình:

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
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

## **Lấy Độ Trong Suốt Của Hình Ảnh**

Aspose.Slides cho phép bạn lấy hiệu ứng trong suốt được áp dụng cho một hình ảnh. Mã C++ sau minh họa thao tác này:

```c++
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;

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

{{% alert color="info" %}} 
Tất cả các hiệu ứng được áp dụng cho hình ảnh có thể được tìm thấy trong [Aspose::Slides::Effects](https://reference.aspose.com/slides/vi/cpp/aspose.slides.effects/). 
{{% /alert %}}

## **Lấy Độ Sáng và Độ Tương Phản Của Hình Ảnh**

Aspose.Slides cho phép bạn lấy hiệu ứng độ sáng và độ tương phản được áp dụng cho một hình ảnh. Giao diện [ILuminance](https://reference.aspose.com/slides/vi/cpp/aspose.slides.effects/iluminance/) đại diện cho hiệu ứng chuyển đổi này.

Mã C++ sau cho bạn thấy cách lấy cài đặt độ sáng và độ tương phản từ một khung hình:

```c++
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ILuminance.h>
#include <DOM/Effects/ILuminanceEffectiveData.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shape(0);
auto pictureFrame = System::ExplicitCast<IPictureFrame>(shape);

auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
for (auto&& effect : imageTransform)
{
    if (System::ObjectExt::Is<ILuminance>(effect))
    {
        auto luminance = System::ExplicitCast<ILuminance>(effect)->GetEffective();
        auto brightness = luminance->get_Brightness();
        auto contrast = luminance->get_Contrast();

        Console::WriteLine(System::String(u"Brightness: ") + brightness);
        Console::WriteLine(System::String(u"Contrast: ") + contrast);
    }
}

presentation->Dispose();
```

## **Định Dạng Khung Hình**

Aspose.Slides cung cấp nhiều tùy chọn định dạng có thể áp dụng cho một khung hình. Nhờ các tùy chọn này, bạn có thể điều chỉnh khung hình để đáp ứng các yêu cầu cụ thể.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation).
2. Lấy tham chiếu đến một slide theo chỉ mục của nó. 
3. Tạo một đối tượng [IPPImage](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_p_p_image) bằng cách thêm một hình ảnh vào [IImagesCollection](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_image_collection) được liên kết với đối tượng presentation sẽ được dùng để lấp đầy hình dạng.
4. Xác định chiều rộng và chiều cao của hình ảnh.
5. Tạo một `PictureFrame` dựa trên chiều rộng và chiều cao của hình ảnh thông qua phương thức [AddPictureFrame](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) được cung cấp bởi đối tượng [IShapes](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_shape_collection) liên kết với slide đã tham chiếu.
6. Thêm khung hình (chứa hình ảnh) vào slide.
7. Đặt màu đường viền của khung hình.
8. Đặt độ rộng đường viền của khung hình.
9. Xoay khung hình bằng cách cung cấp một giá trị dương hoặc âm. 
   * Giá trị dương xoay hình theo chiều kim đồng hồ. 
   * Giá trị âm xoay hình ngược chiều kim đồng hồ.
10. Thêm khung hình (chứa hình ảnh) vào slide.
11. Ghi bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Mã C++ này minh họa quy trình định dạng khung hình:

```c++
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <Util/Images.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Đường dẫn tới thư mục tài liệu.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Tải bản trình chiếu mong muốn
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Truy cập slide đầu tiên
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Tải hình ảnh sẽ được thêm vào bộ sưu tập hình ảnh của bản trình chiếu
// Lấy hình ảnh
auto image = Images::FromFile(filePath);

// Thêm một hình ảnh vào bộ sưu tập hình ảnh của bản trình chiếu
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Thêm khung hình vào slide
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Đặt tỷ lệ tương đối cho chiều rộng và chiều cao
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

//Ghi tệp PPTX ra đĩa
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert title="Mẹo" color="info" %}} 
Aspose gần đây đã phát triển một công cụ [Collage Maker](https://products.aspose.app/slides/vi/collage) miễn phí. Nếu bạn cần [gộp JPG/JPEG](https://products.aspose.app/slides/vi/collage/jpg) hoặc PNG, hoặc [tạo lưới từ ảnh](https://products.aspose.app/slides/vi/collage/photo-grid), bạn có thể sử dụng dịch vụ này. 
{{% /alert %}}

## **Thêm Hình Ảnh Dưới Dạng Liên Kết**

Để tránh làm tăng kích thước bản trình chiếu, bạn có thể thêm hình ảnh (hoặc video) qua các liên kết thay vì nhúng tệp trực tiếp vào bản trình chiếu. Mã C++ này cho bạn thấy cách thêm hình ảnh và video vào một placeholder:

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/IVideoFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/collections/list.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

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

## **Cắt Hình Ảnh**

Mã C++ này cho bạn thấy cách cắt một hình ảnh hiện có trên slide: 

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <Util/Images.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
// Tạo đối tượng hình ảnh mới
auto newImage = presentation->get_Images()->AddImage(Images::FromFile(u"image.png"));

// Thêm một PictureFrame vào Slide
auto picFrame = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 100.0f, 100.0f, 420.0f, 250.0f, newImage);

// Cắt ảnh (giá trị phần trăm)
picFrame->get_PictureFormat()->set_CropLeft(23.6f);
picFrame->get_PictureFormat()->set_CropRight(21.5f);
picFrame->get_PictureFormat()->set_CropTop(3.0f);
picFrame->get_PictureFormat()->set_CropBottom(31.0f);

// Lưu kết quả
presentation->Save(u"cropped.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Xóa Các Vùng Đã Cắt Của Hình**

Nếu bạn muốn xóa các khu vực đã cắt của hình ảnh nằm trong một khung, bạn có thể sử dụng phương thức [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/). Phương thức này trả về hình ảnh đã cắt hoặc hình ảnh gốc nếu không cần cắt.

Mã C++ này minh họa thao tác:

```c++
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"PictureFrameCrop.pptx");
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Lấy PictureFrame từ slide đầu tiên
System::SharedPtr<IPictureFrame> picFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Xóa các vùng đã cắt của hình ảnh PictureFrame và trả về hình ảnh đã cắt
System::SharedPtr<IPPImage> croppedImage = picFrame->get_PictureFormat()->DeletePictureCroppedAreas();

// Lưu kết quả
presentation->Save(u"PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
```

{{% alert title="LƯU Ý" color="warning" %}} 
Phương thức [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) sẽ thêm hình ảnh đã cắt vào bộ sưu tập hình ảnh của presentation. Nếu hình ảnh chỉ được sử dụng trong [PictureFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/pictureframe/) đã xử lý, cấu hình này có thể giảm kích thước bản trình chiếu. Ngược lại, số lượng hình ảnh trong bản trình chiếu kết quả sẽ tăng.

Phương thức này chuyển đổi các metafile WMF/EMF sang hình ảnh raster PNG trong quá trình cắt. 
{{% /alert %}}

## **Nén Hình Ảnh**

Bạn có thể nén một hình ảnh trong bản trình chiếu bằng phương thức [IPictureFillFormat::CompressImage()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipicturefillformat/compressimage/). 
Phương thức này nén hình ảnh bằng cách giảm kích thước dựa trên kích thước hình dạng và độ phân giải được chỉ định, với tùy chọn xóa các vùng đã cắt.

Nó điều chỉnh kích thước và độ phân giải của hình ảnh tương tự như tính năng **Picture Format → Compress Pictures → Resolution** của PowerPoint.

Các ví dụ C++ sau trình bày cách nén hình ảnh trong một bản trình chiếu bằng cách chỉ định độ phân giải mục tiêu và tùy chọn xóa các vùng đã cắt:

```c++
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Nén hình ảnh với độ phân giải mục tiêu 150 DPI (độ phân giải web) và xóa các vùng đã cắt.
bool result = pictureFrame->get_PictureFormat()->CompressImage(true, PicturesCompression::Dpi150);

// Kiểm tra kết quả của quá trình nén.
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

Hoặc sử dụng một giá trị DPI tùy chỉnh trực tiếp:

```c++
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Nén hình ảnh thành 150 DPI (độ phân giải web), xóa các vùng đã cắt.
pictureFrame->get_PictureFormat()->CompressImage(true, 150.0f);

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="LƯU Ý" color="warning" %}} 
Phương thức sẽ chuyển đổi hình ảnh sang độ phân giải thấp hơn dựa trên kích thước hình dạng và DPI được cung cấp. Các khu vực đã cắt cũng có thể bị xóa để tối ưu kích thước tệp. 
Nếu hình ảnh là một metafile (WMF/EMF) hoặc SVG, việc nén sẽ không được áp dụng. Ngoài ra, chất lượng JPEG được giữ nguyên hoặc giảm nhẹ dựa trên độ phân giải, giống như cách PowerPoint xử lý JPEG độ phân giải cao. 
{{% /alert %}}

## **Khóa Tỷ Lệ Khung Hình**

Nếu bạn muốn một hình dạng chứa hình ảnh giữ nguyên tỷ lệ khung ngay cả khi thay đổi kích thước hình ảnh, bạn có thể sử dụng phương thức [set_AspectRatioLocked()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) để bật cài đặt *Lock Aspect Ratio*. 

Mã C++ này cho bạn thấy cách khóa tỷ lệ khung hình:

```c++
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ILayoutSlide> layout = pres->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
System::SharedPtr<ISlide> emptySlide = pres->get_Slides()->AddEmptySlide(layout);

System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
System::SharedPtr<IPPImage> presImage = pres->get_Images()->AddImage(image);

System::SharedPtr<IPictureFrame> pictureFrame = emptySlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 150.0f, static_cast<float>(presImage->get_Width()), static_cast<float>(presImage->get_Height()), presImage);

// đặt hình dạng để duy trì tỷ lệ khung khi thay đổi kích thước
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);
```

{{% alert title="LƯU Ý" color="warning" %}} 
Cài đặt *Lock Aspect Ratio* này chỉ bảo toàn tỷ lệ của hình dạng chứ không phải của hình ảnh bên trong. 
{{% /alert %}}

## **Sử Dụng Thuộc Tính StretchOff**

Bằng cách sử dụng các thuộc tính [StretchOffsetLeft](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.picture_fill_format#ad730bf8db88f47979d84643eb30d1471), [StretchOffsetTop](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.picture_fill_format#aa512e1f022e9c7ff83e9c51ba100709a), [StretchOffsetRight](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.picture_fill_format#ac3597692f9b7e3327d0f4a4169a53127) và [StretchOffsetBottom](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.picture_fill_format#a72acf6945f372a5729c0b760f4a5dc39) từ giao diện [IPictureFillFormat](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_picture_fill_format) và lớp [PictureFillFormat](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.picture_fill_format), bạn có thể chỉ định một hình chữ nhật lấp đầy. 

Khi chỉ định việc kéo giãn của một hình ảnh, một hình chữ nhật nguồn sẽ được co dãn để vừa với hình chữ nhật lấp đầy đã chỉ định. Mỗi cạnh của hình chữ nhật lấp đầy được định nghĩa bằng một phần trăm lệch so với cạnh tương ứng của hộp bao quanh của hình dạng. Phần trăm dương chỉ ra một chèn vào. Phần trăm âm chỉ ra một mở rộng ra.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation).
2. Lấy tham chiếu đến một slide theo chỉ mục của nó.
3. Thêm một hình chữ nhật `AutoShape`. 
4. Tạo một hình ảnh.
5. Đặt loại lấp đầy cho hình dạng.
6. Đặt chế độ lấp đầy hình ảnh cho hình dạng.
7. Thêm một hình ảnh đã đặt để lấp đầy hình dạng.
8. Xác định độ lệch hình ảnh từ cạnh tương ứng của hộp bao quanh hình dạng.
9. Ghi bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Mã C++ này minh họa quy trình sử dụng thuộc tính StretchOff:

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <Util/Images.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
auto ppImage = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
auto slide = pres->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 400.0f, 400.0f, ppImage);

// Sets the image stretched from each side in the shape body
auto pictureFormat = pictureFrame->get_PictureFormat();
pictureFormat->set_PictureFillMode(PictureFillMode::Stretch);
pictureFormat->set_StretchOffsetLeft(24.0f);
pictureFormat->set_StretchOffsetRight(24.0f);
pictureFormat->set_StretchOffsetTop(24.0f);
pictureFormat->set_StretchOffsetBottom(24.0f);

pres->Save(u"imageStretch.pptx", SaveFormat::Pptx);
```

## **FAQ**

### Làm thế nào để biết các định dạng hình ảnh nào được hỗ trợ cho PictureFrame?

Aspose.Slides hỗ trợ cả hình ảnh raster (PNG, JPEG, BMP, GIF, v.v.) và hình ảnh vector (ví dụ, SVG) thông qua đối tượng hình ảnh được gán cho một [PictureFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/pictureframe/). Danh sách các định dạng được hỗ trợ thường trùng khớp với khả năng của công cụ chuyển đổi slide và hình ảnh.

### Việc thêm hàng chục hình ảnh lớn sẽ ảnh hưởng như thế nào đến kích thước và hiệu suất của PPTX?

Nhúng hình ảnh lớn làm tăng kích thước tệp và sử dụng bộ nhớ; liên kết hình ảnh giúp giữ kích thước bản trình chiếu nhỏ hơn nhưng yêu cầu các tệp ngoại vi phải luôn có sẵn. Aspose.Slides cung cấp khả năng thêm hình ảnh bằng liên kết để giảm kích thước tệp.

### Làm sao để khóa một đối tượng hình ảnh tránh việc di chuyển/đổi kích thước ngoài ý muốn?

Sử dụng [khóa hình dạng](https://reference.aspose.com/slides/vi/cpp/aspose.slides/pictureframe/get_pictureframelock/) cho một [PictureFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/pictureframe/) (ví dụ, vô hiệu hoá việc di chuyển hoặc thay đổi kích thước). Cơ chế khóa được mô tả cho các hình dạng trong một [bài viết về bảo vệ](/slides/vi/cpp/applying-protection-to-presentation/) và được hỗ trợ cho nhiều loại hình dạng, bao gồm [PictureFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/pictureframe/).

### Độ trung thực vector SVG có được bảo lưu khi xuất bản trình chiếu ra PDF/hình ảnh không?

Aspose.Slides cho phép trích xuất một SVG từ một [PictureFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/pictureframe/) như là vector gốc. Khi [xuất ra PDF](/slides/vi/cpp/convert-powerpoint-to-pdf/) hoặc [định dạng raster](/slides/vi/cpp/convert-powerpoint-to-png/), kết quả có thể được raster hoá tùy thuộc vào cài đặt xuất; việc SVG gốc được lưu dưới dạng vector được xác nhận bằng hành vi trích xuất.