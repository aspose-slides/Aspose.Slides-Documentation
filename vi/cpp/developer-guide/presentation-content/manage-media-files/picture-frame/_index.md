---
title: "Quản lý Khung Hình trong Bản Trình Bày bằng C++"
linktitle: "Khung Hình"
type: docs
weight: 10
url: /vi/cpp/picture-frame/
keywords:
- "khung hình"
- "thêm khung hình"
- "tạo khung hình"
- "thêm hình ảnh"
- "tạo hình ảnh"
- "trích xuất hình ảnh"
- "hình ảnh raster"
- "hình ảnh vector"
- "cắt hình ảnh"
- "vùng đã cắt"
- "thuộc tính StretchOff"
- "định dạng khung hình"
- "thuộc tính khung hình"
- "tỷ lệ tương đối"
- "hiệu ứng hình ảnh"
- "tỷ lệ khung"
- "độ trong suốt hình ảnh"
- "PowerPoint"
- "OpenDocument"
- "bản trình bày"
- "C++"
- "Aspose.Slides"
description: "Thêm khung hình vào các bản trình bày PowerPoint và OpenDocument với Aspose.Slides cho C++. Tinh giản quy trình làm việc và nâng cao thiết kế slide."
---
## **Giới thiệu**

Khung hình là một hình dạng chứa hình ảnh — giống như một bức tranh trong khung.

Bạn có thể thêm hình ảnh vào một slide thông qua khung hình. Bằng cách này, bạn có thể định dạng hình ảnh bằng cách định dạng khung hình.

