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
- hình raster
- hình SVG
- cắt hình ảnh
- xóa các khu vực đã cắt
- nén hình ảnh
- StretchOffset
- định dạng khung ảnh
- tỷ lệ tương đối
- hiệu ứng hình ảnh
- tỷ lệ khung hình
- PowerPoint
- OpenDocument
- bản trình chiếu
- C++
- Aspose.Slides
description: "Tạo, định dạng, liên kết, cắt, trích xuất và nén khung ảnh trong bản trình chiếu với Aspose.Slides cho C++."
---
## **Tổng quan**

Một khung ảnh là một hình dạng trên slide hiển thị một hình ảnh. Trong Aspose.Slides, tài nguyên hình ảnh và hình dạng hiển thị nó là các đối tượng riêng biệt: một [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) sở hữu các tài nguyên hình ảnh được nhúng thông qua [image collection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/get_images/), trong khi một [IPictureFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipictureframe/) điều khiển vị trí, kích thước, định dạng đường viền, xoay, cắt, hiệu ứng hình ảnh và các thiết lập khác ở mức khung.

Việc tách biệt này hữu ích khi cùng một hình ảnh được hiển thị nhiều lần. Thêm hình ảnh vào bản trình bày một lần, giữ lại [IPPImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ippimage/) trả về, và sử dụng tài nguyên hình ảnh đó khi tạo các khung ảnh.

Khung ảnh có thể chứa hình raster như PNG hoặc JPEG và hình vector SVG. Chúng cũng có thể tham chiếu tới các hình ảnh liên kết thay vì lưu trữ byte hình ảnh trong bản trình bày. Lựa chọn này ảnh hưởng đến khả năng di chuyển, kích thước tệp, việc trích xuất và hành vi xuất, vì vậy nên quyết định cách lưu trữ hình ảnh trước khi áp dụng định dạng hoặc tối ưu hoá.

## **Thêm và Định dạng Hình ảnh Nhúng**

Đối với hình ảnh nhúng, thêm dữ liệu hình ảnh vào bản trình bày và tạo khung ảnh bằng [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/shapecollection/addpictureframe/). Hình ảnh sẽ trở thành một phần của gói bản trình bày, do đó bản trình bày vẫn tự chứa khi được chuyển sang máy tính khác.

Ví dụ sau thêm một hình JPEG, tạo khung với kích thước gốc của hình và áp dụng định dạng đường viền và xoay:

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

Khung ảnh điều khiển hình học được hiển thị; việc thay đổi kích thước khung không thay đổi kích thước pixel gốc được lưu trữ trong tài nguyên hình ảnh nhúng. Sự khác biệt này trở nên quan trọng khi cắt hoặc nén hình ảnh sau này.

## **Sử dụng Tỷ lệ Tương đối**

[IPictureFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipictureframe/) cho phép điều chỉnh tỷ lệ chiều rộng và chiều cao tương đối cho khung. Giá trị `1.0` tương đương với 100% kích thước ban đầu của ảnh. Tỷ lệ tương đối hữu ích khi quy trình cần duy trì mối quan hệ với kích thước nguồn ảnh thay vì tính toán kích thước cuối cùng bằng tay.

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

Tỷ lệ tương đối thay đổi cài đặt tỷ lệ của khung; nó không tái mẫu hoặc nén hình ảnh nhúng.

## **Hình ảnh Nhúng và Liên kết**

Một hình ảnh nhúng lưu trữ dữ liệu hình ảnh bên trong bản trình bày và do đó là lựa chọn an toàn nhất cho khả năng di chuyển và hiển thị dự đoán được. Một hình ảnh liên kết lưu trữ vị trí ngoại vi thông qua đường dẫn liên kết [ISlidesPicture](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidespicture/) thay vì nhúng dữ liệu hình ảnh theo cùng cách.

