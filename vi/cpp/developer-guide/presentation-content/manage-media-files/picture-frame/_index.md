---
title: Quản lý Khung Ảnh trong Bản Trình Chiếu bằng C++
linktitle: Khung Ảnh
type: docs
weight: 10
url: /vi/cpp/picture-frame/
keywords:
- khung ảnh
- thêm khung ảnh
- tạo khung ảnh
- hình ảnh nhúng
- hình ảnh liên kết
- trích xuất hình ảnh
- hình ảnh raster
- hình ảnh SVG
- cắt hình ảnh
- xóa các vùng đã cắt
- nén hình ảnh
- StretchOffset
- định dạng khung ảnh
- tỷ lệ tương đối
- hiệu ứng hình ảnh
- tỉ lệ khung hình
- PowerPoint
- OpenDocument
- bản trình chiếu
- C++
- Aspose.Slides
description: "Tạo, định dạng, liên kết, cắt, trích xuất và nén khung ảnh trong bản trình chiếu với Aspose.Slides cho C++."
---
## **Tổng quan**

Khung ảnh là một hình dạng trên slide hiển thị hình ảnh. Trong Aspose.Slides, tài nguyên hình ảnh và hình dạng hiển thị nó là các đối tượng riêng biệt: một [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) sở hữu các tài nguyên hình ảnh được nhúng thông qua [bộ sưu tập hình ảnh](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/get_images/) của nó, trong khi một [IPictureFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipictureframe/) điều khiển vị trí, kích thước, định dạng đường viền, xoay, cắt, hiệu ứng hình ảnh và các thiết lập cấp khung khác.

Sự tách biệt này hữu ích khi cùng một hình ảnh được hiển thị nhiều lần. Thêm hình ảnh vào bản trình chiếu một lần, giữ lại [IPPImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ippimage/) được trả về, và sử dụng tài nguyên hình ảnh đó khi tạo các khung ảnh.

Khung ảnh có thể chứa các hình ảnh raster như PNG hoặc JPEG và các hình ảnh vector SVG. Chúng cũng có thể tham chiếu tới các hình ảnh được liên kết thay vì lưu trữ byte hình ảnh trong bản trình chiếu. Lựa chọn này ảnh hưởng đến khả năng di chuyển, kích thước tệp, việc trích xuất và hành vi xuất, vì vậy nên quyết định cách lưu trữ hình ảnh trước khi áp dụng định dạng hoặc tối ưu hoá.

## **Thêm và Định dạng Hình ảnh Nhúng**

Đối với hình ảnh nhúng, thêm dữ liệu hình ảnh vào bản trình chiếu và tạo một khung ảnh bằng [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/shapecollection/addpictureframe/). Hình ảnh trở thành một phần của gói bản trình chiếu, vì vậy bản trình chiếu vẫn độc lập khi được chuyển sang máy tính khác.

Ví dụ sau thêm một hình JPEG, tạo khung với kích thước gốc của hình ảnh và áp dụng định dạng đường viền cùng việc xoay:

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

Khung ảnh điều khiển hình học hiển thị; thay đổi kích thước khung không làm thay đổi kích thước pixel gốc được lưu trong tài nguyên hình ảnh nhúng. Sự khác biệt này trở nên quan trọng khi cắt hoặc nén hình ảnh sau này.

## **Sử dụng Tỷ lệ Tương đối**

[IPictureFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipictureframe/) cung cấp khả năng thu phóng chiều rộng và chiều cao tương đối cho khung. Giá trị `1.0` tương ứng với 100% kích thước ảnh gốc. Tỷ lệ tương đối hữu ích khi quy trình làm việc cần giữ mối quan hệ so với kích thước ảnh nguồn thay vì tính toán kích thước cuối cùng bằng tay.

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

Tỷ lệ tương đối thay đổi cài đặt thu phóng của khung; nó không tái mẫu hay nén hình ảnh nhúng.

## **Hình ảnh Nhúng và Liên kết**

Một hình ảnh nhúng lưu trữ dữ liệu hình ảnh bên trong bản trình chiếu và do đó là lựa chọn an toàn nhất cho khả năng di chuyển và việc render dự đoán được. Một hình ảnh liên kết lưu trữ vị trí bên ngoài thông qua đường dẫn liên kết của [ISlidesPicture](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidespicture/) thay vì nhúng dữ liệu hình ảnh theo cách đó.