{{% alert  title="Mẹo" color="primary" %}} 
Aspose cung cấp các bộ chuyển đổi miễn phí — [JPEG sang PowerPoint](https://products.aspose.app/slides/vi/import/jpg-to-ppt) và [PNG sang PowerPoint](https://products.aspose.app/slides/vi/import/png-to-ppt) — cho phép người dùng tạo bản trình bày nhanh chóng từ hình ảnh. 
{{% /alert %}} 

## **Tạo Khung Hình**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation).
2. Lấy tham chiếu của slide thông qua chỉ mục của nó. 
3. Tạo một đối tượng [IPPImage](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_p_p_image) bằng cách thêm hình ảnh vào [IImagescollection](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_image_collection) liên kết với đối tượng presentation sẽ được dùng để lấp đầy hình dạng.
4. Xác định chiều rộng và chiều cao của hình ảnh.
5. Tạo một [PictureFrame](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.picture_frame) dựa trên chiều rộng và chiều cao của hình ảnh thông qua phương thức `AddPictureFrame` được cung cấp bởi đối tượng shape liên kết với slide đã tham chiếu.
6. Thêm khung hình (chứa hình ảnh) vào slide.
7. Ghi bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

Mã C++ dưới đây cho bạn thấy cách tạo một khung hình:

```c++
// Đường dẫn đến thư mục tài liệu.
const String outPath = u"../out/PictureFrameFormatting_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Tải bản trình bày mong muốn
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Truy cập slide đầu tiên
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Tải hình ảnh sẽ được thêm vào bộ sưu tập hình ảnh của bản trình bày
// Lấy ảnh
auto image = Images::FromFile(filePath);

// Thêm một hình ảnh vào bộ sưu tập hình ảnh của bản trình bày
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Thêm một khung hình vào slide
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Đặt tỷ lệ chiều rộng và chiều cao tương đối
pf->set_RelativeScaleHeight(0.8);
pf->set_RelativeScaleWidth(1.35);
// Áp dụng một số định dạng cho PictureFrame
pf->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pf->get_LineFormat()->set_Width ( 20);
pf->set_Rotation( 45);

// Ghi tệp PPTX ra đĩa
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert color="warning" %}} 
Khung hình cho phép bạn nhanh chóng tạo các slide trình chiếu dựa trên hình ảnh. Khi kết hợp khung hình với các tùy chọn lưu của Aspose.Slides, bạn có thể thao tác các hoạt động nhập/xuất để chuyển đổi hình ảnh từ định dạng này sang định dạng khác. Bạn có thể tham khảo các trang sau: chuyển đổi [image to JPG](https://products.aspose.com/slides/vi/cpp/conversion/image-to-jpg/); chuyển đổi [JPG to image](https://products.aspose.com/slides/vi/cpp/conversion/jpg-to-image/); chuyển đổi [JPG to PNG](https://products.aspose.com/slides/vi/cpp/conversion/jpg-to-png/), chuyển đổi [PNG to JPG](https://products.aspose.com/slides/vi/cpp/conversion/png-to-jpg/); chuyển đổi [PNG to SVG](https://products.aspose.com/slides/vi/cpp/conversion/png-to-svg/), chuyển đổi [SVG to PNG](https://products.aspose.com/slides/vi/cpp/conversion/svg-to-png/). 
{{% /alert %}}

## **Tạo Khung Hình với Tỷ Lệ Tương Đối**

Bằng cách thay đổi tỷ lệ tương đối của hình ảnh, bạn có thể tạo một khung hình phức tạp hơn. 

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation).
2. Lấy tham chiếu của slide thông qua chỉ mục của nó. 
3. Thêm một hình ảnh vào bộ sưu tập hình ảnh của presentation.
4. Tạo một đối tượng [IPPImage](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_p_p_image) bằng cách thêm hình ảnh vào [IImagescollection](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_image_collection) liên kết với đối tượng presentation sẽ được dùng để lấp đầy hình dạng.
5. Xác định chiều rộng và chiều cao tương đối của hình ảnh trong khung hình.
6. Ghi bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

Mã C++ dưới đây cho bạn thấy cách tạo một khung hình với tỷ lệ tương đối:

```c++
// Đường dẫn đến thư mục tài liệu.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Tải bản trình bày mong muốn
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Truy cập slide đầu tiên
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Tải hình ảnh sẽ được thêm vào bộ sưu tập hình ảnh của bản trình bày
// Lấy ảnh
auto image = Images::FromFile(filePath);

// Thêm một hình ảnh vào bộ sưu tập hình ảnh của bản trình bày
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Thêm một khung hình vào slide
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Đặt tỷ lệ chiều rộng và chiều cao tương đối
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

// Ghi tệp PPTX ra đĩa
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Trích Xuất Hình Ảnh Raster từ Khung Hình**

Bạn có thể trích xuất các hình ảnh raster từ các đối tượng [PictureFrame](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.picture_frame) và lưu chúng dưới dạng PNG, JPG và các định dạng khác. Ví dụ mã dưới đây minh họa cách trích xuất một hình ảnh từ tài liệu “sample.pptx” và lưu nó ở định dạng PNG.

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

## **Trích Xuất Hình Ảnh SVG từ Khung Hình**

Khi một bản trình bày chứa đồ họa SVG được đặt bên trong các hình dạng [PictureFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/pictureframe/), Aspose.Slides cho C++ cho phép bạn lấy lại các hình ảnh vector gốc với độ chính xác đầy đủ. Bằng cách duyệt qua bộ sưu tập hình dạng của slide, bạn có thể xác định từng [PictureFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/pictureframe/), kiểm tra xem [IPPImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ippimage/) nền có chứa nội dung SVG hay không, sau đó lưu hình ảnh đó vào đĩa hoặc luồng dưới dạng SVG gốc.

Mã C++ dưới đây minh họa cách trích xuất một hình ảnh SVG từ một khung hình:

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

## **Lấy Độ Trong Suốt của Hình Ảnh**

Aspose.Slides cho phép bạn lấy hiệu ứng trong suốt được áp dụng cho hình ảnh. Mã C++ dưới đây trình bày thao tác này:

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

{{% alert title="LƯU Ý" color="primary" %}} 
Tất cả các hiệu ứng áp dụng cho hình ảnh có thể được tìm thấy trong [Aspose::Slides::Effects](https://reference.aspose.com/slides/vi/cpp/aspose.slides.effects/). 
{{% /alert %}}

## **Định Dạng Khung Hình**

Aspose.Slides cung cấp nhiều tùy chọn định dạng có thể áp dụng cho một khung hình. Sử dụng các tùy chọn này, bạn có thể điều chỉnh khung hình để đáp ứng các yêu cầu cụ thể.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation).
2. Lấy tham chiếu của slide thông qua chỉ mục của nó. 
3. Tạo một đối tượng [IPPImage](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_p_p_image) bằng cách thêm hình ảnh vào [IImagescollection](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_image_collection) liên kết với đối tượng presentation sẽ được dùng để lấp đầy hình dạng.
4. Xác định chiều rộng và chiều cao của hình ảnh.
5. Tạo một `PictureFrame` dựa trên chiều rộng và chiều cao của hình ảnh thông qua phương thức [AddPictureFrame](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) được cung cấp bởi đối tượng [IShapes](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_shape_collection) liên kết với slide đã tham chiếu.
6. Thêm khung hình (chứa hình ảnh) vào slide.
7. Đặt màu đường viền cho khung hình.
8. Đặt độ dày đường viền cho khung hình.
9. Xoay khung hình bằng cách cung cấp giá trị dương hoặc âm.
   * Giá trị dương xoay hình theo chiều kim đồng hồ. 
   * Giá trị âm xoay hình ngược chiều kim đồng hồ.
10. Thêm khung hình (chứa hình ảnh) vào slide.
11. Ghi bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

Mã C++ dưới đây minh họa quy trình định dạng khung hình:

```c++
// Đường dẫn tới thư mục tài liệu.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Tải bản trình bày mong muốn
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Truy cập slide đầu tiên
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Tải hình ảnh sẽ được thêm vào bộ sưu tập hình ảnh của bản trình bày
// Lấy ảnh
auto image = Images::FromFile(filePath);

// Thêm một hình ảnh vào bộ sưu tập hình ảnh của bản trình bày
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Thêm một khung hình vào slide
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Đặt tỷ lệ chiều rộng và chiều cao tương đối
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

// Ghi tệp PPTX ra đĩa
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert title="Mẹo" color="primary" %}}
Aspose gần đây đã phát triển một công cụ [Collage Maker miễn phí](https://products.aspose.app/slides/vi/collage). Nếu bạn cần [gộp JPG/JPEG](https://products.aspose.app/slides/vi/collage/jpg) hoặc PNG, [tạo lưới ảnh](https://products.aspose.app/slides/vi/collage/photo-grid), bạn có thể sử dụng dịch vụ này. 
{{% /alert %}}

## **Thêm Hình Ảnh dưới Dạng Liên Kết**

Để tránh kích thước bản trình bày quá lớn, bạn có thể thêm hình ảnh (hoặc video) thông qua liên kết thay vì nhúng tệp trực tiếp vào bản trình bày. Mã C++ dưới đây cho bạn thấy cách thêm một hình ảnh và video vào một placeholder:

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

## **Cắt Hình Ảnh**

Mã C++ dưới đây cho bạn thấy cách cắt một hình ảnh hiện có trên slide:

``` CPP
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;
    
auto presentation = System::MakeObject<Presentation>();
// Tạo đối tượng ảnh mới
auto newImage = presentation->get_Images()->AddImage(Images::FromFile(imagePath));

// Thêm một PictureFrame vào Slide
auto picFrame = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 100.0f, 100.0f, 420.0f, 250.0f, newImage);