Hình ảnh liên kết có thể giảm lượng dữ liệu hình ảnh lưu trong PPTX, nhưng chúng tạo ra một phụ thuộc ngoại vi. Tệp liên kết phải vẫn có thể truy cập được cho ứng dụng mở hoặc hiển thị bản trình bày. Nếu đường dẫn thay đổi, tệp bị di chuyển, hoặc tài nguyên không khả dụng, hình ảnh liên kết có thể không hiển thị như mong đợi. Đối với các bản trình bày phải được gửi email, lưu trữ, hoặc hiển thị trong môi trường cô lập, hình ảnh nhúng thường đáng tin cậy hơn.

### **Thêm Hình ảnh Liên kết**

Ví dụ sau tạo một khung ảnh và chỉ tới một tệp hình ảnh cục bộ. Nó chỉ xử lý việc liên kết hình ảnh; việc liên kết video là một quy trình truyền thông riêng và không được trộn vào ví dụ này.

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

Sử dụng liên kết khi quản lý tệp ngoại vi có chủ đích. Đừng sử dụng chúng chỉ để thay thế nén: một PPTX nhỏ với các phụ thuộc hình ảnh bị hỏng thường ít hữu ích hơn một bản trình bày lớn tự chứa.

## **Trích xuất Hình ảnh từ Khung Ảnh**

Trước khi trích xuất hình ảnh từ một bản trình bày hiện có, hãy kiểm tra rằng một hình dạng thực sự là [IPictureFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipictureframe/) và nó chứa một hình ảnh nhúng. Các khung ảnh liên kết có thể không chứa byte hình ảnh có thể trích xuất theo cùng cách.

### **Trích xuất Hình ảnh Raster**

API hình ảnh hiện đại sử dụng [IImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iimage/) trực tiếp. Ví dụ sau tìm hình raster nhúng đầu tiên trên một slide và lưu nó dưới dạng PNG:

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

Lưu qua [IImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iimage/) sẽ chuyển đổi hình ảnh đã trích xuất sang định dạng đầu ra yêu cầu. Nếu bạn cần byte đã mã hoá lưu trong bản trình bày thay vì tệp raster đã chuyển đổi, hãy sử dụng dữ liệu nhị phân của tài nguyên hình ảnh thay thế.

### **Trích xuất Hình ảnh SVG**

Đối với hình SVG, [IPPImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ippimage/) cung cấp một đối tượng [ISvgImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isvgimage/). Điều này cho phép bạn lấy dữ liệu SVG trực tiếp thay vì raster hoá hình ảnh trước.

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

Giữ nội dung SVG dưới dạng SVG bảo quản nguồn vector bên trong bản trình bày. Các xuất raster như PNG hoặc JPEG buộc phải render nội dung vector thành pixel. Xuất slide thành PDF hoặc SVG cũng là một thao tác render, vì vậy đồ họa đã xuất không nên được coi là bản sao byte‑for‑byte của SVG nhúng gốc; hãy sử dụng dữ liệu [ISvgImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isvgimage/) nhúng khi cần tài nguyên vector gốc.

## **Cắt Hình ảnh**

Cắt thay đổi phần hình ảnh nào hiển thị bên trong khung. Các giá trị cắt trên [IPictureFillFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipicturefillformat/) là phần trăm của kích thước nguồn ảnh. Cắt không xóa ngay các pixel ẩn khỏi hình ảnh nhúng; nó chỉ thay đổi vùng hiển thị.

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

Vì dữ liệu hình ảnh ẩn vẫn còn, việc cắt có thể được thay đổi sau mà không mất pixel gốc. Nếu kích thước tệp quan trọng hơn tính khả năng đảo ngược, các khu vực đã cắt có thể được xóa vật lý như mô tả trong phần tiếp theo.

## **Xóa Dữ liệu Hình ảnh Đã Cắt**

[IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) loại bỏ dữ liệu hình ảnh nằm ngoài khu vực cắt hiện tại và trả về tài nguyên hình ảnh kết quả. Điều này có thể giảm kích thước tệp, nhưng là một tối ưu hoá phá hủy: sau khi lưu bản trình bày, các pixel đã bị xóa sẽ không còn khả năng phục hồi cho thao tác hủy cắt sau này.

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