Hình ảnh liên kết có thể giảm lượng dữ liệu hình ảnh lưu trong PPTX, nhưng chúng tạo ra một phụ thuộc bên ngoài. Tệp liên kết phải vẫn có thể truy cập được bởi ứng dụng mở hoặc render bản trình chiếu. Nếu đường dẫn thay đổi, tệp được di chuyển, hoặc tài nguyên không khả dụng, hình ảnh liên kết có thể không được hiển thị như mong đợi. Đối với các bản trình chiếu cần được gửi email, lưu trữ, hoặc render trong môi trường cô lập, hình ảnh nhúng thường đáng tin cậy hơn.

### **Thêm Hình ảnh Liên kết**

Ví dụ sau tạo một khung ảnh và trỏ nó tới một tệp hình ảnh cục bộ. Nó chỉ xử lý việc liên kết hình ảnh; việc liên kết video là một quy trình media riêng và cố ý không được trộn vào ví dụ này.

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

Sử dụng liên kết khi việc quản lý tệp bên ngoài là có chủ đích. Đừng dùng chúng chỉ để thay thế cho việc nén: một PPTX nhỏ với các phụ thuộc hình ảnh bị hỏng thường ít hữu ích hơn so với một bản trình chiếu lớn và tự chứa.

## **Trích xuất Hình ảnh từ Khung Ảnh**

Trước khi trích xuất hình ảnh khỏi một bản trình chiếu hiện có, hãy kiểm tra xem một hình dạng thực sự có phải là [IPictureFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipictureframe/) và nó có chứa hình ảnh nhúng không. Các khung ảnh liên kết có thể không chứa byte hình ảnh có thể được trích xuất theo cùng cách.

### **Trích xuất Hình ảnh Raster**

API hình ảnh hiện đại sử dụng trực tiếp [IImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iimage/). Ví dụ sau tìm hình raster nhúng đầu tiên trên một slide và lưu nó dưới dạng PNG:

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

Lưu thông qua [IImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iimage/) sẽ chuyển đổi hình ảnh đã trích xuất sang định dạng đầu ra được yêu cầu. Nếu bạn cần các byte đã mã hoá lưu trong bản trình chiếu thay vì một tệp raster đã chuyển đổi, hãy sử dụng dữ liệu nhị phân của tài nguyên hình ảnh thay thế.

### **Trích xuất Hình ảnh SVG**

Đối với hình ảnh SVG, [IPPImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ippimage/) cung cấp một đối tượng [ISvgImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isvgimage/). Điều này cho phép bạn lấy dữ liệu SVG trực tiếp thay vì raster hoá hình ảnh trước.

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

Giữ nội dung SVG dưới dạng SVG bảo tồn nguồn vector bên trong bản trình chiếu. Các xuất raster như PNG hoặc JPEG buộc phải render nội dung vector thành pixel. Xuất slide dưới dạng PDF hoặc SVG cũng là một hoạt động render, vì vậy đồ họa được xuất không nên được coi là bản sao byte‑for‑byte của SVG nhúng gốc; hãy sử dụng dữ liệu [ISvgImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isvgimage/) nhúng khi cần tài nguyên vector gốc.

## **Cắt Hình ảnh**

Cắt ảnh thay đổi phần nào của hình ảnh sẽ hiển thị bên trong khung. Các giá trị cắt trên [IPictureFillFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipicturefillformat/) là phần trăm kích thước của hình ảnh nguồn. Cắt ảnh không xóa ngay các pixel ẩn khỏi hình ảnh nhúng; nó chỉ thay đổi vùng hiển thị.

Ví dụ sau tìm một khung ảnh một cách an toàn và áp dụng các giá trị cắt:

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

Vì dữ liệu hình ảnh ẩn vẫn còn, việc cắt có thể được thay đổi sau này mà không mất các pixel gốc. Nếu kích thước tệp quan trọng hơn tính khả năng phục hồi, các vùng đã cắt có thể được xóa thực tế như mô tả trong phần tiếp theo.

## **Xóa Dữ liệu Hình ảnh Đã Cắt**

[IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) loại bỏ dữ liệu hình ảnh nằm ngoài hình chữ nhật cắt hiện tại và trả về tài nguyên hình ảnh kết quả. Điều này có thể giảm kích thước tệp, nhưng là một tối ưu hoá phá hủy: sau khi bản trình chiếu được lưu, các pixel đã xóa sẽ không còn khả dụng cho thao tác hủy cắt sau này.

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