// Cắt ảnh (giá trị phần trăm)
picFrame->get_PictureFormat()->set_CropLeft(23.6f);
picFrame->get_PictureFormat()->set_CropRight(21.5f);
picFrame->get_PictureFormat()->set_CropTop(3.0f);
picFrame->get_PictureFormat()->set_CropBottom(31.0f);

// Lưu kết quả
presentation->Save(outPptxFile, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Xóa Các Vùng Đã Cắt của Hình Ảnh**

Nếu bạn muốn xóa các vùng đã cắt của một hình ảnh chứa trong khung, bạn có thể sử dụng phương thức [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/). Phương thức này trả về hình ảnh đã cắt hoặc hình ảnh gốc nếu việc cắt không cần thiết.

Mã C++ dưới đây minh họa thao tác này:

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

{{% alert title="LƯU Ý" color="warning" %}} 
Phương thức [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) sẽ thêm hình ảnh đã cắt vào bộ sưu tập hình ảnh của presentation. Nếu hình ảnh chỉ được sử dụng trong [PictureFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/pictureframe/) đã xử lý, thiết lập này có thể giảm kích thước bản trình bày. Ngược lại, số lượng hình ảnh trong bản trình bày kết quả sẽ tăng.

Phương thức này chuyển đổi các tệp metafile WMF/EMF thành hình ảnh PNG raster trong quá trình cắt. 
{{% /alert %}}

## **Nén Hình Ảnh**

Bạn có thể nén một hình ảnh trong bản trình bày bằng phương thức [IPictureFillFormat::CompressImage()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipicturefillformat/compressimage/). Phương thức này nén hình ảnh bằng cách giảm kích thước dựa trên kích thước hình dạng và độ phân giải đã chỉ định, với tùy chọn xóa các vùng đã cắt.

Nó điều chỉnh kích thước và độ phân giải của hình ảnh tương tự như tính năng **Picture Format → Compress Pictures → Resolution** của PowerPoint.

Các ví dụ C++ sau đây minh họa cách nén một hình ảnh trong bản trình bày bằng cách chỉ định độ phân giải mục tiêu và tùy chọn xóa các vùng đã cắt:

```c++
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Nén hình ảnh với độ phân giải mục tiêu 150 DPI (độ phân giải web) và loại bỏ các khu vực đã cắt.
bool result = pictureFrame->get_PictureFormat()->CompressImage(true, PicturesCompression::Dpi150);

// Kiểm tra kết quả của việc nén.
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

Hoặc sử dụng giá trị DPI tùy chỉnh trực tiếp:

```c++
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Nén hình ảnh tới 150 DPI (độ phân giải web), loại bỏ các vùng đã cắt.
pictureFrame->get_PictureFormat()->CompressImage(true, 150.0f);

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="LƯU Ý" color="warning" %}} 
Phương thức này chuyển đổi hình ảnh thành độ phân giải thấp hơn dựa trên kích thước hình dạng và DPI được cung cấp. Các vùng đã cắt cũng có thể bị xóa để tối ưu kích thước tệp. Nếu hình ảnh là metafile (WMF/EMF) hoặc SVG, việc nén sẽ không được áp dụng. Ngoài ra, chất lượng JPEG được giữ nguyên hoặc giảm nhẹ tùy thuộc vào độ phân giải, tương tự như cách PowerPoint xử lý JPEG có độ phân giải cao. 
{{% /alert %}}