Phương thức có thể thêm một tài nguyên hình ảnh mới vào bản trình bày. Nếu hình ảnh gốc cũng được các khung ảnh khác sử dụng, những khung đó vẫn cần tài nguyên hiện có, vì vậy việc xóa các khu vực đã cắt không nhất thiết giảm tổng số hình ảnh. Cắt nội dung WMF hoặc EMF bằng phương pháp này sẽ raster hoá kết quả cắt thành PNG.

## **Nén Hình ảnh Raster**

[IPictureFillFormat::CompressImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipicturefillformat/compressimage/) giảm độ phân giải hình raster so với kích thước mà hình ảnh được hiển thị. Nó cũng có thể loại bỏ các khu vực đã cắt trong cùng một thao tác. Phương thức trả về `true` khi hình ảnh đã được thay đổi kích thước hoặc cắt và `false` khi không cần thay đổi.

Sử dụng giá trị [PicturesCompression](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/picturescompression/) đã định trước khi độ phân giải mục tiêu tiêu chuẩn là đủ:

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

Một giá trị DPI dương tùy chỉnh có thể được truyền thay cho enum khi cần mục tiêu cụ thể.

Nén chỉ dành cho hình raster. Nội dung SVG và metafile không bị giảm bởi quy trình nén raster này. Ngoài ra, hãy nhớ rằng độ phân giải thấp hơn và các khu vực đã cắt bị xóa không thể khôi phục từ bản trình bày đã tối ưu hoá. Chọn độ phân giải mục tiêu dựa trên kích thước lớn nhất mà hình ảnh sẽ thực tế được xem hoặc xuất thay vì áp dụng DPI thấp nhất trên toàn bộ.

## **Quản lý Hiệu ứng Biến đổi Hình ảnh**

Đối với quy trình hoàn chỉnh bao gồm độ sáng, độ tương phản, biến đổi màu, làm mờ, hiệu ứng alpha, chuỗi có thứ tự, kiểm tra, loại bỏ và xác thực vòng quay, xem [Image Transform Effects](/slides/vi/cpp/image-transform-effects/).

## **Khóa Hình dạng Khung Ảnh**

Cài đặt [IPictureFrameLock](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipictureframelock/) kiểm soát các thao tác chỉnh sửa nào bị tắt cho một khung ảnh. Ví dụ, [aspect-ratio lock](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) giữ tỉ lệ hình dạng khi nó được thay đổi kích thước.

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

Khóa áp dụng cho hình dạng khung ảnh. Nó không buộc hình ảnh nguồn phải được tái mẫu hoặc thay đổi vĩnh viễn thành cùng tỉ lệ.

## **Điều chỉnh Giá trị StretchOffset**

Khi chế độ lấp đầy hình ảnh là stretch, các giá trị stretch‑offset trên [IPictureFillFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipicturefillformat/) xác định hình chữ nhật lấp đầy tương đối với hộp bao quanh khung ảnh. Phần trăm dương tạo một lề trong từ cạnh, trong khi phần trăm âm tạo một lề ra ngoài.

Điều này khác với cắt. Giá trị cắt chọn phần nào của nguồn ảnh hiển thị; stretch offset thay đổi hình chữ nhật mà hình lấp đầy được kéo dãn vào.

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

Sử dụng stretch offset để đặt vị trí lấp đầy. Sử dụng thuộc tính cắt khi mục tiêu là ẩn các cạnh của nguồn ảnh.

## **Lưu trữ, Kích thước Tệp và Các cân nhắc Khi Xuất**

Các điểm cân bằng chính dễ quản lý hơn khi lưu trữ hình ảnh và định dạng khung ảnh được xử lý riêng biệt:

- **Hình ảnh nhúng** làm bản trình bày tự chứa và là đáng tin cậy nhất cho việc chia sẻ và render phía máy chủ, nhưng các hình raster lớn làm tăng kích thước PPTX và mức sử dụng bộ nhớ.
- **Hình ảnh liên kết** có thể giữ gói nhỏ hơn, nhưng bản trình bày phụ thuộc vào các tệp ngoại vi vẫn tồn tại ở các đường dẫn hoặc vị trí đã lưu.
- **Cắt** ban đầu không phá hủy. Các pixel ẩn vẫn được nhúng cho đến khi các khu vực đã cắt được xóa rõ ràng hoặc bị loại bỏ trong quá trình nén.
- **Nén** có thể giảm đáng kể kích thước tệp cho các hình raster quá lớn, nhưng sẽ mất độ phân giải nguồn. Nên áp dụng sau khi biết kích thước thực tế trên slide.
- **Hình ảnh SVG** nên để lại dưới dạng SVG khi việc bảo tồn vector quan trọng. Trích xuất trực tiếp SVG nhúng khi bạn cần tài nguyên vector gốc. Các xuất slide raster luôn chuyển slide đã render thành pixel.
- **Hình ảnh lặp lại** nên tái sử dụng tài nguyên [IPPImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ippimage/) hiện có khi có thể thay vì tải lại cùng tệp nhiều lần trong quy trình.

Đối với các bản trình bày lớn, tối ưu hoá hình ảnh thường hiệu quả nhất khi thực hiện có chọn lọc: giữ logo và sơ đồ dưới dạng nội dung vector, nén ảnh chụp theo kích thước hiển thị thực tế, xóa pixel đã cắt chỉ khi không cần chỉnh sửa sau này, và tránh liên kết ngoại vi trừ khi quản lý phụ thuộc là một phần của thiết kế triển khai.

## **Câu hỏi thường gặp**

**Khác nhau giữa khung ảnh và tài nguyên hình ảnh là gì?**

[IPPImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ippimage/) đại diện cho một tài nguyên hình ảnh gắn với bản trình bày. [IPictureFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipictureframe/) là một hình dạng trên slide hiển thị hình ảnh và lưu trữ các thông số hình học và định dạng ở mức khung như kích thước, xoay, giá trị cắt, hiệu ứng và khóa.

**Nên nhúng hay liên kết hình ảnh?**

Nhúng hình ảnh khi bản trình bày phải di động, lưu trữ hoặc render mà không cần truy cập tài nguyên ngoại vi. Liên kết hình ảnh chỉ khi việc giữ các tệp hình ảnh bên ngoài PPTX là có chủ đích và các vị trí ngoại vi có thể được duy trì một cách đáng tin cậy.

**Cắt ảnh có giảm kích thước PPTX không?**

Không tự nhiên. Cài đặt cắt thông thường ẩn một phần của hình nguồn nhưng vẫn giữ các pixel bên dưới. Sử dụng [IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) hoặc nén ảnh với việc loại bỏ khu vực đã cắt khi các pixel đó có thể bị loại bỏ vĩnh viễn.

**Có thể khôi phục chất lượng ảnh sau khi nén không?**

Không. Nén có thể giảm độ phân giải raster lưu trữ, và việc loại bỏ các khu vực đã cắt sẽ xóa dữ liệu ảnh. Giữ nguyên ảnh nguồn bên ngoài bản trình bày nếu có thể sẽ cần chỉnh sửa độ phân giải cao sau này.

**Cách xử lý hình ảnh SVG như thế nào?**

Giữ nội dung SVG dưới dạng SVG khi độ chính xác vector quan trọng. [ISvgImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isvgimage/) nhúng có thể được trích xuất trực tiếp. Render slide thành định dạng raster như PNG hoặc JPEG sẽ raster hoá SVG như một phần của hình ảnh slide.

**Làm sao tránh việc ép kiểu không an toàn khi đọc slide hiện có?**

Kiểm tra loại hình dạng trước khi sử dụng các thành viên đặc thù cho khung ảnh. Kiểm tra hình dạng với [IPictureFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipictureframe/) trước khi thực hiện ép kiểu thời gian chạy, và gán kết quả ép kiểu vào một biến cục bộ trước khi truy cập các thành viên đặc thù.