Phương thức này có thể thêm một tài nguyên hình ảnh mới vào bản trình chiếu. Nếu hình ảnh gốc cũng được các khung ảnh khác sử dụng, các khung đó vẫn cần tài nguyên hiện có, vì vậy việc xóa các vùng đã cắt không nhất thiết giảm tổng số hình ảnh. Cắt nội dung WMF hoặc EMF bằng phương pháp này sẽ raster hoá kết quả đã cắt thành PNG.

## **Nén Hình ảnh Raster**

[IPictureFillFormat::CompressImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipicturefillformat/compressimage/) giảm độ phân giải của hình ảnh raster so với kích thước mà hình ảnh được hiển thị. Nó cũng có thể xóa các vùng đã cắt trong cùng một thao tác. Phương thức trả về `true` khi hình ảnh đã được thay đổi kích thước hoặc cắt và `false` khi không cần thay đổi.

Sử dụng giá trị [PicturesCompression](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/picturescompression/) đã định sẵn khi độ phân giải mục tiêu tiêu chuẩn là đủ:

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

Có thể truyền giá trị DPI dương tùy chỉnh thay vì giá trị enum khi cần một mục tiêu cụ thể.

Nén được thiết kế cho hình ảnh raster. Nội dung SVG và metafile không bị giảm bằng quy trình nén raster này. Ngoài ra, hãy nhớ rằng độ phân giải thấp hơn và các vùng đã xóa không thể khôi phục từ bản trình chiếu đã tối ưu hoá. Chọn độ phân giải mục tiêu dựa trên kích thước lớn nhất mà hình ảnh thực tế sẽ được xem hoặc xuất, thay vì áp dụng DPI thấp nhất cho toàn bộ.

## **Kiểm tra Hiệu ứng Hình ảnh**

Hiệu ứng hình ảnh được lưu trên hình ảnh được khung sử dụng. Bộ sưu tập biến đổi hình ảnh có thể chứa các hiệu ứng như điều chế alpha cố định cho độ trong suốt và độ sáng cho độ sáng và độ tương phản. Ví dụ dưới đây đọc an toàn cả hai loại hiệu ứng từ khung ảnh đầu tiên trên một slide:

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

Các hiệu ứng này thay đổi cách hình ảnh được render trong khung; chúng không ghi lại lại các byte hình ảnh nhúng gốc.

## **Khóa Hình học Khung Ảnh**

Cài đặt [IPictureFrameLock](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipictureframelock/) kiểm soát các thao tác chỉnh sửa nào bị vô hiệu hoá cho một khung ảnh. Ví dụ, [khóa tỉ lệ khung hình](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) giữ nguyên tỷ lệ của hình dạng khi nó được thay đổi kích thước.

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

Khóa áp dụng cho hình dạng khung ảnh. Nó không buộc hình ảnh nguồn phải được tái mẫu hoặc thay đổi vĩnh viễn thành cùng một tỉ lệ khung hình.

## **Điều chỉnh Giá trị StretchOffset**

Khi chế độ lấp đầy hình ảnh là stretch, các giá trị stretch‑offset trên [IPictureFillFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipicturefillformat/) xác định hình chữ nhật lấp đầy so với hộp giới hạn của khung ảnh. Phần trăm dương tạo ra một phần lùi vào từ cạnh, trong khi phần trăm âm tạo ra một phần mở rộng ra ngoài.

Điều này khác với việc cắt. Các giá trị cắt chọn phần nào của hình ảnh nguồn sẽ hiển thị; stretch offset thay đổi hình chữ nhật mà phần lấp đầy hình ảnh hiển thị sẽ được kéo dài.

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

Sử dụng stretch offset để đặt vị trí lấp đầy. Sử dụng thuộc tính cắt khi mục tiêu là ẩn các cạnh của hình ảnh nguồn.

## **Xem xét về Lưu trữ, Kích thước Tệp và Xuất**

Các cân nhắc chính dễ quản lý hơn khi việc lưu trữ hình ảnh và định dạng khung ảnh được xử lý riêng biệt:

- **Hình ảnh nhúng** làm cho bản trình chiếu tự chứa và là đáng tin cậy nhất cho việc chia sẻ và render phía máy chủ, nhưng các hình raster lớn làm tăng kích thước PPTX và sử dụng bộ nhớ.
- **Hình ảnh liên kết** có thể giữ gói nhỏ hơn, nhưng bản trình chiếu phụ thuộc vào việc các tệp bên ngoài vẫn khả dụng tại các đường dẫn hoặc vị trí đã lưu.
- **Cắt** ban đầu không phá hủy. Các pixel ẩn vẫn được nhúng cho đến khi các vùng đã cắt được xóa rõ ràng hoặc loại bỏ trong quá trình nén.
- **Nén** có thể giảm đáng kể kích thước tệp cho các hình raster quá lớn, nhưng nó đánh đổi độ phân giải nguồn. Nên áp dụng sau khi biết kích thước mong muốn trên slide.
- **Hình ảnh SVG** nên để lại dưới dạng SVG khi việc bảo tồn vector quan trọng. Trích xuất SVG nhúng trực tiếp khi bạn cần tài nguyên vector. Các xuất slide raster luôn chuyển đổi slide đã render thành pixel.
- **Hình ảnh lặp lại** nên tái sử dụng tài nguyên [IPPImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ippimage/) hiện có khi có thể thay vì tải cùng một tệp nhiều lần vào quy trình bản trình chiếu.

Đối với các bản trình chiếu lớn, tối ưu hoá hình ảnh thường hiệu quả nhất khi thực hiện một cách chọn lọc: giữ logo và sơ đồ dưới dạng nội dung vector, nén ảnh chụp dựa trên kích thước hiển thị thực tế, chỉ xóa các pixel đã cắt khi không cần chỉnh sửa sau này, và tránh các liên kết bên ngoài trừ khi quản lý phụ thuộc là một phần của thiết kế triển khai.

## **Câu hỏi thường gặp**

**Khác biệt giữa khung ảnh và tài nguyên hình ảnh là gì?**

Một [IPPImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ippimage/) đại diện cho một tài nguyên hình ảnh liên kết với bản trình chiếu. Một [IPictureFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipictureframe/) là một hình dạng trên slide hiển thị hình ảnh và lưu trữ các thông tin hình học và định dạng cấp khung như kích thước, xoay, giá trị cắt, hiệu ứng và khóa.

**Tôi nên nhúng hay liên kết hình ảnh?**

Nhúng hình ảnh khi bản trình chiếu phải di động, lưu trữ, hoặc render mà không cần truy cập vào tài nguyên bên ngoài. Liên kết hình ảnh chỉ khi việc giữ các tệp hình ảnh bên ngoài PPTX là có chủ đích và các vị trí bên ngoài có thể được duy trì một cách đáng tin cậy.

**Cắt ảnh có làm giảm kích thước tệp PPTX không?**

Không phải tự nhiên. Cài đặt cắt thông thường chỉ ẩn một phần hình ảnh nguồn nhưng vẫn giữ các pixel nền. Sử dụng [IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) hoặc nén hình ảnh kèm xóa vùng đã cắt khi các pixel đó có thể bị loại bỏ vĩnh viễn.

**Tôi có thể khôi phục chất lượng hình ảnh sau khi nén không?**

Không. Nén có thể giảm độ phân giải raster lưu trữ, và việc xóa các vùng đã cắt sẽ loại bỏ dữ liệu hình ảnh. Giữ nguyên hình ảnh nguồn bên ngoài bản trình chiếu nếu sau này có thể cần chỉnh sửa ở độ phân giải cao.

**Cách xử lý hình ảnh SVG như thế nào?**

Giữ nội dung SVG dưới dạng SVG khi độ chính xác vector quan trọng. [ISvgImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isvgimage/) nhúng có thể được trích xuất trực tiếp. Render một slide sang định dạng raster như PNG hoặc JPEG sẽ raster hoá SVG như một phần của hình ảnh slide.

**Làm sao để tránh các ép kiểu không an toàn khi đọc các slide hiện có?**

Kiểm tra loại hình dạng trước khi sử dụng các thành viên riêng của khung ảnh. Kiểm tra hình dạng với [IPictureFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipictureframe/) trước khi thực hiện ép kiểu ở thời gian chạy, và gán kết quả ép kiểu vào một biến cục bộ trước khi truy cập các thành viên riêng của khung ảnh.