## **Khóa Tỷ Lệ Khung Hình**

Nếu bạn muốn một hình dạng chứa hình ảnh giữ nguyên tỷ lệ khung ngay cả khi thay đổi kích thước ảnh, bạn có thể sử dụng phương thức [set_AspectRatioLocked()](https://reference.aspose.com/slides/vi/cpp/aspose.slides.ipictureframelock/set_aspectratiolocked/) để thiết lập tùy chọn *Lock Aspect Ratio*. 

Mã C++ dưới đây cho bạn thấy cách khóa tỷ lệ khung hình:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ILayoutSlide> layout = pres->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
System::SharedPtr<ISlide> emptySlide = pres->get_Slides()->AddEmptySlide(layout);

System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
System::SharedPtr<IPPImage> presImage = pres->get_Images()->AddImage(image);

System::SharedPtr<IPictureFrame> pictureFrame = emptySlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 150.0f, static_cast<float>(presImage->get_Width()), static_cast<float>(presImage->get_Height()), presImage);

// set shape to have to preserve aspect ratio on resizing
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);
```

{{% alert title="LƯU Ý" color="warning" %}} 
Cài đặt *Lock Aspect Ratio* này chỉ bảo vệ tỷ lệ khung hình mà không ảnh hưởng tới hình ảnh bên trong. 
{{% /alert %}}

## **Sử Dụng Thuộc Tính StretchOff**

Bằng cách sử dụng các thuộc tính [StretchOffsetLeft](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.picture_fill_format#ad730bf8db88f47979d84643eb30d1471), [StretchOffsetTop](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.picture_fill_format#aa512e1f022e9c7ff83e9c51ba100709a), [StretchOffsetRight](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.picture_fill_format#ac3597692f9b7e3327d0f4a4169a53127) và [StretchOffsetBottom](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.picture_fill_format#a72acf6945f372a5729c0b760f4a5dc39) từ giao diện [IPictureFillFormat](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_picture_fill_format) và lớp [PictureFillFormat](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.picture_fill_format), bạn có thể chỉ định một hình chữ nhật lấp đầy. 

Khi xác định việc kéo dài của hình ảnh, một hình chữ nhật nguồn sẽ được tỷ lệ để vừa với hình chữ nhật lấp đầy đã chỉ định. Mỗi cạnh của hình chữ nhật lấp đầy được định nghĩa bằng một phần trăm offset từ cạnh tương ứng của hộp bao hình dạng. Phần trăm dương chỉ nội suy, phần trăm âm chỉ mở rộng.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation).
2. Lấy tham chiếu của slide thông qua chỉ mục của nó.
3. Thêm một hình chữ nhật `AutoShape`. 
4. Tạo một hình ảnh.
5. Đặt loại lấp đầy cho hình dạng.
6. Đặt chế độ lấp đầy hình ảnh cho hình dạng.
7. Thêm một hình ảnh để lấp đầy hình dạng.
8. Xác định offset của hình ảnh từ các cạnh tương ứng của hộp bao hình dạng.
9. Ghi bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

Mã C++ dưới đây minh họa quy trình sử dụng thuộc tính StretchOff:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto ppImage = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
auto slide = pres->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 400.0f, 400.0f, ppImage);

// Đặt hình ảnh kéo dãn từ mỗi phía trong phần thân hình dạng
auto pictureFormat = pictureFrame->get_PictureFormat();
pictureFormat->set_PictureFillMode(PictureFillMode::Stretch);
pictureFormat->set_StretchOffsetLeft(24.0f);
pictureFormat->set_StretchOffsetRight(24.0f);
pictureFormat->set_StretchOffsetTop(24.0f);
pictureFormat->set_StretchOffsetBottom(24.0f);

pres->Save(u"imageStretch.pptx", SaveFormat::Pptx);
```

## **Câu Hỏi Thường Gặp**

**Làm thế nào để biết những định dạng hình ảnh nào được hỗ trợ cho PictureFrame?**  
Aspose.Slides hỗ trợ cả hình ảnh raster (PNG, JPEG, BMP, GIF, v.v.) và hình ảnh vector (ví dụ, SVG) thông qua đối tượng hình ảnh được gán cho một [PictureFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/pictureframe/). Danh sách các định dạng được hỗ trợ thường trùng khớp với khả năng của engine chuyển đổi slide và hình ảnh.

**Việc thêm hàng chục hình ảnh lớn sẽ ảnh hưởng như thế nào tới kích thước và hiệu năng của PPTX?**  
Nhúng hình ảnh lớn sẽ làm tăng kích thước tệp và mức sử dụng bộ nhớ; liên kết hình ảnh giúp giảm kích thước bản trình bày nhưng yêu cầu các tệp ngoại vi phải luôn khả dụng. Aspose.Slides cung cấp khả năng thêm hình ảnh bằng liên kết để giảm kích thước tệp.

**Làm sao để khóa một đối tượng hình ảnh tránh việc di chuyển/điều chỉnh kích thước không mong muốn?**  
Sử dụng [shape locks](https://reference.aspose.com/slides/vi/cpp/aspose.slides/pictureframe/get_pictureframelock/) cho một [PictureFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/pictureframe/) (ví dụ, tắt chức năng di chuyển hoặc thay đổi kích thước). Cơ chế khóa được mô tả cho các hình dạng trong một [bài viết bảo vệ](/slides/vi/cpp/applying-protection-to-presentation/) riêng và được hỗ trợ cho nhiều loại hình dạng, bao gồm [PictureFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/pictureframe/).

**Độ trung thực của vector SVG có được duy trì khi xuất bản trình bày sang PDF/hình ảnh không?**  
Aspose.Slides cho phép trích xuất SVG từ một [PictureFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/pictureframe/) dưới dạng vector gốc. Khi [xuất sang PDF](/slides/vi/cpp/convert-powerpoint-to-pdf/) hoặc các định dạng raster [/slides/vi/cpp/convert-powerpoint-to-png/], kết quả có thể được raster hoá tùy thuộc vào cài đặt xuất; thực tế rằng SVG gốc được lưu dưới dạng vector được xác nhận qua hành vi trích xuất.